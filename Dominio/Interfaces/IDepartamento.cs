using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IDepartamento : IGenericRepository<Departamento>
{
    Task<IEnumerable<object>> DepartamentoProfesor();
    Task<IEnumerable<object>> DepartamentoSinProfesores();
    Task<IEnumerable<object>> AsignaturaQueNoSeHayaImpartido();
    Task<IEnumerable<object>> DepartamentoYProfesor();
    Task<IEnumerable<object>> DepartamentoSinProfesorAsociado();
    Task<IEnumerable<object>> DepartamentosSinAsignaturas();
}