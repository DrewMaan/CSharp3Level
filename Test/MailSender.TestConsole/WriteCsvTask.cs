using System.Threading;

namespace MailSender.TestConsole
{
	internal class WriteCsvTask
	{
		private readonly Thread _thread;
		
		public string Result { get; private set; }

		public WriteThread()
		{
			_thread = new Thread(WriteString);
		}

		private void WriteString()
		{
			string result = "";
			Result = result;
		}
	}
}