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
        var resultado = await _context.Grados
            .SelectMany(g => g.Asignaturas, (g, a) => new
            {
                NombreGrado = g.Nombre,
                TipoAsignatura = a.Tipo,
                Creditos = a.Creditos
            })
            .GroupBy(x => new { x.NombreGrado, x.TipoAsignatura })
            .Select(g => new
            {
                NombreGrado = g.Key.NombreGrado,
                TipoAsignatura = g.Key.TipoAsignatura,
                SumaCreditos = g.Sum(x => x.Creditos)
            })
            .OrderByDescending(x => x.SumaCreditos)
            .ToListAsync();

        return resultado;
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