using System.Text.Json;
using TLogger;

namespace TartarosServer;

public class Init
{
	private static void CheckLogger()
	{
		Console.WriteLine($"TLogger Version: {Logger.Version}");
        Logger.Info("Info Message");
        Logger.Warn("Warning message");
        Logger.Error("Error message");
        Logger.Debug("Debug message");
	}
    
	private static void CheckFilesystem()
	{
		try
		{
			Directory.CreateDirectory(ConfigHandler.DIRECTORY_ROOT);
			Logger.Info($"Directory created: {ConfigHandler.DIRECTORY_ROOT}");
			
			Directory.CreateDirectory(ConfigHandler.DIRECTORY_CONFIGS);
			Logger.Info($"Directory created: {ConfigHandler.DIRECTORY_CONFIGS}");
			
			Directory.CreateDirectory(ConfigHandler.DIRECTORY_DATABASE);
			Logger.Info($"Directory created: {ConfigHandler.DIRECTORY_DATABASE}");
		}
		catch (Exception e)
		{
			Logger.Error(e.Message);
		}
	}

	private static void CheckConfigs()
	{
		ConfigHandler.Load();
	}
    
	public static void Start()
	{
		Logger.PrintHeader("Initializing");
		CheckLogger();
		CheckFilesystem();
		CheckConfigs();
	}
}