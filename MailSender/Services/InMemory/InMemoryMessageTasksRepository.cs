using System;
using System.Collections.Generic;
using System.Linq;
using MailSender.Models;

namespace MailSender.Services.InMemory
{
	public class InMemoryMessageTasksRepository : InMemoryRepository<MessageTask>
	{
		private static IEnumerable<MessageTask> GetTestData(int count = 10) => Enumerable.Range(1, 5)
			.Select(i => new MessageTask
			{
				Id = i,
				Consignor = new Consignor
				{
					Id = i,
					Name = $"Отправитель {i}",
					Address = $"consignor{i}@server.ru",
					Description = $"Описание отправителя {i}"
				},
				Message = new Message
				{
					Id = i,
					Title = $"Тема письма {i}",
					Text = $"Текст письма {i}"
				},
				Recipients = Enumerable.Range(1, 3)
					.Select(j => new Recipient
					{
						Id = j,
						Name = $"Получатель {j}",
						Address = $"recipient{j}@server.ru",
						Description = $"Описание получателя {i}"
					}).ToList()
			});

		public InMemoryMessageTasksRepository() : base(GetTestData()) { }

		public override void Update(MessageTask item)
		{
			if (item is null) throw new ArgumentNullException(nameof(item));

			var dbItem = GetById(item.Id);
			if (dbItem is null || ReferenceEquals(dbItem, item)) return;

			dbItem.Consignor.Name = item.Consignor.Name;
			dbItem.Consignor.Address = item.Consignor.Address;

			dbItem.Message.Title = item.Message.Title;
			dbItem.Message.Text = item.Message.Text;
		}
	}
}