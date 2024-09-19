using MediatR;

namespace College.Application.Features.GradeStudent.Command
{
    public class AddGradeStudentCommand : IRequest<AddGradeStudentResult>
    {
        public int StudentId { get; set; }
        public int GradeId { get; set; }
        public string SectionGroup { get; set; } = string.Empty;

        public AddGradeStudentCommand(int studentId, int gradeId, string sectionGroup)
        {
            StudentId = studentId;
            GradeId = gradeId;
            SectionGroup = sectionGroup;
        }
    }
}
