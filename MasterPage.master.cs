using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] == null)
        {
            Response.Redirect("Welcome.aspx");
        }
        Session.Timeout = 120;
        string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["revenueConnectionString1"].ConnectionString;
    }
}
