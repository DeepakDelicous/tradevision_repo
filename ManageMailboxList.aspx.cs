using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RET
{
    public partial class ManageMailboxList : System.Web.UI.Page
    {
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
            if (!IsPostBack)
            {
                if (Session["Userid"] == null)
                {
                    Response.Redirect("sessionTimeout.aspx");
                }
                 string Touch_user = Session["UserId"].ToString();
                 if (Touch_user == "ADMIN")
                 {
                     BindAdmin();
                     NewInvoice.Visible = true;
                 }
                 else
                 {
                     BindUser();
                     NewInvoice.Visible = false;
                 }

            }
        }

        private void BindUser()
        {
            string AccountId = MyClass.GetSessionDes();
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM DeclarantCompany where AccountId='" + AccountId + "' "))
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
        private void BindAdmin()
        {
            
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM DeclarantCompany "))
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


        protected void NewInvoice_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageMailbox.aspx");
        }

        protected void imgDelete_Click(object sender, EventArgs e)
        {

            LinkButton lnkbtn = sender as LinkButton;
            //getting particular row linkbutton
            GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
            //getting userid of particular row
            int employeeId = Convert.ToInt32(GridView1.DataKeys[gvrow.RowIndex].Value.ToString());
            int result;
            //getting Connectin String from Web.Config
            string conString = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM DeclarantCompany where ID=" + employeeId, con);
                result = cmd.ExecuteNonQuery();
                con.Close();
                BindAdmin();
            }
            if (result == 1)
            {
                BindAdmin();

            }
        }

        protected void InpaymentEdit_Click(object sender, ImageClickEventArgs e)
        {
            GridViewRow grdrow = (GridViewRow)((ImageButton)sender).NamingContainer as GridViewRow;

            Label ID1 = (Label)grdrow.FindControl("Id");
            string ID = ID1.Text;
            Response.Redirect("ManageMailbox.aspx?ID=" + ID);
        }
    }
}