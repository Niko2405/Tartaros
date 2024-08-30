namespace Tartaros
{
	internal class Program
	{
		static void Main(string[] args)
		{
			bool testModuleSkipped = false;

			Console.WriteLine("Loading program...\n");
			Thread.Sleep(2500);

			foreach (string arg in args)
			{
				if (arg == "--skipTestModule")
				{
					Logger.PrintStatus("TestModule skipped", Logger.StatusCode.INFO);
					testModuleSkipped = true;
				}
			}

			#region INIT
			Console.Title = "Tartaros - Init";
			Init.BuildFilesystem();
			Thread.Sleep(2000);

			ConfigHandler.Init();
			Thread.Sleep(2000);
			#endregion

			#region TEST
			if (!testModuleSkipped)
			{
				Init.CheckCommunications();
				Thread.Sleep(2000);

				Init.CheckCryptAndEncryption();
				Thread.Sleep(2000);
			}
			#endregion

			Terminal.Timeout(5);
			Terminal.Run();
		}
	}
}
