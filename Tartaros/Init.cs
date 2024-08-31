using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tartaros
{
	internal class Init
	{
		public static void BuildFilesystem()
		{
			Logger.PrintStatus("Build filesystem ", Logger.StatusCode.INFO);
			try
			{
				Directory.CreateDirectory(ConfigHandler.DIR_ROOT);
				Logger.PrintStatus("Checking " + ConfigHandler.DIR_ROOT, Logger.StatusCode.OK);

				Directory.CreateDirectory(ConfigHandler.DIR_CONFIGS);
				Logger.PrintStatus("Checking " + ConfigHandler.DIR_CONFIGS, Logger.StatusCode.OK);

				Directory.CreateDirectory(ConfigHandler.DIR_DATABASE);
				Logger.PrintStatus("Checking " + ConfigHandler.DIR_DATABASE, Logger.StatusCode.OK);

				Directory.CreateDirectory(ConfigHandler.DIR_TEMP);
				Logger.PrintStatus("Checking " + ConfigHandler.DIR_TEMP, Logger.StatusCode.OK);

				Logger.PrintStatus("Build filesystem", Logger.StatusCode.OK);
			}
			catch (Exception)
			{
				Logger.PrintStatus("Build filesystem", Logger.StatusCode.FAILED);
			}
		}

		public static void CheckCommunications()
		{
			// Serial
			Logger.PrintStatus("Test serial communication module", Logger.StatusCode.INFO);
			string response = Communication.SerialPortConnection.SendDataAndRecv("ping");
			if (response != "pong")
			{
				Logger.PrintStatus("Serial communication module", Logger.StatusCode.FAILED);
			}
			else if (response == "pong")
			{
				Logger.PrintStatus("Serial communication module", Logger.StatusCode.OK);
			}
		}

		public static void CheckCryptAndEncryption()
		{
			var random = new Random();
			const int TESTS = 500;
			int failCounter = 0;
			long[] buffer = new long[TESTS];

			// Direct (internal)
			Logger.PrintStatus("Test SHA512 (internal)", Logger.StatusCode.INFO);
			for (int i = 0; i < TESTS; i++)
			{
				buffer[i] = random.NextInt64(long.MaxValue / 2, long.MaxValue);
			}
			Logger.PrintStatus($"Filling the buffer: {TESTS}", Logger.StatusCode.OK);

			for (int i = 0; i < buffer.Length; i++)
			{
				string xCrypted = Crypting.Encrypt(buffer[i].ToString());
				string xEncrypted = Crypting.Decrypt(xCrypted);
				Logger.PrintStatus($"[internal] SHA512 Test seq. [{i + 1}/{TESTS}]\t\tOriginal Value: {buffer[i]}\tCrypted Value: {xCrypted}\tEncrypted Value: {xEncrypted}", Logger.StatusCode.OK);

				if (buffer[i].ToString() != xEncrypted)
				{
					failCounter++;
					Logger.PrintStatus($"Crypt Overflow: Len Original Value:{buffer[i].ToString().Length}\tLen Encrypted Value: {xEncrypted.Length}", Logger.StatusCode.FAILED);
				}
			}
			Logger.PrintStatus($"Rusult: [{failCounter} / {TESTS}] failed", Logger.StatusCode.INFO);
			Logger.PrintStatus("Test SHA512 (internal)", Logger.StatusCode.OK);
			Terminal.Timeout(3);

			// Indirect (file)
			Logger.PrintStatus("Test SHA512 (external)", Logger.StatusCode.INFO);
			failCounter = 0;
			try
			{
				for (int i = 0; i < buffer.Length; i++)
				{
					// save values in file
					File.WriteAllText(ConfigHandler.DIR_TEMP + "originalValues.txt", buffer[i].ToString());

					// read file random numbers => crypting => save as new file 
					string xCrypted = Crypting.Encrypt(File.ReadAllText(ConfigHandler.DIR_TEMP + "originalValues.txt"));
					File.WriteAllText(ConfigHandler.DIR_TEMP + "cryptedValues.txt", xCrypted);

					// read crypted data => encrypt values => compare values with or the original
					string xEncrypted = Crypting.Decrypt(File.ReadAllText(ConfigHandler.DIR_TEMP + "cryptedValues.txt"));

					Logger.PrintStatus($"[external] SHA512 Test seq. [{i + 1}/{TESTS}]\t\tOriginal Value: {buffer[i]}\tCrypted Value: {xCrypted}\tEncrypted Value: {xEncrypted}", Logger.StatusCode.OK);
					if (buffer[i].ToString() != xEncrypted)
					{
						failCounter++;
						Logger.PrintStatus($"Crypt Overflow: Len Original Value:{buffer[i].ToString().Length}\tLen Encrypted Value: {xEncrypted.Length}", Logger.StatusCode.FAILED);
					}
					Thread.Sleep(1);
				}
				Logger.PrintStatus($"Rusult: [{failCounter} / {TESTS}] failed", Logger.StatusCode.INFO);
				Logger.PrintStatus("Test SHA512 (external)", Logger.StatusCode.OK);
			}
			catch (Exception)
			{
				Logger.PrintStatus("Test SHA512 (external)", Logger.StatusCode.FAILED);
			}

			// cleanup
			File.Delete(ConfigHandler.DIR_TEMP + "originalValues.txt");
			File.Delete(ConfigHandler.DIR_TEMP + "cryptedValues.txt");
		}
	}
}
