using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using UPS.Assessment.App.Commands;
using UPS.Assessment.App.Services;
using UPS.Assessment.ApplicationService;

namespace UPS.Assessment.App.ViewModels
{
    public class EmployeeListViewModel : BaseViewModel
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeListViewModel(
            IEmployeeService employeeservice,
            NavigationService<NewEmployeeViewModel> newEmployeeNavigationService
            )
        {
            _employeeService = employeeservice;
            NavigateToNewEmployeeCommand = new NavigateCommand<NewEmployeeViewModel>(newEmployeeNavigationService);
            SearchEmployeeCommand = new SearchEmployeesCommand(this);
            DeleteEmployeeCommand = new DeleteEmployeesCommand(employeeservice, this);
            ExportEmployeesCommand = new ExportEmployeesCommand(this);
            NextPageCommand = new GoToNextPageCommand(this);
            PrevPageCommand = new GoToPrevPageCommand(this);
            LoadEmployees();
        }
        public ICommand NavigateToNewEmployeeCommand { get; }
        public ICommand SearchEmployeeCommand { get; }
        public ICommand DeleteEmployeeCommand { get; }
        public ICommand ExportEmployeesCommand { get; }
        public ICommand NextPageCommand { get; }
        public ICommand PrevPageCommand { get; }

        public IEnumerable<EmployeeViewModel> Employees => _employees;
        public PaginationViewModel? Pagination
        {
            get => _pagination; set
            {
                _pagination = value;
                if (value != null)
                {
                    PaginationDescription = $"Page {value.CurrentPage} of {value.TotalPages} pages";
                }
                OnPropertyChanged(nameof(Pagination));
            }
        }
        public string? PaginationDescription
        {
            get => _paginationDescription;
            set
            {
                _paginationDescription = value;
                OnPropertyChanged(nameof(PaginationDescription));
            }
        }
        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                _searchQuery = value;
                OnPropertyChanged(nameof(SearchQuery));
            }
        }
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        public async void LoadEmployees()
        {
            try
            {
                IsLoading = true;
                var employeePaginatedList = await _employeeService.GetAllAsync(_searchQuery, Pagination?.CurrentPage);
                if (employeePaginatedList == null)
                {
                    DisplayLoadingErrorMessage();
                    return;
                }
                _employees.Clear();
                foreach (var employee in employeePaginatedList.Employees)
                {
                    _employees.Add(new EmployeeViewModel(employee));
                }
                Pagination = new PaginationViewModel(employeePaginatedList.PaginationData);
            }
            catch (Exception)
            {
                DisplayLoadingErrorMessage();
            }
            finally
            {
                IsLoading = false;
            }
        }

        public static EmployeeListViewModel LoadViewModel(IEmployeeService employeeservice, 
            NavigationService<NewEmployeeViewModel> newEmployeeNavigationService)
        {
            EmployeeListViewModel viewModel = new(employeeservice, newEmployeeNavigationService);
            return viewModel;
        }

        private static void DisplayLoadingErrorMessage()
        {
            MessageBox.Show("An error occurred while loading employees." +
                   "\n Please check your connection and try again.", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private readonly ObservableCollection<EmployeeViewModel> _employees = new();
        private string _searchQuery = "";
        private PaginationViewModel? _pagination = null;
        private string? _paginationDescription;
        private bool _isLoading = true;
    }
}
