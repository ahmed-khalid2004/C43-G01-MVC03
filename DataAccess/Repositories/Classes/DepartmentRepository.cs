using MVC03.DataAccess.Data.Contexts;
using MVC03.DataAccess.Models.DepartmentModel;
using MVC03.DataAccess.Repositories.Interfaces;

namespace MVC03.DataAccess.Repositories.Classes
{
    public class DepartmentRepository(ApplicationDbContext dbContext) : GenericRepository<Department>(dbContext), IDepartmentRepository
    {
        
    }
}
