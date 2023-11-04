using UPS.Assessment.Domain;

namespace UPS.Assessment.App.ViewModels
{
    public class EmployeeViewModel: BaseViewModel
    {
        private readonly Employee _employee;
        public EmployeeViewModel(Employee employee) => _employee = employee;

        public string Name => _employee.Name;
        public string Email => _employee.Email;
        public string Gender => _employee.Gender.ToString();
        public string Status => _employee.Status.ToString();
    }
}
