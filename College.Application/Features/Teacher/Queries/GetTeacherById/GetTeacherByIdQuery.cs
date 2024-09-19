using MediatR;

namespace College.Application.Features.Teacher.Queries
{
    public class GetTeacherByIdQuery : IRequest<GetTeacherQueryResult>
    {
        public int TeacherId { get; set; }

        public GetTeacherByIdQuery(int teacherId)
        {
            TeacherId = teacherId;
        }
    }
}
