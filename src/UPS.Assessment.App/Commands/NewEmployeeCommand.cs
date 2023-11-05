using System;
using System.Windows;
using UPS.Assessment.App.Services;
using UPS.Assessment.App.ViewModels;
using UPS.Assessment.ApplicationService;
using UPS.Assessment.ApplicationService.DTO;

namespace UPS.Assessment.App.Commands
{
    public class NewEmployeeCommand : BaseCommand<NewEmployeeViewModel>
    {
        private readonly IEmployeeService _employeeService;
        private readonly NavigationService<EmployeeListViewModel> _employeeListNavigationService;
        

        public NewEmployeeCommand(
            NewEmployeeViewModel newEmployee,
            IEmployeeService employeeService,
            NavigationService<EmployeeListViewModel> employeeListNavigationService) :
            base(newEmployee)
        {
            _employeeService = employeeService;
            _employeeListNavigationService = employeeListNavigationService;
        }

        public override bool CanExecute(object? parameter)
        {
            try
            {
                CreateDtoFromViewModel();
                return !ViewModel.IsSaving;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async override void Execute(object? parameter)
        {
            try
            {
                ViewModel.IsSaving = true;
                var employee = CreateDtoFromViewModel();
                await _employeeService.AddAsync(employee);
                MessageBox.Show("Success! The new employee has been added.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                _employeeListNavigationService.Navigate();
            }
            catch (Exception)
            {
                MessageBox.Show("Error! Please complete all fields correctly.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                ViewModel.IsSaving = false;
            }
        }

        private EmployeeDto CreateDtoFromViewModel()
        {
            return new EmployeeDto(this.ViewModel.Name, this.ViewModel.Email, this.ViewModel.Gender.ToLower(), this.ViewModel.Status.ToLower());
        }
    }
}
