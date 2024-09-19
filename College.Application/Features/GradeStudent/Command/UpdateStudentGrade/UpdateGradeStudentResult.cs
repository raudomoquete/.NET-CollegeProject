namespace College.Application.Features.GradeStudent.Command
{
    public class UpdateGradeStudentResult
    {
        public int Id { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
