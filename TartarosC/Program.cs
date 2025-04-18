using TLogger;

namespace TartarosC
{
	internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			Console.WriteLine("TLogger Version: " + Logger.VERSION);
			Logger.Info("Starting program");
			ApplicationConfiguration.Initialize();
			Application.Run(new Login());
		}
	}
}