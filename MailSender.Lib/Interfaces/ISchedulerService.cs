using System;
using MailSender.Models;

namespace MailSender.Interfaces
{
	public interface ISchedulerService
	{
		TimeSpan GetSendTime(string sendTime);

		void SendEmails(IMailService mailService, MessageTask messageTask);
	}
}