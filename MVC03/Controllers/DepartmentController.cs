using MVC03.Services;
using Microsoft.AspNetCore.Mvc;

namespace MVC03.Controllers
{
    public class DepartmentController(IDepartmentService departmentServices) : Controller
    {
        public IActionResult Index()
        {
            var Departments = departmentServices.GetAllDepartments();
            return View();
        }
    }
}