using System;
using System.Windows;
using UPS.Assessment.App.Services;
using UPS.Assessment.App.ViewModels;
using UPS.Assessment.Domain;

namespace UPS.Assessment.App.Commands
{
    public class NewEmployeeCommand : BaseCommand<NewEmployeeViewModel>
    {
        private readonly NavigationService _employeeListNavigationService;

        public NewEmployeeCommand(NewEmployeeViewModel newEmployee, NavigationService employeeListNavigationService):
            base(newEmployee)
        {
            this._employeeListNavigationService = employeeListNavigationService;
        }

        public override bool CanExecute(object? parameter)
        {
            try
            {
                 Employee.Create(this.ViewModel.Name, this.ViewModel.Email, Gender.Male, Status.Active);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override void Execute(object? parameter)
        {
            try
            {
                var employee = Employee.Create(this.ViewModel.Name, this.ViewModel.Email, Gender.Male, Status.Active);
                MessageBox.Show("Success! The new employee has been added.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                _employeeListNavigationService.Navigate();
            }
            catch (Exception)
            {
                MessageBox.Show("Error! Please complete all fields correctly.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
