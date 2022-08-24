using HazarSchool.DTOs;
using HazarSchool.Entities;
using HazarSchool.Interfaces.Repositories;
using HazarSchool.Interfaces.Services;
using HazarSchool.ViewModels.ResponseModels;
using System.Linq;
using static HazarSchool.ViewModels.RequestModels.DepartmentRequestModel;
using static HazarSchool.ViewModels.ResponseModels.DepartmentResponseViewModels;

namespace HazarSchool.Implementations.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public BaseResponse AddDepartment(CreateDepartmentRequestModel model)
        {
            var departmentExist = _departmentRepository.Exists(model.Name);
            if (departmentExist)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = "Department already exist"
                };
            }
            var department = new Department
            {
                Name = model.Name
            };
            _departmentRepository.AddDepartment(department);
            return new BaseResponse
            {
                Status = true,
                Message = $"{model.Name} department created susccessfully"
            };

        }

        public BaseResponse DeleteDepartment(int id)
        {
            var department = _departmentRepository.FindDepartmentById(id);
            if (department == null)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = $"department with{id} doest not exist"
                };
            }
            _departmentRepository.DeleteDepartment(id);
            return new BaseResponse
            {
                Status = true,
                Message = $" {department.Name} deleted successuly"
            };

        }

        public DepartmentsResponseModel GetAllDepartments()
        {
            var departments = _departmentRepository.GetAllDepartments();
            var returnedDepartments = departments.Select(x => new DepartmentDTO
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return new DepartmentsResponseModel
            {
                Data = returnedDepartments,
                Status = true,
                Message = "All Departments retreived successfully"
            };
        }

        public DepartmentResponseModel GetDepartmentById(int id)
        {
            var department = _departmentRepository.FindDepartmentById(id);
            if (department == null)
            {
                return new DepartmentResponseModel
                {
                    Status = false,
                    Message = $" department with id {id} does not exist"
                };
            }
            return new DepartmentResponseModel
            {
                Data = new DepartmentDTO
                {
                    Id = department.Id,
                    Name = department.Name,
                    Students = department.Students.Select(x => new StudentDTO
                    {
                        Id = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Age = x.Age,
                        FullName = $"{x.FirstName} {x.LastName}",
                        DepartmentName = x.Department.Name

                    }).ToList()
                },
                Status = true,
                Message = "Student retrieved successfully"
            };
        }

        public BaseResponse UpdateDepartment(int id, UpdateDepartmentRequestModel model)
        {
            var departmentToBeUpdated = _departmentRepository.FindDepartmentById(id);
            if (departmentToBeUpdated == null)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = $"{model.Name} department does not exist"
                };
            }
            departmentToBeUpdated.Name = model.Name;
            _departmentRepository.UpdateDepartment(departmentToBeUpdated);
            return new BaseResponse
            {
                Status = true,
                Message = " department updated successfully"
            };
        }
    }
}
