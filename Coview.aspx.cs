using RET.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RET
{
    public partial class Coview : System.Web.UI.Page
    {
        //protected override object LoadPageStateFromPersistenceMedium()
        //{
        //    string viewState = Request.Form["__VSTATE"];
        //    byte[] bytes = Convert.FromBase64String(viewState);
        //    bytes = CompressedViewStatePage.Decompress(bytes);
        //    LosFormatter formatter = new LosFormatter();
        //    return formatter.Deserialize(Convert.ToBase64String(bytes));
        //}

        //protected override void SavePageStateToPersistenceMedium(object viewState)
        //{
        //    LosFormatter formatter = new LosFormatter();
        //    StringWriter writer = new StringWriter();
        //    formatter.Serialize(writer, viewState);
        //    string viewStateString = writer.ToString();
        //    byte[] bytes = Convert.FromBase64String(viewStateString);
        //    bytes = CompressedViewStatePage.Compress(bytes);
        //    ClientScript.RegisterHiddenField("__VSTATE", Convert.ToBase64String(bytes));
        //}
        COClass obj = new COClass();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
        string sqlconn = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
        string TempDataPermitNo = "";
        private static string Update = "";

        static string JobNo, MsgNO, refno, msgid = "";
        static string Permitnum = "";
        private int Id = 0;
        //string prmstatus = "";
        
        //bool edit = false;
        //Discharge Port

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> DischargePort(string prefixText)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select * from  LoadingPort where PortCode like '" + prefixText + "%' ", sqlconn);
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

        //Declarant Company

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetListofCountries(string prefixText)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select * from  DeclarantCompany where Code like '" + prefixText + "%' ", sqlconn);
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
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetHSCodeItem(string prefixText)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select * from  HSCode where HSCode like '" + prefixText + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@HSCode", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                List<string> Deccode = new List<string>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Deccode.Add(dt.Rows[i]["HSCode"].ToString() + ":" + dt.Rows[i]["Description"].ToString());
                    // string con = String.Concat(Deccode, DecName);
                }
                return Deccode;
            }
        }

        //Exporter
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetExpcode(string prefixText)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select * from  COExporter where Code like '" + prefixText + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@Code", prefixText);
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


        //Inward Code

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetInwcode(string prefixText)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select * from  COInwardCarrierAgent where Code like '" + prefixText + "%' ", sqlconn);
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
//outward
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetOutWard(string prefixText)
        {
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select * from  [COOutwardCarrierAgent] where Code like '" + prefixText + "%' ", sqlconn);
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

        //freightcode

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetFrieght(string prefixText)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select * from  COFreightForwarder where Code like '" + prefixText + "%' ", sqlconn);
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

        //Consignee
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetCosigncode(string prefixText)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select * from  COConsignee where ConsigneeCode like '" + prefixText + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@ConsigneeCode", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                List<string> Deccode = new List<string>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {


                    Deccode.Add(dt.Rows[i]["ConsigneeCode"].ToString() + ":" + dt.Rows[i]["ConsigneeName"].ToString());


                    // string con = String.Concat(Deccode, DecName);


                }
                return Deccode;
            }
        }
        //Consignee
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetManufactcode(string prefixText)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select * from  COManufacturer where ManufacturerCode like '" + prefixText + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@ManufacturerCode", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                List<string> Deccode = new List<string>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {


                    Deccode.Add(dt.Rows[i]["ManufacturerCode"].ToString() + ":" + dt.Rows[i]["ManufacturerName"].ToString());


                    // string con = String.Concat(Deccode, DecName);


                }
                return Deccode;
            }
        }
        // Get HS Code

      


        //Country Of Orgin

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetCountryItem(string prefixText)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select * from  Country where CountryCode like '" + prefixText + "%' ", sqlconn);
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Userid"] == null)
            {
                Response.Redirect("sessionTimeout.aspx");
            }
            enablefun();
            BindCondition();
            Control myControlMenu = Page.Master.FindControl("Master");
            if (myControlMenu != null)
            {
                myControlMenu.Visible = false;
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
            btnnextsum.Visible = false;
            string DecAccountID = Session["AccountId"].ToString();
            string MailboxId = "";
            string aa = "select Mailboxid from ManageUser where UserId='" + Session["UserId"].ToString() + "'";
            obj.dr = obj.ret_dr(aa);
            while (obj.dr.Read())
            {

                MailboxId = obj.dr["Mailboxid"].ToString();
            }

            string qry111 = "SELECT TradeNetMailboxID,DeclarantName,DeclarantCode,DeclarantTel,CRUEI  from DeclarantCompany a,ManageUser b  where a.AccountID=b.AccountId and a.TradeNetMailboxID=b.Mailboxid and b.UserId='" + Session["UserId"].ToString() + "' and b.MailBoxid='" + MailboxId + "'  group by TradeNetMailboxID,DeclarantName,DeclarantCode,DeclarantTel,CRUEI";

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
          

            summerycalculate();
            if (!IsPostBack)
            {
                Session["Edit"] = true;
                Session["Id"] = Convert.ToInt32(Request.QueryString["Id"]);
                Id = Convert.ToInt32(Request.QueryString["Id"]);
                cargo.Visible = true;

                btnSeaStr.Visible = true;

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

                BindOutward();
                BindExporter();
                BindConsignee();
                BindManufacturer();
                BindItemMaster();
                BindExportPort();
                InwardFlight.Visible = false;
                InwardSea.Visible = false;
                InwardOther.Visible = false;
                //ContainerDetails.Visible = false;
                decBindGrid();

                BindInward();
                BindFrieght();
                BindStorage();
                //CARGO+
                ContarinerGrid.RowDataBound += ContarinerGrid_RowDataBound;
                BindLoading();
                BindlOCATION();
                Bindreceipt();
                //invoice

                OUTWARDFlight.Visible = false;
                OUTWARDSea.Visible = false;
                OUTWARDVesl.Visible = false;
                OUTWARDOther.Visible = false;
                summerycalculate();

                BindInhouse();
                BindHSCode();
                BindCountry();


               
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
                ////SUM OF INVOICE
                //string SumInv = "";
                //string qry11 = "select Count(InvoiceNo) as InvCount from dbo.InNonInvoiceDtl where PermitId='" + txt_code.Text + "' and MessageType='COODEC'";
                //obj.dr = obj.ret_dr(qry11);
                //while (obj.dr.Read())
                //{
                //    SumInv = obj.dr[0].ToString();
                //    txtnoofinv.Text = SumInv;
                //}
                ////SUM OF ITEM
                //string SumItem = "";
                //string qry112 = "select Count(ItemNo) as ItemCount from dbo.COItemDtl where PermitId='" + txt_code.Text + "' and MessageType='COODEC'";
                //obj.dr = obj.ret_dr(qry112);
                //while (obj.dr.Read())
                //{
                //    SumItem = obj.dr[0].ToString();
                //    txtnoofitm.Text = SumItem;
                //}

                /////Total Invoice CIF Value
                //string InvoiceCIFValue = "";
                //string qry112Q = "select sum(CIFSUMAmount) as InNonInvoiceDtl from dbo.InNonInvoiceDtl where PermitId='" + txt_code.Text + "' and MessageType='COODEC'";
                //obj.dr = obj.ret_dr(qry112Q);
                //while (obj.dr.Read())
                //{
                //    InvoiceCIFValue = obj.dr[0].ToString();
                //    txtcifVal.Text = InvoiceCIFValue;
                //}

                ////Sum of Item Amount

                //string SumofItemAmount = "";
                //string qry11s2Q = "select SUM(TotalLineAmount) as  TotalLineAmount  from dbo.COItemDtl where PermitId='" + txt_code.Text + "' and MessageType='COODEC'";
                //obj.dr = obj.ret_dr(qry11s2Q);
                //while (obj.dr.Read())
                //{
                //    SumofItemAmount = obj.dr[0].ToString();
                //    txtitmAmt.Text = SumofItemAmount;
                //}


                //////Total CIF/FOB Value
                ////string TotalCIFFOBValue = "";
                ////string qry11sS2 = "select SUM(CIFFOB) as  GSTAmount  from dbo.ItemDtl where PermitId='" + txt_code.Text + "' and MessageType='COODEC'";
                ////obj.dr = obj.ret_dr(qry11sS2);
                ////while (obj.dr.Read())
                ////{
                ////    TotalCIFFOBValue = obj.dr[0].ToString();
                ////    txtfobval.Text = TotalCIFFOBValue;

                ////}


                DrpOutwardtrasMode_SelectedIndexChanged(null, null);
                ChkSea_CheckedChanged(null, null);
                if (!IsPostBack)
                {


                    ItemNO();
                    PermitNO();
                    JobNO();
                    MSGNO();
                    refid();

                    BindItemMaster();

                    ItemAddGrid.Visible = true;
                    ItemDiv.Visible = true;


                    SetInitialRow();
                    //cpc
                    SetInitialRowc();

                    this.BindGrid();
                    //Co Type
                    string stqrnc = "select Id,Name from [CommonMaster] where TypeId='16' and StatusID=1 order by Name";
                    obj.dr = obj.ret_dr(stqrnc);
                    DrpCoType.DataSource = obj.dr;
                    DrpCoType.DataTextField = "Name";
                    DrpCoType.DataValueField = "Id";
                    DrpCoType.DataBind();
                    obj.closecon();
                    DrpCoType.Items.Insert(0, new ListItem("--Select--", "0"));

                    //Certificate Detail #1 - Type
                    string stqrnq = "select Id,Name from [CommonMaster] where TypeId='17' and StatusID=1 order by Name";
                    obj.dr = obj.ret_dr(stqrnq);
                    DrpCerDtl1.DataSource = obj.dr;
                    DrpCerDtl1.DataTextField = "Name";
                    DrpCerDtl1.DataValueField = "Id";
                    DrpCerDtl1.DataBind();
                    obj.closecon();
                    DrpCerDtl1.Items.Insert(0, new ListItem("--Select--", "0"));

                    //Certificate Detail #2 - Type
                    string stqrnqd = "select Id,Name from [CommonMaster] where TypeId='17' and StatusID=1 order by Name";
                    obj.dr = obj.ret_dr(stqrnqd);
                    DrpCerDtl2.DataSource = obj.dr;
                    DrpCerDtl2.DataTextField = "Name";
                    DrpCerDtl2.DataValueField = "Id";
                    DrpCerDtl2.DataBind();
                    obj.closecon();
                    DrpCerDtl2.Items.Insert(0, new ListItem("--Select--", "0"));

                    //Currency Code

                    string r = "select Currency+':'+CurrencyCountry as Currency,Id from [Currency] order by Currency";
                    obj.dr = obj.ret_dr(r);
                    DrpCurrencyCode.DataSource = obj.dr;
                    DrpCurrencyCode.DataTextField = "Currency";
                    DrpCurrencyCode.DataValueField = "Id";
                    DrpCurrencyCode.DataBind();
                    obj.closecon();
                    DrpCurrencyCode.Items.Insert(0, new ListItem("--Select--", "0"));
                    //HS QTY UOM
                     string w = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                    obj.dr = obj.ret_dr(w);
                    drpInvoiceUOM.DataSource = obj.dr;
                    drpInvoiceUOM.DataTextField = "Name";
                    drpInvoiceUOM.DataValueField = "Id";
                    drpInvoiceUOM.DataBind();
                    obj.closecon();
                    drpInvoiceUOM.Items.Insert(0, new ListItem("--Select--", "0"));
                    
                     string w1 = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                    obj.dr = obj.ret_dr(w1);
                    DrpTextQoutoQTYUOM.DataSource = obj.dr;
                    DrpTextQoutoQTYUOM.DataTextField = "Name";
                    DrpTextQoutoQTYUOM.DataValueField = "Id";
                    DrpTextQoutoQTYUOM.DataBind();
                    obj.closecon();
                    DrpTextQoutoQTYUOM.Items.Insert(0, new ListItem("--Select--", "0"));

                     string w2 = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                    obj.dr = obj.ret_dr(w2);
                    DrpCerITemUOM.DataSource = obj.dr;
                    DrpCerITemUOM.DataTextField = "Name";
                    DrpCerITemUOM.DataValueField = "Id";
                    DrpCerITemUOM.DataBind();
                    obj.closecon();
                    DrpCerITemUOM.Items.Insert(0, new ListItem("--Select--", "0"));
                    
                    

                    //vessel nat
                    string stqrn = "select * from [Country]  order by Description";
                    obj.dr = obj.ret_dr(stqrn);
                    DroVesslNat.DataSource = obj.dr;
                    DroVesslNat.DataTextField = "Description";
                    DroVesslNat.DataValueField = "Id";
                    DroVesslNat.DataBind();
                    obj.closecon();
                    DroVesslNat.Items.Insert(0, new ListItem("--Select--", "0"));

                    //Country
                    //string stqr = "select * from [Country]  order by Description";
                    string stqr = "select Id,CountryCode+' : '+Description as Description from [Country]  order by Description";
                    obj.dr = obj.ret_dr(stqr);
                    DrpFinalDesCountry.DataSource = obj.dr;
                    DrpFinalDesCountry.DataTextField = "Description";
                    DrpFinalDesCountry.DataValueField = "Id";
                    DrpFinalDesCountry.DataBind();
                    obj.closecon();
                    DrpFinalDesCountry.Items.Insert(0, new ListItem("--Select--", "0"));


                    //Country
                    //string stqr = "select * from [Country]  order by Description";
                    string stqr1 = "select Id,CountryCode+' : '+Description as Description from [Country]  order by Description";
                    obj.dr = obj.ret_dr(stqr1);
                    Drpgpsdonorcountry.DataSource = obj.dr;
                    Drpgpsdonorcountry.DataTextField = "Description";
                    Drpgpsdonorcountry.DataValueField = "Id";
                    Drpgpsdonorcountry.DataBind();
                    obj.closecon();
                    Drpgpsdonorcountry.Items.Insert(0, new ListItem("--Select--", "0"));
                    //Declaration Type



                    //OutwardtrasMode
                    string s = "select Id,Name from [CommonMaster] where TypeId='3' and StatusID=1 order by Name";
                    obj.dr = obj.ret_dr(s);
                    DrpOutwardtrasMode.DataSource = obj.dr;
                    DrpOutwardtrasMode.DataTextField = "Name";
                    DrpOutwardtrasMode.DataValueField = "Id";
                    DrpOutwardtrasMode.DataBind();
                    obj.closecon();
                    DrpOutwardtrasMode.Items.Insert(0, new ListItem("--Select--", "0"));
                    //BGIndicator
                    string str111 = "select Id,Name from [CommonMaster] where TypeId='4' and StatusID=1 order by Name";
                    obj.dr = obj.ret_dr(str111);
                    DrpBGIndicator.DataSource = obj.dr;
                    DrpBGIndicator.DataTextField = "Name";
                    DrpBGIndicator.DataValueField = "Id";
                    DrpBGIndicator.DataBind();
                    obj.closecon();
                    DrpBGIndicator.Items.Insert(0, new ListItem("--Select--", "0"));
                    //DocType
                    string str1111 = "select Id,Name from [CommonMaster] where TypeId='5' and StatusID=1 order by Name";
                    obj.dr = obj.ret_dr(str1111);
                    DrpDocType.DataSource = obj.dr;
                    DrpDocType.DataTextField = "Name";
                    DrpDocType.DataValueField = "Id";
                    DrpDocType.DataBind();
                    obj.closecon();
                    DrpDocType.Items.Insert(0, new ListItem("--Select--", "0"));
                    //VesselType
                    string VesStr = "select Id,Name from [CommonMaster] where TypeId='14' and StatusID=1 order by Name";
                    obj.dr = obj.ret_dr(VesStr);
                    ddpVessel.DataSource = obj.dr;
                    ddpVessel.DataTextField = "Name";
                    ddpVessel.DataValueField = "Id";
                    ddpVessel.DataBind();
                    obj.closecon();
                    ddpVessel.Items.Insert(0, new ListItem("--Select--", "0"));

                    //vessel nat
                    string stqqrn = "select * from [Country]  order by Description";
                    obj.dr = obj.ret_dr(stqqrn);
                    DroVesslNat.DataSource = obj.dr;
                    DroVesslNat.DataTextField = "Description";
                    DroVesslNat.DataValueField = "Id";
                    DroVesslNat.DataBind();
                    obj.closecon();
                    DroVesslNat.Items.Insert(0, new ListItem("--Select--", "0"));


                   

                  


                    //TDQ
                    string stri = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                    obj.dr = obj.ret_dr(stri);
                    TDQUOM.DataSource = obj.dr;
                    TDQUOM.DataTextField = "Name";
                    TDQUOM.DataValueField = "Id";
                    TDQUOM.DataBind();
                    obj.closecon();
                    TDQUOM.Items.Insert(0, new ListItem("--Select--", "0"));

                    //TDQ
                    string str1i = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                    obj.dr = obj.ret_dr(str1i);
                    HSQTYUOM.DataSource = obj.dr;
                    HSQTYUOM.DataTextField = "Name";
                    HSQTYUOM.DataValueField = "Id";
                    HSQTYUOM.DataBind();
                    obj.closecon();
                    HSQTYUOM.Items.Insert(0, new ListItem("--Select--", "0"));

                    //TDQ
                    string str2i = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                    obj.dr = obj.ret_dr(str2i);
                    DRPOPQUOM.DataSource = obj.dr;
                    DRPOPQUOM.DataTextField = "Name";
                    DRPOPQUOM.DataValueField = "Id";
                    DRPOPQUOM.DataBind();
                    obj.closecon();
                    DRPOPQUOM.Items.Insert(0, new ListItem("--Select--", "0"));

                    //TDQ
                    string str3 = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                    obj.dr = obj.ret_dr(str3);
                    DRPIPQUOM.DataSource = obj.dr;
                    DRPIPQUOM.DataTextField = "Name";
                    DRPIPQUOM.DataValueField = "Id";
                    DRPIPQUOM.DataBind();
                    obj.closecon();
                    DRPIPQUOM.Items.Insert(0, new ListItem("--Select--", "0"));

                    //TDQ
                    string str5i = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                    obj.dr = obj.ret_dr(str5i);
                    DRPINNPQUOM.DataSource = obj.dr;
                    DRPINNPQUOM.DataTextField = "Name";
                    DRPINNPQUOM.DataValueField = "Id";
                    DRPINNPQUOM.DataBind();
                    obj.closecon();
                    DRPINNPQUOM.Items.Insert(0, new ListItem("--Select--", "0"));

                    //TDQ
                    string str6 = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                    obj.dr = obj.ret_dr(str6);
                    DRPIMPQUOM.DataSource = obj.dr;
                    DRPIMPQUOM.DataTextField = "Name";
                    DRPIMPQUOM.DataValueField = "Id";
                    DRPIMPQUOM.DataBind();
                    obj.closecon();
                    DRPIMPQUOM.Items.Insert(0, new ListItem("--Select--", "0"));

                    //TDQ
                    string str7 = "select Id,Name from [CommonMaster] where TypeId='9' and StatusID=1 order by Name";
                    obj.dr = obj.ret_dr(str7);
                    DRPCurrency.DataSource = obj.dr;
                    DRPCurrency.DataTextField = "Name";
                    DRPCurrency.DataValueField = "Name";
                    DRPCurrency.DataBind();
                    obj.closecon();
                    DRPCurrency.Items.Insert(0, new ListItem("--Select--", "0"));



                    



                  


                    // Cargo UOM
                    string str6s = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                    obj.dr = obj.ret_dr(str6s);
                    DrptotalOuterPack.DataSource = obj.dr;
                    DrptotalOuterPack.DataTextField = "Name";
                    DrptotalOuterPack.DataValueField = "Id";
                    DrptotalOuterPack.DataBind();
                    obj.closecon();
                    DrptotalOuterPack.Items.Insert(0, new ListItem("--Select--", "0"));

                    //string str6ss = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                    //obj.dr = obj.ret_dr(str6ss);
                    //DrpTotalGrossWeight.DataSource = obj.dr;
                    //DrpTotalGrossWeight.DataTextField = "Name";
                    //DrpTotalGrossWeight.DataValueField = "Id";
                    //DrpTotalGrossWeight.DataBind();
                    //obj.closecon();
                    //DrpTotalGrossWeight.Items.Insert(0, new ListItem("--Select--", "0"));

                    string drpv = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                    obj.dr = obj.ret_dr(drpv);
                    DroVesslNat.DataSource = obj.dr;
                    DroVesslNat.DataTextField = "Name";
                    DroVesslNat.DataValueField = "Name";
                    DroVesslNat.DataBind();
                    obj.closecon();
                    DroVesslNat.Items.Insert(0, new ListItem("--Select--", "0"));
                    //string strc = "select Id,Name from [CommonMaster] where TypeId='16' and StatusID=1 order by Name";
                    //obj.dr = obj.ret_dr(strc);
                    //DrpCOType.DataSource = obj.dr;
                    //DrpCOType.DataTextField = "Name";
                    //DrpCOType.DataValueField = "Id";
                    //DrpCOType.DataBind();
                    //obj.closecon();
                    //DrpCOType.Items.Insert(0, new ListItem("--Select--", "0"));
                    //GSP Donor Country
                  //  string stqqrna = "select * from [Country]  order by Description";
                    //obj.dr = obj.ret_dr(stqqrna);
                    //DrpGPSCon.DataSource = obj.dr;
                    //DrpGPSCon.DataTextField = "Description";
                    //DrpGPSCon.DataValueField = "Id";
                    //DrpGPSCon.DataBind();
                    //obj.closecon();
                    //DrpGPSCon.Items.Insert(0, new ListItem("--Select--", "0"));



                    ////Certificate Detail 1
                    //string strc11 = "select Id,Name from [CommonMaster] where TypeId='17' and StatusID=1 order by Name";
                    //obj.dr = obj.ret_dr(strc11);
                    //DrpCerType1.DataSource = obj.dr;
                    //DrpCerType1.DataTextField = "Name";
                    //DrpCerType1.DataValueField = "Id";
                    //DrpCerType1.DataBind();
                    //obj.closecon();
                    //DrpCerType1.Items.Insert(0, new ListItem("--Select--", "0"));

                    ////Certificate Detail 2
                    //string strc22 = "select Id,Name from [CommonMaster] where TypeId='17' and StatusID=1 order by Name";
                    //obj.dr = obj.ret_dr(strc22);
                    //DrpCerType2.DataSource = obj.dr;
                    //DrpCerType2.DataTextField = "Name";
                    //DrpCerType2.DataValueField = "Id";
                    //DrpCerType2.DataBind();
                    //obj.closecon();
                    //DrpCerType2.Items.Insert(0, new ListItem("--Select--", "0"));
                    ////Currency Code
                    //string strc22q = "select Id,Currency " + "+' : '+ " + "CurrencyCountry as CurrencyCountry from [Currency]  order by CurrencyCountry";
                    //obj.dr = obj.ret_dr(strc22q);
                    //DrpCurnContry.DataSource = obj.dr;
                    //DrpCurnContry.DataTextField = "CurrencyCountry";
                    //DrpCurnContry.DataValueField = "Id";
                    //DrpCurnContry.DataBind();
                    //obj.closecon();
                    //DrpCurnContry.Items.Insert(0, new ListItem("--Select--", "0"));
                }
                //if (DrpInwardtrasMode.SelectedItem.ToString() != "--Select--")
                //{
                //    string TransMode = DrpInwardtrasMode.SelectedItem.ToString();
                //    TextMode.Text = TransMode;
                //    InwardFlight.Visible = false;
                //    InwardSea.Visible = false;
                //    InwardOther.Visible = false;
                //    ContainerDetails.Visible = false;
                //    if (TextMode.Text == "1 : Sea")
                //    {
                //        InwardSea.Visible = true;
                //        ContainerDetails.Visible = false;
                //    }
                //    else if (TextMode.Text == "2 : Rail" || TextMode.Text == "3 : Road" || TextMode.Text == "5 : Mail" || TextMode.Text == "7 : Pipeline" || TextMode.Text == "N : Not Required" || TextMode.Text == "6 : Multi-model(Not in use)")
                //    {
                //        InwardOther.Visible = true;
                //        ContainerDetails.Visible = false;
                //    }

                //    else if (TextMode.Text == "4 : Air")
                //    {
                //        InwardFlight.Visible = true;
                //        ContainerDetails.Visible = false;
                //    }
                //}

                DrpOutwardtrasMode_SelectedIndexChanged(null, null);


                //if (DrpOutwardtrasMode.SelectedItem.ToString() != "--Select--")
                //{
                //    string TransMode = DrpInwardtrasMode.SelectedItem.ToString();
                //    TxtExpMode.Text = TransMode;
                //    InwardFlight.Visible = false;
                //    InwardSea.Visible = false;
                //    InwardOther.Visible = false;
                //    //ContainerDetails.Visible = false;
                //    if (TxtExpMode.Text == "1 : Sea")
                //    {
                //       OUTWARDSea.Visible = true;
                //        //ContainerDetails.Visible = false;
                //    }
                //    else if (TxtExpMode.Text == "2 : Rail" || TxtExpMode.Text == "3 : Road" || TxtExpMode.Text == "5 : Mail" || TxtExpMode.Text == "7 : Pipeline" || TxtExpMode.Text == "N : Not Required" || TxtExpMode.Text == "6 : Multi-model(Not in use)")
                //    {
                //        OUTWARDOther.Visible = true;
                //        //ContainerDetails.Visible = false;
                //    }

                //    else if (TxtExpMode.Text == "4 : Air")
                //    {
                //        OUTWARDFlight.Visible = true;
                //        //ContainerDetails.Visible = false;
                //    }
                //}

                string temp = "select PermitId from CoTemp where  PermitId='" + txt_code.Text + "' and TouchUser='" + Session["UserId"].ToString() + "'";
                obj.dr = obj.ret_dr(temp);
                while (obj.dr.Read())
                {

                    TempDataPermitNo = obj.dr["PermitId"].ToString();
                    CoEdit();

                }

                if (Id != 0)
                {
                    CoEdit();
                    return;
                }
                else
                {
                }

            }
        }

        public void enablefun()
        {

            txt_code.Enabled = false;
            TxtTradeMailID.Enabled = false;
            TxtMsgType.Enabled = false;
            //DrpDecType.Text = obj.dr[6].ToString();



            // DrpInwardtrasMode.SelectedItem.Text = obj.dr[8].ToString();
            DrpBGIndicator.Enabled = false;


            ChkSupplyIndicator.Enabled = false;

            ChkSupplyIndicator.Enabled = false;


            ChkRefDoc.Enabled = false;

            DrpOutwardtrasMode.Enabled = false;

            TxtLicense1.Enabled = false;
            TxtLicense2.Enabled = false;
            TxtLicense3.Enabled = false;
            TxtLicense4.Enabled = false;
            TxtLicense5.Enabled = false;
            DrpDocType.Enabled = false;

            DrpCoType.Enabled = false;

            Drpgpsdonorcountry.Enabled = false;

            DrpCerDtl1.Enabled = false;

            TxtCerDtl1.Enabled = false; ;
            DrpCerDtl2.Enabled = false;
            DrpCerDtl2.Enabled = false;
            TxtCerDtl2.Enabled = false; ;
            txtper.Enabled = false;
            DrpCurrencyCode.Enabled = false;

            AddCerDtl1.Enabled = false;
            AddCerDtl2.Enabled = false;
            AddCerDtl3.Enabled = false;
            AddCerDtl4.Enabled = false;
            AddCerDtl5.Enabled = false;
            TransDtl1.Enabled = false;
            TransDtl2.Enabled = false;
            TransDtl3.Enabled = false;
            TransDtl4.Enabled = false;
            TransDtl5.Enabled = false;
            TxtRECPT1.Enabled = false;
            TxtRECPT2.Enabled = false;
            TxtRECPT3.Enabled = false;


            TxtRECPT1.Enabled = false;
            TxtRECPT2.Enabled = false;
            TxtRECPT3.Enabled = false;


            TextMode.Enabled = false;



            TxtLoadShort.Enabled = false;


            TxtVoyageno.Enabled = false;
            TxtVesselName.Enabled = false;
            TxtOceanBill.Enabled = false;
            TxtConRefNo.Enabled = false;
            TxtTrnsID.Enabled = false;
            txtflight.Enabled = false;
            txtaircraft.Enabled = false;
            txtwaybill.Enabled = false;

            txtreLoctn.Enabled = false;

            txtrecloctn.Enabled = false;

            TxttotalOuterPack.Enabled = false;
            DrptotalOuterPack.Enabled = false;

            TxtTotalGrossWeight.Enabled = false;
            DrpTotalGrossWeight.Enabled = false;

            TxtGrossReference.Enabled = false;
            txttrdremrk.Enabled = false;

            TxtPrevPerNO.Enabled = false;
            LblPermitNo.Enabled = false;





            TxtDecCompCode.Enabled = false;
            TxtDecCompName.Enabled = false;
            TxtDecCompName1.Enabled = false;
            TxtDecCompCRUEI.Enabled = false;



            InwardCode.Enabled = false;
            InwardName.Enabled = false;
            InwardName1.Enabled = false;
            InwardCRUEI.Enabled = false;




            FrieghtCode.Enabled = false;
            FrieghtName.Enabled = false;
            FrieghtName1.Enabled = false;
            FrieghtCRUEI.Enabled = false;



            //item

            TxtSerialNo.Enabled = false;

            TDQUOM.Enabled = false;


            ddptotDutiableQty.Enabled = false;


            TxtHSCodeItem.Enabled = false;

            DRPCurrency.Enabled = false;

            TxtDescription.Enabled = false;
            TxtCountryItem.Enabled = false;

            txtcname.Enabled = false;
            DRPCurrency.Enabled = false;

            DRPOPQUOM.Enabled = false;


            TxtTotalDutiableQuantity.Enabled = false;
            TxtInvQty.Enabled = false;
            TxtHSQuantity.Enabled = false;
            HSQTYUOM.Enabled = false;

            TxtUnitPrice.Enabled = false;
            TxtExchangeRate.Enabled = false;
            TxtSumExRate.Enabled = false;
            TxtTotalLineAmount.Enabled = false;



            TxtCIFFOB.Enabled = false;
            TxtOPQty.Enabled = false;
            TxtIPQty.Enabled = false;


            TxtINPQty.Enabled = false;
            TxtINPQty.Enabled = false;
            TxtIMPQty.Enabled = false;
           // ItemGSTRate.Enabled = false;
            DRPINNPQUOM.Enabled = false;

            DRPIMPQUOM.Enabled = false;

         //   DrpPreferentialCode.Enabled = false;

            //ItemGSTUOM.Enabled = false;
            //TxtItemSumGST.Enabled = false; ;
            //TxtExciseDutyRate.Enabled = false;
            //TxtExciseDutyUOM.Enabled = false;
            //TxtSumExciseDuty.Enabled = false;
            //TxtCustomsDutyRate.Enabled = false;
            //TxtCustomsDutyUOM.Enabled = false;
            //TxtSumCustomsDuty.Enabled = false;
            //DrpOtherUOM.Enabled = false;

            //DrpMaking.Enabled = false;


            //TxtOtherTaxRate.Enabled = false;
            //TxtSumOtherTaxRate.Enabled = false;
            //TxtCurrentLot.Enabled = false;
            //TxtPreviousLot.Enabled = false;
            txtShippingMarks1.Enabled = false;



        }
        private void BindCondition()
        {
            string Permitno = "";
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            string status = "";
            COClass select = new COClass();
            obj.dr = obj.ret_dr("Select * from COHeaderTbl Where MSGId='" + msgid + "'");
            if (obj.dr.Read())
            {
                status = obj.dr["Status"].ToString();
                lblstatus.Text = obj.dr["Status"].ToString();
                lblmsgid.Text = obj.dr["MSGId"].ToString();
                lbljobid.Text = obj.dr["JobId"].ToString();
                lbldecdate.Text = obj.dr["TouchTime"].ToString();
                lblcreate.Text = obj.dr["TouchUser"].ToString();
                //Permitno = obj.dr["TouchUser"].ToString();
            }
            //if (!string.IsNullOrWhiteSpace(Permitnum))
            //{
            //    COClass obj1 = new COClass();
            //    obj1.dr = obj1.ret_dr("Select * from COHeaderTbl Where PermitNumber='" + Permitnum + "'");
            //    if (obj1.dr.Read())
            //    {
            //        msgid = obj1.dr["MSGId"].ToString();
            //    }
            //}

            if (status == "APR")
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT Sno as SNo, ConditionCode as Code, ConditionDescription as Description FROM CoPMT Where PermitNumber='" + Permitno + "'"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                GridCondition.DataSource = dt;
                                GridCondition.DataBind();
                            }
                        }
                    }
                }
            }


            else if (status == "ERR")
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT Sno as SNo Error ErrorCode as Code, ErrorDescription+' '+ErrorTrace as Description  FROM COErrorStatus Where MsgID='" + msgid + "'"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                GridCondition.DataSource = dt;
                                GridCondition.DataBind();
                            }
                        }
                    }
                }
            }


            else if (status == "REJ")
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT Sno as SNO, ErrorID  as Code , ErrorDescription as Description FROM CORejectStatus Where MsgID='" + msgid + "'"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                GridCondition.DataSource = dt;
                                GridCondition.DataBind();
                            }
                        }
                    }
                }
            }

            string qry112Q = "SELECT * FROM CoPMT where PermitNumber='" + Permitno + "'";
            obj.dr = obj.ret_dr(qry112Q);
            while (obj.dr.Read())
            {
                LblPermitNo.Text = obj.dr["PermitNumber"].ToString();

                Convert.ToDateTime(obj.dr["EndDate"].ToString()).ToString("dd/MM/yyyy");
                string validityperiod = Convert.ToDateTime(obj.dr["StartDate"].ToString()).ToString("dd/MM/yyyy") + "-" + Convert.ToDateTime(obj.dr["EndDate"].ToString()).ToString("dd/MM/yyyy"); ;
                LblValidPeriod.Text = validityperiod;
                string a = obj.dr["PermitApprovalDatetime"].ToString();
                // string a = "20190321152148SST";
                string year = a.Substring(0, 4);
                string month = a.Substring(4, 2);
                string date = a.Substring(6, 2);
                string hour = a.Substring(8, 2);
                string minit = a.Substring(10, 2);
                string sec = a.Substring(12, 2);


                string finalappdate = date + "-" + month + "-" + year + " " + hour + ":" + minit + ":" + sec;
                //  20190321152148SST
                LblApprovedDate.Text = finalappdate;
            }
            //UpdatePercon.Update();
            co.Update();
            coheader.Update();




        }
        protected void BtnAddNEWItem_Click(object sender, EventArgs e)
        {
            ItemAddGrid.Visible = true;
            ItemDiv.Visible = true;
            BtnAddNEWItem.Visible = false;
            ItemNO();
        }
        private void editcontainer()
        {
            SqlConnection con = new SqlConnection(sqlconn);
            //SqlCommand cmd1 = new SqlCommand("SELECT T1.Id ,T1.CRP,T1.CompanyName,T1.Name,T1.EmailId,T1.Mobile, T2.Name as Rent ,t1.BudgetFrom,T1.BudgetTo ,T3.Name as Type,T4.Name as Location,T5.PropertyRef,T1.MultipleLocation,T1. MultipleProperty  FROM (select a.Id,a.CompanyName,a.Name,a.EmailId,a.Mobile,a.BudgetFrom,a.BudgetTo,b.Name as CRP,a.MultipleLocation,a.MultipleProperty  from lead a,CommonMaster b where a.Per_Com=b.Id and a.TouchUser='" + Touch_user + "') AS T1 JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.RentorBuy=b.Id) AS T2    ON T1.Id = T2.Id    JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Type=b.Id) AS T3  ON T1.Id = T3.Id     JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Location=b.Id) AS T4   ON T1.Id = T4.Id    JOIN ( select b.ID,b.Name,a.PropertyRef  from Lead_List a,Lead b where a.ParentId=b.Id) AS T5   ON T1.Id = T5.Id order by T1.Id desc", con);
            SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,ContainerNo as Column1, Size as Column2,Weight as Column3, SealNo as Column4 from COHeaderTbl a,TranshipmentContainerDtl b where a.PermitId=b.PermitId and a.PermitId='" + txt_code.Text + "' order by RowNo", con);
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            if (dt.Rows.Count <= 0)
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
            SqlConnection con = new SqlConnection(sqlconn);
            //SqlCommand cmd1 = new SqlCommand("SELECT T1.Id ,T1.CRP,T1.CompanyName,T1.Name,T1.EmailId,T1.Mobile, T2.Name as Rent ,t1.BudgetFrom,T1.BudgetTo ,T3.Name as Type,T4.Name as Location,T5.PropertyRef,T1.MultipleLocation,T1. MultipleProperty  FROM (select a.Id,a.CompanyName,a.Name,a.EmailId,a.Mobile,a.BudgetFrom,a.BudgetTo,b.Name as CRP,a.MultipleLocation,a.MultipleProperty  from lead a,CommonMaster b where a.Per_Com=b.Id and a.TouchUser='" + Touch_user + "') AS T1 JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.RentorBuy=b.Id) AS T2    ON T1.Id = T2.Id    JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Type=b.Id) AS T3  ON T1.Id = T3.Id     JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Location=b.Id) AS T4   ON T1.Id = T4.Id    JOIN ( select b.ID,b.Name,a.PropertyRef  from Lead_List a,Lead b where a.ParentId=b.Id) AS T5   ON T1.Id = T5.Id order by T1.Id desc", con);
            SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,ProcessingCode1,ProcessingCode2,ProcessingCode3 from InHeaderTbl a,TranshipmentCPCDtl b where a.PermitId=b.PermitId and b.CPCType='AEO' and a.PermitId='" + txt_code.Text + "'", con);
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            if (dt.Rows.Count <= 0)
            {
                dt.Rows.Add();
            }
            ViewState["CurrentTable"] = dt;
            int rowIndex = 0;
            AEOGrid.DataSource = ViewState["Container"] as DataTable;
            AEOGrid.DataBind();
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
            SqlConnection con = new SqlConnection(sqlconn);
            //SqlCommand cmd1 = new SqlCommand("SELECT T1.Id ,T1.CRP,T1.CompanyName,T1.Name,T1.EmailId,T1.Mobile, T2.Name as Rent ,t1.BudgetFrom,T1.BudgetTo ,T3.Name as Type,T4.Name as Location,T5.PropertyRef,T1.MultipleLocation,T1. MultipleProperty  FROM (select a.Id,a.CompanyName,a.Name,a.EmailId,a.Mobile,a.BudgetFrom,a.BudgetTo,b.Name as CRP,a.MultipleLocation,a.MultipleProperty  from lead a,CommonMaster b where a.Per_Com=b.Id and a.TouchUser='" + Touch_user + "') AS T1 JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.RentorBuy=b.Id) AS T2    ON T1.Id = T2.Id    JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Type=b.Id) AS T3  ON T1.Id = T3.Id     JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Location=b.Id) AS T4   ON T1.Id = T4.Id    JOIN ( select b.ID,b.Name,a.PropertyRef  from Lead_List a,Lead b where a.ParentId=b.Id) AS T5   ON T1.Id = T5.Id order by T1.Id desc", con);
            SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,ProcessingCode1,ProcessingCode2,ProcessingCode3 from InHeaderTbl a,TranshipmentCPCDtl b where a.PermitId=b.PermitId and b.CPCType='CWC' and a.PermitId='" + txt_code.Text + "'", con);
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            if (dt.Rows.Count <= 0)
            {
                dt.Rows.Add();
            }
            ViewState["CurrentTable"] = dt;
            int rowIndex = 0;
            CWCGrid.DataSource = ViewState["Container"] as DataTable;
            CWCGrid.DataBind();
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

            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from COFileUpload where InPaymentId='" + MsgNO + "'"))
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

       

        public void CoEdit()
        {
            BindCondition();
            //vessel nat
            string stqrn = "select * from [Country]  order by Description";
            obj.dr = obj.ret_dr(stqrn);
            DroVesslNat.DataSource = obj.dr;
            DroVesslNat.DataTextField = "Description";
            DroVesslNat.DataValueField = "Id";
            DroVesslNat.DataBind();
            obj.closecon();
            DroVesslNat.Items.Insert(0, new ListItem("--Select--", "0"));
            string DecCompany, ff, climant, Exporter,outward,Manufac = "";
            string strBindTxtBox = "";
            if (TempDataPermitNo != "")
            {
                strBindTxtBox = "select * from [CoTemp] where PermitID='" + TempDataPermitNo + "' and TouchUser='" + Session["UserId"].ToString() + "'";
            }
            else
            {
                strBindTxtBox = "select * from [COHeaderTbl] where Id=" + Id;
            }

          //  string strBindTxtBox = "select * from [COHeaderTbl] where Id=" + Id;
            obj.dr = obj.ret_dr(strBindTxtBox);
            while (obj.dr.Read())
            {



                msgid= obj.dr["MSGId"].ToString();
                Permitnum= obj.dr["PermitNumber"].ToString();
                refno = obj.dr["Refid"].ToString();
                JobNo = obj.dr["JobId"].ToString();
                MsgNO = obj.dr["MSGId"].ToString();
                txt_code.Text = obj.dr["PermitId"].ToString();
                //TxtTradeMailID.Text = obj.dr["TradeNetMailboxID"].ToString();
                TxtMsgType.Text = obj.dr["MessageType"].ToString();
                TxtAppType.Text = obj.dr["ApplicationType"].ToString();
                TxtPrevPerNO.Text = obj.dr["PreviousPermitNo"].ToString();

                TxtGrossReference.Text = obj.dr["Additionalrecieptant"].ToString();

               // DrpDecType.Items.FindByText(obj.dr[6].ToString()).Selected = true;
                 //DrpDecType.SelectedItem.Text = obj.dr[6].ToString();
              //  DrpCargoPackType.Items.FindByText(obj.dr[7].ToString()).Selected = true;
                DrpOutwardtrasMode.ClearSelection();
                DrpOutwardtrasMode.Items.FindByText(obj.dr["OutwardTransportMode"].ToString()).Selected = true;
                //DrpOutwardtrasMode.SelectedItem.Text = obj.dr[9].ToString();
               // DrpBGIndicator.ClearSelection();
               //DrpBGIndicator.Items.FindByText(obj.dr[9].ToString()).Selected = true;
                //DrpBGIndicator.SelectedItem.Text = obj.dr[9].ToString();
                //string ChkSupplyIndicator1 = obj.dr[11].ToString();
                //if (ChkSupplyIndicator1 == "True")
                //{
                //    ChkSupplyIndicator.Checked = true;
                //}
                //else if (ChkSupplyIndicator1 == "False")
                //{
                //    ChkSupplyIndicator.Checked = false;
                //}

                string ChkRefDoc1 = obj.dr["ReferenceDocuments"].ToString();
                if (ChkRefDoc1 == "True" || ChkRefDoc1 == "true")
                {
                    ChkRefDoc.Checked = true;
                    EditDocument();
                }
                else if (ChkRefDoc1 == "False" || ChkRefDoc1 == "false")
                {
                    ChkRefDoc.Checked = false;
                }
                ChkRefDoc_CheckedChanged(null,null);
                DrpCoType.ClearSelection();
                DrpCoType.Items.FindByText(obj.dr["COType"].ToString()).Selected = true;
                DrpCerDtl1.ClearSelection();
                DrpCerDtl1.Items.FindByText(obj.dr["CerDtlType1"].ToString()).Selected = true;
                DrpCerDtl1_SelectedIndexChanged(null, null);
                TxtCerDtl1.Text = obj.dr["CerDtlCopy1"].ToString();

                DrpCerDtl2.ClearSelection();
                DrpCerDtl2.Items.FindByText(obj.dr["CerDtlType2"].ToString()).Selected = true;                
                TxtCerDtl2.Text = obj.dr["CerDtlCopy2"].ToString();
                DrpCurrencyCode.ClearSelection();
                DrpCurrencyCode.Items.FindByText(obj.dr["CurrencyCode"].ToString()).Selected = true;

                string Receipt = obj.dr["AdditionalCer"].ToString();
                char[] Receipt1 = { '-' };
                string[] Receipt12 = Receipt.Split(Receipt1); //will split names using comma as delimiter
                AddCerDtl1.Text = Receipt12[0].ToString();
                AddCerDtl2.Text = Receipt12[1].ToString();
                AddCerDtl3.Text = Receipt12[2].ToString();
                AddCerDtl4.Text = Receipt12[3].ToString();
                AddCerDtl5.Text = Receipt12[4].ToString();


                string Receiptt = obj.dr["TransportDtl"].ToString();
                char[] Receipt1t = { '-' };
                string[] Receipt12t = Receiptt.Split(Receipt1t); //will split names using comma as delimiter
                TransDtl1.Text = Receipt12t[0].ToString();
                TransDtl2.Text = Receipt12t[1].ToString();
                TransDtl3.Text = Receipt12t[2].ToString();
                TransDtl4.Text = Receipt12t[3].ToString();
                TransDtl5.Text = Receipt12t[4].ToString();





                string Receipt11 = obj.dr["Additionalrecieptant"].ToString();
                char[] Receipt111 = { '-' };
                string[] Receipt112 = Receipt11.Split(Receipt111); //will split names using comma as delimiter
                TxtRECPT1.Text = Receipt112[0].ToString();
                if (Receipt112.Length == 2)
                {

                    TxtRECPT2.Text = Receipt112[1].ToString();
                }
                if (Receipt112.Length == 3)
                {

                    TxtRECPT3.Text = Receipt112[2].ToString();
                }

                TextMode.Text = obj.dr["OutwardTransportMode"].ToString();


                TxtExpArrivalDate1.Text = Convert.ToDateTime(obj.dr["DepartureDate"].ToString()).ToString("dd/MM/yyyy");
                TxtExpLoadShort.Text = obj.dr["DischargePort"].ToString();
                TxtExpLoadShort_TextChanged(null, null);
                DrpFinalDesCountry.ClearSelection();
                string fnl = obj.dr["FinalDestinationCountry"].ToString();
                DrpFinalDesCountry.Items.FindByText(obj.dr["FinalDestinationCountry"].ToString()).Selected = true;
               // DrpFinalDesCountry.SelectedItem.Text = obj.dr[19].ToString();


                OUTWARDVoyageNo.Text = obj.dr["OutVoyageNumber"].ToString();
                OUTWARDVessel.Text = obj.dr["OutVesselName"].ToString();

                OUTWARDConref.Text = obj.dr["OutConveyanceRefNo"].ToString();
                OUTWARDTransId.Text = obj.dr["OutTransportId"].ToString();
                OUTWARDFlightN0.Text = obj.dr["OutFlightNO"].ToString();
                OUTWARDAirREgno.Text = obj.dr["OutAircraftRegNo"].ToString();



                TxttotalOuterPack.Text = obj.dr["TotalOuterPack"].ToString();
                DrptotalOuterPack.ClearSelection();
                DrptotalOuterPack.Items.FindByText(obj.dr["TotalOuterPackUOM"].ToString()).Selected = true;



                TxtTotalGrossWeight.Text = obj.dr["TotalGrossWeight"].ToString();
                 DrpTotalGrossWeight.ClearSelection();
                 DrpTotalGrossWeight.Items.FindByText(obj.dr["TotalGrossWeightUOM"].ToString()).Selected = true;

                 txtinternal.Text = obj.dr["InternalRemarks"].ToString();
                 txttrdremrk.Text = obj.dr["TradeRemarks"].ToString();
                 txtper.Text = obj.dr["Percomwealth"].ToString();
                
                Drpgpsdonorcountry.ClearSelection();

                if (!string.IsNullOrWhiteSpace(obj.dr["Gpsdonorcountry"].ToString()))
                {
                    Drpgpsdonorcountry.Items.FindByText(obj.dr["Gpsdonorcountry"].ToString()).Selected = true;
                }
                else
                {
                    Drpgpsdonorcountry.Items.FindByText("--Select--").Selected = true;
                }
                DecCompany = obj.dr["DeclarantCompanyCode"].ToString();
                //Importer = obj.dr[19].ToString();
                Exporter = obj.dr["ExporterCompanyCode"].ToString();
              //  inwardcarrier = obj.dr[21].ToString();
                outward = obj.dr["OutwardCarrierAgentCode"].ToString();
                Manufac = obj.dr["Manufacturer"].ToString();

                ff = obj.dr["FreightForwarderCode"].ToString();
                climant = obj.dr["CONSIGNEECode"].ToString();

                string supp = "select * from [DeclarantCompany] where Code='" + DecCompany + "'";
                obj.dr = obj.ret_dr(supp);
                while (obj.dr.Read())
                {
                    TxtDecCompCode.Text = obj.dr["Code"].ToString();
                    TxtDecCompName.Text = obj.dr["Name"].ToString();
                    TxtDecCompName1.Text = obj.dr["Name1"].ToString();
                    TxtDecCompCRUEI.Text = obj.dr["CRUEI"].ToString();
                }


                string Exp = "select * from [COExporter] where Code='" + Exporter + "'";
                obj.dr = obj.ret_dr(Exp);
                while (obj.dr.Read())
                {
                    TxtExpCode.Text = obj.dr["Code"].ToString();
                    TxtExpName.Text = obj.dr["Name"].ToString();
                    TxtExpName1.Text = obj.dr["Name1"].ToString();
                    TxtExpCRUEI.Text = obj.dr["CRUEI"].ToString();
                    txtadd1.Text = obj.dr["Address"].ToString();

                    txtadd2.Text = obj.dr["Address1"].ToString();
                    txtadd3.Text = obj.dr["Address2"].ToString();
                }

                string outw = "select * from [COOutwardCarrierAgent] where Code='" + outward + "'";
                obj.dr = obj.ret_dr(outw);
                while (obj.dr.Read())
                {
                    OutwardCode.Text = obj.dr["Code"].ToString();
                    OutwardName.Text = obj.dr["Name"].ToString();
                    OutwardName1.Text = obj.dr["Name1"].ToString();
                    OutwardCRUEI.Text = obj.dr["CRUEI"].ToString();
                }

                string ff1 = "select * from [COFreightForwarder] where Code='" + ff + "'";
                obj.dr = obj.ret_dr(ff1);
                while (obj.dr.Read())
                {
                    FrieghtCode.Text = obj.dr["Code"].ToString();
                    FrieghtName.Text = obj.dr["Name"].ToString();
                    FrieghtName1.Text = obj.dr["Name1"].ToString();
                    FrieghtCRUEI.Text = obj.dr["CRUEI"].ToString();
                }


                string cli = "select * from [COConsignee] where ConsigneeCode='" + climant + "'";
                obj.dr = obj.ret_dr(cli);
                while (obj.dr.Read())
                {
                    ConsigneeCode.Text = obj.dr["ConsigneeCode"].ToString();
                    ConsigneeName.Text = obj.dr["ConsigneeName"].ToString();
                    ConsigneeName1.Text = obj.dr["ConsigneeName1"].ToString();
                    ConsigneeCRUEI.Text = obj.dr["ConsigneeCRUEI"].ToString();
                    ConsigneeAddress.Text = obj.dr["ConsigneeAddress"].ToString();

                    ConsigneeAddress1.Text = obj.dr["ConsigneeAddress1"].ToString();
                    ConsigneeCity.Text = obj.dr["ConsigneeCity"].ToString();
                    ConsigneeSub.Text = obj.dr["ConsigneeSub"].ToString();
                    ConsigneePostal.Text = obj.dr["ConsigneePostal"].ToString();
                    ConsigneeCountry.Text = obj.dr["ConsigneeCountry"].ToString();
                }



                string manufac = "select * from [COManufacturer] where ManufacturerCode='" + Manufac + "'";
                obj.dr = obj.ret_dr(manufac);
                while (obj.dr.Read())
                {
                    ManufacturerCode.Text = obj.dr["ManufacturerCode"].ToString();
                    ManufacturerName.Text = obj.dr["ManufacturerName"].ToString();
                    ManufacturerName1.Text = obj.dr["ManufacturerName1"].ToString();
                    ManufacturerCRUEI.Text = obj.dr["ManufacturerCRUEI"].ToString();
                    ManufacturerAddress.Text = obj.dr["ManufacturerAddress"].ToString();
                    ManufacturerAddress1.Text = obj.dr["ManufacturerAddress1"].ToString();
                    ManufacturerCity.Text = obj.dr["ManufacturerCity"].ToString();
                    ManufacturerSubCode.Text = obj.dr["ManufacturerSub"].ToString();
                    ManufacturerSubDivi.Text = obj.dr["ManufacturerSubDivi"].ToString();
                    ManufacturerPostal.Text = obj.dr["ManufacturerPostal"].ToString();
                    ManufacturerCountry.Text = obj.dr["ManufacturerCountry"].ToString();
                }

                DrpOutwardtrasMode_SelectedIndexChanged(null,null);
                ChkRefDoc_CheckedChanged(null, null);
                TxtLoadShort_TextChanged(null, null);
                txtreLoctn_TextChanged(null, null);
                txtrecloctn_TextChanged(null, null);
                TxtExpCode_TextChanged(null, null);
                DrpCerDtl1_SelectedIndexChanged(null, null);
                TxttotalOuterPack_TextChanged(null, null);
                DrpCoType_SelectedIndexChanged(null, null);
                TxtTotalGrossWeight_TextChanged(null, null);
                DrpOutwardtrasMode_SelectedIndexChanged(null, null);

                txtcifitemvalue_TextChanged(null, null);
                DrpCurrencyCode_SelectedIndexChanged(null,null);
                TxtPrevPerNO_TextChanged(null,null);

                editcontainer();
                editCPCAEO();
                editCPCcwc();
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
              
                BindItemMaster();
                //edit = true;
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
                DrpType.DataSource = obj.dr;
                DrpType.DataTextField = "Name";
                DrpType.DataValueField = "Id";
                DrpType.DataBind();
                obj.closecon();
                DrpType.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }


       
   
        private void BindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id,DocumentType,Name FROM COFileUpload where  InPaymentId='" + MsgNO + "'"))
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
        private void BindGridCancel()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id,DocumentType,Name FROM InFile where InPaymentId='" + txt_code.Text + "' "))
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

            string strDelete = "delete from COFileUpload where Id='" + id + "' ";
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
                SqlCommand cmd = new SqlCommand("DELETE FROM COFileUpload where ID=" + employeeId, con);
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
                using (SqlCommand cmd = new SqlCommand("SELECT Id,Code,Name,Name1,CRUEI FROM DeclarantCompany"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
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
            popupcodec.Show();
            popupcodec.X = 300;
            popupcodec.Y = 100;
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
               // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
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
            TxtExpCode.Focus();
        }
        protected void DECPLUS_Click(object sender, EventArgs e)
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
                string StrQuery = ("INSERT INTO [dbo].[DeclarantCompany] ([Code],[Name],[Name1],[CRUEI],[TouchUser],[TouchTime]) VALUES ('" + TxtDecCompCode.Text + "','" + TxtDecCompName.Text + "','" + TxtDecCompName1.Text + "','" + TxtDecCompCRUEI.Text + "','" + Touch_user + "',Convert(VARCHAR,'" + strTime + "',108))");
                obj.exec(StrQuery);
                decBindGrid();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The DeclarantCompany Code Already Exist...');", true);
                // Response.Write("The DeclarantCompany Code Already Exist..");
            }


        }

        //Importer Code
        
        //Inward Code
        //Inward 

        private void BindInward()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id,Code,Name,Name1,CRUEI FROM COInwardCarrierAgent"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
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
               // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalInward();", true);
            }
        }

        protected void InwardGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            InwardGrid.PageIndex = e.NewPageIndex;
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalInward();", true);
            BindInward();
            popupcoinw.Show();
            popupcoinw.X = 300;
            popupcoinw.Y = 100;
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
            string Code = "";
            string qry11 = "SELECT Code FROM COInwardCarrierAgent where Code='" + InwardCode.Text + "'";

            obj.dr = obj.ret_dr(qry11);

            while (obj.dr.Read())
            {
                Code = obj.dr[0].ToString();

            }
            if (Code == "")
            {
                string Touch_user = Session["UserId"].ToString();

                string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string StrQuery = ("INSERT INTO [dbo].[InwardCarrierAgent] ([Code],[Name],[Name1],[CRUEI],[TouchUser],[TouchTime]) VALUES ('" + InwardCode.Text + "','" + InwardName.Text + "','" + InwardName1.Text + "','" + InwardCRUEI.Text + "','" + Touch_user + "',Convert(VARCHAR,'" + strTime + "',108))");
                obj.exec(StrQuery);
                BindInward();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Inward Code Already Exist...');", true);
                //Response.Write("The Inward Code Already Exist..");
            }

        }

        public DataTable GetInwardDataFromDataBase(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = InwardSearch.Text;

            string str3 = "SELECT Id,Code,Name,Name1,CRUEI FROM COInwardCarrierAgent where Code Like '%" + InwardSearch.Text + "%' order by Id desc";
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
                string qry11 = "select * from COInwardCarrierAgent where Code='" + ss[0].ToString() + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {


                    InwardCode.Text = obj.dr[1].ToString();
                    InwardName.Text = obj.dr[2].ToString();
                    InwardName1.Text = obj.dr[3].ToString();
                    InwardCRUEI.Text = obj.dr[4].ToString();

                }
            }
            FrieghtCode.Focus();

        }
        //freight 
        private void BindFrieght()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id,Code,Name,Name1,CRUEI FROM COFreightForwarder"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
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
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalfright();", true);
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
            string Code = "";
            string qry11 = "SELECT Code FROM COFreightForwarder where Code='" + FrieghtCode.Text + "'";

            obj.dr = obj.ret_dr(qry11);

            while (obj.dr.Read())
            {
                Code = obj.dr[0].ToString();

            }
            if (Code == "")
            {
                string Touch_user = Session["UserId"].ToString();

                string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string StrQuery = ("INSERT INTO [dbo].[COFreightForwarder] ([Code],[Name],[Name1],[CRUEI],[TouchUser],[TouchTime]) VALUES ('" + FrieghtCode.Text + "','" + FrieghtName.Text + "','" + FrieghtName1.Text + "','" + FrieghtCRUEI.Text + "','" + Touch_user + "',Convert(VARCHAR,'" + strTime + "',108))");
                obj.exec(StrQuery);
                BindFrieght();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The FreightForwarder Code Already Exist...');", true);
                // Response.Write("The FreightForwarder Code Already Exist..");
            }
        }
        public DataTable GetFreightDataFromDataBase(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = FrieghtSearch.Text;

            string str3 = "SELECT Id,Code,Name,Name1,CRUEI FROM COFreightForwarder where Code Like '%" + FrieghtSearch.Text + "%' order by Id desc";
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
                string qry11 = "select * from COFreightForwarder where Code='" + ss[0].ToString() + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    FrieghtCode.Text = obj.dr[1].ToString();
                    FrieghtName.Text = obj.dr[2].ToString();
                    FrieghtName1.Text = obj.dr[3].ToString();
                    FrieghtCRUEI.Text = obj.dr[4].ToString();

                }
            }
            ConsigneeCode.Focus();
        }

        protected void FrieghtGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            FrieghtGrid.PageIndex = e.NewPageIndex;
           // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalfright();", true);
            BindFrieght();
            popupcofreight.Show();
            popupcofreight.X = 300;
            popupcofreight.Y = 100;
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
            }
        }

        protected void LoadingGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LoadingGrid.PageIndex = e.NewPageIndex;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalLoading();", true);
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
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM ReleaseLocation"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
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
               // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openLocation();", true);
            }
        }

        protected void LocationGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LocationGrid.PageIndex = e.NewPageIndex;
           // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openLocation();", true);
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

                string qry11 = "select * from ReleaseLocation where Code='" + txtreLoctn.Text + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {



                    txtreLoctn.Text = obj.dr[2].ToString();
                    txtrelocDeta.Text = obj.dr[3].ToString();


                }
            }
        }
        private void Bindreceipt()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM ReceiptLocation"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openReceipt();", true);
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
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openReceipt();", true);
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
            if (txtreLoctn.Text != "")
            {

                string qry11 = "select * from ReleaseLocation where Code='" + txtrecloctn.Text + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {



                    txtrecloctn.Text = obj.dr[2].ToString();
                    txtrecloctndet.Text = obj.dr[3].ToString();


                }
            }
        }
        private void BindLoading()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM LoadingPort"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
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

            string str3 = "SELECT * FROM LoadingPort where PortCode Like '%" + CarLoadingSearch.Text + "%' order by Id desc";
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

                string qry11 = "select * from LoadingPort where PortCode='" + TxtLoadShort.Text + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {


                    TxtLoadShort.Text = obj.dr[1].ToString();
                    TxtLoad.Text = obj.dr[2].ToString();


                }
            }
        }
        //invoice
    
        //CPC
        private void SetInitialRowc()
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

            ViewState["CurrentTable"] = dt;



            AEOGrid.DataSource = dt;

            AEOGrid.DataBind();
            AEOGrid.Columns[0].Visible = false;

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



                        dtCurrentTable.Rows[i - 1]["Processing Code1"] = box1.Text;

                        dtCurrentTable.Rows[i - 1]["Processing Code2"] = box2.Text;

                        dtCurrentTable.Rows[i - 1]["Processing Code3"] = box3.Text;



                        rowIndex++;

                    }

                    dtCurrentTable.Rows.Add(drCurrentRow);

                    ViewState["CurrentTable"] = dtCurrentTable;



                    AEOGrid.DataSource = dtCurrentTable;

                    AEOGrid.DataBind();
                    AEOGrid.Columns[0].Visible = false;
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



                        box1.Text = dt.Rows[i]["Processing Code1"].ToString();

                        box2.Text = dt.Rows[i]["Processing Code2"].ToString();

                        box3.Text = dt.Rows[i]["Processing Code3"].ToString();



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

            ViewState["CurrentTable1"] = dt;

            CWCGrid.DataSource = dt;

            CWCGrid.DataBind();
            CWCGrid.Columns[0].Visible = false;

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



                        dtCurrentTable.Rows[i - 1]["Processing Code1"] = box1.Text;

                        dtCurrentTable.Rows[i - 1]["Processing Code2"] = box2.Text;

                        dtCurrentTable.Rows[i - 1]["Processing Code3"] = box3.Text;



                        rowIndex++;

                    }

                    dtCurrentTable.Rows.Add(drCurrentRow);

                    ViewState["CurrentTable1"] = dtCurrentTable;



                    CWCGrid.DataSource = dtCurrentTable;

                    CWCGrid.DataBind();
                    CWCGrid.Columns[0].Visible = false;
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



                        box1.Text = dt.Rows[i]["Processing Code1"].ToString();

                        box2.Text = dt.Rows[i]["Processing Code2"].ToString();

                        box3.Text = dt.Rows[i]["Processing Code3"].ToString();



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

            ViewState["CurrentTable2"] = dt;

            SeaGrid.DataSource = dt;

            SeaGrid.DataBind();
            SeaGrid.Columns[0].Visible = false;

        }
        private void AddNewRowToGrid2cp()
        {

            int rowIndex = 0;



            if (ViewState["CurrentTable2"] != null)
            {

                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable2"];

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

                    ViewState["CurrentTable2"] = dtCurrentTable;



                    SeaGrid.DataSource = dtCurrentTable;

                    SeaGrid.DataBind();
                    SeaGrid.Columns[0].Visible = false;
                }

            }

            else
            {

                Response.Write("ViewState is null");

            }



            //Set Previous Data on Postbacks

            SetPreviousData2cp();

        }
        private void SetPreviousData2cp()
        {

            int rowIndex = 0;

            if (ViewState["CurrentTable2"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTable2"];

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
            AddNewRowToGridc();
        }

        protected void BtnCWC_Click(object sender, EventArgs e)
        {
            if (CWCGrid.Rows.Count <= 0)
            {
                SetInitialRow1cp();
            }
            else
            {
                AddNewRowToGrid1cp();
            }
        }

     

     //item cosde

      
        //heADER uPLOAD
        protected void Btn_Upload_Click(object sender, EventArgs e)
        {
            int infi = 1;
            //if (FileUpload1.HasFile)
            //{
            //if ((FileUpload1.PostedFile != null))
            //{
            foreach (HttpPostedFile postedFile in FileUpload1.PostedFiles)
            {
                string filename = Path.GetFileName(postedFile.FileName);
                string contentType = "";
                FileUpload1.SaveAs(@"C:\Users\Public\IMG" + filename);
                string path = @"C:\Users\Public\IMG\";
                path = path + filename;
                FileUpload1.SaveAs(path);
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
                            string DocType = DrpDocType.SelectedItem.ToString();
                            string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            string query = "insert into COFileUpload values (@Name, @ContentType, @Data,@DocumentType,@InPaymentId,@TouchUser,@TouchTime)";
                            using (SqlCommand cmd = new SqlCommand(query))
                            {

                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@Sno", infi);
                                cmd.Parameters.AddWithValue("@Name", filename);
                                cmd.Parameters.AddWithValue("@ContentType", contentType);
                                cmd.Parameters.AddWithValue("@Data", bytes);
                                cmd.Parameters.AddWithValue("@DocumentType", DocType);
                                cmd.Parameters.AddWithValue("@InPaymentId", MsgNO);
                                cmd.Parameters.AddWithValue("@TouchUser", Touch_user);
                                cmd.Parameters.AddWithValue("@TouchTime", strTime);
                                cmd.Parameters.AddWithValue("@filePath", path);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                                BindGrid();
                            }
                        }
                    }
                }
                infi++;
                updoc.Update();
            }

            DrpDocType.ClearSelection();
            DrpDocType.Items.FindByText("--Select--").Selected = true;
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
              //  string BGIndicator = "";
               

                //string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                //string StrQuery = ("INSERT INTO [dbo].[InhouseItemCode] ([InhouseCode],[HSCode],[Description],[Brand],[Model],[DGIndicator],[TouchUser],[TouchTime]) VALUES ('" + TxtInHouseItem.Text + "','" + TxtHSCodeItem.Text + "','" + TxtDescription.Text + "','" + TxtBrand.Text + "','" + TxtModel.Text + "','" + BGIndicator + "','" + Touch_user + "',Convert(VARCHAR,'" + strTime + "',108))");
                //obj.exec(StrQuery);
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
                    //TxtBrand.Text = "";
                    //TxtModel.Text = "";

                    TxtInHouseItem.Text = requestor;
                    TxtHSCodeItem.Text = requestType;
                    TxtDescription.Text = status;
                    //TxtBrand.Text = crueis;
                    //TxtModel.Text = Model1;
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
            var a = TxtHSCodeItem.Text;

            string str3 = "SELECT * FROM HSCode where HSCode Like '%" + TxtHSCodeItem.Text + "%' order by Id desc";
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
        }


        private void BindInhouse()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM InhouseItemCode"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
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
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM HSCode"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
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
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Country"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
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
                if (TxtHSCodeItem.Text.Trim().StartsWith("87"))
                {
                    //Vehicle.Visible = true;
                    //OptionalCharges.Visible = true;
                }
                else
                {
                    //OptionalCharges.Visible = false;
                }
                string[] ss = TxtHSCodeItem.Text.Split(':');
                string qry11 = "select UOM from HSCode where HSCode='" + ss[0].ToString() + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    string UOm = obj.dr[0].ToString();
                    if (obj.dr[0].ToString() == "-")
                    {
                        drpInvoiceUOM.ClearSelection();
                        // HSQTYUOM.Items.FindByText(obj.dr["UOM"].ToString()).Selected = true;
                    }
                    else
                    {
                        drpInvoiceUOM.ClearSelection();
                        drpInvoiceUOM.Items.FindByText(UOm).Selected = true;
                    }
                }
                //  hscodecoltroll(ss[0].ToString());
                hscode(ss[0].ToString());
                string qry111 = "select * from HSCode where HSCode='" + ss[0].ToString() + "'";
                obj.dr = obj.ret_dr(qry111);
                int typeid = 0;
                while (obj.dr.Read())
                {
                    typeid = Convert.ToInt32(obj.dr["DUTYTYPID"].ToString());
                    TxtHSCodeItem.Text = obj.dr["HSCode"].ToString();
                    TxtDescription.Text = obj.dr["Description"].ToString();
                   
                }

                if (typeid == 61 || typeid == 62 || typeid == 63 || typeid == 64)
                {
                    totDuticableQtyDiv.Visible = true;
                    AlcoholDiv.Visible = false;
                }
                else
                {
                    totDuticableQtyDiv.Visible = false;
                    AlcoholDiv.Visible = false;
                }

                /*hscodecoltroll(TxtHSCodeItem.Text);
                    
                   // string[] ss = TxtHSCodeItem.Text.Split(':');
                    string qry11 = "select * from HSCode where HSCode='" + ss[0].ToString() + "'";
                    obj.dr = obj.ret_dr(qry11);
                    while (obj.dr.Read())
                    {
                        TxtHSCodeItem.Text = obj.dr[1].ToString();
                        TxtDescription.Text = obj.dr[2].ToString();
                        BindProduct1();
                    }
                    qry11 = "select UOM from HSCode where HSCode='" + TxtHSCodeItem.Text + "'";
                    obj.dr = obj.ret_dr(qry11);
                    while (obj.dr.Read())
                    {
                        string UOm = obj.dr[0].ToString();
                        if (obj.dr[0].ToString() == "-")
                        {
                            HSQTYUOM.ClearSelection();
                               //HSQTYUOM.Items.FindByText(obj.dr[0].ToString()).Selected = true;
                        }
                    }  */   




            }
            else
            {
                drpInvoiceUOM.ClearSelection();
                TxtHSCodeItem.Text = "";
                TxtDescription.Text = "";

            }
            TxtDescription.Focus();
        }
        private void hscode(string hscode)
        {

            //string TYPEId = "";
            string qry11s2 = "select * from [CommonMasterType] as a , HSCode as b where a.Id=b.Typeid  and HSCode='" + hscode + "' and Out=1";
            obj.dr = obj.ret_dr(qry11s2);
            if (obj.dr.Read())
            {
                // TYPEId = obj.dr["Id"].ToString();
                lblhserror.Visible = true;
                lblhserror.Text = obj.dr["Type"].ToString();

            }
            else
            {
                lblhserror.Visible = false;
                lblhserror.Text = "";
            }

            string dutable = "select * from [CommonMasterType] as a , HSCode as b where a.Id=b.DUTYTYPID  and HSCode='" + hscode + "' and Out=1";
            obj.dr = obj.ret_dr(dutable);
            if (obj.dr.Read())
            {
                // TYPEId = obj.dr["Id"].ToString();

                lbldhserror.Visible = true;
                lbldhserror.Text = obj.dr["Type"].ToString();

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
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openCountry();", true);
            BindCountry();
            popupcoorgin.Show();
            popupcoorgin.X = 300;
            popupcoorgin.Y = 100;
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

                    //TxtHSCode.Text = requestType;
                    TxtCountryItem.Text =  requestType;
                    txtcname.Text = status;
                }

            }
        }

        protected void TxtCountryItem_TextChanged(object sender, EventArgs e)
        {
            if (TxtCountryItem.Text != "")
            {
                string[] ss = TxtCountryItem.Text.Split(':');
                string qry11 = "select * from Country where CountryCode='" + ss[0].ToString() + "'";
                COClass objcut = new COClass();
                objcut.dr = objcut.ret_dr(qry11);
                while (objcut.dr.Read())
                {
                    TxtCountryItem.Text = objcut.dr[1].ToString();
                    txtcname.Text = objcut.dr[2].ToString();
                }
            }
        }

        

     

       

        //Validation Page Change
        protected void TxtRECPT3_TextChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Party();", true);
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
            string justdate = DateTime.Now.ToString("yyyyMMdd");
            string Touch_user = Session["UserId"].ToString();
            con.Open();
            SqlCommand command1 = new SqlCommand("SELECT Max(Refid) from TranshipmentHeader where MessageType='COODEC' and  LEFT(MSGId,8) ='" + justdate + "'");
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
            string code = String.Format("{0:000}", m_po_no);
            con.Close();
            refno = code;
        }
        private void PermitNO()
        {
            string justdate = DateTime.Now.ToString("yyyyMMdd");
            string Touch_user = Session["UserId"].ToString();
            con.Open();
            SqlCommand command1 = new SqlCommand("SELECT max(Id) from COHeaderTbl where MessageType='COODEC' and  LEFT(MSGId,8) ='" + justdate + "'");
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



        //private void InvoiceNo()
        //{
        //    con.Open();
        //    SqlCommand command1q = new SqlCommand("SELECT max(SNo) from [InNonInvoiceDtl] where MessageType='COODEC'  ");
        //    command1q.Connection = con;
        //    string max_po_noq = command1q.ExecuteScalar().ToString();
        //    int m_po_noq = 0;

        //    int endTagStartPositionq = max_po_noq.LastIndexOf("/");
        //    max_po_noq = max_po_noq.Substring(endTagStartPositionq + 1);
        //    if (max_po_noq != "")
        //    {
        //        m_po_noq = Convert.ToInt32(max_po_noq);
        //    }
        //    else
        //    {
        //        m_po_noq = 0;
        //    }
        //    if (max_po_noq != "0")
        //    {
        //        m_po_noq = m_po_noq + 1;

        //    }
        //    string codeq = " " + String.Format("{0:000}", m_po_noq);
        //    con.Close();
        //    txtserial.Text = codeq;



        //}
        private void ItemNO()
        {
            con.Open();
            SqlCommand command1113 = new SqlCommand("SELECT max(ItemNo) from [COItemDtl] where MessageType='COODEC'  and PermitId='" + txt_code.Text + "'  ");
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
             string Touch_user = Session["UserId"].ToString();
                    DateTime DepatureDate = Convert.ToDateTime(null);
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
                   // var DepatureDate = DateTime.Parse(this.TxtExpArrivalDate1.Text, new CultureInfo("en-US", true));
                  
            if (Update == "AMEND")
            {
                //prmstatus = "AMD";
            }
            else if (Update == "CANCEL")
            {
                //prmstatus = "CNL";
            }
            else if (Update == "REFUND")
            {
                //prmstatus = "RFD";
            }
           ////Count Permit
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
                string AddCerDtl = AddCerDtl1.Text + '-' + AddCerDtl2.Text + '-' + AddCerDtl3.Text + '-' + AddCerDtl4.Text + '-' + AddCerDtl5.Text;
                string TransportDetails = TransDtl1.Text + '-' + TransDtl2.Text + '-' + TransDtl3.Text + '-' + TransDtl4.Text + '-' + TransDtl5.Text;
                string aditionalreceipt = TxtRECPT1.Text + '-' + TxtRECPT2.Text + '-' + TxtRECPT3.Text;
                string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string StrQuery = ("Update COHeaderTbl set Refid='" + refno + "',GrossReference='" + TxtGrossReference.Text + "',Additionalrecieptant='" + aditionalreceipt + "',Gpsdonorcountry='" + Drpgpsdonorcountry.SelectedItem.ToString() + "',Percomwealth='" + txtper.Text + "', MsgId='" + MsgNO + "' ,TradeNetMailboxID='" + TxtTradeMailID.Text + "',MessageType='" + TxtMsgType.Text + "',ApplicationType='" + TxtAppType.Text + "',PreviousPermitNo='" + TxtPrevPerNO.Text + "', OutwardTransportMode='" + DrpOutwardtrasMode.SelectedItem.ToString() + "',ReferenceDocuments='" + ChkRefDoc.Checked.ToString() + "',[COType] = '" + DrpCoType.SelectedItem.ToString() + "',[CerDtlType1] ='" + DrpCerDtl1.SelectedItem.ToString() + "' ,[CerDtlCopy1] = '" + TxtCerDtl1.Text + "' ,[CerDtlType2] ='" + DrpCerDtl2.SelectedItem.ToString() + "'  ,[CerDtlCopy2] ='" + TxtCerDtl2.Text + "' ,[CurrencyCode] ='" + DrpCurrencyCode.SelectedItem.ToString() + "' ,[AdditionalCer] = '" + AddCerDtl + "' ,[TransportDtl] = '" + TransportDetails + "',DeclarantCompanyCode='" + TxtDecCompCode.Text + "',ExporterCompanyCode='" + TxtExpCode.Text + "',OutwardCarrierAgentCode='" + OutwardCode.Text + "',FreightForwarderCode='" + FrieghtCode.Text + "',CONSIGNEECode='" + ConsigneeCode.Text + "',Manufacturer='" + ManufacturerCode.Text + "',DepartureDate='" + Convert.ToDateTime(DepatureDate).ToString("yyyy/MM/dd") + "',DischargePort='" + TxtExpLoadShort.Text + "',FinalDestinationCountry='" + DrpFinalDesCountry.SelectedItem.ToString() + "',OutVoyageNumber='" + OUTWARDVoyageNo.Text + "',OutVesselName='" + OUTWARDVessel.Text + "',OutConveyanceRefNo='" + OUTWARDConref.Text + "',OutTransportId='" + OUTWARDTransId.Text + "',OutFlightNO='" + OUTWARDFlightN0.Text + "',OutAircraftRegNo='" + OUTWARDAirREgno.Text + "',EntryYear='" + txtentry.Text + "',[NumberOfItems]='" + txtnoofitm.Text + "',InternalRemarks='" + txtinternal.Text + "',TradeRemarks='" + txttrdremrk.Text + "',TouchUser='" + Touch_user + "',TouchTime=Convert(VARCHAR,'" + strTime + "',108) where Id='" + Id + "'");
                obj.exec(StrQuery);
            }
            else
            {
                string AddCerDtl = AddCerDtl1.Text + '-' + AddCerDtl2.Text + '-' + AddCerDtl3.Text + '-' + AddCerDtl4.Text + '-' + AddCerDtl5.Text;
                string TransportDetails = TransDtl1.Text + '-' + TransDtl2.Text + '-' + TransDtl3.Text + '-' + TransDtl4.Text + '-' + TransDtl5.Text;
                string aditionalreceipt = TxtRECPT1.Text + '-' + TxtRECPT2.Text + '-' + TxtRECPT3.Text;
                string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string StrQuery = ("Update COHeaderTbl set Refid='" + refno + "',GrossReference='" + TxtGrossReference.Text + "',  TradeNetMailboxID='" + TxtTradeMailID.Text + "',Additionalrecieptant='" + aditionalreceipt + "',Gpsdonorcountry='" + Drpgpsdonorcountry.SelectedItem.ToString() + "',Percomwealth='" + txtper.Text + "',MessageType='" + TxtMsgType.Text + "',ApplicationType='" + TxtAppType.Text + "',PreviousPermitNo='" + TxtPrevPerNO.Text + "', OutwardTransportMode='" + DrpOutwardtrasMode.SelectedItem.ToString() + "',ReferenceDocuments='" + ChkRefDoc.Checked.ToString() + "',[COType] = '" + DrpCoType.SelectedItem.ToString() + "',[CerDtlType1] ='" + DrpCerDtl1.SelectedItem.ToString() + "' ,[CerDtlCopy1] = '" + TxtCerDtl1.Text + "' ,[CerDtlType2] ='" + DrpCerDtl2.SelectedItem.ToString() + "'  ,[CerDtlCopy2] ='" + TxtCerDtl2.Text + "' ,[CurrencyCode] ='" + DrpCurrencyCode.SelectedItem.ToString() + "' ,[AdditionalCer] = '" + AddCerDtl + "' ,[TransportDtl] = '" + TransportDetails + "',DeclarantCompanyCode='" + TxtDecCompCode.Text + "',ExporterCompanyCode='" + TxtExpCode.Text + "',OutwardCarrierAgentCode='" + OutwardCode.Text + "',FreightForwarderCode='" + FrieghtCode.Text + "',CONSIGNEECode='" + ConsigneeCode.Text + "',Manufacturer='" + ManufacturerCode.Text + "',DepartureDate='" + Convert.ToDateTime(DepatureDate).ToString("yyyy/MM/dd") + "',DischargePort='" + TxtExpLoadShort.Text + "',FinalDestinationCountry='" + DrpFinalDesCountry.SelectedItem.ToString() + "',OutVoyageNumber='" + OUTWARDVoyageNo.Text + "',OutVesselName='" + OUTWARDVessel.Text + "',OutConveyanceRefNo='" + OUTWARDConref.Text + "',OutTransportId='" + OUTWARDTransId.Text + "',OutFlightNO='" + OUTWARDFlightN0.Text + "',OutAircraftRegNo='" + OUTWARDAirREgno.Text + "',EntryYear='" + txtentry.Text + "',[NumberOfItems]='" + txtnoofitm.Text + "',InternalRemarks='" + txtinternal.Text + "',TradeRemarks='" + txttrdremrk.Text + "',TouchUser='" + Touch_user + "',TouchTime=Convert(VARCHAR,'" + strTime + "',108) where Id='" + Id + "'");
                obj.exec(StrQuery);
            }

           

            //string StrdeleteQuery = ("delete from TranshipmentContainerDtl where PermitId='" + txt_code.Text + "'");
            //obj.exec(StrdeleteQuery);
            //obj.closecon();
            //int i = 0;
            //foreach (GridViewRow g1 in ContarinerGrid.Rows)
            //{
            //    string ContainerNo = (g1.FindControl("txt1") as TextBox).Text;
            //    string ContainerSize = (g1.FindControl("DrpType") as DropDownList).SelectedItem.ToString();
            //    string ContainerWeight = (g1.FindControl("txt2") as TextBox).Text;
            //    string Containerseal = (g1.FindControl("txt3") as TextBox).Text;

            //    if (ContainerNo != "" && ContainerSize != "" && ContainerWeight != "" && Containerseal != null)
            //    {
            //        string StrQuery1 = ("INSERT INTO [dbo].[TranshipmentContainerDtl] ([PermitId],[RowNo],[ContainerNo],[Size],[Weight],[SealNo],[MessageType],[TouchUser],[TouchTime]) VALUES ('" + txt_code.Text + "','" + i + "','" + ContainerNo + "','" + ContainerSize + "','" + ContainerWeight + "','" + Containerseal + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "')");
            //        obj.exec(StrQuery1);
            //        obj.closecon();
            //    }
            //    i++;
            //}

            //CPC
            //string cpc = ("delete from TranshipmentCPCDtl where PermitId='" + txt_code.Text + "' and CPCType='AEO'");
            //obj.exec(cpc);
            //obj.closecon();
            //int j = 0;
            //foreach (GridViewRow g1 in AEOGrid.Rows)
            //{
            //    string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;

            //    string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
            //    string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;


            //    if (ProcessingCode1 != "" && ProcessingCode2 != "" && ProcessingCode3 != "")
            //    {
            //        string StrQuery1 = ("INSERT INTO [dbo].[TranshipmentCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + j + "','AEO','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
            //        obj.exec(StrQuery1);
            //        obj.closecon();
            //    }
            //    j++;
            //}
            //string cec = ("delete from TranshipmentCPCDtl where PermitId='" + txt_code.Text + "' and CPCType='CWC'");
            //obj.exec(cec);
            //obj.closecon();
            //int K = 0;

            //foreach (GridViewRow g1 in CWCGrid.Rows)
            //{
            //    string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;

            //    string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
            //    string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

            //    if (ProcessingCode1 != "" && ProcessingCode2 != "" && ProcessingCode3 != "")
            //    {
            //        string StrQuery1 = ("INSERT INTO [dbo].[TranshipmentCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + K + "','CWC','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
            //        obj.exec(StrQuery1);
            //        obj.closecon();
            //    }
            //    K++;
            //}

            Response.Redirect("CoList.aspx");
        }



        protected void BtnSaveDraft_Click(object sender, EventArgs e)
        {

            Id = Convert.ToInt16(Session["Id"].ToString());
            if (Id != 0)
            {
                Editdata();
                Itemclear();
                Session["Edit"] = false;
                // eid = 0;
            }
            else
            {


                string Code = "";
                string qry11 = "SELECT PermitId FROM COHeaderTbl where PermitId='" + txt_code.Text + "' and MessageType='COODEC'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    Code = obj.dr[0].ToString();
                }
                if (Code == "")
                {
                    string Touch_user = Session["UserId"].ToString();

                    DateTime DepatureDate = Convert.ToDateTime(null);
                    if (TxtExpArrivalDate1.Text == "")
                    {
                        var date = DateTime.Now.ToString();
                        var manDate = DateTime.ParseExact(date, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        DepatureDate = Convert.ToDateTime(manDate);
                    }
                    else
                    {
                        var InvoiceDate1 = DateTime.ParseExact(TxtExpArrivalDate1.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        DepatureDate = Convert.ToDateTime(InvoiceDate1);
                    }


                   // var DepatureDate = DateTime.Parse(this.TxtExpArrivalDate1.Text, new CultureInfo("en-US", true));
                    JobNO();
                    MSGNO();
                    refid();
                    string AddCerDtl = AddCerDtl1.Text + '-' + AddCerDtl2.Text + '-' + AddCerDtl3.Text + '-' + AddCerDtl4.Text + '-' + AddCerDtl5.Text;
                    string TransportDetails = TransDtl1.Text + '-' + TransDtl2.Text + '-' + TransDtl3.Text + '-' + TransDtl4.Text + '-' + TransDtl5.Text;
                    int chkCode = 0;
                
                    Save:
                    string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string StrQuery = ("INSERT INTO [dbo].[COHeaderTbl] ([Refid],[JobId],[MSGId],[PermitId],[TradeNetMailboxID],[MessageType],[ApplicationType],[PreviousPermitNo],[OutwardTransportMode],[ReferenceDocuments],[COType],[CerDtlType1],[CerDtlCopy1],[CerDtlType2],[CerDtlCopy2],[CurrencyCode],[AdditionalCer],[TransportDtl],[DeclarantCompanyCode],[ExporterCompanyCode],[OutwardCarrierAgentCode],[FreightForwarderCode],[CONSIGNEECode],[Manufacturer],[DepartureDate],[DischargePort],[FinalDestinationCountry],[OutVoyageNumber],[OutVesselName],[OutConveyanceRefNo],[OutTransportId],[OutFlightNO],[OutAircraftRegNo],[DeclareIndicator],[NumberOfItems],[InternalRemarks],[TradeRemarks],[Status],[TouchUser],[TouchTime]) VALUES ('" + refno + "', '" + JobNo + "','" + MsgNO + "','" + txt_code.Text + "','" + TxtTradeMailID.Text + "','" + TxtMsgType.Text + "','" + TxtAppType.Text + "','" + TxtPrevPerNO.Text + "','" + DrpOutwardtrasMode.SelectedItem + "','" + ChkRefDoc.Checked.ToString() + "','" + DrpCoType.SelectedItem + "','" + DrpCerDtl1.SelectedItem + "','" + TxtCerDtl1.Text + "','" + DrpCerDtl2.SelectedItem + "','" + TxtCerDtl2.Text + "','" + DrpCurrencyCode.SelectedItem + "','" + AddCerDtl + "','" + TransportDetails + "', '" + TxtDecCompCode.Text + "','" + TxtExpCode.Text + "','" + OutwardCode.Text + "','" + FrieghtCode.Text + "','" + ConsigneeCode.Text + "','" + ManufacturerCode.Text + "','" + Convert.ToDateTime(DepatureDate).ToString("yyyy/MM/dd") + "','" + TxtExpLoadShort.Text + "','" + DrpFinalDesCountry.SelectedItem + "','" + OUTWARDVoyageNo.Text + "','" + OUTWARDVessel.Text + "','" + OUTWARDConref.Text + "','" + OUTWARDTransId.Text + "','" + OUTWARDFlightN0.Text + "','" + OUTWARDAirREgno.Text + "','" + chkalrt.Checked.ToString() + "','" + txtnoofitm.Text + "','" + txtinternal.Text + "','" + txttrdremrk.Text + "','DRF','" + Touch_user + "',Convert(VARCHAR,'" + strTime + "',108)) ");
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


                    Response.Redirect("CoList.aspx");

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Permit Code '" + txt_code.Text + "' Already Exist..');", true);
                    //  Response.Write("The Importer Code Already Exist..");
                }
                Itemclear();
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

        

       

        protected void TxtDescription_TextChanged(object sender, EventArgs e)
        {

            LblCount.Text = "character count: " + TxtDescription.Text.Length.ToString();
        }

        protected void DrpInvoiceNo_SelectedIndexChanged(object sender, EventArgs e)
        {
           

            //string Code,Code1 = "";
            //string qry11 = "select TICurrency from [InNonInvoiceDtl] where MessageType='COODEC' AND PermitId='" + txt_code.Text + "'  order by TICurrency";
            //obj.dr = obj.ret_dr(qry11);
            //while (obj.dr.Read())
            //{
            //    Code = obj.dr[0].ToString();
            //    if (Code != "--Select--")
            //    {
            //        DRPCurrency.SelectedValue = Code;

            //        string qry111 = "select CurrencyRate from dbo.Currency where Currency='" + Code + "'";
            //        obj.dr = obj.ret_dr(qry111);
            //        while (obj.dr.Read())
            //        {
            //            Code1= obj.dr[0].ToString();
            //            TxtExchangeRate.Text = Code1;
            //        }

            //    }            
               
                
            //}

        }

        protected void DRPCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {

           // string Code1 = "";
                    string qry111 = "select CurrencyRate from dbo.Currency where Currency='" + DRPCurrency.SelectedItem + "'";
                    obj.dr = obj.ret_dr(qry111);
                    while (obj.dr.Read())
                    {
                        TxtExchangeRate.Text = obj.dr[0].ToString();
                       // TxtExchangeRate.Text = Code1;
                    }

                    TxtTotalLineAmount.Focus();

        }

        protected void TxtTotalLineAmount_TextChanged(object sender, EventArgs e)
        {

            if (TxtTotalLineAmount.Text != "")
            {

                double T1, T2 ;
                bool A = double.TryParse(TxtTotalLineAmount.Text.Trim(), out T1);
                bool B = double.TryParse(TxtExchangeRate.Text.Trim(), out T2);
               
                //if (A && B )
                //    //TxtTotalLineCharges.Text = (T1 * T2 ).ToString();
            }
            else
            {
                TxtTotalLineAmount.Text = "0.00";
            }

             if (TxtTotalLineAmount.Text != "")
            {

                double T1, T2 ;
                bool A = double.TryParse(TxtTotalLineAmount.Text.Trim(), out T1);
                bool B = double.TryParse(TxtExchangeRate.Text.Trim(), out T2);
                //bool C = double.TryParse(TxtTotalLineCharges.Text.Trim(), out T3);
               
                if (A && B  )
                    TxtCIFFOB.Text = (T1 * T2 ).ToString();
               
                



            }
            else
            {
                TxtTotalLineAmount.Text = "0.00";
            }
             //Sum of Item Amount

             string SumofItemAmount = "";
             string qry11s2Q = "select SUM(TotalLineAmount) as  TotalLineAmount  from dbo.COItemDtl where PermitId='" + txt_code.Text + "' and MessageType='COODEC'";
             obj.dr = obj.ret_dr(qry11s2Q);
             while (obj.dr.Read())
             {
                 SumofItemAmount = obj.dr[0].ToString();
                 txtitmAmt.Text = SumofItemAmount;
             }
             lblinvoiceAmt.Text = SumofItemAmount;
            
        }

        protected void TxtUnitPrice_TextChanged(object sender, EventArgs e)
        {
            if (TxtUnitPrice.Text != "")
            {

                double T1, T2, T3, T5;
                bool A = double.TryParse(TxtUnitPrice.Text.Trim(), out T1);
                bool B = double.TryParse(TxtExchangeRate.Text.Trim(), out T2);
                bool C = double.TryParse(TxtTotalLineAmount.Text.Trim(), out T3);               
                //bool D = double.TryParse(TxtTotalLineCharges.Text.Trim(), out T4);
                bool E = double.TryParse(TxtHSQuantity.Text.Trim(), out T5);
                
                if (A && B)
                    TxtSumExRate.Text = (T1 * T2 ).ToString();
                TxtTotalLineAmount.Text = (T5 * T1).ToString();
                string lineamt = (T5 * T1).ToString();
               
                //TxtTotalLineCharges.Text = (Convert.ToDouble(lineamt) * T2 / 100).ToString();
                string linecharge = (Convert.ToDouble(lineamt) * T2 / 100).ToString();
                TxtCIFFOB.Text = ((Convert.ToDouble(lineamt) * T2 + Convert.ToDouble(linecharge)).ToString());
                string GSTG = TxtCIFFOB.Text;
             
            }
            else
            {
                TxtUnitPrice.Text = "0.00";
            }
            //Sum of Item Amount

            string SumofItemAmount = "";
            string qry11s2Q = "select SUM(TotalLineAmount) as  TotalLineAmount  from dbo.COItemDtl where PermitId='" + txt_code.Text + "' and MessageType='COODEC'";
            obj.dr = obj.ret_dr(qry11s2Q);
            while (obj.dr.Read())
            {
                SumofItemAmount = obj.dr[0].ToString();
                txtitmAmt.Text = SumofItemAmount;
            }
            lblinvoiceAmt.Text = SumofItemAmount;
        }

        protected void ChkUnitPrice_CheckedChanged(object sender, EventArgs e)
        {
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
            int result;
            //getting Connectin String from Web.Config
            string conString = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM COItemDtl where ID=" + employeeId, con);
                result = cmd.ExecuteNonQuery();

                string var = "DECLARE @SRNO bigint=0;" + Environment.NewLine;
                var = var + " UPDATE COItemDtl SET @SRNO =ItemNo= @SRNO + 1 where PermitId='" + txt_code.Text + "'";

                cmd = new SqlCommand(var, con);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("DELETE FROM COCasctbl where PermitId='" + txt_code.Text + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
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
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM COItemDtl where PermitId='" + txt_code.Text + "' and MessageType='COODEC' order by Id"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
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
        private void summerycalculate()
        {
            string SumItem = "";
            string qry11 = "select Count(ItemNo) as InvCount from dbo.COItemDtl where PermitId='" + txt_code.Text + "' and MessageType='COODEC'";
            obj.dr = obj.ret_dr(qry11);
            while (obj.dr.Read())
            {
                SumItem = obj.dr[0].ToString();
                txtnoofitm.Text = SumItem;
            }

            //Sum of Item Amount

            string SumofItemAmount = "";
            string qry11s2Q = "select SUM(TotalLineAmount) as  TotalLineAmount  from dbo.COItemDtl where PermitId='" + txt_code.Text + "' and MessageType='COODEC'";
            obj.dr = obj.ret_dr(qry11s2Q);
            while (obj.dr.Read())
            {
                SumofItemAmount = obj.dr[0].ToString();
                txtitmAmt.Text = SumofItemAmount;
            }




            lblinvoiceAmt.Text = SumofItemAmount;


            //string SumofItemAmountcert = "";
            //string qry11s2Q1 = "select SUM(ItemValue) as  ItemValue  from dbo.COItemDtl where PermitId='" + txt_code.Text + "' and MessageType='COODEC'";
            //obj.dr = obj.ret_dr(qry11s2Q1);
            //while (obj.dr.Read())
            //{
            //    SumofItemAmountcert = obj.dr[0].ToString();
            //    txtitmAmt.Text = SumofItemAmount;
            //}

           // txtitemvaluecert.Text = SumofItemAmountcert;


        }
        protected void BtnItemAdd_Click(object sender, EventArgs e)
        {

            string itemcnt = "";
            int count = 0;

            string itemcnt1 = "SELECT COUNT(*) as count FROM COItemDtl where  MessageType='COODEC' AND PermitId='" + txt_code.Text + "'";
            obj.dr = obj.ret_dr(itemcnt1);
            while (obj.dr.Read())
            {
                itemcnt = obj.dr["count"].ToString();
                count = Convert.ToInt32(itemcnt);
            }



            if (count < 50)
            {

                lblitemalert.Visible = false;
                string Code = "";
                string qry1111 = "SELECT * FROM COItemDtl where  MessageType='COODEC' AND PermitId='" + txt_code.Text + "' and ItemNo='" + TxtSerialNo.Text + "'";
                obj.dr = obj.ret_dr(qry1111);
                while (obj.dr.Read())
                {
                    Code = obj.dr[1].ToString();
                }


                if (Code == "")
                {


                    string Touch_user = Session["UserId"].ToString();
                    string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    // var InvoiceDate = DateTime.Parse(this.txtinvDate.Value, new CultureInfo("en-US", true));
                    DateTime ManuDate = Convert.ToDateTime(null);
                    if (TxtManuDate.Text == "")
                    {
                        var date = DateTime.Now.ToString("dd/MM/yyyy");
                        var manDate = DateTime.ParseExact(date, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        ManuDate = Convert.ToDateTime(manDate);
                    }
                    else
                    {
                        var InvoiceDate1 = DateTime.ParseExact(TxtManuDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        ManuDate = Convert.ToDateTime(InvoiceDate1);
                    }

                    DateTime InvDate = Convert.ToDateTime(null);
                    if (TxtInvDate.Text == "")
                    {
                        var date = DateTime.Now.ToString("dd/MM/yyyy");
                        var manDate = DateTime.ParseExact(date, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        InvDate = Convert.ToDateTime(manDate);
                    }
                    else
                    {
                        var InvoiceDate1 = DateTime.ParseExact(TxtInvDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        InvDate = Convert.ToDateTime(InvoiceDate1);
                    }


                    if (TxtTextileQty.Text == "")
                    {
                        TxtTextileQty.Text = "0.00";
                    }
                    if (TxtSumExRate.Text == "")
                    {
                        TxtSumExRate.Text = "0.00";
                    }
                    string StrQuery1 = ("INSERT INTO [dbo].[COItemDtl] ([ItemNo],[PermitId],[MessageType],[HSCode],[Description],[Contry],[UnitPrice],[UnitPriceCurrency],[ExchangeRate],[SumExchangeRate],[TotalLineAmount],[CIFFOB],[InvoiceQty],[HSQTY],[HSUOM],[ShippingMark],[CerItemQty],[CerItemUOM],[ManfCostDate],[TextileCat],[TextileQuotaQty],[TextileQuotaQtyUOM],[ItemValue],[InvoiceNumber],[InvoiceDate],[HSOnCer],[OriginCriterion],[PerOrgainCRI],[CertificateDes],[Touch_user],[TouchTime],[Hawblno]) VALUES ('" + TxtSerialNo.Text + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + TxtHSCodeItem.Text + "','" + TxtDescription.Text + "','" + TxtCountryItem.Text + "','" + TxtUnitPrice.Text + "','" + DRPCurrency.SelectedItem.ToString() + "','" + TxtExchangeRate.Text + "','" + TxtSumExRate.Text + "','" + Convert.ToDecimal(TxtTotalLineAmount.Text).ToString() + "','" + Convert.ToDecimal(TxtCIFFOB.Text) + "','" + TxtInvQTY2.Text + "','" + TxtHSQty.Text + "','" + drpInvoiceUOM.SelectedItem.ToString() + "','" + txtShippingMarks1.Text + "','" + TxtCerITEMQty.Text + "','" + DrpCerITemUOM.SelectedItem.ToString() + "','" + Convert.ToDateTime(ManuDate).ToString("yyyy/MM/dd") + "','" + TxtTextileCat.Text + "','" + TxtTextileQty.Text + "','" + DrpTextQoutoQTYUOM.SelectedItem.ToString() + "','" + txtcifitemvalue.Text + "','" + txtinvno.Text + "','" + Convert.ToDateTime(InvDate).ToString("yyyy/MM/dd") + "','" + TxtHSCodeCer.Text + "','" + txtcreteriencode.Text + "," + txtcodesc1.Text + "," + txtcodesc2.Text + "," + txtcodesc3.Text + "','" + TxtPerOrgCir.Text + "','" + TxtCerDes.Text + "','" + Touch_user + "',Convert(VARCHAR,'" + strTime + "',108),'" + txthawbl.Text.ToUpper() + "')");
                    obj.exec(StrQuery1);
                    obj.closecon();


                    BindItemMaster();

                    summerycalculate();




                    ItemAddGrid.Visible = true;
                    ItemDiv.Visible = true;
                    BtnAddNEWItem.Visible = false;
                    Itemclear();
                }
                else
                {

                    string Touch_user = Session["UserId"].ToString();
                    string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    //   var InvoiceDate = DateTime.Parse(this.txtinvDate.Value, new CultureInfo("en-US", true));
                    //string AddCerDtl = TxtACerDtl1.Text + '-' + TxtACerDtl2.Text + '-' + TxtACerDtl3.Text + '-' + TxtACerDtl4.Text + '-' + TxtACerDtl5.Text;
                    //string TransportDetails = TxtTrnDtl1.Text + '-' + TxtTrnDtl2.Text + '-' + TxtTrnDtl3.Text + '-' + TxtTrnDtl4.Text + '-' + TxtTrnDtl5.Text;
                    DateTime ManuDate = Convert.ToDateTime(null);
                    if (TxtManuDate.Text == "")
                    {
                        var date = DateTime.Now.ToString("dd/MM/yyyy");
                        var manDate = DateTime.ParseExact(date, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        ManuDate = Convert.ToDateTime(manDate);
                    }
                    else
                    {
                        var InvoiceDate1 = DateTime.ParseExact(TxtManuDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        ManuDate = Convert.ToDateTime(InvoiceDate1);
                    }

                    DateTime InvDate = Convert.ToDateTime(null);
                    if (TxtInvDate.Text == "")
                    {
                        var date = DateTime.Now.ToString();
                        var manDate = DateTime.ParseExact(date, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        InvDate = Convert.ToDateTime(manDate);
                    }
                    else
                    {
                        var InvoiceDate1 = DateTime.ParseExact(TxtInvDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        InvDate = Convert.ToDateTime(InvoiceDate1);
                    }


                    if (TxtTextileQty.Text == "")
                    {
                        TxtTextileQty.Text = "0.00";
                    }

                    string StrQuery1 = ("UPDATE [dbo].[COItemDtl] SET  [ItemNo] = '" + TxtSerialNo.Text + "',OriginCriterion='" + txtcreteriencode.Text + "," + txtcodesc1.Text + "," + txtcodesc2.Text + "," + txtcodesc3.Text + "',InvoiceNumber='" + txtinvno.Text + "',[PermitId] = '" + txt_code.Text + "',[MessageType] = '" + TxtMsgType.Text + "',[HSCode] ='" + TxtHSCodeItem.Text + "',[Description] = '" + TxtDescription.Text + "',[Contry] = '" + TxtCountryItem.Text + "',[UnitPrice] = '" + TxtUnitPrice.Text + "',[UnitPriceCurrency] = '" + DRPCurrency.SelectedItem.ToString() + "',[ExchangeRate] = '" + TxtExchangeRate.Text + "',[SumExchangeRate] = '" + TxtSumExRate.Text + "',[TotalLineAmount] ='" + TxtTotalLineAmount.Text + "',[CIFFOB] = '" + TxtCIFFOB.Text + "',[InvoiceQty] = '" + TxtInvQTY2.Text + "',[HSQTY] = '" + TxtHSQty.Text + "',[HSUOM] = '" + drpInvoiceUOM.SelectedItem.ToString() + "',[ShippingMark] = '" + txtShippingMarks1.Text + "',[CerItemQty] = '" + TxtCerITEMQty.Text + "',[CerItemUOM] = '" + DrpCerITemUOM.SelectedItem.ToString() + "',[ManfCostDate] = '" + Convert.ToDateTime(ManuDate).ToString("yyyy/MM/dd") + "',[TextileCat] = '" + TxtTextileCat.Text + "',[TextileQuotaQty] = '" + TxtTextileQty.Text + "',[TextileQuotaQtyUOM] = '" + DrpTextQoutoQTYUOM.SelectedItem.ToString() + "',[ItemValue]='" + txtcifitemvalue.Text + "',[InvoiceDate] = '" + Convert.ToDateTime(InvDate).ToString("yyyy/MM/dd") + "',[HSOnCer] = '" + TxtHSCodeCer.Text + "',[PerOrgainCRI] = '" + TxtPerOrgCir.Text + "',[CertificateDes] = '" + TxtCerDes.Text + "',[Touch_user] = '" + Touch_user + "',[TouchTime]=Convert(VARCHAR,'" + strTime + "',108),Hawblno='" + txthawbl.Text.ToUpper() + "'  WHERE  MessageType='COODEC' AND PermitId='" + txt_code.Text + "' and ItemNo='" + TxtSerialNo.Text + "' ");
                    obj.exec(StrQuery1);
                    obj.closecon();


                    BindItemMaster();

                    string SumItem = "";
                    string qry11 = "select Count(ItemNo) as InvCount from dbo.COItemDtl where PermitId='" + txt_code.Text + "' and MessageType='COODEC'";
                    obj.dr = obj.ret_dr(qry11);
                    while (obj.dr.Read())
                    {
                        SumItem = obj.dr[0].ToString();
                        txtnoofitm.Text = SumItem;
                    }

                    //Sum of Item Amount

                    string SumofItemAmount = "";
                    string qry11s2Q = "select SUM(TotalLineAmount) as  TotalLineAmount  from dbo.COItemDtl where PermitId='" + txt_code.Text + "' and MessageType='COODEC'";
                    obj.dr = obj.ret_dr(qry11s2Q);
                    while (obj.dr.Read())
                    {
                        SumofItemAmount = obj.dr[0].ToString();
                        txtitmAmt.Text = SumofItemAmount;
                    }
                    lblinvoiceAmt.Text = SumofItemAmount;




                    ItemAddGrid.Visible = true;
                    ItemDiv.Visible = true;
                    BtnAddNEWItem.Visible = false;

                    Itemclear();
                }
            }
            else
            {
                lblitemalert.Visible = true;
                lblitemalert.Text = "Maximum Number of Items are Not Exceed 50";
            }
        }

        protected void AddItemGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            AddItemGrid.PageIndex = e.NewPageIndex;
            BindItemMaster();
        }

       

      

      

        protected void DrpOutwardtrasMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DrpOutwardtrasMode.SelectedValue != "")
            {

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
                    if (TxtExpMode.Text == "1 : Sea")
                    {
                        outtr.Visible = true;
                        OUTWARDSea.Visible = true;
                        OUTWARDVesl.Visible = false;
                        ContainerDetails.Visible = false;
                    }
                    else if (TxtExpMode.Text == "2 : Rail" || TxtExpMode.Text == "3 : Road" || TxtExpMode.Text == "5 : Mail" || TxtExpMode.Text == "7 : Pipeline" ||  TxtExpMode.Text == "6 : Multi-model(Not in use)")
                    {
                        OUTWARDOther.Visible = true;
                        outtr.Visible = true;
                        //ContainerDetails.Visible = false;
                    }

                    else if (TxtExpMode.Text == "N : Not Required")
                    {
                        outtr.Visible = false;
                    }
                    else if (TxtExpMode.Text == "4 : Air")
                    {
                        outtr.Visible = true;
                        OUTWARDFlight.Visible = true;
                        //ContainerDetails.Visible = false;
                    }
                    lblTotItemGst.Text = DrpOutwardtrasMode.SelectedItem.ToString();


                    //if (DrpOutwardtrasMode.SelectedItem.ToString() != "--Select--")
                    //{
                    //    string TransMode1 = DrpOutwardtrasMode.SelectedItem.ToString();
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
                    //    else if (TextMode.Text == "2 : Rail" || TextMode.Text == "5 : Mail" || TextMode.Text == "7 : Pipeline" || TextMode.Text == "N : Not Required" || TextMode.Text == "6 : Multi-model(Not in use)")
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
            }
           
            ChkRefDoc .Focus();
            cocargo.Update();
            coparty.Update();
            coitem.Update();
        }
        private void BindOutward()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id,Code,Name,Name1,CRUEI FROM [COOutwardCarrierAgent]"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
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
            _objdt = GetOutwardDataFromDataBase(OutwardSearch.Text);
            if (_objdt.Rows.Count > 0)
            {
                OutwardGrid.DataSource = _objdt;
                OutwardGrid.DataBind();
               // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Outward1();", true);
            }
        }

        protected void OutwardGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            OutwardGrid.PageIndex = e.NewPageIndex;
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Outward1();", true);
            BindOutward();
            popupcoout.Show();
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
            string Code = "";
            string qry11 = "SELECT Code FROM [COOutwardCarrierAgent] where Code='" + OutwardCode.Text + "'";

            obj.dr = obj.ret_dr(qry11);

            while (obj.dr.Read())
            {
                Code = obj.dr[0].ToString();

            }
            if (Code == "")
            {
                string Touch_user = Session["UserId"].ToString();

                string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string StrQuery = ("INSERT INTO [dbo].[COOutwardCarrierAgent] ([Code],[Name],[Name1],[CRUEI],[TouchUser],[TouchTime]) VALUES ('" + OutwardCode.Text + "','" + OutwardName.Text + "','" + OutwardName1.Text + "','" + OutwardCRUEI.Text + "','" + Touch_user + "',Convert(VARCHAR,'" + strTime + "',108))");
                obj.exec(StrQuery);
                BindOutward();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Outward Code Already Exist...');", true);
                //Response.Write("The Inward Code Already Exist..");
            }
        }
        public DataTable GetOutwardDataFromDataBase(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = OutwardSearch.Text;

            string str3 = "SELECT Id,Code,Name,Name1,CRUEI FROM [COOutwardCarrierAgent] where Code Like '%" + OutwardSearch.Text + "%' order by Id desc";
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
            //string[] ss = OutwardCode.Text.Split(':');
            if (OutwardCode.Text != "")
            {
                string[] ss = OutwardCode.Text.Split(':');
                string qry11 = "select * from [COOutwardCarrierAgent] where Code='" + ss[0].ToString() + "'";
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
                using (SqlCommand cmd = new SqlCommand("SELECT Id,Code,Name,Name1,CRUEI FROM COExporter"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
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
            _objdt = GetExportDataFromDataBase(ExporterSearch.Text);
            if (_objdt.Rows.Count > 0)
            {
                ExporterGrid.DataSource = _objdt;
                ExporterGrid.DataBind();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "EXPORTER();", true);
            }
        }

        protected void ExporterGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ExporterGrid.PageIndex = e.NewPageIndex;
           // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "EXPORTER();", true);

            BindExporter();
            popupcoexp.Show();
            popupcoexp.X = 300;
            popupcoexp.Y = 100;
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
            string Code = "";
            string qry11 = "SELECT Code FROM [COExporter] where Code='" + TxtExpCode.Text + "'";

            obj.dr = obj.ret_dr(qry11);

            while (obj.dr.Read())
            {
                Code = obj.dr[0].ToString();

            }
            if (Code == "")
            {
                string Touch_user = Session["UserId"].ToString();

                string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string StrQuery = ("INSERT INTO [dbo].[COExporter] ([Code],[Name],[Name1],[CRUEI],[Address],[Address1],[Address2],[TouchUser],[TouchTime]) VALUES ('" + TxtExpCode.Text + "','" + TxtExpName.Text + "','" + TxtExpName1.Text + "','" + TxtExpCRUEI.Text + "','"+txtadd1 .Text +"','"+txtadd2 .Text +"','"+txtadd3 .Text +"','" + Touch_user + "',Convert(VARCHAR,'" + strTime + "',108))");
                obj.exec(StrQuery);
                BindExporter();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The HandingAgent  Already Exist...');", true);
                //Response.Write("The Inward Code Already Exist..");
            }

        }
        public DataTable GetExportDataFromDataBase(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = ExporterSearch.Text;

            string str3 = "SELECT Id,Code,Name,Name1,CRUEI,Address,Address1,Address2 FROM [COExporter] where Code Like '%" + ExporterSearch.Text + "%' order by Id desc";
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
            string[] ss = TxtExpCode.Text.Split(':');
            if (TxtExpCode.Text != "")
            {

                string qry11 = "select * from [COExporter] where Code='" + ss[0].ToString() + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {


                    TxtExpCode.Text = obj.dr["Code"].ToString();
                    TxtExpName.Text = obj.dr["Name"].ToString();
                    TxtExpName1.Text = obj.dr["Name1"].ToString();
                    TxtExpCRUEI.Text = obj.dr["CRUEI"].ToString();
                    txtadd2.Text = obj.dr["Address1"].ToString();
                    txtadd1.Text = obj.dr["Address"].ToString();
                    txtadd3.Text = obj.dr["Address2"].ToString();
                    lblimporterparty.Text = obj.dr["Name"].ToString() + "  " + obj.dr["Name1"].ToString() + " - " + obj.dr["CRUEI"].ToString();
                }
            }
            else
            {
                TxtExpCode.Text = "";
                TxtExpName.Text = "";
                TxtExpName1.Text = "";
                TxtExpCRUEI.Text = "";
                txtadd2.Text = "";
                txtadd1.Text = "";
                txtadd3.Text = "";
            }
            InwardCode.Focus();
        }
        private void BindConsignee()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM COConsignee"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
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
            _objdt = GetConsigneeDataFromDataBase(ConsigneeSearch.Text);
            if (_objdt.Rows.Count > 0)
            {
                ConsigneeGrid.DataSource = _objdt;
                ConsigneeGrid.DataBind();
               // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Consignee();", true);
            }
        }

        protected void ConsigneeGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ConsigneeGrid.PageIndex = e.NewPageIndex;
          //  ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Consignee();", true);
            BindConsignee();
            popupcoconsignee.Show();
            popupcoconsignee.X = 300;
            popupcoconsignee.Y = 100;

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
                    ConsigneePostal.Text = ConsigneePostal12;
                    ConsigneeCountry.Text = ConsigneeCountry12;

                   
                

            }
        }

        protected void ConsigneeAdd_Click(object sender, EventArgs e)
        {
            string Code = "";
            string qry11 = "SELECT ConsigneeCode FROM COConsignee where ConsigneeCode='" + ConsigneeCode.Text + "'";
            obj.dr = obj.ret_dr(qry11);
            while (obj.dr.Read())
            {
                Code = obj.dr[0].ToString();
            }
            if (Code == "")            {
                string Touch_user = Session["UserId"].ToString();
                string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string StrQuery = ("INSERT INTO [dbo].[COConsignee] ([ConsigneeCode],[ConsigneeName],[ConsigneeName1],[ConsigneeCRUEI],[ConsigneeAddress],[ConsigneeAddress1],[ConsigneeCity],[ConsigneeSub],[ConsigneePostal],[ConsigneeCountry],[TouchUser],[TouchTime])  VALUES ('" + ConsigneeCode.Text + "','" + ConsigneeName.Text + "','" + ConsigneeName1.Text + "','" + ConsigneeCRUEI.Text + "','" + ConsigneeAddress.Text + "','" + ConsigneeAddress1.Text + "','" + ConsigneeCity.Text + "','" + ConsigneeSub.Text + "','" + ConsigneePostal.Text + "','" + ConsigneeCountry.Text + "','" + Touch_user + "',Convert(VARCHAR,'" + strTime + "',108))");
                obj.exec(StrQuery);
                BindConsignee();
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

            string str3 = "SELECT * FROM COConsignee where ConsigneeCode Like '%" + ConsigneeSearch.Text + "%' order by Id desc";
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
                string qry11 = "select * from COConsignee where ConsigneeCode='" + ss[0].ToString() + "'";
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
                    ConsigneePostal.Text = obj.dr[9].ToString();
                    ConsigneeCountry.Text = obj.dr[10].ToString();

                    //InwardCode.Text = obj.dr[1].ToString();
                    //InwardName.Text = obj.dr[2].ToString();
                    //InwardName1.Text = obj.dr[3].ToString();
                    //InwardCRUEI.Text = obj.dr[4].ToString();

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
                ConsigneePostal.Text = "";
                ConsigneeCountry.Text = "";
            }

        }
        private void BindExportPort()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM LoadingPort"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
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
            _objdt = GetPortDataFromDataBase(ExpLoadingSearch.Text);
            if (_objdt.Rows.Count > 0)
            {
                ExportGrid.DataSource = _objdt;
                ExportGrid.DataBind();
              //  ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Export();", true);
            }
        }

        protected void ExportGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ExportGrid.PageIndex = e.NewPageIndex;
           // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Export();", true);
            BindExportPort();
            popupcodischargeport.Show();
            popupcodischargeport.X = 300;
            popupcodischargeport.Y = 100;
        }

        protected void LnkExport_Command(object sender, CommandEventArgs e)
        {
            var lb = (LinkButton)sender;
            var row = (GridViewRow)lb.NamingContainer;
            if (row != null)
            {
                var lblCode1 = row.FindControl("lblCode") as Label;
                var lblName1 = row.FindControl("lblName") as Label;
               

                if (lblCode1 != null && lblName1 != null )
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
            string str3 = "SELECT * LoadingPort where PortCode Like '%" + ExpLoadingSearch.Text + "%' order by Id desc";
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
                string qry11 = "select * from LoadingPort where PortCode='" + ss[0].ToString() + "'";
                COClass objexp = new COClass();
                objexp.dr = objexp.ret_dr(qry11);
                while (objexp.dr.Read())
                {
                    TxtExpLoadShort.Text = objexp.dr["PortCode"].ToString();
                    TxtExpLoad.Text = objexp.dr["PortName"].ToString();
                }
            }
            DrpFinalDesCountry.Focus();
        }

        protected void ChkSea_CheckedChanged(object sender, EventArgs e)
        {
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
        }

        protected void btnSeaStr_Click(object sender, EventArgs e)
        {
            if (SeaGrid.Rows.Count <= 0)
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
                string qry11 = "select * from LoadingPort where PortCode='" + txtNextprt.Text + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    txtNextprt.Text = obj.dr[1].ToString();
                    txtNextprt.Text = obj.dr[2].ToString();
                }
            }
        }

        protected void txtLasPrt_TextChanged(object sender, EventArgs e)
        {
            if (txtLasPrt.Text != "")
            {
                string qry11 = "select * from LoadingPort where PortCode='" + txtLasPrt.Text + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    txtLasPrt.Text = obj.dr[1].ToString();
                    txtLasPrt.Text = obj.dr[2].ToString();

                }
            }
        }
        private void BindNextPort()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM LoadingPort"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
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
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM LoadingPort"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
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
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "NextPort();", true);
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "LastPort();", true);
            }
        }

        protected void LastGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LastGrid.PageIndex = e.NewPageIndex;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "LastPort();", true);
            BindLastPort();
        }
        public DataTable GetNextPortDataFromDataBase(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = NextPrtLoading.Text;

            string str3 = "SELECT * FROM LoadingPort where PortCode Like '%" + NextPrtLoading.Text + "%' order by Id desc";
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

            string str3 = "SELECT * FROM LoadingPort where PortCode Like '%" + txtlastprt.Text + "%' order by Id desc";
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "NextPort();", true);
            }
        }

       

        protected void ItemEdit_Click(object sender, ImageClickEventArgs e)
        {
            btnprev.Enabled = true;
            btnnxt.Enabled = true;


            GridViewRow grdrow = (GridViewRow)((ImageButton)sender).NamingContainer as GridViewRow;
            Label ID1 = (Label)grdrow.FindControl("lblID");
            string ID = ID1.Text;
         //   string SuplierCode, Importer = "";
            string strBindTxtBox = "select * from [COItemDtl] where Id=" + ID;
            obj.dr = obj.ret_dr(strBindTxtBox);
            while (obj.dr.Read())
            {
                itemno.Text = obj.dr["ItemNo"].ToString();
                TxtSerialNo.Text = obj.dr["ItemNo"].ToString();
                TxtHSCodeItem.Text = obj.dr["HSCode"].ToString();
                TxtDescription.Text = obj.dr["Description"].ToString();
                TxtCountryItem.Text = obj.dr["Contry"].ToString();
                TxtCountryItem_TextChanged(null, null);
                TxtUnitPrice.Text = obj.dr["UnitPrice"].ToString();
                DRPCurrency.ClearSelection();
                DRPCurrency.Items.FindByText(obj.dr["UnitPriceCurrency"].ToString()).Selected = true;
                TxtExchangeRate.Text = obj.dr["ExchangeRate"].ToString();
                TxtSumExRate.Text = obj.dr["SumExchangeRate"].ToString();
                TxtTotalLineAmount.Text = obj.dr["TotalLineAmount"].ToString();
                TxtCIFFOB.Text = obj.dr["CIFFOB"].ToString();

                TxtInvQTY2.Text = obj.dr["InvoiceQty"].ToString();
                TxtHSQty.Text = obj.dr["HSQTY"].ToString();

                drpInvoiceUOM.ClearSelection();
                drpInvoiceUOM.Items.FindByText(obj.dr["HSUOM"].ToString()).Selected = true;

                txtShippingMarks1.Text = obj.dr["ShippingMark"].ToString();
                TxtCerITEMQty.Text = obj.dr["CerItemQty"].ToString();
                DrpCerITemUOM.ClearSelection();
                DrpCerITemUOM.Items.FindByText(obj.dr["CerItemUOM"].ToString()).Selected = true;

                TxtManuDate.Text = Convert.ToDateTime(obj.dr["ManfCostDate"].ToString()).ToString("dd/MM/yyyy");
                TxtTextileCat.Text = obj.dr["TextileCat"].ToString();
                TxtTextileQty.Text = obj.dr["TextileQuotaQty"].ToString();
                DrpTextQoutoQTYUOM.ClearSelection();
                DrpTextQoutoQTYUOM.Items.FindByText(obj.dr["TextileQuotaQtyUOM"].ToString()).Selected = true;

                TxtInvDate.Text = Convert.ToDateTime(obj.dr["InvoiceDate"].ToString()).ToString("dd/MM/yyyy");
                TxtHSCodeCer.Text = obj.dr["HSOnCer"].ToString();

                TxtPerOrgCir.Text = obj.dr["PerOrgainCRI"].ToString();
                TxtCerDes.Text = obj.dr["CertificateDes"].ToString();
                txtcifitemvalue.Text = obj.dr["ItemValue"].ToString();
                txtinvno.Text = obj.dr["InvoiceNumber"].ToString();
                txtcreteriencode.Text = obj.dr["OriginCriterion"].ToString();
                TxtHSCodeCer.Text = obj.dr["HSOnCer"].ToString();
                txthawbl.Text = obj.dr["Hawblno"].ToString();
                TxtPerOrgCir.Text = obj.dr["PerOrgainCRI"].ToString();
             
                string[] orgncre= obj.dr["OriginCriterion"].ToString().Split(',');
                for (int i = 0; i < orgncre.Length; i++)
                {
                    if (i == 0)
                    {
                        txtcreteriencode.Text = orgncre[i].ToString();
                    }
                    if (i == 1)
                    {
                        txtcodesc1.Text = orgncre[i].ToString();
                    }
                    if (i == 2)
                    {
                        txtcodesc2.Text = orgncre[i].ToString();
                    }
                    if (i == 3)
                    {
                        txtcodesc3.Text = orgncre[i].ToString();
                    }
                }

                    ItemAddGrid.Visible = true;
                ItemDiv.Visible = true;
                BtnAddNEWItem.Visible = false;

            }
            //EditItem();
        }
       
        private void BindManufacturer()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM COManufacturer"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            ManufacturerGrid.DataSource = dt;
                            ManufacturerGrid.DataBind();
                        }
                    }
                }
            }
        }
        protected void ManufacturerSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable _objdt = new DataTable();
            _objdt = GetManufacturerDataFromDataBase(ManufacturerSearch.Text);
            if (_objdt.Rows.Count > 0)
            {
                ManufacturerGrid.DataSource = _objdt;
                ManufacturerGrid.DataBind();
             //   ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Manufacturer();", true);
            }
        }

        protected void ManufacturerGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ManufacturerGrid.PageIndex = e.NewPageIndex;
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Manufacturer();", true);
            BindManufacturer();
            popupcomanufacturer.Show();
            popupcomanufacturer.X = 300;
            popupcomanufacturer.Y = 100;
        }

        protected void LmkManufacturer_Command(object sender, CommandEventArgs e)
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
                string ConsigneePostal12 = ConsigneePostal1.Text;
                string ConsigneeCountry12 = ConsigneeCountry1.Text;


                ManufacturerCode.Text = "";
                ManufacturerName.Text = "";
                ManufacturerName1.Text = "";
                ManufacturerCRUEI.Text = "";
                ManufacturerAddress.Text = "";
                ManufacturerAddress1.Text = "";
                ManufacturerCity.Text = "";
                ManufacturerSubCode.Text = "";
                ManufacturerPostal.Text = "";
                ManufacturerCountry.Text = "";



                ManufacturerCode.Text = requestor;
                ManufacturerName.Text = requestType;
                ManufacturerName1.Text = status;
                ManufacturerCRUEI.Text = crueis;
                ManufacturerAddress.Text = ConsigneeAddress12;
                ManufacturerAddress1.Text = ConsigneeAddress112;
                ManufacturerCity.Text = ConsigneeCity12;
                ManufacturerSubCode.Text = ConsigneeSub12;
                ManufacturerPostal.Text = ConsigneePostal12;
                ManufacturerCountry.Text = ConsigneeCountry12;




            }
        }

        protected void ManufacturerAdd_Click(object sender, EventArgs e)
        {
            string Code = "";
            string qry11 = "SELECT ManufacturerCode FROM COManufacturer where ManufacturerCode='" + ManufacturerCode.Text + "'";
            obj.dr = obj.ret_dr(qry11);
            while (obj.dr.Read())
            {
                Code = obj.dr[0].ToString();
            }
            if (Code == "")
            {
                string Touch_user = Session["UserId"].ToString();
                string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string StrQuery = ("INSERT INTO [dbo].[COManufacturer] ([ManufacturerCode],[ManufacturerName],[ManufacturerName1],[ManufacturerCRUEI],[ManufacturerAddress],[ManufacturerAddress1],[ManufacturerCity],[ManufacturerSub],[ManufacturerSubDivi],[ManufacturerPostal],[ManufacturerCountry],[TouchUser],[TouchTime])  VALUES ('" + ManufacturerCode.Text + "','" + ManufacturerName.Text + "','" + ManufacturerName1.Text + "','" + ManufacturerCRUEI.Text + "','" + ManufacturerAddress.Text + "','" + ManufacturerAddress1.Text + "','" + ManufacturerCity.Text + "','" + ManufacturerSubCode.Text + "','" + ManufacturerSubDivi .Text + "','" + ManufacturerPostal.Text + "','" + ManufacturerCountry.Text + "','" + Touch_user + "',Convert(VARCHAR,'" + strTime + "',108))");
                obj.exec(StrQuery);
                BindManufacturer();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Manufacturer Code Already Exist...');", true);
                //Response.Write("The Inward Code Already Exist..");
            }
        }
        public DataTable GetManufacturerDataFromDataBase(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = ManufacturerSearch.Text;

            string str3 = "SELECT * FROM COManufacturer where ManufacturerCode Like '%" + ManufacturerSearch.Text + "%' order by Id desc";
            obj.dr = obj.ret_dr(str3);
            if (obj.dr.HasRows)
            {
                ManufacturerGrid.DataSource = obj.dr;

            }
            else
            {
                //Empty DataTable to execute the “else-condition”  
                DataTable dt = new DataTable();
                ManufacturerGrid.DataSource = dt;
                ManufacturerGrid.DataBind();
            }
            SqlConnection con = new SqlConnection(sqlconn);
            SqlDataAdapter _objda = new SqlDataAdapter(str3, con);
            con.Close();
            _objda.Fill(_objdt);
            return _objdt;
        }


        protected void ManufacturerCode_TextChanged(object sender, EventArgs e)
        {
            if (ManufacturerCode.Text != "")
            {
                string[] ss = ManufacturerCode.Text.Split(':');

                string qry11 = "select * from COManufacturer where ManufacturerCode='" + ss[0].ToString() + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {

                    ManufacturerCode.Text = obj.dr["ManufacturerCode"].ToString();
                    ManufacturerName.Text = obj.dr["ManufacturerName"].ToString();
                    ManufacturerName1.Text = obj.dr["ManufacturerName1"].ToString();
                    ManufacturerCRUEI.Text = obj.dr["ManufacturerCRUEI"].ToString();
                    ManufacturerAddress.Text = obj.dr["ManufacturerAddress"].ToString();
                    ManufacturerAddress1.Text = obj.dr["ManufacturerAddress1"].ToString();
                    ManufacturerCity.Text = obj.dr["ManufacturerCity"].ToString();
                    ManufacturerSubCode.Text = obj.dr["ManufacturerSub"].ToString();
                    ManufacturerSubDivi.Text = obj.dr["ManufacturerSubDivi"].ToString();
                    ManufacturerPostal.Text = obj.dr["ManufacturerPostal"].ToString();
                    ManufacturerCountry.Text = obj.dr["ManufacturerCountry"].ToString();

                    //InwardCode.Text = obj.dr[1].ToString();
                    //InwardName.Text = obj.dr[2].ToString();
                    //InwardName1.Text = obj.dr[3].ToString();
                    //InwardCRUEI.Text = obj.dr[4].ToString();

                }
            }
            else
            {

                ManufacturerCode.Text = "";
                ManufacturerName.Text = "";
                ManufacturerName1.Text = "";
                ManufacturerCRUEI.Text = "";
                ManufacturerAddress.Text = "";
                ManufacturerAddress1.Text = "";
                ManufacturerCity.Text = "";
                ManufacturerSubCode.Text = "";
                ManufacturerPostal.Text = "";
                ManufacturerCountry.Text = "";

            }
            btnpreviousparty.Focus();
        }
        private void BindStorage()
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
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            StorageGrid.DataSource = dt;
                            StorageGrid.DataBind();
                        }
                    }
                }
            }
        }
        protected void StorageSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable _objdt = new DataTable();
            _objdt = GetStorage(StorageSearch.Text);
            if (_objdt.Rows.Count > 0)
            {
                StorageGrid.DataSource = _objdt;
                StorageGrid.DataBind();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Storage();", true);
            }
        }
        public DataTable GetStorage(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = StorageSearch.Text;

            string str3 = "SELECT * FROM StorageLocation where StorageCode Like '%" + StorageSearch.Text + "%' order by Id desc";
            obj.dr = obj.ret_dr(str3);
            if (obj.dr.HasRows)
            {
                StorageGrid.DataSource = obj.dr;

            }
            else
            {
                //Empty DataTable to execute the “else-condition”  
                DataTable dt = new DataTable();
                StorageGrid.DataSource = dt;
                StorageGrid.DataBind();
            }
            SqlConnection con = new SqlConnection(sqlconn);
            SqlDataAdapter _objda = new SqlDataAdapter(str3, con);
            con.Close();
            _objda.Fill(_objdt);
            return _objdt;
        }
        protected void StorageGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            StorageGrid.PageIndex = e.NewPageIndex;
           // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Storage();", true);
            Bindreceipt();
        }

        protected void LnkStorage_Command(object sender, CommandEventArgs e)
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

                    TxtStorageShort.Text = "";
                    TxtStorageName.Text = "";

                    TxtStorageShort.Text = requestType;
                    TxtStorageName.Text = status;


                }

            }
        }

        protected void TxtStorageShort_TextChanged(object sender, EventArgs e)
        {
            if (TxtStorageShort.Text != "")
            {

                string qry11 = "select * from StorageLocation where StorageCode='" + TxtStorageShort.Text + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {


                    TxtStorageShort.Text = obj.dr[2].ToString();
                    TxtStorageName.Text = obj.dr[3].ToString();
                   
                }
            }
        }

        protected void AddItemSearch_TextChanged(object sender, EventArgs e)
        {

        }
        private void Itemclear()
        {
            TxtCountryItem.Text = "";
            txtcname.Text = "";
            txtcreteriencode.Text = "";
            txtcodesc1.Text = "";
            txtcodesc2.Text = "";
            txtcodesc3.Text = "";

            lblhserror.Text = "";
            TxtHSCodeItem.Text="";
            TxtDescription.Text ="";
            TxtCountryItem.Text="";
            TxtUnitPrice.Text="0.00";
            DRPCurrency.ClearSelection();
            DRPCurrency.Items.FindByText("--Select--");
            txtcifitemvalue.Text = "0.00";
            txtinvno.Text = "";
            TxtExchangeRate.Text="";
            TxtSumExRate.Text="0.00";
            TxtTotalLineAmount.Text="0.00";
            TxtCIFFOB.Text="0.00";
            TxtInvQTY2.Text ="0.00";
            TxtHSQty.Text="0.00";
            drpInvoiceUOM.ClearSelection();
            drpInvoiceUOM.Items.FindByText("--Select--");
            txthawbl.Text = "";
            txtShippingMarks1.Text="";
            TxtCerITEMQty.Text="0.00";
            DrpCerITemUOM.ClearSelection();
            DrpCerITemUOM.Items.FindByText("--Select--");
            
            TxtManuDate.Text="";
            TxtTextileCat.Text ="";
            TxtTextileQty.Text="0.00";
            DrpTextQoutoQTYUOM.ClearSelection();
            DrpTextQoutoQTYUOM.Items.FindByText("--Select--");
            txtcifitemvalue.Text = "0.00";

          
            //DrpP1.Items.FindByText("--Select--").ToString();
            //TxtProductCode2.Text = "";
           
           // txtEndUserDec1.Text = "";
          



            TxtInvDate.Text="";
            TxtHSCodeCer.Text="";
            TxtPerOrgCir.Text="";
            TxtCerDes.Text ="";
            ItemNO();
            

        }

        protected void GridCancelDoc_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridCancelDoc.DataKeys[e.RowIndex].Value.ToString();

            string strDelete = "delete from COFileUpload where Id='" + id + "' ";
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
                SqlCommand cmd = new SqlCommand("DELETE FROM COFileUpload where ID=" + employeeId, con);
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
            foreach (HttpPostedFile postedFile in FileUpload1.PostedFiles)
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
                            string DocType = DrpDocType.SelectedItem.ToString();
                            string strTime = System.DateTime.Now.ToString("yyyy/MM/dd");
                            string query = "insert into COFileUpload values (@Name, @ContentType, @Data,@DocumentType,@InPaymentId,@TouchUser,@TouchTime)";
                            using (SqlCommand cmd = new SqlCommand(query))
                            {

                                cmd.Connection = con;
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
            }
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
                    double a;
                    bool isAValid = double.TryParse(TxtInvQty.Text.Trim(), out a);

                    if (isAValid)
                        TxtHSQuantity.Text = (a / 10).ToString();

                }
                else if (UOm == "TPR")
                {
                    double a;
                    bool isAValid = double.TryParse(TxtInvQty.Text.Trim(), out a);

                    if (isAValid)
                        TxtHSQuantity.Text = (a / 10).ToString();

                }

                else if (UOm == "CEN")
                {
                    double a;
                    bool isAValid = double.TryParse(TxtInvQty.Text.Trim(), out a);

                    if (isAValid)
                        TxtHSQuantity.Text = (a / 100).ToString();

                }

                else if (UOm == "MIL")
                {
                    double a;
                    bool isAValid = double.TryParse(TxtInvQty.Text.Trim(), out a);

                    if (isAValid)
                        TxtHSQuantity.Text = (a / 1000).ToString();

                }

                else if (UOm == "TNE")
                {
                    double a;
                    bool isAValid = double.TryParse(TxtInvQty.Text.Trim(), out a);

                    if (isAValid)
                        TxtHSQuantity.Text = (a / 1000).ToString();

                }
                else if (UOm == "MTK")
                {
                    double a;
                    bool isAValid = double.TryParse(TxtInvQty.Text.Trim(), out a);

                    if (isAValid)
                        TxtHSQuantity.Text = (a * 3.213).ToString();

                }
                else if (UOm == "LTR")
                {
                    double a;
                    bool isAValid = double.TryParse(TxtInvQty.Text.Trim(), out a);

                    if (isAValid)
                        TxtHSQuantity.Text = (a * 1.25).ToString();
                }
                else if (UOm == "NMB")
                {
                    //  string tt;
                    // string [] tokens;
                    double a;
                    bool ss;
                    bool isAValid = double.TryParse(TxtInvQty.Text.Trim(), out a);

                    if (isAValid)

                        //  tt  = TxtInvQty.Text;
                        if (ss = TxtInvQty.Text.Contains("."))
                        {
                            TxtHSQuantity.Text = "Invalid";
                        }
                        else
                        {
                            TxtHSQuantity.Text = TxtInvQty.Text;
                        }


                    // tokens = TxtInvQty.Text.ToString ().Split('.');


                }
            }
        }

        protected void HSQTYUOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DrpTotalGrossWeight.SelectedItem.ToString() != "--select--")
            {
                if (DrpTotalGrossWeight.SelectedItem.ToString() == "TNE" || DrpTotalGrossWeight.SelectedItem.ToString() == "KGM")
                {
                    if (Convert.ToDecimal(TxtHSQuantity.Text) > Convert.ToDecimal(TxtTotalGrossWeight.Text))
                    {
                        Response.Write("<script LANGUAGE='JavaScript' >alert('Please Check Net Weight & Gross Weight')</script>");
                    }
                }
            }
        }

       

        protected void DrpCoType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DrpCoType.SelectedItem.ToString() == "TX : Application for textile products")
            {
                txttile.Visible = true;
            }
            else
            {
                txttile.Visible = false;
            }
            DrpCerDtl1.Focus();
            lblhblValue.Text = DrpCoType.SelectedItem.ToString();
            coitem.Update();
            cocargo.Update();
            coparty.Update();
        }

        protected void DrpOptionalUom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TxtOptionalPrice_TextChanged(object sender, EventArgs e)
        {

        }
        protected void ChkPackInfo_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkPackInfo.Checked == true)
            {
                PackingInfo.Visible = true;
            }
            else
            {
                PackingInfo.Visible = false;
            }
        }
        protected void Chkitemcasc_CheckedChanged(object sender, EventArgs e)
        {
            
        }
        protected void ChkTariff_CheckedChanged(object sender, EventArgs e)
        {
          
        }
        protected void Chklot_CheckedChanged(object sender, EventArgs e)
        {
        }

        protected void DrpCerDtl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (DrpCerDtl1.SelectedItem .Text  != "--Select--")
            {
                entryyrs.Visible = false;
                lbloblval.Text = DrpCerDtl1.SelectedItem.ToString();
             //   coinvno.Visible = true;
                //coorgincriterien.Visible = true;
                if (DrpCerDtl1.SelectedItem.Text.Trim () == "10 : Export Certificate for fresh cut orchids")
            {
                coinvno.Visible = false;
                coorgincriterien.Visible = false;
                common.Visible = false;
                itemvalue.Visible = false;
            }
                else if (DrpCerDtl1.SelectedItem.Text.Trim () == "12 : Global System of Trade Preference (GSTP)")
            {
                coinvno.Visible = true;
                coorgincriterien.Visible = true;
                common.Visible = false;
                itemvalue.Visible = false;
            }
                else if (DrpCerDtl1.SelectedItem.Text.Trim() == "1 : Generalised System of Preferences (GSP) Form A")
                {
                    coinvno.Visible = true;
                    coorgincriterien.Visible = true;
                    common.Visible = false;
                    itemvalue.Visible = false;
                }
                else if (DrpCerDtl1.SelectedItem.Text.Trim() == "16 : ASEAN Trade in Goods Agreement (ATIGA)")
                {
                    coinvno.Visible = true;
                    coorgincriterien.Visible = true;
                    common.Visible = false;
                    itemvalue.Visible = true;
                }
                else if (DrpCerDtl1.SelectedItem.Text.Trim() == "17 : Back to Back ATIGA Form D")
                {
                    coinvno.Visible = true;
                    coorgincriterien.Visible = true;
                    common.Visible = false;
                    itemvalue.Visible = true;
                }
                else if (DrpCerDtl1.SelectedItem.Text.Trim() == "18 : Preferential Certificate of Origin for FTA")
                {
                    coinvno.Visible = false;
                    coorgincriterien.Visible = false;
                    common.Visible = false;
                    itemvalue.Visible = false;
                    entryyrs.Visible = true;
                }
                else if (DrpCerDtl1.SelectedItem.Text.Trim() == "19 : Asean-China FTA Form E")
                {
                    coinvno.Visible = true;
                    coorgincriterien.Visible = true;
                    common.Visible = false;
                    itemvalue.Visible = true;
                }
                else if (DrpCerDtl1.SelectedItem.Text.Trim() == "2 : GSP Form A under Cumulative ASEAN")
                {
                    coinvno.Visible = true;
                    coorgincriterien.Visible = true;
                    gps.Visible = true;
                    itemvalue.Visible = false;
                    common.Visible = false;
                }
                else if (DrpCerDtl1.SelectedItem.Text.Trim() == "20 : Back-to-Back ACFTA Form E")
                {
                    gps.Visible = false;
                    coinvno.Visible = true;
                    coorgincriterien.Visible = true;
                    common.Visible = false;
                    itemvalue.Visible = true;
                }
                else if (DrpCerDtl1.SelectedItem.Text.Trim() == "21 : India Singapore CECA CO")
                {
                    gps.Visible = false;
                    coinvno.Visible = true;
                    coorgincriterien.Visible = true;
                    common.Visible = false;
                    itemvalue.Visible = true;
                }
                else if (DrpCerDtl1.SelectedItem.Text.Trim() == "22 : Back-to-Back AKFTA Form AK")
                {
                    gps.Visible = false;
                    coinvno.Visible = true;
                    coorgincriterien.Visible = true;

                    itemvalue.Visible = true;
                    common.Visible = false;
                }
                else if (DrpCerDtl1.SelectedItem.Text.Trim() == "23 : Asean-Korea FTA Form AK")
                {
                    gps.Visible = false;
                    coinvno.Visible = true;
                    coorgincriterien.Visible = true;
                    itemvalue.Visible = true;
                    common.Visible = false;
                }
                else if (DrpCerDtl1.SelectedItem.Text.Trim() == "24 : Certificate of Origin Generic Form Z")
                {
                    gps.Visible = false;
                    coinvno.Visible = true;
                    coorgincriterien.Visible = true;
                    itemvalue.Visible = true;
                    common.Visible = false;
                }
                else if (DrpCerDtl1.SelectedItem.Text.Trim() == "25 : Asean Japan CEP Form AJ")
                {
                    gps.Visible = false;
                    coinvno.Visible = true;
                    coorgincriterien.Visible = true;
                    itemvalue.Visible = true;
                    common.Visible = false;
                }
                else if (DrpCerDtl1.SelectedItem.Text.Trim() == "26 : Back-to-Back AJCEP Form AJ")
                {
                    gps.Visible = false;
                    coinvno.Visible = true;
                    coorgincriterien.Visible = true;
                    itemvalue.Visible = true;
                    common.Visible = false;
                }
                else if (DrpCerDtl1.SelectedItem.Text.Trim() == "27 : Asean India FTA Form AI")
                {
                    gps.Visible = false;
                    coinvno.Visible = true;
                    coorgincriterien.Visible = true;
                    itemvalue.Visible = true;
                    common.Visible = false;
                }
                else if (DrpCerDtl1.SelectedItem.Text.Trim() == "28 : Back-to-Back AIFTA Form AI")
                {
                    gps.Visible = false;
                    coinvno.Visible = true;
                    itemvalue.Visible = true;
                    coorgincriterien.Visible = true;
                    common.Visible = false;
                }
                else if (DrpCerDtl1.SelectedItem.Text.Trim () == "29 : Asean-Australia-New Zealand FTA Form AANZ")
                {
                    gps.Visible = false;
                    coinvno.Visible = true;
                    itemvalue.Visible = true;
                    coorgincriterien.Visible = true;
                    common.Visible = false;
                }
                else if (DrpCerDtl1.SelectedItem.Text.Trim() == "3 : Back to Back GSP Form A")
                {
                    gps.Visible = false;
                    coinvno.Visible = true;
                    itemvalue.Visible = false;
                    coorgincriterien.Visible = true;
                    common.Visible = false;
                }
                else if (DrpCerDtl1.SelectedItem.Text.Trim() == "30 : Back-to-Back AANZFTA Form AANZ")
                {
                    gps.Visible = false;
                    coinvno.Visible = true;
                    coorgincriterien.Visible = true;
                    common.Visible = false;
                    itemvalue.Visible = true;
                }
                else if (DrpCerDtl1.SelectedItem.Text.Trim() == "4 : Ordinary Certificate of Origin")
                {
                    gps.Visible = false;
                    coinvno.Visible = false;
                    itemvalue.Visible = false;
                    coorgincriterien.Visible = false;
                    common.Visible = false;
                }
                else if (DrpCerDtl1.SelectedItem.Text.Trim() == "4A : Certificate of Processing")
                {
                    gps.Visible = false;
                    coinvno.Visible = false;
                    coorgincriterien.Visible = false;
                    common.Visible = false;
                }
                else if (DrpCerDtl1.SelectedItem.Text.Trim() == "5 : Commonwealth Preference Certificate")
                {
                    gps.Visible = false;
                    coinvno.Visible = false;
                    coorgincriterien.Visible = false;
                    itemvalue.Visible = false;
                    common.Visible = true;
                }
                else if (DrpCerDtl1.SelectedItem.Text.Trim() == "7 : Form W (reserve)")
                {
                    gps.Visible = false;
                    coinvno.Visible = false;
                    coorgincriterien.Visible = false;
                    itemvalue.Visible = false;
                    common.Visible = false;
                }
                else if (DrpCerDtl1.SelectedItem.Text.Trim() == "9 : Ordinary Certificate of Origin for textile products to EU countries only")
                {
                    gps.Visible = false;
                    coinvno.Visible = false;
                    coorgincriterien.Visible = false;
                    itemvalue.Visible = true;
                    common.Visible = false;
                    entryyrs.Visible = true;
                }


            }
           
            else
            {
                //coinvno.Visible = false;
               // coorgincriterien.Visible = false;
            }
            TxtCerDtl1.Focus();
            coitem.Update();
            cocargo.Update();
            coparty.Update();
        }

        protected void TxttotalOuterPack_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxttotalOuterPack.Text))
            {
                lblnoofpack.Text = TxttotalOuterPack.Text+"-"+DrptotalOuterPack.SelectedItem.ToString();
            }
            DrptotalOuterPack.Focus();
        }

        protected void DrptotalOuterPack_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblnoofpack.Text = TxttotalOuterPack.Text + "-" + DrptotalOuterPack.SelectedItem.ToString();
            TxtTotalGrossWeight.Focus();
        }

        protected void TxtTotalGrossWeight_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxtTotalGrossWeight.Text))
            {
                lblgrossweight.Text = TxtTotalGrossWeight.Text + "-" + DrpTotalGrossWeight.SelectedItem.ToString();
            }
        }

        protected void DrpTotalGrossWeight_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblgrossweight.Text = TxtTotalGrossWeight.Text + "-" + DrpTotalGrossWeight.SelectedItem.ToString();
            btnprevcargo.Focus();

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
            co.Update();
            TxtDecCompCode.Focus();
        }

        protected void btnpreviousparty_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[TabContainer1.ActiveTabIndex - 1];
            co.Update();
        }

        protected void btnsaveparty_Click(object sender, EventArgs e)
        {

        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            PartyClr();
        }

        protected void btnnextparty_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[TabContainer1.ActiveTabIndex + 1];
            co.Update();
            TxtExpArrivalDate1.Focus();
        }

        protected void btnprevcargo_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[TabContainer1.ActiveTabIndex - 1];
            co.Update();
        }

        protected void btnsavecargo_Click(object sender, EventArgs e)
        {
            string Touch_user = Session["UserId"].ToString();

            DateTime DepatureDate = Convert.ToDateTime(null);
            if (TxtExpArrivalDate1.Text == "")
            {
                var date = DateTime.Now.ToString();
                var manDate = DateTime.ParseExact(date, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                DepatureDate = Convert.ToDateTime(manDate);
            }
            else
            {
                var InvoiceDate1 = DateTime.ParseExact(TxtExpArrivalDate1.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                DepatureDate = Convert.ToDateTime(InvoiceDate1);
            }


            // var DepatureDate = DateTime.Parse(this.TxtExpArrivalDate1.Text, new CultureInfo("en-US", true));
            JobNO();
            MSGNO();
            refid();
            string PrevPer = "";
            string qry11 = "SELECT PermitId FROM CoTemp where PermitId='" + txt_code.Text + "'";
            obj.dr = obj.ret_dr(qry11);
            while (obj.dr.Read())
            {
                PrevPer = obj.dr[0].ToString();
            }
            if (PrevPer != "")
            {
                string PerCount = ("Delete CoTemp where PermitId='" + txt_code.Text + "'");
                obj.exec(PerCount);
                obj.closecon();
            }
            string AddCerDtl = AddCerDtl1.Text + '-' + AddCerDtl2.Text + '-' + AddCerDtl3.Text + '-' + AddCerDtl4.Text + '-' + AddCerDtl5.Text;
            string TransportDetails = TransDtl1.Text + '-' + TransDtl2.Text + '-' + TransDtl3.Text + '-' + TransDtl4.Text + '-' + TransDtl5.Text;
            int chkCode = 0;
        Save:
            string nullvalue = "0.00";
            string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string StrQuery = ("INSERT INTO [dbo].[CoTemp] ([Refid],[JobId],[MSGId],[PermitId],[TradeNetMailboxID],[MessageType],[ApplicationType],[PreviousPermitNo],[OutwardTransportMode],[ReferenceDocuments],[COType],[CerDtlType1],[CerDtlCopy1],[CerDtlType2],[CerDtlCopy2],[CurrencyCode],[AdditionalCer],[TransportDtl],[DeclarantCompanyCode],[ExporterCompanyCode],[OutwardCarrierAgentCode],[FreightForwarderCode],[CONSIGNEECode],[Manufacturer],[DepartureDate],[DischargePort],[FinalDestinationCountry],[OutVoyageNumber],[OutVesselName],[OutConveyanceRefNo],[OutTransportId],[OutFlightNO],[OutAircraftRegNo],[TotalOuterPack],[TotalOuterPackUOM],[TotalGrossWeight],[TotalGrossWeightUOM],[DeclareIndicator],[NumberOfItems],[InternalRemarks],[TradeRemarks],[Status],[TouchUser],[TouchTime]) VALUES ( '" + refno + "','" + JobNo + "','" + MsgNO + "','" + txt_code.Text + "','" + TxtTradeMailID.Text + "','" + TxtMsgType.Text + "','" + TxtAppType.Text + "','" + TxtPrevPerNO.Text + "','" + DrpOutwardtrasMode.SelectedItem + "','" + ChkRefDoc.Checked.ToString() + "','" + DrpCoType.SelectedItem + "','" + DrpCerDtl1.SelectedItem + "','" + TxtCerDtl1.Text + "','" + DrpCerDtl2.SelectedItem + "','" + TxtCerDtl2.Text + "','" + DrpCurrencyCode.SelectedItem + "','" + AddCerDtl + "','" + TransportDetails + "', '" + TxtDecCompCode.Text + "','" + TxtExpCode.Text + "','" + OutwardCode.Text + "','" + FrieghtCode.Text + "','" + ConsigneeCode.Text + "','" + ManufacturerCode.Text + "','" + Convert.ToDateTime(DepatureDate).ToString("yyyy/MM/dd") + "','" + TxtExpLoadShort.Text + "','" + DrpFinalDesCountry.SelectedItem + "','" + OUTWARDVoyageNo.Text + "','" + OUTWARDVessel.Text + "','" + OUTWARDConref.Text + "','" + OUTWARDTransId.Text + "','" + OUTWARDFlightN0.Text + "','" + OUTWARDAirREgno.Text + "','" + TxttotalOuterPack.Text + "','" + DrptotalOuterPack.SelectedItem.ToString() + "','" + TxtTotalGrossWeight.Text + "','" + DrpTotalGrossWeight.SelectedItem.ToString() + "','" + chkalrt.Checked.ToString() + "','" + nullvalue + "','" + txtinternal.Text + "','" + txttrdremrk.Text + "','NEW','" + Touch_user + "',Convert(VARCHAR,'" + strTime + "',108)) ");
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
            TxtInHouseItem.Focus();
            co.Update();
        }

        protected void btnprevsum_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[TabContainer1.ActiveTabIndex - 1];
            co.Update();
        }


        private void updatenew()
        {
            string Touch_user = Session["UserId"].ToString();

            DateTime DepatureDate = Convert.ToDateTime(null);
            if (TxtExpArrivalDate1.Text == "")
            {
                var date = DateTime.Now.ToString();
                var manDate = DateTime.ParseExact(date, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                DepatureDate = Convert.ToDateTime(manDate);
            }
            else
            {
                var InvoiceDate1 = DateTime.ParseExact(TxtExpArrivalDate1.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                DepatureDate = Convert.ToDateTime(InvoiceDate1);
            }
            // var DepatureDate = DateTime.Parse(this.TxtExpArrivalDate1.Text, new CultureInfo("en-US", true));
            JobNO();
            MSGNO();
            refid();
            string AddCerDtl = AddCerDtl1.Text + '-' + AddCerDtl2.Text + '-' + AddCerDtl3.Text + '-' + AddCerDtl4.Text + '-' + AddCerDtl5.Text;
            string TransportDetails = TransDtl1.Text + '-' + TransDtl2.Text + '-' + TransDtl3.Text + '-' + TransDtl4.Text + '-' + TransDtl5.Text;

            string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            string StrQuery = ("Update COHeaderTbl set  Refid='" + refno + "', TradeNetMailboxID='" + TxtTradeMailID.Text + "',MessageType='" + TxtMsgType.Text + "',Status='NEW',ApplicationType='" + TxtAppType.Text + "',PreviousPermitNo='" + TxtPrevPerNO.Text + "', OutwardTransportMode='" + DrpOutwardtrasMode.SelectedItem.ToString() + "',ReferenceDocuments='" + ChkRefDoc.Checked.ToString() + "',[COType] = '" + DrpCoType.SelectedItem.ToString() + "',[CerDtlType1] ='" + DrpCerDtl1.SelectedItem.ToString() + "' ,[CerDtlCopy1] = '" + TxtCerDtl1.Text + "' ,[CerDtlType2] ='" + DrpCerDtl2.SelectedItem.ToString() + "'  ,[CerDtlCopy2] ='" + TxtCerDtl2.Text + "' ,[CurrencyCode] ='" + DrpCurrencyCode.SelectedItem.ToString() + "' ,[AdditionalCer] = '" + AddCerDtl + "' ,[TransportDtl] = '" + TransportDetails + "',DeclarantCompanyCode='" + TxtDecCompCode.Text + "',ExporterCompanyCode='" + TxtExpCode.Text + "',OutwardCarrierAgentCode='" + OutwardCode.Text + "',FreightForwarderCode='" + FrieghtCode.Text + "',CONSIGNEECode='" + ConsigneeCode.Text + "',Manufacturer='" + ManufacturerCode.Text + "',DepartureDate='" + Convert.ToDateTime(DepatureDate).ToString("yyyy/MM/dd") + "',DischargePort='" + TxtExpLoadShort.Text + "',FinalDestinationCountry='" + DrpFinalDesCountry.SelectedItem.ToString() + "',OutVoyageNumber='" + OUTWARDVoyageNo.Text + "',OutVesselName='" + OUTWARDVessel.Text + "',OutConveyanceRefNo='" + OUTWARDConref.Text + "',OutTransportId='" + OUTWARDTransId.Text + "',OutFlightNO='" + OUTWARDFlightN0.Text + "',OutAircraftRegNo='" + OUTWARDAirREgno.Text + "',[TotalOuterPack]='" + TxttotalOuterPack.Text + "',[TotalOuterPackUOM]='" + DrptotalOuterPack.SelectedItem.ToString() + "',[TotalGrossWeight]='" + TxtTotalGrossWeight.Text + "',[TotalGrossWeightUOM]='" + DrpTotalGrossWeight.SelectedItem.ToString() + "',TouchUser='" + Touch_user + "',TouchTime=Convert(VARCHAR,'" + strTime + "',108) where Id='" + Id + "'");
            obj.exec(StrQuery);


            
            Response.Redirect("CoList.aspx");
        }

        protected void btnsavesum_Click(object sender, EventArgs e)
        {





            Id = Convert.ToInt32(Session["Id"].ToString());
            if (Id != 0)
            {
                Editdata();
                Itemclear();
                Session["Edit"] = false;
                // eid = 0;
            }
            else
            {

                string justdate = DateTime.Now.ToString("yyyyMMdd");
                string Code = "";
                string qry11 = "SELECT PermitId FROM COHeaderTbl where PermitId='" + txt_code.Text + "' and MessageType='COODEC' and  LEFT(MSGId,8) ='" + justdate + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    Code = obj.dr[0].ToString();
                }
                if (Code == "")
                {
                    string Touch_user = Session["UserId"].ToString();

                    DateTime DepatureDate = Convert.ToDateTime(null);
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
                    string AddCerDtl = AddCerDtl1.Text + '-' + AddCerDtl2.Text + '-' + AddCerDtl3.Text + '-' + AddCerDtl4.Text + '-' + AddCerDtl5.Text;
                    string TransportDetails = TransDtl1.Text + '-' + TransDtl2.Text + '-' + TransDtl3.Text + '-' + TransDtl4.Text + '-' + TransDtl5.Text;
                    string aditionalreceipt = TxtRECPT1.Text + '-' + TxtRECPT2.Text + '-' + TxtRECPT3.Text;
                    int chkCode = 0;
                Save:
                    string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string StrQuery = ("INSERT INTO [dbo].[COHeaderTbl] ([Refid],[JobId],[MSGId],[PermitId],[TradeNetMailboxID],[MessageType],[ApplicationType],[PreviousPermitNo],[OutwardTransportMode],[ReferenceDocuments],[COType],[CerDtlType1],[CerDtlCopy1],[CerDtlType2],[CerDtlCopy2],[CurrencyCode],[AdditionalCer],[TransportDtl],[DeclarantCompanyCode],[ExporterCompanyCode],[OutwardCarrierAgentCode],[FreightForwarderCode],[CONSIGNEECode],[Manufacturer],[DepartureDate],[DischargePort],[FinalDestinationCountry],[OutVoyageNumber],[OutVesselName],[OutConveyanceRefNo],[OutTransportId],[OutFlightNO],[OutAircraftRegNo],[TotalOuterPack],[TotalOuterPackUOM],[TotalGrossWeight],[TotalGrossWeightUOM],[DeclareIndicator],[NumberOfItems],[InternalRemarks],[TradeRemarks],[EntryYear],[Status],[TouchUser],[TouchTime],[Additionalrecieptant],[Gpsdonorcountry],[Percomwealth],[GrossReference]) VALUES ( '" + refno + "','" + JobNo + "','" + MsgNO + "','" + txt_code.Text + "','" + TxtTradeMailID.Text + "','" + TxtMsgType.Text + "','" + TxtAppType.Text + "','" + TxtPrevPerNO.Text + "','" + DrpOutwardtrasMode.SelectedItem + "','" + ChkRefDoc.Checked.ToString() + "','" + DrpCoType.SelectedItem + "','" + DrpCerDtl1.SelectedItem + "','" + TxtCerDtl1.Text + "','" + DrpCerDtl2.SelectedItem + "','" + TxtCerDtl2.Text + "','" + DrpCurrencyCode.SelectedItem + "','" + AddCerDtl + "','" + TransportDetails + "', '" + TxtDecCompCode.Text + "','" + TxtExpCode.Text + "','" + OutwardCode.Text + "','" + FrieghtCode.Text + "','" + ConsigneeCode.Text + "','" + ManufacturerCode.Text + "','" + Convert.ToDateTime(DepatureDate).ToString("yyyy/MM/dd") + "','" + TxtExpLoadShort.Text + "','" + DrpFinalDesCountry.SelectedItem + "','" + OUTWARDVoyageNo.Text + "','" + OUTWARDVessel.Text + "','" + OUTWARDConref.Text + "','" + OUTWARDTransId.Text + "','" + OUTWARDFlightN0.Text + "','" + OUTWARDAirREgno.Text + "','" + TxttotalOuterPack.Text + "','" + DrptotalOuterPack.SelectedItem.ToString() + "','" + TxtTotalGrossWeight.Text + "','" + DrpTotalGrossWeight.SelectedItem.ToString() + "','" + chkalrt.Checked.ToString() + "','" + txtnoofitm.Text + "','" + txtinternal.Text + "','" + txttrdremrk.Text + "','" + txtentry.Text + "','NEW','" + Touch_user + "',Convert(VARCHAR,'" + strTime + "',108),'" + aditionalreceipt + "','" + Drpgpsdonorcountry.SelectedItem.ToString() + "','" + txtper.Text + "','"+TxtGrossReference.Text +"') ");
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


                    if (CopyMsg == "")
                    {
                        string PerCount1 = ("INSERT INTO [dbo].[PermitCount] ([PermitId],[MessageType],[AccountId],[MsgId],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Session["AccountId"].ToString() + "','" + MsgNO + "','" + Touch_user + "','" + TouchDate + "')");
                        obj.exec(PerCount1);
                        obj.closecon();
                        // MSGNO();
                    }


                    //Clear Temp Data
                    string tempdel = ("delete from CoTemp where PermitId='" + txt_code.Text + "' and TouchUser='" + Touch_user + "' ");
                    obj.exec(tempdel);

                   // string TouchDate = DateTime.Now.ToString("yyyy/MM/dd");
                    //Count Permit
                    //string PerCount = ("INSERT INTO [dbo].[PermitCount] ([PermitId],[MessageType],[AccountId],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Session["AccountId"].ToString() + "','" + Touch_user + "','" + TouchDate + "')");

                    //obj.exec(PerCount);
                    //obj.closecon();

                    Response.Redirect("CoList.aspx");

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Permit Code '" + txt_code.Text + "' Already Exist..');", true);
                    //  Response.Write("The Importer Code Already Exist..");
                }
                Itemclear();
            }

        }

        protected void btnresetsum_Click(object sender, EventArgs e)
        {

        }

        protected void btnnextsum_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[TabContainer1.ActiveTabIndex + 1];
            co.Update();
        }

        protected void btnprevcpc_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[TabContainer1.ActiveTabIndex - 1];
            co.Update();
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
            co.Update();
        }

        protected void btnprevitem_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[TabContainer1.ActiveTabIndex - 1];
            co.Update();
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
            co.Update();
            txttrdremrk.Focus();

        }

        protected void DECCOMPSearGRID_RowCreated(object sender, GridViewRowEventArgs e)
        {

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
                    // DECCOMPSearGRID.Visible = false;

                }
            }
           
            co.Update();
            coparty.Update();
            TxtExpCode.Focus();
           
        }

        protected void DECCOMPSearGRID_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(DECCOMPSearGRID, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void ExporterGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //  DECCOMPSearGRID.SelectedIndex = Convert.ToInt16(e.CommandArgument);
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

                        //UpdatePanelDCS.Update();
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
                        //  UpdatePanelDCS.Update();

                    }
                    // DECCOMPSearGRID.Visible = false;

                }
            }
            co.Update();
            coparty.Update();
            InwardCode.Focus();

           
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
                        InwardName.Text = "";
                        InwardName1.Text = "";
                        InwardCRUEI.Text = "";
                        InwardCode.Text = requestor;
                        InwardName.Text = requestType;
                        InwardName1.Text = status;
                        InwardCRUEI.Text = crueis;
                        //  UpdatePanelDCS.Update();

                    }
                    // DECCOMPSearGRID.Visible = false;

                }
            }
            co.Update();
            coparty.Update();
            OutwardCode.Focus();
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
                //  DECCOMPSearGRID.SelectedIndex = Convert.ToInt16(e.CommandArgument);
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

                        //UpdatePanelDCS.Update();
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
                        //  UpdatePanelDCS.Update();

                    }
                    // DECCOMPSearGRID.Visible = false;

                }
            }
            co.Update();
            coparty.Update();
            FrieghtCode.Focus(); 
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
                        FrieghtName.Text = "";
                        FrieghtName1.Text = "";
                        FrieghtCRUEI.Text = "";
                        FrieghtCode.Text = requestor;
                        FrieghtName.Text = requestType;
                        FrieghtName1.Text = status;
                        FrieghtCRUEI.Text = crueis;
                        //  UpdatePanelDCS.Update();

                    }
                    // DECCOMPSearGRID.Visible = false;

                }
            }
         
            co.Update();
           
            coparty.Update();
            ConsigneeCode.Focus();
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
                //  DECCOMPSearGRID.SelectedIndex = Convert.ToInt16(e.CommandArgument);
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = ConsigneeGrid.Rows[rowIndex];
                if (row != null)
                {
                    var lblCode1 = row.FindControl("lblCode") as Label;
                    var lblName1 = row.FindControl("lblName") as Label;
                    var lblName11 = row.FindControl("lblName1") as Label;
                    var cruei1 = row.FindControl("lblCRUEI") as Label;


                    var lblca = row.FindControl("ConsigneeAddress") as Label;
                    var lblca1 = row.FindControl("ConsigneeAddress1") as Label;
                    var lblcc = row.FindControl("ConsigneeCity") as Label;
                    var lblcs = row.FindControl("ConsigneeSub") as Label;
                    var lblcsd = row.FindControl("ConsigneeSubDivi1") as Label;
                    var lblcp = row.FindControl("ConsigneePostal") as Label;
                    var country = row.FindControl("ConsigneeCountry") as Label;

                    if (lblCode1 != null && lblName1 != null && lblName11 != null && cruei1 != null)
                    {

                        //UpdatePanelDCS.Update();
                        //Get values
                        string requestor = lblCode1.Text;
                        string requestType = lblName1.Text;
                        string status = lblName11.Text;
                        string crueis = cruei1.Text;

                        string consigneaddress = lblca.Text;
                        string conadd1 = lblca1.Text;
                        string consigneecity = lblcc.Text;
                      //  string consub = lblcs.Text;
                       // string consubd = lblcsd.Text;
                        string conportal = lblcp.Text;
                        string concountry = country.Text;


                        ConsigneeCode.Text = "";
                        ConsigneeAddress.Text = "";
                        ConsigneeSub.Text = "";
                        ConsigneeCRUEI.Text = "";
                        //ConsigneeSubDivi.Text = "";
                        ConsigneeName.Text = "";
                        ConsigneeAddress1.Text = "";
                        ConsigneePostal.Text = "";
                        ConsigneeName1.Text = "";
                        ConsigneeCity.Text = "";
                        ConsigneeCountry.Text = "";


                        ConsigneeCode.Text = requestor;
                        ConsigneeAddress.Text = requestType;
                       // ConsigneeSub.Text = consub;
                        //ConsigneeSubDivi.Text = consubd;
                        ConsigneeCRUEI.Text = crueis;

                        ConsigneeName.Text = consigneaddress;
                        ConsigneeAddress1.Text = conadd1;
                        ConsigneePostal.Text = conportal;
                        ConsigneeName1.Text = status;
                        ConsigneeCity.Text = consigneecity;
                        ConsigneeCountry.Text = concountry;

                        //  UpdatePanelDCS.Update();

                    }
                    // DECCOMPSearGRID.Visible = false;

                }
            }
         
            co.Update();
            coparty.Update();
            ManufacturerCode.Focus();
        }

        protected void ConsigneeGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(ConsigneeGrid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void ManufacturerGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //  DECCOMPSearGRID.SelectedIndex = Convert.ToInt16(e.CommandArgument);
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = ManufacturerGrid.Rows[rowIndex];
                if (row != null)
                {
                    var lblCode1 = row.FindControl("lblCode") as Label;
                    var lblName1 = row.FindControl("lblName") as Label;
                    var lblName11 = row.FindControl("lblName1") as Label;
                    var cruei1 = row.FindControl("lblCRUEI") as Label;
                    var ConsigneeAddress1 = row.FindControl("ConsigneeAddress") as Label;
                    var ConsigneeAddress11 = row.FindControl("ConsigneeAddress1") as Label;
                    var ConsigneeCity1 = row.FindControl("ConsigneeCity") as Label;
                    var ConsigneeCity13 = row.FindControl("ManufacturerSubCode") as Label;

                    var ConsigneeSub1 = row.FindControl("ConsigneeSub") as Label;
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
                    string ConsigneeSubDivi = ConsigneeCity13.Text;
                    string ConsigneeSub12 = ConsigneeSub1.Text;
                    string ConsigneePostal12 = ConsigneePostal1.Text;
                    string ConsigneeCountry12 = ConsigneeCountry1.Text;


                    ManufacturerCode.Text = "";
                    ManufacturerName.Text = "";
                    ManufacturerName1.Text = "";
                    ManufacturerCRUEI.Text = "";
                    ManufacturerAddress.Text = "";
                    ManufacturerAddress1.Text = "";
                    ManufacturerCity.Text = "";
                    ManufacturerSubCode.Text = "";
                    ManufacturerPostal.Text = "";
                    ManufacturerCountry.Text = "";
                    ManufacturerSubDivi.Text = "";



                    ManufacturerCode.Text = requestor;
                    ManufacturerName.Text = requestType;
                    ManufacturerName1.Text = ConsigneeAddress12;
                    ManufacturerCRUEI.Text = crueis;
                    ManufacturerAddress.Text = status;
                    ManufacturerAddress1.Text = ConsigneeAddress112;
                    ManufacturerCity.Text = ConsigneeCity12;
                    ManufacturerSubCode.Text = ConsigneeSub12;
                    ManufacturerPostal.Text = ConsigneePostal12;
                    ManufacturerCountry.Text = ConsigneeCountry12;
                   ManufacturerSubDivi.Text = ConsigneeSubDivi;
                    //  UpdatePanelDCS.Update();


                    // DECCOMPSearGRID.Visible = false;

                }
            }
            btnpreviousparty.Focus();
            co.Update();
        }

        protected void ManufacturerGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(ManufacturerGrid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void ExportGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //  DECCOMPSearGRID.SelectedIndex = Convert.ToInt16(e.CommandArgument);
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

                        //UpdatePanelDCS.Update();
                        //Get values
                        string requestor = lblCode1.Text;
                        string requestType = lblName1.Text;
                        string status = lblName11.Text;
                        // string crueis = cruei1.Text;
                        TxtExpLoadShort.Text = "";
                        TxtExpLoad.Text = "";

                        TxtExpLoadShort.Text = requestor;
                        TxtExpLoad.Text = requestType;

                        //  UpdatePanelDCS.Update();

                    }
                    // DECCOMPSearGRID.Visible = false;

                }
            }
            TxtExpLoadShort.Focus();
            co.Update();
        }

        protected void ExportGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(ExportGrid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
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
                    // var lblCode1 = row.FindControl("lblCode") as Label;
                    var lblName1 = row.FindControl("lblName") as Label;
                    var lblName11 = row.FindControl("lblName1") as Label;
                    //   var cruei1 = row.FindControl("lblCRUEI") as Label;

                    if (lblName1 != null && lblName11 != null)
                    {

                        //UpdatePanelDCS.Update();
                        //Get values
                        // string requestor = lblCode1.Text;
                        string requestType = lblName1.Text;
                        string status = lblName11.Text;
                        // string crueis = cruei1.Text;
                        TxtCountryItem.Text = "";
                        txtcname.Text = "";

                        TxtCountryItem.Text = requestType;
                        txtcname.Text = status;

                        //  UpdatePanelDCS.Update();

                    }
                    // DECCOMPSearGRID.Visible = false;

                }
            }
            co.Update();
        }

        protected void CountryGridItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void BtnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("CoList.aspx");
        }
        public void HeaderClr()
        {
            TxtPrevPerNO.Text = "";
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
            DrpCoType.ClearSelection();
            DrpCoType.Items.FindByText("--Select--").Selected = true;
            Drpgpsdonorcountry.ClearSelection();
            Drpgpsdonorcountry.Items.FindByText("--Select--").Selected = true;
            DrpCerDtl1.ClearSelection();
            DrpCerDtl1.Items.FindByText("--Select--").Selected = true;
            TxtCerDtl1.Text = "";
            DrpCerDtl2.ClearSelection();
            DrpCerDtl2.Items.FindByText("--Select--").Selected = true;
            TxtCerDtl2.Text = "";
            txtper.Text = "";
            DrpCurrencyCode.ClearSelection();
            DrpCurrencyCode.Items.FindByText("--Select--").Selected = true;
            AddCerDtl1.Text = "";
            AddCerDtl2.Text = "";
            AddCerDtl3.Text = "";
            AddCerDtl4.Text = "";
            AddCerDtl5.Text = "";
            TransDtl1.Text = "";
            TransDtl2.Text = "";
            TransDtl3.Text = "";
            TransDtl4.Text = "";
            TransDtl5.Text = "";
            TxtRECPT1.Text = "";
            TxtRECPT2.Text = "";
            TxtRECPT3.Text = "";
            txtper.Text = "0.00";
            Drpgpsdonorcountry.ClearSelection();
            Drpgpsdonorcountry.Items.FindByText("--Select--").Selected = true;
        }

        public void PartyClr()
        {
            TxtDecCompCode.Text = "";
            TxtDecCompCRUEI.Text = "";
            TxtDecCompName.Text = "";
            TxtDecCompName1.Text = "";
            TxtExpCode.Text = "";
            TxtExpCRUEI.Text = "";
            TxtExpName.Text = "";
            TxtExpName1.Text = "";
            txtadd1.Text = "";
            txtadd2.Text = "";
            txtadd3.Text = "";
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
            ConsigneeName.Text = "";
            ConsigneeAddress1.Text = "";
            ConsigneePostal.Text = "";
            ConsigneeName1.Text = "";
            ConsigneeCity.Text = "";
            ConsigneeCountry.Text = "";
            ManufacturerCode.Text = "";
            ManufacturerCRUEI.Text = "";
            ManufacturerAddress.Text = "";
            ManufacturerSubCode.Text = "";
            ManufacturerPostal.Text = "";
            ManufacturerName.Text = "";
            ManufacturerAddress1.Text = "";
            ManufacturerSubDivi.Text = "";
            ManufacturerName1.Text = "";
            ManufacturerCity.Text = "";
            ManufacturerCountry.Text = "";

        }
        public void CargoClr()
        {
            TxtArrivalDate1.Value = "";
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
            txtreLoctn.Text = "";
            txtrelocDeta.Text = "";
            txtrecloctn.Text = "";
            txtrecloctndet.Text = "";
            TxtStorageShort.Text = "";
            TxtStorageName.Text = "";
            TxtExpArrivalDate1.Text = "";
            TxtExpLoadShort.Text = "";
            TxtExpLoad.Text = "";
            DrpFinalDesCountry.ClearSelection();
            DrpFinalDesCountry.Items.FindByText("--Select--").Selected = true;
            chkSea.Checked = false;
            OUTWARDFlightN0.Text = "";
            OUTWARDAirREgno.Text = "";
            OUTWARDVoyageNo.Text = "";
            OUTWARDVessel.Text = "";
            OUTWARDConref.Text = "";
            OUTWARDTransId.Text = "";
            DrpCerDtl2.ClearSelection();
            DrpCerDtl2.Items.FindByText("--Select--").Selected = true;
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
            TxtGrossReference.Text = "";

        }

        protected void TxtExpArrivalDate1_TextChanged(object sender, EventArgs e)
        {
            TxtExpArrivalDate1.Text = DateCheck(TxtExpArrivalDate1.Text);
            TxtExpLoadShort.Focus();
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

        protected void TxtManuDate_TextChanged(object sender, EventArgs e)
        {
            TxtManuDate.Text = DateCheck(TxtManuDate.Text);
            txtcifitemvalue.Focus();
        }

        protected void TxtInvDate_TextChanged(object sender, EventArgs e)
        {
            TxtInvDate.Text = DateCheck(TxtInvDate.Text);
            TxtHSCodeCer.Focus();
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

        protected void TxtInvQTY2_TextChanged(object sender, EventArgs e)
        {
            string qry11 = "select UOM from HSCode where HSCode='" + TxtHSCodeItem.Text + "'";
            obj.dr = obj.ret_dr(qry11);
            while (obj.dr.Read())
            {
                string UOm = obj.dr[0].ToString();


                if (UOm == "TEN")
                {
                    double a;
                    bool isAValid = double.TryParse(TxtInvQTY2.Text.Trim(), out a);

                    if (isAValid)
                        TxtHSQty.Text = (a / 10).ToString();

                }
                else if (UOm == "TPR")
                {
                    double a;
                    bool isAValid = double.TryParse(TxtInvQTY2.Text.Trim(), out a);

                    if (isAValid)
                        TxtHSQty.Text = (a / 10).ToString();

                }

                else if (UOm == "CEN")
                {
                    double a;
                    bool isAValid = double.TryParse(TxtInvQTY2.Text.Trim(), out a);

                    if (isAValid)
                        TxtHSQty.Text = (a / 100).ToString();

                }

                else if (UOm == "MIL")
                {
                    double a;
                    bool isAValid = double.TryParse(TxtInvQTY2.Text.Trim(), out a);

                    if (isAValid)
                        TxtHSQty.Text = (a / 1000).ToString();

                }

                else if (UOm == "TNE")
                {
                    double a;
                    bool isAValid = double.TryParse(TxtInvQTY2.Text.Trim(), out a);

                    if (isAValid)
                        TxtHSQty.Text = (a / 1000).ToString();

                }
                else if (UOm == "MTK")
                {
                    double a;
                    bool isAValid = double.TryParse(TxtInvQTY2.Text.Trim(), out a);

                    if (isAValid)
                        TxtHSQty.Text = (a * 3.213).ToString();

                }
                else if (UOm == "LTR")
                {
                    double a;
                    bool isAValid = double.TryParse(TxtInvQTY2.Text.Trim(), out a);

                    if (isAValid)
                        TxtHSQty.Text = (a * 1.25).ToString();
                }
                else if (UOm == "KGM")
                {
                    TxtHSQuantity.Text = TxtInvQTY2.Text;
                }
                else if (UOm == "NMB")
                {
                    //  string tt;
                    // string [] tokens;
                    double a;
                    bool ss;
                    bool isAValid = double.TryParse(TxtInvQTY2.Text.Trim(), out a);

                    if (isAValid)

                        //  tt  = TxtInvQty.Text;
                        if (ss = TxtInvQTY2.Text.Contains("."))
                        {
                            lblinvqty.Visible = true;
                            lblinvqty.Text = "Invalid";
                        }
                        else
                        {
                            lblinvqty.Visible = false;
                            TxtHSQty.Text = TxtInvQTY2.Text;
                        }


                    // tokens = TxtInvQty.Text.ToString ().Split('.');


                }

                else if (UOm == "-")
                {
                    //  string tt;
                    // string [] tokens;
                    double a;
                    bool ss;
                    bool isAValid = double.TryParse(TxtInvQTY2.Text.Trim(), out a);

                    if (isAValid)

                        //  tt  = TxtInvQty.Text;
                        if (ss = TxtInvQTY2.Text.Contains("."))
                        {
                            lblinvqty.Visible = true;
                            lblinvqty.Text = "Invalid";
                        }
                        else
                        {
                            lblinvqty.Visible = false;
                            TxtHSQty.Text = TxtInvQTY2.Text;
                        }


                    // tokens = TxtInvQty.Text.ToString ().Split('.');


                }
                else
                {
                    TxtHSQty.Text = TxtInvQTY2.Text;
                }
            }
            TxtHSQty.Focus();
        }

        protected void DrpCurrencyCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblnoofpack.Text = DrpCurrencyCode.SelectedItem.Text;
            cosummery.Update();
        }

        protected void TxtPrevPerNO_TextChanged(object sender, EventArgs e)
        {
            lblgrossweight.Text = TxtPrevPerNO.Text;
            cosummery.Update();
        }

        protected void txtcifitemvalue_TextChanged(object sender, EventArgs e)
        {
            if (txtcifitemvalue.Text != "")
            {
                txtitemvaluecert.Text = txtcifitemvalue.Text;
            }
            else
            {
                txtitemvaluecert.Text = "";
            }
            cosummery.Update();
        }

        protected void btnprev_Click(object sender, EventArgs e)
        {
            int itemno1 = Convert.ToInt32(TxtSerialNo.Text);

            int id = itemno1 - 1;
            string ID = id.ToString();
            prevnextitem(ID);
        }

        protected void GridCondition_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridCondition.PageIndex = e.NewPageIndex;
            BindCondition();
        }

        protected void btnnxt_Click(object sender, EventArgs e)
        {
            int itemno1 = Convert.ToInt32(TxtSerialNo.Text);

            int id = itemno1 + 1;
            string ID = id.ToString();
            prevnextitem(ID);
        }
        protected void prevnextitem(string itemno1)
        {
            string Invoice = txt_code.Text;
            string strBindTxtBox = "select * from [COItemDtl]where ItemNo='" + itemno1 + "' and PermitId='" + Invoice + "'";
            obj.dr = obj.ret_dr(strBindTxtBox);
            while (obj.dr.Read())
            {
                itemno.Text = obj.dr["ItemNo"].ToString();
                TxtSerialNo.Text = obj.dr["ItemNo"].ToString();
                TxtHSCodeItem.Text = obj.dr["HSCode"].ToString();
                TxtDescription.Text = obj.dr["Description"].ToString();
                TxtCountryItem.Text = obj.dr["Contry"].ToString();
                TxtCountryItem_TextChanged(null, null);
                TxtUnitPrice.Text = obj.dr["UnitPrice"].ToString();
                DRPCurrency.ClearSelection();
                DRPCurrency.Items.FindByText(obj.dr["UnitPriceCurrency"].ToString()).Selected = true;
                TxtExchangeRate.Text = obj.dr["ExchangeRate"].ToString();
                TxtSumExRate.Text = obj.dr["SumExchangeRate"].ToString();
                TxtTotalLineAmount.Text = obj.dr["TotalLineAmount"].ToString();
                TxtCIFFOB.Text = obj.dr["CIFFOB"].ToString();

                TxtInvQTY2.Text = obj.dr["InvoiceQty"].ToString();
                TxtHSQty.Text = obj.dr["HSQTY"].ToString();

                drpInvoiceUOM.ClearSelection();
                drpInvoiceUOM.Items.FindByText(obj.dr["HSUOM"].ToString()).Selected = true;

                txtShippingMarks1.Text = obj.dr["ShippingMark"].ToString();
                TxtCerITEMQty.Text = obj.dr["CerItemQty"].ToString();
                DrpCerITemUOM.ClearSelection();
                DrpCerITemUOM.Items.FindByText(obj.dr["CerItemUOM"].ToString()).Selected = true;

                TxtManuDate.Text = Convert.ToDateTime(obj.dr["ManfCostDate"].ToString()).ToString("dd/MM/yyyy");
                TxtTextileCat.Text = obj.dr["TextileCat"].ToString();
                TxtTextileQty.Text = obj.dr["TextileQuotaQty"].ToString();
                DrpTextQoutoQTYUOM.ClearSelection();
                DrpTextQoutoQTYUOM.Items.FindByText(obj.dr["TextileQuotaQtyUOM"].ToString()).Selected = true;

                TxtInvDate.Text = Convert.ToDateTime(obj.dr["InvoiceDate"].ToString()).ToString("dd/MM/yyyy");
                TxtHSCodeCer.Text = obj.dr["HSOnCer"].ToString();

                TxtPerOrgCir.Text = obj.dr["PerOrgainCRI"].ToString();
                TxtCerDes.Text = obj.dr["CertificateDes"].ToString();
                txtcifitemvalue.Text = obj.dr["ItemValue"].ToString();
                txtinvno.Text = obj.dr["InvoiceNumber"].ToString();
                txtcreteriencode.Text = obj.dr["OriginCriterion"].ToString();
                TxtHSCodeCer.Text = obj.dr["HSOnCer"].ToString();
                txthawbl.Text = obj.dr["Hawblno"].ToString();
                TxtPerOrgCir.Text = obj.dr["PerOrgainCRI"].ToString();

                string[] orgncre = obj.dr["OriginCriterion"].ToString().Split(',');
                for (int i = 0; i < orgncre.Length; i++)
                {
                    if (i == 0)
                    {
                        txtcreteriencode.Text = orgncre[i].ToString();
                    }
                    if (i == 1)
                    {
                        txtcodesc1.Text = orgncre[i].ToString();
                    }
                    if (i == 2)
                    {
                        txtcodesc2.Text = orgncre[i].ToString();
                    }
                    if (i == 3)
                    {
                        txtcodesc3.Text = orgncre[i].ToString();
                    }
                }

                ItemAddGrid.Visible = true;
                ItemDiv.Visible = true;
                BtnAddNEWItem.Visible = false;

            }
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

                divItem.Attributes["class"] = divItem.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();

                divSummary.Attributes["class"] = divSummary.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();

            }
            else if (TabContainer1.ActiveTabIndex == 1)
            {
                divHeader.Attributes["class"] = divHeader.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divHeader.Attributes.Add("class", "flex flex-col justify-center items-center relative  complete-stepper");
                divParty.Attributes.Add("class", "flex flex-col justify-center items-center relative  active-stepper");
                divCargo.Attributes["class"] = divCargo.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();



                divItem.Attributes["class"] = divItem.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();

                divSummary.Attributes["class"] = divSummary.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();

            }
            else if (TabContainer1.ActiveTabIndex == 2)
            {
                divHeader.Attributes["class"] = divHeader.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divHeader.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                divParty.Attributes["class"] = divParty.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divParty.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                divCargo.Attributes.Add("class", "flex flex-col justify-center items-center relative active-stepper");

                divItem.Attributes["class"] = divItem.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();

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

                divItem.Attributes["class"] = divItem.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();

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

                divItem.Attributes.Add("class", "flex flex-col justify-center items-center relative active-stepper");

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

                divItem.Attributes["class"] = divItem.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divItem.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");

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

                divItem.Attributes["class"] = divItem.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divItem.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");

                divSummary.Attributes.Add("class", "flex flex-col justify-center items-center relative active-stepper");

            }
        }


    }
}