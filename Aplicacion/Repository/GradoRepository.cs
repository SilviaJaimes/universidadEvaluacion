using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class GradoRepository : GenericRepository<Grado>, IGrado
{
    private readonly ApiContext _context;

    public GradoRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<object>> GradoYAsignatura()
    {
        var resultado = await _context.Grados
            .Where(d => d.Asignaturas == d.Asignaturas) 
            .Select(d => new
            {
                NombreGrado = d.Nombre, 
                CantidadAsignaturas = d.Asignaturas.Count
            })
            .OrderByDescending(dp => dp.CantidadAsignaturas)
            .ToListAsync();

        return resultado;
    }

    public async Task<IEnumerable<object>> GradoYAsignaturaMasDe40()
    {
        var resultado = await _context.Grados
            .Where(d => d.Asignaturas.Count >= 40) 
            .Select(d => new
            {
                NombreGrado = d.Nombre, 
                CantidadAsignaturas = d.Asignaturas.Count
            })
            .OrderByDescending(dp => dp.CantidadAsignaturas)
            .ToListAsync();

        return resultado;
    }

    public async Task<IEnumerable<object>> CreditosPorTipoDeAsignatura()
    {
        return await (
            from a in _context.Asignaturas
            join g in _context.Grados on a.IdGrado equals g.Id
            group a by new { g.Nombre, a.Tipo } into grupo
            select new
            {
                NombreGrado = grupo.Key.Nombre,
                TipoAsignatura = grupo.Key.Tipo.ToString(),
                SumaCreditos = grupo.Sum(x => x.Creditos)
            }
        )
        .ToListAsync();
    }

    public override async Task<IEnumerable<Grado>> GetAllAsync()
    {
        return await _context.Grados
            .ToListAsync();
    }

    public override async Task<Grado> GetByIdAsync(int id)
    {
        return await _context.Grados
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}