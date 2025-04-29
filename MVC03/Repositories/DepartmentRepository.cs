using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AspNetMVCProject.Models;
using MVC03.Data.Contexts;

namespace MVC03.Data.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DepartmentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Get all departments with optional tracking
        public IEnumerable<Department> GetAll(bool withTracking = false)
        {
            var query = _dbContext.Departments.AsQueryable();

            if (!withTracking)
            {
                query = query.AsNoTracking();
            }

            return query.ToList();
        }

        // Get department by ID
        public Department? GetById(int id)
        {
            return _dbContext.Departments.Find(id);
        }

        // Update department
        public int Update(Department department)
        {
            _dbContext.Departments.Update(department);
            return _dbContext.SaveChanges();
        }

        // Delete department
        public int Remove(Department department)
        {
            _dbContext.Departments.Remove(department);
            return _dbContext.SaveChanges();
        }

        // Add new department
        public int Add(Department department)
        {
            _dbContext.Departments.Add(department);
            return _dbContext.SaveChanges();
        }
    }
}