using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender.Interfaces
{
	public interface IMailService
	{
		IMailSender GetSender(string serverAddress, int port, bool useSSL, string login, string password);
	}

	public interface IMailSender
	{
		void Send(string senderAddress, string recipientAddress, string subject, string body);

		void Send(string senderAddress, IEnumerable<string> recipientAddresses, string subject, string body);

		void SendParallel(string senderAddress, IEnumerable<string> recipientAddresses, string subject, string body);

		Task SendAsync(string senderAddress, string recipientAddress, string subject, string body, CancellationToken cancellationToken = default);

		Task SendAsync(string senderAddress, IEnumerable<string> recipientAddresses, string subject, string body, CancellationToken cancellationToken = default);

		Task SendParallelAsync(string senderAddress, IEnumerable<string> recipientAddresses, string subject, string body, CancellationToken cancellationToken = default);
	}
}