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
using System;

public partial class Message : System.Web.UI.Page
{
    int ind2 = 0;
    int ind3 = 0;
    int ind4 = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] == null)
        {
            Response.Redirect("Welcome.aspx");
        }
        //UseMethod();
        GridView2.Columns[13].Visible = false;

        GridView2.Columns[12].Visible = false;
        if (Request.QueryString["id"] == "F")
        {
            GridView2.Columns[12].Visible = true;
        }
    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditButton")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView2.Rows[index];
            Session["qno"] = row.Cells[1].Text;
            Session["Ass"] = row.Cells[2].Text;
            Session["sess"] = row.Cells[3].Text;
            HiddenField theHiddenField = row.FindControl("sender1") as HiddenField;
            if (theHiddenField != null)
            {
                Application["Sender"] = theHiddenField;
            }
            Response.Redirect("~/answer.aspx");
        }
        if (e.CommandName == "LinkBtn")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView2.Rows[index];
            Session["qno"] = row.Cells[1].Text;
            LinkButton2_Click(sender, e);
        }
        if (e.CommandName == "ForwardButton")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView2.Rows[index];
            Session["quesno"] = row.Cells[1].Text;
            Session["Assembly"] = row.Cells[2].Text;
            Session["Sessions"] = row.Cells[3].Text;
            Session["Forward"] = "Forward";
            Response.Redirect("~/Forward.aspx");
        }
    }
    
    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditButton")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView3.Rows[index];
            Session["qno"] = row.Cells[1].Text;
            Session["Ass"] = row.Cells[2].Text;
            Session["sess"] = row.Cells[3].Text;
            Response.Redirect("~/answer.aspx");
        }
        if (e.CommandName == "LinkBtn")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView3.Rows[index];
            Session["qno"] = row.Cells[1].Text;
            Session["Ass"] = row.Cells[2].Text;
            Session["sess"] = row.Cells[3].Text;
            LinkButton2_Click(sender, e);
        }
        if (e.CommandName == "ForwardButton")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView3.Rows[index];
            Session["quesno"] = row.Cells[1].Text;
            Session["Assembly"] = row.Cells[2].Text;
            Session["Sessions"] = row.Cells[3].Text;
            Response.Redirect("~/Forward.aspx");
        }
    }
    
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        ind2 = 0;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Text = (++ind2).ToString();
            DateTime dt = DateTime.Parse(e.Row.Cells[7].Text);
            e.Row.Cells[7].Text = dt.Day + "-" + dt.Month + "-" + dt.Year;

            if (e.Row.Cells[6].Text == "")
            {
                DateTime dt2 = DateTime.Parse(e.Row.Cells[6].Text);
                e.Row.Cells[6].Text = dt.Day + "-" + dt.Month + "-" + dt.Year;
            }

            if (e.Row.Cells[6].Text != "")
            {
                e.Row.Cells[6].Text = "N/A";
            }
        }
    }
    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        ind3 = 0;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Text = (++ind3).ToString();
        }
    }
    
    protected string filename;
    public void LinkButton2_Click(object sender, EventArgs e)
    {
        SqlDataReader reader = DataConnection.selectQuery("select files_path from MessageView where ques_no ='" + Session["qno"].ToString() + "' and sadan ='" + Session["Ass"].ToString() + "' and session='" + Session["sess"].ToString() + "'");

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                filename = reader.GetString(0);
            }
        }
        else
        {
            string message = "File Name is not Found";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + message + "');", true);
            return;
        }
        DataConnection.closeConnection();

        DataConnection.insertQuery("update Message set ReadFlag = null where QNo =" + Convert.ToInt32(Session["qno"].ToString()));

        
        string ftpurl = "ftp://localhost/";
        string ftpUserName = "FTPUser";
        string ftpPassword = "123456";
        string ftpFolder = "Question/";

        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpurl + ftpFolder + filename);
        request.Method = WebRequestMethods.Ftp.DownloadFile;

        request.Credentials = new NetworkCredential(ftpUserName, ftpPassword);
        request.UsePassive = true;
        request.UseBinary = true;
        request.EnableSsl = false;
        request.UsePassive = true;
        request.UseBinary = true;
        request.EnableSsl = false;
        request.KeepAlive = true;


        FtpWebResponse response = (FtpWebResponse)request.GetResponse();
        using (MemoryStream stream = new MemoryStream())
        {
            //Download the File.
            response.GetResponseStream().CopyTo(stream);
            Response.AddHeader("content-disposition", "attachment;filename=" + filename);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(stream.ToArray());
            Response.End();
        }
        response.Close();

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


    protected void UseMethod()
    {
        GridViewRow row2;
        GridViewRow row3;
                                    
        if (Request.QueryString["id"]  == "F")
        {
            
            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                row2 = GridView2.Rows[i];
                row2.Cells[9].Visible = true;
            }

            for (int i = 0; i < GridView3.Rows.Count; i++)
            {
                row3 = GridView3.Rows[i];
                row3.Cells[6].Visible = true;
            }          
        }
        else if (Request.QueryString["id"] == "T")
        {

            //for (int i = 0; i < GridView1.Rows.Count; i++)
            //{
            //    row1 = GridView1.Rows[i];
            //    row1.Cells[9].Visible = false;
            //}

            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                row2 = GridView2.Rows[i];
                row2.Cells[9].Visible = false;
                
            }

        }
    }
    protected void GridView4_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditButton")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView4.Rows[index];
            Session["qno"] = row.Cells[1].Text;
            Session["Ass"] = row.Cells[2].Text;
            Session["sess"] = row.Cells[3].Text;
            Response.Redirect("~/answer.aspx");
        }
    }
    protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        ind4 = 0;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Text = (++ind4).ToString();
        }
    }
}