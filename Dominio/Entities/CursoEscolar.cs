namespace Dominio.Entities;

public class CursoEscolar : BaseEntity
{
    public DateOnly AnyoInicio { get; set; }
    public DateOnly AnyoFin { get; set; }

    public ICollection<Matricula> Matriculas { get; set; }
}