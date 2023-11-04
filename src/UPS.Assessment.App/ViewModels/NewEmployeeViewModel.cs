using System.Windows.Input;
using UPS.Assessment.App.Commands;
using UPS.Assessment.App.Services;

namespace UPS.Assessment.App.ViewModels
{
    public class NewEmployeeViewModel : BaseViewModel
    {
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public ICommand SaveEmployeeCommand {  get; }
        public ICommand CancelCommand {  get; }

        public NewEmployeeViewModel(NavigationService employeeListNavigationService)
        {
            SaveEmployeeCommand = new NewEmployeeCommand(this, employeeListNavigationService);
            CancelCommand = new NavigateCommand(employeeListNavigationService);
        }
    }
}
