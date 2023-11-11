using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IGrado : IGenericRepository<Grado>
{
    Task<IEnumerable<object>> GradoYAsignatura();
    Task<IEnumerable<object>> GradoYAsignaturaMasDe40();
    /* Task<IEnumerable<object>> GradoYCredito(); */
}
