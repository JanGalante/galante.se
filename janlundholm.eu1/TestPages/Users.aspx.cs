using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using BusinessLayer;

public partial class TestPages_Users : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        gvUsers.DataSource = Users.GetAll();
        gvUsers.DataBind();

        gvWines.DataSource = WineCollection.GetAll();
        gvWines.DataBind();
    }
}
