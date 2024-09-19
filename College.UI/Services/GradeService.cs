using Newtonsoft.Json;
using System.Text;
using College.UI.Interfaces;
using College.UI.Models.Grade;
using College.UI.Models.Student;

namespace College.UI.Services
{
    public class GradeService : IGradeService
    {
        private readonly HttpClient _httpClient;

        public GradeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AddGradeResult> AddGradeAsync(GradeInput gradeInput)
        {
            try
            {
                var loginAsJson = JsonConvert.SerializeObject(gradeInput, Formatting.Indented);
                var response = await _httpClient.PostAsync("Grade/AddGrade", new StringContent(loginAsJson, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    var createStudentResult = JsonConvert.DeserializeObject<AddGradeResult>(await response.Content.ReadAsStringAsync());
                    return createStudentResult ?? new AddGradeResult();
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return new AddGradeResult();
                }
            }
            catch (Exception ex)
            {
                return new AddGradeResult() { IsError = true, ErrorMessage = ex.Message };
            }
        }

        public async Task<List<GetAllGradesQueryResult>> GetAllGradesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("Grade/GetAllGrades");

                if (response.IsSuccessStatusCode)
                {
                    var grades = JsonConvert.DeserializeObject<List<GetAllGradesQueryResult>>(await response.Content.ReadAsStringAsync());
                    return grades ?? new List<GetAllGradesQueryResult>();
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return new List<GetAllGradesQueryResult>();
                }
            }
            catch (Exception ex)
            {
                return new List<GetAllGradesQueryResult> { new GetAllGradesQueryResult { IsError = true, ErrorMessage = ex.Message } };
            }
        }

        public async Task<GradeResult> GetGradeByIdAsync(int gradeId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"Grade/GetGradeById/{gradeId}");
                if (response.IsSuccessStatusCode)
                {
                    var student = JsonConvert.DeserializeObject<GradeResult>(await response.Content.ReadAsStringAsync());
                    return student ?? new GradeResult();
                }
                else
                {
                    throw new Exception("Error retrieving grade data.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving grade data: {ex.Message}");
            }
        }

        public async Task<RemoveGradeResult> RemoveGradeAsync(int gradeId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"Grade/RemoveGrade/{gradeId}");

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<RemoveGradeResult>(await response.Content.ReadAsStringAsync());
                    return result ?? new RemoveGradeResult();
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return new RemoveGradeResult { IsError = true, ErrorMessage = content };
                }
            }
            catch (Exception ex)
            {
                return new RemoveGradeResult { IsError = true, ErrorMessage = ex.Message };
            }
        }

        public async Task<UpdateGradeResult> UpdateGradeAsync(UpdateGradeInput updateGradeInput)
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(updateGradeInput);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync("Grade/UpdateGrade", content);

                if (!response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return new UpdateGradeResult
                    {
                        IsError = true,
                        ErrorMessage = $"Error: {responseContent}"
                    };
                }

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<UpdateGradeResult>(await response.Content.ReadAsStringAsync());
                    return result ?? new UpdateGradeResult();
                }
                else
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return new UpdateGradeResult { IsError = true, ErrorMessage = responseContent };
                }
            }
            catch (Exception ex)
            {
                return new UpdateGradeResult { IsError = true, ErrorMessage = ex.Message };
            }
        }
    }
}
