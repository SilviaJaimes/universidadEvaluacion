using Dominio.Entities;

namespace API.Dtos;

public class ProfesorDto : BaseEntity
{
    public int IdProfesor { get; set; }
    public PersonaDto Persona { get; set; }
    public int IdDepartamento { get; set; }
    public DepartamentoDto Departamento { get; set; }
}