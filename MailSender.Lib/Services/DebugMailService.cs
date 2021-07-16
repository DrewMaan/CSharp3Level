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

		public void SendEmail(MessageTask messageTask)
		{
			foreach (var recipient in messageTask.Recipients)
			{
				SendEmail(messageTask.Consignor.Address, 
						recipient.Address, 
						messageTask.Message.Title, 
						messageTask.Message.Text);
			}
		}
	}
}