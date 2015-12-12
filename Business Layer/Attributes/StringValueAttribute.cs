using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Attributes
{
	//public class StringValueAttribute
	//{
	//}

	/// <summary>
	/// This attribute is used to represent a string value
	/// for a value in an enum.
	/// 
	/// Från http://weblogs.asp.net/stefansedich/archive/2008/03/12/enum-with-string-values-in-c.aspx
	/// Hur man gör custom attributes http://www.codeproject.com/Articles/2933/Attributes-in-C
	/// </summary>
	public class StringValueAttribute : Attribute
	{

		#region Properties

		/// <summary>
		/// Holds the stringvalue for a value in an enum.
		/// </summary>
		public string StringValue { get; protected set; }
	
		#endregion
		

		/// <summary>
		/// Constructor used to init a StringValue Attribute
		/// </summary>
		/// <param name="value"></param>
		public StringValueAttribute(string value)
		{
			this.StringValue = value;
		}
	}

	//public class CountryInfoAttribute : Attribute
	//{
	//    /// <summary>
	//    /// Holds the stringvalue for a value in an enum.
	//    /// </summary>
	//    public string LanguageCode { get; protected set; }
	//    public string CountryCode { get; protected set; }


	//    /// <summary>
	//    /// Constructor used to init a StringValue Attribute
	//    /// </summary>
	//    /// <param name="value"></param>
	//    public CountryInfoAttribute(string countryCode)
	//    {
	//        this.CountryCode = countryCode;
	//    }
	//}
}
