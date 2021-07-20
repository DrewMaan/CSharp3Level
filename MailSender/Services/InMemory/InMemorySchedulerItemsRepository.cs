using System;
using MailSender.Models;
using System.Collections.Generic;
using System.Linq;

namespace MailSender.Services.InMemory
{
	public class InMemorySchedulerItemsRepository : InMemoryRepository<SchedulerItem>
	{
		private static IEnumerable<SchedulerItem> GetTestData(int count = 10) => Enumerable.Range(1, count)
			.Select(i => new SchedulerItem
			{
				Id = i,
				TimeSend = new DateTime(DateTime.Today.Year,
										DateTime.Today.Month,
										DateTime.Today.Day,
										i, 0, 0),
				MessageBody = $"Текст сообщения {i}"
			});

		public InMemorySchedulerItemsRepository() : base(GetTestData()) { }

		public override void Update(SchedulerItem item)
		{
			if (item is null) throw new ArgumentNullException(nameof(item));

			var dbItem = GetById(item.Id);
			if (dbItem is null || ReferenceEquals(dbItem, item)) return;

			dbItem.TimeSend = item.TimeSend;
			dbItem.MessageBody = item.MessageBody;
		}
	}
}