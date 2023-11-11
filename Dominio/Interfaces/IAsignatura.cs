using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IAsignatura : IGenericRepository<Asignatura>
{
    Task<IEnumerable<object>> Asignaturas();
    Task<IEnumerable<object>> AsignaturasOfertadas();
    Task<IEnumerable<object>> AsignaturasNit();
    Task<IEnumerable<object>> AsignaturasSinProfesores();
}