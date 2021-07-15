using System;
using System.Collections.Generic;
using System.Linq;
using MailSender.Models;

namespace MailSender.Services.InMemory
{
	public class InMemoryConsignorsRepository : InMemoryRepository<Consignor>
	{
		private static IEnumerable<Consignor> GetTestData(int count = 10) => Enumerable.Range(1, count)
			.Select(i => new Consignor
			{
				Id = i,
				Name = $"Отправитель - {i}",
				Address = $"consignor{i}@server.ru",
				Description = $"Описание отправителя {i}",
			});

		public InMemoryConsignorsRepository() : base(GetTestData())
		{
		}

		public override void Update(Consignor item)
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