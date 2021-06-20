using System.Net;
using System.Net.Mail;
using System.Security;

namespace MailSender
{
	public class MailSenderService
	{
		private readonly string _address;
		private readonly int _port;
		private readonly bool _useSsl;
		private readonly string _login;
		private readonly string _password;

		public MailSenderService(string address, int port, bool useSSL, string login, string password)
		{
			_address = address;
			_port = port;
			_useSsl = useSSL;
			_login = login;
			_password = password;
		}

		public void SendMessage(string from, string to, string title, string textMessage)
		{
			using var message = new MailMessage(from, to)
			{
				Subject = title,
				Body = textMessage
			};

			using (var client = new SmtpClient(_address, _port)
			{
				EnableSsl = _useSsl,
				Credentials = new NetworkCredential()
				{
					UserName = _login,
					Password = _password
				}
			})
			{
				client.Send(message);
			}
		}
	}
}