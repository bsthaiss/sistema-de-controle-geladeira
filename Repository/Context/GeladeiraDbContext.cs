using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.Context;

public partial class GeladeiraDbContext : DbContext
{
    public GeladeiraDbContext()
    {
    }

    public GeladeiraDbContext(DbContextOptions<GeladeiraDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ItensGeladeira> ItensGeladeiras { get; set; }
    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItensGeladeira>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ItensGel__3214EC07A3F8B699");

            entity.ToTable("ItensGeladeira");

            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_User");

            entity.ToTable("Usuario");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.SenhaHash)
                .HasMaxLength(300)
                .IsUnicode(false);

            entity.Property(e => e.SenhaSalt)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}