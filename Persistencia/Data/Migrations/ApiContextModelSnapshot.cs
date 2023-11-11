﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistencia;

#nullable disable

namespace Persistencia.Data.Migrations
{
    [DbContext(typeof(ApiContext))]
    partial class ApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Dominio.Entities.Asignatura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("Creditos")
                        .HasMaxLength(100)
                        .HasColumnType("float")
                        .HasColumnName("creditos");

                    b.Property<int>("Cuatrimestre")
                        .HasMaxLength(3)
                        .HasColumnType("int")
                        .HasColumnName("cuatrimestre");

                    b.Property<int>("Curso")
                        .HasMaxLength(3)
                        .HasColumnType("int")
                        .HasColumnName("curso");

                    b.Property<int>("IdGrado")
                        .HasColumnType("int");

                    b.Property<int?>("IdProfesor")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("nombre");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("tipo");

                    b.HasKey("Id");

                    b.HasIndex("IdGrado");

                    b.HasIndex("IdProfesor");

                    b.ToTable("asignatura", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.CursoEscolar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AnyoFin")
                        .HasMaxLength(4)
                        .HasColumnType("int")
                        .HasColumnName("anyoFin");

                    b.Property<int>("AnyoInicio")
                        .HasMaxLength(4)
                        .HasColumnType("int")
                        .HasColumnName("anyoInicio");

                    b.HasKey("Id");

                    b.ToTable("cursoEscolar", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("departamento", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Grado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("grado", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Matricula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdAlumno")
                        .HasColumnType("int");

                    b.Property<int>("IdAsignatura")
                        .HasColumnType("int");

                    b.Property<int>("IdCursoEscolar")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdAlumno");

                    b.HasIndex("IdAsignatura");

                    b.HasIndex("IdCursoEscolar");

                    b.ToTable("matricula", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellido1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("apellido1");

                    b.Property<string>("Apellido2")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("apellido2");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar")
                        .HasColumnName("ciudad");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("direccion");

                    b.Property<DateOnly>("FechaNacimiento")
                        .HasColumnType("date")
                        .HasColumnName("fechaNacimiento");

                    b.Property<string>("Nit")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("varchar")
                        .HasColumnName("nit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar")
                        .HasColumnName("nombre");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("varchar")
                        .HasColumnName("sexo");

                    b.Property<string>("Telefono")
                        .HasMaxLength(9)
                        .HasColumnType("varchar")
                        .HasColumnName("telefono");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar")
                        .HasColumnName("tipo");

                    b.HasKey("Id");

                    b.HasIndex("Nit")
                        .IsUnique();

                    b.ToTable("persona", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Profesor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdDepartamento")
                        .HasColumnType("int");

                    b.Property<int>("IdProfesor")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdDepartamento");

                    b.HasIndex("IdProfesor");

                    b.ToTable("profesor", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("Revoked")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Token")
                        .HasColumnType("longtext");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("RefreshToken", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("rolName");

                    b.HasKey("Id");

                    b.ToTable("rol", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.RolUsuario", b =>
                {
                    b.Property<int>("IdUsuarioFk")
                        .HasColumnType("int");

                    b.Property<int>("IdRolFk")
                        .HasColumnType("int");

                    b.HasKey("IdUsuarioFk", "IdRolFk");

                    b.HasIndex("IdRolFk");

                    b.ToTable("rolUsuario", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("contraseña");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("correoElectronico");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("usuario", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Asignatura", b =>
                {
                    b.HasOne("Dominio.Entities.Grado", "Grado")
                        .WithMany("Asignaturas")
                        .HasForeignKey("IdGrado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.Profesor", "Profesor")
                        .WithMany("Asignaturas")
                        .HasForeignKey("IdProfesor");

                    b.Navigation("Grado");

                    b.Navigation("Profesor");
                });

            modelBuilder.Entity("Dominio.Entities.Matricula", b =>
                {
                    b.HasOne("Dominio.Entities.Persona", "Alumno")
                        .WithMany("Matriculas")
                        .HasForeignKey("IdAlumno")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.Asignatura", "Asignatura")
                        .WithMany("Matriculas")
                        .HasForeignKey("IdAsignatura")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.CursoEscolar", "CursoEscolar")
                        .WithMany("Matriculas")
                        .HasForeignKey("IdCursoEscolar")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alumno");

                    b.Navigation("Asignatura");

                    b.Navigation("CursoEscolar");
                });

            modelBuilder.Entity("Dominio.Entities.Profesor", b =>
                {
                    b.HasOne("Dominio.Entities.Departamento", "Departamento")
                        .WithMany("Profesores")
                        .HasForeignKey("IdDepartamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.Persona", "Persona")
                        .WithMany("Profesores")
                        .HasForeignKey("IdProfesor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("Dominio.Entities.RefreshToken", b =>
                {
                    b.HasOne("Dominio.Entities.Usuario", "Usuario")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Dominio.Entities.RolUsuario", b =>
                {
                    b.HasOne("Dominio.Entities.Rol", "Rol")
                        .WithMany("RolUsuarios")
                        .HasForeignKey("IdRolFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.Usuario", "Usuario")
                        .WithMany("RolUsuarios")
                        .HasForeignKey("IdUsuarioFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Dominio.Entities.Asignatura", b =>
                {
                    b.Navigation("Matriculas");
                });

            modelBuilder.Entity("Dominio.Entities.CursoEscolar", b =>
                {
                    b.Navigation("Matriculas");
                });

            modelBuilder.Entity("Dominio.Entities.Departamento", b =>
                {
                    b.Navigation("Profesores");
                });

            modelBuilder.Entity("Dominio.Entities.Grado", b =>
                {
                    b.Navigation("Asignaturas");
                });

            modelBuilder.Entity("Dominio.Entities.Persona", b =>
                {
                    b.Navigation("Matriculas");

                    b.Navigation("Profesores");
                });

            modelBuilder.Entity("Dominio.Entities.Profesor", b =>
                {
                    b.Navigation("Asignaturas");
                });

            modelBuilder.Entity("Dominio.Entities.Rol", b =>
                {
                    b.Navigation("RolUsuarios");
                });

            modelBuilder.Entity("Dominio.Entities.Usuario", b =>
                {
                    b.Navigation("RefreshTokens");

                    b.Navigation("RolUsuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
