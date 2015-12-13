using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using BusinessLayer.Attributes;

namespace BusinessLayer.Extensions.EnumExtension
{
	public static class EnumExtension
	{
		/// <summary>
		/// Will get the string value for a given enums value, this will
		/// only work if you assign the StringValue attribute to
		/// the items in your enum.
		/// 
		/// Från http://weblogs.asp.net/stefansedich/archive/2008/03/12/enum-with-string-values-in-c.aspx
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetStringValue(this Enum value)
		{
			// Get the type
			Type type = value.GetType();

			// Get fieldinfo for this type
			FieldInfo fieldInfo = type.GetField(value.ToString());

			// Get the stringvalue attributes
			StringValueAttribute[] attribs = fieldInfo.GetCustomAttributes(
				typeof(StringValueAttribute), false) as StringValueAttribute[];

			// Return the first if there was a match.
			return attribs.Length > 0 ? attribs[0].StringValue : null;
		}
	}
}
