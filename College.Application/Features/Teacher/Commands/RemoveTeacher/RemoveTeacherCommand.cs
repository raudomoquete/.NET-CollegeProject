using MediatR;

namespace College.Application.Features.Teacher.Commands
{
    public class RemoveTeacherCommand : IRequest<RemoveTeacherResult>
    {
        public int TeacherId { get; set; }

        public RemoveTeacherCommand(int teacherId)
        {
            TeacherId = teacherId;
        }
    }
}
