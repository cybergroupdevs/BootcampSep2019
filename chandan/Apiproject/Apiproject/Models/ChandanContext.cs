using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Apiproject.Models
{
    public partial class ChandanContext : DbContext
    {
        public ChandanContext()
        {

        }
        public ChandanContext(DbContextOptions<ChandanContext> options):base(options)
        {

        }
        public virtual DbSet<Brands> Brands { get; set; }
        public virtual DbSet<Orders1> Orders1 { get; set; }
        public virtual DbSet<Products1> Products1 { get; set; }
        public virtual DbSet<Taxes> Taxes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            String str = @"Server=CYG348;Database=Chandan;Trusted_Connection=true;";
            optionsBuilder.UseSqlServer(str);
            base.OnConfiguring(optionsBuilder);
           // if (!optionsBuilder.IsConfigured)
           // {
           //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
           //  optionsBuilder.UseSqlServer(@"Server=CYG348;Database=Chandan;Trusted_Connection=True;");
           // }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brands>(entity =>
            {
                entity.HasKey(e => e.Pid);

                entity.Property(e => e.Pid).ValueGeneratedNever();

                entity.Property(e => e.Bname)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Orders1>(entity =>
            {
                entity.HasKey(e => e.Pname);

                entity.Property(e => e.Pname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Products1>(entity =>
            {
                entity.HasKey(e => e.Pid);

                entity.Property(e => e.Pid).ValueGeneratedNever();

                entity.Property(e => e.Pname)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Taxes>(entity =>
            {
                entity.HasKey(e => e.Pid);

                entity.Property(e => e.Pid).ValueGeneratedNever();
            });
        }
    }
}
