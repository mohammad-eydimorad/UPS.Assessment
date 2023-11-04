using UPS.Assessment.ApplicationService;
using UPS.Assessment.ApplicationService.DTO;

namespace UPS.Assessment.ACL.GoRest
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRestClient<EmployeeDto> _restclient;

        public EmployeeService(IRestClient<EmployeeDto> apiHelper)
        {
            _restclient = apiHelper;
        }

        public async Task AddAsync(EmployeeDto employee)
        {
           await _restclient.PostAsync(employee);
        }

        public async Task<List<EmployeeDto>?> GetAllAsync(string query)
        {
            var content = await _restclient.GetListAsync(!String.IsNullOrWhiteSpace(query) ? $"?name={query}" : "");
            return content;
        }

        public async Task DeleteAsync(int id)
        {
            await _restclient.DeleteAsync(id);
        }
    }
}