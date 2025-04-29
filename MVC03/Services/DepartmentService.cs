using MVC03.Models;
using MVC03.Repositories;
using System.Collections.Generic;

namespace MVC03.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentService(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _repository.GetAll(withTracking: false);
        }

        public Department? GetDepartmentById(int id)
        {
            return _repository.GetById(id);
        }

        public int CreateDepartment(Department department)
        {
            return _repository.Add(department);
        }

        public int UpdateDepartment(Department department)
        {
            return _repository.Update(department);
        }

        public int DeleteDepartment(int id)
        {
            var department = _repository.GetById(id);
            if (department == null) return 0;
            return _repository.Remove(department);
        }
    }
}