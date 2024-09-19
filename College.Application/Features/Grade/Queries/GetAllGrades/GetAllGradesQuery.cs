using MediatR;

namespace College.Application.Features.Grade.Queries
{
    public class GetAllGradesQuery : IRequest<List<GetAllGradesQueryResult>>
    {
        public List<GetAllGradesQuery> GradesQueryResults { get; set; } = new List<GetAllGradesQuery>();
        public int Count { get; set; }
    }
}
