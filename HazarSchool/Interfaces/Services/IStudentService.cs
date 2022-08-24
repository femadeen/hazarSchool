using HazarSchool.ViewModels.ResponseModels;
using static HazarSchool.ViewModels.RequestModels.StudentRequestModel;
using static HazarSchool.ViewModels.ResponseModels.StudentResponseViewModels;

namespace HazarSchool.Interfaces.Services
{
    public interface IStudentService
    {
        public BaseResponse AddStudent(CreateStudentRequestModel model);
        public BaseResponse UpdateStudent(int id, UpdateStudentRequestModel model);
        public StudentResponseModel FindStudentByid(int id);
        public StudentResponseModel DeleteStudent(int id);
        public StudentsResponseModel GetAllStudents();
        public StudentsResponseModel GetMaleStudents();
        public StudentsResponseModel GetFemaleStudents();
        public StudentResponseModel Login(StudentLoginRequestModel model);


    }
}
