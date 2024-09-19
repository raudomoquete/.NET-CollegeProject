namespace College.UI.Models.Student
{
    public class UpdateStudentInput
    {
        public int StudentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
    }
}
