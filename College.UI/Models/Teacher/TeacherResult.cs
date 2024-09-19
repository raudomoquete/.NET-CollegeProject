namespace College.UI.Models.Teacher
{
    public class TeacherDataQuery
    {
        public TeacherResult TeacherResults { get; set; } = new TeacherResult();
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }

    public class TeacherResult
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
    }
}
