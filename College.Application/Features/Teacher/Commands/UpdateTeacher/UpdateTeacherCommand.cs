using MediatR;

namespace College.Application.Features.Teacher.Commands
{
    public class UpdateTeacherCommand : IRequest<UpdateTeacherResult>
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }

        public UpdateTeacherCommand(int teacherId, string name, string lastName, string gender)
        {
            TeacherId = teacherId;
            Name = name;
            LastName = lastName;
            Gender = gender;
        }
    }
}
