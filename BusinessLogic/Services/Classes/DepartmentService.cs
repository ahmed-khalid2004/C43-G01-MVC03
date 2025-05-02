using BusinessLogic.DataTransferObjects.DepartmentDtos;
using MVC03.BusinessLogic.DataTransferObjects.DepartmentDtos;
using MVC03.BusinessLogic.Factories;
using MVC03.BusinessLogic.Services.Interfaces;
using MVC03.DataAccess.Repositories.Interfaces;

namespace MVC03.BusinessLogic.Services.Classes
{
    public class DepartmentService(IUnitOfWork _unitOfWork) : IDepartmentService
    {
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departments = _unitOfWork.DepartmentRepository.GetAll();

            return departments.Select(D => D.ToDepartmentDto());
        }

        public DepartmentDetailsDto? GetDepartmentById(int id)
        {
            var department = _unitOfWork.DepartmentRepository.GetById(id);

            return department is null ? null : department.ToDepartmentDetailsDto();
        }
        public int CreateDepartment(CreatedDepartmentDto departmentDto)
        {
            var department = departmentDto.ToEntity();
            _unitOfWork.DepartmentRepository.Add(department);
            return _unitOfWork.SaveChanges();
        }
        public int AddDepartment(CreatedDepartmentDto departmentDto)
        {
            var department = departmentDto.ToEntity();

            _unitOfWork.DepartmentRepository.Add(department);

            return _unitOfWork.SaveChanges();
        }

        public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
        {
            _unitOfWork.DepartmentRepository.Update(departmentDto.ToEntity());
            return _unitOfWork.SaveChanges();
        }

        public bool DeleteDepartment(int id)
        {
            var department = _unitOfWork.DepartmentRepository.GetById(id);
            if (department is null) return false;
            else
            {
                _unitOfWork.DepartmentRepository.Remove(department);
                int Result = _unitOfWork.SaveChanges();
                return Result > 0 ? true : false;

            }
        }


    }
}
