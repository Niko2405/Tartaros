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
			try
			{
				string[] rawCommand = [];
				if (InputCommand.Contains(' '))
				{
					rawCommand = InputCommand.Split(' ');
				}

				// Commands with none args
				if ()
			}
			catch (System.Exception)
			{
				
				throw;
			}
			Logger.PrintStatus("Command not found", Logger.StatusCode.INFO);
			return string.Empty;
		}
	}
}
