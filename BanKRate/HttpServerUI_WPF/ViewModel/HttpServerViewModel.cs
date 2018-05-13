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
            "C:\\JuniorMind\\BanKRate\\SocketExample\\SiteFolder",
            "C:\\Users\\dev\\Desktop\\JuniorMind\\BanKRate\\SocketExample\\SiteFolder",
            "C:\\Users\\albue.DESKTOP-7NLSNIJ\\Desktop\\JM\\JuniorMind\\BanKRate\\SocketExample\\SiteFolder",
            "C:\\Users\\Emanuel\\Desktop\\Code\\JuniorMind\\BanKRate\\SocketExample\\SiteFolder",
            "C:\\Users\\Elix\\Desktop\\JM\\JuniorMind\\BanKRate\\SocketExample\\SiteFolder"
        };
        private HttpServerCommand startServer;
        private HttpServerCommand stopServer;
        HttpServer httpServer;
        Task task;


        public HttpServerViewModel()
        {
            startServer = new HttpServerCommand(ServerStart, () => httpServer==null);
            stopServer = new HttpServerCommand(ServerStop, () => httpServer!=null);
        }

        public string IPAddress { get => ipAddress; set => ipAddress = value; }
        public Int32 Port { get => port; set => port = value; }
        public ObservableCollection<string> Status { get => status; set => status = value; }
        public string SelectedURI { get; set; }

        public string[] UriList => uriList;
        public ICommand StartServer => startServer;
        public ICommand StopServer => stopServer;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (httpServer != null)
                httpServer.RequestStop();
        }

        private void ServerStart()
        {
            httpServer = new HttpServer(port, ipAddress, SelectedURI);
            httpServer.ConsoleTextChanged += HttpServer_ConsoleTextChanged;
            task = new Task(httpServer.RunServerAsync);
            task.Start();
            ToggleCanExecute();
        }

        private void ToggleCanExecute()
        {
            startServer.UpdateCanExecute();
            stopServer.UpdateCanExecute();
        }

        private void ServerStop()
        {
            httpServer.RequestStop();
            //task.Join(5000);
            httpServer = null;
            ToggleCanExecute();
        }

        private void HttpServer_ConsoleTextChanged(string text)
        {
            Action action = new Action(() => Status.Add(text));
            Application.Current.Dispatcher.Invoke(action);
        }

        
    }
}
