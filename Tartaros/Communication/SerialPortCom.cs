using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tartaros.Communication
{
	internal class SerialPortCom
	{
		private static bool locked = false;
		private static SerialPort? serialPort;

		/// <summary>
		/// Send data to serial port
		/// </summary>
		/// <param name="command"></param>
		public static void SendData(string command)
		{
			if (ConfigHandler.currentConfig != null)
			{
				serialPort = new SerialPort
				{
					PortName = ConfigHandler.currentConfig.SerialControlModulePortName,
					BaudRate = ConfigHandler.currentConfig.SerialControlModuleBaudrate,
					StopBits = StopBits.One,
					DataBits = ConfigHandler.currentConfig.SerialControlModuleDataBits,
					Parity = Parity.None,
					ReadTimeout = ConfigHandler.currentConfig.SerialControlModuleReadTimeout,
					WriteTimeout = ConfigHandler.currentConfig.SerialControlModuleWriteTimeout,
				};
				if (!serialPort.IsOpen)
				{
					try
					{
						serialPort.Open();
						serialPort.WriteLine(command);
						serialPort.Close();
					}
					catch (Exception ex)
					{
						Logger.PrintStatus(ex.Message, Logger.StatusCode.INFO);
					}
				}
			}
			else
			{
				Logger.PrintStatus("Reading config", Logger.StatusCode.FAILED);
			}
		}

		/// <summary>
		/// Send data to serial port
		/// </summary>
		/// <param name="command"></param>
		/// <returns>response from device</returns>
		public static string SendDataAndRecv(string command)
		{
			if (ConfigHandler.currentConfig != null)
			{
				string response = string.Empty;
				serialPort = new SerialPort
				{
					PortName = ConfigHandler.currentConfig.SerialControlModulePortName,
					BaudRate = ConfigHandler.currentConfig.SerialControlModuleBaudrate,
					StopBits = StopBits.One,
					DataBits = ConfigHandler.currentConfig.SerialControlModuleDataBits,
					Parity = Parity.None,
					ReadTimeout = ConfigHandler.currentConfig.SerialControlModuleReadTimeout,
					WriteTimeout = ConfigHandler.currentConfig.SerialControlModuleWriteTimeout,
				};
				while (locked)
				{
					Thread.Sleep(1);
				}
				if (!serialPort.IsOpen)
				{
					try
					{
						serialPort.Open();
						locked = true;

						serialPort.WriteLine(command);
						response = serialPort.ReadLine();

						serialPort.Close();
						locked = false;
					}
					catch (Exception ex)
					{
						Logger.PrintStatus(ex.Message, Logger.StatusCode.INFO);
					}
				}
				return response;
			}
			else
			{
				Logger.PrintStatus("Reading config", Logger.StatusCode.FAILED);
				return string.Empty;
			}
		}
	}
}
