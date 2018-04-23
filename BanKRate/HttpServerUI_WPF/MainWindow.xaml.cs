using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HttpServerUI_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HttpServer httpServer;
        Thread thread;

        delegate void ChangeStatusBoxText();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Int32.TryParse(PortBox.Text, out int port);

            if (httpServer == null || httpServer.ShouldStop)
            {
                ChangeButtonState(sender as Button);
                httpServer = new HttpServer(port, IPBox.Text, BaseURIComboBox.Text);
                httpServer.ConsoleTextChanged += HttpServer_ConsoleTextChanged;
                thread = new Thread(new ThreadStart(httpServer.StartHttpServer));
                thread.Start();
            }
            else
            {
                ChangeButtonState(sender as Button);
                httpServer.RequestStop();
                //thread.Join(5000);
            }
        }

        private void ChangeButtonState(Button button)
        {
            switch (button.Content)
            {
                case "Start":
                    button.Content = "Stop";
                    break;
                case "Stop":
                    button.Content = "Start";
                    break;
            }
        }

        private void HttpServer_ConsoleTextChanged(string text)
        {
            ChangeStatusBoxText del = delegate ()
            {
                if (!string.IsNullOrWhiteSpace( StatusBox.Text))
                    StatusBox.AppendText("\r\n" + text);
                else
                    StatusBox.AppendText(text);
            };
            Dispatcher.Invoke(del);
        }

        private void ServerWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(httpServer != null)
                httpServer.RequestStop();
        }
    }
}
