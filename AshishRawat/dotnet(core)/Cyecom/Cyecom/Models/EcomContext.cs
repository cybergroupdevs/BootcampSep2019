using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cyecom.Models
{
    public partial class EcomContext : DbContext
    {
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Order2> Order2 { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Tax> Tax { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=CYG354;Database=Ecom;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.Pid);

                entity.ToTable("brand");

                entity.Property(e => e.Pid)
                    .HasColumnName("pid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bid).HasColumnName("bid");

                entity.Property(e => e.Bname)
                    .HasColumnName("bname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.B)
                    .WithMany(p => p.Brand)
                    .HasForeignKey(d => d.Bid)
                    .HasConstraintName("FK_brand_Order2");
            });

            modelBuilder.Entity<Order2>(entity =>
            {
                entity.HasKey(e => e.Bid);

                entity.Property(e => e.Bid).ValueGeneratedNever();

                entity.Property(e => e.Pname)
                    .HasColumnName("pname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.Pid);

                entity.ToTable("products");

                entity.Property(e => e.Pid)
                    .HasColumnName("pid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Pname)
                    .HasColumnName("pname")
                    .HasColumnType("nchar(10)");
            });

            modelBuilder.Entity<Tax>(entity =>
            {
                entity.HasKey(e => e.Pid);

                entity.ToTable("tax");

                entity.Property(e => e.Pid)
                    .HasColumnName("pid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Gst).HasColumnName("gst");
            });
        }
    }
}
