using College.UI.Models.Teacher;

namespace College.UI.Models.Grade
{
    public class GradeDataQuery
    {
        public GradeResult GradeResults { get; set; } = new GradeResult();
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }

    public class GradeResult
    {
        public int GradeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int TeacherId { get; set; }
        public TeacherResult Teacher { get; set; }
    }
}
