using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Api_Web_Crud.Models;

public partial class CrudApiWebContext : DbContext
{
    public CrudApiWebContext()
    {
    }

    public CrudApiWebContext(DbContextOptions<CrudApiWebContext> options)
        : base(options)
    {
    }

    //crear nuestro dbset
    public DbSet<Estudiantes> EstudianteItems { get; set; }

    public virtual DbSet<Cursos> Cursos { get; set; }

    public virtual DbSet<Estudiantes> Estudiantes { get; set; }

    public virtual DbSet<Profesores> Profesores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            //        => optionsBuilder.UseSqlServer("server=localhost; database=CRUD_API_WEB; integrated security=true; Trusted_Connection=True; TrustServerCertificate=True");

        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cursos>(entity =>
        {
            entity.HasKey(e => e.IdCurso);

            entity.Property(e => e.IdCurso).HasColumnName("ID_CURSO");
            entity.Property(e => e.Capacidad).HasColumnName("CAPACIDAD");
            entity.Property(e => e.Horario)
                .HasColumnType("date")
                .HasColumnName("HORARIO");
            entity.Property(e => e.Nivel).HasColumnName("NIVEL");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Estudiantes>(entity =>
        {
            entity.HasKey(e => e.IdEstudiante);

            entity.Property(e => e.IdEstudiante).HasColumnName("ID_ESTUDIANTE");
            entity.Property(e => e.Edad).HasColumnName("EDAD");
            entity.Property(e => e.Grado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GRADO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Promedio).HasColumnName("PROMEDIO");
        });

        modelBuilder.Entity<Profesores>(entity =>
        {
            entity.HasKey(e => e.IdProfesor);

            entity.Property(e => e.IdProfesor).HasColumnName("ID_PROFESOR");
            entity.Property(e => e.AñosExperiencia).HasColumnName("AÑOS_EXPERIENCIA");
            entity.Property(e => e.Edad).HasColumnName("EDAD");
            entity.Property(e => e.Materia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MATERIA");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
