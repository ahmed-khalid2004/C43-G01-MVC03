using MVC03.Models;
using System.Collections.Generic;

namespace MVC03.Services
{
    public interface IDepartmentService
    {
        IEnumerable<Department> GetAllDepartments();
        Department? GetDepartmentById(int id);
        int CreateDepartment(Department department);
        int UpdateDepartment(Department department);
        int DeleteDepartment(int id);
    }
}