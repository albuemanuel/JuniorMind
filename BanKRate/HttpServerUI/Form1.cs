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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void StartServerButton_Click(object sender, EventArgs e)
        {

            HttpServer httpServer = new HttpServer();
            Thread thread = new Thread(httpServer.StartHttpServer);

            thread.Start();

        }

        private void IPBox_Click(object sender, EventArgs e)
        {
            EmptyBox(sender);
        }

        private void PortBox_Click(object sender, EventArgs e)
        {
            EmptyBox(sender);
        }

        private void BaseURIBox3_Click(object sender, EventArgs e)
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
