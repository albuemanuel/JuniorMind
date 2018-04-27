using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HttpServerUI_WPF
{
    public class HttpServerViewModel
    {
        Int32 port = 13000;
        string ipAddress = "127.0.0.1";

        public string IPAddress { get => ipAddress; set => ipAddress = value; }

        public Int32 Port { get => port; set => Port = value; }


        //HttpServer httpServer;
        //Thread thread;

        //delegate void ChangeStatusBoxText();

        //private void StartServer(object sender, RoutedEventArgs e)
        //{
        //    Int32.TryParse(PortBox.Text, out int port);

        //    if (httpServer == null || httpServer.ShouldStop)
        //    {
        //        ChangeButtonState(sender as Button);
        //        httpServer = new HttpServer(port, IPBox.Text, BaseURIComboBox.Text);
        //        httpServer.ConsoleTextChanged += HttpServer_ConsoleTextChanged;
        //        thread = new Thread(new ThreadStart(httpServer.StartHttpServer));
        //        thread.Start();
        //    }
        //    else
        //    {
        //        ChangeButtonState(sender as Button);
        //        httpServer.RequestStop();
        //        thread.Join(5000);
        //    }
        //}

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
