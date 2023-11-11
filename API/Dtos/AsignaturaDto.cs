using Dominio.Entities;

namespace API.Dtos;

public class AsignaturaDto : BaseEntity
{
    public enum Tipos {
        Basica,
        Obligatoria,
        Optativa
    } 

    public string Nombre { get; set; }
    public float Creditos { get; set; }
    public Tipos Tipo { get; set; }
    public int Curso { get; set; }
    public int Cuatrimestre { get; set; }
    public int IdProfesor { get; set; }
    public ProfesorDto Profesor { get; set; }
    public int IdGrado { get; set; }
    public GradoDto Grado { get; set; }
}