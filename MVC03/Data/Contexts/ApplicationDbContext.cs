using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MVC03.Data.Contexts
{
    public class ApplicationDKContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("ConnectionString");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Either apply individual configuration
            // modelBuilder.ApplyConfiguration(new DepartmentConfiguration());

            // Or apply all configurations from assembly
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}