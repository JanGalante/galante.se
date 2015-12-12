using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class wcResultFullTime : wcResult
    {
        public wcResultFullTime(string result) : base(result)
        {
            //throw new System.NotImplementedException();
        }

		///// <summary>
		///// Metod för att parse:a string till Resultat
		///// Vi antar att resultat kommer in på formeln 4-5 eller 4 - 5
		///// </summary>
		///// <param name="result"></param>
		///// <returns></returns>
		//public static wcResultFullTime Parse(string value)
		//{
		//    string[] temp = value.Split('-');
		//    wcResultFullTime result = new wcResultFullTime();
		//    result.ResultHomeTeam = int.Parse(temp[0].Trim());
		//    result.ResultAwayTeam = int.Parse(temp[1].Trim());
		//}


		public static bool TryParse(string value, out wcResultFullTime result)
		{
			string[] res = value.Split(new char[] { '-' });
			if (string.IsNullOrEmpty(value) || res.Length < 1)
			{
				result = null; //new wcResultFullTime(value);
				return false;
			}

			result = new wcResultFullTime(value);
			return true;
		}
    }
}
