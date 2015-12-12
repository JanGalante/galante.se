using System;
using System.Data;
using System.Data.Odbc;
using DataLayer.Constants;
using DataLayer.Generic;

namespace DataLayer.Specific
{
    /// <summary>
    /// Summary description for GameData
    /// </summary>
    public static class GameData
    {
        public static DataTable CreateGameTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(GameConstants.GameId, typeof(Int32));
            dt.Columns.Add(GameConstants.TournamentId, typeof(Int32));
            dt.Columns.Add(GameConstants.HomeTeam, typeof(String));
            dt.Columns.Add(GameConstants.AwayTeam, typeof(String));
            dt.Columns.Add(GameConstants.HomegoalFulltime, typeof(Int32));
            dt.Columns.Add(GameConstants.AwaygoaFulltime, typeof(Int32));
            dt.Columns.Add(GameConstants.Group, typeof(String));
            dt.Columns.Add(GameConstants.Date, typeof(String));
            dt.Columns.Add(GameConstants.Time, typeof(String));
            return dt;
        }


        /// <summary>
        /// Metod för att hämta alla inomhusmatcher för Dynamo Filmhuset
        /// säsongen 2008/2009.
        /// </summary>
        /// <returns>Typad tabell med matcher</returns>
        public static DataTable GetDynamoIndoor2008()
        {
            OdbcCommand com = new OdbcCommand();
            com.CommandType = CommandType.Text;
            com.CommandText = string.Format("SELECT g.{0}, g.{1}, g.{2}, g.{3}, g.{4}, g.{5}, g.{6}, g.{7}, {8} FROM Games g WHERE {1} = 2",
               GameConstants.GameId, GameConstants.TournamentId, GameConstants.HomeTeam,
               GameConstants.AwayTeam, GameConstants.HomegoalFulltime, GameConstants.AwaygoaFulltime,
               GameConstants.Group, GameConstants.Date, GameConstants.Time);

            DataTable dt = Database.ExecuteCommandReturnDataTable(com, CreateGameTable());
            return dt;
        }
    } 
}
