using MediatR;

namespace College.Application.Features.Student.Queries
{
    public class GetStudentQuery : IRequest<GetStudentQuery>
    {
        public List<StudentQueryResult> StudentQueryResults { get; set; } = new List<StudentQueryResult>();
        public int Count { get; set; }
    }
}
