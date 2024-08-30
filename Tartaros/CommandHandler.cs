using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tartaros
{
	internal class CommandHandler
	{
		public static readonly List<string> CommandList =
		[
			"help",
			"info",
			"clear",
			"run program"
		];

		public static string ProcessCommand(string InputCommand)
		{
			//string[] rawCommand = InputCommand.Split(' ');
			try
			{
				for (int i = 0; i < CommandList.Count; i++)
				{
					if (CommandList[i].StartsWith(InputCommand))
					{
						switch (i)
						{
							case 0:
								return "help is not an option";
							default:
								break;
						}
					}
				}
				return string.Empty;
			}
			catch (Exception)
			{
				Logger.PrintStatus("ProcessCommand", Logger.StatusCode.FAILED);
				return string.Empty;
			}
		}
	}
}
