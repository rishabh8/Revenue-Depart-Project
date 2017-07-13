using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Forward : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] == null)
        {
            Response.Redirect("Welcome.aspx");
        }
        Session.Timeout = 120;
        SectionPanel.Visible = false;
        DistrictPanel.CssClass = "col-lg-12";
        SqlDataReader re = DataConnection.selectQuery("select * from member where memeberid = "+Convert.ToInt32(Session["RCV"])+" and admin = 'A'");
        if (re.HasRows)
        {
            SectionPanel.Visible = true;
            DistrictPanel.CssClass = "col-lg-6";
        }
        int count = CheckBoxList2.Items.Count;
        SqlDataReader reader = DataConnection.selectQuery("select location,memeberid from member where Department='section'");
        if (reader.HasRows)
        {
            //List<String> lst = new List<string>();
            while (reader.Read())
            {
                ListItem item = new ListItem();
                item.Text = reader.GetString(0);
                item.Value = reader.GetInt32(1).ToString();
                item.Selected = false;
                CheckBoxList2.Items.Add(item);
            }
        }
        reader.Close();
        DataConnection.closeConnection();

        //count = CheckBoxList3.Items.Count;
        reader = DataConnection.selectQuery("select location,memeberid from member where Department='dist'");
        if (reader.HasRows)
        {
            //List<String> lst = new List<string>();
            while (reader.Read())
            {
                ListItem item = new ListItem();
                item.Text = reader.GetString(0);
                item.Value = reader.GetInt32(1).ToString();
                item.Selected = false;
                CheckBoxList3.Items.Add(item);
            }
        }
        reader.Close();
        DataConnection.closeConnection();

        CheckBoxList2.DataBind();
        CheckBoxList3.DataBind();
    }

    protected void Forward_Click(object sender, EventArgs e)
    {
        
        int fid =0;
        List<string> lstsection = new List<string>();
        List<string> lstdistrict = new List<string>();

        for (int i = 0; i < CheckBoxList2.Items.Count; i++)
        {
            if (CheckBoxList2.Items[i].Selected)
            {
                lstsection.Add(CheckBoxList2.Items[i].Value);
            }
        }

        for (int i = 0; i < CheckBoxList3.Items.Count ; i++)
        {
            if (CheckBoxList3.Items[i].Selected)
            {
                lstdistrict.Add(CheckBoxList3.Items[i].Value);
            }
        }


        if (lstdistrict.Count > 0)
        {
            
            DataConnection.insertQuery("insert into forward(sender,quesno) values(N'" + Session["RCV"] + "',N'" + Session["quesno"] + "')");
            SqlDataReader reader = DataConnection.selectQuery("select fid from forward where sender = '" + Session["RCV"] + "' and quesno = '" + Session["quesno"] + "'");
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    fid = reader.GetInt32(0);
                }
            }
            reader.Close();
            DataConnection.closeConnection();

            for (int i = 0; i < lstdistrict.Count; i++)
            {
                DataConnection.insertQuery("insert into forwardto values(" + fid + ",N'" + lstdistrict[i].ToString() + "')");
                DataConnection.insertQuery("insert into message values(N'" + lstdistrict[i].ToString() + "',N'" + Session["rcv"] + "',N'" + Session["quesno"] + "',NULL,NULL,NULL,NULL,'Y',N'" + Session["Sessions"] + "',N'" + Session["Assembly"] + "'," + fid + ",NULL)");
            }
            
            string message = "Data has Stored Successfully";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + message + "');", true);
            Response.Redirect("Dashboard.aspx");
        }
        else
        {
            string message = "Please Select Section first";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + message + "');", true);
            return;
        }
    }
}