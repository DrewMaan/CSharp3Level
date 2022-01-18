using MailSender.Interfaces;
using MailSender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender.Services
{
	public class MailSchedulerTPL : IMailScheduler
	{
		private readonly IMailService _mailService;
		private readonly IRepository<SchedulerTask> _taskRepository;

		private Task _waitTask;
		private CancellationTokenSource _cancellationTokenSource;
		public MailSchedulerTPL(IMailService mailService, IRepository<SchedulerTask> taskRepository)
		{
			_mailService = mailService;
			_taskRepository = taskRepository;
		}

		public SchedulerTask AddToPlan(DateTime time, Consignor consignor, EmailsList emails, Server server)
		{
			throw new NotImplementedException();
		}

		public void Start()
		{
			var cancellation = new CancellationTokenSource();
			Interlocked.Exchange(ref _cancellationTokenSource, cancellation)?.Cancel();

			var first_task = _taskRepository.GetAll()
				.Where(t => t.Time > DateTime.Now)
				.OrderBy(t => t.Time)
				.FirstOrDefault();

			_waitTask = null;
			if (first_task is null) return;

			_waitTask = WaitAndRunSchedulerTask(first_task, cancellation.Token);
		}

		private async Task WaitAndRunSchedulerTask(SchedulerTask task, CancellationToken token)
		{

		}

		public void Stop()
		{
			throw new NotImplementedException();
		}
	}
}
