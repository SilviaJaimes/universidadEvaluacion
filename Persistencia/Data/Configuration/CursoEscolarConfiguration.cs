using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class CursoEscolarConfiguration : IEntityTypeConfiguration<CursoEscolar>
{
    public void Configure(EntityTypeBuilder<CursoEscolar> builder)
    {
        builder.ToTable("cursoEscolar");
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
        .IsRequired();
        
        builder.Property(p => p.AnyoInicio)
        .HasColumnName("anyoInicio")
        .HasColumnType("date")
        .IsRequired();

        builder.Property(p => p.AnyoFin)
        .HasColumnName("anyoFin")
        .HasColumnType("date")
        .IsRequired();
    }
}