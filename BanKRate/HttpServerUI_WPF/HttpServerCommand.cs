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
        public event EventHandler CanExecuteChanged;

        //private Action command;

        public delegate void Command();
        private Command command;

        public HttpServerCommand(Command command)
        {
            this.command = command;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            command();
        }
    }
}
