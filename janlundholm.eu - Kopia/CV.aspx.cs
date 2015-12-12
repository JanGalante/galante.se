using System;
using System.Collections;
using System.Configuration;
using System.Data;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;
using BusinessLayer;

public partial class CV : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		Person p1 = new Person();
		p1.FirstName = "Janne";
		p1.LastName = "Lundholm";
		p1.BirthDay = new DateTime(1978, 05, 28);

		Person p2 = new Person();
		p2.FirstName = "Denise";
		p2.LastName = "Hansson";
		p2.BirthDay = new DateTime(1981, 07, 06);

		Person p3 = new Person("Nisse", "Hult", new DateTime(1988, 01, 05));

		PersonCollection coll = new PersonCollection();
		//coll.Add(p1);
		//coll.Add(p2);
		coll.Add(p1, p2, p3);

		Button1.Text = "jakfj";
		GridView1.DataSource = coll;
		GridView1.DataBind();

    }
}
