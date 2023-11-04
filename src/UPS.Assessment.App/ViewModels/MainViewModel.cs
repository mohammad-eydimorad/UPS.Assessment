using System.Windows.Input;
using UPS.Assessment.App.Store;

namespace UPS.Assessment.App.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private readonly NavigationStore _navigationStore;
        public BaseViewModel CurrentViewModel  => _navigationStore.CurrentViewModel;
    }
}
