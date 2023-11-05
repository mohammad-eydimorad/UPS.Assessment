using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using UPS.Assessment.App.Commands;
using UPS.Assessment.App.Services;
using UPS.Assessment.ApplicationService;

namespace UPS.Assessment.App.ViewModels
{
    public class NewEmployeeViewModel : BaseViewModel
    {
        public NewEmployeeViewModel(IEmployeeService employeeService, NavigationService<EmployeeListViewModel> employeeListNavigationService)
        {
            SaveEmployeeCommand = new NewEmployeeCommand(this, employeeService, employeeListNavigationService);
            CancelCommand = new NavigateCommand<EmployeeListViewModel>(employeeListNavigationService);
            _name = "";
            _email = "";
            _gender = ApplicationService.DTO.Gender.male.ToString().ToUpperFirstLetter();
            _status = ApplicationService.DTO.Status.active.ToString().ToUpperFirstLetter();

            _genders = new List<string>
            {
                ApplicationService.DTO.Gender.male.ToString().ToUpperFirstLetter(),
                ApplicationService.DTO.Gender.female.ToString().ToUpperFirstLetter()
            };

            _statuses = new List<string>
            {
              ApplicationService.DTO.Status.active.ToString().ToUpperFirstLetter(),
              ApplicationService.DTO.Status.inactive.ToString().ToUpperFirstLetter()
            };
        }

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

        private bool _isSaving;
        public bool IsSaving
        {
            get => _isSaving;
            set
            {
                _isSaving = value;
                OnPropertyChanged(nameof(IsSaving));
            }
        }

        private readonly IEnumerable<string> _statuses;
        public IReadOnlyList<string> Statuses => _statuses.ToList();

        public ICommand SaveEmployeeCommand { get; }
        public ICommand CancelCommand { get; }
    }
}
