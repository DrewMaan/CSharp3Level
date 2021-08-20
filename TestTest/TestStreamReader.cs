using System.IO;

namespace TestTest
{
	public class TestStreamReader
	{
		public static void CreateTestCsvFile()
		{
			string filePath = @"C:\Learning\CSharp_Level3\CSharp3Level\test.csv";
			if (!File.Exists(filePath))
			{
				using (var sr = File.CreateText(filePath))
				{
					for (int i = 0; i < 500; i++)
					{
						sr.WriteLine($"Index{i} Name{i} Description{i}");
					}
				}
			}
			else
			{
				File.Delete(filePath);
				CreateTestCsvFile();
			}
		}
	}
}
