using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MailSender.Controls
{
	/// <summary>
	/// Логика взаимодействия для SchedulerListViewItem.xaml
	/// </summary>
	public partial class SchedulerListViewItem : UserControl
	{
		public static DependencyProperty TimeValueProperty = DependencyProperty.Register("TimeValue", typeof(TimeSpan), typeof(SchedulerListViewItem), new PropertyMetadata(TimeSpan.Zero));

		public SchedulerListViewItem()
		{
			InitializeComponent();
		}

		public TimeSpan TimeValue
		{
			get => (TimeSpan)GetValue(TimeValueProperty);
			set => SetValue(TimeValueProperty, value);
		}
	}
}
