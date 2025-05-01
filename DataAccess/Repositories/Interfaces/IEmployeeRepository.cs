using MVC03.DataAccess.Models.EmployeeModel;

namespace MVC03.DataAccess.Repositories.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        int Add(Employee employee);
    }
}
