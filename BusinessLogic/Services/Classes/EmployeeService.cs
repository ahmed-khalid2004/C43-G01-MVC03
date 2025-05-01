using AutoMapper;
using MVC03.BusinessLogic.DataTransferObjects.EmployeeDtos;
using MVC03.BusinessLogic.Services.Interfaces;
using MVC03.DataAccess.Models.EmployeeModel;
using MVC03.DataAccess.Repositories.Interfaces;

namespace MVC03.BusinessLogic.Services.Classes
{
    public class EmployeeService(IEmployeeRepository _employeeRepository, IMapper _mapper) : IEmployeeService
    {
        public IEnumerable<EmployeeDto> GetAllEmployees(bool withTracking = false)
        {
            var employees = _employeeRepository.GetAll(withTracking);

            var employeesDto = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);

            return employeesDto;
        }
        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetById(id);

            return employee is null ? null : _mapper.Map<EmployeeDetailsDto>(employee);
        }
        public int CreateEmployee(CreatedEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<CreatedEmployeeDto, Employee>(employeeDto);
            return _employeeRepository.Add(employee);
        }

        public int UpdateEmployee(UpdatedEmployeeDto employeeDto)
        {
            return _employeeRepository.Update(_mapper.Map<UpdatedEmployeeDto, Employee>(employeeDto));
        }

        public bool DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }


    }
}
