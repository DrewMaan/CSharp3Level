using System;
using MailSender.TestWPF.Infrastructure.Commands.Base;

namespace MailSender.TestWPF.Infrastructure.Commands
{
	public class LambdaCommand : Command
	{
		public readonly Action<object> execute;
		public readonly Func<object, bool> canExecute;

		public LambdaCommand(Action<object> execute, Func<object, bool> canExecute = null)
		{
			this.execute = execute;
			this.canExecute = canExecute;
		}

		public override bool CanExecute(object parameter) => canExecute?.Invoke(parameter) ?? true;

		public override void Execute(object parameter) => execute(parameter);
	}
}
