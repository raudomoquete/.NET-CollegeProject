using MediatR;

namespace College.Application.Features.GradeStudent.Queries
{
    public class GetGradeStudentQuery : IRequest<GetGradeStudentQuery>
    {
        public List<GetGradeStudentQueryResult> GradeStudentQueryResults { get; set; } = new List<GetGradeStudentQueryResult>();
        public int Count { get; set; }
    }
}
