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
            routes.Add("FootballRoute", new Route
            (
               "fotboll",
               new CustomRouteHandler("/DynamoInomhus.aspx")
            ));

            routes.Add("WorldCupRoute", new Route
            (
               "vm",
               new CustomRouteHandler("/VM_2010.aspx")
            ));
        }
    }
}