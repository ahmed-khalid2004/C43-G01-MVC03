using System;

namespace MVC03.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
