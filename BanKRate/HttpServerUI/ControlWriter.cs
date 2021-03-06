﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HttpServerUI
{
    public class ControlWriter : TextWriter
    {
        private Control textbox;

        public ControlWriter(Control textbox)
        {
            this.textbox = textbox;
        }

        public override void Write(string value)
        {
            textbox.Text += value;
        }

        public override void WriteLine(string value)
        {
            textbox.Text += value;
        }

        
        public override Encoding Encoding => Encoding.ASCII;
    }
}
