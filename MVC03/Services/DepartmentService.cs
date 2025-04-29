using AspNetMVCProject.Models;
using MVC03.Data.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MVC03.Services
{
    class DepartmentService
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentService(DepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        public int Test()
        {
            List<Department> departments = departmentRepository.GetAll().ToList();
        }
    }
}