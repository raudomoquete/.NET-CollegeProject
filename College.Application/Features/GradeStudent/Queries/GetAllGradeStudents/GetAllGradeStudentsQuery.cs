using MediatR;

namespace College.Application.Features.GradeStudent.Queries
{
    public class GetAllGradeStudentsQuery : IRequest<List<GetAllGradeStudentsQueryResult>>
    {
        public List<GetAllGradeStudentsQuery> GradeStudentsQueryResults { get; set; } = new List<GetAllGradeStudentsQuery>();
        public int Count { get; set; }
    }
}
