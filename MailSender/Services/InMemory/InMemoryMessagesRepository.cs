using System;
using System.Collections.Generic;
using System.Linq;
using MailSender.Models;

namespace MailSender.Services.InMemory
{
	public class InMemoryMessagesRepository : InMemoryRepository<Message>
	{
		private static IEnumerable<Message> GetTestData(int count = 100) => Enumerable.Range(1, count)
			.Select(i => new Message
			{
				Id = i,
				Title = $"Сообщение {i}",
				Text = $"Текст сообщения {i}"
			});

		public InMemoryMessagesRepository() : base(GetTestData())
		{
		}

		public override void Update(Message item)
		{
			if (item is null) throw new ArgumentNullException(nameof(item));

			var dbItem = GetById(item.Id);
			if (dbItem is null || ReferenceEquals(dbItem, item)) return;

			dbItem.Title = item.Title;
			dbItem.Text = item.Text;
		}
	}
}