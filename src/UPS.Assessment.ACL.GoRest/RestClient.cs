namespace UPS.Assessment.ACL.GoRest
{
    using System.Net.Http.Headers;
    using System.Net.Http.Json;
    using System.Text.Json;
    using UPS.Assessment.ApplicationService.DTO;

    public class RestClient<T> : IRestClient<T>
    {
        private readonly HttpClient _httpClient;

        public RestClient(string baseUrl, string token)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<(List<T>? Data, Dictionary<string,string>? Headers)> GetListAsync(string? query)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"/public/v2/users{query}");
            response.EnsureSuccessStatusCode();
            List<T>? data = await response.Content.ReadFromJsonAsync<List<T>>(new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return (data, response.Headers.ToDictionary(h => h.Key, h => string.Join(",", h.Value)));
        }


        public async Task PostAsync(EmployeeDto employee)
        {
            var response = await _httpClient.PostAsJsonAsync("/public/v2/users", employee, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/public/v2/users/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}