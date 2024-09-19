namespace College.UI.Models.Student
{
    public class AddStudentResult
    {
        public int studentId { get; set; }
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
