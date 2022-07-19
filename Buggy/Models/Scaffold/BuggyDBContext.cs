using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Buggy.Models.Scaffold
{
    public partial class BuggyDBContext : DbContext
    {
        public BuggyDBContext()
        {
        }

        public BuggyDBContext(DbContextOptions<BuggyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AnotherTable> AnotherTables { get; set; } = null!;
        public virtual DbSet<Table> Tables { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnotherTable>(entity =>
            {
                entity.ToTable("AnotherTable");

                entity.Property(e => e.Aname)
                    .HasMaxLength(260)
                    .HasColumnName("AName");
            });

            modelBuilder.Entity<Table>(entity =>
            {
                entity.ToTable("Table");

                entity.HasOne(d => d.AnotherTable)
                    .WithMany(p => p.Tables)
                    .HasForeignKey(d => d.AnotherTableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Table_AnotherTable");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
