using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data.OleDb;
using RET.Classes;

namespace RET
{
    public partial class Inpayment : System.Web.UI.Page
    {
        //string OBLERR = "";
        //string DecAccountID = "";
        string ErrorDes = "";
        DataTable dt = new DataTable();
        bool editInvoice = false;
        public static string[] dec;
        private int code = 0;
        private static int Id = 0;
        private static string Update = "";
        static string premStatuschk = "NEW";
        //private static string chkdel = "";
        private static string chkstatus = "";
        public static string uom, exrate, exuom, crate, cuom, kgmvis, ss1;
        InpaymentClass obj = new InpaymentClass();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
        string sqlconn = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
        string TempDataPermitNo = "";
        // SqlDataAdapter dastudent;
        //  DataSet ds_student, ds_course;
        // SqlCommand cmdStudent;
        //bool edit = false;
        static string JobNo, MsgNO, refno = "";

        protected void Page_PreRender(object sender, EventArgs e)
        {
           // decBindGrid();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //duration-300 ease-in-out transition-all hidden
          //  drop_draft_area.ClientIDMode = ClientIDMode.Static;          

            //drop_draft_area.Attributes["class"] = "duration-300 ease-in-out transition-all hidden";

            if (Session["Userid"] == null)
            {
                Response.Redirect("sessionTimeout.aspx");
            }
            ChkTariff.Checked = true;
            ChkTariff_CheckedChanged(null, null);

            string LogStstus = "", Activeuser = "";
            string perqry31 = "select Top 1 LoginStatus,Activeuser from ManageUser where UserId='" + Session["UserId"].ToString() + "'";
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
            btnnextsum.Visible = false;
            LblHSErr.Text = "";
            string DecAccountID = Session["AccountId"].ToString();
            string MailboxId = "";
            string aa = "select Top 1 Mailboxid from ManageUser where UserId='" + Session["UserId"].ToString() + "'";
            obj.dr = obj.ret_dr(aa);
            if (obj.dr.Read())
            {
                MailboxId = obj.dr["Mailboxid"].ToString();
            }
            string qry111 = "SELECT Top 1 TradeNetMailboxID,DeclarantName,DeclarantCode,DeclarantTel,CRUEI  from DeclarantCompany a,ManageUser b  where a.AccountID=b.AccountId and a.TradeNetMailboxID=b.Mailboxid and b.UserId='" + Session["UserId"].ToString() + "' and b.MailBoxid='" + MailboxId + "'  group by TradeNetMailboxID,DeclarantName,DeclarantCode,DeclarantTel,CRUEI";
            obj.dr = obj.ret_dr(qry111);
            if (obj.dr.Read())
            {
                TxtTradeMailID.Text = obj.dr["TradeNetMailboxID"].ToString();
                TxtDecName.Text = obj.dr["DeclarantName"].ToString();
                TxtDecCode.Text = obj.dr["DeclarantCode"].ToString();
                TxtDecTelephone.Text = obj.dr["DeclarantTel"].ToString();
                TxtCRUEINO.Text = obj.dr["CRUEI"].ToString();
            }
            ContarinerGrid.RowDataBound += ContarinerGrid_RowDataBound;
            if (TxtHSCodeItem.Text.Trim().StartsWith("87"))
            {
                OptionalCharges.Visible = true;
                Vehicle.Visible = true;
            }
            else
            {
                OptionalCharges.Visible = false;
                Vehicle.Visible = false;
            }
            //BindInvoice();
            //BindItemMaster();
            // GetData();
            if (!IsPostBack)
            {
                chkstatus = "NEW";
                Session["Edit"] = true;
                Session["Id"] = Convert.ToInt32(Request.QueryString["Id"]);
                Session["Update"] = Convert.ToString(Request.QueryString["Update"]);
                Id = Convert.ToInt32(Request.QueryString["Id"]);
                Update = Convert.ToString(Request.QueryString["Update"]);
                if (chkaeo.Checked == true && chkcwc.Checked == true)
                {
                    AEO.Visible = true;
                    CWC.Visible = true;
                    return;
                }
                else if (chkaeo.Checked == true)
                {
                    AEO.Visible = true;
                    CWC.Visible = false;
                }
                else if (chkcwc.Checked == true)
                {
                    AEO.Visible = false;
                    CWC.Visible = true;
                }
                else
                {
                    AEO.Visible = false;
                    CWC.Visible = false;
                }

                if (ChkRefDoc.Checked == true)
                {
                    Document.Visible = true;
                }
                else
                {
                    Document.Visible = false;
                }
                //BindInvoice();
                //BindItemMaster();
                InwardFlight.Visible = false;
                InwardSea.Visible = false;
                InwardOther.Visible = false;
                decBindGrid();
                BindImport();
                BindInward();
                BindFrieght();
                BindClaimant();
                BindLoading();
                BindlOCATION();
                Bindreceipt();
                //invoice
                BindImportparty();
                BindGridinx();
                TotalInvoice.Visible = false;
                OtherTaxableCharge.Visible = false;
                FrieghtCharges.Visible = false;
                InsuranceCharges.Visible = false;
                CostInsuranceandFreight.Visible = false;
                GST.Visible = false;
                //item
                BindInhouse();
                BindHSCode();
                BindCountry();
                decBindGrid();
                //  GetData();
                BindProduct1();
                //BindProduct2();
                //BindProduct3();
                //BindProduct4();
                BindProduct5();
                if (ChkRefDoc.Checked == true)
                {
                    Document.Visible = true;
                }
                else
                {
                    Document.Visible = false;
                }
                //this . RegisterPostBackControl();
                PermitNO();
                JobNO();
                MSGNO();
                refid();
                InvoiceNo();
                ItemNO();
                ItemAddGrid.Visible = true;
                ItemDiv.Visible = true;
                SetInitialRow();
                SetInitialRow1cp();
                SetInitialRow2cp();
                SetInitialRow2cpScheme();
                SetInitialRow2cpSts();
                SetInitialRow2cpStscwc();
                SetInitialRow2cpIc();
                //cpc
                SetInitialRowc();
                this.BindGrid();

                //Reason Cancel
                string aa1 = "select Top 15 Id,Name +' : '+ Description AS Description from [CommonMaster] where TypeId='75' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(aa1);
                obj.BindDropDown(DrpReasonCancel, obj.dr, "Id", "Description");
                //DrpReasonCancel.DataSource = obj.dr;
                //DrpReasonCancel.DataTextField = "Description";
                //DrpReasonCancel.DataValueField = "Id";
                //DrpReasonCancel.DataBind();
                //obj.closecon();
                //DrpReasonCancel.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));




                //Customers
                string aaaxx = "select id,Customername from [Customer_Tbl] where Moduels='IPTDEC' order by Customername";
                obj.dr = obj.ret_dr(aaaxx);
                obj.BindDropDown(DrpCustomers, obj.dr, "id", "Customername");

                //Reason Refund
                string aaa = "select Top 40 Id,Name +' : '+ Description AS Description from [CommonMaster] where TypeId='76' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(aaa);
                obj.BindDropDown(DrpRefundReason, obj.dr, "Id", "Description");
                //Reason Refund Type
                string aaaa = "select Top 5 Id,Name +' : '+ Description AS Description from [CommonMaster] where TypeId='77' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(aaaa);
                obj.BindDropDown(DrpTypeRefund, obj.dr, "Id", "Description");
                //Reason Refund
                string aaa1 = "select Top 40 Id,Name +' : '+ Description AS Description from [CommonMaster] where TypeId='76' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(aaa1);
                obj.BindDropDown(DrpRefundReason, obj.dr, "Id", "Description");
                //Vehicle  Type
                string strv = "select Top 5 Id,Name from [CommonMaster] where TypeId='20' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(strv);
                obj.BindDropDown(DrpVehicleType, obj.dr, "Id", "Name");
                //Vehicle  Capacity Value
                string strv1 = "select Top 2 Id,Name from [CommonMaster] where TypeId='21' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(strv1);
                obj.BindDropDown(DrpVehicleCapacity, obj.dr, "Id", "Name");
                //Declaration Type
                string str = "select Top 5 Id,Name from [CommonMaster] where TypeId='1' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(str);
                obj.BindDropDown(DrpDecType, obj.dr, "Id", "Name");
                //CargoPackType
                string str1 = "select Top 2 Id,Name from [CommonMaster] where TypeId='2' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(str1);
                obj.BindDropDown(DrpCargoPackType, obj.dr, "Id", "Name");
                //InwardtrasMode
                string str11 = "select Top 10 Id,Name from [CommonMaster] where TypeId='3' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(str11);
                obj.BindDropDown(DrpInwardtrasMode, obj.dr, "Id", "Name");
                //BGIndicator
                string str111 = "select Top 2 Id,Name from [CommonMaster] where TypeId='4' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(str111);
                obj.BindDropDown(DrpBGIndicator, obj.dr, "Id", "Name");
                //DocType
                string str1111 = "select Top 45 Id,Name from [CommonMaster] where TypeId='5' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(str1111);
                obj.BindDropDown(DrpDocType, obj.dr, "Id", "Name");

                str1111 = "select Top 45 Id,Name from [CommonMaster] where TypeId='5' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(str1111);
                obj.BindDropDown(DrpDocumenttype, obj.dr, "Id", "Name");

                str1111 = "select Top 45 Id,Name from [CommonMaster] where TypeId='5' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(str1111);
                obj.BindDropDown(DrprefundDocType, obj.dr, "Id", "Name");
                //invoice
                string strss = "select Top 7 Id,Name from [CommonMaster] where TypeId='7' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(strss);
                obj.BindDropDown(DrpTerms, obj.dr, "Id", "Name");
                string str1aa = "select Top 2 Id,Name from [CommonMaster] where TypeId='8' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(str1aa);
                obj.BindDropDown(DrpSupImpRel, obj.dr, "Id", "Name");
                //Currency1
                string str11s = "select  Id,Currency from [Currency] order by Currency";
                obj.dr = obj.ret_dr(str11s);
                obj.BindDropDown(Drpcurrency1, obj.dr, "Id", "Currency");
                //Optional Currency1            


                string str7w = "select Top 25 Id,Name from [CommonMaster] where TypeId='9' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(str7w);
                obj.BindDropDown(DrpOptionalUom, obj.dr, "Name", "Name");
                //TCurrency2
                string str4 = "select  Id,Currency from [Currency]  order by Currency";
                obj.dr = obj.ret_dr(str4);
                obj.BindDropDown(Drpcurrency2, obj.dr, "Id", "Currency");
                obj.dr = obj.ret_dr(str4);
                obj.BindDropDown(Drpcurrency3, obj.dr, "Id", "Currency");
                obj.dr = obj.ret_dr(str4);
                obj.BindDropDown(Drpcurrency4, obj.dr, "Id", "Currency");
                obj.dr = obj.ret_dr(str4);
                obj.BindDropDown(DRPCurrency, obj.dr, "Id", "Currency");
                //Currency3
                //string str5 = "select Top 20 Id,Currency from [Currency]  order by Currency";
                //obj.dr = obj.ret_dr(str5);

                //Currency4
                //string str5s = "select Top 20 Id,Currency from [Currency]  order by Currency";
                //obj.dr = obj.ret_dr(str5s);

                //item


                //DrpOtherUOM
                string strsaa = "select Top 60 Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(strsaa);
                obj.BindDropDown(DrpOtherUOM, obj.dr, "Id", "Name");
                obj.dr = obj.ret_dr(strsaa);
                obj.BindDropDown(TDQUOM, obj.dr, "Id", "Name");

                obj.dr = obj.ret_dr(strsaa);
                obj.BindDropDown(ddptotDutiableQty, obj.dr, "Id", "Name");


             
                obj.dr = obj.ret_dr(strsaa);
                obj.BindDropDown(HSQTYUOM, obj.dr, "Id", "Name");
                obj.dr = obj.ret_dr(strsaa);
                obj.BindDropDown(DRPOPQUOM, obj.dr, "Id", "Name");
                obj.dr = obj.ret_dr(strsaa);
                obj.BindDropDown(DRPIPQUOM, obj.dr, "Id", "Name");
                obj.dr = obj.ret_dr(strsaa);
                obj.BindDropDown(DRPINNPQUOM, obj.dr, "Id", "Name");
                obj.dr = obj.ret_dr(strsaa);
                obj.BindDropDown(DRPIMPQUOM, obj.dr, "Id", "Name");
                obj.dr = obj.ret_dr(strsaa);
                obj.BindDropDown(DrptotalOuterPack, obj.dr, "Id", "Name");
                //DrpMaking 
                string stra = "select Id,Name from [CommonMaster] where TypeId='12' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(stra);
                obj.BindDropDown(DrpMaking, obj.dr, "Id", "Name");
                //DrpPreferentialCode
                string stdr = "select Id,Name from [CommonMaster] where TypeId='11' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(stdr);
                obj.BindDropDown(DrpPreferentialCode, obj.dr, "Id", "Name");
                //TDQ
                string striW = "select * from [InvoiceDtl] where MessageType='IPTDEC' AND PermitId='" + txt_code.Text + "'  order by InvoiceNo";
                obj.dr = obj.ret_dr(striW);
                obj.BindDropDown(DrpInvoiceNo, obj.dr, "Id", "InvoiceNo");
                //DrpInvoiceNo.DataSource = null;
                //DrpInvoiceNo.DataSource = obj.dr;
                //DrpInvoiceNo.DataTextField = "InvoiceNo";
                //DrpInvoiceNo.DataValueField = "Id";
                //DrpInvoiceNo.DataBind();
                //obj.closecon();
                //DrpInvoiceNo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
                //TDQ
                //string stri = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                //obj.dr = obj.ret_dr(stri);


                //string stri1 = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                //obj.dr = obj.ret_dr(stri1);


                //TDQ
                //string str1i = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                //obj.dr = obj.ret_dr(str1i);

                //TDQ
                //string str2i = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                //obj.dr = obj.ret_dr(str2i);

                //TDQ
                //string str3 = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                //obj.dr = obj.ret_dr(str3);

                //TDQ
                //string str5i = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                //obj.dr = obj.ret_dr(str5i);

                //TDQ
                //string str6 = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                //obj.dr = obj.ret_dr(str6);

                //TDQ
                //string str7 = "select * from [Currency]  order by Currency";
                //obj.dr = obj.ret_dr(str7);

                //P1
                string P1 = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(P1);
                obj.BindDropDown(DrpP1, obj.dr, "Name", "Name");
                obj.dr = obj.ret_dr(P1);
                obj.BindDropDown(DrpP2, obj.dr, "Name", "Name");
                obj.dr = obj.ret_dr(P1);
                obj.BindDropDown(DrpP3, obj.dr, "Name", "Name");
                obj.dr = obj.ret_dr(P1);
                obj.BindDropDown(DrpP4, obj.dr, "Name", "Name");
                obj.dr = obj.ret_dr(P1);
                obj.BindDropDown(DrpP5, obj.dr, "Name", "Name");
                //P2
                //string P2 = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                //obj.dr = obj.ret_dr(P2);

                //P3
                //string P3 = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                //obj.dr = obj.ret_dr(P3);

                //P4
                //string P4 = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                //obj.dr = obj.ret_dr(P4);

                //P5
                //string P5 = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                //obj.dr = obj.ret_dr(P5);

                //DrpCargoPackType_SelectedIndexChanged(null, null);

                ProductCode1();
                ProductCode2();
                ProductCode3();
                ProductCode4();
                ProductCode5();

                //Cargo UOM
                //string str6s = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                //obj.dr = obj.ret_dr(str6s);

                
                string temp = "select Top 1 PermitId from InpaymentTemp where  PermitId='" + txt_code.Text + "' and TouchUser='" + Session["UserId"].ToString() + "'";
                obj.dr = obj.ret_dr(temp);
                if (obj.dr.Read())
                {
                    TempDataPermitNo = obj.dr["PermitId"].ToString();
                    InPaymentEdit();
                }

                divamend.Visible = false;
                divcancel.Visible = false;
                divrefund.Visible = false;
                if (Update != "")
                {
                  
                    if (string.IsNullOrWhiteSpace(Update))
                    {
                        DeclBtn.Visible = true;
                        DeclInd.Visible = true;
                        upinsummary.Update();
                    }
                    if (Update == "AMEND")
                    {
                        divamend.Visible = true;
                        divcancel.Visible = false;
                        divrefund.Visible = false;
                        AmendBtn.Visible = true;
                        AmdInd.Visible = true;
                        chkstatus = "AMEND";
                        btnnextsum.Visible = true;
                        Amend.Visible = true;
                        cancel.Visible = false;
                        Refund.Visible = false;
                        upinamend.Update();



                        InpaymentClass lod12 = new InpaymentClass();
                        lod12.dr = lod12.ret_dr("select PermitNumber from InHeaderTbl where Id='" + Id + "'");
                        if (lod12.dr.HasRows)
                        {
                            while (lod12.dr.Read())
                            {
                                txtamendpermit.Text = lod12.dr["PermitNumber"].ToString();
                                InpaymentClass obj4 = new InpaymentClass();
                                obj4.dr = obj4.ret_dr("select Count(PermitNumber) from InHeaderTbl where PermitNumber='" + lod12.dr["PermitNumber"].ToString() + "' and (Status='APR' or Status='AME') and prmtStatus='AMD'");
                                if (obj4.dr.HasRows)
                                {
                                    while (obj4.dr.Read())
                                    {
                                        int value = Convert.ToInt16(obj4.dr[0].ToString());
                                        value = value + 1;
                                        txtamoundcount.Text = value.ToString();
                                        txtupdateindicator.Text = "AME";
                                    }
                                }
                            }
                            upinamend.Update();
                        }
                        lod12.dr = lod12.ret_dr("select * from InpaymentAmend where Permitno='" + txtamendpermit.Text + "'");
                        if (lod12.dr.HasRows)
                        {
                            while (lod12.dr.Read())
                            {
                                //txtamoundcount.Text = lod12.dr["AmendmentCount"].ToString();
                                txtupdateindicator.Text = lod12.dr["UpdateIndicator"].ToString();
                                txtamendpermit.Text = lod12.dr["Permitno"].ToString();
                                txtreplacepermit.Text = lod12.dr["ReplacementPermitno"].ToString();
                                txtdescreason.Text = lod12.dr["DescriptionOfReason"].ToString();
                                if (lod12.dr["PermitExtension"].ToString().ToUpper() == "true".ToUpper())
                                {
                                    ChkPermitvalEx.Checked = true;
                                }
                                else
                                {
                                    ChkPermitvalEx.Checked = false;
                                }
                                txtvalidity.Text = lod12.dr["ExtendImportPeriod"].ToString();
                                if (lod12.dr["DeclarationIndigator"].ToString().ToUpper() == "true".ToUpper())
                                {
                                    chkdec.Checked = true;
                                }
                                else
                                {
                                    chkdec.Checked = false;
                                }
                            }
                        }
                    }
                    if (Update == "CANCEL")
                    {
                        divcancel.Visible = true;
                        divrefund.Visible = false;
                        divamend.Visible = false;
                        CancelBtn.Visible = true;
                        CancelInd.Visible = true;
                        chkstatus = "CANCEL";
                        btnnextsum.Visible = true;
                        cancel.Visible = true;
                        Amend.Visible = false;
                        Refund.Visible = false;
                        InpaymentClass lod12 = new InpaymentClass();
                        lod12.dr = lod12.ret_dr("select PermitNumber from InHeaderTbl where Id='" + Id + "'");
                        if (lod12.dr.HasRows)
                        {
                            while (lod12.dr.Read())
                            {
                                txtcanPermit.Text = lod12.dr["PermitNumber"].ToString();
                                txtupdateInd.Text = "CNL";
                            }
                        }
                        lod12.dr = lod12.ret_dr("select * from InNonCancel where Permitno='" + txtcanPermit.Text + "'");
                        if (lod12.dr.HasRows)
                        {
                            while (lod12.dr.Read())
                            {
                                txtupdateInd.Text = lod12.dr["UpdateIndicator"].ToString();
                                txtcanPermit.Text = lod12.dr["Permitno"].ToString();
                                txtcanrepPermit.Text = lod12.dr["ReplacementPermitno"].ToString();
                                //DrpReasonCancel.ClearSelection();
                                //DrpReasonCancel.Items.FindByText(obj.dr["ResonForCancel"].ToString()).Selected = true;
                                txtdesReason.Text = lod12.dr["DescriptionOfReason"].ToString();
                                if (lod12.dr["DeclarationIndigator"].ToString().ToUpper() == "true".ToUpper())
                                {
                                    ChkCancelInd.Checked = true;
                                }
                                else
                                {
                                    ChkCancelInd.Checked = false;
                                }
                            }
                        }
                        upincancel.Update();
                    }
                    if (Update == "REFUND")
                    {

                        divcancel.Visible = false;
                        divrefund.Visible = true;
                        divamend.Visible = false;

                        SetInitialRowItemRef();
                        REFDecl.Visible = true;
                        RefundDiv.Visible = true;
                        RefundInd.Visible = true;
                        chkstatus = "REFUND";
                        btnnextsum.Visible = true;
                        Refund.Visible = true;
                        Amend.Visible = false;
                        cancel.Visible = false;
                        InpaymentClass lod12 = new InpaymentClass();
                        lod12.dr = lod12.ret_dr("select PermitNumber from InHeaderTbl where Id='" + Id + "'");
                        if (lod12.dr.HasRows)
                        {
                            while (lod12.dr.Read())
                            {
                                txtrenupdInd.Text = "RFD";
                                txtreundper.Text = lod12.dr["PermitNumber"].ToString();
                            }
                        }
                        upinrefund.Update();
                    }
                }

                if (Id != 0)
                {
                    InPaymentEdit();
                    return;
                }
                else
                {
                }
            }

            BindInvoice();
            BindItemMaster();
            SummaryCalculate();

            string qry11 = "select * from DeclarantCompany where TradeNetMailboxID='" + TxtTradeMailID.Text + "'";
            obj.dr = obj.ret_dr(qry11);
            while (obj.dr.Read())
            {
                // Id,Code,Name,Name1,CRUEI

                TxtDecCompCode.Text = obj.dr["Code"].ToString();
                TxtDecCompName.Text = obj.dr["Name"].ToString();
                TxtDecCompName1.Text = obj.dr["Name1"].ToString();
                TxtDecCompCRUEI.Text = obj.dr["CRUEI"].ToString();

            }
            //  DrpTerms_SelectedIndexChanged(null, null);            
        }




        public void ReqValidatePageLoad()
        {

            if (TxtTradeMailID.Text == "")
            {
                ErrorDes = "Header -  Please Enter TradeNet : ";
            }


            if (Update == "AMEND")
            {
                if (chkdec.Checked == false)
                {
                    ErrorDes = "Summary -  Please Choose Declaration Indicator : ";
                }
            }
            if (Update == "CANCEL")
            {
                if (ChkCancelInd.Checked == false)
                {
                    ErrorDes = "Summary -  Please Choose Declaration Indicator : ";
                }
            }
            if (Update == "REFUND")
            {
                if (ChkRefundInd.Checked == false)
                {
                    ErrorDes = "Summary -  Please Choose Declaration Indicator : ";
                }
            }
            if (Update == "")
            {
                if (chkDeclareInd.Checked == false)
                {
                    ErrorDes = "Summary -  Please Choose Declaration Indicator : ";
                }
            }


            if (TxtDecName.Text == "")
            {
                ErrorDes = ErrorDes + "Header -  Please Enter Declarent Name : ";

            }
            if (TxtDecCode.Text == "")
            {
                ErrorDes = ErrorDes + "Header -  Please Enter Declarent Code : ";

            }
            if (TxtDecTelephone.Text == "")
            {
                ErrorDes = ErrorDes + "Header -  Please Enter Declarent Code : ";

            }
            if (TxtCRUEINO.Text == "")
            {
                ErrorDes = ErrorDes + "Header -  Please Enter Declarent CRUEI : ";

            }
            if (DrpDecType.SelectedItem.ToString() == "--Select--")
            {
                ErrorDes = ErrorDes + "Header -  Please Choose Declaration Type : ";

            }
            if (DrpCargoPackType.SelectedItem.ToString() == "--Select--")
            {
                ErrorDes = ErrorDes + "Header -  Please Choose Cargo Pack Type : ";

            }
            if (TxtDecCompCRUEI.Text == "")
            {
                ErrorDes = ErrorDes + "Party -  Please Enter Declarent CRUEI : ";

            }
            if (TxtDecCompName.Text == "")
            {
                ErrorDes = ErrorDes + "Party -  Please Enter Declarent Name : ";

            }
            if (TxtImpCRUEI.Text == "")
            {
                ErrorDes = ErrorDes + "Party -  Please Enter Importer CRUEI : ";

            }
            if (TxtImpName.Text == "")
            {
                ErrorDes = ErrorDes + "Party -  Please Enter Importer Name : ";

            }



            if (TextMode.Text == "1 : Sea" || TextMode.Text == "4 : Air")
            {

                if (InwardName.Text == "")
                {
                    ErrorDes = ErrorDes + "Party -  Please Enter Inward Name : ";

                }

                if (InwardCRUEI.Text == "")
                {
                    ErrorDes = ErrorDes + "Invoice -  Please Enter Inward CRUEI : ";

                }
            }
            if (txtreLoctn.Text == "")
            {
                ErrorDes = ErrorDes + "Cargo -  Please Enter Release Location : ";

            }
            if (txtrecloctn.Text == "")
            {
                ErrorDes = ErrorDes + "Cargo -  Please Enter Receipt Location : ";

            }

            //gross outerpack

            if (TxtTotalGrossWeight.Text == "")
            {
                ErrorDes = ErrorDes + "Cargo -  Please Enter Total Gross Weight : ";
            }
            if (TxttotalOuterPack.Text == "")
            {
                ErrorDes = ErrorDes + "Cargo -  Please Enter Total Outer Pack Weight : ";
            }
            if (DrptotalOuterPack.SelectedItem.ToString() == "--Select--")
            {
                ErrorDes = ErrorDes + "Cargo -  Please select Outer Pack UOM : ";
            }

            if (DrpTotalGrossWeight.SelectedItem.ToString() == "--Select--")
            {
                ErrorDes = ErrorDes + "Cargo -  Please select Gross Weight UOM : ";
            }



            if (DrpDecType.SelectedItem.ToString() == "BKT : Blanket ")
            {
                if (TxtArrivalDate1.Text == "")
                {
                    ErrorDes = ErrorDes + "Item -  Please Enter Total Gross Weight : ";

                }

            }
            else
            {
                if (DrpInwardtrasMode.SelectedItem.ToString() == "--Select--")
                {
                    ErrorDes = ErrorDes + "Item -  Please Choose Inward Transport Mode : ";

                }

            }
            string TransMode = DrpCargoPackType.SelectedItem.ToString();
            if (DrpCargoPackType.SelectedItem.ToString() != "--Select--")
            {
                if (TransMode != "5 : Other non-Containerized")
                {

                    for (int r = 0; r < ContarinerGrid.Rows.Count; r++)
                    {
                        TextBox box1 = (TextBox)ContarinerGrid.Rows[r].FindControl("txt1");
                        DropDownList Drp1 = (DropDownList)ContarinerGrid.Rows[r].FindControl("DrpType");
                        TextBox box2 = (TextBox)ContarinerGrid.Rows[r].FindControl("txt2");
                        TextBox box3 = (TextBox)ContarinerGrid.Rows[r].FindControl("txt3");

                        if (box1.Text == "")
                        {
                            ErrorDes = ErrorDes + "Cargo -  Please Enter Container No : ";

                        }
                        if (Drp1.SelectedItem.ToString() == "--Select--")
                        {
                            ErrorDes = ErrorDes + "Cargo -  Please Choose Container Size / Type : ";

                        }
                        if (box2.Text == "")
                        {
                            ErrorDes = ErrorDes + "Cargo -  Please Enter Container Weight ( TNE ) : ";

                        }
                        if (box3.Text == "")
                        {
                            ErrorDes = ErrorDes + "Cargo - Please Enter Container  Seal No : ";

                        }

                    }



                }
            }


            string INTransMode = DrpInwardtrasMode.SelectedItem.ToString();
            if (DrpInwardtrasMode.SelectedItem.ToString() != "--Select--")
            {
                if (INTransMode == "1 : Sea")
                {
                    if (TextMode.Text != "N : Not Required")
                    {
                        if (TxtArrivalDate1.Text == "")
                        {
                            ErrorDes = ErrorDes + "Invoice -  Please Enter  Arrival Date :  ";

                        }
                        if (TxtLoadShort.Text == "")
                        {
                            ErrorDes = ErrorDes + "Invoice -  Please Enter  Loading Port : ";

                        }
                        if (TxtVoyageno.Text == "")
                        {
                            ErrorDes = ErrorDes + "Invoice -  Please Enter  Voyage Number :  ";

                        }
                        if (TxtVesselName.Text == "")
                        {
                            ErrorDes = ErrorDes + "Invoice -  Please Enter  Vessel Name : ";

                        }
                        if (TxtOceanBill.Text == "")
                        {
                            ErrorDes = ErrorDes + "Invoice -  Please Enter  Ocean Bill of Lading Number : ";

                        }

                        if (FrieghtCode.Text != "")
                        {
                            if (txthBlCargo.Text == "")
                            {
                                ErrorDes = ErrorDes + " -  Please Enter  HBL/HAWB Number : ";
                            }
                        }
                    }

                    TxtArrivalDate1.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    TxtLoadShort.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    TxtVoyageno.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    TxtVesselName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    txthBlCargo.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);

                    TxtOceanBill.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    txtcruei.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    txtName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    TxtImppartyCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    TxtImppartyName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                }
                else
                {
                    TxtArrivalDate1.BackColor = System.Drawing.Color.White;
                    TxtLoadShort.BackColor = System.Drawing.Color.White;
                    TxtVoyageno.BackColor = System.Drawing.Color.White;
                    TxtVesselName.BackColor = System.Drawing.Color.White;
                    txthBlCargo.BackColor = System.Drawing.Color.White;

                    TxtOceanBill.BackColor = System.Drawing.Color.White;
                    txtcruei.BackColor = System.Drawing.Color.White;
                    txtName.BackColor = System.Drawing.Color.White;
                    TxtImppartyCRUEI.BackColor = System.Drawing.Color.White;
                    TxtImppartyName.BackColor = System.Drawing.Color.White;


                }
                if (INTransMode == "2 : Rail" || INTransMode == "3 : Road" || INTransMode == "5 : Mail" || INTransMode == "7 : Pipeline" || INTransMode == "N : Not Required" || INTransMode == "6 : Multi-model(Not in use)")
                {
                    if (TextMode.Text != "N : Not Required")
                    {
                        if (TxtArrivalDate1.Text == "")
                        {
                            ErrorDes = ErrorDes + "Invoice -  Please Enter  Arrival Date :  ";

                        }
                        if (TxtLoadShort.Text == "")
                        {
                            ErrorDes = ErrorDes + "Invoice -  Please Enter  Loading Port : ";

                        }
                        if (FrieghtCode.Text != "")
                        {
                            if (txthBlCargo.Text == "")
                            {
                                ErrorDes = ErrorDes + " -  Please Enter  HBL/HAWB Number : ";
                            }
                        }
                    }
                    TxtArrivalDate1.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    TxtLoadShort.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    TxtConRefNo.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    TxtTrnsID.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    txthBlCargo.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);

                    txtcruei.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    txtName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    TxtImppartyCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    TxtImppartyName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                }
                else
                {
                    TxtArrivalDate1.BackColor = System.Drawing.Color.White;
                    TxtLoadShort.BackColor = System.Drawing.Color.White;
                    TxtConRefNo.BackColor = System.Drawing.Color.White;
                    TxtTrnsID.BackColor = System.Drawing.Color.White;
                    txthBlCargo.BackColor = System.Drawing.Color.White;

                    txtcruei.BackColor = System.Drawing.Color.White;
                    txtName.BackColor = System.Drawing.Color.White;
                    TxtImppartyCRUEI.BackColor = System.Drawing.Color.White;
                    TxtImppartyName.BackColor = System.Drawing.Color.White;
                }

                if (INTransMode == "4 : Air")
                {
                    if (TextMode.Text != "N : Not Required")
                    {
                        if (TxtArrivalDate1.Text == "")
                        {
                            ErrorDes = ErrorDes + "Invoice -  Please Enter  Arrival Date :  ";
                        }
                        if (TxtLoadShort.Text == "")
                        {
                            ErrorDes = ErrorDes + "Invoice -  Please Enter  Loading Port : ";
                        }
                        if (txtflight.Text == "")
                        {
                            ErrorDes = ErrorDes + "Invoice -  Please Enter  Flight No. :  ";
                        }
                        if (txtwaybill.Text == "")
                        {
                            ErrorDes = ErrorDes + "Invoice -  Please Enter Master Air Way Bill : ";

                        }
                        if (FrieghtCode.Text != "")
                        {
                            if (txthBlCargo.Text == "")
                            {
                                ErrorDes = ErrorDes + " -  Please Enter  HBL/HAWB Number : ";
                            }
                        }
                    }
                    TxtArrivalDate1.BackColor = System.Drawing.Color.CadetBlue;
                    TxtLoadShort.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    txtflight.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    // txtaircraft.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    txthBlCargo.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);

                    txtwaybill.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    txtcruei.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    txtName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    TxtImppartyCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    TxtImppartyName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);

                }
                else
                {
                    TxtArrivalDate1.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    TxtLoadShort.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    txtflight.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    // txtaircraft.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    txthBlCargo.BackColor = System.Drawing.Color.White;

                    txtwaybill.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    txtcruei.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    txtName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    TxtImppartyCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    TxtImppartyName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                }
            }
            TxtTradeMailID.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            TxtDecName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            TxtDecCode.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            TxtDecTelephone.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            TxtCRUEINO.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            DrpDecType.BackColor = System.Drawing.Color.BlueViolet;
            DrpCargoPackType.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            TxtImpCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            TxtImpName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            if (TextMode.Text == "1 : Sea" || TextMode.Text == "4 : Air")
            {
                InwardName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                InwardCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            }
            else
            {
                InwardName.BackColor = System.Drawing.Color.White;
                InwardCRUEI.BackColor = System.Drawing.Color.White;
            }

            TxtDecCompCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            TxtDecCompName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            txtreLoctn.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            txtrecloctn.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            // txtinvNo.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            // txtinvDate1.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            txtcruei.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            txtName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            Drpcurrency1.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            TxtHSCodeItem.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            TxtDescription.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            TxtCountryItem.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            TxtBrand.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            TxtHSQuantity.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            HSQTYUOM.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            DRPCurrency.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            TxtTotalLineAmount.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            TxttotalOuterPack.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            DrptotalOuterPack.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            TxtTotalGrossWeight.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            DrpTotalGrossWeight.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            if (DrpDecType.SelectedItem.ToString() == "BKT : Blanket ")
            {
                TxtArrivalDate1.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            }
            else
            {
                DrpInwardtrasMode.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            }

            string TransMode1 = DrpCargoPackType.SelectedItem.ToString();
            if (DrpCargoPackType.SelectedItem.ToString() != "--Select--")
            {
                if (TransMode1 != "5 : Other non-Containerized")
                {

                    for (int r = 0; r < ContarinerGrid.Rows.Count; r++)
                    {
                        TextBox box1 = (TextBox)ContarinerGrid.Rows[r].FindControl("txt1");
                        DropDownList Drp1 = (DropDownList)ContarinerGrid.Rows[r].FindControl("DrpType");
                        TextBox box2 = (TextBox)ContarinerGrid.Rows[r].FindControl("txt2");
                        TextBox box3 = (TextBox)ContarinerGrid.Rows[r].FindControl("txt3");

                        box1.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                        Drp1.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                        box2.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                        box3.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    }
                }
            }
            InvoiceReq();
            ItemReq();


           

            string[] test = null;
            GridError.DataSource = null;
            GridError.DataBind();
            if (!string.IsNullOrWhiteSpace(ErrorDes))
            {
                test = Regex.Split(ErrorDes, ":");
            }
            if (test != null)
            {
                foreach (string s in test)
                {
                    GridError.DataSource = test;
                    GridError.DataBind();
                    GridError.Visible = true;
                }
            }
            else
            {
                GridError.Visible = false;
            }
            updatepanel1.Update();
        }

        public void InvoiceReq()
        {

            int InvoiceCount = AddInvoiceGrid.Rows.Count;

            if (InvoiceCount <= 0)
            {
                ErrorDes = ErrorDes + "Invoice -  Please Enter Invoice : ";
            }



        }
        public void ItemReq()
        {

            int ItenCount = AddItemGrid.Rows.Count;

            if (ItenCount <= 0)
            {
                ErrorDes = ErrorDes + "Item -  Please Enter Item : ";
            }



        }

        //Autocomplete

        //Declarant Company

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetListofCountries(string prefixText, string DecAccountID)
        {
            //DecAccountID = TxtDecCode.Text;
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select top 5 Code,Name from  DeclarantCompany where AccountID='" + DecAccountID + "' and  Code like '" + prefixText.Replace("'", "''") + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@Name", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet dsde = new DataSet();
                //taTable dt = new DataTable();
                da.Fill(dsde);
                List<string> Deccode1 = new List<string>();
                List<string> DecName = new List<string>();
                List<string> Deccode = new List<string>();
                // string ss1;
                for (int i = 0; i < dsde.Tables[0].Rows.Count; i++)
                {
                    Deccode.Add(dsde.Tables[0].Rows[i]["Code"].ToString() + ":" + dsde.Tables[0].Rows[i]["Name"].ToString());
                    Deccode1.Add(dsde.Tables[0].Rows[i]["Code"].ToString());
                }
                return Deccode;
            }
        }

        //ImportCode

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetImpcode(string prefixText)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select Top 5 Code,Name from  Importer where Code like '" + prefixText.Replace("'", "''") + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@Code", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet dsimp = new DataSet();
                //DataTable dt = new DataTable();
                da.Fill(dsimp);
                List<string> Deccode1 = new List<string>();
                List<string> DecName = new List<string>();
                List<string> Deccode = new List<string>();

                for (int i = 0; i < dsimp.Tables[0].Rows.Count; i++)
                {
                    Deccode.Add(dsimp.Tables[0].Rows[i]["Code"].ToString() + ":" + dsimp.Tables[0].Rows[i]["Name"].ToString());
                    Deccode1.Add(dsimp.Tables[0].Rows[i]["Code"].ToString());
                }
                return Deccode;
            }
        }

        //Inward Code

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetInwcode(string prefixText)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select Top 5 Code,Name from  InwardCarrierAgent where Code like '" + prefixText.Replace("'","''") + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@Name", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet dsinw = new DataSet();
                //DataTable dt = new DataTable();
                da.Fill(dsinw);

                List<string> Deccode = new List<string>();

                for (int i = 0; i < dsinw.Tables[0].Rows.Count; i++)
                {
                    Deccode.Add(dsinw.Tables[0].Rows[i]["Code"].ToString() + ":" + dsinw.Tables[0].Rows[i]["Name"].ToString());
                }
                return Deccode;
            }
        }


        //freightcode

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetFrieght(string prefixText)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select Top 5 Code,Name from  FreightForwarder where Code like '" + prefixText.Replace("'", "''") + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@Name", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet dsfrg = new DataSet();
                //DataTable dt = new DataTable();
                da.Fill(dsfrg);

                List<string> Deccode = new List<string>();

                for (int i = 0; i < dsfrg.Tables[0].Rows.Count; i++)
                {
                    Deccode.Add(dsfrg.Tables[0].Rows[i]["Code"].ToString() + ":" + dsfrg.Tables[0].Rows[i]["Name"].ToString());
                    // string con = String.Concat(Deccode, DecName);
                }
                return Deccode;
            }
        }


        //Claimanity
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetClaimanity(string prefixText)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select Top 5 Name,Name1 from  ClaimantParty where Name like '" + prefixText.Replace("'", "''") + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@Name", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet dsclm = new DataSet();
                //DataTable dt = new DataTable();
                da.Fill(dsclm);

                List<string> Deccode = new List<string>();

                for (int i = 0; i < dsclm.Tables[0].Rows.Count; i++)
                {
                    Deccode.Add(dsclm.Tables[0].Rows[i]["Name"].ToString() + ":" + dsclm.Tables[0].Rows[i]["Name1"].ToString());
                }
                return Deccode;
            }
        }


        //Loading Short

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetLodcode(string prefixText)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select Top 10 PortCode,PortName from  LoadingPort where PortCode like '" + prefixText.Replace("'", "''") + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@PortCode", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet dslp = new DataSet();
                //DataTable dt = new DataTable();
                da.Fill(dslp);

                List<string> Deccode = new List<string>();

                for (int i = 0; i < dslp.Tables[0].Rows.Count; i++)
                {
                    Deccode.Add(dslp.Tables[0].Rows[i]["PortCode"].ToString() + ":" + dslp.Tables[0].Rows[i]["PortName"].ToString());
                }
                return Deccode;
            }
        }

        // Get Release Location
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> Getrelloc(string prefixText)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select Top 10 Code,Description from  ReleaseLocation where Code like '" + prefixText.Replace("'", "''") + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@Description", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet dsrlp = new DataSet();
                //DataTable dt = new DataTable();
                da.Fill(dsrlp);

                List<string> Deccode = new List<string>();

                for (int i = 0; i < dsrlp.Tables[0].Rows.Count; i++)
                {
                    Deccode.Add(dsrlp.Tables[0].Rows[i]["Code"].ToString() + ":" + dsrlp.Tables[0].Rows[i]["Description"].ToString());
                }
                return Deccode;
            }
        }


        // Get Receipt Location
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetRecLoc(string prefixText)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select Top 10 Code,Description from  ReceiptLocation where Code like '" + prefixText.Replace("'", "''") + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@Description", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet dsrecl = new DataSet();
                //DataTable dt = new DataTable();
                da.Fill(dsrecl);

                List<string> Deccode = new List<string>();

                for (int i = 0; i < dsrecl.Tables[0].Rows.Count; i++)
                {
                    Deccode.Add(dsrecl.Tables[0].Rows[i]["Code"].ToString() + ":" + dsrecl.Tables[0].Rows[i]["Description"].ToString());
                }
                return Deccode;
            }
        }


        // Get Suplier Party Code

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> Getsupcode(string prefixText)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select Top 5 Code,Name from  SUPPLIERMANUFACTURERPARTY where Code like '" + prefixText.Replace("'", "''") + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@Name", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet dssup = new DataSet();
                //DataTable dt = new DataTable();
                da.Fill(dssup);
                List<string> Deccode = new List<string>();
                for (int i = 0; i < dssup.Tables[0].Rows.Count; i++)
                {
                    Deccode.Add(dssup.Tables[0].Rows[i]["Code"].ToString() + ":" + dssup.Tables[0].Rows[i]["Name"].ToString());
                }
                return Deccode;
            }
        }




        // Get Importer Party Code

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetImppartycode(string prefixText)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select Top 5 Code,Name from  Importer where Code like '" + prefixText.Replace("'", "''") + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@Name", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet dsimp = new DataSet();
                //DataTable dt = new DataTable();
                da.Fill(dsimp);

                List<string> Deccode = new List<string>();

                for (int i = 0; i < dsimp.Tables[0].Rows.Count; i++)
                {
                    Deccode.Add(dsimp.Tables[0].Rows[i]["Code"].ToString() + ":" + dsimp.Tables[0].Rows[i]["Name"].ToString());
                }
                return Deccode;
            }
        }




        // Get InHouse Code

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetInhouse(string prefixText)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select Top 5 InhouseCode from  InhouseItemCode where InhouseCode like '" + prefixText.Replace("'", "''") + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@InhouseCode", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet dsinh = new DataSet();
                //DataTable dt = new DataTable();
                da.Fill(dsinh);

                List<string> Deccode = new List<string>();

                for (int i = 0; i < dsinh.Tables[0].Rows.Count; i++)
                {
                    Deccode.Add(dsinh.Tables[0].Rows[i]["InhouseCode"].ToString());
                }
                return Deccode;
            }
        }


        // Get HS Code

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetHSCodeItem(string prefixText)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select DISTINCT Top 8 HSCode,Description, is_inpayment_controlled from HSCode where HSCode like '" + prefixText.Replace("'", "''") + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@HSCode", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet dshsc = new DataSet();
                //DataTable dt = new DataTable();
                da.Fill(dshsc);

                List<string> Deccode = new List<string>();

                for (int i = 0; i < dshsc.Tables[0].Rows.Count; i++)
                {
                    Deccode.Add(dshsc.Tables[0].Rows[i]["HSCode"].ToString() + ":" + dshsc.Tables[0].Rows[i]["Description"].ToString() + ":" + dshsc.Tables[0].Rows[i]["is_inpayment_controlled"].ToString());
            }
                return Deccode;
            }
        }


        //Country Of Orgin

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetCountryItem(string prefixText)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select Top 5 CountryCode,Description  from  Country where CountryCode like '" + prefixText.Replace("'", "''") + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@Description", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet dscun = new DataSet();
                //DataTable dt = new DataTable();
                da.Fill(dscun);

                List<string> Deccode = new List<string>();

                for (int i = 0; i < dscun.Tables[0].Rows.Count; i++)
                {
                    Deccode.Add(dscun.Tables[0].Rows[i]["CountryCode"].ToString() + ":" + dscun.Tables[0].Rows[i]["Description"].ToString());
                    // string con = String.Concat(Deccode, DecName);
                }
                return Deccode;
            }
        }

        void ContarinerGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.TableSection = TableRowSection.TableHeader;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //if (string.IsNullOrWhiteSpace(chkdel))
                //{
                DropDownList DrpType = (DropDownList)e.Row.FindControl("DrpType");

                string str11 = "select *  from CommonMaster where TypeId=6 and StatusId=1 order by Name";
                obj.dr = obj.ret_dr(str11);
                obj.BindDropDown(DrpType, obj.dr, "Id", "Name");
                //chkdel = "";
                //}

            }

        }

        private void MSGNO()
        {
            string justdate = DateTime.Now.ToString("yyyyMMdd");
            string MSGCount = "";
            string qry11 = "SELECT COUNT(PermitId) as MsgID  from PermitCount where AccountId='" + Session["AccountId"].ToString() + "' and TouchTime ='" + justdate + "' ";
            obj.dr = obj.ret_dr(qry11);
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
        }

        private void refid()
        {
            string Touch_user = Session["UserId"].ToString();
            string justdate = DateTime.Now.ToString("yyyyMMdd");
            con.Open();
            SqlCommand command1 = new SqlCommand("SELECT Max(Refid) from InHeaderTbl where MessageType='IPTDEC'  and  LEFT(MSGId,8) ='" + justdate + "'");
            command1.Connection = con;
            string max_po_no = command1.ExecuteScalar().ToString();
            int m_po_no = 0;

            int endTagStartPosition = max_po_no.LastIndexOf("/");
            max_po_no = max_po_no.Substring(endTagStartPosition + 1);
            if (max_po_no != "")
            {
                m_po_no = Convert.ToInt32(max_po_no);
            }
            else
            {
                m_po_no = 0;
            }
            if (max_po_no != "0")
            {
                m_po_no = m_po_no + 1;

            }
            string code = Touch_user + String.Format("{0:000}", m_po_no);
            con.Close();
            refno = m_po_no.ToString();
        }

        private void PermitNO()
        {
            string justdate = DateTime.Now.ToString("yyyyMMdd");
            string Touch_user = Session["UserId"].ToString();
            con.Open();
            SqlCommand command1 = new SqlCommand("SELECT Max(Refid) from InHeaderTbl where MessageType='IPTDEC' and  LEFT(MSGId,8) ='" + justdate + "'");
            command1.Connection = con;
            string max_po_no = command1.ExecuteScalar().ToString();
            int m_po_no = 0;

            int endTagStartPosition = max_po_no.LastIndexOf("/");
            max_po_no = max_po_no.Substring(endTagStartPosition + 1);
            if (max_po_no != "")
            {
                m_po_no = Convert.ToInt32(max_po_no);
            }
            else
            {
                m_po_no = 0;
            }
            if (max_po_no != "0")
            {
                m_po_no = m_po_no + 1;

            }
            string code = Touch_user + justdate + String.Format("{0:000}", m_po_no);
            con.Close();
            txt_code.Text = code;
        }
        private void JobNO()
        {

            string justdate = DateTime.Now.ToString("yyyyMMdd");

            string JobCount = "";
            string qry11 = "SELECT COUNT(PermitId) as JobId  from PermitCount where  AccountId='" + Session["AccountId"].ToString() + "' and TouchTime ='" + justdate + "' ";
            obj.dr = obj.ret_dr(qry11);
            while (obj.dr.Read())
            {
                JobCount = obj.dr["JobId"].ToString();
                int count = Convert.ToInt32(JobCount) + 1;
                string Date = DateTime.Now.ToString("yyMMdd");
                string code = "K" + Date + String.Format("{0:00000}", count);

                JobNo = code;

            }
            if (JobCount == "0")
            {
                string Date = DateTime.Now.ToString("yyyyMMdd");
                // string code = "K" + Date + String.Format("{0:00000}");
                JobNo = "K" + Date + "00001";
            }
        }

        private void InvoiceNo()
        {
            int i = 0;
            con.Open();
            SqlCommand command1q = new SqlCommand("SELECT Max(SNo) from [InvoiceDtl] where MessageType='IPTDEC'  and PermitId='" + txt_code.Text + "'  ");
            command1q.Connection = con;
            string max_po_no = command1q.ExecuteScalar().ToString();
            // int m_po_noq = 0;

            //int endTagStartPositionq = max_po_noq.LastIndexOf("/");
            //max_po_noq = max_po_noq.Substring(endTagStartPositionq + 1);
            //if (max_po_noq != "")
            //{
            //    m_po_noq = Convert.ToInt32(max_po_noq);
            //}
            //else
            //{
            //    m_po_noq = 0;
            //}
            //if (max_po_noq != "0")
            //{
            //    m_po_noq = m_po_noq + 1;

            //}
            // int n = Convert.ToInt32(max_po_noq);
            // int m = n + 1;

            if (!string.IsNullOrWhiteSpace(max_po_no))
            {
                i = Convert.ToInt32(max_po_no);
            }
            i = i + 1;
            // refno = i.ToString();


            string codeq = " " + String.Format("{0:000}", i);
            con.Close();
            txtserial.Text = codeq;
        }





        private void ItemNO()
        {
            int i = 0;
            con.Open();
            SqlCommand command1113 = new SqlCommand("SELECT max(ItemNo) from [ItemDtl] where MessageType='IPTDEC'  and PermitId='" + txt_code.Text + "'  ");
            command1113.Connection = con;
            string max_po_no3 = command1113.ExecuteScalar().ToString();

            //int endTagStartPosition3 = max_po_no3.LastIndexOf("/");
            //max_po_no3 = max_po_no3.Substring(endTagStartPosition3 + 1);
            //if (max_po_no3 != "")
            //{
            //    m_po_no3 = Convert.ToInt32(max_po_no3);
            //}
            //else
            //{
            //    m_po_no3 = 0;
            //}
            //if (max_po_no3 != "0")
            //{
            //    m_po_no3 = m_po_no3 + 1;

            //}

            if (!string.IsNullOrWhiteSpace(max_po_no3))
            {
                i = Convert.ToInt32(max_po_no3);
            }
            i = i + 1;

            string code3 = " " + String.Format("{0:000}", i);
            con.Close();
            TxtSerialNo.Text = code3;


        }
        private void BindGrid()
        {
            const int maxTotalSizeKB = 20000;
            long totalKB = 0;

            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT Id, DocumentType, Name, FileSizeKB FROM InFile WHERE InPaymentId = @InPaymentId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@InPaymentId", MsgNO);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        // Calculate total size
                        foreach (DataRow row in dt.Rows)
                        {
                            totalKB += Convert.ToInt64(row["FileSizeKB"]);
                        }

                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }

            // Update total size display
            lblTotalSize.Text = $"{totalKB}KB / {maxTotalSizeKB}KB";
            lblTotalSize.ForeColor = totalKB > maxTotalSizeKB ? System.Drawing.Color.Red : System.Drawing.Color.Black;

            // SAFE FOOTER UPDATE: Only update if footer exists
            if (GridView1.Rows.Count > 0)
            {
                int columnIndex = 3; // File size column index
                GridView1.FooterRow.Cells[columnIndex].Text = $"Total: {totalKB}KB";
                GridView1.FooterRow.Cells[columnIndex].ForeColor = totalKB > maxTotalSizeKB ?
                    System.Drawing.Color.Red : System.Drawing.Color.Black;
                GridView1.FooterRow.Cells[columnIndex].Font.Bold = true;
            }
        }

        private void BindGridCancel()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id,DocumentType,Name FROM InCancelFile where InPaymentId='" + txt_code.Text + "' "))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet dt = new DataSet())
                        {
                            sda.Fill(dt);
                            GridCancelDoc.DataSource = dt.Tables[0];
                            GridCancelDoc.DataBind();
                        }
                    }
                }
            }
        }
        private void BindGridRefund()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id,DocumentType,Name FROM InRefundFile where InPaymentId='" + txt_code.Text + "' "))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet dt = new DataSet())
                        {
                            sda.Fill(dt);
                            GridRefundDoc.DataSource = dt.Tables[0];
                            GridRefundDoc.DataBind();
                        }
                    }
                }
            }
        }
        protected void ChkRefDoc_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkRefDoc.Checked == true)
            {
                Document.Visible = true;
            }
            else
            {
                Document.Visible = false;
            }
            TxtLicense1.Focus();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();

            string strDelete = "delete from InFile where Id='" + id + "' ";
            obj.exec(strDelete);
            BindGrid();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid();
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
                if (con.State == ConnectionState.Closed || con.State == ConnectionState.Broken)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM InFile where ID=" + employeeId, con);
                result = cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                DrpDocType.ClearSelection();
                DrpDocType.Items.FindByText("--Select--").Selected = true;
            }
            if (result == 1)
            {
                BindGrid();
            }

        }


        //Party

        //Party Declaration company
        private void decBindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Top 1 Id,Code,Name,Name1,CRUEI FROM DeclarantCompany where AccountID='" + Session["AccountId"].ToString() + "' "))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet dt = new DataSet())
                        {
                            sda.Fill(dt);
                            DECCOMPSearGRID.DataSource = dt.Tables[0];
                            DECCOMPSearGRID.DataBind();
                        }
                    }
                }
            }
        }

        protected void DECCOMPSearGRID_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DECCOMPSearGRID.PageIndex = e.NewPageIndex;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "DECLARANTCOMPANY();", true);
            decBindGrid();
            mpe.Show();
        }


        protected void lnkRequestID_Command(object sender, CommandEventArgs e)
        {
            //  ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "DECLARANTCOMPANY();", false);
            var lb = (LinkButton)sender;
            var row = (GridViewRow)lb.NamingContainer;
            if (row != null)
            {
                var lblCode1 = row.FindControl("lblCode") as Label;
                var lblName1 = row.FindControl("lblName") as Label;
                var lblName11 = row.FindControl("lblName1") as Label;
                var cruei1 = row.FindControl("lblCRUEI") as Label;

                if (lblCode1 != null && lblName1 != null && lblName11 != null && cruei1 != null)
                {

                    //UpdatePanelDCS.Update();
                    //Get values
                    string requestor = lblCode1.Text;
                    string requestType = lblName1.Text;
                    string status = lblName11.Text;
                    string crueis = cruei1.Text;
                    TxtDecCompCode.Text = "";
                    TxtDecCompName.Text = "";
                    TxtDecCompName1.Text = "";
                    TxtDecCompCRUEI.Text = "";
                    TxtDecCompCode.Text = requestor;
                    TxtDecCompName.Text = requestType;
                    TxtDecCompName1.Text = status;
                    TxtDecCompCRUEI.Text = crueis;


                }
                // DECCOMPSearGRID.Visible = false;

            }


            TxtImpCode.Focus();
        }

        public DataTable GetDataFromDataBase(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = DecSearch.Text;

            string str3 = "SELECT Id,Code,Name,Name1,CRUEI FROM DeclarantCompany where Code Like '%" + DecSearch.Text.Replace("'","''") + "%' or Name Like '%" + DecSearch.Text.Replace("'", "''") + "%' order by Id desc";
            obj.dr = obj.ret_dr(str3);
            if (obj.dr.HasRows)
            {
                DECCOMPSearGRID.DataSource = obj.dr;

            }
            else
            {
                //Empty DataTable to execute the “else-condition”  
                DataTable dt = new DataTable();
                DECCOMPSearGRID.DataSource = dt;
                DECCOMPSearGRID.DataBind();
            }
            SqlConnection con = new SqlConnection(sqlconn);
            SqlDataAdapter _objda = new SqlDataAdapter(str3, con);
            con.Close();
            _objda.Fill(_objdt);
            return _objdt;
        }

        public DataTable GetSupplyDataFromDataBase(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = SUPPLIERSearch.Text;

            string str3 = "SELECT Id,Code,Name,Name1,CRUEI FROM SUPPLIERMANUFACTURERPARTY where Code Like '%" + SUPPLIERSearch.Text.Replace("'", "''") + "%' or Name Like '%" + SUPPLIERSearch.Text.Replace("'", "''") + "%' order by Id desc";
            obj.dr = obj.ret_dr(str3);
            if (obj.dr.HasRows)
            {
                SUPPLIERGrid.DataSource = obj.dr;

            }
            else
            {
                //Empty DataTable to execute the “else-condition”  
                DataTable dt = new DataTable();
                SUPPLIERGrid.DataSource = dt;
                SUPPLIERGrid.DataBind();
            }
            SqlConnection con = new SqlConnection(sqlconn);
            SqlDataAdapter _objda = new SqlDataAdapter(str3, con);
            con.Close();
            _objda.Fill(_objdt);
            return _objdt;
        }

        protected void DecSearch_TextChanged(object sender, EventArgs e)
        {

            DataTable _objdt = new DataTable();
            _objdt = GetDataFromDataBase(DecSearch.Text);
            if (_objdt.Rows.Count > 0)
            {
                DECCOMPSearGRID.DataSource = _objdt;
                DECCOMPSearGRID.DataBind();
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "DECLARANTCOMPANY();", true);
            }

        }

        protected void TxtDecCompCode_TextChanged(object sender, EventArgs e)
        {

            if (TxtDecCompCode.Text != "")
            {
                string[] ss = TxtDecCompCode.Text.Split(':');

                string qry11 = "select * from DeclarantCompany where Code='" + ss[0].ToString() + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    // Id,Code,Name,Name1,CRUEI

                    TxtDecCompCode.Text = obj.dr["Code"].ToString();
                    TxtDecCompName.Text = obj.dr["Name"].ToString();
                    TxtDecCompName1.Text = obj.dr["Name1"].ToString();
                    TxtDecCompCRUEI.Text = obj.dr["CRUEI"].ToString();

                }
            }
            else
            {
                TxtDecCompCode.Text = "";
                TxtDecCompName.Text = "";
                TxtDecCompName1.Text = "";
                TxtDecCompCRUEI.Text = "";
            }
            TxtImpCode.Focus();

        }
        protected void DECPLUS_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtDecCompCode.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Declarant Company Code Already Exist...');", true);
            }
            else
            {
                string Code = "";
                string qry11 = "SELECT Code FROM DeclarantCompany where Code='" + TxtDecCompCode.Text.Replace("'", "''") + "'";

                obj.dr = obj.ret_dr(qry11);

                while (obj.dr.Read())
                {
                    Code = obj.dr[0].ToString();

                }
                if (Code == "")
                {
                    string Touch_user = Session["UserId"].ToString();

                    string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string StrQuery = ("UPDATE [dbo].[DeclarantCompany] SET [Code] ='" + TxtDecCompCode.Text.Replace("'","''") + "' WHERE Name='" + TxtDecCompName.Text + "' ");
                    obj.exec(StrQuery);
                    decBindGrid();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The DeclarantCompany Code Already Exist...');", true);
                    // Response.Write("The DeclarantCompany Code Already Exist..");
                }

                TxtImpCode.Focus();
            }


        }

        //Importer Code
        private void BindImport()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Top 20 Id,Code,Name,Name1,CRUEI FROM Importer"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet dt = new DataSet())
                        {
                            sda.Fill(dt);
                            ImporterGrid.DataSource = dt;
                            ImporterGrid.DataBind();
                            // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalImport();", true);

                        }
                    }
                }
            }
        }
        protected void ImporterSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable _objdt = new DataTable();
            _objdt = GetImportDataFromDataBase(ImporterSearch.Text);
            if (_objdt.Rows.Count > 0)
            {
                ImporterGrid.DataSource = _objdt;
                ImporterGrid.DataBind();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalImport();", true);
            }



        }

        protected void ImporterGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ImporterGrid.PageIndex = e.NewPageIndex;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalImport();", true);
            BindImport();
            popupimp.Show();
        }

        protected void BtnImpADD_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtImpCode.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Importer Code Is Empty');", true);
            }
            else if (string.IsNullOrWhiteSpace(TxtImpCRUEI.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Importer UEI Is Empty');", true);
            }
            else if (string.IsNullOrWhiteSpace(TxtImpName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Importer Name Is Empty');", true);
            }
            else
            {
                string Code = "";
                string qry11 = "SELECT Code FROM Importer where Code='" + TxtImpCode.Text.Replace("'", "''") + "'";

                obj.dr = obj.ret_dr(qry11);

                while (obj.dr.Read())
                {
                    Code = obj.dr[0].ToString();

                }
                if (Code == "")
                {
                    string Touch_user = Session["UserId"].ToString();

                    string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string StrQuery = ("INSERT INTO [dbo].[Importer] ([Code],[Name],[Name1],[CRUEI],[TouchUser],[TouchTime]) VALUES ('" + TxtImpCode.Text.Replace("'","''") + "','" + TxtImpName.Text.Replace("'", "''") + "','" + TxtImpName1.Text.Replace("'", "''") + "','" + TxtImpCRUEI.Text.Replace("'", "''") + "','" + Touch_user + "',Convert(VARCHAR,'" + strTime + "',108))");
                    obj.exec(StrQuery);
                    BindImport();

                    TxtImpCode_TextChanged(null,null);

                    //TxtImppartyCode.Text = TxtImpCode.Text.Replace("'", "''");
                    //TxtImppartyCRUEI.Text = TxtImpCRUEI.Text.Replace("'", "''");
                    //TxtImppartyName.Text = TxtImpName.Text.Replace("'", "''");
                    //TxtImppartyName1.Text = TxtImpName1.Text.Replace("'", "''");



                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : Data Saved Successfully');", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Importer Code Already Exist..');", true);
                    //  Response.Write("The Importer Code Already Exist..");
                }

                InwardCode.Focus();
            }

        }

        protected void LnkImport_Command(object sender, CommandEventArgs e)
        {
            var lb = (LinkButton)sender;
            var row = (GridViewRow)lb.NamingContainer;
            if (row != null)
            {
                var lblCode1 = row.FindControl("lblCode") as Label;
                var lblName1 = row.FindControl("lblName") as Label;
                var lblName11 = row.FindControl("lblName1") as Label;
                var cruei1 = row.FindControl("lblCRUEI") as Label;

                if (lblCode1 != null && lblName1 != null && lblName11 != null && cruei1 != null)
                {
                    //Get values
                    string requestor = lblCode1.Text;
                    string requestType = lblName1.Text;
                    string status = lblName11.Text;
                    string crueis = cruei1.Text;


                    TxtImpCode.Text = "";
                    TxtImpName.Text = "";
                    TxtImpName1.Text = "";
                    TxtImpCRUEI.Text = "";
                    TxtImpCode.Text = requestor;
                    TxtImpName.Text = requestType;
                    TxtImpName1.Text = status;
                    TxtImpCRUEI.Text = crueis;

                }

            }
            InwardCode.Focus();
        }
        public DataTable GetImportDataFromDataBase(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = ImporterSearch.Text;

            string str3 = "SELECT Id,Code,Name,Name1,CRUEI FROM Importer where Code Like '%" + ImporterSearch.Text.Replace("'", "''") + "%' or Name Like '%" + ImporterSearch.Text.Replace("'", "''") + "%' order by Id desc";
            obj.dr = obj.ret_dr(str3);
            if (obj.dr.HasRows)
            {
                ImporterGrid.DataSource = obj.dr;

            }
            else
            {
                //Empty DataTable to execute the “else-condition”  
                DataTable dt = new DataTable();
                ImporterGrid.DataSource = dt;
                ImporterGrid.DataBind();
            }
            SqlConnection con = new SqlConnection(sqlconn);
            SqlDataAdapter _objda = new SqlDataAdapter(str3, con);
            con.Close();
            _objda.Fill(_objdt);
            return _objdt;
        }

        protected void TxtImpCode_TextChanged(object sender, EventArgs e)
        {
            if (TxtImpCode.Text != "")
            {
                string[] ss = TxtImpCode.Text.Split(':');
                string qry11 = "select Top 1 Code,Name,Name1,CRUEI from Importer where Code='" + ss[0].ToString().Replace("'", "''") + "'";
                obj.dr = obj.ret_dr(qry11);
                if (obj.dr.Read())
                {
                    TxtImpCode.Text = obj.dr["Code"].ToString();
                    TxtImpName.Text = obj.dr["Name"].ToString();
                    //Lblmarquee
                    if (TxtImpName.Text == "SC IMPORT & EXPORT LTD")
                    {
                        Lblmarquee.Text = "FOR THIS PART NUMBER SQB0856YY04 MUST USE COUNTRY OF ORIGIN France (FR). ";
                        updatepanel1.Update();
                    }
                    else
                    {
                        Lblmarquee.Text = "";
                        updatepanel1.Update();
                    }

                    TxtImpName1.Text = obj.dr["Name1"].ToString();
                    TxtImpCRUEI.Text = obj.dr["CRUEI"].ToString();
                    lblimporterparty.Text = obj.dr["CRUEI"].ToString() + " - " + obj.dr["Name"].ToString() + " " + obj.dr["Name1"].ToString();

                    //IMPORTER PARTY


                    TxtImppartyCode.Text = obj.dr["Code"].ToString();
                    TxtImppartyCRUEI.Text = obj.dr["CRUEI"].ToString();
                    TxtImppartyName.Text = obj.dr["Name"].ToString();
                    TxtImppartyName1.Text = obj.dr["Name1"].ToString();



                }
            }
            else
            {
                TxtImpCode.Text = "";
                TxtImpName.Text = "";
                TxtImpName1.Text = "";
                TxtImpCRUEI.Text = "";
            }
            InwardCode.Focus();

        }
        //Inward Code
        //Inward 

        private void BindInward()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Top 20 Id,Code,Name,Name1,CRUEI FROM InwardCarrierAgent"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet dt = new DataSet())
                        {
                            sda.Fill(dt);
                            InwardGrid.DataSource = dt;
                            InwardGrid.DataBind();
                        }
                    }
                }
            }
        }

        protected void InwardSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable _objdt = new DataTable();
            _objdt = GetInwardDataFromDataBase(InwardSearch.Text);
            if (_objdt.Rows.Count > 0)
            {
                InwardGrid.DataSource = _objdt;
                InwardGrid.DataBind();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalInward();", true);
            }


            //DataTable _objdt = new DataTable();
            //_objdt = GetInwardDataFromDataBase(InwardSearch.Text);
            //if (_objdt.Rows.Count > 0)
            //{
            //    InwardGrid.DataSource = _objdt;
            //    InwardGrid.DataBind();
            //    // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalInward();", true);
            //}
        }

        protected void InwardGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
           
            InwardGrid.PageIndex = e.NewPageIndex;
            
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalInward();", true);
            BindInward();
            popupinw.Show();
          
        }

        protected void LmkInward_Command(object sender, CommandEventArgs e)
        {
            var lb = (LinkButton)sender;
            var row = (GridViewRow)lb.NamingContainer;
            if (row != null)
            {
                var lblCode1 = row.FindControl("lblCode") as Label;
                var lblName1 = row.FindControl("lblName") as Label;
                var lblName11 = row.FindControl("lblName1") as Label;
                var cruei1 = row.FindControl("lblCRUEI") as Label;

                if (lblCode1 != null && lblName1 != null && lblName11 != null && cruei1 != null)
                {
                    //Get values
                    string requestor = lblCode1.Text;
                    string requestType = lblName1.Text;
                    string status = lblName11.Text;
                    string crueis = cruei1.Text;


                    InwardCode.Text = "";
                    InwardName.Text = "";
                    InwardName1.Text = "";
                    InwardCRUEI.Text = "";
                    InwardCode.Text = requestor;
                    InwardName.Text = requestType;
                    InwardName1.Text = status;
                    InwardCRUEI.Text = crueis;

                }

            }
            FrieghtCode.Focus();
        }

        protected void InwardAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(InwardCode.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Inward Carrier Agent Code Is Empty');", true);
            }
            else if (string.IsNullOrWhiteSpace(InwardCRUEI.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Inward Carrier Agent UEI Is Empty');", true);
            }
            else if (string.IsNullOrWhiteSpace(InwardName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Inward Carrier Agent Name Is Empty');", true);
            }
            else
            {
                string Code = "";
                string qry11 = "SELECT Code FROM InwardCarrierAgent where Code='" + InwardCode.Text.Replace("'","''") + "'";

                obj.dr = obj.ret_dr(qry11);

                while (obj.dr.Read())
                {
                    Code = obj.dr[0].ToString();

                }
                if (Code == "")
                {
                    string Touch_user = Session["UserId"].ToString();

                    string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string StrQuery = ("INSERT INTO [dbo].[InwardCarrierAgent] ([Code],[Name],[Name1],[CRUEI],[TouchUser],[TouchTime]) VALUES ('" + InwardCode.Text.Replace("'", "''") + "','" + InwardName.Text.Replace("'", "''") + "','" + InwardName1.Text.Replace("'", "''") + "','" + InwardCRUEI.Text.Replace("'", "''") + "','" + Touch_user + "',Convert(VARCHAR,'" + strTime + "',108))");
                    obj.exec(StrQuery);
                    BindInward();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : Data Saved Successfully');", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Inward Code Already Exist...');", true);
                    //Response.Write("The Inward Code Already Exist..");
                }

                FrieghtCode.Focus();
            }

        }

        public DataTable GetInwardDataFromDataBase(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = InwardSearch.Text;
            string str3 = "SELECT Id,Code,Name,Name1,CRUEI FROM InwardCarrierAgent where Code Like '%" + ImporterSearch.Text.Replace("'", "''") + "%' or Name Like '%" + ImporterSearch.Text.Replace("'", "''") + "%' order by Id desc";

            //string str3 = "SELECT Id,Code,Name,Name1,CRUEI FROM InwardCarrierAgent where Code Like '%" + InwardSearch.Text + "%' order by Id desc";
            obj.dr = obj.ret_dr(str3);
            if (obj.dr.HasRows)
            {
                InwardGrid.DataSource = obj.dr;

            }
            else
            {
                //Empty DataTable to execute the “else-condition”  
                DataTable dt = new DataTable();
                InwardGrid.DataSource = dt;
                InwardGrid.DataBind();
            }
            SqlConnection con = new SqlConnection(sqlconn);
            SqlDataAdapter _objda = new SqlDataAdapter(str3, con);
            con.Close();
            _objda.Fill(_objdt);
            return _objdt;
        }

        protected void InwardCode_TextChanged(object sender, EventArgs e)
        {

            if (InwardCode.Text != "")
            {
                string[] ss = InwardCode.Text.Split(':');
                string qry11 = "select Top 1 Code,Name,Name1,CRUEI from InwardCarrierAgent where Code='" + ss[0].ToString().Replace("'","''") + "'";
                obj.dr = obj.ret_dr(qry11);
                if (obj.dr.Read())
                {
                    InwardCode.Text = obj.dr["Code"].ToString();
                    InwardName.Text = obj.dr["Name"].ToString();


                    InwardName1.Text = obj.dr["Name1"].ToString();
                    InwardCRUEI.Text = obj.dr["CRUEI"].ToString();
                    // lblimporterparty.Text = obj.dr["CRUEI"].ToString() + " - " + obj.dr["Name"].ToString() + " " + obj.dr["Name1"].ToString();

                    //IMPORTER PARTY


                    InwardCode.Text = obj.dr["Code"].ToString();
                    InwardCRUEI.Text = obj.dr["CRUEI"].ToString();
                    InwardName.Text = obj.dr["Name"].ToString();
                    InwardName1.Text = obj.dr["Name1"].ToString();



                }
            }
            else
            {
                InwardCode.Text = "";
                InwardName.Text = "";
                InwardName1.Text = "";
                InwardCRUEI.Text = "";
            }

            FrieghtCode.Focus();



            //if (InwardCode.Text != "")
            //{
            //    string[] ss = InwardCode.Text.Split(':');
            //    string qry11 = "select Top 1 Code,Name,Name1,CRUEI from InwardCarrierAgent where Code='" + ss[0].ToString() + "'";
            //    obj.dr = obj.ret_dr(qry11);
            //    if (obj.dr.Read())
            //    {
            //        InwardCode.Text = obj.dr["Code"].ToString();
            //        InwardName.Text = obj.dr["Name"].ToString();
            //        InwardName1.Text = obj.dr["Name1"].ToString();
            //        InwardCRUEI.Text = obj.dr["CRUEI"].ToString();
            //    }
            //}
            //else
            //{
            //    InwardCode.Text = "";
            //    InwardName.Text = "";
            //    InwardName1.Text = "";
            //    InwardCRUEI.Text = "";
            //}
            //FrieghtCode.Focus();
        }
        //freight 
        private void BindFrieght()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Top 20 Id,Code,Name,Name1,CRUEI FROM FreightForwarder"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet dt = new DataSet())
                        {
                            sda.Fill(dt);
                            FrieghtGrid.DataSource = dt;
                            FrieghtGrid.DataBind();
                        }
                    }
                }
            }
        }
        protected void FrieghtSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable _objdt = new DataTable();
            _objdt = GetFreightDataFromDataBase(FrieghtSearch.Text);
            if (_objdt.Rows.Count > 0)
            {
                FrieghtGrid.DataSource = _objdt;
                FrieghtGrid.DataBind();
                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalfright();", true);
            }
        }

        protected void LnkFrieght_Command(object sender, CommandEventArgs e)
        {
            var lb = (LinkButton)sender;
            var row = (GridViewRow)lb.NamingContainer;
            if (row != null)
            {
                var lblCode1 = row.FindControl("lblCode") as Label;
                var lblName1 = row.FindControl("lblName") as Label;
                var lblName11 = row.FindControl("lblName1") as Label;
                var cruei1 = row.FindControl("lblCRUEI") as Label;

                if (lblCode1 != null && lblName1 != null && lblName11 != null && cruei1 != null)
                {
                    //Get values
                    string requestor = lblCode1.Text;
                    string requestType = lblName1.Text;
                    string status = lblName11.Text;
                    string crueis = cruei1.Text;


                    FrieghtCode.Text = "";
                    FrieghtName.Text = "";
                    FrieghtName1.Text = "";
                    FrieghtCRUEI.Text = "";
                    FrieghtCode.Text = requestor;
                    FrieghtName.Text = requestType;
                    FrieghtName1.Text = status;
                    FrieghtCRUEI.Text = crueis;

                    string date = DateTime.Now.ToString("yyyyMMdd");
                    string Code = txt_code.Text;
                    DECLARATIONURN.Text = crueis + " - " + date + " - " + Code;
                }

            }
        }

        protected void BtnFrieghtAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FrieghtCode.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Freight Forwarder Code Is Empty');", true);
            }
            else if (string.IsNullOrWhiteSpace(FrieghtCRUEI.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Freight Forwarder CRUEI Is Empty');", true);
            }
            else if (string.IsNullOrWhiteSpace(FrieghtName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Freight Forwarder Name Is Empty');", true);
            }
            else
            {
                string Code = "";
                string qry11 = "SELECT Code FROM FreightForwarder where Code='" + FrieghtCode.Text.Replace("'","''") + "'";

                obj.dr = obj.ret_dr(qry11);

                while (obj.dr.Read())
                {
                    Code = obj.dr[0].ToString();

                }
                if (Code == "")
                {
                    string Touch_user = Session["UserId"].ToString();

                    string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string StrQuery = ("INSERT INTO [dbo].[FreightForwarder] ([Code],[Name],[Name1],[CRUEI],[TouchUser],[TouchTime]) VALUES ('" + FrieghtCode.Text.Replace("'", "''") + "','" + FrieghtName.Text.Replace("'", "''") + "','" + FrieghtName1.Text.Replace("'", "''") + "','" + FrieghtCRUEI.Text.Replace("'", "''") + "','" + Touch_user + "',Convert(VARCHAR,'" + strTime + "',108))");
                    obj.exec(StrQuery);
                    BindFrieght();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : Data Saved Successfully');", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Freight Forwarder Code Already Exist...');", true);
                    // Response.Write("The FreightForwarder Code Already Exist..");
                }

                ClaimantName.Focus();
            }

        }
        public DataTable GetFreightDataFromDataBase(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = FrieghtSearch.Text;

            string str3 = "SELECT Id,Code,Name,Name1,CRUEI FROM FreightForwarder where Code Like '%" + FrieghtSearch.Text.Replace("'", "''") + "%' or Name Like '%" + FrieghtSearch.Text.Replace("'", "''") + "%' order by Id desc";
            obj.dr = obj.ret_dr(str3);
            if (obj.dr.HasRows)
            {
                FrieghtGrid.DataSource = obj.dr;

            }
            else
            {
                //Empty DataTable to execute the “else-condition”  
                DataTable dt = new DataTable();
                FrieghtGrid.DataSource = dt;
                FrieghtGrid.DataBind();
            }
            SqlConnection con = new SqlConnection(sqlconn);
            SqlDataAdapter _objda = new SqlDataAdapter(str3, con);
            con.Close();
            _objda.Fill(_objdt);
            return _objdt;
        }
        protected void FrieghtCode_TextChanged(object sender, EventArgs e)
        {
            if (FrieghtCode.Text != "")
            {
                string[] ss = FrieghtCode.Text.Split(':');
                string qry11 = "select Top 1 Code,Name,Name1,CRUEI from FreightForwarder where Code='" + ss[0].ToString().Replace("'", "''") + "'";
                obj.dr = obj.ret_dr(qry11);
                if (obj.dr.Read())
                {
                    FrieghtCode.Text = obj.dr["Code"].ToString();
                    FrieghtName.Text = obj.dr["Name"].ToString();
                    FrieghtName1.Text = obj.dr["Name1"].ToString();
                    FrieghtCRUEI.Text = obj.dr["CRUEI"].ToString();
                }
            }
            else
            {
                FrieghtCode.Text = "";
                FrieghtName.Text = "";
                FrieghtName1.Text = "";
                FrieghtCRUEI.Text = "";
            }
            ClaimantName.Focus();

        }

        protected void FrieghtGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            FrieghtGrid.PageIndex = e.NewPageIndex;
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalfright();", true);
            BindFrieght();
            upfreightgrid.Update();
            popupfreight.Show();
        }
        //Claimant 
        private void BindClaimant()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Top 20 * FROM ClaimantParty"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet dt = new DataSet())
                        {
                            sda.Fill(dt);
                            ClaimantGrid.DataSource = dt;
                            ClaimantGrid.DataBind();
                        }
                    }
                }
            }
        }
        protected void ClaimantSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable _objdt = new DataTable();
            _objdt = GetClaimantDataFromDataBase(ClaimantSearch.Text);
            if (_objdt.Rows.Count > 0)
            {
                ClaimantGrid.DataSource = _objdt;
                ClaimantGrid.DataBind();
                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalClaimant();", true);
            }
        }

        protected void ClaimantGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ClaimantGrid.PageIndex = e.NewPageIndex;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalClaimant();", true);
            BindClaimant();
            popupclaimant.Show();
        }

        protected void LmkClaimant_Command(object sender, CommandEventArgs e)
        {
            var lb = (LinkButton)sender;
            var row = (GridViewRow)lb.NamingContainer;
            if (row != null)
            {
                var lblCode1 = row.FindControl("lblName") as Label;
                var lblName1 = row.FindControl("lblName1") as Label;
                var cruei1 = row.FindControl("lblCRUEI") as Label;
                var lblName11 = row.FindControl("lblCName") as Label;

                var lblName111 = row.FindControl("lblCName1") as Label;

                if (lblCode1 != null && lblName1 != null && lblName11 != null && cruei1 != null && lblName111 != null)
                {
                    //Get values
                    string requestor = lblCode1.Text;
                    string requestType = lblName1.Text;
                    string status = lblName11.Text;
                    string crueis = cruei1.Text;
                    string Cname = lblName111.Text;


                    ClaimantName.Text = "";
                    ClaimantName1.Text = "";
                    ClaimantCRUEI.Text = "";
                    ClaimantNameC.Text = "";
                    ClaimantName1C.Text = "";
                    ClaimantName.Text = requestor;
                    ClaimantName1.Text = requestType;
                    ClaimantCRUEI.Text = status;
                    ClaimantNameC.Text = crueis;
                    ClaimantName1C.Text = Cname;

                }

            }
            btnpreviousparty.Focus();
        }

        protected void ClaimantAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ClaimantName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The  Claimant Party Code Is Empty');", true);
            }
            if (string.IsNullOrWhiteSpace(ClaimantCRUEI.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The  Claimant Party CRUEI Is Empty');", true);
            }
            if (string.IsNullOrWhiteSpace(ClaimantName1.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The  Claimant Party Name1 Is Empty');", true);
            }
            else if (string.IsNullOrWhiteSpace(ClaimantName1C.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The  Claimant Party Claimant ID Is Empty');", true);
            }
            else if (string.IsNullOrWhiteSpace(ClaimantNameC.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The  Claimant Party Claimant Name Is Empty');", true);
            }
            else
            {
                string Code = "";
                string qry11 = "SELECT Name FROM ClaimantParty where Name='" + ClaimantName.Text.Replace("'","''") + "'";

                obj.dr = obj.ret_dr(qry11);

                while (obj.dr.Read())
                {
                    Code = obj.dr[0].ToString();

                }
                if (Code == "")
                {
                    string Touch_user = Session["UserId"].ToString();

                    string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string StrQuery = ("INSERT INTO [dbo].[ClaimantParty] ([Name],[Name1],[Name2],[CRUEI],[ClaimantName],[ClaimantName1],[TouchUser],[TouchTime]) VALUES ('" + ClaimantName.Text.Replace("'", "''") + "','" + ClaimantName1.Text.Replace("'", "''") + "','" + ClaimantName2.Text.Replace("'", "''") + "','" + ClaimantCRUEI.Text.Replace("'", "''") + "','" + ClaimantNameC.Text.Replace("'", "''") + "','" + ClaimantName1C.Text.Replace("'", "''") + "','" + Touch_user + "',Convert(VARCHAR,'" + strTime + "',108))");
                    obj.exec(StrQuery);
                    BindClaimant();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : Data Saved Successfully');", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Claimant Party Name Already Exist...');", true);
                    // Response.Write("The FreightForwarder Code Already Exist..");
                }

                btnpreviousparty.Focus();
            }
        }
        public DataTable GetClaimantDataFromDataBase(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = searchtext;

            string str3 = "SELECT Id,Name,Name1,Name2,CRUEI,ClaimantName,ClaimantName1 FROM ClaimantParty where Name Like '%" + a.Replace("'", "''") + "%' or Name1 Like '%" + a.Replace("'", "''") + "%' order by Id desc";
            obj.dr = obj.ret_dr(str3);
            if (obj.dr.HasRows)
            {
                ClaimantGrid.DataSource = obj.dr;

            }
            else
            {
                //Empty DataTable to execute the “else-condition”  
                DataTable dt = new DataTable();
                ClaimantGrid.DataSource = dt;
                ClaimantGrid.DataBind();
            }
            SqlConnection con = new SqlConnection(sqlconn);
            SqlDataAdapter _objda = new SqlDataAdapter(str3, con);
            con.Close();
            _objda.Fill(_objdt);
            return _objdt;
        }
        protected void ClaimantName_TextChanged(object sender, EventArgs e)
        {
            if (ClaimantName.Text != "")
            {
                string[] ss = ClaimantName.Text.Split(':');
                string qry11 = "select Top 1 Name,Name1,Name2,CRUEI,ClaimantName,ClaimantName1 from ClaimantParty where Name='" + ss[0].ToString().Replace("'", "''") + "'";
                obj.dr = obj.ret_dr(qry11);
                if (obj.dr.Read())
                {
                    ClaimantName.Text = obj.dr["Name"].ToString();
                    ClaimantName1.Text = obj.dr["Name1"].ToString();
                    ClaimantName2.Text = obj.dr["Name2"].ToString();
                    ClaimantCRUEI.Text = obj.dr["CRUEI"].ToString();
                    ClaimantNameC.Text = obj.dr["ClaimantName"].ToString();
                    ClaimantName1C.Text = obj.dr["ClaimantName1"].ToString();
                }
            }
            else
            {
                ClaimantName.Text = "";
                ClaimantName1.Text = "";
                ClaimantName2.Text = "";
                ClaimantCRUEI.Text = "";
                ClaimantNameC.Text = "";
                ClaimantName1C.Text = "";
            }
            btnpreviousparty.Focus();
        }
        //cargo
        protected void TextMode_TextChanged(object sender, EventArgs e)
        {
            if (TextMode.Text == "")
            {

                if (TextMode.Text == "1 : Sea")
                {
                    InwardSea.Visible = true;
                }
                else if (TextMode.Text == "2 : Rail" || TextMode.Text == "3 : Road" || TextMode.Text == "5 : Mail" || TextMode.Text == "7 : Pipeline" || TextMode.Text == "N : Not Required" || TextMode.Text == "6 : Multi-model(Not in use)")
                {
                    InwardOther.Visible = true;
                }

                else if (TextMode.Text == "4 : Air")
                {
                    InwardFlight.Visible = true;
                }
            }
        }
        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));
            dt.Columns.Add(new DataColumn("Column2", typeof(string)));
            dt.Columns.Add(new DataColumn("Column3", typeof(string)));
            dt.Columns.Add(new DataColumn("Column4", typeof(string)));
            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Column1"] = string.Empty;
            dr["Column2"] = string.Empty;
            dr["Column3"] = string.Empty;
            dr["Column4"] = string.Empty;
            dt.Rows.Add(dr);
            //Store the DataTable in ViewState  
            ViewState["Container"] = dt;
            ContarinerGrid.DataSource = dt;
            ContarinerGrid.DataBind();
        }

        private void SetInitialRowItemRef()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));
            dt.Columns.Add(new DataColumn("Column2", typeof(string)));
            dt.Columns.Add(new DataColumn("Column3", typeof(string)));
            dt.Columns.Add(new DataColumn("Column4", typeof(string)));
            dt.Columns.Add(new DataColumn("Column5", typeof(string)));
            dt.Columns.Add(new DataColumn("Column6", typeof(string)));
            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Column1"] = string.Empty;
            dr["Column2"] = string.Empty;
            dr["Column3"] = string.Empty;
            dr["Column4"] = string.Empty;
            dr["Column5"] = string.Empty;
            dr["Column6"] = string.Empty;
            dt.Rows.Add(dr);
            //Store the DataTable in ViewState  
            ViewState["CurrentTableItem"] = dt;
            RefundItem.DataSource = dt;
            RefundItem.DataBind();
        }
        private void AddNewRowToGridcItemRef()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTableItem"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTableItem"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values
                        TextBox box1 = (TextBox)RefundItem.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                        TextBox box2 = (TextBox)RefundItem.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                        TextBox box3 = (TextBox)RefundItem.Rows[rowIndex].Cells[3].FindControl("TextBox3");
                        TextBox box4 = (TextBox)RefundItem.Rows[rowIndex].Cells[4].FindControl("TextBox4");
                        TextBox box5 = (TextBox)RefundItem.Rows[rowIndex].Cells[5].FindControl("TextBox5");
                        TextBox box6 = (TextBox)RefundItem.Rows[rowIndex].Cells[6].FindControl("TextBox6");
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = i + 1;
                        dtCurrentTable.Rows[i - 1]["Column1"] = box1.Text;
                        dtCurrentTable.Rows[i - 1]["Column2"] = box2.Text;
                        dtCurrentTable.Rows[i - 1]["Column3"] = box3.Text;
                        dtCurrentTable.Rows[i - 1]["Column4"] = box4.Text;
                        dtCurrentTable.Rows[i - 1]["Column5"] = box5.Text;
                        dtCurrentTable.Rows[i - 1]["Column6"] = box6.Text;
                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTableItem"] = dtCurrentTable;
                    RefundItem.DataSource = dtCurrentTable;
                    RefundItem.DataBind();
                    RefundItem.Columns[0].Visible = false;
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            //Set Previous Data on Postbacks
            SetPreviousDatacref();

        }
        private void SetPreviousDatacref()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTableItem"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTableItem"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox box1 = (TextBox)RefundItem.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                        TextBox box2 = (TextBox)RefundItem.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                        TextBox box3 = (TextBox)RefundItem.Rows[rowIndex].Cells[3].FindControl("TextBox3");
                        TextBox box4 = (TextBox)RefundItem.Rows[rowIndex].Cells[4].FindControl("TextBox4");
                        TextBox box5 = (TextBox)RefundItem.Rows[rowIndex].Cells[5].FindControl("TextBox5");
                        TextBox box6 = (TextBox)RefundItem.Rows[rowIndex].Cells[6].FindControl("TextBox6");



                        box1.Text = dt.Rows[i]["Column1"].ToString();
                        box2.Text = dt.Rows[i]["Column2"].ToString();
                        box3.Text = dt.Rows[i]["Column3"].ToString();
                        box4.Text = dt.Rows[i]["Column4"].ToString();
                        box5.Text = dt.Rows[i]["Column5"].ToString();
                        box6.Text = dt.Rows[i]["Column6"].ToString();
                        rowIndex++;
                    }
                }
            }
        }
        private void AddNewRowToGrid()
        {
            int rowIndex = 0;
            if (ViewState["Container"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["Container"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values  
                        TextBox box1 = (TextBox)ContarinerGrid.Rows[rowIndex].Cells[1].FindControl("txt1");
                        DropDownList drp1 = (DropDownList)ContarinerGrid.Rows[rowIndex].Cells[2].FindControl("DrpType");
                        TextBox box2 = (TextBox)ContarinerGrid.Rows[rowIndex].Cells[3].FindControl("txt2");
                        TextBox box3 = (TextBox)ContarinerGrid.Rows[rowIndex].Cells[4].FindControl("txt3");
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = i + 1;
                        dtCurrentTable.Rows[i - 1]["Column1"] = box1.Text;
                        dtCurrentTable.Rows[i - 1]["Column2"] = drp1.SelectedItem.ToString();
                        dtCurrentTable.Rows[i - 1]["Column3"] = box2.Text;
                        dtCurrentTable.Rows[i - 1]["Column4"] = box3.Text;

                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["Container"] = dtCurrentTable;
                    ContarinerGrid.DataSource = dtCurrentTable;
                    ContarinerGrid.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            //Set Previous Data on Postbacks  
            SetPreviousData();
        }
        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["Container"] != null)
            {
                DataTable dt = (DataTable)ViewState["Container"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox box1 = (TextBox)ContarinerGrid.Rows[rowIndex].Cells[1].FindControl("txt1");
                        DropDownList drp1 = (DropDownList)ContarinerGrid.Rows[rowIndex].Cells[1].FindControl("DrpType");
                        TextBox box2 = (TextBox)ContarinerGrid.Rows[rowIndex].Cells[2].FindControl("txt2");
                        TextBox box3 = (TextBox)ContarinerGrid.Rows[rowIndex].Cells[3].FindControl("txt3");
                        box1.Text = dt.Rows[i]["Column1"].ToString();
                        if (!string.IsNullOrWhiteSpace(dt.Rows[i]["Column2"].ToString()))
                        {
                            drp1.ClearSelection();
                            drp1.Items.FindByText(dt.Rows[i]["Column2"].ToString()).Selected = true;
                        }
                        box2.Text = dt.Rows[i]["Column3"].ToString();
                        box3.Text = dt.Rows[i]["Column4"].ToString();
                        rowIndex++;
                    }
                }
            }
        }

        protected void CarLoadingSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable _objdt = new DataTable();
            _objdt = GetDataLoading(CarLoadingSearch.Text);
            if (_objdt.Rows.Count > 0)
            {
                LoadingGrid.DataSource = _objdt;
                LoadingGrid.DataBind();
                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalLoading();", true);
            }

            uploadingport.Update();
        }

        protected void LoadingGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LoadingGrid.PageIndex = e.NewPageIndex;
            //  ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalLoading();", true);
            popuploadingport.Show();
            popuploadingport.X = 400;
            popuploadingport.Y = 100;

            BindLoading();
        }

        protected void LnkLoading_Command(object sender, CommandEventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalLoading();", false);
            var lb = (LinkButton)sender;
            var row = (GridViewRow)lb.NamingContainer;
            if (row != null)
            {
                var lblCode1 = row.FindControl("lblCode") as Label;
                var lblName1 = row.FindControl("lblName") as Label;



                if (lblCode1 != null && lblName1 != null)
                {
                    //Get values
                    string requestor = lblCode1.Text;
                    string requestType = lblName1.Text;


                    TxtLoadShort.Text = "";
                    TxtLoad.Text = "";

                    TxtLoadShort.Text = requestor;
                    TxtLoad.Text = requestType;


                }

            }
        }
        private void BindlOCATION()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Top 20 * FROM ReleaseLocation"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet dt = new DataSet())
                        {
                            sda.Fill(dt);
                            LocationGrid.DataSource = dt;
                            LocationGrid.DataBind();
                        }
                    }
                }
            }
        }
        protected void LocationSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable _objdt = new DataTable();
            _objdt = GetDataFromDataBasecar(LocationSearch.Text);
            if (_objdt.Rows.Count > 0)
            {
                LocationGrid.DataSource = _objdt;
                LocationGrid.DataBind();
                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openLocation();", true);
            }
        }

        protected void LocationGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LocationGrid.PageIndex = e.NewPageIndex;
            //  ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openLocation();", true);
            popupreleaseloc.Show();
            popupreleaseloc.X = 400;
            popupreleaseloc.Y = 100;
            BindlOCATION();
        }

        protected void LnkLocation_Command(object sender, CommandEventArgs e)
        {
            var lb = (LinkButton)sender;
            var row = (GridViewRow)lb.NamingContainer;
            if (row != null)
            {
                var lblCode1 = row.FindControl("lblCode") as Label;
                var lblName1 = row.FindControl("lblName") as Label;
                var lblName11 = row.FindControl("lblName1") as Label;


                if (lblCode1 != null && lblName1 != null && lblName11 != null)
                {
                    //Get values
                    string requestor = lblCode1.Text;
                    string requestType = lblName1.Text;
                    string status = lblName11.Text;

                    txtreLoctn.Text = "";
                    txtrelocDeta.Text = "";

                    txtreLoctn.Text = requestType;
                    txtrelocDeta.Text = status;


                }

            }
        }
        public DataTable GetDataFromDataBasecar(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = txtreLoctn.Text;

            string str3 = "SELECT * FROM ReleaseLocation where Code Like '%" + searchtext + "%' order by Id desc";
            obj.dr = obj.ret_dr(str3);
            if (obj.dr.HasRows)
            {
                LocationGrid.DataSource = obj.dr;

            }
            else
            {
                //Empty DataTable to execute the “else-condition”  
                DataTable dt = new DataTable();
                LocationGrid.DataSource = dt;
                LocationGrid.DataBind();
            }
            SqlConnection con = new SqlConnection(sqlconn);
            SqlDataAdapter _objda = new SqlDataAdapter(str3, con);
            con.Close();
            _objda.Fill(_objdt);
            return _objdt;
        }
        protected void txtreLoctn_TextChanged(object sender, EventArgs e)
        {
            if (txtreLoctn.Text != "")
            {
                InpaymentClass objre = new InpaymentClass();
                string[] ss = txtreLoctn.Text.Split(':');
                if (TextMode.Text == "1 : Sea")
                {
                    if (ss[0].ToString() == "KZ" || ss[0].ToString() == "PPZ" || ss[0].ToString() == "JZ")
                    {

                        string qry11 = "select * from ReleaseLocation where Code='" + ss[0].ToString() + "'";
                        objre.dr = objre.ret_dr(qry11);
                        while (objre.dr.Read())
                        {
                            //txtreLoctn.Text = obj.dr[2].ToString() + ":" + obj.dr[3].ToString();
                            txtreLoctn.Text = objre.dr[2].ToString();
                            txtrelocDeta.Text = objre.dr[3].ToString();
                            txtrelocDeta.ForeColor = Color.Black;
                            lblrelloc.Visible = false;
                        }
                    }
                    else
                    {
                        // txtrelocDeta.ForeColor = Color.Red;

                        string qry11 = "select * from ReleaseLocation where Code='" + ss[0].ToString() + "'";
                        objre.dr = objre.ret_dr(qry11);
                        while (objre.dr.Read())
                        {
                            //txtreLoctn.Text = obj.dr[2].ToString() + ":" + obj.dr[3].ToString();
                            txtreLoctn.Text = objre.dr[2].ToString();
                            txtrelocDeta.Text = objre.dr[3].ToString();
                            txtrelocDeta.ForeColor = Color.Black;
                            //lblrelloc.Visible = false;
                        }

                        lblrelloc.Visible = true;
                        //txtrelocDeta.Text = "";
                        lblrelloc.Text = "Please Check Place of Release Location";
                        //  Response.Write("<Script>alert(Please Check Place of Release Location)</script>");
                    }
                }

                //air

                else if (TextMode.Text == "4 : Air")
                {
                    if (ss[0].ToString() == "CZ" || ss[0].ToString() == "AT1B" || ss[0].ToString() == "AT2B" || ss[0].ToString() == "AT3B")
                    {
                        string qry11 = "select * from ReleaseLocation where Code='" + ss[0].ToString() + "'";
                        objre.dr = objre.ret_dr(qry11);
                        while (objre.dr.Read())
                        {
                            //txtreLoctn.Text = obj.dr[2].ToString() + ":" + obj.dr[3].ToString();
                            txtreLoctn.Text = objre.dr[2].ToString();
                            txtrelocDeta.Text = objre.dr[3].ToString();
                            txtrelocDeta.ForeColor = Color.Black;
                            lblrelloc.Visible = false;
                        }
                    }
                    else
                    {

                        lblrelloc.Visible = true;
                        lblrelloc.Text = "Please Check Place of Release Location";
                        // txtrelocDeta.Text = "";

                        string qry11 = "select * from ReleaseLocation where Code='" + ss[0].ToString() + "'";
                        objre.dr = objre.ret_dr(qry11);
                        while (objre.dr.Read())
                        {
                            //txtreLoctn.Text = obj.dr[2].ToString() + ":" + obj.dr[3].ToString();
                            txtreLoctn.Text = objre.dr[2].ToString();
                            txtrelocDeta.Text = objre.dr[3].ToString();
                            txtrelocDeta.ForeColor = Color.Black;

                        }
                    }
                }
                else if (TextMode.Text == "3 : Road")
                {
                    if (ss[0].ToString() == "THQ" || ss[0].ToString() == "LHQ")
                    {

                        string qry11 = "select * from ReleaseLocation where Code='" + ss[0].ToString() + "'";
                        objre.dr = objre.ret_dr(qry11);
                        while (objre.dr.Read())
                        {
                            //txtreLoctn.Text = obj.dr[2].ToString() + ":" + obj.dr[3].ToString();
                            txtreLoctn.Text = objre.dr[2].ToString();
                            txtrelocDeta.Text = objre.dr[3].ToString();
                            txtrelocDeta.ForeColor = Color.Black;
                            lblrelloc.Visible = false;
                        }
                    }
                    else
                    {
                        // txtrelocDeta.ForeColor = Color.Red;
                        lblrelloc.Visible = true;
                        lblrelloc.Text = "Please Check Place of Release Location";
                        txtrelocDeta.Text = "";
                        string qry11 = "select * from ReleaseLocation where Code='" + ss[0].ToString() + "'";
                        objre.dr = objre.ret_dr(qry11);
                        while (objre.dr.Read())
                        {
                            //txtreLoctn.Text = obj.dr[2].ToString() + ":" + obj.dr[3].ToString();
                            txtreLoctn.Text = objre.dr[2].ToString();
                            txtrelocDeta.Text = objre.dr[3].ToString();
                            txtrelocDeta.ForeColor = Color.Black;

                        }
                    }
                }
                else
                {
                    string qry11 = "select * from ReleaseLocation where Code='" + ss[0].ToString() + "'";
                    objre.dr = objre.ret_dr(qry11);
                    while (objre.dr.Read())
                    {
                        //txtreLoctn.Text = obj.dr[2].ToString() + ":" + obj.dr[3].ToString();
                        txtreLoctn.Text = objre.dr[2].ToString();
                        txtrelocDeta.Text = objre.dr[3].ToString();
                        txtrelocDeta.ForeColor = Color.Black;
                        lblrelloc.Visible = false;
                    }

                }


            }
            else
            {
                txtreLoctn.Text = "";
                txtrelocDeta.Text = "";
            }
            txtrecloctn.Focus();
        }
        private void Bindreceipt()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Top 20 * FROM ReceiptLocation"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet dt = new DataSet())
                        {
                            sda.Fill(dt);
                            ReceiptGrid.DataSource = dt;
                            ReceiptGrid.DataBind();
                        }
                    }
                }
            }
        }
        protected void ReceiptSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable _objdt = new DataTable();
            _objdt = GetReceipt(ReceiptSearch.Text);
            if (_objdt.Rows.Count > 0)
            {
                ReceiptGrid.DataSource = _objdt;
                ReceiptGrid.DataBind();
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openReceipt();", true);
            }
        }
        public DataTable GetReceipt(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = ReceiptSearch.Text;

            string str3 = "SELECT * FROM ReceiptLocation where Code Like '%" + searchtext + "%' order by Id desc";
            obj.dr = obj.ret_dr(str3);
            if (obj.dr.HasRows)
            {
                ReceiptGrid.DataSource = obj.dr;

            }
            else
            {
                //Empty DataTable to execute the “else-condition”  
                DataTable dt = new DataTable();
                ReceiptGrid.DataSource = dt;
                ReceiptGrid.DataBind();
            }
            SqlConnection con = new SqlConnection(sqlconn);
            SqlDataAdapter _objda = new SqlDataAdapter(str3, con);
            con.Close();
            _objda.Fill(_objdt);
            return _objdt;
        }
        protected void ReceiptGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ReceiptGrid.PageIndex = e.NewPageIndex;
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openReceipt();", true);
            popupreceiptloc.Show();
            //popupreceiptloc.X = 400;
            //popupreleaseloc.Y = 100;

            Bindreceipt();
        }

        protected void LnkReceipt_Command(object sender, CommandEventArgs e)
        {
            var lb = (LinkButton)sender;
            var row = (GridViewRow)lb.NamingContainer;
            if (row != null)
            {
                var lblCode1 = row.FindControl("lblCode") as Label;
                var lblName1 = row.FindControl("lblName") as Label;
                var lblName11 = row.FindControl("lblName1") as Label;


                if (lblCode1 != null && lblName1 != null && lblName11 != null)
                {
                    //Get values
                    string requestor = lblCode1.Text;
                    string requestType = lblName1.Text;
                    string status = lblName11.Text;

                    txtrecloctn.Text = "";
                    txtrecloctndet.Text = "";

                    txtrecloctn.Text = requestType;
                    txtrecloctndet.Text = status;


                }

            }
        }

        protected void txtrecloctn_TextChanged(object sender, EventArgs e)
        {
            if (txtrecloctn.Text != "")
            {
                InpaymentClass objrec = new InpaymentClass();
                string[] ss = txtrecloctn.Text.Split(':');

                string qry11 = "select * from ReceiptLocation where Code='" + ss[0].ToString() + "'";
                objrec.dr = objrec.ret_dr(qry11);
                while (objrec.dr.Read())
                {
                    //txtrecloctn.Text = obj.dr[2].ToString()+":"+obj.dr[3].ToString();
                    txtrecloctn.Text = objrec.dr[2].ToString();
                    txtrecloctndet.Text = objrec.dr[3].ToString();


                }
            }
            else
            {
                txtrecloctn.Text = "";
                txtrecloctndet.Text = "";
            }
            BlankDate1.Focus();
        }
        private void BindLoading()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Top 20 * FROM LoadingPort"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet dt = new DataSet())
                        {
                            sda.Fill(dt);
                            LoadingGrid.DataSource = dt;
                            LoadingGrid.DataBind();
                        }
                    }
                }
            }
        }
        public DataTable GetDataLoading(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = CarLoadingSearch.Text;

            string str3 = "SELECT * FROM LoadingPort where PortCode Like '%" + CarLoadingSearch.Text + "%' or PortName like '" + CarLoadingSearch.Text + "%' order by Id desc";
            obj.dr = obj.ret_dr(str3);
            if (obj.dr.HasRows)
            {
                LoadingGrid.DataSource = obj.dr;

            }
            else
            {
                //Empty DataTable to execute the “else-condition”  
                DataTable dt = new DataTable();
                LoadingGrid.DataSource = dt;
                LoadingGrid.DataBind();
            }
            SqlConnection con = new SqlConnection(sqlconn);
            SqlDataAdapter _objda = new SqlDataAdapter(str3, con);
            con.Close();
            _objda.Fill(_objdt);
            return _objdt;
        }
        protected void ContarinerGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            //int index = Convert.ToInt32(e.RowIndex);
            //DataTable dt = ViewState["dt"] as DataTable;
            //dt.Rows[index].Delete();
            //ViewState["dt"] = dt;
            //BindGrid();
            //chkdel = "Delete";
            if (ViewState["Container"] != null)
            {
                DataTable dt = (DataTable)ViewState["Container"];
                DataRow drCurrentRow = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                if (dt.Rows.Count > 1)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["Container"] = dt;
                    ContarinerGrid.DataSource = dt;
                    ContarinerGrid.DataBind();

                    for (int i = 0; i < ContarinerGrid.Rows.Count - 1; i++)
                    {
                        ContarinerGrid.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                    }
                    SetPreviousData();
                }
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }

        protected void TxtLoadShort_TextChanged(object sender, EventArgs e)
        {
            if (TxtLoadShort.Text != "")
            {
                string[] ss = TxtLoadShort.Text.Split(':');
                string qry11 = "select * from LoadingPort where PortCode='" + ss[0].ToString() + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    TxtLoadShort.Text = obj.dr[1].ToString();
                    TxtLoad.Text = obj.dr[2].ToString();
                }
            }
            else
            {
                TxtLoadShort.Text = "";
                TxtLoad.Text = "";
            }
            txthBlCargo.Focus();
        }
        //invoice
        protected void DrpTerms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DrpTerms.SelectedItem.ToString() != "--Select--")
            {
                TotalInvoice.Visible = false;
                OtherTaxableCharge.Visible = false;
                FrieghtCharges.Visible = false;
                InsuranceCharges.Visible = false;
                CostInsuranceandFreight.Visible = false;
                GST.Visible = false;
                if (DrpTerms.SelectedItem.ToString() == "CFR : Cost and Frieght ( also known as C & F )")
                {
                    TotalInvoice.Visible = true;
                    OtherTaxableCharge.Visible = true;
                    FrieghtCharges.Visible = false;
                    InsuranceCharges.Visible = true;
                    CostInsuranceandFreight.Visible = true;
                    GST.Visible = true;
                    if (editInvoice != true)
                    {
                        InsuranceChargesPer.Text = "1.00";
                        string Cur = "10";
                        Drpcurrency4.SelectedValue = Cur;
                        Drpcurrency4_SelectedIndexChanged(null, null);

                        LblFrieghtCharges.Text = "0.00";
                        TxtFrieghtCharges.Text = "0.00";
                        string Cur1 = "0";
                        Drpcurrency3.SelectedValue = Cur1;
                        Drpcurrency3_SelectedIndexChanged(null, null);
                    }
                }
                else if (DrpTerms.SelectedItem.ToString() == "CIF : Cost,Insurance and Frieght")
                {
                    TotalInvoice.Visible = true;
                    OtherTaxableCharge.Visible = true;
                    FrieghtCharges.Visible = false;
                    InsuranceCharges.Visible = false;
                    CostInsuranceandFreight.Visible = true;
                    GST.Visible = true;
                    if (editInvoice != true)
                    {
                        InsuranceChargesPer.Text = "0.00";
                        string Cur = "0";
                        TxtInsuranceCharges.Text = "0.00";
                        lblInsuranceCharges.Text = "0.00";
                        Drpcurrency4.SelectedValue = Cur;
                        Drpcurrency4_SelectedIndexChanged(null, null);

                        LblFrieghtCharges.Text = "0.00";
                        TxtFrieghtCharges.Text = "0.00";
                        LblFrieghtCharges.Text = "0.00";
                        string Cur1 = "0";
                        Drpcurrency3.SelectedValue = Cur1;
                        Drpcurrency3_SelectedIndexChanged(null, null);
                    }
                }
                else if (DrpTerms.SelectedItem.ToString() == "EXW : Exw Works (also known as Ex-Factory)")
                {
                    TotalInvoice.Visible = true;
                    OtherTaxableCharge.Visible = true;
                    FrieghtCharges.Visible = true;
                    InsuranceCharges.Visible = true;
                    CostInsuranceandFreight.Visible = true;
                    GST.Visible = true;
                    if (editInvoice != true)
                    {
                        InsuranceChargesPer.Text = "1.00";
                        string Cur = "10";
                        Drpcurrency4.SelectedValue = Cur;
                        Drpcurrency4_SelectedIndexChanged(null, null);
                    }
                }
                else if (DrpTerms.SelectedItem.ToString() == "CNI : Cost and Insurance (also Known as C & I )")
                {
                    TotalInvoice.Visible = true;
                    OtherTaxableCharge.Visible = true;
                    FrieghtCharges.Visible = true;
                    InsuranceCharges.Visible = false;
                    CostInsuranceandFreight.Visible = true;
                    GST.Visible = true;
                    if (editInvoice != true)
                    {
                        InsuranceChargesPer.Text = "0.00";
                        string Cur = "0";
                        TxtInsuranceCharges.Text = "0.00";
                        Drpcurrency4.SelectedValue = Cur;
                        Drpcurrency4_SelectedIndexChanged(null, null);
                    }
                }
                else if (DrpTerms.SelectedItem.ToString() == "FAS : Free Alongside Ship")
                {
                    TotalInvoice.Visible = true;
                    OtherTaxableCharge.Visible = true;
                    FrieghtCharges.Visible = true;
                    InsuranceCharges.Visible = true;
                    CostInsuranceandFreight.Visible = true;
                    GST.Visible = true;
                    if (editInvoice != true)
                    {
                        InsuranceChargesPer.Text = "1.00";
                        string Cur = "10";
                        Drpcurrency4.SelectedValue = Cur;
                        Drpcurrency4_SelectedIndexChanged(null, null);
                    }
                }
                else if (DrpTerms.SelectedItem.ToString() == "FOB : Free On Board")
                {
                    TotalInvoice.Visible = true;
                    OtherTaxableCharge.Visible = true;
                    FrieghtCharges.Visible = true;
                    InsuranceCharges.Visible = true;
                    CostInsuranceandFreight.Visible = true;
                    GST.Visible = true;
                    if (editInvoice != true)
                    {
                        InsuranceChargesPer.Text = "1.00";
                        string Cur = "10";
                        Drpcurrency4.SelectedValue = Cur;
                        Drpcurrency4_SelectedIndexChanged(null, null);
                    }
                }
            }
            TxtTotalInvoice_TextChanged(null, null);
            InsuranceChargesPer_TextChanged(null, null);
            TxtFrieghtCharges_TextChanged(null, null);
            chkindicator.Focus();
        }
        private void BindGridinx()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Top 20 Id,Code,Name,Name1,CRUEI FROM SUPPLIERMANUFACTURERPARTY"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet dt = new DataSet())
                        {
                            sda.Fill(dt);
                            SUPPLIERGrid.DataSource = dt;
                            SUPPLIERGrid.DataBind();
                        }
                    }
                }
            }
        }
        protected void SUPPLIERSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable _objdt = new DataTable();
            _objdt = GetSupplyDataFromDataBase(SUPPLIERSearch.Text);
            if (_objdt.Rows.Count > 0)
            {
                SUPPLIERGrid.DataSource = _objdt;
                SUPPLIERGrid.DataBind();
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "SUPPLIER();", true);
            }
        }

        protected void SUPPLIERGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            SUPPLIERGrid.PageIndex = e.NewPageIndex;
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "SUPPLIER();", true);
            popupsupplier.Show();
            //popupsupplier.X = 300;
            //popupsupplier.Y = 100;

            BindGridinx();
        }

        protected void lnkRequestID_Command1(object sender, CommandEventArgs e)
        {
            var lb = (LinkButton)sender;
            var row = (GridViewRow)lb.NamingContainer;
            if (row != null)
            {
                var lblCode1 = row.FindControl("lblCode") as Label;
                var lblName1 = row.FindControl("lblName") as Label;
                var lblName11 = row.FindControl("lblName1") as Label;
                var cruei1 = row.FindControl("lblCRUEI") as Label;

                if (lblCode1 != null && lblName1 != null && lblName11 != null && cruei1 != null)
                {
                    //Get values
                    string requestor = lblCode1.Text;
                    string requestType = lblName1.Text;
                    string status = lblName11.Text;
                    string crueis = cruei1.Text;
                    txtcodeinvq.Text = "";
                    txtName.Text = "";
                    txtName1.Text = "";
                    txtcruei.Text = "";
                    txtcodeinvq.Text = requestor;
                    txtName.Text = requestType;
                    txtName1.Text = status;
                    txtcruei.Text = crueis;

                }

            }
        }



        protected void txtcodeinvq_TextChanged(object sender, EventArgs e)
        {
            if (txtcodeinvq.Text != "")
            {
                string[] ss = txtcodeinvq.Text.Split(':');
                string qry11 = "select * from SUPPLIERMANUFACTURERPARTY where Code='" + ss[0].ToString().Replace("'","''") + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {


                    txtcodeinvq.Text = obj.dr[1].ToString();
                    txtName.Text = obj.dr[2].ToString();
                    txtName1.Text = obj.dr[3].ToString();
                    txtcruei.Text = obj.dr[4].ToString();

                }
            }
            else
            {
                txtcodeinvq.Text = "";
                txtName.Text = "";
                txtName1.Text = "";
                txtcruei.Text = "";
            }
            TxtImppartyCode.Focus();
        }

        protected void suppyadd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtcodeinvq.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Supplier/Manufacturer Party Code Is Empty');", true);
            }
            else if (string.IsNullOrWhiteSpace(txtcruei.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Supplier/Manufacturer Party UEI Is Empty');", true);
            }
            else if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Supplier/Manufacturer Party Name Is Empty');", true);
            }
            else
            {


                string Code = "";
                string qry11 = "SELECT Code FROM SUPPLIERMANUFACTURERPARTY where Code='" + txtcodeinvq.Text.Replace("'", "''") + "'";

                obj.dr = obj.ret_dr(qry11);

                while (obj.dr.Read())
                {
                    Code = obj.dr[0].ToString();

                }
                if (Code == "")
                {
                    string Touch_user = Session["UserId"].ToString();

                    string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string StrQuery = ("INSERT INTO [dbo].[SUPPLIERMANUFACTURERPARTY] ([Code],[Name],[Name1],[CRUEI],[TouchUser],[TouchTime]) VALUES ('" + txtcodeinvq.Text.Replace("'", "''") + "','" + txtName.Text.Replace("'", "''") + "','" + txtName1.Text.Replace("'", "''") + "','" + txtcruei.Text.Replace("'", "''") + "','" + Touch_user + "',Convert(VARCHAR,'" + strTime + "',108))");
                    obj.exec(StrQuery);
                    BindGrid();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : Data Saved Successfully');", true);

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Supplier/Manufacturer Party Code Already Exist..');", true);
                    //  Response.Write("The Importer Code Already Exist..");
                }
            }
            TxtImppartyCode.Focus();
        }
        //CPC
        private void SetInitialRowc()
        {

            DataTable dt = new DataTable();

            DataRow dr = null;

            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));

            dt.Columns.Add(new DataColumn("ProcessingCode1", typeof(string)));

            dt.Columns.Add(new DataColumn("ProcessingCode2", typeof(string)));

            dt.Columns.Add(new DataColumn("ProcessingCode3", typeof(string)));

            dr = dt.NewRow();

            dr["RowNumber"] = "1";

            dr["ProcessingCode1"] = string.Empty;

            dr["ProcessingCode2"] = string.Empty;

            dr["ProcessingCode3"] = string.Empty;

            dt.Rows.Add(dr);

            //dr = dt.NewRow();



            //Store the DataTable in ViewState

            ViewState["CurrentTable"] = dt;



            AEOGrid.DataSource = dt;

            AEOGrid.DataBind();
            // AEOGrid.Columns[0].Visible = false;

        }
        private void AddNewRowToGridc()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values
                        TextBox box1 = (TextBox)AEOGrid.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                        TextBox box2 = (TextBox)AEOGrid.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                        TextBox box3 = (TextBox)AEOGrid.Rows[rowIndex].Cells[3].FindControl("TextBox3");
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = i + 1;
                        dtCurrentTable.Rows[i - 1]["ProcessingCode1"] = box1.Text;
                        dtCurrentTable.Rows[i - 1]["ProcessingCode2"] = box2.Text;
                        dtCurrentTable.Rows[i - 1]["ProcessingCode3"] = box3.Text;
                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;
                    AEOGrid.DataSource = dtCurrentTable;
                    AEOGrid.DataBind();
                    //AEOGrid.Columns[0].Visible = false;
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            //Set Previous Data on Postbacks
            SetPreviousDatac();
        }
        private void SetPreviousDatac()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        TextBox box1 = (TextBox)AEOGrid.Rows[rowIndex].Cells[1].FindControl("TextBox1");

                        TextBox box2 = (TextBox)AEOGrid.Rows[rowIndex].Cells[2].FindControl("TextBox2");

                        TextBox box3 = (TextBox)AEOGrid.Rows[rowIndex].Cells[3].FindControl("TextBox3");



                        box1.Text = dt.Rows[i]["ProcessingCode1"].ToString();

                        box2.Text = dt.Rows[i]["ProcessingCode2"].ToString();

                        box3.Text = dt.Rows[i]["ProcessingCode3"].ToString();



                        rowIndex++;

                    }

                }

            }

        }

        private void SetInitialRow1cp()
        {

            DataTable dt = new DataTable();

            DataRow dr = null;

            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));

            dt.Columns.Add(new DataColumn("ProcessingCode1", typeof(string)));

            dt.Columns.Add(new DataColumn("ProcessingCode2", typeof(string)));

            dt.Columns.Add(new DataColumn("ProcessingCode3", typeof(string)));

            dr = dt.NewRow();

            dr["RowNumber"] = 1;

            dr["ProcessingCode1"] = string.Empty;

            dr["ProcessingCode2"] = string.Empty;

            dr["ProcessingCode3"] = string.Empty;

            dt.Rows.Add(dr);

            //dr = dt.NewRow();



            //Store the DataTable in ViewState

            ViewState["CurrentTable1"] = dt;

            CWCGrid.DataSource = dt;

            CWCGrid.DataBind();
            //CWCGrid.Columns[0].Visible = false;

        }
        private void AddNewRowToGrid1cp()
        {

            int rowIndex = 0;



            if (ViewState["CurrentTable1"] != null)
            {

                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable1"];

                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {

                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {

                        //extract the TextBox values

                        TextBox box1 = (TextBox)CWCGrid.Rows[rowIndex].Cells[1].FindControl("TextBox1");

                        TextBox box2 = (TextBox)CWCGrid.Rows[rowIndex].Cells[2].FindControl("TextBox2");

                        TextBox box3 = (TextBox)CWCGrid.Rows[rowIndex].Cells[3].FindControl("TextBox3");



                        drCurrentRow = dtCurrentTable.NewRow();

                        drCurrentRow["RowNumber"] = i + 1;



                        dtCurrentTable.Rows[i - 1]["ProcessingCode1"] = box1.Text;

                        dtCurrentTable.Rows[i - 1]["ProcessingCode2"] = box2.Text;

                        dtCurrentTable.Rows[i - 1]["ProcessingCode3"] = box3.Text;



                        rowIndex++;

                    }

                    dtCurrentTable.Rows.Add(drCurrentRow);

                    ViewState["CurrentTable1"] = dtCurrentTable;



                    CWCGrid.DataSource = dtCurrentTable;

                    CWCGrid.DataBind();
                    //CWCGrid.Columns[0].Visible = false;
                }

            }

            else
            {

                Response.Write("ViewState is null");

            }



            //Set Previous Data on Postbacks

            SetPreviousData1cp();

        }
        private void SetPreviousData1cp()
        {

            int rowIndex = 0;

            if (ViewState["CurrentTable1"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTable1"];

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        TextBox box1 = (TextBox)CWCGrid.Rows[rowIndex].Cells[1].FindControl("TextBox1");

                        TextBox box2 = (TextBox)CWCGrid.Rows[rowIndex].Cells[2].FindControl("TextBox2");

                        TextBox box3 = (TextBox)CWCGrid.Rows[rowIndex].Cells[3].FindControl("TextBox3");



                        box1.Text = dt.Rows[i]["ProcessingCode1"].ToString();

                        box2.Text = dt.Rows[i]["ProcessingCode2"].ToString();

                        box3.Text = dt.Rows[i]["ProcessingCode3"].ToString();



                        rowIndex++;

                    }

                }

            }

        }

        protected void BtnCWC_Click(object sender, EventArgs e)
        {
            DataTable dtCurrent = ViewState["CurrentTable1"] as DataTable;

            // Check if current rows are already 5
            if (dtCurrent != null && dtCurrent.Rows.Count >= 5)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You can only add up to 5 rows.');", true);
                return;
            }

            // Check if there are existing rows and validate the last row's inputs
            if (CWCGrid.Rows.Count > 0) // Replace "CWCGrid" with your actual GridView ID
            {
                int lastRowIndex = CWCGrid.Rows.Count - 1;

                // Replace these with your actual control IDs from the grid
                TextBox box1 = (TextBox)CWCGrid.Rows[lastRowIndex].Cells[1].FindControl("TextBox1");
                TextBox box2 = (TextBox)CWCGrid.Rows[lastRowIndex].Cells[2].FindControl("TextBox2");
                TextBox box3 = (TextBox)CWCGrid.Rows[lastRowIndex].Cells[3].FindControl("TextBox3");

                if (string.IsNullOrWhiteSpace(box1.Text))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please fill all fields in the previous row before adding a new one.');", true);
                    return;
                }
            }

            if (dtCurrent == null || dtCurrent.Rows.Count == 0)
            {
                SetInitialRow1cp();
            }
            else
            {
                AddNewRowToGrid1cp();
            }

            chkcnb.Focus();
        }



        //item cosde


        //heADER uPLOAD
        protected void Btn_Upload_Click(object sender, EventArgs e)
        {
            // Allowed file extensions and MIME types
            string[] allowedExtensions = { ".doc", ".docx", ".pdf", ".xls", ".xlsx", ".bmp", ".jpg", ".jpeg", ".gif", ".emf", ".png", ".tif" };
            string[] allowedMimeTypes = {
                "application/msword",
                "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                "application/pdf",
                "application/vnd.ms-excel",
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "image/bmp",
                "image/jpeg",
                "image/gif",
                "image/x-emf",
                "image/png",
                "image/tiff"
            };

            const int maxTotalSizeKB = 20000;

            long existingTotalKB = 0;
            string constr2 = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr2))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT ISNULL(SUM(FileSizeKB), 0) FROM InFile WHERE InPaymentId = @InPaymentId", con))
                {
                    cmd.Parameters.AddWithValue("@InPaymentId", MsgNO);
                    existingTotalKB = Convert.ToInt64(cmd.ExecuteScalar());
                }
            }

            long newBatchTotalKB = 0;
            foreach (HttpPostedFile postedFile in FileUpload1.PostedFiles)
            {
                newBatchTotalKB += (int)Math.Ceiling(postedFile.ContentLength / 1024.0);
            }

            // Check total size (existing + new)
            if (existingTotalKB + newBatchTotalKB > maxTotalSizeKB)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    $"alert('Total file size cannot exceed {maxTotalSizeKB}KB! Current: {existingTotalKB}KB');", true);
                return;
            }

            long totalSizeBytes = 0;

            // Calculate total size first
            foreach (HttpPostedFile postedFile in FileUpload1.PostedFiles)
            {
                totalSizeBytes += postedFile.ContentLength;
            }

            // Convert to KB and check limit
            if (totalSizeBytes / 1024 > maxTotalSizeKB)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Total file size exceeds 20MB limit!');", true);
                return;
            }

            int infi = 1;
            foreach (HttpPostedFile postedFile in FileUpload1.PostedFiles)
            {
                string filename = Path.GetFileName(postedFile.FileName);
                string fileExtension = Path.GetExtension(filename).ToLower();

                // Validate file extension
                if (!allowedExtensions.Contains(fileExtension))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Invalid file type: {filename}');", true);
                    continue;
                }

                // Validate MIME type
                if (!allowedMimeTypes.Contains(postedFile.ContentType.ToLower()))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Invalid file content type: {filename}');", true);
                    continue;
                }

                string path = @"C:\Users\Public\IMG\" + filename;

                try
                {
                    // Save file once
                    postedFile.SaveAs(path);

                    int fileSizeKB = (int)Math.Ceiling(postedFile.ContentLength / 1024.0);

                    using (Stream fs = postedFile.InputStream)
                    {
                        // Rest of database code remains the same
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            byte[] bytes = br.ReadBytes((Int32)fs.Length);
                            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
                            using (SqlConnection con = new SqlConnection(constr))
                            {
                                // Handle potential null session
                                string Touch_user = Session["UserId"]?.ToString() ?? "unknown";
                                string Code = txt_code.Text;
                                string DocType = DrpDocType.SelectedItem?.ToString() ?? "undefined";
                                string strTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                                string query = @"INSERT INTO InFile VALUES 
                            (@Sno,@Name,@ContentType,@Data,@DocumentType,
                            @InPaymentId,@TouchUser,@TouchTime,@filePath,@FileSizeKB)";

                                using (SqlCommand cmd = new SqlCommand(query, con))
                                {
                                    cmd.Parameters.AddWithValue("@Sno", infi);
                                    cmd.Parameters.AddWithValue("@Name", filename);
                                    cmd.Parameters.AddWithValue("@ContentType", postedFile.ContentType); // Fixed content type
                                    cmd.Parameters.AddWithValue("@Data", bytes);
                                    cmd.Parameters.AddWithValue("@DocumentType", DocType);
                                    cmd.Parameters.AddWithValue("@InPaymentId", MsgNO);
                                    cmd.Parameters.AddWithValue("@TouchUser", Touch_user);
                                    cmd.Parameters.AddWithValue("@TouchTime", strTime);
                                    cmd.Parameters.AddWithValue("@filePath", path);
                                    cmd.Parameters.AddWithValue("@FileSizeKB", fileSizeKB);

                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                    infi++;
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        $"alert('Error uploading {filename}: {ex.Message}');", true);
                }
            }

            // Update UI elements
            DrpDocType.ClearSelection();
            DrpDocType.Items.FindByText("--Select--").Selected = true;
            BindGrid();
            updoc.Update();
        }

        protected void DrpInwardtrasMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            string TransMode = DrpInwardtrasMode.SelectedItem.ToString();

            lbltransmode.Text = TransMode;
            if (DrpInwardtrasMode.SelectedItem.ToString() != "--Select--")
            {

                TextMode.Text = TransMode;
                InwardFlight.Visible = false;
                InwardSea.Visible = false;
                InwardOther.Visible = false;
                //ContainerDetails.Visible = false;

                if (TextMode.Text == "1 : Sea")
                {
                    InwardSea.Visible = true;
                    //ContainerDetails.Visible = false;
                    inhbl.Visible = true;
                    inhab.Visible = false;
                    phawb.Visible = false;
                    carArrival.Visible = true;
                    carLoadingPort.Visible = true;
                    InwardName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    InwardCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    DrpTotalGrossWeight.ClearSelection();
                    DrpTotalGrossWeight.Items.FindByText("TNE").Selected = true;

                }
                else if (TextMode.Text == "2 : Rail" || TextMode.Text == "3 : Road" || TextMode.Text == "5 : Mail" || TextMode.Text == "7 : Pipeline" || TextMode.Text == "6 : Multi-model(Not in use)")
                {
                    InwardOther.Visible = true;
                    //ContainerDetails.Visible = false;
                    inhab.Visible = true;
                    inhbl.Visible = false;
                    phawb.Visible = false;
                    carLoadingPort.Visible = true;
                    carArrival.Visible = true;

                    InwardName.BackColor = System.Drawing.Color.White;
                    InwardCRUEI.BackColor = System.Drawing.Color.White;

                }
                else if (TextMode.Text == "N : Not Required")
                {
                    carLoadingPort.Visible = false;
                    inhab.Visible = false;
                    inhbl.Visible = false;
                    carArrival.Visible = false;
                    InwardName.BackColor = System.Drawing.Color.White;
                    InwardCRUEI.BackColor = System.Drawing.Color.White;

                }
                else if (TextMode.Text == "4 : Air")
                {
                    InwardFlight.Visible = true;
                    //ContainerDetails.Visible = false;
                    inhab.Visible = false;
                    inhbl.Visible = false;
                    phawb.Visible = true;
                    carLoadingPort.Visible = true;
                    InwardName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    InwardCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);

                    DrpTotalGrossWeight.ClearSelection();
                    DrpTotalGrossWeight.Items.FindByText("KGM").Selected = true;

                   

                }

                //if (DrpInwardtrasMode.SelectedItem.ToString() != "--Select--")
                //{
                //    string TransMode1 = DrpInwardtrasMode.SelectedItem.ToString();
                //    TextMode.Text = TransMode1;
                //    InwardFlight.Visible = false;
                //    InwardSea.Visible = false;
                //    InwardOther.Visible = false;
                //    //ContainerDetails.Visible = false;
                //    if (TextMode.Text == "1 : Sea")
                //    {
                //        InwardSea.Visible = true;
                //        //ContainerDetails.Visible = false;
                //        DrpTotalGrossWeight.Items.Clear();
                //        DrpTotalGrossWeight.Items.Add("TNE");
                //        DrpTotalGrossWeight.Items.Add("KGM");
                //        DrpTotalGrossWeight.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
                //    }
                //    else if (TextMode.Text == "2 : Rail" || TextMode.Text == "5 : Mail" || TextMode.Text == "7 : Pipeline" ||  TextMode.Text == "6 : Multi-model(Not in use)")
                //    {
                //        InwardOther.Visible = true;
                //        //ContainerDetails.Visible = true;

                //        string str6ss1 = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                //        obj.dr = obj.ret_dr(str6ss1);
                //        DrpTotalGrossWeight.DataSource = obj.dr;
                //        DrpTotalGrossWeight.DataTextField = "Name";
                //        DrpTotalGrossWeight.DataValueField = "Id";
                //        DrpTotalGrossWeight.DataBind();
                //        obj.closecon();
                //        DrpTotalGrossWeight.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
                //    }

                //    else if (TextMode.Text == "4 : Air")
                //    {
                //        InwardFlight.Visible = true;
                //        //ContainerDetails.Visible = true;
                //        DrpTotalGrossWeight.Items.Clear();
                //        DrpTotalGrossWeight.Items.Add("TNE");
                //        DrpTotalGrossWeight.Items.Add("KGM");
                //        DrpTotalGrossWeight.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
                //    }
                //    else if (TextMode.Text == "3 : Road")
                //    {
                //        InwardOther.Visible = true;
                //        //ContainerDetails.Visible = true;
                //        DrpTotalGrossWeight.Items.Clear();
                //        DrpTotalGrossWeight.Items.Add("KGM");
                //        DrpTotalGrossWeight.Items.Add("TNE");
                //        DrpTotalGrossWeight.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
                //    }
                //}
            }
            else
            {
                InwardFlight.Visible = false;
                InwardSea.Visible = false;
                InwardOther.Visible = false;
                //ContainerDetails.Visible = false;
            }
            //ReqValidatePageLoad();
            upincargo.Update();
            updatepanel1.Update();
            DrpBGIndicator.Focus();

        }


        protected void Unnamed_Click(object sender, EventArgs e)
        {
            string Code = "";
            string qry11 = "SELECT InhouseCode FROM InhouseItemCode where InhouseCode='" + TxtInHouseItem.Text + "'";

            obj.dr = obj.ret_dr(qry11);

            while (obj.dr.Read())
            {
                Code = obj.dr[0].ToString();

            }
            if (Code == "")
            {
                string Touch_user = Session["UserId"].ToString();
                string BGIndicator = "";
                if (ChkBGIndicator.Checked == false)
                {
                    BGIndicator = "N";
                }
                else
                {
                    BGIndicator = "";
                }

                string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string StrQuery = ("INSERT INTO [dbo].[InhouseItemCode] ([InhouseCode],[HSCode],[Description],[Brand],[Model],[DGIndicator],[TouchUser],[TouchTime]) VALUES ('" + TxtInHouseItem.Text + "','" + TxtHSCodeItem.Text + "','" + TxtDescription.Text + "','" + TxtBrand.Text + "','" + TxtModel.Text + "','" + BGIndicator + "','" + Touch_user + "',Convert(VARCHAR,'" + strTime + "',108))");
                obj.exec(StrQuery);
                BindInhouse();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Importer Code Already Exist..');", true);
                //  Response.Write("The Importer Code Already Exist..");
            }
        }

        protected void InhouseSearchItem_TextChanged(object sender, EventArgs e)
        {
            DataTable _objdt = new DataTable();
            _objdt = GetDataFromDataBaseitem(InhouseSearchItem.Text);
            if (_objdt.Rows.Count > 0)
            {
                InhouseGridItem.DataSource = _objdt;
                InhouseGridItem.DataBind();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Inhouse();", true);
            }
        }



        protected void lnkInhouseItem_Click(object sender, EventArgs e)
        {
            var lb = (LinkButton)sender;
            var row = (GridViewRow)lb.NamingContainer;
            if (row != null)
            {
                var lblCode1 = row.FindControl("lblCode") as Label;
                var lblName1 = row.FindControl("lblName") as Label;
                var lblName11 = row.FindControl("lblName1") as Label;
                var cruei1 = row.FindControl("lblCRUEI") as Label;
                var Model = row.FindControl("lblModel") as Label;

                if (lblCode1 != null && lblName1 != null && lblName11 != null && cruei1 != null)
                {
                    //Get values
                    string requestor = lblCode1.Text;
                    string requestType = lblName1.Text;
                    string status = lblName11.Text;
                    string crueis = cruei1.Text;
                    string Model1 = Model.Text;
                    TxtInHouseItem.Text = "";
                    TxtHSCodeItem.Text = "";
                   
                    TxtBrand.Text = "";
                    TxtModel.Text = "";

                    TxtInHouseItem.Text = requestor;
                    TxtHSCodeItem.Text = requestType;

                    if(chklockitemdesc.Checked==true)
                    {

                    }
                    else
                    {
                        TxtDescription.Text = "";
                        TxtDescription.Text = status;
                    }

                        
                    TxtBrand.Text = crueis;
                    TxtModel.Text = Model1;
                    TxtDescription_TextChanged(null, null);

                }

            }
        }
        public DataTable GetDataFromDataBaseitem(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = InhouseSearchItem.Text;

            string str3 = "SELECT * FROM InhouseItemCode where InhouseCode Like '%" + InhouseSearchItem.Text + "%' order by Id desc";
            obj.dr = obj.ret_dr(str3);
            if (obj.dr.HasRows)
            {
                InhouseGridItem.DataSource = obj.dr;

            }
            else
            {
                //Empty DataTable to execute the “else-condition”  
                DataTable dt = new DataTable();
                InhouseGridItem.DataSource = dt;
                InhouseGridItem.DataBind();
            }
            SqlConnection con = new SqlConnection(sqlconn);
            SqlDataAdapter _objda = new SqlDataAdapter(str3, con);
            con.Close();
            _objda.Fill(_objdt);
            return _objdt;
        }

        protected void HSCodeSearchItem_TextChanged(object sender, EventArgs e)
        {
            DataTable _objdt = new DataTable();
            _objdt = GetHSCodeFromDataBase(InhouseSearchItem.Text);
            if (_objdt.Rows.Count > 0)
            {
                HSCodeGridItem.DataSource = _objdt;
                HSCodeGridItem.DataBind();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openHSCode();", true);
            }
        }
        public DataTable GetHSCodeFromDataBase(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = HSCodeSearchItem.Text;

            string str3 = "SELECT top 20 * FROM HSCode where HSCode Like '%" + HSCodeSearchItem.Text + "%' or Description Like '%" + HSCodeSearchItem.Text + "%' order by Id desc";
            obj.dr = obj.ret_dr(str3);
            if (obj.dr.HasRows)
            {
                HSCodeGridItem.DataSource = obj.dr;

            }
            else
            {
                //Empty DataTable to execute the “else-condition”  
                DataTable dt = new DataTable();
                HSCodeGridItem.DataSource = dt;
                HSCodeGridItem.DataBind();
            }
            SqlConnection con = new SqlConnection(sqlconn);
            SqlDataAdapter _objda = new SqlDataAdapter(str3, con);
            con.Close();
            _objda.Fill(_objdt);
            return _objdt;
        }
        protected void InhouseGridItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            InhouseGridItem.PageIndex = e.NewPageIndex;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Inhouse();", true);
            BindInhouse();
        }

        protected void HSCodeGridItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            HSCodeGridItem.PageIndex = e.NewPageIndex;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openHSCode();", true);
            BindHSCode();

            popupHSCODE.Show();
        }


        private void BindInhouse()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Top 20 * FROM InhouseItemCode"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet dt = new DataSet())
                        {
                            sda.Fill(dt);
                            InhouseGridItem.DataSource = dt;
                            InhouseGridItem.DataBind();
                        }
                    }
                }
            }
        }


        private void BindHSCode()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Top 1000 * FROM HSCode"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet dt = new DataSet())
                        {
                            sda.Fill(dt);
                            HSCodeGridItem.DataSource = dt;
                            HSCodeGridItem.DataBind();
                        }
                    }
                }
            }
        }

        private void BindCountry()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Top 20 * FROM Country"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet dt = new DataSet())
                        {
                            sda.Fill(dt);
                            CountryGridItem.DataSource = dt;
                            CountryGridItem.DataBind();
                        }
                    }
                }
            }
        }

        protected void lnkHSCodeItem_Click(object sender, EventArgs e)
        {
            var lb = (LinkButton)sender;
            var row = (GridViewRow)lb.NamingContainer;
            if (row != null)
            {

                var lblName1 = row.FindControl("lblName") as Label;
                var lblName11 = row.FindControl("lblName1") as Label;

                if (lblName1 != null && lblName11 != null)
                {
                    //Get values                   
                    string requestType = lblName1.Text;
                    string status = lblName11.Text;
                    TxtHSCodeItem.Text = "";
                  
                    TxtHSCodeItem.Text = requestType;

                    if(chklockitemdesc.Checked==true)
{

}
else
                    {
                        TxtDescription.Text = "";
                        TxtDescription.Text = status;
}
                   // TxtDescription.Text = status;

                    TxtDescription_TextChanged(null, null);
                    if (TxtHSCodeItem.Text.Trim().StartsWith("87"))
                    {
                        Vehicle.Visible = true;
                        OptionalCharges.Visible = true;
                    }
                    else
                    {
                        OptionalCharges.Visible = false;
                    }
                    string qry11 = "select UOM from HSCode where HSCode='" + TxtHSCodeItem.Text + "'";
                    obj.dr = obj.ret_dr(qry11);
                    while (obj.dr.Read())
                    {
                        string UOm = obj.dr[0].ToString();
                        HSQTYUOM.ClearSelection();
                        HSQTYUOM.Items.FindByText(obj.dr[0].ToString()).Selected = true;




                        //   TxtHSCodeItem.Text = obj.dr[1].ToString();
                        // TxtDescription.Text = obj.dr[2].ToString();

                    }



                }

            }
        }

        protected void TxtHSCodeItem_TextChanged(object sender, EventArgs e)
        {


            InpaymentClass objitem = new InpaymentClass();
            if (TxtHSCodeItem.Text != "")
            {
                AlcoholDiv.Visible = false;
                if (TxtHSCodeItem.Text.Trim().StartsWith("87"))
                {
                    Vehicle.Visible = true;
                    OptionalCharges.Visible = true;
                }
                else
                {
                    Vehicle.Visible = false;
                    OptionalCharges.Visible = false;
                }
                string[] ss = TxtHSCodeItem.Text.Split(':');
                string qry11 = "select DISTINCT UOM from HSCode where HSCode='" + ss[0].ToString() + "'";
                objitem.dr = objitem.ret_dr(qry11);
                while (objitem.dr.Read())
                {
                    string UOm = objitem.dr[0].ToString();
                    if (objitem.dr[0].ToString() != "-")
                    {
                        HSQTYUOM.ClearSelection();
                        HSQTYUOM.Items.FindByText(objitem.dr[0].ToString()).Selected = true;
                    }
                    else
                    {
                        HSQTYUOM.ClearSelection();
                        HSQTYUOM.Items.FindByText(objitem.dr[0].ToString()).Selected = true;
                    }
                }
                hscode(ss[0].ToString());
                string qry1113 = "select * from HSCode where HSCode='" + ss[0].ToString() + "'";
                objitem.dr = objitem.ret_dr(qry1113);

                int typeid = 0;

                while (objitem.dr.Read())
                {
                    typeid = Convert.ToInt32(objitem.dr["DUTYTYPID"].ToString());
                    TxtHSCodeItem.Text = objitem.dr["HSCode"].ToString();

                    if (chklockitemdesc.Checked == true)
                    {

                    }
                    else
                    {
                        TxtDescription.Text = objitem.dr["Description"].ToString();
                    }


                   



                    // Clear the label by default
                    is_inpayment_controlled.Text = string.Empty;

                    // Check if the value exists and is not NULL
                    if (objitem.dr["is_inpayment_controlled"] != DBNull.Value && Convert.ToInt32(objitem.dr["is_inpayment_controlled"]) != 0)
    
                    {
                        // Convert to boolean (true for 1, false for 0)
                        bool isControlled = Convert.ToBoolean(objitem.dr["is_inpayment_controlled"]);

                        // Only set "Controlled" if true (1)
                        if (isControlled)
                        {
                            is_inpayment_controlled.Text = "Controlled Item";
                        }
                        else
                        {
                            is_inpayment_controlled.Text = "";
                        }
                    }
                    else
                    {
                        is_inpayment_controlled.Text = "";
                    }

                    // TxtHSQuantity.Text = objitem.dr["Inpayment"].ToString();
                    uom = objitem.dr["DuitableUom"].ToString();
                    exuom = objitem.dr["Excisedutyuom"].ToString();
                    exrate = objitem.dr["Excisedutyrate"].ToString();
                    crate = objitem.dr["Customsdutyrate"].ToString();
                    cuom = objitem.dr["Customsdutyuom"].ToString();



                    
                }

               

                if ((typeid == 62 || typeid == 63))
                {

                    if (typeid == 62 && HSQTYUOM.SelectedItem.Text == "LTR")
                    {
                        totDuticableQtyDiv.Visible = true;
                        AlcoholDiv.Visible = true;
                    }
                    if (typeid == 63 && HSQTYUOM.SelectedItem.Text == "KGM")
                    {
                        totDuticableQtyDiv.Visible = true;
                        AlcoholDiv.Visible = false;
                    }
                    else if (typeid == 62 && HSQTYUOM.SelectedItem.Text != "LTR")
                    {
                        totDuticableQtyDiv.Visible = true;
                        AlcoholDiv.Visible = false;
                    }
                    else
                    {
                        totDuticableQtyDiv.Visible = true;
                        AlcoholDiv.Visible = true;
                    }



                    TxtExciseDutyRate.Text = exrate;
                    TxtExciseDutyUOM.Text = exuom;
                    TxtCustomsDutyRate.Text = crate;
                    TxtCustomsDutyUOM.Text = cuom;
                    if (uom == "A")
                    {
                        TDQUOM.ClearSelection();
                        TDQUOM.Items.FindByText("--Select--").Selected = true;
                        ddptotDutiableQty.ClearSelection();
                        ddptotDutiableQty.Items.FindByText("--Select--").Selected = true;
                    }


                    else
                    {
                        TDQUOM.ClearSelection();
                        TDQUOM.Items.FindByText(uom).Selected = true;
                        ddptotDutiableQty.ClearSelection();
                        ddptotDutiableQty.Items.FindByText(uom).Selected = true;
                    }



                }
                else if (typeid == 105)
                {
                    TxtExciseDutyRate.Text = exrate;
                    TxtExciseDutyUOM.Text = exuom;
                    TxtCustomsDutyRate.Text = crate;
                    TxtCustomsDutyUOM.Text = cuom;


                    if (uom == "A")
                    {
                        TDQUOM.ClearSelection();
                        TDQUOM.Items.FindByText("--Select--").Selected = true;
                        ddptotDutiableQty.ClearSelection();
                        ddptotDutiableQty.Items.FindByText("--Select--").Selected = true;
                    }


                    else
                    {
                        TDQUOM.ClearSelection();
                        TDQUOM.Items.FindByText(uom).Selected = true;
                        ddptotDutiableQty.ClearSelection();
                        ddptotDutiableQty.Items.FindByText(uom).Selected = true;
                    }
                    totDuticableQtyDiv.Visible = true;

                }
                else if (typeid == 64)
                {
                    if (HSQTYUOM.SelectedItem.Text != "LTR")
                    {
                        totDuticableQtyDiv.Visible = true;
                        AlcoholDiv.Visible = false;
                    }
                    else
                    {
                        AlcoholDiv.Visible = true;
                        totDuticableQtyDiv.Visible = true;
                    }
                    TxtExciseDutyRate.Text = exrate;
                    TxtExciseDutyUOM.Text = exuom;
                    TxtCustomsDutyRate.Text = crate;
                    TxtCustomsDutyUOM.Text = cuom;
                    if (uom == "A")
                    {
                        TDQUOM.ClearSelection();
                        TDQUOM.Items.FindByText("--Select--").Selected = true;
                        ddptotDutiableQty.ClearSelection();
                        ddptotDutiableQty.Items.FindByText("--Select--").Selected = true;
                    }


                    else
                    {
                        TDQUOM.ClearSelection();
                        TDQUOM.Items.FindByText(uom).Selected = true;
                        ddptotDutiableQty.ClearSelection();
                        ddptotDutiableQty.Items.FindByText(uom).Selected = true;
                    }
                }
                else if (typeid == 61 && HSQTYUOM.SelectedItem.Text == "LTR")
                {
                    totDuticableQtyDiv.Visible = true;
                    AlcoholDiv.Visible = true;
                    TxtExciseDutyRate.Text = exrate;
                    TxtExciseDutyUOM.Text = exuom;
                    TxtCustomsDutyRate.Text = crate;
                    TxtCustomsDutyUOM.Text = cuom;
                    if (uom == "A")
                    {
                        TDQUOM.ClearSelection();
                        TDQUOM.Items.FindByText("--Select--").Selected = true;
                        ddptotDutiableQty.ClearSelection();
                        ddptotDutiableQty.Items.FindByText("--Select--").Selected = true;
                    }


                    else
                    {
                        TDQUOM.ClearSelection();
                        TDQUOM.Items.FindByText(uom).Selected = true;
                        ddptotDutiableQty.ClearSelection();
                        ddptotDutiableQty.Items.FindByText(uom).Selected = true;
                    }
                }




                else if (typeid == 61 && HSQTYUOM.SelectedItem.Text == "KGM")
                {
                    totDuticableQtyDiv.Visible = true;
                    // AlcoholDiv.Visible = true;
                    TxtExciseDutyRate.Text = exrate;
                    TxtExciseDutyUOM.Text = exuom;
                    TxtCustomsDutyRate.Text = crate;
                    TxtCustomsDutyUOM.Text = cuom;
                    if (uom == "A")
                    {
                        TDQUOM.ClearSelection();
                        TDQUOM.Items.FindByText("--Select--").Selected = true;
                        ddptotDutiableQty.ClearSelection();
                        ddptotDutiableQty.Items.FindByText("--Select--").Selected = true;
                    }


                    else
                    {
                        TDQUOM.ClearSelection();
                        TDQUOM.Items.FindByText(uom).Selected = true;
                        ddptotDutiableQty.ClearSelection();
                        ddptotDutiableQty.Items.FindByText(uom).Selected = true;
                    }

                }
                else if (typeid == 79)
                {
                    if (uom == "A")
                    {
                        TDQUOM.ClearSelection();
                        TDQUOM.Items.FindByText("--Select--").Selected = true;
                        ddptotDutiableQty.ClearSelection();
                        ddptotDutiableQty.Items.FindByText("--Select--").Selected = true;
                    }


                    else
                    {
                        TDQUOM.ClearSelection();
                        TDQUOM.Items.FindByText(uom).Selected = true;
                        ddptotDutiableQty.ClearSelection();
                        ddptotDutiableQty.Items.FindByText(uom).Selected = true;
                    }

                    totDuticableQtyDiv.Visible = false;

                }
                else
                {

                    if (uom == "A")
                    {
                        TDQUOM.ClearSelection();
                        TDQUOM.Items.FindByText("--Select--").Selected = true;
                        ddptotDutiableQty.ClearSelection();
                        ddptotDutiableQty.Items.FindByText("--Select--").Selected = true;
                    }


                    else
                    {
                        TDQUOM.ClearSelection();
                        TDQUOM.Items.FindByText(uom).Selected = true;
                        ddptotDutiableQty.ClearSelection();
                        ddptotDutiableQty.Items.FindByText(uom).Selected = true;
                    }


                    TxtExciseDutyRate.Text = "0";
                    TxtExciseDutyUOM.Text = "";
                    TxtCustomsDutyRate.Text = "0";
                    TxtCustomsDutyUOM.Text = "";

                    totDuticableQtyDiv.Visible = true;
                    AlcoholDiv.Visible = false;
                }


            }
            else
            {
                TxtDescription.Text = "";
            }
           
            TxtDescription_TextChanged(null, null);
            upinitem.Update();
            TxtCountryItem.Focus();

            BindProduct1();
        }

        protected void ChkSea1_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkSea1.Checked == true)
            {
                SEA.Visible = true;
                return;
            }
            else
            {
                SEA.Visible = false;
            }
            chkcnb.Focus();
        }

        protected void SeaGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (ViewState["CurrentTable2"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable2"];
                DataRow drCurrentRow = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                if (dt.Rows.Count > 1)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["CurrentTable2"] = dt;
                    SeaGrid.DataSource = dt;
                    SeaGrid.DataBind();

                    for (int i = 0; i < ContarinerGrid.Rows.Count - 1; i++)
                    {
                        SeaGrid.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                    }
                    SetPreviousData2cp();
                }
            }
        }

        private void SetPreviousData2cp()
        {

            int rowIndex = 0;

            if (ViewState["CurrentTable26"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTable26"];

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        TextBox box1 = (TextBox)SeaGrid.Rows[rowIndex].Cells[1].FindControl("TextBox1");

                        TextBox box2 = (TextBox)SeaGrid.Rows[rowIndex].Cells[2].FindControl("TextBox2");

                        TextBox box3 = (TextBox)SeaGrid.Rows[rowIndex].Cells[3].FindControl("TextBox3");



                        box1.Text = dt.Rows[i]["Processing Code1"].ToString();

                        box2.Text = dt.Rows[i]["Processing Code2"].ToString();

                        box3.Text = dt.Rows[i]["Processing Code3"].ToString();



                        rowIndex++;

                    }

                }

            }

        }

        protected void btnSeaStr_Click(object sender, EventArgs e)
        {
            DataTable dtCurrent = ViewState["CurrentTable26"] as DataTable;

            // Check if current rows are already 5
            if (dtCurrent != null && dtCurrent.Rows.Count >= 5)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You can only add up to 5 rows.');", true);
                return;
            }

            // Check if there are existing rows and validate the last row's inputs
            if (SeaGrid.Rows.Count > 0) // Replace "YourGridViewID" with your actual GridView ID
            {
                int lastRowIndex = SeaGrid.Rows.Count - 1;

                // Replace these with your actual control IDs from the grid
                TextBox box1 = (TextBox)SeaGrid.Rows[lastRowIndex].Cells[1].FindControl("TextBox1");
                TextBox box2 = (TextBox)SeaGrid.Rows[lastRowIndex].Cells[2].FindControl("TextBox2");
                TextBox box3 = (TextBox)SeaGrid.Rows[lastRowIndex].Cells[3].FindControl("TextBox3");
                // Add more TextBox references if needed

                if (string.IsNullOrWhiteSpace(box1.Text))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please fill all fields in the previous row before adding a new one.');", true);
                    return;
                }
            }

            if (dtCurrent == null || dtCurrent.Rows.Count == 0)
            {
                SetInitialRow2cp();
            }
            else
            {
                AddNewRowToGrid2cp();
            }
        }

        private void SetInitialRow2cp()
        {

            DataTable dt = new DataTable();

            DataRow dr = null;

            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));

            dt.Columns.Add(new DataColumn("Processing Code1", typeof(string)));

            dt.Columns.Add(new DataColumn("Processing Code2", typeof(string)));

            dt.Columns.Add(new DataColumn("Processing Code3", typeof(string)));

            dr = dt.NewRow();

            dr["RowNumber"] = 1;

            dr["Processing Code1"] = string.Empty;

            dr["Processing Code2"] = string.Empty;

            dr["Processing Code3"] = string.Empty;

            dt.Rows.Add(dr);

            //dr = dt.NewRow();



            //Store the DataTable in ViewState

            ViewState["CurrentTable26"] = dt;

            SeaGrid.DataSource = dt;

            SeaGrid.DataBind();
            //SeaGrid.Columns[0].Visible = false;

        }

        private void AddNewRowToGrid2cp()
        {

            int rowIndex = 0;



            if (ViewState["CurrentTable26"] != null)
            {

                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable26"];

                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {

                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {

                        //extract the TextBox values

                        TextBox box1 = (TextBox)SeaGrid.Rows[rowIndex].Cells[1].FindControl("TextBox1");

                        TextBox box2 = (TextBox)SeaGrid.Rows[rowIndex].Cells[2].FindControl("TextBox2");

                        TextBox box3 = (TextBox)SeaGrid.Rows[rowIndex].Cells[3].FindControl("TextBox3");



                        drCurrentRow = dtCurrentTable.NewRow();

                        drCurrentRow["RowNumber"] = i + 1;



                        dtCurrentTable.Rows[i - 1]["Processing Code1"] = box1.Text;

                        dtCurrentTable.Rows[i - 1]["Processing Code2"] = box2.Text;

                        dtCurrentTable.Rows[i - 1]["Processing Code3"] = box3.Text;



                        rowIndex++;

                    }

                    dtCurrentTable.Rows.Add(drCurrentRow);

                    ViewState["CurrentTable26"] = dtCurrentTable;



                    SeaGrid.DataSource = dtCurrentTable;

                    SeaGrid.DataBind();
                    //SeaGrid.Columns[0].Visible = false;
                }

            }

            else
            {

                //Response.Write("ViewState is null");

            }



            //Set Previous Data on Postbacks

            SetPreviousData2cp();

        }

        private void hscode(string hscode)
        {

          


            InpaymentClass objhsn = new InpaymentClass();
            string qry11s2 = "select * from [CommonMasterType] as a , HSCode as b where a.Id=b.Typeid  and HSCode='" + hscode + "' and InPayment=1";
            objhsn.dr = objhsn.ret_dr(qry11s2);
            if (objhsn.dr.Read())
            {
                // TYPEId = obj.dr["Id"].ToString();
                lblhserror.Visible = true;
                lblhserror.Text = objhsn.dr["Type"].ToString();

            }
            else
            {
                lblhserror.Visible = false;
                lblhserror.Text = "";
            }

            string dutable = "select * from [CommonMasterType] as a , HSCode as b where a.Id=b.DUTYTYPID  and HSCode='" + hscode + "' and InPayment=1";
            objhsn.dr = objhsn.ret_dr(dutable);
            if (objhsn.dr.Read())
            {
                // TYPEId = obj.dr["Id"].ToString();
                lbldhserror.Visible = true;
                lbldhserror.Text = objhsn.dr["Type"].ToString();

            }
            else
            {
                lbldhserror.Visible = false;
                lbldhserror.Text = "";
            }



        }
        protected void CountrySearchItem_TextChanged(object sender, EventArgs e)
        {
            DataTable _objdt = new DataTable();
            _objdt = GetCountryFromDataBase(CountrySearchItem.Text);
            if (_objdt.Rows.Count > 0)
            {
                CountryGridItem.DataSource = _objdt;
                CountryGridItem.DataBind();
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openCountry();", true);
            }
        }
        public DataTable GetCountryFromDataBase(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = TxtCountryItem.Text;

            string str3 = "SELECT * FROM Country where CountryCode Like '%" + CountrySearchItem.Text.Replace("'", "''") + "%' or Description Like '%" + CountrySearchItem.Text.Replace("'", "''") + "%' order by Id desc";
            obj.dr = obj.ret_dr(str3);
            if (obj.dr.HasRows)
            {
                CountryGridItem.DataSource = obj.dr;

            }
            else
            {
                //Empty DataTable to execute the “else-condition”  
                DataTable dt = new DataTable();
                CountryGridItem.DataSource = dt;
                CountryGridItem.DataBind();
            }
            SqlConnection con = new SqlConnection(sqlconn);
            SqlDataAdapter _objda = new SqlDataAdapter(str3, con);
            con.Close();
            _objda.Fill(_objdt);
            return _objdt;
        }
        protected void CountryGridItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CountryGridItem.PageIndex = e.NewPageIndex;
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openCountry();", true);
            popupcountryoforgin.Show();
            //popupcountryoforgin.X = 300;
            //popupcountryoforgin.Y = 100;
            BindCountry();
        }

        protected void lnkCountryItem_Click(object sender, EventArgs e)
        {
            var lb = (LinkButton)sender;
            var row = (GridViewRow)lb.NamingContainer;
            if (row != null)
            {

                var lblName1 = row.FindControl("lblName") as Label;
                var lblName11 = row.FindControl("lblName1") as Label;

                if (lblName1 != null && lblName11 != null)
                {
                    //Get values                   
                    string requestType = lblName1.Text;
                    string status = lblName11.Text;
                    // TxtCountryItem.Text = "";
                    txtcname.Text = status;
                    //TxtHSCode.Text = requestType;
                    TxtCountryItem.Text = requestType;
                }

            }
        }

        protected void TxtCountryItem_TextChanged(object sender, EventArgs e)
        {
            if (TxtCountryItem.Text != "")
            {
                string[] ss = TxtCountryItem.Text.Split(':');
                string qry11 = "select * from Country where CountryCode='" + ss[0].ToString() + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    TxtCountryItem.Text = obj.dr[1].ToString();
                    txtcname.Text = obj.dr[2].ToString();
                }
            }

            ChkBGIndicator.Focus();
        }

        //Product Code 1
        private void ProductCode1()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));
            dt.Columns.Add(new DataColumn("Column2", typeof(string)));
            dt.Columns.Add(new DataColumn("Column3", typeof(string)));
            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Column1"] = string.Empty;
            dr["Column2"] = string.Empty;
            dr["Column3"] = string.Empty;
            dt.Rows.Add(dr);
            ViewState["ProductCode1"] = dt;
            ProductCode1Grid1.DataSource = dt;
            ProductCode1Grid1.DataBind();



        }
        private void AddProductCode1Grid()
        {
            int rowIndex = 0;
            if (ViewState["ProductCode1"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["ProductCode1"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values
                        TextBox box1 = (TextBox)ProductCode1Grid1.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                        TextBox box2 = (TextBox)ProductCode1Grid1.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                        TextBox box3 = (TextBox)ProductCode1Grid1.Rows[rowIndex].Cells[3].FindControl("TextBox3");
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = i + 1;
                        dtCurrentTable.Rows[i - 1]["Column1"] = box1.Text;
                        dtCurrentTable.Rows[i - 1]["Column2"] = box2.Text;
                        dtCurrentTable.Rows[i - 1]["Column3"] = box3.Text;
                        rowIndex++;
                    }

                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["ProductCode1"] = dtCurrentTable;
                    ProductCode1Grid1.DataSource = dtCurrentTable;
                    ProductCode1Grid1.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            //Set Previous Data on Postbacks
            SetPreviousData1();

        }
        private void SetPreviousData1()
        {
            int rowIndex = 0;
            if (ViewState["ProductCode1"] != null)
            {
                DataTable dt = (DataTable)ViewState["ProductCode1"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox box1 = (TextBox)ProductCode1Grid1.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                        TextBox box2 = (TextBox)ProductCode1Grid1.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                        TextBox box3 = (TextBox)ProductCode1Grid1.Rows[rowIndex].Cells[3].FindControl("TextBox3");
                        box1.Text = dt.Rows[i]["Column1"].ToString();
                        box2.Text = dt.Rows[i]["Column2"].ToString();
                        box3.Text = dt.Rows[i]["Column3"].ToString();
                        rowIndex++;
                    }
                }
            }
        }

        public DataTable GetProductCodes1FromDataBase(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = ProductCode1Search.Text;
            string str3 = "";
            if (!string.IsNullOrWhiteSpace(TxtHSCodeItem.Text))
            {
                str3 = "SELECT * FROM CASCProductCodes where CASCCode Like '%" + ProductCode1Search.Text + "%' and HSCode='" + TxtHSCodeItem.Text + "' order by Id desc";
            }
            else
            {
                str3 = "SELECT * FROM CASCProductCodes where CASCCode Like '%" + ProductCode1Search.Text + "%' order by Id desc";
            }
            obj.dr = obj.ret_dr(str3);
            if (obj.dr.HasRows)
            {
                ProductCode1Grid.DataSource = obj.dr;

            }
            else
            {
                //Empty DataTable to execute the “else-condition”  
                DataTable dt = new DataTable();
                ProductCode1Grid.DataSource = dt;
                ProductCode1Grid.DataBind();
            }
            SqlConnection con = new SqlConnection(sqlconn);
            SqlDataAdapter _objda = new SqlDataAdapter(str3, con);
            con.Close();
            _objda.Fill(_objdt);
            return _objdt;
        }

        protected void ProductCode1Search_TextChanged(object sender, EventArgs e)
        {
            DataTable _objdt = new DataTable();
            _objdt = GetProductCodes1FromDataBase(ProductCode1Search.Text);
            if (_objdt.Rows.Count > 0)
            {
                ProductCode1Grid.DataSource = _objdt;
                Session["PrctTbl"] = _objdt;
                ProductCode1Grid.DataBind();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Product1();", true);
            }
        }
        protected void showSessionData() // create another method to display sessioned data
        {
            if (dropdownlist5.SelectedValue.ToString() == "All")
            {
                DataTable pdt = (DataTable)Session["PrctTbl"];
                ProductCode1Grid.DataSource = pdt;
                ProductCode1Grid.DataBind();
            }
            else
            {
                ProductCode1Grid.PageSize = int.Parse(dropdownlist5.SelectedValue);
                DataTable pdt = (DataTable)Session["PrctTbl"];
                ProductCode1Grid.DataSource = pdt;
                ProductCode1Grid.DataBind();
            }
        }
        private void BindProduct1()
        {
            if (!string.IsNullOrWhiteSpace(TxtHSCodeItem.Text))
            {
                string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT Top 100 * FROM CASCProductCodes where HSCode LIKE '%" + TxtHSCodeItem.Text.Trim() + "%'"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataSet dt = new DataSet())
                            {
                                sda.Fill(dt);
                                ProductCode1Grid.PageSize = int.Parse(dropdownlist5.SelectedValue);
                                ProductCode1Grid.DataSource = dt;
                                ProductCode1Grid.DataBind();
                                ProductCode2Grid.DataSource = dt;
                                ProductCode2Grid.DataBind();
                                ProductCode3Grid.DataSource = dt;
                                ProductCode3Grid.DataBind();
                                ProductCode4Grid.DataSource = dt;
                                ProductCode4Grid.DataBind();
                                ProductCode5Grid.DataSource = dt;
                                ProductCode5Grid.DataBind();
                                Session["PrctTbl"] = dt;
                            }
                        }
                    }
                }
            }
            else
            {
                string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT Top 100 * FROM CASCProductCodes"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataSet dt = new DataSet())
                            {
                                sda.Fill(dt);
                                ProductCode1Grid.DataSource = dt;
                                Session["PrctTbl"] = dt;
                                ProductCode1Grid.DataBind();
                                ProductCode2Grid.DataSource = dt;
                                ProductCode2Grid.DataBind();
                                ProductCode3Grid.DataSource = dt;
                                ProductCode3Grid.DataBind();
                                ProductCode4Grid.DataSource = dt;
                                ProductCode4Grid.DataBind();
                                ProductCode5Grid.DataSource = dt;
                                ProductCode5Grid.DataBind();
                                Session["PrctTbl"] = dt;
                            }
                        }
                    }
                }
            }

        }


        protected void lnkProductCode1_Command(object sender, CommandEventArgs e)
        {
            var lb = (LinkButton)sender;
            var row = (GridViewRow)lb.NamingContainer;
            if (row != null)
            {

                var lblName1 = row.FindControl("lblName") as Label;
                var lblName11 = row.FindControl("lblName1") as Label;
                var lblumo = row.FindControl("lblUOM") as Label;
                if (lblName1 != null && lblName11 != null)
                {
                    //Get values                   
                    string requestType = lblName1.Text;
                    string status = lblName11.Text;
                    string struom = lblumo.Text;
                    TxtProductCode1.Text = "";

                    //TxtHSCode.Text = requestType;
                    TxtProductCode1.Text = requestType;
                    DrpP1.Text = struom;
                }

            }
        }

        protected void TxtProductCode1_TextChanged(object sender, EventArgs e)
        {
            if (TxtProductCode1.Text != "")
            {
                string qry11 = "select [CASCCode] from CASCProductCodes where CASCCode='" + TxtProductCode1.Text + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    TxtProductCode1.Text = obj.dr[0].ToString();


                }
            }
        }





        protected void ProductCode1Add_Click(object sender, EventArgs e)
        {
            AddProductCode1Grid();
        }

        protected void ProductCode1Grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ProductCode1Grid.PageIndex = e.NewPageIndex;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Product1();", true);
            BindProduct1();
           // showSessionData();
        }
        protected void dropdownlist5_SelectedIndexChanged(object sender, EventArgs e)
        {
            showSessionData();
            //don't call datashow() method in this call only showsessionData();

        }
        //Product Code2
        private void ProductCode2()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));
            dt.Columns.Add(new DataColumn("Column2", typeof(string)));
            dt.Columns.Add(new DataColumn("Column3", typeof(string)));
            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Column1"] = string.Empty;
            dr["Column2"] = string.Empty;
            dr["Column3"] = string.Empty;
            dt.Rows.Add(dr);
            ViewState["ProductCode2"] = dt;
            ProductCode2Grid1.DataSource = dt;
            ProductCode2Grid1.DataBind();

        }
        private void AddProductCode2Grid()
        {
            int rowIndex = 0;
            if (ViewState["ProductCode2"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["ProductCode2"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values
                        TextBox box1 = (TextBox)ProductCode2Grid1.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                        TextBox box2 = (TextBox)ProductCode2Grid1.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                        TextBox box3 = (TextBox)ProductCode2Grid1.Rows[rowIndex].Cells[3].FindControl("TextBox3");
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = i + 1;
                        dtCurrentTable.Rows[i - 1]["Column1"] = box1.Text;
                        dtCurrentTable.Rows[i - 1]["Column2"] = box2.Text;
                        dtCurrentTable.Rows[i - 1]["Column3"] = box3.Text;
                        rowIndex++;
                    }

                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["ProductCode2"] = dtCurrentTable;
                    ProductCode2Grid1.DataSource = dtCurrentTable;
                    ProductCode2Grid1.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            //Set Previous Data on Postbacks
            SetPreviousData2();

        }
        private void SetPreviousData2()
        {
            int rowIndex = 0;
            if (ViewState["ProductCode2"] != null)
            {
                DataTable dt = (DataTable)ViewState["ProductCode2"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox box1 = (TextBox)ProductCode2Grid1.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                        TextBox box2 = (TextBox)ProductCode2Grid1.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                        TextBox box3 = (TextBox)ProductCode2Grid1.Rows[rowIndex].Cells[3].FindControl("TextBox3");
                        box1.Text = dt.Rows[i]["Column1"].ToString();
                        box2.Text = dt.Rows[i]["Column2"].ToString();
                        box3.Text = dt.Rows[i]["Column3"].ToString();
                        rowIndex++;
                    }
                }
            }
        }



        public DataTable GetProductCodes2FromDataBase(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = ProductCode2Search.Text;

            string str3 = "SELECT * FROM CASCProductCodes where CASCCode Like '%" + ProductCode2Search.Text + "%' order by Id desc";
            obj.dr = obj.ret_dr(str3);
            if (obj.dr.HasRows)
            {
                ProductCode2Grid.DataSource = obj.dr;

            }
            else
            {
                //Empty DataTable to execute the “else-condition”  
                DataTable dt = new DataTable();
                ProductCode2Grid.DataSource = dt;
                ProductCode2Grid.DataBind();
            }
            SqlConnection con = new SqlConnection(sqlconn);
            SqlDataAdapter _objda = new SqlDataAdapter(str3, con);
            con.Close();
            _objda.Fill(_objdt);
            return _objdt;
        }
        protected void ProductCode2Search_TextChanged(object sender, EventArgs e)
        {



            DataTable _objdt = new DataTable();
            _objdt = GetProductCodes2FromDataBase(ProductCode2Search.Text);
            if (_objdt.Rows.Count > 0)
            {
                ProductCode2Grid.DataSource = _objdt;
                ProductCode2Grid.DataBind();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Product2();", true);
            }

        }

        protected void ProductCode2Grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ProductCode2Grid.PageIndex = e.NewPageIndex;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Product2();", true);
            BindProduct2();
        }
        private void BindProduct2()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Top 100 * FROM CASCProductCodes"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            ProductCode2Grid.DataSource = dt;
                            ProductCode2Grid.DataBind();
                        }
                    }
                }
            }
        }
        protected void lnkProductCode2_Command(object sender, CommandEventArgs e)
        {
            var lb = (LinkButton)sender;
            var row = (GridViewRow)lb.NamingContainer;
            if (row != null)
            {

                var lblName1 = row.FindControl("lblName") as Label;
                var lblName11 = row.FindControl("lblName1") as Label;

                if (lblName1 != null && lblName11 != null)
                {
                    //Get values                   
                    string requestType = lblName1.Text;
                    string status = lblName11.Text;
                    TxtProductCode2.Text = "";

                    //TxtHSCode.Text = requestType;
                    TxtProductCode2.Text = requestType;
                }

            }
        }

        protected void TxtProductCode2_TextChanged(object sender, EventArgs e)
        {
            if (TxtProductCode2.Text != "")
            {
                string qry11 = "select [CASCCode] from CASCProductCodes where CASCCode='" + TxtProductCode2.Text + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    TxtProductCode2.Text = obj.dr[0].ToString();


                }
            }
        }

        protected void ProductCode2Add_Click(object sender, EventArgs e)
        {
            AddProductCode2Grid();
        }
        //Product Code3
        private void BindProduct3()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Top 100 * FROM CASCProductCodes"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            ProductCode3Grid.DataSource = dt;
                            ProductCode3Grid.DataBind();
                        }
                    }
                }
            }
        }
        private void ProductCode3()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));
            dt.Columns.Add(new DataColumn("Column2", typeof(string)));
            dt.Columns.Add(new DataColumn("Column3", typeof(string)));
            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Column1"] = string.Empty;
            dr["Column2"] = string.Empty;
            dr["Column3"] = string.Empty;
            dt.Rows.Add(dr);
            ViewState["ProductCode3"] = dt;
            ProductCode3Grid1.DataSource = dt;
            ProductCode3Grid1.DataBind();

        }
        private void AddProductCode3Grid()
        {
            int rowIndex = 0;
            if (ViewState["ProductCode3"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["ProductCode3"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values
                        TextBox box1 = (TextBox)ProductCode3Grid1.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                        TextBox box2 = (TextBox)ProductCode3Grid1.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                        TextBox box3 = (TextBox)ProductCode3Grid1.Rows[rowIndex].Cells[3].FindControl("TextBox3");
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = i + 1;
                        dtCurrentTable.Rows[i - 1]["Column1"] = box1.Text;
                        dtCurrentTable.Rows[i - 1]["Column2"] = box2.Text;
                        dtCurrentTable.Rows[i - 1]["Column3"] = box3.Text;
                        rowIndex++;
                    }

                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["ProductCode3"] = dtCurrentTable;
                    ProductCode3Grid1.DataSource = dtCurrentTable;
                    ProductCode3Grid1.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            //Set Previous Data on Postbacks
            SetPreviousData3();

        }
        private void SetPreviousData3()
        {
            int rowIndex = 0;
            if (ViewState["ProductCode3"] != null)
            {
                DataTable dt = (DataTable)ViewState["ProductCode3"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox box1 = (TextBox)ProductCode3Grid1.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                        TextBox box2 = (TextBox)ProductCode3Grid1.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                        TextBox box3 = (TextBox)ProductCode3Grid1.Rows[rowIndex].Cells[3].FindControl("TextBox3");
                        box1.Text = dt.Rows[i]["Column1"].ToString();
                        box2.Text = dt.Rows[i]["Column2"].ToString();
                        box3.Text = dt.Rows[i]["Column3"].ToString();
                        rowIndex++;
                    }
                }
            }
        }



        public DataTable GetProductCodes3FromDataBase(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = ProductCode3Search.Text;

            string str3 = "SELECT * FROM CASCProductCodes where CASCCode Like '%" + ProductCode3Search.Text + "%' order by Id desc";
            obj.dr = obj.ret_dr(str3);
            if (obj.dr.HasRows)
            {
                ProductCode3Grid.DataSource = obj.dr;

            }
            else
            {
                //Empty DataTable to execute the “else-condition”  
                DataTable dt = new DataTable();
                ProductCode3Grid.DataSource = dt;
                ProductCode3Grid.DataBind();
            }
            SqlConnection con = new SqlConnection(sqlconn);
            SqlDataAdapter _objda = new SqlDataAdapter(str3, con);
            con.Close();
            _objda.Fill(_objdt);
            return _objdt;
        }
        protected void ProductCode3Search_TextChanged(object sender, EventArgs e)
        {

            DataTable _objdt = new DataTable();
            _objdt = GetProductCodes3FromDataBase(ProductCode3Search.Text);
            if (_objdt.Rows.Count > 0)
            {
                ProductCode3Grid.DataSource = _objdt;
                ProductCode3Grid.DataBind();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Product3();", true);
            }
        }

        protected void ProductCode3Grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ProductCode3Grid.PageIndex = e.NewPageIndex;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Product3();", true);
            BindProduct3();
        }

        protected void lnkProductCode3_Command(object sender, CommandEventArgs e)
        {
            var lb = (LinkButton)sender;
            var row = (GridViewRow)lb.NamingContainer;
            if (row != null)
            {

                var lblName1 = row.FindControl("lblName") as Label;
                var lblName11 = row.FindControl("lblName1") as Label;

                if (lblName1 != null && lblName11 != null)
                {
                    //Get values                   
                    string requestType = lblName1.Text;
                    string status = lblName11.Text;
                    TxtProductCode3.Text = "";

                    //TxtHSCode.Text = requestType;
                    TxtProductCode3.Text = requestType;
                }

            }
        }

        protected void TxtProductCode3_TextChanged(object sender, EventArgs e)
        {
            if (TxtProductCode3.Text != "")
            {
                string qry11 = "select [CASCCode] from CASCProductCodes where CASCCode='" + TxtProductCode3.Text + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    TxtProductCode3.Text = obj.dr[0].ToString();


                }
            }
        }

        protected void ProductCode3Add_Click(object sender, EventArgs e)
        {
            AddProductCode3Grid();
        }
















        private void BindImportparty()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id,Code,Name,Name1,CRUEI FROM Importer"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet dt = new DataSet())
                        {
                            sda.Fill(dt);
                            ImportPartyGrid.DataSource = dt;
                            ImportPartyGrid.DataBind();
                        }
                    }
                }
            }
        }

        protected void ImportPartySearch_TextChanged(object sender, EventArgs e)
        {
            DataTable _objdt = new DataTable();
            _objdt = GetImportPartyDataFromDataBase(ImporterSearch.Text);
            if (_objdt.Rows.Count > 0)
            {
                ImportPartyGrid.DataSource = _objdt;
                ImportPartyGrid.DataBind();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalImportParty();", true);
            }
        }

        protected void ImportPartyGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ImportPartyGrid.PageIndex = e.NewPageIndex;

            BindImport();
            popupinvimp.Show();
            popupinvimp.X = 400;
            popupinvimp.Y = 100;

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalImportParty();", true);
        }

        protected void LnkImportParty_Command(object sender, CommandEventArgs e)
        {
            var lb = (LinkButton)sender;
            var row = (GridViewRow)lb.NamingContainer;
            if (row != null)
            {
                var lblCode1 = row.FindControl("lblCode") as Label;
                var lblName1 = row.FindControl("lblName") as Label;
                var lblName11 = row.FindControl("lblName1") as Label;
                var cruei1 = row.FindControl("lblCRUEI") as Label;

                if (lblCode1 != null && lblName1 != null && lblName11 != null && cruei1 != null)
                {
                    //Get values
                    string requestor = lblCode1.Text;
                    string requestType = lblName1.Text;
                    string status = lblName11.Text;
                    string crueis = cruei1.Text;


                    TxtImppartyCode.Text = "";
                    TxtImppartyName.Text = "";
                    TxtImppartyName1.Text = "";
                    TxtImppartyCRUEI.Text = "";
                    TxtImppartyCode.Text = requestor;
                    TxtImppartyName.Text = requestType;
                    TxtImppartyName1.Text = status;
                    TxtImppartyCRUEI.Text = crueis;

                }

            }
        }
        public DataTable GetImportPartyDataFromDataBase(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = ImportPartySearch.Text;

            string str3 = "SELECT Id,Code,Name,Name1,CRUEI FROM Importer where Code Like '%" + ImportPartySearch.Text + "%' or Name Like '%" + ImportPartySearch.Text + "%' order by Id desc";
            obj.dr = obj.ret_dr(str3);
            if (obj.dr.HasRows)
            {
                ImportPartyGrid.DataSource = obj.dr;

            }
            else
            {
                //Empty DataTable to execute the “else-condition”  
                DataTable dt = new DataTable();
                ImportPartyGrid.DataSource = dt;
                ImportPartyGrid.DataBind();
            }
            SqlConnection con = new SqlConnection(sqlconn);
            SqlDataAdapter _objda = new SqlDataAdapter(str3, con);
            con.Close();
            _objda.Fill(_objdt);
            return _objdt;
        }

        protected void TxtImppartyCode_TextChanged(object sender, EventArgs e)
        {
            if (TxtImppartyCode.Text != "")
            {
                string[] ss = TxtImppartyCode.Text.Split(':');
                string qry11 = "select * from Importer where Code='" + ss[0].ToString().Trim() + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    TxtImppartyCode.Text = obj.dr[1].ToString();
                    TxtImppartyName.Text = obj.dr[2].ToString();
                    TxtImppartyName1.Text = obj.dr[3].ToString();
                    TxtImppartyCRUEI.Text = obj.dr[4].ToString();

                    lblimporterparty.Text = obj.dr[4].ToString() + " - " + obj.dr[2].ToString() + " " + obj.dr[3].ToString();
                }
            }
            else
            {
                TxtImppartyCode.Text = "";
                TxtImppartyName.Text = "";
                TxtImppartyName1.Text = "";
                TxtImppartyCRUEI.Text = "";
            }
            txtinvNo.Focus();
        }

        protected void BtnImpPartyADD_Click(object sender, EventArgs e)
        {
            string Code = "";
            string qry11 = "SELECT Code FROM Importer where Code='" + TxtImppartyCode.Text + "'";

            obj.dr = obj.ret_dr(qry11);

            while (obj.dr.Read())
            {
                Code = obj.dr[0].ToString();

            }
            if (Code == "")
            {
                string Touch_user = Session["UserId"].ToString();

                string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string StrQuery = ("INSERT INTO [dbo].[Importer] ([Code],[Name],[Name1],[CRUEI],[TouchUser],[TouchTime]) VALUES ('" + TxtImppartyCode.Text + "','" + TxtImppartyName.Text + "','" + TxtImppartyName1.Text + "','" + TxtImppartyCRUEI.Text + "','" + Touch_user + "',Convert(VARCHAR,'" + strTime + "',108))");
                obj.exec(StrQuery);
                BindImportparty();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Importer Code Already Exist..');", true);
                //  Response.Write("The Importer Code Already Exist..");
            }

        }
        /// Invoice calculation
        /// 

        protected void Drpcurrency1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblTotalInvoice.Text = "0.00";
            string qry11 = "SELECT CurrencyRate FROM Currency where Currency='" + Drpcurrency1.SelectedItem.ToString() + "'";
            obj.dr = obj.ret_dr(qry11);
            while (obj.dr.Read())
            {

                LblTotalInvoice.Text = obj.dr[0].ToString();
            }
            TxtTotalInvoice_TextChanged(null, null);
            TxtTotalInvoice.Focus();
        }

        protected void Drpcurrency2_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblOtherTaxableCharge.Text = "0.00";
            string qry11 = "SELECT CurrencyRate FROM Currency where Currency='" + Drpcurrency2.SelectedItem.ToString() + "'";
            obj.dr = obj.ret_dr(qry11);
            while (obj.dr.Read())
            {

                lblOtherTaxableCharge.Text = obj.dr[0].ToString();
            }


            if (OtherTaxableChargePer.Text == "0.00")
            {
                TxtOtherTaxableCharge_TextChanged(null, null);
            }
            else
            {
                OtherTaxableChargePer_TextChanged(null, null);
            }

            // TxtFrieghtCharges_TextChanged(null, null);


            TxtOtherTaxableCharge.Focus();
        }

        protected void Drpcurrency3_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblFrieghtCharges.Text = "0.00";
            string qry11 = "SELECT CurrencyRate FROM Currency where Currency='" + Drpcurrency3.SelectedItem.ToString() + "'";
            obj.dr = obj.ret_dr(qry11);
            while (obj.dr.Read())
            {

                LblFrieghtCharges.Text = obj.dr[0].ToString();
            }
            if (FrieghtChargesPer.Text == "0.00")
            {
                TxtFrieghtCharges_TextChanged(null, null);
            }
            else
            {
                FrieghtChargesPer_TextChanged(null, null);
            }
            TxtFrieghtCharges.Focus();
        }

        protected void Drpcurrency4_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblInsuranceCharges.Text = "0.00";
            string qry11 = "SELECT CurrencyRate FROM Currency where Currency='" + Drpcurrency4.SelectedItem.ToString() + "'";
            obj.dr = obj.ret_dr(qry11);
            while (obj.dr.Read())
            {

                lblInsuranceCharges.Text = obj.dr[0].ToString();
            }
            TxtInsuranceCharges_TextChanged(null, null);
            TxtInsuranceCharges.Focus();
        }

        protected void TxtTotalInvoice_TextChanged(object sender, EventArgs e)
        {
            double INV, fright, tot, insurance, excharge, sumins;

            if (TxtTotalInvoice.Text != "")
            {
                //warning c,d
                double a, b;

                bool isAValid = double.TryParse(LblTotalInvoice.Text.Trim(), out a);
                bool isBValid = double.TryParse(TxtTotalInvoice.Text.Trim(), out b);



                // bool isCValid = double.TryParse(TxtTotalInvoice.Text.Trim(), out c);

                if (isAValid && isBValid)
                {
                    string SumInv = string.Format("{0:N}", Convert.ToDouble(Math.Round((a * b), 4).ToString()));
                    SumTotalInvoice.Text = SumInv;

                }



            }
            else
            {
                SumTotalInvoice.Text = "0.00";

            }






            if (InsuranceChargesPer.Text == "")
            {
                InsuranceChargesPer.Text = "0.00";
                TxtInsuranceCharges_TextChanged(null, null);
            }
            if (Convert.ToDecimal(InsuranceChargesPer.Text) >= 1)
            {

                bool INS = double.TryParse(SumTotalInvoice.Text.Trim(), out INV);
                bool freight = double.TryParse(SumInsuranceCharges.Text.Trim(), out fright);
                bool ins = double.TryParse(InsuranceChargesPer.Text.Trim(), out insurance);
                //  bool exrate = double.TryParse(lblInsuranceCharges.Text.Trim(), out excharge);
                tot = INV + fright;
                SumInsuranceCharges.Text = string.Format("{0:N}", Convert.ToDouble(Math.Round((insurance * tot / 100), 4).ToString()));





                //string INSC = string.Format("{0:N}", Convert.ToDouble(Convert.ToDouble(Math.Round((insurance * tot / 100),4)) / excharge).ToString());
                //TxtInsuranceCharges.Text = INSC;




            }
            sumofinsurance();

            bool exrate = double.TryParse(lblInsuranceCharges.Text.Trim(), out excharge);
            bool sum = double.TryParse(SumInsuranceCharges.Text.Trim(), out sumins);

            if (excharge > 0)
            {
                TxtInsuranceCharges.Text = string.Format("{0:N}", Convert.ToDouble(Math.Round((sumins / excharge), 4).ToString()));
            }
            else
            {
                TxtInsuranceCharges.Text = "0.00";
            }


            totalinv();

            OtherTaxableChargePer.Focus();

            //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "addCommas(this)", true);
        }

        protected void totalinv()
        {
            double T1, T2, T3, T4;
            bool A = double.TryParse(SumTotalInvoice.Text.Trim(), out T1);
            bool B = double.TryParse(SumOtherTaxableCharge.Text.Trim(), out T2);
            bool C = double.TryParse(SumFrieghtCharges.Text.Trim(), out T3);
            bool D = double.TryParse(SumInsuranceCharges.Text.Trim(), out T4);
            if (A && B && C && D)
            {
                string SumGSTTo = string.Format("{0:N}", Convert.ToDouble(Math.Round((T1 + T2 + T3 + T4), 2).ToString()));
                LblSumOFTotal.Text = SumGSTTo;

                //  LblSumOFTotal.Text = Math.Round((T1 + T2 + T3 + T4), 2).ToString();
            }
            double GST, Gpere;
            bool G1 = double.TryParse(LblSumOFTotal.Text.Trim(), out GST);
            bool G2 = double.TryParse(LblGSTpercentage.Text.Trim(), out Gpere);
            if (G1 && G2)
                lblGSTAmount.Text = Math.Round((GST * Gpere / 100), 2).ToString();
        }



        protected void TxtOtherTaxableCharge_TextChanged(object sender, EventArgs e)
        {
            if (TxtOtherTaxableCharge.Text != "")
            {
                double a, b;

                bool isAValid = double.TryParse(lblOtherTaxableCharge.Text.Trim(), out a);
                bool isBValid = double.TryParse(TxtOtherTaxableCharge.Text.Trim(), out b);

                if (isAValid && isBValid)
                {
                    string SumOtChrge = string.Format("{0:N}", Convert.ToDouble(Math.Round((a * b), 2).ToString()));
                    SumOtherTaxableCharge.Text = SumOtChrge;
                }
                //   SumOtherTaxableCharge.Text = Math.Round((a * b), 2).ToString();



            }
            else
            {
                SumOtherTaxableCharge.Text = "0.00";
            }
            sumofinsurance();
            double T1, T2;
            bool A = double.TryParse(SumTotalInvoice.Text.Trim(), out T1);
            bool B = double.TryParse(SumOtherTaxableCharge.Text.Trim(), out T2);
            if (A && B)
            {
                string SumGSTTo = string.Format("{0:N}", Convert.ToDouble(Math.Round((T1 + T2), 4).ToString()));
                LblSumOFTotal.Text = SumGSTTo;

                // LblSumOFTotal.Text = Math.Round((T1 + T2), 4).ToString();
            }
            double GST, Gpere;
            bool G1 = double.TryParse(LblSumOFTotal.Text.Trim(), out GST);
            bool G2 = double.TryParse(LblGSTpercentage.Text.Trim(), out Gpere);
            if (G1 && G2)
            {
                string SumGSTTo = string.Format("{0:N}", Convert.ToDouble(Math.Round((GST * Gpere / 100), 2).ToString()));
                lblGSTAmount.Text = SumGSTTo;

                //  lblGSTAmount.Text = Math.Round((GST * Gpere / 100), 2).ToString();
            }
            //warning FC
            double INV, OTC;
            bool invoice = double.TryParse(SumTotalInvoice.Text.Trim(), out INV);
            bool othertax = double.TryParse(SumOtherTaxableCharge.Text.Trim(), out OTC);
            // bool frieghtcharges = double.TryParse(SumTotalInvoice.Text.Trim(), out FC);

            //string INSC = string.Format("{0:N}", Convert.ToDouble(((INV + OTC) / 100).ToString()));
            //TxtInsuranceCharges.Text = INSC;

            //TxtInsuranceCharges.Text = ((INV + OTC) / 100).ToString();
            TxtInsuranceCharges_TextChanged(null, null);

            FrieghtChargesPer.Focus();

        }

        protected void TxtFrieghtCharges_TextChanged(object sender, EventArgs e)
        {
            if (TxtFrieghtCharges.Text != "")
            {
                double a, b;

                bool isAValid = double.TryParse(LblFrieghtCharges.Text.Trim(), out a);
                bool isBValid = double.TryParse(TxtFrieghtCharges.Text.Trim(), out b);

                if (isAValid && isBValid)
                {
                    string SumFrChrge = string.Format("{0:N}", Convert.ToDouble(Math.Round((a * b), 4).ToString()));
                    SumFrieghtCharges.Text = SumFrChrge;

                    // SumFrieghtCharges.Text = Math.Round((a * b), 2).ToString();
                }
            }
            else
            {
                SumFrieghtCharges.Text = "0.00";
            }

            sumofinsurance();
            double T1, T2, T3;
            bool A = double.TryParse(SumTotalInvoice.Text.Trim(), out T1);
            bool B = double.TryParse(SumOtherTaxableCharge.Text.Trim(), out T2);
            bool C = double.TryParse(SumFrieghtCharges.Text.Trim(), out T3);
            if (A && B && C)
            {
                string SumGSTTo = string.Format("{0:N}", Convert.ToDouble(Math.Round((T1 + T2 + T3), 4).ToString()));
                LblSumOFTotal.Text = SumGSTTo;

                //  LblSumOFTotal.Text = Math.Round((T1 + T2 + T3), 4).ToString();
            }
            double GST, Gpere;
            bool G1 = double.TryParse(LblSumOFTotal.Text.Trim(), out GST);
            bool G2 = double.TryParse(LblGSTpercentage.Text.Trim(), out Gpere);
            if (G1 && G2)
            {
                string SumGSTTo = string.Format("{0:N}", Convert.ToDouble(Math.Round((GST * Gpere / 100), 4).ToString()));
                lblGSTAmount.Text = SumGSTTo;

                // lblGSTAmount.Text = Math.Round((GST * Gpere / 100), 2).ToString();
            }

            double INV, OTC, FC;
            bool invoice = double.TryParse(SumTotalInvoice.Text.Trim(), out INV);
            bool othertax = double.TryParse(SumOtherTaxableCharge.Text.Trim(), out OTC);
            bool frieghtcharges = double.TryParse(SumFrieghtCharges.Text.Trim(), out FC);

            string INSC = string.Format("{0:N}", Convert.ToDouble(((INV + OTC + FC) / 100).ToString()));
            TxtInsuranceCharges.Text = INSC;

            TxtInsuranceCharges.Text = ((INV + FC) / 100).ToString();
            TxtInsuranceCharges_TextChanged(null, null);
            InsuranceChargesPer.Focus();
        }

        protected void TxtInsuranceCharges_TextChanged(object sender, EventArgs e)
        {
            if (lblInsuranceCharges.Text != "")
            {
                double a, b;

                bool isAValid = double.TryParse(lblInsuranceCharges.Text.Trim(), out a);
                bool isBValid = double.TryParse(TxtInsuranceCharges.Text.Trim(), out b);

                if (isAValid && isBValid)
                {
                    string SumINSrChrge = string.Format("{0:N}", Convert.ToDouble(Math.Round((a * b), 2).ToString()));
                    SumInsuranceCharges.Text = SumINSrChrge;
                }

                SumInsuranceCharges.Text = Math.Round((a * b), 2).ToString();

            }
            else
            {
                SumInsuranceCharges.Text = "0.00";
            }
            sumofinsurance();
            totalinv();
            btnprevinvoice.Focus();
        }

        protected void OtherTaxableChargePer_TextChanged(object sender, EventArgs e)
        {
            if (OtherTaxableChargePer.Text != "")
            {
                if (Drpcurrency2.SelectedItem.ToString() != "--Select--")
                {
                    double a, b, c, d;

                    bool isAValid = double.TryParse(SumTotalInvoice.Text.Trim(), out a);
                    bool isBValid = double.TryParse(OtherTaxableChargePer.Text.Trim(), out b);
                    bool isCValid = double.TryParse(lblOtherTaxableCharge.Text.Trim(), out c);
                    if (isAValid && isBValid)
                    {

                        string SumGSTTo = string.Format("{0:N}", Convert.ToDouble(Math.Round((a * b / 100), 4).ToString()));
                        // TxtOtherTaxableCharge.Text = SumGSTTo;
                        string SOTC = string.Format("{0:N}", Convert.ToDouble(Math.Round((a * b / 100), 4).ToString()));
                        SumOtherTaxableCharge.Text = SOTC;
                        bool isDalid = double.TryParse(SumOtherTaxableCharge.Text.Trim(), out d);
                        TxtOtherTaxableCharge.Text = Math.Round((d / c), 4).ToString();
                    }
                }
                else
                {
                    double a, b;

                    bool isAValid = double.TryParse(SumTotalInvoice.Text.Trim(), out a);
                    bool isBValid = double.TryParse(OtherTaxableChargePer.Text.Trim(), out b);
                    if (isAValid && isBValid)
                    {
                        string SumGSTTo = string.Format("{0:N}", Convert.ToDouble(Math.Round((a * b / 100), 4).ToString()));
                        // TxtOtherTaxableCharge.Text = SumGSTTo;
                        //TxtOtherTaxableCharge.Text = Math.Round((a * b / 100), 4).ToString();
                        string SOTC = string.Format("{0:N}", Convert.ToDouble(Math.Round((a * b / 100), 4).ToString()));
                        SumOtherTaxableCharge.Text = SOTC;
                    }
                }
            }
            else
            {
                OtherTaxableChargePer.Text = "0.00";
            }
            sumofinsurance();
            totalinv();
            Drpcurrency2.Focus();
        }


        protected void InsuranceChargesPer_TextChanged(object sender, EventArgs e)
        {
            if (InsuranceChargesPer.Text != "")
            {
                if (InsuranceChargesPer.Text == "0.00")
                {
                    InsuranceChargesPer.Text = "0.00";
                    TxtInsuranceCharges.Text = "0.00";
                }
                else
                {
                    double a, b;

                    bool isAValid = double.TryParse(SumTotalInvoice.Text.Trim(), out a);
                    bool isBValid = double.TryParse(InsuranceChargesPer.Text.Trim(), out b);

                    if (isAValid && isBValid)
                    {
                        double INV, fright, tot, insurance;
                        bool INS = double.TryParse(SumTotalInvoice.Text.Trim(), out INV);
                        bool freight = double.TryParse(SumFrieghtCharges.Text.Trim(), out fright);
                        bool ins = double.TryParse(InsuranceChargesPer.Text.Trim(), out insurance);
                        string TIS = string.Format("{0:N}", Convert.ToDouble(Math.Round((a * b / 100), 2).ToString()));
                        TxtInsuranceCharges.Text = TIS;
                        TxtInsuranceCharges.Text = Math.Round((a * b / 100), 2).ToString();
                        string SumGSTTo = string.Format("{0:N}", Convert.ToDouble(Math.Round((a * b / 100), 2).ToString()));
                        //SumInsuranceCharges.Text = SumGSTTo;
                        //SumInsuranceCharges.Text = Math.Round((a * b / 100), 2).ToString();

                        tot = INV + fright;
                        SumInsuranceCharges.Text = string.Format("{0:N}", Convert.ToDouble(Math.Round((insurance * tot / 100), 2).ToString()));

                    }
                }
            }

            else
            {
                InsuranceChargesPer.Text = "0.00";
            }
            sumofinsurance();
            totalinv();
            Drpcurrency4.Focus();
        }

        protected void sumofinsurance()
        {
            double INV, fright, tot, insurance, excharge;
            bool INS = double.TryParse(SumTotalInvoice.Text.Trim(), out INV);
            bool freight = double.TryParse(SumFrieghtCharges.Text.Trim(), out fright);
            bool ins = double.TryParse(InsuranceChargesPer.Text.Trim(), out insurance);
            bool exrate = double.TryParse(lblInsuranceCharges.Text.Trim(), out excharge);
            tot = INV + fright;
            SumInsuranceCharges.Text = string.Format("{0:N}", Convert.ToDouble(Math.Round((insurance * tot / 100), 4).ToString()));
            //insamt = excharge / tot;
            //TxtInsuranceCharges.Text = string.Format("{0:N}", Convert.ToDouble(Math.Round((insamt), 4).ToString()));


        }

        private void requriedInvoice()
        {
            //if (txtinvNo.Text == "")
            //{
            //    ErrorDes = "Invoice -  Please Enter Invoice Number : ";

            //}
            if (TxtImppartyCode.Text == "")
            {
                ErrorDes = "Invoice -  Please Enter Importer Party : ";

            }
            //if (txtinvDate1.Text == "")
            //{
            //    ErrorDes = "Invoice -  Please Enter Invoice Date : ";

            //}
            if (TxtImpCode.Text != TxtImppartyCode.Text)
            {
                ErrorDes = "Please Check Party-> Importer same as Invoice-> Importer Party : ";
            }
            if ((txtrecloctn.Text == "AISSLOC" || txtrecloctn.Text == "SPIGDS" || txtrecloctn.Text == "SPSTK" || txtrecloctn.Text == "SPNOSTK" || txtrecloctn.Text == "SPIGDS" || txtrecloctn.Text == "RCNOSTK"))
            {

            }
            else if (txtreLoctn.Text == "EM" || txtreLoctn.Text == "EXEMPT")
            {

            }
            else if (DrpDecType.SelectedItem.ToString() == "BKT : Blanket ")
            {

            }
            else
            {
                txtinvNo.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                txtinvDate1.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                if (txtinvNo.Text == "")
                {
                    ErrorDes = ErrorDes + "Invoice -  Please Enter Invoice No : ";

                }
                if (txtinvDate1.Text == "")
                {
                    ErrorDes = ErrorDes + "Invoice -  Please Enter Invoice Date : ";

                }
            }




            string[] test = null;
            GridError.DataSource = null;
            GridError.DataBind();
            if (!string.IsNullOrWhiteSpace(ErrorDes))
            {
                test = Regex.Split(ErrorDes, ":");
            }
            if (test != null)
            {
                string totinvAmt = "";
                foreach (string s in test)
                {
                    Label lbl = new Label();
                    lbl.Text = s;
                    //lbltotinvAmt.Text = reader["TIAmount"].ToString();
                    lbl.BackColor = System.Drawing.Color.WhiteSmoke;
                    lbl.BorderStyle = BorderStyle.Solid;
                    lbl.BorderWidth = 1;
                    lbl.Width = 120;
                    totinvAmt = totinvAmt + " " + lbl.Text + " " + Environment.NewLine;
                    div3.Controls.Add(lbl);
                    div3.Controls.Add(new LiteralControl("<br />"));

                    lblerrorinv.Text = totinvAmt;
                    lblerrorinv.Visible = true;
                    updateInvoice.Update();
                }
            }
            else
            {
                lblerrorinv.Text = "";
                lblerrorinv.Visible = false;
                updateInvoice.Update();
            }
        }


        protected void BtnAddInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                requriedInvoice();
                if (lblerrorinv.Text != "")
                {
                    lblerrorinv.Focus();
                }
                else
                {
                    string Code = "";
                    string qry1111 = "SELECT * FROM InvoiceDtl where  MessageType='IPTDEC' AND PermitId='" + txt_code.Text + "' and Sno='" + txtserial.Text + "'";
                    obj.dr = obj.ret_dr(qry1111);
                    while (obj.dr.Read())
                    {
                        Code = obj.dr[2].ToString();
                    }


                    if (Code == "")
                    {
                        string Touch_user = Session["UserId"].ToString();
                        string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        DateTime InvoiceDate = Convert.ToDateTime(null);
                        if (txtinvDate1.Text == "")
                        {
                            var date = DateTime.Now.ToString();
                            var manDate = DateTime.ParseExact(date, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                            InvoiceDate = Convert.ToDateTime(manDate);
                        }
                        else
                        {
                            var InvoiceDate1 = DateTime.ParseExact(txtinvDate1.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                            InvoiceDate = Convert.ToDateTime(InvoiceDate1);
                        }
                        //var InvoiceDate1 = DateTime.ParseExact(txtinvDate1.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                        // DateTime InvoiceDate = Convert.ToDateTime(InvoiceDate1);
                        // //if (Code == "")
                        //{

                        string StrQuery1 = ("INSERT INTO [dbo].[InvoiceDtl] ([SNo],[InvoiceNo],[InvoiceDate],[TermType],[AdValoremIndicator],[PreDutyRateIndicator],[SupplierImporterRelationship],[SupplierCode],[ImportPartyCode],[TICurrency],[TIExRate],[TIAmount],[TISAmount],[OTCCharge],[OTCCurrency],[OTCExRate],[OTCAmount],[OTCSAmount],[FCCharge],[FCCurrency],[FCExRate],[FCAmount],[FCSAmount],[ICCharge],[ICCurrency],[ICExRate],[ICAmount],[ICSAmount],[CIFSUMAmount],[GSTPercentage],[GSTSUMAmount],[MessageType],[PermitId],[TouchUser],[TouchTime]) VALUES ( '" + txtserial.Text + "','" + txtinvNo.Text.Replace("'","''") + "','" + Convert.ToDateTime(InvoiceDate).ToString("yyyy/MM/dd") + "','" + DrpTerms.SelectedItem + "','" + chkindicator.Checked.ToString() + "','" + chkrateind.Checked.ToString() + "','" + DrpSupImpRel.SelectedItem + "','" + txtcodeinvq.Text.Replace("'", "''") + "','" + TxtImppartyCode.Text.Replace("'", "''") + "','" + Drpcurrency1.SelectedItem + "','" + Convert.ToDecimal(LblTotalInvoice.Text).ToString() + "','" + Convert.ToDecimal(TxtTotalInvoice.Text).ToString() + "','" + Convert.ToDecimal(SumTotalInvoice.Text).ToString() + "','" + Convert.ToDecimal(OtherTaxableChargePer.Text).ToString() + "','" + Drpcurrency2.SelectedItem + "','" + Convert.ToDecimal(lblOtherTaxableCharge.Text).ToString() + "','" + Convert.ToDecimal(TxtOtherTaxableCharge.Text).ToString() + "','" + Convert.ToDecimal(SumOtherTaxableCharge.Text).ToString() + "','" + Convert.ToDecimal(FrieghtChargesPer.Text).ToString() + "','" + Drpcurrency3.SelectedItem + "','" + Convert.ToDecimal(LblFrieghtCharges.Text).ToString() + "','" + Convert.ToDecimal(TxtFrieghtCharges.Text).ToString() + "','" + Convert.ToDecimal(SumFrieghtCharges.Text).ToString() + "','" + Convert.ToDecimal(InsuranceChargesPer.Text).ToString() + "','" + Drpcurrency4.SelectedItem + "','" + Convert.ToDecimal(lblInsuranceCharges.Text).ToString() + "','" + Convert.ToDecimal(TxtInsuranceCharges.Text).ToString() + "','" + Convert.ToDecimal(SumInsuranceCharges.Text).ToString() + "','" + Convert.ToDecimal(LblSumOFTotal.Text).ToString() + "','" + LblGSTpercentage.Text + "','" + Convert.ToDecimal(lblGSTAmount.Text).ToString() + "','" + TxtMsgType.Text.Replace("'", "''") + "','" + txt_code.Text + "','" + Touch_user + "','" + strTime + "')");
                        obj.exec(StrQuery1);
                        obj.closecon();
                        BindInvoice();
                        //}
                        InvoiceNo();

                        string SumInvoice = "";
                        string qry11 = "select Count(InvoiceNo) as InvCount from dbo.InvoiceDtl where PermitId='" + txt_code.Text + "' and MessageType='IPTDEC'";
                        obj.dr = obj.ret_dr(qry11);
                        while (obj.dr.Read())
                        {
                            SumInvoice = obj.dr[0].ToString();
                            txtnoofinv.Text = SumInvoice;
                        }
                        //InvoiceGrid.Visible = true;
                        //InvoiceDiv.Visible = false;
                        //NewInvoice.Visible = true;
                        InvoiceClr();
                        string striW = "select * from [InvoiceDtl] where MessageType='IPTDEC' AND PermitId='" + txt_code.Text + "'  order by InvoiceNo";
                        obj.dr = obj.ret_dr(striW);
                        obj.BindDropDown(DrpInvoiceNo, obj.dr, "Id", "InvoiceNo");
                    }
                    else
                    {

                        string Touch_user = Session["UserId"].ToString();
                        string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        DateTime InvoiceDate = Convert.ToDateTime(null);
                        if (txtinvDate1.Text == "")
                        {
                            var date = DateTime.Now.ToString();
                            var manDate = DateTime.ParseExact(date, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                            InvoiceDate = Convert.ToDateTime(manDate);
                        }
                        else
                        {
                            var InvoiceDate1 = DateTime.ParseExact(txtinvDate1.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                            InvoiceDate = Convert.ToDateTime(InvoiceDate1);
                        }
                        //var InvoiceDate = DateTime.Parse(this.txtinvDate1.Text, new CultureInfo("en-US", true));

                        //if (Code == "")
                        //{
                        string StrQuery1 = ("update [dbo].[InvoiceDtl] set [InvoiceNo]='" + txtinvNo.Text + "',[InvoiceDate]='" + Convert.ToDateTime(InvoiceDate).ToString("yyyy/MM/dd") + "',[TermType] ='" + DrpTerms.SelectedItem + "',[AdValoremIndicator]='" + chkindicator.Checked.ToString() + "',[PreDutyRateIndicator]='" + chkrateind.Checked.ToString() + "',[SupplierImporterRelationship]='" + DrpSupImpRel.SelectedItem + "',[SupplierCode]='" + txtcodeinvq.Text + "',[ImportPartyCode]='" + TxtImppartyCode.Text + "',[TICurrency]='" + Drpcurrency1.SelectedItem + "' ,[TIExRate]='" + Convert.ToDecimal(LblTotalInvoice.Text).ToString() + "',[TIAmount]='" + Convert.ToDecimal(TxtTotalInvoice.Text).ToString() + "',[TISAmount]='" + Convert.ToDecimal(SumTotalInvoice.Text).ToString() + "',[OTCCharge]='" + Convert.ToDecimal(OtherTaxableChargePer.Text).ToString() + "',[OTCCurrency]='" + Drpcurrency2.SelectedItem + "',[OTCExRate]='" + Convert.ToDecimal(lblOtherTaxableCharge.Text).ToString() + "',[OTCAmount]='" + Convert.ToDecimal(TxtOtherTaxableCharge.Text).ToString() + "', [OTCSAmount]='" + Convert.ToDecimal(SumOtherTaxableCharge.Text).ToString() + "',[FCCharge]='" + Convert.ToDecimal(FrieghtChargesPer.Text).ToString() + "',[FCCurrency]='" + Drpcurrency3.SelectedItem + "',[FCExRate]='" + Convert.ToDecimal(LblFrieghtCharges.Text).ToString() + "',[FCAmount]='" + Convert.ToDecimal(TxtFrieghtCharges.Text).ToString() + "',[FCSAmount]='" + Convert.ToDecimal(SumFrieghtCharges.Text).ToString() + "',[ICCharge]='" + Convert.ToDecimal(InsuranceChargesPer.Text).ToString() + "',[ICCurrency]='" + Drpcurrency4.SelectedItem + "',[ICExRate]='" + Convert.ToDecimal(lblInsuranceCharges.Text).ToString() + "',[ICAmount]='" + Convert.ToDecimal(TxtInsuranceCharges.Text).ToString() + "',[ICSAmount]='" + Convert.ToDecimal(SumInsuranceCharges.Text).ToString() + "',[CIFSUMAmount]='" + Convert.ToDecimal(LblSumOFTotal.Text).ToString() + "',[GSTPercentage]='" + LblGSTpercentage.Text + "',[GSTSUMAmount]='" + Convert.ToDecimal(lblGSTAmount.Text).ToString() + "',[TouchUser]='" + Touch_user + "',[TouchTime]='" + strTime + "'  where  MessageType='IPTDEC' AND PermitId='" + txt_code.Text + "' and Sno='" + txtserial.Text + "' ");
                        obj.exec(StrQuery1);
                        obj.closecon();

                        StrQuery1 = ("update [dbo].[ItemDtl] set [InvoiceNo]='" + txtinvNo.Text + "' where  MessageType='IPTDEC' AND PermitId='" + txt_code.Text + "'");
                        obj.exec(StrQuery1);
                        obj.closecon();

                        BindInvoice();
                        //InvoiceGrid.Visible = true;
                        //InvoiceDiv.Visible = false;
                        //NewInvoice.Visible = true;
                        InvoiceClr();
                        string striW = "select * from [InvoiceDtl] where MessageType='IPTDEC' AND PermitId='" + txt_code.Text + "'  order by InvoiceNo";
                        obj.dr = obj.ret_dr(striW);
                        obj.BindDropDown(DrpInvoiceNo, obj.dr, "Id", "InvoiceNo");
                    }
                    SummaryCalculate();
                }
                upinitem.Update();
            }
            catch (Exception EX)
            {
                EX.ToString();
            }
        }
        private void deleteinvoice()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            SqlCommand cmd = new SqlCommand("Delete From InvoiceDtl where PermitId='" + txt_code.Text + "' and MessageType='IPTDEC'");
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void deleteitem()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            SqlCommand cmd = new SqlCommand("Delete From ItemDtl where PermitId='" + txt_code.Text + "' and MessageType='IPTDEC'");
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void checkpermitinvoice()
        {
            string Code = "";
            string qry11 = "select * from [InvoiceDtl] where MessageType='IPTDEC' AND PermitId='" + txt_code.Text + "'";
            obj.dr = obj.ret_dr(qry11);
            while (obj.dr.Read())
            {
                Code = obj.dr[0].ToString();
                if (Code != null)
                {

                    deleteinvoice();
                }



            }
        }

        private void checkpermititem()
        {
            string Code = "";
            string qry11 = "select * from [ItemDtl] where MessageType='IPTDEC' AND PermitId='" + txt_code.Text + "'";
            obj.dr = obj.ret_dr(qry11);
            while (obj.dr.Read())
            {
                Code = obj.dr[0].ToString();
                if (Code != null)
                {

                    deleteitem();
                }



            }
        }
        private void BindInvoice()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Top 20 *,FORMAT(InvoiceDate, 'dd/MM/yyyy') AS INVDatee,SUBSTRING(TermType, 1, 3) as tt  FROM InvoiceDtl where PermitId='" + txt_code.Text + "' and MessageType='IPTDEC' order by Id"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet dt = new DataSet())
                        {
                            sda.Fill(dt);
                            AddInvoiceGrid.DataSource = null;
                            AddInvoiceGrid.DataBind();
                            AddInvoiceGrid.DataSource = dt;
                            AddInvoiceGrid.DataBind();
                        }
                    }
                }
            }
        }
        protected void AddInvoiceSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable _objdt = new DataTable();
            _objdt = GetInvoiceFromDataBase(ProductCode2Search.Text);
            if (_objdt.Rows.Count > 0)
            {
                AddInvoiceGrid.DataSource = _objdt;
                AddInvoiceGrid.DataBind();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Invoice();", true);
            }
        }

        protected void AddInvoiceGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            AddInvoiceGrid.PageIndex = e.NewPageIndex;
            BindInvoice();
        }


        public DataTable GetInvoiceFromDataBase(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = AddInvoiceSearch.Text;

            string str3 = "SELECT * FROM InvoiceDtl where InvoiceNo Like '%" + AddInvoiceSearch.Text + "%' order by Id desc";
            obj.dr = obj.ret_dr(str3);
            if (obj.dr.HasRows)
            {
                AddInvoiceGrid.DataSource = obj.dr;

            }
            else
            {
                //Empty DataTable to execute the “else-condition”  
                DataTable dt = new DataTable();
                AddInvoiceGrid.DataSource = dt;
                AddInvoiceGrid.DataBind();
            }
            SqlConnection con = new SqlConnection(sqlconn);
            SqlDataAdapter _objda = new SqlDataAdapter(str3, con);
            con.Close();
            _objda.Fill(_objdt);
            return _objdt;
        }

        public void Editdata()
        {
            string License = TxtLicense1.Text + '-' + TxtLicense2.Text + '-' + TxtLicense3.Text + '-' + TxtLicense4.Text + '-' + TxtLicense5.Text;
            string Recipient = TxtRECPT1.Text + '-' + TxtRECPT2.Text + '-' + TxtRECPT3.Text;
            string Touch_user = Session["UserId"].ToString();
            // var ArrivalDate = DateTime.Parse(this.TxtArrivalDate1.Text, new CultureInfo("en-US", true));
            DateTime ArrivalDate = Convert.ToDateTime(null);
            if (TxtArrivalDate1.Text == "")
            {
                var date = DateTime.Now.ToString("dd/MM/yyyy");
                var manDate = DateTime.ParseExact(date, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                ArrivalDate = Convert.ToDateTime(manDate);
            }
            else
            {
                var InvoiceDate1 = DateTime.ParseExact(TxtArrivalDate1.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                ArrivalDate = Convert.ToDateTime(InvoiceDate1);
            }
            //var ArrivalDate = DateTime.Parse(this.TxtArrivalDate1.Text, new CultureInfo("en-US", true));
            DateTime BlanketDate = Convert.ToDateTime(null);
            if (BlankDate1.Text == "")
            {
                var date = DateTime.Now.ToString("dd/MM/yyyy");
                var manDate = DateTime.ParseExact(date, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                BlanketDate = Convert.ToDateTime(manDate);
            }
            else
            {
                var InvoiceDate1 = DateTime.ParseExact(BlankDate1.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                BlanketDate = Convert.ToDateTime(InvoiceDate1);
            }

            string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            MSGNO();
            refid();
            JobNO();
            string StrQuery = (" Update InHeaderTbl set Customers='" + DrpCustomers.SelectedItem.Text + "',JobId='" + JobNo + "',MSGId='" + MsgNO + "',ReleaseLocName='" + txtrelocDeta.Text + "',HBL='" + txthBlCargo.Text + "' , TradeNetMailboxID='" + TxtTradeMailID.Text + "',MessageType='" + TxtMsgType.Text + "',DeclarationType='" + DrpDecType.SelectedItem.ToString() + "',[PreviousPermit]='" + TxtPrevPerNO.Text + "',CargoPackType='" + DrpCargoPackType.SelectedItem.ToString() + "',InwardTransportMode='" + DrpInwardtrasMode.SelectedItem.ToString() + "',BGIndicator='" + DrpBGIndicator.SelectedItem.ToString() + "',SupplyIndicator='" + ChkSupplyIndicator.Checked.ToString().ToLower() + "',ReferenceDocuments='" + ChkRefDoc.Checked.ToString().ToLower() + "',License='" + License + "',Recipient='" + Recipient + "',DeclarantCompanyCode='" + TxtDecCompCode.Text + "',ImporterCompanyCode='" + TxtImpCode.Text + "',InwardCarrierAgentCode='" + InwardCode.Text + "',FreightForwarderCode='" + FrieghtCode.Text + "',ClaimantPartyCode='" + ClaimantName.Text + "',ArrivalDate='" + Convert.ToDateTime(ArrivalDate).ToString("yyyy/MM/dd") + "',LoadingPortCode='" + TxtLoadShort.Text + "',VoyageNumber='" + TxtVoyageno.Text + "',VesselName='" + TxtVesselName.Text + "',OceanBillofLadingNo='" + TxtOceanBill.Text + "',ConveyanceRefNo='" + TxtConRefNo.Text + "',TransportId='" + TxtTrnsID.Text + "',FlightNO='" + txtflight.Text + "',AircraftRegNo='" + txtaircraft.Text + "',MasterAirwayBill='" + txtwaybill.Text + "',ReleaseLocation='" + txtreLoctn.Text + "',RecepitLocation='" + txtrecloctn.Text + "',RecepitLocName='" + txtrecloctndet.Text + "',TotalOuterPack='" + TxttotalOuterPack.Text + "',TotalOuterPackUOM='" + DrptotalOuterPack.SelectedItem.ToString() + "',TotalGrossWeight='" + TxtTotalGrossWeight.Text + "',TotalGrossWeightUOM='" + DrpTotalGrossWeight.SelectedItem.ToString() + "',GrossReference='" + TxtGrossReference.Text + "',BlanketStartDate='" + Convert.ToDateTime(BlanketDate).ToString("yyyy/MM/dd") + "',[TradeRemarks]='" + txttrdremrk.Text + "',[InternalRemarks]='" + txtintremrk.Text + "',[CustomerRemarks]='" + txtcusRemrk.Text + "',TouchUser='" + Touch_user + "',TouchTime=Convert(VARCHAR,'" + strTime + "',108),[DeclareIndicator]='" + chkDeclareInd.Checked.ToString().ToLower() + "',NumberOfItems='" + txtnoofitm.Text + "',TotalCIFFOBValue='" + txtfobval.Text + "',TotalGSTTaxAmt='" + txttotgstAmt.Text + "',TotalExDutyAmt='" + txttotexAmt.Text + "',TotalCusDutyAmt='" + txtcusdutyAmt.Text + "',TotalODutyAmt='" + txtothtaxAmt.Text + "',TotalAmtPay='" + txtAmtPayble.Text + "' where Id='" + Id + "'");
            // string StrQuery = (" Update InHeaderTbl set  TradeNetMailboxID='" + TxtTradeMailID.Text + "',MessageType='" + TxtMsgType.Text + "',DeclarationType='" + DrpDecType.SelectedItem.ToString() + "',CargoPackType='" + DrpCargoPackType.SelectedItem.ToString() + "',InwardTransportMode='" + DrpInwardtrasMode.SelectedItem.ToString() + "',BGIndicator='" + DrpBGIndicator.SelectedItem.ToString() + "',SupplyIndicator='" + ChkSupplyIndicator.Checked.ToString() + "',ReferenceDocuments='" + ChkRefDoc.Checked.ToString() + "',License='" + License + "',Recipient='" + Recipient + "',DeclarantCompanyCode='" + TxtDecCompCode.Text + "',ImporterCompanyCode='" + TxtImpCode.Text + "',InwardCarrierAgentCode='" + InwardCode.Text + "',FreightForwarderCode='" + FrieghtCode.Text + "',ClaimantPartyCode='" + ClaimantName.Text + "',ArrivalDate='" + Convert.ToDateTime(ArrivalDate).ToString("yyyy/MM/dd") + "',LoadingPortCode='" + TxtLoadShort.Text + "',VoyageNumber='" + TxtVoyageno.Text + "',VesselName='" + TxtVesselName.Text + "',OceanBillofLadingNo='" + TxtOceanBill.Text + "',ConveyanceRefNo='" + TxtConRefNo.Text + "',TransportId='" + TxtTrnsID.Text + "',FlightNO='" + txtflight.Text + "',AircraftRegNo='" + txtaircraft.Text + "',MasterAirwayBill='" + txtwaybill.Text + "',ReleaseLocation='" + txtreLoctn.Text + "',RecepitLocation='" + txtrecloctn.Text + "',TotalOuterPack='" + TxttotalOuterPack.Text + "',TotalOuterPackUOM='" + DrptotalOuterPack.SelectedItem.ToString() + "',TotalGrossWeight='" + TxtTotalGrossWeight.Text + "',TotalGrossWeightUOM='" + DrpTotalGrossWeight.SelectedItem.ToString() + "',GrossReference='" + TxtGrossReference.Text + "',BlanketStartDate='" + Convert.ToDateTime(BlanketDate).ToString("yyyy/MM/dd") + "',TouchUser='" + Touch_user + "',TouchTime=Convert(VARCHAR,'" + strTime + "',108) where Id='" + Id + "'");
            obj.exec(StrQuery);
            string StrdeleteQuery = ("delete from ContainerDtl where PermitId='" + txt_code.Text + "'");
            obj.exec(StrdeleteQuery);
            obj.closecon();
            int i = 1;
            foreach (GridViewRow g1 in ContarinerGrid.Rows)
            {
                string ContainerNo = (g1.FindControl("txt1") as TextBox).Text;
                string ContainerSize = (g1.FindControl("DrpType") as DropDownList).SelectedItem.ToString();
                string ContainerWeight = (g1.FindControl("txt2") as TextBox).Text;
                string Containerseal = (g1.FindControl("txt3") as TextBox).Text;

                if (ContainerNo != "" && ContainerSize != "" && ContainerWeight != "" && Containerseal != null)
                {
                    string StrQuery1 = ("INSERT INTO [dbo].[ContainerDtl] ([PermitId],[RowNo],[ContainerNo],[Size],[Weight],[SealNo],[MessageType],[TouchUser],[TouchTime]) VALUES ('" + txt_code.Text + "','" + i + "','" + ContainerNo + "','" + ContainerSize + "','" + ContainerWeight + "','" + Containerseal + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "')");
                    obj.exec(StrQuery1);
                    obj.closecon();
                }
                i++;
            }
            //CPC
            string cpc = ("delete from CPCDtl where PermitId='" + txt_code.Text + "' and CPCType='AEO'");
            obj.exec(cpc);
            obj.closecon();
            int j = 1;
            foreach (GridViewRow g1 in AEOGrid.Rows)
            {
                string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;

                string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;


                if (ProcessingCode1 != "")
                {
                    string StrQuery1 = ("INSERT INTO [dbo].[CPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + j + "','AEO','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                    obj.exec(StrQuery1);
                    obj.closecon();
                }
                j++;
            }
            string cec = ("delete from CPCDtl where PermitId='" + txt_code.Text + "' and CPCType='CWC'");
            obj.exec(cec);
            obj.closecon();
            int K = 1;
            foreach (GridViewRow g1 in CWCGrid.Rows)
            {
                string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;

                string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                if (ProcessingCode1 != "")
                {
                    string StrQuery1 = ("INSERT INTO [dbo].[CPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + K + "','CWC','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                    obj.exec(StrQuery1);
                    obj.closecon();
                }
                K++;
            }

            int c = 1;
            foreach (GridViewRow g1 in SeaGrid.Rows)
            {
                string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;
                string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                if (ProcessingCode1 != "")
                {
                    string StrQuery1 = ("INSERT INTO [dbo].[InNonCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + c + "','SEASTORE','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                    obj.exec(StrQuery1);
                    obj.closecon();
                }
                c++;
            }

            int d = 1;
            foreach (GridViewRow g1 in SchemeGrid.Rows)
            {
                string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;
                string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                if (ProcessingCode1 != "")
                {
                    string StrQuery1 = ("INSERT INTO [dbo].[InNonCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + d + "','SCHEME','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                    obj.exec(StrQuery1);
                    obj.closecon();
                }
                d++;
            }

            int f = 1;
            foreach (GridViewRow g1 in StsGrid.Rows)
            {
                string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;
                string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                if (ProcessingCode1 != "")
                {
                    string StrQuery1 = ("INSERT INTO [dbo].[InNonCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + f + "','STS','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                    obj.exec(StrQuery1);
                    obj.closecon();
                }
                f++;
            }

            int g = 1;
            foreach (GridViewRow g1 in StscwcGrid.Rows)
            {
                string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;
                string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                if (ProcessingCode1 != "")
                {
                    string StrQuery1 = ("INSERT INTO [dbo].[InNonCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + g + "','STSANDCWC','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                    obj.exec(StrQuery1);
                    obj.closecon();
                }
                g++;
            }

            int go = 1;
            foreach (GridViewRow g1 in IcGrid.Rows)
            {
                string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;
                string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                if (ProcessingCode1 != "")
                {
                    string StrQuery1 = ("INSERT INTO [dbo].[InNonCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + go + "','IC','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                    obj.exec(StrQuery1);
                    obj.closecon();
                }
                go++;
            }

            Itemclear();
            InvoiceClr();
        }


        public void Updatenew()
        {
            string License = TxtLicense1.Text + '-' + TxtLicense2.Text + '-' + TxtLicense3.Text + '-' + TxtLicense4.Text + '-' + TxtLicense5.Text;
            string Recipient = TxtRECPT1.Text + '-' + TxtRECPT2.Text + '-' + TxtRECPT3.Text;
            string Touch_user = Session["UserId"].ToString();
            // var ArrivalDate = DateTime.Parse(this.TxtArrivalDate1.Text, new CultureInfo("en-US", true));
            DateTime ArrivalDate = Convert.ToDateTime(null);
            if (TxtArrivalDate1.Text == "")
            {
                var date = "01/01/1900";
                //var date = DateTime.Now.ToString("dd/MM/yyyy");
                var manDate = DateTime.ParseExact(date, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                ArrivalDate = Convert.ToDateTime(manDate);
            }
            else
            {
                var InvoiceDate1 = DateTime.ParseExact(TxtArrivalDate1.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                ArrivalDate = Convert.ToDateTime(InvoiceDate1);
            }
            //var ArrivalDate = DateTime.Parse(this.TxtArrivalDate1.Text, new CultureInfo("en-US", true));
            DateTime BlanketDate = Convert.ToDateTime(null);
            if (BlankDate1.Text == "")
            {
                var date = "01/01/1900";
                //var date = DateTime.Now.ToString("dd/MM/yyyy");
                var manDate = DateTime.ParseExact(date, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                BlanketDate = Convert.ToDateTime(manDate);
            }
            else
            {
                var InvoiceDate1 = DateTime.ParseExact(BlankDate1.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                BlanketDate = Convert.ToDateTime(InvoiceDate1);
            }

            string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string prmstatus = "NEW";
            if (chkstatus == "AMEND")
            {
                prmstatus = "AMD";
            }
            else if (chkstatus == "CANCEL")
            {
                prmstatus = "CNL";
            }
            else if (chkstatus == "REFUND")
            {
                prmstatus = "RFD";
            }


            ////Count Permit
            string TouchDate = DateTime.Now.ToString("yyyy/MM/dd");
            string CopyMsg = "";
            //  string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            string Mco = "SELECT MsgId FROM PermitCount where MsgId='" + MsgNO + "' and TouchTime='" + TouchDate + "'";
            obj.dr = obj.ret_dr(Mco);
            while (obj.dr.Read())
            {
                CopyMsg = obj.dr["MsgId"].ToString();
            }
            if (CopyMsg == "")
            {

                string StrQuery = (" Update InHeaderTbl set Customers='" + DrpCustomers.SelectedItem.Text + "',Refid='" + refno + "',MSGId='" + MsgNO + "',HBL='" + txthBlCargo.Text + "' ,Status='NEW',prmtStatus='" + prmstatus + "',Cnb='" + chkcnb.Checked.ToString() + "', TradeNetMailboxID='" + TxtTradeMailID.Text + "',MessageType='" + TxtMsgType.Text + "',DeclarationType='" + DrpDecType.SelectedItem.ToString() + "',[PreviousPermit]='" + TxtPrevPerNO.Text + "',CargoPackType='" + DrpCargoPackType.SelectedItem.ToString() + "',InwardTransportMode='" + DrpInwardtrasMode.SelectedItem.ToString() + "',BGIndicator='" + DrpBGIndicator.SelectedItem.ToString() + "',SupplyIndicator='" + ChkSupplyIndicator.Checked.ToString().ToLower() + "',ReferenceDocuments='" + ChkRefDoc.Checked.ToString().ToLower() + "',License='" + License + "',Recipient='" + Recipient + "',DeclarantCompanyCode='" + TxtDecCompCode.Text + "',ImporterCompanyCode='" + TxtImpCode.Text + "',InwardCarrierAgentCode='" + InwardCode.Text + "',FreightForwarderCode='" + FrieghtCode.Text + "',ClaimantPartyCode='" + ClaimantName.Text + "',ArrivalDate='" + Convert.ToDateTime(ArrivalDate).ToString("yyyy/MM/dd") + "',LoadingPortCode='" + TxtLoadShort.Text + "',VoyageNumber='" + TxtVoyageno.Text + "',VesselName='" + TxtVesselName.Text + "',OceanBillofLadingNo='" + TxtOceanBill.Text + "',ConveyanceRefNo='" + TxtConRefNo.Text + "',TransportId='" + TxtTrnsID.Text + "',FlightNO='" + txtflight.Text + "',AircraftRegNo='" + txtaircraft.Text + "',MasterAirwayBill='" + txtwaybill.Text + "',ReleaseLocation='" + txtreLoctn.Text + "',ReleaseLocName='" + txtrelocDeta.Text + "',RecepitLocation='" + txtrecloctn.Text + "',RecepitLocName='" + txtrecloctndet.Text + "',TotalOuterPack='" + TxttotalOuterPack.Text + "',TotalOuterPackUOM='" + DrptotalOuterPack.SelectedItem.ToString() + "',TotalGrossWeight='" + TxtTotalGrossWeight.Text + "',TotalGrossWeightUOM='" + DrpTotalGrossWeight.SelectedItem.ToString() + "',GrossReference='" + TxtGrossReference.Text + "',BlanketStartDate='" + Convert.ToDateTime(BlanketDate).ToString("yyyy/MM/dd") + "',[TradeRemarks]='" + txttrdremrk.Text + "',[InternalRemarks]='" + txtintremrk.Text + "',[CustomerRemarks]='" + txtcusRemrk.Text + "',TouchUser='" + Touch_user + "',TouchTime=Convert(VARCHAR,'" + strTime + "',108),[DeclareIndicator]='" + chkDeclareInd.Checked.ToString().ToLower() + "',NumberOfItems='" + txtnoofitm.Text + "',TotalCIFFOBValue='" + txtfobval.Text + "',TotalGSTTaxAmt='" + txttotgstAmt.Text + "',TotalExDutyAmt='" + txttotexAmt.Text + "',TotalCusDutyAmt='" + txtcusdutyAmt.Text + "',TotalODutyAmt='" + txtothtaxAmt.Text + "',TotalAmtPay='" + txtAmtPayble.Text + "' where Id='" + Id + "'");
                obj.exec(StrQuery);
            }
            else
            {
                string StrQuery = (" Update InHeaderTbl set Customers='" + DrpCustomers.SelectedItem.Text + "',Refid='" + refno + "',HBL='" + txthBlCargo.Text + "' ,Status='NEW',prmtStatus='" + prmstatus + "', TradeNetMailboxID='" + TxtTradeMailID.Text + "',Cnb='" + chkcnb.Checked.ToString() + "',MessageType='" + TxtMsgType.Text + "',DeclarationType='" + DrpDecType.SelectedItem.ToString() + "',[PreviousPermit]='" + TxtPrevPerNO.Text + "',CargoPackType='" + DrpCargoPackType.SelectedItem.ToString() + "',InwardTransportMode='" + DrpInwardtrasMode.SelectedItem.ToString() + "',BGIndicator='" + DrpBGIndicator.SelectedItem.ToString() + "',SupplyIndicator='" + ChkSupplyIndicator.Checked.ToString().ToLower() + "',ReferenceDocuments='" + ChkRefDoc.Checked.ToString().ToLower() + "',License='" + License + "',Recipient='" + Recipient + "',DeclarantCompanyCode='" + TxtDecCompCode.Text + "',ImporterCompanyCode='" + TxtImpCode.Text + "',InwardCarrierAgentCode='" + InwardCode.Text + "',FreightForwarderCode='" + FrieghtCode.Text + "',ClaimantPartyCode='" + ClaimantName.Text + "',ArrivalDate='" + Convert.ToDateTime(ArrivalDate).ToString("yyyy/MM/dd") + "',LoadingPortCode='" + TxtLoadShort.Text + "',VoyageNumber='" + TxtVoyageno.Text + "',VesselName='" + TxtVesselName.Text + "',OceanBillofLadingNo='" + TxtOceanBill.Text + "',ConveyanceRefNo='" + TxtConRefNo.Text + "',TransportId='" + TxtTrnsID.Text + "',FlightNO='" + txtflight.Text + "',AircraftRegNo='" + txtaircraft.Text + "',MasterAirwayBill='" + txtwaybill.Text + "',ReleaseLocation='" + txtreLoctn.Text + "',ReleaseLocName='" + txtrelocDeta.Text + "',RecepitLocation='" + txtrecloctn.Text + "',RecepitLocName='" + txtrecloctndet.Text + "',TotalOuterPack='" + TxttotalOuterPack.Text + "',TotalOuterPackUOM='" + DrptotalOuterPack.SelectedItem.ToString() + "',TotalGrossWeight='" + TxtTotalGrossWeight.Text + "',TotalGrossWeightUOM='" + DrpTotalGrossWeight.SelectedItem.ToString() + "',GrossReference='" + TxtGrossReference.Text + "',BlanketStartDate='" + Convert.ToDateTime(BlanketDate).ToString("yyyy/MM/dd") + "',[TradeRemarks]='" + txttrdremrk.Text + "',[InternalRemarks]='" + txtintremrk.Text + "',[CustomerRemarks]='" + txtcusRemrk.Text + "',TouchUser='" + Touch_user + "',TouchTime=Convert(VARCHAR,'" + strTime + "',108),[DeclareIndicator]='" + chkDeclareInd.Checked.ToString().ToLower() + "',NumberOfItems='" + txtnoofitm.Text + "',TotalCIFFOBValue='" + txtfobval.Text + "',TotalGSTTaxAmt='" + txttotgstAmt.Text + "',TotalExDutyAmt='" + txttotexAmt.Text + "',TotalCusDutyAmt='" + txtcusdutyAmt.Text + "',TotalODutyAmt='" + txtothtaxAmt.Text + "',TotalAmtPay='" + txtAmtPayble.Text + "' where Id='" + Id + "'");
                obj.exec(StrQuery);
            }





            string StrdeleteQuery = ("delete from ContainerDtl where PermitId='" + txt_code.Text + "'");
            obj.exec(StrdeleteQuery);
            obj.closecon();
            int i = 1;
            if (DrpCargoPackType.SelectedItem.ToString() == "9: Containerized")
            {
                foreach (GridViewRow g1 in ContarinerGrid.Rows)
                {
                    string ContainerNo = (g1.FindControl("txt1") as TextBox).Text;
                    string ContainerSize = (g1.FindControl("DrpType") as DropDownList).SelectedItem.ToString();
                    string ContainerWeight = (g1.FindControl("txt2") as TextBox).Text;
                    string Containerseal = (g1.FindControl("txt3") as TextBox).Text;

                    if (ContainerNo != "" && ContainerSize != "" && ContainerWeight != "" && Containerseal != null)
                    {
                        string StrQuery1 = ("INSERT INTO [dbo].[ContainerDtl] ([PermitId],[RowNo],[ContainerNo],[Size],[Weight],[SealNo],[MessageType],[TouchUser],[TouchTime]) VALUES ('" + txt_code.Text + "','" + i + "','" + ContainerNo + "','" + ContainerSize + "','" + ContainerWeight + "','" + Containerseal + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "')");
                        obj.exec(StrQuery1);
                        obj.closecon();
                    }
                    i++;
                }
            }
            //CPC
            string cpc = ("delete from CPCDtl where PermitId='" + txt_code.Text + "' and CPCType='AEO'");
            obj.exec(cpc);
            obj.closecon();
            int j = 1;
            foreach (GridViewRow g1 in AEOGrid.Rows)
            {
                string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;

                string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;


                if (ProcessingCode1 != "")
                {
                    string StrQuery1 = ("INSERT INTO [dbo].[CPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + j + "','AEO','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                    obj.exec(StrQuery1);
                    obj.closecon();
                }
                j++;
            }
            string cec = ("delete from CPCDtl where PermitId='" + txt_code.Text + "' and CPCType='CWC'");
            obj.exec(cec);
            obj.closecon();
            int K = 1;
            foreach (GridViewRow g1 in CWCGrid.Rows)
            {
                string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;

                string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                if (ProcessingCode1 != "")
                {
                    string StrQuery1 = ("INSERT INTO [dbo].[CPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + K + "','CWC','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                    obj.exec(StrQuery1);
                    obj.closecon();
                }
                K++;
            }

            int c = 1;
            foreach (GridViewRow g1 in SeaGrid.Rows)
            {
                string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;
                string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                if (ProcessingCode1 != "")
                {
                    string StrQuery1 = ("INSERT INTO [dbo].[InNonCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + c + "','SEASTORE','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                    obj.exec(StrQuery1);
                    obj.closecon();
                }
                c++;
            }

            int d = 1;
            foreach (GridViewRow g1 in SchemeGrid.Rows)
            {
                string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;
                string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                if (ProcessingCode1 != "")
                {
                    string StrQuery1 = ("INSERT INTO [dbo].[InNonCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + d + "','SCHEME','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                    obj.exec(StrQuery1);
                    obj.closecon();
                }
                d++;
            }

            int f = 1;
            foreach (GridViewRow g1 in StsGrid.Rows)
            {
                string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;
                string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                if (ProcessingCode1 != "")
                {
                    string StrQuery1 = ("INSERT INTO [dbo].[InNonCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + f + "','STS','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                    obj.exec(StrQuery1);
                    obj.closecon();
                }
                f++;
            }

            int g = 1;
            foreach (GridViewRow g1 in StscwcGrid.Rows)
            {
                string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;
                string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                if (ProcessingCode1 != "")
                {
                    string StrQuery1 = ("INSERT INTO [dbo].[InNonCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + g + "','STSANDCWC','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                    obj.exec(StrQuery1);
                    obj.closecon();
                }
                g++;
            }

            int go = 1;
            foreach (GridViewRow g1 in IcGrid.Rows)
            {
                string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;
                string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                if (ProcessingCode1 != "")
                {
                    string StrQuery1 = ("INSERT INTO [dbo].[InNonCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + go + "','IC','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                    obj.exec(StrQuery1);
                    obj.closecon();
                }
                go++;
            }

            Itemclear();
            InvoiceClr();
        }



        public void Insertdata()
        {



            int chkCode = 0;
            string Code = "";
            string qry11 = "SELECT PermitId FROM InHeaderTbl where PermitId='" + txt_code.Text + "' and MessageType='IPTDEC'";
            obj.dr = obj.ret_dr(qry11);
            while (obj.dr.Read())
            {
                Code = obj.dr[0].ToString();
            }
            if (Code == "")
            {
                string License = TxtLicense1.Text + '-' + TxtLicense2.Text + '-' + TxtLicense3.Text + '-' + TxtLicense4.Text + '-' + TxtLicense5.Text;
                string Recipient = TxtRECPT1.Text + '-' + TxtRECPT2.Text + '-' + TxtRECPT3.Text;


                string Touch_user = Session["UserId"].ToString();
                DateTime ArrivalDate = Convert.ToDateTime(null);
                if (TxtArrivalDate1.Text == "")
                {
                    var date = DateTime.Now.ToString("dd/MM/yyyy");
                    var manDate = DateTime.ParseExact(date, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    ArrivalDate = Convert.ToDateTime(manDate);
                }
                else
                {
                    var InvoiceDate1 = DateTime.ParseExact(TxtArrivalDate1.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    ArrivalDate = Convert.ToDateTime(InvoiceDate1);
                }

                //var ArrivalDate = DateTime.Parse(this.TxtArrivalDate1.Text, new CultureInfo("en-US", true));

                DateTime BlanketDate = Convert.ToDateTime(null);
                if (BlankDate1.Text == "")
                {
                    var date = DateTime.Now.ToString("dd/MM/yyyy");
                    var manDate = DateTime.ParseExact(date, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    BlanketDate = Convert.ToDateTime(manDate);
                }
                else
                {
                    var InvoiceDate1 = DateTime.ParseExact(BlankDate1.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    BlanketDate = Convert.ToDateTime(InvoiceDate1);
                }
                //var BlanketDate = DateTime.Parse(this.BlankDate1.Text, new CultureInfo("en-US", true));
                JobNO();

                refid();
                string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                //Count Permit
                string TouchDate = DateTime.Now.ToString("yyyy/MM/dd");
                string CopyMsg = "";
                string Mco = "SELECT MsgId FROM PermitCount where MsgId='" + MsgNO + "' and TouchTime='" + TouchDate + "'";
                obj.dr = obj.ret_dr(Mco);
                while (obj.dr.Read())
                {
                    CopyMsg = obj.dr["MsgId"].ToString();
                }
                if (CopyMsg == "")
                {
                    MSGNO();

                }
                else
                {
                    string PerCount = ("INSERT INTO [dbo].[PermitCount] ([PermitId],[MessageType],[AccountId],[MsgId],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Session["AccountId"].ToString() + "','" + MsgNO + "','" + Touch_user + "','" + TouchDate + "')");
                    obj.exec(PerCount);
                    obj.closecon();
                    MSGNO();

                }



            //string ad = Convert.ToDateTime(ArrivalDate).ToString("yyyy-MM-dd HH:mm:ss");
            //string bd = Convert.ToDateTime(BlanketDate).ToString("yyyy-MM-dd HH:mm:ss");
            Save:
                string StrQuery = (" INSERT INTO [dbo].[InHeaderTbl] ([JobId],[MSGId],[PermitId],[TradeNetMailboxID],[MessageType],[DeclarationType],[PreviousPermit],[CargoPackType],[InwardTransportMode],[BGIndicator],[SupplyIndicator],[ReferenceDocuments],[License],[Recipient],[DeclarantCompanyCode],[ImporterCompanyCode],[InwardCarrierAgentCode],[FreightForwarderCode],[ClaimantPartyCode],HBL,[ArrivalDate],[LoadingPortCode],[VoyageNumber],[VesselName],[OceanBillofLadingNo],[ConveyanceRefNo],[TransportId],[FlightNO],[AircraftRegNo],[MasterAirwayBill],[ReleaseLocation],ReleaseLocName,[RecepitLocation],[RecepitLocName],[TotalOuterPack],[TotalOuterPackUOM],[TotalGrossWeight],[TotalGrossWeightUOM],[GrossReference],[BlanketStartDate],[TradeRemarks],[InternalRemarks],[CustomerRemarks],[Status],[prmtStatus],[TouchUser],[TouchTime],[DeclareIndicator],[NumberOfItems],[TotalCIFFOBValue],[TotalGSTTaxAmt],[TotalExDutyAmt],[TotalCusDutyAmt],[TotalODutyAmt],[TotalAmtPay],Cnb,Customers) Values ('" + JobNo + "','" + MsgNO + "','" + txt_code.Text + "','" + TxtTradeMailID.Text + "','" + TxtMsgType.Text + "','" + DrpDecType.SelectedItem.ToString() + "','" + TxtPrevPerNO.Text + "','" + DrpCargoPackType.SelectedItem.ToString() + "','" + DrpInwardtrasMode.SelectedItem.ToString() + "','" + DrpBGIndicator.SelectedItem.ToString() + "','" + ChkSupplyIndicator.Checked.ToString().ToLower() + "','" + ChkRefDoc.Checked.ToString().ToLower() + "','" + License + "','" + Recipient + "','" + TxtDecCompCode.Text + "','" + TxtImpCode.Text + "','" + InwardCode.Text + "','" + FrieghtCode.Text + "','" + ClaimantName.Text + "','" + txthBlCargo.Text + "','" + Convert.ToDateTime(ArrivalDate).ToString("yyyy/MM/dd") + "','" + TxtLoadShort.Text + "','" + TxtVoyageno.Text + "','" + TxtVesselName.Text + "','" + TxtOceanBill.Text + "','" + TxtConRefNo.Text + "','" + TxtTrnsID.Text + "','" + txtflight.Text + "','" + txtaircraft.Text + "','" + txtwaybill.Text + "','" + txtreLoctn.Text + "','" + txtrelocDeta.Text + "','" + txtrecloctn.Text + "','" + txtrecloctndet.Text + "','" + TxttotalOuterPack.Text + "','" + DrptotalOuterPack.SelectedItem.ToString() + "','" + TxtTotalGrossWeight.Text + "','" + DrpTotalGrossWeight.SelectedItem.ToString() + "','" + TxtGrossReference.Text + "','" + Convert.ToDateTime(BlanketDate).ToString("yyyy/MM/dd") + "','" + txttrdremrk.Text + "','" + txtintremrk.Text + "','" + txtcusRemrk.Text + "','NEW','NEW','" + Touch_user + "','" + strTime + "','" + chkDeclareInd.Checked.ToString().ToLower() + "','" + txtnoofitm.Text + "','" + txtfobval.Text + "','" + txttotgstAmt.Text + "','" + txttotexAmt.Text + "','" + txtcusdutyAmt.Text + "','" + txtothtaxAmt.Text + "','" + txtAmtPayble.Text + "','" + chkcnb.Checked.ToString() + "','" + DrpCustomers.SelectedItem.Text + "')");
                // string StrQuery = (" INSERT INTO [dbo].[InHeaderTbl] ([JobId],[MSGId],[PermitId],[TradeNetMailboxID],[MessageType],[DeclarationType],[CargoPackType],[InwardTransportMode],[BGIndicator],[SupplyIndicator],[ReferenceDocuments],[License],[Recipient],[DeclarantCompanyCode],[ImporterCompanyCode],[InwardCarrierAgentCode],[FreightForwarderCode],[ClaimantPartyCode],[ArrivalDate],[LoadingPortCode],[VoyageNumber],[VesselName],[OceanBillofLadingNo],[ConveyanceRefNo],[TransportId],[FlightNO],[AircraftRegNo],[MasterAirwayBill],[ReleaseLocation],[RecepitLocation],[TotalOuterPack],[TotalOuterPackUOM],[TotalGrossWeight],[TotalGrossWeightUOM],[GrossReference],[BlanketStartDate],[Status],[TouchUser],[TouchTime]) Values ('" + JobNo + "','" + MsgNO + "','" + txt_code.Text + "','" + TxtTradeMailID.Text + "','" + TxtMsgType.Text + "','" + DrpDecType.SelectedItem.ToString() + "','" + DrpCargoPackType.SelectedItem.ToString() + "','" + DrpInwardtrasMode.SelectedItem.ToString() + "','" + DrpBGIndicator.SelectedItem.ToString() + "','" + ChkSupplyIndicator.Checked.ToString() + "','" + ChkRefDoc.Checked.ToString() + "','" + License + "','" + Recipient + "','" + TxtDecCompCode.Text + "','" + TxtImpCode.Text + "','" + InwardCode.Text + "','" + FrieghtCode.Text + "','" + ClaimantName.Text + "','" + ArrivalDate + "','" + TxtLoadShort.Text + "','" + TxtVoyageno.Text + "','" + TxtVesselName.Text + "','" + TxtOceanBill.Text + "','" + TxtConRefNo.Text + "','" + TxtTrnsID.Text + "','" + txtflight.Text + "','" + txtaircraft.Text + "','" + txtwaybill.Text + "','" + txtreLoctn.Text + "','" + txtrecloctn.Text + "','" + TxttotalOuterPack.Text + "','" + DrptotalOuterPack.SelectedItem.ToString() + "','" + TxtTotalGrossWeight.Text + "','" + DrpTotalGrossWeight.SelectedItem.ToString() + "','" + TxtGrossReference.Text + "','" + BlanketDate + "','DRF','" + Touch_user + "','" + strTime + "')");
                chkCode = obj.exec(StrQuery);
                if (chkCode == -2146232060)
                {
                    PermitNO();
                    string PerCount1 = ("INSERT INTO [dbo].[PermitCount] ([PermitId],[MessageType],[AccountId],[MsgId],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Session["AccountId"].ToString() + "','" + MsgNO + "','" + Touch_user + "','" + TouchDate + "')");
                    obj.exec(PerCount1);
                    obj.closecon();
                    MSGNO();
                    goto Save;
                }
                //   string TouchDate = DateTime.Now.ToString("yyyy/MM/dd");
                if (CopyMsg == "")
                {
                    string PerCount1 = ("INSERT INTO [dbo].[PermitCount] ([PermitId],[MessageType],[AccountId],[MsgId],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Session["AccountId"].ToString() + "','" + MsgNO + "','" + Touch_user + "','" + TouchDate + "')");
                    obj.exec(PerCount1);
                    obj.closecon();
                    // MSGNO();
                }
                int i = 1;
                foreach (GridViewRow g1 in ContarinerGrid.Rows)
                {
                    string ContainerNo = (g1.FindControl("txt1") as TextBox).Text;
                    string ContainerSize = (g1.FindControl("DrpType") as DropDownList).SelectedItem.ToString();
                    string ContainerWeight = (g1.FindControl("txt2") as TextBox).Text;
                    string Containerseal = (g1.FindControl("txt3") as TextBox).Text;

                    if (ContainerNo != "" && ContainerSize != "" && ContainerWeight != "" && Containerseal != null)
                    {
                        string StrQuery1 = ("INSERT INTO [dbo].[ContainerDtl] ([PermitId],[RowNo],[ContainerNo],[Size],[Weight],[SealNo],[MessageType],[TouchUser],[TouchTime]) VALUES ('" + txt_code.Text + "','" + i + "','" + ContainerNo + "','" + ContainerSize + "','" + ContainerWeight + "','" + Containerseal + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "')");
                        obj.exec(StrQuery1);
                        obj.closecon();
                    }
                    i++;
                }

                //CPC
                int a = 1;
                foreach (GridViewRow g1 in AEOGrid.Rows)
                {
                    string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;

                    string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                    string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;


                    if (ProcessingCode1 != "")
                    {
                        string StrQuery1 = ("INSERT INTO [dbo].[CPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + a + "','AEO','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                        obj.exec(StrQuery1);
                        obj.closecon();
                    }
                    a++;
                }
                int b = 1;
                foreach (GridViewRow g1 in CWCGrid.Rows)
                {
                    string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;

                    string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                    string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                    if (ProcessingCode1 != "")
                    {
                        string StrQuery1 = ("INSERT INTO [dbo].[CPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + b + "','CWC','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                        obj.exec(StrQuery1);
                        obj.closecon();
                    }
                    b++;
                }

                int c = 1;
                foreach (GridViewRow g1 in SeaGrid.Rows)
                {
                    string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;
                    string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                    string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                    if (ProcessingCode1 != "")
                    {
                        string StrQuery1 = ("INSERT INTO [dbo].[InNonCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + c + "','SEASTORE','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                        obj.exec(StrQuery1);
                        obj.closecon();
                    }
                    b++;
                }

                int d = 1;
                foreach (GridViewRow g1 in SchemeGrid.Rows)
                {
                    string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;
                    string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                    string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                    if (ProcessingCode1 != "")
                    {
                        string StrQuery1 = ("INSERT INTO [dbo].[InNonCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + d + "','SCHEME','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                        obj.exec(StrQuery1);
                        obj.closecon();
                    }
                    d++;
                }

                int f = 1;
                foreach (GridViewRow g1 in StsGrid.Rows)
                {
                    string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;
                    string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                    string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                    if (ProcessingCode1 != "")
                    {
                        string StrQuery1 = ("INSERT INTO [dbo].[InNonCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + f + "','STS','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                        obj.exec(StrQuery1);
                        obj.closecon();
                    }
                    f++;
                }

                int g = 1;
                foreach (GridViewRow g1 in StscwcGrid.Rows)
                {
                    string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;
                    string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                    string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                    if (ProcessingCode1 != "")
                    {
                        string StrQuery1 = ("INSERT INTO [dbo].[InNonCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + g + "','STSANDCWC','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                        obj.exec(StrQuery1);
                        obj.closecon();
                    }
                    g++;
                }

                int go = 1;
                foreach (GridViewRow g1 in IcGrid.Rows)
                {
                    string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;
                    string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                    string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                    if (ProcessingCode1 != "")
                    {
                        string StrQuery1 = ("INSERT INTO [dbo].[InNonCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + go + "','IC','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                        obj.exec(StrQuery1);
                        obj.closecon();
                    }
                    go++;
                }

                Response.Redirect("InpaymentList.aspx");

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Permit Code '" + txt_code.Text + "' Already Exist..');", true);
                //  Response.Write("The Importer Code Already Exist..");

            }
            Itemclear();
            InvoiceClr();
        }




        private void amendinsert()
        {
            string Touch_user = Session["UserId"].ToString();
            string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string P1 = ("insert into InpaymentAmend (Permitno,AmendmentCount,UpdateIndicator,ReplacementPermitno,DescriptionOfReason,PermitExtension,ExtendImportPeriod,DeclarationIndigator,TouchUser,TouchTme)Values('" + txtamendpermit.Text + "','" + txtamoundcount.Text + "','" + txtupdateindicator.Text + "','" + txtreplacepermit.Text + "','" + txtdescreason.Text + "','" + ChkPermitvalEx.Checked.ToString() + "','" + txtvalidity.Text + "','" + chkdec.Checked.ToString() + "','" + Touch_user + "','" + strTime + "') ");
            obj.exec(P1);
            obj.closecon();

        }
        private void Cancelinsert()
        {
            string Touch_user = Session["UserId"].ToString();
            string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string P1 = ("insert into InpaymentCancel (Permitno,UpdateIndicator,ReplacementPermitno,ResonForCancel,DescriptionOfReason,DeclarationIndigator,TouchUser,TouchTme)Values('" + txtcanPermit.Text + "','" + txtupdateInd.Text + "','" + txtcanrepPermit.Text + "','" + DrpReasonCancel.SelectedItem.Text + "','" + txtdesReason.Text + "','" + ChkCancelInd.Checked.ToString() + "','" + Touch_user + "','" + strTime + "') ");
            obj.exec(P1);
            obj.closecon();

        }
        private void Refudinsert()
        {
            string Touch_user = Session["UserId"].ToString();
            string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string P1 = ("insert into InpaymentRefund (Permitno,UpdateIndicator,ReplacementPermitno,TypeOfRefund,ResonForREfund,DescriptionOfReason,DeclarationIndigator,Additionalinfo,Msgid,TouchUser,TouchTme)Values('" + txtreundper.Text + "','" + txtrenupdInd.Text + "','" + txtrefundrepper.Text + "','" + DrpTypeRefund.SelectedItem.ToString() + "','" + DrpRefundReason.SelectedItem.ToString() + "','" + txtrefudDes.Text + "','" + ChkCancelInd.Checked.ToString() + "','" + txtrefaddd1 + "-" + txtrefadd2.Text + "-" + txtrefadd3.Text + "','" + MsgNO + "','" + Touch_user + "','" + strTime + "') ");
            obj.exec(P1);

            P1 = ("insert into refundvalsummary (PermitId,totalgstAmt,totalexciseAmt,txtcusdutyAmt,txtotherAmt)Values('" + txtreundper.Text + "','" + Convert.ToDecimal(txtrefundgstAmt.Text) + "','" + Convert.ToDecimal(txtExciseRefund.Text) + "','" + Convert.ToDecimal(txtCustomsRefund.Text) + "','" + Convert.ToDecimal(txtotherRefund.Text) + "') ");
            obj.exec(P1);

            int i = 1;
            foreach (GridViewRow g1 in RefundItem.Rows)
            {
                string itemno = (g1.FindControl("TextBox1") as TextBox).Text;
                string hscode = (g1.FindControl("TextBox2") as TextBox).Text;
                string totgstamt = (g1.FindControl("TextBox3") as TextBox).Text;
                string totexi = (g1.FindControl("TextBox4") as TextBox).Text;
                string totcus = (g1.FindControl("TextBox5") as TextBox).Text;
                string totOther = (g1.FindControl("TextBox6") as TextBox).Text;

                if (itemno != "" && hscode != "")
                {
                    string StrQuery1 = ("insert into reunditemsumm (Sno,MSGId,PermitId,ItemNo,HsCode,totalgstAmt,totalexciseAmt,txtcusdutyAmt,txtotherAmt)Values('" + i + "','" + MsgNO + "','" + txtreundper.Text + "','" + itemno + "','" + hscode + "','" + Convert.ToDecimal(totgstamt) + "','" + Convert.ToDecimal(totexi) + "','" + Convert.ToDecimal(totcus) + "','" + Convert.ToDecimal(totOther) + "')");
                    obj.exec(StrQuery1);
                    obj.closecon();
                    i++;
                }

            }
            //P1 = ("insert into reunditemsumm (PermitId,ItemNo,HsCode,totalgstAmt,totalexciseAmt,txtcusdutyAmt,txtotherAmt)Values('" + txtreundper.Text + "','" + txtItemNoRefund.Text + "','" + txthscoderefund.Text + "','" + Convert.ToDecimal(txtitemgstRefud.Text) + "','" + Convert.ToDecimal(txtexciseDutyrefud.Text) + "','" + Convert.ToDecimal(txttotCusitemamt.Text) + "','" + Convert.ToDecimal(tztotheritem.Text) + "') ");
            //obj.exec(P1);
            obj.closecon();

        }

        protected void BtnSaveDraft_Click(object sender, EventArgs e)
        {
            ReqValidatePageLoad();
            if (GridError.DataSource != null)
            {
                GridError.Visible = true;
                POPUPERR.Show();
                POPUPERR.X = 400;
                POPUPERR.Y = 100;
            }
            else
            {

                if (Convert.ToDecimal(txtcifVal.Text) == Convert.ToDecimal(txtfobval.Text))
                {
                    if (Update == "AMEND")
                    {
                        if (ErrorDes == "")
                        {
                            POPUPERR.Hide();

                            Editdata();
                            amendinsert();
                            Response.Redirect("InpaymentList.aspx");
                        }
                        else
                        {
                            POPUPERR.Show();
                            POPUPERR.X = 400;
                            POPUPERR.Y = 100;
                        }

                    }

                    else if (Update == "CANCEL")
                    {
                        Editdata();
                        Cancelinsert();
                        Response.Redirect("InpaymentList.aspx");
                    }
                    else if (Update == "REFUND")
                    {
                        Editdata();
                        Refudinsert();
                        Response.Redirect("InpaymentList.aspx");
                    }
                    else
                    {
                        if (ErrorDes == "")
                        {

                            if (DrpDecType.SelectedItem.ToString() == "BKT : Blanket")
                            {
                                Id = Convert.ToInt16(Session["Id"].ToString());
                                if (Id != 0)
                                {
                                    Editdata();
                                    Response.Redirect("InpaymentList.aspx");
                                    Session["Edit"] = false;
                                    // eid = 0;
                                }

                                else
                                {
                                    Insertdata();

                                }
                            }
                            else
                            {



                                //if (TextMode.Text == "1 : Sea" && TextMode.Text == "4 : Air")
                                //{

                                //    if (string.IsNullOrWhiteSpace(InwardCRUEI.Text))
                                //    {
                                //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Inward Carrier Agent CRUEI Number Is Empty');", true);
                                //        return;
                                //    }
                                //    else if (string.IsNullOrWhiteSpace(InwardName.Text))
                                //    {
                                //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Inward Carrier Agent Name Is Empty');", true);
                                //        return;
                                //    }

                                //}
                                //else
                                //{
                                Id = Convert.ToInt16(Session["Id"].ToString());
                                if (Id != 0)
                                {
                                    Editdata();
                                    Response.Redirect("InpaymentList.aspx");
                                    Session["Edit"] = false;
                                    // eid = 0;
                                }

                                else
                                {
                                    Insertdata();

                                }
                                //}
                            }
                        }
                        else
                        {
                            POPUPERR.Show();
                            POPUPERR.X = 400;
                            POPUPERR.Y = 100;
                        }
                    }
                }
                else
                {
                    lblerror.Text = "INVOICE AMOUNT AND ITEM AMOUNT NOT SAME";
                    lblerror.Focus();
                    //Response.Write("<script LANGUAGE='JavaScript' >alert('Invoice Amount and Item Amount Not Same')</script>");
                }
            }
        }

        protected void AddInvoiceGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = AddInvoiceGrid.DataKeys[e.RowIndex].Value.ToString();

            string strDelete = "delete from InvoiceDtl where Id='" + id + "' ";
            obj.exec(strDelete);
            obj.closecon();
            BindInvoice();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Invoice();", true);
        }

        protected void imgInvoiceDelete_Click(object sender, EventArgs e)
        {
            LinkButton lnkbtn = sender as LinkButton;
            //getting particular row linkbutton
            GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
            //getting userid of particular row
            int employeeId = Convert.ToInt32(AddInvoiceGrid.DataKeys[gvrow.RowIndex].Value.ToString());
            int result;
            //getting Connectin String from Web.Config
            string conString = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM InvoiceDtl where ID=" + employeeId, con);
                result = cmd.ExecuteNonQuery();
                string var = "DECLARE @SRNO bigint=0;" + Environment.NewLine;
                var = var + " UPDATE InvoiceDtl SET @SRNO =SNo= @SRNO + 1 where PermitId='" + txt_code.Text + "'";

                cmd = new SqlCommand(var, con);
                cmd.ExecuteNonQuery();
                con.Close();

                InvoiceNo();
            }


            if (result == 1)
            {
                BindInvoice();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Invoice();", true);
            }
            // AddDynamicLabels();
        }

        protected void chkaeo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkaeo.Checked == true && chkcwc.Checked == true)
            {
                AEO.Visible = true;
                CWC.Visible = true;
                return;
            }
            else if (chkaeo.Checked == true)
            {
                AEO.Visible = true;
                CWC.Visible = false;
            }
            else if (chkcwc.Checked == true)
            {
                AEO.Visible = false;
                CWC.Visible = true;
            }
            else
            {
                AEO.Visible = false;
                CWC.Visible = false;
            }


            chkcwc.Focus();
        }

        protected void chkcwc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkcwc.Checked == true)
            {
                CWC.Visible = true;
                return;
            }
            else
            {
                CWC.Visible = false;
            }
            chkcnb.Focus();
        }

        protected void AEOGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt2 = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                if (dt2.Rows.Count > 1)
                {
                    dt2.Rows.Remove(dt2.Rows[rowIndex]);
                    drCurrentRow = dt2.NewRow();
                    ViewState["CurrentTable"] = dt2;
                    AEOGrid.DataSource = dt2;
                    AEOGrid.DataBind();

                    for (int i = 0; i < ContarinerGrid.Rows.Count - 1; i++)
                    {
                        AEOGrid.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                    }
                    SetPreviousDatac();
                }
            }
        }

        protected void CWCGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //   AddNewRowToGrid1cp();
            if (ViewState["CurrentTable1"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable1"];
                DataRow drCurrentRow = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                if (dt.Rows.Count > 1)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["CurrentTable1"] = dt;
                    CWCGrid.DataSource = dt;
                    CWCGrid.DataBind();

                    for (int i = 0; i < ContarinerGrid.Rows.Count - 1; i++)
                    {
                        CWCGrid.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                    }
                    SetPreviousData1cp();
                }
            }
        }

        protected void DrpDecType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DrpDecType.SelectedItem.ToString() == "BKT : Blanket ")
            {
                DrpInwardtrasMode.Visible = false;
                inwared.Visible = false;
                carLoadingPort.Visible = false;
                carMode.Visible = false;
                InwardFlight.Visible = false;
                InwardSea.Visible = false;
                InwardOther.Visible = false;

            }
            if (DrpDecType.SelectedItem.ToString() == "DUT : Duty")
            {
                DrpInwardtrasMode.Visible = true;
                inwared.Visible = true;
                carLoadingPort.Visible = false;
                carMode.Visible = true;
                InwardFlight.Visible = false;
                InwardSea.Visible = false;
                InwardOther.Visible = false;
                carArrival.Visible = true;

            }
            if (DrpDecType.SelectedItem.ToString() == "DNG : Duty & GST")
            {
                DrpInwardtrasMode.Visible = true;
                inwared.Visible = true;
                carLoadingPort.Visible = false;
                carMode.Visible = true;
                InwardFlight.Visible = false;
                InwardSea.Visible = false;
                InwardOther.Visible = false;
                carArrival.Visible = true;
            }
            if (DrpDecType.SelectedItem.ToString() == "GST : GST (Including Duty Exemption)")
            {
                DrpInwardtrasMode.Visible = true;
                inwared.Visible = true;
                carLoadingPort.Visible = false;
                carMode.Visible = true;
                InwardFlight.Visible = false;
                InwardSea.Visible = false;
                InwardOther.Visible = false;
                carArrival.Visible = true;
            }

            //else if (DrpDecType.SelectedItem.ToString() == "IGM : INTER-GATEWAY MOVEMENT" || DrpDecType.SelectedItem.ToString() == "TIF : THRU TRANSHIPMENT WITHIN SAME FTZ" || DrpDecType.SelectedItem.ToString() == "TTI : THRU TRANSHIPMENT WITH INTER-GATEWAY MOVEMENT")
            //{
            //    dateinfo.Visible = false;
            //}
            if (DrpDecType.SelectedItem.ToString() == "--Select--")
            {
                //inwared.Visible = true;
                DrpInwardtrasMode.Visible = false;
                inwared.Visible = false;
                carLoadingPort.Visible = false;
                carMode.Visible = true;
                InwardFlight.Visible = false;
                InwardSea.Visible = false;
                InwardOther.Visible = false;
                carArrival.Visible = true;
                //carLoadingPort.Visible = true;
                //carMode.Visible = true;
                //InwardFlight.Visible = true;
                //InwardSea.Visible = true;
                //InwardOther.Visible = true;
            }
            upinparty.Update();
            updatepanel1.Update();
            //ReqValidatePageLoad();

            TxtPrevPerNO.Focus();
        }

        protected void ChkUnbrand_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkUnbrand.Checked == true)
            {
                TxtBrand.Text = "UNBRANDED";
            }
            else
            {
                TxtBrand.Text = "";
            }

            TxtBrand.Focus();
        }

        protected void TxtDescription_TextChanged(object sender, EventArgs e)
        {

            LblCount.Text = "(" + TxtDescription.Text.Length.ToString() + " / 512 Characters)"; 
        }

        protected void DrpInvoiceNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Code, Code1 = "";
            string qry11 = "select TICurrency from [InvoiceDtl] where MessageType='IPTDEC' AND PermitId='" + txt_code.Text + "' and InvoiceNo='" + DrpInvoiceNo.SelectedItem.ToString().Replace("'","''") + "'  order by TICurrency";
            obj.dr = obj.ret_dr(qry11);
            while (obj.dr.Read())
            {
                Code = obj.dr[0].ToString();
                if (Code != "--Select--")
                {
                    //DRPCurrency.SelectedValue = Code;
                    DRPCurrency.ClearSelection();
                    DRPCurrency.Items.FindByText(Code).Selected = true;
                    // DrpOptionalUom.SelectedValue = Code;
                    string qry111 = "select CurrencyRate from dbo.Currency where Currency='" + Code + "'";
                    obj.dr = obj.ret_dr(qry111);
                    while (obj.dr.Read())
                    {
                        Code1 = obj.dr[0].ToString();
                        TxtExchangeRate.Text = Code1;
                        // TxtOptionalExchageRate.Text = Code1;
                        upinitem.Update();
                    }
                }
            }
            obj = new InpaymentClass();
            obj.dr = obj.ret_dr("Select TermType from [InvoiceDtl] where MessageType='IPTDEC' AND PermitId='" + txt_code.Text + "' and InvoiceNo='" + DrpInvoiceNo.SelectedItem.ToString().Replace("'","''") + "'");
            while (obj.dr.Read())
            {
                txttermtyp.Text = obj.dr["TermType"].ToString();
            }
            TxtTotalLineAmount.Focus();

        }

        protected void DRPCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string Code = "";
            //string qry11 = "select TICurrency from [InvoiceDtl] where MessageType='IPTDEC' AND PermitId='" + txt_code.Text + "' and InvoiceNo='" + DrpInvoiceNo.SelectedItem.ToString() + "'  order by TICurrency";
            //obj.dr = obj.ret_dr(qry11);
            //while (obj.dr.Read())
            //{
            //    Code = obj.dr[0].ToString();
            //    if (Code != "--Select--")
            //    {
            //        DRPCurrency.SelectedValue = Code;
            //    }
            //}
            string qry11 = "SELECT CurrencyRate FROM Currency where Currency='" + DRPCurrency.SelectedItem.ToString() + "'";
            obj.dr = obj.ret_dr(qry11);
            while (obj.dr.Read())
            {

                TxtExchangeRate.Text = obj.dr[0].ToString();
            }
            TxtTotalLineAmount.Focus();
        }

        protected void TxtTotalLineAmount_TextChanged(object sender, EventArgs e)
        {


            string InvoiceCharge, OtherChnage, Insurancecharge, FrightCharge = "";
            string qry11 = "select TISAmount,OTCSAmount,FCSAmount,ICSAmount from [InvoiceDtl] where MessageType='IPTDEC' AND PermitId='" + txt_code.Text + "' and InvoiceNo='" + DrpInvoiceNo.SelectedItem.ToString().Replace("'", "''") + "'  ";
            obj.dr = obj.ret_dr(qry11);
            while (obj.dr.Read())
            {
                InvoiceCharge = obj.dr[0].ToString();
                OtherChnage = obj.dr[1].ToString();
                Insurancecharge = obj.dr[3].ToString();
                FrightCharge = obj.dr[2].ToString();




                if (TxtTotalLineAmount.Text != "")
                {

                    //double T1, T2;
                    //bool A = double.TryParse(TxtTotalLineAmount.Text.Trim(), out T1);
                    //bool B = double.TryParse(TxtExchangeRate.Text.Trim(), out T2);

                    //if (A && B)
                    //    TxtTotalLineCharges.Text = (T1 * T2).ToString();


                    // PER VALUE FREIGHT  Invoice

                    double T1, T2, T3, T4, T5, A1, A2;
                    bool A = double.TryParse(InvoiceCharge.Trim(), out T1);
                    bool B = double.TryParse(OtherChnage.Trim(), out T2);
                    bool C = double.TryParse(Insurancecharge.Trim(), out T3);
                    bool D = double.TryParse(FrightCharge.Trim(), out T4);
                    bool X = double.TryParse(TxtTotalLineAmount.Text.Trim(), out A1);
                    bool Y = double.TryParse(TxtExchangeRate.Text.Trim(), out A2);

                    if (A && B && C && D)
                    {
                        T5 = (T2 + T3 + T4) / T1;
                        //Total Invoice Charges(SGD)
                        TxtTotalLineCharges.Text = Math.Round(((A2 * A1) * T5), 2).ToString();
                    }


                    txtAlcoholPer_TextChanged(null, null);





                }
                else
                {
                    TxtTotalLineAmount.Text = "0.00";
                }
            }
            if (TxtTotalLineAmount.Text != "")
            {

                double T1, T2, T3, T4;
                bool A = double.TryParse(TxtTotalLineAmount.Text.Trim(), out T1);
                bool B = double.TryParse(TxtExchangeRate.Text.Trim(), out T2);
                bool C = double.TryParse(TxtTotalLineCharges.Text.Trim(), out T3);

                if (A && B && C)
                    TxtCIFFOB.Text = Math.Round((T1 * T2 + T3), 2).ToString();
                bool D = double.TryParse(TxtCIFFOB.Text.Trim(), out T4);
                TxtItemSumGST.Text = Math.Round((T4 * 9 / 100), 2).ToString();

                if (Math.Round((T4 * 9 / 100), 2) >= 10000)
                {
                    Lblmarquee.Text = "Total GST Amount greater than 10000";

                    txttotgstAmt.BorderColor = Color.Red;
                    updatepanel1.Update();
                }
                else
                {
                    Lblmarquee.Text = "";
                    updatepanel1.Update();
                }


            }
            else
            {
                TxtTotalLineAmount.Text = "0.00";
            }
            //Sum of Item Amount

            string SumofItemAmount = "";
            string qry11s2Q = "select SUM(TotalLineAmount) as  TotalLineAmount  from dbo.ItemDtl where PermitId='" + txt_code.Text + "' and MessageType='IPTDEC'";
            obj.dr = obj.ret_dr(qry11s2Q);
            while (obj.dr.Read())
            {
                SumofItemAmount = obj.dr[0].ToString();
                txtitmAmt.Text = SumofItemAmount;
            }



            double cif, exrate, sumex, itemgst, summerygst, optional;
            cif = Convert.ToDouble(TxtCIFFOB.Text);
            exrate = Convert.ToDouble(TxtExciseDutyRate.Text);
            sumex = 0;
            if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
            {
                sumex = Convert.ToDouble(TxtSumExciseDuty.Text);
            }
            else if (TxtHSCodeItem.Text.Trim().StartsWith("87"))
            {
                sumex = Math.Round((cif) * (exrate / 100), 2);
            }
            itemgst = Convert.ToDouble(TxtItemSumGST.Text);
            if (string.IsNullOrWhiteSpace(TxtOptionalSumExRate.Text))
            {
                TxtOptionalSumExRate.Text = "0.00";
            }
            optional = Convert.ToDouble(TxtOptionalSumExRate.Text);

            if (TxtHSCodeItem.Text.Trim().StartsWith("87"))
            {
                TxtSumExciseDuty.Text = sumex.ToString();
            }

            summerygst = (sumex * 0.09) + (itemgst * 0.09) + (optional * 0.09);

            TxtItemSumGST.Text = Math.Round((summerygst), 2).ToString();
            if (Math.Round((summerygst), 2) >= 10000)
            {
                Lblmarquee.Text = "Total GST Amount greater than 10000";

                txttotgstAmt.BorderColor = Color.Red;
                updatepanel1.Update();
            }
            else
            {
                Lblmarquee.Text = "";
                updatepanel1.Update();
            }
            //TxtTotalLineAmount_TextChanged(null, null);
            txtAlcoholPer_TextChanged(null, null);
            upinitem.Update();
            updatepanel1.Update();
            ChkPackInfo.Focus();
        }

        protected void TxtUnitPrice_TextChanged(object sender, EventArgs e)
        {
            if (TxtUnitPrice.Text != "")
            {
                string termtype = "";
                string qry11 = "select TermType from [InvoiceDtl] where MessageType='IPTDEC' AND PermitId='" + txt_code.Text + "' and InvoiceNo='" + DrpInvoiceNo.SelectedItem.ToString().Replace("'", "''") + "'  ";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    termtype = obj.dr["TermType"].ToString();
                }

                double T1, T2, T3, T4, T5;
                bool A = double.TryParse(TxtUnitPrice.Text.Trim(), out T1);
                bool B = double.TryParse(TxtExchangeRate.Text.Trim(), out T2);
                bool C = double.TryParse(TxtTotalLineAmount.Text.Trim(), out T3);
                bool D = double.TryParse(TxtTotalLineCharges.Text.Trim(), out T4);
                bool E = double.TryParse(TxtHSQuantity.Text.Trim(), out T5);

                if (A && B)
                    TxtSumExRate.Text = (T1 * T2).ToString();

                TxtTotalLineAmount.Text = (T5 * T1).ToString();

                string lineamt = (T5 * T1).ToString();
                string linecharge = "0.00";
                if (termtype == "CIF : Cost,Insurance and Frieght")
                {
                    TxtTotalLineCharges.Text = "0.00";
                    linecharge = "0.00";
                }
                else
                {
                    TxtTotalLineCharges.Text = (Convert.ToDouble(lineamt) * T2 / 100).ToString();
                    linecharge = (Convert.ToDouble(lineamt) * T2 / 100).ToString();
                }
                TxtCIFFOB.Text = ((Convert.ToDouble(lineamt) * T2 + Convert.ToDouble(linecharge)).ToString());
                string GSTG = TxtCIFFOB.Text;
                TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(((Convert.ToDouble(GSTG) * 9 / 100).ToString())), 2).ToString();
                if (Math.Round(Convert.ToDecimal(((Convert.ToDouble(GSTG) * 9 / 100).ToString())), 2) >= 10000)
                {
                    Lblmarquee.Text = "Total GST Amount greater than 10000";

                    txttotgstAmt.BorderColor = Color.Red;
                    updatepanel1.Update();
                }
                else
                {
                    Lblmarquee.Text = "";
                    updatepanel1.Update();
                }
            }
            else
            {
                TxtUnitPrice.Text = "0.00";
            }
            //Sum of Item Amount

            string SumofItemAmount = "";
            string qry11s2Q = "select SUM(TotalLineAmount) as  TotalLineAmount  from dbo.ItemDtl where PermitId='" + txt_code.Text + "' and MessageType='IPTDEC'";
            obj.dr = obj.ret_dr(qry11s2Q);
            while (obj.dr.Read())
            {
                SumofItemAmount = obj.dr[0].ToString();
                txtitmAmt.Text = SumofItemAmount;
            }
            //TotalGSTAmount
            string TotalGSTAmount = "";
            string qry11s2 = "select SUM(GSTAmount) as  GSTAmount  from dbo.ItemDtl where PermitId='" + txt_code.Text + "' and MessageType='IPTDEC'";
            obj.dr = obj.ret_dr(qry11s2);
            while (obj.dr.Read())
            {
                TotalGSTAmount = obj.dr[0].ToString();
                txttotgstAmt.Text = TotalGSTAmount;

                if (DrpDecType.SelectedItem.ToString() == "DUT : Duty")
                {
                    txtAmtPayble.Text = txttotexAmt.Text;
                }
                else
                {
                    txtAmtPayble.Text = TotalGSTAmount;
                }
            }
            TxtTotalLineAmount_TextChanged(null, null);
            upinitem.Update();
            updatepanel1.Update();
        }

        protected void ChkUnitPrice_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkUnitPrice.Checked == true)
            {
                TxtUnitPrice.Visible = true;
                TxtSumExRate.Visible = true;
                TxtUnitPrice.Text = "0.00";
                TxtSumExRate.Text = "0.00";

                TxtUnitPrice.Enabled = true;
                TxtSumExRate.Enabled = true;

                extrsItemDiv.Visible = true;
                TxtTotalLineAmount.Enabled = false;
            }
            else
            {
                TxtUnitPrice.Visible = true;
                TxtSumExRate.Visible = true;
                TxtUnitPrice.Text = "0.00";
                TxtSumExRate.Text = "0.00";

                TxtUnitPrice.Enabled = false;
                TxtSumExRate.Enabled = false;
                extrsItemDiv.Visible = false;
                TxtTotalLineAmount.Enabled = true;
            }
            upinitem.Update();
            updatepanel1.Update();
        }

        protected void DrpPreferentialCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DrpPreferentialCode.SelectedItem.ToString() == "PRF : if goods are imported under preferential duty rates")
            {
                lblCustomsDuty.Text = "Customs Duty - EXEMPTED";
                TxtCustomsDutyRate.Text = "0";
                TxtCustomsDutyUOM.Text = "";
                TxtSumCustomsDuty.Text = "0.00";
            }

            else
            {
                lblCustomsDuty.Text = "Customs Duty";
                //TxtCustomsDutyRate.Text = "16";
                TxtCustomsDutyUOM.Text = "";
                TxtHSCodeItem_TextChanged(null, null);
            }

            TxtTotalLineAmount_TextChanged(null, null);
            txtAlcoholPer_TextChanged(null, null);
            upinitem.Update();
            chk234.Focus();
        }

        protected void AddItemSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable _objdt = new DataTable();
            _objdt = GetInvoiceFromDataBase(ProductCode2Search.Text);
            if (_objdt.Rows.Count > 0)
            {
                AddInvoiceGrid.DataSource = _objdt;
                AddInvoiceGrid.DataBind();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Invoice();", true);
            }
        }

        protected void AddItemGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void imgItemDelete_Click(object sender, EventArgs e)
        {

            LinkButton lnkbtn = sender as LinkButton;
            //getting particular row linkbutton
            GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
            //getting userid of particular row
            int employeeId = Convert.ToInt32(AddItemGrid.DataKeys[gvrow.RowIndex].Value.ToString());
            Label ID1 = (Label)gvrow.FindControl("ItemNo");
            string ID = ID1.Text;
            int result;
            //getting Connectin String from Web.Config
            string conString = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM ItemDtl where PermitId='" + txt_code.Text + "' and ItemNo=" + ID, con);
                result = cmd.ExecuteNonQuery();

                cmd = new SqlCommand("DELETE FROM CASCDtl where PermitId='" + txt_code.Text + "' and ItemNo='" + ID + "'", con);
                cmd.ExecuteNonQuery();

                string var1 = "update T";
                var1 = var1 + " set ItemNo = rn";
                var1 = var1 + " from (";
                var1 = var1 + " select ItemNo,";
                var1 = var1 + " row_number() over(order by ItemNo) as rn";
                var1 = var1 + " from ItemDtl where PermitId='" + txt_code.Text + "'";
                var1 = var1 + " ) T";
                //string var = "DECLARE @SRNO bigint=0;" + Environment.NewLine;
                //var = var + " UPDATE ItemDtl SET @SRNO =ItemNo= @SRNO + 1 where PermitId='" + txt_code.Text + "'";
                cmd = new SqlCommand(var1, con);
                cmd.ExecuteNonQuery();

                var1 = "update T";
                var1 = var1 + " set ItemNo = rn";
                var1 = var1 + " from (";
                var1 = var1 + " select ItemNo,";
                var1 = var1 + " row_number() over(order by ItemNo) as rn";
                var1 = var1 + " from CASCDtl where PermitId='" + txt_code.Text + "'";
                var1 = var1 + " ) T";

                //var = "DECLARE @SRNO bigint=0;" + Environment.NewLine;
                //var = var + " UPDATE CASCDtl SET @SRNO =ItemNo= @SRNO + 1 where PermitId='" + txt_code.Text + "'";
                cmd = new SqlCommand(var1, con);
                cmd.ExecuteNonQuery();

                con.Close();
                ItemNO();
                BindItemMaster();
            }
            if (result == 1)
            {
                BindItemMaster();

            }


        }
        private void BindItemMaster()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Top 50 * FROM ItemDtl where PermitId='" + txt_code.Text + "' and MessageType='IPTDEC' order by ItemNo"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet dt = new DataSet())
                        {
                            sda.Fill(dt);
                            AddItemGrid.DataSource = dt;
                            AddItemGrid.DataBind();
                        }
                    }
                }
            }
        }
        public DataTable GetItemFromDataBase(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = AddItemSearch.Text;

            string str3 = "SELECT * FROM InvoiceDtl where InvoiceNo Like '%" + AddItemSearch.Text + "%' order by Id desc";
            obj.dr = obj.ret_dr(str3);
            if (obj.dr.HasRows)
            {
                AddItemGrid.DataSource = obj.dr;

            }
            else
            {
                //Empty DataTable to execute the “else-condition”  
                DataTable dt = new DataTable();
                AddItemGrid.DataSource = dt;
                AddItemGrid.DataBind();
            }
            SqlConnection con = new SqlConnection(sqlconn);
            SqlDataAdapter _objda = new SqlDataAdapter(str3, con);
            con.Close();
            _objda.Fill(_objdt);
            return _objdt;
        }
        protected void BtnItemAdd_Click(object sender, EventArgs e)
        {
           

                is_inpayment_controlled.Text = string.Empty;
            /*string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
          SqlCommand cmd = new SqlCommand ("SELECT COUNT(*) FROM ItemDtl where MessageType='IPTDEC' AND PermitId='" + txt_code.Text + "'",con);*/
            string MaxItemCount = "";
            string maxq = "SELECT COUNT(PermitId) AS MaxItem FROM ItemDtl  where  MessageType='IPTDEC' AND PermitId='" + txt_code.Text + "'";
            obj.dr = obj.ret_dr(maxq);
            while (obj.dr.Read())
            {
                MaxItemCount = obj.dr["MaxItem"].ToString();
            }

            if (MaxItemCount != "50")
            {

                //string itemcnt = "";
                //int count = 0;

                lblitemalert.Visible = false;
                string Code = "";
                string qry1111 = "SELECT * FROM ItemDtl where  MessageType='IPTDEC' AND PermitId='" + txt_code.Text + "' and ItemNo='" + TxtSerialNo.Text + "'";
                obj.dr = obj.ret_dr(qry1111);
                while (obj.dr.Read())
                {
                    Code = obj.dr[1].ToString();
                }


                Chklot.Checked = false;
                Chklot_CheckedChanged(null, null);
                Chkitemcasc.Checked = false;
                Chkitemcasc_CheckedChanged(null, null);
                ChkPackInfo.Checked = false;
                ChkPackInfo_CheckedChanged(null, null);

                if (Code == "")
                {

                    string Touch_user = Session["UserId"].ToString();
                    string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    DateTime orgindate = Convert.ToDateTime(null);
                    if (OriginalRegDate.Text == "")
                    {
                        var date = DateTime.Now.ToString("dd/MM/yyyy");
                        var manDate = DateTime.ParseExact(date, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        orgindate = Convert.ToDateTime(manDate);
                    }
                    else
                    {
                        var InvoiceDate1 = DateTime.ParseExact(OriginalRegDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        orgindate = Convert.ToDateTime(InvoiceDate1);
                    }

                    string strhawb = "";
                    if (string.IsNullOrWhiteSpace(TxtHAWB.Text))
                    {
                        strhawb = "";
                    }
                    else
                    {
                        strhawb = TxtHAWB.SelectedItem.ToString();
                    }

                    string StrQuery1 = ("INSERT INTO [dbo].[ItemDtl] ([ItemNo],[PermitId],[MessageType],[HSCode],[Description],[DGIndicator],[Contry],[Brand],[Model],[InHAWBOBL],[DutiableQty],[DutiableUOM],[TotalDutiableQty],[TotalDutiableUOM],[InvoiceQuantity],[HSQty],[HSUOM],[AlcoholPer],[InvoiceNo],[ChkUnitPrice],[UnitPrice],[UnitPriceCurrency],[ExchangeRate],[SumExchangeRate],[TotalLineAmount],[InvoiceCharges],[CIFFOB],[OPQty],[OPUOM],[IPQty],[IPUOM],[InPqty],[InPUOM],[ImPQty],[ImPUOM],[PreferentialCode],[GSTRate],[GSTUOM],[GSTAmount],[ExciseDutyRate],[ExciseDutyUOM],[ExciseDutyAmount],[CustomsDutyRate],[CustomsDutyUOM],[CustomsDutyAmount],[OtherTaxRate],[OtherTaxUOM],[OtherTaxAmount],[CurrentLot],[PreviousLot],[LSPValue],[Making],[ShippingMarks1],[ShippingMarks2],[ShippingMarks3],[ShippingMarks4],[VehicleType],[EngineCapcity],[EngineCapUOM],[orignaldatereg],[OptionalChrgeUOM],[Optioncahrge],[OptionalSumtotal],[OptionalSumExchage],[TouchUser],[TouchTime]) VALUES ('" + TxtSerialNo.Text + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + TxtHSCodeItem.Text + "','" + TxtDescription.Text + "','" + ChkBGIndicator.Checked.ToString() + "','" + TxtCountryItem.Text + "','" + TxtBrand.Text + "','" + TxtModel.Text + "','" + strhawb + "','" + Convert.ToDecimal( TxtTotalDutiableQuantity.Text).ToString() + "','" + TDQUOM.SelectedItem.ToString() + "','" + Convert.ToDecimal(txttotDutiableQty.Text).ToString() + "','" + ddptotDutiableQty.SelectedItem.ToString() + "','" + Convert.ToDecimal(TxtInvQty.Text).ToString() + "','" + Convert.ToDecimal(TxtHSQuantity.Text).ToString() + "','" + HSQTYUOM.SelectedItem + "','" + Convert.ToDecimal(txtAlcoholPer.Text).ToString() + "','" + DrpInvoiceNo.SelectedItem.ToString().Replace("'", "''") + "','" + ChkUnitPrice.Checked + "','" + Convert.ToDecimal(TxtUnitPrice.Text).ToString() + "','" + DRPCurrency.SelectedItem + "','" + TxtExchangeRate.Text + "','" + Convert.ToDecimal(TxtSumExRate.Text).ToString() + "','" + Convert.ToDecimal(TxtTotalLineAmount.Text).ToString() + "','" + Convert.ToDecimal(TxtTotalLineCharges.Text).ToString() + "','" + Convert.ToDecimal(TxtCIFFOB.Text).ToString() + "','" + Convert.ToDecimal(TxtOPQty.Text).ToString() + "','" + DRPOPQUOM.SelectedItem + "','" + Convert.ToDecimal(TxtIPQty.Text).ToString() + "','" + DRPIPQUOM.SelectedItem + "','" + Convert.ToDecimal(TxtINPQty.Text ).ToString()+ "','" + DRPINNPQUOM.SelectedItem + "','" + Convert.ToDecimal(TxtIMPQty.Text).ToString() + "','" + DRPIMPQUOM.SelectedItem + "','" + DrpPreferentialCode.SelectedItem + "','" + Convert.ToDecimal(ItemGSTRate.Text).ToString() + "','" + ItemGSTUOM.Text + "','" + Convert.ToDecimal(TxtItemSumGST.Text).ToString() + "','" + Convert.ToDecimal(TxtExciseDutyRate.Text).ToString() + "','" + TxtExciseDutyUOM.Text + "','" + Convert.ToDecimal(TxtSumExciseDuty.Text).ToString() + "','" + Convert.ToDecimal(TxtCustomsDutyRate.Text).ToString() + "','" + TxtCustomsDutyUOM.Text + "','" + Convert.ToDecimal(TxtSumCustomsDuty.Text).ToString() + "','" + Convert.ToDecimal(TxtOtherTaxRate.Text).ToString() + "','" + DrpOtherUOM.SelectedItem + "','" + Convert.ToDecimal(TxtSumOtherTaxRate.Text).ToString() + "','" + TxtCurrentLot.Text + "','" + TxtPreviousLot.Text + "','" + Convert.ToDecimal(txtlsp.Text).ToString() + "','" + DrpMaking.SelectedItem.ToString() + "','" + txtShippingMarks1.Text + "','" + txtShippingMarks2.Text + "','" + txtShippingMarks3.Text + "','" + txtShippingMarks4.Text + "','" + DrpVehicleType.SelectedItem.Text + "','" + TextBox4.Text + "','" + DrpVehicleCapacity.SelectedItem.Text + "','" + OriginalRegDate.Text + "','" + DrpOptionalUom.SelectedItem.Text + "','" + Convert.ToDecimal(TxtOptionalPrice.Text).ToString() + "','" + Convert.ToDecimal(TxtOptionalExchageRate.Text).ToString() + "','" + Convert.ToDecimal(TxtOptionalSumExRate.Text).ToString() + "','" + Touch_user + "','" + strTime + "')");
                    obj.exec(StrQuery1);
                    obj.closecon();

                    


                    //ProductCode 1
                    int p1 = 1;

                    foreach (GridViewRow g1 in ProductCode1Grid1.Rows)
                    {
                        string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;
                        string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                        string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                        if (TxtProductCode1.Text != "")
                        {
                            if (p1 == 1)
                            {
                                if (TxtProQty1.Text == "")
                                {
                                    TxtProQty1.Text = "0.00";
                                }
                                string P1 = ("INSERT INTO [dbo].[CASCDtl] (ItemNo,[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode1.Text + "','" + TxtProQty1.Text + "','" + DrpP1.SelectedItem.Text + "','" + p1 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc1')");
                                obj.exec(P1);
                                obj.closecon();
                            }
                            else
                            {
                                if (!string.IsNullOrWhiteSpace(ProcessingCode1))
                                {
                                    if (TxtProQty1.Text == "")
                                    {
                                        TxtProQty1.Text = "0.00";
                                    }

                                    string P1 = ("INSERT INTO [dbo].[CASCDtl] (ItemNo,[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode1.Text + "','" + TxtProQty1.Text + "','" + DrpP1.SelectedItem.Text + "','" + p1 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc1')");
                                    obj.exec(P1);
                                    obj.closecon();
                                }
                            }
                        }
                        p1++;
                    }



                    //ProductCode 2
                    int p2 = 1;
                    foreach (GridViewRow g2 in ProductCode2Grid1.Rows)
                    {

                        string ProcessingCode1 = (g2.FindControl("TextBox1") as TextBox).Text;
                        string ProcessingCode2 = (g2.FindControl("TextBox2") as TextBox).Text;
                        string ProcessingCode3 = (g2.FindControl("TextBox3") as TextBox).Text;

                        if (TxtProductCode2.Text != "")
                        {
                            if (p2 == 1)
                            {
                                if (TxtProQty2.Text == "")
                                {
                                    TxtProQty2.Text = "0.00";
                                }
                                string P2 = ("INSERT INTO [dbo].[CASCDtl] (ItemNo,[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode2.Text + "','" + TxtProQty2.Text + "','" + DrpP2.SelectedItem + "','" + p2 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc2')");
                                obj.exec(P2);
                                obj.closecon();
                            }
                            else
                            {
                                if (!string.IsNullOrWhiteSpace(ProcessingCode1))
                                {
                                    if (TxtProQty2.Text == "")
                                    {
                                        TxtProQty2.Text = "0.00";
                                    }
                                    string P2 = ("INSERT INTO [dbo].[CASCDtl] (ItemNo,[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode2.Text + "','" + TxtProQty2.Text + "','" + DrpP2.SelectedItem + "','" + p2 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc2')");
                                    obj.exec(P2);
                                    obj.closecon();
                                }
                            }
                        }
                        p2++;
                    }


                    //ProductCode 3
                    int p3 = 1;
                    foreach (GridViewRow g3 in ProductCode3Grid1.Rows)
                    {

                        string ProcessingCode1 = (g3.FindControl("TextBox1") as TextBox).Text;
                        string ProcessingCode2 = (g3.FindControl("TextBox2") as TextBox).Text;
                        string ProcessingCode3 = (g3.FindControl("TextBox3") as TextBox).Text;

                        if (TxtProductCode3.Text != "")
                        {
                            if (p3 == 1)
                            {
                                if (TxtProQty3.Text == "")
                                {
                                    TxtProQty3.Text = "0.00";
                                }
                                string P1 = ("INSERT INTO [dbo].[CASCDtl] (ItemNo,[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode3.Text + "','" + TxtProQty3.Text + "','" + DrpP3.SelectedItem + "','" + p3 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc3')");
                                obj.exec(P1);
                                obj.closecon();
                            }
                            else
                            {
                                if (!string.IsNullOrWhiteSpace(ProcessingCode1))
                                {
                                    if (TxtProQty3.Text == "")
                                    {
                                        TxtProQty3.Text = "0.00";
                                    }
                                    string P1 = ("INSERT INTO [dbo].[CASCDtl] (ItemNo,[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode3.Text + "','" + TxtProQty3.Text + "','" + DrpP3.SelectedItem + "','" + p3 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc3')");
                                    obj.exec(P1);
                                    obj.closecon();
                                }
                            }
                        }
                        p3++;
                    }


                    BindItemMaster();




                    //con.Open();
                    //SqlCommand command1113 = new SqlCommand("SELECT max(ItemNo) from [ItemDtl] where MessageType='IPTDEC' and PermitId='" + txt_code.Text + "' ");
                    //command1113.Connection = con;
                    //string max_po_no3 = command1113.ExecuteScalar().ToString();
                    //int m_po_no3 = 0;

                    //int endTagStartPosition3 = max_po_no3.LastIndexOf("/");
                    //max_po_no3 = max_po_no3.Substring(endTagStartPosition3 + 1);
                    //m_po_no3 = Convert.ToInt32(max_po_no3);
                    //if (max_po_no3 != "0")
                    //{
                    //    m_po_no3 = m_po_no3 + 1;

                    //}
                    //string code3 = " " + String.Format("{0:000}", m_po_no3);
                    //con.Close();
                    //TxtSerialNo.Text = code3;

                    string SumItem = "";
                    string qry11 = "select Count(ItemNo) as InvCount from dbo.ItemDtl where PermitId='" + txt_code.Text + "' and MessageType='IPTDEC'";
                    obj.dr = obj.ret_dr(qry11);
                    while (obj.dr.Read())
                    {
                        SumItem = obj.dr[0].ToString();
                        txtnoofitm.Text = SumItem;
                    }

                    //Sum of Item Amount

                    string SumofItemAmount = "";
                    string qry11s2Q = "select SUM(TotalLineAmount) as  TotalLineAmount  from dbo.ItemDtl where PermitId='" + txt_code.Text + "' and MessageType='IPTDEC'";
                    obj.dr = obj.ret_dr(qry11s2Q);
                    while (obj.dr.Read())
                    {
                        SumofItemAmount = obj.dr[0].ToString();
                        txtitmAmt.Text = SumofItemAmount;
                    }


                    //Total GST Amount

                    string TotalGSTAmount = "";
                    string qry11s2 = "select SUM(GSTAmount) as  GSTAmount  from dbo.ItemDtl where PermitId='" + txt_code.Text + "' and MessageType='IPTDEC'";
                    obj.dr = obj.ret_dr(qry11s2);
                    while (obj.dr.Read())
                    {
                        TotalGSTAmount = obj.dr[0].ToString();
                        txttotgstAmt.Text = TotalGSTAmount;

                        if (DrpDecType.SelectedItem.ToString() == "DUT : Duty")
                        {
                            txtAmtPayble.Text = txttotexAmt.Text;
                            lbltap.Text = txttotexAmt.Text;
                        }
                        else
                        {
                            txtAmtPayble.Text = TotalGSTAmount;
                            lbltap.Text = TotalGSTAmount;
                        }
                        //txtAmtPayble.Text = TotalGSTAmount;
                    }

                    //Total CIF/FOB Value
                    string TotalCIFFOBValue = "";
                    string qry11sS2 = "select SUM(CIFFOB) as  GSTAmount  from dbo.ItemDtl where PermitId='" + txt_code.Text + "' and MessageType='IPTDEC'";
                    obj.dr = obj.ret_dr(qry11sS2);
                    while (obj.dr.Read())
                    {
                        TotalCIFFOBValue = obj.dr[0].ToString();
                        txtfobval.Text = TotalCIFFOBValue;

                    }
                    ItemAddGrid.Visible = true;
                    ItemDiv.Visible = true;
                    BtnAddNEWItem.Visible = false;
                    //  DrpInvoiceNo_SelectedIndexChanged(null, null);
                  
                    TxtHSCodeItem.Focus();


                    MyClass objhsnd = new MyClass();
                    string dataexit = "";
                    string qry11s2a = "select * from [ITEM_CASC_HSCODES]  where  HSCode='" + TxtHSCodeItem.Text + "'";
                    objhsnd.dr = objhsnd.ret_dr(qry11s2a);
                    if (objhsnd.dr.Read())
                    {
                        dataexit = objhsnd.dr["HSCode"].ToString();

                    }

                    if (dataexit != "")
                    {
                        if (TxtProductCode1.Text == "")
                        {
                             ScriptManager.RegisterStartupScript(this, GetType(), "Warning", "alert('The following controlled HS code(s) does not have a CASC Product Code. Item # " + TxtSerialNo.Text + " - " + TxtHSCodeItem.Text + "');", true);

                        }
                    }
                    Itemclear();

                }

                else
                {

                    string Touch_user = Session["UserId"].ToString();
                    string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    //   var InvoiceDate = DateTime.Parse(this.txtinvDate.Value, new CultureInfo("en-US", true));
                    string strhawb = "";
                    if (string.IsNullOrWhiteSpace(TxtHAWB.Text))
                    {
                        strhawb = "";
                    }
                    else
                    {
                        strhawb = TxtHAWB.SelectedItem.ToString();
                    }

                    if (string.IsNullOrWhiteSpace(TxtOptionalPrice.Text))
                    {
                        TxtOptionalPrice.Text = "0.00";
                    }
                    if (string.IsNullOrWhiteSpace(TxtOptionalExchageRate.Text))
                    {
                        TxtOptionalExchageRate.Text = "0.00";
                    }
                    if (string.IsNullOrWhiteSpace(TxtOptionalSumExRate.Text))
                    {
                        TxtOptionalSumExRate.Text = "0.00";
                    }

                    string StrQuery1 = ("update [dbo].[ItemDtl]  set [HSCode]='" + TxtHSCodeItem.Text + "',[LSPValue]='" + Convert.ToDecimal(txtlsp.Text).ToString() + "',[Description]='" + TxtDescription.Text + "',[DGIndicator]='" + ChkBGIndicator.Checked.ToString() + "',[Contry]= '" + TxtCountryItem.Text + "',[Brand]='" + TxtBrand.Text + "',[Model]='" + TxtModel.Text + "',[InHAWBOBL]='" + strhawb + "',[DutiableQty]='" + Convert.ToDecimal(TxtTotalDutiableQuantity.Text).ToString() + "',[DutiableUOM]='" + TDQUOM.SelectedItem.ToString() + "',[TotalDutiableQty]='" + Convert.ToDecimal(txttotDutiableQty.Text).ToString() + "',[TotalDutiableUOM]='" + ddptotDutiableQty.SelectedItem.ToString() + "',[InvoiceQuantity]='" + Convert.ToDecimal(TxtInvQty.Text).ToString() + "',[HSQty]='" + Convert.ToDecimal(TxtHSQuantity.Text).ToString() + "', [HSUOM]='" + HSQTYUOM.SelectedItem + "',[AlcoholPer]='" + Convert.ToDecimal(txtAlcoholPer.Text).ToString() + "',[InvoiceNo]='" + DrpInvoiceNo.SelectedItem.ToString().Replace("'","''") + "',[ChkUnitPrice]='" + ChkUnitPrice.Checked + "',[UnitPrice]='" + TxtUnitPrice.Text + "',[UnitPriceCurrency]='" + DRPCurrency.SelectedItem + "',[ExchangeRate]='" + Convert.ToDecimal(TxtExchangeRate.Text).ToString() + "',[SumExchangeRate]='" + Convert.ToDecimal(TxtSumExRate.Text).ToString() + "',[TotalLineAmount]='" + Convert.ToDecimal(TxtTotalLineAmount.Text).ToString() + "',[InvoiceCharges]='" + Convert.ToDecimal(TxtTotalLineCharges.Text).ToString() + "',[CIFFOB]='" + Convert.ToDecimal(TxtCIFFOB.Text).ToString() + "',[OPQty]='" + Convert.ToDecimal(TxtOPQty.Text).ToString() + "',[OPUOM]='" + DRPOPQUOM.SelectedItem + "',[IPQty]='" + Convert.ToDecimal(TxtIPQty.Text).ToString() + "',[IPUOM]='" + DRPIPQUOM.SelectedItem + "',[InPqty]='" + Convert.ToDecimal(TxtINPQty.Text).ToString() + "',[InPUOM]='" + DRPINNPQUOM.SelectedItem + "',[ImPQty]='" + Convert.ToDecimal(TxtIMPQty.Text).ToString() + "',[ImPUOM]='" + DRPIMPQUOM.SelectedItem + "',[PreferentialCode]='" + DrpPreferentialCode.SelectedItem + "',[GSTRate]='" + Convert.ToDecimal(ItemGSTRate.Text).ToString() + "',[GSTUOM]='" + ItemGSTUOM.Text + "',[GSTAmount]='" + Convert.ToDecimal(TxtItemSumGST.Text).ToString() + "',[ExciseDutyRate]='" + Convert.ToDecimal(TxtExciseDutyRate.Text).ToString() + "', [ExciseDutyUOM]='" + TxtExciseDutyUOM.Text + "',[ExciseDutyAmount]='" + Convert.ToDecimal(TxtSumExciseDuty.Text ).ToString()+ "',[CustomsDutyRate]='" + Convert.ToDecimal(TxtCustomsDutyRate.Text).ToString() + "',[CustomsDutyUOM]='" + TxtCustomsDutyUOM.Text + "',[CustomsDutyAmount]='" + Convert.ToDecimal(TxtSumCustomsDuty.Text).ToString() + "',[OtherTaxRate]='" + Convert.ToDecimal(TxtOtherTaxRate.Text).ToString() + "',[OtherTaxUOM]='" + DrpOtherUOM.SelectedItem + "',[OtherTaxAmount]='" + Convert.ToDecimal(TxtSumOtherTaxRate.Text ).ToString()+ "',[CurrentLot]='" + TxtCurrentLot.Text + "',[PreviousLot]='" + TxtPreviousLot.Text + "',[Making]='" + DrpMaking.SelectedItem.ToString() + "',[ShippingMarks1]='" + txtShippingMarks1.Text + "',[ShippingMarks2]='" + txtShippingMarks2.Text + "',[ShippingMarks3]='" + txtShippingMarks3.Text + "',[ShippingMarks4]='" + txtShippingMarks4.Text + "',[VehicleType]='" + DrpVehicleType.SelectedItem.Text + "',[EngineCapcity]='" + TextBox4.Text + "',[EngineCapUOM]='" + DrpVehicleCapacity.SelectedItem.Text + "',[orignaldatereg]='" + OriginalRegDate.Text + "',[TouchUser]='" + Touch_user + "',OptionalChrgeUOM='" + DrpOptionalUom.SelectedItem.Text + "',[Optioncahrge]='" + Convert.ToDecimal(TxtOptionalPrice.Text).ToString() + "',[OptionalSumtotal]='" + Convert.ToDecimal(TxtOptionalExchageRate.Text ).ToString()+ "',[OptionalSumExchage]='" + Convert.ToDecimal(TxtOptionalSumExRate.Text).ToString() + "',[TouchTime]='" + strTime + "' where  MessageType='IPTDEC' AND PermitId='" + txt_code.Text + "' and ItemNo='" + TxtSerialNo.Text + "'");
                    obj.exec(StrQuery1);
                    obj.closecon();

                   



                    string cpc = ("delete from CASCDtl where PermitId='" + txt_code.Text + "' and CASCId='Casc1' and ItemNo='" + TxtSerialNo.Text + "'");
                    obj.exec(cpc);
                    obj.closecon();

                    //ProductCode 1
                    int p1 = 1;
                    foreach (GridViewRow g1 in ProductCode1Grid1.Rows)
                    {
                        string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;
                        string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                        string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                        if (TxtProductCode1.Text != "")
                        {
                            if (p1 == 1)
                            {
                                if (TxtProQty1.Text == "")
                                {
                                    TxtProQty1.Text = "0.00";
                                }
                                string P1 = ("INSERT INTO [dbo].[CASCDtl] (ItemNo,[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode1.Text + "','" + TxtProQty1.Text + "','" + DrpP1.SelectedItem.Text + "','" + p1 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc1')");
                                obj.exec(P1);
                                obj.closecon();
                            }
                            else
                            {
                                if (!string.IsNullOrWhiteSpace(ProcessingCode1))
                                {
                                    if (TxtProQty1.Text == "")
                                    {
                                        TxtProQty1.Text = "0.00";
                                    }
                                    string P1 = ("INSERT INTO [dbo].[CASCDtl] (ItemNo,[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode1.Text + "','" + TxtProQty1.Text + "','" + DrpP1.SelectedItem.Text + "','" + p1 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc1')");
                                    obj.exec(P1);
                                    obj.closecon();
                                }
                            }
                        }
                        p1++;
                    }
                    //foreach (GridViewRow g1 in ProductCode1Grid1.Rows)
                    //{

                    //    string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;
                    //    string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                    //    string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;
                    //    if (TxtProductCode1.Text != "")
                    //    {

                    //        string P1 = ("INSERT INTO [dbo].[CASCDtl] (ItemNo,[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode1.Text + "','" + TxtProQty1.Text + "','" + DrpP1.SelectedItem + "','" + p1 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc1')");
                    //        obj.exec(P1);
                    //        obj.closecon();
                    //    }
                    //    p1++;
                    //}

                    string cpc2 = ("delete from CASCDtl where PermitId='" + txt_code.Text + "' and CASCId='Casc2' and ItemNo='" + TxtSerialNo.Text + "'");
                    obj.exec(cpc2);
                    obj.closecon();
                    //ProductCode 2
                    int p2 = 1;
                    foreach (GridViewRow g2 in ProductCode2Grid1.Rows)
                    {

                        string ProcessingCode1 = (g2.FindControl("TextBox1") as TextBox).Text;
                        string ProcessingCode2 = (g2.FindControl("TextBox2") as TextBox).Text;
                        string ProcessingCode3 = (g2.FindControl("TextBox3") as TextBox).Text;

                        if (TxtProductCode2.Text != "")
                        {
                            if (p2 == 1)
                            {
                                if (TxtProQty2.Text == "")
                                {
                                    TxtProQty2.Text = "0.00";
                                }
                                string P1 = ("INSERT INTO [dbo].[CASCDtl] (ItemNo,[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode2.Text + "','" + TxtProQty2.Text + "','" + DrpP2.SelectedItem + "','" + p2 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc2')");
                                obj.exec(P1);
                                obj.closecon();
                            }
                            else
                            {
                                if (!string.IsNullOrWhiteSpace(ProcessingCode1))
                                {
                                    if (TxtProQty2.Text == "")
                                    {
                                        TxtProQty2.Text = "0.00";
                                    }
                                    string P1 = ("INSERT INTO [dbo].[CASCDtl] (ItemNo,[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode2.Text + "','" + TxtProQty2.Text + "','" + DrpP2.SelectedItem + "','" + p2 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc2')");
                                    obj.exec(P1);
                                    obj.closecon();
                                }
                            }
                        }

                        p2++;
                    }

                    string cpc3 = ("delete from CASCDtl where PermitId='" + txt_code.Text + "' and CASCId='Casc3' and ItemNo='" + TxtSerialNo.Text + "'");
                    obj.exec(cpc3);
                    obj.closecon();
                    //ProductCode 3
                    int p3 = 1;
                    foreach (GridViewRow g3 in ProductCode3Grid1.Rows)
                    {

                        string ProcessingCode1 = (g3.FindControl("TextBox1") as TextBox).Text;
                        string ProcessingCode2 = (g3.FindControl("TextBox2") as TextBox).Text;
                        string ProcessingCode3 = (g3.FindControl("TextBox3") as TextBox).Text;
                        if (TxtProductCode3.Text != "")
                        {
                            if (p3 == 1)
                            {
                                if (TxtProQty3.Text == "")
                                {
                                    TxtProQty3.Text = "0.00";
                                }
                                string P1 = ("INSERT INTO [dbo].[CASCDtl] (ItemNo,[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode3.Text + "','" + TxtProQty3.Text + "','" + DrpP3.SelectedItem + "','" + p3 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc3')");
                                obj.exec(P1);
                                obj.closecon();
                            }
                            else
                            {
                                if (!string.IsNullOrWhiteSpace(ProcessingCode1))
                                {
                                    if (TxtProQty3.Text == "")
                                    {
                                        TxtProQty3.Text = "0.00";
                                    }
                                    string P1 = ("INSERT INTO [dbo].[CASCDtl] (ItemNo,[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode3.Text + "','" + TxtProQty3.Text + "','" + DrpP3.SelectedItem + "','" + p3 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc3')");
                                    obj.exec(P1);
                                    obj.closecon();
                                }
                            }
                        }

                        p3++;
                    }
                    BindItemMaster();
                    SummaryCalculate();
                    ItemAddGrid.Visible = true;
                    ItemDiv.Visible = true;
                    BtnAddNEWItem.Visible = false;
                    // DrpInvoiceNo_SelectedIndexChanged(null, null);
                 
                    TxtHSCodeItem.Focus();
                    //  InvoiceClr();

                    MyClass objhsnd = new MyClass();
                    string dataexit = "";
                    string qry11s2a = "select * from [ITEM_CASC_HSCODES]  where  HSCode='" + TxtHSCodeItem.Text + "'";
                    objhsnd.dr = objhsnd.ret_dr(qry11s2a);
                    if (objhsnd.dr.Read())
                    {
                        dataexit = objhsnd.dr["HSCode"].ToString();

                    }

                    if (dataexit != "")
                    {
                        if (TxtProductCode1.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Warning", "alert('The following controlled HS code(s) does not have a CASC Product Code. Item # " + TxtSerialNo.Text + " - " + TxtHSCodeItem.Text + " ');", true);

                        }
                    }
                    Itemclear();


                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('You are already added 50 Item ... !!!');", true);

            }
        }

        protected void AddItemGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            AddItemGrid.PageIndex = e.NewPageIndex;
            SetData();
            BindItemMaster();


        }

        //protected void NewInvoice_Click(object sender, EventArgs e)
        //{
        //    //InvoiceGrid.Visible = false;
        //    //InvoiceDiv.Visible = true;
        //    //NewInvoice.Visible = false;
        //    //InvoiceNo();

        //}

        protected void BtnAddNEWItem_Click(object sender, EventArgs e)
        {
            ItemAddGrid.Visible = true;
            ItemDiv.Visible = true;
            BtnAddNEWItem.Visible = false;
            ItemNO();
        }

        private void AddDynamicLabels()
        {
            string totinvAmt = "";
            string ConString = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            SqlConnection con = new SqlConnection(ConString);
            string CmdString = "select Sum(TIAmount) as TIAmount,TICurrency  from dbo.InvoiceDtl where PermitId='" + txt_code.Text + "' and MessageType='IPTDEC' group by TICurrency ORDER BY TICurrency DESC";
            SqlCommand cmd = new SqlCommand(CmdString, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Label lbl = new Label();
                lbl.Text = reader["TICurrency"].ToString() + " " + reader["TIAmount"].ToString();
                lbltotinvAmt.Text = reader["TIAmount"].ToString();
                lbl.BackColor = System.Drawing.Color.WhiteSmoke;
                lbl.BorderStyle = BorderStyle.Solid;
                lbl.BorderWidth = 1;
                lbl.Width = 150;
                totinvAmt = totinvAmt + " " + lbl.Text + " " + Environment.NewLine;



                div3.Controls.Add(lbl);
                div3.Controls.Add(new LiteralControl("<br />"));

                


            }



            string termtype = "";

            string ConString1 = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            SqlConnection con1 = new SqlConnection(ConString1);

            string CmdString1 = "select SUBSTRING(TermType, 1, 3) as TermType  from dbo.InvoiceDtl where PermitId='" + txt_code.Text + "' and MessageType='IPTDEC' group by TermType ORDER BY TermType asc";
            SqlCommand cmd1 = new SqlCommand(CmdString1, con1);
            con1.Open();
            SqlDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                Label lbl1 = new Label();
                lbl1.Text = reader1["TermType"].ToString();               
                lbl1.BackColor = System.Drawing.Color.WhiteSmoke;
                lbl1.BorderStyle = BorderStyle.Solid;
                lbl1.BorderWidth = 1;
                lbl1.Width = 150;
                termtype = termtype + " " + lbl1.Text + " " + Environment.NewLine;


                div9.Controls.Add(lbl1);
                div9.Controls.Add(new LiteralControl("<br />"));




            }

            lblinvoiceAmt.Text = totinvAmt;
            con.Close();
        }
        private void AddDynamicItem()
        {
            string totinvAmt = "";
            string ConString = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            SqlConnection con = new SqlConnection(ConString);
            string CmdString = "select distinct (UnitPriceCurrency), sum(TotalLineAmount) as TotalLineAmount from ItemDtl where PermitId='" + txt_code.Text + "' and MessageType='IPTDEC'  GROUP BY UnitPriceCurrency ORDER BY UnitPriceCurrency DESC";
            SqlCommand cmd = new SqlCommand(CmdString, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Label lbl = new Label();
                lbl.Text = reader["UnitPriceCurrency"].ToString() + " " + reader["TotalLineAmount"].ToString();
                lbltotinvAmt.Text = reader["TotalLineAmount"].ToString();
                lbl.BackColor = System.Drawing.Color.WhiteSmoke;
                lbl.BorderStyle = BorderStyle.Solid;
                lbl.BorderWidth = 1;
                lbl.Width = 120;
                totinvAmt = totinvAmt + " " + lbl.Text + " " + Environment.NewLine;
                div6.Controls.Add(lbl);
                div6.Controls.Add(new LiteralControl("<br />"));
                div10.Controls.Add(lbl);
                div10.Controls.Add(new LiteralControl("<br />"));
                
            }
            Label1.Text = totinvAmt;
            con.Close();
        }


        protected void InvoiceEdit_Click(object sender, ImageClickEventArgs e)
        {
            GridViewRow grdrow = (GridViewRow)((ImageButton)sender).NamingContainer as GridViewRow;
            Label ID1 = (Label)grdrow.FindControl("lblID");
            string ID = ID1.Text;
            if (ID != "")
            {
                editInvoice = true;
            }


            string SuplierCode, Importer = "";
            string strBindTxtBox = "select * from [InvoiceDtl] where Id=" + ID;
            obj.dr = obj.ret_dr(strBindTxtBox);
            while (obj.dr.Read())
            {
                txtserial.Text = obj.dr["SNo"].ToString();
                txtinvNo.Text = obj.dr["InvoiceNo"].ToString();
                txtinvDate1.Text = Convert.ToDateTime(obj.dr["InvoiceDate"].ToString()).ToString("dd/MM/yyyy");
                DrpTerms.ClearSelection();
                DrpTerms.Items.FindByText(obj.dr["TermType"].ToString()).Selected = true;
                //DrpTerms.SelectedValue= obj.dr[4].ToString();


                string chkind = obj.dr["AdValoremIndicator"].ToString();
                if (chkind == "True")
                {
                    chkindicator.Checked = true;
                }
                else if (chkind == "False")
                {
                    chkindicator.Checked = false;
                }
                string chkrate = obj.dr["PreDutyRateIndicator"].ToString();
                if (chkrate == "True")
                {
                    chkrateind.Checked = true;
                }
                else if (chkrate == "False")
                {
                    chkrateind.Checked = false;
                }

                DrpSupImpRel.ClearSelection();
                DrpSupImpRel.Items.FindByText(obj.dr["SupplierImporterRelationship"].ToString()).Selected = true;
                //DrpSupImpRel.SelectedItem.Text = obj.dr[7].ToString();

                //   Drpcurrency1.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
                Drpcurrency1.ClearSelection();
                Drpcurrency1.Items.FindByText(obj.dr["TICurrency"].ToString()).Selected = true;

                LblTotalInvoice.Text = obj.dr["TIExRate"].ToString();
                TxtTotalInvoice.Text = obj.dr["TIAmount"].ToString();
                SumTotalInvoice.Text = obj.dr["TISAmount"].ToString();

                //txt_ln.Text = obj.dr[3].ToString();
                OtherTaxableChargePer.Text = obj.dr["OTCCharge"].ToString();
                Drpcurrency2.ClearSelection();
                Drpcurrency2.Items.FindByText(obj.dr["OTCCurrency"].ToString()).Selected = true;

                lblOtherTaxableCharge.Text = obj.dr["OTCExRate"].ToString();
                TxtOtherTaxableCharge.Text = obj.dr["OTCAmount"].ToString();
                SumOtherTaxableCharge.Text = obj.dr["OTCSAmount"].ToString();
                FrieghtChargesPer.Text = obj.dr["FCCharge"].ToString();

                Drpcurrency3.ClearSelection();
                Drpcurrency3.Items.FindByText(obj.dr["FCCurrency"].ToString()).Selected = true;
                //  Drpcurrency3.SelectedItem.Text = obj.dr[10].ToString();
                LblFrieghtCharges.Text = obj.dr["FCExRate"].ToString();
                TxtFrieghtCharges.Text = obj.dr["FCAmount"].ToString();
                SumFrieghtCharges.Text = obj.dr["FCSAmount"].ToString();


                InsuranceChargesPer.Text = obj.dr["ICCharge"].ToString();
                Drpcurrency4.ClearSelection();
                Drpcurrency4.Items.FindByText(obj.dr["ICCurrency"].ToString()).Selected = true;
                // Drpcurrency4.SelectedItem.Text = obj.dr[25].ToString();
                lblInsuranceCharges.Text = obj.dr["ICExRate"].ToString();
                TxtInsuranceCharges.Text = obj.dr["ICAmount"].ToString();
                SumInsuranceCharges.Text = obj.dr["ICSAmount"].ToString();
                LblSumOFTotal.Text = obj.dr["CIFSUMAmount"].ToString();
                LblGSTpercentage.Text = obj.dr["GSTPercentage"].ToString();
                LblSumOFTotal.Text = obj.dr["GSTSUMAmount"].ToString();


                SuplierCode = obj.dr["SupplierCode"].ToString();
                Importer = obj.dr["ImportPartyCode"].ToString();
                string supp = "select * from [SUPPLIERMANUFACTURERPARTY] where Code='" + SuplierCode + "'";
                obj.dr = obj.ret_dr(supp);
                while (obj.dr.Read())
                {
                    txtcodeinvq.Text = obj.dr[1].ToString();
                    txtName.Text = obj.dr[2].ToString();
                    txtName1.Text = obj.dr[3].ToString();
                    txtcruei.Text = obj.dr[4].ToString();
                }


                //TxtImppartyCode
                //string imp = "select * from [Importer] where Code='" + Importer + "'";
                //obj.dr = obj.ret_dr(imp);
                //while (obj.dr.Read())
                //{
                //    TxtImppartyCode.Text = obj.dr[1].ToString();
                //    TxtImppartyName.Text = obj.dr[2].ToString();
                //    TxtImppartyName1.Text = obj.dr[3].ToString();
                //    TxtImppartyCRUEI.Text = obj.dr[4].ToString();
                //}
                // DrpTerms_SelectedIndexChanged(null, null);
                //InvoiceGrid.Visible = false;
                //InvoiceDiv.Visible = true;
                //NewInvoice.Visible = false;
            }

            DrpTerms_SelectedIndexChanged(null, null);
            TxtTotalInvoice_TextChanged(null, null);
            InsuranceChargesPer_TextChanged(null, null);
            TxtFrieghtCharges_TextChanged(null, null);
        }

        protected void ItemEdit_Click(object sender, ImageClickEventArgs e)
        {
            btnprev.Enabled = true;
            btnnxt.Enabled = true;

            string stra = "select Id,Name from [CommonMaster] where TypeId='12' and StatusID=1 order by Name";
            obj.dr = obj.ret_dr(stra);
            DrpMaking.DataSource = obj.dr;
            DrpMaking.DataTextField = "Name";
            DrpMaking.DataValueField = "Id";
            DrpMaking.DataBind();
            obj.closecon();
            DrpMaking.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));

            string Invoice = txt_code.Text;
            string striW = "select * from [InvoiceDtl] where MessageType='IPTDEC' AND PermitId='" + Invoice + "'  order by InvoiceNo";
            obj.dr = obj.ret_dr(striW);
            obj.BindDropDown(DrpInvoiceNo, obj.dr, "Id", "InvoiceNo");
            //DrpInvoiceNo.DataSource = null;
            //DrpInvoiceNo.DataSource = obj.dr;
            //DrpInvoiceNo.DataTextField = "InvoiceNo";
            //DrpInvoiceNo.DataValueField = "Id";
            //DrpInvoiceNo.DataBind();
            //obj.closecon();
            //DrpInvoiceNo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));

            GridViewRow grdrow = (GridViewRow)((ImageButton)sender).NamingContainer as GridViewRow;
            Label ID1 = (Label)grdrow.FindControl("lblID");
            string ID = ID1.Text;

            //warning
            // string SuplierCode, Importer = "";

            string strBindTxtBox = "select * from [ItemDtl] where Id=" + ID;
            obj.dr = obj.ret_dr(strBindTxtBox);
            while (obj.dr.Read())
            {
                try
                {

                    TxtSerialNo.Text = obj.dr["ItemNo"].ToString();
                    itemno.Text = obj.dr["ItemNo"].ToString();
                    TxtHSCodeItem.Text = obj.dr["HSCode"].ToString();
                    TxtHSCodeItem_TextChanged(null, null);
                    TxtDescription.Text = obj.dr["Description"].ToString();
                    string chkrate = obj.dr["DGIndicator"].ToString();
                    if (chkrate == "True")
                    {
                        ChkBGIndicator.Checked = true;
                    }
                    else if (chkrate == "False")
                    {
                        ChkBGIndicator.Checked = false;
                    }
                    TxtCountryItem.Text = obj.dr["Contry"].ToString();

                    TxtBrand.Text = obj.dr["Brand"].ToString();
                    TxtModel.Text = obj.dr["model"].ToString();
                    string[] hblvalue = obj.dr["InHAWBOBL"].ToString().Split(',');
                    for (int i = 0; i < hblvalue.Length; i++)
                    {
                        TxtHAWB.Items.Add(hblvalue[i].ToString());
                    }
                    lblhblValue.Text = txthBlCargo.Text;
                    //TxtHAWB.ClearSelection();
                    //TxtHAWB.Items.FindByText(obj.dr["InHAWBOBL"].ToString()).Selected = true;
                    //TxtHAWB.Text = obj.dr["InHAWBOBL"].ToString();
                    TxtTotalDutiableQuantity.Text = obj.dr["DutiableQty"].ToString();
                    TDQUOM.ClearSelection();
                    TDQUOM.Items.FindByText(obj.dr["DutiableUOM"].ToString()).Selected = true;
                    txttotDutiableQty.Text = obj.dr["TotalDutiableQty"].ToString();
                    ddptotDutiableQty.ClearSelection();
                    ddptotDutiableQty.Items.FindByText(obj.dr["TotalDutiableUOM"].ToString()).Selected = true;
                    txtAlcoholPer.Text = obj.dr["AlcoholPer"].ToString();
                    // TDQUOM.SelectedItem.Text = obj.dr["TotalDutiableUOM"].ToString();
                    TxtInvQty.Text = obj.dr["InvoiceQuantity"].ToString();
                    TxtHSQuantity.Text = obj.dr["HSQty"].ToString();
                    HSQTYUOM.ClearSelection();
                    HSQTYUOM.Items.FindByText(obj.dr["HSUOM"].ToString()).Selected = true;

                    //HSQTYUOM.ClearSelection();
                    //HSQTYUOM.SelectedItem.Text = obj.dr["HSUOM"].ToString();
                    string invno = obj.dr["InvoiceNo"].ToString();
                    DrpInvoiceNo.ClearSelection();
                    string striW1 = "select * from [InvoiceDtl] where MessageType='IPTDEC' AND PermitId='" + Invoice + "' and  InvoiceNo='" + obj.dr["InvoiceNo"].ToString() + "' order by InvoiceNo";
                    InpaymentClass objinv = new InpaymentClass();
                    objinv.dr = objinv.ret_dr(striW1);
                    if (objinv.dr.Read())
                    {
                        DrpInvoiceNo.Items.FindByText(obj.dr["InvoiceNo"].ToString()).Selected = true;
                    }
                    else
                    {
                        DrpInvoiceNo.Items.FindByText("--Select--").Selected = true;
                    }
                    //DrpInvoiceNo.Items.FindByText(obj.dr["InvoiceNo"].ToString()).Selected = true;                    
                    // DrpInvoiceNo.SelectedItem.Text = obj.dr[16].ToString();
                    string ChkUnitPrice1 = obj.dr["ChkUnitPrice"].ToString();
                    if (ChkUnitPrice1 == "True")
                    {
                        ChkUnitPrice.Checked = true;
                    }
                    else if (ChkUnitPrice1 == "False")
                    {
                        ChkUnitPrice.Checked = false;
                    }
                    ChkUnitPrice_CheckedChanged(null, null);

                    TxtUnitPrice.Text = obj.dr["UnitPrice"].ToString();

                    DRPCurrency.ClearSelection();
                    DRPCurrency.Items.FindByText(obj.dr["UnitPriceCurrency"].ToString()).Selected = true;
                    //DRPCurrency.SelectedItem.Text = obj.dr[19].ToString();
                    TxtExchangeRate.Text = obj.dr["ExchangeRate"].ToString();
                    TxtSumExRate.Text = obj.dr["SumExchangeRate"].ToString();
                    TxtTotalLineAmount.Text = obj.dr["TotalLineAmount"].ToString();
                    TxtTotalLineCharges.Text = obj.dr["InvoiceCharges"].ToString();
                    TxtCIFFOB.Text = obj.dr["CIFFOB"].ToString();


                    TxtOPQty.Text = Math.Round(Convert.ToDecimal(obj.dr["OPQty"].ToString()), 0).ToString();
                    if (TxtOPQty.Text != "0")
                    {
                        ChkPackInfo.Checked = true;
                        ChkPackInfo_CheckedChanged(null, null);
                    }
                    else
                    {
                        ChkPackInfo.Checked = false;
                        ChkPackInfo_CheckedChanged(null, null);
                    }
                    DRPOPQUOM.ClearSelection();
                    DRPOPQUOM.Items.FindByText(obj.dr["OPUOM"].ToString()).Selected = true;



                    // DRPOPQUOM.SelectedItem.Text = obj.dr[26].ToString();
                    TxtIPQty.Text = Math.Round(Convert.ToDecimal(obj.dr["IPQty"].ToString()), 0).ToString();

                    DRPIPQUOM.ClearSelection();
                    DRPIPQUOM.Items.FindByText(obj.dr["IPUOM"].ToString()).Selected = true;
                    // DRPIPQUOM.SelectedItem.Text = obj.dr[28].ToString();
                    TxtINPQty.Text = Math.Round(Convert.ToDecimal(obj.dr["InPqty"].ToString()), 0).ToString();

                    DRPINNPQUOM.ClearSelection();
                    DRPINNPQUOM.Items.FindByText(obj.dr["InPUOM"].ToString()).Selected = true;
                    // DRPINNPQUOM.SelectedItem.Text = obj.dr[30].ToString();
                    TxtIMPQty.Text = Math.Round(Convert.ToDecimal(obj.dr["ImPQty"].ToString()), 0).ToString();

                    DRPIMPQUOM.ClearSelection();
                    DRPIMPQUOM.Items.FindByText(obj.dr["ImPUOM"].ToString()).Selected = true;
                    //DRPIMPQUOM.SelectedItem.Text = obj.dr[32].ToString();
                    DrpPreferentialCode.ClearSelection();
                    DrpPreferentialCode.Items.FindByText(obj.dr["PreferentialCode"].ToString()).Selected = true;
                    // DrpPreferentialCode.SelectedItem.Text = obj.dr[33].ToString();
                    txtlsp.Text = obj.dr["LSPValue"].ToString();
                    ItemGSTRate.Text = obj.dr["GSTRate"].ToString();
                    ItemGSTUOM.Text = obj.dr["GSTUOM"].ToString();
                    TxtItemSumGST.Text = obj.dr["GSTAmount"].ToString();
                    TxtExciseDutyRate.Text = obj.dr["ExciseDutyRate"].ToString();
                    TxtExciseDutyUOM.Text = obj.dr["ExciseDutyUOM"].ToString();
                    TxtSumExciseDuty.Text = obj.dr["ExciseDutyAmount"].ToString();
                    TxtCustomsDutyRate.Text = obj.dr["CustomsDutyRate"].ToString();
                    TxtCustomsDutyUOM.Text = obj.dr["CustomsDutyUOM"].ToString();
                    TxtSumCustomsDuty.Text = obj.dr["CustomsDutyAmount"].ToString();
                    TxtOtherTaxRate.Text = obj.dr["OtherTaxRate"].ToString();


                    DrpOtherUOM.ClearSelection();
                    DrpOtherUOM.Items.FindByText(obj.dr["OtherTaxUOM"].ToString()).Selected = true;
                    //DrpOtherUOM.SelectedItem.Text = obj.dr[44].ToString();
                    TxtSumOtherTaxRate.Text = obj.dr["OtherTaxAmount"].ToString();
                    TxtCurrentLot.Text = obj.dr["CurrentLot"].ToString();


                    if (TxtCurrentLot.Text != "")
                    {
                        Chklot.Checked = true;
                        Chklot_CheckedChanged(null, null);
                    }
                    else
                    {
                        Chklot.Checked = false;
                        Chklot_CheckedChanged(null, null);
                    }

                    DrpMaking.ClearSelection();
                    DrpMaking.Items.FindByText(obj.dr["Making"].ToString()).Selected = true;
                    // DrpMaking.SelectedItem.Text = obj.dr[47].ToString();
                    TxtPreviousLot.Text = obj.dr["PreviousLot"].ToString();
                    txtShippingMarks1.Text = obj.dr["ShippingMarks1"].ToString();
                    txtShippingMarks2.Text = obj.dr["ShippingMarks2"].ToString();
                    txtShippingMarks3.Text = obj.dr["ShippingMarks3"].ToString();
                    txtShippingMarks4.Text = obj.dr["ShippingMarks4"].ToString();
                    if (!string.IsNullOrWhiteSpace(obj.dr["VehicleType"].ToString()))
                    {
                        if (obj.dr["VehicleType"].ToString() != "-Select-")
                        {

                            DrpVehicleType.ClearSelection();
                            DrpVehicleType.Items.FindByText(obj.dr["VehicleType"].ToString()).Selected = true;
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(obj.dr["OptionalChrgeUOM"].ToString()))
                    {
                        if (obj.dr["OptionalChrgeUOM"].ToString() != "-Select-")
                        {
                            DrpOptionalUom.ClearSelection();
                            DrpOptionalUom.Items.FindByText(obj.dr["OptionalChrgeUOM"].ToString()).Selected = true;
                        }
                    }


                    TextBox4.Text = obj.dr["EngineCapcity"].ToString();
                    TxtOptionalPrice.Text = obj.dr["Optioncahrge"].ToString();
                    TxtOptionalExchageRate.Text = obj.dr["OptionalSumtotal"].ToString();
                    TxtOptionalSumExRate.Text = obj.dr["OptionalSumExchage"].ToString();
                    if (!string.IsNullOrWhiteSpace(obj.dr["EngineCapUOM"].ToString()))
                    {
                        if (obj.dr["EngineCapUOM"].ToString() != "-Select-")
                        {
                            DrpVehicleCapacity.ClearSelection();
                            DrpVehicleCapacity.Items.FindByText(obj.dr["EngineCapUOM"].ToString()).Selected = true;
                        }
                    }

                    OriginalRegDate.Text = obj.dr["orignaldatereg"].ToString();


                    editbindProduct1(ID);
                    editbindProduct2(ID);
                    editbindProduct3(ID);
                    string co = "select * from [Country] where CountryCode='" + TxtCountryItem.Text + "'";
                    obj.dr = obj.ret_dr(co);
                    while (obj.dr.Read())
                    {
                        txtcname.Text = obj.dr["Description"].ToString();
                    }

                    ItemAddGrid.Visible = true;
                    ItemDiv.Visible = true;
                    BtnAddNEWItem.Visible = false;
                    DrpInvoiceNo_SelectedIndexChanged(null, null);
                    //HSQTYUOM_SelectedIndexChanged(null, null);
                    return;
                }
                //EditItem();


                catch (Exception ex)
                {
                    ex.ToString();
                }
            }


        }

        private void editbindProduct1(string ID)
        {
            try
            {
                string strBindTxtBox = "select * from [ItemDtl] where Id=" + ID;
                obj.dr = obj.ret_dr(strBindTxtBox);
                while (obj.dr.Read())
                {
                    SqlConnection con = new SqlConnection(sqlconn);
                    //SqlCommand cmd1 = new SqlCommand("SELECT T1.Id ,T1.CRP,T1.CompanyName,T1.Name,T1.EmailId,T1.Mobile, T2.Name as Rent ,t1.BudgetFrom,T1.BudgetTo ,T3.Name as Type,T4.Name as Location,T5.PropertyRef,T1.MultipleLocation,T1. MultipleProperty  FROM (select a.Id,a.CompanyName,a.Name,a.EmailId,a.Mobile,a.BudgetFrom,a.BudgetTo,b.Name as CRP,a.MultipleLocation,a.MultipleProperty  from lead a,CommonMaster b where a.Per_Com=b.Id and a.TouchUser='" + Touch_user + "') AS T1 JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.RentorBuy=b.Id) AS T2    ON T1.Id = T2.Id    JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Type=b.Id) AS T3  ON T1.Id = T3.Id     JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Location=b.Id) AS T4   ON T1.Id = T4.Id    JOIN ( select b.ID,b.Name,a.PropertyRef  from Lead_List a,Lead b where a.ParentId=b.Id) AS T5   ON T1.Id = T5.Id order by T1.Id desc", con);
                    //SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3 from ItemDtl a,CASCDtl b where a.PermitId=b.PermitId and b.CASCId='Casc1' and a.PermitId='" + txt_code.Text + "'", con);
                    //SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3 from ItemDtl inner join CASCDtl on ItemDtl.ItemNo=CASCDtl.ItemNo where CASCDtl.CASCId='Casc1' and CASCDtl.PermitId='" + txt_code.Text + "'", con);
                    SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3, Quantity , ProductCode from CASCDtl  where CASCId='Casc1' and PermitId='" + txt_code.Text + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "' ORDER BY RowNumber asc", con);
                    string ff = "select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3, Quantity , ProductCode,ProductUOM from CASCDtl  where CASCId='Casc1' and PermitId='" + txt_code.Text + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "' ORDER BY RowNumber asc ";
                    InpaymentClass objprc = new InpaymentClass();
                    objprc.dr = objprc.ret_dr(ff);
                    if (objprc.dr.Read())
                    {
                        TxtProQty1.Text = objprc.dr["Quantity"].ToString();
                        TxtProductCode1.Text = objprc.dr["ProductCode"].ToString();
                        if (TxtProductCode1.Text != "")
                        {
                            Chkitemcasc.Checked = true;
                            Chkitemcasc_CheckedChanged(null, null);
                        }
                        else
                        {
                            Chkitemcasc.Checked = false;
                            Chkitemcasc_CheckedChanged(null, null);
                        }
                        DrpP1.ClearSelection();
                        DrpP1.Items.FindByText(objprc.dr["ProductUOM"].ToString()).Selected = true;
                        //DrpP3.SelectedItem.Text = obj.dr["ProductUOM"].ToString();
                    }

                    SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);


                    DataTable dt = new DataTable();
                    sda1.Fill(dt);
                    if (dt.Rows.Count <= 0)
                    {
                        dt.Rows.Add();
                    }
                    ViewState["ProductCode1"] = dt;
                    ProductCode1Grid1.DataSource = ViewState["ProductCode1"] as DataTable;
                    ProductCode1Grid1.DataBind();
                    int rowIndex = 0;
                    if (ViewState["ProductCode1"] != null)
                    {
                        DataTable dt1 = (DataTable)ViewState["ProductCode1"];
                        if (dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt1.Rows.Count; i++)
                            {
                                TextBox box1 = (TextBox)ProductCode1Grid1.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                                TextBox box2 = (TextBox)ProductCode1Grid1.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                                TextBox box3 = (TextBox)ProductCode1Grid1.Rows[rowIndex].Cells[3].FindControl("TextBox3");

                                box1.Text = dt1.Rows[i]["Column1"].ToString();
                                if (dt1.Rows[i]["ProductCode"].ToString() != "")
                                {
                                    Chkitemcasc.Checked = true;
                                    Chkitemcasc_CheckedChanged(null, null);
                                }
                                else
                                {
                                    Chkitemcasc.Checked = false;
                                    Chkitemcasc_CheckedChanged(null, null);
                                }
                                box2.Text = dt1.Rows[i]["Column2"].ToString();
                                box3.Text = dt1.Rows[i]["Column3"].ToString();
                                rowIndex++;
                            }
                            //ProductCode1Grid1.DataSource = dt;
                            //ProductCode1Grid1.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void editbindProduct2(string ID)
        {
            try
            {
                string strBindTxtBox = "select * from [ItemDtl] where Id=" + ID;
                obj.dr = obj.ret_dr(strBindTxtBox);
                while (obj.dr.Read())
                {
                    SqlConnection con = new SqlConnection(sqlconn);
                    //SqlCommand cmd1 = new SqlCommand("SELECT T1.Id ,T1.CRP,T1.CompanyName,T1.Name,T1.EmailId,T1.Mobile, T2.Name as Rent ,t1.BudgetFrom,T1.BudgetTo ,T3.Name as Type,T4.Name as Location,T5.PropertyRef,T1.MultipleLocation,T1. MultipleProperty  FROM (select a.Id,a.CompanyName,a.Name,a.EmailId,a.Mobile,a.BudgetFrom,a.BudgetTo,b.Name as CRP,a.MultipleLocation,a.MultipleProperty  from lead a,CommonMaster b where a.Per_Com=b.Id and a.TouchUser='" + Touch_user + "') AS T1 JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.RentorBuy=b.Id) AS T2    ON T1.Id = T2.Id    JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Type=b.Id) AS T3  ON T1.Id = T3.Id     JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Location=b.Id) AS T4   ON T1.Id = T4.Id    JOIN ( select b.ID,b.Name,a.PropertyRef  from Lead_List a,Lead b where a.ParentId=b.Id) AS T5   ON T1.Id = T5.Id order by T1.Id desc", con);
                    //SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3 from ItemDtl a,CASCDtl b where a.PermitId=b.PermitId and b.CASCId='Casc2' and a.PermitId='" + txt_code.Text + "'", con);
                    //SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3 from ItemDtl inner join CASCDtl on ItemDtl.ItemNo=CASCDtl.ItemNo where CASCDtl.CASCId='Casc2' and CASCDtl.PermitId='" + txt_code.Text + "'", con);
                    SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3, Quantity , ProductCode from CASCDtl  where CASCId='Casc2' and PermitId='" + txt_code.Text + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "' ORDER BY RowNumber asc", con);
                    SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    sda1.Fill(dt);
                    ViewState["ProductCode2"] = dt;

                    string ff = "select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3, Quantity , ProductCode,ProductUOM from CASCDtl  where CASCId='Casc2' and PermitId='" + txt_code.Text + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "' ORDER BY RowNumber asc";

                    InpaymentClass objprc = new InpaymentClass();
                    objprc.dr = objprc.ret_dr(ff);
                    if (objprc.dr.Read())
                    {
                        TxtProQty2.Text = objprc.dr["Quantity"].ToString();
                        TxtProductCode2.Text = objprc.dr["ProductCode"].ToString();

                        DrpP2.ClearSelection();
                        DrpP2.Items.FindByText(objprc.dr["ProductUOM"].ToString()).Selected = true;
                        //DrpP2.SelectedItem.Text = obj.dr["ProductUOM"].ToString();
                    }



                    if (dt.Rows.Count <= 0)
                    {
                        dt.Rows.Add();
                    }
                    ViewState["ProductCode1"] = dt;
                    ProductCode2Grid1.DataSource = dt;
                    ProductCode2Grid1.DataBind();
                    int rowIndex = 0;
                    if (ViewState["ProductCode2"] != null)
                    {
                        DataTable dt1 = (DataTable)ViewState["ProductCode2"];
                        if (dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt1.Rows.Count; i++)
                            {
                                TextBox box1 = (TextBox)ProductCode2Grid1.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                                TextBox box2 = (TextBox)ProductCode2Grid1.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                                TextBox box3 = (TextBox)ProductCode2Grid1.Rows[rowIndex].Cells[3].FindControl("TextBox3");
                                box1.Text = dt1.Rows[i]["Column1"].ToString();
                                box2.Text = dt1.Rows[i]["Column2"].ToString();
                                box3.Text = dt1.Rows[i]["Column3"].ToString();
                                rowIndex++;
                                //ProductCode2Grid1.DataSource = dt;
                                //ProductCode2Grid1.DataBind();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void editbindProduct3(string ID)
        {
            try
            {
                string strBindTxtBox = "select * from [ItemDtl] where Id=" + ID;
                obj.dr = obj.ret_dr(strBindTxtBox);
                while (obj.dr.Read())
                {
                    SqlConnection con = new SqlConnection(sqlconn);
                    //SqlCommand cmd1 = new SqlCommand("SELECT T1.Id ,T1.CRP,T1.CompanyName,T1.Name,T1.EmailId,T1.Mobile, T2.Name as Rent ,t1.BudgetFrom,T1.BudgetTo ,T3.Name as Type,T4.Name as Location,T5.PropertyRef,T1.MultipleLocation,T1. MultipleProperty  FROM (select a.Id,a.CompanyName,a.Name,a.EmailId,a.Mobile,a.BudgetFrom,a.BudgetTo,b.Name as CRP,a.MultipleLocation,a.MultipleProperty  from lead a,CommonMaster b where a.Per_Com=b.Id and a.TouchUser='" + Touch_user + "') AS T1 JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.RentorBuy=b.Id) AS T2    ON T1.Id = T2.Id    JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Type=b.Id) AS T3  ON T1.Id = T3.Id     JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Location=b.Id) AS T4   ON T1.Id = T4.Id    JOIN ( select b.ID,b.Name,a.PropertyRef  from Lead_List a,Lead b where a.ParentId=b.Id) AS T5   ON T1.Id = T5.Id order by T1.Id desc", con);
                    //SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3 from ItemDtl a,CASCDtl b where a.PermitId=b.PermitId and b.CASCId='Casc3' and a.PermitId='" + txt_code.Text + "'", con);
                    //SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3 from ItemDtl inner join CASCDtl on ItemDtl.ItemNo=CASCDtl.ItemNo where CASCDtl.CASCId='Casc3' and CASCDtl.PermitId='" + txt_code.Text + "'", con);
                    SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3, Quantity , ProductCode from CASCDtl  where CASCId='Casc3' and PermitId='" + txt_code.Text + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "' ORDER BY RowNumber asc", con);
                    SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    sda1.Fill(dt);
                    ViewState["ProductCode3"] = dt;

                    string ff = "select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3, Quantity , ProductCode,ProductUOM from CASCDtl  where CASCId='Casc3' and PermitId='" + txt_code.Text + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "'";

                    InpaymentClass objprc = new InpaymentClass();
                    objprc.dr = objprc.ret_dr(ff);
                    if (objprc.dr.Read())
                    {
                        TxtProQty3.Text = objprc.dr["Quantity"].ToString();
                        TxtProductCode3.Text = objprc.dr["ProductCode"].ToString();

                        DrpP3.ClearSelection();
                        DrpP3.Items.FindByText(objprc.dr["ProductUOM"].ToString()).Selected = true;
                        //DrpP3.SelectedItem.Text = obj.dr["ProductUOM"].ToString();
                    }

                    if (dt.Rows.Count <= 0)
                    {
                        dt.Rows.Add();
                    }
                    ViewState["ProductCode1"] = dt;
                    ProductCode3Grid1.DataSource = dt;
                    ProductCode3Grid1.DataBind();
                    int rowIndex = 0;
                    if (ViewState["ProductCode3"] != null)
                    {
                        DataTable dt1 = (DataTable)ViewState["ProductCode3"];
                        if (dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt1.Rows.Count; i++)
                            {
                                TextBox box1 = (TextBox)ProductCode3Grid1.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                                TextBox box2 = (TextBox)ProductCode3Grid1.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                                TextBox box3 = (TextBox)ProductCode3Grid1.Rows[rowIndex].Cells[3].FindControl("TextBox3");
                                box1.Text = dt1.Rows[i]["Column1"].ToString();
                                box2.Text = dt1.Rows[i]["Column2"].ToString();
                                box3.Text = dt1.Rows[i]["Column3"].ToString();
                                rowIndex++;
                                //ProductCode3Grid1.DataSource = dt;
                                //ProductCode3Grid1.DataBind();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }



        public void InPaymentEdit()
        {
            BtnPrintCIF.Visible = false;
            string DecCompany, Importer, inwardcarrier, ff, climant = "";
            string strBindTxtBox = "";
            if (TempDataPermitNo != "")
            {
                strBindTxtBox = "select * from [InpaymentTemp] where PermitID='" + TempDataPermitNo + "' and TouchUser='" + Session["UserId"].ToString() + "'";
            }
            else
            {
                strBindTxtBox = "select * from [InHeaderTbl] where Id=" + Id;
            }

            obj.dr = obj.ret_dr(strBindTxtBox);
            while (obj.dr.Read())
            {
                premStatuschk = obj.dr["prmtStatus"].ToString();
                refno = obj.dr["Refid"].ToString();
                JobNo = obj.dr["JobId"].ToString();
                MsgNO = obj.dr["MSGId"].ToString();
                txt_code.Text = obj.dr["PermitId"].ToString();
                //TxtTradeMailID.Text = obj.dr["TradeNetMailboxID"].ToString();
                TxtMsgType.Text = obj.dr["MessageType"].ToString();
                //DrpDecType.Text = obj.dr[6].ToString();

                DrpCustomers.ClearSelection();
                DrpCustomers.Items.FindByText(obj.dr["Customers"].ToString()).Selected = true;

                DrpDecType.ClearSelection();
                DrpDecType.Items.FindByText(obj.dr["DeclarationType"].ToString()).Selected = true;
                DrpDecType_SelectedIndexChanged(null, null);
                //DrpDecType.SelectedItem.Text = obj.dr[6].ToString();
                DrpCargoPackType.ClearSelection();
                string cartype = obj.dr[7].ToString();
                DrpCargoPackType.Items.FindByText(obj.dr["CargoPackType"].ToString()).Selected = true;
                //DrpCargoPackType_SelectedIndexChanged(null, null);
                //DrpCargoPackType.SelectedItem.Text = obj.dr[7].ToString();
                DrpInwardtrasMode.ClearSelection();
                DrpInwardtrasMode.Items.FindByText(obj.dr["InwardTransportMode"].ToString()).Selected = true;

                // DrpInwardtrasMode.SelectedItem.Text = obj.dr[8].ToString();
                string sdsdsds = obj.dr["BGIndicator"].ToString();
                DrpBGIndicator.ClearSelection();
                DrpBGIndicator.Items.FindByText(obj.dr["BGIndicator"].ToString()).Selected = true;
                // DrpBGIndicator.SelectedItem.Text = obj.dr[9].ToString();
                string ChkSupplyIndicator1 = obj.dr["SupplyIndicator"].ToString();
                if (ChkSupplyIndicator1 == "true" || ChkSupplyIndicator1 == "True")
                {
                    ChkSupplyIndicator.Checked = true;
                }
                else if (ChkSupplyIndicator1 == "false" || ChkSupplyIndicator1 == "False")
                {
                    ChkSupplyIndicator.Checked = false;
                }
                string ChkRefDoc1 = obj.dr["ReferenceDocuments"].ToString();
                if (ChkRefDoc1 == "true" || ChkRefDoc1 == "True")
                {
                    ChkRefDoc.Checked = true;
                }
                else if (ChkRefDoc1 == "false" || ChkRefDoc1 == "False")
                {
                    ChkRefDoc.Checked = false;
                }

                ChkRefDoc_CheckedChanged(null, null);
                string di = obj.dr["DeclareIndicator"].ToString();
                if (di == "true" || di == "True")
                {
                    chkDeclareInd.Checked = true;
                }
                else if (di == "false" | di == "False")
                {
                    chkDeclareInd.Checked = false;
                }
                string cnb = obj.dr["Cnb"].ToString();
                if (cnb == "true" || cnb == "True")
                {
                    chkcnb.Checked = true;
                }
                else if (cnb == "false" || cnb == "False")
                {
                    chkcnb.Checked = false;
                }

                string Licence = obj.dr["License"].ToString();
                char[] delimiters = { '-' };
                string[] splitLicence = Licence.Split(delimiters); //will split names using minus as delimiter
                TxtLicense1.Text = splitLicence[0].ToString();
                TxtLicense2.Text = splitLicence[1].ToString();
                TxtLicense3.Text = splitLicence[2].ToString();
                TxtLicense4.Text = splitLicence[3].ToString();
                TxtLicense5.Text = splitLicence[4].ToString();
                EditDocument();

                string Receipt = obj.dr["Recipient"].ToString();
                char[] Receipt1 = { '-' };
                string[] Receipt12 = Receipt.Split(Receipt1); //will split names using minus as delimiter
                TxtRECPT1.Text = Receipt12[0].ToString();
                TxtRECPT2.Text = Receipt12[1].ToString();
                TxtRECPT3.Text = Receipt12[2].ToString();


                TextMode.Text = obj.dr["InwardTransportMode"].ToString();
                txthBlCargo.Text = obj.dr["HBL"].ToString();

                lblhblValue.Text = txthBlCargo.Text;


                TxtArrivalDate1.Text = Convert.ToDateTime(obj.dr["ArrivalDate"].ToString()).ToString("dd/MM/yyyy");

                TxtLoadShort.Text = obj.dr["LoadingPortCode"].ToString();


                TxtVoyageno.Text = obj.dr["VoyageNumber"].ToString();
                TxtVesselName.Text = obj.dr["VesselName"].ToString();
                TxtOceanBill.Text = obj.dr["OceanBillofLadingNo"].ToString();
                TxtOceanBill_TextChanged(null, null);


                TxtConRefNo.Text = obj.dr["ConveyanceRefNo"].ToString();
                TxtTrnsID.Text = obj.dr["TransportId"].ToString();
                txtflight.Text = obj.dr["FlightNO"].ToString();
                txtaircraft.Text = obj.dr["AircraftRegNo"].ToString();
                txtwaybill.Text = obj.dr["MasterAirwayBill"].ToString();
                txtwaybill_TextChanged(null, null);
                string fff = obj.dr["InwardTransportMode"].ToString();
                if ((obj.dr["InwardTransportMode"].ToString()) == "1 : Sea")
                {

                    lbloblval.Text = TxtOceanBill.Text;
                }

                else if ((obj.dr["InwardTransportMode"].ToString()) == "4 : Air")
                {
                    lbloblval.Text = txtwaybill.Text;
                }

                txtreLoctn.Text = obj.dr["ReleaseLocation"].ToString();
                txtreLoctn_TextChanged(null, null);
                txtrelocDeta.Text = obj.dr["ReleaseLocName"].ToString();
                txtrecloctn.Text = obj.dr["RecepitLocation"].ToString();
                txtrecloctn_TextChanged(null, null);
                txtrecloctndet.Text = obj.dr["RecepitLocName"].ToString();
                TxttotalOuterPack.Text = obj.dr["TotalOuterPack"].ToString();
                DrptotalOuterPack.ClearSelection();
                string sfd = obj.dr["TotalOuterPackUOM"].ToString();
                DrptotalOuterPack.Items.FindByText(obj.dr["TotalOuterPackUOM"].ToString()).Selected = true;
                // DrptotalOuterPack.SelectedItem.Text = obj.dr[32].ToString();
                if (!string.IsNullOrWhiteSpace(TxttotalOuterPack.Text))
                {
                    lblnoofpack.Text = TxttotalOuterPack.Text + " " + DrptotalOuterPack.SelectedItem.ToString();
                }


                TxtTotalGrossWeight.Text = obj.dr["TotalGrossWeight"].ToString();
                DrpTotalGrossWeight.ClearSelection();
                DrpTotalGrossWeight.Items.FindByText(obj.dr["TotalGrossWeightUOM"].ToString()).Selected = true;
                //DrpTotalGrossWeight.SelectedItem.Text = obj.dr[34].ToString();

                if (!string.IsNullOrWhiteSpace(TxtTotalGrossWeight.Text))
                {
                    lblgrossweight.Text = TxtTotalGrossWeight.Text + " " + DrpTotalGrossWeight.SelectedItem.ToString();
                }
                TxtGrossReference.Text = obj.dr["GrossReference"].ToString();
                txttrdremrk.Text = obj.dr["TradeRemarks"].ToString();
                txtintremrk.Text = obj.dr["InternalRemarks"].ToString();
                txtcusRemrk.Text = obj.dr["CustomerRemarks"].ToString();
                TxtPrevPerNO.Text = obj.dr["PreviousPermit"].ToString();
                BlankDate1.Text = Convert.ToDateTime(obj.dr["BlanketStartDate"].ToString()).ToString("dd/MM/yyyy");

                DecCompany = obj.dr["DeclarantCompanyCode"].ToString();
                Importer = obj.dr["ImporterCompanyCode"].ToString();
                inwardcarrier = obj.dr["InwardCarrierAgentCode"].ToString();
                ff = obj.dr["FreightForwarderCode"].ToString();
                climant = obj.dr["ClaimantPartyCode"].ToString();

                string supp = "select * from [DeclarantCompany] where Code='" + DecCompany + "'";
                obj.dr = obj.ret_dr(supp);
                while (obj.dr.Read())
                {
                    TxtDecCompCode.Text = obj.dr["Code"].ToString();
                    TxtDecCompName.Text = obj.dr["Name"].ToString();
                    TxtDecCompName1.Text = obj.dr["Name1"].ToString();
                    TxtDecCompCRUEI.Text = obj.dr["CRUEI"].ToString();
                }




                string imp = "select * from [Importer] where Code='" + Importer + "'";
                obj.dr = obj.ret_dr(imp);
                while (obj.dr.Read())
                {
                    TxtImpCode.Text = obj.dr["Code"].ToString();
                    TxtImpName.Text = obj.dr["Name"].ToString();
                    TxtImpName1.Text = obj.dr["Name1"].ToString();
                    TxtImpCRUEI.Text = obj.dr["CRUEI"].ToString();
                    lblimporterparty.Text = TxtImpCRUEI.Text + " - " + TxtImpName.Text + " " + obj.dr["Name1"].ToString();



                        TxtImppartyCode.Text = obj.dr["Code"].ToString();
                    TxtImppartyName.Text = obj.dr["Name"].ToString();
                      TxtImppartyName1.Text = obj.dr["Name1"].ToString();
                      TxtImppartyCRUEI.Text = obj.dr["CRUEI"].ToString();


                }




                string invc = "select * from [InwardCarrierAgent] where Code='" + inwardcarrier + "'";
                obj.dr = obj.ret_dr(invc);
                while (obj.dr.Read())
                {
                    InwardCode.Text = obj.dr["Code"].ToString();
                    InwardName.Text = obj.dr["Name"].ToString();
                    InwardName1.Text = obj.dr["Name1"].ToString();
                    InwardCRUEI.Text = obj.dr["CRUEI"].ToString();
                }


                string ff1 = "select * from [FreightForwarder] where Code='" + ff + "'";
                obj.dr = obj.ret_dr(ff1);
                while (obj.dr.Read())
                {
                    FrieghtCode.Text = obj.dr["Code"].ToString();
                    FrieghtName.Text = obj.dr["Name"].ToString();
                    FrieghtName1.Text = obj.dr["Name1"].ToString();
                    FrieghtCRUEI.Text = obj.dr["CRUEI"].ToString();
                }


                string cli = "select * from [ClaimantParty] where Name='" + climant + "'";
                obj.dr = obj.ret_dr(cli);
                while (obj.dr.Read())
                {
                    ClaimantName.Text = obj.dr["Name"].ToString();
                    ClaimantName1.Text = obj.dr["Name1"].ToString();
                    ClaimantName2.Text = obj.dr["Name2"].ToString();
                    ClaimantCRUEI.Text = obj.dr["CRUEI"].ToString();
                    ClaimantNameC.Text = obj.dr["ClaimantName"].ToString();
                    ClaimantName1C.Text = obj.dr["ClaimantName1"].ToString();
                }

                ChkRefDoc_CheckedChanged(null, null);
                TxtLoadShort_TextChanged(null, null);
                DrpDecType_SelectedIndexChanged(null, null);
                DrpCargoPackType_SelectedIndexChanged(null, null);
                DrpInwardtrasMode_SelectedIndexChanged(null, null);
                TxtTotalGrossWeight_TextChanged(null, null);
                DrpTotalGrossWeight_SelectedIndexChanged(null, null);


                editCPCAEO();
                editCPCcwc();
                editcontainer();

                editCPCSEASTORE();
                editCPCIcstore();
                editCPCSchemestore();
                editCPCStsstore();
                editCPCStscwcstore();
                editCPCIcstore();

                TextMode_TextChanged(null, null);
                //SUM OF INVOICE
                string SumInv = "";
                string qry11 = "select Count(InvoiceNo) as InvCount from dbo.InvoiceDtl where PermitId='" + txt_code.Text + "' and MessageType='IPTDEC'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    SumInv = obj.dr[0].ToString();
                    txtnoofinv.Text = SumInv;
                }
                //SUM OF ITEM
                string SumItem = "";
                string qry112 = "select Count(ItemNo) as ItemCount from dbo.ItemDtl where PermitId='" + txt_code.Text + "' and MessageType='IPTDEC'";
                obj.dr = obj.ret_dr(qry112);
                while (obj.dr.Read())
                {
                    SumItem = obj.dr[0].ToString();
                    txtnoofitm.Text = SumItem;
                }

                ///Total Invoice CIF Value
                string InvoiceCIFValue = "";
                string qry112Q = "select sum(CIFSUMAmount) as InvoiceDtl from dbo.InvoiceDtl where PermitId='" + txt_code.Text + "' and MessageType='IPTDEC'";
                obj.dr = obj.ret_dr(qry112Q);
                while (obj.dr.Read())
                {
                    InvoiceCIFValue = obj.dr[0].ToString();
                    txtcifVal.Text = InvoiceCIFValue;
                }

                //Sum of Item Amount

                string SumofItemAmount = "";
                string qry11s2Q = "select SUM(TotalLineAmount) as  TotalLineAmount  from dbo.ItemDtl where PermitId='" + txt_code.Text + "' and MessageType='IPTDEC'";
                obj.dr = obj.ret_dr(qry11s2Q);
                while (obj.dr.Read())
                {
                    SumofItemAmount = obj.dr[0].ToString();
                    txtitmAmt.Text = SumofItemAmount;
                }
                //TotalGSTAmount
                string TotalGSTAmount = "";
                string qry11s2 = "select SUM(GSTAmount) as  GSTAmount  from dbo.ItemDtl where PermitId='" + txt_code.Text + "' and MessageType='IPTDEC'";
                obj.dr = obj.ret_dr(qry11s2);
                while (obj.dr.Read())
                {
                    TotalGSTAmount = obj.dr[0].ToString();
                    txttotgstAmt.Text = TotalGSTAmount;

                    if (DrpDecType.SelectedItem.ToString() == "DUT : Duty")
                    {
                        txtAmtPayble.Text = txttotexAmt.Text;
                        lbltap.Text = txttotexAmt.Text;
                    }
                    else
                    {
                        txtAmtPayble.Text = TotalGSTAmount;
                        lbltap.Text = TotalGSTAmount;
                    }
                    //txtAmtPayble.Text = TotalGSTAmount;
                }
                //Total CIF/FOB Value
                string TotalCIFFOBValue = "";
                string qry11sS2 = "select SUM(CIFFOB) as  GSTAmount  from dbo.ItemDtl where PermitId='" + txt_code.Text + "' and MessageType='IPTDEC'";
                obj.dr = obj.ret_dr(qry11sS2);
                while (obj.dr.Read())
                {
                    TotalCIFFOBValue = obj.dr[0].ToString();
                    txtfobval.Text = TotalCIFFOBValue;

                }

                chkaeo_CheckedChanged(null, null);
                BindInvoice();
                BindItemMaster();
                //edit = true;
                DrpInvoiceNo.DataSource = null;
                string striW = "select * from [InvoiceDtl] where MessageType='IPTDEC' AND PermitId='" + txt_code.Text + "'  order by InvoiceNo";
                obj.dr = obj.ret_dr(striW);
                obj.BindDropDown(DrpInvoiceNo, obj.dr, "Id", "InvoiceNo");
                //DrpInvoiceNo.DataSource = obj.dr;
                //DrpInvoiceNo.DataTextField = "InvoiceNo";
                //DrpInvoiceNo.DataValueField = "Id";
                //DrpInvoiceNo.DataBind();
                //obj.closecon();
                //DrpInvoiceNo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
                txttrdremrk_TextChanged(null, null);
                InvoiceNo();
                ItemNO();
                updatepanel1.Update();
            }

        }


        private void editcontainer()
        {

            SqlConnection con = new SqlConnection(sqlconn);
            //SqlCommand cmd1 = new SqlCommand("SELECT T1.Id ,T1.CRP,T1.CompanyName,T1.Name,T1.EmailId,T1.Mobile, T2.Name as Rent ,t1.BudgetFrom,T1.BudgetTo ,T3.Name as Type,T4.Name as Location,T5.PropertyRef,T1.MultipleLocation,T1. MultipleProperty  FROM (select a.Id,a.CompanyName,a.Name,a.EmailId,a.Mobile,a.BudgetFrom,a.BudgetTo,b.Name as CRP,a.MultipleLocation,a.MultipleProperty  from lead a,CommonMaster b where a.Per_Com=b.Id and a.TouchUser='" + Touch_user + "') AS T1 JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.RentorBuy=b.Id) AS T2    ON T1.Id = T2.Id    JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Type=b.Id) AS T3  ON T1.Id = T3.Id     JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Location=b.Id) AS T4   ON T1.Id = T4.Id    JOIN ( select b.ID,b.Name,a.PropertyRef  from Lead_List a,Lead b where a.ParentId=b.Id) AS T5   ON T1.Id = T5.Id order by T1.Id desc", con);
            SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,ContainerNo as Column1, Size as Column2,Weight as Column3, SealNo as Column4 from InHeaderTbl a,ContainerDtl b where a.PermitId=b.PermitId and a.PermitId='" + txt_code.Text + "' order by RowNo", con);
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                dt.Rows.Add();
            }
            ViewState["Container"] = dt;
            ContarinerGrid.DataSource = ViewState["Container"] as DataTable;
            ContarinerGrid.DataBind();
            int rowIndex = 0;
            if (ViewState["Container"] != null)
            {
                DataTable dt1 = (DataTable)ViewState["Container"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {

                        TextBox box1 = (TextBox)ContarinerGrid.Rows[rowIndex].Cells[1].FindControl("txt1");
                        DropDownList drp1 = (DropDownList)ContarinerGrid.Rows[rowIndex].Cells[1].FindControl("DrpType");
                        TextBox box2 = (TextBox)ContarinerGrid.Rows[rowIndex].Cells[2].FindControl("txt2");
                        TextBox box3 = (TextBox)ContarinerGrid.Rows[rowIndex].Cells[3].FindControl("txt3");
                        box1.Text = dt.Rows[i]["Column1"].ToString();
                        if (!string.IsNullOrWhiteSpace(dt.Rows[i]["Column2"].ToString()))
                        {
                            drp1.ClearSelection();
                            drp1.Items.FindByText(dt.Rows[i]["Column2"].ToString()).Selected = true;
                        }

                        //  drp1.SelectedValue = dt.Rows[i]["Column2"].ToString();
                        box2.Text = dt.Rows[i]["Column3"].ToString();
                        box3.Text = dt.Rows[i]["Column4"].ToString();
                        rowIndex++;

                    }
                }
            }



        }

        private void editCPCAEO()
        {
            string qry = "select RowNo as RowNumber, ProcessingCode1, ProcessingCode2, ProcessingCode3 from InHeaderTbl a, CPCDtl b where a.PermitId = b.PermitId and b.CPCType = 'AEO' and a.PermitId = '" + txt_code.Text + "'";
            SqlConnection con = new SqlConnection(sqlconn);
            SqlCommand cmd1 = new SqlCommand(qry, con);
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            sda1.Fill(dt);

            // Initialize a row with RowNumber = 1 if no data exists
            if (dt.Rows.Count <= 0)
            {
                DataRow newRow = dt.NewRow();
                newRow["RowNumber"] = 1; // Set initial sequence
                newRow["ProcessingCode1"] = string.Empty;
                newRow["ProcessingCode2"] = string.Empty;
                newRow["ProcessingCode3"] = string.Empty;
                dt.Rows.Add(newRow);
            }

            ViewState["CurrentTable"] = dt;
            AEOGrid.DataSource = dt;
            AEOGrid.DataBind();


            string ccc = "";
            obj.dr = obj.ret_dr(qry);
            while (obj.dr.Read())
            {
                ccc = obj.dr["ProcessingCode1"].ToString();
            }
            if (ccc == "")
            {
                chkaeo.Checked = false;
            }
            else
            {
                chkaeo.Checked = true;
            }

           

                // Populate TextBoxes for TemplateFields (if needed)
                int rowIndex = 0;
            DataTable dt1 = (DataTable)ViewState["CurrentTable"];
            if (dt1 != null && dt1.Rows.Count > 0)
            {
                foreach (DataRow row in dt1.Rows)
                {
                    TextBox box1 = (TextBox)AEOGrid.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                  
                    TextBox box2 = (TextBox)AEOGrid.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                    TextBox box3 = (TextBox)AEOGrid.Rows[rowIndex].Cells[3].FindControl("TextBox3");
                    box1.Text = row["ProcessingCode1"].ToString();
                    box2.Text = row["ProcessingCode2"].ToString();
                    box3.Text = row["ProcessingCode3"].ToString();
                    rowIndex++;
                }
            }
        }

        private void editCPCcwc()
        {
            SqlConnection con = new SqlConnection(sqlconn);

            string qry = "select RowNo as RowNumber,ProcessingCode1,ProcessingCode2,ProcessingCode3 from InHeaderTbl a,CPCDtl b where a.PermitId=b.PermitId and b.CPCType='CWC' and a.PermitId='" + txt_code.Text + "'";
            //SqlCommand cmd1 = new SqlCommand("SELECT T1.Id ,T1.CRP,T1.CompanyName,T1.Name,T1.EmailId,T1.Mobile, T2.Name as Rent ,t1.BudgetFrom,T1.BudgetTo ,T3.Name as Type,T4.Name as Location,T5.PropertyRef,T1.MultipleLocation,T1. MultipleProperty  FROM (select a.Id,a.CompanyName,a.Name,a.EmailId,a.Mobile,a.BudgetFrom,a.BudgetTo,b.Name as CRP,a.MultipleLocation,a.MultipleProperty  from lead a,CommonMaster b where a.Per_Com=b.Id and a.TouchUser='" + Touch_user + "') AS T1 JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.RentorBuy=b.Id) AS T2    ON T1.Id = T2.Id    JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Type=b.Id) AS T3  ON T1.Id = T3.Id     JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Location=b.Id) AS T4   ON T1.Id = T4.Id    JOIN ( select b.ID,b.Name,a.PropertyRef  from Lead_List a,Lead b where a.ParentId=b.Id) AS T5   ON T1.Id = T5.Id order by T1.Id desc", con);
            SqlCommand cmd1 = new SqlCommand(qry, con);
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            ViewState["CurrentTable1"] = dt;
            if (dt.Rows.Count <= 0)
            {
                DataRow newRow = dt.NewRow();
                newRow["RowNumber"] = 1; // Set initial sequence
                newRow["ProcessingCode1"] = string.Empty;
                newRow["ProcessingCode2"] = string.Empty;
                newRow["ProcessingCode3"] = string.Empty;
                dt.Rows.Add(newRow);
            }
            CWCGrid.DataSource = ViewState["CurrentTable"] as DataTable;
            CWCGrid.DataBind();

            string ccc = "";
            obj.dr = obj.ret_dr(qry);
            while (obj.dr.Read())
            {
                ccc = obj.dr["ProcessingCode1"].ToString();
            }
            if (ccc == "")
            {
                chkcwc.Checked = false;
            }
            else
            {
                chkcwc.Checked = true;
            }

            int rowIndex = 0;
            if (ViewState["CurrentTable1"] != null)
            {
                DataTable dt1 = (DataTable)ViewState["CurrentTable1"];
                if (dt1.Rows.Count > 0)
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                       

                        TextBox box1 = (TextBox)CWCGrid.Rows[rowIndex].Cells[1].FindControl("TextBox1");                     

                        TextBox box2 = (TextBox)CWCGrid.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                        TextBox box3 = (TextBox)CWCGrid.Rows[rowIndex].Cells[3].FindControl("TextBox3");
                        box1.Text = dt1.Rows[i]["ProcessingCode1"].ToString();
                        box2.Text = dt1.Rows[i]["ProcessingCode2"].ToString();
                        box3.Text = dt1.Rows[i]["ProcessingCode3"].ToString();
                        rowIndex++;
                    }
                }
            }
        }
        private void EditDocument()
        {
            const int maxTotalSizeKB = 20000;
            long totalKB = 0;

            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT Id, DocumentType, Name, FileSizeKB FROM InFile WHERE InPaymentId = @InPaymentId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@InPaymentId", MsgNO);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        // Calculate total size
                        foreach (DataRow row in dt.Rows)
                        {
                            totalKB += Convert.ToInt64(row["FileSizeKB"]);
                        }

                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }

            // Update total size display
            lblTotalSize.Text = $"{totalKB}KB / {maxTotalSizeKB}KB";
            lblTotalSize.ForeColor = totalKB > maxTotalSizeKB ? System.Drawing.Color.Red : System.Drawing.Color.Black;

            // SAFE FOOTER UPDATE: Only update if footer exists
            if (GridView1.Rows.Count > 0)
            {
                int columnIndex = 3; // File size column index
                GridView1.FooterRow.Cells[columnIndex].Text = $"Total: {totalKB}KB";
                GridView1.FooterRow.Cells[columnIndex].ForeColor = totalKB > maxTotalSizeKB ?
                    System.Drawing.Color.Red : System.Drawing.Color.Black;
                GridView1.FooterRow.Cells[columnIndex].Font.Bold = true;
            }


           

        }


        private void RegisterPostBackControl()
        {
            foreach (GridViewRow row in DECCOMPSearGRID.Rows)
            {
                LinkButton lnkFull = row.FindControl("lnkFull") as LinkButton;
                ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkFull);
            }
        }

        protected void FullPostBack(object sender, EventArgs e)
        {
            //string requestor = ((sender as LinkButton).NamingContainer as GridViewRow).Cells[0].Text;

            //string requestType = ((sender as LinkButton).NamingContainer as GridViewRow).Cells[1].Text;
            //string status = ((sender as LinkButton).NamingContainer as GridViewRow).Cells[2].Text;
            //string crueis = ((sender as LinkButton).NamingContainer as GridViewRow).Cells[3].Text;
            //TxtDecCompCode.Text = "";
            //TxtDecCompName.Text = "";
            //TxtDecCompName1.Text = "";
            //TxtDecCompCRUEI.Text = "";
            //TxtDecCompCode.Text = requestor;
            //TxtDecCompName.Text = requestType;
            //TxtDecCompName1.Text = status;
            //TxtDecCompCRUEI.Text = crueis;

        }



        protected void DECCOMPSearGRID_select(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Select")
            {
                //  DECCOMPSearGRID.SelectedIndex = Convert.ToInt16(e.CommandArgument);
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = DECCOMPSearGRID.Rows[rowIndex];
                if (row != null)
                {
                    var lblCode1 = row.FindControl("lblCode") as Label;
                    var lblName1 = row.FindControl("lblName") as Label;
                    var lblName11 = row.FindControl("lblName1") as Label;
                    var cruei1 = row.FindControl("lblCRUEI") as Label;

                    if (lblCode1 != null && lblName1 != null && lblName11 != null && cruei1 != null)
                    {

                        //UpdatePanelDCS.Update();
                        //Get values
                        string requestor = lblCode1.Text;
                        string requestType = lblName1.Text;
                        string status = lblName11.Text;
                        string crueis = cruei1.Text;
                        TxtDecCompCode.Text = "";
                        TxtDecCompName.Text = "";
                        TxtDecCompName1.Text = "";
                        TxtDecCompCRUEI.Text = "";
                        TxtDecCompCode.Text = requestor;
                        TxtDecCompName.Text = requestType;
                        TxtDecCompName1.Text = status;
                        TxtDecCompCRUEI.Text = crueis;
                        //  UpdatePanelDCS.Update();

                    }
                    // DECCOMPSearGRID.Visible = false;

                }
            }
        }
        private void InvoiceClr()
        {
            txtName.Text = "";
            txtcodeinvq.Text = "";
            txtName1.Text = "";
            txtcruei.Text = "";
            //TxtImppartyCode.Text = "";
            //TxtImppartyName.Text = "";

            //TxtImppartyName1.Text = "";
            //TxtImppartyCRUEI.Text = "";

            txtserial.Text = "";
            txtinvNo.Text = "";
            DrpTerms.ClearSelection();
            DrpTerms.Items.FindByText("--Select--").ToString();
            // DrpTerms.SelectedItem.Text = "--Select--";
            //  DrpTerms.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
            // DrpTerms.Items.Clear();
            DrpSupImpRel.ClearSelection();
            DrpSupImpRel.Items.FindByText("--Select--").ToString();
            // DrpSupImpRel.SelectedItem.Text = "--Select--";
            //  DrpSupImpRel.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
            //// DrpSupImpRel.Items.Clear();
            txtcodeinvq.Text = "";
            //  TxtImppartyCode.Text = "";

            Drpcurrency1.ClearSelection();
            Drpcurrency1.Items.FindByText("--Select--").ToString();
            // Drpcurrency1.SelectedItem.Text = "--Select--";
            // Drpcurrency1.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
            // Drpcurrency1.Items.Clear();
            LblTotalInvoice.Text = "0.00";
            TxtTotalInvoice.Text = "0.00";
            SumTotalInvoice.Text = "0.00";
            OtherTaxableChargePer.Text = "0.00";
            Drpcurrency2.ClearSelection();
            Drpcurrency2.Items.FindByText("--Select--").ToString();
            // Drpcurrency2.SelectedItem.Text = "--Select--";
            // Drpcurrency2.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
            //Drpcurrency2.Items.Clear();
            lblOtherTaxableCharge.Text = "0.00";
            TxtOtherTaxableCharge.Text = "0.00";
            SumOtherTaxableCharge.Text = "0.00";
            FrieghtChargesPer.Text = "0.00";
            Drpcurrency3.ClearSelection();
            Drpcurrency3.Items.FindByText("--Select--").ToString();
            //  Drpcurrency3.SelectedItem.Text = "--Select--";
            // Drpcurrency3.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
            // Drpcurrency3.Items.Clear();
            LblFrieghtCharges.Text = "0.00";
            TxtFrieghtCharges.Text = "0.00";
            SumFrieghtCharges.Text = "0.00";
            InsuranceChargesPer.Text = "0.00";
            Drpcurrency4.ClearSelection();
            Drpcurrency4.Items.FindByText("--Select--").ToString();
            //  Drpcurrency4.SelectedItem.Text = "--Select--";
            //  Drpcurrency4.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
            // Drpcurrency4.Items.Clear();
            lblInsuranceCharges.Text = "0.00";
            TxtInsuranceCharges.Text = "0.00";
            SumInsuranceCharges.Text = "0.00";
            FrieghtChargesPer.Text = "0.00";
            DRPCurrency.ClearSelection();
            DRPCurrency.Items.FindByText("--Select--").ToString();
            //  DRPCurrency.SelectedItem.Text = "--Select--";
            // Drpcurrency3.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
            //Drpcurrency3.Items.Clear();
            LblFrieghtCharges.Text = "0.00";
            TxtFrieghtCharges.Text = "0.00";
            SumFrieghtCharges.Text = "0.00";
            InsuranceChargesPer.Text = "0.00";
            txtinvDate1.Text = "";

            // Drpcurrency4.Items.Clear();
            lblInsuranceCharges.Text = "0.00";
            TxtInsuranceCharges.Text = "0.00";
            SumInsuranceCharges.Text = "0.00";
            LblSumOFTotal.Text = "0.00";
            LblGSTpercentage.Text = "9";
            lblGSTAmount.Text = "0.00";
            editInvoice = false;
            InvoiceNo();

        }
        private void Itemclear()
        {
            TxtSerialNo.Text = "";
            //txt_code.Text = "";
            lblhserror.Text = "";
            //  TDQUOM.Items.Clear();
            lblhserror.Visible = false;
            LblHSErr.Visible = false;
            // TDQUOM.SelectedItem.Text = "--Select--";
            TDQUOM.ClearSelection();
            TDQUOM.Items.FindByText("--Select--").Selected = true;

            ddptotDutiableQty.ClearSelection();
            ddptotDutiableQty.Items.FindByText("--Select--").Selected = true;
            //DrpInvoiceNo.SelectedItem.Text = "--Select--";

            DrpInvoiceNo.ClearSelection();
            DrpInvoiceNo.Items.FindByText("--Select--").Selected = true;
            // DrpInvoiceNo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
            //DrpInvoiceNo.Items.Clear();
            // TxtMsgType.Text = "";
            TxtHSCodeItem.Text = "";
            // DRPCurrency.Items.Clear();
            txtlsp.Text = "0.00";
            DRPCurrency.ClearSelection();
            DRPCurrency.Items.FindByText("--Select--").Selected = true;
            // DRPCurrency.SelectedItem.Text = "--Select--";
            TxtDescription.Text = "";
            TxtCountryItem.Text = "";
            TxtBrand.Text = "";
            TxtModel.Text = "";
            txtcname.Text = "";
            DRPCurrency.ClearSelection();
            DRPCurrency.Items.FindByText("--Select--").Selected = true;
            DRPOPQUOM.ClearSelection();
            DRPOPQUOM.Items.FindByText("--Select--").Selected = true;
            //  DRPOPQUOM.SelectedItem.Text = "--Select--";
            // DRPOPQUOM.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
            //  DRPOPQUOM.Items.Clear();
            TxtHAWB.ClearSelection();
            TxtTotalDutiableQuantity.Text = "0.00";
            TxtInvQty.Text = "0.00";
            TxtHSQuantity.Text = "0.00";
            HSQTYUOM.ClearSelection();
            HSQTYUOM.Items.FindByText("--Select--").Selected = true;
            //HSQTYUOM.SelectedItem.Text = "--Select--";
            // HSQTYUOM.Items.Clear();
            TxtUnitPrice.Text = "0.00";
            TxtExchangeRate.Text = "0.00";
            TxtSumExRate.Text = "0.00";
            TxtTotalLineAmount.Text = "0.00";
            Drpcurrency4.ClearSelection();
            Drpcurrency4.Items.FindByText("--Select--").Selected = true;
            // Drpcurrency4.SelectedItem.Text = "--Select--";
            // Drpcurrency4.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
            // Drpcurrency4.Items.Clear();
            TxtTotalLineCharges.Text = "0.00";
            TxtCIFFOB.Text = "0.00";
            TxtOPQty.Text = "0.00";
            TxtIPQty.Text = "0.00";
            Drpcurrency3.ClearSelection();
            Drpcurrency3.Items.FindByText("--Select--").Selected = true;
            //   Drpcurrency3.SelectedItem.Text = "--Select--";
            DRPIPQUOM.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
            //DRPIPQUOM.Items.Clear();
            TxtINPQty.Text = "0.00";
            TxtINPQty.Text = "0.00";
            TxtIMPQty.Text = "0.00";
            ItemGSTRate.Text = "9.00";
            DRPINNPQUOM.ClearSelection();
            DRPINNPQUOM.Items.FindByText("--Select--").Selected = true;
            // DRPINNPQUOM.SelectedItem.Text = "--Select--";
            //DRPINNPQUOM.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
            // DRPINNPQUOM.Items.Clear();
            DRPIMPQUOM.ClearSelection();
            DRPIMPQUOM.Items.FindByText("--Select--").Selected = true;
            //   DRPIMPQUOM.SelectedItem.Text = "--Select--";
            //   DRPIMPQUOM.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
            //DRPIMPQUOM.Items.Clear();
            DrpPreferentialCode.ClearSelection();
            DrpPreferentialCode.Items.FindByText("--Select--").Selected = true;
            //DrpPreferentialCode.SelectedItem.Text = "--Select--";
            // DrpPreferentialCode.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
            //DrpPreferentialCode.Items.Clear();
            ItemGSTUOM.Text = "";
            TxtItemSumGST.Text = "0.00";
            TxtExciseDutyRate.Text = "0.00";
            TxtExciseDutyUOM.Text = "";
            TxtSumExciseDuty.Text = "0.00";
            TxtCustomsDutyRate.Text = "0.00";
            TxtCustomsDutyUOM.Text = "";
            TxtSumCustomsDuty.Text = "0.00";
            DrpOtherUOM.ClearSelection();
            DrpOtherUOM.Items.FindByText("--Select--").Selected = true;

            //   DrpOtherUOM.SelectedItem.Text = "--Select--";
            //DrpOtherUOM.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
            //DrpOtherUOM.Items.Clear();
            DrpMaking.ClearSelection();
            DrpMaking.Items.FindByText("--Select--").Selected = true;
            // DrpMaking.SelectedItem.Text = "--Select--";
            // DrpMaking.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
            // DrpMaking.Items.Clear();

            TxtOtherTaxRate.Text = "0.00";
            TxtSumOtherTaxRate.Text = "0.00";
            TxtCurrentLot.Text = "";
            TxtPreviousLot.Text = "";
            txtShippingMarks1.Text = "";
            txtShippingMarks2.Text = "";
            txtShippingMarks3.Text = "";
            LblHSErr.Visible = false;
            lblhserror.Visible = false;
            txtShippingMarks4.Text = "";
            ItemGSTUOM.Text = "PER";
            ChkBGIndicator.Checked = false;
            ChkUnbrand.Checked = false;
            txtAlcoholPer.Text = "0.00";
            TxtIPQty.Text = "0.00";
            DRPIPQUOM.ClearSelection();
            DRPIPQUOM.Items.FindByText("--Select--").Selected = true;

            txttotDutiableQty.Text = "0.00";
            ddptotDutiableQty.ClearSelection();
            ddptotDutiableQty.Items.FindByText("--Select--").Selected = true;

            DrpVehicleType.ClearSelection();
            DrpVehicleType.Items.FindByText("--Select--").Selected = true;

            DrpOptionalUom.ClearSelection();
            DrpOptionalUom.Items.FindByText("--Select--").Selected = true;

            TextBox4.Text = "";
            TxtOptionalPrice.Text = "0.00";
            TxtOptionalExchageRate.Text = "0.00";
            TxtOptionalSumExRate.Text = "0.00";

            DrpVehicleCapacity.ClearSelection();
            DrpVehicleCapacity.Items.FindByText("--Select--").Selected = true;

            OriginalRegDate.Text = "";






            TxtProductCode1.Text = "";
            TxtProQty1.Text = "0.0000";
            DrpP1.ClearSelection();
            DrpP1.Items.FindByText("--Select--").Selected = true;
            //EndUserDesp1.Text = "";

            TxtProductCode2.Text = "";
            TxtProQty2.Text = "0.0000";
            DrpP2.ClearSelection();
            DrpP2.Items.FindByText("--Select--").Selected = true;
            //EndUserDesp2.Text = "";



            TxtProductCode3.Text = "";
            TxtProQty3.Text = "0.0000";
            DrpP3.ClearSelection();
            DrpP3.Items.FindByText("--Select--").Selected = true;
            //  EndUserDesp3.Text = "";

            TxtProductCode4.Text = "";
            TxtProQty4.Text = "0.0000";
            DrpP1.ClearSelection();
            DrpP4.Items.FindByText("--Select--").Selected = true;
            // EndUserDes4.Text = "";



            TxtProductCode5.Text = "";
            TxtProQty5.Text = "0.0000";
            DrpP1.ClearSelection();
            DrpP5.Items.FindByText("--Select--").Selected = true;
            //EndUserDes5.Text = "";







            ItemNO();
            ProductCode1();
            ProductCode2();
            ProductCode3();
            ProductCode4();
            ProductCode5();

        }
        protected void TxtInHouseItem_TextChanged(object sender, EventArgs e)
        {

            if (TxtInHouseItem.Text != "")
            {

                //   string[] ss = TxtInHouseItem.Text.Split(':');


                string qry11 = "select * from InhouseItemCode where InhouseCode='" + TxtInHouseItem.Text + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    TxtInHouseItem.Text = obj.dr[1].ToString();
                    TxtHSCodeItem.Text = obj.dr[2].ToString();

                    if (chklockitemdesc.Checked == true)
                    {

                    }
                    else
                    {
                        TxtDescription.Text = obj.dr[3].ToString();
                    }

                   


                }

            }
            TxtHSCodeItem.Focus();
        }



        protected void TxtInvQty_TextChanged(object sender, EventArgs e)
        {
            string qry11 = "select UOM from HSCode where HSCode='" + TxtHSCodeItem.Text + "'";
            obj.dr = obj.ret_dr(qry11);
            while (obj.dr.Read())
            {
                string UOm = obj.dr[0].ToString();
                if (UOm == "TEN")
                {
                    //warning b
                    double a;
                    bool isAValid = double.TryParse(TxtInvQty.Text.Trim(), out a);

                    if (isAValid)
                        TxtHSQuantity.Text = (a / 10).ToString("F6");

                }
                else if (UOm == "TPR")
                {
                    double a;
                    bool isAValid = double.TryParse(TxtInvQty.Text.Trim(), out a);

                    if (isAValid)
                        TxtHSQuantity.Text = (a / 10).ToString("F6");

                }

                else if (UOm == "CEN")
                {
                    double a;
                    bool isAValid = double.TryParse(TxtInvQty.Text.Trim(), out a);

                    if (isAValid)
                        TxtHSQuantity.Text = (a / 100).ToString("F6");

                }

                else if (UOm == "MIL")
                {
                    double a;
                    bool isAValid = double.TryParse(TxtInvQty.Text.Trim(), out a);

                    if (isAValid)
                        TxtHSQuantity.Text = (a / 1000).ToString("F6");

                }

                else if (UOm == "TNE")
                {
                    double a;
                    bool isAValid = double.TryParse(TxtInvQty.Text.Trim(), out a);

                    if (isAValid)
                        TxtHSQuantity.Text = (a / 1000).ToString("F6");

                }


                else if (UOm == "MTK")
                {
                    double a;
                    bool isAValid = double.TryParse(TxtInvQty.Text.Trim(), out a);

                    if (isAValid)
                        TxtHSQuantity.Text = (a * 3.213).ToString("F6");

                }
                else if (UOm == "LTR")
                {
                    double a;
                    bool isAValid = double.TryParse(TxtInvQty.Text.Trim(), out a);

                    if (isAValid)
                        TxtHSQuantity.Text = (a * 1.25).ToString("F6");
                }
                else if (UOm == "KGM")
                {
                    TxtHSQuantity.Text = TxtInvQty.Text;
                }
                else if (UOm == "NMB" || UOm == "-")
                {
                    //  string tt;
                    // string [] tokens;
                    double a;
                    bool ss;
                    bool isAValid = double.TryParse(TxtInvQty.Text.Trim(), out a);
                    // 0
                    if (isAValid)

                        //  tt  = TxtInvQty.Text;
                        if (ss = TxtInvQty.Text.Contains("."))
                        {
                            lblinvqty.Visible = true;
                            lblinvqty.Text = "Invalid";
                        }
                        else
                        {
                            lblinvqty.Visible = false;
                            TxtHSQuantity.Text = TxtInvQty.Text;
                        }
                }
            }

            TxtHSQuantity.Focus();
        }

        protected void TxtOptionalPrice_TextChanged(object sender, EventArgs e)
        {
            if (TxtUnitPrice.Text != "")
            {

                double T1, T2, T3;
                bool A = double.TryParse(TxtOptionalPrice.Text.Trim(), out T1);
                bool B = double.TryParse(TxtOptionalExchageRate.Text.Trim(), out T2);
                bool C = double.TryParse(TxtOptionalSumExRate.Text.Trim(), out T3);

                if (A && B)
                    TxtOptionalSumExRate.Text = (T1 * T2).ToString();
            }
            //    TxtTotalLineAmount.Text = (T5 * T1).ToString();
            //    string lineamt = (T5 * T1).ToString();

            //    TxtTotalLineCharges.Text = (Convert.ToDouble(lineamt) * T2 / 100).ToString();
            //    string linecharge = (Convert.ToDouble(lineamt) * T2 / 100).ToString();
            //    TxtCIFFOB.Text = ((Convert.ToDouble(lineamt) * T2 + Convert.ToDouble(linecharge)).ToString());
            //    string GSTG = TxtCIFFOB.Text;
            //    TxtItemSumGST.Text = ((Convert.ToDouble(GSTG) * 7 / 100).ToString());
            //}
            //else
            //{
            //    TxtUnitPrice.Text = "0.00";
            //}
            ////Sum of Item Amount

            //string SumofItemAmount = "";
            //string qry11s2Q = "select SUM(TotalLineAmount) as  TotalLineAmount  from dbo.ItemDtl where PermitId='" + txt_code.Text + "' and MessageType='IPTDEC'";
            //obj.dr = obj.ret_dr(qry11s2Q);
            //while (obj.dr.Read())
            //{
            //    SumofItemAmount = obj.dr[0].ToString();
            //    txtitmAmt.Text = SumofItemAmount;
            //}
            ////TotalGSTAmount
            //string TotalGSTAmount = "";
            //string qry11s2 = "select SUM(GSTAmount) as  GSTAmount  from dbo.ItemDtl where PermitId='" + txt_code.Text + "' and MessageType='IPTDEC'";
            //obj.dr = obj.ret_dr(qry11s2);
            //while (obj.dr.Read())
            //{
            //    TotalGSTAmount = obj.dr[0].ToString();
            //    txttotgstAmt.Text = TotalGSTAmount;
            //    txtAmtPayble.Text = TotalGSTAmount;
            //}
        }

        protected void DrpOptionalUom_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Code, Code1 = "";
            string qry11 = "select TICurrency from [InvoiceDtl] where MessageType='IPTDEC' AND PermitId='" + txt_code.Text + "' and InvoiceNo='" + DrpInvoiceNo.SelectedItem.ToString().Replace("'", "''") + "'  order by TICurrency";
            obj.dr = obj.ret_dr(qry11);
            while (obj.dr.Read())
            {
                Code = obj.dr[0].ToString();
                if (Code != "--Select--")
                {
                    DrpOptionalUom.ClearSelection();
                    DrpOptionalUom.Items.FindByText(Code).Selected = true;


                    string qry111 = "select CurrencyRate from dbo.Currency where Currency='" + Code + "'";
                    obj.dr = obj.ret_dr(qry111);
                    while (obj.dr.Read())
                    {
                        Code1 = obj.dr[0].ToString();
                        TxtOptionalExchageRate.Text = Code1;
                    }

                }


            }
            TxtTotalLineAmount.Focus();

        }

        protected void GridCancelDoc_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridCancelDoc.DataKeys[e.RowIndex].Value.ToString();

            string strDelete = "delete from InCancelFile where Id='" + id + "' ";
            obj.exec(strDelete);
            obj.closecon();
            BindGridCancel();
        }

        protected void GridCancelDoc_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridCancelDoc.PageIndex = e.NewPageIndex;

            BindGridCancel();
        }

        protected void CancelDocDelete_Click(object sender, EventArgs e)
        {
            LinkButton lnkbtn = sender as LinkButton;
            //getting particular row linkbutton
            GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
            //getting userid of particular row
            int employeeId = Convert.ToInt32(GridCancelDoc.DataKeys[gvrow.RowIndex].Value.ToString());
            int result;
            //getting Connectin String from Web.Config
            string conString = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM InCancelFile where ID=" + employeeId, con);
                result = cmd.ExecuteNonQuery();
                con.Close();
            }
            if (result == 1)
            {
                BindGridCancel();
            }
        }

        protected void BtnCancelUp_Click(object sender, EventArgs e)
        {
            int i = 1;
            foreach (HttpPostedFile postedFile in FileUpload2.PostedFiles)
            {
                string filename = Path.GetFileName(postedFile.FileName);
                string contentType = postedFile.ContentType;
                using (Stream fs = postedFile.InputStream)
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            string Touch_user = Session["UserId"].ToString();
                            string Code = txt_code.Text;
                            string DocType = DrpDocumenttype.SelectedItem.ToString();
                            string strTime = System.DateTime.Now.ToString("yyyy/MM/dd");
                            string query = "insert into InCancelFile values (@SNo,@Name, @ContentType, @Data,@DocumentType,@InPaymentId,@TouchUser,@TouchTime)";
                            using (SqlCommand cmd = new SqlCommand(query))
                            {

                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@SNo", i);
                                cmd.Parameters.AddWithValue("@Name", filename);
                                cmd.Parameters.AddWithValue("@ContentType", contentType);
                                cmd.Parameters.AddWithValue("@Data", bytes);
                                cmd.Parameters.AddWithValue("@DocumentType", DocType);
                                cmd.Parameters.AddWithValue("@InPaymentId", Code);
                                cmd.Parameters.AddWithValue("@TouchUser", Touch_user);
                                cmd.Parameters.AddWithValue("@TouchTime", strTime);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                                BindGridCancel();
                            }
                        }
                    }
                }
                i++;
            }
        }

        protected void GridRefundDoc_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridRefundDoc.DataKeys[e.RowIndex].Value.ToString();

            string strDelete = "delete from InFile where Id='" + id + "' ";
            obj.exec(strDelete);
            obj.closecon();
            BindGridRefund();
        }

        protected void BtnRefundUp_Click(object sender, EventArgs e)
        {
            int i = 1;

            foreach (HttpPostedFile postedFile in FileUpload3.PostedFiles)
            {
                string filename = Path.GetFileName(postedFile.FileName);
                string contentType = postedFile.ContentType;
                using (Stream fs = postedFile.InputStream)
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            string Touch_user = Session["UserId"].ToString();
                            string Code = txt_code.Text;
                            string DocType = DrprefundDocType.SelectedItem.ToString();
                            string strTime = System.DateTime.Now.ToString("yyyy/MM/dd");
                            string query = "insert into InRefundFile values (@Sno,@Name, @ContentType, @Data,@DocumentType,@InPaymentId,@TouchUser,@TouchTime)";
                            using (SqlCommand cmd = new SqlCommand(query))
                            {

                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@Sno", i);
                                cmd.Parameters.AddWithValue("@Name", filename);
                                cmd.Parameters.AddWithValue("@ContentType", contentType);
                                cmd.Parameters.AddWithValue("@Data", bytes);
                                cmd.Parameters.AddWithValue("@DocumentType", DocType);
                                cmd.Parameters.AddWithValue("@InPaymentId", Code);
                                cmd.Parameters.AddWithValue("@TouchUser", Touch_user);
                                cmd.Parameters.AddWithValue("@TouchTime", strTime);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                                BindGridRefund();
                            }
                        }
                    }
                }
            }
            i++;
        }


        protected void GridRefundDoc_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridRefundDoc.PageIndex = e.NewPageIndex;

            BindGridRefund();
        }

        protected void RefundDocDelete_Click(object sender, EventArgs e)
        {
            LinkButton lnkbtn = sender as LinkButton;
            //getting particular row linkbutton
            GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
            //getting userid of particular row
            int employeeId = Convert.ToInt32(GridRefundDoc.DataKeys[gvrow.RowIndex].Value.ToString());
            int result;
            //getting Connectin String from Web.Config
            string conString = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM InRefundFile where ID=" + employeeId, con);
                result = cmd.ExecuteNonQuery();
                con.Close();
            }
            if (result == 1)
            {
                BindGridRefund();
            }
        }

        protected void TxtArrivalDate1_TextChanged(object sender, EventArgs e)
        {
            TxtArrivalDate1.Text = DateCheck(TxtArrivalDate1.Text);

            DateTime arrivalDate = Convert.ToDateTime(TxtArrivalDate1.Text);

            if (arrivalDate.Date < DateTime.Today)
            {           
                alertarrival.Visible = true;
                alertarrival.Text = "Arrival date is in the past. Please check.";
            }
            else
            {
                alertarrival.Visible = false;
                alertarrival.Text = "";

            }



                // TxttotalOuterPack.Text = "0";
                // TxttotalOuterPack_TextChanged(null, null);

                txtreLoctn.Focus();
        }

        protected void txtinvDate1_TextChanged(object sender, EventArgs e)
        {
            txtinvDate1.Text = DateCheck(txtinvDate1.Text);
        }
        public string DateCheck(string Dateval)
        {
            string curdate = "";
            if (Dateval.Length == 10)
            {
                curdate = Dateval;
            }
            else if (Dateval.Length == 8)
            {
                string date = Dateval.Substring(0, 2);
                string month = Dateval.Substring(2, 2);
                string year = Dateval.Substring(4, 4);
                if (Convert.ToInt16(year) >= 2015 && Convert.ToInt16(year) <= 2070)
                {

                }
                else
                {
                    year = System.DateTime.Now.ToString("yyyy");
                }
                if (Convert.ToInt16(month) >= 1 && Convert.ToInt16(month) <= 12)
                {
                    if (month == "01" || month == "03" || month == "05" || month == "07" || month == "08" || month == "10" || month == "12")
                    {
                        if (Convert.ToInt16(date) >= 1 && Convert.ToInt16(date) <= 31)
                        {
                            curdate = date + "/" + month + "/" + year;
                        }
                        else
                        {
                            curdate = DateTime.Now.ToString("dd/MM/yyyy");
                        }
                    }
                    else if (month == "04" || month == "06" || month == "09" || month == "11")
                    {
                        if (Convert.ToInt16(date) >= 1 && Convert.ToInt16(date) <= 30)
                        {
                            curdate = date + "/" + month + "/" + year;
                        }
                        else
                        {
                            curdate = DateTime.Now.ToString("dd/MM/yyyy");
                        }
                    }
                    else if (month == "02")
                    {
                        if (Convert.ToInt16(date) >= 1 && Convert.ToInt16(date) <= 29)
                        {
                            curdate = date + "/" + month + "/" + year;
                        }
                        else
                        {
                            curdate = DateTime.Now.ToString("dd/MM/yyyy");
                        }
                    }
                }
                else
                {
                    curdate = DateTime.Now.ToString("dd/MM/yyyy");
                }
            }
            else
            {
                curdate = DateTime.Now.ToString("dd/MM/yyyy");
            }

            return curdate;
        }

        protected void DrpCargoPackType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string TransMode = DrpCargoPackType.SelectedItem.ToString();
            if (DrpCargoPackType.SelectedItem.ToString() != "--Select--")
            {

                if (TransMode == "9: Containerized")
                {
                    gvAddrow.Visible = true;
                }
                else
                {
                    gvAddrow.Visible = false;
                }
            }
            else
            {
                gvAddrow.Visible = false;
            }
            if (DrpInwardtrasMode.Visible == true)
            {
                DrpInwardtrasMode.Focus();
            }
            else
            {
                DrpInwardtrasMode.Focus();
            }
            //ReqValidatePageLoad();
            DrpInwardtrasMode_SelectedIndexChanged(null, null);
            DrpInwardtrasMode.Focus();
            upinheader.Update();
            upincargo.Update();
            // updatepanel1.Update();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TxtProQty1.Text = TxtHSQuantity.Text;
            //  DrpP1.Text = HSQTYUOM.SelectedItem.ToString();
        }

        protected void TxtHAWB_TextChanged(object sender, EventArgs e)
        {
            if (TxtHAWB.Text != "")
            {
                if (string.IsNullOrWhiteSpace(FrieghtCode.Text))
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Please Check Freight Forwarded')</script>");
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(FrieghtCode.Text))
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Please Check Freight Forwarded')</script>");
                }
            }
        }
        private void Frightforwardcheck()
        {
            if (TxtHAWB.Text != "")
            {
                if (string.IsNullOrWhiteSpace(FrieghtCode.Text))
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Please Check Freight Forwarded')</script>");
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(FrieghtCode.Text))
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Please Check Freight Forwarded')</script>");
                }
            }
        }

        protected void TxtHSQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        protected void HSQTYUOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DrpTotalGrossWeight.SelectedItem.ToString() != "--select--")
            {
                if (DrpTotalGrossWeight.SelectedItem.ToString() == HSQTYUOM.SelectedItem.ToString())
                {
                    if (DrpTotalGrossWeight.SelectedItem.ToString() == "TNE" || DrpTotalGrossWeight.SelectedItem.ToString() == "KGM")
                    {
                        if (Convert.ToDecimal(TxtHSQuantity.Text) > Convert.ToDecimal(TxtTotalGrossWeight.Text))
                        {
                            LblHSErr.Text = "Please Check Net Weight & Gross Weight";
                            upinitem.Update();
                            // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Please Check Net Weight & Gross Weight", true);
                            // Response.Write("<script LANGUAGE='JavaScript' >alert('Please Check Net Weight & Gross Weight')</script>");
                        }
                    }
                }
            }

            if (HSQTYUOM.SelectedItem.Text == "LTR")
            {
                txtAlcoholPer.Focus();
            }
            else
            {
                DrpInvoiceNo.Focus();
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            InpaymentClass curobj = new InpaymentClass();
            curobj.dr = curobj.ret_dr("select Distinct TICurrency,TIExRate from InvoiceDtl where  MessageType='IPTDEC' AND PermitId='" + txt_code.Text + "'");
            while (curobj.dr.Read())
            {
                txttrdremrk.Text = txttrdremrk.Text + "EXCHANGE RATE:  " + curobj.dr["TICurrency"].ToString() + " : " + curobj.dr["TIExRate"].ToString() + Environment.NewLine;
            }
            //string ss = Drpcurrency1.SelectedItem.Text + " : " + LblTotalInvoice.Text;

            //txttrdremrk.Text = ss;


        }

        protected void btninvnum_Click(object sender, EventArgs e)
        {
            string sent = "Invoice Number :";

            txttrdremrk.Text = txttrdremrk.Text = Environment.NewLine + sent + Environment.NewLine;


        }

        protected void chkAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAuto.Checked == true)
            {
                txtfobval.Enabled = false;
            }
            else
            {
                txtfobval.Enabled = true;
            }
        }

        protected void btntest_Click(object sender, EventArgs e)
        {
            BindProduct1();
        }

        protected void BlankDate1_TextChanged(object sender, EventArgs e)
        {
            BlankDate1.Text = DateCheck(BlankDate1.Text);
            TxttotalOuterPack.Text = "0";
            TxttotalOuterPack_TextChanged(null, null);
            TxttotalOuterPack.Focus();
            
        }

        protected void txtinvDate1_TextChanged1(object sender, EventArgs e)
        {
            txtinvDate1.Text = DateCheck(txtinvDate1.Text);
            DrpTerms.Focus();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            //InvoiceGrid.Visible = true;
            //InvoiceDiv.Visible = false;
            //NewInvoice.Visible = true;
        }
        private void SummaryCalculate()
        {
            AddDynamicLabels();
            AddDynamicItem();
            //SUM OF INVOICE
            string SumInv = "";
            string qry11 = "select Count(InvoiceNo) as InvCount from dbo.InvoiceDtl where PermitId='" + txt_code.Text + "' and MessageType='IPTDEC'";
            obj.dr = obj.ret_dr(qry11);
            while (obj.dr.Read())
            {
                SumInv = obj.dr[0].ToString();
                txtnoofinv.Text = SumInv;
            }
            //SUM OF ITEM
            string SumItem = "";
            string qry112 = "select Count(ItemNo) as ItemCount from dbo.ItemDtl where PermitId='" + txt_code.Text + "' and MessageType='IPTDEC'";
            obj.dr = obj.ret_dr(qry112);
            while (obj.dr.Read())
            {
                SumItem = obj.dr[0].ToString();
                txtnoofitm.Text = SumItem;
            }

            ///Total Invoice CIF Value
            string InvoiceCIFValue = "";
            string qry112Q = "select sum(CIFSUMAmount) as InvoiceDtl from dbo.InvoiceDtl where PermitId='" + txt_code.Text + "' and MessageType='IPTDEC'";
            obj.dr = obj.ret_dr(qry112Q);
            while (obj.dr.Read())
            {
                InvoiceCIFValue = obj.dr[0].ToString();
                txtcifVal.Text = InvoiceCIFValue;
            }

            //Sum of Item Amount

            string SumofItemAmount = "";
            string qry11s2Q = "select SUM(TotalLineAmount) as  TotalLineAmount  from dbo.ItemDtl where PermitId='" + txt_code.Text + "' and MessageType='IPTDEC'";
            obj.dr = obj.ret_dr(qry11s2Q);
            while (obj.dr.Read())
            {
                SumofItemAmount = obj.dr[0].ToString();
                txtitmAmt.Text = SumofItemAmount;
            }
            //TotalGSTAmount
            string TotalGSTAmount = "";
            string qry11s2 = "select SUM(GSTAmount) as  GSTAmount  from dbo.ItemDtl where PermitId='" + txt_code.Text + "' and MessageType='IPTDEC'";
            obj.dr = obj.ret_dr(qry11s2);
            while (obj.dr.Read())
            {
                TotalGSTAmount = obj.dr[0].ToString();
                txttotgstAmt.Text = TotalGSTAmount;

                //if (DrpDecType.SelectedItem.ToString() == "DUT : Duty")
                //{
                //    txtAmtPayble.Text = txttotexAmt.Text;
                //}
                //else
                //{
                txtAmtPayble.Text = TotalGSTAmount;
                lbltap.Text = TotalGSTAmount;
                //}
                //txtAmtPayble.Text = TotalGSTAmount;
            }
            lblTotItemGst.Text = txttotgstAmt.Text;


            //TotalitemGSTAmount
            string TotalitemGSTAmount = "";
            string qry11s2e = "select sum(GSTSUMAmount) as InvoiceGST  from dbo.InvoiceDtl where PermitId='" + txt_code.Text + "' and MessageType='IPTDEC'";
            obj.dr = obj.ret_dr(qry11s2e);
            while (obj.dr.Read())
            {
                TotalitemGSTAmount = obj.dr[0].ToString();
                lblTotINVGst.Text = obj.dr[0].ToString();

            }
            
            if(TotalitemGSTAmount=="")
            {
                lblTotINVGst.Text = "0.00";
            }



            //Total CIF/FOB Value
            string TotalCIFFOBValue = "";
            string qry11sS2 = "select SUM(CIFFOB) as  GSTAmount  from dbo.ItemDtl where PermitId='" + txt_code.Text + "' and MessageType='IPTDEC'";
            obj.dr = obj.ret_dr(qry11sS2);
            while (obj.dr.Read())
            {
                TotalCIFFOBValue = obj.dr[0].ToString();
                txtfobval.Text = TotalCIFFOBValue;

            }


            string TotalGSTAmount1 = "", totalexamt = "", cusamt = "", othertaxamt = "";
            string qry11s233 = "select SUM(GSTAmount) as  GSTAmount  from dbo.ItemDtl where PermitId='" + txt_code.Text + "' and MessageType='IPTDEC'";
            obj.dr = obj.ret_dr(qry11s233);
            while (obj.dr.Read())
            {
                TotalGSTAmount1 = obj.dr[0].ToString();
                txttotgstAmt.Text = TotalGSTAmount1;

                // txtAmtPayble.Text = TotalGSTAmount;
            }

            string qry11s21 = "select SUM(ExciseDutyAmount) as  GSTAmount  from dbo.ItemDtl where PermitId='" + txt_code.Text + "' and MessageType='IPTDEC'";
            obj.dr = obj.ret_dr(qry11s21);
            while (obj.dr.Read())
            {
                totalexamt = obj.dr[0].ToString();
                txttotexAmt.Text = totalexamt;
                // txtAmtPayble.Text = TotalGSTAmount;
            }
            string qry11s22 = "select SUM(CustomsDutyAmount) as  GSTAmount  from dbo.ItemDtl where PermitId='" + txt_code.Text + "' and MessageType='IPTDEC'";
            obj.dr = obj.ret_dr(qry11s22);
            while (obj.dr.Read())
            {
                cusamt = obj.dr[0].ToString();
                txtcusdutyAmt.Text = cusamt;
                // txtAmtPayble.Text = TotalGSTAmount;
            }


            string qry11s23 = "select SUM(OtherTaxAmount) as  GSTAmount  from dbo.ItemDtl where PermitId='" + txt_code.Text + "' and MessageType='IPTDEC'";
            obj.dr = obj.ret_dr(qry11s23);
            while (obj.dr.Read())
            {
                othertaxamt = obj.dr[0].ToString();
                txtothtaxAmt.Text = othertaxamt;
                // txtAmtPayble.Text = TotalGSTAmount;
            }


            double T11, T22, T33, T44;
            bool AA = double.TryParse(txttotgstAmt.Text.Trim(), out T11);
            bool BB = double.TryParse(txttotexAmt.Text.Trim(), out T22);
            bool CC = double.TryParse(txtcusdutyAmt.Text.Trim(), out T33);
            bool DD = double.TryParse(txtothtaxAmt.Text.Trim(), out T44);

            if (AA && BB && CC)
            {
                //if (DrpDecType.SelectedItem.ToString() == "DUT : Duty")
                //{
                //    txtAmtPayble.Text = txttotexAmt.Text;
                //}
                //else
                //{
                if (DrpDecType.SelectedItem.ToString() == "DNG : Duty & GST")
                {
                    txtAmtPayble.Text = (T11 + T22 + T33 + T44).ToString();

                    lbltap.Text = (T11 + T22 + T33 + T44).ToString();
                }
                else
                {
                    txtAmtPayble.Text = (T22 + T33 + T44).ToString();
                    lbltap.Text = (T22 + T33 + T44).ToString();
                }
                //}
            }
            if (DrpDecType.SelectedItem.ToString() == "GST : GST (Including Duty Exemption)")
            {
                if (!string.IsNullOrWhiteSpace(txttotgstAmt.Text))
                {
                    lbltap.Text = txttotgstAmt.Text;
                    txtAmtPayble.Text = txttotgstAmt.Text;
                }
            }
            else if (DrpDecType.SelectedItem.ToString() == "BKT : Blanket ")
            {
                if (!string.IsNullOrWhiteSpace(txttotgstAmt.Text))
                {
                    lbltap.Text = txttotgstAmt.Text;
                    txtAmtPayble.Text = txttotgstAmt.Text;
                }
            }
        }

        protected void DECCOMPSearGRID_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //foreach (GridViewRow row in DECCOMPSearGRID.Rows)
            //{
            //    if (row.RowIndex == DECCOMPSearGRID.SelectedIndex)
            //    {
            //        row.ToolTip = string.Empty;
            //        String doctype, name, name1, cruei;
            //        doctype = row.Cells[0].Text;
            //        name = row.Cells[1].Text;
            //        name1 = row.Cells[2].Text;
            //        cruei = row.Cells[3].Text;
            //        TxtDecCompCode.Text = doctype;
            //        TxtDecCompName.Text = name;
            //        TxtDecCompName1.Text = name1;
            //        TxtDecCompCRUEI.Text = cruei;


            //    }
            //}

            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    //Attach click event to each row in Gridview
            //    //Response.Redirect("Home.aspx");
            //    e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.DECCOMPSearGRID, "Select$" + e.Row.RowIndex);
            //}

        }

        protected void DECCOMPSearGRID_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(DECCOMPSearGRID, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
            // e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.DECCOMPSearGRID, "Select$" + e.Row.RowIndex);

        }


        protected void DECCOMPSearGRID_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in DECCOMPSearGRID.Rows)
            {
                //if (row.RowIndex == DECCOMPSearGRID.SelectedIndex)
                //{
                //row.ToolTip = string.Empty;
                //String doctype, name, name1, cruei;
                //doctype = row.Cells[0].Text;
                //name = row.Cells[1].Text;
                //name1 = row.Cells[2].Text;
                //cruei = row.Cells[3].Text;
                //TxtDecCompCode.Text = doctype;
                //TxtDecCompName.Text = name;
                //TxtDecCompName1.Text = name1;
                //TxtDecCompCRUEI.Text = cruei;


                //}
            }
            updatepanel1.Update();
            UpdatePanel2.Update();
            updatepanel3.Update();
            upinparty.Update();

            TxtImpCode.Focus();

        }

        protected void ChkPackInfo_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkPackInfo.Checked == true)
            {
                //PackingInfo.Visible = true;
                TxtOPQty.Focus();
            }
            else
            {
                //PackingInfo.Visible = false;
                Chkitemcasc.Focus();
            }

        }

        protected void Chkitemcasc_CheckedChanged(object sender, EventArgs e)
        {
            if (Chkitemcasc.Checked == true)
            {
                //ItemCASC.Visible = true;
                TxtProductCode1.Focus();
            }
            else
            {
                ChkTariff.Focus();
                //ItemCASC.Visible = false;
            }
        }

        protected void ChkTariff_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkTariff.Checked == true)
            {
                //Tariff.Visible = true;
                DrpPreferentialCode.Focus();
            }
            else
            {
                //Tariff.Visible = false;
                Chklot.Focus();
            }
        }

        protected void Chklot_CheckedChanged(object sender, EventArgs e)
        {
            if (Chklot.Checked == true)
            {
                //LOTID.Visible = true;
                TxtCurrentLot.Focus();
            }
            else
            {
                //LOTID.Visible = false;

            }
        }

        protected void txthBlCargo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txthBlCargo.Text))
            {
                TxtHAWB.Items.Clear();
                string[] hblvalue = txthBlCargo.Text.Split(',');
                for (int i = 0; i < hblvalue.Length; i++)
                {
                    TxtHAWB.Items.Add(hblvalue[i].ToString());
                }
                lblhblValue.Text = txthBlCargo.Text;
            }
            else
            {
                TxtHAWB.Items.Clear();
            }
            upinitem.Update();
            updatepanel1.Update();
            upinsummary.Update();
            TxtArrivalDate1.Focus();
        }

        protected void TxtOceanBill_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxtOceanBill.Text))
            {
                lbloblval.Text = TxtOceanBill.Text;
            }
            updatepanel1.Update();
            upinsummary.Update();
            txthBlCargo.Focus();
        }

        protected void TxttotalOuterPack_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxttotalOuterPack.Text))
            {
                lblnoofpack.Text = TxttotalOuterPack.Text + " " + DrptotalOuterPack.SelectedItem.ToString();
            }
            updatepanel1.Update();
            upinsummary.Update();
            DrptotalOuterPack.Focus();

        }

        protected void DrptotalOuterPack_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblnoofpack.Text = TxttotalOuterPack.Text + " " + DrptotalOuterPack.SelectedItem.ToString();
            updatepanel1.Update();
            upinsummary.Update();
            TxtTotalGrossWeight.Focus();

        }

        protected void TxtTotalGrossWeight_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxtTotalGrossWeight.Text))
            {
                lblgrossweight.Text = TxtTotalGrossWeight.Text + " " + DrpTotalGrossWeight.SelectedItem.ToString();

                if (DrpTotalGrossWeight.SelectedItem.ToString() == "KGM")
                {
                    txtTtlPGW.Text = TxtTotalGrossWeight.Text;

                    DrpTtlPGW.ClearSelection();
                    DrpTtlPGW.Items.FindByText("KGM").Selected = true;


                    lblttlpermitgw.Text = txtTtlPGW.Text + "  " + "KGM"; 

                }
                else
                {
                    decimal TtlPGW = Convert.ToDecimal(TxtTotalGrossWeight.Text) / Convert.ToDecimal(1000);
                    txtTtlPGW.Text = Convert.ToString(Math.Round(TtlPGW, 3));
                    DrpTtlPGW.ClearSelection();
                    DrpTtlPGW.Items.FindByText("TNE").Selected = true;

                    lblttlpermitgw.Text = txtTtlPGW.Text + "  " + "TNE";

                }

            }


            updatepanel1.Update();
            upinsummary.Update();
            DrpTotalGrossWeight.Focus();
        }

        protected void DrpTotalGrossWeight_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblgrossweight.Text = TxtTotalGrossWeight.Text + " " + DrpTotalGrossWeight.SelectedItem.ToString();

            if(DrpTotalGrossWeight.SelectedItem.ToString()== "KGM")
            {
                txtTtlPGW.Text = TxtTotalGrossWeight.Text;
               
                DrpTtlPGW.ClearSelection();
                DrpTtlPGW.Items.FindByText("KGM").Selected = true;

                lblttlpermitgw.Text = txtTtlPGW.Text + "  " + "KGM";

            }
            else
            {
                decimal TtlPGW = Convert.ToDecimal(TxtTotalGrossWeight.Text) / Convert.ToDecimal(1000);
                txtTtlPGW.Text = Convert.ToString(Math.Round( TtlPGW, 2));
                DrpTtlPGW.ClearSelection();
                DrpTtlPGW.Items.FindByText("TNE").Selected = true;
                lblttlpermitgw.Text = txtTtlPGW.Text + "  " + "TNE";
            }



            updatepanel1.Update();
            upinsummary.Update();




            if (TextMode.Text.ToUpper() == "1 : SEA")
            {
                TxtVoyageno.Focus();
            }

            else if (TextMode.Text.ToUpper() == "4 : AIR")
            {
                txtflight.Focus();
            }
            else if (TextMode.Text.ToString() == "2 : RAIL" || TextMode.Text.ToString() == "3 : ROAD" || TextMode.Text.ToString() == "5 : MAIL" || TextMode.Text.ToString() == "6 : MULTI-MODEL(NOT IN USE)" || TextMode.Text.ToString() == "7 : PIPELINE")
            {
                TxtConRefNo.Focus();
            }
            else
            {
                btnprevcargo.Focus();
            }




        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( 'WebForm1.aspx?Id=" + "DEC" + "', null, 'height=700,width=760,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
        }
        private void BindTextBoxvalues()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select * from DeclarantCompany where Code=" + code, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            TxtDecCompCode.Text = dt.Rows[0][0].ToString();
            TxtDecCompCRUEI.Text = dt.Rows[0][1].ToString();
            TxtDecCompName.Text = dt.Rows[0][2].ToString();
            TxtDecCompName1.Text = dt.Rows[0][3].ToString();
            // txtDept.Text = dt.Rows[0][4].ToString();
        }

        protected void TxtIPQty_TextChanged(object sender, EventArgs e)
        {
            double T1, T2, T3, T4, T5;
            bool A = double.TryParse(TxtOPQty.Text.Trim(), out T1);
            bool B = double.TryParse(TxtIPQty.Text.Trim(), out T2);
            bool C = double.TryParse(TxtINPQty.Text.Trim(), out T3);
            bool D = double.TryParse(TxtIMPQty.Text.Trim(), out T4);
            bool F = double.TryParse(TxtTotalDutiableQuantity.Text.Trim(), out T5);
            //   bool G = double.TryParse(TxtIMPQty.Text.Trim(), out T9);

            duticalc(T1, T2, T3, T4, T5);
            txtAlcoholPer_TextChanged(null, null);
            DRPIPQUOM.Focus();
        }

        protected void txtAlcoholPer_TextChanged(object sender, EventArgs e)
        {
            if (txtAlcoholPer.Text != "")
            {

                double T1, T2, T3, T4, T5, T6, T7;
                bool A = double.TryParse(txttotDutiableQty.Text.Trim(), out T1);
                bool B = double.TryParse(txtAlcoholPer.Text.Trim(), out T2);
                bool C = double.TryParse(TxtExciseDutyRate.Text.Trim(), out T3);
                bool D = double.TryParse(TxtCustomsDutyRate.Text.Trim(), out T4);
                //if (T2 == 0)
                //{
                //    T2 = 1;
                //}


                if (A && B && C)
                {
                    if (T2 > 0)
                    {
                        TxtSumExciseDuty.Text = (T1 * T2 * (T3 / 100)).ToString();
                        TxtSumCustomsDuty.Text = (T1 * T2 * (T4 / 100)).ToString();
                    }

                }

                T4 = Convert.ToDouble(TxtSumExciseDuty.Text);
                T5 = Convert.ToDouble(TxtCIFFOB.Text);
                T7 = Convert.ToDouble(TxtSumCustomsDuty.Text);

                if (DrpDecType.SelectedItem.ToString() != "GST : GST (Including Duty Exemption)")
                {
                    T6 = ((T4 * 0.09) + (T5 * 0.09) + (T7 * 0.09));
                    TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T6.ToString()), 2).ToString();
                    if (Math.Round(Convert.ToDecimal(T6.ToString()), 2) >= 10000)
                    {
                        Lblmarquee.Text = "Total GST Amount greater than 10000";

                        txttotgstAmt.BorderColor = Color.Red;
                        updatepanel1.Update();
                    }
                    else
                    {
                        Lblmarquee.Text = "";
                        updatepanel1.Update();
                    }
                }

                else
                {
                    T6 = T5 * 0.09;
                    TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T6.ToString()), 2).ToString();
                    if (Math.Round(Convert.ToDecimal(T6.ToString()), 2) >= 10000)
                    {
                        Lblmarquee.Text = "Total GST Amount greater than 10000";

                        txttotgstAmt.BorderColor = Color.Red;
                        updatepanel1.Update();
                    }
                    else
                    {
                        Lblmarquee.Text = "";
                        updatepanel1.Update();
                    }
                }
                //bool D = double.TryParse(TxtCIFFOB.Text.Trim(), out T4);
                //bool E = double.TryParse(TxtSumExciseDuty.Text.Trim(), out T5);
                //if (D && E) 
                // = ((T4 * (7 / 100)) + (T5 * (7 / 100))).ToString() ;
            }
            upinitem.Update();
            updatepanel1.Update();
        }

        protected void TxtINPQty_TextChanged(object sender, EventArgs e)
        {
            double T1, T2, T3, T4, T5;
            bool A = double.TryParse(TxtOPQty.Text.Trim(), out T1);
            bool B = double.TryParse(TxtIPQty.Text.Trim(), out T2);
            bool C = double.TryParse(TxtINPQty.Text.Trim(), out T3);
            bool D = double.TryParse(TxtIMPQty.Text.Trim(), out T4);
            bool F = double.TryParse(TxtTotalDutiableQuantity.Text.Trim(), out T5);
            //   bool G = double.TryParse(TxtIMPQty.Text.Trim(), out T9);

            duticalc(T1, T2, T3, T4, T5);
            txtAlcoholPer_TextChanged(null, null);
            DRPINNPQUOM.Focus();
            upinitem.Update();
            updatepanel1.Update();
        }

        protected void TxtIMPQty_TextChanged(object sender, EventArgs e)
        {
            double T1, T2, T3, T4, T5;
            bool A = double.TryParse(TxtOPQty.Text.Trim(), out T1);
            bool B = double.TryParse(TxtIPQty.Text.Trim(), out T2);
            bool C = double.TryParse(TxtINPQty.Text.Trim(), out T3);
            bool D = double.TryParse(TxtIMPQty.Text.Trim(), out T4);
            bool F = double.TryParse(TxtTotalDutiableQuantity.Text.Trim(), out T5);
            //   bool G = double.TryParse(TxtIMPQty.Text.Trim(), out T9);

            duticalc(T1, T2, T3, T4, T5);
            txtAlcoholPer_TextChanged(null, null);
            DRPIMPQUOM.Focus();
        }

        protected void txttotDutiableQty_TextChanged(object sender, EventArgs e)
        {
            double T1, T2, T3, T4, T5;
            bool A = double.TryParse(TxtOPQty.Text.Trim(), out T1);
            bool B = double.TryParse(TxtIPQty.Text.Trim(), out T2);
            bool C = double.TryParse(TxtINPQty.Text.Trim(), out T3);
            bool D = double.TryParse(TxtIMPQty.Text.Trim(), out T4);
            bool F = double.TryParse(TxtTotalDutiableQuantity.Text.Trim(), out T5);
            //bool G = double.TryParse(TxtIMPQty.Text.Trim(), out T9);

            duticalc(T1, T2, T3, T4, T5);

            if (!string.IsNullOrWhiteSpace(txttotDutiableQty.Text))
            {
                if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                {
                    decimal val = Convert.ToDecimal(txttotDutiableQty.Text) * Convert.ToDecimal(TxtExciseDutyRate.Text);
                    TxtSumExciseDuty.Text = val.ToString();
                }
            }
            txtAlcoholPer_TextChanged(null, null);
            upinitem.Update();
            updatepanel1.Update();
            ddptotDutiableQty.Focus();
        }

        protected void TxtTotalDutiableQuantity_TextChanged(object sender, EventArgs e)
        {

            double T1, T2, T3, T4, T5;
            bool A = double.TryParse(TxtOPQty.Text.Trim(), out T1);
            bool B = double.TryParse(TxtIPQty.Text.Trim(), out T2);
            bool C = double.TryParse(TxtINPQty.Text.Trim(), out T3);
            bool D = double.TryParse(TxtIMPQty.Text.Trim(), out T4);
            bool F = double.TryParse(TxtTotalDutiableQuantity.Text.Trim(), out T5);
            //   bool G = double.TryParse(TxtIMPQty.Text.Trim(), out T9);

            duticalc(T1, T2, T3, T4, T5);
            txtAlcoholPer_TextChanged(null, null);
            TDQUOM.Focus();
        }



        private void duticalc(double op, double ip, double inp, double imp, double totduti)
        {
            string[] ss = TxtHSCodeItem.Text.Split(':');
            string qry1112 = "select * from HSCode where HSCode='" + ss[0].ToString() + "'";
            obj.dr = obj.ret_dr(qry1112);

            int typeidval = 0;
            while (obj.dr.Read())
            {
                kgmvis = obj.dr["Kgmvisible"].ToString();
                typeidval = Convert.ToInt32(obj.dr["DUTYTYPID"].ToString());
                BindProduct1();
            }

            if (TxtTotalDutiableQuantity.Text != "")
            {
                double T1, T2, T3, T4;
                bool A = double.TryParse(TxtExciseDutyRate.Text.Trim(), out T1);
                bool B = double.TryParse(TxtCIFFOB.Text.Trim(), out T2);

                if (ip != 0 && op != 0 && inp == 0 && imp == 0)
                {
                    if (TDQUOM.SelectedItem.Text == "LTR")
                    {
                        txttotDutiableQty.Text = (op * ip * totduti).ToString();
                        TxtHSQuantity.Text = (op * ip * totduti).ToString();
                    }
                    else if (TDQUOM.SelectedItem.Text == "TNE" && typeidval == 105)
                    {

                        if (TxtHSCodeItem.Text == "21069020" || TxtHSCodeItem.Text == "21069062" || TxtHSCodeItem.Text == "21069065" || TxtHSCodeItem.Text == "21069067" || TxtHSCodeItem.Text == "24012010" || TxtHSCodeItem.Text == "24012090" || TxtHSCodeItem.Text == "24031190" || TxtHSCodeItem.Text == "24031919" || TxtHSCodeItem.Text == "24031920" || TxtHSCodeItem.Text == "24031991" || TxtHSCodeItem.Text == "24031999" || TxtHSCodeItem.Text == "24039110" || TxtHSCodeItem.Text == "24039190" || TxtHSCodeItem.Text == "24039930" || TxtHSCodeItem.Text == "24039990" || TxtHSCodeItem.Text == "24041100" || TxtHSCodeItem.Text == "27112110" || TxtHSCodeItem.Text == "33021020")
                        {
                            txttotDutiableQty.Text = Math.Round(Convert.ToDecimal(((op * ip * totduti))), 2).ToString();
                        }
                        else
                        {
                            txttotDutiableQty.Text = Math.Round(Convert.ToDecimal(((op * ip * totduti))) / Convert.ToDecimal(1000), 2).ToString();
                        }
                        // txttotDutiableQty.Text = ((op * ip  * inp *imp * totduti)).ToString();

                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {


                            TxtSumExciseDuty.Text = Math.Round(Convert.ToDecimal(((txttotDutiableQty.Text))) * Convert.ToDecimal(T1), 2).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);

                        if (DrpDecType.SelectedItem.ToString() != "GST : GST (Including Duty Exemption)")
                        {
                            T4 = (T2 * 0.09) + (T3 * 0.09);

                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                        else
                        {
                            T4 = (T2 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }

                    }
                    else if (TDQUOM.SelectedItem.Text == "KGM" && typeidval == 105)
                    {

                        if (TxtHSCodeItem.Text == "21069020" || TxtHSCodeItem.Text == "21069062" || TxtHSCodeItem.Text == "21069065" || TxtHSCodeItem.Text == "21069067" || TxtHSCodeItem.Text == "24012010" || TxtHSCodeItem.Text == "24012090" || TxtHSCodeItem.Text == "24031190" || TxtHSCodeItem.Text == "24031919" || TxtHSCodeItem.Text == "24031920" || TxtHSCodeItem.Text == "24031991" || TxtHSCodeItem.Text == "24031999" || TxtHSCodeItem.Text == "24039110" || TxtHSCodeItem.Text == "24039190" || TxtHSCodeItem.Text == "24039930" || TxtHSCodeItem.Text == "24039990" || TxtHSCodeItem.Text == "24041100" || TxtHSCodeItem.Text == "27112110" || TxtHSCodeItem.Text == "33021020")
                        {
                            txttotDutiableQty.Text = Math.Round(Convert.ToDecimal(((op * ip * totduti))), 2).ToString();
                        }
                        else
                        {
                            txttotDutiableQty.Text = Math.Round(Convert.ToDecimal(((op * ip * totduti))) / Convert.ToDecimal(1000), 2).ToString();
                        }

                        // txttotDutiableQty.Text = ((op * ip  * inp *imp * totduti)).ToString();

                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {


                            TxtSumExciseDuty.Text = Math.Round(Convert.ToDecimal(((txttotDutiableQty.Text))) * Convert.ToDecimal(T1), 2).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);

                        if (DrpDecType.SelectedItem.ToString() != "GST : GST (Including Duty Exemption)")
                        {
                            T4 = (T2 * 0.09) + (T3 * 0.09);

                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                        else
                        {
                            T4 = (T2 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }

                    }
                    else if (TDQUOM.SelectedItem.Text == "KGM" && kgmvis == "MULTIPLE")
                    {

                        txttotDutiableQty.Text = ((op * ip * totduti)).ToString();
                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {
                            TxtSumExciseDuty.Text = ((op * ip * totduti) * (T1)).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);

                        if (DrpDecType.SelectedItem.ToString() != "GST : GST (Including Duty Exemption)")
                        {

                            T4 = (T2 * 0.09) + (T3 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString("0.00");
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                        else
                        {
                            T4 = (T2 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString("0.00");
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }


                    }
                    else if (TDQUOM.SelectedItem.Text == "KGM" && kgmvis == "DIVIDE")
                    {

                        txttotDutiableQty.Text = ((op * ip * totduti) / 1000).ToString();
                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {
                            TxtSumExciseDuty.Text = (((op * ip * totduti) / 1000) * (T1)).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);
                        if (DrpDecType.SelectedItem.ToString() != "GST : GST (Including Duty Exemption)")
                        {

                            T4 = (T2 * 0.09) + (T3 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                        else
                        {
                            T4 = (T2 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                    }

                    else if (TDQUOM.SelectedItem.Text == "STK")
                    {

                        txttotDutiableQty.Text = ((op * ip)).ToString();
                        TxtHSQuantity.Text = ((op * ip * totduti) / 1000).ToString();
                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {
                            TxtSumExciseDuty.Text = (((op * ip)) * (T1)).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);
                        if (DrpDecType.SelectedItem.ToString() != "GST : GST (Including Duty Exemption)")
                        {
                            T4 = (T2 * 0.09) + (T3 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                        else
                        {
                            T4 = (T2 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                    }
                   

                    else if (TDQUOM.SelectedItem.Text == "KGM" && typeidval == 62)
                    {

                        txttotDutiableQty.Text = ((op * ip * totduti)).ToString();
                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {
                            TxtSumExciseDuty.Text = (((op * ip * totduti)) * (T1)).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);

                        if (DrpDecType.SelectedItem.ToString() != "GST : GST (Including Duty Exemption)")
                        {
                            T4 = (T2 * 0.09) + (T3 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                        else
                        {
                            T4 = (T2 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                    }

                    else if (TDQUOM.SelectedItem.Text == "TNE" && typeidval == 62)
                    {

                        txttotDutiableQty.Text = ((op * ip * totduti)).ToString();
                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {
                            TxtSumExciseDuty.Text = (((op * ip * totduti)) * (T1)).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);

                        if (DrpDecType.SelectedItem.ToString() != "GST : GST (Including Duty Exemption)")
                        {
                            T4 = (T2 * 0.09) + (T3 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                        else
                        {
                            T4 = (T2 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                    }
                    else if (TDQUOM.SelectedItem.Text == "DAL")
                    {

                        txttotDutiableQty.Text = ((op * ip * totduti)).ToString();
                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {
                            TxtSumExciseDuty.Text = (((op * ip * totduti)) * (T1)).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);

                        if (DrpDecType.SelectedItem.ToString() != "GST : GST (Including Duty Exemption)")
                        {
                            T4 = (T2 * 0.09) + (T3 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                        else
                        {
                            T4 = (T2 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }


                        }
                    }




                }

                else if (op != 0 && ip == 0 && inp == 0 && imp == 0)
                {
                    if (TDQUOM.SelectedItem.Text == "LTR")
                    {


                        txttotDutiableQty.Text = (op * totduti).ToString();
                        TxtHSQuantity.Text = (op * totduti).ToString();

                    }
                    else if (TDQUOM.SelectedItem.Text == "TNE" && typeidval == 105)
                    {
                                                            
                        if (TxtHSCodeItem.Text == "21069020" || TxtHSCodeItem.Text == "21069062" || TxtHSCodeItem.Text == "21069065" || TxtHSCodeItem.Text == "21069067" || TxtHSCodeItem.Text == "24012010" || TxtHSCodeItem.Text == "24012090" || TxtHSCodeItem.Text == "24031190" || TxtHSCodeItem.Text == "24031919" || TxtHSCodeItem.Text == "24031920" || TxtHSCodeItem.Text == "24031991" || TxtHSCodeItem.Text == "24031999" || TxtHSCodeItem.Text == "24039110" || TxtHSCodeItem.Text == "24039190" || TxtHSCodeItem.Text == "24039930" || TxtHSCodeItem.Text == "24039990" || TxtHSCodeItem.Text == "24041100" || TxtHSCodeItem.Text == "27112110" || TxtHSCodeItem.Text == "33021020")
                        {
                            txttotDutiableQty.Text = Math.Round(Convert.ToDecimal(((op * totduti))), 2).ToString();
                        }
                        else
                        {
                            txttotDutiableQty.Text = Math.Round(Convert.ToDecimal(((op * totduti))) / Convert.ToDecimal(1000), 2).ToString();
                        }
                        // txttotDutiableQty.Text = ((op * ip  * inp *imp * totduti)).ToString();

                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {


                            TxtSumExciseDuty.Text = Math.Round(Convert.ToDecimal(((txttotDutiableQty.Text))) * Convert.ToDecimal(T1), 2).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);

                        if (DrpDecType.SelectedItem.ToString() != "GST : GST (Including Duty Exemption)")
                        {
                            T4 = (T2 * 0.09) + (T3 * 0.09);

                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                        else
                        {
                            T4 = (T2 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }

                    }
                    else if (TDQUOM.SelectedItem.Text == "KGM" && typeidval == 105)
                    {                     

                        if (TxtHSCodeItem.Text== "21069020" || TxtHSCodeItem.Text == "21069062" || TxtHSCodeItem.Text == "21069065" || TxtHSCodeItem.Text == "21069067" || TxtHSCodeItem.Text == "24012010" || TxtHSCodeItem.Text == "24012090" || TxtHSCodeItem.Text == "24031190" || TxtHSCodeItem.Text == "24031919" || TxtHSCodeItem.Text == "24031920" || TxtHSCodeItem.Text == "24031991" || TxtHSCodeItem.Text == "24031999" || TxtHSCodeItem.Text == "24039110" || TxtHSCodeItem.Text == "24039190" || TxtHSCodeItem.Text == "24039930" || TxtHSCodeItem.Text == "24039990" || TxtHSCodeItem.Text == "24041100" || TxtHSCodeItem.Text == "27112110" || TxtHSCodeItem.Text == "33021020")
                        {
                            txttotDutiableQty.Text = Math.Round(Convert.ToDecimal(((op * totduti))) , 2).ToString();
                        }
                        else
                        {
                            txttotDutiableQty.Text = Math.Round(Convert.ToDecimal(((op * totduti))) / Convert.ToDecimal(1000), 2).ToString();
                        }
                      
                        // txttotDutiableQty.Text = ((op * ip  * inp *imp * totduti)).ToString();

                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {

                            
                            TxtSumExciseDuty.Text = Math.Round(Convert.ToDecimal(((txttotDutiableQty.Text))) * Convert.ToDecimal(T1), 2).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);

                        if (DrpDecType.SelectedItem.ToString() != "GST : GST (Including Duty Exemption)")
                        {
                            T4 = (T2 * 0.09) + (T3 * 0.09);

                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                        else
                        {
                            T4 = (T2 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }

                    }
                    else if (TDQUOM.SelectedItem.Text == "KGM" && kgmvis == "MULTIPLE")
                    {

                        txttotDutiableQty.Text = ((op * totduti)).ToString();
                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {
                            TxtSumExciseDuty.Text = ((op * totduti) * (T1)).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);

                        if (DrpDecType.SelectedItem.ToString() != "GST : GST (Including Duty Exemption)")
                        {
                            T4 = (T2 * 0.09) + (T3 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                        else
                        {
                            T4 = (T2 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }


                    }
                    else if (TDQUOM.SelectedItem.Text == "KGM" && kgmvis == "DIVIDE")
                    {

                        txttotDutiableQty.Text = ((op * totduti) / 1000).ToString();
                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {
                            TxtSumExciseDuty.Text = (((op * totduti) / 1000) * (T1)).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);

                        if (DrpDecType.SelectedItem.ToString() != "GST : GST (Including Duty Exemption)")
                        {
                            T4 = (T2 * 0.09) + (T3 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                        else
                        {
                            T4 = (T2 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                    }

                    else if (TDQUOM.SelectedItem.Text == "STK")
                    {

                        txttotDutiableQty.Text = ((op)).ToString();
                        TxtHSQuantity.Text = ((op * totduti) / 1000).ToString();
                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {
                            TxtSumExciseDuty.Text = (((op)) * (T1)).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);

                        if (DrpDecType.SelectedItem.ToString() != "GST : GST (Including Duty Exemption)")
                        {
                            T4 = (T2 * 0.09) + (T3 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                        else
                        {
                            T4 = (T2 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                    }
                    else if (TDQUOM.SelectedItem.Text == "KGM" && typeidval == 62)
                    {

                        txttotDutiableQty.Text = ((op * totduti)).ToString();
                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {
                            TxtSumExciseDuty.Text = (((op * totduti)) * (T1)).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);

                        if (DrpDecType.SelectedItem.ToString() != "GST : GST (Including Duty Exemption)")
                        {
                            T4 = (T2 * 0.09) + (T3 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                        else
                        {
                            T4 = (T2 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                    }

                    else if (TDQUOM.SelectedItem.Text == "TNE" && typeidval == 62)
                    {

                        txttotDutiableQty.Text = ((op * totduti)).ToString();
                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {
                            TxtSumExciseDuty.Text = (((op * totduti)) * (T1)).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);

                        if (DrpDecType.SelectedItem.ToString() != "GST : GST (Including Duty Exemption)")
                        {
                            T4 = (T2 * 0.09) + (T3 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                        else
                        {
                            T4 = (T2 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                    }
                    else if (TDQUOM.SelectedItem.Text == "DAL")
                    {

                        txttotDutiableQty.Text = ((op * totduti)).ToString();
                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {
                            TxtSumExciseDuty.Text = (((op * totduti)) * (T1)).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);

                        if (DrpDecType.SelectedItem.ToString() != "GST : GST (Including Duty Exemption)")
                        {
                            T4 = (T2 * 0.09) + (T3 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                        else
                        {
                            T4 = (T2 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                    }
                }
                else if (ip != 0 && op != 0 && inp != 0 && imp != 0)
                {
                    if (TDQUOM.SelectedItem.Text == "LTR")
                    {


                        txttotDutiableQty.Text = (op * ip * inp * imp * totduti).ToString();
                        TxtHSQuantity.Text = (op * ip * inp * imp * totduti).ToString();

                    }
                    else if (TDQUOM.SelectedItem.Text == "TNE" && typeidval == 105)
                    {

                        if (TxtHSCodeItem.Text == "21069020" || TxtHSCodeItem.Text == "21069062" || TxtHSCodeItem.Text == "21069065" || TxtHSCodeItem.Text == "21069067" || TxtHSCodeItem.Text == "24012010" || TxtHSCodeItem.Text == "24012090" || TxtHSCodeItem.Text == "24031190" || TxtHSCodeItem.Text == "24031919" || TxtHSCodeItem.Text == "24031920" || TxtHSCodeItem.Text == "24031991" || TxtHSCodeItem.Text == "24031999" || TxtHSCodeItem.Text == "24039110" || TxtHSCodeItem.Text == "24039190" || TxtHSCodeItem.Text == "24039930" || TxtHSCodeItem.Text == "24039990" || TxtHSCodeItem.Text == "24041100" || TxtHSCodeItem.Text == "27112110" || TxtHSCodeItem.Text == "33021020")
                        {
                            txttotDutiableQty.Text = Math.Round(Convert.ToDecimal(((op * ip * inp * imp * totduti))), 2).ToString();
                        }
                        else
                        {
                            txttotDutiableQty.Text = Math.Round(Convert.ToDecimal(((op * ip * inp * imp * totduti))) / Convert.ToDecimal(1000), 2).ToString();
                        }
                        // txttotDutiableQty.Text = ((op * ip  * inp *imp * totduti)).ToString();

                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {


                            TxtSumExciseDuty.Text = Math.Round(Convert.ToDecimal(((txttotDutiableQty.Text))) * Convert.ToDecimal(T1), 2).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);

                        if (DrpDecType.SelectedItem.ToString() != "GST : GST (Including Duty Exemption)")
                        {
                            T4 = (T2 * 0.09) + (T3 * 0.09);

                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                        else
                        {
                            T4 = (T2 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }

                    }
                    else if (TDQUOM.SelectedItem.Text == "KGM" && typeidval == 105)
                    {

                        if (TxtHSCodeItem.Text == "21069020" || TxtHSCodeItem.Text == "21069062" || TxtHSCodeItem.Text == "21069065" || TxtHSCodeItem.Text == "21069067" || TxtHSCodeItem.Text == "24012010" || TxtHSCodeItem.Text == "24012090" || TxtHSCodeItem.Text == "24031190" || TxtHSCodeItem.Text == "24031919" || TxtHSCodeItem.Text == "24031920" || TxtHSCodeItem.Text == "24031991" || TxtHSCodeItem.Text == "24031999" || TxtHSCodeItem.Text == "24039110" || TxtHSCodeItem.Text == "24039190" || TxtHSCodeItem.Text == "24039930" || TxtHSCodeItem.Text == "24039990" || TxtHSCodeItem.Text == "24041100" || TxtHSCodeItem.Text == "27112110" || TxtHSCodeItem.Text == "33021020")
                        {
                            txttotDutiableQty.Text = Math.Round(Convert.ToDecimal(((op * ip * inp * imp * totduti))), 2).ToString();
                        }
                        else
                        {
                            txttotDutiableQty.Text = Math.Round(Convert.ToDecimal(((op * ip * inp * imp * totduti))) / Convert.ToDecimal(1000), 2).ToString();
                        }

                        // txttotDutiableQty.Text = ((op * ip  * inp *imp * totduti)).ToString();

                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {


                            TxtSumExciseDuty.Text = Math.Round(Convert.ToDecimal(((txttotDutiableQty.Text))) * Convert.ToDecimal(T1), 2).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);

                        if (DrpDecType.SelectedItem.ToString() != "GST : GST (Including Duty Exemption)")
                        {
                            T4 = (T2 * 0.09) + (T3 * 0.09);

                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                        else
                        {
                            T4 = (T2 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }

                    }
                    else if (TDQUOM.SelectedItem.Text == "KGM" && kgmvis == "MULTIPLE")
                    {

                        txttotDutiableQty.Text = ((op * ip * inp * imp * totduti)).ToString();
                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {
                            TxtSumExciseDuty.Text = ((op * ip * inp * imp * totduti) * (T1)).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);

                        if (DrpDecType.SelectedItem.ToString() != "GST : GST (Including Duty Exemption)")
                        {
                            T4 = (T2 * 0.09) + (T3 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                        else
                        {
                            T4 = (T2 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }


                    }
                    else if (TDQUOM.SelectedItem.Text == "KGM" && kgmvis == "DIVIDE")
                    {

                        txttotDutiableQty.Text = ((op * ip * inp * imp * totduti) / 1000).ToString();
                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {
                            TxtSumExciseDuty.Text = (((op * ip * inp * imp * totduti) / 1000) * (T1)).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);

                        if (DrpDecType.SelectedItem.ToString() != "GST : GST (Including Duty Exemption)")
                        {
                            T4 = (T2 * 0.09) + (T3 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                        else
                        {
                            T4 = (T2 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                    }

                    else if (TDQUOM.SelectedItem.Text == "STK")
                    {

                        txttotDutiableQty.Text = ((op * ip * inp * imp)).ToString();
                        TxtHSQuantity.Text = ((op * ip * inp * imp * totduti) / 1000).ToString();
                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {
                            TxtSumExciseDuty.Text = (((op * ip * inp * imp)) * (T1)).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);
                        if (DrpDecType.SelectedItem.ToString() != "GST : GST (Including Duty Exemption)")
                        {
                            T4 = (T2 * 0.09) + (T3 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                        else
                        {
                            T4 = (T2 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                    }
                    else if (TDQUOM.SelectedItem.Text == "KGM" && typeidval == 62)
                    {

                        txttotDutiableQty.Text = ((op * ip * inp * imp * totduti)).ToString();
                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {
                            TxtSumExciseDuty.Text = (((op * ip * inp * imp * totduti)) * (T1)).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);
                        if (DrpDecType.SelectedItem.ToString() != "GST : GST (Including Duty Exemption)")
                        {
                            T4 = (T2 * 0.09) + (T3 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                        else
                        {
                            T4 = (T2 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                    }

                    else if (TDQUOM.SelectedItem.Text == "TNE" && typeidval == 62)
                    {

                        txttotDutiableQty.Text = ((op * ip * inp * imp * totduti)).ToString();
                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {
                            TxtSumExciseDuty.Text = (((op * ip * inp * imp * totduti)) * (T1)).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);
                        if (DrpDecType.SelectedItem.ToString() != "GST : GST (Including Duty Exemption)")
                        {
                            T4 = (T2 * 0.09) + (T3 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                        else
                        {
                            T4 = (T2 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                    }
                    else if (TDQUOM.SelectedItem.Text == "DAL")
                    {

                        txttotDutiableQty.Text = ((op * ip * inp * imp * totduti)).ToString();
                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {
                            TxtSumExciseDuty.Text = (((op * ip * inp * imp * totduti)) * (T1)).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);
                        if (DrpDecType.SelectedItem.ToString() != "GST : GST (Including Duty Exemption)")
                        {
                            T4 = (T2 * 0.09) + (T3 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                        else
                        {
                            T4 = (T2 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                    }


                }
                else if (ip != 0 && op != 0 && inp != 0 && imp == 0)
                {
                    if (TDQUOM.SelectedItem.Text == "LTR")
                    {


                        txttotDutiableQty.Text = (op * ip * inp * totduti).ToString();
                        TxtHSQuantity.Text = (op * ip * inp * totduti).ToString();

                    }

                    else if (TDQUOM.SelectedItem.Text == "TNE" && typeidval == 105)
                    {

                        if (TxtHSCodeItem.Text == "21069020" || TxtHSCodeItem.Text == "21069062" || TxtHSCodeItem.Text == "21069065" || TxtHSCodeItem.Text == "21069067" || TxtHSCodeItem.Text == "24012010" || TxtHSCodeItem.Text == "24012090" || TxtHSCodeItem.Text == "24031190" || TxtHSCodeItem.Text == "24031919" || TxtHSCodeItem.Text == "24031920" || TxtHSCodeItem.Text == "24031991" || TxtHSCodeItem.Text == "24031999" || TxtHSCodeItem.Text == "24039110" || TxtHSCodeItem.Text == "24039190" || TxtHSCodeItem.Text == "24039930" || TxtHSCodeItem.Text == "24039990" || TxtHSCodeItem.Text == "24041100" || TxtHSCodeItem.Text == "27112110" || TxtHSCodeItem.Text == "33021020")
                        {
                            txttotDutiableQty.Text = Math.Round(Convert.ToDecimal(((op * ip * inp * totduti))), 2).ToString();
                        }
                        else
                        {
                            txttotDutiableQty.Text = Math.Round(Convert.ToDecimal(((op * ip * inp  * totduti))) / Convert.ToDecimal(1000), 2).ToString();
                        }
                        // txttotDutiableQty.Text = ((op * ip  * inp *imp * totduti)).ToString();

                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {


                            TxtSumExciseDuty.Text = Math.Round(Convert.ToDecimal(((txttotDutiableQty.Text))) * Convert.ToDecimal(T1), 2).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);

                        if (DrpDecType.SelectedItem.ToString() != "GST : GST (Including Duty Exemption)")
                        {
                            T4 = (T2 * 0.09) + (T3 * 0.09);

                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                        else
                        {
                            T4 = (T2 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }

                    }
                    else if (TDQUOM.SelectedItem.Text == "KGM" && typeidval == 105)
                    {

                        if (TxtHSCodeItem.Text == "21069020" || TxtHSCodeItem.Text == "21069062" || TxtHSCodeItem.Text == "21069065" || TxtHSCodeItem.Text == "21069067" || TxtHSCodeItem.Text == "24012010" || TxtHSCodeItem.Text == "24012090" || TxtHSCodeItem.Text == "24031190" || TxtHSCodeItem.Text == "24031919" || TxtHSCodeItem.Text == "24031920" || TxtHSCodeItem.Text == "24031991" || TxtHSCodeItem.Text == "24031999" || TxtHSCodeItem.Text == "24039110" || TxtHSCodeItem.Text == "24039190" || TxtHSCodeItem.Text == "24039930" || TxtHSCodeItem.Text == "24039990" || TxtHSCodeItem.Text == "24041100" || TxtHSCodeItem.Text == "27112110" || TxtHSCodeItem.Text == "33021020")
                        {
                            txttotDutiableQty.Text = Math.Round(Convert.ToDecimal(((op * ip * inp  * totduti))), 2).ToString();
                        }
                        else
                        {
                            txttotDutiableQty.Text = Math.Round(Convert.ToDecimal(((op * ip * inp  * totduti))) / Convert.ToDecimal(1000), 2).ToString();
                        }

                        // txttotDutiableQty.Text = ((op * ip  * inp *imp * totduti)).ToString();

                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {


                            TxtSumExciseDuty.Text = Math.Round(Convert.ToDecimal(((txttotDutiableQty.Text))) * Convert.ToDecimal(T1), 2).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);

                        if (DrpDecType.SelectedItem.ToString() != "GST : GST (Including Duty Exemption)")
                        {
                            T4 = (T2 * 0.09) + (T3 * 0.09);

                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                        else
                        {
                            T4 = (T2 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }

                    }
                    else if (TDQUOM.SelectedItem.Text == "KGM" && kgmvis == "MULTIPLE")
                    {

                        txttotDutiableQty.Text = ((op * ip * inp * totduti)).ToString();
                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {
                            TxtSumExciseDuty.Text = ((op * ip * inp * totduti) * (T1)).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);

                        if (DrpDecType.SelectedItem.ToString() != "GST : GST (Including Duty Exemption)")
                        {
                            T4 = (T2 * 0.09) + (T3 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                        else
                        {
                            T4 = (T2 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }


                    }
                    else if (TDQUOM.SelectedItem.Text == "KGM" && kgmvis == "DIVIDE")
                    {

                        txttotDutiableQty.Text = ((op * ip * inp * totduti / 1000)).ToString();
                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {
                            TxtSumExciseDuty.Text = (((op * ip * inp * totduti) / 1000) * (T1)).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);

                        if (DrpDecType.SelectedItem.ToString() != "GST : GST (Including Duty Exemption)")
                        {
                            T4 = (T2 * 0.09) + (T3 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                        else
                        {
                            T4 = (T2 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                    }

                    else if (TDQUOM.SelectedItem.Text == "STK")
                    {

                        txttotDutiableQty.Text = ((op * ip * inp)).ToString();
                        TxtHSQuantity.Text = ((op * ip * inp * totduti) / 1000).ToString();
                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {
                            TxtSumExciseDuty.Text = (((op * ip * inp)) * (T1)).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);

                        if (DrpDecType.SelectedItem.ToString() != "GST : GST (Including Duty Exemption)")
                        {
                            T4 = (T2 * 0.09) + (T3 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                        else
                        {
                            T4 = (T2 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                    }
                    else if (TDQUOM.SelectedItem.Text == "KGM" && typeidval == 62)
                    {

                        txttotDutiableQty.Text = ((op * ip * inp * totduti)).ToString();
                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {
                            TxtSumExciseDuty.Text = (((op * ip * inp * totduti)) * (T1)).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);

                        if (DrpDecType.SelectedItem.ToString() != "GST : GST (Including Duty Exemption)")
                        {
                            T4 = (T2 * 0.09) + (T3 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                        else
                        {
                            T4 = (T2 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                    }

                    else if (TDQUOM.SelectedItem.Text == "TNE" && typeidval == 62)
                    {

                        txttotDutiableQty.Text = ((op * ip * inp * totduti)).ToString();
                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {
                            TxtSumExciseDuty.Text = (((op * ip * inp * totduti)) * (T1)).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);

                        if (DrpDecType.SelectedItem.ToString() != "GST : GST (Including Duty Exemption)")
                        {
                            T4 = (T2 * 0.09) + (T3 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                        else
                        {
                            T4 = (T2 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                    }
                    else if (TDQUOM.SelectedItem.Text == "DAL")
                    {

                        txttotDutiableQty.Text = ((op * ip * inp * totduti)).ToString();
                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {
                            TxtSumExciseDuty.Text = (((op * ip * inp * totduti)) * (T1)).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);

                        if (DrpDecType.SelectedItem.ToString() != "GST : GST (Including Duty Exemption)")
                        {
                            T4 = (T2 * 0.09) + (T3 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                        else
                        {
                            T4 = (T2 * 0.09);
                            TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T4.ToString()), 2).ToString();
                            if (Math.Round(Convert.ToDecimal(T4.ToString()), 2) >= 10000)
                            {
                                Lblmarquee.Text = "Total GST Amount greater than 10000";

                                txttotgstAmt.BorderColor = Color.Red;
                                updatepanel1.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                updatepanel1.Update();
                            }
                        }
                    }

                }
                upinitem.Update();
                updatepanel1.Update();
            }
        }


        protected void gsttarrif()
        {

        }


        protected void btnsaveheader_Click(object sender, EventArgs e)
        {




        }

        protected void btnresetheader_Click(object sender, EventArgs e)
        {

            //DrpDecType.ClearSelection();
            //TxtPrevPerNO.Text = "";

            //DrpCargoPackType.ClearSelection();
            //DrpInwardtrasMode.ClearSelection();
            //DrpBGIndicator.ClearSelection();
            //ChkSupplyIndicator.Checked = false;
            //ChkRefDoc.Checked = false;

            HeaderClr();
        }

        protected void btnnextheader_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[TabContainer1.ActiveTabIndex + 1];
            upinheader.Update();
            updatepanel1.Update();
            TxtDecCompCode.Focus();

        }

        protected void btnpreviousparty_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[TabContainer1.ActiveTabIndex - 1];
            upinheader.Update();
            updatepanel1.Update();

        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            partyClr();
        }

        protected void btnnextparty_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[TabContainer1.ActiveTabIndex + 1];
            upincargo.Update();
            updatepanel1.Update();
            TxtLoadShort.Focus();

        }

        protected void btnprevcargo_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[TabContainer1.ActiveTabIndex - 1];
            upinheader.Update();
            updatepanel1.Update();
            TxtImpCode.Focus();

        }

        protected void btnsavecargo_Click(object sender, EventArgs e)
        {
            int chkCode = 0;


            string License = TxtLicense1.Text + '-' + TxtLicense2.Text + '-' + TxtLicense3.Text + '-' + TxtLicense4.Text + '-' + TxtLicense5.Text;
            string Recipient = TxtRECPT1.Text + '-' + TxtRECPT2.Text + '-' + TxtRECPT3.Text;


            string Touch_user = Session["UserId"].ToString();
            DateTime ArrivalDate = Convert.ToDateTime(null);
            if (TxtArrivalDate1.Text == "")
            {
                var date = DateTime.Now.ToString("dd/MM/yyyy");
                var manDate = DateTime.ParseExact(date, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                ArrivalDate = Convert.ToDateTime(manDate);
            }
            else
            {
                var InvoiceDate1 = DateTime.ParseExact(TxtArrivalDate1.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                ArrivalDate = Convert.ToDateTime(InvoiceDate1);
            }

            //var ArrivalDate = DateTime.Parse(this.TxtArrivalDate1.Text, new CultureInfo("en-US", true));

            DateTime BlanketDate = Convert.ToDateTime(null);
            if (BlankDate1.Text == "")
            {
                var date = DateTime.Now.ToString("dd/MM/yyyy");
                var manDate = DateTime.ParseExact(date, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                BlanketDate = Convert.ToDateTime(manDate);
            }
            else
            {
                var InvoiceDate1 = DateTime.ParseExact(BlankDate1.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                BlanketDate = Convert.ToDateTime(InvoiceDate1);
            }
            //var BlanketDate = DateTime.Parse(this.BlankDate1.Text, new CultureInfo("en-US", true));
            JobNO();
            MSGNO();

            refid();

            string PrevPer = "";
            string qry11 = "SELECT PermitId FROM InpaymentTemp where PermitId='" + txt_code.Text + "'";
            obj.dr = obj.ret_dr(qry11);
            while (obj.dr.Read())
            {
                PrevPer = obj.dr[0].ToString();
            }
            if (PrevPer != "")
            {
                string PerCount = ("Delete InpaymentTemp where PermitId='" + txt_code.Text + "'");
                obj.exec(PerCount);
                obj.closecon();
            }
            string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //string ad = Convert.ToDateTime(ArrivalDate).ToString("yyyy-MM-dd HH:mm:ss");
        //string bd = Convert.ToDateTime(BlanketDate).ToString("yyyy-MM-dd HH:mm:ss");
        Save:
            string Nullval = "0.00";
            string StrQuery = (" INSERT INTO [dbo].[InpaymentTemp] ([Refid],[JobId],[MSGId],[PermitId],[TradeNetMailboxID],[MessageType],[DeclarationType],[PreviousPermit],[CargoPackType],[InwardTransportMode],[BGIndicator],[SupplyIndicator],[ReferenceDocuments],[License],[Recipient],[DeclarantCompanyCode],[ImporterCompanyCode],[InwardCarrierAgentCode],[FreightForwarderCode],[ClaimantPartyCode],HBL,[ArrivalDate],[LoadingPortCode],[VoyageNumber],[VesselName],[OceanBillofLadingNo],[ConveyanceRefNo],[TransportId],[FlightNO],[AircraftRegNo],[MasterAirwayBill],[ReleaseLocation],ReleaseLocName,[RecepitLocation],[TotalOuterPack],[TotalOuterPackUOM],[TotalGrossWeight],[TotalGrossWeightUOM],[GrossReference],[BlanketStartDate],[TradeRemarks],[InternalRemarks],[CustomerRemarks],[Status],[prmtStatus],[TouchUser],[TouchTime],[DeclareIndicator],[NumberOfItems],[TotalCIFFOBValue],[TotalGSTTaxAmt],[TotalExDutyAmt],[TotalCusDutyAmt],[TotalODutyAmt],[TotalAmtPay],Cnb,Customers) Values ('" + refno + "','" + JobNo + "','" + MsgNO + "','" + txt_code.Text + "','" + TxtTradeMailID.Text + "','" + TxtMsgType.Text + "','" + DrpDecType.SelectedItem.ToString() + "','" + TxtPrevPerNO.Text + "','" + DrpCargoPackType.SelectedItem.ToString() + "','" + DrpInwardtrasMode.SelectedItem.ToString() + "','" + DrpBGIndicator.SelectedItem.ToString() + "','" + ChkSupplyIndicator.Checked.ToString().ToLower() + "','" + ChkRefDoc.Checked.ToString().ToLower() + "','" + License + "','" + Recipient + "','" + TxtDecCompCode.Text + "','" + TxtImpCode.Text + "','" + InwardCode.Text + "','" + FrieghtCode.Text + "','" + ClaimantName.Text + "','" + txthBlCargo.Text + "','" + Convert.ToDateTime(ArrivalDate).ToString("yyyy/MM/dd") + "','" + TxtLoadShort.Text + "','" + TxtVoyageno.Text + "','" + TxtVesselName.Text + "','" + TxtOceanBill.Text + "','" + TxtConRefNo.Text + "','" + TxtTrnsID.Text + "','" + txtflight.Text + "','" + txtaircraft.Text + "','" + txtwaybill.Text + "','" + txtreLoctn.Text + "','" + txtrelocDeta.Text + "','" + txtrecloctn.Text + "','" + TxttotalOuterPack.Text + "','" + DrptotalOuterPack.SelectedItem.ToString() + "','" + TxtTotalGrossWeight.Text + "','" + DrpTotalGrossWeight.SelectedItem.ToString() + "','" + TxtGrossReference.Text + "','" + Convert.ToDateTime(BlanketDate).ToString("yyyy/MM/dd") + "','" + txttrdremrk.Text + "','" + txtintremrk.Text + "','" + txtcusRemrk.Text + "','NEW','NEW','" + Touch_user + "','" + strTime + "','" + chkDeclareInd.Checked.ToString().ToLower() + "','" + Nullval + "','" + Nullval + "','" + Nullval + "','" + Nullval + "','" + Nullval + "','" + Nullval + "','" + Nullval + "','" + chkcnb.Checked.ToString() + "','" + DrpCustomers.SelectedItem.Text + "')");
            // string StrQuery = (" INSERT INTO [dbo].[InHeaderTbl] ([JobId],[MSGId],[PermitId],[TradeNetMailboxID],[MessageType],[DeclarationType],[CargoPackType],[InwardTransportMode],[BGIndicator],[SupplyIndicator],[ReferenceDocuments],[License],[Recipient],[DeclarantCompanyCode],[ImporterCompanyCode],[InwardCarrierAgentCode],[FreightForwarderCode],[ClaimantPartyCode],[ArrivalDate],[LoadingPortCode],[VoyageNumber],[VesselName],[OceanBillofLadingNo],[ConveyanceRefNo],[TransportId],[FlightNO],[AircraftRegNo],[MasterAirwayBill],[ReleaseLocation],[RecepitLocation],[TotalOuterPack],[TotalOuterPackUOM],[TotalGrossWeight],[TotalGrossWeightUOM],[GrossReference],[BlanketStartDate],[Status],[TouchUser],[TouchTime]) Values ('" + JobNo + "','" + MsgNO + "','" + txt_code.Text + "','" + TxtTradeMailID.Text + "','" + TxtMsgType.Text + "','" + DrpDecType.SelectedItem.ToString() + "','" + DrpCargoPackType.SelectedItem.ToString() + "','" + DrpInwardtrasMode.SelectedItem.ToString() + "','" + DrpBGIndicator.SelectedItem.ToString() + "','" + ChkSupplyIndicator.Checked.ToString() + "','" + ChkRefDoc.Checked.ToString() + "','" + License + "','" + Recipient + "','" + TxtDecCompCode.Text + "','" + TxtImpCode.Text + "','" + InwardCode.Text + "','" + FrieghtCode.Text + "','" + ClaimantName.Text + "','" + ArrivalDate + "','" + TxtLoadShort.Text + "','" + TxtVoyageno.Text + "','" + TxtVesselName.Text + "','" + TxtOceanBill.Text + "','" + TxtConRefNo.Text + "','" + TxtTrnsID.Text + "','" + txtflight.Text + "','" + txtaircraft.Text + "','" + txtwaybill.Text + "','" + txtreLoctn.Text + "','" + txtrecloctn.Text + "','" + TxttotalOuterPack.Text + "','" + DrptotalOuterPack.SelectedItem.ToString() + "','" + TxtTotalGrossWeight.Text + "','" + DrpTotalGrossWeight.SelectedItem.ToString() + "','" + TxtGrossReference.Text + "','" + BlanketDate + "','DRF','" + Touch_user + "','" + strTime + "')");
            chkCode = obj.exec(StrQuery);
            if (chkCode == -2146232060)
            {
                PermitNO();
                goto Save;
            }
            btnnextcargo.Focus();

        }

        protected void btnresetcargo_Click(object sender, EventArgs e)
        {
            CargoClr();
        }

        protected void btnnextcargo_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[TabContainer1.ActiveTabIndex + 1];
            updatepanel1.Update();
            txtcodeinvq.Focus();


        }

        protected void btnprevinvoice_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[TabContainer1.ActiveTabIndex - 1];
            updatepanel1.Update();


        }

        protected void btnsaveinvoice_Click(object sender, EventArgs e)
        {

        }

        protected void btnresetinvoice_Click(object sender, EventArgs e)
        {
            InvoiceClr();
        }

        protected void btnnextinvoice_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[TabContainer1.ActiveTabIndex + 1];
            updatepanel1.Update();
            TxtHAWB.Focus();

        }

        protected void btnprevitem_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[TabContainer1.ActiveTabIndex - 1];
            updatepanel1.Update();

        }

        //protected void btnsaveitem_Click(object sender, EventArgs e)
        //{

        //}

        protected void btnresetitem_Click(object sender, EventArgs e)
        {
            Itemclear();
        }

        protected void btnnextitem_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[TabContainer1.ActiveTabIndex + 1];
            updatepanel1.Update();
            chkaeo.Focus();

        }

        protected void btnprevcpc_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[TabContainer1.ActiveTabIndex - 1];
            updatepanel1.Update();

        }


        protected void btnnextcpc_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[TabContainer1.ActiveTabIndex + 1];
            updatepanel1.Update();
            txttrdremrk.Focus();

        }

        protected void btnprevsum_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[TabContainer1.ActiveTabIndex - 1];
            updatepanel1.Update();

        }

        protected void btnsavesum_Click(object sender, EventArgs e)
        {           


            ReqValidatePageLoad();


            double totinv, totciffob = 0;

            totinv = Convert.ToDouble(txtcifVal.Text);
            totciffob = Convert.ToDouble(txtfobval.Text);
            string confirmValue = Request.Form["confirm_value"];
            if (totciffob == totinv)
            {
                lblerror.Visible = false;

            }
            else
            {


                if (confirmValue == "Yes")
                {

                }

            }








            if (GridError.DataSource != null)
            {
                GridError.Visible = true;
                POPUPERR.Show();
                POPUPERR.X = 400;
                POPUPERR.Y = 100;
            }
            else
            {

                if (chkstatus == "AMEND")
                {
                    if (ErrorDes == "")
                    {
                        POPUPERR.Hide();
                        Updatenew();
                        amendinsert();
                        Response.Redirect("InpaymentList.aspx");
                    }
                    else
                    {
                        POPUPERR.Show();
                        POPUPERR.X = 400;
                        POPUPERR.Y = 100;
                    }

                }

                else if (chkstatus == "CANCEL")
                {
                    Updatenew();
                    Cancelinsert();
                    Response.Redirect("InpaymentList.aspx");
                }
                else if (chkstatus == "REFUND")
                {
                    Updatenew();
                    Refudinsert();
                    Response.Redirect("InpaymentList.aspx");
                }
                else
                {
                    if (ErrorDes == "")
                    {

                        if (DrpDecType.SelectedItem.ToString() == "BKT : Blanket")
                        {
                            Id = Convert.ToInt16(Session["Id"].ToString());
                            if (Id != 0)
                            {
                                Updatenew();
                                Response.Redirect("InpaymentList.aspx");
                                Session["Edit"] = false;
                                // eid = 0;
                            }

                            else
                            {
                                string justdate = DateTime.Now.ToString("yyyyMMdd");
                                int chkCode = 0;
                                string Code = "";
                                string qry11 = "SELECT PermitId FROM InHeaderTbl where PermitId='" + txt_code.Text + "' and MessageType='IPTDEC' and  LEFT(MSGId,8) ='" + justdate + "'";
                                obj.dr = obj.ret_dr(qry11);
                                while (obj.dr.Read())
                                {
                                    Code = obj.dr[0].ToString();
                                }
                                if (Code == "")
                                {
                                    string License = TxtLicense1.Text + '-' + TxtLicense2.Text + '-' + TxtLicense3.Text + '-' + TxtLicense4.Text + '-' + TxtLicense5.Text;
                                    string Recipient = TxtRECPT1.Text + '-' + TxtRECPT2.Text + '-' + TxtRECPT3.Text;


                                    string Touch_user = Session["UserId"].ToString();
                                    DateTime ArrivalDate = Convert.ToDateTime(null);
                                    if (TxtArrivalDate1.Text == "")
                                    {
                                        var date = "01/01/1900";
                                        //var date = DateTime.Now.ToString("dd/MM/yyyy");
                                        var manDate = DateTime.ParseExact(date, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                                        ArrivalDate = Convert.ToDateTime(manDate);
                                    }
                                    else
                                    {
                                        var InvoiceDate1 = DateTime.ParseExact(TxtArrivalDate1.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                                        ArrivalDate = Convert.ToDateTime(InvoiceDate1);
                                    }

                                    //var ArrivalDate = DateTime.Parse(this.TxtArrivalDate1.Text, new CultureInfo("en-US", true));

                                    DateTime BlanketDate = Convert.ToDateTime(null);
                                    if (BlankDate1.Text == "")
                                    {
                                        var date = "01/01/1900";
                                        //var date = DateTime.Now.ToString("dd/MM/yyyy");
                                        var manDate = DateTime.ParseExact(date, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                                        BlanketDate = Convert.ToDateTime(manDate);
                                    }
                                    else
                                    {
                                        var InvoiceDate1 = DateTime.ParseExact(BlankDate1.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                                        BlanketDate = Convert.ToDateTime(InvoiceDate1);
                                    }
                                    JobNO();

                                    refid();
                                    //Count Permit
                                    string TouchDate = DateTime.Now.ToString("yyyy/MM/dd");
                                    string CopyMsg = "";
                                    string Mco = "SELECT MsgId FROM PermitCount where MsgId='" + MsgNO + "' and TouchTime='" + TouchDate + "'";
                                    obj.dr = obj.ret_dr(Mco);
                                    while (obj.dr.Read())
                                    {
                                        CopyMsg = obj.dr["MsgId"].ToString();
                                    }
                                    if (CopyMsg == "")
                                    {
                                        MSGNO();

                                    }
                                    else
                                    {
                                        string PerCount = ("INSERT INTO [dbo].[PermitCount] ([PermitId],[MessageType],[AccountId],[MsgId],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Session["AccountId"].ToString() + "','" + MsgNO + "','" + Touch_user + "','" + TouchDate + "')");
                                        obj.exec(PerCount);
                                        obj.closecon();
                                        MSGNO();
                                    }

                                    string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                //string ad = Convert.ToDateTime(ArrivalDate).ToString("yyyy-MM-dd HH:mm:ss");
                                //string bd = Convert.ToDateTime(BlanketDate).ToString("yyyy-MM-dd HH:mm:ss");
                                Save:
                                    string StrQuery = (" INSERT INTO [dbo].[InHeaderTbl] ([Refid],[JobId],[MSGId],[PermitId],[TradeNetMailboxID],[MessageType],[DeclarationType],[PreviousPermit],[CargoPackType],[InwardTransportMode],[BGIndicator],[SupplyIndicator],[ReferenceDocuments],[License],[Recipient],[DeclarantCompanyCode],[ImporterCompanyCode],[InwardCarrierAgentCode],[FreightForwarderCode],[ClaimantPartyCode],HBL,[ArrivalDate],[LoadingPortCode],[VoyageNumber],[VesselName],[OceanBillofLadingNo],[ConveyanceRefNo],[TransportId],[FlightNO],[AircraftRegNo],[MasterAirwayBill],[ReleaseLocation],ReleaseLocName,[RecepitLocation],[RecepitLocName],[TotalOuterPack],[TotalOuterPackUOM],[TotalGrossWeight],[TotalGrossWeightUOM],[GrossReference],[BlanketStartDate],[TradeRemarks],[InternalRemarks],[CustomerRemarks],[Status],[prmtStatus],[TouchUser],[TouchTime],[DeclareIndicator],[NumberOfItems],[TotalCIFFOBValue],[TotalGSTTaxAmt],[TotalExDutyAmt],[TotalCusDutyAmt],[TotalODutyAmt],[TotalAmtPay],[Cnb],Customers) Values ('" + refno + "','" + JobNo + "','" + MsgNO + "','" + txt_code.Text + "','" + TxtTradeMailID.Text + "','" + TxtMsgType.Text + "','" + DrpDecType.SelectedItem.ToString() + "','" + TxtPrevPerNO.Text + "','" + DrpCargoPackType.SelectedItem.ToString() + "','" + DrpInwardtrasMode.SelectedItem.ToString() + "','" + DrpBGIndicator.SelectedItem.ToString() + "','" + ChkSupplyIndicator.Checked.ToString().ToLower() + "','" + ChkRefDoc.Checked.ToString().ToLower() + "','" + License + "','" + Recipient + "','" + TxtDecCompCode.Text + "','" + TxtImpCode.Text + "','" + InwardCode.Text + "','" + FrieghtCode.Text + "','" + ClaimantName.Text + "','" + txthBlCargo.Text + "','" + Convert.ToDateTime(ArrivalDate).ToString("yyyy/MM/dd") + "','" + TxtLoadShort.Text + "','" + TxtVoyageno.Text + "','" + TxtVesselName.Text + "','" + TxtOceanBill.Text + "','" + TxtConRefNo.Text + "','" + TxtTrnsID.Text + "','" + txtflight.Text + "','" + txtaircraft.Text + "','" + txtwaybill.Text + "','" + txtreLoctn.Text + "','" + txtrelocDeta.Text + "','" + txtrecloctn.Text + "','" + txtrecloctndet.Text + "','" + TxttotalOuterPack.Text + "','" + DrptotalOuterPack.SelectedItem.ToString() + "','" + TxtTotalGrossWeight.Text + "','" + DrpTotalGrossWeight.SelectedItem.ToString() + "','" + TxtGrossReference.Text + "','" + Convert.ToDateTime(BlanketDate).ToString("yyyy/MM/dd") + "','" + txttrdremrk.Text + "','" + txtintremrk.Text + "','" + txtcusRemrk.Text + "','NEW','NEW','" + Touch_user + "','" + strTime + "','" + chkDeclareInd.Checked.ToString().ToLower() + "','" + txtnoofitm.Text + "','" + txtfobval.Text + "','" + txttotgstAmt.Text + "','" + txttotexAmt.Text + "','" + txtcusdutyAmt.Text + "','" + txtothtaxAmt.Text + "','" + txtAmtPayble.Text + "','" + chkcnb.Checked.ToString() + "','" + DrpCustomers.SelectedItem.Text + "')");
                                    // string StrQuery = (" INSERT INTO [dbo].[InHeaderTbl] ([JobId],[MSGId],[PermitId],[TradeNetMailboxID],[MessageType],[DeclarationType],[CargoPackType],[InwardTransportMode],[BGIndicator],[SupplyIndicator],[ReferenceDocuments],[License],[Recipient],[DeclarantCompanyCode],[ImporterCompanyCode],[InwardCarrierAgentCode],[FreightForwarderCode],[ClaimantPartyCode],[ArrivalDate],[LoadingPortCode],[VoyageNumber],[VesselName],[OceanBillofLadingNo],[ConveyanceRefNo],[TransportId],[FlightNO],[AircraftRegNo],[MasterAirwayBill],[ReleaseLocation],[RecepitLocation],[TotalOuterPack],[TotalOuterPackUOM],[TotalGrossWeight],[TotalGrossWeightUOM],[GrossReference],[BlanketStartDate],[Status],[TouchUser],[TouchTime]) Values ('" + JobNo + "','" + MsgNO + "','" + txt_code.Text + "','" + TxtTradeMailID.Text + "','" + TxtMsgType.Text + "','" + DrpDecType.SelectedItem.ToString() + "','" + DrpCargoPackType.SelectedItem.ToString() + "','" + DrpInwardtrasMode.SelectedItem.ToString() + "','" + DrpBGIndicator.SelectedItem.ToString() + "','" + ChkSupplyIndicator.Checked.ToString() + "','" + ChkRefDoc.Checked.ToString() + "','" + License + "','" + Recipient + "','" + TxtDecCompCode.Text + "','" + TxtImpCode.Text + "','" + InwardCode.Text + "','" + FrieghtCode.Text + "','" + ClaimantName.Text + "','" + ArrivalDate + "','" + TxtLoadShort.Text + "','" + TxtVoyageno.Text + "','" + TxtVesselName.Text + "','" + TxtOceanBill.Text + "','" + TxtConRefNo.Text + "','" + TxtTrnsID.Text + "','" + txtflight.Text + "','" + txtaircraft.Text + "','" + txtwaybill.Text + "','" + txtreLoctn.Text + "','" + txtrecloctn.Text + "','" + TxttotalOuterPack.Text + "','" + DrptotalOuterPack.SelectedItem.ToString() + "','" + TxtTotalGrossWeight.Text + "','" + DrpTotalGrossWeight.SelectedItem.ToString() + "','" + TxtGrossReference.Text + "','" + BlanketDate + "','DRF','" + Touch_user + "','" + strTime + "')");
                                    chkCode = obj.exec(StrQuery);
                                    if (chkCode == -2146232060)
                                    {
                                        PermitNO();
                                        goto Save;
                                    }






                                    //Clear Temp Data
                                    string tempdel = ("delete from inpaymenttemp where PermitId='" + txt_code.Text + "' and TouchUser='" + Touch_user + "' ");
                                    obj.exec(tempdel);

                                    //Count Permit
                                    //string TouchDate = DateTime.Now.ToString("yyyy/MM/dd");
                                    //string PerCount = ("INSERT INTO [dbo].[PermitCount] ([PermitId],[MessageType],[AccountId],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Session["AccountId"].ToString() + "','" + Touch_user + "','" + TouchDate + "')");
                                    //obj.exec(PerCount);
                                    //obj.closecon();
                                    int i = 1;
                                    foreach (GridViewRow g1 in ContarinerGrid.Rows)
                                    {
                                        string ContainerNo = (g1.FindControl("txt1") as TextBox).Text;
                                        string ContainerSize = (g1.FindControl("DrpType") as DropDownList).SelectedItem.ToString();
                                        string ContainerWeight = (g1.FindControl("txt2") as TextBox).Text;
                                        string Containerseal = (g1.FindControl("txt3") as TextBox).Text;

                                        if (ContainerNo != "" && ContainerSize != "" && ContainerWeight != "" && Containerseal != null)
                                        {
                                            string StrQuery1 = ("INSERT INTO [dbo].[ContainerDtl] ([PermitId],[RowNo],[ContainerNo],[Size],[Weight],[SealNo],[MessageType],[TouchUser],[TouchTime]) VALUES ('" + txt_code.Text + "','" + i + "','" + ContainerNo + "','" + ContainerSize + "','" + ContainerWeight + "','" + Containerseal + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "')");
                                            obj.exec(StrQuery1);
                                            obj.closecon();
                                        }
                                        i++;
                                    }

                                    //CPC
                                    int a = 1;
                                    foreach (GridViewRow g1 in AEOGrid.Rows)
                                    {
                                        string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;

                                        string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                                        string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;


                                        if (ProcessingCode1 != "")
                                        {
                                            string StrQuery1 = ("INSERT INTO [dbo].[CPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + a + "','AEO','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                                            obj.exec(StrQuery1);
                                            obj.closecon();
                                        }
                                        a++;
                                    }


                                    int b = 1;
                                    foreach (GridViewRow g1 in CWCGrid.Rows)
                                    {
                                        string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;

                                        string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                                        string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                                        if (ProcessingCode1 != "")
                                        {
                                            string StrQuery1 = ("INSERT INTO [dbo].[CPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + b + "','CWC','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                                            obj.exec(StrQuery1);
                                            obj.closecon();
                                        }
                                        b++;
                                    }

                                    int c = 1;
                                    foreach (GridViewRow g1 in SeaGrid.Rows)
                                    {
                                        string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;
                                        string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                                        string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                                        if (ProcessingCode1 != "")
                                        {
                                            string StrQuery1 = ("INSERT INTO [dbo].[InNonCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + c + "','SEASTORE','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                                            obj.exec(StrQuery1);
                                            obj.closecon();
                                        }
                                        b++;
                                    }

                                    int d = 1;
                                    foreach (GridViewRow g1 in SchemeGrid.Rows)
                                    {
                                        string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;
                                        string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                                        string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                                        if (ProcessingCode1 != "")
                                        {
                                            string StrQuery1 = ("INSERT INTO [dbo].[InNonCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + d + "','SCHEME','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                                            obj.exec(StrQuery1);
                                            obj.closecon();
                                        }
                                        d++;
                                    }

                                    int f = 1;
                                    foreach (GridViewRow g1 in StsGrid.Rows)
                                    {
                                        string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;
                                        string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                                        string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                                        if (ProcessingCode1 != "")
                                        {
                                            string StrQuery1 = ("INSERT INTO [dbo].[InNonCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + f + "','STS','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                                            obj.exec(StrQuery1);
                                            obj.closecon();
                                        }
                                        f++;
                                    }

                                    int g = 1;
                                    foreach (GridViewRow g1 in StscwcGrid.Rows)
                                    {
                                        string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;
                                        string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                                        string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                                        if (ProcessingCode1 != "")
                                        {
                                            string StrQuery1 = ("INSERT INTO [dbo].[InNonCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + g + "','STSANDCWC','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                                            obj.exec(StrQuery1);
                                            obj.closecon();
                                        }
                                        g++;
                                    }

                                    int go = 1;
                                    foreach (GridViewRow g1 in IcGrid.Rows)
                                    {
                                        string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;
                                        string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                                        string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                                        if (ProcessingCode1 != "")
                                        {
                                            string StrQuery1 = ("INSERT INTO [dbo].[InNonCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + go + "','IC','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                                            obj.exec(StrQuery1);
                                            obj.closecon();
                                        }
                                        go++;
                                    }

                                    Response.Redirect("InpaymentList.aspx");

                                }
                                else
                                {
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Permit Code '" + txt_code.Text + "' Already Exist..');", true);
                                    //  Response.Write("The Importer Code Already Exist..");

                                }
                                //Itemclear();
                                //InvoiceClr();

                            }
                        }
                        else
                        {



                            //if (TextMode.Text == "1 : Sea" && TextMode.Text == "4 : Air")
                            //{

                            //    if (string.IsNullOrWhiteSpace(InwardCRUEI.Text))
                            //    {
                            //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Inward Carrier Agent CRUEI Number Is Empty');", true);
                            //        return;
                            //    }
                            //    else if (string.IsNullOrWhiteSpace(InwardName.Text))
                            //    {
                            //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Inward Carrier Agent Name Is Empty');", true);
                            //        return;
                            //    }

                            //}
                            //else
                            //{
                            Id = Convert.ToInt32(Session["Id"].ToString());
                            if (Id != 0)
                            {
                                Updatenew();
                                Response.Redirect("InpaymentList.aspx");
                                Session["Edit"] = false;
                                // eid = 0;
                            }

                            else
                            {
                                int chkCode = 0;
                                string Code = "";
                                string qry11 = "SELECT PermitId FROM InHeaderTbl where PermitId='" + txt_code.Text + "' and MessageType='IPTDEC'";
                                obj.dr = obj.ret_dr(qry11);
                                while (obj.dr.Read())
                                {
                                    Code = obj.dr[0].ToString();
                                }
                                if (Code == "")
                                {
                                    string License = TxtLicense1.Text + '-' + TxtLicense2.Text + '-' + TxtLicense3.Text + '-' + TxtLicense4.Text + '-' + TxtLicense5.Text;
                                    string Recipient = TxtRECPT1.Text + '-' + TxtRECPT2.Text + '-' + TxtRECPT3.Text;


                                    string Touch_user = Session["UserId"].ToString();
                                    DateTime ArrivalDate = Convert.ToDateTime(null);
                                    if (TxtArrivalDate1.Text == "")
                                    {
                                        var date = "01/01/1900";
                                        //var date = DateTime.Now.ToString("dd/MM/yyyy");
                                        var manDate = DateTime.ParseExact(date, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                                        ArrivalDate = Convert.ToDateTime(manDate);
                                    }
                                    else
                                    {
                                        var InvoiceDate1 = DateTime.ParseExact(TxtArrivalDate1.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                                        ArrivalDate = Convert.ToDateTime(InvoiceDate1);
                                    }

                                    //var ArrivalDate = DateTime.Parse(this.TxtArrivalDate1.Text, new CultureInfo("en-US", true));

                                    DateTime BlanketDate = Convert.ToDateTime(null);
                                    if (BlankDate1.Text == "")
                                    {
                                        var date = "01/01/1900";
                                        //var date = DateTime.Now.ToString("dd/MM/yyyy");
                                        var manDate = DateTime.ParseExact(date, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                                        BlanketDate = Convert.ToDateTime(manDate);
                                    }
                                    else
                                    {
                                        var InvoiceDate1 = DateTime.ParseExact(BlankDate1.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                                        BlanketDate = Convert.ToDateTime(InvoiceDate1);
                                    }
                                    JobNO();

                                    refid();
                                    //Count Permit
                                    string TouchDate = DateTime.Now.ToString("yyyy/MM/dd");
                                    string CopyMsg = "";
                                    string Mco = "SELECT MsgId FROM PermitCount where MsgId='" + MsgNO + "' and TouchTime='" + TouchDate + "'";
                                    obj.dr = obj.ret_dr(Mco);
                                    while (obj.dr.Read())
                                    {
                                        CopyMsg = obj.dr["MsgId"].ToString();
                                    }
                                    if (CopyMsg == "")
                                    {
                                        MSGNO();

                                    }
                                    else
                                    {
                                        string PerCount = ("INSERT INTO [dbo].[PermitCount] ([PermitId],[MessageType],[AccountId],[MsgId],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Session["AccountId"].ToString() + "','" + MsgNO + "','" + Touch_user + "','" + TouchDate + "')");
                                        obj.exec(PerCount);
                                        obj.closecon();
                                        MSGNO();
                                    }



                                    string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                //string ad = Convert.ToDateTime(ArrivalDate).ToString("yyyy-MM-dd HH:mm:ss");
                                //string bd = Convert.ToDateTime(BlanketDate).ToString("yyyy-MM-dd HH:mm:ss");
                                Save:
                                    string StrQuery = (" INSERT INTO [dbo].[InHeaderTbl] ([Refid],[JobId],[MSGId],[PermitId],[TradeNetMailboxID],[MessageType],[DeclarationType],[PreviousPermit],[CargoPackType],[InwardTransportMode],[BGIndicator],[SupplyIndicator],[ReferenceDocuments],[License],[Recipient],[DeclarantCompanyCode],[ImporterCompanyCode],[InwardCarrierAgentCode],[FreightForwarderCode],[ClaimantPartyCode],HBL,[ArrivalDate],[LoadingPortCode],[VoyageNumber],[VesselName],[OceanBillofLadingNo],[ConveyanceRefNo],[TransportId],[FlightNO],[AircraftRegNo],[MasterAirwayBill],[ReleaseLocation],ReleaseLocName,[RecepitLocation],[RecepitLocName],[TotalOuterPack],[TotalOuterPackUOM],[TotalGrossWeight],[TotalGrossWeightUOM],[GrossReference],[BlanketStartDate],[TradeRemarks],[InternalRemarks],[CustomerRemarks],[Status],[prmtStatus],[TouchUser],[TouchTime],[DeclareIndicator],[NumberOfItems],[TotalCIFFOBValue],[TotalGSTTaxAmt],[TotalExDutyAmt],[TotalCusDutyAmt],[TotalODutyAmt],[TotalAmtPay],Cnb,Customers) Values ('" + refno + "','" + JobNo + "','" + MsgNO + "','" + txt_code.Text + "','" + TxtTradeMailID.Text + "','" + TxtMsgType.Text + "','" + DrpDecType.SelectedItem.ToString() + "','" + TxtPrevPerNO.Text + "','" + DrpCargoPackType.SelectedItem.ToString() + "','" + DrpInwardtrasMode.SelectedItem.ToString() + "','" + DrpBGIndicator.SelectedItem.ToString() + "','" + ChkSupplyIndicator.Checked.ToString().ToLower() + "','" + ChkRefDoc.Checked.ToString().ToLower() + "','" + License + "','" + Recipient + "','" + TxtDecCompCode.Text + "','" + TxtImpCode.Text + "','" + InwardCode.Text + "','" + FrieghtCode.Text + "','" + ClaimantName.Text + "','" + txthBlCargo.Text + "','" + Convert.ToDateTime(ArrivalDate).ToString("yyyy/MM/dd") + "','" + TxtLoadShort.Text + "','" + TxtVoyageno.Text + "','" + TxtVesselName.Text + "','" + TxtOceanBill.Text + "','" + TxtConRefNo.Text + "','" + TxtTrnsID.Text + "','" + txtflight.Text + "','" + txtaircraft.Text + "','" + txtwaybill.Text + "','" + txtreLoctn.Text + "','" + txtrelocDeta.Text + "','" + txtrecloctn.Text + "','" + txtrecloctndet.Text + "','" + TxttotalOuterPack.Text + "','" + DrptotalOuterPack.SelectedItem.ToString() + "','" + TxtTotalGrossWeight.Text + "','" + DrpTotalGrossWeight.SelectedItem.ToString() + "','" + TxtGrossReference.Text + "','" + Convert.ToDateTime(BlanketDate).ToString("yyyy/MM/dd") + "','" + txttrdremrk.Text + "','" + txtintremrk.Text + "','" + txtcusRemrk.Text + "','NEW','NEW','" + Touch_user + "','" + strTime + "','" + chkDeclareInd.Checked.ToString().ToLower() + "','" + txtnoofitm.Text + "','" + txtfobval.Text + "','" + txttotgstAmt.Text + "','" + txttotexAmt.Text + "','" + txtcusdutyAmt.Text + "','" + txtothtaxAmt.Text + "','" + txtAmtPayble.Text + "','" + chkcnb.Checked.ToString() + "','" + DrpCustomers.SelectedItem.Text + "')");
                                    // string StrQuery = (" INSERT INTO [dbo].[InHeaderTbl] ([JobId],[MSGId],[PermitId],[TradeNetMailboxID],[MessageType],[DeclarationType],[CargoPackType],[InwardTransportMode],[BGIndicator],[SupplyIndicator],[ReferenceDocuments],[License],[Recipient],[DeclarantCompanyCode],[ImporterCompanyCode],[InwardCarrierAgentCode],[FreightForwarderCode],[ClaimantPartyCode],[ArrivalDate],[LoadingPortCode],[VoyageNumber],[VesselName],[OceanBillofLadingNo],[ConveyanceRefNo],[TransportId],[FlightNO],[AircraftRegNo],[MasterAirwayBill],[ReleaseLocation],[RecepitLocation],[TotalOuterPack],[TotalOuterPackUOM],[TotalGrossWeight],[TotalGrossWeightUOM],[GrossReference],[BlanketStartDate],[Status],[TouchUser],[TouchTime]) Values ('" + JobNo + "','" + MsgNO + "','" + txt_code.Text + "','" + TxtTradeMailID.Text + "','" + TxtMsgType.Text + "','" + DrpDecType.SelectedItem.ToString() + "','" + DrpCargoPackType.SelectedItem.ToString() + "','" + DrpInwardtrasMode.SelectedItem.ToString() + "','" + DrpBGIndicator.SelectedItem.ToString() + "','" + ChkSupplyIndicator.Checked.ToString() + "','" + ChkRefDoc.Checked.ToString() + "','" + License + "','" + Recipient + "','" + TxtDecCompCode.Text + "','" + TxtImpCode.Text + "','" + InwardCode.Text + "','" + FrieghtCode.Text + "','" + ClaimantName.Text + "','" + ArrivalDate + "','" + TxtLoadShort.Text + "','" + TxtVoyageno.Text + "','" + TxtVesselName.Text + "','" + TxtOceanBill.Text + "','" + TxtConRefNo.Text + "','" + TxtTrnsID.Text + "','" + txtflight.Text + "','" + txtaircraft.Text + "','" + txtwaybill.Text + "','" + txtreLoctn.Text + "','" + txtrecloctn.Text + "','" + TxttotalOuterPack.Text + "','" + DrptotalOuterPack.SelectedItem.ToString() + "','" + TxtTotalGrossWeight.Text + "','" + DrpTotalGrossWeight.SelectedItem.ToString() + "','" + TxtGrossReference.Text + "','" + BlanketDate + "','DRF','" + Touch_user + "','" + strTime + "')");
                                    chkCode = obj.exec(StrQuery);
                                    if (chkCode == -2146232060)
                                    {
                                        JobNO();
                                        PermitNO();
                                        goto Save;
                                    }



                                    if (CopyMsg == "")
                                    {
                                        string PerCount1 = ("INSERT INTO [dbo].[PermitCount] ([PermitId],[MessageType],[AccountId],[MsgId],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Session["AccountId"].ToString() + "','" + MsgNO + "','" + Touch_user + "','" + TouchDate + "')");
                                        obj.exec(PerCount1);
                                        obj.closecon();
                                        // MSGNO();
                                    }




                                    //Clear Temp Data
                                    string tempdel = ("delete from inpaymenttemp where PermitId='" + txt_code.Text + "' and TouchUser='" + Touch_user + "' ");
                                    obj.exec(tempdel);

                                    ////Count Permit
                                    //string TouchDate = DateTime.Now.ToString("yyyy/MM/dd");
                                    //string PerCount = ("INSERT INTO [dbo].[PermitCount] ([PermitId],[MessageType],[AccountId],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Session["AccountId"].ToString() + "','" + Touch_user + "','" + TouchDate + "')");
                                    //obj.exec(PerCount);
                                    //obj.closecon();
                                    int i = 1;
                                    foreach (GridViewRow g1 in ContarinerGrid.Rows)
                                    {
                                        string ContainerNo = (g1.FindControl("txt1") as TextBox).Text;
                                        string ContainerSize = (g1.FindControl("DrpType") as DropDownList).SelectedItem.ToString();
                                        string ContainerWeight = (g1.FindControl("txt2") as TextBox).Text;
                                        string Containerseal = (g1.FindControl("txt3") as TextBox).Text;

                                        if (ContainerNo != "" && ContainerSize != "" && ContainerWeight != "" && Containerseal != null)
                                        {
                                            string StrQuery1 = ("INSERT INTO [dbo].[ContainerDtl] ([PermitId],[RowNo],[ContainerNo],[Size],[Weight],[SealNo],[MessageType],[TouchUser],[TouchTime]) VALUES ('" + txt_code.Text + "','" + i + "','" + ContainerNo + "','" + ContainerSize + "','" + ContainerWeight + "','" + Containerseal + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "')");
                                            obj.exec(StrQuery1);
                                            obj.closecon();
                                        }
                                        i++;
                                    }

                                    //CPC
                                    int a = 1;
                                    foreach (GridViewRow g1 in AEOGrid.Rows)
                                    {
                                        string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;

                                        string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                                        string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;


                                        if (ProcessingCode1 != "")
                                        {
                                            string StrQuery1 = ("INSERT INTO [dbo].[CPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + a + "','AEO','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                                            obj.exec(StrQuery1);
                                            obj.closecon();
                                        }
                                        a++;
                                    }
                                    int b = 1;
                                    foreach (GridViewRow g1 in CWCGrid.Rows)
                                    {
                                        string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;

                                        string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                                        string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                                        if (ProcessingCode1 != "")
                                        {
                                            string StrQuery1 = ("INSERT INTO [dbo].[CPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + b + "','CWC','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                                            obj.exec(StrQuery1);
                                            obj.closecon();
                                        }
                                        b++;
                                    }

                                    int c = 1;
                                    foreach (GridViewRow g1 in SeaGrid.Rows)
                                    {
                                        string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;
                                        string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                                        string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                                        if (ProcessingCode1 != "")
                                        {
                                            string StrQuery1 = ("INSERT INTO [dbo].[InNonCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + c + "','SEASTORE','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                                            obj.exec(StrQuery1);
                                            obj.closecon();
                                        }
                                        b++;
                                    }

                                    int d = 1;
                                    foreach (GridViewRow g1 in SchemeGrid.Rows)
                                    {
                                        string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;
                                        string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                                        string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                                        if (ProcessingCode1 != "")
                                        {
                                            string StrQuery1 = ("INSERT INTO [dbo].[InNonCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + d + "','SCHEME','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                                            obj.exec(StrQuery1);
                                            obj.closecon();
                                        }
                                        d++;
                                    }

                                    int f = 1;
                                    foreach (GridViewRow g1 in StsGrid.Rows)
                                    {
                                        string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;
                                        string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                                        string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                                        if (ProcessingCode1 != "")
                                        {
                                            string StrQuery1 = ("INSERT INTO [dbo].[InNonCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + f + "','STS','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                                            obj.exec(StrQuery1);
                                            obj.closecon();
                                        }
                                        f++;
                                    }

                                    int g = 1;
                                    foreach (GridViewRow g1 in StscwcGrid.Rows)
                                    {
                                        string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;
                                        string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                                        string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                                        if (ProcessingCode1 != "")
                                        {
                                            string StrQuery1 = ("INSERT INTO [dbo].[InNonCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + g + "','STSANDCWC','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                                            obj.exec(StrQuery1);
                                            obj.closecon();
                                        }
                                        g++;
                                    }

                                    int go = 1;
                                    foreach (GridViewRow g1 in IcGrid.Rows)
                                    {
                                        string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;
                                        string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                                        string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                                        if (ProcessingCode1 != "")
                                        {
                                            string StrQuery1 = ("INSERT INTO [dbo].[InNonCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + go + "','IC','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                                            obj.exec(StrQuery1);
                                            obj.closecon();
                                        }
                                        go++;
                                    }

                                    Response.Redirect("InpaymentList.aspx");

                                }
                                else
                                {
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Permit Code '" + txt_code.Text + "' Already Exist..');", true);
                                    //  Response.Write("The Importer Code Already Exist..");

                                }
                                //Itemclear();
                                //InvoiceClr();

                            }

                        }
                        //}
                    }

                    else
                    {
                        POPUPERR.Show();
                        POPUPERR.X = 400;
                        POPUPERR.Y = 100;
                    }
                }
                //}
                //else
                //{
                //    lblerror.Text = "INVOICE AMOUNT AND ITEM AMOUNT NOT SAME";
                //    lblerror.Focus();
                //    //Response.Write("<script LANGUAGE='JavaScript' >alert('Invoice Amount and Item Amount Not Same')</script>");
                //}

                //}
            }


        }


        protected void btnnextsum_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[TabContainer1.ActiveTabIndex + 1];
            updatepanel1.Update();

        }

        protected void ImporterGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(ImporterGrid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void ImporterGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in ImporterGrid.Rows)
            {
                //if (row.RowIndex == ImporterGrid.SelectedIndex)
                //{
                //    row.ToolTip = string.Empty;
                //    String doctype, name, name1, cruei;
                //    doctype = row.Cells[0].Text;
                //    name = row.Cells[1].Text;
                //    name1 = row.Cells[2].Text;
                //    cruei = row.Cells[3].Text;
                //    TxtImpCode.Text = doctype;
                //    TxtImpCRUEI.Text = name;
                //    TxtImpName.Text = name1;
                //    TxtImpName1.Text = cruei;


                //}
            }
            updatepanel1.Update();
            UpdatePanel2.Update();
            updatepanel3.Update();
            upinparty.Update();
            InwardCode.Focus();
        }

        protected void ImporterGrid_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }

        protected void ImporterGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //  DECCOMPSearGRID.SelectedIndex = Convert.ToInt16(e.CommandArgument);
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = ImporterGrid.Rows[rowIndex];
                if (row != null)
                {
                    var lblCode1 = row.FindControl("lblCode") as Label;
                    var lblName1 = row.FindControl("lblName") as Label;
                    var lblName11 = row.FindControl("lblName1") as Label;
                    var cruei1 = row.FindControl("lblCRUEI") as Label;

                    if (lblCode1 != null && lblName1 != null && lblName11 != null && cruei1 != null)
                    {

                        //UpdatePanelDCS.Update();
                        //Get values
                        string requestor = lblCode1.Text;
                        string requestType = lblName1.Text;
                        string status = lblName11.Text;
                        string crueis = cruei1.Text;
                        TxtImpCode.Text = "";
                        TxtImpCRUEI.Text = "";
                        TxtImpName.Text = "";
                        TxtImpName1.Text = "";
                        TxtImpCode.Text = requestor;
                        TxtImpName.Text = requestType;
                        TxtImpName1.Text = status;
                        TxtImpCRUEI.Text = crueis;
                        lblimporterparty.Text = crueis + " - " + requestType + " " + status;

                        //IMPORTER PARTY
                        TxtImppartyCode.Text = "";
                        TxtImppartyCRUEI.Text = "";
                        TxtImppartyName.Text = "";
                        TxtImppartyName1.Text = "";

                        TxtImppartyCode.Text = requestor;
                        TxtImppartyCRUEI.Text = crueis;
                        TxtImppartyName.Text = requestType;
                        TxtImppartyName1.Text = status;


                        //  UpdatePanelDCS.Update();

                    }
                    // DECCOMPSearGRID.Visible = false;

                }
            }
            updatepanel1.Update();

            upimpgrid.Update();

        }

        protected void InwardGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //  DECCOMPSearGRID.SelectedIndex = Convert.ToInt16(e.CommandArgument);
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = InwardGrid.Rows[rowIndex];
                if (row != null)
                {
                    var lblCode1 = row.FindControl("lblCode") as Label;
                    var lblName1 = row.FindControl("lblName") as Label;
                    var lblName11 = row.FindControl("lblName1") as Label;
                    var cruei1 = row.FindControl("lblCRUEI") as Label;

                    if (lblCode1 != null && lblName1 != null && lblName11 != null && cruei1 != null)
                    {

                        //UpdatePanelDCS.Update();
                        //Get values
                        string requestor = lblCode1.Text;
                        string requestType = lblName1.Text;
                        string status = lblName11.Text;
                        string crueis = cruei1.Text;
                        InwardCode.Text = "";
                        InwardCRUEI.Text = "";
                        InwardName.Text = "";
                        InwardName1.Text = "";
                        InwardCode.Text = requestor;
                        InwardName.Text = requestType;
                        InwardName1.Text = status;
                        InwardCRUEI.Text = crueis;
                        //  UpdatePanelDCS.Update();

                    }
                    // DECCOMPSearGRID.Visible = false;

                }
            }

            updatepanel1.Update();
            UpdatePanelInwardSearch.Update();
          


        }

        protected void InwardGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(InwardGrid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void FrieghtGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //  DECCOMPSearGRID.SelectedIndex = Convert.ToInt16(e.CommandArgument);
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = FrieghtGrid.Rows[rowIndex];
                if (row != null)
                {
                    var lblCode1 = row.FindControl("lblCode") as Label;
                    var lblName1 = row.FindControl("lblName") as Label;
                    var lblName11 = row.FindControl("lblName1") as Label;
                    var cruei1 = row.FindControl("lblCRUEI") as Label;

                    if (lblCode1 != null && lblName1 != null && lblName11 != null && cruei1 != null)
                    {

                        //UpdatePanelDCS.Update();
                        //Get values
                        string requestor = lblCode1.Text;
                        string requestType = lblName1.Text;
                        string status = lblName11.Text;
                        string crueis = cruei1.Text;
                        FrieghtCode.Text = "";
                        FrieghtCRUEI.Text = "";
                        InwardName.Text = "";
                        InwardName1.Text = "";
                        FrieghtCode.Text = requestor;
                        FrieghtName.Text = requestType;
                        FrieghtName1.Text = status;
                        FrieghtCRUEI.Text = crueis;
                        //  UpdatePanelDCS.Update();

                    }
                    // DECCOMPSearGRID.Visible = false;

                }
            }
            updatepanel1.Update();
            upfreightgrid.Update();
            FrieghtCode.Focus();
        }

        protected void FrieghtGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(FrieghtGrid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void ClaimantGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //  DECCOMPSearGRID.SelectedIndex = Convert.ToInt16(e.CommandArgument);
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = ClaimantGrid.Rows[rowIndex];
                if (row != null)
                {
                    var code = row.FindControl("lblname") as Label;
                    var name = row.FindControl("lblName1") as Label;
                    var name1 = row.FindControl("lblName2") as Label;
                    var cruei = row.FindControl("lblCRUEI") as Label;
                    var cid = row.FindControl("lblCName1") as Label;
                    var cnamr = row.FindControl("lblCName") as Label;
               


                    if (code != null && name != null && name1 != null && cruei != null && cid != null && cnamr != null)
                    {

                        //UpdatePanelDCS.Update();
                        //Get values

                        ClaimantName.Text = "";
                        ClaimantName1.Text = "";
                        ClaimantName2.Text = "";
                        ClaimantCRUEI.Text = "";
                        ClaimantName1C.Text = "";
                        ClaimantNameC.Text = "";


                        ClaimantName.Text = code.Text;
                        ClaimantName1.Text = name.Text;
                        ClaimantName2.Text = name1.Text;
                        ClaimantCRUEI.Text = cruei.Text;
                        ClaimantName1C.Text = cid.Text;
                        ClaimantNameC.Text = cnamr.Text;
                        //  UpdatePanelDCS.Update();

                    }
                    // DECCOMPSearGRID.Visible = false;

                }
            }
            updatepanel1.Update();
            UpdatePanel2.Update();
            updatepanel3.Update();
            upinparty.Update();

        }

        protected void ClaimantGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(ClaimantGrid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void LoadingGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //  DECCOMPSearGRID.SelectedIndex = Convert.ToInt16(e.CommandArgument);
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = LoadingGrid.Rows[rowIndex];
                if (row != null)
                {
                    var lblCode1 = row.FindControl("lblCode") as Label;
                    var lblName1 = row.FindControl("lblName") as Label;
                    var lblName11 = row.FindControl("lblName1") as Label;


                    if (lblCode1 != null && lblName1 != null && lblName11 != null)
                    {

                        //UpdatePanelDCS.Update();
                        //Get values
                        string requestor = lblCode1.Text;
                        string requestType = lblName1.Text;
                        string status = lblName11.Text;


                        TxtLoadShort.Text = "";
                        TxtLoad.Text = "";
                        TxtLoadShort.Text = requestor;
                        TxtLoad.Text = requestType;

                        //  UpdatePanelDCS.Update();

                    }
                    // DECCOMPSearGRID.Visible = false;

                }
            }
            updatepanel1.Update();
            uploadingport.Update();
            btnpreviousparty.Focus();
        }

        protected void LoadingGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(LoadingGrid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer;hovercolour:red";
            }
        }

        protected void LocationGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //  DECCOMPSearGRID.SelectedIndex = Convert.ToInt16(e.CommandArgument);
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = LocationGrid.Rows[rowIndex];
                if (row != null)
                {
                    var lblCode1 = row.FindControl("lblCode") as Label;
                    var lblName1 = row.FindControl("lblName") as Label;
                    var lblName11 = row.FindControl("lblName1") as Label;


                    if (lblCode1 != null && lblName1 != null && lblName11 != null)
                    {

                        //UpdatePanelDCS.Update();
                        //Get values
                        string requestor = lblCode1.Text;
                        string requestType = lblName1.Text;
                        string status = lblName11.Text;


                        txtreLoctn.Text = "";
                        txtrelocDeta.Text = "";
                        txtreLoctn.Text = requestor;
                        txtrelocDeta.Text = status;

                        //  UpdatePanelDCS.Update();

                    }
                    // DECCOMPSearGRID.Visible = false;

                }
            }
            updatepanel1.Update();
            uprelloc.Update();
        }

        protected void LocationGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(LocationGrid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer;hovercolour:red";
            }
        }

        protected void ReceiptGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //  DECCOMPSearGRID.SelectedIndex = Convert.ToInt16(e.CommandArgument);
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = ReceiptGrid.Rows[rowIndex];
                if (row != null)
                {
                    var lblCode1 = row.FindControl("lblCode") as Label;
                    var lblName1 = row.FindControl("lblName") as Label;
                    var lblName11 = row.FindControl("lblName1") as Label;


                    if (lblCode1 != null && lblName1 != null && lblName11 != null)
                    {

                        //UpdatePanelDCS.Update();
                        //Get values
                        string requestor = lblCode1.Text;
                        string requestType = lblName1.Text;
                        string status = lblName11.Text;


                        txtrecloctn.Text = "";
                        txtrecloctndet.Text = "";
                        txtrecloctn.Text = requestor;
                        txtrecloctndet.Text = status;

                        //  UpdatePanelDCS.Update();

                    }
                    // DECCOMPSearGRID.Visible = false;

                }
            }
            updatepanel1.Update();
            UpdatePanel2.Update();
        }

        protected void ReceiptGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(ReceiptGrid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer;hovercolour:red";
            }
        }

        protected void SUPPLIERGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //  DECCOMPSearGRID.SelectedIndex = Convert.ToInt16(e.CommandArgument);
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = SUPPLIERGrid.Rows[rowIndex];
                if (row != null)
                {
                    var lblCode1 = row.FindControl("lblCode") as Label;
                    var lblName1 = row.FindControl("lblName") as Label;
                    var lblName11 = row.FindControl("lblName1") as Label;
                    var cruei1 = row.FindControl("lblCRUEI") as Label;


                    if (lblCode1 != null && lblName1 != null && lblName11 != null)
                    {

                        //UpdatePanelDCS.Update();
                        //Get values
                        string requestor = lblCode1.Text;
                        string requestType = lblName1.Text;
                        string status = lblName11.Text;
                        string crueis = cruei1.Text;


                        txtcodeinvq.Text = "";
                        txtcruei.Text = "";

                        txtName.Text = "";
                        txtName1.Text = "";

                        txtcodeinvq.Text = requestor;
                        txtcruei.Text = crueis;
                        txtName.Text = requestType;
                        txtName1.Text = status;
                        // txtrecloctndet.Text = status;

                        //  UpdatePanelDCS.Update();

                    }
                    // DECCOMPSearGRID.Visible = false;

                }
            }
            updatepanel1.Update();
            upinvimp.Update();
        }

        protected void SUPPLIERGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(SUPPLIERGrid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer;hovercolour:red";
            }
        }

        protected void ImportPartyGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //  DECCOMPSearGRID.SelectedIndex = Convert.ToInt16(e.CommandArgument);
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = ImportPartyGrid.Rows[rowIndex];
                if (row != null)
                {
                    var lblCode1 = row.FindControl("lblCode") as Label;
                    var lblName1 = row.FindControl("lblName") as Label;
                    var lblName11 = row.FindControl("lblName1") as Label;
                    var cruei1 = row.FindControl("lblCRUEI") as Label;


                    if (lblCode1 != null && lblName1 != null && lblName11 != null)
                    {

                        //UpdatePanelDCS.Update();
                        //Get values
                        string requestor = lblCode1.Text;
                        string requestType = lblName1.Text;
                        string status = lblName11.Text;
                        string crueis = cruei1.Text;


                        TxtImppartyCode.Text = "";
                        TxtImppartyCRUEI.Text = "";

                        TxtImppartyName.Text = "";
                        TxtImppartyName1.Text = "";

                        TxtImppartyCode.Text = requestor;
                        TxtImppartyCRUEI.Text = crueis;
                        TxtImppartyName.Text = requestType;
                        TxtImppartyName1.Text = status;
                        // txtrecloctndet.Text = status;

                        //  UpdatePanelDCS.Update();

                    }
                    // DECCOMPSearGRID.Visible = false;

                }
            }
            updatepanel1.Update();
            UpdatePanel2.Update();
        }

        protected void ImportPartyGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(ImportPartyGrid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer;hovercolour:red";
            }
        }

        protected void CountryGridItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(CountryGridItem, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer;hovercolour:red";
            }
        }

        protected void CountryGridItem_RowCommand(object sender, GridViewCommandEventArgs e)
        {



            if (e.CommandName == "Select")
            {
                //  DECCOMPSearGRID.SelectedIndex = Convert.ToInt16(e.CommandArgument);
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = CountryGridItem.Rows[rowIndex];
                if (row != null)
                {
                    var lblName = row.FindControl("lblName") as Label;
                    var lblName1 = row.FindControl("lblName1") as Label;
                    //var lblName11 = row.FindControl("lblName1") as Label;


                    if (lblName != null && lblName1 != null)
                    {

                        //UpdatePanelDCS.Update();
                        //Get values
                        string requestor = lblName.Text;
                        string requestType = lblName1.Text;
                        //string status = lblName11.Text;


                        TxtCountryItem.Text = "";
                        txtcname.Text = "";
                        TxtCountryItem.Text = requestor;
                        txtcname.Text = requestType;

                        //  UpdatePanelDCS.Update();

                    }
                    // DECCOMPSearGRID.Visible = false;

                }
            }
            updatepanel1.Update();
            UpdatePanel2.Update();
        }

        protected void imgDelete_Click1(object sender, EventArgs e)
        {
            updatepanel1.Update();
        }

        protected void AEOGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string item = e.Row.Cells[0].Text;
                foreach (LinkButton button in e.Row.Cells[3].Controls.OfType<LinkButton>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
                    }
                }
            }
        }

        protected void ProductCode1Grid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //  DECCOMPSearGRID.SelectedIndex = Convert.ToInt16(e.CommandArgument);
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = ProductCode1Grid.Rows[rowIndex];
                if (row != null)
                {

                    var lblName1 = row.FindControl("lblName") as Label;
                    var lblName11 = row.FindControl("lblName1") as Label;
                    var cruei1 = row.FindControl("lblUOM") as Label;

                    if (lblName1 != null && lblName11 != null && cruei1 != null)
                    {

                        //UpdatePanelDCS.Update();
                        //Get values

                        string requestType = lblName1.Text;
                        string status = lblName11.Text;
                        string crueis = cruei1.Text;
                        TxtProductCode1.Text = "";
                        TxtDecCompName.Text = "";
                        DrpP1.ClearSelection();


                        TxtProductCode1.Text = requestType;
                        DrpP1.Items.FindByText(crueis).Selected = true;
                        // HSQTYUOM.Items.FindByText(obj.dr["HSUOM"].ToString()).Selected = true;
                        //  UpdatePanelDCS.Update();

                    }
                    // DECCOMPSearGRID.Visible = false;

                }
            }
            updatepanel1.Update();
        }

        protected void ProductCode1Grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(ProductCode1Grid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void ProductCode2Grid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //  DECCOMPSearGRID.SelectedIndex = Convert.ToInt16(e.CommandArgument);
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = ProductCode2Grid.Rows[rowIndex];
                if (row != null)
                {

                    var lblName1 = row.FindControl("lblName") as Label;
                    var lblName11 = row.FindControl("lblName1") as Label;
                    var cruei1 = row.FindControl("lblUOM") as Label;

                    if (lblName1 != null && lblName11 != null && cruei1 != null)
                    {

                        //UpdatePanelDCS.Update();
                        //Get values

                        string requestType = lblName1.Text;
                        string status = lblName11.Text;
                        string crueis = cruei1.Text;
                        TxtProductCode2.Text = "";
                        TxtDecCompName.Text = "";
                        DrpP2.ClearSelection();


                        TxtProductCode2.Text = requestType;
                        DrpP2.Items.FindByText(crueis).Selected = true;
                        // HSQTYUOM.Items.FindByText(obj.dr["HSUOM"].ToString()).Selected = true;
                        //  UpdatePanelDCS.Update();

                    }
                    // DECCOMPSearGRID.Visible = false;

                }
            }
            upinitem.Update();

            updatepanel1.Update();
        }

        protected void ProductCode2Grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(ProductCode2Grid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void ddlpc2_SelectedIndexChanged(object sender, EventArgs e)
        {
            showSessionData();
        }

        protected void btnpc2_Click(object sender, EventArgs e)
        {
            TxtProQty2.Text = TxtHSQuantity.Text;
        }

        protected void ddlpc3_SelectedIndexChanged(object sender, EventArgs e)
        {
            showSessionData();
        }

        protected void ProductCode3Grid_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void ProductCode3Grid_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {


        }

        protected void ProductCode3Grid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //  DECCOMPSearGRID.SelectedIndex = Convert.ToInt16(e.CommandArgument);
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = ProductCode3Grid.Rows[rowIndex];
                if (row != null)
                {

                    var lblName1 = row.FindControl("lblName") as Label;
                    var lblName11 = row.FindControl("lblName1") as Label;
                    var cruei1 = row.FindControl("lblUOM") as Label;

                    if (lblName1 != null && lblName11 != null && cruei1 != null)
                    {

                        //UpdatePanelDCS.Update();
                        //Get values

                        string requestType = lblName1.Text;
                        string status = lblName11.Text;
                        string crueis = cruei1.Text;
                        TxtProductCode3.Text = "";
                        TxtDecCompName.Text = "";
                        DrpP3.ClearSelection();


                        TxtProductCode3.Text = requestType;
                        DrpP3.Items.FindByText(crueis).Selected = true;
                        // HSQTYUOM.Items.FindByText(obj.dr["HSUOM"].ToString()).Selected = true;
                        //  UpdatePanelDCS.Update();

                    }
                    // DECCOMPSearGRID.Visible = false;

                }
            }
            uppc3.Update();

            updatepanel1.Update();
        }

        protected void ProductCode3Grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(ProductCode3Grid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        //Product Code4
        private void BindProduct4()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Top 100 * FROM CASCProductCodes"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            ProductCode4Grid.DataSource = dt;
                            ProductCode4Grid.DataBind();
                        }
                    }
                }
            }
        }
        private void ProductCode4()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));
            dt.Columns.Add(new DataColumn("Column2", typeof(string)));
            dt.Columns.Add(new DataColumn("Column3", typeof(string)));
            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Column1"] = string.Empty;
            dr["Column2"] = string.Empty;
            dr["Column3"] = string.Empty;
            dt.Rows.Add(dr);
            ViewState["ProductCode4"] = dt;
            ProductCode4Grid1.DataSource = dt;
            ProductCode4Grid1.DataBind();

        }
        private void AddProductCode4Grid()
        {
            int rowIndex = 0;
            if (ViewState["ProductCode4"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["ProductCode4"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values
                        TextBox box1 = (TextBox)ProductCode4Grid1.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                        TextBox box2 = (TextBox)ProductCode4Grid1.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                        TextBox box3 = (TextBox)ProductCode4Grid1.Rows[rowIndex].Cells[3].FindControl("TextBox3");
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = i + 1;
                        dtCurrentTable.Rows[i - 1]["Column1"] = box1.Text;
                        dtCurrentTable.Rows[i - 1]["Column2"] = box2.Text;
                        dtCurrentTable.Rows[i - 1]["Column3"] = box3.Text;
                        rowIndex++;
                    }

                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["ProductCode4"] = dtCurrentTable;
                    ProductCode4Grid1.DataSource = dtCurrentTable;
                    ProductCode4Grid1.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            //Set Previous Data on Postbacks
            SetPreviousData4();

        }
        private void SetPreviousData4()
        {
            int rowIndex = 0;
            if (ViewState["ProductCode4"] != null)
            {
                DataTable dt = (DataTable)ViewState["ProductCode4"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox box1 = (TextBox)ProductCode4Grid1.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                        TextBox box2 = (TextBox)ProductCode4Grid1.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                        TextBox box3 = (TextBox)ProductCode4Grid1.Rows[rowIndex].Cells[3].FindControl("TextBox3");
                        box1.Text = dt.Rows[i]["Column1"].ToString();
                        box2.Text = dt.Rows[i]["Column2"].ToString();
                        box3.Text = dt.Rows[i]["Column3"].ToString();
                        rowIndex++;
                    }
                }
            }
        }



        public DataTable GetProductCodes4FromDataBase(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = ProductCode4Search.Text;

            string str3 = "SELECT * FROM CASCProductCodes where CASCCode Like '%" + ProductCode4Search.Text + "%' order by Id desc";
            obj.dr = obj.ret_dr(str3);
            if (obj.dr.HasRows)
            {
                ProductCode4Grid.DataSource = obj.dr;

            }
            else
            {
                //Empty DataTable to execute the “else-condition”  
                DataTable dt = new DataTable();
                ProductCode4Grid.DataSource = dt;
                ProductCode4Grid.DataBind();
            }
            SqlConnection con = new SqlConnection(sqlconn);
            SqlDataAdapter _objda = new SqlDataAdapter(str3, con);
            con.Close();
            _objda.Fill(_objdt);
            return _objdt;
        }
        protected void ProductCode4Search_TextChanged(object sender, EventArgs e)
        {
            DataTable _objdt = new DataTable();
            _objdt = GetProductCodes4FromDataBase(ProductCode4Search.Text);
            if (_objdt.Rows.Count > 0)
            {
                ProductCode4Grid.DataSource = _objdt;
                ProductCode4Grid.DataBind();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Product4();", true);
            }
        }

        protected void ProductCode4Grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ProductCode4Grid.PageIndex = e.NewPageIndex;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Product4();", true);
            BindProduct5();
        }

        protected void lnkProductCode4_Command(object sender, CommandEventArgs e)
        {
            var lb = (LinkButton)sender;
            var row = (GridViewRow)lb.NamingContainer;
            if (row != null)
            {

                var lblName1 = row.FindControl("lblName") as Label;
                var lblName11 = row.FindControl("lblName1") as Label;

                if (lblName1 != null && lblName11 != null)
                {
                    //Get values                   
                    string requestType = lblName1.Text;
                    string status = lblName11.Text;
                    TxtProductCode4.Text = "";

                    //TxtHSCode.Text = requestType;
                    TxtProductCode4.Text = requestType;
                }

            }
        }

        protected void TxtProductCode4_TextChanged(object sender, EventArgs e)
        {
            if (TxtProductCode4.Text != "")
            {
                string qry11 = "select [CASCCode] from CASCProductCodes where CASCCode='" + TxtProductCode4.Text + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    TxtProductCode4.Text = obj.dr[0].ToString();


                }
            }
        }

        protected void ProductCode4Add_Click(object sender, EventArgs e)
        {
            AddProductCode4Grid();
        }
        //Product Code5
        private void BindProduct5()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Top 100 * FROM CASCProductCodes"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            ProductCode5Grid.DataSource = dt;
                            ProductCode5Grid.DataBind();
                        }
                    }
                }
            }
        }
        private void ProductCode5()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));
            dt.Columns.Add(new DataColumn("Column2", typeof(string)));
            dt.Columns.Add(new DataColumn("Column3", typeof(string)));
            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Column1"] = string.Empty;
            dr["Column2"] = string.Empty;
            dr["Column3"] = string.Empty;
            dt.Rows.Add(dr);
            ViewState["ProductCode5"] = dt;
            ProductCode5Grid1.DataSource = dt;
            ProductCode5Grid1.DataBind();

        }

        private void AddProductCode5Grid()
        {
            int rowIndex = 0;
            if (ViewState["ProductCode5"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["ProductCode5"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values
                        TextBox box1 = (TextBox)ProductCode5Grid1.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                        TextBox box2 = (TextBox)ProductCode5Grid1.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                        TextBox box3 = (TextBox)ProductCode5Grid1.Rows[rowIndex].Cells[3].FindControl("TextBox3");
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = i + 1;
                        dtCurrentTable.Rows[i - 1]["Column1"] = box1.Text;
                        dtCurrentTable.Rows[i - 1]["Column2"] = box2.Text;
                        dtCurrentTable.Rows[i - 1]["Column3"] = box3.Text;
                        rowIndex++;
                    }

                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["ProductCode5"] = dtCurrentTable;
                    ProductCode5Grid1.DataSource = dtCurrentTable;
                    ProductCode5Grid1.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            //Set Previous Data on Postbacks
            SetPreviousData5();

        }
        private void SetPreviousData5()
        {
            int rowIndex = 0;
            if (ViewState["ProductCode5"] != null)
            {
                DataTable dt = (DataTable)ViewState["ProductCode5"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox box1 = (TextBox)ProductCode5Grid1.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                        TextBox box2 = (TextBox)ProductCode5Grid1.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                        TextBox box3 = (TextBox)ProductCode5Grid1.Rows[rowIndex].Cells[3].FindControl("TextBox3");
                        box1.Text = dt.Rows[i]["Column1"].ToString();
                        box2.Text = dt.Rows[i]["Column2"].ToString();
                        box3.Text = dt.Rows[i]["Column3"].ToString();
                        rowIndex++;
                    }
                }
            }
        }



        public DataTable GetProductCodes5FromDataBase(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = ProductCode5Search.Text;

            string str3 = "SELECT * FROM CASCProductCodes where CASCCode Like '%" + ProductCode5Search.Text + "%' order by Id desc";
            obj.dr = obj.ret_dr(str3);
            if (obj.dr.HasRows)
            {
                ProductCode5Grid.DataSource = obj.dr;

            }
            else
            {
                //Empty DataTable to execute the “else-condition”  
                DataTable dt = new DataTable();
                ProductCode5Grid.DataSource = dt;
                ProductCode5Grid.DataBind();
            }
            SqlConnection con = new SqlConnection(sqlconn);
            SqlDataAdapter _objda = new SqlDataAdapter(str3, con);
            con.Close();
            _objda.Fill(_objdt);
            return _objdt;
        }
        protected void ProductCode5Search_TextChanged(object sender, EventArgs e)
        {
            DataTable _objdt = new DataTable();
            _objdt = GetProductCodes5FromDataBase(ProductCode5Search.Text);
            if (_objdt.Rows.Count > 0)
            {
                ProductCode5Grid.DataSource = _objdt;
                ProductCode5Grid.DataBind();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Product5();", true);
            }
        }

        protected void ProductCode5Grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ProductCode5Grid.PageIndex = e.NewPageIndex;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Product5();", true);
            BindProduct5();
        }

        protected void lnkProductCode5_Command(object sender, CommandEventArgs e)
        {
            var lb = (LinkButton)sender;
            var row = (GridViewRow)lb.NamingContainer;
            if (row != null)
            {

                var lblName1 = row.FindControl("lblName") as Label;
                var lblName11 = row.FindControl("lblName1") as Label;

                if (lblName1 != null && lblName11 != null)
                {
                    //Get values                   
                    string requestType = lblName1.Text;
                    string status = lblName11.Text;
                    TxtProductCode5.Text = "";

                    //TxtHSCode.Text = requestType;
                    TxtProductCode5.Text = requestType;
                }

            }
        }

        protected void TxtProductCode5_TextChanged(object sender, EventArgs e)
        {
            if (TxtProductCode5.Text != "")
            {
                string qry11 = "select [CASCCode] from CASCProductCodes where CASCCode='" + TxtProductCode5.Text + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    TxtProductCode5.Text = obj.dr[0].ToString();


                }
            }
        }

        protected void ProductCode5Plus_Click(object sender, EventArgs e)
        {
            AddProductCode5Grid();
        }

        protected void ProductCode5Grid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //  DECCOMPSearGRID.SelectedIndex = Convert.ToInt16(e.CommandArgument);
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = ProductCode5Grid.Rows[rowIndex];
                if (row != null)
                {

                    var lblName1 = row.FindControl("lblName") as Label;
                    var lblName11 = row.FindControl("lblName1") as Label;
                    var cruei1 = row.FindControl("lblUOM") as Label;

                    if (lblName1 != null && lblName11 != null && cruei1 != null)
                    {

                        //UpdatePanelDCS.Update();
                        //Get values

                        string requestType = lblName1.Text;
                        string status = lblName11.Text;
                        string crueis = cruei1.Text;
                        TxtProductCode5.Text = "";
                        TxtDecCompName.Text = "";
                        DrpP5.ClearSelection();


                        TxtProductCode5.Text = requestType;
                        DrpP5.Items.FindByText(crueis).Selected = true;
                        // HSQTYUOM.Items.FindByText(obj.dr["HSUOM"].ToString()).Selected = true;
                        //  UpdatePanelDCS.Update();

                    }
                    // DECCOMPSearGRID.Visible = false;

                }
            }
            uppc3.Update();

            updatepanel1.Update();
        }

        protected void ProductCode5Grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(ProductCode5Grid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void ProductCode4Grid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //  DECCOMPSearGRID.SelectedIndex = Convert.ToInt16(e.CommandArgument);
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = ProductCode4Grid.Rows[rowIndex];
                if (row != null)
                {

                    var lblName1 = row.FindControl("lblName") as Label;
                    var lblName11 = row.FindControl("lblName1") as Label;
                    var cruei1 = row.FindControl("lblUOM") as Label;

                    if (lblName1 != null && lblName11 != null && cruei1 != null)
                    {

                        //UpdatePanelDCS.Update();
                        //Get values

                        string requestType = lblName1.Text;
                        string status = lblName11.Text;
                        string crueis = cruei1.Text;
                        TxtProductCode4.Text = "";
                        TxtDecCompName.Text = "";
                        DrpP4.ClearSelection();


                        TxtProductCode4.Text = requestType;
                        DrpP4.Items.FindByText(crueis).Selected = true;
                        // HSQTYUOM.Items.FindByText(obj.dr["HSUOM"].ToString()).Selected = true;
                        //  UpdatePanelDCS.Update();

                    }
                    // DECCOMPSearGRID.Visible = false;

                }
            }
            uppc3.Update();

            updatepanel1.Update();
        }

        protected void ProductCode4Grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(ProductCode4Grid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void ddlpc4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlpc5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtlsp_TextChanged(object sender, EventArgs e)
        {
            if (txtlsp.Text != "")
            {





                double T1, T2, T3, T4, T5, T6, T7, T8;
                bool A = double.TryParse(txtlsp.Text.Trim(), out T1);
                bool B = double.TryParse(TxtSumCustomsDuty.Text.Trim(), out T2);
                bool C = double.TryParse(TxtSumExciseDuty.Text.Trim(), out T3);
                bool D = double.TryParse(TxtOtherTaxableCharge.Text.Trim(), out T4);





                T4 = Convert.ToDouble(txtlsp.Text);
                T5 = Convert.ToDouble(TxtSumCustomsDuty.Text);
                T7 = Convert.ToDouble(TxtSumExciseDuty.Text);
                T8 = Convert.ToDouble(TxtOtherTaxableCharge.Text);
                T6 = ((T4 * 0.09) + (T5 * 0.09) + (T7 * 0.09) + (T8 * 0.09));

                TxtItemSumGST.Text = Math.Round(Convert.ToDecimal(T6.ToString()), 2).ToString();


                if (Math.Round(Convert.ToDecimal(T6.ToString()), 2) >= 10000)
                {
                    Lblmarquee.Text = "Total GST Amount greater than 10000";

                    txttotgstAmt.BorderColor = Color.Red;
                    updatepanel1.Update();
                }
                else
                {
                    Lblmarquee.Text = "";
                    updatepanel1.Update();
                }
                if (Math.Round(Convert.ToDecimal(T6.ToString()), 2) >= 10000)
                {
                    Lblmarquee.Text = "Total GST Amount greater than 10000";

                    txttotgstAmt.BorderColor = Color.Red;
                    updatepanel1.Update();
                }
                else
                {
                    Lblmarquee.Text = "";
                    updatepanel1.Update();
                }




                //bool D = double.TryParse(TxtCIFFOB.Text.Trim(), out T4);
                //bool E = double.TryParse(TxtSumExciseDuty.Text.Trim(), out T5);
                //if (D && E) 
                // = ((T4 * (7 / 100)) + (T5 * (7 / 100))).ToString() ;
            }
            upinitem.Update();
            ChkPackInfo.Focus();
        }

        protected void txtwaybill_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtwaybill.Text))
            {
                lbloblval.Text = txtwaybill.Text;
            }
            updatepanel1.Update();
            upinsummary.Update();
            txthBlCargo.Focus();
        }

        protected void TxtOPQty_TextChanged(object sender, EventArgs e)
        {
            double T1, T2, T3, T4, T5;
            bool A = double.TryParse(TxtOPQty.Text.Trim(), out T1);
            bool B = double.TryParse(TxtIPQty.Text.Trim(), out T2);
            bool C = double.TryParse(TxtINPQty.Text.Trim(), out T3);
            bool D = double.TryParse(TxtIMPQty.Text.Trim(), out T4);
            bool F = double.TryParse(TxtTotalDutiableQuantity.Text.Trim(), out T5);
            //   bool G = double.TryParse(TxtIMPQty.Text.Trim(), out T9);

            duticalc(T1, T2, T3, T4, T5);

            txtAlcoholPer_TextChanged(null, null);

            DRPOPQUOM.Focus();
        }

        protected void GridError_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridError.PageIndex = e.NewPageIndex;
            ReqValidatePageLoad();
            requriedInvoice();

        }

        protected void BtnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("InpaymentList.aspx");
        }

        protected void BtnPrintCIF_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            string qry11 = "select t2.Name,t2.CRUEI,t1.JobId,t1.MSGId,t1.TouchTime,t3.* from InHeaderTbl t1,Importer t2,InvoiceDtl t3 where  t1.ImporterCompanyCode=t2.Code and t1.PermitId=t3.PermitId  and  t1.PermitId='" + txt_code.Text + "'";
            obj.dr = obj.ret_dr(qry11);
            while (obj.dr.Read())
            {
                string FCCurrency = "";
                if (obj.dr["FCCurrency"].ToString() == "--Select--")
                {
                    FCCurrency = "";
                }
                else
                {
                    FCCurrency = obj.dr["FCCurrency"].ToString();
                }
                string ICCurrency = "";
                if (obj.dr["ICCurrency"].ToString() == "--Select--")
                {
                    ICCurrency = "";
                }
                else
                {
                    ICCurrency = obj.dr["ICCurrency"].ToString();
                }
                string OTCCurrency = "";
                if (obj.dr["OTCCurrency"].ToString() == "--Select--")
                {
                    OTCCurrency = "";
                }
                else
                {
                    OTCCurrency = obj.dr["OTCCurrency"].ToString();
                }



                //Dummy data for Invoice (Bill).
                string Line = "----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
                //  int orderNo = 2303;
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[7] {
                       new DataColumn("SNO",  typeof(string)),
                        new DataColumn("ITEM", typeof(string)),
                        new DataColumn("CURRENCY", typeof(string)),
                        new DataColumn("EXCHG. RATE", typeof(string)),
                        new DataColumn("PERC.",  typeof(string)),
                        new DataColumn("AMOUNT",  typeof(string)),
                     new DataColumn("AMOUNT (SGD)",  typeof(string))});
                dt.Rows.Add(1, "TOTAL INVOICE", "" + obj.dr["TICurrency"].ToString() + "", "" + obj.dr["TIExRate"].ToString() + "", "", "" + obj.dr["TIAmount"].ToString() + "", "" + obj.dr["TISAmount"].ToString() + "");
                dt.Rows.Add(2, "FREIGHT CHARGES", "" + FCCurrency + "", "" + obj.dr["FCExRate"].ToString() + "", "" + obj.dr["FCCharge"].ToString() + "", "" + obj.dr["FCAmount"].ToString() + "", "" + obj.dr["FCSAmount"].ToString() + "");
                dt.Rows.Add(3, "INSURANCE", "" + ICCurrency + "", "" + obj.dr["ICExRate"].ToString() + "", "" + obj.dr["ICCharge"].ToString() + "", "" + obj.dr["ICAmount"].ToString() + "", "" + obj.dr["ICSAmount"].ToString() + "");
                dt.Rows.Add(4, "OTHER CHARGES", "" + OTCCurrency + "", "" + obj.dr["OTCExRate"].ToString() + "", "" + obj.dr["OTCCharge"].ToString() + "", "" + obj.dr["OTCAmount"].ToString() + "", "" + obj.dr["OTCSAmount"].ToString() + "");
                dt.Rows.Add(5, "CUSTOMS VALUE", "", "", "", "", "" + obj.dr["CIFSUMAmount"].ToString() + "");
                dt.Rows.Add(6, "GST", "", "", "7.00", "", "" + obj.dr["GSTSUMAmount"].ToString() + "");
                using (StringWriter sw = new StringWriter())
                {
                    using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                    {

                        sb.Append("<font size='1'>");

                        if (obj.dr["SNo"].ToString() == "1")
                        {



                            sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
                            sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><b>CIF INFORMATION</b></td></tr>");
                            sb.Append("<tr><td colspan = '2'></td></tr>");
                            sb.Append("<tr><td><b>COMPANY NAME: </b>");
                            sb.Append(obj.dr["Name"].ToString());
                            sb.Append("</td><td align = 'right'><b>JOB NUMBER:  </b>");
                            sb.Append(obj.dr["JobId"].ToString());
                            sb.Append(" </td></tr>");
                            sb.Append("<tr><td><b>COMPANY UEN: </b>");
                            sb.Append(obj.dr["CRUEI"].ToString());
                            sb.Append("</td><td align = 'right'><b>JOB CREATED: </b>");
                            sb.Append(obj.dr["TouchTime"].ToString());
                            sb.Append(" </td></tr>");
                            sb.Append("<tr><td><b> </b>");
                            sb.Append("</td><td align = 'right'><b>MESSAGE ID:    </b>");
                            sb.Append(obj.dr["MsgId"].ToString());
                            sb.Append(" </td></tr>");
                            sb.Append("</table>");
                        }
                        sb.Append(Line);

                        sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
                        sb.Append("<tr><td colspan = '2'></td></tr>");
                        sb.Append("<tr><td><b>INVOICE NUMBER: </b>");
                        sb.Append(obj.dr["InvoiceNo"].ToString());
                        sb.Append("</td><td><b>  </b>");
                        string InvTerm = obj.dr["TermType"].ToString();
                        sb.Append(" </td></tr>");
                        sb.Append("<tr><td><b>INVOICE TERM: </b>");
                        sb.Append(InvTerm);
                        sb.Append("</td><td><b></b>");
                        sb.Append(" </td></tr>");
                        sb.Append("</table>");
                        sb.Append("<br>");
                        sb.Append("<br>");
                        //Generate Invoice (Bill) Items Grid.
                        sb.Append("<table width='100%' border='1'>");
                        sb.Append("<tr  align='center'>");
                        foreach (DataColumn column in dt.Columns)
                        {
                            sb.Append("<th>");
                            sb.Append(column.ColumnName);
                            sb.Append("</th>");
                        }
                        sb.Append("</tr>");
                        foreach (DataRow row in dt.Rows)
                        {
                            sb.Append("<tr align='center'>");
                            foreach (DataColumn column in dt.Columns)
                            {
                                sb.Append("<td>");
                                sb.Append(row[column]);
                                sb.Append("</td>");
                            }
                            sb.Append("</tr>");
                        }
                        sb.Append("</table>");

                        //sb.Append("<table style='width:100%'>");
                        //sb.Append("  <tr>");
                        //sb.Append(" <th></th> ");
                        //sb.Append("  <th></th>");
                        //sb.Append("  <th  align='left'>TOTAL GST</th>");
                        //sb.Append("  <th  align='right'>" + obj.dr["GSTSUMAmount"].ToString() + "</th>");
                        //sb.Append(" </tr>");
                        //sb.Append(" <tr >");
                        //sb.Append("  <td></td> ");
                        //sb.Append("  <td></td>");
                        //sb.Append("  <td align='left'>TOTAL EXCISE DUTY AMOUNT</td> ");
                        //sb.Append("  <td align='right'>0.00</td>");
                        //sb.Append(" </tr>");
                        //sb.Append(" <tr >");
                        //sb.Append(" <td></td> ");
                        //sb.Append(" <td></td>");
                        //sb.Append("  <td align='left'>TOTAL CUSTOMS DUTY AMOUNT</td> ");
                        //sb.Append("  <td align='right'>0.00</td>");
                        //sb.Append("  </tr>");
                        //sb.Append(" <tr >");
                        //sb.Append(" <td></td> ");
                        //sb.Append(" <td></td>");
                        //sb.Append("  <td align='left'>TOTAL OTHER TAX AMOUNT</td> ");
                        //sb.Append("  <td align='right'>0.00</td>");
                        //sb.Append("  </tr>");
                        //sb.Append(" <tr >");
                        //sb.Append(" <td></td> ");
                        //sb.Append(" <td></td>");
                        //sb.Append("  <td align='left'>TOTAL AMOUNT PAYABLE</td> ");
                        //sb.Append("  <td align='right'>0.00</td>");
                        //sb.Append("  </tr>");
                        //sb.Append("</table>");
                        sb.Append("</font>");


                        // innonpayment.Update();

                    }
                }
            }
            //Export HTML String as PDF.
            StringReader sr = new StringReader(sb.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=In-PrintGST.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
        }
        public void HeaderClr()
        {
            DrpDecType.ClearSelection();
            DrpDecType.Items.FindByText("--Select--").Selected = true;
            TxtPrevPerNO.Text = "";
            DrpCargoPackType.ClearSelection();
            DrpCargoPackType.Items.FindByText("--Select--").Selected = true;
            DrpInwardtrasMode.ClearSelection();
            DrpInwardtrasMode.Items.FindByText("--Select--").Selected = true;
            DrpBGIndicator.ClearSelection();
            DrpBGIndicator.Items.FindByText("--Select--").Selected = true;
            ChkOverrExgRate.Checked = false;
            ChkSupplyIndicator.Checked = false;
            ChkRefDoc.Checked = false;
            TxtLicense1.Text = "";
            TxtLicense2.Text = "";
            TxtLicense3.Text = "";
            TxtLicense4.Text = "";
            TxtLicense5.Text = "";
            DrpDocType.ClearSelection();
            DrpDocType.Items.FindByText("--Select--").Selected = true;
            TxtRECPT1.Text = "";
            TxtRECPT2.Text = "";
            TxtRECPT3.Text = "";

        }
        public void partyClr()
        {
            TxtDecCompCode.Text = "";
            TxtDecCompCRUEI.Text = "";
            TxtDecCompName.Text = "";
            TxtDecCompName1.Text = "";
            TxtImpCode.Text = "";
            TxtImpCRUEI.Text = "";
            TxtImpName.Text = "";
            TxtImpName1.Text = "";
            InwardCode.Text = "";
            InwardCRUEI.Text = "";
            InwardName.Text = "";
            InwardName1.Text = "";
            FrieghtCode.Text = "";
            FrieghtCRUEI.Text = "";
            FrieghtName.Text = "";
            FrieghtName1.Text = "";
            ClaimantName.Text = "";
            ClaimantNameC.Text = "";
            ClaimantName1.Text = "";
            ClaimantCRUEI.Text = "";
            ClaimantName1C.Text = "";

        }

        public void CargoClr()
        {
            TxtLoadShort.Text = "";
            TxtLoad.Text = "";
            txtflight.Text = "";
            txtaircraft.Text = "";
            txtwaybill.Text = "";
            TxtVoyageno.Text = "";
            TxtVesselName.Text = "";
            TxtOceanBill.Text = "";
            TxtConRefNo.Text = "";
            TxtTrnsID.Text = "";
            txthBlCargo.Text = "";
            TxtArrivalDate1.Text = "";
            txtreLoctn.Text = "";
            txtrelocDeta.Text = "";
            txtrecloctn.Text = "";
            txtrecloctndet.Text = "";
            BlankDate1.Text = "";
            TxttotalOuterPack.Text = "";
            DrptotalOuterPack.ClearSelection();
            DrptotalOuterPack.Items.FindByText("--Select--").Selected = true;
            TxtTotalGrossWeight.Text = "";
            DrpTotalGrossWeight.ClearSelection();
            DrpTotalGrossWeight.Items.FindByText("--Select--").Selected = true;
            TxtGrossReference.Text = "";

        }
        public void AmendClr()
        {
            txtamoundcount.Text = "";
            txtupdateindicator.Text = "";
            txtamendpermit.Text = "";
            txtreplacepermit.Text = "";
            txtdescreason.Text = "";
            ChkPermitvalEx.Checked = false;
            txtvalidity.Text = "";
            chkdec.Checked = false;

        }
        public void CancelClr()
        {
            txtupdateInd.Text = "";
            txtcanPermit.Text = "";
            txtcanrepPermit.Text = "";
            DrpReasonCancel.ClearSelection();
            DrpReasonCancel.Items.FindByText("--Select--").Selected = true;
            txtdesReason.Text = "";
            DrpDocumenttype.ClearSelection();
            DrpDocumenttype.Items.FindByText("--Select--").Selected = true;
        }

        public void RefundClr()
        {
            txtrenupdInd.Text = "";
            txtreundper.Text = "";
            txtrefundrepper.Text = "";

            DrpTypeRefund.ClearSelection();
            DrpTypeRefund.Items.FindByText("--Select--").Selected = true;
            DrpRefundReason.ClearSelection();
            DrpRefundReason.Items.FindByText("--Select--").Selected = true;

            txtrefudDes.Text = "";

            DrprefundDocType.ClearSelection();
            DrprefundDocType.Items.FindByText("--Select--").Selected = true;
            txtrefaddd1.Text = "";
            txtrefadd2.Text = "";
            txtrefadd3.Text = "";

        }

        protected void ContarinerGrid_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string item = e.Row.Cells[0].Text;
                foreach (Button button in e.Row.Cells[2].Controls.OfType<Button>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
                    }
                }
            }
        }

        protected void btnyes_Click(object sender, EventArgs e)
        {
            //OBLERR = "";
            //OBLERR = "YES";
            btnsavesum_Click(null, null);
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            //OBLERR = "";
            //OBLERR = "No";
            btnsavesum_Click(null, null);
        }

        protected void chk234_CheckedChanged(object sender, EventArgs e)
        {
            if (chk234.Checked == true)
            {
                ItemGSTRate.Enabled = true;
                ItemGSTUOM.Enabled = true;
                TxtItemSumGST.Enabled = true;
                TxtExciseDutyRate.Enabled = true;
                TxtExciseDutyUOM.Enabled = true;
                TxtSumExciseDuty.Enabled = true;
                TxtCustomsDutyRate.Enabled = true;
                TxtCustomsDutyUOM.Enabled = true;
                TxtSumCustomsDuty.Enabled = true;
                TxtOtherTaxRate.Enabled = true;
                TxtInsuranceCharges.Enabled = true;
                DrpOtherUOM.Enabled = true;
                TxtSumOtherTaxRate.Enabled = true;
            }
            else
            {
                ItemGSTRate.Enabled = false;
                ItemGSTUOM.Enabled = false;
                TxtItemSumGST.Enabled = false;
                TxtExciseDutyRate.Enabled = false;
                TxtExciseDutyUOM.Enabled = false;
                TxtSumExciseDuty.Enabled = false;
                TxtCustomsDutyRate.Enabled = false;
                TxtCustomsDutyUOM.Enabled = false;
                TxtSumCustomsDuty.Enabled = false;
                TxtOtherTaxRate.Enabled = false;
                TxtInsuranceCharges.Enabled = false;
                DrpOtherUOM.Enabled = false;
                TxtSumOtherTaxRate.Enabled = false;
            }
        }

        protected void AddItem_Click(object sender, EventArgs e)
        {
            if (RefundItem.Rows.Count <= 0)
            {
                SetInitialRowItemRef();
            }
            else
            {
                AddNewRowToGridcItemRef();
            }
        }

        protected void RefundItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            DataTable dt = ViewState["CurrentTableItem"] as DataTable;
            dt.Rows[index].Delete();
            ViewState["CurrentTableItem"] = dt;
        }

        protected void RefundItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string item = e.Row.Cells[0].Text;
                foreach (LinkButton button in e.Row.Cells[3].Controls.OfType<LinkButton>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
                    }
                }
            }
        }

        protected void ChkOverrExgRate_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkOverrExgRate.Checked == true)
            {
                lblInsuranceCharges.Enabled = true;
                LblFrieghtCharges.Enabled = true;
                lblOtherTaxableCharge.Enabled = true;
                LblTotalInvoice.Enabled = true;
            }
            else
            {
                lblInsuranceCharges.Enabled = false;
                LblFrieghtCharges.Enabled = false;
                lblOtherTaxableCharge.Enabled = false;
                LblTotalInvoice.Enabled = false;
            }
        }

        private void GetData()
        {

            ArrayList arr;

            if (ViewState["SelectedRecords"] != null)
            {
                arr = (ArrayList)ViewState["SelectedRecords"];
            }


            else
            {

                arr = new ArrayList();

                CheckBox chkAll = (CheckBox)AddItemGrid.HeaderRow.Cells[0].FindControl("chkAll");

                for (int i = 0; i < AddItemGrid.Rows.Count; i++)
                {

                    if (chkAll.Checked)
                    {

                        if (!arr.Contains(AddItemGrid.DataKeys[i].Value))
                        {

                            arr.Add(AddItemGrid.DataKeys[i].Value);

                        }

                    }

                    else
                    {

                        CheckBox chk = (CheckBox)AddItemGrid.Rows[i]

                                           .Cells[0].FindControl("chk");

                        if (chk.Checked)
                        {

                            if (!arr.Contains(AddItemGrid.DataKeys[i].Value))
                            {

                                arr.Add(AddItemGrid.DataKeys[i].Value);

                            }

                        }

                        else
                        {

                            if (arr.Contains(AddItemGrid.DataKeys[i].Value))
                            {

                                arr.Remove(AddItemGrid.DataKeys[i].Value);

                            }

                        }

                    }
                }
            }

            ViewState["SelectedRecords"] = arr;

        }

        private void SetData()
        {

            int currentCount = 0;

            CheckBox chkAll = (CheckBox)AddItemGrid.HeaderRow

                                    .Cells[0].FindControl("chkAll");

            chkAll.Checked = true;

            ArrayList arr = (ArrayList)ViewState["SelectedRecords"];

            for (int i = 0; i < AddItemGrid.Rows.Count; i++)
            {

                CheckBox chk = (CheckBox)AddItemGrid.Rows[i]

                                .Cells[0].FindControl("chk");

                if (chk != null)
                {

                    chk.Checked = arr.Contains(AddItemGrid.DataKeys[i].Value);

                    if (!chk.Checked)

                        chkAll.Checked = false;

                    else

                        currentCount++;

                }

            }

            hfCount.Value = (arr.Count - currentCount).ToString();

        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {

            int count = 0;

            SetData();

            AddItemGrid.AllowPaging = false;

            AddItemGrid.DataBind();

            ArrayList arr = (ArrayList)ViewState["SelectedRecords"];

            count = arr.Count;

            for (int i = 0; i < AddItemGrid.Rows.Count; i++)
            {

                if (arr.Contains(AddItemGrid.DataKeys[i].Value))
                {

                    DeleteRecord(AddItemGrid.DataKeys[i].Value.ToString());

                    arr.Remove(AddItemGrid.DataKeys[i].Value);

                }

            }

            ViewState["SelectedRecords"] = arr;

            hfCount.Value = "0";

            AddItemGrid.AllowPaging = true;

            BindGrid();

            ShowMessage(count);

        }
        private void DeleteRecord(string CustomerID)
        {

            string constr = ConfigurationManager

                        .ConnectionStrings["Mycon"].ConnectionString;

            string query = "DELETE FROM ItemDtl" +

                            "where Id=@Id";

            SqlConnection con = new SqlConnection(constr);

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Id", CustomerID);

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();

        }

        private void ShowMessage(int count)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("alert('");
            sb.Append(count.ToString());
            sb.Append(" records deleted.');");
            sb.Append("</script>");

            ClientScript.RegisterStartupScript(this.GetType(),

                            "script", sb.ToString());
        }

        protected void BtnExcelUp_Click(object sender, EventArgs e)
        {
            //  Container();
            ItemUpload();
            // Casc();
            BindItemMaster();
        }

        protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
        {
            TabPanelClasses();
        }

        private void TabPanelClasses()
        {


            if (TabContainer1.ActiveTabIndex == 0)
            {
                divHeader.Attributes.Add("class", "flex flex-col justify-center items-center relative active-stepper");
                divParty.Attributes["class"] = divParty.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divCargo.Attributes["class"] = divCargo.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divInvoice.Attributes["class"] = divInvoice.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divItem.Attributes["class"] = divItem.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divCPC.Attributes["class"] = divCPC.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divSummary.Attributes["class"] = divSummary.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();

            }
            else if (TabContainer1.ActiveTabIndex == 1)
            {
                divHeader.Attributes["class"] = divHeader.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divHeader.Attributes.Add("class", "flex flex-col justify-center items-center relative  complete-stepper");
                divParty.Attributes.Add("class", "flex flex-col justify-center items-center relative  active-stepper");
                divCargo.Attributes["class"] = divCargo.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divInvoice.Attributes["class"] = divInvoice.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divItem.Attributes["class"] = divItem.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divCPC.Attributes["class"] = divCPC.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divSummary.Attributes["class"] = divSummary.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();

            }
            else if (TabContainer1.ActiveTabIndex == 2)
            {
                divHeader.Attributes["class"] = divHeader.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divHeader.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                divParty.Attributes["class"] = divParty.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divParty.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                divCargo.Attributes.Add("class", "flex flex-col justify-center items-center relative active-stepper");
                divInvoice.Attributes["class"] = divInvoice.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divItem.Attributes["class"] = divItem.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divCPC.Attributes["class"] = divCPC.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divSummary.Attributes["class"] = divSummary.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();

            }
            else if (TabContainer1.ActiveTabIndex == 3)
            {
                divHeader.Attributes["class"] = divHeader.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divHeader.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                divParty.Attributes["class"] = divParty.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divParty.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                divCargo.Attributes["class"] = divCargo.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divCargo.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                divInvoice.Attributes.Add("class", "flex flex-col justify-center items-center relative active-stepper");
                divItem.Attributes["class"] = divItem.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divCPC.Attributes["class"] = divCPC.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divSummary.Attributes["class"] = divSummary.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();

            }
            else if (TabContainer1.ActiveTabIndex == 4)
            {
                divHeader.Attributes["class"] = divHeader.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divHeader.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                divParty.Attributes["class"] = divParty.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divParty.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                divCargo.Attributes["class"] = divCargo.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divCargo.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                divInvoice.Attributes["class"] = divInvoice.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divInvoice.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                divItem.Attributes.Add("class", "flex flex-col justify-center items-center relative active-stepper");
                divCPC.Attributes["class"] = divCPC.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper-stepper", "").Trim();
                divSummary.Attributes["class"] = divSummary.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();

            }
            else if (TabContainer1.ActiveTabIndex == 5)
            {
                divHeader.Attributes["class"] = divHeader.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divHeader.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                divParty.Attributes["class"] = divParty.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divParty.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                divCargo.Attributes["class"] = divCargo.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divCargo.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                divInvoice.Attributes["class"] = divInvoice.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divInvoice.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                divItem.Attributes["class"] = divItem.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divItem.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                divCPC.Attributes.Add("class", "flex flex-col justify-center items-center relative active-stepper");
                divSummary.Attributes["class"] = divSummary.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();

            }
            else if (TabContainer1.ActiveTabIndex == 6)
            {


                divHeader.Attributes["class"] = divHeader.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divHeader.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                divParty.Attributes["class"] = divParty.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divParty.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                divCargo.Attributes["class"] = divCargo.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divCargo.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                divInvoice.Attributes["class"] = divInvoice.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divInvoice.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                divItem.Attributes["class"] = divItem.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divItem.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                divCPC.Attributes["class"] = divCPC.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divCPC.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                divSummary.Attributes.Add("class", "flex flex-col justify-center items-center relative active-stepper");





            }

            else if (TabContainer1.ActiveTabIndex == 7)
            {
                if (Update == "AMEND")
                {



                    divHeader.Attributes["class"] = divHeader.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                    divHeader.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                    divParty.Attributes["class"] = divParty.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                    divParty.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                    divCargo.Attributes["class"] = divCargo.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                    divCargo.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                    divInvoice.Attributes["class"] = divInvoice.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                    divInvoice.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                    divItem.Attributes["class"] = divItem.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                    divItem.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                    divCPC.Attributes["class"] = divCPC.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                    divCPC.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                    divSummary.Attributes["class"] = divCPC.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                    divSummary.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                    divamend.Attributes.Add("class", "flex flex-col justify-center items-center relative  active-stepper");
                    divamend.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");

                }

                else if (Update == "CANCEL")
                {
                    divHeader.Attributes["class"] = divHeader.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                    divHeader.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                    divParty.Attributes["class"] = divParty.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                    divParty.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                    divCargo.Attributes["class"] = divCargo.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                    divCargo.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                    divInvoice.Attributes["class"] = divInvoice.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                    divInvoice.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                    divItem.Attributes["class"] = divItem.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                    divItem.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                    divCPC.Attributes["class"] = divCPC.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                    divCPC.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                    divSummary.Attributes["class"] = divCPC.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                    divSummary.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                    divcancel.Attributes.Add("class", "flex flex-col justify-center items-center relative  active-stepper");
                    divcancel.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                }
                else
                {
                    divHeader.Attributes["class"] = divHeader.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                    divHeader.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                    divParty.Attributes["class"] = divParty.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                    divParty.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                    divCargo.Attributes["class"] = divCargo.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                    divCargo.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                    divInvoice.Attributes["class"] = divInvoice.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                    divInvoice.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                    divItem.Attributes["class"] = divItem.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                    divItem.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                    divCPC.Attributes["class"] = divCPC.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                    divCPC.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                    divSummary.Attributes["class"] = divCPC.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                    divSummary.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                    divrefund.Attributes.Add("class", "flex flex-col justify-center items-center relative  active-stepper");
                    divrefund.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                }
            }



        }

        public void Container()
        {
            string ConStr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            if (FileUpload4.HasFile)
            {
                try
                {
                    string path = @"C:\Users\Public\Files1\" + FileUpload4.FileName;
                    //string path = string.Concat(Server.MapPath("~/Files/" + FileUpload1.FileName));
                    FileUpload4.SaveAs(path);
                    string Extension = Path.GetExtension(FileUpload4.FileName);
                    // Connection String to Excel Workbook
                    string excelConnectionString = "";

                    switch (Extension)
                    {
                        case ".xls": //Excel 97-03
                            excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=Excel 8.0";
                            break;
                        case ".xlsx": //Excel 07
                            excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0";
                            break;
                    }
                    OleDbConnection connection = new OleDbConnection();
                    connection.ConnectionString = excelConnectionString;
                    connection.Open();
                    //string sheet1 = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["TABLE_NAME"].ToString();
                    DataTable dt = new DataTable();
                    dt = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                    String[] excelSheets = new String[dt.Rows.Count];
                    int i = 0;

                    // Add the sheet name to the string array.
                    foreach (DataRow row in dt.Rows)
                    {
                        excelSheets[i] = row["TABLE_NAME"].ToString();
                        i++;
                    }

                    // Loop through all of the sheets if you want too...
                    for (int j = 0; j < excelSheets.Length; j++)
                    {
                        // Query each excel sheet.
                    }
                    OleDbCommand command = new OleDbCommand("select * from [ContainerInfo$]", connection);

                    OleDbDataAdapter adp = new OleDbDataAdapter(command);
                    dt = new DataTable();
                    adp.Fill(dt);

                    string MyConnection2 = ConStr.ToString();

                    SqlConnection con = new SqlConnection(MyConnection2);
                    SqlCommand cmd;

                    /* Loop thorugh dataTable*/
                    i = 1;
                    foreach (DataRow row in dt.Rows)
                    {
                        con.Open();


                        string PermitNo = "KNN000001", MessageType = "IPTDEC", TouchUser = "KNN000";
                        string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


                        string qry = "INSERT INTO [dbo].[ContainerDtl] ([PermitId],[RowNo],[ContainerNo],[Size],[Weight],[SealNo],[MessageType],[TouchUser],[TouchTime]) VALUES ('" + PermitNo + "','" + i + "','" + row["ContainerNo"].ToString() + "','" + row["Size"].ToString() + "','" + row["Weight"].ToString() + "','" + row["SealNo"].ToString() + "','" + MessageType + "','" + TouchUser + "','" + strTime + "')";
                        // string query = "insert into booking(JobId,OrderId,TaskType,CusId,DriverID,StartDate,EndDate,Small,Medium,Normal,Odd,Eurosize,Ref,Description,TaskStatus,TouchUser,TouchTime)  values ('" + txt_code.Text + "','" + row["OrderId"].ToString() + "','" + row["TaskType"].ToString() + "','" + row["CusId"].ToString() + "','Idle','" + row["StartDate"].ToString() + "',' " + row["EndDate"].ToString() + "','" + row["Small"].ToString() + "','" + row["Medium"].ToString() + "','" + row["Normal"].ToString() + "','" + row["Odd"].ToString() + "','" + row["Eurosize"].ToString() + "','" + row["Ref"].ToString() + "','" + row["Description"].ToString() + "','" + Status + "','" + Touch_user + "','" + strTime + "')";
                        cmd = new SqlCommand(qry, con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        i++;

                    }
                    Error_LBL.Text = "Succesfully Uploaded";
                }
                catch (Exception ex)
                {
                    Error_LBL.Text = ex.Message;
                }
            }
        }
        public void ItemUpload()
        {
            string ConStr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            if (FileUpload4.HasFile)
            {
                try
                {

                    //string path = @"C:\Users\Public\Files1\" + FileUpload4.FileName;
                    //////string path = string.Concat(Server.MapPath("~/Files/" + FileUpload4.FileName));
                    ////FileUpload4.SaveAs(path);
                    //string Extension = Path.GetExtension(FileUpload4.FileName);
                    //// Connection String to Excel Workbook
                    //string excelConnectionString = "";
                    //switch (Extension)
                    //{
                    //    case ".xls": //Excel 97-03
                    //        excelConnectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel 8.0", path);
                    //        break;
                    //    case ".xlsx": //Excel 07
                    //        excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0";
                    //        break;
                    //}
                    //OleDbConnection connection = new OleDbConnection();
                    //connection.ConnectionString = excelConnectionString;
                    //OleDbCommand command = new OleDbCommand("select * from [ItemInfo$]", connection);
                    //connection.Open();
                    //OleDbDataAdapter adp = new OleDbDataAdapter(command);
                    //DataTable dt = new DataTable();

                    //adp.Fill(dt);

                    //string MyConnection2 = ConStr.ToString();

                    //SqlConnection con = new SqlConnection(MyConnection2);                    
                    string path = @"C:\Users\Public\Files1\" + FileUpload4.FileName;
                    //string path = string.Concat(Server.MapPath("~/Files/" + FileUpload1.FileName));
                    FileUpload4.SaveAs(path);
                    string Extension = Path.GetExtension(FileUpload4.FileName);
                    // Connection String to Excel Workbook
                    string excelConnectionString = "";

                    switch (Extension)
                    {
                        case ".xls": //Excel 97-03
                            excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=Excel 8.0";
                            break;
                        case ".xlsx": //Excel 07
                            excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0";
                            break;
                    }
                    OleDbConnection connection = new OleDbConnection();
                    connection.ConnectionString = excelConnectionString;
                    connection.Open();
                    //string sheet1 = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["TABLE_NAME"].ToString();
                    DataTable dt = new DataTable();
                    dt = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                    String[] excelSheets = new String[dt.Rows.Count];
                    int i = 0;

                    // Add the sheet name to the string array.
                    foreach (DataRow row in dt.Rows)
                    {
                        excelSheets[i] = row["TABLE_NAME"].ToString();
                        i++;
                    }

                    // Loop through all of the sheets if you want too...
                    for (int j = 0; j < excelSheets.Length; j++)
                    {
                        // Query each excel sheet.
                    }
                    OleDbCommand command = new OleDbCommand("select * from [ItemInfo$]", connection);

                    OleDbDataAdapter adp = new OleDbDataAdapter(command);
                    dt = new DataTable();
                    adp.Fill(dt);

                    string MyConnection2 = ConStr.ToString();

                    SqlConnection con = new SqlConnection(MyConnection2);
                    //  SqlCommand cmd;

                    /* Loop thorugh dataTable*/
                    i = 1;
                    con.Open();
                    foreach (DataRow row in dt.Rows)
                    {
                        //string BGIndicator = "", DutiableQty = "", Dutiableuom = "", ttlDutiableQty = "", ttlDutiableuom = "",HSQuantity="",HSQuantityUOM="";

                        if (row["HS Code"].ToString() != "")
                        {
                            string Messagetype = "IPTDEC";
                            string Touch_user = Session["UserId"].ToString();
                            string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                            string hscode = "";
                            if (row["HS Code"].ToString() == "")
                            {
                                hscode = "";
                            }
                            else
                            {
                                hscode = row["HS Code"].ToString();
                            }
                            string description = "";
                            if (row["Description"].ToString() == "")
                            {
                                description = "";
                            }
                            else
                            {
                                description = row["Description"].ToString();
                            }
                            string DGIndicator = "";
                            if (row["DG Indicator"].ToString() == "")
                            {
                                DGIndicator = "false";
                            }
                            else
                            {
                                DGIndicator = row["DG Indicator"].ToString();
                            }

                            string Country = "";
                            if (row["Country of Origin"].ToString() == "")
                            {
                                Country = "";
                            }
                            else
                            {
                                Country = row["Country of Origin"].ToString();
                            }
                            string Brand = "";
                            if (row["Brand"].ToString() == "")
                            {
                                Brand = "";
                            }
                            else
                            {
                                Brand = row["Brand"].ToString();
                            }
                            string Model = "";
                            if (row["Model"].ToString() == "")
                            {
                                Model = "";
                            }
                            else
                            {
                                Model = row["Model"].ToString();
                            }

                            string InHAWBOBL = "";
                            if (row["In HAWB"].ToString() == "")
                            {
                                InHAWBOBL = "0.00";
                            }
                            else
                            {
                                InHAWBOBL = row["In HAWB"].ToString();
                            }


                            string DutyQty = "";
                            if (row["Dutiable Qty"].ToString() == "")
                            {
                                DutyQty = "0.00";
                            }
                            else
                            {
                                DutyQty = row["Dutiable Qty"].ToString();
                            }
                            string DutyQtyUOM = "";
                            if (row["Dutiable UOM"].ToString() == "")
                            {
                                DutyQtyUOM = "--Select--";
                            }
                            else
                            {
                                DutyQtyUOM = row["Dutiable UOM"].ToString();
                            }

                            string TtlDutyQty = "";
                            if (row["Total Dutiable Qty"].ToString() == "")
                            {
                                TtlDutyQty = "0.00";
                            }
                            else
                            {
                                TtlDutyQty = row["Total Dutiable Qty"].ToString();
                            }
                            string ttlDutyQtyUOM = "";
                            if (row["Total Dutiable UOM"].ToString() == "")
                            {
                                ttlDutyQtyUOM = "--Select--";
                            }
                            else
                            {
                                ttlDutyQtyUOM = row["Total Dutiable UOM"].ToString();
                            }


                            int InvoiceQty = 0;
                            string HSQuantity = "";

                            if (row["HS Qty"].ToString() == "")
                            {
                                HSQuantity = "0.00";
                            }
                            else
                            {
                                HSQuantity = row["HS Qty"].ToString();
                            }

                            string HSQuantityUOM = "";
                            if (row["HS UOM"].ToString() == "")
                            {
                                HSQuantityUOM = "--Select--";
                            }
                            else
                            {
                                HSQuantityUOM = row["HS UOM"].ToString();
                            }

                            string AlPer = "";
                            if (row["Alcohol Percentage"].ToString() == "")
                            {
                                AlPer = "0.00";
                            }
                            else
                            {
                                AlPer = row["Alcohol Percentage"].ToString();
                            }
                            string INVno = "";
                            if (row["Invoice Number"].ToString() == "")
                            {
                                INVno = "0.00";
                            }
                            else
                            {
                                INVno = row["Invoice Number"].ToString();
                            }

                            string chkUnitPrice = "false";

                            string UnitPrice = "false";
                            if (row["Unit Price"].ToString() == "")
                            {
                                UnitPrice = "0.00";
                            }
                            else
                            {
                                UnitPrice = row["Unit Price"].ToString();
                            }

                            string UnitPriceCurency = "";
                            if (row["Item Currency"].ToString() == "")
                            {
                                UnitPriceCurency = "--Select--";
                            }
                            else
                            {
                                UnitPriceCurency = row["Item Currency"].ToString();
                            }

                            string UnitPriceExrate = "0.00", SumExchangeRate = "0.00", InvoiceCharges = "0.00", CIFFOB = "0.00"; ;

                            string TotalLineAmount = "";

                            if (row["Total Line Amount"].ToString() == "")
                            {
                                TotalLineAmount = "0.00";
                            }
                            else
                            {
                                TotalLineAmount = row["Total Line Amount"].ToString();
                            }
                            string inPackQty = "", innerPackQty = "", inmostPackQty = "", OuterPackQty = "";
                            string inPackQtyUOM = "", innerPackQtyUOM = "", inmostPackQtyUOM = "", OuterPackQtyUOM = "";

                            if (row["In Pack Qty"].ToString() == "")
                            {
                                inPackQty = "0.00";
                            }
                            else
                            {
                                inPackQty = row["In Pack Qty"].ToString();
                            }
                            if (row["In Pack UOM"].ToString() == "")
                            {
                                inPackQtyUOM = "--Select--";
                            }
                            else
                            {
                                inPackQtyUOM = row["In Pack UOM"].ToString();
                            }

                            if (row["Inner Pack Qty"].ToString() == "")
                            {
                                innerPackQty = "0.00";
                            }
                            else
                            {
                                innerPackQty = row["Inner Pack Qty"].ToString();
                            }
                            if (row["Inner Pack UOM"].ToString() == "")
                            {
                                innerPackQtyUOM = "--Select--";
                            }
                            else
                            {
                                innerPackQtyUOM = row["Inner Pack UOM"].ToString();
                            }

                            if (row["Inmost Pack Qty"].ToString() == "")
                            {
                                inmostPackQty = "0.00";
                            }
                            else
                            {
                                inmostPackQty = row["Inmost Pack Qty"].ToString();
                            }
                            if (row["Inmost Pack UOM"].ToString() == "")
                            {
                                inmostPackQtyUOM = "--Select--";
                            }
                            else
                            {
                                inmostPackQtyUOM = row["Inmost Pack UOM"].ToString();
                            }


                            if (row["Outer Pack Qty"].ToString() == "")
                            {
                                OuterPackQty = "0.00";
                            }
                            else
                            {
                                OuterPackQty = row["Outer Pack Qty"].ToString();
                            }
                            if (row["Outer Pack UOM"].ToString() == "")
                            {
                                OuterPackQtyUOM = "--Select--";
                            }
                            else
                            {
                                OuterPackQtyUOM = row["Outer Pack UOM"].ToString();
                            }

                            string PerCode = "";
                            if (row["Tarrif Preferential Code"].ToString() == "")
                            {
                                PerCode = "";
                            }
                            else
                            {
                                PerCode = row["Tarrif Preferential Code"].ToString();
                            }

                            string GSTRAte = "9";


                            string GSTUOM = "PER";
                            string GSTAMOUNT = "0.00", ExciseRate = "0.00", ExciseUOM = "--Select--", ExciseAmt = "0.00", CusRate = "0.00", CusUOM = "--Select--", CusAmt = "0.00", OtherRate = "0.00", OtherUOM = "--Select--", OtherAmt = "0.00";

                            string CurrentLOt = "";

                            if (row["Current Lot"].ToString() == "")
                            {
                                CurrentLOt = "";
                            }
                            else
                            {
                                CurrentLOt = row["Current Lot"].ToString();
                            }

                            string PrevLot = "";

                            if (row["Previous Lot"].ToString() == "")
                            {
                                PrevLot = "";
                            }
                            else
                            {
                                PrevLot = row["Previous Lot"].ToString();
                            }

                            string Making = "", Ship1 = "", Ship2 = "", Ship3 = "", Ship4 = "";
                            if (row["Shipping Marks 1"].ToString() == "")
                            {
                                Ship1 = "";
                            }
                            else
                            {
                                Ship1 = row["Shipping Marks 1"].ToString();
                            }

                            if (row["Shipping Marks 2"].ToString() == "")
                            {
                                Ship2 = "";
                            }
                            else
                            {
                                Ship2 = row["Shipping Marks 2"].ToString();
                            }
                            if (row["Shipping Marks 3"].ToString() == "")
                            {
                                Ship3 = "";
                            }
                            else
                            {
                                Ship3 = row["Shipping Marks 3"].ToString();
                            }
                            if (row["Shipping Marks 4"].ToString() == "")
                            {
                                Ship4 = "";
                            }
                            else
                            {
                                Ship4 = row["Shipping Marks 4"].ToString();
                            }
                            string LSPValue = "0.00";
                            //string StrQuery1 = ("INSERT INTO [dbo].[ItemDtl] ([ItemNo],[PermitId],[MessageType],[HSCode],[Description],[DGIndicator],[Contry],[Brand],[Model],[InHAWBOBL],[DutiableQty],[DutiableUOM],[TotalDutiableQty],[TotalDutiableUOM],[InvoiceQuantity],[HSQty],[HSUOM],[AlcoholPer],[InvoiceNo],[ChkUnitPrice],[UnitPrice],[UnitPriceCurrency],[ExchangeRate],[SumExchangeRate],[TotalLineAmount],[InvoiceCharges],[CIFFOB],[OPQty],[OPUOM],[IPQty],[IPUOM],[InPqty],[InPUOM],[ImPQty],[ImPUOM],[PreferentialCode],[GSTRate],[GSTUOM],[GSTAmount],[ExciseDutyRate],[ExciseDutyUOM],[ExciseDutyAmount],[CustomsDutyRate],[CustomsDutyUOM],[CustomsDutyAmount],[OtherTaxRate],[OtherTaxUOM],[OtherTaxAmount],[CurrentLot],[PreviousLot],[Making],[ShippingMarks1],[ShippingMarks2],[ShippingMarks3],[ShippingMarks4],[TouchUser],[TouchTime]) VALUES ('" + i + "','" + PermitId + "','" + Messagetype + "','" + row["HS Code"].ToString() + "','" + row["Description"].ToString() + "','" + BGIndicator + "','" + row["Country of Origin"].ToString() + "','" + row["Brand"].ToString() + "','" + row["Model"].ToString() + "','" + row["In HAWB"].ToString() + "','" + row["Dutiable Qty"].ToString() + "','" + row["Dutiable UOM"].ToString() + "','" + row["Total Dutiable Qty"].ToString() + "','" + row["Total Dutiable UOM"].ToString() + "','" + InvoiceQty + "','" + row["HS Qty"].ToString() + "','" + row["HS UOM"].ToString() + "','" + row["Alcohol Percentage"].ToString() + "','" + row["Invoice Number"].ToString() + "','" + chkunitprice + "','" + UnitPrice + "','" + row["Item Currency"].ToString() + "','" + ExchangeRate + "','" + sumofExchangeRate + "','" + row["Total Line Amount"].ToString() + "','" + totalnvcharges + "','" + CIFOBVal + "','" + row["Outer Pack Qty"].ToString() + "','" + row["Outer Pack UOM"].ToString() + "','" + row["In Pack Qty"].ToString() + "','" + row["In Pack UOM"].ToString() + "','" + row["Inner Pack Qty"].ToString() + "','" + row["Inner Pack UOM"].ToString() + "','" + row["Inmost Pack Qty"].ToString() + "','" + row["Inmost Pack UOM"].ToString() + "','" + row["Tarrif Preferential Code"].ToString() + "','" + GST + "','PER','" + DecimalVal + "','" + DecimalVal + "','" + DecimalVal + "','" + DecimalVal + "','" + DecimalVal + "','" + nullval + "','" + DecimalVal + "','" + DecimalVal + "','" + uom + "','" + DecimalVal + "','" + row["Current Lot"].ToString() + "','" + row["Previous Lot"].ToString() + "','" + uom + "','" + row["Shipping Marks 1"].ToString() + "','" + row["Shipping Marks 2"].ToString() + "','" + row["Shipping Marks 3"].ToString() + "','" + row["Shipping Marks 4"].ToString() + "','" + Touch_user + "','" + strTime + "')");
                            string StrQuery1 = ("INSERT INTO [dbo].[ItemDtl] ([ItemNo],[PermitId],[MessageType],[HSCode],[Description],[DGIndicator],[Contry],[Brand],[Model],[InHAWBOBL],[DutiableQty],[DutiableUOM],[TotalDutiableQty],[TotalDutiableUOM],[InvoiceQuantity],[HSQty],[HSUOM],[AlcoholPer],[InvoiceNo],[ChkUnitPrice],[UnitPrice],[UnitPriceCurrency],[ExchangeRate],[SumExchangeRate],[TotalLineAmount],[InvoiceCharges],[CIFFOB],[OPQty],[OPUOM],[IPQty],[IPUOM],[InPqty],[InPUOM],[ImPQty],[ImPUOM],[PreferentialCode],[GSTRate],[GSTUOM],[GSTAmount],[ExciseDutyRate],[ExciseDutyUOM],[ExciseDutyAmount],[CustomsDutyRate],[CustomsDutyUOM],[CustomsDutyAmount],[OtherTaxRate],[OtherTaxUOM],[OtherTaxAmount],[CurrentLot],[PreviousLot],LSPValue,[Making],[ShippingMarks1],[ShippingMarks2],[ShippingMarks3],[ShippingMarks4],[TouchUser],[TouchTime]) VALUES ('" + i + "','" + txt_code.Text + "','" + Messagetype + "','" + hscode + "','" + description + "','" + DGIndicator + "','" + Country + "','" + Brand + "','" + Model + "','" + InHAWBOBL + "','" + DutyQty + "','" + DutyQtyUOM + "','" + TtlDutyQty + "','" + ttlDutyQtyUOM + "','" + InvoiceQty + "','" + HSQuantity + "','" + HSQuantityUOM + "','" + AlPer + "','" + INVno + "','" + chkUnitPrice + "','" + UnitPrice + "','" + UnitPriceCurency + "','" + UnitPriceExrate + "','" + SumExchangeRate + "','" + TotalLineAmount + "','" + InvoiceCharges + "','" + CIFFOB + "','" + OuterPackQty + "','" + OuterPackQtyUOM + "','" + inPackQty + "','" + inPackQtyUOM + "','" + innerPackQty + "','" + innerPackQtyUOM + "','" + inmostPackQty + "','" + inmostPackQtyUOM + "','" + PerCode + "','" + GSTRAte + "','" + GSTUOM + "','" + GSTAMOUNT + "','" + ExciseRate + "','" + ExciseUOM + "','" + ExciseAmt + "','" + CusRate + "','" + CusUOM + "','" + CusAmt + "','" + OtherRate + "','" + OtherUOM + "','" + OtherAmt + "','" + CurrentLOt + "','" + PrevLot + "','" + LSPValue + "','" + Making + "','" + Ship1 + "','" + Ship2 + "','" + Ship3 + "','" + Ship4 + "','" + Touch_user + "','" + strTime + "')");
                            obj.exec(StrQuery1);
                        }
                        obj.closecon();
                        i++;
                        Error_LBL.Text = "Succesfully Uploaded";
                    }
                }
                catch (Exception ex)
                {
                    Error_LBL.Text = ex.Message;
                }
            }
        }

        public void Casc()
        {
            string ConStr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            if (FileUpload4.HasFile)
            {
                try
                {

                    string path = @"C:\Users\Public\Files1\" + FileUpload4.FileName;
                    //FileUpload4.SaveAs(path);
                    string Extension = Path.GetExtension(FileUpload4.FileName);
                    // Connection String to Excel Workbook
                    string excelConnectionString = "";
                    switch (Extension)
                    {
                        case ".xls": //Excel 97-03
                            excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=Excel 8.0";
                            break;
                        case ".xlsx": //Excel 07
                            excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0";
                            break;
                    }
                    OleDbConnection connection = new OleDbConnection();
                    connection.ConnectionString = excelConnectionString;
                    OleDbCommand command = new OleDbCommand("SELECT * FROM [CASCDtl$]", connection);
                    connection.Open();
                    OleDbDataAdapter adp = new OleDbDataAdapter(command);
                    DataTable dt = new DataTable();
                    dt.Clear();
                    adp.Fill(dt);

                    //command = new OleDbCommand("select * from [Casccodes$]", connection);
                    //OleDbDataAdapter adp1 = new OleDbDataAdapter(command);
                    //DataTable dt1 = new DataTable();
                    //dt1.Clear();
                    //adp1.Fill(dt1);

                    // string ProductCode = "", Quantity = "", ProductUOM = "", ProductCode1 = "", Quantity1 = "", ProductUOM1 = "";
                    //foreach (DataRow row in dt.Rows)
                    //{
                    //string BGIndicator = "", DutiableQty = "", Dutiableuom = "", ttlDutiableQty = "", ttlDutiableuom = "",HSQuantity="",HSQuantityUOM="";

                    //    if (row["HS Code"].ToString() != "")
                    //    {
                    //        if (row["CASC Product Code 1"].ToString() == "")
                    //        {
                    //            ProductCode = "";
                    //        }
                    //        else
                    //        {
                    //            ProductCode = row["CASC Product Code 1"].ToString();
                    //        }

                    //        if (row["CASC Product Code 1 Qty"].ToString() == "")
                    //        {
                    //            Quantity = "0.00";
                    //        }
                    //        else
                    //        {
                    //            Quantity = row["CASC Product Code 1 Qty"].ToString();
                    //        }

                    //        if (row["CASC Product Code 1 UOM"].ToString() == "")
                    //        {
                    //            ProductUOM = "--Select--";
                    //        }
                    //        else
                    //        {
                    //            ProductUOM = row["CASC Product Code 1 UOM"].ToString();
                    //        }

                    //        if (row["CASC Product Code 2"].ToString() == "")
                    //        {
                    //            ProductCode1 = "";
                    //        }
                    //        else
                    //        {
                    //            ProductCode1 = row["CASC Product Code 2"].ToString();
                    //        }

                    //        if (row["CASC Product Code 2 Qty"].ToString() == "")
                    //        {
                    //            Quantity = "0.00";
                    //        }
                    //        else
                    //        {
                    //            Quantity = row["CASC Product Code 2 Qty"].ToString();
                    //        }

                    //        if (row["CASC Product Code 2 UOM"].ToString() == "")
                    //        {
                    //            ProductUOM = "--Select--";
                    //        }
                    //        else
                    //        {
                    //            ProductUOM = row["CASC Product Code 2 UOM"].ToString();
                    //        }
                    //    }
                    //  }
                    string MyConnection2 = ConStr.ToString();

                    SqlConnection con = new SqlConnection(MyConnection2);

                    /* Loop thorugh dataTable*/
                    con.Open();
                    foreach (DataRow row in dt.Rows)
                    {
                        int p1 = 1;
                        if (row["Item Number"].ToString() != "")
                        {
                            string PermitId = txt_code.Text;
                            string Messagetype = "IPTDEC";
                            string Touch_user = Session["UserId"].ToString();
                            string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


                            string QTY;


                            if (row["QTY"].ToString() == "")
                            {
                                QTY = "0.00";
                            }
                            else
                            {
                                QTY = row["QTY"].ToString();
                            }



                            string StrQuery1 = ("INSERT INTO [dbo].[CASCDtl] (ItemNo,[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId]) VALUES ('" + row["Item Number"].ToString() + "','" + row["ProductCode"].ToString() + "','" + QTY + "','" + row["UOM"].ToString() + "','" + p1 + "','" + row["Code 1"].ToString() + "','" + row["Code 2"].ToString() + "','" + row["Code 3"].ToString() + "','" + PermitId + "','" + Messagetype + "','" + Touch_user + "','" + strTime + "','" + row["CascID"].ToString() + "')");
                            obj.exec(StrQuery1);
                            p1++;
                        }
                        obj.closecon();

                        Error_LBL.Text = "Succesfully Uploaded";
                    }
                }
                catch (Exception ex)
                {
                    Error_LBL.Text = ex.Message;
                }
            }
        }

        protected void OriginalRegDate_TextChanged(object sender, EventArgs e)
        {
            //OriginalRegDate.Text = DateCheck(OriginalRegDate.Text);
            string curdate = "";
            string Dateval = OriginalRegDate.Text;
            if (Dateval.Length == 10)
            {
                curdate = Dateval;
            }
            else if (Dateval.Length == 8)
            {
                string date = Dateval.Substring(0, 2);
                string month = Dateval.Substring(2, 2);
                string year = Dateval.Substring(4, 4);
                if (Convert.ToInt16(month) >= 1 && Convert.ToInt16(month) <= 12)
                {
                    if (month == "01" || month == "03" || month == "05" || month == "07" || month == "08" || month == "10" || month == "12")
                    {
                        if (Convert.ToInt16(date) >= 1 && Convert.ToInt16(date) <= 31)
                        {
                            curdate = date + "/" + month + "/" + year;
                        }
                        else
                        {
                            curdate = DateTime.Now.ToString("dd/MM/yyyy");
                        }
                    }
                    else if (month == "04" || month == "06" || month == "09" || month == "11")
                    {
                        if (Convert.ToInt16(date) >= 1 && Convert.ToInt16(date) <= 30)
                        {
                            curdate = date + "/" + month + "/" + year;
                        }
                        else
                        {
                            curdate = DateTime.Now.ToString("dd/MM/yyyy");
                        }
                    }
                    else if (month == "02")
                    {
                        if (Convert.ToInt16(date) >= 1 && Convert.ToInt16(date) <= 29)
                        {
                            curdate = date + "/" + month + "/" + year;
                        }
                        else
                        {
                            curdate = DateTime.Now.ToString("dd/MM/yyyy");
                        }
                    }
                }
                else
                {
                    curdate = DateTime.Now.ToString("dd/MM/yyyy");
                }
            }
            else
            {
                curdate = DateTime.Now.ToString("dd/MM/yyyy");
            }
            OriginalRegDate.Text = curdate;
            OriginalRegDate.Focus();
        }

        protected void txttrdremrk_TextChanged(object sender, EventArgs e)
        {
            lbltracunt.Text = "(" + txttrdremrk.Text.Length.ToString() + " / 1024 Characters)"; 
        }

        protected void FrieghtChargesPer_TextChanged(object sender, EventArgs e)
        {
            double excharge, sumins, insamt;
            if (FrieghtChargesPer.Text != "")
            {

                if (Drpcurrency3.SelectedItem.ToString() != "--Select--")
                {
                    double a, b, c, d;

                    bool isAValid = double.TryParse(SumTotalInvoice.Text.Trim(), out a);
                    bool isBValid = double.TryParse(FrieghtChargesPer.Text.Trim(), out b);
                    bool isCValid = double.TryParse(LblFrieghtCharges.Text.Trim(), out c);

                    if (isAValid && isBValid)
                    {
                        string SOT = string.Format("{0:N}", Convert.ToDouble(Math.Round((a * b / 100), 4).ToString()));
                        // LblSumOFTotal.Text = SOT;
                        SumFrieghtCharges.Text = SOT;
                        bool isDValid = double.TryParse(SOT, out d);
                        string SumGSTTo = string.Format("{0:N}", Convert.ToDouble(Math.Round((a * b / 100), 4).ToString()));
                        //  LblSumOFTotal.Text = SumGSTTo;
                        // SumFrieghtCharges.Text = Math.Round((a * b / 100), 2).ToString();
                        // SumFrieghtCharges.Text = SOT;

                        TxtFrieghtCharges.Text = string.Format("{0:N}", Convert.ToDouble(Math.Round((d / c), 4).ToString()));







                    }
                }
                else
                {
                    double a, b;

                    bool isAValid = double.TryParse(SumTotalInvoice.Text.Trim(), out a);
                    bool isBValid = double.TryParse(FrieghtChargesPer.Text.Trim(), out b);
                    //bool isCValid = double.TryParse(LblFrieghtCharges.Text.Trim(), out c);

                    if (isAValid && isBValid)
                    {
                        string SOT = string.Format("{0:N}", Convert.ToDouble(Math.Round((a * b / 100), 4).ToString()));
                        // LblSumOFTotal.Text = SOT;
                        SumFrieghtCharges.Text = SOT;
                        //bool isDValid = double.TryParse(SOT, out d);
                        string SumGSTTo = string.Format("{0:N}", Convert.ToDouble(Math.Round((a * b / 100), 4).ToString()));
                        //  LblSumOFTotal.Text = SumGSTTo;
                        // SumFrieghtCharges.Text = Math.Round((a * b / 100), 2).ToString();
                        // SumFrieghtCharges.Text = SOT;

                        // TxtFrieghtCharges.Text = string.Format("{0:N}", Convert.ToDouble(Math.Round((d / c), 4).ToString()));






                    }
                }


            }
            else
            {
                FrieghtChargesPer.Text = "0.00";
            }



            sumofinsurance();
            bool exrate = double.TryParse(lblInsuranceCharges.Text.Trim(), out excharge);
            bool sum = double.TryParse(SumInsuranceCharges.Text.Trim(), out sumins);

            TxtInsuranceCharges.Text = string.Format("{0:N}", Convert.ToDouble(Math.Round((sumins / excharge), 4).ToString()));
            totalinv();

            Drpcurrency3.Focus();

            //  TxtFrieghtCharges_TextChanged(null,null);
        }

        protected void btnprev_Click(object sender, EventArgs e)
        {
            int itemno1 = Convert.ToInt32(TxtSerialNo.Text);

            int id = itemno1 - 1;
            string ID = id.ToString();


            // string strBindTxtBox = "select * from [ItemDtl] where ItemNo='" + ID + "' and PermitId='" + Invoice + "'";

            string stra = "select Id,Name from [CommonMaster] where TypeId='12' and StatusID=1 order by Name";
            obj.dr = obj.ret_dr(stra);
            DrpMaking.DataSource = obj.dr;
            DrpMaking.DataTextField = "Name";
            DrpMaking.DataValueField = "Id";
            DrpMaking.DataBind();
            obj.closecon();
            DrpMaking.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));

            string Invoice = txt_code.Text;
            string striW = "select * from [InvoiceDtl] where MessageType='IPTDEC' AND PermitId='" + Invoice + "'  order by InvoiceNo";
            obj.dr = obj.ret_dr(striW);
            obj.BindDropDown(DrpInvoiceNo, obj.dr, "Id", "InvoiceNo");
            //DrpInvoiceNo.DataSource = null;
            //DrpInvoiceNo.DataSource = obj.dr;
            //DrpInvoiceNo.DataTextField = "InvoiceNo";
            //DrpInvoiceNo.DataValueField = "Id";
            //DrpInvoiceNo.DataBind();
            //obj.closecon();
            //DrpInvoiceNo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));

            //GridViewRow grdrow = (GridViewRow)((ImageButton)sender).NamingContainer as GridViewRow;
            //Label ID1 = (Label)grdrow.FindControl("lblID");
            //string ID = ID1.Text;

            //warning
            // string SuplierCode, Importer = "";

            string strBindTxtBox = "select * from [ItemDtl] where ItemNo='" + ID + "' and PermitId='" + Invoice + "'";
            obj.dr = obj.ret_dr(strBindTxtBox);
            while (obj.dr.Read())
            {
                try
                {

                    TxtSerialNo.Text = obj.dr["ItemNo"].ToString();
                    itemno.Text = obj.dr["ItemNo"].ToString();
                    TxtHSCodeItem.Text = obj.dr["HSCode"].ToString();
                    TxtHSCodeItem_TextChanged(null, null);
                    TxtDescription.Text = obj.dr["Description"].ToString();
                    string chkrate = obj.dr["DGIndicator"].ToString();
                    if (chkrate == "True")
                    {
                        ChkBGIndicator.Checked = true;
                    }
                    else if (chkrate == "False")
                    {
                        ChkBGIndicator.Checked = false;
                    }
                    TxtCountryItem.Text = obj.dr["Contry"].ToString();

                    TxtBrand.Text = obj.dr["Brand"].ToString();
                    TxtModel.Text = obj.dr["model"].ToString();
                    string[] hblvalue = obj.dr["InHAWBOBL"].ToString().Split(',');
                    for (int i = 0; i < hblvalue.Length; i++)
                    {
                        TxtHAWB.Items.Add(hblvalue[i].ToString());
                    }
                    lblhblValue.Text = txthBlCargo.Text;
                    //TxtHAWB.ClearSelection();
                    //TxtHAWB.Items.FindByText(obj.dr["InHAWBOBL"].ToString()).Selected = true;
                    //TxtHAWB.Text = obj.dr["InHAWBOBL"].ToString();
                    TxtTotalDutiableQuantity.Text = obj.dr["DutiableQty"].ToString();
                    TDQUOM.ClearSelection();
                    TDQUOM.Items.FindByText(obj.dr["DutiableUOM"].ToString()).Selected = true;
                    txttotDutiableQty.Text = obj.dr["TotalDutiableQty"].ToString();
                    ddptotDutiableQty.ClearSelection();
                    ddptotDutiableQty.Items.FindByText(obj.dr["TotalDutiableUOM"].ToString()).Selected = true;
                    txtAlcoholPer.Text = obj.dr["AlcoholPer"].ToString();
                    // TDQUOM.SelectedItem.Text = obj.dr["TotalDutiableUOM"].ToString();
                    TxtInvQty.Text = obj.dr["InvoiceQuantity"].ToString();
                    TxtHSQuantity.Text = obj.dr["HSQty"].ToString();
                    HSQTYUOM.ClearSelection();
                    HSQTYUOM.Items.FindByText(obj.dr["HSUOM"].ToString()).Selected = true;

                    //HSQTYUOM.ClearSelection();
                    //HSQTYUOM.SelectedItem.Text = obj.dr["HSUOM"].ToString();
                    string invno = obj.dr["InvoiceNo"].ToString();
                    DrpInvoiceNo.ClearSelection();
                    string striW1 = "select * from [InvoiceDtl] where MessageType='IPTDEC' AND PermitId='" + Invoice + "' and  InvoiceNo='" + obj.dr["InvoiceNo"].ToString() + "' order by InvoiceNo";
                    InpaymentClass objinv = new InpaymentClass();
                    objinv.dr = objinv.ret_dr(striW1);
                    if (objinv.dr.Read())
                    {
                        DrpInvoiceNo.Items.FindByText(obj.dr["InvoiceNo"].ToString()).Selected = true;
                    }
                    else
                    {
                        DrpInvoiceNo.Items.FindByText("--Select--").Selected = true;
                    }
                    //DrpInvoiceNo.Items.FindByText(obj.dr["InvoiceNo"].ToString()).Selected = true;                    
                    // DrpInvoiceNo.SelectedItem.Text = obj.dr[16].ToString();
                    string ChkUnitPrice1 = obj.dr["ChkUnitPrice"].ToString();
                    if (ChkUnitPrice1 == "True")
                    {
                        ChkUnitPrice.Checked = true;
                    }
                    else if (ChkUnitPrice1 == "False")
                    {
                        ChkUnitPrice.Checked = false;
                    }
                    ChkUnitPrice_CheckedChanged(null, null);

                    TxtUnitPrice.Text = obj.dr["UnitPrice"].ToString();

                    DRPCurrency.ClearSelection();
                    DRPCurrency.Items.FindByText(obj.dr["UnitPriceCurrency"].ToString()).Selected = true;
                    //DRPCurrency.SelectedItem.Text = obj.dr[19].ToString();
                    TxtExchangeRate.Text = obj.dr["ExchangeRate"].ToString();
                    TxtSumExRate.Text = obj.dr["SumExchangeRate"].ToString();
                    TxtTotalLineAmount.Text = obj.dr["TotalLineAmount"].ToString();
                    TxtTotalLineCharges.Text = obj.dr["InvoiceCharges"].ToString();
                    TxtCIFFOB.Text = obj.dr["CIFFOB"].ToString();
                    TxtOPQty.Text = Math.Round(Convert.ToDecimal(obj.dr["OPQty"].ToString()), 0).ToString();

                    DRPOPQUOM.ClearSelection();
                    DRPOPQUOM.Items.FindByText(obj.dr["OPUOM"].ToString()).Selected = true;



                    // DRPOPQUOM.SelectedItem.Text = obj.dr[26].ToString();
                    TxtIPQty.Text = Math.Round(Convert.ToDecimal(obj.dr["IPQty"].ToString()), 0).ToString();

                    DRPIPQUOM.ClearSelection();
                    DRPIPQUOM.Items.FindByText(obj.dr["IPUOM"].ToString()).Selected = true;
                    // DRPIPQUOM.SelectedItem.Text = obj.dr[28].ToString();
                    TxtINPQty.Text = Math.Round(Convert.ToDecimal(obj.dr["InPqty"].ToString()), 0).ToString();

                    DRPINNPQUOM.ClearSelection();
                    DRPINNPQUOM.Items.FindByText(obj.dr["InPUOM"].ToString()).Selected = true;
                    // DRPINNPQUOM.SelectedItem.Text = obj.dr[30].ToString();
                    TxtIMPQty.Text = Math.Round(Convert.ToDecimal(obj.dr["ImPQty"].ToString()), 0).ToString();

                    DRPIMPQUOM.ClearSelection();
                    DRPIMPQUOM.Items.FindByText(obj.dr["ImPUOM"].ToString()).Selected = true;
                    //DRPIMPQUOM.SelectedItem.Text = obj.dr[32].ToString();
                    DrpPreferentialCode.ClearSelection();
                    DrpPreferentialCode.Items.FindByText(obj.dr["PreferentialCode"].ToString()).Selected = true;
                    // DrpPreferentialCode.SelectedItem.Text = obj.dr[33].ToString();
                    txtlsp.Text = obj.dr["LSPValue"].ToString();
                    ItemGSTRate.Text = obj.dr["GSTRate"].ToString();
                    ItemGSTUOM.Text = obj.dr["GSTUOM"].ToString();
                    TxtItemSumGST.Text = obj.dr["GSTAmount"].ToString();
                    TxtExciseDutyRate.Text = obj.dr["ExciseDutyRate"].ToString();
                    TxtExciseDutyUOM.Text = obj.dr["ExciseDutyUOM"].ToString();
                    TxtSumExciseDuty.Text = obj.dr["ExciseDutyAmount"].ToString();
                    TxtCustomsDutyRate.Text = obj.dr["CustomsDutyRate"].ToString();
                    TxtCustomsDutyUOM.Text = obj.dr["CustomsDutyUOM"].ToString();
                    TxtSumCustomsDuty.Text = obj.dr["CustomsDutyAmount"].ToString();
                    TxtOtherTaxRate.Text = obj.dr["OtherTaxRate"].ToString();


                    DrpOtherUOM.ClearSelection();
                    DrpOtherUOM.Items.FindByText(obj.dr["OtherTaxUOM"].ToString()).Selected = true;
                    //DrpOtherUOM.SelectedItem.Text = obj.dr[44].ToString();
                    TxtSumOtherTaxRate.Text = obj.dr["OtherTaxAmount"].ToString();
                    TxtCurrentLot.Text = obj.dr["CurrentLot"].ToString();

                    DrpMaking.ClearSelection();
                    DrpMaking.Items.FindByText(obj.dr["Making"].ToString()).Selected = true;
                    // DrpMaking.SelectedItem.Text = obj.dr[47].ToString();
                    TxtPreviousLot.Text = obj.dr["PreviousLot"].ToString();
                    txtShippingMarks1.Text = obj.dr["ShippingMarks1"].ToString();
                    txtShippingMarks2.Text = obj.dr["ShippingMarks2"].ToString();
                    txtShippingMarks3.Text = obj.dr["ShippingMarks3"].ToString();
                    txtShippingMarks4.Text = obj.dr["ShippingMarks4"].ToString();
                    if (!string.IsNullOrWhiteSpace(obj.dr["VehicleType"].ToString()))
                    {
                        if (obj.dr["VehicleType"].ToString() != "-Select-")
                        {

                            DrpVehicleType.ClearSelection();
                            DrpVehicleType.Items.FindByText(obj.dr["VehicleType"].ToString()).Selected = true;
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(obj.dr["OptionalChrgeUOM"].ToString()))
                    {
                        if (obj.dr["OptionalChrgeUOM"].ToString() != "-Select-")
                        {
                            DrpOptionalUom.ClearSelection();
                            DrpOptionalUom.Items.FindByText(obj.dr["OptionalChrgeUOM"].ToString()).Selected = true;
                        }
                    }


                    TextBox4.Text = obj.dr["EngineCapcity"].ToString();
                    TxtOptionalPrice.Text = obj.dr["Optioncahrge"].ToString();
                    TxtOptionalExchageRate.Text = obj.dr["OptionalSumtotal"].ToString();
                    TxtOptionalSumExRate.Text = obj.dr["OptionalSumExchage"].ToString();
                    if (!string.IsNullOrWhiteSpace(obj.dr["EngineCapUOM"].ToString()))
                    {
                        if (obj.dr["EngineCapUOM"].ToString() != "-Select-")
                        {
                            DrpVehicleCapacity.ClearSelection();
                            DrpVehicleCapacity.Items.FindByText(obj.dr["EngineCapUOM"].ToString()).Selected = true;
                        }
                    }

                    OriginalRegDate.Text = obj.dr["orignaldatereg"].ToString();


                    editbindProduct1(ID);
                    editbindProduct2(ID);
                    editbindProduct3(ID);
                    string co = "select * from [Country] where CountryCode='" + TxtCountryItem.Text + "'";
                    obj.dr = obj.ret_dr(co);
                    while (obj.dr.Read())
                    {
                        txtcname.Text = obj.dr["Description"].ToString();
                    }

                    ItemAddGrid.Visible = true;
                    ItemDiv.Visible = true;
                    BtnAddNEWItem.Visible = false;
                    DrpInvoiceNo_SelectedIndexChanged(null, null);
                    //HSQTYUOM_SelectedIndexChanged(null, null);
                    return;
                }
                //EditItem();


                catch (Exception ex)
                {
                    ex.ToString();
                }
            }

        }

        protected void btnnxt_Click(object sender, EventArgs e)
        {

            int itemno1 = Convert.ToInt32(TxtSerialNo.Text);

            int id = itemno1 + 1;
            string ID = id.ToString();


            //  string strBindTxtBox = "select * from [ItemDtl] where ItemNo='" + ID + "' and PermitId='" + Invoice + "'";
            string stra = "select Id,Name from [CommonMaster] where TypeId='12' and StatusID=1 order by Name";
            obj.dr = obj.ret_dr(stra);
            DrpMaking.DataSource = obj.dr;
            DrpMaking.DataTextField = "Name";
            DrpMaking.DataValueField = "Id";
            DrpMaking.DataBind();
            obj.closecon();
            DrpMaking.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));

            string Invoice = txt_code.Text;
            string striW = "select * from [InvoiceDtl] where MessageType='IPTDEC' AND PermitId='" + Invoice + "'  order by InvoiceNo";
            obj.dr = obj.ret_dr(striW);
            obj.BindDropDown(DrpInvoiceNo, obj.dr, "Id", "InvoiceNo");
            //DrpInvoiceNo.DataSource = null;
            //DrpInvoiceNo.DataSource = obj.dr;
            //DrpInvoiceNo.DataTextField = "InvoiceNo";
            //DrpInvoiceNo.DataValueField = "Id";
            //DrpInvoiceNo.DataBind();
            //obj.closecon();
            //DrpInvoiceNo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));

            //GridViewRow grdrow = (GridViewRow)((ImageButton)sender).NamingContainer as GridViewRow;
            //Label ID1 = (Label)grdrow.FindControl("lblID");
            //string ID = ID1.Text;

            //warning
            // string SuplierCode, Importer = "";

            string strBindTxtBox = "select * from [ItemDtl] where ItemNo='" + ID + "' and PermitId='" + Invoice + "'";
            obj.dr = obj.ret_dr(strBindTxtBox);
            while (obj.dr.Read())
            {
                try
                {

                    TxtSerialNo.Text = obj.dr["ItemNo"].ToString();
                    itemno.Text = obj.dr["ItemNo"].ToString();
                    TxtHSCodeItem.Text = obj.dr["HSCode"].ToString();
                    TxtHSCodeItem_TextChanged(null, null);
                    TxtDescription.Text = obj.dr["Description"].ToString();
                    string chkrate = obj.dr["DGIndicator"].ToString();
                    if (chkrate == "True")
                    {
                        ChkBGIndicator.Checked = true;
                    }
                    else if (chkrate == "False")
                    {
                        ChkBGIndicator.Checked = false;
                    }
                    TxtCountryItem.Text = obj.dr["Contry"].ToString();

                    TxtBrand.Text = obj.dr["Brand"].ToString();
                    TxtModel.Text = obj.dr["model"].ToString();
                    string[] hblvalue = obj.dr["InHAWBOBL"].ToString().Split(',');
                    for (int i = 0; i < hblvalue.Length; i++)
                    {
                        TxtHAWB.Items.Add(hblvalue[i].ToString());
                    }
                    lblhblValue.Text = txthBlCargo.Text;
                    //TxtHAWB.ClearSelection();
                    //TxtHAWB.Items.FindByText(obj.dr["InHAWBOBL"].ToString()).Selected = true;
                    //TxtHAWB.Text = obj.dr["InHAWBOBL"].ToString();
                    TxtTotalDutiableQuantity.Text = obj.dr["DutiableQty"].ToString();
                    TDQUOM.ClearSelection();
                    TDQUOM.Items.FindByText(obj.dr["DutiableUOM"].ToString()).Selected = true;
                    txttotDutiableQty.Text = obj.dr["TotalDutiableQty"].ToString();
                    ddptotDutiableQty.ClearSelection();
                    ddptotDutiableQty.Items.FindByText(obj.dr["TotalDutiableUOM"].ToString()).Selected = true;
                    txtAlcoholPer.Text = obj.dr["AlcoholPer"].ToString();
                    // TDQUOM.SelectedItem.Text = obj.dr["TotalDutiableUOM"].ToString();
                    TxtInvQty.Text = obj.dr["InvoiceQuantity"].ToString();
                    TxtHSQuantity.Text = obj.dr["HSQty"].ToString();
                    HSQTYUOM.ClearSelection();
                    HSQTYUOM.Items.FindByText(obj.dr["HSUOM"].ToString()).Selected = true;

                    //HSQTYUOM.ClearSelection();
                    //HSQTYUOM.SelectedItem.Text = obj.dr["HSUOM"].ToString();
                    string invno = obj.dr["InvoiceNo"].ToString();
                    DrpInvoiceNo.ClearSelection();
                    string striW1 = "select * from [InvoiceDtl] where MessageType='IPTDEC' AND PermitId='" + Invoice + "' and  InvoiceNo='" + obj.dr["InvoiceNo"].ToString() + "' order by InvoiceNo";
                    InpaymentClass objinv = new InpaymentClass();
                    objinv.dr = objinv.ret_dr(striW1);
                    if (objinv.dr.Read())
                    {
                        DrpInvoiceNo.Items.FindByText(obj.dr["InvoiceNo"].ToString()).Selected = true;
                    }
                    else
                    {
                        DrpInvoiceNo.Items.FindByText("--Select--").Selected = true;
                    }
                    //DrpInvoiceNo.Items.FindByText(obj.dr["InvoiceNo"].ToString()).Selected = true;                    
                    // DrpInvoiceNo.SelectedItem.Text = obj.dr[16].ToString();
                    string ChkUnitPrice1 = obj.dr["ChkUnitPrice"].ToString();
                    if (ChkUnitPrice1 == "True")
                    {
                        ChkUnitPrice.Checked = true;
                    }
                    else if (ChkUnitPrice1 == "False")
                    {
                        ChkUnitPrice.Checked = false;
                    }
                    ChkUnitPrice_CheckedChanged(null, null);

                    TxtUnitPrice.Text = obj.dr["UnitPrice"].ToString();

                    DRPCurrency.ClearSelection();
                    DRPCurrency.Items.FindByText(obj.dr["UnitPriceCurrency"].ToString()).Selected = true;
                    //DRPCurrency.SelectedItem.Text = obj.dr[19].ToString();
                    TxtExchangeRate.Text = obj.dr["ExchangeRate"].ToString();
                    TxtSumExRate.Text = obj.dr["SumExchangeRate"].ToString();
                    TxtTotalLineAmount.Text = obj.dr["TotalLineAmount"].ToString();
                    TxtTotalLineCharges.Text = obj.dr["InvoiceCharges"].ToString();
                    TxtCIFFOB.Text = obj.dr["CIFFOB"].ToString();
                    TxtOPQty.Text = Math.Round(Convert.ToDecimal(obj.dr["OPQty"].ToString()), 0).ToString();

                    DRPOPQUOM.ClearSelection();
                    DRPOPQUOM.Items.FindByText(obj.dr["OPUOM"].ToString()).Selected = true;



                    // DRPOPQUOM.SelectedItem.Text = obj.dr[26].ToString();
                    TxtIPQty.Text = Math.Round(Convert.ToDecimal(obj.dr["IPQty"].ToString()), 0).ToString();

                    DRPIPQUOM.ClearSelection();
                    DRPIPQUOM.Items.FindByText(obj.dr["IPUOM"].ToString()).Selected = true;
                    // DRPIPQUOM.SelectedItem.Text = obj.dr[28].ToString();
                    TxtINPQty.Text = Math.Round(Convert.ToDecimal(obj.dr["InPqty"].ToString()), 0).ToString();

                    DRPINNPQUOM.ClearSelection();
                    DRPINNPQUOM.Items.FindByText(obj.dr["InPUOM"].ToString()).Selected = true;
                    // DRPINNPQUOM.SelectedItem.Text = obj.dr[30].ToString();
                    TxtIMPQty.Text = Math.Round(Convert.ToDecimal(obj.dr["ImPQty"].ToString()), 0).ToString();

                    DRPIMPQUOM.ClearSelection();
                    DRPIMPQUOM.Items.FindByText(obj.dr["ImPUOM"].ToString()).Selected = true;
                    //DRPIMPQUOM.SelectedItem.Text = obj.dr[32].ToString();
                    DrpPreferentialCode.ClearSelection();
                    DrpPreferentialCode.Items.FindByText(obj.dr["PreferentialCode"].ToString()).Selected = true;
                    // DrpPreferentialCode.SelectedItem.Text = obj.dr[33].ToString();
                    txtlsp.Text = obj.dr["LSPValue"].ToString();
                    ItemGSTRate.Text = obj.dr["GSTRate"].ToString();
                    ItemGSTUOM.Text = obj.dr["GSTUOM"].ToString();
                    TxtItemSumGST.Text = obj.dr["GSTAmount"].ToString();
                    TxtExciseDutyRate.Text = obj.dr["ExciseDutyRate"].ToString();
                    TxtExciseDutyUOM.Text = obj.dr["ExciseDutyUOM"].ToString();
                    TxtSumExciseDuty.Text = obj.dr["ExciseDutyAmount"].ToString();
                    TxtCustomsDutyRate.Text = obj.dr["CustomsDutyRate"].ToString();
                    TxtCustomsDutyUOM.Text = obj.dr["CustomsDutyUOM"].ToString();
                    TxtSumCustomsDuty.Text = obj.dr["CustomsDutyAmount"].ToString();
                    TxtOtherTaxRate.Text = obj.dr["OtherTaxRate"].ToString();


                    DrpOtherUOM.ClearSelection();
                    DrpOtherUOM.Items.FindByText(obj.dr["OtherTaxUOM"].ToString()).Selected = true;
                    //DrpOtherUOM.SelectedItem.Text = obj.dr[44].ToString();
                    TxtSumOtherTaxRate.Text = obj.dr["OtherTaxAmount"].ToString();
                    TxtCurrentLot.Text = obj.dr["CurrentLot"].ToString();

                    DrpMaking.ClearSelection();
                    DrpMaking.Items.FindByText(obj.dr["Making"].ToString()).Selected = true;
                    // DrpMaking.SelectedItem.Text = obj.dr[47].ToString();
                    TxtPreviousLot.Text = obj.dr["PreviousLot"].ToString();
                    txtShippingMarks1.Text = obj.dr["ShippingMarks1"].ToString();
                    txtShippingMarks2.Text = obj.dr["ShippingMarks2"].ToString();
                    txtShippingMarks3.Text = obj.dr["ShippingMarks3"].ToString();
                    txtShippingMarks4.Text = obj.dr["ShippingMarks4"].ToString();
                    if (!string.IsNullOrWhiteSpace(obj.dr["VehicleType"].ToString()))
                    {
                        if (obj.dr["VehicleType"].ToString() != "-Select-")
                        {

                            DrpVehicleType.ClearSelection();
                            DrpVehicleType.Items.FindByText(obj.dr["VehicleType"].ToString()).Selected = true;
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(obj.dr["OptionalChrgeUOM"].ToString()))
                    {
                        if (obj.dr["OptionalChrgeUOM"].ToString() != "-Select-")
                        {
                            DrpOptionalUom.ClearSelection();
                            DrpOptionalUom.Items.FindByText(obj.dr["OptionalChrgeUOM"].ToString()).Selected = true;
                        }
                    }


                    TextBox4.Text = obj.dr["EngineCapcity"].ToString();
                    TxtOptionalPrice.Text = obj.dr["Optioncahrge"].ToString();
                    TxtOptionalExchageRate.Text = obj.dr["OptionalSumtotal"].ToString();
                    TxtOptionalSumExRate.Text = obj.dr["OptionalSumExchage"].ToString();
                    if (!string.IsNullOrWhiteSpace(obj.dr["EngineCapUOM"].ToString()))
                    {
                        if (obj.dr["EngineCapUOM"].ToString() != "-Select-")
                        {
                            DrpVehicleCapacity.ClearSelection();
                            DrpVehicleCapacity.Items.FindByText(obj.dr["EngineCapUOM"].ToString()).Selected = true;
                        }
                    }

                    OriginalRegDate.Text = obj.dr["orignaldatereg"].ToString();


                    editbindProduct1(ID);
                    editbindProduct2(ID);
                    editbindProduct3(ID);
                    string co = "select * from [Country] where CountryCode='" + TxtCountryItem.Text + "'";
                    obj.dr = obj.ret_dr(co);
                    while (obj.dr.Read())
                    {
                        txtcname.Text = obj.dr["Description"].ToString();
                    }

                    ItemAddGrid.Visible = true;
                    ItemDiv.Visible = true;
                    BtnAddNEWItem.Visible = false;
                    DrpInvoiceNo_SelectedIndexChanged(null, null);
                    //HSQTYUOM_SelectedIndexChanged(null, null);
                    return;
                }
                //EditItem();


                catch (Exception ex)
                {
                    ex.ToString();
                }
            }

        }



        //Start From here
        protected void Chkscheme_CheckedChanged(object sender, EventArgs e)
        {
            if (Chkscheme1.Checked == true)
            {
                SCHEME.Visible = true;
                return;
            }
            else
            {
                SCHEME.Visible = false;
            }
            btnSchemeStr.Focus();
        }
        protected void SchemeGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (ViewState["CurrentTable2"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable2"];
                DataRow drCurrentRow = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                if (dt.Rows.Count > 1)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["CurrentTable2"] = dt;
                    SchemeGrid.DataSource = dt;
                    SchemeGrid.DataBind();

                    for (int i = 0; i < ContarinerGrid.Rows.Count - 1; i++)
                    {
                        SchemeGrid.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                    }
                    SetPreviousData2cp();
                }
            }
        }

        protected void btnSchemeStr_Click(object sender, EventArgs e)
        {
            DataTable dtCurrent = ViewState["CurrentTable30"] as DataTable;

            // Check if current rows are already 5
            if (dtCurrent != null && dtCurrent.Rows.Count >= 5)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You can only add up to 5 rows.');", true);
                return;
            }

            // Check if there are existing rows and validate the last row's inputs
            if (SchemeGrid.Rows.Count > 0)
            {
                int lastRowIndex = SchemeGrid.Rows.Count - 1;

                // Get the three textboxes from the last row
                TextBox box1 = (TextBox)SchemeGrid.Rows[lastRowIndex].Cells[1].FindControl("TextBox1");
                TextBox box2 = (TextBox)SchemeGrid.Rows[lastRowIndex].Cells[2].FindControl("TextBox2");
                TextBox box3 = (TextBox)SchemeGrid.Rows[lastRowIndex].Cells[3].FindControl("TextBox3");

                // Validate all three fields
                if (string.IsNullOrWhiteSpace(box1.Text) )
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        "alert('Please fill all three fields in the previous row before adding a new one.');", true);
                    return;
                }
            }

            if (dtCurrent == null || dtCurrent.Rows.Count == 0)
            {
                SetInitialRow2cpScheme();
            }
            else
            {
                AddNewRowToGrid2cpScheme();
            }
        }

        private void SetInitialRow2cpScheme()
        {

            DataTable dt = new DataTable();

            DataRow dr = null;

            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));

            dt.Columns.Add(new DataColumn("Processing Code1", typeof(string)));

            dt.Columns.Add(new DataColumn("Processing Code2", typeof(string)));

            dt.Columns.Add(new DataColumn("Processing Code3", typeof(string)));

            dr = dt.NewRow();

            dr["RowNumber"] = 1;

            dr["Processing Code1"] = string.Empty;

            dr["Processing Code2"] = string.Empty;

            dr["Processing Code3"] = string.Empty;

            dt.Rows.Add(dr);

            //dr = dt.NewRow();



            //Store the DataTable in ViewState

            ViewState["CurrentTable30"] = dt;

            SchemeGrid.DataSource = dt;

            SchemeGrid.DataBind();
            //SchemeGrid.Columns[0].Visible = false;

        }
        private void AddNewRowToGrid2cpScheme()
        {

            int rowIndex = 0;



            if (ViewState["CurrentTable30"] != null)
            {

                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable30"];

                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {

                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {

                        //extract the TextBox values

                        TextBox box1 = (TextBox)SchemeGrid.Rows[rowIndex].Cells[1].FindControl("TextBox1");

                        TextBox box2 = (TextBox)SchemeGrid.Rows[rowIndex].Cells[2].FindControl("TextBox2");

                        TextBox box3 = (TextBox)SchemeGrid.Rows[rowIndex].Cells[3].FindControl("TextBox3");



                        drCurrentRow = dtCurrentTable.NewRow();

                        drCurrentRow["RowNumber"] = i + 1;



                        dtCurrentTable.Rows[i - 1]["Processing Code1"] = box1.Text;

                        dtCurrentTable.Rows[i - 1]["Processing Code2"] = box2.Text;

                        dtCurrentTable.Rows[i - 1]["Processing Code3"] = box3.Text;



                        rowIndex++;

                    }

                    dtCurrentTable.Rows.Add(drCurrentRow);

                    ViewState["CurrentTable30"] = dtCurrentTable;



                    SchemeGrid.DataSource = dtCurrentTable;

                    SchemeGrid.DataBind();
                    //SchemeGrid.Columns[0].Visible = false;
                }

            }

            else
            {

                Response.Write("ViewState is null");

            }



            //Set Previous Data on Postbacks

            SetPreviousData2cpScheme();

        }
        private void SetPreviousData2cpScheme()
        {

            int rowIndex = 0;

            if (ViewState["CurrentTable30"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTable30"];

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        TextBox box1 = (TextBox)SchemeGrid.Rows[rowIndex].Cells[1].FindControl("TextBox1");

                        TextBox box2 = (TextBox)SchemeGrid.Rows[rowIndex].Cells[2].FindControl("TextBox2");

                        TextBox box3 = (TextBox)SchemeGrid.Rows[rowIndex].Cells[3].FindControl("TextBox3");



                        box1.Text = dt.Rows[i]["Processing Code1"].ToString();

                        box2.Text = dt.Rows[i]["Processing Code2"].ToString();

                        box3.Text = dt.Rows[i]["Processing Code3"].ToString();



                        rowIndex++;

                    }

                }

            }

        }
        private void editCPCSchemestore()
        {
            string qry = "select RowNo as RowNumber,ProcessingCode1,ProcessingCode2,ProcessingCode3 from InHeaderTbl a,InNonCPCDtl b where a.PermitId=b.PermitId and b.CPCType='SCHEME' and a.PermitId='" + txt_code.Text + "'"; 
            SqlConnection con = new SqlConnection(sqlconn);
            //SqlCommand cmd1 = new SqlCommand("SELECT T1.Id ,T1.CRP,T1.CompanyName,T1.Name,T1.EmailId,T1.Mobile, T2.Name as Rent ,t1.BudgetFrom,T1.BudgetTo ,T3.Name as Type,T4.Name as Location,T5.PropertyRef,T1.MultipleLocation,T1. MultipleProperty  FROM (select a.Id,a.CompanyName,a.Name,a.EmailId,a.Mobile,a.BudgetFrom,a.BudgetTo,b.Name as CRP,a.MultipleLocation,a.MultipleProperty  from lead a,CommonMaster b where a.Per_Com=b.Id and a.TouchUser='" + Touch_user + "') AS T1 JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.RentorBuy=b.Id) AS T2    ON T1.Id = T2.Id    JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Type=b.Id) AS T3  ON T1.Id = T3.Id     JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Location=b.Id) AS T4   ON T1.Id = T4.Id    JOIN ( select b.ID,b.Name,a.PropertyRef  from Lead_List a,Lead b where a.ParentId=b.Id) AS T5   ON T1.Id = T5.Id order by T1.Id desc", con);
            SqlCommand cmd1 = new SqlCommand(qry, con);
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            if (dt.Rows.Count <= 0)
            {
                DataRow newRow = dt.NewRow();
                newRow["RowNumber"] = 1; // Set initial sequence
                newRow["ProcessingCode1"] = string.Empty;
                newRow["ProcessingCode2"] = string.Empty;
                newRow["ProcessingCode3"] = string.Empty;
                dt.Rows.Add(newRow);
            }

            ViewState["CurrentTable30"] = dt;
            SchemeGrid.DataSource = ViewState["CurrentTable30"] as DataTable;
            SchemeGrid.DataBind();

            string ccc = "";
            obj.dr = obj.ret_dr(qry);
            while (obj.dr.Read())
            {
                ccc = obj.dr["ProcessingCode1"].ToString();
            }
            if (ccc == "")
            {
                Chkic1.Checked = false;
                IC.Visible = false;
            }
            else
            {
                Chkic1.Checked = true;
                IC.Visible = true;
            }

           

            int rowIndex = 0;
            if (ViewState["CurrentTable30"] != null)
            {
                DataTable dt1 = (DataTable)ViewState["CurrentTable30"];
                if (dt1.Rows.Count > 0)
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                      
                        TextBox box1 = (TextBox)SchemeGrid.Rows[rowIndex].Cells[1].FindControl("TextBox1");

                      

                        TextBox box2 = (TextBox)SchemeGrid.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                        TextBox box3 = (TextBox)SchemeGrid.Rows[rowIndex].Cells[3].FindControl("TextBox3");
                        box1.Text = dt1.Rows[i]["ProcessingCode1"].ToString();
                        box2.Text = dt1.Rows[i]["ProcessingCode2"].ToString();
                        box3.Text = dt1.Rows[i]["ProcessingCode3"].ToString();
                        rowIndex++;
                    }
                }
            }

        }



        protected void Chksts_CheckedChanged(object sender, EventArgs e)
        {
            if (Chksts1.Checked == true)
            {
                STS.Visible = true;
                return;
            }
            else
            {
                STS.Visible = false;
            }
            btnStsStr.Focus();
        }
        protected void StsGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (ViewState["CurrentTable2"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable2"];
                DataRow drCurrentRow = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                if (dt.Rows.Count > 1)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["CurrentTable2"] = dt;
                    StsGrid.DataSource = dt;
                    StsGrid.DataBind();

                    for (int i = 0; i < ContarinerGrid.Rows.Count - 1; i++)
                    {
                        StsGrid.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                    }
                    SetPreviousData2cp();
                }
            }
        }

        protected void btnStsStr_Click(object sender, EventArgs e)
        {
            DataTable dtCurrent = ViewState["CurrentTable21"] as DataTable;

            // Check if current rows are already 5
            if (dtCurrent != null && dtCurrent.Rows.Count >= 5)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You can only add up to 5 rows.');", true);
                return;
            }

            // Check if there are existing rows and validate the last row's inputs
            if (StsGrid.Rows.Count > 0)
            {
                int lastRowIndex = StsGrid.Rows.Count - 1;

                // Get the three textboxes from the last row
                TextBox box1 = (TextBox)StsGrid.Rows[lastRowIndex].Cells[1].FindControl("TextBox1");
                TextBox box2 = (TextBox)StsGrid.Rows[lastRowIndex].Cells[2].FindControl("TextBox2");
                TextBox box3 = (TextBox)StsGrid.Rows[lastRowIndex].Cells[3].FindControl("TextBox3");

                // Validate all three fields
                if (string.IsNullOrWhiteSpace(box1.Text)  )
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        "alert('Please fill all three fields in the previous row before adding a new one.');", true);
                    return;
                }
            }

            if (dtCurrent == null || dtCurrent.Rows.Count == 0)
            {
                SetInitialRow2cpSts();
            }
            else
            {
                AddNewRowToGrid2cpSts();
            }

            chkcwc.Focus();
        }

        private void SetInitialRow2cpSts()
        {

            DataTable dt = new DataTable();

            DataRow dr = null;

            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));

            dt.Columns.Add(new DataColumn("Processing Code1", typeof(string)));

            dt.Columns.Add(new DataColumn("Processing Code2", typeof(string)));

            dt.Columns.Add(new DataColumn("Processing Code3", typeof(string)));

            dr = dt.NewRow();

            dr["RowNumber"] = 1;

            dr["Processing Code1"] = string.Empty;

            dr["Processing Code2"] = string.Empty;

            dr["Processing Code3"] = string.Empty;

            dt.Rows.Add(dr);

            //dr = dt.NewRow();



            //Store the DataTable in ViewState

            ViewState["CurrentTable21"] = dt;

            StsGrid.DataSource = dt;

            StsGrid.DataBind();
            //StsGrid.Columns[0].Visible = false;

        }
        private void AddNewRowToGrid2cpSts()
        {

            int rowIndex = 0;



            if (ViewState["CurrentTable21"] != null)
            {

                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable21"];

                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {

                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {

                        //extract the TextBox values

                        TextBox box1 = (TextBox)StsGrid.Rows[rowIndex].Cells[1].FindControl("TextBox1");

                        TextBox box2 = (TextBox)StsGrid.Rows[rowIndex].Cells[2].FindControl("TextBox2");

                        TextBox box3 = (TextBox)StsGrid.Rows[rowIndex].Cells[3].FindControl("TextBox3");



                        drCurrentRow = dtCurrentTable.NewRow();

                        drCurrentRow["RowNumber"] = i + 1;



                        dtCurrentTable.Rows[i - 1]["Processing Code1"] = box1.Text;

                        dtCurrentTable.Rows[i - 1]["Processing Code2"] = box2.Text;

                        dtCurrentTable.Rows[i - 1]["Processing Code3"] = box3.Text;



                        rowIndex++;

                    }

                    dtCurrentTable.Rows.Add(drCurrentRow);

                    ViewState["CurrentTable21"] = dtCurrentTable;



                    StsGrid.DataSource = dtCurrentTable;

                    StsGrid.DataBind();
                    //StsGrid.Columns[0].Visible = false;
                }

            }

            else
            {

                Response.Write("ViewState is null");

            }



            //Set Previous Data on Postbacks

            SetPreviousData2cpSts();

        }
        private void SetPreviousData2cpSts()
        {

            int rowIndex = 0;

            if (ViewState["CurrentTable21"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTable21"];

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        TextBox box1 = (TextBox)StsGrid.Rows[rowIndex].Cells[1].FindControl("TextBox1");

                        TextBox box2 = (TextBox)StsGrid.Rows[rowIndex].Cells[2].FindControl("TextBox2");

                        TextBox box3 = (TextBox)StsGrid.Rows[rowIndex].Cells[3].FindControl("TextBox3");



                        box1.Text = dt.Rows[i]["Processing Code1"].ToString();

                        box2.Text = dt.Rows[i]["Processing Code2"].ToString();

                        box3.Text = dt.Rows[i]["Processing Code3"].ToString();



                        rowIndex++;

                    }

                }

            }

        }
        private void editCPCStsstore()
        {
            string qry = "select RowNo as RowNumber,ProcessingCode1,ProcessingCode2,ProcessingCode3 from InHeaderTbl a,InNonCPCDtl b where a.PermitId=b.PermitId and b.CPCType='STS' and a.PermitId='" + txt_code.Text + "'";
            SqlConnection con = new SqlConnection(sqlconn);
            //SqlCommand cmd1 = new SqlCommand("SELECT T1.Id ,T1.CRP,T1.CompanyName,T1.Name,T1.EmailId,T1.Mobile, T2.Name as Rent ,t1.BudgetFrom,T1.BudgetTo ,T3.Name as Type,T4.Name as Location,T5.PropertyRef,T1.MultipleLocation,T1. MultipleProperty  FROM (select a.Id,a.CompanyName,a.Name,a.EmailId,a.Mobile,a.BudgetFrom,a.BudgetTo,b.Name as CRP,a.MultipleLocation,a.MultipleProperty  from lead a,CommonMaster b where a.Per_Com=b.Id and a.TouchUser='" + Touch_user + "') AS T1 JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.RentorBuy=b.Id) AS T2    ON T1.Id = T2.Id    JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Type=b.Id) AS T3  ON T1.Id = T3.Id     JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Location=b.Id) AS T4   ON T1.Id = T4.Id    JOIN ( select b.ID,b.Name,a.PropertyRef  from Lead_List a,Lead b where a.ParentId=b.Id) AS T5   ON T1.Id = T5.Id order by T1.Id desc", con);
            SqlCommand cmd1 = new SqlCommand(qry, con);
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            if (dt.Rows.Count <= 0)
            {
                DataRow newRow = dt.NewRow();
                newRow["RowNumber"] = 1; // Set initial sequence
                newRow["ProcessingCode1"] = string.Empty;
                newRow["ProcessingCode2"] = string.Empty;
                newRow["ProcessingCode3"] = string.Empty;
                dt.Rows.Add(newRow);
            }

            ViewState["CurrentTable21"] = dt;
            StsGrid.DataSource = ViewState["CurrentTable21"] as DataTable;
            StsGrid.DataBind();


            string ccc = "";
            obj.dr = obj.ret_dr(qry);
            while (obj.dr.Read())
            {
                ccc = obj.dr["ProcessingCode1"].ToString();
            }
            if (ccc == "")
            {
                Chksts1.Checked = false;
                STS.Visible = false;
            }
            else
            {
                Chksts1.Checked = true;
                STS.Visible = true;
            }

           
            int rowIndex = 0;
            if (ViewState["CurrentTable21"] != null)
            {
                DataTable dt1 = (DataTable)ViewState["CurrentTable21"];
                if (dt1.Rows.Count > 0)
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                       
                        TextBox box1 = (TextBox)StsGrid.Rows[rowIndex].Cells[1].FindControl("TextBox1");

                      
                        TextBox box2 = (TextBox)StsGrid.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                        TextBox box3 = (TextBox)StsGrid.Rows[rowIndex].Cells[3].FindControl("TextBox3");
                        box1.Text = dt1.Rows[i]["ProcessingCode1"].ToString();
                        box2.Text = dt1.Rows[i]["ProcessingCode2"].ToString();
                        box3.Text = dt1.Rows[i]["ProcessingCode3"].ToString();
                        rowIndex++;
                    }
                }
            }

        }


        protected void Chkstscwc_CheckedChanged(object sender, EventArgs e)
        {
            if (Chkstscwc1.Checked == true)
            {
                STSANDCWS.Visible = true;
                return;
            }
            else
            {
                STSANDCWS.Visible = false;
            }
            btnStscwcStr.Focus();
        }
        protected void StscwcGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (ViewState["CurrentTable2"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable2"];
                DataRow drCurrentRow = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                if (dt.Rows.Count > 1)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["CurrentTable2"] = dt;
                    StscwcGrid.DataSource = dt;
                    StscwcGrid.DataBind();

                    for (int i = 0; i < ContarinerGrid.Rows.Count - 1; i++)
                    {
                        StscwcGrid.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                    }
                    SetPreviousData2cp();
                }
            }
        }

        protected void btnStscwcStr_Click(object sender, EventArgs e)
        {
            DataTable dtCurrent = ViewState["CurrentTable22"] as DataTable;

            // Check if current rows are already 5
            if (dtCurrent != null && dtCurrent.Rows.Count >= 5)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You can only add up to 5 rows.');", true);
                return;
            }

            // Check if there are existing rows and validate the last row's inputs
            if (StscwcGrid.Rows.Count > 0)
            {
                int lastRowIndex = StscwcGrid.Rows.Count - 1;

                // Get the three textboxes from the last row
                TextBox box1 = (TextBox)StscwcGrid.Rows[lastRowIndex].Cells[1].FindControl("TextBox1");
                TextBox box2 = (TextBox)StscwcGrid.Rows[lastRowIndex].Cells[2].FindControl("TextBox2");
                TextBox box3 = (TextBox)StscwcGrid.Rows[lastRowIndex].Cells[3].FindControl("TextBox3");

                // Validate all three fields
                if (string.IsNullOrWhiteSpace(box1.Text) )
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        "alert('Please complete all fields in the current row before adding a new one.');", true);
                    return;
                }
            }

            if (dtCurrent == null || dtCurrent.Rows.Count == 0)
            {
                SetInitialRow2cpStscwc();
            }
            else
            {
                AddNewRowToGrid2cpStscwc();
            }

            chkcwc.Focus();
        }

        private void SetInitialRow2cpStscwc()
        {

            DataTable dt = new DataTable();

            DataRow dr = null;

            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));

            dt.Columns.Add(new DataColumn("Processing Code1", typeof(string)));

            dt.Columns.Add(new DataColumn("Processing Code2", typeof(string)));

            dt.Columns.Add(new DataColumn("Processing Code3", typeof(string)));

            dr = dt.NewRow();

            dr["RowNumber"] = 1;

            dr["Processing Code1"] = string.Empty;

            dr["Processing Code2"] = string.Empty;

            dr["Processing Code3"] = string.Empty;

            dt.Rows.Add(dr);

            //dr = dt.NewRow();



            //Store the DataTable in ViewState

            ViewState["CurrentTable22"] = dt;

            StscwcGrid.DataSource = dt;

            StscwcGrid.DataBind();
            //StscwcGrid.Columns[0].Visible = false;

        }
        private void AddNewRowToGrid2cpStscwc()
        {

            int rowIndex = 0;



            if (ViewState["CurrentTable22"] != null)
            {

                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable22"];

                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {

                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {

                        //extract the TextBox values

                        TextBox box1 = (TextBox)StscwcGrid.Rows[rowIndex].Cells[1].FindControl("TextBox1");

                        TextBox box2 = (TextBox)StscwcGrid.Rows[rowIndex].Cells[2].FindControl("TextBox2");

                        TextBox box3 = (TextBox)StscwcGrid.Rows[rowIndex].Cells[3].FindControl("TextBox3");



                        drCurrentRow = dtCurrentTable.NewRow();

                        drCurrentRow["RowNumber"] = i + 1;



                        dtCurrentTable.Rows[i - 1]["Processing Code1"] = box1.Text;

                        dtCurrentTable.Rows[i - 1]["Processing Code2"] = box2.Text;

                        dtCurrentTable.Rows[i - 1]["Processing Code3"] = box3.Text;



                        rowIndex++;

                    }

                    dtCurrentTable.Rows.Add(drCurrentRow);

                    ViewState["CurrentTable22"] = dtCurrentTable;



                    StscwcGrid.DataSource = dtCurrentTable;

                    StscwcGrid.DataBind();
                    //StscwcGrid.Columns[0].Visible = false;
                }

            }

            else
            {

                Response.Write("ViewState is null");

            }



            //Set Previous Data on Postbacks

            SetPreviousData2cpStscwc();

        }
        private void SetPreviousData2cpStscwc()
        {

            int rowIndex = 0;

            if (ViewState["CurrentTable22"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTable22"];

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        TextBox box1 = (TextBox)StscwcGrid.Rows[rowIndex].Cells[1].FindControl("TextBox1");

                        TextBox box2 = (TextBox)StscwcGrid.Rows[rowIndex].Cells[2].FindControl("TextBox2");

                        TextBox box3 = (TextBox)StscwcGrid.Rows[rowIndex].Cells[3].FindControl("TextBox3");



                        box1.Text = dt.Rows[i]["Processing Code1"].ToString();

                        box2.Text = dt.Rows[i]["Processing Code2"].ToString();

                        box3.Text = dt.Rows[i]["Processing Code3"].ToString();



                        rowIndex++;

                    }

                }

            }

        }
        private void editCPCStscwcstore()
        {
            string qry= "select RowNo as RowNumber,ProcessingCode1,ProcessingCode2,ProcessingCode3 from InHeaderTbl a,InNonCPCDtl b where a.PermitId=b.PermitId and b.CPCType='STSANDCWC' and a.PermitId='" + txt_code.Text + "'";
            SqlConnection con = new SqlConnection(sqlconn);
            //SqlCommand cmd1 = new SqlCommand("SELECT T1.Id ,T1.CRP,T1.CompanyName,T1.Name,T1.EmailId,T1.Mobile, T2.Name as Rent ,t1.BudgetFrom,T1.BudgetTo ,T3.Name as Type,T4.Name as Location,T5.PropertyRef,T1.MultipleLocation,T1. MultipleProperty  FROM (select a.Id,a.CompanyName,a.Name,a.EmailId,a.Mobile,a.BudgetFrom,a.BudgetTo,b.Name as CRP,a.MultipleLocation,a.MultipleProperty  from lead a,CommonMaster b where a.Per_Com=b.Id and a.TouchUser='" + Touch_user + "') AS T1 JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.RentorBuy=b.Id) AS T2    ON T1.Id = T2.Id    JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Type=b.Id) AS T3  ON T1.Id = T3.Id     JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Location=b.Id) AS T4   ON T1.Id = T4.Id    JOIN ( select b.ID,b.Name,a.PropertyRef  from Lead_List a,Lead b where a.ParentId=b.Id) AS T5   ON T1.Id = T5.Id order by T1.Id desc", con);
            SqlCommand cmd1 = new SqlCommand(qry, con);
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            if (dt.Rows.Count <= 0)
            {
                DataRow newRow = dt.NewRow();
                newRow["RowNumber"] = 1; // Set initial sequence
                newRow["ProcessingCode1"] = string.Empty;
                newRow["ProcessingCode2"] = string.Empty;
                newRow["ProcessingCode3"] = string.Empty;
                dt.Rows.Add(newRow);
            }

            ViewState["CurrentTable22"] = dt;
            StscwcGrid.DataSource = ViewState["CurrentTable22"] as DataTable;
            StscwcGrid.DataBind();
            string ccc = "";
            obj.dr = obj.ret_dr(qry);
            while (obj.dr.Read())
            {
                ccc = obj.dr["ProcessingCode1"].ToString();
            }
            if (ccc == "")
            {
                Chkstscwc1.Checked = false;
                STSANDCWS.Visible = false;
            }
            else
            {
                Chkstscwc1.Checked = true;
                STSANDCWS.Visible = true;
            }


          


            int rowIndex = 0;
            if (ViewState["CurrentTable22"] != null)
            {
                DataTable dt1 = (DataTable)ViewState["CurrentTable22"];
                if (dt1.Rows.Count > 0)
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                       
                        TextBox box1 = (TextBox)StscwcGrid.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                       
                        TextBox box2 = (TextBox)StscwcGrid.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                        TextBox box3 = (TextBox)StscwcGrid.Rows[rowIndex].Cells[3].FindControl("TextBox3");
                        box1.Text = dt1.Rows[i]["ProcessingCode1"].ToString();
                        box2.Text = dt1.Rows[i]["ProcessingCode2"].ToString();
                        box3.Text = dt1.Rows[i]["ProcessingCode3"].ToString();
                        rowIndex++;
                    }
                }
            }

        }


        protected void Chkic_CheckedChanged(object sender, EventArgs e)
        {
            if (Chkic1.Checked == true)
            {
                IC.Visible = true;
                return;
            }
            else
            {
                IC.Visible = false;
            }
            btnIcStr.Focus();
        }
        protected void IcGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (ViewState["CurrentTable2"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable2"];
                DataRow drCurrentRow = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                if (dt.Rows.Count > 1)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["CurrentTable2"] = dt;
                    IcGrid.DataSource = dt;
                    IcGrid.DataBind();

                    for (int i = 0; i < ContarinerGrid.Rows.Count - 1; i++)
                    {
                        IcGrid.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                    }
                    SetPreviousData2cp();
                }
            }
        }

        protected void btnIcStr_Click(object sender, EventArgs e)
        {
            DataTable dtCurrent = ViewState["CurrentTable24"] as DataTable;

            // 1. Check if current rows are already 5
            if (dtCurrent != null && dtCurrent.Rows.Count >= 5)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You can only add up to 5 rows.');", true);
                return;
            }

            // 2. Validate previous row's data if grid has rows
            if (IcGrid.Rows.Count > 0)
            {
                int lastRowIndex = IcGrid.Rows.Count - 1;

                // Get the three textbox controls
                TextBox box1 = (TextBox)IcGrid.Rows[lastRowIndex].Cells[1].FindControl("TextBox1");
                TextBox box2 = (TextBox)IcGrid.Rows[lastRowIndex].Cells[2].FindControl("TextBox2");
                TextBox box3 = (TextBox)IcGrid.Rows[lastRowIndex].Cells[3].FindControl("TextBox3");

                // Check if any field is empty
                if (string.IsNullOrWhiteSpace(box1.Text) )
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        "alert('Please complete all fields in the current row before adding a new one.');", true);
                    return;
                }
            }

            // 3. Add new row (either initial or additional)
            if (dtCurrent == null || dtCurrent.Rows.Count == 0)
            {
                SetInitialRow2cpIc();
            }
            else
            {
                AddNewRowToGrid2cpIc();
            }

            // 4. Set focus
            chkcwc.Focus();
        }

        private void SetInitialRow2cpIc()
        {

            DataTable dt = new DataTable();

            DataRow dr = null;

            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));

            dt.Columns.Add(new DataColumn("Processing Code1", typeof(string)));

            dt.Columns.Add(new DataColumn("Processing Code2", typeof(string)));

            dt.Columns.Add(new DataColumn("Processing Code3", typeof(string)));

            dr = dt.NewRow();

            dr["RowNumber"] = 1;

            dr["Processing Code1"] = string.Empty;

            dr["Processing Code2"] = string.Empty;

            dr["Processing Code3"] = string.Empty;

            dt.Rows.Add(dr);

            //dr = dt.NewRow();



            //Store the DataTable in ViewState

            ViewState["CurrentTable24"] = dt;

            IcGrid.DataSource = dt;

            IcGrid.DataBind();
            //IcGrid.Columns[0].Visible = false;

        }
        private void AddNewRowToGrid2cpIc()
        {

            int rowIndex = 0;



            if (ViewState["CurrentTable24"] != null)
            {

                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable24"];

                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {

                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {

                        //extract the TextBox values

                        TextBox box1 = (TextBox)IcGrid.Rows[rowIndex].Cells[1].FindControl("TextBox1");

                        TextBox box2 = (TextBox)IcGrid.Rows[rowIndex].Cells[2].FindControl("TextBox2");

                        TextBox box3 = (TextBox)IcGrid.Rows[rowIndex].Cells[3].FindControl("TextBox3");



                        drCurrentRow = dtCurrentTable.NewRow();

                        drCurrentRow["RowNumber"] = i + 1;



                        dtCurrentTable.Rows[i - 1]["Processing Code1"] = box1.Text;

                        dtCurrentTable.Rows[i - 1]["Processing Code2"] = box2.Text;

                        dtCurrentTable.Rows[i - 1]["Processing Code3"] = box3.Text;



                        rowIndex++;

                    }

                    dtCurrentTable.Rows.Add(drCurrentRow);

                    ViewState["CurrentTable24"] = dtCurrentTable;



                    IcGrid.DataSource = dtCurrentTable;

                    IcGrid.DataBind();
                    //IcGrid.Columns[0].Visible = false;
                }

            }

            else
            {

                Response.Write("ViewState is null");

            }



            //Set Previous Data on Postbacks

            SetPreviousData2cpIc();

        }
        private void SetPreviousData2cpIc()
        {

            int rowIndex = 0;

            if (ViewState["CurrentTable24"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTable24"];

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        TextBox box1 = (TextBox)IcGrid.Rows[rowIndex].Cells[1].FindControl("TextBox1");

                        TextBox box2 = (TextBox)IcGrid.Rows[rowIndex].Cells[2].FindControl("TextBox2");

                        TextBox box3 = (TextBox)IcGrid.Rows[rowIndex].Cells[3].FindControl("TextBox3");



                        box1.Text = dt.Rows[i]["Processing Code1"].ToString();

                        box2.Text = dt.Rows[i]["Processing Code2"].ToString();

                        box3.Text = dt.Rows[i]["Processing Code3"].ToString();



                        rowIndex++;

                    }

                }

            }

        }
        private void editCPCIcstore()
        {
            string qry = "select RowNo as RowNumber,ProcessingCode1,ProcessingCode2,ProcessingCode3 from InHeaderTbl a,InNonCPCDtl b where a.PermitId=b.PermitId and b.CPCType='IC' and a.PermitId='" + txt_code.Text + "'";
            SqlConnection con = new SqlConnection(sqlconn);
            //SqlCommand cmd1 = new SqlCommand("SELECT T1.Id ,T1.CRP,T1.CompanyName,T1.Name,T1.EmailId,T1.Mobile, T2.Name as Rent ,t1.BudgetFrom,T1.BudgetTo ,T3.Name as Type,T4.Name as Location,T5.PropertyRef,T1.MultipleLocation,T1. MultipleProperty  FROM (select a.Id,a.CompanyName,a.Name,a.EmailId,a.Mobile,a.BudgetFrom,a.BudgetTo,b.Name as CRP,a.MultipleLocation,a.MultipleProperty  from lead a,CommonMaster b where a.Per_Com=b.Id and a.TouchUser='" + Touch_user + "') AS T1 JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.RentorBuy=b.Id) AS T2    ON T1.Id = T2.Id    JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Type=b.Id) AS T3  ON T1.Id = T3.Id     JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Location=b.Id) AS T4   ON T1.Id = T4.Id    JOIN ( select b.ID,b.Name,a.PropertyRef  from Lead_List a,Lead b where a.ParentId=b.Id) AS T5   ON T1.Id = T5.Id order by T1.Id desc", con);
            SqlCommand cmd1 = new SqlCommand(qry, con);
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            if (dt.Rows.Count <= 0)
            {
                DataRow newRow = dt.NewRow();
                newRow["RowNumber"] = 1; // Set initial sequence
                newRow["ProcessingCode1"] = string.Empty;
                newRow["ProcessingCode2"] = string.Empty;
                newRow["ProcessingCode3"] = string.Empty;
                dt.Rows.Add(newRow);
            }

            ViewState["CurrentTable24"] = dt;
            IcGrid.DataSource = ViewState["CurrentTable24"] as DataTable;
            IcGrid.DataBind();


            string ccc = "";
            obj.dr = obj.ret_dr(qry);
            while (obj.dr.Read())
            {
                ccc = obj.dr["ProcessingCode1"].ToString();
            }
            if (ccc == "")
            {
                Chkic1.Checked = false;
                IC.Visible = false;
            }
            else
            {
                Chkic1.Checked = true;
                IC.Visible = true;
            }

            int rowIndex = 0;
            if (ViewState["CurrentTable24"] != null)
            {
                DataTable dt1 = (DataTable)ViewState["CurrentTable24"];
                if (dt1.Rows.Count > 0)
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {


                        TextBox box1 = (TextBox)IcGrid.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                       
                       
                        TextBox box2 = (TextBox)IcGrid.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                        TextBox box3 = (TextBox)IcGrid.Rows[rowIndex].Cells[3].FindControl("TextBox3");
                        box1.Text = dt1.Rows[i]["ProcessingCode1"].ToString();
                        box2.Text = dt1.Rows[i]["ProcessingCode2"].ToString();
                        box3.Text = dt1.Rows[i]["ProcessingCode3"].ToString();
                        rowIndex++;
                    }
                }
            }

        }


        private void editCPCSEASTORE()
        {
            string qry = "select RowNo as RowNumber,ProcessingCode1,ProcessingCode2,ProcessingCode3 from InHeaderTbl a,InNonCPCDtl b where a.PermitId=b.PermitId and b.CPCType='SEASTORE' and a.PermitId='" + txt_code.Text + "'";
            SqlConnection con = new SqlConnection(sqlconn);
            //SqlCommand cmd1 = new SqlCommand("SELECT T1.Id ,T1.CRP,T1.CompanyName,T1.Name,T1.EmailId,T1.Mobile, T2.Name as Rent ,t1.BudgetFrom,T1.BudgetTo ,T3.Name as Type,T4.Name as Location,T5.PropertyRef,T1.MultipleLocation,T1. MultipleProperty  FROM (select a.Id,a.CompanyName,a.Name,a.EmailId,a.Mobile,a.BudgetFrom,a.BudgetTo,b.Name as CRP,a.MultipleLocation,a.MultipleProperty  from lead a,CommonMaster b where a.Per_Com=b.Id and a.TouchUser='" + Touch_user + "') AS T1 JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.RentorBuy=b.Id) AS T2    ON T1.Id = T2.Id    JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Type=b.Id) AS T3  ON T1.Id = T3.Id     JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Location=b.Id) AS T4   ON T1.Id = T4.Id    JOIN ( select b.ID,b.Name,a.PropertyRef  from Lead_List a,Lead b where a.ParentId=b.Id) AS T5   ON T1.Id = T5.Id order by T1.Id desc", con);
            SqlCommand cmd1 = new SqlCommand(qry, con);
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            if (dt.Rows.Count <= 0)
            {
                DataRow newRow = dt.NewRow();
                newRow["RowNumber"] = 1; // Set initial sequence
                newRow["ProcessingCode1"] = string.Empty;
                newRow["ProcessingCode2"] = string.Empty;
                newRow["ProcessingCode3"] = string.Empty;
                dt.Rows.Add(newRow);
            }

            ViewState["CurrentTable2"] = dt;
            SeaGrid.DataSource = ViewState["CurrentTable2"] as DataTable;
            SeaGrid.DataBind();


            string ccc = "";
            obj.dr = obj.ret_dr(qry);
            while (obj.dr.Read())
            {
                ccc = obj.dr["ProcessingCode1"].ToString();
            }
            if (ccc == "")
            {
                ChkSea1.Checked = false;
                SEA.Visible = false;
            }
            else
            {
                ChkSea1.Checked = true;
                SEA.Visible = true;
            }

           

            int rowIndex = 0;
            if (ViewState["CurrentTable2"] != null)
            {
                DataTable dt1 = (DataTable)ViewState["CurrentTable2"];
                if (dt1.Rows.Count > 0)
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                       
                        TextBox box1 = (TextBox)SeaGrid.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                                               

                        TextBox box2 = (TextBox)SeaGrid.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                        TextBox box3 = (TextBox)SeaGrid.Rows[rowIndex].Cells[3].FindControl("TextBox3");
                        box1.Text = dt1.Rows[i]["ProcessingCode1"].ToString();
                        box2.Text = dt1.Rows[i]["ProcessingCode2"].ToString();
                        box3.Text = dt1.Rows[i]["ProcessingCode3"].ToString();
                        rowIndex++;
                    }
                }
            }
        }

      

        protected void lblName_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "DownloadFile")
            {
                string fileName = e.CommandArgument.ToString();
                string folderPath = @"C:\Users\Public\IMG\";
                string filePath = Path.Combine(folderPath, fileName);

                if (File.Exists(filePath))
                {
                    Response.Clear();
                    Response.ContentType = "application/octet-stream";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                    Response.TransmitFile(filePath);
                    Response.End();
                }
                else
                {
                    // Optional: Show message if file not found
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('File not found.');", true);
                }
            }
        }
        private void ShowNoResultFound(DataTable source, GridView gv)
        {
            source.Rows.Add(source.NewRow()); // create a new blank row to the DataTable
            // Bind the DataTable which contain a blank row to the GridView
            gv.DataSource = source;
            gv.DataBind();
            // Get the total number of columns in the GridView to know what the Column Span should be
            int columnsCount = gv.Columns.Count;
            gv.Rows[0].Cells.Clear();// clear all the cells in the row
            gv.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
            gv.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

            //You can set the styles here
            gv.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            gv.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
            gv.Rows[0].Cells[0].Font.Bold = true;
            //set No Results found to the new added cell
            gv.Rows[0].Cells[0].Text = "NO RESULT FOUND!";
        }
        protected void txtdocserach_TextChanged(object sender, EventArgs e)
        {
            string query = "";
            if (txtdocserach.Text == "")
            {
                query = "SELECT Id, DocumentType, Name, FileSizeKB FROM InFile WHERE InPaymentId = '"+ MsgNO + "'";


            }
            else
            {
                query = "SELECT Id, DocumentType, Name, FileSizeKB FROM InFile WHERE DocumentType like'%" + txtdocserach.Text + "%' and DocumentType like'%" + txtdocserach.Text + "%' AND  InPaymentId = '"+ MsgNO + "'";

            }

            using (SqlCommand cmd = new SqlCommand(query))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        if (dt.Rows.Count > 0) //Check if DataTable returns data
                        {
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                        else //else if no data returned from the DataTable then 
                        {    //call the method ShowNoResultFound()
                            ShowNoResultFound(dt, GridView1);
                        }
                        //GridInPayment.DataSource = dt;
                        //GridInPayment.DataBind();

                    }
                }
            }
        }

        protected void lnkcopybrand_Click(object sender, EventArgs e)
        {
           

          obj.exec("update ItemDtl set Brand='"+TxtBrand.Text+"' where PermitId='" + txt_code.Text + "'");
            obj.closecon();
            BindItemMaster();


        }

        protected void lnkcopymodel_Click(object sender, EventArgs e)
        {
            obj.exec("update ItemDtl set Model='" + TxtModel.Text + "' where PermitId='" + txt_code.Text + "'");
            obj.closecon();
            BindItemMaster();
        }

        protected void lnkcopydesc_Click(object sender, EventArgs e)
        {
            obj.exec("update ItemDtl set Description='" + TxtDescription.Text + "' where PermitId='" + txt_code.Text + "'");
            obj.closecon();
            BindItemMaster();
        }

        protected void Button19_Click(object sender, EventArgs e)
        {
            TxtProQty3.Text = TxtHSQuantity.Text;
        }

        protected void Button21_Click(object sender, EventArgs e)
        {
            TxtProQty4.Text = TxtHSQuantity.Text;
        }

        protected void Button20_Click(object sender, EventArgs e)
        {
            TxtProQty5.Text = TxtHSQuantity.Text;
        }

        protected void BtnItemDeleteAll_Click(object sender, EventArgs e)
        {
            obj.exec("delete ItemDtl  where PermitId='" + txt_code.Text + "'");
            obj.closecon();
            BindItemMaster();
        }

        protected void BtnItemEditAll_Click(object sender, EventArgs e)
        {
            string strBindTxtBox = "select * from [ItemDtl] where permitid='"+ txt_code.Text + "'";
            obj.dr = obj.ret_dr(strBindTxtBox);
            while (obj.dr.Read())
            {
                try
                {

                    TxtSerialNo.Text = obj.dr["ItemNo"].ToString();
                    itemno.Text = obj.dr["ItemNo"].ToString();
                    TxtHSCodeItem.Text = obj.dr["HSCode"].ToString();
                    TxtHSCodeItem_TextChanged(null, null);
                    TxtDescription.Text = obj.dr["Description"].ToString();
                    string chkrate = obj.dr["DGIndicator"].ToString();
                    if (chkrate == "True")
                    {
                        ChkBGIndicator.Checked = true;
                    }
                    else if (chkrate == "False")
                    {
                        ChkBGIndicator.Checked = false;
                    }
                    TxtCountryItem.Text = obj.dr["Contry"].ToString();

                    TxtBrand.Text = obj.dr["Brand"].ToString();
                    TxtModel.Text = obj.dr["model"].ToString();
                    string[] hblvalue = obj.dr["InHAWBOBL"].ToString().Split(',');
                    for (int i = 0; i < hblvalue.Length; i++)
                    {
                        TxtHAWB.Items.Add(hblvalue[i].ToString());
                    }
                    lblhblValue.Text = txthBlCargo.Text;
                    //TxtHAWB.ClearSelection();
                    //TxtHAWB.Items.FindByText(obj.dr["InHAWBOBL"].ToString()).Selected = true;
                    //TxtHAWB.Text = obj.dr["InHAWBOBL"].ToString();
                    TxtTotalDutiableQuantity.Text = obj.dr["DutiableQty"].ToString();
                    TDQUOM.ClearSelection();
                    TDQUOM.Items.FindByText(obj.dr["DutiableUOM"].ToString()).Selected = true;
                    txttotDutiableQty.Text = obj.dr["TotalDutiableQty"].ToString();
                    ddptotDutiableQty.ClearSelection();
                    ddptotDutiableQty.Items.FindByText(obj.dr["TotalDutiableUOM"].ToString()).Selected = true;
                    txtAlcoholPer.Text = obj.dr["AlcoholPer"].ToString();
                    // TDQUOM.SelectedItem.Text = obj.dr["TotalDutiableUOM"].ToString();
                    TxtInvQty.Text = obj.dr["InvoiceQuantity"].ToString();
                    TxtHSQuantity.Text = obj.dr["HSQty"].ToString();
                    HSQTYUOM.ClearSelection();
                    HSQTYUOM.Items.FindByText(obj.dr["HSUOM"].ToString()).Selected = true;

                    //HSQTYUOM.ClearSelection();
                    //HSQTYUOM.SelectedItem.Text = obj.dr["HSUOM"].ToString();
                    string invno = obj.dr["InvoiceNo"].ToString();
                    DrpInvoiceNo.ClearSelection();
                    string striW1 = "select * from [InvoiceDtl] where MessageType='IPTDEC' AND PermitId='" + Invoice + "' and  InvoiceNo='" + obj.dr["InvoiceNo"].ToString() + "' order by InvoiceNo";
                    InpaymentClass objinv = new InpaymentClass();
                    objinv.dr = objinv.ret_dr(striW1);
                    if (objinv.dr.Read())
                    {
                        DrpInvoiceNo.Items.FindByText(obj.dr["InvoiceNo"].ToString()).Selected = true;
                    }
                    else
                    {
                        DrpInvoiceNo.Items.FindByText("--Select--").Selected = true;
                    }
                    //DrpInvoiceNo.Items.FindByText(obj.dr["InvoiceNo"].ToString()).Selected = true;                    
                    // DrpInvoiceNo.SelectedItem.Text = obj.dr[16].ToString();
                    string ChkUnitPrice1 = obj.dr["ChkUnitPrice"].ToString();
                    if (ChkUnitPrice1 == "True")
                    {
                        ChkUnitPrice.Checked = true;
                    }
                    else if (ChkUnitPrice1 == "False")
                    {
                        ChkUnitPrice.Checked = false;
                    }
                    ChkUnitPrice_CheckedChanged(null, null);

                    TxtUnitPrice.Text = obj.dr["UnitPrice"].ToString();

                    DRPCurrency.ClearSelection();
                    DRPCurrency.Items.FindByText(obj.dr["UnitPriceCurrency"].ToString()).Selected = true;
                    //DRPCurrency.SelectedItem.Text = obj.dr[19].ToString();
                    TxtExchangeRate.Text = obj.dr["ExchangeRate"].ToString();
                    TxtSumExRate.Text = obj.dr["SumExchangeRate"].ToString();
                    TxtTotalLineAmount.Text = obj.dr["TotalLineAmount"].ToString();
                    TxtTotalLineCharges.Text = obj.dr["InvoiceCharges"].ToString();
                    TxtCIFFOB.Text = obj.dr["CIFFOB"].ToString();


                    TxtOPQty.Text = Math.Round(Convert.ToDecimal(obj.dr["OPQty"].ToString()), 0).ToString();
                    if (TxtOPQty.Text != "0")
                    {
                        ChkPackInfo.Checked = true;
                        ChkPackInfo_CheckedChanged(null, null);
                    }
                    else
                    {
                        ChkPackInfo.Checked = false;
                        ChkPackInfo_CheckedChanged(null, null);
                    }
                    DRPOPQUOM.ClearSelection();
                    DRPOPQUOM.Items.FindByText(obj.dr["OPUOM"].ToString()).Selected = true;



                    // DRPOPQUOM.SelectedItem.Text = obj.dr[26].ToString();
                    TxtIPQty.Text = Math.Round(Convert.ToDecimal(obj.dr["IPQty"].ToString()), 0).ToString();

                    DRPIPQUOM.ClearSelection();
                    DRPIPQUOM.Items.FindByText(obj.dr["IPUOM"].ToString()).Selected = true;
                    // DRPIPQUOM.SelectedItem.Text = obj.dr[28].ToString();
                    TxtINPQty.Text = Math.Round(Convert.ToDecimal(obj.dr["InPqty"].ToString()), 0).ToString();

                    DRPINNPQUOM.ClearSelection();
                    DRPINNPQUOM.Items.FindByText(obj.dr["InPUOM"].ToString()).Selected = true;
                    // DRPINNPQUOM.SelectedItem.Text = obj.dr[30].ToString();
                    TxtIMPQty.Text = Math.Round(Convert.ToDecimal(obj.dr["ImPQty"].ToString()), 0).ToString();

                    DRPIMPQUOM.ClearSelection();
                    DRPIMPQUOM.Items.FindByText(obj.dr["ImPUOM"].ToString()).Selected = true;
                    //DRPIMPQUOM.SelectedItem.Text = obj.dr[32].ToString();
                    DrpPreferentialCode.ClearSelection();
                    DrpPreferentialCode.Items.FindByText(obj.dr["PreferentialCode"].ToString()).Selected = true;
                    // DrpPreferentialCode.SelectedItem.Text = obj.dr[33].ToString();
                    txtlsp.Text = obj.dr["LSPValue"].ToString();
                    ItemGSTRate.Text = obj.dr["GSTRate"].ToString();
                    ItemGSTUOM.Text = obj.dr["GSTUOM"].ToString();
                    TxtItemSumGST.Text = obj.dr["GSTAmount"].ToString();
                    TxtExciseDutyRate.Text = obj.dr["ExciseDutyRate"].ToString();
                    TxtExciseDutyUOM.Text = obj.dr["ExciseDutyUOM"].ToString();
                    TxtSumExciseDuty.Text = obj.dr["ExciseDutyAmount"].ToString();
                    TxtCustomsDutyRate.Text = obj.dr["CustomsDutyRate"].ToString();
                    TxtCustomsDutyUOM.Text = obj.dr["CustomsDutyUOM"].ToString();
                    TxtSumCustomsDuty.Text = obj.dr["CustomsDutyAmount"].ToString();
                    TxtOtherTaxRate.Text = obj.dr["OtherTaxRate"].ToString();


                    DrpOtherUOM.ClearSelection();
                    DrpOtherUOM.Items.FindByText(obj.dr["OtherTaxUOM"].ToString()).Selected = true;
                    //DrpOtherUOM.SelectedItem.Text = obj.dr[44].ToString();
                    TxtSumOtherTaxRate.Text = obj.dr["OtherTaxAmount"].ToString();
                    TxtCurrentLot.Text = obj.dr["CurrentLot"].ToString();


                    if (TxtCurrentLot.Text != "")
                    {
                        Chklot.Checked = true;
                        Chklot_CheckedChanged(null, null);
                    }
                    else
                    {
                        Chklot.Checked = false;
                        Chklot_CheckedChanged(null, null);
                    }

                    DrpMaking.ClearSelection();
                    DrpMaking.Items.FindByText(obj.dr["Making"].ToString()).Selected = true;
                    // DrpMaking.SelectedItem.Text = obj.dr[47].ToString();
                    TxtPreviousLot.Text = obj.dr["PreviousLot"].ToString();
                    txtShippingMarks1.Text = obj.dr["ShippingMarks1"].ToString();
                    txtShippingMarks2.Text = obj.dr["ShippingMarks2"].ToString();
                    txtShippingMarks3.Text = obj.dr["ShippingMarks3"].ToString();
                    txtShippingMarks4.Text = obj.dr["ShippingMarks4"].ToString();
                    if (!string.IsNullOrWhiteSpace(obj.dr["VehicleType"].ToString()))
                    {
                        if (obj.dr["VehicleType"].ToString() != "-Select-")
                        {

                            DrpVehicleType.ClearSelection();
                            DrpVehicleType.Items.FindByText(obj.dr["VehicleType"].ToString()).Selected = true;
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(obj.dr["OptionalChrgeUOM"].ToString()))
                    {
                        if (obj.dr["OptionalChrgeUOM"].ToString() != "-Select-")
                        {
                            DrpOptionalUom.ClearSelection();
                            DrpOptionalUom.Items.FindByText(obj.dr["OptionalChrgeUOM"].ToString()).Selected = true;
                        }
                    }


                    TextBox4.Text = obj.dr["EngineCapcity"].ToString();
                    TxtOptionalPrice.Text = obj.dr["Optioncahrge"].ToString();
                    TxtOptionalExchageRate.Text = obj.dr["OptionalSumtotal"].ToString();
                    TxtOptionalSumExRate.Text = obj.dr["OptionalSumExchage"].ToString();
                    if (!string.IsNullOrWhiteSpace(obj.dr["EngineCapUOM"].ToString()))
                    {
                        if (obj.dr["EngineCapUOM"].ToString() != "-Select-")
                        {
                            DrpVehicleCapacity.ClearSelection();
                            DrpVehicleCapacity.Items.FindByText(obj.dr["EngineCapUOM"].ToString()).Selected = true;
                        }
                    }

                    OriginalRegDate.Text = obj.dr["orignaldatereg"].ToString();


                    editbindProduct1(ID);
                    editbindProduct2(ID);
                    editbindProduct3(ID);
                    string co = "select * from [Country] where CountryCode='" + TxtCountryItem.Text + "'";
                    obj.dr = obj.ret_dr(co);
                    while (obj.dr.Read())
                    {
                        txtcname.Text = obj.dr["Description"].ToString();
                    }

                    ItemAddGrid.Visible = true;
                    ItemDiv.Visible = true;
                    BtnAddNEWItem.Visible = false;
                    DrpInvoiceNo_SelectedIndexChanged(null, null);
                    //HSQTYUOM_SelectedIndexChanged(null, null);
                    return;
                }
                //EditItem();


                catch (Exception ex)
                {
                    ex.ToString();
                }
            }


            Itemclear();

        }

        protected void BtnPPN_Click(object sender, EventArgs e)
        {
            string sent = "Previous Permit Number :";

            txttrdremrk.Text = txttrdremrk.Text + Environment.NewLine + sent + TxtPrevPerNO.Text + Environment.NewLine;

        }

        protected void HSCodeGridItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(ImporterGrid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void HSCodeGridItem_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                //Reference the GridView Row.
                GridViewRow row = HSCodeGridItem.Rows[rowIndex];
                if (row != null)
                {
                    var lblCode1 = row.FindControl("lblName") as Label;
                    var lblName1 = row.FindControl("lblName1") as Label;
                 

                    if (lblCode1 != null && lblName1 != null )
                    {
                        string requestor = lblCode1.Text;
                        string requestType = lblName1.Text;

                        TxtHSCodeItem.Text = "";
                       

                        TxtHSCodeItem.Text = requestor;
                        if (chklockitemdesc.Checked == true)
                        {

                        }
                        else
                        {
                            TxtDescription.Text = "";
                            TxtDescription.Text = requestType;
                        }
                      

                       
                    }
                }
            }
            updatepanel1.Update();
        }

        protected void lnkHSCodeItem_Command(object sender, CommandEventArgs e)
        {
            var lb = (LinkButton)sender;
            var row = (GridViewRow)lb.NamingContainer;
            if (row != null)
            {
              
                var lblName1 = row.FindControl("lblName") as Label;
                var lblName11 = row.FindControl("lblName1") as Label;
              

                if ( lblName1 != null && lblName11 != null )
                {
                    //Get values
                  
                    string requestType = lblName1.Text;
                    string status = lblName11.Text;

                    TxtHSCodeItem.Text = "";
                   

                    TxtHSCodeItem.Text = requestType;

                    if (chklockitemdesc.Checked == true)
                    {

                    }
                    else
                    {
                        TxtDescription.Text = "";
                        TxtDescription.Text = status;
                    }

                 //   TxtDescription.Text = status;

                   

                }

            }
        }

        protected void txtDutiableQty_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btncopyhscode_Click(object sender, EventArgs e)
        {
            obj.exec("update ItemDtl set HSCode='" + txtctd.Text + "' where PermitId='" + txt_code.Text + "'");
            obj.closecon();
            BindItemMaster();
            btncopyhscode.Focus();

        }

        protected void btncopydesc_Click(object sender, EventArgs e)
        {
            obj.exec("update ItemDtl set Description='" + txtctd.Text + "' where PermitId='" + txt_code.Text + "'");
            obj.closecon();
            BindItemMaster();
            btncopyhscode.Focus();
        }

        protected void btncopycoo_Click(object sender, EventArgs e)
        {
            obj.exec("update ItemDtl set Contry='" + txtctd.Text + "' where PermitId='" + txt_code.Text + "'");
            obj.closecon();
            BindItemMaster();
            btncopyhscode.Focus();
        }

        protected void Btnselectitem_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gvrow in AddItemGrid.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("chk");
                if (chk != null & chk.Checked)
                {
                    Label statustype = (Label)gvrow.FindControl("lblID");



                    string P1 = ("delete ItemDtl  where id='" + statustype.Text + "' ");
                    obj.exec(P1);
                    obj.closecon();
                }
            }
            BindItemMaster();
        }

        protected void chk_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void BtnAEO_Click(object sender, EventArgs e)
        {
            DataTable dtCurrent = ViewState["CurrentTable"] as DataTable;

            // Check if current rows are already 5
            if (dtCurrent != null && dtCurrent.Rows.Count >= 5)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You can only add up to 5 rows.');", true);
                return;
            }

            // Check if there are existing rows and validate the last row's inputs
            if (AEOGrid.Rows.Count > 0)
            {
                int lastRowIndex = AEOGrid.Rows.Count - 1;

                TextBox box1 = (TextBox)AEOGrid.Rows[lastRowIndex].Cells[1].FindControl("TextBox1");
                TextBox box2 = (TextBox)AEOGrid.Rows[lastRowIndex].Cells[2].FindControl("TextBox2");
                TextBox box3 = (TextBox)AEOGrid.Rows[lastRowIndex].Cells[3].FindControl("TextBox3");

                if (string.IsNullOrWhiteSpace(box1.Text))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please fill all fields in the previous row before adding a new one.');", true);
                    return;
                }
            }

            if (dtCurrent == null || dtCurrent.Rows.Count == 0)
            {
                SetInitialRow();
            }
            else
            {
                AddNewRowToGridc();
            }

            chkcwc.Focus();
        }

        protected void imgDelete_ClickAEO(object sender, EventArgs e)
        {
            // Get clicked button and row index
            LinkButton btn = (LinkButton)sender;
            int rowIndex = Convert.ToInt32(btn.CommandArgument);

            // Get DataTable from ViewState
            DataTable dt = ViewState["CurrentTable"] as DataTable;

            if (dt != null && dt.Rows.Count > rowIndex)
            {
                // Check if it's the last row
                if (dt.Rows.Count == 1)
                {
                    // Show alert and prevent deletion
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "lastRowAlert",
                        "alert('You cannot delete the last row.');", true);
                    return;
                }

                // Remove the row
                dt.Rows.RemoveAt(rowIndex);

                // Update row numbers
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["RowNumber"] = i + 1;
                }

                // Rebind GridView
                ViewState["CurrentTable"] = dt;
                AEOGrid.DataSource = dt;
                AEOGrid.DataBind();
            }
        }

        protected void imgDelete_ClickCWC(object sender, EventArgs e)
        {
            // Get clicked button and row index
            LinkButton btn = (LinkButton)sender;
            int rowIndex = Convert.ToInt32(btn.CommandArgument);

            // Get DataTable from ViewState
            DataTable dt = ViewState["CurrentTable1"] as DataTable;

            if (dt != null && dt.Rows.Count > rowIndex)
            {
                // Check if it's the last row
                if (dt.Rows.Count == 1)
                {
                    // Show alert and prevent deletion
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "lastRowAlert",
                        "alert('You cannot delete the last row.');", true);
                    return;
                }

                // Remove the row
                dt.Rows.RemoveAt(rowIndex);

                // Update row numbers
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["RowNumber"] = i + 1;
                }

                // Rebind GridView
                ViewState["CurrentTable1"] = dt;
                CWCGrid.DataSource = dt;
                CWCGrid.DataBind();
            }
        }

        protected void imgDelete_ClickSea(object sender, EventArgs e)
        {
            // Get clicked button and row index
            LinkButton btn = (LinkButton)sender;
            int rowIndex = Convert.ToInt32(btn.CommandArgument);

            // Get DataTable from ViewState
            DataTable dt = ViewState["CurrentTable26"] as DataTable;

            if (dt != null && dt.Rows.Count > rowIndex)
            {
                // Check if it's the last row
                if (dt.Rows.Count == 1)
                {
                    // Show alert and prevent deletion
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "lastRowAlert",
                        "alert('You cannot delete the last row.');", true);
                    return;
                }

                // Remove the row
                dt.Rows.RemoveAt(rowIndex);

                // Update row numbers
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["RowNumber"] = i + 1;
                }

                // Rebind GridView
                ViewState["CurrentTable26"] = dt;
                SeaGrid.DataSource = dt;
                SeaGrid.DataBind();
            }
        }

        protected void imgDelete_ClickScheme(object sender, EventArgs e)
        {
            // Get clicked button and row index
            LinkButton btn = (LinkButton)sender;
            int rowIndex = Convert.ToInt32(btn.CommandArgument);

            // Get DataTable from ViewState
            DataTable dt = ViewState["CurrentTable30"] as DataTable;

            if (dt != null && dt.Rows.Count > rowIndex)
            {
                // Check if it's the last row
                if (dt.Rows.Count == 1)
                {
                    // Show alert and prevent deletion
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "lastRowAlert",
                        "alert('You cannot delete the last remaining record.');", true);
                    return;
                }

                // Remove the row
                dt.Rows.RemoveAt(rowIndex);

                // Update row numbers
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["RowNumber"] = i + 1;
                }

                // Rebind GridView
                ViewState["CurrentTable30"] = dt;
                SchemeGrid.DataSource = dt;
                SchemeGrid.DataBind();

                // Optional: Show success message (uncomment if needed)
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "deleteSuccess", 
                //     "alert('Record deleted successfully.');", true);
            }
        }

        protected void imgDelete_ClickSts(object sender, EventArgs e)
        {
            // Get clicked button and row index
            LinkButton btn = (LinkButton)sender;
            int rowIndex = Convert.ToInt32(btn.CommandArgument);

            // Get DataTable from ViewState
            DataTable dt = ViewState["CurrentTable21"] as DataTable;

            if (dt != null)
            {
                // Check if only one row remains
                if (dt.Rows.Count <= 1)
                {
                    // Show alert using ScriptManager
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You cannot delete the last row.');", true);
                    return;
                }

                if (dt.Rows.Count > rowIndex)
                {
                    // Remove the row
                    dt.Rows.RemoveAt(rowIndex);

                    // Update row numbers
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["RowNumber"] = i + 1;
                    }

                    // Rebind GridView
                    ViewState["CurrentTable21"] = dt;
                    StsGrid.DataSource = dt;
                    StsGrid.DataBind();
                }
            }
        }

        protected void imgDelete_ClickStsCwc(object sender, EventArgs e)
        {
            // Get clicked button and row index
            LinkButton btn = (LinkButton)sender;
            int rowIndex = Convert.ToInt32(btn.CommandArgument);

            // Get DataTable from ViewState
            DataTable dt = ViewState["CurrentTable22"] as DataTable;

            if (dt != null)
            {
                // Check if only one row remains
                if (dt.Rows.Count <= 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You cannot delete the last row.');", true);
                    return;
                }

                if (dt.Rows.Count > rowIndex)
                {
                    // Remove the row
                    dt.Rows.RemoveAt(rowIndex);

                    // Update row numbers
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["RowNumber"] = i + 1;
                    }

                    // Rebind GridView
                    ViewState["CurrentTable22"] = dt;
                    StscwcGrid.DataSource = dt;
                    StscwcGrid.DataBind();
                }
            }
        }


        protected void imgDelete_ClickIC(object sender, EventArgs e)
        {
            // Get clicked button and row index
            LinkButton btn = (LinkButton)sender;
            int rowIndex = Convert.ToInt32(btn.CommandArgument);

            // Get DataTable from ViewState
            DataTable dt = ViewState["CurrentTable24"] as DataTable;

            if (dt != null)
            {
                // Prevent deletion if only one row remains
                if (dt.Rows.Count <= 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You cannot delete the last row.');", true);
                    return;
                }

                if (dt.Rows.Count > rowIndex)
                {
                    // Remove the row
                    dt.Rows.RemoveAt(rowIndex);

                    // Update row numbers
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["RowNumber"] = i + 1;
                    }

                    // Rebind GridView
                    ViewState["CurrentTable24"] = dt;
                    IcGrid.DataSource = dt;
                    IcGrid.DataBind();
                }
            }
        }
        

    }
}