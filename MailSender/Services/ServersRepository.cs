using System;
using System.Collections.Generic;
using System.Linq;
using MailSender.Models;

namespace MailSender.Servcies
{
	public class ServersRepository
	{
		private List<Server> _Servers;

		public ServersRepository()
		{
			_Servers = Enumerable.Range(1, 10)
				.Select(i => new Server
				{
					Id = i,
					Name = $"Сервер {i}",
					Address = $"smtp.server-{i}.ru",
					Login = $"User-{i}",
					Password = $"Password - {i}",
					UseSSL = i % 2 == 0
				})
				.ToList();
		}

		public IEnumerable<Server> GetAll() => _Servers;

		public Server Create(string Name, string Address, int Port, bool UseSSL, string Login, string Password)
		{
			var server = new Server
			{
				Name = Name,
				Address = Address,
				Port = Port,
				UseSSL = UseSSL,
				Login = Login,
				Password = Password,
			};
			Add(server);
			return server;
		}

		public void Add(Server server)
		{
			_Servers.Add(server);
		}

		public void Remove(Server server)
		{
			_Servers.Remove(server);
		}

		public void Update(Server server)
		{
			if (server is null) throw new ArgumentNullException(nameof(server));
			
			var repoServer = _Servers.FirstOrDefault(i => i.Id == server.Id);
			if(repoServer is null || ReferenceEquals(repoServer, server)) return;

			repoServer.Name = server.Name;
			repoServer.Address = server.Address;
			repoServer.Port = server.Port;
			repoServer.UseSSL = server.UseSSL;
			repoServer.Login = server.Login;
			repoServer.Password = server.Password;
		}
	}
}