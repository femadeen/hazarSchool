using HazarSchool.DTOs;
using System.Collections.Generic;

namespace HazarSchool.ViewModels.ResponseModels
{
    public class CourseResponseViewModels
    {
        public class CourseResponseModel : BaseResponse
        {
            public CourseDTO Data { get; set; }
        }

        public class CoursesResponseModel : BaseResponse
        {
            public IEnumerable<CourseDTO> Data { get; set; } = new List<CourseDTO>();
        }
    }
}
