using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MVC03.Data.Contexts;
using AspNetMVCProject.Services;

namespace MVC03.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Add services to the container
            builder.Services.AddControllersWithViews();
            //builder.Services.AddScoped<ApplicationDbContext>(); // 2. Register To Service In DI Container
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped<IDepartmentService, DepartmentRepository>();
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline

            app.Run();
        }
    }
}