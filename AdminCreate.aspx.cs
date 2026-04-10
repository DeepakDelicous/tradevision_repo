using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RET
{
    public partial class AdminCreate : System.Web.UI.Page
    {
       // string decrpt = "";
        MyClass obj = new MyClass();
        string sqlconn = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
        bool edit = false;
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
            

            string Touch_user = Session["UserId"].ToString();
            if (Touch_user == "ADMIN")
            {

                TxtAccID.Enabled = true;
                TxtUEN.Enabled = true;
                TxtGSTReg.Enabled = true;
                TxtName.Enabled = true;
                BtnCancel.Visible = true;
            }
            else
            {

                TxtAccID.Enabled = false;
                TxtUEN.Enabled = false;
                TxtGSTReg.Enabled = false;
                TxtName.Enabled = false;
                DrpStatus.Enabled = false;
                BtnCancel.Visible = false;
               
            }


            if (!IsPostBack)
            {


                Session["Edit"] = true;
                Session["Id"] = Convert.ToInt32(Request.QueryString["Id"]);
                Id = Convert.ToInt32(Request.QueryString["Id"]);
                if(Touch_user!="ADMIN")
                {
                    LoadData();
                }
                if (Id != 0)
                {
                    AdminEdit();
                    return;
                }

            }
        }

        public void LoadData()
        {
            string AccountId = MyClass.GetSessionDes();
            string strBindTxtBox = "select * from [AdminCreate] where AccountID='" + AccountId + "'";
            obj.dr = obj.ret_dr(strBindTxtBox);
            while (obj.dr.Read())
            {
                TxtAccID.Text = obj.dr["AccountID"].ToString();
                TxtName.Text = obj.dr["Name"].ToString();
                TxtUEN.Text = obj.dr["UEN"].ToString();
                TxtGSTReg.Text = obj.dr["GSTRegistration"].ToString();
                TxtConName.Text = obj.dr["ContactName"].ToString();
                TxtConTel.Text = obj.dr["ContactTel"].ToString();
                TxtConFax.Text = obj.dr["ContactFax"].ToString();
                TxtConMob.Text = obj.dr["ContactMobile"].ToString();
                TxtConEmail.Text = obj.dr["ContactEmail"].ToString();
                TxtAddress.Text = obj.dr["Address"].ToString();
                TxtPostal.Text = obj.dr["PostalCode"].ToString();
                TxtCountry.Text = obj.dr["CountryCode"].ToString();
                //txt_code.Text = obj.dr["PermitId"].ToString();
                //TxtTradeMailID.Text = obj.dr["TradeNetMailboxID"].ToString();
                //TxtMsgType.Text = obj.dr["MessageType"].ToString();
                ////DrpDecType.Text = obj.dr[6].ToString();
                DrpStatus.ClearSelection();
                DrpStatus.Items.FindByText(obj.dr["Status"].ToString()).Selected = true;
            }
        }

        public void AdminEdit()
        {
            string AccountId = MyClass.GetSessionDes();
            string strBindTxtBox = "select * from [AdminCreate] where Id=" + Id;
            obj.dr = obj.ret_dr(strBindTxtBox);
            while (obj.dr.Read())
            {
                TxtAccID.Text = obj.dr["AccountID"].ToString();
                TxtName.Text = obj.dr["Name"].ToString();
                TxtUEN.Text = obj.dr["UEN"].ToString();
                TxtGSTReg.Text = obj.dr["GSTRegistration"].ToString();
                TxtConName.Text = obj.dr["ContactName"].ToString();
                TxtConTel.Text = obj.dr["ContactTel"].ToString();
                TxtConFax.Text = obj.dr["ContactFax"].ToString();
                TxtConMob.Text = obj.dr["ContactMobile"].ToString();
                TxtConEmail.Text = obj.dr["ContactEmail"].ToString();
                TxtAddress.Text = obj.dr["Address"].ToString();
                TxtPostal.Text = obj.dr["PostalCode"].ToString();
                TxtCountry.Text = obj.dr["CountryCode"].ToString();
                //txt_code.Text = obj.dr["PermitId"].ToString();
                //TxtTradeMailID.Text = obj.dr["TradeNetMailboxID"].ToString();
                //TxtMsgType.Text = obj.dr["MessageType"].ToString();
                ////DrpDecType.Text = obj.dr[6].ToString();
                DrpStatus.ClearSelection();
                DrpStatus.Items.FindByText(obj.dr["Status"].ToString()).Selected = true;
            }
        }
        public void InsertDate()
        {
            string Touch_user = Session["UserId"].ToString();           
            string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string StrQuery = ("INSERT INTO [dbo].[AdminCreate] ([AccountID],[Name],[UEN],[GSTRegistration],[ContactName],[ContactTel],[ContactFax],[ContactMobile],[ContactEmail],[Address],[PostalCode],[CountryCode],[Status],[UserCreated],[DateCreated],[UserLastUpdated],[DateLastUpdated]) VALUES ('" + TxtAccID.Text + "','" + TxtName.Text + "','" + TxtUEN.Text + "','" + TxtGSTReg.Text + "','" + TxtConName.Text + "','" + TxtConTel.Text + "','" + TxtConFax.Text + "','" + TxtConMob.Text + "','" + TxtConEmail.Text + "','" + TxtAddress.Text + "','" + TxtPostal.Text + "','" + TxtCountry.Text + "','" + DrpStatus.SelectedItem.ToString() + "','" + Touch_user + "','" + strTime + "','" + Touch_user + "','" + strTime + "')");
            obj.exec(StrQuery);
        }
        public void Editdata()
        {
            string Touch_user = Session["UserId"].ToString();
            string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string StrQuery = ("UPDATE [dbo].[AdminCreate] SET [AccountID] ='"+TxtAccID.Text+"' ,[Name] ='"+TxtName.Text+"' ,[UEN] = '"+TxtUEN.Text+"' ,[GSTRegistration] ='"+TxtGSTReg.Text+"' ,[ContactName] ='"+TxtConName.Text+"' ,[ContactTel] ='"+TxtConTel.Text+"' ,[ContactFax] ='"+TxtConFax.Text+"' ,[ContactMobile] ='"+TxtConMob.Text+"' ,[ContactEmail] = '"+TxtConEmail.Text+"' ,[Address] = '"+TxtAddress.Text+"'  ,[PostalCode] ='"+TxtPostal.Text+"'  ,[CountryCode] = '"+TxtCountry.Text+"' ,[Status] ='"+DrpStatus.SelectedItem.ToString()+"' ,[UserLastUpdated] = '"+Touch_user+"',[DateLastUpdated] = '"+strTime+"' WHERE  Id='"+Id+"'");
            obj.exec(StrQuery);
        }

        public void EdituSER()
        {
            string AccountId = MyClass.GetSessionDes();
            string Touch_user = Session["UserId"].ToString();
            string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string StrQuery = ("UPDATE [dbo].[AdminCreate] SET [AccountID] ='" + TxtAccID.Text + "' ,[Name] ='" + TxtName.Text + "' ,[UEN] = '" + TxtUEN.Text + "' ,[GSTRegistration] ='" + TxtGSTReg.Text + "' ,[ContactName] ='" + TxtConName.Text + "' ,[ContactTel] ='" + TxtConTel.Text + "' ,[ContactFax] ='" + TxtConFax.Text + "' ,[ContactMobile] ='" + TxtConMob.Text + "' ,[ContactEmail] = '" + TxtConEmail.Text + "' ,[Address] = '" + TxtAddress.Text + "'  ,[PostalCode] ='" + TxtPostal.Text + "'  ,[CountryCode] = '" + TxtCountry.Text + "' ,[Status] ='" + DrpStatus.SelectedItem.ToString() + "' ,[UserLastUpdated] = '" + Touch_user + "',[DateLastUpdated] = '" + strTime + "' WHERE  AccountID='" + AccountId + "'");
            obj.exec(StrQuery);
        }
        
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            Id = Convert.ToInt16(Session["Id"].ToString());
            if (Id != 0)
            {
                Editdata();
                Session["Edit"] = false;
                // eid = 0;
                Response.Redirect("AdminCreateList.aspx");
            }

            else
            {
                string Touch_user = Session["UserId"].ToString();
                if (Touch_user != "ADMIN")
                {
                    EdituSER();
                    return;
                }

                InsertDate();
                Response.Redirect("AdminCreateList.aspx");

            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminCreateList.aspx");
        }
    }
}