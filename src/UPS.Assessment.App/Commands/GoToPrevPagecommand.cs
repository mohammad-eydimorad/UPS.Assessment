using UPS.Assessment.App.ViewModels;

namespace UPS.Assessment.App.Commands
{
    internal class GoToPrevPageCommand : BaseCommand<EmployeeListViewModel>
    {
        public GoToPrevPageCommand(EmployeeListViewModel viewModel)
            : base(viewModel)
        {
        }

        public override void Execute(object? parameter)
        {
            if (ViewModel.Pagination == null
                || ViewModel.Pagination.CurrentPage <= 1)
            {
                return;
            }
            ViewModel.Pagination.CurrentPage -= 1;
            ViewModel.LoadEmployees();
        }
    }
}
