using EntityDepartment = MVC03.DataAccess.Models.DepartmentModel.Department;
using MVC03.DataAccess.Models.DepartmentModel;

namespace MVC03.DataAccess.Repositories
{
    public interface IDepartmentRepository
    {
        int Add(EntityDepartment department);
        IEnumerable<EntityDepartment> GetAll(bool WithTracking = false);
        EntityDepartment? GetById(int id);
        int Remove(EntityDepartment department);
        int Update(EntityDepartment department);
    }
}