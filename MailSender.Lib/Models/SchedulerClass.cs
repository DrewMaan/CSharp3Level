using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Timer = System.Timers.Timer;
using System.Windows;


namespace MailSender.Models
{
	class SchedulerClass
	{
		private Timer _timer;
		private MailSenderService _mailSenderService;
		private DateTime _dtSend;
		private IQueryable<Message> _messages;

		/// <summary>
		/// Метод, который превращает строку из текстбокса tbTimePicker в TimeSpan
		/// </summary>
		/// <param name="strSendTime"></param>
		/// <returns></returns>
		public TimeSpan GetSendTime(string strSendTime)
		{
			TimeSpan tsSendTime = new TimeSpan();
			try
			{
				tsSendTime = TimeSpan.Parse(strSendTime);
			}
			catch { }
			return tsSendTime;
		}

		/// <summary>
		//// Непосредственно отправка писем
		/// </summary>
		/// <param name="dtSend"></param>
		/// <param name="emailSender"></param>
		/// <param name="emails"></param>
		public void SendEmails(DateTime dtSend, MailSenderService mailSenderService, IQueryable<Message> messages)
		{
			_mailSenderService = mailSenderService; // Экземпляр класса, отвечающего за отправку писем, присваиваем 
			_dtSend = dtSend;
			_messages = messages;
			_timer.Elapsed += OnTimerEvent;
			_timer.Interval = 2000;
			_timer.AutoReset = true;
			_timer.Enabled = true;
		}

		private void OnTimerEvent(object sender, EventArgs e)
		{
			if (_dtSend.ToShortTimeString() == DateTime.Now.ToShortTimeString())
			{
				_mailSenderService.SendMails(_messages);
				MessageBox.Show("Письма отправлены.");
			}
		}


	}
}
