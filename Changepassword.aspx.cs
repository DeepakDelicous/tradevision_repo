using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace RET
{
    public partial class Changepassword : System.Web.UI.Page
    {
        MyClass obj = new MyClass();
        string sqlconn = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Userid"] == null)
            {
                Response.Redirect("sessionTimeout.aspx");
            }
            string LogStstus = "", Activeuser = "";
            string perqry31 = "select LoginStatus,Activeuser from ManageUser where UserId='" + Session["UserId"].ToString() + "'";
            obj.dr = obj.ret_dr(perqry31);
            while (obj.dr.Read())
            {
                LogStstus = obj.dr["LoginStatus"].ToString();
                Activeuser = obj.dr["Activeuser"].ToString();
                string ClientMac = Session["Mac"].ToString();
                if (LogStstus == "True" && Activeuser == Session["Mac"].ToString())
                {

                }
                else
                {
                    Response.Redirect("sessionTimeout.aspx");
                }

            }

            if (!IsPostBack)
            {
                string strBindTxtBox = "select TradeNetMailboxID, CurrentPassword,TradenetAccount from DeclarantCompany Inner join  ManageUser ON DeclarantCompany.TradeNetMailboxID = ManageUser.MailBoxId Where ManageUser.Userid='" + Session["UserId"].ToString() + "'";
                obj.dr = obj.ret_dr(strBindTxtBox);
                while (obj.dr.Read())
                {
                    TxtMailBoxID.Text = obj.dr["TradeNetMailboxID"].ToString();
                    txtcurrentpassword.Text = obj.dr["CurrentPassword"].ToString();
                    TxtDecCompCode.Text = obj.dr["TradenetAccount"].ToString();
                }
            }

        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (txtnewpassword.Text != null)
            {
                DateTime exp = DateTime.Today.AddDays(85);
                string expdate = exp.ToString("yyyy/MM/dd");
                string strBindTxtBox = "Update DeclarantCompany set CurrentPassword='" + txtnewpassword.Text + "', ValididityDate='" + expdate + "' where TradeNetMailboxID='" + TxtMailBoxID.Text + "'";
                obj.dr = obj.ret_dr(strBindTxtBox);
                lblmsg.Text = "Successfully Updated";
            }
            else
            {
                lblnewpwd.Text = "Please Enter Newpassword";
            }
        }
    }
}