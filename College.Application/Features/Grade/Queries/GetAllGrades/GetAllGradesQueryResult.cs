using Entity = College.Domain.Entities;


namespace College.Application.Features.Grade.Queries
{
    public class GetAllGradesQueryResult
    {
        public int GradeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? TeacherId { get; set; }
        public virtual Entity.Teacher? Teacher { get; set; }
        public Guid AlternativeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public GetAllGradesQueryResult
        (int gradeId, string name, int? teacherId,
            Entity.Teacher? teacher, Guid altertativeId, 
            DateTime createDate, DateTime modifiedDate
        )
        {
            GradeId = gradeId;
            Name = name;
            TeacherId = teacherId;
            Teacher = teacher;
            AlternativeId = altertativeId;
            CreatedDate = createDate;
            ModifiedDate = modifiedDate;
        }
    }
}
