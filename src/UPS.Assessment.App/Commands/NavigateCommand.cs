using UPS.Assessment.App.Services;
using UPS.Assessment.App.ViewModels;

namespace UPS.Assessment.App.Commands
{
    public class NavigateCommand<TViewModel> : BaseCommand where TViewModel : BaseViewModel
    {
        private readonly NavigationService<TViewModel> _navigationService;

        public NavigateCommand(NavigationService<TViewModel> navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            _navigationService.Navigate();
        }
    }
}
