using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class wcResultHalfTime : wcResult
    {
        public wcResultHalfTime(string result) : base(result)
        {
            //throw new System.NotImplementedException();
        }

		public static bool TryParse(string value, out wcResultHalfTime result)
		{
			string[] res = value.Split(new char[] { '-' });
			if (string.IsNullOrEmpty(value) || res.Length < 1)
			{
				result = null; //new wcResultHalfTime(value);
				return false;
			}

			result = new wcResultHalfTime(value);
			return true;
		}
    }
}
