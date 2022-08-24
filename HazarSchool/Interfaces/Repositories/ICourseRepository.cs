using HazarSchool.Entities;
using System.Collections.Generic;

namespace HazarSchool.Interfaces.Repositories
{
    public interface ICourseRepository
    {
        public Course AddCourse(Course course);
        public Course FindCourseById(int id);
        public void DeleteCourse(int id);
        public Course UpdateCourse(Course course);
        public List<Course> GetAllCourses();
        public List<Course> GetCoursesByStudent(int studentId);
        public List<Course> GetSelectedCourses(List<int> courseIds);
        public bool Exist(string courseName);
    }
}
