namespace College.Application.Features.Student.Commands
{
    public class AddStudentResult
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
