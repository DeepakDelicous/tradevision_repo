using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RET
{
    public partial class GetMac : System.Web.UI.Page
    {
        MyClass obj = new MyClass();
        protected void Page_Load(object sender, EventArgs e)
        {
           
           

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