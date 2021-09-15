using System.IO;
using System.Threading;

namespace MailSender.TestConsole
{
	internal class WriteTxtTask
	{
		private readonly Thread _thread;
		private readonly char[] _charBuf;
		private readonly StreamWriter _streamWriter;

		public char[] Result { get; private set; }

		public WriteTxtTask(StreamWriter streamWriter, char[] charBuf)
		{
			_thread = new Thread(WriteString);
			_charBuf = charBuf;
			_streamWriter = streamWriter;
		}

		public void Start() => _thread.Start();

		public void Join() => _thread.Join();

		private void WriteString()
		{
			_streamWriter.Write(_charBuf);
		}
	}
}