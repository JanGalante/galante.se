using System;
using System.Data;
using System.Data.Odbc;
using DataLayer.Constants;
using DataLayer.Generic;

namespace DataLayer.Specific
{
    /// <summary>
    /// Summary description for WineData
    /// </summary>
    public static class WineData
    {
        public static DataTable CreateWineTable()
        {
            DataTable dt = new DataTable("Wines");
            dt.Columns.Add(WineConstants.WineId, typeof(Int32));
            dt.Columns.Add(WineConstants.Name, typeof(String));
            dt.Columns.Add(WineConstants.Country, typeof(String));
            dt.Columns.Add(WineConstants.District, typeof(String));
            dt.Columns.Add(WineConstants.Vintage, typeof(Int32));
            dt.Columns.Add(WineConstants.Grapes, typeof(String));
            dt.Columns.Add(WineConstants.AlcoholPercent, typeof(Decimal));
            dt.Columns.Add(WineConstants.Price, typeof(Int32));
            dt.Columns.Add(WineConstants.Usage, typeof(String));
            dt.Columns.Add(WineConstants.Color, typeof(String));
            dt.Columns.Add(WineConstants.Taste, typeof(String));
            dt.Columns.Add(WineConstants.Scent, typeof(String));
            dt.Columns.Add(WineConstants.SystemArticleNr, typeof(Int32));
            dt.Columns.Add(WineConstants.SystemFullness, typeof(Int32));
            dt.Columns.Add(WineConstants.SystemAbrasiveness, typeof(Int32));
            dt.Columns.Add(WineConstants.SystemFruitAcid, typeof(Int32));
            dt.Columns.Add(WineConstants.Other, typeof(String));
            return dt;
        }

        public static DataTable GetAll()
        {
            OdbcCommand com = new OdbcCommand();
            com.CommandType = CommandType.Text;
            com.CommandText = string.Format("SELECT w.{0}, w.{1}, w.{2}, w.{3}, w.{4}, w.{5}, w.{6}, w.{7}, w.{8}, w.{9}, w.{10}, w.{11}, w.{12}, w.{13}, w.{14}, w.{15}, w.{16} FROM Wines w",
                WineConstants.WineId, WineConstants.Name, WineConstants.Country, WineConstants.District,
                WineConstants.Vintage, WineConstants.Grapes, WineConstants.AlcoholPercent, WineConstants.Price,
                WineConstants.Usage, WineConstants.Color, WineConstants.Taste, WineConstants.Scent,
                WineConstants.SystemArticleNr, WineConstants.SystemFullness, WineConstants.SystemAbrasiveness,
                WineConstants.SystemFruitAcid, WineConstants.Other);

            DataTable dt = Database.ExecuteCommandReturnDataTable(com, CreateWineTable());
            return dt;
        }
    } 
}