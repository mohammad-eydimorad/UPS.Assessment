using Microsoft.Win32;
using System.Windows;
using System;
using UPS.Assessment.App.ViewModels;

namespace UPS.Assessment.App.Commands
{
    internal class ExportEmployeesCommand : BaseCommand<EmployeeListViewModel>
    {
        public ExportEmployeesCommand(EmployeeListViewModel viewModel)
            : base(viewModel)
        {
        }

        public override void Execute(object? parameter)
        {
            try
            {
                string? filePath = GetSaveFilePath();

                if (!string.IsNullOrEmpty(filePath))
                {
                    CsvExporter.ExportToCsv(ViewModel.Employees, filePath);
                    MessageBox.Show("CSV export was successful. The data has been saved to the selected file.", "Success",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("CSV export encountered an error. Please try again or check the selected file path.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private static string? GetSaveFilePath()
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
    }
}
