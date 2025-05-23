using System.Diagnostics;
using TLogger;

namespace TartarosC
{
	public partial class Login : Form
	{
		private Size formOriginalSize;

		private Rectangle boundsTextBoxUsername;
		private Rectangle boundsTextBoxPassword;
		private Rectangle boundsTextBoxServerAddress;

		private Rectangle boundsLabelUsername;
		private Rectangle boundsLabelPassword;
		private Rectangle boundsLabelServer;

		private Rectangle boundsButtonLogin;

		public Login()
		{
			InitializeComponent();
			this.Resize += Login_Resize;
			formOriginalSize = this.Size;

			boundsTextBoxUsername = new Rectangle(textBoxUsername.Location, textBoxUsername.Size);
			boundsTextBoxPassword = new Rectangle(textBoxPassword.Location, textBoxPassword.Size);
			boundsTextBoxServerAddress = new Rectangle(textBoxServerAddress.Location, textBoxServerAddress.Size);

			boundsLabelUsername = new Rectangle(labelUsername.Location, labelUsername.Size);
			boundsLabelPassword = new Rectangle(labelPassword.Location, labelPassword.Size);
			boundsLabelServer = new Rectangle(labelServer.Location, labelServer.Size);

			boundsButtonLogin = new Rectangle(buttonLogin.Location, buttonLogin.Size);
		}

		private void Login_Resize(object? sender, EventArgs e)
		{
			ResizeControl(textBoxUsername, boundsTextBoxUsername);
			ResizeControl(textBoxPassword, boundsTextBoxPassword);
			ResizeControl(textBoxServerAddress, boundsTextBoxServerAddress);

			ResizeControl(labelUsername, boundsLabelUsername);
			ResizeControl(labelPassword, boundsLabelPassword);
			ResizeControl(labelServer, boundsLabelServer);

			ResizeControl(buttonLogin, boundsButtonLogin);
		}

		private void ResizeControl(Control control, Rectangle bounds)
		{
			float xRatio = (float)(this.Width) / (float)(formOriginalSize.Width);
			float yRatio = (float)(this.Height) / (float)(formOriginalSize.Height);
			int newX = (int)(bounds.X * xRatio);
			int newY = (int)(bounds.Y * yRatio);

			int newWidth = (int)(bounds.Width * xRatio);
			int newHeigth = (int)(bounds.Height * yRatio);

			control.Location = new Point(newX, newY);
			control.Size = new Size(newWidth, newHeigth);

			Debug.WriteLine("========= RESIZED =========");
			Debug.WriteLine($"Set {control.GetType().Name} to location [X:{newX} | Y:{newY}]");
			Debug.WriteLine($"Set {control.GetType().Name} to size [Width:{newWidth} | Heigth:{newHeigth}]");
		}

		private void buttonLogin_Click(object sender, EventArgs e)
		{
			string username = (string)textBoxUsername.Text;
			string password = (string)textBoxPassword.Text;
			string serverAddress = (string)textBoxServerAddress.Text;

			if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(serverAddress))
			{
				Logger.Warn("Input incorrect");
				return;
			}
			ClientSocket.Username = username;
			ClientSocket.Password = password;
			ClientSocket.ServerAddress = serverAddress;
			this.Hide();
			new MainForm().Show();
		}

		private void Login_Load(object sender, EventArgs e)
		{
			this.TopMost = true;
		}

		private void Login_FormClosed(object sender, FormClosedEventArgs e)
		{
			Environment.Exit(0);
		}
	}
}
