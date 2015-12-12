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
            hlLogin.NavigateUrl = Context.User.Identity.IsAuthenticated ? "Default.aspx?status=signOut" : "Login.aspx";
        }
        
        
        hlFootball.NavigateUrl = RouteTable.Routes.GetVirtualPath(null, "FootballRoute", new RouteValueDictionary { }).VirtualPath;
        //hlFootball.NavigateUrl = RouteTable.Routes.GetVirtualPath(null, new RouteValueDictionary { 
        //    { "categoryName", "beverages" }, 
        //    {"action", "summarize" }}
        //).VirtualPath;

    }
}
