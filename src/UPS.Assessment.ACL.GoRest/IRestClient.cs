using UPS.Assessment.ApplicationService.DTO;

namespace UPS.Assessment.ACL.GoRest
{
    public interface IRestClient<T>
    {
        Task<(List<T>? Data, Dictionary<string, string>? Headers)> GetListAsync(string? query);
        Task PostAsync(EmployeeDto employee);
        Task DeleteAsync(int id);
    }
}
