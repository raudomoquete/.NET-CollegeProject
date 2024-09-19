namespace College.UI.Models.GradeStudent
{
    public class UpdateGradeStudentResult
    {
        public int gradeStudentId { get; set; }
        public bool Success { get; set; }
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
