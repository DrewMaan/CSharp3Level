using System;
using System.IO;
using System.Text;

namespace CalculateNumbersFromFiles
{
	public static class FileGenerator
	{
		static Random rand = new Random();
		public static string FilesPath = @"..\..\..\Files\";

		public static void GenerateFiles(int numbers = 1)
		{
			for (int i = 0; i < numbers; i++)
			{
				using var fstream = new FileStream(FilesPath + "file" + i + ".dat", FileMode.OpenOrCreate);
				var numbers1 = rand.NextDouble() * 10;
				var numbers2 = rand.NextDouble() * 10;
				byte[] input = Encoding.Default.GetBytes($"{rand.Next(1, 3)} {numbers1.ToString("F6")} {numbers2.ToString("F6")}");

				fstream.Write(input);
			}
		}
	}
}
