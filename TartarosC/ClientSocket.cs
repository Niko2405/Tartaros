using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TartarosC
{
	internal class ClientSocket
	{
		private static string? _username;
		private static string? _password;
		private static string? _serveraddress;
		private static int _port;

		public static string Username
		{
			get
			{
				return _username;
			}
			set
			{
				_username = value;
			}
		}
		public static string Password
		{
			get
			{
				return _password;
			}
			set
			{
				_password = value;
			}
		}

		public static string ServerAddress
		{
			get
			{
				return _serveraddress;
			}
			set
			{
				_serveraddress = value;
			}
		}
	}
}
