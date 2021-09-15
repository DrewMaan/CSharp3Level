using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace MailSender.TestConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			//long N;
			//if (long.TryParse(Console.ReadLine(), out N))
			//{
			//	//Console.WriteLine("Начало вычмсления факториала из {0}", N);
			//	//Console.WriteLine("Результат: {0}", FactorialThreads(N, 20));

			//	Console.WriteLine("Начало вычмсления суммы чисел от 1 до {0}", N);
			//	Console.WriteLine("Результат: {0}", SumThreads(N, 20));
			//}

			List<char[]> listBufThreads = new List<char[]>();
			int bufSize = 512;
			string filePath = Directory.GetCurrentDirectory().Replace("\\Test\\MailSender.TestConsole\\bin\\Debug\\net5.0", "") + "\\Test.csv";
			string filePathTxt = Directory.GetCurrentDirectory().Replace("\\Test\\MailSender.TestConsole\\bin\\Debug\\net5.0", "") + "\\Test.txt";
			FileInfo file = new FileInfo(filePath);
			var parts = (file.Length / bufSize) / 100;
			ReadCsvTask[] tasks = new ReadCsvTask[parts];

			if(File.Exists(filePathTxt))
			{
				File.Delete(filePathTxt);
			}

			using (StreamWriter sw = File.CreateText(filePathTxt))
			{
				using (StreamReader sr = new StreamReader(filePath))
				{
					while (!sr.EndOfStream)
					{
						for (int i = 0; i < tasks.Length; i++)
						{
							tasks[i] = new ReadCsvTask(sr, bufSize);
						}

						for (int i = 0; i < tasks.Length; i++)
						{
							tasks[i].Start();
							tasks[i].Join();
						}

						WriteTxtTask[] writeTxtTasks = new WriteTxtTask[tasks.Length];
						for (int i = 0; i < tasks.Length; i++)
						{
							writeTxtTasks[i] = new WriteTxtTask(sw, tasks[i].Result);
						}
						for (int i = 0; i < tasks.Length; i++)
						{
							writeTxtTasks[i].Start();
							writeTxtTasks[i].Join();
						}
					}
				}
			}


			Console.ReadKey();
		}

		public static BigInteger FactorialThreads(long N, int numberIntervals)
		{
			if (N == 1 || N == 0) return 1;
			if (N < 0)
			{
				Console.WriteLine("Невозможно вычислить факториал из отрицательного числа!");
				throw new ArgumentException("Невозможно вычислить факториал из отрицательного числа!", nameof(N));
			}

			BigInteger result = 1;
			FactorialTask[] tasks;
			long step = N / numberIntervals;
			long start = 1;

			if (start < step)
			{
				tasks = new FactorialTask[numberIntervals + 1];
				for (int i = 1; i <= numberIntervals; i++)
				{
					if (i == numberIntervals)
						tasks[i] = new FactorialTask(new Tuple<long, long>(start + 1, N));
					else
					{
						tasks[i] = new FactorialTask(new Tuple<long, long>(start + 1, step * i));
					}
					start = step * i;
				}

				for (int i = 1; i <= numberIntervals; i++)
				{
					tasks[i].Start();
				}

				for (int i = 1; i <= numberIntervals; i++)
				{
					tasks[i].Join();
				}

				for (int i = 1; i <= numberIntervals; i++)
				{
					result *= tasks[i].Result;
				}
			}
			else
			{
				var intervals = CreateIntervals(new Tuple<long, long>(2, N));
				tasks = new FactorialTask[intervals.Count + 1];
				for (int i = 1; i <= intervals.Count; i++) 
					tasks[i] = new FactorialTask(intervals[i - 1]);

				for (int i = 1; i <= intervals.Count; i++)
				{
					tasks[i].Start();
				}

				for (int i = 1; i <= intervals.Count; i++)
				{
					tasks[i].Join();
				}

				for (int i = 1; i <= intervals.Count; i++)
				{
					result *= tasks[i].Result;
				}
			}

			return result;
		}

		public static BigInteger SumThreads(long N, int numberIntervals)
		{
			if (N == 1 || N == 0) return 1;
			if (N < 0)
			{
				Console.WriteLine("Невозможно вычислить сумму из отрицательного числа!");
				throw new ArgumentException("Невозможно вычислить сумму из отрицательного числа!", nameof(N));
			}

			BigInteger result = 0;
			SumTask[] tasks;
			long step = N / numberIntervals;
			long start = 0;

			if (start < step)
			{
				tasks = new SumTask[numberIntervals + 1];
				for (int i = 1; i <= numberIntervals; i++)
				{
					if (i == numberIntervals)
						tasks[i] = new SumTask(new Tuple<long, long>(start + 1, N));
					else
					{
						tasks[i] = new SumTask(new Tuple<long, long>(start + 1, step * i));
					}
					start = step * i;
				}

				for (int i = 1; i <= numberIntervals; i++)
				{
					tasks[i].Start();
				}

				for (int i = 1; i <= numberIntervals; i++)
				{
					tasks[i].Join();
				}

				for (int i = 1; i <= numberIntervals; i++)
				{
					result += tasks[i].Result;
				}
			}
			else
			{
				var intervals = CreateIntervals(new Tuple<long, long>(1, N));
				tasks = new SumTask[intervals.Count + 1];
				for (int i = 1; i <= intervals.Count; i++)
					tasks[i] = new SumTask(intervals[i - 1]);

				for (int i = 1; i <= intervals.Count; i++)
				{
					tasks[i].Start();
				}

				for (int i = 1; i <= intervals.Count; i++)
				{
					tasks[i].Join();
				}

				for (int i = 1; i <= intervals.Count; i++)
				{
					result += tasks[i].Result;
				}
			}

			return result;
		}

		public static List<Tuple<long, long>> CreateIntervals(Tuple<long, long> interval)
		{
			List<Tuple<long, long>> intervals = new List<Tuple<long, long>>();

			if (interval.Item2 - interval.Item1 > 1)
			{
				var m = (interval.Item1 + interval.Item2) / 2;
				var interval1 = new Tuple<long, long>(interval.Item1, m);
				var interval2 = new Tuple<long, long>(m + 1, interval.Item2);

				if (interval1.Item2 - interval1.Item1 > 1)
				{
					intervals.AddRange(CreateIntervals(interval1));
				}
				else
				{
					intervals.Add(interval1);
				}

				if (interval2.Item2 - interval2.Item1 > 1)
				{
					intervals.AddRange(CreateIntervals(interval2));
				}
				else
				{
					intervals.Add(interval2);
				}
			}

			return intervals;
		}

		//static List<char[]> ReadCsvFileThreads()
		//{
		//	string filePath = @"E:\Learning\CSharp3Level";
		//	ReadCsvTask[] readCsvTasks;
		//	int bufSize = 128;

		//}
	}
}
