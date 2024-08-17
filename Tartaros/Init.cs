using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tartaros
{
	internal class Init
	{
		public static void BuildFilesystem()
		{
			Logger.PrintStatus("Build filesystem ", Logger.StatusCode.INFO);
			try
			{
				Directory.CreateDirectory(ConfigHandler.DIR_ROOT);
				Logger.PrintStatus("Checking " + ConfigHandler.DIR_ROOT, Logger.StatusCode.OK);

				Directory.CreateDirectory(ConfigHandler.DIR_CONFIGS);
				Logger.PrintStatus("Checking " + ConfigHandler.DIR_CONFIGS, Logger.StatusCode.OK);

				Directory.CreateDirectory(ConfigHandler.DIR_DATABASE);
				Logger.PrintStatus("Checking " + ConfigHandler.DIR_DATABASE, Logger.StatusCode.OK);

				Directory.CreateDirectory(ConfigHandler.DIR_TEMP);
				Logger.PrintStatus("Checking " + ConfigHandler.DIR_TEMP, Logger.StatusCode.OK);

				Logger.PrintStatus("Build filesystem", Logger.StatusCode.OK);
			}
			catch (Exception)
			{
				Logger.PrintStatus("Build filesystem", Logger.StatusCode.FAILED);
			}
		}

		public static void CheckCommunications()
		{
			// Serial
			Logger.PrintStatus("Test serial communication module", Logger.StatusCode.INFO);
			string response = Communication.SerialPortCom.SendDataAndRecv("ping");
			if (response != "pong")
			{
				Logger.PrintStatus("Serial communication module", Logger.StatusCode.FAILED);
			}
			else if (response == "pong")
			{
				Logger.PrintStatus("Serial communication module", Logger.StatusCode.OK);
			}
		}

		public static void CheckCryptAndEncryption()
		{
			// Direct (stdout)
			// Indirect (file)
		}
	}
}
