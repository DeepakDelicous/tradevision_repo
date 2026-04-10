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
    public partial class AddUser : System.Web.UI.Page
    {
        MyClass obj = new MyClass();
        
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
       
        //Warning
       /* SqlDataAdapter dastudent;
        DataSet ds_student, ds_course;
        SqlCommand cmdStudent;*/
       
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

                //nameerrormeg.Visible = false;
                //useriderrormeg.Visible = false;
                string str = "select Id,Name from [CommonMaster] where TypeId='19' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(str);
                DrpDesig.DataSource = obj.dr;
                DrpDesig.DataTextField = "Name";
                DrpDesig.DataValueField = "Id";
                DrpDesig.DataBind();
                obj.closecon();
                DrpDesig.Items.Insert(0, new ListItem("--Select--", "0"));
            }
           
        }
        public void createId()
        {

            string destype = "";
            string perqry3 = "select max(Id) from UserProfile where Designation='" + DrpDesig.SelectedValue + "'";
            obj.dr = obj.ret_dr(perqry3);
            while (obj.dr.Read())
            {
                destype = obj.dr[0].ToString();
            }
            if (destype == "")
            {
                string desi = DrpDesig.SelectedItem.ToString();

                txt_code.Text = desi.Substring(0, 3) + "001";
                string final = txt_code.Text;
            }
            else
            {

                con.Open();
                SqlCommand command1 = new SqlCommand("SELECT max(Id) from UserProfile where Designation='" + DrpDesig.SelectedValue + "'");
                command1.Connection = con;
                string max_po_no = command1.ExecuteScalar().ToString();
                int m_po_no = 0;

                int endTagStartPosition = max_po_no.LastIndexOf("/");
                max_po_no = max_po_no.Substring(endTagStartPosition + 1);
                m_po_no = Convert.ToInt32(max_po_no);
                if (max_po_no != "0")
                {
                    m_po_no = m_po_no + 1;

                }
                string name = DrpDesig.SelectedItem.ToString();
                string code = name.Substring(0, 3) + String.Format("{0:000}", m_po_no);
                con.Close();
                txt_code.Text = code;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string Touch_user = "Admin";

            int Id = 0;
            string perqry1 = "select * from UserProfile where Name='" + txt_name.Text + "'";
            obj.dr = obj.ret_dr(perqry1);
            while (obj.dr.Read())
            {
                Id = Convert.ToInt32(obj.dr[0]);
            }
            int Id2 = 0;
            string perqry2 = "select * from UserProfile where Email='" + TxtEmail.Text + "'";
            obj.dr = obj.ret_dr(perqry2);
            while (obj.dr.Read())
            {
                Id2 = Convert.ToInt32(obj.dr[0]);
            }
            int Id3 = 0;
            string perqry3 = "select * from UserProfile where EmpId='" + txt_code.Text + "'";
            obj.dr = obj.ret_dr(perqry3);
            while (obj.dr.Read())
            {
                Id3 = Convert.ToInt32(obj.dr[0]);
            }
            if(Id != 0)
            {
                //nameerrormeg.Visible = true;
                //useriderrormeg.Visible = false;
                nameerrormeg.InnerText = "Name Already Exist";
            }
            else if(Id2 != 0)
            {
                //nameerrormeg.Visible = false;
                //useriderrormeg.Visible = true;
                useriderrormeg.InnerText = "Email Id Already Exist";
            }
            else if (Id3 != 0)
            {
                //nameerrormeg.Visible = false;
                //useriderrormeg.Visible = true;
                useriderrormeg.InnerText = "Employee Id Already Exist";
            }
            else
            {
                nameerrormeg.InnerText = "";
                useriderrormeg.InnerText = "";


                string encrptpassword = MyClass.Encrypt(TxtPassword.Text);

              

                string strTime = System.DateTime.Now.ToString("yyyy/MM/dd");
                string StrQuery = ("INSERT INTO [dbo].[UserProfile] ([EmpId],[Name],[MobileNo],[Email],[Designation],[UserName],[Password],[ConfirmPassword],[Status],[TouchUser],[TouchTime]) VALUES ('" + txt_code.Text + "','" + txt_name.Text + "','" + TxtMobile.Text + "','" + TxtEmail.Text + "','" + DrpDesig.SelectedValue + "','" + TxtUserName.Text + "','" + encrptpassword + "','" + encrptpassword + "','" + drp_sts.SelectedValue + "','" + Touch_user + "',Convert(VARCHAR,'" + strTime + "',108))");
                obj.exec(StrQuery);
                string dec = "";
                string perqry31 = "select Password from UserProfile where EmpId='" + txt_code.Text + "'";
                obj.dr = obj.ret_dr(perqry31);
                while (obj.dr.Read())
                {
                    dec = obj.dr[0].ToString();
                    string decrpt = MyClass.Decrypt(dec);
                }
                


            }
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {

        }

        protected void DrpDesig_SelectedIndexChanged(object sender, EventArgs e)
        {
            createId();
        }
    }
}