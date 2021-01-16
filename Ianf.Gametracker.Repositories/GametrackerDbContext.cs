using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Ianf.Gametracker.Repositories.Entities;

#nullable disable

namespace Ianf.Gametracker.Repositories
{
    public partial class GametrackerDbContext : DbContext
    {
        public GametrackerDbContext()
        {
        }

        public GametrackerDbContext(DbContextOptions<GametrackerDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TestData> TestDatas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=192.168.1.73; Database=Gametracker; User Id=SA; Password=31Freeble$");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TestData>(entity =>
            {
                entity.ToTable("TestData");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
