using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using DataLayer.Constants;
using DataLayer.Specific;

namespace BusinessLayer
{
    /// <summary>
    /// Summary description for Users
    /// </summary>
    public class Users : ICollection<User>
    {
        private List<User> _users;


        private Users()
        {
            this._users = new List<User>();
        }

        //public static DataTable GetAll()
        public static Users GetAll()
        {
            //return UserData.AllUsers();

            Users uu = new Users();

            DataTable dt = UserData.AllUsers();
            foreach (DataRow dr in dt.Rows)
            {
                User u = new User();
                u.Id = (int)dr[UserConstants.UserId];
                u.Username = (string)dr[UserConstants.UserName];
                u.Password = (string)dr[UserConstants.Password];
                u.Roles = ((string)dr[UserConstants.Roles]).Split(new char[]{','});

                uu.Add(u);
            }
            return uu;

        }

        /// <summary>
        /// Metod som hämtar aktuell användare utifrån inskickat användarnamn
        /// och lösenord. Hittas ingen användare returneras null.
        /// </summary>
        /// <param name="username">Användarnamn</param>
        /// <param name="password">Lösenord</param>
        /// <returns></returns>
        //public static DataRow GetAuthenticatedUser(string username, string password)
        //{
        //    foreach (DataRow user in Users.GetAll().Rows)
        //    {
        //        if ((string)user["username"] == username && (string)user["password"] == password)
        //        {
        //            return user;
        //        }
        //    }
        //    return null;
        //}
        public static User GetAuthenticatedUser(string username, string password)
        {
            foreach (User u in Users.GetAll())
            {
                if (u.Username == username && u.Password == password)
	            {
            		 return u;
	            }
            }
            return null;
        }


        //public static void Load()
        //{ 
        //    foreach (DataRow dr in collection)
        //    {
        //        JanLundholm.Eu.User user = new JanLundholm.Eu.User();
        //        user.Id = dr[""];
        //    }
        //}

        #region ICollection<User> Members

        public void Add(User item)
        {
            this._users.Add(item);
        }

        public void Clear()
        {
            this._users.Clear();
        }

        public bool Contains(User item)
        {
            return this._users.Contains(item);
        }

        public void CopyTo(User[] array, int arrayIndex)
        {
            this._users.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return this._users.Count; }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(User item)
        {
            return this._users.Remove(item);
        }

        #endregion

        #region IEnumerable<User> Members

        public IEnumerator<User> GetEnumerator()
        {
            foreach (User u in this._users)
            {
                yield return u;
            }
            yield break; //Denna är valfri
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            //return ((IEnumerator<User>)this).GetEnumerator();
            return this.GetEnumerator();
        }

        #endregion
    }
}