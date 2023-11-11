using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class CursoEscolarRepository : GenericRepository<CursoEscolar>, ICursoEscolar
{
    private readonly ApiContext _context;

    public CursoEscolarRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<CursoEscolar>> GetAllAsync()
    {
        return await _context.CursoEscolares
            .ToListAsync();
    }

    public override async Task<CursoEscolar> GetByIdAsync(int id)
    {
        return await _context.CursoEscolares
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}