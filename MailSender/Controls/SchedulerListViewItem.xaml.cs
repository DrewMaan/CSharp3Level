using System;
using System.Windows;
using System.Windows.Input;
using MailSender.Models;

namespace MailSender.Controls
{
	/// <summary>
	/// Логика взаимодействия для SchedulerListViewItem.xaml
	/// </summary>
	public partial class SchedulerListViewItem
	{
		public static DependencyProperty TimeValueProperty = DependencyProperty.Register("TimeValue", 
																					typeof(TimeSpan), 
																					typeof(SchedulerListViewItem), 
																							  new PropertyMetadata(TimeSpan.Zero));
		public static DependencyProperty EditItemCommandProperty = DependencyProperty.Register("EditItemCommand",
																								typeof(ICommand),
																								typeof(SchedulerListViewItem));
		public static DependencyProperty DeleteItemCommandProperty = DependencyProperty.Register("DeleteItemCommand",
																									typeof(ICommand),
																									typeof(SchedulerListViewItem));
		public static DependencyProperty ItemCommandParameterProperty = DependencyProperty.Register("ItemCommandParameter", 
																											typeof(SchedulerItem), 
																											  typeof(SchedulerListViewItem));

		public SchedulerListViewItem()
		{
			InitializeComponent();
		}

		public TimeSpan TimeValue
		{
			get => (TimeSpan)GetValue(TimeValueProperty);
			set => SetValue(TimeValueProperty, value);
		}

		public ICommand EditItemCommand
		{
			get => (ICommand) GetValue(EditItemCommandProperty);
			set => SetValue(EditItemCommandProperty, value);
		}

		public ICommand DeleteItemCommand
		{
			get => (ICommand)GetValue(DeleteItemCommandProperty);
			set => SetValue(DeleteItemCommandProperty, value);
		}

		public SchedulerItem ItemCommandParameter
		{
			get => (SchedulerItem)GetValue(ItemCommandParameterProperty);
			set => SetValue(ItemCommandParameterProperty, value);
		}
	}
}
