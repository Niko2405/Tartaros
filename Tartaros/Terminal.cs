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
			Console.Title = "Tartaros - Terminal";

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
			Console.CursorVisible = false;
			Console.Write("Waiting... ");
			for (int i = 0; i <= seconds; i++)
			{
				Console.Write(i);
				Thread.Sleep(1000);
				if (i >= 10)
				{
					Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
				}
				else if (i <= 9)
				{
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
				}
			}
			Console.CursorVisible = true;
			Console.WriteLine();
		}
	}
}
