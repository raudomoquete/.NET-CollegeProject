namespace College.UI.Models.Teacher
{
    public class UpdateTeacherResult
    {
        public int teacherId { get; set; }
        public bool Success { get; set; }
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
