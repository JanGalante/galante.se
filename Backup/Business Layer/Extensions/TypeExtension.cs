using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Extensions.TypeExtension
{
	public static class TypeExtension
	{
		public static T ToType<T>(this object o, T typeToCastTo)
		{
			return (T)o;
		} 
	}
}
