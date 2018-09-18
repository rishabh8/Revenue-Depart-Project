using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Welcome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
                
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            SqlDataReader read = DataConnection.selectQuery("select * from member where member_email='" + username.Text.Trim() + "' and password='" + password.Text.Trim() + "'");
        
        if (read.HasRows)
        {
            while (read.Read())
            {
                Session["UserId"] = username.Text.Trim();
                Application["Username"] = read.GetValue(0).ToString().ToUpper();
                Session["UR"] = read.GetValue(5).ToString().ToUpper();
                Session["RCV"] = read.GetValue(7).ToString().ToUpper();
                Session["RCV1"] = read.GetValue(7).ToString().ToUpper();
                Response.Redirect("Dashboard.aspx");
            }
        }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + ex.Message + "');", true);
        }
        
        
    }
}