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
            this.IPBox = new System.Windows.Forms.TextBox();
            this.PortBox = new System.Windows.Forms.TextBox();
            this.BaseURIBox = new System.Windows.Forms.TextBox();
            this.StatusBox = new System.Windows.Forms.TextBox();
            this.StartServerButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // IPBox
            // 
            this.IPBox.Location = new System.Drawing.Point(23, 50);
            this.IPBox.Name = "IPBox";
            this.IPBox.Size = new System.Drawing.Size(100, 20);
            this.IPBox.TabIndex = 1;
            this.IPBox.Text = "127.0.0.1";
            this.IPBox.Click += new System.EventHandler(this.IPBox_Click);
            // 
            // PortBox
            // 
            this.PortBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PortBox.Location = new System.Drawing.Point(592, 51);
            this.PortBox.Name = "PortBox";
            this.PortBox.Size = new System.Drawing.Size(100, 20);
            this.PortBox.TabIndex = 2;
            this.PortBox.Text = "13000";
            this.PortBox.Click += new System.EventHandler(this.PortBox_Click);
            // 
            // BaseURIBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.BaseURIBox, 2);
            this.BaseURIBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaseURIBox.Location = new System.Drawing.Point(23, 23);
            this.BaseURIBox.Multiline = true;
            this.BaseURIBox.Name = "BaseURIBox";
            this.BaseURIBox.Size = new System.Drawing.Size(669, 21);
            this.BaseURIBox.TabIndex = 3;
            this.BaseURIBox.Text = "C:\\Users\\dev\\Desktop\\JuniorMind\\BanKRate\\SocketExample\\SiteFolder";
            this.BaseURIBox.Click += new System.EventHandler(this.BaseURIBox_Click);
            // 
            // StatusBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.StatusBox, 2);
            this.StatusBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatusBox.Location = new System.Drawing.Point(23, 131);
            this.StatusBox.Multiline = true;
            this.StatusBox.Name = "StatusBox";
            this.StatusBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.StatusBox.Size = new System.Drawing.Size(669, 474);
            this.StatusBox.TabIndex = 4;
            // 
            // StartServerButton
            // 
            this.StartServerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tableLayoutPanel1.SetColumnSpan(this.StartServerButton, 2);
            this.StartServerButton.Location = new System.Drawing.Point(164, 77);
            this.StartServerButton.Name = "StartServerButton";
            this.StartServerButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartServerButton.Size = new System.Drawing.Size(386, 48);
            this.StartServerButton.TabIndex = 0;
            this.StartServerButton.Text = "Start Server";
            this.StartServerButton.UseVisualStyleBackColor = true;
            this.StartServerButton.Click += new System.EventHandler(this.StartServerButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.StatusBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.PortBox, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.BaseURIBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.StartServerButton, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.IPBox, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(716, 628);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ServerWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 628);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ServerWindowForm";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox IPBox;
        private System.Windows.Forms.TextBox PortBox;
        private System.Windows.Forms.TextBox BaseURIBox;
        private System.Windows.Forms.TextBox StatusBox;
        private System.Windows.Forms.Button StartServerButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

