namespace Dominio.Interfaces;

public interface IUnitOfWork
{
        IRol Roles { get; }
        IUsuario Usuarios { get; }
        IAsignatura Asignaturas { get; }
        ICursoEscolar CursoEscolares { get; }
        IDepartamento Departamentos { get; }
        IGrado Grados { get; }
        IMatricula Matriculas { get; }
        IPersona Personas { get; }
        IProfesor Profesores { get; }
        Task<int> SaveAsync();
}