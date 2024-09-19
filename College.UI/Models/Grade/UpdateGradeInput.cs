using College.UI.Models.Teacher;

namespace College.UI.Models.Grade
{
    public class UpdateGradeInput
    {
        public int GradeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual UpdateTeacherInput? Teacher { get; set; }
    }
}
