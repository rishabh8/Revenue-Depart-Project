using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Collections;
using System.Web.Script.Serialization;
using System.Net;
using System.Text;

public partial class ManageUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void SaveUser_Click(object sender, EventArgs e)
    {
        DataConnection.insertQuery("insert into member(Member_name,member_post,member_email,password,member_contact,admin,location,Department) values(N'" + Name.Text + "',N'" + Post.Text + "',N'" + Email.Text + "',N'" + Password.Text + "',N'" + ContNo.Text + "',N'" + Authen.Text + "',N'" + RCV.Text + "',N'" + OFMAIL.Text + "')");
        Response.Redirect("manageuser.aspx");
    }

    protected void btnAsmSes_Click(object sender, EventArgs e)
    {
        if (txtSadan.Text != "" && txtSadan.Text != "")
        {
            SqlDataReader reader = DataConnection.selectQuery("select * from AssemblySession where Assemblys=N'" + txtSadan.Text + "' and Session='" + txtSession.Text + "'");
            if (reader.HasRows == false)
            {
                DataConnection.insertQuery("insert into AssemblySession values(N'" + txtSadan.Text + "','" + txtSession.Text + "')");
                GridView2.DataBind();
            }
        }
    }

    protected void btnGrp_Click(object sender, EventArgs e)
    {
        if (txtGrp.Text != "")
        {
            SqlDataReader reader = DataConnection.selectQuery("select * from mst_group where grp=N'" + txtGrp.Text + "'");
            if (reader.HasRows==false)
            {
                DataConnection.insertQuery("insert into mst_group values(N'" + txtGrp.Text + "')");
                GridView3.DataBind();
            }
        }
    }
}