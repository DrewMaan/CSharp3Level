using System;
using System.Collections.Generic;
using System.Linq;
using MailSender.Models;

namespace MailSender.Services
{
	public class ConsignorsRepository
	{
		private List<Consignor> _consignors;

		public ConsignorsRepository()
		{
			_consignors = Enumerable.Range(1, 10)
				.Select(i => new Consignor
				{
					Id = i,
					Name = $"Отправитель - {i}",
					Address = $"sender-{i}.server.ru",
					Description = $"Описание отправителя {i}",
				}).ToList();
		}

		public IEnumerable<Consignor> GetAll() => _consignors;

		public Consignor Create(string name, string address, string description)
		{
			var consignor = new Consignor
			{
				Name = name,
				Address = address,
				Description = description
			};
			Add(consignor);
			return consignor;
		}

		public void Add(Consignor consignor)
		{
			_consignors.Add(consignor);
		}

		public void Remove(Consignor consignor)
		{
			_consignors.Remove(consignor);
		}

		public void Update(Consignor consignor)
		{
			if (consignor is null) throw new ArgumentNullException(nameof(consignor));

			var repoConsignor = _consignors.FirstOrDefault(i => i.Id == consignor.Id);
			if (repoConsignor is null || ReferenceEquals(repoConsignor, _consignors)) return;

			repoConsignor.Name = consignor.Name;
			repoConsignor.Address = consignor.Address;
			repoConsignor.Description = consignor.Description;
		}
	}
}
