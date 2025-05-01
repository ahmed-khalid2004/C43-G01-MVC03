using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MVC03.DataAccess.Repositories.Classes;
using MVC03.BusinessLogic.Services;
using MVC03.BusinessLogic.Services.Classes;
using MVC03.BusinessLogic.Services.Interfaces;
using MVC03.DataAccess.Data.Contexts;
using MVC03.DataAccess.Repositories;
using MVC03.DataAccess.Repositories.Classes;
using MVC03.DataAccess.Repositories.Interfaces;
using MVC03.DataAccess.Repositories.Classes;
using Microsoft.AspNetCore.Mvc;
using MVC03.DataAccess.Repositories.Classes;
using MVC03.BusinessLogic.Profile;
namespace MVC03
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            #region Add Service to Container

            builder.Services.AddControllersWithViews(Options =>
            {
                Options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });
            //builder.Services.AddScoped<ApplicationDbContext>();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration["DefaultConnection"]);
            });

            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddAutoMapper(M => M.AddProfile(new MappingProfile()));
            #endregion

            var app = builder.Build();

            #region Configure the HTTP request pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            #endregion


            app.Run();
        }
    }
}