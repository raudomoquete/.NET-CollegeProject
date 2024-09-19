using MediatR;

namespace College.Application.Features.Student.Queries
{
    public class GetAllStudentsQuery : IRequest<List<GetAllStudentsQueryResult>>
    {
        public List<GetAllStudentsQuery> StudentsQueryResults { get; set; } = new List<GetAllStudentsQuery>();
        public int Count { get; set; }
    }
}
