using MailSender.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MailSender.Controls
{
	/// <summary>
	/// Логика взаимодействия для ServersToolBarControl.xaml
	/// </summary>
	public partial class ServersToolBar : UserControl
	{
		public ServersToolBar()
		{
			InitializeComponent();
		}

		public static readonly DependencyProperty ServersProperty = DependencyProperty.Register("Servers", typeof(ObservableCollection<Server>), typeof(ServersToolBar));
		public static readonly DependencyProperty SelectedServerProperty = DependencyProperty.Register("SelectedServer", typeof(Server), typeof(ServersToolBar));
		public static readonly DependencyProperty ServersTitleProperty = DependencyProperty.Register("ServersTitle", typeof(string), typeof(ServersToolBar));

		public static readonly DependencyProperty AddCommandProperty = DependencyProperty.Register("AddCommand", typeof(ICommand), typeof(ServersToolBar));
		public static readonly DependencyProperty EditCommandProperty = DependencyProperty.Register("EditCommand", typeof(ICommand), typeof(ServersToolBar));
		public static readonly DependencyProperty RemoveCommandProperty = DependencyProperty.Register("RemoveCommand", typeof(ICommand), typeof(ServersToolBar));

		public ObservableCollection<Server> Servers
		{
			get => (ObservableCollection<Server>)GetValue(ServersProperty);
			set => SetValue(ServersProperty, value);
		}

		public Server SelectedServer
		{
			get => (Server)GetValue(SelectedServerProperty);
			set => SetValue(SelectedServerProperty, value);
		}

		public string ServersTitle
		{
			get => (string)GetValue(ServersTitleProperty);
			set => SetValue(ServersTitleProperty, value);
		}

		#region DP Commands
		public ICommand AddCommand
		{
			get => (ICommand)GetValue(AddCommandProperty);
			set => SetValue(AddCommandProperty, value);
		}

		public ICommand EditCommand
		{
			get => (ICommand)GetValue(EditCommandProperty);
			set => SetValue(EditCommandProperty, value);
		}

		public ICommand RemoveCommand
		{
			get => (ICommand)GetValue(RemoveCommandProperty);
			set => SetValue(RemoveCommandProperty, value);
		}
		#endregion
	}
}
