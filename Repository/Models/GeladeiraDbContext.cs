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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=GeladeiraDB;Uid=sa;Pwd=123;Trusted_Connection=True;TrustServerCertificate=True;");

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
