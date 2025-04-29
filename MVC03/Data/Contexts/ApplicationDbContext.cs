using Microsoft.EntityFrameworkCore;
using MVC03.Models;

namespace MVC03.Data.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Department> Departments { get; set; }
    }
}