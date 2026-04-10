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
    public partial class ManageUser : System.Web.UI.Page
    {
      //  string decrpt = "";
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

            if (!IsPostBack)
            {             
                Session["Edit"] = true;
                Session["Id"] = Convert.ToInt32(Request.QueryString["Id"]);
                Id = Convert.ToInt32(Request.QueryString["Id"]);
                //Account ID
                string strv = "select * from [AdminCreate] order by AccountID";
                obj.dr = obj.ret_dr(strv);
                DrpAccountId.DataSource = null;
                DrpAccountId.DataSource = obj.dr;
                DrpAccountId.DataTextField = "AccountID";
                DrpAccountId.DataValueField = "Id";
                DrpAccountId.DataBind();
                obj.closecon();
                DrpAccountId.Items.Insert(0, new ListItem("--Select--", "0"));
                //Roles
                ////Account ID
                //string Sr = "select Id,Name from [CommonMaster] where TypeId='73' and StatusID=1 order by Name";
                //obj.dr = obj.ret_dr(Sr);
                //DrpRole.DataSource = null;
                //DrpRole.DataSource = obj.dr;
                //DrpRole.DataTextField = "Name";
                //DrpRole.DataValueField = "Id";
                //DrpRole.DataBind();
                //obj.closecon();
                //DrpRole.Items.Insert(0, new ListItem("--Select--", "0"));
                ////Groups
                //string Srg = "select Id,Name from [CommonMaster] where TypeId='74' and StatusID=1 order by Name";
                //obj.dr = obj.ret_dr(Srg);
                //DrpGroup.DataSource = null;
                //DrpGroup.DataSource = obj.dr;
                //DrpGroup.DataTextField = "Name";
                //DrpGroup.DataValueField = "Id";
                //DrpGroup.DataBind();
                //obj.closecon();
                //DrpGroup.Items.Insert(0, new ListItem("--Select--", "0"));

                //dEFAULTPOOL
                string Accountid = MyClass.GetSessionDes();
                string SrgD = "select * from SequencePool";
                obj.dr = obj.ret_dr(SrgD);
                DrpDecPool.DataSource = null;
                DrpDecPool.DataSource = obj.dr;
                DrpDecPool.DataTextField = "Description";
                DrpDecPool.DataValueField = "Id";
                DrpDecPool.DataBind();
                obj.closecon();
                DrpDecPool.Items.Insert(0, new ListItem("--Select--", "0"));

                chkDec_CheckedChanged(null, null);
                //Mainboxid
                // string Accountid = MyClass.GetSessionDes();
                string SrgsD = "select * from DeclarantCompany";
                obj.dr = obj.ret_dr(SrgsD);
                DrpMailbox.DataSource = null;
                DrpMailbox.DataSource = obj.dr;
                DrpMailbox.DataTextField = "TradeNetMailboxID";
                DrpMailbox.DataValueField = "Id";
                DrpMailbox.DataBind();
                obj.closecon();
                DrpMailbox.Items.Insert(0, new ListItem("--Select--", "0"));
                if (Id != 0)
                {
                    AdminEdit();
                   
                }
                BindInpaymentGrid();
                BindInnonpaymentGrid();
                BindOutGrid();
                BindtRANSGrid();
                BindcoGrid();
                //BindIOutGrid();
                //BindtranshipmentGrid();
                //BindCOGrid();
            }
            chkDec_CheckedChanged(null, null);
         
        }
        public void AdminEdit()
        {

            string strBindTxtBox = "select * from [ManageUser] where Id=" + Id;
            obj.dr = obj.ret_dr(strBindTxtBox);
            while (obj.dr.Read())
            {
                
                     DrpAccountId.ClearSelection();
                     DrpAccountId.Items.FindByText(obj.dr["AccountId"].ToString()).Selected = true;
                     txtuserid.Text = obj.dr["UserId"].ToString();
                     txtusername.Text = obj.dr["UserName"].ToString();
                     //string encrptpassword = MyClass.Encrypt(txtpassword.Text);
                     txtpassword.Text = obj.dr["Password"].ToString();
                     txtconPassword.Text = obj.dr["ConfirmPassword"].ToString();
                     txtdept.Text = obj.dr["Department"].ToString();
                     txttel.Text = obj.dr["Telephone"].ToString();
                     txtfax.Text = obj.dr["Fax"].ToString();
                     txtmobile.Text = obj.dr["Mobile"].ToString();
                     txtemail.Text = obj.dr["Email"].ToString();
                     DrpStatus.ClearSelection();
                     DrpStatus.Items.FindByText(obj.dr["Status"].ToString()).Selected = true;
                     DrpMailbox.ClearSelection();
                     DrpMailbox.Items.FindByText(obj.dr["MailBoxId"].ToString()).Selected = true;
                     

                     string AccountAdmin = obj.dr["AccountAdmin"].ToString();
                     if (AccountAdmin == "True")
                     {
                         ChkAccAd.Checked = true;
                     }
                     else
                     {
                         ChkAccAd.Checked = false;
                     }
                     string B2BDocAdmin = obj.dr["B2BDocAdmin"].ToString();

                     if (B2BDocAdmin == "True")
                     {
                         ChkDocAd.Checked = true;
                     }
                     else
                     {
                         ChkDocAd.Checked = false;
                     }
                     string DataEntryClerk = obj.dr["DataEntryClerk"].ToString();
                     if (DataEntryClerk == "True")
                     {
                         ChkDataEC.Checked = true;
                     }
                     else
                     {
                         ChkDataEC.Checked = false;
                     }
                     string Declarent = obj.dr["Declarent"].ToString();
                     if (Declarent == "True")
                     {
                         chkDec.Checked = true;
                     }
                     else
                     {
                         chkDec.Checked = false;
                     }
                     string OperationManager = obj.dr["OperationManager"].ToString();
                     if (OperationManager == "True")
                     {
                         ChkOpManager.Checked = true;
                     }
                     else
                     {
                         ChkOpManager.Checked = false;
                     }

                    
            }
          
            BindInpaymentGrid();
            BindInnonpaymentGrid();
            BindOutGrid();
            BindtRANSGrid();
            BindcoGrid();
            DrpMailbox_SelectedIndexChanged(null, null);
            //BindIOutGrid();
            //BindtranshipmentGrid();
            //BindCOGrid();
        }
        public void InsertDate()
        {

            string encrptpassword = MyClass.Encrypt(txtpassword.Text);

            string Touch_user = Session["UserId"].ToString();
            string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string pwd = txtpassword.Text;
            string StrQuery = ("INSERT INTO [dbo].[ManageUser] ([AccountId],[UserId],[UserName],[Password],[ConfirmPassword],[Department],[Telephone],[Fax],[Mobile],[Email],[Status],LoginStatus,AccountAdmin,B2BDocAdmin,DataEntryClerk,Declarent,OperationManager,[UserCreated],[DateCreated],[UserLastUpdated],[DateLastUpdated],[MailBoxId]) VALUES ('" + DrpAccountId.SelectedItem.ToString() + "','" + txtuserid.Text + "','" + txtusername.Text + "','" + txtpassword.Text + "','" + txtpassword.Text + "','" + txtdept.Text + "','" + txttel.Text + "','" + txtfax.Text + "','" + txtmobile.Text + "','" + txtemail.Text + "','" + DrpStatus.SelectedItem.ToString() + "','" + null + "','" + ChkAccAd.Checked.ToString() + "','" + ChkDocAd.Checked.ToString() + "','" + ChkDataEC.Checked.ToString() + "','" + chkDec.Checked.ToString() + "','" + ChkOpManager.Checked.ToString() + "','" + Touch_user + "','" + strTime + "','" + Touch_user + "','" + strTime + "','" + DrpMailbox.SelectedItem.Text + "')");
            obj.exec(StrQuery);
            DeleteInpayment();
            DeleteInnonpayment();
            DeleteOut();
            DeletetRANS();
            Deleteco();
            //DeleteOutpayment();
            //Deletetranshipment();
            //DeleteCO();




        }
        public void Editdata()
        {
            string encrptpassword = MyClass.Encrypt(txtpassword.Text);
            string Touch_user = Session["UserId"].ToString();
            string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string pwd = txtpassword.Text;
            string StrQuery = ("UPDATE [dbo].[ManageUser] SET [AccountId] = '" + DrpAccountId.SelectedItem + "' ,[UserId] = '" + txtuserid.Text + "' ,[UserName] ='" + txtusername.Text + "' ,[Password] = '" + pwd + "' ,[ConfirmPassword] ='" + encrptpassword + "'  ,[Department] = '" + txtdept.Text + "' ,[Telephone] ='" + txttel.Text + "'  ,[Fax] = '" + txtfax.Text + "'  ,[Mobile] = '" + txtmobile.Text + "' ,[Email] = '" + txtemail.Text + "'  ,[Status] ='" + DrpStatus.SelectedItem + "'   ,AccountAdmin='" + ChkAccAd.Checked.ToString() + "',B2BDocAdmin='" + ChkDocAd.Checked.ToString() + "',DataEntryClerk='" + ChkDataEC.Checked.ToString() + "',Declarent='" + chkDec.Checked.ToString() + "',OperationManager='" + ChkOpManager.Checked.ToString() + "',[UserLastUpdated] = '" + Touch_user + "'   ,[DateLastUpdated] = '" + strTime + "',[MailBoxId]='" + DrpMailbox.SelectedItem.Text + "' WHERE Id='" + Id + "'");
            obj.exec(StrQuery);
            DeleteInpayment();
            DeleteInnonpayment();
            DeleteOut();
            DeletetRANS();
            Deleteco();
            //DeleteOutpayment();
            //Deletetranshipment();
            //DeleteCO();

        }


        protected void BtnSave_Click(object sender, EventArgs e)
        {
            Id = Convert.ToInt16(Session["Id"].ToString());
            if (Id != 0)
            {
                Editdata();
                Session["Edit"] = false;
                // eid = 0;
                Response.Redirect("ManageUserList.aspx");
            }

            else
            {
                InsertDate();
                Response.Redirect("ManageUserList.aspx");

            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageUserList.aspx");
        }

      

       

        protected void DrpMailbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string MailboxId = DrpMailbox.SelectedItem.ToString();
            string strBindTxtBox = "select * from DeclarantCompany where TradeNetMailboxID='"+MailboxId+"'";
            obj.dr = obj.ret_dr(strBindTxtBox);
            while (obj.dr.Read())
            {
                TxtDecName.Text = obj.dr["DeclarantName"].ToString();
                TxtDecCompCode.Text = obj.dr["DeclarantCode"].ToString();
                TxtDecCompName.Text = obj.dr["Name"].ToString();
                // Name1.Text = obj.dr["ContactFax"].ToString();
                TxtDecCompCRUEI.Text = obj.dr["CRUEI"].ToString();
                TxtDecTel.Text = obj.dr["DeclarantTel"].ToString();
            }
        }

        protected void ChkDataEC_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkDataEC.Checked == true)
            {
                DecDtl.Visible = true;
            }
            else if (chkDec.Checked == true)
            {
                DecDtl.Visible = true;
            }
            else
            {
                DecDtl.Visible = false;
            }
            
           
         
        }


        //Inpayment Grid
        private void BindInpaymentGrid()
        {
            string Touch_user = txtuserid.Text;
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            DataSet Gridds = new DataSet();
            using (SqlConnection con = new SqlConnection(constr))
            {
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand("SELECT FiledName,FiledValue FROM CustomiseReport Where ReportName='" + "Inpayment" + "' and UserName='"+Touch_user+"'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(ds);
                            if ((ds.Tables[0].Rows.Count > 0))
                            {
                                //Select the checkboxlist items those values are true in database
                                //Loop through the DataTable
                                ChkBoxListInPayment.Items.Clear();
                                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                                {
                                    //You need to change this as per your DB Design

                                    //CheckBoxList1.Items.FindByText(myResults.Tables[0].Rows[i]["FK_ic_id"].ToString()).Selected = true;
                                    //Find the checkbox list items using FindByValue and select it.
                                    ChkBoxListInPayment.Items.Add(ds.Tables[0].Rows[i]["FiledName"].ToString());
                                    if (ds.Tables[0].Rows[i]["FiledValue"].ToString() == "True")
                                    {
                                        ChkBoxListInPayment.Items[i].Selected = true;
                                    }
                                    else
                                    {
                                        ChkBoxListInPayment.Items[i].Selected = false;
                                    }
                                }
                            }

                            else
                            {

                                string str = "SELECT        t1.Id, t1.JobId, t1.MSGId, CONVERT(varchar, t1.TouchTime, 105) AS DecDate, SUBSTRING(t1.DeclarationType, 1, CHARINDEX(':', t1.DeclarationType) - 1) AS DeclarationType, t1.TouchUser AS Createby, t2.TradeNetMailboxID AS DecId, CONVERT(varchar, t1.ArrivalDate, 105) AS ETA, t1.PermitId AS PermitNo, t3.Name AS Importer,STUFF((SELECT ', ' + US.InHAWBOBL FROM ItemDtl US WHERE US.PermitId = t1.PermitId FOR XML PATH('')), 1, 1, '') InHAWBOBL,CASE  WHEN  t1.InwardTransportMode = '4 : Air' THEN t1.MasterAirwayBill  WHEN t1.InwardTransportMode = '1 : Sea'  THEN t1.OceanBillofLadingNo  ELSE ''  END AS MAWBOBL,t1.LoadingPortCode, t1.MessageType, t1.InwardTransportMode, t1.PreviousPermit, t1.InternalRemarks, SUBSTRING(t5.TermType, 1, CHARINDEX(':', t5.TermType) - 1) AS TermType, SUM(t5.GSTSUMAmount) AS GSTSUMAmount,(select Count(ItemNo) from ItemDtl where ItemDtl.PermitId=t1.PermitId) as SumOfItem, t1.Status FROM  InHeaderTbl AS t1 INNER JOIN DeclarantCompany AS t2 ON t1.DeclarantCompanyCode = t2.Code INNER JOIN Importer AS t3 ON t1.ImporterCompanyCode = t3.Code INNER JOIN InvoiceDtl AS t5 ON t1.PermitId = t5.PermitId GROUP BY t1.Id, t1.JobId, t1.MSGId, t1.TouchTime, t1.TouchUser, t1.DeclarationType, t1.ArrivalDate, t1.PermitId, t1.InwardTransportMode, t1.MasterAirwayBill, t1.OceanBillofLadingNo, t1.LoadingPortCode, t1.MessageType, t1.InwardTransportMode, t1.PreviousPermit, t1.InternalRemarks, t1.Status, t2.TradeNetMailboxID, t3.Name, t5.TermType";
                                using (SqlCommand cmd1 = new SqlCommand(str))
                                {
                                    using (SqlDataAdapter sda1 = new SqlDataAdapter())
                                    {
                                        cmd1.Connection = con;
                                        sda1.SelectCommand = cmd1;
                                        using (DataTable dt1 = new DataTable())
                                        {
                                            sda1.Fill(Gridds);
                                        }
                                        ChkBoxListInPayment.Items.Clear();
                                        foreach (DataColumn dc in Gridds.Tables[0].Columns)
                                        {
                                            
                                            ChkBoxListInPayment.Items.Add(dc.ToString());

                                        }

                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        protected void DeleteInpayment()
        {
            string Touch_user = txtuserid.Text;
            string type = "Inpayment";
            string ChkVal = "";
            int n = 0;
            string strDelete = "delete from [CustomiseReport] where [ReportName]='Inpayment' and UserName='" + Touch_user + "'";
            obj.exec(strDelete);

            for (int i = 0; i < ChkBoxListInPayment.Items.Count; i++)
            {
                n = i + 1;
                if (ChkBoxListInPayment.Items[i].Selected == true)
                {
                    ChkVal = "True";
                }
                else
                {
                    ChkVal = "False";
                }
                string str1 = ChkBoxListInPayment.Items[i].ToString();
                obj.exec("insert into CustomiseReport(ReportName,Sno,FiledName,FiledValue,UserName) values('" + type + "','" + n + "','" + str1 + "','" + ChkVal + "','" + Touch_user + "')");
            }



            obj.closecon();


        }


        //Innon Payment Grid

        private void BindInnonpaymentGrid()
        {
            string Touch_user = txtuserid.Text;
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            DataSet Gridds = new DataSet();
            using (SqlConnection con = new SqlConnection(constr))
            {
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand("SELECT FiledName,FiledValue FROM CustomiseReport Where ReportName='" + "Innonpayment" + "' and UserName='" + Touch_user + "'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(ds);
                            if ((ds.Tables[0].Rows.Count > 0))
                            {
                                //Select the checkboxlist items those values are true in database
                                //Loop through the DataTable
                                ChkBoxListInnonPayment.Items.Clear();
                                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                                {
                                    //You need to change this as per your DB Design

                                    //CheckBoxList1.Items.FindByText(myResults.Tables[0].Rows[i]["FK_ic_id"].ToString()).Selected = true;
                                    //Find the checkbox list items using FindByValue and select it.
                                    ChkBoxListInnonPayment.Items.Add(ds.Tables[0].Rows[i]["FiledName"].ToString());
                                    if (ds.Tables[0].Rows[i]["FiledValue"].ToString() == "True")
                                    {
                                        ChkBoxListInnonPayment.Items[i].Selected = true;
                                    }
                                    else
                                    {
                                        ChkBoxListInnonPayment.Items[i].Selected = false;
                                    }
                                }
                            }

                            else
                            {

                                string str = "SELECT  t1.Id, t1.JobId, t1.MSGId, CONVERT(varchar, t1.TouchTime, 105) AS DecDate, SUBSTRING(t1.DeclarationType, 1, CHARINDEX(':', t1.DeclarationType) - 1) AS DeclarationType, t1.TouchUser AS Createby, t2.TradeNetMailboxID AS DecId, CONVERT(varchar, t1.ArrivalDate, 105) AS ETA, t1.PermitId AS PermitNo, t3.Name AS Importer,STUFF((SELECT ', ' + US.InHAWBOBL FROM ItemDtl US WHERE US.PermitId = t1.PermitId FOR XML PATH('')), 1, 1, '') InHAWBOBL,CASE  WHEN  t1.InwardTransportMode = '4 : Air' THEN t1.MasterAirwayBill   WHEN t1.InwardTransportMode = '1 : Sea'  THEN t1.OceanBillofLadingNo   ELSE ''  END AS MAWBOBL,t1.LoadingPortCode, t1.MessageType, t1.InwardTransportMode,  t1.PreviousPermit, t1.InternalRemarks, SUBSTRING(t5.TermType, 1, CHARINDEX(':', t5.TermType) - 1) AS TermType,  SUM(t5.GSTSUMAmount) AS GSTSUMAmount,  (select Count(ItemNo) from ItemDtl where   ItemDtl.PermitId=t1.PermitId) as SumOfItem, t1.Status  FROM  InNonHeaderTbl AS t1 INNER JOIN   DeclarantCompany AS t2 ON t1.DeclarantCompanyCode = t2.Code   INNER JOIN Importer AS t3 ON t1.ImporterCompanyCode = t3.Code   INNER JOIN InNonInvoiceDtl AS t5 ON t1.PermitId = t5.PermitId   GROUP BY t1.Id, t1.JobId, t1.MSGId, t1.TouchTime, t1.TouchUser, t1.DeclarationType, t1.ArrivalDate, t1.PermitId, t1.InwardTransportMode, t1.MasterAirwayBill, t1.OceanBillofLadingNo, t1.LoadingPortCode, t1.MessageType, t1.InwardTransportMode, t1.PreviousPermit, t1.InternalRemarks, t1.Status, t2.TradeNetMailboxID, t3.Name, t5.TermType";
                                using (SqlCommand cmd1 = new SqlCommand(str))
                                {
                                    using (SqlDataAdapter sda1 = new SqlDataAdapter())
                                    {
                                        cmd1.Connection = con;
                                        sda1.SelectCommand = cmd1;
                                        using (DataTable dt1 = new DataTable())
                                        {
                                            sda1.Fill(Gridds);
                                        }
                                        ChkBoxListInnonPayment.Items.Clear();
                                        foreach (DataColumn dc in Gridds.Tables[0].Columns)
                                        {
                                           
                                            ChkBoxListInnonPayment.Items.Add(dc.ToString());

                                        }

                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        protected void DeleteInnonpayment()
        {
            string Touch_user = txtuserid.Text;
            string type = "Innonpayment";
            string ChkVal = "";
            int n = 0;
            string strDelete = "delete from [CustomiseReport] where [ReportName]='Innonpayment' and UserName='" + Touch_user + "'";
            obj.exec(strDelete);

            for (int i = 0; i < ChkBoxListInnonPayment.Items.Count; i++)
            {
                n = i + 1;
                if (ChkBoxListInnonPayment.Items[i].Selected == true)
                {
                    ChkVal = "True";
                }
                else
                {
                    ChkVal = "False";
                }
                string str1 = ChkBoxListInnonPayment.Items[i].ToString();
                obj.exec("insert into CustomiseReport(ReportName,Sno,FiledName,FiledValue,UserName) values('" + type + "','" + n + "','" + str1 + "','" + ChkVal + "','" + Touch_user + "')");
            }



            obj.closecon();


        }

        private void BindOutGrid()
        {
            string Touch_user = txtuserid.Text;
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            DataSet Gridds = new DataSet();
            using (SqlConnection con = new SqlConnection(constr))
            {
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand("SELECT FiledName,FiledValue FROM CustomiseReport Where ReportName='" + "OUT" + "' and UserName='" + Touch_user + "'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(ds);
                            if ((ds.Tables[0].Rows.Count > 0))
                            {
                                //Select the checkboxlist items those values are true in database
                                //Loop through the DataTable
                                ChkBoxListOut.Items.Clear();
                                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                                {
                                    //You need to change this as per your DB Design

                                    //CheckBoxList1.Items.FindByText(myResults.Tables[0].Rows[i]["FK_ic_id"].ToString()).Selected = true;
                                    //Find the checkbox list items using FindByValue and select it.
                                    ChkBoxListOut.Items.Add(ds.Tables[0].Rows[i]["FiledName"].ToString());
                                    if (ds.Tables[0].Rows[i]["FiledValue"].ToString() == "True")
                                    {
                                        ChkBoxListOut.Items[i].Selected = true;
                                    }
                                    else
                                    {
                                        ChkBoxListOut.Items[i].Selected = false;
                                    }
                                }
                            }

                            else
                            {

                                string str = "SELECT  t1.Id, t1.JobId, t1.MSGId,CONVERT(varchar, t1.TouchTime, 105) AS DecDate, SUBSTRING(t1.DeclarationType, 1,  CHARINDEX(':', t1.DeclarationType) - 1) AS DeclarationType, t1.TouchUser AS Createby, t2.TradeNetMailboxID AS DecId, CONVERT(varchar, t1.DepartureDate, 105) AS ETD, t1.PermitId AS PermitNo, t1.PreviousPermit,  t3.OutUserName AS Exporter, STUFF((SELECT ', ' + US.InHAWBOBL FROM OutItemDtl US  WHERE US.PermitId = t1.PermitId  FOR XML PATH('')), 1, 1, '') InHAWBOBL,CASE   WHEN  t1.OutwardTransportMode = '4 : Air' THEN t1.MasterAirwayBill     WHEN t1.OutwardTransportMode = '1 : Sea'  THEN t1.OceanBillofLadingNo    ELSE ''  END AS MAWBOBL, t1.DischargePort as POD, t1.MessageType, t1.OutwardTransportMode, t1.InternalRemarks,  SUM(t5.GSTSUMAmount) AS GSTSUMAmount,  (select Count(ItemNo) from OutItemDtl   where   OutItemDtl.PermitId=t1.PermitId) as SumOfItem, t1.Status    FROM  OutHeaderTbl AS t1 INNER JOIN   DeclarantCompany AS t2   ON t1.DeclarantCompanyCode = t2.Code   INNER JOIN OutExporter AS t3   ON t1.ExporterCompanyCode = t3.OutUserCode   INNER JOIN OutInvoiceDtl AS t5   ON t1.PermitId = t5.PermitId  GROUP BY t1.Id, t1.JobId, t1.MSGId, t1.TouchTime, t1.TouchUser, t1.DeclarationType, t1.DepartureDate, t1.PermitId,t1.PreviousPermit, t1.OutwardTransportMode, t1.MasterAirwayBill, t1.OceanBillofLadingNo, t1.DischargePort, t1.MessageType, t1.InwardTransportMode, t1.PreviousPermit, t1.InternalRemarks, t1.Status, t2.TradeNetMailboxID, t3.OutUserName";
                                using (SqlCommand cmd1 = new SqlCommand(str))
                                {
                                    using (SqlDataAdapter sda1 = new SqlDataAdapter())
                                    {
                                        cmd1.Connection = con;
                                        sda1.SelectCommand = cmd1;
                                        using (DataTable dt1 = new DataTable())
                                        {
                                            sda1.Fill(Gridds);
                                        }
                                        ChkBoxListOut.Items.Clear();
                                        foreach (DataColumn dc in Gridds.Tables[0].Columns)
                                        {

                                            ChkBoxListOut.Items.Add(dc.ToString());

                                        }

                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        protected void DeleteOut()
        {
            string Touch_user = txtuserid.Text;
            string type = "OUT";
            string ChkVal = "";
            int n = 0;
            string strDelete = "delete from [CustomiseReport] where [ReportName]='OUT' and UserName='" + Touch_user + "'";
            obj.exec(strDelete);

            for (int i = 0; i < ChkBoxListOut.Items.Count; i++)
            {
                n = i + 1;
                if (ChkBoxListOut.Items[i].Selected == true)
                {
                    ChkVal = "True";
                }
                else
                {
                    ChkVal = "False";
                }
                string str1 = ChkBoxListOut.Items[i].ToString();
                obj.exec("insert into CustomiseReport(ReportName,Sno,FiledName,FiledValue,UserName) values('" + type + "','" + n + "','" + str1 + "','" + ChkVal + "','" + Touch_user + "')");
            }



            obj.closecon();


        }
        //tRANSHIPMENT

        private void BindtRANSGrid()
        {
            string Touch_user = txtuserid.Text;
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            DataSet Gridds = new DataSet();
            using (SqlConnection con = new SqlConnection(constr))
            {
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand("SELECT FiledName,FiledValue FROM CustomiseReport Where ReportName='" + "TRANSHIPMENT" + "' and UserName='" + Touch_user + "'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(ds);
                            if ((ds.Tables[0].Rows.Count > 0))
                            {
                                //Select the checkboxlist items those values are true in database
                                //Loop through the DataTable
                                ChkBoxListTrans.Items.Clear();
                                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                                {
                                    //You need to change this as per your DB Design

                                    //CheckBoxList1.Items.FindByText(myResults.Tables[0].Rows[i]["FK_ic_id"].ToString()).Selected = true;
                                    //Find the checkbox list items using FindByValue and select it.
                                    ChkBoxListTrans.Items.Add(ds.Tables[0].Rows[i]["FiledName"].ToString());
                                    if (ds.Tables[0].Rows[i]["FiledValue"].ToString() == "True")
                                    {
                                        ChkBoxListTrans.Items[i].Selected = true;
                                    }
                                    else
                                    {
                                        ChkBoxListTrans.Items[i].Selected = false;
                                    }
                                }
                            }

                            else
                            {

                                string str = "SELECT t1.Id, t1.JobId, t1.MSGId, CONVERT(varchar, t1.TouchTime, 105) AS DecDate, SUBSTRING(t1.DeclarationType, 1, CHARINDEX(':', t1.DeclarationType) - 1) AS DeclarationType, t1.TouchUser AS Createby, t2.TradeNetMailboxID AS DecId, CONVERT(varchar, t1.ArrivalDate, 105) AS ETA, t1.PermitId AS PermitNo, t3.Name AS Importer,STUFF((SELECT ', ' + US.InHAWBOBL  FROM TranshipmentItemDtl  US  WHERE US.PermitId = t1.PermitId FOR XML PATH('')), 1, 1, '') InHAWBOBL,CASE   WHEN  t1.InwardTransportMode = '4 : Air' THEN t1.MasterAirwayBill  WHEN t1.InwardTransportMode = '1 : Sea'  THEN t1.OceanBillofLadingNo  ELSE ''  END AS MAWBOBL,t1.LoadingPortCode, t1.MessageType, t1.InwardTransportMode, t1.PreviousPermit, t1.InternalRemarks,(select Count(ItemNo) from TranshipmentItemDtl where TranshipmentItemDtl.PermitId=t1.PermitId) as SumOfItem, t1.Status FROM  TranshipmentHeader AS t1 INNER JOIN DeclarantCompany AS t2 ON t1.DeclarantCompanyCode = t2.Code INNER JOIN Importer AS t3 ON t1.ImporterCompanyCode = t3.Code  INNER JOIN ManageUser AS t6 ON t6.UserId=t1.TouchUser  GROUP BY t1.Id, t1.JobId, t1.MSGId, t1.TouchTime, t1.TouchUser, t1.DeclarationType, t1.ArrivalDate, t1.PermitId, t1.InwardTransportMode, t1.MasterAirwayBill, t1.OceanBillofLadingNo, t1.LoadingPortCode, t1.MessageType, t1.InwardTransportMode,  t1.PreviousPermit, t1.InternalRemarks, t1.Status, t2.TradeNetMailboxID, t3.Name,t6.AccountId";
                                using (SqlCommand cmd1 = new SqlCommand(str))
                                {
                                    using (SqlDataAdapter sda1 = new SqlDataAdapter())
                                    {
                                        cmd1.Connection = con;
                                        sda1.SelectCommand = cmd1;
                                        using (DataTable dt1 = new DataTable())
                                        {
                                            sda1.Fill(Gridds);
                                        }
                                        ChkBoxListTrans.Items.Clear();
                                        foreach (DataColumn dc in Gridds.Tables[0].Columns)
                                        {

                                            ChkBoxListTrans.Items.Add(dc.ToString());

                                        }

                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        protected void DeletetRANS()
        {
            string Touch_user = txtuserid.Text;
            string type = "TRANSHIPMENT";
            string ChkVal = "";
            int n = 0;
            string strDelete = "delete from [CustomiseReport] where [ReportName]='TRANSHIPMENT' and UserName='" + Touch_user + "'";
            obj.exec(strDelete);

            for (int i = 0; i < ChkBoxListTrans.Items.Count; i++)
            {
                n = i + 1;
                if (ChkBoxListTrans.Items[i].Selected == true)
                {
                    ChkVal = "True";
                }
                else
                {
                    ChkVal = "False";
                }
                string str1 = ChkBoxListTrans.Items[i].ToString();
                obj.exec("insert into CustomiseReport(ReportName,Sno,FiledName,FiledValue,UserName) values('" + type + "','" + n + "','" + str1 + "','" + ChkVal + "','" + Touch_user + "')");
            }



            obj.closecon();


        }

        //co

        private void BindcoGrid()
        {
            string Touch_user = txtuserid.Text;
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            DataSet Gridds = new DataSet();
            using (SqlConnection con = new SqlConnection(constr))
            {
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand("SELECT FiledName,FiledValue FROM CustomiseReport Where ReportName='" + "CO" + "' and UserName='" + Touch_user + "'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(ds);
                            if ((ds.Tables[0].Rows.Count > 0))
                            {
                                //Select the checkboxlist items those values are true in database
                                //Loop through the DataTable
                                ChkBoxListCo.Items.Clear();
                                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                                {
                                    //You need to change this as per your DB Design

                                    //CheckBoxList1.Items.FindByText(myResults.Tables[0].Rows[i]["FK_ic_id"].ToString()).Selected = true;
                                    //Find the checkbox list items using FindByValue and select it.
                                    ChkBoxListCo.Items.Add(ds.Tables[0].Rows[i]["FiledName"].ToString());
                                    if (ds.Tables[0].Rows[i]["FiledValue"].ToString() == "True")
                                    {
                                        ChkBoxListCo.Items[i].Selected = true;
                                    }
                                    else
                                    {
                                        ChkBoxListCo.Items[i].Selected = false;
                                    }
                                }
                            }

                            else
                            {

                                string str = "SELECT  t1.Id, t1.JobId, t1.MSGId,CONVERT(varchar, t1.TouchTime, 105) AS DecDate, t1.ApplicationType AS DeclarationType, t1.TouchUser AS Createby, t2.TradeNetMailboxID AS DecId, CONVERT(varchar, t1.DepartureDate, 105) AS ETD, t1.PermitId AS PermitNo, t1.PreviousPermitNo,  t3.Code AS Exporter, STUFF((SELECT ', ' + US.InHAWBOBL FROM OutItemDtl US  WHERE US.PermitId = t1.PermitId  FOR XML PATH('')), 1, 1, '') InHAWBOBL, t1.DischargePort as POD, t1.MessageType, t1.OutwardTransportMode, t1.InternalRemarks,  (select Count(ItemNo) from COItemDtl   where   COItemDtl.PermitId=t1.PermitId) as SumOfItem, t1.Status  FROM  COHeaderTbl AS t1 INNER JOIN   DeclarantCompany AS t2   ON t1.DeclarantCompanyCode = t2.Code   INNER JOIN COExporter AS t3   ON t1.ExporterCompanyCode = t3.Code  INNER JOIN ManageUser AS t6 ON t6.UserId=t1.TouchUser   GROUP BY t1.Id, t1.JobId, t1.MSGId, t1.TouchTime, t1.TouchUser, t1.ApplicationType, t1.DepartureDate, t1.PermitId,t1.PreviousPermitNo, t1.OutwardTransportMode, t1.DischargePort, t1.MessageType, t1.OutwardTransportMode, t1.PreviousPermitNo, t1.InternalRemarks, t1.Status, t2.TradeNetMailboxID, t3.Code,t6.AccountId";
                                using (SqlCommand cmd1 = new SqlCommand(str))
                                {
                                    using (SqlDataAdapter sda1 = new SqlDataAdapter())
                                    {
                                        cmd1.Connection = con;
                                        sda1.SelectCommand = cmd1;
                                        using (DataTable dt1 = new DataTable())
                                        {
                                            sda1.Fill(Gridds);
                                        }
                                        ChkBoxListCo.Items.Clear();
                                        foreach (DataColumn dc in Gridds.Tables[0].Columns)
                                        {

                                            ChkBoxListCo.Items.Add(dc.ToString());

                                        }

                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        protected void Deleteco()
        {
            string Touch_user = txtuserid.Text;
            string type = "CO";
            string ChkVal = "";
            int n = 0;
            string strDelete = "delete from [CustomiseReport] where [ReportName]='CO' and UserName='" + Touch_user + "'";
            obj.exec(strDelete);

            for (int i = 0; i < ChkBoxListCo.Items.Count; i++)
            {
                n = i + 1;
                if (ChkBoxListCo.Items[i].Selected == true)
                {
                    ChkVal = "True";
                }
                else
                {
                    ChkVal = "False";
                }
                string str1 = ChkBoxListCo.Items[i].ToString();
                obj.exec("insert into CustomiseReport(ReportName,Sno,FiledName,FiledValue,UserName) values('" + type + "','" + n + "','" + str1 + "','" + ChkVal + "','" + Touch_user + "')");
            }



            obj.closecon();


        }

     ////Out 
       


     //   private void BindIOutGrid()
     //   {
     //       string Touch_user = txtuserid.Text;
     //       string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
     //       DataSet Gridds = new DataSet();
     //       using (SqlConnection con = new SqlConnection(constr))
     //       {
     //           DataSet ds = new DataSet();
     //           using (SqlCommand cmd = new SqlCommand("SELECT FiledName,FiledValue FROM CustomiseReport Where ReportName='" + "Out" + "' and UserName='" + Touch_user + "'"))
     //           {
     //               using (SqlDataAdapter sda = new SqlDataAdapter())
     //               {
     //                   cmd.Connection = con;
     //                   sda.SelectCommand = cmd;
     //                   using (DataTable dt = new DataTable())
     //                   {
     //                       sda.Fill(ds);
     //                       if ((ds.Tables[0].Rows.Count > 0))
     //                       {
     //                           //Select the checkboxlist items those values are true in database
     //                           //Loop through the DataTable
     //                           ChkBoxListOut.Items.Clear();
     //                           for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
     //                           {
     //                               //You need to change this as per your DB Design

     //                               //CheckBoxList1.Items.FindByText(myResults.Tables[0].Rows[i]["FK_ic_id"].ToString()).Selected = true;
     //                               //Find the checkbox list items using FindByValue and select it.
     //                               ChkBoxListOut.Items.Add(ds.Tables[0].Rows[i]["FiledName"].ToString());
     //                               if (ds.Tables[0].Rows[i]["FiledValue"].ToString() == "True")
     //                               {
     //                                   ChkBoxListOut.Items[i].Selected = true;
     //                               }
     //                               else
     //                               {
     //                                   ChkBoxListOut.Items[i].Selected = false;
     //                               }
     //                           }
     //                       }

     //                       else
     //                       {

     //                           string str = "select t1.JobId,MSGId, convert(varchar, t1.TouchTime, 105) as DecDate,DeclarationType,t1.TouchUser as Createby,t2.TradeNetMailboxID as DecId, convert(varchar, ArrivalDate, 105) as ETA,t1.PermitId as PermitNo,t3.Name as Importer,t4.InHAWBOBL,";
     //                           str = str + "CASE  WHEN  t1.InwardTransportMode = '4 : Air' THEN t1.MasterAirwayBill  WHEN t1.InwardTransportMode = '1 : Sea'  THEN t1.OceanBillofLadingNo  ELSE ''  END AS MAWBOBL,t1.LoadingPortCode,t1.MessageType,t1.InwardTransportMode,t1.PreviousPermit,t1.InternalRemarks,t5.TermType,t5.GSTSUMAmount,sum(t4.ItemNo) as SumOFItem,t1.Status";
     //                           str = str + "from InNonHeaderTbl t1 , DeclarantCompany t2 , Importer t3,InNonItemDtl t4,InNonInvoiceDtl t5  where t1.DeclarantCompanyCode=t2.Code  and t1.ImporterCompanyCode=t3.Code  and t1.PermitId=t4.PermitId and";
     //                           str = str + "  t1.PermitId=t5.PermitId and t1.PermitId='Permit 006'  GROUP BY t4.ItemNo,t1.JobId,t1.MSGId,t1.TouchTime,t1.TouchUser";
     //                           str = str + "   ,t1.DeclarationType,t2.TradeNetMailboxID,t1.ArrivalDate,t1.PermitId,t3.Name,t4.InHAWBOBL,t1.InwardTransportMode ,t1.MasterAirwayBill,t1.OceanBillofLadingNo,t1.LoadingPortCode ,t1.MessageType,t1.InwardTransportMode,t1.PreviousPermit,t1.InternalRemarks,t5.TermType,t5.GSTSUMAmount,t1.Status";
     //                           using (SqlCommand cmd1 = new SqlCommand(str))
     //                           {
     //                               using (SqlDataAdapter sda1 = new SqlDataAdapter())
     //                               {
     //                                   cmd1.Connection = con;
     //                                   sda1.SelectCommand = cmd1;
     //                                   using (DataTable dt1 = new DataTable())
     //                                   {
     //                                       sda1.Fill(Gridds);
     //                                   }

     //                                   foreach (DataColumn dc in Gridds.Tables[0].Columns)
     //                                   {
     //                                       ChkBoxListOut.Items.Add(dc.ToString());

     //                                   }

     //                               }
     //                           }
     //                       }
     //                   }
     //               }
     //           }
     //       }
     //   }


     //   protected void DeleteOutpayment()
     //   {
     //       string Touch_user = txtuserid.Text;
     //       string type = "Out";
     //       string ChkVal = "";
     //       int n = 0;
     //       string strDelete = "delete from [CustomiseReport] where [ReportName]='Out' and UserName='" + Touch_user + "'";
     //       obj.exec(strDelete);

     //       for (int i = 0; i < ChkBoxListOut.Items.Count; i++)
     //       {
     //           n = i + 1;
     //           if (ChkBoxListOut.Items[i].Selected == true)
     //           {
     //               ChkVal = "True";
     //           }
     //           else
     //           {
     //               ChkVal = "False";
     //           }
     //           string str1 = ChkBoxListOut.Items[i].ToString();
     //           obj.exec("insert into CustomiseReport(ReportName,Sno,FiledName,FiledValue,UserName) values('" + type + "','" + n + "','" + str1 + "','" + ChkVal + "','" + Touch_user + "')");
     //       }



     //       obj.closecon();


     //   }



     //   //Transhipment 



     //   private void BindtranshipmentGrid()
     //   {
     //       string Touch_user = txtuserid.Text;
     //       string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
     //       DataSet Gridds = new DataSet();
     //       using (SqlConnection con = new SqlConnection(constr))
     //       {
     //           DataSet ds = new DataSet();
     //           using (SqlCommand cmd = new SqlCommand("SELECT FiledName,FiledValue FROM CustomiseReport Where ReportName='" + "Transhipment" + "' and UserName='" + Touch_user + "'"))
     //           {
     //               using (SqlDataAdapter sda = new SqlDataAdapter())
     //               {
     //                   cmd.Connection = con;
     //                   sda.SelectCommand = cmd;
     //                   using (DataTable dt = new DataTable())
     //                   {
     //                       sda.Fill(ds);
     //                       if ((ds.Tables[0].Rows.Count > 0))
     //                       {
     //                           //Select the checkboxlist items those values are true in database
     //                           //Loop through the DataTable
     //                           ChkBoxListTrans.Items.Clear();
     //                           for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
     //                           {
     //                               //You need to change this as per your DB Design

     //                               //CheckBoxList1.Items.FindByText(myResults.Tables[0].Rows[i]["FK_ic_id"].ToString()).Selected = true;
     //                               //Find the checkbox list items using FindByValue and select it.
     //                               ChkBoxListTrans.Items.Add(ds.Tables[0].Rows[i]["FiledName"].ToString());
     //                               if (ds.Tables[0].Rows[i]["FiledValue"].ToString() == "True")
     //                               {
     //                                   ChkBoxListTrans.Items[i].Selected = true;
     //                               }
     //                               else
     //                               {
     //                                   ChkBoxListTrans.Items[i].Selected = false;
     //                               }
     //                           }
     //                       }

     //                       else
     //                       {

     //                           string str = "select t1.JobId,MSGId, convert(varchar, t1.TouchTime, 105) as DecDate,DeclarationType,t1.TouchUser as Createby,t2.TradeNetMailboxID as DecId, convert(varchar, ArrivalDate, 105) as ETA,t1.PermitId as PermitNo,t3.Name as Importer,t4.InHAWBOBL,";
     //                           str = str + "CASE  WHEN  t1.InwardTransportMode = '4 : Air' THEN t1.MasterAirwayBill  WHEN t1.InwardTransportMode = '1 : Sea'  THEN t1.OceanBillofLadingNo  ELSE ''  END AS MAWBOBL,t1.LoadingPortCode,t1.MessageType,t1.InwardTransportMode,t1.PreviousPermit,t1.InternalRemarks,t5.TermType,t5.GSTSUMAmount,sum(t4.ItemNo) as SumOFItem,t1.Status";
     //                           str = str + "from InNonHeaderTbl t1 , DeclarantCompany t2 , Importer t3,InNonItemDtl t4,InNonInvoiceDtl t5  where t1.DeclarantCompanyCode=t2.Code  and t1.ImporterCompanyCode=t3.Code  and t1.PermitId=t4.PermitId and";
     //                           str = str + "  t1.PermitId=t5.PermitId and t1.PermitId='Permit 006'  GROUP BY t4.ItemNo,t1.JobId,t1.MSGId,t1.TouchTime,t1.TouchUser";
     //                           str = str + "   ,t1.DeclarationType,t2.TradeNetMailboxID,t1.ArrivalDate,t1.PermitId,t3.Name,t4.InHAWBOBL,t1.InwardTransportMode ,t1.MasterAirwayBill,t1.OceanBillofLadingNo,t1.LoadingPortCode ,t1.MessageType,t1.InwardTransportMode,t1.PreviousPermit,t1.InternalRemarks,t5.TermType,t5.GSTSUMAmount,t1.Status";
     //                           using (SqlCommand cmd1 = new SqlCommand(str))
     //                           {
     //                               using (SqlDataAdapter sda1 = new SqlDataAdapter())
     //                               {
     //                                   cmd1.Connection = con;
     //                                   sda1.SelectCommand = cmd1;
     //                                   using (DataTable dt1 = new DataTable())
     //                                   {
     //                                       sda1.Fill(Gridds);
     //                                   }

     //                                   foreach (DataColumn dc in Gridds.Tables[0].Columns)
     //                                   {
     //                                       ChkBoxListTrans.Items.Add(dc.ToString());

     //                                   }

     //                               }
     //                           }
     //                       }
     //                   }
     //               }
     //           }
     //       }
     //   }


     //   protected void Deletetranshipment()
     //   {
     //       string Touch_user = txtuserid.Text;
     //       string type = "Transhipment";
     //       string ChkVal = "";
     //       int n = 0;
     //       string strDelete = "delete from [CustomiseReport] where [ReportName]='Transhipment' and UserName='" + Touch_user + "'";
     //       obj.exec(strDelete);

     //       for (int i = 0; i < ChkBoxListTrans.Items.Count; i++)
     //       {
     //           n = i + 1;
     //           if (ChkBoxListTrans.Items[i].Selected == true)
     //           {
     //               ChkVal = "True";
     //           }
     //           else
     //           {
     //               ChkVal = "False";
     //           }
     //           string str1 = ChkBoxListTrans.Items[i].ToString();
     //           obj.exec("insert into CustomiseReport(ReportName,Sno,FiledName,FiledValue,UserName) values('" + type + "','" + n + "','" + str1 + "','" + ChkVal + "','" + Touch_user + "')");
     //       }



     //       obj.closecon();


     //   }

     //   //CO 



     //   private void BindCOGrid()
     //   {
     //       string Touch_user = txtuserid.Text;
     //       string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
     //       DataSet Gridds = new DataSet();
     //       using (SqlConnection con = new SqlConnection(constr))
     //       {
     //           DataSet ds = new DataSet();
     //           using (SqlCommand cmd = new SqlCommand("SELECT FiledName,FiledValue FROM CustomiseReport Where ReportName='" + "Co" + "' and UserName='" + Touch_user + "'"))
     //           {
     //               using (SqlDataAdapter sda = new SqlDataAdapter())
     //               {
     //                   cmd.Connection = con;
     //                   sda.SelectCommand = cmd;
     //                   using (DataTable dt = new DataTable())
     //                   {
     //                       sda.Fill(ds);
     //                       if ((ds.Tables[0].Rows.Count > 0))
     //                       {
     //                           //Select the checkboxlist items those values are true in database
     //                           //Loop through the DataTable
     //                           ChkBoxListCo.Items.Clear();
     //                           for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
     //                           {
     //                               //You need to change this as per your DB Design

     //                               //CheckBoxList1.Items.FindByText(myResults.Tables[0].Rows[i]["FK_ic_id"].ToString()).Selected = true;
     //                               //Find the checkbox list items using FindByValue and select it.
     //                               ChkBoxListCo.Items.Add(ds.Tables[0].Rows[i]["FiledName"].ToString());
     //                               if (ds.Tables[0].Rows[i]["FiledValue"].ToString() == "True")
     //                               {
     //                                   ChkBoxListCo.Items[i].Selected = true;
     //                               }
     //                               else
     //                               {
     //                                   ChkBoxListCo.Items[i].Selected = false;
     //                               }
     //                           }
     //                       }

     //                       else
     //                       {

     //                           string str = "select t1.JobId,MSGId, convert(varchar, t1.TouchTime, 105) as DecDate,DeclarationType,t1.TouchUser as Createby,t2.TradeNetMailboxID as DecId, convert(varchar, ArrivalDate, 105) as ETA,t1.PermitId as PermitNo,t3.Name as Importer,t4.InHAWBOBL,";
     //                           str = str + "CASE  WHEN  t1.InwardTransportMode = '4 : Air' THEN t1.MasterAirwayBill  WHEN t1.InwardTransportMode = '1 : Sea'  THEN t1.OceanBillofLadingNo  ELSE ''  END AS MAWBOBL,t1.LoadingPortCode,t1.MessageType,t1.InwardTransportMode,t1.PreviousPermit,t1.InternalRemarks,t5.TermType,t5.GSTSUMAmount,sum(t4.ItemNo) as SumOFItem,t1.Status";
     //                           str = str + "from InNonHeaderTbl t1 , DeclarantCompany t2 , Importer t3,InNonItemDtl t4,InNonInvoiceDtl t5  where t1.DeclarantCompanyCode=t2.Code  and t1.ImporterCompanyCode=t3.Code  and t1.PermitId=t4.PermitId and";
     //                           str = str + "  t1.PermitId=t5.PermitId and t1.PermitId='Permit 006'  GROUP BY t4.ItemNo,t1.JobId,t1.MSGId,t1.TouchTime,t1.TouchUser";
     //                           str = str + "   ,t1.DeclarationType,t2.TradeNetMailboxID,t1.ArrivalDate,t1.PermitId,t3.Name,t4.InHAWBOBL,t1.InwardTransportMode ,t1.MasterAirwayBill,t1.OceanBillofLadingNo,t1.LoadingPortCode ,t1.MessageType,t1.InwardTransportMode,t1.PreviousPermit,t1.InternalRemarks,t5.TermType,t5.GSTSUMAmount,t1.Status";
     //                           using (SqlCommand cmd1 = new SqlCommand(str))
     //                           {
     //                               using (SqlDataAdapter sda1 = new SqlDataAdapter())
     //                               {
     //                                   cmd1.Connection = con;
     //                                   sda1.SelectCommand = cmd1;
     //                                   using (DataTable dt1 = new DataTable())
     //                                   {
     //                                       sda1.Fill(Gridds);
     //                                   }

     //                                   foreach (DataColumn dc in Gridds.Tables[0].Columns)
     //                                   {
     //                                       ChkBoxListCo.Items.Add(dc.ToString());

     //                                   }

     //                               }
     //                           }
     //                       }
     //                   }
     //               }
     //           }
     //       }
     //   }


     //   protected void DeleteCO()
     //   {
     //       string Touch_user = txtuserid.Text;
     //       string type = "Co";
     //       string ChkVal = "";
     //       int n = 0;
     //       string strDelete = "delete from [CustomiseReport] where [ReportName]='Co' and UserName='" + Touch_user + "'";
     //       obj.exec(strDelete);

     //       for (int i = 0; i < ChkBoxListCo.Items.Count; i++)
     //       {
     //           n = i + 1;
     //           if (ChkBoxListCo.Items[i].Selected == true)
     //           {
     //               ChkVal = "True";
     //           }
     //           else
     //           {
     //               ChkVal = "False";
     //           }
     //           string str1 = ChkBoxListCo.Items[i].ToString();
     //           obj.exec("insert into CustomiseReport(ReportName,Sno,FiledName,FiledValue,UserName) values('" + type + "','" + n + "','" + str1 + "','" + ChkVal + "','" + Touch_user + "')");
     //       }



     //       obj.closecon();


     //   }


        protected void chkDec_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDec.Checked == true)
            {
                DecDtl.Visible = true;
            }
            else if (ChkDataEC.Checked == true)
            {
                DecDtl.Visible = true;
            }
            else
            {
                DecDtl.Visible = false;
            }
        }

        protected void ChkBoxListInPayment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ChkBoxListInPayment_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ChkBoxListInnonPayment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ChkBoxListInnonPayment_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}