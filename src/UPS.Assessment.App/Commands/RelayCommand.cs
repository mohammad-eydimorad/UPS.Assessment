using System;

namespace UPS.Assessment.App.Commands
{
    public class RelayCommand : BaseCommand
    {
        private readonly Action<object?> _executeAction;
        Func<object?, bool>? _canExecuteAction;

        public RelayCommand(Action<object?> executeAction)
        {
            this._executeAction = executeAction;
        }

        public RelayCommand(Action<object?> executeAction, Func<object?, bool>? canExecuteAction)
            : this(executeAction)
        {
            this._canExecuteAction = canExecuteAction;
        }

        public override bool CanExecute(object? parameter)
        {
            return _canExecuteAction != null ? _canExecuteAction(parameter) : base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            _executeAction(parameter);
        }
    }
}
