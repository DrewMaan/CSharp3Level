using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MailSender.Models;

namespace MailSender.ViewModels.Base
{
	public class MyToolBarViewModelBase<T> : ViewModel
	{
		protected string _title;
		private T _selectedItem;

		protected MyToolBarViewModelBase()
		{
		}

		public string Title
		{
			get => _title;
		}

		public T SelectedItem
		{
			get => _selectedItem;
			set => _ = Set(ref _selectedItem, value);
		}

		public ObservableCollection<T> Items { get; } = new ObservableCollection<T>();
	}
}
