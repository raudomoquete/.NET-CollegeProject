namespace College.Application.Features.Student.Queries
{
    public class GetAllStudentsQueryResult
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public Guid AlternativeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public GetAllStudentsQueryResult(int studentId, string name, string lastName, string gender, DateTime bday, Guid altertativeId, DateTime createDate, DateTime modifiedDate)
        {
            StudentId = studentId;
            Name = name;
            LastName = lastName;
            Gender = gender;
            BirthDate = bday;
            AlternativeId = altertativeId;
            CreatedDate = createDate;
            ModifiedDate = modifiedDate;
        }
    }
}
