using Newtonsoft.Json;
using System.Text;
using College.UI.Interfaces;
using College.UI.Models.Teacher;

namespace College.UI.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly HttpClient _httpClient;

        public TeacherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AddTeacherResult> AddTeacherAsync(TeacherInput teacherInput)
        {
            try
            {
                var loginAsJson = JsonConvert.SerializeObject(teacherInput, Formatting.Indented);
                var response = await _httpClient.PostAsync("Teacher/AddTeacher", new StringContent(loginAsJson, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    var createTeacherResult = JsonConvert.DeserializeObject<AddTeacherResult>(await response.Content.ReadAsStringAsync());
                    return createTeacherResult ?? new AddTeacherResult();
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return new AddTeacherResult();
                }
            }
            catch (Exception ex)
            {
                return new AddTeacherResult() { IsError = true, ErrorMessage = ex.Message };
            }
        }

        public async Task<List<GetAllTeachersQueryResult>> GetAllTeachersAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("Teacher/GetAllTeachers");

                if (response.IsSuccessStatusCode)
                {
                    var teachers = JsonConvert.DeserializeObject<List<GetAllTeachersQueryResult>>(await response.Content.ReadAsStringAsync());
                    return teachers ?? new List<GetAllTeachersQueryResult>();
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return new List<GetAllTeachersQueryResult>();
                }
            }
            catch (Exception ex)
            {
                return new List<GetAllTeachersQueryResult> { new GetAllTeachersQueryResult { IsError = true, ErrorMessage = ex.Message } };
            }
        }

        public async Task<TeacherResult> GetTeachertByIdAsync(int teacherId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"Teacher/GetTeacherById/{teacherId}");
                if (response.IsSuccessStatusCode)
                {
                    var student = JsonConvert.DeserializeObject<TeacherResult>(await response.Content.ReadAsStringAsync());
                    return student ?? new TeacherResult();
                }
                else
                {
                    throw new Exception("Error retrieving teacher data.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving teacher data: {ex.Message}");
            }
        }

        public async Task<RemoveTeacherResult> RemoveTeacherAsync(int teacherId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"Teacher/RemoveTeacher/{teacherId}");

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<RemoveTeacherResult>(await response.Content.ReadAsStringAsync());
                    return result ?? new RemoveTeacherResult();
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return new RemoveTeacherResult { IsError = true, ErrorMessage = content };
                }
            }
            catch (Exception ex)
            {
                return new RemoveTeacherResult { IsError = true, ErrorMessage = ex.Message };
            }
        }

        public async Task<UpdateTeacherResult> UpdateTeacherAsync(UpdateTeacherInput updateTeacherInput)
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(updateTeacherInput);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync("Teacher/UpdateTeacher", content);

                if (!response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return new UpdateTeacherResult
                    {
                        IsError = true,
                        ErrorMessage = $"Error: {responseContent}"
                    };
                }

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<UpdateTeacherResult>(await response.Content.ReadAsStringAsync());
                    return result ?? new UpdateTeacherResult();
                }
                else
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return new UpdateTeacherResult { IsError = true, ErrorMessage = responseContent };
                }
            }
            catch (Exception ex)
            {
                return new UpdateTeacherResult { IsError = true, ErrorMessage = ex.Message };
            }
        }
    }
}
