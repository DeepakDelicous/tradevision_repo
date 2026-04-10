using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;


namespace RET
{
    public partial class OutList : System.Web.UI.Page
    {        
        string PermID = "";
        DataTable dt = new DataTable();
        MyClass obj = new MyClass();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
        string sqlconn = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
        iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 60f, 5f, 5f, 20f);
        float pgheight = 0;
        int lineheight = 0;
        int Linecount = 62;
        int chkline = 0;
        string space = "", space1 = "";
        int sapceval = 0, spceval1 = 0;
        string handl = "";
        string strInHAWBOBL = ""; 
        string MSGNUMBER = "";
        string JobNo, MsgNO, refno, PermitNo, PermitId = "";
        static string tradmail = "";
        static List<string> lststr = new List<string>();
        List<string> lststr1 = new List<string>();
        List<string> lststr2 = new List<string>();
        List<string> lststr3 = new List<string>();
        List<string> AmdFileds = new List<string>();
        string msgid = "", pemno = "";
        string fldName = "", fldval = "", fldval1 = "";
        private static string Update = "";

        string issueaut = "", commacc = "", commacc1 = "", ststype = "", msgidName = "MsgID", SnoName = "Sno";
        string commaccName = "", issueautName = "";
        //warning
        /* SqlDataAdapter dastudent;
         DataSet ds_student, ds_course;
         SqlCommand cmdStudent;*/

        //TextBox txtJobid;
        //TextBox txtPermitId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Userid"] == null)
            {
                Response.Redirect("sessionTimeout.aspx");
            }
            string LogStstus = "", Activeuser = "";
            string perqry31 = "select LoginStatus,Activeuser,MailBoxId from ManageUser where UserId='" + Session["UserId"].ToString() + "'";
            obj.dr = obj.ret_dr(perqry31);
            while (obj.dr.Read())
            {
                LogStstus = obj.dr["LoginStatus"].ToString();
                Activeuser = obj.dr["Activeuser"].ToString();
                tradmail = obj.dr["MailBoxId"].ToString();
                string ClientMac = Session["Mac"].ToString();
                if (LogStstus == "True" && Activeuser == Session["Mac"].ToString())
                {

                }
                else
                {
                    Response.Redirect("sessionTimeout.aspx");
                }

            }
            foreach (GridViewRow gvrow in GridInPayment.Rows)
            {
                var checkbox = gvrow.FindControl("CheckBox1") as CheckBox;
                if (checkbox.Checked)
                {

                    ACR.Visible = true;
                    UpdatePanel3.Update();
                    break;
                }
                else
                {
                    ACR.Visible = false;
                    UpdatePanel3.Update();
                }
            }
            if (!IsPostBack)
            {
                // ViewState["Permit"] = txtPermitId.Text;
                BindInPayment();
                BindInpaymentGrid();
               /// colorchange();
                // search();
            }
           // colorchange();
        }
        public void ErrorXml(string folName)
        {
            try
            {
                string xmlFile = "";
                string tradeIDXML = tradmail;
                string[] tradID = tradeIDXML.Split('.');
                tradeIDXML = tradID[1].ToString() + "\\";
                string filePath = @"D:\MHAccess\workingdir\KaizenIN\" + tradeIDXML;
              //  string filePath = @"C:\Users\Public\" + folName + "\\ResponseFile\\";
                DirectoryInfo apple = new DirectoryInfo(filePath);
                foreach (var file in apple.GetFiles("*"))
                {
                    fldName = "";
                    fldval = "";
                    xmlFile = File.ReadAllText(filePath + file);
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.LoadXml(xmlFile);
                    XmlNode rootNode = xmldoc.DocumentElement;
                    //DisplayNodes(rootNode);
                    //XmlNodeList list = xmldoc.SelectNodes("cac:Permit");    
                    var nodeList1 = xmldoc.GetElementsByTagName("cbc:Date");
                    foreach (XmlNode node in nodeList1)
                    {
                        msgid = node.InnerText;
                    }
                    var nodeList2 = xmldoc.GetElementsByTagName("cbc:SequenceNumeric");
                    foreach (XmlNode node in nodeList2)
                    {
                        pemno = node.InnerText;
                    }
                    string strvalue = pemno.PadLeft(4, '0');
                    strvalue = msgid + strvalue;
                    var nodeList = xmldoc.GetElementsByTagName("err:ErrorMessage");
                    string Short_Fall = string.Empty;
                    string hdtext = string.Empty;                   

                    var nodeList4 = xmldoc.GetElementsByTagName("cbc:CommonAccessReference");
                    foreach (XmlNode node in nodeList4)
                    {
                        commaccName = "CommonAccessReference";
                        commacc = node.InnerText;
                    }
                    if (commacc == "ERRORM")
                    {
                        foreach (XmlNode node in nodeList)
                        {
                            int sno1 = 0;
                            XmlNodeList children = node.ChildNodes;
                            foreach (XmlNode child in children)
                            {
                                hdtext = child.Name.ToString();
                                string[] hval = hdtext.Split(':');
                                fldval = ""; fldName = "";
                                if (hval[0].ToString() == "cac")
                                {
                                    XmlNodeList children1 = child.ChildNodes;
                                    int chki = 0;
                                    lststr1 = new List<string>();
                                    if (hdtext != "cac:UniqueReferenceNumber")
                                    {
                                        foreach (XmlNode child1 in children1)
                                        {
                                            string name = child1.Name;
                                            string[] hval1 = child1.Name.ToString().Split(':');
                                            if (hval1[1].ToString() == "ErrorCode")
                                            {
                                                sno1 = sno1 + 1;
                                                if (chki == 0)
                                                {
                                                    fldName = fldName + hval1[1].ToString() + ",";
                                                }
                                                fldval = fldval + "'" + child1.InnerText + "',";
                                            }
                                            else if (hval1[1].ToString() == "ErrorDescription")
                                            {
                                                if (chki == 0)
                                                {
                                                    fldName = fldName + "ErrorDescription,";
                                                }
                                                fldval = fldval + "'" + child1.InnerText + "',";
                                            }
                                            else if (hval1[1].ToString() == "ErrorTrace")
                                            {
                                                if (chki == 0)
                                                {
                                                    fldName = fldName + "ErrorTrace,";
                                                    chki = chki = +1;
                                                }
                                                lststr1.Add(child1.InnerText);
                                            }
                                        }

                                    }
                                    if (!string.IsNullOrWhiteSpace(fldval))
                                    {
                                        string ffname = "";
                                        string flanme = file.ToString().Substring(0, file.ToString().Length - 2);
                                        for (int j = 0; j < lststr1.Count; j++)
                                        {
                                            if (j == 0)
                                            {
                                                fldval1 = "'" + sno1 + "','" + strvalue + "',";
                                                if (!string.IsNullOrWhiteSpace(issueaut))
                                                {
                                                    fldval1 = fldval1 + "'" + issueaut + "',";
                                                }
                                                if (!string.IsNullOrWhiteSpace(commacc))
                                                {
                                                    fldval1 = fldval1 + "'" + commacc + "',";
                                                }
                                                if (!string.IsNullOrWhiteSpace(ststype))
                                                {
                                                    fldval1 = fldval1 + "'" + ststype + "',";
                                                }
                                                fldval1 = fldval1 + fldval;
                                                fldName = fldName.Substring(0, fldName.Length - 1);
                                                fldval1 = fldval1.Substring(0, fldval1.Length - 1);
                                            }
                                            //ffname = ffname.Substring(0, 3);
                                            string str = "";
                                            MyClass objipt = new MyClass();
                                            objipt.dr = objipt.ret_dr("select * FROM OutHeaderTbl where MSGId='" + strvalue + "'");
                                            while (objipt.dr.Read())
                                            {
                                                string value = objipt.dr["MSGId"].ToString();
                                                if (!string.IsNullOrWhiteSpace(value))
                                                {
                                                    str = "update OutHeaderTbl set  Status='ERR' where MSGId='" + strvalue + "'";
                                                    obj.exec(str);

                                                    str = "delete from DownXmlTbl where FName='" + flanme + "' and tradeID='" + folName + "'";
                                                    obj.exec(str);

                                                    str = "Insert into ErrorStatus(" + SnoName + "," + msgidName + "," + commaccName + "," + fldName + ") values(" + fldval1 + ",'" + lststr1[j].ToString() + "')";
                                                    obj.exec(str);

                                                    ffname = "IPT";
                                                    //MyClass objiptrej = new MyClass();
                                                    //objiptrej.dr = objiptrej.ret_dr("select Count(*) FROM ErrorStatus where MsgID='" + strvalue + "'");
                                                    //while (objiptrej.dr.Read())
                                                    //{
                                                    //    string value1 = objiptrej.dr[0].ToString();
                                                    //    if (Convert.ToInt32(value1) <= 0)
                                                    //    {
                                                    //        str = "Insert into ErrorStatus(" + SnoName + "," + msgidName + "," + commaccName + "," + fldName + ") values(" + fldval1 + ",'" + lststr1[j].ToString() + "')";
                                                    //        obj.exec(str);

                                                    //    }
                                                    //}
                                                }

                                            }
                                            objipt = new MyClass();
                                            objipt.dr = objipt.ret_dr("select * FROM InNonHeaderTbl where MSGId='" + strvalue + "'");
                                            while (objipt.dr.Read())
                                            {
                                                string value = objipt.dr["MSGId"].ToString();
                                                if (!string.IsNullOrWhiteSpace(value))
                                                {
                                                    str = "update InNonHeaderTbl set  Status='ERR' where MSGId='" + strvalue + "'";
                                                    obj.exec(str);

                                                    str = "delete from DownXmlTbl where FName='" + flanme + "' and tradeID='" + folName + "'";
                                                    obj.exec(str);

                                                    ffname = "INP";

                                                    str = "Insert into InnonErrorStatus(" + SnoName + "," + msgidName + "," + commaccName + "," + fldName + ") values(" + fldval1 + ",'" + lststr1[j].ToString() + "')";
                                                    obj.exec(str);

                                                    //MyClass objiptrej = new MyClass();
                                                    //objiptrej.dr = objiptrej.ret_dr("select Count(*) FROM InnonErrorStatus where MsgID='" + strvalue + "'");
                                                    //while (objiptrej.dr.Read())
                                                    //{
                                                    //    string value1 = objiptrej.dr[0].ToString();
                                                    //    if (Convert.ToInt32(value1) <= 0)
                                                    //    {
                                                    

                                                    //    }
                                                    //}
                                                }

                                            }
                                            objipt = new MyClass();
                                            objipt.dr = objipt.ret_dr("select * FROM OutHeaderTbl where MSGId='" + strvalue + "'");
                                            while (objipt.dr.Read())
                                            {
                                                string value = objipt.dr["MSGId"].ToString();
                                                if (!string.IsNullOrWhiteSpace(value))
                                                {
                                                    str = "update OutHeaderTbl set  Status='ERR' where MSGId='" + strvalue + "'";
                                                    obj.exec(str);

                                                    str = "delete from DownXmlTbl where FName='" + flanme + "' and tradeID='" + folName + "'";
                                                    obj.exec(str);

                                                    ffname = "OUT";

                                                    str = "Insert into OutErrorStatus(" + SnoName + "," + msgidName + "," + commaccName + "," + fldName + ") values(" + fldval1 + ",'" + lststr1[j].ToString() + "')";
                                                    obj.exec(str);

                                                    //str = "delete from DownXmlTbl where FName='" + strvalue + "'.xml.1";
                                                    //obj.exec(str);

                                                    //MyClass objiptrej = new MyClass();
                                                    //objiptrej.dr = objiptrej.ret_dr("select Count(*) FROM OutErrorStatus where MsgID='" + strvalue + "'");
                                                    //while (objiptrej.dr.Read())
                                                    //{
                                                    //    string value1 = objiptrej.dr[0].ToString();
                                                    //    if (Convert.ToInt32(value1) <= 0)
                                                    //    {
                                                    

                                                    //    }
                                                    //}
                                                }

                                            }
                                            objipt = new MyClass();
                                            objipt.dr = objipt.ret_dr("select * FROM TranshipmentHeader where MSGId='" + strvalue + "'");
                                            while (objipt.dr.Read())
                                            {
                                                string value = objipt.dr["MSGId"].ToString();
                                                if (!string.IsNullOrWhiteSpace(value))
                                                {
                                                    str = "update TranshipmentHeader set  Status='ERR' where MSGId='" + strvalue + "'";
                                                    obj.exec(str);

                                                    str = "delete from DownXmlTbl where FName='" + flanme + "' and tradeID='" + folName + "'";
                                                    obj.exec(str);
                                                    //str = "delete from DownXmlTbl where FName='" + strvalue + "'.xml.1";
                                                    //obj.exec(str);

                                                    ffname = "TNP";

                                                    str = "Insert into TransErrorStatus(" + SnoName + "," + msgidName + "," + commaccName + "," + fldName + ") values(" + fldval1 + ",'" + lststr1[j].ToString() + "')";
                                                    obj.exec(str);

                                                    //MyClass objiptrej = new MyClass();
                                                    //objiptrej.dr = objiptrej.ret_dr("select Count(*) FROM TransErrorStatus where MsgID='" + strvalue + "'");
                                                    //while (objiptrej.dr.Read())
                                                    //{
                                                    //    string value1 = objiptrej.dr[0].ToString();
                                                    //    if (Convert.ToInt32(value1) <= 0)
                                                    //    {
                                                    

                                                    //    }
                                                    //}
                                                }

                                            }
                                            objipt = new MyClass();
                                            objipt.dr = objipt.ret_dr("select * FROM COHeaderTbl where MSGId='" + strvalue + "'");
                                            while (objipt.dr.Read())
                                            {
                                                string value = objipt.dr["MSGId"].ToString();
                                                if (!string.IsNullOrWhiteSpace(value))
                                                {
                                                    str = "update COHeaderTbl set  Status='ERR' where MSGId='" + strvalue + "'";
                                                    obj.exec(str);

                                                    str = "delete from DownXmlTbl where FName='" + flanme + "' and tradeID='" + folName + "'";
                                                    obj.exec(str);
                                                    //str = "delete from DownXmlTbl where FName='" + strvalue + "'.xml.1";
                                                    //obj.exec(str);
                                                    ffname = "COO";

                                                    str = "Insert into COErrorStatus(" + SnoName + "," + msgidName + "," + commaccName + "," + fldName + ") values(" + fldval1 + ",'" + lststr1[j].ToString() + "')";
                                                    obj.exec(str);

                                                    //MyClass objiptrej = new MyClass();
                                                    //objiptrej.dr = objiptrej.ret_dr("select Count(*) FROM COErrorStatus where MsgID='" + strvalue + "'");
                                                    //while (objiptrej.dr.Read())
                                                    //{
                                                    //    string value1 = objiptrej.dr[0].ToString();
                                                    //    if (Convert.ToInt32(value1) <= 0)
                                                    //    {
                                                    

                                                    //    }
                                                    //}
                                                }

                                            }
                                        }
                                        if (!string.IsNullOrWhiteSpace(ffname))
                                        {
                                            string sourceFile = @"D:\MHAccess\workingdir\KaizenIN\" + folName + file;
                                            string destinationFile = @"D:\MHAccess\workingdir\KaizenIN\" + folName + "\\CopyFile\\" + file;

                                            System.IO.File.Copy(sourceFile, destinationFile);
                                            File.Delete(sourceFile);
                                        }
                                        //string sourceFile = @"C:\Users\Public\ResponseFile\" + file;
                                        //string destinationFile = @"C:\Users\Public\CopyFile\" + file;
                                        //if (File.Exists(destinationFile))
                                        //{
                                        //    File.Delete(destinationFile);
                                        //    System.IO.File.Move(sourceFile, destinationFile);
                                        //}
                                        //else
                                        //{
                                        //    System.IO.File.Move(sourceFile, destinationFile);
                                        //}
                                    }
                                }
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
        public void Cancelxml(string folName)
        {
            try
            {
                string xmlFile = "";

              //  string filePath = @"C:\Users\Public\" + folName + "\\ResponseFile\\";

                string tradeIDXML = tradmail;
                string[] tradID = tradeIDXML.Split('.');
                tradeIDXML = tradID[1].ToString() + "\\";
                string filePath = @"D:\MHAccess\workingdir\KaizenIN\" + tradeIDXML;

                DirectoryInfo apple = new DirectoryInfo(filePath);
                foreach (var file in apple.GetFiles("*"))
                {
                    fldName = "";
                    fldval = "";
                    xmlFile = File.ReadAllText(filePath + file);
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.LoadXml(xmlFile);
                    XmlNode rootNode = xmldoc.DocumentElement;
                    //DisplayNodes(rootNode);
                    //XmlNodeList list = xmldoc.SelectNodes("cac:Permit");    
                    var nodeList1 = xmldoc.GetElementsByTagName("cbc:Date");
                    foreach (XmlNode node in nodeList1)
                    {
                        msgid = node.InnerText;
                    }
                    var nodeList2 = xmldoc.GetElementsByTagName("cbc:SequenceNumeric");
                    foreach (XmlNode node in nodeList2)
                    {
                        pemno = node.InnerText;
                    }
                    string strvalue = pemno.PadLeft(4, '0');
                    strvalue = msgid + strvalue;
                    var nodeList = xmldoc.GetElementsByTagName("app:ApprovalMessage");
                    string Short_Fall = string.Empty;
                    string hdtext = string.Empty;                    
                    var nodeList4 = xmldoc.GetElementsByTagName("cbc:PermitNumber");
                    foreach (XmlNode node in nodeList4)
                    {
                        commaccName = "PermitNumber";
                        commacc = node.InnerText;
                    }
                    var nodeList6 = xmldoc.GetElementsByTagName("cbc:CommonAccessReference");
                    foreach (XmlNode node in nodeList6)
                    {
                        //commaccName1 = "CommonAccessReference";
                        commacc1 = node.InnerText;
                    }
                    var nodeList5 = xmldoc.GetElementsByTagName("cbc:SubmissionDatetime");
                    foreach (XmlNode node in nodeList5)
                    {
                        issueautName = "CancelDate";
                        issueaut = node.InnerText.Substring(0, 8);
                    }
                    if (commacc1 == "STATUS")
                    {
                        foreach (XmlNode node in nodeList)
                        {
                            int sno1 = 0;
                            XmlNodeList children = node.ChildNodes;
                            foreach (XmlNode child in children)
                            {
                                hdtext = child.Name.ToString();
                                string[] hval = hdtext.Split(':');
                                fldval = ""; fldName = "";
                                if (hval[0].ToString() == "cac")
                                {
                                    XmlNodeList children1 = child.ChildNodes;
                                    int chki = 0;
                                    lststr1 = new List<string>();
                                    if (hdtext != "cac:UniqueReferenceNumber")
                                    {
                                        foreach (XmlNode child1 in children1)
                                        {
                                            string name = child1.Name;
                                            string[] hval1 = child1.Name.ToString().Split(':');
                                            if (hval1[1].ToString() == "ConditionCode")
                                            {
                                                sno1 = sno1 + 1;
                                                if (chki == 0)
                                                {
                                                    fldName = fldName + "ConditionCde,";
                                                }
                                                fldval = fldval + "'" + child1.InnerText + "',";
                                            }
                                            else if (hval1[1].ToString() == "FreeText")
                                            {
                                                if (chki == 0)
                                                {
                                                    fldName = fldName + "ConditionDes,";
                                                }
                                                fldval = fldval + "'" + child1.InnerText + "',";
                                            }
                                        }

                                    }
                                    if (!string.IsNullOrWhiteSpace(fldval))
                                    {

                                        fldval1 = "'" + sno1 + "','" + strvalue + "',";
                                        string ffname = "";
                                        string flanme = file.ToString().Substring(0, file.ToString().Length - 2);
                                        //ffname = ffname.Substring(0, 3);
                                        if (!string.IsNullOrWhiteSpace(issueaut))
                                        {
                                            issueaut = issueaut.Insert(4, "/");
                                            issueaut = issueaut.Insert(7, "/");

                                            string date = Convert.ToDateTime(issueaut).ToString("dd/MM/yyyy");
                                            //DateTime date = DateTime.ParseExact(issueaut, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                            //DateTime dt = Convert.ToDateTime(issueaut);
                                            fldval1 = fldval1 + "'" + issueaut + "',";
                                        }
                                        if (!string.IsNullOrWhiteSpace(commacc))
                                        {
                                            fldval1 = fldval1 + "'" + commacc + "',";
                                        }
                                        if (!string.IsNullOrWhiteSpace(ststype))
                                        {
                                            fldval1 = fldval1 + "'" + ststype + "',";
                                        }
                                        fldval1 = fldval1 + fldval;
                                        fldName = fldName.Substring(0, fldName.Length - 1);
                                        fldval1 = fldval1.Substring(0, fldval1.Length - 1);

                                        string str = "";

                                        MyClass objipt = new MyClass();
                                        objipt.dr = objipt.ret_dr("select Count(*) FROM OutHeaderTbl where MSGId='" + strvalue + "'");
                                        while (objipt.dr.Read())
                                        {
                                            string value = objipt.dr[0].ToString();
                                            if (Convert.ToInt32(value) > 0)
                                            {
                                                str = "update OutHeaderTbl set  Status='CNL' where MSGId='" + strvalue + "'";
                                                obj.exec(str);

                                                str = "delete from DownXmlTbl where FName='" + flanme + "' and tradeID='" + folName + "'";
                                                obj.exec(str);

                                                MyClass objiptrej = new MyClass();
                                                objiptrej.dr = objiptrej.ret_dr("select Count(*) FROM InCancel where MsgId='" + strvalue + "'");
                                                while (objiptrej.dr.Read())
                                                {
                                                    string value1 = objiptrej.dr[0].ToString();
                                                    if (Convert.ToInt32(value1) <= 0)
                                                    {
                                                        str = "Insert into InCancel(" + SnoName + "," + msgidName + "," + issueautName + "," + commaccName + "," + fldName + ") values(" + fldval1 + ")";
                                                        obj.exec(str);
                                                        ffname = "IPT";
                                                    }
                                                }
                                            }

                                        }

                                        objipt = new MyClass();
                                        objipt.dr = objipt.ret_dr("select Count(*) FROM InNonHeaderTbl where MSGId='" + strvalue + "'");
                                        while (objipt.dr.Read())
                                        {
                                            string value = objipt.dr[0].ToString();
                                            if (Convert.ToInt32(value) > 0)
                                            {
                                                str = "update InNonHeaderTbl set  Status='CNL' where MSGId='" + strvalue + "'";
                                                obj.exec(str);

                                                str = "delete from DownXmlTbl where FName='" + flanme + "' and tradeID='" + folName + "'";
                                                obj.exec(str);

                                                MyClass objiptrej = new MyClass();
                                                objiptrej.dr = objiptrej.ret_dr("select Count(*) FROM InnonCancelPermit where MsgId='" + strvalue + "'");
                                                while (objiptrej.dr.Read())
                                                {
                                                    string value1 = objiptrej.dr[0].ToString();
                                                    if (Convert.ToInt32(value1) <= 0)
                                                    {
                                                        str = "Insert into InnonCancelPermit(" + SnoName + "," + msgidName + "," + issueautName + "," + commaccName + "," + fldName + ") values(" + fldval1 + ")";
                                                        obj.exec(str);
                                                        ffname = "INP";
                                                    }
                                                }
                                            }

                                        }
                                        objipt = new MyClass();
                                        objipt.dr = objipt.ret_dr("select Count(*) FROM OutHeaderTbl where MSGId='" + strvalue + "'");
                                        while (objipt.dr.Read())
                                        {
                                            string value = objipt.dr[0].ToString();
                                            if (Convert.ToInt32(value) > 0)
                                            {
                                                str = "update OutHeaderTbl set  Status='CNL' where MSGId='" + strvalue + "'";
                                                obj.exec(str);

                                                str = "delete from DownXmlTbl where FName='" + flanme + "' and tradeID='" + folName + "'";
                                                obj.exec(str);

                                                MyClass objiptrej = new MyClass();
                                                objiptrej.dr = objiptrej.ret_dr("select Count(*) FROM OutCancelPermit where MsgId='" + strvalue + "'");
                                                while (objiptrej.dr.Read())
                                                {
                                                    string value1 = objiptrej.dr[0].ToString();
                                                    if (Convert.ToInt32(value1) <= 0)
                                                    {
                                                        str = "Insert into OutCancelPermit(" + SnoName + "," + msgidName + "," + issueautName + "," + commaccName + "," + fldName + ") values(" + fldval1 + ")";
                                                        obj.exec(str);
                                                        ffname = "OUT";
                                                    }
                                                }
                                            }

                                        }
                                        objipt = new MyClass();
                                        objipt.dr = objipt.ret_dr("select Count(*) FROM TranshipmentHeader where MSGId='" + strvalue + "'");
                                        while (objipt.dr.Read())
                                        {
                                            string value = objipt.dr[0].ToString();
                                            if (Convert.ToInt32(value) > 0)
                                            {
                                                str = "update TranshipmentHeader set  Status='CNL' where MSGId='" + strvalue + "'";
                                                obj.exec(str);

                                                str = "delete from DownXmlTbl where FName='" + flanme + "' and tradeID='" + folName + "'";
                                                obj.exec(str);

                                                MyClass objiptrej = new MyClass();
                                                objiptrej.dr = objiptrej.ret_dr("select Count(*) FROM TransCancelPermit where MsgId='" + strvalue + "'");
                                                while (objiptrej.dr.Read())
                                                {
                                                    string value1 = objiptrej.dr[0].ToString();
                                                    if (Convert.ToInt32(value1) <= 0)
                                                    {
                                                        str = "Insert into TransCancelPermit(" + SnoName + "," + msgidName + "," + issueautName + "," + commaccName + "," + fldName + ") values(" + fldval1 + ")";
                                                        obj.exec(str);
                                                        ffname = "TNP";
                                                    }
                                                }
                                            }

                                        }
                                        if (!string.IsNullOrWhiteSpace(ffname))
                                        {
                                            string sourceFile = @"D:\MHAccess\workingdir\KaizenIN\" + folName + file;
                                            string destinationFile = @"D:\MHAccess\workingdir\KaizenIN\" + folName + "\\CopyFile\\" + file;

                                            System.IO.File.Copy(sourceFile, destinationFile);
                                            File.Delete(sourceFile);
                                        }
                                        //string sourceFile = @"C:\Users\Public\ResponseFile\" + file;

                                        //string destinationFile = @"C:\Users\Public\CopyFile\" + file;
                                        //if (File.Exists(destinationFile))
                                        //{
                                        //    File.Delete(destinationFile);
                                        //    System.IO.File.Move(sourceFile, destinationFile);
                                        //}
                                        //else
                                        //{
                                        //    System.IO.File.Move(sourceFile, destinationFile);
                                        //}

                                    }
                                }
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
        public void AmendXml(string folName)
        {
            try
            {
                string xmlFile = "";
                string date = "";
                string date1 = "", date2 = "", date3 = "";

                string filePath = @"C:\Users\Public\" + folName + "\\ResponseFile\\";
                DirectoryInfo apple = new DirectoryInfo(filePath);
                foreach (var file in apple.GetFiles("*"))
                {
                    fldName = "";
                    fldval = "";
                    string Cerno = "";
                    xmlFile = File.ReadAllText(filePath + file);
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.LoadXml(xmlFile);
                    XmlNode rootNode = xmldoc.DocumentElement;
                    //DisplayNodes(rootNode);
                    //XmlNodeList list = xmldoc.SelectNodes("cac:Permit");   
                    var nodeList11 = xmldoc.GetElementsByTagName("cbc:Date");
                    foreach (XmlNode node in nodeList11)
                    {
                        date = node.InnerText;
                        date1 = date.Substring(0, 4);
                        date = date.Remove(0, 4);
                        date2 = date.Substring(0, 2);
                        date = date.Remove(0, 2);
                        date3 = date.Substring(0, 2);
                        date = date1 + "-" + date2 + "-" + date3;
                    }
                    var nodeList1 = xmldoc.GetElementsByTagName("cbc:MessageReference");
                    foreach (XmlNode node in nodeList1)
                    {
                        msgid = node.InnerText;
                    }
                    var nodeList2 = xmldoc.GetElementsByTagName("cbc:PermitNumber");
                    foreach (XmlNode node in nodeList2)
                    {
                        pemno = node.InnerText;
                    }
                    var nodeList = xmldoc.GetElementsByTagName("cac:Permit");
                    string Short_Fall = string.Empty;
                    string hdtext = string.Empty;
                    var nodeList3 = xmldoc.GetElementsByTagName("cac:SCUpdateInformation");
                    string Short_Fall1 = string.Empty;
                    string hdtext1 = string.Empty;
                    AmdFileds = new List<string>();
                    lststr2 = new List<string>();
                    lststr3 = new List<string>();
                    foreach (XmlNode node in nodeList3)
                    {
                        XmlNodeList children = node.ChildNodes;
                        foreach (XmlNode child in children)
                        {
                            hdtext1 = child.Name.ToString();
                            string[] hval = hdtext1.Split(':');
                            if (hval[0].ToString() != "cac")
                            {
                                string val = child.InnerText;
                                AmdFileds.Add(val);
                            }
                        }
                    }
                    int i = 0;
                    fldName = "Sno,";
                    lststr1 = new List<string>();
                    lststr2 = new List<string>();
                    lststr3 = new List<string>();
                    foreach (XmlNode node in nodeList)
                    {
                        XmlNodeList children = node.ChildNodes;
                        foreach (XmlNode child in children)
                        {                            
                            hdtext = child.Name.ToString();
                            string[] hval = hdtext.Split(':');
                            if (hval[0].ToString() != "cac")
                            {
                                if (hdtext != "cbc:OriginalApprovalDatetime")
                                {
                                    string[] authorsList = hdtext.Split(':');
                                    if (hdtext == "cbc:CertificateNumber")
                                    {
                                        Cerno = child.InnerText;
                                        fldName = fldName + authorsList[1].ToString() + ",";
                                        fldval = fldval + "'" + child.InnerText + "'" + ",";
                                    }
                                    else
                                    {                                        
                                        fldName = fldName + authorsList[1].ToString() + ",";
                                        fldval = fldval + "'" + child.InnerText + "'" + ",";
                                    }
                                }
                            }
                            if (hval[0].ToString() == "cac")
                            {
                                XmlNodeList children1 = child.ChildNodes;
                                foreach (XmlNode child1 in children1)
                                {
                                    string name = child1.Name;
                                    string[] hval1 = child1.Name.ToString().Split(':');
                                    if (hval1[1].ToString() == "AgencyCode")
                                    {
                                        if (i == 0)
                                        {
                                            fldName = fldName + hval1[1].ToString() + ",";
                                        }
                                        lststr1.Add(child1.InnerText);
                                    }
                                    else if (hval1[1].ToString() == "ConditionCode")
                                    {
                                        if (i == 0)
                                        {
                                            fldName = fldName + hval1[1].ToString() + ",";
                                        }
                                        lststr2.Add(child1.InnerText);
                                    }
                                    else if (hval1[1].ToString() == "ConditionDescription")
                                    {
                                        if (i == 0)
                                        {
                                            fldName = fldName + hval1[1].ToString() + ",";
                                            i = i + 1;
                                        }
                                        lststr3.Add(child1.InnerText);
                                    }
                                    else
                                    {
                                        fldName = fldName + hval1[1].ToString() + ",";
                                        fldval = fldval + "'" + child1.InnerText + "'" + ",";
                                    }
                                }
                            }
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(fldval))
                    {
                        fldName = fldName.Substring(0, fldName.Length - 1);
                        fldval = fldval.Substring(0, fldval.Length - 1);
                        string ffname = "";
                        string flanme = file.ToString().Substring(0, file.ToString().Length - 2);
                        //ffname = ffname.Substring(0, 3);
                        int sno = 1;
                        ffname = "";
                        for (int j = 0; j < lststr1.Count; j++)
                        {
                            string str = "";
                            if (j == 0)
                            {
                                MyClass objipt = new MyClass();
                                objipt.dr = objipt.ret_dr("select Count(*) FROM OutHeaderTbl where MSGId='" + msgid + "'");
                                while (objipt.dr.Read())
                                {
                                    string value = objipt.dr[0].ToString();
                                    if (Convert.ToInt32(value) > 0)
                                    {
                                        str = "update OutHeaderTbl set  PermitNumber='" + pemno + "',Status='AME' where MSGId='" + msgid + "'";
                                        obj.exec(str);

                                        str = "delete from DownXmlTbl where FName='" + flanme + "' and tradeID='" + folName + "'";
                                        obj.exec(str);

                                        MyClass objiptrej = new MyClass();
                                        objiptrej.dr = objiptrej.ret_dr("select Count(*) FROM InAMDPMT where PermitNumber='" + pemno + "'");
                                        while (objiptrej.dr.Read())
                                        {
                                            string value1 = objiptrej.dr[0].ToString();
                                            if (Convert.ToInt32(value1) <= 0)
                                            {
                                                ffname = "IPT";
                                            }
                                            else
                                            {
                                                ffname = "IPT";
                                                obj.exec("delete FROM InAMDPMT where PermitNumber='" + pemno + "'");
                                            }
                                        }
                                    }

                                }
                                objipt = new MyClass();
                                objipt.dr = objipt.ret_dr("select Count(*) FROM InNonHeaderTbl where MSGId='" + msgid + "'");
                                while (objipt.dr.Read())
                                {
                                    string value = objipt.dr[0].ToString();
                                    if (Convert.ToInt32(value) > 0)
                                    {
                                        str = "update InNonHeaderTbl set  PermitNumber='" + pemno + "',Status='AME' where MSGId='" + msgid + "' ";
                                        obj.exec(str);


                                        str = "delete from DownXmlTbl where FName='" + flanme + "' and tradeID='" + folName + "'";
                                        obj.exec(str);
                                        //ffname = "INP";
                                        MyClass objiptrej = new MyClass();
                                        objiptrej.dr = objiptrej.ret_dr("select Count(*) FROM InnonAMDPMT where PermitNumber='" + pemno + "'");
                                        while (objiptrej.dr.Read())
                                        {
                                            string value1 = objiptrej.dr[0].ToString();
                                            if (Convert.ToInt32(value1) <= 0)
                                            {
                                                ffname = "INP";
                                            }
                                            else
                                            {
                                                ffname = "INP";
                                                obj.exec("delete FROM InnonAMDPMT where PermitNumber='" + pemno + "'");
                                            }

                                        }

                                    }

                                }
                                objipt = new MyClass();
                                objipt.dr = objipt.ret_dr("select Count(*) FROM OutHeaderTbl where MSGId='" + msgid + "'");
                                while (objipt.dr.Read())
                                {
                                    string value = objipt.dr[0].ToString();
                                    if (Convert.ToInt32(value) > 0)
                                    {
                                        str = "update OutHeaderTbl set  PermitNumber='" + pemno + "',Status='AME',CertificateNumber='"+Cerno+"' where MSGId='" + msgid + "'";
                                        obj.exec(str);


                                        str = "delete from DownXmlTbl where FName='" + flanme + "' and tradeID='" + folName + "'";
                                        obj.exec(str);
                                        ffname = "OUT";
                                        MyClass objiptrej = new MyClass();
                                        objiptrej.dr = objiptrej.ret_dr("select Count(*) FROM OutAMDPMT where PermitNumber='" + pemno + "'");
                                        while (objiptrej.dr.Read())
                                        {
                                            string value1 = objiptrej.dr[0].ToString();
                                            if (Convert.ToInt32(value1) <= 0)
                                            {
                                                ffname = "OUT";
                                            }
                                            else
                                            {
                                                ffname = "OUT";
                                                obj.exec("delete FROM OutAMDPMT where PermitNumber='" + pemno + "'");
                                            }
                                        }
                                    }

                                }
                                objipt = new MyClass();
                                objipt.dr = objipt.ret_dr("select Count(*) FROM TranshipmentHeader where MSGId='" + msgid + "'");
                                while (objipt.dr.Read())
                                {
                                    string value = objipt.dr[0].ToString();
                                    if (Convert.ToInt32(value) > 0)
                                    {
                                        str = "update TranshipmentHeader set  PermitNumber='" + pemno + "',Status='AME' where MSGId='" + msgid + "'";
                                        obj.exec(str);

                                        str = "delete from DownXmlTbl where FName='" + flanme + "' and tradeID='" + folName + "'";
                                        obj.exec(str);
                                        ffname = "TNP";
                                        MyClass objiptrej = new MyClass();
                                        objiptrej.dr = objiptrej.ret_dr("select Count(*) FROM TransAMDPMT where PermitNumber='" + pemno + "'");
                                        while (objiptrej.dr.Read())
                                        {
                                            string value1 = objiptrej.dr[0].ToString();
                                            if (Convert.ToInt32(value1) <= 0)
                                            {
                                                ffname = "TNP";
                                            }
                                            else
                                            {
                                                ffname = "TNP";
                                                obj.exec("delete FROM TransAMDPMT where PermitNumber='" + pemno + "'");
                                            }
                                        }
                                    }

                                }
                                objipt = new MyClass();
                                objipt.dr = objipt.ret_dr("select Count(*) FROM COHeaderTbl where MSGId='" + msgid + "'");
                                while (objipt.dr.Read())
                                {
                                    string value = objipt.dr[0].ToString();
                                    if (Convert.ToInt32(value) > 0)
                                    {
                                        str = "update COHeaderTbl set  PermitNumber='" + pemno + "',Status='AME' where MSGId='" + msgid + "'";
                                        obj.exec(str);

                                        str = "delete from DownXmlTbl where FName='" + flanme + "' and tradeID='" + folName + "'";
                                        obj.exec(str);

                                        ffname = "COO";
                                    }

                                }
                            }

                            lststr1[j] = lststr1[j].Replace("'", "~");
                            lststr2[j] = lststr2[j].Replace("'", "~");
                            string mnhhs = lststr3[j].ToString();
                            lststr3[j] = lststr3[j].Replace("'", "~");
                            mnhhs = lststr3[j].ToString();
                            if (ffname == "IPT")
                            {
                                str = "insert into InAMDPMT(" + fldName + ") values('" + sno + "'," + fldval + ",'" + lststr1[j].ToString() + "','" + lststr2[j].ToString() + "','" + lststr3[j].ToString() + "')";
                                obj.exec(str);
                                sno = sno + 1;
                            }
                            else if (ffname == "INP")
                            {
                                str = "insert into InnonAMDPMT(" + fldName + ") values('" + sno + "'," + fldval + ",'" + lststr1[j].ToString() + "','" + lststr2[j].ToString() + "','" + lststr3[j].ToString() + "')";
                                obj.exec(str);
                                sno = sno + 1;
                            }
                            else if (ffname == "OUT")
                            {
                                str = "insert into OutAMDPMT(" + fldName + ") values('" + sno + "'," + fldval + ",'" + lststr1[j].ToString() + "','" + lststr2[j].ToString() + "','" + lststr3[j].ToString() + "')";
                                obj.exec(str);
                                sno = sno + 1;
                            }
                            else if (ffname == "TNP")
                            {
                                str = "insert into TransAMDPMT(" + fldName + ") values('" + sno + "'," + fldval + ",'" + lststr1[j].ToString() + "','" + lststr2[j].ToString() + "','" + lststr3[j].ToString() + "')";
                                obj.exec(str);
                                sno = sno + 1;
                            }

                        }
                        for (int j = 0; j < AmdFileds.Count; j++)
                        {                            
                            string str1 = "";
                            if (ffname == "IPT")
                            {
                                str1 = "insert into amndtbl(PermitNum,AmdDate,CodtionCde,DecType,MSGId) values('" + pemno + "','" + Convert.ToDateTime(date).ToString("yyyy/MM/dd") + "','" + AmdFileds[j].ToString() + "','IPTDEC','" + msgid + "')";
                                obj.exec(str1);
                            }
                            else if (ffname == "INP")
                            {
                                str1 = "insert into amndtbl(PermitNum,AmdDate,CodtionCde,DecType,MSGId) values('" + pemno + "','" + Convert.ToDateTime(date).ToString("yyyy/MM/dd") + "','" + AmdFileds[j].ToString() + "','INPDEC','" + msgid + "')";
                                obj.exec(str1);
                            }
                            else if (ffname == "OUT")
                            {
                                str1 = "insert into amndtbl(PermitNum,AmdDate,CodtionCde,DecType,MSGId) values('" + pemno + "','" + Convert.ToDateTime(date).ToString("yyyy/MM/dd") + "','" + AmdFileds[j].ToString() + "','OUTDEC','" + msgid + "')";
                                obj.exec(str1);
                            }
                            else if (ffname == "TNP")
                            {
                                str1 = "insert into amndtbl(PermitNum,AmdDate,CodtionCde,DecType,MSGId) values('" + pemno + "','" + Convert.ToDateTime(date).ToString("yyyy/MM/dd") + "','" + AmdFileds[j].ToString() + "','TNPDEC','" + msgid + "')";
                                obj.exec(str1);
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(ffname))
                        {
                            string sourceFile = @"D:\MHAccess\workingdir\KaizenIN\" + folName + file;
                            string destinationFile = @"D:\MHAccess\workingdir\KaizenIN\" + folName + "\\CopyFile\\" + file;

                            System.IO.File.Copy(sourceFile, destinationFile);
                            File.Delete(sourceFile);
                        }
                        //string sourceFile = @"C:\Users\Public\ResponseFile\" + file;

                        //string destinationFile = @"C:\Users\Public\CopyFile\" + file;
                        //if (File.Exists(destinationFile))
                        //{
                        //    File.Delete(destinationFile);
                        //    System.IO.File.Move(sourceFile, destinationFile);
                        //}
                        //else
                        //{
                        //    System.IO.File.Move(sourceFile, destinationFile);
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public void ResponseXML(string folName)
        {
            try
            {
                string xmlFile = "";
                string updatval = "";


                string tradeIDXML = tradmail;
                string[] tradID = tradeIDXML.Split('.');
                tradeIDXML = tradID[1].ToString() + "\\";
                string filePath = @"D:\MHAccess\workingdir\KaizenIN\" + tradeIDXML;


               // string filePath = @"C:\Users\Public\" + folName + "\\ResponseFile\\";
                DirectoryInfo apple = new DirectoryInfo(filePath);
                foreach (var file in apple.GetFiles("*"))
                {
                    lststr1.Clear();
                    fldName = "";
                    fldval = "";
                    string Cerno = "";
                    lststr1 = new List<string>();
                    lststr2 = new List<string>();
                    lststr3 = new List<string>();
                    //do the thing
                    xmlFile = File.ReadAllText(filePath + file);
                    //xmlFile = filePath + file;
                    // TextBox1.Text = TextBox1.Text + file + Environment.NewLine;
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.LoadXml(xmlFile);
                    XmlNode rootNode = xmldoc.DocumentElement;
                    // DisplayNodes(rootNode);
                    var nodeList1 = xmldoc.GetElementsByTagName("cbc:MessageReference");
                    foreach (XmlNode node in nodeList1)
                    {
                        msgid = node.InnerText;
                    }
                    var nodeList2 = xmldoc.GetElementsByTagName("cbc:PermitNumber");
                    foreach (XmlNode node in nodeList2)
                    {
                        pemno = node.InnerText;
                    }
                    var nodeList21 = xmldoc.GetElementsByTagName("cbc:UpdateIndicatorCode");
                    foreach (XmlNode node in nodeList21)
                    {
                        updatval = node.InnerText;
                    }
                    if (updatval != "AME")
                    {
                        var nodeList = xmldoc.GetElementsByTagName("cac:Permit");
                        string Short_Fall = string.Empty;
                        string hdtext = string.Empty;
                        int i = 0;
                        fldName = "Sno,";
                        
                        foreach (XmlNode node in nodeList)
                        {
                            XmlNodeList children = node.ChildNodes;
                            foreach (XmlNode child in children)
                            {                                
                                hdtext = child.Name.ToString();
                                string[] hval = hdtext.Split(':');
                                if (hval[0].ToString() != "cac")
                                {
                                    string[] authorsList = hdtext.Split(':');
                                    if (child.Name.ToString() == "cbc:CertificateNumber")
                                    {
                                        Cerno = child.InnerText;
                                        fldName = fldName + authorsList[1].ToString() + ",";
                                        fldval = fldval + "'" + child.InnerText + "'" + ",";
                                    }
                                    else
                                    {                                        
                                        fldName = fldName + authorsList[1].ToString() + ",";
                                        fldval = fldval + "'" + child.InnerText + "'" + ",";
                                    }
                                }
                                if (hval[0].ToString() == "cac")
                                {
                                    XmlNodeList children1 = child.ChildNodes;
                                    foreach (XmlNode child1 in children1)
                                    {
                                        string name = child1.Name;
                                        string[] hval1 = child1.Name.ToString().Split(':');
                                        if (hval1[1].ToString() == "AgencyCode")
                                        {
                                            if (i == 0)
                                            {
                                                fldName = fldName + hval1[1].ToString() + ",";
                                            }
                                            lststr1.Add(child1.InnerText);
                                        }
                                        else if (hval1[1].ToString() == "ConditionCode")
                                        {
                                            if (i == 0)
                                            {
                                                fldName = fldName + hval1[1].ToString() + ",";
                                            }
                                            lststr2.Add(child1.InnerText);
                                        }
                                        else if (hval1[1].ToString() == "ConditionDescription")
                                        {
                                            if (i == 0)
                                            {
                                                fldName = fldName + hval1[1].ToString() + ",";
                                                i = i + 1;
                                            }
                                            lststr3.Add(child1.InnerText);
                                        }
                                        else
                                        {
                                            fldName = fldName + hval1[1].ToString() + ",";
                                            fldval = fldval + "'" + child1.InnerText + "'" + ",";
                                        }
                                    }
                                }
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(fldval))
                        {
                            fldName = fldName.Substring(0, fldName.Length - 1);
                            fldval = fldval.Substring(0, fldval.Length - 1);
                            int sno = 1;
                            string ffname = "";
                            string flanme = file.ToString().Substring(0, file.ToString().Length - 2);
                            //ffname = ffname.Substring(0, 3);
                            ffname = "";
                            for (int j = 0; j < lststr1.Count; j++)
                            {
                                string str = "";
                                if (j == 0)
                                {
                                    MyClass objipt = new MyClass();
                                    objipt.dr = objipt.ret_dr("select * FROM OutHeaderTbl where MSGId='" + msgid + "'");
                                    if (objipt.dr.HasRows)
                                    {
                                        while (objipt.dr.Read())
                                        {
                                            string value = objipt.dr["MSGId"].ToString();
                                            if (!string.IsNullOrWhiteSpace(value))
                                            {
                                                str = "update OutHeaderTbl set  PermitNumber='" + pemno + "',Status='APR' where MSGId='" + msgid + "'";
                                                obj.exec(str);

                                                str = "delete from DownXmlTbl where FName='" + flanme + "' and tradeID='" + folName + "'";
                                                obj.exec(str);
                                                MyClass objiptrej = new MyClass();
                                                //objiptrej.dr = objiptrej.ret_dr("select Count(*) FROM InPMT where PermitNumber='" + pemno + "'");
                                                //while (objiptrej.dr.Read())
                                                //{
                                                //    string value1 = objiptrej.dr[0].ToString();
                                                //    if (Convert.ToInt32(value1) <= 0)
                                                //    {
                                                //        ffname = "IPT";
                                                //    }
                                                ffname = "IPT";
                                            }

                                        }
                                    }
                                    objipt = new MyClass();
                                    objipt.dr = objipt.ret_dr("select * FROM InNonHeaderTbl where MSGId='" + msgid + "'");
                                    if (objipt.dr.HasRows)
                                    {
                                        while (objipt.dr.Read())
                                        {
                                            string value = objipt.dr["MSGId"].ToString();
                                            if (!string.IsNullOrWhiteSpace(value))
                                            {
                                                str = "update InNonHeaderTbl set  PermitNumber='" + pemno + "',Status='APR' where MSGId='" + msgid + "'";
                                                obj.exec(str);


                                                str = "delete from DownXmlTbl where FName='" + flanme + "' and tradeID='" + folName + "'s";
                                                obj.exec(str);
                                                //MyClass objiptrej = new MyClass();
                                                //objiptrej.dr = objiptrej.ret_dr("select Count(*) FROM InnonPMT where PermitNumber='" + pemno + "'");
                                                //while (objiptrej.dr.Read())
                                                //{
                                                //    string value1 = objiptrej.dr[0].ToString();
                                                //    if (Convert.ToInt32(value1) <= 0)
                                                //    {
                                                //        ffname = "INP";
                                                //    }
                                                //}
                                                ffname = "INP";
                                            }
                                        }
                                    }
                                    objipt = new MyClass();
                                    objipt.dr = objipt.ret_dr("select * FROM OutHeaderTbl where MSGId='" + msgid + "'");
                                    if (objipt.dr.HasRows)
                                    {
                                        while (objipt.dr.Read())
                                        {
                                            string value = objipt.dr["MSGId"].ToString();
                                            if (!string.IsNullOrWhiteSpace(value))
                                            {
                                                str = "update OutHeaderTbl set  PermitNumber='" + pemno + "',Status='APR',CertificateNumber='"+Cerno+"' where MSGId='" + msgid + "'";
                                                obj.exec(str);


                                                str = "delete from DownXmlTbl where FName='" + flanme + "' and tradeID='" + folName + "'";
                                                obj.exec(str);
                                                //MyClass objiptrej = new MyClass();
                                                //objiptrej.dr = objiptrej.ret_dr("select Count(*) FROM OutPMT where PermitNumber='" + pemno + "'");
                                                //while (objiptrej.dr.Read())
                                                //{
                                                //    string value1 = objiptrej.dr[0].ToString();
                                                //    if (Convert.ToInt32(value1) <= 0)
                                                //    {
                                                ffname = "OUT";
                                                //    }
                                                //}
                                            }
                                        }
                                    }

                                    objipt = new MyClass();
                                    objipt.dr = objipt.ret_dr("select * FROM TranshipmentHeader where MSGId='" + msgid + "'");
                                    if (objipt.dr.HasRows)
                                    {
                                        while (objipt.dr.Read())
                                        {
                                            string value = objipt.dr["MSGId"].ToString();
                                            if (!string.IsNullOrWhiteSpace(value))
                                            {
                                                str = "update TranshipmentHeader set  PermitNumber='" + pemno + "',Status='APR' where MSGId='" + msgid + "'";
                                                obj.exec(str);


                                                str = "delete from DownXmlTbl where FName='" + flanme + "' and tradeID='" + folName + "'";
                                                obj.exec(str);
                                                //MyClass objiptrej = new MyClass();
                                                //objiptrej.dr = objiptrej.ret_dr("select Count(*) FROM TransPMT where PermitNumber='" + pemno + "'");
                                                //while (objiptrej.dr.Read())
                                                //{
                                                //    string value1 = objiptrej.dr[0].ToString();
                                                //    if (Convert.ToInt32(value1) <= 0)
                                                //    {
                                                ffname = "TNP";
                                                //    }
                                                //}
                                            }
                                        }
                                    }

                                    objipt = new MyClass();
                                    objipt.dr = objipt.ret_dr("select * FROM COHeaderTbl where MSGId='" + msgid + "'");
                                    if (objipt.dr.HasRows)
                                    {
                                        while (objipt.dr.Read())
                                        {
                                            string value = objipt.dr[0].ToString();
                                            if (Convert.ToInt32(value) > 0)
                                            {
                                                str = "update COHeaderTbl set  PermitNumber='" + pemno + "',Status='APR' where MSGId='" + msgid + "'";
                                                obj.exec(str);


                                                str = "delete from DownXmlTbl where FName='" + flanme + "' and tradeID='" + folName + "'";
                                                obj.exec(str);
                                                //MyClass objiptrej = new MyClass();
                                                //objiptrej.dr = objiptrej.ret_dr("select Count(*) FROM CoPMT where PermitNumber='" + pemno + "'");
                                                //while (objiptrej.dr.Read())
                                                //{
                                                //    string value1 = objiptrej.dr[0].ToString();
                                                //    if (Convert.ToInt32(value1) <= 0)
                                                //    {
                                                ffname = "COO";
                                                //            }
                                                //        }
                                            }
                                        }
                                    }
                                }
                                //if (j == 0)
                                //{
                                //    if (ffname == "IPT")
                                //    {
                                //        str = "update OutHeaderTbl set  PermitNumber='" + pemno + "',Status='APR' where MSGId='" + msgid + "'";
                                //        obj.exec(str);

                                //        str = "delete from DownXmlTbl where FName='" + msgid + "'.xml.1";
                                //        obj.exec(str);
                                //    }
                                //    else if (ffname == "INP")
                                //    {
                                //        str = "update InNonHeaderTbl set  PermitNumber='" + pemno + "',Status='APR' where MSGId='" + msgid + "'";
                                //        obj.exec(str);

                                //        str = "delete from DownXmlTbl where FName='" + msgid + "'.xml.1";
                                //        obj.exec(str);
                                //    }
                                //    else if (ffname == "OUT")
                                //    {
                                //        str = "update OutHeaderTbl set  PermitNumber='" + pemno + "',Status='APR' where MSGId='" + msgid + "'";
                                //        obj.exec(str);

                                //        str = "delete from DownXmlTbl where FName='" + msgid + "'.xml.1";
                                //        obj.exec(str);
                                //    }
                                //    else if (ffname == "TNP")
                                //    {
                                //        str = "update TranshipmentHeader set  PermitNumber='" + pemno + "',Status='APR' where MSGId='" + msgid + "'";
                                //        obj.exec(str);

                                //        str = "delete from DownXmlTbl where FName='" + msgid + "'.xml.1";
                                //        obj.exec(str);
                                //    }
                                //    else if (ffname == "COO")
                                //    {
                                //        str = "update COHeaderTbl set  PermitNumber='" + pemno + "',Status='APR' where MSGId='" + msgid + "'";
                                //        obj.exec(str);

                                //        str = "delete from DownXmlTbl where FName='" + msgid + "'.xml.1";
                                //        obj.exec(str);
                                //    }

                                //}

                                lststr1[j] = lststr1[j].Replace("'", "~");
                                lststr2[j] = lststr2[j].Replace("'", "~");
                                string mnhhs = lststr3[j].ToString();
                                lststr3[j] = lststr3[j].Replace("'", "~");
                                mnhhs = lststr3[j].ToString();
                                if (ffname == "IPT")
                                {
                                    str = "insert into InPMT(" + fldName + ") values('" + sno + "'," + fldval + ",'" + lststr1[j].ToString() + "','" + lststr2[j].ToString() + "','" + lststr3[j].ToString() + "')";
                                    obj.exec(str);
                                    sno = sno + 1;
                                }
                                else if (ffname == "INP")
                                {
                                    str = "insert into InnonPMT(" + fldName + ") values('" + sno + "'," + fldval + ",'" + lststr1[j].ToString() + "','" + lststr2[j].ToString() + "','" + lststr3[j].ToString() + "')";
                                    obj.exec(str);
                                    sno = sno + 1;
                                }
                                else if (ffname == "OUT")
                                {
                                    str = "insert into OutPMT(" + fldName + ") values('" + sno + "'," + fldval + ",'" + lststr1[j].ToString() + "','" + lststr2[j].ToString() + "','" + lststr3[j].ToString() + "')";
                                    obj.exec(str);
                                    sno = sno + 1;
                                }
                                else if (ffname == "TNP")
                                {
                                    str = "insert into TransPMT(" + fldName + ") values('" + sno + "'," + fldval + ",'" + lststr1[j].ToString() + "','" + lststr2[j].ToString() + "','" + lststr3[j].ToString() + "')";
                                    obj.exec(str);
                                    sno = sno + 1;
                                }
                                else if (ffname == "COO")
                                {
                                    str = "insert into CoPMT(" + fldName + ") values('" + sno + "'," + fldval + ",'" + lststr1[j].ToString() + "','" + lststr2[j].ToString() + "','" + lststr3[j].ToString() + "')";
                                    obj.exec(str);
                                    sno = sno + 1;
                                }

                            }
                            if (!string.IsNullOrWhiteSpace(ffname))
                            {
                                string sourceFile = @"D:\MHAccess\workingdir\KaizenIN\" + folName + file;
                                string destinationFile = @"D:\MHAccess\workingdir\KaizenIN\" + folName + "\\CopyFile\\" + file;

                                System.IO.File.Copy(sourceFile, destinationFile);
                                File.Delete(sourceFile);
                            }
                            //string sourceFile = @"C:\Users\Public\ResponseFile\" + file;

                            //string destinationFile = @"C:\Users\Public\CopyFile\" + file;
                            //if (File.Exists(destinationFile))
                            //{
                            //    File.Delete(destinationFile);
                            //    System.IO.File.Move(sourceFile, destinationFile);
                            //}
                            //else
                            //{
                            //    System.IO.File.Move(sourceFile, destinationFile);
                            //}
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public void search()
        {
          //  colorchange();
            string condidtion = "", str = "";
            string JobId = txtJobId.Text;
            //string JobId = (GridInPayment.FooterRow.FindControl("txtJobId") as TextBox).Text;
            string MSGId = (GridInPayment.FooterRow.FindControl("txtMSGId") as TextBox).Text;
            string DecDate = (GridInPayment.FooterRow.FindControl("txtDecDate") as TextBox).Text;
            string Createby = (GridInPayment.FooterRow.FindControl("txtCreateby") as TextBox).Text;
            string DeclarationType = (GridInPayment.FooterRow.FindControl("txtDeclarationType") as TextBox).Text;
            string DecId = (GridInPayment.FooterRow.FindControl("txtDecId") as TextBox).Text;
            string ETA = (GridInPayment.FooterRow.FindControl("txtETD") as TextBox).Text;
            string PermitNo = (GridInPayment.FooterRow.FindControl("txtPermitNo") as TextBox).Text;
            string OutImporter = (GridInPayment.FooterRow.FindControl("txtExporter") as TextBox).Text;
            string InHAWBOBL = (GridInPayment.FooterRow.FindControl("txtInHAWBOBL") as TextBox).Text;
            string MAWBOBL = (GridInPayment.FooterRow.FindControl("txtMAWBOBL") as TextBox).Text;
            string LoadingPortCode = (GridInPayment.FooterRow.FindControl("txtPOD") as TextBox).Text;
            string MessageType = (GridInPayment.FooterRow.FindControl("txtMessageType") as TextBox).Text;
            string InwardTransportMode = (GridInPayment.FooterRow.FindControl("txtOutwardTransportMode") as TextBox).Text;

            string PreviousPermit = (GridInPayment.FooterRow.FindControl("txtPreviousPermit") as TextBox).Text;
            string InternalRemarks = (GridInPayment.FooterRow.FindControl("txtInternalRemarks") as TextBox).Text;
           // string TermType = (GridInPayment.FooterRow.FindControl("txtTermType") as TextBox).Text;

            string Status = (GridInPayment.FooterRow.FindControl("txtStatus") as TextBox).Text;
            string gstsum = (GridInPayment.FooterRow.FindControl("txtGSTSUMAmount") as TextBox).Text;






            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {

                if (!string.IsNullOrWhiteSpace(JobId))
                {
                    condidtion = condidtion + "t1.JobId like '%" + JobId + "%' and ";
                }

                if (!string.IsNullOrWhiteSpace(MSGId))
                {
                    condidtion = condidtion + "t1.MSGId like '%" + MSGId + "%' and ";
                }

                if (!string.IsNullOrWhiteSpace(DecDate))
                {
                    condidtion = condidtion + "convert(varchar, t1.TouchTime, 105) like '%" + DecDate + "%' and ";
                }

                if (!string.IsNullOrWhiteSpace(DeclarationType))
                {
                    condidtion = condidtion + "Substring(DeclarationType , 1,Charindex(':', DeclarationType)-1) like '%" + DeclarationType + "%' and ";
                }

                if (!string.IsNullOrWhiteSpace(Createby))
                {
                    condidtion = condidtion + "t1.TouchUser like '%" + Createby + "%' and ";
                }

                if (!string.IsNullOrWhiteSpace(DecId))
                {
                    condidtion = condidtion + "t2.TradeNetMailboxID like '%" + DecId + "%' and ";
                }

                if (!string.IsNullOrWhiteSpace(ETA))
                {
                    condidtion = condidtion + "convert(varchar, DepartureDate, 105) like '%" + ETA + "%' and ";
                }

                if (!string.IsNullOrWhiteSpace(PermitNo))
                {
                    condidtion = condidtion + "t1.PermitId like '%" + PermitNo + "%' and ";
                }

                if (!string.IsNullOrWhiteSpace(OutImporter))
                {
                    condidtion = condidtion + "t3.OutUserName like '%" + OutImporter + "%' and ";
                }

                if (!string.IsNullOrWhiteSpace(InHAWBOBL))
                {
                    condidtion = condidtion + "t4.InHAWBOBL like '%" + InHAWBOBL + "%' and ";
                }


                if (!string.IsNullOrWhiteSpace(MAWBOBL))
                {
                    condidtion = condidtion + "(t1.MasterAirwayBill like '%" + MAWBOBL + "%' or t1.OceanBillofLadingNo Like '%" + MAWBOBL + "%') and ";
                }

                if (!string.IsNullOrWhiteSpace(LoadingPortCode))
                {
                    condidtion = condidtion + "t1.DischargePort like '%" + LoadingPortCode + "%' and ";
                }

                if (!string.IsNullOrWhiteSpace(MessageType))
                {
                    condidtion = condidtion + "t1.MessageType like '%" + MessageType + "%' and ";
                }

                if (!string.IsNullOrWhiteSpace(InwardTransportMode))
                {
                    condidtion = condidtion + "t1.OutwardTransportMode like '%" + InwardTransportMode + "%' and ";
                }

                if (!string.IsNullOrWhiteSpace(PreviousPermit))
                {
                    condidtion = condidtion + "t1.PreviousPermit like '%" + PreviousPermit + "%' and ";
                }
                if (!string.IsNullOrWhiteSpace(InternalRemarks))
                {
                    condidtion = condidtion + "t1.InternalRemarks like '%" + InternalRemarks + "%' and ";
                }
                


                if (!string.IsNullOrWhiteSpace(Status))
                {
                    condidtion = condidtion + "t1.Status like '%" + Status + "%' and ";
                }


                string SUMMM = "";
                if (!string.IsNullOrWhiteSpace(gstsum))
                {
                    SUMMM = " HAVING SUM(t5.GSTSUMAmount) ='" + gstsum + "'  ";
                }

                if (!string.IsNullOrWhiteSpace(condidtion))
                {
                    condidtion = condidtion.Substring(0, condidtion.Length - 4);
                }


                if (condidtion == "")
                {
                    if (SUMMM == "")
                    {
                         str = "SELECT  t1.Id, t1.JobId, t1.MSGId,CONVERT(varchar, t1.TouchTime, 105) AS DecDate, SUBSTRING(t1.DeclarationType, 1,  CHARINDEX(':', t1.DeclarationType) - 1) AS DeclarationType, t1.TouchUser AS Createby, t2.TradeNetMailboxID AS DecId, CONVERT(varchar, t1.DepartureDate, 105) AS ETD, t1.PermitId AS LocalNo, t1.PermitNumber AS PermitNo, t1.PreviousPermit,t1.CertificateNumber as CertificateNo,t1.COType,t1.CerDetailtype1,t1.CurrencyCode,  t3.OutUserName+' '+t3.OutUserName1 AS Exporter, STUFF((SELECT distinct(', ' +  US.InHAWBOBL) FROM OutItemDtl US  WHERE US.PermitId = t1.PermitId  FOR XML PATH('')), 1, 1, '') InHAWBOBL,CASE   WHEN  t1.OutwardTransportMode = '4 : Air' THEN t1.MasterAirwayBill     WHEN t1.OutwardTransportMode = '1 : Sea'  THEN t1.OceanBillofLadingNo    ELSE ''  END AS MAWBOBL, t1.DischargePort as POD, t1.MessageType, t1.OutwardTransportMode, t1.InternalRemarks,  SUM(t5.GSTSUMAmount) AS GSTSUMAmount,  (select Count(ItemNo) from OutItemDtl   where   OutItemDtl.PermitId=t1.PermitId) as SumOfItem, t1.Status    FROM  OutHeaderTbl AS t1 INNER JOIN   DeclarantCompany AS t2   ON t1.DeclarantCompanyCode = t2.Code   INNER JOIN OutExporter AS t3   ON t1.ExporterCompanyCode = t3.OutUserCode   INNER JOIN OutInvoiceDtl AS t5   ON t1.PermitId = t5.PermitId  INNER JOIN ManageUser AS t6 ON t6.UserId=t1.TouchUser  where t6.AccountId='" + Session["AccountId"].ToString() + "'  and t2.TradeNetMailboxID='" + tradmail + "'   GROUP BY t1.Id, t1.JobId, t1.MSGId, t1.TouchTime, t1.TouchUser, t1.DeclarationType, t1.DepartureDate, t1.PermitId,t1.PermitNumber,t1.PreviousPermit, t1.OutwardTransportMode, t1.MasterAirwayBill, t1.OceanBillofLadingNo, t1.DischargePort, t1.MessageType, t1.InwardTransportMode, t1.PreviousPermit,t1.COType,t1.CerDetailtype1,t1.CurrencyCode, t1.InternalRemarks,t1.CertificateNumber, t1.Status, t2.TradeNetMailboxID, t3.OutUserName,t3.OutUserName1,t6.AccountId order by t1.Id Desc";


                    }
                    else
                    {
                        str = "SELECT  t1.Id, t1.JobId, t1.MSGId,CONVERT(varchar, t1.TouchTime, 105) AS DecDate, SUBSTRING(t1.DeclarationType, 1,  CHARINDEX(':', t1.DeclarationType) - 1) AS DeclarationType, t1.TouchUser AS Createby, t2.TradeNetMailboxID AS DecId, CONVERT(varchar, t1.DepartureDate, 105) AS ETD, t1.PermitId AS LocalNo, t1.PermitNumber AS PermitNo, t1.PreviousPermit,t1.CertificateNumber as CertificateNo,t1.COType,t1.CerDetailtype1,t1.CurrencyCode,  t3.OutUserName+' '+t3.OutUserName1 AS Exporter, STUFF((SELECT distinct(', ' +  US.InHAWBOBL) FROM OutItemDtl US  WHERE US.PermitId = t1.PermitId  FOR XML PATH('')), 1, 1, '') InHAWBOBL,CASE   WHEN  t1.OutwardTransportMode = '4 : Air' THEN t1.MasterAirwayBill     WHEN t1.OutwardTransportMode = '1 : Sea'  THEN t1.OceanBillofLadingNo    ELSE ''  END AS MAWBOBL, t1.DischargePort as POD, t1.MessageType, t1.OutwardTransportMode, t1.InternalRemarks,  SUM(t5.GSTSUMAmount) AS GSTSUMAmount,  (select Count(ItemNo) from OutItemDtl   where   OutItemDtl.PermitId=t1.PermitId) as SumOfItem, t1.Status    FROM  OutHeaderTbl AS t1 INNER JOIN   DeclarantCompany AS t2   ON t1.DeclarantCompanyCode = t2.Code   INNER JOIN OutExporter AS t3   ON t1.ExporterCompanyCode = t3.OutUserCode   INNER JOIN OutInvoiceDtl AS t5   ON t1.PermitId = t5.PermitId  INNER JOIN ManageUser AS t6 ON t6.UserId=t1.TouchUser  where t6.AccountId='" + Session["AccountId"].ToString() + "'  and t2.TradeNetMailboxID='" + tradmail + "'   GROUP BY t1.Id, t1.JobId, t1.MSGId, t1.TouchTime, t1.TouchUser, t1.DeclarationType, t1.DepartureDate, t1.PermitId,t1.PermitNumber,t1.PreviousPermit, t1.OutwardTransportMode, t1.MasterAirwayBill, t1.OceanBillofLadingNo, t1.DischargePort, t1.MessageType, t1.InwardTransportMode, t1.PreviousPermit,t1.COType,t1.CerDetailtype1,t1.CurrencyCode, t1.InternalRemarks,t1.CertificateNumber, t1.Status, t2.TradeNetMailboxID, t3.OutUserName,t3.OutUserName1,t6.AccountId  " + SUMMM + " order by t1.Id Desc";


                    }
                }
                else
                {
                    if (SUMMM == "")
                    {
                        str = "SELECT  t1.Id, t1.JobId, t1.MSGId,CONVERT(varchar, t1.TouchTime, 105) AS DecDate, SUBSTRING(t1.DeclarationType, 1,  CHARINDEX(':', t1.DeclarationType) - 1) AS DeclarationType, t1.TouchUser AS Createby, t2.TradeNetMailboxID AS DecId, CONVERT(varchar, t1.DepartureDate, 105) AS ETD, t1.PermitId AS LocalNo, t1.PermitNumber AS PermitNo, t1.PreviousPermit,t1.CertificateNumber as CertificateNo,t1.COType,t1.CerDetailtype1,t1.CurrencyCode,  t3.OutUserName+' '+t3.OutUserName1 AS Exporter, STUFF((SELECT distinct(', ' +  US.InHAWBOBL) FROM OutItemDtl US  WHERE US.PermitId = t1.PermitId  FOR XML PATH('')), 1, 1, '') InHAWBOBL,CASE   WHEN  t1.OutwardTransportMode = '4 : Air' THEN t1.MasterAirwayBill     WHEN t1.OutwardTransportMode = '1 : Sea'  THEN t1.OceanBillofLadingNo    ELSE ''  END AS MAWBOBL, t1.DischargePort as POD, t1.MessageType, t1.OutwardTransportMode, t1.InternalRemarks,  SUM(t5.GSTSUMAmount) AS GSTSUMAmount,  (select Count(ItemNo) from OutItemDtl   where   OutItemDtl.PermitId=t1.PermitId) as SumOfItem, t1.Status    FROM  OutHeaderTbl AS t1 INNER JOIN   DeclarantCompany AS t2   ON t1.DeclarantCompanyCode = t2.Code   INNER JOIN OutExporter AS t3   ON t1.ExporterCompanyCode = t3.OutUserCode   INNER JOIN OutInvoiceDtl AS t5   ON t1.PermitId = t5.PermitId  INNER JOIN ManageUser AS t6 ON t6.UserId=t1.TouchUser  where t6.AccountId='" + Session["AccountId"].ToString() + "'  and t2.TradeNetMailboxID='" + tradmail + "'   and " + condidtion + "   GROUP BY t1.Id, t1.JobId, t1.MSGId, t1.TouchTime, t1.TouchUser, t1.DeclarationType, t1.DepartureDate, t1.PermitId,t1.PermitNumber,t1.PreviousPermit, t1.OutwardTransportMode, t1.MasterAirwayBill, t1.OceanBillofLadingNo, t1.DischargePort, t1.MessageType, t1.InwardTransportMode, t1.PreviousPermit,t1.COType,t1.CerDetailtype1,t1.CurrencyCode, t1.InternalRemarks,t1.CertificateNumber, t1.Status, t2.TradeNetMailboxID, t3.OutUserName,t3.OutUserName1,t6.AccountId  " + SUMMM + " order by t1.Id Desc";


                    }
                    else
                    {
                        str = "SELECT  t1.Id, t1.JobId, t1.MSGId,CONVERT(varchar, t1.TouchTime, 105) AS DecDate, SUBSTRING(t1.DeclarationType, 1,  CHARINDEX(':', t1.DeclarationType) - 1) AS DeclarationType, t1.TouchUser AS Createby, t2.TradeNetMailboxID AS DecId, CONVERT(varchar, t1.DepartureDate, 105) AS ETD, t1.PermitId AS LocalNo, t1.PermitNumber AS PermitNo, t1.PreviousPermit,t1.CertificateNumber as CertificateNo,t1.COType,t1.CerDetailtype1,t1.CurrencyCode,  t3.OutUserName+' '+t3.OutUserName1 AS Exporter, STUFF((SELECT distinct(', ' +  US.InHAWBOBL) FROM OutItemDtl US  WHERE US.PermitId = t1.PermitId  FOR XML PATH('')), 1, 1, '') InHAWBOBL,CASE   WHEN  t1.OutwardTransportMode = '4 : Air' THEN t1.MasterAirwayBill     WHEN t1.OutwardTransportMode = '1 : Sea'  THEN t1.OceanBillofLadingNo    ELSE ''  END AS MAWBOBL, t1.DischargePort as POD, t1.MessageType, t1.OutwardTransportMode, t1.InternalRemarks,  SUM(t5.GSTSUMAmount) AS GSTSUMAmount,  (select Count(ItemNo) from OutItemDtl   where   OutItemDtl.PermitId=t1.PermitId) as SumOfItem, t1.Status    FROM  OutHeaderTbl AS t1 INNER JOIN   DeclarantCompany AS t2   ON t1.DeclarantCompanyCode = t2.Code   INNER JOIN OutExporter AS t3   ON t1.ExporterCompanyCode = t3.OutUserCode   INNER JOIN OutInvoiceDtl AS t5   ON t1.PermitId = t5.PermitId  INNER JOIN ManageUser AS t6 ON t6.UserId=t1.TouchUser  where t6.AccountId='" + Session["AccountId"].ToString() + "'  and t2.TradeNetMailboxID='" + tradmail + "'   and " + condidtion + "   GROUP BY t1.Id, t1.JobId, t1.MSGId, t1.TouchTime, t1.TouchUser, t1.DeclarationType, t1.DepartureDate, t1.PermitId,t1.PermitNumber,t1.PreviousPermit, t1.OutwardTransportMode, t1.MasterAirwayBill, t1.OceanBillofLadingNo, t1.DischargePort, t1.MessageType, t1.InwardTransportMode, t1.PreviousPermit,t1.COType,t1.CerDetailtype1,t1.CurrencyCode, t1.InternalRemarks,t1.CertificateNumber, t1.Status, t2.TradeNetMailboxID, t3.OutUserName,t3.OutUserName1,t6.AccountId  " + SUMMM + " order by t1.Id Desc";


                    }
                }

                //if (condidtion == "")
                //{
                //    str = "SELECT  t1.Id, t1.JobId, t1.MSGId,CONVERT(varchar, t1.TouchTime, 105) AS DecDate, SUBSTRING(t1.DeclarationType, 1,  CHARINDEX(':', t1.DeclarationType) - 1) AS DeclarationType, t1.TouchUser AS Createby, t2.TradeNetMailboxID AS DecId, CONVERT(varchar, t1.DepartureDate, 105) AS ETD, t1.PermitId AS LocalNo, t1.PermitNumber AS PermitNo, t1.PreviousPermit,  t3.OutUserName AS Exporter, STUFF((SELECT distinct(', ' +  US.InHAWBOBL) FROM OutItemDtl US  WHERE US.PermitId = t1.PermitId  FOR XML PATH('')), 1, 1, '') InHAWBOBL,CASE   WHEN  t1.OutwardTransportMode = '4 : Air' THEN t1.MasterAirwayBill     WHEN t1.OutwardTransportMode = '1 : Sea'  THEN t1.OceanBillofLadingNo    ELSE ''  END AS MAWBOBL, t1.DischargePort as POD, t1.MessageType, t1.OutwardTransportMode, t1.InternalRemarks,  SUM(t5.GSTSUMAmount) AS GSTSUMAmount,  (select Count(ItemNo) from OutItemDtl   where   OutItemDtl.PermitId=t1.PermitId) as SumOfItem, t1.Status    FROM  OutHeaderTbl AS t1 INNER JOIN   DeclarantCompany AS t2   ON t1.DeclarantCompanyCode = t2.Code   INNER JOIN OutExporter AS t3   ON t1.ExporterCompanyCode = t3.OutUserCode   INNER JOIN OutInvoiceDtl AS t5   ON t1.PermitId = t5.PermitId  INNER JOIN ManageUser AS t6 ON t6.UserId=t1.TouchUser where t6.AccountId='" + Session["AccountId"].ToString() + "' GROUP BY t1.Id, t1.JobId, t1.MSGId, t1.TouchTime, t1.TouchUser, t1.DeclarationType, t1.DepartureDate, t1.PermitId,t1.PermitNumber,t1.PreviousPermit, t1.OutwardTransportMode, t1.MasterAirwayBill, t1.OceanBillofLadingNo, t1.DischargePort, t1.MessageType, t1.InwardTransportMode, t1.PreviousPermit, t1.InternalRemarks, t1.Status, t2.TradeNetMailboxID, t3.OutUserName,t6.AccountId order by t1.Id Desc";
                //}
                //else
                //{
                //    str = "SELECT  t1.Id, t1.JobId, t1.MSGId,CONVERT(varchar, t1.TouchTime, 105) AS DecDate, SUBSTRING(t1.DeclarationType, 1,  CHARINDEX(':', t1.DeclarationType) - 1) AS DeclarationType, t1.TouchUser AS Createby, t2.TradeNetMailboxID AS DecId, CONVERT(varchar, t1.DepartureDate, 105) AS ETD, t1.PermitId AS LocalNo, t1.PermitNumber AS PermitNo, t1.PreviousPermit,  t3.OutUserName AS Exporter, STUFF((SELECT distinct(', ' +  US.InHAWBOBL) FROM OutItemDtl US  WHERE US.PermitId = t1.PermitId  FOR XML PATH('')), 1, 1, '') InHAWBOBL,CASE   WHEN  t1.OutwardTransportMode = '4 : Air' THEN t1.MasterAirwayBill     WHEN t1.OutwardTransportMode = '1 : Sea'  THEN t1.OceanBillofLadingNo    ELSE ''  END AS MAWBOBL, t1.DischargePort as POD, t1.MessageType, t1.OutwardTransportMode, t1.InternalRemarks,  SUM(t5.GSTSUMAmount) AS GSTSUMAmount,  (select Count(ItemNo) from OutItemDtl   where   OutItemDtl.PermitId=t1.PermitId) as SumOfItem, t1.Status    FROM  OutHeaderTbl AS t1 INNER JOIN   DeclarantCompany AS t2   ON t1.DeclarantCompanyCode = t2.Code   INNER JOIN OutExporter AS t3   ON t1.ExporterCompanyCode = t3.OutUserCode   INNER JOIN OutInvoiceDtl AS t5   ON t1.PermitId = t5.PermitId  INNER JOIN ManageUser AS t6 ON t6.UserId=t1.TouchUser where t6.AccountId='" + Session["AccountId"].ToString() + "'  and " + condidtion + " GROUP BY t1.Id, t1.JobId, t1.MSGId, t1.TouchTime, t1.TouchUser, t1.DeclarationType, t1.DepartureDate, t1.PermitId,t1.PermitNumber,t1.PreviousPermit, t1.OutwardTransportMode, t1.MasterAirwayBill, t1.OceanBillofLadingNo, t1.DischargePort, t1.MessageType, t1.InwardTransportMode, t1.PreviousPermit, t1.InternalRemarks, t1.Status, t2.TradeNetMailboxID, t3.OutUserName,t6.AccountId order by t1.Id Desc";
                // }

                using (SqlCommand cmd = new SqlCommand(str))
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
                                GridInPayment.DataSource = dt;
                                GridInPayment.DataBind();
                            }
                            else //else if no data returned from the DataTable then 
                            {    //call the method ShowNoResultFound()
                                ShowNoResultFound(dt, GridInPayment);
                            }
                            //GridInPayment.DataSource = dt;
                            //GridInPayment.DataBind();

                        }
                    }

                    txtJobId.Text = JobId;
                    //(GridInPayment.FooterRow.FindControl("txtJobId") as TextBox).Text = JobId;
                    (GridInPayment.FooterRow.FindControl("txtMSGId") as TextBox).Text = MSGId;
                    (GridInPayment.FooterRow.FindControl("txtDecDate") as TextBox).Text = DecDate;
                    (GridInPayment.FooterRow.FindControl("txtDeclarationType") as TextBox).Text = DeclarationType;
                    (GridInPayment.FooterRow.FindControl("txtDecId") as TextBox).Text = DecId;
                    (GridInPayment.FooterRow.FindControl("txtETD") as TextBox).Text = ETA;
                    (GridInPayment.FooterRow.FindControl("txtExporter") as TextBox).Text = OutImporter;
                    (GridInPayment.FooterRow.FindControl("txtInHAWBOBL") as TextBox).Text = InHAWBOBL;
                    (GridInPayment.FooterRow.FindControl("txtMAWBOBL") as TextBox).Text = MAWBOBL;
                    (GridInPayment.FooterRow.FindControl("txtPOD") as TextBox).Text = LoadingPortCode;
                    (GridInPayment.FooterRow.FindControl("txtMessageType") as TextBox).Text = MessageType;
                    (GridInPayment.FooterRow.FindControl("txtOutwardTransportMode") as TextBox).Text = InwardTransportMode;
                    (GridInPayment.FooterRow.FindControl("txtPreviousPermit") as TextBox).Text = PreviousPermit;
                    (GridInPayment.FooterRow.FindControl("txtInternalRemarks") as TextBox).Text = InternalRemarks;
                  //  (GridInPayment.FooterRow.FindControl("txtTermType") as TextBox).Text = TermType;

                    (GridInPayment.FooterRow.FindControl("txtStatus") as TextBox).Text = Status;
                    (GridInPayment.FooterRow.FindControl("txtMSGId") as TextBox).Text = MSGId;
                    txtJobId.Text = JobId;
                    //(GridInPayment.FooterRow.FindControl("txtJobId") as TextBox).Text = JobId;
                    (GridInPayment.FooterRow.FindControl("txtMSGId") as TextBox).Text = MSGId;
                    (GridInPayment.FooterRow.FindControl("txtGSTSUMAmount") as TextBox).Text = gstsum;
                    //TextBox txtMSGId = (TextBox)GridInPayment.FooterRow.FindControl("txtMSGId");
                    //txtMSGId.Text = txtbox;
                    // Response.Write(value);
                }
            }
            foreach (GridViewRow gvrow in GridInPayment.Rows)
            {
                if (gvrow != null)
                {
                    Label chk = (Label)gvrow.FindControl("lblStatus");

                    if (chk != null)
                    {
                        string ID = chk.Text;
                        if (ID.ToUpper() == "NEW")
                        {
                            gvrow.Cells[1].Enabled = true;
                            gvrow.Cells[2].Enabled = true;

                        }
                        else
                        {
                            gvrow.Cells[1].Enabled = false;
                            gvrow.Cells[2].Enabled = false;
                        }
                        changestatuscolor();
                        colorchange();
                    }
                }




            }
            //   colorchange();
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
       
        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 3;
            int result;
            foreach (System.Web.UI.WebControls.ListItem item in CheckBoxList1.Items)
            {
                string a = item.Value.ToString();
                string b = item.Text.ToString();

                if (item.Selected)
                {
                    string ax = item.Value.ToString();
                    // string bx= item.Text.ToString();

                    foreach (DataControlField col in GridInPayment.Columns)
                    {
                        if (col.HeaderText == ax)
                        {
                            con.Open();
                            string Touch_user = Session["UserId"].ToString();
                            SqlCommand cmd6 = new SqlCommand("update CustomiseReport set FiledValue='True' where FiledName='" + col.HeaderText + "'  and ReportName='OUT' and UserName='" + Touch_user + "' ", con);
                            result = cmd6.ExecuteNonQuery();
                            con.Close();
                            col.Visible = true;
                        }

                    }

                }
                else
                {
                    string ax = item.Value.ToString();
                    // string bx= item.Text.ToString();

                    foreach (DataControlField col in GridInPayment.Columns)
                    {
                        if (col.HeaderText == ax)
                        {
                            con.Open();
                            string Touch_user = Session["UserId"].ToString();
                            SqlCommand cmd6 = new SqlCommand("update CustomiseReport set FiledValue='False' where FiledName='" + col.HeaderText + "' and ReportName='OUT' and UserName='" + Touch_user + "' ", con);
                            result = cmd6.ExecuteNonQuery();
                            con.Close();
                            col.Visible = false;
                        }
                    }

                }
            }
        }

        protected void CheckBoxList1_TextChanged(object sender, EventArgs e)
        {

        }
        private void BindInPayment()
        {

            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string str = "SELECT  top 10 t1.Id, t1.JobId, t1.MSGId,CONVERT(varchar, t1.TouchTime, 105) AS DecDate, SUBSTRING(t1.DeclarationType, 1,  CHARINDEX(':', t1.DeclarationType) - 1) AS DeclarationType, t1.TouchUser AS Createby, t2.TradeNetMailboxID AS DecId, CONVERT(varchar, t1.DepartureDate, 105) AS ETD, t1.PermitId AS LocalNo, t1.PermitNumber AS PermitNo, t1.PreviousPermit,t1.CertificateNumber as CertificateNo,t1.COType,t1.CerDetailtype1,t1.CurrencyCode,  t3.OutUserName+' '+t3.OutUserName1 AS Exporter, STUFF((SELECT distinct(', ' +  US.InHAWBOBL) FROM OutItemDtl US  WHERE US.PermitId = t1.PermitId  FOR XML PATH('')), 1, 1, '') InHAWBOBL,CASE   WHEN  t1.OutwardTransportMode = '4 : Air' THEN t1.MasterAirwayBill     WHEN t1.OutwardTransportMode = '1 : Sea'  THEN t1.OceanBillofLadingNo    ELSE ''  END AS MAWBOBL, t1.DischargePort as POD, t1.MessageType, t1.OutwardTransportMode, t1.InternalRemarks,  SUM(t5.GSTSUMAmount) AS GSTSUMAmount,  (select Count(ItemNo) from OutItemDtl   where   OutItemDtl.PermitId=t1.PermitId) as SumOfItem, t1.Status    FROM  OutHeaderTbl AS t1 INNER JOIN   DeclarantCompany AS t2   ON t1.DeclarantCompanyCode = t2.Code   INNER JOIN OutExporter AS t3   ON t1.ExporterCompanyCode = t3.OutUserCode   INNER JOIN OutInvoiceDtl AS t5   ON t1.PermitId = t5.PermitId  INNER JOIN ManageUser AS t6 ON t6.UserId=t1.TouchUser  where t6.AccountId='" + Session["AccountId"].ToString() + "'  and t2.TradeNetMailboxID='"+ tradmail + "'   GROUP BY t1.Id, t1.JobId, t1.MSGId, t1.TouchTime, t1.TouchUser, t1.DeclarationType, t1.DepartureDate, t1.PermitId,t1.PermitNumber,t1.PreviousPermit, t1.OutwardTransportMode, t1.MasterAirwayBill, t1.OceanBillofLadingNo, t1.DischargePort, t1.MessageType, t1.InwardTransportMode, t1.PreviousPermit,t1.COType,t1.CerDetailtype1,t1.CurrencyCode, t1.InternalRemarks,t1.CertificateNumber, t1.Status, t2.TradeNetMailboxID, t3.OutUserName,t3.OutUserName1,t6.AccountId order by t1.Id Desc";

                // = "select t1.Id,t1.JobId,MSGId, convert(varchar, t1.TouchTime, 105) as DecDate,Substring(DeclarationType, 1,Charindex(':', DeclarationType)-1) as DeclarationType,t1.TouchUser as Createby,t2.TradeNetMailboxID as DecId, convert(varchar, ArrivalDate, 105) as ETA,t1.PermitId as PermitNo,t3.Name as OutImporter,t4.InHAWBOBL,CASE  WHEN  t1.InwardTransportMode = '4 : Air' THEN t1.MasterAirwayBill  WHEN t1.InwardTransportMode = '1 : Sea'  THEN t1.OceanBillofLadingNo  ELSE ''  END AS MAWBOBL,t1.LoadingPortCode,t1.MessageType,t1.InwardTransportMode,t1.PreviousPermit,t1.InternalRemarks,Substring(t5.TermType, 1,Charindex(':', t5.TermType)-1) as TermType ,t5.GSTSUMAmount,sum(t4.ItemNo) as SumOFItem,t1.Status from OutHeaderTbl t1 , DeclarantCompany t2 , OutImporter t3,ItemDtl t4,InvoiceDtl t5  where t1.DeclarantCompanyCode=t2.Code  and t1.ImporterCompanyCode=t3.Code  and t1.PermitId=t4.PermitId and t1.PermitId=t5.PermitId  GROUP BY t1.Id,t4.ItemNo,t1.JobId,t1.MSGId,t1.TouchTime,t1.TouchUser,t1.DeclarationType,t2.TradeNetMailboxID,t1.ArrivalDate,t1.PermitId,t3.Name,t4.InHAWBOBL,t1.InwardTransportMode ,t1.MasterAirwayBill,t1.OceanBillofLadingNo,t1.LoadingPortCode ,t1.MessageType,t1.InwardTransportMode,t1.PreviousPermit,t1.InternalRemarks,t5.TermType,t5.GSTSUMAmount,t1.Status";
                using (SqlCommand cmd = new SqlCommand(str))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridInPayment.DataSource = dt;
                            GridInPayment.DataBind();
                        }
                    }
                }
            }

            //   int gridViewCellCount = GridInPayment.Rows[0].Cells.Count;
            //warning

            //  string qurey = "";
            string Touch_user = Session["UserId"].ToString();
            // string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT FiledName,FiledValue FROM CustomiseReport Where ReportName='" + "OUT" + "' and UserName='" + Touch_user + "' and FiledValue='True'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                // qurey = "Select Id,";
                                List<string> str = new List<string>();
                                List<string> str1 = new List<string>();
                                //string[] str = new string[GridInPayment.Columns.Count];
                                foreach (DataRow sdr in dt.Rows)
                                {
                                    string trs = sdr["FiledName"].ToString();
                                    //foreach (DataControlField col in GridInPayment.Columns)
                                    //{
                                    if (sdr["FiledValue"].ToString() == "True")
                                    {


                                        for (int row_val = 0; row_val < GridInPayment.Columns.Count; row_val++)
                                        {
                                            try
                                            {

                                                if (GridInPayment.HeaderRow.Cells[row_val].Text == sdr["FiledName"].ToString())
                                                {
                                                    str.Add(row_val.ToString());
                                                }
                                                GridInPayment.Columns[row_val].Visible = false;
                                            }
                                            catch (Exception ex)
                                            {
                                                ex.ToString();
                                            }

                                        }

                                    }
                                    else
                                    {
                                        for (int row_val = 0; row_val < GridInPayment.Columns.Count; row_val++)
                                        {
                                            //if (GridInPayment.HeaderRow.Cells[row_val].Text == sdr["FiledName"].ToString())
                                            //{
                                            str1.Add(row_val.ToString());
                                            //}
                                            GridInPayment.Columns[row_val].Visible = false;

                                        }
                                    }
                                    GridInPayment.Columns[0].Visible = true;
                                    GridInPayment.Columns[1].Visible = true;
                                    GridInPayment.Columns[2].Visible = true;
                                    //  GridInPayment.Columns[23].Visible = true;
                                    if (str.Count > 0)
                                    {
                                        foreach (string newstr in str)
                                        {
                                            GridInPayment.Columns[Convert.ToInt16(newstr)].Visible = true;
                                        }
                                    }
                                    else
                                    {
                                        foreach (string newstr in str1)
                                        {
                                            GridInPayment.Columns[Convert.ToInt16(newstr)].Visible = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            changestatuscolor();
        }

        protected void load()
        {
            BindInpaymentGrid();
        }

        public DataTable seletctquery(string str)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return dt;
            }
            catch (Exception ex)
            {
                ex.ToString();
                con.Close();
                return null;
                //  ex.ToString();
            }
        }
        //Inpayment Grid
        private void BindInpaymentGrid()
        {
            string Touch_user = Session["UserId"].ToString();
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
                                CheckBoxList1.Items.Clear();
                                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                                {
                                    //You need to change this as per your DB Design

                                    //CheckBoxList1.Items.FindByText(myResults.Tables[0].Rows[i]["FK_ic_id"].ToString()).Selected = true;
                                    //Find the checkbox list items using FindByValue and select it.
                                    CheckBoxList1.Items.Add(ds.Tables[0].Rows[i]["FiledName"].ToString());
                                    if (ds.Tables[0].Rows[i]["FiledValue"].ToString() == "True")
                                    {
                                        CheckBoxList1.Items[i].Selected = true;
                                    }
                                    else
                                    {
                                        CheckBoxList1.Items[i].Selected = false;
                                    }
                                }
                            }

                            else
                            {

                                string str = "SELECT  top 10 t1.Id, t1.JobId, t1.MSGId,CONVERT(varchar, t1.TouchTime, 105) AS DecDate, \r\nSUBSTRING(t1.DeclarationType, 1,  CHARINDEX(':', t1.DeclarationType) - 1) AS DeclarationType, t1.TouchUser AS Createby,\r\nt2.TradeNetMailboxID AS DecId, CONVERT(varchar, t1.DepartureDate, 105) AS ETD, t1.PermitId AS LocalNo, t1.PermitNumber AS PermitNo, \r\nt1.PreviousPermit,t1.CertificateNumber as CertificateNo,t1.COType,t1.CerDetailtype1,t1.CurrencyCode, \r\nt3.OutUserName+' '+t3.OutUserName1 AS Exporter, STUFF((SELECT distinct(', ' +  US.InHAWBOBL) FROM OutItemDtl US \r\nWHERE US.PermitId = t1.PermitId  FOR XML PATH('')), 1, 1, '') InHAWBOBL,\r\nCASE   WHEN  t1.OutwardTransportMode = '4 : Air' THEN t1.MasterAirwayBill \r\nWHEN t1.OutwardTransportMode = '1 : Sea'  THEN t1.OceanBillofLadingNo  \r\nELSE ''  END AS MAWBOBL, t1.DischargePort as POD, t1.MessageType, t1.OutwardTransportMode, t1.InternalRemarks, \r\nSUM(t5.GSTSUMAmount) AS GSTSUMAmount,  (select Count(ItemNo) from OutItemDtl   where   OutItemDtl.PermitId=t1.PermitId) as SumOfItem,\r\nt1.Status    FROM  OutHeaderTbl AS t1 INNER JOIN   DeclarantCompany AS t2   ON t1.DeclarantCompanyCode = t2.Code   INNER JOIN OutExporter AS t3   ON t1.ExporterCompanyCode = t3.OutUserCode   INNER JOIN OutInvoiceDtl AS t5   ON t1.PermitId = t5.PermitId  INNER JOIN ManageUser AS t6 ON t6.UserId=t1.TouchUser    where t6.AccountId='" + Session["AccountId"].ToString() + "' and t2.TradeNetMailboxID='"+ tradmail + "'  GROUP BY t1.Id, t1.JobId, t1.MSGId, t1.TouchTime, t1.TouchUser, t1.DeclarationType, t1.DepartureDate, t1.PermitId,t1.PermitNumber,t1.PreviousPermit, t1.OutwardTransportMode, t1.MasterAirwayBill, t1.OceanBillofLadingNo, t1.DischargePort, t1.MessageType, t1.InwardTransportMode, t1.PreviousPermit,t1.COType,t1.CerDetailtype1,t1.CurrencyCode, t1.InternalRemarks,t1.CertificateNumber, t1.Status, t2.TradeNetMailboxID, t3.OutUserName,t3.OutUserName1,t6.AccountId order by t1.Id Desc";
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
                                        CheckBoxList1.Items.Clear();
                                        foreach (DataColumn dc in Gridds.Tables[0].Columns)
                                        {

                                            CheckBoxList1.Items.Add(dc.ToString());

                                        }

                                    }
                                }
                            }
                        }
                    }
                }
            }

            // colorchange();
            changestatuscolor();
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            BindInPayment();    
        }

        protected void GridInPayment_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           // string id = GridInPayment.DataKeys[e.RowIndex].Value.ToString();

           // string strDelete = "delete from OutHeaderTbl where Id='" + id + "' ";
           // obj.exec(strDelete);
           // obj.closecon();
           // BindInPayment();
           //// colorchange();
        }

        protected void GridInPayment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridInPayment.PageIndex = e.NewPageIndex;
            BindInPayment();
          //  colorchange();
        }

        protected void imgDelete_Click(object sender, EventArgs e)
        {
            LinkButton lnkbtn = sender as LinkButton;
            //getting particular row linkbutton
            GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
            //getting userid of particular row
            int employeeId = Convert.ToInt32(GridInPayment.DataKeys[gvrow.RowIndex].Value.ToString());
            int result;

            con.Open();
            SqlCommand cmd = new SqlCommand("update  OutHeaderTbl set  Status='DEL' where ID=" + employeeId, con);
            result = cmd.ExecuteNonQuery();
            con.Close();
            BindInPayment();
            changestatuscolor();
        }

        protected void InpaymentEdit_Click(object sender, ImageClickEventArgs e)
        {
            GridViewRow grdrow = (GridViewRow)((ImageButton)sender).NamingContainer as GridViewRow;

            Label ID1 = (Label)grdrow.FindControl("Id");
            string ID = ID1.Text;
            //string ID = "4";
            Response.Redirect("Out.aspx?ID=" + ID);
        }

        protected void txtJobId_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        protected void txtMSGId_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        protected void txtDecDate_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        protected void txtDeclarationType_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        protected void txtCreateby_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        protected void txtDecId_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        protected void txtETD_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        protected void txtPermitNo_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        protected void txtExporter_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        protected void txtInHAWBOBL_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        protected void txtMAWBOBL_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        protected void txtPOD_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        protected void txtMessageType_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        protected void txtOutwardTransportMode_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        protected void txtPreviousPermit_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        protected void txtInternalRemarks_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        protected void txtGSTSUMAmount_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        protected void txtSumOFItem_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        protected void txtStatus_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        protected void PrintCCP_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gvrow in GridInPayment.Rows)
            {
                var checkbox = gvrow.FindControl("CheckBox1") as CheckBox;
                if (checkbox.Checked)
                {
                    Label ID1 = (Label)gvrow.FindControl("Id");
                    string ID = ID1.Text;
                    MyClass lodobj = new MyClass();
                    string lodport = "select * from [OutHeaderTbl] where Id=" + ID + "";
                    lodobj.dr = lodobj.ret_dr(lodport);
                    if (lodobj.dr.HasRows)
                    {
                        while (lodobj.dr.Read())
                        {
                            PermID = lodobj.dr["PermitId"].ToString();
                        }
                    }
                    if (PermID != "")
                    {
                        //var PermitID = gvrow.FindControl("txtPermitNo") as TextBox;                    
                        LoadCCPPirnt(PermID);
                    }
                    else
                    {
                        LblErr.Text = "Please Check Approved Permit";
                    }
                  
                }
                else
                {
                    LblErr.Text = "Please Check Any Permit";
                }
            }
        }

        private void LoadCCPPirnt(string permit)
        {            
            string comNamedec = "", Decname = "", unicref = "", telphn = "", deccode = "";            
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from OutHeaderTbl  where PermitId='" + permit + "'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                    }
                }
            }

            int linecount = 0;
            //string path = Server.MapPath("PDF-Files");
            string path = @"C:\Users\Public\PDF-Files";
            string filename = path + "\\" + dt.Rows[0]["PermitNumber"].ToString() + "CCP.pdf";

            //Create new PDF document 

            PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create, FileAccess.ReadWrite));
            //Barcode genarate
            Response.ContentType = "application/pdf";
            PdfWriter writer = PdfWriter.GetInstance(
              document, Response.OutputStream
            );
            document.Open();
            pgheight = document.PageSize.Height;
            // FONT            
            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1257, false);
            iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 10, iTextSharp.text.Font.NORMAL);

            BaseFont bfTimes1 = BaseFont.CreateFont(BaseFont.COURIER_BOLD, BaseFont.CP1257, false);
            iTextSharp.text.Font timesBold = new iTextSharp.text.Font(bfTimes1, 10, iTextSharp.text.Font.NORMAL);

            //page 1 //
            document.Add(new Paragraph("\n"));
            string testerwd = "                                                                     ";
            iTextSharp.text.Paragraph c3r = new iTextSharp.text.Paragraph(testerwd, times);
            c3r.Alignment = Element.ALIGN_LEFT;
            document.Add(c3r);
            // iTextShirp
            //Bitmap barCode = new Bitmap(1, 1);
            string data = dt.Rows[0]["PermitNumber"].ToString();
            Barcode39 code128 = new Barcode39();
            // Barcode128 code128 = new Barcode128(); // barcode type
            code128.Code = data;
            code128.StartStopText = false;
            code128.Extended = false;
            code128.BarHeight = 36f;
            code128.Size = 12f;
            code128.N = 3.0f;
            code128.Baseline = 12f;
            code128.X = 1f;

            ////Image imageCode39 = code128.CreateImageWithBarcode(cb, null, null);
            ////imageCode39.SetAbsolutePosition(355f, 700f);
            ////cb.AddImage(imageCode39);

            System.Drawing.Image barCode = code128.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White);
            barCode.Save(path + "/barcode.gif", System.Drawing.Imaging.ImageFormat.Gif); //save file
            //return barCode;

            string imageURL = path + "/barcode.gif";
            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);
            //Resize image depend upon your need


            //jpg.ScaleToFit(250f,180f);
            //Give space before image
            //jpgjpg.Width = 100f;
            //jpg.SpacingBefore = 80f;
            ////Give some space after the image

            //jpg.SpacingAfter = 5f;

            jpg.IndentationLeft = 30;

            jpg.IndentationRight = 30;

            jpg.Alignment = Element.ALIGN_RIGHT;

            if (!string.IsNullOrWhiteSpace(data))
            {
                document.Add(jpg);
            }
            else
            {
                BlankSapce1(2);
            }


            //document.Add(lblImg.Text.ToString());

            //document.Add(new Paragraph("\n"));
            //document.Add(new Paragraph("\n"));
            //document.Add(new Paragraph("\n"));
            string perName = "PERMIT NO : ";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = perName.Length;
            spceval1 = 69 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }
            perName = space + perName;
            Chunk cce1 = new Chunk(perName, times);
            Phrase tte2 = new Phrase(cce1);
            string pernum = "";
            if (!string.IsNullOrWhiteSpace(dt.Rows[0]["PermitNumber"].ToString()))
            {
                pernum = dt.Rows[0]["PermitNumber"].ToString();
            }
            else
            {
                pernum = "DRAFT";
            }
            Chunk pt1 = new Chunk(pernum, timesBold);
            Phrase ptt1 = new Phrase(pt1);
            iTextSharp.text.Paragraph p1 = new iTextSharp.text.Paragraph();
            p1.Add(tte2);
            p1.Add(ptt1);
            //p1.Alignment = Element.ALIGN_LEFT;
            p1.SetLeading(0.0f, 1.0f);
            document.Add(p1);
            linecount = 6;
            //string permit1 = "                                                         PERMIT NO : IM9C105123Y";
            //Chunk t1 = new Chunk("CJ", timesBold);
            //Phrase tt1 = new Phrase(t1);
            //iTextSharp.text.Paragraph p1 = new iTextSharp.text.Paragraph(permit1, times);
            //p1.Alignment = Element.ALIGN_LEFT;
            //document.Add(p1);

            MyClass objdec = new MyClass();
            objdec.dr = objdec.ret_dr("select * from DeclarantCompany where TradeNetMailboxID='" + dt.Rows[0]["TradeNetMailboxID"].ToString() + "'");
            if (objdec.dr.HasRows)
            {
                while (objdec.dr.Read())
                {
                    comNamedec = objdec.dr["Name"].ToString();
                    Decname = objdec.dr["DeclarantName"].ToString();
                    unicref = objdec.dr["CRUEI"].ToString();
                    telphn = objdec.dr["DeclarantTel"].ToString();
                    deccode = objdec.dr["DeclarantCode"].ToString();
                }
            }

            string testerwblnk1 = "                                     ";
            iTextSharp.text.Paragraph blnk1 = new iTextSharp.text.Paragraph(testerwblnk1, times);
            blnk1.Alignment = Element.ALIGN_LEFT;
            blnk1.SetLeading(0.0f, 1.0f);
            document.Add(blnk1);
            linecount = linecount + 1;

            string testerwblnk2 = "                                     ";
            iTextSharp.text.Paragraph blnk2 = new iTextSharp.text.Paragraph(testerwblnk2, times);
            blnk2.Alignment = Element.ALIGN_LEFT;
            blnk2.SetLeading(0.0f, 1.0f);
            document.Add(blnk2);
            linecount = linecount + 1;

            string testerwblnk3 = "                                     ";
            iTextSharp.text.Paragraph blnk3 = new iTextSharp.text.Paragraph(testerwblnk3, times);
            blnk3.Alignment = Element.ALIGN_LEFT;
            blnk3.SetLeading(0.0f, 1.0f);
            document.Add(blnk3);
            linecount = linecount + 1;

            string testerwblnk4 = "                                     ";
            iTextSharp.text.Paragraph blnk4 = new iTextSharp.text.Paragraph(testerwblnk4, times);
            blnk4.Alignment = Element.ALIGN_LEFT;
            blnk4.SetLeading(0.0f, 1.0f);
            document.Add(blnk4);
            linecount = linecount + 1;

            //document.Add(new Paragraph("\n"));
            //document.Add(new Paragraph("\n"));
            //document.Add(new Paragraph("\n"));
            //document.Add(new Paragraph("\n"));

            string testerw = "                                     CARGO CLEARANCE PERMIT                   ";
            iTextSharp.text.Paragraph cr = new iTextSharp.text.Paragraph(testerw, times);
            cr.Alignment = Element.ALIGN_LEFT;
            cr.SetLeading(0.0f, 1.0f);
            document.Add(cr);
            linecount = linecount + 1;

            string testerwblnk5 = "                                     ";
            iTextSharp.text.Paragraph blnk5 = new iTextSharp.text.Paragraph(testerwblnk5, times);
            blnk5.Alignment = Element.ALIGN_LEFT;
            blnk5.SetLeading(0.0f, 1.0f);
            document.Add(blnk5);
            linecount = linecount + 1;

            string testerwblnk6 = "                                     ";
            iTextSharp.text.Paragraph blnk6 = new iTextSharp.text.Paragraph(testerwblnk6, times);
            blnk6.Alignment = Element.ALIGN_LEFT;
            blnk6.SetLeading(0.0f, 1.0f);
            document.Add(blnk6);
            linecount = linecount + 1;

            //document.Add(new Paragraph("\n"));
            //document.Add(new Paragraph("\n"));
            string msgtype = "";
            if (dt.Rows[0]["prmtStatus"].ToString() == "AMD")
            {
                msgtype = "MESSAGE TYPE      : OUT (WITH OR WITHOUT CERTIFICATE OF ORIGIN) UPDATED PERMIT";
            }
            else
            {
                msgtype = "MESSAGE TYPE      : OUT (WITH OR WITHOUT CERTIFICATE OF ORIGIN) PERMIT";
            }



            iTextSharp.text.Paragraph msgty = new iTextSharp.text.Paragraph(msgtype, times);
            msgty.Alignment = Element.ALIGN_LEFT;
            msgty.SetLeading(0.0f, 1.0f);
            document.Add(msgty);
            linecount = linecount + 1;

            string[] decltype = dt.Rows[0]["DeclarationType"].ToString().Split(':');
            string dectype = "DECLARATION TYPE  :" + decltype[1].ToString().ToUpper() + "";
            iTextSharp.text.Paragraph dectp = new iTextSharp.text.Paragraph(dectype, times);
            dectp.Alignment = Element.ALIGN_LEFT;
            dectp.SetLeading(0.0f, 1.0f);
            document.Add(dectp);
            linecount = linecount + 1;

            string testerwblnk7 = "                                     ";
            iTextSharp.text.Paragraph blnk7 = new iTextSharp.text.Paragraph(testerwblnk7, times);
            blnk7.Alignment = Element.ALIGN_LEFT;
            blnk7.SetLeading(0.0f, 1.0f);
            document.Add(blnk7);
            linecount = linecount + 1;

            string testerwblnk8 = "                                     ";
            iTextSharp.text.Paragraph blnk8 = new iTextSharp.text.Paragraph(testerwblnk8, times);
            blnk8.Alignment = Element.ALIGN_LEFT;
            blnk8.SetLeading(0.0f, 1.0f);
            document.Add(blnk8);
            linecount = linecount + 1;

            //document.Add(new Paragraph("\n"));
            //document.Add(new Paragraph("\n"));

            string Validate = "", Validate1 = "", cerfitno = "";
            string datechk = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4).ToString();
            //string[] str = dt.Rows[0]["MSGId"].ToString().Substring(0,dt.Rows[0]["MSGId"].ToString().Length-4).ToString();
            //var chkdt = DateTime.ParseExact(datechk, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //Validate = chkdt.ToString("dd/MM/yyyy");
            MyClass prmtdt = new MyClass();
            prmtdt.dr = prmtdt.ret_dr("select * from OutPMT where PermitNumber='" + dt.Rows[0]["PermitNumber"].ToString() + "'");
            if (prmtdt.dr.HasRows)
            {
                while (prmtdt.dr.Read())
                {
                    Validate = Convert.ToDateTime(prmtdt.dr["StartDate"].ToString()).ToString("dd/MM/yyyy");
                    Validate1 = Convert.ToDateTime(prmtdt.dr["EndDate"].ToString()).ToString("dd/MM/yyyy");
                    cerfitno = prmtdt.dr["CertificateNumber"].ToString();
                }
            }
            perName = "PERMIT NO : ";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = perName.Length;
            spceval1 = 69 - sapceval;
            for (int i = 0; i < 6; i++)
            {
                space = space + " ";
            }
            string validityfrom = Validate;
            string impname = "OutImporter:                            VALIDITY PERIOD" + space + ": " + validityfrom + " -             ";
            iTextSharp.text.Paragraph a1 = new iTextSharp.text.Paragraph(impname, times);
            a1.Alignment = Element.ALIGN_LEFT;
            a1.SetLeading(0.0f, 1.0f);
            document.Add(a1);
            linecount = linecount + 1;
            string imptrname = "", impname1 = "", impceui = "";
            string impget = "Select * from OutImporter where Code='" + dt.Rows[0]["ImporterCompanyCode"].ToString() + "'";
            obj.dr = obj.ret_dr(impget);
            if (obj.dr.HasRows)
            {
                while (obj.dr.Read())
                {
                    imptrname = obj.dr["Name"].ToString();
                    impname1 = obj.dr["Name1"].ToString();
                    impceui = obj.dr["CRUEI"].ToString();
                }
            }
            if (string.IsNullOrWhiteSpace(impname1))
            {
                impname1 = "";
            }

            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 60 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }




            string validityto = Validate1;
            Validate1 = validityto;
            //  Validate1 = DateTime.Now.AddDays(10).ToString("dd/MM/yyyy");
            string impnam1 = "" + imptrname + "" + space + "" + Validate1 + "               ";
            iTextSharp.text.Paragraph a2 = new iTextSharp.text.Paragraph(impnam1.ToUpper(), times);
            a2.Alignment = Element.ALIGN_LEFT;
            a2.SetLeading(0.0f, 1.0f);
            document.Add(a2);
            linecount = linecount + 1;

            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = impname1.Length;
            spceval1 = 37 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = impname1.Length;
            spceval1 = 37 - sapceval;
            for (int i = 0; i < 6; i++)
            {
                space1 = space1 + " ";
            }
            if (dt.Rows[0]["prmtStatus"].ToString() == "AMD")
            {
                int chkval = 0;
                MyClass amddate = new MyClass();
                amddate.dr = amddate.ret_dr("select * from amndtbl where PermitNum='" + dt.Rows[0]["PermitNumber"].ToString() + "'");
                if (amddate.dr.HasRows)
                {
                    while (amddate.dr.Read())
                    {
                        if (chkval == 0)
                        {

                            string NAME1 = "" + impname1 + "" + space + "" + "AMENDMENT DATE" + space1 + " : " + Convert.ToDateTime(amddate.dr["AmdDate"].ToString()).ToString("dd/MM/yyyy");
                            iTextSharp.text.Paragraph RQ = new iTextSharp.text.Paragraph(NAME1.ToUpper(), times);
                            RQ.Alignment = Element.ALIGN_LEFT;
                            RQ.SetLeading(0.0f, 1.0f);
                            document.Add(RQ);
                            chkval = chkval + 1;
                        }

                    }
                }
            }
            else
            {
                string NAME1 = "" + impname1 + "" + space + " ";
                iTextSharp.text.Paragraph RQ = new iTextSharp.text.Paragraph(NAME1.ToUpper(), times);
                RQ.Alignment = Element.ALIGN_LEFT;
                RQ.SetLeading(0.0f, 1.0f);
                document.Add(RQ);
            }

            //string impnam2 = "" + impname1 + "                                             ";
            //iTextSharp.text.Paragraph a3 = new iTextSharp.text.Paragraph(impnam2, times);
            //a3.Alignment = Element.ALIGN_LEFT;
            //document.Add(a3);

            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = impceui.Length;
            spceval1 = 37 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }



            decimal TtlPGW = 0;
            if (dt.Rows[0]["TotalGrossWeightUOM"].ToString() == "KGM")
            {
                TtlPGW = Convert.ToDecimal(dt.Rows[0]["TotalGrossWeight"].ToString());
            }
            else
            {
                TtlPGW = Convert.ToDecimal(dt.Rows[0]["TotalGrossWeight"].ToString()) / Convert.ToDecimal(1000);
            }


            string strtest2 = Math.Round(Convert.ToDecimal(TtlPGW), 3).ToString("0.000");


            sapceval = 0; spceval1 = 0;
            sapceval = strtest2.Length;
            spceval1 = 15 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }


            string impnam3 = "" + impceui + "" + space + "TOTAL GROSS WT/UNIT  :  " + space1 + "" + strtest2 + "/" + dt.Rows[0]["TotalGrossWeightUOM"].ToString() + "";
            iTextSharp.text.Paragraph a4 = new iTextSharp.text.Paragraph(impnam3, times);
            a4.Alignment = Element.ALIGN_LEFT;
            a4.SetLeading(0.0f, 1.0f);
            document.Add(a4);
            linecount = linecount + 1;

            string exptr = "EXPORTER:";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = exptr.Length;
            spceval1 = 37 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }
            sapceval = 0; spceval1 = 0;
            sapceval = dt.Rows[0]["TotalOuterPack"].ToString().Length;
            spceval1 = 15 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }

            string impnam4 = "EXPORTER:" + space + "TOTAL OUTER PACK/UNIT:  " + space1 + "" + dt.Rows[0]["TotalOuterPack"].ToString() + "/" + dt.Rows[0]["TotalOuterPackUOM"].ToString() + "       ";
            iTextSharp.text.Paragraph a5 = new iTextSharp.text.Paragraph(impnam4, times);
            a5.Alignment = Element.ALIGN_LEFT;
            a5.SetLeading(0.0f, 1.0f);
            document.Add(a5);
            linecount = linecount + 1;



            string Exptrname = "", Expname1 = "", Expceui = "";
            string Exppget = "Select * from OutExporter where OutUserCode='" + dt.Rows[0]["ExporterCompanyCode"].ToString() + "'";
            obj.dr = obj.ret_dr(Exppget);
            if (obj.dr.HasRows)
            {
                while (obj.dr.Read())
                {
                    Exptrname = obj.dr["OutUserName"].ToString().ToUpper();
                    Expname1 = obj.dr["OutUserName1"].ToString().ToUpper();
                    Expceui = obj.dr["OutUserCRUEI"].ToString().ToUpper();
                }
            }

            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = Exptrname.Length;
            spceval1 = 37 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }
            sapceval = dt.Rows[0]["TotalExDutyAmt"].ToString().Length;
            spceval1 = 16 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }
            string impnam5 = "" + Exptrname + "" + space + "TOT EXCISE DUT PAYABLE : S$" + space1 + "" + dt.Rows[0]["TotalExDutyAmt"].ToString() + "";
            iTextSharp.text.Paragraph a6 = new iTextSharp.text.Paragraph(impnam5, times);
            a6.Alignment = Element.ALIGN_LEFT;
            a6.SetLeading(0.0f, 1.0f);
            document.Add(a6);
            linecount = linecount + 1;

            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = Expname1.Length;
            spceval1 = 37 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }
            sapceval = 0; spceval1 = 0;
            sapceval = dt.Rows[0]["TotalCusDutyAmt"].ToString().Length;
            spceval1 = 16 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }
            string impnam6 = "" + Expname1 + "" + space + "TOT CUSTOMS DUT PAYABLE: S$" + space1 + "" + dt.Rows[0]["TotalCusDutyAmt"].ToString() + "";
            iTextSharp.text.Paragraph a7 = new iTextSharp.text.Paragraph(impnam6, times);
            a7.Alignment = Element.ALIGN_LEFT;
            a7.SetLeading(0.0f, 1.0f);
            document.Add(a7);
            linecount = linecount + 1;

            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = Expceui.Length;
            spceval1 = 37 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }
            sapceval = 0; spceval1 = 0;
            sapceval = dt.Rows[0]["TotalODutyAmt"].ToString().Length;
            spceval1 = 16 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }
            string impnam7 = "" + Expceui + "" + space + "TOT OTHER TAX PAYABLE  : S$" + space1 + "" + dt.Rows[0]["TotalODutyAmt"].ToString() + "";
            iTextSharp.text.Paragraph a8 = new iTextSharp.text.Paragraph(impnam7, times);
            a8.Alignment = Element.ALIGN_LEFT;
            a8.SetLeading(0.0f, 1.0f);
            document.Add(a8);
            linecount = linecount + 1;

            handl = "HANDLING AGENT:";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = handl.Length;
            spceval1 = 37 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }
            sapceval = 0; spceval1 = 0;
            sapceval = dt.Rows[0]["TotalGSTTaxAmt"].ToString().Length;
            spceval1 = 16 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }
            string impnam8 = "HANDLING AGENT:" + space + "TOTAL GST AMT          : S$" + space1 + "" + dt.Rows[0]["TotalGSTTaxAmt"].ToString() + "";
            iTextSharp.text.Paragraph a9 = new iTextSharp.text.Paragraph(impnam8, times);
            a9.Alignment = Element.ALIGN_LEFT;
            a9.SetLeading(0.0f, 1.0f);
            document.Add(a9);
            linecount = linecount + 1;

            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = handl.Length;
            spceval1 = 37 - sapceval;
            for (int i = 0; i < 37; i++)
            {
                space = space + " ";
            }
            sapceval = 0; spceval1 = 0;
            sapceval = dt.Rows[0]["TotalAmtPay"].ToString().Length;
            spceval1 = 16 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }
            string impnam9 = "" + space + "TOTAL AMOUNT PAYABLE   : S$" + space1 + "" + dt.Rows[0]["TotalAmtPay"].ToString() + "";
            iTextSharp.text.Paragraph b1 = new iTextSharp.text.Paragraph(impnam9, times);
            b1.Alignment = Element.ALIGN_LEFT;
            b1.SetLeading(0.0f, 1.0f);
            document.Add(b1);
            linecount = linecount + 1;

            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = handl.Length;
            spceval1 = 37 - sapceval;
            for (int i = 0; i < 37; i++)
            {
                space = space + " ";
            }
            string[] cartype = dt.Rows[0]["CargoPackType"].ToString().Split(':');
            sapceval = 0; spceval1 = 0;
            sapceval = cartype[1].ToString().Substring(1).ToUpper().Length;
            spceval1 = 23 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }


            string impna10 = "" + space + "CARGO PACKING TYPE: " + cartype[1].ToString().Substring(1).ToUpper() + "";
            iTextSharp.text.Paragraph b2 = new iTextSharp.text.Paragraph(impna10, times);
            b2.Alignment = Element.ALIGN_LEFT;
            b2.SetLeading(0.0f, 1.0f);
            document.Add(b2);
            linecount = linecount + 1;

            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = handl.Length;
            spceval1 = 37 - sapceval;
            for (int i = 0; i < 37; i++)
            {
                space = space + " ";
            }
            string impna11 = "" + space + "IN TRANSPORT IDENTIFIER:                    ";
            iTextSharp.text.Paragraph b3 = new iTextSharp.text.Paragraph(impna11, times);
            b3.Alignment = Element.ALIGN_LEFT;
            b3.SetLeading(0.0f, 1.0f);
            document.Add(b3);
            linecount = linecount + 1;

            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = handl.Length;
            spceval1 = 37 - sapceval;
            for (int i = 0; i < 37; i++)
            {
                space = space + " ";
            }
            cartype = dt.Rows[0]["VesselName"].ToString().Split(':');
            sapceval = 0; spceval1 = 0;
            sapceval = dt.Rows[0]["VesselName"].ToString().Length;
            spceval1 = 23 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }

            string transidval = "";
            if (dt.Rows[0]["InwardTransportMode"].ToString() == "4 : Air")
            {
                transidval = dt.Rows[0]["AircraftRegNo"].ToString().ToUpper();
            }
            else if (dt.Rows[0]["InwardTransportMode"].ToString() == "1 : Sea")
            {
                transidval = dt.Rows[0]["VesselName"].ToString().ToUpper();
            }
            else
            {
                transidval = dt.Rows[0]["TransportId"].ToString().ToUpper();
            }
            string impna12 = "" + space + "" + transidval + "";
            iTextSharp.text.Paragraph b4 = new iTextSharp.text.Paragraph(impna12, times);
            b4.Alignment = Element.ALIGN_LEFT;
            b4.SetLeading(0.0f, 1.0f);
            document.Add(b4);
            linecount = linecount + 1;

            string conveno = "", mastebill = "";
            if (dt.Rows[0]["InwardTransportMode"].ToString() == "4 : Air")
            {
                conveno = dt.Rows[0]["FlightNO"].ToString().ToUpper();
                mastebill = dt.Rows[0]["MasterAirwayBill"].ToString().ToUpper();
            }
            else if (dt.Rows[0]["InwardTransportMode"].ToString() == "1 : Sea")
            {
                conveno = dt.Rows[0]["VoyageNumber"].ToString().ToUpper();
                mastebill = dt.Rows[0]["OceanBillofLadingNo"].ToString().ToUpper();
            }
            else
            {
                conveno = dt.Rows[0]["ConveyanceRefNo"].ToString().ToUpper();
                mastebill = dt.Rows[0]["TransportId"].ToString().ToUpper();
            }

            handl = "PORT OF LOADING/NEXT PORT OF CALL:";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = handl.Length;
            spceval1 = 37 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }
            cartype = dt.Rows[0]["VesselName"].ToString().Split(':');
            sapceval = 0; spceval1 = 0;
            sapceval = conveno.Length;
            spceval1 = 23 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }

            string impna13 = "PORT OF LOADING/NEXT PORT OF CALL:" + space + "CONVEYANCE REFERENCE NO: " + conveno.ToUpper() + "";
            iTextSharp.text.Paragraph b5 = new iTextSharp.text.Paragraph(impna13, times);
            b5.Alignment = Element.ALIGN_LEFT;
            b5.SetLeading(0.0f, 1.0f);
            document.Add(b5);
            linecount = linecount + 1;

            string lodportName = "", lodportName1 = "", lodportName2="";
            MyClass lodobj = new MyClass();
            string lodport = "Select * from LoadingPort where PortCode='" + dt.Rows[0]["LoadingPortCode"].ToString() + "'";
            lodobj.dr = lodobj.ret_dr(lodport);
            if (lodobj.dr.HasRows)
            {
                while (lodobj.dr.Read())
                {
                    lodportName = lodobj.dr["PortName"].ToString().ToUpper();
                }
            }

            lodobj = new MyClass();
            lodport = "Select * from LoadingPort where PortCode='" + dt.Rows[0]["NextPort"].ToString() + "'";
            lodobj.dr = lodobj.ret_dr(lodport);
            if (lodobj.dr.HasRows)
            {
                while (lodobj.dr.Read())
                {
                    lodportName1 = lodobj.dr["PortName"].ToString().ToUpper();
                }
            }
            if (!string.IsNullOrWhiteSpace(lodportName))
            {
                lodportName2=lodportName+"/";
            }

            if (!string.IsNullOrWhiteSpace(lodportName1))
            {
                lodportName2 = lodportName2 + lodportName1;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(lodportName2))
                {
                    lodportName2 = lodportName2.Substring(0, lodportName2.Length - 1);
                }
            }
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = lodportName2.Length;
            spceval1 = 37 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }
            string impna14 = "" + lodportName2 + "" + space + "OBL/MAWB NO:                               ";
            iTextSharp.text.Paragraph b6 = new iTextSharp.text.Paragraph(impna14, times);
            b6.Alignment = Element.ALIGN_LEFT;
            b6.SetLeading(0.0f, 1.0f);
            document.Add(b6);
            linecount = linecount + 1;


            handl = "PORT OF DISCHARGE/FINAL PORT OF CALL:";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = handl.Length;
            spceval1 = 37 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }
            cartype = dt.Rows[0]["VesselName"].ToString().Split(':');
            sapceval = 0; spceval1 = 0;
            sapceval = mastebill.Length;
            spceval1 = 23 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }
            string impna15 = "PORT OF DISCHARGE/FINAL PORT OF CALL " + space + "" + mastebill.ToUpper() + "";
            iTextSharp.text.Paragraph b7 = new iTextSharp.text.Paragraph(impna15, times);
            b7.Alignment = Element.ALIGN_LEFT;
            b7.SetLeading(0.0f, 1.0f);
            document.Add(b7);
            linecount = linecount + 1;

            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = handl.Length;
            spceval1 = 21 - sapceval;
            for (int i = 0; i < 36; i++)
            {
                space = space + " ";
            }


            string Portdischarge = "", finalcharge = "", finalcharge1="";
            MyClass Portobj = new MyClass();
            string loddisport = "Select * from LoadingPort where PortCode='" + dt.Rows[0]["DischargePort"].ToString() + "'";
            Portobj.dr = Portobj.ret_dr(loddisport);
            if (Portobj.dr.HasRows)
            {
                while (Portobj.dr.Read())
                {
                    Portdischarge = Portobj.dr["PortName"].ToString().ToUpper();
                }
            }
            Portobj = new MyClass();
            loddisport = "Select * from LoadingPort where PortCode='" + dt.Rows[0]["LastPort"].ToString() + "'";
            Portobj.dr = Portobj.ret_dr(loddisport);
            if (Portobj.dr.HasRows)
            {
                while (Portobj.dr.Read())
                {
                    finalcharge = Portobj.dr["PortName"].ToString().ToUpper();
                }
            }
            if (!string.IsNullOrWhiteSpace(Portdischarge))
            {
                finalcharge1 = Portdischarge + "/";
            }
            if (!string.IsNullOrWhiteSpace(finalcharge))
            {
                finalcharge1 = finalcharge1 + finalcharge;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(finalcharge1))
                {
                    finalcharge1 = finalcharge1.Substring(0, finalcharge1.Length - 1);
                }
            }
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = finalcharge1.Length;
            spceval1 = 36 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }
            string Adate = "";
            if (dt.Rows[0]["DeclarationType"].ToString() == "DRT : DIRECT (INCLUDING STORAGE IN FTZ)")
            {
                if (dt.Rows[0]["InwardTransportMode"].ToString() != "--Select--")
                {
                    if (dt.Rows[0]["InwardTransportMode"].ToString() != "N : Not Required")
                    {
                        Adate = Convert.ToDateTime(dt.Rows[0]["ArrivalDate"].ToString()).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        Adate = "";
                    }
                }
            }

            string impna16 = "" + finalcharge1 + " " + space + "ARRIVAL DATE         : " + Adate;
            iTextSharp.text.Paragraph b8 = new iTextSharp.text.Paragraph(impna16, times);
            b8.Alignment = Element.ALIGN_LEFT;
            b8.SetLeading(0.0f, 1.0f);
            document.Add(b8);
            linecount = linecount + 1;

            handl = "COUNTRY OF FINAL DESTINATION:";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = handl.Length;
            spceval1 = 37 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }
            cartype = dt.Rows[0]["VesselName"].ToString().Split(':');
            sapceval = 0; spceval1 = 0;
            sapceval = dt.Rows[0]["ConveyanceRefNo"].ToString().Length;
            spceval1 = 23 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }
            string impna17 = "COUNTRY OF FINAL DESTINATION:" + space + "OU TRANSPORT IDENTIFIER:";
            iTextSharp.text.Paragraph b9 = new iTextSharp.text.Paragraph(impna17, times);
            b9.Alignment = Element.ALIGN_LEFT;
            b9.SetLeading(0.0f, 1.0f);
            document.Add(b9);
            linecount = linecount + 1;

            string FianlDis = "";
            if (dt.Rows[0]["FinalDestinationCountry"].ToString() != "--Select--")
            {
                string[] ss = dt.Rows[0]["FinalDestinationCountry"].ToString().Split(':');

                string finaldischarge = ss[1].ToString();
                FianlDis = finaldischarge.Substring(1);
            }
            //MyClass obj = new MyClass();
            //string finaldisport = "Select * from LoadingPort where PortCode='" + dt.Rows[0]["DischargePort"].ToString() + "'";
            //obj.dr = obj.ret_dr(finaldisport);
            //if (obj.dr.HasRows)
            //{
            //    while (obj.dr.Read())
            //    {
            //        Portdischarge = obj.dr["PortName"].ToString();
            //    }
            //}

            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = FianlDis.Length;
            spceval1 = 37 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }
            transidval = "";
            if (dt.Rows[0]["OutwardTransportMode"].ToString() == "4 : Air")
            {
                transidval = dt.Rows[0]["OutAircraftRegNo"].ToString().ToUpper();
            }
            else if (dt.Rows[0]["OutwardTransportMode"].ToString() == "1 : Sea")
            {
                transidval = dt.Rows[0]["OutVesselName"].ToString().ToUpper();
            }
            else
            {
                transidval = dt.Rows[0]["OutTransportId"].ToString().ToUpper();
            }
            string impna18 = "" + FianlDis + "" + space + "" + transidval + "   ";
            //string impna18 = "" + FianlDis + "" + space + "" + dt.Rows[0]["OutVesselName"].ToString().ToUpper() + "   ";
            iTextSharp.text.Paragraph c1 = new iTextSharp.text.Paragraph(impna18, times);
            c1.Alignment = Element.ALIGN_LEFT;
            c1.SetLeading(0.0f, 1.0f);
            document.Add(c1);
            linecount = linecount + 1;

            conveno = ""; mastebill = "";
            if (dt.Rows[0]["OutwardTransportMode"].ToString() == "4 : Air")
            {
                conveno = dt.Rows[0]["OutFlightNO"].ToString().ToUpper();
                mastebill = dt.Rows[0]["OutMasterAirwayBill"].ToString().ToUpper();
            }
            else if (dt.Rows[0]["OutwardTransportMode"].ToString() == "1 : Sea")
            {
                conveno = dt.Rows[0]["OutVoyageNumber"].ToString().ToUpper();
                mastebill = dt.Rows[0]["OutOceanBillofLadingNo"].ToString().ToUpper();
            }
            else
            {
                conveno = dt.Rows[0]["OutConveyanceRefNo"].ToString().ToUpper();
                mastebill = dt.Rows[0]["OutTransportId"].ToString().ToUpper();
            }
            handl = "INWARD CARRIER AGENT:";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = handl.Length;
            spceval1 = 37 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }
            cartype = dt.Rows[0]["VesselName"].ToString().Split(':');
            sapceval = 0; spceval1 = 0;
            sapceval = conveno.Length;
            spceval1 = 23 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }
            string voyageno = dt.Rows[0]["OutVoyageNumber"].ToString();
            string impna19 = "INWARD CARRIER AGENT:" + space + "CONVEYANCE REFERENCE NO: " + conveno.ToUpper() + "";
            iTextSharp.text.Paragraph c2 = new iTextSharp.text.Paragraph(impna19, times);
            c2.Alignment = Element.ALIGN_LEFT;
            c2.SetLeading(0.0f, 1.0f);
            document.Add(c2);
            linecount = linecount + 1;

            string inwName = "", inwName1 = "", inwUEI = "";
            MyClass inwobj = new MyClass();
            string inwqury = "Select * from InwardCarrierAgent where Code='" + dt.Rows[0]["InwardCarrierAgentCode"].ToString() + "'";
            inwobj.dr = inwobj.ret_dr(inwqury);
            if (inwobj.dr.HasRows)
            {
                while (inwobj.dr.Read())
                {
                    int partLength = 35;
                    string sentence = inwobj.dr["Name"].ToString() + " " + inwobj.dr["Name1"].ToString();
                    sentence = sentence.Replace("\n", " ");
                    List<string> lines =
                        sentence
                            .Split(' ')
                            .Aggregate(new[] { "" }.ToList(), (a, x) =>
                            {
                                var last = a[a.Count - 1];
                                if ((last + " " + x).Length > partLength)
                                {
                                    a.Add(x);
                                }
                                else
                                {
                                    a[a.Count - 1] = (last + " " + x).Trim();
                                }
                                return a;
                            });
                    if (lines.Count == 1)
                    {
                        inwName = lines[lines.Count - 1].ToString();
                        inwName1 = "";
                        inwUEI = " ";
                    }
                    else if (lines.Count == 2)
                    {
                        inwName = lines[0].ToString();
                        inwName1 = lines[1].ToString();
                        inwUEI = " ";
                    }
                    else if (lines.Count == 3)
                    {
                        inwName = lines[0].ToString();
                        inwName1 = lines[1].ToString();
                        inwUEI = " ";
                    }
                    //inwName = inwobj.dr["Name"].ToString().ToUpper();
                    //inwName1 = inwobj.dr["Name1"].ToString().ToUpper();
                    //inwUEI = inwobj.dr["CRUEI"].ToString();
                }
            }
            if (string.IsNullOrWhiteSpace(inwName1))
            {
                inwName1 = " ";
            }
            handl = "INWARD CARRIER AGENT:";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = inwName.Length;
            spceval1 = 37 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }
            cartype = dt.Rows[0]["VesselName"].ToString().Split(':');
            sapceval = 0; spceval1 = 0;
            sapceval = mastebill.Length;
            spceval1 = 23 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }
            string impna20 = "" + inwName + "" + space + "OBL/MAWB/UCR NO:                          ";
            iTextSharp.text.Paragraph c3 = new iTextSharp.text.Paragraph(impna20.ToUpper(), times);
            c3.Alignment = Element.ALIGN_LEFT;
            c3.SetLeading(0.0f, 1.0f);
            document.Add(c3);
            linecount = linecount + 1;

            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = inwName1.Length;
            spceval1 = 37 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }
            string impna21 = "" + inwName1 + "" + space + "" + mastebill.ToUpper() + "";

            iTextSharp.text.Paragraph c4 = new iTextSharp.text.Paragraph(impna21, times);
            c4.Alignment = Element.ALIGN_LEFT;
            c4.SetLeading(0.0f, 1.0f);
            document.Add(c4);
            linecount = linecount + 1;

            handl = "INWARD CARRIER AGENT:";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = inwUEI.Length;
            spceval1 = 37 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }
            cartype = dt.Rows[0]["VesselName"].ToString().Split(':');
            sapceval = 0; spceval1 = 0;
            sapceval = dt.Rows[0]["ConveyanceRefNo"].ToString().Length;
            spceval1 = 23 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }
            string ddate = "";
            string datedep = dt.Rows[0]["DepartureDate"].ToString();
            if (dt.Rows[0]["DepartureDate"].ToString() != "01/01/1900 00:00:00")
            {
                ddate = Convert.ToDateTime(dt.Rows[0]["DepartureDate"].ToString()).ToString("dd/MM/yyyy");
            }
            string impna22 = "" + inwUEI + "" + space + "DEPARTURE DATE       : " + ddate + "";
            iTextSharp.text.Paragraph c5 = new iTextSharp.text.Paragraph(impna22, times);
            c5.Alignment = Element.ALIGN_LEFT;
            c5.SetLeading(0.0f, 1.0f);
            document.Add(c5);
            linecount = linecount + 1;

            //string impna23 = "OUTWARD CARRIER AGENT:                                                      ";
            //iTextSharp.text.Paragraph c6 = new iTextSharp.text.Paragraph(impna23, times);
            //c6.Alignment = Element.ALIGN_LEFT;
            //c6.SetLeading(0.0f, 1.0f);
            //document.Add(c6);

            handl = "INWARD CARRIER AGENT:";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = handl.Length;
            spceval1 = 15 - sapceval;
            for (int i = 0; i < 15; i++)
            {
                space = space + " ";
            }
            cartype = dt.Rows[0]["VesselName"].ToString().Split(':');
            sapceval = 0; spceval1 = 0;
            sapceval = dt.Rows[0]["ConveyanceRefNo"].ToString().Length;
            spceval1 = 23 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }
            //BlankSapce(1);
            string impna24 = "OUTWARD CARRIER AGENT:" + space + "";
            iTextSharp.text.Paragraph c7 = new iTextSharp.text.Paragraph(impna24, times);
            c7.Alignment = Element.ALIGN_LEFT;
            c7.SetLeading(0.0f, 1.0f);
            document.Add(c7);
            linecount = linecount + 1;

            string OutName = "", outname1 = " ", OutECUI = " ";
            MyClass Outobj = new MyClass();
            string Outqury = "Select * from OutwardCarrierAgent where Code='" + dt.Rows[0]["OutwardCarrierAgentCode"].ToString() + "'";
            Outobj.dr = Outobj.ret_dr(Outqury);
            if (Outobj.dr.HasRows)
            {
                while (Outobj.dr.Read())
                {
                    int partLength = 35;
                    string sentence = Outobj.dr["Name"].ToString() + " " + Outobj.dr["Name1"].ToString();
                    sentence = sentence.Replace("\n", " ");
                    List<string> lines =
                        sentence
                            .Split(' ')
                            .Aggregate(new[] { "" }.ToList(), (a, x) =>
                            {
                                var last = a[a.Count - 1];
                                if ((last + " " + x).Length > partLength)
                                {
                                    a.Add(x);
                                }
                                else
                                {
                                    a[a.Count - 1] = (last + " " + x).Trim();
                                }
                                return a;
                            });
                    if (lines.Count == 1)
                    {
                        OutName = lines[lines.Count - 1].ToString();
                        outname1 = "";
                        OutECUI = " ";
                    }
                    else if (lines.Count == 2)
                    {
                        OutName = lines[0].ToString();
                        outname1 = lines[1].ToString();
                        OutECUI = " ";
                    }
                    else if (lines.Count == 3)
                    {
                        OutName = lines[0].ToString();
                        outname1 = lines[1].ToString();
                        OutECUI = " ";
                    }
                    //OutName = Outobj.dr["Name"].ToString().ToUpper();
                    //outname1 = Outobj.dr["Name1"].ToString().ToUpper();
                    //OutECUI = Outobj.dr["CRUEI"].ToString();
                }
            }

            if (string.IsNullOrWhiteSpace(outname1))
            {
                outname1 = " ";
            }
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = OutName.Length;
            spceval1 = 37 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            string impna25 = "" + OutName + "" + space + "CERTIFICATE NO: " + cerfitno.ToUpper() + "";
            iTextSharp.text.Paragraph c8 = new iTextSharp.text.Paragraph(impna25, times);
            c8.Alignment = Element.ALIGN_LEFT;
            c8.SetLeading(0.0f, 1.0f);
            document.Add(c8);
            linecount = linecount + 1;

            string impna26 = "" + outname1 + "";
            iTextSharp.text.Paragraph c9 = new iTextSharp.text.Paragraph(impna26, times);
            c9.Alignment = Element.ALIGN_LEFT;
            c9.SetLeading(0.0f, 1.0f);
            document.Add(c9);
            linecount = linecount + 1;

            string impna26p = "" + OutECUI + "";
            iTextSharp.text.Paragraph c9p = new iTextSharp.text.Paragraph(impna26p, times);
            c9p.Alignment = Element.ALIGN_LEFT;
            c9p.SetLeading(0.0f, 1.0f);
            document.Add(c9p);
            linecount = linecount + 1;

            handl = "PLACE OF RELEASE:";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = handl.Length;
            spceval1 = 37 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }
            cartype = dt.Rows[0]["VesselName"].ToString().Split(':');
            sapceval = 0; spceval1 = 0;
            sapceval = dt.Rows[0]["ConveyanceRefNo"].ToString().Length;
            spceval1 = 23 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }
            string impna27 = "PLACE OF RELEASE:" + space + "PLACE OF RECEIPT:                         ";
            iTextSharp.text.Paragraph d1 = new iTextSharp.text.Paragraph(impna27, times);
            d1.Alignment = Element.ALIGN_LEFT;
            d1.SetLeading(0.0f, 1.0f);
            document.Add(d1);
            linecount = linecount + 1;

            string rectName = "";
            rectName = dt.Rows[0]["RepLocName"].ToString();
            if (string.IsNullOrWhiteSpace(rectName))
            {
                string receploc = "Select * from ReceiptLocation where Code='" + dt.Rows[0]["RecepitLocation"].ToString() + "'";
                obj.dr = obj.ret_dr(receploc);
                if (obj.dr.HasRows)
                {
                    while (obj.dr.Read())
                    {
                        rectName = obj.dr["Description"].ToString();
                    }
                }
            }
            

            string relseName = "";
            relseName = dt.Rows[0]["ResLoaName"].ToString();
            if (string.IsNullOrWhiteSpace(relseName))
            {
                string relseloc = "Select * from ReleaseLocation where Code='" + dt.Rows[0]["ReleaseLocation"].ToString() + "'";
                obj.dr = obj.ret_dr(relseloc);
                if (obj.dr.HasRows)
                {
                    while (obj.dr.Read())
                    {
                        relseName = obj.dr["Description"].ToString().ToUpper();
                    }
                }
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["ReleaseLocation"].ToString()))
                {
                    if (string.IsNullOrWhiteSpace(relseName))
                    {
                        relseName = dt.Rows[0]["ReleaseLocation"].ToString().ToUpper();
                    }
                }
            }
            int partLength11 = 32;
            string sentence11 = rectName;
            List<string> Recplines =
                sentence11
                    .Split(' ')
                    .Aggregate(new[] { "" }.ToList(), (a, x) =>
                    {
                        var last = a[a.Count - 1];
                        if ((last + " " + x).Length > partLength11)
                        {
                            a.Add(x);
                        }
                        else
                        {
                            a[a.Count - 1] = (last + " " + x).Trim();
                        }
                        return a;
                    });
            int partLength1 = 32;
            string sentence1 = relseName;
            List<string> Relslines =
                sentence1
                    .Split(' ')
                    .Aggregate(new[] { "" }.ToList(), (a, x) =>
                    {
                        var last = a[a.Count - 1];
                        if ((last + " " + x).Length > partLength1)
                        {
                            a.Add(x);
                        }
                        else
                        {
                            a[a.Count - 1] = (last + " " + x).Trim();
                        }
                        return a;
                    });
            int relscount = 0;
            int lne1 = 0;
            if (Relslines.Count < Recplines.Count)
            {
                for (relscount = 0; relscount < Recplines.Count; relscount++)
                {
                    string relsename = "";
                    if (relscount < Relslines.Count)
                    {
                        relsename = Relslines[relscount].ToString();
                    }
                    handl = "PLACE OF RELEASE:";
                    space = ""; space1 = "";
                    sapceval = 0; spceval1 = 0;
                    sapceval = relsename.Length;
                    spceval1 = 37 - sapceval;
                    for (int i = 0; i < spceval1; i++)
                    {
                        space = space + " ";
                    }
                    string impna28 = "" + relsename + "" + space + "" + Recplines[relscount].ToString().ToUpper() + "";
                    iTextSharp.text.Paragraph d2 = new iTextSharp.text.Paragraph(impna28, times);
                    d2.Alignment = Element.ALIGN_LEFT;
                    d2.SetLeading(0.0f, 1.0f);
                    document.Add(d2);
                    linecount = linecount + 1;
                    lne1 = lne1 + 1;
                }
            }
            else
            {
                for (relscount = 0; relscount < Relslines.Count; relscount++)
                {
                    string relsen = "";
                    if (relscount < Recplines.Count)
                    {
                        relsen = Recplines[relscount].ToString();
                    }
                    handl = "PLACE OF RELEASE:";
                    space = ""; space1 = "";
                    sapceval = 0; spceval1 = 0;
                    sapceval = Relslines[relscount].ToString().Length;
                    spceval1 = 37 - sapceval;
                    for (int i = 0; i < spceval1; i++)
                    {
                        space = space + " ";
                    }
                    string impna28 = "" + Relslines[relscount].ToString() + "" + space + "" + relsen.ToUpper() + "";
                    iTextSharp.text.Paragraph d2 = new iTextSharp.text.Paragraph(impna28, times);
                    d2.Alignment = Element.ALIGN_LEFT;
                    d2.SetLeading(0.0f, 1.0f);
                    document.Add(d2);
                    linecount = linecount + 1;
                    lne1 = lne1 + 1;
                }
            }

            handl = "PLACE OF RELEASE:";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = dt.Rows[0]["ReleaseLocation"].ToString().Length;
            spceval1 = 37 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }
            string impna29 = "" + dt.Rows[0]["ReleaseLocation"].ToString().ToUpper() + "" + space + "" + dt.Rows[0]["RecepitLocation"].ToString().ToUpper() + "";
            iTextSharp.text.Paragraph d3 = new iTextSharp.text.Paragraph(impna29, times);
            d3.Alignment = Element.ALIGN_LEFT;
            d3.SetLeading(0.0f, 1.0f);
            document.Add(d3);
            linecount = linecount + 1;

            //for (int rno = lne1; rno <= 9; rno++)
            //{
            //    BlankSapce(1);
            //}

            handl = "LICENCE NO:";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = handl.Length;
            spceval1 = 37 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }
            cartype = dt.Rows[0]["VesselName"].ToString().Split(':');
            sapceval = 0; spceval1 = 0;
            sapceval = dt.Rows[0]["ConveyanceRefNo"].ToString().Length;
            spceval1 = 23 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }
            string impna37 = "LICENCE NO:" + space + "CUSTOMS PROCEDURE CODE (CPC) :            ";
            iTextSharp.text.Paragraph e2 = new iTextSharp.text.Paragraph(impna37, times);
            e2.Alignment = Element.ALIGN_LEFT;
            e2.SetLeading(0.0f, 1.0f);
            document.Add(e2);
            linecount = linecount + 1;



            string aeoName = "", cwcName = "", cnbName = "", seastor = "", sts = "", stscwc = "", deferrd = "";
            string cpcQury = "Select * from OutCPCDtl where PermitId='" + dt.Rows[0]["PermitId"].ToString() + "'";
            obj.dr = obj.ret_dr(cpcQury);
            if (obj.dr.HasRows)
            {
                while (obj.dr.Read())
                {
                    if (obj.dr["CPCType"].ToString() == "AEO")
                    {
                        aeoName = obj.dr["CPCType"].ToString();
                    }
                    else if (obj.dr["CPCType"].ToString() == "CWC")
                    {
                        cwcName = obj.dr["CPCType"].ToString();
                    }
                    else if (obj.dr["CPCType"].ToString() == "SEASTORE")
                    {
                        seastor = obj.dr["CPCType"].ToString();
                    }
                    else if (obj.dr["CPCType"].ToString() == "SEA STORE")
                    {
                        seastor = obj.dr["CPCType"].ToString();
                    }
                    else if (obj.dr["CPCType"].ToString() == "STS")
                    {
                        sts = obj.dr["CPCType"].ToString();
                    }
                    else if (obj.dr["CPCType"].ToString() == "STS and CWC")
                    {
                        stscwc = obj.dr["CPCType"].ToString();
                    }
                    else if (obj.dr["CPCType"].ToString() == "CNB")
                    {
                        cnbName = obj.dr["CPCType"].ToString();
                    }
                    else if (obj.dr["CPCType"].ToString() == "Deferred Printing for CO")
                    {
                        deferrd = obj.dr["CPCType"].ToString();
                    }
                }
            }
            string LicNo1 = "", LicNo2 = "", LicNo3 = "", LicNo4 = "", LicNo5 = "";
            string[] LicVal = dt.Rows[0]["License"].ToString().Split('-');
            for (int li = 0; li < LicVal.Length; li++)
            {
                if (li == 0)
                {
                    LicNo1 = LicVal[li].ToString();
                }
                else if (li == 1)
                {
                    LicNo2 = LicVal[li].ToString();
                }
                else if (li == 2)
                {
                    LicNo3 = LicVal[li].ToString();
                }
                else if (li == 3)
                {
                    LicNo4 = LicVal[li].ToString();
                }
                else if (li == 4)
                {
                    LicNo5 = LicVal[li].ToString();
                }
            }
            handl = "LICENCE NO:";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = LicNo1.Length;
            spceval1 = 37 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }
            cartype = dt.Rows[0]["VesselName"].ToString().Split(':');
            sapceval = 0; spceval1 = 0;
            sapceval = dt.Rows[0]["ConveyanceRefNo"].ToString().Length;
            spceval1 = 23 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }
            string cpcval = "";
            if (!string.IsNullOrWhiteSpace(aeoName))
            {
                cpcval = aeoName;
                aeoName = "";
            }
            else if (!string.IsNullOrWhiteSpace(cwcName))
            {
                cpcval = cwcName;
                cwcName = "";
            }
            else if (!string.IsNullOrWhiteSpace(cnbName))
            {
                cpcval = cnbName;
                cnbName = "";
            }
            else if (!string.IsNullOrWhiteSpace(seastor))
            {
                cpcval = seastor;
                seastor = "";
            }
            else if (!string.IsNullOrWhiteSpace(sts))
            {
                cpcval = sts;
                sts = "";
            }
            else if (!string.IsNullOrWhiteSpace(stscwc))
            {
                cpcval = stscwc;
                stscwc = "";
            }
            else if (!string.IsNullOrWhiteSpace(deferrd))
            {
                cpcval = deferrd;
                deferrd = "";
            }
            string impna38 = "" + LicNo1 + "" + space + "" + cpcval.ToUpper() + "";
            iTextSharp.text.Paragraph e3 = new iTextSharp.text.Paragraph(impna38, times);
            e3.Alignment = Element.ALIGN_LEFT;
            e3.SetLeading(0.0f, 1.0f);
            document.Add(e3);
            linecount = linecount + 1;

            handl = "LICENCE NO:";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = LicNo2.Length;
            spceval1 = 37 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }
            cartype = dt.Rows[0]["VesselName"].ToString().Split(':');
            sapceval = 0; spceval1 = 0;
            sapceval = dt.Rows[0]["ConveyanceRefNo"].ToString().Length;
            spceval1 = 23 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }
            cpcval = "";
            if (!string.IsNullOrWhiteSpace(aeoName))
            {
                cpcval = aeoName;
                aeoName = "";
            }
            else if (!string.IsNullOrWhiteSpace(cwcName))
            {
                cpcval = cwcName;
                cwcName = "";
            }
            else if (!string.IsNullOrWhiteSpace(cnbName))
            {
                cpcval = cnbName;
                cnbName = "";
            }
            else if (!string.IsNullOrWhiteSpace(seastor))
            {
                cpcval = seastor;
                seastor = "";
            }
            else if (!string.IsNullOrWhiteSpace(sts))
            {
                cpcval = sts;
                sts = "";
            }
            else if (!string.IsNullOrWhiteSpace(stscwc))
            {
                cpcval = stscwc;
                stscwc = "";
            }
            else if (!string.IsNullOrWhiteSpace(deferrd))
            {
                cpcval = deferrd;
                deferrd = "";
            }
            string impna39 = "" + LicNo2 + "" + space + "" + cpcval.ToUpper() + "";
            iTextSharp.text.Paragraph e4 = new iTextSharp.text.Paragraph(impna39, times);
            e4.Alignment = Element.ALIGN_LEFT;
            e4.SetLeading(0.0f, 1.0f);
            document.Add(e4);
            linecount = linecount + 1;

            handl = "LICENCE NO:";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = LicNo3.Length;
            spceval1 = 37 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }
            cartype = dt.Rows[0]["VesselName"].ToString().Split(':');
            sapceval = 0; spceval1 = 0;
            sapceval = dt.Rows[0]["ConveyanceRefNo"].ToString().Length;
            spceval1 = 23 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }
            cpcval = "";
            if (!string.IsNullOrWhiteSpace(aeoName))
            {
                cpcval = aeoName;
                aeoName = "";
            }
            else if (!string.IsNullOrWhiteSpace(cwcName))
            {
                cpcval = cwcName;
                cwcName = "";
            }
            else if (!string.IsNullOrWhiteSpace(cnbName))
            {
                cpcval = cnbName;
                cnbName = "";
            }
            else if (!string.IsNullOrWhiteSpace(seastor))
            {
                cpcval = seastor;
                seastor = "";
            }
            else if (!string.IsNullOrWhiteSpace(sts))
            {
                cpcval = sts;
                sts = "";
            }
            else if (!string.IsNullOrWhiteSpace(stscwc))
            {
                cpcval = stscwc;
                stscwc = "";
            }
            else if (!string.IsNullOrWhiteSpace(deferrd))
            {
                cpcval = deferrd;
                deferrd = "";
            }
            string impna40 = "" + LicNo3 + "" + space + "" + cpcval.ToUpper() + "";
            iTextSharp.text.Paragraph e5 = new iTextSharp.text.Paragraph(impna40, times);
            e5.Alignment = Element.ALIGN_LEFT;
            e5.SetLeading(0.0f, 1.0f);
            document.Add(e5);
            linecount = linecount + 1;

            handl = "LICENCE NO:";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = LicNo4.Length;
            spceval1 = 37 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }
            cartype = dt.Rows[0]["VesselName"].ToString().Split(':');
            sapceval = 0; spceval1 = 0;
            sapceval = dt.Rows[0]["ConveyanceRefNo"].ToString().Length;
            spceval1 = 23 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }
            cpcval = "";
            if (!string.IsNullOrWhiteSpace(aeoName))
            {
                cpcval = aeoName;
                aeoName = "";
            }
            else if (!string.IsNullOrWhiteSpace(cwcName))
            {
                cpcval = cwcName;
                cwcName = "";
            }
            else if (!string.IsNullOrWhiteSpace(cnbName))
            {
                cpcval = cnbName;
                cnbName = "";
            }
            else if (!string.IsNullOrWhiteSpace(seastor))
            {
                cpcval = seastor;
                seastor = "";
            }
            else if (!string.IsNullOrWhiteSpace(sts))
            {
                cpcval = sts;
                sts = "";
            }
            else if (!string.IsNullOrWhiteSpace(stscwc))
            {
                cpcval = stscwc;
                stscwc = "";
            }
            else if (!string.IsNullOrWhiteSpace(deferrd))
            {
                cpcval = deferrd;
                deferrd = "";
            }
            string impna41 = "" + LicNo4 + "" + space + "" + cpcval.ToUpper();
            iTextSharp.text.Paragraph e6 = new iTextSharp.text.Paragraph(impna41, times);
            e6.Alignment = Element.ALIGN_LEFT;
            e6.SetLeading(0.0f, 1.0f);
            document.Add(e6);
            linecount = linecount + 1;

            handl = "LICENCE NO:";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = LicNo5.Length;
            spceval1 = 37 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }
            cartype = dt.Rows[0]["VesselName"].ToString().Split(':');
            sapceval = 0; spceval1 = 0;
            sapceval = dt.Rows[0]["ConveyanceRefNo"].ToString().Length;
            spceval1 = 23 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }
            cpcval = "";
            if (!string.IsNullOrWhiteSpace(aeoName))
            {
                cpcval = aeoName;
                aeoName = "";
            }
            else if (!string.IsNullOrWhiteSpace(cwcName))
            {
                cpcval = cwcName;
                cwcName = "";
            }
            else if (!string.IsNullOrWhiteSpace(cnbName))
            {
                cpcval = cnbName;
                cnbName = "";
            }
            else if (!string.IsNullOrWhiteSpace(seastor))
            {
                cpcval = seastor;
                seastor = "";
            }
            else if (!string.IsNullOrWhiteSpace(sts))
            {
                cpcval = sts;
                sts = "";
            }
            else if (!string.IsNullOrWhiteSpace(stscwc))
            {
                cpcval = stscwc;
                stscwc = "";
            }
            else if (!string.IsNullOrWhiteSpace(deferrd))
            {
                cpcval = deferrd;
                deferrd = "";
            }
            string impna30 = "" + LicNo5 + "" + space + "" + cpcval.ToUpper();
            iTextSharp.text.Paragraph d4 = new iTextSharp.text.Paragraph(impna30, times);
            d4.Alignment = Element.ALIGN_LEFT;
            d4.SetLeading(0.0f, 1.0f);
            document.Add(d4);
            linecount = linecount + 1;
            lineheight = 540;
            for (int i = linecount; i <= 75; i++)
            {
                if (pgheight - 92 > lineheight)
                {
                    string impna31 = "          ";
                    iTextSharp.text.Paragraph d5 = new iTextSharp.text.Paragraph(impna31, times);
                    d5.Alignment = Element.ALIGN_LEFT;
                    d5.SetLeading(0.0f, 1.0f);
                    document.Add(d5);
                    linecount = linecount + 1;
                    lineheight = lineheight + 10;
                }
            }

            string linecode = "";
            for (int i = 1; i <= 80; i++)
            {
                linecode = linecode + "-";
            }

            iTextSharp.text.Paragraph Line = new iTextSharp.text.Paragraph(linecode, times);
            string msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
            string impna43 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "                              ";
            Line.Alignment = Element.ALIGN_LEFT;
            Line.SetLeading(0.0f, 1.0f);
            //document.Add(Line);

            //document.Add(new Paragraph("\n"));

            iTextSharp.text.Paragraph l3 = new iTextSharp.text.Paragraph(impna43, times);
            l3.Alignment = Element.ALIGN_LEFT;
            l3.SetLeading(0.0f, 1.0f);
            //document.Add(l3);
            //BlankSapce(1);
            //if (linecount == 60)
            //{

            //}
            document.NewPage();
            BlankSapce1(1);
            lineheight = 0;
            Linecount = 0;
            chkline = 0;
            string itemQury = "Select * from OutItemDtl where PermitId='" + dt.Rows[0]["PermitId"].ToString() + "' order by ItemNo";
            obj.dr = obj.ret_dr(itemQury);
            if (obj.dr.HasRows)
            {
                while (obj.dr.Read())
                {
                    strInHAWBOBL = obj.dr["OutHAWBOBL"].ToString();
                    if (pgheight - 92 > lineheight)
                    {
                        if (Linecount == 0)
                        {
                            ItemHeaderprint();
                        }
                        string sno = "";
                        if (obj.dr["ItemNo"].ToString().Length == 1)
                        {
                            sno = "0" + obj.dr["ItemNo"].ToString();
                        }
                        else
                        {
                            sno = obj.dr["ItemNo"].ToString();
                        }
                        string currenlot = "   " + sno + "  " + obj.dr["HSCode"].ToString() + "   " + obj.dr["CurrentLot"].ToString();
                        space = ""; space1 = "";
                        sapceval = 0; spceval1 = 0;
                        sapceval = currenlot.Length;
                        spceval1 = 50 - sapceval;
                        for (int i = 0; i < spceval1; i++)
                        {
                            space = space + " ";
                        }
                        if (pgheight - 92 > lineheight)
                        {
                            string page022 = "   " + sno + "  " + obj.dr["HSCode"].ToString() + "   " + obj.dr["CurrentLot"].ToString() + "" + space + "" + obj.dr["PreviousLot"].ToString();
                            iTextSharp.text.Paragraph h3 = new iTextSharp.text.Paragraph(page022, times);
                            h3.Alignment = Element.ALIGN_LEFT;
                            h3.SetLeading(0.0f, 1.0f);
                            document.Add(h3);
                            Linecount = Linecount + 1;
                            lineheight = lineheight + 10;
                        }
                        else
                        {
                            //document.Add(Line);
                            Linecount = Linecount + 1;
                            lineheight = lineheight + 10;

                            msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                            string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                            iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                            l3p.Alignment = Element.ALIGN_LEFT;
                            l3p.SetLeading(0.0f, 1.0f);
                            //document.Add(l3p);
                            BlankSapce1(3);
                            //document.NewPage();
                            Linecount = 0;
                            lineheight = 0;
                            ItemHeaderprint();

                            string page022 = "   " + sno + "  " + obj.dr["HSCode"].ToString() + "   " + obj.dr["CurrentLot"].ToString() + "";
                            iTextSharp.text.Paragraph h3 = new iTextSharp.text.Paragraph(page022, times);
                            h3.Alignment = Element.ALIGN_LEFT;
                            h3.SetLeading(0.0f, 1.0f);
                            document.Add(h3);
                            Linecount = Linecount + 1;
                            lineheight = lineheight + 10;
                        }

                        string Marking = "";
                        if (obj.dr["Making"].ToString() != "--Select--")
                        {
                            string[] macode = obj.dr["Making"].ToString().Split(':');
                            Marking = macode[0].Substring(0, macode[0].Length - 1);
                        }
                        if (string.IsNullOrWhiteSpace(Marking))
                        {
                            Marking = "  ";
                        }
                        string teststr = "" + Marking.ToUpper() + "  " + obj.dr["Contry"].ToString().ToUpper() + "   " + obj.dr["Brand"].ToString().ToUpper() + " ";
                        space = ""; space1 = "";
                        sapceval = 0; spceval1 = 0;
                        sapceval = teststr.Length;
                        spceval1 = 44 - sapceval;
                        for (int i = 0; i < spceval1; i++)
                        {
                            space = space + " ";
                        }
                        if (pgheight - 92 > lineheight)
                        {
                            string page023 = "" + Marking.ToUpper() + "  " + obj.dr["Contry"].ToString().ToUpper() + "   " + obj.dr["Brand"].ToString().ToUpper() + " " + space + " " + obj.dr["Model"].ToString().ToUpper() + "";
                            iTextSharp.text.Paragraph h4 = new iTextSharp.text.Paragraph(page023, times);
                            h4.Alignment = Element.ALIGN_LEFT;
                            h4.SetLeading(0.0f, 1.0f);
                            document.Add(h4);
                            Linecount = Linecount + 1;
                            lineheight = lineheight + 10;
                        }
                        else
                        {
                            //document.Add(Line);
                            Linecount = Linecount + 1;
                            lineheight = lineheight + 10;

                            msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                            string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                            iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                            l3p.Alignment = Element.ALIGN_LEFT;
                            l3p.SetLeading(0.0f, 1.0f);
                            //document.Add(l3p);
                            BlankSapce1(3);
                            //document.NewPage();
                            Linecount = 0;
                            lineheight = 0;
                            ItemHeaderprint();

                            string page023 = "" + Marking.ToUpper() + "  " + obj.dr["Contry"].ToString().ToUpper() + "   " + obj.dr["Brand"].ToString().ToUpper() + " " + space + " " + obj.dr["Model"].ToString().ToUpper() + "";
                            iTextSharp.text.Paragraph h4 = new iTextSharp.text.Paragraph(page023, times);
                            h4.Alignment = Element.ALIGN_LEFT;
                            h4.SetLeading(0.0f, 1.0f);
                            document.Add(h4);
                            Linecount = Linecount + 1;
                            lineheight = lineheight + 10;
                        }

                        handl = "LICENCE NO:";
                        space = ""; space1 = "";
                        sapceval = 0; spceval1 = 0;
                        //sapceval = obj.dr["InMAWBOBL"].ToString().Length;
                        spceval1 = 45 - sapceval;
                        for (int i = 0; i < spceval1; i++)
                        {
                            space = space + " ";
                        }
                        //string page024 = "       ";
                        //iTextSharp.text.Paragraph h5 = new iTextSharp.text.Paragraph(page024, times);
                        //h5.Alignment = Element.ALIGN_LEFT;
                        //h5.SetLeading(0.0f, 1.0f);
                        //document.Add(h5);
                        //Linecount = Linecount + 1;

                        if (!string.IsNullOrWhiteSpace(obj.dr["OutHAWBOBL"].ToString()))
                        {
                            handl = "LICENCE NO:";
                            space = ""; space1 = "";
                            sapceval = 0; spceval1 = 0;
                            sapceval = obj.dr["InHAWBOBL"].ToString().Length;
                            spceval1 = 45 - sapceval;
                            for (int i = 0; i < spceval1; i++)
                            {
                                space = space + " ";
                            }
                            if (pgheight - 92 > lineheight)
                            {
                                string page024p = "" + obj.dr["InHAWBOBL"].ToString().ToUpper() + "" + space + "" + obj.dr["OutHAWBOBL"].ToString().ToUpper() + "";
                                iTextSharp.text.Paragraph h5p = new iTextSharp.text.Paragraph(page024p, times);
                                h5p.Alignment = Element.ALIGN_LEFT;
                                h5p.SetLeading(0.0f, 1.0f);
                                document.Add(h5p);
                                Linecount = Linecount + 1;
                                lineheight = lineheight + 10;
                            }
                            else
                            {
                                //document.Add(Line);
                                Linecount = Linecount + 1;
                                lineheight = lineheight + 10;

                                msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                                string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                                iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                                l3p.Alignment = Element.ALIGN_LEFT;
                                l3p.SetLeading(0.0f, 1.0f);
                                //document.Add(l3p);
                                BlankSapce1(3);
                                //document.NewPage();
                                Linecount = 0;
                                lineheight = 0;
                                ItemHeaderprint();

                                string page024p = "" + obj.dr["InHAWBOBL"].ToString().ToUpper() + "" + space + "" + obj.dr["OutHAWBOBL"].ToString().ToUpper() + "";
                                iTextSharp.text.Paragraph h5p = new iTextSharp.text.Paragraph(page024p, times);
                                h5p.Alignment = Element.ALIGN_LEFT;
                                h5p.SetLeading(0.0f, 1.0f);
                                document.Add(h5p);
                                Linecount = Linecount + 1;
                                lineheight = lineheight + 10;
                            }
                        }

                        string opqty = "", inpqty = "";
                        string opqtyval = "";
                        if (obj.dr["OPUOM"].ToString() != "--Select--")
                        {
                            handl = obj.dr["OPQty"].ToString();
                            space = ""; space1 = "";
                            sapceval = 0; spceval1 = 0;
                            double val = Convert.ToDouble(obj.dr["OPQty"].ToString());
                            sapceval = val.ToString().Length;
                            spceval1 = 8 - sapceval;
                            for (int i = 0; i < spceval1; i++)
                            {
                                space = space + " ";
                            }
                            opqtyval = space + Math.Round(Convert.ToDecimal(obj.dr["OPQty"].ToString()),0) + " " + obj.dr["OPUOM"].ToString() + " ";
                            //strtest = "1";
                        }
                        if (obj.dr["IPUOM"].ToString() != "--Select--")
                        {
                            handl = obj.dr["IPQty"].ToString();
                            space = ""; space1 = "";
                            sapceval = 0; spceval1 = 0;
                            double val = Convert.ToDouble(obj.dr["IPQty"].ToString());
                            sapceval = val.ToString().Length;
                            spceval1 = 8 - sapceval;
                            for (int i = 0; i < spceval1; i++)
                            {
                                space = space + " ";
                            }
                            opqtyval = opqtyval + space + Math.Round(Convert.ToDecimal(obj.dr["IPQty"].ToString()),0) + " " + obj.dr["IPUOM"].ToString() + " ";
                            //strtest = "2";
                        }
                        if (obj.dr["InPUOM"].ToString() != "--Select--")
                        {
                            handl = obj.dr["InPqty"].ToString();
                            space = ""; space1 = "";
                            sapceval = 0; spceval1 = 0;
                            double val = Convert.ToDouble(obj.dr["InPqty"].ToString());
                            sapceval = val.ToString().Length;
                            spceval1 = 8 - sapceval;
                            for (int i = 0; i < spceval1; i++)
                            {
                                space = space + " ";
                            }
                            inpqty = space + Math.Round(Convert.ToDecimal(obj.dr["InPqty"].ToString()),0) + " " + obj.dr["InPUOM"].ToString() + " ";
                            //strtest = "3";
                        }
                        if (obj.dr["ImPUOM"].ToString() != "--Select--")
                        {
                            handl = obj.dr["ImPQty"].ToString();
                            space = ""; space1 = "";
                            sapceval = 0; spceval1 = 0;
                            double val = Convert.ToDouble(obj.dr["ImPQty"].ToString());
                            sapceval = val.ToString().Length;
                            spceval1 = 8 - sapceval;
                            for (int i = 0; i < spceval1; i++)
                            {
                                space = space + " ";
                            }
                            inpqty = inpqty + space + Math.Round(Convert.ToDecimal(obj.dr["ImPQty"].ToString()),0) + " " + obj.dr["ImPUOM"].ToString() + "";
                            //strtest = "4";
                        }

                       int partLength12 = 50;
                       string sentence12 = obj.dr["Description"].ToString();
                        List<string> lines =
                            sentence12
                                .Split(' ')
                                .Aggregate(new[] { "" }.ToList(), (a, x) =>
                                {
                                    var last = a[a.Count - 1];
                                    if ((last + " " + x).Length > partLength12)
                                    {
                                        a.Add(x);
                                    }
                                    else
                                    {
                                        a[a.Count - 1] = (last + " " + x).Trim();
                                    }
                                    return a;
                                });

                        int rcunt = 0;
                        teststr = "";
                        if (!string.IsNullOrWhiteSpace(opqtyval))
                        {
                            opqty = opqtyval;
                            opqtyval = "";
                        }
                        else if (!string.IsNullOrWhiteSpace(inpqty))
                        {
                            opqty = inpqty;
                            inpqty = "";
                        }
                        if (!string.IsNullOrWhiteSpace(opqty))
                        {
                            teststr = opqty;
                            opqty = "";
                        }
                        else
                        {
                            if (rcunt <= lines.Count - 1)
                            {
                                teststr = lines[rcunt].ToString().ToUpper();
                                rcunt = rcunt + 1;
                            }
                        }
                        string hsval = "", hsval1="";
                        string chkval = "";
                            string itemQury1 = "Select Count(*) from ChkHsCode where HSCode='" + obj.dr["HSCode"].ToString() + "'";
                            MyClass objchk = new MyClass();
                            objchk.dr = objchk.ret_dr(itemQury1);
                            if (objchk.dr.HasRows)
                            {
                                while (objchk.dr.Read())
                                {
                                    chkval = objchk.dr[0].ToString();
                                }
                            }
                            if (chkval == "1")
                            {

                                hsval = Math.Round(Convert.ToDecimal(obj.dr["TotalDutiableQty"].ToString()), 4).ToString("0.0000");
                                hsval1 = hsval;
                                hsval = hsval + " " + obj.dr["TotalDutiableUOM"].ToString();
                            }
                            else
                            {
                                hsval = Math.Round(Convert.ToDecimal(obj.dr["HSQty"].ToString()), 4).ToString("0.0000");
                                hsval1 = hsval;
                                hsval = hsval + " " + obj.dr["HSUOM"].ToString().ToUpper();
                            }                         
                        handl = "LICENCE NO:";
                        space = ""; space1 = "";
                        sapceval = 0; spceval1 = 0;
                        sapceval = teststr.ToUpper().Length;
                        spceval1 = 50 - sapceval;
                        for (int i = 0; i < spceval1; i++)
                        {
                            space = space + " ";
                        }
                        cartype = dt.Rows[0]["VesselName"].ToString().Split(':');
                        sapceval = 0; spceval1 = 0;
                        sapceval = hsval1.Length;
                        spceval1 = 25 - sapceval;
                        for (int i = 0; i < spceval1; i++)
                        {
                            space1 = space1 + " ";
                        }

                        if (pgheight - 92 > lineheight)
                        {
                            string page025 = "" + teststr.ToUpper() + "" + space + "" + space1 + "" + hsval + "    ";
                            iTextSharp.text.Paragraph h6 = new iTextSharp.text.Paragraph(page025, times);
                            h6.Alignment = Element.ALIGN_LEFT;
                            h6.SetLeading(0.0f, 1.0f);
                            document.Add(h6);
                            Linecount = Linecount + 1;
                            lineheight = lineheight + 10;
                        }
                        else
                        {
                            //document.Add(Line);
                            Linecount = Linecount + 1;
                            lineheight = lineheight + 10;

                            msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                            string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                            iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                            l3p.Alignment = Element.ALIGN_LEFT;
                            l3p.SetLeading(0.0f, 1.0f);
                            //document.Add(l3p);
                            BlankSapce1(3);
                            //document.NewPage();
                            Linecount = 0;
                            lineheight = 0;
                            ItemHeaderprint();

                            string page025 = "" + teststr.ToUpper() + "" + space + "" + space1 + "" + hsval + "    ";
                            iTextSharp.text.Paragraph h6 = new iTextSharp.text.Paragraph(page025, times);
                            h6.Alignment = Element.ALIGN_LEFT;
                            h6.SetLeading(0.0f, 1.0f);
                            document.Add(h6);
                            Linecount = Linecount + 1;
                            lineheight = lineheight + 10;
                        }

                        teststr = "";
                        if (!string.IsNullOrWhiteSpace(opqtyval))
                        {
                            opqty = opqtyval;
                            opqtyval = "";
                        }
                        else if (!string.IsNullOrWhiteSpace(inpqty))
                        {
                            opqty = inpqty;
                            inpqty = "";
                        }

                        if (!string.IsNullOrWhiteSpace(opqty))
                        {
                            teststr = opqty;
                            opqty = "";
                        }
                        else
                        {
                            if (rcunt <= lines.Count - 1)
                            {
                                teststr = lines[rcunt].ToString().ToUpper();
                                rcunt = rcunt + 1;
                            }
                        }
                        handl = "LICENCE NO:";
                        space = ""; space1 = "";
                        sapceval = 0; spceval1 = 0;
                        sapceval = teststr.Length;
                        spceval1 = 50 - sapceval;
                        for (int i = 0; i < spceval1; i++)
                        {
                            space = space + " ";
                        }
                        cartype = dt.Rows[0]["VesselName"].ToString().Split(':');
                        sapceval = 0; spceval1 = 0;
                        sapceval = obj.dr["CIFFOB"].ToString().Length;
                        spceval1 = 25 - sapceval;
                        for (int i = 0; i < spceval1; i++)
                        {
                            space1 = space1 + " ";
                        }
                        if (pgheight - 92 > lineheight)
                        {
                            string page026 = "" + teststr + "" + space + "" + space1 + "" + obj.dr["CIFFOB"].ToString() + "    ";
                            iTextSharp.text.Paragraph h7 = new iTextSharp.text.Paragraph(page026, times);
                            h7.Alignment = Element.ALIGN_LEFT;
                            h7.SetLeading(0.0f, 1.0f);
                            document.Add(h7);
                            Linecount = Linecount + 1;
                            lineheight = lineheight + 10;
                        }
                        else
                        {
                            //document.Add(Line);
                            Linecount = Linecount + 1;
                            lineheight = lineheight + 10;

                            msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                            string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                            iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                            l3p.Alignment = Element.ALIGN_LEFT;
                            l3p.SetLeading(0.0f, 1.0f);
                            //document.Add(l3p);
                            BlankSapce1(3);
                            //document.NewPage();
                            Linecount = 0;
                            lineheight = 0;
                            ItemHeaderprint();

                            string page026 = "" + teststr + "" + space + "" + space1 + "" + obj.dr["CIFFOB"].ToString() + "    ";
                            iTextSharp.text.Paragraph h7 = new iTextSharp.text.Paragraph(page026, times);
                            h7.Alignment = Element.ALIGN_LEFT;
                            h7.SetLeading(0.0f, 1.0f);
                            document.Add(h7);
                            Linecount = Linecount + 1;
                            lineheight = lineheight + 10;
                        }

                        //teststr = opqty;
                        //if (teststr.Length > 50)
                        //{
                        //    teststr = opqty.Substring(0, 50);
                        //    opqty = opqty.Remove(0, 50);
                        //}
                        //else
                        //{
                        //    teststr = opqty;
                        //    opqty = opqty.Remove(0, teststr.Length);
                        //}
                        //handl = "LICENCE NO:";
                        //space = ""; space1 = "";
                        //sapceval = 0; spceval1 = 0;
                        //sapceval = teststr.Length;
                        //spceval1 = 50 - sapceval;
                        //for (int i = 0; i < spceval1; i++)
                        //{
                        //    space = space + " ";
                        //}
                        //cartype = dt.Rows[0]["VesselName"].ToString().Split(':');
                        //sapceval = 0; spceval1 = 0;
                        //sapceval = obj.dr["GSTAmount"].ToString().Length;
                        //spceval1 = 25 - sapceval;
                        //for (int i = 0; i < spceval1; i++)
                        //{
                        //    space1 = space1 + " ";
                        //}
                        //string page027 = "" + teststr + "" + space + "" + space1 + "" + obj.dr["GSTAmount"].ToString() + "    ";
                        //iTextSharp.text.Paragraph h8 = new iTextSharp.text.Paragraph(page027, times);
                        //h8.Alignment = Element.ALIGN_LEFT;
                        //h8.SetLeading(0.0f, 1.0f);
                        //document.Add(h8);
                        //Linecount = Linecount + 1;



                        //teststr = opqty;
                        //if (teststr.Length > 50)
                        //{
                        //    teststr = opqty.Substring(0, 50);
                        //    opqty = opqty.Remove(0, 50);
                        //}
                        //else
                        //{
                        //    teststr = opqty;
                        //    opqty = opqty.Remove(0, teststr.Length);
                        //}
                        teststr = "";
                        if (!string.IsNullOrWhiteSpace(opqty))
                        {
                            teststr = opqty;
                        }
                        else
                        {
                            if (rcunt <= lines.Count - 1)
                            {
                                teststr = lines[rcunt].ToString().ToUpper();
                                rcunt = rcunt + 1;
                            }
                        }
                        string DutiAmt = "";
                        if (obj.dr["DutiableUOM"].ToString() != "--Select--")
                        {
                            DutiAmt = Math.Round(Convert.ToDecimal(obj.dr["DutiableQty"].ToString()), 4).ToString("0.0000");
                        }
                        if (!string.IsNullOrWhiteSpace(teststr) || !string.IsNullOrWhiteSpace(DutiAmt))
                        {
                            handl = "LICENCE NO:";
                            space = ""; space1 = "";
                            sapceval = 0; spceval1 = 0;
                            sapceval = teststr.Length;
                            spceval1 = 50 - sapceval;
                            for (int i = 0; i < spceval1; i++)
                            {
                                space = space + " ";
                            }
                            cartype = dt.Rows[0]["VesselName"].ToString().Split(':');
                            sapceval = 0; spceval1 = 0;
                            sapceval = DutiAmt.Length;
                            spceval1 = 25 - sapceval;
                            for (int i = 0; i < spceval1; i++)
                            {
                                space1 = space1 + " ";
                            }
                            if (pgheight - 92 > lineheight)
                            {
                                if (!string.IsNullOrWhiteSpace(DutiAmt))
                                {
                                    DutiAmt = DutiAmt + " " + obj.dr["DutiableUOM"].ToString();
                                }
                                string page033 = "" + teststr + "" + space + "" + space1 + "" + DutiAmt;
                                iTextSharp.text.Paragraph i4 = new iTextSharp.text.Paragraph(page033, times);
                                i4.Alignment = Element.ALIGN_LEFT;
                                i4.SetLeading(0.0f, 1.0f);
                                document.Add(i4);
                                Linecount = Linecount + 1;
                                lineheight = lineheight + 10;
                            }
                            else
                            {
                                //document.Add(Line);
                                Linecount = Linecount + 1;
                                lineheight = lineheight + 10;

                                msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                                string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                                iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                                l3p.Alignment = Element.ALIGN_LEFT;
                                l3p.SetLeading(0.0f, 1.0f);

                                //document.Add(l3p);
                                BlankSapce1(3);
                                //document.NewPage();
                                Linecount = 0;
                                lineheight = 0;
                                ItemHeaderprint();

                                string page033 = "" + teststr + "" + space + "" + space1 + "" + DutiAmt + " " + obj.dr["DutiableUOM"].ToString();
                                iTextSharp.text.Paragraph i4 = new iTextSharp.text.Paragraph(page033, times);
                                i4.Alignment = Element.ALIGN_LEFT;
                                i4.SetLeading(0.0f, 1.0f);
                                document.Add(i4);
                                Linecount = Linecount + 1;
                                lineheight = lineheight + 10;
                            }
                        }

                        teststr = "";
                        if (!string.IsNullOrWhiteSpace(opqty))
                        {
                            teststr = opqty;
                        }
                        else
                        {
                            if (rcunt <= lines.Count - 1)
                            {
                                teststr = lines[rcunt].ToString().ToUpper();
                                rcunt = rcunt + 1;
                            }
                        }

                        //hsval = Math.Round(Convert.ToDecimal(obj.dr["TotalLineAmount"].ToString()), 4).ToString("0.0000");
                        //handl = "LICENCE NO:";
                        //space = ""; space1 = "";
                        //sapceval = 0; spceval1 = 0;
                        //sapceval = teststr.Length;
                        //spceval1 = 50 - sapceval;
                        //for (int i = 0; i < spceval1; i++)
                        //{
                        //    space = space + " ";
                        //}
                        //cartype = dt.Rows[0]["VesselName"].ToString().Split(':');
                        //sapceval = 0; spceval1 = 0;
                        //sapceval = hsval.Length;
                        //spceval1 = 25 - sapceval;
                        //for (int i = 0; i < spceval1; i++)
                        //{
                        //    space1 = space1 + " ";
                        //}
                        //string page028 = "" + teststr + "" + space + "" + space1 + "" + hsval + " " + obj.dr["UnitPriceCurrency"].ToString() + "";
                        //iTextSharp.text.Paragraph h9 = new iTextSharp.text.Paragraph(page028, times);
                        //h9.Alignment = Element.ALIGN_LEFT;
                        //h9.SetLeading(0.0f, 1.0f);
                        //document.Add(h9);
                        //Linecount = Linecount + 1;

                        //teststr = opqty;
                        //if (teststr.Length > 50)
                        //{
                        //    teststr = opqty.Substring(0, 50);
                        //    opqty = opqty.Remove(0, 50);
                        //}
                        //else
                        //{
                        //    teststr = opqty;
                        //    opqty = opqty.Remove(0, teststr.Length);
                        //}
                        DutiAmt = "";
                        if (obj.dr["ExciseDutyRate"] != DBNull.Value && !string.IsNullOrEmpty(obj.dr["ExciseDutyRate"].ToString()))
                        {
                            if (Convert.ToDecimal(obj.dr["ExciseDutyRate"].ToString()) > 0)
                            {
                                DutiAmt = obj.dr["ExciseDutyAmount"].ToString() + "";
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(teststr) || !string.IsNullOrWhiteSpace(DutiAmt))
                        {
                            handl = "LICENCE NO:";
                            space = ""; space1 = "";
                            sapceval = 0; spceval1 = 0;
                            sapceval = teststr.Length;
                            spceval1 = 50 - sapceval;
                            for (int i = 0; i < spceval1; i++)
                            {
                                space = space + " ";
                            }
                            cartype = dt.Rows[0]["VesselName"].ToString().Split(':');
                            sapceval = 0; spceval1 = 0;
                            sapceval = obj.dr["ExciseDutyAmount"].ToString().Length;
                            spceval1 = 25 - sapceval;
                            for (int i = 0; i < spceval1; i++)
                            {
                                space1 = space1 + " ";
                            }
                            if (pgheight - 92 > lineheight)
                            {
                                string page034 = "" + teststr + "" + space + "" + space1 + "" + DutiAmt + "";
                                iTextSharp.text.Paragraph i5 = new iTextSharp.text.Paragraph(page034, times);
                                i5.Alignment = Element.ALIGN_LEFT;
                                i5.SetLeading(0.0f, 1.0f);
                                document.Add(i5);
                                Linecount = Linecount + 1;
                                lineheight = lineheight + 10;
                            }
                            else
                            {
                                //document.Add(Line);
                                Linecount = Linecount + 1;
                                lineheight = lineheight + 10;

                                msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                                string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                                iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                                l3p.Alignment = Element.ALIGN_LEFT;
                                l3p.SetLeading(0.0f, 1.0f);
                                //document.Add(l3p);
                                BlankSapce1(3);
                                //document.NewPage();
                                Linecount = 0;
                                lineheight = 0;
                                ItemHeaderprint();

                                string page034 = "" + teststr + "" + space + "" + space1 + "" + DutiAmt + "";
                                iTextSharp.text.Paragraph i5 = new iTextSharp.text.Paragraph(page034, times);
                                i5.Alignment = Element.ALIGN_LEFT;
                                i5.SetLeading(0.0f, 1.0f);
                                document.Add(i5);
                                Linecount = Linecount + 1;
                                lineheight = lineheight + 10;
                            }
                        }

                        for (int ij = rcunt; rcunt <= lines.Count - 1; rcunt++)
                        {
                            if (pgheight - 92 > lineheight)
                            {
                                teststr = lines[rcunt].ToString().ToUpper();
                                string page034 = "" + teststr + "" + space + "" + space1 + "" + DutiAmt + "";
                                iTextSharp.text.Paragraph i5 = new iTextSharp.text.Paragraph(page034, times);
                                i5.Alignment = Element.ALIGN_LEFT;
                                document.Add(i5);
                                chkline = chkline + 1;
                                lineheight = lineheight + 10;
                            }
                            else
                            {
                                //document.Add(Line);
                                Linecount = Linecount + 1;
                                lineheight = lineheight + 10;

                                msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                                string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                                iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                                l3p.Alignment = Element.ALIGN_LEFT;
                                l3p.SetLeading(0.0f, 1.0f);
                                // document.Add(l3p);
                                BlankSapce1(3);
                                //document.NewPage();
                                Linecount = 0;
                                lineheight = 0;
                                ItemHeaderprint();

                                teststr = lines[rcunt].ToString().ToUpper();
                                string page034 = "" + teststr + "" + space + "" + space1 + "" + DutiAmt + "";
                                iTextSharp.text.Paragraph i5 = new iTextSharp.text.Paragraph(page034, times);
                                i5.Alignment = Element.ALIGN_LEFT;
                                document.Add(i5);
                                chkline = chkline + 1;
                                lineheight = lineheight + 10;
                            }
                        }
                        string supName = "";
                        MyClass obj1 = new MyClass();
                        string InvQury = "Select * from OutInvoiceDtl where PermitId='" + dt.Rows[0]["PermitId"].ToString() + "'";
                        obj1.dr = obj1.ret_dr(InvQury);
                        if (obj1.dr.HasRows)
                        {
                            while (obj1.dr.Read())
                            {
                                MyClass obj2 = new MyClass();
                                string supcode = "Select * from SUPPLIERMANUFACTURERPARTY where Code='" + obj1.dr["SupplierCode"].ToString() + "'";
                                obj2.dr = obj2.ret_dr(supcode);
                                if (obj2.dr.HasRows)
                                {
                                    while (obj2.dr.Read())
                                    {
                                        supName = obj2.dr["Name"].ToString();
                                    }
                                }
                            }
                        }
                        if (string.IsNullOrWhiteSpace(supName))
                        {
                            supName = "-";
                        }
                        if (supName != "-")
                        {
                            if (pgheight - 92 > lineheight)
                            {
                                string page035 = "" + supName + "";
                                iTextSharp.text.Paragraph i6 = new iTextSharp.text.Paragraph(page035, times);
                                i6.Alignment = Element.ALIGN_LEFT;
                                i6.SetLeading(0.0f, 1.0f);
                                document.Add(i6);
                                Linecount = Linecount + 1;
                                lineheight = lineheight + 10;
                            }
                            else
                            {
                                //document.Add(Line);
                                Linecount = Linecount + 1;
                                lineheight = lineheight + 10;

                                msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                                string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                                iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                                l3p.Alignment = Element.ALIGN_LEFT;
                                l3p.SetLeading(0.0f, 1.0f);
                                //document.Add(l3p);
                                BlankSapce1(3);
                                //document.NewPage();
                                Linecount = 0;
                                lineheight = 0;
                                ItemHeaderprint();

                                string page035 = "" + supName + "";
                                iTextSharp.text.Paragraph i6 = new iTextSharp.text.Paragraph(page035, times);
                                i6.Alignment = Element.ALIGN_LEFT;
                                i6.SetLeading(0.0f, 1.0f);
                                document.Add(i6);
                                Linecount = Linecount + 1;
                                lineheight = lineheight + 10;
                            }

                        }
                        else
                        {
                            //string page035 = "" + supName + "";
                            //iTextSharp.text.Paragraph i6 = new iTextSharp.text.Paragraph(page035, times);
                            //i6.Alignment = Element.ALIGN_LEFT;
                            //i6.SetLeading(0.0f, 1.0f);
                            //document.Add(i6);
                            //Linecount = Linecount + 1;
                        }

                        if (pgheight - 92 > lineheight)
                        {
                            document.Add(Line);
                            Linecount = Linecount + 1;
                            lineheight = lineheight + 10;
                        }
                        else
                        {
                            //document.Add(Line);
                            Linecount = Linecount + 1;
                            lineheight = lineheight + 10;

                            msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                            string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                            iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                            l3p.Alignment = Element.ALIGN_LEFT;
                            l3p.SetLeading(0.0f, 1.0f);
                            //document.Add(l3p);
                            BlankSapce1(3);
                            //document.NewPage();
                            Linecount = 0;
                            lineheight = 0;
                            ItemHeaderprint();

                        }
                        //BlankSapce(2);
                        //document.Add(Line);
                        //Linecount = Linecount + 1;

                        string casccode = "", cacsprctQty = "", EngNo = "", Chaseno = "";
                        MyClass obj3 = new MyClass();
                        string CascQury = "Select * from OutCASCDtl where PermitId='" + dt.Rows[0]["PermitId"].ToString() + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "'";
                        obj3.dr = obj3.ret_dr(CascQury);
                        int l = 0;
                        string sno1 = "";
                        if (obj3.dr.HasRows)
                        {
                            while (obj3.dr.Read())
                            {
                                l = l + 1;
                                sno1 = "0" + l;
                                casccode = obj3.dr["ProductCode"].ToString();
                                cacsprctQty = Math.Round(Convert.ToDecimal(obj3.dr["Quantity"].ToString()), 4).ToString("0.0000") + " " + obj3.dr["ProductUOM"].ToString();
                                EngNo = obj3.dr["CascCode1"].ToString();
                                Chaseno = obj3.dr["CascCode2"].ToString();
                                if (!string.IsNullOrWhiteSpace(casccode))
                                {
                                    if (pgheight - 92 > lineheight)
                                    {
                                        string page042 = "S/NO   CA/SC PRODUCT CODE                      CA/SC PRODUCT QTY & UNIT         ";
                                        iTextSharp.text.Paragraph j3 = new iTextSharp.text.Paragraph(page042, times);
                                        j3.Alignment = Element.ALIGN_LEFT;
                                        j3.SetLeading(0.0f, 1.0f);
                                        document.Add(j3);
                                        Linecount = Linecount + 1;
                                        lineheight = lineheight + 10;
                                    }
                                    else
                                    {
                                        //document.Add(Line);
                                        Linecount = Linecount + 1;
                                        lineheight = lineheight + 10;

                                        msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                                        string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                                        iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                                        l3p.Alignment = Element.ALIGN_LEFT;
                                        l3p.SetLeading(0.0f, 1.0f);
                                        //document.Add(l3p);
                                        BlankSapce1(3);
                                        //document.NewPage();
                                        Linecount = 0;
                                        lineheight = 0;
                                        ItemHeaderprint();

                                        string page042 = "S/NO   CA/SC PRODUCT CODE                      CA/SC PRODUCT QTY & UNIT         ";
                                        iTextSharp.text.Paragraph j3 = new iTextSharp.text.Paragraph(page042, times);
                                        j3.Alignment = Element.ALIGN_LEFT;
                                        j3.SetLeading(0.0f, 1.0f);
                                        document.Add(j3);
                                        Linecount = Linecount + 1;
                                        lineheight = lineheight + 10;
                                    }

                                    for (int k = 0; sno1.Length < 5; k++)
                                    {
                                        sno1 = " " + sno1;
                                    }
                                    string caspt = Math.Round(Convert.ToDecimal(obj3.dr["Quantity"].ToString()), 4).ToString("0.0000");
                                    for (int k = 0; caspt.Length < 16; k++)
                                    {
                                        caspt = " " + caspt;
                                    }
                                    space = ""; space1 = "";
                                    sapceval = 0; spceval1 = 0;
                                    sapceval = teststr.Length;
                                    spceval1 = 50 - sapceval;
                                    for (int i = 0; i < 22; i++)
                                    {
                                        space = space + " ";
                                    }
                                    sapceval = 0; spceval1 = 0;
                                    sapceval = casccode.Length;
                                    spceval1 = 18 - sapceval;
                                    for (int i = 0; i < spceval1; i++)
                                    {
                                        space1 = space1 + " ";
                                    }
                                    if (pgheight - 92 > lineheight)
                                    {
                                        string page043 = "" + sno1 + "" + "  " + casccode + "" + space1 + "" + space + "" + caspt + " " + obj3.dr["ProductUOM"].ToString() + "";
                                        iTextSharp.text.Paragraph j4 = new iTextSharp.text.Paragraph(page043, times);
                                        j4.Alignment = Element.ALIGN_LEFT;
                                        j4.SetLeading(0.0f, 1.0f);
                                        document.Add(j4);
                                        Linecount = Linecount + 1;
                                        lineheight = lineheight + 10;
                                    }
                                    else
                                    {
                                        //document.Add(Line);
                                        Linecount = Linecount + 1;
                                        lineheight = lineheight + 10;

                                        msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                                        string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                                        iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                                        l3p.Alignment = Element.ALIGN_LEFT;
                                        l3p.SetLeading(0.0f, 1.0f);
                                        //document.Add(l3p);
                                        BlankSapce1(3);
                                        //document.NewPage();
                                        Linecount = 0;
                                        lineheight = 0;
                                        ItemHeaderprint();

                                        string page043 = "" + sno1 + "" + "  " + casccode + "" + space1 + "" + space + "" + caspt + " " + obj3.dr["ProductUOM"].ToString() + "";
                                        iTextSharp.text.Paragraph j4 = new iTextSharp.text.Paragraph(page043, times);
                                        j4.Alignment = Element.ALIGN_LEFT;
                                        j4.SetLeading(0.0f, 1.0f);
                                        document.Add(j4);
                                        Linecount = Linecount + 1;
                                        lineheight = lineheight + 10;
                                    }
                                    if (pgheight - 92 > lineheight)
                                    {
                                        document.Add(Line);
                                        Linecount = Linecount + 1;
                                        lineheight = lineheight + 10;
                                    }
                                    else
                                    {
                                        //document.Add(Line);
                                        Linecount = Linecount + 1;
                                        lineheight = lineheight + 10;

                                        msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                                        string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                                        iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                                        l3p.Alignment = Element.ALIGN_LEFT;
                                        l3p.SetLeading(0.0f, 1.0f);
                                        //document.Add(l3p);
                                        BlankSapce1(3);
                                        //document.NewPage();
                                        Linecount = 0;
                                        lineheight = 0;
                                        ItemHeaderprint();
                                    }
                                }
                                if (!string.IsNullOrWhiteSpace(EngNo))
                                {
                                    string eng = obj.dr["HSCode"].ToString().Substring(0, 2);
                                    if (eng == "87")
                                    {
                                        if (pgheight - 92 > lineheight)
                                        {
                                            string page042 = "S/NO   ENGINE NO/CHASSIS NO                               ";
                                            iTextSharp.text.Paragraph j3 = new iTextSharp.text.Paragraph(page042, times);
                                            j3.Alignment = Element.ALIGN_LEFT;
                                            j3.SetLeading(0.0f, 1.0f);
                                            document.Add(j3);
                                            Linecount = Linecount + 1;
                                            lineheight = lineheight + 10;
                                        }
                                        else
                                        {
                                            //document.Add(Line);
                                            Linecount = Linecount + 1;
                                            lineheight = lineheight + 10;

                                            msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                                            string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                                            iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                                            l3p.Alignment = Element.ALIGN_LEFT;
                                            l3p.SetLeading(0.0f, 1.0f);
                                            //document.Add(l3p);
                                            BlankSapce1(3);
                                            //document.NewPage();
                                            Linecount = 0;
                                            lineheight = 0;
                                            ItemHeaderprint();

                                            string page042 = "S/NO   ENGINE NO/CHASSIS NO                               ";
                                            iTextSharp.text.Paragraph j3 = new iTextSharp.text.Paragraph(page042, times);
                                            j3.Alignment = Element.ALIGN_LEFT;
                                            j3.SetLeading(0.0f, 1.0f);
                                            document.Add(j3);
                                            Linecount = Linecount + 1;
                                            lineheight = lineheight + 10;
                                        }
                                        for (int k = 0; sno1.Length < 5; k++)
                                        {
                                            sno1 = " " + sno1;
                                        }
                                        if (pgheight - 92 > lineheight)
                                        {
                                            string page043 = "" + sno1 + "" + "  " + EngNo.ToUpper() + "/" + Chaseno.ToUpper() + "";
                                            iTextSharp.text.Paragraph j4 = new iTextSharp.text.Paragraph(page043, times);
                                            j4.Alignment = Element.ALIGN_LEFT;
                                            j4.SetLeading(0.0f, 1.0f);
                                            document.Add(j4);
                                            Linecount = Linecount + 1;
                                            lineheight = lineheight + 10;
                                        }
                                        else
                                        {
                                            //document.Add(Line);
                                            Linecount = Linecount + 1;
                                            lineheight = lineheight + 10;

                                            msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                                            string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                                            iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                                            l3p.Alignment = Element.ALIGN_LEFT;
                                            l3p.SetLeading(0.0f, 1.0f);
                                            //document.Add(l3p);
                                            BlankSapce1(3);
                                            //document.NewPage();
                                            Linecount = 0;
                                            lineheight = 0;
                                            ItemHeaderprint();

                                            string page043 = "" + sno1 + "" + "  " + EngNo.ToUpper() + "/" + Chaseno.ToUpper() + "";
                                            iTextSharp.text.Paragraph j4 = new iTextSharp.text.Paragraph(page043, times);
                                            j4.Alignment = Element.ALIGN_LEFT;
                                            j4.SetLeading(0.0f, 1.0f);
                                            document.Add(j4);
                                            Linecount = Linecount + 1;
                                            lineheight = lineheight + 10;
                                        }
                                        if (pgheight - 92 > lineheight)
                                        {
                                            document.Add(Line);
                                            Linecount = Linecount + 1;
                                            lineheight = lineheight + 10;
                                        }
                                        else
                                        {
                                            //document.Add(Line);
                                            Linecount = Linecount + 1;
                                            lineheight = lineheight + 10;

                                            msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                                            string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                                            iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                                            l3p.Alignment = Element.ALIGN_LEFT;
                                            l3p.SetLeading(0.0f, 1.0f);
                                            //document.Add(l3p);
                                            BlankSapce1(3);
                                            //document.NewPage();
                                            Linecount = 0;
                                            lineheight = 0;
                                            ItemHeaderprint();
                                        }
                                    }
                                }
                            }
                        }
                        if (pgheight - 92 > lineheight)
                        {
                            chkline = chkline + 1;
                            BlankSapce(2);
                        }
                        else
                        {
                            //document.Add(Line);
                            Linecount = Linecount + 1;
                            lineheight = lineheight + 10;

                            msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                            string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                            iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                            l3p.Alignment = Element.ALIGN_LEFT;
                            l3p.SetLeading(0.0f, 1.0f);
                            //document.Add(l3p);
                            BlankSapce1(3);
                            //document.NewPage();
                            Linecount = 0;
                            lineheight = 0;
                            ItemHeaderprint();
                        }
                        if (pgheight - 92 > lineheight)
                        {
                            document.Add(Line);
                            Linecount = Linecount + 1;
                            lineheight = lineheight + 10;
                        }
                        else
                        {
                            //document.Add(Line);
                            Linecount = Linecount + 1;
                            lineheight = lineheight + 10;

                            msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                            string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                            iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                            l3p.Alignment = Element.ALIGN_LEFT;
                            l3p.SetLeading(0.0f, 1.0f);
                            //document.Add(l3p);
                            BlankSapce1(3);
                            //document.NewPage();
                            Linecount = 0;
                            lineheight = 0;
                            ItemHeaderprint();
                        }
                        //BlankSapce(1);
                        //Linecount = Linecount + 1;
                    }
                    else
                    {
                        //document.Add(Line);
                        Linecount = Linecount + 1;

                        msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                        string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                        iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                        l3p.Alignment = Element.ALIGN_LEFT;
                        l3p.SetLeading(0.0f, 1.0f);
                        //document.Add(l3p);
                        BlankSapce(4);
                        Linecount = 0;
                    }

                }
            }

            if (pgheight - 92 > lineheight)
            {
                string page323 = "TRADER’S REMARKS                                                            ";
                iTextSharp.text.Paragraph al4 = new iTextSharp.text.Paragraph(page323, times);
                al4.Alignment = Element.ALIGN_LEFT;
                al4.SetLeading(0.0f, 1.0f);
                document.Add(al4);
                Linecount = Linecount + 1;
                lineheight = lineheight + 10;
            }
            else
            {
                //document.Add(Line);
                Linecount = Linecount + 1;
                lineheight = lineheight + 10;

                msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                l3p.Alignment = Element.ALIGN_LEFT;
                l3p.SetLeading(0.0f, 1.0f);
                //document.Add(l3p);
                BlankSapce1(3);
                //document.NewPage();
                Linecount = 0;
                lineheight = 0;
                Detailprintval();

                string page323 = "TRADER’S REMARKS                                                            ";
                iTextSharp.text.Paragraph al4 = new iTextSharp.text.Paragraph(page323, times);
                al4.Alignment = Element.ALIGN_LEFT;
                al4.SetLeading(0.0f, 1.0f);
                document.Add(al4);
                Linecount = Linecount + 1;
                lineheight = lineheight + 10;
            }


            if (pgheight - 92 > lineheight)
            {
               int partLength13 = 80;
               string sentence13 = dt.Rows[0]["TradeRemarks"].ToString();
                List<string> lines =
                    sentence13
                        .Split(' ')
                        .Aggregate(new[] { "" }.ToList(), (a, x) =>
                        {
                            var last = a[a.Count - 1];
                            if ((last + " " + x).Length > partLength13)
                            {
                                a.Add(x);
                            }
                            else
                            {
                                a[a.Count - 1] = (last + " " + x).Trim();
                            }
                            return a;
                        });
                for (int k = 0; k < lines.Count; k++)
                {
                    if (pgheight - 92 > lineheight)
                    {
                        string page324 = "" + lines[k].ToString() + "";
                        page324 = page324.Replace("\n", " ");
                        iTextSharp.text.Paragraph al5 = new iTextSharp.text.Paragraph(page324.ToUpper(), times);
                        al5.Alignment = Element.ALIGN_LEFT;
                        al5.SetLeading(0.0f, 1.0f);
                        document.Add(al5);
                        Linecount = Linecount + 1;
                        lineheight = lineheight + 10;
                    }
                    else
                    {
                        //document.Add(Line);
                        Linecount = Linecount + 1;
                        lineheight = lineheight + 10;

                        msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                        string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                        iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                        l3p.Alignment = Element.ALIGN_LEFT;
                        l3p.SetLeading(0.0f, 1.0f);
                        //document.Add(l3p);
                        BlankSapce1(3);
                        //document.NewPage();
                        Linecount = 0;
                        lineheight = 0;
                        Detailprintval();

                        string page324 = "" + lines[k].ToString() + "";
                        page324 = page324.Replace("\n", " ");
                        iTextSharp.text.Paragraph al5 = new iTextSharp.text.Paragraph(page324.ToUpper(), times);
                        al5.Alignment = Element.ALIGN_LEFT;
                        al5.SetLeading(0.0f, 1.0f);
                        document.Add(al5);
                        Linecount = Linecount + 1;
                        lineheight = lineheight + 10;
                    }
                }
            }
            else
            {
                //document.Add(Line);
                Linecount = Linecount + 1;
                lineheight = lineheight + 10;

                msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                l3p.Alignment = Element.ALIGN_LEFT;
                l3p.SetLeading(0.0f, 1.0f);
                //document.Add(l3p);
                BlankSapce1(3);
                //document.NewPage();
                Linecount = 0;
                lineheight = 0;
                Detailprintval();

               int partLength14 = 80;
               string sentence14 = dt.Rows[0]["TradeRemarks"].ToString();
                List<string> lines =
                    sentence14
                        .Split(' ')
                        .Aggregate(new[] { "" }.ToList(), (a, x) =>
                        {
                            var last = a[a.Count - 1];
                            if ((last + " " + x).Length > partLength14)
                            {
                                a.Add(x);
                            }
                            else
                            {
                                a[a.Count - 1] = (last + " " + x).Trim();
                            }
                            return a;
                        });
                for (int k = 0; k < lines.Count; k++)
                {
                    if (pgheight - 92 > lineheight)
                    {
                        string page324 = "" + lines[k].ToString() + "";
                        page324 = page324.Replace("\n", " ");
                        iTextSharp.text.Paragraph al5 = new iTextSharp.text.Paragraph(page324.ToUpper(), times);
                        al5.Alignment = Element.ALIGN_LEFT;
                        al5.SetLeading(0.0f, 1.0f);
                        document.Add(al5);
                        Linecount = Linecount + 1;
                        lineheight = lineheight + 10;
                    }
                    else
                    {
                        //document.Add(Line);
                        Linecount = Linecount + 1;
                        lineheight = lineheight + 10;

                        msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                        page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                        iTextSharp.text.Paragraph l3pp = new iTextSharp.text.Paragraph(page062, times);
                        l3pp.Alignment = Element.ALIGN_LEFT;
                        l3pp.SetLeading(0.0f, 1.0f);
                        //document.Add(l3pp);
                        BlankSapce1(3);
                        //document.NewPage();
                        Linecount = 0;
                        lineheight = 0;
                        Detailprintval();

                        string page324 = "" + lines[k].ToString() + "";
                        page324 = page324.Replace("\n", " ");
                        iTextSharp.text.Paragraph al5 = new iTextSharp.text.Paragraph(page324.ToUpper(), times);
                        al5.Alignment = Element.ALIGN_LEFT;
                        al5.SetLeading(0.0f, 1.0f);
                        document.Add(al5);
                        Linecount = Linecount + 1;
                        lineheight = lineheight + 10;
                    }
                }
            }


            string csno = "", cName = "", Ctype = "", cVal = "", cVal1 = "";
            MyClass obj5 = new MyClass();
            string Conqury = "select * from OutContainerDtl where PermitId='" + dt.Rows[0]["PermitId"].ToString() + "'";
            obj5.dr = obj5.ret_dr(Conqury);
            if (obj5.dr.HasRows)
            {
                while (obj5.dr.Read())
                {
                    csno = obj5.dr["RowNo"].ToString();
                    cName = obj5.dr["ContainerNo"].ToString();
                    Ctype = obj5.dr["Size"].ToString();
                    cVal = obj5.dr["Weight"].ToString();
                    cVal1 = obj5.dr["SealNo"].ToString();
                    if (csno == "1")
                    {
                        if (pgheight - 92 > lineheight)
                        {
                            document.Add(Line);
                            Linecount = Linecount + 1;
                            lineheight = lineheight + 10;
                        }
                        else
                        {
                            //document.Add(Line);
                            Linecount = Linecount + 1;
                            lineheight = lineheight + 10;

                            msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                            string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                            iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                            l3p.Alignment = Element.ALIGN_LEFT;
                            l3p.SetLeading(0.0f, 1.0f);
                            //document.Add(l3p);
                            BlankSapce1(3);
                            //document.NewPage();
                            Linecount = 0;
                            lineheight = 0;
                            Detailprintval();
                        }

                        if (pgheight - 92 > lineheight)
                        {
                            string page331 = "CONTAINER IDENTIFIERS                                                       ";
                            iTextSharp.text.Paragraph am0 = new iTextSharp.text.Paragraph(page331, times);
                            am0.Alignment = Element.ALIGN_LEFT;
                            am0.SetLeading(0.0f, 1.0f);
                            document.Add(am0);
                            Linecount = Linecount + 1;
                            lineheight = lineheight + 10;
                        }
                        else
                        {
                            //document.Add(Line);
                            Linecount = Linecount + 1;
                            lineheight = lineheight + 10;

                            msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                            string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                            iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                            l3p.Alignment = Element.ALIGN_LEFT;
                            l3p.SetLeading(0.0f, 1.0f);
                            //document.Add(l3p);
                            BlankSapce1(3);
                            //document.NewPage();
                            Linecount = 0;
                            lineheight = 0;
                            Detailprintval();

                            string page331 = "CONTAINER IDENTIFIERS                                                       ";
                            iTextSharp.text.Paragraph am0 = new iTextSharp.text.Paragraph(page331, times);
                            am0.Alignment = Element.ALIGN_LEFT;
                            am0.SetLeading(0.0f, 1.0f);
                            document.Add(am0);
                            Linecount = Linecount + 1;
                            lineheight = lineheight + 10;
                        }
                    }
                    if (pgheight - 92 > lineheight)
                    {
                        if (csno.Length < 2)
                        {
                            csno = "0" + csno + ")";
                        }
                        if (cVal.Length < 3)
                        {
                            for (int i = cVal.Length; cVal.Length < 3; i++)
                            {
                                cVal = "0" + cVal;
                            }
                        }
                        for (int k = cName.Length; cName.Length < 13; k++)
                        {
                            cName = cName + " ";
                        }
                        string[] Ctype1 = Ctype.Split(':');
                        string ctype = "", ctype1 = "";
                        ctype = Ctype1[0].ToString().Substring(0, 3);
                        ctype1 = Ctype1[0].ToString().Substring(Ctype1[0].ToString().Length - 3);
                        ctype1 = ctype1.Substring(0, ctype1.Length - 1);
                        ctype = ctype + " " + ctype1;
                        string page332 = "" + csno + "  " + cName.ToUpper() + " " + ctype + " " + cVal + " " + cVal1.ToUpper() + "             ";
                        iTextSharp.text.Paragraph am1 = new iTextSharp.text.Paragraph(page332, times);
                        am1.Alignment = Element.ALIGN_LEFT;
                        am1.SetLeading(0.0f, 1.0f);
                        document.Add(am1);
                        Linecount = Linecount + 1;
                        lineheight = lineheight + 10;
                    }
                    else
                    {
                        //document.Add(Line);
                        Linecount = Linecount + 1;
                        lineheight = lineheight + 10;

                        msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                        string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                        iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                        l3p.Alignment = Element.ALIGN_LEFT;
                        l3p.SetLeading(0.0f, 1.0f);
                        //document.Add(l3p);
                        BlankSapce1(3);
                        //document.NewPage();
                        Linecount = 0;
                        lineheight = 0;
                        Detailprintval();

                        if (csno.Length < 2)
                        {
                            csno = "0" + csno + ")";
                        }
                        if (cVal.Length < 3)
                        {
                            for (int i = cVal.Length; cVal.Length < 3; i++)
                            {
                                cVal = "0" + cVal;
                            }
                        }
                        for (int k = cName.Length; cName.Length < 13; k++)
                        {
                            cName = cName + " ";
                        }
                        string[] Ctype1 = Ctype.Split(':');
                        string ctype = "", ctype1 = "";
                        ctype = Ctype1[0].ToString().Substring(0, 3);
                        ctype1 = Ctype1[0].ToString().Substring(Ctype1[0].ToString().Length - 3);
                        ctype1 = ctype1.Substring(0, ctype1.Length - 1);
                        ctype = ctype + " " + ctype1;
                        string page332 = "" + csno + "  " + cName.ToUpper() + " " + ctype + " " + cVal + " " + cVal1.ToUpper() + "             ";
                        iTextSharp.text.Paragraph am1 = new iTextSharp.text.Paragraph(page332, times);
                        am1.Alignment = Element.ALIGN_LEFT;
                        am1.SetLeading(0.0f, 1.0f);
                        document.Add(am1);
                        Linecount = Linecount + 1;
                        lineheight = lineheight + 10;
                    }
                }
            }

            if (pgheight - 92 > lineheight)
            {
                document.Add(Line);
                Linecount = Linecount + 1;
                lineheight = lineheight + 10;
            }
            else
            {
                //document.Add(Line);
                Linecount = Linecount + 1;
                lineheight = lineheight + 10;

                msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                l3p.Alignment = Element.ALIGN_LEFT;
                l3p.SetLeading(0.0f, 1.0f);
                //document.Add(l3p);
                BlankSapce1(3);
                //document.NewPage();
                Linecount = 0;
                lineheight = 0;
                Detailprintval();
            }


            if (pgheight - 92 > lineheight)
            {
                string page342 = "NO UNAUTHORISED ADDITION/AMENDMENT TO THIS PERMIT MAY BE MADE AFTER APPROVAL     ";
                iTextSharp.text.Paragraph an1 = new iTextSharp.text.Paragraph(page342, times);
                an1.Alignment = Element.ALIGN_LEFT;
                an1.SetLeading(0.0f, 1.0f);
                document.Add(an1);
                Linecount = Linecount + 1;
                lineheight = lineheight + 10;
            }
            else
            {
                //document.Add(Line);
                Linecount = Linecount + 1;
                lineheight = lineheight + 10;

                msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                l3p.Alignment = Element.ALIGN_LEFT;
                l3p.SetLeading(0.0f, 1.0f);
                //document.Add(l3p);
                BlankSapce1(3);
                //document.NewPage();
                Linecount = 0;
                lineheight = 0;
                Detailprintval();

                string page342 = "NO UNAUTHORISED ADDITION/AMENDMENT TO THIS PERMIT MAY BE MADE AFTER APPROVAL     ";
                iTextSharp.text.Paragraph an1 = new iTextSharp.text.Paragraph(page342, times);
                an1.Alignment = Element.ALIGN_LEFT;
                an1.SetLeading(0.0f, 1.0f);
                document.Add(an1);
                Linecount = Linecount + 1;
                lineheight = lineheight + 10;
            }

            if (pgheight - 92 > lineheight)
            {
                document.Add(Line);
                Linecount = Linecount + 1;
                lineheight = lineheight + 10;
            }
            else
            {
                //document.Add(Line);
                Linecount = Linecount + 1;
                lineheight = lineheight + 10;

                msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                l3p.Alignment = Element.ALIGN_LEFT;
                l3p.SetLeading(0.0f, 1.0f);
                //document.Add(l3p);
                BlankSapce1(3);
                //document.NewPage();
                Linecount = 0;
                lineheight = 0;
                Detailprintval();
            }

            if (pgheight - 92 > lineheight)
            {
                BlankSapce(1);
                string page344 = "NAME OF COMPANY: " + comNamedec + "             ";
                iTextSharp.text.Paragraph an3 = new iTextSharp.text.Paragraph(page344, times);
                an3.Alignment = Element.ALIGN_LEFT;
                an3.SetLeading(0.0f, 1.0f);
                document.Add(an3);
                Linecount = Linecount + 1;
                lineheight = lineheight + 10;

                BlankSapce(1);

            }
            else
            {
                //document.Add(Line);
                Linecount = Linecount + 1;
                lineheight = lineheight + 10;

                msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                l3p.Alignment = Element.ALIGN_LEFT;
                l3p.SetLeading(0.0f, 1.0f);
                //document.Add(l3p);
                BlankSapce1(3);
                //document.NewPage();
                Linecount = 0;
                lineheight = 0;
                Detailprintval();

                BlankSapce(1);
                string page344 = "NAME OF COMPANY: " + comNamedec + "             ";
                iTextSharp.text.Paragraph an3 = new iTextSharp.text.Paragraph(page344, times);
                an3.Alignment = Element.ALIGN_LEFT;
                an3.SetLeading(0.0f, 1.0f);
                document.Add(an3);
                Linecount = Linecount + 1;
                lineheight = lineheight + 10;

                BlankSapce(1);
            }

            if (pgheight - 92 > lineheight)
            {
                string page346 = "DECLARANT NAME : " + Decname + "             ";
                iTextSharp.text.Paragraph an5 = new iTextSharp.text.Paragraph(page346, times);
                an5.Alignment = Element.ALIGN_LEFT;
                an5.SetLeading(0.0f, 1.0f);
                document.Add(an5);
                Linecount = Linecount + 1;
                lineheight = lineheight + 10;

                BlankSapce(1);

            }
            else
            {
                //document.Add(Line);
                Linecount = Linecount + 1;
                lineheight = lineheight + 10;

                msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                l3p.Alignment = Element.ALIGN_LEFT;
                l3p.SetLeading(0.0f, 1.0f);
                //document.Add(l3p);
                BlankSapce1(3);
                //document.NewPage();
                Linecount = 0;
                lineheight = 0;
                Detailprintval();

                string page346 = "DECLARANT NAME : " + Decname + "             ";
                iTextSharp.text.Paragraph an5 = new iTextSharp.text.Paragraph(page346, times);
                an5.Alignment = Element.ALIGN_LEFT;
                an5.SetLeading(0.0f, 1.0f);
                document.Add(an5);
                Linecount = Linecount + 1;
                lineheight = lineheight + 10;

                BlankSapce(1);
            }

            deccode = deccode.Substring(deccode.Length - 5);
            for (int i = 0; i < 4; i++)
            {
                deccode = "X" + deccode;
            }
            if (pgheight - 92 > lineheight)
            {
                string page348 = "DECLARANT CODE : " + deccode + "                                              ";
                iTextSharp.text.Paragraph an7 = new iTextSharp.text.Paragraph(page348, times);
                an7.Alignment = Element.ALIGN_LEFT;
                an7.SetLeading(0.0f, 1.0f);
                document.Add(an7);
                Linecount = Linecount + 1;
                lineheight = lineheight + 10;

            }
            else
            {
                //document.Add(Line);
                Linecount = Linecount + 1;
                lineheight = lineheight + 10;

                msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                l3p.Alignment = Element.ALIGN_LEFT;
                l3p.SetLeading(0.0f, 1.0f);
                //document.Add(l3p);
                BlankSapce1(3);
                //document.NewPage();
                Linecount = 0;
                lineheight = 0;
                Detailprintval();

                string page348 = "DECLARANT CODE : " + deccode + "                                              ";
                iTextSharp.text.Paragraph an7 = new iTextSharp.text.Paragraph(page348, times);
                an7.Alignment = Element.ALIGN_LEFT;
                an7.SetLeading(0.0f, 1.0f);
                document.Add(an7);
                Linecount = Linecount + 1;
                lineheight = lineheight + 10;
            }

            if (pgheight - 92 > lineheight)
            {
                string page349 = "TEL NO         : " + telphn + "                                              ";
                iTextSharp.text.Paragraph an8 = new iTextSharp.text.Paragraph(page349, times);
                an8.Alignment = Element.ALIGN_LEFT;
                an8.SetLeading(0.0f, 1.0f);
                document.Add(an8);
                Linecount = Linecount + 1;
                lineheight = lineheight + 10;
            }
            else
            {
                //document.Add(Line);
                Linecount = Linecount + 1;
                lineheight = lineheight + 10;

                msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                l3p.Alignment = Element.ALIGN_LEFT;
                l3p.SetLeading(0.0f, 1.0f);
                //document.Add(l3p);
                BlankSapce1(3);
                //document.NewPage();
                Linecount = 0;
                lineheight = 0;
                Detailprintval();

                string page349 = "TEL NO         : " + telphn + "                                              ";
                iTextSharp.text.Paragraph an8 = new iTextSharp.text.Paragraph(page349, times);
                an8.Alignment = Element.ALIGN_LEFT;
                an8.SetLeading(0.0f, 1.0f);
                document.Add(an8);
                Linecount = Linecount + 1;
                lineheight = lineheight + 10;
            }

            if (pgheight - 92 > lineheight)
            {
                document.Add(Line);
                Linecount = Linecount + 1;
                lineheight = lineheight + 10;
            }
            else
            {
                //document.Add(Line);
                Linecount = Linecount + 1;
                lineheight = lineheight + 10;

                msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                l3p.Alignment = Element.ALIGN_LEFT;
                l3p.SetLeading(0.0f, 1.0f);
                //document.Add(l3p);
                BlankSapce1(3);
                //document.NewPage();
                Linecount = 0;
                lineheight = 0;
                Detailprintval();
            }

            if (pgheight - 92 > lineheight)
            {
                string page350 = "CONTROLLING AGENCY/CUSTOMS CONDITIONS                                           ";
                iTextSharp.text.Paragraph an9 = new iTextSharp.text.Paragraph(page350, times);
                an9.Alignment = Element.ALIGN_LEFT;
                an9.SetLeading(0.0f, 1.0f);
                document.Add(an9);
                Linecount = Linecount + 1;
                lineheight = lineheight + 10;
            }
            else
            {
                //document.Add(Line);
                Linecount = Linecount + 1;
                lineheight = lineheight + 10;

                msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                l3p.Alignment = Element.ALIGN_LEFT;
                l3p.SetLeading(0.0f, 1.0f);
                //document.Add(l3p);
                BlankSapce1(3);
                //document.NewPage();
                Linecount = 0;
                lineheight = 0;
                Detailprintval();

                string page350 = "CONTROLLING AGENCY/CUSTOMS CONDITIONS                                           ";
                iTextSharp.text.Paragraph an9 = new iTextSharp.text.Paragraph(page350, times);
                an9.Alignment = Element.ALIGN_LEFT;
                an9.SetLeading(0.0f, 1.0f);
                document.Add(an9);
                Linecount = Linecount + 1;
                lineheight = lineheight + 10;
            }

            if (dt.Rows[0]["prmtStatus"].ToString() == "AMD")
            {
                prmtdt.dr = prmtdt.ret_dr("select Distinct * from OutAMDPMT where PermitNumber='" + dt.Rows[0]["PermitNumber"].ToString() + "' order by Sno");
                if (prmtdt.dr.HasRows)
                {
                    while (prmtdt.dr.Read())
                    {
                        string cnstr = "";
                        cnstr = prmtdt.dr["ConditionCode"].ToString();
                        for (int k = 0; cnstr.Length < 4; k++)
                        {
                            cnstr = cnstr + " ";
                        }                        
                        string sentence2 = cnstr + "" + " - " + prmtdt.dr["ConditionDescription"].ToString();
                        List<string> lines = new List<string>();
                        for (int i = 0; i < sentence2.Length; i++)
                        {
                            if (i == 80)
                            {
                                lines.Add(sentence2.Substring(0, 80));
                                sentence2 = sentence2.Remove(0, 80);
                                sentence2.TrimStart();
                                i = 0;
                            }
                        }
                        lines.Add(sentence2);
                        //List<string> lines =
                        //    sentence
                        //        .Split(' ')
                        //        .Aggregate(new[] { "" }.ToList(), (a, x) =>
                        //        {
                        //            var last = a[a.Count - 1];
                        //            if ((last + " " + x).Length > partLength)
                        //            {
                        //                a.Add(x);
                        //            }
                        //            else
                        //            {
                        //                a[a.Count - 1] = (last + " " + x).Trim();
                        //            }
                        //            return a;
                        //        });
                        for (int j = 0; j < lines.Count; j++)
                        {
                            if (pgheight - 142 > lineheight)
                            {
                                Chunk t1 = null;
                                Phrase tt1 = null;
                                if (j == 0)
                                {
                                    cnstr = "";
                                    cnstr = prmtdt.dr["ConditionCode"].ToString();
                                    for (int k = 0; cnstr.Length < 4; k++)
                                    {
                                        cnstr = cnstr + " ";
                                    }
                                    t1 = new Chunk(cnstr + " ", timesBold);
                                    tt1 = new Phrase(t1);
                                    if (prmtdt.dr["ConditionCode"].ToString().Length == 2)
                                    {
                                        lines[j] = lines[j].ToString().Substring(3);
                                    }
                                    else
                                    {
                                        lines[j] = lines[j].ToString().Substring(4);
                                    }
                                }
                                lines[j] = lines[j].ToString().Replace("~", "'");
                                Chunk cc1 = new Chunk(lines[j].ToString().TrimStart() + "", times);
                                Phrase tt2 = new Phrase(cc1);
                                iTextSharp.text.Paragraph ao1 = new iTextSharp.text.Paragraph();
                                if (j == 0)
                                {
                                    ao1.Add(tt1);
                                }
                                ao1.Add(tt2);
                                ao1.Alignment = Element.ALIGN_LEFT;
                                ao1.SetLeading(0.0f, 0.90f);
                                document.Add(ao1);
                                Linecount = Linecount + 1;
                                lineheight = lineheight + 10;
                            }
                            else
                            {
                                //document.Add(Line);
                                Linecount = Linecount + 1;
                                lineheight = lineheight + 10;

                                msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                                string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                                iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                                l3p.Alignment = Element.ALIGN_LEFT;
                                l3p.SetLeading(0.0f, 1.0f);
                                //document.Add(l3p);
                                //BlankSapce1(2);
                                document.NewPage();
                                BlankSapce1(1);
                                Linecount = 0;
                                lineheight = 0;
                                Detailprintval();

                                Chunk t1 = null;
                                Phrase tt1 = null;
                                if (j == 0)
                                {
                                    cnstr = "";
                                    cnstr = prmtdt.dr["ConditionCode"].ToString();
                                    for (int k = 0; cnstr.Length < 4; k++)
                                    {
                                        cnstr = cnstr + " ";
                                    }
                                    t1 = new Chunk(cnstr + " ", timesBold);
                                    tt1 = new Phrase(t1);
                                    if (prmtdt.dr["ConditionCode"].ToString().Length == 2)
                                    {
                                        lines[j] = lines[j].ToString().Substring(3);
                                    }
                                    else
                                    {
                                        lines[j] = lines[j].ToString().Substring(4);
                                    }
                                }
                                lines[j] = lines[j].ToString().Replace("~", "'");
                                Chunk cc1 = new Chunk(lines[j].ToString().TrimStart() + "", times);
                                Phrase tt2 = new Phrase(cc1);
                                iTextSharp.text.Paragraph ao1 = new iTextSharp.text.Paragraph();
                                if (j == 0)
                                {
                                    ao1.Add(tt1);
                                }
                                ao1.Add(tt2);
                                ao1.Alignment = Element.ALIGN_LEFT;
                                ao1.SetLeading(0.0f, 0.90f);
                                document.Add(ao1);
                                Linecount = Linecount + 1;
                                lineheight = lineheight + 10;
                            }
                        }

                    }
                }

                if (pgheight - 142 > lineheight)
                {
                    string page348 = "   ";
                    iTextSharp.text.Paragraph an7 = new iTextSharp.text.Paragraph(page348, times);
                    an7.Alignment = Element.ALIGN_LEFT;
                    an7.SetLeading(0.0f, 1.0f);
                    document.Add(an7);
                    Linecount = Linecount + 1;
                    lineheight = lineheight + 10;
                }
                else
                {
                    Linecount = Linecount + 1;
                    lineheight = lineheight + 10;

                    msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                    string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                    iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                    l3p.Alignment = Element.ALIGN_LEFT;
                    l3p.SetLeading(0.0f, 1.0f);
                    //document.Add(l3p);
                    //BlankSapce1(2);
                    document.NewPage();
                    BlankSapce1(1);
                    Linecount = 0;
                    lineheight = 0;
                    Detailprintval();
                }
                if (pgheight - 142 > lineheight)
                {

                    string page348 = "THE FOLLOWING FIELDS HAVE BEEN AMENDED";
                    iTextSharp.text.Paragraph an7 = new iTextSharp.text.Paragraph(page348, times);
                    an7.Alignment = Element.ALIGN_LEFT;
                    an7.SetLeading(0.0f, 1.0f);
                    document.Add(an7);
                    Linecount = Linecount + 1;
                    lineheight = lineheight + 10;
                }
                else
                {
                    Linecount = Linecount + 1;
                    lineheight = lineheight + 10;

                    msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                    string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                    iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                    l3p.Alignment = Element.ALIGN_LEFT;
                    l3p.SetLeading(0.0f, 1.0f);
                    //document.Add(l3p);
                    //BlankSapce1(2);
                    document.NewPage();
                    BlankSapce1(1);
                    Linecount = 0;
                    lineheight = 0;
                    Detailprintval();

                    string page348 = "THE FOLLOWING FIELDS HAVE BEEN AMENDED";
                    iTextSharp.text.Paragraph an7 = new iTextSharp.text.Paragraph(page348, times);
                    an7.Alignment = Element.ALIGN_LEFT;
                    an7.SetLeading(0.0f, 1.0f);
                    document.Add(an7);
                    Linecount = Linecount + 1;
                    lineheight = lineheight + 10;
                }

                MyClass ojbcon = new MyClass();
                ojbcon.dr = ojbcon.ret_dr("select * from amndtbl where MSGId='" + dt.Rows[0]["MSGId"].ToString() + "' and DecType='OUTDEC'");
                if (ojbcon.dr.HasRows)
                {
                    while (ojbcon.dr.Read())
                    {
                        MyClass objki = new MyClass();
                        objki.dr = objki.ret_dr("select * from amendtbl where Amendcode='" + ojbcon.dr["CodtionCde"].ToString() + "'");
                        if (objki.dr.HasRows)
                        {
                            while (objki.dr.Read())
                            {
                                if (pgheight - 142 > lineheight)
                                {
                                   int partLength15 = 80;
                                   string sentence15 = objki.dr["Desciption"].ToString();
                                    List<string> lines =
                                        sentence15
                                            .Split(' ')
                                            .Aggregate(new[] { "" }.ToList(), (a, x) =>
                                            {
                                                var last = a[a.Count - 1];
                                                if ((last + " " + x).Length > partLength15)
                                                {
                                                    a.Add(x);
                                                }
                                                else
                                                {
                                                    a[a.Count - 1] = (last + " " + x).Trim();
                                                }
                                                return a;
                                            });

                                    for (int i = 0; i < lines.Count; i++)
                                    {
                                        string page348 = lines[i].ToString().ToUpper();
                                        //string page348 = objki.dr["Desciption"].ToString().ToUpper();
                                        iTextSharp.text.Paragraph an7 = new iTextSharp.text.Paragraph(page348, times);
                                        an7.Alignment = Element.ALIGN_LEFT;
                                        an7.SetLeading(0.0f, 1.0f);
                                        document.Add(an7);
                                        Linecount = Linecount + 1;
                                        lineheight = lineheight + 10;
                                    }
                                }
                                else
                                {
                                    Linecount = Linecount + 1;
                                    lineheight = lineheight + 10;

                                    msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                                    string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                                    iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                                    l3p.Alignment = Element.ALIGN_LEFT;
                                    l3p.SetLeading(0.0f, 1.0f);
                                    //document.Add(l3p);
                                    //BlankSapce1(2);
                                    document.NewPage();
                                    BlankSapce1(1);
                                    Linecount = 0;
                                    lineheight = 0;
                                    Detailprintval();

                                   int partLength16 = 80;
                                   string sentence16 = objki.dr["Desciption"].ToString();
                                    List<string> lines =
                                        sentence16
                                            .Split(' ')
                                            .Aggregate(new[] { "" }.ToList(), (a, x) =>
                                            {
                                                var last = a[a.Count - 1];
                                                if ((last + " " + x).Length > partLength16)
                                                {
                                                    a.Add(x);
                                                }
                                                else
                                                {
                                                    a[a.Count - 1] = (last + " " + x).Trim();
                                                }
                                                return a;
                                            });

                                    for (int i = 0; i < lines.Count; i++)
                                    {
                                        string page348 = lines[i].ToString().ToUpper();
                                        //string page348 = objki.dr["Desciption"].ToString().ToUpper();
                                        iTextSharp.text.Paragraph an7 = new iTextSharp.text.Paragraph(page348, times);
                                        an7.Alignment = Element.ALIGN_LEFT;
                                        an7.SetLeading(0.0f, 1.0f);
                                        document.Add(an7);
                                        Linecount = Linecount + 1;
                                        lineheight = lineheight + 10;
                                    }
                                }
                            }
                        }
                    }
                }

            }
            else
            {
                prmtdt.dr = prmtdt.ret_dr("select Distinct * from OutPMT where PermitNumber='" + dt.Rows[0]["PermitNumber"].ToString() + "' order by Sno");
                if (prmtdt.dr.HasRows)
                {
                    while (prmtdt.dr.Read())
                    {
                        string cnstr = "";
                        cnstr = prmtdt.dr["ConditionCode"].ToString();
                        for (int k = 0; cnstr.Length < 4; k++)
                        {
                            cnstr = cnstr + " ";
                        }                       
                       string sentence17 = cnstr + "" + " - " + prmtdt.dr["ConditionDescription"].ToString();
                        List<string> lines = new List<string>();
                        for (int i = 0; i < sentence17.Length; i++)
                        {
                            if (i == 80)
                            {
                                lines.Add(sentence17.Substring(0, 80));
                                sentence17 = sentence17.Remove(0, 80);
                                sentence17.TrimStart();
                                i = 0;
                            }
                        }
                        lines.Add(sentence17);
                        //List<string> lines =
                        //    sentence
                        //        .Split(null)
                        //        .Aggregate(new[] { "" }.ToList(), (a, x) =>
                        //        {
                        //            var last = a[a.Count - 1];
                        //            if ((last + " " + x).Length > partLength)
                        //            {
                        //                a.Add(x);
                        //            }
                        //            else
                        //            {
                        //                a[a.Count - 1] = (last + " " + x).Trim();
                        //            }
                        //            return a;
                        //        });
                        for (int j = 0; j < lines.Count; j++)
                        {
                            if (pgheight - 142 > lineheight)
                            {
                                Chunk t1 = null;
                                Phrase tt1 = null;
                                if (j == 0)
                                {
                                    cnstr = "";
                                    cnstr = prmtdt.dr["ConditionCode"].ToString();
                                    for (int k = 0; cnstr.Length < 4; k++)
                                    {
                                        cnstr = cnstr + " ";
                                    }
                                    t1 = new Chunk(cnstr + " ", timesBold);
                                    tt1 = new Phrase(t1);
                                    if (prmtdt.dr["ConditionCode"].ToString().Length == 2)
                                    {
                                        lines[j] = lines[j].ToString().Substring(3);
                                    }
                                    else
                                    {
                                        if (prmtdt.dr["ConditionCode"].ToString().Length == 4)
                                        {
                                            lines[j] = lines[j].ToString().Substring(5);
                                        }
                                        else
                                        {
                                            lines[j] = lines[j].ToString().Substring(4);
                                        }
                                    }
                                }
                                lines[j] = lines[j].ToString().Replace("~", "'");
                                Chunk cc1 = new Chunk(lines[j].ToString().TrimStart() + "", times);
                                Phrase tt2 = new Phrase(cc1);
                                iTextSharp.text.Paragraph ao1 = new iTextSharp.text.Paragraph();
                                if (j == 0)
                                {
                                    ao1.Add(tt1);
                                }
                                ao1.Add(tt2);
                                ao1.Alignment = Element.ALIGN_LEFT;
                                ao1.SetLeading(0.0f, 1.0f);
                                document.Add(ao1);
                                Linecount = Linecount + 1;
                                lineheight = lineheight + 10;
                            }
                            else
                            {
                                //document.Add(Line);
                                Linecount = Linecount + 1;
                                lineheight = lineheight + 15;

                                msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                                string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                                iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                                l3p.Alignment = Element.ALIGN_LEFT;
                                l3p.SetLeading(0.0f, 1.0f);
                                //document.Add(l3p);
                                //BlankSapce1(3);
                                document.NewPage();
                                BlankSapce1(1);
                                Linecount = 0;
                                lineheight = 0;
                                Detailprintval();

                                Chunk t1 = null;
                                Phrase tt1 = null;
                                if (j == 0)
                                {
                                    cnstr = "";
                                    cnstr = prmtdt.dr["ConditionCode"].ToString();
                                    for (int k = 0; cnstr.Length < 4; k++)
                                    {
                                        cnstr = cnstr + " ";
                                    }
                                    t1 = new Chunk(cnstr + " ", timesBold);
                                    tt1 = new Phrase(t1);
                                    if (prmtdt.dr["ConditionCode"].ToString().Length == 2)
                                    {
                                        lines[j] = lines[j].ToString().Substring(3);
                                    }
                                    else
                                    {
                                        if (prmtdt.dr["ConditionCode"].ToString().Length == 4)
                                        {
                                            lines[j] = lines[j].ToString().Substring(5);
                                        }
                                        else
                                        {
                                            lines[j] = lines[j].ToString().Substring(4);
                                        }
                                    }
                                }
                                lines[j] = lines[j].ToString().Replace("~", "'");
                                Chunk cc1 = new Chunk(lines[j].ToString().TrimStart() + "", times);
                                Phrase tt2 = new Phrase(cc1);
                                iTextSharp.text.Paragraph ao1 = new iTextSharp.text.Paragraph();
                                if (j == 0)
                                {
                                    ao1.Add(tt1);
                                }
                                ao1.Add(tt2);
                                ao1.Alignment = Element.ALIGN_LEFT;
                                ao1.SetLeading(0.0f, 1.0f);
                                document.Add(ao1);
                                Linecount = Linecount + 1;
                                lineheight = lineheight + 15;
                            }
                        }

                    }
                }
            }
            //int numline = 0;
            if (lineheight < 540)
            {
                lineheight = 540;
                //numline = 142;
            }
            else
            {
                if (lineheight < 650)
                {
                    //numline = 112;
                }
                else
                {
                    //numline = 142;
                }
            }
            //for (int li = Linecount; li <= 75; li++)
            //{
            while (pgheight - 112 > lineheight)
            {
                //BlankSapce1(1);
                string page3625 = "                                       ";
                iTextSharp.text.Paragraph ap24 = new iTextSharp.text.Paragraph(page3625, times);
                ap24.Alignment = Element.ALIGN_LEFT;
                ap24.SetLeading(0.0f, 1.0f);
                document.Add(ap24);
                Linecount = Linecount + 1;
                lineheight = lineheight + 15;
            }
            //}


            //document.Add(Line);
            Linecount = Linecount + 1;

            msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
            string page33591 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
            iTextSharp.text.Paragraph am401 = new iTextSharp.text.Paragraph(page33591, times);
            am401.Alignment = Element.ALIGN_LEFT;
            am401.SetLeading(0.0f, 1.0f);
            //am401.FirstLineIndent = 640;
            //am401.IndentationLeft = 30;
            //am401.IndentationRight = 50;
            //document.Add(am401);

            document.Close();
            byte[] bytes = File.ReadAllBytes(filename);

            using (MemoryStream stream = new MemoryStream())
            {
                PdfReader reader = new PdfReader(bytes);
                using (PdfStamper stamper = new PdfStamper(reader, stream))
                {
                    int pages = reader.NumberOfPages;
                    for (int i = 1; i <= pages; i++)
                    {
                        if (i == 1)
                        {
                            ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_RIGHT, new Phrase("PG  : " + i.ToString() + " OF " + pages, times), 541f, 698f, 0);
                        }
                        else
                        {
                            ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_RIGHT, new Phrase("PG  : " + i.ToString() + " OF " + pages, times), 541f, 817f, 0);
                        }

                        string linecodep = "";
                        for (int il = 1; il <= 80; il++)
                        {
                            linecodep = linecodep + "-";
                        }
                        ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_RIGHT, new Phrase(linecodep, times), 541f, 50f, 0);
                        string page33591p = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                        ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_RIGHT, new Phrase(page33591p, times), 282f, 40f, 0);
                    }
                }
                bytes = stream.ToArray();

            }
            File.WriteAllBytes(filename, bytes);
            ShowPdf(filename);
        }
        private void BlankSapce(int spceval)
        {
            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1257, false);
            iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 10, iTextSharp.text.Font.NORMAL);

            BaseFont bfTimes1 = BaseFont.CreateFont(BaseFont.COURIER_BOLD, BaseFont.CP1257, false);
            iTextSharp.text.Font timesBold = new iTextSharp.text.Font(bfTimes1, 10, iTextSharp.text.Font.NORMAL);

            for (int j = 1; j <= spceval; j++)
            {
                //string impna4a = "                                                                                ";
                //iTextSharp.text.Paragraph rr = new iTextSharp.text.Paragraph(impna4a, times);
                //rr.Alignment = Element.ALIGN_LEFT;
                //rr.SetLeading(0.0f, 1.0f);
                //document.Add(rr);
                //Linecount = Linecount + 1;
                if (pgheight - 92 > lineheight)
                {
                    document.Add(Chunk.NEWLINE);
                    Linecount = Linecount + 1;
                    lineheight = lineheight + 10;
                }
            }
        }
        private void BlankSapce1(int spceval)
        {
            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1257, false);
            iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 10, iTextSharp.text.Font.NORMAL);

            BaseFont bfTimes1 = BaseFont.CreateFont(BaseFont.COURIER_BOLD, BaseFont.CP1257, false);
            iTextSharp.text.Font timesBold = new iTextSharp.text.Font(bfTimes1, 10, iTextSharp.text.Font.NORMAL);

            for (int j = 1; j <= spceval; j++)
            {
                //string impna4a = "                                                                                ";
                //iTextSharp.text.Paragraph rr = new iTextSharp.text.Paragraph(impna4a, times);
                //rr.Alignment = Element.ALIGN_LEFT;
                //rr.SetLeading(0.0f, 1.0f);
                //document.Add(rr);                
                document.Add(Chunk.NEWLINE);
                Linecount = Linecount + 1;                
            }
        }
        private void ItemHeaderprint()
        {
            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1257, false);
            iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 10, iTextSharp.text.Font.NORMAL);

            BaseFont bfTimes1 = BaseFont.CreateFont(BaseFont.COURIER_BOLD, BaseFont.CP1257, false);
            iTextSharp.text.Font timesBold = new iTextSharp.text.Font(bfTimes1, 10, iTextSharp.text.Font.NORMAL);

            string linecode = "";
            for (int i = 1; i <= 80; i++)
            {
                linecode = linecode + "-";
            }

            iTextSharp.text.Paragraph Line = new iTextSharp.text.Paragraph(linecode, times);
            Line.SetLeading(0.0f, 1.0f);

            string page001 = "                                     CARGO CLEARANCE PERMIT                   ";
            iTextSharp.text.Paragraph e9 = new iTextSharp.text.Paragraph(page001, times);
            e9.Alignment = Element.ALIGN_LEFT;
            e9.SetLeading(0.0f, 1.0f);
            document.Add(e9);
            Linecount = Linecount + 1;
            lineheight = lineheight + 10;

            Chunk cce1 = new Chunk("PERMIT NO    : ", times);
            Phrase tte2 = new Phrase(cce1);
            string pernum="";
            if(!string.IsNullOrWhiteSpace(dt.Rows[0]["PermitNumber"].ToString()))
            {
                pernum=dt.Rows[0]["PermitNumber"].ToString();
            }
            else
            {
                pernum="DRAFT";
            }
            Chunk pt1 = new Chunk(pernum, times);
            Phrase ptt1 = new Phrase(pt1);
            Chunk pt12 = new Chunk("           ======================                     ", times);
            Phrase ptt12 = new Phrase(pt12);
            iTextSharp.text.Paragraph p1 = new iTextSharp.text.Paragraph();
            p1.Add(tte2);
            p1.Add(ptt1);
            p1.Add(ptt12);
            //p1.Alignment = Element.ALIGN_LEFT;
            p1.SetLeading(0.0f, 1.0f);
            document.Add(p1);
            Linecount = Linecount + 1;
            lineheight = lineheight + 10;

            //string page002 = "PERMIT NO : IM9C105123Y              ======================                     ";
            //iTextSharp.text.Paragraph f1 = new iTextSharp.text.Paragraph(page002, times);
            //f1.Alignment = Element.ALIGN_LEFT;
            //f1.SetLeading(0.0f, 1f);
            //document.Add(f1);
            //Linecount = Linecount + 1;

            string page003 = "                                      (CONTINUATION PAGE)                       ";
            iTextSharp.text.Paragraph f2 = new iTextSharp.text.Paragraph(page003, times);
            f2.Alignment = Element.ALIGN_LEFT;
            f2.SetLeading(0.0f, 1.0f);
            document.Add(f2);
            Linecount = Linecount + 1;
            lineheight = lineheight + 10;

            BlankSapce(1);
            string page004 = "CONSIGNMENT DETAILS                                                             ";
            iTextSharp.text.Paragraph f3 = new iTextSharp.text.Paragraph(page004, times);
            f3.Alignment = Element.ALIGN_LEFT;
            f3.SetLeading(0.0f, 1.0f);
            document.Add(f3);
            Linecount = Linecount + 1;
            lineheight = lineheight + 10;

            document.Add(Line);
            Linecount = Linecount + 1;
            lineheight = lineheight + 10;

            string page006 = "S/NO     HS CODE      CURRENT LOT NO         PREVIOUS LOT NO                ";
            iTextSharp.text.Paragraph f5 = new iTextSharp.text.Paragraph(page006, times);
            f5.Alignment = Element.ALIGN_LEFT;
            f5.SetLeading(0.0f, 1.0f);
            document.Add(f5);
            Linecount = Linecount + 1;
            lineheight = lineheight + 10;

            string page007 = "MARKING    CTY OF ORIGIN    BRAND NAME       MODEL                            ";
            iTextSharp.text.Paragraph f6 = new iTextSharp.text.Paragraph(page007, times);
            f6.Alignment = Element.ALIGN_LEFT;
            f6.SetLeading(0.0f, 1.0f);
            document.Add(f6);
            Linecount = Linecount + 1;
            lineheight = lineheight + 10;


            handl = "IN MAWB/CUCR/OBL";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = handl.Length;
            spceval1 = 45 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }
            //string page009p = "IN MAWB/OUCR/OBL" + space + "OUT MAWB/OUCR/OBL                 ";
            //iTextSharp.text.Paragraph f8p = new iTextSharp.text.Paragraph(page009p, times);
            //f8p.Alignment = Element.ALIGN_LEFT;
            //f8p.SetLeading(0.0f, 1.0f);
            //document.Add(f8p);
            //Linecount = Linecount + 1;

            if (!string.IsNullOrWhiteSpace(strInHAWBOBL))
            {
                handl = "IN HAWB/HUCR/HBL";
                space = ""; space1 = "";
                sapceval = 0; spceval1 = 0;
                sapceval = handl.Length;
                spceval1 = 45 - sapceval;
                for (int i = 0; i < spceval1; i++)
                {
                    space = space + " ";
                }
                string page009 = "IN HAWB/HUCR/HBL" + space + "OUT HAWB/HUCR/HBL                 ";
                iTextSharp.text.Paragraph f8 = new iTextSharp.text.Paragraph(page009, times);
                f8.Alignment = Element.ALIGN_LEFT;
                f8.SetLeading(0.0f, 1.0f);
                document.Add(f8);
                Linecount = Linecount + 1;
                lineheight = lineheight + 10;
            }
            handl = "PACKING/GOODS DESCRIPTION";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = handl.Length;
            spceval1 = 45 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }
            string page010 = "PACKING/GOODS DESCRIPTION" + space + "HS QUANTITY & UNIT                ";
            iTextSharp.text.Paragraph f9 = new iTextSharp.text.Paragraph(page010, times);
            f9.Alignment = Element.ALIGN_LEFT;
            f9.SetLeading(0.0f, 1.0f);
            document.Add(f9);
            Linecount = Linecount + 1;
            lineheight = lineheight + 10;

            string page011 = "                                             CIF/FOB VALUE (S$)                ";
            iTextSharp.text.Paragraph g1 = new iTextSharp.text.Paragraph(page011, times);
            g1.Alignment = Element.ALIGN_LEFT;
            g1.SetLeading(0.0f, 1.0f);
            document.Add(g1);
            Linecount = Linecount + 1;
            lineheight = lineheight + 10;

            //string page013 = "                                             GST AMOUNT (S$)                   ";
            //iTextSharp.text.Paragraph g3 = new iTextSharp.text.Paragraph(page013, times);
            //g3.Alignment = Element.ALIGN_LEFT;
            //g3.SetLeading(0.0f, 1.0f);
            //document.Add(g3);
            //Linecount = Linecount + 1;

            if (obj.dr["DutiableUOM"].ToString() != "--Select--")
            {
                string page014 = "                                             DUT QTY/WT/VOL & UNIT             ";
                iTextSharp.text.Paragraph g4 = new iTextSharp.text.Paragraph(page014, times);
                g4.Alignment = Element.ALIGN_LEFT;
                g4.SetLeading(0.0f, 1.0f);
                document.Add(g4);
                Linecount = Linecount + 1;
                lineheight = lineheight + 10;
            }

            //string page015 = "                                             UNIT PRICE & CODE                 ";
            //iTextSharp.text.Paragraph g5 = new iTextSharp.text.Paragraph(page015, times);
            //g5.Alignment = Element.ALIGN_LEFT;
            //g5.SetLeading(0.0f, 1.0f);
            //document.Add(g5);
            //Linecount = Linecount + 1;

            if (obj.dr["ExciseDutyRate"] != DBNull.Value && !string.IsNullOrEmpty(obj.dr["ExciseDutyRate"].ToString()))
            {
                if (Convert.ToDecimal(obj.dr["ExciseDutyRate"].ToString()) > 0)
                {
                    string page016 = "                                             EXCISE DUTY PAYABLE (S$)          ";
                    iTextSharp.text.Paragraph g6 = new iTextSharp.text.Paragraph(page016, times);
                    g6.Alignment = Element.ALIGN_LEFT;
                    g6.SetLeading(0.0f, 1.0f);
                    document.Add(g6);
                    Linecount = Linecount + 1;
                    lineheight = lineheight + 10;
                }
            }
            MyClass obj11 = new MyClass();
            string InvQury = "Select * from OutInvoiceDtl where PermitId='" + dt.Rows[0]["PermitId"].ToString() + "'";
            obj11.dr = obj11.ret_dr(InvQury);
            if (obj11.dr.HasRows)
            {
                while (obj11.dr.Read())
                {
                    if (!string.IsNullOrWhiteSpace(obj11.dr["SupplierCode"].ToString()))
                    {
                        string page019 = "MANUFACTURER’S NAME                                                         ";
                        iTextSharp.text.Paragraph g9 = new iTextSharp.text.Paragraph(page019, times);
                        g9.Alignment = Element.ALIGN_LEFT;
                        g9.SetLeading(0.0f, 1.0f);
                        document.Add(g9);
                        Linecount = Linecount + 1;
                        lineheight = lineheight + 10;
                    }
                }
            }
            document.Add(Line);
            Linecount = Linecount + 1;
            lineheight = lineheight + 10;
        }
        private void Detailprintval()
        {
            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1257, false);
            iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 10, iTextSharp.text.Font.NORMAL);

            BaseFont bfTimes1 = BaseFont.CreateFont(BaseFont.COURIER_BOLD, BaseFont.CP1257, false);
            iTextSharp.text.Font timesBold = new iTextSharp.text.Font(bfTimes1, 10, iTextSharp.text.Font.NORMAL);

            string linecode = "";
            for (int i = 1; i <= 80; i++)
            {
                linecode = linecode + "-";
            }

            iTextSharp.text.Paragraph Line = new iTextSharp.text.Paragraph(linecode, times);

            Linecount = 0;
            string page001 = "                                     CARGO CLEARANCE PERMIT                   ";
            iTextSharp.text.Paragraph e9 = new iTextSharp.text.Paragraph(page001, times);
            e9.Alignment = Element.ALIGN_LEFT;
            e9.SetLeading(0.0f, 1.0f);
            document.Add(e9);
            Linecount = Linecount + 1;
            lineheight = lineheight + 10;

            Chunk cce1 = new Chunk("PERMIT NO    : ", times);
            Phrase tte2 = new Phrase(cce1);
            string pernum="";
            if(!string.IsNullOrWhiteSpace(dt.Rows[0]["PermitNumber"].ToString()))
            {
                pernum=dt.Rows[0]["PermitNumber"].ToString();
            }
            else
            {
                pernum="DRAFT";
            }
            Chunk pt1 = new Chunk(pernum, times);
            Phrase ptt1 = new Phrase(pt1);
            Chunk pt12 = new Chunk("           ======================                     ", times);
            Phrase ptt12 = new Phrase(pt12);
            iTextSharp.text.Paragraph p1 = new iTextSharp.text.Paragraph();
            p1.Add(tte2);
            p1.Add(ptt1);
            p1.Add(ptt12);
            //p1.Alignment = Element.ALIGN_LEFT;
            p1.SetLeading(0.0f, 1.0f);
            document.Add(p1);
            Linecount = Linecount + 1;
            lineheight = lineheight + 10;

            //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
            string page338 = "                                      (CONTINUATION PAGE)                       ";
            iTextSharp.text.Paragraph am7 = new iTextSharp.text.Paragraph(page338, times);
            am7.Alignment = Element.ALIGN_LEFT;
            am7.SetLeading(0.0f, 1.0f);
            document.Add(am7);
            Linecount = Linecount + 1;
            lineheight = lineheight + 10;

            BlankSapce(1);
            //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
            string page339 = "CONSIGNMENT DETAILS (Cont’d)                                                          ";
            iTextSharp.text.Paragraph am8 = new iTextSharp.text.Paragraph(page339, times);
            am8.Alignment = Element.ALIGN_LEFT;
            am8.SetLeading(0.0f, 1.0f);
            document.Add(am8);
            Linecount = Linecount + 1;
            lineheight = lineheight + 10;

            document.Add(Line);
            Linecount = Linecount + 1;
            lineheight = lineheight + 10;
        }
        public void ShowPdf(string filename)
        {
            //Clears all content output from Buffer Stream
            Response.ClearContent();
            //Clears all headers from Buffer Stream
            Response.ClearHeaders();
            //Adds an HTTP header to the output stream
            //Response.AddHeader("Content-Disposition", "inline;filename=" + filename);
            Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".pdf");
            //Gets or Sets the HTTP MIME type of the output stream
            Response.ContentType = "application/pdf";
            //Writes the content of the specified file directory to an HTTP response output stream as a file block
            Response.WriteFile(filename);
            //sends all currently buffered output to the client
            Response.Flush();
            //Clears all content output from Buffer Stream
            Response.Clear();
        }

        /*protected void GridInPayment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //  DECCOMPSearGRID.SelectedIndex = Convert.ToInt16(e.CommandArgument);
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = GridInPayment.Rows[rowIndex];
                if (row != null)
                {
                    var lblCode1 = row.FindControl("Id") as Label;
                     var chk = row.FindControl("CheckBox1") as CheckBox ;
                     if (chk.Checked != true)
                     {

                        var invEdit = row.FindControl("ImageButton1") as ImageButton;

                        Label ID1 = (Label)row.FindControl("Id");
                        string ID = ID1.Text;
                        Response.Redirect("Out.aspx?ID=" + ID);

                        // Label ID1 = (Label)grdrow.FindControl("Id");
                        // string ID = ID1.Text;
                        //string ID = lblCode1.Text;
                         //string ID = "4";
                         //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(900/2);var Mtop = (screen.height/2)-(500/2);window.open( 'OutView.aspx?ID=" + ID + "', null, 'height=500,width=2000,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
                     }
                    //Response.Redirect("InpaymentView.aspx?ID=" + ID);
                }
            }
        }*/


        protected void GridInPayment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "Select")
            //{
            //    //  DECCOMPSearGRID.SelectedIndex = Convert.ToInt16(e.CommandArgument);
            //    int rowIndex = Convert.ToInt32(e.CommandArgument);

            //    //Reference the GridView Row.
            //    GridViewRow row = GridInPayment.Rows[rowIndex];
            //    if (row != null)
            //    {
            //        var lblCode1 = row.FindControl("Id") as Label;
            //        var chk = row.FindControl("CheckBox1") as CheckBox;
            //        if (chk.Checked != true)
            //        {
            //            // Label ID1 = (Label)grdrow.FindControl("Id");
            //            // string ID = ID1.Text;
            //            string ID = lblCode1.Text;
            //            //string ID = "4";
            //            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(900/2);var Mtop = (screen.height/2)-(500/2);window.open( 'OutView.aspx?ID=" + ID + "', null, 'height=500,width=2000,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
            //        }
            //        //Response.Redirect("InpaymentView.aspx?ID=" + ID);
            //    }
            //}
        }

        protected void GridInPayment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridInPayment, "Select$" + e.Row.RowIndex);
            //    e.Row.Attributes["style"] = "cursor:pointer";
            //}
        }

        protected void Drppermitedit_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow gvrow in GridInPayment.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("CheckBox1");
                if (chk != null & chk.Checked)
                {
                    Label status = (Label)gvrow.FindControl("lblStatus");
                    string ID = status.Text;
                    if (ID.ToUpper() == "APR" || ID.ToUpper() == "AME")
                    {

                        if (Drppermitedit.SelectedItem.ToString() == "--Select--")
                        {

                        }
                        else if (Drppermitedit.SelectedItem.ToString() == "AMEND")
                        {
                            //foreach (GridViewRow gvrow in GridInPayment.Rows)
                            //{
                            var checkbox = gvrow.FindControl("CheckBox1") as CheckBox;
                            if (checkbox.Checked)
                            {
                                //Label ID1 = (Label)gvrow.FindControl("Id");
                                //string ID = ID1.Text;
                                //MyClass lodobj = new MyClass();
                                //string lodport = "select * from [OutHeaderTbl] where PermitNumber='XO9C015957S'";
                                //lodobj.dr = lodobj.ret_dr(lodport);
                                //if (lodobj.dr.HasRows)
                                //{
                                //    while (lodobj.dr.Read())
                                //    {
                                //        PermID = lodobj.dr["Id"].ToString();
                                //    }
                                //}

                                //Response.Redirect("Out.aspx?Id=" + ID + "&Update=" + Drppermitedit.SelectedItem.ToString() + "");




                                Label ID1 = (Label)gvrow.FindControl("lblPermitNo");
                                PermitId = ID1.Text;


                                Label id = (Label)gvrow.FindControl("Id");
                                string idf = id.Text;


                                PermitNO();
                                JobNO();
                                refid();
                                MSGNO();
                                string Touch_user = Session["UserId"].ToString();
                                string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                string permitnumber = "";
                                MyClass lod12 = new MyClass();
                                lod12.dr = lod12.ret_dr("select PermitNumber from OutHeaderTbl where PermitId='" + idf + "'");
                                if (lod12.dr.HasRows)
                                {
                                    while (lod12.dr.Read())
                                    {
                                        permitnumber = lod12.dr["PermitNumber"].ToString();
                                    }
                                }

                                string headertbl = "insert into OutHeaderTbl ([Refid],[JobId],[MSGId],[PermitId],[TradeNetMailboxID],[MessageType],[DeclarationType],[PreviousPermit],[CargoPackType],[InwardTransportMode],[OutwardTransportMode],[BGIndicator],[SupplyIndicator],[ReferenceDocuments],[License],[COType],[Entryyear],[GSPDonorCountry],[CerDetailtype1],[CerDetailCopies1],[CerDetailtype2],[CerDetailCopies2],[PerCommon],[CurrencyCode],[AddCerDtl],[TransDtl],[Recipient],[DeclarantCompanyCode],[ExporterCompanyCode],[Inwardcarriercode],[OutwardCarrierAgentCode],[FreightForwarderCode],[ImporterCompanyCode],[InwardCarrierAgentCode],[CONSIGNEECode],[EndUserCode],[Manufacturer],[ArrivalDate],[ArrivalTime],[LoadingPortCode],[VoyageNumber],[VesselName],[OceanBillofLadingNo],[ConveyanceRefNo],[TransportId],[FlightNO],[AircraftRegNo],[MasterAirwayBill],[ReleaseLocation],[ResLoaName],[RecepitLocation],[RecepitLocName],[StorageLocation],[BlanketStartDate],[DepartureDate],[DepartureTime],[DischargePort],[FinalDestinationCountry],[OutVoyageNumber],[OutVesselName],[OutOceanBillofLadingNo],[VesselType],[VesselNetRegTon],[VesselNationality] ,[TowingVesselID],[TowingVesselName],[NextPort],[LastPort],[OutConveyanceRefNo],[OutTransportId],[OutFlightNO],[OutAircraftRegNo],[OutMasterAirwayBill],[outHAWB],[INHAWB],[TotalOuterPack],[TotalOuterPackUOM],[TotalGrossWeight],[TotalGrossWeightUOM],[GrossReference],[TradeRemarks],[InternalRemarks],[DeclareIndicator],[NumberOfItems],[TotalCIFFOBValue],[TotalGSTTaxAmt],[TotalExDutyAmt],[TotalCusDutyAmt],[TotalODutyAmt],[TotalAmtPay],[Status],[TouchUser],[TouchTime],PermitNumber,[prmtStatus],[RepLocName],[CertificateNumber],[Defrentprinting],[Cnb] )";
                                headertbl = headertbl + "  select  '" + refno + "' as Refid,'" + JobNo + "' as JobId ,'" + MsgNO + "' as MSGID,'" + PermitNo + "' as PermitId,[TradeNetMailboxID],[MessageType],[DeclarationType],[PreviousPermit],[CargoPackType],[InwardTransportMode],[OutwardTransportMode],[BGIndicator],[SupplyIndicator],[ReferenceDocuments],[License],[COType],[Entryyear],[GSPDonorCountry],[CerDetailtype1],[CerDetailCopies1],[CerDetailtype2],[CerDetailCopies2],[PerCommon],[CurrencyCode],[AddCerDtl],[TransDtl],[Recipient],[DeclarantCompanyCode],[ExporterCompanyCode],[Inwardcarriercode],[OutwardCarrierAgentCode],[FreightForwarderCode],[ImporterCompanyCode],[InwardCarrierAgentCode],[CONSIGNEECode],[EndUserCode],[Manufacturer],[ArrivalDate],[ArrivalTime],[LoadingPortCode],[VoyageNumber],[VesselName],[OceanBillofLadingNo],[ConveyanceRefNo],[TransportId],[FlightNO],[AircraftRegNo],[MasterAirwayBill],[ReleaseLocation],[ResLoaName],[RecepitLocation],[RecepitLocName],[StorageLocation],[BlanketStartDate],[DepartureDate],[DepartureTime],[DischargePort],[FinalDestinationCountry],[OutVoyageNumber],[OutVesselName],[OutOceanBillofLadingNo],[VesselType],[VesselNetRegTon],[VesselNationality] ,[TowingVesselID],[TowingVesselName],[NextPort],[LastPort],[OutConveyanceRefNo],[OutTransportId],[OutFlightNO],[OutAircraftRegNo],[OutMasterAirwayBill],[outHAWB],[INHAWB],[TotalOuterPack],[TotalOuterPackUOM],[TotalGrossWeight],[TotalGrossWeightUOM],[GrossReference],[TradeRemarks],[InternalRemarks],[DeclareIndicator],[NumberOfItems],[TotalCIFFOBValue],[TotalGSTTaxAmt],[TotalExDutyAmt],[TotalCusDutyAmt],[TotalODutyAmt],[TotalAmtPay],'NEW' as [Status],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime],'" + permitnumber + "' as [PermitNumber],'AMD' as [prmtStatus],[RepLocName],[CertificateNumber],[Defrentprinting],[Cnb] from OutHeaderTbl where [PermitId] = '" + PermitId + "'  ";

                                /*
                                string headertbl = "insert into OutHeaderTbl ([Refid],[JobId],[MSGId],[PermitId],[TradeNetMailboxID],[MessageType],[DeclarationType],[PreviousPermit],[CargoPackType],[InwardTransportMode],[OutwardTransportMode],[BGIndicator],[SupplyIndicator],[ReferenceDocuments],[License],[COType],[Entryyear],[GSPDonorCountry],[CerDetailtype1],[CerDetailCopies1],[CerDetailtype2],[CerDetailCopies2],[PerCommon],[CurrencyCode],[AddCerDtl],[TransDtl],[Recipient],[DeclarantCompanyCode],[ExporterCompanyCode],[Inwardcarriercode],[OutwardCarrierAgentCode],[FreightForwarderCode],[ImporterCompanyCode],[InwardCarrierAgentCode],[CONSIGNEECode],[EndUserCode],[Manufacturer],[ArrivalDate],[ArrivalTime],[LoadingPortCode],[VoyageNumber],[VesselName],[OceanBillofLadingNo],[ConveyanceRefNo],[TransportId],[FlightNO],[AircraftRegNo],[MasterAirwayBill],[ReleaseLocation],[ResLoaName],[RecepitLocation],[RepLocName],[StorageLocation],[BlanketStartDate],[DepartureDate],[DepartureTime],[DischargePort],[FinalDestinationCountry],[OutVoyageNumber],[OutVesselName],[OutOceanBillofLadingNo],[VesselType],[VesselNetRegTon],[VesselNationality] ,[TowingVesselID],[TowingVesselName],[NextPort],[LastPort],[OutConveyanceRefNo],[OutTransportId],[OutFlightNO],[OutAircraftRegNo],[OutMasterAirwayBill],[TotalOuterPack],[TotalOuterPackUOM],[TotalGrossWeight],[TotalGrossWeightUOM],[GrossReference],[TradeRemarks],[InternalRemarks],[DeclareIndicator],[NumberOfItems],[TotalCIFFOBValue],[TotalGSTTaxAmt],[TotalExDutyAmt],[TotalCusDutyAmt],[TotalODutyAmt],[TotalAmtPay],[Status],[TouchUser],[TouchTime],[PermitNumber],[prmtStatus])";
                                headertbl = headertbl + "  select  '" + refno + "' as Refid,'" + JobNo + "' as JobId ,'" + MsgNO + "' as MSGID,'" + PermitNo + "' as PermitId,[TradeNetMailboxID],[MessageType],[DeclarationType],[PreviousPermit],[CargoPackType],[InwardTransportMode],[OutwardTransportMode],[BGIndicator],[SupplyIndicator],[ReferenceDocuments],[License],[COType],[Entryyear],[GSPDonorCountry],[CerDetailtype1],[CerDetailCopies1],[CerDetailtype2],[CerDetailCopies2],[PerCommon],[CurrencyCode],[AddCerDtl],[TransDtl],[Recipient],[DeclarantCompanyCode],[ExporterCompanyCode],[Inwardcarriercode],[OutwardCarrierAgentCode],[FreightForwarderCode],[ImporterCompanyCode],[InwardCarrierAgentCode],[CONSIGNEECode],[EndUserCode],[Manufacturer],[ArrivalDate],[ArrivalTime],[LoadingPortCode],[VoyageNumber],[VesselName],[OceanBillofLadingNo],[ConveyanceRefNo],[TransportId],[FlightNO],[AircraftRegNo],[MasterAirwayBill],[ReleaseLocation],[ResLoaName],[RecepitLocation],[RepLocName],[StorageLocation],[BlanketStartDate],[DepartureDate],[DepartureTime],[DischargePort],[FinalDestinationCountry],[OutVoyageNumber],[OutVesselName],[OutOceanBillofLadingNo],[VesselType],[VesselNetRegTon],[VesselNationality] ,[TowingVesselID],[TowingVesselName],[NextPort],[LastPort],[OutConveyanceRefNo],[OutTransportId],[OutFlightNO],[OutAircraftRegNo],[OutMasterAirwayBill],[TotalOuterPack],[TotalOuterPackUOM],[TotalGrossWeight],[TotalGrossWeightUOM],[GrossReference],[TradeRemarks],[InternalRemarks],[DeclareIndicator],[NumberOfItems],[TotalCIFFOBValue],[TotalGSTTaxAmt],[TotalExDutyAmt],[TotalCusDutyAmt],[TotalODutyAmt],[TotalAmtPay],'NEW' as [Status],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime],[PermitNumber],'AMD' as [prmtStatus] from OutHeaderTbl where [PermitId] = '" + PermitId + "'  ";
                                */

                                string invoice = "insert into OutInvoiceDtl ([SNo],[InvoiceNo],[InvoiceDate],[TermType],[AdValoremIndicator],[PreDutyRateIndicator],[SupplierImporterRelationship],[SupplierCode],[ExportPartyCode],[TICurrency],[TIExRate],[TIAmount] ,[TISAmount],[OTCCharge],[OTCCurrency],[OTCExRate],[OTCAmount],[OTCSAmount],[FCCharge],[FCCurrency],[FCExRate],[FCAmount],[FCSAmount],[ICCharge],[ICCurrency],[ICExRate],[ICAmount],[ICSAmount],[CIFSUMAmount],[GSTPercentage],[GSTSUMAmount],[MessageType],[PermitId],[TouchUser],[TouchTime]  )";
                                invoice = invoice + " select [SNo],[InvoiceNo],[InvoiceDate],[TermType],[AdValoremIndicator],[PreDutyRateIndicator],[SupplierImporterRelationship],[SupplierCode],[ExportPartyCode],[TICurrency],[TIExRate],[TIAmount] ,[TISAmount],[OTCCharge],[OTCCurrency],[OTCExRate],[OTCAmount],[OTCSAmount],[FCCharge],[FCCurrency],[FCExRate],[FCAmount],[FCSAmount],[ICCharge],[ICCurrency],[ICExRate],[ICAmount],[ICSAmount],[CIFSUMAmount],[GSTPercentage],[GSTSUMAmount],[MessageType],'" + PermitNo + "' as [PermitId],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime]  from OutInvoiceDtl where [PermitId] = '" + PermitId + "'  ";


                                string item = "insert into OutItemDtl ([ItemNo],[PermitId]  ,[MessageType],[HSCode] ,[Description],[DGIndicator],[Contry],[EndUserDescription],[Brand],[Model],[InHAWBOBL],[OutHAWBOBL],[DutiableQty],[DutiableUOM],[TotalDutiableQty],[TotalDutiableUOM],[InvoiceQuantity],[HSQty],[HSUOM],[AlcoholPer],[InvoiceNo],[ChkUnitPrice],[UnitPrice],[UnitPriceCurrency],[ExchangeRate],[SumExchangeRate],[TotalLineAmount],[InvoiceCharges] ,[CIFFOB],[OPQty],[OPUOM],[IPQty],[IPUOM],[InPqty],[InPUOM],[ImPQty],[ImPUOM],[PreferentialCode],[GSTRate],[GSTUOM],[GSTAmount],[ExciseDutyRate],[ExciseDutyUOM],[ExciseDutyAmount],[CustomsDutyRate],[CustomsDutyUOM],[CustomsDutyAmount],[OtherTaxRate],[OtherTaxUOM],[OtherTaxAmount],[CurrentLot],[PreviousLot],[Making],[ShippingMarks1],[ShippingMarks2],[ShippingMarks3],[ShippingMarks4],[CerItemQty],[CerItemUOM],[CIFValOfCer],[ManufactureCostDate],[TexCat],[TexQuotaQty],[TexQuotaUOM],[CerInvNo],[CerInvDate],[OriginOfCer],[HSCodeCer],[PerContent] ,[CertificateDescription],[TouchUser],[TouchTime] )";
                                item = item + " select  [ItemNo],'" + PermitNo + "' AS [PermitId]  ,[MessageType],[HSCode] ,[Description],[DGIndicator],[Contry],[EndUserDescription],[Brand],[Model],[InHAWBOBL],[OutHAWBOBL],[DutiableQty],[DutiableUOM],[TotalDutiableQty],[TotalDutiableUOM],[InvoiceQuantity],[HSQty],[HSUOM],[AlcoholPer],[InvoiceNo],[ChkUnitPrice],[UnitPrice],[UnitPriceCurrency],[ExchangeRate],[SumExchangeRate],[TotalLineAmount],[InvoiceCharges] ,[CIFFOB],[OPQty],[OPUOM],[IPQty],[IPUOM],[InPqty],[InPUOM],[ImPQty],[ImPUOM],[PreferentialCode],[GSTRate],[GSTUOM],[GSTAmount],[ExciseDutyRate],[ExciseDutyUOM],[ExciseDutyAmount],[CustomsDutyRate],[CustomsDutyUOM],[CustomsDutyAmount],[OtherTaxRate],[OtherTaxUOM],[OtherTaxAmount],[CurrentLot],[PreviousLot],[Making],[ShippingMarks1],[ShippingMarks2],[ShippingMarks3],[ShippingMarks4],[CerItemQty],[CerItemUOM],[CIFValOfCer],[ManufactureCostDate],[TexCat],[TexQuotaQty],[TexQuotaUOM],[CerInvNo],[CerInvDate],[OriginOfCer],[HSCodeCer],[PerContent] ,[CertificateDescription],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime]  from OutItemDtl where [PermitId] = '" + PermitId + "' ";


                                string container = "insert into OutContainerDtl ([PermitId],[RowNo],[ContainerNo],[Size],[Weight],[SealNo],[MessageType],[TouchUser],[TouchTime])";
                                container = container + " select  '" + PermitNo + "' as [PermitId],[RowNo],[ContainerNo],[Size],[Weight],[SealNo],[MessageType],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime]  from OutContainerDtl where [PermitId] = '" + PermitId + "'  ";


                                string CPCDtl = "insert into OutCPCDtl ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])";
                                CPCDtl = CPCDtl + " select  '" + PermitNo + "' as [PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime]  from OutCPCDtl where [PermitId] = '" + PermitId + "'  ";


                                string CASCDtl = "insert into OutCASCDtl ([ItemNo],[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime],[CASCId],EndUserDes)";
                                CASCDtl = CASCDtl + "  select  [ItemNo],[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],'" + PermitNo + "' as [PermitId],[MessageType],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime],[CASCId],EndUserDes  from OutCASCDtl where [PermitId] = '" + PermitId + "'  ";


                                string file = "insert into OutFile ([Name],[ContentType],[Data],[DocumentType],[InPaymentId],[TouchUser],[TouchTime] )";
                                file = file + "select  [Name],[ContentType],[Data],[DocumentType],'" + PermitNo + "' as [InPaymentId],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime]  from OutFile where [InPaymentId] = '" + PermitId + "' ";

                                // string PerCount = ("INSERT INTO [dbo].[PermitCount] ([PermitId],[MessageType],[AccountId],[TouchUser],[TouchTime])  VALUES ('" + PermitNo + "','OUTDEC','" + Session["AccountId"].ToString() + "','" + Touch_user + "','" + strTime + "')");
                                string PerCount = ("INSERT INTO [dbo].[PermitCount] ([PermitId],[MessageType],[AccountId],[MsgId],[TouchUser],[TouchTime])  VALUES ('" + PermitNo + "','OUTDEC','" + Session["AccountId"].ToString() + "','" + MsgNO + "','" + Touch_user + "','" + strTime + "')");
                                obj.exec(headertbl);
                                obj.exec(invoice);
                                obj.exec(item);
                                obj.exec(container);
                                obj.exec(CPCDtl);
                                obj.exec(CASCDtl);
                                obj.exec(file);
                                obj.exec(PerCount);

                                obj.closecon();



                                BindInPayment();
                                string strBindTxtBox = "select * from OutHeaderTbl where PermitId='" + PermitNo + "'";
                                obj.dr = obj.ret_dr(strBindTxtBox);
                                while (obj.dr.Read())
                                {
                                    string idpass = obj.dr["ID"].ToString();
                                    //Response.Redirect("Out.aspx?ID=" + idpass);
                                    Response.Redirect("Out.aspx?Id=" + idpass + "&Update=" + Drppermitedit.SelectedItem.ToString() + "");

                                }
                                // }
                            }

                        }
                        else if (Drppermitedit.SelectedItem.ToString() == "CANCEL")
                        {
                            //foreach (GridViewRow gvrow in GridInPayment.Rows)
                            //{
                            var checkbox = gvrow.FindControl("CheckBox1") as CheckBox;
                            if (checkbox.Checked)
                            {
                                Label ID1 = (Label)gvrow.FindControl("lblPermitNo");
                                PermitId = ID1.Text;
                                PermitNO();
                                JobNO();
                                refid();
                                MSGNO();
                                string Touch_user = Session["UserId"].ToString();
                                string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                string permitnumber = "";
                                MyClass lod12 = new MyClass();
                                lod12.dr = lod12.ret_dr("select PermitNumber from OutHeaderTbl where PermitId='" + PermitId + "'");
                                if (lod12.dr.HasRows)
                                {
                                    while (lod12.dr.Read())
                                    {
                                        permitnumber = lod12.dr["PermitNumber"].ToString();
                                    }
                                }

                                string headertbl = "insert into OutHeaderTbl ([Refid],[JobId],[MSGId],[PermitId],[TradeNetMailboxID],[MessageType],[DeclarationType],[PreviousPermit],[CargoPackType],[InwardTransportMode],[OutwardTransportMode],[BGIndicator],[SupplyIndicator],[ReferenceDocuments],[License],[COType],[Entryyear],[GSPDonorCountry],[CerDetailtype1],[CerDetailCopies1],[CerDetailtype2],[CerDetailCopies2],[PerCommon],[CurrencyCode],[AddCerDtl],[TransDtl],[Recipient],[DeclarantCompanyCode],[ExporterCompanyCode],[Inwardcarriercode],[OutwardCarrierAgentCode],[FreightForwarderCode],[ImporterCompanyCode],[InwardCarrierAgentCode],[CONSIGNEECode],[EndUserCode],[Manufacturer],[ArrivalDate],[ArrivalTime],[LoadingPortCode],[VoyageNumber],[VesselName],[OceanBillofLadingNo],[ConveyanceRefNo],[TransportId],[FlightNO],[AircraftRegNo],[MasterAirwayBill],[ReleaseLocation],[ResLoaName],[RecepitLocation],[RepLocName],[StorageLocation],[BlanketStartDate],[DepartureDate],[DepartureTime],[DischargePort],[FinalDestinationCountry],[OutVoyageNumber],[OutVesselName],[OutOceanBillofLadingNo],[VesselType],[VesselNetRegTon],[VesselNationality] ,[TowingVesselID],[TowingVesselName],[NextPort],[LastPort],[OutConveyanceRefNo],[OutTransportId],[OutFlightNO],[OutAircraftRegNo],[OutMasterAirwayBill],[TotalOuterPack],[TotalOuterPackUOM],[TotalGrossWeight],[TotalGrossWeightUOM],[GrossReference],[TradeRemarks],[InternalRemarks],[DeclareIndicator],[NumberOfItems],[TotalCIFFOBValue],[TotalGSTTaxAmt],[TotalExDutyAmt],[TotalCusDutyAmt],[TotalODutyAmt],[TotalAmtPay],[Status],[TouchUser],[TouchTime],[PermitNumber],[prmtStatus])";
                                headertbl = headertbl + "  select  '" + refno + "' as Refid,'" + JobNo + "' as JobId ,'" + MsgNO + "' as MSGID,'" + PermitNo + "' as PermitId,[TradeNetMailboxID],[MessageType],[DeclarationType],[PreviousPermit],[CargoPackType],[InwardTransportMode],[OutwardTransportMode],[BGIndicator],[SupplyIndicator],[ReferenceDocuments],[License],[COType],[Entryyear],[GSPDonorCountry],[CerDetailtype1],[CerDetailCopies1],[CerDetailtype2],[CerDetailCopies2],[PerCommon],[CurrencyCode],[AddCerDtl],[TransDtl],[Recipient],[DeclarantCompanyCode],[ExporterCompanyCode],[Inwardcarriercode],[OutwardCarrierAgentCode],[FreightForwarderCode],[ImporterCompanyCode],[InwardCarrierAgentCode],[CONSIGNEECode],[EndUserCode],[Manufacturer],[ArrivalDate],[ArrivalTime],[LoadingPortCode],[VoyageNumber],[VesselName],[OceanBillofLadingNo],[ConveyanceRefNo],[TransportId],[FlightNO],[AircraftRegNo],[MasterAirwayBill],[ReleaseLocation],[ResLoaName],[RecepitLocation],[RepLocName],[StorageLocation],[BlanketStartDate],[DepartureDate],[DepartureTime],[DischargePort],[FinalDestinationCountry],[OutVoyageNumber],[OutVesselName],[OutOceanBillofLadingNo],[VesselType],[VesselNetRegTon],[VesselNationality] ,[TowingVesselID],[TowingVesselName],[NextPort],[LastPort],[OutConveyanceRefNo],[OutTransportId],[OutFlightNO],[OutAircraftRegNo],[OutMasterAirwayBill],[TotalOuterPack],[TotalOuterPackUOM],[TotalGrossWeight],[TotalGrossWeightUOM],[GrossReference],[TradeRemarks],[InternalRemarks],[DeclareIndicator],[NumberOfItems],[TotalCIFFOBValue],[TotalGSTTaxAmt],[TotalExDutyAmt],[TotalCusDutyAmt],[TotalODutyAmt],[TotalAmtPay],'NEW' as [Status],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime],'"+permitnumber+"' as [PermitNumber],'CNL' as [prmtStatus] from OutHeaderTbl where [PermitId] = '" + PermitId + "'  ";


                                string invoice = "insert into OutInvoiceDtl ([SNo],[InvoiceNo],[InvoiceDate],[TermType],[AdValoremIndicator],[PreDutyRateIndicator],[SupplierImporterRelationship],[SupplierCode],[ExportPartyCode],[TICurrency],[TIExRate],[TIAmount] ,[TISAmount],[OTCCharge],[OTCCurrency],[OTCExRate],[OTCAmount],[OTCSAmount],[FCCharge],[FCCurrency],[FCExRate],[FCAmount],[FCSAmount],[ICCharge],[ICCurrency],[ICExRate],[ICAmount],[ICSAmount],[CIFSUMAmount],[GSTPercentage],[GSTSUMAmount],[MessageType],[PermitId],[TouchUser],[TouchTime]  )";
                                invoice = invoice + " select [SNo],[InvoiceNo],[InvoiceDate],[TermType],[AdValoremIndicator],[PreDutyRateIndicator],[SupplierImporterRelationship],[SupplierCode],[ExportPartyCode],[TICurrency],[TIExRate],[TIAmount] ,[TISAmount],[OTCCharge],[OTCCurrency],[OTCExRate],[OTCAmount],[OTCSAmount],[FCCharge],[FCCurrency],[FCExRate],[FCAmount],[FCSAmount],[ICCharge],[ICCurrency],[ICExRate],[ICAmount],[ICSAmount],[CIFSUMAmount],[GSTPercentage],[GSTSUMAmount],[MessageType],'" + PermitNo + "' as [PermitId],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime]  from OutInvoiceDtl where [PermitId] = '" + PermitId + "'  ";


                                string item = "insert into OutItemDtl ([ItemNo],[PermitId]  ,[MessageType],[HSCode] ,[Description],[DGIndicator],[Contry],[EndUserDescription],[Brand],[Model],[InHAWBOBL],[OutHAWBOBL],[DutiableQty],[DutiableUOM],[TotalDutiableQty],[TotalDutiableUOM],[InvoiceQuantity],[HSQty],[HSUOM],[AlcoholPer],[InvoiceNo],[ChkUnitPrice],[UnitPrice],[UnitPriceCurrency],[ExchangeRate],[SumExchangeRate],[TotalLineAmount],[InvoiceCharges] ,[CIFFOB],[OPQty],[OPUOM],[IPQty],[IPUOM],[InPqty],[InPUOM],[ImPQty],[ImPUOM],[PreferentialCode],[GSTRate],[GSTUOM],[GSTAmount],[ExciseDutyRate],[ExciseDutyUOM],[ExciseDutyAmount],[CustomsDutyRate],[CustomsDutyUOM],[CustomsDutyAmount],[OtherTaxRate],[OtherTaxUOM],[OtherTaxAmount],[CurrentLot],[PreviousLot],[Making],[ShippingMarks1],[ShippingMarks2],[ShippingMarks3],[ShippingMarks4],[CerItemQty],[CerItemUOM],[CIFValOfCer],[ManufactureCostDate],[TexCat],[TexQuotaQty],[TexQuotaUOM],[CerInvNo],[CerInvDate],[OriginOfCer],[HSCodeCer],[PerContent] ,[CertificateDescription],[TouchUser],[TouchTime] )";
                                item = item + " select  [ItemNo],'" + PermitNo + "' AS [PermitId]  ,[MessageType],[HSCode] ,[Description],[DGIndicator],[Contry],[EndUserDescription],[Brand],[Model],[InHAWBOBL],[OutHAWBOBL],[DutiableQty],[DutiableUOM],[TotalDutiableQty],[TotalDutiableUOM],[InvoiceQuantity],[HSQty],[HSUOM],[AlcoholPer],[InvoiceNo],[ChkUnitPrice],[UnitPrice],[UnitPriceCurrency],[ExchangeRate],[SumExchangeRate],[TotalLineAmount],[InvoiceCharges] ,[CIFFOB],[OPQty],[OPUOM],[IPQty],[IPUOM],[InPqty],[InPUOM],[ImPQty],[ImPUOM],[PreferentialCode],[GSTRate],[GSTUOM],[GSTAmount],[ExciseDutyRate],[ExciseDutyUOM],[ExciseDutyAmount],[CustomsDutyRate],[CustomsDutyUOM],[CustomsDutyAmount],[OtherTaxRate],[OtherTaxUOM],[OtherTaxAmount],[CurrentLot],[PreviousLot],[Making],[ShippingMarks1],[ShippingMarks2],[ShippingMarks3],[ShippingMarks4],[CerItemQty],[CerItemUOM],[CIFValOfCer],[ManufactureCostDate],[TexCat],[TexQuotaQty],[TexQuotaUOM],[CerInvNo],[CerInvDate],[OriginOfCer],[HSCodeCer],[PerContent] ,[CertificateDescription],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime]  from OutItemDtl where [PermitId] = '" + PermitId + "' ";


                                string container = "insert into OutContainerDtl ([PermitId],[RowNo],[ContainerNo],[Size],[Weight],[SealNo],[MessageType],[TouchUser],[TouchTime])";
                                container = container + " select  '" + PermitNo + "' as [PermitId],[RowNo],[ContainerNo],[Size],[Weight],[SealNo],[MessageType],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime]  from OutContainerDtl where [PermitId] = '" + PermitId + "'  ";


                                string CPCDtl = "insert into OutCPCDtl ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])";
                                CPCDtl = CPCDtl + " select  '" + PermitNo + "' as [PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime]  from OutCPCDtl where [PermitId] = '" + PermitId + "'  ";


                                string CASCDtl = "insert into OutCASCDtl ([ItemNo],[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime],[CASCId],EndUserDes)";
                                CASCDtl = CASCDtl + "  select  [ItemNo],[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],'" + PermitNo + "' as [PermitId],[MessageType],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime],[CASCId],EndUserDes  from OutCASCDtl where [PermitId] = '" + PermitId + "'  ";


                                string file = "insert into OutFile ([Name],[ContentType],[Data],[DocumentType],[InPaymentId],[TouchUser],[TouchTime] )";
                                file = file + "select  [Name],[ContentType],[Data],[DocumentType],'" + PermitNo + "' as [InPaymentId],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime]  from OutFile where [InPaymentId] = '" + PermitId + "' ";

                                // string PerCount = ("INSERT INTO [dbo].[PermitCount] ([PermitId],[MessageType],[AccountId],[TouchUser],[TouchTime])  VALUES ('" + PermitNo + "','OUTDEC','" + Session["AccountId"].ToString() + "','" + Touch_user + "','" + strTime + "')");
                                string PerCount = ("INSERT INTO [dbo].[PermitCount] ([PermitId],[MessageType],[AccountId],[MsgId],[TouchUser],[TouchTime])  VALUES ('" + PermitNo + "','OUTDEC','" + Session["AccountId"].ToString() + "','" + MsgNO + "','" + Touch_user + "','" + strTime + "')");
                                obj.exec(headertbl);
                                obj.exec(invoice);
                                obj.exec(item);
                                obj.exec(container);
                                obj.exec(CPCDtl);
                                obj.exec(CASCDtl);
                                obj.exec(file);
                                obj.exec(PerCount);

                                obj.closecon();



                                BindInPayment();
                                string strBindTxtBox = "select * from OutHeaderTbl where PermitId='" + PermitNo + "'";
                                obj.dr = obj.ret_dr(strBindTxtBox);
                                while (obj.dr.Read())
                                {
                                    string idpass = obj.dr["ID"].ToString();
                                    //Response.Redirect("Out.aspx?ID=" + idpass);
                                    Response.Redirect("Out.aspx?Id=" + idpass + "&Update=" + Drppermitedit.SelectedItem.ToString() + "");

                                }
                            }
                            // }
                        }
                    }
                }
            }
        }


        private void colorchange()
        {
            foreach (GridViewRow gvrow in GridInPayment.Rows)
            {
                Label ID1 = (Label)gvrow.FindControl("lblStatus");
                if (!string.IsNullOrEmpty(ID1.Text))
                {
                    string ID = ID1.Text;
                    if (ID.ToUpper() == "NEW")
                    {
                        gvrow.ForeColor = Color.Blue;
                    }
                    else if (ID.ToUpper() == "APR")
                    {
                        gvrow.ForeColor = Color.YellowGreen;
                    }
                    else if (ID.ToUpper() == "ERR")
                    {
                        gvrow.ForeColor = Color.Red;
                    }
                    else if (ID.ToUpper() == "PEN")
                    {
                        gvrow.ForeColor = Color.BlueViolet;
                    }
                    else if (ID.ToUpper() == "REJ")
                    {
                        gvrow.ForeColor = Color.Brown;
                    }
                }
            }
        }


        private void LoadOUTDEC(string permit)
        {
            string tradeID = "";
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from OutHeaderTbl  where PermitId='" + permit + "'"))
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
                XElement Transport = null;
                XElement ModeCode = null;
                MSGNUMBER = dt.Rows[0]["MsgId"].ToString();
                XElement TransportMode = null;
                XElement TransportMeans = null;
                XElement InwardTransport = null;
                XElement OutVessalNaltional = null;
                XElement OutVessalReg = null;
                XElement OutVessalType = null;
              //  XElement OutAdditional = null;
                XElement BlanketStartDate = null;
                string[] DecType = null;
                XElement CerType1 = null;
                XElement SeqNum1 = null;
                XElement copNum = null;

                XElement CerType = null;
                XElement SeqNum = null;
                XElement CerDetail = null;
                XElement AppProductType = null;
                XElement EntryYear = null;
                XElement GSPDonr = null;
                //XElement TotalAmountPayable = new XElement(ns2 + "TotalAmountPayable", dt.Rows[0]["TotalAmtPay"].ToString());
                //XElement TotalOtherTaxAmount = new XElement(ns2 + "TotalOtherTaxAmount", dt.Rows[0]["TotalODutyAmt"].ToString());
                //XElement TotalCustomsDutyAmount = new XElement(ns2 + "TotalCustomsDutyAmount", dt.Rows[0]["TotalCusDutyAmt"].ToString());
                //XElement TotalExciseDutyAmount = new XElement(ns2 + "TotalExciseDutyAmount", dt.Rows[0]["TotalExDutyAmt"].ToString());
                //XElement TotalGoodsAndServicesTaxAmount = new XElement(ns2 + "TotalGoodsAndServicesTaxAmount", dt.Rows[0]["TotalGSTTaxAmt"].ToString());
                //XElement TotalTariff = new XElement(ns3 + "TotalTariff", "");
                //if (Convert.ToDecimal(dt.Rows[0]["TotalGSTTaxAmt"].ToString()) > 0)
                //{
                //    TotalTariff.Add(TotalGoodsAndServicesTaxAmount);
                //}
                //if (Convert.ToDecimal(dt.Rows[0]["TotalExDutyAmt"].ToString()) > 0)
                //{
                //    TotalTariff.Add(TotalExciseDutyAmount);
                //}
                //if (Convert.ToDecimal(dt.Rows[0]["TotalCusDutyAmt"].ToString()) > 0)
                //{
                //    TotalTariff.Add(TotalCustomsDutyAmount);
                //}
                //if (Convert.ToDecimal(dt.Rows[0]["TotalODutyAmt"].ToString()) > 0)
                //{
                //    TotalTariff.Add(TotalOtherTaxAmount);
                //}
                //if (Convert.ToDecimal(dt.Rows[0]["TotalAmtPay"].ToString()) > 0)
                //{
                //    TotalTariff.Add(TotalAmountPayable);
                //}


                decimal TtlPGW = 0;
                if (dt.Rows[0]["TotalGrossWeightUOM"].ToString() == "KGM")
                {
                    TtlPGW = Convert.ToDecimal(dt.Rows[0]["TotalGrossWeight"].ToString());
                }
                else
                {
                    TtlPGW = Convert.ToDecimal(dt.Rows[0]["TotalGrossWeight"].ToString()) / Convert.ToDecimal(1000);
                }
                string strtest2 = Math.Round(Convert.ToDecimal(TtlPGW), 3).ToString("0.000");

                XElement TotalGrossWeight = new XElement(ns2 + "TotalGrossWeight", strtest2.ToUpper());


                //XElement TotalGrossWeight = new XElement(ns2 + "TotalGrossWeight", dt.Rows[0]["TotalGrossWeight"].ToString().ToUpper());


                TotalGrossWeight.Add(new XAttribute("unitCode", dt.Rows[0]["TotalGrossWeightUOM"].ToString().ToUpper()));
                XElement TotalOuterPack = new XElement(ns2 + "TotalOuterPack", dt.Rows[0]["TotalOuterPack"].ToString().ToUpper());
                TotalOuterPack.Add(new XAttribute("unitCode", dt.Rows[0]["TotalOuterPackUOM"].ToString().ToUpper()));
                XElement TotalCIFFOBValue = new XElement(ns2 + "TotalCIFFOBValue", dt.Rows[0]["TotalCIFFOBValue"].ToString().ToUpper());
                //  string NoItem = Math.Round(Convert.ToDecimal(obj.dr["GSTRate"].ToString()), 0).ToString();

                XElement NumberOfItems = new XElement(ns2 + "NumberOfItems", Math.Round(Convert.ToDecimal(dt.Rows[0]["NumberOfItems"].ToString().ToUpper()), 0));
                XElement Summary = new XElement(ns6 + "Summary");
                if (Convert.ToDecimal(dt.Rows[0]["NumberOfItems"].ToString()) > 0)
                {
                    Summary.Add(NumberOfItems);
                }
                if (Convert.ToDecimal(dt.Rows[0]["TotalCIFFOBValue"].ToString()) > 0)
                {
                    Summary.Add(TotalCIFFOBValue);
                }
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["TotalOuterPackUOM"].ToString()))
                {
                    if (dt.Rows[0]["TotalOuterPackUOM"].ToString() != "--Select--")
                    {
                        Summary.Add(TotalOuterPack);
                    }
                }
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["TotalGrossWeightUOM"].ToString()))
                {
                    if (dt.Rows[0]["TotalGrossWeightUOM"].ToString() != "--Select--")
                    {
                        Summary.Add(TotalGrossWeight);
                    }
                }
                //if (Convert.ToDecimal(dt.Rows[0]["TotalGSTTaxAmt"].ToString()) > 0)
                //{
                //    Summary.Add(TotalTariff);
                //}
                //Summary
                XElement Item = null;
                

                //Item
                //XElement InvoiceName = new XElement(ns3 + "Invoice", "");
                //string invQury = "select * from dbo.InvoiceDtl where PermitId='" + dt.Rows[0]["PermitId"].ToString() + "'";
                //obj.dr = obj.ret_dr(invQury);
                //if (obj.dr.HasRows)
                //{
                //    while (obj.dr.Read())
                //    {
                //        XElement ChargePercent3 = new XElement(ns2 + "ChargePercent", obj.dr["OTCCharge"].ToString());
                //        XElement ExchangeRate3 = new XElement(ns2 + "ExchangeRate", obj.dr["OTCExRate"].ToString());
                //        XElement Amount3 = new XElement(ns2 + "Amount", obj.dr["OTCAmount"].ToString());
                //        string Othercurny = "";
                //        if (obj.dr["OTCCurrency"].ToString() == "--Select--")
                //        {
                //            Othercurny = "";
                //        }
                //        else
                //        {
                //            Othercurny = obj.dr["OTCCurrency"].ToString();
                //        }
                //        Amount3.Add(new XAttribute("currencyID", Othercurny));
                //        XElement OtherTaxableCharge = new XElement(ns3 + "OtherTaxableCharge", "");
                //        XElement ChargePercent2 = new XElement(ns2 + "ChargePercent", obj.dr["ICCharge"].ToString());
                //        XElement ExchangeRate2 = new XElement(ns2 + "ExchangeRate", obj.dr["ICExRate"].ToString());
                //        XElement Amount2 = new XElement(ns2 + "Amount", obj.dr["ICAmount"].ToString());
                //        string Incucurny = "";
                //        if (obj.dr["ICCurrency"].ToString() == "--Select--")
                //        {
                //            Incucurny = "";
                //        }
                //        else
                //        {
                //            Incucurny = obj.dr["ICCurrency"].ToString();
                //        }
                //        Amount2.Add(new XAttribute("currencyID", Incucurny));
                //        XElement InsuranceCharge = new XElement(ns3 + "InsuranceCharge", "");
                //        XElement ChargePercent = new XElement(ns2 + "ChargePercent", obj.dr["FCCharge"].ToString());
                //        XElement ExchangeRate1 = new XElement(ns2 + "ExchangeRate", obj.dr["FCExRate"].ToString());
                //        XElement Amount1 = new XElement(ns2 + "Amount", obj.dr["FCAmount"].ToString());
                //        string frgtcurny = "";
                //        if (obj.dr["FCCurrency"].ToString() == "--Select--")
                //        {
                //            frgtcurny = "";
                //        }
                //        else
                //        {
                //            frgtcurny = obj.dr["FCCurrency"].ToString();
                //        }
                //        Amount1.Add(new XAttribute("currencyID", frgtcurny));
                //        XElement FreightCharge = new XElement(ns3 + "FreightCharge", "");
                //        XElement ExchangeRate = new XElement(ns2 + "ExchangeRate", obj.dr["TIExRate"].ToString());
                //        XElement Amount = new XElement(ns2 + "Amount", obj.dr["TIAmount"].ToString());
                //        Amount.Add(new XAttribute("currencyID", obj.dr["TICurrency"].ToString()));
                //        XElement TotalInvoiceValue = new XElement(ns3 + "TotalInvoiceValue", "");
                //        string[] termtype = obj.dr["TermType"].ToString().Split(':');
                //        XElement UnitPriceTermType = new XElement(ns2 + "UnitPriceTermType", termtype[0].ToString().Substring(0, termtype[0].Length - 1));
                //        string Suppqury = "select CRUEI,Name from dbo.SUPPLIERMANUFACTURERPARTY where Code='" + obj.dr["SupplierCode"].ToString() + "'";
                //        string SuppName = "", Suppid = "";
                //        MyClass obj1 = new MyClass();
                //        obj1.dr = obj1.ret_dr(Suppqury);
                //        while (obj1.dr.Read())
                //        {
                //            // CPC.Add(obj.dr[0].ToString());
                //            SuppName = obj1.dr["Name"].ToString();
                //            Suppid = obj1.dr["CRUEI"].ToString();
                //        }
                //        XElement InvName = new XElement(ns2 + "Name", SuppName);
                //        XElement InvCodeValue = new XElement(ns2 + "CodeValue", Suppid);
                //        XElement SupplierManufacturerParty = new XElement(ns3 + "SupplierManufacturerParty", "");
                //        XElement InvoiceDate = new XElement(ns2 + "InvoiceDate", Convert.ToDateTime(obj.dr["InvoiceDate"].ToString()).ToString("yyyyMMdd"));
                //        XElement InvoiceNumber = new XElement(ns2 + "InvoiceNumber", obj.dr["InvoiceNo"].ToString());
                //        if (!string.IsNullOrWhiteSpace(obj.dr["InvoiceNo"].ToString()))
                //        {
                //            InvoiceName.Add(InvoiceNumber);
                //        }
                //        if (!string.IsNullOrWhiteSpace(obj.dr["InvoiceDate"].ToString()))
                //        {
                //            InvoiceName.Add(InvoiceDate);
                //        }
                //        if (!string.IsNullOrWhiteSpace(Suppid))
                //        {
                //            InvoiceName.Add(SupplierManufacturerParty);
                //            SupplierManufacturerParty.Add(InvCodeValue);
                //            SupplierManufacturerParty.Add(InvName);
                //        }
                //        if (!string.IsNullOrWhiteSpace(termtype[0].ToString().Substring(0, termtype[0].Length - 1)))
                //        {
                //            InvoiceName.Add(UnitPriceTermType);
                //        }
                //        if (!string.IsNullOrWhiteSpace(obj.dr["TICurrency"].ToString()))
                //        {
                //            if (obj.dr["TICurrency"].ToString() != "--Select--")
                //            {
                //                InvoiceName.Add(TotalInvoiceValue);
                //                TotalInvoiceValue.Add(Amount);
                //                TotalInvoiceValue.Add(ExchangeRate);
                //            }
                //        }
                //        if (!string.IsNullOrWhiteSpace(frgtcurny))
                //        {
                //            InvoiceName.Add(FreightCharge);
                //            FreightCharge.Add(Amount1);
                //            FreightCharge.Add(ExchangeRate1);
                //            FreightCharge.Add(ChargePercent);
                //        }
                //        if (!string.IsNullOrWhiteSpace(Incucurny))
                //        {
                //            InvoiceName.Add(InsuranceCharge);
                //            InsuranceCharge.Add(Amount2);
                //            InsuranceCharge.Add(ExchangeRate2);
                //            InsuranceCharge.Add(ChargePercent2);
                //        }
                //        if (!string.IsNullOrWhiteSpace(Othercurny))
                //        {
                //            InvoiceName.Add(OtherTaxableCharge);
                //            OtherTaxableCharge.Add(Amount3);
                //            OtherTaxableCharge.Add(ExchangeRate3);
                //            OtherTaxableCharge.Add(ChargePercent3);
                //        }
                //    }
                //}EngineCapacity

                string SupFile = "";
                XElement SupportingDocumentReference = new XElement(ns3 + "SupportingDocumentReference", "");
                string infilname = "select * from OutFile where InPaymentId='" + dt.Rows[0]["PermitId"].ToString() + "'";
                obj.dr = obj.ret_dr(infilname);
                while (obj.dr.Read())
                {
                    XElement Filename = new XElement(ns2 + "Filename", obj.dr["Name"].ToString().ToUpper());
                    string[] docuID = obj.dr["DocumentType"].ToString().Split(':');
                    XElement DocumentID = new XElement(ns2 + "DocumentID", docuID[0].ToString().Substring(0, docuID[0].Length - 1).ToUpper());
                    SupFile = docuID[0].ToString().Substring(0, docuID[0].Length - 1);
                    SupportingDocumentReference.Add(DocumentID);
                    SupportingDocumentReference.Add(Filename);
                }
                string licNo = "";
                XElement Licence = new XElement(ns3 + "Licence", "");
                string[] refid = dt.Rows[0]["License"].ToString().Split('-');
                for (int ri = 0; ri < refid.Length; ri++)
                {
                    if (!string.IsNullOrWhiteSpace(refid[ri].ToString()))
                    {
                        licNo = refid[0].ToString();
                        XElement Referenceid = new XElement(ns2 + "ReferenceID", refid[ri].ToString().ToUpper());
                        Licence.Add(Referenceid);
                    }
                }
                //string clamtparty = "select CRUEI,Name,ClaimantName1,ClaimantName from dbo.ClaimantParty where Name='" + dt.Rows[0]["ClaimantPartyCode"].ToString() + "'";
                //string clamtpartyuName = "", clamtuei = "", clatinfocode = "", clatinfoname = "";
                //obj.dr = obj.ret_dr(clamtparty);
                //while (obj.dr.Read())
                //{
                //    // CPC.Add(obj.dr[0].ToString());
                //    clamtpartyuName = obj.dr["Name"].ToString();
                //    clamtuei = obj.dr["CRUEI"].ToString();
                //    clatinfocode = obj.dr["ClaimantName1"].ToString();
                //    clatinfoname = obj.dr["ClaimantName"].ToString();
                //}
                //XElement LicName = new XElement(ns2 + "Name", clatinfoname);
                //XElement LicCodeValue = new XElement(ns2 + "CodeValue", clatinfocode);
                //XElement ClaimantInformation = new XElement(ns3 + "ClaimantInformation", "");
                //XElement ClainmentInfoName = new XElement(ns2 + "Name", clamtpartyuName);
                //XElement ClainmentInfoPartyName = new XElement(ns3 + "PartyName", "");
                //XElement ClainmentInfoID = new XElement(ns2 + "ID", clamtuei);
                //XElement ClainmentPartyIdentification = new XElement(ns3 + "PartyIdentification", "");
                //XElement PartyDetail = new XElement(ns3 + "PartyDetail", "");
                //XElement ClaimantParty = new XElement(ns3 + "ClaimantParty", "");
                //ClaimantParty.Add(PartyDetail);
                //PartyDetail.Add(ClainmentPartyIdentification);
                //ClainmentPartyIdentification.Add(ClainmentInfoID);
                //PartyDetail.Add(ClainmentInfoPartyName);
                //ClainmentInfoPartyName.Add(ClainmentInfoName);
                //if (!string.IsNullOrWhiteSpace(clatinfocode))
                //{
                //    ClaimantParty.Add(ClaimantInformation);
                //    ClaimantInformation.Add(LicCodeValue);
                //    ClaimantInformation.Add(LicName);
                //}

                string ManufactStr = "select * from OutManufacturer where ManufacturerCode='" + dt.Rows[0]["Manufacturer"].ToString() + "'";
                string ManufactID = "", ManufactName = "", ManufactAddre = "", ManufactCity = "", ManufactCountrySubCode = "", ManufactCountrySub = "", ManufactCountryCode = "", ManufactPostalCde = "";
                obj.dr = obj.ret_dr(ManufactStr);
                while (obj.dr.Read())
                {
                    ManufactID = obj.dr["ManufacturerCRUEI"].ToString().ToUpper();
                    ManufactName = obj.dr["ManufacturerName"].ToString();
                    ManufactAddre = obj.dr["ManufacturerAddress"].ToString();
                    ManufactCity = obj.dr["ManufacturerCity"].ToString();
                    ManufactCountrySubCode = obj.dr["ManufacturerSubDivi"].ToString();
                    ManufactCountrySub = obj.dr["ManufacturerSub"].ToString();
                    ManufactCountryCode = obj.dr["ManufacturerCountry"].ToString();
                    ManufactPostalCde = obj.dr["ManufacturerPostal"].ToString();
                }
                XElement ManufactPartyCountry = new XElement(ns2 + "CountryCode", ManufactCountryCode.Trim().ToUpper());
                XElement ManufactPartypostCode = new XElement(ns2 + "PostalZone", ManufactPostalCde.ToUpper());
                XElement ManufactPartyCountrySub = new XElement(ns2 + "CountrySubentity", ManufactCountrySub.ToUpper());
                XElement ManufactPartyCountrySubCode = new XElement(ns2 + "CountrySubentityCode", ManufactCountrySubCode.ToUpper());
                XElement ManufactPartyCity = new XElement(ns2 + "CityName", ManufactCity.ToUpper());
                XElement ManufactPartyLine = new XElement(ns2 + "Line", ManufactAddre.ToUpper());
                XElement ManufactPartyAddLine = new XElement(ns3 + "AddressLine", "");
                XElement ManufactPartyAddre = new XElement(ns3 + "Address", "");
                if (!string.IsNullOrWhiteSpace(ManufactAddre))
                {
                    ManufactPartyAddLine.Add(ManufactPartyLine);
                }
                if (!string.IsNullOrWhiteSpace(ManufactAddre))
                {
                    ManufactPartyAddre.Add(ManufactPartyAddLine);
                }
                if (!string.IsNullOrWhiteSpace(ManufactCity))
                {
                    ManufactPartyAddre.Add(ManufactPartyCity);
                }
                if (!string.IsNullOrWhiteSpace(ManufactCountrySubCode))
                {
                    ManufactPartyAddre.Add(ManufactPartyCountrySubCode);
                }
                if (!string.IsNullOrWhiteSpace(ManufactCountrySub))
                {
                    ManufactPartyAddre.Add(ManufactPartyCountrySub);
                }
                if (!string.IsNullOrWhiteSpace(ManufactPostalCde))
                {
                    ManufactPartyAddre.Add(ManufactPartypostCode);
                }
                if (!string.IsNullOrWhiteSpace(ManufactCountryCode))
                {
                    ManufactPartyAddre.Add(ManufactPartyCountry);
                }


                XElement ManufactPartName1 = new XElement(ns2 + "Name", ManufactName.ToUpper());
                XElement ManufactPartyName = new XElement(ns3 + "PartyName", "");
                ManufactPartyName.Add(ManufactPartName1);
                XElement ManufactPartyID = new XElement(ns2 + "ID", ManufactID.ToUpper());
                XElement ManufactPartIdenti = new XElement(ns3 + "PartyIdentification", "");
                ManufactPartIdenti.Add(ManufactPartyID);
                XElement ManufactPartDetail = new XElement(ns3 + "PartyDetail", "");
                ManufactPartDetail.Add(ManufactPartIdenti);
                ManufactPartDetail.Add(ManufactPartyName);
                XElement ManufactParty = new XElement(ns3 + "ManufacturerParty", "");
                ManufactParty.Add(ManufactPartDetail);
                ManufactParty.Add(ManufactPartyAddre);

                string EndUserStr = "select * from OutEndUser where EndUserCode='" + dt.Rows[0]["EndUserCode"].ToString() + "'";
                string EndUserIDS = "", EndUserNameS = "", EndUserAddres = "", EndUserCityS = "", EndUserCountrySubCodeS = "", EndUserCountrySubS = "", EndUserCountryCodeS = "", EndUserPostalCdeS = "";
                obj.dr = obj.ret_dr(EndUserStr);
                while (obj.dr.Read())
                {
                    EndUserIDS = obj.dr["EndUserCode"].ToString().ToUpper();
                    EndUserNameS = obj.dr["EndUserName"].ToString().ToUpper();
                    EndUserAddres = obj.dr["EndUserAddress"].ToString().ToUpper();
                    EndUserCityS = obj.dr["EndUserCity"].ToString().ToUpper();
                    EndUserCountrySubCodeS = obj.dr["EndUserSubCode"].ToString().ToUpper();
                    EndUserCountrySubS = obj.dr["EndUserSub"].ToString().ToUpper();
                    EndUserCountryCodeS = obj.dr["EndUserCountry"].ToString().ToUpper();
                    EndUserPostalCdeS = obj.dr["EndUserPostal"].ToString().ToUpper();
                }
                XElement EndUserPartyCountry = new XElement(ns2 + "CountryCode", EndUserCountryCodeS.Trim().ToUpper());
                XElement EndUserPartypostCode = new XElement(ns2 + "PostalZone", EndUserPostalCdeS.ToUpper());
                XElement EndUserPartyCountrySub = new XElement(ns2 + "CountrySubentity", EndUserCountrySubS.ToUpper());
                XElement EndUserPartyCountrySubCode = new XElement(ns2 + "CountrySubentityCode", EndUserCountrySubCodeS.ToUpper());
                XElement EndUserPartyCity = new XElement(ns2 + "CityName", EndUserCityS.ToUpper());
                XElement EndUserPartyLine = new XElement(ns2 + "Line", EndUserAddres.ToUpper());
                XElement EndUserPartyAddLine = new XElement(ns3 + "AddressLine", "");
                XElement EndUserPartyAddre = new XElement(ns3 + "Address", "");
                if (!string.IsNullOrWhiteSpace(EndUserAddres))
                {
                    EndUserPartyAddLine.Add(EndUserPartyLine);
                }
                if (!string.IsNullOrWhiteSpace(EndUserAddres))
                {
                    EndUserPartyAddre.Add(EndUserPartyAddLine);
                }
                if (!string.IsNullOrWhiteSpace(EndUserCityS))
                {
                    EndUserPartyAddre.Add(EndUserPartyCity);
                }
                if (!string.IsNullOrWhiteSpace(EndUserCountrySubCodeS))
                {
                    EndUserPartyAddre.Add(EndUserPartyCountrySubCode);
                }
                if (!string.IsNullOrWhiteSpace(EndUserCountrySubS))
                {
                    EndUserPartyAddre.Add(EndUserPartyCountrySub);
                }
                if (!string.IsNullOrWhiteSpace(EndUserPostalCdeS))
                {
                    EndUserPartyAddre.Add(EndUserPartypostCode);
                }
                if (!string.IsNullOrWhiteSpace(EndUserCountryCodeS))
                {
                    EndUserPartyAddre.Add(EndUserPartyCountry);
                }

                XElement EndUserPartName = new XElement(ns2 + "Name", EndUserNameS);
                XElement EndUserPartyName = new XElement(ns3 + "PartyName", "");
                if (!string.IsNullOrWhiteSpace(EndUserNameS))
                {
                    EndUserPartyName.Add(EndUserPartName);
                }
                XElement EndUserParty = new XElement(ns3 + "EndUserParty", "");

                if (!string.IsNullOrWhiteSpace(EndUserNameS))
                {
                    EndUserParty.Add(EndUserPartyName);
                }
                if (!string.IsNullOrWhiteSpace(EndUserAddres))
                {
                    EndUserParty.Add(EndUserPartyAddre);
                }

                string ConsigneeStr = "select * from OutConsignee where ConsigneeCode='" + dt.Rows[0]["CONSIGNEECode"].ToString() + "'";
                string ConsignName = "", ConsignAddre = "", ConsignCity = "", ConsignCountrySubCode = "", ConsignCountrySub = "", ConsignCountryCode = "", ConsignPostalCde = "";
                obj.dr = obj.ret_dr(ConsigneeStr);
                while (obj.dr.Read())
                {
                    ConsignName = obj.dr["ConsigneeName"].ToString().ToUpper();
                    ConsignAddre = obj.dr["ConsigneeAddress"].ToString().ToUpper();
                    ConsignCity = obj.dr["ConsigneeCity"].ToString().ToUpper();
                    ConsignCountrySub = obj.dr["ConsigneeSub"].ToString().ToUpper();
                    ConsignPostalCde = obj.dr["ConsigneePostal"].ToString().ToUpper();
                    ConsignCountryCode = obj.dr["ConsigneeCountry"].ToString().ToUpper();
                }
                XElement ConsignPartyCountry = new XElement(ns2 + "CountryCode", ConsignCountryCode.Trim().ToUpper());
                XElement ConsignPartypostCode = new XElement(ns2 + "PostalZone", ConsignPostalCde);
                XElement ConsignPartyCountrySub = new XElement(ns2 + "CountrySubentity", ConsignCountrySub);
                XElement ConsignPartyCountrySubCode = new XElement(ns2 + "CountrySubentityCode", ConsignCountrySubCode);
                XElement ConsignPartyCity = new XElement(ns2 + "CityName", ConsignCity.ToUpper());
                XElement ConsignPartyLine = new XElement(ns2 + "Line", ConsignAddre.ToUpper());
                XElement ConsignPartyAddLine = new XElement(ns3 + "AddressLine", "");
                XElement ConsignPartyAddre = new XElement(ns3 + "Address", "");
                if (!string.IsNullOrWhiteSpace(ConsignAddre))
                {
                    ConsignPartyAddLine.Add(ConsignPartyLine);
                }
                if (!string.IsNullOrWhiteSpace(ConsignAddre))
                {
                    ConsignPartyAddre.Add(ConsignPartyAddLine);
                }
                if (!string.IsNullOrWhiteSpace(ConsignCity))
                {
                    ConsignPartyAddre.Add(ConsignPartyCity);
                }
                if (!string.IsNullOrWhiteSpace(ConsignCountrySubCode))
                {
                    ConsignPartyAddre.Add(ConsignPartyCountrySubCode);
                }
                if (!string.IsNullOrWhiteSpace(ConsignCountrySub))
                {
                    ConsignPartyAddre.Add(ConsignPartyCountrySub);
                }
                if (!string.IsNullOrWhiteSpace(ConsignPostalCde))
                {
                    ConsignPartyAddre.Add(ConsignPartypostCode);
                }
                if (!string.IsNullOrWhiteSpace(ConsignCountryCode))
                {
                    ConsignPartyAddre.Add(ConsignPartyCountry);
                }


                XElement ConsignPartName = new XElement(ns2 + "Name", ConsignName.ToUpper());
                XElement ConsignPartyName = new XElement(ns3 + "PartyName", "");
                ConsignPartyName.Add(ConsignPartName);
                XElement ConsignParty = new XElement(ns3 + "ConsigneeParty", "");
                if (!string.IsNullOrWhiteSpace(ConsignName))
                {
                    ConsignParty.Add(ConsignPartyName);
                }
                if (!string.IsNullOrWhiteSpace(ConsignAddre))
                {
                    ConsignParty.Add(ConsignPartyAddre);
                }


                string ExportStr = "select * from OutExporter where OutUserCode='" + dt.Rows[0]["ExporterCompanyCode"].ToString() + "'";
                string ExpID = "", ExpName = "", ExpName1 = "", Expadd1 = "", ExpAddre = "", ExpCity = "", ExpCountrySubCode = "", ExpCountrySub = "", ExpCountryCode = "", ExpPostalCde = "";
                obj.dr = obj.ret_dr(ExportStr);
                while (obj.dr.Read())
                {
                    ExpName = obj.dr["OutUserName"].ToString().ToUpper();
                    ExpName1 = obj.dr["OutUserName1"].ToString().ToUpper();
                    ExpID = obj.dr["OutUserCRUEI"].ToString().ToUpper();
                    ExpAddre = obj.dr["OutUserAddress"].ToString().ToUpper();
                    Expadd1 = obj.dr["OutUserAddress1"].ToString().ToUpper();
                    ExpCity = obj.dr["OutUserCity"].ToString().ToUpper();
                    ExpCountrySubCode = obj.dr["OutUserSubCode"].ToString().ToUpper();
                    ExpCountrySub = obj.dr["OutUserSub"].ToString().ToUpper();
                    ExpCountryCode = obj.dr["OutUserCountry"].ToString().ToUpper();
                    ExpPostalCde = obj.dr["OutUserPostal"].ToString().ToUpper();

                }
                XElement ExpPartyCountry = new XElement(ns2 + "CountryCode", ExpCountryCode.Trim().ToUpper());
                XElement ExpPartypostCode = new XElement(ns2 + "PostalZone", ExpPostalCde);
                XElement ExpPartyCountrySub = new XElement(ns2 + "CountrySubentity", ExpCountrySub);
                XElement ExpPartyCountrySubCode = new XElement(ns2 + "CountrySubentityCode", ExpCountrySubCode);
                XElement ExpPartyCity = new XElement(ns2 + "CityName", ExpCity.ToUpper());
                XElement ExpPartyLine = new XElement(ns2 + "Line", ExpAddre.ToUpper());
                XElement ExpPartyAddLine = new XElement(ns3 + "Addressline", "");
                XElement ExpPartyAddre = new XElement(ns3 + "Address", "");
                if (!string.IsNullOrWhiteSpace(ExpAddre))
                {
                    ExpPartyAddLine.Add(ExpPartyLine);
                }
                if (!string.IsNullOrWhiteSpace(ExpAddre))
                {
                    ExpPartyAddre.Add(ExpPartyAddLine);
                }
                if (!string.IsNullOrWhiteSpace(ExpCity))
                {
                    ExpPartyAddre.Add(ExpPartyCity);
                }
                if (!string.IsNullOrWhiteSpace(ExpCountrySubCode))
                {
                    ExpPartyAddre.Add(ExpPartyCountrySubCode);
                }
                if (!string.IsNullOrWhiteSpace(ExpCountrySub))
                {
                    ExpPartyAddre.Add(ExpPartyCountrySub);
                }
                if (!string.IsNullOrWhiteSpace(ExpPostalCde))
                {
                    ExpPartyAddre.Add(ExpPartypostCode);
                }
                if (!string.IsNullOrWhiteSpace(ExpCountryCode))
                {
                    ExpPartyAddre.Add(ExpPartyCountry);
                }
                XElement ExpPartName1 = new XElement(ns2 + "Name", ExpName1.ToUpper());
                XElement ExpPartName = new XElement(ns2 + "Name", ExpName.ToUpper());
                XElement ExpPartyName = new XElement(ns3 + "PartyName", "");

                ExpPartyName.Add(ExpPartName);
                if (!string.IsNullOrWhiteSpace(ExpName1))
                {
                    ExpPartyName.Add(ExpName1);
                }

                XElement ExpPartyID = new XElement(ns2 + "ID", ExpID.ToUpper());
                XElement ExpPartIdenti = new XElement(ns3 + "PartyIdentification", "");
                ExpPartIdenti.Add(ExpPartyID);
                XElement ExpPartDetail = new XElement(ns3 + "PartyDetail", "");
                ExpPartDetail.Add(ExpPartIdenti);
                ExpPartDetail.Add(ExpPartyName);
                XElement ExporterParty = new XElement(ns3 + "ExporterParty", "");
                ExporterParty.Add(ExpPartDetail);
                ExporterParty.Add(ExpPartyAddre);

                string Outwardparty = "select CRUEI,Name from dbo.OutwardCarrierAgent where Code='" + dt.Rows[0]["OutwardCarrierAgentCode"].ToString() + "'";
                string OutwardName = "", Outwardid = "";
                obj.dr = obj.ret_dr(Outwardparty);
                while (obj.dr.Read())
                {
                    // CPC.Add(obj.dr[0].ToString());
                    OutwardName = obj.dr["Name"].ToString().ToUpper();
                    Outwardid = obj.dr["CRUEI"].ToString().ToUpper();
                }
                XElement OutwardPartName = new XElement(ns2 + "Name", OutwardName);
                XElement OutwardPartyName = new XElement(ns3 + "PartyName", "");
                XElement OutwardID = new XElement(ns2 + "ID", Outwardid);
                XElement OutwardPartyIdentification = new XElement(ns3 + "PartyIdentification", "");
                XElement OutwardCarrierAgentParty = new XElement(ns3 + "OutwardCarrierAgentParty", "");
                OutwardCarrierAgentParty.Add(OutwardPartyIdentification);
                OutwardPartyIdentification.Add(OutwardID);
                OutwardCarrierAgentParty.Add(OutwardPartyName);
                OutwardPartyName.Add(OutwardPartName);

                string impotparty = "select CRUEI,Name from dbo.OutImporter where Code='" + dt.Rows[0]["ImporterCompanyCode"].ToString() + "'";
                string importName = "", Importid = "";
                obj.dr = obj.ret_dr(impotparty);
                while (obj.dr.Read())
                {
                    // CPC.Add(obj.dr[0].ToString());
                    importName = obj.dr["Name"].ToString().ToUpper();
                    Importid = obj.dr["CRUEI"].ToString().ToUpper();
                }


                XElement ClainmentName = new XElement(ns2 + "Name", importName);
                XElement ClainmentPartyName = new XElement(ns3 + "PartyName", "");
                XElement ClainmentID = new XElement(ns2 + "ID", Importid);
                XElement ImportPartyIdentification = new XElement(ns3 + "PartyIdentification", "");
                XElement ImporterParty = new XElement(ns3 + "ImporterParty", "");


                ImporterParty.Add(ImportPartyIdentification);

                ImportPartyIdentification.Add(ClainmentID);
                ImporterParty.Add(ClainmentPartyName);
                ClainmentPartyName.Add(ClainmentName);

                string inwardparty = "select CRUEI,Name from dbo.InwardCarrierAgent where Code='" + dt.Rows[0]["Inwardcarriercode"].ToString() + "'";
                string inwardName = "", inwardid = "";
                obj.dr = obj.ret_dr(inwardparty);
                while (obj.dr.Read())
                {
                    // CPC.Add(obj.dr[0].ToString());
                    inwardName = obj.dr["Name"].ToString().ToUpper();
                    inwardid = obj.dr["CRUEI"].ToString().ToUpper();
                }
                XElement ImportName = new XElement(ns2 + "Name", inwardName);
                XElement ImportPartyName = new XElement(ns3 + "PartyName", "");
                XElement ImportID = new XElement(ns2 + "ID", inwardid);
                XElement InwardPartyIdentification = new XElement(ns3 + "PartyIdentification", "");
                XElement InwardCarrierAgentParty = new XElement(ns3 + "InwardCarrierAgentParty", "");
                InwardCarrierAgentParty.Add(InwardPartyIdentification);
                InwardPartyIdentification.Add(ImportID);
                InwardCarrierAgentParty.Add(ImportPartyName);
                ImportPartyName.Add(ImportName);
                string freiparty = "select CRUEI,Name from dbo.FreightForwarder where Code='" + dt.Rows[0]["FreightForwarderCode"].ToString() + "'";
                string FreiName = "", FreiID = "";
                obj.dr = obj.ret_dr(freiparty);
                while (obj.dr.Read())
                {
                    // CPC.Add(obj.dr[0].ToString());
                    FreiID = obj.dr["CRUEI"].ToString().ToUpper();
                    FreiName = obj.dr["Name"].ToString().ToUpper();
                    //InwardTransportMode = obj.dr[1].ToString();
                }
                XElement InwardName = new XElement(ns2 + "Name", FreiName);
                XElement InwardPartyName = new XElement(ns3 + "PartyName", "");
                XElement InwardID = new XElement(ns2 + "ID", FreiID);
                XElement FreightPartyIdentification = new XElement(ns3 + "PartyIdentification", "");
                XElement FreightForwarderParty = new XElement(ns3 + "FreightForwarderParty", "");
                FreightForwarderParty.Add(FreightPartyIdentification);
                FreightPartyIdentification.Add(InwardID);
                FreightForwarderParty.Add(InwardPartyName);
                InwardPartyName.Add(InwardName);
                string delparty = "select CRUEI,Name from dbo.DeclarantCompany where Code='" + dt.Rows[0]["DeclarantCompanyCode"].ToString() + "'";
                string declrName = "", declrid = "";
                obj.dr = obj.ret_dr(delparty);
                while (obj.dr.Read())
                {
                    // CPC.Add(obj.dr[0].ToString());
                    declrid = obj.dr["CRUEI"].ToString().ToUpper();
                    declrName = obj.dr["Name"].ToString().ToUpper();
                    //InwardTransportMode = obj.dr[1].ToString();
                }
                XElement FreightName = new XElement(ns2 + "Name", declrName);
                XElement PartyName = new XElement(ns3 + "PartyName", "");
                XElement ID = new XElement(ns2 + "ID", declrid);
                XElement PartyIdentification = new XElement(ns3 + "PartyIdentification", "");
                XElement DeclaringAgentParty = new XElement(ns3 + "DeclaringAgentParty", "");
                DeclaringAgentParty.Add(PartyIdentification);
                PartyIdentification.Add(ID);
                DeclaringAgentParty.Add(PartyName);
                PartyName.Add(FreightName);

                tradeID = dt.Rows[0]["TradeNetMailboxID"].ToString();
                string[] tradID = tradeID.Split('.');
                tradeID = tradID[1].ToString();
                delparty = "select * from dbo.DeclarantCompany where TradeNetMailboxID='" + dt.Rows[0]["TradeNetMailboxID"].ToString() + "'";
                string telphn = "", decname = "", deccode = "", DecId="";
                obj.dr = obj.ret_dr(delparty);
                while (obj.dr.Read())
                {
                    telphn = obj.dr["DeclarantTel"].ToString().ToUpper();
                    decname = obj.dr["DeclarantName"].ToString().ToUpper();
                    deccode = obj.dr["DeclarantCode"].ToString().ToUpper();
                    DecId = obj.dr["CRUEI"].ToString().ToUpper();
                }
                XElement Telephone = new XElement(ns2 + "Telephone", telphn);
                XElement DeclarName = new XElement(ns2 + "Name", decname.ToUpper());
                XElement CodeValue = new XElement(ns2 + "CodeValue", deccode.ToUpper());
                XElement PersonInformation = new XElement(ns3 + "PersonInformation", "");
                XElement DeclarantParty = new XElement(ns3 + "DeclarantParty", "");
                DeclarantParty.Add(PersonInformation);
                PersonInformation.Add(CodeValue);
                PersonInformation.Add(DeclarName);
                DeclarantParty.Add(Telephone);
                XElement Party = new XElement(ns6 + "Party");
                Party.Add(DeclarantParty);
                if (!string.IsNullOrWhiteSpace(declrid))
                {
                    Party.Add(DeclaringAgentParty);
                }
                if (!string.IsNullOrWhiteSpace(FreiID))
                {
                    Party.Add(FreightForwarderParty);
                }
                if (!string.IsNullOrWhiteSpace(inwardid))
                {
                    Party.Add(InwardCarrierAgentParty);
                }
                if (!string.IsNullOrWhiteSpace(Importid))
                {
                    Party.Add(ImporterParty);
                }
                if (!string.IsNullOrWhiteSpace(Outwardid))
                {
                    Party.Add(OutwardCarrierAgentParty);
                }
                if (!string.IsNullOrWhiteSpace(ExpID))
                {
                    Party.Add(ExporterParty);
                }
                if (!string.IsNullOrWhiteSpace(ConsignName))
                {
                    Party.Add(ConsignParty);
                }
                if (!string.IsNullOrWhiteSpace(EndUserNameS))
                {
                    Party.Add(EndUserParty);
                }
                if (!string.IsNullOrWhiteSpace(ManufactName))
                {
                    Party.Add(ManufactParty);
                }
                if (!string.IsNullOrWhiteSpace(licNo))
                {
                    Party.Add(Licence);
                }
                if (!string.IsNullOrWhiteSpace(SupFile))
                {
                    Party.Add(SupportingDocumentReference);
                }
                //Party.Add(InvoiceName);
                //Party


                string[] final = dt.Rows[0]["FinalDestinationCountry"].ToString().Split(':');
                string ff = final[0].ToString().Substring(0, final[0].Length - 1);

                XElement Outfinal = new XElement(ns2 + "FinalDestinationCountry", ff.ToUpper());


                XElement outDischargePort = new XElement(ns2 + "DischargePort", dt.Rows[0]["DischargePort"].ToString().ToUpper());
                XElement OutDepatureDate = new XElement(ns2 + "DepartureDate", Convert.ToDateTime(dt.Rows[0]["DepartureDate"].ToString()).ToString("yyyyMMdd"));
                XElement OutLastport = new XElement(ns2 + "LoadingFinalPort", dt.Rows[0]["LastPort"].ToString().ToUpper());
                XElement OutNextport = new XElement(ns2 + "LoadingNextPort", dt.Rows[0]["NextPort"].ToString().ToUpper());

                XElement OutTowingVessalName = new XElement(ns2 + "VesselName", dt.Rows[0]["TowingVesselName"].ToString().ToUpper());

                XElement OutVessalID = new XElement(ns2 + "VesselID", dt.Rows[0]["TowingVesselID"].ToString().ToUpper());


                XElement OutTowingVessal = new XElement(ns3 + "TowingVessel", "");
                XElement OutAdditional = null;
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["VesselType"].ToString()))
                {
                    if (dt.Rows[0]["VesselType"].ToString() != "--Select--")
                    {
                        OutAdditional = new XElement(ns3 + "AdditionalVesselInformation", "");
                    }
                }
              
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["TowingVesselID"].ToString().ToUpper()))
                {

                    OutTowingVessal.Add(OutVessalID);
                }
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["TowingVesselName"].ToString().ToUpper()))
                {
                    OutTowingVessal.Add(OutTowingVessalName);
                }
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["VesselNationality"].ToString().ToUpper()))
                {
                    string[] strvessal = dt.Rows[0]["VesselNationality"].ToString().Split(':');
                    OutVessalNaltional = new XElement(ns2 + "VesselNationality", strvessal[0].Substring(0, strvessal[0].Length-1).ToUpper());
                }
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["VesselNetRegTon"].ToString()))
                {
                    OutVessalReg = new XElement(ns2 + "NetRegisterTonnage", dt.Rows[0]["VesselNetRegTon"].ToString().ToUpper());
                }
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["VesselType"].ToString()))
                {

                    string result = dt.Rows[0]["VesselType"].ToString().Substring(0, 2);

                    OutVessalType = new XElement(ns2 + "VesselType", result.ToUpper());

                }
                
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["VesselType"].ToString()))
                {
                    if (dt.Rows[0]["VesselType"].ToString().ToUpper() != "--Select--".ToUpper())
                    {
                        OutAdditional.Add(OutVessalType);
                    }
                }
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["VesselNetRegTon"].ToString()))
                {
                    OutAdditional.Add(OutVessalReg);
                }
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["VesselNationality"].ToString()))
                {
                    if (dt.Rows[0]["VesselNationality"].ToString().ToUpper() != "--Select--".ToUpper())
                    {
                        OutAdditional.Add(OutVessalNaltional);
                    }
                }
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["TowingVesselID"].ToString()))
                {
                    OutAdditional.Add(OutTowingVessal);
                }
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["NextPort"].ToString()))
                {
                    OutAdditional.Add(OutNextport);
                }
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["LastPort"].ToString()))
                {
                    OutAdditional.Add(OutLastport);
                }



                

                XElement OutMawNumber = null;
                XElement OutTransIdentifier = null;
                XElement OutConveyanceNum = null;
                string mawval = "", transidenty = "", ConvenRef = "";
                if (dt.Rows[0]["OutwardTransportMode"].ToString() == "4 : Air")
                {
                    mawval = dt.Rows[0]["OutMasterAirwayBill"].ToString().ToUpper();
                    transidenty = dt.Rows[0]["OutAircraftRegNo"].ToString().ToUpper();
                    ConvenRef = dt.Rows[0]["OutFlightNO"].ToString().ToUpper();
                    OutMawNumber = new XElement(ns2 + "MAWBOUCROBLNumber", dt.Rows[0]["OutMasterAirwayBill"].ToString().ToUpper());
                    OutTransIdentifier = new XElement(ns2 + "TransportIdentifier", dt.Rows[0]["OutAircraftRegNo"].ToString().ToUpper());
                    OutConveyanceNum = new XElement(ns2 + "ConveyanceReferenceNumber", dt.Rows[0]["OutFlightNO"].ToString().ToUpper());
                }
                else if (dt.Rows[0]["OutwardTransportMode"].ToString() == "1 : Sea")
                {
                    mawval = dt.Rows[0]["OutOceanBillofLadingNo"].ToString().ToUpper();
                    transidenty = dt.Rows[0]["OutVesselName"].ToString().ToUpper();
                    ConvenRef = dt.Rows[0]["OutVoyageNumber"].ToString().ToUpper();
                    OutMawNumber = new XElement(ns2 + "MAWBOUCROBLNumber", dt.Rows[0]["OutOceanBillofLadingNo"].ToString().ToUpper());
                    OutTransIdentifier = new XElement(ns2 + "TransportIdentifier", dt.Rows[0]["OutVesselName"].ToString().ToUpper());
                    OutConveyanceNum = new XElement(ns2 + "ConveyanceReferenceNumber", dt.Rows[0]["OutVoyageNumber"].ToString().ToUpper());
                }
                else
                {
                    mawval = "";
                    transidenty = dt.Rows[0]["OutTransportId"].ToString().ToUpper();
                    ConvenRef = dt.Rows[0]["OutConveyanceRefNo"].ToString().ToUpper();
                    OutMawNumber = new XElement(ns2 + "MAWBOUCROBLNumber", mawval.ToUpper());
                    OutTransIdentifier = new XElement(ns2 + "TransportIdentifier", dt.Rows[0]["OutTransportId"].ToString().ToUpper());
                    OutConveyanceNum = new XElement(ns2 + "ConveyanceReferenceNumber", dt.Rows[0]["OutConveyanceRefNo"].ToString().ToUpper());
                }
                string[] OutMdeCode = dt.Rows[0]["OutwardTransportMode"].ToString().Split(':');
                XElement OutModeCode = new XElement(ns2 + "ModeCode", OutMdeCode[0].Substring(0, OutMdeCode[0].Length - 1).ToUpper());
                XElement OutTransMode = new XElement(ns3 + "TransportMode", "");
                if (dt.Rows[0]["OutwardTransportMode"].ToString() != "--Select--")
                {
                    OutTransMode.Add(OutModeCode);
                }
                if (!string.IsNullOrWhiteSpace(ConvenRef))
                {
                    OutTransMode.Add(OutConveyanceNum);
                }                
               
                if (!string.IsNullOrWhiteSpace(transidenty))
                {
                    OutTransMode.Add(OutTransIdentifier);
                }
                XElement OutTransMeans = new XElement(ns3 + "TransportMeans", "");
                XElement Outward = new XElement(ns3 + "OutwardTransport", "");                
                Outward.Add(OutTransMeans);

                OutTransMeans.Add(OutTransMode);
                if (!string.IsNullOrWhiteSpace(mawval))
                {
                    OutTransMeans.Add(OutMawNumber);
                }
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["VesselType"].ToString()))
                {
                    if (dt.Rows[0]["VesselType"].ToString() != "--Select--")
                    {
                        string result = dt.Rows[0]["VesselType"].ToString().Substring(0, 2);
                        if (result != "--Select--")
                        {
                            Outward.Add(OutAdditional);
                        }
                    }
                }


                //OutTransMeans.Add(OutMawNumber);
                //if (dt.Rows[0]["OutwardTransportMode"].ToString() != "--Select--")
                //{
                //    if (dt.Rows[0]["OutwardTransportMode"].ToString().ToUpper() == "1:SEA".ToUpper())
                //    {
                //        Outward.Add(OutAdditional);
                //    }
                //}



                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["DepartureDate"].ToString()))
                {
                    Outward.Add(OutDepatureDate);
                }

                


                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["DischargePort"].ToString()))
                {
                    Outward.Add(outDischargePort);
                }
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["FinalDestinationCountry"].ToString()))
                {
                    if (dt.Rows[0]["FinalDestinationCountry"].ToString().ToUpper() != "--Select--".ToUpper())
                    {
                        Outward.Add(Outfinal);
                    }
                }



                string[] mdecde = null;                
                XElement MAWBOUCROBLNumber = null;
                XElement TransportIdentifier = null;
                XElement ConveyanceReferenceNumber = null;
                string inmawval = "", intrans = "", inconveref = "";
                XElement LoadingPort = new XElement(ns2 + "LoadingPort", dt.Rows[0]["LoadingPortCode"].ToString().ToUpper());
                XElement ArrivalDate = new XElement(ns2 + "ArrivalDate", Convert.ToDateTime(dt.Rows[0]["ArrivalDate"].ToString()).ToString("yyyyMMdd"));

                if (dt.Rows[0]["InwardTransportMode"].ToString() == "4 : Air")
                {
                    inmawval = dt.Rows[0]["MasterAirwayBill"].ToString().ToUpper();
                    intrans = dt.Rows[0]["AircraftRegNo"].ToString().ToUpper();
                    inconveref = dt.Rows[0]["FlightNO"].ToString().ToUpper();
                    MAWBOUCROBLNumber = new XElement(ns2 + "MAWBOUCROBLNumber", dt.Rows[0]["MasterAirwayBill"].ToString().ToUpper());
                    TransportIdentifier = new XElement(ns2 + "TransportIdentifier", dt.Rows[0]["AircraftRegNo"].ToString().ToUpper());
                    ConveyanceReferenceNumber = new XElement(ns2 + "ConveyanceReferenceNumber", dt.Rows[0]["FlightNO"].ToString().ToUpper());
                }
                else if (dt.Rows[0]["InwardTransportMode"].ToString() == "1 : Sea")
                {
                    inmawval = dt.Rows[0]["OceanBillofLadingNo"].ToString().ToUpper();
                    intrans = dt.Rows[0]["VesselName"].ToString().ToUpper();
                    inconveref = dt.Rows[0]["ConveyanceRefNo"].ToString().ToUpper();
                    MAWBOUCROBLNumber = new XElement(ns2 + "MAWBOUCROBLNumber", dt.Rows[0]["OceanBillofLadingNo"].ToString().ToUpper());
                    TransportIdentifier = new XElement(ns2 + "TransportIdentifier", dt.Rows[0]["VesselName"].ToString().ToUpper());
                    ConveyanceReferenceNumber = new XElement(ns2 + "ConveyanceReferenceNumber", dt.Rows[0]["VoyageNumber"].ToString().ToUpper());
                }
                else
                {
                    inmawval = "";
                    intrans = dt.Rows[0]["TransportId"].ToString().ToUpper();
                    inconveref = dt.Rows[0]["ConveyanceRefNo"].ToString().ToUpper();
                    MAWBOUCROBLNumber = new XElement(ns2 + "MAWBOUCROBLNumber", inmawval.ToUpper());
                    TransportIdentifier = new XElement(ns2 + "TransportIdentifier", dt.Rows[0]["TransportId"].ToString().ToUpper());
                    ConveyanceReferenceNumber = new XElement(ns2 + "ConveyanceReferenceNumber", dt.Rows[0]["ConveyanceRefNo"].ToString().ToUpper());
                }
                
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["InwardTransportMode"].ToString()))
                {
                    if (dt.Rows[0]["InwardTransportMode"].ToString().ToUpper() != "--Select--".ToUpper())
                    {
                        mdecde = dt.Rows[0]["InwardTransportMode"].ToString().Split(':');


                        ModeCode = new XElement(ns2 + "ModeCode", mdecde[0].Substring(0, mdecde[0].Length - 1).ToUpper());
                        TransportMode = new XElement(ns3 + "TransportMode", "");
                        TransportMeans = new XElement(ns3 + "TransportMeans", "");
                        InwardTransport = new XElement(ns3 + "InwardTransport", "");
                        InwardTransport.Add(TransportMeans);
                        TransportMeans.Add(TransportMode);
                        if (!string.IsNullOrWhiteSpace(mdecde[0].Substring(0, mdecde[0].Length - 1)))
                        {
                            TransportMode.Add(ModeCode);
                        }
                        if (!string.IsNullOrWhiteSpace(inconveref))
                        {
                            TransportMode.Add(ConveyanceReferenceNumber);
                        }
                        if (!string.IsNullOrWhiteSpace(intrans))
                        {
                            TransportMode.Add(TransportIdentifier);
                        }
                        if (!string.IsNullOrWhiteSpace(inmawval))
                        {
                            TransportMeans.Add(MAWBOUCROBLNumber);
                        }
                        if (!string.IsNullOrWhiteSpace(dt.Rows[0]["ArrivalDate"].ToString()))
                        {
                            InwardTransport.Add(ArrivalDate);
                        }
                        if (!string.IsNullOrWhiteSpace(dt.Rows[0]["LoadingPortCode"].ToString()))
                        {
                            InwardTransport.Add(LoadingPort);
                        }


                        //Transport
                    }
                    else
                    {
                        mdecde = dt.Rows[0]["InwardTransportMode"].ToString().Split(':');
                    }
                }
                string transchk = "";
                Transport = new XElement(ns6 + "Transport", "");
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["InwardTransportMode"].ToString()))
                {
                    if (dt.Rows[0]["InwardTransportMode"].ToString().ToUpper() != "--Select--".ToUpper())
                    {
                        string[] decout = dt.Rows[0]["InwardTransportMode"].ToString().Split(':');
                        if (decout[0].Substring(0, decout[0].Length - 1) != "N")
                        {
                            Transport.Add(InwardTransport);
                            transchk = "IN";
                        }
                    }
                }
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["OutwardTransportMode"].ToString()))
                {
                    if (dt.Rows[0]["OutwardTransportMode"].ToString() != "--Select--")
                    {
                        string[] decout = dt.Rows[0]["OutwardTransportMode"].ToString().Split(':');
                        if (decout[0].Substring(0, decout[0].Length - 1) != "N")
                        {
                            Transport.Add(Outward);
                            transchk = "IN";
                        }
                    }
                }

               



                string[] dd = dt.Rows[0]["DeclarationType"].ToString().Split(':');
                if (dd[0].ToString() == "BKT ")
                {
                    BlanketStartDate = new XElement(ns2 + "BlanketStartDate", Convert.ToDateTime(dt.Rows[0]["BlanketStartDate"].ToString()).ToString("yyyyMMdd"));
                    //XElement SupplyIndicator = new XElement(ns2 + "SupplyIndicator", dt.Rows[0]["SupplyIndicator"].ToString());
                }
                string CargoPackType = "", InwardTransportMode = "";
                string qry1213 = "select CargoPackType,OutwardTransportMode from dbo.OutHeaderTbl where PermitID='" + dt.Rows[0]["PermitID"].ToString() + "'";
                obj.dr = obj.ret_dr(qry1213);
                while (obj.dr.Read())
                {
                    // CPC.Add(obj.dr[0].ToString());
                    CargoPackType = obj.dr[0].ToString();
                    InwardTransportMode = obj.dr[1].ToString();
                }
                XElement TransportEquipment = new XElement(ns3 + "TransportEquipment", "");
                if (CargoPackType == "9: Containerized" && InwardTransportMode == "1 : Sea")
                {
                    string Con = "select RowNo,ContainerNo,Size,Weight,SealNo from dbo.OutContainerDtl where PermitID='" + dt.Rows[0]["PermitID"].ToString() + "'";
                    obj.dr = obj.ret_dr(Con);
                    while (obj.dr.Read())
                    {
                        // CPC.Add(obj.dr[0].ToString());
                        //CargoPackType = obj.dr[0].ToString();
                        //InwardTransportMode = obj.dr[1].ToString();
                        string[] ConType = obj.dr[2].ToString().Split(':');

                        XElement SealID = new XElement(ns2 + "SealID", obj.dr[4].ToString().ToUpper());
                        XElement TransportEquipmentSeal = new XElement(ns3 + "TransportEquipmentSeal", "");
                        TransportEquipmentSeal.Add(SealID);
                        XElement EquipmentWeightMeasureNumeric = new XElement(ns2 + "EquipmentWeightMeasureNumeric", obj.dr[3].ToString().ToUpper());
                        XElement SizeTypeCode = new XElement(ns2 + "SizeTypeCode", ConType[0].Substring(0, ConType[0].Length - 1).ToUpper());
                        XElement EquipmentID = new XElement(ns2 + "EquipmentID", obj.dr[1].ToString().ToUpper());
                        XElement SequenceNumeric = new XElement(ns2 + "SequenceNumeric", obj.dr[0].ToString().ToUpper());
                        TransportEquipment = new XElement(ns3 + "TransportEquipment", "");
                        TransportEquipment.Add(SequenceNumeric);
                        TransportEquipment.Add(EquipmentID);
                        TransportEquipment.Add(SizeTypeCode);
                        TransportEquipment.Add(EquipmentWeightMeasureNumeric);
                        TransportEquipment.Add(TransportEquipmentSeal);
                    }
                }
                else
                {
                    XElement SealID = new XElement(ns2 + "SealID", "");
                    XElement TransportEquipmentSeal = new XElement(ns3 + "TransportEquipmentSeal", "");
                    TransportEquipmentSeal.Add(SealID);
                    XElement EquipmentWeightMeasureNumeric = new XElement(ns2 + "EquipmentWeightMeasureNumeric", "");
                    XElement SizeTypeCode = new XElement(ns2 + "SizeTypeCode", "");
                    XElement EquipmentID = new XElement(ns2 + "EquipmentID", "");
                    XElement SequenceNumeric = new XElement(ns2 + "SequenceNumeric", "");

                    TransportEquipment.Add(SequenceNumeric);
                    TransportEquipment.Add(EquipmentID);
                    TransportEquipment.Add(SizeTypeCode);
                    TransportEquipment.Add(EquipmentWeightMeasureNumeric);
                    TransportEquipment.Add(TransportEquipmentSeal);
                }

                string StorageLoc = "";
                string qrys113 = "select StorageCode,Description from dbo.StorageLocation where StorageCode='" + dt.Rows[0]["StorageLocation"].ToString() + "'";
                obj.dr = obj.ret_dr(qrys113);
                while (obj.dr.Read())
                {
                    // CPC.Add(obj.dr[0].ToString());
                    StorageLoc = obj.dr[1].ToString().ToUpper();
                }

                XElement StorageLocationName = new XElement(ns2 + "StorageCode", StorageLoc.ToUpper());
                XElement StorageLocationCode = new XElement(ns2 + "LocationCode", dt.Rows[0]["StorageLocation"].ToString().ToUpper());
                XElement StorageLocation = new XElement(ns3 + "StorageLocation", "");
                StorageLocation.Add(StorageLocationCode);
                //StorageLocation.Add(ReceiptLocationName);
                string ReceiptLoc = "";
                string recname = "";
                string qry113 = "select LocationCode,Description from dbo.ReceiptLocation where LocationCode='" + dt.Rows[0]["RecepitLocation"].ToString() + "'";
                obj.dr = obj.ret_dr(qry113);
                while (obj.dr.Read())
                {
                    // CPC.Add(obj.dr[0].ToString());
                    recname = obj.dr[1].ToString().ToUpper();
                }
                ReceiptLoc = dt.Rows[0]["RepLocName"].ToString().ToUpper();
                if (string.IsNullOrWhiteSpace(dt.Rows[0]["RepLocName"].ToString().ToUpper()))
                {
                    ReceiptLoc = recname;
                }
                XElement ReceiptLocationName = new XElement(ns2 + "LocationName", ReceiptLoc.ToUpper());
                XElement ReceiptLocationCode = new XElement(ns2 + "LocationCode", dt.Rows[0]["RecepitLocation"].ToString().ToUpper());
                XElement ReceiptLocation = new XElement(ns3 + "ReceiptLocation", "");
                ReceiptLocation.Add(ReceiptLocationCode);
                ReceiptLocation.Add(ReceiptLocationName);
                string ReleaseLoc = "";
                string relname = "";
                string qry11 = "select LocationCode,Description from dbo.ReleaseLocation where LocationCode='" + dt.Rows[0]["ReleaseLocation"].ToString() + "'";
                obj.dr = obj.ret_dr(qry11);
                while (obj.dr.Read())
                {
                    // CPC.Add(obj.dr[0].ToString());
                    relname = obj.dr[1].ToString();
                }
                ReleaseLoc = dt.Rows[0]["ResLoaName"].ToString().ToUpper();
                if (string.IsNullOrWhiteSpace(dt.Rows[0]["ResLoaName"].ToString().ToUpper()))
                {
                    ReleaseLoc = relname;
                }
                XElement LocationName = new XElement(ns2 + "LocationName", ReleaseLoc.ToUpper());
                XElement LocationCode = new XElement(ns2 + "LocationCode", dt.Rows[0]["ReleaseLocation"].ToString().ToUpper());
                XElement ReleaseLocation = new XElement(ns3 + "ReleaseLocation", "");
                ReleaseLocation.Add(LocationCode);
                ReleaseLocation.Add(LocationName);

                string[] cargotype = dt.Rows[0]["CargoPackType"].ToString().Split(':');
                XElement CargoPackingType = new XElement(ns2 + "CargoPackingType", cargotype[0].ToString().Substring(0, 1).ToUpper());
                XElement Cargo = new XElement(ns6 + "Cargo");
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["CargoPackType"].ToString()))
                {
                    Cargo.Add(CargoPackingType);
                }
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["ReleaseLocation"].ToString()))
                {
                    Cargo.Add(ReleaseLocation);
                }
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["RecepitLocation"].ToString()))
                {
                    Cargo.Add(ReceiptLocation);
                }
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["StorageLocation"].ToString()))
                {
                    Cargo.Add(StorageLocation);
                }
                if (CargoPackType == "9: Containerized" && InwardTransportMode == "1 : Sea")
                {
                    Cargo.Add(TransportEquipment);
                }
                //if (!string.IsNullOrWhiteSpace(dt.Rows[0]["SupplyIndicator"].ToString()))
                //{
                //    if (dt.Rows[0]["SupplyIndicator"].ToString().ToUpper() == "True".ToUpper())
                //    {
                //        Cargo.Add(SupplyIndicator);
                //    }
                //}

                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["BlanketStartDate"].ToString()))
                {

                    if (dt.Rows[0]["BlanketStartDate"].ToString() != "19000101")
                    {
                        Cargo.Add(BlanketStartDate);
                    }

                }
                //if (!string.IsNullOrWhiteSpace(dt.Rows[0]["VesselType"].ToString()))
                //{
                //    if (dt.Rows[0]["VesselType"].ToString() != "--Select--")
                //    {

                //        string result = dt.Rows[0]["VesselType"].ToString().Substring(0, 2);



                //        if (result != "--Select--")
                //        {
                //            Transport.Add(OutAdditional);
                //        }
                //    }
                //}

                XElement Certified = null;
                XElement TransportDet = null;
                XElement AddCerDetails = null;
                XElement CurrencyCode = null;
                XElement PerferenceCon = null;
                XElement copNum1 = null;
                if (dt.Rows[0]["COType"].ToString() != "--Select--")
                {

                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["CurrencyCode"].ToString()))
                    {
                        string[] cur = dt.Rows[0]["CurrencyCode"].ToString().Split(':');
                        CurrencyCode = new XElement(ns2 + "CurrencyCode", cur[0].ToString().ToUpper());
                    }
                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["PerCommon"].ToString()))
                    {
                        PerferenceCon = new XElement(ns2 + "PreferenceContentPercent", dt.Rows[0]["PerCommon"].ToString().ToUpper());
                    }
                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["CerDetailCopies2"].ToString()))
                    {
                        copNum1 = new XElement(ns2 + "CopiesNumeric", dt.Rows[0]["CerDetailCopies2"].ToString().ToUpper());
                    }

                    if (dt.Rows[0]["CerDetailtype2"].ToString() != "--Select--")
                    {
                        string[] Cerfititype1 = dt.Rows[0]["CerDetailtype2"].ToString().Split(':');

                        CerType1 = new XElement(ns2 + "CertificateType", Cerfititype1[0].Substring(0, Cerfititype1[0].Length - 1).ToUpper());
                        SeqNum1 = new XElement(ns2 + "SequenceNumeric", "2");                        
                    }
                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["CerDetailCopies1"].ToString()))
                    {
                        copNum = new XElement(ns2 + "CopiesNumeric", dt.Rows[0]["CerDetailCopies1"].ToString().ToUpper());
                    }

                    if (dt.Rows[0]["CerDetailtype1"].ToString().ToUpper() != "--Select--".ToUpper())
                    {

                        string[] Cerfititype = dt.Rows[0]["CerDetailtype1"].ToString().Split(':');
                        CerType = new XElement(ns2 + "CertificateType", Cerfititype[0].Substring(0, Cerfititype[0].Length - 1).ToUpper());
                        SeqNum = new XElement(ns2 + "SequenceNumeric", "1");
                        CerDetail = new XElement(ns3 + "CertificateDetail", "");
                    }
                    if (dt.Rows[0]["CerDetailtype1"].ToString() != "--Select--")
                    {
                        CerDetail.Add(SeqNum);
                        CerDetail.Add(CerType);
                    }
                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["CerDetailCopies1"].ToString()))
                    {
                        CerDetail.Add(copNum);
                    }
                    if (dt.Rows[0]["CerDetailtype2"].ToString() != "--Select--")
                    {
                        CerDetail.Add(SeqNum1);
                        CerDetail.Add(CerType1);
                    }
                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["CerDetailCopies2"].ToString()))
                    {
                        CerDetail.Add(copNum1);
                    }
                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["GSPDonorCountry"].ToString()))
                    {
                        string[] gspcou = dt.Rows[0]["GSPDonorCountry"].ToString().Split(':');
                        GSPDonr = new XElement(ns2 + "GSPDonorCountry", gspcou[0].Substring(0, gspcou[0].Length-1).ToUpper());
                    }
                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["Entryyear"].ToString()))
                    {
                        EntryYear = new XElement(ns2 + "EntryYear", Convert.ToDateTime(dt.Rows[0]["Entryyear"].ToString()).ToString("yyyy"));
                    }
                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["COType"].ToString()))
                    {
                        string[] AppType = dt.Rows[0]["COType"].ToString().Split(':');
                        AppProductType = new XElement(ns2 + "ApplicationProductType", AppType[0].Substring(0, AppType[0].Length - 1).ToUpper());
                        Certified = new XElement(ns6 + "Certificate", "");
                    }
                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["COType"].ToString()))
                    {
                        Certified.Add(AppProductType);
                    }
                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["Entryyear"].ToString()))
                    {
                        Certified.Add(EntryYear);
                    }
                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["GSPDonorCountry"].ToString()))
                    {
                        if (dt.Rows[0]["GSPDonorCountry"].ToString() != "--Select--")
                        {
                            Certified.Add(GSPDonr);
                        }
                    }
                    if (dt.Rows[0]["CerDetailtype1"].ToString().ToUpper() != "--Select--".ToUpper())
                    {
                        Certified.Add(CerDetail);
                    }
                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["PerCommon"].ToString()))
                    {
                        Certified.Add(PerferenceCon);
                    }
                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["CurrencyCode"].ToString()))
                    {
                        Certified.Add(CurrencyCode);
                    }
                    if (dt.Rows[0]["AddCerDtl"].ToString()!="----")
                    {
                        if (!string.IsNullOrWhiteSpace(dt.Rows[0]["AddCerDtl"].ToString()))
                        {
                            string[] addcer = dt.Rows[0]["AddCerDtl"].ToString().Split('-');
                            for (int i = 0; i < addcer.Length; i++)
                            {
                                if (!string.IsNullOrWhiteSpace(addcer[i].ToString()))
                                {
                                    AddCerDetails = new XElement(ns2 + "AdditionalCertificateDetails", addcer[i].ToString().ToUpper());
                                    Certified.Add(AddCerDetails);
                                }
                            }
                        }
                        
                    }
                    if (dt.Rows[0]["TransDtl"].ToString()!="----")
                    {
                        if (!string.IsNullOrWhiteSpace(dt.Rows[0]["TransDtl"].ToString()))
                        {
                            string[] addtr = dt.Rows[0]["TransDtl"].ToString().Split('-');
                            for (int i = 0; i < addtr.Length; i++)
                            {
                                if (!string.IsNullOrWhiteSpace(addtr[i].ToString()))
                                {
                                    TransportDet = new XElement(ns2 + "TransportDetails", addtr[i].ToString().ToUpper());
                                    Certified.Add(TransportDet);
                                }
                            }
                        }                                              
                    }
                }

                


                string[] bankercode1 = dt.Rows[0]["BGIndicator"].ToString().Split(':');
                XElement BankerCode = new XElement(ns2 + "BankerGuaranteeCode", bankercode1[0].Substring(0, bankercode1[0].ToString().Length - 1).ToUpper());
                //XElement BankerCode = new XElement(ns2 + "BankerGuaranteeCode", dt.Rows[0]["BGIndicator"].ToString());
                XElement Additional = new XElement(ns2 + "AdditionalRecipientID", "");
                XElement Remarks = new XElement(ns3 + "Remarks", "");



                XElement DeclarationIndicator = new XElement(ns2 + "DeclarationIndicator", dt.Rows[0]["DeclareIndicator"].ToString().ToLower());
                XElement PreviousPermitNumber = new XElement(ns2 + "PreviousPermitNumber", dt.Rows[0]["PreviousPermit"].ToString().TrimEnd().ToUpper());
                DecType = dt.Rows[0]["DeclarationType"].ToString().Split(':');
                XElement DeclarationType = new XElement(ns2 + "DeclarationType", DecType[0].ToString().Substring(0, DecType[0].ToString().Length - 1).ToUpper());
                XElement CommonAccessReference = null;
                if (Update == "AMEND")
                {
                    CommonAccessReference = new XElement(ns2 + "CommonAccessReference", "OUTUPD");
                }
                else
                {
                    CommonAccessReference = new XElement(ns2 + "CommonAccessReference", dt.Rows[0]["MessageType"].ToString().ToUpper());
                }
                XElement DeclarantID = new XElement(ns2 + "DeclarantID", dt.Rows[0]["TradeNetMailboxID"].ToString().ToUpper());
                XElement MessageReference = new XElement(ns2 + "MessageReference", dt.Rows[0]["MSGId"].ToString().ToUpper());
                string date = "";
                string sequneNo = "";
                date = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                sequneNo = dt.Rows[0]["MSGId"].ToString().Substring(dt.Rows[0]["MSGId"].ToString().Length - 4);
                XElement UniqueReferenceNumber = new XElement(ns3 + "UniqueReferenceNumber", "");
                UniqueReferenceNumber.Add(new XElement(ns2 + "ID", DecId.ToUpper()));
                UniqueReferenceNumber.Add(new XElement(ns2 + "Date", date));
                UniqueReferenceNumber.Add(new XElement(ns2 + "SequenceNumeric", sequneNo));
                XElement Header = new XElement(ns6 + "Header");
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["MSGId"].ToString()))
                {
                    Header.Add(MessageReference);
                }
                Header.Add(UniqueReferenceNumber);
                Header.Add(DeclarantID);
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["MessageType"].ToString()))
                {
                    Header.Add(CommonAccessReference);
                }
                if (!string.IsNullOrWhiteSpace(DecType[0].ToString().Substring(0, DecType[0].ToString().Length - 1)))
                {
                    Header.Add(DeclarationType);
                }
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["DeclareIndicator"].ToString()))
                {
                    Header.Add(DeclarationIndicator);
                }
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["PreviousPermit"].ToString()))
                {
                    Header.Add(PreviousPermitNumber);
                }
                string tr1;

                string tr = dt.Rows[0]["TradeRemarks"].ToString();
                int length1 = tr.Length / 512;
                for (int i = 0; i < length1; i++)
                {
                    tr1 = tr.Substring(0, 35);
                    tr = tr.Remove(0, 512);
                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["TradeRemarks"].ToString()))
                    {
                        Remarks.Add(new XElement(ns2 + "FreeText", tr1.ToUpper()));
                        Header.Add(Remarks);
                    }

                }
                if (!string.IsNullOrWhiteSpace(tr))
                {
                    Remarks.Add(new XElement(ns2 + "FreeText", tr.ToUpper()));
                    Header.Add(Remarks);
                }

                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["TradeRemarks"].ToString()))
                {

                }
                //Header.Add(Additional);
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["BGIndicator"].ToString()))
                {
                    if (dt.Rows[0]["BGIndicator"].ToString() != "--Select--")
                    {
                        Header.Add(BankerCode);
                    }
                }
                //List<string> CPC = new List<string>();
                //string qry11a = "select distinct(CPCType) from dbo.OutCPCDtl where PermitId='" + dt.Rows[0]["PermitID"].ToString() + "'";
                //obj.dr = obj.ret_dr(qry11a);
                //while (obj.dr.Read())
                //{
                //    CPC.Add(obj.dr[0].ToString());
                //    // CPC = obj.dr[0].ToString();
                //}
                //string cusprc = "";
                //XElement Customprce = new XElement(ns3 + "CustomsProcedureCodeInformation", "");
                //for (int i = 0; i < CPC.Count; i++)
                //{
                //    string Code = "";
                //    string qry111 = "select * from dbo.OutCPCDtl where PermitId='" + dt.Rows[0]["PermitID"].ToString() + "' and CPCType='" + CPC[i].ToString() + "'";
                //    obj.dr = obj.ret_dr(qry111);
                //    while (obj.dr.Read())
                //    {
                //        Code = obj.dr[0].ToString();

                //        //cARGO

                //        XElement Customprce1 = new XElement(ns3 + "CPCProcessingCode", "");
                //        if (!string.IsNullOrWhiteSpace(obj.dr["CPCType"].ToString()))
                //        {
                //            if (!string.IsNullOrWhiteSpace(obj.dr["ProcessingCode1"].ToString()))
                //            {
                //                Customprce1.Add(new XElement(ns2 + "ProcessingCodeOne", obj.dr["ProcessingCode1"].ToString().ToUpper()));
                //            }
                //            if (!string.IsNullOrWhiteSpace(obj.dr["ProcessingCode2"].ToString()))
                //            {
                //                Customprce1.Add(new XElement(ns2 + "ProcessingCodeTwo", obj.dr["ProcessingCode2"].ToString().ToUpper()));
                //            }
                //            if (!string.IsNullOrWhiteSpace(obj.dr["ProcessingCode3"].ToString()))
                //            {
                //                Customprce1.Add(new XElement(ns2 + "ProcessingCodeThree", obj.dr["ProcessingCode3"].ToString().ToUpper()));
                //            }
                //            MyClass objcas = new MyClass();
                //            DecType = dt.Rows[0]["DeclarationType"].ToString().Split(':');
                //if (dt.Rows[0]["COType"].ToString() == "--Select--")
                //{
                //    if (DecType[0].ToString().Substring(0, DecType[0].ToString().Length - 1) == "DRT")
                //    {
                //        objcas.dr = objcas.ret_dr("select CPCCode from CPCCodeValue where PCode='" + obj.dr["CPCType"].ToString() + "' and CarRef='OUT w/o co' and DecType='" + DecType[0].ToString().Substring(0, DecType[0].ToString().Length - 1) + "' and CPCCode Like '440%'");
                //    }
                //    else
                //    {
                //        objcas.dr = objcas.ret_dr("select CPCCode from CPCCodeValue where PCode='" + obj.dr["CPCType"].ToString() + "' and CarRef='OUT w/o co' and DecType='" + DecType[0].ToString().Substring(0, DecType[0].ToString().Length - 1) + "'");
                //    }
                //}
                //else
                //{
                //    if (DecType[0].ToString().Substring(0, DecType[0].ToString().Length - 1) == "DRT")
                //    {
                //        objcas.dr = objcas.ret_dr("select CPCCode from CPCCodeValue where PCode='" + obj.dr["CPCType"].ToString() + "' and CarRef='OUT with co' and DecType='" + DecType[0].ToString().Substring(0, DecType[0].ToString().Length - 1) + "' and CPCCode Like '5 40%'");
                //    }
                //    else
                //    {
                //        objcas.dr = objcas.ret_dr("select CPCCode from CPCCodeValue where PCode='" + obj.dr["CPCType"].ToString() + "' and CarRef='OUT with co' and DecType='" + DecType[0].ToString().Substring(0, DecType[0].ToString().Length - 1) + "'");
                //    }
                //}
                //            while (objcas.dr.Read())
                //            {
                //                cusprc = objcas.dr["CPCCode"].ToString();
                //                Customprce.Add(new XElement(ns2 + "CustomsProcedureCode", objcas.dr["CPCCode"].ToString().ToUpper()));
                //                cusprc = objcas.dr["CPCCode"].ToString().ToUpper();
                //            }
                //            Customprce.Add(Customprce1);
                //            Header.Add(Customprce);
                //        }

                //    }
                //}              
                List<string> CPC = new List<string>();
                string qry11a = "select distinct(CPCType) from dbo.OutCPCDtl where PermitId='" + dt.Rows[0]["PermitID"].ToString() + "'";
                obj.dr = obj.ret_dr(qry11a);
                while (obj.dr.Read())
                {
                    CPC.Add(obj.dr[0].ToString());
                    // CPC = obj.dr[0].ToString();
                }
                string cusprc = "";
                XElement Customprce = null;
                for (int i = 0; i < CPC.Count; i++)
                {
                    string Code = "";
                    string qry111 = "select * from dbo.OutCPCDtl where PermitId='" + dt.Rows[0]["PermitID"].ToString() + "' and CPCType='" + CPC[i].ToString() + "'";
                    obj.dr = obj.ret_dr(qry111);
                    while (obj.dr.Read())
                    {
                        Code = obj.dr[0].ToString();

                        //cARGO
                        Customprce = new XElement(ns3 + "CustomsProcedureCodeInformation", "");
                        XElement Customprce1 = null;
                        Customprce1 = new XElement(ns3 + "CPCProcessingCode", "");
                        if (!string.IsNullOrWhiteSpace(obj.dr["CPCType"].ToString()))
                        {
                            if (!string.IsNullOrWhiteSpace(obj.dr["ProcessingCode1"].ToString()))
                            {
                                Customprce1.Add(new XElement(ns2 + "ProcessingCodeOne", obj.dr["ProcessingCode1"].ToString().ToUpper()));
                            }
                            if (!string.IsNullOrWhiteSpace(obj.dr["ProcessingCode2"].ToString()))
                            {
                                Customprce1.Add(new XElement(ns2 + "ProcessingCodeTwo", obj.dr["ProcessingCode2"].ToString().ToUpper()));
                            }
                            if (!string.IsNullOrWhiteSpace(obj.dr["ProcessingCode3"].ToString()))
                            {
                                Customprce1.Add(new XElement(ns2 + "ProcessingCodeThree", obj.dr["ProcessingCode3"].ToString().ToUpper()));
                            }

                            MyClass objcas = new MyClass();
                            string[] DecType1 = dt.Rows[0]["DeclarationType"].ToString().Split(':');

                            string result = dt.Rows[0]["DeclarationType"].ToString().Substring(0, 3);



                            if (dt.Rows[0]["COType"].ToString() == "--Select--")
                            {
                                if (result == "DRT")
                                {
                                    objcas.dr = objcas.ret_dr("select CPCCode from CPCCodeValue where PCode='" + obj.dr["CPCType"].ToString() + "' and CarRef='OUT w/o co' and DecType='" + DecType[0].ToString().Substring(0, DecType[0].ToString().Length - 1) + "' and CPCCode Like '440%'");
                                }
                                else
                                {
                                    objcas.dr = objcas.ret_dr("select CPCCode from CPCCodeValue where PCode='" + obj.dr["CPCType"].ToString() + "' and CarRef='OUT w/o co' and DecType='" + DecType[0].ToString().Substring(0, DecType[0].ToString().Length - 1) + "'");
                                }
                            }
                            else
                            {
                                if (result == "DRT")
                                {
                                    objcas.dr = objcas.ret_dr("select CPCCode from CPCCodeValue where PCode='" + obj.dr["CPCType"].ToString() + "' and CarRef='OUT with co' and DecType='" + DecType[0].ToString().Substring(0, DecType[0].ToString().Length - 1) + "' and CPCCode Like '540%'");
                                }
                                else
                                {
                                    objcas.dr = objcas.ret_dr("select CPCCode from CPCCodeValue where PCode='" + obj.dr["CPCType"].ToString() + "' and CarRef='OUT with co' and DecType='" + DecType[0].ToString().Substring(0, DecType[0].ToString().Length - 1) + "'");
                                }
                            }
                            ////objcas.dr = objcas.ret_dr("select CPCCode from CPCCodeValue where PCode='" + obj.dr["CPCType"].ToString() + "' and CarRef='IPT' and DecType='" + DecType1[0].ToString().Substring(0, DecType1[0].ToString().Length - 1) + "'");
                            //while (objcas.dr.Read())
                            //{
                            //    Customprce.Add(new XElement(ns2 + "CustomsProcedureCode", objcas.dr["CPCCode"].ToString().ToUpper()));
                            //    cusprc = objcas.dr["CPCCode"].ToString();
                            //}

                           
                            string[] DecType11 = dt.Rows[0]["DeclarationType"].ToString().Split(':');
                            while (objcas.dr.Read())
                            {
                                Customprce.Add(new XElement(ns2 + "CustomsProcedureCode", objcas.dr["CPCCode"].ToString().Trim().ToUpper()));
                                cusprc = objcas.dr["CPCCode"].ToString();
                            }


                            Customprce.Add(Customprce1);
                            Header.Add(Customprce);
                        }

                    }
                }
                //header
                XElement updateAmt = null;
                int n = 0;
                if (!string.IsNullOrWhiteSpace(Update))
                {
                    if (Update == "AMEND")
                    {
                        string qry111 = "";
                        MyClass objcan = new MyClass();
                        if (Update == "AMEND")
                        {
                            qry111 = "select * from dbo.OutAmend where Permitno='" + dt.Rows[0]["PermitNumber"].ToString() + "'";
                            objcan.dr = objcan.ret_dr(qry111);
                        }
                        else
                        {
                            qry111 = "select * from dbo.OutCancel where Permitno='" + dt.Rows[0]["PermitNumber"].ToString() + "'";
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
                                updateexdper = new XElement(ns2 + "ExtensionReason", objcan.dr["ExtendImportPeriod"].ToString().ToUpper());
                                updatepervalexp = new XElement(ns2 + "PermitValidityExtensionIndicator", objcan.dr["PermitExtension"].ToString().ToLower());
                            }
                            XElement updateAmtval = new XElement(ns3 + "Amendment", "");
                            XElement updateReppermitno = new XElement(ns2 + "ReplacementPermitNumber", objcan.dr["ReplacementPermitno"].ToString().ToUpper());
                            XElement updatepermitno = new XElement(ns2 + "UpdatePermitNumber", objcan.dr["Permitno"].ToString().ToUpper());
                            XElement updatereuqno = new XElement(ns2 + "UpdateRequestNumber", objcan.dr["AmendmentCount"].ToString());
                            XElement updateInd = new XElement(ns2 + "UpdateIndicatorCode", objcan.dr["UpdateIndicator"].ToString().ToUpper());
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
                                string chkval="";
                                if (!string.IsNullOrWhiteSpace(objcan.dr["PermitExtension"].ToString().ToLower()))
                                {
                                    if (objcan.dr["PermitExtension"].ToString().ToLower() != "false")
                                    {
                                        updateAmtval.Add(updatepervalexp);
                                        chkval = "IN";
                                    }
                                }
                                if (!string.IsNullOrWhiteSpace(objcan.dr["ExtendImportPeriod"].ToString()))
                                {
                                    updateAmtval.Add(updateexdper);
                                    chkval = "IN";
                                }
                                if (!string.IsNullOrWhiteSpace(objcan.dr["DescriptionOfReason"].ToString()))
                                {
                                    updateAmtval.Add(updateAmtReason);
                                    chkval = "IN";
                                }
                                if (!string.IsNullOrWhiteSpace(chkval))
                                {
                                    updateAmt.Add(updateAmtval);
                                }
                            }
                        }
                    }
                    //reportElement.Add(updateAmt);
                }
                XElement InboundMessage = new XElement(ns1 + "InboundMessage");
                XElement inpdel = new XElement(ns6 + "Declaration", "");
                XElement InPayment = null;
                if (!string.IsNullOrWhiteSpace(Update))
                {
                    if (Update != "NEW")
                    {
                        InPayment = new XElement(ns6 + "OutwardUpdate", "");
                    }
                    else
                    {
                        InPayment = new XElement(ns6 + "Outward", "");
                    }
                }
                else
                {
                    InPayment = new XElement(ns6 + "Outward", "");
                }
                //if (!string.IsNullOrWhiteSpace(Update))
                //{
                //    InPayment.Add(updateAmt);
                //}
                if (Update != "NEW")
                {
                    inpdel.Add(Header);
                    inpdel.Add(Certified);
                    inpdel.Add(Cargo);
                    if (!string.IsNullOrWhiteSpace(transchk))
                    {
                        inpdel.Add(Transport);
                    }
                    inpdel.Add(Party);
                }
                else
                {
                    InPayment.Add(Header);
                    InPayment.Add(Certified);
                    InPayment.Add(Cargo);
                    if (!string.IsNullOrWhiteSpace(transchk))
                    {
                        InPayment.Add(Transport);
                    }
                    InPayment.Add(Party);
                }
                //XElement InboundMessage = new XElement(ns1 + "InboundMessage");
                //XElement InPayment = new XElement(ns6 + "Outward", Header, Certified, Cargo, Transport, Party);
                string ItemQury = "select * from dbo.OutItemDtL where PermitId='" + dt.Rows[0]["PermitId"].ToString() + "' Order by ItemNo";
                obj.dr = obj.ret_dr(ItemQury);
                if (obj.dr.HasRows)
                {
                    while (obj.dr.Read())
                    {
                        string strcd = obj.dr["PreferentialCode"].ToString();
                        string[] percode = obj.dr["PreferentialCode"].ToString().Split(':');
                        XElement PreferentialCode=null;
                        XElement Tariff=null;                        
                        if (!string.IsNullOrWhiteSpace(percode[0].ToString()))
                        {
                            PreferentialCode = new XElement(ns2 + "PreferentialCode", percode[0].ToString().Substring(0, percode[0].Length - 1).ToUpper());
                            Tariff = new XElement(ns3 + "Tariff", "");
                            if (!string.IsNullOrWhiteSpace(percode[0].ToString().Substring(0, percode[0].Length - 1)))
                            {
                                if (obj.dr["PreferentialCode"].ToString() != "--Select--")
                                {
                                    Tariff.Add(PreferentialCode);
                                }
                            }
                        }                        
                        XElement ItemContentPer = new XElement(ns2 + "ContentPercent", obj.dr["PerContent"].ToString().ToUpper());
                        XElement ItemCerHsCode = new XElement(ns2 + "HarmonizedSystemCode", obj.dr["HSCodeCer"].ToString().ToUpper());
                        
                        XElement ItemInvDate = new XElement(ns2 + "ItemInvoiceDate", Convert.ToDateTime(obj.dr["CerInvDate"].ToString()).ToString("yyyyMMdd"));
                        XElement ItemInvNum = new XElement(ns2 + "ItemInvoiceNumber", obj.dr["CerInvNo"].ToString().ToUpper());
                        XElement TextQutoQty = null;
                        XElement TextCatCode = null;
                        XElement ManufactDate = null;
                        XElement ItemCerLine = null;

                        XElement ItemCerDescription = null;

                        XElement OutHAWBHUCRHBLNumber = null;
                        XElement InHAWBHUCRHBLNumber = null;
                        XElement Marking = null;
                        XElement PreviousLotNumber = null;
                        XElement CurrentLotNumber = null;
                        XElement LotIdentification = null;

                        XElement InmostPackQuantity = null;

                        XElement InnerPackQuantity = null;
                        XElement InPackQuantity = null;
                        XElement OuterPackQuantity = null;
                        XElement ItemValue = null;
                        XElement ItemCerQty = null;
                        XElement ItemCertified = null;                        
                        XElement EndUserDescrip = null;
                        XElement BrandName = null;
                        XElement ModelDescription = null;
                        XElement DangerousGoodsIndicator = null;
                        XElement ShippingMarks = null;
                        XElement ShippingMarksInformation = null;

                        XElement TransactionValue = null;
                        XElement ItemCIFFOBValue = null;
                        XElement OriginCountry = null;
                        XElement AlcoholPercent = null;
                        XElement DutiableQuantity = null;
                        XElement TotalDutiableQuantity = null;
                        XElement HarmonizedSystemQuantity = null;
                        XElement ItemQuantity = null;



                        string[] strhw = null;

                        if (obj.dr["TexQuotaQty"].ToString() != "0.00")
                        {
                            TextQutoQty = new XElement(ns2 + "TextileQuotaQuantity", obj.dr["TexQuotaQty"].ToString());


                            TextQutoQty.Add(new XAttribute("unitCode", obj.dr["TexQuotaUOM"].ToString().ToUpper()));
                        }

                        if (!string.IsNullOrWhiteSpace(obj.dr["TexCat"].ToString()))
                        {
                            TextCatCode = new XElement(ns2 + "TextileCategoryCode", obj.dr["TexCat"].ToString().ToUpper());
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["ManufactureCostDate"].ToString()))
                        {

                            ManufactDate = new XElement(ns2 + "ManufacturingCostDate", Convert.ToDateTime(obj.dr["ManufactureCostDate"].ToString()).ToString("yyyyMMdd"));
                        }


                        //  string replacement = Regex.Replace(DD, @"\t|\n|\r", "");

                        if (!string.IsNullOrWhiteSpace(obj.dr["CertificateDescription"].ToString()))
                        {

                            ItemCerDescription = new XElement(ns3 + "ItemCertificateDescription", "");
                            //string l1;
                            //string DD = obj.dr["CertificateDescription"].ToString();
                            //int length = DD.Length / 35;
                            //for (int i = 0; i < length; i++)
                            //{
                            //    l1 = DD.Substring(0, 35);
                            //    DD = DD.Remove(0, 35);
                            //    if (!string.IsNullOrWhiteSpace(obj.dr["CertificateDescription"].ToString()))
                            //    {
                            //        ItemCerLine = new XElement(ns2 + "Line", l1.ToUpper());
                            //        ItemCerDescription.Add(ItemCerLine);
                            //    }

                            //}
                            //if (!string.IsNullOrWhiteSpace(DD))
                            //{
                            //    ItemCerLine = new XElement(ns2 + "Line", DD.ToUpper());
                            //    ItemCerDescription.Add(ItemCerLine);
                            //}
                            int partLength = 35;
                            string sentence = obj.dr["CertificateDescription"].ToString();
                            sentence = sentence.Replace("\n", " ");
                            List<string> lines =
                                sentence
                                    .Split(' ')
                                    .Aggregate(new[] { "" }.ToList(), (a, x) =>
                                    {
                                        var last = a[a.Count - 1];
                                        if ((last + " " + x).Length > partLength)
                                        {
                                            a.Add(x);
                                        }
                                        else
                                        {
                                            a[a.Count - 1] = (last + " " + x).Trim();
                                        }
                                        return a;
                                    });
                            for (int i = 0; i < lines.Count; i++)
                            {
                                if (!string.IsNullOrWhiteSpace(obj.dr["CertificateDescription"].ToString()))
                                {
                                    ItemCerLine = new XElement(ns2 + "Line", lines[i].ToString().ToUpper());
                                    ItemCerDescription.Add(ItemCerLine);
                                }
                            }

                        }

                        if (obj.dr["CIFValOfCer"].ToString() != "0.00")
                        {
                            ItemValue = new XElement(ns2 + "ItemValue", obj.dr["CIFValOfCer"].ToString().ToUpper());
                        }

                        string itemcerdet = "";
                        if (!string.IsNullOrWhiteSpace(obj.dr["CerItemQty"].ToString()))
                        {
                            itemcerdet = obj.dr["CerItemQty"].ToString();
                            ItemCerQty = new XElement(ns2 + "ItemCertificateQuantity", obj.dr["CerItemQty"].ToString().ToUpper());
                            ItemCerQty.Add(new XAttribute("unitCode", obj.dr["CerItemUOM"].ToString().ToUpper()));
                            ItemCertified = new XElement(ns3 + "ItemCertificate", "");

                            if (Convert.ToDecimal(obj.dr["CerItemQty"].ToString()) > 0)
                            {
                                ItemCertified.Add(ItemCerQty);
                            }

                            ItemCertified.Add(ItemValue);
                        }





                        if (!string.IsNullOrWhiteSpace(obj.dr["CertificateDescription"].ToString()))
                        {
                            ItemCertified.Add(ItemCerDescription);
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["ManufactureCostDate"].ToString()))
                        {
                            ItemCertified.Add(ManufactDate);
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["TexCat"].ToString()))
                        {
                            ItemCertified.Add(TextCatCode);
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["TexQuotaQty"].ToString()))
                        {
                            if (Convert.ToDecimal(obj.dr["TexQuotaQty"].ToString()) > 0)
                            {
                                ItemCertified.Add(TextQutoQty);
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["CerInvNo"].ToString()))
                        {
                            ItemCertified.Add(ItemInvNum);
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["CerInvDate"].ToString()))
                        {
                            ItemCertified.Add(ItemInvDate);
                        }
                        XElement ItemOrginCer = null;
                        if (!string.IsNullOrWhiteSpace(obj.dr["OriginOfCer"].ToString()))
                        {
                            string[] orgin = obj.dr["OriginOfCer"].ToString().Split(',');
                            for (int i = 0; i < orgin.Length; i++)
                            {
                                if (!string.IsNullOrWhiteSpace(orgin[i].ToString()))
                                {
                                    ItemOrginCer = new XElement(ns2 + "OriginCriterion", orgin[i].ToString().ToUpper());
                                    ItemCertified.Add(ItemOrginCer);
                                }
                            }
                        }
                        
                        if (!string.IsNullOrWhiteSpace(obj.dr["HSCodeCer"].ToString()))
                        {
                            ItemCertified.Add(ItemCerHsCode);
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["PerContent"].ToString()))
                        {
                            ItemCertified.Add(ItemContentPer);
                        }

                        if (!string.IsNullOrWhiteSpace(obj.dr["OutHAWBOBL"].ToString()))
                        {
                            OutHAWBHUCRHBLNumber = new XElement(ns2 + "OutHAWBHUCRHBLNumber", obj.dr["OutHAWBOBL"].ToString().ToUpper());
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["InHAWBOBL"].ToString()))
                        {

                            InHAWBHUCRHBLNumber = new XElement(ns2 + "InHAWBHUCRHBLNumber", obj.dr["InHAWBOBL"].ToString().ToUpper());

                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["Making"].ToString()))
                        {
                            strhw = obj.dr["Making"].ToString().Split(':');
                            Marking = new XElement(ns2 + "Marking", strhw[0].ToString().Substring(0, strhw[0].Length - 1));
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["PreviousLot"].ToString()))
                        {


                            PreviousLotNumber = new XElement(ns2 + "PreviousLotNumber", obj.dr["PreviousLot"].ToString().ToUpper());
                        }

                        if (!string.IsNullOrWhiteSpace(obj.dr["CurrentLot"].ToString()))
                        {
                            CurrentLotNumber = new XElement(ns2 + "CurrentLotNumber", obj.dr["CurrentLot"].ToString().ToUpper());
                        }

                        if (!string.IsNullOrWhiteSpace(obj.dr["CurrentLot"].ToString()))
                        {
                            LotIdentification = new XElement(ns3 + "LotIdentification", "");
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["CurrentLot"].ToString()))
                        {
                            LotIdentification.Add(CurrentLotNumber);
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["PreviousLot"].ToString()))
                        {
                            LotIdentification.Add(PreviousLotNumber);
                        }
                        if (!string.IsNullOrWhiteSpace(strhw[0].ToString().Substring(0, strhw[0].Length - 1)))
                        {
                            if (obj.dr["Making"].ToString() != "--Select--")
                            {
                                LotIdentification.Add(Marking);
                            }
                        }

                        //if (!string.IsNullOrWhiteSpace(obj.dr["ShippingMarks1"].ToString()))
                        //{
                        //    ShippingMarks = new XElement(ns2 + "ShippingMarks", obj.dr["ShippingMarks1"].ToString().ToUpper());
                        //    ShippingMarksInformation = new XElement(ns3 + "ShippingMarksInformation", "");
                        //}
                        //if (!string.IsNullOrWhiteSpace(obj.dr["ShippingMarks1"].ToString()))
                        //{
                        //    ShippingMarksInformation.Add(ShippingMarks);
                        //}
                        if (obj.dr["ImPQty"].ToString() != "0.00")
                        {
                            InmostPackQuantity = new XElement(ns2 + "InmostPackQuantity", Math.Round(Convert.ToDecimal(obj.dr["ImPQty"].ToString().ToUpper()),0));
                            InmostPackQuantity.Add(new XAttribute("unitCode", obj.dr["ImPUOM"].ToString()));
                        }

                        if (obj.dr["InPqty"].ToString() != "0.00")
                        {
                            InnerPackQuantity = new XElement(ns2 + "InnerPackQuantity", Math.Round(Convert.ToDecimal(obj.dr["InPqty"].ToString().ToUpper()),0));
                            InnerPackQuantity.Add(new XAttribute("unitCode", obj.dr["InPUOM"].ToString()));
                        }

                        if (obj.dr["IPQty"].ToString() != "0.00")
                        {
                            InPackQuantity = new XElement(ns2 + "InPackQuantity", Math.Round(Convert.ToDecimal(obj.dr["IPQty"].ToString().ToUpper()),0));
                            InPackQuantity.Add(new XAttribute("unitCode", obj.dr["IPUOM"].ToString()));
                        }

                        if (obj.dr["OPQty"].ToString() != "0.00")
                        {
                            OuterPackQuantity = new XElement(ns2 + "OuterPackQuantity", Math.Round(Convert.ToDecimal(obj.dr["OPQty"].ToString()),0));
                            OuterPackQuantity.Add(new XAttribute("unitCode", obj.dr["OPUOM"].ToString()));
                        }

                        XElement PackingDescription = new XElement(ns3 + "PackingDescription", "");
                        if (!string.IsNullOrWhiteSpace(obj.dr["OPUOM"].ToString()))
                        {
                            if (obj.dr["OPUOM"].ToString() != "--Select--")
                            {
                                PackingDescription.Add(OuterPackQuantity);
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["IPUOM"].ToString()))
                        {
                            if (obj.dr["IPUOM"].ToString() != "--Select--")
                            {
                                PackingDescription.Add(InPackQuantity);
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["InPUOM"].ToString()))
                        {
                            if (obj.dr["InPUOM"].ToString() != "--Select--")
                            {
                                PackingDescription.Add(InnerPackQuantity);
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["ImPUOM"].ToString()))
                        {
                            if (obj.dr["ImPUOM"].ToString() != "--Select--")
                            {
                                PackingDescription.Add(InmostPackQuantity);
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["DGIndicator"].ToString()))
                        {
                            DangerousGoodsIndicator = new XElement(ns2 + "DangerousGoodsIndicator", obj.dr["DGIndicator"].ToString().ToLower());
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["Model"].ToString()))
                        {
                            ModelDescription = new XElement(ns2 + "ModelDescription", obj.dr["Model"].ToString().ToUpper());
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["Brand"].ToString()))
                        {
                            BrandName = new XElement(ns2 + "BrandName", obj.dr["Brand"].ToString().ToUpper());
                        }

                        //if (!string.IsNullOrWhiteSpace(obj.dr["EndUserDes"].ToString()))
                        //{
                        //    EndUserLine = new XElement(ns2 + "EndUseLine", obj.dr["EndUserDes"].ToString().ToUpper());
                        //}
                        //if (!string.IsNullOrWhiteSpace(obj.dr["EndUserDes"].ToString()))
                        //{
                        //    EndUserDescrip = new XElement(ns3 + "EndUseDescription", "");
                        //    EndUserDescrip.Add(EndUserLine);
                        //}

                        XElement AdditionalCASCIdentification = new XElement(ns3 + "AdditionalCASCIdentification", "");



                                                
                        if (!string.IsNullOrWhiteSpace(obj.dr["CIFFOB"].ToString()))
                        {
                            if (Convert.ToDecimal(obj.dr["CIFFOB"].ToString()) > 0)
                            {
                                ItemCIFFOBValue = new XElement(ns2 + "ItemCIFFOBValue", obj.dr["CIFFOB"].ToString().ToUpper());
                            }
                        }

                        TransactionValue = new XElement(ns3 + "TransactionValue", "");
                        TransactionValue.Add(ItemCIFFOBValue);

                        //TransactionValue.Add(LastSellingPriceValue);
                        //if (!string.IsNullOrWhiteSpace(obj.dr["UnitPriceCurrency"].ToString()))
                        //{
                        //    if (obj.dr["UnitPriceCurrency"].ToString() != "--Select--")
                        //    {
                        //        TransactionValue.Add(UnitPriceValue);
                        //    }
                        //}
                        //TransactionValue.Add(OptionalItemCharge);
                        string[] corgin = obj.dr["Contry"].ToString().Split(':');
                        string cuntry = corgin[0].ToString().Substring(0, corgin[0].Length - 1);
                        
                        AlcoholPercent = new XElement(ns2 + "AlcoholPercent",Math.Round(Convert.ToDecimal(obj.dr["AlcoholPer"].ToString().ToUpper()),0));
                        DutiableQuantity = new XElement(ns2 + "DutiableQuantity", obj.dr["DutiableQty"].ToString().ToUpper());
                        DutiableQuantity.Add(new XAttribute("unitCode", obj.dr["DutiableUOM"].ToString().ToUpper()));
                        TotalDutiableQuantity = new XElement(ns2 + "TotalDutiableQuantity", obj.dr["TotalDutiableQty"].ToString().ToUpper());
                        TotalDutiableQuantity.Add(new XAttribute("unitCode", obj.dr["TotalDutiableUOM"].ToString().ToUpper()));
                        HarmonizedSystemQuantity = new XElement(ns2 + "HarmonizedSystemQuantity", obj.dr["HSQty"].ToString().ToUpper());
                        HarmonizedSystemQuantity.Add(new XAttribute("unitCode", obj.dr["HSUOM"].ToString().ToUpper()));
                        ItemQuantity = new XElement(ns3 + "ItemQuantity", "");
                        if (!string.IsNullOrWhiteSpace(obj.dr["HSQty"].ToString()))
                        {
                            if (Convert.ToDecimal(obj.dr["HSQty"].ToString()) > 0)
                            {
                                ItemQuantity.Add(HarmonizedSystemQuantity);
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["TotalDutiableQty"].ToString()))
                        {
                            if (Convert.ToDecimal(obj.dr["TotalDutiableQty"].ToString()) > 0)
                            {
                                ItemQuantity.Add(TotalDutiableQuantity);
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["DutiableQty"].ToString()))
                        {
                            if (Convert.ToDecimal(obj.dr["DutiableQty"].ToString()) > 0)
                            {
                                ItemQuantity.Add(DutiableQuantity);
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["AlcoholPer"].ToString()))
                        {
                            if (Convert.ToDecimal(obj.dr["AlcoholPer"].ToString()) > 0)
                            {
                                ItemQuantity.Add(AlcoholPercent);
                            }
                        }
                        XElement GoodsDescription = new XElement(ns2 + "GoodsDescription", obj.dr["Description"].ToString().ToUpper());
                        XElement ItemHarmonizedSystemCode = new XElement(ns2 + "ItemHarmonizedSystemCode", obj.dr["HSCode"].ToString().ToUpper());
                        XElement ItemSequenceNumeric = new XElement(ns2 + "ItemSequenceNumeric", obj.dr["ItemNo"].ToString().ToUpper());
                        Item = new XElement(ns6 + "Item");
                        if (!string.IsNullOrWhiteSpace(obj.dr["ItemNo"].ToString()))
                        {
                            Item.Add(ItemSequenceNumeric);
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["HSCode"].ToString()))
                        {
                            Item.Add(ItemHarmonizedSystemCode);
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["Description"].ToString()))
                        {
                            Item.Add(GoodsDescription);
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["HSQty"].ToString()))
                        {
                            Item.Add(ItemQuantity);
                        }
                        if (!string.IsNullOrWhiteSpace(corgin[0].ToString()))
                        {
                            for (int i = 0; i < corgin.Length; i++)
                            {
                                OriginCountry = new XElement(ns2 + "OriginCountry", corgin[i].ToString().ToUpper());
                                Item.Add(OriginCountry);
                            }
                                
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["UnitPriceCurrency"].ToString()))
                        {
                            if (obj.dr["UnitPriceCurrency"].ToString() != "--Select--")
                            {
                                Item.Add(TransactionValue);
                            }
                        }
                        string CascQury = "select * from dbo.OutCASCDtl where PermitId='" + obj.dr["PermitId"].ToString() + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "' Order by Id";                                              
                        XElement CASCProductQuantity = null;
                        XElement CASCProductCode = null;
                        XElement CASCProduct = null;
                        XElement EndUserDescLine = null;
                        XElement EndUserDescriptn = null;
                        MyClass obj2 = new MyClass();
                        obj2.dr = obj2.ret_dr(CascQury);
                        if (obj2.dr.HasRows)
                        {                            
                            while (obj2.dr.Read())
                            {
                                string CascQuryName = "", CascQuryid = "", CascPdrt = "", EndUserDes = "";
                                List<string> cascde1 = new List<string>();
                                List<string> cascde2 = new List<string>();
                                List<string> cascde3 = new List<string>();
                                cascde1.Add("");
                                cascde2.Add("");
                                cascde3.Add("");
                                CascQuryName = obj2.dr["Quantity"].ToString().ToUpper();
                                CascQuryid = obj2.dr["ProductUOM"].ToString().ToUpper();
                                CascPdrt = obj2.dr["ProductCode"].ToString().ToUpper();
                                EndUserDes = obj2.dr["EndUserDes"].ToString().ToUpper();
                                XElement CASCCodeThree = new XElement(ns2 + "CASCCodeThree", obj2.dr["CascCode3"].ToString().ToUpper());
                                XElement CASCCodeTwo = new XElement(ns2 + "CASCCodeTwo", obj2.dr["CascCode2"].ToString().ToUpper());
                                XElement CASCCodeOne = new XElement(ns2 + "CASCCodeOne", obj2.dr["CascCode1"].ToString().ToUpper());
                                if (!string.IsNullOrEmpty(obj2.dr["CascCode1"].ToString()))
                                {
                                    cascde1.Remove("");
                                    cascde1.Add(obj2.dr["CascCode1"].ToString());
                                    AdditionalCASCIdentification.Add(CASCCodeOne);
                                }
                                if (!string.IsNullOrEmpty(obj2.dr["CascCode2"].ToString()))
                                {
                                    cascde2.Remove("");
                                    cascde2.Add(obj2.dr["CascCode2"].ToString());
                                    AdditionalCASCIdentification.Add(CASCCodeTwo);
                                }
                                if (!string.IsNullOrEmpty(obj2.dr["CascCode3"].ToString()))
                                {
                                    cascde2.Remove("");
                                    cascde2.Add(obj2.dr["CascCode3"].ToString());
                                    AdditionalCASCIdentification.Add(CASCCodeThree);
                                }
                                CASCProductQuantity = new XElement(ns2 + "CASCProductQuantity", CascQuryName);
                                CASCProductQuantity.Add(new XAttribute("unitCode", CascQuryid));
                                CASCProductCode = new XElement(ns2 + "CASCProductCode", CascPdrt);
                                CASCProduct = new XElement(ns3 + "CASCProduct", "");
                                EndUserDescLine = new XElement(ns2 + "EndUseLine", EndUserDes);
                                EndUserDescriptn = new XElement(ns3 + "EndUseDescription", "");
                                EndUserDescriptn.Add(EndUserDescLine);
                                if (!string.IsNullOrWhiteSpace(CascPdrt))
                                {
                                    CASCProduct.Add(CASCProductCode);
                                    if (Convert.ToDecimal(CascQuryName) > 0)
                                    {
                                        CASCProduct.Add(CASCProductQuantity);
                                    }
                                    if (!string.IsNullOrWhiteSpace(cascde1[0].ToString()) || !string.IsNullOrWhiteSpace(cascde2[0].ToString()) || !string.IsNullOrWhiteSpace(cascde3[0].ToString()))
                                    {
                                        CASCProduct.Add(AdditionalCASCIdentification);
                                    }
                                    if (!string.IsNullOrWhiteSpace(EndUserDes))
                                    {
                                        CASCProduct.Add(EndUserDescriptn);
                                    }
                                }
                                if (!string.IsNullOrWhiteSpace(CascPdrt))
                                {
                                    Item.Add(CASCProduct);
                                }

                            }
                        }
                        else
                        {
                            //CASCProductQuantity = new XElement(ns2 + "CASCProductQuantity", CascQuryName);
                            //CASCProductQuantity.Add(new XAttribute("unitCode", CascQuryid));
                            //CASCProductCode = new XElement(ns2 + "CASCProductCode", CascPdrt);
                            //CASCProduct = new XElement(ns3 + "CASCProduct", "");
                            //EndUserDescLine = new XElement(ns2 + "EndUseLine", EndUserDes);
                            //EndUserDescriptn = new XElement(ns3 + "EndUseDescription", "");
                            //EndUserDescriptn.Add(EndUserDescLine);
                            //if (!string.IsNullOrWhiteSpace(CascPdrt))
                            //{
                            //    CASCProduct.Add(CASCProductCode);
                            //    if (Convert.ToDecimal(CascQuryName) > 0)
                            //    {
                            //        CASCProduct.Add(CASCProductQuantity);
                            //    }
                            //    if (!string.IsNullOrWhiteSpace(cascde1[0].ToString()) || !string.IsNullOrWhiteSpace(cascde2[0].ToString()) || !string.IsNullOrWhiteSpace(cascde3[0].ToString()))
                            //    {
                            //        CASCProduct.Add(AdditionalCASCIdentification);
                            //    }
                            //    if (!string.IsNullOrWhiteSpace(EndUserDes))
                            //    {
                            //        CASCProduct.Add(EndUserDescriptn);
                            //    }
                            //}
                            //if (!string.IsNullOrWhiteSpace(CascPdrt))
                            //{
                            //    Item.Add(CASCProduct);
                            //}
                        }                        
                        
                        if (!string.IsNullOrWhiteSpace(obj.dr["EndUserDescription"].ToString()))
                        {
                            Item.Add(EndUserDescrip);
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["Brand"].ToString()))
                        {
                            Item.Add(BrandName);
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["Model"].ToString()))
                        {
                            Item.Add(ModelDescription);
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["DGIndicator"].ToString()))
                        {
                            Item.Add(DangerousGoodsIndicator);
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["OPUOM"].ToString()) || !string.IsNullOrWhiteSpace(obj.dr["IPUOM"].ToString()) || !string.IsNullOrWhiteSpace(obj.dr["InPUOM"].ToString()) || !string.IsNullOrWhiteSpace(obj.dr["ImPUOM"].ToString()))
                        {
                            string oucur = "", incur = "", inpaccur = "", imcur = "";
                            oucur = obj.dr["OPUOM"].ToString();
                            incur = obj.dr["IPUOM"].ToString();
                            inpaccur = obj.dr["InPUOM"].ToString();
                            imcur = obj.dr["ImPUOM"].ToString();
                            if (oucur != "--Select--" || incur != "--Select--" || inpaccur != "--Select--" || imcur != "--Select--")
                            {
                                Item.Add(PackingDescription);
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["ShippingMarks1"].ToString()))
                        {
                            int partLength12 = 17;
                            string sentence12 = obj.dr["ShippingMarks1"].ToString();
                            sentence12 = sentence12.Replace("\n", " ");
                            List<string> lines12 =
                                sentence12
                                    .Split(' ')
                                    .Aggregate(new[] { "" }.ToList(), (a, x) =>
                                    {
                                        var last = a[a.Count - 1];
                                        if ((last + " " + x).Length > partLength12)
                                        {
                                            a.Add(x);
                                        }
                                        else
                                        {
                                            a[a.Count - 1] = (last + " " + x).Trim();
                                        }
                                        return a;
                                    });
                            ShippingMarksInformation = new XElement(ns3 + "ShippingMarksInformation", "");
                            for (int i = 0; i < lines12.Count; i++)
                            {
                                if (!string.IsNullOrWhiteSpace(lines12[i].ToString()))
                                {
                                    ShippingMarks = null;
                                    //ShipMarksInfo = null;
                                    ShippingMarks = new XElement(ns2 + "ShippingMarks", lines12[i].ToString().ToUpper());
                                    ShippingMarksInformation.Add(ShippingMarks);

                                }
                            }
                            Item.Add(ShippingMarksInformation);
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["ShippingMarks2"].ToString()))
                        {
                            int partLength12 = 17;
                            string sentence12 = obj.dr["ShippingMarks2"].ToString();
                            sentence12 = sentence12.Replace("\n", " ");
                            List<string> lines12 =
                                sentence12
                                    .Split(' ')
                                    .Aggregate(new[] { "" }.ToList(), (a, x) =>
                                    {
                                        var last = a[a.Count - 1];
                                        if ((last + " " + x).Length > partLength12)
                                        {
                                            a.Add(x);
                                        }
                                        else
                                        {
                                            a[a.Count - 1] = (last + " " + x).Trim();
                                        }
                                        return a;
                                    });
                            ShippingMarksInformation = new XElement(ns3 + "ShippingMarksInformation", "");
                            for (int i = 0; i < lines12.Count; i++)
                            {
                                if (!string.IsNullOrWhiteSpace(lines12[i].ToString()))
                                {
                                    ShippingMarks = null;
                                    //ShipMarksInfo = null;
                                    ShippingMarks = new XElement(ns2 + "ShippingMarks", lines12[i].ToString().ToUpper());
                                    ShippingMarksInformation.Add(ShippingMarks);

                                }
                            }
                            Item.Add(ShippingMarksInformation);
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["ShippingMarks3"].ToString()))
                        {
                            int partLength12 = 17;
                            string sentence12 = obj.dr["ShippingMarks3"].ToString();
                            sentence12 = sentence12.Replace("\n", " ");
                            List<string> lines12 =
                                sentence12
                                    .Split(' ')
                                    .Aggregate(new[] { "" }.ToList(), (a, x) =>
                                    {
                                        var last = a[a.Count - 1];
                                        if ((last + " " + x).Length > partLength12)
                                        {
                                            a.Add(x);
                                        }
                                        else
                                        {
                                            a[a.Count - 1] = (last + " " + x).Trim();
                                        }
                                        return a;
                                    });
                            ShippingMarksInformation = new XElement(ns3 + "ShippingMarksInformation", "");
                            for (int i = 0; i < lines12.Count; i++)
                            {
                                if (!string.IsNullOrWhiteSpace(lines12[i].ToString()))
                                {
                                    ShippingMarks = null;
                                    //ShipMarksInfo = null;
                                    ShippingMarks = new XElement(ns2 + "ShippingMarks", lines12[i].ToString().ToUpper());
                                    ShippingMarksInformation.Add(ShippingMarks);

                                }
                            }
                            Item.Add(ShippingMarksInformation);
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["ShippingMarks4"].ToString()))
                        {
                            int partLength12 = 17;
                            string sentence12 = obj.dr["ShippingMarks4"].ToString();
                            sentence12 = sentence12.Replace("\n", " ");
                            List<string> lines12 =
                                sentence12
                                    .Split(' ')
                                    .Aggregate(new[] { "" }.ToList(), (a, x) =>
                                    {
                                        var last = a[a.Count - 1];
                                        if ((last + " " + x).Length > partLength12)
                                        {
                                            a.Add(x);
                                        }
                                        else
                                        {
                                            a[a.Count - 1] = (last + " " + x).Trim();
                                        }
                                        return a;
                                    });
                            ShippingMarksInformation = new XElement(ns3 + "ShippingMarksInformation", "");
                            for (int i = 0; i < lines12.Count; i++)
                            {
                                if (!string.IsNullOrWhiteSpace(lines12[i].ToString()))
                                {
                                    ShippingMarks = null;
                                    //ShipMarksInfo = null;
                                    ShippingMarks = new XElement(ns2 + "ShippingMarks", lines12[i].ToString().ToUpper());
                                    ShippingMarksInformation.Add(ShippingMarks);

                                }
                            }
                            Item.Add(ShippingMarksInformation);
                        }                       
                        //Item.Add(ShippingMarksInformation);
                        if (!string.IsNullOrWhiteSpace(obj.dr["CurrentLot"].ToString()))
                        {
                            Item.Add(LotIdentification);
                        }
                        //if (!string.IsNullOrWhiteSpace(obj.dr["CertificateDescription"].ToString()))
                        //{
                        //    Item.Add(ItemCertified);
                        //}

                        if (!string.IsNullOrWhiteSpace(obj.dr["InHAWBOBL"].ToString()))
                        {
                            Item.Add(InHAWBHUCRHBLNumber);
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["OutHAWBOBL"].ToString()))
                        {
                            Item.Add(OutHAWBHUCRHBLNumber);
                        }
                        if (dt.Rows[0]["COType"].ToString() != "--Select--")
                        {
                            if (!string.IsNullOrWhiteSpace(obj.dr["OriginOfCer"].ToString()))
                            {
                                //if (Convert.ToDecimal(itemcerdet) > 0)
                                //{
                                Item.Add(ItemCertified);
                                //}
                            }
                        }
                        //if (!string.IsNullOrWhiteSpace(obj.dr["InvoiceNo"].ToString()))
                        //{
                        //    if (obj.dr["InvoiceNo"].ToString() != "--Select--")
                        //    {
                        //        Item.Add(ItemInvoiceNumber);
                        //    }
                        //}
                        //Item.Add(MotorVehicle);
                        if (!string.IsNullOrWhiteSpace(percode[0].ToString()))
                        {
                            if (!string.IsNullOrWhiteSpace(percode[0].ToString().Substring(0, percode[0].Length - 1)))
                            {
                                if (obj.dr["PreferentialCode"].ToString() != "--Select--")
                                {
                                    Item.Add(Tariff);
                                }
                            }
                        }
                        if (Update != "NEW")
                        {
                            inpdel.Add(Item);
                        }
                        else
                        {
                            InPayment.Add(Item);
                        }
                    }
                }
                if (Update != "NEW")
                {
                    inpdel.Add(Summary);
                }
                else
                {
                    InPayment.Add(Summary);
                }
                if (Update != "NEW")
                {
                    InPayment.Add(updateAmt);
                    InPayment.Add(inpdel);
                }                
                InboundMessage.Add(InPayment);
                //XElement InPayment = new XElement(ns5 + "Inpayment", "");
                reportElement.Add(new XElement(ns2 + "MessageVersion", "041"));
                reportElement.Add(new XElement(ns2 + "SenderID", dt.Rows[0]["TradeNetMailboxID"].ToString().ToUpper().TrimEnd()));
                if (tradeID.ToUpper() == "LYYO002")
                {
                    reportElement.Add(new XElement(ns2 + "RecipientID", "DCS4.DCS4001"));
                }
                else
                {
                    reportElement.Add(new XElement(ns2 + "RecipientID", "DCST.DCST401"));
                }
                reportElement.Add(new XElement(ns2 + "TotalNumberOfDeclaration", "1"));
                reportElement.Add(InboundMessage);
                //reportElement.Add(new XElement(ns5 + "InPayment", Header, Cargo, Transport, Party, Item, Summary));
                //reportElement.Add(new XElement(ns5 + "InboundMessage", "InPayment"));

                doc.WriteTo(xw);
            }
            // Response.Write(sb.ToString());
            string Datetoday = DateTime.Now.ToString();
            //string path = @"C:\Kaizen\OUTDEC'" + Datetoday + "'.xml";

            //// Create a file to write to.
            //using (StreamWriter sw = File.CreateText(path))
            //{
            //    sw.WriteLine(sb.ToString());

            //}

            //var folder = Server.MapPath("KaizenXML");
            //if (!Directory.Exists(folder))
            //{
            //    Directory.CreateDirectory(folder);
            //}

            ////string path = @"C:\Kaizen\IPTDEC.xml";
            //string path = Server.MapPath("KaizenXML");
            //string filename = path + "\\OUTDEC.xml";
            //// Create a file to write to.
            //if (File.Exists(filename))
            //{
            //    File.Delete(filename);
            //}
            //using (StreamWriter sw = File.CreateText(filename))
            //{
            //    sw.WriteLine(sb.ToString());

            //}

            var folder1 = @"D:\MHAccess\workingdir\KaizenOUT\" + tradeID;
            if (!Directory.Exists(folder1))
            {
                Directory.CreateDirectory(folder1);
            }

            //var folder = Server.MapPath("KaizenXML");
            var folder = @"D:\MHAccess\workingdir\KaizenOUT\" + tradeID;
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            //string path = @"D:\Kaizen\IPTDEC.xml";
            //string path = Server.MapPath("KaizenXML");
            string path = @"D:\MHAccess\workingdir\KaizenOUT\" + tradeID;


            //foreach (GridViewRow gvrow in GridInPayment.Rows)
            //{
            //    CheckBox chk = (CheckBox)gvrow.FindControl("CheckBox1");
            //    if (chk != null & chk.Checked)
            //    {
            //        Label labelProductID = (Label)gvrow.FindControl("lblPermitNo");
            //        permitid = labelProductID.Text;
            //    }
            //}
            string MsgId = MSGNUMBER;
            string filename = path + "\\OUTDEC" + MsgId + ".xml";
            // Create a file to write to.
            if (!File.Exists(filename))
            {
                //File.Delete(filename);
                using (StreamWriter sw = File.CreateText(filename))
                {
                    sw.WriteLine(sb.ToString());
                    string strins = "";
                    string Name = "OUTDEC" + MsgId + ".xml";
                    strins = "Insert Into XmlTbl values('" + path + "','" + Name + "','','" + tradeID.ToLower() + "')";
                    obj.exec(strins);

                    strins = "Insert Into DownXmlTbl values('" + path + "','" + Name + "','','" + tradeID.ToLower() + "')";
                    obj.exec(strins);

                    obj.closecon();


                    string strinsn = "";
                    //Send CMD 
                    // Command=Submit|cont_type=F|subj=IPTDEC202510290002|filename=D:\\MHAccess\\workingdir\\KaizenOUT\\KAKG001\\IPTDEC202510290002.xml|cont_id=G14848838067|recip_id=dcst401|notifn=N"

                    string sunjt = "OUTDEC" + MsgId + "";
                    strinsn = "Insert Into Customs_Data values('" + tradeID.ToLower() + "','" + path + "','" + Name + "','Command=Submit|cont_type=F|subj=" + sunjt + "|filename=" + path + "\\" + Name + "|cont_id=G14848838067|recip_id=dcst401|notifn=N','Send CMD','Not Executed')";
                    obj.exec(strinsn);
                    obj.exec(strinsn);
                    //obj.dr = obj.ret_dr("select * from Customs_Data where Status='Not Executed'");
                    //while (obj.dr.Read())
                    //{
                    //    MyClass objsss = new MyClass();
                    //    objsss.exec("update Customs_Data set Status='Executed' where id='" + obj.dr["id"].ToString() + "'");
                    //    string body = obj.dr["CMD"].ToString() + Environment.NewLine + "Command=Retrieve|filename=D:\\MHAccess\\workingdir\\KaizenIN\\KAKG001\\" + sunjt + ".xml|sender_id=dcst401|loc=I";
                    //    string eml = body;
                    //    File.WriteAllText(@"D:\MHAccess\pmmin.msg", eml);
                    //}

                }
            }
            
        }





        public void RejectionXML(string folName)
        {
            try
            {
                string filePath = @"C:\Users\Public\" + folName + "\\ResponseFile\\";
                string xmlFile = "";
                DirectoryInfo apple = new DirectoryInfo(filePath);
                foreach (var file in apple.GetFiles("*"))
                {
                    lststr1.Clear();
                    fldName = "";
                    fldval = "";
                    xmlFile = File.ReadAllText(filePath + file);
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.LoadXml(xmlFile);
                    XmlNode rootNode = xmldoc.DocumentElement;
                    var nodeList1 = xmldoc.GetElementsByTagName("cbc:Date");
                    foreach (XmlNode node in nodeList1)
                    {
                        msgid = node.InnerText;
                    }
                    var nodeList2 = xmldoc.GetElementsByTagName("cbc:SequenceNumeric");
                    foreach (XmlNode node in nodeList2)
                    {
                        pemno = node.InnerText;
                    }
                    string strvalue = pemno.PadLeft(4, '0');
                    strvalue = msgid + strvalue;
                    var nodeList = xmldoc.GetElementsByTagName("rej:RejectionMessage");
                    string Short_Fall = string.Empty;
                    string hdtext = string.Empty;                    
                    var nodeList4 = xmldoc.GetElementsByTagName("cbc:CommonAccessReference");
                    foreach (XmlNode node in nodeList4)
                    {
                        commaccName = "CommonAccessReference";
                        commacc = node.InnerText;
                    }
                    if (commacc == "STATUS")
                    {
                        int sno1 = 0;
                        lststr1 = new List<string>();
                        lststr2 = new List<string>();
                        lststr3 = new List<string>();
                        foreach (XmlNode node in nodeList)
                        {

                            XmlNodeList children = node.ChildNodes;
                            foreach (XmlNode child in children)
                            {                                
                                hdtext = child.Name.ToString();
                                string[] hval = hdtext.Split(':');
                                fldval = ""; fldName = "";
                                if (hval[0].ToString() == "cac")
                                {

                                    XmlNodeList children1 = child.ChildNodes;
                                    if (hdtext != "cac:UniqueReferenceNumber")
                                    {
                                        foreach (XmlNode child1 in children1)
                                        {
                                            string name = child1.Name;
                                            string[] hval1 = child1.Name.ToString().Split(':');
                                            if (hval1[1].ToString() == "ErrorID")
                                            {
                                                sno1 = sno1 + 1;
                                                fldName = fldName + hval1[1].ToString() + ",";
                                                fldval = fldval + "'" + child1.InnerText + "',";
                                                lststr1.Add(child1.InnerText);
                                            }
                                            else if (hval1[1].ToString() == "ErrorDescription")
                                            {
                                                fldName = fldName + "ErrorDescription,";
                                                lststr2.Add(child1.InnerText);
                                                //fldval = fldval + "'" + child1.InnerText + "',";
                                            }
                                            else if (hval1[1].ToString() == "ErrorSequenceNumeric")
                                            {

                                                fldName = fldName + "ErrorSno,";
                                                lststr3.Add(child1.InnerText);
                                                //fldval = fldval + "'" + child1.InnerText + "',";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(fldval))
                        {
                            fldval1 = "'" + sno1 + "','" + strvalue + "',";
                            if (!string.IsNullOrWhiteSpace(issueaut))
                            {
                                fldval1 = fldval1 + "'" + issueaut + "',";
                            }
                            if (!string.IsNullOrWhiteSpace(commacc))
                            {
                                fldval1 = fldval + "'" + commacc + "',";
                            }
                            if (!string.IsNullOrWhiteSpace(ststype))
                            {
                                fldval1 = fldval1 + "'" + ststype + "',";
                            }
                            fldName = fldName.Substring(0, fldName.Length - 1);
                            fldval1 = fldval1.Substring(0, fldval1.Length - 1);
                            int sno = 1;
                            string ffname = "";
                            string flanme = file.ToString().Substring(0, file.ToString().Length - 2);
                            //ffname = ffname.Substring(0, 3);
                            for (int j = 0; j < lststr1.Count; j++)
                            {
                                string str = "";
                                if (j == 0)
                                {
                                    MyClass objipt = new MyClass();
                                    objipt.dr = objipt.ret_dr("select * FROM OutHeaderTbl where MSGId='" + strvalue + "'");
                                    while (objipt.dr.Read())
                                    {
                                        string value = objipt.dr["MSGId"].ToString();
                                        if (!string.IsNullOrWhiteSpace(value))
                                        {
                                            str = "update OutHeaderTbl set  Status='REJ' where MSGId='" + strvalue + "'";
                                            obj.exec(str);


                                            str = "delete from DownXmlTbl where FName='" + flanme + "' and tradeID='" + folName + "'";
                                            obj.exec(str);

                                            ffname = "IPT";

                                            //MyClass objiptrej = new MyClass();
                                            //objiptrej.dr = objiptrej.ret_dr("select Count(*) FROM RejectStatus where MsgID='" + strvalue + "'");
                                            //while (objiptrej.dr.Read())
                                            //{
                                            //    string value1 = objiptrej.dr[0].ToString();
                                            //    if (Convert.ToInt32(value1) <= 0)
                                            //    {


                                            //    }
                                            //}
                                        }

                                    }
                                    objipt = new MyClass();
                                    objipt.dr = objipt.ret_dr("select * FROM InNonHeaderTbl where MSGId='" + strvalue + "'");
                                    while (objipt.dr.Read())
                                    {
                                        string value = objipt.dr["MSGId"].ToString();
                                        if (!string.IsNullOrWhiteSpace(value))
                                        {
                                            str = "update InNonHeaderTbl set  Status='REJ' where MSGId='" + strvalue + "'";
                                            obj.exec(str);

                                            str = "delete from DownXmlTbl where FName='" + flanme + "' and tradeID='" + folName + "'";
                                            obj.exec(str);

                                            ffname = "INP";
                                            //MyClass objiptrej = new MyClass();
                                            //objiptrej.dr = objiptrej.ret_dr("select Count(*) FROM InnonRejectStatus where MsgID='" + strvalue + "'");
                                            //while (objiptrej.dr.Read())
                                            //{
                                            //    string value1 = objiptrej.dr[0].ToString();
                                            //    if (Convert.ToInt32(value1) <= 0)
                                            //    {


                                            //    }
                                            //}
                                        }

                                    }
                                    objipt = new MyClass();
                                    objipt.dr = objipt.ret_dr("select * FROM OutHeaderTbl where MSGId='" + strvalue + "'");
                                    while (objipt.dr.Read())
                                    {
                                        string value = objipt.dr["MSGId"].ToString();
                                        if (!string.IsNullOrWhiteSpace(value))
                                        {
                                            str = "update OutHeaderTbl set  Status='REJ' where MSGId='" + strvalue + "'";
                                            obj.exec(str);

                                            str = "delete from DownXmlTbl where FName='" + flanme + "' and tradeID='" + folName + "'";
                                            obj.exec(str);

                                            ffname = "OUT";
                                            //MyClass objiptrej = new MyClass();
                                            //objiptrej.dr = objiptrej.ret_dr("select Count(*) FROM OutRejectStatus where MsgID='" + strvalue + "'");
                                            //while (objiptrej.dr.Read())
                                            //{
                                            //    string value1 = objiptrej.dr[0].ToString();
                                            //    if (Convert.ToInt32(value1) <= 0)
                                            //    {


                                            //    }
                                            //}
                                        }
                                    }
                                    objipt = new MyClass();
                                    objipt.dr = objipt.ret_dr("select * FROM TranshipmentHeader where MSGId='" + strvalue + "'");
                                    while (objipt.dr.Read())
                                    {
                                        string value = objipt.dr["MSGId"].ToString();
                                        if (!string.IsNullOrWhiteSpace(value))
                                        {
                                            str = "update TranshipmentHeader set  Status='REJ' where MSGId='" + strvalue + "'";
                                            obj.exec(str);

                                            str = "delete from DownXmlTbl where FName='" + flanme + "' and tradeID='" + folName + "'";
                                            obj.exec(str);

                                            ffname = "TNP";

                                            //MyClass objiptrej = new MyClass();
                                            //objiptrej.dr = objiptrej.ret_dr("select Count(*) FROM TransRejectStatus where MsgID='" + strvalue + "'");
                                            //while (objiptrej.dr.Read())
                                            //{
                                            //    string value1 = objiptrej.dr[0].ToString();
                                            //    if (Convert.ToInt32(value1) <= 0)
                                            //    {


                                            //    }
                                            //}
                                        }
                                    }
                                    objipt = new MyClass();
                                    objipt.dr = objipt.ret_dr("select * FROM COHeaderTbl where MSGId='" + strvalue + "'");
                                    while (objipt.dr.Read())
                                    {
                                        string value = objipt.dr["MSGId"].ToString();
                                        if (!string.IsNullOrWhiteSpace(value))
                                        {
                                            str = "update COHeaderTbl set  Status='REJ' where MSGId='" + strvalue + "'";
                                            obj.exec(str);

                                            str = "delete from DownXmlTbl where FName='" + flanme + "' and tradeID='" + folName + "'";
                                            obj.exec(str);

                                            ffname = "COO";
                                            //MyClass objiptrej = new MyClass();
                                            //objiptrej.dr = objiptrej.ret_dr("select Count(*) FROM CORejectStatus where MsgID='" + strvalue + "'");
                                            //while (objiptrej.dr.Read())
                                            //{
                                            //    string value1 = objiptrej.dr[0].ToString();
                                            //    if (Convert.ToInt32(value1) <= 0)
                                            //    {


                                            //    }
                                            //}
                                        }

                                    }
                                }
                                lststr1[j] = lststr1[j].Replace("'", "~");
                                lststr2[j] = lststr2[j].Replace("'", "~");
                                //string mnhhs = lststr3[j].ToString();
                                //lststr3[j] = lststr3[j].Replace("'", "~");
                                //mnhhs = lststr3[j].ToString();
                                if (ffname == "IPT")
                                {
                                    str = "Insert into RejectStatus(" + SnoName + "," + msgidName + "," + commaccName + "," + fldName + ") values('" + sno + "','" + strvalue + "','" + commacc + "','" + lststr1[j].ToString() + "','" + lststr2[j].ToString() + "')";
                                    obj.exec(str);
                                    sno = sno + 1;
                                }
                                else if (ffname == "INP")
                                {
                                    str = "Insert into InnonRejectStatus(" + SnoName + "," + msgidName + "," + commaccName + "," + fldName + ") values('" + sno + "','" + strvalue + "','" + commacc + "','" + lststr1[j].ToString() + "','" + lststr2[j].ToString() + "')";
                                    obj.exec(str);
                                    sno = sno + 1;
                                }
                                else if (ffname == "OUT")
                                {
                                    str = "Insert into OutRejectStatus(" + SnoName + "," + msgidName + "," + commaccName + "," + fldName + ") values('" + sno + "','" + strvalue + "','" + commacc + "','" + lststr1[j].ToString() + "','" + lststr2[j].ToString() + "')";
                                    obj.exec(str);
                                    sno = sno + 1;
                                }
                                else if (ffname == "TNP")
                                {
                                    str = "Insert into TransRejectStatus(" + SnoName + "," + msgidName + "," + commaccName + "," + fldName + ") values('" + sno + "','" + strvalue + "','" + commacc + "','" + lststr1[j].ToString() + "','" + lststr2[j].ToString() + "')";
                                    obj.exec(str);
                                    sno = sno + 1;
                                }
                                else if (ffname == "COO")
                                {
                                    str = "Insert into CORejectStatus(" + SnoName + "," + msgidName + "," + commaccName + "," + fldName + ") values('" + sno + "','" + strvalue + "','" + commacc + "','" + lststr1[j].ToString() + "','" + lststr2[j].ToString() + "')";
                                    obj.exec(str);
                                    sno = sno + 1;
                                }
                            }
                            if (!string.IsNullOrWhiteSpace(ffname))
                            {
                                string sourceFile = @"D:\MHAccess\workingdir\KaizenIN\" + folName + file;
                                string destinationFile = @"D:\MHAccess\workingdir\KaizenIN\" + folName + "\\CopyFile\\" + file;

                                System.IO.File.Copy(sourceFile, destinationFile);
                                File.Delete(sourceFile);
                            }
                            //if (File.Exists(destinationFile))
                            //{

                            //    System.IO.File.Move(sourceFile, destinationFile);
                            //}
                            //else
                            //{
                            //    System.IO.File.Move(sourceFile, destinationFile);
                            //}

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            string ID = "";
            int result = 0;
            foreach (GridViewRow gvrow in GridInPayment.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("CheckBox1");
                if (chk != null & chk.Checked)
                {
                    Label labelProductID = (Label)gvrow.FindControl("Id");

                    con.Open();
                    SqlCommand cmd = new SqlCommand("update  OutHeaderTbl set  Status='DEL' where ID=" + labelProductID.Text, con);
                    result = cmd.ExecuteNonQuery();
                    con.Close();
                    BindInPayment();
                    changestatuscolor();
                }
            }
        }
        private void changestatuscolor()
        {
            foreach (GridViewRow gvrow in GridInPayment.Rows)
            {
                Label ID1 = (Label)gvrow.FindControl("lblStatus");
                if (!string.IsNullOrEmpty(ID1.Text))
                {
                    if (ID1.Text == "NEW")
                    {
                        ID1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#9e9a98");
                        string sentence = ID1.Text.ToLower();
                        ID1.Text = sentence[0].ToString().ToUpper() + sentence.Substring(1);
                    }
                    if (ID1.Text == "DEL")
                    {
                        ID1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#f21010");
                        string sentence = ID1.Text.ToLower();
                        ID1.Text = sentence[0].ToString().ToUpper() + sentence.Substring(1);
                    }
                    else if (ID1.Text == "APR")
                    {
                        ID1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#2dc497");
                        string sentence = ID1.Text.ToLower();
                        ID1.Text = sentence[0].ToString().ToUpper() + sentence.Substring(1);
                    }
                    else if (ID1.Text == "PEN")
                    {
                        ID1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#fd6d05");
                        string sentence = ID1.Text.ToLower();
                        ID1.Text = sentence[0].ToString().ToUpper() + sentence.Substring(1);
                    }
                    else if (ID1.Text == "ERR")
                    {
                        ID1.ForeColor = Color.Red;
                        string sentence = ID1.Text.ToLower();
                        ID1.Text = sentence[0].ToString().ToUpper() + sentence.Substring(1);
                    }
                    else if (ID1.Text == "REJ")
                    {
                        ID1.ForeColor = Color.Brown;
                        string sentence = ID1.Text.ToLower();
                        ID1.Text = sentence[0].ToString().ToUpper() + sentence.Substring(1);
                    }
                }
            }
        }

        protected void BtnPrintCIF_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gvrow in GridInPayment.Rows)
            {
                var checkbox = gvrow.FindControl("CheckBox1") as CheckBox;
                if (checkbox.Checked)
                {
                    Label ID1 = (Label)gvrow.FindControl("Id");
                    string ID = ID1.Text;
                    MyClass lodobj = new MyClass();
                    string lodport = "select * from [OutHeaderTbl] where Id=" + ID + "";
                    lodobj.dr = lodobj.ret_dr(lodport);
                    if (lodobj.dr.HasRows)
                    {
                        while (lodobj.dr.Read())
                        {
                            PermID = lodobj.dr["PermitId"].ToString();
                        }
                    }

                    if (PermID != "")
                    {
                        //var PermitID = gvrow.FindControl("txtPermitNo") as TextBox;  
                        printcif(PermID);
                    }
                    else
                    {
                        printcif(PermID);
                        // LblErr.Text = "Please Check Approved Permit";
                    }
                }
                else
                {
                    LblErr.Text = "Please Check Any Permit";
                }
            }


        }
        public void printcif(string PermID)
        {
            string chk = "";
            StringBuilder sb = new StringBuilder();
            string qry11 = "select t2.Name,t2.CRUEI,t1.JobId,t1.MSGId,t1.TouchTime,t3.* from OutHeaderTbl t1,OutImporter t2,OutInvoiceDtl t3 where  t1.ImporterCompanyCode=t2.Code and t1.PermitId=t3.PermitId  and  t1.PermitId='" + PermID + "'";
            obj.dr = obj.ret_dr(qry11);
            while (obj.dr.Read())
            {
                chk = obj.dr["FCCurrency"].ToString();
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
            if (chk != "")
            {
                StringReader sr = new StringReader(sb.ToString());
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=OUT-PrintGST.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
            }
        }

        protected void View_Click(object sender, EventArgs e)
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer as GridViewRow;

            Label ID1 = (Label)grdrow.FindControl("Id");


            string ID = ID1.Text;
            //string ID = "4";
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(900/2);var Mtop = (screen.height/2)-(500/2);window.open( 'OutView.aspx?ID=" + ID + "', null, 'height=900,width=2000,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

        }

        protected void txtJobId_TextChanged1(object sender, EventArgs e)
        {
            search();
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void LoadInpDecCancel(string permitid)
        {
            string tradeID = "";
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from OutHeaderTbl  where PermitId='" + permitid + "'"))
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

                //XElement Telephone = new XElement(ns2 + "Telephone", "94550043");
                //XElement DeclarName = new XElement(ns2 + "Name", "ESVARAN ESVARAN");
                //XElement CodeValue = new XElement(ns2 + "CodeValue", "S9409336H");
                //XElement PersonInformation = new XElement(ns3 + "PersonInformation", "");
                //XElement DeclarantParty = new XElement(ns3 + "DeclarantParty", "");
                //DeclarantParty.Add(PersonInformation);
                //PersonInformation.Add(CodeValue);
                //PersonInformation.Add(DeclarName);
                //DeclarantParty.Add(Telephone);
                string SupFile = "";
                XElement SupportingDocumentReference = null;
                XElement Filename = null;
                XElement DocumentID = null;

                tradeID = dt.Rows[0]["TradeNetMailboxID"].ToString();
                string[] tradID = tradeID.Split('.');
                tradeID = tradID[1].ToString();
                string delparty = "select * from dbo.DeclarantCompany where TradeNetMailboxID='" + dt.Rows[0]["TradeNetMailboxID"].ToString() + "'";
                string telphn = "", decname = "", deccode = "", DecId = "";
                obj.dr = obj.ret_dr(delparty);
                while (obj.dr.Read())
                {
                    telphn = obj.dr["DeclarantTel"].ToString().ToUpper();
                    decname = obj.dr["DeclarantName"].ToString().ToUpper();
                    deccode = obj.dr["DeclarantCode"].ToString().ToUpper();
                    DecId = obj.dr["CRUEI"].ToString().ToUpper();
                }
                XElement Telephone = new XElement(ns2 + "Telephone", telphn);
                XElement DeclarName = new XElement(ns2 + "Name", decname.ToUpper());
                XElement CodeValue = new XElement(ns2 + "CodeValue", deccode.ToUpper());
                XElement PersonInformation = new XElement(ns3 + "PersonInformation", "");
                XElement DeclarantParty = new XElement(ns3 + "DeclarantParty", "");
                DeclarantParty.Add(PersonInformation);
                PersonInformation.Add(CodeValue);
                PersonInformation.Add(DeclarName);
                DeclarantParty.Add(Telephone);
                MyClass objd = new MyClass();
                string[] percode = null;
                objd.dr = objd.ret_dr("select * from OutCancel where Permitno='" + dt.Rows[0]["PermitNumber"].ToString() + "'");
                if (objd.dr.HasRows)
                {
                    while (objd.dr.Read())
                    {
                        percode = objd.dr["ResonForCancel"].ToString().Split(':');
                    }
                }
                XElement canreason = new XElement(ns2 + "CancellationReasonCode", percode[0].ToString().Substring(0, percode[0].Length - 1).ToUpper());
                XElement DeclarationIndicator = new XElement(ns2 + "DeclarationIndicator", dt.Rows[0]["DeclareIndicator"].ToString().ToLower());
                XElement CommonAccessReference = new XElement(ns2 + "CommonAccessReference", "OUTUPD");
                XElement DeclarantID = new XElement(ns2 + "DeclarantID", dt.Rows[0]["TradeNetMailboxID"].ToString().ToUpper().TrimEnd());
                XElement MessageReference = new XElement(ns2 + "MessageReference", dt.Rows[0]["MSGId"].ToString());
                string date = "";
                string sequneNo = "";
                MSGNUMBER = dt.Rows[0]["MSGId"].ToString();
                date = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                sequneNo = dt.Rows[0]["MSGId"].ToString().Substring(dt.Rows[0]["MSGId"].ToString().Length - 4);
                XElement UniqueReferenceNumber = new XElement(ns3 + "UniqueReferenceNumber", "");
                UniqueReferenceNumber.Add(new XElement(ns2 + "ID", DecId.ToUpper()));
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
                string infilname = "select * from OutFile where InPaymentId='" + dt.Rows[0]["PermitId"].ToString() + "'";
                obj.dr = obj.ret_dr(infilname);
                while (obj.dr.Read())
                {
                    SupportingDocumentReference = null;
                    SupportingDocumentReference = new XElement(ns3 + "SupportingDocumentReference", "");
                    Filename = new XElement(ns2 + "Filename", obj.dr["Name"].ToString().ToUpper());
                    string[] docuID = obj.dr["DocumentType"].ToString().Split(':');
                    DocumentID = new XElement(ns2 + "DocumentID", docuID[0].ToString().Substring(0, docuID[0].Length - 1).ToUpper());
                    SupFile = docuID[0].ToString().Substring(0, docuID[0].Length - 1);
                    SupportingDocumentReference.Add(DocumentID);
                    SupportingDocumentReference.Add(Filename);
                    cancelupd.Add(SupportingDocumentReference);
                }
                //if (!string.IsNullOrWhiteSpace(SupFile))
                //{
                //    cancelupd.Add(SupportingDocumentReference);
                //}
                //header
                XElement updateAmt = null;
                int n = 0;
                if (!string.IsNullOrWhiteSpace(Update))
                {
                    string qry111 = "";
                    MyClass objcan = new MyClass();
                    if (Update == "AMD")
                    {
                        qry111 = "select * from dbo.OutAmend where Permitno='" + dt.Rows[0]["PermitNumber"].ToString() + "'";
                        objcan.dr = objcan.ret_dr(qry111);
                    }
                    else
                    {
                        qry111 = "select * from dbo.OutCancel where Permitno='" + dt.Rows[0]["PermitNumber"].ToString() + "'";
                        objcan.dr = objcan.ret_dr(qry111);
                    }
                    while (objcan.dr.Read())
                    {
                        n =  1;
                        XElement updateAmtReason = null;
                        XElement updateexdper = null;
                        XElement updatepervalexp = null;
                        if (Update == "AMD")
                        {
                            updateAmtReason = new XElement(ns2 + "AmendmentReason", objcan.dr["DescriptionOfReason"].ToString().ToUpper());
                            updateexdper = new XElement(ns2 + "ExtensionReason", objcan.dr["ExtendImportPeriod"].ToString().ToUpper());
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
                        if (Update == "AMD")
                        {
                            string chkval = "";
                            if (!string.IsNullOrWhiteSpace(objcan.dr["PermitExtension"].ToString().ToLower()))
                            {
                                updateAmtval.Add(updatepervalexp);
                                chkval = "IN";
                            }
                            if (!string.IsNullOrWhiteSpace(objcan.dr["ExtendImportPeriod"].ToString()))
                            {
                                updateAmtval.Add(updateexdper);
                                chkval = "IN";
                            }
                            if (!string.IsNullOrWhiteSpace(objcan.dr["DescriptionOfReason"].ToString()))
                            {
                                updateAmtval.Add(updateAmtReason);
                                chkval = "IN";
                            }
                            if (!string.IsNullOrWhiteSpace(chkval))
                            {
                                updateAmt.Add(updateAmtval);
                            }
                        }
                    }
                    //reportElement.Add(updateAmt);
                }

                XElement InboundMessage = new XElement(ns1 + "InboundMessage");
                XElement InPayment = new XElement(ns6 + "OutwardUpdate", "");
                if (!string.IsNullOrWhiteSpace(Update))
                {
                    InPayment.Add(updateAmt);
                }
                InPayment.Add(cancelupd);
                InboundMessage.Add(InPayment);
                //XElement InPayment = new XElement(ns5 + "Inpayment", "");
                reportElement.Add(new XElement(ns2 + "MessageVersion", "041"));
                reportElement.Add(new XElement(ns2 + "SenderID", dt.Rows[0]["TradeNetMailboxID"].ToString().ToUpper()));
                if (tradeID.ToUpper() == "LYYO002")
                {
                    reportElement.Add(new XElement(ns2 + "RecipientID", "DCS4.DCS4001"));
                }
                else
                {
                    reportElement.Add(new XElement(ns2 + "RecipientID", "DCST.DCST401"));
                }
                reportElement.Add(new XElement(ns2 + "TotalNumberOfDeclaration", "1"));
                reportElement.Add(InboundMessage);
                //reportElement.Add(new XElement(ns5 + "InPayment", Header, Cargo, Transport, Party, Item, Summary));
                //reportElement.Add(new XElement(ns5 + "InboundMessage", "InPayment"));                               

                doc.WriteTo(xw);
            }
            // Response.Write(sb.ToString());

            var folder = @"C:\Users\Public\" + tradeID + "\\KaizenXML";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            //string path = @"C:\Kaizen\IPTDEC.xml";
            string path = @"C:\Users\Public\" + tradeID + "\\KaizenXML";
            string MsgId = MSGNUMBER;
            string filename = path + "\\OUTDEC" + MsgId + ".xml";
            // Create a file to write to.
            if (!File.Exists(filename))
            {
                // File.Delete(filename)
                using (StreamWriter sw = File.CreateText(filename))
                {
                    sw.WriteLine(sb.ToString());
                    string strins = "";
                    string Name = "OUTDEC" + MsgId + ".xml";
                    strins = "Insert Into XmlTbl values('" + path + "','" + Name + "','','" + tradeID.ToLower() + "')";
                    obj.exec(strins);

                    strins = "Insert Into DownXmlTbl values('" + path + "','" + Name + "','','" + tradeID.ToLower() + "')";
                    obj.exec(strins);

                    obj.closecon();

                }
            }
        }
        protected void BtnSaveFinal_Click(object sender, EventArgs e)
        {
            string str = string.Empty;
            string strname = string.Empty;
            string permitid = null;
            string tradeIDXML = "";
            foreach (GridViewRow gvrow in GridInPayment.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("CheckBox1");
                if (chk != null & chk.Checked)
                {
                    Label statustype = (Label)gvrow.FindControl("lblStatus");
                    string prmchk = statustype.Text;
                    if (prmchk.ToUpper() == "NEW".ToUpper())
                    {
                        Label labelProductID = (Label)gvrow.FindControl("lblPermitNo");
                        permitid = labelProductID.Text;
                        MyClass obj2 = new MyClass();
                        obj2.dr = obj2.ret_dr("Select prmtStatus,TradeNetMailboxID from OutHeaderTbl where PermitId='" + permitid + "'");
                        if (obj2.dr.HasRows)
                        {
                            while (obj2.dr.Read())
                            {
                                tradeIDXML = obj2.dr["TradeNetMailboxID"].ToString();
                                if (obj2.dr["prmtStatus"].ToString() == "AMD")
                                {
                                    Update = "AMEND";
                                }
                                else
                                {
                                    Update = obj2.dr["prmtStatus"].ToString();
                                }
                            }
                        }
                        if (Update == "CNL")
                        {
                            LoadInpDecCancel(permitid);
                        }
                        else
                        {
                            LoadOUTDEC(permitid);
                        }
                        //LoadOUTDEC(permitid);


                        string Touch_user = Session["UserId"].ToString();
                        string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        string P1 = ("Update OutHeaderTbl set Status='PEN' , TouchUser= '" + Touch_user + "' , TouchTime='" + strTime + "' where PermitId='" + permitid + "' ");
                        obj.exec(P1);
                        obj.closecon();
                    }
                }
            }
            //MyClass obj21 = new MyClass();
            //obj21.dr = obj21.ret_dr("Select TradeNetMailboxID from OutHeaderTbl where TouchUser= '" + Session["UserId"].ToString() + "'");
            //if (obj21.dr.HasRows)
            //{
            //    while (obj21.dr.Read())
            //    {
            //        tradeIDXML = obj21.dr["TradeNetMailboxID"].ToString();
            //    }
            //}
            tradeIDXML = tradmail;
            string[] tradID = tradeIDXML.Split('.');
            tradeIDXML = tradID[1].ToString();

            var folder1 = @"D:\MHAccess\workingdir\KaizenOUT\" + tradeIDXML;
            if (!Directory.Exists(folder1))
            {
                Directory.CreateDirectory(folder1);
            }

            var folder = @"D:\MHAccess\workingdir\KaizenIN\" + tradeIDXML;
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
           
            Cancelxml(tradeIDXML);
            ErrorXml(tradeIDXML);
            RejectionXML(tradeIDXML);
            AmendXml(tradeIDXML);
            ResponseXML(tradeIDXML);
            BindInPayment();
            
        }

        protected void txtLocalNo_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        protected void BtnCopyPermit_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gvrow in GridInPayment.Rows)
            {
                var checkbox = gvrow.FindControl("CheckBox1") as CheckBox;
                if (checkbox.Checked)
                {
                    Label status = (Label)gvrow.FindControl("lblStatus");
                    string ID = status.Text;
                    //if (ID.ToUpper() != "PEN")
                    //{
                        Label ID1 = (Label)gvrow.FindControl("lblPermitNo");
                        PermitId = ID1.Text;
                        PermitNO();
                        JobNO();
                        refid();
                        MSGNO();
                        string Touch_user = Session["UserId"].ToString();
                        string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


                        string headertbl = "insert into OutHeaderTbl ([Refid],[JobId],[MSGId],[PermitId],[TradeNetMailboxID],[MessageType],[DeclarationType],[PreviousPermit],[CargoPackType],[InwardTransportMode],[OutwardTransportMode],[BGIndicator],[SupplyIndicator],[ReferenceDocuments],[License],[COType],[Entryyear],[GSPDonorCountry],[CerDetailtype1],[CerDetailCopies1],[CerDetailtype2],[CerDetailCopies2],[PerCommon],[CurrencyCode],[AddCerDtl],[TransDtl],[Recipient],[DeclarantCompanyCode],[ExporterCompanyCode],[Inwardcarriercode],[OutwardCarrierAgentCode],[FreightForwarderCode],[ImporterCompanyCode],[InwardCarrierAgentCode],[CONSIGNEECode],[EndUserCode],[Manufacturer],[ArrivalDate],[ArrivalTime],[LoadingPortCode],[VoyageNumber],[VesselName],[OceanBillofLadingNo],[ConveyanceRefNo],[TransportId],[FlightNO],[AircraftRegNo],[MasterAirwayBill],[ReleaseLocation],[ResLoaName],[RecepitLocation],[RecepitLocName],[StorageLocation],[BlanketStartDate],[DepartureDate],[DepartureTime],[DischargePort],[FinalDestinationCountry],[OutVoyageNumber],[OutVesselName],[OutOceanBillofLadingNo],[VesselType],[VesselNetRegTon],[VesselNationality] ,[TowingVesselID],[TowingVesselName],[NextPort],[LastPort],[OutConveyanceRefNo],[OutTransportId],[OutFlightNO],[OutAircraftRegNo],[OutMasterAirwayBill],[outHAWB],[INHAWB],[TotalOuterPack],[TotalOuterPackUOM],[TotalGrossWeight],[TotalGrossWeightUOM],[GrossReference],[TradeRemarks],[InternalRemarks],[DeclareIndicator],[NumberOfItems],[TotalCIFFOBValue],[TotalGSTTaxAmt],[TotalExDutyAmt],[TotalCusDutyAmt],[TotalODutyAmt],[TotalAmtPay],[Status],[TouchUser],[TouchTime],[prmtStatus] )";
                        headertbl = headertbl + "  select  '" + refno + "' as Refid,'" + JobNo + "' as JobId ,'" + MsgNO + "' as MSGID,'" + PermitNo + "' as PermitId,[TradeNetMailboxID],[MessageType],[DeclarationType],[PreviousPermit],[CargoPackType],[InwardTransportMode],[OutwardTransportMode],[BGIndicator],[SupplyIndicator],[ReferenceDocuments],[License],[COType],[Entryyear],[GSPDonorCountry],[CerDetailtype1],[CerDetailCopies1],[CerDetailtype2],[CerDetailCopies2],[PerCommon],[CurrencyCode],[AddCerDtl],[TransDtl],[Recipient],[DeclarantCompanyCode],[ExporterCompanyCode],[Inwardcarriercode],[OutwardCarrierAgentCode],[FreightForwarderCode],[ImporterCompanyCode],[InwardCarrierAgentCode],[CONSIGNEECode],[EndUserCode],[Manufacturer],[ArrivalDate],[ArrivalTime],[LoadingPortCode],[VoyageNumber],[VesselName],[OceanBillofLadingNo],[ConveyanceRefNo],[TransportId],[FlightNO],[AircraftRegNo],[MasterAirwayBill],[ReleaseLocation],[ResLoaName],[RecepitLocation],[RecepitLocName],[StorageLocation],[BlanketStartDate],[DepartureDate],[DepartureTime],[DischargePort],[FinalDestinationCountry],[OutVoyageNumber],[OutVesselName],[OutOceanBillofLadingNo],[VesselType],[VesselNetRegTon],[VesselNationality] ,[TowingVesselID],[TowingVesselName],[NextPort],[LastPort],[OutConveyanceRefNo],[OutTransportId],[OutFlightNO],[OutAircraftRegNo],[OutMasterAirwayBill],[outHAWB],[INHAWB],[TotalOuterPack],[TotalOuterPackUOM],[TotalGrossWeight],[TotalGrossWeightUOM],[GrossReference],[TradeRemarks],[InternalRemarks],[DeclareIndicator],[NumberOfItems],[TotalCIFFOBValue],[TotalGSTTaxAmt],[TotalExDutyAmt],[TotalCusDutyAmt],[TotalODutyAmt],[TotalAmtPay],'NEW' as [Status],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime],'NEW' as [prmtStatus] from OutHeaderTbl where [PermitId] = '" + PermitId + "'  ";


                        string invoice = "insert into OutInvoiceDtl ([SNo],[InvoiceNo],[InvoiceDate],[TermType],[AdValoremIndicator],[PreDutyRateIndicator],[SupplierImporterRelationship],[SupplierCode],[ExportPartyCode],[TICurrency],[TIExRate],[TIAmount] ,[TISAmount],[OTCCharge],[OTCCurrency],[OTCExRate],[OTCAmount],[OTCSAmount],[FCCharge],[FCCurrency],[FCExRate],[FCAmount],[FCSAmount],[ICCharge],[ICCurrency],[ICExRate],[ICAmount],[ICSAmount],[CIFSUMAmount],[GSTPercentage],[GSTSUMAmount],[MessageType],[PermitId],[TouchUser],[TouchTime]  )";
                        invoice = invoice + " select [SNo],[InvoiceNo],[InvoiceDate],[TermType],[AdValoremIndicator],[PreDutyRateIndicator],[SupplierImporterRelationship],[SupplierCode],[ExportPartyCode],[TICurrency],[TIExRate],[TIAmount] ,[TISAmount],[OTCCharge],[OTCCurrency],[OTCExRate],[OTCAmount],[OTCSAmount],[FCCharge],[FCCurrency],[FCExRate],[FCAmount],[FCSAmount],[ICCharge],[ICCurrency],[ICExRate],[ICAmount],[ICSAmount],[CIFSUMAmount],[GSTPercentage],[GSTSUMAmount],[MessageType],'" + PermitNo + "' as [PermitId],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime]  from OutInvoiceDtl where [PermitId] = '" + PermitId + "'  ";


                        string item = "insert into OutItemDtl ([ItemNo],[PermitId]  ,[MessageType],[HSCode] ,[Description],[DGIndicator],[Contry],[EndUserDescription],[Brand],[Model],[InHAWBOBL],[OutHAWBOBL],[DutiableQty],[DutiableUOM],[TotalDutiableQty],[TotalDutiableUOM],[InvoiceQuantity],[HSQty],[HSUOM],[AlcoholPer],[InvoiceNo],[ChkUnitPrice],[UnitPrice],[UnitPriceCurrency],[ExchangeRate],[SumExchangeRate],[TotalLineAmount],[InvoiceCharges] ,[CIFFOB],[OPQty],[OPUOM],[IPQty],[IPUOM],[InPqty],[InPUOM],[ImPQty],[ImPUOM],[PreferentialCode],[GSTRate],[GSTUOM],[GSTAmount],[ExciseDutyRate],[ExciseDutyUOM],[ExciseDutyAmount],[CustomsDutyRate],[CustomsDutyUOM],[CustomsDutyAmount],[OtherTaxRate],[OtherTaxUOM],[OtherTaxAmount],[CurrentLot],[PreviousLot],[Making],[ShippingMarks1],[ShippingMarks2],[ShippingMarks3],[ShippingMarks4],[CerItemQty],[CerItemUOM],[CIFValOfCer],[ManufactureCostDate],[TexCat],[TexQuotaQty],[TexQuotaUOM],[CerInvNo],[CerInvDate],[OriginOfCer],[HSCodeCer],[PerContent] ,[CertificateDescription],[TouchUser],[TouchTime] )";
                        item = item + " select  [ItemNo],'" + PermitNo + "' AS [PermitId]  ,[MessageType],[HSCode] ,[Description],[DGIndicator],[Contry],[EndUserDescription],[Brand],[Model],[InHAWBOBL],[OutHAWBOBL],[DutiableQty],[DutiableUOM],[TotalDutiableQty],[TotalDutiableUOM],[InvoiceQuantity],[HSQty],[HSUOM],[AlcoholPer],[InvoiceNo],[ChkUnitPrice],[UnitPrice],[UnitPriceCurrency],[ExchangeRate],[SumExchangeRate],[TotalLineAmount],[InvoiceCharges] ,[CIFFOB],[OPQty],[OPUOM],[IPQty],[IPUOM],[InPqty],[InPUOM],[ImPQty],[ImPUOM],[PreferentialCode],[GSTRate],[GSTUOM],[GSTAmount],[ExciseDutyRate],[ExciseDutyUOM],[ExciseDutyAmount],[CustomsDutyRate],[CustomsDutyUOM],[CustomsDutyAmount],[OtherTaxRate],[OtherTaxUOM],[OtherTaxAmount],[CurrentLot],[PreviousLot],[Making],[ShippingMarks1],[ShippingMarks2],[ShippingMarks3],[ShippingMarks4],[CerItemQty],[CerItemUOM],[CIFValOfCer],[ManufactureCostDate],[TexCat],[TexQuotaQty],[TexQuotaUOM],[CerInvNo],[CerInvDate],[OriginOfCer],[HSCodeCer],[PerContent] ,[CertificateDescription],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime]  from OutItemDtl where [PermitId] = '" + PermitId + "' ";


                        string container = "insert into OutContainerDtl ([PermitId],[RowNo],[ContainerNo],[Size],[Weight],[SealNo],[MessageType],[TouchUser],[TouchTime])";
                        container = container + " select  '" + PermitNo + "' as [PermitId],[RowNo],[ContainerNo],[Size],[Weight],[SealNo],[MessageType],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime]  from OutContainerDtl where [PermitId] = '" + PermitId + "'  ";


                        string CPCDtl = "insert into OutCPCDtl ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])";
                        CPCDtl = CPCDtl + " select  '" + PermitNo + "' as [PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime]  from OutCPCDtl where [PermitId] = '" + PermitId + "'  ";


                        string CASCDtl = "insert into OutCASCDtl ([ItemNo],[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime],[CASCId],EndUserDes)";
                        CASCDtl = CASCDtl + "  select  [ItemNo],[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],'" + PermitNo + "' as [PermitId],[MessageType],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime],[CASCId],EndUserDes  from OutCASCDtl where [PermitId] = '" + PermitId + "'  Order by Id";


                        string file = "insert into OutFile ([Name],[ContentType],[Data],[DocumentType],[InPaymentId],[TouchUser],[TouchTime] )";
                        file = file + "select  [Name],[ContentType],[Data],[DocumentType],'" + PermitNo + "' as [InPaymentId],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime]  from OutFile where [InPaymentId] = '" + PermitId + "' ";

                        // string PerCount = ("INSERT INTO [dbo].[PermitCount] ([PermitId],[MessageType],[AccountId],[TouchUser],[TouchTime])  VALUES ('" + PermitNo + "','OUTDEC','" + Session["AccountId"].ToString() + "','" + Touch_user + "','" + strTime + "')");
                        string PerCount = ("INSERT INTO [dbo].[PermitCount] ([PermitId],[MessageType],[AccountId],[MsgId],[TouchUser],[TouchTime])  VALUES ('" + PermitNo + "','OUTDEC','" + Session["AccountId"].ToString() + "','" + MsgNO + "','" + Touch_user + "','" + strTime + "')");
                        obj.exec(headertbl);
                        obj.exec(invoice);
                        obj.exec(item);
                        obj.exec(container);
                        obj.exec(CPCDtl);
                        obj.exec(CASCDtl);
                        obj.exec(file);
                        obj.exec(PerCount);

                        obj.closecon();



                        BindInPayment();
                        string strBindTxtBox = "select * from OutHeaderTbl where PermitId='" + PermitNo + "'";
                        obj.dr = obj.ret_dr(strBindTxtBox);
                        while (obj.dr.Read())
                        {
                            string idpass = obj.dr["ID"].ToString();
                            Response.Redirect("Out.aspx?ID=" + idpass);

                        }
                    //}
                }
            }
        }

        private void PermitNO()
        {
            string justdate = DateTime.Now.ToString("yyyyMMdd");
            string Touch_user = Session["UserId"].ToString();
            con.Open();
            SqlCommand command1 = new SqlCommand("SELECT Max(Refid) from OutHeaderTbl where LEFT(MSGId,8) ='" + justdate + "'");
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
            PermitNo = code;
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
            SqlCommand command1 = new SqlCommand("SELECT Max(Refid) from OutHeaderTbl where   LEFT(MSGId,8) ='" + justdate + "'");
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

        private void LoadCCPPrintstatus(string permit)
        {          

            //string constr = ConfigurationManager.ConnectionStrings["Data source=GOD-PC;Initial catalog=KaizenTrial;Persist Security Info=True;user ID=sa;Password=123;Min Pool Size=10; Max Pool Size=20000"].ConnectionString;
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from OutHeaderTbl  where PermitId='" + permit + "'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                    }
                }
            }            
            //string path = Server.MapPath("PDF-Files");
            string path = @"C:\Users\Public\PDF-Files";
            string filename = path + "\\" + "Rejectstatus.pdf";

            //Create new PDF document 

            PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create, FileAccess.ReadWrite));
            //Barcode genarate
            Response.ContentType = "application/pdf";
            PdfWriter writer = PdfWriter.GetInstance(
              document, Response.OutputStream
            );
            document.Open();


            //document.Add(rect);


            pgheight = document.PageSize.Height;



            // FONT            
            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1257, false);
            iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 10, iTextSharp.text.Font.NORMAL);

            BaseFont bfTimes1 = BaseFont.CreateFont(BaseFont.COURIER_BOLD, BaseFont.CP1257, false);
            iTextSharp.text.Font timesBold = new iTextSharp.text.Font(bfTimes1, 10, iTextSharp.text.Font.NORMAL);

            //page 1 //
            document.Add(new Paragraph("\n"));
            string testerwd = "                                                                     ";
            iTextSharp.text.Paragraph c3r = new iTextSharp.text.Paragraph(testerwd, times);
            c3r.Alignment = Element.ALIGN_LEFT;

            document.Add(c3r);
            // iTextShirp
            //Bitmap barCode = new Bitmap(1, 1);            
            Barcode39 code128 = new Barcode39();            

            string perName = "PERMIT NO : ";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = perName.Length;
            spceval1 = 69 - sapceval;
            for (int i = 0; i < 6; i++)
            {
                space = space + " ";
            }

            MyClass objdec = new MyClass();
            string imptrname = "", impname1 = "", impceui = "";
            string impget = "Select * from OutImporter where Code='" + dt.Rows[0]["ImporterCompanyCode"].ToString() + "'";
            objdec.dr = objdec.ret_dr("Select * from OutExporter where OutUserCode='" + dt.Rows[0]["ExporterCompanyCode"].ToString() + "'");
            // dr = cmd1.ExecuteReader();

            if (objdec.dr.Read())
            {
                imptrname = objdec.dr["OutUserName"].ToString();
                impname1 = objdec.dr["OutUserName1"].ToString();
                impceui = objdec.dr["OutUserCRUEI"].ToString();
            }

            string cmpname = imptrname + impname1;

            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = cmpname.Length;
            spceval1 = 69 - sapceval;
            //for (int i = 0; i < spceval1; i++)
            //{
            //    space = space + " ";
            //}
            //  Font fontH1 = new Font("Times New Roman", 10, Font.NORMAL);
            PdfPTable table = new PdfPTable(2);
            table.HorizontalAlignment = Element.ALIGN_LEFT;
            table.SpacingBefore = 30f;

            table.SpacingAfter = 30f;
            PdfPCell cell = new PdfPCell(new Phrase("REJECTED DECLARATION", times));
            cell.Colspan = 2;

            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("MESSAGE TYPE :OUT (WITH OR WITHOUT CERTIFICATE OF ORIGIN)", times));
            table.AddCell(cell);
            // table.AddCell(cell);
            // string msgid = dt.Rows[0]["MSGId"].ToString();
            //  cell.Colspan = 1;
            cell = new PdfPCell(new Phrase("DECLARATION TYPE : " + dt.Rows[0]["DeclarationType"].ToString(), times));
            table.AddCell(cell);
            // cell.Colspan = 2;


            // table.AddCell(cell);
            string dd = "COMPANY NAME:" + imptrname
                                     + impname1;            
            cell = new PdfPCell(new Phrase(dd, times));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("DATE:" + dt.Rows[0]["TouchTime"].ToString(), times));
            table.AddCell(cell);

            //   table.AddCell(cell);

            cell.Colspan = 2;
            cell = new PdfPCell(new Phrase("COMPANY UEN:" + impceui, times));

            table.AddCell(cell);
            string msgid = dt.Rows[0]["MSGId"].ToString();
            cell = new PdfPCell(new Phrase("MESSAGE ID: " + msgid, times));
            table.AddCell(cell);


            MyClass lodobj = new MyClass();
            string lodportName = "";

            string lodport = "Select * from LoadingPort where PortCode='" + dt.Rows[0]["LoadingPortCode"].ToString().ToUpper() + "'";
            lodobj.dr = lodobj.ret_dr(lodport);
            if (lodobj.dr.HasRows)
            {
                while (lodobj.dr.Read())
                {
                    lodportName = lodobj.dr["PortName"].ToString().ToUpper();
                }
            }



            cell.Colspan = 2;

            cell = new PdfPCell(new Phrase("PORT OF LOADING:" + lodportName, times));

            table.AddCell(cell);
            //  string msgid = dt.Rows[0]["MSGId"].ToString();
            cell = new PdfPCell(new Phrase("AME / CNL PERMIT: " +dt.Rows[0]["PermitNumber"].ToString (), times));
            table.AddCell(cell);


           
            //  string msgid = dt.Rows[0]["MSGId"].ToString();
            cell = new PdfPCell(new Phrase("PREV PERMIT: " + dt.Rows[0]["PreviousPermit"].ToString(), times));
            table.AddCell(cell);

            cell.Colspan = 2;

            cell = new PdfPCell(new Phrase("DESTINATION CITY: " + dt.Rows[0]["FinalDestinationCountry"].ToString(), times));

            table.AddCell(cell);
            //  string msgid = dt.Rows[0]["MSGId"].ToString();
            cell = new PdfPCell(new Phrase("ARRIVAL DATE: " + dt.Rows[0]["ArrivalDate"].ToString(), times));
            table.AddCell(cell);


            string[] tid = dt.Rows[0]["InwardTransportMode"].ToString().Split(':');

            string transportid = "";
            if (dt.Rows[0]["InwardTransportMode"].ToString() == "1: Sea")
            {
                transportid = dt.Rows[0]["VesselName"].ToString();
            }
            else if (dt.Rows[0]["InwardTransportMode"].ToString() == "4: Air")
            {
                transportid = dt.Rows[0]["FlightNO"].ToString();
            }
            else
            {
                transportid = dt.Rows[0]["TransportId"].ToString();
            }



            cell.Colspan = 2;

            cell = new PdfPCell(new Phrase("IN TRANSPORT ID: " + transportid.ToUpper (), times));

            table.AddCell(cell);
            //  string msgid = dt.Rows[0]["MSGId"].ToString();
            cell = new PdfPCell(new Phrase("DEPARTURE DATE: " + dt.Rows[0]["DepartureDate"].ToString(), times));
            table.AddCell(cell);



            string convey = "";
            if (dt.Rows[0]["InwardTransportMode"].ToString() == "1: Sea")
            {
                convey = dt.Rows[0]["VoyageNumber"].ToString();
            }
            else if (dt.Rows[0]["InwardTransportMode"].ToString() == "4: Air")
            {
                convey = dt.Rows[0]["AircraftRegNo"].ToString();
            }
            else
            {
                convey = dt.Rows[0]["ConveyanceRefNo"].ToString();
            }

            cell.Colspan = 2;

            cell = new PdfPCell(new Phrase("CONVEYANCE REF: " + convey, times));

            table.AddCell(cell);
            //  string msgid = dt.Rows[0]["MSGId"].ToString();
            cell = new PdfPCell(new Phrase("NUMBER OF ITEMS: " + dt.Rows[0]["NumberOfItems"].ToString(), times));
            table.AddCell(cell);



            // MyClass lodobj1 = new MyClass();
            string mawb = "";
            if (dt.Rows[0]["InwardTransportMode"].ToString() == "1: Sea")
            {
                mawb = dt.Rows[0]["OceanBillofLadingNo"].ToString();
            }
            else if (dt.Rows[0]["InwardTransportMode"].ToString() == "4: Air")
            {
                mawb = dt.Rows[0]["MasterAirwayBill"].ToString();
            }


            cell.Colspan = 2;

            cell = new PdfPCell(new Phrase("MAWB/OBL:" + mawb, times));

            table.AddCell(cell);
            string ttlouterpack = dt.Rows[0]["TotalOuterPackUOM"].ToString() + " / " + dt.Rows[0]["TotalOuterPack"].ToString();
            cell = new PdfPCell(new Phrase("TOTAL OUTER PK: " + ttlouterpack, times));
            table.AddCell(cell);




            string grossgst = dt.Rows[0]["TotalGrossWeight"].ToString() + " / " + dt.Rows[0]["TotalGrossWeightUOM"].ToString();

            string[] outtid = dt.Rows[0]["OutwardTransportMode"].ToString().Split(':');

            string outtransportid = "";
            if (dt.Rows[0]["OutwardTransportMode"].ToString() == "1: Sea")
            {
                outtransportid = dt.Rows[0]["OutVesselName"].ToString();
            }
            else if (dt.Rows[0]["OutwardTransportMode"].ToString() == "4: Air")
            {
                outtransportid = dt.Rows[0]["OutFlightNO"].ToString();
            }
            else
            {
                outtransportid = dt.Rows[0]["OutTransportId"].ToString();
            }


            cell.Colspan = 2;

            cell = new PdfPCell(new Phrase("OUT TRANSPORT ID:" + outtransportid.ToUpper (), times));

            table.AddCell(cell);
            //  string msgid = dt.Rows[0]["MSGId"].ToString();
            cell = new PdfPCell(new Phrase("TOTAL GROSS WGT: " + grossgst, times));
            table.AddCell(cell);



            string outconvey = "";
            if (dt.Rows[0]["OutwardTransportMode"].ToString() == "1: Sea")
            {
                outconvey = dt.Rows[0]["OutVoyageNumber"].ToString();
            }
            else if (dt.Rows[0]["OutwardTransportMode"].ToString() == "4:; Air")
            {
                outconvey = dt.Rows[0]["OutAircraftRegNo"].ToString();
            }
            else
            {
                outconvey = dt.Rows[0]["OutConveyanceRefNo"].ToString();
            }





            cell.Colspan = 2;

            cell = new PdfPCell(new Phrase("CONVEYANCEREF: " + outconvey, times));

            table.AddCell(cell);
            //  string msgid = dt.Rows[0]["MSGId"].ToString();o
            cell = new PdfPCell(new Phrase("TOTAL CIFFOB VAL: $ " + dt.Rows[0]["TotalCIFFOBValue"].ToString(), times));
            table.AddCell(cell);


            string outmawb = "";
            if (dt.Rows[0]["OutwardTransportMode"].ToString() == "1: Sea")
            {
                outmawb = dt.Rows[0]["OutOceanBillofLadingNo"].ToString();
            }
            else if (dt.Rows[0]["OutwardTransportMode"].ToString() == "4: Air")
            {
                outmawb = dt.Rows[0]["OutMasterAirwayBill"].ToString();
            }


            //cell.Colspan = 2;

            cell = new PdfPCell(new Phrase("MAWB/OBL: " + outmawb, times));


            table.AddCell(cell);

            //  MyClass lodobj = new MyClass();
            string por = "";

            string por1 = "Select * from ReleaseLocation where Code='" + dt.Rows[0]["ReleaseLocation"].ToString().ToUpper() + "'";
            lodobj.dr = lodobj.ret_dr(por1);
            if (lodobj.dr.HasRows)
            {
                while (lodobj.dr.Read())
                {
                    por = lodobj.dr["Description"].ToString().ToUpper();
                }
            }



            string pol = "";

            string pol1 = "Select * from ReceiptLocation where Code='" + dt.Rows[0]["RecepitLocation"].ToString().ToUpper() + "'";
            lodobj.dr = lodobj.ret_dr(pol1);
            if (lodobj.dr.HasRows)
            {
                while (lodobj.dr.Read())
                {
                    pol = lodobj.dr["Description"].ToString().ToUpper();
                }
            }


            //  string msgid = dt.Rows[0]["MSGId"].ToString();
            cell = new PdfPCell(new Phrase("PL OF RELEASE: " + por, times));
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase("PL OF RECEIPT:" + pol, times));

            table.AddCell(cell);
            //  string msgid = dt.Rows[0]["MSGId"].ToString();
            cell = new PdfPCell(new Phrase("TRADER REMARKS: " + dt.Rows[0]["TradeRemarks"].ToString(), times));
            table.AddCell(cell);


            document.Add(table);



            PdfPTable table1 = new PdfPTable(3);

            //actual width of table in points

            table1.TotalWidth = 216f;

            //fix the absolute width of the table

            //   table1.LockedWidth = true;



            //relative col widths in proportions - 1/3 and 2/3

            float[] widths = new float[] { 1f, 5f, 5f };

            table1.SetWidths(widths);

            table1.HorizontalAlignment = 0;

            //leave a gap before and after the table

            table1.SpacingBefore = 20f;

            table1.SpacingAfter = 30f;



            PdfPCell cell1 = new PdfPCell(new Phrase("REJECT REASON", times));

            cell1.Colspan = 3;

            cell1.Border = 0;


            cell1.HorizontalAlignment = 1;

            table1.AddCell(cell1);


            cell1.Colspan = 3;
            cell1 = new PdfPCell(new Phrase("S.NO", times));
            table1.AddCell(cell1);

            cell1 = new PdfPCell(new Phrase("ERROR ID", times));
            table1.AddCell(cell1);

            cell1 = new PdfPCell(new Phrase("DESCRIPTION", times));
            table1.AddCell(cell1);

            //reject desc


            string rej = "select ErrorSno,ErrorID,ErrorDescription from OutRejectStatus  where MsgID='" + dt.Rows[0]["MSGId"].ToString() + "'";
            lodobj.dr = lodobj.ret_dr(rej);
            if (lodobj.dr.HasRows)
            {
                while (lodobj.dr.Read())
                {
                    cell1 = new PdfPCell(new Phrase(lodobj.dr["ErrorSno"].ToString(), times));
                    table1.AddCell(cell1);
                    cell1 = new PdfPCell(new Phrase(lodobj.dr["ErrorID"].ToString(), times));
                    table1.AddCell(cell1);
                    cell1 = new PdfPCell(new Phrase(lodobj.dr["ErrorDescription"].ToString(), times));
                    table1.AddCell(cell1);

                }
            }




            //using (SqlConnection con1 = new SqlConnection(constr))
            //{
            //    using (SqlCommand cmd11 = new SqlCommand("select ErrorID,ErrorDescription from RejectStatus  where MsgID='" + dt.Rows [0]["MSGId"].ToString () + "'"))
            //    {

            //            cmd11.Connection = con;
            //            using (SqlDataReader rdr = cmd11.ExecuteReader())
            //            {
            //                while (rdr.Read())
            //                {

            //                    table1.AddCell(rdr[0].ToString());

            //                    table1.AddCell(rdr[1].ToString());

            //                }
            //            }
            //          //  sda1.SelectCommand = cmd11;
            //           // sda1.Fill(dt);

            //    }
            //}

            document.Add(table1);


            document.Close();
            byte[] bytes = File.ReadAllBytes(filename);

            using (MemoryStream stream = new MemoryStream())
            {
                PdfReader reader = new PdfReader(bytes);
                using (PdfStamper stamper = new PdfStamper(reader, stream))
                {
                    int pages = reader.NumberOfPages;
                    for (int i = 1; i <= pages; i++)
                    {
                        if (i == 1)
                        {
                            ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_RIGHT, new Phrase("PG  : " + i.ToString() + " OF " + pages, times), 541f, 817f, 0);
                        }
                        else
                        {
                            ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_RIGHT, new Phrase("PG  : " + i.ToString() + " OF " + pages, times), 541f, 817f, 0);
                        }
                    }
                }
                bytes = stream.ToArray();

            }


            File.WriteAllBytes(filename, bytes);
            ShowPdf(filename);
        }

        protected void btnRejectSta_Click(object sender, EventArgs e)
        {
            string str = string.Empty;
            string strname = string.Empty;
            string permitid = null;
            string status = "";
            foreach (GridViewRow gvrow in GridInPayment.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("CheckBox1");
                if (chk != null & chk.Checked)
                {
                    Label labelProductID = (Label)gvrow.FindControl("lblPermitNo");
                    Label statustype = (Label)gvrow.FindControl("lblStatus");
                    permitid = labelProductID.Text;
                    MyClass obj2 = new MyClass();
                    obj2.dr = obj2.ret_dr("Select Status from OutHeaderTbl where PermitId='" + permitid + "'");
                    if (obj2.dr.HasRows)
                    {
                        while (obj2.dr.Read())
                        {
                            status = obj2.dr["Status"].ToString();
                        }
                    }

                    if (status == "REJ")
                    {
                        LoadCCPPrintstatus(permitid);
                    }

                }
            }
        }


        private void LoadCCPPrintcancelstatus(string permit)
        {           
            //string constr = ConfigurationManager.ConnectionStrings["Data source=GOD-PC;Initial catalog=KaizenTrial;Persist Security Info=True;user ID=sa;Password=123;Min Pool Size=10; Max Pool Size=20000"].ConnectionString;
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from OutHeaderTbl  where PermitId='" + permit + "'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                    }
                }
            }            
            //string path = Server.MapPath("PDF-Files");
            string path = @"C:\Users\Public\PDF-Files";
            string filename = path + "\\" + "CancelStatus.pdf";

            //Create new PDF document 

            PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create, FileAccess.ReadWrite));
            //Barcode genarate
            Response.ContentType = "application/pdf";
            PdfWriter writer = PdfWriter.GetInstance(
              document, Response.OutputStream
            );
            document.Open();


            //document.Add(rect);


            pgheight = document.PageSize.Height;



            // FONT            
            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1257, false);
            iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 10, iTextSharp.text.Font.NORMAL);

            BaseFont bfTimes1 = BaseFont.CreateFont(BaseFont.COURIER_BOLD, BaseFont.CP1257, false);
            iTextSharp.text.Font timesBold = new iTextSharp.text.Font(bfTimes1, 10, iTextSharp.text.Font.NORMAL);

            //page 1 //
            document.Add(new Paragraph("\n"));
            string testerwd = "                                                                     ";
            iTextSharp.text.Paragraph c3r = new iTextSharp.text.Paragraph(testerwd, times);
            c3r.Alignment = Element.ALIGN_LEFT;

            document.Add(c3r);
            // iTextShirp
            //Bitmap barCode = new Bitmap(1, 1);
            
            Barcode39 code128 = new Barcode39();



            

            string perName = "PERMIT NO : ";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = perName.Length;
            spceval1 = 69 - sapceval;
            for (int i = 0; i < 6; i++)
            {
                space = space + " ";
            }

            MyClass objdec = new MyClass();
            string imptrname = "", impname1 = "", impceui = "";
            string impget = "Select * from OutImporter where Code='" + dt.Rows[0]["ImporterCompanyCode"].ToString() + "'";
            objdec.dr = objdec.ret_dr("Select * from OutExporter where OutUserCode='" + dt.Rows[0]["ExporterCompanyCode"].ToString() + "'");
            // dr = cmd1.ExecuteReader();

            if (objdec.dr.Read())
            {
                imptrname = objdec.dr["OutUserName"].ToString();
                impname1 = objdec.dr["OutUserName1"].ToString();
                impceui = objdec.dr["OutUserCRUEI"].ToString();
            }

            string cmpname = imptrname + impname1;

            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = cmpname.Length;
            spceval1 = 69 - sapceval;
            //for (int i = 0; i < spceval1; i++)
            //{
            //    space = space + " ";
            //}
            //  Font fontH1 = new Font("Times New Roman", 10, Font.NORMAL);
            PdfPTable table = new PdfPTable(2);
            table.HorizontalAlignment = Element.ALIGN_LEFT;
            table.SpacingBefore = 30f;

            table.SpacingAfter = 30f;
            PdfPCell cell = new PdfPCell(new Phrase("CANCELLED PERMIT", times));
            cell.Colspan = 2;

            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("MESSAGE TYPE : OUT (WITH OR WITHOUT CERTIFICATE OF ORIGIN) UPDATE APPLICATION", times));
            table.AddCell(cell);
            // table.AddCell(cell);
            // string msgid = dt.Rows[0]["MSGId"].ToString();
            //  cell.Colspan = 1;
            cell = new PdfPCell(new Phrase("DECLARATION TYPE : " + dt.Rows[0]["DeclarationType"].ToString(), times));
            table.AddCell(cell);
            // cell.Colspan = 2;


            // table.AddCell(cell);
            string dd = "COMPANY NAME:" + imptrname
                                     + impname1;            
            cell = new PdfPCell(new Phrase(dd, times));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("DATE:" + dt.Rows[0]["TouchTime"].ToString(), times));
            table.AddCell(cell);

            //   table.AddCell(cell);

            cell.Colspan = 2;
            cell = new PdfPCell(new Phrase("COMPANY UEN:" + impceui, times));

            table.AddCell(cell);
            string msgid = dt.Rows[0]["MSGId"].ToString();
            cell = new PdfPCell(new Phrase("MESSAGE ID: " + msgid, times));
            table.AddCell(cell);


            MyClass lodobj = new MyClass();
            string lodportName = "";

            string lodport = "Select * from LoadingPort where PortCode='" + dt.Rows[0]["LoadingPortCode"].ToString().ToUpper() + "'";
            lodobj.dr = lodobj.ret_dr(lodport);
            if (lodobj.dr.HasRows)
            {
                while (lodobj.dr.Read())
                {
                    lodportName = lodobj.dr["PortName"].ToString().ToUpper();
                }
            }



            cell.Colspan = 2;

            cell = new PdfPCell(new Phrase("PORT OF LOADING:" + lodportName, times));

            table.AddCell(cell);
            //  string msgid = dt.Rows[0]["MSGId"].ToString();
            cell = new PdfPCell(new Phrase("PERMIT NUMBER: " + dt.Rows [0]["PermitNumber"].ToString().ToUpper(), times));
            table.AddCell(cell);


            

            table.AddCell(cell);
            //  string msgid = dt.Rows[0]["MSGId"].ToString();
            cell = new PdfPCell(new Phrase("PREV PERMIT: " + dt.Rows[0]["PreviousPermit"].ToString(), times));
            table.AddCell(cell);

            cell.Colspan = 2;

            cell = new PdfPCell(new Phrase("DESTINATION CITY: " + dt.Rows[0]["FinalDestinationCountry"].ToString(), times));

            table.AddCell(cell);
            //  string msgid = dt.Rows[0]["MSGId"].ToString();
            cell = new PdfPCell(new Phrase("ARRIVAL DATE: " + dt.Rows[0]["ArrivalDate"].ToString(), times));
            table.AddCell(cell);


            string[] tid = dt.Rows[0]["InwardTransportMode"].ToString().Split(':');
             string transportid = "";
            if (dt.Rows[0]["InwardTransportMode"].ToString() == "1: Sea")
            {
                transportid = dt.Rows[0]["VesselName"].ToString();
            }
            else if (dt.Rows[0]["InwardTransportMode"].ToString() == "4: Air")
            {
                transportid = dt.Rows[0]["FlightNO"].ToString();
            }
            else
            {
                transportid = dt.Rows[0]["TransportId"].ToString();
            }

            cell.Colspan = 2;

            cell = new PdfPCell(new Phrase("IN TRANSPORT ID: " + transportid.ToUpper (), times));

            table.AddCell(cell);
            //  string msgid = dt.Rows[0]["MSGId"].ToString();
            cell = new PdfPCell(new Phrase("DEPARTURE DATE: " + dt.Rows[0]["DepartureDate"].ToString(), times));
            table.AddCell(cell);



            string convey = "";
            if (dt.Rows[0]["InwardTransportMode"].ToString() == "1: Sea")
            {
                convey = dt.Rows[0]["VoyageNumber"].ToString();
            }
            else if (dt.Rows[0]["InwardTransportMode"].ToString() == "4: Air")
            {
                convey = dt.Rows[0]["AircraftRegNo"].ToString();
            }
            else
            {
                convey = dt.Rows[0]["ConveyanceRefNo"].ToString();
            }

            cell.Colspan = 2;

            cell = new PdfPCell(new Phrase("CONVEYANCE REF: " + convey, times));

            table.AddCell(cell);
            //  string msgid = dt.Rows[0]["MSGId"].ToString();
            cell = new PdfPCell(new Phrase("NUMBER OF ITEMS: " + dt.Rows[0]["NumberOfItems"].ToString(), times));
            table.AddCell(cell);



            // MyClass lodobj1 = new MyClass();
            string mawb = "";
            if (dt.Rows[0]["InwardTransportMode"].ToString() == "1: Sea")
            {
                mawb = dt.Rows[0]["OceanBillofLadingNo"].ToString();
            }
            else if (dt.Rows[0]["InwardTransportMode"].ToString() == "4: Air")
            {
                mawb = dt.Rows[0]["MasterAirwayBill"].ToString();
            }


            cell.Colspan = 2;

            cell = new PdfPCell(new Phrase("MAWB/OBL:" + mawb, times));

            table.AddCell(cell);
            string ttlouterpack = dt.Rows[0]["TotalOuterPackUOM"].ToString() + " / " + dt.Rows[0]["TotalOuterPack"].ToString();
            cell = new PdfPCell(new Phrase("TOTAL OUTER PK: " + ttlouterpack, times));
            table.AddCell(cell);




            string grossgst = dt.Rows[0]["TotalGrossWeight"].ToString() + " / " + dt.Rows[0]["TotalGrossWeightUOM"].ToString();

            string[] outtid = dt.Rows[0]["OutwardTransportMode"].ToString().Split(':');


            string outtransportid = "";
            if (dt.Rows[0]["OutwardTransportMode"].ToString() == "1: Sea")
            {
                outtransportid = dt.Rows[0]["OutVesselName"].ToString();
            }
            else if (dt.Rows[0]["OutwardTransportMode"].ToString() == "4: Air")
            {
                outtransportid = dt.Rows[0]["OutFlightNO"].ToString();
            }
            else
            {
                outtransportid = dt.Rows[0]["OutTransportId"].ToString();
            }


            cell.Colspan = 2;

            cell = new PdfPCell(new Phrase("OUT TRANSPORT ID:" + outtransportid.ToUpper (), times));

            table.AddCell(cell);
            //  string msgid = dt.Rows[0]["MSGId"].ToString();
            cell = new PdfPCell(new Phrase("TOTAL GROSS WGT: " + grossgst, times));
            table.AddCell(cell);



            string outconvey = "";
            if (dt.Rows[0]["OutwardTransportMode"].ToString() == "1: Sea")
            {
                outconvey = dt.Rows[0]["OutVoyageNumber"].ToString();
            }
            else if (dt.Rows[0]["OutwardTransportMode"].ToString() == "4: Air")
            {
                outconvey = dt.Rows[0]["OutAircraftRegNo"].ToString();
            }
            else
            {
                outconvey = dt.Rows[0]["OutConveyanceRefNo"].ToString();
            }





            cell.Colspan = 2;

            cell = new PdfPCell(new Phrase("CONVEYANCEREF: " + outconvey, times));

            table.AddCell(cell);
            //  string msgid = dt.Rows[0]["MSGId"].ToString();o
            cell = new PdfPCell(new Phrase("TOTAL CIFFOB VAL: $ " + dt.Rows[0]["TotalCIFFOBValue"].ToString(), times));
            table.AddCell(cell);


            string outmawb = "";
            if (dt.Rows[0]["OutwardTransportMode"].ToString() == "1: Sea")
            {
                outmawb = dt.Rows[0]["OutOceanBillofLadingNo"].ToString();
            }
            else if (dt.Rows[0]["OutwardTransportMode"].ToString() == "4: Air")
            {
                outmawb = dt.Rows[0]["OutMasterAirwayBill"].ToString();
            }


            //cell.Colspan = 2;

            cell = new PdfPCell(new Phrase("MAWB/OBL: " + outmawb, times));


            table.AddCell(cell);

            //  MyClass lodobj = new MyClass();
            string por = "";

            string por1 = "Select * from ReleaseLocation where Code='" + dt.Rows[0]["ReleaseLocation"].ToString().ToUpper() + "'";
            lodobj.dr = lodobj.ret_dr(por1);
            if (lodobj.dr.HasRows)
            {
                while (lodobj.dr.Read())
                {
                    por = lodobj.dr["Description"].ToString().ToUpper();
                }
            }



            string pol = "";

            string pol1 = "Select * from ReceiptLocation where Code='" + dt.Rows[0]["RecepitLocation"].ToString().ToUpper() + "'";
            lodobj.dr = lodobj.ret_dr(pol1);
            if (lodobj.dr.HasRows)
            {
                while (lodobj.dr.Read())
                {
                    pol = lodobj.dr["Description"].ToString().ToUpper();
                }
            }


            //  string msgid = dt.Rows[0]["MSGId"].ToString();
            cell = new PdfPCell(new Phrase("PL OF RELEASE: " + por, times));
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase("PL OF RECEIPT:" + pol, times));

            table.AddCell(cell);
            //  string msgid = dt.Rows[0]["MSGId"].ToString();
            cell = new PdfPCell(new Phrase("TRADER REMARKS: " + dt.Rows[0]["TradeRemarks"].ToString(), times));
            table.AddCell(cell);


            document.Add(table);

            //document.Add(table);

            //

            PdfPTable table1 = new PdfPTable(2);

            //actual width of table in points

            table1.TotalWidth = 216f;

            //fix the absolute width of the table

            //   table1.LockedWidth = true;



            //relative col widths in proportions - 1/3 and 2/3

            float[] widths = new float[] { 1f, 5f };

            table1.SetWidths(widths);

            table1.HorizontalAlignment = 0;

            //leave a gap before and after the table

            table1.SpacingBefore = 10f;

            table1.SpacingAfter = 10f;



            PdfPCell cell1 = new PdfPCell(new Phrase("CANCEL REASON", times));

            cell1.Colspan = 3;

            cell1.Border = 0;


            cell1.HorizontalAlignment = 1;

            table1.AddCell(cell1);


            cell1.Colspan = 2;
            cell1 = new PdfPCell(new Phrase("REASON OF CANCEL", times));
            table1.AddCell(cell1);

            cell1 = new PdfPCell(new Phrase("DESCRIPTION", times));
            table1.AddCell(cell1);

            //cell1 = new PdfPCell(new Phrase("Description", times));
            //table1.AddCell(cell1);

            //reject desc


            string rej = "select * from OutCancel  where Permitno='" + dt.Rows[0]["PermitNumber"].ToString() + "'";
            lodobj.dr = lodobj.ret_dr(rej);
            if (lodobj.dr.HasRows)
            {
                while (lodobj.dr.Read())
                {
                    string[] roc = lodobj.dr["ResonForCancel"].ToString().Split(':');
                    cell1 = new PdfPCell(new Phrase(roc[0].ToString().ToUpper (), times));
                    table1.AddCell(cell1);
                    cell1 = new PdfPCell(new Phrase(lodobj.dr["ResonForCancel"].ToString().ToUpper (), times));
                    table1.AddCell(cell1);
                    //cell1 = new PdfPCell(new Phrase(lodobj.dr["ErrorDescription"].ToString(), times));
                    //table1.AddCell(cell1);

                }
            }



            PdfPTable table2 = new PdfPTable(2);

            //actual width of table in points

            table2.TotalWidth = 216f;

            //fix the absolute width of the table

            //   table1.LockedWidth = true;



            //relative col widths in proportions - 1/3 and 2/3

            float[] widths2 = new float[] { 1f, 5f };

            table2.SetWidths(widths);

            table2.HorizontalAlignment = 0;

            //leave a gap before and after the table

            table2.SpacingBefore = 10f;

            table2.SpacingAfter = 10f;


            PdfPCell cell12 = new PdfPCell(new Phrase("CANCEL REASON", times));

            cell12.Colspan = 3;

            cell12.Border = 0;


            cell12.HorizontalAlignment = 1;

            table2.AddCell(cell12);
            cell12.Colspan = 2;
            cell12 = new PdfPCell(new Phrase("CONDITION CODE", times));
            table2.AddCell(cell12);

            cell12 = new PdfPCell(new Phrase("CONDITION DESCRIPTION", times));
            table2.AddCell(cell12);



            //cell1 = new PdfPCell(new Phrase("Description", times));
            //table1.AddCell(cell1);

            //reject desc


            string rej1 = "select * from OutCancelPermit  where PermitNumber='" + dt.Rows[0]["PermitNumber"].ToString() + "'";
            lodobj.dr = lodobj.ret_dr(rej1);
            if (lodobj.dr.HasRows)
            {
                while (lodobj.dr.Read())
                {
                    string[] roc = lodobj.dr["ConditionCde"].ToString().Split(':');
                    cell12 = new PdfPCell(new Phrase(roc[0].ToString().ToUpper (), times));
                    table2.AddCell(cell12);
                    cell12 = new PdfPCell(new Phrase(lodobj.dr["ConditionDes"].ToString().ToUpper (), times));
                    table2.AddCell(cell12);
                    //cell1 = new PdfPCell(new Phrase(lodobj.dr["ErrorDescription"].ToString(), times));
                    //table1.AddCell(cell1);

                }
            }



            //using (SqlConnection con1 = new SqlConnection(constr))
            //{
            //    using (SqlCommand cmd11 = new SqlCommand("select ErrorID,ErrorDescription from RejectStatus  where MsgID='" + dt.Rows [0]["MSGId"].ToString () + "'"))
            //    {

            //            cmd11.Connection = con;
            //            using (SqlDataReader rdr = cmd11.ExecuteReader())
            //            {
            //                while (rdr.Read())
            //                {

            //                    table1.AddCell(rdr[0].ToString());

            //                    table1.AddCell(rdr[1].ToString());

            //                }
            //            }
            //          //  sda1.SelectCommand = cmd11;
            //           // sda1.Fill(dt);

            //    }
            //}

            document.Add(table1);
            document.Add(table2);

            document.Close();
            byte[] bytes = File.ReadAllBytes(filename);

            using (MemoryStream stream = new MemoryStream())
            {
                PdfReader reader = new PdfReader(bytes);
                using (PdfStamper stamper = new PdfStamper(reader, stream))
                {
                    int pages = reader.NumberOfPages;
                    for (int i = 1; i <= pages; i++)
                    {
                        if (i == 1)
                        {
                            ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_RIGHT, new Phrase("PG  : " + i.ToString() + " OF " + pages, times), 541f, 817f, 0);
                        }
                        else
                        {
                            ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_RIGHT, new Phrase("PG  : " + i.ToString() + " OF " + pages, times), 541f, 817f, 0);
                        }
                    }
                }
                bytes = stream.ToArray();

            }


            File.WriteAllBytes(filename, bytes);
            ShowPdf(filename);
        }

        protected void btnCanSta_Click(object sender, EventArgs e)
        {
            string str = string.Empty;
            string strname = string.Empty;
            string permitid = null;
            string status = "";
            foreach (GridViewRow gvrow in GridInPayment.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("CheckBox1");
                if (chk != null & chk.Checked)
                {
                    Label labelProductID = (Label)gvrow.FindControl("lblPermitNo");
                    Label statustype = (Label)gvrow.FindControl("lblStatus");
                    permitid = labelProductID.Text;
                    MyClass obj2 = new MyClass();
                    obj2.dr = obj2.ret_dr("Select Status from OutHeaderTbl where PermitId='" + permitid + "'");
                    if (obj2.dr.HasRows)
                    {
                        while (obj2.dr.Read())
                        {
                            status = obj2.dr["Status"].ToString();
                        }
                    }

                    if (status == "CNL")
                    {
                        LoadCCPPrintcancelstatus(permitid);
                    }

                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string str = string.Empty;
            string strname = string.Empty;
            string permitid = null;
            string status = "";
            foreach (GridViewRow gvrow in GridInPayment.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("CheckBox1");
                if (chk != null & chk.Checked)
                {
                    Label labelProductID = (Label)gvrow.FindControl("lblPermitNo");
                    Label statustype = (Label)gvrow.FindControl("lblCerDtlType1");
                    permitid = labelProductID.Text;
                    strname = statustype.Text;
                    if (strname == "1 : Generalised System of Preferences (GSP) Form A" || strname == "4 : Ordinary Certificate of Origin" || strname == "18 : Preferential Certificate of Origin for FTA")
                    {
                        LoadCooPrint1(permitid);
                    }
                    else
                    {
                        LoadCooPrint(permitid);
                    }

                }
            }
        }
        private void LoadCooPrint1(string permitid)
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from OutHeaderTbl  where PermitId='" + permitid + "'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                    }
                }
            }

            var folder = @"C:\Users\Public\KaizenCCp";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            //string path = @"C:\Kaizen\IPTDEC.xml";
            string path = @"C:\Users\Public\KaizenCCp";
            string filename = path + "\\InpaymentCCP" + PermID + ".pdf";
            // Create a file to write to.
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            int lastcunt = 0;
            List<string> lines = new List<string>();
            List<string> lines1 = new List<string>();
            //Create new PDF document 
            iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 30f, 40f, 10f, 10f);
            PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create, FileAccess.ReadWrite));

            //Barcode genarate
            Response.ContentType = "application/pdf";
            PdfWriter writer = PdfWriter.GetInstance(
              document, Response.OutputStream
            );
            document.Open();
            PdfContentByte cb = writer.DirectContent;
            // FONT
            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1257, false);
            iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 7);

            BaseFont bfTimes1 = BaseFont.CreateFont(BaseFont.COURIER_BOLD, BaseFont.CP1257, false);
            iTextSharp.text.Font timesBold = new iTextSharp.text.Font(bfTimes1, 8);

            //page 1 //
            document.Add(new Paragraph("\n"));


            //document.Add(lblImg.Text.ToString());

            //document.Add(new Paragraph("\n"));
            //document.Add(new Paragraph("\n"));
            //document.Add(new Paragraph("\n"));

            string permit1 = "ANNEX 7";
            iTextSharp.text.Paragraph p1 = new iTextSharp.text.Paragraph(permit1, timesBold);
            //p1.Alignment = Element.ALIGN_CENTER;
            //document.Add(p1);

            //document.Add(new Paragraph(""));

            //permit1 = "Original (Duplicate/Triplicate)";
            //p1 = new iTextSharp.text.Paragraph(permit1, timesBold);
            //p1.Alignment = Element.ALIGN_CENTER;
            //document.Add(p1);

            document.Add(new Paragraph("\n"));

            string imptrname = "";
            string space = "", space1 = "";
            int sapceval = 0, spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            //permit1 = "Job No.";
            //p1 = new iTextSharp.text.Paragraph(space + permit1, times);
            //p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            imptrname = "  1. Exporter (Name & Address)";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "Job No. " + dt.Rows[0]["JobId"].ToString();
            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            MyClass objdec = new MyClass();
            string imptrname2 = "", impname1 = "", impceui = "", impadd = "";
            objdec.dr = objdec.ret_dr("Select * from OutExporter where Code='" + dt.Rows[0]["ExporterCompanyCode"].ToString() + "'");
            // dr = cmd1.ExecuteReader();

            if (objdec.dr.Read())
            {
                imptrname2 = "  " + objdec.dr["OutUserName"].ToString();
                impname1 = "  " + objdec.dr["OutUserAddress"].ToString();
                impceui = "  " + objdec.dr["OutUserAddress1"].ToString();
                impadd = "  " + objdec.dr["OutUserCity"].ToString();
            }

            imptrname = imptrname2;
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "";
            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            imptrname = impname1;
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "";
            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            imptrname = impceui;
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "";
            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            imptrname = impadd;
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "";
            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            //document.Add(new Paragraph("\n"));

            permit1 = "  ";
            p1 = new iTextSharp.text.Paragraph(permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            imptrname = "  2. Consignee (Name, Full Address & Country)";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "           (GSP) FORM A";
            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            objdec = new MyClass();
            imptrname2 = ""; impname1 = ""; impceui = ""; impadd = "";
            objdec.dr = objdec.ret_dr("Select * from OutConsignee where ConsigneeCode='" + dt.Rows[0]["CONSIGNEECode"].ToString() + "'");
            // dr = cmd1.ExecuteReader();

            if (objdec.dr.Read())
            {
                imptrname2 = "  " + objdec.dr["ConsigneeName"].ToString();
                impname1 = "  " + objdec.dr["ConsigneeAddress"].ToString();
                impceui = "  " + objdec.dr["ConsigneeAddress1"].ToString();
                impadd = "  " + objdec.dr["ConsigneeCity"].ToString();
            }

            imptrname = imptrname2;
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "";
            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            imptrname = impname1;
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "";
            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);


            imptrname = impceui;
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "";
            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            imptrname = impadd;
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "";
            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            permit1 = "    ";
            p1 = new iTextSharp.text.Paragraph(permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);


            //document.Add(new Paragraph("\n"));

            space1 = "";
            sapceval = 0; spceval1 = 0;
            spceval1 = 10 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }

            imptrname = "  3 Departure Date              " + space1 + dt.Rows[0]["DepartureDate"].ToString();
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "8 DECLARATION BY THE EXPORTER";
            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            document.Add(new Paragraph("\n"));

            string typename = "";
            if (dt.Rows[0]["OutwardTransportMode"].ToString() == "3 : Road")
            {
                typename = dt.Rows[0]["OutTransportId"].ToString();
            }
            else if (dt.Rows[0]["OutwardTransportMode"].ToString() == "1 : Sea")
            {
                typename = dt.Rows[0]["OutVesselName"].ToString();
            }
            else if (dt.Rows[0]["OutwardTransportMode"].ToString() == "4 : Air")
            {
                typename = dt.Rows[0]["OutFlightNO"].ToString();
            }
            imptrname = "  4 Vessel's Name/Flight No.    " + space1 + typename;
            space = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "";
            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            document.Add(new Paragraph("\n"));

            imptrname = "  5 Port of Discharge           " + space1 + dt.Rows[0]["DischargePort"].ToString();
            space = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = " ";
            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            document.Add(new Paragraph("\n"));

            imptrname = "  6 Country of Final Destination" + space1 + dt.Rows[0]["FinalDestinationCountry"].ToString();
            space = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "";
            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            permit1 = "  ";
            p1 = new iTextSharp.text.Paragraph(permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            //document.Add(new Paragraph("\n"));

            string coocuntry = "";
            objdec = new MyClass();
            imptrname2 = ""; impname1 = ""; impceui = ""; impadd = "";
            objdec.dr = objdec.ret_dr("Select * from OutItemDtl  where PermitId='" + permitid + "'");
            // dr = cmd1.ExecuteReader();            
            if (objdec.dr.Read())
            {
                //coocuntry = objdec.dr["OriginCriterion"].ToString();
            }

            imptrname = "  7 Country of Origin of Goods  " + space1 + coocuntry;
            space = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }



            permit1 = "";
            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            permit1 = "   ";
            p1 = new iTextSharp.text.Paragraph(permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            //document.Add(new Paragraph("\n"));           

            imptrname = "9 Marks and numbers on";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 30 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "10 No. & Kind of Packages, Description of Goods";
            space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = permit1.Length;
            spceval1 = 60 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }

            string permit2 = "11 Quantity & Unit";
            string space2 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = permit2.Length;
            spceval1 = 35 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space2 = space2 + " ";
            }

            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1 + space1 + permit2, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            imptrname = "";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 30 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "(including brand names if necessary)";
            space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = permit1.Length;
            spceval1 = 60 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }

            permit2 = "";
            space2 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = permit2.Length;
            spceval1 = 35 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space2 = space2 + " ";
            }

            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1 + space1 + permit2, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);


            permit2 = "  ";
            p1 = new iTextSharp.text.Paragraph(permit2, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            objdec = new MyClass();
            imptrname2 = ""; impname1 = ""; impceui = ""; impadd = "";
            objdec.dr = objdec.ret_dr("Select * from OutItemDtl  where PermitId='" + permitid + "'");
            // dr = cmd1.ExecuteReader();
            int ii = 0;
            int linecunt = 0;
            if (objdec.dr.Read())
            {
                int cunt = 0;
                int n = 0;
                int l = 0;
                int partLength = 12;
                string sentence = "  " + objdec.dr["ShippingMarks1"].ToString() + " " + objdec.dr["ShippingMarks2"].ToString() + " " + objdec.dr["ShippingMarks3"].ToString() + " " + objdec.dr["ShippingMarks4"].ToString();
                sentence = sentence.Replace("\n", " ");
                lines =
                    sentence
                        .Split(' ')
                        .Aggregate(new[] { "" }.ToList(), (a, x) =>
                        {
                            var last = a[a.Count - 1];
                            if ((last + " " + x).Length > partLength)
                            {
                                a.Add(x);
                            }
                            else
                            {
                                a[a.Count - 1] = (last + " " + x).Trim();
                            }
                            return a;
                        });

                partLength = 35;
                string sentence1 = "  " + objdec.dr["CertificateDescription"].ToString();
                sentence1 = sentence1.Replace("\n", " ");
                lines1 =
                    sentence1
                        .Split(' ')
                        .Aggregate(new[] { "" }.ToList(), (a, x) =>
                        {
                            var last = a[a.Count - 1];
                            if ((last + " " + x).Length > partLength)
                            {
                                a.Add(x);
                            }
                            else
                            {
                                a[a.Count - 1] = (last + " " + x).Trim();
                            }
                            return a;
                        });

                if (lines.Count > lines1.Count)
                {
                    cunt = lines.Count;
                }
                else
                {
                    cunt = lines1.Count;
                }
                for (l = n; l < cunt; l++)
                {
                    if (linecunt < 30)
                    {
                        if (l < lines.Count)
                        {
                            imptrname = lines[l].ToString();
                        }
                        else
                        {
                            imptrname = " ";
                        }
                        space = ""; space1 = "";
                        sapceval = 0; spceval1 = 0;
                        sapceval = imptrname.Length;
                        spceval1 = 30 - sapceval;
                        for (int i = 0; i < spceval1; i++)
                        {
                            space = space + " ";
                        }

                        permit1 = lines1[l].ToString();
                        space1 = "";
                        sapceval = 0; spceval1 = 0;
                        sapceval = permit1.Length;
                        spceval1 = 60 - sapceval;
                        for (int i = 0; i < spceval1; i++)
                        {
                            space1 = space1 + " ";
                        }

                        if (l == 0)
                        {
                            permit2 = objdec.dr["CerItemQty"].ToString();
                            space2 = "";
                            sapceval = 0; spceval1 = 0;
                            sapceval = permit2.Length;
                            spceval1 = 35 - sapceval;
                            for (int i = 0; i < spceval1; i++)
                            {
                                space2 = space2 + " ";
                            }
                        }
                        else if (l == 1)
                        {
                            permit2 = objdec.dr["CerItemUOM"].ToString();
                            space2 = "";
                            sapceval = 0; spceval1 = 0;
                            sapceval = permit2.Length;
                            spceval1 = 35 - sapceval;
                            for (int i = 0; i < spceval1; i++)
                            {
                                space2 = space2 + " ";
                            }
                        }
                        else
                        {
                            permit2 = "  ";
                            space2 = "";
                            sapceval = 0; spceval1 = 0;
                            sapceval = permit2.Length;
                            spceval1 = 35 - sapceval;
                            for (int i = 0; i < spceval1; i++)
                            {
                                space2 = space2 + " ";
                            }
                        }

                        p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1 + space1 + permit2, times);
                        p1.Alignment = Element.ALIGN_LEFT;
                        document.Add(p1);

                        linecunt = linecunt + 1;
                    }
                }
            }
            if (linecunt < 30)
            {
                for (int m = linecunt; m < 30; m++)
                {
                    permit2 = "  ";
                    p1 = new iTextSharp.text.Paragraph(permit2, times);
                    p1.Alignment = Element.ALIGN_LEFT;
                    document.Add(p1);
                }
            }

            //document.Add(new Paragraph("\n"));
            //document.Add(new Paragraph("\n"));
            //document.Add(new Paragraph("\n"));
            //document.Add(new Paragraph("\n"));
            //document.Add(new Paragraph("\n"));
            //document.Add(new Paragraph("\n"));
            //document.Add(new Paragraph("\n"));
            //document.Add(new Paragraph("\n"));
            //document.Add(new Paragraph("\n"));
            //document.Add(new Paragraph("\n"));
            //document.Add(new Paragraph("\n"));
            //document.Add(new Paragraph("\n"));
            //document.Add(new Paragraph("\n"));
            //document.Add(new Paragraph("\n"));
            //document.Add(new Paragraph("\n"));
            //document.Add(new Paragraph("\n"));
            //document.Add(new Paragraph("\n"));                        


            imptrname = "12. CERTIFICATION BY THE COMPETENT AUTHORITY";

            p1 = new iTextSharp.text.Paragraph(imptrname, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            document.Add(new Paragraph("\n"));

            imptrname = "We hereby certify that evidence has been produced to satisfy us that the goods specified above originate in the country shown in box 7";
            p1 = new iTextSharp.text.Paragraph(imptrname, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            iTextSharp.text.Rectangle rect1 = new iTextSharp.text.Rectangle(30, 30, 570, 780);
            rect1.Border = iTextSharp.text.Rectangle.BOX;
            rect1.BorderWidth = 0.5f;
            rect1.BorderColor = new BaseColor(Color.Black);
            document.Add(rect1);

            iTextSharp.text.Rectangle rect2 = new iTextSharp.text.Rectangle(30, 660, 570, 780);
            rect2.Border = iTextSharp.text.Rectangle.BOX;
            rect2.BorderWidth = 0.5f;
            rect2.BorderColor = new BaseColor(Color.Black);
            document.Add(rect2);

            iTextSharp.text.Rectangle rect3 = new iTextSharp.text.Rectangle(30, 530, 570, 780);
            rect3.Border = iTextSharp.text.Rectangle.BOX;
            rect3.BorderWidth = 0.5f;
            rect3.BorderColor = new BaseColor(Color.Black);
            document.Add(rect3);

            iTextSharp.text.Rectangle rect = new iTextSharp.text.Rectangle(30, 720, 295, 780);
            rect.Border = iTextSharp.text.Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = new BaseColor(Color.Black);
            document.Add(rect);

            iTextSharp.text.Rectangle rect4 = new iTextSharp.text.Rectangle(30, 660, 295, 780);
            rect4.Border = iTextSharp.text.Rectangle.BOX;
            rect4.BorderWidth = 0.5f;
            rect4.BorderColor = new BaseColor(Color.Black);
            document.Add(rect4);

            iTextSharp.text.Rectangle rect5 = new iTextSharp.text.Rectangle(30, 635, 295, 780);
            rect5.Border = iTextSharp.text.Rectangle.BOX;
            rect5.BorderWidth = 0.5f;
            rect5.BorderColor = new BaseColor(Color.Black);
            document.Add(rect5);

            iTextSharp.text.Rectangle rect6 = new iTextSharp.text.Rectangle(30, 610, 295, 780);
            rect6.Border = iTextSharp.text.Rectangle.BOX;
            rect6.BorderWidth = 0.5f;
            rect6.BorderColor = new BaseColor(Color.Black);
            document.Add(rect6);

            iTextSharp.text.Rectangle rect7 = new iTextSharp.text.Rectangle(30, 580, 295, 780);
            rect7.Border = iTextSharp.text.Rectangle.BOX;
            rect7.BorderWidth = 0.5f;
            rect7.BorderColor = new BaseColor(Color.Black);
            document.Add(rect7);

            iTextSharp.text.Rectangle rect8 = new iTextSharp.text.Rectangle(30, 550, 295, 780);
            rect8.Border = iTextSharp.text.Rectangle.BOX;
            rect8.BorderWidth = 0.5f;
            rect8.BorderColor = new BaseColor(Color.Black);
            document.Add(rect8);

            iTextSharp.text.Rectangle rect9 = new iTextSharp.text.Rectangle(30, 530, 295, 780);
            rect9.Border = iTextSharp.text.Rectangle.BOX;
            rect9.BorderWidth = 0.5f;
            rect9.BorderColor = new BaseColor(Color.Black);
            document.Add(rect9);

            iTextSharp.text.Rectangle rect10 = new iTextSharp.text.Rectangle(30, 500, 570, 780);
            rect10.Border = iTextSharp.text.Rectangle.BOX;
            rect10.BorderWidth = 0.5f;
            rect10.BorderColor = new BaseColor(Color.Black);
            document.Add(rect10);

            iTextSharp.text.Rectangle rect11 = new iTextSharp.text.Rectangle(30, 200, 570, 500);
            rect11.Border = iTextSharp.text.Rectangle.BOX;
            rect11.BorderWidth = 0.5f;
            rect11.BorderColor = new BaseColor(Color.Black);
            document.Add(rect11);


            document.Close();
            //byte[] bytes = File.ReadAllBytes(filename);

            //using (MemoryStream stream = new MemoryStream())
            //{
            //    PdfReader reader = new PdfReader(bytes);
            //    using (PdfStamper stamper = new PdfStamper(reader, stream))
            //    {
            //        int pages = reader.NumberOfPages;
            //        for (int i = 1; i <= pages; i++)
            //        {
            //            if (i == 1)
            //            {
            //                ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_RIGHT, new Phrase("Page " + i.ToString() + " OF " + pages, times), 513f, 707f, 0);
            //            }
            //            else
            //            {
            //                ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_RIGHT, new Phrase("Page " + i.ToString() + " OF " + pages, times), 508f, 805f, 0);
            //            }
            //        }
            //    }
            //    bytes = stream.ToArray();

            //}
            //File.WriteAllBytes(filename, bytes);
            ShowPdf(filename);
        }
        private void LoadCooPrint(string permitid)
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from OutHeaderTbl  where PermitId='" + permitid + "'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                    }
                }
            }

            var folder = @"C:\Users\Public\KaizenCCp";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            //string path = @"C:\Kaizen\IPTDEC.xml";
            string path = @"C:\Users\Public\KaizenCCp";
            string filename = path + "\\OutCCP" + PermID + ".pdf";
            // Create a file to write to.
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            int lastcunt = 0;
            List<string> lines = new List<string>();
            List<string> lines1 = new List<string>();
            //Create new PDF document 
            iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 30f, 40f, 10f, 10f);
            PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create, FileAccess.ReadWrite));

            //Barcode genarate
            Response.ContentType = "application/pdf";
            PdfWriter writer = PdfWriter.GetInstance(
              document, Response.OutputStream
            );
            document.Open();
            PdfContentByte cb = writer.DirectContent;
            // FONT
            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1257, false);
            iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 7);

            BaseFont bfTimes1 = BaseFont.CreateFont(BaseFont.COURIER_BOLD, BaseFont.CP1257, false);
            iTextSharp.text.Font timesBold = new iTextSharp.text.Font(bfTimes1, 8);

        PageNew:
            //page 1 //
            document.Add(new Paragraph("\n"));

            string ComName = "                ASEAN TRADE IN GOODS AGREEMENT /";
            string ComName1 = "             ASEAN INDUSTRIAL COOPERATION SCHEME";
            string ComName2 = "                     CERTIFICATE OF ORIGIN";

            //document.Add(lblImg.Text.ToString());

            //document.Add(new Paragraph("\n"));
            //document.Add(new Paragraph("\n"));
            //document.Add(new Paragraph("\n"));

            string permit1 = "ANNEX 7";
            iTextSharp.text.Paragraph p1 = new iTextSharp.text.Paragraph(permit1, timesBold);
            p1.Alignment = Element.ALIGN_CENTER;
            document.Add(p1);

            document.Add(new Paragraph(""));

            permit1 = "Original (Duplicate/Triplicate)";
            p1 = new iTextSharp.text.Paragraph(permit1, timesBold);
            p1.Alignment = Element.ALIGN_CENTER;
            document.Add(p1);

            document.Add(new Paragraph("\n"));

            string imptrname = "  1.Goods consigned from (Exporter's business name,address,country)";
            string space = "", space1 = "";
            int sapceval = 0, spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "Reference No.  " + dt.Rows[0]["JobId"].ToString() + "";
            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            MyClass objdec = new MyClass();
            string imptrname2 = "", impname1 = "", impceui = "", impadd = "";
            objdec.dr = objdec.ret_dr("Select * from OutExporter where Code='" + dt.Rows[0]["ExporterCompanyCode"].ToString() + "'");
            // dr = cmd1.ExecuteReader();

            if (objdec.dr.Read())
            {
                imptrname2 = "  " + objdec.dr["OutUserName"].ToString();
                impname1 = "  " + objdec.dr["OutUserAddress"].ToString();
                impceui = "  " + objdec.dr["OutUserAddress1"].ToString();
                impadd = "  " + objdec.dr["OutUserCity"].ToString();
            }

            imptrname = imptrname2;
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "";
            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            imptrname = impname1;
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "";
            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            imptrname = impceui;
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = ComName;
            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            imptrname = impadd;
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = ComName1;
            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            imptrname = "";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = ComName2;
            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            imptrname = "";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "           (Combined Declaration and Certificate)";
            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            objdec = new MyClass();
            imptrname2 = ""; impname1 = ""; impceui = ""; impadd = "";
            objdec.dr = objdec.ret_dr("Select * from COConsignee where OutConsignee='" + dt.Rows[0]["CONSIGNEECode"].ToString() + "'");
            // dr = cmd1.ExecuteReader();

            if (objdec.dr.Read())
            {
                imptrname2 = "  " + objdec.dr["ConsigneeName"].ToString();
                impname1 = "  " + objdec.dr["ConsigneeAddress"].ToString();
                impceui = "  " + objdec.dr["ConsigneeAddress1"].ToString();
                impadd = "  " + objdec.dr["ConsigneeCity"].ToString();
            }

            imptrname = "  2.Goods consigned to (Consignee's name, address and country)";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "                           FORM D";
            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);


            imptrname = imptrname2;
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "                Issued in Singapore";
            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            imptrname = impname1;
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "  ";
            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);


            imptrname = impceui;
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "                  See Overleaf Notes";
            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            //permit1 = "           ";
            //p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            //p1.Alignment = Element.ALIGN_LEFT;
            //document.Add(p1);

            imptrname = impadd;
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "";
            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            permit1 = " ";
            p1 = new iTextSharp.text.Paragraph(permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            imptrname = "  3.Means of transport and route (as far as know)";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "4.for Official Use";
            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);


            permit1 = " ";
            p1 = new iTextSharp.text.Paragraph(permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            space1 = "";
            sapceval = 0; spceval1 = 0;
            spceval1 = 15 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }

            imptrname = "  Departure date             " + space1 + dt.Rows[0]["DepartureDate"].ToString();
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "        Preferential Treatment Given Under ASEAN";
            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);


            imptrname = "";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "        Trade in Goods Agreement";
            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            permit1 = "  ";
            p1 = new iTextSharp.text.Paragraph(permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            string typename = "";
            if (dt.Rows[0]["OutwardTransportMode"].ToString() == "3 : Road")
            {
                typename = dt.Rows[0]["OutTransportId"].ToString();
            }
            else if (dt.Rows[0]["OutwardTransportMode"].ToString() == "1 : Sea")
            {
                typename = dt.Rows[0]["OutVesselName"].ToString();
            }
            else if (dt.Rows[0]["OutwardTransportMode"].ToString() == "4 : Air")
            {
                typename = dt.Rows[0]["OutFlightNO"].ToString();
            }

            space1 = "";
            sapceval = 0; spceval1 = 0;
            spceval1 = 15 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }
            imptrname = "  Vessel's name/Aircraft etc." + space1 + typename;
            space = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "        Preferential Treatment Given Under ASEAN";
            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            imptrname = "";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "        Interestial Corperation Schems";
            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            spceval1 = 80 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }
            permit1 = " ";
            p1 = new iTextSharp.text.Paragraph(permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            space1 = "";
            sapceval = 0; spceval1 = 0;
            spceval1 = 15 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }

            imptrname = "  Port of Discharge          " + space1 + dt.Rows[0]["DischargePort"].ToString();
            space = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "        Preferential Treatment Not Given (Please";
            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            imptrname = "";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "        state reason/s)";
            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            document.Add(new Paragraph("\n"));

            imptrname = "";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "............................................";
            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            imptrname = "";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "Signature of Authorised Signatory of the Importing";
            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            imptrname = "";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "Country";
            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            permit1 = " ";
            p1 = new iTextSharp.text.Paragraph(permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            imptrname = "5.Item";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 10 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "6.Marks and";
            space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = permit1.Length;
            spceval1 = 15 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }

            string permit2 = "7.Number and type of packages,";
            string space2 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = permit2.Length;
            spceval1 = 40 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space2 = space2 + " ";
            }

            string permit3 = "8.Origin criterion";
            string space3 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = permit3.Length;
            spceval1 = 20 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space3 = space3 + " ";
            }

            string permit4 = "9.Gross weight or other";
            string space4 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = permit4.Length;
            spceval1 = 25 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space4 = space4 + " ";
            }

            string permit5 = "10.Number and";

            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1 + space1 + permit2 + space2 + permit3 + space3 + permit4 + space4 + permit5, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            imptrname = "  Number";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 10 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "  numbers on";
            space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = permit1.Length;
            spceval1 = 15 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }

            permit2 = "  description of goods (inculding";
            space2 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = permit2.Length;
            spceval1 = 40 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space2 = space2 + " ";
            }

            permit3 = "  (see Overleaf";
            space3 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = permit3.Length;
            spceval1 = 20 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space3 = space3 + " ";
            }

            permit4 = "  quantity and values ";
            space4 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = permit4.Length;
            spceval1 = 25 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space4 = space4 + " ";
            }

            permit5 = "  date of";

            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1 + space1 + permit2 + space2 + permit3 + space3 + permit4 + space4 + permit5, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            imptrname = "";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 10 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "  packages";
            space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = permit1.Length;
            spceval1 = 15 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }

            permit2 = "  quantity where appropriate and HS";
            space2 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = permit2.Length;
            spceval1 = 40 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space2 = space2 + " ";
            }

            permit3 = "  Notes)";
            space3 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = permit3.Length;
            spceval1 = 20 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space3 = space3 + " ";
            }

            permit4 = "  (FOB) where RVC";
            space4 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = permit4.Length;
            spceval1 = 25 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space4 = space4 + " ";
            }

            permit5 = "  invoices";

            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1 + space1 + permit2 + space2 + permit3 + space3 + permit4 + space4 + permit5, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            imptrname = "";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 10 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "";
            space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = permit1.Length;
            spceval1 = 15 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }

            permit2 = "  number of the importing country)";
            space2 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = permit2.Length;
            spceval1 = 40 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space2 = space2 + " ";
            }

            permit3 = "";
            space3 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = permit3.Length;
            spceval1 = 20 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space3 = space3 + " ";
            }

            permit4 = "  is applied";
            space4 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = permit4.Length;
            spceval1 = 25 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space4 = space4 + " ";
            }

            permit5 = "";

            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1 + space1 + permit2 + space2 + permit3 + space3 + permit4 + space4 + permit5, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            permit5 = " ";

            p1 = new iTextSharp.text.Paragraph(permit5, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            string coocuntry = "";
            objdec = new MyClass();
            imptrname2 = ""; impname1 = ""; impceui = ""; impadd = "";
            objdec.dr = objdec.ret_dr("Select * from OutItemDtl  where PermitId='" + permitid + "'");
            // dr = cmd1.ExecuteReader();
            int ii = 0;
            int linecunt = 0;
            if (objdec.dr.Read())
            {
                if (linecunt < 9)
                {
                    int n = 1;
                    int l = 1;
                    int cunt = 0;
                    if (lastcunt == 0)
                    {
                        ii = ii + 1;
                        imptrname = "  " + ii.ToString();
                        space = ""; space1 = "";
                        sapceval = 0; spceval1 = 0;
                        sapceval = imptrname.Length;
                        spceval1 = 10 - sapceval;
                        for (int i = 0; i < spceval1; i++)
                        {
                            space = space + " ";
                        }

                        if (string.IsNullOrWhiteSpace(coocuntry))
                        {
                            MyClass objdec1 = new MyClass();
                            objdec1.dr = objdec1.ret_dr("SELECT * FROM Country where CountryCode='" + objdec.dr["Contry"].ToString() + "'");
                            if (objdec1.dr.Read())
                            {
                                coocuntry = objdec1.dr["Description"].ToString();
                            }
                        }
                        int partLength = 12;
                        string sentence = "  " + objdec.dr["ShippingMarks1"].ToString().ToUpper() + "  " + objdec.dr["ShippingMarks2"].ToString().ToUpper() + "  " + objdec.dr["ShippingMarks3"].ToString().ToUpper() + "  " + objdec.dr["ShippingMarks4"].ToString().ToUpper();
                        sentence = sentence.Replace("\n", " ");
                        lines =
                            sentence
                                .Split(' ')
                                .Aggregate(new[] { "" }.ToList(), (a, x) =>
                                {
                                    var last = a[a.Count - 1];
                                    if ((last + " " + x).Length > partLength)
                                    {
                                        a.Add(x);
                                    }
                                    else
                                    {
                                        a[a.Count - 1] = (last + " " + x).Trim();
                                    }
                                    return a;
                                });

                        permit1 = lines[0].ToString();
                        space1 = "";
                        sapceval = 0; spceval1 = 0;
                        sapceval = permit1.Length;
                        spceval1 = 15 - sapceval;
                        for (int i = 0; i < spceval1; i++)
                        {
                            space1 = space1 + " ";
                        }

                        partLength = 35;
                        string sentence1 = "  " + objdec.dr["CertificateDescription"].ToString().ToUpper();
                        sentence1 = sentence1.Replace("\n", " ");
                        lines1 =
                            sentence1
                                .Split(' ')
                                .Aggregate(new[] { "" }.ToList(), (a, x) =>
                                {
                                    var last = a[a.Count - 1];
                                    if ((last + " " + x).Length > partLength)
                                    {
                                        a.Add(x);
                                    }
                                    else
                                    {
                                        a[a.Count - 1] = (last + " " + x).Trim();
                                    }
                                    return a;
                                });
                        permit2 = lines1[0].ToString();
                        space2 = "";
                        sapceval = 0; spceval1 = 0;
                        sapceval = permit2.Length;
                        spceval1 = 40 - sapceval;
                        for (int i = 0; i < spceval1; i++)
                        {
                            space2 = space2 + " ";
                        }

                        //permit3 = objdec.dr["OriginCriterion"].ToString().ToUpper();

                        permit3 = "";
                        space3 = "";
                        sapceval = 0; spceval1 = 0;
                        sapceval = permit3.Length;
                        spceval1 = 20 - sapceval;
                        for (int i = 0; i < spceval1; i++)
                        {
                            space3 = space3 + " ";
                        }

                        permit4 = objdec.dr["CerItemQty"].ToString() + " " + objdec.dr["CerItemUOM"].ToString().ToUpper();
                        space4 = "";
                        sapceval = 0; spceval1 = 0;
                        sapceval = permit4.Length;
                        spceval1 = 25 - sapceval;
                        for (int i = 0; i < spceval1; i++)
                        {
                            space4 = space4 + " ";
                        }

                        permit5 = objdec.dr["InvoiceNumber"].ToString().ToUpper();

                        p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1 + space1 + permit2 + space2 + permit3 + space3 + permit4 + space4 + permit5, times);
                        p1.Alignment = Element.ALIGN_LEFT;
                        document.Add(p1);

                        linecunt = linecunt + 1;

                    }
                    else
                    {
                        n = lastcunt;
                    }

                    if (lines.Count > lines1.Count)
                    {
                        cunt = lines.Count - 1;
                    }
                    else
                    {
                        cunt = lines1.Count - 1;
                    }
                    for (l = n; l < cunt; l++)
                    {
                        if (linecunt < 9)
                        {
                            imptrname = "  ";
                            space = ""; space1 = "";
                            sapceval = 0; spceval1 = 0;
                            sapceval = imptrname.Length;
                            spceval1 = 10 - sapceval;
                            for (int i = 0; i < spceval1; i++)
                            {
                                space = space + " ";
                            }

                            if (l < lines.Count)
                            {
                                permit1 = lines[l].ToString();
                            }
                            else
                            {
                                permit1 = " ";
                            }
                            space1 = "";
                            sapceval = 0; spceval1 = 0;
                            sapceval = permit1.Length;
                            spceval1 = 15 - sapceval;
                            for (int i = 0; i < spceval1; i++)
                            {
                                space1 = space1 + " ";
                            }


                            permit2 = lines1[l].ToString();
                            space2 = "";
                            sapceval = 0; spceval1 = 0;
                            sapceval = permit2.Length;
                            spceval1 = 40 - sapceval;
                            for (int i = 0; i < spceval1; i++)
                            {
                                space2 = space2 + " ";
                            }

                            if (l == 1)
                            {
                                permit3 = objdec.dr["PerOrgainCRI"].ToString() + " %";
                                string[] curcde = dt.Rows[0]["CurrencyCode"].ToString().Split(':');
                                permit4 = objdec.dr["ItemValue"].ToString() + " " + curcde[0].ToString();
                                permit5 = Convert.ToDateTime(objdec.dr["InvoiceDate"].ToString()).ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                permit3 = " ";
                                permit4 = " ";
                                permit5 = " ";
                            }

                            space3 = "";
                            sapceval = 0; spceval1 = 0;
                            sapceval = permit3.Length;
                            spceval1 = 20 - sapceval;
                            for (int i = 0; i < spceval1; i++)
                            {
                                space3 = space3 + " ";
                            }


                            space4 = "";
                            sapceval = 0; spceval1 = 0;
                            sapceval = permit4.Length;
                            spceval1 = 25 - sapceval;
                            for (int i = 0; i < spceval1; i++)
                            {
                                space4 = space4 + " ";
                            }



                            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1 + space1 + permit2 + space2 + permit3 + space3 + permit4 + space4 + permit5, times);
                            p1.Alignment = Element.ALIGN_LEFT;
                            document.Add(p1);

                            linecunt = linecunt + 1;
                            lastcunt = 0;
                        }
                        else
                        {
                            lastcunt = l;
                            break;
                            //return;
                        }
                    }
                }
                else
                {
                    lastcunt = linecunt;
                    return;
                }
            }

            if (linecunt < 9)
            {
                for (int m = linecunt; m < 9; m++)
                {
                    permit1 = " ";
                    p1 = new iTextSharp.text.Paragraph(permit1, times);
                    p1.Alignment = Element.ALIGN_LEFT;
                    document.Add(p1);
                }
            }
            //document.Add(new Paragraph("\n"));
            //document.Add(new Paragraph("\n"));
            //document.Add(new Paragraph("\n"));
            //document.Add(new Paragraph("\n"));
            //document.Add(new Paragraph("\n"));
            //document.Add(new Paragraph("\n"));            

            imptrname = "  11.Declaration by the exporter";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 68 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "12.Certification";

            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            //document.Add(new Paragraph("\n"));

            permit5 = " ";
            p1 = new iTextSharp.text.Paragraph(permit5, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            imptrname = "  The undersigned hereby declares that the above details and";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "  It is hereby certified, on the basis of control ";

            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            imptrname = "  statement are correct; that all the goods were produced in";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "  carried out, that the declaration by the exporter";

            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            imptrname = "  ";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "  is correct";

            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            permit1 = "  ";

            p1 = new iTextSharp.text.Paragraph(permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            imptrname = "              ...............................";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = " ";

            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            imptrname = "                  " + coocuntry;
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = " ";

            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            //document.Add(new Paragraph(""));

            permit1 = " ";

            p1 = new iTextSharp.text.Paragraph(permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            imptrname = "  and that they comply with the origin requirements";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = " ";

            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            imptrname = "  specified for these goods in the ASEAN Trade in";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = " ";

            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            imptrname = "  Goods Agreement for the goods exported to";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = " ";

            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            imptrname = "              ...............................";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = " ";

            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);
            string[] impcuntry = dt.Rows[0]["FinalDestinationCountry"].ToString().Split(':');
            imptrname = "                  " + impcuntry[1].ToString();
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = " ";

            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            document.Add(new Paragraph(""));

            imptrname = "              ...............................";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "         ...............................";

            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            imptrname = "                  Place and date, signature of";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "            Place and date, signature of";

            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            imptrname = "                    authorised signatory";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "                certifying authority";

            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);


            //iTextSharp.text.Rectangle rect = new iTextSharp.text.Rectangle(10, 10, 10, 10);
            //document.Add(rect);

            imptrname = "13";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 70 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "";

            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            imptrname = "     Third Country Invoicing";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 35 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "Exhibition";

            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            document.Add(new Paragraph("\n"));

            imptrname = "     Accumulation";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 35 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "De Minimis";

            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            document.Add(new Paragraph("\n"));

            imptrname = "     Back-to-Back CO";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 35 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "Issued Retroactiverly";

            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            document.Add(new Paragraph("\n"));

            imptrname = "     Partial Cumulation";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 30 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            permit1 = "";

            p1 = new iTextSharp.text.Paragraph(imptrname + space + permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);


            //iTextSharp.text.Rectangle rect = new iTextSharp.text.Rectangle(document.PageSize.Width-200f, 100f, 100f,100f);
            //document.Add(rect);

            //Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 150.0F, BaseColor.BLACK, Element.ALIGN_UNDEFINED, 1)));
            //document.Add(p);
            //iTextSharp.text.pdf.draw.LineSeparator line1 = new iTextSharp.text.pdf.draw.LineSeparator(1f, 60f, BaseColor.BLACK, Element.ALIGN_LEFT, 680);        

            //iTextSharp.text.pdf.draw.LineSeparator line2 = new iTextSharp.text.pdf.draw.LineSeparator(1f, 103f, BaseColor.BLACK, Element.ALIGN_LEFT, 610);
            //document.Add(new Chunk(line1));
            //document.Add(new Chunk(line2));

            //PdfContentByte contentByte = writer.DirectContent;
            //contentByte.SetLineWidth(1);
            //contentByte.MoveTo(0, 14);
            //contentByte.LineTo(document.PageSize.Width, 14);
            //contentByte.Stroke();

            iTextSharp.text.Rectangle rect1 = new iTextSharp.text.Rectangle(30, 30, 570, 780);
            rect1.Border = iTextSharp.text.Rectangle.BOX;
            rect1.BorderWidth = 0.5f;
            rect1.BorderColor = new BaseColor(Color.Black);
            document.Add(rect1);

            iTextSharp.text.Rectangle rect2 = new iTextSharp.text.Rectangle(30, 640, 570, 780);
            rect2.Border = iTextSharp.text.Rectangle.BOX;
            rect2.BorderWidth = 0.5f;
            rect2.BorderColor = new BaseColor(Color.Black);
            document.Add(rect2);

            iTextSharp.text.Rectangle rect3 = new iTextSharp.text.Rectangle(30, 475, 570, 780);
            rect3.Border = iTextSharp.text.Rectangle.BOX;
            rect3.BorderWidth = 0.5f;
            rect3.BorderColor = new BaseColor(Color.Black);
            document.Add(rect3);

            iTextSharp.text.Rectangle rect13 = new iTextSharp.text.Rectangle(320, 605, 340, 590);
            rect13.Border = iTextSharp.text.Rectangle.BOX;
            rect13.BorderWidth = 0.5f;
            rect13.BorderColor = new BaseColor(Color.Black);
            document.Add(rect13);

            iTextSharp.text.Rectangle rect14 = new iTextSharp.text.Rectangle(320, 575, 340, 560);
            rect14.Border = iTextSharp.text.Rectangle.BOX;
            rect14.BorderWidth = 0.5f;
            rect14.BorderColor = new BaseColor(Color.Black);
            document.Add(rect14);

            iTextSharp.text.Rectangle rect15 = new iTextSharp.text.Rectangle(320, 545, 340, 530);
            rect15.Border = iTextSharp.text.Rectangle.BOX;
            rect15.BorderWidth = 0.5f;
            rect15.BorderColor = new BaseColor(Color.Black);
            document.Add(rect15);

            //iTextSharp.text.Rectangle rect16 = new iTextSharp.text.Rectangle(260, 525, 280, 510);
            //rect16.Border = iTextSharp.text.Rectangle.BOX;
            //rect16.BorderWidth = 0.5f;
            //rect16.BorderColor = new BaseColor(Color.Black);
            //document.Add(rect16);

            iTextSharp.text.Rectangle rect4 = new iTextSharp.text.Rectangle(30, 475, 315, 780);
            rect4.Border = iTextSharp.text.Rectangle.BOX;
            rect4.BorderWidth = 0.5f;
            rect4.BorderColor = new BaseColor(Color.Black);
            document.Add(rect4);

            rect4 = new iTextSharp.text.Rectangle(30, 320, 570, 420);
            rect4.Border = iTextSharp.text.Rectangle.BOX;
            rect4.BorderWidth = 0.5f;
            rect4.BorderColor = new BaseColor(Color.Black);
            document.Add(rect4);

            iTextSharp.text.Rectangle rect5 = new iTextSharp.text.Rectangle(30, 475, 70, 320);
            rect5.Border = iTextSharp.text.Rectangle.BOX;
            rect5.BorderWidth = 0.5f;
            rect5.BorderColor = new BaseColor(Color.Black);
            document.Add(rect5);

            iTextSharp.text.Rectangle rect6 = new iTextSharp.text.Rectangle(70, 475, 130, 320);
            rect6.Border = iTextSharp.text.Rectangle.BOX;
            rect6.BorderWidth = 0.5f;
            rect6.BorderColor = new BaseColor(Color.Black);
            document.Add(rect6);

            iTextSharp.text.Rectangle rect7 = new iTextSharp.text.Rectangle(130, 475, 300, 320);
            rect7.Border = iTextSharp.text.Rectangle.BOX;
            rect7.BorderWidth = 0.5f;
            rect7.BorderColor = new BaseColor(Color.Black);
            document.Add(rect7);

            iTextSharp.text.Rectangle rect8 = new iTextSharp.text.Rectangle(300, 475, 380, 320);
            rect8.Border = iTextSharp.text.Rectangle.BOX;
            rect8.BorderWidth = 0.5f;
            rect8.BorderColor = new BaseColor(Color.Black);
            document.Add(rect8);

            iTextSharp.text.Rectangle rect9 = new iTextSharp.text.Rectangle(380, 475, 480, 320);
            rect9.Border = iTextSharp.text.Rectangle.BOX;
            rect9.BorderWidth = 0.5f;
            rect9.BorderColor = new BaseColor(Color.Black);
            document.Add(rect9);

            iTextSharp.text.Rectangle rect10 = new iTextSharp.text.Rectangle(480, 475, 570, 320);
            rect10.Border = iTextSharp.text.Rectangle.BOX;
            rect10.BorderWidth = 0.5f;
            rect10.BorderColor = new BaseColor(Color.Black);
            document.Add(rect10);

            iTextSharp.text.Rectangle rect11 = new iTextSharp.text.Rectangle(30, 30, 290, 320);
            rect11.Border = iTextSharp.text.Rectangle.BOX;
            rect11.BorderWidth = 0.5f;
            rect11.BorderColor = new BaseColor(Color.Black);
            document.Add(rect11);

            iTextSharp.text.Rectangle rect12 = new iTextSharp.text.Rectangle(30, 30, 290, 140);
            rect12.Border = iTextSharp.text.Rectangle.BOX;
            rect12.BorderWidth = 0.5f;
            rect12.BorderColor = new BaseColor(Color.Black);
            document.Add(rect12);

            iTextSharp.text.Rectangle rect17 = new iTextSharp.text.Rectangle(40, 125, 45, 120);
            rect17.Border = iTextSharp.text.Rectangle.BOX;
            rect17.BorderWidth = 0.5f;
            rect17.BorderColor = new BaseColor(Color.Black);
            document.Add(rect17);

            iTextSharp.text.Rectangle rect21 = new iTextSharp.text.Rectangle(168, 125, 173, 120);
            rect21.Border = iTextSharp.text.Rectangle.BOX;
            rect21.BorderWidth = 0.5f;
            rect21.BorderColor = new BaseColor(Color.Black);
            document.Add(rect21);

            iTextSharp.text.Rectangle rect18 = new iTextSharp.text.Rectangle(40, 97, 45, 92);
            rect18.Border = iTextSharp.text.Rectangle.BOX;
            rect18.BorderWidth = 0.5f;
            rect18.BorderColor = new BaseColor(Color.Black);
            document.Add(rect18);

            iTextSharp.text.Rectangle rect22 = new iTextSharp.text.Rectangle(168, 97, 173, 92);
            rect22.Border = iTextSharp.text.Rectangle.BOX;
            rect22.BorderWidth = 0.5f;
            rect22.BorderColor = new BaseColor(Color.Black);
            document.Add(rect22);

            iTextSharp.text.Rectangle rect19 = new iTextSharp.text.Rectangle(40, 70, 45, 65);
            rect19.Border = iTextSharp.text.Rectangle.BOX;
            rect19.BorderWidth = 0.5f;
            rect19.BorderColor = new BaseColor(Color.Black);
            document.Add(rect19);

            iTextSharp.text.Rectangle rect23 = new iTextSharp.text.Rectangle(168, 70, 173, 65);
            rect23.Border = iTextSharp.text.Rectangle.BOX;
            rect23.BorderWidth = 0.5f;
            rect23.BorderColor = new BaseColor(Color.Black);
            document.Add(rect23);

            iTextSharp.text.Rectangle rect20 = new iTextSharp.text.Rectangle(40, 40, 45, 35);
            rect20.Border = iTextSharp.text.Rectangle.BOX;
            rect20.BorderWidth = 0.5f;
            rect20.BorderColor = new BaseColor(Color.Black);
            document.Add(rect20);

            iTextSharp.text.Rectangle rect = new iTextSharp.text.Rectangle(30, 700, 315, 780);
            rect.Border = iTextSharp.text.Rectangle.BOX;
            rect.BorderWidth = 0.5f;
            rect.BorderColor = new BaseColor(Color.Black);
            document.Add(rect);

            if (lastcunt != 0)
            {
                document.NewPage();
                goto PageNew;
            }

            document.Close();
            //byte[] bytes = File.ReadAllBytes(filename);

            //using (MemoryStream stream = new MemoryStream())
            //{
            //    PdfReader reader = new PdfReader(bytes);
            //    using (PdfStamper stamper = new PdfStamper(reader, stream))
            //    {
            //        int pages = reader.NumberOfPages;
            //        for (int i = 1; i <= pages; i++)
            //        {
            //            if (i == 1)
            //            {
            //                ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_RIGHT, new Phrase("Page " + i.ToString() + " OF " + pages, times), 513f, 707f, 0);
            //            }
            //            else
            //            {
            //                ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_RIGHT, new Phrase("Page " + i.ToString() + " OF " + pages, times), 508f, 805f, 0);
            //            }
            //        }
            //    }
            //    bytes = stream.ToArray();

            //}
            //File.WriteAllBytes(filename, bytes);
            ShowPdf(filename);
        }
    }
}