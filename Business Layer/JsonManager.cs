using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;

namespace BusinessLayer
{
	/// <summary>
	/// http://stackoverflow.com/questions/1212344/parse-json-in-c-sharp
	/// 
	/// En annan finns här http://www.codeproject.com/Articles/43317/Saving-ASP-NET-Form-Data-with-jQuery-AJAX-and-JSON
	/// </summary>
	public class JsonManager
	{
		public static string Serialize<T>(T obj)
		{
			DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
			using (MemoryStream ms = new MemoryStream())
			{
				serializer.WriteObject(ms, obj);
				return Encoding.Default.GetString(ms.ToArray());
			}
		}

		public static T Deserialise<T>(string json)
		{
			//T obj = Activator.CreateInstance<T>();
			//MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
			//DataContractJsonSerializer serialiser = new DataContractJsonSerializer(obj.GetType());
			//ms.Close();
			//return obj;

			T obj = Activator.CreateInstance<T>();
			using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
			{
				DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
				obj = (T)serializer.ReadObject(ms); // <== Your missing line
				return obj;
			} 
		}
	}
}
