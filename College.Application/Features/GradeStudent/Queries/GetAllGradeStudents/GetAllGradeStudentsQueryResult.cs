namespace College.Application.Features.GradeStudent.Queries
{
    public class GetAllGradeStudentsQueryResult
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int GradeId { get; set; }
        public string SectionGroup { get; set; }

        public GetAllGradeStudentsQueryResult(
            int id, 
            int studentId,
            int gradeId,
            string sectionGroup)
        {
            Id = id;
            StudentId = studentId;
            GradeId = gradeId;
            SectionGroup = sectionGroup;
        }
    }
}
