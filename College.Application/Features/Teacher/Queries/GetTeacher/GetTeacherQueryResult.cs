namespace College.Application.Features.Teacher.Queries
{
    public class GetTeacherQueryResult
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }

        public GetTeacherQueryResult()
        {
           
        }

        public GetTeacherQueryResult(int teacherId, string name, string lastName, string gender)
        {
            TeacherId = teacherId;
            Name = name;
            LastName = lastName;
            Gender = gender;
        }
    }
}
