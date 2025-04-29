namespace MVC03.DataTransferObjects
{
    public class UpdatedDepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public DateOnly Date { get; set; }
        public string? Description { get; set; } 
        
    }
}
