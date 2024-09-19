using System.ComponentModel.DataAnnotations;
using College.Domain.Models;

namespace College.Domain.Entities
{
    public class Grade : BaseEntity
    {
        [Key]
        public int GradeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? TeacherId { get; set; }
        public virtual Teacher? Teacher { get; set; }

        public virtual ICollection<GradeStudent>? GradeStudents { get; set; }
    }
}
