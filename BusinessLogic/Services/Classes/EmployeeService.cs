using MVC03.BusinessLogic.DataTransferObjects.EmployeeDtos;
using MVC03.BusinessLogic.Services.Interfaces;
using MVC03.DataAccess.Repositories.Interfaces;

namespace MVC03.BusinessLogic.Services.Classes
{
    public class EmployeeService(IEmployeeRepository _employeeRepository) : IEmployeeService
    {
        public IEnumerable<EmployeeDto> GetAllEmployees(bool withTracking = false)
        {
            var employees = _employeeRepository.GetAll(withTracking);

            var employeesDto = employees.Select(emp => new EmployeeDto
            {
                Id = emp.Id,
                Name = emp.Name,
                Age = emp.Age,
                Email = emp.Email,
                IsActive = emp.IsActive,
                Salary = emp.Salary,
                EmployeeType = emp.EmployeeType.ToString(),
                Gender = emp.Gender.ToString()
            });

            return employeesDto;
        }
        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetById(id);

            return employee is null ? null : new EmployeeDetailsDto()
            {
                Id = employee.Id,
                Name = employee.Name,
                Salary = employee.Salary,
                Address = employee.Address,
                Age = employee.Age,
                Email = employee.Email,
                HiringDate = DateOnly.FromDateTime(employee.HiringDate),
                IsActive = employee.IsActive,
                PhoneNumber = employee.PhoneNumber,
                EmployeeType = employee.EmployeeType.ToString(),
                Gender = employee.Gender.ToString(),
                CreatedBy = 1,
                CreatedOn = (DateTime)employee.CreatedOn,
                LastModifiedBy = 1,
                LastModifiedOn = (DateTime)employee.LastModifiedOn
            };
        }
        public int CreateEmployee(CreatedEmployeeDto employeeDto)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public int UpdateEmployee(UpdatedEmployeeDto employeeDto)
        {
            throw new NotImplementedException();
        }
    }
}
