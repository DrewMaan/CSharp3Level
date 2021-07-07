using MailSender.Models;

namespace MailSender.Interfaces
{
	public interface IServerUserDialog
	{
		bool EditServer(Server server);
		bool AddServer(out Server server);
	}
}
