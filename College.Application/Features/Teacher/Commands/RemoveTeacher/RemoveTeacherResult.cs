namespace College.Application.Features.Teacher.Commands
{
    public class RemoveTeacherResult
    {
        public int TeacherId { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
