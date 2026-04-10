using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace RET
{
    public partial class Login : System.Web.UI.Page
    {                
        string decrpt = "";
        MyClass obj = new MyClass();
        string sqlconn = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


            }
            lbl_err.Text = "";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            lbl_err.Text = "";
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }


            string MAc = "";
            string Masq = "select MACAddress from SystemInfo";
            obj.dr = obj.ret_dr(Masq);
            while (obj.dr.Read())
            {
                MAc = obj.dr["MacAddress"].ToString();
                //if (MAc == sMacAddress)
                //{
                    decrpt = Password.Text;
                    SqlConnection con = new SqlConnection(sqlconn);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from ManageUser where UserId=@UserId  and Password=@password and Status='Active'", con);

                    cmd.Parameters.AddWithValue("@UserId", Username.Text);
                    cmd.Parameters.AddWithValue("@password", decrpt);
                    // cmd.Parameters.AddWithValue("@Name", txtName.Text);

                    // Session["UserName"] = username.Text;
                    // Session["Name"] = username.Text;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        //string dtmailname = dt.Columns["EmailId"].ToString();
                        //string tblpassword = dt.Columns["Password"].ToString();
                        //if (dtmailname == username.Text.ToString().Trim() && tblpassword == password.Text.ToString().Trim())
                        //{
                        foreach (DataRow row in dt.Rows)
                        {



                            Session["AccountId"] = row["AccountId"].ToString();
                            Session["UserId"] = row["UserId"].ToString();
                            Session["Mac"] = row["Activeuser"].ToString();

                            MyClass.SetSession(Session["UserId"].ToString());
                            MyClass.SetSessionDes(Session["AccountId"].ToString());
                            MyClass.SetSessionMac(Session["Mac"].ToString());
                            //NAME = Session["Name"].ToString();
                        }
                        con.Close();

                        string LogStstus = "";
                        string perqry31 = "select LoginStatus from ManageUser where UserId='" + Session["UserId"].ToString() + "'";
                        obj.dr = obj.ret_dr(perqry31);
                        while (obj.dr.Read())
                        {
                            LogStstus = obj.dr["LoginStatus"].ToString();
                        }

                        if (LogStstus == "True")
                        {
                            if (ChkLogin.Checked == true)
                            {
                                lbl_err.Text = "";
                                Session.Remove("Mac");
                                string user = Username.Text;
                                string StrQuery = ("UPDATE [dbo].[ManageUser] SET LoginStatus='True' , ActiveUser='" + MAc + "'  WHERE UserId='" + user + "'");
                                obj.exec(StrQuery);
                                Session["Mac"] = MAc;

                                MyClass.SetSession(Session["Mac"].ToString());


                                Response.Redirect("Home.aspx");

                            }
                            else
                            {

                                if (Session["Userid"] == null)
                                {
                                    lbl_err.Text = "";
                                    lbl_err.Text = "User Already Login with another System...!!!";
                                }
                                else
                                {
                                    lbl_err.Text = "";
                                    Session.Remove("Mac");
                                    string user = Username.Text;
                                    string StrQuery = ("UPDATE [dbo].[ManageUser] SET LoginStatus='True' , ActiveUser='" + MAc + "'  WHERE UserId='" + user + "'");
                                    obj.exec(StrQuery);
                                    Session["Mac"] = MAc;

                                    MyClass.SetSession(Session["Mac"].ToString());


                                    Response.Redirect("Home.aspx");
                                }
                            }

                        }
                        else
                        {

                            string StrQuery = ("UPDATE [dbo].[ManageUser] SET LoginStatus='True'  , ActiveUser='" + MAc + "'   WHERE UserId='" + Session["UserId"].ToString() + "'");
                            obj.exec(StrQuery);
                            Response.Redirect("Home.aspx");


                        }
                        //}
                        //else
                        //{
                        //    lbl_err.Text = "Enter correct Username and Password";
                        //}
                    }
                    else
                    {
                        lbl_err.Text = "";
                        lbl_err.Text = "Enter correct Username and Password";
                        return;
                    }


                //}
                //else
                //{
                    //lbl_err.Text = "";
                    //lbl_err.Text = "Your System Has Not Support To Access this Portal ... !!!";
               // }
            }








        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string locn = ConfigurationManager.AppSettings["~"];

         //  System.Diagnostics.Process.Start( "~/timerapplication.exe");
        }
    }
}