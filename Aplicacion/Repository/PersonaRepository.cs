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