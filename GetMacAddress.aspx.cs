using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RET
{
    public partial class GetMacAddress : System.Web.UI.Page
    {
        MyClass obj = new MyClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["Userid"] == null)
            //{
            //    Response.Redirect("sessionTimeout.aspx");
            //}
            //string LogStstus = "", Activeuser = "";
            //string perqry31 = "select LoginStatus,Activeuser from ManageUser where UserId='" + Session["UserId"].ToString() + "'";
            //obj.dr = obj.ret_dr(perqry31);
            //while (obj.dr.Read())
            //{
            //    LogStstus = obj.dr["LoginStatus"].ToString();
            //    Activeuser = obj.dr["Activeuser"].ToString();
            //    string ClientMac = Session["Mac"].ToString();
            //    if (LogStstus == "True" && Activeuser == Session["Mac"].ToString())
            //    {

            //    }
            //    else
            //    {
            //        Response.Redirect("sessionTimeout.aspx");
            //    }

            //}

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
            txtmac.Text = sMacAddress;
            txtsysname.Text = Environment.MachineName;
        }

        protected void btn_Click(object sender, EventArgs e)
        {

            string StrQuery = ("insert into SystemInfo (SystemName,MACAddress) values ('" + txtsysname.Text + "','" + txtmac.Text + "') ");
            obj.exec(StrQuery);
        }
    }
}