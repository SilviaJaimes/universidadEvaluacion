using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
        builder.ToTable("persona");
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
        .IsRequired();

        builder.Property(p => p.Nit)
        .HasColumnName("nit")
        .HasColumnType("varchar")
        .HasMaxLength(9)
        .IsRequired();

        builder.HasIndex(p => p.Nit).IsUnique();

        builder.Property(p => p.Nombre)
        .HasColumnName("nombre")
        .HasColumnType("varchar")
        .HasMaxLength(25)
        .IsRequired();

        builder.Property(p => p.Apellido1)
        .HasColumnName("apellido1")
        .HasColumnType("varchar")
        .HasMaxLength(50)
        .IsRequired();

        builder.Property(p => p.Apellido2)
        .HasColumnName("apellido2")
        .HasColumnType("varchar")
        .HasMaxLength(50)
        .IsRequired();

        builder.Property(p => p.Ciudad)
        .HasColumnName("ciudad")
        .HasColumnType("varchar")
        .HasMaxLength(25)
        .IsRequired();

        builder.Property(p => p.Direccion)
        .HasColumnName("direccion")
        .HasColumnType("varchar")
        .HasMaxLength(50)
        .IsRequired();

        builder.Property(p => p.Telefono)
        .HasColumnName("telefono")
        .HasColumnType("varchar")
        .HasMaxLength(9);

        builder.Property(p => p.FechaNacimiento)
        .HasColumnName("fechaNacimiento")
        .HasColumnType("date")
        .IsRequired();

        builder.Property(p => p.Tipo)
        .HasColumnName("tipo")
        .HasColumnType("varchar")
        .HasMaxLength(10)
        .IsRequired()
        .HasConversion<string>();

        builder.Property(p => p.Sexo)
        .HasColumnName("sexo")
        .HasColumnType("varchar")
        .HasMaxLength(1)
        .IsRequired()
        .HasConversion<string>();
    }
}