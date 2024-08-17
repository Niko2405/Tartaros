using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tartaros
{
	internal class Terminal
	{
		public static void Run()
		{
			string? command;
			Console.Clear();
			while (true)
			{
				Console.SetCursorPosition(0, Console.WindowHeight - 1);
				Console.Write('>');
				command = Console.ReadLine();

				if (command != null)
				{
					if (command == "shutdown")
					{
						Logger.PrintStatus("shutdown...", Logger.StatusCode.INFO);
						Environment.Exit(0);
					}
				}
			}
		}
		public static void Timeout(int seconds)
		{
			using (var progress = new ProgressBar())
			{
				for (int i = 0; i <= seconds; i++)
				{
					progress.Report((double)i / 100);
					Thread.Sleep(100);
				}
			}
		}
	}
}
