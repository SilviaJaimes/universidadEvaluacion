using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IPersona : IGenericRepository<Persona>
{
    Task<IEnumerable<object>> ListadoAlumnos();
    Task<IEnumerable<object>> AlumnosSinTelefono();
    Task<IEnumerable<object>> Alumnos1999();
}