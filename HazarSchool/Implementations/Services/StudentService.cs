using HazarSchool.DTOs;
using HazarSchool.Entities;
using HazarSchool.Interfaces.Repositories;
using HazarSchool.Interfaces.Services;
using HazarSchool.ViewModels.ResponseModels;
using System.Linq;
using static HazarSchool.ViewModels.RequestModels.StudentRequestModel;
using static HazarSchool.ViewModels.ResponseModels.StudentResponseViewModels;

namespace HazarSchool.Implementations.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        public StudentService(IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }

        public int DateTime { get; private set; }

        public BaseResponse AddStudent(CreateStudentRequestModel model)
        {
            var studentCheck = _studentRepository.Exists(model.FirstName, model.LastName);
            if (studentCheck)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = $"{model.FirstName} and {model.LastName} already exist"
                };
            }
            var student = new Student
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                Level = model.Level,
                Gender = model.Gender,
                Email = model.Email,
                Password = model.Password,
                DepartmentId = model.DepartmentId,

            };
            var courses = _courseRepository.GetSelectedCourses(model.CourseIds);
            /* var studentCourses = new List<StudentCourse>();*/
            foreach (var course in courses)
            {
                StudentCourse studentCourse = new StudentCourse
                {
                    CourseId = course.Id,
                    StudentId = student.Id,
                    Student = student,
                    Course = course
                };
                student.StudentCourses.Add(studentCourse);
                /* studentCourses.Add(studentCourse);*/
            }
            _studentRepository.AddStudent(student);

            /*_studentRepository.AddStudentCourses(studentCourses);*/
            return new BaseResponse
            {
                Status = true,
                Message = "Student Added Successfully"
            };
        }

        public StudentResponseModel DeleteStudent(int id)
        {
            var student = _studentRepository.FindStudentById(id);
            if (student == null)
            {
                return new StudentResponseModel
                {
                    Status = false,
                    Message = "Student does not exist"
                };
            }
            _studentRepository.DeleteStudent(id);
            return new StudentResponseModel
            {
                Status = true,
                Message = "Student deleted successsfully"
            };
        }

        public StudentResponseModel FindStudentByid(int id)
        {
            var student = _studentRepository.FindStudentById(id);
            if (student == null)
            {
                return new StudentResponseModel
                {
                    Status = false,
                    Message = "Student does not exist"
                };
            }
            return new StudentResponseModel
            {
                Data = new StudentDTO
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Age = student.Age,
                    Email = student.Email,
                    DepartmentName = student.Department.Name,
                    Courses = student.StudentCourses.Select(s => new CourseDTO
                    {
                        Id = s.Id,
                        Name = s.Course.Name

                    }).ToList()
                },
                Status = true,
                Message = "Student detials retrieved successfully"
            };
        }

        public StudentsResponseModel GetAllStudents()
        {
            var students = _studentRepository.GetAllStudents();
            var retrunedStudent = students.Select(s => new StudentDTO
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Age = s.Age,

            }).ToList();
            return new StudentsResponseModel
            {
                Data = retrunedStudent,
                Status = true,
                Message = "List of Students retreived successfully"
            };
        }

        public StudentsResponseModel GetFemaleStudents()
        {
            var students = _studentRepository.GetFemaleStudents();
            var femaleStudents = students.Select(f => new StudentDTO
            {
                Id = f.Id,
                FirstName = f.FirstName,
                LastName = f.LastName,
                Email = f.Email
            }).ToList();
            return new StudentsResponseModel
            {
                Data = femaleStudents,
                Status = true,
                Message = "List of Female Student retreived succeffuly"
            };
        }

        public StudentsResponseModel GetMaleStudents()
        {
            var students = _studentRepository.GetMaleStudents();
            var maleStudents = students.Select(m => new StudentDTO
            {
                Id = m.Id,
                FirstName = m.FirstName,
                LastName = m.LastName,
                Email = m.Email
            }).ToList();
            return new StudentsResponseModel
            {
                Data = maleStudents,
                Status = true,
                Message = "List Of Male Students retrived sucessfully"
            };
        }

        public StudentResponseModel Login(StudentLoginRequestModel model)
        {
            var student = _studentRepository.FindStudentByEmail(model.Email);
            if (student == null)
            {
                return new StudentResponseModel
                {
                    Status = false,
                    Message = "Invalid email or password"
                };
            }
            if (student.Password != model.Password)
            {
                return new StudentResponseModel
                {
                    Status = false,
                    Message = "Invalid email or password"
                };
            }
            return new StudentResponseModel
            {
                Status = true,
                Message = "Login successful",
                Data = new StudentDTO
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Age = student.Age,
                    Email = student.Email
                }

            };


        }

        public BaseResponse UpdateStudent(int id, UpdateStudentRequestModel model)
        {
            var student = _studentRepository.FindStudentById(id);
            if (student == null)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = " No student with such Id exist"
                };
            }
            student.Email = model.Email;
            student.Age = model.Age;
            student.LastName = model.LastName;
            _studentRepository.UpdateStudent(student);
            return new BaseResponse
            {
                Status = true,
                Message = "Student updated successfully"
            };

        }
    }
}
