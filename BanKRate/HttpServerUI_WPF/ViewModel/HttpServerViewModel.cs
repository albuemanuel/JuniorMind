using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace HttpServerUI_WPF
{
    public class HttpServerViewModel : INotifyPropertyChanged
    {
        Int32 port = 13000;
        string ipAddress = "127.0.0.1";
        ObservableCollection<string> status = new ObservableCollection<string>();
        string[] uriList =
        {
            "C:\\Users\\dev\\Desktop\\JuniorMind\\BanKRate\\SocketExample\\SiteFolder",
            "C:\\Users\\albue.DESKTOP-7NLSNIJ\\Desktop\\JM\\JuniorMind\\BanKRate\\SocketExample\\SiteFolder",
            "C:\\Users\\Emanuel\\Desktop\\Code\\JuniorMind\\BanKRate\\SocketExample\\SiteFolder"
        };
        private ICommand startServer;

        private string startButtonContent = "Start";

        public string IPAddress { get => ipAddress; set => ipAddress = value; }
        public Int32 Port { get => port; set => Port = value; }
        public ObservableCollection<string> Status { get => status; set => status = value; }
        
        public string[] UriList => uriList;

        
        public string StartButtonContent { get => startButtonContent; set
            {
                startButtonContent = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StartButtonContent)));
            }
        }
        

        public ICommand StartServer => startServer;

        public HttpServerViewModel()
        {
            startServer = new HttpServerCommand(ServerStart);
        }

        HttpServer httpServer;
        Thread thread;

        public event PropertyChangedEventHandler PropertyChanged;

        private void ServerStart()
        {
            ToggleStartButton();

            if (httpServer == null || httpServer.ShouldStop)
            {
                
                httpServer = new HttpServer(port, ipAddress, uriList[1]);
                httpServer.ConsoleTextChanged += HttpServer_ConsoleTextChanged;
                thread = new Thread(new ThreadStart(httpServer.StartHttpServer));
                thread.Start();
            }
            else
            {
                httpServer.RequestStop();
                thread.Join(5000);
            }
        }

        private void ToggleStartButton()
        {
            switch (StartButtonContent)
            {
                case "Start":
                    StartButtonContent = "Stop";

                    break;
                case "Stop":
                    StartButtonContent = "Start";
                    break;
            }
            
        }

        private void HttpServer_ConsoleTextChanged(string text)
        {
            //ChangeStatusBoxText del = delegate ()
            //{ 
            //    if (!string.IsNullOrWhiteSpace(StatusBox.Text))
            //        StatusBox.AppendText("\r\n" + text);
            //    else
            //        StatusBox.AppendText(text);
            //};
            //Dispatcher.Invoke(del);

            Action action = new Action(() => Status.Add(text));
            Application.Current.Dispatcher.Invoke(action);
        }

        public void OnWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (httpServer != null)
                httpServer.RequestStop();
        }
    }
}
