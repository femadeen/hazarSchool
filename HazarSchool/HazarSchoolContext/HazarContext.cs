using HazarSchool.Entities;
using Microsoft.EntityFrameworkCore;

namespace HazarSchool.HazarSchoolContext
{
    public class HazarContext : DbContext
    {
        public HazarContext(DbContextOptions<HazarContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
    }

}

