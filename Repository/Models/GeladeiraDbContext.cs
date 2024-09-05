using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repository.Models;

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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}