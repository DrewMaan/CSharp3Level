using System;
using System.CodeDom;
using System.Collections;
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

namespace MailSender
{
	/// <summary>
	/// Логика взаимодействия для MyToolBar.xaml
	/// </summary>
	public partial class MyToolBar : UserControl
	{
		public MyToolBar()
		{
			InitializeComponent();
			this.DataContext = this;
		}
		

		public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
			"Header", typeof(string), typeof(MyToolBar), new PropertyMetadata(default(string)));

		public string Header
		{
			get { return (string) GetValue(HeaderProperty); }
			set { SetValue(HeaderProperty, value); }
		}

		//public static readonly DependencyProperty ListProperty = DependencyProperty.Register(
		//	"List", typeof(IList<T>), typeof(MyToolBar), new PropertyMetadata(default(IList<T>)));

		//public ObservableCollection<> List
		//{
		//	get { return (IList<T>) GetValue(ListProperty); }
		//	set { SetValue(ListProperty, value); }
		//}

		//public static readonly DependencyProperty ItemsTypeProperty = DependencyProperty.Register(
		//	"ItemsType", typeof(Type), typeof(MyToolBar));

		//public Type ItemsType
		//{
		//	get { return (Type) GetValue(ItemsTypeProperty); }
		//	set { SetValue(ItemsTypeProperty, value); }
		//}
	}
}
