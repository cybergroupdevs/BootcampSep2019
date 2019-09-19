using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cyecom.Models
{
    public partial class EcomContext : DbContext
    {
        public EcomContext()
        {

        }
        public EcomContext(DbContextOptions<EcomContext> options): base(options)
        {

        }
        public virtual DbSet<Brands> Brands { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Tax> Tax { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string cn = @"Server=CYG354;Database=Ecom;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(cn);
            base.OnConfiguring(optionsBuilder);
          //  if (!optionsBuilder.IsConfigured)
            //{
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
  //              optionsBuilder.UseSqlServer(@"Server=CYG354;Database=Ecom;Trusted_connection=true;");
    //        }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brands>(entity =>
            {
                entity.HasKey(e => e.Pid);

                entity.ToTable("brands");

                entity.Property(e => e.Pid)
                    .HasColumnName("pid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bid).HasColumnName("bid");

                entity.Property(e => e.Bname)
                    .HasColumnName("bname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.P)
                    .WithOne(p => p.InverseP)
                    .HasForeignKey<Brands>(d => d.Pid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__brands");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.Bid);

                entity.ToTable("orders");

                entity.Property(e => e.Bid)
                    .HasColumnName("bid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Pname)
                    .HasColumnName("pname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.pid);

                entity.ToTable("products");

                entity.Property(e => e.pid)
                    .HasColumnName("pid")
                    .ValueGeneratedNever();

                entity.Property(e => e.pname)
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
