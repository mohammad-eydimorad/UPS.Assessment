using System.Collections.Generic;
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
        }

        public ICommand SaveEmployeeCommand { get; }
        public ICommand CancelCommand { get; }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public string Gender
        {
            get => _gender;
            set
            {
                _gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }
        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }
        public bool IsSaving
        {
            get => _isSaving;
            set
            {
                _isSaving = value;
                OnPropertyChanged(nameof(IsSaving));
            }
        }
        public IReadOnlyList<string> Genders => new List<string>
            {
                ApplicationService.DTO.Gender.male.ToString().ToUpperFirstLetter(),
                ApplicationService.DTO.Gender.female.ToString().ToUpperFirstLetter()
            };
        public IReadOnlyList<string> Statuses => new List<string>
            {
              ApplicationService.DTO.Status.active.ToString().ToUpperFirstLetter(),
              ApplicationService.DTO.Status.inactive.ToString().ToUpperFirstLetter()
            };

        private string _name = "";
        private string _email = "";
        private string _gender = ApplicationService.DTO.Gender.male.ToString().ToUpperFirstLetter();
        private string _status = ApplicationService.DTO.Status.active.ToString().ToUpperFirstLetter();
        private bool _isSaving;
    }
}
