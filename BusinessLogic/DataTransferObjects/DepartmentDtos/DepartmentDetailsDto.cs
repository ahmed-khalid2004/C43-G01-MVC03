using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC03.DataAccess.Models;
namespace BusinessLogic.DataTransferObjects.DepartmentDtos
{
    public class DepartmentDetailsDto
    {
        /* DepartmentDetailsDto(Department department) { 
            Id = department.Id;
            Name = department.Name;
            CreatedOn = DateOnly.FromDateTime((DateTime)department.CreatedOn);
        }*/
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateOnly? CreatedOn { get; set; }
        public int LastModifiedBy { get; set; }
        public DateOnly? LastModifiedOn { get; set; }

        public bool IsDeleted { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}