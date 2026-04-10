using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RET
{
    public partial class ManageMailbox : System.Web.UI.Page
    {
      //  string decrpt = "";
        MyClass obj = new MyClass();
        string sqlconn = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
      //  bool edit = false;
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
           
            if (!IsPostBack)
            {
                Session["Edit"] = true;
                Session["Id"] = Convert.ToInt32(Request.QueryString["Id"]);
                Id = Convert.ToInt32(Request.QueryString["Id"]);
                //Vehicle  Type
                string strv = "select * from [AdminCreate] order by AccountID";
                obj.dr = obj.ret_dr(strv);
                DrpAccountId.DataSource = null;
                DrpAccountId.DataSource = obj.dr;
                DrpAccountId.DataTextField = "AccountID";
                DrpAccountId.DataValueField = "Id";
                DrpAccountId.DataBind();
                obj.closecon();
                DrpAccountId.Items.Insert(0, new ListItem("--Select--", "0"));
                  string Touch_user = Session["UserId"].ToString();
                  if (Touch_user == "ADMIN")
                  {
                      DrpStatus.Enabled = true;
                  }
                  else
                  {
                      string strvs = "select * from [AdminCreate] order by AccountID";
                      obj.dr = obj.ret_dr(strvs);
                      DrpAccountId.DataSource = null;
                      DrpAccountId.DataSource = obj.dr;
                      DrpAccountId.DataTextField = "AccountID";
                      DrpAccountId.DataValueField = "Id";
                      DrpAccountId.DataBind();
                      obj.closecon();
                      DrpAccountId.Items.Insert(0, new ListItem("--Select--", "0"));
                      string account = MyClass.GetSessionDes();
                      DrpAccountId.ClearSelection();
                      DrpAccountId.Items.FindByText(account).Selected = true;
                      DrpAccountId.Enabled = false;
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
            string strBindTxtBox = "select * from DeclarantCompany where  Id=" + Id;
            obj.dr = obj.ret_dr(strBindTxtBox);
            while (obj.dr.Read())
            {

                TxtMailBoxID.Text = obj.dr["TradeNetMailboxID"].ToString();
                TxtCurrentpwd.Text = obj.dr["CurrentPassword"].ToString();
                TxttradeAcc.Text = obj.dr["TradenetAccount"].ToString();
                TxtDecName.Text = obj.dr["DeclarantName"].ToString();
                TxtDecCompCode.Text = obj.dr["DeclarantCode"].ToString();
                TxtDecCompName.Text = obj.dr["Name"].ToString();
               // Name1.Text = obj.dr["ContactFax"].ToString();
                TxtDecCompCRUEI.Text = obj.dr["CRUEI"].ToString();
                TxtDecTel.Text = obj.dr["DeclarantTel"].ToString();
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
            DateTime exp = DateTime.Today.AddDays(85);
            string expdate = exp.ToString("yyyy/MM/dd");
            string Name1 = "";
            string SCode = "";
            string StrQuery = ("INSERT INTO [dbo].[DeclarantCompany] ([TradeNetMailboxID],[CurrentPassword],[TradenetAccount],[DeclarantName],[DeclarantCode],[Code],[Name],[Name1],[DeclarantTel],[CRUEI],[AccountID],[Status],[TouchUser],[TouchTime],[ValididityDate])  VALUES ('" + TxtMailBoxID.Text + "','" + TxtCurrentpwd.Text + "','" + TxttradeAcc.Text + "','" + TxtDecName.Text + "','" + TxtDecCompCode.Text + "','" + SCode + "','" + TxtDecCompName.Text + "','" + Name1 + "','" + TxtDecTel.Text + "','" + TxtDecCompCRUEI.Text + "','" + DrpAccountId.SelectedItem.ToString() + "','" + DrpStatus.SelectedItem.ToString() + "','" + Touch_user + "','" + strTime + "','" + expdate + "')");
            obj.exec(StrQuery);
        }
        public void Editdata()
        {
            string Touch_user = Session["UserId"].ToString();
            string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string Name1="";
            string SCode = "";
            string StrQuery = ("UPDATE [dbo].[DeclarantCompany] SET [TradeNetMailboxID] ='" + TxtMailBoxID.Text + "'  ,[CurrentPassword] ='" + TxtCurrentpwd.Text + "'  ,[TradenetAccount] ='" + TxttradeAcc.Text + "' ,[DeclarantName] = '" + TxtDecName.Text + "',[DeclarantCode]='" + TxtDecCompCode.Text + "',[Code] ='" + SCode + "' ,[Name] ='" + TxtDecCompName.Text + "',[Name1] ='" + Name1 + "' ,DeclarantTel='" + TxtDecTel.Text + "' ,[CRUEI] ='" + TxtDecCompCRUEI.Text + "',AccountID='" + DrpAccountId.SelectedItem.ToString() + "' ,Status='" + DrpStatus.SelectedItem.ToString() + "' ,[TouchUser] ='" + Touch_user + "'  ,[TouchTime] = '" + strTime + "' WHERE Id='" + Id + "' ");
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
                Response.Redirect("ManageMailboxList.aspx");
            }

            else
            {
                InsertDate();
                Response.Redirect("ManageMailboxList.aspx");

            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageMailboxList.aspx");
        }
    }
}