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

			ConfigHandler.Init();
			#endregion

			#region TEST
			if (!testModuleSkipped)
			{
				Init.CheckCommunications();
				Init.CheckCryptAndEncryption();
			}
			#endregion

			Terminal.Timeout(3);
			Terminal.Run();
		}
	}
}
