using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using MailSender.Data;
using MailSender.Infrastructure.Commands;
using MailSender.Interfaces;
using MailSender.Models;
using MailSender.Servcies;
using MailSender.ViewModels.Base;

namespace MailSender.ViewModels
{
	public class MainWindowViewModel : ViewModel
	{
		private readonly ServersRepository _serversRepository;
		private readonly IMailService _MailService;
		private readonly IStatistic _Statistic;
		private readonly ServersToolBarViewModel _serversToolBarViewModel;

		public MainWindowViewModel(ServersRepository serversRepository, IMailService mailService, IStatistic statistic, ServersToolBarViewModel serversToolBarViewModel)
		{
			_serversRepository = serversRepository;
			_MailService = mailService;
			_Statistic = statistic;
			_serversToolBarViewModel = serversToolBarViewModel;
		}

		private string _title = "Рассыльщик почты";
		/// <summary>
		/// Заголовок окна
		/// </summary>
		public string Title
		{
			get => _title;
			set => _ = Set(ref _title, value);
		}

		#region Status : string - Статус

		/// <summary>Статус</summary>
		private string _Status = "Готов!";

		/// <summary>Статус</summary>
		public string Status { get => _Status; set => Set(ref _Status, value); }

		#endregion

		public Server SelectedServer => _serversToolBarViewModel.SelectedItem;

		private ObservableCollection<Recipient> _recipients;
		/// <summary>
		/// Список получателей
		/// </summary>
		public ObservableCollection<Recipient> Recipients
		{
			get => _recipients;
			set => _ = Set(ref _recipients, value);
		}

		private ObservableCollection<Message> _messages;
		/// <summary>
		/// Список писем
		/// </summary>
		public ObservableCollection<Message> Messages
		{
			get => _messages;
			set => _ = Set(ref _messages, value);
		}

		private ICommand _LoadDataCommand;

		public ICommand LoadDataCommand => _LoadDataCommand ??= new LambdaCommand(OnLoadDataCommandExecuted);

		private void OnLoadDataCommandExecuted(object p)
		{
			Recipients = new ObservableCollection<Recipient>(TestData.Recipients); 
			Messages = new ObservableCollection<Message>(TestData.Messages);
		}

		private ICommand _ExitCommand;

		public ICommand ExitCommand => _ExitCommand
			??= new LambdaCommand(OnExitCommandExecuted);

		private static void OnExitCommandExecuted(object _)
		{
			Application.Current.Shutdown();
		}

		#region Command SendMessageCommand - Отправка почты

		/// <summary>Отправка почты</summary>
		private LambdaCommand _SendMessageCommand;

		/// <summary>Отправка почты</summary>
		public ICommand SendMessageCommand => _SendMessageCommand
			??= new(OnSendMessageCommandExecuted);

		/// <summary>Логика выполнения - Отправка почты</summary>
		private void OnSendMessageCommandExecuted(object p)
		{
			_MailService.SendEmail("Отправитель", "Получатель", "Тема", "Тело письма");
		}

		#endregion
	}
}
