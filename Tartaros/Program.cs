namespace Tartaros
{
	internal class Program
	{
		static void Main(string[] args)
		{
			foreach (string arg in args)
			{

			}
			// init
			Init.BuildFilesystem();

			Terminal.Timeout(5000);

			Terminal.Run();
		}
	}
}
