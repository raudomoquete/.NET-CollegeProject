namespace College.Application.Features.Student.Queries
{
    public class StudentQueryResult
    {
        public int StudentId { get; }
        public string Name { get; }
        public string LastName { get;}
        public string Gender { get; }
        public DateTime BirthDate { get; }

        public StudentQueryResult()
        {
        }

        public StudentQueryResult(int studentId, string name, string lastName, string gender, DateTime birthDate)
        {
            StudentId = studentId;
            Name = name;
            LastName = lastName;
            Gender = gender;
            BirthDate = birthDate;
        }
    }
}
