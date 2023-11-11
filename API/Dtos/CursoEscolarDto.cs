using Dominio.Entities;

namespace API.Dtos;

public class CursoEscolarDto : BaseEntity
{
    public DateOnly AnyoInicio { get; set; }
    public DateOnly AnyoFin { get; set; }
}