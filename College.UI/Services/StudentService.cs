using Newtonsoft.Json;
using System.Text;
using College.UI.Interfaces;
using College.UI.Models.Student;

namespace College.UI.Services
{
    public class StudentService : IStudentService
    {
        private readonly HttpClient _httpClient;

        public StudentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AddStudentResult> AddStudentAsync(StudentInput studentInput)
        {
            try
            {
                var loginAsJson = JsonConvert.SerializeObject(studentInput, Formatting.Indented);
                var response = await _httpClient.PostAsync("Student/AddStudent", new StringContent(loginAsJson, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    var createStudentResult = JsonConvert.DeserializeObject<AddStudentResult>(await response.Content.ReadAsStringAsync());
                    return createStudentResult ?? new AddStudentResult();
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return new AddStudentResult();
                }
            }
            catch(Exception ex)
            {
                return new AddStudentResult() { IsError = true, ErrorMessage = ex.Message };
            }
        }

        public async Task<List<GetAllStudentsQueryResult>> GetAllStudentsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("Student/GetAllStudents");

                if (response.IsSuccessStatusCode)
                {
                    var students = JsonConvert.DeserializeObject<List<GetAllStudentsQueryResult>>(await response.Content.ReadAsStringAsync());
                    return students ?? new List<GetAllStudentsQueryResult>();
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return new List<GetAllStudentsQueryResult>();
                }
            }
            catch (Exception ex)
            {
                return new List<GetAllStudentsQueryResult> { new GetAllStudentsQueryResult { IsError = true, ErrorMessage = ex.Message } };
            }
        }

        public async Task<RemoveStudentResult> RemoveStudentAsync(int studentId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"Student/RemoveStudent/{studentId}");

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<RemoveStudentResult>(await response.Content.ReadAsStringAsync());
                    return result ?? new RemoveStudentResult();
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return new RemoveStudentResult { IsError = true, ErrorMessage = content };
                }
            }
            catch (Exception ex)
            {
                return new RemoveStudentResult { IsError = true, ErrorMessage = ex.Message };
            }
        }

        public async Task<StudentResult> GetStudentByIdAsync(int studentId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"Student/GetStudentById/{studentId}");
                if (response.IsSuccessStatusCode)
                {
                    var student = JsonConvert.DeserializeObject<StudentResult>(await response.Content.ReadAsStringAsync());
                    return student ?? new StudentResult();
                }
                else
                {
                    throw new Exception("Error retrieving student data.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving student data: {ex.Message}");
            }
        }

        public async Task<UpdateStudentResult> UpdateStudentAsync(UpdateStudentInput updateStudentInput)
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(updateStudentInput);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync("Student/UpdateStudent", content);

                if (!response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return new UpdateStudentResult
                    {
                        IsError = true,
                        ErrorMessage = $"Error: {responseContent}"
                    };
                }

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<UpdateStudentResult>(await response.Content.ReadAsStringAsync());
                    return result ?? new UpdateStudentResult();
                }
                else
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return new UpdateStudentResult { IsError = true, ErrorMessage = responseContent };
                }
            }
            catch (Exception ex)
            {
                return new UpdateStudentResult { IsError = true, ErrorMessage = ex.Message };
            }
        }

    }
}
