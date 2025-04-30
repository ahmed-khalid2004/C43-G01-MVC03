using MVC03.Models;

namespace MVC03.DataTransferObjects
{
    public class DepartmentDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly CreatedOn { get; set; }
        public int LastModifiedBy { get; set; }

        public DepartmentDetailsDto(Department department)
        {
            Id = department.Id;
            Name = department.Name;
            CreatedOn = DateOnly.FromDateTime(department.CreateOn);
        }
    }
}
