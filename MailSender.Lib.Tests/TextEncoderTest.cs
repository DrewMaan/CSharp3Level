using System;
using System.Collections.Generic;
using System.Text;
using MailSender.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MailSender.Lib.Tests
{
	[TestClass]
	public class TextEncoderTest
	{
		[TestMethod]
		public void Encode_ABC_return_BCD_with_key_default()
		{
			//AAA

			//Arange - подготовка данных
			var pass = "ABC";
			var expected = "BCD";

			//Act - действие, нацеленное на тестирование кода
			var actual = TextEncoder.Encode(pass);

			//Assert - проверка утверждений
			Assert.AreEqual(expected, actual);

			//StringAssert.Matches();
			//CollectionAssert.AreEquivalent();
		}

		[TestMethod]
		public void Decode_BCD_return_ABC_with_key_default()
		{
			//AAA

			//Arange - подготовка данных
			var pass = "BCD";
			var expected = "ABC";

			//Act - действие, нацеленное на тестирование кода
			var actual = TextEncoder.Decode(pass);

			//Assert - проверка утверждений
			Assert.AreEqual(expected, actual);

			//StringAssert.Matches();
			//CollectionAssert.AreEquivalent();
		}
	}
}
