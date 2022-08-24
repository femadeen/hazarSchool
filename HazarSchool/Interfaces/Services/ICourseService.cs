using HazarSchool.ViewModels.ResponseModels;
using static HazarSchool.ViewModels.RequestModels.CourseRequestModel;
using static HazarSchool.ViewModels.ResponseModels.CourseResponseViewModels;

namespace HazarSchool.Interfaces.Services
{
    public interface ICourseService
    {
        public BaseResponse AddCourse(CreateCourseRequestModel model);

        public BaseResponse UpdateCourse(int id, UpdateCourseRequestModel model);

        public BaseResponse DeleteCourse(int id);

        public CourseResponseModel GetCourseById(int id);

        public CoursesResponseModel GetAllCourses();




    }
}
