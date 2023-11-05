using UPS.Assessment.App.ViewModels;

namespace UPS.Assessment.App.Commands
{
    internal class SearchEmployeesCommand : BaseCommand<EmployeeListViewModel>
    {
        public SearchEmployeesCommand(EmployeeListViewModel viewModel)
            : base(viewModel)
        {
        }

        public override void Execute(object? parameter)
        {
            if (ViewModel.Pagination == null)
            {
                return;
            }

            ViewModel.Pagination.CurrentPage = 1;
            ViewModel.LoadEmployees();
        }
    }
}
