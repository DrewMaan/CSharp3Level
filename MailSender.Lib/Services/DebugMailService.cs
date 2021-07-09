using System.Diagnostics;
using System.Linq;
using MailSender.Interfaces;
using MailSender.Models;

namespace MailSender.Services
{
	public class DebugMailService : IMailService
	{
		private readonly IStatistic _Statistic;

		public DebugMailService(IStatistic Statistic) => _Statistic = Statistic;

		public void SendEmail(string From, string To, string Title, string Body)
		{
			Debug.WriteLine($"Отправка почты от {From} к {To}: {Title} - {Body}");
			_Statistic.MessageSended();
		}

		public void SendEmail(IQueryable<Message> mails)
		{
			foreach (var mail in mails)
			{
				Debug.WriteLine($"Отправка почты от отправитель к получатель: {mail.Title} - {mail.Text}");
				_Statistic.MessageSended();
			}
		}
	}
}