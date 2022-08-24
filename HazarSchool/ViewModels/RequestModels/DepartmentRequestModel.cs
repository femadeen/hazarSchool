using System.ComponentModel.DataAnnotations;

namespace HazarSchool.ViewModels.RequestModels
{
    public class DepartmentRequestModel
    {
        public class CreateDepartmentRequestModel
        {
            [Required (ErrorMessage = "Department name required")]
            public string Name { get; set; }
        }

        public class UpdateDepartmentRequestModel
        {
            public string Name { get; set; }
        }
    }
}
