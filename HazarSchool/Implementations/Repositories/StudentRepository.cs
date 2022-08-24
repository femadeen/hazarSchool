using HazarSchool.Entities;
using HazarSchool.Enums;
using HazarSchool.HazarSchoolContext;
using HazarSchool.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HazarSchool.Implementations.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly HazarContext _context;

        public StudentRepository(HazarContext context)
        {
            _context = context;

        }

        public Student AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }

        public bool AddStudentCourses(List<StudentCourse> studentCourses)
        {
            _context.StudentCourses.AddRange(studentCourses);
            _context.SaveChanges();
            return true;
        }

        public void DeleteStudent(int id)
        {
            var student = FindStudentById(id);
            _context.Students.Remove(student);
            _context.SaveChanges();
        }

        public bool Exists(string firstName, string lastName)
        {
            var isExisting = _context.Students.Any(student => student.FirstName.ToLower() == firstName.ToLower() && student.LastName.ToLower() == lastName.ToLower());
            return isExisting;
        }

        public Student FindStudentByEmail(string email)
        {
            var student = _context.Students.FirstOrDefault(student => student.Email.ToLower() == email.ToLower());
            return student;
        }

        public Student FindStudentById(int id)
        {
            var student = _context.Students
               .Include(d => d.Department)
                .Include(s => s.StudentCourses)
                .ThenInclude(c => c.Course)
                .SingleOrDefault(x => x.Id == id);
            return student;
        }

        public List<Student> GetAllStudents()
        {
            var students = _context.Students
                .Include(d => d.Department)
                .Include(s => s.StudentCourses)
                .ThenInclude(x => x.Course)
                .ToList();
            return students;
        }

        public List<Student> GetFemaleStudents()
        {
            var femaleStudents = _context.Students
                 .Include(x => x.Department)
                 .Include(x => x.StudentCourses)
                 .ThenInclude(x => x.Course)
                 .Where(x => x.Gender == Gender.Female)
                 .ToList();
            return femaleStudents;

        }

        public List<Student> GetMaleStudents()
        {
            var maleStudents = _context.Students
                .Include(x => x.Department)
                .Include(x => x.StudentCourses)
                .ThenInclude(x => x.Course)
                .Where(x => x.Gender == Gender.Male)
                .ToList();
            return maleStudents;
        }

        public List<Student> GetStudentsByCourse(int courseId)
        {
            var students = _context.StudentCourses
                .Include(x => x.Student).ThenInclude(x => x.Department)
                .Where(x => x.CourseId == courseId).Select(x => x.Student)
                .ToList();
            /* var studentsOfferingCourse = _context.Students.Where(x => x.StudentCourses.Any(x => x.CourseId == courseId)).ToList();*/
            return students;

        }

        public List<Student> GetStudentsByDepartment(int departmentId)
        {
            var students = _context.Students
                .Include(x => x.Department)
                .Include(x => x.StudentCourses)
                .ThenInclude(x => x.Course)
                .Where(x => x.DepartmentId == departmentId).ToList();
            return students;
        }

        public List<Student> GetStudentsByLevel(Level Level)
        {
            var students = _context.Students.Where(x => x.Level == Level).ToList();
            return students;
        }

        public Student UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
            return student;
        }

    }

}
