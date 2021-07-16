using System;
using System.Windows;
using System.Windows.Threading;
using MailSender.Interfaces;
using MailSender.Models;

namespace MailSender.Services
{
	public class SchedulerService : ISchedulerService
	{
		private DispatcherTimer dispatcherTimer = new DispatcherTimer();
		private IMailService mailService;
		private DateTime timeSend;
		private MessageTask _messageTask;

		public TimeSpan GetSendTime(string sendTime)
		{
			TimeSpan tsSendTime = new TimeSpan();
			TimeSpan.TryParse(sendTime, out tsSendTime);
			return tsSendTime;
		}

		public void SendEmails(IMailService mailService, MessageTask messageTask)
		{
			this.mailService = mailService;
			_messageTask = messageTask;
			dispatcherTimer.Tick += DispatcherTimer_Tick;
			dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
			dispatcherTimer.Start();
		}

		private void DispatcherTimer_Tick(object sender, EventArgs e)
		{
			if (timeSend.ToShortTimeString() == DateTime.Now.ToShortTimeString())
			{
				mailService.SendEmail(_messageTask);
				dispatcherTimer.Stop();
				MessageBox.Show("Письма отправлены");
			}
		}
	}
}
