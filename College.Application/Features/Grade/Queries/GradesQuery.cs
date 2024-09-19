using MediatR;

namespace College.Application.Features.Grade.Queries
{
    public class GradesQuery : IRequest<GradesQuery>
    {
        public List<GradeDataQueryResult> GradeDataQueryResults { get; set; } = new List<GradeDataQueryResult>();
        public int Count { get; set; }
    }
}
