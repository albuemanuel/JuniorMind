using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HttpServerUI_WPF
{
    public class HttpServerCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
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

        //private Action command;

        public delegate void Command();
        private Command command;
        public delegate bool Enabled();
        private Enabled canExecute;

        public HttpServerCommand(Command command, Enabled canExecute)
        {
            this.command = command;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute != null && canExecute();
        }

        public void Execute(object parameter)
        {
            command();
        }
    }
}
