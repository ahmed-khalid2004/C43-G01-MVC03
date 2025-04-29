using Microsoft.EntityFrameworkCore;
using AspNetMVCProject.Models;
using System.Reflection;
using MVC03.Data.Confingurations;

namespace MVC03.Data.Contexts
{
    class ApplicationDbContext : DbContext
        {
            public DbSet<Department> Departments { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("ConnectionString");
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.ApplyConfiguration<Department>(new DepartmentConfigurations());
                modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
                modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            }
        }
    }
