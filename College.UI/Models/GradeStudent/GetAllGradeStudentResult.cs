using College.UI.Models.Grade;
using College.UI.Models.Student;

namespace College.UI.Models.GradeStudent
{
    public class GetAllGradeStudentResult
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public GetAllStudentsQueryResult? Student { get; set; }
        public int GradeId { get; set; }
        public GetAllGradesQueryResult? Grade { get; set; }
        public string SectionGroup { get; set; } = string.Empty;
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
