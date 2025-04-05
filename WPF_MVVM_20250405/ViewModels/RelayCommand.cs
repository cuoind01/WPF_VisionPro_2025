using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_MVVM_20250405.ViewModels
{
    public class RelayCommand<T> : ICommand
    {
        Action<T> _Execute;
        Predicate<T> _CanExecute;

        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            _Execute = execute;
            _CanExecute = canExecute;
        }

        event EventHandler ICommand.CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        bool ICommand.CanExecute(object parameter)
        {
            return _CanExecute==null?true: _CanExecute((T)parameter);
        }

        void ICommand.Execute(object parameter)
        {
            _Execute((T)parameter);
        }
    }
}
