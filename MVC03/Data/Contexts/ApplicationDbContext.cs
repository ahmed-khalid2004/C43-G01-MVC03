using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Demo.DataAccess.Data.Configurations;
using Demo.DataAccess.Models;

namespace Demo.DataAccess.Data.Contexts
{
    public class ApplicationDKContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Either apply individual configuration
            // modelBuilder.ApplyConfiguration(new DepartmentConfiguration());

            // Or apply all configurations from assembly
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}