using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CRUDApplication.Models;

public partial class CrudapplicationContext : DbContext
{
    public CrudapplicationContext()
    {
    }

    public CrudapplicationContext(DbContextOptions<CrudapplicationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Roll).HasName("pk_roll");

            entity.ToTable("Student");

            entity.Property(e => e.Roll).ValueGeneratedNever();
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
