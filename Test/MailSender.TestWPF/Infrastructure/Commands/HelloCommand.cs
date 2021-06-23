using System;
using System.Windows;
using System.Windows.Input;

namespace MailSender.TestWPF.Infrastructure.Commands
{
	public class HelloCommand : ICommand
	{
		public event EventHandler CanExecuteChanged
		{
			add => CommandManager.RequerySuggested += value;
			remove => CommandManager.RequerySuggested -= value;
		}

		private int counter = 3;

		public bool CanExecute(object parameter) => counter > 0;

		public void Execute(object parameter)
		{
			counter--;
			MessageBox.Show("Всем привет!");
		}
	}
}
