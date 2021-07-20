using System;
using System.Collections.Generic;
using MailSender.Models;

namespace MailSender.Interfaces
{
	public interface ISchedulerService
	{
		TimeSpan GetSendTime(string sendTime);

		void SendEmails(IMailService mailService, Dictionary<DateTime, string> timeSendAndMessage, MessageTask messageTask);
	}
}