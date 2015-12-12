using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using BusinessLayer.Enumerators;
using System.Runtime.Serialization;

namespace BusinessLayer
{
	[Serializable]
    public class wcGameCollection : List<wcGame> //ItemCollectionBase<wcGame>
    {
		[DataMember]
		public string Name { get; private set; }
		private List<wcTeam> _teams;

        public List<wcTeam> Teams
        {
            get { return _teams; }
            set { _teams = value; }
        }



        ///// <summary>
        ///// Konstruktor
        ///// </summary>
        ///// <param name="doc"></param>
        //public wcGameCollection(XmlDocument doc)
        //{
        //    foreach (XmlNode node in doc.SelectNodes("/tournement/group[@name='A']/game"))
        //    {
        //        wcGame game = new wcGame(node);
        //        this.Add(game);
        //    }

        //    //Skapar de lag som är med i turneringen
        //    CreateTeams();

        //    //Spelar matcher
        //    foreach (wcGame game in this)
        //    {
        //        //game.Play();
        //        this.PlayGame(game);
        //    }

        //    //Sorterar
        //    this.Teams.Sort(wcGameCollection.PointComparison);
        //}

		public wcGameCollection()
		{
		}

		
		public wcGameCollection(string name)
		{ 
			this.Name = name;
		}


        public void CreateTeams()
        {
            this.Teams = new List<wcTeam>();

            foreach (wcGame game in this)
            {
                if (this.Teams.Contains(game.HomeTeam) == false)
                {
                    this.Teams.Add(game.HomeTeam);
                    //game.HomeTeam = Teams[Teams.Count];
                }
                if (this.Teams.Contains(game.AwayTeam) == false)
                {
                    this.Teams.Add(game.AwayTeam);
                }
            }

            

        }


        public void PlayGame(wcGame game)
        {
			//Kontrollerar om det finns ett slutresultat, annars kan matchen inte spelas
			//Går inte att räkna upp lagens poäng och så vidare.
			if (game.FinalResult == null)
			{
				return;
			}

			//Finds the team in the collection that matcher the hometeam (in the game).
            //Detta görs för att de två inte är samma instans. Det är instansen i kollektionen 
            //vi vill använda
            wcTeam homeTeam = this.Teams.Find(delegate(wcTeam team)
            {
                //return team == game.HomeTeam;
                return team.Equals(game.HomeTeam);
            }
            );

            wcTeam awayTeam = this.Teams.Find(delegate(wcTeam team)
            {
                //return team == game.AwayTeam;
                return team.Equals(game.AwayTeam);
            }
            );

			

            homeTeam.GamesPlayed++;
            homeTeam.GoalsMade += game.FinalResult != null ? game.FinalResult.ResultHomeTeam : 0;
            homeTeam.GoalsBackward += game.FinalResult != null ? game.FinalResult.ResultAwayTeam : 0;

            awayTeam.GamesPlayed++;
            awayTeam.GoalsMade += game.FinalResult != null ? game.FinalResult.ResultAwayTeam : 0;
            awayTeam.GoalsBackward += game.FinalResult != null ? game.FinalResult.ResultHomeTeam : 0;
            

            //homeTeam.Points = game.WinningTeam == EnumConstants.WinningTeam.Hometeam
            switch (game.WinningTeam)
            {
                case EnumConstants.WinningTeam.Hometeam:
                    homeTeam.GamesWon++;
                    homeTeam.Points += 3;
                    break;
                case EnumConstants.WinningTeam.Draw:
                    homeTeam.GamesDraw++;
                    homeTeam.Points++;
                    break;
                case EnumConstants.WinningTeam.Awayteam:
                    homeTeam.GamesLost++;
                    break;
                //case EnumConstants.WinningTeam.Undefined:
                //default:
                //    throw new System.Exception("WinningTeam id undefined");
            }


            switch (game.WinningTeam)
            {
                case EnumConstants.WinningTeam.Awayteam:
                    awayTeam.GamesWon++;
                    awayTeam.Points += 3;
                    break;
                case EnumConstants.WinningTeam.Draw:
                    awayTeam.GamesDraw++;
                    awayTeam.Points++;
                    break;
                case EnumConstants.WinningTeam.Hometeam:
                    awayTeam.GamesLost++;
                    break;
                //case EnumConstants.WinningTeam.Undefined:
                //default:
                //    throw new System.Exception("WinningTeam id undefined");
            }

            //bool isHomeTeam = this.Name == game.HomeTeam.Name ? true : false;

            //this.GoalsMade += isHomeTeam ? (int)game.HomegoalFulltime : (int)game.AwaygoalFulltime;
            //this.GoalsBackward += isHomeTeam ? (int)game.AwaygoalFulltime : (int)game.HomegoalFulltime;

            //this.GamesPlayed++;
            //switch (game.WinningTeamFulltime)
            //{
            //    case EnumConstants.WinningTeam.Hometeam:
            //        this.GamesWon += isHomeTeam ? 1 : 0;
            //        this.Points += isHomeTeam ? 3 : 0;
            //        this.GamesLost += isHomeTeam ? 0 : 1;
            //        break;
            //    case EnumConstants.WinningTeam.Draw:
            //        this.GamesDraw++;
            //        this.Points++;
            //        break;
            //    case EnumConstants.WinningTeam.Awayteam:
            //        this.GamesWon += isHomeTeam ? 0 : 1;
            //        this.Points += isHomeTeam ? 0 : 3;
            //        this.GamesLost += isHomeTeam ? 1 : 0;
            //        break;
            //    case EnumConstants.WinningTeam.Undefined:
            //    default:
            //        throw new System.Exception("WinningTeam id undefined");
            //}
        }


        public static Comparison<wcTeam> PointComparison = delegate(wcTeam t1, wcTeam t2)
        {
            //return -(t1.Points.CompareTo(t2.Points));
            int compare = -(t1.Points.CompareTo(t2.Points));
            if (compare == 0)
            {
                compare = -(t1.GoalDifference.CompareTo(t2.GoalDifference));
            }
            if (compare == 0)
            {
                compare = -(t1.GoalsMade.CompareTo(t2.GoalsMade));
            }

            return compare;
        };


        

  


        //private void CreateTeams()
        //{
        //    foreach (wcGame game in this)
        //    {

        //        if (AlreadyExists(game.HomeTeam) == false)
        //        {
        //            this.Teams.Add(game.HomeTeam);
        //        }
        //    }
        //}

        //public bool AlreadyExists(wcTeam match)
        //{
        //    foreach (wcTeam team in this.Teams)
        //    {
        //        if (team.Name == match.Name )
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

    }
}
