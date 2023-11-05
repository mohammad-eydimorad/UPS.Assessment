using UPS.Assessment.ApplicationService.DTO;

namespace UPS.Assessment.App.ViewModels
{
    public class EmployeeViewModel: BaseViewModel
    {
        private readonly EmployeeDto _employee;
        public EmployeeViewModel(EmployeeDto employee) => _employee = employee;

        public int Id => _employee.Id;
        public string Name => _employee.Name;
        public string Email => _employee.Email;
        public string Gender => _employee.Gender.ToUpperFirstLetter();
        public string Status => _employee.Status.ToUpperFirstLetter();
    }
}
