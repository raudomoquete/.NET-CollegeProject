using MediatR;

namespace College.Application.Features.GradeStudent.Command
{
    public class UpdateGradeStudentCommand : IRequest<UpdateGradeStudentResult>
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int GradeId { get; set; }
        public string SectionGroup { get; set; } = string.Empty;

        public UpdateGradeStudentCommand(
            int id, 
            int studentId,
            int gradeId,
            string sectionGroup)
        {
            Id = id;
            StudentId = studentId;
            GradeId = gradeId;
            SectionGroup = sectionGroup;
        }
    }
}
