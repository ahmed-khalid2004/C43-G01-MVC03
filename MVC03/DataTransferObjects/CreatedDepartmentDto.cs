using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC03.DataTransferObjects
{
    public class CreatedDepartmentDto
    {
        public string Name { get; set; } = null!;
        [Required(ErrorMessage =":(")]
        public string Code { get; set; } = null!;
        public DateOnly DateOfCreation { get; set; }
        public string? Description { get; set; }
    }
}