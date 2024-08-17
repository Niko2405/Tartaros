using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tartaros
{
	internal class Logger
	{
		/// <summary>
		/// Print status code of this running process
		/// </summary>
		public enum StatusCode
		{
			INFO,
			OK,
			FAILED,
		}

		/// <summary>
		/// Print Status log of given process name
		/// </summary>
		/// <param name="message"></param>
		/// <param name="code"></param>
		public static void PrintStatus(string message, StatusCode code)
		{
			// [FAILED]
			// [ INFO ]
			// [  OK  ]
			switch (code)
			{
				case StatusCode.INFO:
					Console.Write("[");
					Console.ForegroundColor = ConsoleColor.Cyan;
					Console.Write(" INFO ");
					Console.ForegroundColor = ConsoleColor.White;
					Console.Write("] ");
					Console.WriteLine(message);
					break;
				case StatusCode.OK:
					Console.Write("[");
					Console.ForegroundColor = ConsoleColor.Green;
					Console.Write("  OK  ");
					Console.ForegroundColor = ConsoleColor.White;
					Console.Write("] ");
					Console.WriteLine(message);
					break;
				case StatusCode.FAILED:
					Console.Write("[");
					Console.ForegroundColor = ConsoleColor.Red;
					Console.Write("FAILED");
					Console.ForegroundColor = ConsoleColor.White;
					Console.Write("] ");
					Console.WriteLine(message);
					break;
				default:
					break;
			}
		}
	}
}
