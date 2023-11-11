using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class MatriculaConfiguration : IEntityTypeConfiguration<Matricula>
{
    public void Configure(EntityTypeBuilder<Matricula> builder)
    {
        builder.ToTable("matricula");
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
        .IsRequired();

        builder.HasOne(d => d.Alumno)
        .WithMany(d => d.Matriculas)
        .HasForeignKey(d => d.IdAlumno);

        builder.HasOne(d => d.Asignatura)
        .WithMany(d => d.Matriculas)
        .HasForeignKey(d => d.IdAsignatura);

        builder.HasOne(d => d.CursoEscolar)
        .WithMany(d => d.Matriculas)
        .HasForeignKey(d => d.IdCursoEscolar);
    }
}