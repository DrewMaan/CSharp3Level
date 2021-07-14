using System;
using System.Collections.Generic;
using System.Linq;
using MailSender.Models;

namespace MailSender.Services.InMemory
{
	public class InMemoryRecipientsRepository : InMemoryRepository<Recipient>
	{
		private static IEnumerable<Recipient> GetTestData(int count = 10) => Enumerable.Range(1, count)
			.Select(i => new Recipient
			{
				Id = i,
				Name = $"Отправитель - {i}",
				Address = $"sender-{i}.server.ru",
				Description = $"Описание отправителя {i}",
			});

		public InMemoryRecipientsRepository() : base(GetTestData())
		{
		}

		public override void Update(Recipient item)
		{
			if (item is null) throw new ArgumentNullException(nameof(item));

			var dbItem = GetById(item.Id);
			if (dbItem is null || ReferenceEquals(dbItem, item)) return;

			dbItem.Name = item.Name;
			dbItem.Address = item.Address;
			dbItem.Description = item.Description;
		}
	}
}