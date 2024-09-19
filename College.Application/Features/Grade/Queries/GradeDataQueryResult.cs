using Entity = College.Domain.Entities;

namespace College.Application.Features.Grade.Queries
{
    public class GradeDataQueryResult
    {
        public int GradeId { get; }
        public string Name { get; }
        public int? TeacherId { get;}
        public virtual Entity.Teacher? Teacher { get; }

        public GradeDataQueryResult()
        {  
        }

        public GradeDataQueryResult(
            int gradeId,
            string name,
            int? teacherId,
            Entity.Teacher? teacher)
        {
            GradeId = gradeId;
            Name = name;
            TeacherId = teacherId;
            Teacher = teacher;
        }
    }
}
