using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class wcResultPenelties : wcResult
    {
        public wcResultPenelties(string result) : base(result)
        {
            //throw new System.NotImplementedException();
        }


		public static bool TryParse(string value, out wcResultPenelties result)
		{
			string[] res = value.Split(new char[] { '-' });
			if (string.IsNullOrEmpty(value) || res.Length < 1)
			{
				result = null; //new wcResultPenelties(value);
				return false;
			}

			result = new wcResultPenelties(value);
			return true;
		}
    }
}
