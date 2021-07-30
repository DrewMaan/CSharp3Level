using System;
using System.Numerics;
using System.Threading;

namespace MailSender.TestConsole
{
	class SumTask
	{
		private readonly Thread _thread;
		private readonly Tuple<long, long> _interval;


		public BigInteger Result { get; private set; }

		public SumTask(Tuple<long, long> interval)
		{
			_interval = interval;
			_thread = new Thread(CalculateSum);
		}

		public void Start() => _thread.Start();

		public void Join() => _thread.Join();

		private void CalculateSum()
		{
			BigInteger result = 0;
			for (long i = _interval.Item1; i <= _interval.Item2; i++)
			{
				result += i;
			}

			Result = result;
		}
	}
}