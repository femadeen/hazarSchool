using System.Collections.Generic;

namespace HazarSchool.DTOs
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<StudentDTO> Students = new List<StudentDTO>();
    }
}
