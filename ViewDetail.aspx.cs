using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class ViewDetail : System.Web.UI.Page
{
    int ind = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] == "A")
        {
            GridView1.DataSourceID = "SqlDataSource1";
        }
        else if (Request.QueryString["id"] == "B")
        {
            GridView1.DataSourceID = "SqlDataSource2";
        }
        else if (Request.QueryString["id"] == "C")
        {
            GridView1.DataSourceID = "SqlDataSource3";
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Text = (ind + 1).ToString();
        }
    }
}