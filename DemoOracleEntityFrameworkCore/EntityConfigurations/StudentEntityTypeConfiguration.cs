using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DemoOracleEntityFrameworkCore.Models;

namespace DemoOracleEntityFrameworkCore.EntityConfigurations
{
    public class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> entity)
        {
            entity.ToTable("student_test");

            entity.HasKey(e => e.StudentId)
            .HasName("student_test_pk_student_id");

            entity.HasIndex(e => e.StudentEmail)
            .HasDatabaseName("student_test_uq_student_email")
            .IsUnique();

            entity.Property(e => e.StudentId)
            .HasColumnName("student_id");

            entity.Property(e => e.CourseId)
            .HasColumnName("course_id");

            entity.Property(e => e.StudentFirstName)
            .HasColumnName("student_first_name")
            .HasMaxLength(50)
            .IsRequired();

            entity.Property(e => e.StudentLastName)
            .HasColumnName("student_last_name")
            .HasMaxLength(50)
            .IsRequired();

            entity.Property(e => e.StudentEmail)
            .HasColumnName("student_email")
            .HasMaxLength(50)
            .IsUnicode(false)
            .IsRequired();

            entity.Property(e => e.StudentGender)
            .HasColumnName("student_gender")
            .HasColumnType("CHAR(1)")
            .HasDefaultValueSql("('0')")
            .HasConversion(gender => gender.Value ? "1" : "0", gender => gender == "1" ? true : false);

            entity.Property(e => e.StudentBirthday)
            .HasColumnName("student_birthday")
            .HasColumnType("DATE");

            entity.HasOne(e => e.Course)
            .WithMany(e => e.Students)
            .HasForeignKey(e => e.CourseId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("student_test_fk_course_id");
        }
    }
}