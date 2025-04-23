using System.Collections.Generic;
using AspNetMVCProject.Models;

namespace AspNetMVCProject.Services
{
    public interface IDepartmentService
    {
        IEnumerable<Department> GetAll();
        Department GetById(int id);
        void Add(Department department);
        void Update(Department department);
        void Delete(int id);
    }
}
