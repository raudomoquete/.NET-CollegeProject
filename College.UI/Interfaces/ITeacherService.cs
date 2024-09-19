using College.UI.Models.Teacher;

namespace College.UI.Interfaces
{
    public interface ITeacherService
    {
        Task<TeacherResult> GetTeachertByIdAsync(int teacherId);

        Task<AddTeacherResult> AddTeacherAsync(TeacherInput teacherInput);

        Task<List<GetAllTeachersQueryResult>> GetAllTeachersAsync();

        Task<RemoveTeacherResult> RemoveTeacherAsync(int teacherId);

        Task<UpdateTeacherResult> UpdateTeacherAsync(UpdateTeacherInput updateTeacherInput);
    }
}
