using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Lab1.Commands
{
    public class DelegateCommand : ICommand
    {
        private readonly Action _execute;

        private readonly Func<bool> _canExecute;

        public DelegateCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException("execute");

            if (canExecute != null)
            {
                this._canExecute = canExecute;
            }
        }

        public DelegateCommand(Action execute)
            : this(execute, null)
        {
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {

            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute.Invoke();
        }

        public virtual void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                _execute.Invoke();
            }
        }
    }
}
