using System;
using System.Data;
using System.Data.Odbc;
using DataLayer.Constants;
using DataLayer.Generic;

namespace DataLayer.Specific
{
    /// <summary>
    /// Summary description for UserData
    /// </summary>
    public static class UserData
    {
        /// <summary>
        /// Metod för att skapa typad tabell.
        /// </summary>
        /// <returns></returns>
        public static DataTable CreateUserTable()
        {
            DataTable dt = new DataTable("Users");
            dt.Columns.Add("userid", typeof(Int32));
            dt.Columns.Add("username", typeof(String));
            dt.Columns.Add("password", typeof(String));
            dt.Columns.Add("roles", typeof(String));
            return dt;
        }

        public static DataTable AddUserTableRow(DataTable userTable, int userId, string username, 
            string password, string roles)
        {
            DataRow dr = userTable.NewRow();
            dr[UserConstants.UserId] = userId;
            dr[UserConstants.UserName] = username;
            dr[UserConstants.Password] = password;
            dr[UserConstants.Roles] = roles;

            userTable.Rows.Add(dr);
            return userTable;
        }

        /// <summary>
        /// DataTable med användare
        /// </summary>
        /// <returns></returns>
        public static DataTable AllUsers()
        {
            DataTable dt = CreateUserTable();

            //Lägger till rader
            dt = AddUserTableRow(dt, 1, "familia", "galante", "familia");
            dt = AddUserTableRow(dt, 2, "test", "test", "user");
            dt = AddUserTableRow(dt, 3, "jan", "test", "user,familia,admin");
            return dt;
        }
    } 
}
