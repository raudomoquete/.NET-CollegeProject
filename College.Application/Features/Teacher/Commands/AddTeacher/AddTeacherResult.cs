namespace College.Application.Features.Teacher.Command
{
    public class AddTeacherResult
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
