namespace College.UI.Models.Teacher
{
    public class AddTeacherResult
    {
        public int teacherId { get; set; }
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
