using System.Text;
using System.Threading.Tasks;
namespace MVC03.Models
{
    public class BaseEntity
    {
        public int Id { get; set; } // Primary Key
        public int CreatedBy { get; set; } // User Id
        public DateTime? CreateOn { get; set; }
        public int LastModifiedBy { get; set; } // User ID
        public DateTime? LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; } // Soft Delete
    }
}
