namespace Dominio.Entities;

public class Matricula : BaseEntity
{
    public int IdAlumno { get; set; }
    public Persona Alumno { get; set; }
    public int IdCursoEscolar { get; set; }
    public CursoEscolar CursoEscolar { get; set; }
    public int IdAsignatura { get; set; }
    public Asignatura Asignatura { get; set; }
}