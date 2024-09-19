namespace College.UI.Models.Student
{
    public class StudentDataQuery
    {
        public StudentResult StudentResults { get; set; } = new StudentResult();
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }

    public class StudentResult
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
