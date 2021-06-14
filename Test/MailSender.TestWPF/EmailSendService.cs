using System;
using System.Net;
using System.Net.Mail;
using System.Security;

namespace MailSender.TestWPF
{
	public class EmailSendService : IDisposable
	{
		private readonly SmtpClient client;

		public EmailSendService(string login, SecureString password)
		{
			client = new SmtpClient(ServiceParameters.Host, ServiceParameters.Port)
			{
				UseDefaultCredentials = false,
				DeliveryMethod = SmtpDeliveryMethod.Network,
				EnableSsl = true,
				Credentials = new NetworkCredential
				{
					UserName = login,
					SecurePassword = password
				}
			};
		}

		public void SendMessage()
		{
			client.Send(ServiceParameters.Message);
		}

		public void Dispose()
		{
			client?.Dispose();
		}
	}
}
