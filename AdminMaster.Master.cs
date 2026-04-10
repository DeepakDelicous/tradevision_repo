using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RET
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
       // string decrpt = "";
        MyClass obj = new MyClass();
        string sqlconn = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Userid"] == null)
            {
                Response.Redirect("sessionTimeout.aspx");
            }

           
            user.Text = Session["UserId"].ToString();
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            string user = Session["UserId"].ToString();
            string StrQuery = ("UPDATE [dbo].[ManageUser] SET LoginStatus='False'  WHERE UserId='" + user + "'");
            obj.exec(StrQuery);

            Session.Remove("UserId");
            Response.Redirect("Login.aspx");
        }

        protected void LnkAdmincreate_Click(object sender, EventArgs e)
        {
            string Touch_user = Session["UserId"].ToString();
             if (Touch_user == "ADMIN")
             {
                 Response.Redirect("AdminCreateList.ASPX");

             }
             else
             {
                 Response.Redirect("AdminCreate.ASPX");
             }
        }
    }
}