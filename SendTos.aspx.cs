using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class SendTos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["UserId"] == null)
        {
            Response.Redirect("Welcome.aspx");
        }
        if (Session["sgques"].ToString() == "SendData")
        {
            CheckBoxList1.Enabled = false;
            //CheckBoxList2.Enabled = true;
            //CheckBoxList3.Enabled = true;
            //CheckBoxList4.Enabled = true;
            //CheckBoxList5.Enabled = true;
            //CheckBoxList6.Enabled = true;
            
            TextBox1.Enabled = false;
            TextBox2.Enabled = false;
            TextBox3.Enabled = false;
            TextBox4.Enabled = false;
        }
        SqlDataReader r = DataConnection.selectQuery("select relatedVibag, membernames from question where ques_no=" + Convert.ToInt32(Session["quesno"].ToString()) +" and sadan='" + Session["sadan"] +"' and session='" + Session["session"] + "'");
        if (r.HasRows)
        {
            while (r.Read())
            {
                Session["Vibhag"] = r.GetString(0);
                Session["memberName"] = r.GetString(1);
            }
        }
        
        Questions.Text = "प्रश्‍न संख्या & " + Session["quesno"].ToString() + "@" + Session["Vibhag"].ToString() + "] " + Session["memberName"].ToString();
        
        CheckBoxList1.Items.Clear();
        //CheckBoxList2.Items.Clear();
        //CheckBoxList3.Items.Clear();
        SqlDataReader reader = DataConnection.selectQuery("SELECT dbo.question_Detail.ques_detail FROM         dbo.member_Question INNER JOIN dbo.question ON dbo.member_Question.qno = dbo.question.ques_no AND dbo.member_Question.assemblys = dbo.question.sadan AND dbo.member_Question.session = dbo.question.session INNER JOIN dbo.question_Detail ON dbo.member_Question.qid = dbo.question_Detail.quesid WHERE     (dbo.question.ques_no = " + Convert.ToInt32(Session["quesno"].ToString()) + ") AND (dbo.member_Question.assemblys = '" + Session["sadan"].ToString() + "') AND (dbo.member_Question.session = '" + Session["session"].ToString() + "')");
        if (reader.HasRows)
        {
            //List<String> lst = new List<string>();
            while (reader.Read())
            {
                CheckBoxList1.Items.Add(reader.GetString(0));
            }
        }

        for (int i = 0; i < CheckBoxList1.Items.Count; i++)
        {
            CheckBoxList1.Items[i].Selected = true;
        }

        int count = CheckBoxList2.Items.Count;
        reader = DataConnection.selectQuery("select location,memeberid from member where Department='section'");
        if (reader.HasRows)
        {
            
            while (reader.Read())
            {
                ListItem item = new ListItem();
                item.Text = reader.GetString(0);
                item.Value = reader.GetInt32(1).ToString();
                item.Selected = false;
                CheckBoxList2.Items.Add(item);
            }
        }

        count = CheckBoxList3.Items.Count;
        reader = DataConnection.selectQuery("select location,memeberid from member where Department='dist'");
        if (reader.HasRows)
        {
            
            while (reader.Read())
            {
                ListItem item = new ListItem();
                item.Text = reader.GetString(0);
                item.Value = reader.GetInt32(1).ToString();
                item.Selected = false;
                CheckBoxList3.Items.Add(item);
            }
        }
        count = CheckBoxList4.Items.Count;
        reader = DataConnection.selectQuery("select location,memeberid from member where Department='DC'");
        if (reader.HasRows)
        {
            
            while (reader.Read())
            {
                ListItem item = new ListItem();
                item.Text = reader.GetString(0);
                item.Value = reader.GetInt32(1).ToString();
                item.Selected = false;
                CheckBoxList4.Items.Add(item);
            }
        }
        count = CheckBoxList5.Items.Count;
        reader = DataConnection.selectQuery("select location,memeberid from member where Department='RAA'");
        if (reader.HasRows)
        {
            
            while (reader.Read())
            {
                ListItem item = new ListItem();
                item.Text = reader.GetString(0);
                item.Value = reader.GetInt32(1).ToString();
                item.Selected = false;
                CheckBoxList5.Items.Add(item);
            }
        }
        count = CheckBoxList6.Items.Count;
        reader = DataConnection.selectQuery("select location,memeberid from member where Department='SO'");
        if (reader.HasRows)
        {
            
            while (reader.Read())
            {
                ListItem item = new ListItem();
                item.Text = reader.GetString(0);
                item.Value = reader.GetInt32(1).ToString();
                item.Selected = false;
                CheckBoxList6.Items.Add(item);
            }
        }

        SqlDataReader read = DataConnection.selectQuery("select location,Department  from member where memeberid in (select rcv from Message where QNO='" + Session["quesno"].ToString() + "' and Assemblys='" + Session["sadan"].ToString() + "' and Session='" + Session["session"].ToString() + "' and Sender='" + Session["RCV"].ToString() + "' and submitted='T')");
        if (read.HasRows)
        {
            while (read.Read())
            {
                if (read.GetString(1) == "section")
                {
                    for (int i = 0; i < CheckBoxList2.Items.Count; i++)
                    {
                        if (CheckBoxList2.Items[i].Text.Trim() == read.GetString(0).Trim())
                        {
                            CheckBoxList2.Items[i].Selected = true;
                        }
                    }
                }

                if (read.GetString(1) == "Dist")
                {
                    for (int i = 0; i < CheckBoxList3.Items.Count; i++)
                    {
                        if (CheckBoxList3.Items[i].Text == read.GetString(0))
                        {
                            CheckBoxList3.Items[i].Selected = true;
                        }
                    }
                }

                if (read.GetString(1) == "DC")
                {
                    for (int i = 0; i < CheckBoxList4.Items.Count; i++)
                    {
                        if (CheckBoxList4.Items[i].Text.Trim() == read.GetString(0).Trim())
                        {
                            CheckBoxList4.Items[i].Selected = true;
                        }
                    }
                }
                if (read.GetString(1) == "RAA")
                {
                    for (int i = 0; i < CheckBoxList5.Items.Count; i++)
                    {
                        if (CheckBoxList5.Items[i].Text.Trim() == read.GetString(0).Trim())
                        {
                            CheckBoxList5.Items[i].Selected = true;
                        }
                    }
                }
                if (read.GetString(1) == "SO")
                {
                    for (int i = 0; i < CheckBoxList6.Items.Count; i++)
                    {
                        if (CheckBoxList6.Items[i].Text == read.GetString(0))
                        {
                            CheckBoxList6.Items[i].Selected = true;
                        }
                    }
                }

            }
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        string message = "";
        string memberno = "";
        CheckBoxList2.DataBind();
        CheckBoxList3.DataBind();
        CheckBoxList4.DataBind();
        CheckBoxList5.DataBind();
        CheckBoxList6.DataBind();

        if (Session["sgques"].ToString() == "SendData")
        {
            DataConnection.insertQuery("update message set sgsubmit='T' where QNO=N'" + Session["quesno"].ToString() + "' and Assemblys=N'" + Session["sadan"].ToString() + "' and Session=N'" + Session["session"].ToString() + "'");
            DataConnection.insertQuery("insert into miscellenous (other_posist_name,posist_no,posist_date,answer_mem_name,ans_no,ans_date,remark,session,assemblys,quesno) values('" + TextBox8.Text + "','" + TextBox9.Text + "','" + Convert.ToDateTime(TextBox10.Text) + "','" + TextBox11.Text + "','" + TextBox12.Text + "','" + Convert.ToDateTime(TextBox13.Text) + "','" + TextBox14.Text + "','" + Session["session"].ToString() + "','" + Session["sadan"] + "'," + Convert.ToInt32(Session["quesno"].ToString()) + ")");
            
            Response.Redirect("Dashboard.aspx");
        }
        else
        {
            if (getCheckBoxCount(CheckBoxList2) > 0)
            {
                for (int i = 0; i < CheckBoxList2.Items.Count; i++)
                {
                    if (CheckBoxList2.Items[i].Selected)
                    {
                        SqlDataReader r1 = DataConnection.selectQuery("select memeberid from member where member_name=N'" + CheckBoxList2.Items[i].Text.Trim() + "'");
                        if (r1.HasRows)
                        {
                            while (r1.Read())
                            {
                                memberno = r1.GetInt32(0).ToString();
                            }
                        }
                        r1.Close();

                        DataConnection.insertQuery("insert into message(QNO,RCV,Sender,Assemblys,Session) values(N'" + Session["quesno"].ToString() + "',N'" + memberno + "',N'" + Session["RCV"].ToString() + "',N'" + Session["assembly"].ToString() + "',N'" + Session["Session"].ToString() + "')");
                    }
                }
            }

            if (getCheckBoxCount(CheckBoxList3) > 0)
            {
                for (int i = 0; i < CheckBoxList3.Items.Count; i++)
                {
                    if (CheckBoxList3.Items[i].Selected)
                    {
                        SqlDataReader r = DataConnection.selectQuery("select memeberid from member where location=N'" + CheckBoxList3.Items[i].Text.Trim() + "'");
                        if (r.HasRows)
                        {
                            while (r.Read())
                            {
                                memberno = r.GetInt32(0).ToString();
                            }
                        }
                        r.Close();

                        DataConnection.insertQuery("insert into message(QNO,RCV,Sender,Assemblys,Session) values(N'" + Session["quesno"].ToString() + "',N'" + memberno + "',N'" + Session["RCV"].ToString() + "',N'" + Session["assembly"].ToString() + "',N'" + Session["Session"].ToString() + "')");
                    }

                }
            }

            if (getCheckBoxCount(CheckBoxList4) > 0)
            {
                for (int i = 0; i < CheckBoxList4.Items.Count; i++)
                {
                    if (CheckBoxList4.Items[i].Selected)
                    {
                        SqlDataReader re = DataConnection.selectQuery("select memeberid from member where location=N'" + CheckBoxList4.Items[i].Text.Trim() + "'");
                        if (re.HasRows)
                        {
                            while (re.Read())
                            {
                                memberno = re.GetInt32(0).ToString();
                            }
                            re.Close();
                            DataConnection.insertQuery("insert into message(QNO,RCV,Sender,Assemblys,Session) values(N'" + Session["quesno"].ToString() + "',N'" + memberno + "',N'" + Session["RCV"].ToString() + "',N'" + Session["assembly"].ToString() + "',N'" + Session["Session"].ToString() + "')");
                        }
                    }
                }
            }

            if (getCheckBoxCount(CheckBoxList5) > 0)
            {
                for (int i = 0; i < CheckBoxList5.Items.Count; i++)
                {
                    if (CheckBoxList5.Items[i].Selected)
                    {
                        SqlDataReader re2 = DataConnection.selectQuery("select memeberid from member where location=N'" + CheckBoxList5.Items[i].Text.Trim() + "'");
                        if (re2.HasRows)
                        {
                            while (re2.Read())
                            {
                                memberno = re2.GetInt32(0).ToString();
                            }
                            re2.Close();
                            DataConnection.insertQuery("insert into message(QNO,RCV,Sender,Assemblys,Session) values(N'" + Session["quesno"].ToString() + "',N'" + memberno + "',N'" + Session["RCV"].ToString() + "',N'" + Session["assembly"].ToString() + "',N'" + Session["Session"].ToString() + "')");
                        }
                    }
                }
            }


            if (getCheckBoxCount(CheckBoxList6) > 0)
            {
                for (int i = 0; i < CheckBoxList6.Items.Count; i++)
                {
                    if (CheckBoxList6.Items[i].Selected)
                    {
                        SqlDataReader re3 = DataConnection.selectQuery("select memeberid from member where location=N'" + CheckBoxList6.Items[i].Text.Trim() + "'");
                        if (re3.HasRows)
                        {
                            while (re3.Read())
                            {
                                memberno = re3.GetInt32(0).ToString();
                            }
                            re3.Close();
                            DataConnection.insertQuery("insert into message(QNO,RCV,Sender,Assemblys,Session) values(N'" + Session["quesno"].ToString() + "',N'" + memberno + "',N'" + Session["RCV"].ToString() + "',N'" + Session["assembly"].ToString() + "',N'" + Session["Session"].ToString() + "')");
                        }
                    }
                }

            }


            if(getCheckBoxCount(CheckBoxList2) < 0)
            {
                message = "Select Atleast Section ";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + message + "');", true);
                return;
            }
        }
        message = "Data has Stored Successfully";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + message + "');", true);
        Response.Redirect("Dashboard.aspx");
    }

    public int getCheckBoxCount(CheckBoxList csk)
    {
        int count = 0;
        for (int i = 0; i < csk.Items.Count; i++)
        {
            if (csk.Items[i].Selected)
            {
                count++;
            }
        }
        return count;
    }

}