namespace College.UI.Models.Student
{
    public class RemoveStudentResult
    {
        public bool Success { get; set; }
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
