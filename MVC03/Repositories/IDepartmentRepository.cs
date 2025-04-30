using MVC03.Models;
using System.Collections.Generic;

namespace MVC03.Repositories
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAll(bool withTracking = false);
        Department? GetById(int id);
        int Add(Department department);
        int Update(Department department);
        int Remove(Department department);
    }
}