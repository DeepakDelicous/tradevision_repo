using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Org.BouncyCastle.Utilities;
using System.Xml.Linq;
using Org.BouncyCastle.Cms;
using System.ComponentModel;
using System.Drawing;

namespace RET
{
    public partial class Webhook : System.Web.UI.Page
    {
        MyClass obj = new MyClass();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.HttpMethod == "POST")
            {
                using (var reader = new StreamReader(Request.InputStream))
                {

                    string justdate = DateTime.Now.ToString("yyyyMMdd");
                    string JobNo = "";

                    string JobCount = "";
                    string qry11 = "SELECT COUNT(PermitId) as JobId  from PermitCount where  AccountId='KAIZEN' AND TouchTime ='" + justdate + "' ";
                    obj.dr = obj.ret_dr(qry11);
                    while (obj.dr.Read())
                    {
                        JobCount = obj.dr["JobId"].ToString();
                        int count = Convert.ToInt32(JobCount) + 1;
                        string Date = DateTime.Now.ToString("yyMMdd");
                        string code2 = "K" + Date + String.Format("{0:00000}", count);

                        JobNo = code2;

                    }
                    if (JobCount == "0")
                    {
                        string Date = DateTime.Now.ToString("yyyyMMdd");
                        // string code = "K" + Date + String.Format("{0:00000}");
                        JobNo = "K" + Date + "00001";
                    }


                    //MessageNo

                    string justdate2 = DateTime.Now.ToString("yyyyMMdd");
                    string MSGCount = "";
                    string MsgNO = "";
                    string qry112 = "SELECT COUNT(PermitId) as MsgID  from PermitCount where AccountId='KAIZEN' and TouchTime ='" + justdate2 + "' ";
                    obj.dr = obj.ret_dr(qry112);
                    while (obj.dr.Read())
                    {
                        MSGCount = obj.dr["MsgID"].ToString();
                        int count = Convert.ToInt32(MSGCount) + 1;
                        string Date = DateTime.Now.ToString("yyyyMMdd");
                        MsgNO = Date + "" + String.Format("{0:0000}", count);
                    }
                    if (MSGCount == "0")
                    {
                        string Date = DateTime.Now.ToString("yyyyMMdd");
                        MsgNO = Date + "0001";
                    }

                    string MailboxId = "";
                    string aa = "select Top 1 Mailboxid from ManageUser where UserId='1'";
                    obj.dr = obj.ret_dr(aa);
                    if (obj.dr.Read())
                    {
                    MailboxId = obj.dr["Mailboxid"].ToString();
                    }

                    //
                    string TxtTradeMailID = "";
                    string TxtDecName = "";
                    string TxtDecCode = "";
                    string TxtDecTelephone = "";
                    string TxtCRUEINO = "";

                    string qry111 = "SELECT Top 1 TradeNetMailboxID,DeclarantName,DeclarantCode,DeclarantTel,CRUEI  from DeclarantCompany a,ManageUser b  where a.AccountID=b.AccountId and a.TradeNetMailboxID=b.Mailboxid and b.UserId='1' and b.MailBoxid='" + MailboxId + "'  group by TradeNetMailboxID,DeclarantName,DeclarantCode,DeclarantTel,CRUEI";
                    obj.dr = obj.ret_dr(qry111);
                    if (obj.dr.Read())
                    {
                        TxtTradeMailID = obj.dr["TradeNetMailboxID"].ToString();
                        TxtDecName = obj.dr["DeclarantName"].ToString();
                        TxtDecCode = obj.dr["DeclarantCode"].ToString();
                        TxtDecTelephone = obj.dr["DeclarantTel"].ToString();
                        TxtCRUEINO = obj.dr["CRUEI"].ToString();
                    }

                    var TxtMsgType = "IPTDEC";
                    string Touch_user = "1";
                    string txt_code = "";

                    string justdate22 = DateTime.Now.ToString("yyyyMMdd");
                    string qry222 = "SELECT Max(Refid) as MaxRefid " +
                    "FROM InHeaderTbl " +
                    "WHERE MessageType='IPTDEC' " +
                    "AND LEFT(MSGId,8) = '" + justdate22 + "'";

                    obj.dr = obj.ret_dr(qry222);
                    string max_po_no = "";
                    if (obj.dr.Read())
                    {
                        max_po_no = obj.dr["MaxRefid"].ToString();
                    }

                    int m_po_no = 0;
                    if (!string.IsNullOrEmpty(max_po_no))
                    {
                        int endTagStartPosition = max_po_no.LastIndexOf("/");
                        if (endTagStartPosition >= 0)
                        {
                            max_po_no = max_po_no.Substring(endTagStartPosition + 1);
                        }

                        if (!string.IsNullOrEmpty(max_po_no))
                        {
                            m_po_no = Convert.ToInt32(max_po_no);
                        }
                    }

                    if (m_po_no != 0)
                    {
                        m_po_no = m_po_no + 1;
                    }

                    string code = Touch_user + justdate + String.Format("{0:000}", m_po_no);
                    txt_code = code;


                    var body = reader.ReadToEnd();

                    string port_of_loading = "";
                    string inward_vessel_name = "";
                    string inward_voyage_number = "";
                    string importer_name = "";
                    string exporter_name = "";
                    string inward_carrier = "";
                    string outward_carrier = "";
                    string total_outer_pack = "";
                    string total_gross_weight = "";
                    string arrival_date = "";
                    string loading_port = "";
                    string vessel_name = "";
                    string voyage_number = "";
                    string bl_number = "";
                    string release_location = "";
                    string recipient_location = "";
                    string departure_date = "";
                    string discharge_port = "";
                    string outward_vessel_name = "";
                    string outward_voyage_number = "";
                    string invoice_number = "";
                    string shipment_date = "";
                    string hs_quantity = "";
                    string total_line_amt = "";
                    string description = "";
                    string net_weight = "";
                    string currency = "";
                    string total_amount = "";
                    string total_amount_ = "";
                    string declaration_type = "";
                    string StrQuery = "";

                    if (body.Contains("port_of_loading"))
                    {
                        // very basic extractor
                        port_of_loading = Extract(body, "\"port_of_loading\":\"", "\"");
                        inward_vessel_name = Extract(body, "\"inward_vessel_name\":\"", "\"");
                        inward_voyage_number = Extract(body, "\"inward_voyage_number\":\"", "\"");
                        importer_name = Extract(body, "\"importer_name\":\"", "\"");
                        exporter_name = Extract(body, "\"exporter_name\":\"", "\"");
                        inward_carrier = Extract(body, "\"inward_carrier\":\"", "\"");
                        outward_carrier = Extract(body, "\"outward_carrier\":\"", "\"");
                        total_outer_pack = Extract(body, "\"total_outer_pack\":", ",");
                        total_gross_weight = Extract(body, "\"total_gross_weight\":", ",");
                        arrival_date = Extract(body, "\"arrival_date\":\"", "\"");
                        loading_port = Extract(body, "\"loading_port\":\"", "\"");
                        vessel_name = Extract(body, "\"vessel_name\":\"", "\"");
                        voyage_number = Extract(body, "\"voyage_number\":\"", "\"");
                        bl_number = Extract(body, "\"bl_number\":\"", "\"");
                        release_location = Extract(body, "\"release_location\":\"", "\"");
                        recipient_location = Extract(body, "\"recipient_location\":\"", "\"");
                        departure_date = Extract(body, "\"departure_date\":\"", "\"");
                        discharge_port = Extract(body, "\"discharge_port\":\"", "\"");
                        outward_vessel_name = Extract(body, "\"outward_vessel_name\":\"", "\"");
                        outward_voyage_number = Extract(body, "\"outward_voyage_number\":\"", "\"");
                        invoice_number = Extract(body, "\"invoice_number\":\"", "\"");
                        shipment_date = Extract(body, "\"shipment_date\":\"", "\"");
                        hs_quantity = Extract(body, "\"hs_quantity\":", ",");
                        total_line_amt = Extract(body, "\"total_line_amt\":\"", "\"");
                        description = Extract(body, "\"description\":\"", "\"");
                        net_weight = Extract(body, "\"net_weight\":\"", "\"");
                        currency = Extract(body, "\"currency\":\"", "\"");
                        total_amount = Extract(body, "\"total_amount\":\"", "\"");
                        total_amount_ = Extract(body, "\"total_amount_\":\"", "\"");
                        declaration_type = Extract(body, "\"declaration_type\":[", "]");
                        string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


                        StrQuery = ("INSERT INTO [dbo].[InHeaderTbl] ([JobId],[MSGId],[PermitId],[TradeNetMailboxID],[MessageType],[DeclarationType],[PreviousPermit],[CargoPackType],[InwardTransportMode],[BGIndicator],[SupplyIndicator],[ReferenceDocuments],[License],[Recipient],[DeclarantCompanyCode],[ImporterCompanyCode],[InwardCarrierAgentCode],[FreightForwarderCode],[ClaimantPartyCode],HBL,[ArrivalDate],[LoadingPortCode],[VoyageNumber],[VesselName],[OceanBillofLadingNo],[ConveyanceRefNo],[TransportId],[FlightNO],[AircraftRegNo],[MasterAirwayBill],[ReleaseLocation],ReleaseLocName,[RecepitLocation],[RecepitLocName],[TotalOuterPack],[TotalOuterPackUOM],[TotalGrossWeight],[TotalGrossWeightUOM],[GrossReference],[BlanketStartDate],[TradeRemarks],[InternalRemarks],[CustomerRemarks],[Status],[prmtStatus],[TouchUser],[TouchTime],[DeclareIndicator],[NumberOfItems],[TotalCIFFOBValue],[TotalGSTTaxAmt],[TotalExDutyAmt],[TotalCusDutyAmt],[TotalODutyAmt],[TotalAmtPay]) Values ('" + JobNo + "','" + MsgNO + "','" + txt_code + "','" + TxtTradeMailID + "','" + TxtMsgType + "','','','','','','','','','','','','','','','','" + Convert.ToDateTime(arrival_date).ToString("yyyy/MM/dd") + "','" + port_of_loading + "','" + inward_voyage_number + "','" + inward_vessel_name + "','','','','','','','" + release_location + "','','" + recipient_location + "','','" + total_outer_pack + "','','" + net_weight + "','KG','','" + Convert.ToDateTime(arrival_date).ToString("yyyy/MM/dd") + "','','','','NEW','NEW','" + Touch_user + "','" + strTime + "','','','','','','','','" + total_amount + "')");
                        int chkCode = 0;
                        chkCode = obj.exec(StrQuery);

                    }


                    string logPath = Server.MapPath("~/App_Data/webhook.log");

                    string logContent =
                    "=== Webhook Data Received at " + DateTime.Now + " ===" + Environment.NewLine +
                    "port_of_loading      : " + port_of_loading + Environment.NewLine +
                    "inward_vessel_name   : " + inward_vessel_name + Environment.NewLine +
                    "inward_voyage_number : " + inward_voyage_number + Environment.NewLine +
                    "importer_name        : " + importer_name + Environment.NewLine +
                    "exporter_name        : " + exporter_name + Environment.NewLine +
                    "inward_carrier       : " + inward_carrier + Environment.NewLine +
                    "outward_carrier      : " + outward_carrier + Environment.NewLine +
                    "total_outer_pack     : " + total_outer_pack + Environment.NewLine +
                    "total_gross_weight   : " + total_gross_weight + Environment.NewLine +
                    "arrival_date         : " + arrival_date + Environment.NewLine +
                    "loading_port         : " + loading_port + Environment.NewLine +
                    "vessel_name          : " + vessel_name + Environment.NewLine +
                    "voyage_number        : " + voyage_number + Environment.NewLine +
                    "bl_number            : " + bl_number + Environment.NewLine +
                    "release_location     : " + release_location + Environment.NewLine +
                    "recipient_location   : " + recipient_location + Environment.NewLine +
                    "departure_date       : " + departure_date + Environment.NewLine +
                    "discharge_port       : " + discharge_port + Environment.NewLine +
                    "outward_vessel_name  : " + outward_vessel_name + Environment.NewLine +
                    "outward_voyage_number: " + outward_voyage_number + Environment.NewLine +
                    "invoice_number       : " + invoice_number + Environment.NewLine +
                    "shipment_date        : " + shipment_date + Environment.NewLine +
                    "hs_quantity          : " + hs_quantity + Environment.NewLine +
                    "total_line_amt       : " + total_line_amt + Environment.NewLine +
                    "description          : " + description + Environment.NewLine +
                    "net_weight           : " + net_weight + Environment.NewLine +
                    "currency             : " + currency + Environment.NewLine +
                    "total_amount         : " + total_amount + Environment.NewLine +
                    "total_amount_        : " + total_amount_ + Environment.NewLine +
                    "declaration_type     : " + declaration_type + Environment.NewLine +
                    "job_no               : " + JobNo + Environment.NewLine +
                    "SQL Query            : " + StrQuery + Environment.NewLine;

                    File.WriteAllText(logPath, logContent);

                    Response.StatusCode = 200;
                    Response.ContentType = "application/json";
                    Response.Write("{\"status\":\"Webhook received successfully\"}");
                    Response.End();

                }
            }


        }

        private string Extract(string input, string start, string end)
        {
            int i1 = input.IndexOf(start);
            if (i1 == -1) return "";
            i1 += start.Length;
            int i2 = input.IndexOf(end, i1);
            if (i2 == -1) return input.Substring(i1);
            return input.Substring(i1, i2 - i1);
        }

    }
}