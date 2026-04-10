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
    public partial class SequencePool : System.Web.UI.Page
    {
        MyClass obj = new MyClass();
        string sqlconn = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
       // bool edit = false;
        private int Id = 0;
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
            Session["Edit"] = true;
            Session["Id"] = Convert.ToInt32(Request.QueryString["Id"]);
            Id = Convert.ToInt32(Request.QueryString["Id"]);
            if (!IsPostBack)
            {

                string Touch_user = Session["UserId"].ToString();
                Session["Edit"] = true;
                Session["Id"] = Convert.ToInt32(Request.QueryString["Id"]);
                Id = Convert.ToInt32(Request.QueryString["Id"]);
                if (Touch_user == "ADMIN")
                {
                    BindSeq();
                }
                else
                {
                    Binduser();
                }
                if (Id != 0)
                {
                    AdminEdit();
                    return;
                }

            }
        }

        public void AdminEdit()
        {
            string AccountId = MyClass.GetSessionDes();
            string strBindTxtBox = "select * from [SequencePool] where Id=" + Id;
            obj.dr = obj.ret_dr(strBindTxtBox);
            while (obj.dr.Read())
            {
                TxtPoolId.Text = obj.dr["PoolID"].ToString();
                TxtDes.Text = obj.dr["Description"].ToString();
                TxtStartSeq.Text = obj.dr["StartSequence"].ToString();
                TxtEndSeq.Text = obj.dr["EndSequence"].ToString();
            }
        }
        private void BindSeq()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM SequencePool"))
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
        private void Binduser()
        {
            string AccountId = MyClass.GetSessionDes();
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM SequencePool where [AccountID]='" + AccountId + "'"))
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
        public void InsertDate()
        {
            string accountid = MyClass.GetSessionDes();
            string Touch_user = Session["UserId"].ToString();
            string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string StrQuery = ("INSERT INTO [dbo].[SequencePool] ([PoolID],[Description],[StartSequence],[EndSequence],[AccountID],[Status],[UserCreated],[DateCreated],[UserLastUpdated],[DateLastUpdated]) VALUES ('" + TxtPoolId.Text + "','" + TxtDes.Text + "','" + TxtStartSeq.Text + "','" + TxtEndSeq.Text + "','" + accountid + "','" + DrpStatus.SelectedItem.ToString() + "','" + Touch_user + "','" + strTime + "','" + Touch_user + "','" + strTime + "')");
            obj.exec(StrQuery);
        }
        public void Editdata()
        {
            string accountid=MyClass.GetSessionDes();
            string Touch_user = Session["UserId"].ToString();
            string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string StrQuery = ("UPDATE [dbo].[SequencePool] SET [PoolID] ='" + TxtPoolId.Text + "'  ,[Description] = '" + TxtDes.Text + "',[StartSequence] ='" + TxtStartSeq.Text + "'  ,[EndSequence] ='" + TxtEndSeq.Text + "' ,[AccountID] = '" + accountid + "',[Status] ='"+DrpStatus.SelectedItem.ToString()+"'  ,[UserLastUpdated] = '" + Touch_user + "',[DateLastUpdated] = '" + strTime + "' WHERE  Id='" + Id + "'");
            obj.exec(StrQuery);
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (Id != 0)
            {
                Editdata();
                Session["Edit"] = false;
                // eid = 0;
                Response.Redirect("SequencePool.aspx");
            }

            else
            {
                string Touch_user = Session["UserId"].ToString();
               
                InsertDate();
                Response.Redirect("SequencePool.aspx");

            }
        }

        protected void imgDelete_Click(object sender, EventArgs e)
        {
            string Touch_user = Session["UserId"].ToString();

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
                SqlCommand cmd = new SqlCommand("DELETE FROM AdminCreate where ID=" + employeeId, con);
                result = cmd.ExecuteNonQuery();
                con.Close();
                if (Touch_user == "ADMIN")
                {
                    BindSeq();
                }
                else
                {
                    Binduser();
                }
            }
            if (result == 1)
            {
                if (Touch_user == "ADMIN")
                {
                    BindSeq();
                }
                else
                {
                    Binduser();
                }

            }
        }

        protected void InpaymentEdit_Click(object sender, ImageClickEventArgs e)
        {
            GridViewRow grdrow = (GridViewRow)((ImageButton)sender).NamingContainer as GridViewRow;

            Label ID1 = (Label)grdrow.FindControl("Id");
            string ID = ID1.Text;
            Response.Redirect("SequencePool.aspx?ID=" + ID);
        }
    }
}