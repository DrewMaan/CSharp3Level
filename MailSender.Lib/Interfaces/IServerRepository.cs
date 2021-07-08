using MailSender.Models;
using System.Collections.Generic;

namespace MailSender.Interfaces
{
	public interface IServerRepository
	{
		ICollection<Server> Servers { get; }

		void Load();

		void SaveChanges();
	}
}