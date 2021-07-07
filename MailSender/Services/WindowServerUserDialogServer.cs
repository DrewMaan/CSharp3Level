using MailSender.Interfaces;
using MailSender.Models;
using MailSender.ViewModels;
using MailSender.Views;

namespace MailSender.Services
{
	class WindowServerUserDialogServer : IServerUserDialog
	{
		public bool EditServer(Server server)
		{
			var model = new ServersEditDialogViewModel
			{
				Name = server.Name,
				Address = server.Address,
				Port = server.Port,
				UseSSL = server.UseSSL,
				Login = server.Login,
				Password = server.Password,
				Descriprion = server.Description
			};

			var view = new ServerEditDialog
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

			server.Name = model.Name;
			server.Address = model.Address;
			server.Port = model.Port;
			server.UseSSL = model.UseSSL;
			server.Login = model.Login;
			server.Password = model.Password;
			server.Description = model.Descriprion;

			return true;
		}

		public bool AddServer(out Server server)
		{
			server = new Server();

			var model = new ServersEditDialogViewModel
			{
				Name = null,
				Address = null,
				Port = 25,
				UseSSL = false,
				Login = null,
				Password = null,
			};

			var view = new ServerEditDialog
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

			server.Name = model.Name;
			server.Address = model.Address;
			server.Port = model.Port;
			server.UseSSL = model.UseSSL;
			server.Login = model.Login;
			server.Password = model.Password;

			return true;
		}
	}
}
