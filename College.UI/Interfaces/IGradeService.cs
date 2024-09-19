using College.UI.Models.Grade;

namespace College.UI.Interfaces
{
    public interface IGradeService
    {
        Task<GradeResult> GetGradeByIdAsync(int gradeId);

        Task<AddGradeResult> AddGradeAsync(GradeInput gradeInput);

        Task<List<GetAllGradesQueryResult>> GetAllGradesAsync();

        Task<RemoveGradeResult> RemoveGradeAsync(int gradeId);

        Task<UpdateGradeResult> UpdateGradeAsync(UpdateGradeInput updateGradeInput);
    }
}
