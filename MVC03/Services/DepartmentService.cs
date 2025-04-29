using System.Collections.Generic;
using System.Linq;
using AspNetMVCProject.Models;
using MVC03.Data.Contexts;

namespace AspNetMVCProject.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationDbContext _context;

        public DepartmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Department> GetAll()
        {
            return _context.Departments.Where(d => !d.IsDeleted).ToList();
        }

        public Department GetById(int id)
        {
            return _context.Departments.Find(id);
        }

        public void Add(Department department)
        {
            department.CreatedOn = DateTime.Now;
            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        public void Update(Department department)
        {
            _context.Departments.Update(department);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var dept = _context.Departments.Find(id);
            if (dept != null)
            {
                dept.IsDeleted = true;
                _context.SaveChanges();
            }
        }
    }
}
