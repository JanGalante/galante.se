using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace BusinessLayer
{
    public abstract class wcResult
    {
        private int _resultAwayTeam;
        private int _resultHomeTeam;

        public int ResultAwayTeam
        {
            get { return _resultAwayTeam; }
            set { _resultAwayTeam = value; }
        }

        public int ResultHomeTeam
        {
            get { return _resultHomeTeam; }
            set { _resultHomeTeam = value; }
        }

        /// <summary>
        /// Konstukror
        /// </summary>
        /// <param name="node"></param>
        public wcResult(string result)
        {
			//int dummy;

            string[] res = result.Split(new char[]{'-'});
			//if (string.IsNullOrEmpty(result) || res.Length < 1 || !int.TryParse(res[0], out dummy) || !int.TryParse(res[1], out dummy))
			if (string.IsNullOrEmpty(result) || res.Length < 1)
	        {
        		 throw new InvalidOperationException("Resultatet har inte skickats in på korrekt format till konstruktor");
	        }
            this.ResultHomeTeam = int.Parse(res[0].Trim());
            this.ResultAwayTeam = int.Parse(res[1].Trim());

			//int.TryParse(res[0], out dummy);
			//int.TryParse(res[1], out dummy);
                
        }
        //public wcResult(XmlNode node)
        //{
        //    //throw new System.NotImplementedException();
        //    this.ResultAwayTeam = node.SelectSingleNode("");
        //}

    }
}
