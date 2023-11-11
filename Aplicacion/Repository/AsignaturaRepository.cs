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