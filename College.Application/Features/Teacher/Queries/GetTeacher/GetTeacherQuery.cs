using MediatR;

namespace College.Application.Features.Teacher.Queries
{
    public class GetTeacherQuery : IRequest<GetTeacherQuery>
    {
        public List<GetTeacherQueryResult> TeacherQueryResults { get; set; } = new List<GetTeacherQueryResult>();
        public int Count { get; set; }
    }
}
