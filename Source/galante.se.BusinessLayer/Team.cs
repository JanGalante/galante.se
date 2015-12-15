using System;
using System.Collections.Generic;

using BusinessLayer.Enumerators;

namespace BusinessLayer
{
    /// <summary>
    /// Summary description for Team
    /// </summary>
    public class Team : IComparable<Team>
    {
        private string _name = null;
        private int _gamesPlayed = 0;
        private int _gamesWon = 0;
        private int _gamesDraw = 0;
        private int _gamesLost = 0;
        private int _goalsMade = 0;
        private int _goalsBackward = 0;
        private int _points = 0;
        private GameCollection _games = new GameCollection();


        public GameCollection Games
        {
            get { return _games; }
        }
        
        /// <summary>
        /// Lagets (eller individens) namn.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int GamesPlayed
        {
            get 
            { 
                return _gamesPlayed; 
                //return Games.Count;
            }
            set { _gamesPlayed = value; }
        }

        public int GamesWon
        {
            get { return _gamesWon; }
            set { _gamesWon = value; }
        }

        public int GamesDraw
        {
            get { return _gamesDraw; }
            set { _gamesDraw = value; }
        }

        public int GamesLost
        {
            get { return _gamesLost; }
            set { _gamesLost = value; }
        }

        public int GoalsMade
        {
            get { return _goalsMade; }
            set { _goalsMade = value; }
        }

        public int GoalsBackward
        {
            get { return _goalsBackward; }
            set { _goalsBackward = value; }
        }

        public int GoalDifference
        {
            get { return this.GoalsMade - this.GoalsBackward; }
        }

        public int Points
        {
            get { return _points; }
            set { _points = value; }
        }



        /// <summary>
        /// Default konstruktor
        /// </summary>
        public Team() { }

        public Team(string teamName) 
        {
            _name = teamName;
            //Lägger till metod på eventet OnItemAdded
            _games.OnItemAdded += this.Team_OnGameAdded; //this.MyEventMethod;
            _games.OnFilterChanged += this.Team_OnGameFilterChanged;
        }

        public Team(string teamName, GameCollection games) :this (teamName)
        {
            foreach (Game game in games)
            {
                this.PlayGame(game);
            }
        }


        #region IComparable<Team> Members

        //TODO: Tror inte denna används längre. Ta bort.
        public int CompareTo(Team other)
        {
            //throw new NotImplementedException();
            //return ProductName.CompareTo(other.ProductName);
            return this.Name.CompareTo(other.Name);
        }


        //Deklaration och instansiering av delegat. Instansierng med hjälp
        //av anonym metod
        public static Comparison<Team> NameComparison = delegate(Team t1, Team t2)
        {
            return t1.Name.CompareTo(t2.Name);
        };

        public static Comparison<Team> GamesPlayedComparison = delegate(Team t1, Team t2)
        {
            return -(t1.GamesPlayed.CompareTo(t2.GamesPlayed));
        };

        public static Comparison<Team> GamesWonComparison = delegate(Team t1, Team t2)
        {
            return -(t1.GamesWon.CompareTo(t2.GamesWon));
        };

        public static Comparison<Team> GamesDrawComparison = delegate(Team t1, Team t2)
        {
            return -(t1.GamesDraw.CompareTo(t2.GamesDraw));
        };

        public static Comparison<Team> GamesLostComparison = delegate(Team t1, Team t2)
        {
            return -(t1.GamesLost.CompareTo(t2.GamesLost));
        };
        
        public static Comparison<Team> GoalsMadeComparison = delegate(Team t1, Team t2)
        {
            return -(t1.GoalsMade.CompareTo(t2.GoalsMade));
        };

        public static Comparison<Team> GoalsBackwardComparison = delegate(Team t1, Team t2)
        {
            return t1.GoalsBackward.CompareTo(t2.GoalsBackward);
        };

        public static Comparison<Team> GoalDifferenceComparison = delegate(Team t1, Team t2)
        {
            int result = -(t1.GoalDifference.CompareTo(t2.GoalDifference));
            if (result == 0)
            {
                result = -(t1.GoalsMade.CompareTo(t2.GoalsMade));
            }
            return result;
        };

        public static Comparison<Team> PointComparison = delegate(Team t1, Team t2)
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





        //private static ItemCollectionBase<Team>.FilteredCollectionItemDelegate Filter;
        //Filter = new ItemCollectionBase<Team>.FilteredCollectionItemDelegate TeamFilter;
        


        ////private bool TeamFilter(Team t)
        //private bool TeamFilter()
        //{
        //    return true;
        //}


        private void PlayGame(Game game)
        {
            bool isHomeTeam = this.Name == game.HomeTeam.Name ? true : false;

            this.GoalsMade += isHomeTeam ? (int)game.HomegoalFulltime : (int)game.AwaygoalFulltime;
            this.GoalsBackward += isHomeTeam ? (int)game.AwaygoalFulltime : (int)game.HomegoalFulltime;

            this.GamesPlayed++;
            switch (game.WinningTeamFulltime)
            {
                case EnumConstants.WinningTeam.Hometeam:
                    this.GamesWon += isHomeTeam ? 1 : 0;
                    this.Points += isHomeTeam ? 3 : 0;
                    this.GamesLost += isHomeTeam ? 0 : 1;
                    break;
                case EnumConstants.WinningTeam.Draw:
                    this.GamesDraw++;
                    this.Points++;
                    break;
                case EnumConstants.WinningTeam.Awayteam:
                    this.GamesWon += isHomeTeam ? 0 : 1;
                    this.Points += isHomeTeam ? 0 : 3;
                    this.GamesLost += isHomeTeam ? 1 : 0;
                    break;
                case EnumConstants.WinningTeam.Undefined:
                default:
                    throw new System.Exception("WinningTeam id undefined");
            }
        }

        public void Team_OnGameAdded(object sender, EventArgs e)
        {
            Game g = sender as Game;
            //HttpContext.Current.Response.Write(string.Format("{0}<br>{1}-{2}: {3}-{4} <br>", this.Name, g.HomeTeam.Name, g.AwayTeam.Name, g.HomegoalFulltime, g.AwaygoalFulltime));
            //Spelar matchen och uppderar lagets poäng m.m.
            this.PlayGame(g);
        }

        public void Team_OnGameFilterChanged(object sender, EventArgs e)
        {
            //Nollställer statistiken
            this.GamesPlayed = 0;
            this.GamesWon = 0;
            this.GamesDraw = 0;
            this.GamesLost = 0;
            this.GoalsMade = 0;
            this.GoalsBackward = 0;
            this.Points = 0;
            //Loopar igenom kollektionen utefter den
            //nya filtreringen
            foreach (Game g in this.Games)
            {
                this.PlayGame(g);
                //HttpContext.Current.Response.Write(string.Format("{0}<br>{1}-{2}: {3}-{4} <br>", this.Name, g.HomeTeam.Name, g.AwayTeam.Name, g.HomegoalFulltime, g.AwaygoalFulltime));
            }
        }


        #endregion
    } 
}
