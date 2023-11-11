using Dominio.Entities;

namespace API.Dtos;

public class MatriculaDto : BaseEntity
{
    public int IdAlumno { get; set; }
    public PersonaDto Alumno { get; set; }
    public int IdAsignatura { get; set; }
    public AsignaturaDto Asignatura { get; set; }
    public int IdCursoEscolar { get; set; }
    public CursoEscolarDto CursoEscolar { get; set; }
}