using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class GradoConfiguration : IEntityTypeConfiguration<Grado>
{
    public void Configure(EntityTypeBuilder<Grado> builder)
    {
        builder.ToTable("grado");
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
        .IsRequired();
        
        builder.Property(p => p.Nombre)
        .HasColumnName("nombre")
        .HasColumnType("varchar")
        .HasMaxLength(100)
        .IsRequired();
    }
}