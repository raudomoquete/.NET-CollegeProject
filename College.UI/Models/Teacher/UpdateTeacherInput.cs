namespace College.UI.Models.Teacher
{
    public class UpdateTeacherInput
    {
        public int teacherId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
    }
}