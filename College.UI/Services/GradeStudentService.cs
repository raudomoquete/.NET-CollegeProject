using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using College.UI.Interfaces;
using College.UI.Models.GradeStudent;
using College.UI.Models.Student;

namespace College.UI.Services
{
    public class GradeStudentService : IGradeStudentService
    {
        private readonly HttpClient _httpClient;

        public GradeStudentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AddGradeStudentResult> AddGradeStudentAsync(GradeStudentInput gradeStudentInput)
        {
            try
            {
                var loginAsJson = JsonConvert.SerializeObject(gradeStudentInput, Formatting.Indented);
                var response = await _httpClient.PostAsync("GradeStudent/AddGradeStudent", new StringContent(loginAsJson, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    var createStudentResult = JsonConvert.DeserializeObject<AddGradeStudentResult>(await response.Content.ReadAsStringAsync());
                    return createStudentResult ?? new AddGradeStudentResult();
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return new AddGradeStudentResult();
                }
            }
            catch (Exception ex)
            {
                return new AddGradeStudentResult() { IsError = true, ErrorMessage = ex.Message };
            }
        }

        public async Task<List<GetAllGradeStudentResult>> GetAllGradeStudentAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("GradeStudent/GetAllGradeStudents");

                if (response.IsSuccessStatusCode)
                {
                    var students = JsonConvert.DeserializeObject<List<GetAllGradeStudentResult>>(await response.Content.ReadAsStringAsync());
                    return students ?? new List<GetAllGradeStudentResult>();
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return new List<GetAllGradeStudentResult>();
                }
            }
            catch (Exception ex)
            {
                return new List<GetAllGradeStudentResult> { new GetAllGradeStudentResult { IsError = true, ErrorMessage = ex.Message } };
            }
        }

        public async Task<GradeStudentResult> GetGradeStudentByIdAsync(int gradeStudentId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"GradeStudent/GetGradeStudentById/{gradeStudentId}");
                if (response.IsSuccessStatusCode)
                {
                    var student = JsonConvert.DeserializeObject<GradeStudentResult>(await response.Content.ReadAsStringAsync());
                    return student ?? new GradeStudentResult();
                }
                else
                {
                    throw new Exception("Error retrieving grade student data.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving student data: {ex.Message}");
            }
        }

        public async Task<RemoveGradeStudentResult> RemoveGradeStudentAsync(int gradestudentId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"GradeStudent/RemoveGradeStudent/{gradestudentId}");

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<RemoveGradeStudentResult>(await response.Content.ReadAsStringAsync());
                    return result ?? new RemoveGradeStudentResult();
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return new RemoveGradeStudentResult { IsError = true, ErrorMessage = content };
                }
            }
            catch (Exception ex)
            {
                return new RemoveGradeStudentResult { IsError = true, ErrorMessage = ex.Message };
            }
        }

        public async Task<UpdateGradeStudentResult> UpdateGradeStudentAsync(UpdateGradeStudentInput updateGradeStudentInput)
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(updateGradeStudentInput);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync("GradeStudent/UpdateGradeStudent", content);

                if (!response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return new UpdateGradeStudentResult
                    {
                        IsError = true,
                        ErrorMessage = $"Error: {responseContent}"
                    };
                }

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<UpdateGradeStudentResult>(await response.Content.ReadAsStringAsync());
                    return result ?? new UpdateGradeStudentResult();
                }
                else
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return new UpdateGradeStudentResult { IsError = true, ErrorMessage = responseContent };
                }
            }
            catch (Exception ex)
            {
                return new UpdateGradeStudentResult { IsError = true, ErrorMessage = ex.Message };
            }
        }
    }
}
