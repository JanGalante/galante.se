using System;
using System.Collections.Generic;
using System.Data;
using System.Xml;

using BusinessLayer.Enumerators;
using DataLayer.Constants;

namespace BusinessLayer
{
    /// <summary>
    /// Summary description for Game
    /// </summary>
    public class Game
    {
        private int _id;
        private int _tournamentId;
        private Team _homeTeam;
        private Team _awayTeam;
        private int? _homegoalFulltime;
        private int? _awaygoalFulltime;
        private string _group;
        private DateTime _date;
        private string _time;


        public int Id 
        { 
            get { return _id; }
            set { _id = value; } 
        }

        public int TournamentId
        {
            get { return _tournamentId; }
            set { _tournamentId = value; }
        }

        public Team HomeTeam
        {
            get { return _homeTeam; }
            set { _homeTeam = value; }
        }

        public Team AwayTeam
        {
            get { return _awayTeam; }
            set { _awayTeam = value; }
        }

        public int? HomegoalFulltime
        {
            get { return _homegoalFulltime; }
            set { _homegoalFulltime = value; }
        }

        public int? AwaygoalFulltime
        {
            get { return _awaygoalFulltime; }
            set { _awaygoalFulltime = value; }
        }

        public string Group
        {
            get { return _group; }
            set { _group = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public string Time
        {
            get { return _time; }
            set { _time = value; }
        }


        public EnumConstants.WinningTeam WinningTeamFulltime
        {
            get
            {
                if (this.HomegoalFulltime > this.AwaygoalFulltime)
                {
                    return EnumConstants.WinningTeam.Hometeam;
                }
                else if (this.HomegoalFulltime == this.AwaygoalFulltime)
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
        /// Default konstruktor
        /// </summary>
        public Game() { }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="row"></param>
        public Game(DataRow row)
        {
            _id = (int)row[GameConstants.GameId];
            _tournamentId = (int)row[GameConstants.TournamentId];
            _homeTeam = new Team(row[GameConstants.HomeTeam] as string);
            _awayTeam = new Team(row[GameConstants.AwayTeam] as string);
            _homegoalFulltime = row[GameConstants.HomegoalFulltime] as int?;
            _awaygoalFulltime = row[GameConstants.AwaygoaFulltime] as int?;
            _group = row[GameConstants.Group] as string;
            _date = DateTime.Parse(row[GameConstants.Date] as string);
            _time = row[GameConstants.Time] as string;
        }

        public Game(XmlNode gameNode)
        {
            int i;
            //_id = (int)row[GameConstants.GameId];
            _id = int.Parse(gameNode.Attributes["gameId"].Value);
            //_tournamentId = (int)row[GameConstants.TournamentId];
            //_homeTeam = new Team(row[GameConstants.HomeTeam] as string);
            _homeTeam = new Team(gameNode.SelectSingleNode("teams").Attributes["homeTeam"].Value as string);
            //_awayTeam = new Team(row[GameConstants.AwayTeam] as string);
            _awayTeam = new Team(gameNode.SelectSingleNode("teams").Attributes["awayTeam"].Value as string);
            //_homegoalFulltime = row[GameConstants.HomegoalFulltime] as int?;
            _homegoalFulltime = int.TryParse(gameNode.SelectSingleNode("standingFulltime").Attributes["homeGoal"].Value, out i) ? (int?)i : null;
            //_awaygoalFulltime = row[GameConstants.AwaygoaFulltime] as int?;
            _awaygoalFulltime = int.TryParse(gameNode.SelectSingleNode("standingFulltime").Attributes["awayGoal"].Value, out i) ? (int?)i : null;
            //_awaygoalFulltime = row[GameConstants.AwaygoaFulltime] as int?;
            //_group = row[GameConstants.Group] as string;
            //_date = DateTime.Parse(row[GameConstants.Date] as string);
            _date = DateTime.Parse(gameNode.Attributes["date"].Value);
            //_time = row[GameConstants.Time] as string;
        }
    } 
}
