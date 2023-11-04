using System;
using UPS.Assessment.App.Store;
using UPS.Assessment.App.ViewModels;

namespace UPS.Assessment.App.Services
{
    public class NavigationService<TViewModel> where TViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _viewModelFactory;
        public NavigationService(NavigationStore navigationStore, Func<TViewModel> viewModelFactory)
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
