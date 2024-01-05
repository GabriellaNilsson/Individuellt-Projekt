using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Individuellt_Projekt.Models;

public partial class SchoolSystemContext : DbContext
{
    public SchoolSystemContext()
    {
    }

    public SchoolSystemContext(DbContextOptions<SchoolSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog=SchoolSystemDb;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK_Grades");

            entity.ToTable("Class");

            entity.Property(e => e.ClassId)
                .ValueGeneratedNever()
                .HasColumnName("ClassID");
            entity.Property(e => e.ClassName).HasMaxLength(10);
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.Property(e => e.CourseId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("CourseID");
            entity.Property(e => e.Classroom)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.CourseName).HasMaxLength(50);
            entity.Property(e => e.FkemployeeId).HasColumnName("FKEmployeeID");

            entity.HasOne(d => d.Fkemployee).WithMany(p => p.Courses)
                .HasForeignKey(d => d.FkemployeeId)
                .HasConstraintName("FK_Courses_Employees");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeesId);

            entity.Property(e => e.EmployeesId)
                .ValueGeneratedNever()
                .HasColumnName("EmployeesID");
            entity.Property(e => e.FirstName).HasMaxLength(30);
            entity.Property(e => e.FkroleId).HasColumnName("FKRoleID");
            entity.Property(e => e.Fksalary).HasColumnName("FKSalary");
            entity.Property(e => e.LastName).HasMaxLength(30);
            entity.Property(e => e.PersonalNumber)
                .HasMaxLength(12)
                .IsFixedLength();
            entity.Property(e => e.StartOfEmployment)
                .HasMaxLength(4)
                .IsFixedLength();
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CourseId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("CourseID");
            entity.Property(e => e.DateOfGrade).HasColumnType("datetime");
            entity.Property(e => e.FkteacherId).HasColumnName("FKTeacherID");
            entity.Property(e => e.StudentId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("StudentID");

            entity.HasOne(d => d.Course).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_Enrollments_Courses");

            entity.HasOne(d => d.Fkteacher).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.FkteacherId)
                .HasConstraintName("FK_Enrollments_Employees");

            entity.HasOne(d => d.Student).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_Enrollments_Students");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("RoleID");
            entity.Property(e => e.Role1)
                .HasMaxLength(50)
                .HasColumnName("Role");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(e => e.StudentId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("StudentID");
            entity.Property(e => e.FirstName).HasMaxLength(30);
            entity.Property(e => e.FkclassId).HasColumnName("FKClassID");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.HealthInfo).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(30);
            entity.Property(e => e.PersonalNumber)
                .HasMaxLength(12)
                .IsFixedLength();

            entity.HasOne(d => d.Fkclass).WithMany(p => p.Students)
                .HasForeignKey(d => d.FkclassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Students_Class");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
