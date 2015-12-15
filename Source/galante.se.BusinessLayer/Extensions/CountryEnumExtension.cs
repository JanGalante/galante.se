using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using BusinessLayer.Attributes;
using BusinessLayer.Enumerators;


namespace BusinessLayer.Extensions.CountryEnumExtension
{
	public static class CountryEnumExtension
	{
		/// <summary>
		/// Metod för att hämta ut information om landskod från 
		/// attributet CountryInfoAttribute. Observera att denna extension method
		/// endast kommer vara tillgänglig för enum av typen <code>Country</code>.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetCountryCode(this EnumConstants.Country value)
		{
			// Get the type
			Type type = value.GetType();

			// Get fieldinfo for this type
			FieldInfo fieldInfo = type.GetField(value.ToString());

			// Get the stringvalue attributes
			CountryInfoAttribute[] attribs = fieldInfo.GetCustomAttributes(
				typeof(CountryInfoAttribute), false) as CountryInfoAttribute[];

			// Return the first if there was a match.
			return attribs.Length > 0 ? attribs[0].CountryCode : null;
		}
	}
}
