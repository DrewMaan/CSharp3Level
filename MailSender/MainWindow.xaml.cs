using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Windows;
using MailSender.Data;
using MailSender.Models;

namespace MailSender
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow() => InitializeComponent();

		//private void MenuExit_OnClick(object sender, RoutedEventArgs e)
		//{
		//	throw new NotImplementedException();
		//}

		//private void OpenScheduler_OnClick(object sender, RoutedEventArgs e)
		//{
		//	TabScheduler.IsSelected = true;
		//}

		//private void AddServer_OnClick(object sender, RoutedEventArgs e)
		//{
		//	ServerEditDialog.Create(out var name, out var address, out var port, out var ssl, out var description,
		//		out var login, out var password);

		//	var server = new Server()
		//	{
		//		Id = TestData.Servers.DefaultIfEmpty().Max(s => s.Id) + 1,
		//		Address = address,
		//		Login = login,
		//		Name = name,
		//		Password = password,
		//		Port = port,
		//		UseSSL = ssl
		//	};

		//	TestData.Servers.Add(server);

		//	ServersList.ItemsSource = null;
		//	ServersList.ItemsSource = TestData.Servers;
		//	ServersList.SelectedItem = server;
		//}

		//private void EditServer_OnClick(object sender, RoutedEventArgs e)
		//{
		//	if(!(ServersList.SelectedItem is Server server)) return;

		//	var name = server.Name;
		//	var address = server.Address;
		//	var port = server.Port;
		//	var ssl = server.UseSSL;
		//	var description = server.Description;
		//	var login = server.Login;
		//	var password = server.Password;

		//	ServerEditDialog.ShowDialog("Редактирование сервера", ref name, ref address, ref port, ref ssl, ref description,
		//		ref login, ref password);

		//	server.Name = name;
		//	server.Address = address;
		//	server.Port = port;
		//	server.UseSSL = ssl;
		//	server.Description = description;
		//	server.Login = login;
		//	server.Password = password;

		//	ServersList.ItemsSource = null;
		//	ServersList.ItemsSource = TestData.Servers;
		//}

		//private void DeleteServer_OnClick(object sender, RoutedEventArgs e)
		//{
		//	if (!(ServersList.SelectedItem is Server server)) return;

		//	TestData.Servers.Remove(server);

		//	ServersList.ItemsSource = null;
		//	ServersList.ItemsSource = TestData.Servers;
		//	ServersList.SelectedIndex = 0;
		//}

		//private void SendNow_OnClick(object sender, RoutedEventArgs e)
		//{
		//	if(!(ConsignorsList.SelectedItem is Consignor consignor)) return;
		//	if(!(RecepientList.SelectedItem is Recipient recepient)) return;
		//	if(!(ServersList.SelectedItem is Server server)) return;
		//	if(!(MessagesList.SelectedItem is Message message)) return;

		//	var mail_sender = new MailSenderService(server.Address, server.Port, server.UseSSL, server.Login,
		//		server.Password);
		//	if(string.IsNullOrEmpty(txtbMessageBody.Text))
		//	{
		//		MessageBox.Show($"Письмо не заполнено", "Отправка почты", MessageBoxButton.OK, MessageBoxImage.Error);
		//		TabMessage.IsSelected = true;
		//		return;
		//	}

		//	try
		//	{
		//		var timer = Stopwatch.StartNew();
		//		mail_sender.SendMessage(consignor.Address, recepient.Address, message.Title, message.Text);
		//		timer.Stop();

		//		MessageBox.Show($"Почта успешно отправлена за {timer.Elapsed.TotalSeconds:0.##}c", "Отправка почты", MessageBoxButton.OK, MessageBoxImage.Information);
		//	}
		//	catch (SmtpException exception)
		//	{
		//		MessageBox.Show("Ошибка при отправке почты", "Отправка почты", MessageBoxButton.OK, MessageBoxImage.Error);
		//	}
		//}

		//private void ConsignorEdit_OnClick(object sender, RoutedEventArgs e)
		//{
		//	if(!(ConsignorsList.SelectedItem is Consignor consignor)) return;

		//	var name = consignor.Name;
		//	var address = consignor.Address;
		//	var description = consignor.Description;

		//	ConsignorEditDialog.ShowDialog("Редактирование отправителя", ref name, ref address, ref description);

		//	consignor.Name = name;
		//	consignor.Address = address;
		//	consignor.Description = description;

		//	ConsignorsList.ItemsSource = null;
		//	ConsignorsList.ItemsSource = TestData.Consignors;
		//	ConsignorsList.SelectedItem = consignor;
		//}

		//private void ConsignorAdd_OnClick(object sender, RoutedEventArgs e)
		//{
		//	ConsignorEditDialog.Create(out var name, out var address, out var description);

		//	Consignor consignor = new Consignor()
		//	{
		//		Name = name,
		//		Address = address,
		//		Description = description
		//	};

		//	TestData.Consignors.Add(consignor);

		//	ConsignorsList.ItemsSource = null;
		//	ConsignorsList.ItemsSource = TestData.Consignors;
		//	ConsignorsList.SelectedItem = consignor;
		//}

		//private void btnSend_Click(object sender, RoutedEventArgs e)
		//{
		//	SchedulerClass sc = new SchedulerClass();
		//	TimeSpan tsSendTime = sc.GetSendTime(tbTimePicker.Text);
		//	if (tsSendTime == new TimeSpan())
		//	{
		//		MessageBox.Show("Некорректный формат даты");
		//		return;
		//	}
		//	DateTime dtSendDateTime = (cldSchedulDateTimes.SelectedDate ?? DateTime.Today).Add(tsSendTime);
		//	if (dtSendDateTime < DateTime.Now)
		//	{
		//		MessageBox.Show("Дата и время отправки писем не могут быть раньше, чем настоящее время");
		//		return;
		//	}
		//	EmailSendServiceClass emailSender = new EmailSendServiceClass(cbSenderSelect.Text, cbSenderSelect.SelectedValue.ToString());
		//	sc.SendEmails(dtSendDateTime, emailSender, (IQueryable<Email>)dgEmails.ItemsSource);
		//}

	}
}
