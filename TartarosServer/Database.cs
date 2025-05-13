using System.Data.SQLite;
using TLogger;

namespace TartarosServer;

internal class Database
{
	// https://www.codeguru.com/dotnet/using-sqlite-in-a-c-application/
	
	public static void Test()
	{
		string testData = "Hallo SQLite3";

		try
		{
			SQLiteConnection connection = new SQLiteConnection($"Data Source={ConfigHandler.DIRECTORY_DATABASE}TestDatabase.db");
			connection.Open();
			SQLiteCommand sqlCommand = connection.CreateCommand();
			string command = """
			                 CREATE TABLE IF NOT EXISTS TestTable (
			                     		id   INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
			                 			text TEXT    NOT NULL
			                 		);
			                 """;
			sqlCommand.CommandText = command;
			sqlCommand.ExecuteNonQuery();
		
			// Insert data
			command = $"INSERT INTO TestTable (text) VALUES ('{testData}');";
			sqlCommand.CommandText = command;
			sqlCommand.ExecuteNonQuery();
		
			// Query data
			command = "SELECT * FROM TestTable WHERE id = 1;";
			sqlCommand.CommandText = command;
			SQLiteDataReader reader = sqlCommand.ExecuteReader();
			while (reader.Read())
			{
				string data = reader.GetString(1);
				if (data == testData)
				{
					Logger.Info("Database Test: OK");
				}
				else if (data != testData)
				{
					Logger.Error("Database Test: FAILED");
				}
			}
			reader.Close();
			sqlCommand.Dispose(); // very important for windows systems
			connection.Close();
		
			// Drop DB
			File.Delete(ConfigHandler.DIRECTORY_DATABASE + "TestDatabase.db");
		}
		catch (Exception e)
		{
			Logger.Error(e.Message);
		}
	}
}