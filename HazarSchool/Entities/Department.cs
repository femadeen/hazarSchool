using System.Collections.Generic;

namespace HazarSchool.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Student> Students = new List<Student>();

    }
}
