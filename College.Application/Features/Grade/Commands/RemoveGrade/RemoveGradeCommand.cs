using MediatR;

namespace College.Application.Features.Grade.Commands
{
    public class RemoveGradeCommand : IRequest<RemoveGradeResult>
    {
        public int GradeId { get; set; }

        public RemoveGradeCommand(int gradeId)
        {
            GradeId = gradeId;
        }
    }
}
