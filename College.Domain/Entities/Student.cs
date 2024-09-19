using System.ComponentModel.DataAnnotations;
using College.Domain.Models;

namespace College.Domain.Entities
{
    public class Student : BaseEntity
    {
        [Key]
        public int StudentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }

        public virtual ICollection<GradeStudent> GradeStudents { get; set; } = new List<GradeStudent>();
    }
}
