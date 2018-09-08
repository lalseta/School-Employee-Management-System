using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;


public partial class ForgotPassword : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    DataSet ds = new DataSet();
    IUDS obj = new IUDS();
    protected void Page_Load(object sender, EventArgs e)
    {
        IfError.Visible = false;
        cn.ConnectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\SEMSDatabase.mdf;Integrated Security=True;User Instance=True";
        cn.Open();
    }
    protected void Btnsubmit_Click(object sender, EventArgs e)
    {

        if (cn.State == ConnectionState.Open)
        {
            cn.Close();


        }
        else
        {
            cn.Open();
        }
        cn.Open();
        //SqlDataAdapter da = new SqlDataAdapter("select UserName,Email,Password from tbl_EmpPrsnlDetail where Username= '" + TxtUsername.Text + "'", cn);
        //da.Fill(ds);


        ds = obj.sel("select UserName,Email,Password from tbl_EmpPrsnlDetail where Username= '" + TxtUsername.Text + "'");
        if (ds.Tables[0].Rows.Count == 0)
        {
            IfError.Text = "Enter Correct Username";
            IfError.Visible = true;
            return;
        }


        else
        {
            IfError.Visible = false;
            try
            {
                IfError.Text = (ds.Tables[0].Rows[0]["Email"]).ToString();
                MailMessage Msg = new MailMessage();
                // Sender e-mail address.
                Msg.From = new MailAddress(IfError.Text);
                // Recipient e-mail address.
                Msg.To.Add(IfError.Text);
                Msg.Subject = "Your Password Details";
                Msg.Body = "Hi, <br/>Please check your Login Details<br/><br/>Your Username: " + ds.Tables[0].Rows[0]["UserName"] + "<br/><br/>Your Password: " + ds.Tables[0].Rows[0]["Password"] + "<br/><br/>";
                Msg.IsBodyHtml = true;
                // your remote SMTP server IP.
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("SemsSystem@gmail.com", "jenithjohn");
                smtp.EnableSsl = true;
                smtp.Send(Msg);
                Msg = null;
                IfError.Text = "Your Password Details Sent to your mail.";
                // Clear the textbox valuess
                TxtUsername.Text = "";
                TxtUsername.Visible = true;
                IfError.Visible = true;

            }
            catch (Exception)
            {
                IfError.Text = "There is a connection problem Please Switch on Internet,...!";
                IfError.Visible = true;
                TxtUsername.Text = "";
            }


        }


    }


}