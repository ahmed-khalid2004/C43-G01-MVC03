using Microsoft.EntityFrameworkCore;
using MVC03.Data.Contexts;
using MVC03.Models;

namespace MVC03.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Department> GetAll(bool withTracking = false)
        {
            return withTracking
                ? _context.Departments.ToList()
                : _context.Departments.AsNoTracking().ToList();
        }

        public Department? GetById(int id)
        {
            return _context.Departments.Find(id);
        }

        public int Add(Department department)
        {
            _context.Departments.Add(department);
            return _context.SaveChanges();
        }

        public int Update(Department department)
        {
            _context.Departments.Update(department);
            return _context.SaveChanges();
        }

        public int Remove(Department department)
        {
            _context.Departments.Remove(department);
            return _context.SaveChanges();
        }
    }
}