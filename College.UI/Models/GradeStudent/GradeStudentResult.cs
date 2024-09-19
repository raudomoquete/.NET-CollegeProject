using College.UI.Models.Grade;
using College.UI.Models.Student;

namespace College.UI.Models.GradeStudent
{
    public class GradeStudentResult
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public StudentResult? Student { get; set; }
        public int GradeId { get; set; }
        public GradeResult? Grade { get; set; }
        public string SectionGroup { get; set; }
    }
}
