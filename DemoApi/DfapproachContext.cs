using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DemoApi;

public partial class DfapproachContext : DbContext
{
    public DfapproachContext()
    {
    }

    public DfapproachContext(DbContextOptions<DfapproachContext> options)
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
            entity.HasKey(e => e.Sid);

            entity.Property(e => e.Sdob).HasColumnName("SDob");
            entity.Property(e => e.Semail).HasColumnName("SEmail");
            entity.Property(e => e.Sgender).HasColumnName("SGender");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
