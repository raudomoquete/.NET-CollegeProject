using College.Application.Common;
using MediatR;

namespace College.Application.Features.Grade.Commands
{
    public class AddGradeCommand : IRequest<Result>
    {
        public string Name { get; set; } = string.Empty;

        public AddGradeCommand(string name)
        {
            Name = name;
        }
    }
}
