using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RET
{
    public partial class Home1 : System.Web.UI.Page
    {
        //protected override object LoadPageStateFromPersistenceMedium()
        //{
        //    string viewState = Request.Form["__VSTATE"];
        //    byte[] bytes = Convert.FromBase64String(viewState);
        //    bytes = CompressedViewStatePage.Decompress(bytes);
        //    LosFormatter formatter = new LosFormatter();
        //    return formatter.Deserialize(Convert.ToBase64String(bytes));
        //}

        //protected override void SavePageStateToPersistenceMedium(object viewState)
        //{
        //    LosFormatter formatter = new LosFormatter();
        //    StringWriter writer = new StringWriter();
        //    formatter.Serialize(writer, viewState);
        //    string viewStateString = writer.ToString();
        //    byte[] bytes = Convert.FromBase64String(viewStateString);
        //    bytes = CompressedViewStatePage.Compress(bytes);
        //    ClientScript.RegisterHiddenField("__VSTATE", Convert.ToBase64String(bytes));
        //}
        //string decrpt = "";           
            MyClass obj = new MyClass();
        string sqlconn = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            string curdate = System.DateTime.Now.ToString("yyyy/MM/dd");
            DateTime cd = DateTime.Today;
            string strBindTxtBox = "select * from DeclarantCompany Inner join  ManageUser ON DeclarantCompany.TradeNetMailboxID = ManageUser.MailBoxId Where ManageUser.Userid='" + Session["UserId"].ToString() + "' ";

            //string strBindTxtBox = "select * from DeclarantCompany Inner join  ManageUser ON DeclarantCompany.TradeNetMailboxID = ManageUser.MailBoxId Where ManageUser.Userid='" + Session["UserId"].ToString() + "' and ValididityDate <='" + curdate + "'";
           // string strBindTxtBox = "select * from DeclarantCompany Where ValididityDate >='" + curdate + "'";
            obj.dr = obj.ret_dr(strBindTxtBox);
            if (obj.dr.Read())
            {
                PopupValidity.Show();
            }
            else
            {
               PopupValidity.Hide();
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
            }


           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Changepassword.aspx");
        }

                
    }
}