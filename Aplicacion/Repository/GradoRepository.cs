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