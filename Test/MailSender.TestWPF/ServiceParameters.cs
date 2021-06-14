using System;
using System.Net.Mail;

namespace MailSender.TestWPF
{
	public static class ServiceParameters
	{
		public static string Host => "smtp.yandex.ru";
		public static int Port => 25;
		private static MailAddress MailFrom => new MailAddress("mortalway@yandex.ru");
		private static MailAddress MailTo => new MailAddress("kasimovskiy.a.d.test@yandex.ru");

		public static MailMessage Message => new MailMessage(MailFrom, MailTo)
		{
			Subject = "Тестовое сообщение от " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ff"),
			Body = "Тело тестового сообщения " + DateTime.Now.ToString("F")
		};
	}
}
