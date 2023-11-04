using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using UPS.Assessment.App.Commands;
using UPS.Assessment.App.Services;
using UPS.Assessment.ApplicationService;

namespace UPS.Assessment.App.ViewModels
{
    public class EmployeeListViewModel : BaseViewModel
    {
        public EmployeeListViewModel(IEmployeeService employeeservice, NavigationService<NewEmployeeViewModel> newEmployeeNavigationService)
        {
            this._employees = new ObservableCollection<EmployeeViewModel>();
            NewEmployeeCommand = new NavigateCommand<NewEmployeeViewModel>(newEmployeeNavigationService);
            SearchEmployeeCommand = new RelayCommand((_) => LoadEmployees());
            DeleteEmployeeCommand = new RelayCommand((id) => DeleteEmployee((int?)id));
            ExportEmployeesCommand = new RelayCommand((_) => ExportEmployees());
            _employeeService = employeeservice;
            _searchQuery = "";
            LoadEmployees();
        }

        private async void LoadEmployees()
        {
            var employees = await _employeeService.GetAllAsync(_searchQuery);
            if (employees != null)
            {
                _employees.Clear();
                foreach (var employee in employees)
                {
                    _employees.Add(new EmployeeViewModel(employee));
                }
            }
        }
        private async void DeleteEmployee(int? id)
        {
            if (id == null)
            {
                return;
            }

            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this employee?", "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                await _employeeService.DeleteAsync(id.Value);
                LoadEmployees();
            }
        }

        private void ExportEmployees()
        {
            try
            {
                string filePath = GetSaveFilePath();

                if (!string.IsNullOrEmpty(filePath))
                {
                    CsvExporter.ExportToCsv(_employees, filePath);
                    MessageBox.Show("CSV export was successful. The data has been saved to the selected file.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("CSV export encountered an error. Please try again or check the selected file path.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private string GetSaveFilePath()
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                Title = "Export to CSV",
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                return saveFileDialog.FileName;
            }

            return null;
        }

        public static EmployeeListViewModel LoadViewModel(IEmployeeService employeeservice, NavigationService<NewEmployeeViewModel> newEmployeeNavigationService)
        {
            EmployeeListViewModel viewModel = new EmployeeListViewModel(employeeservice, newEmployeeNavigationService);
            return viewModel;
        }

        public ICommand NewEmployeeCommand { get; }
        public ICommand SearchEmployeeCommand { get; }
        public ICommand DeleteEmployeeCommand { get; }
        public ICommand ExportEmployeesCommand { get; }
        private readonly ObservableCollection<EmployeeViewModel> _employees;
        private readonly IEmployeeService _employeeService;

        public IEnumerable<EmployeeViewModel> Employees => _employees;

        private string _searchQuery;
        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                _searchQuery = value;
                OnPropertyChanged(nameof(SearchQuery));
            }
        }
    }
}
