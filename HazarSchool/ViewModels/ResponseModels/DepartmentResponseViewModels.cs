using HazarSchool.DTOs;
using System.Collections.Generic;

namespace HazarSchool.ViewModels.ResponseModels
{
    public class DepartmentResponseViewModels
    {
        public class DepartmentResponseModel : BaseResponse
        {
            public DepartmentDTO Data { get; set; }
        }

        public class DepartmentsResponseModel : BaseResponse
        {
            public IEnumerable<DepartmentDTO> Data { get; set; } = new List<DepartmentDTO>();
        }
    }
}
