using TLogger;

namespace Tartaros
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine($"TLogger Version: {Logger.VERSION}");
			Init.Start();
			Thread.Sleep(2500);
			foreach (var arg in args)
			{
				if (arg == "--client")
				{
					Console.Title = "Tartaros - Client";
					Client.Active = true;
					Server.Active = false;
				}
				if (arg == "--server")
				{
					Console.Title = "Tartaros - Server";
					Client.Active = false;
					Server.Active = true;
				}
			}
			if (Server.Active)
			{
				// TODO: start service
				// TODO: Connect to hardware COM
				// TODO: start cli
				Server.RunCommandLine();
			}
			if (Client.Active)
			{
				// TODO: login to server
			}
		}
	}
}
