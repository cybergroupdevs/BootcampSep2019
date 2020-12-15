using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Flipkart.Models
{
    public partial class shopping_cartContext : DbContext
    {
        public virtual DbSet<Brands> Brands { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Products> Products { get; set; }

        public shopping_cartContext()
        {

        }
        public shopping_cartContext(DbContextOptions<shopping_cartContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string cn = @"Server=CYG238;Database=shopping_cart;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(cn);
            base.OnConfiguring(optionsBuilder);

            //            if (!optionsBuilder.IsConfigured)
            //            {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //                optionsBuilder.UseSqlServer(@"Server=CYG238;Database=shopping_cart;Trusted_Connection=True;");
            //            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brands>(entity =>
            {
                entity.HasKey(e => e.BrandId);

                entity.Property(e => e.BrandId)
                    .HasColumnName("Brand_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.BrandName)
                    .HasColumnName("Brand_Name")
                    .HasColumnType("nchar(20)");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.BrandId);

                entity.ToTable("orders");

                entity.Property(e => e.BrandId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Pname)
                    .HasColumnName("PName")
                    .HasColumnType("nchar(20)");

                entity.Property(e => e.Price).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Quantity).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.PId);

                entity.ToTable("products");

                entity.Property(e => e.PId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.BrandId)
                    .HasColumnName("BrandId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Pname)
                    .HasColumnName("PName")
                    .HasColumnType("nchar(20)");
            });
        }
    }
}
