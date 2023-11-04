using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using UPS.Assessment.App.Commands;
using UPS.Assessment.App.Services;
using UPS.Assessment.Domain;

namespace UPS.Assessment.App.ViewModels
{
    public class EmployeeListViewModel : BaseViewModel
    {
        public EmployeeListViewModel(NavigationService navigationService)
        {
            this._employees = new ObservableCollection<EmployeeViewModel>();
            _employees.Add(new EmployeeViewModel(Employee.Create("Mohammad", "m.eidimorad@gmail.com", Gender.Male, Status.Active)));
            _employees.Add(new EmployeeViewModel(Employee.Create("John", "john@gmail.com", Gender.Male, Status.Active)));

            NewEmployeeCommand = new NavigateCommand(navigationService);
        }
        public ICommand NewEmployeeCommand { get; }
        private readonly ObservableCollection<EmployeeViewModel> _employees;
        public IEnumerable<EmployeeViewModel> Employees => _employees;
    }
}
