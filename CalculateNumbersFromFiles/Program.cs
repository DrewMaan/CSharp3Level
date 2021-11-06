using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateNumbersFromFiles
{
	class Program
	{
		static void Main(string[] args)
		{
			FileGenerator.GenerateFiles(10000);
			File.WriteAllText(FileGenerator.FilesPath + "result.dat", string.Empty);
			var filesNames = Directory.GetFiles(FileGenerator.FilesPath).Where(x => x != FileGenerator.FilesPath + "result.dat").ToArray();
			using var fstreamResult = new FileStream(FileGenerator.FilesPath + "result.dat", FileMode.Append);
			object fstreamResultLock = new object();

			Parallel.ForEach(filesNames, (fileName) =>
			{
				double result = 0.0;

				using var sr = new StreamReader(fileName);
				string[] arguments = sr.ReadLine().Split(' ');

				if(int.Parse(arguments[0]) == 1)
					result = double.Parse(arguments[1]) * double.Parse(arguments[2]);
				else
					result = double.Parse(arguments[1]) / double.Parse(arguments[2]);

				byte[] input = Encoding.Default.GetBytes(result.ToString() + "\n");
				lock(fstreamResultLock)
				{
					fstreamResult.Write(input);
				}
			});
		}
	}
}
