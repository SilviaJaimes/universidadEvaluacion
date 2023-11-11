using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class ProfesorRepository : GenericRepository<Profesor>, IProfesor
{
    private readonly ApiContext _context;

    public ProfesorRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Profesor>> GetAllAsync()
    {
        return await _context.Profesores
            .ToListAsync();
    }

    public override async Task<Profesor> GetByIdAsync(int id)
    {
        return await _context.Profesores
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}