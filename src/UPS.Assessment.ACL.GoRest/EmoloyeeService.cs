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

        public async Task<EmployeeListDto> GetAllAsync(string name, int? page)
        {
            var (Data, Headers) = await _restclient.GetListAsync(MakeQueryString(page ?? 1, name));
            var employeeListDto = new EmployeeListDto
            {
                Employees = Data
            };
            if (Headers != null)
            {
                employeeListDto.PaginationData = new PaginationDto(int.Parse(Headers["x-pagination-page"]), int.Parse(Headers["x-pagination-limit"]), int.Parse(Headers["x-pagination-pages"]), int.Parse(Headers["x-pagination-total"]));
            }

            return employeeListDto;
        }

        public async Task DeleteAsync(int id)
        {
            await _restclient.DeleteAsync(id);
        }

        private string MakeQueryString(int page, string name)
        {
            string queryString = $"?page={page}";
            if (!string.IsNullOrEmpty(name))
            {
                queryString += $"&name={name}";
            }

            return queryString;
        }
    }
}