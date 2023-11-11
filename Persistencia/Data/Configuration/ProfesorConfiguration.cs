using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class ProfesorConfiguration : IEntityTypeConfiguration<Profesor>
{
    public void Configure(EntityTypeBuilder<Profesor> builder)
    {
        builder.ToTable("profesor");
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
        .IsRequired();

        builder.HasOne(d => d.Persona)
        .WithMany(d => d.Profesores)
        .HasForeignKey(d => d.IdProfesor);

        builder.HasOne(d => d.Departamento)
        .WithMany(d => d.Profesores)
        .HasForeignKey(d => d.IdDepartamento);
    }
}