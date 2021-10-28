using System;
using System.Threading.Tasks;

namespace MatrixMultiplication
{
	class Program
	{
		static void Main(string[] args)
		{
			Random rand = new Random();
			int[,] a = new int[100, 100];
			int[,] b = new int[100, 100];

			for(int i = 0; i < a.GetLength(0); i++)
			{
				for(int j = 0; j < a.GetLength(1); j++)
				{
					a[i, j] = rand.Next(0, 10);
					b[i, j] = rand.Next(0, 10);
				}
			}

			int[,] c = new int[100, 100];

			Parallel.For(0, a.GetLength(0), (i) =>
			{
				for (int j = 0; j < b.GetLength(1); j++)
					for (int k = 0; k < b.GetLength(0); k++)
						c[i, j] += a[i, k] * b[k, j];
			});

			Console.ReadLine();
		}
	}
}
