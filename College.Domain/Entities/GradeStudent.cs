using System.ComponentModel.DataAnnotations;
using College.Domain.Models;

namespace College.Domain.Entities
{
    public class GradeStudent : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public virtual Student? Student { get; set; }
        public int GradeId { get; set; }
        public virtual Grade? Grade { get; set; }
        public string SectionGroup { get; set; } = string.Empty;
    }
}