using SocketExample;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HttpServerUI
{
    public partial class ServerWindowForm : Form
    {
        HttpServer httpServer;
        Thread thread;

        delegate void ChangeTextBox();

        public ServerWindowForm()
        {
            InitializeComponent();
        }

        private void StartServerButton_Click(object sender, EventArgs e)
        {
            Int32.TryParse(PortBox.Text, out int port);

            if (httpServer == null || httpServer.ShouldStop)
            {
                ChangeButtonState(sender as Button);
                httpServer = new HttpServer(port, IPBox.Text, BaseURIBox.Text);
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

        private void HttpServer_ConsoleTextChanged(string text)
        {
            ChangeTextBox del = () => StatusBox.AppendText(text);

            Invoke(new Action(() =>
                StatusBox.AppendText(text)));
        }

        private void CreateServer()
        {

        }
        
        private void ChangeButtonState(Button button)
        {
            switch(button.Text)
            {
                case "Start Server":
                    button.Text = "Stop Server";
                    break;
                case "Stop Server":
                    button.Text = "Start Server";
                    break;
            }
        }

        private void IPBox_Click(object sender, EventArgs e)
        {
            EmptyBox(sender);
        }

        private void PortBox_Click(object sender, EventArgs e)
        {
            EmptyBox(sender);
        }

        private void BaseURIBox_Click(object sender, EventArgs e)
        {
            EmptyBox(sender);
        }

        private static void EmptyBox(object sender)
        {
            TextBox box = sender as TextBox;
            box.Text = string.Empty;
        }
    }
}
