using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Dashboard : System.Web.UI.Page
{
    int ind1 = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] == null)
        {
            Response.Redirect("Welcome.aspx");
        }

        SqlDataReader reader1 = DataConnection.selectQuery("select COUNT(*) from Message where RCV=" + Session["RCV"]);
        if (reader1.HasRows)
        {
            while (reader1.Read())
            {
                totalQues.Text = reader1.GetInt32(0).ToString();
            }
        }
        reader1.Close();

        SqlDataReader reader2 = DataConnection.selectQuery("select COUNT(*) from Message where RCV=" + Session["RCV"] + " and Submitted='T'");
        if (reader2.HasRows)
        {
            while (reader2.Read())
            {
                leftQues.Text = reader2.GetInt32(0).ToString();
            }
        }
        reader2.Close();

        leftQuestion.Text = Math.Abs(Convert.ToInt32(totalQues.Text) - Convert.ToInt32(leftQues.Text)).ToString();

        SqlDataReader reader4 = DataConnection.selectQuery("select count(*) from question where memberno =" + Convert.ToInt32(Session["RCV"].ToString()));
        if (reader4.HasRows)
        {
            while (reader4.Read())
            {
                TotalQuesC.Text = reader4.GetInt32(0).ToString();
            }
        }

        SqlDataReader reader5 = DataConnection.selectQuery("select count(distinct Sender) as StGC from Message where sgsubmit='T' and sender=N'" + Session["RCV"] + "'");
        if (reader5.HasRows)
        {
            while (reader5.Read())
            {
                TotalAnswerC.Text = reader5.GetInt32(0).ToString();
                
            }
        }

        TotalAnswerNC.Text = Math.Abs( Convert.ToInt32(TotalQuesC.Text) - Convert.ToInt32(TotalAnswerC.Text) ).ToString();

        SqlDataReader reader6 = DataConnection.selectQuery("select COUNT(rcv) from Message where Sender='" + Session["RCV"] + "' and sgsubmit is null");
        if (reader6.HasRows)
        {
            while (reader6.Read())
            {
                AnswerP.Text = reader6.GetInt32(0).ToString();
            }
        }

        SqlDataReader reader7 = DataConnection.selectQuery("select COUNT(rcv) from Message where Sender='" + Session["RCV"] + "' and sgsubmit is null and Submitted='T'");
        if (reader7.HasRows)
        {
            while (reader7.Read())
            {
                AnswerPrat.Text = reader7.GetInt32(0).ToString();
            }
        }

        NonAnswered.Text = Math.Abs(Convert.ToInt32(AnswerP.Text) - Convert.ToInt32(AnswerPrat.Text)).ToString();

        SqlDataReader reader8 = DataConnection.selectQuery("select COUNT(*) from Message where RCV=" + Session["RCV"]);
        if (reader8.HasRows)
        {
            while (reader8.Read())
            {
                TotalSectionQuestionR.Text = reader8.GetInt32(0).ToString();

            }
        }

        SqlDataReader reader9 = DataConnection.selectQuery("select COUNT(*) from Message where submitted='T' and RCV=" + Session["RCV"]);
        if (reader9.HasRows)
        {
            while (reader9.Read())
            {
                TotalSectionA.Text = reader9.GetInt32(0).ToString();

            }
        }

        DifferentLeftSection.Text = Convert.ToString(Convert.ToInt32(TotalSectionQuestionR.Text) - Convert.ToInt32(TotalSectionA.Text));

        SqlDataReader reader10 = DataConnection.selectQuery("select COUNT(*) from Message where sender=" + Session["RCV"]);
        if (reader10.HasRows)
        {
            while (reader10.Read())
            {
                TotalQusF.Text = reader10.GetInt32(0).ToString();

            }
        }

        SqlDataReader reader11 = DataConnection.selectQuery("select COUNT(*) from Message where submitted='T' and sender=" + Session["RCV"]);
        if (reader11.HasRows)
        {
            while (reader11.Read())
            {
                TotalQusFA.Text = reader11.GetInt32(0).ToString();
                
            }
        }

        DifferentQF.Text = Math.Abs(Convert.ToInt32(TotalQusF.Text) - Convert.ToInt32(TotalQusFA.Text)).ToString();
        
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "SendButton")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[index];
            Session["quesno"] = row.Cells[1].Text;
            Session["sadan"] = row.Cells[2].Text;
            Session["assembly"] = row.Cells[2].Text;
            Session["session"] = row.Cells[3].Text;
            Session["Session"] = row.Cells[3].Text;
            Session["memberno"] = Session["RCV"];
            Session["Vibhag"] = row.Cells[5].Text;
            Session["memberName"] = row.Cells[10].Text;
            Session["sgques"] = "";
            Response.Redirect("SendTos.aspx");
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Text = (++ind1).ToString();
        }
    }
}