using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HttpServerUI_WPF
{
    public class HttpServerViewModel
    {
        Int32 port = 13000;
        string ipAddress = "127.0.0.1";
        string[] status;
        string[] uriList =
        {
            "C:\\Users\\dev\\Desktop\\JuniorMind\\BanKRate\\SocketExample\\SiteFolder",
            "C:\\Users\\albue.DESKTOP-7NLSNIJ\\Desktop\\JM\\JuniorMind\\BanKRate\\SocketExample\\SiteFolder",
            "C:\\Users\\Emanuel\\Desktop\\Code\\JuniorMind\\BanKRate\\SocketExample\\SiteFolder"
        };
        private ICommand startServer;
        public string IPAddress { get => ipAddress; set => ipAddress = value; }
        public Int32 Port { get => port; set => Port = value; }
        public string[] Status { get => status; set => status = value; }
        public string[] UriList => uriList;

        public string StartButtonContent => "Start";
        public ICommand StartServer => startServer;

        public HttpServerViewModel()
        {
            startServer = new HttpServerCommand(ServerStart);
        }

        HttpServer httpServer;
        Thread thread;

        //delegate void ChangeStatusBoxText();

        private void ServerStart()
        {

            if (httpServer == null || httpServer.ShouldStop)
            {
                //ChangeButtonState(sender as Button);
                httpServer = new HttpServer(port, ipAddress, uriList[1]);
                //httpServer.ConsoleTextChanged += HttpServer_ConsoleTextChanged;
                thread = new Thread(new ThreadStart(httpServer.StartHttpServer));
                thread.Start();
            }
            else
            {
                //ChangeButtonState(sender as Button);
                httpServer.RequestStop();
                thread.Join(5000);
            }
        }

        //private void ChangeButtonState(Button button)
        //{
        //    switch (button.Content)
        //    {
        //        case "Start":
        //            button.Content = "Stop";
        //            break;
        //        case "Stop":
        //            button.Content = "Start";
        //            break;
        //    }
        //}

        //private void HttpServer_ConsoleTextChanged(string text)
        //{
        //    ChangeStatusBoxText del = delegate ()
        //    {
        //        if (!string.IsNullOrWhiteSpace(StatusBox.Text))
        //            StatusBox.AppendText("\r\n" + text);
        //        else
        //            StatusBox.AppendText(text);
        //    };
        //    Dispatcher.Invoke(del);
        //}

        //private void ServerWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        //{
        //    if (httpServer != null)
        //        httpServer.RequestStop();
        //}
    }
}
