using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RET
{
    public partial class Index : System.Web.UI.Page
    {

     //   string UnzipTechCode = "Unziptech2017";
        MyClass obj = new MyClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            //string LogStstus = "";
            //string perqry31 = "select LoginStatus from ManageUser where UserId='" + Session["UserId"].ToString() + "'";
            //obj.dr = obj.ret_dr(perqry31);
            //while (obj.dr.Read())
            //{
            //    LogStstus = obj.dr["LoginStatus"].ToString();
            //}

            //if (LogStstus == "True")
            //{
            //    Response.Redirect("sessionTimeout.aspx");
            //}

     //     string add  =  // Set the contents of textBox1 to:
     //Environment.ProcessorCount + "/" +       //
     //           // {number of processors}/{machine name}/
     //Environment.MachineName + "/" +
     //           // {user domain}\{username}/
     //Environment.UserDomainName + "\\" +
     //           // {number of logical drives}
     //Environment.UserName + "/" +
     //Environment.GetLogicalDrives().Length; 
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

        }

        //protected void lnkbtn_Click(object sender, EventArgs e)
        //{
        //    if (UnzipTechCode == "Unziptech2017")
        //    {
        //        Response.Redirect("Login.aspx");
        //    }
        //    else
        //    {
        //        Response.Redirect("404.aspx");
        //    }
        //}

        //protected void LinkButton1_Click(object sender, EventArgs e)
        //{

        //    ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( 'Login.aspx', null, 'height=700,width=760,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
            
        //}
    }
}