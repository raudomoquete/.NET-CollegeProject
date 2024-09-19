namespace College.Application.Features.Student.Commands
{
    public class RemoveStudentResult
    {
        public int StudentId { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
