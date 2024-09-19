using College.UI.Models.Teacher;

namespace College.UI.Models.Grade
{
    public class GetAllGradesQueryResult
    {
        public int GradeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int TeacherId { get; set; }
        public GetAllTeachersQueryResult Teacher { get; set; }
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
