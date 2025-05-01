using MVC03.DataAccess.Data.Contexts;
using MVC03.DataAccess.Models.EmployeeModel;
using MVC03.DataAccess.Repositories.Classes;
using MVC03.DataAccess.Repositories.Interfaces;

namespace MVC03.DataAccess.Repositories.Classes
{
    public class EmployeeRepository(ApplicationDbContext dbContext) : GenericRepository<Employee>(dbContext), IEmployeeRepository
    {
        
    }
}
