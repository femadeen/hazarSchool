namespace HazarSchool.ViewModels.RequestModels
{
    public class CourseRequestModel
    {
        public class CreateCourseRequestModel
        {
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public class UpdateCourseRequestModel
        {
            public string Name { get; set; }
            public string Description { get; set; }

        }
    }
}
