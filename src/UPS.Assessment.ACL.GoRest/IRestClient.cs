using UPS.Assessment.ApplicationService.DTO;

namespace UPS.Assessment.ACL.GoRest
{
    public interface IRestClient<T>
    {
        Task<List<T>?> GetListAsync(string? query);
        Task PostAsync(EmployeeDto employee);
        Task DeleteAsync(int id);
    }
}
