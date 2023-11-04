using System.Windows;
using UPS.Assessment.App.Services;
using UPS.Assessment.App.Store;
using UPS.Assessment.App.ViewModels;

namespace UPS.Assessment.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        //private readonly NavigationService _navigationService;

        public App()
        {
            _navigationStore = new NavigationStore();
            
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var employeeListViewModel = EmployeeListViewModelFactory();
            _navigationStore.CurrentViewModel = employeeListViewModel;

            MainWindow = new MainWindow
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }

        private EmployeeListViewModel EmployeeListViewModelFactory()
        {
            var _navigationService = new NavigationService(_navigationStore, NewEmployeeViewModelFactory);
            return new EmployeeListViewModel(_navigationService);

        }

        private NewEmployeeViewModel NewEmployeeViewModelFactory()
        {
            return new NewEmployeeViewModel(new NavigationService(_navigationStore, EmployeeListViewModelFactory));
        }

    }
}
