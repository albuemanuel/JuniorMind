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
        public delegate void Command();
        public delegate bool Enabled();

        private Command command;
        private Enabled canExecute;

        public event EventHandler CanExecuteChanged;

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

        public void UpdateCanExecute()
        {
            CanExecuteChanged?.Invoke(this, null);
        }
    }
}
