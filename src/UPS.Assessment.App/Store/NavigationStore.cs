using System;
using UPS.Assessment.App.ViewModels;

namespace UPS.Assessment.App.Store
{
    public class NavigationStore
    {
        private BaseViewModel _currentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                CurrentViewModelChanged?.Invoke();
            }
        }
        public event Action CurrentViewModelChanged;
    }
}
