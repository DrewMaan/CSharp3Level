using Microsoft.Extensions.DependencyInjection;

namespace MailSender.ViewModels
{
	public class ViewModelLocator
	{
		public MainWindowViewModel MainWindowViewModel => App.Services.GetRequiredService<MainWindowViewModel>();
	}
}
