using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using RET.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace RET
{
    public partial class InNonPayment : System.Web.UI.Page
    {        
        string TempDataPermitNo = "";
        InnonPaymentClass obj = new InnonPaymentClass();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
        string sqlconn = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
        //string OBLERR = "";
        /*   SqlDataAdapter dastudent;
           DataSet ds_student, ds_course;
           SqlCommand cmdStudent;*/
        public static string uom, exrate, exuom, crate, cuom, kgmvis;
        static string JobNo, MsgNO,refno = "";
        private static int Id = 0;
        private static string Update = "", Status = "New";
        private static string chkstatus = "";
        //private int eid = 0;
        //bool edit = false;
        bool editInvoice = false;
        string ErrorDes = "";
        //string DecAccountID = "";
        static string premStatuschk = "NEW";

        //Autocomplete

        //Declarant Company

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetListofCountries(string prefixText, string DecAccountID)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select * from  DeclarantCompany where AccountID='" + DecAccountID + "' and  Code like '" + prefixText + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@Name", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<string> Deccode1 = new List<string>();
                List<string> DecName = new List<string>();
                List<string> Deccode = new List<string>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {


                    Deccode.Add(dt.Rows[i]["Code"].ToString() + ":" + dt.Rows[i]["Name"].ToString());
                    Deccode1.Add(dt.Rows[i]["Code"].ToString());

                    // string con = String.Concat(Deccode, DecName);


                }
                return Deccode;
            }
        }

        //ImportCode

        //[System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetImpcode(string prefixText)
        {            
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select Top 5 * from  Importer where Code like '" + prefixText.Replace("'", "''") + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@Code", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<string> Deccode1 = new List<string>();
                List<string> DecName = new List<string>();
                List<string> Deccode = new List<string>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Deccode.Add(dt.Rows[i]["Code"].ToString() + ":" + dt.Rows[i]["Name"].ToString());
                    Deccode1.Add(dt.Rows[i]["Code"].ToString());                    
                }
                return Deccode;
            }
        }
        //Inward Code

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetInwcode(string prefixText)
        {            
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select Top 5 * from  InnonInwardCarrierAgent where Code like '" + prefixText.Replace("'", "''") + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@Name", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                List<string> Deccode = new List<string>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Deccode.Add(dt.Rows[i]["Code"].ToString() + ":" + dt.Rows[i]["Name"].ToString());
                }
                return Deccode;
            }
        }
        //freightcode

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetFrieght(string prefixText)
        {            
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select Top 5 * from  FreightForwarder where Code like '" + prefixText.Replace("'", "''") + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@Name", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<string> Deccode = new List<string>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Deccode.Add(dt.Rows[i]["Code"].ToString() + ":" + dt.Rows[i]["Name"].ToString());
                }
                return Deccode;
            }
        }
        //Outward
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetOutwardCar(string prefixText)
        {            
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select Top 5 * from  InnonOutwardCarrierAgent where Code like '" + prefixText.Replace("'", "''") + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@Name", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<string> Deccode = new List<string>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Deccode.Add(dt.Rows[i]["Code"].ToString() + ":" + dt.Rows[i]["Name"].ToString());
                }
                return Deccode;
            }
        }
        //Claimanity
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetClaimanity(string prefixText)
        {            
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select Top 5 * from  InnonClaimantParty where Name like '" + prefixText.Replace("'", "''") + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@Name", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                List<string> Deccode = new List<string>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Deccode.Add(dt.Rows[i]["Name"].ToString() + ":" + dt.Rows[i]["Name1"].ToString());
                }
                return Deccode;
            }
        }
        //Consignee
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetCosigncode(string prefixText)
        {            
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select Top 5 * from  InnonConsignee where ConsigneeCode like '" + prefixText.Replace("'", "''") + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@ConsigneeCode", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<string> Deccode = new List<string>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Deccode.Add(dt.Rows[i]["ConsigneeCode"].ToString() + ":" + dt.Rows[i]["ConsigneeName"].ToString());
                }
                return Deccode;
            }
        }
        //Exporter
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetExpcode(string prefixText)
        {            
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select Top 5 * from  InnonExporter where Code like '" + prefixText.Replace("'", "''") + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@Code", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<string> Deccode = new List<string>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Deccode.Add(dt.Rows[i]["Code"].ToString() + ":" + dt.Rows[i]["Name"].ToString());
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
                SqlCommand cmd = new SqlCommand("select * from  LoadingPort where PortCode like '" + prefixText.Replace("'", "''") + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@PortCode", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                List<string> Deccode = new List<string>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {


                     Deccode.Add(dt.Rows[i]["PortCode"].ToString() + ":" + dt.Rows[i]["PortName"].ToString());
                    //Deccode.Add(dt.Rows[i]["PortCode"].ToString());


                    // string con = String.Concat(Deccode, DecName);


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

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetStrgLoc(string prefixText)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select Top 10 Code,Description from  StorageLocation where Code like '" + prefixText.Replace("'", "''") + "%' ", sqlconn);
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
                SqlCommand cmd = new SqlCommand("select * from  INNONSUPPLIERMANUFACTURERPARTY where Code like '" + prefixText.Replace("'", "''") + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@Name", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                List<string> Deccode = new List<string>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {


                    //Deccode.Add(dt.Rows[i]["Code"].ToString() + ":" + dt.Rows[i]["Name"].ToString());
                    Deccode.Add(dt.Rows[i]["Code"].ToString());


                    // string con = String.Concat(Deccode, DecName);


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
                SqlCommand cmd = new SqlCommand("select * from  Importer where Code like '" + prefixText.Replace("'", "''") + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@Name", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                List<string> Deccode = new List<string>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {


                    Deccode.Add(dt.Rows[i]["Code"].ToString() + ":" + dt.Rows[i]["Name"].ToString());


                    // string con = String.Concat(Deccode, DecName);


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
                SqlCommand cmd = new SqlCommand("select * from  InhouseItemCode where InhouseCode like '" + prefixText.Replace("'", "''") + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@InhouseCode", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                List<string> Deccode = new List<string>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {


                    Deccode.Add(dt.Rows[i]["InhouseCode"].ToString());


                    // string con = String.Concat(Deccode, DecName);


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
                SqlCommand cmd = new SqlCommand("select DISTINCT Top 8 HSCode,Description, is_innonpayment_controlled from  HSCode where HSCode like '" + prefixText.Replace("'", "''") + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@HSCode", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet dshsc = new DataSet();
                //DataTable dt = new DataTable();
                da.Fill(dshsc);

                List<string> Deccode = new List<string>();

                for (int i = 0; i < dshsc.Tables[0].Rows.Count; i++)
                {
                    Deccode.Add(dshsc.Tables[0].Rows[i]["HSCode"].ToString() + ":" + dshsc.Tables[0].Rows[i]["Description"].ToString());
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
                SqlCommand cmd = new SqlCommand("select * from  Country where CountryCode like '" + prefixText.Replace("'", "''") + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@Description", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                List<string> Deccode = new List<string>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {


                    Deccode.Add(dt.Rows[i]["CountryCode"].ToString() + ":" + dt.Rows[i]["Description"].ToString());


                    // string con = String.Concat(Deccode, DecName);


                }
                return Deccode;
            }
        }


        //Discharge Port

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> DischargePort(string prefixText)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select * from  LoadingPort where PortCode like '" + prefixText.Replace("'", "''") + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@Description", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                List<string> Deccode = new List<string>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {


                    Deccode.Add(dt.Rows[i]["PortCode"].ToString() + ":" + dt.Rows[i]["PortName"].ToString());


                    // string con = String.Concat(Deccode, DecName);


                }
                return Deccode;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
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
            lblerror.Text = "";
            lblsameerror.Text = "";
            string DecAccountID = Session["AccountId"].ToString();
            string MailboxId = "";
            string aa = "select Top 1 Mailboxid from ManageUser where UserId='" + Session["UserId"].ToString() + "'";
            obj.dr = obj.ret_dr(aa);
            if (obj.dr.Read())
            {

                MailboxId = obj.dr["Mailboxid"].ToString();
            }

            string qry111 = "SELECT Top 1 TradeNetMailboxID,DeclarantName,DeclarantCode,DeclarantTel,CRUEI  from DeclarantCompany a,ManageUser b  where a.AccountID=b.AccountId and a.TradeNetMailboxID=b.Mailboxid and b.UserId='" + Session["UserId"].ToString() + "' and b.MailBoxid='" + MailboxId + "'  group by TradeNetMailboxID,DeclarantName,DeclarantCode,DeclarantTel,CRUEI";

            //  string qry111 = "select TradeNetMailboxID,DeclarantName,DeclarantCode,DeclarantTel,CRUEI  from DeclarantCompany where AccountID='" + Session["AccountId"].ToString() + "' ";
            obj.dr = obj.ret_dr(qry111);
            while (obj.dr.Read())
            {
                TxtTradeMailID.Text = obj.dr["TradeNetMailboxID"].ToString();
                TxtDecName.Text = obj.dr["DeclarantName"].ToString();
                TxtDecCode.Text = obj.dr["DeclarantCode"].ToString();
                TxtDecTelephone.Text = obj.dr["DeclarantTel"].ToString();
                TxtCRUEINO.Text = obj.dr["CRUEI"].ToString();
            }
            ContarinerGrid.RowDataBound += ContarinerGrid_RowDataBound;
            //BindInvoice();
            //BindItemMaster();
            SummaryCalculate();
            if (!IsPostBack)
            {
                chkstatus = "NEW";
                Session["Edit"] = true;
                Session["Id"] = Convert.ToInt32(Request.QueryString["Id"]);
                Session["Update"] = Convert.ToString(Request.QueryString["Update"]);
                Id = Convert.ToInt32(Request.QueryString["Id"]);
                Update = Convert.ToString(Request.QueryString["Update"]);


                cargo.Visible = true;
                Inward.Visible = true;
                Outward.Visible = false;
                btnSeaStr.Visible = true;
                divstrge.Visible = true;
                if (TxtTradeMailID.Text == "")
                {
                    TxtTradeMailID.BackColor = Color.Red;
                }
                if (chkaeo.Checked == true && chkcwc.Checked == true && ChkSea1.Checked == true)
                {
                    AEO.Visible = true;
                    CWC.Visible = true;
                    SEA.Visible = true;
                    return;
                }
                else if (chkaeo.Checked == true)
                {
                    AEO.Visible = true;
                    CWC.Visible = false;
                    SEA.Visible = false;
                }
                else if (chkcwc.Checked == true)
                {
                    AEO.Visible = false;
                    CWC.Visible = true;
                    SEA.Visible = false;
                }
                else if (ChkSea1.Checked == true)
                {
                    AEO.Visible = false;
                    CWC.Visible = false;
                    SEA.Visible = true;
                }
                else
                {
                    AEO.Visible = false;
                    CWC.Visible = false;
                    SEA.Visible = false;
                }

                if (ChkRefDoc.Checked == true)
                {
                    Document.Visible = true;
                }
                else
                {
                    Document.Visible = false;
                }
                if (ChkUnitPrice.Checked == true)
                {
                    TxtUnitPrice.Visible = true;
                    TxtSumExRate.Visible = true;
                }
                else
                {
                    TxtUnitPrice.Visible = false;
                    TxtSumExRate.Visible = false;
                }
                BindClaimant();
                BindOutward();
                BindExporter();
                BindConsignee();
                //BindInvoice();
                //BindItemMaster();
                BindExportPort();
                InwardFlight.Visible = false;
                InwardSea.Visible = false;
                InwardOther.Visible = false;
                //ContainerDetails.Visible = false;
                decBindGrid();
                BindImport();
                BindInward();
                BindFrieght();

                //CARGO+
                ContarinerGrid.RowDataBound += ContarinerGrid_RowDataBound;
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
                OUTWARDFlight.Visible = false;
                OUTWARDSea.Visible = false;
                OUTWARDVesl.Visible = false;
                OUTWARDOther.Visible = false;
                GST.Visible = false;
                //item
                BindInhouse();
                BindHSCode();
                BindCountry();


                BindProduct1();
                //BindProduct2();
                //BindProduct3();
                //BindProduct4();
                //BindProduct5();
                BindLastPort();
                BindNextPort();
                if (ChkRefDoc.Checked == true)
                {
                    Document.Visible = true;
                }
                else
                {
                    Document.Visible = false;
                }
                DrpDecType_SelectedIndexChanged(null, null);
               
                //DrpCargoPackType_SelectedIndexChanged(null, null);
                ChkSea_CheckedChanged(null, null);


                //

                //  InvoiceNo();                
                PermitNO();
                refid();
                JobNO();
                MSGNO();

                InvoiceNo();
                ItemNO();
                //BindInvoice();
                //BindItemMaster();
                InvoiceGrid.Visible = true;
                InvoiceDiv.Visible = true;

                ItemAddGrid.Visible = true;
                ItemDiv.Visible = true;


                SetInitialRow();
                SetInitialRow1cp();
                SetInitialRow2cp();
                SetInitialRow2cpScheme();
                SetInitialRow2cpSts();
                SetInitialRow2cpStscwc();
                //cpc
                SetInitialRowc();
                SetInitialRow2cpIc();

                this.BindGrid();

                //Reason Cancel
                string aa1 = "select Top 15 Id,Name +' : '+ Description AS Description from [CommonMaster] where TypeId='75' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(aa1);
                obj.BindDropDown(DrpReasonCancel, obj.dr, "Id", "Description");

                //Cancel
                string can = "select Top 45 Id,Name from [CommonMaster] where TypeId='5' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(can);
                obj.BindDropDown(DrpDocumenttype, obj.dr, "Id", "Name");

                //vessel nat
                string stqrn = "select Top 245 Id,CountryCode+' : '+Description as Description from [Country]  order by Description";
                obj.dr = obj.ret_dr(stqrn);
                obj.BindDropDown(DroVesslNat, obj.dr, "Id", "Description");

                //Country
                string stqr = "select Top 245 Id,CountryCode +' : '+ Description AS Description from [Country]  order by Description";
                obj.dr = obj.ret_dr(stqr);
                obj.BindDropDown(DrpFinalDesCountry, obj.dr, "Id", "Description");

                //Declaration Type
                string str = "select Top 15 Id,Name from [CommonMaster] where TypeId='13' and StatusID=1 order by Name";
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

                //OutwardtrasMode
                string s = "select Top 10 Id,Name from [CommonMaster] where TypeId='3' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(s);
                obj.BindDropDown(DrpOutwardtrasMode, obj.dr, "Id", "Name");





                //BGIndicator
                string str111 = "select Top 2 Id,Name from [CommonMaster] where TypeId='4' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(str111);
                obj.BindDropDown(DrpBGIndicator, obj.dr, "Id", "Name");

                //DocType
                string str1111 = "select Top 45 Id,Name from [CommonMaster] where TypeId='5' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(str1111);
                obj.BindDropDown(DrpDocType, obj.dr, "Id", "Name");

                //VesselType
                string VesStr = "select Top 15 Id,Name from [CommonMaster] where TypeId='14' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(VesStr);
                obj.BindDropDown(ddpVessel, obj.dr, "Id", "Name");

                //vessel nat
                string stqqrn = "select Top 245 Id,CountryCode+' : '+Description as Description from [Country]  order by Description";
                obj.dr = obj.ret_dr(stqqrn);
                obj.BindDropDown(DroVesslNat, obj.dr, "Id", "Description");

                //invoice
                string strss = "select Top 10 Id,Name from [CommonMaster] where TypeId='7' and StatusID=1 order by Name";
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
                string str7w = "select Top 30 Id,Name from [CommonMaster] where TypeId='9' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(str7w);
                obj.BindDropDown(DrpOptionalUom, obj.dr, "Id", "Name");


                //TCurrency2
                string str4 = "select  Id,Currency from [Currency]  order by Currency";
                obj.dr = obj.ret_dr(str4);
                obj.BindDropDown(Drpcurrency2, obj.dr, "Id", "Currency");

                //Currency3
                string str5 = "select  Id,Currency from [Currency]  order by Currency";
                obj.dr = obj.ret_dr(str5);
                obj.BindDropDown(Drpcurrency3, obj.dr, "Id", "Currency");

                //Currency4
                string str5s = "select  Id,Currency from [Currency]  order by Currency";
                obj.dr = obj.ret_dr(str5s);
                obj.BindDropDown(Drpcurrency4, obj.dr, "Id", "Currency");
                //item


                //DrpOtherUOM
                string strsaa = "select Top 60 Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(strsaa);
                obj.BindDropDown(DrpOtherUOM, obj.dr, "Id", "Name");


                //DrpMaking 
                string stra = "select Top 2 Id,Name from [CommonMaster] where TypeId='12' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(stra);
                obj.BindDropDown(DrpMaking, obj.dr, "Id", "Name");

                //DrpPreferentialCode
                string stdr = "select Top 5 Id,Name from [CommonMaster] where TypeId='11' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(stdr);
                obj.BindDropDown(DrpPreferentialCode, obj.dr, "Id", "Name");

                //TDQ
                string striW = "select Top 20 Id,InvoiceNo from [InNonInvoiceDtl] where MessageType='INPDEC' AND PermitId='" + txt_code.Text + "'  order by InvoiceNo";
                obj.dr = obj.ret_dr(striW);
                obj.BindDropDown(DrpInvoiceNo, obj.dr, "Id", "InvoiceNo");

                //TDQ
                string stri = "select Top 60 Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(stri);
                obj.BindDropDown(TDQUOM, obj.dr, "Id", "Name");

                string stri1 = "select Top 60 Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(stri1);
                obj.BindDropDown(ddptotDutiableQty, obj.dr, "Id", "Name");

                //TDQ
                string str1i = "select Top 60 Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(str1i);
                obj.BindDropDown(HSQTYUOM, obj.dr, "Id", "Name");

                //TDQ
                string str2i = "select Top 60 Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(str2i);
                obj.BindDropDown(DRPOPQUOM, obj.dr, "Id", "Name");

                //TDQ
                string str3 = "select Top 60 Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(str3);
                obj.BindDropDown(DRPIPQUOM, obj.dr, "Id", "Name");

                //TDQ
                string str5i = "select Top 60 Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(str5i);
                obj.BindDropDown(DRPINNPQUOM, obj.dr, "Id", "Name");

                //TDQ
                string str6 = "select Top 60 Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(str6);
                obj.BindDropDown(DRPIMPQUOM, obj.dr, "Id", "Name");

                //TDQ
                string str7 = "select  Id,Currency from [Currency]  order by Currency";
                obj.dr = obj.ret_dr(str7);
                obj.BindDropDown(DRPCurrency, obj.dr, "Id", "Currency");

                //P1
                string P1 = "select Top 60 Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(P1);
                obj.BindDropDown(DrpP1, obj.dr, "Id", "Name");

                //P2
                string P2 = "select Top 60 Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(P2);
                obj.BindDropDown(DrpP2, obj.dr, "Id", "Name");

                //P3
                string P3 = "select Top 60 Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(P3);
                obj.BindDropDown(DrpP3, obj.dr, "Name", "Name");

                //P4
                string P4 = "select Top 60 Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(P4);
                obj.BindDropDown(DrpP4, obj.dr, "Id", "Name");

                //P5
                string P5 = "select Top 60 Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(P5);
                obj.BindDropDown(DrpP5, obj.dr, "Id", "Name");

                //vehicletype
                string vehicle = "select Top 5 Id,Name from [CommonMaster] where TypeId='20' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(vehicle);
                obj.BindDropDown(DrpVehicleType, obj.dr, "Id", "Name");

                //engine
                string engine = "select Top 5 Id,Name from [CommonMaster] where TypeId='21' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(engine);
                obj.BindDropDown(DrpVehicleCapacity, obj.dr, "Id", "Name");

                DrpOutwardtrasMode_SelectedIndexChanged(null, null);

                ProductCode1();
                ProductCode2();
                ProductCode3();
                ProductCode4();
                ProductCode5();
                BindStoreLocation();

                // Cargo UOM
                string str6s = "select Top 60 Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(str6s);
                obj.BindDropDown(DrptotalOuterPack, obj.dr, "Id", "Name");

                string str6ss = "select Top 60 Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(str6ss);
                obj.BindDropDown(DrpTotalGrossWeight, obj.dr, "Id", "Name");

                string drpv = "select Top 245 Id,CountryCode+' : '+Description as Description from [Country]  order by Description";
                obj.dr = obj.ret_dr(drpv);
                obj.BindDropDown(DroVesslNat, obj.dr, "Id", "Description");

                if (DrpInwardtrasMode.SelectedItem.ToString() != "--Select--")
                {
                    string TransMode = DrpInwardtrasMode.SelectedItem.ToString();
                    TextMode.Text = TransMode;
                    InwardFlight.Visible = false;
                    InwardSea.Visible = false;
                    InwardOther.Visible = false;
                    //ContainerDetails.Visible = false;
                    if (TextMode.Text == "1 : Sea")
                    {
                        InwardSea.Visible = true;
                        //ContainerDetails.Visible = false;
                        DrpTotalGrossWeight.Items.Clear();
                        DrpTotalGrossWeight.Items.Add("KGM");
                        DrpTotalGrossWeight.Items.Add("TNE");
                        DrpTotalGrossWeight.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
                    }
                    else if (TextMode.Text == "2 : Rail" || TextMode.Text == "5 : Mail" || TextMode.Text == "7 : Pipeline" || TextMode.Text == "N : Not Required" || TextMode.Text == "6 : Multi-model(Not in use)")
                    {
                        InwardOther.Visible = true;
                        //ContainerDetails.Visible = true;

                        string str6ss1 = "select Top 60 Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                        obj.dr = obj.ret_dr(str6ss1);
                        obj.BindDropDown(DroVesslNat, obj.dr, "Id", "Name");
                    }

                    else if (TextMode.Text == "4 : Air")
                    {
                        InwardFlight.Visible = true;
                        //ContainerDetails.Visible = true;
                        DrpTotalGrossWeight.Items.Clear();
                        DrpTotalGrossWeight.Items.Add("KGM");
                        DrpTotalGrossWeight.Items.Add("TNE");
                        DrpTotalGrossWeight.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
                    }
                    else if (TextMode.Text == "3 : Road")
                    {
                        InwardOther.Visible = true;
                        //ContainerDetails.Visible = true;
                        DrpTotalGrossWeight.Items.Clear();
                        DrpTotalGrossWeight.Items.Add("KGM");
                        DrpTotalGrossWeight.Items.Add("TNE");
                        DrpTotalGrossWeight.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
                    }
                }
                TxtHAWB.Items.Add(" ");
                txtOutHAWB1.Items.Add(" ");
                string temp = "select Top 1 PermitId from InNonpaymentTemp where  PermitId='" + txt_code.Text + "' and TouchUser='" + Session["UserId"].ToString() + "'";
                obj.dr = obj.ret_dr(temp);
                if (obj.dr.Read())
                {

                    TempDataPermitNo = obj.dr["PermitId"].ToString();
                    InnonPaymentEdit();
                }

                divcancel.Visible = false;
                divamend.Visible = false;
                if (Update != "")
                {
                    divamend.Visible = false;
                    if (string.IsNullOrWhiteSpace(Update))
                    {
                        DeclBtn.Visible = true;
                        DeclInd.Visible = true;
                        upinnonsummary.Update();
                    }
                    if (Update == "AMEND")
                    {

                        divcancel.Visible = false;
                        divamend.Visible = true;

                        AmendInd.Visible = true;
                        Amendbtn.Visible = true;
                        chkstatus = "AMEND";
                        btnnextsum.Visible = true;
                        Amend.Visible = true;
                        Cancel.Visible = false;
                        // Refund.Visible = false;
                        InnonPaymentClass lod12 = new InnonPaymentClass();
                        lod12.dr = lod12.ret_dr("select PermitNumber from InNonHeaderTbl where Id='" + Id + "'");
                        if (lod12.dr.HasRows)
                        {
                            while (lod12.dr.Read())
                            {
                                int value = 0;
                                InnonPaymentClass obj4 = new InnonPaymentClass();
                                obj4.dr = obj4.ret_dr("select Count(PermitNumber) from InNonHeaderTbl where PermitNumber='" + lod12.dr["PermitNumber"].ToString() + "' and (Status='APR' or Status='AME') and prmtStatus='AMD'");
                                if (obj4.dr.HasRows)
                                {
                                    while (obj4.dr.Read())
                                    {
                                        value = Convert.ToInt16(obj4.dr[0].ToString());
                                        value = value + 1;
                                    }
                                }
                                txtamoundcount.Text = value.ToString();
                                txtamendpermit.Text = lod12.dr["PermitNumber"].ToString();
                                txtupdateindicator.Text = "AME";
                                upinnonsummary.Update();
                            }
                        }
                        lod12.dr = lod12.ret_dr("select * from InNonAmend where Permitno='" + txtamendpermit.Text + "'");
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
                        upinnonamend.Update();
                    }
                    if (Update == "CANCEL")
                    {

                        divcancel.Visible = true;
                        divamend.Visible = false;

                      
                        CancelInd.Visible = true;
                        CancelBtn.Visible = true;
                        chkstatus = "CANCEL";
                        btnnextsum.Visible = true;
                        Cancel.Visible = true;
                        Amend.Visible = false;
                        InnonPaymentClass lod12 = new InnonPaymentClass();
                        lod12.dr = lod12.ret_dr("select PermitNumber from InNonHeaderTbl where Id='" + Id + "'");
                        if (lod12.dr.HasRows)
                        {
                            while (lod12.dr.Read())
                            {
                                txtcanPermit.Text = lod12.dr["PermitNumber"].ToString();
                                txtupdateInd.Text = "CNL";
                                upinnoncancel.Update();
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
                                    CheckBox4.Checked = true;
                                }
                                else
                                {
                                    CheckBox4.Checked = false;
                                }
                            }
                        }
                        upinnoncancel.Update();
                    }

                }
                if (Id != 0)
                {
                    InnonPaymentEdit();
                    //eid = 1;
                    //Id = 0;
                    return;
                }
                else
                {
                }
                DrpDecType.Focus();


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
            }



            if (DrpTerms.SelectedItem.ToString() != "--Select--")
            {

                if (DrpTerms.SelectedItem.ToString() == "CFR : Cost and Frieght ( also known as C & F )")
                {
                    TotalInvoice.Visible = true;
                    OtherTaxableCharge.Visible = true;
                    FrieghtCharges.Visible = false;
                    InsuranceCharges.Visible = true;
                    CostInsuranceandFreight.Visible = true;
                    GST.Visible = true;
                }
                else if (DrpTerms.SelectedItem.ToString() == "CIF : Cost,Insurance and Frieght")
                {
                    TotalInvoice.Visible = true;
                    OtherTaxableCharge.Visible = true;
                    FrieghtCharges.Visible = false;
                    InsuranceCharges.Visible = false;
                    CostInsuranceandFreight.Visible = true;
                    GST.Visible = true;
                }
                else if (DrpTerms.SelectedItem.ToString() == "EXW : Exw Works (also known as Ex-Factory)")
                {
                    TotalInvoice.Visible = true;
                    OtherTaxableCharge.Visible = true;
                    FrieghtCharges.Visible = true;
                    InsuranceCharges.Visible = true;
                    CostInsuranceandFreight.Visible = true;
                    GST.Visible = true;
                }
                else if (DrpTerms.SelectedItem.ToString() == "CNI : Cost and Insurance (also Known as C & I )")
                {
                    TotalInvoice.Visible = true;
                    OtherTaxableCharge.Visible = true;
                    FrieghtCharges.Visible = true;
                    InsuranceCharges.Visible = false;
                    CostInsuranceandFreight.Visible = true;
                    GST.Visible = true;
                }
                else if (DrpTerms.SelectedItem.ToString() == "FAS : Free Alongside Ship")
                {
                    TotalInvoice.Visible = true;
                    OtherTaxableCharge.Visible = true;
                    FrieghtCharges.Visible = true;
                    InsuranceCharges.Visible = true;
                    CostInsuranceandFreight.Visible = true;
                    GST.Visible = true;
                }
                else if (DrpTerms.SelectedItem.ToString() == "FOB : Free On Board")
                {
                    TotalInvoice.Visible = true;
                    OtherTaxableCharge.Visible = true;
                    FrieghtCharges.Visible = true;
                    InsuranceCharges.Visible = true;
                    CostInsuranceandFreight.Visible = true;
                    GST.Visible = true;
                }



            }
            else
            {
                TotalInvoice.Visible = true;
                OtherTaxableCharge.Visible = true;
                FrieghtCharges.Visible = true;
                InsuranceCharges.Visible = true;
                CostInsuranceandFreight.Visible = true;
                GST.Visible = true;
            }
            BindInvoice();
            BindItemMaster();
            OUTWARDOcenbill_TextChanged(null, null);
            OUTWARDAirwaybill_TextChanged(null, null);
            txtouthblCargo_TextChanged(null, null);
        }
        private void editcontainer()
        {
            SqlConnection con = new SqlConnection(sqlconn);
            //SqlCommand cmd1 = new SqlCommand("SELECT T1.Id ,T1.CRP,T1.CompanyName,T1.Name,T1.EmailId,T1.Mobile, T2.Name as Rent ,t1.BudgetFrom,T1.BudgetTo ,T3.Name as Type,T4.Name as Location,T5.PropertyRef,T1.MultipleLocation,T1. MultipleProperty  FROM (select a.Id,a.CompanyName,a.Name,a.EmailId,a.Mobile,a.BudgetFrom,a.BudgetTo,b.Name as CRP,a.MultipleLocation,a.MultipleProperty  from lead a,CommonMaster b where a.Per_Com=b.Id and a.TouchUser='" + Touch_user + "') AS T1 JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.RentorBuy=b.Id) AS T2    ON T1.Id = T2.Id    JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Type=b.Id) AS T3  ON T1.Id = T3.Id     JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Location=b.Id) AS T4   ON T1.Id = T4.Id    JOIN ( select b.ID,b.Name,a.PropertyRef  from Lead_List a,Lead b where a.ParentId=b.Id) AS T5   ON T1.Id = T5.Id order by T1.Id desc", con);
            SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,ContainerNo as Column1, Size as Column2,Weight as Column3, SealNo as Column4 from InNonHeaderTbl a,InnonContainerDtl b where a.PermitId=b.PermitId and a.PermitId='" + txt_code.Text + "' order by RowNo", con);
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            if (dt.Rows.Count <= 0)
            {
                dt.Rows.Add(0);
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
            string qry = "select RowNo as RowNumber,ProcessingCode1,ProcessingCode2,ProcessingCode3 from InNonHeaderTbl a,InNonCPCDtl b where a.PermitId=b.PermitId and b.CPCType='AEO' and a.PermitId='" + txt_code.Text + "'";
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

            ViewState["CurrentTable"] = dt;
            AEOGrid.DataSource = ViewState["CurrentTable"] as DataTable;
            AEOGrid.DataBind();

            string ccc = "";
            obj.dr = obj.ret_dr(qry);
            while (obj.dr.Read())
            {
                ccc = obj.dr["ProcessingCode1"].ToString();
            }
            if (ccc == "")
            {
                AEO.Visible = true;
                chkaeo.Checked = false;
            }
            else
            {
                AEO.Visible = true;
                chkaeo.Checked = true;
            }


            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt1 = (DataTable)ViewState["CurrentTable"];
                if (dt1.Rows.Count > 0)
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                       
                        TextBox box1 = (TextBox)AEOGrid.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                        TextBox box2 = (TextBox)AEOGrid.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                        TextBox box3 = (TextBox)AEOGrid.Rows[rowIndex].Cells[3].FindControl("TextBox3");
                        box1.Text = dt1.Rows[i]["ProcessingCode1"].ToString();
                        box2.Text = dt1.Rows[i]["ProcessingCode2"].ToString();
                        box3.Text = dt1.Rows[i]["ProcessingCode3"].ToString();
                        rowIndex++;
                    }
                }
            }

          

        }
        private void editCPCcwc()
        {
            string qry = "select RowNo as RowNumber,ProcessingCode1,ProcessingCode2,ProcessingCode3 from InNonHeaderTbl a,InNonCPCDtl b where a.PermitId=b.PermitId and b.CPCType='CWC' and a.PermitId='" + txt_code.Text + "'";
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

            ViewState["CurrentTable1"] = dt;
            CWCGrid.DataSource = ViewState["CurrentTable1"] as DataTable;
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
                CWC.Visible = false;
            }
            else
            {
                chkcwc.Checked = true;
                CWC.Visible = true;
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
            upinnoncpc.Update();
        }
        private void editCPCSeastore()
        {
            string qry = "select RowNo as RowNumber,ProcessingCode1,ProcessingCode2,ProcessingCode3 from InNonHeaderTbl a,InNonCPCDtl b where a.PermitId=b.PermitId and b.CPCType='SEASTORE' and a.PermitId='" + txt_code.Text + "'";
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
    
        private void EditDocument()
        {
            const int maxTotalSizeKB = 20000;
            long totalKB = 0;

            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT Id, DocumentType, Name, FileSizeKB FROM InNonFile WHERE InPaymentId = @InPaymentId";
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
        public void InnonPaymentEdit()
        {
            try
            {
                BtnPrintCIF.Visible = true;
                //vessel nat
                string stqrn = "select Id,CountryCode+' : '+Description as Description from [Country]  order by Description";
                obj.dr = obj.ret_dr(stqrn);
                obj.BindDropDown(DroVesslNat, obj.dr, "Id", "Description");

                string DecCompany, Importer, inwardcarrier, ff, climant, Exporter, outward, consignee = "";
                string strBindTxtBox = "";
                if (TempDataPermitNo != "")
                {
                    strBindTxtBox = "select * from [InNonpaymentTemp] where PermitID='" + TempDataPermitNo + "' and TouchUser='" + Session["UserId"].ToString() + "'";
                }
                else
                {
                    strBindTxtBox = "select * from [InNonHeaderTbl] where Id=" + Id;
                }


                // string strBindTxtBox = "select * from [InNonHeaderTbl] where Id=" + Id;
                obj.dr = obj.ret_dr(strBindTxtBox);
                while (obj.dr.Read())
                {
                    premStatuschk = obj.dr["prmtStatus"].ToString();
                    refno = obj.dr["Refid"].ToString();
                    JobNo = obj.dr["JobId"].ToString();
                    MsgNO = obj.dr["MSGId"].ToString();
                    Status = obj.dr["Status"].ToString();
                    txt_code.Text = obj.dr["PermitId"].ToString();
                    //TxtTradeMailID.Text = obj.dr["TradeNetMailboxID"].ToString();
                    TxtMsgType.Text = obj.dr["MessageType"].ToString();
                    DrpDecType.ClearSelection();
                    DrpDecType.Items.FindByText(obj.dr["DeclarationType"].ToString()).Selected = true;
                    DrpDecType_SelectedIndexChanged(null, null);
                    //DrpDecType.SelectedItem.Text = obj.dr[6].ToString();
                    DrpCargoPackType.ClearSelection();
                    DrpCargoPackType.Items.FindByText(obj.dr["CargoPackType"].ToString()).Selected = true;
                    DrpCargoPackType_SelectedIndexChanged(null, null);
                    // DrpCargoPackType.SelectedItem.Text = obj.dr[7].ToString();

                    DrpInwardtrasMode.ClearSelection();
                    DrpInwardtrasMode.Items.FindByText(obj.dr["InwardTransportMode"].ToString()).Selected = true;
                    DrpInwardtrasMode_SelectedIndexChanged(null, null);
                    DrpOutwardtrasMode.ClearSelection();
                    DrpOutwardtrasMode.Items.FindByText(obj.dr["OutwardTransportMode"].ToString()).Selected = true;
                    DrpOutwardtrasMode_SelectedIndexChanged(null, null);
                    //DrpOutwardtrasMode.SelectedItem.Text = obj.dr[9].ToString();

                    DrpBGIndicator.ClearSelection();
                    DrpBGIndicator.Items.FindByText(obj.dr["BGIndicator"].ToString()).Selected = true;
                    //DrpBGIndicator.SelectedItem.Text = obj.dr[9].ToString();
                    string ChkSupplyIndicator1 = obj.dr["SupplyIndicator"].ToString();
                    if (ChkSupplyIndicator1 == "True" || ChkSupplyIndicator1 == "true")
                    {
                        ChkSupplyIndicator.Checked = true;
                    }
                    else if (ChkSupplyIndicator1 == "False" || ChkSupplyIndicator1 == "false")
                    {
                        ChkSupplyIndicator.Checked = false;
                    }
                    string ChkRefDoc1 = obj.dr["ReferenceDocuments"].ToString();
                    if (ChkRefDoc1 == "True" || ChkRefDoc1 == "true")
                    {
                        ChkRefDoc.Checked = true;
                    }
                    else if (ChkRefDoc1 == "False" || ChkRefDoc1 == "false")
                    {
                        ChkRefDoc.Checked = false;
                    }

                    string seastr = obj.dr["seastore"].ToString();
                    if (seastr == "True" || seastr == "true")
                    {
                        chkSea.Checked = true;
                    }
                    else if (seastr == "False" || seastr == "false")
                    {
                        chkSea.Checked = false;
                    }
                    string cnb = obj.dr["Cnb"].ToString();
                    if (cnb == "True" || cnb == "true")
                    {
                        chkcnb.Checked = true;
                    }
                    else if (cnb == "False" || cnb == "false")
                    {
                        chkcnb.Checked = false;
                    }

                    chkSea_CheckedChanged1(null, null);


                    string Licence = obj.dr["License"].ToString();
                    char[] delimiters = { '-' };
                    string[] splitLicence = Licence.Split(delimiters); //will split names using comma as delimiter
                    TxtLicense1.Text = splitLicence[0].ToString();
                    TxtLicense2.Text = splitLicence[1].ToString();
                    TxtLicense3.Text = splitLicence[2].ToString();
                    TxtLicense4.Text = splitLicence[3].ToString();
                    TxtLicense5.Text = splitLicence[4].ToString();
                    EditDocument();

                    string Receipt = obj.dr["Recipient"].ToString();
                    char[] Receipt1 = { '-' };
                    string[] Receipt12 = Receipt.Split(Receipt1); //will split names using comma as delimiter
                    TxtRECPT1.Text = Receipt12[0].ToString();
                    TxtRECPT2.Text = Receipt12[1].ToString();
                    TxtRECPT3.Text = Receipt12[2].ToString();

                    TxtPrevPerNO.Text = obj.dr["PreviousPermit"].ToString();
                    TextMode.Text = obj.dr["InwardTransportMode"].ToString();

                    if (Convert.ToDateTime(obj.dr["ArrivalDate"].ToString()).ToString("dd/MM/yyyy") != "01/01/1900")
                    {
                        TxtArrivalDate1.Text = Convert.ToDateTime(obj.dr["ArrivalDate"].ToString()).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        TxtArrivalDate1.Text = "";
                    }
                    TxtLoadShort.Text = obj.dr["LoadingPortCode"].ToString();
                    if (Convert.ToDateTime(obj.dr["DepartureDate"].ToString()).ToString("dd/MM/yyyy") != "01/01/1900")
                    {
                        TxtExpArrivalDate1.Text = Convert.ToDateTime(obj.dr["DepartureDate"].ToString()).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        TxtExpArrivalDate1.Text = "";
                    }

                    TxtVoyageno.Text = obj.dr["VoyageNumber"].ToString();
                    TxtVesselName.Text = obj.dr["VesselName"].ToString();
                    TxtOceanBill.Text = obj.dr["OceanBillofLadingNo"].ToString();
                    TxtConRefNo.Text = obj.dr["ConveyanceRefNo"].ToString();
                    TxtTrnsID.Text = obj.dr["TransportId"].ToString();
                    txtflight.Text = obj.dr["FlightNO"].ToString();
                    txtaircraft.Text = obj.dr["AircraftRegNo"].ToString();
                    txtwaybill.Text = obj.dr["MasterAirwayBill"].ToString();



                    if ((obj.dr["InwardTransportMode"].ToString()) == "1 : Sea")
                    {

                        lbloblval.Text = TxtOceanBill.Text;
                    }

                    else if ((obj.dr["InwardTransportMode"].ToString()) == "4 : Air")
                    {
                        lbloblval.Text = txtwaybill.Text;
                    }





                    txthblCargo.Text = obj.dr["Inhabl"].ToString();
                    txtouthblCargo.Text = obj.dr["outhbl"].ToString();

                    txtreLoctn.Text = obj.dr["ReleaseLocation"].ToString();
                    txtrelocDeta.Text = obj.dr["ReleaseLocaName"].ToString();

                    txtrecloctn.Text = obj.dr["RecepitLocation"].ToString();
                    txtrecloctndet.Text = obj.dr["RecepilocaName"].ToString();
                    txtstrgeloc.Text = obj.dr["StorageLocation"].ToString();
                    if (!string.IsNullOrEmpty(obj.dr["ExhibitionSDate"].ToString()))
                    {
                        txtExStartDate.Text = obj.dr["ExhibitionSDate"].ToString();
                    }
                    if (!string.IsNullOrEmpty(obj.dr["ExhibitionEDate"].ToString()))
                    {
                        txtExEndDate.Text = obj.dr["ExhibitionEDate"].ToString();
                    }
                    TxtExpLoadShort.Text = obj.dr["DischargePort"].ToString();
                    //DrpFinalDesCountry.SelectedItem.Text = obj.dr[37].ToString();

                    DrpFinalDesCountry.ClearSelection();
                    DrpFinalDesCountry.Items.FindByText(obj.dr["FinalDestinationCountry"].ToString()).Selected = true;

                    if ((obj.dr["InwardTransportMode"].ToString()) == "1 : Sea")
                    {

                        lbloblval.Text = TxtOceanBill.Text;
                    }

                    else if ((obj.dr["InwardTransportMode"].ToString()) == "4 : Air")
                    {
                        lbloblval.Text = txtwaybill.Text;
                    }



                    OUTWARDVoyageNo.Text = obj.dr["OutVoyageNumber"].ToString();
                    OUTWARDVessel.Text = obj.dr["OutVesselName"].ToString();
                    OUTWARDOcenbill.Text = obj.dr["OutOceanBillofLadingNo"].ToString();
                    //ddpVessel.SelectedItem.Text = obj.dr[41].ToString();
                    ddpVessel.ClearSelection();
                    ddpVessel.Items.FindByText(obj.dr["VesselType"].ToString()).Selected = true;
                    txtvesnet.Text = obj.dr["VesselNetRegTon"].ToString();
                    // DroVesslNat.SelectedItem.Text = obj.dr[43].ToString();

                    DroVesslNat.ClearSelection();
                    DroVesslNat.Items.FindByText(obj.dr["VesselNationality"].ToString()).Selected = true;
                    txtTowVes.Text = obj.dr["TowingVesselID"].ToString();
                    txtTowVesName.Text = obj.dr["TowingVesselName"].ToString();
                    txtNextprt.Text = obj.dr["NextPort"].ToString();
                    txtLasPrt.Text = obj.dr["LastPort"].ToString();
                    OUTWARDConref.Text = obj.dr["OutConveyanceRefNo"].ToString();
                    OUTWARDTransId.Text = obj.dr["OutTransportId"].ToString();
                    OUTWARDFlightN0.Text = obj.dr["OutFlightNO"].ToString();
                    OUTWARDAirREgno.Text = obj.dr["OutAircraftRegNo"].ToString();
                    OUTWARDAirwaybill.Text = obj.dr["OutMasterAirwayBill"].ToString();

                    TxttotalOuterPack.Text = obj.dr["TotalOuterPack"].ToString();

                    DrptotalOuterPack.ClearSelection();
                    DrptotalOuterPack.Items.FindByText(obj.dr["TotalOuterPackUOM"].ToString()).Selected = true;
                    // DrptotalOuterPack.SelectedItem.Text = obj.dr[32].ToString();
                    TxtTotalGrossWeight.Text = obj.dr["TotalGrossWeight"].ToString();

                    string chkdsss = obj.dr["TotalGrossWeightUOM"].ToString();
                    DrpTotalGrossWeight.ClearSelection();
                    DrpTotalGrossWeight.Items.FindByText(obj.dr["TotalGrossWeightUOM"].ToString()).Selected = true;
                    // DrpTotalGrossWeight.SelectedItem.Text = obj.dr[34].ToString();
                    TxtGrossReference.Text = obj.dr["GrossReference"].ToString();
                    txttrdremrk.Text = obj.dr["TradeRemarks"].ToString();
                    txtintremrk.Text = obj.dr["InternalRemarks"].ToString();
                    if (Convert.ToDateTime(obj.dr["BlanketStartDate"].ToString()).ToString("dd/MM/yyyy") != "01/01/1900")
                    {
                        BlankDate1.Text = Convert.ToDateTime(obj.dr["BlanketStartDate"].ToString()).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        BlankDate1.Text = "";
                    }

                    txtothtaxAmt.Text = obj.dr["TotalODutyAmt"].ToString();
                    txttotexAmt.Text = obj.dr["TotalExDutyAmt"].ToString();
                    txttotgstAmt.Text = obj.dr["TotalGSTTaxAmt"].ToString();
                    txtnoofitm.Text = obj.dr["NumberOfItems"].ToString();

                    txtcifVal.Text = obj.dr["TotalCIFFOBValue"].ToString();



                    DecCompany = obj.dr["DeclarantCompanyCode"].ToString();
                    Importer = obj.dr["ImporterCompanyCode"].ToString();
                    Exporter = obj.dr["ExporterCompanyCode"].ToString();
                    inwardcarrier = obj.dr["InwardCarrierAgentCode"].ToString();
                    outward = obj.dr["OutwardCarrierAgentCode"].ToString();
                    consignee = obj.dr["ConsigneeCode"].ToString();
                    ff = obj.dr["FreightForwarderCode"].ToString();
                    climant = obj.dr["ClaimantPartyCode"].ToString();

                    if (obj.dr["CargoPackType"].ToString() == "5 : Other non-Containerized")
                    {
                        ContainerDetails.Visible = false;
                    }
                    else
                    {

                        editcontainer();
                    }
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
                        TxtImpCode.Text = obj.dr[1].ToString();
                        TxtImpName.Text = obj.dr[2].ToString();
                        TxtImpName1.Text = obj.dr[3].ToString();
                        TxtImpCRUEI.Text = obj.dr[4].ToString();
                        lblimporterparty.Text = obj.dr[4].ToString() + " - " + obj.dr[2].ToString() + " " + obj.dr[3].ToString();
                    }
                    string Exp = "select * from [InnonExporter] where Code='" + Exporter + "'";
                    obj.dr = obj.ret_dr(Exp);
                    while (obj.dr.Read())
                    {
                        TxtExpCode.Text = obj.dr[1].ToString();
                        TxtExpName.Text = obj.dr[2].ToString();
                        TxtExpName1.Text = obj.dr[3].ToString();
                        TxtExpCRUEI.Text = obj.dr[4].ToString();

                        lblexporterparty.Text = obj.dr[4].ToString() + " - " + obj.dr[2].ToString() + " " + obj.dr[3].ToString();
                    }
                    string invc = "select * from [InnonInwardCarrierAgent] where Code='" + inwardcarrier + "'";
                    obj.dr = obj.ret_dr(invc);
                    while (obj.dr.Read())
                    {
                        InwardCode.Text = obj.dr[1].ToString();
                        InwardName.Text = obj.dr[2].ToString();
                        InwardName1.Text = obj.dr[3].ToString();
                        InwardCRUEI.Text = obj.dr[4].ToString();
                    }
                    string outw = "select * from [InnonOutwardCarrierAgent] where Code='" + outward + "'";
                    obj.dr = obj.ret_dr(outw);
                    while (obj.dr.Read())
                    {
                        OutwardCode.Text = obj.dr[1].ToString();
                        OutwardName.Text = obj.dr[2].ToString();
                        OutwardName1.Text = obj.dr[3].ToString();
                        OutwardCRUEI.Text = obj.dr[4].ToString();
                    }

                    string ff1 = "select * from [FreightForwarder] where Code='" + ff + "'";
                    obj.dr = obj.ret_dr(ff1);
                    while (obj.dr.Read())
                    {
                        FrieghtCode.Text = obj.dr[1].ToString();
                        FrieghtName.Text = obj.dr[2].ToString();
                        FrieghtName1.Text = obj.dr[3].ToString();
                        FrieghtCRUEI.Text = obj.dr[4].ToString();
                    }


                    string cli = "select * from [InnonConsignee] where ConsigneeCode='" + consignee + "'";
                    obj.dr = obj.ret_dr(cli);
                    while (obj.dr.Read())
                    {
                        ConsigneeCode.Text = obj.dr[1].ToString();
                        ConsigneeName.Text = obj.dr[2].ToString();
                        ConsigneeName1.Text = obj.dr[3].ToString();
                        ConsigneeCRUEI.Text = obj.dr[4].ToString();
                        ConsigneeAddress.Text = obj.dr[5].ToString();
                        ConsigneeAddress1.Text = obj.dr[6].ToString();
                        ConsigneeCity.Text = obj.dr[7].ToString();
                        ConsigneeSub.Text = obj.dr[8].ToString();
                        ConsigneeSubDivi.Text = obj.dr[9].ToString();
                        ConsigneePostal.Text = obj.dr[10].ToString();
                        ConsigneeCountry.Text = obj.dr[11].ToString();


                    }



                    string climantparty = "select * from [InnonClaimantParty] where Name='" + climant + "'";
                    obj.dr = obj.ret_dr(climantparty);
                    while (obj.dr.Read())
                    {
                        ClaimantName.Text = obj.dr["Name"].ToString();
                        ClaimantCRUEI.Text = obj.dr["CRUEI"].ToString();
                        ClaimantName1C.Text = obj.dr["ClaimantName1"].ToString();
                        ClaimantNameC.Text = obj.dr["ClaimantName"].ToString();
                        ClaimantName1.Text = obj.dr["Name1"].ToString();
                        ClaimantName2.Text = obj.dr["Name2"].ToString();

                    }

                    txtstrgeloc_TextChanged(null, null);
                    ChkRefDoc_CheckedChanged(null, null);
                    TxtLoadShort_TextChanged(null, null);
                    //txtreLoctn_TextChanged(null, null);
                    //txtrecloctn_TextChanged(null, null);
                    txtlastprt_TextChanged(null, null);
                    txtLasPrt_TextChanged(null, null);
                    txtNextprt_TextChanged(null, null);
                    txtouthblCargo_TextChanged(null, null);
                    TxtHSCodeItem_TextChanged(null, null);
                    DrpDecType_SelectedIndexChanged(null, null);
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


                    BindInvoice();
                    BindItemMaster();

                    editCPCAEO();
                    editCPCcwc();
                    editCPCSeastore();
                   
                    editCPCSchemestore();
                    editCPCStsstore();
                    editCPCStscwcstore();
                    editCPCIcstore();

                    //SUM OF INVOICE
                    string SumInv = "";
                    string qry11 = "select Count(InvoiceNo) as InvCount from dbo.InNonInvoiceDtl where PermitId='" + txt_code.Text + "' and MessageType='INPDEC'";
                    obj.dr = obj.ret_dr(qry11);
                    while (obj.dr.Read())
                    {
                        SumInv = obj.dr[0].ToString();
                        txtnoofinv.Text = SumInv;
                    }
                    //SUM OF ITEM
                    string SumItem = "";
                    string qry112 = "select Count(ItemNo) as ItemCount from dbo.InNonItemDtl where PermitId='" + txt_code.Text + "' and MessageType='INPDEC'";
                    obj.dr = obj.ret_dr(qry112);
                    while (obj.dr.Read())
                    {
                        SumItem = obj.dr[0].ToString();
                        txtnoofitm.Text = SumItem;
                    }

                    ///Total Invoice CIF Value
                    string InvoiceCIFValue = "";
                    string qry112Q = "select sum(CIFSUMAmount) as InNonInvoiceDtl from dbo.InNonInvoiceDtl where PermitId='" + txt_code.Text + "' and MessageType='INPDEC'";
                    obj.dr = obj.ret_dr(qry112Q);
                    while (obj.dr.Read())
                    {
                        InvoiceCIFValue = obj.dr[0].ToString();
                        txtcifVal.Text = InvoiceCIFValue;
                    }

                    //Sum of Item Amount

                    string SumofItemAmount = "";
                    string qry11s2Q = "select SUM(TotalLineAmount) as  TotalLineAmount  from dbo.InNonItemDtl where PermitId='" + txt_code.Text + "' and MessageType='INPDEC'";
                    obj.dr = obj.ret_dr(qry11s2Q);
                    while (obj.dr.Read())
                    {
                        SumofItemAmount = obj.dr[0].ToString();
                        txtitmAmt.Text = SumofItemAmount;
                    }
                    //TotalGSTAmount
                    string TotalGSTAmount = "";
                    string qry11s2 = "select SUM(GSTAmount) as  GSTAmount  from dbo.InNonItemDtl where PermitId='" + txt_code.Text + "' and MessageType='INPDEC'";
                    obj.dr = obj.ret_dr(qry11s2);
                    while (obj.dr.Read())
                    {
                        TotalGSTAmount = obj.dr[0].ToString();
                        txttotgstAmt.Text = TotalGSTAmount;
                        txtAmtPayble.Text = "0.00";
                    }

                    //Total CIF/FOB Value
                    string TotalCIFFOBValue = "";
                    string qry11sS2 = "select SUM(CIFFOB) as  GSTAmount  from dbo.InNonItemDtl where PermitId='" + txt_code.Text + "' and MessageType='INPDEC'";
                    obj.dr = obj.ret_dr(qry11sS2);
                    while (obj.dr.Read())
                    {
                        TotalCIFFOBValue = obj.dr[0].ToString();
                        txtfobval.Text = TotalCIFFOBValue;

                    }

                    InvoiceGrid.Visible = true;

                    TxttotalOuterPack_TextChanged(null, null);
                    DrptotalOuterPack_SelectedIndexChanged(null, null);
                    TxtTotalGrossWeight_TextChanged(null, null);
                    DrpTotalGrossWeight_SelectedIndexChanged(null, null);
                    TxtExpLoadShort_TextChanged(null, null);
                    TxtOceanBill_TextChanged(null, null);
                    txthblCargo_TextChanged(null, null);
                    txtwaybill_TextChanged(null, null);

                    upinnoncargo.Update();
                    AddDynamicLabels();
                    AddDynamicItem();
                    SummaryCalculate();
                    //edit = true;
                    string Invoice = txt_code.Text;
                    DrpInvoiceNo.DataSource = null;
                    string striW = "select * from [InNonInvoiceDtl] where MessageType='INPDEC' AND PermitId='" + Invoice + "'  order by InvoiceNo";
                    obj.dr = obj.ret_dr(striW);
                    DrpInvoiceNo.DataSource = obj.dr;
                    DrpInvoiceNo.DataTextField = "InvoiceNo";
                    DrpInvoiceNo.DataValueField = "Id";
                    DrpInvoiceNo.DataBind();
                    obj.closecon();
                    DrpInvoiceNo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
                    txttrdremrk_TextChanged(null, null);
                    OUTWARDOcenbill_TextChanged(null, null);
                    OUTWARDAirwaybill_TextChanged(null, null);
                    txtouthblCargo_TextChanged(null, null);
                    InvoiceNo();
                    ItemNO();
                    innonpayment.Update();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }
        void ContarinerGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.TableSection = TableRowSection.TableHeader;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList DrpType = (DropDownList)e.Row.FindControl("DrpType");

                string str11 = "select *  from CommonMaster where TypeId=6 and StatusId=1 order by Name";
                obj.dr = obj.ret_dr(str11);
                obj.BindDropDown(DrpType, obj.dr, "Id", "Name");               
            }
        }




        private void BindGrid()
        {
            const int maxTotalSizeKB = 2000;
            long totalKB = 0;

            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT Id, DocumentType, Name, FileSizeKB FROM InNonFile WHERE InPaymentId = @InPaymentId";
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
                using (SqlCommand cmd = new SqlCommand("SELECT Id,DocumentType,Name FROM InNoncANFile where InPaymentId='" + txt_code.Text + "' "))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet dt = new DataSet())
                        {
                            sda.Fill(dt);
                            GridCancelDoc.DataSource = dt;
                            GridCancelDoc.DataBind();
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
            TxtRECPT1.Focus();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();

            string strDelete = "delete from InNonFile where Id='" + id + "' ";
            obj.exec(strDelete);
            obj.closecon();
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
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM InNonFile where ID=" + employeeId, con);
                result = cmd.ExecuteNonQuery();
                con.Close();
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
                using (SqlCommand cmd = new SqlCommand("SELECT Top 10 Id,Code,Name,Name1,CRUEI FROM DeclarantCompany where AccountID='" + Session["AccountId"].ToString() + "' "))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet dt = new DataSet())
                        {
                            sda.Fill(dt);
                            DECCOMPSearGRID.DataSource = dt;
                            DECCOMPSearGRID.DataBind();
                        }
                    }
                }
            }
        }

        protected void DECCOMPSearGRID_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DECCOMPSearGRID.PageIndex = e.NewPageIndex;
            //  ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            decBindGrid();
            popupinnondec.Show();
            popupinnondec.X = 400;
            popupinnondec.Y = 100;
        }

        protected void lnkRequestID_Command(object sender, CommandEventArgs e)
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
                    TxtDecCompCode.Text = "";
                    TxtDecCompName.Text = "";
                    TxtDecCompName1.Text = "";
                    TxtDecCompCRUEI.Text = "";
                    TxtDecCompCode.Text = requestor;
                    TxtDecCompName.Text = requestType;
                    TxtDecCompName1.Text = status;
                    TxtDecCompCRUEI.Text = crueis;

                }

            }
        }
        public DataTable GetStrgLocSerach(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = txtstorageSearch.Text;

            string str3 = "select Id,Code,StorageCode,Description from  StorageLocation where Code like '" + txtstorageSearch.Text.Replace("'", "''") + "%' ";
            obj.dr = obj.ret_dr(str3);
            if (obj.dr.HasRows)
            {
                GridStorageLoc.DataSource = obj.dr;

            }
            else
            {
                //Empty DataTable to execute the “else-condition”  
                DataTable dt = new DataTable();
                GridStorageLoc.DataSource = dt;
                GridStorageLoc.DataBind();
            }
            SqlConnection con = new SqlConnection(sqlconn);
            SqlDataAdapter _objda = new SqlDataAdapter(str3, con);
            con.Close();
            _objda.Fill(_objdt);
            return _objdt;
        }

        public DataTable GetDataFromDataBase(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = DecSearch.Text;

            string str3 = "SELECT Id,Code,Name,Name1,CRUEI FROM DeclarantCompany where Code Like '%" + DecSearch.Text + "%' order by Id desc";
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

        protected void DecSearch_TextChanged(object sender, EventArgs e)
        {

            DataTable _objdt = new DataTable();
            _objdt = GetDataFromDataBase(DecSearch.Text);
            if (_objdt.Rows.Count > 0)
            {
                DECCOMPSearGRID.DataSource = _objdt;
                DECCOMPSearGRID.DataBind();
                //   ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The DeclarantCompany Code Is Empty');", true);
            }
            else
            {
                string Code = "";
                string qry11 = "SELECT Code FROM DeclarantCompany where Code='" + TxtDecCompCode.Text + "'";

                obj.dr = obj.ret_dr(qry11);

                while (obj.dr.Read())
                {
                    Code = obj.dr[0].ToString();

                }
                if (Code == "")
                {
                    string Touch_user = Session["UserId"].ToString();

                    string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string StrQuery = ("UPDATE [dbo].[DeclarantCompany] SET [Code] ='" + TxtDecCompCode.Text + "' WHERE Name='" + TxtDecCompName.Text + "' ");
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
                        }
                    }
                }
            }
        }
        protected void ImporterSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable _objdt = new DataTable();
            _objdt = GetImportDataFromDataBase(ImporterSearch.Text.Replace("'", "''"));
            if (_objdt.Rows.Count > 0)
            {
                ImporterGrid.DataSource = _objdt;
                ImporterGrid.DataBind();
                popupinnonimp.Show();                
            }

        }

        protected void ImporterGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ImporterGrid.PageIndex = e.NewPageIndex;
            //   ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalImport();", true);
            BindImport();
            popupinnonimp.Show();
            //popupinnonimp.X = 400;
            //popupinnonimp.Y = 100;
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

                    string strTime = System.DateTime.Now.ToString("yyyy/MM/dd");
                    string StrQuery = ("INSERT INTO [dbo].[Importer] ([Code],[Name],[Name1],[CRUEI],[TouchUser],[TouchTime]) VALUES ('" + TxtImpCode.Text.Replace("'", "''") + "','" + TxtImpName.Text.Replace("'", "''") + "','" + TxtImpName1.Text.Replace("'", "''") + "','" + TxtImpCRUEI.Text.Replace("'", "''") + "','" + Touch_user + "',Convert(VARCHAR,'" + strTime + "',108))");
                    obj.exec(StrQuery);
                    BindImport();

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : Data Saved Successfully');", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Importer Code Already Exist..');", true);
                    //  Response.Write("The Importer Code Already Exist..");
                }

                TxtExpCode.Focus();
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
                string qry11 = "select Top 1 * from Importer where Code='" + ss[0].ToString().Replace("'", "''") + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    TxtImpCode.Text = obj.dr[1].ToString();
                    TxtImpName.Text = obj.dr[2].ToString();
                    if (TxtImpName.Text == "SINGAPORE AIRLINES LIMITED")
                    {
                        Lblmarquee.Text = "FOR THIS PART NUMBER SQB0856YY04 MUST USE COUNTRY OF ORIGIN France (FR). ";
                        innonpayment.Update();
                    }
                    else
                    {
                        Lblmarquee.Text = "";
                        innonpayment.Update();
                    }

                    TxtImpName1.Text = obj.dr[3].ToString();
                    TxtImpCRUEI.Text = obj.dr[4].ToString();
                    lblimporterparty.Text = obj.dr[4].ToString() + " - " + obj.dr[2].ToString() + " " + obj.dr[3].ToString();

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
            TxtExpCode.Focus();
        }
        //Inward Code
        //Inward 

        private void BindInward()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Top 20 Id,Code,Name,Name1,CRUEI FROM InnonInwardCarrierAgent"))
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
            _objdt = GetInwardDataFromDataBase(InwardSearch.Text.Replace("'", "''"));
            if (_objdt.Rows.Count > 0)
            {
                InwardGrid.DataSource = _objdt;
                InwardGrid.DataBind();
                  ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalInward();", true);
                popupinnoninw.Show();

            }
        }

        protected void InwardGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            InwardGrid.PageIndex = e.NewPageIndex;
            //  ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalInward();", true);

            BindInward();
            popupinnoninw.Show();
           
           

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
        }

        protected void InwardAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(InwardCode.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Inward Code Is Empty');", true);
            }
            else if (string.IsNullOrWhiteSpace(InwardCRUEI.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Inward UEI Is Empty');", true);
            }
            else if (string.IsNullOrWhiteSpace(InwardName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Inward Name Is Empty');", true);
            }
            else
            {
                string Code = "";
                string qry11 = "SELECT Code FROM InnonInwardCarrierAgent where Code='" + InwardCode.Text.Replace("'", "''") + "'";

                obj.dr = obj.ret_dr(qry11);

                while (obj.dr.Read())
                {
                    Code = obj.dr[0].ToString();

                }
                if (Code == "")
                {
                    string Touch_user = Session["UserId"].ToString();

                    string strTime = System.DateTime.Now.ToString("yyyy/MM/dd");
                    string StrQuery = ("INSERT INTO [dbo].[InnonInwardCarrierAgent] ([Code],[Name],[Name1],[CRUEI],[TouchUser],[TouchTime]) VALUES ('" + InwardCode.Text.Replace("'", "''") + "','" + InwardName.Text.Replace("'", "''") + "','" + InwardName1.Text.Replace("'", "''") + "','" + InwardCRUEI.Text.Replace("'", "''") + "','" + Touch_user + "',Convert(VARCHAR,'" + strTime + "',108))");
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

            string str3 = "SELECT Id,Code,Name,Name1,CRUEI FROM InnonInwardCarrierAgent where Code Like '%" + InwardSearch.Text.Replace("'", "''") + "%' or Name Like '%" + InwardSearch.Text.Replace("'", "''") + "%' order by Id desc";
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
                string qry11 = "select Top 1 * from InnonInwardCarrierAgent where Code='" + ss[0].ToString().Replace("'", "''") + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    InwardCode.Text = obj.dr[1].ToString();
                    InwardName.Text = obj.dr[2].ToString();
                    InwardName1.Text = obj.dr[3].ToString();
                    InwardCRUEI.Text = obj.dr[4].ToString();
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
            _objdt = GetFreightDataFromDataBase(FrieghtSearch.Text.Replace("'", "''"));
            if (_objdt.Rows.Count > 0)
            {
                FrieghtGrid.DataSource = _objdt;
                FrieghtGrid.DataBind();

                popupinnonfreight.Show();
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalfright();", true);
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

                }

            }
        }

        protected void BtnFrieghtAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FrieghtCode.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The FreightForwarder Code Is Empty');", true);
            }
            else if (string.IsNullOrWhiteSpace(FrieghtName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The FreightForwarder UEI Is Empty');", true);
            }
            else if (string.IsNullOrWhiteSpace(FrieghtCRUEI.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The FreightForwarder Name is Empty');", true);
            }
            else
            {
                string Code = "";
                string qry11 = "SELECT Code FROM FreightForwarder where Code='" + FrieghtCode.Text.Replace("'", "''") + "'";

                obj.dr = obj.ret_dr(qry11);

                while (obj.dr.Read())
                {
                    Code = obj.dr[0].ToString();

                }
                if (Code == "")
                {
                    string Touch_user = Session["UserId"].ToString();

                    string strTime = System.DateTime.Now.ToString("yyyy/MM/dd");
                    string StrQuery = ("INSERT INTO [dbo].[FreightForwarder] ([Code],[Name],[Name1],[CRUEI],[TouchUser],[TouchTime]) VALUES ('" + FrieghtCode.Text.Replace("'", "''") + "','" + FrieghtName.Text.Replace("'", "''") + "','" + FrieghtName1.Text.Replace("'", "''") + "','" + FrieghtCRUEI.Text.Replace("'", "''") + "','" + Touch_user + "',Convert(VARCHAR,'" + strTime + "',108))");
                    obj.exec(StrQuery);
                    BindFrieght();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : Data Saved Successfully');", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The FreightForwarder Code Already Exist...');", true);
                    // Response.Write("The FreightForwarder Code Already Exist..");
                }

                ClaimantName.Focus();
            }
        }
        public DataTable GetFreightDataFromDataBase(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = FrieghtSearch.Text;

            string str3 = "SELECT Id,Code,Name,Name1,CRUEI FROM FreightForwarder where Code Like '%" + FrieghtSearch.Text.Replace("'", "''") + "%' order by Id desc";
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
                txthblCargo.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            }
            else
            {
                txthblCargo.BackColor = System.Drawing.Color.White;                
            }
            if (FrieghtCode.Text != "")
            {
                string[] ss = FrieghtCode.Text.Split(':');
                string qry11 = "select Top 1 * from FreightForwarder where Code='" + ss[0].ToString().Replace("'", "''") + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    FrieghtCode.Text = obj.dr[1].ToString();
                    FrieghtName.Text = obj.dr[2].ToString();
                    FrieghtName1.Text = obj.dr[3].ToString();
                    FrieghtCRUEI.Text = obj.dr[4].ToString();
                }
            }
            else
            {
                FrieghtCode.Text = "";
                FrieghtName.Text = "";
                FrieghtName1.Text = "";
                FrieghtCRUEI.Text = "";
            }
            ConsigneeCode.Focus();
        }

        protected void FrieghtGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            FrieghtGrid.PageIndex = e.NewPageIndex;
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalfright();", true);
            BindFrieght();
            popupinnonfreight.Show();
          
           
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
                        dtCurrentTable.Rows[i - 1]["Column2"] = drp1.SelectedValue.ToString();
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
                        drp1.SelectedValue = dt.Rows[i]["Column2"].ToString();
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
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalLoading();", true);
                popupinnonloadingport.Show();
            }
        }

        protected void LoadingGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LoadingGrid.PageIndex = e.NewPageIndex;
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalLoading();", true);
            popupinnonloadingport.Show();
          
            BindLoading();
        }

        protected void LnkLoading_Command(object sender, CommandEventArgs e)
        {
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
                using (SqlCommand cmd = new SqlCommand("SELECT Top 100 * FROM ReleaseLocation"))
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
            _objdt = GetDataFromDataBasecar(LocationSearch.Text.Replace("'", "''"));
            if (_objdt.Rows.Count > 0)
            {
                LocationGrid.DataSource = _objdt;
                LocationGrid.DataBind();
                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openLocation();", true);
            }
            popupinnonreleaseloction.Show();
           
        }

        protected void LocationGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LocationGrid.PageIndex = e.NewPageIndex;
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openLocation();", true);
            popupinnonreleaseloction.Show();
            
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

            string str3 = "SELECT * FROM ReleaseLocation where Code Like '%" + searchtext.Replace("'", "''") + "%' order by Id desc";
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
                string[] ss = txtreLoctn.Text.Split(':');
                string control = ss[0].ToString();
                if (TextMode.Text == "1 : Sea")
                {
                    if (control.ToUpper() == "CZ" || control.ToUpper() == "LHQ" || control.ToUpper() == "THQ" || control.ToUpper() == "AT1B" || control.ToUpper() == "AT2B" || control.ToUpper() == "AT3B" || control.ToUpper() == "ATC")
                    {
                        string qry11 = "select * from ReleaseLocation where Code='" + control + "'";
                        obj.dr = obj.ret_dr(qry11);
                        while (obj.dr.Read())
                        {
                            //txtreLoctn.Text = obj.dr[2].ToString() + ":" + obj.dr[3].ToString();
                            txtreLoctn.Text = obj.dr[2].ToString();
                            txtrelocDeta.Text = obj.dr[3].ToString();
                            txtrelocDeta.ForeColor = Color.Black;
                        }
                        // txtrelocDeta.ForeColor = Color.Red;
                        lblrelloc.Visible = true;
                        //txtrelocDeta.Text = "";
                        lblrelloc.Text = "Please Check Place of Release Location";
                        //  Response.Write("<Script>alert(Please Check Place of Release Location)</script>");
                    }
                    else
                    {
                        // string[] ss = txtreLoctn.Text.Split(':');

                        string qry11 = "select * from ReleaseLocation where Code='" + control + "'";
                        obj.dr = obj.ret_dr(qry11);
                        while (obj.dr.Read())
                        {
                            //txtreLoctn.Text = obj.dr[2].ToString() + ":" + obj.dr[3].ToString();
                            txtreLoctn.Text = obj.dr[2].ToString();
                            txtrelocDeta.Text = obj.dr[3].ToString();
                            txtrelocDeta.ForeColor = Color.Black;
                            lblrelloc.Visible = false;
                        }
                    }


                }

                //air

                else if (TextMode.Text == "4 : Air")
                {
                    if (control.ToUpper() == "CZ" || control.ToUpper() == "AT1B" || control.ToUpper() == "AT2B" || control.ToUpper() == "AT3B")
                    {

                        // string[] ss = txtreLoctn.Text.Split(':');

                        string qry11 = "select * from ReleaseLocation where Code='" + control + "'";
                        obj.dr = obj.ret_dr(qry11);
                        while (obj.dr.Read())
                        {
                            //txtreLoctn.Text = obj.dr[2].ToString() + ":" + obj.dr[3].ToString();
                            txtreLoctn.Text = obj.dr[2].ToString();
                            txtrelocDeta.Text = obj.dr[3].ToString();
                            txtrelocDeta.ForeColor = Color.Black;
                            lblrelloc.Visible = false;
                        }
                    }
                    else
                    {
                        // txtrelocDeta.ForeColor = Color.Red;
                        string qry11 = "select * from ReleaseLocation where Code='" + control + "'";
                        obj.dr = obj.ret_dr(qry11);
                        while (obj.dr.Read())
                        {
                            //txtreLoctn.Text = obj.dr[2].ToString() + ":" + obj.dr[3].ToString();
                            txtreLoctn.Text = obj.dr[2].ToString();
                            txtrelocDeta.Text = obj.dr[3].ToString();
                            txtrelocDeta.ForeColor = Color.Black;
                        }
                        lblrelloc.Visible = true;
                        lblrelloc.Text = "Please Check Place of Release Location";
                        //txtrelocDeta.Text = "";
                        //  Response.Write("<Script>alert(Please Check Place of Release Location)</script>");
                    }
                }
                else if (TextMode.Text == "3 : Road")
                {
                    if (control.ToUpper() == "THQ" || control.ToUpper() == "LHQ")
                    {

                        //  string[] ss = txtreLoctn.Text.Split(':');

                        string qry11 = "select * from ReleaseLocation where Code='" + control + "'";
                        obj.dr = obj.ret_dr(qry11);
                        while (obj.dr.Read())
                        {
                            //txtreLoctn.Text = obj.dr[2].ToString() + ":" + obj.dr[3].ToString();
                            txtreLoctn.Text = obj.dr[2].ToString();
                            txtrelocDeta.Text = obj.dr[3].ToString();
                            txtrelocDeta.ForeColor = Color.Black;
                            lblrelloc.Visible = false;
                        }
                    }
                    else
                    {
                        // txtrelocDeta.ForeColor = Color.Red;
                        string qry11 = "select * from ReleaseLocation where Code='" + control + "'";
                        obj.dr = obj.ret_dr(qry11);
                        while (obj.dr.Read())
                        {
                            //txtreLoctn.Text = obj.dr[2].ToString() + ":" + obj.dr[3].ToString();
                            txtreLoctn.Text = obj.dr[2].ToString();
                            txtrelocDeta.Text = obj.dr[3].ToString();
                            txtrelocDeta.ForeColor = Color.Black;
                        }
                        lblrelloc.Visible = true;
                        lblrelloc.Text = "Please Check Place of Release Location";
                        //txtrelocDeta.Text = "";
                        //  Response.Write("<Script>alert(Please Check Place of Release Location)</script>");
                    }
                }
                else
                {
                    //  string[] ss = txtreLoctn.Text.Split(':');

                    string qry11 = "select * from ReleaseLocation where Code='" + control + "'";
                    obj.dr = obj.ret_dr(qry11);
                    while (obj.dr.Read())
                    {
                        //txtreLoctn.Text = obj.dr[2].ToString() + ":" + obj.dr[3].ToString();
                        txtreLoctn.Text = obj.dr[2].ToString();
                        txtrelocDeta.Text = obj.dr[3].ToString();
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
            txtrelocDeta.Focus();
        }
        private void Bindreceipt()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Top 100 * FROM ReceiptLocation"))
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
        private void BindStoreLocation()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM StorageLocation"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet dt = new DataSet())
                        {
                            sda.Fill(dt);
                            GridStorageLoc.DataSource = dt;
                            GridStorageLoc.DataBind();
                        }
                    }
                }
            }
        }
        protected void ReceiptSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable _objdt = new DataTable();
            _objdt = GetReceipt(ReceiptSearch.Text.Replace("'", "''"));
            if (_objdt.Rows.Count > 0)
            {
                ReceiptGrid.DataSource = _objdt;
                ReceiptGrid.DataBind();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openReceipt();", true);
            }
            popupinnonreceiptlocation.Show();
           
        }
        public DataTable GetReceipt(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = ReceiptSearch.Text;

            string str3 = "SELECT * FROM ReceiptLocation where Code Like '%" + ReceiptSearch.Text.Replace("'", "''") + "%' order by Id desc";
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
            //popupinnonreceiptlocat  ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openReceipt();", true);
            popupinnonreceiptlocation.Show();
           
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
                string[] ss = txtrecloctn.Text.Split(':');
                string qry11 = "select * from ReleaseLocation where Code='" + ss[0].ToString().Replace("'", "''") + "'";
                obj.dr = obj.ret_dr(qry11);
                if (obj.dr != null)
                {
                    while (obj.dr.Read())
                    {
                        txtrecloctn.Text = obj.dr[2].ToString();
                        txtrecloctndet.Text = obj.dr[3].ToString();
                    }
                }
                else
                {
                    txtrecloctn.Text = ss[0].ToString();
                    txtrecloctndet.Text = ss[0].ToString();
                }
            }
            else
            {
                txtrecloctn.Text = "";
                txtrecloctndet.Text = "";
            }
            txtrecloctndet.Focus();            
        }
        private void BindLoading()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Top 100 * FROM LoadingPort"))
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

            string str3 = "SELECT * FROM LoadingPort where PortCode Like '%" + CarLoadingSearch.Text.Replace("'", "''") + "%' or PortName like '" + CarLoadingSearch.Text.Replace("'", "''") + "%' order by Id desc";
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
                string qry11 = "select * from LoadingPort where PortCode='" + ss[0].ToString().Replace("'", "''") + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    TxtLoadShort.Text = obj.dr["PortCode"].ToString();
                    TxtLoad.Text = obj.dr["PortName"].ToString();
                }
            }
            else
            {
                TxtLoadShort.Text = "";
                TxtLoad.Text = "";
            }

            if (TextMode.Text == "1 : SEA")
            {
                TxtVoyageno.Focus();
            }

            else if (TextMode.Text == "4 : AIR")
            {
                txtflight.Focus();
            }

        }
        //invoice
        protected void DrpTerms_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TotalInvoice.Visible = false;
            //OtherTaxableCharge.Visible = false;
            //FrieghtCharges.Visible = false;
            //InsuranceCharges.Visible = false;
            //CostInsuranceandFreight.Visible = false;
            //GST.Visible = false;
            //if (DrpTerms.SelectedItem.ToString() == "CFR : Cost and Frieght ( also known as C & F )")
            //{
            //    TotalInvoice.Visible = true;
            //    OtherTaxableCharge.Visible = true;
            //    FrieghtCharges.Visible = false;
            //    InsuranceCharges.Visible = true;
            //    CostInsuranceandFreight.Visible = true;
            //    GST.Visible = true;
            //    if (editInvoice != true)
            //    {
            //        InsuranceChargesPer.Text = "1.00";
            //        string Cur = "13";
            //        Drpcurrency4.SelectedValue = Cur;
            //        Drpcurrency4_SelectedIndexChanged(null, null);

            //        LblFrieghtCharges.Text = "0.00";
            //        TxtFrieghtCharges.Text = "0.00";
            //        Cur = "0";
            //        Drpcurrency3.SelectedValue = Cur;
            //        Drpcurrency3_SelectedIndexChanged(null, null);
            //    }
            //}
            //else if (DrpTerms.SelectedItem.ToString() == "CIF : Cost,Insurance and Frieght")
            //{
            //    TotalInvoice.Visible = true;
            //    OtherTaxableCharge.Visible = true;
            //    FrieghtCharges.Visible = false;
            //    InsuranceCharges.Visible = false;
            //    CostInsuranceandFreight.Visible = true;
            //    GST.Visible = true;
            //    if (editInvoice != true)
            //    {
            //        InsuranceChargesPer.Text = "0.00";
            //        string Cur = "13";
            //        TxtInsuranceCharges.Text = "0.00";
            //        Drpcurrency4.SelectedValue = Cur;
            //        Drpcurrency4_SelectedIndexChanged(null, null);

            //        LblFrieghtCharges.Text = "0.00";
            //        TxtFrieghtCharges.Text = "0.00";
            //        Cur = "0";
            //        Drpcurrency3.SelectedValue = Cur;
            //        Drpcurrency3_SelectedIndexChanged(null, null);
            //    }
            //}
            //else if (DrpTerms.SelectedItem.ToString() == "EXW : Exw Works (also known as Ex-Factory)")
            //{
            //    TotalInvoice.Visible = true;
            //    OtherTaxableCharge.Visible = true;
            //    FrieghtCharges.Visible = true;
            //    InsuranceCharges.Visible = true;
            //    CostInsuranceandFreight.Visible = true;
            //    GST.Visible = true;
            //    if (editInvoice != true)
            //    {
            //        InsuranceChargesPer.Text = "1.00";
            //        string Cur = "13";
            //        Drpcurrency4.SelectedValue = Cur;
            //        Drpcurrency4_SelectedIndexChanged(null, null);
            //    }
            //}
            //else if (DrpTerms.SelectedItem.ToString() == "CNI : Cost and Insurance (also Known as C & I )")
            //{
            //    TotalInvoice.Visible = true;
            //    OtherTaxableCharge.Visible = true;
            //    FrieghtCharges.Visible = true;
            //    InsuranceCharges.Visible = false;
            //    CostInsuranceandFreight.Visible = true;
            //    GST.Visible = true;
            //    if (editInvoice != true)
            //    {
            //        InsuranceChargesPer.Text = "0.00";
            //        string Cur = "13";
            //        TxtInsuranceCharges.Text = "0.00";
            //        Drpcurrency4.SelectedValue = Cur;
            //        Drpcurrency4_SelectedIndexChanged(null, null);
            //    }
            //}
            //else if (DrpTerms.SelectedItem.ToString() == "FAS : Free Alongside Ship")
            //{
            //    TotalInvoice.Visible = true;
            //    OtherTaxableCharge.Visible = true;
            //    FrieghtCharges.Visible = true;
            //    InsuranceCharges.Visible = true;
            //    CostInsuranceandFreight.Visible = true;
            //    GST.Visible = true;
            //    if (editInvoice != true)
            //    {
            //        InsuranceChargesPer.Text = "1.00";
            //        string Cur = "13";
            //        Drpcurrency4.SelectedValue = Cur;
            //        Drpcurrency4_SelectedIndexChanged(null, null);
            //    }
            //}
            //else if (DrpTerms.SelectedItem.ToString() == "FOB : Free On Board")
            //{
            //    TotalInvoice.Visible = true;
            //    OtherTaxableCharge.Visible = true;
            //    FrieghtCharges.Visible = true;
            //    InsuranceCharges.Visible = true;
            //    CostInsuranceandFreight.Visible = true;
            //    GST.Visible = true;
            //    if (editInvoice != true)
            //    {
            //        InsuranceChargesPer.Text = "1.00";
            //        string Cur = "13";
            //        Drpcurrency4.SelectedValue = Cur;
            //        Drpcurrency4_SelectedIndexChanged(null, null);
            //    }
            //}
            //else
            //{
            //    TotalInvoice.Visible = true;
            //    OtherTaxableCharge.Visible = true;
            //    FrieghtCharges.Visible = true;
            //    InsuranceCharges.Visible = true;
            //    CostInsuranceandFreight.Visible = true;
            //    GST.Visible = true;
            //    if (editInvoice != true)
            //    {
            //        InsuranceChargesPer.Text = "1.00";
            //        string Cur = "13";
            //        Drpcurrency4.SelectedValue = Cur;
            //        Drpcurrency4_SelectedIndexChanged(null, null);
            //    }
            //}
            //TxtTotalInvoice_TextChanged(null, null);
            //TxtInsuranceCharges_TextChanged(null, null);
            //TxtFrieghtCharges_TextChanged(null, null);
            //chkindicator.Focus();
            //InvoiceGrid.Visible = true;
            //InvoiceDiv.Visible = true;

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
            //NewInvoice.Visible = false;
        }
        private void BindGridinx()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Top 20 Id,Code,Name,Name1,CRUEI FROM INNONSUPPLIERMANUFACTURERPARTY"))
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
            _objdt = GetDataFromDataBase(SUPPLIERSearch.Text);
            if (_objdt.Rows.Count > 0)
            {
                SUPPLIERGrid.DataSource = _objdt;
                SUPPLIERGrid.DataBind();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            }
        }

        protected void SUPPLIERGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            SUPPLIERGrid.PageIndex = e.NewPageIndex;
            //  ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal1();", true);
            popupinnonsp.Show();
            popupinnonsp.X = 400;
            popupinnonsp.Y = 100;
            BindGrid();
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
                string qry11 = "select * from INNONSUPPLIERMANUFACTURERPARTY where Code='" + ss[0].ToString().Replace("'", "''") + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    txtcodeinvq.Text = obj.dr["Code"].ToString();
                    txtName.Text = obj.dr["Name"].ToString();
                    txtName1.Text = obj.dr["Name1"].ToString();
                    txtcruei.Text = obj.dr["CRUEI"].ToString();
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
            string Code = "";
            string qry11 = "SELECT Code FROM INNONSUPPLIERMANUFACTURERPARTY where Code='" + txtcodeinvq.Text.Replace("'", "''") + "'";

            obj.dr = obj.ret_dr(qry11);

            while (obj.dr.Read())
            {
                Code = obj.dr[0].ToString();

            }
            if (Code == "")
            {
                string Touch_user = Session["UserId"].ToString();

                string strTime = System.DateTime.Now.ToString("yyyy/MM/dd");
                string StrQuery = ("INSERT INTO [dbo].[INNONSUPPLIERMANUFACTURERPARTY] ([Code],[Name],[Name1],[CRUEI],[TouchUser],[TouchTime]) VALUES ('" + txtcodeinvq.Text.Replace("'", "''") + "','" + txtName.Text.Replace("'", "''") + "','" + txtName1.Text.Replace("'", "''") + "','" + txtcruei.Text.Replace("'", "''") + "','" + Touch_user + "',Convert(VARCHAR,'" + strTime + "',108))");
                obj.exec(StrQuery);
                BindGridinx();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : Data Saved Successfully');", true);

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Importer Code Already Exist..');", true);
                //  Response.Write("The Importer Code Already Exist..");
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

                if (string.IsNullOrWhiteSpace(box1.Text) )
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

        protected void BtnCWC_Click(object sender, EventArgs e)
        {
            DataTable dtCurrent = ViewState["CurrentTable1"] as DataTable;
            if (dtCurrent != null && dtCurrent.Rows.Count >= 5)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You can only add up to 5 rows.');", true);
                return;
            }

            if (CWCGrid.Rows.Count > 0) // Replace "CWCGrid" with your actual GridView ID
            {
                int lastRowIndex = CWCGrid.Rows.Count - 1;

                // Replace these with your actual control IDs from the grid
                TextBox box1 = (TextBox)CWCGrid.Rows[lastRowIndex].Cells[1].FindControl("TextBox1");
                TextBox box2 = (TextBox)CWCGrid.Rows[lastRowIndex].Cells[2].FindControl("TextBox2");
                TextBox box3 = (TextBox)CWCGrid.Rows[lastRowIndex].Cells[3].FindControl("TextBox3");

                if (string.IsNullOrWhiteSpace(box1.Text) )
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

            const int maxTotalSizeKB = 20000; // 20MB
            long totalSizeBytes = 0;

            // Calculate total size first
            foreach (HttpPostedFile postedFile in FileUpload1.PostedFiles)
            {
                totalSizeBytes += postedFile.ContentLength;
            }

            // Check total size limit
            if (totalSizeBytes > maxTotalSizeKB * 1024)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Total file size exceeds 20MB limit!');", true);
                return;
            }

            int infi = 1;
            foreach (HttpPostedFile postedFile in FileUpload1.PostedFiles)
            {
                string filename = Path.GetFileName(postedFile.FileName);
                string fileExtension = Path.GetExtension(filename).ToLower();
                string contentType = postedFile.ContentType;

                // Validate file extension
                if (!allowedExtensions.Contains(fileExtension))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        $"alert('Invalid file type: {filename}');", true);
                    continue;
                }

                // Validate MIME type
                if (!allowedMimeTypes.Contains(contentType.ToLower()))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        $"alert('Invalid file content type: {filename}');", true);
                    continue;
                }
                string path = @"C:\Users\Public\IMG\" + filename;
                try
                {

                    postedFile.SaveAs(path);

                    int fileSizeKB = (int)Math.Ceiling(postedFile.ContentLength / 1024.0);

                    using (Stream fs = postedFile.InputStream)
                    {
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            byte[] bytes = br.ReadBytes((Int32)fs.Length);
                            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;

                            using (SqlConnection con = new SqlConnection(constr))
                            {
                                string Touch_user = Session["UserId"]?.ToString() ?? "unknown";
                                string Code = MsgNO;
                                string DocType = DrpDocType.SelectedItem?.ToString() ?? "undefined";
                                string strTime = DateTime.Now.ToString("yyyy/MM/dd");

                                string query = @"INSERT INTO InNonFile VALUES 
                            (@Sno,@Name,@ContentType,@Data,@DocumentType,
                            @InPaymentId,@TouchUser,@TouchTime,@filePath,@FileSizeKB)";

                                using (SqlCommand cmd = new SqlCommand(query, con))
                                {
                                    cmd.Parameters.AddWithValue("@Sno", infi);
                                    cmd.Parameters.AddWithValue("@Name", filename);
                                    cmd.Parameters.AddWithValue("@ContentType", contentType);
                                    cmd.Parameters.AddWithValue("@Data", bytes);
                                    cmd.Parameters.AddWithValue("@DocumentType", DocType);
                                    cmd.Parameters.AddWithValue("@InPaymentId", Code);
                                    cmd.Parameters.AddWithValue("@TouchUser", Touch_user);
                                    cmd.Parameters.AddWithValue("@TouchTime", strTime);
                                    cmd.Parameters.AddWithValue("@filePath", path);
                                    cmd.Parameters.AddWithValue("@FileSizeKB", fileSizeKB);
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                }
                            }
                        }
                    }

                    infi++;
                    BindGrid();
                    DrpDocType.ClearSelection();
                    DrpDocType.Items.FindByText("--Select--").Selected = true;
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        $"alert('Error uploading {filename}: {ex.Message}');", true);
                }
            }

            innonheader.Update();
        }

        protected void DrpInwardtrasMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            string TransMode = DrpInwardtrasMode.SelectedItem.ToString();

            lblinwardtm.Text = DrpInwardtrasMode.SelectedItem.ToString();


            if (DrpInwardtrasMode.SelectedItem.ToString() != "--Select--")
            {
                InwardCRUEI.BackColor = System.Drawing.Color.White;
                InwardName.BackColor = System.Drawing.Color.White;
                TextMode.Text = TransMode;
                InwardFlight.Visible = false;
                InwardSea.Visible = false;
                InwardOther.Visible = false;
                ExpParty.Visible = true;
                //ContainerDetails.Visible = false;
                inhbl1.Visible = false;
                if (TextMode.Text == "1 : Sea")
                {

                    InwardSea.Visible = true;
                    inhbl.Visible = true;
                    inhbl1.Visible = true;
                    inhab.Visible = false;
                    inhab1.Visible = false;
                    phawb.Visible = false;
                    phawb1.Visible = false;
                    load.Visible = true;
                    inwa.Visible = true;
                    //ContainerDetails.Visible = true;                            

                    InwardCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    InwardName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);

                    DrpTotalGrossWeight.Items.Clear();
                    DrpTotalGrossWeight.Items.Add("KGM");
                    DrpTotalGrossWeight.Items.Add("TNE");
                    DrpTotalGrossWeight.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
                }
                else if (TextMode.Text == "2 : Rail" || TextMode.Text == "3 : Road" || TextMode.Text == "5 : Mail" || TextMode.Text == "7 : Pipeline" ||  TextMode.Text == "6 : Multi-model(Not in use)")
                {
                    InwardOther.Visible = true;
                    inhab.Visible = true;
                    inhab1.Visible = true;
                    inhbl.Visible = false;
                    inhab1.Visible = false;
                    phawb.Visible = false;
                    phawb1.Visible = false;
                    inhbl1.Visible = true;
                    load.Visible = true;
                    Locationinfo.Visible = true;
                    inwa.Visible = true;
                    //ContainerDetails.Visible = false;
                    InwardCRUEI.BackColor = System.Drawing.Color.White;
                    InwardName.BackColor = System.Drawing.Color.White;
                    if (TextMode.Text == "3 : Road")
                    {
                         DrpTotalGrossWeight.Items.Clear();
                        DrpTotalGrossWeight.Items.Add("KGM");
                        DrpTotalGrossWeight.Items.Add("TNE");
                        DrpTotalGrossWeight.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
                    }
                }

                else if (TextMode.Text == "N : Not Required")
                {
                  //  carLoadingPort.Visible = false;
                   // inhab.Visible = false;
                    //inhbl.Visible = false;
                    //load.Visible = false;
                    Locationinfo.Visible = true;
                    inwa.Visible = false;
                   /// carArrival.Visible = false;

                }

                else if (TextMode.Text == "4 : Air")
                {
                    InwardFlight.Visible = true;
                    inhab.Visible = true;
                    inhab1.Visible = true;
                    inhbl.Visible = false;
                    inhbl1.Visible = false;
                    phawb.Visible = true;
                    phawb1.Visible = true;
                    load.Visible = true;
                    inwa.Visible = true;
                    Locationinfo.Visible = true;
                    //DrpTotalGrossWeight.Items.Clear();
                    //DrpTotalGrossWeight.Items.Add("TNE");
                    //DrpTotalGrossWeight.Items.Add("KGM");
                    //DrpTotalGrossWeight.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));

                    InwardCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    InwardName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    // ContainerDetails.Visible = false;

                    DrpTotalGrossWeight.Items.Clear();
                    DrpTotalGrossWeight.Items.Add("KGM");
                    DrpTotalGrossWeight.Items.Add("TNE");
                    DrpTotalGrossWeight.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
                }                
            }
                     
            
            if (DrpDecType.SelectedItem.ToString() == "SFZ : STORAGE IN FTZ" || DrpDecType.SelectedItem.ToString() == "REX : FOR RE-EXPORT")
            {
                inhab.Visible = true;
                inhab1.Visible = true;
                inhbl.Visible = false;
                DrpOutwardtrasMode.Focus();
            }
            else
            {
                inhab.Visible = true;
                inhab1.Visible = true;
                inhbl.Visible = false;
                DrpBGIndicator.Focus();
            }
            upinnoncargo.Update();
            innonpayment.Update();
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

                string strTime = System.DateTime.Now.ToString("yyyy/MM/dd");
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
                    TxtDescription.Text = "";
                    TxtBrand.Text = "";
                    TxtModel.Text = "";

                    TxtInHouseItem.Text = requestor;
                    TxtHSCodeItem.Text = requestType;
                    TxtDescription.Text = status;
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
            _objdt = GetHSCodeFromDataBase(HSCodeSearchItem.Text.Replace("'","''"));
            if (_objdt.Rows.Count > 0)
            {
                HSCodeGridItem.DataSource = _objdt;
                HSCodeGridItem.DataBind();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openHSCode();", true);
            }
            popupHSCODE.Show();
        }
        public DataTable GetHSCodeFromDataBase(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = TxtHSCodeItem.Text;

            string str3 = "SELECT * FROM HSCode where HSCode Like '%" + TxtHSCodeItem.Text.Replace("'", "''") + "%' order by Id desc";
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
           // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Inhouse();", true);

            BindInhouse();
        }

        protected void HSCodeGridItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            HSCodeGridItem.PageIndex = e.NewPageIndex;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openHSCode();", true);
            BindHSCode();
        }


        private void BindInhouse()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Top 1000 * FROM InhouseItemCode"))
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
                using (SqlCommand cmd = new SqlCommand("SELECT Top 100 * FROM Country"))
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
                    TxtDescription.Text = "";
                    TxtHSCodeItem.Text = requestType;
                    TxtDescription.Text = status;
                    TxtDescription_TextChanged(null, null);
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

        protected void TxtHSCodeItem_TextChanged(object sender, EventArgs e)
        {
            if (TxtHSCodeItem.Text != "")
            {
                if (TxtHSCodeItem.Text != "")
                {
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
                    string qry11 = "select UOM from HSCode where HSCode='" + ss[0].ToString() + "'";
                    InnonPaymentClass objitm = new InnonPaymentClass();
                    objitm.dr = objitm.ret_dr(qry11);
                    while (objitm.dr.Read())
                    {
                        string UOm = objitm.dr[0].ToString();
                        if (objitm.dr[0].ToString() == "-")
                        {
                            HSQTYUOM.ClearSelection();
                            HSQTYUOM.Items.FindByText(objitm.dr["UOM"].ToString()).Selected = true;
                        }
                        else
                        {
                            HSQTYUOM.ClearSelection();
                            HSQTYUOM.Items.FindByText(UOm).Selected = true;
                        }
                    }
                    //  hscodecoltroll(ss[0].ToString());
                    hscode(ss[0].ToString());
                    string qry111 = "select * from HSCode where HSCode='" + ss[0].ToString() + "'";
                    objitm.dr = objitm.ret_dr(qry111);
                    int typeid = 0;
                    while (objitm.dr.Read())
                    {
                        typeid = Convert.ToInt32(objitm.dr["DUTYTYPID"].ToString());
                        TxtHSCodeItem.Text = objitm.dr["HSCode"].ToString();
                        TxtDescription.Text = objitm.dr["Description"].ToString();

                        is_inpayment_controlled.Text = string.Empty;


                        // Check if the value exists and is not NULL
                    if (objitm.dr["is_innonpayment_controlled"] != DBNull.Value && Convert.ToInt32(objitm.dr["is_innonpayment_controlled"]) != 0)
                     {
                            // Convert to boolean (true for 1, false for 0)
                            bool isControlled = Convert.ToBoolean(objitm.dr["is_innonpayment_controlled"]);

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

                        uom = objitm.dr["DuitableUom"].ToString();
                        exuom = objitm.dr["Excisedutyuom"].ToString();
                        exrate = objitm.dr["Excisedutyrate"].ToString();
                        crate = objitm.dr["Customsdutyrate"].ToString();
                        cuom = objitm.dr["Customsdutyuom"].ToString();
                        BindProduct1();
                    }

                    if (typeid == 62 || typeid == 63 )
                    {
                        if (typeid == 62 && HSQTYUOM.SelectedItem.Text == "LTR")
                        {
                            duti.Visible = true;
                            AlcoholDiv.Visible = true;
                        }
                        else if (typeid == 62 && HSQTYUOM.SelectedItem.Text != "LTR")
                        {
                            duti.Visible = true;
                            AlcoholDiv.Visible = false;
                        }
                        else
                        {
                            duti.Visible = true;
                            AlcoholDiv.Visible = true;
                        }

                        //duti.Visible = true;
                        //AlcoholDiv.Visible = true;


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
                        duti.Visible = true;

                    }
                    else if (typeid == 64)
                    {
                        if (HSQTYUOM.SelectedItem.Text != "LTR")
                        {
                            duti.Visible = true;
                            AlcoholDiv.Visible = false;
                        }
                        else
                        {
                            AlcoholDiv.Visible = true;
                            duti.Visible = true;
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
                        duti.Visible = true;
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
                        duti.Visible = true;
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
                    else
                    {
                        duti.Visible = false;
                        AlcoholDiv.Visible = false;
                    }
                    if (TxtHSCodeItem.Text == "24031100" || TxtHSCodeItem.Text == "24039930" || TxtHSCodeItem.Text == "24039940" || TxtHSCodeItem.Text == "24039950" || TxtHSCodeItem.Text == "24039990" || TxtHSCodeItem.Text == "33021020")
                    {
                        AlcoholDiv.Visible = false;
                    }                    
                }
                else
                {
                    TxtDescription.Text = "";
                }
                
            }
            else
            {
                TxtDescription.Text = "";
            }
            TxtDescription_TextChanged(null, null);
            TxtCountryItem.Focus();

        }




        private void hscode(string hscode)
        {


          


            //string TYPEId = "";
            InnonPaymentClass objhsn = new InnonPaymentClass();
            string qry11s2 = "select * from [CommonMasterType] as a , HSCode as b where a.Id=b.Typeid  and HSCode='" + hscode + "' and InnonPayment=1";
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

            string dutable = "select * from [CommonMasterType] as a , HSCode as b where a.Id=b.DUTYTYPID  and HSCode='" + hscode + "' and InnonPayment=1";
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

            string str3 = "SELECT * FROM Country where CountryCode Like '%" + CountrySearchItem.Text + "%' order by Id desc";
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
          //  ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openCountry();", true);
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
                    TxtCountryItem.Text = "";

                    txtcname.Text = status;
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

            string str3 = "SELECT * FROM CASCProductCodes where CASCCode Like '%" + ProductCode1Search.Text + "%' order by Id desc";
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
            string testste = dropdownlist5.SelectedValue.ToString();
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
        protected void dropdownlist5_SelectedIndexChanged(object sender, EventArgs e)
        {
            showSessionData();
            //don't call datashow() method in this call only showsessionData();

        }
        private void BindProduct1()
        {
            if (!string.IsNullOrWhiteSpace(TxtHSCodeItem.Text))
            {
                string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT Top 100 * FROM CASCProductCodes where HSCode='" + TxtHSCodeItem.Text + "'"))
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
            TxtProQty1.Focus();
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
            showSessionData();
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
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM CASCProductCodes"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet dt = new DataSet())
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
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM CASCProductCodes"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet dt = new DataSet())
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


        //Product Code4
        private void BindProduct4()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM CASCProductCodes"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet dt = new DataSet())
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
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM CASCProductCodes"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet dt = new DataSet())
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

        private void BindImportparty()
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
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalImportParty();", true);
            }
        }

        protected void ImportPartyGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ImportPartyGrid.PageIndex = e.NewPageIndex;
            //  ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalImportParty();", true);
            popupinnoninvimp.Show();
            popupinnoninvimp.X = 400;
            popupinnoninvimp.Y = 100;
            BindImport();
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

            string str3 = "SELECT Id,Code,Name,Name1,CRUEI FROM Importer where Code Like '%" + ImportPartySearch.Text + "%' order by Id desc";
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
                string qry11 = "select * from Importer where Code='" + ss[0].ToString() + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    TxtImppartyCode.Text = obj.dr[1].ToString();
                    TxtImppartyName.Text = obj.dr[2].ToString();
                    TxtImppartyName1.Text = obj.dr[3].ToString();
                    TxtImppartyCRUEI.Text = obj.dr[4].ToString();
                }
            }
            else
            {
                TxtImppartyCode.Text = "";
                TxtImppartyName.Text = "";
                TxtImppartyName1.Text = "";
                TxtImppartyCRUEI.Text = "";
            }
            innonpayment.Update();
            upinnonsummary.Update();

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

                string strTime = System.DateTime.Now.ToString("yyyy/MM/dd");
                string StrQuery = ("INSERT INTO [dbo].[Importer] ([Code],[Name],[Name1],[CRUEI],[TouchUser],[TouchTime]) VALUES ('" + TxtImppartyCode.Text + "','" + TxtImppartyName.Text + "','" + TxtImppartyName1.Text + "','" + TxtImppartyCRUEI.Text + "','" + Touch_user + "',Convert(VARCHAR,'" + strTime + "',108))");
                obj.exec(StrQuery);
                BindImportparty();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Importer Code Already Exist..');", true);
                //  Response.Write("The Importer Code Already Exist..");
            }
            txtinvNo.Focus();

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
        }
        protected void sumofinsurance()
        {
            double INV, fright, tot, insurance, excharge, insamt;
            bool INS = double.TryParse(SumTotalInvoice.Text.Trim(), out INV);
            bool freight = double.TryParse(SumFrieghtCharges.Text.Trim(), out fright);
            bool ins = double.TryParse(InsuranceChargesPer.Text.Trim(), out insurance);
            bool exrate = double.TryParse(lblInsuranceCharges.Text.Trim(), out excharge);
            tot = INV + fright;
            if (insurance > 0)
            {
                SumInsuranceCharges.Text = string.Format("{0:N}", Convert.ToDouble(Math.Round((insurance * tot / 100), 4).ToString()));
            }

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
            }
            double GST, Gpere;
            bool G1 = double.TryParse(LblSumOFTotal.Text.Trim(), out GST);
            bool G2 = double.TryParse(LblGSTpercentage.Text.Trim(), out Gpere);
            if (G1 && G2)
            {
                string SumGSTTo = string.Format("{0:N}", Convert.ToDouble(Math.Round((GST * Gpere / 100), 2).ToString()));
                lblGSTAmount.Text = SumGSTTo;
            }
            //warning FC
            double INV, OTC;
            bool invoice = double.TryParse(SumTotalInvoice.Text.Trim(), out INV);
            bool othertax = double.TryParse(SumOtherTaxableCharge.Text.Trim(), out OTC);            
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
            }
            double GST, Gpere;
            bool G1 = double.TryParse(LblSumOFTotal.Text.Trim(), out GST);
            bool G2 = double.TryParse(LblGSTpercentage.Text.Trim(), out Gpere);
            if (G1 && G2)
            {
                string SumGSTTo = string.Format("{0:N}", Convert.ToDouble(Math.Round((GST * Gpere / 100), 4).ToString()));
                lblGSTAmount.Text = SumGSTTo;
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
                        double INV, fright, tot, insurance, excharge;
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
        }


        //Validation Page Change
        protected void TxtRECPT3_TextChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Party();", true);
        }

        private void InvoiceNo()
        {
            con.Open();
            SqlCommand command1q = new SqlCommand("SELECT Count(*) from [InNonInvoiceDtl] where MessageType='INPDEC'  and PermitId='" + txt_code.Text + "'  ");
            command1q.Connection = con;
            int max_po_noq = Convert.ToInt32(command1q.ExecuteScalar());           
            string codeq = " " + String.Format("{0:000}", max_po_noq + 1);
            con.Close();
            txtserial.Text = codeq;



        }

        private void requriedInvoice()
        {
            if (txtinvNo.Text == "")
            {
                ErrorDes = "Invoice -  Please Enter Invoice Number : ";

            }
            if (TxtImppartyCode.Text == "")
            {
                ErrorDes = "Invoice -  Please Enter Importer Party : ";

            }
            if (txtinvDate1.Text == "")
            {
                ErrorDes = "Invoice -  Please Enter Invoice Date : ";

            }
            if (TxtImpCode.Text != TxtImppartyCode.Text)
            {
                ErrorDes = "Please Check Party-> Importer same as Invoice-> Importer Party : ";
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
                    lbl.Width = 150;
                    totinvAmt = totinvAmt + " " + lbl.Text + " " + Environment.NewLine;
                    div3.Controls.Add(lbl);
                    div3.Controls.Add(new LiteralControl("<br />"));

                    lblerrorinv.Text = totinvAmt;
                    lblerrorinv.Visible = true;
                    upinnoninvoice.Update();
                }
            }
            else
            {
                lblerrorinv.Text = "";
                lblerrorinv.Visible = false;
                upinnoninvoice.Update();
            }
        }

        protected void BtnAddInvoice_Click(object sender, EventArgs e)
        {
            requriedInvoice();
            if (lblerrorinv.Text != "")
            {
                lblerrorinv.Focus();
            }
            else
            {
                string Code = "";
                string qry1111 = "SELECT * FROM InNonInvoiceDtl where  MessageType='INPDEC' AND PermitId='" + txt_code.Text + "' and Sno='" + txtserial.Text + "'";
                obj.dr = obj.ret_dr(qry1111);
                while (obj.dr.Read())
                {
                    Code = obj.dr[2].ToString();
                }


                if (Code == "")
                {
                    string Touch_user = Session["UserId"].ToString();
                    string strTime = System.DateTime.Now.ToString("yyyy/MM/dd");
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
                    string StrQuery1 = ("INSERT INTO [dbo].[InNonInvoiceDtl] ([SNo],[InvoiceNo],[InvoiceDate],[TermType],[AdValoremIndicator],[PreDutyRateIndicator],[SupplierImporterRelationship],[SupplierCode],[ImportPartyCode],[TICurrency],[TIExRate],[TIAmount],[TISAmount],[OTCCharge],[OTCCurrency],[OTCExRate],[OTCAmount],[OTCSAmount],[FCCharge],[FCCurrency],[FCExRate],[FCAmount],[FCSAmount],[ICCharge],[ICCurrency],[ICExRate],[ICAmount],[ICSAmount],[CIFSUMAmount],[GSTPercentage],[GSTSUMAmount],[MessageType],[PermitId],[TouchUser],[TouchTime]) VALUES ( '" + txtserial.Text + "','" + txtinvNo.Text + "','" + Convert.ToDateTime(InvoiceDate).ToString("yyyy/MM/dd") + "','" + DrpTerms.SelectedItem.Text + "','" + chkindicator.Checked.ToString() + "','" + chkrateind.Checked.ToString() + "','" + DrpSupImpRel.SelectedItem + "','" + txtcodeinvq.Text + "','" + TxtImppartyCode.Text + "','" + Drpcurrency1.SelectedItem.Text + "','" + Convert.ToDecimal(LblTotalInvoice.Text) + "','" + Convert.ToDecimal(TxtTotalInvoice.Text) + "','" + Convert.ToDecimal(SumTotalInvoice.Text) + "','" + Convert.ToDecimal(OtherTaxableChargePer.Text) + "','" + Drpcurrency2.SelectedItem.ToString() + "','" + Convert.ToDecimal(lblOtherTaxableCharge.Text) + "','" + Convert.ToDecimal(TxtOtherTaxableCharge.Text) + "','" + Convert.ToDecimal(SumOtherTaxableCharge.Text) + "','" + Convert.ToDecimal(FrieghtChargesPer.Text) + "','" + Drpcurrency3.SelectedItem.ToString() + "','" + Convert.ToDecimal(LblFrieghtCharges.Text) + "','" + Convert.ToDecimal(TxtFrieghtCharges.Text) + "','" + Convert.ToDecimal(SumFrieghtCharges.Text) + "','" + Convert.ToDecimal(InsuranceChargesPer.Text) + "','" + Drpcurrency4.SelectedItem.ToString() + "','" + Convert.ToDecimal(lblInsuranceCharges.Text) + "','" + Convert.ToDecimal(TxtInsuranceCharges.Text) + "','" + Convert.ToDecimal(SumInsuranceCharges.Text) + "','" + Convert.ToDecimal(LblSumOFTotal.Text) + "','" + Convert.ToDecimal(LblGSTpercentage.Text) + "','" + Convert.ToDecimal(lblGSTAmount.Text) + "','" + TxtMsgType.Text + "','" + txt_code.Text + "','" + Touch_user + "','" + strTime + "')");
                    obj.exec(StrQuery1);
                    obj.closecon();
                    BindInvoice();




                    InvoiceNo();

                    string SumInvoice = "";
                    string qry11 = "select Count(InvoiceNo) as InvCount from dbo.InNonInvoiceDtl where PermitId='" + txt_code.Text + "' and MessageType='INPDEC'";
                    obj.dr = obj.ret_dr(qry11);
                    while (obj.dr.Read())
                    {
                        SumInvoice = obj.dr[0].ToString();
                        txtnoofinv.Text = SumInvoice;
                    }
                    InvoiceGrid.Visible = true;
                    InvoiceDiv.Visible = true;
                    //NewInvoice.Visible = true;
                    InvoiceClr();


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

                    //if (Code == "")
                    //{
                    string StrQuery1 = ("update [dbo].[InNonInvoiceDtl] set [Invoiceno]='" + txtinvNo.Text + "', [InvoiceDate]='" + Convert.ToDateTime(InvoiceDate).ToString("yyyy/MM/dd") + "',[TermType] ='" + DrpTerms.SelectedItem + "',[AdValoremIndicator]='" + chkindicator.Checked.ToString() + "',[PreDutyRateIndicator]='" + chkrateind.Checked.ToString() + "',[SupplierImporterRelationship]='" + DrpSupImpRel.SelectedItem + "',[SupplierCode]='" + txtcodeinvq.Text + "',[ImportPartyCode]='" + TxtImppartyCode.Text + "',[TICurrency]='" + Drpcurrency1.SelectedItem + "' ,[TIExRate]='" + Convert.ToDecimal(LblTotalInvoice.Text) + "',[TIAmount]='" + Convert.ToDecimal(TxtTotalInvoice.Text) + "',[TISAmount]='" + Convert.ToDecimal(SumTotalInvoice.Text) + "',[OTCCharge]='" + Convert.ToDecimal(OtherTaxableChargePer.Text) + "',[OTCCurrency]='" + Drpcurrency2.SelectedItem + "',[OTCExRate]='" + Convert.ToDecimal(lblOtherTaxableCharge.Text) + "',[OTCAmount]='" + Convert.ToDecimal(TxtOtherTaxableCharge.Text) + "', [OTCSAmount]='" + Convert.ToDecimal(SumOtherTaxableCharge.Text) + "',[FCCharge]='" + Convert.ToDecimal(FrieghtChargesPer.Text) + "',[FCCurrency]='" + Drpcurrency3.SelectedItem + "',[FCExRate]='" + Convert.ToDecimal(LblFrieghtCharges.Text) + "',[FCAmount]='" + Convert.ToDecimal(TxtFrieghtCharges.Text) + "',[FCSAmount]='" + Convert.ToDecimal(SumFrieghtCharges.Text) + "',[ICCharge]='" + Convert.ToDecimal(InsuranceChargesPer.Text) + "',[ICCurrency]='" + Drpcurrency4.SelectedItem + "',[ICExRate]='" + Convert.ToDecimal(lblInsuranceCharges.Text) + "',[ICAmount]='" + Convert.ToDecimal(TxtInsuranceCharges.Text) + "',[ICSAmount]='" + Convert.ToDecimal(SumInsuranceCharges.Text) + "',[CIFSUMAmount]='" + Convert.ToDecimal(LblSumOFTotal.Text) + "',[GSTPercentage]='" + LblGSTpercentage.Text + "',[GSTSUMAmount]='" + Convert.ToDecimal(lblGSTAmount.Text) + "',[TouchUser]='" + Touch_user + "',[TouchTime]='" + strTime + "'  where  MessageType='INPDEC' AND PermitId='" + txt_code.Text + "' and Sno='" + txtserial.Text + "' ");
                    obj.exec(StrQuery1);
                    obj.closecon();

                    StrQuery1 = ("update [dbo].[InNonItemDtl] set [InvoiceNo]='" + txtinvNo.Text + "' where  MessageType='INPDEC' AND PermitId='" + txt_code.Text + "'");
                    obj.exec(StrQuery1);
                    obj.closecon();
                    BindInvoice();
                    InvoiceGrid.Visible = true;
                    InvoiceDiv.Visible = true;
                    //NewInvoice.Visible = true;
                    InvoiceClr();
                }
                string Invoice = txt_code.Text;
                string striW = "select * from [InNonInvoiceDtl] where MessageType='INPDEC' AND PermitId='" + Invoice + "'  order by InvoiceNo";
                obj.dr = obj.ret_dr(striW);
                obj.BindDropDown(DrpInvoiceNo, obj.dr, "Id", "InvoiceNo");                
                SummaryCalculate();
                //  InvoiceClr();
            }
        }
        private void BindInvoice()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Top 20 *,FORMAT(InvoiceDate, 'dd/MM/yyyy') AS INVDatee,SUBSTRING(TermType, 1, 3) as tt FROM InNonInvoiceDtl where PermitId='" + txt_code.Text + "' and MessageType='INPDEC' order by Id"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet dt = new DataSet())
                        {
                            sda.Fill(dt);
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

            string str3 = "SELECT * FROM InNonInvoiceDtl where InvoiceNo Like '%" + AddInvoiceSearch.Text + "%' order by Id desc";
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
        private void MSGNO()
        {
            string MSGCount = "";
            string justdate = DateTime.Now.ToString("yyyyMMdd");
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
            SqlCommand command1 = new SqlCommand("SELECT Max(Refid) from InNonHeaderTbl where MessageType='INPDEC' and  LEFT(MSGId,8) ='" + justdate + "'");
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
            string Touch_user = Session["UserId"].ToString();
            string justdate = DateTime.Now.ToString("yyyyMMdd");
            con.Open();
            SqlCommand command1 = new SqlCommand("SELECT max(Refid) from InNonHeaderTbl where MessageType='INPDEC' and  LEFT(MSGId,8) ='" + justdate + "'");
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
            string qry11 = "SELECT COUNT(PermitId) as JobId  from PermitCount where AccountId='" + Session["AccountId"].ToString() + "' and TouchTime ='" + justdate + "' ";
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
        
        private void ItemNO()
        {
            con.Open();
            SqlCommand command1113 = new SqlCommand("SELECT max(ItemNo) from [InNonItemDtl] where MessageType='INPDEC'  and PermitId='" + txt_code.Text + "'  ");
            command1113.Connection = con;
            string max_po_no3 = command1113.ExecuteScalar().ToString();
            int m_po_no3 = 0;

            int endTagStartPosition3 = max_po_no3.LastIndexOf("/");
            max_po_no3 = max_po_no3.Substring(endTagStartPosition3 + 1);
            if (max_po_no3 != "")
            {
                m_po_no3 = Convert.ToInt32(max_po_no3);
            }
            else
            {
                m_po_no3 = 0;
            }
            if (max_po_no3 != "0")
            {
                m_po_no3 = m_po_no3 + 1;

            }
            string code3 = " " + String.Format("{0:000}", m_po_no3);
            con.Close();
            TxtSerialNo.Text = code3;


        }
        public void Editdata()
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
            DateTime BlanketDate = Convert.ToDateTime(null);
            // var BlanketDate = DateTime.Parse(this.BlankDate1.Text, new CultureInfo("en-US", true));
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


            DateTime DepatureDate = Convert.ToDateTime(null);
            // var DepatureDate = DateTime.Parse(this.TxtExpArrivalDate1.Value, new CultureInfo("en-US", true));
            if (TxtExpArrivalDate1.Text == "")
            {
                var date = "01/01/1900";
                //var date = DateTime.Now.ToString("dd/MM/yyyy");
                var manDate = DateTime.ParseExact(date, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                DepatureDate = Convert.ToDateTime(manDate);
            }
            else
            {
                var InvoiceDate1 = DateTime.ParseExact(TxtExpArrivalDate1.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                DepatureDate = Convert.ToDateTime(InvoiceDate1);
            }
            
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
               
                   
                  //  MSGNO();
                
             ////Count Permit
            string TouchDate = DateTime.Now.ToString("yyyy/MM/dd");
            string CopyMsg = "";
            string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); 

            string Mco = "SELECT MsgId FROM PermitCount where MsgId='" + MsgNO + "' and TouchTime='" + TouchDate + "'";
            obj.dr = obj.ret_dr(Mco);
            while (obj.dr.Read())
            {
                CopyMsg = obj.dr["MsgId"].ToString();
            }
            if (CopyMsg == "")
            {


                string StrQuery = (" Update InNonHeaderTbl set GrossReference='" + TxtGrossReference.Text + "', Refid='" + refno + "',Cnb='" + chkcnb.Checked.ToString() + "',MSGId='" + MsgNO + "',ExhibitionSDate='" + txtExStartDate.Text + "',PreviousPermit='" + TxtPrevPerNO.Text + "',seastore='" + chkSea.Checked.ToString() + "', ExhibitionEDate='" + txtExEndDate.Text + "',TradeRemarks='" + txttrdremrk.Text + "', InternalRemarks='" + txtintremrk.Text + "', TradeNetMailboxID='" + TxtTradeMailID.Text + "',MessageType='" + TxtMsgType.Text + "',DeclarationType='" + DrpDecType.SelectedItem.ToString() + "',CargoPackType='" + DrpCargoPackType.SelectedItem.ToString() + "',InwardTransportMode='" + DrpInwardtrasMode.SelectedItem.ToString() + "', OutwardTransportMode='" + DrpOutwardtrasMode.SelectedItem.ToString() + "',BGIndicator='" + DrpBGIndicator.SelectedItem.ToString() + "',SupplyIndicator='" + ChkSupplyIndicator.Checked.ToString() + "',ReferenceDocuments='" + ChkRefDoc.Checked.ToString() + "',License='" + License + "',Recipient='" + Recipient + "',DeclarantCompanyCode='" + TxtDecCompCode.Text + "',ImporterCompanyCode='" + TxtImpCode.Text + "',ExporterCompanyCode='" + TxtExpCode.Text + "',InwardCarrierAgentCode='" + InwardCode.Text + "',OutwardCarrierAgentCode='" + OutwardCode.Text + "',FreightForwarderCode='" + FrieghtCode.Text + "',ClaimantPartyCode='" + ClaimantName.Text + "',ConsigneeCode='" + ConsigneeCode.Text + "',ArrivalDate='" + Convert.ToDateTime(ArrivalDate).ToString("yyyy/MM/dd") + "',LoadingPortCode='" + TxtLoadShort.Text + "',VoyageNumber='" + TxtVoyageno.Text + "',VesselName='" + TxtVesselName.Text + "',OceanBillofLadingNo='" + TxtOceanBill.Text + "',ConveyanceRefNo='" + TxtConRefNo.Text + "',TransportId='" + TxtTrnsID.Text + "',FlightNO='" + txtflight.Text + "',AircraftRegNo='" + txtaircraft.Text + "',MasterAirwayBill='" + txtwaybill.Text + "',ReleaseLocation='" + txtreLoctn.Text + "',ReleaseLocaName='" + txtrelocDeta.Text + "',RecepitLocation='" + txtrecloctn.Text + "',RecepilocaName='" + txtrecloctndet.Text + "',StorageLocation='"+txtstrgeloc.Text+"',BlanketStartDate='" + Convert.ToDateTime(BlanketDate).ToString("yyyy/MM/dd") + "',DepartureDate='" + Convert.ToDateTime(DepatureDate).ToString("yyyy/MM/dd") + "',DischargePort='" + TxtExpLoadShort.Text + "',FinalDestinationCountry='" + DrpFinalDesCountry.SelectedItem.ToString() + "',OutVoyageNumber='" + OUTWARDVoyageNo.Text + "',OutVesselName='" + OUTWARDVessel.Text + "',OutOceanBillofLadingNo='" + OUTWARDOcenbill.Text + "',VesselType='" + ddpVessel.SelectedItem.ToString() + "',VesselNetRegTon='" + txtvesnet.Text + "',VesselNationality='" + DroVesslNat.SelectedItem.ToString() + "',TowingVesselID='" + txtTowVes.Text + "',TowingVesselName='" + txtTowVes.Text + "',NextPort='" + txtNextprt.Text + "',LastPort='" + txtLasPrt.Text + "',OutConveyanceRefNo='" + OUTWARDConref.Text + "',OutTransportId='" + OUTWARDTransId.Text + "',OutFlightNO='" + OUTWARDFlightN0.Text + "',OutAircraftRegNo='" + OUTWARDAirREgno.Text + "',OutMasterAirwayBill='" + OUTWARDAirwaybill.Text + "',TotalOuterPack='" + TxttotalOuterPack.Text + "',TotalOuterPackUOM='" + DrptotalOuterPack.SelectedItem.ToString() + "',TotalGrossWeight='" + TxtTotalGrossWeight.Text + "',TotalGrossWeightUOM='" + DrpTotalGrossWeight.SelectedItem.ToString() + "',NumberOfItems='" + txtnoofitm.Text + "',TotalCIFFOBValue='" + txtfobval.Text + "',TotalGSTTaxAmt='" + txttotgstAmt.Text + "',TotalODutyAmt='" + txtothtaxAmt.Text + "',TotalCusDutyAmt='" + txtcusdutyAmt.Text + "',TotalExDutyAmt='" + txttotexAmt.Text + "',Status='" + "NEW" + "',prmtStatus='" + prmstatus + "',Inhabl='" + txthblCargo.Text + "',outhbl='" + txtouthblCargo.Text + "',TouchUser='" + Touch_user + "',TouchTime=Convert(VARCHAR,'" + strTime + "',108) where Id='" + Id + "'");
                obj.exec(StrQuery);
            }
            else
            {

                string StrQuery = (" Update InNonHeaderTbl set GrossReference='" + TxtGrossReference.Text + "',Refid='" + refno + "',Cnb='" + chkcnb.Checked.ToString() + "',ExhibitionSDate='" + txtExStartDate.Text + "', ExhibitionEDate='" + txtExEndDate.Text + "',seastore='" + chkSea.Checked.ToString() + "',PreviousPermit='" + TxtPrevPerNO.Text + "',TradeRemarks='" + txttrdremrk.Text + "', InternalRemarks='" + txtintremrk.Text + "', TradeNetMailboxID='" + TxtTradeMailID.Text + "',MessageType='" + TxtMsgType.Text + "',DeclarationType='" + DrpDecType.SelectedItem.ToString() + "',CargoPackType='" + DrpCargoPackType.SelectedItem.ToString() + "',InwardTransportMode='" + DrpInwardtrasMode.SelectedItem.ToString() + "', OutwardTransportMode='" + DrpOutwardtrasMode.SelectedItem.ToString() + "',BGIndicator='" + DrpBGIndicator.SelectedItem.ToString() + "',SupplyIndicator='" + ChkSupplyIndicator.Checked.ToString() + "',ReferenceDocuments='" + ChkRefDoc.Checked.ToString() + "',License='" + License + "',Recipient='" + Recipient + "',DeclarantCompanyCode='" + TxtDecCompCode.Text + "',ImporterCompanyCode='" + TxtImpCode.Text + "',ExporterCompanyCode='" + TxtExpCode.Text + "',InwardCarrierAgentCode='" + InwardCode.Text + "',OutwardCarrierAgentCode='" + OutwardCode.Text + "',FreightForwarderCode='" + FrieghtCode.Text + "',ClaimantPartyCode='" + ClaimantName.Text + "',ConsigneeCode='" + ConsigneeCode.Text + "',ArrivalDate='" + Convert.ToDateTime(ArrivalDate).ToString("yyyy/MM/dd") + "',LoadingPortCode='" + TxtLoadShort.Text + "',VoyageNumber='" + TxtVoyageno.Text + "',VesselName='" + TxtVesselName.Text + "',OceanBillofLadingNo='" + TxtOceanBill.Text + "',ConveyanceRefNo='" + TxtConRefNo.Text + "',TransportId='" + TxtTrnsID.Text + "',FlightNO='" + txtflight.Text + "',AircraftRegNo='" + txtaircraft.Text + "',MasterAirwayBill='" + txtwaybill.Text + "',ReleaseLocation='" + txtreLoctn.Text + "',ReleaseLocaName='" + txtrelocDeta.Text + "',RecepitLocation='" + txtrecloctn.Text + "',RecepilocaName='" + txtrecloctndet.Text + "',StorageLocation='" + txtstrgeloc.Text + "',BlanketStartDate='" + Convert.ToDateTime(BlanketDate).ToString("yyyy/MM/dd") + "',DepartureDate='" + Convert.ToDateTime(DepatureDate).ToString("yyyy/MM/dd") + "',DischargePort='" + TxtExpLoadShort.Text + "',FinalDestinationCountry='" + DrpFinalDesCountry.SelectedItem.ToString() + "',OutVoyageNumber='" + OUTWARDVoyageNo.Text + "',OutVesselName='" + OUTWARDVessel.Text + "',OutOceanBillofLadingNo='" + OUTWARDOcenbill.Text + "',VesselType='" + ddpVessel.SelectedItem.ToString() + "',VesselNetRegTon='" + txtvesnet.Text + "',VesselNationality='" + DroVesslNat.SelectedItem.ToString() + "',TowingVesselID='" + txtTowVes.Text + "',TowingVesselName='" + txtTowVes.Text + "',NextPort='" + txtNextprt.Text + "',LastPort='" + txtLasPrt.Text + "',OutConveyanceRefNo='" + OUTWARDConref.Text + "',OutTransportId='" + OUTWARDTransId.Text + "',OutFlightNO='" + OUTWARDFlightN0.Text + "',OutAircraftRegNo='" + OUTWARDAirREgno.Text + "',OutMasterAirwayBill='" + OUTWARDAirwaybill.Text + "',TotalOuterPack='" + TxttotalOuterPack.Text + "',TotalOuterPackUOM='" + DrptotalOuterPack.SelectedItem.ToString() + "',TotalGrossWeight='" + TxtTotalGrossWeight.Text + "',TotalGrossWeightUOM='" + DrpTotalGrossWeight.SelectedItem.ToString() + "',NumberOfItems='" + txtnoofitm.Text + "',TotalCIFFOBValue='" + txtfobval.Text + "',TotalGSTTaxAmt='" + txttotgstAmt.Text + "',TotalODutyAmt='" + txtothtaxAmt.Text + "',TotalCusDutyAmt='" + txtcusdutyAmt.Text + "',TotalExDutyAmt='" + txttotexAmt.Text + "',Status='" + "NEW" + "',prmtStatus='" + prmstatus + "',Inhabl='" + txthblCargo.Text + "',outhbl='" + txtouthblCargo.Text + "',TouchUser='" + Touch_user + "',TouchTime=Convert(VARCHAR,'" + strTime + "',108) where Id='" + Id + "'");
                obj.exec(StrQuery);
            }

           
                                   
            string StrdeleteQuery = ("delete from InnonContainerDtl where PermitId='" + txt_code.Text + "'");
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
                        string StrQuery1 = ("INSERT INTO [dbo].[InnonContainerDtl] ([PermitId],[RowNo],[ContainerNo],[Size],[Weight],[SealNo],[MessageType],[TouchUser],[TouchTime]) VALUES ('" + txt_code.Text + "','" + i + "','" + ContainerNo + "','" + ContainerSize + "','" + ContainerWeight + "','" + Containerseal + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "')");
                        obj.exec(StrQuery1);
                        obj.closecon();
                    }
                    i++;
                }
            }

            //CPC
            string cpc = ("delete from InNonCPCDtl where PermitId='" + txt_code.Text + "' and CPCType='AEO'");
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
                    string StrQuery1 = ("INSERT INTO [dbo].[InNonCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + j + "','AEO','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                    obj.exec(StrQuery1);
                    obj.closecon();
                }
                j++;
            }
            string cec = ("delete from InNonCPCDtl where PermitId='" + txt_code.Text + "' and CPCType='CWC'");
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
                    string StrQuery1 = ("INSERT INTO [dbo].[InNonCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + K + "','CWC','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                    obj.exec(StrQuery1);
                    obj.closecon();
                }
                K++;
            }

            cec = ("delete from InNonCPCDtl where PermitId='" + txt_code.Text + "' and CPCType='SEASTORE'");
            obj.exec(cec);
            obj.closecon();
            K = 1;

            foreach (GridViewRow g1 in SeaGrid.Rows)
            {
                string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;

                string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                if (ProcessingCode1 != "")
                {
                    string StrQuery1 = ("INSERT INTO [dbo].[InNonCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + K + "','SEASTORE','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                    obj.exec(StrQuery1);
                    obj.closecon();
                }
                K++;
            }

            int c = 1;
            foreach (GridViewRow g1 in SchemeGrid.Rows)
            {
                string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;
                string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                if (ProcessingCode1 != "")
                {
                    string StrQuery1 = ("INSERT INTO [dbo].[InNonCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + c + "','SCHEME','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                    obj.exec(StrQuery1);
                    obj.closecon();
                }
                c++;
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

            int l = 1;
            foreach (GridViewRow g1 in IcGrid.Rows)
            {
                string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;
                string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                if (ProcessingCode1 != "")
                {
                    string StrQuery1 = ("INSERT INTO [dbo].[InNonCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + l + "','IC','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                    obj.exec(StrQuery1);
                    obj.closecon();
                }
                l++;
            }

            if (prmstatus == "NEW")
            {
                Response.Redirect("InNonpaymentList.aspx");
            }
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
                    Id = Convert.ToInt16(Session["Id"].ToString());
                    if (Id != 0)
                    {
                        Editdata();
                        InvoiceClr();
                        Itemclear();
                        Session["Edit"] = false;
                        //eid = 0;
                    }
                    else
                    {
                        int chkCode = 0;
                        string Code = "";
                        string qry11 = "SELECT PermitId FROM InNonHeaderTbl where PermitId='" + txt_code.Text + "' and MessageType='INPDEC'";
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

                            //var ArrivalDate = DateTime.Parse(this.TxtArrivalDate1.Text, new CultureInfo("en-US", true));
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
                            DateTime BlanketDate = Convert.ToDateTime(null);
                            // var BlanketDate = DateTime.Parse(this.BlankDate1.Text, new CultureInfo("en-US", true));
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


                            DateTime DepatureDate = Convert.ToDateTime(null);
                            // var DepatureDate = DateTime.Parse(this.TxtExpArrivalDate1.Value, new CultureInfo("en-US", true));
                            if (BlankDate1.Text == "")
                            {
                                var date = DateTime.Now.ToString("dd/MM/yyyy");
                                var manDate = DateTime.ParseExact(date, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                                DepatureDate = Convert.ToDateTime(manDate);
                            }
                            else
                            {
                                var InvoiceDate1 = DateTime.ParseExact(TxtExpArrivalDate1.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                                DepatureDate = Convert.ToDateTime(InvoiceDate1);
                            }
                            JobNO();
                            MSGNO();
                            refid();

                        Save:
                            string strTime = System.DateTime.Now.ToString("yyyy/MM/dd");
                        string StrQuery = ("INSERT INTO [dbo].[InNonHeaderTbl] ([Refid],[JobId],[MSGId],[PermitId],[TradeNetMailboxID],[MessageType],[DeclarationType],PreviousPermit,[CargoPackType],[InwardTransportMode],[OutwardTransportMode],[BGIndicator],[SupplyIndicator],[ReferenceDocuments],[License],[Recipient],[DeclarantCompanyCode],[ImporterCompanyCode],[ExporterCompanyCode],[InwardCarrierAgentCode],[OutwardCarrierAgentCode],[FreightForwarderCode],[ConsigneeCode],[ClaimantPartyCode],[ArrivalDate],[LoadingPortCode],[VoyageNumber],[VesselName],[OceanBillofLadingNo],[ConveyanceRefNo],[TransportId],[FlightNO],[AircraftRegNo],[MasterAirwayBill],[ReleaseLocation],[ReleaseLocaName],[RecepitLocation],RecepilocaName,StorageLocation,ExhibitionSDate,ExhibitionEDate,[BlanketStartDate],[TradeRemarks] ,[InternalRemarks],[CustomerRemarks] ,[DepartureDate],[DischargePort],[FinalDestinationCountry],[OutVoyageNumber],[OutVesselName],[OutOceanBillofLadingNo],[VesselType],[VesselNetRegTon],[VesselNationality],[TowingVesselID],[TowingVesselName],[NextPort],[LastPort],[OutConveyanceRefNo],[OutTransportId],[OutFlightNO],[OutAircraftRegNo],[OutMasterAirwayBill],[TotalOuterPack],[TotalOuterPackUOM],[TotalGrossWeight],[TotalGrossWeightUOM],GrossRefrence,[DeclareIndicator],[NumberOfItems],[TotalCIFFOBValue],[TotalGSTTaxAmt],[TotalExDutyAmt],[TotalCusDutyAmt],[TotalODutyAmt],[TotalAmtPay],[Status],[prmtStatus],[TouchUser],[TouchTime],[Cnb])  VALUES('" + refno + "','" + JobNo + "','" + MsgNO + "','" + txt_code.Text + "','" + TxtTradeMailID.Text + "','" + TxtMsgType.Text + "','" + DrpDecType.SelectedItem.ToString() + "','" + TxtPrevPerNO.Text + "','" + DrpCargoPackType.SelectedItem.ToString() + "','" + DrpInwardtrasMode.SelectedItem.ToString() + "','" + DrpOutwardtrasMode.SelectedItem.ToString() + "','" + DrpBGIndicator.SelectedItem.ToString() + "','" + ChkSupplyIndicator.Checked.ToString() + "','" + ChkRefDoc.Checked.ToString() + "','" + License + "','" + Recipient + "', '" + TxtDecCompCode.Text + "','" + TxtImpCode.Text + "','" + TxtExpCode.Text + "','" + InwardCode.Text + "','" + OutwardCode.Text + "','" + FrieghtCode.Text + "','" + ConsigneeCode.Text + "','" + ClaimantName.Text + "','" + Convert.ToDateTime(ArrivalDate).ToString("yyyy/MM/dd") + "','" + TxtLoadShort.Text + "','" + TxtVoyageno.Text + "','" + TxtVesselName.Text + "','" + TxtOceanBill.Text + "','" + TxtConRefNo.Text + "','" + TxtTrnsID.Text + "','" + txtflight.Text + "','" + txtaircraft.Text + "','" + txtwaybill.Text + "','" + txtreLoctn.Text + "','"+txtrelocDeta.Text+"','" + txtrecloctn.Text + "','" + txtrecloctn.Text + "','" + txtstrgeloc.Text + "','" + txtExStartDate.Text + "','" + txtExEndDate.Text + "','" + Convert.ToDateTime(BlanketDate).ToString("yyyy/MM/dd") + "','" + txttrdremrk.Text + "','" + txtintremrk.Text + "','" + txtcusRemrk.Text + "','" + Convert.ToDateTime(DepatureDate).ToString("yyyy/MM/dd") + "','" + TxtExpLoadShort.Text + "','" + DrpFinalDesCountry.SelectedItem + "','" + OUTWARDVoyageNo.Text + "','" + OUTWARDVessel.Text + "','" + OUTWARDOcenbill.Text + "','" + ddpVessel.SelectedItem + "','" + txtvesnet.Text + "','" + DroVesslNat.SelectedItem + "','" + txtTowVes.Text + "','" + txtTowVesName.Text + "','" + txtNextprt.Text + "','" + txtLasPrt.Text + "','" + OUTWARDConref.Text + "','" + OUTWARDTransId.Text + "','" + OUTWARDFlightN0.Text + "','" + OUTWARDAirREgno.Text + "','" + OUTWARDAirwaybill.Text + "','" + TxttotalOuterPack.Text + "','" + DrptotalOuterPack.SelectedItem.ToString() + "','" + TxtTotalGrossWeight.Text + "','" + DrpTotalGrossWeight.SelectedItem.ToString() + "','"+TxtGrossReference.Text+"','" + chkalrt.Checked.ToString().ToLower() + "','" + txtnoofitm.Text + "','" + txtfobval.Text + "','" + txttotgstAmt.Text + "','" + txttotexAmt.Text + "','" + txtcusdutyAmt.Text + "','" + txtothtaxAmt.Text + "','" + txtAmtPayble.Text + "','NEW','NEW','" + Touch_user + "','" + strTime + "','"+chkcnb .Checked .ToString ()+"')");
                            chkCode = obj.exec(StrQuery);
                            if (chkCode == -2146232060)
                            {
                                PermitNO();
                                goto Save;
                            }
                            string TouchDate = DateTime.Now.ToString("yyyy/MM/dd");
                            //Count Permit



                            string PerCount = ("INSERT INTO [dbo].[PermitCount] ([PermitId],[MessageType],[AccountId],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Session["AccountId"].ToString() + "','" + Touch_user + "','" + TouchDate + "')");
                            obj.exec(PerCount);
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
                                    string StrQuery1 = ("INSERT INTO [dbo].[InnonContainerDtl] ([PermitId],[RowNo],[ContainerNo],[Size],[Weight],[SealNo],[MessageType],[TouchUser],[TouchTime]) VALUES ('" + txt_code.Text + "','" + i + "','" + ContainerNo + "','" + ContainerSize + "','" + ContainerWeight + "','" + Containerseal + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "')");
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
                                    string StrQuery1 = ("INSERT INTO [dbo].[InNonCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + a + "','AEO','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
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

                                if (ProcessingCode1 != "" )
                                {
                                    string StrQuery1 = ("INSERT INTO [dbo].[InNonCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + b + "','CWC','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                                    obj.exec(StrQuery1);
                                    obj.closecon();
                                }
                                b++;
                            }

                            int h = 1;
                            foreach (GridViewRow g1 in SchemeGrid.Rows)
                            {
                                string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;
                                string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                                string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                                if (ProcessingCode1 != "")
                                {
                                    string StrQuery1 = ("INSERT INTO [dbo].[InNonCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + h + "','SCHEME','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                                    obj.exec(StrQuery1);
                                    obj.closecon();
                                }
                                h++;
                            }

                            int o = 1;
                            foreach (GridViewRow g1 in StsGrid.Rows)
                            {
                                string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;
                                string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                                string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                                if (ProcessingCode1 != "")
                                {
                                    string StrQuery1 = ("INSERT INTO [dbo].[InNonCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + o + "','STS','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                                    obj.exec(StrQuery1);
                                    obj.closecon();
                                }
                                o++;
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

                            int l = 1;
                            foreach (GridViewRow g1 in IcGrid.Rows)
                            {
                                string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;
                                string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                                string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                                if (ProcessingCode1 != "")
                                {
                                    string StrQuery1 = ("INSERT INTO [dbo].[InNonCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + l + "','IC','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                                    obj.exec(StrQuery1);
                                    obj.closecon();
                                }
                                l++;
                            }


                            Response.Redirect("InNONpaymentList.aspx");

                        }
                        else
                        {
                            lblsameerror.Text = "The Permit Code '" + txt_code.Text + "' Already Exist..";
                            lblsameerror.Focus();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Permit Code '" + txt_code.Text + "' Already Exist..');", true);
                            //  Response.Write("The Importer Code Already Exist..");
                        }
                        InvoiceClr();
                        Itemclear();
                    }



                }
                else
                {
                    lblerror.Text = "INVOICE AMOUNT AND ITEM AMOUNT NOT SAME";
                    lblerror.Focus();
                }
            }

        }
       
        protected void AddInvoiceGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = AddInvoiceGrid.DataKeys[e.RowIndex].Value.ToString();

            string strDelete = "delete from InNonInvoiceDtl where Id='" + id + "' ";
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
                SqlCommand cmd = new SqlCommand("DELETE FROM InNonInvoiceDtl where ID=" + employeeId, con);
                result = cmd.ExecuteNonQuery();

                string var = "DECLARE @SRNO bigint=0;" + Environment.NewLine;
                var = var + " UPDATE InNonInvoiceDtl SET @SRNO =SNo= @SRNO + 1 where PermitId='" + txt_code.Text + "'";

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
            BtnAEO.Focus();

        }

        protected void chkcwc_CheckedChanged(object sender, EventArgs e)
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
            BtnCWC.Focus();
        }
        protected void AEOGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // AddNewRowToGridc();
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                if (dt.Rows.Count > 1)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["CurrentTable"] = dt;
                    AEOGrid.DataSource = dt;
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

            if (DrpDecType.SelectedValue != "")
            {
                //testdiv.Visible = false;
                ConsigneeCountry.BackColor = System.Drawing.Color.White;
                OutwardCRUEI.BackColor = System.Drawing.Color.White;
                OutwardName.BackColor = System.Drawing.Color.White;
                startdate.Visible = false;
                lodprtdiv.Visible = true;
                if (DrpDecType.SelectedItem.ToString() == "BKT : BLANKET [INCLUDING BLANKET GST RELIEF (& DUTY EXEMPTION)]")
                {
                    load.Visible = false;
                    inhawbl.Visible = false;
                    outhbl.Visible = false; 
                    divstrge.Visible = true;
                    cargo.Visible = true;
                    Inward.Visible = false;
                    Outward.Visible = false;
                    lodprtdiv.Visible = false;
                    TxtLoadShort.Text = "";
                    TxtLoad.Text = "";
                    divstrge.Visible = true;
                    OutwardName.Enabled = true;
                    OutwardCRUEI.Enabled = true;
                    //OutwardCRUEI.BackColor = Color.ActiveCaption;
                    EXPORTER.Visible = true;
                    TxtExpName.Enabled = true;
                    //TxtExpName.BackColor = Color.ActiveCaption;
                    InwardCRUEI.BackColor = Color.White;
                    InwardName.BackColor = Color.White;
                    TxtExpCRUEI.BackColor = Color.White;
                    TxtExpName.BackColor = Color.White;
                    TxtExpCRUEI.Enabled = true;
                    //Party Visible
                    ClaimantParty.Visible = true;
                    ExpParty.Visible = true;
                    OutParty.Visible = false;
                    ConsigneeParty.Visible = true;

                    EXhDiv.Visible = true;                    
                    load.Visible = true;
                    inhawbl.Visible = false;
                }
                else if (DrpDecType.SelectedItem.ToString() == "TCE : TEMPORARY IMPORT FOR EXHIBITION/AUCTIONS WITHOUT SALES" || DrpDecType.SelectedItem.ToString() == "TCO : TEMPORARY IMPORT FOR OTHER PURPOSES" || DrpDecType.SelectedItem.ToString() == "TCR : TEMPORARY IMPORT FOR REPAIRS" || DrpDecType.SelectedItem.ToString() == "TCS : TEMPORARY IMPORT FOR EXHIBITION/AUCTIONS WITH SALES")
                {
                    EXhDiv.Visible = true;
                    startdate.Visible = true;
                }
                else if (DrpDecType.SelectedItem.ToString() == "REX : FOR RE-EXPORT")
                {
                    load.Visible = true;
                    inhawbl.Visible = true;
                    outhbl.Visible = true;
                    divstrge.Visible = true;
                    cargo.Visible = true;
                    Inward.Visible = true;
                    Outward.Visible = true;
                    OutwardName.Enabled = true;
                    divstrge.Visible = true;
                    //OutwardName.BackColor = Color.ActiveCaption;
                    OutwardCRUEI.Enabled = true;
                    //OutwardCRUEI.BackColor = Color.ActiveCaption;
                    EXPORTER.Visible = true;
                    TxtExpName.Enabled = true;
                    //TxtExpName.BackColor = Color.ActiveCaption;
                    TxtExpCRUEI.Enabled = true;
                    //testdiv.Visible = false;
                    //TxtExpCRUEI.BackColor = Color.ActiveCaption;
                    EXhDiv.Visible = false;
                    startdate.Visible = false;
                    BlankStart.Visible = false;
                    //Party Visible
                    ClaimantParty.Visible = false;
                    ExpParty.Visible = true;
                    OutParty.Visible = true;
                    ConsigneeParty.Visible = true;
                  //  OutwardDiv.Visible = true;

                    ConsigneeCountry.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    OutwardCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    OutwardName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);                  
                }
                else if (DrpDecType.SelectedItem.ToString() == "SFZ : STORAGE IN FTZ")
                {
                    EXhDiv.Visible = false;
                    startdate.Visible = false;
                    load.Visible = true;
                    inhawbl.Visible = true;
                    outhbl.Visible = true;
                    divstrge.Visible = true;
                    cargo.Visible = true;
                    Inward.Visible = true;
                    Outward.Visible = true;
                    divstrge.Visible = true;
                    OutwardName.Enabled = true;
                    //OutwardName.BackColor = Color.ActiveCaption;
                    OutwardCRUEI.Enabled = true;
                    //OutwardCRUEI.BackColor = Color.ActiveCaption;
                    EXPORTER.Visible = true;
                    TxtExpName.Enabled = true;
                    //TxtExpName.BackColor = Color.ActiveCaption;
                    TxtExpCRUEI.Enabled = true;
                    //testdiv.Visible = false;
                    //TxtExpCRUEI.BackColor = Color.ActiveCaption;
                    //Party Visible

                    BlankStart.Visible = false ;
                    ClaimantParty.Visible = false;
                    ExpParty.Visible = false;
                    OutParty.Visible = true;
                    ConsigneeParty.Visible = true;                  
                }
                else
                {
                    // EXhDiv.Visible = false;
                    load.Visible = true;
                    inhawbl.Visible = true;
                    outhbl.Visible = true;
                    divstrge.Visible = true;
                    cargo.Visible = true;
                    Inward.Visible = true;
                    Outward.Visible = false;
                    Outward1.Visible = false;
                    divstrge.Visible = true;
                    OutwardName.Enabled = false;
                    OutwardName.BackColor = Color.White;
                    OutwardCRUEI.Enabled = false;
                    OutwardCRUEI.BackColor = Color.White;
                    EXPORTER.Visible = false;
                    TxtExpName.Enabled = false;
                    TxtExpName.BackColor = Color.White;
                    TxtExpCRUEI.Enabled = false;
                    TxtExpCRUEI.BackColor = Color.White;
                    //Party Visible
                    ClaimantParty.Visible = false;
                    ExpParty.Visible = true;
                    OutParty.Visible = false;
                    ConsigneeParty.Visible = true;
                    BlankStart.Visible = false;                  
                    if (DrpDecType.SelectedItem.ToString() == "GTR : GST RELIEF (& DUTY EXEMPTION)")
                    {
                        EXhDiv.Visible = false;
                        startdate.Visible = false;
                        load.Visible = true;
                        inhawbl.Visible = true;
                        outhbl.Visible = true;
                        divstrge.Visible = true;
                        //Party Visible
                        ClaimantParty.Visible = true;
                        ExpParty.Visible = true;
                        OutParty.Visible = false;
                        ConsigneeParty.Visible = true;
                        BlankStart.Visible = false;                        
                    }
                    else if (DrpDecType.SelectedItem.ToString() == "TCR : TEMPORARY IMPORT FOR REPAIRS")
                    {
                        EXhDiv.Visible = true;
                        startdate.Visible = true;
                        load.Visible = true;
                        inhawbl.Visible = true;
                        outhbl.Visible = true;
                        divstrge.Visible = true;                        
                    }
                    else if (DrpDecType.SelectedItem.ToString() == "SHO : SHUT-OUT")
                    {
                        load.Visible = true;
                        inhawbl.Visible = true;
                        outhbl.Visible = false;
                        divstrge.Visible = false;
                        EXhDiv.Visible = false;
                    }

                    else
                    {
                        EXhDiv.Visible = false;
                        startdate.Visible = false;
                        load.Visible = true;
                        inhawbl.Visible = true;
                        ExpParty.Visible = false;                        
                    }


                }
            }
            upinnonparty.Update();
            upinnoncargo.Update();
            innonpayment.Update();
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
            string qry11 = "select TICurrency from [InNonInvoiceDtl] where MessageType='INPDEC' AND PermitId='" + txt_code.Text + "' and InvoiceNo='" + DrpInvoiceNo.SelectedItem.ToString() + "'  order by TICurrency";
            obj.dr = obj.ret_dr(qry11);
            while (obj.dr.Read())
            {
                Code = obj.dr[0].ToString();
                if (Code != "--Select--")
                {
                    DRPCurrency.ClearSelection();
                    DRPCurrency.Items.FindByText(Code).Selected = true;                    
                    string qry111 = "select CurrencyRate from dbo.Currency where Currency='" + Code + "'";
                    obj.dr = obj.ret_dr(qry111);
                    while (obj.dr.Read())
                    {
                        Code1 = obj.dr[0].ToString();
                        TxtExchangeRate.Text = Code1;
                       // TxtOptionalExchageRate.Text = Code1;
                    }
                }
            }
            obj = new InnonPaymentClass();
            obj.dr = obj.ret_dr("Select TermType from [InNonInvoiceDtl] where MessageType='INPDEC' AND PermitId='" + txt_code.Text + "' and InvoiceNo='" + DrpInvoiceNo.SelectedItem.ToString() + "'");
            while (obj.dr.Read())
            {
                txttermtyp.Text = obj.dr["TermType"].ToString();
            }
            TxtTotalLineAmount.Focus();
        }

        protected void DRPCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Code = "";
            string qry11 = "select TICurrency from [InNonInvoiceDtl] where MessageType='INPDEC' AND PermitId='" + txt_code.Text + "' and InvoiceNo='" + DrpInvoiceNo.SelectedItem.ToString() + "'  order by TICurrency";
            obj.dr = obj.ret_dr(qry11);
            while (obj.dr.Read())
            {
                Code = obj.dr[0].ToString();
                if (Code != "--Select--")
                {
                    DRPCurrency.SelectedValue = Code;
                }
            }
            TxtTotalLineAmount.Focus();
        }

        protected void TxtTotalLineAmount_TextChanged(object sender, EventArgs e)
        {


            string InvoiceCharge, OtherChnage, Insurancecharge, FrightCharge = "";
            string qry11 = "select TISAmount,OTCSAmount,FCSAmount,ICSAmount from [InNonInvoiceDtl] where MessageType='INPDEC' AND PermitId='" + txt_code.Text + "' and InvoiceNo='" + DrpInvoiceNo.SelectedItem.ToString() + "'  ";
            obj.dr = obj.ret_dr(qry11);
            while (obj.dr.Read())
            {
                InvoiceCharge = obj.dr[0].ToString();
                OtherChnage = obj.dr[1].ToString();
                Insurancecharge = obj.dr[3].ToString();
                FrightCharge = obj.dr[2].ToString();




                if (TxtTotalLineAmount.Text != "")
                {                    
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
            }
            else
            {
                TxtTotalLineAmount.Text = "0.00";
            }
            //Sum of Item Amount

            string SumofItemAmount = "";
            string qry11s2Q = "select SUM(TotalLineAmount) as  TotalLineAmount  from InNonItemDtl where PermitId='" + txt_code.Text + "' and MessageType='INPDEC'";
            obj.dr = obj.ret_dr(qry11s2Q);
            while (obj.dr.Read())
            {
                SumofItemAmount = obj.dr[0].ToString();
                txtitmAmt.Text = SumofItemAmount;
            }
            string TotalGSTAmount = "";
            string qry11s2 = "select SUM(GSTAmount) as  GSTAmount  from InNonItemDtl where PermitId='" + txt_code.Text + "' and MessageType='INPDEC'";
            obj.dr = obj.ret_dr(qry11s2);
            while (obj.dr.Read())
            {
                TotalGSTAmount = obj.dr[0].ToString();
                txttotgstAmt.Text = TotalGSTAmount;
                txtAmtPayble.Text = "0.00";
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
            //sumex = Math.Round((cif) * (exrate/100), 2);            
            itemgst = Convert.ToDouble(TxtItemSumGST.Text);
            optional = Convert.ToDouble(TxtOptionalSumExRate.Text);

            if (TxtHSCodeItem.Text.Trim().StartsWith("87"))
            {
                TxtSumExciseDuty.Text = sumex.ToString();
            }
            summerygst = (sumex * 0.09) + (cif * 0.09) + (optional * 0.09);

            TxtItemSumGST.Text = Math.Round((summerygst), 2).ToString();
            ChkPackInfo.Focus();
        }

        protected void TxtUnitPrice_TextChanged(object sender, EventArgs e)
        {
            if (TxtUnitPrice.Text != "")
            {

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

                TxtTotalLineCharges.Text = (Convert.ToDouble(lineamt) * T2 / 100).ToString();
                string linecharge = (Convert.ToDouble(lineamt) * T2 / 100).ToString();
                TxtCIFFOB.Text = ((Convert.ToDouble(lineamt) * T2 + Convert.ToDouble(linecharge)).ToString());
                string GSTG = TxtCIFFOB.Text;
                TxtItemSumGST.Text = ((Convert.ToDouble(GSTG) * 9 / 100).ToString());
            }
            else
            {
                TxtUnitPrice.Text = "0.00";
            }
            //Sum of Item Amount

            string SumofItemAmount = "";
            string qry11s2Q = "select SUM(TotalLineAmount) as  TotalLineAmount  from InNonItemDtl where PermitId='" + txt_code.Text + "' and MessageType='INPDEC'";
            obj.dr = obj.ret_dr(qry11s2Q);
            while (obj.dr.Read())
            {
                SumofItemAmount = obj.dr[0].ToString();
                txtitmAmt.Text = SumofItemAmount;
            }
            //TotalGSTAmount
            string TotalGSTAmount = "";
            string qry11s2 = "select SUM(GSTAmount) as  GSTAmount  from InNonItemDtl where PermitId='" + txt_code.Text + "' and MessageType='INPDEC'";
            obj.dr = obj.ret_dr(qry11s2);
            while (obj.dr.Read())
            {
                TotalGSTAmount = obj.dr[0].ToString();
                txttotgstAmt.Text = TotalGSTAmount;
                txtAmtPayble.Text = "0.00";
            }
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
        }

        protected void DrpPreferentialCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DrpPreferentialCode.SelectedItem.ToString() == "PRF : if goods are imported under preferential duty rates")
            {
              //  lblCustomsDuty.Text = "Cusbtnnextcpc_Clicktoms Duty - EXEMPTED";
                lblCustomsDuty.Text = "Customs Duty - EXEMPTED";
                TxtCustomsDutyRate.Text = "0";
                TxtCustomsDutyUOM.Text = "--Select--";
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
            upinnonitem.Update();
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
        protected void AddItemGrid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            AddItemGrid.EditIndex = e.NewEditIndex;
            BindItemMaster();
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
                SqlCommand cmd = new SqlCommand("DELETE FROM InNonItemDtl where PermitId='" + txt_code.Text + "' and ItemNo=" + ID, con);
                result = cmd.ExecuteNonQuery();

                cmd = new SqlCommand("DELETE FROM INNONCASCDtl where PermitId='" + txt_code.Text + "' and ItemNo='"+ID+"'", con);
                cmd.ExecuteNonQuery();

                

                string var1 = "update T";
                var1 = var1 + " set ItemNo = rn";
                var1 = var1 + " from (";
                var1 = var1 + " select ItemNo,";
                var1 = var1 + " row_number() over(order by ItemNo) as rn";
                var1 = var1 + " from InNonItemDtl where PermitId='" + txt_code.Text + "'";
                var1 = var1 + " ) T";
                //string var = "DECLARE @SRNO bigint=0;" + Environment.NewLine;
                //var = var + " UPDATE InNonItemDtl SET @SRNO =ItemNo= @SRNO + 1 where PermitId='" + txt_code.Text + "'";
                cmd = new SqlCommand(var1, con);
                cmd.ExecuteNonQuery();

                //for (int k = 0; k < 5; k++)
                //{
                //    string type = "Casc";
                //    if (k == 0)
                //    {
                //        type = type + "1";
                //    }
                //    if (k == 1)
                //    {
                //        type = type + "2";
                //    }
                //    if (k == 2)
                //    {
                //        type = type + "3";
                //    }
                //    if (k == 3)
                //    {
                //        type = type + "4";
                //    }
                //    if (k == 3)
                //    {
                //        type = type + "5";
                //    }

                //var1 = "update T";
                //var1 = var1 + " set ItemNo = rn";
                //var1 = var1 + " from (";
                //var1 = var1 + " select ItemNo,";
                //var1 = var1 + " row_number() over(order by ItemNo) as rn";
                //var1 = var1 + " from INNONCASCDtl where PermitId='" + txt_code.Text + "'";
                //var1 = var1 + " ) T";

                ////var = "DECLARE @SRNO bigint=0;" + Environment.NewLine;
                ////var = var + " UPDATE CASCDtl SET @SRNO =ItemNo= @SRNO + 1 where PermitId='" + txt_code.Text + "'";
                //cmd = new SqlCommand(var1, con);
                //cmd.ExecuteNonQuery();
                int itemno = 1;
                DataSet sds = new DataSet();
                sds = obj.ds1("select Distinct ItemNo from INNONCASCDtl where PermitId='" + txt_code.Text + "' Order by ItemNo");
                for (int k = 0; k < sds.Tables[0].Rows.Count; k++)
                {                    
                    DataSet asd = new DataSet();
                    asd = obj.ds1("select Count(*) from INNONCASCDtl where PermitId='" + txt_code.Text + "' and ItemNo='" + sds.Tables[0].Rows[k]["ItemNo"].ToString() + "'");
                    if (Convert.ToDecimal(asd.Tables[0].Rows[0][0].ToString()) > 0)
                    {
                        cmd = new SqlCommand("UPDATE INNONCASCDtl SET  ItemNo='" + itemno + "' where PermitId='" + txt_code.Text + "' and ItemNo='" + sds.Tables[0].Rows[k]["ItemNo"].ToString() + "'", con);
                        cmd.ExecuteNonQuery();
                        itemno = itemno + 1;
                    }
                }
                    //}
                    con.Close();
                ItemNO();
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
                using (SqlCommand cmd = new SqlCommand("SELECT Top 50 * FROM InNonItemDtl where PermitId='" + txt_code.Text + "' and MessageType='INPDEC' order by ItemNo"))
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

            string str3 = "SELECT * FROM InNonInvoiceDtl where InvoiceNo Like '%" + AddItemSearch.Text + "%' order by Id desc";
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
            string MaxItemCount = "";
            string maxq = "SELECT COUNT(PermitId) AS MaxItem FROM InNonItemDtl  where  MessageType='INPDEC' AND PermitId='" + txt_code.Text + "'";
            obj.dr = obj.ret_dr(maxq);
            while (obj.dr.Read())
            {
                MaxItemCount = obj.dr["MaxItem"].ToString();
            }

            if (MaxItemCount != "50")
            {

                string itemcnt = "";
                int count = 1;

                lblitemalert.Visible = false;
                string Code = "";
                string qry1111 = "SELECT * FROM InNonItemDtl where  MessageType='INPDEC' AND PermitId='" + txt_code.Text + "' and ItemNo='" + TxtSerialNo.Text + "'";
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
                    string strTime = System.DateTime.Now.ToString("yyyy/MM/dd");

                    DateTime orgindate = Convert.ToDateTime(null);
                    if (txtorgindate.Text == "")
                    {
                        var date = DateTime.Now.ToString("dd/MM/yyyy");
                        var manDate = DateTime.ParseExact(date, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        orgindate = Convert.ToDateTime(manDate);
                    }
                    else
                    {
                        var InvoiceDate1 = DateTime.ParseExact(txtorgindate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        orgindate = Convert.ToDateTime(InvoiceDate1);
                    }
                    string StrQuery1 = ("INSERT INTO [dbo].[InNonItemDtl] ([ItemNo],[PermitId],[MessageType],[HSCode],[Description],[DGIndicator],[Contry],[Brand],[Model],[Vehicletype],[Enginecapacity],[Engineuom],[Orginregdate],[InHAWBOBL],[OutHAWBOBL],[DutiableQty],[DutiableUOM],[TotalDutiableQty],[TotalDutiableUOM],[InvoiceQuantity],[HSQty],[HSUOM],[AlcoholPer],[InvoiceNo],[UnitPrice],[UnitPriceCurrency],[ExchangeRate],[SumExchangeRate],[TotalLineAmount],[InvoiceCharges],[CIFFOB],[OPQty],[OPUOM],[IPQty],[IPUOM],[InPqty],[InPUOM],[ImPQty],[ImPUOM],[PreferentialCode],[GSTRate],[GSTUOM],[GSTAmount],[ExciseDutyRate],[ExciseDutyUOM],[ExciseDutyAmount],[CustomsDutyRate],[CustomsDutyUOM],[CustomsDutyAmount],[OtherTaxRate],[OtherTaxUOM],[OtherTaxAmount],[CurrentLot],[PreviousLot],LSPValue,[Making],[ShippingMarks1],[ShippingMarks2],[ShippingMarks3],[ShippingMarks4],[OptionalChrgeUOM],[Optioncahrge],[OptionalSumtotal],[OptionalSumExchage],[TouchUser],[TouchTime]) VALUES ('" + TxtSerialNo.Text + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + TxtHSCodeItem.Text + "','" + TxtDescription.Text + "','" + ChkBGIndicator.Checked.ToString() + "','" + TxtCountryItem.Text + "','" + TxtBrand.Text + "','" + TxtModel.Text + "','" + DrpVehicleType.SelectedItem.Text + "','" + txtengine.Text + "','" + DrpVehicleCapacity.SelectedItem.Text + "','" + Convert.ToDateTime(orgindate).ToString("yyyy/MM/dd") + "','" + TxtHAWB.SelectedItem.ToString() + "','" + txtOutHAWB1.SelectedItem.ToString() + "','" + Convert.ToDecimal( TxtTotalDutiableQuantity.Text).ToString()   + "','" + TDQUOM.SelectedItem.ToString() + "','" + Convert.ToDecimal(txttotDutiableQty.Text ).ToString()+ "','" + ddptotDutiableQty.SelectedItem.ToString() + "','" + Convert.ToDecimal(TxtInvQty.Text).ToString() + "','" + Convert.ToDecimal(TxtHSQuantity.Text).ToString() + "','" + HSQTYUOM.SelectedItem.Text + "','" + Convert.ToDecimal(txtAlcoholPer.Text).ToString() + "','" + DrpInvoiceNo.SelectedItem.Text + "','" + Convert.ToDecimal(TxtUnitPrice.Text).ToString() + "','" + DRPCurrency.SelectedItem.Text + "','" + Convert.ToDecimal(TxtExchangeRate.Text).ToString() + "','" + Convert.ToDecimal(TxtSumExRate.Text).ToString() + "','" + Convert.ToDecimal(TxtTotalLineAmount.Text).ToString() + "','" + Convert.ToDecimal(TxtTotalLineCharges.Text).ToString() + "','" + Convert.ToDecimal(TxtCIFFOB.Text).ToString() + "','" + Convert.ToDecimal(TxtOPQty.Text).ToString() + "','" + DRPOPQUOM.SelectedItem.Text + "','" + Convert.ToDecimal(TxtIPQty.Text).ToString() + "','" + DRPIPQUOM.SelectedItem.Text + "','" + Convert.ToDecimal(TxtINPQty.Text).ToString() + "','" + DRPINNPQUOM.SelectedItem.Text + "','" + Convert.ToDecimal(TxtIMPQty.Text).ToString() + "','" + DRPIMPQUOM.SelectedItem.Text + "','" + DrpPreferentialCode.SelectedItem.Text + "','" + Convert.ToDecimal(ItemGSTRate.Text).ToString() + "','" + ItemGSTUOM.Text + "','" + Convert.ToDecimal(TxtItemSumGST.Text).ToString() + "','" + Convert.ToDecimal(TxtExciseDutyRate.Text).ToString() + "','" + TxtExciseDutyUOM.Text + "','" + Convert.ToDecimal(TxtSumExciseDuty.Text).ToString() + "','" + Convert.ToDecimal(TxtCustomsDutyRate.Text).ToString() + "','" + TxtCustomsDutyUOM.Text + "','" + Convert.ToDecimal(TxtSumCustomsDuty.Text ).ToString()+ "','" + Convert.ToDecimal(TxtOtherTaxRate.Text ).ToString()+ "','" + DrpOtherUOM.SelectedItem.Text + "','" + Convert.ToDecimal(TxtSumOtherTaxRate.Text ).ToString()+ "','" + TxtCurrentLot.Text + "','" + TxtPreviousLot.Text + "','" + Convert.ToDecimal(txtlsp.Text).ToString() + "','" + DrpMaking.SelectedItem.Text + "','" + txtShippingMarks1.Text + "','" + txtShippingMarks2.Text + "','" + txtShippingMarks3.Text + "','" + txtShippingMarks4.Text + "','" + DrpOptionalUom.SelectedItem.Text + "','" + Convert.ToDecimal(TxtOptionalPrice.Text).ToString() + "','" + Convert.ToDecimal(TxtOptionalExchageRate.Text).ToString() + "','" + Convert.ToDecimal(TxtOptionalSumExRate.Text).ToString() + "','" + Touch_user + "','" + strTime + "')");
                    obj.exec(StrQuery1);
                    obj.closecon();


                    //ProductCode 1
                    if (string.IsNullOrWhiteSpace(TxtProQty1.Text))
                    {
                        TxtProQty1.Text = "0.00";
                    }
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
                                string P1 = ("INSERT INTO [dbo].[INNONCASCDtl] (ItemNo,[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode1.Text + "','" + TxtProQty1.Text + "','" + DrpP1.SelectedItem.Text + "','" + p1 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc1')");
                                obj.exec(P1);
                                obj.closecon();
                            }
                            else
                            {
                                if (!string.IsNullOrWhiteSpace(ProcessingCode1))
                                {
                                    string P1 = ("INSERT INTO [dbo].[INNONCASCDtl] (ItemNo,[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode1.Text + "','" + TxtProQty1.Text + "','" + DrpP1.SelectedItem.Text + "','" + p1 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc1')");
                                    obj.exec(P1);
                                    obj.closecon();
                                }
                            }
                        }
                        p1++;
                    }


                    //ProductCode 2
                    if (string.IsNullOrWhiteSpace(TxtProQty2.Text))
                    {
                        TxtProQty2.Text = "0.00";
                    }
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
                                string P1 = ("INSERT INTO [dbo].[INNONCASCDtl] (ItemNo,[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode2.Text + "','" + TxtProQty2.Text + "','" + DrpP2.SelectedItem.Text + "','" + p2 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc2')");
                                obj.exec(P1);
                                obj.closecon();
                            }
                            else
                            {
                                if (!string.IsNullOrWhiteSpace(ProcessingCode1))
                                {
                                    string P1 = ("INSERT INTO [dbo].[INNONCASCDtl] (ItemNo,[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode2.Text + "','" + TxtProQty2.Text + "','" + DrpP2.SelectedItem.Text + "','" + p2 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc2')");
                                    obj.exec(P1);
                                    obj.closecon();
                                }
                            }
                        }
                        p2++;
                    }


                    //ProductCode 3
                    if (string.IsNullOrWhiteSpace(TxtProQty3.Text))
                    {
                        TxtProQty3.Text = "0.00";
                    }
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
                                string P1 = ("INSERT INTO [dbo].[INNONCASCDtl] (ItemNo,[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode3.Text + "','" + TxtProQty3.Text + "','" + DrpP3.SelectedItem.Text + "','" + p3 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc3')");
                                obj.exec(P1);
                                obj.closecon();
                            }
                            else
                            {
                                if (!string.IsNullOrWhiteSpace(ProcessingCode1))
                                {
                                    string P1 = ("INSERT INTO [dbo].[INNONCASCDtl] (ItemNo,[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode3.Text + "','" + TxtProQty3.Text + "','" + DrpP3.SelectedItem.Text + "','" + p3 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc3')");
                                    obj.exec(P1);
                                    obj.closecon();
                                }
                            }
                        }
                        p3++;
                    }

                    //ProductCode 4
                    if (string.IsNullOrWhiteSpace(TxtProQty4.Text))
                    {
                        TxtProQty4.Text = "0.00";
                    }
                    int p4 = 1;
                    foreach (GridViewRow g4 in ProductCode4Grid1.Rows)
                    {

                        string ProcessingCode1 = (g4.FindControl("TextBox1") as TextBox).Text;
                        string ProcessingCode2 = (g4.FindControl("TextBox2") as TextBox).Text;
                        string ProcessingCode3 = (g4.FindControl("TextBox3") as TextBox).Text;

                        if (TxtProductCode4.Text != "")
                        {
                            if (p4 == 1)
                            {
                                string P1 = ("INSERT INTO [dbo].[INNONCASCDtl] (ItemNo,[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode4.Text + "','" + TxtProQty4.Text + "','" + DrpP4.SelectedItem.Text + "','" + p4 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc4')");
                                obj.exec(P1);
                                obj.closecon();
                            }
                            else
                            {
                                if (!string.IsNullOrWhiteSpace(ProcessingCode1))
                                {
                                    string P1 = ("INSERT INTO [dbo].[INNONCASCDtl] (ItemNo,[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode4.Text + "','" + TxtProQty4.Text + "','" + DrpP4.SelectedItem.Text + "','" + p4 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc4')");
                                    obj.exec(P1);
                                    obj.closecon();
                                }
                            }
                        }
                        p4++;
                    }


                    //ProductCode 5
                    if (string.IsNullOrWhiteSpace(TxtProQty5.Text))
                    {
                        TxtProQty5.Text = "0.00";
                    }
                    int p5 = 1;
                    foreach (GridViewRow g5 in ProductCode5Grid1.Rows)
                    {

                        string ProcessingCode1 = (g5.FindControl("TextBox1") as TextBox).Text;
                        string ProcessingCode2 = (g5.FindControl("TextBox2") as TextBox).Text;
                        string ProcessingCode3 = (g5.FindControl("TextBox3") as TextBox).Text;

                        if (TxtProductCode5.Text != "")
                        {
                            if (p5 == 1)
                            {
                                string P1 = ("INSERT INTO [dbo].[INNONCASCDtl] (ItemNo,[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode5.Text + "','" + TxtProQty5.Text + "','" + DrpP5.SelectedItem.Text + "','" + p5 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc5')");
                                obj.exec(P1);
                                obj.closecon();
                            }
                            else
                            {
                                if (!string.IsNullOrWhiteSpace(ProcessingCode1))
                                {
                                    string P1 = ("INSERT INTO [dbo].[INNONCASCDtl] (ItemNo,[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode5.Text + "','" + TxtProQty5.Text + "','" + DrpP5.SelectedItem.Text + "','" + p5 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc5')");
                                    obj.exec(P1);
                                    obj.closecon();
                                }
                            }
                        }
                        p5++;
                    }
                    BindItemMaster();
                    con.Open();
                    SqlCommand command1113 = new SqlCommand("SELECT Count(ItemNo) from [InNonItemDtl] where MessageType='INPDEC' and PermitId='" + txt_code.Text + "' ");
                    command1113.Connection = con;
                    int max_po_no3 = Convert.ToInt32(command1113.ExecuteScalar());
                    int m_po_no3 = 0;
                    m_po_no3 = max_po_no3 + 1;
                    string code3 = " " + String.Format("{0:000}", m_po_no3);
                    con.Close();
                    TxtSerialNo.Text = code3;

                    SummaryCalculate();
                    ItemAddGrid.Visible = true;
                    ItemDiv.Visible = true;
                    BtnAddNEWItem.Visible = false;
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
                    //string itemcnt1 = "SELECT COUNT(*) as count FROM InNonItemDtl where MessageType='INPDEC' AND PermitId='" + txt_code.Text + "'";
                    //obj.dr = obj.ret_dr(itemcnt1);
                    //while (obj.dr.Read())
                    //{
                    //    itemcnt = obj.dr["count"].ToString();
                    //    count = Convert.ToInt32(itemcnt);
                    //}
                    //if (count < 50)
                    //{
                    string Touch_user = Session["UserId"].ToString();
                    string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    //   var InvoiceDate = DateTime.Parse(this.txtinvDate.Value, new CultureInfo("en-US", true));
                    DateTime orgindate = Convert.ToDateTime(null);
                    if (txtorgindate.Text == "")
                    {
                        var date = DateTime.Now.ToString("dd/MM/yyyy");
                        var manDate = DateTime.ParseExact(date, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        orgindate = Convert.ToDateTime(manDate);
                    }
                    else
                    {
                        var InvoiceDate1 = DateTime.ParseExact(txtorgindate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        orgindate = Convert.ToDateTime(InvoiceDate1);
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



                    string StrQuery1 = ("update [dbo].[InNonItemDtl]  set [HSCode]='" + TxtHSCodeItem.Text + "',[Description]='" + TxtDescription.Text + "',[DGIndicator]='" + ChkBGIndicator.Checked.ToString() + "',[Contry]= '" + TxtCountryItem.Text + "',[Brand]='" + TxtBrand.Text + "',[Model]='" + TxtModel.Text + "',[Vehicletype]='" + DrpVehicleType.SelectedItem.Text + "',[Enginecapacity]='" + txtengine.Text + "',[Engineuom]='" + DrpVehicleCapacity.SelectedItem.Text + "',[Orginregdate]='" + Convert.ToDateTime(orgindate).ToString("yyyy/MM/dd") + "',[InHAWBOBL]='" + TxtHAWB.SelectedItem.ToString() + "',[OutHAWBOBL]='" + txtOutHAWB1.SelectedItem.ToString() + "',[DutiableQty]='" + Convert.ToDecimal(TxtTotalDutiableQuantity.Text).ToString() + "',[DutiableUOM]='" + TDQUOM.SelectedItem.Text + "',[TotalDutiableQty]='" + Convert.ToDecimal(txttotDutiableQty.Text).ToString() + "',[TotalDutiableUOM]='" + ddptotDutiableQty.SelectedItem.Text + "',[InvoiceQuantity]='" + Convert.ToDecimal(TxtInvQty.Text).ToString() + "',[HSQty]='" + Convert.ToDecimal(TxtHSQuantity.Text).ToString() + "', [HSUOM]='" + HSQTYUOM.SelectedItem.Text + "',[AlcoholPer]='" + Convert.ToDecimal(txtAlcoholPer.Text).ToString() + "',[InvoiceNo]='" + DrpInvoiceNo.SelectedItem.Text.Replace("'","''") + "',[ChkUnitPrice]='" + ChkUnitPrice.Checked + "',[UnitPrice]='" + Convert.ToDecimal(TxtUnitPrice.Text).ToString() + "',[UnitPriceCurrency]='" + DRPCurrency.SelectedItem.Text + "',[ExchangeRate]='" + Convert.ToDecimal(TxtExchangeRate.Text).ToString() + "',[SumExchangeRate]='" + Convert.ToDecimal(TxtSumExRate.Text).ToString() + "',[TotalLineAmount]='" + Convert.ToDecimal(TxtTotalLineAmount.Text ).ToString()+ "',[InvoiceCharges]='" + Convert.ToDecimal(TxtTotalLineCharges.Text).ToString() + "',[CIFFOB]='" + Convert.ToDecimal(TxtCIFFOB.Text).ToString() + "',[OPQty]='" + Convert.ToDecimal(TxtOPQty.Text).ToString() + "',[OPUOM]='" + DRPOPQUOM.SelectedItem.Text + "',[IPQty]='" + Convert.ToDecimal(TxtIPQty.Text).ToString() + "',[IPUOM]='" + DRPIPQUOM.SelectedItem.Text + "',[InPqty]='" + Convert.ToDecimal(TxtINPQty.Text).ToString() + "',[InPUOM]='" + DRPINNPQUOM.SelectedItem.Text + "',[ImPQty]='" + Convert.ToDecimal(TxtIMPQty.Text).ToString() + "',[ImPUOM]='" + DRPIMPQUOM.SelectedItem.Text + "',[PreferentialCode]='" + DrpPreferentialCode.SelectedItem.Text + "',[GSTRate]='" + Convert.ToDecimal(ItemGSTRate.Text).ToString() + "',[GSTUOM]='" + ItemGSTUOM.Text + "',[GSTAmount]='" + Convert.ToDecimal(TxtItemSumGST.Text).ToString() + "',[ExciseDutyRate]='" + Convert.ToDecimal(TxtExciseDutyRate.Text).ToString() + "', [ExciseDutyUOM]='" + TxtExciseDutyUOM.Text + "',[ExciseDutyAmount]='" + Convert.ToDecimal(TxtSumExciseDuty.Text).ToString() + "',[CustomsDutyRate]='" + Convert.ToDecimal(TxtCustomsDutyRate.Text).ToString() + "',[CustomsDutyUOM]='" + TxtCustomsDutyUOM.Text + "',[CustomsDutyAmount]='" + Convert.ToDecimal(TxtSumCustomsDuty.Text).ToString() + "',[OtherTaxRate]='" + Convert.ToDecimal(TxtOtherTaxRate.Text ).ToString()+ "',[OtherTaxUOM]='" + DrpOtherUOM.SelectedItem.Text + "',[OtherTaxAmount]='" + Convert.ToDecimal(TxtSumOtherTaxRate.Text).ToString() + "',[CurrentLot]='" + TxtCurrentLot.Text + "',[PreviousLot]='" + TxtPreviousLot.Text + "',[Making]='" + DrpMaking.SelectedItem.Text + "',[ShippingMarks1]='" + txtShippingMarks1.Text + "',[ShippingMarks2]='" + txtShippingMarks2.Text + "',[ShippingMarks3]='" + txtShippingMarks3.Text + "',[ShippingMarks4]='" + txtShippingMarks4.Text + "',OptionalChrgeUOM='" + DrpOptionalUom.SelectedItem.Text + "',[Optioncahrge]='" + Convert.ToDecimal(TxtOptionalPrice.Text).ToString() + "',[OptionalSumtotal]='" + Convert.ToDecimal(TxtOptionalExchageRate.Text).ToString() + "',[OptionalSumExchage]='" + Convert.ToDecimal(TxtOptionalSumExRate.Text).ToString() + "',[TouchUser]='" + Touch_user + "',[TouchTime]='" + strTime + "' where  MessageType='INPDEC' AND PermitId='" + txt_code.Text + "' and ItemNo='" + TxtSerialNo.Text + "'");
                    obj.exec(StrQuery1);
                    obj.closecon();

                    string cpc = ("delete from INNONCASCDtl where PermitId='" + txt_code.Text + "' and CASCId='Casc1' and ItemNo='" + TxtSerialNo.Text + "'");
                    obj.exec(cpc);
                    obj.closecon();
                    if (string.IsNullOrWhiteSpace(TxtProQty1.Text))
                    {
                        TxtProQty1.Text = "0.00";
                    }
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
                                string P1 = ("INSERT INTO [dbo].[INNONCASCDtl] (ItemNo,[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode1.Text + "','" + TxtProQty1.Text + "','" + DrpP1.SelectedItem.Text + "','" + p1 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc1')");
                                obj.exec(P1);
                                obj.closecon();
                            }
                            else
                            {
                                if (!string.IsNullOrWhiteSpace(ProcessingCode1))
                                {
                                    string P1 = ("INSERT INTO [dbo].[INNONCASCDtl] (ItemNo,[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode1.Text + "','" + TxtProQty1.Text + "','" + DrpP1.SelectedItem.Text + "','" + p1 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc1')");
                                    obj.exec(P1);
                                    obj.closecon();
                                }
                            }
                        }
                        p1++;
                    }

                    string cpc2 = ("delete from INNONCASCDtl where PermitId='" + txt_code.Text + "' and CASCId='Casc2' and ItemNo='" + TxtSerialNo.Text + "'");
                    obj.exec(cpc2);
                    obj.closecon();
                    //ProductCode 2
                    if (string.IsNullOrWhiteSpace(TxtProQty2.Text))
                    {
                        TxtProQty2.Text = "0.00";
                    }
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
                                string P1 = ("INSERT INTO [dbo].[INNONCASCDtl] (ItemNo,[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode2.Text + "','" + TxtProQty2.Text + "','" + DrpP2.SelectedItem.Text + "','" + p2 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc2')");
                                obj.exec(P1);
                                obj.closecon();
                            }
                            else
                            {
                                if (!string.IsNullOrWhiteSpace(ProcessingCode1))
                                {
                                    string P1 = ("INSERT INTO [dbo].[INNONCASCDtl] (ItemNo,[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode2.Text + "','" + TxtProQty2.Text + "','" + DrpP2.SelectedItem.Text + "','" + p2 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc2')");
                                    obj.exec(P1);
                                    obj.closecon();
                                }
                            }
                        }
                        p2++;
                    }

                    string cpc3 = ("delete from INNONCASCDtl where PermitId='" + txt_code.Text + "' and CASCId='Casc3' and ItemNo='" + TxtSerialNo.Text + "'");
                    obj.exec(cpc3);
                    obj.closecon();
                    //ProductCode 3
                    if (string.IsNullOrWhiteSpace(TxtProQty3.Text))
                    {
                        TxtProQty3.Text = "0.00";
                    }
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
                                string P1 = ("INSERT INTO [dbo].[INNONCASCDtl] (ItemNo,[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode3.Text + "','" + TxtProQty3.Text + "','" + DrpP3.SelectedItem.Text + "','" + p3 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc3')");
                                obj.exec(P1);
                                obj.closecon();
                            }
                            else
                            {
                                if (!string.IsNullOrWhiteSpace(ProcessingCode1))
                                {
                                    string P1 = ("INSERT INTO [dbo].[INNONCASCDtl] (ItemNo,[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode3.Text + "','" + TxtProQty3.Text + "','" + DrpP3.SelectedItem.Text + "','" + p3 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc3')");
                                    obj.exec(P1);
                                    obj.closecon();
                                }
                            }
                        }
                        p3++;
                    }
                    string cpc4 = ("delete from INNONCASCDtl where PermitId='" + txt_code.Text + "' and CASCId='Casc4' and ItemNo='" + TxtSerialNo.Text + "'");
                    obj.exec(cpc4);
                    obj.closecon();
                    //ProductCode 4
                    if (string.IsNullOrWhiteSpace(TxtProQty4.Text))
                    {
                        TxtProQty4.Text = "0.00";
                    }
                    int p4 = 1;
                    foreach (GridViewRow g4 in ProductCode4Grid1.Rows)
                    {

                        string ProcessingCode1 = (g4.FindControl("TextBox1") as TextBox).Text;
                        string ProcessingCode2 = (g4.FindControl("TextBox2") as TextBox).Text;
                        string ProcessingCode3 = (g4.FindControl("TextBox3") as TextBox).Text;

                        if (TxtProductCode4.Text != "")
                        {
                            if (p4 == 1)
                            {
                                string P1 = ("INSERT INTO [dbo].[INNONCASCDtl] (ItemNo,[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode4.Text + "','" + TxtProQty4.Text + "','" + DrpP4.SelectedItem.Text + "','" + p4 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc4')");
                                obj.exec(P1);
                                obj.closecon();
                            }
                            else
                            {
                                if (!string.IsNullOrWhiteSpace(ProcessingCode1))
                                {
                                    string P1 = ("INSERT INTO [dbo].[INNONCASCDtl] (ItemNo,[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode4.Text + "','" + TxtProQty4.Text + "','" + DrpP4.SelectedItem.Text + "','" + p4 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc4')");
                                    obj.exec(P1);
                                    obj.closecon();
                                }
                            }
                        }
                        p4++;
                    }
                    string cpc5 = ("delete from INNONCASCDtl where PermitId='" + txt_code.Text + "' and CASCId='Casc5' and ItemNo='" + TxtSerialNo.Text + "'");
                    obj.exec(cpc5);
                    obj.closecon();

                    //ProductCode 5
                    if (string.IsNullOrWhiteSpace(TxtProQty5.Text))
                    {
                        TxtProQty5.Text = "0.00";
                    }
                    int p5 = 1;
                    foreach (GridViewRow g5 in ProductCode5Grid1.Rows)
                    {

                        string ProcessingCode1 = (g5.FindControl("TextBox1") as TextBox).Text;
                        string ProcessingCode2 = (g5.FindControl("TextBox2") as TextBox).Text;
                        string ProcessingCode3 = (g5.FindControl("TextBox3") as TextBox).Text;

                        if (TxtProductCode5.Text != "")
                        {
                            if (p5 == 1)
                            {
                                string P1 = ("INSERT INTO [dbo].[INNONCASCDtl] (ItemNo,[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode5.Text + "','" + TxtProQty5.Text + "','" + DrpP5.SelectedItem.Text + "','" + p5 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc5')");
                                obj.exec(P1);
                                obj.closecon();
                            }
                            else
                            {
                                if (!string.IsNullOrWhiteSpace(ProcessingCode1))
                                {
                                    string P1 = ("INSERT INTO [dbo].[INNONCASCDtl] (ItemNo,[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode5.Text + "','" + TxtProQty5.Text + "','" + DrpP5.SelectedItem.Text + "','" + p5 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc5')");
                                    obj.exec(P1);
                                    obj.closecon();
                                }
                            }
                        }
                        p5++;
                    }
                    BindItemMaster();
                    string SumItem = "";
                    string qry11 = "select Count(ItemNo) as InvCount from dbo.InNonItemDtl where PermitId='" + txt_code.Text + "' and MessageType='INPDEC'";
                    obj.dr = obj.ret_dr(qry11);
                    while (obj.dr.Read())
                    {
                        SumItem = obj.dr[0].ToString();
                        txtnoofitm.Text = SumItem;
                    }

                    //Sum of Item Amount

                    string SumofItemAmount = "";
                    string qry11s2Q = "select SUM(TotalLineAmount) as  TotalLineAmount  from dbo.InNonItemDtl where PermitId='" + txt_code.Text + "' and MessageType='INPDEC'";
                    obj.dr = obj.ret_dr(qry11s2Q);
                    while (obj.dr.Read())
                    {
                        SumofItemAmount = obj.dr[0].ToString();
                        txtitmAmt.Text = SumofItemAmount;
                    }


                    //Total GST Amount

                    string TotalGSTAmount = "";
                    string qry11s2 = "select SUM(GSTAmount) as  GSTAmount  from dbo.InNonItemDtl where PermitId='" + txt_code.Text + "' and MessageType='INPDEC'";
                    obj.dr = obj.ret_dr(qry11s2);
                    while (obj.dr.Read())
                    {
                        TotalGSTAmount = obj.dr[0].ToString();
                        txttotgstAmt.Text = TotalGSTAmount;
                        txtAmtPayble.Text = "0.00";
                    }

                    //Total CIF/FOB Value
                    string TotalCIFFOBValue = "";
                    string qry11sS2 = "select SUM(CIFFOB) as  GSTAmount  from dbo.InNonItemDtl where PermitId='" + txt_code.Text + "' and MessageType='INPDEC'";
                    obj.dr = obj.ret_dr(qry11sS2);
                    while (obj.dr.Read())
                    {
                        TotalCIFFOBValue = obj.dr[0].ToString();
                        txtfobval.Text = TotalCIFFOBValue;

                    }
                    ItemAddGrid.Visible = true;
                    ItemDiv.Visible = true;
                    BtnAddNEWItem.Visible = false;
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
                    //}
                    //else
                    //{
                    //    lblitemalert.Visible = true;
                    //    lblitemalert.Text = "Maximum Number of Items are Not Exceed 50";
                    //}
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
            BindItemMaster();
        }

        protected void NewInvoice_Click(object sender, EventArgs e)
        {
            InvoiceGrid.Visible = true;
            InvoiceDiv.Visible = true;
            //NewInvoice.Visible = false;
            InvoiceNo();
        }

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
            string CmdString = "select TIAmount,TICurrency  from dbo.InNonInvoiceDtl where PermitId='" + txt_code.Text + "' and MessageType='INPDEC'  ORDER BY TICurrency DESC";
            SqlCommand cmd = new SqlCommand(CmdString, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Label lbl = new Label();
                lbl.Text = reader["TICurrency"].ToString() + " " + reader["TIAmount"].ToString();
                lbltotinvAmt.Text = reader["TIAmount"].ToString();
                totinvAmt = totinvAmt + " " + lbl.Text + " " + Environment.NewLine;

                lbl.BackColor = System.Drawing.Color.WhiteSmoke;
                lbl.BorderStyle = BorderStyle.Solid;
                lbl.BorderWidth = 1;
                lbl.Width = 150;

                div3.Controls.Add(lbl);
                div3.Controls.Add(new LiteralControl("<br />"));
            }
            lblinvoiceAmt.Text = totinvAmt;
            con.Close();
        }
        private void AddDynamicItem()
        {
            string totinvAmt = "";
            string ConString = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            SqlConnection con = new SqlConnection(ConString);
            string CmdString = "select distinct (UnitPriceCurrency), sum(TotalLineAmount) as TotalLineAmount from InNonItemDtl where PermitId='" + txt_code.Text + "' and MessageType='INPDEC'  GROUP BY UnitPriceCurrency ORDER BY UnitPriceCurrency DESC";
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
                lbl.Width = 150;
                totinvAmt = totinvAmt + " " + lbl.Text + " " + Environment.NewLine;
                div6.Controls.Add(lbl);
                div6.Controls.Add(new LiteralControl("<br />"));
            }
            Label1.Text = totinvAmt;
            con.Close();
        }
        protected void DrpOutwardtrasMode_SelectedIndexChanged(object sender, EventArgs e)
        {

            lbloutwardtm.Text = DrpOutwardtrasMode.SelectedItem.ToString();

            if (DrpOutwardtrasMode.SelectedValue != "")
            {
                OutwardCRUEI.BackColor = System.Drawing.Color.White;
                OutwardName.BackColor = System.Drawing.Color.White;
                ddpVessel.BackColor = System.Drawing.Color.White;
                string TransMode = DrpOutwardtrasMode.SelectedItem.ToString();
                TxtExpMode.Text = TransMode;
                if (DrpOutwardtrasMode.SelectedItem.ToString() != "--Select--")
                {
                    TxtExpMode.Text = TransMode;
                    OUTWARDFlight.Visible = false;
                    OUTWARDSea.Visible = false;
                    OUTWARDVesl.Visible = false;
                    OUTWARDOther.Visible = false;
                    //ContainerDetails.Visible = false;
                 //   OutwardDiv.Visible = true;
                    if (TxtExpMode.Text == "1 : Sea")
                    {
                       // OutwardDiv.Visible = true;
                        OutwardDiv.Visible = true;
                        OUTWARDSea.Visible = true;
                        OUTWARDVesl.Visible = true;
                        outhbl.Visible = true;

                        OutwardCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                        OutwardName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                        ddpVessel.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                        //OutwardCRUEI.BackColor =Color.ac;
                        //  ContainerDetails.Visible = true;
                    }
                    else if (TxtExpMode.Text == "2 : Rail" || TxtExpMode.Text == "3 : Road" || TxtExpMode.Text == "5 : Mail" || TxtExpMode.Text == "7 : Pipeline" || TxtExpMode.Text == "6 : Multi-model(Not in use)")
                    {
                        OutwardDiv.Visible = true;
                        OUTWARDOther.Visible = true;
                        outhbl.Visible = true;
                        //ContainerDetails.Visible = false;
                        //InwardCRUEI.BackColor = System.Drawing.Color.White;
                        //InwardName.BackColor = System.Drawing.Color.White;
                    }

                    else if (TxtExpMode.Text == "4 : Air")
                    {
                        OutwardDiv.Visible = true;
                        OUTWARDFlight.Visible = true;
                        outhbl.Visible = true;
                        //ContainerDetails.Visible = false;

                        OutwardCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                        OutwardName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                        ddpVessel.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    }
                    else if (TxtExpMode.Text == "N : Not Required")
                    {
                        OutwardDiv.Visible = false;
                        OUTWARDFlight.Visible = false;
                        outhbl.Visible = true;
                        //ContainerDetails.Visible = false;
                    }
                    else
                    {
                        OutwardDiv.Visible = false;
                    }
                }
            }
            DrpBGIndicator.Focus();
            upinnoncargo.Update();
            innonpayment.Update();
        }
        private void BindOutward()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Top 20 Id,Code,Name,Name1,CRUEI FROM [InnonOutwardCarrierAgent]"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet dt = new DataSet())
                        {
                            sda.Fill(dt);
                            OutwardGrid.DataSource = dt;
                            OutwardGrid.DataBind();
                        }
                    }
                }
            }
        }
        protected void OutwardSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable _objdt = new DataTable();
            _objdt = GetOutwardDataFromDataBase(OutwardSearch.Text.Replace("'", "''"));
            if (_objdt.Rows.Count > 0)
            {
                OutwardGrid.DataSource = _objdt;
                OutwardGrid.DataBind();
                popupinnonout.Show();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Outward1();", true);
            }
        }

        protected void OutwardGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            OutwardGrid.PageIndex = e.NewPageIndex;
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Outward1();", true);
            popupinnonout.Show();
          
            BindOutward();
        }

        protected void LmkOutward_Command(object sender, CommandEventArgs e)
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


                    OutwardCode.Text = "";
                    OutwardName.Text = "";
                    OutwardName1.Text = "";
                    OutwardCRUEI.Text = "";
                    OutwardCode.Text = requestor;
                    OutwardName.Text = requestType;
                    OutwardName1.Text = status;
                    OutwardCRUEI.Text = crueis;

                }

            }
        }

        protected void OutwardAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(OutwardCode.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Outward Code Is Empty');", true);
            }
            else if (string.IsNullOrWhiteSpace(OutwardCRUEI.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Outward UEI Is Empty');", true);
            }
            else if (string.IsNullOrWhiteSpace(OutwardName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Outward Name Is Empty');", true);
            }
            else
            {
                string Code = "";
                string qry11 = "SELECT Code FROM [InnonOutwardCarrierAgent] where Code='" + OutwardCode.Text.Replace("'", "''") + "'";

                obj.dr = obj.ret_dr(qry11);

                while (obj.dr.Read())
                {
                    Code = obj.dr[0].ToString();

                }
                if (Code == "")
                {
                    string Touch_user = Session["UserId"].ToString();

                    string strTime = System.DateTime.Now.ToString("yyyy/MM/dd");
                    string StrQuery = ("INSERT INTO [dbo].[InnonOutwardCarrierAgent] ([Code],[Name],[Name1],[CRUEI],[TouchUser],[TouchTime]) VALUES ('" + OutwardCode.Text.Replace("'", "''") + "','" + OutwardName.Text.Replace("'", "''") + "','" + OutwardName1.Text.Replace("'", "''") + "','" + OutwardCRUEI.Text.Replace("'", "''") + "','" + Touch_user + "',Convert(VARCHAR,'" + strTime + "',108))");
                    obj.exec(StrQuery);
                    BindOutward();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : Data Saved Successfully');", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Outward Code Already Exist...');", true);
                    //Response.Write("The Inward Code Already Exist..");
                }
            }
        }
        public DataTable GetOutwardDataFromDataBase(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = OutwardSearch.Text;

            string str3 = "SELECT Id,Code,Name,Name1,CRUEI FROM [InnonOutwardCarrierAgent] where Code Like '%" + OutwardSearch.Text.Replace("'", "''") + "%' or Name Like '%" + OutwardSearch.Text.Replace("'", "''") + "%' order by Id desc";
            obj.dr = obj.ret_dr(str3);
            if (obj.dr.HasRows)
            {
                OutwardGrid.DataSource = obj.dr;

            }
            else
            {
                //Empty DataTable to execute the “else-condition”  
                DataTable dt = new DataTable();
                OutwardGrid.DataSource = dt;
                OutwardGrid.DataBind();
            }
            SqlConnection con = new SqlConnection(sqlconn);
            SqlDataAdapter _objda = new SqlDataAdapter(str3, con);
            con.Close();
            _objda.Fill(_objdt);
            return _objdt;
        }

        protected void OutwardCode_TextChanged(object sender, EventArgs e)
        {
            if (OutwardCode.Text != "")
            {
                string[] ss = OutwardCode.Text.Split(':');
                string qry11 = "select Top 1 * from [InnonOutwardCarrierAgent] where Code='" + ss[0].ToString().Replace("'", "''") + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    OutwardCode.Text = obj.dr["Code"].ToString();
                    OutwardName.Text = obj.dr["Name"].ToString();
                    OutwardName1.Text = obj.dr["Name1"].ToString();
                    OutwardCRUEI.Text = obj.dr["CRUEI"].ToString();
                }
            }
            else
            {
                OutwardCode.Text = "";
                OutwardName.Text = "";
                OutwardName1.Text = "";
                OutwardCRUEI.Text = "";
            }
        }
        private void BindExporter()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Top 20 Id,Code,Name,Name1,CRUEI FROM InnonExporter"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet dt = new DataSet())
                        {
                            sda.Fill(dt);
                            ExporterGrid.DataSource = dt;
                            ExporterGrid.DataBind();
                        }
                    }
                }
            }
        }
        protected void ExporterSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable _objdt = new DataTable();
            _objdt = GetExportDataFromDataBase(ExporterSearch.Text.Replace("'", "''"));
            if (_objdt.Rows.Count > 0)
            {
                ExporterGrid.DataSource = _objdt;
                ExporterGrid.DataBind();
                Popupexp.Show();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "EXPORTER();", true);
            }
        }

        protected void ExporterGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ExporterGrid.PageIndex = e.NewPageIndex;
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "EXPORTER();", true);
            Popupexp.Show();
           
            BindExporter();
        }

        protected void LnkExporter_Command(object sender, CommandEventArgs e)
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


                    TxtExpCode.Text = "";
                    TxtExpName.Text = "";
                    TxtExpName1.Text = "";
                    TxtExpCRUEI.Text = "";
                    TxtExpCode.Text = requestor;
                    TxtExpName.Text = requestType;
                    TxtExpName1.Text = status;
                    TxtExpCRUEI.Text = crueis;

                }

            }
        }

        protected void BtnExpAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtExpCode.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Exporter Code Is Empty');", true);
            }
            else if (string.IsNullOrWhiteSpace(TxtExpCRUEI.Text ))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Exporter UEI Is Empty');", true);
            }
            else if (string.IsNullOrWhiteSpace(TxtExpName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Exporter Name Is Empty');", true);
            }
            else
            {
                string Code = "";
                string qry11 = "SELECT Code FROM [InnonExporter] where Code='" + TxtExpCode.Text.Replace("'", "''") + "'";

                obj.dr = obj.ret_dr(qry11);

                while (obj.dr.Read())
                {
                    Code = obj.dr[0].ToString();

                }
                if (Code == "")
                {
                    string Touch_user = Session["UserId"].ToString();

                    string strTime = System.DateTime.Now.ToString("yyyy/MM/dd");
                    string StrQuery = ("INSERT INTO [dbo].[InnonExporter] ([Code],[Name],[Name1],[CRUEI],[TouchUser],[TouchTime]) VALUES ('" + TxtExpCode.Text.Replace("'", "''") + "','" + TxtExpName.Text.Replace("'", "''") + "','" + TxtExpName1.Text.Replace("'", "''") + "','" + TxtExpCRUEI.Text.Replace("'", "''") + "','" + Touch_user + "',Convert(VARCHAR,'" + strTime + "',108))");
                    obj.exec(StrQuery);
                    BindExporter();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : Data Saved Successfully');", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Exporter Code Already Exist...');", true);
                    //Response.Write("The Inward Code Already Exist..");
                }
                InwardCode.Focus();
            }

        }
        public DataTable GetExportDataFromDataBase(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = ExporterSearch.Text;

            string str3 = "SELECT Top 10 Id,Code,Name,Name1,CRUEI FROM [InnonExporter] where Code Like '%" + ExporterSearch.Text.Replace("'", "''") + "%' or Name Like '%" + ExporterSearch.Text.Replace("'", "''") + "%' order by Id desc";
            obj.dr = obj.ret_dr(str3);
            if (obj.dr.HasRows)
            {
                ExporterGrid.DataSource = obj.dr;

            }
            else
            {
                //Empty DataTable to execute the “else-condition”  
                DataTable dt = new DataTable();
                ExporterGrid.DataSource = dt;
                ExporterGrid.DataBind();
            }
            SqlConnection con = new SqlConnection(sqlconn);
            SqlDataAdapter _objda = new SqlDataAdapter(str3, con);
            con.Close();
            _objda.Fill(_objdt);
            return _objdt;
        }

        protected void TxtExpCode_TextChanged(object sender, EventArgs e)
        {
            if (TxtExpCode.Text != "")
            {
                string[] ss = TxtExpCode.Text.Split(':');
                string qry11 = "select Top 1 * from [InnonExporter] where Code='" + ss[0].ToString().Replace("'", "''") + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    TxtExpCode.Text = obj.dr[1].ToString();
                    TxtExpName.Text = obj.dr[2].ToString();
                    TxtExpName1.Text = obj.dr[3].ToString();
                    TxtExpCRUEI.Text = obj.dr[4].ToString();

                    lblexporterparty.Text = obj.dr[4].ToString() + " - " + obj.dr[2].ToString() + " " + obj.dr[3].ToString();

                }
            }
            else
            {
                TxtExpCode.Text = "";
                TxtExpName.Text = "";
                TxtExpName1.Text = "";
                TxtExpCRUEI.Text = "";
            }
            InwardCode.Focus();
        }
        private void BindConsignee()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Top 20 * FROM InnonConsignee"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet dt = new DataSet())
                        {
                            sda.Fill(dt);
                            ConsigneeGrid.DataSource = dt;
                            ConsigneeGrid.DataBind();
                        }
                    }
                }
            }
        }
        protected void ConsigneeSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable _objdt = new DataTable();
            _objdt = GetConsigneeDataFromDataBase(ConsigneeSearch.Text.Replace("'", "''"));
            if (_objdt.Rows.Count > 0)
            {
                ConsigneeGrid.DataSource = _objdt;
                ConsigneeGrid.DataBind();
                popupinnonconsignee.Show();
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Consignee();", true);
            }
        }

        protected void ConsigneeGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ConsigneeGrid.PageIndex = e.NewPageIndex;
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Consignee();", true);
            popupinnonconsignee.Show();
          
            BindConsignee();
        }

        protected void LmkConsignee_Command(object sender, CommandEventArgs e)
        {
            var lb = (LinkButton)sender;
            var row = (GridViewRow)lb.NamingContainer;
            if (row != null)
            {
                var lblCode1 = row.FindControl("lblCode") as Label;
                var lblName1 = row.FindControl("lblName") as Label;
                var lblName11 = row.FindControl("lblName1") as Label;
                var cruei1 = row.FindControl("lblCRUEI") as Label;
                var ConsigneeAddress1 = row.FindControl("ConsigneeAddress") as Label;
                var ConsigneeAddress11 = row.FindControl("ConsigneeAddress1") as Label;
                var ConsigneeCity1 = row.FindControl("ConsigneeCity") as Label;
                var ConsigneeSub1 = row.FindControl("ConsigneeSub") as Label;
                var ConsigneeSubdivi = row.FindControl("ConsigneeSubDivi") as Label;
                var ConsigneePostal1 = row.FindControl("ConsigneePostal") as Label;
                var ConsigneeCountry1 = row.FindControl("ConsigneeCountry") as Label;

                //Get values
                string requestor = lblCode1.Text;
                string requestType = lblName1.Text;
                string status = lblName11.Text;
                string crueis = cruei1.Text;
                string ConsigneeAddress12 = ConsigneeAddress1.Text;
                string ConsigneeAddress112 = ConsigneeAddress11.Text;
                string ConsigneeCity12 = ConsigneeCity1.Text;
                string ConsigneeSub12 = ConsigneeSub1.Text;
                string ConsigneeSub121divi = ConsigneeSubdivi.Text;
                string ConsigneePostal12 = ConsigneePostal1.Text;
                string ConsigneeCountry12 = ConsigneeCountry1.Text;


                ConsigneeCode.Text = "";
                ConsigneeName.Text = "";
                ConsigneeName1.Text = "";
                ConsigneeCRUEI.Text = "";
                ConsigneeAddress.Text = "";
                ConsigneeAddress1.Text = "";
                ConsigneeCity.Text = "";
                ConsigneeSub.Text = "";
                ConsigneeSubDivi.Text = "";
                ConsigneePostal.Text = "";
                ConsigneeCountry.Text = "";



                ConsigneeCode.Text = requestor;
                ConsigneeName.Text = requestType;
                ConsigneeName1.Text = status;
                ConsigneeCRUEI.Text = crueis;
                ConsigneeAddress.Text = ConsigneeAddress12;
                ConsigneeAddress1.Text = ConsigneeAddress112;
                ConsigneeCity.Text = ConsigneeCity12;
                ConsigneeSub.Text = ConsigneeSub12;
                ConsigneeSubDivi.Text = ConsigneeSub121divi;
                ConsigneePostal.Text = ConsigneePostal12;
                ConsigneeCountry.Text = ConsigneeCountry12;




            }
        }

        protected void ConsigneeAdd_Click(object sender, EventArgs e)
        {
            string Code = "";
            string qry11 = "SELECT ConsigneeCode FROM InnonConsignee where ConsigneeCode='" + ConsigneeCode.Text.Replace("'", "''") + "'";
            obj.dr = obj.ret_dr(qry11);
            while (obj.dr.Read())
            {
                Code = obj.dr[0].ToString();
            }
            if (Code == "")
            {
                if (string.IsNullOrWhiteSpace(ConsigneeName.Text))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : Consignee Name is Empty...');", true);
                    return;
                }
                if (string.IsNullOrWhiteSpace(ConsigneeAddress.Text))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : Consignee Address is Empty...');", true);
                    return;
                }
                if (string.IsNullOrWhiteSpace(ConsigneeCountry.Text))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : Consignee Country is Empty...');", true);
                    return;
                }
                else
                {
                    string Touch_user = Session["UserId"].ToString();
                    string strTime = System.DateTime.Now.ToString("yyyy/MM/dd");
                    string StrQuery = ("INSERT INTO [dbo].[InnonConsignee] ([ConsigneeCode],[ConsigneeName],[ConsigneeName1],[ConsigneeCRUEI],[ConsigneeAddress],[ConsigneeAddress1],[ConsigneeCity],[ConsigneeSub],ConsigneeSubDivi,[ConsigneePostal],[ConsigneeCountry],[TouchUser],[TouchTime])  VALUES ('" + ConsigneeCode.Text.Replace("'", "''") + "','" + ConsigneeName.Text.Replace("'", "''") + "','" + ConsigneeName1.Text.Replace("'", "''") + "','" + ConsigneeCRUEI.Text.Replace("'", "''") + "','" + ConsigneeAddress.Text.Replace("'", "''") + "','" + ConsigneeAddress1.Text.Replace("'", "''") + "','" + ConsigneeCity.Text.Replace("'", "''") + "','" + ConsigneeSub.Text.Replace("'", "''") + "','" + ConsigneeSubDivi.Text.Replace("'", "''") + "','" + ConsigneePostal.Text.Replace("'", "''") + "','" + ConsigneeCountry.Text.Replace("'", "''") + "','" + Touch_user + "',Convert(VARCHAR,'" + strTime + "',108))");
                    obj.exec(StrQuery);
                    BindConsignee();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : Data Saved Successfully');", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Inward Code Already Exist...');", true);
                //Response.Write("The Inward Code Already Exist..");
            }
        }
        public DataTable GetConsigneeDataFromDataBase(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = ConsigneeSearch.Text;

            string str3 = "SELECT Top 10 * FROM InnonConsignee where ConsigneeCode Like '%" + ConsigneeSearch.Text.Replace("'", "''") + "%' or ConsigneeName Like '%" + ConsigneeSearch.Text.Replace("'", "''") + "%' order by Id desc";
            obj.dr = obj.ret_dr(str3);
            if (obj.dr.HasRows)
            {
                ConsigneeGrid.DataSource = obj.dr;

            }
            else
            {
                //Empty DataTable to execute the “else-condition”  
                DataTable dt = new DataTable();
                ConsigneeGrid.DataSource = dt;
                ConsigneeGrid.DataBind();
            }
            SqlConnection con = new SqlConnection(sqlconn);
            SqlDataAdapter _objda = new SqlDataAdapter(str3, con);
            con.Close();
            _objda.Fill(_objdt);
            return _objdt;
        }



        protected void ConsigneeCode_TextChanged(object sender, EventArgs e)
        {
            if (ConsigneeCode.Text != "")
            {
                string[] ss = ConsigneeCode.Text.Split(':');
                string qry11 = "select Top 1 * from InnonConsignee where ConsigneeCode='" + ss[0].ToString().Replace("'", "''") + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    ConsigneeCode.Text = obj.dr[1].ToString();
                    ConsigneeName.Text = obj.dr[2].ToString();
                    ConsigneeName1.Text = obj.dr[3].ToString();
                    ConsigneeCRUEI.Text = obj.dr[4].ToString();
                    ConsigneeAddress.Text = obj.dr[5].ToString();
                    ConsigneeAddress1.Text = obj.dr[6].ToString();
                    ConsigneeCity.Text = obj.dr[7].ToString();
                    ConsigneeSub.Text = obj.dr[8].ToString();
                    ConsigneeSubDivi.Text = obj.dr[9].ToString();
                    ConsigneePostal.Text = obj.dr[10].ToString();
                    ConsigneeCountry.Text = obj.dr[11].ToString();
                }
            }
            else
            {
                ConsigneeCode.Text = "";
                ConsigneeName.Text = "";
                ConsigneeName1.Text = "";
                ConsigneeCRUEI.Text = "";
                ConsigneeAddress.Text = "";
                ConsigneeAddress1.Text = "";
                ConsigneeCity.Text = "";
                ConsigneeSub.Text = "";
                ConsigneeSubDivi.Text = "";
                ConsigneePostal.Text = "";
                ConsigneeCountry.Text = "";
            }



        }
        private void BindExportPort()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Top 100 * FROM LoadingPort"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet dt = new DataSet())
                        {
                            sda.Fill(dt);
                            ExportGrid.DataSource = dt;
                            ExportGrid.DataBind();
                        }
                    }
                }
            }
        }
        protected void ExpLoadingSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable _objdt = new DataTable();
            _objdt = GetPortDataFromDataBase(ExpLoadingSearch.Text.Replace("'", "''"));
            if (_objdt.Rows.Count > 0)
            {
                ExportGrid.DataSource = _objdt;
                ExportGrid.DataBind();
                popupinnondichargeport.Show();
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Export();", true);
            }
        }

        protected void ExportGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ExportGrid.PageIndex = e.NewPageIndex;
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Export();", true);
            popupinnondichargeport.Show();
        
            BindExportPort();
        }

        protected void LnkExport_Command(object sender, CommandEventArgs e)
        {
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


                    TxtExpLoadShort.Text = "";
                    TxtExpLoad.Text = "";


                    TxtExpLoadShort.Text = requestor;
                    TxtExpLoad.Text = requestType;
                }

            }
        }

        protected void TxtExpMode_TextChanged(object sender, EventArgs e)
        {
            if (TxtExpMode.Text == "")
            {

                if (TxtExpMode.Text == "1 : Sea")
                {
                    OUTWARDSea.Visible = true;
                }
                else if (TxtExpMode.Text == "2 : Rail" || TxtExpMode.Text == "3 : Road" || TxtExpMode.Text == "5 : Mail" || TxtExpMode.Text == "7 : Pipeline" || TxtExpMode.Text == "N : Not Required" || TxtExpMode.Text == "6 : Multi-model(Not in use)")
                {
                    OUTWARDOther.Visible = true;
                }

                else if (TxtExpMode.Text == "4 : Air")
                {
                    OUTWARDFlight.Visible = true;
                }
            }
        }
        public DataTable GetPortDataFromDataBase(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = ExpLoadingSearch.Text;
            string str3 = "SELECT * LoadingPort where PortCode Like '%" + ExpLoadingSearch.Text.Replace("'", "''") + "%' or PortName like '" + ExpLoadingSearch.Text.Replace("'", "''") + "%' order by Id desc";
            obj.dr = obj.ret_dr(str3);
            if (obj.dr.HasRows)
            {
                ExportGrid.DataSource = obj.dr;

            }
            else
            {
                //Empty DataTable to execute the “else-condition”  
                DataTable dt = new DataTable();
                ExportGrid.DataSource = dt;
                ExportGrid.DataBind();
            }
            SqlConnection con = new SqlConnection(sqlconn);
            SqlDataAdapter _objda = new SqlDataAdapter(str3, con);
            con.Close();
            _objda.Fill(_objdt);
            return _objdt;
        }
        protected void TxtExpLoadShort_TextChanged(object sender, EventArgs e)
        {
            if (TxtExpLoadShort.Text != "")
            {
                string[] ss = TxtExpLoadShort.Text.Split(':');
                string qry11 = "select Top 1 * from LoadingPort where PortCode='" + ss[0].ToString().Replace("'", "''") + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    TxtExpLoadShort.Text = obj.dr["PortCode"].ToString();
                    TxtExpLoad.Text = obj.dr["PortName"].ToString();
                }
            }
            else
            {
                TxtExpLoadShort.Text = "";
                TxtExpLoad.Text = "";
            }
        }

        protected void ChkSea_CheckedChanged(object sender, EventArgs e)
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

        protected void btnSeaStr_Click(object sender, EventArgs e)
        {
            DataTable dtCurrent = ViewState["CurrentTable26"] as DataTable;

            // Check if current rows are already 5
            if (dtCurrent != null && dtCurrent.Rows.Count >= 5)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You can only add up to 5 rows.');", true);
                return;
            }

            if (SeaGrid.Rows.Count > 0) // Replace "CWCGrid" with your actual GridView ID
            {
                int lastRowIndex = SeaGrid.Rows.Count - 1;

                // Replace these with your actual control IDs from the grid
                TextBox box1 = (TextBox)SeaGrid.Rows[lastRowIndex].Cells[1].FindControl("TextBox1");
                TextBox box2 = (TextBox)SeaGrid.Rows[lastRowIndex].Cells[2].FindControl("TextBox2");
                TextBox box3 = (TextBox)SeaGrid.Rows[lastRowIndex].Cells[3].FindControl("TextBox3");

                if (string.IsNullOrWhiteSpace(box1.Text) )
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

        protected void txtNextprt_TextChanged(object sender, EventArgs e)
        {
            if (txtNextprt.Text != "")
            {
                string qry11 = "select Top 1 * from LoadingPort where PortCode='" + txtNextprt.Text.Replace("'", "''") + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    txtNextprt.Text = obj.dr["PortCode"].ToString();
                    txtNetPrtSer.Text = obj.dr["PortName"].ToString();
                }
            }
            else
            {
                txtNextprt.Text = "";
                txtNetPrtSer.Text = "";
            }
        }

        protected void txtLasPrt_TextChanged(object sender, EventArgs e)
        {
            if (txtLasPrt.Text != "")
            {
                string qry11 = "select Top 1 * from LoadingPort where PortCode='" + txtLasPrt.Text.Replace("'", "''") + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    txtLasPrt.Text = obj.dr["PortCode"].ToString();
                    txtLasPrtSer.Text = obj.dr["PortName"].ToString();
                }
            }
            else
            {
                txtLasPrt.Text = "";
                txtLasPrtSer.Text = "";
            }
        }
        private void BindNextPort()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Top 100 * FROM LoadingPort"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet dt = new DataSet())
                        {
                            sda.Fill(dt);
                            NextPortGrid.DataSource = dt;
                            NextPortGrid.DataBind();
                        }
                    }
                }
            }
        }
        private void BindLastPort()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Top 100 * FROM LoadingPort"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet dt = new DataSet())
                        {
                            sda.Fill(dt);
                            LastGrid.DataSource = dt;
                            LastGrid.DataBind();
                        }
                    }
                }
            }
        }

        protected void NextPortGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            NextPortGrid.PageIndex = e.NewPageIndex;
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "NextPort();", true);
            popupinnonnxtport.Show();
        

            BindNextPort();
        }

        protected void LnkLoading1_Command(object sender, CommandEventArgs e)
        {
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


                    txtNextprt.Text = "";
                    txtNetPrtSer.Text = "";

                    txtNextprt.Text = requestor;
                    txtNetPrtSer.Text = requestType;


                }

            }
        }

        protected void txtlastprt_TextChanged(object sender, EventArgs e)
        {
            DataTable _objdt = new DataTable();
            _objdt = GetLastPortDataFromDataBase(txtlastprt.Text);
            if (_objdt.Rows.Count > 0)
            {
                LastGrid.DataSource = _objdt;
                LastGrid.DataBind();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "LastPort();", true);
            }
            popupinnonlastport.Show();
         
        }

        protected void LastGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            LastGrid.PageIndex = e.NewPageIndex;
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "LastPort();", true);
            popupinnonlastport.Show();
       
            BindLastPort();
        }
        public DataTable GetNextPortDataFromDataBase(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = NextPrtLoading.Text;

            string str3 = "SELECT Top 10 * FROM LoadingPort where PortCode Like '%" + NextPrtLoading.Text + "%' order by Id desc";
            obj.dr = obj.ret_dr(str3);
            if (obj.dr.HasRows)
            {
                NextPortGrid.DataSource = obj.dr;

            }
            else
            {
                //Empty DataTable to execute the “else-condition”  
                DataTable dt = new DataTable();
                NextPortGrid.DataSource = dt;
                NextPortGrid.DataBind();
            }
            SqlConnection con = new SqlConnection(sqlconn);
            SqlDataAdapter _objda = new SqlDataAdapter(str3, con);
            con.Close();
            _objda.Fill(_objdt);
            return _objdt;
        }
        public DataTable GetLastPortDataFromDataBase(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = txtlastprt.Text;

            string str3 = "SELECT Top 10 * FROM LoadingPort where PortCode Like '%" + txtlastprt.Text + "%' order by Id desc";
            obj.dr = obj.ret_dr(str3);
            if (obj.dr.HasRows)
            {
                LastGrid.DataSource = obj.dr;

            }
            else
            {
                //Empty DataTable to execute the “else-condition”  
                DataTable dt = new DataTable();
                LastGrid.DataSource = dt;
                LastGrid.DataBind();
            }
            SqlConnection con = new SqlConnection(sqlconn);
            SqlDataAdapter _objda = new SqlDataAdapter(str3, con);
            con.Close();
            _objda.Fill(_objdt);
            return _objdt;
        }
        protected void LnkLoading2_Command(object sender, CommandEventArgs e)
        {
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


                    txtLasPrt.Text = "";
                    txtLasPrtSer.Text = "";

                    txtLasPrt.Text = requestor;
                    txtLasPrtSer.Text = requestType;


                }

            }
        }

        protected void NextPrtLoading_TextChanged(object sender, EventArgs e)
        {
            DataTable _objdt = new DataTable();
            _objdt = GetNextPortDataFromDataBase(NextPrtLoading.Text);
            if (_objdt.Rows.Count > 0)
            {
                NextPortGrid.DataSource = _objdt;
                NextPortGrid.DataBind();
                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "NextPort();", true);
            }
            popupinnonnxtport.Show();
         
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
            string strBindTxtBox = "select * from [InNonInvoiceDtl] where Id=" + ID;
            obj.dr = obj.ret_dr(strBindTxtBox);
            while (obj.dr.Read())
            {


                txtserial.Text = obj.dr["SNo"].ToString();
                txtinvNo.Text = obj.dr["InvoiceNo"].ToString();
                string Invoice = txt_code.Text;
               
                txtinvDate1.Text = Convert.ToDateTime(obj.dr["InvoiceDate"].ToString()).ToString("dd/MM/yyyy");


                DrpTerms.ClearSelection();
                string str = obj.dr["TermType"].ToString();
                DrpTerms.Items.FindByText(obj.dr["TermType"].ToString()).Selected = true;
                //  DrpTerms.SelectedValue = obj.dr[4].ToString();
                // DrpTerms.SelectedItem.Text = obj.dr[4].ToString();

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
                // Drpcurrency1.SelectedItem.Text = obj.dr[10].ToString();
                LblTotalInvoice.Text = obj.dr["TIExRate"].ToString();
                TxtTotalInvoice.Text = obj.dr["TIAmount"].ToString();
                SumTotalInvoice.Text = obj.dr["TISAmount"].ToString();

                //txt_ln.Text = obj.dr[3].ToString();
                OtherTaxableChargePer.Text = obj.dr["OTCCharge"].ToString();

                Drpcurrency2.ClearSelection();
                Drpcurrency2.Items.FindByText(obj.dr["OTCCurrency"].ToString()).Selected = true;
                //  Drpcurrency2.SelectedItem.Text = obj.dr[15].ToString();
                lblOtherTaxableCharge.Text = obj.dr["OTCExRate"].ToString();
                TxtOtherTaxableCharge.Text = obj.dr["OTCAmount"].ToString();
                SumOtherTaxableCharge.Text = obj.dr["OTCSAmount"].ToString();
                FrieghtChargesPer.Text = obj.dr["FCCharge"].ToString();

                Drpcurrency3.ClearSelection();
                Drpcurrency3.Items.FindByText(obj.dr["FCCurrency"].ToString()).Selected = true;
                // Drpcurrency3.SelectedItem.Text = obj.dr[20].ToString();
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
                string supp = "select * from [INNONSUPPLIERMANUFACTURERPARTY] where Code='" + SuplierCode + "'";
                obj.dr = obj.ret_dr(supp);
                while (obj.dr.Read())
                {
                    txtcodeinvq.Text = obj.dr[1].ToString();
                    txtName.Text = obj.dr[2].ToString();
                    txtName1.Text = obj.dr[3].ToString();
                    txtcruei.Text = obj.dr[4].ToString();
                }
                string imp = "select * from [Importer] where Code='" + Importer + "'";
                obj.dr = obj.ret_dr(imp);
                while (obj.dr.Read())
                {
                    TxtImppartyCode.Text = obj.dr[1].ToString();
                    TxtImppartyName.Text = obj.dr[2].ToString();
                    TxtImppartyName1.Text = obj.dr[3].ToString();
                    TxtImppartyCRUEI.Text = obj.dr[4].ToString();
                }
                // DrpTerms_SelectedIndexChanged(null, null);
                InvoiceGrid.Visible = true;
                InvoiceDiv.Visible = true;
                //NewInvoice.Visible = false;
                string striW = "select * from [InNonInvoiceDtl] where MessageType='INPDEC' AND PermitId='" + Invoice + "'  order by InvoiceNo";
                obj.dr = obj.ret_dr(striW);
                obj.BindDropDown(DrpInvoiceNo, obj.dr, "Id", "InvoiceNo");               
            }

            DrpTerms_SelectedIndexChanged(null, null);
            TxtTotalInvoice_TextChanged(null, null);
            TxtFrieghtCharges_TextChanged(null, null);
        }

        protected void ItemEdit_Click(object sender, ImageClickEventArgs e)
        {
            string P1 = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
            obj.dr = obj.ret_dr(P1);
            obj.BindDropDown(DrpP1, obj.dr, "Name", "Name");            

            P1 = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
            obj.dr = obj.ret_dr(P1);
            obj.BindDropDown(DrpP2, obj.dr, "Name", "Name");            

            P1 = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
            obj.dr = obj.ret_dr(P1);
            obj.BindDropDown(DrpP3, obj.dr, "Name", "Name");
            
            P1 = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
            obj.dr = obj.ret_dr(P1);
            obj.BindDropDown(DrpP4, obj.dr, "Name", "Name");
            
            P1 = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
            obj.dr = obj.ret_dr(P1);
            obj.BindDropDown(DrpP5, obj.dr, "Name", "Name");
            
            string stra = "select Id,Name from [CommonMaster] where TypeId='12' and StatusID='1' order by Name";
            obj.dr = obj.ret_dr(stra);
            obj.BindDropDown(DrpMaking, obj.dr, "Id", "Name");

            string Invoice = txt_code.Text;
            string striW = "select * from [InNonInvoiceDtl] where MessageType='INPDEC' AND PermitId='" + Invoice + "'  order by InvoiceNo";
            obj.dr = obj.ret_dr(striW);
            obj.BindDropDown(DrpInvoiceNo, obj.dr, "Id", "InvoiceNo");
            
            GridViewRow grdrow = (GridViewRow)((ImageButton)sender).NamingContainer as GridViewRow;
            Label ID1 = (Label)grdrow.FindControl("lblID");
            string ID = ID1.Text;
            //warning
            //   string SuplierCode, Importer = "";
            string strBindTxtBox = "select * from [InNonItemDtl] where Id=" + ID;
            obj.dr = obj.ret_dr(strBindTxtBox);
            while (obj.dr.Read())
            {
                TxtSerialNo.Text = obj.dr["ItemNo"].ToString();
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
                TxtModel.Text = obj.dr["Model"].ToString();


                if (!string.IsNullOrWhiteSpace(obj.dr["Vehicletype"].ToString()))
                {
                    DrpVehicleType.ClearSelection();
                    DrpVehicleType.Items.FindByText(obj.dr["Vehicletype"].ToString()).Selected = true;
                }
                else
                {
                    DrpVehicleType.ClearSelection();
                    DrpVehicleType.Items.FindByText("--Select--").Selected = true;
                }

                txtengine.Text = obj.dr["Enginecapacity"].ToString();

                if (!string.IsNullOrWhiteSpace(obj.dr["Engineuom"].ToString()))
                {
                    DrpVehicleCapacity.ClearSelection();
                    DrpVehicleCapacity.Items.FindByText(obj.dr["Engineuom"].ToString()).Selected = true;
                }
                else
                {
                    DrpVehicleCapacity.ClearSelection();
                    DrpVehicleCapacity.Items.FindByText("--Select--").Selected = true;
                }

                DateTime orgindate = Convert.ToDateTime(null);
                if (obj.dr["Orginregdate"].ToString() != "")
                {

                    txtorgindate.Text = Convert.ToDateTime(obj.dr["Orginregdate"].ToString()).ToString("dd/MM/yyyy");
                }
                else
                {

                    txtorgindate.Text = "";

                }

                txtlsp.Text = obj.dr["LSPValue"].ToString();

                TxtHAWB.Items.Add(obj.dr["InHAWBOBL"].ToString());
                txtOutHAWB1.Items.Add(obj.dr["OutHAWBOBL"].ToString());                       
                TxtTotalDutiableQuantity.Text = obj.dr["DutiableQty"].ToString();
                TDQUOM.ClearSelection();
                TDQUOM.Items.FindByText(obj.dr["DutiableUOM"].ToString()).Selected = true;
                //TDQUOM.SelectedItem.Text = obj.dr[13].ToString();
                txttotDutiableQty.Text = obj.dr["TotalDutiableQty"].ToString();
                ddptotDutiableQty.ClearSelection();
                ddptotDutiableQty.Items.FindByText(obj.dr["TotalDutiableUOM"].ToString()).Selected = true;
                TxtInvQty.Text = obj.dr["InvoiceQuantity"].ToString();
                TxtHSQuantity.Text = obj.dr["HSQty"].ToString();

                // HSQTYUOM.SelectedItem.Text = obj.dr[16].ToString();
                HSQTYUOM.ClearSelection();
                HSQTYUOM.Items.FindByText(obj.dr["HSUOM"].ToString()).Selected = true;
                txtAlcoholPer.Text = obj.dr["AlcoholPer"].ToString();
                DrpInvoiceNo.ClearSelection();
                string striW1 = "select * from [InNonInvoiceDtl] where MessageType='INPDEC' AND PermitId='" + Invoice + "' and  InvoiceNo='" + obj.dr["InvoiceNo"].ToString() + "' order by InvoiceNo";
                InnonPaymentClass objinv = new InnonPaymentClass();
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

                TxtUnitPrice.Text = obj.dr["UnitPrice"].ToString();
                DRPCurrency.ClearSelection();
                DRPCurrency.Items.FindByText(obj.dr["UnitPriceCurrency"].ToString()).Selected = true;
                //  DRPCurrency.SelectedItem.Text = obj.dr[19].ToString();
                TxtExchangeRate.Text = obj.dr["ExchangeRate"].ToString();
                TxtSumExRate.Text = obj.dr["SumExchangeRate"].ToString();
                TxtTotalLineAmount.Text = obj.dr["TotalLineAmount"].ToString();
                TxtTotalLineCharges.Text = obj.dr["InvoiceCharges"].ToString();
                TxtCIFFOB.Text = obj.dr["CIFFOB"].ToString();
                if (!string.IsNullOrWhiteSpace(obj.dr["OptionalChrgeUOM"].ToString()))
                {
                    if (obj.dr["OptionalChrgeUOM"].ToString() != "--Select--")
                    {
                        DrpOptionalUom.ClearSelection();
                        DrpOptionalUom.Items.FindByText(obj.dr["OptionalChrgeUOM"].ToString()).Selected = true;
                    }
                }
                TxtOptionalPrice.Text = obj.dr["Optioncahrge"].ToString();
                TxtOptionalExchageRate.Text = obj.dr["OptionalSumtotal"].ToString();
                TxtOptionalSumExRate.Text = obj.dr["OptionalSumExchage"].ToString();
                
                TxtOPQty.Text =Math.Round(Convert.ToDecimal(obj.dr["OPQty"].ToString()),0).ToString();

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

                if (Convert .ToDecimal ( obj.dr["OPQty"].ToString() )>0)
                {
                    PackingInfo.Visible = true;
                }


                DRPOPQUOM.ClearSelection();
                DRPOPQUOM.Items.FindByText(obj.dr["OPUOM"].ToString()).Selected = true;
                // DRPOPQUOM.SelectedItem.Text = obj.dr[26].ToString();
                TxtIPQty.Text = Math.Round(Convert.ToDecimal(obj.dr["IPQty"].ToString()),0).ToString();

                DRPIPQUOM.ClearSelection();
                DRPIPQUOM.Items.FindByText(obj.dr["IPUOM"].ToString()).Selected = true;
                /// DRPIPQUOM.SelectedItem.Text = obj.dr[28].ToString();
                TxtINPQty.Text = Math.Round(Convert.ToDecimal(obj.dr["InPqty"].ToString()), 0).ToString();

                DRPINNPQUOM.ClearSelection();
                DRPINNPQUOM.Items.FindByText(obj.dr["InPUOM"].ToString()).Selected = true;
                //DRPINNPQUOM.SelectedItem.Text = obj.dr[30].ToString();
                TxtIMPQty.Text = Math.Round(Convert.ToDecimal(obj.dr["ImPQty"].ToString()), 0).ToString();

                DRPIMPQUOM.ClearSelection();
                DRPIMPQUOM.Items.FindByText(obj.dr["ImPUOM"].ToString()).Selected = true;
                // DRPIMPQUOM.SelectedItem.Text = obj.dr[32].ToString();

                DrpPreferentialCode.ClearSelection();
                DrpPreferentialCode.Items.FindByText(obj.dr["PreferentialCode"].ToString()).Selected = true;
                //DrpPreferentialCode.SelectedItem.Text = obj.dr[33].ToString();
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
                //  DrpOtherUOM.SelectedItem.Text = obj.dr[44].ToString();
                TxtSumOtherTaxRate.Text = obj.dr["OtherTaxAmount"].ToString();

                if (obj.dr["CurrentLot"].ToString() == "")
                {
                    LOTID.Visible = true;
                }
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
                TxtPreviousLot.Text = obj.dr["PreviousLot"].ToString();

                DrpMaking.ClearSelection();
                DrpMaking.Items.FindByText(obj.dr["Making"].ToString()).Selected = true;                
                if (!string.IsNullOrWhiteSpace(obj.dr["ShippingMarks1"].ToString()))
                {
                    ShippMarkDiv.Visible = true;
                }

                txtShippingMarks1.Text = obj.dr["ShippingMarks1"].ToString();
                txtShippingMarks2.Text = obj.dr["ShippingMarks2"].ToString();
                txtShippingMarks3.Text = obj.dr["ShippingMarks3"].ToString();
                txtShippingMarks4.Text = obj.dr["ShippingMarks4"].ToString();
                editbindProduct1(ID);
                editbindProduct2(ID);
                editbindProduct3(ID);
                editbindProduct4(ID);
                editbindProduct5(ID);

                string co = "select * from [Country] where CountryCode='" + TxtCountryItem.Text + "'";
                obj.dr = obj.ret_dr(co);
                while (obj.dr.Read())
                {
                    txtcname.Text = obj.dr["Description"].ToString();
                }               
                DrpInvoiceNo_SelectedIndexChanged(null,null);
                ItemAddGrid.Visible = true;
                ItemDiv.Visible = true;
                BtnAddNEWItem.Visible = false;
            }
            //EditItem();
        }
        private void editbindProduct1(string ID)
        {
            string strBindTxtBox = "select * from [InNonItemDtl] where Id=" + ID;
            obj.dr = obj.ret_dr(strBindTxtBox);
            while (obj.dr.Read())
            {
                SqlConnection con = new SqlConnection(sqlconn);
                //SqlCommand cmd1 = new SqlCommand("SELECT T1.Id ,T1.CRP,T1.CompanyName,T1.Name,T1.EmailId,T1.Mobile, T2.Name as Rent ,t1.BudgetFrom,T1.BudgetTo ,T3.Name as Type,T4.Name as Location,T5.PropertyRef,T1.MultipleLocation,T1. MultipleProperty  FROM (select a.Id,a.CompanyName,a.Name,a.EmailId,a.Mobile,a.BudgetFrom,a.BudgetTo,b.Name as CRP,a.MultipleLocation,a.MultipleProperty  from lead a,CommonMaster b where a.Per_Com=b.Id and a.TouchUser='" + Touch_user + "') AS T1 JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.RentorBuy=b.Id) AS T2    ON T1.Id = T2.Id    JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Type=b.Id) AS T3  ON T1.Id = T3.Id     JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Location=b.Id) AS T4   ON T1.Id = T4.Id    JOIN ( select b.ID,b.Name,a.PropertyRef  from Lead_List a,Lead b where a.ParentId=b.Id) AS T5   ON T1.Id = T5.Id order by T1.Id desc", con);
                //SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3, Quantity , ProductCode from InNonItemDtl a,INNONCASCDtl b where a.PermitId=b.PermitId and b.CASCId='Casc1' and a.PermitId='" + txt_code.Text + "'", con);
                SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3, Quantity , ProductCode from INNONCASCDtl  where CASCId='Casc1' and PermitId='" + txt_code.Text + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "' ORDER BY RowNumber asc", con);
                string ff = "select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3, Quantity , ProductCode,ProductUOM from INNONCASCDtl  where CASCId='Casc1' and PermitId='" + txt_code.Text + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "' ORDER BY RowNumber asc";
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                sda1.Fill(dt);                
                ViewState["ProductCode1"] = dt;
                InnonPaymentClass objprc = new InnonPaymentClass();
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
                    if (!string.IsNullOrWhiteSpace(objprc.dr["ProductUOM"].ToString()))
                    {
                        DrpP1.ClearSelection();
                        DrpP1.Items.FindByText(objprc.dr["ProductUOM"].ToString()).Selected = true;
                    }

                    //DrpP1.SelectedItem.Text = obj.dr["ProductUOM"].ToString();
                }
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
                            //TextBox box4 = (TextBox)ProductCode1Grid.Rows[rowIndex].Cells[4].FindControl("TxtProQty1");
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
                            //AddProductCode1Grid();
                            rowIndex++;
                        }
                       
                    }
                }
            }
        }

        private void editbindProduct2(string ID)
        {
            string strBindTxtBox = "select * from [InNonItemDtl] where Id=" + ID;
            obj.dr = obj.ret_dr(strBindTxtBox);
            while (obj.dr.Read())
            {
                SqlConnection con = new SqlConnection(sqlconn);
                //SqlCommand cmd1 = new SqlCommand("SELECT T1.Id ,T1.CRP,T1.CompanyName,T1.Name,T1.EmailId,T1.Mobile, T2.Name as Rent ,t1.BudgetFrom,T1.BudgetTo ,T3.Name as Type,T4.Name as Location,T5.PropertyRef,T1.MultipleLocation,T1. MultipleProperty  FROM (select a.Id,a.CompanyName,a.Name,a.EmailId,a.Mobile,a.BudgetFrom,a.BudgetTo,b.Name as CRP,a.MultipleLocation,a.MultipleProperty  from lead a,CommonMaster b where a.Per_Com=b.Id and a.TouchUser='" + Touch_user + "') AS T1 JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.RentorBuy=b.Id) AS T2    ON T1.Id = T2.Id    JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Type=b.Id) AS T3  ON T1.Id = T3.Id     JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Location=b.Id) AS T4   ON T1.Id = T4.Id    JOIN ( select b.ID,b.Name,a.PropertyRef  from Lead_List a,Lead b where a.ParentId=b.Id) AS T5   ON T1.Id = T5.Id order by T1.Id desc", con);
                //SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3 from InNonItemDtl a,INNONCASCDtl b where a.PermitId=b.PermitId and b.CASCId='Casc2' and a.PermitId='" + txt_code.Text + "'", con);
                SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3, Quantity , ProductCode from INNONCASCDtl  where CASCId='Casc2' and PermitId='" + txt_code.Text + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "' ORDER BY RowNumber asc", con);
                string ff = "select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3,Quantity , ProductCode,ProductUOM from INNONCASCDtl  where CASCId='Casc2' and PermitId='" + txt_code.Text + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "' ORDER BY RowNumber asc";
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                sda1.Fill(dt);
                ViewState["ProductCode2"] = dt;
                InnonPaymentClass objprc = new InnonPaymentClass();
                objprc.dr = objprc.ret_dr(ff);
                if (objprc.dr.Read())
                {
                    TxtProQty2.Text = objprc.dr["Quantity"].ToString();
                    TxtProductCode2.Text = objprc.dr["ProductCode"].ToString();
                    DrpP2.ClearSelection();
                    DrpP2.Items.FindByText(objprc.dr["ProductUOM"].ToString()).Selected = true;
                    //DrpP1.SelectedItem.Text = obj.dr["ProductUOM"].ToString();
                }
                int rowIndex = 0;
                if (dt.Rows.Count <= 0)
                {
                    dt.Rows.Add();
                }
                ViewState["ProductCode1"] = dt;
                ProductCode2Grid1.DataSource = ViewState["ProductCode1"] as DataTable;
                ProductCode2Grid1.DataBind();
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
                        }
                        //ProductCode2Grid1.DataSource = dt;
                        //ProductCode2Grid1.DataBind();
                    }
                }
            }
        }

        private void editbindProduct3(string ID)
        {
            string strBindTxtBox = "select * from [InNonItemDtl] where Id=" + ID;
            obj.dr = obj.ret_dr(strBindTxtBox);
            while (obj.dr.Read())
            {
                SqlConnection con = new SqlConnection(sqlconn);
                //SqlCommand cmd1 = new SqlCommand("SELECT T1.Id ,T1.CRP,T1.CompanyName,T1.Name,T1.EmailId,T1.Mobile, T2.Name as Rent ,t1.BudgetFrom,T1.BudgetTo ,T3.Name as Type,T4.Name as Location,T5.PropertyRef,T1.MultipleLocation,T1. MultipleProperty  FROM (select a.Id,a.CompanyName,a.Name,a.EmailId,a.Mobile,a.BudgetFrom,a.BudgetTo,b.Name as CRP,a.MultipleLocation,a.MultipleProperty  from lead a,CommonMaster b where a.Per_Com=b.Id and a.TouchUser='" + Touch_user + "') AS T1 JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.RentorBuy=b.Id) AS T2    ON T1.Id = T2.Id    JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Type=b.Id) AS T3  ON T1.Id = T3.Id     JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Location=b.Id) AS T4   ON T1.Id = T4.Id    JOIN ( select b.ID,b.Name,a.PropertyRef  from Lead_List a,Lead b where a.ParentId=b.Id) AS T5   ON T1.Id = T5.Id order by T1.Id desc", con);
                //SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3 from InNonItemDtl a,INNONCASCDtl b where a.PermitId=b.PermitId and b.CASCId='Casc3' and a.PermitId='" + txt_code.Text + "'", con);
                SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3, Quantity , ProductCode from INNONCASCDtl  where CASCId='Casc3' and PermitId='" + txt_code.Text + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "' ORDER BY RowNumber asc", con);
                string ff = "select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3, Quantity , ProductCode,ProductUOM from INNONCASCDtl  where CASCId='Casc3' and PermitId='" + txt_code.Text + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "' ORDER BY RowNumber asc";
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                sda1.Fill(dt);
                ViewState["ProductCode3"] = dt;
                InnonPaymentClass objprc = new InnonPaymentClass();
                objprc.dr = objprc.ret_dr(ff);                
                if (objprc.dr.Read())
                {
                    TxtProQty3.Text = objprc.dr["Quantity"].ToString();
                    TxtProductCode3.Text = objprc.dr["ProductCode"].ToString();
                    DrpP3.ClearSelection();
                    DrpP3.Items.FindByText(objprc.dr["ProductUOM"].ToString()).Selected = true;
                    //DrpP3.SelectedItem.Text = obj.dr["ProductUOM"].ToString();
                }

                int rowIndex = 0;
                if (dt.Rows.Count <= 0)
                {
                    dt.Rows.Add();
                }
                ViewState["ProductCode1"] = dt;
                ProductCode3Grid1.DataSource = ViewState["ProductCode1"] as DataTable;
                ProductCode3Grid1.DataBind();
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
                        }
                        //ProductCode3Grid1.DataSource = dt;
                        //ProductCode3Grid1.DataBind();
                    }
                }
            }
        }

        private void editbindProduct4(string ID)
        {
            string strBindTxtBox = "select * from [InNonItemDtl] where Id=" + ID;
            obj.dr = obj.ret_dr(strBindTxtBox);
            while (obj.dr.Read())
            {
                SqlConnection con = new SqlConnection(sqlconn);
                //SqlCommand cmd1 = new SqlCommand("SELECT T1.Id ,T1.CRP,T1.CompanyName,T1.Name,T1.EmailId,T1.Mobile, T2.Name as Rent ,t1.BudgetFrom,T1.BudgetTo ,T3.Name as Type,T4.Name as Location,T5.PropertyRef,T1.MultipleLocation,T1. MultipleProperty  FROM (select a.Id,a.CompanyName,a.Name,a.EmailId,a.Mobile,a.BudgetFrom,a.BudgetTo,b.Name as CRP,a.MultipleLocation,a.MultipleProperty  from lead a,CommonMaster b where a.Per_Com=b.Id and a.TouchUser='" + Touch_user + "') AS T1 JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.RentorBuy=b.Id) AS T2    ON T1.Id = T2.Id    JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Type=b.Id) AS T3  ON T1.Id = T3.Id     JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Location=b.Id) AS T4   ON T1.Id = T4.Id    JOIN ( select b.ID,b.Name,a.PropertyRef  from Lead_List a,Lead b where a.ParentId=b.Id) AS T5   ON T1.Id = T5.Id order by T1.Id desc", con);
                //SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3 from InNonItemDtl a,INNONCASCDtl b where a.PermitId=b.PermitId and b.CASCId='Casc4' and a.PermitId='" + txt_code.Text + "'", con);
                SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3, Quantity , ProductCode from INNONCASCDtl  where CASCId='Casc4' and PermitId='" + txt_code.Text + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "' ORDER BY RowNumber asc", con);
                string ff = "select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3, Quantity , ProductCode,ProductUOM from INNONCASCDtl  where CASCId='Casc4' and PermitId='" + txt_code.Text + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "' ORDER BY RowNumber asc";
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                sda1.Fill(dt);
                ViewState["ProductCode4"] = dt;
                InnonPaymentClass objprc = new InnonPaymentClass();
                objprc.dr = objprc.ret_dr(ff);
                if (objprc.dr.Read())
                {
                    TxtProQty4.Text = objprc.dr["Quantity"].ToString();
                    TxtProductCode4.Text = objprc.dr["ProductCode"].ToString();
                    DrpP4.ClearSelection();
                    DrpP4.Items.FindByText(objprc.dr["ProductUOM"].ToString()).Selected = true;
                    //DrpP3.SelectedItem.Text = obj.dr["ProductUOM"].ToString();
                }

                int rowIndex = 0;
                if (dt.Rows.Count <= 0)
                {
                    dt.Rows.Add();
                }
                ViewState["ProductCode1"] = dt;
                ProductCode4Grid1.DataSource = ViewState["ProductCode1"] as DataTable;
                ProductCode4Grid1.DataBind();
                if (ViewState["ProductCode4"] != null)
                {
                    DataTable dt1 = (DataTable)ViewState["ProductCode4"];
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt1.Rows.Count; i++)
                        {
                            TextBox box1 = (TextBox)ProductCode4Grid1.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                            TextBox box2 = (TextBox)ProductCode4Grid1.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                            TextBox box3 = (TextBox)ProductCode4Grid1.Rows[rowIndex].Cells[3].FindControl("TextBox3");
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

        private void editbindProduct5(string ID)
        {
            string strBindTxtBox = "select * from [InNonItemDtl] where Id=" + ID;
            obj.dr = obj.ret_dr(strBindTxtBox);
            while (obj.dr.Read())
            {
                SqlConnection con = new SqlConnection(sqlconn);
                //SqlCommand cmd1 = new SqlCommand("SELECT T1.Id ,T1.CRP,T1.CompanyName,T1.Name,T1.EmailId,T1.Mobile, T2.Name as Rent ,t1.BudgetFrom,T1.BudgetTo ,T3.Name as Type,T4.Name as Location,T5.PropertyRef,T1.MultipleLocation,T1. MultipleProperty  FROM (select a.Id,a.CompanyName,a.Name,a.EmailId,a.Mobile,a.BudgetFrom,a.BudgetTo,b.Name as CRP,a.MultipleLocation,a.MultipleProperty  from lead a,CommonMaster b where a.Per_Com=b.Id and a.TouchUser='" + Touch_user + "') AS T1 JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.RentorBuy=b.Id) AS T2    ON T1.Id = T2.Id    JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Type=b.Id) AS T3  ON T1.Id = T3.Id     JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Location=b.Id) AS T4   ON T1.Id = T4.Id    JOIN ( select b.ID,b.Name,a.PropertyRef  from Lead_List a,Lead b where a.ParentId=b.Id) AS T5   ON T1.Id = T5.Id order by T1.Id desc", con);
                //SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3 from InNonItemDtl a,INNONCASCDtl b where a.PermitId=b.PermitId and b.CASCId='Casc5' and a.PermitId='" + txt_code.Text + "'", con);
                SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3, Quantity , ProductCode from INNONCASCDtl  where CASCId='Casc5' and PermitId='" + txt_code.Text + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "' ORDER BY RowNumber asc", con);
                string ff = "select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3, Quantity , ProductCode,ProductUOM from INNONCASCDtl  where CASCId='Casc5' and PermitId='" + txt_code.Text + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "' ORDER BY RowNumber asc";
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                sda1.Fill(dt);
                ViewState["ProductCode5"] = dt;
                InnonPaymentClass objprc = new InnonPaymentClass();
                objprc.dr = objprc.ret_dr(ff);
                if (objprc.dr.Read())
                {
                    TxtProQty5.Text = objprc.dr["Quantity"].ToString();
                    TxtProductCode5.Text = objprc.dr["ProductCode"].ToString();
                    DrpP5.ClearSelection();
                    DrpP5.Items.FindByText(objprc.dr["ProductUOM"].ToString()).Selected = true;
                    //DrpP3.SelectedItem.Text = obj.dr["ProductUOM"].ToString();
                }

                int rowIndex = 0;
                if (dt.Rows.Count <= 0)
                {
                    dt.Rows.Add();
                }
                ViewState["ProductCode1"] = dt;
                ProductCode5Grid1.DataSource = ViewState["ProductCode1"] as DataTable;
                ProductCode5Grid1.DataBind();
                if (ViewState["ProductCode5"] != null)
                {
                    DataTable dt1 = (DataTable)ViewState["ProductCode5"];
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt1.Rows.Count; i++)
                        {
                            TextBox box1 = (TextBox)ProductCode5Grid1.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                            TextBox box2 = (TextBox)ProductCode5Grid1.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                            TextBox box3 = (TextBox)ProductCode5Grid1.Rows[rowIndex].Cells[3].FindControl("TextBox3");
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
            DrpTerms.Items.FindByText("--Select--").Selected = true;            
            DrpSupImpRel.ClearSelection();
            DrpSupImpRel.Items.FindByText("--Select--").Selected = true;            
            txtcodeinvq.Text = "";
            //  TxtImppartyCode.Text = "";

            Drpcurrency1.ClearSelection();
            Drpcurrency1.Items.FindByText("--Select--").Selected = true;            
            LblTotalInvoice.Text = "0.00";
            TxtTotalInvoice.Text = "0.00";
            SumTotalInvoice.Text = "0.00";
            OtherTaxableChargePer.Text = "0.00";
            Drpcurrency2.ClearSelection();
            Drpcurrency2.Items.FindByText("--Select--").Selected = true;            
            lblOtherTaxableCharge.Text = "0.00";
            TxtOtherTaxableCharge.Text = "0.00";
            SumOtherTaxableCharge.Text = "0.00";
            FrieghtChargesPer.Text = "0.00";

            Drpcurrency3.ClearSelection();
            Drpcurrency3.Items.FindByText("--Select--").Selected = true;            
            LblFrieghtCharges.Text = "0.00";
            TxtFrieghtCharges.Text = "0.00";
            SumFrieghtCharges.Text = "0.00";
            InsuranceChargesPer.Text = "0.00";
            Drpcurrency4.ClearSelection();
            Drpcurrency4.Items.FindByText("--Select--").Selected = true;            
            lblInsuranceCharges.Text = "0.00";
            TxtInsuranceCharges.Text = "0.00";
            SumInsuranceCharges.Text = "0.00";
            FrieghtChargesPer.Text = "0.00";
            Drpcurrency3.ClearSelection();
            Drpcurrency3.Items.FindByText("--Select--").Selected = true;            
            LblFrieghtCharges.Text = "0.00";
            TxtFrieghtCharges.Text = "0.00";
            SumFrieghtCharges.Text = "0.00";
            InsuranceChargesPer.Text = "0.00";            
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
            lblhserror.Text = "";
            lbldhserror.Text = "";
            lbldhserror.Visible = false;
            lblhserror.Visible = false;            
            //txtExStartDate.Text = "";
            //txtExEndDate.Text = "";
            TDQUOM.ClearSelection();
            TDQUOM.Items.FindByText("--Select--").Selected = true;
            lblhserror.Visible = false;           
            ddptotDutiableQty.ClearSelection();
            ddptotDutiableQty.Items.FindByText("--Select--").Selected = true;
            TxtProQty1.Text = "0.0000";
            TxtProQty2.Text = "0.0000";
            TxtProQty3.Text = "0.0000";
            TxtProQty4.Text = "0.0000";
            TxtProQty5.Text = "0.0000";
            ChkBGIndicator.Checked = false;
            DrpInvoiceNo.ClearSelection();
            DrpInvoiceNo.Items.FindByText("--Select--").Selected = true;            
            TxtHSCodeItem.Text = "";
            DRPCurrency.ClearSelection();
            DRPCurrency.Items.FindByText("--Select--").Selected = true;
            txtlsp.Text = "0.00";            
            TxtDescription.Text = "";
            TxtCountryItem.Text = "";
            txtcname.Text = "";
            ChkUnbrand.Checked = false;
            TxtBrand.Text = "";
            TxtModel.Text = "";
            DRPOPQUOM.ClearSelection();
            DRPOPQUOM.Items.FindByText("--Select--").Selected = true;            
            txtAlcoholPer.Text = "0.00";
            txtorgindate.Text = "";
            txttotDutiableQty.Text = "0.00";
            DrpVehicleType.ClearSelection();
            DrpVehicleType.Items.FindByText("--Select--").Selected = true;                      
            TxtTotalDutiableQuantity.Text = "0.00";
            TxtInvQty.Text = "0.00";
            txtengine.Text = "0.00";
            TxtHSQuantity.Text = "0.00";
            HSQTYUOM.ClearSelection();
            HSQTYUOM.Items.FindByText("--Select--").Selected = true;            
            TxtUnitPrice.Text = "0.00";
            TxtExchangeRate.Text = "0.00";
            TxtSumExRate.Text = "0.00";
            TxtTotalLineAmount.Text = "0.00";
            Drpcurrency4.ClearSelection();
            Drpcurrency4.Items.FindByText("--Select--").Selected = true;            
            TxtTotalLineCharges.Text = "0.00";
            TxtCIFFOB.Text = "0.00";
            TxtOPQty.Text = "0.00";
            TxtIPQty.Text = "0.00";
            Drpcurrency3.ClearSelection();
            Drpcurrency3.Items.FindByText("--Select--").Selected = true;            
            DRPIPQUOM.ClearSelection();
            DRPIPQUOM.Items.FindByText("--Select--").Selected = true;            
            TxtINPQty.Text = "0.00";
            TxtINPQty.Text = "0.00";
            TxtIMPQty.Text = "0.00";
            ItemGSTRate.Text = "9";
            DRPINNPQUOM.ClearSelection();
            DRPINNPQUOM.Items.FindByText("--Select--").Selected = true;            
            DRPIMPQUOM.ClearSelection();
            DRPIMPQUOM.Items.FindByText("--Select--").Selected = true;            
            DrpPreferentialCode.ClearSelection();
            DrpPreferentialCode.Items.FindByText("--Select--").Selected = true;            
            ItemGSTUOM.Text = "PER";
            txtAlcoholPer.Text = "0.00";
            TxtItemSumGST.Text = "0.00";
            TxtExciseDutyRate.Text = "0.00";            
            TxtSumExciseDuty.Text = "0.00";
            TxtCustomsDutyRate.Text = "0.00";            
            TxtSumCustomsDuty.Text = "0.00";
            DrpOtherUOM.ClearSelection();
            DrpOtherUOM.Items.FindByText("--Select--").Selected = true;            
            DrpMaking.ClearSelection();
            DrpMaking.Items.FindByText("--Select--").Selected = true;            
            TxtProductCode1.Text = "";
            TxtProductCode1.Text = "";
            DrpOptionalUom.ClearSelection();
            DrpOptionalUom.Items.FindByText("--Select--").Selected = true;
            TxtOptionalPrice.Text = "0.00";
            TxtOptionalExchageRate.Text = "0.00";
            TxtOptionalSumExRate.Text = "0.00";
            DrpP1.ClearSelection();
            DrpP1.Items.FindByText("--Select--").Selected = true;
            ProductCode1();
            TxtProductCode2.Text = "";
            TxtProductCode1.Text = "";
            DrpP2.ClearSelection();
            DrpP2.Items.FindByText("--Select--").Selected = true;
            ProductCode2();
            TxtProductCode3.Text = "";
            TxtProductCode3.Text = "";
            DrpP3.ClearSelection();
            DrpP3.Items.FindByText("--Select--").Selected = true;
            ProductCode3();
            TxtProductCode4.Text = "";
            TxtProductCode4.Text = "";
            DrpP4.ClearSelection();
            DrpP4.Items.FindByText("--Select--").Selected = true;
            ProductCode4();
            TxtProductCode5.Text = "";
            TxtProductCode5.Text = "";
            DrpP5.ClearSelection();
            DrpP5.Items.FindByText("--Select--").Selected = true;
            ProductCode5();
            TxtOtherTaxRate.Text = "0.00";
            TxtSumOtherTaxRate.Text = "0.00";
            TxtCurrentLot.Text = "";
            TxtPreviousLot.Text = "";
            txtShippingMarks1.Text = "";
            txtShippingMarks2.Text = "";
            txtShippingMarks3.Text = "";
            lblhserror.Visible = false;
            TxtHSCodeItem_TextChanged(null,null);
            txtShippingMarks4.Text = "";
            TxtIPQty.Text = "0.00";
            DRPIPQUOM.ClearSelection();
            DRPIPQUOM.Items.FindByText("--Select--").Selected = true;
            TxtOptionalSumExRate.Text = "0.00";
            txttotDutiableQty.Text = "0.00";
            ddptotDutiableQty.ClearSelection();
            ddptotDutiableQty.Items.FindByText("--Select--").Selected = true;
            DrpVehicleType.ClearSelection();
            DrpVehicleType.Items.FindByText("--Select--").Selected = true;
            DrpOptionalUom.ClearSelection();
            DrpOptionalUom.Items.FindByText("--Select--").Selected = true;
            txtengine.Text = "0.00";
            TxtOptionalPrice.Text = "0.00";
            TxtOptionalExchageRate.Text = "0.00";
            TxtOptionalSumExRate.Text = "0.00";
            DrpVehicleCapacity.ClearSelection();
            DrpVehicleCapacity.Items.FindByText("--Select--").Selected = true;
            txtorgindate.Text = "";
            ItemNO();
        }

        protected void AddItemGrid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TxtInHouseItem_TextChanged(object sender, EventArgs e)
        {
            if (TxtInHouseItem.Text != "")
            {
                string qry11 = "select Top 1 * from InhouseItemCode where InhouseCode='" + TxtInHouseItem.Text + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    TxtInHouseItem.Text = obj.dr[1].ToString();
                    TxtHSCodeItem.Text = obj.dr[2].ToString();
                    TxtDescription.Text = obj.dr[3].ToString();
                }
            }
            TxtHSCodeItem.Focus();
        }

        protected void GridCancelDoc_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridCancelDoc.DataKeys[e.RowIndex].Value.ToString();
            string strDelete = "delete from InNonFile where Id='" + id + "' ";
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
                SqlCommand cmd = new SqlCommand("DELETE FROM InNoncANFile where ID=" + employeeId, con);
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
            //int infi = 1;
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
                            string query = "insert into InNoncANFile values (@Name, @ContentType, @Data,@DocumentType,@InPaymentId,@TouchUser,@TouchTime)";
                            using (SqlCommand cmd = new SqlCommand(query))
                            {

                                cmd.Connection = con;
                               // cmd.Parameters.AddWithValue("@Sno", infi);
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
              //  infi++;
            }
        }

        protected void DrpCargoPackType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string TransMode = DrpCargoPackType.SelectedItem.ToString();
            if (DrpCargoPackType.SelectedItem.ToString() != "--Select--")
            {

                if (TransMode == "9: Containerized")
                {
                    ContainerDetails.Visible = true;
                }
                else
                {
                    ContainerDetails.Visible = false;
                }
            }
            else
            {
                ContainerDetails.Visible = false;
            }
            upinnoncargo.Update();
            innonpayment.Update();
            if (DrpInwardtrasMode.Visible == true)
            {
                DrpInwardtrasMode.Focus();
            }
            else if (DrpOutwardtrasMode.Visible == true)
            {
                DrpOutwardtrasMode.Focus();
            }
            else
            {
                DrpBGIndicator.Focus();
            }
        }

        protected void txtstrgeloc_TextChanged(object sender, EventArgs e)
        {
            if (txtstrgeloc.Text != "")
            {
                string[] ss = txtstrgeloc.Text.Split(':');
                string qry11 = "select Top 1 * from StorageLocation where Code='" + ss[0].ToString() + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    txtstrgeloc.Text = obj.dr[2].ToString();
                    txtstrgelocdet.Text = obj.dr[3].ToString();
                }
            }
            else
            {
                txtstrgeloc.Text = "";
                txtstrgelocdet.Text = "";
            }
            if (DrpInwardtrasMode.Text.ToString().ToUpper() == "N : NOT REQUIRED")
            {
                btnprevcargo.Focus();
            }
            else
            {
                TxtArrivalDate1.Focus();
            }
        }

        protected void TxtInvQty_TextChanged(object sender, EventArgs e)
        {
            string qry11 = "select Top 1 UOM from HSCode where HSCode='" + TxtHSCodeItem.Text + "'";
            obj.dr = obj.ret_dr(qry11);
            while (obj.dr.Read())
            {
                string UOm = obj.dr[0].ToString();
                if (UOm == "TEN")
                {
                    //warning
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
                else if (UOm == "KGM")
                {
                    TxtHSQuantity.Text = TxtInvQty.Text;
                }
                else if (UOm == "LTR")
                {
                    double a;
                    bool isAValid = double.TryParse(TxtInvQty.Text.Trim(), out a);

                    if (isAValid)
                        TxtHSQuantity.Text = (a * 1.25).ToString("F6");
                }
                else if (UOm == "NMB" || UOm == "-")
                {
                    double a;
                    bool ss;
                    bool isAValid = double.TryParse(TxtInvQty.Text.Trim(), out a);

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
                            lblhserror.Text = "Please Check Net Weight & Gross Weight";                            
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

        protected void TxtHAWB_TextChanged(object sender, EventArgs e)
        {            
            TxtInHouseItem.Focus();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TxtProQty1.Text = TxtHSQuantity.Text;
          //  DrpP1.ClearSelection();
          //  DrpP1.Items.FindByText(HSQTYUOM.SelectedItem.ToString()).Selected = true;
            //DrpP1.Text = HSQTYUOM.SelectedItem.ToString();
        }


        private void BindClaimant()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Top 20 Id,Name,Name1,Name2,CRUEI,ClaimantName,ClaimantName1 FROM InnonClaimantParty"))
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
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalClaimant();", true);
            }
        }

        protected void ClaimantGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ClaimantGrid.PageIndex = e.NewPageIndex;
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalClaimant();", true);
            popupinnonclaimant.Show();
            popupinnonclaimant.X = 400;
            popupinnonclaimant.Y = 100;
            BindClaimant();
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
        }

        protected void ClaimantName_TextChanged(object sender, EventArgs e)
        {
            if (ClaimantName.Text != "")
            {
                string[] ss = ClaimantName.Text.Split(':');
                string qry11 = "select Top 1 * from InnonClaimantParty where Name='" + ss[0].ToString() + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
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
        public DataTable GetClaimantDataFromDataBase(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = searchtext;

            string str3 = "SELECT Top 5 Id,Name,Name1,Name2,CRUEI,ClaimantName,ClaimantName1 FROM InnonClaimantParty where Name Like '%" + a + "%' or Name1 Like '%" + a + "%' order by Id desc";
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
        protected void ClaimantAdd_Click(object sender, EventArgs e)
        {
            string Code = "";
            string qry11 = "SELECT Name FROM InnonClaimantParty where Name='" + ClaimantName.Text + "'";

            obj.dr = obj.ret_dr(qry11);

            while (obj.dr.Read())
            {
                Code = obj.dr[0].ToString();

            }
            if (Code == "")
            {
                string Touch_user = Session["UserId"].ToString();

                string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string StrQuery = ("INSERT INTO [dbo].[InnonClaimantParty] ([Name],[Name1],[Name2],[CRUEI],[ClaimantName],[ClaimantName1],[TouchUser],[TouchTime]) VALUES ('" + ClaimantName.Text + "','" + ClaimantName1.Text + "','"+ClaimantName2.Text+"','" + ClaimantCRUEI.Text + "','" + ClaimantNameC.Text + "','" + ClaimantName1C.Text + "','" + Touch_user + "',Convert(VARCHAR,'" + strTime + "',108))");
                obj.exec(StrQuery);
                BindClaimant();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : Data Saved Successfully');", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The ClaimantParty Name Already Exist...');", true);
                // Response.Write("The FreightForwarder Code Already Exist..");
            }
            btnpreviousparty.Focus();
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



            TxtLoadShort.Focus();
        }

        protected void txtinvDate1_TextChanged(object sender, EventArgs e)
        {
            txtinvDate1.Text = DateCheck(txtinvDate1.Text);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            InvoiceGrid.Visible = true;
            InvoiceDiv.Visible = true;
            //NewInvoice.Visible = true;
        }
        private void SummaryCalculate()
        {
            AddDynamicLabels();
            AddDynamicItem();
            string SumInv = "";
            string qry11 = "select Count(InvoiceNo) as InvCount from dbo.InNonInvoiceDtl where PermitId='" + txt_code.Text + "' and MessageType='INPDEC'";
            obj.dr = obj.ret_dr(qry11);
            while (obj.dr.Read())
            {
                SumInv = obj.dr[0].ToString();
                txtnoofinv.Text = SumInv;
            }
            //SUM OF ITEM
            string SumItem = "";
            string qry112 = "select Count(ItemNo) as ItemCount from dbo.InNonItemDtl where PermitId='" + txt_code.Text + "' and MessageType='INPDEC'";
            obj.dr = obj.ret_dr(qry112);
            while (obj.dr.Read())
            {
                SumItem = obj.dr[0].ToString();
                txtnoofitm.Text = SumItem;
            }

            ///Total Invoice CIF Value
            string InvoiceCIFValue = "";
            string qry112Q = "select sum(CIFSUMAmount) as InNonInvoiceDtl from dbo.InNonInvoiceDtl where PermitId='" + txt_code.Text + "' and MessageType='INPDEC'";
            obj.dr = obj.ret_dr(qry112Q);
            while (obj.dr.Read())
            {
                InvoiceCIFValue = obj.dr[0].ToString();
                txtcifVal.Text = InvoiceCIFValue;
            }

            //Sum of Item Amount

            string SumofItemAmount = "";
            string qry11s2Q = "select SUM(TotalLineAmount) as  TotalLineAmount  from dbo.InNonItemDtl where PermitId='" + txt_code.Text + "' and MessageType='INPDEC'";
            obj.dr = obj.ret_dr(qry11s2Q);
            while (obj.dr.Read())
            {
                SumofItemAmount = obj.dr[0].ToString();
                txtitmAmt.Text = SumofItemAmount;
            }
            //TotalGSTAmount
            string TotalGSTAmount = "";
            string qry11s2 = "select SUM(GSTAmount) as  GSTAmount  from dbo.InNonItemDtl where PermitId='" + txt_code.Text + "' and MessageType='INPDEC'";
            obj.dr = obj.ret_dr(qry11s2);
            while (obj.dr.Read())
            {
                TotalGSTAmount = obj.dr[0].ToString();
                txttotgstAmt.Text = TotalGSTAmount;
                txtAmtPayble.Text = "0.00";
            }
            lblTotItemGst.Text = txttotgstAmt.Text;
            //Total CIF/FOB Value
            string TotalCIFFOBValue = "";
            string qry11sS2 = "select SUM(CIFFOB) as  GSTAmount  from dbo.InNonItemDtl where PermitId='" + txt_code.Text + "' and MessageType='INPDEC'";
            obj.dr = obj.ret_dr(qry11sS2);
            while (obj.dr.Read())
            {
                TotalCIFFOBValue = obj.dr[0].ToString();
                txtfobval.Text = TotalCIFFOBValue;

            }
            string totalexamt = "";
            string examt = "select SUM(ExciseDutyAmount) as  ExciseDutyAmount  from dbo.InNonItemDtl where PermitId='" + txt_code.Text + "' and MessageType='INPDEC'";
            obj.dr = obj.ret_dr(examt);
            while (obj.dr.Read())
            {
                totalexamt = obj.dr[0].ToString();
                txttotexAmt.Text = totalexamt;

            }
            string totalcusamt = "";
            string cusamt = "select SUM(CustomsDutyAmount) as  CustomsDutyAmount  from dbo.InNonItemDtl where PermitId='" + txt_code.Text + "' and MessageType='INPDEC'";
            obj.dr = obj.ret_dr(cusamt);
            while (obj.dr.Read())
            {
                totalcusamt = obj.dr[0].ToString();
                txtcusdutyAmt.Text = totalcusamt;

            }
            string totalotheramt = "";
            string otheramt = "select SUM(OtherTaxAmount) as  OtherTaxAmount  from dbo.InNonItemDtl where PermitId='" + txt_code.Text + "' and MessageType='INPDEC'";
            obj.dr = obj.ret_dr(otheramt);
            while (obj.dr.Read())
            {
                totalotheramt = obj.dr[0].ToString();
                txtothtaxAmt.Text = totalotheramt;

            }
        }
        protected void ChkPackInfo_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkPackInfo.Checked == true)
            {
                PackingInfo.Visible = true;
            }
            else
            {
                PackingInfo.Visible = true;
            }
            TxtOPQty.Focus();
        }
        protected void Chkitemcasc_CheckedChanged(object sender, EventArgs e)
        {
            if (Chkitemcasc.Checked == true)
            {
                //ItemCASC.Visible = true;
            }
            else
            {
                //ItemCASC.Visible = false;
            }
            TxtProductCode1.Focus();
        }
        protected void ChkTariff_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkTariff.Checked == true)
            {
                Tariff.Visible = true;
            }
            else
            {
                Tariff.Visible = false;
            }

            chk234.Focus();

        }
        protected void Chklot_CheckedChanged(object sender, EventArgs e)
        {
            if (Chklot.Checked == true)
            {
                LOTID.Visible = true;
            }
            else
            {
                LOTID.Visible = true;
            }
            TxtCurrentLot.Focus();
        }

        protected void txthblCargo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txthblCargo.Text))
            {

                txthblCargo.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                TxtHAWB.Items.Clear();
                string[] hblvalue = txthblCargo.Text.Split(',');
                for (int i = 0; i < hblvalue.Length; i++)
                {
                    TxtHAWB.Items.Add(hblvalue[i].ToString());
                }
                lblhblValue.Text = txthblCargo.Text;
            }
            upinnonitem.Update();
            innonpayment.Update();
            upinnonsummary.Update();

        }

        protected void txtouthblCargo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtouthblCargo.Text))
            {
                txtOutHAWB1.Items.Clear();
                string[] hblvalue = txtouthblCargo.Text.Split(',');
                for (int i = 0; i < hblvalue.Length; i++)
                {
                    txtOutHAWB1.Items.Add(hblvalue[i].ToString());
                }
                Lblouthblhawb.Text = txtouthblCargo.Text;
            }
            upinnonitem.Update();
            innonpayment.Update();
            upinnonsummary.Update();
        }

        protected void TxttotalOuterPack_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxttotalOuterPack.Text))
            {
                lblnoofpack.Text = TxttotalOuterPack.Text + " " + DrptotalOuterPack.SelectedItem.ToString();
            }
            upinnonsummary.Update();
            upinnonparty.Update();
            innonpayment.Update();
            DrptotalOuterPack.Focus();

        }

        protected void DrptotalOuterPack_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblnoofpack.Text = TxttotalOuterPack.Text + " " + DrptotalOuterPack.SelectedItem.ToString();
            upinnonsummary.Update();
            upinnonparty.Update();
            innonpayment.Update();
            TxtTotalGrossWeight.Focus();
        }       

        protected void DrpTotalGrossWeight_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblgrossweight.Text = TxtTotalGrossWeight.Text + " " + DrpTotalGrossWeight.SelectedItem.ToString();

            if (DrpTotalGrossWeight.SelectedItem.ToString() == "KGM")
            {
                txtTtlPGW.Text = TxtTotalGrossWeight.Text;

                DrpTtlPGW.ClearSelection();
                DrpTtlPGW.Items.FindByText("KGM").Selected = true;

            }
            else
            {
                decimal TtlPGW = Convert.ToDecimal(TxtTotalGrossWeight.Text) / Convert.ToDecimal(1000);
                txtTtlPGW.Text = Convert.ToString(Math.Round(TtlPGW, 3));
                DrpTtlPGW.ClearSelection();
                DrpTtlPGW.Items.FindByText("TNE").Selected = true;

            }


            if (DrpCargoPackType.SelectedItem.Text == "9 : Containerized")
            {

            }
            else
            {
                txtreLoctn.Focus();
            }
            upinnonsummary.Update();
            upinnonparty.Update();            
            innonpayment.Update();
        }

        protected void TxtExpArrivalDate1_TextChanged(object sender, EventArgs e)
        {
            TxtExpArrivalDate1.Text = DateCheck(TxtExpArrivalDate1.Text);
            DateTime arrivalDate = Convert.ToDateTime(TxtExpArrivalDate1.Text);
            if (arrivalDate.Date < DateTime.Today)
            {
                alertdeparture.Visible = true;
                alertdeparture.Text = "Departure date is in the past. Please check.";
            }
            else
            {
                alertdeparture.Visible = false;
                alertdeparture.Text = "";

            }

            TxtExpLoadShort.Focus();
        }

        protected void btninvnum_Click(object sender, EventArgs e)
        {
            string sent = "Invoice Number :";

            txttrdremrk.Text = Environment.NewLine + sent;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            InnonPaymentClass curobj = new InnonPaymentClass();
            curobj.dr = curobj.ret_dr("select Distinct TICurrency,TIExRate from InNonInvoiceDtl where  MessageType='INPDEC' AND PermitId='" + txt_code.Text + "'");
            while (curobj.dr.Read())
            {
                txttrdremrk.Text = txttrdremrk.Text + " " + curobj.dr["TICurrency"].ToString() + " : " + curobj.dr["TIExRate"].ToString() + Environment.NewLine;
            }            
        }

        protected void BtnHSQty2_Click(object sender, EventArgs e)
        {
            TxtProQty2.Text = TxtHSQuantity.Text;
            DrpP2.ClearSelection();
            DrpP2.Items.FindByText(HSQTYUOM.SelectedItem.ToString()).Selected = true;
        }

        protected void BtnHSQty3_Click(object sender, EventArgs e)
        {
            TxtProQty3.Text = TxtHSQuantity.Text;
            DrpP3.ClearSelection();
            DrpP3.Items.FindByText(HSQTYUOM.SelectedItem.ToString()).Selected = true;            
        }

        protected void TxtOPQty_TextChanged(object sender, EventArgs e)
        {
            if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
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
            }
            DRPOPQUOM.Focus();
                        
        }

        protected void TxtIPQty_TextChanged(object sender, EventArgs e)
        {
            if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
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
        }

        protected void TxtINPQty_TextChanged(object sender, EventArgs e)
        {
            if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
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
            }
        }

        protected void TxtIMPQty_TextChanged(object sender, EventArgs e)
        {
            if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
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
                                innonpayment.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                innonpayment.Update();
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
                                innonpayment.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                innonpayment.Update();
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
                                innonpayment.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                innonpayment.Update();
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
                                innonpayment.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                innonpayment.Update();
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
                        T4 = (T2 * 0.09) + (T3 * 0.09);
                        TxtItemSumGST.Text = T4.ToString();
                    }
                    else if (TDQUOM.SelectedItem.Text == "KGM" && kgmvis == "DIVIDE")
                    {
                        txttotDutiableQty.Text = ((op * ip * totduti) / 1000).ToString();
                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {
                            TxtSumExciseDuty.Text = (((op * ip * totduti) / 1000) * (T1)).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);
                        T4 = (T2 * 0.09) + (T3 * 0.09);
                        TxtItemSumGST.Text = T4.ToString();
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
                        T4 = (T2 * 0.09) + (T3 * 0.09);
                        TxtItemSumGST.Text = T4.ToString();
                    }
                    else if (TDQUOM.SelectedItem.Text == "KGM" && typeidval == 62)
                    {
                        txttotDutiableQty.Text = ((op * ip * totduti)).ToString();
                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {
                            TxtSumExciseDuty.Text = (((op * ip * totduti)) * (T1)).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);
                        T4 = (T2 * 0.09) + (T3 * 0.09);
                        TxtItemSumGST.Text = T4.ToString();
                    }

                    else if (TDQUOM.SelectedItem.Text == "TNE" && typeidval == 62)
                    {
                        txttotDutiableQty.Text = ((op * ip * totduti)).ToString();
                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {
                            TxtSumExciseDuty.Text = (((op * ip * totduti)) * (T1)).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);
                        T4 = (T2 * 0.09) + (T3 * 0.09);
                        TxtItemSumGST.Text = T4.ToString();
                    }
                    else if (TDQUOM.SelectedItem.Text == "DAL")
                    {
                        txttotDutiableQty.Text = ((op * ip * totduti)).ToString();
                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {
                            TxtSumExciseDuty.Text = (((op * ip * totduti)) * (T1)).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);
                        T4 = (T2 * 0.09) + (T3 * 0.09);
                        TxtItemSumGST.Text = T4.ToString();
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
                                innonpayment.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                innonpayment.Update();
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
                                innonpayment.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                innonpayment.Update();
                            }
                        }

                    }
                    else if (TDQUOM.SelectedItem.Text == "KGM" && typeidval == 105)
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
                                innonpayment.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                innonpayment.Update();
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
                                innonpayment.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                innonpayment.Update();
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
                        T4 = (T2 * 0.09) + (T3 * 0.09);
                        TxtItemSumGST.Text = T4.ToString();
                    }
                    else if (TDQUOM.SelectedItem.Text == "KGM" && kgmvis == "DIVIDE")
                    {
                        txttotDutiableQty.Text = ((op * totduti) / 1000).ToString();
                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {
                            TxtSumExciseDuty.Text = (((op * totduti) / 1000) * (T1)).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);
                        T4 = (T2 * 0.09) + (T3 * 0.09);
                        TxtItemSumGST.Text = T4.ToString();
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
                        T4 = (T2 * 0.09) + (T3 * 0.09);
                        TxtItemSumGST.Text = T4.ToString();
                    }
                    else if (TDQUOM.SelectedItem.Text == "KGM" && typeidval == 62)
                    {
                        txttotDutiableQty.Text = ((op * totduti)).ToString();
                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {
                            TxtSumExciseDuty.Text = (((op * totduti)) * (T1)).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);
                        T4 = (T2 * 0.09) + (T3 * 0.09);
                        TxtItemSumGST.Text = T4.ToString();
                    }
                    else if (TDQUOM.SelectedItem.Text == "TNE" && typeidval == 62)
                    {
                        txttotDutiableQty.Text = ((op * totduti)).ToString();
                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {
                            TxtSumExciseDuty.Text = (((op * totduti)) * (T1)).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);
                        T4 = (T2 * 0.09) + (T3 * 0.09);
                        TxtItemSumGST.Text = T4.ToString();
                    }
                    else if (TDQUOM.SelectedItem.Text == "DAL")
                    {
                        txttotDutiableQty.Text = ((op * totduti)).ToString();
                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {
                            TxtSumExciseDuty.Text = (((op * totduti)) * (T1)).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);
                        T4 = (T2 * 0.09) + (T3 * 0.09);
                        TxtItemSumGST.Text = T4.ToString();
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
                            txttotDutiableQty.Text = Math.Round(Convert.ToDecimal(((op * ip * inp * totduti))), 2).ToString();
                        }
                        else
                        {
                            txttotDutiableQty.Text = Math.Round(Convert.ToDecimal(((op * ip * inp * totduti))) / Convert.ToDecimal(1000), 2).ToString();
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
                                innonpayment.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                innonpayment.Update();
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
                                innonpayment.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                innonpayment.Update();
                            }
                        }

                    }
                    else if (TDQUOM.SelectedItem.Text == "KGM" && typeidval == 105)
                    {

                        if (TxtHSCodeItem.Text == "21069020" || TxtHSCodeItem.Text == "21069062" || TxtHSCodeItem.Text == "21069065" || TxtHSCodeItem.Text == "21069067" || TxtHSCodeItem.Text == "24012010" || TxtHSCodeItem.Text == "24012090" || TxtHSCodeItem.Text == "24031190" || TxtHSCodeItem.Text == "24031919" || TxtHSCodeItem.Text == "24031920" || TxtHSCodeItem.Text == "24031991" || TxtHSCodeItem.Text == "24031999" || TxtHSCodeItem.Text == "24039110" || TxtHSCodeItem.Text == "24039190" || TxtHSCodeItem.Text == "24039930" || TxtHSCodeItem.Text == "24039990" || TxtHSCodeItem.Text == "24041100" || TxtHSCodeItem.Text == "27112110" || TxtHSCodeItem.Text == "33021020")
                        {
                            txttotDutiableQty.Text = Math.Round(Convert.ToDecimal(((op * ip * inp * totduti))), 2).ToString();
                        }
                        else
                        {
                            txttotDutiableQty.Text = Math.Round(Convert.ToDecimal(((op * ip * inp * totduti))) / Convert.ToDecimal(1000), 2).ToString();
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
                                innonpayment.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                innonpayment.Update();
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
                                innonpayment.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                innonpayment.Update();
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
                        T4 = (T2 * 0.09) + (T3 * 0.09);
                        TxtItemSumGST.Text = T4.ToString();
                    }
                    else if (TDQUOM.SelectedItem.Text == "KGM" && kgmvis == "DIVIDE")
                    {
                        txttotDutiableQty.Text = ((op * ip * inp * imp * totduti) / 1000).ToString();
                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {
                            TxtSumExciseDuty.Text = (((op * ip * inp * imp * totduti) / 1000) * (T1)).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);
                        T4 = (T2 * 0.09) + (T3 * 0.09);
                        TxtItemSumGST.Text = T4.ToString();
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
                        T4 = (T2 * 0.09) + (T3 * 0.09);
                        TxtItemSumGST.Text = T4.ToString();
                    }
                    else if (TDQUOM.SelectedItem.Text == "KGM" && typeidval == 62)
                    {
                        txttotDutiableQty.Text = ((op * ip * inp * imp * totduti)).ToString();
                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {
                            TxtSumExciseDuty.Text = (((op * ip * inp * imp * totduti)) * (T1)).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);
                        T4 = (T2 * 0.09) + (T3 * 0.09);
                        TxtItemSumGST.Text = T4.ToString();
                    }
                    else if (TDQUOM.SelectedItem.Text == "TNE" && typeidval == 62)
                    {
                        txttotDutiableQty.Text = ((op * ip * inp * imp * totduti)).ToString();
                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {
                            TxtSumExciseDuty.Text = (((op * ip * inp * imp * totduti)) * (T1)).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);
                        T4 = (T2 * 0.09) + (T3 * 0.09);
                        TxtItemSumGST.Text = T4.ToString();
                    }
                    else if (TDQUOM.SelectedItem.Text == "DAL")
                    {
                        txttotDutiableQty.Text = ((op * ip * inp * imp * totduti)).ToString();
                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {
                            TxtSumExciseDuty.Text = (((op * ip * inp * imp * totduti)) * (T1)).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);
                        T4 = (T2 * 0.09) + (T3 * 0.09);
                        TxtItemSumGST.Text = T4.ToString();
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
                            txttotDutiableQty.Text = Math.Round(Convert.ToDecimal(((op * ip * inp * totduti))) / Convert.ToDecimal(1000), 2).ToString();
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
                                innonpayment.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                innonpayment.Update();
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
                                innonpayment.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                innonpayment.Update();
                            }
                        }

                    }
                    else if (TDQUOM.SelectedItem.Text == "KGM" && typeidval == 105)
                    {

                        if (TxtHSCodeItem.Text == "21069020" || TxtHSCodeItem.Text == "21069062" || TxtHSCodeItem.Text == "21069065" || TxtHSCodeItem.Text == "21069067" || TxtHSCodeItem.Text == "24012010" || TxtHSCodeItem.Text == "24012090" || TxtHSCodeItem.Text == "24031190" || TxtHSCodeItem.Text == "24031919" || TxtHSCodeItem.Text == "24031920" || TxtHSCodeItem.Text == "24031991" || TxtHSCodeItem.Text == "24031999" || TxtHSCodeItem.Text == "24039110" || TxtHSCodeItem.Text == "24039190" || TxtHSCodeItem.Text == "24039930" || TxtHSCodeItem.Text == "24039990" || TxtHSCodeItem.Text == "24041100" || TxtHSCodeItem.Text == "27112110" || TxtHSCodeItem.Text == "33021020")
                        {
                            txttotDutiableQty.Text = Math.Round(Convert.ToDecimal(((op * ip * inp * totduti))), 2).ToString();
                        }
                        else
                        {
                            txttotDutiableQty.Text = Math.Round(Convert.ToDecimal(((op * ip * inp * totduti))) / Convert.ToDecimal(1000), 2).ToString();
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
                                innonpayment.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                innonpayment.Update();
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
                                innonpayment.Update();
                            }
                            else
                            {
                                Lblmarquee.Text = "";
                                innonpayment.Update();
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
                        T4 = (T2 * 0.09) + (T3 * 0.09);
                        TxtItemSumGST.Text = T4.ToString();
                    }
                    else if (TDQUOM.SelectedItem.Text == "KGM" && kgmvis == "DIVIDE")
                    {
                        txttotDutiableQty.Text = ((op * ip * inp * totduti / 1000)).ToString();
                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {
                            TxtSumExciseDuty.Text = (((op * ip * inp * totduti) / 1000) * (T1)).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);
                        T4 = (T2 * 0.09) + (T3 * 0.09);
                        TxtItemSumGST.Text = T4.ToString();
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
                        T4 = (T2 * 0.09) + (T3 * 0.09);
                        TxtItemSumGST.Text = T4.ToString();
                    }
                    else if (TDQUOM.SelectedItem.Text == "KGM" && typeidval == 62)
                    {
                        txttotDutiableQty.Text = ((op * ip * inp * totduti)).ToString();
                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {
                            TxtSumExciseDuty.Text = (((op * ip * inp * totduti)) * (T1)).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);
                        T4 = (T2 * 0.09) + (T3 * 0.09);
                        TxtItemSumGST.Text = T4.ToString();
                    }

                    else if (TDQUOM.SelectedItem.Text == "TNE" && typeidval == 62)
                    {
                        txttotDutiableQty.Text = ((op * ip * inp * totduti)).ToString();
                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {
                            TxtSumExciseDuty.Text = (((op * ip * inp * totduti)) * (T1)).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);
                        T4 = (T2 * 0.09) + (T3 * 0.09);
                        TxtItemSumGST.Text = T4.ToString();
                    }
                    else if (TDQUOM.SelectedItem.Text == "DAL")
                    {
                        txttotDutiableQty.Text = ((op * ip * inp * totduti)).ToString();
                        if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                        {
                            TxtSumExciseDuty.Text = (((op * ip * inp * totduti)) * (T1)).ToString();
                        }
                        T3 = Convert.ToDouble(TxtSumExciseDuty.Text);
                        T4 = (T2 * 0.09) + (T3 * 0.09);
                        TxtItemSumGST.Text = T4.ToString();
                    }
                }
            }
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


        protected void btnsaveheader_Click(object sender, EventArgs e)
        {

        }

        protected void btnresetheader_Click(object sender, EventArgs e)
        {
            HeaderClr();
        }

        protected void btnnextheader_Click(object sender, EventArgs e)
        {
            
            TabContainer1.ActiveTab = TabContainer1.Tabs[TabContainer1.ActiveTabIndex + 1];
            innonheader.Update();
            innonpayment.Update();
            TxtDecCompCode.Focus();

        }

        protected void btnpreviousparty_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[TabContainer1.ActiveTabIndex - 1];
            // innonheader.Update();
            innonpayment.Update();
            DrpDecType.Focus();


        }

        protected void btnsaveparty_Click(object sender, EventArgs e)
        {

        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            PartyClr();
            TxtDecCompCode.Focus();

        }

        protected void btnnextparty_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[TabContainer1.ActiveTabIndex + 1];
            innonpayment.Update();
            TxttotalOuterPack.Focus();
        }

        protected void btnprevcargo_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[TabContainer1.ActiveTabIndex - 1];
            innonpayment.Update();
            TxtDecCompCode.Focus();
        }

        protected void btnsavecargo_Click(object sender, EventArgs e)
        {
            int chkCode = 0;
            string License = TxtLicense1.Text + '-' + TxtLicense2.Text + '-' + TxtLicense3.Text + '-' + TxtLicense4.Text + '-' + TxtLicense5.Text;
            string Recipient = TxtRECPT1.Text + '-' + TxtRECPT2.Text + '-' + TxtRECPT3.Text;
            string Touch_user = Session["UserId"].ToString();
            //var ArrivalDate = DateTime.Parse(this.TxtArrivalDate1.Text, new CultureInfo("en-US", true));
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
            DateTime BlanketDate = Convert.ToDateTime(null);
            // var BlanketDate = DateTime.Parse(this.BlankDate1.Text, new CultureInfo("en-US", true));
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
            DateTime DepatureDate = Convert.ToDateTime(null);
            // var DepatureDate = DateTime.Parse(this.TxtExpArrivalDate1.Value, new CultureInfo("en-US", true));
            if (TxtExpArrivalDate1.Text == "")
            {
                var date = DateTime.Now.ToString("dd/MM/yyyy");
                var manDate = DateTime.ParseExact(date, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                DepatureDate = Convert.ToDateTime(manDate);
            }
            else
            {
                var InvoiceDate1 = DateTime.ParseExact(TxtExpArrivalDate1.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                DepatureDate = Convert.ToDateTime(InvoiceDate1);
            }

            JobNO();
            MSGNO();
            refid();

            string PrevPer = "";
            string qry11 = "SELECT PermitId FROM InNonpaymentTemp where PermitId='" + txt_code.Text + "'";
            obj.dr = obj.ret_dr(qry11);
            while (obj.dr.Read())
            {
                PrevPer = obj.dr[0].ToString();
            }
            if (PrevPer != "")
            {
                string PerCount = ("Delete InNonpaymentTemp where PermitId='" + txt_code.Text + "'");
                obj.exec(PerCount);
                obj.closecon();
            }
        Save:
            string nullval = "0.00";
            string strTime = System.DateTime.Now.ToString("yyyy/MM/dd");
            string StrQuery = ("INSERT INTO [dbo].[InNonpaymentTemp] ([Refid],[JobId],[MSGId],[PermitId],[TradeNetMailboxID],[MessageType],[DeclarationType],PreviousPermit,[CargoPackType],[InwardTransportMode],[OutwardTransportMode],[BGIndicator],[SupplyIndicator],[ReferenceDocuments],[License],[Recipient],[DeclarantCompanyCode],[ImporterCompanyCode],[ExporterCompanyCode],[InwardCarrierAgentCode],[OutwardCarrierAgentCode],[FreightForwarderCode],[ConsigneeCode],[ClaimantPartyCode],[ArrivalDate],[LoadingPortCode],[VoyageNumber],[VesselName],[OceanBillofLadingNo],[ConveyanceRefNo],[TransportId],[FlightNO],[AircraftRegNo],[MasterAirwayBill],[ReleaseLocation],[ReleaseLocaName],[RecepitLocation],RecepilocaName,StorageLocation,ExhibitionSDate,ExhibitionEDate,[BlanketStartDate],[TradeRemarks] ,[InternalRemarks],[CustomerRemarks] ,[DepartureDate],[DischargePort],[FinalDestinationCountry],[OutVoyageNumber],[OutVesselName],[OutOceanBillofLadingNo],[VesselType],[VesselNetRegTon],[VesselNationality],[TowingVesselID],[TowingVesselName],[NextPort],[LastPort],[OutConveyanceRefNo],[OutTransportId],[OutFlightNO],[OutAircraftRegNo],[OutMasterAirwayBill],[TotalOuterPack],[TotalOuterPackUOM],[TotalGrossWeight],[TotalGrossWeightUOM],[DeclareIndicator],[NumberOfItems],[TotalCIFFOBValue],[TotalGSTTaxAmt],[TotalExDutyAmt],[TotalCusDutyAmt],[TotalODutyAmt],[TotalAmtPay],[Status],[prmtStatus],[TouchUser],[TouchTime])  VALUES('" + refno + "','" + JobNo + "','" + MsgNO + "','" + txt_code.Text + "','" + TxtTradeMailID.Text + "','" + TxtMsgType.Text + "','" + DrpDecType.SelectedItem.ToString() + "','" + TxtPrevPerNO.Text + "','" + DrpCargoPackType.SelectedItem.ToString() + "','" + DrpInwardtrasMode.SelectedItem.ToString() + "','" + DrpOutwardtrasMode.SelectedItem.ToString() + "','" + DrpBGIndicator.SelectedItem.ToString() + "','" + ChkSupplyIndicator.Checked.ToString() + "','" + ChkRefDoc.Checked.ToString() + "','" + License + "','" + Recipient + "', '" + TxtDecCompCode.Text + "','" + TxtImpCode.Text + "','" + TxtExpCode.Text + "','" + InwardCode.Text + "','" + OutwardCode.Text + "','" + FrieghtCode.Text + "','" + ConsigneeCode.Text + "','" + ClaimantName.Text + "','" + Convert.ToDateTime(ArrivalDate).ToString("yyyy/MM/dd") + "','" + TxtLoadShort.Text + "','" + TxtVoyageno.Text + "','" + TxtVesselName.Text + "','" + TxtOceanBill.Text + "','" + TxtConRefNo.Text + "','" + TxtTrnsID.Text + "','" + txtflight.Text + "','" + txtaircraft.Text + "','" + txtwaybill.Text + "','" + txtreLoctn.Text + "','"+txtrelocDeta.Text+"','" + txtrecloctn.Text + "','" + txtrecloctn.Text + "','" + txtstrgeloc.Text + "','" + txtExStartDate.Text + "','" + txtExEndDate.Text + "','" + Convert.ToDateTime(BlanketDate).ToString("yyyy/MM/dd") + "','" + txttrdremrk.Text + "','" + txtintremrk.Text + "','" + txtcusRemrk.Text + "','" + Convert.ToDateTime(DepatureDate).ToString("yyyy/MM/dd") + "','" + TxtExpLoadShort.Text + "','" + DrpFinalDesCountry.SelectedItem + "','" + OUTWARDVoyageNo.Text + "','" + OUTWARDVessel.Text + "','" + OUTWARDOcenbill.Text + "','" + ddpVessel.SelectedItem + "','" + txtvesnet.Text + "','" + DroVesslNat.SelectedItem + "','" + txtTowVes.Text + "','" + txtTowVesName.Text + "','" + txtNextprt.Text + "','" + txtLasPrt.Text + "','" + OUTWARDConref.Text + "','" + OUTWARDTransId.Text + "','" + OUTWARDFlightN0.Text + "','" + OUTWARDAirREgno.Text + "','" + OUTWARDAirwaybill.Text + "','" + TxttotalOuterPack.Text + "','" + DrptotalOuterPack.SelectedItem.ToString() + "','" + TxtTotalGrossWeight.Text + "','" + DrpTotalGrossWeight.SelectedItem.ToString() + "','" + chkalrt.Checked.ToString().ToLower() + "','" + nullval + "','" + nullval + "','" + nullval + "','" + nullval + "','" + nullval + "','" + nullval + "','" + nullval + "','NEW','NEW','" + Touch_user + "','" + strTime + "')");
            chkCode = obj.exec(StrQuery);
            if (chkCode == -2146232060)
            {
                refid();
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
            innonpayment.Update();
            txtcodeinvq.Focus();
        }

        protected void btnprevinvoice_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[TabContainer1.ActiveTabIndex - 1];
            innonpayment.Update();
            TxtLoadShort.Focus();
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
            innonpayment.Update();
            TxtInHouseItem.Focus();
        }

        protected void btnprevitem_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[TabContainer1.ActiveTabIndex - 1];
            innonpayment.Update();
            TxtInHouseItem.Focus();
        }

        protected void btnsaveitem_Click(object sender, EventArgs e)
        {

        }

        protected void btnresetitem_Click(object sender, EventArgs e)
        {
            Itemclear();
        }

        protected void btnnextitem_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[TabContainer1.ActiveTabIndex + 1];
            innonpayment.Update();
            chkaeo.Focus();
        }

        protected void btnprevcpc_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[TabContainer1.ActiveTabIndex - 1];
            innonpayment.Update();
            TxtInHouseItem.Focus();
        }

        protected void btnsavecpc_Click(object sender, EventArgs e)
        {

        }

        protected void btnresetcpc_Click(object sender, EventArgs e)
        {

        }

        protected void btnnextcpc_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[TabContainer1.ActiveTabIndex + 1];
            innonpayment.Update();
            chkAuto.Focus();
        }

        protected void btnprevsum_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[TabContainer1.ActiveTabIndex - 1];
            innonpayment.Update();
        }
        private void amendinsert()
        {
            string Touch_user = Session["UserId"].ToString();
            string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string P1 = ("insert into InNonAmend (Permitno,AmendmentCount,UpdateIndicator,ReplacementPermitno,DescriptionOfReason,PermitExtension,ExtendImportPeriod,DeclarationIndigator,TouchUser,TouchTme)Values('" + txtamendpermit.Text + "','" + txtamoundcount.Text + "','" + txtupdateindicator.Text + "','" + txtreplacepermit.Text + "','" + txtdescreason.Text + "','" + ChkPermitvalEx.Checked.ToString() + "','" + txtvalidity.Text + "','" + chkdec.Checked.ToString() + "','" + Touch_user + "','" + strTime + "') ");
            obj.exec(P1);
            obj.closecon();
        }
        private void Cancelinsert()
        {
            string Touch_user = Session["UserId"].ToString();
            string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string P1 = ("insert into InNonCancel (Permitno,UpdateIndicator,ReplacementPermitno,ResonForCancel,DescriptionOfReason,DeclarationIndigator,TouchUser,TouchTme)Values('" + txtcanPermit.Text + "','" + txtupdateInd.Text + "','" + txtcanrepPermit.Text + "','" + DrpReasonCancel.SelectedItem.ToString() + "','" + txtdesReason.Text + "','" + CheckBox4.Checked.ToString() + "','" + Touch_user + "','" + strTime + "') ");
            obj.exec(P1);
            obj.closecon();
        }
        private void LoadInpDecCancel()
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from InNonHeaderTbl  where PermitId='" + txt_code.Text + "'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            XmlWriterSettings xws = new XmlWriterSettings();
            xws.OmitXmlDeclaration = true;
            xws.Indent = true;
            using (XmlWriter xw = XmlWriter.Create(sb, xws))
            {
                XNamespace ns1 = "urn:crimsonlogic:tn:schema:xsd:TradenetDeclaration";
                XNamespace ns2 = "urn:crimsonlogic:tn:schema:xsd:CommonBasicComponents-2";
                XNamespace ns3 = "urn:crimsonlogic:tn:schema:xsd:CommonAggregateComponents-2";
                XNamespace ns4 = "urn:crimsonlogic:tn:schema:xsd:InNonPayment";
                XNamespace ns5 = "urn:crimsonlogic:tn:schema:xsd:InPayment";
                XNamespace ns6 = "urn:crimsonlogic:tn:schema:xsd:OutwardDeclaration";
                XNamespace ns7 = "urn:crimsonlogic:tn:schema:xsd:TranshipmentMovement";
                XNamespace ns8 = "urn:crimsonlogic:tn:schema:xsd:CertificateOfOrigin";

                XDocument doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
                XElement reportElement = new XElement(ns1 + "TradenetDeclaration",
                new XAttribute(XNamespace.Xmlns + "cbc", ns2),
                new XAttribute(XNamespace.Xmlns + "cac", ns3),
                new XAttribute(XNamespace.Xmlns + "inp", ns4),
                new XAttribute(XNamespace.Xmlns + "ipt", ns5),
                new XAttribute(XNamespace.Xmlns + "out", ns6),
                new XAttribute(XNamespace.Xmlns + "tnp", ns7),
                new XAttribute(XNamespace.Xmlns + "coo", ns8));
                string Date = DateTime.Now.ToString("yyyyMMddHHmm");
                reportElement.Add(new XAttribute("dateTime", Date));
                reportElement.Add(new XAttribute("instanceIdentifier", dt.Rows[0]["JobId"].ToString()));
                doc.Add(reportElement);

                XElement Telephone = new XElement(ns2 + "Telephone", "94550043");
                XElement DeclarName = new XElement(ns2 + "Name", "ESVARAN ESVARAN");
                XElement CodeValue = new XElement(ns2 + "CodeValue", "S9409336H");
                XElement PersonInformation = new XElement(ns3 + "PersonInformation", "");
                XElement DeclarantParty = new XElement(ns3 + "DeclarantParty", "");
                DeclarantParty.Add(PersonInformation);
                PersonInformation.Add(CodeValue);
                PersonInformation.Add(DeclarName);
                DeclarantParty.Add(Telephone);
                InnonPaymentClass objd = new InnonPaymentClass();
                string[] percode = null;
                objd.dr = objd.ret_dr("select * from InNonCancel where Permitno='" + dt.Rows[0]["PermitNumber"].ToString() + "'");
                if (objd.dr.HasRows)
                {
                    while (objd.dr.Read())
                    {
                        percode = objd.dr["ResonForCancel"].ToString().Split(':');
                    }
                }
                XElement canreason = new XElement(ns2 + "CancellationReasonCode", percode[0].ToString().Substring(0, percode[0].Length - 1).ToUpper());
                XElement DeclarationIndicator = new XElement(ns2 + "DeclarationIndicator", dt.Rows[0]["DeclareIndicator"].ToString().ToLower());
                XElement CommonAccessReference = new XElement(ns2 + "CommonAccessReference", dt.Rows[0]["MessageType"].ToString());
                XElement DeclarantID = new XElement(ns2 + "DeclarantID", "QXMF.QXMF001");
                XElement MessageReference = new XElement(ns2 + "MessageReference", dt.Rows[0]["MSGId"].ToString());
                string date = "";
                string sequneNo = "";
                date = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                sequneNo = dt.Rows[0]["MSGId"].ToString().Substring(dt.Rows[0]["MSGId"].ToString().Length - 4);
                XElement UniqueReferenceNumber = new XElement(ns3 + "UniqueReferenceNumber", "");
                UniqueReferenceNumber.Add(new XElement(ns2 + "ID", "201834618Z"));
                UniqueReferenceNumber.Add(new XElement(ns2 + "Date", date));
                UniqueReferenceNumber.Add(new XElement(ns2 + "SequenceNumeric", sequneNo));

                XElement cancelupdhed = new XElement(ns3 + "CancellationHeader", "");
                XElement cancelupd = new XElement(ns3 + "Cancellation", "");
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["MSGId"].ToString()))
                {
                    cancelupdhed.Add(MessageReference);
                }
                cancelupdhed.Add(UniqueReferenceNumber);
                cancelupdhed.Add(DeclarantID);
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["MessageType"].ToString()))
                {
                    cancelupdhed.Add(CommonAccessReference);
                }
                cancelupdhed.Add(DeclarationIndicator);
                cancelupdhed.Add(canreason);
                cancelupd.Add(cancelupdhed);
                cancelupd.Add(DeclarantParty);
                //header
                XElement updateAmt = null;
                int n = 0;
                if (!string.IsNullOrWhiteSpace(Update))
                {
                    string qry111 = "";
                    InnonPaymentClass objcan = new InnonPaymentClass();
                    if (Update == "AMEND")
                    {
                        qry111 = "select * from dbo.InNonAmend where Permitno='" + dt.Rows[0]["PermitNumber"].ToString() + "'";
                        objcan.dr = objcan.ret_dr(qry111);
                    }
                    else
                    {
                        qry111 = "select * from dbo.InNonCancel where Permitno='" + dt.Rows[0]["PermitNumber"].ToString() + "'";
                        objcan.dr = objcan.ret_dr(qry111);
                    }
                    while (objcan.dr.Read())
                    {
                        n = n + 1;
                        XElement updateAmtReason = null;
                        XElement updateexdper = null;
                        XElement updatepervalexp = null;
                        if (Update == "AMEND")
                        {
                            updateAmtReason = new XElement(ns2 + "AmendmentReason", objcan.dr["DescriptionOfReason"].ToString().ToUpper());
                            updateexdper = new XElement(ns2 + "ExtensionReason", objcan.dr["ExtendImportPeriod"].ToString().ToLower());
                            updatepervalexp = new XElement(ns2 + "PermitValidityExtensionIndicator", objcan.dr["PermitExtension"].ToString().ToLower());
                        }
                        XElement updateAmtval = new XElement(ns3 + "Amendment", "");
                        XElement updateReppermitno = new XElement(ns2 + "ReplacementPermitNumber", objcan.dr["ReplacementPermitno"].ToString());
                        XElement updatepermitno = new XElement(ns2 + "UpdatePermitNumber", objcan.dr["Permitno"].ToString());
                        XElement updatereuqno = new XElement(ns2 + "UpdateRequestNumber", n);
                        XElement updateInd = new XElement(ns2 + "UpdateIndicatorCode", objcan.dr["UpdateIndicator"].ToString());
                        updateAmt = new XElement(ns3 + "Update", "");
                        if (!string.IsNullOrWhiteSpace(objcan.dr["UpdateIndicator"].ToString()))
                        {
                            updateAmt.Add(updateInd);
                        }
                        updateAmt.Add(updatereuqno);
                        if (!string.IsNullOrWhiteSpace(objcan.dr["Permitno"].ToString()))
                        {
                            updateAmt.Add(updatepermitno);
                        }
                        if (!string.IsNullOrWhiteSpace(objcan.dr["ReplacementPermitno"].ToString()))
                        {
                            updateAmt.Add(updateReppermitno);
                        }
                        if (Update == "AMEND")
                        {
                            if (!string.IsNullOrWhiteSpace(objcan.dr["PermitExtension"].ToString().ToLower()))
                            {
                                updateAmtval.Add(updatepervalexp);
                            }
                            if (!string.IsNullOrWhiteSpace(objcan.dr["ExtendImportPeriod"].ToString()))
                            {
                                updateAmtval.Add(updateexdper);
                            }
                            if (!string.IsNullOrWhiteSpace(objcan.dr["DescriptionOfReason"].ToString()))
                            {
                                updateAmtval.Add(updateAmtReason);
                            }
                            updateAmt.Add(updateAmtval);
                        }
                    }
                    //reportElement.Add(updateAmt);
                }

                XElement InboundMessage = new XElement(ns1 + "InboundMessage");
                XElement InPayment = new XElement(ns4 + "InNonPaymentUpdate", "");
                if (!string.IsNullOrWhiteSpace(Update))
                {
                    InPayment.Add(updateAmt);
                }
                InPayment.Add(cancelupd);
                InboundMessage.Add(InPayment);
                //XElement InPayment = new XElement(ns5 + "Inpayment", "");
                reportElement.Add(new XElement(ns2 + "MessageVersion", "041"));
                reportElement.Add(new XElement(ns2 + "SenderID", "QXMF.QXMF001"));
                reportElement.Add(new XElement(ns2 + "RecipientID", "DCST.DCST401"));
                reportElement.Add(new XElement(ns2 + "TotalNumberOfDeclaration", "1"));
                reportElement.Add(InboundMessage);
                //reportElement.Add(new XElement(ns5 + "InPayment", Header, Cargo, Transport, Party, Item, Summary));
                //reportElement.Add(new XElement(ns5 + "InboundMessage", "InPayment"));                               

                doc.WriteTo(xw);
            }
            // Response.Write(sb.ToString());

            var folder = Server.MapPath("KaizenXML");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            //string path = @"D:\Kaizen\INPDEC.xml";
            string path = Server.MapPath("KaizenXML");
            string filename = path + "\\INPDECCAN" + txt_code.Text + ".xml";
            // Create a file to write to.
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            using (StreamWriter sw = File.CreateText(filename))
            {
                sw.WriteLine(sb.ToString());

            }
        }
        protected void btnsavesum_Click(object sender, EventArgs e)
        {
            ReqValidatePageLoad();
            if (GridError.DataSource != null)
            {
                GridError.Visible = true;
                POPUPERR.Show();
              
            }
            else
            {

                if (chkstatus == "AMEND")
                {
                    Editdata();
                    amendinsert();
                    Response.Redirect("InNonpaymentList.aspx");

                }
                else if (chkstatus == "CANCEL")
                {
                    Editdata();
                    Cancelinsert();
                    Response.Redirect("InNonpaymentList.aspx");
                }
                else
                {
                    //if (Math.Round(Convert.ToDecimal(txtcifVal.Text), 0) == Math.Round(Convert.ToDecimal(txtfobval.Text), 0))
                    //{
                    Id = Convert.ToInt32(Session["Id"].ToString());
                    if (Id != 0)
                    {
                        Editdata();
                        InvoiceClr();
                        Itemclear();
                        Session["Edit"] = false;
                        //eid = 0;
                    }
                    else
                    {
                        string justdate = DateTime.Now.ToString("yyyyMMdd");
                        int chkCode = 0;
                        string Code = "";
                        string qry11 = "SELECT PermitId FROM InNonHeaderTbl where PermitId='" + txt_code.Text + "' and MessageType='INPDEC' and  LEFT(MSGId,8) ='" + justdate + "'";
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

                            //var ArrivalDate = DateTime.Parse(this.TxtArrivalDate1.Text, new CultureInfo("en-US", true));
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
                            DateTime BlanketDate = Convert.ToDateTime(null);
                            // var BlanketDate = DateTime.Parse(this.BlankDate1.Text, new CultureInfo("en-US", true));
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


                            DateTime DepatureDate = Convert.ToDateTime(null);
                            // var DepatureDate = DateTime.Parse(this.TxtExpArrivalDate1.Value, new CultureInfo("en-US", true));
                            if (TxtExpArrivalDate1.Text == "")
                            {
                                var date = "01/01/1900";
                                //var date = DateTime.Now.ToString("dd/MM/yyyy");
                                var manDate = DateTime.ParseExact(date, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                                DepatureDate = Convert.ToDateTime(manDate);
                            }
                            else
                            {
                                var InvoiceDate1 = DateTime.ParseExact(TxtExpArrivalDate1.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                                DepatureDate = Convert.ToDateTime(InvoiceDate1);
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

                        Save:


                            string strTime = System.DateTime.Now.ToString("yyyy/MM/dd");
                            string StrQuery = ("INSERT INTO [dbo].[InNonHeaderTbl] ([Refid],[JobId],[MSGId],[PermitId],[TradeNetMailboxID],[MessageType],[DeclarationType],PreviousPermit,[CargoPackType],[InwardTransportMode],[OutwardTransportMode],[BGIndicator],[SupplyIndicator],[ReferenceDocuments],[License],[Recipient],[DeclarantCompanyCode],[ImporterCompanyCode],[ExporterCompanyCode],[InwardCarrierAgentCode],[OutwardCarrierAgentCode],[FreightForwarderCode],[ConsigneeCode],[ClaimantPartyCode],[ArrivalDate],[LoadingPortCode],[VoyageNumber],[VesselName],[OceanBillofLadingNo],[ConveyanceRefNo],[TransportId],[FlightNO],[AircraftRegNo],[MasterAirwayBill],[ReleaseLocation],[ReleaseLocaName],[RecepitLocation],RecepilocaName,StorageLocation,ExhibitionSDate,ExhibitionEDate,[BlanketStartDate],[TradeRemarks] ,[InternalRemarks],[CustomerRemarks] ,[DepartureDate],[DischargePort],[FinalDestinationCountry],[OutVoyageNumber],[OutVesselName],[OutOceanBillofLadingNo],[VesselType],[VesselNetRegTon],[VesselNationality],[TowingVesselID],[TowingVesselName],[NextPort],[LastPort],[OutConveyanceRefNo],[OutTransportId],[OutFlightNO],[OutAircraftRegNo],[OutMasterAirwayBill],[TotalOuterPack],[TotalOuterPackUOM],[TotalGrossWeight],[TotalGrossWeightUOM],GrossReference,[DeclareIndicator],[NumberOfItems],[TotalCIFFOBValue],[TotalGSTTaxAmt],[TotalExDutyAmt],[TotalCusDutyAmt],[TotalODutyAmt],[TotalAmtPay],[Status],[prmtStatus],[Inhabl],[outhbl],[seastore], [scheme], [TouchUser],[TouchTime])  VALUES('" + refno.ToUpper() + "','" + JobNo.ToUpper() + "','" + MsgNO.ToUpper() + "','" + txt_code.Text + "','" + TxtTradeMailID.Text.ToUpper() + "','" + TxtMsgType.Text.ToUpper() + "','" + DrpDecType.SelectedItem.ToString() + "','" + TxtPrevPerNO.Text.ToUpper() + "','" + DrpCargoPackType.SelectedItem.ToString() + "','" + DrpInwardtrasMode.SelectedItem.ToString() + "','" + DrpOutwardtrasMode.SelectedItem.ToString() + "','" + DrpBGIndicator.SelectedItem.ToString() + "','" + ChkSupplyIndicator.Checked.ToString() + "','" + ChkRefDoc.Checked.ToString().ToLower() + "','" + License.ToUpper() + "','" + Recipient.ToUpper() + "', '" + TxtDecCompCode.Text.ToUpper() + "','" + TxtImpCode.Text.ToUpper() + "','" + TxtExpCode.Text.ToUpper() + "','" + InwardCode.Text.ToUpper() + "','" + OutwardCode.Text.ToUpper() + "','" + FrieghtCode.Text.ToUpper() + "','" + ConsigneeCode.Text.ToUpper() + "','" + ClaimantName.Text.ToUpper() + "','" + Convert.ToDateTime(ArrivalDate).ToString("yyyy/MM/dd") + "','" + TxtLoadShort.Text + "','" + TxtVoyageno.Text.ToUpper() + "','" + TxtVesselName.Text.ToUpper() + "','" + TxtOceanBill.Text.ToUpper() + "','" + TxtConRefNo.Text.ToUpper() + "','" + TxtTrnsID.Text + "','" + txtflight.Text.ToUpper() + "','" + txtaircraft.Text.ToUpper() + "','" + txtwaybill.Text.ToUpper() + "','" + txtreLoctn.Text.ToUpper() + "','" + txtrelocDeta.Text.ToUpper() + "','" + txtrecloctn.Text.ToUpper() + "','" + txtrecloctndet.Text.ToUpper() + "','" + txtstrgeloc.Text + "','" + txtExStartDate.Text + "','" + txtExEndDate.Text + "','" + Convert.ToDateTime(BlanketDate).ToString("yyyy/MM/dd") + "','" + txttrdremrk.Text + "','" + txtintremrk.Text + "','" + txtcusRemrk.Text + "','" + Convert.ToDateTime(DepatureDate).ToString("yyyy/MM/dd") + "','" + TxtExpLoadShort.Text + "','" + DrpFinalDesCountry.SelectedItem + "','" + OUTWARDVoyageNo.Text + "','" + OUTWARDVessel.Text + "','" + OUTWARDOcenbill.Text + "','" + ddpVessel.SelectedItem + "','" + txtvesnet.Text + "','" + DroVesslNat.SelectedItem + "','" + txtTowVes.Text + "','" + txtTowVesName.Text + "','" + txtNextprt.Text + "','" + txtLasPrt.Text + "','" + OUTWARDConref.Text + "','" + OUTWARDTransId.Text + "','" + OUTWARDFlightN0.Text + "','" + OUTWARDAirREgno.Text + "','" + OUTWARDAirwaybill.Text + "','" + TxttotalOuterPack.Text + "','" + DrptotalOuterPack.SelectedItem.ToString() + "','" + TxtTotalGrossWeight.Text + "','" + DrpTotalGrossWeight.SelectedItem.ToString() + "','" + TxtGrossReference.Text + "','" + chkalrt.Checked.ToString().ToLower() + "','" + txtnoofitm.Text + "','" + txtfobval.Text + "','" + txttotgstAmt.Text + "','" + txttotexAmt.Text + "','" + txtcusdutyAmt.Text + "','" + txtothtaxAmt.Text + "','" + txtAmtPayble.Text + "','NEW','NEW','" + txthblCargo.Text + "','" + txtouthblCargo.Text + "','" + chkSea.Checked.ToString() + "','" + Chkscheme1.Checked.ToString() + "','" + Touch_user + "','" + strTime + "' )");
                            chkCode = obj.exec(StrQuery);
                            if (chkCode == -2146232060)
                            {
                                refid();
                                PermitNO();
                                goto Save;
                            }

                            //Clear Temp Data
                            string tempdel = ("delete from InNonpaymentTemp where PermitId='" + txt_code.Text + "' and TouchUser='" + Touch_user + "' ");
                            obj.exec(tempdel);

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
                                    string StrQuery1 = ("INSERT INTO [dbo].[InnonContainerDtl] ([PermitId],[RowNo],[ContainerNo],[Size],[Weight],[SealNo],[MessageType],[TouchUser],[TouchTime]) VALUES ('" + txt_code.Text + "','" + i + "','" + ContainerNo + "','" + ContainerSize + "','" + ContainerWeight + "','" + Containerseal + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "')");
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
                                    string StrQuery1 = ("INSERT INTO [dbo].[InNonCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + a + "','AEO','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
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
                                    string StrQuery1 = ("INSERT INTO [dbo].[InNonCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + b + "','CWC','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
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

                            int l = 1;
                            foreach (GridViewRow g1 in IcGrid.Rows)
                            {
                                string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;
                                string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                                string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                                if (ProcessingCode1 != "")
                                {
                                    string StrQuery1 = ("INSERT INTO [dbo].[InNonCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + l + "','IC','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                                    obj.exec(StrQuery1);
                                    obj.closecon();
                                }
                                l++;
                            }

                            Response.Redirect("InNONpaymentList.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Permit Code '" + txt_code.Text + "' Already Exist..');", true);
                        }
                        InvoiceClr();
                        Itemclear();
                    }
                }
            }
        }

        protected void btnresetsum_Click(object sender, EventArgs e)
        {

        }

        protected void btnnextsum_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[TabContainer1.ActiveTabIndex + 1];
            innonpayment.Update();
        }

        protected void DECCOMPSearGRID_RowCommand(object sender, GridViewCommandEventArgs e)
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
                }
            }
            innonpayment.Update();
        }

        protected void DECCOMPSearGRID_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(DECCOMPSearGRID, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void ImporterGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {                
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
                        TxtImpName.Text = "";
                        TxtImpName1.Text = "";
                        TxtImpCRUEI.Text = "";

                        TxtImpCode.Text = requestor;
                        TxtImpName.Text = requestType;
                        TxtImpName1.Text = status;
                        TxtImpCRUEI.Text = crueis;
                        lblimporterparty.Text = crueis + " - " + requestType + " " + status;
                        //  UpdatePanelDCS.Update();


                        //IMPORTER PARTY
                        TxtImppartyCode.Text = "";
                        TxtImppartyCRUEI.Text = "";
                        TxtImppartyName.Text = "";
                        TxtImppartyName1.Text = "";

                        TxtImppartyCode.Text = requestor;
                        TxtImppartyCRUEI.Text = crueis;
                        TxtImppartyName.Text = requestType;
                        TxtImppartyName1.Text = status;
                    }                   
                }
            }
            innonpayment.Update();
        }

        protected void ImporterGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(ImporterGrid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void ExporterGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {                
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                //Reference the GridView Row.
                GridViewRow row = ExporterGrid.Rows[rowIndex];
                if (row != null)
                {
                    var lblCode1 = row.FindControl("lblCode") as Label;
                    var lblName1 = row.FindControl("lblName") as Label;
                    var lblName11 = row.FindControl("lblName1") as Label;
                    var cruei1 = row.FindControl("lblCRUEI") as Label;

                    if (lblCode1 != null && lblName1 != null && lblName11 != null && cruei1 != null)
                    {                        
                        string requestor = lblCode1.Text;
                        string requestType = lblName1.Text;
                        string status = lblName11.Text;
                        string crueis = cruei1.Text;
                        TxtExpCode.Text = "";
                        TxtExpName.Text = "";
                        TxtExpName1.Text = "";
                        TxtExpCRUEI.Text = "";
                        TxtExpCode.Text = requestor;
                        TxtExpName.Text = requestType;
                        TxtExpName1.Text = status;
                        TxtExpCRUEI.Text = crueis;

                        lblimporterparty.Text = crueis + " - " + requestType + " " + status;
                    }                   
                }
            }
            innonpayment.Update();
        }

        protected void ExporterGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(ExporterGrid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void InwardGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {                
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
            }
            innonpayment.Update();
        }

        protected void InwardGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(InwardGrid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void OutwardGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {                
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                //Reference the GridView Row.
                GridViewRow row = OutwardGrid.Rows[rowIndex];
                if (row != null)
                {
                    var lblCode1 = row.FindControl("lblCode") as Label;
                    var lblName1 = row.FindControl("lblName") as Label;
                    var lblName11 = row.FindControl("lblName1") as Label;
                    var cruei1 = row.FindControl("lblCRUEI") as Label;

                    if (lblCode1 != null && lblName1 != null && lblName11 != null && cruei1 != null)
                    {                        
                        string requestor = lblCode1.Text;
                        string requestType = lblName1.Text;
                        string status = lblName11.Text;
                        string crueis = cruei1.Text;
                        OutwardCode.Text = "";
                        OutwardName.Text = "";
                        OutwardName1.Text = "";
                        OutwardCRUEI.Text = "";
                        OutwardCode.Text = requestor;
                        OutwardName.Text = requestType;
                        OutwardName1.Text = status;
                        OutwardCRUEI.Text = crueis;                        
                    }                  
                }
            }
            innonpayment.Update();
        }

        protected void OutwardGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(OutwardGrid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void FrieghtGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {                
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
                    }                   
                }
            }
            innonpayment.Update();
        }

        protected void FrieghtGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(FrieghtGrid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void ConsigneeGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {                
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                //Reference the GridView Row.
                GridViewRow row = ConsigneeGrid.Rows[rowIndex];
                if (row != null)
                {
                    var lblCode1 = row.FindControl("lblCode") as Label;
                    var lblName1 = row.FindControl("lblName") as Label;
                    var lblName11 = row.FindControl("lblName1") as Label;
                    var cruei1 = row.FindControl("lblCRUEI") as Label;
                    var ConsigneeAddress1 = row.FindControl("ConsigneeAddress") as Label;
                    var ConsigneeAddress11 = row.FindControl("ConsigneeAddress1") as Label;
                    var ConsigneeCity1 = row.FindControl("ConsigneeCity") as Label;
                    var ConsigneeSub1 = row.FindControl("ConsigneeSub") as Label;
                    var ConsigneeSubdivi = row.FindControl("ConsigneeSubDivi") as Label;
                    var ConsigneePostal1 = row.FindControl("ConsigneePostal") as Label;
                    var ConsigneeCountry1 = row.FindControl("ConsigneeCountry") as Label;
                    //Get values
                    string requestor = lblCode1.Text;
                    string requestType = lblName1.Text;
                    string status = lblName11.Text;
                    string crueis = cruei1.Text;
                    string ConsigneeAddress12 = ConsigneeAddress1.Text;
                    string ConsigneeAddress112 = ConsigneeAddress11.Text;
                    string ConsigneeCity12 = ConsigneeCity1.Text;
                    string ConsigneeSub12 = ConsigneeSub1.Text;
                    string ConsigneeSub121divi = ConsigneeSubdivi.Text;
                    string ConsigneePostal12 = ConsigneePostal1.Text;
                    string ConsigneeCountry12 = ConsigneeCountry1.Text;
                    ConsigneeCode.Text = "";
                    ConsigneeName.Text = "";
                    ConsigneeName1.Text = "";
                    ConsigneeCRUEI.Text = "";
                    ConsigneeAddress.Text = "";
                    ConsigneeAddress1.Text = "";
                    ConsigneeCity.Text = "";
                    ConsigneeSub.Text = "";
                    ConsigneeSubDivi.Text = "";
                    ConsigneePostal.Text = "";
                    ConsigneeCountry.Text = "";
                    ConsigneeCode.Text = requestor;
                    ConsigneeName.Text = requestType;
                    ConsigneeName1.Text = status;
                    ConsigneeCRUEI.Text = crueis;
                    ConsigneeAddress.Text = ConsigneeAddress12;
                    ConsigneeAddress1.Text = ConsigneeAddress112;
                    ConsigneeCity.Text = ConsigneeCity12;
                    ConsigneeSub.Text = ConsigneeSub12;
                    ConsigneeSubDivi.Text = ConsigneeSub121divi;
                    ConsigneePostal.Text = ConsigneePostal12;
                    ConsigneeCountry.Text = ConsigneeCountry12;
                }
            }
            innonpayment.Update();
        }

        protected void ConsigneeGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(ConsigneeGrid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void LoadingGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {                
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                //Reference the GridView Row.
                GridViewRow row = LoadingGrid.Rows[rowIndex];
                if (row != null)
                {
                    var lblCode1 = row.FindControl("lblCode") as Label;
                    var lblName1 = row.FindControl("lblName") as Label;
                    var lblName11 = row.FindControl("lblName1") as Label;
                    //   var cruei1 = row.FindControl("lblCRUEI") as Label;
                    if (lblCode1 != null && lblName1 != null && lblName11 != null)
                    {                        
                        string requestor = lblCode1.Text;
                        string requestType = lblName1.Text;
                        string status = lblName11.Text;
                        // string crueis = cruei1.Text;
                        TxtLoadShort.Text = "";
                        TxtLoad.Text = "";
                        TxtLoadShort.Text = requestor;
                        TxtLoad.Text = requestType;                        
                    }
                }
            }
            innonpayment.Update();
        }

        protected void LoadingGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(LoadingGrid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void LocationGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {                
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                //Reference the GridView Row.
                GridViewRow row = LocationGrid.Rows[rowIndex];
                if (row != null)
                {
                    var lblCode1 = row.FindControl("lblCode") as Label;
                    var lblName1 = row.FindControl("lblName") as Label;
                    var lblName11 = row.FindControl("lblName1") as Label;
                    //   var cruei1 = row.FindControl("lblCRUEI") as Label;
                    if (lblCode1 != null && lblName1 != null && lblName11 != null)
                    {                       
                        string requestor = lblCode1.Text;
                        string requestType = lblName1.Text;
                        string status = lblName11.Text;
                        // string crueis = cruei1.Text;
                        txtreLoctn.Text = "";
                        txtrelocDeta.Text = "";
                        txtreLoctn.Text = requestType;
                        txtrelocDeta.Text = status;                        
                    }                    
                }
            }
            innonpayment.Update();
        }

        protected void LocationGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(LocationGrid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void ReceiptGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {                
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                //Reference the GridView Row.
                GridViewRow row = ReceiptGrid.Rows[rowIndex];
                if (row != null)
                {
                    var lblCode1 = row.FindControl("lblCode") as Label;
                    var lblName1 = row.FindControl("lblName") as Label;
                    var lblName11 = row.FindControl("lblName1") as Label;
                    //   var cruei1 = row.FindControl("lblCRUEI") as Label;
                    if (lblCode1 != null && lblName1 != null && lblName11 != null)
                    {                        
                        string requestor = lblCode1.Text;
                        string requestType = lblName1.Text;
                        string status = lblName11.Text;
                        // string crueis = cruei1.Text;
                        txtrecloctn.Text = "";
                        txtrecloctndet.Text = "";
                        txtrecloctn.Text = requestType;
                        txtrecloctndet.Text = status;                        
                    }
                }
            }
            innonpayment.Update();
        }

        protected void ReceiptGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(ReceiptGrid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void ExportGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {                
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                //Reference the GridView Row.
                GridViewRow row = ExportGrid.Rows[rowIndex];
                if (row != null)
                {
                    var lblCode1 = row.FindControl("lblCode") as Label;
                    var lblName1 = row.FindControl("lblName") as Label;
                    var lblName11 = row.FindControl("lblName1") as Label;
                    //   var cruei1 = row.FindControl("lblCRUEI") as Label;
                    if (lblCode1 != null && lblName1 != null && lblName11 != null)
                    {                        
                        string requestor = lblCode1.Text;
                        string requestType = lblName1.Text;
                        string status = lblName11.Text;
                        // string crueis = cruei1.Text;
                        TxtExpLoadShort.Text = "";
                        TxtExpLoadShort.Text = "";
                        TxtExpLoadShort.Text = requestType;
                        TxtExpLoadShort.Text = status;                       
                    }                   
                }
            }
            innonpayment.Update();
        }

        protected void ExportGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(ExportGrid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void NextPortGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {                
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                //Reference the GridView Row.
                GridViewRow row = NextPortGrid.Rows[rowIndex];
                if (row != null)
                {
                    var lblCode1 = row.FindControl("lblCode") as Label;
                    var lblName1 = row.FindControl("lblName") as Label;
                    var lblName11 = row.FindControl("lblName1") as Label;                   
                    if (lblCode1 != null && lblName1 != null && lblName11 != null)
                    {                        
                        string requestor = lblCode1.Text;
                        string requestType = lblName1.Text;
                        string status = lblName11.Text;
                        // string crueis = cruei1.Text;
                        txtNextprt.Text = "";
                        txtNetPrtSer.Text = "";
                        txtNextprt.Text = requestor;
                        txtNetPrtSer.Text = requestType;                       
                    }                    
                }
            }
            innonpayment.Update();
        }

        protected void NextPortGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(NextPortGrid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void LastGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {                
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                //Reference the GridView Row.
                GridViewRow row = LastGrid.Rows[rowIndex];
                if (row != null)
                {
                    var lblCode1 = row.FindControl("lblCode") as Label;
                    var lblName1 = row.FindControl("lblName") as Label;
                    var lblName11 = row.FindControl("lblName1") as Label;
                    if (lblCode1 != null && lblName1 != null && lblName11 != null)
                    {                        
                        string requestor = lblCode1.Text;
                        string requestType = lblName1.Text;
                        string status = lblName11.Text;
                        // string crueis = cruei1.Text;
                        txtLasPrt.Text = "";
                        txtLasPrtSer.Text = "";
                        txtLasPrt.Text = requestor;
                        txtLasPrtSer.Text = requestType;                        
                    }                    
                }
            }
            innonpayment.Update();
        }

        protected void LastGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(LastGrid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void SUPPLIERGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {                
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                //Reference the GridView Row.
                GridViewRow row = SUPPLIERGrid.Rows[rowIndex];
                if (row != null)
                {
                    var lblCode1 = row.FindControl("lblCode") as Label;
                    var lblName1 = row.FindControl("lblName") as Label;
                    var lblName11 = row.FindControl("lblName1") as Label;
                    var cruei1 = row.FindControl("lblCRUEI") as Label;
                    if (lblCode1 != null && lblName1 != null && lblName11 != null && cruei1 != null)
                    {                        
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
            innonpayment.Update();
        }

        protected void SUPPLIERGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(SUPPLIERGrid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void ImportPartyGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {                
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                //Reference the GridView Row.
                GridViewRow row = ImportPartyGrid.Rows[rowIndex];
                if (row != null)
                {
                    var lblCode1 = row.FindControl("lblCode") as Label;
                    var lblName1 = row.FindControl("lblName") as Label;
                    var lblName11 = row.FindControl("lblName1") as Label;
                    var cruei1 = row.FindControl("lblCRUEI") as Label;
                    if (lblCode1 != null && lblName1 != null && lblName11 != null && cruei1 != null)
                    {                        
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
            innonpayment.Update();
        }

        protected void ImportPartyGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(ImportPartyGrid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void CountryGridItem_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {                
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                //Reference the GridView Row.
                GridViewRow row = CountryGridItem.Rows[rowIndex];
                if (row != null)
                {                    
                    var lblName1 = row.FindControl("lblName") as Label;
                    var lblName11 = row.FindControl("lblName1") as Label;                    
                    if (lblName1 != null && lblName11 != null)
                    {                                               
                        string requestType = lblName1.Text;
                        string status = lblName11.Text;
                        // string crueis = cruei1.Text;
                        TxtCountryItem.Text = "";
                        txtcname.Text = "";
                        TxtCountryItem.Text = requestType;
                        txtcname.Text = status;                        
                    }                    
                }
            }
            innonpayment.Update();
        }

        protected void CountryGridItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(CountryGridItem, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
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

                }
                else
                {
                    decimal TtlPGW = Convert.ToDecimal(TxtTotalGrossWeight.Text) / Convert.ToDecimal(1000);
                    txtTtlPGW.Text = Convert.ToString(Math.Round(TtlPGW, 3));
                    DrpTtlPGW.ClearSelection();
                    DrpTtlPGW.Items.FindByText("TNE").Selected = true;

                }

            }
            upinnonsummary.Update();
            upinnonparty.Update();
            DrpTotalGrossWeight.Focus();

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



                if (A && B && C)
                {
                    if (T2 > 0)
                    {
                        TxtSumExciseDuty.Text = (T1 * T2 * (T3 / 100)).ToString();
                        TxtSumCustomsDuty.Text = (T1 * T2 * (T4 / 100)).ToString();
                    }
                    //else
                    //{
                    //    TxtSumExciseDuty.Text = (T1 * (T3 / 100)).ToString();
                    //    TxtSumCustomsDuty.Text = (T1 * (T4 / 100)).ToString();
                    //}
                    //TxtSumCustomsDuty.Text = (T1 * T2 * (T4 / 100)).ToString();

                }
                T4 = Convert.ToDouble(TxtSumExciseDuty.Text);
                T5 = Convert.ToDouble(TxtCIFFOB.Text);
                T7 = Convert.ToDouble(TxtSumCustomsDuty.Text);
                T6 = ((T4 * 0.09) + (T5 * 0.09) + (T7 * 0.09));

                TxtItemSumGST.Text = T6.ToString();               
            }
        }

        protected void ProductCode1Grid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {                
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
                        string requestType = lblName1.Text;
                        string status = lblName11.Text;
                        string crueis = cruei1.Text;
                        TxtProductCode1.Text = "";                        
                        DrpP1.ClearSelection();
                        TxtProductCode1.Text = requestType;
                        DrpP1.Items.FindByText(crueis).Selected = true;                       
                    }                   
                }
            }
            innonpayment.Update();

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
                        string requestType = lblName1.Text;
                        string status = lblName11.Text;
                        string crueis = cruei1.Text;
                        TxtProductCode2.Text = "";                        
                        DrpP2.ClearSelection();
                        TxtProductCode2.Text = requestType;
                        DrpP2.Items.FindByText(crueis).Selected = true;                       
                    }                    
                }
            }
            innonpayment.Update();
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

        }

        protected void ddlpc3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ProductCode3Grid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {                
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
                        string requestType = lblName1.Text;
                        string status = lblName11.Text;
                        string crueis = cruei1.Text;
                        TxtProductCode3.Text = "";                        
                        DrpP3.ClearSelection();                        
                        TxtProductCode3.Text = requestType;
                        DrpP3.Items.FindByText(crueis).Selected = true;                        
                    }                    
                }
            }
            innonpayment.Update();
        }

        protected void ProductCode3Grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(ProductCode3Grid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void ProductCode4Grid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {                
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
                        string requestType = lblName1.Text;
                        string status = lblName11.Text;
                        string crueis = cruei1.Text;
                        TxtProductCode4.Text = "";                        
                        DrpP4.ClearSelection();
                        TxtProductCode4.Text = requestType;
                        DrpP4.Items.FindByText(crueis).Selected = true;                        
                    }                    
                }
            }
            innonpayment.Update();
        }

        protected void ProductCode4Grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(ProductCode4Grid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void ProductCode5Grid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {                
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
                        string requestType = lblName1.Text;
                        string status = lblName11.Text;
                        string crueis = cruei1.Text;
                        TxtProductCode5.Text = "";                        
                        DrpP5.ClearSelection();
                        TxtProductCode5.Text = requestType;
                        DrpP5.Items.FindByText(crueis).Selected = true;                        
                    }                   
                }
            }
            innonpayment.Update();
        }

        protected void ProductCode5Grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(ProductCode5Grid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
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
                T6 = ((T4 * 0.09) + (T5 * 0.09) + (T7 * 0.09) + (T7 * 0.09));

                TxtItemSumGST.Text = T6.ToString();               
            }
            upinnonitem.Update();
            ChkPackInfo.Focus();
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
        }

        protected void txtwaybill_TextChanged(object sender, EventArgs e)
        {
            if (DrpInwardtrasMode.SelectedItem.ToString().ToUpper() == "4 : Air".ToUpper())
            {
                if (!string.IsNullOrWhiteSpace(txtwaybill.Text))
                {
                    lbloblval.Text = txtwaybill.Text;                   
                }
            }          
            txtreLoctn.Focus();
            innonpayment.Update();
            upinnonsummary.Update();
        }

        protected void TxtOceanBill_TextChanged(object sender, EventArgs e)
        {
            if (DrpInwardtrasMode.SelectedItem.ToString().ToUpper() == "1 : Sea".ToUpper())
            {
                if (!string.IsNullOrWhiteSpace(TxtOceanBill.Text))
                {
                    lbloblval.Text = TxtOceanBill.Text;
                }
            }
            innonpayment.Update();
            upinnonsummary.Update();
            txtreLoctn.Focus();
        }

      

        protected void btnprevamend_Click(object sender, EventArgs e)
        {

        }

        protected void btnsaveamend_Click(object sender, EventArgs e)
        {
            btnsavesum_Click(null,null);
        }

        protected void btnresetamend_Click(object sender, EventArgs e)
        {

        }

        protected void btnnextamend_Click(object sender, EventArgs e)
        {
            txtupdateindicator.Focus();
        }

        protected void btnprevcancel_Click(object sender, EventArgs e)
        {

        }

        protected void btnsavecancel_Click(object sender, EventArgs e)
        {
            btnsavesum_Click(null,null);
        }

        protected void btnresetcancel_Click(object sender, EventArgs e)
        {

        }

        protected void btnnextcancel_Click(object sender, EventArgs e)
        {

        }

        protected void BtnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("InNONpaymentList.aspx");
        }

        protected void GridStorageLoc_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridStorageLoc.PageIndex = e.NewPageIndex;
            //popupinnonreceiptlocat  ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openReceipt();", true);
            popupinnonstorageloc.Show();
          
            BindStoreLocation();
        }

        protected void GridStorageLoc_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {               
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                //Reference the GridView Row.
                GridViewRow row = GridStorageLoc.Rows[rowIndex];
                if (row != null)
                {
                    var LblCode = row.FindControl("lblCode") as Label;
                    var lblName = row.FindControl("lblName") as Label;
                    var lblName1 = row.FindControl("lblName1") as Label;
                    if ( lblName != null && lblName1 != null)
                    {
                        string requestType = lblName.Text;
                        string status = lblName1.Text;                      
                        txtstrgeloc.Text = "";
                        txtstrgelocdet.Text = "";                    
                        txtstrgeloc.Text = requestType;
                        txtstrgelocdet.Text = status;                     
                    }                   
                }
            }
            innonpayment.Update();
        }

        protected void GridStorageLoc_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridStorageLoc, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void LnkReceipt_Command1(object sender, CommandEventArgs e)
        {
            var lb = (LinkButton)sender;
            var row = (GridViewRow)lb.NamingContainer;
            if (row != null)
            {
                var lblCode1 = row.FindControl("lblName") as Label;
                var lblName1 = row.FindControl("lblName1") as Label;              
                if (lblCode1 != null && lblName1 != null )
                {
                    //Get values
                    string requestor = lblCode1.Text;
                    string requestType = lblName1.Text;                    
                    txtstrgeloc.Text = "";
                    txtstrgelocdet.Text = "";
                    txtstrgeloc.Text = requestor;
                    txtstrgelocdet.Text = requestType;                    
                }
            }
        }

        protected void BtnPrintCIF_Click(object sender, EventArgs e)
        {
            //string qry11 = "select t2.Name,t2.CRUEI,t1.JobId,t1.MSGId,t1.TouchTime,t3.* from InNonHeaderTbl t1,Importer t2,InNonInvoiceDtl t3 where  t1.ImporterCompanyCode=t2.Code and t1.PermitId=t3.PermitId  and t1.PermitId='"+txt_code.Text +"'";
            //obj.dr = obj.ret_dr(qry11);
            //while (obj.dr.Read())
            //{
            //    string FCCurrency = "";
            //    if (obj.dr["FCCurrency"].ToString() == "--Select--")
            //    {
            //        FCCurrency = "";
            //    }
            //    else
            //    {
            //        FCCurrency = obj.dr["FCCurrency"].ToString();
            //    }
            //    string ICCurrency = "";
            //    if (obj.dr["ICCurrency"].ToString() == "--Select--")
            //    {
            //        ICCurrency = "";
            //    }
            //    else
            //    {
            //        ICCurrency = obj.dr["ICCurrency"].ToString();
            //    }
            //    string OTCCurrency = "";
            //    if (obj.dr["OTCCurrency"].ToString() == "--Select--")
            //    {
            //        OTCCurrency = "";
            //    }
            //    else
            //    {
            //        OTCCurrency = obj.dr["OTCCurrency"].ToString();
            //    }
            //    //Dummy data for Invoice (Bill).
            //    string Line = "----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
            //  //  int orderNo = 2303;
            //    DataTable dt = new DataTable();
            //    dt.Columns.AddRange(new DataColumn[7] {
            //           new DataColumn("SNO",  typeof(string)),
            //      new DataColumn("ITEM", typeof(string)),
            //      new DataColumn("CURRENCY", typeof(string)),
            //      new DataColumn("EXCHG. RATE", typeof(string)),
            //      new DataColumn("PERC.",  typeof(string)),
            //      new DataColumn("AMOUNT",  typeof(string)),
            //         new DataColumn("AMOUNT (SGD)",  typeof(string))});
            //    dt.Rows.Add(1, "TOTAL INVOICE", "" + obj.dr["TICurrency"].ToString() + "", "" + obj.dr["TIExRate"].ToString() + "", "", "" + obj.dr["TIAmount"].ToString() + "", "" + obj.dr["TISAmount"].ToString() + "");
            //    dt.Rows.Add(2, "FREIGHT CHARGES", "" + FCCurrency + "", "" + obj.dr["FCExRate"].ToString() + "", "" + obj.dr["FCCharge"].ToString() + "", "" + obj.dr["FCAmount"].ToString() + "", "" + obj.dr["FCSAmount"].ToString() + "");
            //    dt.Rows.Add(3, "INSURANCE", "" + ICCurrency + "", "" + obj.dr["ICExRate"].ToString() + "", "" + obj.dr["ICCharge"].ToString() + "", "" + obj.dr["ICAmount"].ToString() + "", "" + obj.dr["ICSAmount"].ToString() + "");
            //    dt.Rows.Add(4, "OTHER CHARGES", "" + OTCCurrency + "", "" + obj.dr["OTCExRate"].ToString() + "", "" + obj.dr["OTCCharge"].ToString() + "", "" + obj.dr["OTCAmount"].ToString() + "", "" + obj.dr["OTCSAmount"].ToString() + "");
            //    dt.Rows.Add(5, "CUSTOMS VALUE", "", "", "", "", "" + obj.dr["CIFSUMAmount"].ToString() + "");
            //    dt.Rows.Add(6, "GST", "", "", "7.00", "", "" + obj.dr["GSTSUMAmount"].ToString() + "");
            //    using (StringWriter sw = new StringWriter())
            //    {
            //        using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            //        {
            //            StringBuilder sb = new StringBuilder();                        
            //            sb.Append("<font size='1'>");
            //            sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
            //            sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><b>CIF INFORMATION</b></td></tr>");
            //            sb.Append("<tr><td colspan = '2'></td></tr>");
            //            sb.Append("<tr><td><b>COMPANY NAME: </b>");
            //            sb.Append(obj.dr["Name"].ToString());
            //            sb.Append("</td><td align = 'right'><b>JOB NUMBER:  </b>");
            //            sb.Append(obj.dr["JobId"].ToString());
            //            sb.Append(" </td></tr>");
            //            sb.Append("<tr><td><b>COMPANY UEN: </b>");
            //            sb.Append(obj.dr["CRUEI"].ToString());
            //            sb.Append("</td><td align = 'right'><b>JOB CREATED: </b>");
            //            sb.Append(obj.dr["TouchTime"].ToString());
            //            sb.Append(" </td></tr>");
            //            sb.Append("<tr><td><b> </b>");
            //            sb.Append("</td><td align = 'right'><b>MESSAGE ID:    </b>");
            //            sb.Append(obj.dr["MsgId"].ToString());
            //            sb.Append(" </td></tr>");
            //            sb.Append("</table>");
            //            sb.Append(Line);
            //            sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
            //            sb.Append("<tr><td colspan = '2'></td></tr>");
            //            sb.Append("<tr><td><b>INVOICE NUMBER: </b>");
            //            sb.Append(obj.dr["InvoiceNo"].ToString());
            //            sb.Append("</td><td><b>  </b>");
            //            string InvTerm = obj.dr["TermType"].ToString();
            //            sb.Append(" </td></tr>");
            //            sb.Append("<tr><td><b>INVOICE TERM: </b>");
            //            sb.Append(InvTerm);
            //            sb.Append("</td><td><b></b>");
            //            sb.Append(" </td></tr>");
            //            sb.Append("</table>");
            //            sb.Append("<br>");
            //            sb.Append("<br>");
            //            //Generate Invoice (Bill) Items Grid.
            //            sb.Append("<table width='100%' border='1'>");
            //            sb.Append("<tr  align='center'>");
            //            foreach (DataColumn column in dt.Columns)
            //            {
            //                sb.Append("<th>");
            //                sb.Append(column.ColumnName);
            //                sb.Append("</th>");
            //            }
            //            sb.Append("</tr>");
            //            foreach (DataRow row in dt.Rows)
            //            {
            //                sb.Append("<tr align='center'>");
            //                foreach (DataColumn column in dt.Columns)
            //                {
            //                    sb.Append("<td>");
            //                    sb.Append(row[column]);
            //                    sb.Append("</td>");
            //                }
            //                sb.Append("</tr>");
            //            }
            //            sb.Append("</table>");
            //            sb.Append("<table style='width:100%'>");
            //            sb.Append("  <tr>");
            //            sb.Append(" <th></th> ");
            //            sb.Append("  <th></th>");
            //            sb.Append("  <th  align='left'>TOTAL GST</th>");
            //            sb.Append("  <th  align='right'>" + obj.dr["GSTSUMAmount"].ToString() + "</th>");
            //            sb.Append(" </tr>");
            //            sb.Append(" <tr >");
            //            sb.Append("  <td></td> ");
            //            sb.Append("  <td></td>");
            //            sb.Append("  <td align='left'>TOTAL EXCISE DUTY AMOUNT</td> ");
            //            sb.Append("  <td align='right'>0.00</td>");
            //            sb.Append(" </tr>");
            //            sb.Append(" <tr >");
            //            sb.Append(" <td></td> ");
            //            sb.Append(" <td></td>");
            //            sb.Append("  <td align='left'>TOTAL CUSTOMS DUTY AMOUNT</td> ");
            //            sb.Append("  <td align='right'>0.00</td>");
            //            sb.Append("  </tr>");
            //            sb.Append(" <tr >");
            //            sb.Append(" <td></td> ");
            //            sb.Append(" <td></td>");
            //            sb.Append("  <td align='left'>TOTAL OTHER TAX AMOUNT</td> ");
            //            sb.Append("  <td align='right'>0.00</td>");
            //            sb.Append("  </tr>");
            //            sb.Append(" <tr >");
            //            sb.Append(" <td></td> ");
            //            sb.Append(" <td></td>");
            //            sb.Append("  <td align='left'>TOTAL AMOUNT PAYABLE</td> ");
            //            sb.Append("  <td align='right'>0.00</td>");
            //            sb.Append("  </tr>");
            //            sb.Append("</table>");                        
            //            sb.Append("</font>");
            //            //Export HTML String as PDF.
            //            StringReader sr = new StringReader(sb.ToString());
            //            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            //            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            //            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            //            pdfDoc.Open();
            //            htmlparser.Parse(sr);
            //            pdfDoc.Close();
            //            Response.ContentType = "application/pdf";
            //            Response.AddHeader("content-disposition", "attachment;filename=InNon-Invoice.pdf");
            //            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //            Response.Write(pdfDoc);
            //            Response.End();
            //           // innonpayment.Update();
            //        }
            //    }
            //}

            StringBuilder sb = new StringBuilder();
            string qry11 = "select t2.Name,t2.CRUEI,t1.JobId,t1.MSGId,t1.TouchTime,t3.* from InNonHeaderTbl t1,Importer t2,InNonInvoiceDtl t3 where  t1.ImporterCompanyCode=t2.Code and t1.PermitId=t3.PermitId  and t1.PermitId='" + txt_code.Text + "'";
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
                dt.Rows.Add(6, "GST", "", "", "9.00", "", "" + obj.dr["GSTSUMAmount"].ToString() + "");
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
            Response.AddHeader("content-disposition", "attachment;filename=IN-Non-PrintGST.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
        }
        public void ReqValidatePageLoad()
        {
            if (TxttotalOuterPack.Text == "")
            {
                ErrorDes = "Cargo -  Please Enter TOTAL OUTER PACK : ";
                TxttotalOuterPack.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                TxttotalOuterPack.Focus();
            }

            if (DrptotalOuterPack.SelectedItem.Text == "--Select--")
            {
                ErrorDes = "Cargo -  Please Enter TOTAL OUTER PACK UOM : ";
                DrptotalOuterPack.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                DrptotalOuterPack.Focus();
            }
            if (TxtTotalGrossWeight.Text == "")
            {
                ErrorDes = "Cargo -  Please Enter TOTAL GROSS WEIGHT : ";
                TxtTotalGrossWeight.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                TxtTotalGrossWeight.Focus();
            }
            if (DrpTotalGrossWeight.SelectedItem.Text == "--Select--")
            {
                ErrorDes = "Cargo -  Please Enter TOTAL GROSS WEIGHT UOM : ";
                DrpTotalGrossWeight.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                DrpTotalGrossWeight.Focus();
            }            
            
            if (TxtTradeMailID.Text == "")
            {
                ErrorDes = "Header -  Please Enter TradeNet : ";
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
                ErrorDes = ErrorDes + "Invoice -  Please Enter Importer CRUEI : ";
            }
            if (TxtImpName.Text == "")
            {
                ErrorDes = ErrorDes + "Invoice -  Please Enter Importer Name : ";

            }
            if (DrpDecType.SelectedItem.ToString() == "REX : FOR RE-EXPORT")
            {
                if (string.IsNullOrWhiteSpace(TxtExpCode.Text))
                {
                    ErrorDes = ErrorDes + "Party -  Please Enter Expoter Code : ";
                }
                if (string.IsNullOrWhiteSpace(TxtExpCRUEI.Text))
                {
                    ErrorDes = ErrorDes + "Party -  Please Enter Expoter CRUEI : ";
                }
                if (string.IsNullOrWhiteSpace(TxtExpName.Text))
                {
                    ErrorDes = ErrorDes + "Party -  Please Enter Expoter CRUEI : ";
                }
                if (string.IsNullOrWhiteSpace(ConsigneeCode.Text))
                {
                    ErrorDes = ErrorDes + "Party -  Please Enter Consignee Code : ";
                }
                if (string.IsNullOrWhiteSpace(ConsigneeCRUEI.Text))
                {
                    ErrorDes = ErrorDes + "Party -  Please Enter Consignee CRUEI : ";
                }
                if (string.IsNullOrWhiteSpace(ConsigneeName.Text))
                {
                    ErrorDes = ErrorDes + "Party -  Please Enter Consignee Name : ";
                }
                if (string.IsNullOrWhiteSpace(ConsigneeAddress.Text))
                {
                    ErrorDes = ErrorDes + "Party -  Please Enter Consignee Address : ";
                }
                if (string.IsNullOrWhiteSpace(ConsigneeCountry.Text))
                {
                    ErrorDes = ErrorDes + "Party -  Please Enter Consignee Country : ";
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

            if (DrpDecType.SelectedItem.ToString() == "APS : APPROVED PREMISES/SCHEMES" && DrpDecType.SelectedItem.ToString() == "DES : DESTRUCTION" && DrpDecType.SelectedItem.ToString() == "GTR : GST RELIEF (& DUTY EXEMPTION)" && DrpDecType.SelectedItem.ToString() == "SFZ : STORAGE IN FTZ" && DrpDecType.SelectedItem.ToString() == "SHO : SHUT-OUT" &&
                DrpDecType.SelectedItem.ToString() == "TCE : TEMPORARY IMPORT FOR EXHIBITION/AUCTIONS WITHOUT SALES" && DrpDecType.SelectedItem.ToString() == "TCI : TEMPORARY EXPORT / RE-IMPORTED GOODS" && DrpDecType.SelectedItem.ToString() == "TCO : TEMPORARY IMPORT FOR OTHER PURPOSE" && DrpDecType.SelectedItem.ToString() == "TCR : TEMPORARY IMPORT FOR REPAIRS" && DrpDecType.SelectedItem.ToString() == "TCS : TEMPORARY IMPORT FOR EXHIBITION/AUCTIONS WITH SALES")
            {
                if (DrpInwardtrasMode.SelectedItem.ToString() == "--Select--")
                {
                    ErrorDes = ErrorDes + "Item -  Please Choose Inward Transport Mode : ";
                }

            }
            else
            {
                if (DrpDecType.SelectedItem.ToString() != "BKT : BLANKET [INCLUDING BLANKET GST RELIEF (& DUTY EXEMPTION)]")
                {
                    if (TextMode.Text != "N : Not Required")
                    {
                        if (TxtArrivalDate1.Text == "")
                        {
                            ErrorDes = ErrorDes + "Item -  Please Enter Arrival Date : ";
                        }
                    }
                }

            }
            if (!string.IsNullOrWhiteSpace(txthblCargo.Text))
            {
                if (string.IsNullOrWhiteSpace(FrieghtCode.Text))
                {
                    ErrorDes = ErrorDes + "Cargo - Please Enter Freight Forwarder : ";
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
                        if (DrpOutwardtrasMode.Visible == true)
                        {
                            if (DrpOutwardtrasMode.SelectedItem.ToString() == "--Select--")
                            {
                                ErrorDes = ErrorDes + "Invoice -  Please Enter  Outward Transport Mode : ";
                            }
                        }
                        if (txtExStartDate.Visible == true)
                        {
                            if (string.IsNullOrWhiteSpace(txtExStartDate.Text))
                            {
                                ErrorDes = ErrorDes + "Invoice -  Please Enter  Start Date : ";
                            }
                        }
                        if (txtExEndDate.Visible == true)
                        {
                            if (string.IsNullOrWhiteSpace(txtExEndDate.Text))
                            {
                                ErrorDes = ErrorDes + "Invoice -  Please Enter  End Date : ";
                            }
                        }
                    }                   
                    TxtArrivalDate1.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    TxtLoadShort.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    TxtVoyageno.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    TxtVesselName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
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
                    }
                    TxtArrivalDate1.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    TxtLoadShort.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    //TxtConRefNo.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    //TxtTrnsID.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
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
                    }
                    TxtArrivalDate1.BackColor = System.Drawing.Color.CadetBlue;
                    TxtLoadShort.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    txtflight.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    txtaircraft.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
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
                    txtaircraft.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    txtwaybill.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    txtcruei.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    txtName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    TxtImppartyCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    TxtImppartyName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                }
            }
            if (string.IsNullOrWhiteSpace(TxttotalOuterPack.Text))
            {
                ErrorDes = ErrorDes + "Cargo -  Please Enter Outer Pack Qty : ";
            }
            if (DrptotalOuterPack.SelectedItem.ToString() == "--Select--")
            {
                ErrorDes = ErrorDes + "Cargo -  Please Enter Outer Pack UOM : ";
            }
            if (string.IsNullOrWhiteSpace(TxtTotalGrossWeight.Text))
            {
                ErrorDes = ErrorDes + "Cargo -  Please Enter Gross Weight Qty : ";
            }
            if (DrpTotalGrossWeight.SelectedItem.ToString() == "--Select--")
            {
                ErrorDes = ErrorDes + "Cargo -  Please Enter Gross Weight UOM : ";
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
            TxtDecCompCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            TxtDecCompName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            txtreLoctn.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            txtrecloctn.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            txtinvNo.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            txtinvDate1.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
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
            DataTable dt = new DataTable();
            //dt.Columns.Add("Error");
            GridError.DataBind();
            if (!string.IsNullOrWhiteSpace(ErrorDes))
            {
                test = Regex.Split(ErrorDes, ":");                
            }
            if (test != null)
            {
                GridError.DataSource = test;
                GridError.DataBind();
                GridError.Visible = true;
            }
            else
            {
                GridError.Visible = false;
            }
            innonpayment.Update();
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

        protected void GridError_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridError.PageIndex = e.NewPageIndex;
            ReqValidatePageLoad();
        }

        protected void txtorgindate_TextChanged(object sender, EventArgs e)
        {
            //txtorgindate.Text = DateCheck(txtorgindate.Text);
            string curdate = "";
            if (txtorgindate.Text.Length == 10)
            {
                curdate = txtorgindate.Text;
            }
            else if (txtorgindate.Text.Length == 8)
            {
                string date = txtorgindate.Text.Substring(0, 2);
                string month = txtorgindate.Text.Substring(2, 2);
                string year = txtorgindate.Text.Substring(4, 4);                
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
            txtorgindate.Text = curdate;
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
            DrpOutwardtrasMode.ClearSelection();
            DrpOutwardtrasMode.Items.FindByText("--Select--").Selected = true;
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
        public void PartyClr()
        {
            TxtDecCompCode.Text = "";
            TxtDecCompCRUEI.Text = "";
            TxtDecCompName.Text = "";
            TxtDecCompName1.Text = "";
            TxtImpCode.Text = "";
            TxtImpCRUEI.Text = "";
            TxtImpName.Text = "";
            TxtImpName1.Text = "";
            TxtExpCode.Text = "";
            TxtExpCRUEI.Text = "";
            TxtExpName.Text = "";
            TxtExpName1.Text = "";
            InwardCode.Text = "";
            InwardCRUEI.Text = "";
            InwardName.Text = "";
            InwardName1.Text = "";
            OutwardCode.Text = "";
            OutwardCRUEI.Text = "";
            OutwardName.Text = "";
            OutwardName1.Text = "";
            FrieghtCode.Text = "";
            FrieghtCRUEI.Text = "";
            FrieghtName.Text = "";
            FrieghtName1.Text = "";
            ConsigneeCode.Text = "";
            ConsigneeCRUEI.Text = "";
            ConsigneeAddress.Text = "";
            ConsigneeSub.Text = "";
            ConsigneeCountry.Text = "";
            ConsigneeAddress1.Text = "";
            ConsigneeSubDivi.Text = "";
            ConsigneeName.Text = "";
            ConsigneeName1.Text = "";
            ConsigneeCity.Text = "";
            ConsigneePostal.Text = "";
            ClaimantName.Text = "";
            ClaimantCRUEI.Text = "";
            ClaimantName1C.Text = "";
            ClaimantNameC.Text = "";
            ClaimantName1.Text = "";
        }

        public void CargoClr()
        {            
            TxtArrivalDate1.Text = "";
            TxtLoadShort.Text = "";
            TxtLoad.Text = "";
            txthblCargo.Text = "";
            txtflight.Text = "";
            txtaircraft.Text = "";
            txtwaybill.Text = "";
            TxtVoyageno.Text = "";
            TxtVesselName.Text = "";
            TxtOceanBill.Text = "";
            TxtConRefNo.Text = "";
            TxtTrnsID.Text = "";
            txtreLoctn.Text = "";
            txtrelocDeta.Text = "";
            txtrecloctn.Text = "";
            txtrecloctndet.Text = "";
            txtstrgeloc.Text = "";
            txtstrgelocdet.Text = "";
            txtExStartDate.Text = "";
            txtExEndDate.Text = "";
            BlankDate1.Text = "";            
            TxtExpArrivalDate1.Text = "";
            TxtExpLoadShort.Text = "";
            TxtExpLoad.Text = "";
            DrpFinalDesCountry.ClearSelection();
            DrpFinalDesCountry.Items.FindByText("--Select--").Selected = true;
            chkSea.Checked = false;
            OUTWARDFlightN0.Text = "";
            OUTWARDAirREgno.Text = "";
            OUTWARDAirwaybill.Text = "";
            OUTWARDVoyageNo.Text = "";
            OUTWARDVessel.Text = "";
            OUTWARDOcenbill.Text = "";
            txtouthblCargo.Text = "";
            OUTWARDConref.Text = "";
            OUTWARDTransId.Text = "";
            ddpVessel.ClearSelection();
            ddpVessel.Items.FindByText("--Select--").Selected = true;
            txtvesnet.Text = "";
            DroVesslNat.ClearSelection();
            DroVesslNat.Items.FindByText("--Select--").Selected = true;
            txtTowVes.Text = "";
            txtTowVesName.Text = "";
            txtNextprt.Text = "";
            txtNetPrtSer.Text = "";
            txtLasPrt.Text = "";
            txtLasPrtSer.Text = "";
            TxttotalOuterPack.Text = "";
            DrptotalOuterPack.ClearSelection();
            DrptotalOuterPack.Items.FindByText("--Select--").Selected = true;
            TxtTotalGrossWeight.Text = "";
            DrpTotalGrossWeight.ClearSelection();
            DrpTotalGrossWeight.Items.FindByText("--Select--").Selected = true;
        }

        protected void chkSea_CheckedChanged1(object sender, EventArgs e)
        {
            if (chkSea.Checked == true)
            {
                dischargeport.Visible = false;
                txtNextprt.Focus();
            }
            else
            {
                dischargeport.Visible = true;
                DrpFinalDesCountry.Focus();
            }
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

        protected void BtnYes_Click(object sender, EventArgs e)
        {            
            btnsavesum_Click(null, null);
        }

        protected void BtnNo_Click(object sender, EventArgs e)
        {            
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
                DrpOtherUOM.Enabled = false;
                TxtSumOtherTaxRate.Enabled = false;
            }
        }

        protected void DrpOptionalUom_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtOptionalPrice.Text = "0.00";
            string qry11 = "SELECT CurrencyRate FROM Currency where Currency='" + DrpOptionalUom.SelectedItem.ToString() + "'";
            obj.dr = obj.ret_dr(qry11);
            while (obj.dr.Read())
            {
                TxtOptionalPrice.Text = obj.dr[0].ToString();
            }            
            upinnonitem.Update();
        }

        protected void TxtOptionalExchageRate_TextChanged(object sender, EventArgs e)
        {
            if (DrpOptionalUom.SelectedItem.ToString() != "--Select--")
            {
                if (!string.IsNullOrWhiteSpace(TxtOptionalPrice.Text) && !string.IsNullOrWhiteSpace(TxtOptionalExchageRate.Text))
                {
                    decimal deval = Convert.ToDecimal(TxtOptionalPrice.Text) * Convert.ToDecimal(TxtOptionalExchageRate.Text);
                    TxtOptionalSumExRate.Text = Math.Round(deval, 2).ToString("0.00");
                }
            }
            upinnonitem.Update();
        }

        protected void suppyadd_Click1(object sender, EventArgs e)
        {
            string Code = "";
            string qry11 = "SELECT Code FROM INNONSUPPLIERMANUFACTURERPARTY where Code='" + txtcodeinvq.Text + "'";
            obj.dr = obj.ret_dr(qry11);
            while (obj.dr.Read())
            {
                Code = obj.dr[0].ToString();
            }
            if (Code == "")
            {
                string Touch_user = Session["UserId"].ToString();
                string strTime = System.DateTime.Now.ToString("yyyy/MM/dd");
                string StrQuery = ("INSERT INTO [dbo].[INNONSUPPLIERMANUFACTURERPARTY] ([Code],[Name],[Name1],[CRUEI],[TouchUser],[TouchTime]) VALUES ('" + txtcodeinvq.Text + "','" + txtName.Text + "','" + txtName1.Text + "','" + txtcruei.Text + "','" + Touch_user + "',Convert(VARCHAR,'" + strTime + "',108))");
                obj.exec(StrQuery);
                BindGridinx();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Importer Code Already Exist..');", true);               
            }
            TxtImppartyCode.Focus();
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

        protected void BtnExcelUp_Click(object sender, EventArgs e)
        {
            //Container();
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


                    divamend.Attributes["class"] = divCPC.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();

                    divamend.Attributes.Add("class", "flex flex-col justify-center items-center relative  active-stepper");
                    divamend.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");

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


                    divcancel.Attributes["class"] = divCPC.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                    divcancel.Attributes.Add("class", "flex flex-col justify-center items-center relative  active-stepper");
                    divcancel.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
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
                    FileUpload4.SaveAs(path);
                    string Extension = Path.GetExtension(FileUpload4.FileName);
                    // Connection String to Excel Workbook
                    string excelConnectionString = "";
                    switch (Extension)
                    {
                        case ".xls": //Excel 97-03
                            excelConnectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=Excel 8.0", path);
                            break;
                        case ".xlsx": //Excel 07
                            excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0";
                            break;
                    }
                    OleDbConnection connection = new OleDbConnection(excelConnectionString);
                    connection.Open();
                    //connection.ConnectionString = excelConnectionString;                    
                    string sheet1 = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["TABLE_NAME"].ToString();
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
                        string MessageType = "INPDEC", TouchUser = Session["UserId"].ToString();
                        string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        string qry = "INSERT INTO [dbo].[InnonContainerDtl] ([PermitId],[RowNo],[ContainerNo],[Size],[Weight],[SealNo],[MessageType],[TouchUser],[TouchTime]) VALUES ('" + txt_code.Text + "','" + i + "','" + row["ContainerNo"].ToString() + "','" + row["Size"].ToString() + "','" + row["Weight"].ToString() + "','" + row["SealNo"].ToString() + "','" + MessageType + "','" + TouchUser + "','" + strTime + "')";
                        // string query = "insert into booking(JobId,OrderId,TaskType,CusId,DriverID,StartDate,EndDate,Small,Medium,Normal,Odd,Eurosize,Ref,Description,TaskStatus,TouchUser,TouchTime)  values ('" + txt_code.Text + "','" + row["OrderId"].ToString() + "','" + row["TaskType"].ToString() + "','" + row["CusId"].ToString() + "','Idle','" + row["StartDate"].ToString() + "',' " + row["EndDate"].ToString() + "','" + row["Small"].ToString() + "','" + row["Medium"].ToString() + "','" + row["Normal"].ToString() + "','" + row["Odd"].ToString() + "','" + row["Eurosize"].ToString() + "','" + row["Ref"].ToString() + "','" + row["Description"].ToString() + "','" + Status + "','" + Touch_user + "','" + strTime + "')";
                        cmd = new SqlCommand(qry, con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        i++;
                    }
                    Error.Text = "Succesfully Uploaded";
                }
                catch (Exception ex)
                {
                    Error.Text = ex.Message;
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
                    string path = @"C:\Users\Public\Files1\" + FileUpload4.FileName;
                    //FileUpload1.SaveAs(path);
                    string Extension = Path.GetExtension(FileUpload4.FileName);
                    // Connection String to Excel Workbook
                    string excelConnectionString = "";
                    switch (Extension)
                    {
                        case ".xls": //Excel 97-03
                            excelConnectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel 8.0", path);
                            break;
                        case ".xlsx": //Excel 07
                            excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0";
                            break;
                    }
                    OleDbConnection connection = new OleDbConnection();
                    connection.ConnectionString = excelConnectionString;
                    OleDbCommand command = new OleDbCommand("select * from [ItemInfo$]", connection);
                    connection.Open();
                    OleDbDataAdapter adp = new OleDbDataAdapter(command);
                    DataTable dt = new DataTable();
                    dt.Clear();
                    adp.Fill(dt);
                    string MyConnection2 = ConStr.ToString();
                    SqlConnection con = new SqlConnection(MyConnection2);
                    //SqlCommand cmd;
                    /* Loop thorugh dataTable*/
                    int i = 1;
                    con.Open();
                    foreach (DataRow row in dt.Rows)
                    {                        
                        if (row["HS Code"].ToString() != "")
                        {                            
                            string Messagetype = "INPDEC";
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
                            string UnitPriceExrate = "0.00", SumExchangeRate = "0.00", InvoiceCharges = "0.00", CIFFOB = "0.00";
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
                            string StrQuery1 = ("INSERT INTO [dbo].[InNonItemDtl] ([ItemNo],[PermitId],[MessageType],[HSCode],[Description],[DGIndicator],[Contry],[Brand],[Model],[InHAWBOBL],[DutiableQty],[DutiableUOM],[TotalDutiableQty],[TotalDutiableUOM],[InvoiceQuantity],[HSQty],[HSUOM],[AlcoholPer],[InvoiceNo],[ChkUnitPrice],[UnitPrice],[UnitPriceCurrency],[ExchangeRate],[SumExchangeRate],[TotalLineAmount],[InvoiceCharges],[CIFFOB],[OPQty],[OPUOM],[IPQty],[IPUOM],[InPqty],[InPUOM],[ImPQty],[ImPUOM],[PreferentialCode],[GSTRate],[GSTUOM],[GSTAmount],[ExciseDutyRate],[ExciseDutyUOM],[ExciseDutyAmount],[CustomsDutyRate],[CustomsDutyUOM],[CustomsDutyAmount],[OtherTaxRate],[OtherTaxUOM],[OtherTaxAmount],[CurrentLot],[PreviousLot],LSPValue,[Making],[ShippingMarks1],[ShippingMarks2],[ShippingMarks3],[ShippingMarks4],[TouchUser],[TouchTime]) VALUES ('" + i + "','" + txt_code.Text + "','" + Messagetype + "','" + hscode + "','" + description + "','" + DGIndicator + "','" + Country + "','" + Brand + "','" + Model + "','" + InHAWBOBL + "','" + DutyQty + "','" + DutyQtyUOM + "','" + TtlDutyQty + "','" + ttlDutyQtyUOM + "','" + InvoiceQty + "','" + HSQuantity + "','" + HSQuantityUOM + "','" + AlPer + "','" + INVno + "','" + chkUnitPrice + "','" + UnitPrice + "','" + UnitPriceCurency + "','" + UnitPriceExrate + "','" + SumExchangeRate + "','" + TotalLineAmount + "','" + InvoiceCharges + "','" + CIFFOB + "','" + OuterPackQty + "','" + OuterPackQtyUOM + "','" + inPackQty + "','" + inPackQtyUOM + "','" + innerPackQty + "','" + innerPackQtyUOM + "','" + inmostPackQty + "','" + inmostPackQtyUOM + "','" + PerCode + "','" + GSTRAte + "','" + GSTUOM + "','" + GSTAMOUNT + "','" + ExciseRate + "','" + ExciseUOM + "','" + ExciseAmt + "','" + CusRate + "','" + CusUOM + "','" + CusAmt + "','" + OtherRate + "','" + OtherUOM + "','" + OtherAmt + "','" + CurrentLOt + "','" + PrevLot + "','" + LSPValue + "','" + Making + "','" + Ship1 + "','" + Ship2 + "','" + Ship3 + "','" + Ship4 + "','" + Touch_user + "','" + strTime + "')");
                            obj.exec(StrQuery1);                            
                        }
                        obj.closecon();
                        i++;
                        Error.Text = "Succesfully Uploaded";
                    }
                }
                catch (Exception ex)
                {
                    Error.Text = ex.Message;
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
                    //FileUpload1.SaveAs(path);
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
                    OleDbCommand command = new OleDbCommand("select * from [Casc codes$]", connection);
                    connection.Open();
                    OleDbDataAdapter adp = new OleDbDataAdapter(command);
                    DataTable dt = new DataTable();
                    dt.Clear();
                    adp.Fill(dt);
                    command = new OleDbCommand("select * from [ItemInfo$]", connection);
                    OleDbDataAdapter adp1 = new OleDbDataAdapter(command);
                    DataTable dt1 = new DataTable();
                    dt1.Clear();
                    adp1.Fill(dt1);
                    string ProductCode = "", Quantity = "", ProductUOM = "", ProductCode1 = "", Quantity1 = "", ProductUOM1 = "";
                    foreach (DataRow row in dt1.Rows)
                    {                        
                        if (row["HS Code"].ToString() != "")
                        {
                            if (row["CASC Product Code 1"].ToString() == "")
                            {
                                ProductCode = "";
                            }
                            else
                            {
                                ProductCode = row["CASC Product Code 1"].ToString();
                            }

                            if (row["CASC Product Code 1 Qty"].ToString() == "")
                            {
                                Quantity = "0.00";
                            }
                            else
                            {
                                Quantity = row["CASC Product Code 1 Qty"].ToString();
                            }

                            if (row["CASC Product Code 1 UOM"].ToString() == "")
                            {
                                ProductUOM = "--Select--";
                            }
                            else
                            {
                                ProductUOM = row["CASC Product Code 1 UOM"].ToString();
                            }

                            if (row["CASC Product Code 2"].ToString() == "")
                            {
                                ProductCode1 = "";
                            }
                            else
                            {
                                ProductCode1 = row["CASC Product Code 2"].ToString();
                            }

                            if (row["CASC Product Code 2 Qty"].ToString() == "")
                            {
                                Quantity = "0.00";
                            }
                            else
                            {
                                Quantity = row["CASC Product Code 2 Qty"].ToString();
                            }

                            if (row["CASC Product Code 2 UOM"].ToString() == "")
                            {
                                ProductUOM = "--Select--";
                            }
                            else
                            {
                                ProductUOM = row["CASC Product Code 2 UOM"].ToString();
                            }
                        }
                    }
                    string MyConnection2 = ConStr.ToString();
                    SqlConnection con = new SqlConnection(MyConnection2);                   
                    /* Loop thorugh dataTable*/                    
                    con.Open();
                    foreach (DataRow row in dt.Rows)
                    {
                        int p1 = 1;
                        if (row["Item Number"].ToString() != "")
                        {
                            string PermitId = "KNN001010";
                            string Messagetype = "INPDEC";
                            string Touch_user = Session["UserId"].ToString();
                            string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            string DecimalVal = "0.00";
                            string nullval = "Null";
                            string uom = "--Select--";
                            if (row["CascID"].ToString() == "Casc1")
                            {
                                nullval = ProductCode;
                                DecimalVal = Quantity;
                                uom = ProductUOM;
                            }
                            else if (row["CascID"].ToString() == "Casc1")
                            {
                                nullval = ProductCode1;
                                DecimalVal = Quantity1;
                                uom = ProductUOM1;
                            }
                            string StrQuery1 = ("INSERT INTO [dbo].[INNONCASCDtl] (ItemNo,[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId]) VALUES ('" + row["Item Number"].ToString() + "','" + nullval + "','" + DecimalVal + "','" + uom + "','" + p1 + "','" + row["Code 1"].ToString() + "','" + row["Code 2"].ToString() + "','" + row["Code 3"].ToString() + "','" + PermitId + "','" + Messagetype + "','" + Touch_user + "','" + strTime + "','" + row["CascID"].ToString() + "')");
                            obj.exec(StrQuery1);
                            p1++;
                        }
                        obj.closecon();
                        Error.Text = "Succesfully Uploaded";
                    }
                }
                catch (Exception ex)
                {
                    Error.Text = ex.Message;
                }
            }
        }

        protected void txtExStartDate_TextChanged(object sender, EventArgs e)
        {
            txtExStartDate.Text = DateCheck(txtExStartDate.Text);
            if (txtExEndDate.Visible == true)
            {
                txtExEndDate.Focus();
            }
            else
            {
                btnprevcargo.Focus();
            }
        }

        protected void txtExEndDate_TextChanged(object sender, EventArgs e)
        {
            txtExEndDate.Text = DateCheck(txtExEndDate.Text);
            TxtArrivalDate1.Focus();
        }

        protected void ClaimantGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {                    
                    int rowIndex = Convert.ToInt32(e.CommandArgument);
                    //Reference the GridView Row.
                    GridViewRow row = ClaimantGrid.Rows[rowIndex];
                    if (row != null)
                    {                        
                        var lblCode1 = row.FindControl("lblname") as Label;
                        var lblName1 = row.FindControl("lblName1") as Label;
                        var lblName2 = row.FindControl("lblName2") as Label;
                        var cruei1 = row.FindControl("lblCRUEI") as Label;
                        var lblName11 = row.FindControl("lblCName") as Label;
                        var claimantname = row.FindControl("lblCName1") as Label;                
                        //Get values
                        string requestor = lblCode1.Text;
                        string requestType = claimantname.Text;
                        string status = lblName2.Text;
                        string crueis = cruei1.Text;
                        string claimantName = lblName11.Text;
                        string claimantName1 =lblName1.Text; 
                        ClaimantName.Text = requestor;
                        ClaimantName1C.Text = requestType;
                        ClaimantCRUEI.Text = crueis;
                        ClaimantName1.Text = claimantName1;
                        ClaimantNameC.Text = claimantName;
                        ClaimantName2.Text = status;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            innonpayment.Update();
        }

        protected void ClaimantGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(ClaimantGrid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void txttrdremrk_TextChanged(object sender, EventArgs e)
        {
            lbltracunt.Text = "(" + txttrdremrk.Text.Length.ToString() + " / 1024 Characters)"; 
        }

        protected void OUTWARDOcenbill_TextChanged(object sender, EventArgs e)
        {
            lbloutobls.Text = OUTWARDOcenbill.Text;
        }

        protected void OUTWARDAirwaybill_TextChanged(object sender, EventArgs e)
        {
            lbloutobls.Text = OUTWARDAirwaybill.Text;
           
        }
        protected void btnprev_Click(object sender, EventArgs e)
        {
            int itemno1 = Convert.ToInt32(TxtSerialNo.Text);

            int id = itemno1 - 1;
            string ID = id.ToString();


            // string strBindTxtBox = "select * from [InNonItemDtl] where ItemNo='" + ID + "' and PermitId='" + Invoice + "'";

            string stra = "select Id,Name from [CommonMaster] where TypeId='12' and StatusID=1 order by Name";
            obj.dr = obj.ret_dr(stra);
            DrpMaking.DataSource = obj.dr;
            DrpMaking.DataTextField = "Name";
            DrpMaking.DataValueField = "Id";
            DrpMaking.DataBind();
            obj.closecon();
            DrpMaking.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));

            string Invoice = txt_code.Text;
            string striW = "select * from [InNonInvoiceDtl] where MessageType='INPDEC' AND PermitId='" + Invoice + "'  order by InvoiceNo";
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

            string strBindTxtBox = "select * from [InNonItemDtl] where ItemNo='" + ID + "' and PermitId='" + Invoice + "'";
            obj.dr = obj.ret_dr(strBindTxtBox);
            while (obj.dr.Read())
            {
                TxtSerialNo.Text = obj.dr["ItemNo"].ToString();
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
                TxtModel.Text = obj.dr["Model"].ToString();


                if (!string.IsNullOrWhiteSpace(obj.dr["Vehicletype"].ToString()))
                {
                    DrpVehicleType.ClearSelection();
                    DrpVehicleType.Items.FindByText(obj.dr["Vehicletype"].ToString()).Selected = true;
                }
                else
                {
                    DrpVehicleType.ClearSelection();
                    DrpVehicleType.Items.FindByText("--Select--").Selected = true;
                }

                txtengine.Text = obj.dr["Enginecapacity"].ToString();

                if (!string.IsNullOrWhiteSpace(obj.dr["Engineuom"].ToString()))
                {
                    DrpVehicleCapacity.ClearSelection();
                    DrpVehicleCapacity.Items.FindByText(obj.dr["Engineuom"].ToString()).Selected = true;
                }
                else
                {
                    DrpVehicleCapacity.ClearSelection();
                    DrpVehicleCapacity.Items.FindByText("--Select--").Selected = true;
                }

                DateTime orgindate = Convert.ToDateTime(null);
                if (obj.dr["Orginregdate"].ToString() != "")
                {

                    txtorgindate.Text = Convert.ToDateTime(obj.dr["Orginregdate"].ToString()).ToString("dd/MM/yyyy");
                }
                else
                {

                    txtorgindate.Text = "";

                }

                txtlsp.Text = obj.dr["LSPValue"].ToString();

                TxtHAWB.Items.Add(obj.dr["InHAWBOBL"].ToString());
                txtOutHAWB1.Items.Add(obj.dr["OutHAWBOBL"].ToString());
                TxtTotalDutiableQuantity.Text = obj.dr["DutiableQty"].ToString();
                TDQUOM.ClearSelection();
                TDQUOM.Items.FindByText(obj.dr["DutiableUOM"].ToString()).Selected = true;
                //TDQUOM.SelectedItem.Text = obj.dr[13].ToString();
                txttotDutiableQty.Text = obj.dr["TotalDutiableQty"].ToString();
                ddptotDutiableQty.ClearSelection();
                ddptotDutiableQty.Items.FindByText(obj.dr["TotalDutiableUOM"].ToString()).Selected = true;
                TxtInvQty.Text = obj.dr["InvoiceQuantity"].ToString();
                TxtHSQuantity.Text = obj.dr["HSQty"].ToString();

                // HSQTYUOM.SelectedItem.Text = obj.dr[16].ToString();
                HSQTYUOM.ClearSelection();
                HSQTYUOM.Items.FindByText(obj.dr["HSUOM"].ToString()).Selected = true;
                txtAlcoholPer.Text = obj.dr["AlcoholPer"].ToString();
                DrpInvoiceNo.ClearSelection();
                string striW1 = "select * from [InNonInvoiceDtl] where MessageType='INPDEC' AND PermitId='" + Invoice + "' and  InvoiceNo='" + obj.dr["InvoiceNo"].ToString() + "' order by InvoiceNo";
                InnonPaymentClass objinv = new InnonPaymentClass();
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

                TxtUnitPrice.Text = obj.dr["UnitPrice"].ToString();
                DRPCurrency.ClearSelection();
                DRPCurrency.Items.FindByText(obj.dr["UnitPriceCurrency"].ToString()).Selected = true;
                //  DRPCurrency.SelectedItem.Text = obj.dr[19].ToString();
                TxtExchangeRate.Text = obj.dr["ExchangeRate"].ToString();
                TxtSumExRate.Text = obj.dr["SumExchangeRate"].ToString();
                TxtTotalLineAmount.Text = obj.dr["TotalLineAmount"].ToString();
                TxtTotalLineCharges.Text = obj.dr["InvoiceCharges"].ToString();
                TxtCIFFOB.Text = obj.dr["CIFFOB"].ToString();
                if (!string.IsNullOrWhiteSpace(obj.dr["OptionalChrgeUOM"].ToString()))
                {
                    if (obj.dr["OptionalChrgeUOM"].ToString() != "--Select--")
                    {
                        DrpOptionalUom.ClearSelection();
                        DrpOptionalUom.Items.FindByText(obj.dr["OptionalChrgeUOM"].ToString()).Selected = true;
                    }
                }
                TxtOptionalPrice.Text = obj.dr["Optioncahrge"].ToString();
                TxtOptionalExchageRate.Text = obj.dr["OptionalSumtotal"].ToString();
                TxtOptionalSumExRate.Text = obj.dr["OptionalSumExchage"].ToString();

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

                if (Convert.ToDecimal(obj.dr["OPQty"].ToString()) > 0)
                {
                    PackingInfo.Visible = true;
                }


                DRPOPQUOM.ClearSelection();
                DRPOPQUOM.Items.FindByText(obj.dr["OPUOM"].ToString()).Selected = true;
                // DRPOPQUOM.SelectedItem.Text = obj.dr[26].ToString();
                TxtIPQty.Text = Math.Round(Convert.ToDecimal(obj.dr["IPQty"].ToString()), 0).ToString();

                DRPIPQUOM.ClearSelection();
                DRPIPQUOM.Items.FindByText(obj.dr["IPUOM"].ToString()).Selected = true;
                /// DRPIPQUOM.SelectedItem.Text = obj.dr[28].ToString();
                TxtINPQty.Text = Math.Round(Convert.ToDecimal(obj.dr["InPqty"].ToString()), 0).ToString();

                DRPINNPQUOM.ClearSelection();
                DRPINNPQUOM.Items.FindByText(obj.dr["InPUOM"].ToString()).Selected = true;
                //DRPINNPQUOM.SelectedItem.Text = obj.dr[30].ToString();
                TxtIMPQty.Text = Math.Round(Convert.ToDecimal(obj.dr["ImPQty"].ToString()), 0).ToString();

                DRPIMPQUOM.ClearSelection();
                DRPIMPQUOM.Items.FindByText(obj.dr["ImPUOM"].ToString()).Selected = true;
                // DRPIMPQUOM.SelectedItem.Text = obj.dr[32].ToString();

                DrpPreferentialCode.ClearSelection();
                DrpPreferentialCode.Items.FindByText(obj.dr["PreferentialCode"].ToString()).Selected = true;
                //DrpPreferentialCode.SelectedItem.Text = obj.dr[33].ToString();
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
                //  DrpOtherUOM.SelectedItem.Text = obj.dr[44].ToString();
                TxtSumOtherTaxRate.Text = obj.dr["OtherTaxAmount"].ToString();

                if (obj.dr["CurrentLot"].ToString() == "")
                {
                    LOTID.Visible = true;
                }
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
                TxtPreviousLot.Text = obj.dr["PreviousLot"].ToString();

                DrpMaking.ClearSelection();
                DrpMaking.Items.FindByText(obj.dr["Making"].ToString()).Selected = true;
                if (!string.IsNullOrWhiteSpace(obj.dr["ShippingMarks1"].ToString()))
                {
                    ShippMarkDiv.Visible = true;
                }

                txtShippingMarks1.Text = obj.dr["ShippingMarks1"].ToString();
                txtShippingMarks2.Text = obj.dr["ShippingMarks2"].ToString();
                txtShippingMarks3.Text = obj.dr["ShippingMarks3"].ToString();
                txtShippingMarks4.Text = obj.dr["ShippingMarks4"].ToString();
                editbindProduct1(ID);
                editbindProduct2(ID);
                editbindProduct3(ID);
                editbindProduct4(ID);
                editbindProduct5(ID);

                string co = "select * from [Country] where CountryCode='" + TxtCountryItem.Text + "'";
                obj.dr = obj.ret_dr(co);
                while (obj.dr.Read())
                {
                    txtcname.Text = obj.dr["Description"].ToString();
                }
                DrpInvoiceNo_SelectedIndexChanged(null, null);
                ItemAddGrid.Visible = true;
                ItemDiv.Visible = true;
                BtnAddNEWItem.Visible = false;
            }

        }

        protected void btnnxt_Click(object sender, EventArgs e)
        {

            int itemno1 = Convert.ToInt32(TxtSerialNo.Text);

            int id = itemno1 + 1;
            string ID = id.ToString();


            //  string strBindTxtBox = "select * from [InNonItemDtl] where ItemNo='" + ID + "' and PermitId='" + Invoice + "'";
            string stra = "select Id,Name from [CommonMaster] where TypeId='12' and StatusID=1 order by Name";
            obj.dr = obj.ret_dr(stra);
            DrpMaking.DataSource = obj.dr;
            DrpMaking.DataTextField = "Name";
            DrpMaking.DataValueField = "Id";
            DrpMaking.DataBind();
            obj.closecon();
            DrpMaking.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));

            string Invoice = txt_code.Text;
            string striW = "select * from [InNonInvoiceDtl] where MessageType='INPDEC' AND PermitId='" + Invoice + "'  order by InvoiceNo";
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

            string strBindTxtBox = "select * from [InNonItemDtl] where ItemNo='" + ID + "' and PermitId='" + Invoice + "'";
            obj.dr = obj.ret_dr(strBindTxtBox);
            while (obj.dr.Read())
            {
                TxtSerialNo.Text = obj.dr["ItemNo"].ToString();
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
                TxtModel.Text = obj.dr["Model"].ToString();


                if (!string.IsNullOrWhiteSpace(obj.dr["Vehicletype"].ToString()))
                {
                    DrpVehicleType.ClearSelection();
                    DrpVehicleType.Items.FindByText(obj.dr["Vehicletype"].ToString()).Selected = true;
                }
                else
                {
                    DrpVehicleType.ClearSelection();
                    DrpVehicleType.Items.FindByText("--Select--").Selected = true;
                }

                txtengine.Text = obj.dr["Enginecapacity"].ToString();

                if (!string.IsNullOrWhiteSpace(obj.dr["Engineuom"].ToString()))
                {
                    DrpVehicleCapacity.ClearSelection();
                    DrpVehicleCapacity.Items.FindByText(obj.dr["Engineuom"].ToString()).Selected = true;
                }
                else
                {
                    DrpVehicleCapacity.ClearSelection();
                    DrpVehicleCapacity.Items.FindByText("--Select--").Selected = true;
                }

                DateTime orgindate = Convert.ToDateTime(null);
                if (obj.dr["Orginregdate"].ToString() != "")
                {

                    txtorgindate.Text = Convert.ToDateTime(obj.dr["Orginregdate"].ToString()).ToString("dd/MM/yyyy");
                }
                else
                {

                    txtorgindate.Text = "";

                }

                txtlsp.Text = obj.dr["LSPValue"].ToString();

                TxtHAWB.Items.Add(obj.dr["InHAWBOBL"].ToString());
                txtOutHAWB1.Items.Add(obj.dr["OutHAWBOBL"].ToString());
                TxtTotalDutiableQuantity.Text = obj.dr["DutiableQty"].ToString();
                TDQUOM.ClearSelection();
                TDQUOM.Items.FindByText(obj.dr["DutiableUOM"].ToString()).Selected = true;
                //TDQUOM.SelectedItem.Text = obj.dr[13].ToString();
                txttotDutiableQty.Text = obj.dr["TotalDutiableQty"].ToString();
                ddptotDutiableQty.ClearSelection();
                ddptotDutiableQty.Items.FindByText(obj.dr["TotalDutiableUOM"].ToString()).Selected = true;
                TxtInvQty.Text = obj.dr["InvoiceQuantity"].ToString();
                TxtHSQuantity.Text = obj.dr["HSQty"].ToString();

                // HSQTYUOM.SelectedItem.Text = obj.dr[16].ToString();
                HSQTYUOM.ClearSelection();
                HSQTYUOM.Items.FindByText(obj.dr["HSUOM"].ToString()).Selected = true;
                txtAlcoholPer.Text = obj.dr["AlcoholPer"].ToString();
                DrpInvoiceNo.ClearSelection();
                string striW1 = "select * from [InNonInvoiceDtl] where MessageType='INPDEC' AND PermitId='" + Invoice + "' and  InvoiceNo='" + obj.dr["InvoiceNo"].ToString() + "' order by InvoiceNo";
                InnonPaymentClass objinv = new InnonPaymentClass();
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

                TxtUnitPrice.Text = obj.dr["UnitPrice"].ToString();
                DRPCurrency.ClearSelection();
                DRPCurrency.Items.FindByText(obj.dr["UnitPriceCurrency"].ToString()).Selected = true;
                //  DRPCurrency.SelectedItem.Text = obj.dr[19].ToString();
                TxtExchangeRate.Text = obj.dr["ExchangeRate"].ToString();
                TxtSumExRate.Text = obj.dr["SumExchangeRate"].ToString();
                TxtTotalLineAmount.Text = obj.dr["TotalLineAmount"].ToString();
                TxtTotalLineCharges.Text = obj.dr["InvoiceCharges"].ToString();
                TxtCIFFOB.Text = obj.dr["CIFFOB"].ToString();
                if (!string.IsNullOrWhiteSpace(obj.dr["OptionalChrgeUOM"].ToString()))
                {
                    if (obj.dr["OptionalChrgeUOM"].ToString() != "--Select--")
                    {
                        DrpOptionalUom.ClearSelection();
                        DrpOptionalUom.Items.FindByText(obj.dr["OptionalChrgeUOM"].ToString()).Selected = true;
                    }
                }
                TxtOptionalPrice.Text = obj.dr["Optioncahrge"].ToString();
                TxtOptionalExchageRate.Text = obj.dr["OptionalSumtotal"].ToString();
                TxtOptionalSumExRate.Text = obj.dr["OptionalSumExchage"].ToString();

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

                if (Convert.ToDecimal(obj.dr["OPQty"].ToString()) > 0)
                {
                    PackingInfo.Visible = true;
                }


                DRPOPQUOM.ClearSelection();
                DRPOPQUOM.Items.FindByText(obj.dr["OPUOM"].ToString()).Selected = true;
                // DRPOPQUOM.SelectedItem.Text = obj.dr[26].ToString();
                TxtIPQty.Text = Math.Round(Convert.ToDecimal(obj.dr["IPQty"].ToString()), 0).ToString();

                DRPIPQUOM.ClearSelection();
                DRPIPQUOM.Items.FindByText(obj.dr["IPUOM"].ToString()).Selected = true;
                /// DRPIPQUOM.SelectedItem.Text = obj.dr[28].ToString();
                TxtINPQty.Text = Math.Round(Convert.ToDecimal(obj.dr["InPqty"].ToString()), 0).ToString();

                DRPINNPQUOM.ClearSelection();
                DRPINNPQUOM.Items.FindByText(obj.dr["InPUOM"].ToString()).Selected = true;
                //DRPINNPQUOM.SelectedItem.Text = obj.dr[30].ToString();
                TxtIMPQty.Text = Math.Round(Convert.ToDecimal(obj.dr["ImPQty"].ToString()), 0).ToString();

                DRPIMPQUOM.ClearSelection();
                DRPIMPQUOM.Items.FindByText(obj.dr["ImPUOM"].ToString()).Selected = true;
                // DRPIMPQUOM.SelectedItem.Text = obj.dr[32].ToString();

                DrpPreferentialCode.ClearSelection();
                DrpPreferentialCode.Items.FindByText(obj.dr["PreferentialCode"].ToString()).Selected = true;
                //DrpPreferentialCode.SelectedItem.Text = obj.dr[33].ToString();
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
                //  DrpOtherUOM.SelectedItem.Text = obj.dr[44].ToString();
                TxtSumOtherTaxRate.Text = obj.dr["OtherTaxAmount"].ToString();

                if (obj.dr["CurrentLot"].ToString() == "")
                {
                    LOTID.Visible = true;
                }
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
                TxtPreviousLot.Text = obj.dr["PreviousLot"].ToString();

                DrpMaking.ClearSelection();
                DrpMaking.Items.FindByText(obj.dr["Making"].ToString()).Selected = true;
                if (!string.IsNullOrWhiteSpace(obj.dr["ShippingMarks1"].ToString()))
                {
                    ShippMarkDiv.Visible = true;
                }

                txtShippingMarks1.Text = obj.dr["ShippingMarks1"].ToString();
                txtShippingMarks2.Text = obj.dr["ShippingMarks2"].ToString();
                txtShippingMarks3.Text = obj.dr["ShippingMarks3"].ToString();
                txtShippingMarks4.Text = obj.dr["ShippingMarks4"].ToString();
                editbindProduct1(ID);
                editbindProduct2(ID);
                editbindProduct3(ID);
                editbindProduct4(ID);
                editbindProduct5(ID);

                string co = "select * from [Country] where CountryCode='" + TxtCountryItem.Text + "'";
                obj.dr = obj.ret_dr(co);
                while (obj.dr.Read())
                {
                    txtcname.Text = obj.dr["Description"].ToString();
                }
                DrpInvoiceNo_SelectedIndexChanged(null, null);
                ItemAddGrid.Visible = true;
                ItemDiv.Visible = true;
                BtnAddNEWItem.Visible = false;
            }

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

            //double T1, T2, T3, T4, T5;
            //bool A = double.TryParse(TxtOPQty.Text.Trim(), out T1);
            //bool B = double.TryParse(TxtIPQty.Text.Trim(), out T2);
            //bool C = double.TryParse(TxtINPQty.Text.Trim(), out T3);
            //bool D = double.TryParse(TxtIMPQty.Text.Trim(), out T4);
            //bool F = double.TryParse(TxtTotalDutiableQuantity.Text.Trim(), out T5);
            ////   bool G = double.TryParse(TxtIMPQty.Text.Trim(), out T9);

            //duticalc(T1, T2, T3, T4, T5);
            //txtAlcoholPer_TextChanged(null, null);
            if (!string.IsNullOrWhiteSpace(txttotDutiableQty.Text))
            {
                if (!TxtHSCodeItem.Text.Trim().StartsWith("87"))
                {
                    decimal val = Convert.ToDecimal(txttotDutiableQty.Text) * Convert.ToDecimal(TxtExciseDutyRate.Text);
                    TxtSumExciseDuty.Text = val.ToString();
                }                
            }
            txtAlcoholPer_TextChanged(null, null);
            ddptotDutiableQty.Focus();
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

            if (SchemeGrid.Rows.Count > 0) // Replace "CWCGrid" with your actual GridView ID
            {
                int lastRowIndex = SchemeGrid.Rows.Count - 1;

                // Replace these with your actual control IDs from the grid
                TextBox box1 = (TextBox)SchemeGrid.Rows[lastRowIndex].Cells[1].FindControl("TextBox1");
                TextBox box2 = (TextBox)SchemeGrid.Rows[lastRowIndex].Cells[2].FindControl("TextBox2");
                TextBox box3 = (TextBox)SchemeGrid.Rows[lastRowIndex].Cells[3].FindControl("TextBox3");

                if (string.IsNullOrWhiteSpace(box1.Text) )
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please fill all fields in the previous row before adding a new one.');", true);
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
            string qry = "select RowNo as RowNumber,ProcessingCode1,ProcessingCode2,ProcessingCode3 from InNonHeaderTbl a,InNonCPCDtl b where a.PermitId=b.PermitId and b.CPCType='SCHEME' and a.PermitId='" + txt_code.Text + "'";
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
                Chkscheme1.Checked = false;
                SCHEME.Visible = false;
            }
            else
            {
                Chkscheme1.Checked = true;
                SCHEME.Visible = true;
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

            if (StsGrid.Rows.Count > 0) // Replace "CWCGrid" with your actual GridView ID
            {
                int lastRowIndex = StsGrid.Rows.Count - 1;

                // Replace these with your actual control IDs from the grid
                TextBox box1 = (TextBox)StsGrid.Rows[lastRowIndex].Cells[1].FindControl("TextBox1");
                TextBox box2 = (TextBox)StsGrid.Rows[lastRowIndex].Cells[2].FindControl("TextBox2");
                TextBox box3 = (TextBox)StsGrid.Rows[lastRowIndex].Cells[3].FindControl("TextBox3");

                if (string.IsNullOrWhiteSpace(box1.Text) )
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please fill all fields in the previous row before adding a new one.');", true);
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
            string qry = "select RowNo as RowNumber,ProcessingCode1,ProcessingCode2,ProcessingCode3 from InNonHeaderTbl a,InNonCPCDtl b where a.PermitId=b.PermitId and b.CPCType='STS' and a.PermitId='" + txt_code.Text + "'";
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

            if (StscwcGrid.Rows.Count > 0) // Replace "CWCGrid" with your actual GridView ID
            {
                int lastRowIndex = StscwcGrid.Rows.Count - 1;

                // Replace these with your actual control IDs from the grid
                TextBox box1 = (TextBox)StscwcGrid.Rows[lastRowIndex].Cells[1].FindControl("TextBox1");
                TextBox box2 = (TextBox)StscwcGrid.Rows[lastRowIndex].Cells[2].FindControl("TextBox2");
                TextBox box3 = (TextBox)StscwcGrid.Rows[lastRowIndex].Cells[3].FindControl("TextBox3");

                if (string.IsNullOrWhiteSpace(box1.Text) )
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please fill all fields in the previous row before adding a new one.');", true);
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
            string qry = "select RowNo as RowNumber,ProcessingCode1,ProcessingCode2,ProcessingCode3 from InNonHeaderTbl a,InNonCPCDtl b where a.PermitId=b.PermitId and b.CPCType='STSANDCWC' and a.PermitId='" + txt_code.Text + "'";
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

            // Check if current rows are already 5
            if (dtCurrent != null && dtCurrent.Rows.Count >= 5)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You can only add up to 5 rows.');", true);
                return;
            }

            if (IcGrid.Rows.Count > 0) // Replace "CWCGrid" with your actual GridView ID
            {
                int lastRowIndex = IcGrid.Rows.Count - 1;

                // Replace these with your actual control IDs from the grid
                TextBox box1 = (TextBox)IcGrid.Rows[lastRowIndex].Cells[1].FindControl("TextBox1");
                TextBox box2 = (TextBox)IcGrid.Rows[lastRowIndex].Cells[2].FindControl("TextBox2");
                TextBox box3 = (TextBox)IcGrid.Rows[lastRowIndex].Cells[3].FindControl("TextBox3");

                if (string.IsNullOrWhiteSpace(box1.Text) )
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please fill all fields in the previous row before adding a new one.');", true);
                    return;
                }
            }

            if (dtCurrent == null || dtCurrent.Rows.Count == 0)
            {
                SetInitialRow2cpIc();
            }
            else
            {
                AddNewRowToGrid2cpIc();
            }

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

        protected void txtdocserach_TextChanged(object sender, EventArgs e)
        {
            string query = "";
            if (txtdocserach.Text == "")
            {
                query = "SELECT Id, DocumentType, Name, FileSizeKB FROM InNonFile WHERE InPaymentId = '" + MsgNO + "'";


            }
            else
            {
                query = "SELECT Id, DocumentType, Name, FileSizeKB FROM InNonFile WHERE DocumentType like'%" + txtdocserach.Text + "%' and DocumentType like'%" + txtdocserach.Text + "%' AND  InPaymentId = '" + MsgNO + "'";

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

        protected void lblName_Command(object sender, CommandEventArgs e)
        {
            var lb = (LinkButton)sender;
            var row = (GridViewRow)lb.NamingContainer;
            if (row != null)
            {
                var lblCode1 = row.FindControl("lblName") as LinkButton;


                if (lblCode1 != null)
                {
                    //Get values
                    string requestor = lblCode1.Text;


                    string path = @"C:\Users\Public\IMG\" + requestor;

                    Response.ContentType = "application/octet-stream";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(path));
                    Response.TransmitFile(path);
                    Response.End();



                }

            }
        }

        protected void txtstorageSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable _objdt = new DataTable();
            _objdt = GetStrgLocSerach(txtstorageSearch.Text.Replace("'", "''"));
            if (_objdt.Rows.Count > 0)
            {
                GridStorageLoc.DataSource = _objdt;
                GridStorageLoc.DataBind();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openReceipt();", true);
            }
            popupinnonstorageloc.Show();
        }

        protected void HSCodeGridItem_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            HSCodeGridItem.PageIndex = e.NewPageIndex;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openHSCode();", true);
            BindHSCode();
        }

        protected void lnkcopydesc_Click(object sender, EventArgs e)
        {
            obj.exec("update InNonItemDtl set Description='" + TxtDescription.Text + "' where PermitId='" + txt_code.Text + "'");
            obj.closecon();
            BindItemMaster();
        }

        protected void lnkcopybrand_Click(object sender, EventArgs e)
        {
            obj.exec("update InNonItemDtl set Brand='" + TxtBrand.Text + "' where PermitId='" + txt_code.Text + "'");
            obj.closecon();
            BindItemMaster();

        }

        protected void lnkcopymodel_Click(object sender, EventArgs e)
        {
            obj.exec("update InNonItemDtl set Model='" + TxtModel.Text + "' where PermitId='" + txt_code.Text + "'");
            obj.closecon();
            BindItemMaster();
        }

        protected void BtnItemDeleteAll_Click(object sender, EventArgs e)
        {
            obj.exec("delete InNonItemDtl  where PermitId='" + txt_code.Text + "'");
            obj.closecon();
            BindItemMaster();
        }

        protected void BtnItemEditAll_Click(object sender, EventArgs e)
        {
            string strBindTxtBox = "select * from [InNonItemDtl] where permitid='" + txt_code.Text + "'";
            obj.dr = obj.ret_dr(strBindTxtBox);
            while (obj.dr.Read())
            {
                TxtSerialNo.Text = obj.dr["ItemNo"].ToString();
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
                TxtModel.Text = obj.dr["Model"].ToString();


                if (!string.IsNullOrWhiteSpace(obj.dr["Vehicletype"].ToString()))
                {
                    DrpVehicleType.ClearSelection();
                    DrpVehicleType.Items.FindByText(obj.dr["Vehicletype"].ToString()).Selected = true;
                }
                else
                {
                    DrpVehicleType.ClearSelection();
                    DrpVehicleType.Items.FindByText("--Select--").Selected = true;
                }

                txtengine.Text = obj.dr["Enginecapacity"].ToString();

                if (!string.IsNullOrWhiteSpace(obj.dr["Engineuom"].ToString()))
                {
                    DrpVehicleCapacity.ClearSelection();
                    DrpVehicleCapacity.Items.FindByText(obj.dr["Engineuom"].ToString()).Selected = true;
                }
                else
                {
                    DrpVehicleCapacity.ClearSelection();
                    DrpVehicleCapacity.Items.FindByText("--Select--").Selected = true;
                }

                DateTime orgindate = Convert.ToDateTime(null);
                if (obj.dr["Orginregdate"].ToString() != "")
                {

                    txtorgindate.Text = Convert.ToDateTime(obj.dr["Orginregdate"].ToString()).ToString("dd/MM/yyyy");
                }
                else
                {

                    txtorgindate.Text = "";

                }

                txtlsp.Text = obj.dr["LSPValue"].ToString();

                TxtHAWB.Items.Add(obj.dr["InHAWBOBL"].ToString());
                txtOutHAWB1.Items.Add(obj.dr["OutHAWBOBL"].ToString());
                TxtTotalDutiableQuantity.Text = obj.dr["DutiableQty"].ToString();
                TDQUOM.ClearSelection();
                TDQUOM.Items.FindByText(obj.dr["DutiableUOM"].ToString()).Selected = true;
                //TDQUOM.SelectedItem.Text = obj.dr[13].ToString();
                txttotDutiableQty.Text = obj.dr["TotalDutiableQty"].ToString();
                ddptotDutiableQty.ClearSelection();
                ddptotDutiableQty.Items.FindByText(obj.dr["TotalDutiableUOM"].ToString()).Selected = true;
                TxtInvQty.Text = obj.dr["InvoiceQuantity"].ToString();
                TxtHSQuantity.Text = obj.dr["HSQty"].ToString();

                // HSQTYUOM.SelectedItem.Text = obj.dr[16].ToString();
                HSQTYUOM.ClearSelection();
                HSQTYUOM.Items.FindByText(obj.dr["HSUOM"].ToString()).Selected = true;
                txtAlcoholPer.Text = obj.dr["AlcoholPer"].ToString();
                DrpInvoiceNo.ClearSelection();
                string striW1 = "select * from [InNonInvoiceDtl] where MessageType='INPDEC' AND PermitId='" + Invoice + "' and  InvoiceNo='" + obj.dr["InvoiceNo"].ToString() + "' order by InvoiceNo";
                InnonPaymentClass objinv = new InnonPaymentClass();
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

                TxtUnitPrice.Text = obj.dr["UnitPrice"].ToString();
                DRPCurrency.ClearSelection();
                DRPCurrency.Items.FindByText(obj.dr["UnitPriceCurrency"].ToString()).Selected = true;
                //  DRPCurrency.SelectedItem.Text = obj.dr[19].ToString();
                TxtExchangeRate.Text = obj.dr["ExchangeRate"].ToString();
                TxtSumExRate.Text = obj.dr["SumExchangeRate"].ToString();
                TxtTotalLineAmount.Text = obj.dr["TotalLineAmount"].ToString();
                TxtTotalLineCharges.Text = obj.dr["InvoiceCharges"].ToString();
                TxtCIFFOB.Text = obj.dr["CIFFOB"].ToString();
                if (!string.IsNullOrWhiteSpace(obj.dr["OptionalChrgeUOM"].ToString()))
                {
                    if (obj.dr["OptionalChrgeUOM"].ToString() != "--Select--")
                    {
                        DrpOptionalUom.ClearSelection();
                        DrpOptionalUom.Items.FindByText(obj.dr["OptionalChrgeUOM"].ToString()).Selected = true;
                    }
                }
                TxtOptionalPrice.Text = obj.dr["Optioncahrge"].ToString();
                TxtOptionalExchageRate.Text = obj.dr["OptionalSumtotal"].ToString();
                TxtOptionalSumExRate.Text = obj.dr["OptionalSumExchage"].ToString();

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

                if (Convert.ToDecimal(obj.dr["OPQty"].ToString()) > 0)
                {
                    PackingInfo.Visible = true;
                }


                DRPOPQUOM.ClearSelection();
                DRPOPQUOM.Items.FindByText(obj.dr["OPUOM"].ToString()).Selected = true;
                // DRPOPQUOM.SelectedItem.Text = obj.dr[26].ToString();
                TxtIPQty.Text = Math.Round(Convert.ToDecimal(obj.dr["IPQty"].ToString()), 0).ToString();

                DRPIPQUOM.ClearSelection();
                DRPIPQUOM.Items.FindByText(obj.dr["IPUOM"].ToString()).Selected = true;
                /// DRPIPQUOM.SelectedItem.Text = obj.dr[28].ToString();
                TxtINPQty.Text = Math.Round(Convert.ToDecimal(obj.dr["InPqty"].ToString()), 0).ToString();

                DRPINNPQUOM.ClearSelection();
                DRPINNPQUOM.Items.FindByText(obj.dr["InPUOM"].ToString()).Selected = true;
                //DRPINNPQUOM.SelectedItem.Text = obj.dr[30].ToString();
                TxtIMPQty.Text = Math.Round(Convert.ToDecimal(obj.dr["ImPQty"].ToString()), 0).ToString();

                DRPIMPQUOM.ClearSelection();
                DRPIMPQUOM.Items.FindByText(obj.dr["ImPUOM"].ToString()).Selected = true;
                // DRPIMPQUOM.SelectedItem.Text = obj.dr[32].ToString();

                DrpPreferentialCode.ClearSelection();
                DrpPreferentialCode.Items.FindByText(obj.dr["PreferentialCode"].ToString()).Selected = true;
                //DrpPreferentialCode.SelectedItem.Text = obj.dr[33].ToString();
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
                //  DrpOtherUOM.SelectedItem.Text = obj.dr[44].ToString();
                TxtSumOtherTaxRate.Text = obj.dr["OtherTaxAmount"].ToString();

                if (obj.dr["CurrentLot"].ToString() == "")
                {
                    LOTID.Visible = true;
                }
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
                TxtPreviousLot.Text = obj.dr["PreviousLot"].ToString();

                DrpMaking.ClearSelection();
                DrpMaking.Items.FindByText(obj.dr["Making"].ToString()).Selected = true;
                if (!string.IsNullOrWhiteSpace(obj.dr["ShippingMarks1"].ToString()))
                {
                    ShippMarkDiv.Visible = true;
                }

                txtShippingMarks1.Text = obj.dr["ShippingMarks1"].ToString();
                txtShippingMarks2.Text = obj.dr["ShippingMarks2"].ToString();
                txtShippingMarks3.Text = obj.dr["ShippingMarks3"].ToString();
                txtShippingMarks4.Text = obj.dr["ShippingMarks4"].ToString();
                editbindProduct1(ID);
                editbindProduct2(ID);
                editbindProduct3(ID);
                editbindProduct4(ID);
                editbindProduct5(ID);

                string co = "select * from [Country] where CountryCode='" + TxtCountryItem.Text + "'";
                obj.dr = obj.ret_dr(co);
                while (obj.dr.Read())
                {
                    txtcname.Text = obj.dr["Description"].ToString();
                }
                DrpInvoiceNo_SelectedIndexChanged(null, null);
                ItemAddGrid.Visible = true;
                ItemDiv.Visible = true;
                BtnAddNEWItem.Visible = false;
            }
            Itemclear();
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            TxtProQty5.Text = TxtHSQuantity.Text;
           // DrpP5.ClearSelection();
          //  DrpP5.Items.FindByText(HSQTYUOM.SelectedItem.ToString()).Selected = true;
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            TxtProQty4.Text = TxtHSQuantity.Text;
          //  DrpP4.ClearSelection();
           // DrpP4.Items.FindByText(HSQTYUOM.SelectedItem.ToString()).Selected = true;
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            TxtProQty3.Text = TxtHSQuantity.Text;
           // DrpP3.ClearSelection();
          //  DrpP3.Items.FindByText(HSQTYUOM.SelectedItem.ToString()).Selected = true;
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            TxtProQty2.Text = TxtHSQuantity.Text;
           // DrpP2.ClearSelection();
           // DrpP2.Items.FindByText(HSQTYUOM.SelectedItem.ToString()).Selected = true;
        }

        protected void BtnPPN_Click(object sender, EventArgs e)
        {
            string sent = "Previous Permit Number :";

            txttrdremrk.Text = txttrdremrk.Text + Environment.NewLine + sent + TxtPrevPerNO.Text + Environment.NewLine;
        }

        protected void btncopyhscode_Click(object sender, EventArgs e)
        {
            obj.exec("update InNonItemDtl set HSCode='" + txtctd.Text + "' where PermitId='" + txt_code.Text + "'");
            obj.closecon();
            BindItemMaster();
            btncopyhscode.Focus();
        }

        protected void btncopydesc_Click(object sender, EventArgs e)
        {
            obj.exec("update InNonItemDtl set Description='" + txtctd.Text + "' where PermitId='" + txt_code.Text + "'");
            obj.closecon();
            BindItemMaster();
            btncopyhscode.Focus();
        }

        protected void btncopycoo_Click(object sender, EventArgs e)
        {
            obj.exec("update InNonItemDtl set Contry='" + txtctd.Text + "' where PermitId='" + txt_code.Text + "'");
            obj.closecon();
            BindItemMaster();
            btncopyhscode.Focus();
        }

        protected void Button12_Click(object sender, EventArgs e)
        {

            obj.exec("delete InNonItemDtl  where PermitId='" + txt_code.Text + "'");
            obj.closecon();
            BindItemMaster();
        }

        protected void Btnselectitem_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gvrow in AddItemGrid.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("chk");
                if (chk != null & chk.Checked)
                {
                    Label statustype = (Label)gvrow.FindControl("lblID");
                    
                    string P1 = ("delete InNonItemDtl  where id='" + statustype.Text + "' ");
                    obj.exec(P1);
                    obj.closecon();


                }
            }
            BindItemMaster();
        }

        protected void chk_CheckedChanged(object sender, EventArgs e)
        {

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


        protected void imgDelete_ClickAEO(object sender, EventArgs e)
        {
            // Get clicked button and row index
            LinkButton btn = (LinkButton)sender;
            int rowIndex = Convert.ToInt32(btn.CommandArgument);

            // Get DataTable from ViewState
            DataTable dt = ViewState["CurrentTable"] as DataTable;

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
                    ViewState["CurrentTable"] = dt;
                    AEOGrid.DataSource = dt;
                    AEOGrid.DataBind();
                }
            }
        }


        protected void imgDelete_ClickCWC(object sender, EventArgs e)
        {
            // Get clicked button and row index
            LinkButton btn = (LinkButton)sender;
            int rowIndex = Convert.ToInt32(btn.CommandArgument);

            // Get DataTable from ViewState
            DataTable dt = ViewState["CurrentTable1"] as DataTable;

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
                    ViewState["CurrentTable1"] = dt;
                    CWCGrid.DataSource = dt;
                    CWCGrid.DataBind();
                }
            }
        }


        protected void imgDelete_ClickSea(object sender, EventArgs e)
        {
            // Get clicked button and row index
            LinkButton btn = (LinkButton)sender;
            int rowIndex = Convert.ToInt32(btn.CommandArgument);

            // Get DataTable from ViewState
            DataTable dt = ViewState["CurrentTable26"] as DataTable;

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
                    ViewState["CurrentTable26"] = dt;
                    SeaGrid.DataSource = dt;
                    SeaGrid.DataBind();
                }
            }
        }


        protected void imgDelete_ClickScheme(object sender, EventArgs e)
        {
            // Get clicked button and row index
            LinkButton btn = (LinkButton)sender;
            int rowIndex = Convert.ToInt32(btn.CommandArgument);

            // Get DataTable from ViewState
            DataTable dt = ViewState["CurrentTable30"] as DataTable;

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
                    ViewState["CurrentTable30"] = dt;
                    SchemeGrid.DataSource = dt;
                    SchemeGrid.DataBind();
                }
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
    
