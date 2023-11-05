using System;

namespace UPS.Assessment.App.Commands
{
    public class RelayCommand : BaseCommand
    {
        private readonly Action<object?> _action;

        public RelayCommand(Action<object?> action)
        {
            this._action = action;
        }

        public override void Execute(object? parameter)
        {
           _action(parameter);
        }
    }
}
