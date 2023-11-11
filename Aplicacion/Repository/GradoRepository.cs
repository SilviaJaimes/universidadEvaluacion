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

    /* public async Task<IEnumerable<object>> GradoYCredito()
    {
        var resultado = await _context.Grados
            .Where(grado => grado.Asignaturas.Any())
            .Select(grado => new
            {
                NombreGrado = grado.Nombre,
                CreditosPorTipoDeAsignatura = _context.Asignaturas
                    .Where(asignatura => asignatura.IdGrado == grado.Id)
                    .GroupBy(asignatura => asignatura.Tipo)
                    .Select(grupo => new
                    {
                        TipoAsignatura = ObtenerNombreTipoAsignatura(grupo.Key),
                        SumaCreditos = grupo.Sum(asignatura => asignatura.Creditos)
                    })
                    .OrderByDescending(grupo => grupo.SumaCreditos)
                    .ToList()
            })
            .ToListAsync();

        return resultado;
    }

    private static string ObtenerNombreTipoAsignatura(Asignatura.Tipos tipo)
    {
        return tipo switch
        {
            Asignatura.Tipos.Basica => "Basica",
            Asignatura.Tipos.Obligatoria => "Obligatoria",
            Asignatura.Tipos.Optativa => "Optativa",
            _ => tipo.ToString()  // Manejar casos adicionales según sea necesario
        };
    } */

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