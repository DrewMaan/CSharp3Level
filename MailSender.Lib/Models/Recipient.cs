using System;
using System.ComponentModel;
using MailSender.Models.Base;

namespace MailSender.Models
{
	public class Recipient : Person, IDataErrorInfo
	{
		string IDataErrorInfo.this[string propertyName]
		{
			get
			{
				switch (propertyName)
				{
					case nameof(Name):
						var name = Name;
						if (name is null) return "Строка имени не определена";
						if (name == "") return "Строка имени пуста";
						if (name.Length < 3) return "Имя должно быть больше 2 символов";
						return null;
					default: return null;
				}
			}
		}

		public override string Name
		{
			get => base.Name;
			set
			{
				if (string.IsNullOrEmpty(value))
					throw new ArgumentException("Передано пустое имя", nameof(value));
				base.Name = value;
			}
		}

		string IDataErrorInfo.Error => null;
	}
}
