namespace College.Application.Features.Teacher.Queries
{
    public class GetAllTeachersQueryResult
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public Guid AlternativeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public GetAllTeachersQueryResult(int teacherId, string name, string lastName, string gender, Guid altertativeId, DateTime createDate, DateTime modifiedDate)
        {
            TeacherId = teacherId;
            Name = name;
            LastName = lastName;
            Gender = gender;
            AlternativeId = altertativeId;
            CreatedDate = createDate;
            ModifiedDate = modifiedDate;
        }
    }
}
