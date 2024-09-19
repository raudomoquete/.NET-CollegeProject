using MediatR;

namespace College.Application.Features.Student.Queries
{
    public class GetStudentByIdQuery : IRequest<StudentQueryResult>
    {
        public int StudentId { get; }

        public GetStudentByIdQuery(int studentId)
        {
            StudentId = studentId;
        }
    }
}
