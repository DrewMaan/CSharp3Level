using MailSender.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Services
{
	public class SmtpMailService : IMailService
	{
		public IMailSender GetSender(string serverAddress, int port, bool useSSL, string login, string password)
		{
			return new Sender(serverAddress, port, useSSL, login, password);
		}

		private class Sender : IMailSender
		{
			private string _serverAddress;
			private int _port;
			private bool _useSSL;
			private string _login;
			private string _password;

			public Sender(string serverAddress, int port, bool useSSL, string login, string password)
			{
				_serverAddress = serverAddress;
				_port = port;
				_useSSL = useSSL;
				_login = login;
				_password = password;
			}

			public void Send(string senderAddress, string recipientAddress, string subject, string body)
			{
				using var client = new SmtpClient(_serverAddress, _port)
				{
					EnableSsl = _useSSL,
					Credentials = new NetworkCredential
					{
						UserName = _login,
						Password = _password
					}
				};

				using var message = new MailMessage(senderAddress, recipientAddress, subject, body);

				client.Send(message);
			}
		}
	}
}
