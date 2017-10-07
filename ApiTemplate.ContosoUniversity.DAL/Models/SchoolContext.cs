using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiTemplate.ContosoUniversity.DAL.Models
{
    public partial class SchoolContext : DbContext
    {
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Enrollment> Enrollment { get; set; }
        public virtual DbSet<Student> Student { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                // todo inject options bulder or connection string somehow
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ContosoUniversity1;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseId)
                    .HasColumnName("CourseID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.HasIndex(e => e.CourseId);

                entity.HasIndex(e => e.StudentId);

                entity.Property(e => e.EnrollmentId).HasColumnName("EnrollmentID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Enrollment)
                    .HasForeignKey(d => d.CourseId);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Enrollment)
                    .HasForeignKey(d => d.StudentId);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
            });
        }
    }
}
