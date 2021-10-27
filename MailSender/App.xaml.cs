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
			services.AddSingleton<MainWindowViewModel>();
			services.AddSingleton<ServersToolBarViewModel>();
			services.AddSingleton<ConsignorsToolBarViewModel>();

			services.AddSingleton<IStatistic, InMemoryStatisticService>();

			services.AddSingleton<IMailService, DebugMailService>();
			//services.AddSingleton<IMailService, SmtpMailService>();

			services.AddSingleton<ISchedulerService, SchedulerService>();

			services.AddScoped<IServerUserDialog, WindowServerUserDialogServer>();
			services.AddScoped<IConsignorUserDialog, WindowConsignorUserDialog>();
			services.AddScoped<ISchedulerItemUserDialog, WindowSchedulerItemUserDialogServer>();

			services.AddSingleton<IRepository<Server>, InMemoryServersRepository>();
			services.AddSingleton<IRepository<Consignor>, InMemoryConsignorsRepository>();
			services.AddSingleton<IRepository<Recipient>, InMemoryRecipientsRepository>();
			services.AddSingleton<IRepository<Message>, InMemoryMessagesRepository>();
			services.AddSingleton<IRepository<MessageTask>, InMemoryMessageTasksRepository>();
			services.AddSingleton<IRepository<SchedulerItem>, InMemorySchedulerItemsRepository>();
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
