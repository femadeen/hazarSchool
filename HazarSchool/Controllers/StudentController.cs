using HazarSchool.Interfaces.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Security.Claims;
using static HazarSchool.ViewModels.RequestModels.StudentRequestModel;

namespace HazarSchool.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IDepartmentService _departmentService;
        private readonly ICourseService _courseService;
        public StudentController(IStudentService studentService, IDepartmentService department, ICourseService courseService)

        {
            _studentService = studentService;
            _departmentService = department;
            _courseService = courseService;
        }

        public IActionResult Index()
        {
            if(ModelState.IsValid)
            {

            }
            var students = _studentService.GetAllStudents();
            return View(students);
        }

        public IActionResult FemaleStudents()
        {
            var femaleStudents = _studentService.GetFemaleStudents();
            return View(femaleStudents);
        }

        public IActionResult MaleStudents()
        {
            var maleStudents = _studentService.GetMaleStudents();
            return View(maleStudents);
        }
        public IActionResult AddStudent()
        {
            var departments = _departmentService.GetAllDepartments();
            var courses = _courseService.GetAllCourses();
            ViewData["Departments"] = new SelectList(departments.Data, "Id", "Name");
            ViewData["Courses"] = new SelectList(courses.Data, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(CreateStudentRequestModel model)
        {
            _studentService.AddStudent(model);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var student = _studentService.FindStudentByid(id);
            return View(student.Data);
        }

        [HttpPost]
        public IActionResult Update(int id, UpdateStudentRequestModel model)
        {
            _studentService.UpdateStudent(id, model);
            return RedirectToAction("index");
        }

        public IActionResult UpdateProfile()
        {
            int id = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var student = _studentService.FindStudentByid(id);
            return View(student.Data);
        }

        [HttpPost]
        public IActionResult UpdateProfile(UpdateStudentRequestModel model)
        {
            int id = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
             _studentService.UpdateStudent(id, model);
            var student = _studentService.FindStudentByid(id);
            return RedirectToAction("StudentDetails", student.Data);
        }
        public IActionResult StudentDetails(int id)
        {
            var student = _studentService.FindStudentByid(id);
            return View(student);
        }

        [Authorize]
        public IActionResult DeleteStudent(int id)
        {
            var student = _studentService.FindStudentByid(id);
            return View(student);
        }

        [Authorize]
        [HttpPost, ActionName("DeleteStudent")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _studentService.DeleteStudent(id);
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]

        public IActionResult Login(StudentLoginRequestModel model)
        {
            var loginStatus = _studentService.Login(model);
            if (loginStatus.Status == false)
            {
                ViewBag.Message = loginStatus.Message;
                return View();
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, loginStatus.Data.FirstName),
                new Claim(ClaimTypes.NameIdentifier, loginStatus.Data.Id.ToString()),
                new Claim(ClaimTypes.GivenName, $"{loginStatus.Data.FirstName} {loginStatus.Data.LastName}"),
                new Claim(ClaimTypes.Email, loginStatus.Data.Email)
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authenticationProperties = new AuthenticationProperties();
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authenticationProperties);
            return RedirectToAction("StudentDetails", loginStatus.Data);
        }
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }


        /*public IActionResult Login(StudentLoginRequestModel model)
        {
           var loginStatus = _studentService.Login(model);
            if (loginStatus.Status == false)
            {
                ViewBag.Message = loginStatus.Message;
                return View();
            }
            if (loginStatus.Status == true)
            {
                ViewBag.Message = loginStatus.Message;
                return RedirectToAction("Index");
            }
            HttpContext.Session.SetInt32("Id", loginStatus.Data.Id);
            HttpContext.Session.SetString("Email", loginStatus.Data.Email);
            return RedirectToAction("Index");
        }*/

        /*public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }*/
    }
}
