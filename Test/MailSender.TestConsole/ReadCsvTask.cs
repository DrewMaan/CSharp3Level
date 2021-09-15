using System.IO;
using System.Threading;

namespace MailSender.TestConsole
{
	internal class ReadCsvTask
	{
		private readonly Thread _thread;
		private readonly int _bufSize;
		private readonly StreamReader _streamReader;

		public char[] Result { get; private set; }

		public ReadCsvTask(StreamReader streamReader, int bufSize)
		{
			_thread = new Thread(ReadString);
			_bufSize = bufSize;
			_streamReader = streamReader;
		}

		public void Start() => _thread.Start();

		public void Join() => _thread.Join();

		private void ReadString()
		{
			char[] charBuf = new char[_bufSize];
			_streamReader.ReadBlock(charBuf, 0, _bufSize);
			Result = charBuf;
		}
	}
}