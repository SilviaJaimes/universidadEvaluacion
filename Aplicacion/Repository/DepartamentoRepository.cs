using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class DepartamentoRepository : GenericRepository<Departamento>, IDepartamento
{
    private readonly ApiContext _context;

    public DepartamentoRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<object>> DepartamentoProfesor()
    {
        var departamentos = await (
            from a in _context.Asignaturas
            join p in _context.Profesores on a.IdProfesor equals p.Id
            where a.Grado.Nombre == "Grado en Ingeniería Informática (Plan 2015)"
            select new
            {
                Departamento = p.Departamento.Nombre,
            })
            .Distinct()
            .ToListAsync();

        return departamentos;
    }

    public async Task<IEnumerable<object>> DepartamentoSinProfesores()
    {
        var departamentos = await (
            from d in _context.Departamentos
            where !d.Profesores.Any() 
            select new
            {
                Nombre = d.Nombre
            })
            .ToListAsync();

        return departamentos;
    }

    public async Task<IEnumerable<object>> AsignaturaQueNoSeHayaImpartido()
    {
        var departamentos = await (
            from a in _context.Asignaturas
            join p in _context.Profesores on a.IdProfesor equals p.Id
            join d in _context.Departamentos on p.IdDepartamento equals d.Id
            select new
            {
                Departamento = d.Nombre,
                AsignaturasNoImpartidas = (
                    from a in _context.Asignaturas
                    where a.IdProfesor.HasValue 
                    where !_context.Matriculas.Any(m => m.IdAsignatura == a.Id)
                    select a.Nombre
                ).ToList()
            })
            .Where(depto => depto.AsignaturasNoImpartidas.Any())
            .ToListAsync();

        return departamentos;
    }

    public async Task<IEnumerable<object>> DepartamentoYProfesor()
    {
        var resultado = await _context.Departamentos
            .Where(d => d.Profesores == d.Profesores) 
            .Select(d => new
            {
                NombreDepartamento = d.Nombre, 
                CantidadProfesores = d.Profesores.Count
            })
            .OrderByDescending(dp => dp.CantidadProfesores)
            .ToListAsync();

        return resultado;
    }

    public override async Task<IEnumerable<Departamento>> GetAllAsync()
    {
        return await _context.Departamentos
            .ToListAsync();
    }

    public override async Task<Departamento> GetByIdAsync(int id)
    {
        return await _context.Departamentos
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}