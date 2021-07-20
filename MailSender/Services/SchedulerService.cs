using System;
using System.Collections.Generic;
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
		private MessageTask _messageTask;
		private Dictionary<DateTime, string> _timeSendAndMessage;

		public TimeSpan GetSendTime(string sendTime)
		{
			TimeSpan tsSendTime = new TimeSpan();
			TimeSpan.TryParse(sendTime, out tsSendTime);
			return tsSendTime;
		}

		public void SendEmails(IMailService mailService, Dictionary<DateTime, string> timeSendAndMessage, MessageTask messageTask)
		{
			this.mailService = mailService;
			_messageTask = messageTask;
			_timeSendAndMessage = timeSendAndMessage;
			dispatcherTimer.Tick += DispatcherTimer_Tick;
			dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
			dispatcherTimer.Start();
		}

		private void DispatcherTimer_Tick(object sender, EventArgs e)
		{
			foreach (var item in _timeSendAndMessage)
			{
				if (item.Key.ToShortTimeString() == DateTime.Now.ToShortTimeString())
				{
					foreach (var recipient in _messageTask.Recipients)
					{
						mailService.SendEmail(_messageTask.Consignor.Address, recipient.Address, _messageTask.Message.Title, item.Value);
					}

					dispatcherTimer.Stop();
					MessageBox.Show("Письма отправлены");
				}
			}
			//if (timeSend.ToShortTimeString() == DateTime.Now.ToShortTimeString())
			//{
			//	//mailService.SendEmail(_messageTask);
			//	dispatcherTimer.Stop();
			//	MessageBox.Show("Письма отправлены");
			//}
		}
	}
}
