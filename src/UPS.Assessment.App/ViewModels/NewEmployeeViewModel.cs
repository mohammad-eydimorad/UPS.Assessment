using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using UPS.Assessment.App.Commands;
using UPS.Assessment.App.Services;
using UPS.Assessment.Domain;

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

        private string _gender;
        public string Gender
        {
            get => _gender;
            set
            {
                _gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }

        private readonly IEnumerable<string> _genders;
        public IReadOnlyList<string> Genders => _genders.ToList();

        private string _status;
        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        private readonly IEnumerable<string> _statuses;
        public IReadOnlyList<string> Statuses => _statuses.ToList();

        public ICommand SaveEmployeeCommand {  get; }
        public ICommand CancelCommand {  get; }

        public NewEmployeeViewModel(NavigationService employeeListNavigationService)
        {
            SaveEmployeeCommand = new NewEmployeeCommand(this, employeeListNavigationService);
            CancelCommand = new NavigateCommand(employeeListNavigationService);
            _gender = Domain.Gender.Male.ToString();
            _status = Domain.Status.Active.ToString();
            
            _genders = new List<string>
            {
                "Male",
                "Female"
            };

            _statuses = new List<string>
            {
                "Active",
                "Inactive"
            };
        }
    }
}
