﻿using System;
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
			Console.Title = "Tartaros - Terminal";
			Console.Clear();

			while (true)
			{
				Console.Title = "Tartaros - Terminal";
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
					Console.WriteLine(CommandHandler.ProcessCommand(command));
				}
			}
		}

		public static void Timeout(int seconds)
		{
			Console.CursorVisible = false;
			Console.SetCursorPosition(0, Console.WindowHeight - 1);
			Console.Write("Loading... ");
			for (int i = seconds; i >= 0; i--)
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
