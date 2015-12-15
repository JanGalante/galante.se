using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Attributes
{
	public class CountryInfoAttribute : Attribute
	{
		/// <summary>
		/// Håller information om språkkod.
		/// </summary>
		public string LanguageCode { get; set; }
		/// <summary>
		/// Håller info om landskod
		/// </summary>
		public string CountryCode { get; set; }


		/// <summary>
		/// Constructor used to init a StringValue Attribute
		/// </summary>
		/// <param name="value"></param>
		public CountryInfoAttribute(string countryCode)
		{
			this.CountryCode = countryCode;
		}
	}
}
