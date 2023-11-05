using System.Windows;
using UPS.Assessment.App.ViewModels;
using UPS.Assessment.ApplicationService;

namespace UPS.Assessment.App.Commands
{
    internal class DeleteEmployeesCommand : BaseCommand<EmployeeListViewModel>
    {
        private readonly IEmployeeService _employeeService;

        public DeleteEmployeesCommand(IEmployeeService employeeService, EmployeeListViewModel viewModel)
            : base(viewModel)
        {
            this._employeeService = employeeService;
        }

        public async override void Execute(object? parameter)
        {
            if (parameter == null)
            {
                return;
            }
            int.TryParse(parameter.ToString(), out int id);

            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this employee?", "Confirm Deletion",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                await _employeeService.DeleteAsync(id);
                ViewModel.LoadEmployees();
            }
        }
    }
}
