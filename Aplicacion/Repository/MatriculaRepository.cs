using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class MatriculaRepository : GenericRepository<Matricula>, IMatricula
{
    private readonly ApiContext _context;

    public MatriculaRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Matricula>> GetAllAsync()
    {
        return await _context.Matriculas
            .ToListAsync();
    }

    public override async Task<Matricula> GetByIdAsync(int id)
    {
        return await _context.Matriculas
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}