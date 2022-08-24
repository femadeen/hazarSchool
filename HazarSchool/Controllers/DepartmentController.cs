using HazarSchool.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using static HazarSchool.ViewModels.RequestModels.DepartmentRequestModel;

namespace HazarSchool.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments();
            return View(departments);
        }

        public IActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]

        public IActionResult AddDepartment(CreateDepartmentRequestModel model)
        {
            var response = _departmentService.AddDepartment(model);
            if (!response.Status)
            {
                ViewBag["Department enter Already exist"] = response.Message;
            }
            return RedirectToAction("Index");
        }

        public IActionResult UpdateDepartment(int id)
        {
            var department = _departmentService.GetDepartmentById(id);
            return View(department.Data);
        }

        [HttpPost]

        public IActionResult UpdateDepartment(int id, UpdateDepartmentRequestModel model)
        {
            _departmentService.UpdateDepartment(id, model);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var department = _departmentService.GetDepartmentById(id);
            return View(department);
        }
        
        public IActionResult Delete(int id)
        {
            var department = _departmentService.GetDepartmentById(id);
            return View(department);
        }

        [HttpPost, ActionName("Delete")]

        public IActionResult DeleteConfirmed(int id)
        {
            var department = _departmentService.DeleteDepartment(id);
            return RedirectToAction("Index");
        }
    }
}
