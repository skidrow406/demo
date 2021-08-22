using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DemoOracleEntityFrameworkCore.Models;

namespace DemoOracleEntityFrameworkCore.EntityConfigurations
{
    public class CourseEntityTypeConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> entity)
        {
            entity.ToTable("course_test");

            entity.HasKey(e => e.CourceId)
            .HasName("course_test_pk_course_id");

            entity.Property(e => e.CourceId)
            .HasColumnName("course_id");

            entity.Property(e => e.CourseName)
            .HasColumnName("course_name")
            .HasMaxLength(50)
            .IsRequired();
        }
    }
}