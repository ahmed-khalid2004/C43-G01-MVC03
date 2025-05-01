using System;
using MVC03.BusinessLogic.DataTransferObjects;
using MVC03.DataAccess.Models;

namespace MVC03.BusinessLogic.Factories
{
    static class DepartmentFactory
    {
        public static DepartmentDto ToDepartmentDto(this Department D)
        {
            return new DepartmentDto()
            {
                DeptId = D.Id,
                Code = D.Code,
                Description = D.Description,
                Name = D.Name,
                DateOfCreation = DateOnly.FromDateTime((DateTime)D.CreatedOn)
            };
        }

        public static DepartmentDetailsDto ToDepartmentDetailsDto(this Department D) {
            return new DepartmentDetailsDto()
            {
                Id = D.Id,
                Name = D.Name,
                CreatedOn = DateOnly.FromDateTime((DateTime)D.CreatedOn)
            };
        }

        public static Department ToEntity(this CreatedDepartmentDto departmentDto)
        {
            return new Department()
            {
                Name = departmentDto.Name,
                Code = departmentDto.Code,
                Description = departmentDto.Description,
                CreatedOn = departmentDto.DateOfCreation.ToDateTime(new TimeOnly())
            };
        }

        public static Department ToEntity(this UpdatedDepartmentDto departmentDto)
        {
            return new Department()
            {
                Id = departmentDto.Id,
                Name = departmentDto.Name,
                Code = departmentDto.Code,
                CreatedOn = departmentDto.DateOfCreation.ToDateTime(new TimeOnly()),
                Description = departmentDto.Description
            };
        }
    }
}
