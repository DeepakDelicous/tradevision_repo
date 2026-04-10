using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RET
{
    public partial class Home : System.Web.UI.MasterPage
    {
        //string decrpt = "";
        MyClass obj = new MyClass();
        string sqlconn = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            // 1. Get the current UTC time
            DateTime utcNow = DateTime.UtcNow;

            // 2. Find the Singapore Time Zone
            TimeZoneInfo sgTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Singapore Standard Time");

            // 3. Convert UTC to Singapore Time
            DateTime sgTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, sgTimeZone);

            // 4. Display it in a Label (Format: 11-Mar-2026 02:45 PM)
            lblSingaporeTime.Text = sgTime.ToString("dd-MMM-yyyy hh:mm tt");

            AddConditionalCss();

            if (Session["Userid"] == null)
            {
                Response.Redirect("sessionTimeout.aspx");
            }

            string MailboxId = "";
            string aa = "select Top 1 Mailboxid from ManageUser where UserId='" + Session["UserId"].ToString() + "'";
            obj.dr = obj.ret_dr(aa);
            if (obj.dr.Read())
            {
                MailboxId = obj.dr["Mailboxid"].ToString();
            }

            string qry111 = "SELECT Top 1 TradeNetMailboxID,DeclarantName,DeclarantCode,DeclarantTel,CRUEI  from DeclarantCompany a,ManageUser b  where a.AccountID=b.AccountId and a.TradeNetMailboxID=b.Mailboxid and b.UserId='" + Session["UserId"].ToString() + "' and b.MailBoxid='" + MailboxId + "'  group by TradeNetMailboxID,DeclarantName,DeclarantCode,DeclarantTel,CRUEI";
            obj.dr = obj.ret_dr(qry111);
            if (obj.dr.Read())
            {
               
                user.Text = obj.dr["DeclarantName"].ToString().ToUpper();
              
            }

           // user.Text = Session["UserId"].ToString();
            
        }
        
        private void AddConditionalCss()
        {
            string currentPage = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            string conditionalClasses = "2xl:pl-20 2xl:pr-10 px-6 py-6 w-full mx-auto";
            string defaultClasses = "px-6 py-6 xl:max-w-[1150px] fixw w-full mx-auto";

            // Pages that need the conditional classes
            string[] conditionalPages = new string[]
            {
                "InpaymentList.aspx",
                "InNonPaymentList.aspx",
                "OutList.aspx",
                "TranshipmentList.aspx",
                "CoList.aspx"
            };

            // Check if the current page is one of the conditional pages
            if (conditionalPages.Contains(currentPage, StringComparer.OrdinalIgnoreCase))
            {
                mainDiv.Attributes["class"] = conditionalClasses;
            }
            else
            {
                mainDiv.Attributes["class"] = defaultClasses;
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            string user = Session["UserId"].ToString();
            string StrQuery = ("UPDATE [dbo].[ManageUser] SET LoginStatus='False'  WHERE UserId='" + user + "'");
            obj.exec(StrQuery);
            Session.Remove("UserId");
           // Response.Redirect("index.aspx");

            string close = @"<script type='text/javascript'>
                                window.returnValue = true;
                                window.close();
                                </script>";
            base.Response.Write(close);


        }
    }
}