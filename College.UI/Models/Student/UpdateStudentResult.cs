namespace College.UI.Models.Student
{
    public class UpdateStudentResult
    {
        public int studentId { get; set; }
        public bool Success { get; set; }
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
