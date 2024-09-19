using MediatR;

namespace College.Application.Features.GradeStudent.Queries
{
    public class GetGradeStudentByIdQuery : IRequest<GetGradeStudentQueryResult>
    {
        public int Id { get; }

        public GetGradeStudentByIdQuery(int gradeStudentId)
        {
            Id = gradeStudentId;
        }
    }
}
