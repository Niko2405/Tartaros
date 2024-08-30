using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tartaros
{
	internal class CommandHandler
	{
		public static string ProcessCommand(string InputCommand)
		{
			string[] rawCommand = InputCommand.Split(' ');
			try
			{
				#region HELP
				if (rawCommand[0] == "help" && rawCommand.Length == 1)
				{
					return "No help";
				}
				#endregion

				#region INFO
				if (rawCommand[0] == "info")
				{
					return "No info";
				}
				#endregion

				#region CLEAR
				if (rawCommand[0] == "clear")
				{
					Console.Clear();
					return string.Empty;
				}
				#endregion

				#region RUN
				if (rawCommand[0] == "run")
				{
					if (rawCommand.Length == 1)
					{
						return "Available options:\nrun program [program]";
					}
					if (rawCommand[1] == "program")
					{
						if (rawCommand.Length == 2)
					{
						return "Available programs:\n-> testmodule\n-> serialcontrol";
					}
						if (rawCommand[2] == "testmodule")
						{
							Init.CheckCommunications();
							Init.CheckCryptAndEncryption();
							return string.Empty;
						}
						if (rawCommand[2] == "serialcontrol")
						{
							
						}
					}
				}
				#endregion

				#region SET
				if (rawCommand[0] == "set")
				{
					
				}
				#endregion

				#region GET
				if (rawCommand[0] == "get")
				{
					if (rawCommand.Length == 1)
					{
						return "Available options:\nget config";
					}
					if (rawCommand[1] == "config")
					{
						return File.ReadAllText(ConfigHandler.CONFIG_FILE);
					}
				}
				#endregion

				Logger.PrintStatus("No command found", Logger.StatusCode.FAILED);
				return string.Empty;
			}
			catch (IndexOutOfRangeException)
			{
				return string.Empty;
			}
		}
	}
}
