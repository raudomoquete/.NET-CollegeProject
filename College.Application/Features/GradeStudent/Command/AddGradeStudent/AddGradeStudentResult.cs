namespace College.Application.Features.GradeStudent.Command
{
    public class AddGradeStudentResult
    {
        public int GradeStudentId { get; set; }
        public int StudentId { get; set; }
        public int GradeId { get; set; }
        public string SectionGroup { get; set; } = string.Empty;
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
