using System.Collections.Generic;
using System.Linq;
using MailSender.Models;

namespace MailSender.Services.InMemory
{
	public class InMemoryServerRepository : InMemoryRepository<Server>
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

		public InMemoryServerRepository() : base(GetTestData()) { }

		public override void Update(Server item)
		{
			throw new System.NotImplementedException();
		}
	}
}