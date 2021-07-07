using MailSender.ViewModels.Base;
using Microsoft.Extensions.DependencyInjection;

namespace MailSender.ViewModels
{
	public class ViewModelLocator
	{
		public MainWindowViewModel MainWindowViewModel => App.Services.GetRequiredService<MainWindowViewModel>();
		public ServersToolBarViewModel ServersToolBarVM => 
			App.Services.GetRequiredService<ServersToolBarViewModel>();

		public ConsignorsToolBarViewModel ConsignorsToolBarVM =>
			App.Services.GetRequiredService<ConsignorsToolBarViewModel>();
	}
}
