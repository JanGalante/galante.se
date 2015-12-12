using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    /// <summary>
    /// Summary description for TeamCollection
    /// </summary>
    public class TeamCollection : ItemCollectionBase<Team>
    {
        public enum SortBy
        { 
            NotDefined,
            Name,
            GamesPlayed,
            GamesWon,
            GamesDraw,
            GamesLost,
            GoalsMade,
            GoalsBackward,
            GoalDifference,
            Points,
        }

        /// <summary>
        /// Antal omgångar som har spelats.
        /// </summary>
        public int Round
        {
            get 
            { 
                //return _round;
                int maxGamesPlayed = 0;
                foreach (Team t in this)
                {
                    if (t.GamesPlayed > maxGamesPlayed)
                    {
                        maxGamesPlayed = t.GamesPlayed;
                    }
                }
                return maxGamesPlayed;
            }
            //set { _round = value; }
        }

        /// <summary>
        /// Deafault konstruktor. Denna kräver en konstruktor i
        /// ItemCollectionBase efftersom den implicit anropar  :base()
        /// </summary>
        public TeamCollection() { }

        /// <summary>
        /// Konstruktor som hämtar ut alla lag som finns med i samlingen av matcher.
        /// </summary>
        /// <param name="games"></param>
        public TeamCollection(GameCollection games) 
        {
            foreach (Game game in games)
            {
                //Om hemmalaget inte redan finns i kolletionen läggs det till
                if (!this.Contains(game.HomeTeam))
                {
                    this.Add(game.HomeTeam);
                }
                //Om bortalaget inte redan finns i kolletionen läggs det till
                if (!this.Contains(game.AwayTeam))
                {
                    this.Add(game.AwayTeam);
                }

                this.Find(game.HomeTeam.Name).Games.Add(game); //Lägger till matchen i lagets match-collection
                this.Find(game.AwayTeam.Name).Games.Add(game); //Lägger till matchen i lagets match-collection
            }
        }


        /// <summary>
        /// Kontrollerar om inskickat lag redan finns i
        /// kollektionen. Kontrollen görs mot lagnamn(Team.Name).
        /// </summary>
        /// <param name="t1"></param>
        /// <returns></returns>
        public new bool Contains(Team t1)
        {
            foreach (Team t2 in this)
            {
                if (t2.Name == t1.Name)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Returnerar det lag som överstämmer med inskickat lagnamet.
        /// </summary>
        /// <param name="teamName"></param>
        /// <returns></returns>
        public Team Find(string teamName)
        {
            foreach (Team t in this)
            {
                if (t.Name == teamName)
                {
                    return t;
                }
            }
            return null;
        }

        /// <summary>
        ///  Sorterar kollektionen efter önskad sortering.
        /// </summary>
        /// <param name="sortby"></param>
        public void PerformSort(SortBy sortby)
        {
            switch (sortby)
            {
                case SortBy.GamesPlayed:
                    this.Sort(Team.GamesPlayedComparison);
                    break;
                case SortBy.GamesWon:
                    this.Sort(Team.GamesWonComparison);
                    break;
                case SortBy.GamesDraw:
                    this.Sort(Team.GamesDrawComparison);
                    break;
                case SortBy.GamesLost:
                    this.Sort(Team.GamesLostComparison);
                    break;
                case SortBy.GoalsMade:
                    this.Sort(Team.GoalsMadeComparison);
                    break;
                case SortBy.GoalsBackward:
                    this.Sort(Team.GoalsBackwardComparison);
                    break;
                case SortBy.GoalDifference:
                    this.Sort(Team.GoalDifferenceComparison);
                    break;
                case SortBy.Points:
                    this.Sort(Team.PointComparison);
                    break;
                case SortBy.Name:
                case SortBy.NotDefined:
                default:
                    this.Sort(Team.NameComparison);
                    break;
            }
        }

        public void SetGamesFilter(DateTime date)
        {
            foreach (Team t in this)
            {
                t.Games.SetDateFilter(date);
            }
        }

        public bool ItemFilterDelegate(Team t)
        {
            //return true;
            return t.GoalDifference >= 0;
        }

        //public Predicate<Team> findDelegate = new Predicate<Team>(FindDelegateMethod);
        public Predicate<Team> FindDelegate 
        {
            get { return new Predicate<Team>(FindDelegateMethod); }
        }

        public bool FindDelegateMethod(Team t)
        {
            //return new Team();
            return true;
        }


        //public Predicate<Team> FindTeamDelegate = delegate(Team t1)
        //{
        //    foreach (Team t2 in this)
        //    {
        //        if (t1 == t2)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //};

        //public Predicate<Team> FindTeamDelegate
        //{
        //    get
        //    {
        //        return delegate(Team t1)
        //        {
        //            foreach (Team t2 in this)
        //            {
        //                if (t1 == t2)
        //                {
        //                    return true;
        //                }
        //            }
        //            return false;
        //        };
        //    }
        //}
    }
}
