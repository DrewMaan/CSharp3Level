using System.IO;

namespace TestTest
{
	public class TestStreamReader
	{
		public static void CreateTestCsvFile(string filePath)
		{
			if (!File.Exists(filePath))
			{
				using (var sr = File.CreateText(filePath))
				{
					for (int i = 0; i < 1_000_000; i++)
					{
						sr.WriteLine($"Index{i} Name{i} Description{i}");
					}
				}
			}
			else
			{
				File.Delete(filePath);
				CreateTestCsvFile(filePath);
			}
		}
	}
}
