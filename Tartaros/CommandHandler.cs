using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tartaros
{
	internal class CommandHandler
	{
		public static readonly List<string> CommandList = new()
		{
			{"help"},
			{"info"},

			{"getConfig"},
			{"runProgram"}
		};

		public static string ProcessCommand(string InputCommand)
		{
			if (InputCommand == string.Empty)
			{
				return string.Empty;
			}

			string[] rawCommand = InputCommand.Split(' ');
			try
			{
				if (rawCommand[0] == "help")
				{
					if (rawCommand.Length > 1)
					{
						if (rawCommand[1] == "getConfig")
						{
							return "help - getConfig";
						}
						else if (rawCommand[1] == "runProgram")
						{
							return "help - runProgram";
						}
					}
					else
					{
						return "Use: help [command]";
					}
				}
				else if (rawCommand[0] == "info")
				{
					return "No info here";
				}
				else if (rawCommand[0] == "getConfig")
				{
					return File.ReadAllText(ConfigHandler.CONFIG_FILE);
				}
				else if (rawCommand[0] == "runProgram")
				{
					if (rawCommand.Length > 1)
					{
						if (rawCommand[1] == "testModule")
						{
							Init.CheckCommunications();
							Init.CheckCryptAndEncryption();
						}
						else if (rawCommand[1] == "serialControl")
						{
							Programs.SerialControl.Run();
							return string.Empty;
						}
					}
				}
				else if (rawCommand[0] == "clear")
				{
					Console.Clear();
					return string.Empty;
				}
			}
			catch (IndexOutOfRangeException)
			{
				return string.Empty;
			}
			Logger.PrintStatus("Command not found", Logger.StatusCode.INFO);
			return string.Empty;
		}
	}
}
