using System;
using System.Collections;
using System.Configuration;
using System.Data;
//using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
//using System.Xml.Linq;
using BusinessLayer;

public partial class MasterPage : System.Web.UI.MasterPage
{
    private PageBase _thisPageBase = null;

    private PageBase thisPageBase
    {
        get 
        {
            //Lazy loading
            if (_thisPageBase == null)
            {
                _thisPageBase = (PageBase)this.Page;
            }
            return _thisPageBase; 
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //HttpContext.Current.Response.Write(thisPageBase.CurrentIpAddress);
        //HttpContext.Current.Response.Write(Context.User.Identity.IsAuthenticated ? "Logout" : "Login");
        //HttpContext.Current.Response.Write(hlLogin.Text + "<--TExt");
        //HttpContext.Current.Response.End();

        if (hlLogin != null)
        {
            hlLogin.Text = Context.User.Identity.IsAuthenticated ? "Logout" : "Login";
            //hlLogin.NavigateUrl = Context.User.Identity.IsAuthenticated ? 
            //    "Default.aspx?status=signOut" : 
            //    "Login.aspx";
            hlLogin.NavigateUrl = Context.User.Identity.IsAuthenticated ?
                hlCV.NavigateUrl = RouteTable.Routes.GetVirtualPath(null, "LogoutRoute", new RouteValueDictionary { }).VirtualPath :
                hlCV.NavigateUrl = RouteTable.Routes.GetVirtualPath(null, "LoginRoute", new RouteValueDictionary { }).VirtualPath;
        }

        hlHome.NavigateUrl = RouteTable.Routes.GetVirtualPath(null, "HomeRoute", new RouteValueDictionary { }).VirtualPath;
        hlCV.NavigateUrl = RouteTable.Routes.GetVirtualPath(null, "CvRoute", new RouteValueDictionary { }).VirtualPath;
		//hlEM.NavigateUrl = RouteTable.Routes.GetVirtualPath(null, "EmRoute", new RouteValueDictionary { }).VirtualPath;
		//hlVM.NavigateUrl = RouteTable.Routes.GetVirtualPath(null, "VmRoute", new RouteValueDictionary { }).VirtualPath;
		hlEM2012.NavigateUrl = RouteTable.Routes.GetVirtualPath(null, "EuropeanCup2012Route", new RouteValueDictionary { }).VirtualPath;
        hlFootball.NavigateUrl = RouteTable.Routes.GetVirtualPath(null, "FootballRoute", new RouteValueDictionary { }).VirtualPath;
        //hlFootball.NavigateUrl = RouteTable.Routes.GetVirtualPath(null, new RouteValueDictionary { 
        //    { "categoryName", "beverages" }, 
        //    {"action", "summarize" }}
        //).VirtualPath;

    }
}
