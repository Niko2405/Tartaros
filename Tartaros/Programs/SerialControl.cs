using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tartaros.Programs
{
	internal class SerialControl
	{
		public static void Run()
		{
			string? command;
			Console.Title = "Tartaros - SerialControl";
			Console.Clear();

			if (ConfigHandler.currentConfig != null)
			{
				Console.WriteLine($"Current settings:\nSerialPort: {ConfigHandler.currentConfig.SerialControlModulePortName}\nBaudrate: {ConfigHandler.currentConfig.SerialControlModuleBaudrate}\nDataBits: {ConfigHandler.currentConfig.SerialControlModuleDataBits}\nStopBits: One\nParity: None\nReadTimeout: {ConfigHandler.currentConfig.SerialControlModuleReadTimeout}\nWriteTimeout: {ConfigHandler.currentConfig.SerialControlModuleWriteTimeout}");
				
				while (true)
				{
					Console.SetCursorPosition(0, Console.WindowHeight - 1);
					Console.Write('>');
					command = Console.ReadLine();

					if (command != null)
					{
						if (command == "exit")
						{
							Console.Clear();
							return;
						}
						Console.WriteLine(Communication.SerialPortConnection.SendDataAndRecv(command));
					}
				}
			}
		}
	}
}
