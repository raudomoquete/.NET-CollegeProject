using MediatR;

namespace College.Application.Features.Teacher.Queries
{
    public class GetAllTeachersQuery : IRequest<List<GetAllTeachersQueryResult>>
    {
        public List<GetAllTeachersQuery> TeachersQueryResults { get; set; } = new List<GetAllTeachersQuery>();
        public int Count { get; set; }
    }
    
}
