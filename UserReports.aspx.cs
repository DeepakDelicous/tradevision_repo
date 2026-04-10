using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RET
{
    public partial class UserReports : System.Web.UI.Page
    {
        // string decrpt = "";
        MyClass obj = new MyClass();
        string sqlconn = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
        private DataTable inpatdt = new DataTable();
        private DataTable innonpdt = new DataTable();
        private DataTable outdt = new DataTable();
        private DataTable transdt = new DataTable();
        private DataTable codt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            LblErr.Text = "";
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

            }

            }
        private void BindAEDComplianceReport()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string MailBox = "";

                string perqry31 = "select TradenetAccount from ManageUser a1,DeclarantCompany a2 where a1.MailBoxId=a2.TradeNetMailboxID and  UserId='" + Session["UserId"].ToString() + "'";
                obj.dr = obj.ret_dr(perqry31);
                while (obj.dr.Read())
                {
                    MailBox = obj.dr["TradenetAccount"].ToString();
                }


                string query = "";
                query = query + "   select a1.TradeNetMailboxID,a1.PermitNumber,a1.MSGId,a1.TouchTime as DateSubmitted,a2.StartDate as Permitdate,a3.OutUserName + ' ' + a3.OutUserName1 as ExporterName,a3.OutUserCRUEI as ExporterUEN , ";
                query = query + " STUFF((SELECT distinct(', ' + US.InHAWBOBL) FROM OutItemDtl US  WHERE US.PermitId = a1.PermitId";
                query = query + " FOR XML PATH('')), 1, 1, '') InHAWBOBL,CASE WHEN  a1.OutwardTransportMode = '4 : Air' THEN a1.MasterAirwayBill";
                query = query + " WHEN a1.OutwardTransportMode = '1 : Sea'  THEN a1.OceanBillofLadingNo ELSE ''  END AS MAWBOBL,a1.DepartureDate,a1.DepartureTime";
                query = query + " ,a1.Status,DATEDIFF(DAY, a1.DepartureDate, a2.StartDate) AS ApprvvsETD,(case when a1.DepartureDate >= a2.StartDate";
                query = query + "  then 'YES' else 'NO'";
                query = query + "  end) as AEDCompliant,(case when a1.DepartureDate >= a2.StartDate";
                query = query + "    then 'No' else 'Yes'";
                query = query + " end) as Late,a1.TradeRemarks,a1.TouchUser as Creator,";
                query = query + " CASE WHEN  a1.Status = 'APR' and a1.prmtStatus = 'NEW' THEN 'No'";
                query = query + "  WHEN a1.Status = 'APR' and a1.prmtStatus = 'AMD'  THEN 'YES'    ELSE ''  END AS Amendment";
                query = query + " from OutHeaderTbl a1, OutPMT a2,OutExporter a3, OutItemDtl a4";
                query = query + " where a1.PermitNumber = a2.PermitNumber and a1.ExporterCompanyCode = a3.OutUserCode and a1.PermitId = a4.PermitId";
                query = query + " and a1.Status = 'APR' and a1.TradeNetMailboxID lIKE '%"+ MailBox + "%' and  a1.TouchTime>='" + Convert.ToDateTime(TxtFromDate.Text).ToString("yyyy/MM/dd") + "' and a1.TouchTime<='" + Convert.ToDateTime(TxtToDate.Text).ToString("yyyy/MM/dd") + "'";
                query = query + " group by a1.TradeNetMailboxID, a1.PermitNumber,a1.MSGId,a1.TouchTime,a2.StartDate,a3.OutUserName + ' ' + a3.OutUserName1,a3.OutUserCRUEI,a1.PermitId,a1.OutwardTransportMode,a1.MasterAirwayBill,a1.OutwardTransportMode,a1.OceanBillofLadingNo";
                query = query + " ,a1.DepartureDate,a1.DepartureTime,a1.Status,a1.TradeRemarks,a1.TouchUser,a1.prmtStatus";





                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridReport.DataSource = dt;
                            GridReport.DataBind();
                        }
                    }
                }
            }
        }

        private void BindBillingReport()
        {
            string inpaymentqry = "", Innonpaymentqry = "", Outqry = "", Trashipmentqry = "", Coqry = "";
            string MailBox = "";

            string perqry31 = "select TradenetAccount from ManageUser a1,DeclarantCompany a2 where a1.MailBoxId=a2.TradeNetMailboxID and  UserId='" + Session["UserId"].ToString() + "'";
            obj.dr = obj.ret_dr(perqry31);
            while (obj.dr.Read())
            {
                MailBox = obj.dr["TradenetAccount"].ToString();
            }

            //Inpayment
            inpaymentqry = inpaymentqry + " select a1.TradeNetMailboxID,a1.PermitNumber,max(MSGId) as MSGID,a1.Status,a1.DeclarationType,MAX(a1.TouchTime) as DeclarationDate,a2.DeclarantName";
            inpaymentqry = inpaymentqry + " ,a1.TouchUser as USERId,a1.PreviousPermit as PrevPermitNo,a3.StartDate as ApprovalDate,a4.Name + ' ' + a4.Name1 as ImporterName, '' as ExporterName";
            inpaymentqry = inpaymentqry + " from InHeaderTbl a1,DeclarantCompany a2, InPMT as a3 ,Importer a4";
            inpaymentqry = inpaymentqry + " where a1.TradeNetMailboxID = a2.TradeNetMailboxID and a1.PermitNumber = a3.PermitNumber and";
            inpaymentqry = inpaymentqry + " a1.ImporterCompanyCode = a4.Code  and a1.Status = 'APR' and a1.TradeNetMailboxID Like '%"+MailBox+ "%' and  a1.TouchTime>='" + Convert.ToDateTime(TxtFromDate.Text).ToString("yyyy/MM/dd") + "' and a1.TouchTime<='" + Convert.ToDateTime(TxtToDate.Text).ToString("yyyy/MM/dd") + "'";
            inpaymentqry = inpaymentqry + " group by  a1.TradeNetMailboxID,a1.PermitNumber,a1.Status,a1.DeclarationType,a2.DeclarantName,a1.TouchUser,a1.PreviousPermit,a3.StartDate,a4.Name,a4.Name1";

            //InnonPayment
            Innonpaymentqry = Innonpaymentqry + "    select a1.TradeNetMailboxID,a1.PermitNumber,max(MSGId) as MSGID,a1.Status,a1.DeclarationType,MAX(a1.TouchTime) as DeclarationDate,a2.DeclarantName";
            Innonpaymentqry = Innonpaymentqry + " ,a1.TouchUser as USERId,a1.PreviousPermit as PrevPermitNo,a3.StartDate as ApprovalDate,a4.Name + ' ' + a4.Name1 as ImporterName, '' as ExporterName";
            Innonpaymentqry = Innonpaymentqry + " from InNonHeaderTbl a1,DeclarantCompany a2, InnonPMT as a3 ,Importer a4";
            Innonpaymentqry = Innonpaymentqry + " where a1.TradeNetMailboxID = a2.TradeNetMailboxID and a1.PermitNumber = a3.PermitNumber and";
            Innonpaymentqry = Innonpaymentqry + " a1.ImporterCompanyCode = a4.Code and a1.Status = 'APR' and a1.TradeNetMailboxID Like '%"+MailBox+ "%' and  a1.TouchTime>='" + Convert.ToDateTime(TxtFromDate.Text).ToString("yyyy/MM/dd") + "' and a1.TouchTime<='" + Convert.ToDateTime(TxtToDate.Text).ToString("yyyy/MM/dd") + "'";
            Innonpaymentqry = Innonpaymentqry + " group by  a1.TradeNetMailboxID,a1.PermitNumber,a1.Status,a1.DeclarationType,a2.DeclarantName,a1.TouchUser,a1.PreviousPermit,a3.StartDate,a4.Name,a4.Name1";

            //Out
            Outqry = Outqry + "    select a1.TradeNetMailboxID,a1.PermitNumber,max(MSGId) as MSGID,a1.Status,a1.DeclarationType,MAX(a1.TouchTime) as DeclarationDate,a2.DeclarantName";
            Outqry = Outqry + " ,a1.TouchUser as USERId,a1.PreviousPermit as PrevPermitNo,a3.StartDate as ApprovalDate,a4.Name + ' ' + a4.Name1 as ImporterName, '' as ExporterName";
            Outqry = Outqry + " from OutHeaderTbl a1,DeclarantCompany a2, OutPMT as a3 ,Importer a4";
            Outqry = Outqry + " where a1.TradeNetMailboxID = a2.TradeNetMailboxID and a1.PermitNumber = a3.PermitNumber and";
            Outqry = Outqry + " a1.ImporterCompanyCode = a4.Code and a1.Status = 'APR' and a1.TradeNetMailboxID Like '%"+MailBox+ "%' and  a1.TouchTime>='" + Convert.ToDateTime(TxtFromDate.Text).ToString("yyyy/MM/dd") + "' and a1.TouchTime<='" + Convert.ToDateTime(TxtToDate.Text).ToString("yyyy/MM/dd") + "'";
            Outqry = Outqry + " group by  a1.TradeNetMailboxID,a1.PermitNumber,a1.Status,a1.DeclarationType,a2.DeclarantName,a1.TouchUser,a1.PreviousPermit,a3.StartDate,a4.Name,a4.Name1";

            //Transhipment 
            Trashipmentqry = Trashipmentqry + "     select a1.TradeNetMailboxID,a1.PermitNumber,max(MSGId) as MSGID,a1.Status,a1.DeclarationType,MAX(a1.TouchTime) as DeclarationDate,a2.DeclarantName";
            Trashipmentqry = Trashipmentqry + " ,a1.TouchUser as USERId,a1.PreviousPermit as PrevPermitNo,a3.StartDate as ApprovalDate,a4.Name + ' ' + a4.Name1 as ImporterName, '' as ExporterName";
            Trashipmentqry = Trashipmentqry + " from TranshipmentHeader a1,DeclarantCompany a2, TransPMT as a3 ,Importer a4";
            Trashipmentqry = Trashipmentqry + " where a1.TradeNetMailboxID = a2.TradeNetMailboxID and a1.PermitNumber = a3.PermitNumber and";
            Trashipmentqry = Trashipmentqry + " a1.ImporterCompanyCode = a4.Code and a1.Status = 'APR' and a1.TradeNetMailboxID Like '%"+MailBox+ "%' and  a1.TouchTime>='" + Convert.ToDateTime(TxtFromDate.Text).ToString("yyyy/MM/dd") + "' and a1.TouchTime<='" + Convert.ToDateTime(TxtToDate.Text).ToString("yyyy/MM/dd") + "'";
            Trashipmentqry = Trashipmentqry + " group by  a1.TradeNetMailboxID,a1.PermitNumber,a1.Status,a1.DeclarationType,a2.DeclarantName,a1.TouchUser,a1.PreviousPermit,a3.StartDate,a4.Name,a4.Name1";


            //CO
            Coqry = Coqry + "      select a1.TradeNetMailboxID,a1.PermitNumber,max(MSGId) as MSGID,a1.Status,a1.ApplicationType,MAX(a1.TouchTime) as DeclarationDate,a2.DeclarantName";
            Coqry = Coqry + " ,a1.TouchUser as USERId,a1.PreviousPermitNo as PrevPermitNo,a3.StartDate as ApprovalDate,a4.Name + ' ' + a4.Name1 as ImporterName, '' as ExporterName";
            Coqry = Coqry + " from COHeaderTbl a1,DeclarantCompany a2, CoPMT as a3 ,COExporter a4";
            Coqry = Coqry + " where a1.TradeNetMailboxID = a2.TradeNetMailboxID and a1.PermitNumber = a3.PermitNumber and";
            Coqry = Coqry + " a1.ExporterCompanyCode = a4.Code and a1.Status = 'APR' and a1.TradeNetMailboxID Like '%"+MailBox+ "%' and  a1.TouchTime>='" + Convert.ToDateTime(TxtFromDate.Text).ToString("yyyy/MM/dd") + "' and a1.TouchTime<='" + Convert.ToDateTime(TxtToDate.Text).ToString("yyyy/MM/dd") + "'";
            Coqry = Coqry + " group by  a1.TradeNetMailboxID,a1.PermitNumber,a1.Status,a1.ApplicationType,a2.DeclarantName,a1.TouchUser,a1.PreviousPermitNo,a3.StartDate,a4.Name,a4.Name1";


            //IN
            SqlConnection con = new SqlConnection(sqlconn);
            SqlCommand cmd = new SqlCommand(inpaymentqry, con);
            con.Open();               
            SqlDataAdapter da = new SqlDataAdapter(cmd);                  
            da.Fill(inpatdt);
            con.Close();
            da.Dispose();

            //INNON          
            SqlCommand cmd1 = new SqlCommand(Innonpaymentqry, con);
            con.Open();           
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);            
            da1.Fill(innonpdt);
            con.Close();
            da1.Dispose();

            //Out
            SqlCommand cmd2 = new SqlCommand(Innonpaymentqry, con);
            con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(outdt);
            con.Close();
            da2.Dispose();

            //Transhipment            
            SqlCommand cmd3 = new SqlCommand(Innonpaymentqry, con);
            con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            da3.Fill(transdt);
            con.Close();
            da3.Dispose();

            //Co           
            SqlCommand cmd4 = new SqlCommand(Innonpaymentqry, con);
            con.Open();
            SqlDataAdapter da4 = new SqlDataAdapter(cmd4);
            da4.Fill(codt);
            con.Close();
            da4.Dispose();



            DataTable merge = new DataTable();
            merge.Merge(inpatdt);
            merge.Merge(innonpdt);
            merge.Merge(outdt);
            merge.Merge(transdt);
            merge.Merge(codt);
            
            GridReport.DataSource = merge;
            GridReport.DataBind();




        }
        private void ExportGridToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = DrpRepport.SelectedItem.Text + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            GridReport.GridLines = GridLines.Both;
            GridReport.HeaderStyle.Font.Bold = true;
            GridReport.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();

        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (TxtFromDate.Text == "")
            {
                LblErr.Text = "Please Enter From Date";
                return;
            }
            else if (TxtToDate.Text == "")
            {
                LblErr.Text = "Please Enter To Date";
                return;
            }
            else if (DrpRepport.SelectedItem.Text == "--Select--")
            {
                LblErr.Text = "Please Choose Report";
                return;
            }
            else
            {
                if (DrpRepport.SelectedItem.Text == "AED Compliance Report (Monthly)")
                {

                    BindAEDComplianceReport();

                }
                else if(DrpRepport.SelectedItem.Text== "Billing Report (Summary by Approved Date)")
                {
                    BindBillingReport();
                }

            }
        }

        protected void BtnExcel_Click(object sender, EventArgs e)
        {
            if (TxtFromDate.Text == "")
            {
                LblErr.Text = "Please Enter From Date";
                return;
            }
            else if (TxtToDate.Text == "")
            {
                LblErr.Text = "Please Enter To Date";
                return;
            }
            else if (DrpRepport.SelectedItem.Text == "--Select--")
            {
                LblErr.Text = "Please Choose Report";
                return;
            }
            else
            {
                ExportGridToExcel();
            }
        }
    }
}