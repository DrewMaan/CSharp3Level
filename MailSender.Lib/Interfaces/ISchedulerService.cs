using System;
using System.Linq;
using MailSender.Models;

namespace MailSender.Interfaces
{
	public interface ISchedulerService
	{
		TimeSpan GetSendTime(string sendTime);

		void SendEmails(DateTime timeSend, IMailService mailService, MessageTask messageTask);
	}
}