using System;
using System.Collections.Generic;
using System.Linq;
using MailSender.Models;

namespace MailSender.Services.InMemory
{
	public class InMemoryServersRepository : InMemoryRepository<Server>
	{
		private static IEnumerable<Server> GetTestData(int count = 10) => Enumerable.Range(1, count)
			.Select(i => new Server
			{
				Id = i,
				Name = $"Сервер {i}",
				Address = $"smtp.server-{i}.ru",
				Login = $"User-{i}",
				Password = $"Password - {i}",
				UseSSL = i % 2 == 0
			});

		public InMemoryServersRepository() : base(GetTestData()) { }

		public override void Update(Server item)
		{
			if (item is null) throw new ArgumentNullException(nameof(item));

			var dbItem = GetById(item.Id);
			if (dbItem is null || ReferenceEquals(dbItem, item)) return;

			dbItem.Name = item.Name;
			dbItem.Address = item.Address;
			dbItem.Port = item.Port;
			dbItem.UseSSL = item.UseSSL;
			dbItem.Login = item.Login;
			dbItem.Password = item.Password;
		}
	}
}