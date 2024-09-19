using MediatR;

namespace College.Application.Features.GradeStudent.Command
{
    public class RemoveGradeStudentCommand : IRequest<RemoveGradeStudentResult>
    {
        public int Id { get; set; }

        public RemoveGradeStudentCommand(int id)
        {
            Id = id;
        }
    }
}
