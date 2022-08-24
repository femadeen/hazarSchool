using HazarSchool.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HazarSchool.ViewModels.RequestModels
{
    public class StudentRequestModel
    {
        public class CreateStudentRequestModel
        {
            [Required]
            public string FirstName { get; set; }
            public string LastName { get; set; }

            [Range(18, 100, ErrorMessage = "Out Of Range")]
            public int Age { get; set; }
            public string Email { get; set; }
            [DataType(DataType.Password)]
            public string Password { get; set; }
            public Gender Gender { get; set; }
            public Level Level { get; set; }

            [Display(Name = "Department")]
            public int DepartmentId { get; set; }

            [Display(Name = "Courses")]
            public List<int> CourseIds { get; set; } = new List<int>();
        }

        public class UpdateStudentRequestModel
        {
            public string Email { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string DepartmentId { get; set; }
            public Level Level { get; set; }

        }

        public class StudentLoginRequestModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}
