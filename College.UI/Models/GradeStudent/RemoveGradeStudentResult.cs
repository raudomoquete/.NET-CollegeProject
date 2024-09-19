namespace College.UI.Models.GradeStudent
{
    public class RemoveGradeStudentResult
    {
        public bool Success { get; set; }
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
