using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml.Linq;

using System.Web.Routing;

namespace janlundholm.eu
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Egen metod för routing
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.Add("BikeSaleRoute", new Route
            //(
            //   "bikes/sale",
            //   new CustomRouteHandler("~/Contoso/Products/Details.aspx")
            //));

            routes.Add("HomeRoute", new Route
            (
               "",
               new CustomRouteHandler("/Default.aspx")
            ));

            routes.Add("CvRoute", new Route
            (
               "cv",
               new CustomRouteHandler("/CV.aspx")
            ));

            routes.Add("ContactRoute", new Route
            (
               "contact",
               new CustomRouteHandler("/Contact.aspx")
            ));

            routes.Add("LoginRoute", new Route
            (
               "login",
               new CustomRouteHandler("/Login.aspx")
            ));

            routes.Add("LogoutRoute", new Route
            (
               "logout",
               new CustomRouteHandler("/Login.aspx?status=signOut")
            ));

            routes.Add("EmRoute", new Route
            (
               "em",
               new CustomRouteHandler("/EM_2008.aspx")
            ));

            routes.Add("VmRoute", new Route
            (
               "vm",
               new CustomRouteHandler("/VM_2010.aspx")
            ));

            routes.Add("FootballRoute", new Route
            (
               "fotboll",
               new CustomRouteHandler("/DynamoInomhus.aspx")
            ));

            routes.Add("wc2010Route", new Route
            (
               "wc2010",
               new CustomRouteHandler("/wc2010.aspx")
            ));

			routes.Add("EuropeanCup2012Route", new Route
			(
			   "em2012",
			   new CustomRouteHandler("/European2012.aspx")
			));


        }
    }
}