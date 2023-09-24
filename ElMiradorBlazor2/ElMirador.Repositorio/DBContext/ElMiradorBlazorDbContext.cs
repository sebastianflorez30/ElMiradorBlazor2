using System;
using System.Collections.Generic;
using ElMirador.Modelo;
using Microsoft.EntityFrameworkCore;

namespace ElMirador.Repositorio.DBContext;

public partial class ElMiradorBlazorDbContext : DbContext
{
    public ElMiradorBlazorDbContext()
    {
    }

    public ElMiradorBlazorDbContext(DbContextOptions<ElMiradorBlazorDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Acta> Actas { get; set; }

    public virtual DbSet<Asamblea> Asambleas { get; set; }

    public virtual DbSet<Rol> Roles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Votacion> Votaciones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Acta>(entity =>
        {
            entity.HasKey(e => e.IdActa).HasName("PK__Actas__53616019F50AAC1A");

            entity.Property(e => e.IdActa).HasColumnName("Id_Acta");
            entity.Property(e => e.FechaAsamblea).HasColumnType("datetime");
            entity.Property(e => e.Texto)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Asamblea>(entity =>
        {
            entity.HasKey(e => e.IdAsamblea).HasName("PK__Asamblea__0A00CD2A624B2853");

            entity.Property(e => e.IdAsamblea).HasColumnName("Id_Asamblea");
            entity.Property(e => e.Agenda)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.IdActa).HasColumnName("Id_Acta");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");
            entity.Property(e => e.Lugar)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdActaNavigation).WithMany(p => p.Asambleas)
                .HasForeignKey(d => d.IdActa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Asambleas__Id_Ac__5535A963");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Asambleas)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Asambleas__Id_Us__5629CD9C");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Roles__55932E86493730AD");

            entity.Property(e => e.IdRol).HasColumnName("Id_Rol");
            entity.Property(e => e.Administrador)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Propietario)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__63C76BE2B81C9523");

            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IdRol).HasColumnName("Id_Rol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuarios__Id_Rol__38996AB5");
        });

        modelBuilder.Entity<Votacion>(entity =>
        {
            entity.HasKey(e => e.IdVotacion).HasName("PK__Votacion__60FDC2480F2F16FC");

            entity.Property(e => e.IdVotacion).HasColumnName("Id_Votacion");
            entity.Property(e => e.IdAsamblea).HasColumnName("Id_Asamblea");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");
            entity.Property(e => e.Preguntas)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Resultados)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.IdAsambleaNavigation).WithMany(p => p.Votaciones)
                .HasForeignKey(d => d.IdAsamblea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Votacione__Id_As__59FA5E80");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Votaciones)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Votacione__Id_Us__59063A47");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
