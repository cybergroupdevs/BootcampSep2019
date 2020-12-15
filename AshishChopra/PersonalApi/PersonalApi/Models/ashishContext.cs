using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PersonalApi.Models
{
    public partial class ashishContext : DbContext
    {
        public ashishContext()
        {

        }
        public ashishContext(DbContextOptions<ashishContext> options)
           : base(options) { }
        
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          // String str = @"Server=CYG362;Database=ashish;Trusted_Connection=true;";
          // optionsBuilder.UseSqlServer(str);
           // base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=CYG362;Database=ashish;Trusted_Connection=True;");
            }
       }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.Bid);

                entity.Property(e => e.Bid).ValueGeneratedNever();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Bid);

                entity.Property(e => e.Bid).ValueGeneratedNever();

                entity.Property(e => e.Pname)
                    .IsRequired()
                    .HasColumnType("nchar(10)");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Pid);

                entity.Property(e => e.Pid).ValueGeneratedNever();

                entity.Property(e => e.Pname)
                    .IsRequired()
                    .HasColumnType("nchar(10)");
            });
        }
    }
}
