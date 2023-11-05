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

        public async Task<EmployeeListDto> GetAllAsync(string query)
        {
            var content = await _restclient.GetListAsync(!String.IsNullOrWhiteSpace(query) ? $"?name={query}" : "");
           var employeeListDto = new EmployeeListDto();
            employeeListDto.Employees = content.Data;
            if(content.Headers != null)
            {
                employeeListDto.PaginationData = new PaginationDataDto
                {
                    CurrentPage = int.Parse(content.Headers["x-pagination-page"]),
                    Limit = int.Parse(content.Headers["x-pagination-limit"]),
                    TotalPages = int.Parse(content.Headers["x-pagination-pages"]),
                    TotalCount = int.Parse(content.Headers["x-pagination-total"]),
                };
            }
          
            return employeeListDto;
        }

        public async Task DeleteAsync(int id)
        {
            await _restclient.DeleteAsync(id);
        }
    }
}