using MailSender.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
	/// Логика взаимодействия для ConsignorsToolbBar.xaml
	/// </summary>
	public partial class ConsignorsToolbBar : UserControl
	{
		public ConsignorsToolbBar()
		{
			InitializeComponent();
		}

		public static readonly DependencyProperty ConsignorsProperty = DependencyProperty.Register("Consignors", typeof(ObservableCollection<Consignor>), typeof(ConsignorsToolbBar));
		public static readonly DependencyProperty SelectedConsignorProperty = DependencyProperty.Register("SelectedConsignor", typeof(Consignor), typeof(ConsignorsToolbBar));
		public static readonly DependencyProperty ConsignorsTitleProperty = DependencyProperty.Register("ConsignorsTitle", typeof(string), typeof(ConsignorsToolbBar));

		public static readonly DependencyProperty AddCommandProperty = DependencyProperty.Register("AddCommand", typeof(ICommand), typeof(ConsignorsToolbBar));
		public static readonly DependencyProperty EditCommandProperty = DependencyProperty.Register("EditCommand", typeof(ICommand), typeof(ConsignorsToolbBar));
		public static readonly DependencyProperty RemoveCommandProperty = DependencyProperty.Register("RemoveCommand", typeof(ICommand), typeof(ConsignorsToolbBar));

		public ObservableCollection<Consignor> Consignors
		{
			get => (ObservableCollection<Consignor>)GetValue(ConsignorsProperty);
			set => SetValue(ConsignorsProperty, value);
		}

		public Consignor SelectedConsignor
		{
			get => (Consignor)GetValue(SelectedConsignorProperty);
			set => SetValue(SelectedConsignorProperty, value);
		}

		public string ConsignorsTitle
		{
			get => (string)GetValue(ConsignorsTitleProperty);
			set => SetValue(ConsignorsTitleProperty, value);
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
