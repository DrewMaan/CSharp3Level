using MailSender.Interfaces;
using MailSender.Models;
using MailSender.ViewModels;
using MailSender.Views;

namespace MailSender.Services
{
	public class WindowSchedulerItemUserDialogServer : ISchedulerItemUserDialog
	{
		public bool EditSchedulerItem(SchedulerItem schedulerItem)
		{

			var model = new SchedulerItemEditDialogViewModel
			{
				MessageBody = schedulerItem.MessageBody
			};

			var view = new SchedulerItemEditDialog
			{
				DataContext = model
			};

			model.EditCompleted += (s, e) =>
			{
				view.DialogResult = true;
				view.Close();
			};

			model.EditCanceled += (s, e) =>
			{
				view.DialogResult = false;
				view.Close();
			};

			if (view.ShowDialog() != true)
				return false;

			schedulerItem.MessageBody = model.MessageBody;

			return true;
		}

		public bool AddSchedulerItem(out SchedulerItem schedulerItem)
		{
			schedulerItem = new SchedulerItem();

			var model = new SchedulerItemEditDialogViewModel
			{
				MessageBody = null
			};

			var view = new SchedulerItemEditDialog
			{
				DataContext = model
			};

			model.EditCompleted += (s, e) =>
			{
				view.DialogResult = true;
				view.Close();
			};

			model.EditCanceled += (s, e) =>
			{
				view.DialogResult = false;
				view.Close();
			};

			if (view.ShowDialog() != true)
				return false;

			schedulerItem.MessageBody = model.MessageBody;

			return true;
		}
	}
}