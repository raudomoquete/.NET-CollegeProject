using MediatR;

namespace College.Application.Features.Student.Commands
{
    public class UpdateStudentCommand : IRequest<UpdateStudentResult>
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }

        public UpdateStudentCommand(int studentId, string name, string lastName, string gender, DateTime birthDate)
        {
            StudentId = studentId;
            Name = name;
            LastName = lastName;
            Gender = gender;
            BirthDate = birthDate;
        }
    }
}
