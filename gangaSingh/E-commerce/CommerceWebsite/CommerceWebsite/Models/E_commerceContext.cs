using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CommerceWebsite.Models
{
    public partial class E_commerceContext : DbContext
    {
        public E_commerceContext()
        {

        }

        public E_commerceContext(DbContextOptions<E_commerceContext> options) : base(options)
        {

        }
    
        public virtual DbSet<Brands> Brands { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //String str = @"Server=CYG356;Database=E-commerce;Trusted_Connection=True;";
            //optionsBuilder.UseSqlServer(@"Server=CYG356;Database=E-commerce;Trusted_Connection=True;");
            //base()
           // base.OnConfiguring(optionsBuilder.UseSqlServer(@"Server=CYG356;Database=E-commerce;Trusted_Connection=True;"));
            if (!optionsBuilder.IsConfigured)
            {

               {
                    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                    optionsBuilder.UseSqlServer(@"Server=CYG356;Database=E-commerce;Trusted_Connection=True;");
               }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brands>(entity =>
            {
                entity.HasKey(e => e.BrandId);

                entity.Property(e => e.BrandId)
                    .HasColumnName("Brand_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BrandName)
                    .HasColumnName("Brand_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ItemId).HasColumnName("Item_id");
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.Property(e => e.ItemId)
                    .HasColumnName("Item_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ItemName)
                    .HasColumnName("Item_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ItemPrice).HasColumnName("Item_price");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.Property(e => e.OrderId)
                    .HasColumnName("Order_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BrandId).HasColumnName("Brand_id");

                entity.Property(e => e.ItemId).HasColumnName("Item_id");
            });
        }
    }
}
