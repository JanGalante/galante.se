using System;
using System.Data;
using System.Data.Odbc;

namespace DataLayer.Generic
{
    /// <summary>
    /// Summary description for Database
    /// </summary>
    public static class Database
    {
        public static OdbcConnection GetOpenConnection()
        {
            //OracleConnection conn = new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString);
            OdbcConnection conn = new OdbcConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString);
            conn.Open();
            return conn;
        }

        //private static OracleCommand SetupCommand(OracleCommand com)
        private static OdbcCommand SetupCommand(OdbcCommand com)
        {
            com.Connection = GetOpenConnection();
            //com.CommandTimeout = 
            //com.CommandType = CommandType.StoredProcedure;
            return com;
        }


        //public static DataTable ExecuteCommandReturnDataTable(OracleCommand com)
        public static DataTable ExecuteCommandReturnDataTable(OdbcCommand com)
        {
            SetupCommand(com);
            //OracleDataReader dr = com.ExecuteReader(CommandBehavior.CloseConnection);
            OdbcDataReader dr = com.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            dr.Dispose();
            com.Connection.Dispose();
            com.Dispose();
            return dt;
        }

        private static void ExecuteAsyncCommandReturnDataTableDone(IAsyncResult res)
        {
        }

        //public delegate DataTable CommandExecuter(OracleCommand com, DataTable table);
        public delegate DataTable CommandExecuter(OdbcCommand com, DataTable table);


        //public static DataTable[] ExecuteAsyncCommandReturnDataTable(OracleCommand[] coms)
        //{
        //    DataTable[] tables = new DataTable[coms.Length];
        //    //IAsyncResult[] results = new IAsyncResult[coms.Length];
        //    System.Threading.WaitHandle[] handles = new System.Threading.WaitHandle[coms.Length];

        //    //Loopa på alla commands
        //    for (int i = 0; i < coms.Length; i++)
        //    {
        //        //Skapa en tbl för command
        //        tables[i] = new DataTable();
        //        //Skapa delegaten som ska köra commandot
        //        CommandExecuter exec = new CommandExecuter(ExecuteCommandReturnDataTable);

        //        //Kör delegaten och skicka in vilken tbl resultatet ska land i.
        //        IAsyncResult res = exec.BeginInvoke(coms[i],
        //            tables[i],
        //            new AsyncCallback(ExecuteAsyncCommandReturnDataTableDone),
        //            exec);
        //        //Lagra waithandle
        //        handles[i] = res.AsyncWaitHandle;
        //    }
        //    //Vänta på alla handles.
        //    System.Threading.WaitHandle.WaitAll(handles);
        //    return tables;
        //}


        //public static DataTable[] ExecuteAsyncCommandReturnDataTable(OracleCommand[] coms, DataTable[] tables)
        //{
        //    //IAsyncResult[] results = new IAsyncResult[coms.Length];
        //    System.Threading.WaitHandle[] handles = new System.Threading.WaitHandle[coms.Length];

        //    //Loopa på alla commands
        //    for (int i = 0; i < coms.Length; i++)
        //    {
        //        //Skapa delegaten som ska köra commandot
        //        CommandExecuter exec = new CommandExecuter(ExecuteCommandReturnDataTable);

        //        //Kör delegaten och skicka in vilken tbl resultatet ska land i.
        //        IAsyncResult res = exec.BeginInvoke(coms[i],
        //            tables[i],
        //            new AsyncCallback(ExecuteAsyncCommandReturnDataTableDone),
        //            exec);
        //        //Lagra waithandle
        //        handles[i] = res.AsyncWaitHandle;
        //    }
        //    //Vänta på alla handles.
        //    System.Threading.WaitHandle.WaitAll(handles);
        //    return tables;

        //}



        /// <summary>
        /// Hämtar data från DB, placerar i typsäkrad datatabell som skickas 
        /// med som inparametrar och returnerar den fyllda datatabellen.
        /// </summary>
        /// <param name="com"></param>
        /// <param name="Table">Datatabell som ska fyllas med datat</param>
        /// <returns>Fylld DataTable</returns>
        //public static DataTable ExecuteCommandReturnDataTable(OracleCommand com, DataTable Table)
        public static DataTable ExecuteCommandReturnDataTable(OdbcCommand com, DataTable Table)
        {
            SetupCommand(com);
            //OracleDataReader dr = com.ExecuteReader(CommandBehavior.CloseConnection);
            OdbcDataReader dr = com.ExecuteReader(CommandBehavior.CloseConnection);

            //Starta laddning av data utan validering av rader
            Table.BeginLoadData();
            Table.Load(dr, LoadOption.OverwriteChanges); //Ladda data från readern utan version hantering.
            Table.EndLoadData(); //Avsluta laddning och validera datat...
            Table.AcceptChanges(); //Alla ev versioner(ska bara finnas en) blir org version
            dr.Close();
            dr.Dispose();
            com.Connection.Dispose();
            com.Dispose();
            return Table;
        }


        //public static OracleDataReader ExecuteCommandReturnReader(OracleCommand com)
        public static OdbcDataReader ExecuteCommandReturnReader(OdbcCommand com)
        {
            SetupCommand(com);
            //OracleDataReader dr = com.ExecuteReader(CommandBehavior.CloseConnection);
            OdbcDataReader dr = com.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }

        /// <summary>
        /// Används för instert/update/delete. OracleCommand.ExecuteNonQuery() används
        /// </summary>
        /// <param name="com"></param>
        //public static void ExecuteCommand(OracleCommand com)
        public static void ExecuteCommand(OdbcCommand com)
        {
            SetupCommand(com);
            com.ExecuteNonQuery();
            com.Connection.Dispose();
            com.Dispose();
        }

        /// <summary>
        /// Används för anrop av Oracle-procudurer med OUT parametrar. Returnerar OracleParameterCollection med alla OUT parametrar.
        /// </summary>
        /// <param name="com"></param>
        /// <returns>OracleParameterCollection med alla OUT-parametrar från proceduren</returns>
        //public static OracleParameterCollection ExecuteCommandReturnParameterCollection(OracleCommand com)
        public static OdbcParameterCollection ExecuteCommandReturnParameterCollection(OdbcCommand com)
        {
            SetupCommand(com);
            com.ExecuteNonQuery();

            //Sparar undan parametercollectionen som ska returneras
            //OracleParameterCollection _parameters = com.Parameters;
            OdbcParameterCollection _parameters = com.Parameters;

            com.Connection.Dispose();
            com.Dispose();
            return _parameters;
        }

        //public static T ExecuteCommand<T>(OracleCommand com)
        public static T ExecuteCommand<T>(OdbcCommand com)
        {
            SetupCommand(com);
            T ret = (T)com.ExecuteScalar();
            com.Connection.Close();
            com.Connection.Dispose();
            com.Dispose();
            return ret;
        }
    } 
}
