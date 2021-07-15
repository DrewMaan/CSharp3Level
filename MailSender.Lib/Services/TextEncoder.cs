using System.Linq;

namespace MailSender.Services
{
	public class TextEncoder
	{
		public static string Encode(string pass, int key = 1) => new(pass.Select(c => (char) (c + key)).ToArray());

		public static string Decode(string pass, int key = 1) => new(pass.Select(c => (char) (c - key)).ToArray());
	}
}