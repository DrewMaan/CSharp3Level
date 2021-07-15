using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace MailSender.Infrastructure.Validation
{
	public class RegexValidation : ValidationRule
	{
		private Regex _regex;

		public string Pattern
		{
			get => _regex.ToString();
			set => _regex = string.IsNullOrEmpty(value) ? null : new(value);
		}

		public bool AllowNull { get; set; }

		public string ErroeMessage { get; set; }

		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			//return ValidationResult.ValidResult;
			//return new ValidationResult(true / false, "Текст ошибки при false");
			if (value is null)
				return AllowNull
					? ValidationResult.ValidResult
					: new ValidationResult(false, ErroeMessage ?? "Пустая ссылка");

			if(_regex is null) return ValidationResult.ValidResult;

			if (value is not string input)
				input = value.ToString();

			return _regex.IsMatch(input ?? "")
				? ValidationResult.ValidResult
				: new ValidationResult(false,
					ErroeMessage ?? $"Строка {input} не удовлетворяет регулярному выражению {Pattern}");
		}
	}
}