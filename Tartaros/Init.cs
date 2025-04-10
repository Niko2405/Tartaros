using SerialPower;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TLogger;

namespace Tartaros
{
	internal class Init
	{
		private static void CheckFilesystem()
		{
			try
			{
				Directory.CreateDirectory(ConfigHandler.DIR_ROOT);
				Logger.Info("Checking " + ConfigHandler.DIR_ROOT);

				Directory.CreateDirectory(ConfigHandler.DIR_CONFIGS);
				Logger.Info("Checking " + ConfigHandler.DIR_CONFIGS);

				Directory.CreateDirectory(ConfigHandler.DIR_DATA);
				Logger.Info("Checking " + ConfigHandler.DIR_DATA);

				Directory.CreateDirectory(ConfigHandler.DIR_TEMP);
				Logger.Info("Checking " + ConfigHandler.DIR_TEMP);
			}
			catch (Exception ex)
			{
				Logger.Error(ex.Message);
			}
		}

		private static void CheckConfig()
		{
			ConfigHandler.Init();
			ConfigHandler.SaveConfig();
			Logger.Info("\n" + File.ReadAllText(ConfigHandler.CONFIG_FILE));
		}

		private static void ShowSystemInfos()
		{
			Assembly assembly = Assembly.GetExecutingAssembly();
			FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
			Console.WriteLine("Config Handler:\t\t\tJSON");
			Console.WriteLine($"Current release version:\t{fileVersionInfo.FileVersion}");
			Console.WriteLine($"DotNet version:\t\t\t{Environment.Version}");
			Console.WriteLine($"CPUs:\t\t\t\t{Environment.ProcessorCount}");
			Console.WriteLine($"Machine name:\t\t\t{Environment.MachineName}");
			Console.WriteLine($"Admin override:\t\t\t{Environment.IsPrivilegedProcess}");
			Console.WriteLine($"Operating system:\t\t{Environment.OSVersion}");
		}

		private static void TestLoggerSystem()
		{
			Logger.Info("This is a info message");
			Logger.Warn("This is a warn message");
			Logger.Error("This is a error message");
		}

		public static void Start()
		{
			Thread.Sleep(1000);
			TestLoggerSystem();
			Thread.Sleep(1000);
			CheckFilesystem();
			Thread.Sleep(1000);
			CheckConfig();
			Thread.Sleep(1000);
			ShowSystemInfos();
			Thread.Sleep(1000);
		}
	}
}
