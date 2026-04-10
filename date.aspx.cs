using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RET
{
    public partial class date : System.Web.UI.Page
    {
        MyClass obj = new MyClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            string LogStstus = "";
            string perqry31 = "select LoginStatus from ManageUser where UserId='" + Session["UserId"].ToString() + "'";
            obj.dr = obj.ret_dr(perqry31);
            while (obj.dr.Read())
            {
                LogStstus = obj.dr["LoginStatus"].ToString();
            }

            if (LogStstus == "True")
            {
                Response.Redirect("sessionTimeout.aspx");
            }
            TxtArrivalDate1.Value = DateTime.Today.ToString();
            //this.TxtArrivalDate1.Value = DateTime.Now;
          
           
        }
    }
}