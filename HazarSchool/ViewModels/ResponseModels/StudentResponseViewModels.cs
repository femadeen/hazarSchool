using HazarSchool.DTOs;
using System.Collections.Generic;

namespace HazarSchool.ViewModels.ResponseModels
{
    public class StudentResponseViewModels
    {
        public class StudentResponseModel : BaseResponse
        {
            public StudentDTO Data { get; set; }
        }

        public class StudentsResponseModel : BaseResponse
        {
            public IEnumerable<StudentDTO> Data { get; set; } = new List<StudentDTO>();
        }
    }
}
