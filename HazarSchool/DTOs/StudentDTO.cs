using HazarSchool.Enums;
using System.Collections.Generic;

namespace HazarSchool.DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public Level Level { get; set; }
        public string Email { get; set; }
        public int YearOfBirth { get; set; }
        public string DepartmentName { get; set; }

        public List<CourseDTO> Courses = new List<CourseDTO>();
    }
}
