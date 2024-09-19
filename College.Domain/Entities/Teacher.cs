using System.ComponentModel.DataAnnotations;
using College.Domain.Models;

namespace College.Domain.Entities
{
    public class Teacher : BaseEntity
    {
        [Key]
        public int TeacherId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
    }
}
