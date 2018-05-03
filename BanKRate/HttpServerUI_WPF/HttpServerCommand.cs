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

        private Action command;

        public HttpServerCommand(Action command)
        {
            this.command = command;
        }

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            command();
        }
    }
}
