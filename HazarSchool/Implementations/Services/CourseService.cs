using HazarSchool.DTOs;
using HazarSchool.Entities;
using HazarSchool.Interfaces.Repositories;
using HazarSchool.Interfaces.Services;
using HazarSchool.ViewModels.ResponseModels;
using System.Linq;
using static HazarSchool.ViewModels.RequestModels.CourseRequestModel;
using static HazarSchool.ViewModels.ResponseModels.CourseResponseViewModels;

namespace HazarSchool.Implementations.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public BaseResponse AddCourse(CreateCourseRequestModel model)
        {
            var courseExisting = _courseRepository.Exist(model.Name);
            if (courseExisting)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = "Sorry! Course already exist"
                };
            }
            var course = new Course
            {
                Name = model.Name,
            };
            _courseRepository.AddCourse(course);
            return new BaseResponse
            {
                Status = true,
                Message = "Course successfully registered"
            };
        }

        public BaseResponse DeleteCourse(int id)
        {
            var course = _courseRepository.FindCourseById(id);
            if (course == null)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = "Course does not exist"
                };
            }
            _courseRepository.DeleteCourse(id);
            return new BaseResponse
            {
                Status = true,
                Message = "Course Deleted Successfully"
            };
        }

        public CoursesResponseModel GetAllCourses()
        {
            var courses = _courseRepository.GetAllCourses();
            var returnedCourses = courses.Select(x => new CourseDTO
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
            return new CoursesResponseModel
            {
                Data = returnedCourses,
                Status = true,
                Message = "All Courses retrieved successfully"
            };
        }

        public CourseResponseModel GetCourseById(int id)
        {
            var course = _courseRepository.FindCourseById(id);
            if (course == null)
            {
                return new CourseResponseModel
                {
                    Status = false,
                    Message = $"Course with ID {id} does not exist"
                };
            }
            return new CourseResponseModel
            {
                Data = new CourseDTO
                {
                    Id = course.Id,
                    Name = course.Name,
                    Students = course.StudentCourses.Select(x => new StudentDTO
                    {
                        Id = x.Student.Id,
                        FirstName = x.Student.FirstName,
                        LastName = x.Student.LastName,
                        Age = x.Student.Age,
                        FullName = x.Student.FirstName + x.Student.LastName,
                        DepartmentName = x.Student.Department.Name
                    }).ToList(),
                },
            };
        }

        public BaseResponse UpdateCourse(int id, UpdateCourseRequestModel model)
        {
            var courseToBeUpdated = _courseRepository.FindCourseById(id);
            if (courseToBeUpdated == null)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = "Course does not exist"
                };
            }
            courseToBeUpdated.Name = model.Name;
            _courseRepository.UpdateCourse(courseToBeUpdated);
            return new BaseResponse
            {
                Status = true,
                Message = "Course updated successfully"
            };
        }
    }
}
