﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTest
{
	class Program
	{
		static void Main(string[] args)
		{
			string filePath = Directory.GetCurrentDirectory().Replace("\\TestTest\\bin\\Debug", "") + "\\Test.csv";
			TestStreamReader.CreateTestCsvFile(filePath);
			using (StreamReader sr = new StreamReader(filePath))
			{
				List<char[]> listBuf = new List<char[]>();
				int index = 0;
				while (!sr.EndOfStream)
				{
					char[] charBuf = new char[512];
					index += sr.ReadBlock(charBuf, 0, charBuf.Length);
					listBuf.Add(charBuf);
				}
			}
		}

		public static List<Tuple<long, long>> CreateIntervals(Tuple<long, long> interval)
		{
			List<Tuple<long, long>> intervals = new List<Tuple<long, long>>();

			if (interval.Item2 - interval.Item1 > 1)
			{
				var m = (interval.Item1 + interval.Item2) / 2;
				var interval1 = new Tuple<long, long>(interval.Item1, m);
				var interval2 = new Tuple<long, long>(m + 1, interval1.Item2);

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
	}
}
