using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DataTransferObjects.DepartmentDtos
{
    public class CreatedDepartmentDto
    {
        public string Name {  get; set; } = null!;
        public string Description { get; set; }
        public string Code { get; set; } = null!;
        public DateOnly DateOfCreation { get; set; }

    }
}
