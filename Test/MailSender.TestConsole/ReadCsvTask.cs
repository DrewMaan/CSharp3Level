using System.IO;
using System.Threading;

namespace MailSender.TestConsole
{
	internal class ReadCsvTask
	{
		private readonly Thread _thread;
		private readonly int _bufSize;
		private readonly string _filePath;

		public char[] Result { get; private set; }

		public ReadCsvTask(int bufSize, string filePath)
		{
			_thread = new Thread(ReadString);
			_bufSize = bufSize;
		}

		private void ReadString()
		{
			char[] charBuf = new char[_bufSize];
			using (var sr = new StreamReader(_filePath))
			{
				sr.ReadBlock(charBuf, 0, _bufSize);
			}
			Result = charBuf;
		}
	}
}