using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using MySql.Data.MySqlClient;B

using BusinessLayer;
using DataLayer.Generic;
using DataLayer.Specific;

public partial class TestPages_DbConnection : PageBase
{
    //private const string ScriptName1 = "pupupScript";
    //private const string ScriptName2 = "ButtonClickScript";


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["action"] == "addnew")
        {
            DetailsView1.ChangeMode(DetailsViewMode.Insert);
            //DetailsView1.Visible = true;
        }
        

        BuildPlayerGrid();


        // Check to see if the client script is already registered.
        ClientScriptManager cs = Page.ClientScript;
        if (!cs.IsClientScriptIncludeRegistered(this.GetType(), "test.js"))
        {
            //cs.RegisterClientScriptInclude(this.GetType(), "test.js", "../JavaScript/test.js");
        }

        //SqlDataSource1.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
        //SqlDataSource1.InsertCommand = "INSERT ";
    }


    private void BuildPlayerGrid()
    {
        OdbcCommand com = new OdbcCommand();
        com.CommandType = CommandType.Text;
        com.CommandText = "SELECT * FROM Players";

        DataTable dt = Database.ExecuteCommandReturnDataTable(com);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    //void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    if (e.CommandName == "Add")
    //    {
    //        SqlDataSource1.Insert();
    //    }
    //}


    public void GridView2_RowCreated(object sender, GridViewRowEventArgs e)
    {
        // The GridViewCommandEventArgs class does not contain a 
        // property that indicates which row's command button was
        // clicked. To identify which row's button was clicked, use 
        // the button's CommandArgument property by setting it to the 
        // row's index.


        ////Add CSS class on header row.
        //if (e.Row.RowType == DataControlRowType.Header)
        //    e.Row.CssClass = "header";

        ////Add CSS class on normal row.
        //if (e.Row.RowType == DataControlRowType.DataRow &&
        //          e.Row.RowState == DataControlRowState.Normal)
        //    e.Row.CssClass = "normal";

        ////Add CSS class on alternate row.
        //if (e.Row.RowType == DataControlRowType.DataRow &&
        //          e.Row.RowState == DataControlRowState.Alternate)
        //    e.Row.CssClass = "alternate";


        if (e.Row.RowType == DataControlRowType.DataRow /*&& e.Row.RowState == DataControlRowState.Normal*/)
	    {
            //e.Row.CssClass = "test";

            // Retrieve the LinkButton control from the first column.
            //LinkButton addButton = (LinkButton)e.Row.FindControl("DeleteButton"); //AddButton
            //if (addButton != null)
            //{
            //    addButton.CssClass = "test";
            //}

            //// Set the LinkButton's CommandArgument property with the
            //// row's index.
            //addButton.CommandArgument = e.Row.RowIndex.ToString();

            //((LinkButton)e.Row.Cells[0].Controls[0]).CssClass = "thickbox"; //Edit
            //((LinkButton)e.Row.Cells[0].Controls[2]).CssClass = "thickbox"; //Delete
            //((LinkButton)e.Row.Cells[0].Controls[4]).CssClass = "thickbox"; //Select
	    }
    }


    public void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // If multiple buttons are used in a GridView control, use the
        // CommandName property to determine which button was clicked.
        if (e.CommandName == "Add")
        {
            // Convert the row index stored in the CommandArgument
            // property to an Integer.
            int index = Convert.ToInt32(e.CommandArgument);

            // Retrieve the row that contains the button clicked 
            // by the user from the Rows collection.
            GridViewRow row = GridView2.Rows[index];

            // Create a new ListItem object for the product in the row.     
            //ListItem item = new ListItem();
            //item.Text = Server.HtmlDecode(row.Cells[1].Text);
        }
    }

    public void lbAddNew_Click(object sender, EventArgs e)
    {
        DetailsView1.ChangeMode(DetailsViewMode.Insert);
    }

    public void DetailsView1_ItemUpdated(object sender, EventArgs e)
    {
        DetailsView1.Visible = false;
    }

    public void DetailsView1_ItemInserted(object sender, EventArgs e)
    {
        DetailsView1.Visible = false;
    }

    public void DetailsView1_ItemDeleted(object sender, EventArgs e)
    {
        DetailsView1.Visible = false;
    }
}
