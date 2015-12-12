using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace BusinessLayer
{	
	[Serializable]
	[DataContract(IsReference = false)]
    public class wcTeam : IEquatable<wcTeam>
    {
        private string _name;
        private int _gamesPlayed = 0;
        private int _gamesWon = 0;
        private int _gamesDraw = 0;
        private int _gamesLost = 0;
        private int _goalsMade = 0;
        private int _goalsBackward = 0;
        private int _points = 0;

		[DataMember(IsRequired = false)]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

		[DataMember(IsRequired = false)]
        public int GamesPlayed
        {
            get { return _gamesPlayed; }
            set { _gamesPlayed = value; }
        }

		[DataMember(IsRequired = false)]
        public int GamesWon
        {
            get { return _gamesWon; }
            set { _gamesWon = value; }
        }

		[DataMember(IsRequired = false)]
        public int GamesDraw
        {
            get { return _gamesDraw; }
            set { _gamesDraw = value; }
        }

		[DataMember(IsRequired = false)]
        public int GamesLost
        {
            get { return _gamesLost; }
            set { _gamesLost = value; }
        }

		[DataMember(IsRequired = false)]
        public int GoalsMade
        {
            get { return _goalsMade; }
            set { _goalsMade = value; }
        }

		[DataMember(IsRequired = false)]
        public int GoalsBackward
        {
            get { return _goalsBackward; }
            set { _goalsBackward = value; }
        }

		[DataMember(IsRequired = false)]
        public int GoalDifference
        {
            get { return this.GoalsMade - this.GoalsBackward; }
			protected set { throw new InvalidOperationException("Denna set property går inte att använda utan finns endast för att det ska vara möjligt att serialisera"); }

        }

		[DataMember(IsRequired = false)]
        public int Points
        {
            get { return _points; }
            set { _points = value; }
        }

		/// <summary>
		/// Konstruktor
		/// </summary>
		/// <param name="name"></param>
        public wcTeam(string name)
        {
            this.Name = name;
        }





        #region IEquatable<wcTeam> Members

        public bool Equals(wcTeam other)
        {
            //throw new NotImplementedException();
            if (other == null)
            {
                return false;
            }
            return (this.Name.Equals(other.Name));
        }

        #endregion



        //private void PlayGame(wcGame game)
        //{
        //    bool isHomeTeam = this.Name == game.HomeTeam.Name ? true : false;

        //    this.GoalsMade += isHomeTeam ? (int)game.HomegoalFulltime : (int)game.AwaygoalFulltime;
        //    this.GoalsBackward += isHomeTeam ? (int)game.AwaygoalFulltime : (int)game.HomegoalFulltime;

        //    this.GamesPlayed++;
        //    switch (game.WinningTeamFulltime)
        //    {
        //        case EnumConstants.WinningTeam.Hometeam:
        //            this.GamesWon += isHomeTeam ? 1 : 0;
        //            this.Points += isHomeTeam ? 3 : 0;
        //            this.GamesLost += isHomeTeam ? 0 : 1;
        //            break;
        //        case EnumConstants.WinningTeam.Draw:
        //            this.GamesDraw++;
        //            this.Points++;
        //            break;
        //        case EnumConstants.WinningTeam.Awayteam:
        //            this.GamesWon += isHomeTeam ? 0 : 1;
        //            this.Points += isHomeTeam ? 0 : 3;
        //            this.GamesLost += isHomeTeam ? 1 : 0;
        //            break;
        //        case EnumConstants.WinningTeam.Undefined:
        //        default:
        //            throw new System.Exception("WinningTeam id undefined");
        //    }

        //}


    }
}
