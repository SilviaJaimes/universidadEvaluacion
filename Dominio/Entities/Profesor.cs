using Microsoft.AspNetCore.Identity;

namespace Dominio.Entities;

public class Profesor : BaseEntity
{
    public int IdProfesor { get; set; }
    public Persona Persona { get; set; }
    public int IdDepartamento { get; set; }
    public Departamento Departamento { get; set; }

    public ICollection<Asignatura> Asignaturas { get; set; }
}