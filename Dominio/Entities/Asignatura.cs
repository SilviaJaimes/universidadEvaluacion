namespace Dominio.Entities;

public class Asignatura : BaseEntity
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
    public Profesor Profesor { get; set; }
    public int IdGrado { get; set; }
    public Grado Grado { get; set; }

    public ICollection<Matricula> Matriculas { get; set; }
}