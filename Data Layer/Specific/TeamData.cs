using System;
using System.Data;
using System.Data.Odbc;
using DataLayer.Constants;
using DataLayer.Generic;

namespace DataLayer.Specific
{
    /// <summary>
    /// Summary description for TeamData
    /// </summary>
    public static class TeamData
    {
        public static DataTable CreateTeamTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(TeamConstants.TeamName, typeof(String));
            dt.Columns.Add(TeamConstants.GamesPlayed, typeof(Int32));
            dt.Columns.Add(TeamConstants.GamesWon, typeof(Int32));
            dt.Columns.Add(TeamConstants.GamesDraw, typeof(Int32));
            dt.Columns.Add(TeamConstants.GamesLost, typeof(Int32));
            dt.Columns.Add(TeamConstants.GoalsMade, typeof(Int32));
            dt.Columns.Add(TeamConstants.GoalsBackward, typeof(Int32));
            dt.Columns.Add(TeamConstants.Points, typeof(Int32));

            return dt;
        }
    } 
}
