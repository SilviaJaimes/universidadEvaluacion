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