using Microsoft.EntityFrameworkCore;
using AspNetMVCProject.Models;

namespace AspNetMVCProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Department> Departments { get; set; }
    }
}
