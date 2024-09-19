using MediatR;

namespace College.Application.Features.Grade.Commands
{
    public class UpdateGradeCommand : IRequest<UpdateGradeResult>
    {
        public int GradeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int TeacherId { get; set; }

        public UpdateGradeCommand(int gradeId, string name, int teacherId)
        {
            GradeId = gradeId;
            Name = name;
            TeacherId = teacherId;
        }
    }
}
