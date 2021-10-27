﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using MailSender.Interfaces;
using MailSender.Models;

namespace MailSender.Services
{
	public class DebugMailService : IMailService
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
				Debug.WriteLine($"Отправка почты от {senderAddress} к {recipientAddress}\nТема: {subject}\nТекст: {body}");
			}

			public void Send(string senderAddress, IEnumerable<string> recipientAddresses, string subject, string body)
			{
				foreach (var recipientAddress in recipientAddresses)
					Send(senderAddress, recipientAddress, subject, body);
			}

			public void SendParallel(string senderAddress, IEnumerable<string> recipientAddresses, string subject, string body)
			{
				foreach (var recipientAddress in recipientAddresses)
					//ThreadPool.QueueUserWorkItem(_ => Send(senderAddress, recipientAddress, subject, body));
					ThreadPool.QueueUserWorkItem(p => Send((string)((object[])p)[0], (string)((object[])p)[1], (string)((object[])p)[2], (string)((object[])p)[3]),
						new[] { senderAddress, recipientAddress, subject, body });
			}
		}
	}
}