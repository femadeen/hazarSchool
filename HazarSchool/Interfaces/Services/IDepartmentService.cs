using HazarSchool.ViewModels.ResponseModels;
using static HazarSchool.ViewModels.RequestModels.DepartmentRequestModel;
using static HazarSchool.ViewModels.ResponseModels.DepartmentResponseViewModels;

namespace HazarSchool.Interfaces.Services
{
    public interface IDepartmentService
    {
        public BaseResponse AddDepartment(CreateDepartmentRequestModel model);
        public BaseResponse UpdateDepartment(int id, UpdateDepartmentRequestModel model);
        public BaseResponse DeleteDepartment(int id);
        public DepartmentResponseModel GetDepartmentById(int id);
        public DepartmentsResponseModel GetAllDepartments();
    }
}
