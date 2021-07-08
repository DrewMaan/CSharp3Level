using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MailSender.Interfaces;
using MailSender.Models;

namespace MailSender.Services
{
	public class DataStorageInXmlFile : IServerRepository
	{
		public class DataStructure
		{
			public List<Server> Servers { get; set; } = new List<Server>();
		}

		private readonly string _fileName;

		public DataStorageInXmlFile(string fileName) => _fileName = fileName;

		public DataStructure Data { get; set; } = new DataStructure();

		ICollection<Server> IServerRepository.Servers => Data.Servers;

		public void Load()
		{
			if (!File.Exists(_fileName))
			{
				Data = new DataStructure();
				return;
			}

			using (var file = File.OpenText(_fileName))
			{
				if (file.BaseStream.Length == 0)
				{
					Data = new DataStructure();
					return;
				}

				var serializer = new XmlSerializer(typeof(DataStructure));
				Data = (DataStructure) serializer.Deserialize(file);
			}
		}

		public void SaveChanges()
		{
			using (var file = File.CreateText(_fileName))
			{
				var serializer = new XmlSerializer(typeof(DataStructure));
				serializer.Serialize(file, Data);
			}
		}
	}
}
