namespace College.Application.Features.Grade.Commands
{
    public class AddGradeResult
    {
        public int? GradeId { get; set; }
        public string Name { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
