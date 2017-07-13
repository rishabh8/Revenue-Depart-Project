using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using System.Drawing;

 
public partial class Search : System.Web.UI.Page
{
    private string sadan = "%";
    private string session = "%";
    private string quesno = "%";
    private string questype = "%";
    private string membernames = "%";
    private string deptname = "%";
    private string lists = "%";
    private string rcv = "%";

    protected void Page_Load(object sender, EventArgs e)
    {   
        membernamess.Items.Add("--- सदस्य का नाम चुनें ---");
        SqlDataReader reader = DataConnection.selectQuery("select * from MLA_member");
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                membernamess.Items.Add(reader.GetString(0));
            }
        }

        if (!IsPostBack)
        {
            GridView1.DataBind();
        }
    }

    protected void Searchbtn_Click(object sender, EventArgs e)
    {
        if (sadhan.SelectedIndex != 0)
        {
            sadan = sadhan.SelectedValue.Trim();
        }
        if (sessions.SelectedIndex != 0)
        {
            session = sessions.SelectedValue.Trim();
        }
        if (quesnos.Text != "")
        {
            quesno = quesnos.Text.Trim();
        }
        if (quesType.SelectedIndex != 0)
        {
            questype = quesType.SelectedValue.Trim();
        }
        if (membernamess.SelectedIndex != 0)
        {
            membernames = membernamess.SelectedValue.Trim();
        }
        if (relatatedvibhag.Text != "")
        {
            deptname = relatatedvibhag.Text.Trim();
        }
        if (listed.SelectedIndex != 0)
        {
            lists = listed.SelectedValue.Trim();
        }
        if (Session["UR"].ToString() == "F" || Session["UR"].ToString() == "U")
        {
            rcv = Session["RCV"].ToString();
        }
        else if (Session["UR"].ToString() == "A" || Session["UR"].ToString() == "" || Session["UR"].ToString() == null)
        {
            rcv = "%";
        }

        SqlDataSource1.SelectCommand = "select * from SearchDetail where sadan like '" + sadan.Trim() + "' and session like '" + session.Trim() + "' and ques_no like '" + quesno.Trim() + "' and relatedVibag like N'" + deptname + "' and quesType like N'" + questype + "' and listed like N'" + lists + "'  and membernames like N'" + membernames + "'";
        
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //int index = Convert.ToInt32(e.CommandArgument);
        //GridViewRow row = GridView1.Rows[index];

        Searchbtn_Click(sender,new EventArgs());
    }

    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
    }

      

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            SqlDataReader listeds = DataConnection.selectQuery("select listeddate from question where ques_no like " + Convert.ToInt32(e.Row.Cells[2].Text) + " and sadan like N'" + e.Row.Cells[0].Text + "' and session like '" + e.Row.Cells[1].Text + "'");
            if (listeds.HasRows)
            {
                while (listeds.Read())
                {
                    if (listeds.IsDBNull(0))
                    {
                        e.Row.Cells[7].Text = "<p style='color:red;'> Not Define </p>";
                    }
                    else
                    {
                        e.Row.Cells[7].Text = listeds.GetString(0);
                    }
                        
                }
            }

            SqlDataReader quesdetails = DataConnection.selectQuery("SELECT distinct   dbo.question_Detail.ques_detail FROM         dbo.question_Detail INNER JOIN dbo.member_Question ON dbo.question_Detail.quesid = dbo.member_Question.qid INNER JOIN dbo.Message ON dbo.member_Question.qno = dbo.Message.QNO AND dbo.member_Question.assemblys = dbo.Message.Assemblys AND dbo.member_Question.session = dbo.Message.Session where dbo.Message.Assemblys like '" + e.Row.Cells[0].Text + "' and dbo.Message.Session like '" + e.Row.Cells[1].Text + "' and dbo.Message.QNO  like " + Convert.ToInt32(e.Row.Cells[2].Text));
            if (quesdetails.HasRows)
            {
                int i = 0;
                while (quesdetails.Read())
                {
                    e.Row.Cells[5].Text += (++i).ToString() + ") " + quesdetails.GetString(0) + "<br/><br/>";
                }
            }

            SqlDataReader sendtos = DataConnection.selectQuery("SELECT dbo.member.member_name, dbo.Message.Submitted,dbo.Message.sgsubmit FROM  dbo.member INNER JOIN dbo.Message ON dbo.member.memeberid = dbo.Message.RCV where QNO=" + e.Row.Cells[2].Text + " and Assemblys='" + e.Row.Cells[0].Text + "' and Session='" + e.Row.Cells[1].Text + "' and forward is null");
            if (sendtos.HasRows)
            {
                int i = 0,j=0,k=0;
                bool status = false;
                while (sendtos.Read())
                {
                    e.Row.Cells[9].Text += (++i).ToString() + ". " + sendtos.GetString(0) + "<br/><br/>";
                    
                    if(sendtos.IsDBNull(1) || sendtos.GetString(1).Equals(""))
                    {
                        e.Row.Cells[10].Text += "<p style='color:red;'>" + (++j).ToString() + ". " + " Answer not Received " + "</p><br/>";
                        //e.Row.Cells[10].Attributes.Add("style", "color:red;");
                    }
                    else if (sendtos.GetString(1) == "T")
                    {
                        e.Row.Cells[10].Text += "<p style='color:green;'>" + (++j).ToString() + ". " + " Answer Received " + "</p><br/>";
                        //e.Row.Cells[10].Attributes.Add("style", "color:green;");
                    }

                    if (sendtos.IsDBNull(2) || sendtos.GetString(2).Equals(""))
                    {
                        if (status == false)
                        {
                            e.Row.Cells[11].Text += "<p style='color:red;'>" + (++k).ToString() + ". " + " Not Sent to Govenment " + "</p><br/>";
                            status = true;
                        }
                        //e.Row.Cells[11].Attributes.Add("style", "color:red;");
                    }
                    else if (sendtos.GetString(2) == "T")
                    {
                        if (status == false)
                        {
                            e.Row.Cells[11].Text += "<p style='color:green;'>" + (++k).ToString() + ". " + " Send To Government " + "</p><br/>";
                            status = true;
                        }
                    }

                }
            }
        }
    }
}
