namespace Tartaros
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Loading program...\n");
			Thread.Sleep(2500);

			foreach (string arg in args)
			{

			}

			#region INIT
			Console.Title = "Tartaros - Init";
			Init.BuildFilesystem();
			Thread.Sleep(2000);

			ConfigHandler.Init();
			Thread.Sleep(2000);
			Init.CheckCommunications();
			Thread.Sleep(2000);

			Init.CheckCryptAndEncryption();
			Thread.Sleep(2000);
			#endregion

			Terminal.Timeout(5);
			Terminal.Run();
		}
	}
}
