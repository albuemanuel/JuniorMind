namespace HttpServerUI
{
    partial class ServerWindowForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.IPBox = new System.Windows.Forms.TextBox();
            this.PortBox = new System.Windows.Forms.TextBox();
            this.BaseURIBox = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(301, 206);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start Server";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.StartServerButton_Click);
            // 
            // IPBox
            // 
            this.IPBox.Location = new System.Drawing.Point(91, 105);
            this.IPBox.Name = "IPBox";
            this.IPBox.Size = new System.Drawing.Size(100, 20);
            this.IPBox.TabIndex = 1;
            this.IPBox.Text = "127.0.0.1";
            this.IPBox.Click += new System.EventHandler(this.IPBox_Click);
            // 
            // PortBox
            // 
            this.PortBox.Location = new System.Drawing.Point(468, 105);
            this.PortBox.Name = "PortBox";
            this.PortBox.Size = new System.Drawing.Size(100, 20);
            this.PortBox.TabIndex = 2;
            this.PortBox.Text = "13000";
            this.PortBox.Click += new System.EventHandler(this.PortBox_Click);
            // 
            // BaseURIBox
            // 
            this.BaseURIBox.Location = new System.Drawing.Point(82, 159);
            this.BaseURIBox.Multiline = true;
            this.BaseURIBox.Name = "BaseURIBox";
            this.BaseURIBox.Size = new System.Drawing.Size(495, 20);
            this.BaseURIBox.TabIndex = 3;
            this.BaseURIBox.Text = "C:\\Users\\albue.DESKTOP-7NLSNIJ\\Desktop\\JM\\JuniorMind\\BanKRate\\SocketExample\\SiteF" +
    "older";
            this.BaseURIBox.Click += new System.EventHandler(this.BaseURIBox_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(91, 289);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(477, 280);
            this.textBox4.TabIndex = 4;
            // 
            // ServerWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 628);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.BaseURIBox);
            this.Controls.Add(this.PortBox);
            this.Controls.Add(this.IPBox);
            this.Controls.Add(this.button1);
            this.Name = "ServerWindowForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox IPBox;
        private System.Windows.Forms.TextBox PortBox;
        private System.Windows.Forms.TextBox BaseURIBox;
        private System.Windows.Forms.TextBox textBox4;
    }
}

