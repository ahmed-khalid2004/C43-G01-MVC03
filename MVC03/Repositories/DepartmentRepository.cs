using AspNetMVCProject.Models;
using Demo.DataAccess.Data.Contexts;
using Demo.DataAccess.Entities;

namespace Demo.DataAccess.Repositories
{
    // Primary Constructor - .NET 8 C# 12
    class DepartmentRepository(ApplicationDbContext dbContext)
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        // CRUD Operations
        // Get All
        // Get By Id
        public Department? GetById(int id)
        {
            var department = _dbContext.Departments.Find(id);
            return department;
        }

        // Update
        // Delete
        // Insert
    }
}
