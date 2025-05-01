using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC03.DataAccess.Data.Contexts;
using MVC03.DataAccess.Models.DepartmentModel;
using EntityDepartment = MVC03.DataAccess.Models.DepartmentModel.Department;

namespace MVC03.DataAccess.Repositories
{
    public class DepartmentRepository(ApplicationDbContext dbContext) : IDepartmentRepository
    {
        private readonly ApplicationDbContext _dbContext = dbContext;
        //public DepartmentRepository (ApplicationDbContext dbContext) { this._dbContext = dbContext;}

        public IEnumerable<EntityDepartment> GetAll(bool WithTracking = false)
        {
            if (WithTracking) return _dbContext.Departments.ToList();
            else return _dbContext.Departments.AsNoTracking().ToList();
        }
        public EntityDepartment? GetById(int id) => _dbContext.Departments.Find(id);

        public int Update(EntityDepartment department)
        {
            _dbContext.Departments.Update(department);
            return _dbContext.SaveChanges();
        }

        public int Remove(EntityDepartment department)
        {
            _dbContext.Departments.Remove(department);
            return _dbContext.SaveChanges();
        }

        public int Add(EntityDepartment department)
        {
            _dbContext.Departments.Add(department);
            return _dbContext.SaveChanges();
        }


    }
}
