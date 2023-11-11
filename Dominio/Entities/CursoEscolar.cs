namespace Dominio.Entities;

public class CursoEscolar : BaseEntity
{
    public int AnyoInicio { get; set; }
    public int AnyoFin { get; set; }

    public ICollection<Matricula> Matriculas { get; set; }
}