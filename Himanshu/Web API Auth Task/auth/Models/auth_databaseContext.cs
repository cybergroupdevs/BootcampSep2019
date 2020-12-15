using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace auth.Models
{
    public partial class auth_databaseContext : DbContext
    {
        public virtual DbSet<UserDetails> UserDetails { get; set; }
        public virtual DbSet<UserPassword> UserPassword { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string cn = @"Server=CYG238;Database=auth_database;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(cn);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDetails>(entity =>
            {
                entity.HasKey(e => e.Email);

                entity.ToTable("user_details");

                entity.Property(e => e.Email)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CollegeId)
                    .HasColumnName("CollegeID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CollegeName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.UserDetails)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("FK__user_deta__Usern__4CA06362");
            });

            modelBuilder.Entity<UserPassword>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.ToTable("user_password");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
