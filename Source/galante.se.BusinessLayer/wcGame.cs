using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using BusinessLayer.Enumerators;
using System.Runtime.Serialization;

namespace BusinessLayer
{
	[Serializable]
	[DataContract]
    public class wcGame
    {
		[DataMember(IsRequired = false)]
		public wcTeam HomeTeam {get; set;}

		[DataMember(IsRequired = false)]
		public wcTeam AwayTeam { get; set; }

		[DataMember(IsRequired = false)]
		public List<wcResult> Results { get; set; }

		[DataMember(IsRequired = false)]
		public DateTime Date { get; set; }

		[DataMember(IsRequired = false)]
		public string Channel { get; set; }

		[DataMember(IsRequired = false)]
		public int Id { get; set; }

		
		//public wcTeam HomeTeam
		//{
		//    get { return _homeTeam; }
		//    set { _homeTeam = value; }
		//}

		//public wcTeam AwayTeam
		//{
		//    get { return _awayTeam; }
		//    set { _awayTeam = value; }
		//}

		//public List<wcResult> Results
		//{
		//    get { return _results; }
		//    set { _results = value; }
		//}

		//public DateTime Date
		//{
		//    get { return _date; }
		//    set { _date = value; }
		//}

		//public string Channel
		//{
		//    get { return _channel; }
		//    set { _channel = value; }
		//}

        public wcResult FinalResult
        {
            get
            {
                //Kontrollerar om resultat finns
                if (this.Results == null || this.Results.Count <= 0)
                {
                    return null;
                }
                return this.Results[this.Results.Count - 1]; 
            }
        }

        public EnumConstants.WinningTeam WinningTeam
        {
            get 
            {
                if (this.FinalResult == null)
                {
                    return EnumConstants.WinningTeam.Undefined;
                }

                if (this.FinalResult.ResultHomeTeam > this.FinalResult.ResultAwayTeam)
                {
                    return EnumConstants.WinningTeam.Hometeam;
                }
                else if (this.FinalResult.ResultHomeTeam == this.FinalResult.ResultAwayTeam)
                {
                    return EnumConstants.WinningTeam.Draw;
                }
                else
                {
                    return EnumConstants.WinningTeam.Awayteam;
                }
            }
        }


		/// <summary>
        /// Konstruktor
        /// </summary>
		public wcGame()
		{ }

        /// <summary>
        /// Konstruktor
        /// </summary>
        public wcGame(XmlNode node)
        {
            //this.HomeTeam = new wcTeam(node.SelectSingleNode("/game@homeTeam").ToString());
            //this.AwayTeam = new wcTeam(node.SelectSingleNode("/game@awayTeam").ToString());
            //this.Date = DateTime.Parse(node.SelectSingleNode("/game@date").ToString());
            //this.Channel = node.SelectSingleNode("/game@channel").ToString();

            DateTime dateDummy;

			this.Id = int.Parse(node.SelectSingleNode("@id").Value);
            this.HomeTeam = new wcTeam(node.SelectSingleNode("@homeTeam").Value);
            this.AwayTeam = new wcTeam(node.SelectSingleNode("@awayTeam").Value);
            //this.Date = DateTime.Parse(node.SelectSingleNode("@date").Value);
            this.Date = DateTime.TryParse(node.SelectSingleNode("@date").Value, out dateDummy) ? dateDummy : DateTime.MinValue;
            this.Channel = node.SelectSingleNode("@channel").Value;

            


            //Kontrollerar om resultat finns tillgängligt
			//if (node.SelectSingleNode("result") != null && !string.IsNullOrEmpty(node.SelectSingleNode("result").InnerText))
			if (node.SelectSingleNode("result") != null )
            {
                this.CreateResults(node.SelectSingleNode("result"));
            }
        }


        /// <summary>
        /// Metod som skapar matchresultat utifrån xml
        /// </summary>
        /// <param name="node"></param>
        private void CreateResults(XmlNode node)
        {
            this.Results = new List<wcResult>();

            foreach (XmlAttribute a in node.Attributes)
            {
				wcResultHalfTime resultHalfTime;
				if (a.Name == "halftime" && wcResultHalfTime.TryParse(a.Value, out resultHalfTime))
                {
                    this.Results.Add(new wcResultHalfTime(a.Value));
                }

				wcResultFullTime resultFullTime;
				if (a.Name == "fulltime" && wcResultFullTime.TryParse(a.Value, out resultFullTime))
                {
                    this.Results.Add(new wcResultFullTime(a.Value));
                }

				wcResultPenelties resultPenelties;
				if (a.Name == "penelties" && wcResultPenelties.TryParse(a.Value, out resultPenelties))
                {
                    this.Results.Add(new wcResultPenelties(a.Value));
                }
                
            }

			//Om inga resultat och kollektionen är tom sätter vi dit en null-referens
			if (this.Results.Count == 0)
			{
				this.Results = null;
			}

            //if (node.SelectSingleNode("/game/result@halftime") != null)
            //{
            //    this.Results.Add(new wcResultHalfTime(node.SelectSingleNode("/game/result@halftime").ToString()));
            //}
            //if (node.SelectSingleNode("/game/result@fulltime") != null)
            //{
            //    this.Results.Add(new wcResultFullTime(node.SelectSingleNode("/game/result@fulltime").ToString()));
            //}
            //if (node.SelectSingleNode("/game/result@penelties") != null)
            //{
            //    this.Results.Add(new wcResultPenelties(node.SelectSingleNode("/game/result@penelties").ToString()));
            //}
        }


        //public void Play()
        //{

        //}


        //public EnumConstants.WinningTeam WinningTeamFulltime
        //{
        //    get
        //    {
        //        if (this.HomeTeam. HomegoalFulltime > this.AwaygoalFulltime)
        //        {
        //            return EnumConstants.WinningTeam.Hometeam;
        //        }
        //        else if (this.HomegoalFulltime == this.AwaygoalFulltime)
        //        {
        //            return EnumConstants.WinningTeam.Draw;
        //        }
        //        else
        //        {
        //            return EnumConstants.WinningTeam.Awayteam;
        //        }
        //    }
        //}
    }
}
