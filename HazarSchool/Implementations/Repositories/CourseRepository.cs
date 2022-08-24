using HazarSchool.Entities;
using HazarSchool.HazarSchoolContext;
using HazarSchool.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace HazarSchool.Implementations.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly HazarContext _context;

        public CourseRepository(HazarContext context)
        {
            _context = context;
        }

        public Course AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
            return course;
        }

        public void DeleteCourse(int id)
        {
            var course = FindCourseById(id);
            _context.Courses.Remove(course);
            _context.SaveChanges();

        }

        public bool Exist(string courseName)
        {
            var course = _context.Courses.Any(x => x.Name.ToLower() == courseName.ToLower());
            return course;
        }

        public Course FindCourseById(int id)
        {
            var course = _context.Courses
                /*.Include(x => x.StudentCourses)
                .ThenInclude(b => b.Student)
                .ThenInclude(d => d.Department)*/
                .SingleOrDefault(x => x.Id == id);
            return course;
        }


        public List<Course> GetAllCourses()
        {
            var courses = _context.Courses
                /*  .Include(j => j.StudentCourses)
                  .ThenInclude(s => s.Student)*/
                .ToList();
            return courses;
        }

        public List<Course> GetCoursesByStudent(int studentId)
        {
            var courses = _context.Courses.Where(x => x.StudentCourses.Any(x => x.StudentId == studentId)).ToList();
            return courses;
        }

        public List<Course> GetSelectedCourses(List<int> courseIds)
        {
            var couses = _context.Courses.Where(x => courseIds.Contains(x.Id)).ToList();
            return couses;
        }

        public Course UpdateCourse(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
            return course;
        }
    }
}
