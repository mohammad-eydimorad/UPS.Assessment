using UPS.Assessment.App.ViewModels;

namespace UPS.Assessment.App.Commands
{
    internal class GoToNextPageCommand : BaseCommand<EmployeeListViewModel>
    {
        public GoToNextPageCommand(EmployeeListViewModel viewModel)
            : base(viewModel)
        {
        }

        public override void Execute(object? parameter)
        {
            if (ViewModel.Pagination == null
                || ViewModel.Pagination.CurrentPage >= ViewModel.Pagination.TotalPages)
            {
                return;
            }
            ViewModel.Pagination.CurrentPage += 1;
            ViewModel.LoadEmployees();
        }
    }
}
