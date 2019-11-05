using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication5.Models
{
    public partial class Test_platformContext : DbContext
    {
        public Test_platformContext()
        {

        }
        public Test_platformContext(DbContextOptions<Test_platformContext> options) : base(options)
        {

        }
        public virtual DbSet<SignUp> SignUp { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //            if (!optionsBuilder.IsConfigured)
            //            {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //                optionsBuilder.UseSqlServer(@"Server=CYG362;Database=Test_platform;Trusted_Connection=True;");
            //            }
            optionsBuilder.UseSqlServer(@"Server=CYG362;Database=Test_platform;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SignUp>(entity =>
            {
                entity.HasKey(e => e.Email);

                entity.ToTable("signUp");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CollegeId)
                    .IsRequired()
                    .HasColumnName("College_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CollegeName)
                    .IsRequired()
                    .HasColumnName("College_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ConfirmPassword)
                    .IsRequired()
                    .HasColumnName("Confirm_Password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
