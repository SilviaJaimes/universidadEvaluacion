using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class PersonaRepository : GenericRepository<Persona>, IPersona
{
    private readonly ApiContext _context;

    public PersonaRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<object>> ListadoAlumnos()
    {
        var alumnos = await _context.Personas
            .Where(p => p.Tipo == Persona.Tipos.Alumno)
            .OrderBy(p => p.Apellido1)
            .ThenBy(p => p.Apellido2)
            .ThenBy(p => p.Nombre)
            .Select(p => new
            {
                PrimerApellido = p.Apellido1,
                SegundoApellido = p.Apellido2,
                Nombre = p.Nombre
            })
            .ToListAsync();

        return alumnos;
    }

    public async Task<IEnumerable<object>> AlumnosSinTelefono()
    {
        var alumnos = await (
            from p in _context.Personas
            where p.Tipo == Persona.Tipos.Alumno
            where p.Telefono == null
            select new
            {
                Nombre = p.Nombre,
                PrimerApellido = p.Apellido1,
                SegundoApellido = p.Apellido2
            })
            .Distinct()
            .ToListAsync();

        return alumnos;
    }

    public async Task<IEnumerable<object>> Alumnos1999()
    {
        int year = 1999;
        DateOnly inicio = new DateOnly(year, 1, 1);
        DateOnly Fin = new DateOnly(year, 12, 31);
        var alumnos = await (
            from p in _context.Personas
            where p.Tipo == Persona.Tipos.Alumno
            where p.FechaNacimiento >=  inicio && p.FechaNacimiento <= Fin 
            select new
            {
                Nombre = p.Nombre,
                PrimerApellido = p.Apellido1,
                SegundoApellido = p.Apellido2
            })
            .Distinct()
            .ToListAsync();

        return alumnos;
    }

    public async Task<IEnumerable<object>> ProfesoresSinTelefono()
    {
        var profesores = await (
            from p in _context.Personas
            where p.Tipo == Persona.Tipos.Profesor
            where p.Telefono == null
            where p.Nit.EndsWith("K")
            select new
            {
                Nit = p.Nit,
                Nombre = p.Nombre,
                PrimerApellido = p.Apellido1,
                SegundoApellido = p.Apellido2
            })
            .Distinct()
            .ToListAsync();

        return profesores;
    }

    public async Task<IEnumerable<object>> AlumnasMatricula()
    {
        var alumnas = await (
            from m in _context.Matriculas
            join p in _context.Personas on m.IdAlumno equals p.Id
            where p.Tipo == Persona.Tipos.Alumno
            where p.Sexo == Persona.Sexos.M
            where m.Asignatura.Grado.Nombre == "Grado en Ingeniería Informática (Plan 2015)"
            select new
            {
                Nombre = p.Nombre,
                PrimerApellido = p.Apellido1,
                SegundoApellido = p.Apellido2,
                Grado = m.Asignatura.Grado.Nombre
            })
            .Distinct()
            .ToListAsync();

        return alumnas;
    }

    public async Task<IEnumerable<object>> ProfesorDepartamento()
    {
        var profesores = await _context.Personas
            .Where(p => p.Tipo == Persona.Tipos.Profesor)
            .OrderBy(p => p.Apellido1)
            .ThenBy(p => p.Apellido2)
            .ThenBy(p => p.Nombre)
            .Select(p => new
            {
                PrimerApellido = p.Apellido1,
                SegundoApellido = p.Apellido2,
                Nombre = p.Nombre,
                NombreDepartamento = _context.Profesores
                    .Where(profesor => profesor.IdProfesor == p.Id)
                    .Select(profesor => profesor.Departamento.Nombre)
                    .FirstOrDefault()
            })
            .ToListAsync();

        return profesores;
    }

    public async Task<IEnumerable<object>> AlumnosCursoEscolar()
    {
        var alumnos = await (
            from m in _context.Matriculas
            join p in _context.Personas on m.IdAlumno equals p.Id
            where p.Tipo == Persona.Tipos.Alumno
            where m.CursoEscolar.AnyoInicio == 2018
            where m.CursoEscolar.AnyoFin == 2019
            select new
            {
                Nombre = p.Nombre,
                PrimerApellido = p.Apellido1,
                SegundoApellido = p.Apellido2,
            })
            .Distinct()
            .ToListAsync();

        return alumnos;
    }

    public async Task<IEnumerable<object>> ProfesoresDepartamentos()
    {
        var profesores = await (
            from pr in _context.Profesores
            join p in _context.Personas on pr.IdProfesor equals p.Id into personaGroup
            from persona in personaGroup.DefaultIfEmpty()
            join d in _context.Departamentos on pr.IdDepartamento equals d.Id into departamentoGroup
            from departamento in departamentoGroup.DefaultIfEmpty()
            where persona.Tipo == Persona.Tipos.Profesor
            orderby departamento != null ? departamento.Nombre : "Sin departamento", persona.Apellido1, persona.Apellido2, persona.Nombre
            select new
            {
                NombreDepartamento = departamento != null ? departamento.Nombre : "Sin departamento",
                PrimerApellido = persona.Apellido1,
                SegundoApellido = persona.Apellido2,
                Nombre = persona.Nombre
            })
            .ToListAsync();

        return profesores;
    }

    public async Task<IEnumerable<object>> ProfesoresSinAsignatura()
    {
        var profesores = await (
            from p in _context.Personas
            where p.Tipo == Persona.Tipos.Profesor
            where !_context.Asignaturas.Any(a => a.IdProfesor == p.Id)
            select new
            {
                Nombre = p.Nombre,
                PrimerApellido = p.Apellido1,
                SegundoApellido = p.Apellido2
            })
            .ToListAsync();

        return profesores;
    }

    public async Task<int> TotalAlumnas()
    {
        int numeroTotalAlumnasFemeninas = await _context.Personas
            .Where(p => p.Tipo == Persona.Tipos.Alumno && p.Sexo == Persona.Sexos.M)
            .CountAsync();

        return numeroTotalAlumnasFemeninas;
    }

    public async Task<int> AlumnosNacidosEn1999()
    {
        int alumnos = await _context.Personas
            .Where(p => p.Tipo == Persona.Tipos.Alumno && p.FechaNacimiento.Year == 1999)
            .CountAsync();

        return alumnos;
    }

    public async Task<IEnumerable<object>> ProfesoresPorDepartamento()
    {
        var resultado = await _context.Departamentos
            .Where(d => d.Profesores.Any()) 
            .Select(d => new
            {
                NombreDepartamento = d.Nombre, 
                NumeroProfesores = d.Profesores.Count
            })
            .OrderByDescending(dp => dp.NumeroProfesores)
            .ToListAsync();

        return resultado;
    }

    public async Task<IEnumerable<object>> AlumnosMatriculadosPorCurso()
    {
        var resultado = await _context.Matriculas
            .GroupBy(m => m.CursoEscolar.AnyoInicio)
            .Select(g => new
            {
                AnioCursoEscolar = g.Key,
                NumAlumnosMatriculados = g.Count()
            })
            .OrderBy(g => g.AnioCursoEscolar)
            .ToListAsync();

        return resultado;
    }

    public async Task<IEnumerable<object>> AsignaturaPorProfesor()
    {
        var resultado = await _context.Profesores
            .Where(d => d.Asignaturas == d.Asignaturas) 
            .Select(d => new
            {
                Id = d.IdProfesor,
                Nombre = d.Persona.Nombre, 
                PrimerApellido = d.Persona.Apellido1, 
                SegundoApellido = d.Persona.Apellido2, 
                CantidadAsignaturas = d.Asignaturas.Count
            })
            .OrderByDescending(dp => dp.CantidadAsignaturas)
            .ToListAsync();

        return resultado;
    }

    public async Task<Persona> ObtenerAlumnoMasJoven()
    {
        var alumnoMasJoven = await _context.Personas
            .Where(p => p.Tipo == Persona.Tipos.Alumno)
            .OrderBy(p => p.FechaNacimiento)
            .FirstOrDefaultAsync();

        return alumnoMasJoven;
    }

    public async Task<IEnumerable<object>> ProfesoresSinDepartamentos()
    {
        var profesoresSinDepartamento = await _context.Personas
            .Where(p => p.Tipo == Persona.Tipos.Profesor && p.Profesores.All(pf => pf.Departamento == null))
            .Select(p => new
            {
                NombreProfesor = $"{p.Nombre} {p.Apellido1} {p.Apellido2}",
                Departamento = "Sin asignar"
            })
            .ToListAsync();

        return profesoresSinDepartamento;
    }

    public async Task<IEnumerable<object>> ProfesoresDepartamentoSinAsignatura()
    {
        var profesoresSinAsignaturas = await _context.Profesores
            .Where(p => p.IdDepartamento != null && !p.Asignaturas.Any())
            .Select(p => new
            {
                NombreProfesor = p.Persona.Nombre,
                ApellidoProfesor = p.Persona.Apellido1,
                DepartamentoAsociado = p.Departamento.Nombre
            })
            .ToListAsync();

        return profesoresSinAsignaturas;
    }

    public override async Task<IEnumerable<Persona>> GetAllAsync()
    {
        return await _context.Personas
            .ToListAsync();
    }

    public override async Task<Persona> GetByIdAsync(int id)
    {
        return await _context.Personas
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}