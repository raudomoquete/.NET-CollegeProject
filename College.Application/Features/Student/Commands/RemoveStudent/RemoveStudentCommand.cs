using MediatR;

namespace College.Application.Features.Student.Commands
{
    public class RemoveStudentCommand : IRequest<RemoveStudentResult>
    {
        public int StudentId { get; set; }

        public RemoveStudentCommand(int studentId)
        {
            StudentId = studentId;
        }
    }
}
