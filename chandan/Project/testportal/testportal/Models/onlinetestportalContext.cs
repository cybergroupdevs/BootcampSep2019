using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace testportal.Models
{
    public partial class onlinetestportalContext : DbContext
    {
        public onlinetestportalContext()
        {

        }
        public onlinetestportalContext(DbContextOptions<onlinetestportalContext> options) : base(options)
        {

        }
        public virtual DbSet<Table1> Table1 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            String str = @"Server=CYG348;Database=onlinetestportal;Trusted_Connection=true;";
            optionsBuilder.UseSqlServer(str);
            base.OnConfiguring(optionsBuilder);
            //if (!optionsBuilder.IsConfigured)
            // {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
           // optionsBuilder.UseSqlServer(@"Server=CYG348;Database=onlinetestportal;Trusted_Connection=True;");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table1>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.ToTable("Table_1");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Collegeid).HasColumnName("collegeid");

                entity.Property(e => e.Collegename)
                    .HasColumnName("collegename")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
