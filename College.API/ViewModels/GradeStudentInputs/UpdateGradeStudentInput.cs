using College.Domain.Entities;

namespace College.API.ViewModels.GradeStudentInputs
{
    public class UpdateGradeStudentInput
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int GradeId { get; set; }
        public string SectionGroup { get; set; }
    }
}
