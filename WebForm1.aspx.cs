using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RET
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public static string name;
        MyClass obj = new MyClass();
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
            name = Request.QueryString["Id"].ToString();
            if (name == "DEC")
            {
                string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT Id,Code,Name,Name1,CRUEI FROM DeclarantCompany"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                            }
                        }
                    }
                }
            }
            else
            {
                GridView1.Visible = false;
            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Attach click event to each row in Gridview
                //Response.Redirect("Home.aspx");
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowIndex == GridView1.SelectedIndex)
                {
                    row.ToolTip = string.Empty;
                    String pid, name, desc;
                    pid = row.Cells[0].Text;
                    name = row.Cells[1].Text;
                    desc = row.Cells[2].Text;
                    Session["Declarent"] = name;

                    string DecSess = Session["Declarent"].ToString();
                    string jScript = "<script>window.close();</script>";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "keyClientBlock", jScript);

                    Response.Redirect("Inpayment.aspx");
      ////  Response.Redirect("~/Inpayment.aspx?Id=" + row.Cells[0].Text);
      //              string pageurl = "Inpayment.aspx?Code=" + name + "&action=view";

      //             // string script = "<script language='javascript'>viewblogs('" + pageurl + "');</script>";
      //  //string jScript = "<script>window.close();</script>";
      //  //ClientScript.RegisterClientScriptBlock(this.GetType(), "keyClientBlock", jScript);
      //  //Response.Redirect("~/Inpayment.aspx?Code=" + row.Cells[1].Text);
      //  ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( 'Inpayment.aspx?Code=" + name + "', null, 'height=700,width=760,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'');", true);

                }
            }
        }
    }
}