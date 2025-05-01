using System.Collections.Generic;
using System.Linq;
using MVC03.BusinessLogic.DataTransferObjects;
using MVC03.BusinessLogic.Factories;
using MVC03.BusinessLogic.Services;
using MVC03.DataAccess.Repositories;

namespace MVC03.BusinessLogic.Services
{
    public class DepartmentService(IDepartmentRepository _departmentRepository) : IDepartmentService
    {
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departments = _departmentRepository.GetAll();

            return departments.Select(D => D.ToDepartmentDto());
        }

        public DepartmentDetailsDto? GetDepartmentById(int id)
        {
            var department = _departmentRepository.GetById(id);

            return department is null ? null : department.ToDepartmentDetailsDto();
        }

        public int AddDepartment(CreatedDepartmentDto departmentDto)
        {
            var department = departmentDto.ToEntity();

            return _departmentRepository.Add(department);
        }

        public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
        {
            return _departmentRepository.Update(departmentDto.ToEntity());
        }

        public bool DeleteDepartment(int id)
        {
            var department = _departmentRepository.GetById(id);
            if (department is null) return false;
            else
            {
                int Result = _departmentRepository.Remove(department);
                return Result > 0 ? true : false;

            }
        }

    }
}
