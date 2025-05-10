using System.Text.Json;
using System.Data.SQLite;
using TLogger;

namespace TartarosServer;

class Program
{
	static void Main(string[] args)
	{
		Logger.PrintHeader("Program starting");
		Logger.Info("Reading arguments...");
        
		foreach (string arg in args)
		{
			if (arg == "--debug")
			{
				Logger.DebugEnabled = true;
				Logger.Debug("Debug is enabled");
			}
		}
		Init.Start();
	}
}
