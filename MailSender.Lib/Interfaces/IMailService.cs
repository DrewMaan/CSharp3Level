using System.Linq;
using MailSender.Models;

namespace MailSender.Interfaces
{
	public interface IMailService
	{
		void SendEmail(string From, string To, string Title, string Body);

		void SendEmail(IQueryable<Message> mails);
	}
}