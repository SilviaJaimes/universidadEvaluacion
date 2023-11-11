using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class AsignaturaRepository : GenericRepository<Asignatura>, IAsignatura
{
    private readonly ApiContext _context;

    public AsignaturaRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<object>> Asignaturas()
    {
        var asignaturas = await (
            from a in _context.Asignaturas
            where a.Cuatrimestre == 1
            where a.Curso == 3
            where a.IdGrado == 7
            select new
            {
                Id = a.Id,
                Nombre = a.Nombre
            })
            .Distinct()
            .ToListAsync();

        return asignaturas;
    }

    public async Task<IEnumerable<object>> AsignaturasOfertadas()
    {
        var asignaturas = await (
            from a in _context.Asignaturas
            where a.Grado.Nombre == "Grado en Ingeniería Informática (Plan 2015)"
            select new
            {
                Id = a.Id,
                Nombre = a.Nombre
            })
            .Distinct()
            .ToListAsync();

        return asignaturas;
    }

    public async Task<IEnumerable<object>> AsignaturasNit()
    {
        var asignaturas = await (
            from m in _context.Matriculas
            join a in _context.Asignaturas on m.IdAsignatura equals a.Id
            where m.Alumno.Nit == "26902806M"
            select new
            {
                NombreAsignatura = a.Nombre,
                AnyoInicio = m.CursoEscolar.AnyoInicio,
                AnyoFin = m.CursoEscolar.AnyoFin,
                NitAlumno = m.Alumno.Nit
            })
            .Distinct()
            .ToListAsync();

        return asignaturas;
    }

    public async Task<IEnumerable<object>> AsignaturasSinProfesores()
    {
        var asignaturas = await (
            from a in _context.Asignaturas
            where a.IdProfesor == null
            select new
            {
                IdAsignatura = a.Id,
                Asignatura = a.Nombre
            })
            .ToListAsync();

        return asignaturas;
    }

    public async Task<IEnumerable<object>> AsignaturasSinProfesor()
    {
        var asignaturas = await (
            from a in _context.Asignaturas
            where a.IdProfesor == null
            select new
            {
                IdAsignatura = a.Id,
                Asignatura = a.Nombre
            })
            .ToListAsync();

        return asignaturas;
    }

    public override async Task<IEnumerable<Asignatura>> GetAllAsync()
    {
        return await _context.Asignaturas
            .ToListAsync();
    }

    public override async Task<Asignatura> GetByIdAsync(int id)
    {
        return await _context.Asignaturas
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}