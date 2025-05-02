using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC03.DataAccess.Repositories.Interfaces
{
    public interface IUnitOfWork 
    {
        IEmployeeRepository EmployeeRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        int SaveChanges();
    }
}
