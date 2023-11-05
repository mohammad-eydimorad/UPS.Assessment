using UPS.Assessment.ApplicationService.DTO;

namespace UPS.Assessment.ApplicationService
{
    public interface IEmployeeService
    {
        Task AddAsync(EmployeeDto employee);
        Task<EmployeeListDto> GetAllAsync(string query);
        Task DeleteAsync(int id);
    }
}