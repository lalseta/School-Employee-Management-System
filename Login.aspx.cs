using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Login : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\SEMSDatabase.mdf;Integrated Security=True;User Instance=True");

    IUDS obj = new IUDS();
    DataSet ds = new DataSet();
    int i;

    string str, str1;


    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["new"] = "Try";
        //Response.Redirect("fileupload.aspx");
        if (!IsPostBack)
        {
            if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
            {
                Txtusername.Text = Request.Cookies["UserName"].Value;
                Txtpassword.Attributes["value"] = Request.Cookies["Password"].Value;
            }
        }


    }
    protected void Btnreset_Click(object sender, EventArgs e)
    {
        Txtpassword.Text = "";
        Txtusername.Text = "";
    }
    protected void Btnlogin_Click(object sender, EventArgs e)
    {
         if (chkRememberMe.Checked)
        {
            Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
        }
        else
        {
            Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);

        }
        Response.Cookies["UserName"].Value = Txtusername.Text.Trim();
        Response.Cookies["Password"].Value = Txtpassword.Text.Trim();

    

        try
        {


            ds = obj.sel("select * from tbl_EmpPrsnlDetail where UserName='" + Txtusername.Text.Replace("'", " ") + "' AND Password='" + Txtpassword.Text.Replace("'", " ") + "' AND DesignationId='" + Ddldesignation.SelectedValue + "'");

            if (ds.Tables[0].Rows.Count == 0)
            {
              ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Error", "alert('Enter Corect Username or Password');", true);
            }
            else
            {


                // ds = obj.sel("select * from tbl_EmpPrsnlDetail where UserName='" + Txtusername.Text + "' AND Password='" + Txtpassword.Text + "' AND DesignationId='" + Ddldesignation.SelectedValue + "'");


                cn.Open();
                SqlDataReader data;
                SqlCommand cmd = new SqlCommand("select UserName,Password,Activate_Deactivate from tbl_EmpPrsnlDetail where UserName='" + Txtusername.Text + "'", cn);
                data = cmd.ExecuteReader();



                while (data.Read())
                {
                    str = data["Password"].ToString();
                    str1 = data["Activate_Deactivate"].ToString();

                    if (Txtpassword.Text != str || str1 == "0")
                    {
                        // MessageBox.Show("Invalid Login");
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Error", "alert('Your Account has not been activated or Invalid Login');", true);

                    }
                    else if (Txtpassword.Text == str && str1 == "1")
                    {
                        if (Ddldesignation.SelectedIndex == 0)
                        {
                            Session["new"] = Txtusername.Text;
                            Response.Write(Session["new"].ToString());
                            Response.Redirect("~/AdminPrincipalPanel/HomePage.aspx");
                        }

                        else if (Ddldesignation.SelectedIndex == 1)
                        {
                            Session["new"] = Txtusername.Text;
                            Response.Write(Session["new"].ToString());
                            Response.Redirect("~/StaffPanel/HomePage.aspx");
                        }
                        else if (Ddldesignation.SelectedIndex == 2)
                        {
                            Session["new"] = Txtusername.Text;
                            Response.Write(Session["new"].ToString());
                            Response.Redirect("~/StaffPanel/HomePage.aspx");

                        }
                        else if (Ddldesignation.SelectedIndex == 3)
                        {
                            Session["new"] = Txtusername.Text;
                            Response.Write(Session["new"].ToString());
                            Response.Redirect("~/ClerkPanel/HomePage.aspx");


                        }
                        else if (Ddldesignation.SelectedIndex == 4)
                        {

                            Session["new"] = Txtusername.Text;
                            Response.Write(Session["new"].ToString());
                            Response.Redirect("~/AccountantPanel/HomePage.aspx");
                        }
                        else if (Ddldesignation.SelectedIndex == 5)
                        {

                            Session["new"] = Txtusername.Text;
                            Response.Write(Session["new"].ToString());
                            Response.Redirect("~/AdminPrincipalPanel/HomePage.aspx");
                        }
                        else
                        {
                            Session["new"] = Txtusername.Text;
                            Response.Write(Session["new"].ToString());
                            Response.Redirect("~/StaffPanel/HomePage.aspx");
                        }
                    }
                    else
                    {

                        //MessageBox.Show("Invalid Login");
                    }

                    i++;

                }

                if (i == 0)

                    //MessageBox.Show("Invalid login");
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Error", "alert('Your Account has not been activated or Invalid Login');", true);
            
               // lblMesg.Visible = true;
                cn.Close();
            }
        }

        catch (Exception ex)
        {
            //lblMesg.Text = ex.Message;
            //lblMesg.Visible = true;

        }

    }





}



//protected void btnlogin_Click(object sender, EventArgs e)
//  {
//      SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

//      SqlCommand cmd = new SqlCommand("select stupassword,status from studentinfo where stuusername='" + Txtusrname.Text + "'", conn);

//      SqlDataReader dr;

//      conn.Open();
//      dr = cmd.ExecuteReader();
//      string str,str1;
//      int i = 0;

//      while (dr.Read())
//      {

//          str = dr["stupassword"].ToString();
//          str1 = dr["status"].ToString();
//          if (Txtpass.Text != str || str1 == "InActive")
//          {
//              // MessageBox.Show("Invalid Login");
//              lblmsg.Text = "Your Account has not been activated or Invalid Login";

//          }
//          else if (Txtpass.Text == str && str1 == "Active")
//          {
//              //MessageBox.Show("Valid login"); 
//              Session["reg_no"] = Txtusrname.Text;
//              Response.Redirect("~/Default.aspx");

//          }
//          else
//          {
//              lblmsg.Text = "Invalid Login";
//          }

//          i++;

//      }

//      if (i == 0)

//          // MessageBox.Show("Invalid login");
//          lblmsg.Text = "Invalid Login";
//      conn.Close();
//  }
