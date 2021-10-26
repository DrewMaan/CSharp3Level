using System.Linq;
using MailSender.Models;

namespace MailSender.Interfaces
{
	public interface IMailService
	{
		IMailSender GetSender(string serverAddress, int port, bool useSSL, string login, string password);
	}

	public interface IMailSender
	{
		void Send(string senderAddress, string recipientAddress, string subject, string body);
	}
}