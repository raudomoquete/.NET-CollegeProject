using College.UI.Models.GradeStudent;

namespace College.UI.Interfaces
{
    public interface IGradeStudentService
    {
        Task<GradeStudentResult> GetGradeStudentByIdAsync(int gradeStudentId);

        Task<AddGradeStudentResult> AddGradeStudentAsync(GradeStudentInput gradeStudentInput);

        Task<List<GetAllGradeStudentResult>> GetAllGradeStudentAsync();

        Task<RemoveGradeStudentResult> RemoveGradeStudentAsync(int gradestudentId);

        Task<UpdateGradeStudentResult> UpdateGradeStudentAsync(UpdateGradeStudentInput updateGradeStudentInput);
    }
}
