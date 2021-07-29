using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender.TestConsole
{
	class FactorialTask
	{
		private readonly Thread _thread;
		private readonly Tuple<long, long> _interval;


		public BigInteger Result { get; private set; }

		public FactorialTask(Tuple<long,long> interval)
		{
			_interval = interval;
			_thread = new Thread(CalculateFactorial);
		}

		public void Start() => _thread.Start();

		public void Join() => _thread.Join();

		private void CalculateFactorial()
		{
			BigInteger result = 1;
			for (long i = _interval.Item1; i <= _interval.Item2; i++)
			{
				result *= i;
			}

			Result = result;
		}
	}
}
