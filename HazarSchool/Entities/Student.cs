using HazarSchool.Enums;
using System.Collections.Generic;

namespace HazarSchool.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public Level Level { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public List<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();

    }
}
