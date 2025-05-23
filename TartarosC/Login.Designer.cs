namespace TartarosC
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			tableLayoutPanel = new TableLayoutPanel();
			panelLogin = new Panel();
			labelServer = new Label();
			textBoxServerAddress = new TextBox();
			labelPassword = new Label();
			labelUsername = new Label();
			buttonLogin = new Button();
			textBoxPassword = new TextBox();
			textBoxUsername = new TextBox();
			panel1 = new Panel();
			tableLayoutPanel.SuspendLayout();
			panelLogin.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel
			// 
			tableLayoutPanel.BackColor = Color.FromArgb(32, 32, 32);
			tableLayoutPanel.ColumnCount = 3;
			tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
			tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
			tableLayoutPanel.Controls.Add(panelLogin, 1, 1);
			tableLayoutPanel.Controls.Add(panel1, 1, 0);
			tableLayoutPanel.Dock = DockStyle.Fill;
			tableLayoutPanel.Location = new Point(0, 0);
			tableLayoutPanel.Name = "tableLayoutPanel";
			tableLayoutPanel.RowCount = 3;
			tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
			tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel.Size = new Size(1898, 1024);
			tableLayoutPanel.TabIndex = 0;
			// 
			// panelLogin
			// 
			panelLogin.BackColor = Color.FromArgb(50, 50, 50);
			panelLogin.Controls.Add(labelServer);
			panelLogin.Controls.Add(textBoxServerAddress);
			panelLogin.Controls.Add(labelPassword);
			panelLogin.Controls.Add(labelUsername);
			panelLogin.Controls.Add(buttonLogin);
			panelLogin.Controls.Add(textBoxPassword);
			panelLogin.Controls.Add(textBoxUsername);
			panelLogin.Dock = DockStyle.Fill;
			panelLogin.Location = new Point(702, 287);
			panelLogin.Name = "panelLogin";
			panelLogin.Size = new Size(493, 449);
			panelLogin.TabIndex = 0;
			// 
			// labelServer
			// 
			labelServer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			labelServer.AutoSize = true;
			labelServer.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			labelServer.ForeColor = Color.White;
			labelServer.Location = new Point(43, 238);
			labelServer.Name = "labelServer";
			labelServer.Size = new Size(101, 38);
			labelServer.TabIndex = 9;
			labelServer.Text = "Server";
			labelServer.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// textBoxServerAddress
			// 
			textBoxServerAddress.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			textBoxServerAddress.BackColor = Color.FromArgb(70, 70, 70);
			textBoxServerAddress.BorderStyle = BorderStyle.None;
			textBoxServerAddress.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
			textBoxServerAddress.ForeColor = Color.White;
			textBoxServerAddress.Location = new Point(43, 279);
			textBoxServerAddress.Name = "textBoxServerAddress";
			textBoxServerAddress.Size = new Size(420, 38);
			textBoxServerAddress.TabIndex = 8;
			textBoxServerAddress.Text = "127.0.0.1";
			textBoxServerAddress.TextAlign = HorizontalAlignment.Center;
			// 
			// labelPassword
			// 
			labelPassword.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			labelPassword.AutoSize = true;
			labelPassword.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			labelPassword.ForeColor = Color.White;
			labelPassword.Location = new Point(43, 131);
			labelPassword.Name = "labelPassword";
			labelPassword.Size = new Size(139, 38);
			labelPassword.TabIndex = 7;
			labelPassword.Text = "Password";
			labelPassword.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// labelUsername
			// 
			labelUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			labelUsername.AutoSize = true;
			labelUsername.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			labelUsername.ForeColor = Color.White;
			labelUsername.Location = new Point(43, 13);
			labelUsername.Name = "labelUsername";
			labelUsername.Size = new Size(148, 38);
			labelUsername.TabIndex = 6;
			labelUsername.Text = "Username";
			labelUsername.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// buttonLogin
			// 
			buttonLogin.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			buttonLogin.BackColor = Color.FromArgb(70, 70, 70);
			buttonLogin.BackgroundImageLayout = ImageLayout.Zoom;
			buttonLogin.Cursor = Cursors.Hand;
			buttonLogin.FlatStyle = FlatStyle.Popup;
			buttonLogin.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
			buttonLogin.ForeColor = Color.White;
			buttonLogin.Location = new Point(43, 372);
			buttonLogin.Margin = new Padding(0);
			buttonLogin.Name = "buttonLogin";
			buttonLogin.Size = new Size(416, 58);
			buttonLogin.TabIndex = 5;
			buttonLogin.Text = "Login";
			buttonLogin.UseVisualStyleBackColor = false;
			buttonLogin.Click += buttonLogin_Click;
			// 
			// textBoxPassword
			// 
			textBoxPassword.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			textBoxPassword.BackColor = Color.FromArgb(70, 70, 70);
			textBoxPassword.BorderStyle = BorderStyle.None;
			textBoxPassword.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
			textBoxPassword.ForeColor = Color.White;
			textBoxPassword.Location = new Point(43, 172);
			textBoxPassword.Name = "textBoxPassword";
			textBoxPassword.PasswordChar = '*';
			textBoxPassword.Size = new Size(420, 38);
			textBoxPassword.TabIndex = 4;
			textBoxPassword.TextAlign = HorizontalAlignment.Center;
			// 
			// textBoxUsername
			// 
			textBoxUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			textBoxUsername.BackColor = Color.FromArgb(70, 70, 70);
			textBoxUsername.BorderStyle = BorderStyle.None;
			textBoxUsername.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
			textBoxUsername.ForeColor = Color.White;
			textBoxUsername.Location = new Point(43, 54);
			textBoxUsername.Name = "textBoxUsername";
			textBoxUsername.Size = new Size(420, 38);
			textBoxUsername.TabIndex = 3;
			textBoxUsername.TextAlign = HorizontalAlignment.Center;
			// 
			// panel1
			// 
			panel1.BackgroundImageLayout = ImageLayout.Center;
			panel1.Dock = DockStyle.Fill;
			panel1.Location = new Point(702, 3);
			panel1.Name = "panel1";
			panel1.Size = new Size(493, 278);
			panel1.TabIndex = 1;
			// 
			// Login
			// 
			AutoScaleDimensions = new SizeF(13F, 32F);
			AutoScaleMode = AutoScaleMode.Font;
			AutoSize = true;
			ClientSize = new Size(1898, 1024);
			Controls.Add(tableLayoutPanel);
			Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			Margin = new Padding(4);
			MinimumSize = new Size(1200, 1000);
			Name = "Login";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Tartaros - Login";
			FormClosed += Login_FormClosed;
			Load += Login_Load;
			tableLayoutPanel.ResumeLayout(false);
			panelLogin.ResumeLayout(false);
			panelLogin.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private TableLayoutPanel tableLayoutPanel;
		private Panel panelLogin;
		private Button buttonLogin;
		private TextBox textBoxPassword;
		private TextBox textBoxUsername;
		private Label labelUsername;
		private Label labelServer;
		private TextBox textBoxServerAddress;
		private Label labelPassword;
		private Panel panel1;
	}
}
