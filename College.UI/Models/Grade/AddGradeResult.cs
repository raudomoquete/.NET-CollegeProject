namespace College.UI.Models.Grade
{
    public class AddGradeResult
    {
        public int teacherId { get; set; }
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
