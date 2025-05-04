using System.Text.Json;
using TLogger;

namespace TartarosServer;

public class ConfigHandler
{
	public static Serial? serialConfig;
	public static Network? networkConfig;
	
	public static readonly string DIRECTORY_ROOT = "server/";
	public static readonly string DIRECTORY_DATABASE = DIRECTORY_ROOT + "database/";
	public static readonly string DIRECTORY_CONFIGS = DIRECTORY_ROOT +  "configs/";
	
	public static readonly string FILE_CONFIG_SERIAL = DIRECTORY_CONFIGS + "serial.conf";
	public static readonly string FILE_CONFIG_NETWORK = DIRECTORY_CONFIGS + "network.conf";
	public static readonly string FILE_CONFIG_DATABASE = DIRECTORY_CONFIGS + "database.conf";
	
	private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };
	
	private static void CreateConfig()
	{
		try
		{
			File.WriteAllTextAsync(FILE_CONFIG_SERIAL, JsonSerializer.Serialize(new Serial(), JsonOptions));
			File.WriteAllTextAsync(FILE_CONFIG_NETWORK, JsonSerializer.Serialize(new Network(), JsonOptions));
			//File.WriteAllTextAsync(FILE_CONFIG_DATABASE, JsonSerializer.Serialize(new Database(), JsonOptions));
		}
		catch (Exception e)
		{
			Logger.Error($"Failed to create config: {e.Message}");
		}
	}
	public static void Load()
	{
		if (!File.Exists(FILE_CONFIG_SERIAL) || !File.Exists(FILE_CONFIG_NETWORK))
		{
			CreateConfig();
		}

		try
		{
			serialConfig = JsonSerializer.Deserialize<Serial>(File.ReadAllText(FILE_CONFIG_SERIAL), JsonOptions);
			networkConfig = JsonSerializer.Deserialize<Network>(File.ReadAllText(FILE_CONFIG_NETWORK), JsonOptions);
		}
		catch (Exception e)
		{
			Logger.Error(e.Message);
		}
	}
}
