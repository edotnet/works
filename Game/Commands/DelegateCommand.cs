using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1.Commands
{

    class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }


        public Action<object> execute;

        public Func<object, bool> canExecute;

        public bool CanExecute(object parameter) => canExecute == null || canExecute(parameter);


        public DelegateCommand(Action<object> action, Func<object, bool> func = null)
        {
            execute = action;
            canExecute = func;
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
                execute(parameter);
        }
    }
}
