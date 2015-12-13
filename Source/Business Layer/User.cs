using System;
using System.Collections.Generic;
//using System.Security.Principal;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace BusinessLayer
{
    /// <summary>
    /// Summary description for User
    /// </summary>
    public class User
    {
        private int _id;
        private string _username;
        private string _password;
        private string[] _roles;



        public User()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string[] Roles
        {
            get { return _roles; }
            set { _roles = value; }
        } 
        #endregion




        #region Methods
        /// <summary>
        /// Metod som försöker logga in användaren utifrån användarnamn
        /// och lösen ord. Om en användare hittas skapas en FormsAuthenticationTicket.
        /// </summary>
        /// <param name="username">Användarnamn</param>
        /// <param name="password">Lösenord</param>
        /// <returns>True returneras om användaren lyckades loggain, 
        /// annars retuneras false.</returns>
        public static void SignIn(string username, string password)
        {
            //Försöker hämta användare
            //DataRow userRow = Users.GetAuthenticatedUser(username, password);
            User user = Users.GetAuthenticatedUser(username, password);

            ////Kontrollerar userId finns
            //if (userRow != null)
            //{
            //    //Skaper en ticket och lägger i en cookie
            //    JanLundholm.Eu.User.CreateAuthenticationTicket((int)userRow["userid"], (string)userRow["roles"]);
            //    HttpContext.Current.Response.Redirect(FormsAuthentication.DefaultUrl); //Tar bort querystring
            //    //FormsAuthentication.RedirectFromLoginPage()
            //}

            //Kontrollerar userId finns
            if (user != null)
            {
                //Skaper en ticket och lägger i en cookie
                User.CreateAuthenticationTicket(user.Id, string.Join(",", user.Roles));
                HttpContext.Current.Response.Redirect(FormsAuthentication.DefaultUrl); //Tar bort querystring
                //FormsAuthentication.RedirectFromLoginPage()
            }
        }

        /// <summary>
        /// Metod för att logga ut en användare. Tat bort FormsAuthenticationTicket
        /// samt avslutar sessionen.
        /// </summary>
        public static void SignOut()
        {
            HttpContext.Current.Session.Abandon();
            FormsAuthentication.SignOut();
            HttpContext.Current.Response.Redirect("Default.aspx"); //Tar bort querystring
        }

        /// <summary>
        /// Skaper en ticket med användarid och roller. Samt lägger den i en cookie.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roles"></param>
        public static void CreateAuthenticationTicket(int userId, string roles)
        {
            //Skapar ticket för Authentication
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, userId.ToString(), DateTime.Now,
                DateTime.Now.AddMinutes(30), false, roles, FormsAuthentication.FormsCookiePath);

            //Hashar cookien för transport
            string hash = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);

            //Lägger till Cookie
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// Metod för att hämta aktuell FormsAuthenticationTicket ur cookie.
        /// </summary>
        /// <returns></returns>
        public static FormsAuthenticationTicket GetAuthenticationTicket()
        {
            //Hämtar cookie
            string cookieName = FormsAuthentication.FormsCookieName;
            HttpCookie authCookie = HttpContext.Current.Request.Cookies[cookieName];

            //Cookie finns inte
            if (authCookie == null)
            {
                return null;
            }

            //Dekrypterar cookie
            FormsAuthenticationTicket authTicket = null;
            try
            {
                authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            }
            catch (Exception)
            {
                throw new Exception("Exception fångades vid dekryptering. FormsAuthenticationTicket kunde inte dekrypteras");
            }

            if (authTicket == null)
            {
                throw new Exception("FormsAuthenticationTicket kunde inte dekrypteras");
            }
            return authTicket;
        }

        /// <summary>
        /// Metod för att hämta ut GenericPrincipal ur en FormsAuthenticationTicket.
        /// </summary>
        /// <param name="authTicket"></param>
        /// <returns></returns>
        public static GenericPrincipal GetPrincipal(FormsAuthenticationTicket authTicket)
        {
            GenericIdentity gi = new GenericIdentity(authTicket.Name);
            string[] roles = authTicket.UserData.Split(new char[] { ',' });
            GenericPrincipal principal = new GenericPrincipal(gi, roles);

            return principal;
        }
        #endregion

    } 
}
