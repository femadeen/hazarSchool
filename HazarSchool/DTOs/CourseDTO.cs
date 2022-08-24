using System.Collections.Generic;

namespace HazarSchool.DTOs
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<StudentDTO> Students = new List<StudentDTO>();
    }
}
