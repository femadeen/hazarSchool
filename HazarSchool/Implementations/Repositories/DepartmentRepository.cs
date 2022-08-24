using HazarSchool.Entities;
using HazarSchool.HazarSchoolContext;
using HazarSchool.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace HazarSchool.Implementations.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly HazarContext _context;
        public DepartmentRepository(HazarContext context)
        {
            _context = context;
        }

        public Department AddDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
            return department;
        }


        public void DeleteDepartment(int id)
        {
            var department = FindDepartmentById(id);
            _context.Departments.Remove(department);
            _context.SaveChanges();
        }

        public bool Exists(string name)
        {
            var isExisting = _context.Departments.Any(x => x.Name.ToLower() == name.ToLower());
            return isExisting;
        }


        public Department FindDepartmentById(int id)
        {
            var deprtment = _context.Departments.SingleOrDefault(x => x.Id == id);
            return deprtment;
        }

        public List<Department> GetAllDepartments()
        {
            var departments = _context.Departments.ToList();
            return departments;
        }

        public Department UpdateDepartment(Department department)
        {
            _context.Departments.Update(department);
            _context.SaveChanges();
            return department;
        }
    }
}
