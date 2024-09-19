namespace College.UI.Models.Grade
{
    public class RemoveGradeResult
    {
        public bool Success { get; set; }
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
