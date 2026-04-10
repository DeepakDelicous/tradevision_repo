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
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RET
{
    public partial class Transhipment : System.Web.UI.Page
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
        MyClass obj = new MyClass();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
        string sqlconn = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
        string TempDataPermitNo = "";
        /*  SqlDataAdapter dastudent;
          DataSet ds_student, ds_course;
          SqlCommand cmdStudent;*/
        //string DecAccountID = "";
        static string JobNo, MsgNO = "",refno = "";
        public static string uom, kgmvis;
        private static string Update = "";
        private static string chkstatus = "NEW";
        private static int Id = 0;
        //bool edit = false;
        string ErrorDes = "";
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
                SqlCommand cmd = new SqlCommand("select * from  DeclarantCompany where AccountID='" + DecAccountID + "' and  Code like '" + prefixText + "%'  ", sqlconn);
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
        public static List<string> GetOutWard(string prefixText)
        {
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select * from  [transOutward] where Code like '" + prefixText + "%' ", sqlconn);
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
                SqlCommand cmd = new SqlCommand("select * from  transfreight where Code like '" + prefixText + "%' ", sqlconn);
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

        //Inward Code

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetInwcode(string prefixText)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select * from  transInwardcarrier where Code like '" + prefixText + "%' ", sqlconn);
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

        //ImportCode

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetImpcode(string prefixText)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select * from  Importer where Code like '" + prefixText + "%' ", sqlconn);
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
                SqlCommand cmd = new SqlCommand("select * from  HandingAgent where Code like '" + prefixText + "%' ", sqlconn);
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

        //Consignee
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetCosigncode(string prefixText)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select * from  transConsignee where ConsigneeCode like '" + prefixText + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@ConsigneeName", prefixText);
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



        //End User
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetEnduser(string prefixText)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select * from  transEnduser where EndUserCode like '" + prefixText + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@EndUserCode", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                List<string> Deccode = new List<string>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {


                    Deccode.Add(dt.Rows[i]["EndUserCode"].ToString() + ":" + dt.Rows[i]["EndUserName"].ToString());


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
                SqlCommand cmd = new SqlCommand("select * from  ReleaseLocation where Code like '" + prefixText + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@Description", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                List<string> Deccode = new List<string>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {


                    Deccode.Add(dt.Rows[i]["Code"].ToString() + ":" + dt.Rows[i]["Description"].ToString());
                    // Deccode.Add(dt.Rows[i]["Code"].ToString());


                    // string con = String.Concat(Deccode, DecName);


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
                SqlCommand cmd = new SqlCommand("select * from  ReceiptLocation where Code like '" + prefixText + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@Description", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                List<string> Deccode = new List<string>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {


                    Deccode.Add(dt.Rows[i]["Code"].ToString() + ":" + dt.Rows[i]["Description"].ToString());

                    // Deccode.Add(dt.Rows[i]["Code"].ToString());
                    // string con = String.Concat(Deccode, DecName);


                }
                return Deccode;
            }
        }

        // Get Storage  Location
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetStorageLoc(string prefixText)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select * from  ReceiptLocation where Code like '" + prefixText + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@Description", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                List<string> Deccode = new List<string>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {


                    Deccode.Add(dt.Rows[i]["Code"].ToString() + ":" + dt.Rows[i]["Description"].ToString());

                    // Deccode.Add(dt.Rows[i]["Code"].ToString());
                    // string con = String.Concat(Deccode, DecName);


                }
                return Deccode;
            }
        }


        // Get Storage  Location
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetLoadingport(string prefixText)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select * from  LoadingPort where PortCode like '" + prefixText + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@PortName", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                List<string> Deccode = new List<string>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {


                    Deccode.Add(dt.Rows[i]["PortCode"].ToString() + ":" + dt.Rows[i]["PortName"].ToString());

                    //Deccode.Add(dt.Rows[i]["Code"].ToString());
                    // string con = String.Concat(Deccode, DecName);


                }
                return Deccode;
            }
        }

        // Get Storage  Location
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetDischargeport(string prefixText)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select * from  LoadingPort where PortCode like '" + prefixText + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@PortName", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                List<string> Deccode = new List<string>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {


                    Deccode.Add(dt.Rows[i]["PortCode"].ToString() + ":" + dt.Rows[i]["PortName"].ToString());

                    //Deccode.Add(dt.Rows[i]["Code"].ToString());
                    // string con = String.Concat(Deccode, DecName);


                }
                return Deccode;
            }
        }
        // Get Storage  Location
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetNextport(string prefixText)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select * from  LoadingPort where PortCode like '" + prefixText + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@PortName", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                List<string> Deccode = new List<string>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {


                    Deccode.Add(dt.Rows[i]["PortCode"].ToString() + ":" + dt.Rows[i]["PortName"].ToString());

                    //Deccode.Add(dt.Rows[i]["Code"].ToString());
                    // string con = String.Concat(Deccode, DecName);


                }
                return Deccode;
            }
        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetLastport(string prefixText)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select * from  LoadingPort where PortCode like '" + prefixText + "%' ", sqlconn);
                cmd.Parameters.AddWithValue("@PortName", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                List<string> Deccode = new List<string>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {


                    Deccode.Add(dt.Rows[i]["PortCode"].ToString() + ":" + dt.Rows[i]["PortName"].ToString());

                    //Deccode.Add(dt.Rows[i]["Code"].ToString());
                    // string con = String.Concat(Deccode, DecName);


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
                SqlCommand cmd = new SqlCommand("select * from  SUPPLIERMANUFACTURERPARTY where Code like '" + prefixText + "%' ", sqlconn);
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




        // Get Importer Party Code

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetImppartycode(string prefixText)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select * from  Exporter where Code like '" + prefixText + "%' ", sqlconn);
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
                SqlCommand cmd = new SqlCommand("select * from  InhouseItemCode where InhouseCode like '" + prefixText + "%' ", sqlconn);
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
                SqlCommand cmd = new SqlCommand("select DISTINCT Top 8 HSCode,Description, is_trans_controlled from  HSCode where HSCode like '" + prefixText + "%' ", sqlconn);
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


                    Deccode.Add(dt.Rows[i]["CountryCode"].ToString() + " : " + dt.Rows[i]["Description"].ToString());


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
            SummaryCalculate();
            if (!IsPostBack)
            {
                chkstatus = "NEW";
                Session["Edit"] = true;
                Session["Id"] = Convert.ToInt32(Request.QueryString["Id"]);
                Session["Update"] = Convert.ToString(Request.QueryString["Update"]);
                Id = Convert.ToInt32(Request.QueryString["Id"]);
                Update = Convert.ToString(Request.QueryString["Update"]);
                Id = Convert.ToInt32(Request.QueryString["Id"]);
                cargo.Visible = true;
                Inward.Visible = true;
                Outward.Visible = false;
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
                BindStorage();
                //CARGO+
                ContarinerGrid.RowDataBound += ContarinerGrid_RowDataBound;
                BindLoading();
                BindlOCATION();
                Bindreceipt();
                //invoice

                OUTWARDFlight.Visible = false;
                // OUTWARDSea.Visible = false;
                //  OUTWARDVesl.Visible = false;
                OUTWARDOther.Visible = false;


                BindInhouse();
                BindHSCode();
                BindCountry();
                BindEndUser();

                BindProduct1();
                //BindProduct2();
                //BindProduct3();
                //BindProduct4();
                //BindProduct5();
                BindLastPort();
                BindNextPort();
                SummaryCalculate();
                if (ChkRefDoc.Checked == true)
                {
                    Document.Visible = true;
                }
                else
                {
                    Document.Visible = false;
                }
                //SUM OF INVOICE
                string SumInv = "";
                string qry11aa = "select Count(InvoiceNo) as InvCount from dbo.InNonInvoiceDtl where PermitId='" + txt_code.Text + "' and MessageType='INPDEC'";
                obj.dr = obj.ret_dr(qry11aa);
                while (obj.dr.Read())
                {
                    SumInv = obj.dr[0].ToString();
                    txtnoofinv.Text = SumInv;
                }
                //SUM OF ITEM
                string SumItem = "";
                string qry112 = "select Count(ItemNo) as ItemCount from dbo.TranshipmentItemDtl where PermitId='" + txt_code.Text + "' and MessageType='INPDEC'";
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
                string qry11s2Q = "select Distinct UnitPriceCurrency,Sum(TotalLineAmount) as TotalLineAmount from dbo.TranshipmentItemDtl where PermitId='" + txt_code.Text + "' and MessageType='TNPDEC' GROUP BY UnitPriceCurrency  ORDER BY UnitPriceCurrency DESC";
                obj.dr = obj.ret_dr(qry11s2Q);
                while (obj.dr.Read())
                {
                    SumofItemAmount = obj.dr[0].ToString() + " : " + obj.dr[1].ToString();
                    Label lbl = new Label();
                    lbl.Text = SumofItemAmount;
                    //lblinvoiceAmt.Text = reader["TotalLineAmount"].ToString();
                    lbl.BackColor = System.Drawing.Color.WhiteSmoke;
                    lbl.BorderStyle = BorderStyle.Solid;
                    lbl.BorderWidth = 1;
                    lbl.Width = 200;
                    //totinvAmt = totinvAmt + "  -  " + lbl.Text + " " + Environment.NewLine;
                    div1.Controls.Add(lbl);
                    div1.Controls.Add(new LiteralControl("<br />"));
                    div2.Controls.Add(lbl);
                    div2.Controls.Add(new LiteralControl("<br />"));
                    //txtitmAmt.Text = SumofItemAmount;
                }
                //TotalGSTAmount
                string TotalGSTAmount = "";
                string qry11s2 = "select SUM(GSTAmount) as  GSTAmount  from dbo.TranshipmentItemDtl where PermitId='" + txt_code.Text + "' and MessageType='INPDEC'";
                obj.dr = obj.ret_dr(qry11s2);
                while (obj.dr.Read())
                {
                    TotalGSTAmount = obj.dr[0].ToString();
                    txttotgstAmt.Text = TotalGSTAmount;
                    txtAmtPayble.Text = TotalGSTAmount;
                }

                //Total CIF/FOB Value
                string TotalCIFFOBValue = "";
                string qry11sS2 = "select SUM(CIFFOB) as  GSTAmount  from dbo.TranshipmentItemDtl where PermitId='" + txt_code.Text + "' and MessageType='TNPDEC'";
                obj.dr = obj.ret_dr(qry11sS2);
                while (obj.dr.Read())
                {
                    TotalCIFFOBValue = obj.dr[0].ToString();
                    txtfobval.Text = TotalCIFFOBValue;

                }

                //DrpDecType_SelectedIndexChanged(null, null);
                //DrpOutwardtrasMode_SelectedIndexChanged(null, null);
                ChkSea_CheckedChanged(null, null);


                
                PermitNO();
                JobNO();
                MSGNO();
                refid();
                ItemNO();
                BindItemMaster();

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
                //Cancel
                string can = "select Id,Name from [CommonMaster] where TypeId='5' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(can);
                DrpDocumenttype.DataSource = null;
                DrpDocumenttype.DataSource = obj.dr;
                DrpDocumenttype.DataTextField = "Name";
                DrpDocumenttype.DataValueField = "Id";
                DrpDocumenttype.DataBind();
                obj.closecon();
                DrpDocumenttype.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));

                //Reason Cancel
                string aa1 = "select Id,Name +' : '+ Description AS Description from [CommonMaster] where TypeId='75' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(aa1);
                DrpReasonCancel.DataSource = obj.dr;
                DrpReasonCancel.DataTextField = "Description";
                DrpReasonCancel.DataValueField = "Id";
                DrpReasonCancel.DataBind();
                obj.closecon();
                DrpReasonCancel.Items.Insert(0, new ListItem("--Select--", "0"));
                //vessel nat


                string stqrn = "select Id,CountryCode+' : '+Description as Description from [Country]  order by Description";
                obj.dr = obj.ret_dr(stqrn);
                DroVesslNat.DataSource = obj.dr;
                DroVesslNat.DataTextField = "Description";
                DroVesslNat.DataValueField = "Id";
                DroVesslNat.DataBind();
                obj.closecon();
                DroVesslNat.Items.Insert(0, new ListItem("--Select--", "0"));

                //Country
                string stqr = "select Id, [CountryCode] +' : '+ [Description] as Description from [Country]  order by Description";
                obj.dr = obj.ret_dr(stqr);
                DrpFinalDesCountry.DataSource = obj.dr;
                DrpFinalDesCountry.DataTextField = "Description";
                DrpFinalDesCountry.DataValueField = "Id";
                DrpFinalDesCountry.DataBind();
                obj.closecon();
                DrpFinalDesCountry.Items.Insert(0, new ListItem("--Select--", "0"));

                //Declaration Type
                string str = "select Id,Name from [CommonMaster] where TypeId='18' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(str);
                DrpDecType.DataSource = obj.dr;
                DrpDecType.DataTextField = "Name";
                DrpDecType.DataValueField = "Id";
                DrpDecType.DataBind();
                obj.closecon();
                DrpDecType.Items.Insert(0, new ListItem("--Select--", "0"));

                //CargoPackType
                string str1 = "select Id,Name from [CommonMaster] where TypeId='2' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(str1);
                DrpCargoPackType.DataSource = obj.dr;
                DrpCargoPackType.DataTextField = "Name";
                DrpCargoPackType.DataValueField = "Id";
                DrpCargoPackType.DataBind();
                obj.closecon();
                DrpCargoPackType.Items.Insert(0, new ListItem("--Select--", "0"));
                //InwardtrasMode
                string str11 = "select Id,Name from [CommonMaster] where TypeId='3' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(str11);
                DrpInwardtrasMode.DataSource = obj.dr;
                DrpInwardtrasMode.DataTextField = "Name";
                DrpInwardtrasMode.DataValueField = "Id";
                DrpInwardtrasMode.DataBind();
                obj.closecon();
                DrpInwardtrasMode.Items.Insert(0, new ListItem("--Select--", "0"));

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
                string stqqrn = "select Id,CountryCode+' : '+Description as Description from [Country]  order by Description";
                obj.dr = obj.ret_dr(stqqrn);
                DroVesslNat.DataSource = obj.dr;
                DroVesslNat.DataTextField = "Description";
                DroVesslNat.DataValueField = "Id";
                DroVesslNat.DataBind();
                obj.closecon();
                DroVesslNat.Items.Insert(0, new ListItem("--Select--", "0"));

                //Optional Currency1            


                string str7w = "select Id,Name from [CommonMaster] where TypeId='9' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(str7w);
                DrpOptionalUom.DataSource = null;
                DrpOptionalUom.DataSource = obj.dr;
                DrpOptionalUom.DataTextField = "Name";
                DrpOptionalUom.DataValueField = "Name";
                DrpOptionalUom.DataBind();
                obj.closecon();
                DrpOptionalUom.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));

                //DrpOtherUOM
                string strsaa = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(strsaa);
                DrpOtherUOM.DataSource = obj.dr;
                DrpOtherUOM.DataTextField = "Name";
                DrpOtherUOM.DataValueField = "Id";
                DrpOtherUOM.DataBind();
                obj.closecon();
                DrpOtherUOM.Items.Insert(0, new ListItem("--Select--", "0"));


                //DrpMaking 
                string stra = "select Id,Name from [CommonMaster] where TypeId='12' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(stra);
                DrpMaking.DataSource = obj.dr;
                DrpMaking.DataTextField = "Name";
                DrpMaking.DataValueField = "Id";
                DrpMaking.DataBind();
                obj.closecon();
                DrpMaking.Items.Insert(0, new ListItem("--Select--", "0"));

                //DrpPreferentialCode
                string stdr = "select Id,Name from [CommonMaster] where TypeId='11' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(stdr);
                DrpPreferentialCode.DataSource = obj.dr;
                DrpPreferentialCode.DataTextField = "Name";
                DrpPreferentialCode.DataValueField = "Id";
                DrpPreferentialCode.DataBind();
                obj.closecon();
                DrpPreferentialCode.Items.Insert(0, new ListItem("--Select--", "0"));



                //TDQ
                string stri = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(stri);
                TDQUOM.DataSource = obj.dr;
                TDQUOM.DataTextField = "Name";
                TDQUOM.DataValueField = "Id";
                TDQUOM.DataBind();
                obj.closecon();
                TDQUOM.Items.Insert(0, new ListItem("--Select--", "0"));

                string stri1 = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(stri1);
                ddptotDutiableQty.DataSource = null;
                ddptotDutiableQty.DataSource = obj.dr;
                ddptotDutiableQty.DataTextField = "Name";
                ddptotDutiableQty.DataValueField = "Id";
                ddptotDutiableQty.DataBind();
                obj.closecon();
                ddptotDutiableQty.Items.Insert(0, new ListItem("--Select--", "0"));

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
                string str7 = "select  Id,Currency from [Currency] order by Currency";
                obj.dr = obj.ret_dr(str7);
                DRPCurrency.DataSource = obj.dr;
                DRPCurrency.DataTextField = "Currency";
                DRPCurrency.DataValueField = "Id";
                DRPCurrency.DataBind();
                obj.closecon();
                DRPCurrency.Items.Insert(0, new ListItem("--Select--", "0"));


                //P1
                string P1 = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(P1);
                DrpP1.DataSource = obj.dr;
                DrpP1.DataTextField = "Name";
                DrpP1.DataValueField = "Name";
                DrpP1.DataBind();
                obj.closecon();
                DrpP1.Items.Insert(0, new ListItem("--Select--", "0"));


                //P2
                string P2 = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(P2);
                DrpP2.DataSource = obj.dr;
                DrpP2.DataTextField = "Name";
                DrpP2.DataValueField = "Name";
                DrpP2.DataBind();
                obj.closecon();
                DrpP2.Items.Insert(0, new ListItem("--Select--", "0"));


                //P3
                string P3 = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(P3);
                DrpP3.DataSource = obj.dr;
                DrpP3.DataTextField = "Name";
                DrpP3.DataValueField = "Name";
                DrpP3.DataBind();
                obj.closecon();
                DrpP3.Items.Insert(0, new ListItem("--Select--", "0"));

                //P4
                string P4 = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(P4);
                DrpP4.DataSource = obj.dr;
                DrpP4.DataTextField = "Name";
                DrpP4.DataValueField = "Name";
                DrpP4.DataBind();
                obj.closecon();
                DrpP4.Items.Insert(0, new ListItem("--Select--", "0"));


                //P5
                string P5 = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(P5);
                DrpP5.DataSource = obj.dr;
                DrpP5.DataTextField = "Name";
                DrpP5.DataValueField = "Name";
                DrpP5.DataBind();
                obj.closecon();
                DrpP5.Items.Insert(0, new ListItem("--Select--", "0"));


                //vehicletype
                string vehicle = "select Id,Name from [CommonMaster] where TypeId='20' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(vehicle);
                DrpVehicleType.DataSource = obj.dr;
                DrpVehicleType.DataTextField = "Name";
                DrpVehicleType.DataValueField = "Id";
                DrpVehicleType.DataBind();
                obj.closecon();
                DrpVehicleType.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));


                //engine
                string engine = "select Id,Name from [CommonMaster] where TypeId='21' and StatusID=1 order by Name";
                obj.dr = obj.ret_dr(engine);
                DrpVehicleCapacity.DataSource = obj.dr;
                DrpVehicleCapacity.DataTextField = "Name";
                DrpVehicleCapacity.DataValueField = "Id";
                DrpVehicleCapacity.DataBind();
                obj.closecon();
                DrpVehicleCapacity.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));

                ProductCode1();
                ProductCode2();
                ProductCode3();
                ProductCode4();
                ProductCode5();


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

                //string drpv = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                //obj.dr = obj.ret_dr(drpv);
                //DroVesslNat.DataSource = obj.dr;
                //DroVesslNat.DataTextField = "Name";
                //DroVesslNat.DataValueField = "Name";
                //DroVesslNat.DataBind();
                //obj.closecon();
                //DroVesslNat.Items.Insert(0, new ListItem("--Select--", "0"));
                DrpInwardtrasMode_SelectedIndexChanged(null, null);
                //outtr.Visible = false;
                DrpOutwardtrasMode_SelectedIndexChanged(null, null);
                DrpCargoPackType_SelectedIndexChanged(null, null);

                string temp = "select PermitId from TranshipmentTemp where  PermitId='" + txt_code.Text + "' and TouchUser='" + Session["UserId"].ToString() + "'";
                obj.dr = obj.ret_dr(temp);
                while (obj.dr.Read())
                {

                    TempDataPermitNo = obj.dr["PermitId"].ToString();
                    InnonPaymentEdit();

                }
                if (Update != "")
                {
                    divamend.Visible = false;
                    divcancel.Visible = false;
                    if (string.IsNullOrWhiteSpace(Update))
                    {
                        DeclBtn.Visible = true;
                        DeclInd.Visible = true;
                        transhipsummery.Update();
                    }
                    if (Update == "AMEND")
                    {
                        divamend.Visible = true;
                        divcancel.Visible = false;
                        AmendInd.Visible = true;
                        Amendbtn.Visible = true;
                        chkstatus = "AMEND";
                        Amend.Visible = true;
                        Cancel.Visible = false;
                        // Refund.Visible = false;
                        MyClass lod12 = new MyClass();
                        lod12.dr = lod12.ret_dr("select PermitNumber from TranshipmentHeader where Id='" + Id + "'");
                        if (lod12.dr.HasRows)
                        {
                            while (lod12.dr.Read())
                            {
                                int value=0;
                                MyClass obj4 = new MyClass();
                                obj4.dr = obj4.ret_dr("select Count(PermitNumber) from TranshipmentHeader where PermitNumber='" + lod12.dr["PermitNumber"].ToString() + "' and (Status='APR' or Status='AME') and prmtStatus='AMD'");
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
                                transhipsummery.Update();
                            }
                        }
                        MyClass lod121 = new MyClass();
                        lod121.dr = lod121.ret_dr("select * from TransAmend where Permitno='" + txtamendpermit.Text + "'");
                        if (lod121.dr.HasRows)
                        {
                            while (lod121.dr.Read())
                            {
                                //txtamoundcount.Text = lod121.dr["AmendmentCount"].ToString();
                                txtupdateindicator.Text = lod121.dr["UpdateIndicator"].ToString();
                                txtamendpermit.Text = lod121.dr["Permitno"].ToString();
                                txtreplacepermit.Text = lod121.dr["ReplacementPermitno"].ToString();
                                txtdescreason.Text = lod121.dr["DescriptionOfReason"].ToString();
                                if (lod121.dr["PermitExtension"].ToString().ToUpper() == "true".ToUpper())
                                {
                                    ChkPermitvalEx.Checked = true;
                                }
                                else
                                {
                                    ChkPermitvalEx.Checked = false;
                                }
                                txtvalidity.Text = lod121.dr["ExtendImportPeriod"].ToString();
                                if (lod121.dr["DeclarationIndigator"].ToString().ToUpper() == "true".ToUpper())
                                {
                                    chkdec.Checked = true;
                                }
                                else
                                {
                                    chkdec.Checked = false;
                                }
                            }
                        }
                        transhipamend.Update();
                    }
                    if (Update == "CANCEL")
                    {
                        divamend.Visible = false;
                        divcancel.Visible = true;

                        CancelInd.Visible = true;
                        CancelBtn.Visible = true;
                        chkstatus = "CANCEL";
                        Cancel.Visible = true;
                        Amend.Visible = false;
                        MyClass lod12 = new MyClass();
                        lod12.dr = lod12.ret_dr("select PermitNumber from TranshipmentHeader where Id='" + Id + "'");
                        if (lod12.dr.HasRows)
                        {
                            while (lod12.dr.Read())
                            {
                                txtcanPermit.Text = lod12.dr["PermitNumber"].ToString();
                                txtupdateInd.Text = "CNL";
                                transhipsummery.Update();
                            }
                        }
                        lod12.dr = lod12.ret_dr("select * from TransCancel where Permitno='" + txtcanPermit.Text + "'");
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
                    }
                    transhipcancelcancel.Update();
                }
                if (Id != 0)
                {
                    InnonPaymentEdit();                                        
                    return;
                }
                else
                {
                }
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
            //        ContainerDetails.Visible = true;
            //    }

            //    else if (TextMode.Text == "4 : Air")
            //    {
            //        InwardFlight.Visible = true;
            //        ContainerDetails.Visible = true;
            //    }
            //}

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
            //        //ContainerDetails.Visible = true;
            //    }

            //    else if (TxtExpMode.Text == "4 : Air")
            //    {
            //        OUTWARDFlight.Visible = true;
            //        //ContainerDetails.Visible = true;
            //    }
            //}


            ChkPackInfo_CheckedChanged(null, null);
                Chkitemcasc_CheckedChanged(null, null);
            Chklot_CheckedChanged(null, null);
            ChkTariff_CheckedChanged(null, null);


            AddItemSummary();
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
            SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,ContainerNo as Column1, Size as Column2,Weight as Column3, SealNo as Column4 from TranshipmentHeader a,TranshipmentContainerDtl b where a.PermitId=b.PermitId and a.PermitId='" + txt_code.Text + "' order by RowNo", con);
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


            //SqlConnection con = new SqlConnection(sqlconn);
            ////SqlCommand cmd1 = new SqlCommand("SELECT T1.Id ,T1.CRP,T1.CompanyName,T1.Name,T1.EmailId,T1.Mobile, T2.Name as Rent ,t1.BudgetFrom,T1.BudgetTo ,T3.Name as Type,T4.Name as Location,T5.PropertyRef,T1.MultipleLocation,T1. MultipleProperty  FROM (select a.Id,a.CompanyName,a.Name,a.EmailId,a.Mobile,a.BudgetFrom,a.BudgetTo,b.Name as CRP,a.MultipleLocation,a.MultipleProperty  from lead a,CommonMaster b where a.Per_Com=b.Id and a.TouchUser='" + Touch_user + "') AS T1 JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.RentorBuy=b.Id) AS T2    ON T1.Id = T2.Id    JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Type=b.Id) AS T3  ON T1.Id = T3.Id     JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Location=b.Id) AS T4   ON T1.Id = T4.Id    JOIN ( select b.ID,b.Name,a.PropertyRef  from Lead_List a,Lead b where a.ParentId=b.Id) AS T5   ON T1.Id = T5.Id order by T1.Id desc", con);
            //SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,ContainerNo as Column1, Size as Column2,Weight as Column3, SealNo as Column4 from InHeaderTbl a,TranshipmentContainerDtl b where a.PermitId=b.PermitId and a.PermitId='" + txt_code.Text + "'", con);
            //SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            //DataTable dt = new DataTable();
            //sda1.Fill(dt);
            //ViewState["Container"] = dt;
            //ContarinerGrid.DataSource = ViewState["Container"] as DataTable;
            //ContarinerGrid.DataBind();
            //int rowIndex = 0;
            //if (ViewState["Container"] != null)
            //{
            //    DataTable dt1 = (DataTable)ViewState["Container"];
            //    if (dt.Rows.Count > 0)
            //    {
            //        for (int i = 0; i < dt1.Rows.Count; i++)
            //        {

            //            TextBox box1 = (TextBox)ContarinerGrid.Rows[rowIndex].Cells[1].FindControl("txt1");
            //            DropDownList drp1 = (DropDownList)ContarinerGrid.Rows[rowIndex].Cells[1].FindControl("DrpType");
            //            TextBox box2 = (TextBox)ContarinerGrid.Rows[rowIndex].Cells[2].FindControl("txt2");
            //            TextBox box3 = (TextBox)ContarinerGrid.Rows[rowIndex].Cells[3].FindControl("txt3");
            //            box1.Text = dt.Rows[i]["Column1"].ToString();
            //            drp1.ClearSelection();
            //            drp1.Items.FindByText(dt.Rows[i]["Column2"].ToString()).Selected = true;

            //            //  drp1.SelectedValue = dt.Rows[i]["Column2"].ToString();
            //            box2.Text = dt.Rows[i]["Column3"].ToString();
            //            box3.Text = dt.Rows[i]["Column4"].ToString();
            //            rowIndex++;

            //        }
            //    }
            //}



        }

        private void editCPCAEO()
        {
            string qry = "select RowNo as RowNumber,ProcessingCode1,ProcessingCode2,ProcessingCode3 from TranshipmentHeader a,TranshipmentCPCDtl b where a.PermitId=b.PermitId and a.PermitId='" + txt_code.Text + "' and b.CPCType='AEO'";
            SqlConnection con = new SqlConnection(sqlconn);
            //SqlCommand cmd1 = new SqlCommand("SELECT T1.Id ,T1.CRP,T1.CompanyName,T1.Name,T1.EmailId,T1.Mobile, T2.Name as Rent ,t1.BudgetFrom,T1.BudgetTo ,T3.Name as Type,T4.Name as Location,T5.PropertyRef,T1.MultipleLocation,T1. MultipleProperty  FROM (select a.Id,a.CompanyName,a.Name,a.EmailId,a.Mobile,a.BudgetFrom,a.BudgetTo,b.Name as CRP,a.MultipleLocation,a.MultipleProperty  from lead a,CommonMaster b where a.Per_Com=b.Id and a.TouchUser='" + Touch_user + "') AS T1 JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.RentorBuy=b.Id) AS T2    ON T1.Id = T2.Id    JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Type=b.Id) AS T3  ON T1.Id = T3.Id     JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Location=b.Id) AS T4   ON T1.Id = T4.Id    JOIN ( select b.ID,b.Name,a.PropertyRef  from Lead_List a,Lead b where a.ParentId=b.Id) AS T5   ON T1.Id = T5.Id order by T1.Id desc", con);
            SqlCommand cmd1 = new SqlCommand(qry, con);
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            //if (dt.Rows.Count > 0)
            //{
            //    //if (!string.IsNullOrWhiteSpace(dt.Rows[0]["RowNo"].ToString()))
            //    //{
            //    //    if (Convert.ToDecimal(dt.Rows[0]["RowNo"].ToString()) > 0)
            //    //    {
            //            AEO.Visible = true;
            //    //    }
            //    //}
            //}
            //    else
            //    {
            //        AEO.Visible = false;
            //    }


            //ViewState["CurrentTable"] = dt;

            //int rowIndex = 0;
            //if (ViewState["CurrentTable"] != null)
            //{
            //    DataTable dt1 = (DataTable)ViewState["CurrentTable"];
            //    if (dt1.Rows.Count > 0)
            //    {
            //        for (int i = 0; i < dt1.Rows.Count; i++)
            //        {
            //            TextBox box1 = (TextBox)ProductCode1Grid1.Rows[rowIndex].Cells[1].FindControl("TextBox1");
            //            TextBox box2 = (TextBox)ProductCode1Grid1.Rows[rowIndex].Cells[2].FindControl("TextBox2");
            //            TextBox box3 = (TextBox)ProductCode1Grid1.Rows[rowIndex].Cells[3].FindControl("TextBox3");
            //            box1.Text = dt1.Rows[i]["ProcessingCode1"].ToString();
            //            box2.Text = dt1.Rows[i]["ProcessingCode2"].ToString();
            //            box3.Text = dt1.Rows[i]["ProcessingCode3"].ToString();
            //            rowIndex++;
            //        }
            //    }
            //}
            if (dt.Rows.Count <= 0)
            {
                DataRow newRow = dt.NewRow();
                newRow["RowNumber"] = 1; // Set initial sequence
                newRow["ProcessingCode1"] = string.Empty;
                newRow["ProcessingCode2"] = string.Empty;
                newRow["ProcessingCode3"] = string.Empty;
                dt.Rows.Add(newRow);
            }
            else
            {
                chkaeo.Checked = true;
                chkaeo_CheckedChanged(null, null);
            }
            ViewState["ContainerAEO"] = dt;
            ViewState["CurrentTable"] = dt;
            int rowIndex = 0;
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
                chkaeo.Checked = false;
            }
            else
            {
                chkaeo.Checked = true;
            }


            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt1 = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
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
            transhipcpc.Update();
        }
        private void editCPCcwc()
        {
            string qry = "select RowNo as RowNumber,ProcessingCode1,ProcessingCode2,ProcessingCode3 from TranshipmentHeader a,TranshipmentCPCDtl b where a.PermitId=b.PermitId and a.PermitId='" + txt_code.Text + "' and b.CPCType='STS' ";
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
            else
            {
                chkcwc.Checked = true;
                chkcwc_CheckedChanged(null, null);
            }
            ViewState["Containercwc"] = dt;
            ViewState["CurrentTable1"] = dt;
            int rowIndex = 0;
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
            }
            else
            {
                chkcwc.Checked = true;
            }


            if (ViewState["CurrentTable1"] != null)
            {
                DataTable dt1 = (DataTable)ViewState["CurrentTable1"];
                if (dt.Rows.Count > 0)
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
            transhipcpc.Update();
            //SqlConnection con = new SqlConnection(sqlconn);
            ////SqlCommand cmd1 = new SqlCommand("SELECT T1.Id ,T1.CRP,T1.CompanyName,T1.Name,T1.EmailId,T1.Mobile, T2.Name as Rent ,t1.BudgetFrom,T1.BudgetTo ,T3.Name as Type,T4.Name as Location,T5.PropertyRef,T1.MultipleLocation,T1. MultipleProperty  FROM (select a.Id,a.CompanyName,a.Name,a.EmailId,a.Mobile,a.BudgetFrom,a.BudgetTo,b.Name as CRP,a.MultipleLocation,a.MultipleProperty  from lead a,CommonMaster b where a.Per_Com=b.Id and a.TouchUser='" + Touch_user + "') AS T1 JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.RentorBuy=b.Id) AS T2    ON T1.Id = T2.Id    JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Type=b.Id) AS T3  ON T1.Id = T3.Id     JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Location=b.Id) AS T4   ON T1.Id = T4.Id    JOIN ( select b.ID,b.Name,a.PropertyRef  from Lead_List a,Lead b where a.ParentId=b.Id) AS T5   ON T1.Id = T5.Id order by T1.Id desc", con);
            //SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,ProcessingCode1,ProcessingCode2,ProcessingCode3 from TranshipmentHeader a,TranshipmentCPCDtl b where a.PermitId=b.PermitId and b.CPCType='CWC' and a.PermitId='" + txt_code.Text + "'", con);
            //SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            //DataTable dt = new DataTable();
            //sda1.Fill(dt);
            //if (dt.Rows.Count <= 0)
            //{
            //    dt.Rows.Add();
            //}
            //else
            //{
            //    chkcwc.Checked = true;
            //    chkcwc_CheckedChanged(null, null);
            //}
            //ViewState["CurrentTable"] = dt;
            //int rowIndex = 0;
            //CWCGrid.DataSource = ViewState["CurrentTable"] as DataTable;
            //CWCGrid.DataBind();
            //if (ViewState["CurrentTable1"] != null)
            //{
            //    DataTable dt1 = (DataTable)ViewState["CurrentTable1"];
            //    if (dt1.Rows.Count > 0)
            //    {
            //        for (int i = 0; i < dt1.Rows.Count; i++)
            //        {
            //            TextBox box1 = (TextBox)CWCGrid.Rows[rowIndex].Cells[1].FindControl("TextBox1");
            //            TextBox box2 = (TextBox)CWCGrid.Rows[rowIndex].Cells[2].FindControl("TextBox2");
            //            TextBox box3 = (TextBox)CWCGrid.Rows[rowIndex].Cells[3].FindControl("TextBox3");
            //            box1.Text = dt1.Rows[i]["ProcessingCode1"].ToString();
            //            box2.Text = dt1.Rows[i]["ProcessingCode2"].ToString();
            //            box3.Text = dt1.Rows[i]["ProcessingCode3"].ToString();
            //            rowIndex++;
            //        }
            //    }
            //}
            //transhipcpc.Update();
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
        private void editCPCSEASTORE()
        {
            string qry = "select RowNo as RowNumber,ProcessingCode1,ProcessingCode2,ProcessingCode3 from TranshipmentHeader a,TranshipmentCPCDtl b where a.PermitId=b.PermitId and a.PermitId='" + txt_code.Text + "' and b.CPCType='SEASTORE' ";
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
            else
            {
                ChkSea1.Checked = true;
                ChkSea1_CheckedChanged(null, null);
            }
            ViewState["ContainerSEASTORE"] = dt;
            ViewState["CurrentTable2"] = dt;
            int rowIndex = 0;
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
            }
            else
            {
                ChkSea1.Checked = true;
            }
            if (ViewState["CurrentTable2"] != null)
            {
                DataTable dt1 = (DataTable)ViewState["CurrentTable2"];
                if (dt.Rows.Count > 0)
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
            transhipcpc.Update();
        }      

        private void EditDocument()
        {

            const int maxTotalSizeKB = 20000;
            long totalKB = 0;

            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT Id, DocumentType, Name, FileSizeKB FROM transhipfile WHERE InPaymentId = @InPaymentId";
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

            //vessel nat
            string stqrn = "select Id,CountryCode+' : '+Description as Description from [Country]  order by Description";
            obj.dr = obj.ret_dr(stqrn);
            DroVesslNat.DataSource = obj.dr;
            DroVesslNat.DataTextField = "Description";
            DroVesslNat.DataValueField = "Id";
            DroVesslNat.DataBind();
            obj.closecon();
            DroVesslNat.Items.Insert(0, new ListItem("--Select--", "0"));


            string DecCompany, Importer, inwardcarrier, ff, climant, Exporter, outward, EndUser,iteminobl="",itemoutobl = "";
            string strBindTxtBox = "";
            if (TempDataPermitNo != "")
            {
                strBindTxtBox = "select * from [TranshipmentTemp] where PermitID='" + TempDataPermitNo + "' and TouchUser='" + Session["UserId"].ToString() + "'";
            }
            else
            {
                strBindTxtBox = "select * from [TranshipmentHeader] where Id=" + Id;
            }

            //string strBindTxtBox = "select * from [TranshipmentHeader] where Id=" + Id;
            obj.dr = obj.ret_dr(strBindTxtBox);
            while (obj.dr.Read())
            {
                //premStatuschk = obj.dr["prmtStatus"].ToString();
                refno = obj.dr["Refid"].ToString();
                JobNo = obj.dr["JobId"].ToString();
                MsgNO = obj.dr["MSGId"].ToString();
                txt_code.Text = obj.dr["PermitId"].ToString();
                //TxtTradeMailID.Text = obj.dr["TradeNetMailboxID"].ToString();
                TxtMsgType.Text = obj.dr["MessageType"].ToString();
                TxtPrevPerNO.Text = obj.dr["PreviousPermit"].ToString();
                string dd = obj.dr["DeclarationType"].ToString();
                DrpDecType.ClearSelection();
                DrpDecType.Items.FindByText(obj.dr["DeclarationType"].ToString()).Selected = true;
                DrpCargoPackType.ClearSelection();
                DrpCargoPackType.Items.FindByText(obj.dr["CargoPackType"].ToString()).Selected = true;
                DrpCargoPackType_SelectedIndexChanged(null, null);
                DrpInwardtrasMode.ClearSelection();

                DrpInwardtrasMode.Items.FindByText(obj.dr["InwardTransportMode"].ToString()).Selected = true;
                DrpOutwardtrasMode.ClearSelection();

                DrpOutwardtrasMode.Items.FindByText(obj.dr["OutwardTransportMode"].ToString()).Selected = true;
                DrpBGIndicator.ClearSelection();

                DrpBGIndicator.Items.FindByText(obj.dr["BGIndicator"].ToString()).Selected = true;
                // DrpBGIndicator.SelectedItem.Text = obj.dr[9].ToString();
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

                string cnb = obj.dr["ReferenceDocuments"].ToString();
                if (cnb == "True" || cnb == "true")
                {
                    chkcnb.Checked = true;
                }
                else if (cnb == "False" || cnb == "false")
                {
                    chkcnb.Checked = false;
                }

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
                TxtRECPT1.Text = splitLicence[0].ToString();
                TxtRECPT2.Text = splitLicence[1].ToString();
                TxtRECPT3.Text = splitLicence[2].ToString();


                TextMode.Text = obj.dr["InwardTransportMode"].ToString();


                TxtArrivalDate1.Text = Convert.ToDateTime(obj.dr["ArrivalDate"].ToString()).ToString("dd/MM/yyyy");

                TxtLoadShort.Text = obj.dr["LoadingPortCode"].ToString();


                TxtVoyageno.Text = obj.dr["VoyageNumber"].ToString();
                TxtVesselName.Text = obj.dr["VesselName"].ToString();
                TxtOceanBill.Text = obj.dr["OceanBillofLadingNo"].ToString();
                TxtConRefNo.Text = obj.dr["ConveyanceRefNo"].ToString();
                TxtTrnsID.Text = obj.dr["TransportId"].ToString();
                txtflight.Text = obj.dr["FlightNO"].ToString();
                txtaircraft.Text = obj.dr["AircraftRegNo"].ToString();
                txtwaybill.Text = obj.dr["MasterAirwayBill"].ToString();

                txtreLoctn.Text = obj.dr["ReleaseLocation"].ToString();
                //txtrelocDeta.Text = obj.dr["ReleaseLocName"].ToString();

                txtrecloctn.Text = obj.dr["RecepitLocation"].ToString();
                //txtrecloctndet.Text = obj.dr["RecepitLocName"].ToString();
                TxtStorageShort.Text = obj.dr["StorageLocation"].ToString();

                BlankDate1.Text = Convert.ToDateTime(obj.dr["RemovalStartDate"].ToString()).ToString("dd/MM/yyyy");

                TxtExpArrivalDate1.Text = Convert.ToDateTime(obj.dr["DepartureDate"].ToString()).ToString("dd/MM/yyyy");

                //DepatureDate.Value = obj.dr[37].ToString();
                TxtExpLoadShort.Text = obj.dr["DischargePort"].ToString();

                DrpFinalDesCountry.ClearSelection();
                DrpFinalDesCountry.SelectedItem.Text = obj.dr["FinalDestinationCountry"].ToString();

                OUTWARDVoyageNo.Text = obj.dr["OutVoyageNumber"].ToString();
                OUTWARDVessel.Text = obj.dr["OutVesselName"].ToString();
                OUTWARDOcenbill.Text = obj.dr["OutOceanBillofLadingNo"].ToString();
                //ddpVessel.SelectedItem.Text = obj.dr[40].ToString();
                DrpFinalDesCountry.ClearSelection();
                ddpVessel.Items.FindByText(obj.dr["VesselType"].ToString()).Selected = true;
                txtvesnet.Text = obj.dr["VesselNetRegTon"].ToString();
                //DroVesslNat.SelectedItem.Text = obj.dr[43].ToString();
                txtintremrk.Text = obj.dr["InternalRemarks"].ToString();
                txttrdremrk.Text = obj.dr["TradeRemarks"].ToString();
                txtvesnet.Text = obj.dr["VesselNetRegTon"].ToString();

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
                //DrptotalOuterPack.SelectedItem.Text = obj.dr[32].ToString();
                TxtTotalGrossWeight.Text = obj.dr["TotalGrossWeight"].ToString();
                DrpTotalGrossWeight.ClearSelection();
                DrpTotalGrossWeight.Items.FindByText(obj.dr["TotalGrossWeightUOM"].ToString()).Selected = true;
                // DrpTotalGrossWeight.SelectedItem.Text = obj.dr[34].ToString();
                TxtGrossReference.Text = obj.dr["GrossReference"].ToString();                

                //   BlankDate1.Text= obj.dr[36].ToString();

                DecCompany = obj.dr["DeclarantCompanyCode"].ToString();
                Importer = obj.dr["ImporterCompanyCode"].ToString();
                Exporter = obj.dr["HandlingAgentCode"].ToString();
                inwardcarrier = obj.dr["InwardCarrierAgentCode"].ToString();
                outward = obj.dr["OutwardCarrierAgentCode"].ToString();
                EndUser = obj.dr["EndUserCode"].ToString();
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

                

                string inhbl = "select * from [TranshipmentItemDtl] where PermitId='" + txt_code.Text + "'";
                obj.dr = obj.ret_dr(inhbl);
                while (obj.dr.Read())
                {

                    iteminobl= obj.dr["InMAWBOBL"].ToString();
                    itemoutobl = obj.dr["OutMAWBOBL"].ToString();

                   lblhblValue.Text = obj.dr["InHAWBOBL"].ToString();;
                   lblouthbl.Text   = obj.dr["OutHAWBOBL"].ToString(); ;
                }

                string [] jhbl=dd.Split(':');
                if (jhbl[0].ToString() != "TTF " || jhbl[0].ToString() != "TTI ")
                {
                    lbloblval.Text = TxtOceanBill.Text;
                    lbloutobl.Text = OUTWARDOcenbill.Text;
                }
                else
                {
                    lbloblval.Text = iteminobl;
                    lbloutobl.Text = itemoutobl;
                }

                string imp = "select * from [Importer] where Code='" + Importer + "'";
                obj.dr = obj.ret_dr(imp);
                while (obj.dr.Read())
                {
                    TxtImpCode.Text = obj.dr[1].ToString();
                    TxtImpName.Text = obj.dr[2].ToString();
                    TxtImpName1.Text = obj.dr[3].ToString();
                    TxtImpCRUEI.Text = obj.dr[4].ToString();

                    lblimporterparty.Text = obj.dr[4].ToString() + " - " + obj.dr[2].ToString() + " - " + obj.dr[3].ToString();


                }
                string Exp = "select * from [HandingAgent] where Code='" + Exporter + "'";
                obj.dr = obj.ret_dr(Exp);
                while (obj.dr.Read())
                {
                    TxtExpCode.Text = obj.dr["Code"].ToString();
                    TxtExpName.Text = obj.dr["Name"].ToString();
                    TxtExpName1.Text = obj.dr["Name1"].ToString();
                    TxtExpCRUEI.Text = obj.dr["CRUEI"].ToString();

                    LblHandAgent.Text = obj.dr["CRUEI"].ToString() + " - " + obj.dr["Name"].ToString() + " - " + obj.dr["Name1"].ToString();
                }
                string invc = "select * from [transInwardcarrier] where Code='" + inwardcarrier + "'";
                obj.dr = obj.ret_dr(invc);
                while (obj.dr.Read())
                {
                    InwardCode.Text = obj.dr["Code"].ToString();
                    InwardName.Text = obj.dr["Name"].ToString();
                    InwardName1.Text = obj.dr["Name1"].ToString();
                    InwardCRUEI.Text = obj.dr["CRUEI"].ToString();
                }
                string outw = "select * from [transOutward] where Code='" + outward + "'";
                obj.dr = obj.ret_dr(outw);
                while (obj.dr.Read())
                {
                    OutwardCode.Text = obj.dr["Code"].ToString();
                    OutwardName.Text = obj.dr["Name"].ToString();
                    OutwardName1.Text = obj.dr["Name1"].ToString();
                    OutwardCRUEI.Text = obj.dr["CRUEI"].ToString();
                }

                string ff1 = "select * from [transfreight] where Code='" + ff + "'";
                obj.dr = obj.ret_dr(ff1);
                while (obj.dr.Read())
                {
                    FrieghtCode.Text = obj.dr["Code"].ToString();
                    FrieghtName.Text = obj.dr["Name"].ToString();
                    FrieghtName1.Text = obj.dr["Name1"].ToString();
                    FrieghtCRUEI.Text = obj.dr["CRUEI"].ToString();
                }


                string cli = "select * from [transConsignee] where ConsigneeCode='" + climant + "'";
                obj.dr = obj.ret_dr(cli);
                while (obj.dr.Read())
                {
                    ConsigneeCode.Text = obj.dr["ConsigneeCode"].ToString();
                    ConsigneeName.Text = obj.dr["ConsigneeName"].ToString();
                    ConsigneeName1.Text = obj.dr["ConsigneeName1"].ToString();
                    ConsigneeCRUEI.Text = obj.dr["ConsigneeCRUEI"].ToString();
                    ConsigneeAddress.Text = obj.dr["ConsigneeAddress"].ToString();

                    ConsigneeAddress1.Text = obj.dr["ConsigneeAddress"].ToString();
                    ConsigneeCity.Text = obj.dr["ConsigneeCity"].ToString();
                    ConsigneeSub.Text = obj.dr["ConsigneeSub"].ToString();
                    ConsigneeSubDivi.Text = obj.dr["ConsigneeSubDivi"].ToString();
                    ConsigneePostal.Text = obj.dr["ConsigneePostal"].ToString();
                    ConsigneeCountry.Text = obj.dr["ConsigneeCountry"].ToString();

                }

                string t = "select * from [transEnduser] where EndUserCode='" + EndUser + "'";
                obj.dr = obj.ret_dr(t);
                while (obj.dr.Read())
                {
                    EndUserCode.Text = obj.dr["EndUserCode"].ToString();
                    EndUserName.Text = obj.dr["EndUserName"].ToString();
                    EndUserName1.Text = obj.dr["EndUserName1"].ToString();
                    EndUserCrueo.Text = obj.dr["EndUserCRUEI"].ToString();
                    EndUserAddress.Text = obj.dr["EndUserAddress"].ToString();

                    EndUserAddress1.Text = obj.dr["EndUserAddress1"].ToString();
                    EndUserCity.Text = obj.dr["EndUserCity"].ToString();
                    EndUserSubCodeDivi.Text = obj.dr["EndUserSubDivi"].ToString();
                    EndUserSubCode.Text = obj.dr["EndUserSub"].ToString();

                    EndUserPostal.Text = obj.dr["EndUserPostal"].ToString();
                    EndUserCountry.Text = obj.dr["EndUserCountry"].ToString();
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

                BindItemMaster();
                //edit = true;
            }
            editcontainer();
            
            editCPCAEO();
            editCPCcwc();
            editCPCSEASTORE();
            editCPCIcstore();
            editCPCSchemestore();
            editCPCStsstore();
            editCPCStscwcstore();
            
            TxtStorageShort_TextChanged(null, null);
            ChkRefDoc_CheckedChanged(null, null);
            TxtLoadShort_TextChanged(null, null);
            //txtreLoctn_TextChanged(null, null);
            //txtrecloctn_TextChanged(null, null);
            TxtCountryItem_TextChanged(null,null);
            
            TxtExpLoadShort_TextChanged(null, null);
            txtNextprt_TextChanged(null, null);
            txtLasPrt_TextChanged(null, null);
            
            //DrpInwardtrasMode_SelectedIndexChanged(null, null);
           
            DrpOutwardtrasMode_SelectedIndexChanged(null, null);
            TxtExpCode_TextChanged(null, null);
            
            TxtImpCode_TextChanged(null, null);
            TxtOceanBill_TextChanged(null, null);
              
            DrpCargoPackType_SelectedIndexChanged(null, null);
            OUTWARDOcenbill_TextChanged(null, null);
            
            DrptotalOuterPack_SelectedIndexChanged(null, null);
            DrpTotalGrossWeight_SelectedIndexChanged(null, null);
            AddItemSummary();
            ItemNO();
            
            transhipment.Update();

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
            const int maxTotalSizeKB = 20000;
            long totalKB = 0;

            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT Id, DocumentType, Name, FileSizeKB FROM transhipfile WHERE InPaymentId = @InPaymentId";
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
                using (SqlCommand cmd = new SqlCommand("SELECT Id,DocumentType,Name FROM TranscANFile where InPaymentId='" + txt_code.Text + "' "))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
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
            TxtLicense1.Focus();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();

            string strDelete = "delete from TempFileUpload where Id='" + id + "' ";
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
                SqlCommand cmd = new SqlCommand("DELETE FROM transhipfile where ID=" + employeeId, con);
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
                using (SqlCommand cmd = new SqlCommand("SELECT Id,Code,Name,Name1,CRUEI FROM DeclarantCompany where AccountID='" + Session["AccountId"].ToString() + "'"))
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
            popuptransdec.Show();
           

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
            TxtImpCode.Focus();
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
        private void BindImport()
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
                        using (DataTable dt = new DataTable())
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
            _objdt = GetImportDataFromDataBase(ImporterSearch.Text);
            if (_objdt.Rows.Count > 0)
            {
                ImporterGrid.DataSource = _objdt;
                ImporterGrid.DataBind();
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalImport();", true);
            }

        }

        protected void ImporterGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ImporterGrid.PageIndex = e.NewPageIndex;
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalImport();", true);
            BindImport();
            popuptransimp.Show();
          

        }

        protected void BtnImpADD_Click(object sender, EventArgs e)
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
            TxtExpCode.Focus();
        }
        public DataTable GetImportDataFromDataBase(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = ImporterSearch.Text;

            string str3 = "SELECT Id,Code,Name,Name1,CRUEI FROM Importer where Code Like '%" + ImporterSearch.Text.Replace("'", "''") + "%' order by Id desc";
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

                string qry11 = "select * from Importer where Code='" + ss[0].ToString().Replace("'", "''") + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {


                    TxtImpCode.Text = obj.dr[1].ToString();
                    TxtImpName.Text = obj.dr[2].ToString();
                    TxtImpName1.Text = obj.dr[3].ToString();
                    TxtImpCRUEI.Text = obj.dr[4].ToString();
                    lblimporterparty.Text = obj.dr[4].ToString() + " - " + obj.dr[2].ToString() + "" + obj.dr[3].ToString();
                }
            }
            else
            {
                TxtImpCode.Text = "";
                TxtImpName.Text = "";
                TxtImpName1.Text = "";
                TxtImpCRUEI.Text = "";
                lblimporterparty.Text = "";
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
                using (SqlCommand cmd = new SqlCommand("SELECT Id,Code,Name,Name1,CRUEI FROM transInwardcarrier"))
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
            _objdt = GetInwardDataFromDataBase(InwardSearch.Text.Replace("'", "''"));
            if (_objdt.Rows.Count > 0)
            {
                InwardGrid.DataSource = _objdt;
                InwardGrid.DataBind();
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalInward();", true);
            }
        }

        protected void InwardGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            InwardGrid.PageIndex = e.NewPageIndex;
            //  ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalInward();", true);
            BindInward();
            popuptransinw.Show();
          
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
            OutwardCode.Focus();
        }

        protected void InwardAdd_Click(object sender, EventArgs e)
        {
            string Code = "";
            string qry11 = "SELECT Code FROM transInwardcarrier where Code='" + InwardCode.Text.Replace("'", "''") + "'";

            obj.dr = obj.ret_dr(qry11);

            while (obj.dr.Read())
            {
                Code = obj.dr[0].ToString();

            }
            if (Code == "")
            {
                string Touch_user = Session["UserId"].ToString();

                string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string StrQuery = ("INSERT INTO [dbo].[transInwardcarrier] ([Code],[Name],[Name1],[CRUEI],[TouchUser],[TouchTime]) VALUES ('" + InwardCode.Text.Replace("'", "''") + "','" + InwardName.Text.Replace("'", "''") + "','" + InwardName1.Text.Replace("'", "''") + "','" + InwardCRUEI.Text.Replace("'", "''") + "','" + Touch_user + "',Convert(VARCHAR,'" + strTime + "',108))");
                obj.exec(StrQuery);
                BindInward();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : Data Saved Successfully');", true);
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

            string str3 = "SELECT Id,Code,Name,Name1,CRUEI FROM transInwardcarrier where Code Like '%" + InwardSearch.Text.Replace("'", "''") + "%' order by Id desc";
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
                string qry11 = "select * from transInwardcarrier where Code='" + ss[0].ToString().Replace("'", "''") + "'";
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
            OutwardCode.Focus();
        }
        //freight 
        private void BindFrieght()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id,Code,Name,Name1,CRUEI FROM transfreight"))
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
                //   ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalfright();", true);
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
            ConsigneeCode.Focus();
        }

        protected void BtnFrieghtAdd_Click(object sender, EventArgs e)
        {
            string Code = "";
            string qry11 = "SELECT Code FROM transfreight where Code='" + FrieghtCode.Text.Replace("'", "''") + "'";

            obj.dr = obj.ret_dr(qry11);

            while (obj.dr.Read())
            {
                Code = obj.dr[0].ToString();

            }
            if (Code == "")
            {
                string Touch_user = Session["UserId"].ToString();

                string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string StrQuery = ("INSERT INTO [dbo].[transfreight] ([Code],[Name],[Name1],[CRUEI],[TouchUser],[TouchTime]) VALUES ('" + FrieghtCode.Text.Replace("'", "''") + "','" + FrieghtName.Text.Replace("'", "''") + "','" + FrieghtName1.Text.Replace("'", "''") + "','" + FrieghtCRUEI.Text.Replace("'", "''") + "','" + Touch_user + "',Convert(VARCHAR,'" + strTime + "',108))");
                obj.exec(StrQuery);
                BindFrieght();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : Data Saved Successfully');", true);
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

            string str3 = "SELECT Id,Code,Name,Name1,CRUEI FROM transfreight where Code Like '%" + FrieghtSearch.Text.Replace("'", "''") + "%' order by Id desc";
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
                string qry11 = "select * from transfreight where Code='" + ss[0].ToString().Replace("'", "''") + "'";
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
            //  ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalfright();", true);
            BindFrieght();
            popuptransfreight.Show();
            

        }

        //cargo
        protected void TextMode_TextChanged(object sender, EventArgs e)
        {
            if (TextMode.Text != "")
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
                //Response.Write("ViewState is null");
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
            //  ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalLoading();", true);
            BindLoading();
            popuptransloadingport.Show();
          
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
                if (TextMode.Text == "1 : Sea")
                {
                    TxtVoyageno.Focus();
                }
                else if (TextMode.Text == "2 : Rail" || TextMode.Text == "3 : Road" || TextMode.Text == "5 : Mail" || TextMode.Text == "7 : Pipeline" || TextMode.Text == "N : Not Required" || TextMode.Text == "6 : Multi-model(Not in use)")
                {
                    TxtConRefNo.Focus();
                }

                else if (TextMode.Text == "4 : Air")
                {
                    txtflight.Focus();
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
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openLocation();", true);
            }
        }

        protected void LocationGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LocationGrid.PageIndex = e.NewPageIndex;
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openLocation();", true);
            BindlOCATION();
            popuptransreleaseloc.Show();
            
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
            txtrecloctn.Focus();
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
                string qry11 = "select * from ReleaseLocation where Code='" + ss[0].ToString().Replace("'", "''") + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    txtreLoctn.Text = obj.dr[2].ToString();
                    txtrelocDeta.Text = obj.dr[3].ToString();
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
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openReceipt();", true);
            }
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
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openReceipt();", true);
            Bindreceipt();
            popuptransrecloc.Show();
            
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
            TxtStorageShort.Focus();
        }

        protected void txtrecloctn_TextChanged(object sender, EventArgs e)
        {
            if (txtrecloctn.Text != "")
            {
                string[] ss = txtrecloctn.Text.Split(':');

                string qry11 = "select * from ReleaseLocation where Code='" + ss[0].ToString().Replace("'", "''") + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    txtrecloctn.Text = obj.dr[2].ToString();
                    txtrecloctndet.Text = obj.dr[3].ToString();
                }
            }
            else
            {
                txtrecloctn.Text = "";
                txtrecloctndet.Text = "";
            }
            TxtStorageShort.Focus();
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
                string qry11 = "select * from LoadingPort where PortCode='" + ss[0].ToString() + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    TxtLoadShort.Text = obj.dr["PortCode"].ToString();
                    TxtLoad.Text = obj.dr["PortName"].ToString();

                }
                if (TextMode.Text == "1 : Sea")
                {
                    TxtVoyageno.Focus();
                }
                else if (TextMode.Text == "2 : Rail" || TextMode.Text == "3 : Road" || TextMode.Text == "5 : Mail" || TextMode.Text == "7 : Pipeline" || TextMode.Text == "N : Not Required" || TextMode.Text == "6 : Multi-model(Not in use)")
                {
                    TxtConRefNo.Focus();
                }

                else if (TextMode.Text == "4 : Air")
                {
                    txtflight.Focus();
                }
            }
            else
            {
                TxtLoadShort.Text = "";
                TxtLoad.Text = "";
            }
        }
        //invoice

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

            dr["RowNumber"] = 1;

            dr["ProcessingCode1"] = string.Empty;

            dr["ProcessingCode2"] = string.Empty;

            dr["ProcessingCode3"] = string.Empty;

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

            foreach (HttpPostedFile postedFile in FileUpload1.PostedFiles)
            {
                string filename = Path.GetFileName(postedFile.FileName);
                string fileExtension = Path.GetExtension(filename).ToLower();
                string contentType = postedFile.ContentType.ToLower();

                // Validate file extension
                if (!allowedExtensions.Contains(fileExtension))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        $"alert('Invalid file type: {filename}');", true);
                    continue;
                }

                // Validate MIME type
                if (!allowedMimeTypes.Contains(contentType))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        $"alert('Invalid file content type: {filename}');", true);
                    continue;
                }
                string path = @"C:\Users\Public\IMG\" + filename;
                try
                {
                    int fileSizeKB = (int)Math.Ceiling(postedFile.ContentLength / 1024.0);
                    using (Stream fs = postedFile.InputStream)
                    {
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            byte[] bytes = br.ReadBytes((Int32)fs.Length);
                            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;

                            using (SqlConnection con = new SqlConnection(constr))
                            {
                                string Touch_user = Session["UserId"].ToString();
                                string Code = MsgNO;
                                string DocType = DrpDocType.SelectedItem.ToString();
                                string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                string query = "insert into transhipfile values (@Name, @ContentType, @Data,@DocumentType,@TranshipId,@TouchUser,@TouchTime,@filePath,@FileSizeKB)";
                                using (SqlCommand cmd = new SqlCommand(query))
                                {

                                    cmd.Connection = con;
                                    cmd.Parameters.AddWithValue("@Name", filename);
                                    cmd.Parameters.AddWithValue("@ContentType", contentType);
                                    cmd.Parameters.AddWithValue("@Data", bytes);
                                    cmd.Parameters.AddWithValue("@DocumentType", DocType);
                                    cmd.Parameters.AddWithValue("@TranshipId", Code);
                                    cmd.Parameters.AddWithValue("@TouchUser", Touch_user);
                                    cmd.Parameters.AddWithValue("@TouchTime", strTime);
                                    cmd.Parameters.AddWithValue("@filePath", path);
                                    cmd.Parameters.AddWithValue("@FileSizeKB", fileSizeKB);
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                    BindGrid();
                                }
                            }
                        }
                    }
                    BindGrid();
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        $"alert('Error uploading {filename}: {ex.Message}');", true);
                }
            }

         
            DrpDocType.ClearSelection();
            DrpDocType.Items.FindByText("--Select--").Selected = true;
            transhipheader.Update();
        }

        protected void DrpInwardtrasMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  ReqValidatePageLoad();
            string TransMode = DrpInwardtrasMode.SelectedItem.ToString();
            string checktrans = DrpOutwardtrasMode.SelectedItem.ToString();

            if (checktrans == "1 : Sea" || checktrans == "4 : Air")
            {
                if (DrpDecType.SelectedItem.ToString() == "TTF : THRU TRANSHIPMENT WITHIN SAME FTZ" || DrpDecType.SelectedItem.ToString() == "TTI : THRU TRANSHIPMENT WITH INTER-GATEWAY MOVEMENT")
                {
                    OBLOUTMAWBL.Visible = true;
                }
                else
                {
                    OBLOUTMAWBL.Visible = false;
                }
            }
            else
            {
                OBLOUTMAWBL.Visible = false;
            }



            if (DrpInwardtrasMode.SelectedItem.ToString() != "--Select--")
            {

                InwardDetailsdiv1.Visible = false;
                TextMode.Text = TransMode;
                InwardFlight.Visible = false;
                InwardSea.Visible = false;
                InwardOther.Visible = false;
                //ContainerDetails.Visible = false;
                if (TextMode.Text == "1 : Sea")
                {
                    if (DrpDecType.SelectedItem.ToString() == "TTF : THRU TRANSHIPMENT WITHIN SAME FTZ" || DrpDecType.SelectedItem.ToString() == "TTI : THRU TRANSHIPMENT WITH INTER-GATEWAY MOVEMENT")
                    {
                        OBLINOUT.Visible = true;
                    }
                    else
                    {
                        OBLINOUT.Visible = false;
                    }



                    InwardSea.Visible = true;
                    inhbl.Visible = true;
                    inhab.Visible = false;
                    phawb.Visible = false;
                    inw.Visible = true;
                    InwardDetailsdiv1.Visible = true;

                    InwardCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    InwardName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);

                    //DrpTotalGrossWeight.Items.Clear();
                    //DrpTotalGrossWeight.Items.Add("TNE");
                    //DrpTotalGrossWeight.Items.Add("KGM");
                    //DrpTotalGrossWeight.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
                    //ContainerDetails.Visible = true;
                }


                else if (TextMode.Text == "2 : Rail" || TextMode.Text == "5 : Mail" || TextMode.Text == "7 : Pipeline" || TextMode.Text == "6 : Multi-model(Not in use)")
                {
                    if (DrpDecType.SelectedItem.ToString() == "TTF : THRU TRANSHIPMENT WITHIN SAME FTZ" || DrpDecType.SelectedItem.ToString() == "TTI : THRU TRANSHIPMENT WITH INTER-GATEWAY MOVEMENT")
                    {
                        OBLINOUT.Visible = false;
                    }
                    InwardOther.Visible = true;
                    inhab.Visible = true;
                    inhbl.Visible = false;
                    phawb.Visible = false;
                    inw.Visible = true;
                    InwardDetailsdiv1.Visible = true;
                    InwardCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    InwardName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);

                    //string str6ss1 = "select Id,Name from [CommonMaster] where TypeId='10' and StatusID=1 order by Name";
                    //obj.dr = obj.ret_dr(str6ss1);
                    //DrpTotalGrossWeight.DataSource = obj.dr;
                    //DrpTotalGrossWeight.DataTextField = "Name";
                    //DrpTotalGrossWeight.DataValueField = "Id";
                    //DrpTotalGrossWeight.DataBind();
                    //obj.closecon();
                    //DrpTotalGrossWeight.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
                    //ContainerDetails.Visible = false;
                }



                else if (TextMode.Text == "3 : Road")
                {
                    if (DrpDecType.SelectedItem.ToString() == "TTF : THRU TRANSHIPMENT WITHIN SAME FTZ" || DrpDecType.SelectedItem.ToString() == "TTI : THRU TRANSHIPMENT WITH INTER-GATEWAY MOVEMENT")
                    {
                        OBLINOUT.Visible = false;
                    }



                    InwardDetailsdiv1.Visible = true;
                    InwardOther.Visible = true;
                    inw.Visible = true;
                    inhab.Visible = true;
                    inhbl.Visible = false;
                    phawb.Visible = false;

                    InwardCRUEI.BackColor = System.Drawing.Color.White;
                    InwardName.BackColor = System.Drawing.Color.White;

                    //DrpTotalGrossWeight.Items.Clear();
                    //DrpTotalGrossWeight.Items.Add("KGM");
                    //DrpTotalGrossWeight.Items.Add("TNE");
                    //DrpTotalGrossWeight.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));


                    //ContainerDetails.Visible = false;
                }



                else if (TextMode.Text == "4 : Air")
                {
                    if (DrpDecType.SelectedItem.ToString() == "TTF : THRU TRANSHIPMENT WITHIN SAME FTZ" || DrpDecType.SelectedItem.ToString() == "TTI : THRU TRANSHIPMENT WITH INTER-GATEWAY MOVEMENT")
                    {
                        OBLINOUT.Visible = true;
                    }

                    InwardDetailsdiv1.Visible = true;
                    InwardFlight.Visible = true;
                    inhab.Visible = true;
                    inhbl.Visible = false;
                    phawb.Visible = true;
                    inw.Visible = true;

                    InwardCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    InwardName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);

                    //DrpTotalGrossWeight.Items.Clear();
                    //DrpTotalGrossWeight.Items.Add("TNE");
                    //DrpTotalGrossWeight.Items.Add("KGM");
                    //DrpTotalGrossWeight.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
                    // ContainerDetails.Visible = false;
                }
                else if (TextMode.Text == "N : Not Required")
                {
                    // OutDiv.Visible = false;
                    InwardDetailsdiv1.Visible = false;
                }
            }


            else
            {
                InwardDetailsdiv1.Visible = false;
            }


            transhipparty.Update();
            transhipcargo.Update();
            DrpOutwardtrasMode.Focus();
            //DrpDecType_SelectedIndexChanged(null, null);
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
                MyClass objitm = new MyClass();
                objitm.dr = objitm.ret_dr(qry11);
                while (objitm.dr.Read())
                {
                    string UOm = objitm.dr[0].ToString();
                    if (objitm.dr[0].ToString() == "-")
                    {
                        HSQTYUOM.ClearSelection();
                        HSQTYUOM.Items.FindByText(objitm.dr[0].ToString()).Selected = true;
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
                    uom = objitm.dr["DuitableUom"].ToString();
                    TxtHSCodeItem.Text = objitm.dr["HSCode"].ToString();
                    TxtDescription.Text = objitm.dr["Description"].ToString();

                    is_inpayment_controlled.Text = string.Empty;

                    // Check if the value exists and is not NULL
                    if (objitm.dr["is_trans_controlled"] != DBNull.Value && Convert.ToInt32(objitm.dr["is_trans_controlled"]) != 0)
                    {
                        // Convert to boolean (true for 1, false for 0)
                        bool isControlled = Convert.ToBoolean(objitm.dr["is_trans_controlled"]);

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

                    BindProduct1();
                }

                if (typeid == 62 || typeid == 63 )
                {
                    if (typeid == 62 && HSQTYUOM.SelectedItem.Text == "LTR")
                    {
                        totDuticableQtyDiv.Visible = true;
                        AlcoholDiv.Visible = true;
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
                    totDuticableQtyDiv.Visible = false;
                    AlcoholDiv.Visible = false;
                }

                /*hscodecoltroll(TxtHSCodeItem.Text);
                    
                    string[] ss = TxtHSCodeItem.Text.Split(':');
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
                            //   HSQTYUOM.Items.FindByText(obj.dr[0].ToString()).Selected = true;
                        }
                    }     */




            }
            else
            {
                HSQTYUOM.ClearSelection();
                TxtHSCodeItem.Text = "";
                TxtDescription.Text = "";

            }
            TxtDescription_TextChanged(null, null);
            TxtCountryItem.Focus();
            transhipitem.Update();
        }

        private void hscode(string hscode)
        {

            //string TYPEId = "";
            MyClass objhsn = new MyClass();
            string qry11s2 = "select * from [CommonMasterType] as a , HSCode as b where a.Id=b.Typeid  and HSCode='" + hscode + "' and Transhipment=1";
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

            string dutable = "select * from [CommonMasterType] as a , HSCode as b where a.Id=b.DUTYTYPID  and HSCode='" + hscode + "' and Transhipment=1";
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
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openCountry();", true);
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
            popuptransorgin.Show();
          
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
                    txtcname.Text = "";
                    //TxtHSCode.Text = requestType;
                    TxtCountryItem.Text = requestType;
                    txtcname.Text = status;
                }
                ChkBGIndicator.Focus();

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
                ChkBGIndicator.Focus();
            }
            else
            {
                TxtCountryItem.Text = "";
                txtcname.Text = "";
            }
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
                //Response.Write("ViewState is null");
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
        protected void btntest_Click(object sender, EventArgs e)
        {
            BindProduct1();
        }
        private void BindProduct1()
        {
            if (!string.IsNullOrWhiteSpace(TxtHSCodeItem.Text))
            {
                string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM CASCProductCodes where HSCode='" + TxtHSCodeItem.Text + "'"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
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
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM CASCProductCodes"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
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
                TxtProQty1.Focus();

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
            popupinnondec.Show();
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
                //Response.Write("ViewState is null");
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
            ModalPopupExtender1.Show();
          
        }

        protected void ProductCode2Grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ProductCode2Grid.PageIndex = e.NewPageIndex;
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Product2();", true);
            BindProduct1();
            ModalPopupExtender1.Show();
           
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
                TxtProQty2.Focus();
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
                TxtProQty2.Focus();
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
                //Response.Write("ViewState is null");
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

            ModalPopupExtender2.Show();
          
        }

        protected void ProductCode3Grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ProductCode3Grid.PageIndex = e.NewPageIndex;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Product3();", true);
            BindProduct1();
            ModalPopupExtender2.Show();
         
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
                TxtProQty3.Focus();
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
                TxtProQty3.Focus();
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
                //Response.Write("ViewState is null");
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
            BindProduct1();
            ModalPopupExtender3.Show();
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
                TxtProQty4.Focus();

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
                TxtProQty4.Focus();
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
                //Response.Write("ViewState is null");
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
            BindProduct1();
            ModalPopupExtender4.Show();
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
                TxtProQty5.Focus();
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
                TxtProQty5.Focus();
            }
        }

        protected void ProductCode5Plus_Click(object sender, EventArgs e)
        {
            AddProductCode5Grid();
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
            string qry11 = "SELECT COUNT(PermitId) as MsgID  from PermitCount where  AccountId='" + Session["AccountId"].ToString() + "' and TouchTime ='" + justdate + "' ";
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
            SqlCommand command1 = new SqlCommand("SELECT Max(Refid) from TranshipmentHeader where MessageType='TNPDEC' and  LEFT(MSGId,8) ='" + justdate + "'");
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
            string code =  String.Format("{0:000}", m_po_no);
            con.Close();
            refno = m_po_no.ToString();
        }
        private void PermitNO()
        {
            string Touch_user = Session["UserId"].ToString();
            string justdate = DateTime.Now.ToString("yyyyMMdd");
            con.Open();
            SqlCommand command1 = new SqlCommand("SELECT max(Refid) from TranshipmentHeader where MessageType='TNPDEC' and  LEFT(MSGId,8) ='" + justdate + "'");
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
            string qry11 = "SELECT COUNT(PermitId) as JobId  from PermitCount where   AccountId='" + Session["AccountId"].ToString() + "' and TouchTime ='" + justdate + "' ";
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
        //    SqlCommand command1q = new SqlCommand("SELECT max(SNo) from [InNonInvoiceDtl] where MessageType='TNPDEC'  ");
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
            SqlCommand command1113 = new SqlCommand("SELECT max(ItemNo) from [TranshipmentItemDtl] where MessageType='TNPDEC'  and PermitId='" + txt_code.Text + "'  ");
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

            // string AddCerDtl = TxtACerDtl1.Text + '-' + TxtACerDtl2.Text + '-' + TxtACerDtl3.Text + '-' + TxtACerDtl4.Text + '-' + TxtACerDtl5.Text;
            // string TransportDetails = TxtTrnDtl1.Text + '-' + TxtTrnDtl2.Text + '-' + TxtTrnDtl3.Text + '-' + TxtTrnDtl4.Text + '-' + TxtTrnDtl5.Text;

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
                ArrivalDate = Convert.ToDateTime(TxtArrivalDate1.Text);
            }

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

            // var BlanketDate = DateTime.Parse(this.BlankDate1.Text, new CultureInfo("en-US", true));
            DateTime TxtExpArrivalDate = Convert.ToDateTime(null);
            if (TxtExpArrivalDate1.Text == "")
            {
                var date = "01/01/1900";
                //var date = DateTime.Now.ToString("dd/MM/yyyy");
                var manDate = DateTime.ParseExact(date, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                TxtExpArrivalDate = Convert.ToDateTime(manDate);

            }
            else
            {
                var InvoiceDate1 = DateTime.ParseExact(TxtExpArrivalDate1.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                TxtExpArrivalDate = Convert.ToDateTime(InvoiceDate1);
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

                string StrQuery = (" Update TranshipmentHeader set Refid='" + refno + "',MSGId='" + MsgNO + "',Cnb='"+chkcnb .Checked .ToString ()+"',TradeNetMailboxID='" + TxtTradeMailID.Text + "',MessageType='" + TxtMsgType.Text + "',PreviousPermit='" + TxtPrevPerNO.Text + "',DeclarationType='" + DrpDecType.SelectedItem.ToString() + "',CargoPackType='" + DrpCargoPackType.SelectedItem.ToString() + "',InwardTransportMode='" + DrpInwardtrasMode.SelectedItem.ToString() + "', OutwardTransportMode='" + DrpOutwardtrasMode.SelectedItem.ToString() + "',BGIndicator='" + DrpBGIndicator.SelectedItem.ToString() + "',SupplyIndicator='" + ChkSupplyIndicator.Checked.ToString() + "',ReferenceDocuments='" + ChkRefDoc.Checked.ToString() + "',License='" + License + "',Recipient='" + Recipient + "',DeclarantCompanyCode='" + TxtDecCompCode.Text + "',ImporterCompanyCode='" + TxtImpCode.Text + "',HandlingAgentCode='" + TxtExpCode.Text + "',InwardCarrierAgentCode='" + InwardCode.Text + "',OutwardCarrierAgentCode='" + OutwardCode.Text + "',FreightForwarderCode='" + FrieghtCode.Text + "',ClaimantPartyCode='" + ConsigneeCode.Text + "',EndUserCode='" + EndUserCode.Text + "',ArrivalDate='" + Convert.ToDateTime(ArrivalDate).ToString("yyyy/MM/dd") + "',LoadingPortCode='" + TxtLoadShort.Text + "',VoyageNumber='" + TxtVoyageno.Text + "',VesselName='" + TxtVesselName.Text + "',OceanBillofLadingNo='" + TxtOceanBill.Text + "',ConveyanceRefNo='" + TxtConRefNo.Text + "',TransportId='" + TxtTrnsID.Text + "',FlightNO='" + txtflight.Text + "',AircraftRegNo='" + txtaircraft.Text + "',MasterAirwayBill='" + txtwaybill.Text + "',ReleaseLocation='" + txtreLoctn.Text + "',ReleaseLocName='" + txtrelocDeta.Text + "',RecepitLocation='" + txtrecloctn.Text + "',RecepitLocName='" + txtrecloctndet.Text + "',StorageLocation='" + TxtStorageShort.Text + "',RemovalStartDate='" + Convert.ToDateTime(BlanketDate).ToString("yyyy/MM/dd") + "',DepartureDate='" + Convert.ToDateTime(TxtExpArrivalDate).ToString("yyyy/MM/dd") + "',DischargePort='" + TxtExpLoadShort.Text + "',FinalDestinationCountry='" + DrpFinalDesCountry.SelectedItem.ToString() + "',OutVoyageNumber='" + OUTWARDVoyageNo.Text + "',OutVesselName='" + OUTWARDVessel.Text + "',OutOceanBillofLadingNo='" + OUTWARDOcenbill.Text + "',VesselType='" + ddpVessel.SelectedItem.ToString() + "',VesselNetRegTon='" + txtvesnet.Text + "',VesselNationality='" + DroVesslNat.SelectedItem.ToString() + "',TowingVesselID='" + txtTowVes.Text + "',TowingVesselName='" + txtTowVes.Text + "',NextPort='" + txtNextprt.Text + "',LastPort='" + txtLasPrt.Text + "',OutConveyanceRefNo='" + OUTWARDConref.Text + "',OutTransportId='" + OUTWARDTransId.Text + "',OutFlightNO='" + OUTWARDFlightN0.Text + "',OutAircraftRegNo='" + OUTWARDAirREgno.Text + "',OutMasterAirwayBill='" + OUTWARDAirwaybill.Text + "',TotalOuterPack='" + TxttotalOuterPack.Text + "',TotalOuterPackUOM='" + DrptotalOuterPack.SelectedItem.ToString() + "',TotalGrossWeight='" + TxtTotalGrossWeight.Text + "',TotalGrossWeightUOM='" + DrpTotalGrossWeight.SelectedItem.ToString() + "',GrossReference='" + TxtGrossReference.Text + "',TradeRemarks='" + txttrdremrk.Text + "',InternalRemarks='" + txtintremrk.Text + "',NumberOfItems='" + txtnoofitm.Text + "',TotalGSTTaxAmt='0.00',TotalExDutyAmt='" + txttotexAmt.Text + "',TotalCusDutyAmt='" + txtcusdutyAmt.Text + "',TotalODutyAmt='" + txtothtaxAmt.Text + "',TotalAmtPay='0.00',TotalCIFFOBValue='" + txtfobval.Text + "',TouchUser='" + Touch_user + "',TouchTime=Convert(VARCHAR,'" + strTime + "',108),prmtStatus='" + prmstatus + "' where Id='" + Id + "'");
                obj.exec(StrQuery);
            }
            else
            {

                string StrQuery = (" Update TranshipmentHeader set  Refid='" + refno + "',TradeNetMailboxID='" + TxtTradeMailID.Text + "', Cnb='" + chkcnb.Checked.ToString() + "',MessageType='" + TxtMsgType.Text + "',DeclarationType='" + DrpDecType.SelectedItem.ToString() + "',PreviousPermit='" + TxtPrevPerNO.Text + "',CargoPackType='" + DrpCargoPackType.SelectedItem.ToString() + "',InwardTransportMode='" + DrpInwardtrasMode.SelectedItem.ToString() + "', OutwardTransportMode='" + DrpOutwardtrasMode.SelectedItem.ToString() + "',BGIndicator='" + DrpBGIndicator.SelectedItem.ToString() + "',SupplyIndicator='" + ChkSupplyIndicator.Checked.ToString() + "',ReferenceDocuments='" + ChkRefDoc.Checked.ToString() + "',License='" + License + "',Recipient='" + Recipient + "',DeclarantCompanyCode='" + TxtDecCompCode.Text + "',ImporterCompanyCode='" + TxtImpCode.Text + "',HandlingAgentCode='" + TxtExpCode.Text + "',InwardCarrierAgentCode='" + InwardCode.Text + "',OutwardCarrierAgentCode='" + OutwardCode.Text + "',FreightForwarderCode='" + FrieghtCode.Text + "',ClaimantPartyCode='" + ConsigneeCode.Text + "',EndUserCode='" + EndUserCode.Text + "',ArrivalDate='" + Convert.ToDateTime(ArrivalDate).ToString("yyyy/MM/dd") + "',LoadingPortCode='" + TxtLoadShort.Text + "',VoyageNumber='" + TxtVoyageno.Text + "',VesselName='" + TxtVesselName.Text + "',OceanBillofLadingNo='" + TxtOceanBill.Text + "',ConveyanceRefNo='" + TxtConRefNo.Text + "',TransportId='" + TxtTrnsID.Text + "',FlightNO='" + txtflight.Text + "',AircraftRegNo='" + txtaircraft.Text + "',MasterAirwayBill='" + txtwaybill.Text + "',ReleaseLocation='" + txtreLoctn.Text + "',ReleaseLocName='" + txtrelocDeta.Text + "',RecepitLocation='" + txtrecloctn.Text + "',RecepitLocName='" + txtrecloctndet.Text + "',StorageLocation='" + TxtStorageShort.Text + "',RemovalStartDate='" + Convert.ToDateTime(BlanketDate).ToString("yyyy/MM/dd") + "',DepartureDate='" + Convert.ToDateTime(TxtExpArrivalDate).ToString("yyyy/MM/dd") + "',DischargePort='" + TxtExpLoadShort.Text + "',FinalDestinationCountry='" + DrpFinalDesCountry.SelectedItem.ToString() + "',OutVoyageNumber='" + OUTWARDVoyageNo.Text + "',OutVesselName='" + OUTWARDVessel.Text + "',OutOceanBillofLadingNo='" + OUTWARDOcenbill.Text + "',VesselType='" + ddpVessel.SelectedItem.ToString() + "',VesselNetRegTon='" + txtvesnet.Text + "',VesselNationality='" + DroVesslNat.SelectedItem.ToString() + "',TowingVesselID='" + txtTowVes.Text + "',TowingVesselName='" + txtTowVes.Text + "',NextPort='" + txtNextprt.Text + "',LastPort='" + txtLasPrt.Text + "',OutConveyanceRefNo='" + OUTWARDConref.Text + "',OutTransportId='" + OUTWARDTransId.Text + "',OutFlightNO='" + OUTWARDFlightN0.Text + "',OutAircraftRegNo='" + OUTWARDAirREgno.Text + "',OutMasterAirwayBill='" + OUTWARDAirwaybill.Text + "',TotalOuterPack='" + TxttotalOuterPack.Text + "',TotalOuterPackUOM='" + DrptotalOuterPack.SelectedItem.ToString() + "',TotalGrossWeight='" + TxtTotalGrossWeight.Text + "',TotalGrossWeightUOM='" + DrpTotalGrossWeight.SelectedItem.ToString() + "',GrossReference='" + TxtGrossReference.Text + "',InternalRemarks='" + txtintremrk.Text + "',TradeRemarks='" + txttrdremrk.Text + "',NumberOfItems='" + txtnoofitm.Text + "',TotalGSTTaxAmt='0.00',TotalExDutyAmt='" + txttotexAmt.Text + "',TotalCusDutyAmt='" + txtcusdutyAmt.Text + "',TotalODutyAmt='" + txtothtaxAmt.Text + "',TotalAmtPay='0.00',TotalCIFFOBValue='" + txtfobval.Text + "',TouchUser='" + Touch_user + "',TouchTime=Convert(VARCHAR,'" + strTime + "',108),prmtStatus='" + prmstatus + "' where Id='" + Id + "'");
                obj.exec(StrQuery);
            }
           




            string StrdeleteQuery = ("delete from TranshipmentContainerDtl where PermitId='" + txt_code.Text + "'");
            obj.exec(StrdeleteQuery);
            obj.closecon();
            int i = 0;
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
                        string StrQuery1 = ("INSERT INTO [dbo].[TranshipmentContainerDtl] ([PermitId],[RowNo],[ContainerNo],[Size],[Weight],[SealNo],[MessageType],[TouchUser],[TouchTime]) VALUES ('" + txt_code.Text + "','" + i + "','" + ContainerNo + "','" + ContainerSize + "','" + ContainerWeight + "','" + Containerseal + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "')");
                        obj.exec(StrQuery1);
                        obj.closecon();
                    }
                    i++;
                }
            }

            //CPC
            string cpc = ("delete from TranshipmentCPCDtl where PermitId='" + txt_code.Text + "' and CPCType='AEO'");
            obj.exec(cpc);
            obj.closecon();
            int j = 0;
            foreach (GridViewRow g1 in AEOGrid.Rows)
            {
                string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;

                string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;


                if (ProcessingCode1 != "")
                {
                    string StrQuery1 = ("INSERT INTO [dbo].[TranshipmentCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + j + "','AEO','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                    obj.exec(StrQuery1);
                    obj.closecon();
                }
                j++;
            }
            string cec = ("delete from TranshipmentCPCDtl where PermitId='" + txt_code.Text + "' and CPCType='STS'");
            obj.exec(cec);
            obj.closecon();
            int K = 0;

            foreach (GridViewRow g1 in CWCGrid.Rows)
            {
                string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;

                string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                if (ProcessingCode1 != "")
                {
                    string StrQuery1 = ("INSERT INTO [dbo].[TranshipmentCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + K + "','STS','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                    obj.exec(StrQuery1);
                    obj.closecon();
                }
                K++;
            }

            string cec1 = ("delete from TranshipmentCPCDtl where PermitId='" + txt_code.Text + "' and CPCType='SEASTORE'");
            obj.exec(cec1);
            obj.closecon();
            int l = 0;

            foreach (GridViewRow g1 in SeaGrid.Rows)
            {
                string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;

                string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                if (ProcessingCode1 != "")
                {
                    string StrQuery1 = ("INSERT INTO [dbo].[TranshipmentCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + l + "','SEASTORE','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                    obj.exec(StrQuery1);
                    obj.closecon();
                }
                l++;
            }

            string cec12 = ("delete from TranshipmentCPCDtl where PermitId='" + txt_code.Text + "' and CPCType='IC'");
            obj.exec(cec12);
            obj.closecon();

            int ll = 1;

            foreach (GridViewRow g1 in IcGrid.Rows)
            {
                string ProcessingCode1 = (g1.FindControl("TextBox1") as TextBox).Text;
                string ProcessingCode2 = (g1.FindControl("TextBox2") as TextBox).Text;
                string ProcessingCode3 = (g1.FindControl("TextBox3") as TextBox).Text;

                if (ProcessingCode1 != "")
                {
                    string StrQuery1 = ("INSERT INTO [dbo].[InNonCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + ll + "','IC','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                    obj.exec(StrQuery1);
                    obj.closecon();
                }
                ll++;
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

            if (prmstatus == "NEW")
            {
                Response.Redirect("TranshipmentList.aspx");
            }
        }
        private void amendinsert()
        {
            string Touch_user = Session["UserId"].ToString();
            string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string P1 = ("insert into TransAmend (Permitno,AmendmentCount,UpdateIndicator,ReplacementPermitno,DescriptionOfReason,PermitExtension,ExtendImportPeriod,DeclarationIndigator,TouchUser,TouchTme)Values('" + txtamendpermit.Text + "','" + txtamoundcount.Text + "','" + txtupdateindicator.Text + "','" + txtreplacepermit.Text + "','" + txtdescreason.Text + "','" + ChkPermitvalEx.Checked.ToString() + "','" + txtvalidity.Text + "','" + chkdec.Checked.ToString() + "','" + Touch_user + "','" + strTime + "') ");
            obj.exec(P1);
            obj.closecon();

        }
        private void Cancelinsert()
        {
            string Touch_user = Session["UserId"].ToString();
            string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string P1 = ("insert into TransCancel (Permitno,UpdateIndicator,ReplacementPermitno,ResonForCancel,DescriptionOfReason,DeclarationIndigator,TouchUser,TouchTme)Values('" + txtcanPermit.Text + "','" + txtupdateInd.Text + "','" + txtcanrepPermit.Text + "','" + DrpReasonCancel.SelectedItem.Text + "','" + txtdesReason.Text + "','" + CheckBox4.Checked.ToString() + "','" + Touch_user + "','" + strTime + "') ");
            obj.exec(P1);
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
                  if (chkstatus == "AMEND")
                  {
                      //if (ErrorDes == "")
                      //{
                      //    POPUPERR.Hide();

                      Editdata();
                      amendinsert();
                      Response.Redirect("TranshipmentList.aspx");
                      //}
                      //else
                      //{
                      //    POPUPERR.Show();
                      //    POPUPERR.X = 400;
                      //    POPUPERR.Y = 100;
                      //}

                  }
                  else if (chkstatus == "CANCEL")
                  {
                      Editdata();
                      Cancelinsert();
                      Response.Redirect("TranshipmentList.aspx");
                  }
                  else
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
                          string qry11 = "SELECT PermitId FROM TranshipmentHeader where PermitId='" + txt_code.Text + "' and MessageType='TNPDEC' and  LEFT(MSGId,8) ='" + justdate + "'";
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

                              // var BlanketDate = DateTime.Parse(this.BlankDate1.Text, new CultureInfo("en-US", true));

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



                              //  var DepatureDate = DateTime.Parse(this.TxtExpArrivalDate1.Text, new CultureInfo("en-US", true));
                              DateTime DepatureDate = Convert.ToDateTime(null);
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
                              int chkCode = 0;
                          Save:
                              string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                          string StrQuery = ("INSERT INTO [dbo].[TranshipmentHeader] ([Refid],[JobId],[MSGId],[PermitId],[TradeNetMailboxID],[MessageType],[DeclarationType],[PreviousPermit],[CargoPackType],[InwardTransportMode],[OutwardTransportMode],[BGIndicator],[SupplyIndicator],[ReferenceDocuments],[License],[Recipient],[DeclarantCompanyCode],[ImporterCompanyCode],[HandlingAgentCode],[InwardCarrierAgentCode],[OutwardCarrierAgentCode],[FreightForwarderCode],[ClaimantPartyCode],[EndUserCode],[ArrivalDate],[LoadingPortCode],[VoyageNumber],[VesselName],[OceanBillofLadingNo],[ConveyanceRefNo],[TransportId],[FlightNO],[AircraftRegNo],[MasterAirwayBill],[ReleaseLocation],[ReleaseLocName],[RecepitLocation],[RecepitLocName],[StorageLocation],[RemovalStartDate],[DepartureDate],[DischargePort],[FinalDestinationCountry],[OutVoyageNumber],[OutVesselName],[OutOceanBillofLadingNo],[VesselType],[VesselNetRegTon],[VesselNationality],[TowingVesselID],[TowingVesselName],[NextPort],[LastPort],[OutConveyanceRefNo],[OutTransportId],[OutFlightNO],[OutAircraftRegNo],[OutMasterAirwayBill],[TotalOuterPack],[TotalOuterPackUOM],[TotalGrossWeight],[TotalGrossWeightUOM],[GrossReference],[TradeRemarks],[InternalRemarks],[DeclareIndicator],[NumberOfItems],[TotalCIFFOBValue], [Status],[prmtStatus],[TouchUser],[TouchTime],[Cnb])  VALUES('" + refno + "','" + JobNo + "','" + MsgNO + "','" + txt_code.Text + "','" + TxtTradeMailID.Text + "','" + TxtMsgType.Text + "','" + DrpDecType.SelectedItem.ToString() + "','"+TxtPrevPerNO .Text +"','" + DrpCargoPackType.SelectedItem.ToString() + "','" + DrpInwardtrasMode.SelectedItem.ToString() + "','" + DrpOutwardtrasMode.SelectedItem.ToString() + "','" + DrpBGIndicator.SelectedItem.ToString() + "','" + ChkSupplyIndicator.Checked.ToString() + "','" + ChkRefDoc.Checked.ToString() + "','" + License + "','" + Recipient + "', '" + TxtDecCompCode.Text + "','" + TxtImpCode.Text + "','" + TxtExpCode.Text + "','" + InwardCode.Text + "','" + OutwardCode.Text + "','" + FrieghtCode.Text + "','" + ConsigneeCode.Text + "','" + EndUserCode.Text + "','" + Convert.ToDateTime(ArrivalDate).ToString("yyyy/MM/dd") + "','" + TxtLoadShort.Text + "','" + TxtVoyageno.Text + "','" + TxtVesselName.Text + "','" + TxtOceanBill.Text + "','" + TxtConRefNo.Text + "','" + TxtTrnsID.Text + "','" + txtflight.Text + "','" + txtaircraft.Text + "','" + txtwaybill.Text + "','" + txtreLoctn.Text + "','" + txtrelocDeta.Text + "','" + txtrecloctn.Text + "','" + txtrecloctndet.Text + "','" + TxtStorageShort.Text + "','" + Convert.ToDateTime(BlanketDate).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(DepatureDate).ToString("yyyy/MM/dd") + "','" + TxtExpLoadShort.Text + "','" + DrpFinalDesCountry.SelectedItem + "','" + OUTWARDVoyageNo.Text + "','" + OUTWARDVessel.Text + "','" + OUTWARDOcenbill.Text + "','" + ddpVessel.SelectedItem + "','" + txtvesnet.Text + "','" + DroVesslNat.SelectedItem + "','" + txtTowVes.Text + "','" + txtTowVesName.Text + "','" + txtNextprt.Text + "','" + txtLasPrt.Text + "','" + OUTWARDConref.Text + "','" + OUTWARDTransId.Text + "','" + OUTWARDFlightN0.Text + "','" + OUTWARDAirREgno.Text + "','" + OUTWARDAirwaybill.Text + "','" + TxttotalOuterPack.Text + "','" + DrptotalOuterPack.SelectedItem.ToString() + "','" + TxtTotalGrossWeight.Text + "','" + DrpTotalGrossWeight.SelectedItem.ToString() + "','" + TxtGrossReference.Text + "','" + txttrdremrk.Text + "','" + txtintremrk.Text + "','" + chkalrt.Checked.ToString() + "','" + txtnoofitm.Text + "','" + txtfobval.Text + "','NEW','NEW','" + Touch_user + "',Convert(VARCHAR,'" + strTime + "',108),'"+chkcnb .Checked .ToString ()+"')");
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
                              string tempdel = ("delete from TranshipmentTemp where PermitId='" + txt_code.Text + "' and TouchUser='" + Touch_user + "' ");
                              obj.exec(tempdel);

                             // string TouchDate = DateTime.Now.ToString("yyyy/MM/dd");
                              ////Count Permit
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
                                      string StrQuery1 = ("INSERT INTO [dbo].[TranshipmentContainerDtl] ([PermitId],[RowNo],[ContainerNo],[Size],[Weight],[SealNo],[MessageType],[TouchUser],[TouchTime]) VALUES ('" + txt_code.Text + "','" + i + "','" + ContainerNo + "','" + ContainerSize + "','" + ContainerWeight + "','" + Containerseal + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "')");
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
                                      string StrQuery1 = ("INSERT INTO [dbo].[TranshipmentCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + a + "','AEO','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
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
                                      string StrQuery1 = ("INSERT INTO [dbo].[TranshipmentCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + b + "','STS','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
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
                                      string StrQuery1 = ("INSERT INTO [dbo].[TranshipmentCPCDtl] ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])  VALUES ('" + txt_code.Text + "','" + TxtMsgType.Text + "','" + c + "','SEASTORE','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + Touch_user + "','" + strTime + "')");
                                      obj.exec(StrQuery1);
                                      obj.closecon();
                                  }
                                  c++;
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

                            Response.Redirect("TranshipmentList.aspx");

                          }
                          else
                          {
                              ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The Permit Code '" + txt_code.Text + "' Already Exist..');", true);
                              Response.Redirect("TranshipmentList.aspx");
                              //  Response.Write("The Importer Code Already Exist..");
                          }
                          //Itemclear();
                      }
                  }
              }
        }



        protected void chkaeo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkaeo.Checked == true)
            {
                AEO.Visible = true;
            }
            else
            {
                AEO.Visible = false;
            }
            //if (chkaeo.Checked == true && chkcwc.Checked == true)
            //{
            //    AEO.Visible = true;
            //    CWC.Visible = true;
            //    return;
            //}
            //else if (chkaeo.Checked == true)
            //{
            //    AEO.Visible = true;
            //    CWC.Visible = false;
            //}
            //else if (chkcwc.Checked == true)
            //{
            //    AEO.Visible = false;
            //    CWC.Visible = true;
            //}
            //else
            //{
            //    AEO.Visible = false;
            //    CWC.Visible = false;
            //}

        }

        protected void chkcwc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkcwc.Checked == true)
            {
                CWC.Visible = true;
            }
            else
            {
                CWC.Visible = false;
            }
            //if (chkaeo.Checked == true && chkcwc.Checked == true)
            //{
            //    AEO.Visible = true;
            //    CWC.Visible = true;
            //    return;
            //}
            //else if (chkaeo.Checked == true)
            //{
            //    AEO.Visible = true;
            //    CWC.Visible = false;
            //}
            //else if (chkcwc.Checked == true)
            //{
            //    AEO.Visible = false;
            //    CWC.Visible = true;
            //    //Response.Write("<script LANGUAGE='JavaScript' >alert('Please Attach Document File')</script>");
            //}
            //else
            //{
            //    AEO.Visible = false;
            //    CWC.Visible = false;
            //}

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
           // ReqValidatePageLoad();
            if (DrpDecType.SelectedValue != "")
            {
                ImportDiv.Visible = true;
                if (DrpDecType.SelectedItem.ToString() == "BRE : BLANKET REMOVAL")
                {
                    cargo.Visible = true;
                    Inward.Visible = true;
                    Outward.Visible = false;
                    outw.Visible = false;
                    transimp.Visible = true;
                    transfreight.Visible = true;
                    outtr.Visible = false;
                    BlankDate1.Visible = true;
                    lblrem.Visible = true;
                    OBLINOUT.Visible = false;
                    OBLOUTMAWBL.Visible = false;
                }
                else if (DrpDecType.SelectedItem.ToString() == "REM : REMOVAL")
                {
                    cargo.Visible = true;
                    Inward.Visible = true;
                    Outward.Visible = false;
                    outw.Visible = false;
                    transimp.Visible = true;
                    transfreight.Visible = true;
                    BlankDate1.Visible = true;
                    lblrem.Visible = true;
                    outtr.Visible = false;
                    OBLINOUT.Visible = false;
                    OBLOUTMAWBL.Visible = false;
                }
                else if (DrpDecType.SelectedItem.ToString() == "IGM : INTER-GATEWAY MOVEMENT")
                {
                    cargo.Visible = true;
                    Inward.Visible = true;
                    Outward.Visible = true;
                    outw.Visible = true;
                    transimp.Visible = true;
                    transfreight.Visible = true;
                    BlankDate1.Visible = false;
                    lblrem.Visible = false;
                    OBLINOUT.Visible = false;
                    OBLOUTMAWBL.Visible = false;
                }
                else if (DrpDecType.SelectedItem.ToString() == "TTF : THRU TRANSHIPMENT WITHIN SAME FTZ")
                {
                    cargo.Visible = true;
                    Inward.Visible = true;
                    Outward.Visible = true;
                    outw.Visible = true;
                    transimp.Visible = true;
                    transfreight.Visible = true;
                    BlankDate1.Visible = false;
                    lblrem.Visible = false;
                    ImportDiv.Visible = false;
                   // OBLINOUT.Visible = true;
                    inobl.Visible = false;
                    outobl.Visible = false;
                    inmaster.Visible = false;
                    outmaster.Visible = false;

                    //OBLINOUT.Visible = true;
                    //OBLOUTMAWBL.Visible = true;
                }

                else if (DrpDecType.SelectedItem.ToString() == "TTI : THRU TRANSHIPMENT WITH INTER-GATEWAY MOVEMENT")
                {
                    cargo.Visible = true;
                    Inward.Visible = true;
                    Outward.Visible = true;
                    outw.Visible = true;
                    transimp.Visible = true;
                    transfreight.Visible = true;
                    BlankDate1.Visible = false;
                    lblrem.Visible = false;
                    ImportDiv.Visible = false;
                  //  OBLINOUT.Visible = true;
                    inobl.Visible = false;
                    outobl.Visible = false;
                    inmaster.Visible = false;
                    outmaster.Visible = false;

                    //OBLINOUT.Visible = true;
                    //OBLOUTMAWBL.Visible = true;
                }
                else
                {
                    //inobl.Visible = true;
                    //outobl.Visible = true;
                    //OBLINOUT.Visible = false;
                    cargo.Visible = true;
                    Inward.Visible = true;
                    Outward.Visible = true;
                    outtr.Visible = false;
                    outw.Visible = true;
                    ImportDiv.Visible = true;
                }
            }
            transhipparty.Update();
            transhipcargo.Update();
            TxtPrevPerNO.Focus();
        }

        protected void ChkUnbrand_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkUnbrand.Checked == true)
            {
                TxtBrand.Text = "UnBranded";
            }
            else
            {
                TxtBrand.Text = "";
            }
            TxtModel.Focus();
        }

        protected void TxtDescription_TextChanged(object sender, EventArgs e)
        {

            LblCount.Text = "(" + TxtDescription.Text.Length.ToString() + " / 512 Characters)"; 
            TxtCountryItem.Focus();
        }
        protected void BtnPPN_Click(object sender, EventArgs e)
        {
            string sent = "Previous Permit Number :";

            txttrdremrk.Text = txttrdremrk.Text + Environment.NewLine + sent + TxtPrevPerNO.Text + Environment.NewLine;

        }
        protected void txttrdremrk_TextChanged(object sender, EventArgs e)
        {
            lbltracunt.Text = "(" + txttrdremrk.Text.Length.ToString() + " / 1024 Characters)";
           // lbltracunt.Text = "Character Count: " + txttrdremrk.Text.Length.ToString();
        }

        protected void DrpInvoiceNo_SelectedIndexChanged(object sender, EventArgs e)
        {


            string Code, Code1 = "";
            string qry11 = "select TICurrency from [InNonInvoiceDtl] where MessageType='INPDEC' AND PermitId='" + txt_code.Text + "'  order by TICurrency";
            obj.dr = obj.ret_dr(qry11);
            while (obj.dr.Read())
            {
                Code = obj.dr[0].ToString();
                if (Code != "--Select--")
                {
                    DRPCurrency.SelectedValue = Code;

                    string qry111 = "select CurrencyRate from dbo.Currency where Currency='" + Code + "'";
                    obj.dr = obj.ret_dr(qry111);
                    while (obj.dr.Read())
                    {
                        Code1 = obj.dr[0].ToString();
                        TxtExchangeRate.Text = Code1;
                    }

                }


            }

        }

        protected void DRPCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string Code = "";
            //string qry11 = "select TICurrency from [InNonInvoiceDtl] where MessageType='INPDEC' AND PermitId='" + txt_code.Text + "'   order by TICurrency";
            //obj.dr = obj.ret_dr(qry11);
            //while (obj.dr.Read())
            //{
            //    Code = obj.dr[0].ToString();
            //    if (Code != "--Select--")
            //    {
            //        DRPCurrency.SelectedValue = Code;
            //    }
            //}
            string Code1 = "";
            string qry111 = "select CurrencyRate from dbo.Currency where Currency='" + DRPCurrency.SelectedItem + "'";
            obj.dr = obj.ret_dr(qry111);
            while (obj.dr.Read())
            {
                Code1 = obj.dr[0].ToString();
                TxtExchangeRate.Text = Code1;
            }
            TxtTotalLineAmount.Focus();
        }

        protected void TxtTotalLineAmount_TextChanged(object sender, EventArgs e)
        {

            if (TxtTotalLineAmount.Text != "")
            {

                double T1, T2;
                bool A = double.TryParse(TxtTotalLineAmount.Text.Trim(), out T1);
                bool B = double.TryParse(TxtExchangeRate.Text.Trim(), out T2);

                if (A && B)
                    TxtCIFFOB.Text = (T1 * T2).ToString();
                TxtItemSumGST.Text = (T1 * T2 * 7 / 100).ToString();
            }
            else
            {
                TxtCIFFOB.Text = "0.00";
            }

            // if (TxtTotalLineAmount.Text != "")
            //{

            //    double T1, T2 ,T3;
            //    bool A = double.TryParse(TxtTotalLineAmount.Text.Trim(), out T1);
            //    bool B = double.TryParse(TxtExchangeRate.Text.Trim(), out T2);
            //    bool C = double.TryParse(TxtTotalLineCharges.Text.Trim(), out T3);

            //    if (A && B && C )
            //        TxtCIFFOB.Text = (T1 * T2 + T3).ToString();
            //    TxtItemSumGST.Text = (T1 * T2 + T3 * 7 / 100).ToString();




            //}
            //else
            //{
            //    TxtTotalLineAmount.Text = "0.00";
            //}
            //Sum of Item Amount

            string SumofItemAmount = "";
            string qry11s2Q = "select Distinct UnitPriceCurrency,Sum(TotalLineAmount) as TotalLineAmount from dbo.TranshipmentItemDtl where PermitId='" + txt_code.Text + "' and MessageType='TNPDEC' GROUP BY UnitPriceCurrency  ORDER BY UnitPriceCurrency DESC";
            obj.dr = obj.ret_dr(qry11s2Q);
            while (obj.dr.Read())
            {
                SumofItemAmount = obj.dr[0].ToString() + " : " + obj.dr[1].ToString();
                Label lbl = new Label();
                lbl.Text = SumofItemAmount;
                //lblinvoiceAmt.Text = reader["TotalLineAmount"].ToString();
                lbl.BackColor = System.Drawing.Color.WhiteSmoke;
                lbl.BorderStyle = BorderStyle.Solid;
                lbl.BorderWidth = 1;
                lbl.Width = 200;
                //totinvAmt = totinvAmt + "  -  " + lbl.Text + " " + Environment.NewLine;
                div1.Controls.Add(lbl);
                div1.Controls.Add(new LiteralControl("<br />"));
                //div2.Controls.Add(lbl);
                //div2.Controls.Add(new LiteralControl("<br />"));

            }
            string TotalGSTAmount = "";
            string qry11s2 = "select SUM(GSTAmount) as  GSTAmount  from dbo.TranshipmentItemDtl where PermitId='" + txt_code.Text + "' and MessageType='INPDEC'";
            obj.dr = obj.ret_dr(qry11s2);
            while (obj.dr.Read())
            {
                TotalGSTAmount = obj.dr[0].ToString();
                txttotgstAmt.Text = TotalGSTAmount;
                txtAmtPayble.Text = TotalGSTAmount;
            }
            TxtCIFFOB.Focus();

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
                TxtItemSumGST.Text = ((Convert.ToDouble(GSTG) * 7 / 100).ToString());
            }
            else
            {
                TxtUnitPrice.Text = "0.00";
            }
            //Sum of Item Amount

            string SumofItemAmount = "";
            string qry11s2Q = "select Distinct UnitPriceCurrency,Sum(TotalLineAmount) as TotalLineAmount from dbo.TranshipmentItemDtl where PermitId='" + txt_code.Text + "' and MessageType='TNPDEC' GROUP BY UnitPriceCurrency  ORDER BY UnitPriceCurrency DESC";
            obj.dr = obj.ret_dr(qry11s2Q);
            while (obj.dr.Read())
            {
                SumofItemAmount = obj.dr[0].ToString()+" : "+obj.dr[1].ToString();
                Label lbl = new Label();
                lbl.Text = SumofItemAmount;
                //lblinvoiceAmt.Text = reader["TotalLineAmount"].ToString();
                lbl.BackColor = System.Drawing.Color.WhiteSmoke;
                lbl.BorderStyle = BorderStyle.Solid;
                lbl.BorderWidth = 1;
                lbl.Width = 200;
                //totinvAmt = totinvAmt + "  -  " + lbl.Text + " " + Environment.NewLine;
                div1.Controls.Add(lbl);
                div1.Controls.Add(new LiteralControl("<br />"));
                //div2.Controls.Add(lbl);
                //div2.Controls.Add(new LiteralControl("<br />"));
            }
            //TotalGSTAmount
            string TotalGSTAmount = "";
            string qry11s2 = "select SUM(GSTAmount) as  GSTAmount  from dbo.TranshipmentItemDtl where PermitId='" + txt_code.Text + "' and MessageType='INPDEC'";
            obj.dr = obj.ret_dr(qry11s2);
            while (obj.dr.Read())
            {
                TotalGSTAmount = obj.dr[0].ToString();
                txttotgstAmt.Text = TotalGSTAmount;
                txtAmtPayble.Text = TotalGSTAmount;
            }
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
            DRPCurrency.Focus();
        }

        protected void DrpPreferentialCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DrpPreferentialCode.SelectedItem.ToString() == "PRF : if goods are imported under preferential dut")
            {
                lblCustomsDuty.Text = "Customs Duty - EXEMPTED";
            }

            else
            {
                lblCustomsDuty.Text = "Customs Duty";
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
                SqlCommand cmd = new SqlCommand("DELETE FROM TranshipmentItemDtl where ID=" + employeeId, con);
                result = cmd.ExecuteNonQuery();

                cmd = new SqlCommand("DELETE FROM TCASCDtl where PermitId='" + txt_code.Text + "' and ItemNo='" + ID + "'", con);
                cmd.ExecuteNonQuery();

                //cmd = new SqlCommand("DELETE FROM TCASCDtl where PermitId='" + txt_code.Text + "'", con);
                //cmd.ExecuteNonQuery();

                string var1 = "update T";
                var1 = var1 + " set ItemNo = rn";
                var1 = var1 + " from (";
                var1 = var1 + " select ItemNo,";
                var1 = var1 + " row_number() over(order by ItemNo) as rn";
                var1 = var1 + " from TranshipmentItemDtl where PermitId='" + txt_code.Text + "'";
                var1 = var1 + " ) T";
                //string var = "DECLARE @SRNO bigint=0;" + Environment.NewLine;
                //var = var + " UPDATE TranshipmentItemDtl SET @SRNO =ItemNo= @SRNO + 1 where PermitId='" + txt_code.Text + "'";
                cmd = new SqlCommand(var1, con);
                cmd.ExecuteNonQuery();

                int itemno = 1;
                DataSet sds = new DataSet();
                sds = obj.ds1("select Distinct ItemNo from TCASCDtl where PermitId='" + txt_code.Text + "' Order by ItemNo");
                for (int k = 0; k < sds.Tables[0].Rows.Count; k++)
                {
                    DataSet asd = new DataSet();
                    asd = obj.ds1("select Count(*) from TCASCDtl where PermitId='" + txt_code.Text + "' and ItemNo='" + sds.Tables[0].Rows[k]["ItemNo"].ToString() + "'");
                    if (Convert.ToDecimal(asd.Tables[0].Rows[0][0].ToString()) > 0)
                    {
                        cmd = new SqlCommand("UPDATE TCASCDtl SET  ItemNo='" + itemno + "' where PermitId='" + txt_code.Text + "' and ItemNo='" + sds.Tables[0].Rows[k]["ItemNo"].ToString() + "'", con);
                        cmd.ExecuteNonQuery();
                        itemno = itemno + 1;
                    }
                }
                con.Close();
            }
            //if (result == 1)
            //{
                BindItemMaster();

            //}
        }
        private void BindItemMaster()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM TranshipmentItemDtl where PermitId='" + txt_code.Text + "' and MessageType='TNPDEC' order by ItemNo"))
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
            transhipment.Update();
            transhipitem.Update();
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


        protected void AddItemGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            AddItemGrid.PageIndex = e.NewPageIndex;
            BindItemMaster();
        }








        private void BindOutward()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id,Code,Name,Name1,CRUEI FROM [transOutward]"))
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
            //  ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Outward1();", true);
            BindOutward();
            popuptransoutward.Show();
           
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
            FrieghtCode.Focus();
        }

        protected void OutwardAdd_Click(object sender, EventArgs e)
        {
            string Code = "";
            string qry11 = "SELECT Code FROM [transOutward] where Code='" + OutwardCode.Text.Replace("'", "''") + "'";

            obj.dr = obj.ret_dr(qry11);

            while (obj.dr.Read())
            {
                Code = obj.dr[0].ToString();

            }
            if (Code == "")
            {
                string Touch_user = Session["UserId"].ToString();

                string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string StrQuery = ("INSERT INTO [dbo].[transOutward] ([Code],[Name],[Name1],[CRUEI],[TouchUser],[TouchTime]) VALUES ('" + OutwardCode.Text.Replace("'", "''") + "','" + OutwardName.Text.Replace("'", "''") + "','" + OutwardName1.Text.Replace("'", "''") + "','" + OutwardCRUEI.Text.Replace("'", "''") + "','" + Touch_user + "',Convert(VARCHAR,'" + strTime + "',108))");
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
        public DataTable GetOutwardDataFromDataBase(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = OutwardSearch.Text;

            string str3 = "SELECT Id,Code,Name,Name1,CRUEI FROM [transOutward] where Code Like '%" + OutwardSearch.Text.Replace("'", "''") + "%' order by Id desc";
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

                string qry11 = "select * from [transOutward] where Code='" + ss[0].ToString().Replace("'", "''") + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {


                    OutwardCode.Text = obj.dr[1].ToString();
                    OutwardName.Text = obj.dr[2].ToString();
                    OutwardName1.Text = obj.dr[3].ToString();
                    OutwardCRUEI.Text = obj.dr[4].ToString();

                }
            }
            else
            {
                OutwardCode.Text = "";
                OutwardName.Text = "";
                OutwardName1.Text = "";
                OutwardCRUEI.Text = "";
            }
            FrieghtCode.Focus();
        }
        private void BindExporter()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id,Code,Name,Name1,CRUEI FROM HandingAgent"))
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
                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "EXPORTER();", true);
            }
        }

        protected void ExporterGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ExporterGrid.PageIndex = e.NewPageIndex;
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "EXPORTER();", true);
            BindExporter();
            popuptransexp.Show();
          

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

            InwardCode.Focus();
        }

        protected void BtnExpAdd_Click(object sender, EventArgs e)
        {
            string Code = "";
            string qry11 = "SELECT Code FROM [HandingAgent] where Code='" + TxtExpCode.Text.Replace("'", "''") + "'";

            obj.dr = obj.ret_dr(qry11);

            while (obj.dr.Read())
            {
                Code = obj.dr[0].ToString();

            }
            if (Code == "")
            {
                string Touch_user = Session["UserId"].ToString();

                string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string StrQuery = ("INSERT INTO [dbo].[HandingAgent] ([Code],[Name],[Name1],[CRUEI],[TouchUser],[TouchTime]) VALUES ('" + TxtExpCode.Text.Replace("'", "''") + "','" + TxtExpName.Text.Replace("'", "''") + "','" + TxtExpName1.Text.Replace("'", "''") + "','" + TxtExpCRUEI.Text.Replace("'", "''") + "','" + Touch_user + "',Convert(VARCHAR,'" + strTime + "',108))");
                obj.exec(StrQuery);
                BindExporter();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : Data Saved Successfully');", true);
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

            string str3 = "SELECT Id,Code,Name,Name1,CRUEI FROM [HandingAgent] where Code Like '%" + ExporterSearch.Text.Replace("'", "''") + "%' order by Id desc";
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
                string qry11 = "select * from [HandingAgent] where Code='" + ss[0].ToString().Replace("'", "''") + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {


                    TxtExpCode.Text = obj.dr[1].ToString();
                    TxtExpName.Text = obj.dr[2].ToString();
                    TxtExpName1.Text = obj.dr[3].ToString();
                    TxtExpCRUEI.Text = obj.dr[4].ToString();
                    LblHandAgent.Text = obj.dr[4].ToString() + " - " + obj.dr[2].ToString() + " - " + obj.dr[3].ToString();
                }
            }
            else
            {
                TxtExpCode.Text = "";
                TxtExpName.Text = "";
                TxtExpName1.Text = "";
                TxtExpCRUEI.Text = "";
                LblHandAgent.Text = "";

            }
            InwardCode.Focus();
        }
        private void BindConsignee()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM transConsignee"))
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
                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Consignee();", true);
            }
        }

        protected void ConsigneeGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ConsigneeGrid.PageIndex = e.NewPageIndex;
            //  ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Consignee();", true);
            BindConsignee();
            popuptransconsignee.Show();
          

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
                var ConsigneeSubDivi = row.FindControl("ConsigneeSubDivi") as Label;
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
                string ConsigneeSubDivif = ConsigneeSubDivi.Text;


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
                ConsigneeName.Text = ConsigneeAddress12;
                ConsigneeName1.Text = status;
                ConsigneeCRUEI.Text = crueis;
                ConsigneeAddress.Text = requestType;
                ConsigneeAddress1.Text = ConsigneeAddress112;
                ConsigneeCity.Text = ConsigneeCity12;
                ConsigneeSub.Text = ConsigneeSub12;
                ConsigneeSubDivi.Text = ConsigneeSubDivif;
                ConsigneePostal.Text = ConsigneePostal12;
                ConsigneeCountry.Text = ConsigneeCountry12;




            }
            EndUserCode.Focus();
        }

        protected void ConsigneeAdd_Click(object sender, EventArgs e)
        {
            string Code = "";
            string qry11 = "SELECT ConsigneeCode FROM transConsignee where ConsigneeCode='" + ConsigneeCode.Text.Replace("'", "''") + "'";
            obj.dr = obj.ret_dr(qry11);
            while (obj.dr.Read())
            {
                Code = obj.dr[0].ToString();
            }
            if (Code == "")
            {
                string Touch_user = Session["UserId"].ToString();
                string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string StrQuery = ("INSERT INTO [dbo].[transConsignee] ([ConsigneeCode],[ConsigneeName],[ConsigneeName1],[ConsigneeCRUEI],[ConsigneeAddress],[ConsigneeAddress1],[ConsigneeCity],[ConsigneeSub],ConsigneeSubDivi,[ConsigneePostal],[ConsigneeCountry],[TouchUser],[TouchTime])  VALUES ('" + ConsigneeCode.Text.Replace("'", "''") + "','" + ConsigneeName.Text.Replace("'", "''") + "','" + ConsigneeName1.Text.Replace("'", "''") + "','" + ConsigneeCRUEI.Text.Replace("'", "''") + "','" + ConsigneeAddress.Text.Replace("'", "''") + "','" + ConsigneeAddress1.Text.Replace("'", "''") + "','" + ConsigneeCity.Text.Replace("'", "''") + "','" + ConsigneeSub.Text + "','" + ConsigneeSubDivi.Text.Replace("'", "''") + "','" + ConsigneePostal.Text.Replace("'", "''") + "','" + ConsigneeCountry.Text.Replace("'", "''") + "','" + Touch_user + "',Convert(VARCHAR,'" + strTime + "',108))");
                obj.exec(StrQuery);
                BindConsignee();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : Data Saved Successfully');", true);
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

            string str3 = "SELECT * FROM transConsignee where ConsigneeCode Like '%" + ConsigneeSearch.Text.Replace("'", "''") + "%' order by Id desc";
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
                string qry11 = "select * from transConsignee where ConsigneeCode='" + ss[0].ToString().Replace("'", "''") + "'";
                obj.dr = obj.ret_dr(qry11);
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
                    ConsigneeSubDivi.Text = obj.dr["ConsigneeSubDivi"].ToString();
                    ConsigneePostal.Text = obj.dr["ConsigneePostal"].ToString();
                    ConsigneeCountry.Text = obj.dr["ConsigneeCountry"].ToString();
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
            EndUserCode.Focus();

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
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Export();", true);
            }
        }

        protected void ExportGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ExportGrid.PageIndex = e.NewPageIndex;
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Export();", true);
            BindExportPort();
            popuptransdischargeport.Show();
         

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
                if (TxtExpMode.Text == "1 : Sea")
                {
                    OUTWARDVoyageNo.Focus();
                }
                else if (TxtExpMode.Text == "2 : Rail" || TxtExpMode.Text == "3 : Road" || TxtExpMode.Text == "5 : Mail" || TxtExpMode.Text == "7 : Pipeline" || TxtExpMode.Text == "N : Not Required" || TxtExpMode.Text == "6 : Multi-model(Not in use)")
                {
                    OUTWARDConref.Focus();
                }

                else if (TxtExpMode.Text == "4 : Air")
                {
                    OUTWARDFlightN0.Focus();
                }
                DrpFinalDesCountry.Focus();
            }
        }

        protected void TxtExpMode_TextChanged(object sender, EventArgs e)
        {
            if (TxtExpMode.Text != "")
            {

                if (TxtExpMode.Text == "1 : Sea")
                {
                    OUTWARDSea.Visible = true;
                    //OUTWARDVesl.Visible = true;
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
            transhipcargo.Update();
        }
        public DataTable GetPortDataFromDataBase(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = ExpLoadingSearch.Text;
            string str3 = "SELECT * from LoadingPort where PortCode Like '%" + ExpLoadingSearch.Text.Replace("'", "''") + "%' or PortName like '" + ExpLoadingSearch.Text.Replace("'", "''") + "%' order by Id desc";
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
                string qry11 = "select * from LoadingPort where PortCode='" + ss[0].ToString().Replace("'", "''") + "'";

                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    TxtExpLoadShort.Text = obj.dr["PortCode"].ToString();
                    TxtExpLoad.Text = obj.dr["PortName"].ToString();
                }
                if (TxtExpMode.Text == "1 : Sea")
                {
                    OUTWARDVoyageNo.Focus();
                }
                else if (TxtExpMode.Text == "2 : Rail" || TxtExpMode.Text == "3 : Road" || TxtExpMode.Text == "5 : Mail" || TxtExpMode.Text == "7 : Pipeline" || TxtExpMode.Text == "N : Not Required" || TxtExpMode.Text == "6 : Multi-model(Not in use)")
                {
                    OUTWARDConref.Focus();
                }

                else if (TxtExpMode.Text == "4 : Air")
                {
                    OUTWARDFlightN0.Focus();
                }
            }
            else
            {
                TxtExpLoadShort.Text = "";
                TxtExpLoad.Text = "";
            }
            DrpFinalDesCountry.Focus();
        }

        protected void ChkSea_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkSea1.Checked == true)
            {
                SEA.Visible = true;
            }
            else
            {
                SEA.Visible = false;
            }
            //if (chkaeo.Checked == true && chkcwc.Checked == true && ChkSea1.Checked == true)
            //{
            //    AEO.Visible = true;
            //    CWC.Visible = true;
            //    SEA.Visible = true;

            //    return;
            //}
            //else if (chkaeo.Checked == true)
            //{
            //    AEO.Visible = true;
            //    CWC.Visible = false;
            //    SEA.Visible = false;
            //}
            //else if (chkcwc.Checked == true)
            //{
            //    AEO.Visible = false;
            //    CWC.Visible = true;
            //    SEA.Visible = false;
            //}
            //else if (ChkSea1.Checked == true)
            //{
            //    AEO.Visible = false;
            //    CWC.Visible = false;
            //    SEA.Visible = true;
            //}
            //else
            //{
            //    AEO.Visible = false;
            //    CWC.Visible = false;
            //    SEA.Visible = false;
            //}
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
                string[] ss = txtNextprt.Text.Split(':');
                string qry11 = "select * from LoadingPort where PortCode='" + ss[0].ToString() + "'";
                // string qry11 = "select * from LoadingPort where PortCode='" + txtNextprt.Text + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    txtNextprt.Text = obj.dr["PortCode"].ToString();
                    txtNetPrtSer.Text = obj.dr["PortName"].ToString();
                }
                txtLasPrt.Focus();
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
                string[] ss = txtLasPrt.Text.Split(':');
                string qry11 = "select * from LoadingPort where PortCode='" + ss[0].ToString() + "'";
                // string qry11 = "select * from LoadingPort where PortCode='" + txtLasPrt.Text + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    txtLasPrt.Text = obj.dr[1].ToString();
                    txtLasPrtSer.Text = obj.dr[2].ToString();
                    txtLasPrtSer.Focus();
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
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "NextPort();", true);
            BindNextPort();
            popuptransnxtport.Show();
           

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
                txtLasPrt.Focus();
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

            popuptranslastport.Show();
           
        }

        protected void LastGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LastGrid.PageIndex = e.NewPageIndex;
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "LastPort();", true);

            BindLastPort();
            popuptranslastport.Show();
           

        }
        public DataTable GetNextPortDataFromDataBase(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = NextPrtLoading.Text;

            string str3 = "SELECT * FROM LoadingPort where PortCode Like '%" + NextPrtLoading.Text + "%' or PortName like '" + NextPrtLoading.Text + "%' order by Id desc";
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

            string str3 = "SELECT * FROM LoadingPort where PortCode Like '%" + txtlastprt.Text + "%' or PortName like '" + txtlastprt.Text + "%' order by Id desc";
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

                    txtLasPrtSer.Focus();
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
            popuptranslastport.Show();
           
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
            DrpMaking.Items.Insert(0, new ListItem("--Select--", "0"));



            GridViewRow grdrow = (GridViewRow)((ImageButton)sender).NamingContainer as GridViewRow;
            Label ID1 = (Label)grdrow.FindControl("lblID");
            string ID = ID1.Text;

            //warning
            // string SuplierCode, Importer = "";

            string strBindTxtBox = "select * from [TranshipmentItemDtl] where Id=" + ID;
            obj.dr = obj.ret_dr(strBindTxtBox);
            while (obj.dr.Read())
            {
                TxtSerialNo.Text = obj.dr["ItemNo"].ToString();
                itemno.Text = obj.dr["ItemNo"].ToString();
                TxtHSCodeItem.Text = obj.dr["HSCode"].ToString();
                TxtHSCodeItem_TextChanged(null, null);
                TxtDescription.Text = obj.dr["Description"].ToString();
                TxtDescription_TextChanged(null, null);
                string chkrate = obj.dr["DGIndicator"].ToString();
                if (chkrate == "True" || chkrate == "true")
                {
                    ChkBGIndicator.Checked = true;
                }
                else if (chkrate == "False" || chkrate == "false")
                {
                    ChkBGIndicator.Checked = false;
                }
                TxtCountryItem.Text = obj.dr["Contry"].ToString();

                TxtBrand.Text = obj.dr["Brand"].ToString();
                TxtModel.Text = obj.dr["Model"].ToString();
                TxtHAWB.Text = obj.dr["InHAWBOBL"].ToString();
                txtOutHAWB.Text = obj.dr["OutHAWBOBL"].ToString();
                TxtInMAWBOBL.Text = obj.dr["InMAWBOBL"].ToString();
                TxtOutMAWBOBL.Text = obj.dr["OutMAWBOBL"].ToString();

                TxtTotalDutiableQuantity.Text = obj.dr["DutiableQty"].ToString();
                TDQUOM.ClearSelection();
                TDQUOM.Items.FindByText(obj.dr["DutiableUOM"].ToString()).Selected = true;
                txttotDutiableQty.Text = obj.dr["TotalDutiableQty"].ToString();
                ddptotDutiableQty.ClearSelection();
                ddptotDutiableQty.Items.FindByText(obj.dr["TotalDutiableUOM"].ToString()).Selected = true;
                //TDQUOM.SelectedItem.Text = obj.dr["TotalDutiableUOM"].ToString();
                txtAlcoholPer.Text = obj.dr["AlcoholPer"].ToString();
                TxtInvQty.Text = obj.dr["InvoiceQuantity"].ToString();
                TxtHSQuantity.Text = obj.dr["HSQty"].ToString();
                HSQTYUOM.ClearSelection();
                HSQTYUOM.Items.FindByText(obj.dr["HSUOM"].ToString()).Selected = true;
                //HSQTYUOM.SelectedItem.Text = obj.dr[16].ToString();

                // DrpInvoiceNo.Items.FindByText(obj.dr[16].ToString()).Selected = true;
                //DrpInvoiceNo.SelectedItem.Text = obj.dr[16].ToString();
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
                // DRPCurrency.SelectedItem.Text = obj.dr[19].ToString();
                TxtExchangeRate.Text = obj.dr["ExchangeRate"].ToString();
                TxtSumExRate.Text = obj.dr["SumExchangeRate"].ToString();
                TxtTotalLineAmount.Text = obj.dr["TotalLineAmount"].ToString();
                TxtTotalLineCharges.Text = obj.dr["InvoiceCharges"].ToString();
                TxtCIFFOB.Text = obj.dr["CIFFOB"].ToString();
                TxtOPQty.Text =Math.Round(Convert.ToDecimal(obj.dr["OPQty"].ToString()),0).ToString();


                if (Convert.ToDecimal(obj.dr["OPQty"].ToString()) > 0)
                {
                    ChkPackInfo.Checked = true;
                    PackingInfo.Visible = true;
                }


                //  DRPOPQUOM.Items.FindByText(obj.dr[26].ToString()).Selected = true;
                DRPOPQUOM.ClearSelection();
                DRPOPQUOM.Items.FindByText(obj.dr["OPUOM"].ToString()).Selected = true;
                //DRPOPQUOM.SelectedItem.Text = obj.dr[26].ToString();
                TxtIPQty.Text =Math.Round(Convert.ToDecimal( obj.dr["IPQty"].ToString()),0).ToString();
                //  DRPIPQUOM.Items.FindByText(obj.dr[28].ToString()).Selected = true;
                DRPIPQUOM.ClearSelection();
                DRPIPQUOM.Items.FindByText(obj.dr["IPUOM"].ToString()).Selected = true;
                //DRPIPQUOM.SelectedItem.Text = obj.dr[28].ToString();
                TxtINPQty.Text = Math.Round(Convert.ToDecimal(obj.dr["InPqty"].ToString()),0).ToString();
                //  DRPINNPQUOM.Items.FindByText(obj.dr[30].ToString()).Selected = true;
                DRPINNPQUOM.ClearSelection();
                DRPINNPQUOM.Items.FindByText(obj.dr["InPUOM"].ToString()).Selected = true;
                //DRPINNPQUOM.SelectedItem.Text = obj.dr[30].ToString();
                TxtIMPQty.Text = Math.Round(Convert.ToDecimal(obj.dr["ImPQty"].ToString()), 0).ToString();
                //  DRPIMPQUOM.Items.FindByText(obj.dr[32].ToString()).Selected = true;
                DRPIMPQUOM.ClearSelection();
                DRPIMPQUOM.Items.FindByText(obj.dr["ImPUOM"].ToString()).Selected = true;
                //DRPIMPQUOM.SelectedItem.Text = obj.dr[32].ToString();

                //  DrpPreferentialCode.Items.FindByText(obj.dr[33].ToString()).Selected = true;
                DrpPreferentialCode.ClearSelection();
                DrpPreferentialCode.Items.FindByText(obj.dr["PreferentialCode"].ToString()).Selected = true;
                // DrpPreferentialCode.SelectedItem.Text = obj.dr[33].ToString();
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
                //  DrpOtherUOM.Items.FindByText(obj.dr[44].ToString()).Selected = true;
                DrpOtherUOM.ClearSelection();
                DrpOtherUOM.Items.FindByText(obj.dr["OtherTaxUOM"].ToString()).Selected = true;
                //DrpOtherUOM.SelectedItem.Text = obj.dr[44].ToString();
                TxtSumOtherTaxRate.Text = obj.dr["OtherTaxAmount"].ToString();
                TxtCurrentLot.Text = obj.dr["CurrentLot"].ToString();
                DrpMaking.ClearSelection();
                DrpMaking.Items.FindByText(obj.dr["Making"].ToString()).Selected = true;
                // DrpMaking.SelectedItem.Text = obj.dr[47].ToString();
                TxtPreviousLot.Text = obj.dr["PreviousLot"].ToString();
                if (!string.IsNullOrWhiteSpace(obj.dr["PreviousLot"].ToString()))
                {
                    Chklot.Checked = true;
                    Chklot_CheckedChanged(null,null);
                    
                }

             
              
                txtShippingMarks1.Text = obj.dr["ShippingMarks1"].ToString();
                txtShippingMarks2.Text = obj.dr["ShippingMarks2"].ToString();
                txtShippingMarks3.Text = obj.dr["ShippingMarks3"].ToString();
                txtShippingMarks4.Text = obj.dr["ShippingMarks4"].ToString();
              
                //OriginalRegDate.Text = obj.dr["Orginregdate"].ToString();
                //DrpVehicleCapacity.Text = obj.dr["Engineuom"].ToString();
                //txtengine.Text = obj.dr["Enginecapacity"].ToString();

                //DrpVehicleType.Text = obj.dr["DrpVehicleType"].ToString();

                if (!string.IsNullOrWhiteSpace(obj.dr["DrpVehicleType"].ToString()))
                {
                    DrpVehicleType.ClearSelection();
                    DrpVehicleType.Items.FindByText(obj.dr["DrpVehicleType"].ToString()).Selected = true;
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

                if (!string.IsNullOrWhiteSpace(obj.dr["Orginregdate"].ToString()))
                {
                    OriginalRegDate.Text = Convert.ToDateTime(obj.dr["Orginregdate"].ToString()).ToString("dd/MM/yyyy");
                }
                editbindProduct1(ID);
                editbindProduct2(ID);
                editbindProduct3(ID);
                editbindProduct4(ID);
                editbindProduct5(ID);


                ItemAddGrid.Visible = true;
                ItemDiv.Visible = true;
                BtnAddNEWItem.Visible = false;               
                TxtCountryItem_TextChanged(null,null);

            }
            //EditItem();
        }


        private void editbindProduct1(string ID)
        {
            string strBindTxtBox = "select * from [TranshipmentItemDtl] where Id=" + ID;
            obj.dr = obj.ret_dr(strBindTxtBox);
            while (obj.dr.Read())
            {
                SqlConnection con = new SqlConnection(sqlconn);
                //SqlCommand cmd1 = new SqlCommand("SELECT T1.Id ,T1.CRP,T1.CompanyName,T1.Name,T1.EmailId,T1.Mobile, T2.Name as Rent ,t1.BudgetFrom,T1.BudgetTo ,T3.Name as Type,T4.Name as Location,T5.PropertyRef,T1.MultipleLocation,T1. MultipleProperty  FROM (select a.Id,a.CompanyName,a.Name,a.EmailId,a.Mobile,a.BudgetFrom,a.BudgetTo,b.Name as CRP,a.MultipleLocation,a.MultipleProperty  from lead a,CommonMaster b where a.Per_Com=b.Id and a.TouchUser='" + Touch_user + "') AS T1 JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.RentorBuy=b.Id) AS T2    ON T1.Id = T2.Id    JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Type=b.Id) AS T3  ON T1.Id = T3.Id     JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Location=b.Id) AS T4   ON T1.Id = T4.Id    JOIN ( select b.ID,b.Name,a.PropertyRef  from Lead_List a,Lead b where a.ParentId=b.Id) AS T5   ON T1.Id = T5.Id order by T1.Id desc", con);
                //SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3 from TranshipmentItemDtl a,TCASCDtl b where a.PermitId=b.PermitId and b.CASCId='Casc1' and a.PermitId='" + txt_code.Text + "'", con);
                SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3, Quantity , ProductCode from TCASCDtl  where CASCId='Casc1' and PermitId='" + txt_code.Text + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "'", con);
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                sda1.Fill(dt);
                ViewState["ProductCode1"] = dt;
                string ff = "select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3, Quantity , ProductCode,ProductUOM,Enduserdesc from TCASCDtl  where CASCId='Casc1' and PermitId='" + txt_code.Text + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "'";
                MyClass objprc = new MyClass();
                objprc.dr = objprc.ret_dr(ff);
                if (objprc.dr.Read())
                {

                    TxtProQty1.Text = objprc.dr["Quantity"].ToString();
                    TxtProductCode1.Text = objprc.dr["ProductCode"].ToString();
                    DrpP1.ClearSelection();
                    DrpP1.Items.FindByText(objprc.dr["ProductUOM"].ToString()).Selected = true;
                    EndUserDesp1.Text = objprc.dr["Enduserdesc"].ToString();
                    EndUserDesp1_TextChanged(null, null);
                    //DrpP3.SelectedItem.Text = obj.dr["ProductUOM"].ToString();
                }
                if (dt.Rows.Count <= 0)
                {
                    dt.Rows.Add();
                }
                ViewState["ProductCode1"] = dt;
                ProductCode1Grid1.DataSource = dt;
                ProductCode1Grid1.DataBind();
                int rowIndex = 0;
                if (ViewState["ProductCode1"] != null)
                {
                    DataTable dt1 = (DataTable)ViewState["ProductCode1"];
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt1.Rows.Count; i++)
                        {
                            Chkitemcasc.Checked = true;
                            Chkitemcasc_CheckedChanged(null,null);
                            TextBox box1 = (TextBox)ProductCode1Grid1.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                            TextBox box2 = (TextBox)ProductCode1Grid1.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                            TextBox box3 = (TextBox)ProductCode1Grid1.Rows[rowIndex].Cells[3].FindControl("TextBox3");
                            box1.Text = dt1.Rows[i]["Column1"].ToString();
                            box2.Text = dt1.Rows[i]["Column2"].ToString();
                            box3.Text = dt1.Rows[i]["Column3"].ToString();
                            rowIndex++;
                            //ProductCode1Grid1.DataSource = dt;
                            //ProductCode1Grid1.DataBind();
                        }
                    }
                }
            }
        }

        private void editbindProduct2(string ID)
        {
            string strBindTxtBox = "select * from [TranshipmentItemDtl] where Id=" + ID;
            obj.dr = obj.ret_dr(strBindTxtBox);
            while (obj.dr.Read())
            {
                SqlConnection con = new SqlConnection(sqlconn);
                //SqlCommand cmd1 = new SqlCommand("SELECT T1.Id ,T1.CRP,T1.CompanyName,T1.Name,T1.EmailId,T1.Mobile, T2.Name as Rent ,t1.BudgetFrom,T1.BudgetTo ,T3.Name as Type,T4.Name as Location,T5.PropertyRef,T1.MultipleLocation,T1. MultipleProperty  FROM (select a.Id,a.CompanyName,a.Name,a.EmailId,a.Mobile,a.BudgetFrom,a.BudgetTo,b.Name as CRP,a.MultipleLocation,a.MultipleProperty  from lead a,CommonMaster b where a.Per_Com=b.Id and a.TouchUser='" + Touch_user + "') AS T1 JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.RentorBuy=b.Id) AS T2    ON T1.Id = T2.Id    JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Type=b.Id) AS T3  ON T1.Id = T3.Id     JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Location=b.Id) AS T4   ON T1.Id = T4.Id    JOIN ( select b.ID,b.Name,a.PropertyRef  from Lead_List a,Lead b where a.ParentId=b.Id) AS T5   ON T1.Id = T5.Id order by T1.Id desc", con);
                //SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3 from TranshipmentItemDtl a,TCASCDtl b where a.PermitId=b.PermitId and b.CASCId='Casc2' and a.PermitId='" + txt_code.Text + "'", con);
                SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3, Quantity , ProductCode from TCASCDtl  where CASCId='Casc2' and PermitId='" + txt_code.Text + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "'", con);
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                sda1.Fill(dt);
                ViewState["ProductCode2"] = dt;
                string ff = "select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3, Quantity , ProductCode,ProductUOM,Enduserdesc from TCASCDtl  where CASCId='Casc2' and PermitId='" + txt_code.Text + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "'";
                //string ff = "select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3,Quantity,ProductCode,ProductUOM,Enduserdesc from TCASCDtl b where a.PermitId=b.PermitId and b.CASCId='Casc2' and a.PermitId='" + txt_code.Text + "'";
                MyClass objprc = new MyClass();
                objprc.dr = objprc.ret_dr(ff);
                if (objprc.dr.Read())
                {

                    TxtProQty2.Text = objprc.dr["Quantity"].ToString();
                    TxtProductCode2.Text = objprc.dr["ProductCode"].ToString();
                    DrpP2.ClearSelection();
                    DrpP2.Items.FindByText(objprc.dr["ProductUOM"].ToString()).Selected = true;
                    EndUserDesp2.Text = objprc.dr["Enduserdesc"].ToString();
                    EndUserDesp2_TextChanged(null, null);
                    //DrpP3.SelectedItem.Text = obj.dr["ProductUOM"].ToString();
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

        private void editbindProduct3(string ID)
        {
            string strBindTxtBox = "select * from [TranshipmentItemDtl] where Id=" + ID;
            obj.dr = obj.ret_dr(strBindTxtBox);
            while (obj.dr.Read())
            {
                SqlConnection con = new SqlConnection(sqlconn);
                //SqlCommand cmd1 = new SqlCommand("SELECT T1.Id ,T1.CRP,T1.CompanyName,T1.Name,T1.EmailId,T1.Mobile, T2.Name as Rent ,t1.BudgetFrom,T1.BudgetTo ,T3.Name as Type,T4.Name as Location,T5.PropertyRef,T1.MultipleLocation,T1. MultipleProperty  FROM (select a.Id,a.CompanyName,a.Name,a.EmailId,a.Mobile,a.BudgetFrom,a.BudgetTo,b.Name as CRP,a.MultipleLocation,a.MultipleProperty  from lead a,CommonMaster b where a.Per_Com=b.Id and a.TouchUser='" + Touch_user + "') AS T1 JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.RentorBuy=b.Id) AS T2    ON T1.Id = T2.Id    JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Type=b.Id) AS T3  ON T1.Id = T3.Id     JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Location=b.Id) AS T4   ON T1.Id = T4.Id    JOIN ( select b.ID,b.Name,a.PropertyRef  from Lead_List a,Lead b where a.ParentId=b.Id) AS T5   ON T1.Id = T5.Id order by T1.Id desc", con);
                //SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3 from TranshipmentItemDtl a,TCASCDtl b where a.PermitId=b.PermitId and b.CASCId='Casc3' and a.PermitId='" + txt_code.Text + "'", con);
                SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3, Quantity , ProductCode from TCASCDtl  where CASCId='Casc3' and PermitId='" + txt_code.Text + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "'", con);
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                sda1.Fill(dt);
                ViewState["ProductCode3"] = dt;
                string ff = "select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3, Quantity , ProductCode,ProductUOM,Enduserdesc from TCASCDtl  where CASCId='Casc3' and PermitId='" + txt_code.Text + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "'";
                //string ff = "select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3,Quantity,ProductCode,ProductUOM,Enduserdesc from ItemDtl a,TCASCDtl b where a.PermitId=b.PermitId and b.CASCId='Casc3' and a.PermitId='" + txt_code.Text + "'";
                MyClass objprc = new MyClass();
                objprc.dr = objprc.ret_dr(ff);
                if (objprc.dr.Read())
                {
                    TxtProQty3.Text = objprc.dr["Quantity"].ToString();
                    TxtProductCode3.Text = objprc.dr["ProductCode"].ToString();
                    DrpP3.ClearSelection();
                    DrpP3.Items.FindByText(objprc.dr["ProductUOM"].ToString()).Selected = true;
                    EndUserDesp3.Text = objprc.dr["Enduserdesc"].ToString();
                    EndUserDesp3_TextChanged(null, null);
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
                           
                        }
                    }
                }
            }
        }

        private void editbindProduct4(string ID)
        {
            string strBindTxtBox = "select * from [TranshipmentItemDtl] where Id=" + ID;
            obj.dr = obj.ret_dr(strBindTxtBox);
            while (obj.dr.Read())
            {
                SqlConnection con = new SqlConnection(sqlconn);
                //SqlCommand cmd1 = new SqlCommand("SELECT T1.Id ,T1.CRP,T1.CompanyName,T1.Name,T1.EmailId,T1.Mobile, T2.Name as Rent ,t1.BudgetFrom,T1.BudgetTo ,T3.Name as Type,T4.Name as Location,T5.PropertyRef,T1.MultipleLocation,T1. MultipleProperty  FROM (select a.Id,a.CompanyName,a.Name,a.EmailId,a.Mobile,a.BudgetFrom,a.BudgetTo,b.Name as CRP,a.MultipleLocation,a.MultipleProperty  from lead a,CommonMaster b where a.Per_Com=b.Id and a.TouchUser='" + Touch_user + "') AS T1 JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.RentorBuy=b.Id) AS T2    ON T1.Id = T2.Id    JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Type=b.Id) AS T3  ON T1.Id = T3.Id     JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Location=b.Id) AS T4   ON T1.Id = T4.Id    JOIN ( select b.ID,b.Name,a.PropertyRef  from Lead_List a,Lead b where a.ParentId=b.Id) AS T5   ON T1.Id = T5.Id order by T1.Id desc", con);
                //SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3 from TranshipmentItemDtl a,TCASCDtl b where a.PermitId=b.PermitId and b.CASCId='Casc4' and a.PermitId='" + txt_code.Text + "'", con);
                SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3, Quantity , ProductCode from TCASCDtl  where CASCId='Casc4' and PermitId='" + txt_code.Text + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "'", con);
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                sda1.Fill(dt);
                ViewState["ProductCode4"] = dt;
                string ff = "select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3, Quantity , ProductCode,ProductUOM,Enduserdesc from TCASCDtl  where CASCId='Casc4' and PermitId='" + txt_code.Text + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "'";
                //string ff = "select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3,Quantity,ProductCode,ProductUOM,Enduserdesc from ItemDtl a,TCASCDtl b where a.PermitId=b.PermitId and b.CASCId='Casc4' and a.PermitId='" + txt_code.Text + "'";
                MyClass objprc = new MyClass();
                objprc.dr = objprc.ret_dr(ff);
                if (objprc.dr.Read())
                {

                    TxtProQty4.Text = objprc.dr["Quantity"].ToString();
                    TxtProductCode4.Text = objprc.dr["ProductCode"].ToString();
                    DrpP4.ClearSelection();
                    DrpP4.Items.FindByText(objprc.dr["ProductUOM"].ToString()).Selected = true;
                    EndUserDesp4.Text = objprc.dr["Enduserdesc"].ToString();
                    EndUserDesp4_TextChanged(null, null);
                    //DrpP3.SelectedItem.Text = obj.dr["ProductUOM"].ToString();
                }
                if (dt.Rows.Count <= 0)
                {
                    dt.Rows.Add();
                }
                ViewState["ProductCode1"] = dt;
                ProductCode4Grid1.DataSource = dt;
                ProductCode4Grid1.DataBind();
                int rowIndex = 0;
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
                        }
                    }
                }
            }
        }

        private void editbindProduct5(string ID)
        {
            string strBindTxtBox = "select * from [TranshipmentItemDtl] where Id=" + ID;
            obj.dr = obj.ret_dr(strBindTxtBox);
            while (obj.dr.Read())
            {
                SqlConnection con = new SqlConnection(sqlconn);
                //SqlCommand cmd1 = new SqlCommand("SELECT T1.Id ,T1.CRP,T1.CompanyName,T1.Name,T1.EmailId,T1.Mobile, T2.Name as Rent ,t1.BudgetFrom,T1.BudgetTo ,T3.Name as Type,T4.Name as Location,T5.PropertyRef,T1.MultipleLocation,T1. MultipleProperty  FROM (select a.Id,a.CompanyName,a.Name,a.EmailId,a.Mobile,a.BudgetFrom,a.BudgetTo,b.Name as CRP,a.MultipleLocation,a.MultipleProperty  from lead a,CommonMaster b where a.Per_Com=b.Id and a.TouchUser='" + Touch_user + "') AS T1 JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.RentorBuy=b.Id) AS T2    ON T1.Id = T2.Id    JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Type=b.Id) AS T3  ON T1.Id = T3.Id     JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Location=b.Id) AS T4   ON T1.Id = T4.Id    JOIN ( select b.ID,b.Name,a.PropertyRef  from Lead_List a,Lead b where a.ParentId=b.Id) AS T5   ON T1.Id = T5.Id order by T1.Id desc", con);
                //SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3 from TranshipmentItemDtl a,TCASCDtl b where a.PermitId=b.PermitId and b.CASCId='Casc5' and a.PermitId='" + txt_code.Text + "'", con);
                SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3, Quantity , ProductCode from TCASCDtl  where CASCId='Casc5' and PermitId='" + txt_code.Text + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "'", con);
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                sda1.Fill(dt);
                ViewState["ProductCode5"] = dt;
                string ff = "select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3, Quantity , ProductCode,ProductUOM,Enduserdesc from TCASCDtl  where CASCId='Casc5' and PermitId='" + txt_code.Text + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "'";
                //string ff = "select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3,Quantity,ProductCode,ProductUOM,Enduserdesc from ItemDtl a,TCASCDtl b where a.PermitId=b.PermitId and b.CASCId='Casc5' and a.PermitId='" + txt_code.Text + "'";
                MyClass objprc = new MyClass();
                objprc.dr = objprc.ret_dr(ff);
                if (objprc.dr.Read())
                {

                    TxtProQty5.Text = objprc.dr["Quantity"].ToString();
                    TxtProductCode5.Text = objprc.dr["ProductCode"].ToString();
                    DrpP5.ClearSelection();
                    DrpP5.Items.FindByText(objprc.dr["ProductUOM"].ToString()).Selected = true;
                    EndUserDesp5.Text = objprc.dr["Enduserdesc"].ToString();
                    EndUserDesp5_TextChanged(null, null);
                    //DrpP3.SelectedItem.Text = obj.dr["ProductUOM"].ToString();
                }
                if (dt.Rows.Count <= 0)
                {
                    dt.Rows.Add();
                }
                ViewState["ProductCode1"] = dt;
                ProductCode5Grid1.DataSource = dt;
                ProductCode5Grid1.DataBind();
                int rowIndex = 0;
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
                        }
                    }
                }
            }
        }








        private void BindEndUser()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM transEnduser"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            EndUserGrid.DataSource = dt;
                            EndUserGrid.DataBind();
                        }
                    }
                }
            }
        }
        protected void EndUserSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable _objdt = new DataTable();
            _objdt = GetEndUserDataFromDataBase(EndUserSearch.Text);
            if (_objdt.Rows.Count > 0)
            {
                EndUserGrid.DataSource = _objdt;
                EndUserGrid.DataBind();
                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "EndUser();", true);
            }
        }

        protected void EndUserGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            EndUserGrid.PageIndex = e.NewPageIndex;
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "EndUser();", true);
            BindEndUser();
            popuptransenduser.Show();
           

        }

        protected void LmkEndUser_Command(object sender, CommandEventArgs e)
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
                var ConsigneeSubDivi = row.FindControl("ConsigneeSubDivi") as Label;
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
                string ConsigneeSubDivif = ConsigneeSubDivi.Text;

                string ConsigneePostal12 = ConsigneePostal1.Text;
                string ConsigneeCountry12 = ConsigneeCountry1.Text;


                EndUserCode.Text = "";
                EndUserName.Text = "";
                EndUserName1.Text = "";
                EndUserCrueo.Text = "";
                EndUserAddress.Text = "";
                EndUserAddress1.Text = "";
                EndUserCity.Text = "";
                EndUserSubCode.Text = "";
                EndUserSubCodeDivi.Text = "";
                EndUserPostal.Text = "";
                EndUserCountry.Text = "";



                EndUserCode.Text = requestor;
                EndUserName.Text = requestType;
                EndUserName1.Text = status;
                EndUserCrueo.Text = crueis;
                EndUserAddress.Text = ConsigneeAddress12;
                EndUserAddress1.Text = ConsigneeAddress112;
                EndUserCity.Text = ConsigneeCity12;
                EndUserSubCode.Text = ConsigneeSub12;
                EndUserSubCodeDivi.Text = ConsigneeSubDivif;
                EndUserPostal.Text = ConsigneePostal12;
                EndUserCountry.Text = ConsigneeCountry12;




            }
            btnpreviousparty.Focus();
        }

        protected void EndUserAdd_Click(object sender, EventArgs e)
        {
            string Code = "";
            string qry11 = "SELECT EndUserCode FROM transEnduser where EndUserCode='" + EndUserCode.Text.Replace("'", "''") + "'";
            obj.dr = obj.ret_dr(qry11);
            while (obj.dr.Read())
            {
                Code = obj.dr[0].ToString();
            }
            if (Code == "")
            {
                string Touch_user = Session["UserId"].ToString();
                string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string StrQuery = ("INSERT INTO [dbo].[transEnduser] ([EndUserCode],[EndUserName],[EndUserName1],[EndUserCRUEI],[EndUserAddress],[EndUserAddress1],[EndUserCity],[EndUserSub],EndUserSubDivi,[EndUserPostal],[EndUserCountry],[TouchUser],[TouchTime])  VALUES ('" + EndUserCode.Text.Replace("'", "''") + "','" + EndUserName.Text.Replace("'", "''") + "','" + EndUserName1.Text.Replace("'", "''") + "','" + EndUserCrueo.Text.Replace("'", "''") + "','" + EndUserAddress.Text.Replace("'", "''") + "','" + EndUserAddress1.Text.Replace("'", "''") + "','" + EndUserCity.Text.Replace("'", "''") + "','" + EndUserSubCode.Text.Replace("'", "''") + "','" + EndUserSubCodeDivi.Text.Replace("'", "''") + "','" + EndUserPostal.Text.Replace("'", "''") + "','" + EndUserCountry.Text.Replace("'", "''") + "','" + Touch_user + "',Convert(VARCHAR,'" + strTime + "',108))");
                obj.exec(StrQuery);
                BindEndUser();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : Data Saved Successfully');", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : The EndUser Code Already Exist...');", true);
                //Response.Write("The Inward Code Already Exist..");
            }
        }
        public DataTable GetEndUserDataFromDataBase(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = EndUserSearch.Text;

            string str3 = "SELECT * FROM transEnduser where EndUserCode Like '%" + EndUserSearch.Text.Replace("'", "''") + "%' order by Id desc";
            obj.dr = obj.ret_dr(str3);
            if (obj.dr.HasRows)
            {
                EndUserGrid.DataSource = obj.dr;

            }
            else
            {
                //Empty DataTable to execute the “else-condition”  
                DataTable dt = new DataTable();
                EndUserGrid.DataSource = dt;
                EndUserGrid.DataBind();
            }
            SqlConnection con = new SqlConnection(sqlconn);
            SqlDataAdapter _objda = new SqlDataAdapter(str3, con);
            con.Close();
            _objda.Fill(_objdt);
            return _objdt;
        }


        protected void EndUserCode_TextChanged(object sender, EventArgs e)
        {
            if (EndUserCode.Text != "")
            {
                string[] ss = EndUserCode.Text.Split(':');
                string qry11 = "select * from transEnduser where EndUserCode='" + ss[0].ToString().Replace("'", "''") + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {

                    EndUserCode.Text = obj.dr["EndUserCode"].ToString();
                    EndUserName.Text = obj.dr["EndUserName"].ToString();
                    EndUserName1.Text = obj.dr["EndUserName1"].ToString();
                    EndUserCrueo.Text = obj.dr["EndUserCRUEI"].ToString();
                    EndUserAddress.Text = obj.dr["EndUserAddress"].ToString();
                    EndUserAddress1.Text = obj.dr["EndUserAddress1"].ToString();
                    EndUserCity.Text = obj.dr["EndUserCity"].ToString();
                    EndUserSubCode.Text = obj.dr["EndUserSub"].ToString();
                    EndUserSubCodeDivi.Text = obj.dr["EndUserSubDivi"].ToString();
                    EndUserPostal.Text = obj.dr["EndUserPostal"].ToString();
                    EndUserCountry.Text = obj.dr["EndUserCountry"].ToString();

                }
            }
            else
            {
                EndUserCode.Text = "";
                EndUserName.Text = "";
                EndUserName1.Text = "";
                EndUserCrueo.Text = "";
                EndUserAddress.Text = "";
                EndUserAddress1.Text = "";
                EndUserCity.Text = "";
                EndUserSubCode.Text = "";
                EndUserSubCodeDivi.Text = "";
                EndUserPostal.Text = "";
                EndUserCountry.Text = "";
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
                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Storage();", true);
            }
        }
        public DataTable GetStorage(string searchtext)
        {
            DataTable _objdt = new DataTable();
            var a = StorageSearch.Text;

            string str3 = "SELECT * FROM StorageLocation where StorageCode Like '%" + StorageSearch.Text.Replace("'", "''") + "%' order by Id desc";
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
            BindStorage();
            popuptransstorage.Show();
           

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
            BlankDate1.Focus();
        }

        protected void TxtStorageShort_TextChanged(object sender, EventArgs e)
        {
            if (TxtStorageShort.Text != "")
            {

                string[] ss = TxtStorageShort.Text.Split(':');
                string qry11 = "select * from ReceiptLocation where Code='" + ss[0].ToString().Replace("'", "''") + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    TxtStorageShort.Text = obj.dr[2].ToString();
                    TxtStorageName.Text = obj.dr[3].ToString();
                }
            }
            else
            {
                TxtStorageShort.Text = "";
                TxtStorageName.Text = "";
            }
            BlankDate1.Focus();
        }

        protected void AddItemSearch_TextChanged(object sender, EventArgs e)
        {

        }
        private void Itemclear()
        {
            //txtOutHAWB.Text = "";
            // TxtSerialNo.Text = "";
            //txt_code.Text = "";
            lblhserror.Visible = false;
            //TDQUOM.Items.Clear();
            TDQUOM.ClearSelection();
            TDQUOM.Items.FindByText("--Select--").Selected = true;
            ddptotDutiableQty.ClearSelection();
            ddptotDutiableQty.Items.FindByText("--Select--").Selected = true;
            //  DrpInvoiceNo.Items.Insert(0, new ListItem("--Select--", "0"));
            //DrpInvoiceNo.Items.Clear();
            TxtMsgType.Text = "TNPDEC";
            TxtHSCodeItem.Text = "";
            DRPCurrency.ClearSelection();
            DRPCurrency.Items.FindByText("--Select--").Selected = true;
            //DRPCurrency.Items.Clear();
            TxtDescription.Text = "";
            TxtCountryItem.Text = "";
            TxtBrand.Text = "";
            TxtModel.Text = "";

            DRPOPQUOM.ClearSelection();
            DRPOPQUOM.Items.FindByText("--Select--").Selected = true;
            //DRPOPQUOM.SelectedItem.Text = "--Select--";
            //  DRPOPQUOM.Items.Clear();
          //  TxtHAWB.Text = "";
           // TxtTotalDutiableQuantity
            TxtTotalDutiableQuantity.Text = "0.00";
            TxtInvQty.Text = "0.00";
            TxtHSQuantity.Text = "0.00";
            HSQTYUOM.ClearSelection();
            HSQTYUOM.Items.FindByText("--Select--").Selected = true;
            //HSQTYUOM.Items.Clear();
            TxtUnitPrice.Text = "0.00";
            TxtExchangeRate.Text = "0.00";
            TxtSumExRate.Text = "0.00";
            TxtTotalLineAmount.Text = "0.00";
            txtAlcoholPer.Text = "0.00";
            // Drpcurrency4.Items.Insert(0, new ListItem("--Select--", "0"));
            // Drpcurrency4.Items.Clear();
            TxtTotalLineCharges.Text = "0.00";
            TxtCIFFOB.Text = "0.00";
            TxtOPQty.Text = "0.00";
            TxtIPQty.Text = "0.00";
            DRPIPQUOM.ClearSelection();
            DRPIPQUOM.Items.FindByText("--Select--").Selected = true;
            //DRPIPQUOM.SelectedItem.Text = "--Select--";
            // DRPIPQUOM.Items.Insert(0, new ListItem("--Select--", "0"));
            //DRPIPQUOM.Items.Clear();
            TxtINPQty.Text = "0.00";
            TxtINPQty.Text = "0.00";
            TxtIMPQty.Text = "0.00";
            ItemGSTRate.Text = "0.00";

            DRPINNPQUOM.ClearSelection();
            DRPINNPQUOM.Items.FindByText("--Select--").Selected = true;
            //DRPINNPQUOM.SelectedItem.Text = "--Select--";
            //  DRPINNPQUOM.Items.Insert(0, new ListItem("--Select--", "0"));
            // DRPINNPQUOM.Items.Clear();
            txtcname.Text = "";

            DRPIPQUOM.ClearSelection();
            DRPIPQUOM.Items.FindByText("--Select--").Selected = true;
            //DRPIPQUOM.SelectedItem.Text = "--Select--";
            DRPIMPQUOM.ClearSelection();
            DRPIMPQUOM.Items.FindByText("--Select--").Selected = true;
            //DRPIMPQUOM.Items.Insert(0, new ListItem("--Select--", "0"));
            //DRPIMPQUOM.Items.Clear();

            DrpPreferentialCode.ClearSelection();
            DrpPreferentialCode.Items.FindByText("--Select--").Selected = true;
            //DrpPreferentialCode.SelectedItem.Text = "--Select--";
            // DrpPreferentialCode.Items.Insert(0, new ListItem("--Select--", "0"));

            ItemGSTUOM.Text = "PER";
            TxtItemSumGST.Text = "0.00";
            TxtExciseDutyRate.Text = "0.00";
            TxtExciseDutyUOM.Text = "0.00";
            TxtSumExciseDuty.Text = "0.00";
            TxtCustomsDutyRate.Text = "0.00";
            TxtCustomsDutyUOM.Text = "0.00";
            TxtSumCustomsDuty.Text = "0.00";
            DrpOtherUOM.ClearSelection();
            DrpOtherUOM.Items.FindByText("--Select--").Selected = true;
            //DrpOtherUOM.SelectedItem.Text = "--Select--";

            DrpMaking.ClearSelection();
            DrpMaking.Items.FindByText("--Select--").Selected = true;
            //DrpMaking.SelectedItem.Text = "--Select--";


            TxtOtherTaxRate.Text = "0.00";
            TxtSumOtherTaxRate.Text = "0.00";
            TxtCurrentLot.Text = "";
            TxtPreviousLot.Text = "";
            txtShippingMarks1.Text = "";
            txtShippingMarks2.Text = "";
            txtShippingMarks3.Text = "";

            txtShippingMarks4.Text = "";

            txttotDutiableQty.Text = "0.00";
            TxtInMAWBOBL.Text = "";
            TxtOutMAWBOBL.Text = "";
          
            TxtProductCode1.Text = "";
            TxtProQty1.Text = "";
            DrpP1.ClearSelection();
            DrpP1.Items.FindByText("--Select--").Selected = true;
            EndUserDesp1.Text = "";

            TxtProductCode2.Text = "";
            TxtProQty2.Text = "";
            DrpP2.ClearSelection();
            DrpP2.Items.FindByText("--Select--").Selected = true;
            EndUserDesp2.Text = "";

           

            TxtProductCode3.Text = "";
            TxtProQty3.Text = "";
            DrpP3.ClearSelection();
            DrpP3.Items.FindByText("--Select--").Selected = true;
            EndUserDesp3.Text = "";

            TxtProductCode4.Text = "";
            TxtProQty4.Text = "";
            DrpP1.ClearSelection();
            DrpP4.Items.FindByText("--Select--").Selected = true;
            EndUserDesp4.Text = "";



            TxtProductCode5.Text = "";
            TxtProQty5.Text = "";
            DrpP1.ClearSelection();
            DrpP5.Items.FindByText("--Select--").Selected = true;
            EndUserDesp5.Text = "";

            TxtOptionalPrice.Text = "0.00";
            TxtOptionalExchageRate.Text = "0.00";
            TxtOptionalSumExRate.Text = "0.00";
            DrpOptionalUom.ClearSelection();
            DrpOptionalUom.Items.FindByText("--Select--").Selected = true;


            DrpVehicleType.ClearSelection();
            DrpVehicleType.Items.FindByText("--Select--").Selected = true;
            txtengine.Text = "0.00";
            OriginalRegDate.Text = "";
            DrpVehicleCapacity.ClearSelection();
            DrpVehicleCapacity.Items.FindByText("--Select--").Selected = true;
            
            //ProductCode1Grid1.DataSource = null;
            //ProductCode2Grid1.DataSource = null;
            //ProductCode3Grid1.DataSource = null;
            //ProductCode4Grid1.DataSource = null;
            ChkBGIndicator.Checked = false;
            ChkUnbrand.Checked = false;
            //ProductCode5Grid1.DataSource = null;
            lblhserror.Text = "";
            transhipment.Update();
            transhipitem.Update();
            ItemNO();

            ProductCode1();
            ProductCode2();
            ProductCode3();
            ProductCode4();
            ProductCode5();


        }

        protected void GridCancelDoc_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridCancelDoc.DataKeys[e.RowIndex].Value.ToString();

            string strDelete = "delete from InFile where Id='" + id + "' ";
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
                SqlCommand cmd = new SqlCommand("DELETE FROM TranscANFile where ID=" + employeeId, con);
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
                            string query = "insert into TranscANFile values (@Name, @ContentType, @Data,@DocumentType,@InPaymentId,@TouchUser,@TouchTime)";
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

        protected void DrpCargoPackType_SelectedIndexChanged(object sender, EventArgs e)
        {
           // ReqValidatePageLoad();
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


            transhipcargo.Update();
            transhipparty.Update();
            DrpInwardtrasMode.Focus();
            DrpDecType_SelectedIndexChanged(null, null);
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
                            lblinvqty.Visible = true;
                            lblinvqty.Text = "Invalid";
                        }
                        else
                        {
                            lblinvqty.Visible = false;
                            TxtHSQuantity.Text = TxtInvQty.Text;
                        }


                    // tokens = TxtInvQty.Text.ToString ().Split('.');


                }
                else if (UOm == "-")
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
                            lblinvqty.Visible = true;
                            lblinvqty.Text = "Invalid";
                        }
                        else
                        {
                            lblinvqty.Visible = false;
                            TxtHSQuantity.Text = TxtInvQty.Text;
                        }


                    // tokens = TxtInvQty.Text.ToString ().Split('.');


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
                            LblHSErr.Text = "Please Check Net Weight & Gross Weight";
                            transhipitem.Update();
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
                DRPCurrency.Focus();
            }
        }

        protected void TxtHAWB_TextChanged(object sender, EventArgs e)
        {

            lblhblValue.Text = TxtHAWB.Text;
            transhipsummery.Update();
            //if (TxtHAWB.Text != "")
            //{
            //    if (string.IsNullOrWhiteSpace(FrieghtCode.Text))
            //    {
            //        Response.Write("<script LANGUAGE='JavaScript' >alert('Please Check Freight Forwarded')</script>");
            //    }
            //}
            //else
            //{
            //    if (!string.IsNullOrWhiteSpace(FrieghtCode.Text))
            //    {
            //        Response.Write("<script LANGUAGE='JavaScript' >alert('Please Check Freight Forwarded')</script>");
            //    }
            //}
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TxtProQty1.Text = TxtHSQuantity.Text;
            DrpP1.Text = HSQTYUOM.SelectedItem.ToString();
        }

       
        private void CopyConsignee()
        {
            EndUserCode.Text = ConsigneeCode.Text;
            EndUserName.Text = ConsigneeName.Text;
            EndUserName1.Text = ConsigneeName1.Text;
            EndUserCrueo.Text = ConsigneeCRUEI.Text;
            EndUserAddress.Text = ConsigneeAddress.Text;
            EndUserAddress1.Text = ConsigneeAddress1.Text;
            EndUserCity.Text = ConsigneeCity.Text;
            EndUserSubCode.Text = ConsigneeSub.Text;
            EndUserSubCodeDivi.Text = ConsigneeSubDivi.Text;
            EndUserPostal.Text = ConsigneePostal.Text;
            EndUserCountry.Text = ConsigneeCountry.Text;
        }
        protected void btncopyconsign_Click(object sender, EventArgs e)
        {
            CopyConsignee();
        }

        protected void TxtInHouseItem_TextChanged(object sender, EventArgs e)
        {
            if (TxtInHouseItem.Text != "")
            {

                string[] ss = TxtInHouseItem.Text.Split(':');


                string qry11 = "select * from InhouseItemCode where InhouseCode='" + ss[0].ToString() + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    TxtInHouseItem.Text = obj.dr[1].ToString();
                    TxtHSCodeItem.Text = obj.dr[2].ToString();
                    TxtDescription.Text = obj.dr[3].ToString();

                }

            }
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
                if (Convert.ToInt16(year) >= 1900 && Convert.ToInt16(year) <= 2070)
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
            TxtLoadShort.Focus();
        }

        protected void BlankDate1_TextChanged(object sender, EventArgs e)
        {
            BlankDate1.Text = DateCheck(BlankDate1.Text);
            TxttotalOuterPack.Focus();
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

        protected void Button4_Click(object sender, EventArgs e)
        {
            TxtProQty2.Text = TxtHSQuantity.Text;
            DrpP2.SelectedItem.Text = HSQTYUOM.SelectedItem.ToString();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            TxtProQty3.Text = TxtHSQuantity.Text;
            DrpP3.SelectedItem.Text = HSQTYUOM.SelectedItem.ToString();
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            TxtProQty4.Text = TxtHSQuantity.Text;
            DrpP4.SelectedItem.Text = HSQTYUOM.SelectedItem.ToString();
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            TxtProQty5.Text = TxtHSQuantity.Text;
            DrpP5.SelectedItem.Text = HSQTYUOM.SelectedItem.ToString();
        }

        private void SetPreviousproduct()
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



                        box1.Text = dt.Rows[i]["CASC CODE 1"].ToString();

                        box2.Text = dt.Rows[i]["CASC CODE 2"].ToString();

                        box3.Text = dt.Rows[i]["CASC CODE 3"].ToString();



                        rowIndex++;

                    }

                }

            }

        }

        protected void ProductCode1Grid1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
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
                    ProductCode1Grid1.DataSource = dt;
                    ProductCode1Grid1.DataBind();

                    for (int i = 0; i < ContarinerGrid.Rows.Count - 1; i++)
                    {
                        ProductCode1Grid1.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                    }
                    SetPreviousproduct();
                }
            }
        }

        protected void ProductCode1Grid1_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void Button3_Click(object sender, EventArgs e)
        {
            MyClass curobj = new MyClass();
            curobj.dr = curobj.ret_dr("select Distinct UnitPriceCurrency,ExchangeRate from TranshipmentItemDtl where  MessageType='TNPDEC' AND PermitId='" + txt_code.Text + "'");
            while (curobj.dr.Read())
            {
                txttrdremrk.Text = txttrdremrk.Text + " " + curobj.dr["UnitPriceCurrency"].ToString() + " : " + curobj.dr["ExchangeRate"].ToString() + Environment.NewLine;
            }
            //string ss = Drpcurrency1.SelectedItem.Text + " : " + LblTotalInvoice.Text;

            //txttrdremrk.Text = ss;
            //outsummery.Update();
            //string ss = DRPCurrency.SelectedItem.Text + " : " + TxtExchangeRate.Text;

            //txttrdremrk.Text = ss;
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
            //string Code, Code1 = "";
            //string qry11 = "select TICurrency from [InvoiceDtl] where MessageType='TNPDEC' AND PermitId='" + txt_code.Text + "' and InvoiceNo='" + DrpInvoiceNo.SelectedItem.ToString() + "'  order by TICurrency";
            //obj.dr = obj.ret_dr(qry11);
            //while (obj.dr.Read())
            //{
            //    Code = obj.dr[0].ToString();
            //    if (Code != "--Select--")
            //    {
            //        DrpOptionalUom.ClearSelection();
            //        DrpOptionalUom.Items.FindByText(Code).Selected = true;


            //        string qry111 = "select CurrencyRate from dbo.Currency where Currency='" + Code + "'";
            //        obj.dr = obj.ret_dr(qry111);
            //        while (obj.dr.Read())
            //        {
            //            Code1 = obj.dr[0].ToString();
            //            TxtOptionalExchageRate.Text = Code1;
            //        }

            //    }


            //}
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
            TxtOPQty.Focus();
          //  Chkitemcasc.Focus();
        }
        protected void Chkitemcasc_CheckedChanged(object sender, EventArgs e)
        {
            if (Chkitemcasc.Checked == true)
            {
                ItemCASC.Visible = true;
            }
            else
            {
                ItemCASC.Visible = false;
            }
            transhipment.Update();
            transhipitem.Update();
            TxtProductCode1.Focus();
          //  Chklot.Focus();
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
            DrpPreferentialCode.Focus();
        }
        protected void Chklot_CheckedChanged(object sender, EventArgs e)
        {
            if (Chklot.Checked == true)
            {
                LOTID.Visible = true;
            }
            else
            {
                LOTID.Visible = false;
            }
        }

        protected void btnoutsaveheader_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[TabContainer1.ActiveTabIndex - 1];
            transhipment.Update();
            transhipheader.Update();
        }

        protected void btnoutresetheader_Click(object sender, EventArgs e)
        {
            HeaderClr();
        }

        protected void btnoutnextheader_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[TabContainer1.ActiveTabIndex + 1];
            transhipment.Update();
            transhipheader.Update();
            TxtDecCompCode.Focus();
        }

        protected void btnpreviousparty_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[TabContainer1.ActiveTabIndex - 1];
            transhipment.Update();
            transhipparty.Update();
            TxtMsgType.Focus();
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
            transhipment.Update();
            transhipparty.Update();
            txtreLoctn.Focus();
        }

        protected void btnprevcargo_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[TabContainer1.ActiveTabIndex - 1];
            transhipment.Update();
            transhipcargo.Update();
            TxtDecCompCode.Focus();

        }

        protected void btnsavecargo_Click(object sender, EventArgs e)
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

            // var BlanketDate = DateTime.Parse(this.BlankDate1.Text, new CultureInfo("en-US", true));

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



            //  var DepatureDate = DateTime.Parse(this.TxtExpArrivalDate1.Text, new CultureInfo("en-US", true));
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
            MSGNO();
            refid();
            string PrevPer = "";
            string qry11 = "SELECT PermitId FROM TranshipmentTemp where PermitId='" + txt_code.Text + "'";
            obj.dr = obj.ret_dr(qry11);
            while (obj.dr.Read())
            {
                PrevPer = obj.dr[0].ToString();
            }
            if (PrevPer != "")
            {
                string PerCount = ("Delete TranshipmentTemp where PermitId='" + txt_code.Text + "'");
                obj.exec(PerCount);
                obj.closecon();
            }
            int chkCode = 0;
        Save:
            string nullvalue = "0.00";
            string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string StrQuery = ("INSERT INTO [dbo].[TranshipmentTemp] ([Refid],[JobId],[MSGId],[PermitId],[TradeNetMailboxID],[MessageType],[DeclarationType],[CargoPackType],[InwardTransportMode],[OutwardTransportMode],[BGIndicator],[SupplyIndicator],[ReferenceDocuments],[License],[Recipient],[DeclarantCompanyCode],[ImporterCompanyCode],[HandlingAgentCode],[InwardCarrierAgentCode],[OutwardCarrierAgentCode],[FreightForwarderCode],[ClaimantPartyCode],[EndUserCode],[ArrivalDate],[LoadingPortCode],[VoyageNumber],[VesselName],[OceanBillofLadingNo],[ConveyanceRefNo],[TransportId],[FlightNO],[AircraftRegNo],[MasterAirwayBill],[ReleaseLocation],[ReleaseLocName],[RecepitLocation],[RecepitLocName],[StorageLocation],[RemovalStartDate],[DepartureDate],[DischargePort],[FinalDestinationCountry],[OutVoyageNumber],[OutVesselName],[OutOceanBillofLadingNo],[VesselType],[VesselNetRegTon],[VesselNationality],[TowingVesselID],[TowingVesselName],[NextPort],[LastPort],[OutConveyanceRefNo],[OutTransportId],[OutFlightNO],[OutAircraftRegNo],[OutMasterAirwayBill],[TotalOuterPack],[TotalOuterPackUOM],[TotalGrossWeight],[TotalGrossWeightUOM],[GrossReference],[TradeRemarks],[InternalRemarks],[DeclareIndicator],[NumberOfItems],[TotalCIFFOBValue], [Status],[prmtStatus],[TouchUser],[TouchTime])  VALUES('" + refno + "','" + JobNo + "','" + MsgNO + "','" + txt_code.Text + "','" + TxtTradeMailID.Text + "','" + TxtMsgType.Text + "','" + DrpDecType.SelectedItem.ToString() + "','" + DrpCargoPackType.SelectedItem.ToString() + "','" + DrpInwardtrasMode.SelectedItem.ToString() + "','" + DrpOutwardtrasMode.SelectedItem.ToString() + "','" + DrpBGIndicator.SelectedItem.ToString() + "','" + ChkSupplyIndicator.Checked.ToString() + "','" + ChkRefDoc.Checked.ToString() + "','" + License + "','" + Recipient + "', '" + TxtDecCompCode.Text + "','" + TxtImpCode.Text + "','" + TxtExpCode.Text + "','" + InwardCode.Text + "','" + OutwardCode.Text + "','" + FrieghtCode.Text + "','" + ConsigneeCode.Text + "','" + EndUserCode.Text + "','" + Convert.ToDateTime(ArrivalDate).ToString("yyyy/MM/dd") + "','" + TxtLoadShort.Text + "','" + TxtVoyageno.Text + "','" + TxtVesselName.Text + "','" + TxtOceanBill.Text + "','" + TxtConRefNo.Text + "','" + TxtTrnsID.Text + "','" + txtflight.Text + "','" + txtaircraft.Text + "','" + txtwaybill.Text + "','" + txtreLoctn.Text + "','"+txtrelocDeta.Text+"','" + txtrecloctn.Text + "','"+txtrecloctndet.Text+"','" + TxtStorageShort.Text + "','" + Convert.ToDateTime(BlanketDate).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(DepatureDate).ToString("yyyy/MM/dd") + "','" + TxtExpLoadShort.Text + "','" + DrpFinalDesCountry.SelectedItem + "','" + OUTWARDVoyageNo.Text + "','" + OUTWARDVessel.Text + "','" + OUTWARDOcenbill.Text + "','" + ddpVessel.SelectedItem + "','" + txtvesnet.Text + "','" + DroVesslNat.SelectedItem + "','" + txtTowVes.Text + "','" + txtTowVesName.Text + "','" + txtNextprt.Text + "','" + txtLasPrt.Text + "','" + OUTWARDConref.Text + "','" + OUTWARDTransId.Text + "','" + OUTWARDFlightN0.Text + "','" + OUTWARDAirREgno.Text + "','" + OUTWARDAirwaybill.Text + "','" + TxttotalOuterPack.Text + "','" + DrptotalOuterPack.SelectedItem.ToString() + "','" + TxtTotalGrossWeight.Text + "','" + DrpTotalGrossWeight.SelectedItem.ToString() + "','" + TxtGrossReference.Text + "','" + txttrdremrk.Text + "','" + txtintremrk.Text + "','" + chkalrt.Checked.ToString() + "','" + nullvalue + "','" + nullvalue + "','NEW','NEW','" + Touch_user + "',Convert(VARCHAR,'" + strTime + "',108))");
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
            transhipment.Update();
            transhipcargo.Update();
            TxtHAWB.Focus();
        }

        protected void btnprevitem_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[TabContainer1.ActiveTabIndex - 1];
            transhipment.Update();
            transhipitem.Update();
            txtreLoctn.Focus();
        }
        public void ReqItem()
        {

            if (TxtHSCodeItem.Text == "")
            {
                ErrorDes = ErrorDes + "Cargo -  Please Enter HS Code : ";

            }
            if (TxtDescription.Text == "")
            {
                ErrorDes = ErrorDes + "Cargo -  Please Enter HS Description : ";

            }
            if (TxtCountryItem.Text == "")
            {
                ErrorDes = ErrorDes + "Cargo -  Please Enter Country : ";

            }

            if (TxtHSQuantity.Text == "")
            {
                ErrorDes = ErrorDes + "Cargo -  Please Enter THSQuantity : ";

            }
            if (HSQTYUOM.SelectedItem.ToString() == "--Select--")
            {
                ErrorDes = ErrorDes + "Cargo -  Please Choose HS UOM : ";

            }
            if (DRPCurrency.SelectedItem.ToString() == "--Select--")
            {
                ErrorDes = ErrorDes + "Cargo -  Please Choose Currency : ";

            }

            if (TxtTotalLineAmount.Text == "")
            {
                ErrorDes = ErrorDes + "Cargo -  Please Enter TotalLineAmount : ";

            }
            if (DrpInwardtrasMode.SelectedItem.ToString() == "1 : Sea" || DrpInwardtrasMode.SelectedItem.ToString() == "4 : Air")
            {
                if (TxtInMAWBOBL.Text == "")
                {
                    ErrorDes = ErrorDes + "Party -  Please Enter InMAWBOBL : ";
                    TxtInMAWBOBL.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                }


            }

            if (DrpOutwardtrasMode.SelectedItem.ToString() == "1 : Sea" || DrpOutwardtrasMode.SelectedItem.ToString() == "4 : Air")
            {
                if (TxtOutMAWBOBL.Text == "")
                {
                    ErrorDes = ErrorDes + "Party -  Please Enter OutMAWBOBL : ";
                    TxtOutMAWBOBL.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                }


            }
            TxtHSCodeItem.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            TxtDescription.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            TxtCountryItem.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            // TxtBrand.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            TxtHSQuantity.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            HSQTYUOM.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            DRPCurrency.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            TxtTotalLineAmount.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);


        }
        protected void btnsaveitem_Click(object sender, EventArgs e)
        {
            try
            {
                ReqItem();
                if (GridError.DataSource != null)
                {
                    GridError.Visible = true;
                    POPUPERR.Show();
                    POPUPERR.X = 400;
                    POPUPERR.Y = 100;
                }
                else
                {

                    string itemcnt = "";
                    int count = 0;

                    string itemcnt1 = "SELECT COUNT(*) as count FROM TranshipmentItemDtl where MessageType='TNPDEC' AND PermitId='" + txt_code.Text + "'";
                    obj.dr = obj.ret_dr(itemcnt1);
                    while (obj.dr.Read())
                    {
                        itemcnt = obj.dr["count"].ToString();
                        count = Convert.ToInt32(itemcnt);
                    }
                    string Code = "";
                    string qry1111 = "SELECT * FROM TranshipmentItemDtl where  MessageType='TNPDEC' AND PermitId='" + txt_code.Text + "' and ItemNo='" + TxtSerialNo.Text + "'";
                    obj.dr = obj.ret_dr(qry1111);
                    while (obj.dr.Read())
                    {
                        Code = obj.dr[1].ToString();
                    }

                    if (Code == "")
                    {
                        if (count < 50)
                        {
                            lblitemalert.Visible = false;


                            string Touch_user = Session["UserId"].ToString();
                            string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            //   var InvoiceDate = DateTime.Parse(this.txtinvDate.Value, new CultureInfo("en-US", true));
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


                            string StrQuery1 = ("INSERT INTO [dbo].[TranshipmentItemDtl] ([ItemNo],[PermitId],[MessageType],[HSCode],[Description],[DGIndicator],[Contry],[Brand],[Model],[DrpVehicleType],[Enginecapacity],[Engineuom],[Orginregdate],[InHAWBOBL],InMAWBOBL,[OutHAWBOBL],OutMAWBOBL,[DutiableQty],[DutiableUOM],[TotalDutiableQty],[TotalDutiableUOM],[InvoiceQuantity],[HSQty],[HSUOM],[AlcoholPer],[UnitPrice],[UnitPriceCurrency],[ExchangeRate],[SumExchangeRate],[TotalLineAmount],[InvoiceCharges],[CIFFOB],[OPQty],[OPUOM],[IPQty],[IPUOM],[InPqty],[InPUOM],[ImPQty],[ImPUOM],[PreferentialCode],[GSTRate],[GSTUOM],[GSTAmount],[ExciseDutyRate],[ExciseDutyUOM],[ExciseDutyAmount],[CustomsDutyRate],[CustomsDutyUOM],[CustomsDutyAmount],[OtherTaxRate],[OtherTaxUOM],[OtherTaxAmount],[CurrentLot],[PreviousLot],[Making],[ShippingMarks1],[ShippingMarks2],[ShippingMarks3],[ShippingMarks4],[OptionalChrgeUOM],[Optioncahrge],[OptionalSumtotal],[OptionalSumExchage],[TouchUser],[TouchTime]) VALUES ('" + TxtSerialNo.Text + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + TxtHSCodeItem.Text + "','" + TxtDescription.Text + "','" + ChkBGIndicator.Checked.ToString() + "','" + TxtCountryItem.Text + "','" + TxtBrand.Text + "','" + TxtModel.Text + "','" + DrpVehicleType.SelectedItem.Text + "','" + txtengine.Text + "','" + DrpVehicleCapacity.SelectedItem.Text + "','" + Convert.ToDateTime(orgindate).ToString("yyyy/MM/dd") + "','" + TxtHAWB.Text + "','" + TxtInMAWBOBL.Text + "','" + txtOutHAWB.Text + "','" + TxtOutMAWBOBL.Text + "','" + TxtTotalDutiableQuantity.Text + "','" + TDQUOM.SelectedItem.ToString() + "','" + txttotDutiableQty.Text + "','" + ddptotDutiableQty.SelectedItem.ToString() + "','" + TxtInvQty.Text + "','" + TxtHSQuantity.Text + "','" + HSQTYUOM.SelectedItem + "','" + txtAlcoholPer.Text + "','" + TxtUnitPrice.Text + "','" + DRPCurrency.SelectedItem + "','" + TxtExchangeRate.Text + "','" + TxtSumExRate.Text + "','" + Convert.ToDecimal(TxtTotalLineAmount.Text).ToString() + "','" + Convert.ToDecimal(TxtTotalLineCharges.Text).ToString() + "','" + Convert.ToDecimal(TxtCIFFOB.Text).ToString() + "','" + TxtOPQty.Text + "','" + DRPOPQUOM.SelectedItem + "','" + TxtIPQty.Text + "','" + DRPIPQUOM.SelectedItem + "','" + TxtINPQty.Text + "','" + DRPINNPQUOM.SelectedItem + "','" + TxtIMPQty.Text + "','" + DRPIMPQUOM.SelectedItem + "','" + DrpPreferentialCode.SelectedItem + "','" + ItemGSTRate.Text + "','" + ItemGSTUOM.Text + "','" + Convert.ToDecimal(TxtItemSumGST.Text).ToString() + "','" + TxtExciseDutyRate.Text + "','" + TxtExciseDutyUOM.Text + "','" + TxtSumExciseDuty.Text + "','" + TxtCustomsDutyRate.Text + "','" + TxtCustomsDutyUOM.Text + "','" + TxtSumCustomsDuty.Text + "','" + TxtOtherTaxRate.Text + "','" + DrpOtherUOM.SelectedItem + "','" + TxtSumOtherTaxRate.Text + "','" + TxtCurrentLot.Text + "','" + TxtPreviousLot.Text + "','" + DrpMaking.SelectedItem + "','" + txtShippingMarks1.Text + "','" + txtShippingMarks2.Text + "','" + txtShippingMarks3.Text + "','" + txtShippingMarks4.Text + "','" + DrpOptionalUom.SelectedItem.Text + "','" + TxtOptionalPrice.Text + "','" + TxtOptionalExchageRate.Text + "','" + TxtOptionalSumExRate.Text + "','" + Touch_user + "','" + strTime + "')");
                            obj.exec(StrQuery1);
                            obj.closecon();

                            if (string.IsNullOrWhiteSpace(TxtProQty1.Text))
                            {
                                TxtProQty1.Text = "0.00";
                            }
                            if (string.IsNullOrWhiteSpace(TxtProQty2.Text))
                            {
                                TxtProQty2.Text = "0.00";
                            }
                            if (string.IsNullOrWhiteSpace(TxtProQty3.Text))
                            {
                                TxtProQty3.Text = "0.00";


                            }
                            if (string.IsNullOrWhiteSpace(TxtProQty4.Text))
                            {
                                TxtProQty4.Text = "0.00";
                            }
                            if (string.IsNullOrWhiteSpace(TxtProQty5.Text))
                            {
                                TxtProQty5.Text = "0.00";
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
                                    string P1 = ("INSERT INTO [dbo].[TCASCDtl] ([ItemNo],[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId],[Enduserdesc]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode1.Text + "','" + TxtProQty1.Text + "','" + DrpP1.SelectedItem + "','" + p1 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc1','" + EndUserDesp1.Text + "')");
                                    obj.exec(P1);
                                    obj.closecon();
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
                                    string P1 = ("INSERT INTO [dbo].[TCASCDtl] ([ItemNo],[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId],[Enduserdesc]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode2.Text + "','" + TxtProQty2.Text + "','" + DrpP2.SelectedItem + "','" + p2 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc2','" + EndUserDesp2.Text + "')");
                                    obj.exec(P1);
                                    obj.closecon();
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
                                    string P1 = ("INSERT INTO [dbo].[TCASCDtl] ([ItemNo],[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId],[Enduserdesc]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode3.Text + "','" + TxtProQty3.Text + "','" + DrpP3.SelectedItem + "','" + p3 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc3','" + EndUserDesp3.Text + "')");
                                    obj.exec(P1);
                                    obj.closecon();
                                }
                                p3++;
                            }

                            //ProductCode 4
                            int p4 = 1;
                            foreach (GridViewRow g4 in ProductCode4Grid1.Rows)
                            {

                                string ProcessingCode1 = (g4.FindControl("TextBox1") as TextBox).Text;
                                string ProcessingCode2 = (g4.FindControl("TextBox2") as TextBox).Text;
                                string ProcessingCode3 = (g4.FindControl("TextBox3") as TextBox).Text;

                                if (TxtProductCode4.Text != "")
                                {
                                    string P1 = ("INSERT INTO [dbo].[TCASCDtl] ([ItemNo],[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId],[Enduserdesc]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode4.Text + "','" + TxtProQty4.Text + "','" + DrpP4.SelectedItem + "','" + p4 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc4','" + EndUserDesp4.Text + "')");
                                    obj.exec(P1);
                                    obj.closecon();
                                }
                                p4++;
                            }


                            //ProductCode 5
                            int p5 = 1;
                            foreach (GridViewRow g5 in ProductCode5Grid1.Rows)
                            {

                                string ProcessingCode1 = (g5.FindControl("TextBox1") as TextBox).Text;
                                string ProcessingCode2 = (g5.FindControl("TextBox2") as TextBox).Text;
                                string ProcessingCode3 = (g5.FindControl("TextBox3") as TextBox).Text;

                                if (TxtProductCode5.Text != "")
                                {
                                    string P1 = ("INSERT INTO [dbo].[TCASCDtl] ([ItemNo],[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId],[Enduserdesc]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode5.Text + "','" + TxtProQty5.Text + "','" + DrpP5.SelectedItem + "','" + p5 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc5','" + EndUserDesp5.Text + "')");
                                    obj.exec(P1);
                                    obj.closecon();
                                }
                                p5++;
                            }
                            BindItemMaster();
                            ItemAddGrid.Visible = true;
                            ItemDiv.Visible = true;
                            BtnAddNEWItem.Visible = false;
                            SummaryCalculate();
                            Itemclear();
                        }
                        else
                        {
                            lblitemalert.Visible = true;
                            lblitemalert.Text = "Maximum Number of Items are Not Exceed 50";
                        }
                    }

                    else
                    {

                        string Touch_user = Session["UserId"].ToString();
                        string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        //   var InvoiceDate = DateTime.Parse(this.txtinvDate.Value, new CultureInfo("en-US", true));

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


                        string StrQuery1 = ("update [dbo].[TranshipmentItemDtl]  set InMAWBOBL='" + TxtInMAWBOBL.Text + "',OutMAWBOBL='" + TxtOutMAWBOBL.Text + "',[HSCode]='" + TxtHSCodeItem.Text + "',[Description]='" + TxtDescription.Text + "',[DGIndicator]='" + ChkBGIndicator.Checked.ToString() + "',[Contry]= '" + TxtCountryItem.Text + "',[Brand]='" + TxtBrand.Text + "',[Model]='" + TxtModel.Text + "',[DrpVehicleType]='" + DrpVehicleType.SelectedItem.Text + "',[Enginecapacity]='" + txtengine.Text + "',[Engineuom]='" + DrpVehicleCapacity.SelectedItem.Text + "',[Orginregdate]='" + Convert.ToDateTime(orgindate).ToString("yyyy/MM/dd") + "',[InHAWBOBL]='" + TxtHAWB.Text + "',[OutHAWBOBL]='" + txtOutHAWB.Text + "',[DutiableQty]='" + TxtTotalDutiableQuantity.Text + "',[DutiableUOM]='" + TDQUOM.SelectedItem.ToString() + "',[TotalDutiableQty]='" + txttotDutiableQty.Text + "',[TotalDutiableUOM]='" + ddptotDutiableQty.SelectedItem.ToString() + "',[InvoiceQuantity]='" + TxtInvQty.Text + "',[HSQty]='" + TxtHSQuantity.Text + "', [HSUOM]='" + HSQTYUOM.SelectedItem + "',[AlcoholPer]='" + txtAlcoholPer.Text + "',[ChkUnitPrice]='" + ChkUnitPrice.Checked + "',[UnitPrice]='" + TxtUnitPrice.Text + "',[UnitPriceCurrency]='" + DRPCurrency.SelectedItem + "',[ExchangeRate]='" + TxtExchangeRate.Text + "',[SumExchangeRate]='" + TxtSumExRate.Text + "',[TotalLineAmount]='" + TxtTotalLineAmount.Text + "',[InvoiceCharges]='" + TxtTotalLineCharges.Text + "',[CIFFOB]='" + TxtCIFFOB.Text + "',[OPQty]='" + TxtOPQty.Text + "',[OPUOM]='" + DRPOPQUOM.SelectedItem + "',[IPQty]='" + TxtIPQty.Text + "',[IPUOM]='" + DRPIPQUOM.SelectedItem + "',[InPqty]='" + TxtINPQty.Text + "',[InPUOM]='" + DRPINNPQUOM.SelectedItem + "',[ImPQty]='" + TxtIMPQty.Text + "',[ImPUOM]='" + DRPIMPQUOM.SelectedItem + "',[PreferentialCode]='" + DrpPreferentialCode.SelectedItem + "',[GSTRate]='" + ItemGSTRate.Text + "',[GSTUOM]='" + ItemGSTUOM.Text + "',[GSTAmount]='" + TxtItemSumGST.Text + "',[ExciseDutyRate]='" + TxtExciseDutyRate.Text + "', [ExciseDutyUOM]='" + TxtExciseDutyUOM.Text + "',[ExciseDutyAmount]='" + TxtSumExciseDuty.Text + "',[CustomsDutyRate]='" + TxtCustomsDutyRate.Text + "',[CustomsDutyUOM]='" + TxtCustomsDutyUOM.Text + "',[CustomsDutyAmount]='" + TxtSumCustomsDuty.Text + "',[OtherTaxRate]='" + TxtOtherTaxRate.Text + "',[OtherTaxUOM]='" + DrpOtherUOM.SelectedItem + "',[OtherTaxAmount]='" + TxtSumOtherTaxRate.Text + "',[CurrentLot]='" + TxtCurrentLot.Text + "',[PreviousLot]='" + TxtPreviousLot.Text + "',[Making]='" + DrpMaking.SelectedItem + "',[ShippingMarks1]='" + txtShippingMarks1.Text + "',[ShippingMarks2]='" + txtShippingMarks2.Text + "',[ShippingMarks3]='" + txtShippingMarks3.Text + "',[ShippingMarks4]='" + txtShippingMarks4.Text + "',OptionalChrgeUOM='" + DrpOptionalUom.SelectedItem.Text + "',[Optioncahrge]='" + TxtOptionalPrice.Text + "',[OptionalSumtotal]='" + TxtOptionalExchageRate.Text + "',[OptionalSumExchage]='" + TxtOptionalSumExRate.Text + "',[TouchUser]='" + Touch_user + "',[TouchTime]='" + strTime + "' where  MessageType='TNPDEC' AND PermitId='" + txt_code.Text + "' and ItemNo='" + TxtSerialNo.Text + "'");
                        obj.exec(StrQuery1);
                        obj.closecon();

                        string cpc = ("delete from TCASCDtl where PermitId='" + txt_code.Text + "' and CASCId='Casc1' and ItemNo='" + TxtSerialNo.Text + "'");
                        obj.exec(cpc);
                        obj.closecon();
                        if (string.IsNullOrWhiteSpace(TxtProQty1.Text))
                        {
                            TxtProQty1.Text = "0.00";
                        }
                        if (string.IsNullOrWhiteSpace(TxtProQty2.Text))
                        {
                            TxtProQty2.Text = "0.00";
                        }
                        if (string.IsNullOrWhiteSpace(TxtProQty3.Text))
                        {
                            TxtProQty3.Text = "0.00";


                        }
                        if (string.IsNullOrWhiteSpace(TxtProQty4.Text))
                        {
                            TxtProQty4.Text = "0.00";
                        }
                        if (string.IsNullOrWhiteSpace(TxtProQty5.Text))
                        {
                            TxtProQty5.Text = "0.00";
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
                                string P1 = ("INSERT INTO [dbo].[TCASCDtl] ([ItemNo],[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId],[Enduserdesc]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode1.Text + "','" + TxtProQty1.Text + "','" + DrpP1.SelectedItem + "','" + p1 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc1','" + EndUserDesp1.Text + "')");
                                obj.exec(P1);
                                obj.closecon();
                            }
                            p1++;
                        }

                        string cpc2 = ("delete from TCASCDtl where PermitId='" + txt_code.Text + "' and CASCId='Casc2' and ItemNo='" + TxtSerialNo.Text + "'");
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
                                string P1 = ("INSERT INTO [dbo].[TCASCDtl] ([ItemNo],[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId],[Enduserdesc]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode2.Text + "','" + TxtProQty2.Text + "','" + DrpP2.SelectedItem + "','" + p2 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc2','" + EndUserDesp2.Text + "')");
                                obj.exec(P1);
                                obj.closecon();
                            }
                            p2++;
                        }

                        string cpc3 = ("delete from TCASCDtl where PermitId='" + txt_code.Text + "' and CASCId='Casc3' and ItemNo='" + TxtSerialNo.Text + "'");
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
                                string P1 = ("INSERT INTO [dbo].[TCASCDtl] ([ItemNo],[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId],[Enduserdesc]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode3.Text + "','" + TxtProQty3.Text + "','" + DrpP3.SelectedItem + "','" + p3 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc3','" + EndUserDesp3.Text + "')");
                                obj.exec(P1);
                                obj.closecon();
                            }
                            p3++;
                        }
                        string cpc4 = ("delete from TCASCDtl where PermitId='" + txt_code.Text + "' and CASCId='Casc4' and ItemNo='" + TxtSerialNo.Text + "'");
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
                                string P1 = ("INSERT INTO [dbo].[TCASCDtl] ([ItemNo],[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId],[Enduserdesc]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode4.Text + "','" + TxtProQty4.Text + "','" + DrpP4.SelectedItem + "','" + p4 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc4','" + EndUserDesp4.Text + "')");
                                obj.exec(P1);
                                obj.closecon();
                            }
                            p4++;
                        }
                        string cpc5 = ("delete from TCASCDtl where PermitId='" + txt_code.Text + "' and CASCId='Casc5' and ItemNo='" + TxtSerialNo.Text + "'");
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
                                string P1 = ("INSERT INTO [dbo].[TCASCDtl] ([ItemNo],[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId],[Enduserdesc]) VALUES ('" + TxtSerialNo.Text + "','" + TxtProductCode5.Text + "','" + TxtProQty5.Text + "','" + DrpP5.SelectedItem + "','" + p5 + "','" + ProcessingCode1 + "','" + ProcessingCode2 + "','" + ProcessingCode3 + "','" + txt_code.Text + "','" + TxtMsgType.Text + "','" + Touch_user + "','" + strTime + "','Casc5','" + EndUserDesp5.Text + "')");
                                obj.exec(P1);
                                obj.closecon();
                            }
                            p5++;
                        }






                        string SumItem = "";
                        string qry11 = "select Count(ItemNo) as InvCount from dbo.TranshipmentItemDtl where PermitId='" + txt_code.Text + "' and MessageType='TNPDEC'";
                        obj.dr = obj.ret_dr(qry11);
                        while (obj.dr.Read())
                        {
                            SumItem = obj.dr[0].ToString();
                            txtnoofitm.Text = SumItem;
                        }

                        //Sum of Item Amount

                        string SumofItemAmount = "";
                        string qry11s2Q = "select Distinct UnitPriceCurrency,Sum(TotalLineAmount) as TotalLineAmount from dbo.TranshipmentItemDtl where PermitId='" + txt_code.Text + "' and MessageType='TNPDEC' GROUP BY UnitPriceCurrency  ORDER BY UnitPriceCurrency DESC";
                        obj.dr = obj.ret_dr(qry11s2Q);
                        while (obj.dr.Read())
                        {
                            SumofItemAmount = obj.dr[0].ToString() + " : " + obj.dr[1].ToString();
                            Label lbl = new Label();
                            lbl.Text = SumofItemAmount;
                            //lblinvoiceAmt.Text = reader["TotalLineAmount"].ToString();
                            lbl.BackColor = System.Drawing.Color.WhiteSmoke;
                            lbl.BorderStyle = BorderStyle.Solid;
                            lbl.BorderWidth = 1;
                            lbl.Width = 200;
                            //totinvAmt = totinvAmt + "  -  " + lbl.Text + " " + Environment.NewLine;
                            div1.Controls.Add(lbl);
                            div1.Controls.Add(new LiteralControl("<br />"));
                            //div2.Controls.Add(lbl);
                            //div2.Controls.Add(new LiteralControl("<br />"));
                        }


                        //Total GST Amount

                        string TotalGSTAmount = "";
                        string qry11s2 = "select SUM(GSTAmount) as  GSTAmount  from dbo.TranshipmentItemDtl where PermitId='" + txt_code.Text + "' and MessageType='TNPDEC'";
                        obj.dr = obj.ret_dr(qry11s2);
                        while (obj.dr.Read())
                        {
                            TotalGSTAmount = obj.dr[0].ToString();
                            txttotgstAmt.Text = TotalGSTAmount;
                            txtAmtPayble.Text = TotalGSTAmount;
                        }

                        //Total CIF/FOB Value
                        string TotalCIFFOBValue = "";
                        string qry11sS2 = "select SUM(CIFFOB) as  GSTAmount  from dbo.TranshipmentItemDtl where PermitId='" + txt_code.Text + "' and MessageType='TNPDEC'";
                        obj.dr = obj.ret_dr(qry11sS2);
                        while (obj.dr.Read())
                        {
                            TotalCIFFOBValue = obj.dr[0].ToString();
                            txtfobval.Text = TotalCIFFOBValue;

                        }
                        SummaryCalculate();
                        AddItemSummary();
                        ItemAddGrid.Visible = true;
                        ItemDiv.Visible = true;
                        BtnAddNEWItem.Visible = false;
                        Itemclear();
                        BindItemMaster();
                    }

                }
                transhipment.Update();
                transhipitem.Update();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void btnresetitem_Click(object sender, EventArgs e)
        {
            Itemclear();
        }

        protected void btnnextitem_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[TabContainer1.ActiveTabIndex + 1];
            transhipment.Update();
            transhipitem.Update();
            chkaeo.Focus();
        }

        protected void btnprevcpc_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[TabContainer1.ActiveTabIndex - 1];
            transhipment.Update();
            transhipcpc.Update();
            TxtHAWB.Focus();
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
            transhipment.Update();
            transhipcpc.Update();
            txttrdremrk.Focus();
        }

        protected void btnprevsum_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[TabContainer1.ActiveTabIndex - 1];
            transhipment.Update();
            transhipsummery.Update();
            chkaeo.Focus();
        }

        protected void btnsavesum_Click(object sender, EventArgs e)
        {
            BtnSaveDraft_Click(null,null);
        }

        protected void btnresetsum_Click(object sender, EventArgs e)
        {

        }

        protected void btnnextsum_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[TabContainer1.ActiveTabIndex + 1];
            transhipment.Update();
            transhipsummery.Update();
        }

        protected void TxtOPQty_TextChanged(object sender, EventArgs e)
        {
            string[] ss = TxtHSCodeItem.Text.Split(':');
            string qry1112 = "select * from HSCode where HSCode='" + ss[0].ToString() + "'";
            obj.dr = obj.ret_dr(qry1112);

            // int typeid = 0;

            while (obj.dr.Read())
            {

                kgmvis = obj.dr["Kgmvisible"].ToString();



                BindProduct1();
            }

            if (TxtOPQty.Text != "")
            {

                double T1, T2, T3, T4, T8;
                bool A = double.TryParse(TxtOPQty.Text.Trim(), out T1);
                bool B = double.TryParse(TxtIPQty.Text.Trim(), out T2);
                bool C = double.TryParse(TxtTotalDutiableQuantity.Text.Trim(), out T3);
                bool D = double.TryParse(TxtIMPQty.Text.Trim(), out T4);
                bool F = double.TryParse(TxtINPQty.Text.Trim(), out T8);
                double pacqty = 0;
                if (T1 > 0)
                {
                    pacqty = T1;
                }
                if (T2 > 0)
                {
                    pacqty =pacqty* T2;
                }
                if (T4 > 0)
                {
                    pacqty = pacqty * T4;
                }
                if (T8 > 0)
                {
                    pacqty = pacqty * T8;
                }

                if (TDQUOM.SelectedItem.Text == "LTR")
                {

                    if (A && B)
                    {
                        txttotDutiableQty.Text = (pacqty * T3).ToString();
                        TxtHSQuantity.Text = (pacqty * T3).ToString();
                    }
                }
                else if (TDQUOM.SelectedItem.Text == "KGM" && kgmvis == "MULTIPLE")
                {
                    if (A && B)
                    {
                        txttotDutiableQty.Text = ((pacqty * T3)).ToString();

                    }
                }
                else if (TDQUOM.SelectedItem.Text == "KGM" && kgmvis == "DIVIDE")
                {
                    if (A && B)
                    {
                        txttotDutiableQty.Text = ((pacqty * T3) / 1000).ToString();


                    }
                }
                else if (TDQUOM.SelectedItem.Text == "STK")
                {
                    if (A && B)
                    {
                        txttotDutiableQty.Text = ((pacqty * T3)).ToString();
                        TxtHSQuantity.Text = ((pacqty * T3) / 1000).ToString();

                    }
                }
                else if (TDQUOM.SelectedItem.Text == "DAL")
                {
                    if (A && B)
                    {
                        txttotDutiableQty.Text = ((pacqty * T3)).ToString();

                    }
                }

            }
            DRPOPQUOM.Focus();
        }

        protected void TxtIPQty_TextChanged(object sender, EventArgs e)
        {
            string[] ss = TxtHSCodeItem.Text.Split(':');
            string qry1112 = "select * from HSCode where HSCode='" + ss[0].ToString() + "'";
            obj.dr = obj.ret_dr(qry1112);

            // int typeid = 0;

            while (obj.dr.Read())
            {

                kgmvis = obj.dr["Kgmvisible"].ToString();



                BindProduct1();
            }

            if (TxtIPQty.Text != "")
            {

                double T1, T2, T3, T4, T8;
                bool A = double.TryParse(TxtOPQty.Text.Trim(), out T1);
                bool B = double.TryParse(TxtIPQty.Text.Trim(), out T2);
                bool C = double.TryParse(TxtTotalDutiableQuantity.Text.Trim(), out T3);
                bool D = double.TryParse(TxtIMPQty.Text.Trim(), out T4);
                bool F = double.TryParse(TxtINPQty.Text.Trim(), out T8);
                double pacqty = 0;
                if (T1 > 0)
                {
                    pacqty = T1;
                }
                if (T2 > 0)
                {
                    pacqty = pacqty * T2;
                }
                if (T4 > 0)
                {
                    pacqty = pacqty * T4;
                }
                if (T8 > 0)
                {
                    pacqty = pacqty * T8;
                }

                if (TDQUOM.SelectedItem.Text == "LTR")
                {

                    if (A && B)
                    {
                        txttotDutiableQty.Text = (pacqty * T3).ToString();
                        TxtHSQuantity.Text = (pacqty * T3).ToString();
                    }
                }
                else if (TDQUOM.SelectedItem.Text == "KGM" && kgmvis == "MULTIPLE")
                {
                    if (A && B)
                    {
                        txttotDutiableQty.Text = ((pacqty * T3)).ToString();

                    }
                }
                else if (TDQUOM.SelectedItem.Text == "KGM" && kgmvis == "DIVIDE")
                {
                    if (A && B)
                    {
                        txttotDutiableQty.Text = ((pacqty * T3) / 1000).ToString();


                    }
                    else if (TDQUOM.SelectedItem.Text == "STK")
                    {
                        if (A && B)
                        {
                            txttotDutiableQty.Text = ((pacqty * T3)).ToString();
                            TxtHSQuantity.Text = ((pacqty * T3) / 1000).ToString();

                        }
                    }
                    else if (TDQUOM.SelectedItem.Text == "DAL")
                    {
                        if (A && B)
                        {
                            txttotDutiableQty.Text = ((pacqty * T3)).ToString();

                        }
                    }

                }
            }
            DRPIPQUOM.Focus();
        }

        protected void TxtINPQty_TextChanged(object sender, EventArgs e)
        {
            string[] ss = TxtHSCodeItem.Text.Split(':');
            string qry1112 = "select * from HSCode where HSCode='" + ss[0].ToString() + "'";
            obj.dr = obj.ret_dr(qry1112);

            // int typeid = 0;

            while (obj.dr.Read())
            {

                kgmvis = obj.dr["Kgmvisible"].ToString();



                BindProduct1();
            }

            if (TxtINPQty.Text != "")
            {

                double T1, T2, T3, T4, T8;
                bool A = double.TryParse(TxtOPQty.Text.Trim(), out T1);
                bool B = double.TryParse(TxtIPQty.Text.Trim(), out T2);
                bool C = double.TryParse(TxtTotalDutiableQuantity.Text.Trim(), out T3);
                bool D = double.TryParse(TxtIMPQty.Text.Trim(), out T4);
                bool F = double.TryParse(TxtINPQty.Text.Trim(), out T8);
                double pacqty = 0;
                if (T1 > 0)
                {
                    pacqty = T1;
                }
                if (T2 > 0)
                {
                    pacqty = pacqty * T2;
                }
                if (T4 > 0)
                {
                    pacqty = pacqty * T4;
                }
                if (T8 > 0)
                {
                    pacqty = pacqty * T8;
                }

                if (TDQUOM.SelectedItem.Text == "LTR")
                {

                    if (A && B)
                    {
                        txttotDutiableQty.Text = (pacqty * T3).ToString();
                        TxtHSQuantity.Text = (pacqty * T3).ToString();
                    }
                }
                else if (TDQUOM.SelectedItem.Text == "KGM" && kgmvis == "MULTIPLE")
                {
                    if (A && B)
                    {
                        txttotDutiableQty.Text = ((pacqty * T3)).ToString();

                    }
                }
                else if (TDQUOM.SelectedItem.Text == "KGM" && kgmvis == "DIVIDE")
                {
                    if (A && B)
                    {
                        txttotDutiableQty.Text = ((pacqty * T3) / 1000).ToString();


                    }
                    else if (TDQUOM.SelectedItem.Text == "STK")
                    {
                        if (A && B)
                        {
                            txttotDutiableQty.Text = ((pacqty * T3)).ToString();
                            TxtHSQuantity.Text = ((pacqty * T3) / 1000).ToString();

                        }
                    }
                    else if (TDQUOM.SelectedItem.Text == "DAL")
                    {
                        if (A && B)
                        {
                            txttotDutiableQty.Text = ((pacqty * T3)).ToString();

                        }
                    }

                }
            }
            DRPINNPQUOM.Focus();
        }

        protected void TxtIMPQty_TextChanged(object sender, EventArgs e)
        {
            string[] ss = TxtHSCodeItem.Text.Split(':');
            string qry1112 = "select * from HSCode where HSCode='" + ss[0].ToString() + "'";
            obj.dr = obj.ret_dr(qry1112);

            // int typeid = 0;

            while (obj.dr.Read())
            {

                kgmvis = obj.dr["Kgmvisible"].ToString();



                BindProduct1();
            }

            if (TxtIMPQty.Text != "")
            {

                double T1, T2, T3, T4, T8;
                bool A = double.TryParse(TxtOPQty.Text.Trim(), out T1);
                bool B = double.TryParse(TxtIPQty.Text.Trim(), out T2);
                bool C = double.TryParse(TxtTotalDutiableQuantity.Text.Trim(), out T3);
                bool D = double.TryParse(TxtIMPQty.Text.Trim(), out T4);
                bool F = double.TryParse(TxtINPQty.Text.Trim(), out T8);
                double pacqty = 0;
                if (T1 > 0)
                {
                    pacqty = T1;
                }
                if (T2 > 0)
                {
                    pacqty = pacqty * T2;
                }
                if (T4 > 0)
                {
                    pacqty = pacqty * T4;
                }
                if (T8 > 0)
                {
                    pacqty = pacqty * T8;
                }

                if (TDQUOM.SelectedItem.Text == "LTR")
                {

                    if (A && B)
                    {
                        txttotDutiableQty.Text = (pacqty * T3).ToString();
                        TxtHSQuantity.Text = (pacqty * T3).ToString();
                    }
                }
                else if (TDQUOM.SelectedItem.Text == "KGM" && kgmvis == "MULTIPLE")
                {
                    if (A && B)
                    {
                        txttotDutiableQty.Text = ((pacqty * T3)).ToString();

                    }
                }
                else if (TDQUOM.SelectedItem.Text == "KGM" && kgmvis == "DIVIDE")
                {
                    if (A && B)
                    {
                        txttotDutiableQty.Text = ((pacqty * T3) / 1000).ToString();


                    }
                    else if (TDQUOM.SelectedItem.Text == "STK")
                    {
                        if (A && B)
                        {
                            txttotDutiableQty.Text = ((pacqty * T3)).ToString();
                            TxtHSQuantity.Text = ((pacqty * T3) / 1000).ToString();

                        }
                    }
                    else if (TDQUOM.SelectedItem.Text == "DAL")
                    {
                        if (A && B)
                        {
                            txttotDutiableQty.Text = ((pacqty * T3)).ToString();

                        }
                    }

                }
            }
            DRPIMPQUOM.Focus();
        }

        protected void TxtTotalDutiableQuantity_TextChanged(object sender, EventArgs e)
        {
            string[] ss = TxtHSCodeItem.Text.Split(':');
            string qry1112 = "select * from HSCode where HSCode='" + ss[0].ToString() + "'";
            obj.dr = obj.ret_dr(qry1112);

            // int typeid = 0;

            while (obj.dr.Read())
            {

                kgmvis = obj.dr["Kgmvisible"].ToString();



                BindProduct1();
            }

            if (TxtTotalDutiableQuantity.Text != "")
            {


                double T1, T2, T3, T4, T8;
                bool A = double.TryParse(TxtIPQty.Text.Trim(), out T1);
                bool B = double.TryParse(TxtOPQty.Text.Trim(), out T2);
                bool C = double.TryParse(TxtTotalDutiableQuantity.Text.Trim(), out T3);
                bool D = double.TryParse(TxtIMPQty.Text.Trim(), out T4);
                bool F = double.TryParse(TxtINPQty.Text.Trim(), out T8);

                if (T4 == 0 && T8 == 0)
                {
                    if (TDQUOM.SelectedItem.Text == "LTR")
                    {

                        if (A && B)
                        {
                            txttotDutiableQty.Text = (T1 * T2 * T3).ToString();
                            TxtHSQuantity.Text = (T1 * T2 * T3).ToString();
                        }
                    }
                    else if (TDQUOM.SelectedItem.Text == "KGM" && kgmvis == "MULTIPLE")
                    {
                        if (A && B)
                        {
                            txttotDutiableQty.Text = ((T1 * T2 * T3)).ToString();

                        }
                    }
                    else if (TDQUOM.SelectedItem.Text == "KGM" && kgmvis == "DIVIDE")
                    {
                        if (A && B)
                        {
                            txttotDutiableQty.Text = ((T1 * T2 * T3) / 1000).ToString();


                        }
                        else if (TDQUOM.SelectedItem.Text == "STK")
                        {
                            if (A && B)
                            {
                                txttotDutiableQty.Text = ((T1 * T2 * T3)).ToString();
                                TxtHSQuantity.Text = ((T1 * T2 * T3) / 1000).ToString();

                            }
                        }
                        else if (TDQUOM.SelectedItem.Text == "DAL")
                        {
                            if (A && B)
                            {
                                txttotDutiableQty.Text = ((T1 * T2 * T3)).ToString();

                            }
                        }

                    }
                }
                else if (T1 != 0 && T2 != 0 && T4 != 0 && T8 != 0)
                {

                    if (TDQUOM.SelectedItem.Text == "LTR")
                    {

                        if (A && B)
                        {
                            txttotDutiableQty.Text = (T1 * T2 * T3 * T4 * T8).ToString();
                            TxtHSQuantity.Text = (T1 * T2 * T3 * T4 * T8).ToString();
                        }
                    }
                    else if (TDQUOM.SelectedItem.Text == "KGM" && kgmvis == "MULTIPLE")
                    {
                        if (A && B)
                        {
                            txttotDutiableQty.Text = ((T1 * T2 * T3 * T4 * T8)).ToString();

                        }
                    }
                    else if (TDQUOM.SelectedItem.Text == "KGM" && kgmvis == "DIVIDE")
                    {
                        if (A && B)
                        {
                            txttotDutiableQty.Text = ((T1 * T2 * T3 * T4 * T8) / 1000).ToString();


                        }
                        else if (TDQUOM.SelectedItem.Text == "STK")
                        {
                            if (A && B)
                            {
                                txttotDutiableQty.Text = ((T1 * T2 * T3 * T4 * T8)).ToString();
                                TxtHSQuantity.Text = ((T1 * T2 * T3 * T8 * T4) / 1000).ToString();

                            }
                        }
                        else if (TDQUOM.SelectedItem.Text == "DAL")
                        {
                            if (A && B)
                            {
                                txttotDutiableQty.Text = ((T1 * T2 * T3 * T4 * T8)).ToString();

                            }
                        }

                    }
                }
                else if (T4 != 0 && T8 == 0)
                {

                    if (TDQUOM.SelectedItem.Text == "LTR")
                    {

                        if (A && B)
                        {
                            txttotDutiableQty.Text = (T1 * T2 * T3 * T4).ToString();
                            TxtHSQuantity.Text = (T1 * T2 * T3 * T4).ToString();
                        }
                    }
                    else if (TDQUOM.SelectedItem.Text == "KGM" && kgmvis == "MULTIPLE")
                    {
                        if (A && B)
                        {
                            txttotDutiableQty.Text = ((T1 * T2 * T3 * T4)).ToString();

                        }
                    }
                    else if (TDQUOM.SelectedItem.Text == "KGM" && kgmvis == "DIVIDE")
                    {
                        if (A && B)
                        {
                            txttotDutiableQty.Text = ((T1 * T2 * T3 * T4) / 1000).ToString();


                        }
                        else if (TDQUOM.SelectedItem.Text == "STK")
                        {
                            if (A && B)
                            {
                                txttotDutiableQty.Text = ((T1 * T2 * T3 * T4)).ToString();
                                TxtHSQuantity.Text = ((T1 * T2 * T3 * T4) / 1000).ToString();

                            }
                        }
                        else if (TDQUOM.SelectedItem.Text == "DAL")
                        {
                            if (A && B)
                            {
                                txttotDutiableQty.Text = ((T1 * T2 * T3 * T4)).ToString();

                            }
                        }

                    }
                }

                else if (T4 == 0 && T8 != 0)
                {

                    if (TDQUOM.SelectedItem.Text == "LTR")
                    {

                        if (A && B)
                        {
                            txttotDutiableQty.Text = (T1 * T2 * T3 * T8).ToString();
                            TxtHSQuantity.Text = (T1 * T2 * T3 * T8).ToString();
                        }
                    }
                    else if (TDQUOM.SelectedItem.Text == "KGM" && kgmvis == "MULTIPLE")
                    {
                        if (A && B)
                        {
                            txttotDutiableQty.Text = ((T1 * T2 * T3 * T8)).ToString();

                        }
                    }
                    else if (TDQUOM.SelectedItem.Text == "KGM" && kgmvis == "DIVIDE")
                    {
                        if (A && B)
                        {
                            txttotDutiableQty.Text = ((T1 * T2 * T3 * T8) / 1000).ToString();


                        }
                        else if (TDQUOM.SelectedItem.Text == "STK")
                        {
                            if (A && B)
                            {
                                txttotDutiableQty.Text = ((T1 * T2 * T3 * T8)).ToString();
                                TxtHSQuantity.Text = ((T1 * T2 * T3 * T8) / 1000).ToString();

                            }
                        }
                        else if (TDQUOM.SelectedItem.Text == "DAL")
                        {
                            if (A && B)
                            {
                                txttotDutiableQty.Text = ((T1 * T2 * T3 * T8)).ToString();

                            }
                        }

                    }
                }

            }
            TDQUOM.Focus();
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
            transhipment.Update();
            TxtImpCode.Focus();
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
                        TxtImpName.Text = "";
                        TxtImpName1.Text = "";
                        TxtImpCRUEI.Text = "";
                        TxtImpCode.Text = requestor;
                        TxtImpName.Text = requestType;
                        TxtImpName1.Text = status;
                        TxtImpCRUEI.Text = crueis;

                        lblimporterparty.Text = crueis + " - " + requestType + " " + status;
                    }
                    // DECCOMPSearGRID.Visible = false;

                }
            }
            transhipment.Update();
            TxtExpCode.Focus();
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

                        LblHandAgent.Text = crueis + " - " + requestType + " - " + status;
                        //  UpdatePanelDCS.Update();

                    }
                    // DECCOMPSearGRID.Visible = false;

                }
            }
            transhipment.Update();
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
            transhipment.Update();
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
            transhipment.Update();
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
            transhipment.Update();
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
                    var lblcsd = row.FindControl("ConsigneeSubDivi") as Label;
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
                        string consub = lblcs.Text;
                        string consubdivi = lblcsd.Text;
                        string conportal = lblcp.Text;
                        string concountry = country.Text;


                        ConsigneeCode.Text = "";
                        ConsigneeAddress.Text = "";
                        ConsigneeSub.Text = "";
                        ConsigneeSubDivi.Text = "";
                        ConsigneeCRUEI.Text = "";
                        ConsigneeName.Text = "";
                        ConsigneeAddress1.Text = "";
                        ConsigneePostal.Text = "";
                        ConsigneeName1.Text = "";
                        ConsigneeCity.Text = "";
                        ConsigneeCountry.Text = "";


                        ConsigneeCode.Text = requestor;
                        ConsigneeName.Text = requestType;
                        ConsigneeName1.Text = status;
                        ConsigneeAddress.Text = consigneaddress;
                        ConsigneeAddress1.Text = conadd1;
                        ConsigneeCity.Text = consigneecity;
                        ConsigneeSub.Text = consub;
                        ConsigneeCRUEI.Text = crueis;
                        ConsigneeSubDivi.Text = consubdivi;                                                
                        ConsigneePostal.Text = conportal;                                               
                        ConsigneeCountry.Text = concountry;                        
                    }                    
                }
            }
            transhipment.Update();
            EndUserCode.Focus();
        }

        protected void ConsigneeGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(ConsigneeGrid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void EndUserGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //  DECCOMPSearGRID.SelectedIndex = Convert.ToInt16(e.CommandArgument);
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = EndUserGrid.Rows[rowIndex];
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
                    var ConsigneeSubDivi = row.FindControl("ConsigneeSubDivi") as Label;
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
                    string ConsigneeSubDivif = ConsigneeSubDivi.Text;

                    string ConsigneePostal12 = ConsigneePostal1.Text;
                    string ConsigneeCountry12 = ConsigneeCountry1.Text;


                    EndUserCode.Text = "";
                    EndUserName.Text = "";
                    EndUserName1.Text = "";
                    EndUserCrueo.Text = "";
                    EndUserAddress.Text = "";
                    EndUserAddress1.Text = "";
                    EndUserCity.Text = "";
                    EndUserSubCode.Text = "";
                    EndUserSubCodeDivi.Text = "";
                    EndUserPostal.Text = "";
                    EndUserCountry.Text = "";



                    EndUserCode.Text = requestor;
                    EndUserName.Text = requestType;
                    EndUserName1.Text = status;
                    EndUserCrueo.Text = crueis;
                    EndUserAddress.Text = ConsigneeAddress12;
                    EndUserAddress1.Text = ConsigneeAddress112;
                    EndUserCity.Text = ConsigneeCity12;
                    EndUserSubCode.Text = ConsigneeSub12;
                    EndUserSubCodeDivi.Text = ConsigneeSubDivif;
                    EndUserPostal.Text = ConsigneePostal12;
                    EndUserCountry.Text = ConsigneeCountry12;
                    //  UpdatePanelDCS.Update();

                }
                // DECCOMPSearGRID.Visible = false;


            }
            transhipment.Update();
            btnpreviousparty.Focus();
        }

        protected void EndUserGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(EndUserGrid, "Select$" + e.Row.RowIndex);
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
                    //   var cruei1 = row.FindControl("lblCRUEI") as Label;

                    if (lblCode1 != null && lblName1 != null && lblName11 != null)
                    {

                        //UpdatePanelDCS.Update();
                        //Get values
                        string requestor = lblCode1.Text;
                        string requestType = lblName1.Text;
                        string status = lblName11.Text;
                        // string crueis = cruei1.Text;
                        TxtLoadShort.Text = "";
                        TxtLoad.Text = "";

                        TxtLoadShort.Text = requestor;
                        TxtLoad.Text = requestType;

                        //  UpdatePanelDCS.Update();

                    }
                    // DECCOMPSearGRID.Visible = false;

                }
            }
            transhipment.Update();
            if (TextMode.Text == "1 : Sea")
            {
                TxtVoyageno.Focus();
            }
            else if (TextMode.Text == "2 : Rail" || TextMode.Text == "3 : Road" || TextMode.Text == "5 : Mail" || TextMode.Text == "7 : Pipeline" || TextMode.Text == "N : Not Required" || TextMode.Text == "6 : Multi-model(Not in use)")
            {
                TxtConRefNo.Focus();
            }

            else if (TextMode.Text == "4 : Air")
            {
                txtflight.Focus();
            }
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
                //  DECCOMPSearGRID.SelectedIndex = Convert.ToInt16(e.CommandArgument);
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

                        //UpdatePanelDCS.Update();
                        //Get values
                        string requestor = lblCode1.Text;
                        string requestType = lblName1.Text;
                        string status = lblName11.Text;
                        // string crueis = cruei1.Text;
                        txtreLoctn.Text = "";
                        txtrelocDeta.Text = "";

                        txtreLoctn.Text = requestType;
                        txtrelocDeta.Text = status;

                        //  UpdatePanelDCS.Update();

                    }
                    // DECCOMPSearGRID.Visible = false;

                }
            }


            transhipment.Update();
            txtrecloctn.Focus();
        }

        protected void LocationGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(LocationGrid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void BtnItemAdd_Click1(object sender, EventArgs e)
        {

        }

        private void SummaryCalculate()
        {

            //SUM OF INVOICE
            //string SumInv = "";
            //string qry11 = "select Count(InvoiceNo) as InvCount from dbo.OutInvoiceDtl where PermitId='" + txt_code.Text + "' and MessageType='OUTDEC'";
            //obj.dr = obj.ret_dr(qry11);
            //while (obj.dr.Read())
            //{
            //    SumInv = obj.dr[0].ToString();
            //    txtnoofinv.Text = SumInv;
            //}
            //SUM OF ITEM
            string SumItem = "";
            string qry112 = "select Count(ItemNo) as ItemCount from dbo.TranshipmentItemDtl where PermitId='" + txt_code.Text + "' and MessageType='TNPDEC'";
            obj.dr = obj.ret_dr(qry112);
            while (obj.dr.Read())
            {
                SumItem = obj.dr[0].ToString();
                txtnoofitm.Text = SumItem;
            }

            ///Total Invoice CIF Value
            //string InvoiceCIFValue = "";
            //string qry112Q = "select sum(CIFSUMAmount) as InvoiceDtl from dbo.OutInvoiceDtl where PermitId='" + txt_code.Text + "' and MessageType='TNPDEC'";
            //obj.dr = obj.ret_dr(qry112Q);
            //while (obj.dr.Read())
            //{
            //    InvoiceCIFValue = obj.dr[0].ToString();
            //    txtcifVal.Text = InvoiceCIFValue;
            //}

            //Sum of Item Amount

            string SumofItemAmount = "";
            string qry11s2Q = "select Distinct UnitPriceCurrency,Sum(TotalLineAmount) as TotalLineAmount from dbo.TranshipmentItemDtl where PermitId='" + txt_code.Text + "' and MessageType='TNPDEC' GROUP BY UnitPriceCurrency  ORDER BY UnitPriceCurrency DESC";
            obj.dr = obj.ret_dr(qry11s2Q);
            while (obj.dr.Read())
            {
                SumofItemAmount = obj.dr[0].ToString()+" : "+obj.dr[1].ToString();
                Label lbl = new Label();
                lbl.Text = SumofItemAmount;
                //lblinvoiceAmt.Text = reader["TotalLineAmount"].ToString();
                lbl.BackColor = System.Drawing.Color.WhiteSmoke;
                lbl.BorderStyle = BorderStyle.Solid;
                lbl.BorderWidth = 1;
                lbl.Width = 200;
                //totinvAmt = totinvAmt + "  -  " + lbl.Text + " " + Environment.NewLine;
                div1.Controls.Add(lbl);
                div1.Controls.Add(new LiteralControl("<br />"));
                div2.Controls.Add(lbl);
                div2.Controls.Add(new LiteralControl("<br />"));
            }
            //TotalGSTAmount
            string TotalGSTAmount = "";
            string qry11s2 = "select SUM(GSTAmount) as  GSTAmount  from dbo.TranshipmentItemDtl where PermitId='" + txt_code.Text + "' and MessageType='TNPDEC'";
            obj.dr = obj.ret_dr(qry11s2);
            while (obj.dr.Read())
            {
                TotalGSTAmount = obj.dr[0].ToString();
                txttotgstAmt.Text = TotalGSTAmount;
                txtAmtPayble.Text = TotalGSTAmount;
            }
            lblTotItemGst.Text = txttotgstAmt.Text;
            //Total CIF/FOB Value
            string TotalCIFFOBValue = "";
            string qry11sS2 = "select SUM(CIFFOB) as  GSTAmount  from dbo.TranshipmentItemDtl where PermitId='" + txt_code.Text + "' and MessageType='TNPDEC'";
            obj.dr = obj.ret_dr(qry11sS2);
            while (obj.dr.Read())
            {
                TotalCIFFOBValue = obj.dr[0].ToString();
                txtfobval.Text = TotalCIFFOBValue;

            }


            string TotalGSTAmount1 = "", totalexamt = "", cusamt = "";
            string qry11s233 = "select SUM(GSTAmount) as  GSTAmount  from dbo.TranshipmentItemDtl where PermitId='" + txt_code.Text + "' and MessageType='TNPDEC'";
            obj.dr = obj.ret_dr(qry11s233);
            while (obj.dr.Read())
            {
                TotalGSTAmount1 = obj.dr[0].ToString();
                txttotgstAmt.Text = TotalGSTAmount1;
                // txtAmtPayble.Text = TotalGSTAmount;
            }

            string qry11s21 = "select SUM(ExciseDutyAmount) as  GSTAmount  from dbo.TranshipmentItemDtl where PermitId='" + txt_code.Text + "' and MessageType='TNPDEC'";
            obj.dr = obj.ret_dr(qry11s21);
            while (obj.dr.Read())
            {
                totalexamt = obj.dr[0].ToString();
                txttotexAmt.Text = totalexamt;
                // txtAmtPayble.Text = TotalGSTAmount;
            }
            string qry11s22 = "select SUM(CustomsDutyAmount) as  GSTAmount  from dbo.TranshipmentItemDtl where PermitId='" + txt_code.Text + "' and MessageType='TNPDEC'";
            obj.dr = obj.ret_dr(qry11s22);
            while (obj.dr.Read())
            {
                cusamt = obj.dr[0].ToString();
                txtcusdutyAmt.Text = cusamt;
                // txtAmtPayble.Text = TotalGSTAmount;
            }



            //AddDynamicLabels();
            transhipsummery.Update();
        }

        protected void TxtOceanBill_TextChanged(object sender, EventArgs e)
        {


            lbloblval.Text = TxtOceanBill.Text;
          
            transhipsummery.Update();
            TxtExpArrivalDate1.Focus();

        }

        protected void OUTWARDOcenbill_TextChanged(object sender, EventArgs e)
        {
            lbloutobl.Text = OUTWARDOcenbill.Text;
            transhipsummery.Update();
            ddpVessel.Focus();
        }

        protected void txtOutHAWB_TextChanged(object sender, EventArgs e)
        {
            lblouthbl.Text = txtOutHAWB.Text;
            transhipsummery.Update();

        }

        protected void txtwaybill_TextChanged(object sender, EventArgs e)
        {
            lbloblval.Text = txtwaybill.Text;
            transhipsummery.Update();

        }

        protected void OUTWARDAirwaybill_TextChanged(object sender, EventArgs e)
        {
            lbloblval.Text = OUTWARDAirwaybill.Text;
            transhipsummery.Update();
        }

        protected void TxttotalOuterPack_TextChanged(object sender, EventArgs e)
        {
            lblnoofpack.Text = TxttotalOuterPack.Text;
            transhipsummery.Update();
            DrptotalOuterPack.Focus();

        }

        protected void DrptotalOuterPack_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblnoofpack.Text = TxttotalOuterPack.Text + " - " + DrptotalOuterPack.SelectedItem.Text;
            transhipsummery.Update();
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

                }
                else
                {
                    decimal TtlPGW = Convert.ToDecimal(TxtTotalGrossWeight.Text) / Convert.ToDecimal(1000);
                    txtTtlPGW.Text = Convert.ToString(Math.Round(TtlPGW, 3));
                    DrpTtlPGW.ClearSelection();
                    DrpTtlPGW.Items.FindByText("TNE").Selected = true;

                }

            }


            transhipment.Update();
            transhipsummery.Update();
            DrpTotalGrossWeight.Focus();

         
        }

        protected void DrpTotalGrossWeight_SelectedIndexChanged(object sender, EventArgs e)
        {

            //lblgrossweight.Text = TxtTotalGrossWeight.Text + " - " + DrpTotalGrossWeight.SelectedItem.Text;
            //transhipsummery.Update();
            //DrpTotalGrossWeight.Focus();
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



            transhipment.Update();

            transhipsummery.Update();


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

        protected void DrpOutwardtrasMode_SelectedIndexChanged(object sender, EventArgs e)
        {
           // ReqValidatePageLoad();



            string checktrans = DrpInwardtrasMode.SelectedItem.ToString();

            if (checktrans == "1 : Sea" || checktrans == "4 : Air")
            {
                if (DrpDecType.SelectedItem.ToString() == "TTF : THRU TRANSHIPMENT WITHIN SAME FTZ" || DrpDecType.SelectedItem.ToString() == "TTI : THRU TRANSHIPMENT WITH INTER-GATEWAY MOVEMENT")
                {
                    OBLINOUT.Visible = true;
                }
                else
                {
                    OBLINOUT.Visible = false;
                }
            }
            else
            {
                OBLINOUT.Visible = false;
            }


            if (DrpOutwardtrasMode.SelectedItem.ToString() != "--Select--")
            {
                outtr.Visible = false;
            }
            if (DrpOutwardtrasMode.SelectedValue != "")
            {

                string TransMode = DrpOutwardtrasMode.SelectedItem.ToString();
                TxtExpMode.Text = TransMode;
                if (DrpOutwardtrasMode.SelectedItem.ToString() != "--Select--")
                {
                    //outtr.Visible = false;
                    TxtExpMode.Text = TransMode;
                    OUTWARDFlight.Visible = false;
                    OUTWARDSea.Visible = false;
                    // OUTWARDVesl.Visible = false;
                    OUTWARDOther.Visible = false;
                    outw.Visible = true;
                    // outtr.Visible = true;
                    Seastorediv.Visible = false;
                    //ContainerDetails.Visible = false;
                    if (TxtExpMode.Text == "1 : Sea")
                    {
                        if (DrpDecType.SelectedItem.ToString() == "TTF : THRU TRANSHIPMENT WITHIN SAME FTZ" || DrpDecType.SelectedItem.ToString() == "TTI : THRU TRANSHIPMENT WITH INTER-GATEWAY MOVEMENT")
                        {
                            OBLOUTMAWBL.Visible = true;
                        }
                        else
                        {
                            OBLOUTMAWBL.Visible = false;
                        }
                        outtr.Visible = true;
                        OUTWARDFlight.Visible = false;
                        OUTWARDSea.Visible = true;
                        // outvessel.Visible = true;
                        outvessel.Visible = true;
                        outw.Visible = true;
                        Seastorediv.Visible = true;
                        OutwardName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                        OutwardCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    }
                    else if (TxtExpMode.Text == "2 : Rail" || TxtExpMode.Text == "5 : Mail" || TxtExpMode.Text == "7 : Pipeline" ||  TxtExpMode.Text == "6 : Multi-model(Not in use)")
                    {
                        if (DrpDecType.SelectedItem.ToString() == "TTF : THRU TRANSHIPMENT WITHIN SAME FTZ" || DrpDecType.SelectedItem.ToString() == "TTI : THRU TRANSHIPMENT WITH INTER-GATEWAY MOVEMENT")
                        {
                            OBLOUTMAWBL.Visible = false;
                        }
                        OUTWARDOther.Visible = true;
                        outw.Visible = true;
                        OUTWARDSea.Visible = false;
                        outtr.Visible = true;
                        outvessel.Visible = false;
                        Seastorediv.Visible = false;

                        OutwardName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                        OutwardCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                        //ContainerDetails.Visible = false;
                    }
                    else if (TxtExpMode.Text == "3 : Road")
                    {
                        if (DrpDecType.SelectedItem.ToString() == "TTF : THRU TRANSHIPMENT WITHIN SAME FTZ" || DrpDecType.SelectedItem.ToString() == "TTI : THRU TRANSHIPMENT WITH INTER-GATEWAY MOVEMENT")
                        {
                            OBLOUTMAWBL.Visible = false;
                        }
                        OUTWARDOther.Visible = true;
                        outw.Visible = false;
                        OUTWARDSea.Visible = false;
                        outtr.Visible = true;
                        outvessel.Visible = false;
                        Seastorediv.Visible = false;                        
                        OutwardName.BackColor = System.Drawing.Color.White;
                        OutwardCRUEI.BackColor = System.Drawing.Color.White;
                        OBLINOUT.Visible = false;
                        //ContainerDetails.Visible = false;
                    }



                    else if (TxtExpMode.Text == "4 : Air")
                    {
                        if (DrpDecType.SelectedItem.ToString() == "TTF : THRU TRANSHIPMENT WITHIN SAME FTZ" || DrpDecType.SelectedItem.ToString() == "TTI : THRU TRANSHIPMENT WITH INTER-GATEWAY MOVEMENT")
                        {
                            OBLOUTMAWBL.Visible = true;
                        }
                        else
                        {
                            OBLOUTMAWBL.Visible = false;
                        }
                        OUTWARDFlight.Visible = true;
                        outw.Visible = true;
                        outtr.Visible = true;
                        OUTWARDSea.Visible = false;
                        outvessel.Visible = false;
                        Seastorediv.Visible = false;

                        OutwardName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                        OutwardCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                        //ContainerDetails.Visible = false;
                    }
                    else if (TxtExpMode.Text == "N : Not Required")
                    {
                        if (DrpDecType.SelectedItem.ToString() == "TTF : THRU TRANSHIPMENT WITHIN SAME FTZ" || DrpDecType.SelectedItem.ToString() == "TTI : THRU TRANSHIPMENT WITH INTER-GATEWAY MOVEMENT")
                        {
                            OBLOUTMAWBL.Visible = false;
                        }
                        outtr.Visible = false;
                        //Seastorediv.Visible = false;
                    }
                }
                else
                {
                    outtr.Visible = false;
                }
            }

            transhipcargo.Update();
            transhipparty.Update();
            DrpBGIndicator.Focus();
            DrpDecType_SelectedIndexChanged(null, null);
        }

        protected void BtnExit_Click(object sender, EventArgs e)
        {

            Response.Redirect("TranshipmentList.aspx");
        }

        protected void btnamendprevious_Click(object sender, EventArgs e)
        {

        }

        protected void btnamendsave_Click(object sender, EventArgs e)
        {

        }

        protected void btnamendreset_Click(object sender, EventArgs e)
        {

        }

        protected void btnamendnext_Click(object sender, EventArgs e)
        {

        }

        protected void btncancelprevios_Click(object sender, EventArgs e)
        {

        }

        protected void btncancelsave_Click(object sender, EventArgs e)
        {

        }

        protected void btncancelnext_Click(object sender, EventArgs e)
        {

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
                    //   var cruei1 = row.FindControl("lblCRUEI") as Label;

                    if (lblCode1 != null && lblName1 != null && lblName11 != null)
                    {

                        //UpdatePanelDCS.Update();
                        //Get values
                        string requestor = lblCode1.Text;
                        string requestType = lblName1.Text;
                        string status = lblName11.Text;
                        // string crueis = cruei1.Text;
                        txtrecloctn.Text = "";
                        txtrecloctndet.Text = "";

                        txtrecloctn.Text = requestType;
                        txtrecloctndet.Text = status;

                        //  UpdatePanelDCS.Update();

                    }
                    // DECCOMPSearGRID.Visible = false;

                }
            }


            transhipment.Update();
            TxtStorageShort.Focus();
        }

        protected void ReceiptGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(ReceiptGrid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void StorageGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //  DECCOMPSearGRID.SelectedIndex = Convert.ToInt16(e.CommandArgument);
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = StorageGrid.Rows[rowIndex];
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
                        TxtStorageShort.Text = "";
                        TxtStorageName.Text = "";

                        TxtStorageShort.Text = requestType;
                        TxtStorageName.Text = status;

                        //  UpdatePanelDCS.Update();

                    }
                    // DECCOMPSearGRID.Visible = false;

                }
            }


            transhipment.Update();
            BlankDate1.Focus();
        }

        protected void StorageGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(StorageGrid, "Select$" + e.Row.RowIndex);
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
                    if (TxtExpMode.Text == "1 : Sea")
                    {
                        OUTWARDVoyageNo.Focus();
                    }
                    else if (TxtExpMode.Text == "2 : Rail" || TxtExpMode.Text == "3 : Road" || TxtExpMode.Text == "5 : Mail" || TxtExpMode.Text == "7 : Pipeline" || TxtExpMode.Text == "N : Not Required" || TxtExpMode.Text == "6 : Multi-model(Not in use)")
                    {
                        OUTWARDConref.Focus();
                    }

                    else if (TxtExpMode.Text == "4 : Air")
                    {
                        OUTWARDFlightN0.Focus();
                    }
                    // DECCOMPSearGRID.Visible = false;

                }
            }


            transhipment.Update();
            DrpFinalDesCountry.Focus();
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
                //  DECCOMPSearGRID.SelectedIndex = Convert.ToInt16(e.CommandArgument);
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = NextPortGrid.Rows[rowIndex];
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
                        txtNextprt.Text = "";
                        txtNetPrtSer.Text = "";

                        txtNextprt.Text = requestor;
                        txtNetPrtSer.Text = requestType;

                        //  UpdatePanelDCS.Update();

                    }
                    // DECCOMPSearGRID.Visible = false;
                    txtLasPrt.Focus();
                }
            }


            transhipment.Update();
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
                //  DECCOMPSearGRID.SelectedIndex = Convert.ToInt16(e.CommandArgument);
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = LastGrid.Rows[rowIndex];
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
                        txtLasPrt.Text = "";
                        txtLasPrtSer.Text = "";

                        txtLasPrt.Text = requestor;
                        txtLasPrtSer.Text = requestType;

                        //  UpdatePanelDCS.Update();

                    }
                    // DECCOMPSearGRID.Visible = false;
                    txtLasPrtSer.Focus();
                }
            }


            transhipment.Update();
        }

        protected void LastGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(LastGrid, "Select$" + e.Row.RowIndex);
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
                    var lblCode1 = row.FindControl("lblCode") as Label;
                    var lblName1 = row.FindControl("lblName") as Label;
                    var lblName11 = row.FindControl("lblName1") as Label;
                    //   var cruei1 = row.FindControl("lblCRUEI") as Label;

                    if (lblName1 != null && lblName11 != null)
                    {

                        //UpdatePanelDCS.Update();
                        //Get values
                        string requestor = lblName1.Text;
                        string requestType = lblName11.Text;

                        // string crueis = cruei1.Text;
                        TxtCountryItem.Text = "";
                        txtcname.Text = "";

                        TxtCountryItem.Text = requestor;
                        txtcname.Text = requestType;

                        //  UpdatePanelDCS.Update();

                    }
                    // DECCOMPSearGRID.Visible = false;

                }
            }


            transhipment.Update();
            ChkBGIndicator.Focus();
        }

        protected void CountryGridItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(CountryGridItem, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void OriginalRegDate_TextChanged(object sender, EventArgs e)
        {
            OriginalRegDate.Text = DateCheck(OriginalRegDate.Text);
        }

        private void AddItemSummary()
        {
            string totinvAmt = "";
            string ConString = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            SqlConnection con = new SqlConnection(ConString);
            string CmdString = "select Distinct UnitPriceCurrency,Sum(TotalLineAmount) as TotalLineAmount from dbo.TranshipmentItemDtl where PermitId='" + txt_code.Text + "' and MessageType='TNPDEC' GROUP BY UnitPriceCurrency  ORDER BY UnitPriceCurrency DESC";
            SqlCommand cmd = new SqlCommand(CmdString, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Label lbl = new Label();
                lbl.Text = reader["UnitPriceCurrency"].ToString() + reader["TotalLineAmount"].ToString();
                lblinvoiceAmt.Text = reader["TotalLineAmount"].ToString();
                lbl.BackColor = System.Drawing.Color.WhiteSmoke;
                lbl.BorderStyle = BorderStyle.Solid;
                lbl.BorderWidth = 1;
                lbl.Width = 200;
                totinvAmt = totinvAmt + "  -  " + lbl.Text + " " + Environment.NewLine;
                div1.Controls.Add(lbl);
                div1.Controls.Add(new LiteralControl("<br />"));
                //div2.Controls.Add(lbl);
                //div2.Controls.Add(new LiteralControl("<br />"));
            }
            lblinvoiceAmt.Text = totinvAmt;
            con.Close();
            transhipsummery.Update();
        }
        public void ReqValidatePageLoad()
        {

            if (TxtTradeMailID.Text == "")
            {
                ErrorDes = "Header -  Please Enter TradeNet : ";

            }
            if (chkalrt.Visible == true)
            {
                if (chkalrt.Checked == false)
                {
                    ErrorDes = "Summary -  Please Choose Declaration Indicator : ";
                }
            }
            else if (chkdec.Visible == true)
            {
                if (chkdec.Checked == false)
                {
                    ErrorDes = "Summary -  Please Choose Declaration Indicator : ";
                }
            }
            else if (CheckBox4.Visible == true)
            {
                if (CheckBox4.Checked == false)
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
            if (DrpDecType.SelectedItem.ToString() == "BRE : BLANKET REMOVAL")
            {
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

                if (txtreLoctn.Text == "")
                {
                    ErrorDes = ErrorDes + "Cargo -  Please Enter Release Location : ";

                }
                if (txtrecloctn.Text == "")
                {
                    ErrorDes = ErrorDes + "Cargo -  Please Enter Receipt Location : ";

                }

               
                 if (TxttotalOuterPack.Text == "")
                {
                    ErrorDes = ErrorDes + "Cargo -  Please Enter TotalOuterPack : ";

                }
                 if (DrptotalOuterPack.SelectedItem.ToString() == "")
                {
                    ErrorDes = ErrorDes + "Cargo -  Please Choose OuterPackUOM : ";

                }
                  if (TxtTotalGrossWeight.Text == "")
                {
                    ErrorDes = ErrorDes + "Cargo -  Please Enter TotalGrossWeight : ";

                }
                 if (DrpTotalGrossWeight.SelectedItem.ToString() == "")
                {
                    ErrorDes = ErrorDes + "Cargo -  Please Choose TotalGrossUOM : ";

                }

                 DrpCargoPackType.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                 TxtDecCompCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                 TxtDecCompName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                 TxtImpCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                 TxtImpName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                

                 txtreLoctn.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                 txtrecloctn.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                 BlankDate1.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
               
                 TxttotalOuterPack.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                 DrptotalOuterPack.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                 TxtTotalGrossWeight.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                 DrpTotalGrossWeight.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);

       
            }
            else if (DrpDecType.SelectedItem.ToString() == "IGM : INTER-GATEWAY MOVEMENT")
            {
                if (DrpCargoPackType.SelectedItem.ToString() == "--Select--")
                {
                    ErrorDes = ErrorDes + "Header -  Please Choose Cargo Pack Type : ";

                }

                if (DrpInwardtrasMode.SelectedItem.ToString() == "--Select--")
                {
                    ErrorDes = ErrorDes + "Header -  Please Choose InwardTransMode : ";

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

                if (txtreLoctn.Text == "")
                {
                    ErrorDes = ErrorDes + "Cargo -  Please Enter Release Location : ";

                }
                if (txtrecloctn.Text == "")
                {
                    ErrorDes = ErrorDes + "Cargo -  Please Enter Receipt Location : ";

                }               

              
                if (TxttotalOuterPack.Text == "")
                {
                    ErrorDes = ErrorDes + "Cargo -  Please Enter TotalOuterPack : ";

                }
                if (DrptotalOuterPack.SelectedItem.ToString() == "")
                {
                    ErrorDes = ErrorDes + "Cargo -  Please Choose OuterPackUOM : ";

                }
                if (TxtTotalGrossWeight.Text == "")
                {
                    ErrorDes = ErrorDes + "Cargo -  Please Enter TotalGrossWeight : ";

                }
                if (DrpTotalGrossWeight.SelectedItem.ToString() == "")
                {
                    ErrorDes = ErrorDes + "Cargo -  Please Choose TotalGrossUOM : ";

                }

                DrpCargoPackType.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                DrpInwardtrasMode.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                TxtDecCompCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                TxtDecCompName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                TxtImpCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                TxtImpName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);


                txtreLoctn.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                txtrecloctn.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                BlankDate1.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
               
                TxttotalOuterPack.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                DrptotalOuterPack.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                TxtTotalGrossWeight.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                DrpTotalGrossWeight.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);

            }
            else if (DrpDecType.SelectedItem.ToString() == "REM : REMOVAL")
            {
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

                if (txtreLoctn.Text == "")
                {
                    ErrorDes = ErrorDes + "Cargo -  Please Enter Release Location : ";

                }
                if (txtrecloctn.Text == "")
                {
                    ErrorDes = ErrorDes + "Cargo -  Please Enter Receipt Location : ";

                }

                if (TxttotalOuterPack.Text == "")
                {
                    ErrorDes = ErrorDes + "Cargo -  Please Enter TotalOuterPack : ";

                }
                if (DrptotalOuterPack.SelectedItem.ToString() == "")
                {
                    ErrorDes = ErrorDes + "Cargo -  Please Choose OuterPackUOM : ";

                }
                if (TxtTotalGrossWeight.Text == "")
                {
                    ErrorDes = ErrorDes + "Cargo -  Please Enter TotalGrossWeight : ";

                }
                if (DrpTotalGrossWeight.SelectedItem.ToString() == "")
                {
                    ErrorDes = ErrorDes + "Cargo -  Please Choose TotalGrossUOM : ";

                }

                DrpCargoPackType.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
              //  DrpInwardtrasMode.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                TxtDecCompCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                TxtDecCompName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                TxtImpCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                TxtImpName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);


                txtreLoctn.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                txtrecloctn.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                BlankDate1.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
              
                TxttotalOuterPack.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                DrptotalOuterPack.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                TxtTotalGrossWeight.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                DrpTotalGrossWeight.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            }
            else if (DrpDecType.SelectedItem.ToString() == "TTF : THRU TRANSHIPMENT WITHIN SAME FTZ")
            {
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

                if (txtreLoctn.Text == "")
                {
                    ErrorDes = ErrorDes + "Cargo -  Please Enter Release Location : ";

                }
                if (txtrecloctn.Text == "")
                {
                    ErrorDes = ErrorDes + "Cargo -  Please Enter Receipt Location : ";

                }               

              
                if (TxttotalOuterPack.Text == "")
                {
                    ErrorDes = ErrorDes + "Cargo -  Please Enter TotalOuterPack : ";

                }
                if (DrptotalOuterPack.SelectedItem.ToString() == "")
                {
                    ErrorDes = ErrorDes + "Cargo -  Please Choose OuterPackUOM : ";

                }
                if (TxtTotalGrossWeight.Text == "")
                {
                    ErrorDes = ErrorDes + "Cargo -  Please Enter TotalGrossWeight : ";

                }
                if (DrpTotalGrossWeight.SelectedItem.ToString() == "")
                {
                    ErrorDes = ErrorDes + "Cargo -  Please Choose TotalGrossUOM : ";

                }

                DrpCargoPackType.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                DrpInwardtrasMode.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                TxtDecCompCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                TxtDecCompName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                TxtImpCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                TxtImpName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);


                txtreLoctn.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                txtrecloctn.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                BlankDate1.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
              
                TxttotalOuterPack.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                DrptotalOuterPack.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                TxtTotalGrossWeight.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                DrpTotalGrossWeight.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            }
            else if (DrpDecType.SelectedItem.ToString() == "TTI : THRU TRANSHIPMENT WITH INTER-GATEWAY MOVEMENT")
            {
                if (DrpCargoPackType.SelectedItem.ToString() == "--Select--")
                {
                    ErrorDes = ErrorDes + "Header -  Please Choose Cargo Pack Type : ";

                }

                if (DrpInwardtrasMode.SelectedItem.ToString() == "--Select--")
                {
                    ErrorDes = ErrorDes + "Header -  Please Choose InwardTransMode : ";

                }

                
                if (TxtDecCompCRUEI.Text == "")
                {
                    ErrorDes = ErrorDes + "Party -  Please Enter Declarent CRUEI : ";

                }
                if (TxtDecCompName.Text == "")
                {
                    ErrorDes = ErrorDes + "Party -  Please Enter Declarent Name : ";

                }                

                if (txtreLoctn.Text == "")
                {
                    ErrorDes = ErrorDes + "Cargo -  Please Enter Release Location : ";

                }
                if (txtrecloctn.Text == "")
                {
                    ErrorDes = ErrorDes + "Cargo -  Please Enter Receipt Location : ";

                }                
             
                if (TxttotalOuterPack.Text == "")
                {
                    ErrorDes = ErrorDes + "Cargo -  Please Enter TotalOuterPack : ";

                }
                if (DrptotalOuterPack.SelectedItem.ToString() == "")
                {
                    ErrorDes = ErrorDes + "Cargo -  Please Choose OuterPackUOM : ";

                }
                if (TxtTotalGrossWeight.Text == "")
                {
                    ErrorDes = ErrorDes + "Cargo -  Please Enter TotalGrossWeight : ";

                }
                if (DrpTotalGrossWeight.SelectedItem.ToString() == "")
                {
                    ErrorDes = ErrorDes + "Cargo -  Please Choose TotalGrossUOM : ";

                }

                DrpCargoPackType.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                DrpInwardtrasMode.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                TxtDecCompCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                TxtDecCompName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                TxtImpCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                TxtImpName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);


                txtreLoctn.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                txtrecloctn.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                BlankDate1.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
              
                TxttotalOuterPack.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                DrptotalOuterPack.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                TxtTotalGrossWeight.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                DrpTotalGrossWeight.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            }

            if (DrpInwardtrasMode.SelectedItem.ToString() == "--Select--")
            {
                ErrorDes = ErrorDes + "Header -  Please Choose InwardTransMode : ";

            }
            if (DrpInwardtrasMode.SelectedItem.ToString() != "--Select--")
            {
                if (DrpInwardtrasMode.SelectedItem.ToString() == "1 : Sea")
                {
                    if (TextMode.Text != "N : Not Required")
                    {
                        if (InwardName.Text == "")
                        {
                            ErrorDes = ErrorDes + "Party -  Please Enter Inward Carrier Agent Name : ";
                            InwardName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                        }
                        if (InwardCRUEI.Text == "")
                        {
                            ErrorDes = ErrorDes + "Party -  Please Enter Inward Carrier Agent CRUEI : ";
                            InwardCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                        }

                        //if (TxtInMAWBOBL.Text == "")
                        //{
                        //    ErrorDes = ErrorDes + "Party -  Please Enter InMAWBOBL : ";
                        //    TxtInMAWBOBL.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                        //}
                        if (TxtArrivalDate1.Text == "")
                        {
                            ErrorDes = ErrorDes + "Party -  Please Enter  ARRIVAL DATE : ";
                            TxtInMAWBOBL.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                        }

                        if (TxtLoadShort.Text == "")
                        {
                            ErrorDes = ErrorDes + "Party -  Please Enter  LOADING PORT : ";
                            TxtInMAWBOBL.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                        }
                        if (TxtVoyageno.Text == "")
                        {
                            ErrorDes = ErrorDes + "Party -  Please Enter  VOYAGE NUMBER : ";
                            TxtInMAWBOBL.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                        }
                        if (TxtVesselName.Text == "")
                        {
                            ErrorDes = ErrorDes + "Party -  Please Enter VesselName : ";
                            TxtInMAWBOBL.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                        }


                    }

                }
                else
                {
                    //if (TxtInMAWBOBL.Text == "")
                    //{
                    //    ErrorDes = ErrorDes + "Party -  Please Enter InMAWBOBL : ";
                    //    TxtInMAWBOBL.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    //}
                    if (TextMode.Text != "N : Not Required")
                    {
                        if (TxtArrivalDate1.Text == "")
                        {
                            ErrorDes = ErrorDes + "Party -  Please Enter  ARRIVAL DATE : ";
                            TxtInMAWBOBL.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                        }

                        if (TxtLoadShort.Text == "")
                        {
                            ErrorDes = ErrorDes + "Party -  Please Enter  LOADING PORT : ";
                            TxtInMAWBOBL.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                        }
                    }
                }
                if (DrpInwardtrasMode.SelectedItem.ToString() == "4 : Air")
                {

                    //if (TxtInMAWBOBL.Text == "")
                    //{
                    //    ErrorDes = ErrorDes + "Party -  Please Enter InMAWBOBL : ";
                    //    TxtInMAWBOBL.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    //}
                    if (TextMode.Text != "N : Not Required")
                    {
                        if (TxtArrivalDate1.Text == "")
                        {
                            ErrorDes = ErrorDes + "Party -  Please Enter  ARRIVAL DATE : ";
                            TxtInMAWBOBL.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                        }

                        if (TxtLoadShort.Text == "")
                        {
                            ErrorDes = ErrorDes + "Party -  Please Enter  LOADING PORT : ";
                            TxtInMAWBOBL.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                        }
                        if (txtflight.Text == "")
                        {
                            ErrorDes = ErrorDes + "Party -  Please Enter  flightNo : ";
                            TxtInMAWBOBL.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                        }
                    }

                }

            }
            if (DrpOutwardtrasMode.SelectedItem.ToString() != "--Select--")
            {

                if (DrpOutwardtrasMode.SelectedItem.ToString() == "1 : Sea")
                {

                    if (TextMode.Text != "N : Not Required")
                    {                        
                        if (DrpDecType.SelectedItem.ToString() == "REM : REMOVAL" || DrpDecType.SelectedItem.ToString() == "BRE : BLANKET REMOVAL")
                        {
                            
                        }
                        else
                        {
                            if (OutwardName.Text == "")
                            {
                                ErrorDes = ErrorDes + "Party -  Please Enter Outward Carrier Agent Name : ";
                                OutwardName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                            }

                            if (OutwardCRUEI.Text == "")
                            {
                                ErrorDes = ErrorDes + "Party -  Please Enter  Outward Carrier Agent CRUEI : ";
                                OutwardCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                            }
                        }

                        //if (TxtOutMAWBOBL.Text == "")
                        //{
                        //    ErrorDes = ErrorDes + "Party -  Please Enter OutMAWBOBL : ";
                        //    TxtOutMAWBOBL.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                        //}
                        if (TxtExpArrivalDate1.Text == "")
                        {
                            ErrorDes = ErrorDes + "Party -  Please Enter  Departure DATE : ";
                            TxtInMAWBOBL.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                        }

                        if (TxtExpLoadShort.Text == "")
                        {
                            ErrorDes = ErrorDes + "Party -  Please Enter  Discharge PORT : ";
                            TxtInMAWBOBL.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                        }
                        if (DrpFinalDesCountry.SelectedItem.ToString() == "--Select--")
                        {
                            ErrorDes = ErrorDes + "Header -  Please Choose FinalDesCountry : ";

                        }
                    }

                }
                else
                {
                    if (DrpDecType.SelectedItem.ToString() == "TTF : THIRU TRANSHIPMENT WITHIN SAME FTZ" && DrpDecType.SelectedItem.ToString() == "TTI : THIRU TRANSHIPMENT WITH INTER-GATEWAY MOVEMENT")
                    {
                        if (TextMode.Text != "N : Not Required")
                        {
                            if (TxtOutMAWBOBL.Text == "")
                            {
                                ErrorDes = ErrorDes + "Party -  Please Enter OutMAWBOBL : ";
                                TxtOutMAWBOBL.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                            }
                        }
                    }
                    if (TextMode.Text != "N : Not Required")
                    {
                        if (TxtExpArrivalDate1.Text == "")
                        {
                            ErrorDes = ErrorDes + "Party -  Please Enter  Departure DATE : ";
                            TxtInMAWBOBL.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                        }

                        if (TxtExpLoadShort.Text == "")
                        {
                            ErrorDes = ErrorDes + "Party -  Please Enter  Discharge PORT : ";
                            TxtInMAWBOBL.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                        }
                        if (DrpFinalDesCountry.SelectedItem.ToString() == "--Select--")
                        {
                            ErrorDes = ErrorDes + "Header -  Please Choose FinalDesCountry : ";

                        }
                    }
                }

                if (DrpOutwardtrasMode.SelectedItem.ToString() == "4 : Air")
                {
                    //if (TxtOutMAWBOBL.Text == "")
                    //{
                    //    ErrorDes = ErrorDes + "Party -  Please Enter OutMAWBOBL : ";
                    //    TxtOutMAWBOBL.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                    //}
                    if (TextMode.Text != "N : Not Required")
                    {
                        if (TxtExpArrivalDate1.Text == "")
                        {
                            ErrorDes = ErrorDes + "Party -  Please Enter  Departure DATE : ";
                            TxtInMAWBOBL.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                        }

                        if (TxtExpLoadShort.Text == "")
                        {
                            ErrorDes = ErrorDes + "Party -  Please Enter  Discharge PORT : ";
                            TxtInMAWBOBL.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                        }
                        if (DrpFinalDesCountry.SelectedItem.ToString() == "--Select--")
                        {
                            ErrorDes = ErrorDes + "Header -  Please Choose FinalDesCountry : ";

                        }
                        if (OUTWARDFlightN0.Text == "")
                        {
                            ErrorDes = ErrorDes + "Party -  Please Enter OUT FLIGHT NUMBER : ";
                            TxtInMAWBOBL.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
                        }
                    }
                }
            }

            //if (DrpCargoPackType.SelectedItem.ToString() == "--Select--")
            //{
            //    ErrorDes = ErrorDes + "Header -  Please Choose Cargo Pack Type : ";

            //}
            



            //if (TxtImpCRUEI.Text == "")
            //{
            //    ErrorDes = ErrorDes + "Party -  Please Enter Importer CRUEI : ";

            //}
            //if (TxtImpName.Text == "")
            //{
            //    ErrorDes = ErrorDes + "Party -  Please Enter Importer Name : ";

            //}


            //if (TextMode.Text == "1 : Sea" || TextMode.Text == "4 : Air")
            //{

            //    if (InwardName.Text == "")
            //    {
            //        ErrorDes = ErrorDes + "Party -  Please Enter Inward Name : ";

            //    }

            //    if (InwardCRUEI.Text == "")
            //    {
            //        ErrorDes = ErrorDes + "Invoice -  Please Enter Inward CRUEI : ";

            //    }
            //}
            //if (txtreLoctn.Text == "")
            //{
            //    ErrorDes = ErrorDes + "Cargo -  Please Enter Release Location : ";

            //}
            //if (txtrecloctn.Text == "")
            //{
            //    ErrorDes = ErrorDes + "Cargo -  Please Enter Receipt Location : ";

            //}



            //if (DrpDecType.SelectedItem.ToString() == "BKT : Blanket ")
            //{
            //    if (TxtArrivalDate1.Text == "")
            //    {
            //        ErrorDes = ErrorDes + "Item -  Please Enter Total Gross Weight : ";

            //    }

            //}
            //else
            //{
            //    if (DrpInwardtrasMode.SelectedItem.ToString() == "--Select--")
            //    {
            //        ErrorDes = ErrorDes + "Item -  Please Choose Inward Transport Mode : ";

            //    }

            //}
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


            //string INTransMode = DrpInwardtrasMode.SelectedItem.ToString();
            //if (DrpInwardtrasMode.SelectedItem.ToString() != "--Select--")
            //{
            //    if (INTransMode == "1 : Sea")
            //    {

            //        if (TxtArrivalDate1.Text == "")
            //        {
            //            ErrorDes = ErrorDes + "Invoice -  Please Enter  Arrival Date :  ";

            //        }
            //        if (TxtLoadShort.Text == "")
            //        {
            //            ErrorDes = ErrorDes + "Invoice -  Please Enter  Loading Port : ";

            //        }
            //        if (TxtVoyageno.Text == "")
            //        {
            //            ErrorDes = ErrorDes + "Invoice -  Please Enter  Voyage Number :  ";

            //        }
            //        if (TxtVesselName.Text == "")
            //        {
            //            ErrorDes = ErrorDes + "Invoice -  Please Enter  Vessel Name : ";

            //        }
            //        if (TxtOceanBill.Text == "")
            //        {
            //            ErrorDes = ErrorDes + "Invoice -  Please Enter  Ocean Bill of Lading Number : ";

            //        }

            //        //if (txtcruei.Text == "")
            //        //{
            //        //    ErrorDes = ErrorDes + "Invoice -  Please Enter  Supplier / Manufacturer Party CRUEI :  ";

            //        //}
            //        //if (txtName.Text == "")
            //        //{
            //        //    ErrorDes = ErrorDes + "Invoice -  Please Enter  Supplier / Manufacturer Party  Name : ";

            //        //}
            //        //if (TxtImppartyCRUEI.Text == "")
            //        //{
            //        //    ErrorDes = ErrorDes + "Invoice -  Please Enter  Importer Party CRUEI :  ";

            //        //}
            //        //if (TxtImppartyName.Text == "")
            //        //{
            //        //    ErrorDes = ErrorDes + "Invoice -  Please Enter  Importer Party  Name : ";

            //        //}

            //        TxtArrivalDate1.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //        TxtLoadShort.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //        TxtVoyageno.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //        TxtVesselName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);

            //        TxtOceanBill.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //        //txtcruei.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //        //txtName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //        //TxtImppartyCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //        //TxtImppartyName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);

            //    }
            //    else
            //    {
            //        TxtArrivalDate1.BackColor = System.Drawing.Color.White;
            //        TxtLoadShort.BackColor = System.Drawing.Color.White;
            //        TxtVoyageno.BackColor = System.Drawing.Color.White;
            //        TxtVesselName.BackColor = System.Drawing.Color.White;

            //        TxtOceanBill.BackColor = System.Drawing.Color.White;
            //        //txtcruei.BackColor = System.Drawing.Color.White;
            //        //txtName.BackColor = System.Drawing.Color.White;
            //        //TxtImppartyCRUEI.BackColor = System.Drawing.Color.White;
            //        //TxtImppartyName.BackColor = System.Drawing.Color.White;

            //    }
            //    if (INTransMode == "2 : Rail" || INTransMode == "3 : Road" || INTransMode == "5 : Mail" || INTransMode == "7 : Pipeline" || INTransMode == "N : Not Required" || INTransMode == "6 : Multi-model(Not in use)")
            //    {
            //        if (TxtArrivalDate1.Text == "")
            //        {
            //            ErrorDes = ErrorDes + "Invoice -  Please Enter  Arrival Date :  ";

            //        }
            //        if (TxtLoadShort.Text == "")
            //        {
            //            ErrorDes = ErrorDes + "Invoice -  Please Enter  Loading Port : ";

            //        }


            //        //if (txtcruei.Text == "")
            //        //{
            //        //    ErrorDes = ErrorDes + "Invoice -  Please Enter  Supplier / Manufacturer Party CRUEI :  ";

            //        //}
            //        //if (txtName.Text == "")
            //        //{
            //        //    ErrorDes = ErrorDes + "Invoice -  Please Enter  Supplier / Manufacturer Party  Name : ";

            //        //}
            //        //if (TxtImppartyCRUEI.Text == "")
            //        //{
            //        //    ErrorDes = ErrorDes + "Invoice -  Please Enter  Importer Party CRUEI :  ";

            //        //}
            //        //if (TxtImppartyName.Text == "")
            //        //{
            //        //    ErrorDes = ErrorDes + "Invoice -  Please Enter  Importer Party  Name : ";

            //        //}
            //        TxtArrivalDate1.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //        TxtLoadShort.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //        TxtConRefNo.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //        TxtTrnsID.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);


            //        //txtcruei.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //        //txtName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //        //TxtImppartyCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //        //TxtImppartyName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);


            //    }
            //    else
            //    {
            //        TxtArrivalDate1.BackColor = System.Drawing.Color.White;
            //        TxtLoadShort.BackColor = System.Drawing.Color.White;
            //        TxtConRefNo.BackColor = System.Drawing.Color.White;
            //        TxtTrnsID.BackColor = System.Drawing.Color.White;


            //        //txtcruei.BackColor = System.Drawing.Color.White;
            //        //txtName.BackColor = System.Drawing.Color.White;
            //        //TxtImppartyCRUEI.BackColor = System.Drawing.Color.White;
            //        //TxtImppartyName.BackColor = System.Drawing.Color.White;

            //    }

            //    if (INTransMode == "4 : Air")
            //    {
            //        if (TxtArrivalDate1.Text == "")
            //        {
            //            ErrorDes = ErrorDes + "Invoice -  Please Enter  Arrival Date :  ";

            //        }
            //        if (TxtLoadShort.Text == "")
            //        {
            //            ErrorDes = ErrorDes + "Invoice -  Please Enter  Loading Port : ";

            //        }
            //        if (txtflight.Text == "")
            //        {
            //            ErrorDes = ErrorDes + "Invoice -  Please Enter  Flight No. :  ";

            //        }
            //        //if (txtaircraft.Text == "")
            //        //{
            //        //    ErrorDes = ErrorDes + "Invoice -  Please Enter  Air Craft : ";

            //        //}
            //        if (txtwaybill.Text == "")
            //        {
            //            ErrorDes = ErrorDes + "Invoice -  Please Enter Master Air Way Bill : ";

            //        }

            //        //if (txtcruei.Text == "")
            //        //{
            //        //    ErrorDes = ErrorDes + "Invoice -  Please Enter  Supplier / Manufacturer Party CRUEI :  ";

            //        //}
            //        //if (txtName.Text == "")
            //        //{
            //        //    ErrorDes = ErrorDes + "Invoice -  Please Enter  Supplier / Manufacturer Party  Name : ";

            //        //}
            //        //if (TxtImppartyCRUEI.Text == "")
            //        //{
            //        //    ErrorDes = ErrorDes + "Invoice -  Please Enter  Importer Party CRUEI :  ";

            //        //}
            //        //if (TxtImppartyName.Text == "")
            //        //{
            //        //    ErrorDes = ErrorDes + "Invoice -  Please Enter  Importer Party  Name : ";

            //        //}

            //        TxtArrivalDate1.BackColor = System.Drawing.Color.CadetBlue;
            //        TxtLoadShort.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //        txtflight.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //        // txtaircraft.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);

            //        txtwaybill.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //        //txtcruei.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //        //txtName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //        //TxtImppartyCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //        //TxtImppartyName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);

            //    }
            //    else
            //    {
            //        TxtArrivalDate1.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //        TxtLoadShort.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //        txtflight.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //        // txtaircraft.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);

            //        txtwaybill.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //        //txtcruei.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //        //txtName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //        //TxtImppartyCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //        //TxtImppartyName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //    }
            //}





            //TxtTradeMailID.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //TxtDecName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //TxtDecCode.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //TxtDecTelephone.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //TxtCRUEINO.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //DrpDecType.BackColor = System.Drawing.Color.BlueViolet;
            //DrpCargoPackType.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //TxtImpCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //TxtImpName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //if (TextMode.Text == "1 : Sea" || TextMode.Text == "4 : Air")
            //{

            //    InwardName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //    InwardCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //}

            //TxtDecCompCRUEI.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //TxtDecCompName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //txtreLoctn.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //txtrecloctn.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            ////txtinvNo.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            ////txtinvDate1.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            ////txtcruei.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            ////txtName.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            ////Drpcurrency1.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //TxtHSCodeItem.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //TxtDescription.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //TxtCountryItem.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //TxtBrand.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //TxtHSQuantity.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //HSQTYUOM.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //DRPCurrency.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //TxtTotalLineAmount.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //TxttotalOuterPack.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //DrptotalOuterPack.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //TxtTotalGrossWeight.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //DrpTotalGrossWeight.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //if (DrpDecType.SelectedItem.ToString() == "BKT : Blanket ")
            //{
            //    TxtArrivalDate1.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //}
            //else
            //{
            //    DrpInwardtrasMode.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            //}

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
            transhipment.Update();
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
            POPUPERR.Show();
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
            ConsigneeSubDivi.Text = "";
            ConsigneeName.Text = "";
            ConsigneeAddress1.Text = "";
            ConsigneePostal.Text = "";
            ConsigneeName1.Text = "";
            ConsigneeCity.Text = "";
            ConsigneeCountry.Text = "";
            EndUserCode.Text = "";
            EndUserCrueo.Text = "";
            EndUserAddress.Text = "";
            EndUserSubCode.Text = "";
            EndUserSubCodeDivi.Text = "";
            EndUserName.Text = "";
            EndUserAddress1.Text = "";
            EndUserPostal.Text = "";
            EndUserName1.Text = "";
            EndUserCity.Text = "";
            EndUserCountry.Text = "";
        }
        public void CargoClr()
        {
            txtreLoctn.Text = "";
            txtrelocDeta.Text = "";
            txtrecloctn.Text = "";
            txtrecloctndet.Text = "";
            TxtStorageShort.Text = "";
            TxtStorageName.Text = "";
            BlankDate1.Text = "";
            TxttotalOuterPack.Text = "";
            DrptotalOuterPack.ClearSelection();
            DrptotalOuterPack.Items.FindByText("--Select--").Selected = true;
            TxtTotalGrossWeight.Text = "";
            DrpTotalGrossWeight.ClearSelection();
            DrpTotalGrossWeight.Items.FindByText("--Select--").Selected = true;
            TxtArrivalDate1.Text = "";
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
            TxtExpMode.Text = "";
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
            OUTWARDConref.Text = "";
            OUTWARDTransId.Text = "";
            TxtGrossReference.Text = "";
        }
        protected void btninvnum_Click(object sender, EventArgs e)
        {
            string sent = "Invoice Number :";

            txttrdremrk.Text = Environment.NewLine + sent;
        }

        protected void ContarinerGrid_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    string item = e.Row.Cells[0].Text;
            //    foreach (Button button in e.Row.Cells[2].Controls.OfType<Button>())
            //    {
            //        if (button.CommandName == "Delete")
            //        {
            //            button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
            //        }
            //    }
            //}

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
                DrpType.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
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
            transhipitem.Update();

            transhipment .Update();
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
            transhipitem.Update();

            transhipment.Update();
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
        protected void ddlpc3_SelectedIndexChanged(object sender, EventArgs e)
        {
            showSessionData();
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

            transhipment.Update();
            transhipitem.Update();

        }

        protected void ProductCode3Grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(ProductCode3Grid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
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
            transhipment.Update();
            transhipitem.Update();
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
            transhipment .Update();
            transhipitem.Update();
        }

        protected void ProductCode4Grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(ProductCode4Grid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }
        protected void btnpc2_Click(object sender, EventArgs e)
        {
            TxtProQty2.Text = TxtHSQuantity.Text;
        }

        protected void ddlpc4_SelectedIndexChanged(object sender, EventArgs e)
        {
            showSessionData();
        }

        protected void ddlpc5_SelectedIndexChanged(object sender, EventArgs e)
        {
            showSessionData();
        }

        protected void TxtInMAWBOBL_TextChanged(object sender, EventArgs e)
        {
            lbloblval.Text = TxtInMAWBOBL.Text;
            transhipsummery.Update();
        }

        protected void TxtOutMAWBOBL_TextChanged(object sender, EventArgs e)
        {
            lbloutobl.Text = TxtOutMAWBOBL.Text;
            transhipsummery.Update();
        }

        protected void btnsaveamend_Click(object sender, EventArgs e)
        {
            btnsavesum_Click(null,null);
        }

        protected void btnsavecancel_Click(object sender, EventArgs e)
        {
            btnsavesum_Click(null, null);
        }

        protected void btnCopyAll_Click(object sender, EventArgs e)
        {
            DataSet dss = new DataSet();
            MyClass cpyobj = new MyClass();
            dss = cpyobj.ds1("select distinct InHAWBOBL from TranshipmentItemDtl where MessageType='TNPDEC' AND PermitId='" + txt_code.Text + "' and InHAWBOBL!=''");
           if (dss.Tables[0].Rows.Count == 1)
           {
               TxtHAWB.Text = dss.Tables[0].Rows[0]["InHAWBOBL"].ToString();
           }
        }

        protected void BtnOutCopyAll_Click(object sender, EventArgs e)
        {
            DataSet dss = new DataSet();
            MyClass cpyobj = new MyClass();
            dss = cpyobj.ds1("select distinct OutHAWBOBL from TranshipmentItemDtl where MessageType='TNPDEC' AND PermitId='" + txt_code.Text + "' and OutHAWBOBL!=''");
            if (dss.Tables[0].Rows.Count == 1)
            {
                txtOutHAWB.Text = dss.Tables[0].Rows[0]["OutHAWBOBL"].ToString();
            }            
        }

        protected void imgDelete_Click1(object sender, EventArgs e)
        {
            AEOGrid_RowDeleting(null, null);
            transhipcpc.Update();
        }

        protected void BtnExcelUp_Click(object sender, EventArgs e)
        {
          //  Container();
            ItemUpload();
           // Casc();
          //  BindItemMaster();
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
                divCPC.Attributes["class"] = divCPC.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divSummary.Attributes["class"] = divSummary.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();

            }
            else if (TabContainer1.ActiveTabIndex == 1)
            {
                divHeader.Attributes["class"] = divHeader.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divHeader.Attributes.Add("class", "flex flex-col justify-center items-center relative  complete-stepper");
                divParty.Attributes.Add("class", "flex flex-col justify-center items-center relative  active-stepper");
                divCargo.Attributes["class"] = divCargo.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                
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
                
                divItem.Attributes["class"] = divItem.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                divItem.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                divCPC.Attributes.Add("class", "flex flex-col justify-center items-center relative active-stepper");
                divSummary.Attributes["class"] = divSummary.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();

            }
            else if (TabContainer1.ActiveTabIndex == 6)
            {
                if (Update == "AMEND")
                {



                    divHeader.Attributes["class"] = divHeader.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                    divHeader.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                    divParty.Attributes["class"] = divParty.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                    divParty.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                    divCargo.Attributes["class"] = divCargo.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                    divCargo.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");

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

                //divHeader.Attributes["class"] = divHeader.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                //divHeader.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                //divParty.Attributes["class"] = divParty.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                //divParty.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                //divCargo.Attributes["class"] = divCargo.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                //divCargo.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                
                //divItem.Attributes["class"] = divItem.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                //divItem.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                //divCPC.Attributes["class"] = divCPC.Attributes["class"].Replace("active-stepper", "").Replace("complete-stepper", "").Trim();
                //divCPC.Attributes.Add("class", "flex flex-col justify-center items-center relative complete-stepper");
                //divSummary.Attributes.Add("class", "flex flex-col justify-center items-center relative active-stepper");

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

                    //if (dt == null)
                    //{
                    //    return null;
                    //}

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


                        string MessageType = "TNPDEC", TouchUser = Session["UserId"].ToString();
                        string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


                        string qry = "INSERT INTO [dbo].[TranshipmentContainerDtl] ([PermitId],[RowNo],[ContainerNo],[Size],[Weight],[SealNo],[MessageType],[TouchUser],[TouchTime]) VALUES ('" + txt_code.Text + "','" + i + "','" + row["ContainerNo"].ToString() + "','" + row["Size"].ToString() + "','" + row["Weight"].ToString() + "','" + row["SealNo"].ToString() + "','" + MessageType + "','" + TouchUser + "','" + strTime + "')";
                        // string query = "insert into booking(JobId,OrderId,TaskType,CusId,DriverID,StartDate,EndDate,Small,Medium,Normal,Odd,Eurosize,Ref,Description,TaskStatus,TouchUser,TouchTime)  values ('" + txt_code.Text + "','" + row["OrderId"].ToString() + "','" + row["TaskType"].ToString() + "','" + row["CusId"].ToString() + "','Idle','" + row["StartDate"].ToString() + "',' " + row["EndDate"].ToString() + "','" + row["Small"].ToString() + "','" + row["Medium"].ToString() + "','" + row["Normal"].ToString() + "','" + row["Odd"].ToString() + "','" + row["Eurosize"].ToString() + "','" + row["Ref"].ToString() + "','" + row["Description"].ToString() + "','" + Status + "','" + Touch_user + "','" + strTime + "')";
                        cmd = new SqlCommand(qry, con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        i++;

                    }

                    //Error1.Text = "Succesfully Uploaded";
                }
                catch (Exception ex)
                {
                    //Error1.Text = ex.Message;
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

                    /* Loop thorugh dataTable*/
                    int i = 1;
                    con.Open();
                    foreach (DataRow row in dt.Rows)
                    {
                        //string BGIndicator = "", DutiableQty = "", Dutiableuom = "", ttlDutiableQty = "", ttlDutiableuom = "",HSQuantity="",HSQuantityUOM="";

                        if (row["HS Code"].ToString() != "")
                        {                            
                            string Messagetype = "TNPDEC";
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
                            string StrQuery1 = ("INSERT INTO [dbo].[TranshipmentItemDtl] ([ItemNo],[PermitId],[MessageType],[HSCode],[Description],[DGIndicator],[Contry],[Brand],[Model],[InHAWBOBL],[DutiableQty],[DutiableUOM],[TotalDutiableQty],[TotalDutiableUOM],[InvoiceQuantity],[HSQty],[HSUOM],[AlcoholPer],[InvoiceNo],[ChkUnitPrice],[UnitPrice],[UnitPriceCurrency],[ExchangeRate],[SumExchangeRate],[TotalLineAmount],[InvoiceCharges],[CIFFOB],[OPQty],[OPUOM],[IPQty],[IPUOM],[InPqty],[InPUOM],[ImPQty],[ImPUOM],[PreferentialCode],[GSTRate],[GSTUOM],[GSTAmount],[ExciseDutyRate],[ExciseDutyUOM],[ExciseDutyAmount],[CustomsDutyRate],[CustomsDutyUOM],[CustomsDutyAmount],[OtherTaxRate],[OtherTaxUOM],[OtherTaxAmount],[CurrentLot],[PreviousLot],LSPValue,[Making],[ShippingMarks1],[ShippingMarks2],[ShippingMarks3],[ShippingMarks4],[TouchUser],[TouchTime]) VALUES ('" + i + "','" + txt_code.Text + "','" + Messagetype + "','" + hscode + "','" + description + "','" + DGIndicator + "','" + Country + "','" + Brand + "','" + Model + "','" + InHAWBOBL + "','" + DutyQty + "','" + DutyQtyUOM + "','" + TtlDutyQty + "','" + ttlDutyQtyUOM + "','" + InvoiceQty + "','" + HSQuantity + "','" + HSQuantityUOM + "','" + AlPer + "','" + INVno + "','" + chkUnitPrice + "','" + UnitPrice + "','" + UnitPriceCurency + "','" + UnitPriceExrate + "','" + SumExchangeRate + "','" + TotalLineAmount + "','" + InvoiceCharges + "','" + CIFFOB + "','" + OuterPackQty + "','" + OuterPackQtyUOM + "','" + inPackQty + "','" + inPackQtyUOM + "','" + innerPackQty + "','" + innerPackQtyUOM + "','" + inmostPackQty + "','" + inmostPackQtyUOM + "','" + PerCode + "','" + GSTRAte + "','" + GSTUOM + "','" + GSTAMOUNT + "','" + ExciseRate + "','" + ExciseUOM + "','" + ExciseAmt + "','" + CusRate + "','" + CusUOM + "','" + CusAmt + "','" + OtherRate + "','" + OtherUOM + "','" + OtherAmt + "','" + CurrentLOt + "','" + PrevLot + "','" + LSPValue + "','" + Making + "','" + Ship1 + "','" + Ship2 + "','" + Ship3 + "','" + Ship4 + "','" + Touch_user + "','" + strTime + "')");
                            obj.exec(StrQuery1);
                            //}
                            //else
                            //{
                            //    string StrQuery1 = ("INSERT INTO [dbo].[COItemDtl] ([ItemNo],[PermitId],[MessageType],[HSCode],[Description],[Contry],[UnitPrice],[UnitPriceCurrency],[ExchangeRate],[SumExchangeRate],[TotalLineAmount],[CIFFOB],[InvoiceQty],[HSQTY],[HSUOM],[ShippingMark],[CerItemQty],[CerItemUOM],[ManfCostDate],[TextileCat],[TextileQuotaQty],[TextileQuotaQtyUOM],[ItemValue],[InvoiceNumber],[InvoiceDate],[HSOnCer],[OriginCriterion],[PerOrgainCRI],[CertificateDes],[Touch_user],[TouchTime]) VALUES ('" + i + "','" + PermitId + "','" + Messagetype + "','" + row["HS Code"].ToString() + "','" + row["Description"].ToString() + "','" + row["Country of Origin"].ToString() + "','" + UnitPrice + "','" + row["Item Currency"].ToString() + "','" + ExchangeRate + "','" + sumofExchangeRate + "','" + row["Total Line Amount"].ToString() + "','" + DecimalVal + "','" + DecimalVal + "','" + row["HS Qty"].ToString() + "','" + row["HS UOM"].ToString() + "','" + row["Shipping Marks 1"].ToString() + "','" + row["CO Certificate Item Qty"].ToString() + "','" + row["CO Certificate Item UOM"].ToString() + "','" + row["CO Manufacturing Cost Date"].ToString() + "','" + nullval + "','" + DecimalVal + "','" + uom + "','" + DecimalVal + "','" + nullval + "','" + nullval + "','" + nullval + "','" + row["CO Origin Criterion"].ToString() + "','" + nullval + "','" + nullval + "','" + Touch_user + "',Convert(VARCHAR,'" + strTime + "',108))");
                            //    obj.exec(StrQuery1);
                            //}
                        }
                        obj.closecon();
                        i++;
                        //Error1.Text = "Succesfully Uploaded";
                    }
                }
                catch (Exception ex)
                {
                   // Error1.Text = ex.Message;
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
                        //string BGIndicator = "", DutiableQty = "", Dutiableuom = "", ttlDutiableQty = "", ttlDutiableuom = "",HSQuantity="",HSQuantityUOM="";

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
                            string Messagetype = "TNPDEC";
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

                            string StrQuery1 = ("INSERT INTO [dbo].[TCASCDtl] (ItemNo,[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime] ,[CASCId]) VALUES ('" + row["Item Number"].ToString() + "','" + nullval + "','" + DecimalVal + "','" + uom + "','" + p1 + "','" + row["Code 1"].ToString() + "','" + row["Code 2"].ToString() + "','" + row["Code 3"].ToString() + "','" + PermitId + "','" + Messagetype + "','" + Touch_user + "','" + strTime + "','" + row["CascID"].ToString() + "')");
                            obj.exec(StrQuery1);
                            p1++;
                        }
                        obj.closecon();

                        //Error1.Text = "Succesfully Uploaded";
                    }
                }
                catch (Exception ex)
                {
                    //Error1.Text = ex.Message;
                }
            }
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
            transhipitem.Update();
        }

        protected void btnnxt_Click(object sender, EventArgs e)
        {
            int itemno1 = Convert.ToInt32(TxtSerialNo.Text);

            int id = itemno1 + 1;
            string ID = id.ToString();
            prevnextitem(ID);
        }

        protected void btnprev_Click(object sender, EventArgs e)
        {
            int itemno1 = Convert.ToInt32(TxtSerialNo.Text);

            int id = itemno1 - 1;
            string ID = id.ToString();
            prevnextitem(ID);
        }
        protected void prevnextitem(string itemno1)
        {
            string stra = "select Id,Name from [CommonMaster] where TypeId='12' and StatusID=1 order by Name";
            obj.dr = obj.ret_dr(stra);
            DrpMaking.DataSource = obj.dr;
            DrpMaking.DataTextField = "Name";
            DrpMaking.DataValueField = "Id";
            DrpMaking.DataBind();
            obj.closecon();
            DrpMaking.Items.Insert(0, new ListItem("--Select--", "0"));

            string Invoice = txt_code.Text;
          

          
            //warning
            // string SuplierCode, Importer = "";

            string strBindTxtBox = "select * from [TranshipmentItemDtl] where ItemNo='" + itemno1 + "' and PermitId='" + Invoice + "'";
            obj.dr = obj.ret_dr(strBindTxtBox);
            while (obj.dr.Read())
            {
                TxtSerialNo.Text = obj.dr["ItemNo"].ToString();
                itemno.Text = obj.dr["ItemNo"].ToString();
                TxtHSCodeItem.Text = obj.dr["HSCode"].ToString();
                TxtHSCodeItem_TextChanged(null, null);
                TxtDescription.Text = obj.dr["Description"].ToString();
                string chkrate = obj.dr["DGIndicator"].ToString();
                if (chkrate == "True" || chkrate == "true")
                {
                    ChkBGIndicator.Checked = true;
                }
                else if (chkrate == "False" || chkrate == "false")
                {
                    ChkBGIndicator.Checked = false;
                }
                TxtCountryItem.Text = obj.dr["Contry"].ToString();

                TxtBrand.Text = obj.dr["Brand"].ToString();
                TxtModel.Text = obj.dr["Model"].ToString();
                TxtHAWB.Text = obj.dr["InHAWBOBL"].ToString();
                txtOutHAWB.Text = obj.dr["OutHAWBOBL"].ToString();
                TxtInMAWBOBL.Text = obj.dr["InMAWBOBL"].ToString();
                TxtOutMAWBOBL.Text = obj.dr["OutMAWBOBL"].ToString();

                TxtTotalDutiableQuantity.Text = obj.dr["DutiableQty"].ToString();
                TDQUOM.ClearSelection();
                TDQUOM.Items.FindByText(obj.dr["DutiableUOM"].ToString()).Selected = true;
                txttotDutiableQty.Text = obj.dr["TotalDutiableQty"].ToString();
                ddptotDutiableQty.ClearSelection();
                ddptotDutiableQty.Items.FindByText(obj.dr["TotalDutiableUOM"].ToString()).Selected = true;
                //TDQUOM.SelectedItem.Text = obj.dr["TotalDutiableUOM"].ToString();
                txtAlcoholPer.Text = obj.dr["AlcoholPer"].ToString();
                TxtInvQty.Text = obj.dr["InvoiceQuantity"].ToString();
                TxtHSQuantity.Text = obj.dr["HSQty"].ToString();
                HSQTYUOM.ClearSelection();
                HSQTYUOM.Items.FindByText(obj.dr["HSUOM"].ToString()).Selected = true;
                //HSQTYUOM.SelectedItem.Text = obj.dr[16].ToString();

                // DrpInvoiceNo.Items.FindByText(obj.dr[16].ToString()).Selected = true;
                //DrpInvoiceNo.SelectedItem.Text = obj.dr[16].ToString();
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
                // DRPCurrency.SelectedItem.Text = obj.dr[19].ToString();
                TxtExchangeRate.Text = obj.dr["ExchangeRate"].ToString();
                TxtSumExRate.Text = obj.dr["SumExchangeRate"].ToString();
                TxtTotalLineAmount.Text = obj.dr["TotalLineAmount"].ToString();
                TxtTotalLineCharges.Text = obj.dr["InvoiceCharges"].ToString();
                TxtCIFFOB.Text = obj.dr["CIFFOB"].ToString();
                TxtOPQty.Text = Math.Round(Convert.ToDecimal(obj.dr["OPQty"].ToString()), 0).ToString();


                if (Convert.ToDecimal(obj.dr["OPQty"].ToString()) > 0)
                {
                    ChkPackInfo.Checked = true;
                    PackingInfo.Visible = true;
                }


                //  DRPOPQUOM.Items.FindByText(obj.dr[26].ToString()).Selected = true;
                DRPOPQUOM.ClearSelection();
                DRPOPQUOM.Items.FindByText(obj.dr["OPUOM"].ToString()).Selected = true;
                //DRPOPQUOM.SelectedItem.Text = obj.dr[26].ToString();
                TxtIPQty.Text = Math.Round(Convert.ToDecimal(obj.dr["IPQty"].ToString()), 0).ToString();
                //  DRPIPQUOM.Items.FindByText(obj.dr[28].ToString()).Selected = true;
                DRPIPQUOM.ClearSelection();
                DRPIPQUOM.Items.FindByText(obj.dr["IPUOM"].ToString()).Selected = true;
                //DRPIPQUOM.SelectedItem.Text = obj.dr[28].ToString();
                TxtINPQty.Text = Math.Round(Convert.ToDecimal(obj.dr["InPqty"].ToString()), 0).ToString();
                //  DRPINNPQUOM.Items.FindByText(obj.dr[30].ToString()).Selected = true;
                DRPINNPQUOM.ClearSelection();
                DRPINNPQUOM.Items.FindByText(obj.dr["InPUOM"].ToString()).Selected = true;
                //DRPINNPQUOM.SelectedItem.Text = obj.dr[30].ToString();
                TxtIMPQty.Text = Math.Round(Convert.ToDecimal(obj.dr["ImPQty"].ToString()), 0).ToString();
                //  DRPIMPQUOM.Items.FindByText(obj.dr[32].ToString()).Selected = true;
                DRPIMPQUOM.ClearSelection();
                DRPIMPQUOM.Items.FindByText(obj.dr["ImPUOM"].ToString()).Selected = true;
                //DRPIMPQUOM.SelectedItem.Text = obj.dr[32].ToString();

                //  DrpPreferentialCode.Items.FindByText(obj.dr[33].ToString()).Selected = true;
                DrpPreferentialCode.ClearSelection();
                DrpPreferentialCode.Items.FindByText(obj.dr["PreferentialCode"].ToString()).Selected = true;
                // DrpPreferentialCode.SelectedItem.Text = obj.dr[33].ToString();
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
                //  DrpOtherUOM.Items.FindByText(obj.dr[44].ToString()).Selected = true;
                DrpOtherUOM.ClearSelection();
                DrpOtherUOM.Items.FindByText(obj.dr["OtherTaxUOM"].ToString()).Selected = true;
                //DrpOtherUOM.SelectedItem.Text = obj.dr[44].ToString();
                TxtSumOtherTaxRate.Text = obj.dr["OtherTaxAmount"].ToString();
                TxtCurrentLot.Text = obj.dr["CurrentLot"].ToString();
                DrpMaking.ClearSelection();
                DrpMaking.Items.FindByText(obj.dr["Making"].ToString()).Selected = true;
                // DrpMaking.SelectedItem.Text = obj.dr[47].ToString();
                TxtPreviousLot.Text = obj.dr["PreviousLot"].ToString();
                if (!string.IsNullOrWhiteSpace(obj.dr["PreviousLot"].ToString()))
                {
                    Chklot.Checked = true;
                    Chklot_CheckedChanged(null, null);

                }



                txtShippingMarks1.Text = obj.dr["ShippingMarks1"].ToString();
                txtShippingMarks2.Text = obj.dr["ShippingMarks2"].ToString();
                txtShippingMarks3.Text = obj.dr["ShippingMarks3"].ToString();
                txtShippingMarks4.Text = obj.dr["ShippingMarks4"].ToString();

                //OriginalRegDate.Text = obj.dr["Orginregdate"].ToString();
                //DrpVehicleCapacity.Text = obj.dr["Engineuom"].ToString();
                //txtengine.Text = obj.dr["Enginecapacity"].ToString();

                //DrpVehicleType.Text = obj.dr["DrpVehicleType"].ToString();

                if (!string.IsNullOrWhiteSpace(obj.dr["DrpVehicleType"].ToString()))
                {
                    DrpVehicleType.ClearSelection();
                    DrpVehicleType.Items.FindByText(obj.dr["DrpVehicleType"].ToString()).Selected = true;
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

                if (!string.IsNullOrWhiteSpace(obj.dr["Orginregdate"].ToString()))
                {
                    OriginalRegDate.Text = Convert.ToDateTime(obj.dr["Orginregdate"].ToString()).ToString("dd/MM/yyyy");
                }
                editbindProduct1pn(itemno1,Invoice);
                editbindProduct2pn(itemno1, Invoice);
                editbindProduct3pn(itemno1, Invoice);
                editbindProduct4pn(itemno1, Invoice);
                editbindProduct5pn(itemno1, Invoice);


                ItemAddGrid.Visible = true;
                ItemDiv.Visible = true;
                BtnAddNEWItem.Visible = false;
                TxtCountryItem_TextChanged(null, null);

            }
            
        }

        private void editbindProduct1pn(string ID,string pid)
        {
            string strBindTxtBox = "select * from [TranshipmentItemDtl] where ItemNo='" + ID + "' and PermitId='" + pid + "'";
            obj.dr = obj.ret_dr(strBindTxtBox);
            while (obj.dr.Read())
            {
                SqlConnection con = new SqlConnection(sqlconn);
                //SqlCommand cmd1 = new SqlCommand("SELECT T1.Id ,T1.CRP,T1.CompanyName,T1.Name,T1.EmailId,T1.Mobile, T2.Name as Rent ,t1.BudgetFrom,T1.BudgetTo ,T3.Name as Type,T4.Name as Location,T5.PropertyRef,T1.MultipleLocation,T1. MultipleProperty  FROM (select a.Id,a.CompanyName,a.Name,a.EmailId,a.Mobile,a.BudgetFrom,a.BudgetTo,b.Name as CRP,a.MultipleLocation,a.MultipleProperty  from lead a,CommonMaster b where a.Per_Com=b.Id and a.TouchUser='" + Touch_user + "') AS T1 JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.RentorBuy=b.Id) AS T2    ON T1.Id = T2.Id    JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Type=b.Id) AS T3  ON T1.Id = T3.Id     JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Location=b.Id) AS T4   ON T1.Id = T4.Id    JOIN ( select b.ID,b.Name,a.PropertyRef  from Lead_List a,Lead b where a.ParentId=b.Id) AS T5   ON T1.Id = T5.Id order by T1.Id desc", con);
                //SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3 from TranshipmentItemDtl a,TCASCDtl b where a.PermitId=b.PermitId and b.CASCId='Casc1' and a.PermitId='" + txt_code.Text + "'", con);
                SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3, Quantity , ProductCode from TCASCDtl  where CASCId='Casc1' and PermitId='" + txt_code.Text + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "'", con);
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                sda1.Fill(dt);
                ViewState["ProductCode1"] = dt;
                string ff = "select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3, Quantity , ProductCode,ProductUOM,Enduserdesc from TCASCDtl  where CASCId='Casc1' and PermitId='" + txt_code.Text + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "'";
                MyClass objprc = new MyClass();
                objprc.dr = objprc.ret_dr(ff);
                if (objprc.dr.Read())
                {

                    TxtProQty1.Text = objprc.dr["Quantity"].ToString();
                    TxtProductCode1.Text = objprc.dr["ProductCode"].ToString();
                    DrpP1.ClearSelection();
                    DrpP1.Items.FindByText(objprc.dr["ProductUOM"].ToString()).Selected = true;
                    EndUserDesp1.Text = objprc.dr["Enduserdesc"].ToString();
                    EndUserDesp1_TextChanged(null, null);
                    //DrpP3.SelectedItem.Text = obj.dr["ProductUOM"].ToString();
                }
                if (dt.Rows.Count <= 0)
                {
                    dt.Rows.Add();
                }
                ViewState["ProductCode1"] = dt;
                ProductCode1Grid1.DataSource = dt;
                ProductCode1Grid1.DataBind();
                int rowIndex = 0;
                if (ViewState["ProductCode1"] != null)
                {
                    DataTable dt1 = (DataTable)ViewState["ProductCode1"];
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt1.Rows.Count; i++)
                        {
                            Chkitemcasc.Checked = true;
                            Chkitemcasc_CheckedChanged(null, null);
                            TextBox box1 = (TextBox)ProductCode1Grid1.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                            TextBox box2 = (TextBox)ProductCode1Grid1.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                            TextBox box3 = (TextBox)ProductCode1Grid1.Rows[rowIndex].Cells[3].FindControl("TextBox3");
                            box1.Text = dt1.Rows[i]["Column1"].ToString();
                            box2.Text = dt1.Rows[i]["Column2"].ToString();
                            box3.Text = dt1.Rows[i]["Column3"].ToString();
                            rowIndex++;
                            //ProductCode1Grid1.DataSource = dt;
                            //ProductCode1Grid1.DataBind();
                        }
                    }
                }
            }
        }

        private void editbindProduct2pn(string ID, string pid)
        {
            string strBindTxtBox = "select * from [TranshipmentItemDtl] where ItemNo='" + ID + "' and PermitId='" + pid + "'";
            obj.dr = obj.ret_dr(strBindTxtBox);
            while (obj.dr.Read())
            {
                SqlConnection con = new SqlConnection(sqlconn);
                //SqlCommand cmd1 = new SqlCommand("SELECT T1.Id ,T1.CRP,T1.CompanyName,T1.Name,T1.EmailId,T1.Mobile, T2.Name as Rent ,t1.BudgetFrom,T1.BudgetTo ,T3.Name as Type,T4.Name as Location,T5.PropertyRef,T1.MultipleLocation,T1. MultipleProperty  FROM (select a.Id,a.CompanyName,a.Name,a.EmailId,a.Mobile,a.BudgetFrom,a.BudgetTo,b.Name as CRP,a.MultipleLocation,a.MultipleProperty  from lead a,CommonMaster b where a.Per_Com=b.Id and a.TouchUser='" + Touch_user + "') AS T1 JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.RentorBuy=b.Id) AS T2    ON T1.Id = T2.Id    JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Type=b.Id) AS T3  ON T1.Id = T3.Id     JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Location=b.Id) AS T4   ON T1.Id = T4.Id    JOIN ( select b.ID,b.Name,a.PropertyRef  from Lead_List a,Lead b where a.ParentId=b.Id) AS T5   ON T1.Id = T5.Id order by T1.Id desc", con);
                //SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3 from TranshipmentItemDtl a,TCASCDtl b where a.PermitId=b.PermitId and b.CASCId='Casc2' and a.PermitId='" + txt_code.Text + "'", con);
                SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3, Quantity , ProductCode from TCASCDtl  where CASCId='Casc2' and PermitId='" + txt_code.Text + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "'", con);
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                sda1.Fill(dt);
                ViewState["ProductCode2"] = dt;
                string ff = "select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3, Quantity , ProductCode,ProductUOM,Enduserdesc from TCASCDtl  where CASCId='Casc2' and PermitId='" + txt_code.Text + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "'";
                //string ff = "select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3,Quantity,ProductCode,ProductUOM,Enduserdesc from TCASCDtl b where a.PermitId=b.PermitId and b.CASCId='Casc2' and a.PermitId='" + txt_code.Text + "'";
                MyClass objprc = new MyClass();
                objprc.dr = objprc.ret_dr(ff);
                if (objprc.dr.Read())
                {

                    TxtProQty2.Text = objprc.dr["Quantity"].ToString();
                    TxtProductCode2.Text = objprc.dr["ProductCode"].ToString();
                    DrpP2.ClearSelection();
                    DrpP2.Items.FindByText(objprc.dr["ProductUOM"].ToString()).Selected = true;
                    EndUserDesp2.Text = objprc.dr["Enduserdesc"].ToString();
                    EndUserDesp2_TextChanged(null, null);
                    //DrpP3.SelectedItem.Text = obj.dr["ProductUOM"].ToString();
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

        private void editbindProduct3pn(string ID, string pid)
        {
            string strBindTxtBox = "select * from [TranshipmentItemDtl] where ItemNo='" + ID + "' and PermitId='" + pid + "'";
            obj.dr = obj.ret_dr(strBindTxtBox);
            while (obj.dr.Read())
            {
                SqlConnection con = new SqlConnection(sqlconn);
                //SqlCommand cmd1 = new SqlCommand("SELECT T1.Id ,T1.CRP,T1.CompanyName,T1.Name,T1.EmailId,T1.Mobile, T2.Name as Rent ,t1.BudgetFrom,T1.BudgetTo ,T3.Name as Type,T4.Name as Location,T5.PropertyRef,T1.MultipleLocation,T1. MultipleProperty  FROM (select a.Id,a.CompanyName,a.Name,a.EmailId,a.Mobile,a.BudgetFrom,a.BudgetTo,b.Name as CRP,a.MultipleLocation,a.MultipleProperty  from lead a,CommonMaster b where a.Per_Com=b.Id and a.TouchUser='" + Touch_user + "') AS T1 JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.RentorBuy=b.Id) AS T2    ON T1.Id = T2.Id    JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Type=b.Id) AS T3  ON T1.Id = T3.Id     JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Location=b.Id) AS T4   ON T1.Id = T4.Id    JOIN ( select b.ID,b.Name,a.PropertyRef  from Lead_List a,Lead b where a.ParentId=b.Id) AS T5   ON T1.Id = T5.Id order by T1.Id desc", con);
                //SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3 from TranshipmentItemDtl a,TCASCDtl b where a.PermitId=b.PermitId and b.CASCId='Casc3' and a.PermitId='" + txt_code.Text + "'", con);
                SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3, Quantity , ProductCode from TCASCDtl  where CASCId='Casc3' and PermitId='" + txt_code.Text + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "'", con);
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                sda1.Fill(dt);
                ViewState["ProductCode3"] = dt;
                string ff = "select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3, Quantity , ProductCode,ProductUOM,Enduserdesc from TCASCDtl  where CASCId='Casc3' and PermitId='" + txt_code.Text + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "'";
                //string ff = "select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3,Quantity,ProductCode,ProductUOM,Enduserdesc from ItemDtl a,TCASCDtl b where a.PermitId=b.PermitId and b.CASCId='Casc3' and a.PermitId='" + txt_code.Text + "'";
                MyClass objprc = new MyClass();
                objprc.dr = objprc.ret_dr(ff);
                if (objprc.dr.Read())
                {
                    TxtProQty3.Text = objprc.dr["Quantity"].ToString();
                    TxtProductCode3.Text = objprc.dr["ProductCode"].ToString();
                    DrpP3.ClearSelection();
                    DrpP3.Items.FindByText(objprc.dr["ProductUOM"].ToString()).Selected = true;
                    EndUserDesp3.Text = objprc.dr["Enduserdesc"].ToString();
                    EndUserDesp3_TextChanged(null, null);
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

                        }
                    }
                }
            }
        }

        private void editbindProduct4pn(string ID, string pid)
        {
            string strBindTxtBox = "select * from [TranshipmentItemDtl] where ItemNo='" + ID + "' and PermitId='" + pid + "'";
            obj.dr = obj.ret_dr(strBindTxtBox);
            while (obj.dr.Read())
            {
                SqlConnection con = new SqlConnection(sqlconn);
                //SqlCommand cmd1 = new SqlCommand("SELECT T1.Id ,T1.CRP,T1.CompanyName,T1.Name,T1.EmailId,T1.Mobile, T2.Name as Rent ,t1.BudgetFrom,T1.BudgetTo ,T3.Name as Type,T4.Name as Location,T5.PropertyRef,T1.MultipleLocation,T1. MultipleProperty  FROM (select a.Id,a.CompanyName,a.Name,a.EmailId,a.Mobile,a.BudgetFrom,a.BudgetTo,b.Name as CRP,a.MultipleLocation,a.MultipleProperty  from lead a,CommonMaster b where a.Per_Com=b.Id and a.TouchUser='" + Touch_user + "') AS T1 JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.RentorBuy=b.Id) AS T2    ON T1.Id = T2.Id    JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Type=b.Id) AS T3  ON T1.Id = T3.Id     JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Location=b.Id) AS T4   ON T1.Id = T4.Id    JOIN ( select b.ID,b.Name,a.PropertyRef  from Lead_List a,Lead b where a.ParentId=b.Id) AS T5   ON T1.Id = T5.Id order by T1.Id desc", con);
                //SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3 from TranshipmentItemDtl a,TCASCDtl b where a.PermitId=b.PermitId and b.CASCId='Casc4' and a.PermitId='" + txt_code.Text + "'", con);
                SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3, Quantity , ProductCode from TCASCDtl  where CASCId='Casc4' and PermitId='" + txt_code.Text + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "'", con);
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                sda1.Fill(dt);
                ViewState["ProductCode4"] = dt;
                string ff = "select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3, Quantity , ProductCode,ProductUOM,Enduserdesc from TCASCDtl  where CASCId='Casc4' and PermitId='" + txt_code.Text + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "'";
                //string ff = "select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3,Quantity,ProductCode,ProductUOM,Enduserdesc from ItemDtl a,TCASCDtl b where a.PermitId=b.PermitId and b.CASCId='Casc4' and a.PermitId='" + txt_code.Text + "'";
                MyClass objprc = new MyClass();
                objprc.dr = objprc.ret_dr(ff);
                if (objprc.dr.Read())
                {
                    TxtProQty4.Text = objprc.dr["Quantity"].ToString();
                    TxtProductCode4.Text = objprc.dr["ProductCode"].ToString();
                    DrpP4.ClearSelection();
                    DrpP4.Items.FindByText(objprc.dr["ProductUOM"].ToString()).Selected = true;
                    EndUserDesp4.Text = objprc.dr["Enduserdesc"].ToString();
                    EndUserDesp4_TextChanged(null, null);
                    //DrpP3.SelectedItem.Text = obj.dr["ProductUOM"].ToString();
                }
                if (dt.Rows.Count <= 0)
                {
                    dt.Rows.Add();
                }
                ViewState["ProductCode1"] = dt;
                ProductCode4Grid1.DataSource = dt;
                ProductCode4Grid1.DataBind();
                int rowIndex = 0;
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
                        }
                    }
                }
            }
        }

        private void editbindProduct5pn(string ID, string pid)
        {
            string strBindTxtBox = "select * from [TranshipmentItemDtl] where ItemNo='"+ID+"' and PermitId='"+pid+"'";
            obj.dr = obj.ret_dr(strBindTxtBox);
            while (obj.dr.Read())
            {
                SqlConnection con = new SqlConnection(sqlconn);
                //SqlCommand cmd1 = new SqlCommand("SELECT T1.Id ,T1.CRP,T1.CompanyName,T1.Name,T1.EmailId,T1.Mobile, T2.Name as Rent ,t1.BudgetFrom,T1.BudgetTo ,T3.Name as Type,T4.Name as Location,T5.PropertyRef,T1.MultipleLocation,T1. MultipleProperty  FROM (select a.Id,a.CompanyName,a.Name,a.EmailId,a.Mobile,a.BudgetFrom,a.BudgetTo,b.Name as CRP,a.MultipleLocation,a.MultipleProperty  from lead a,CommonMaster b where a.Per_Com=b.Id and a.TouchUser='" + Touch_user + "') AS T1 JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.RentorBuy=b.Id) AS T2    ON T1.Id = T2.Id    JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Type=b.Id) AS T3  ON T1.Id = T3.Id     JOIN ( select a.ID,b.Name from lead a,CommonMaster b where a.Location=b.Id) AS T4   ON T1.Id = T4.Id    JOIN ( select b.ID,b.Name,a.PropertyRef  from Lead_List a,Lead b where a.ParentId=b.Id) AS T5   ON T1.Id = T5.Id order by T1.Id desc", con);
                //SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3 from TranshipmentItemDtl a,TCASCDtl b where a.PermitId=b.PermitId and b.CASCId='Casc5' and a.PermitId='" + txt_code.Text + "'", con);
                SqlCommand cmd1 = new SqlCommand("select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3, Quantity , ProductCode from TCASCDtl  where CASCId='Casc5' and PermitId='" + txt_code.Text + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "'", con);
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                sda1.Fill(dt);
                ViewState["ProductCode5"] = dt;
                string ff = "select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3, Quantity , ProductCode,ProductUOM,Enduserdesc from TCASCDtl  where CASCId='Casc5' and PermitId='" + txt_code.Text + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "'";
                //string ff = "select RowNo as RowNumber,CascCode1 as Column1, CascCode2 as Column2,CascCode3 as Column3,Quantity,ProductCode,ProductUOM,Enduserdesc from ItemDtl a,TCASCDtl b where a.PermitId=b.PermitId and b.CASCId='Casc5' and a.PermitId='" + txt_code.Text + "'";
                MyClass objprc = new MyClass();
                objprc.dr = objprc.ret_dr(ff);
                if (objprc.dr.Read())
                {

                    TxtProQty5.Text = objprc.dr["Quantity"].ToString();
                    TxtProductCode5.Text = objprc.dr["ProductCode"].ToString();
                    DrpP5.ClearSelection();
                    DrpP5.Items.FindByText(objprc.dr["ProductUOM"].ToString()).Selected = true;
                    EndUserDesp5.Text = objprc.dr["Enduserdesc"].ToString();
                    EndUserDesp5_TextChanged(null, null);
                    //DrpP3.SelectedItem.Text = obj.dr["ProductUOM"].ToString();
                }
                if (dt.Rows.Count <= 0)
                {
                    dt.Rows.Add();
                }
                ViewState["ProductCode1"] = dt;
                ProductCode5Grid1.DataSource = dt;
                ProductCode5Grid1.DataBind();
                int rowIndex = 0;
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
                        }
                    }
                }
            }
        }

        protected void EndUserDesp1_TextChanged(object sender, EventArgs e)
        {
            lblenddescr.Text = "character count: " + EndUserDesp1.Text.Length.ToString();
            
        }

        protected void EndUserDesp2_TextChanged(object sender, EventArgs e)
        {
            lblenddescr1.Text = "character count: " + EndUserDesp2.Text.Length.ToString();

        }

        protected void EndUserDesp3_TextChanged(object sender, EventArgs e)
        {
            lblenddescr2.Text = "character count: " + EndUserDesp3.Text.Length.ToString();
        }

        protected void EndUserDesp4_TextChanged(object sender, EventArgs e)
        {
            lblenddescr3.Text = "character count: " + EndUserDesp4.Text.Length.ToString();
        }

        protected void EndUserDesp5_TextChanged(object sender, EventArgs e)
        {
            lblenddescr4.Text = "character count: " + EndUserDesp5.Text.Length.ToString();
        }



        //Connect

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
            string qry = "select RowNo as RowNumber,ProcessingCode1,ProcessingCode2,ProcessingCode3 from InHeaderTbl a,InNonCPCDtl b where a.PermitId=b.PermitId and b.CPCType='STSANDCWC' and a.PermitId='" + txt_code.Text + "'";
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


        protected void imgDelete_ClickAEO(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int rowIndex = Convert.ToInt32(btn.CommandArgument);

            DataTable dt = ViewState["CurrentTable"] as DataTable;

            if (dt != null)
            {
                if (dt.Rows.Count <= 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You cannot delete the last row.');", true);
                    return;
                }

                if (dt.Rows.Count > rowIndex)
                {
                    dt.Rows.RemoveAt(rowIndex);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["RowNumber"] = i + 1;
                    }

                    ViewState["CurrentTable"] = dt;
                    AEOGrid.DataSource = dt;
                    AEOGrid.DataBind();
                }
            }
        }


        protected void imgDelete_ClickCWC(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int rowIndex = Convert.ToInt32(btn.CommandArgument);

            DataTable dt = ViewState["CurrentTable1"] as DataTable;

            if (dt != null)
            {
                if (dt.Rows.Count <= 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You cannot delete the last row.');", true);
                    return;
                }

                if (dt.Rows.Count > rowIndex)
                {
                    dt.Rows.RemoveAt(rowIndex);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["RowNumber"] = i + 1;
                    }

                    ViewState["CurrentTable1"] = dt;
                    CWCGrid.DataSource = dt;
                    CWCGrid.DataBind();
                }
            }
        }


        protected void imgDelete_ClickSea(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int rowIndex = Convert.ToInt32(btn.CommandArgument);

            DataTable dt = ViewState["CurrentTable26"] as DataTable;

            if (dt != null)
            {
                if (dt.Rows.Count <= 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You cannot delete the last row.');", true);
                    return;
                }

                if (dt.Rows.Count > rowIndex)
                {
                    dt.Rows.RemoveAt(rowIndex);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["RowNumber"] = i + 1;
                    }

                    ViewState["CurrentTable26"] = dt;
                    SeaGrid.DataSource = dt;
                    SeaGrid.DataBind();
                }
            }
        }


        protected void imgDelete_ClickScheme(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int rowIndex = Convert.ToInt32(btn.CommandArgument);

            DataTable dt = ViewState["CurrentTable30"] as DataTable;

            if (dt != null)
            {
                if (dt.Rows.Count <= 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You cannot delete the last row.');", true);
                    return;
                }

                if (dt.Rows.Count > rowIndex)
                {
                    dt.Rows.RemoveAt(rowIndex);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["RowNumber"] = i + 1;
                    }

                    ViewState["CurrentTable30"] = dt;
                    SchemeGrid.DataSource = dt;
                    SchemeGrid.DataBind();
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


                    if (lblCode1 != null && lblName1 != null)
                    {
                        string requestor = lblCode1.Text;
                        string requestType = lblName1.Text;

                        TxtHSCodeItem.Text = "";
                        TxtDescription.Text = "";

                        TxtHSCodeItem.Text = requestor;
                        TxtDescription.Text = requestType;

                    }
                }
            }
            transhipment.Update();
        }

    

        protected void HSCodeSearchItem_TextChanged1(object sender, EventArgs e)
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

        protected void lnkHSCodeItem_Command(object sender, CommandEventArgs e)
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



                }

            }

        }

        protected void imgDelete_ClickSts(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int rowIndex = Convert.ToInt32(btn.CommandArgument);

            DataTable dt = ViewState["CurrentTable21"] as DataTable;

            if (dt != null)
            {
                if (dt.Rows.Count <= 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You cannot delete the last row.');", true);
                    return;
                }

                if (dt.Rows.Count > rowIndex)
                {
                    dt.Rows.RemoveAt(rowIndex);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["RowNumber"] = i + 1;
                    }

                    ViewState["CurrentTable21"] = dt;
                    StsGrid.DataSource = dt;
                    StsGrid.DataBind();
                }
            }
        }


        protected void imgDelete_ClickStsCwc(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int rowIndex = Convert.ToInt32(btn.CommandArgument);

            DataTable dt = ViewState["CurrentTable22"] as DataTable;

            if (dt != null)
            {
                if (dt.Rows.Count <= 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You cannot delete the last row.');", true);
                    return;
                }

                if (dt.Rows.Count > rowIndex)
                {
                    dt.Rows.RemoveAt(rowIndex);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["RowNumber"] = i + 1;
                    }

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

            if (dt != null && dt.Rows.Count > rowIndex)
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
