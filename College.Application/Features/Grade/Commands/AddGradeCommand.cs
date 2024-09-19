using MediatR;

namespace College.Application.Features.Grade.Commands
{
    public class AddGradeCommand : IRequest<AddGradeResult>
    {
        public string Name { get; set; } = string.Empty;

        public AddGradeCommand(string name)
        {
            Name = name;
        }
    }
}
