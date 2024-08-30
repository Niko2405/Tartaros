using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Tartaros
{
	internal class ConfigHandler
	{
		/// <summary>
		/// Global JsonOptions
		/// </summary>
		public static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };

		// Directories
		public static readonly string DIR_ROOT = "tartaros/";
		public static readonly string DIR_DATABASE = DIR_ROOT + "data/";
		public static readonly string DIR_CONFIGS = DIR_ROOT + "config/";
		public static readonly string DIR_TEMP = DIR_ROOT + "tmp/";

		// Files
		public static readonly string CONFIG_FILE = DIR_CONFIGS + "config.json";

		// etc
		//public static readonly string CRYPT_PASSWORD = "Test123";
		public static readonly string DATAFILE_EXTENTION = ".dat";

		public static ConfigObject? currentConfig;

		/// <summary>
		/// Load config from file
		/// </summary>
		public static void Init()
		{
			if (!File.Exists(CONFIG_FILE))
			{
				try
				{
					File.WriteAllText(CONFIG_FILE, JsonSerializer.Serialize(new ConfigObject(), JsonOptions));
					Logger.PrintStatus("Create config at " + CONFIG_FILE, Logger.StatusCode.OK);
				}
				catch (UnauthorizedAccessException)
				{
					Logger.PrintStatus("No permission to create config file at " + CONFIG_FILE, Logger.StatusCode.FAILED);
					Environment.Exit(1);
				}
			}
			currentConfig = JsonSerializer.Deserialize<ConfigObject>(File.ReadAllText(CONFIG_FILE), JsonOptions);
			if (currentConfig == null)
			{
				Logger.PrintStatus("Reading config", Logger.StatusCode.FAILED);
				return;
			}
			Logger.PrintStatus("Reading config", Logger.StatusCode.OK);
		}

		/// <summary>
		/// Save current config
		/// </summary>
		public static void SaveConfig()
		{
			try
			{
				File.WriteAllText(CONFIG_FILE, JsonSerializer.Serialize(currentConfig, JsonOptions));
				Logger.PrintStatus("Config file saved at " + CONFIG_FILE, Logger.StatusCode.OK);
			}
			catch (UnauthorizedAccessException)
			{
				Logger.PrintStatus("No permission to create config file at " + CONFIG_FILE, Logger.StatusCode.FAILED);
				Environment.Exit(1);
			}
		}

		/// <summary>
		/// Primary Config Interface
		/// </summary>
		public class ConfigObject
		{
			public string ServerListenInterface { get; set; } = "127.0.0.1";
			public int ServerListenPort { get; set; } = 8080;

			public string SerialControlModulePortName { get; set; } = "COM1";
			public int SerialControlModuleBaudrate { get; set; } = 9600;
			public int SerialControlModuleStopBits { get; set; } = 1;
			public int SerialControlModuleDataBits { get; set; } = 8;
			public int SerialControlModuleReadTimeout { get; set; } = 500;
			public int SerialControlModuleWriteTimeout { get; set; } = 500;

			public string CryptKey { get; set; } = System.Environment.MachineName;
			public int CryptIterations { get; set; } = 25000;
			public string CryptSaltNew { get; set; } = "TestSalt";
		}
	}
}
