using Microsoft.AspNetCore.Mvc;
using AspNetMVCProject.Services;
using AspNetMVCProject.Models;

namespace AspNetMVCProject.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _service;

        public DepartmentController(IDepartmentService service)
        {
            _service = service;
        }

        public IActionResult Index() => View(_service.GetAll());

        public IActionResult Details(int id) => View(_service.GetById(id));

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _service.Add(department);
                return RedirectToAction("Index");
            }
            return View(department);
        }

        public IActionResult Edit(int id) => View(_service.GetById(id));

        [HttpPost]
        public IActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                _service.Update(department);
                return RedirectToAction("Index");
            }
            return View(department);
        }

        public IActionResult Delete(int id) => View(_service.GetById(id));

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
