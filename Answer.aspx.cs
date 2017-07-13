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
using System.Drawing;

public partial class Answer : System.Web.UI.Page
{
    protected string filename;
    protected int countques;
    protected int ansid;
    protected string btnc="";
    protected string ada = "";
    Label lblQuesHeading;
    Label lblAnswer;
    TextBox txtAnswer;
    Label lblAnsHeading;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] == null)
        {
            Response.Redirect("Welcome.aspx");
        }
        Session.Timeout = 120;
        Button3.Visible = false;
        ArrayList arrLabel2 = new ArrayList();
        Boolean vs = true;
        
        SqlDataReader reader = DataConnection.selectQuery("select ans_details from answer_detail where aid in (select distinct(member_answer.aid) from member_answer,Message where member_answer.quesno='" + Session["qno"].ToString() + "' and member_answer.assemblys='"+ Session["Ass"].ToString()  +"' and member_answer.session='"+ Session["sess"].ToString() +"' and member_answer.mid='" + Session["RCV1"].ToString() + "' and Message.QNO=member_answer.quesno and Message.Submitted='T' and Message.RCV=member_answer.mid)");
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                arrLabel2.Add(reader.GetString(0));
            }
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Button2.Visible = false;
            Button3.Visible = false;
            vs = false;
            ada = "T";
        }
        else
        {
            SqlDataReader reader1 = DataConnection.selectQuery("select ans_details from answer_detail where aid in (select distinct(member_answer.aid) from member_answer,Message where member_answer.quesno='" + Session["qno"].ToString() + "' and member_answer.assemblys='" + Session["Ass"].ToString() + "' and member_answer.session='" + Session["sess"].ToString() + "' and member_answer.mid='" + Session["RCV"].ToString() + "' and Message.QNO=member_answer.quesno and Message.ReadFlag='T' and Message.RCV=member_answer.mid)");
            if (reader1.HasRows)
            {
                while (reader1.Read())
                {
                    arrLabel2.Add(reader1.GetString(0));
                }
                vs = true;
                ada = "T";
                LinkButton2.Visible = true;
                LinkButton4.Visible = true;
            }
            else
            {
                LinkButton2.Visible = false;
                LinkButton4.Visible = false;
            }
            
        }

        messagebox.Visible = false;
        ArrayList arrLabel = new ArrayList();
        DataConnection.updateQuery("update message set readflag='T' where sender='"+ Application["Sender"].ToString() +"' and RCV='" + Session["RCV1"].ToString() + "' and QNO='" + Session["qno"].ToString() + "' and Assemblys='" + Session["Ass"].ToString() + "' and session='"+ Session["sess"].ToString() +"'");
        reader = DataConnection.selectQuery("select ques_detail from question_Detail where quesid in ( select qid from member_Question where qno=" + Convert.ToInt32(Session["qno"].ToString()) + " and assemblys='"+ Session["Ass"].ToString() +"' and  session='"+ Session["sess"].ToString() +"')");
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                arrLabel.Add(reader.GetString(0));
            }
        }
        DataConnection.closeConnection();

        countques = arrLabel.Count;
        

        addControls.Controls.Add(new LiteralControl("<div class='col-lg-12'>"));
        
        //String scriptText = "";

        for (int i = 0; i < countques; i++)
        {
            addControls.Controls.Add(new LiteralControl("<div class='panel panel-yellow' style='border : 3px solid brown; padding : 10px'>"));
            lblQuesHeading = new Label();
            lblQuesHeading.Text = "Questions" + (i+1);
            lblQuesHeading.Font.Bold = true;
            lblQuesHeading.Font.Size = 15;
            addControls.Controls.Add(new LiteralControl("<div class='form-group'>"));
            addControls.Controls.Add(lblQuesHeading);
            addControls.Controls.Add(new LiteralControl("</div>"));
            lblAnswer = new Label();
            //lblAnswer.CssClass = "form-control";
            lblAnswer.Height = 100;
            lblAnswer.Enabled = false;
            lblAnswer.Attributes.Add("style", "font-size : 20px;");
            //Adding TextBox
            txtAnswer = new TextBox();
            txtAnswer.CssClass = "form-control";
            txtAnswer.Attributes.Add("onblur", "this.value=convert_to_unicode(this.value);");
            txtAnswer.TextMode = TextBoxMode.MultiLine;
            txtAnswer.Attributes.Add("style", "font-family : 'DevLys 010'; font-size : 20px;");
            txtAnswer.ID = "legacy_text" + i;
            txtAnswer.Attributes.Add("onblur", "this.value=convert_to_unicode(this.value);");

            addControls.Controls.Add(new LiteralControl("<div class='form-group'>"));
            lblAnswer.Text = arrLabel[i].ToString();
            addControls.Controls.Add(lblAnswer);
            addControls.Controls.Add(new LiteralControl("</div>"));

            lblAnsHeading = new Label();
            lblAnsHeading.Text = "Answer" + (i+1);
            lblAnsHeading.Font.Size = 14;
            lblAnsHeading.Font.Bold = true;
            addControls.Controls.Add(new LiteralControl("<div class='form-group'>"));
            addControls.Controls.Add(lblAnsHeading);
            addControls.Controls.Add(new LiteralControl("</div>"));
            
            if (arrLabel2.Count > 0)
            {
                txtAnswer.Text = arrLabel2[i].ToString();
                txtAnswer.Enabled = vs;
            }
            //Adding Textbox
            addControls.Controls.Add(new LiteralControl("<div class='form-group'>"));
            addControls.Controls.Add(txtAnswer);
            addControls.Controls.Add(new LiteralControl("</div>"));
            addControls.Controls.Add(new LiteralControl("</div>"));
        }
        addControls.Controls.Add(new LiteralControl("</div>"));
    }

    
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

        SqlDataReader reader = DataConnection.selectQuery("select distinct(files_path) from question_pdf where quesno=" + Convert.ToInt32(Session["qno"].ToString()) + " and Assemblys='" + Session["Ass"].ToString() + "' and session='" + Session["sess"].ToString() +"'");
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                filename = reader.GetString(0);
            }
        }
        DataConnection.closeConnection();

        Response.Write(filename);
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

    protected void LinkButton3_Click(object sender, EventArgs e)
    {

        SqlDataReader reader = DataConnection.selectQuery("select distinct(file_path_xls) from question_pdf where quesno=" + Convert.ToInt32(Session["qno"].ToString()) + " and Assemblys='" + Session["Ass"].ToString() + "' and session='" + Session["sess"].ToString() +"'");
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                filename = reader.GetString(0);
            }
        }
        DataConnection.closeConnection();

        Response.Write(filename);
        string ftpurl = "ftp://localhost/";
        string ftpUserName = "FTPUser";
        string ftpPassword = "123456";
        string ftpFolder = "FormatQuestion/";

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

    protected void LinkButton2_Click(object sender, EventArgs e)
    {

        SqlDataReader reader = DataConnection.selectQuery("select distinct(file_path) from answer_pdf where aid in (select distinct(aid) from member_answer where quesno='" + Session["qno"].ToString() + "' and mid='" + Session["RCV1"].ToString() + "') and mid=" + Session["RCV1"].ToString());
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                filename = reader.GetString(0);
            }
        }
        else
        {
            string message = "Answer File Not Found";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + message + "');", true);
            return;
        }

        DataConnection.closeConnection();

        Response.Write(filename);
        string ftpurl = "ftp://localhost/";
        string ftpUserName = "FTPUser";
        string ftpPassword = "123456";
        string ftpFolder = "Answer/";

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

    protected void LinkButton4_Click(object sender, EventArgs e)
    {

        SqlDataReader reader = DataConnection.selectQuery("select distinct(file_path_xls) from answer_pdf where aid in (select distinct(aid) from member_answer where quesno='" + Session["qno"].ToString() + "' and mid='" + Session["RCV1"].ToString() + "') and mid=" + Session["RCV1"].ToString());
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                filename = reader.GetString(0);
            }
        }
        else
        {
            string message = "Answer File Not Found";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + message + "');", true);
            return;
        }

        DataConnection.closeConnection();

        Response.Write(filename);
        string ftpurl = "ftp://localhost/";
        string ftpUserName = "FTPUser";
        string ftpPassword = "123456";
        string ftpFolder = "FormatAnswer/";

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

    private bool IsPDF(HttpPostedFile file)
    {
        String[] validtype = { "jpg", "pdf", "jpeg" };
        //string ext = System.IO.Path.GetExtension(file.FileName);
        bool isValidFile = false;

        for (int i = 0; i < validtype.Length; i++)
        {
            if (Path.GetExtension(file.FileName).ToLower() == "." + validtype[i])
            {
                isValidFile = true;
                break;
            }
        }
        return isValidFile;
    }

    protected void uploads_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFiles)
        {
            HttpPostedFile files = (HttpPostedFile)FileUpload1.PostedFile;
            if ((files != null) && (files.ContentLength > 0))
            {
                if (!IsPDF(files))
                {
                    lblMessage.Text = "File should be pdf";
                    lblMessage.CssClass = "alert alert-danger";
                    return;
                }
            }

            int iFileSize = files.ContentLength;

            if (iFileSize > 1000000)
            {
                lblMessage.Text = "File size is more than 1 MB";
                lblMessage.CssClass = "alert alert-danger";
                return;
            }

            Button4_Click(sender,e);
            btnc = "T";
            
            //DataBase Connection
            if (ada == "")
            {
                SqlDataReader chk = DataConnection.selectQuery("select * from answer_pdf where aid=" + ansid);
                if (chk.HasRows)
                {
                    DataConnection.insertQuery("update answer_pdf set file_path = N'" + Path.GetFileName(FileUpload1.FileName) + "' where aid=" + ansid);
                }
                else
                {
                    DataConnection.insertQuery("insert into answer_pdf(mid,aid,file_path,date,time) values(" + Convert.ToInt32(Session["RCV1"].ToString()) + "," + ansid + ",'" + Path.GetFileName(FileUpload1.FileName) + "',GETDATE(),SYSDATETIME())");
                }
                
            }
            else 
            {
                DataConnection.insertQuery("update answer_pdf set file_path='" + Path.GetFileName(FileUpload1.FileName) + "',date=GETDATE(),time=SYSDATETIME() where mid=" + Convert.ToInt32(Session["RCV1"].ToString()) + " and aid=" + ansid);
            }
            string sourcefilepath = Path.GetFileName(FileUpload1.FileName);
            string ftpurl = "ftp://localhost/";
            string ftpUserName = "FTPUser";
            string ftpPassword = "123456";
            string ftpFolder = "Answer/";
            
            try
            {
                UploadFileToFtp(ftpurl, sourcefilepath.ToString(), ftpUserName, ftpPassword, ftpFolder);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        else
        {
            lblMessage.Text = "Please Select File ";
            lblMessage.CssClass = "alert alert-danger";
        }
    }

    public void UploadFileToFtp(string fileurl, string sourcefilepath, string fusername, string fpassword, string ftpFolder)
    {
        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(fileurl + ftpFolder + sourcefilepath);
        request.Method = WebRequestMethods.Ftp.UploadFile;
        request.Credentials = new NetworkCredential(fusername, fpassword);

        byte[] fileBytes = FileUpload1.FileBytes;
        request.ContentLength = fileBytes.Length;
        Stream requeststream = request.GetRequestStream();
        requeststream.Write(fileBytes, 0, fileBytes.Length);
        requeststream.Close();

        lblMessage.Visible = true;
        lblMessage.Text = "";
        lblMessage.CssClass = "alert alert-success";
        lblMessage.Text += FileUpload1.PostedFile.FileName + " uploaded.<br />";
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        
        //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + message + "');", true);
        if (btnc=="")
        {
            Button4_Click(sender, e);
        }
        DataConnection.insertQuery("update Message set RespFlag = 'T' where sender='" + Application["Sender"].ToString() + "' and QNo = " + Convert.ToInt32(Session["qno"].ToString()) + " and session=N'" + Session["sess"].ToString() + "' and Assemblys=N'" + Session["Ass"].ToString() + "' and RCV='" + Session["RCV"].ToString() + "'");
        messagebox.Visible = true;
        Button3.Visible = true;
        
    }

    protected void Button4_Click(object sender, EventArgs e)
    {

        //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + message + "');", true);
        if (ada == "")
        {
            DataConnection.insertQuery("insert into member_answer (quesno,mid,date,time,assemblys,session) values(" + Convert.ToInt32(Session["qno"].ToString()) + "," + Convert.ToInt32(Session["RCV1"].ToString()) + ",GETDATE(),SYSDATETIME(),N'"+ Session["Ass"].ToString() +"',N'"+ Session["sess"].ToString() +"')");
        }
        else {
            DataConnection.updateQuery("update member_answer set date=GETDATE(),time=SYSDATETIME() where quesno=" + Convert.ToInt32(Session["qno"].ToString()) + " and mid=" + Convert.ToInt32(Session["RCV1"].ToString()));
        }
        //Fetch Aid from
        SqlDataReader reader = DataConnection.selectQuery("select aid from member_answer where quesno = " + Convert.ToInt32(Session["qno"]));
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                ansid = reader.GetInt32(0);
            }
        }
        DataConnection.closeConnection();
        reader.Close();
        int i = 0;
        foreach (TextBox text in addControls.Controls.OfType<TextBox>())
        {
            if (ada == "")
            {
                DataConnection.insertQuery("insert into answer_detail values(" + ansid + "," + i + ",N'" + text.Text + "')");
            }
            else
            {
                DataConnection.insertQuery("update answer_detail set ans_details=N'" + text.Text + "' where srno=" + i + " and aid=" + ansid);
            }
            i++;
        }
    }


    protected void Button3_Click(object sender, EventArgs e)
    {
        int aid=0;
        SqlDataReader reader = DataConnection.selectQuery("select aid from Answeridview");
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                aid = reader.GetInt32(0);
            }
        }
        DataConnection.updateQuery("update message set submitted='T' , pending='T' , aid =" + aid + " where sender='" + Application["Sender"].ToString() + "' and RCV=N'" + Session["RCV1"].ToString() + "' and QNO=N'" + Session["qno"].ToString() + "' and session=N'" + Session["sess"].ToString() + "' and Assemblys=N'" + Session["Ass"].ToString() + "'");
        Response.Redirect("Dashboard.aspx");
    }
    public void UploadFileToFtp2(string fileurl, string sourcefilepath, string fusername, string fpassword, string ftpFolder)
    {
        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(fileurl + ftpFolder + sourcefilepath);
        request.Method = WebRequestMethods.Ftp.UploadFile;
        request.Credentials = new NetworkCredential(fusername, fpassword);

        byte[] fileBytes = FileUpload2.FileBytes;
        request.ContentLength = fileBytes.Length;
        Stream requeststream = request.GetRequestStream();
        requeststream.Write(fileBytes, 0, fileBytes.Length);
        requeststream.Close();

        lblFormat.Visible = true;
        lblFormat.Text = "";
        lblFormat.CssClass = "alert alert-success";
        lblFormat.Text += FileUpload2.PostedFile.FileName + " uploaded.<br />";
    }
    private bool IsExcel(HttpPostedFile file)
    {
        String[] validtype = { "xls", "xlsx", "doc", "docx" };
        //string ext = System.IO.Path.GetExtension(file.FileName);
        bool isValidFile = false;

        for (int i = 0; i < validtype.Length; i++)
        {
            if (Path.GetExtension(file.FileName).ToLower() == "." + validtype[i])
            {
                isValidFile = true;
                break;
            }
        }
        return isValidFile;
    }
    protected void uploads2_Click(object sender, EventArgs e)
    {
        if (FileUpload2.HasFiles)
        {
            HttpPostedFile files = (HttpPostedFile)FileUpload2.PostedFile;
            if ((files != null) && (files.ContentLength > 0))
            {
                if (!IsExcel(files))
                {
                    lblFormat.Text = "File should be pdf";
                    lblFormat.CssClass = "alert alert-danger";
                    return;
                }
            }

            int iFileSize = files.ContentLength;

            if (iFileSize > 1000000)
            {
                lblFormat.Text = "File size is more than 1 MB";
                lblFormat.CssClass = "alert alert-danger";
                return;
            }

            Button4_Click(sender, e);
            btnc = "T";

            //DataBase Connection
            if (ada == "")
            {
                SqlDataReader chk = DataConnection.selectQuery("select * from answer_pdf where aid=" + ansid);
                if (chk.HasRows)
                {
                    DataConnection.insertQuery("update answer_pdf set file_path_xls = N'" + Path.GetFileName(FileUpload2.FileName) + "' where aid=" + ansid);

                }
                else
                {
                    DataConnection.insertQuery("insert into answer_pdf(mid,aid,file_path,date,time) values(" + Convert.ToInt32(Session["RCV1"].ToString()) + "," + ansid + ",'" + Path.GetFileName(FileUpload2.FileName) + "',GETDATE(),SYSDATETIME())");
                }
            }
            else
            {
                DataConnection.insertQuery("update answer_pdf set file_path_xls='" + Path.GetFileName(FileUpload2.FileName) + "',date=GETDATE(),time=SYSDATETIME() where mid=" + Convert.ToInt32(Session["RCV1"].ToString()) + " and aid=" + ansid);
            }
            string sourcefilepath = Path.GetFileName(FileUpload2.FileName);
            string ftpurl = "ftp://localhost/";
            string ftpUserName = "FTPUser";
            string ftpPassword = "123456";
            string ftpFolder = "FormatAnswer/";

            try
            {
                UploadFileToFtp2(ftpurl, sourcefilepath.ToString(), ftpUserName, ftpPassword, ftpFolder);

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        else
        {
            lblMessage.Text = "Please Select File ";
            lblMessage.CssClass = "alert alert-danger";
        }

    }

}