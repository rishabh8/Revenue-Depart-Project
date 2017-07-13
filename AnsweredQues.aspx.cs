using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Data.OleDb;

public partial class AnsweredQues : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] == null)
        {
            Response.Redirect("Welcome.aspx");
        }

        if(!IsPostBack)
        { 
            if (Session["UR"].ToString() == "A" || Session["UR"].ToString() == "F")
            {
                GridView1.Columns[0].Visible=true;
            }
            Session["qno"] = "";
            Session["session"] = "";
            Session["Assemblys"] = "";
        }
    }
    
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditButton")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[index];
            Session["qno"] = row.Cells[3].Text;
            Session["Ass"] = row.Cells[1].Text;
            Session["sess"] = row.Cells[2].Text;
            SqlDataReader reader = DataConnection.selectQuery("select memeberid from member where member_name=N'" + row.Cells[4].Text + "'");
            string rcvs = "";
            while (reader.Read())
            {
                rcvs = reader.GetInt32(0).ToString();
            }
            Session["RCV1"] = rcvs;

            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + rcvs + "');", true);
            Response.Redirect("~/answer.aspx");
        }
        if (e.CommandName == "ExportButton")
        {
            eprt1.Visible = true;
            int x=0;
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[index];
            Session["qno"] = row.Cells[3].Text;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[1] { new DataColumn("SENT") });
            SqlDataReader reader = DataConnection.selectQuery("SELECT dbo.question_Detail.ques_detail FROM         dbo.member_Question INNER JOIN dbo.question_Detail ON dbo.member_Question.qid = dbo.question_Detail.quesid INNER JOIN dbo.question ON dbo.member_Question.qno = dbo.question.ques_no WHERE     (dbo.question.sadan = '" + row.Cells[1].Text + "') AND (dbo.question.session = '" + row.Cells[2].Text + "') AND (dbo.question.ques_no = " + row.Cells[3].Text + ")");
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    dt.Columns.AddRange(new DataColumn[1] { new DataColumn(reader.GetString(0)) });
                    x = x + 1;
                }
            }
            SqlDataReader reader1;
            reader = DataConnection.selectQuery("select member.location,message.rcv from message,member where Message.RCV=member.memeberid and sender =" + Session["rcv"].ToString() + " and QNO='" + row.Cells[3].Text + "' and Session='" + row.Cells[2].Text + "' and assemblys='" + row.Cells[1].Text + "'");
            if (reader.HasRows)
            {
                int n = -1;
                while (reader.Read())
                {
                    dt.Rows.Add(reader.GetString(0));
                    n = n + 1;
                    reader1 = DataConnection.selectQuery("select ans_details from answer_detail where aid in (select distinct(member_answer.aid) from member_answer,Message where member_answer.assemblys='" + row.Cells[1].Text + "' and  member_answer.session='" + row.Cells[2].Text + "' and member_answer.quesno='" + row.Cells[3].Text + "' and member_answer.mid='" + reader.GetString(1) + "' and Message.QNO=member_answer.quesno and Message.Submitted='T' and Message.RCV=member_answer.mid)");
                    if (reader1.HasRows)
                    {
                        int m = 0,l=1;
                        while (reader1.Read())
                        {
                            
                                dt.Rows[n][l]=reader1.GetString(0);
                                l = l + 1;
                            
                            m = m + 1;
                        }
                    }
                }
            }
            //ReportDataSource rs = new ReportDataSource("DataSet1", dt);
            //ReportViewer1.LocalReport.DataSources.Clear();
            //ReportViewer1.LocalReport.DataSources.Add(rs);

            //ReportViewer1.LocalReport.Refresh();
            //ReportViewer1.DataBind();            
            GridView2.DataSource = dt;
            GridView2.Attributes.Add("style", "word-break:break-all; word-wrap:break-word");
            GridView2.DataBind();
        }
        if (e.CommandName == "SGGovt")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[index];
            Session["quesno"] = row.Cells[3].Text;
            Session["sadan"] = row.Cells[1].Text;
            Session["session"] = row.Cells[2].Text;
            Session["sgques"] = "SendData";
            Response.Redirect("SendTos.aspx");
        }
    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Attributes.Add("style", "word-break:break-all;word-wrap:break-word;");
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int tq=2, sq=1;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string theHiddenField = ((HiddenField)e.Row.Cells[1].FindControl("Label1")).Value;
            //SqlDataReader reader = DataConnection.selectQuery("select count(*) as ctq from message where Assemblys=N'" + e.Row.Cells[1].Text + "' and Session=N'" + e.Row.Cells[2].Text + "' and QNO=N'" + e.Row.Cells[3].Text + "' and sender='" + Session["rcv"].ToString() + "'");
            //if (reader.HasRows)
            //{
            //    tq = Convert.ToInt32(reader[0]);
            //}
            //reader = DataConnection.selectQuery("select count(*) as csq from message where Assemblys=N'" + e.Row.Cells[1].Text + "' and Session=N'" + e.Row.Cells[2].Text + "' and QNO=N'" + e.Row.Cells[3].Text + "' and Submitted='T' and sender='" + Session["rcv"].ToString() + "'");
            //if (reader.HasRows)
            //{
            //    sq = reader.GetInt32(0);
            //}
            sq = (sq * 100) / tq;
            if (theHiddenField == "T")
            {
                e.Row.Cells[1].FindControl("btnAns").Visible = true;
                e.Row.Cells[1].FindControl("btnExport").Visible = true;
                e.Row.Cells[1].FindControl("SGGovt").Visible = true;
            }
            if (Session["qno"].ToString() == e.Row.Cells[3].Text && Session["session"].ToString() == e.Row.Cells[2].Text && Session["Assemblys"].ToString() == e.Row.Cells[1].Text)
            {
                e.Row.Cells[1].FindControl("btnExport").Visible = false;
                e.Row.Cells[1].FindControl("SGGovt").Visible = false;
            }
            
            
        }
    }

    protected void UseMethod()
    {
        GridViewRow row1;
        
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            if(GridView1.Rows[i].Cells[5].FindControl("Submitted") != null)
            {
                row1 = GridView1.Rows[i];
                row1.Cells[4].Visible = true;
            }
        }
    }


    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnclose_Click(object sender, EventArgs e)
    {
        eprt1.Visible = false;
    }

    protected void btnExpt_Click(object sender, EventArgs e)
    {
        
    }
}