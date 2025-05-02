using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVC03.ViewModels.DepartmentViewModel
{
    public class DepartmentViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateOnly DateOfCreation { get; set; }
    }
}
