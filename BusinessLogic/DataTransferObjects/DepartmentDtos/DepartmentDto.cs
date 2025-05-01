using MVC03.BusinessLogic.DataTransferObjects.DepartmentDtos;


namespace MVC03.BusinessLogic.DataTransferObjects.DepartmentDtos
{
    public class DepartmentDto
    {
        public int DeptId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateOnly? DateOfCreation { get; set; }


    }
}
