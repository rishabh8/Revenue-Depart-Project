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


public partial class Questions : System.Web.UI.Page
{
    //public static int memberno;
    public static int questionid = 1;
    public string Values;
    public string sadhanValue = "";
    public string sessionValue = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] == null)
        {
            Response.Redirect("Welcome.aspx");
        }
        ////memberNamess.Items.Add("Select");
        if (!Page.IsPostBack)
        {
            Session["quno"] = 0;
            sadhan.Items.Clear();
            session.Items.Clear();
            sadhan.Items.Add("सदन");
            session.Items.Add("सत्र");
            SqlDataReader memname = DataConnection.selectQuery("select member_name from MLA_member");
            if (memname.HasRows)
            {
                while (memname.Read())
                {
                    memberNamess.Items.Add(memname.GetString(0));
                }
            }

            SqlDataReader assem = DataConnection.selectQuery("select distinct assemblys from AssemblySession");
            if (assem.HasRows)
            {
                while (assem.Read())
                {
                    sadhan.Items.Add(assem.GetString(0));
                }
            }
            SqlDataReader sess = DataConnection.selectQuery("select distinct session from AssemblySession");
            if (sess.HasRows)
            {
                while (sess.Read())
                {
                    session.Items.Add(sess.GetString(0));
                }
            }
            SqlDataReader grp = DataConnection.selectQuery("select * from mst_group");
            if (grp.HasRows)
            {
                while (grp.Read())
                {

                }
            }
        }
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
    private bool IsExcel(HttpPostedFile file)
    {
        String[] validtype = { "xls", "xlsx", "doc","docx" };
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
            if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
            {
                if (!IsPDF(FileUpload1.PostedFile))
                {
                    lblMessage.Text = "File should be pdf";
                    lblMessage.CssClass = "alert alert-danger";
                    return;
                }
            }

            int iFileSize = FileUpload1.PostedFile.ContentLength;

            if (iFileSize > 5242880)
            {
                lblMessage.Text = "File size is more than 5 MB";
                lblMessage.CssClass = "alert alert-danger";
                return;
            }

            if (!validate())
            {
                focusOnControl();
                string message = "Please Enter Data on Focus Control !!";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + message + "');", true);
                return;
            }
            else
            {

                StringBuilder sourcefilepath = new StringBuilder();
                sourcefilepath.Append(FileUpload1.FileName.Substring(0, FileUpload1.FileName.Length - 4));
                sourcefilepath.Append("_");
                sourcefilepath.Append(Session["RCV"].ToString());
                sourcefilepath.Append(quesno.Text);
                sourcefilepath.Append(sadhan.Text);
                sourcefilepath.Append(session.Text);
                sourcefilepath.Append(Path.GetExtension(FileUpload1.PostedFile.FileName));

                string ftpurl = "ftp://localhost/";
                string ftpUserName = "FTPUser";
                string ftpPassword = "123456";
                string ftpFolder = "Question/";

                try
                {
                    UploadFileToFtp(ftpurl, sourcefilepath.ToString(), ftpUserName, ftpPassword, ftpFolder);
                    //Insert Data into question_pdf table 
                    DataConnection.insertQuery("insert into question_pdf(mid,quesno,files_path,date,time,assemblys,session) values(" + Session["RCV"].ToString() + "," + Convert.ToInt32(quesno.Text) + ",'" + sourcefilepath.ToString() + "',GETDATE(),SYSDATETIME(),N'"+ sadhan.Text.Trim() +"','"+ session.Text.Trim() +"')");
                }
                catch (Exception ex)
                {
                    string message = "Error in Uploading" + ex.Message;
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + message + "');", true);
                }
            }
        }
        else
        {
            lblMessage.CssClass = "alert alert-danger";
            lblMessage.Text = "Please Select Filename ";
            return;
        }
    }


    public void UploadFileToFtp(string fileurl,string sourcefilepath, string fusername, string fpassword, string ftpFolder)
    {
        FtpWebRequest request = (FtpWebRequest) WebRequest.Create(fileurl + ftpFolder + sourcefilepath);
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
    

    public bool validate()
    {
        
        if (sadhan.SelectedIndex == 0)
        {
            sadhan.CssClass = "form-control panel panel-red";
            return false;
        }
        if (session.SelectedValue.Equals("Session"))
        {
            session.CssClass = "form-control panel panel-red";
            return false;
        }
        if (quesno.Text == "")
        {
            quesno.CssClass = "form-control panel panel-red";
            return false;
        }
        if (groupno.SelectedValue.Equals("Select"))
        {
            groupno.CssClass = "form-control panel panel-red";
            return false;
        }
        if (revenueQuesno.Text == "")
        {
            revenueQuesno.CssClass = "form-control panel panel-red";
            return false;
        }
        if (relatatedvibhag.Text == "")
        {
            relatatedvibhag.CssClass = "form-control panel panel-red";
            return false;
        }
        if (quesType.SelectedValue.Equals("Select"))
        {
            quesType.CssClass = "form-control panel panel-red";
            return false;
        }
        if (listed.SelectedValue.Equals("Select"))
        {
            listed.CssClass = "form-control panel panel-red";
            return false;
        }
        
        return true;

    }

    public void focusOnControl()
    {
        
        if (sadhan.SelectedIndex == 0)
        {
            sadhan.Focus();
        }
        else if (session.SelectedIndex == 0)
        {
            session.Focus();
        }
        else if (quesno.Text == "")
        {
            quesno.Focus();
        }
        else if (groupno.Text == "")
        {
            groupno.Focus();
        }
        else if (revenueQuesno.Text == "")
        {
            revenueQuesno.Focus();
        }
        else if (relatatedvibhag.Text == "")
        {
            relatatedvibhag.Focus();
        }
        else if (quesType.SelectedIndex == 0)
        {
            quesType.Focus();
        }
        else if (listed.SelectedIndex == 0 )
        {
            listed.Focus();
        }
    }

    protected void savedetails_Click(object sender, EventArgs e)
    {
        if (!validate())
        {
            focusOnControl();
            string message = "Please Enter Data on Focus Control !!";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + message + "');", true);
            return;
        }
        else
        {
            try
            {
                ArrayList ques = new ArrayList();

                string[] textboxValues = Request.Form.GetValues("DynamicTextBox");
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                for (int i = 0; i < textboxValues.Length; i++)
                {
                    if (textboxValues[i] != "")
                    {
                        ques.Add(textboxValues[i]);
                    }
                }
                this.Values = serializer.Serialize(ques);

                if (listed.SelectedIndex == 2)
                {
                    //Insert Data into Question table
                    DataConnection.insertQuery("insert into question(ques_no,sadan,session,groupno,revenueQuesNo,relatedVibag,quesType,memberno,listed,branchdate,membernames) values(" + Convert.ToInt32(quesno.Text) + ",N'" + sadhan.SelectedValue.ToString() + "',N'" + session.SelectedValue.ToString() + "',N'" + groupno.SelectedValue.ToString() + "',N'" + revenueQuesno.Text.Trim() + "',N'" + relatatedvibhag.Text.Trim() + "',N'" + quesType.Text.Trim() + "'," + Convert.ToInt32(Session["RCV"]) + ",N'" + listed.SelectedValue.ToString() + "','" + Convert.ToDateTime(branchDate.Text) + "',N'" + memberNamess.SelectedValue.Trim() + "')");
                }
                else
                {
                    DataConnection.insertQuery("insert into question(ques_no,sadan,session,groupno,revenueQuesNo,relatedVibag,quesType,memberno,listed,listeddate,branchdate,membernames) values(" + Convert.ToInt32(quesno.Text) + ",N'" + sadhan.SelectedValue.ToString() + "',N'" + session.SelectedValue.ToString() + "',N'" + groupno.SelectedValue.ToString() + "',N'" + revenueQuesno.Text.Trim() + "',N'" + relatatedvibhag.Text.Trim() + "',N'" + quesType.Text.Trim() + "'," + Convert.ToInt32(Session["RCV"]) + ",N'" + listed.SelectedValue.ToString() + "','"+Convert.ToDateTime(listedDate.Text)+"','" + Convert.ToDateTime(branchDate.Text) + "',N'"+ memberNamess.SelectedValue.Trim() +"')");
                }


                //Insert Data into member_Question table
                DataConnection.insertQuery("insert into member_question (mid,qno,date,time,assemblys,session) values(" + Convert.ToInt32(Session["RCV"].ToString()) + "," + Convert.ToInt32(quesno.Text) + ",GETDATE(),SYSDATETIME(),N'"+ sadhan.SelectedValue.Trim() +"',N'"+ session.SelectedValue.Trim() +"')");

                //Fetch quesid from member_question table
                int quesid = 0;
                SqlDataReader reader = DataConnection.selectQuery("select qid from member_question where qno=" + Convert.ToInt32(quesno.Text));
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        quesid = reader.GetInt32(0);
                    }
                }
                DataConnection.closeConnection();

                //Insert Data into question_Detail table
                if (quesid > 0)
                {
                    int i = 0;
                    foreach (string qa in ques)
                    {
                        DataConnection.insertQuery("insert into question_Detail values(" + quesid + "," + ++i + ",N'" + qa.ToString().Trim() + "')");
                    }
                }
                Session["quesno"] = quesno.Text;
                Session["memberno"] = Session["RCV"];
                Session["assembly"] = sadhan.Text;
                Session["sadan"] = sadhan.Text;
                Session["Session"] = session.Text;
                Session["session"] = session.Text;
                Session["Vibhag"] = relatatedvibhag.Text;
                Session["memberName"] = memberNamess.Text;
                Session["sgques"] = "";
                Response.Redirect("SendTos.aspx");
                
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + ex.Message + "');", true);
            }
        }
    }


    protected void quesno_TextChanged(object sender, EventArgs e)
    {
        SqlDataReader reader = DataConnection.selectQuery("select * from question where ques_no=" + Convert.ToInt32(quesno.Text) + " and session=N'" + session.SelectedValue + "' and sadan=N'" + sadhan.SelectedValue + "'");
        if (reader.HasRows)
        {
            string message = "Quesno Already present!! Please Change it..";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + message + "');", true);
            quesno.Text = "";
            quesno.Focus();
        }
        else
        {
            groupno.Focus();
        }

        DataConnection.closeConnection();
    }
    
    protected void uploads2_Click(object sender, EventArgs e)
    {
        if (FileUpload2.HasFiles)
        {
            if ((FileUpload2.PostedFile != null) && (FileUpload2.PostedFile.ContentLength > 0))
            {
                if (!IsExcel(FileUpload2.PostedFile))
                {
                    lblMessage.Text = "File should be in Excel or Word";
                    lblMessage.CssClass = "alert alert-danger";
                    return;
                }
            }

            int iFileSize = FileUpload2.PostedFile.ContentLength;

            if (iFileSize > 5242880)
            {
                lblMessage.Text = "File size is more than 5 MB";
                lblMessage.CssClass = "alert alert-danger";
                return;
            }

            if (!validate())
            {
                focusOnControl();
                string message = "Please Enter Data on Focus Control !!";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + message + "');", true);
                return;
            }
            else
            {

                StringBuilder sourcefilepath = new StringBuilder();
                sourcefilepath.Append(FileUpload2.FileName.Substring(0, FileUpload2.FileName.Length - 4));
                sourcefilepath.Append("_");
                sourcefilepath.Append(Session["RCV"].ToString());
                sourcefilepath.Append(quesno.Text);
                sourcefilepath.Append(sadhan.Text);
                sourcefilepath.Append(session.Text);
                sourcefilepath.Append(Path.GetExtension(FileUpload2.PostedFile.FileName));

                string ftpurl = "ftp://localhost/";
                string ftpUserName = "FTPUser";
                string ftpPassword = "123456";
                string ftpFolder = "FormatQuestion/";

                try
                {
                    UploadFileToFtp2(ftpurl, sourcefilepath.ToString(), ftpUserName, ftpPassword, ftpFolder);
                    //Insert Data into question_pdf table 
                    DataConnection.insertQuery("update question_pdf set file_path_xls=N'" + sourcefilepath.ToString() + "' where quesno=" + Convert.ToInt32(quesno.Text) + " and assemblys=N'" + sadhan.Text.Trim() + "' and session=N'" + session.Text.Trim() + "'");
                }
                catch (Exception ex)
                {
                    string message = "Error in Uploading" + ex.Message;
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + message + "');", true);
                }
            }
        }
        else
        {
            lblFormat.CssClass = "alert alert-danger";
            lblFormat.Text = "Please Select Filename ";
            return;
        }
    }
}


