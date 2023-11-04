using System;
using System.ComponentModel;
using System.Windows.Input;
using UPS.Assessment.App.ViewModels;

namespace UPS.Assessment.App.Commands
{
    public abstract class BaseCommand<TViewModel> : BaseCommand where TViewModel : BaseViewModel
    {
        public TViewModel ViewModel;

        protected BaseCommand(TViewModel viewModel)
        {
            ViewModel = viewModel;
            ViewModel.PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }
    }

    public abstract class BaseCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public virtual bool CanExecute(object? parameter)
        {
            return true;
        }

        public abstract void Execute(object? parameter);

        protected void OnCanExecuteChanged() => CanExecuteChanged?.Invoke(this, new EventArgs());
    }
}
