using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IPersona : IGenericRepository<Persona>
{
    Task<IEnumerable<object>> ListadoAlumnos();
    Task<IEnumerable<object>> AlumnosSinTelefono();
    Task<IEnumerable<object>> Alumnos1999();
    Task<IEnumerable<object>> ProfesoresSinTelefono();
    Task<IEnumerable<object>> AlumnasMatricula();
    Task<IEnumerable<object>> ProfesorDepartamento();
    Task<IEnumerable<object>> AlumnosCursoEscolar();
    Task<IEnumerable<object>> ProfesoresDepartamentos();
    Task<IEnumerable<object>> ProfesoresSinAsignatura();
    Task<int> TotalAlumnas();
    Task<int> AlumnosNacidosEn1999();
    Task<IEnumerable<object>> ProfesoresPorDepartamento();
    Task<IEnumerable<object>> AsignaturaPorProfesor();
}