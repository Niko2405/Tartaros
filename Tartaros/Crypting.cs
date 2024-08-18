using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tartaros
{
	internal class Crypting
	{
		//public static readonly byte[] SALT = [45, 12, 60, 51, 73, 7, 84, 97];
		public static readonly byte[] IV = new byte[16];

		/// <summary>
		/// Verschlüsseln
		/// </summary>
		/// <param name="text"></param>
		/// <param name="key"></param>
		/// <returns></returns>
		public static string Encrypt(string text)
		{
			byte[] buffer = Encoding.UTF8.GetBytes(text);
			Aes aes = Aes.Create();
			//aes.Padding = PaddingMode.Zeros;
			if (ConfigHandler.currentConfig == null)
			{
				Logger.PrintStatus("Cannot read key from config file", Logger.StatusCode.FAILED);
				return "No key found";
			}
			aes.Key = CreateKey(ConfigHandler.currentConfig.CryptKey);
			aes.IV = IV;

			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
				{
					cryptoStream.Write(buffer, 0, buffer.Length);
					cryptoStream.FlushFinalBlock();
				}
				return Convert.ToBase64String(memoryStream.ToArray());
			}
		}

		/// <summary>
		/// Entschlüsseln
		/// </summary>
		/// <param name="cryptedText"></param>
		/// <param name="key"></param>
		/// <returns></returns>
		public static string Decrypt(string cryptedText)
		{
			byte[] buffer = Convert.FromBase64String(cryptedText);
			Aes aes = Aes.Create();
			//aes.Padding = PaddingMode.Zeros;
			if (ConfigHandler.currentConfig == null)
			{
				Logger.PrintStatus("Cannot read key from config file", Logger.StatusCode.FAILED);
				return "No key found";
			}
			aes.Key = CreateKey(ConfigHandler.currentConfig.CryptKey);
			aes.IV = IV;

			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
				{
					cryptoStream.Write(buffer, 0, buffer.Length);
					cryptoStream.FlushFinalBlock();
				}
				return Encoding.UTF8.GetString(memoryStream.ToArray());
			}
		}

		/// <summary>
		/// Create Key
		/// </summary>
		/// <param name="password"></param>
		/// <param name="keyBytes"></param>
		/// <returns>Key for en-decryping</returns>
		public static byte[] CreateKey(string password, int keyBytes = 32)
		{
			if (ConfigHandler.currentConfig != null)
			{
				var keyGenerator = Rfc2898DeriveBytes.Pbkdf2(password, Encoding.UTF8.GetBytes(ConfigHandler.currentConfig.CryptSaltNew), ConfigHandler.currentConfig.CryptIterations, HashAlgorithmName.SHA512, keyBytes);
				return keyGenerator;
			}
			Logger.PrintStatus("[SHA512] Create key", Logger.StatusCode.FAILED);
			return [];
		}

		public static bool CheckEncoding(string value, Encoding encoding)
		{
			bool retCode;
			var charArray = value.ToCharArray();
			byte[] bytes = new byte[charArray.Length];
			for (int i = 0; i < charArray.Length; i++)
			{
				bytes[i] = (byte)charArray[i];
			}
			retCode = string.Equals(encoding.GetString(bytes, 0, bytes.Length), value, StringComparison.InvariantCulture);
			return retCode;
		}
	}
}
