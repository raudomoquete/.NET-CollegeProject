using College.UI.Models.Student;

namespace College.UI.Interfaces
{
    public interface IStudentService
    {
        Task<StudentResult> GetStudentByIdAsync(int studentId);

        Task<AddStudentResult> AddStudentAsync(StudentInput studentInput);

        Task<List<GetAllStudentsQueryResult>> GetAllStudentsAsync();

        Task<RemoveStudentResult> RemoveStudentAsync(int studentId);

        Task<UpdateStudentResult> UpdateStudentAsync(UpdateStudentInput updateStudentInput);
    }
}
