using System;
using System.Net;
using System.Net.Mail;

namespace MailSender.TestConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			MailAddress from = new MailAddress("mortalway@yandex.ru");
			MailAddress to = new MailAddress("kasimovskiy.a.d.test@yandex.ru");
			using MailMessage message = new MailMessage(from, to)
			{
				Subject = "Тестовое сообщение от " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ff"),
				Body = "Тело тестового сообщения " + DateTime.Now.ToString("F")
			};

			//message.Attachments.Add(new Attachment());
			using var client = new SmtpClient("smtp.yandex.ru", 25)
			{
				UseDefaultCredentials = false,
				DeliveryMethod = SmtpDeliveryMethod.Network,
				EnableSsl = true,
				Credentials = new NetworkCredential
				{
					UserName = "mortalway",
					Password = "somepassword"
				}
			};
		}
	}
}
