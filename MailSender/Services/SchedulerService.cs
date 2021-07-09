using System;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Threading;
using MailSender.Interfaces;
using MailSender.Models;

namespace MailSender.Services
{
	public class SchedulerService
	{
		private DispatcherTimer dispatcherTimer = new DispatcherTimer();
		private IMailService mailService;
		private DateTime timeSend;
		private IQueryable<Message> mails;

		public TimeSpan GetSendTime(string sendTime)
		{
			TimeSpan tsSendTime = new TimeSpan();
			TimeSpan.TryParse(sendTime, out tsSendTime);
			return tsSendTime;
		}

		public void SendEmails(DateTime timeSend, IMailService mailService, IQueryable<Message> mails)
		{
			this.mailService = mailService;
			this.timeSend = timeSend;
			this.mails = mails;
			dispatcherTimer.Tick += DispatcherTimer_Tick;
			dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
			dispatcherTimer.Start();
		}

		private void DispatcherTimer_Tick(object sender, EventArgs e)
		{
			if (timeSend.ToShortTimeString() == DateTime.Now.ToShortTimeString())
			{
				mailService.SendEmail(mails);
				dispatcherTimer.Stop();
				MessageBox.Show("Письма отправлены");
			}
		}
	}
}
