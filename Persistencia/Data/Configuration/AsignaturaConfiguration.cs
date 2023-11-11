using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class AsignaturaConfiguration : IEntityTypeConfiguration<Asignatura>
{
    public void Configure(EntityTypeBuilder<Asignatura> builder)
    {
        builder.ToTable("asignatura");
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
        .IsRequired();
        
        builder.Property(p => p.Nombre)
        .HasColumnName("nombre")
        .HasColumnType("varchar")
        .HasMaxLength(100)
        .IsRequired();

        builder.Property(p => p.Creditos)
        .HasColumnName("creditos")
        .HasColumnType("float")
        .HasMaxLength(100)
        .IsRequired();

        builder.Property(p => p.Tipo)
        .HasColumnName("tipo")
        .HasColumnType("varchar")
        .HasMaxLength(100)
        .IsRequired()
        .HasConversion<string>();

        builder.Property(p => p.Curso)
        .HasColumnName("curso")
        .HasColumnType("int")
        .HasMaxLength(3)
        .IsRequired();

        builder.Property(p => p.Cuatrimestre)
        .HasColumnName("cuatrimestre")
        .HasColumnType("int")
        .HasMaxLength(3)
        .IsRequired();

        builder.HasOne(d => d.Profesor)
        .WithMany(d => d.Asignaturas)
        .HasForeignKey(d => d.IdProfesor)
        .IsRequired(false);

        builder.HasOne(d => d.Grado)
        .WithMany(d => d.Asignaturas)
        .HasForeignKey(d => d.IdGrado);
    }
}