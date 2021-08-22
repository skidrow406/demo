using Microsoft.EntityFrameworkCore;
using DemoOracleEntityFrameworkCore.EntityConfigurations;
using DemoOracleEntityFrameworkCore.Models;

namespace DemoOracleEntityFrameworkCore.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StudentEntityTypeConfiguration());
        }
    }
}