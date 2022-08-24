using HazarSchool.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using static HazarSchool.ViewModels.RequestModels.CourseRequestModel;

namespace HazarSchool.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public IActionResult Index()
        {
            var courses = _courseService.GetAllCourses();
            return View(courses);
        }

        public IActionResult CreateCourse()
        {
            return View();
        }

        [HttpPost]

        public IActionResult CreateCourse(CreateCourseRequestModel model)
        {
            _courseService.AddCourse(model);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var course = _courseService.GetCourseById(id);
            return View(course);
        }

        [HttpPost]
        public IActionResult Update(int id, UpdateCourseRequestModel model)
        {
            var course = _courseService.UpdateCourse(id, model);
            {
                return RedirectToAction("Index");
            }
        }
        public IActionResult CourseDetails(int id)
        {
            var course = _courseService.GetCourseById(id);
            return View(course);
        }
        public IActionResult Delete(int id)
        {
            var course = _courseService.GetCourseById(id);
            return View(course);
        }

        [HttpPost, ActionName("Delete")]

        public IActionResult DeleteConfirmed(int id)
        {
            var course = _courseService.DeleteCourse(id);
            return RedirectToAction("index");
        }

    }
}
