using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLogger;

namespace Tartaros
{
	internal class Server
	{
		public static bool Active = false;

		public static void RunCommandLine()
		{
			string? command;
			Console.Clear();
			Console.Write(Terminal.LOGO);

			while (true)
			{
				Console.SetCursorPosition(0, Console.WindowHeight - 1);
				Console.Write('>');
				command = Console.ReadLine();
				if (!string.IsNullOrEmpty(command))
				{
					Logger.Info(command);
					// process
				}
			}
		}
	}
}
