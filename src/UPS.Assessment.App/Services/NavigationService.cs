using System;
using UPS.Assessment.App.Store;
using UPS.Assessment.App.ViewModels;

namespace UPS.Assessment.App.Services
{
    public class NavigationService
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<BaseViewModel> _viewModelFactory;
        public NavigationService(NavigationStore navigationStore, Func<BaseViewModel> viewModelFactory)
        {
            _navigationStore = navigationStore;
            _viewModelFactory = viewModelFactory;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _viewModelFactory();
        }
    }
}
