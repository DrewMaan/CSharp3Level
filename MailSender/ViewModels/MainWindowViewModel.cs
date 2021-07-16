﻿using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using MailSender.Data;
using MailSender.Infrastructure.Commands;
using MailSender.Interfaces;
using MailSender.Models;
using MailSender.ViewModels.Base;

namespace MailSender.ViewModels
{
	public class MainWindowViewModel : ViewModel
	{
		private readonly IRepository<Server> _serversRepository;
		private readonly IRepository<Consignor> _consignorsRepository;
		private readonly IRepository<Recipient> _recipientsRepository;
		private readonly IRepository<Message> _messagesRepository;
		private readonly IRepository<MessageTask> _messageTaskRepository;
		private readonly ISchedulerService _schedulerService;
		private readonly IMailService _MailService;
		private readonly IStatistic _Statistic;

		public MainWindowViewModel(IRepository<Server> serversRepository,
			IRepository<Consignor> consignorsRepository,
			IRepository<Recipient> recipientsRepository,
			IRepository<Message> messagesRepository,
			IRepository<MessageTask> messageTaskRepository,
			ISchedulerService schedulerService,
			IMailService mailService, 
			IStatistic statistic)
		{
			_serversRepository = serversRepository;
			_consignorsRepository = consignorsRepository;
			_recipientsRepository = recipientsRepository;
			_messagesRepository = messagesRepository;
			_messageTaskRepository = messageTaskRepository;
			_schedulerService = schedulerService;
			_MailService = mailService;
			_Statistic = statistic;
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

		private ObservableCollection<Server> _servers;

		/// <summary>
		/// Список серверов
		/// </summary>
		public ObservableCollection<Server> Servers = new ObservableCollection<Server>();

		private ObservableCollection<Consignor> _consignors;
		/// <summary>
		/// Список отправителей
		/// </summary>
		public ObservableCollection<Consignor> Consignors
		{
			get => _consignors;
			set => _ = Set(ref _consignors, value);
		}

		private ObservableCollection<Recipient> _recipients;
		/// <summary>
		/// Список получателей
		/// </summary>
		public ObservableCollection<Recipient> Recipients
		{
			get => _recipients;
			set => _ = Set(ref _recipients, value);
		}

		private Recipient _selectedRecipient;

		public Recipient SelectedRecipient
		{
			get => _selectedRecipient;
			set => _ = Set(ref _selectedRecipient, value);
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

		private ObservableCollection<MessageTask> _messageTasks;
		/// <summary>
		/// Список заданий
		/// </summary>
		public ObservableCollection<MessageTask> MessageTasks
		{
			get => _messageTasks;
			set => _ = Set(ref _messageTasks, value);
		}

		private MessageTask _selectedMessageTask;
		/// <summary>
		/// Список заданий
		/// </summary>
		public MessageTask SelectedMessageTask
		{
			get => _selectedMessageTask;
			set => _ = Set(ref _selectedMessageTask, value);
		}

		private DateTime? _timeSend;

		public DateTime? TimeSend
		{
			get => _timeSend;
			set => _ = Set(ref _timeSend, value);
		}

		private ICommand _LoadDataCommand;

		public ICommand LoadDataCommand => _LoadDataCommand ??= new LambdaCommand(OnLoadDataCommandExecuted);

		private void OnLoadDataCommandExecuted(object p)
		{
			Servers = new ObservableCollection<Server>(TestData.Servers);
			Consignors = new ObservableCollection<Consignor>(TestData.Consignors); 
			Recipients = new ObservableCollection<Recipient>(TestData.Recipients); 
			Messages = new ObservableCollection<Message>(TestData.Messages);
			MessageTasks = new ObservableCollection<MessageTask>(_messageTaskRepository.GetAll());
		}

		private ICommand _ExitCommand;

		public ICommand ExitCommand => _ExitCommand
			??= new LambdaCommand(OnExitCommandExecuted);

		private static void OnExitCommandExecuted(object _)
		{
			Application.Current.Shutdown();
		}

		#region Command LoadServersCommand - Загрузка серверов

		/// <summary>Загрузка серверов</summary>
		private LambdaCommand _LoadServersCommand;

		/// <summary>Загрузка серверов</summary>
		public ICommand LoadServersCommand => _LoadServersCommand
			??= new(OnLoadServersCommandExecuted);

		/// <summary>Логика выполнения - Загрузка серверов</summary>
		private void OnLoadServersCommandExecuted(object p)
		{
			Servers.Clear();
			foreach (var server in _serversRepository.GetAll())
				Servers.Add(server);
		}

		#endregion

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

		#region Command ScheduleMessageCommand - Отправка почты

		/// <summary>Отправка почты</summary>
		private LambdaCommand _scheduleMessageCommand;

		/// <summary>Отправка почты</summary>
		public ICommand ScheduleMessageCommand => _scheduleMessageCommand
			??= new(OnScheduleMessageCommandExecuted);

		/// <summary>Логика выполнения - Отправка почты</summary>
		private void OnScheduleMessageCommandExecuted(object p)
		{
			if (TimeSend is null)
			{
				MessageBox.Show("Время отправки писем не задано!", "Ошибка планировщика", MessageBoxButton.OK,
					MessageBoxImage.Error);
				return;
			}

			_schedulerService.SendEmails(TimeSend.Value, _MailService, SelectedMessageTask);
		}

		#endregion
	}
}
