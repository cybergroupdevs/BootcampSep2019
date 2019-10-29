using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OnlineTest.Models
{
    public partial class OnlineTesContext : DbContext
    {
        public OnlineTesContext() {}
        public OnlineTesContext( DbContextOptions<OnlineTesContext> options) : base(options) { }
        public virtual DbSet<SignUp> SignUp { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=CYG359;Database=OnlineTes;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<SignUp>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ColId).HasColumnName("col_id");

                entity.Property(e => e.ColName)
                    .HasColumnName("col_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pwd)
                    .HasColumnName("pwd")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
