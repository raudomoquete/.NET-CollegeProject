namespace College.UI.Models.GradeStudent
{
    public class UpdateGradeStudentInput
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int GradeId { get; set; }
        public string SectionGroup { get; set; } = string.Empty;
    }
}
