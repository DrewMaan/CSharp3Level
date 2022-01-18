using System;
using System.Windows;
using MailSender.Interfaces;
using MailSender.Models;
using MailSender.Services;
using MailSender.Services.InMemory;
using MailSender.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MailSender
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private static IHost _hosting;

		public static IHost Hosting
		{
			get
			{
				if (_hosting != null) return _hosting; 
				var host_builder = Host.CreateDefaultBuilder(Environment.GetCommandLineArgs());
				host_builder.ConfigureServices(ConfigureServices);
				return _hosting = host_builder.Build();
			}
		}

		public static IServiceProvider Services => Hosting.Services;

		private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
		{
			services.AddScoped<MainWindowViewModel>();

			services.AddScoped<IStatistic, InMemoryStatisticService>();

			services.AddScoped<IMailService, DebugMailService>();
			//services.AddSingleton<IMailService, SmtpMailService>();

			services.AddScoped<ISchedulerService, SchedulerService>();

			services.AddScoped<IServerUserDialog, WindowServerUserDialogServer>();
			services.AddScoped<IConsignorUserDialog, WindowConsignorUserDialog>();
			services.AddScoped<ISchedulerItemUserDialog, WindowSchedulerItemUserDialogServer>();

			services.AddScoped<IRepository<Server>, InMemoryServersRepository>();
			services.AddScoped<IRepository<Consignor>, InMemoryConsignorsRepository>();
			services.AddScoped<IRepository<Recipient>, InMemoryRecipientsRepository>();
			services.AddScoped<IRepository<Message>, InMemoryMessagesRepository>();
			services.AddScoped<IRepository<MessageTask>, InMemoryMessageTasksRepository>();
			services.AddScoped<IRepository<SchedulerItem>, InMemorySchedulerItemsRepository>();
		}

		protected override void OnStartup(StartupEventArgs e)
		{
			Hosting.Start();
			base.OnStartup(e);

			//var services = new ServiceCollection();
			//services.AddScoped<MainWindowViewModel>();
		}

		protected override void OnExit(ExitEventArgs e)
		{
			base.OnExit(e);
			Hosting.Dispose();
		}
	}
}
