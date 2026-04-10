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
    public partial class CommonMaster : System.Web.UI.Page
    {
        MyClass obj = new MyClass();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
       
        //warning
      /*  SqlDataAdapter dastudent;
        DataSet ds_student, ds_course;
        SqlCommand cmdStudent;*/

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["Name"] == null || Session["Name"] == "")
            //{
            //    Response.Redirect("Login.aspx");
            //}
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

           
            if (!this.IsPostBack)
            {
                con.Open();
                SqlCommand command1 = new SqlCommand("SELECT max(Id) from CommonMaster");
                command1.Connection = con;
                string max_po_no = command1.ExecuteScalar().ToString();
                if (max_po_no=="")
                {
                    max_po_no = "1";
                }
                int m_po_no = 0;

                int endTagStartPosition = max_po_no.LastIndexOf("/");
                max_po_no = max_po_no.Substring(endTagStartPosition + 1);
                m_po_no = Convert.ToInt32(max_po_no);
                if (max_po_no != "0")
                {
                    m_po_no = m_po_no + 1;

                }
                string code = " " + String.Format("{0:000}", m_po_no);
                con.Close();
                txt_code.Text = code;
            }
            string str = "select Id,Type from CommonMasterType order by Type";
            obj.dr = obj.ret_dr(str);
            drp_type.DataSource = obj.dr;
            drp_type.DataTextField = "Type";
            drp_type.DataValueField = "Id";
            drp_type.DataBind();
            obj.closecon();

            drp_type.Items.Insert(0, new ListItem("-- Select --", "0"));

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string Touch_user = "Admin";

            string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string StrQuery = ("INSERT INTO [dbo].[CommonMaster] ([Name],[Description],[TypeId],[TypeName],[StatusId],[StatusName],[TouchUser],[TouchTime]) VALUES ('" + txt_name.Text + "','" + txt_des.Text + "','" + drp_type.SelectedValue.ToString() + "','" + drp_type.SelectedItem.ToString() + "','" + drp_sts.SelectedValue + "','" + drp_sts.SelectedItem + "' ,'" + Touch_user + "',Convert(VARCHAR,'" + strTime + "',108))");
            obj.exec(StrQuery);
            Response.Redirect("CommonMaster.aspx");
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {

        }

    }
}