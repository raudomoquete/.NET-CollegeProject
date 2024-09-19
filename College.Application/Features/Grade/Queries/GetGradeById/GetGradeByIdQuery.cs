using MediatR;

namespace College.Application.Features.Grade.Queries
{
    public class GetGradeByIdQuery : IRequest<GradeDataQueryResult>
    {
        public int GradeId { get; }

        public GetGradeByIdQuery(int gradeId)
        {
            GradeId = gradeId;
        }
    }
}
