namespace Tartaros
{
	internal class Program
	{
		static void Main(string[] args)
		{
			foreach (string arg in args)
			{

			}

			#region INIT
			Init.BuildFilesystem();
			ConfigHandler.Init();
			Init.CheckCommunications();
			Init.CheckCryptAndEncryption();
			#endregion

			Terminal.Timeout(5);
			Terminal.Run();
		}
	}
}
