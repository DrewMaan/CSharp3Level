using MailSender.Models;
using System.Collections.Generic;
using System.Linq;

namespace MailSender.Data
{
	public class TestData
	{
		public static List<Server> Servers { get; } = new List<Server>()
		{
			new Server() {Address = "smtp.yandex.ru", Login = "", Password = "", Name = "Yandex", UseSSL = true},
			new Server() {Address = "smtp.gmail.com", Login = "", Password = "", Name = "Google", UseSSL = true},
			new Server() {Address = "smtp-mail.outlook.com", Login = "", Password = "", Name = "Outlook", UseSSL = true},
			new Server() {Address = "smtp.mail.ru", Login = "", Password = "", Name = "Mail.ru", UseSSL = true},
			new Server() {Address = "smtp.mail.me.com", Login = "", Password = "", Name = "ICloud", UseSSL = true, Port = 587}
		};

		public static List<Consignor> Consignors { get; } = Enumerable.Range(1, 10)
			.Select(i => new Consignor
			{
				Id = i,
				Name = $"Отправитель - {i}",
				Address = $"sender-{i}.server.ru",
				Description = $"Описание отправителя {i}",
			})
			.ToList();

		public static List<Recipient> Recipients { get; } = Enumerable.Range(1, 10)
			.Select(i => new Recipient
			{
				Id = i,
				Name = $"Получатель - {i}",
				Address = $"recipient-{i}.server.ru",
				Description = $"Описание получателя {i}"
			})
			.ToList();

		public static List<Message> Messages { get; } = Enumerable.Range(1, 100)
			.Select(i => new Message
			{
				Title = $"Сообщение {i}",
				Text = $"Текст сообщения {i}"
			})
			.ToList();
	}
}
