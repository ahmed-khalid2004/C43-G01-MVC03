using System.Collections.Generic;
using System.Linq;
using AspNetMVCProject.Data;
using AspNetMVCProject.Models;

namespace AspNetMVCProject.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly AppDbContext _context;

        public DepartmentService(AppDbContext context)
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
