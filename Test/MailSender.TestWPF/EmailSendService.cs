using System;
using System.Net;
using System.Net.Mail;
using System.Security;

namespace MailSender.TestWPF
{
	public class EmailSendService : IDisposable
	{
		private readonly SmtpClient client;
		private MailMessage message;

		public EmailSendService(string login, SecureString password, string subjectMessage, string message)
		{
			this.message = ServiceParameters.Message;
			this.message.Body = message + "\n\n" + ServiceParameters.Message.Body;
			this.message.Subject = subjectMessage;

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
			client.Send(message);
		}

		public void Dispose()
		{
			client?.Dispose();
			message?.Dispose();
		}
	}
}
