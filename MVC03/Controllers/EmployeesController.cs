using Microsoft.AspNetCore.Mvc;
using MVC03.BusinessLogic.DataTransferObjects.EmployeeDtos;
using MVC03.BusinessLogic.Services.Interfaces;
using MVC03.DataAccess.Models.EmployeeModel;
using MVC03.DataAccess.Models.Shared.Enums;
using MVC03.ViewModels;

namespace MVC03.Controllers
{
    public class EmployeesController(IEmployeeService _employeeService, IWebHostEnvironment environment, ILogger<EmployeesController> logger) : Controller
    {
        public IActionResult Index()
        {
            var Employees = _employeeService.GetAllEmployees();
            return View(Employees);
        }

        #region Create Employee

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(CreatedEmployeeDto employeeDto)
        {
            if (ModelState.IsValid) // Server Side Validation
            {
                try
                {
                    int result = _employeeService.CreateEmployee(employeeDto);
                    if (result > 0)
                        return RedirectToAction(actionName: nameof(Index));
                    else
                        ModelState.AddModelError(key: string.Empty, errorMessage: "Can't Create Employee");
                }
                catch (Exception ex)
                {
                    if (environment.IsDevelopment())
                        ModelState.AddModelError(key: string.Empty, errorMessage: ex.Message);
                    else
                        logger.LogError(message: ex.Message);
                }
            }
            return View(employeeDto);
        }

        #endregion

        #region Details of Employee
        [HttpGet]
        public IActionResult Details(int? id)
        {

            if (!id.HasValue) return BadRequest();
            var employee = _employeeService.GetEmployeeById(id.Value);
            return employee is null ? NotFound() : View(employee);
        }
        #endregion

        #region Edit Employee
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var employee = _employeeService.GetEmployeeById(id.Value);

            if (employee == null)
                return NotFound();
            var employeeDto = new UpdatedEmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Salary = employee.Salary,
                Address = employee.Address,
                Age = employee.Age,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                IsActive = employee.IsActive,
                HiringDate = employee.HiringDate,
                Gender = Enum.Parse<Gender>(employee.Gender),
                EmployeeType = Enum.Parse<EmployeeType>(employee.EmployeeType)
            };

            return View(employeeDto);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int? id, UpdatedEmployeeDto employeeDto)
        {
            if (!id.HasValue || id != employeeDto.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(employeeDto);

            try
            {
                var result = _employeeService.UpdateEmployee(employeeDto);

                if (result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee is not Updated");
                    return View(employeeDto);
                }
            }
            catch (Exception ex)
            {
                if (environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(employeeDto);
                }
                else
                {
                    logger.LogError(ex.Message);
                    return View("ErrorView", ex);
                }
            }

        }

        #endregion

        #region Delete Employee
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return BadRequest();

            try
            {
                var deleted = _employeeService.DeleteEmployee(id);

                if (deleted)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee is not Deleted");
                    return RedirectToAction(nameof(Delete), new { id = id });
                }
            }
            catch (Exception ex)
            {
                if (environment.IsDevelopment())
                {
                    // Optionally show a custom message: "Employee could not be deleted"
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    logger.LogError(ex.Message);
                    return View("Error", ex);
                }
            }
        }
        #endregion

    }
}
