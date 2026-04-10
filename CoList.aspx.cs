using iTextSharp.text;
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
    public partial class CoList : System.Web.UI.Page
    {
        string PermID = "";
        DataTable dt = new DataTable();
        MyClass obj = new MyClass();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
        string sqlconn = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
        string MSGNUMBER = "";
        string JobNo, MsgNO, refno, PermitNo, PermitId = "";

      
        static List<string> lststr = new List<string>();
        List<string> lststr1 = new List<string>();
        List<string> lststr2 = new List<string>();
        List<string> lststr3 = new List<string>();
        List<string> AmdFileds = new List<string>();
        string msgid = "", pemno = "";
        string fldName = "",  fldval = "", fldval1 = "";
        static string tradmail = "";
        string issueaut = "", commacc = "", commacc1 = "", ststype = "", msgidName = "MsgID", SnoName = "Sno";
        string commaccName = "", issueautName = "", commaccName1 = "";
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


            if (!IsPostBack)
            {
                // ViewState["Permit"] = txtPermitId.Text;
                BindInPayment();
                BindInpaymentGrid();
                // search();
             //   colorchange();
            }
           // colorchange();
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
        public void ErrorXml(string folName)
        {
            try
            {
                string xmlFile = "";

                string filePath = @"D:\Users\Public\" + folName + "\\ResponseFile\\";
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
                    int i = 0;

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
                                            objipt.dr = objipt.ret_dr("select * FROM InHeaderTbl where MSGId='" + strvalue + "'");
                                            while (objipt.dr.Read())
                                            {
                                                string value = objipt.dr["MSGId"].ToString();
                                                if (!string.IsNullOrWhiteSpace(value))
                                                {
                                                    str = "update InHeaderTbl set  Status='ERR' where MSGId='" + strvalue + "'";
                                                    obj.exec(str);

                                                    str = "delete from DownXmlTbl where FName='" + flanme + "' and tradeID='" + folName + "'";
                                                    obj.exec(str);

                                                    ffname = "IPT";

                                                    str = "Insert into ErrorStatus(" + SnoName + "," + msgidName + "," + commaccName + "," + fldName + ") values(" + fldval1 + ",'" + lststr1[j].ToString() + "')";
                                                    obj.exec(str);

                                                    //MyClass objiptrej = new MyClass();
                                                    //objiptrej.dr = objiptrej.ret_dr("select Count(*) FROM ErrorStatus where MsgID='" + strvalue + "'");
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
                                        //string sourceFile = @"D:\Users\Public\ResponseFile\" + file;
                                        //string destinationFile = @"D:\Users\Public\CopyFile\" + file;
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

            }
        }
        public void Cancelxml(string folName)
        {
            try
            {
                string xmlFile = "";

                string filePath = @"D:\Users\Public\" + folName + "\\ResponseFile\\";
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
                    int i = 0;
                    var nodeList4 = xmldoc.GetElementsByTagName("cbc:PermitNumber");
                    foreach (XmlNode node in nodeList4)
                    {
                        commaccName = "PermitNumber";
                        commacc = node.InnerText;
                    }
                    var nodeList6 = xmldoc.GetElementsByTagName("cbc:CommonAccessReference");
                    foreach (XmlNode node in nodeList6)
                    {
                        commaccName1 = "CommonAccessReference";
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
                                        objipt.dr = objipt.ret_dr("select Count(*) FROM InHeaderTbl where MSGId='" + strvalue + "'");
                                        while (objipt.dr.Read())
                                        {
                                            string value = objipt.dr[0].ToString();
                                            if (Convert.ToInt32(value) > 0)
                                            {
                                                str = "update InHeaderTbl set  Status='CNL' where MSGId='" + strvalue + "'";
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
                                        //string sourceFile = @"D:\Users\Public\ResponseFile\" + file;

                                        //string destinationFile = @"D:\Users\Public\CopyFile\" + file;
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

            }
        }
        public void AmendXml(string folName)
        {
            try
            {
                string xmlFile = "";
                string date = "";
                string date1 = "", date2 = "", date3 = "";

                string filePath = @"D:\Users\Public\" + folName + "\\ResponseFile\\";
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
                                objipt.dr = objipt.ret_dr("select Count(*) FROM InHeaderTbl where MSGId='" + msgid + "'");
                                while (objipt.dr.Read())
                                {
                                    string value = objipt.dr[0].ToString();
                                    if (Convert.ToInt32(value) > 0)
                                    {
                                        str = "update InHeaderTbl set  PermitNumber='" + pemno + "',Status='AME' where MSGId='" + msgid + "'";
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
                                        str = "update OutHeaderTbl set  PermitNumber='" + pemno + "',Status='AME' where MSGId='" + msgid + "'";
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
                            DateTime dst1 = new DateTime();

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
                        //string sourceFile = @"D:\Users\Public\ResponseFile\" + file;

                        //string destinationFile = @"D:\Users\Public\CopyFile\" + file;
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

            }
        }
        public void search()
        {
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
            string Importer = (GridInPayment.FooterRow.FindControl("txtExporter") as TextBox).Text;
            string InHAWBOBL = (GridInPayment.FooterRow.FindControl("txtInHAWBOBL") as TextBox).Text;
            string MAWBOBL = (GridInPayment.FooterRow.FindControl("txtMAWBOBL") as TextBox).Text;
            string LoadingPortCode = (GridInPayment.FooterRow.FindControl("txtPOD") as TextBox).Text;
            string MessageType = (GridInPayment.FooterRow.FindControl("txtMessageType") as TextBox).Text;
            string InwardTransportMode = (GridInPayment.FooterRow.FindControl("txtOutwardTransportMode") as TextBox).Text;

            string PreviousPermit = (GridInPayment.FooterRow.FindControl("txtPreviousPermitNo") as TextBox).Text;
            string InternalRemarks = (GridInPayment.FooterRow.FindControl("txtInternalRemarks") as TextBox).Text;
           // string TermType = (GridInPayment.FooterRow.FindControl("txtTermType") as TextBox).Text;

            string Status = (GridInPayment.FooterRow.FindControl("txtStatus") as TextBox).Text;


          //  string gstsum = (GridInPayment.FooterRow.FindControl("txtGSTSUMAmount") as TextBox).Text;





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

                if (!string.IsNullOrWhiteSpace(Importer))
                {
                    condidtion = condidtion + "t3.Code like '%" + Importer + "%' and ";
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
                    condidtion = condidtion + "t1.PreviousPermitNo like '%" + PreviousPermit + "%' and ";
                }
                if (!string.IsNullOrWhiteSpace(InternalRemarks))
                {
                    condidtion = condidtion + "t1.InternalRemarks like '%" + InternalRemarks + "%' and ";
                }
                


                if (!string.IsNullOrWhiteSpace(Status))
                {
                    condidtion = condidtion + "t1.Status like '%" + Status + "%' and ";
                }



                if (!string.IsNullOrWhiteSpace(condidtion))
                {
                    condidtion = condidtion.Substring(0, condidtion.Length - 4);
                }


                string SUMMM = "";
                //if (!string.IsNullOrWhiteSpace(gstsum))
                //{
                //    SUMMM = " HAVING SUM(t5.GSTSUMAmount) ='" + gstsum + "'  ";
                //}
                //if (!string.IsNullOrWhiteSpace(condidtion))
                //{
                //    condidtion = condidtion.Substring(0, condidtion.Length - 4);
                //}



                if (condidtion == "")
                {
                    if (SUMMM == "")
                    {
                        str = "SELECT  t1.Id, t1.JobId, t1.MSGId,CONVERT(varchar, t1.TouchTime, 105) AS DecDate, t1.ApplicationType AS DeclarationType, t1.TouchUser AS Createby, t2.TradeNetMailboxID AS DecId, CONVERT(varchar, t1.DepartureDate, 105) AS ETD, t1.PermitId AS LocalNo, t1.PermitNumber AS PermitNo, t1.PreviousPermitNo,  t3.Code AS Exporter, STUFF((SELECT ', ' + US.InHAWBOBL FROM OutItemDtl US  WHERE US.PermitId = t1.PermitId  FOR XML PATH('')), 1, 1, '') InHAWBOBL, t1.DischargePort as POD, t1.MessageType, t1.OutwardTransportMode, t1.InternalRemarks,  (select Count(ItemNo) from COItemDtl   where   COItemDtl.PermitId=t1.PermitId) as SumOfItem, t1.Status  FROM  COHeaderTbl AS t1 INNER JOIN   DeclarantCompany AS t2   ON t1.DeclarantCompanyCode = t2.Code   INNER JOIN COExporter AS t3   ON t1.ExporterCompanyCode = t3.Code  INNER JOIN ManageUser AS t6 ON t6.UserId=t1.TouchUser where t6.AccountId='" + Session["AccountId"].ToString() + "'   and t2.TradeNetMailboxID='" + tradmail + "'  GROUP BY t1.Id, t1.JobId, t1.MSGId, t1.TouchTime, t1.TouchUser, t1.ApplicationType, t1.DepartureDate, t1.PermitId,t1.PermitNumber,t1.PreviousPermitNo, t1.OutwardTransportMode, t1.DischargePort, t1.MessageType, t1.OutwardTransportMode, t1.PreviousPermitNo, t1.InternalRemarks, t1.Status, t2.TradeNetMailboxID, t3.Code,t6.AccountId order by t1.Id desc";


                    }
                    else
                    {
                        str = "SELECT  t1.Id, t1.JobId, t1.MSGId,CONVERT(varchar, t1.TouchTime, 105) AS DecDate, t1.ApplicationType AS DeclarationType, t1.TouchUser AS Createby, t2.TradeNetMailboxID AS DecId, CONVERT(varchar, t1.DepartureDate, 105) AS ETD, t1.PermitId AS LocalNo, t1.PermitNumber AS PermitNo, t1.PreviousPermitNo,  t3.Code AS Exporter, STUFF((SELECT ', ' + US.InHAWBOBL FROM OutItemDtl US  WHERE US.PermitId = t1.PermitId  FOR XML PATH('')), 1, 1, '') InHAWBOBL, t1.DischargePort as POD, t1.MessageType, t1.OutwardTransportMode, t1.InternalRemarks,  (select Count(ItemNo) from COItemDtl   where   COItemDtl.PermitId=t1.PermitId) as SumOfItem, t1.Status  FROM  COHeaderTbl AS t1 INNER JOIN   DeclarantCompany AS t2   ON t1.DeclarantCompanyCode = t2.Code   INNER JOIN COExporter AS t3   ON t1.ExporterCompanyCode = t3.Code  INNER JOIN ManageUser AS t6 ON t6.UserId=t1.TouchUser where t6.AccountId='" + Session["AccountId"].ToString() + "'   and t2.TradeNetMailboxID='" + tradmail + "'  GROUP BY t1.Id, t1.JobId, t1.MSGId, t1.TouchTime, t1.TouchUser, t1.ApplicationType, t1.DepartureDate, t1.PermitId,t1.PermitNumber,t1.PreviousPermitNo, t1.OutwardTransportMode, t1.DischargePort, t1.MessageType, t1.OutwardTransportMode, t1.PreviousPermitNo, t1.InternalRemarks, t1.Status, t2.TradeNetMailboxID, t3.Code,t6.AccountId " + SUMMM + " order by t1.Id desc";


                    }
                }
                else
                {
                    if (SUMMM == "")
                    {
                        str = "SELECT  t1.Id, t1.JobId, t1.MSGId,CONVERT(varchar, t1.TouchTime, 105) AS DecDate, t1.ApplicationType AS DeclarationType, t1.TouchUser AS Createby, t2.TradeNetMailboxID AS DecId, CONVERT(varchar, t1.DepartureDate, 105) AS ETD, t1.PermitId AS LocalNo, t1.PermitNumber AS PermitNo, t1.PreviousPermitNo,  t3.Code AS Exporter, STUFF((SELECT ', ' + US.InHAWBOBL FROM OutItemDtl US  WHERE US.PermitId = t1.PermitId  FOR XML PATH('')), 1, 1, '') InHAWBOBL, t1.DischargePort as POD, t1.MessageType, t1.OutwardTransportMode, t1.InternalRemarks,  (select Count(ItemNo) from COItemDtl   where   COItemDtl.PermitId=t1.PermitId) as SumOfItem, t1.Status  FROM  COHeaderTbl AS t1 INNER JOIN   DeclarantCompany AS t2   ON t1.DeclarantCompanyCode = t2.Code   INNER JOIN COExporter AS t3   ON t1.ExporterCompanyCode = t3.Code  INNER JOIN ManageUser AS t6 ON t6.UserId=t1.TouchUser where t6.AccountId='" + Session["AccountId"].ToString() + "'   and t2.TradeNetMailboxID='" + tradmail + "'    and " + condidtion + "   GROUP BY t1.Id, t1.JobId, t1.MSGId, t1.TouchTime, t1.TouchUser, t1.ApplicationType, t1.DepartureDate, t1.PermitId,t1.PermitNumber,t1.PreviousPermitNo, t1.OutwardTransportMode, t1.DischargePort, t1.MessageType, t1.OutwardTransportMode, t1.PreviousPermitNo, t1.InternalRemarks, t1.Status, t2.TradeNetMailboxID, t3.Code,t6.AccountId " + SUMMM + " order by t1.Id desc";

                    }
                    else
                    {
                        str = "SELECT  t1.Id, t1.JobId, t1.MSGId,CONVERT(varchar, t1.TouchTime, 105) AS DecDate, t1.ApplicationType AS DeclarationType, t1.TouchUser AS Createby, t2.TradeNetMailboxID AS DecId, CONVERT(varchar, t1.DepartureDate, 105) AS ETD, t1.PermitId AS LocalNo, t1.PermitNumber AS PermitNo, t1.PreviousPermitNo,  t3.Code AS Exporter, STUFF((SELECT ', ' + US.InHAWBOBL FROM OutItemDtl US  WHERE US.PermitId = t1.PermitId  FOR XML PATH('')), 1, 1, '') InHAWBOBL, t1.DischargePort as POD, t1.MessageType, t1.OutwardTransportMode, t1.InternalRemarks,  (select Count(ItemNo) from COItemDtl   where   COItemDtl.PermitId=t1.PermitId) as SumOfItem, t1.Status  FROM  COHeaderTbl AS t1 INNER JOIN   DeclarantCompany AS t2   ON t1.DeclarantCompanyCode = t2.Code   INNER JOIN COExporter AS t3   ON t1.ExporterCompanyCode = t3.Code  INNER JOIN ManageUser AS t6 ON t6.UserId=t1.TouchUser where t6.AccountId='" + Session["AccountId"].ToString() + "'   and t2.TradeNetMailboxID='" + tradmail + "'    and " + condidtion + "   GROUP BY t1.Id, t1.JobId, t1.MSGId, t1.TouchTime, t1.TouchUser, t1.ApplicationType, t1.DepartureDate, t1.PermitId,t1.PermitNumber,t1.PreviousPermitNo, t1.OutwardTransportMode, t1.DischargePort, t1.MessageType, t1.OutwardTransportMode, t1.PreviousPermitNo, t1.InternalRemarks, t1.Status, t2.TradeNetMailboxID, t3.Code,t6.AccountId " + SUMMM + " order by t1.Id desc";

                    }
                }


                if (condidtion == "")
                {



                    str = "SELECT  t1.Id, t1.JobId, t1.MSGId,CONVERT(varchar, t1.TouchTime, 105) AS DecDate, t1.ApplicationType AS DeclarationType, t1.TouchUser AS Createby, t2.TradeNetMailboxID AS DecId, CONVERT(varchar, t1.DepartureDate, 105) AS ETD, t1.PermitId AS LocalNo, t1.PermitNumber AS PermitNo, t1.PreviousPermitNo,  t3.Code AS Exporter, STUFF((SELECT ', ' + US.InHAWBOBL FROM OutItemDtl US  WHERE US.PermitId = t1.PermitId  FOR XML PATH('')), 1, 1, '') InHAWBOBL, t1.DischargePort as POD, t1.MessageType, t1.OutwardTransportMode, t1.InternalRemarks,  (select Count(ItemNo) from COItemDtl   where   COItemDtl.PermitId=t1.PermitId) as SumOfItem, t1.Status  FROM  COHeaderTbl AS t1 INNER JOIN   DeclarantCompany AS t2   ON t1.DeclarantCompanyCode = t2.Code   INNER JOIN COExporter AS t3   ON t1.ExporterCompanyCode = t3.Code  INNER JOIN ManageUser AS t6 ON t6.UserId=t1.TouchUser where t6.AccountId='" + Session["AccountId"].ToString() + "'   GROUP BY t1.Id, t1.JobId, t1.MSGId, t1.TouchTime, t1.TouchUser, t1.ApplicationType, t1.DepartureDate, t1.PermitId,t1.PermitNumber,t1.PreviousPermitNo, t1.OutwardTransportMode, t1.DischargePort, t1.MessageType, t1.OutwardTransportMode, t1.PreviousPermitNo, t1.InternalRemarks, t1.Status, t2.TradeNetMailboxID, t3.Code,t6.AccountId order by t1.Id desc";
                }
                else
                {
                    str = "SELECT  t1.Id, t1.JobId, t1.MSGId,CONVERT(varchar, t1.TouchTime, 105) AS DecDate, t1.ApplicationType AS DeclarationType, t1.TouchUser AS Createby, t2.TradeNetMailboxID AS DecId, CONVERT(varchar, t1.DepartureDate, 105) AS ETD, t1.PermitId AS LocalNo, t1.PermitNumber AS PermitNo, t1.PreviousPermitNo,  t3.Code AS Exporter, STUFF((SELECT ', ' + US.InHAWBOBL FROM OutItemDtl US  WHERE US.PermitId = t1.PermitId  FOR XML PATH('')), 1, 1, '') InHAWBOBL, t1.DischargePort as POD, t1.MessageType, t1.OutwardTransportMode, t1.InternalRemarks,  (select Count(ItemNo) from COItemDtl   where   COItemDtl.PermitId=t1.PermitId) as SumOfItem, t1.Status  FROM  COHeaderTbl AS t1 INNER JOIN   DeclarantCompany AS t2   ON t1.DeclarantCompanyCode = t2.Code   INNER JOIN COExporter AS t3   ON t1.ExporterCompanyCode = t3.Code  INNER JOIN ManageUser AS t6 ON t6.UserId=t1.TouchUser where t6.AccountId='" + Session["AccountId"].ToString() + "' and " + condidtion + "  GROUP BY t1.Id, t1.JobId, t1.MSGId, t1.TouchTime, t1.TouchUser, t1.ApplicationType, t1.DepartureDate, t1.PermitId,t1.PermitNumber,t1.PreviousPermitNo, t1.OutwardTransportMode, t1.DischargePort, t1.MessageType, t1.OutwardTransportMode, t1.PreviousPermitNo, t1.InternalRemarks, t1.Status, t2.TradeNetMailboxID, t3.Code,t6.AccountId order by t1.Id desc";
                }

                // string str = "select t1.Id,t1.JobId,MSGId, convert(varchar, t1.TouchTime, 105) as DecDate,Substring(DeclarationType, 1,Charindex(':', DeclarationType)-1) as DeclarationType,t1.TouchUser as Createby,t2.TradeNetMailboxID as DecId, convert(varchar, ArrivalDate, 105) as ETA,t1.PermitId as PermitNo,t3.Name as Importer,t4.InHAWBOBL,CASE  WHEN  t1.InwardTransportMode = '4 : Air' THEN t1.MasterAirwayBill  WHEN t1.InwardTransportMode = '1 : Sea'  THEN t1.OceanBillofLadingNo  ELSE ''  END AS MAWBOBL,t1.LoadingPortCode,t1.MessageType,t1.InwardTransportMode,t1.PreviousPermit,t1.InternalRemarks,Substring(t5.TermType, 1,Charindex(':', t5.TermType)-1) as TermType ,t5.GSTSUMAmount,sum(t4.ItemNo) as SumOFItem,t1.Status from InHeaderTbl t1 , DeclarantCompany t2 , Importer t3,ItemDtl t4,InvoiceDtl t5  where t1.DeclarantCompanyCode=t2.Code  and t1.ImporterCompanyCode=t3.Code  and t1.PermitId=t4.PermitId and t1.PermitId=t5.PermitId and " + field + " Like '" + value + "'  GROUP BY t1.Id,t4.ItemNo,t1.JobId,t1.MSGId,t1.TouchTime,t1.TouchUser,t1.DeclarationType,t2.TradeNetMailboxID,t1.ArrivalDate,t1.PermitId,t3.Name,t4.InHAWBOBL,t1.InwardTransportMode ,t1.MasterAirwayBill,t1.OceanBillofLadingNo,t1.LoadingPortCode ,t1.MessageType,t1.InwardTransportMode,t1.PreviousPermit,t1.InternalRemarks,t5.TermType,t5.GSTSUMAmount,t1.Status";
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
                    (GridInPayment.FooterRow.FindControl("txtExporter") as TextBox).Text = Importer;
                    (GridInPayment.FooterRow.FindControl("txtInHAWBOBL") as TextBox).Text = InHAWBOBL;
                    (GridInPayment.FooterRow.FindControl("txtMAWBOBL") as TextBox).Text = MAWBOBL;
                    (GridInPayment.FooterRow.FindControl("txtPOD") as TextBox).Text = LoadingPortCode;
                    (GridInPayment.FooterRow.FindControl("txtMessageType") as TextBox).Text = MessageType;
                    (GridInPayment.FooterRow.FindControl("txtOutwardTransportMode") as TextBox).Text = InwardTransportMode;
                    (GridInPayment.FooterRow.FindControl("txtPreviousPermitNo") as TextBox).Text = PreviousPermit;
                    (GridInPayment.FooterRow.FindControl("txtInternalRemarks") as TextBox).Text = InternalRemarks;
                  //  (GridInPayment.FooterRow.FindControl("txtTermType") as TextBox).Text = TermType;

                    (GridInPayment.FooterRow.FindControl("txtStatus") as TextBox).Text = Status;
                    (GridInPayment.FooterRow.FindControl("txtMSGId") as TextBox).Text = MSGId;
                    txtJobId.Text = JobId;
                    //(GridInPayment.FooterRow.FindControl("txtJobId") as TextBox).Text = JobId;
                    (GridInPayment.FooterRow.FindControl("txtMSGId") as TextBox).Text = MSGId;
                   // (GridInPayment.FooterRow.FindControl("txtGSTSUMAmount") as TextBox).Text = gstsum;
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


            //  colorchange();
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
        private void PrintCCPCreate()
        {
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from InHeaderTbl  where PermitId='" + PermID + "'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                    }
                }
            }

            var folder = Server.MapPath("KaizenCCp");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            //string path = @"D:\Kaizen\IPTDEC.xml";
            string path = Server.MapPath("KaizenCCp");
            string filename = path + "\\InpaymentCCP" + PermID + ".pdf";
            // Create a file to write to.
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }

            //Create new PDF document 
            iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 80f, 5f, 5f, 0f);
            PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create, FileAccess.ReadWrite));

            //Barcode genarate
            Response.ContentType = "application/pdf";
            PdfWriter writer = PdfWriter.GetInstance(
              document, Response.OutputStream
            );
            document.Open();

            // FONT
            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1257, false);
            iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 9);

            BaseFont bfTimes1 = BaseFont.CreateFont(BaseFont.COURIER_BOLD, BaseFont.CP1257, false);
            iTextSharp.text.Font timesBold = new iTextSharp.text.Font(bfTimes1, 9);

            //page 1 //
            document.Add(new Paragraph("\n"));
            string testerwd = "                                                                     ";
            iTextSharp.text.Paragraph c3r = new iTextSharp.text.Paragraph(testerwd, times);
            c3r.Alignment = Element.ALIGN_LEFT;
            document.Add(c3r);
            // iTextShirp
            //Bitmap barCode = new Bitmap(1, 1);
            string data = "IG9A429783R";
            Barcode39 code128 = new Barcode39();
            // Barcode128 code128 = new Barcode128(); // barcode type
            code128.Code = data;
            System.Drawing.Image barCode = code128.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White);
            barCode.Save(Server.MapPath("/barcode.gif"), System.Drawing.Imaging.ImageFormat.Gif); //save file
            //return barCode;

            string imageURL = Server.MapPath(".") + "/barcode.gif";
            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);
            //Resize image depend upon your need

            jpg.ScaleToFit(200f, 200f);
            //Give space before image

            //jpg.SpacingBefore = 80f;
            ////Give some space after the image

            //jpg.SpacingAfter = 5f;

            jpg.IndentationLeft = 80;

            jpg.IndentationRight = 80;

            jpg.Alignment = Element.ALIGN_RIGHT;


            document.Add(jpg);


            //document.Add(lblImg.Text.ToString());

            //document.Add(new Paragraph("\n"));
            //document.Add(new Paragraph("\n"));
            //document.Add(new Paragraph("\n"));

            string permit1 = "                                                         PERMIT NO : IG9A429783R";
            iTextSharp.text.Paragraph p1 = new iTextSharp.text.Paragraph(permit1, times);
            p1.Alignment = Element.ALIGN_LEFT;
            document.Add(p1);

            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph("\n"));

            string testerw = "                                     CARGO CLEARANCE PERMIT                   ";
            iTextSharp.text.Paragraph cr = new iTextSharp.text.Paragraph(testerw, times);
            cr.Alignment = Element.ALIGN_LEFT;
            document.Add(cr);
            document.Add(new Paragraph("\n"));
            //document.Add(new Paragraph("\n"));
            string msgtype = "MESSAGE TYPE      : IN-PAYMENT PERMIT";
            iTextSharp.text.Paragraph msgty = new iTextSharp.text.Paragraph(msgtype, times);
            msgty.Alignment = Element.ALIGN_LEFT;
            document.Add(msgty);

            string[] decltype = dt.Rows[0]["DeclarationType"].ToString().Split(':');
            string dectype = "DECLARATION TYPE  : " + decltype[1].ToString().Substring(2).ToUpper() + "";
            iTextSharp.text.Paragraph dectp = new iTextSharp.text.Paragraph(dectype, times);
            dectp.Alignment = Element.ALIGN_LEFT;
            document.Add(dectp);

            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph("\n"));

            string Validate1 = "";
            string datechk = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4).ToString();
            //string[] str = dt.Rows[0]["MSGId"].ToString().Substring(0,dt.Rows[0]["MSGId"].ToString().Length-4).ToString();
            //var chkdt = DateTime.ParseExact(datechk, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //Validate = chkdt.ToString("dd/MM/yyyy");

            string impname = "IMPORTER:                            VALIDITY PERIOD : " + DateTime.Now.ToString("dd/MM/yyyy") + " -             ";
            iTextSharp.text.Paragraph a1 = new iTextSharp.text.Paragraph(impname, times);
            a1.Alignment = Element.ALIGN_LEFT;
            document.Add(a1);

            string imptrname = "", impname1 = "", impceui = "";
            string impget = "Select * from Importer where Code='" + dt.Rows[0]["ImporterCompanyCode"].ToString() + "'";
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
            if (!string.IsNullOrWhiteSpace(impname1))
            {
                impname1 = "                                   ";
            }
            string space = "", space1 = "";
            int sapceval = 0, spceval1 = 0;
            sapceval = imptrname.Length;
            spceval1 = 55 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }

            Validate1 = DateTime.Now.AddDays(15).ToString("dd/MM/yyyy");
            string impnam1 = "" + imptrname + "" + space + "" + Validate1 + "               ";
            iTextSharp.text.Paragraph a2 = new iTextSharp.text.Paragraph(impnam1, times);
            a2.Alignment = Element.ALIGN_LEFT;
            document.Add(a2);


            string impnam2 = "" + impname1 + "                                             ";
            iTextSharp.text.Paragraph a3 = new iTextSharp.text.Paragraph(impnam2, times);
            a3.Alignment = Element.ALIGN_LEFT;
            document.Add(a3);

            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = impceui.Length;
            spceval1 = 37 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }
            string strtest2 = Math.Round(Convert.ToDecimal(dt.Rows[0]["TotalGrossWeight"].ToString()), 2).ToString("0.000");
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
            document.Add(a4);

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
            document.Add(a5);

            space = ""; space1 = "";
            for (int i = 0; i < 37; i++)
            {
                space = space + " ";
            }
            sapceval = 0; spceval1 = 0;
            sapceval = dt.Rows[0]["TotalExDutyAmt"].ToString().Length;
            spceval1 = 16 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }
            string impnam5 = "" + space + "TOT EXCISE DUT PAYABLE : S$" + space1 + "" + dt.Rows[0]["TotalExDutyAmt"].ToString() + "";
            iTextSharp.text.Paragraph a6 = new iTextSharp.text.Paragraph(impnam5, times);
            a6.Alignment = Element.ALIGN_LEFT;
            document.Add(a6);

            space = ""; space1 = "";
            for (int i = 0; i < 37; i++)
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
            string impnam6 = "" + space + "TOT CUSTOMS DUT PAYABLE: S$" + space1 + "" + dt.Rows[0]["TotalCusDutyAmt"].ToString() + "";
            iTextSharp.text.Paragraph a7 = new iTextSharp.text.Paragraph(impnam6, times);
            a7.Alignment = Element.ALIGN_LEFT;
            document.Add(a7);

            space = ""; space1 = "";
            for (int i = 0; i < 37; i++)
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
            string impnam7 = "" + space + "TOT OTHER TAX PAYABLE  : S$" + space1 + "" + dt.Rows[0]["TotalODutyAmt"].ToString() + "";
            iTextSharp.text.Paragraph a8 = new iTextSharp.text.Paragraph(impnam7, times);
            a8.Alignment = Element.ALIGN_LEFT;
            document.Add(a8);

            string handl = "HANDLING AGENT:";
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
            document.Add(a9);

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
            document.Add(b1);

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
            document.Add(b2);

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
            document.Add(b3);

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

            string impna12 = "" + space + "" + dt.Rows[0]["VesselName"].ToString() + "";
            iTextSharp.text.Paragraph b4 = new iTextSharp.text.Paragraph(impna12, times);
            b4.Alignment = Element.ALIGN_LEFT;
            document.Add(b4);

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
            sapceval = dt.Rows[0]["ConveyanceRefNo"].ToString().Length;
            spceval1 = 23 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }
            string impna13 = "PORT OF LOADING/NEXT PORT OF CALL:" + space + "CONVEYANCE REFERENCE NO: " + dt.Rows[0]["VoyageNumber"].ToString() + "";
            iTextSharp.text.Paragraph b5 = new iTextSharp.text.Paragraph(impna13, times);
            b5.Alignment = Element.ALIGN_LEFT;
            document.Add(b5);

            string lodportName = "";
            MyClass lodobj = new MyClass();
            string lodport = "Select * from LoadingPort where PortCode='" + dt.Rows[0]["LoadingPortCode"].ToString() + "'";
            lodobj.dr = lodobj.ret_dr(lodport);
            if (lodobj.dr.HasRows)
            {
                while (lodobj.dr.Read())
                {
                    lodportName = lodobj.dr["PortName"].ToString();
                }
            }
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = lodportName.Length;
            spceval1 = 37 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }
            string impna14 = "" + lodportName + "" + space + "OBL/MAWB NO:                               ";
            iTextSharp.text.Paragraph b6 = new iTextSharp.text.Paragraph(impna14, times);
            b6.Alignment = Element.ALIGN_LEFT;
            document.Add(b6);

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
            sapceval = dt.Rows[0]["OceanBillofLadingNo"].ToString().Length;
            spceval1 = 23 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }
            string impna15 = "PORT OF DISCHARGE/FINAL PORT OF CALL " + space + "" + dt.Rows[0]["OceanBillofLadingNo"].ToString() + "";
            iTextSharp.text.Paragraph b7 = new iTextSharp.text.Paragraph(impna15, times);
            b7.Alignment = Element.ALIGN_LEFT;
            document.Add(b7);

            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = handl.Length;
            spceval1 = 37 - sapceval;
            for (int i = 0; i < 37; i++)
            {
                space = space + " ";
            }
            string impna16 = "" + space + "ARRIVAL DATE         : " + Convert.ToDateTime(dt.Rows[0]["ArrivalDate"].ToString()).ToString("dd/MM/yyyy") + "";
            iTextSharp.text.Paragraph b8 = new iTextSharp.text.Paragraph(impna16, times);
            b8.Alignment = Element.ALIGN_LEFT;
            document.Add(b8);

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
            document.Add(b9);


            string impna18 = "        ";
            iTextSharp.text.Paragraph c1 = new iTextSharp.text.Paragraph(impna18, times);
            c1.Alignment = Element.ALIGN_LEFT;
            document.Add(c1);

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
            sapceval = dt.Rows[0]["ConveyanceRefNo"].ToString().Length;
            spceval1 = 23 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }
            string impna19 = "INWARD CARRIER AGENT:" + space + "CONVEYANCE REFERENCE NO: ";
            iTextSharp.text.Paragraph c2 = new iTextSharp.text.Paragraph(impna19, times);
            c2.Alignment = Element.ALIGN_LEFT;
            document.Add(c2);

            string inwName = "";
            MyClass inwobj = new MyClass();
            string inwqury = "Select * from InwardCarrierAgent where Code='" + dt.Rows[0]["InwardCarrierAgentCode"].ToString() + "'";
            inwobj.dr = inwobj.ret_dr(inwqury);
            if (inwobj.dr.HasRows)
            {
                while (inwobj.dr.Read())
                {
                    inwName = inwobj.dr["Name"].ToString();
                }
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
            sapceval = dt.Rows[0]["ConveyanceRefNo"].ToString().Length;
            spceval1 = 23 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }
            string impna20 = "" + inwName + "" + space + "OBL/MAWB/UCR NO:                          ";
            iTextSharp.text.Paragraph c3 = new iTextSharp.text.Paragraph(impna20, times);
            c3.Alignment = Element.ALIGN_LEFT;
            document.Add(c3);


            string impna21 = "       ";
            iTextSharp.text.Paragraph c4 = new iTextSharp.text.Paragraph(impna21, times);
            c4.Alignment = Element.ALIGN_LEFT;
            document.Add(c4);


            handl = "INWARD CARRIER AGENT:";
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
            sapceval = dt.Rows[0]["ConveyanceRefNo"].ToString().Length;
            spceval1 = 23 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }

            string impna22 = "" + space + "DEPARTURE DATE       :          ";
            iTextSharp.text.Paragraph c5 = new iTextSharp.text.Paragraph(impna22, times);
            c5.Alignment = Element.ALIGN_LEFT;
            document.Add(c5);


            string impna23 = "OUTWARD CARRIER AGENT:                                                      ";
            iTextSharp.text.Paragraph c6 = new iTextSharp.text.Paragraph(impna23, times);
            c6.Alignment = Element.ALIGN_LEFT;
            document.Add(c6);

            handl = "INWARD CARRIER AGENT:";
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
            sapceval = dt.Rows[0]["ConveyanceRefNo"].ToString().Length;
            spceval1 = 23 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }
            string impna24 = "" + space + "CERTIFICATE NO: ";
            iTextSharp.text.Paragraph c7 = new iTextSharp.text.Paragraph(impna24, times);
            c7.Alignment = Element.ALIGN_LEFT;
            document.Add(c7);



            string impna25 = "                                            ";
            iTextSharp.text.Paragraph c8 = new iTextSharp.text.Paragraph(impna25, times);
            c8.Alignment = Element.ALIGN_LEFT;
            document.Add(c8);


            string impna26 = "                                                ";
            iTextSharp.text.Paragraph c9 = new iTextSharp.text.Paragraph(impna26, times);
            c9.Alignment = Element.ALIGN_LEFT;
            document.Add(c9);

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
            document.Add(d1);
            string rectName = "";
            string receploc = "Select * from ReceiptLocation where Code='" + dt.Rows[0]["RecepitLocation"].ToString() + "'";
            obj.dr = obj.ret_dr(receploc);
            if (obj.dr.HasRows)
            {
                while (obj.dr.Read())
                {
                    rectName = obj.dr["Description"].ToString();
                }
            }
            string relseName = "";
            string relseloc = "Select * from ReleaseLocation where Code='" + dt.Rows[0]["ReleaseLocation"].ToString() + "'";
            obj.dr = obj.ret_dr(relseloc);
            if (obj.dr.HasRows)
            {
                while (obj.dr.Read())
                {
                    relseName = obj.dr["Description"].ToString();
                }
            }
            handl = "PLACE OF RELEASE:";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = relseName.Length;
            spceval1 = 37 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }
            string impna28 = "" + relseName + "" + space + "" + rectName + "";
            iTextSharp.text.Paragraph d2 = new iTextSharp.text.Paragraph(impna28, times);
            d2.Alignment = Element.ALIGN_LEFT;
            document.Add(d2);

            handl = "PLACE OF RELEASE:";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = dt.Rows[0]["ReleaseLocation"].ToString().Length;
            spceval1 = 37 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }
            string impna29 = "" + dt.Rows[0]["ReleaseLocation"].ToString() + "" + space + "" + dt.Rows[0]["RecepitLocation"].ToString() + "";
            iTextSharp.text.Paragraph d3 = new iTextSharp.text.Paragraph(impna29, times);
            d3.Alignment = Element.ALIGN_LEFT;
            document.Add(d3);


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
            document.Add(e2);

            string aeoName = "", cwcName = "", cnbName = "";
            string cpcQury = "Select * from CPCDtl where PermitId='" + dt.Rows[0]["PermitId"].ToString() + "'";
            obj.dr = obj.ret_dr(cpcQury);
            if (obj.dr.HasRows)
            {
                while (obj.dr.Read())
                {
                    if (obj.dr["CPCType"].ToString() == "aeo")
                    {
                        aeoName = obj.dr["CPCType"].ToString();
                    }
                    else if (obj.dr["CPCType"].ToString() == "cwc")
                    {
                        cwcName = obj.dr["CPCType"].ToString();
                    }
                    else if (obj.dr["CPCType"].ToString() == "cnb")
                    {
                        cnbName = obj.dr["CPCType"].ToString();
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
            string impna38 = "" + LicNo1 + "" + space + "" + aeoName + "";
            iTextSharp.text.Paragraph e3 = new iTextSharp.text.Paragraph(impna38, times);
            e3.Alignment = Element.ALIGN_LEFT;
            document.Add(e3);

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
            string impna39 = "" + LicNo2 + "" + space + "" + cwcName + "";
            iTextSharp.text.Paragraph e4 = new iTextSharp.text.Paragraph(impna39, times);
            e4.Alignment = Element.ALIGN_LEFT;
            document.Add(e4);

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
            string impna40 = "" + LicNo3 + "" + space + "" + cnbName + "";
            iTextSharp.text.Paragraph e5 = new iTextSharp.text.Paragraph(impna40, times);
            e5.Alignment = Element.ALIGN_LEFT;
            document.Add(e5);

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
            string impna41 = "" + LicNo4 + "" + space + "";
            iTextSharp.text.Paragraph e6 = new iTextSharp.text.Paragraph(impna41, times);
            e6.Alignment = Element.ALIGN_LEFT;
            document.Add(e6);

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
            string impna30 = "" + LicNo5 + "" + space + "         ";
            iTextSharp.text.Paragraph d4 = new iTextSharp.text.Paragraph(impna30, times);
            d4.Alignment = Element.ALIGN_LEFT;
            document.Add(d4);

            //string teststr="S/NO HS CODE CURRENT LOT NO "

            string impna31 = "          ";
            iTextSharp.text.Paragraph d5 = new iTextSharp.text.Paragraph(impna31, times);
            d5.Alignment = Element.ALIGN_LEFT;
            document.Add(d5);



            ////string impna32 = "          ";
            ////iTextSharp.text.Paragraph d6 = new iTextSharp.text.Paragraph(impna32, times);
            ////d6.Alignment = Element.ALIGN_LEFT;
            ////document.Add(d6);

            ////string impna33 = "          ";
            ////iTextSharp.text.Paragraph d7 = new iTextSharp.text.Paragraph(impna33, times);
            ////d7.Alignment = Element.ALIGN_LEFT;
            ////document.Add(d7);


            string impna34 = "          ";
            iTextSharp.text.Paragraph d8 = new iTextSharp.text.Paragraph(impna34, times);
            d8.Alignment = Element.ALIGN_LEFT;
            document.Add(d5);


            string impna35 = "          ";
            iTextSharp.text.Paragraph d9 = new iTextSharp.text.Paragraph(impna35, times);
            d9.Alignment = Element.ALIGN_LEFT;
            document.Add(d9);


            string impna36 = "                                  ";
            iTextSharp.text.Paragraph e1 = new iTextSharp.text.Paragraph(impna36, times);
            e1.Alignment = Element.ALIGN_LEFT;
            document.Add(e1);

            string impna135 = "          ";
            iTextSharp.text.Paragraph d119 = new iTextSharp.text.Paragraph(impna135, times);
            d9.Alignment = Element.ALIGN_LEFT;
            document.Add(d119);


            string impna136 = "                                  ";
            iTextSharp.text.Paragraph e111 = new iTextSharp.text.Paragraph(impna136, times);
            e1.Alignment = Element.ALIGN_LEFT;
            document.Add(e111);

            string impna42 = "-------------------------------------------------------------------------------";
            iTextSharp.text.Paragraph Line = new iTextSharp.text.Paragraph(impna42, times);
            Line.Alignment = Element.ALIGN_LEFT;
            document.Add(Line);

            //document.Add(new Paragraph("\n"));
            string msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
            string impna43 = "UNIQUE REF : 201834618Z " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(9) + "                              ";
            iTextSharp.text.Paragraph e8 = new iTextSharp.text.Paragraph(impna43, times);
            e8.Alignment = Element.ALIGN_LEFT;
            document.Add(e8);

            string impna4a = "                                                                                ";
            iTextSharp.text.Paragraph rr = new iTextSharp.text.Paragraph(impna4a, times);
            rr.Alignment = Element.ALIGN_LEFT;
            document.Add(rr);

            string impna4b = "                                                                                ";
            iTextSharp.text.Paragraph rrr = new iTextSharp.text.Paragraph(impna4b, times);
            rrr.Alignment = Element.ALIGN_LEFT;
            document.Add(rrr);
            //page 2 //

            int Linecount = 62;
            int chkline = 0;
            string itemQury = "Select * from ItemDtl where PermitId='" + dt.Rows[0]["PermitId"].ToString() + "'";
            obj.dr = obj.ret_dr(itemQury);
            if (obj.dr.HasRows)
            {
                while (obj.dr.Read())
                {
                    if (chkline == 0)
                    {
                        string page001 = "                                     CARGO CLEARANCE PERMIT                   ";
                        iTextSharp.text.Paragraph e9 = new iTextSharp.text.Paragraph(page001, times);
                        e9.Alignment = Element.ALIGN_LEFT;
                        document.Add(e9);
                        chkline = chkline + 1;

                        //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                        string page002 = "PERMIT NO : IG9A429783R              ======================                     ";
                        iTextSharp.text.Paragraph f1 = new iTextSharp.text.Paragraph(page002, times);
                        f1.Alignment = Element.ALIGN_LEFT;
                        document.Add(f1);
                        chkline = chkline + 1;

                        //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                        string page003 = "                                      (CONTINUATION PAGE)                       ";
                        iTextSharp.text.Paragraph f2 = new iTextSharp.text.Paragraph(page003, times);
                        f2.Alignment = Element.ALIGN_LEFT;
                        document.Add(f2);
                        chkline = chkline + 1;

                        //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                        string page004 = "CONSIGNMENT DETAILS                                                             ";
                        iTextSharp.text.Paragraph f3 = new iTextSharp.text.Paragraph(page004, times);
                        f3.Alignment = Element.ALIGN_LEFT;
                        document.Add(f3);
                        chkline = chkline + 1;

                        document.Add(Line);
                        chkline = chkline + 1;

                        string page006 = "S/NO     HS CODE     CURRENT LOT NO          PREVIOUS LOT NO                ";
                        iTextSharp.text.Paragraph f5 = new iTextSharp.text.Paragraph(page006, times);
                        f5.Alignment = Element.ALIGN_LEFT;
                        document.Add(f5);
                        chkline = chkline + 1;

                        string page007 = "MARKING   CTY OF ORIGIN   BRAND NAME         MODEL                            ";
                        iTextSharp.text.Paragraph f6 = new iTextSharp.text.Paragraph(page007, times);
                        f6.Alignment = Element.ALIGN_LEFT;
                        document.Add(f6);
                        chkline = chkline + 1;

                        //string page008 = "IN MAWB/OUCR/OBL                           OUT MAWB/OUCR/OBL                 ";
                        //iTextSharp.text.Paragraph f7 = new iTextSharp.text.Paragraph(page008, times);
                        //f7.Alignment = Element.ALIGN_LEFT;
                        //document.Add(f7);
                        //chkline = chkline + 1;

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
                        document.Add(f8);
                        chkline = chkline + 1;

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
                        document.Add(f9);
                        chkline = chkline + 1;

                        string page011 = "                                             CIF/FOB VALUE (S$)                ";
                        iTextSharp.text.Paragraph g1 = new iTextSharp.text.Paragraph(page011, times);
                        g1.Alignment = Element.ALIGN_LEFT;
                        document.Add(g1);
                        chkline = chkline + 1;

                        //string page012 = "                                             LSP VALUE (S$)                    ";
                        //iTextSharp.text.Paragraph g2 = new iTextSharp.text.Paragraph(page012, times);
                        //g2.Alignment = Element.ALIGN_LEFT;
                        //document.Add(g2);
                        //chkline = chkline + 1;

                        string page013 = "                                             GST AMOUNT (S$)                   ";
                        iTextSharp.text.Paragraph g3 = new iTextSharp.text.Paragraph(page013, times);
                        g3.Alignment = Element.ALIGN_LEFT;
                        document.Add(g3);
                        chkline = chkline + 1;

                        if (obj.dr["DutiableUOM"].ToString() != "--Select--")
                        {
                            string page014 = "                                             DUT QTY/WT/VOL & UNIT             ";
                            iTextSharp.text.Paragraph g4 = new iTextSharp.text.Paragraph(page014, times);
                            g4.Alignment = Element.ALIGN_LEFT;
                            document.Add(g4);
                            chkline = chkline + 1;
                        }

                        string page015 = "                                             UNIT PRICE & CODE                 ";
                        iTextSharp.text.Paragraph g5 = new iTextSharp.text.Paragraph(page015, times);
                        g5.Alignment = Element.ALIGN_LEFT;
                        document.Add(g5);
                        chkline = chkline + 1;

                        if (Convert.ToDecimal(obj.dr["ExciseDutyRate"].ToString()) > 0)
                        {
                            string page016 = "                                             EXCISE DUTY PAYABLE (S$)          ";
                            iTextSharp.text.Paragraph g6 = new iTextSharp.text.Paragraph(page016, times);
                            g6.Alignment = Element.ALIGN_LEFT;
                            document.Add(g6);
                            chkline = chkline + 1;
                        }

                        //string page017 = "                                             CUSTOMS DUTY PAYABLE(S$)          ";
                        //iTextSharp.text.Paragraph g7 = new iTextSharp.text.Paragraph(page017, times);
                        //g7.Alignment = Element.ALIGN_LEFT;
                        //document.Add(g7);
                        //chkline = chkline + 1;

                        //string page018 = "                                             OTHER TAX PAYABLE(S$)            ";
                        //iTextSharp.text.Paragraph g8 = new iTextSharp.text.Paragraph(page018, times);
                        //g8.Alignment = Element.ALIGN_LEFT;
                        //document.Add(g8);
                        //chkline = chkline + 1;

                        string page019 = "MANUFACTURER’S NAME                                                         ";
                        iTextSharp.text.Paragraph g9 = new iTextSharp.text.Paragraph(page019, times);
                        g9.Alignment = Element.ALIGN_LEFT;
                        document.Add(g9);
                        chkline = chkline + 1;

                        document.Add(Line);
                        chkline = chkline + 1;
                    }
                    if (chkline < Linecount)
                    {
                        //string page021 = "  ";
                        //iTextSharp.text.Paragraph h2 = new iTextSharp.text.Paragraph(page021, times);
                        //h2.Alignment = Element.ALIGN_LEFT;
                        //document.Add(h2);
                        //chkline = chkline + 1;

                        string sno = "";
                        if (obj.dr["ItemNo"].ToString().Length == 1)
                        {
                            sno = "0" + obj.dr["ItemNo"].ToString();
                        }
                        else
                        {
                            sno = obj.dr["ItemNo"].ToString();
                        }

                        string page022 = "  " + sno + "   " + obj.dr["HSCode"].ToString() + "   " + obj.dr["CurrentLot"].ToString() + "";
                        iTextSharp.text.Paragraph h3 = new iTextSharp.text.Paragraph(page022, times);
                        h3.Alignment = Element.ALIGN_LEFT;
                        document.Add(h3);
                        chkline = chkline + 1;

                        string Marking = "";
                        if (obj.dr["Making"].ToString() != "--Select--")
                        {
                            Marking = obj.dr["Making"].ToString();
                        }

                        string page023 = "" + Marking + "    " + obj.dr["Contry"].ToString() + "    " + obj.dr["Brand"].ToString() + "";
                        iTextSharp.text.Paragraph h4 = new iTextSharp.text.Paragraph(page023, times);
                        h4.Alignment = Element.ALIGN_LEFT;
                        document.Add(h4);
                        chkline = chkline + 1;

                        handl = "LICENCE NO:";
                        space = ""; space1 = "";
                        sapceval = 0; spceval1 = 0;
                        sapceval = obj.dr["InHAWBOBL"].ToString().Length;
                        spceval1 = 45 - sapceval;
                        for (int i = 0; i < spceval1; i++)
                        {
                            space = space + " ";
                        }
                        string page024 = "" + obj.dr["InHAWBOBL"].ToString() + "" + space + "";
                        iTextSharp.text.Paragraph h5 = new iTextSharp.text.Paragraph(page024, times);
                        h5.Alignment = Element.ALIGN_LEFT;
                        document.Add(h5);
                        chkline = chkline + 1;

                        string opqty = "", strtest = "";
                        if (obj.dr["OPUOM"].ToString() != "--Select--")
                        {
                            opqty = "   " + obj.dr["OPQty"].ToString() + "  " + obj.dr["OPUOM"].ToString() + "       ";
                            strtest = "1";
                        }
                        if (obj.dr["IPUOM"].ToString() != "--Select--")
                        {
                            opqty = opqty + "" + obj.dr["IPQty"].ToString() + "  " + obj.dr["IPUOM"].ToString() + "       ";
                            strtest = "2";
                        }
                        if (obj.dr["InPUOM"].ToString() != "--Select--")
                        {
                            opqty = opqty + "" + obj.dr["InPqty"].ToString() + "  " + obj.dr["InPUOM"].ToString() + "       ";
                            strtest = "3";
                        }
                        if (obj.dr["InPUOM"].ToString() != "--Select--")
                        {
                            opqty = opqty + "" + obj.dr["ImPQty"].ToString() + "  " + obj.dr["ImPUOM"].ToString() + "";
                            strtest = "4";
                        }

                        if (string.IsNullOrWhiteSpace(strtest))
                        {
                            opqty = obj.dr["Description"].ToString();
                        }

                        string teststr = opqty;
                        if (teststr.Length > 50)
                        {
                            teststr = opqty.Substring(0, 50);
                            opqty = opqty.Remove(0, 50);
                        }
                        else
                        {
                            teststr = opqty;
                            opqty = opqty.Remove(0, teststr.Length);
                        }


                        string hsval = Math.Round(Convert.ToDecimal(obj.dr["HSQty"].ToString()), 4).ToString("0.0000");
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
                        sapceval = hsval.Length;
                        spceval1 = 25 - sapceval;
                        for (int i = 0; i < spceval1; i++)
                        {
                            space1 = space1 + " ";
                        }


                        string page025 = "" + teststr + "" + space + "" + space1 + "" + hsval + " " + obj.dr["HSUOM"].ToString() + "";
                        iTextSharp.text.Paragraph h6 = new iTextSharp.text.Paragraph(page025, times);
                        h6.Alignment = Element.ALIGN_LEFT;
                        document.Add(h6);
                        chkline = chkline + 1;

                        teststr = opqty;
                        if (teststr.Length > 50)
                        {
                            teststr = opqty.Substring(0, 50);
                            opqty = opqty.Remove(0, 50);
                        }
                        else
                        {
                            teststr = opqty;
                            opqty = opqty.Remove(0, teststr.Length);
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
                        string page026 = "" + teststr + "" + space + "" + space1 + "" + obj.dr["CIFFOB"].ToString() + "    ";
                        iTextSharp.text.Paragraph h7 = new iTextSharp.text.Paragraph(page026, times);
                        h7.Alignment = Element.ALIGN_LEFT;
                        document.Add(h7);
                        chkline = chkline + 1;

                        teststr = opqty;
                        if (teststr.Length > 50)
                        {
                            teststr = opqty.Substring(0, 50);
                            opqty = opqty.Remove(0, 50);
                        }
                        else
                        {
                            teststr = opqty;
                            opqty = opqty.Remove(0, teststr.Length);
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
                        sapceval = obj.dr["GSTAmount"].ToString().Length;
                        spceval1 = 25 - sapceval;
                        for (int i = 0; i < spceval1; i++)
                        {
                            space1 = space1 + " ";
                        }
                        string page027 = "" + teststr + "" + space + "" + space1 + "" + obj.dr["GSTAmount"].ToString() + "    ";
                        iTextSharp.text.Paragraph h8 = new iTextSharp.text.Paragraph(page027, times);
                        h8.Alignment = Element.ALIGN_LEFT;
                        document.Add(h8);
                        chkline = chkline + 1;

                        teststr = opqty;
                        if (teststr.Length > 50)
                        {
                            teststr = opqty.Substring(0, 50);
                            opqty = opqty.Remove(0, 50);
                        }
                        else
                        {
                            teststr = opqty;
                            opqty = opqty.Remove(0, teststr.Length);
                        }

                        hsval = Math.Round(Convert.ToDecimal(obj.dr["TotalLineAmount"].ToString()), 4).ToString("0.0000");
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
                        sapceval = hsval.Length;
                        spceval1 = 25 - sapceval;
                        for (int i = 0; i < spceval1; i++)
                        {
                            space1 = space1 + " ";
                        }
                        string page028 = "" + teststr + "" + space + "" + space1 + "" + hsval + " " + obj.dr["UnitPriceCurrency"].ToString() + "";
                        iTextSharp.text.Paragraph h9 = new iTextSharp.text.Paragraph(page028, times);
                        h9.Alignment = Element.ALIGN_LEFT;
                        document.Add(h9);
                        chkline = chkline + 1;

                        //string page030 = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX          ZZZZZZZZZZZZ9.99 XXX";
                        //iTextSharp.text.Paragraph i1 = new iTextSharp.text.Paragraph(page030, times);
                        //i1.Alignment = Element.ALIGN_LEFT;
                        //document.Add(i1);
                        //chkline = chkline + 1;

                        //string page031 = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX          ZZZZZZZZZZZZ9.99 XXX";
                        //iTextSharp.text.Paragraph i2 = new iTextSharp.text.Paragraph(page031, times);
                        //i2.Alignment = Element.ALIGN_LEFT;
                        //document.Add(i2);
                        //chkline = chkline + 1;

                        //string page032 = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX          ZZZZZZZZZZZZ9.99    ";
                        //iTextSharp.text.Paragraph i3 = new iTextSharp.text.Paragraph(page032, times);
                        //i3.Alignment = Element.ALIGN_LEFT;
                        //document.Add(i3);
                        //chkline = chkline + 1;


                        teststr = opqty;
                        if (teststr.Length > 50)
                        {
                            teststr = opqty.Substring(0, 50);
                            opqty = opqty.Remove(0, 50);
                        }
                        else
                        {
                            teststr = opqty;
                            opqty = opqty.Remove(0, teststr.Length);
                        }
                        string DutiAmt = "";
                        if (obj.dr["DutiableUOM"].ToString() != "--Select--")
                        {
                            DutiAmt = obj.dr["DutiableQty"].ToString() + " " + obj.dr["DutiableUOM"].ToString();
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
                            sapceval = obj.dr["GSTAmount"].ToString().Length;
                            spceval1 = 25 - sapceval;
                            for (int i = 0; i < spceval1; i++)
                            {
                                space1 = space1 + " ";
                            }
                            string page033 = "" + teststr + "" + space + "" + space1 + "" + DutiAmt + "";
                            iTextSharp.text.Paragraph i4 = new iTextSharp.text.Paragraph(page033, times);
                            i4.Alignment = Element.ALIGN_LEFT;
                            document.Add(i4);
                            chkline = chkline + 1;
                        }

                        teststr = opqty;
                        if (teststr.Length > 50)
                        {
                            teststr = opqty.Substring(0, 50);
                            opqty = opqty.Remove(0, 50);
                        }
                        else
                        {
                            teststr = opqty;
                            opqty = opqty.Remove(0, teststr.Length);
                        }
                        DutiAmt = "";
                        if (Convert.ToDecimal(obj.dr["ExciseDutyRate"].ToString()) > 0)
                        {
                            DutiAmt = obj.dr["ExciseDutyAmount"].ToString() + "    ";
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
                            sapceval = obj.dr["GSTAmount"].ToString().Length;
                            spceval1 = 25 - sapceval;
                            for (int i = 0; i < spceval1; i++)
                            {
                                space1 = space1 + " ";
                            }
                            string page034 = "" + teststr + "" + space + "" + space1 + "" + DutiAmt + "";
                            iTextSharp.text.Paragraph i5 = new iTextSharp.text.Paragraph(page034, times);
                            i5.Alignment = Element.ALIGN_LEFT;
                            document.Add(i5);
                            chkline = chkline + 1;
                        }

                        string supName = "";
                        MyClass obj1 = new MyClass();
                        string InvQury = "Select * from InvoiceDtl where PermitId='" + dt.Rows[0]["PermitId"].ToString() + "'";
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
                        string page035 = "" + supName + "";
                        iTextSharp.text.Paragraph i6 = new iTextSharp.text.Paragraph(page035, times);
                        i6.Alignment = Element.ALIGN_LEFT;
                        document.Add(i6);
                        chkline = chkline + 1;

                        //string page036 = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX                              ";
                        //iTextSharp.text.Paragraph i7 = new iTextSharp.text.Paragraph(page036, times);
                        //i7.Alignment = Element.ALIGN_LEFT;
                        //document.Add(i7);
                        //chkline = chkline + 1;

                        //string page037 = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX                              ";
                        //iTextSharp.text.Paragraph i8 = new iTextSharp.text.Paragraph(page037, times);
                        //i8.Alignment = Element.ALIGN_LEFT;
                        //document.Add(i8);
                        //chkline = chkline + 1;

                        //string page038 = "XXXXXXXXXXXX                                                                    ";
                        //iTextSharp.text.Paragraph i9 = new iTextSharp.text.Paragraph(page038, times);
                        //i9.Alignment = Element.ALIGN_LEFT;
                        //document.Add(i9);
                        //chkline = chkline + 1;

                        //string page039 = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX                              ";
                        //iTextSharp.text.Paragraph j0 = new iTextSharp.text.Paragraph(page039, times);
                        //j0.Alignment = Element.ALIGN_LEFT;
                        //document.Add(j0);
                        //chkline = chkline + 1;

                        //string page040 = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX                              ";
                        //iTextSharp.text.Paragraph j1 = new iTextSharp.text.Paragraph(page040, times);
                        //j1.Alignment = Element.ALIGN_LEFT;
                        //document.Add(j1);
                        //chkline = chkline + 1;

                        document.Add(Line);
                        chkline = chkline + 1;

                        string casccode = "", cacsprctQty = "";
                        MyClass obj3 = new MyClass();
                        string CascQury = "Select * from CASCDtl where PermitId='" + dt.Rows[0]["PermitId"].ToString() + "'";
                        obj3.dr = obj3.ret_dr(CascQury);
                        if (obj3.dr.HasRows)
                        {
                            while (obj3.dr.Read())
                            {
                                casccode = obj3.dr["ProductCode"].ToString();
                                cacsprctQty = obj3.dr["Quantity"].ToString() + " " + obj3.dr["ProductUOM"].ToString();
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(casccode))
                        {
                            string page042 = "S/NO   CA/SC PRODUCT CODE                      CA/SC PRODUCT QTY & UNIT         ";
                            iTextSharp.text.Paragraph j3 = new iTextSharp.text.Paragraph(page042, times);
                            j3.Alignment = Element.ALIGN_LEFT;
                            document.Add(j3);
                            chkline = chkline + 1;

                            string page043 = "01  " + casccode + "                        " + cacsprctQty + "";
                            iTextSharp.text.Paragraph j4 = new iTextSharp.text.Paragraph(page043, times);
                            j4.Alignment = Element.ALIGN_LEFT;
                            document.Add(j4);
                            chkline = chkline + 1;

                            document.Add(Line);
                            chkline = chkline + 1;
                        }
                        else
                        {
                            ////string page043 = " ";
                            ////iTextSharp.text.Paragraph j4 = new iTextSharp.text.Paragraph(page043, times);
                            ////j4.Alignment = Element.ALIGN_LEFT;
                            ////document.Add(j4);
                            ////chkline = chkline + 1;

                            //string page046 = "  ";
                            //iTextSharp.text.Paragraph j7 = new iTextSharp.text.Paragraph(page046, times);
                            //j7.Alignment = Element.ALIGN_LEFT;
                            //document.Add(j7);
                            //chkline = chkline + 1;

                        }



                        //string page045 = "S/NO   ENGINE NO/CHASSIS NO (46)                                                ";
                        //iTextSharp.text.Paragraph j6 = new iTextSharp.text.Paragraph(page045, times);
                        //j6.Alignment = Element.ALIGN_LEFT;
                        //document.Add(j6);
                        //chkline = chkline + 1;

                        //string page046 = "ZZZ99  XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX/XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX  ";
                        //iTextSharp.text.Paragraph j7 = new iTextSharp.text.Paragraph(page046, times);
                        //j7.Alignment = Element.ALIGN_LEFT;
                        //document.Add(j7);
                        //chkline = chkline + 1;
                        //document.Add(Line);
                        //chkline = chkline + 1;


                        document.Add(new Paragraph("\n"));
                        chkline = chkline + 1;

                        //document.Add(Line);
                        //chkline = chkline + 1;

                        //string page052 = "XX  XX   XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
                        //iTextSharp.text.Paragraph k3 = new iTextSharp.text.Paragraph(page052, times);
                        //k3.Alignment = Element.ALIGN_LEFT;
                        //document.Add(k3);
                        //chkline = chkline + 1;

                        //string page051 = "ZZZ99  XXXXXXXXXX  XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
                        //iTextSharp.text.Paragraph k2 = new iTextSharp.text.Paragraph(page051, times);
                        //k2.Alignment = Element.ALIGN_LEFT;
                        //document.Add(k2);
                        //chkline = chkline + 1;

                        //string page053 = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX          XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
                        //iTextSharp.text.Paragraph k4 = new iTextSharp.text.Paragraph(page053, times);
                        //k4.Alignment = Element.ALIGN_LEFT;
                        //document.Add(k4);
                        //chkline = chkline + 1;

                        //string page054 = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX          XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
                        //iTextSharp.text.Paragraph k5 = new iTextSharp.text.Paragraph(page054, times);
                        //k5.Alignment = Element.ALIGN_LEFT;
                        //document.Add(k5);
                        //chkline = chkline + 1;

                        //string page055 = "ZZZZZZZ9 XXX ZZZZZZZ9 XXX                                   ZZZZZZZZZZ9.9999 XXX";
                        //iTextSharp.text.Paragraph k6 = new iTextSharp.text.Paragraph(page055, times);
                        //k6.Alignment = Element.ALIGN_LEFT;
                        //document.Add(k6);
                        //chkline = chkline + 1;

                        //string page056 = "ZZZZZZZ9 XXX ZZZZZZZ9 XXX                                   ZZZZZZZZZZ9.99      ";
                        //iTextSharp.text.Paragraph k7 = new iTextSharp.text.Paragraph(page056, times);
                        //k7.Alignment = Element.ALIGN_LEFT;
                        //document.Add(k7);
                        //chkline = chkline + 1;

                        //string page057 = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX          ZZZZZZZZZZ9.99      ";
                        //iTextSharp.text.Paragraph k8 = new iTextSharp.text.Paragraph(page057, times);
                        //k8.Alignment = Element.ALIGN_LEFT;
                        //document.Add(k8);
                        //chkline = chkline + 1;

                        //string page058 = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX          ZZZZZZZZZZ9.99     ";
                        //iTextSharp.text.Paragraph k9 = new iTextSharp.text.Paragraph(page058, times);
                        //k9.Alignment = Element.ALIGN_LEFT;
                        //document.Add(k9);
                        //chkline = chkline + 1;

                        //string page059 = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX          ZZZZZZZZZZ9.9999 XXX";
                        //iTextSharp.text.Paragraph l0 = new iTextSharp.text.Paragraph(page059, times);
                        //l0.Alignment = Element.ALIGN_LEFT;
                        //document.Add(l0);
                        //chkline = chkline + 1;

                        //string page060 = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX          ZZZZZZZZZZ9.9999 XXX";
                        //iTextSharp.text.Paragraph l1 = new iTextSharp.text.Paragraph(page060, times);
                        //l1.Alignment = Element.ALIGN_LEFT;
                        //document.Add(l1);
                        //chkline = chkline + 1;

                        if (chkline == 60)
                        {
                            document.Add(Line);
                            chkline = chkline + 1;

                            msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                            string page062 = "UNIQUE REF : 201834618Z " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(9) + "";
                            iTextSharp.text.Paragraph l3 = new iTextSharp.text.Paragraph(page062, times);
                            l3.Alignment = Element.ALIGN_LEFT;
                            document.Add(l3);
                            chkline = chkline + 1;
                            chkline = 0;
                        }


                    }
                }
            }



            ////string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";                                      

            if (chkline < Linecount)
            {
                if (chkline == 59)
                {
                    document.Add(Line);
                    chkline = chkline + 1;
                    msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                    string page335 = "UNIQUE REF : 201834618Z " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(9) + "";
                    iTextSharp.text.Paragraph am4 = new iTextSharp.text.Paragraph(page335, times);
                    am4.Alignment = Element.ALIGN_LEFT;
                    document.Add(am4);
                    chkline = chkline + 1;

                    string pager35 = "                                                                               ";
                    iTextSharp.text.Paragraph ym4 = new iTextSharp.text.Paragraph(pager35, times);
                    ym4.Alignment = Element.ALIGN_LEFT;
                    document.Add(ym4);
                    chkline = chkline + 1;
                }
                else
                {
                    string page198 = "                                                                             ";
                    iTextSharp.text.Paragraph al2 = new iTextSharp.text.Paragraph(page198, times);
                    al2.Alignment = Element.ALIGN_LEFT;
                    document.Add(al2);
                    chkline = chkline + 1;
                }
            }
            else
            {
                chkline = 0;
                string page336 = "                                     CARGO CLEARANCE PERMIT        Page z1 OF z3";
                iTextSharp.text.Paragraph am5 = new iTextSharp.text.Paragraph(page336, times);
                am5.Alignment = Element.ALIGN_LEFT;
                document.Add(am5);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page337 = "PERMIT NO : XXXXXXXXXXX     (12)     ======================                     ";
                iTextSharp.text.Paragraph am6 = new iTextSharp.text.Paragraph(page337, times);
                am6.Alignment = Element.ALIGN_LEFT;
                document.Add(am6);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page338 = "                                      (CONTINUATION PAGE)                       ";
                iTextSharp.text.Paragraph am7 = new iTextSharp.text.Paragraph(page338, times);
                am7.Alignment = Element.ALIGN_LEFT;
                document.Add(am7);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page339 = "CONSIGNMENT DETAILS (Cont’d)                                                          ";
                iTextSharp.text.Paragraph am8 = new iTextSharp.text.Paragraph(page339, times);
                am8.Alignment = Element.ALIGN_LEFT;
                document.Add(am8);
                chkline = chkline + 1;

                ////string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                //string page183 = "--------------------------------------------------------------------------------";
                //iTextSharp.text.Paragraph x6 = new iTextSharp.text.Paragraph(page183, times);
                //x6.Alignment = Element.ALIGN_LEFT;
                //document.Add(x6);
                document.Add(Line);
                chkline = chkline + 1;

            }



            if (chkline < Linecount)
            {
                if (chkline == 59)
                {
                    document.Add(Line);
                    chkline = chkline + 1;
                    msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                    string page335 = "UNIQUE REF : 201834618Z " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(9) + "";
                    iTextSharp.text.Paragraph am4 = new iTextSharp.text.Paragraph(page335, times);
                    am4.Alignment = Element.ALIGN_LEFT;
                    document.Add(am4);
                    chkline = chkline + 1;

                    string pager35 = "                                                                               ";
                    iTextSharp.text.Paragraph ym4 = new iTextSharp.text.Paragraph(pager35, times);
                    ym4.Alignment = Element.ALIGN_LEFT;
                    document.Add(ym4);
                    chkline = chkline + 1;
                }
                else
                {
                    string page322 = "                                                                             ";
                    iTextSharp.text.Paragraph al3 = new iTextSharp.text.Paragraph(page322, times);
                    al3.Alignment = Element.ALIGN_LEFT;
                    document.Add(al3);
                    document.Add(Line);
                    chkline = chkline + 1;
                }
            }
            else
            {
                chkline = 0;
                string page336 = "                                     CARGO CLEARANCE PERMIT        Page z1 OF z3";
                iTextSharp.text.Paragraph am5 = new iTextSharp.text.Paragraph(page336, times);
                am5.Alignment = Element.ALIGN_LEFT;
                document.Add(am5);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page337 = "PERMIT NO : XXXXXXXXXXX     (12)     ======================                     ";
                iTextSharp.text.Paragraph am6 = new iTextSharp.text.Paragraph(page337, times);
                am6.Alignment = Element.ALIGN_LEFT;
                document.Add(am6);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page338 = "                                      (CONTINUATION PAGE)                       ";
                iTextSharp.text.Paragraph am7 = new iTextSharp.text.Paragraph(page338, times);
                am7.Alignment = Element.ALIGN_LEFT;
                document.Add(am7);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page339 = "CONSIGNMENT DETAILS (Cont’d)                                                          ";
                iTextSharp.text.Paragraph am8 = new iTextSharp.text.Paragraph(page339, times);
                am8.Alignment = Element.ALIGN_LEFT;
                document.Add(am8);
                chkline = chkline + 1;

                ////string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                //string page183 = "--------------------------------------------------------------------------------";
                //iTextSharp.text.Paragraph x6 = new iTextSharp.text.Paragraph(page183, times);
                //x6.Alignment = Element.ALIGN_LEFT;
                //document.Add(x6);
                document.Add(Line);
                chkline = chkline + 1;

            }
            //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
            if (chkline < Linecount)
            {
                if (chkline == 59)
                {
                    document.Add(Line);
                    chkline = chkline + 1;
                    msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                    string page335 = "UNIQUE REF : 201834618Z " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(9) + "";
                    iTextSharp.text.Paragraph am4 = new iTextSharp.text.Paragraph(page335, times);
                    am4.Alignment = Element.ALIGN_LEFT;
                    document.Add(am4);
                    chkline = chkline + 1;

                    string pager35 = "                                                                               ";
                    iTextSharp.text.Paragraph ym4 = new iTextSharp.text.Paragraph(pager35, times);
                    ym4.Alignment = Element.ALIGN_LEFT;
                    document.Add(ym4);
                    chkline = chkline + 1;
                }
                else
                {
                    string page323 = "TRADER’s REMARKS                                                            ";
                    iTextSharp.text.Paragraph al4 = new iTextSharp.text.Paragraph(page323, times);
                    al4.Alignment = Element.ALIGN_LEFT;
                    document.Add(al4);
                    chkline = chkline + 1;
                }
            }
            else
            {
                chkline = 0;
                string page336 = "                                     CARGO CLEARANCE PERMIT        Page z1 OF z3";
                iTextSharp.text.Paragraph am5 = new iTextSharp.text.Paragraph(page336, times);
                am5.Alignment = Element.ALIGN_LEFT;
                document.Add(am5);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page337 = "PERMIT NO : XXXXXXXXXXX     (12)     ======================                     ";
                iTextSharp.text.Paragraph am6 = new iTextSharp.text.Paragraph(page337, times);
                am6.Alignment = Element.ALIGN_LEFT;
                document.Add(am6);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page338 = "                                      (CONTINUATION PAGE)                       ";
                iTextSharp.text.Paragraph am7 = new iTextSharp.text.Paragraph(page338, times);
                am7.Alignment = Element.ALIGN_LEFT;
                document.Add(am7);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page339 = "CONSIGNMENT DETAILS (Cont’d)                                                          ";
                iTextSharp.text.Paragraph am8 = new iTextSharp.text.Paragraph(page339, times);
                am8.Alignment = Element.ALIGN_LEFT;
                document.Add(am8);
                chkline = chkline + 1;

                ////string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                //string page183 = "--------------------------------------------------------------------------------";
                //iTextSharp.text.Paragraph x6 = new iTextSharp.text.Paragraph(page183, times);
                //x6.Alignment = Element.ALIGN_LEFT;
                //document.Add(x6);
                document.Add(Line);
                chkline = chkline + 1;

            }

            if (chkline < Linecount)
            {
                if (chkline == 59)
                {
                    document.Add(Line);
                    chkline = chkline + 1;
                    msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                    string page335 = "UNIQUE REF : 201834618Z " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(9) + "";
                    iTextSharp.text.Paragraph am4 = new iTextSharp.text.Paragraph(page335, times);
                    am4.Alignment = Element.ALIGN_LEFT;
                    document.Add(am4);
                    chkline = chkline + 1;

                    string pager35 = "                                                                               ";
                    iTextSharp.text.Paragraph ym4 = new iTextSharp.text.Paragraph(pager35, times);
                    ym4.Alignment = Element.ALIGN_LEFT;
                    document.Add(ym4);
                    chkline = chkline + 1;
                }
                else
                {
                    string page324 = "" + dt.Rows[0]["TradeRemarks"].ToString() + "";
                    iTextSharp.text.Paragraph al5 = new iTextSharp.text.Paragraph(page324, times);
                    al5.Alignment = Element.ALIGN_LEFT;
                    document.Add(al5);
                    chkline = chkline + 1;
                }
            }

            else
            {
                chkline = 0;
                string page336 = "                                     CARGO CLEARANCE PERMIT        Page z1 OF z3";
                iTextSharp.text.Paragraph am5 = new iTextSharp.text.Paragraph(page336, times);
                am5.Alignment = Element.ALIGN_LEFT;
                document.Add(am5);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page337 = "PERMIT NO : XXXXXXXXXXX     (12)     ======================                     ";
                iTextSharp.text.Paragraph am6 = new iTextSharp.text.Paragraph(page337, times);
                am6.Alignment = Element.ALIGN_LEFT;
                document.Add(am6);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page338 = "                                      (CONTINUATION PAGE)                       ";
                iTextSharp.text.Paragraph am7 = new iTextSharp.text.Paragraph(page338, times);
                am7.Alignment = Element.ALIGN_LEFT;
                document.Add(am7);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page339 = "CONSIGNMENT DETAILS (Cont’d)                                                          ";
                iTextSharp.text.Paragraph am8 = new iTextSharp.text.Paragraph(page339, times);
                am8.Alignment = Element.ALIGN_LEFT;
                document.Add(am8);
                chkline = chkline + 1;

                ////string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                //string page183 = "--------------------------------------------------------------------------------";
                //iTextSharp.text.Paragraph x6 = new iTextSharp.text.Paragraph(page183, times);
                //x6.Alignment = Element.ALIGN_LEFT;
                //document.Add(x6);
                document.Add(Line);
                chkline = chkline + 1;

            }

            //string page325 = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            //iTextSharp.text.Paragraph al6 = new iTextSharp.text.Paragraph(page325, times);
            //al6.Alignment = Element.ALIGN_LEFT;
            //document.Add(al6);

            //string page326 = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            //iTextSharp.text.Paragraph al7 = new iTextSharp.text.Paragraph(page326, times);
            //al7.Alignment = Element.ALIGN_LEFT;
            //document.Add(al7);


            //string page327 = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            //iTextSharp.text.Paragraph al8 = new iTextSharp.text.Paragraph(page327, times);
            //al8.Alignment = Element.ALIGN_LEFT;
            //document.Add(al8);

            //string page328 = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            //iTextSharp.text.Paragraph al9 = new iTextSharp.text.Paragraph(page328, times);
            //al9.Alignment = Element.ALIGN_LEFT;
            //document.Add(al9);

            //string page329 = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            //iTextSharp.text.Paragraph al10 = new iTextSharp.text.Paragraph(page329, times);
            //al10.Alignment = Element.ALIGN_LEFT;
            //document.Add(al10);

            //string page330 = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX                                                ";
            //iTextSharp.text.Paragraph al11 = new iTextSharp.text.Paragraph(page330, times);
            //al11.Alignment = Element.ALIGN_LEFT;
            //document.Add(al11);
            if (chkline < Linecount)
            {
                if (chkline == 59)
                {
                    document.Add(Line);
                    chkline = chkline + 1;

                    msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                    string page335 = "UNIQUE REF : 201834618Z " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(9) + "";
                    iTextSharp.text.Paragraph am4 = new iTextSharp.text.Paragraph(page335, times);
                    am4.Alignment = Element.ALIGN_LEFT;
                    document.Add(am4);
                    chkline = chkline + 1;

                    string pager35 = "                                                                               ";
                    iTextSharp.text.Paragraph ym4 = new iTextSharp.text.Paragraph(pager35, times);
                    ym4.Alignment = Element.ALIGN_LEFT;
                    document.Add(ym4);
                    chkline = chkline + 1;
                }
                else
                {
                    document.Add(Line);
                    chkline = chkline + 1;
                }
            }
            else
            {
                chkline = 0;
                string page336 = "                                     CARGO CLEARANCE PERMIT        Page z1 OF z3";
                iTextSharp.text.Paragraph am5 = new iTextSharp.text.Paragraph(page336, times);
                am5.Alignment = Element.ALIGN_LEFT;
                document.Add(am5);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page337 = "PERMIT NO : XXXXXXXXXXX     (12)     ======================                     ";
                iTextSharp.text.Paragraph am6 = new iTextSharp.text.Paragraph(page337, times);
                am6.Alignment = Element.ALIGN_LEFT;
                document.Add(am6);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page338 = "                                      (CONTINUATION PAGE)                       ";
                iTextSharp.text.Paragraph am7 = new iTextSharp.text.Paragraph(page338, times);
                am7.Alignment = Element.ALIGN_LEFT;
                document.Add(am7);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page339 = "CONSIGNMENT DETAILS (Cont’d)                                                          ";
                iTextSharp.text.Paragraph am8 = new iTextSharp.text.Paragraph(page339, times);
                am8.Alignment = Element.ALIGN_LEFT;
                document.Add(am8);
                chkline = chkline + 1;

                ////string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                //string page183 = "--------------------------------------------------------------------------------";
                //iTextSharp.text.Paragraph x6 = new iTextSharp.text.Paragraph(page183, times);
                //x6.Alignment = Element.ALIGN_LEFT;
                //document.Add(x6);
                document.Add(Line);
                chkline = chkline + 1;

            }

            if (chkline < Linecount)
            {
                if (chkline == 59)
                {
                    document.Add(Line);
                    chkline = chkline + 1;

                    string page335 = "UNIQUE REF : XXXXXXXXXXXXXXXXX CCYYMMDD 9999 (64)                              ";
                    iTextSharp.text.Paragraph am4 = new iTextSharp.text.Paragraph(page335, times);
                    am4.Alignment = Element.ALIGN_LEFT;
                    document.Add(am4);
                    chkline = chkline + 1;

                    string pager35 = "                                                                               ";
                    iTextSharp.text.Paragraph ym4 = new iTextSharp.text.Paragraph(pager35, times);
                    ym4.Alignment = Element.ALIGN_LEFT;
                    document.Add(ym4);
                    chkline = chkline + 1;
                }
                else
                {
                    string page331 = "CONTAINER IDENTIFIERS                                                       ";
                    iTextSharp.text.Paragraph am0 = new iTextSharp.text.Paragraph(page331, times);
                    am0.Alignment = Element.ALIGN_LEFT;
                    document.Add(am0);
                    chkline = chkline + 1;
                }
            }
            else
            {
                chkline = 0;
                string page336 = "                                     CARGO CLEARANCE PERMIT        Page z1 OF z3";
                iTextSharp.text.Paragraph am5 = new iTextSharp.text.Paragraph(page336, times);
                am5.Alignment = Element.ALIGN_LEFT;
                document.Add(am5);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page337 = "PERMIT NO : XXXXXXXXXXX     (12)     ======================                     ";
                iTextSharp.text.Paragraph am6 = new iTextSharp.text.Paragraph(page337, times);
                am6.Alignment = Element.ALIGN_LEFT;
                document.Add(am6);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page338 = "                                      (CONTINUATION PAGE)                       ";
                iTextSharp.text.Paragraph am7 = new iTextSharp.text.Paragraph(page338, times);
                am7.Alignment = Element.ALIGN_LEFT;
                document.Add(am7);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page339 = "CONSIGNMENT DETAILS (Cont’d)                                                          ";
                iTextSharp.text.Paragraph am8 = new iTextSharp.text.Paragraph(page339, times);
                am8.Alignment = Element.ALIGN_LEFT;
                document.Add(am8);
                chkline = chkline + 1;

                ////string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                //string page183 = "--------------------------------------------------------------------------------";
                //iTextSharp.text.Paragraph x6 = new iTextSharp.text.Paragraph(page183, times);
                //x6.Alignment = Element.ALIGN_LEFT;
                //document.Add(x6);
                document.Add(Line);
                chkline = chkline + 1;

            }

            string csno = "", cName = "", Ctype = "", cVal = "", cVal1 = "";
            MyClass obj5 = new MyClass();
            string Conqury = "select * from ContainerDtl where PermitId='" + dt.Rows[0]["PermitId"].ToString() + "'";
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
                    if (chkline < Linecount)
                    {
                        if (chkline == 59)
                        {
                            document.Add(Line);
                            chkline = chkline + 1;

                            msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                            string page335 = "UNIQUE REF : 201834618Z " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(9) + "";
                            iTextSharp.text.Paragraph am4 = new iTextSharp.text.Paragraph(page335, times);
                            am4.Alignment = Element.ALIGN_LEFT;
                            document.Add(am4);
                            chkline = chkline + 1;

                            string pager35 = "                                                                               ";
                            iTextSharp.text.Paragraph ym4 = new iTextSharp.text.Paragraph(pager35, times);
                            ym4.Alignment = Element.ALIGN_LEFT;
                            document.Add(ym4);
                            chkline = chkline + 1;
                        }
                        else
                        {
                            if (csno.Length < 2)
                            {
                                csno = "0" + csno + ")";
                            }
                            if (cVal.Length < 3)
                            {
                                cVal = "00" + cVal;
                            }
                            string[] Ctype1 = Ctype.Split(':');
                            string page332 = "" + csno + "  " + cName + " " + Ctype1[0].ToString().Substring(0, Ctype1[0].ToString().Length - 1) + " " + cVal + " " + cVal1 + "             ";
                            iTextSharp.text.Paragraph am1 = new iTextSharp.text.Paragraph(page332, times);
                            am1.Alignment = Element.ALIGN_LEFT;
                            document.Add(am1);
                            chkline = chkline + 1;
                        }
                    }
                    else
                    {
                        chkline = 0;
                        string page336 = "                                     CARGO CLEARANCE PERMIT        Page z1 OF z3";
                        iTextSharp.text.Paragraph am5 = new iTextSharp.text.Paragraph(page336, times);
                        am5.Alignment = Element.ALIGN_LEFT;
                        document.Add(am5);
                        chkline = chkline + 1;

                        //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                        string page337 = "PERMIT NO : XXXXXXXXXXX     (12)     ======================                     ";
                        iTextSharp.text.Paragraph am6 = new iTextSharp.text.Paragraph(page337, times);
                        am6.Alignment = Element.ALIGN_LEFT;
                        document.Add(am6);
                        chkline = chkline + 1;

                        //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                        string page338 = "                                      (CONTINUATION PAGE)                       ";
                        iTextSharp.text.Paragraph am7 = new iTextSharp.text.Paragraph(page338, times);
                        am7.Alignment = Element.ALIGN_LEFT;
                        document.Add(am7);
                        chkline = chkline + 1;

                        //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                        string page339 = "CONSIGNMENT DETAILS (Cont’d)                                                          ";
                        iTextSharp.text.Paragraph am8 = new iTextSharp.text.Paragraph(page339, times);
                        am8.Alignment = Element.ALIGN_LEFT;
                        document.Add(am8);
                        chkline = chkline + 1;

                        ////string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                        //string page183 = "--------------------------------------------------------------------------------";
                        //iTextSharp.text.Paragraph x6 = new iTextSharp.text.Paragraph(page183, times);
                        //x6.Alignment = Element.ALIGN_LEFT;
                        //document.Add(x6);
                        document.Add(Line);
                        chkline = chkline + 1;

                    }
                }
            }


            //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";            


            //if (chkline < Linecount)
            //{
            //    if (chkline == 59)
            //    {
            //        document.Add(Line);
            //        chkline = chkline + 1;

            //        string page335 = "UNIQUE REF : XXXXXXXXXXXXXXXXX CCYYMMDD 9999 (64)                              ";
            //        iTextSharp.text.Paragraph am4 = new iTextSharp.text.Paragraph(page335, times);
            //        am4.Alignment = Element.ALIGN_LEFT;
            //        document.Add(am4);
            //        chkline = chkline + 1;

            //        string pager35 = "                                                                               ";
            //        iTextSharp.text.Paragraph ym4 = new iTextSharp.text.Paragraph(pager35, times);
            //        ym4.Alignment = Element.ALIGN_LEFT;
            //        document.Add(ym4);
            //        chkline = chkline + 1;
            //    }
            //    else
            //    {
            //        string page341 = "                                                                                 ";
            //        iTextSharp.text.Paragraph an0 = new iTextSharp.text.Paragraph(page341, times);
            //        an0.Alignment = Element.ALIGN_LEFT;
            //        document.Add(an0);
            //        chkline = chkline + 1;
            //    }
            //}            
            //else
            //{
            //    chkline = 0;
            //    string page336 = "                                     CARGO CLEARANCE PERMIT        Page z1 OF z3";
            //    iTextSharp.text.Paragraph am5 = new iTextSharp.text.Paragraph(page336, times);
            //    am5.Alignment = Element.ALIGN_LEFT;
            //    document.Add(am5);
            //    chkline = chkline + 1;

            //    //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
            //    string page337 = "PERMIT NO : XXXXXXXXXXX     (12)     ======================                     ";
            //    iTextSharp.text.Paragraph am6 = new iTextSharp.text.Paragraph(page337, times);
            //    am6.Alignment = Element.ALIGN_LEFT;
            //    document.Add(am6);
            //    chkline = chkline + 1;

            //    //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
            //    string page338 = "                                      (CONTINUATION PAGE)                       ";
            //    iTextSharp.text.Paragraph am7 = new iTextSharp.text.Paragraph(page338, times);
            //    am7.Alignment = Element.ALIGN_LEFT;
            //    document.Add(am7);
            //    chkline = chkline + 1;

            //    //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
            //    string page339 = "CONSIGNMENT DETAILS (Cont’d)                                                          ";
            //    iTextSharp.text.Paragraph am8 = new iTextSharp.text.Paragraph(page339, times);
            //    am8.Alignment = Element.ALIGN_LEFT;
            //    document.Add(am8);
            //    chkline = chkline + 1;

            //    ////string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
            //    //string page183 = "--------------------------------------------------------------------------------";
            //    //iTextSharp.text.Paragraph x6 = new iTextSharp.text.Paragraph(page183, times);
            //    //x6.Alignment = Element.ALIGN_LEFT;
            //    //document.Add(x6);
            //    document.Add(Line);
            //    chkline = chkline + 1;

            //}

            if (chkline < Linecount)
            {
                if (chkline == 59)
                {
                    document.Add(Line);
                    chkline = chkline + 1;

                    msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                    string page335 = "UNIQUE REF : 201834618Z " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(9) + "";
                    iTextSharp.text.Paragraph am4 = new iTextSharp.text.Paragraph(page335, times);
                    am4.Alignment = Element.ALIGN_LEFT;
                    document.Add(am4);
                    chkline = chkline + 1;

                    string pager35 = "                                                                               ";
                    iTextSharp.text.Paragraph ym4 = new iTextSharp.text.Paragraph(pager35, times);
                    ym4.Alignment = Element.ALIGN_LEFT;
                    document.Add(ym4);
                    chkline = chkline + 1;
                }
                else
                {
                    document.Add(Line);
                    chkline = chkline + 1;
                }
            }
            else
            {
                chkline = 0;
                string page336 = "                                     CARGO CLEARANCE PERMIT        Page z1 OF z3";
                iTextSharp.text.Paragraph am5 = new iTextSharp.text.Paragraph(page336, times);
                am5.Alignment = Element.ALIGN_LEFT;
                document.Add(am5);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page337 = "PERMIT NO : XXXXXXXXXXX     (12)     ======================                     ";
                iTextSharp.text.Paragraph am6 = new iTextSharp.text.Paragraph(page337, times);
                am6.Alignment = Element.ALIGN_LEFT;
                document.Add(am6);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page338 = "                                      (CONTINUATION PAGE)                       ";
                iTextSharp.text.Paragraph am7 = new iTextSharp.text.Paragraph(page338, times);
                am7.Alignment = Element.ALIGN_LEFT;
                document.Add(am7);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page339 = "CONSIGNMENT DETAILS (Cont’d)                                                          ";
                iTextSharp.text.Paragraph am8 = new iTextSharp.text.Paragraph(page339, times);
                am8.Alignment = Element.ALIGN_LEFT;
                document.Add(am8);
                chkline = chkline + 1;

                ////string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                //string page183 = "--------------------------------------------------------------------------------";
                //iTextSharp.text.Paragraph x6 = new iTextSharp.text.Paragraph(page183, times);
                //x6.Alignment = Element.ALIGN_LEFT;
                //document.Add(x6);
                document.Add(Line);
                chkline = chkline + 1;

            }

            if (chkline < Linecount)
            {
                if (chkline == 59)
                {
                    document.Add(Line);
                    chkline = chkline + 1;
                    msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                    string page335 = "UNIQUE REF : 201834618Z " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(9) + "";
                    iTextSharp.text.Paragraph am4 = new iTextSharp.text.Paragraph(page335, times);
                    am4.Alignment = Element.ALIGN_LEFT;
                    document.Add(am4);
                    chkline = chkline + 1;

                    string pager35 = "                                                                               ";
                    iTextSharp.text.Paragraph ym4 = new iTextSharp.text.Paragraph(pager35, times);
                    ym4.Alignment = Element.ALIGN_LEFT;
                    document.Add(ym4);
                    chkline = chkline + 1;
                }
                else
                {
                    string page342 = "NO UNAUTHORISED ADDITION/AMENDMENT TO THIS PERMIT MAY BE MADE AFTER APPROVAL     ";
                    iTextSharp.text.Paragraph an1 = new iTextSharp.text.Paragraph(page342, times);
                    an1.Alignment = Element.ALIGN_LEFT;
                    document.Add(an1);
                    chkline = chkline + 1;
                }
            }
            else
            {
                chkline = 0;
                string page336 = "                                     CARGO CLEARANCE PERMIT        Page z1 OF z3";
                iTextSharp.text.Paragraph am5 = new iTextSharp.text.Paragraph(page336, times);
                am5.Alignment = Element.ALIGN_LEFT;
                document.Add(am5);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page337 = "PERMIT NO : XXXXXXXXXXX     (12)     ======================                     ";
                iTextSharp.text.Paragraph am6 = new iTextSharp.text.Paragraph(page337, times);
                am6.Alignment = Element.ALIGN_LEFT;
                document.Add(am6);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page338 = "                                      (CONTINUATION PAGE)                       ";
                iTextSharp.text.Paragraph am7 = new iTextSharp.text.Paragraph(page338, times);
                am7.Alignment = Element.ALIGN_LEFT;
                document.Add(am7);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page339 = "CONSIGNMENT DETAILS (Cont’d)                                                          ";
                iTextSharp.text.Paragraph am8 = new iTextSharp.text.Paragraph(page339, times);
                am8.Alignment = Element.ALIGN_LEFT;
                document.Add(am8);
                chkline = chkline + 1;

                ////string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                //string page183 = "--------------------------------------------------------------------------------";
                //iTextSharp.text.Paragraph x6 = new iTextSharp.text.Paragraph(page183, times);
                //x6.Alignment = Element.ALIGN_LEFT;
                //document.Add(x6);
                document.Add(Line);
                chkline = chkline + 1;

            }
            if (chkline < Linecount)
            {
                if (chkline == 59)
                {
                    document.Add(Line);
                    chkline = chkline + 1;
                    msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                    string page335 = "UNIQUE REF : 201834618Z " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(9) + "";
                    iTextSharp.text.Paragraph am4 = new iTextSharp.text.Paragraph(page335, times);
                    am4.Alignment = Element.ALIGN_LEFT;
                    document.Add(am4);
                    chkline = chkline + 1;

                    string pager35 = "                                                                               ";
                    iTextSharp.text.Paragraph ym4 = new iTextSharp.text.Paragraph(pager35, times);
                    ym4.Alignment = Element.ALIGN_LEFT;
                    document.Add(ym4);
                    chkline = chkline + 1;
                }
                else
                {
                    document.Add(Line);
                    chkline = chkline + 1;
                }
            }
            else
            {
                chkline = 0;
                string page336 = "                                     CARGO CLEARANCE PERMIT        Page z1 OF z3";
                iTextSharp.text.Paragraph am5 = new iTextSharp.text.Paragraph(page336, times);
                am5.Alignment = Element.ALIGN_LEFT;
                document.Add(am5);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page337 = "PERMIT NO : XXXXXXXXXXX     (12)     ======================                     ";
                iTextSharp.text.Paragraph am6 = new iTextSharp.text.Paragraph(page337, times);
                am6.Alignment = Element.ALIGN_LEFT;
                document.Add(am6);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page338 = "                                      (CONTINUATION PAGE)                       ";
                iTextSharp.text.Paragraph am7 = new iTextSharp.text.Paragraph(page338, times);
                am7.Alignment = Element.ALIGN_LEFT;
                document.Add(am7);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page339 = "CONSIGNMENT DETAILS (Cont’d)                                                          ";
                iTextSharp.text.Paragraph am8 = new iTextSharp.text.Paragraph(page339, times);
                am8.Alignment = Element.ALIGN_LEFT;
                document.Add(am8);
                chkline = chkline + 1;

                ////string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                //string page183 = "--------------------------------------------------------------------------------";
                //iTextSharp.text.Paragraph x6 = new iTextSharp.text.Paragraph(page183, times);
                //x6.Alignment = Element.ALIGN_LEFT;
                //document.Add(x6);
                document.Add(Line);
                chkline = chkline + 1;

            }

            //if (chkline < Linecount)
            //{
            //    if (chkline == 59)
            //    {
            //        document.Add(Line);
            //        chkline = chkline + 1;

            //        string page335 = "UNIQUE REF : XXXXXXXXXXXXXXXXX CCYYMMDD 9999 (64)                              ";
            //        iTextSharp.text.Paragraph am4 = new iTextSharp.text.Paragraph(page335, times);
            //        am4.Alignment = Element.ALIGN_LEFT;
            //        document.Add(am4);
            //        chkline = chkline + 1;

            //        string pager35 = "                                                                               ";
            //        iTextSharp.text.Paragraph ym4 = new iTextSharp.text.Paragraph(pager35, times);
            //        ym4.Alignment = Element.ALIGN_LEFT;
            //        document.Add(ym4);
            //        chkline = chkline + 1;
            //    }
            //    else
            //    {
            //        string page343 = "                                                                             ";
            //        iTextSharp.text.Paragraph an2 = new iTextSharp.text.Paragraph(page343, times);
            //        an2.Alignment = Element.ALIGN_LEFT;
            //        document.Add(an2);
            //        chkline = chkline + 1;
            //    }
            //}            
            //else
            //{
            //    chkline = 0;
            //    string page336 = "                                     CARGO CLEARANCE PERMIT        Page z1 OF z3";
            //    iTextSharp.text.Paragraph am5 = new iTextSharp.text.Paragraph(page336, times);
            //    am5.Alignment = Element.ALIGN_LEFT;
            //    document.Add(am5);
            //    chkline = chkline + 1;

            //    //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
            //    string page337 = "PERMIT NO : XXXXXXXXXXX     (12)     ======================                     ";
            //    iTextSharp.text.Paragraph am6 = new iTextSharp.text.Paragraph(page337, times);
            //    am6.Alignment = Element.ALIGN_LEFT;
            //    document.Add(am6);
            //    chkline = chkline + 1;

            //    //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
            //    string page338 = "                                      (CONTINUATION PAGE)                       ";
            //    iTextSharp.text.Paragraph am7 = new iTextSharp.text.Paragraph(page338, times);
            //    am7.Alignment = Element.ALIGN_LEFT;
            //    document.Add(am7);
            //    chkline = chkline + 1;

            //    //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
            //    string page339 = "CONSIGNMENT DETAILS (Cont’d)                                                          ";
            //    iTextSharp.text.Paragraph am8 = new iTextSharp.text.Paragraph(page339, times);
            //    am8.Alignment = Element.ALIGN_LEFT;
            //    document.Add(am8);
            //    chkline = chkline + 1;

            //    ////string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
            //    //string page183 = "--------------------------------------------------------------------------------";
            //    //iTextSharp.text.Paragraph x6 = new iTextSharp.text.Paragraph(page183, times);
            //    //x6.Alignment = Element.ALIGN_LEFT;
            //    //document.Add(x6);
            //    document.Add(Line);
            //    chkline = chkline + 1;

            //}

            if (chkline < Linecount)
            {
                if (chkline == 59)
                {
                    document.Add(Line);
                    chkline = chkline + 1;
                    msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                    string page335 = "UNIQUE REF : 201834618Z " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(9) + "";
                    iTextSharp.text.Paragraph am4 = new iTextSharp.text.Paragraph(page335, times);
                    am4.Alignment = Element.ALIGN_LEFT;
                    document.Add(am4);
                    chkline = chkline + 1;

                    string pager35 = "                                                                               ";
                    iTextSharp.text.Paragraph ym4 = new iTextSharp.text.Paragraph(pager35, times);
                    ym4.Alignment = Element.ALIGN_LEFT;
                    document.Add(ym4);
                    chkline = chkline + 1;
                }
                else
                {
                    // string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                    string page344 = "NAME OF COMPANY: KAIZEN TRADE TECHNOLOGY PTE LTD             ";
                    iTextSharp.text.Paragraph an3 = new iTextSharp.text.Paragraph(page344, times);
                    an3.Alignment = Element.ALIGN_LEFT;
                    document.Add(an3);
                    chkline = chkline + 1;

                    string page3442 = "            ";
                    iTextSharp.text.Paragraph an32 = new iTextSharp.text.Paragraph(page3442, times);
                    an32.Alignment = Element.ALIGN_LEFT;
                    document.Add(an32);
                    chkline = chkline + 1;
                }
            }
            else
            {
                chkline = 0;
                string page336 = "                                     CARGO CLEARANCE PERMIT        Page z1 OF z3";
                iTextSharp.text.Paragraph am5 = new iTextSharp.text.Paragraph(page336, times);
                am5.Alignment = Element.ALIGN_LEFT;
                document.Add(am5);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page337 = "PERMIT NO : XXXXXXXXXXX     (12)     ======================                     ";
                iTextSharp.text.Paragraph am6 = new iTextSharp.text.Paragraph(page337, times);
                am6.Alignment = Element.ALIGN_LEFT;
                document.Add(am6);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page338 = "                                      (CONTINUATION PAGE)                       ";
                iTextSharp.text.Paragraph am7 = new iTextSharp.text.Paragraph(page338, times);
                am7.Alignment = Element.ALIGN_LEFT;
                document.Add(am7);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page339 = "CONSIGNMENT DETAILS (Cont’d)                                                          ";
                iTextSharp.text.Paragraph am8 = new iTextSharp.text.Paragraph(page339, times);
                am8.Alignment = Element.ALIGN_LEFT;
                document.Add(am8);
                chkline = chkline + 1;

                ////string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                //string page183 = "--------------------------------------------------------------------------------";
                //iTextSharp.text.Paragraph x6 = new iTextSharp.text.Paragraph(page183, times);
                //x6.Alignment = Element.ALIGN_LEFT;
                //document.Add(x6);
                document.Add(Line);
                chkline = chkline + 1;

            }


            //  string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
            //string page345 = "                 XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX             ";
            //iTextSharp.text.Paragraph an4 = new iTextSharp.text.Paragraph(page345, times);
            //an4.Alignment = Element.ALIGN_LEFT;
            //document.Add(an4);

            if (chkline < Linecount)
            {
                if (chkline == 59)
                {
                    document.Add(Line);
                    chkline = chkline + 1;
                    msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                    string page335 = "UNIQUE REF : 201834618Z " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(9) + "";
                    iTextSharp.text.Paragraph am4 = new iTextSharp.text.Paragraph(page335, times);
                    am4.Alignment = Element.ALIGN_LEFT;
                    document.Add(am4);
                    chkline = chkline + 1;

                    string pager35 = "                                                                               ";
                    iTextSharp.text.Paragraph ym4 = new iTextSharp.text.Paragraph(pager35, times);
                    ym4.Alignment = Element.ALIGN_LEFT;
                    document.Add(ym4);
                    chkline = chkline + 1;
                }
                else
                {
                    // string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                    string page346 = "DECLARANT NAME : ESVARAN ESVARAN             ";
                    iTextSharp.text.Paragraph an5 = new iTextSharp.text.Paragraph(page346, times);
                    an5.Alignment = Element.ALIGN_LEFT;
                    document.Add(an5);
                    chkline = chkline + 1;

                    string page3462 = "             ";
                    iTextSharp.text.Paragraph an52 = new iTextSharp.text.Paragraph(page3462, times);
                    an52.Alignment = Element.ALIGN_LEFT;
                    document.Add(an52);
                    chkline = chkline + 1;
                }
            }
            else
            {
                chkline = 0;
                string page336 = "                                     CARGO CLEARANCE PERMIT        Page z1 OF z3";
                iTextSharp.text.Paragraph am5 = new iTextSharp.text.Paragraph(page336, times);
                am5.Alignment = Element.ALIGN_LEFT;
                document.Add(am5);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page337 = "PERMIT NO : XXXXXXXXXXX     (12)     ======================                     ";
                iTextSharp.text.Paragraph am6 = new iTextSharp.text.Paragraph(page337, times);
                am6.Alignment = Element.ALIGN_LEFT;
                document.Add(am6);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page338 = "                                      (CONTINUATION PAGE)                       ";
                iTextSharp.text.Paragraph am7 = new iTextSharp.text.Paragraph(page338, times);
                am7.Alignment = Element.ALIGN_LEFT;
                document.Add(am7);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page339 = "CONSIGNMENT DETAILS (Cont’d)                                                          ";
                iTextSharp.text.Paragraph am8 = new iTextSharp.text.Paragraph(page339, times);
                am8.Alignment = Element.ALIGN_LEFT;
                document.Add(am8);
                chkline = chkline + 1;

                ////string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                //string page183 = "--------------------------------------------------------------------------------";
                //iTextSharp.text.Paragraph x6 = new iTextSharp.text.Paragraph(page183, times);
                //x6.Alignment = Element.ALIGN_LEFT;
                //document.Add(x6);
                document.Add(Line);
                chkline = chkline + 1;

            }

            // string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
            //string page347 = "                 XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX             ";
            //iTextSharp.text.Paragraph an6 = new iTextSharp.text.Paragraph(page347, times);
            //an6.Alignment = Element.ALIGN_LEFT;
            //document.Add(an6);

            if (chkline < Linecount)
            {
                if (chkline == 59)
                {
                    document.Add(Line);
                    chkline = chkline + 1;
                    msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                    string page335 = "UNIQUE REF : 201834618Z " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(9) + "";
                    iTextSharp.text.Paragraph am4 = new iTextSharp.text.Paragraph(page335, times);
                    am4.Alignment = Element.ALIGN_LEFT;
                    document.Add(am4);
                    chkline = chkline + 1;

                    string pager35 = "                                                                               ";
                    iTextSharp.text.Paragraph ym4 = new iTextSharp.text.Paragraph(pager35, times);
                    ym4.Alignment = Element.ALIGN_LEFT;
                    document.Add(ym4);
                    chkline = chkline + 1;
                }
                else
                {
                    // string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                    string page348 = "DECLARANT CODE : XXXX9336H                                              ";
                    iTextSharp.text.Paragraph an7 = new iTextSharp.text.Paragraph(page348, times);
                    an7.Alignment = Element.ALIGN_LEFT;
                    document.Add(an7);
                    chkline = chkline + 1;
                }
            }
            else
            {
                chkline = 0;
                string page336 = "                                     CARGO CLEARANCE PERMIT        Page z1 OF z3";
                iTextSharp.text.Paragraph am5 = new iTextSharp.text.Paragraph(page336, times);
                am5.Alignment = Element.ALIGN_LEFT;
                document.Add(am5);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page337 = "PERMIT NO : XXXXXXXXXXX     (12)     ======================                     ";
                iTextSharp.text.Paragraph am6 = new iTextSharp.text.Paragraph(page337, times);
                am6.Alignment = Element.ALIGN_LEFT;
                document.Add(am6);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page338 = "                                      (CONTINUATION PAGE)                       ";
                iTextSharp.text.Paragraph am7 = new iTextSharp.text.Paragraph(page338, times);
                am7.Alignment = Element.ALIGN_LEFT;
                document.Add(am7);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page339 = "CONSIGNMENT DETAILS (Cont’d)                                                          ";
                iTextSharp.text.Paragraph am8 = new iTextSharp.text.Paragraph(page339, times);
                am8.Alignment = Element.ALIGN_LEFT;
                document.Add(am8);
                chkline = chkline + 1;

                ////string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                //string page183 = "--------------------------------------------------------------------------------";
                //iTextSharp.text.Paragraph x6 = new iTextSharp.text.Paragraph(page183, times);
                //x6.Alignment = Element.ALIGN_LEFT;
                //document.Add(x6);
                document.Add(Line);
                chkline = chkline + 1;

            }

            if (chkline < Linecount)
            {
                if (chkline == 59)
                {
                    document.Add(Line);
                    chkline = chkline + 1;
                    msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                    string page335 = "UNIQUE REF : 201834618Z " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(9) + "";
                    iTextSharp.text.Paragraph am4 = new iTextSharp.text.Paragraph(page335, times);
                    am4.Alignment = Element.ALIGN_LEFT;
                    document.Add(am4);
                    chkline = chkline + 1;

                    string pager35 = "                                                                               ";
                    iTextSharp.text.Paragraph ym4 = new iTextSharp.text.Paragraph(pager35, times);
                    ym4.Alignment = Element.ALIGN_LEFT;
                    document.Add(ym4);
                    chkline = chkline + 1;
                }
                else
                {
                    //  string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                    string page349 = "TEL NO         : 94550043                                              ";
                    iTextSharp.text.Paragraph an8 = new iTextSharp.text.Paragraph(page349, times);
                    an8.Alignment = Element.ALIGN_LEFT;
                    document.Add(an8);
                    chkline = chkline + 1;
                }
            }
            else
            {
                chkline = 0;
                string page336 = "                                     CARGO CLEARANCE PERMIT        Page z1 OF z3";
                iTextSharp.text.Paragraph am5 = new iTextSharp.text.Paragraph(page336, times);
                am5.Alignment = Element.ALIGN_LEFT;
                document.Add(am5);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page337 = "PERMIT NO : XXXXXXXXXXX     (12)     ======================                     ";
                iTextSharp.text.Paragraph am6 = new iTextSharp.text.Paragraph(page337, times);
                am6.Alignment = Element.ALIGN_LEFT;
                document.Add(am6);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page338 = "                                      (CONTINUATION PAGE)                       ";
                iTextSharp.text.Paragraph am7 = new iTextSharp.text.Paragraph(page338, times);
                am7.Alignment = Element.ALIGN_LEFT;
                document.Add(am7);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page339 = "CONSIGNMENT DETAILS (Cont’d)                                                          ";
                iTextSharp.text.Paragraph am8 = new iTextSharp.text.Paragraph(page339, times);
                am8.Alignment = Element.ALIGN_LEFT;
                document.Add(am8);
                chkline = chkline + 1;

                ////string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                //string page183 = "--------------------------------------------------------------------------------";
                //iTextSharp.text.Paragraph x6 = new iTextSharp.text.Paragraph(page183, times);
                //x6.Alignment = Element.ALIGN_LEFT;
                //document.Add(x6);
                document.Add(Line);
                chkline = chkline + 1;

            }
            if (chkline < Linecount)
            {
                if (chkline == 59)
                {
                    document.Add(Line);
                    chkline = chkline + 1;
                    msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                    string page335 = "UNIQUE REF : 201834618Z " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(9) + "";
                    iTextSharp.text.Paragraph am4 = new iTextSharp.text.Paragraph(page335, times);
                    am4.Alignment = Element.ALIGN_LEFT;
                    document.Add(am4);
                    chkline = chkline + 1;

                    string pager35 = "                                                                               ";
                    iTextSharp.text.Paragraph ym4 = new iTextSharp.text.Paragraph(pager35, times);
                    ym4.Alignment = Element.ALIGN_LEFT;
                    document.Add(ym4);
                    chkline = chkline + 1;
                }
                else
                {
                    document.Add(Line);
                    chkline = chkline + 1;
                }
            }
            else
            {
                chkline = 0;
                string page336 = "                                     CARGO CLEARANCE PERMIT        Page z1 OF z3";
                iTextSharp.text.Paragraph am5 = new iTextSharp.text.Paragraph(page336, times);
                am5.Alignment = Element.ALIGN_LEFT;
                document.Add(am5);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page337 = "PERMIT NO : XXXXXXXXXXX     (12)     ======================                     ";
                iTextSharp.text.Paragraph am6 = new iTextSharp.text.Paragraph(page337, times);
                am6.Alignment = Element.ALIGN_LEFT;
                document.Add(am6);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page338 = "                                      (CONTINUATION PAGE)                       ";
                iTextSharp.text.Paragraph am7 = new iTextSharp.text.Paragraph(page338, times);
                am7.Alignment = Element.ALIGN_LEFT;
                document.Add(am7);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page339 = "CONSIGNMENT DETAILS (Cont’d)                                                          ";
                iTextSharp.text.Paragraph am8 = new iTextSharp.text.Paragraph(page339, times);
                am8.Alignment = Element.ALIGN_LEFT;
                document.Add(am8);
                chkline = chkline + 1;

                ////string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                //string page183 = "--------------------------------------------------------------------------------";
                //iTextSharp.text.Paragraph x6 = new iTextSharp.text.Paragraph(page183, times);
                //x6.Alignment = Element.ALIGN_LEFT;
                //document.Add(x6);
                document.Add(Line);
                chkline = chkline + 1;

            }

            if (chkline < Linecount)
            {
                if (chkline == 59)
                {
                    document.Add(Line);
                    chkline = chkline + 1;

                    msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                    string page335 = "UNIQUE REF : 201834618Z " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(9) + "";
                    iTextSharp.text.Paragraph am4 = new iTextSharp.text.Paragraph(page335, times);
                    am4.Alignment = Element.ALIGN_LEFT;
                    document.Add(am4);
                    chkline = chkline + 1;

                    string pager35 = "                                                                               ";
                    iTextSharp.text.Paragraph ym4 = new iTextSharp.text.Paragraph(pager35, times);
                    ym4.Alignment = Element.ALIGN_LEFT;
                    document.Add(ym4);
                    chkline = chkline + 1;
                }
                else
                {
                    // string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                    string page350 = "CONTROLLING AGENCY/CUSTOMS CONDITIONS                                           ";
                    iTextSharp.text.Paragraph an9 = new iTextSharp.text.Paragraph(page350, times);
                    an9.Alignment = Element.ALIGN_LEFT;
                    document.Add(an9);
                    chkline = chkline + 1;
                }
            }
            else
            {
                chkline = 0;
                string page336 = "                                     CARGO CLEARANCE PERMIT        Page z1 OF z3";
                iTextSharp.text.Paragraph am5 = new iTextSharp.text.Paragraph(page336, times);
                am5.Alignment = Element.ALIGN_LEFT;
                document.Add(am5);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page337 = "PERMIT NO : XXXXXXXXXXX     (12)     ======================                     ";
                iTextSharp.text.Paragraph am6 = new iTextSharp.text.Paragraph(page337, times);
                am6.Alignment = Element.ALIGN_LEFT;
                document.Add(am6);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page338 = "                                      (CONTINUATION PAGE)                       ";
                iTextSharp.text.Paragraph am7 = new iTextSharp.text.Paragraph(page338, times);
                am7.Alignment = Element.ALIGN_LEFT;
                document.Add(am7);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page339 = "CONSIGNMENT DETAILS (Cont’d)                                                          ";
                iTextSharp.text.Paragraph am8 = new iTextSharp.text.Paragraph(page339, times);
                am8.Alignment = Element.ALIGN_LEFT;
                document.Add(am8);
                chkline = chkline + 1;

                ////string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                //string page183 = "--------------------------------------------------------------------------------";
                //iTextSharp.text.Paragraph x6 = new iTextSharp.text.Paragraph(page183, times);
                //x6.Alignment = Element.ALIGN_LEFT;
                //document.Add(x6);
                document.Add(Line);
                chkline = chkline + 1;

            }

            if (chkline < Linecount)
            {
                if (chkline == 59)
                {
                    document.Add(Line);
                    chkline = chkline + 1;

                    msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                    string page335 = "UNIQUE REF : 201834618Z " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(9) + "";
                    iTextSharp.text.Paragraph am4 = new iTextSharp.text.Paragraph(page335, times);
                    am4.Alignment = Element.ALIGN_LEFT;
                    document.Add(am4);
                    chkline = chkline + 1;

                    string pager35 = "                                                                               ";
                    iTextSharp.text.Paragraph ym4 = new iTextSharp.text.Paragraph(pager35, times);
                    ym4.Alignment = Element.ALIGN_LEFT;
                    document.Add(ym4);
                    chkline = chkline + 1;
                }
                else
                {
                    //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";

                    //   string page351 = "Y99 - SPECIMEN PERMIT ONLY";
                    Chunk t1 = new Chunk("Y99", timesBold);
                    Phrase tt1 = new Phrase(t1);
                    Chunk cc1 = new Chunk(" - SPECIMEN PERMIT ONLY", times);
                    Phrase tt2 = new Phrase(cc1);
                    iTextSharp.text.Paragraph ao0 = new iTextSharp.text.Paragraph();
                    ao0.Add(tt1);
                    ao0.Add(tt2);
                    ao0.Alignment = Element.ALIGN_LEFT;
                    document.Add(ao0);
                    chkline = chkline + 1;
                }
            }
            else
            {
                chkline = 0;
                string page336 = "                                     CARGO CLEARANCE PERMIT        Page z1 OF z3";
                iTextSharp.text.Paragraph am5 = new iTextSharp.text.Paragraph(page336, times);
                am5.Alignment = Element.ALIGN_LEFT;
                document.Add(am5);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page337 = "PERMIT NO : XXXXXXXXXXX     (12)     ======================                     ";
                iTextSharp.text.Paragraph am6 = new iTextSharp.text.Paragraph(page337, times);
                am6.Alignment = Element.ALIGN_LEFT;
                document.Add(am6);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page338 = "                                      (CONTINUATION PAGE)                       ";
                iTextSharp.text.Paragraph am7 = new iTextSharp.text.Paragraph(page338, times);
                am7.Alignment = Element.ALIGN_LEFT;
                document.Add(am7);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page339 = "CONSIGNMENT DETAILS (Cont’d)                                                          ";
                iTextSharp.text.Paragraph am8 = new iTextSharp.text.Paragraph(page339, times);
                am8.Alignment = Element.ALIGN_LEFT;
                document.Add(am8);
                chkline = chkline + 1;

                ////string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                //string page183 = "--------------------------------------------------------------------------------";
                //iTextSharp.text.Paragraph x6 = new iTextSharp.text.Paragraph(page183, times);
                //x6.Alignment = Element.ALIGN_LEFT;
                //document.Add(x6);
                document.Add(Line);
                chkline = chkline + 1;

            }

            if (chkline < Linecount)
            {
                if (chkline == 59)
                {
                    document.Add(Line);
                    chkline = chkline + 1;

                    msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                    string page335 = "UNIQUE REF : 201834618Z " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(9) + "";
                    iTextSharp.text.Paragraph am4 = new iTextSharp.text.Paragraph(page335, times);
                    am4.Alignment = Element.ALIGN_LEFT;
                    document.Add(am4);
                    chkline = chkline + 1;

                    string pager35 = "                                                                               ";
                    iTextSharp.text.Paragraph ym4 = new iTextSharp.text.Paragraph(pager35, times);
                    ym4.Alignment = Element.ALIGN_LEFT;
                    document.Add(ym4);
                    chkline = chkline + 1;
                }
                else
                {
                    //  string page352 = "Z01 - APPROVED BY SINGAPORE CUSTOMS.";
                    Chunk t1 = new Chunk("Z01", timesBold);
                    Phrase tt1 = new Phrase(t1);
                    Chunk cc1 = new Chunk(" - APPROVED BY SINGAPORE CUSTOMS.", times);
                    Phrase tt2 = new Phrase(cc1);
                    iTextSharp.text.Paragraph ao1 = new iTextSharp.text.Paragraph();
                    ao1.Add(tt1);
                    ao1.Add(tt2);
                    ao1.Alignment = Element.ALIGN_LEFT;
                    document.Add(ao1);
                    chkline = chkline + 1;
                }
            }
            else
            {
                chkline = 0;
                string page336 = "                                     CARGO CLEARANCE PERMIT        Page z1 OF z3";
                iTextSharp.text.Paragraph am5 = new iTextSharp.text.Paragraph(page336, times);
                am5.Alignment = Element.ALIGN_LEFT;
                document.Add(am5);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page337 = "PERMIT NO : XXXXXXXXXXX     (12)     ======================                     ";
                iTextSharp.text.Paragraph am6 = new iTextSharp.text.Paragraph(page337, times);
                am6.Alignment = Element.ALIGN_LEFT;
                document.Add(am6);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page338 = "                                      (CONTINUATION PAGE)                       ";
                iTextSharp.text.Paragraph am7 = new iTextSharp.text.Paragraph(page338, times);
                am7.Alignment = Element.ALIGN_LEFT;
                document.Add(am7);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page339 = "CONSIGNMENT DETAILS (Cont’d)                                                          ";
                iTextSharp.text.Paragraph am8 = new iTextSharp.text.Paragraph(page339, times);
                am8.Alignment = Element.ALIGN_LEFT;
                document.Add(am8);
                chkline = chkline + 1;

                ////string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                //string page183 = "--------------------------------------------------------------------------------";
                //iTextSharp.text.Paragraph x6 = new iTextSharp.text.Paragraph(page183, times);
                //x6.Alignment = Element.ALIGN_LEFT;
                //document.Add(x6);
                document.Add(Line);
                chkline = chkline + 1;

            }

            if (chkline < Linecount)
            {
                if (chkline == 59)
                {
                    document.Add(Line);
                    chkline = chkline + 1;

                    msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                    string page335 = "UNIQUE REF : 201834618Z " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(9) + "";
                    iTextSharp.text.Paragraph am4 = new iTextSharp.text.Paragraph(page335, times);
                    am4.Alignment = Element.ALIGN_LEFT;
                    document.Add(am4);
                    chkline = chkline + 1;

                    string pager35 = "                                                                               ";
                    iTextSharp.text.Paragraph ym4 = new iTextSharp.text.Paragraph(pager35, times);
                    ym4.Alignment = Element.ALIGN_LEFT;
                    document.Add(ym4);
                    chkline = chkline + 1;
                }
                else
                {
                    // string page353 = "GA - APPROVED BY SINGAPORE CUSTOMS SUBJECT TO THE IMPORTER, EXPORTER,";
                    Chunk t1 = new Chunk("GA", timesBold);
                    Phrase tt1 = new Phrase(t1);
                    Chunk cc1 = new Chunk(" - APPROVED BY SINGAPORE CUSTOMS SUBJECT TO THE IMPORTER, EXPORTER", times);
                    Phrase tt2 = new Phrase(cc1);
                    iTextSharp.text.Paragraph ao2 = new iTextSharp.text.Paragraph();
                    ao2.Add(tt1);
                    ao2.Add(tt2);
                    ao2.Alignment = Element.ALIGN_LEFT;
                    document.Add(ao2);
                    chkline = chkline + 1;
                }
            }
            else
            {
                chkline = 0;
                string page336 = "                                     CARGO CLEARANCE PERMIT        Page z1 OF z3";
                iTextSharp.text.Paragraph am5 = new iTextSharp.text.Paragraph(page336, times);
                am5.Alignment = Element.ALIGN_LEFT;
                document.Add(am5);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page337 = "PERMIT NO : XXXXXXXXXXX     (12)     ======================                     ";
                iTextSharp.text.Paragraph am6 = new iTextSharp.text.Paragraph(page337, times);
                am6.Alignment = Element.ALIGN_LEFT;
                document.Add(am6);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page338 = "                                      (CONTINUATION PAGE)                       ";
                iTextSharp.text.Paragraph am7 = new iTextSharp.text.Paragraph(page338, times);
                am7.Alignment = Element.ALIGN_LEFT;
                document.Add(am7);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page339 = "CONSIGNMENT DETAILS (Cont’d)                                                          ";
                iTextSharp.text.Paragraph am8 = new iTextSharp.text.Paragraph(page339, times);
                am8.Alignment = Element.ALIGN_LEFT;
                document.Add(am8);
                chkline = chkline + 1;

                ////string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                //string page183 = "--------------------------------------------------------------------------------";
                //iTextSharp.text.Paragraph x6 = new iTextSharp.text.Paragraph(page183, times);
                //x6.Alignment = Element.ALIGN_LEFT;
                //document.Add(x6);
                document.Add(Line);
                chkline = chkline + 1;

            }

            if (chkline < Linecount)
            {
                if (chkline == 59)
                {
                    document.Add(Line);
                    chkline = chkline + 1;

                    msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                    string page335 = "UNIQUE REF : 201834618Z " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(9) + "";
                    iTextSharp.text.Paragraph am4 = new iTextSharp.text.Paragraph(page335, times);
                    am4.Alignment = Element.ALIGN_LEFT;
                    document.Add(am4);
                    chkline = chkline + 1;

                    string pager35 = "                                                                               ";
                    iTextSharp.text.Paragraph ym4 = new iTextSharp.text.Paragraph(pager35, times);
                    ym4.Alignment = Element.ALIGN_LEFT;
                    document.Add(ym4);
                    chkline = chkline + 1;
                }
                else
                {
                    string page354 = "DECLARING AGENT OR/AND THE DECLARANT COMPLYING WITH THE FOLLOWING CONDITION(S)";
                    iTextSharp.text.Paragraph ao3 = new iTextSharp.text.Paragraph(page354, times);
                    ao3.Alignment = Element.ALIGN_LEFT;
                    document.Add(ao3);
                    chkline = chkline + 1;
                }
            }
            else
            {
                chkline = 0;
                string page336 = "                                     CARGO CLEARANCE PERMIT        Page z1 OF z3";
                iTextSharp.text.Paragraph am5 = new iTextSharp.text.Paragraph(page336, times);
                am5.Alignment = Element.ALIGN_LEFT;
                document.Add(am5);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page337 = "PERMIT NO : XXXXXXXXXXX     (12)     ======================                     ";
                iTextSharp.text.Paragraph am6 = new iTextSharp.text.Paragraph(page337, times);
                am6.Alignment = Element.ALIGN_LEFT;
                document.Add(am6);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page338 = "                                      (CONTINUATION PAGE)                       ";
                iTextSharp.text.Paragraph am7 = new iTextSharp.text.Paragraph(page338, times);
                am7.Alignment = Element.ALIGN_LEFT;
                document.Add(am7);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page339 = "CONSIGNMENT DETAILS (Cont’d)                                                          ";
                iTextSharp.text.Paragraph am8 = new iTextSharp.text.Paragraph(page339, times);
                am8.Alignment = Element.ALIGN_LEFT;
                document.Add(am8);
                chkline = chkline + 1;

                ////string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                //string page183 = "--------------------------------------------------------------------------------";
                //iTextSharp.text.Paragraph x6 = new iTextSharp.text.Paragraph(page183, times);
                //x6.Alignment = Element.ALIGN_LEFT;
                //document.Add(x6);
                document.Add(Line);
                chkline = chkline + 1;

            }

            if (chkline < Linecount)
            {
                string page355 = "FOR THE PERMIT TO BE VALID. FAILURE TO COMPLY WITH CONDITION(S) IS AN OFFENCE.";
                iTextSharp.text.Paragraph ao4 = new iTextSharp.text.Paragraph(page355, times);
                ao4.Alignment = Element.ALIGN_LEFT;
                document.Add(ao4);
                chkline = chkline + 1;
            }

            if (chkline < Linecount)
            {
                if (chkline == 59)
                {
                    document.Add(Line);
                    chkline = chkline + 1;

                    msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                    string page335 = "UNIQUE REF : 201834618Z " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(9) + "";
                    iTextSharp.text.Paragraph am4 = new iTextSharp.text.Paragraph(page335, times);
                    am4.Alignment = Element.ALIGN_LEFT;
                    document.Add(am4);
                    chkline = chkline + 1;

                    string pager35 = "                                                                               ";
                    iTextSharp.text.Paragraph ym4 = new iTextSharp.text.Paragraph(pager35, times);
                    ym4.Alignment = Element.ALIGN_LEFT;
                    document.Add(ym4);
                    chkline = chkline + 1;
                }
                else
                {
                    //string page356 = "GQ - IF THE DUTY/GST IS NOT PAID WITHIN THE VALIDITY PERIOD OF THE PERMIT,";
                    Chunk t1 = new Chunk("GQ", timesBold);
                    Phrase tt1 = new Phrase(t1);
                    Chunk cc1 = new Chunk(" - IF THE DUTY/GST IS NOT PAID WITHIN THE VALIDITY PERIOD OF THE PERMIT", times);
                    Phrase tt2 = new Phrase(cc1);
                    iTextSharp.text.Paragraph ao5 = new iTextSharp.text.Paragraph();
                    ao5.Alignment = Element.ALIGN_LEFT;
                    ao5.Add(tt1);
                    ao5.Add(tt2);
                    document.Add(ao5);
                    chkline = chkline + 1;
                }
            }
            else
            {
                chkline = 0;
                string page336 = "                                     CARGO CLEARANCE PERMIT        Page z1 OF z3";
                iTextSharp.text.Paragraph am5 = new iTextSharp.text.Paragraph(page336, times);
                am5.Alignment = Element.ALIGN_LEFT;
                document.Add(am5);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page337 = "PERMIT NO : XXXXXXXXXXX     (12)     ======================                     ";
                iTextSharp.text.Paragraph am6 = new iTextSharp.text.Paragraph(page337, times);
                am6.Alignment = Element.ALIGN_LEFT;
                document.Add(am6);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page338 = "                                      (CONTINUATION PAGE)                       ";
                iTextSharp.text.Paragraph am7 = new iTextSharp.text.Paragraph(page338, times);
                am7.Alignment = Element.ALIGN_LEFT;
                document.Add(am7);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page339 = "CONSIGNMENT DETAILS (Cont’d)                                                          ";
                iTextSharp.text.Paragraph am8 = new iTextSharp.text.Paragraph(page339, times);
                am8.Alignment = Element.ALIGN_LEFT;
                document.Add(am8);
                chkline = chkline + 1;

                ////string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                //string page183 = "--------------------------------------------------------------------------------";
                //iTextSharp.text.Paragraph x6 = new iTextSharp.text.Paragraph(page183, times);
                //x6.Alignment = Element.ALIGN_LEFT;
                //document.Add(x6);
                document.Add(Line);
                chkline = chkline + 1;

            }

            if (chkline < Linecount)
            {
                if (chkline == 59)
                {
                    document.Add(Line);
                    chkline = chkline + 1;

                    msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                    string page335 = "UNIQUE REF : 201834618Z " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(9) + "";
                    iTextSharp.text.Paragraph am4 = new iTextSharp.text.Paragraph(page335, times);
                    am4.Alignment = Element.ALIGN_LEFT;
                    document.Add(am4);
                    chkline = chkline + 1;

                    string pager35 = "                                                                               ";
                    iTextSharp.text.Paragraph ym4 = new iTextSharp.text.Paragraph(pager35, times);
                    ym4.Alignment = Element.ALIGN_LEFT;
                    document.Add(ym4);
                    chkline = chkline + 1;
                }
                else
                {
                    string page357 = "THIS PERMIT MUST BE CANCELLED BEFORE ITS EXPIRY DATE IF IT IS NOT USED FOR CARGO";
                    iTextSharp.text.Paragraph ao6 = new iTextSharp.text.Paragraph(page357, times);
                    ao6.Alignment = Element.ALIGN_LEFT;
                    document.Add(ao6);
                    chkline = chkline + 1;
                }
            }
            else
            {
                chkline = 0;
                string page336 = "                                     CARGO CLEARANCE PERMIT        Page z1 OF z3";
                iTextSharp.text.Paragraph am5 = new iTextSharp.text.Paragraph(page336, times);
                am5.Alignment = Element.ALIGN_LEFT;
                document.Add(am5);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page337 = "PERMIT NO : XXXXXXXXXXX     (12)     ======================                     ";
                iTextSharp.text.Paragraph am6 = new iTextSharp.text.Paragraph(page337, times);
                am6.Alignment = Element.ALIGN_LEFT;
                document.Add(am6);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page338 = "                                      (CONTINUATION PAGE)                       ";
                iTextSharp.text.Paragraph am7 = new iTextSharp.text.Paragraph(page338, times);
                am7.Alignment = Element.ALIGN_LEFT;
                document.Add(am7);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page339 = "CONSIGNMENT DETAILS (Cont’d)                                                          ";
                iTextSharp.text.Paragraph am8 = new iTextSharp.text.Paragraph(page339, times);
                am8.Alignment = Element.ALIGN_LEFT;
                document.Add(am8);
                chkline = chkline + 1;

                ////string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                //string page183 = "--------------------------------------------------------------------------------";
                //iTextSharp.text.Paragraph x6 = new iTextSharp.text.Paragraph(page183, times);
                //x6.Alignment = Element.ALIGN_LEFT;
                //document.Add(x6);
                document.Add(Line);
                chkline = chkline + 1;

            }

            if (chkline < Linecount)
            {
                if (chkline == 59)
                {
                    document.Add(Line);
                    chkline = chkline + 1;

                    msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                    string page335 = "UNIQUE REF : 201834618Z " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(9) + "";
                    iTextSharp.text.Paragraph am4 = new iTextSharp.text.Paragraph(page335, times);
                    am4.Alignment = Element.ALIGN_LEFT;
                    document.Add(am4);
                    chkline = chkline + 1;

                    string pager35 = "                                                                               ";
                    iTextSharp.text.Paragraph ym4 = new iTextSharp.text.Paragraph(pager35, times);
                    ym4.Alignment = Element.ALIGN_LEFT;
                    document.Add(ym4);
                    chkline = chkline + 1;
                }
                else
                {
                    string page358 = "CLEARANCE                                                             ";
                    iTextSharp.text.Paragraph ao7 = new iTextSharp.text.Paragraph(page358, times);
                    ao7.Alignment = Element.ALIGN_LEFT;
                    document.Add(ao7);
                    chkline = chkline + 1;
                }
            }
            else
            {
                chkline = 0;
                string page336 = "                                     CARGO CLEARANCE PERMIT        Page z1 OF z3";
                iTextSharp.text.Paragraph am5 = new iTextSharp.text.Paragraph(page336, times);
                am5.Alignment = Element.ALIGN_LEFT;
                document.Add(am5);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page337 = "PERMIT NO : XXXXXXXXXXX     (12)     ======================                     ";
                iTextSharp.text.Paragraph am6 = new iTextSharp.text.Paragraph(page337, times);
                am6.Alignment = Element.ALIGN_LEFT;
                document.Add(am6);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page338 = "                                      (CONTINUATION PAGE)                       ";
                iTextSharp.text.Paragraph am7 = new iTextSharp.text.Paragraph(page338, times);
                am7.Alignment = Element.ALIGN_LEFT;
                document.Add(am7);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page339 = "CONSIGNMENT DETAILS (Cont’d)                                                          ";
                iTextSharp.text.Paragraph am8 = new iTextSharp.text.Paragraph(page339, times);
                am8.Alignment = Element.ALIGN_LEFT;
                document.Add(am8);
                chkline = chkline + 1;

                ////string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                //string page183 = "--------------------------------------------------------------------------------";
                //iTextSharp.text.Paragraph x6 = new iTextSharp.text.Paragraph(page183, times);
                //x6.Alignment = Element.ALIGN_LEFT;
                //document.Add(x6);
                document.Add(Line);
                chkline = chkline + 1;

            }

            if (chkline < Linecount)
            {
                if (chkline == 59)
                {
                    document.Add(Line);
                    chkline = chkline + 1;

                    msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                    string page335 = "UNIQUE REF : 201834618Z " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(9) + "";
                    iTextSharp.text.Paragraph am4 = new iTextSharp.text.Paragraph(page335, times);
                    am4.Alignment = Element.ALIGN_LEFT;
                    document.Add(am4);
                    chkline = chkline + 1;

                    string pager35 = "                                                                               ";
                    iTextSharp.text.Paragraph ym4 = new iTextSharp.text.Paragraph(pager35, times);
                    ym4.Alignment = Element.ALIGN_LEFT;
                    document.Add(ym4);
                    chkline = chkline + 1;
                }
                else
                {
                    //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                    //   string page359 = "P1 - THE CONTAINER(S) MUST BE PRODUCED AT CUSTOMS CHECKPOINT(S) FOR CLEARANCE";
                    Chunk t1 = new Chunk("P1", timesBold);
                    Phrase tt1 = new Phrase(t1);
                    Chunk cc1 = new Chunk(" - THE CONTAINER(S) MUST BE PRODUCED AT CUSTOMS CHECKPOINT(S) FOR CLEARANCE", times);
                    Phrase tt2 = new Phrase(cc1);
                    iTextSharp.text.Paragraph ao8 = new iTextSharp.text.Paragraph();
                    ao8.Add(tt1);
                    ao8.Add(tt2);
                    ao8.Alignment = Element.ALIGN_LEFT;
                    document.Add(ao8);
                    chkline = chkline + 1;
                }
            }
            else
            {
                chkline = 0;
                string page336 = "                                     CARGO CLEARANCE PERMIT        Page z1 OF z3";
                iTextSharp.text.Paragraph am5 = new iTextSharp.text.Paragraph(page336, times);
                am5.Alignment = Element.ALIGN_LEFT;
                document.Add(am5);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page337 = "PERMIT NO : XXXXXXXXXXX     (12)     ======================                     ";
                iTextSharp.text.Paragraph am6 = new iTextSharp.text.Paragraph(page337, times);
                am6.Alignment = Element.ALIGN_LEFT;
                document.Add(am6);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page338 = "                                      (CONTINUATION PAGE)                       ";
                iTextSharp.text.Paragraph am7 = new iTextSharp.text.Paragraph(page338, times);
                am7.Alignment = Element.ALIGN_LEFT;
                document.Add(am7);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page339 = "CONSIGNMENT DETAILS (Cont’d)                                                          ";
                iTextSharp.text.Paragraph am8 = new iTextSharp.text.Paragraph(page339, times);
                am8.Alignment = Element.ALIGN_LEFT;
                document.Add(am8);
                chkline = chkline + 1;

                ////string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                //string page183 = "--------------------------------------------------------------------------------";
                //iTextSharp.text.Paragraph x6 = new iTextSharp.text.Paragraph(page183, times);
                //x6.Alignment = Element.ALIGN_LEFT;
                //document.Add(x6);
                document.Add(Line);
                chkline = chkline + 1;

            }

            if (chkline < Linecount)
            {
                if (chkline == 59)
                {
                    document.Add(Line);
                    chkline = chkline + 1;

                    msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                    string page335 = "UNIQUE REF : 201834618Z " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(9) + "";
                    iTextSharp.text.Paragraph am4 = new iTextSharp.text.Paragraph(page335, times);
                    am4.Alignment = Element.ALIGN_LEFT;
                    document.Add(am4);
                    chkline = chkline + 1;

                    string pager35 = "                                                                               ";
                    iTextSharp.text.Paragraph ym4 = new iTextSharp.text.Paragraph(pager35, times);
                    ym4.Alignment = Element.ALIGN_LEFT;
                    document.Add(ym4);
                    chkline = chkline + 1;
                }
                else
                {
                    string page360 = "UNLESS DIRECTED TO 'GREEN' LANE. FOR CONTAINER(S) TO BE SCANNED, PLEASE PRODUCE";
                    iTextSharp.text.Paragraph ao9 = new iTextSharp.text.Paragraph(page360, times);
                    ao9.Alignment = Element.ALIGN_LEFT;
                    document.Add(ao9);
                    chkline = chkline + 1;
                }
            }
            else
            {
                chkline = 0;
                string page336 = "                                     CARGO CLEARANCE PERMIT        Page z1 OF z3";
                iTextSharp.text.Paragraph am5 = new iTextSharp.text.Paragraph(page336, times);
                am5.Alignment = Element.ALIGN_LEFT;
                document.Add(am5);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page337 = "PERMIT NO : XXXXXXXXXXX     (12)     ======================                     ";
                iTextSharp.text.Paragraph am6 = new iTextSharp.text.Paragraph(page337, times);
                am6.Alignment = Element.ALIGN_LEFT;
                document.Add(am6);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page338 = "                                      (CONTINUATION PAGE)                       ";
                iTextSharp.text.Paragraph am7 = new iTextSharp.text.Paragraph(page338, times);
                am7.Alignment = Element.ALIGN_LEFT;
                document.Add(am7);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page339 = "CONSIGNMENT DETAILS (Cont’d)                                                          ";
                iTextSharp.text.Paragraph am8 = new iTextSharp.text.Paragraph(page339, times);
                am8.Alignment = Element.ALIGN_LEFT;
                document.Add(am8);
                chkline = chkline + 1;

                ////string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                //string page183 = "--------------------------------------------------------------------------------";
                //iTextSharp.text.Paragraph x6 = new iTextSharp.text.Paragraph(page183, times);
                //x6.Alignment = Element.ALIGN_LEFT;
                //document.Add(x6);
                document.Add(Line);
                chkline = chkline + 1;

            }


            if (chkline < Linecount)
            {
                if (chkline == 59)
                {
                    document.Add(Line);
                    chkline = chkline + 1;

                    msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                    string page335 = "UNIQUE REF : 201834618Z " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(9) + "";
                    iTextSharp.text.Paragraph am4 = new iTextSharp.text.Paragraph(page335, times);
                    am4.Alignment = Element.ALIGN_LEFT;
                    document.Add(am4);
                    chkline = chkline + 1;

                    string pager35 = "                                                                               ";
                    iTextSharp.text.Paragraph ym4 = new iTextSharp.text.Paragraph(pager35, times);
                    ym4.Alignment = Element.ALIGN_LEFT;
                    document.Add(ym4);
                    chkline = chkline + 1;
                }
                else
                {
                    string page361 = "FOR SCANNING BY ICA AT SCANNING STATION AS DIRECTED.";
                    iTextSharp.text.Paragraph ap0 = new iTextSharp.text.Paragraph(page361, times);
                    ap0.Alignment = Element.ALIGN_LEFT;
                    document.Add(ap0);
                    chkline = chkline + 1;

                    string page3643 = "    ";
                    iTextSharp.text.Paragraph ap42 = new iTextSharp.text.Paragraph(page3643, times);
                    ap42.Alignment = Element.ALIGN_LEFT;
                    document.Add(ap42);
                    chkline = chkline + 1;

                    document.Add(Line);
                    chkline = chkline + 1;

                    msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                    string page3359 = "UNIQUE REF : 201834618Z " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(9) + "";
                    iTextSharp.text.Paragraph am40 = new iTextSharp.text.Paragraph(page3359, times);
                    am40.Alignment = Element.ALIGN_LEFT;
                    document.Add(am40);

                    string page36431 = "    ";
                    iTextSharp.text.Paragraph ap421 = new iTextSharp.text.Paragraph(page36431, times);
                    ap421.Alignment = Element.ALIGN_LEFT;
                    document.Add(ap421);
                    chkline = chkline + 1;

                }
            }
            else
            {
                chkline = 0;
                string page336 = "                                     CARGO CLEARANCE PERMIT        Page z1 OF z3";
                iTextSharp.text.Paragraph am5 = new iTextSharp.text.Paragraph(page336, times);
                am5.Alignment = Element.ALIGN_LEFT;
                document.Add(am5);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page337 = "PERMIT NO : XXXXXXXXXXX     (12)     ======================                     ";
                iTextSharp.text.Paragraph am6 = new iTextSharp.text.Paragraph(page337, times);
                am6.Alignment = Element.ALIGN_LEFT;
                document.Add(am6);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page338 = "                                      (CONTINUATION PAGE)                       ";
                iTextSharp.text.Paragraph am7 = new iTextSharp.text.Paragraph(page338, times);
                am7.Alignment = Element.ALIGN_LEFT;
                document.Add(am7);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page339 = "CONSIGNMENT DETAILS (Cont’d)                                                          ";
                iTextSharp.text.Paragraph am8 = new iTextSharp.text.Paragraph(page339, times);
                am8.Alignment = Element.ALIGN_LEFT;
                document.Add(am8);
                chkline = chkline + 1;

                ////string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                //string page183 = "--------------------------------------------------------------------------------";
                //iTextSharp.text.Paragraph x6 = new iTextSharp.text.Paragraph(page183, times);
                //x6.Alignment = Element.ALIGN_LEFT;
                //document.Add(x6);
                document.Add(Line);
                chkline = chkline + 1;

            }
            if (chkline < Linecount)
            {
                if (chkline == 59)
                {
                    document.Add(Line);
                    chkline = chkline + 1;

                    msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                    string page335 = "UNIQUE REF : 201834618Z " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(9) + "";
                    iTextSharp.text.Paragraph am4 = new iTextSharp.text.Paragraph(page335, times);
                    am4.Alignment = Element.ALIGN_LEFT;
                    document.Add(am4);
                    chkline = chkline + 1;

                    string pager35 = "                                                                               ";
                    iTextSharp.text.Paragraph ym4 = new iTextSharp.text.Paragraph(pager35, times);
                    ym4.Alignment = Element.ALIGN_LEFT;
                    document.Add(ym4);
                    chkline = chkline + 1;
                }
                else
                {
                    chkline = 0;
                    string page336 = "                                     CARGO CLEARANCE PERMIT        ";
                    iTextSharp.text.Paragraph am5 = new iTextSharp.text.Paragraph(page336, times);
                    am5.Alignment = Element.ALIGN_LEFT;
                    document.Add(am5);
                    chkline = chkline + 1;

                    //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                    string page337 = "PERMIT NO :  IG9A429783R              ======================                     ";
                    iTextSharp.text.Paragraph am6 = new iTextSharp.text.Paragraph(page337, times);
                    am6.Alignment = Element.ALIGN_LEFT;
                    document.Add(am6);
                    chkline = chkline + 1;

                    //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                    string page338 = "                                      (CONTINUATION PAGE)                       ";
                    iTextSharp.text.Paragraph am7 = new iTextSharp.text.Paragraph(page338, times);
                    am7.Alignment = Element.ALIGN_LEFT;
                    document.Add(am7);
                    chkline = chkline + 1;

                    //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                    string page339 = "CONSIGNMENT DETAILS (Cont’d)                                                          ";
                    iTextSharp.text.Paragraph am8 = new iTextSharp.text.Paragraph(page339, times);
                    am8.Alignment = Element.ALIGN_LEFT;
                    document.Add(am8);
                    chkline = chkline + 1;


                    document.Add(Line);

                    Chunk t1 = new Chunk("G1", timesBold);
                    Phrase tt1 = new Phrase(t1);
                    Chunk cc1 = new Chunk(" - PAYMENT OF CUSTOMS DUTY/GST MUST BE MADE TO SINGAPORE CUSTOMS AT UNITED", times);
                    Phrase tt2 = new Phrase(cc1);
                    //    string page362 = "G1 - PAYMENT OF CUSTOMS DUTY/GST MUST BE MADE TO SINGAPORE CUSTOMS AT UNITED";
                    iTextSharp.text.Paragraph ap1 = new iTextSharp.text.Paragraph();
                    ap1.Add(tt1);
                    ap1.Add(tt2);
                    ap1.Alignment = Element.ALIGN_LEFT;
                    document.Add(ap1);
                    chkline = chkline + 1;
                }
            }

            else
            {
                chkline = 0;
                string page336 = "                                     CARGO CLEARANCE PERMIT        Page z1 OF z3";
                iTextSharp.text.Paragraph am5 = new iTextSharp.text.Paragraph(page336, times);
                am5.Alignment = Element.ALIGN_LEFT;
                document.Add(am5);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page337 = "PERMIT NO : XXXXXXXXXXX     (12)     ======================                     ";
                iTextSharp.text.Paragraph am6 = new iTextSharp.text.Paragraph(page337, times);
                am6.Alignment = Element.ALIGN_LEFT;
                document.Add(am6);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page338 = "                                      (CONTINUATION PAGE)                       ";
                iTextSharp.text.Paragraph am7 = new iTextSharp.text.Paragraph(page338, times);
                am7.Alignment = Element.ALIGN_LEFT;
                document.Add(am7);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page339 = "CONSIGNMENT DETAILS (Cont’d)                                                          ";
                iTextSharp.text.Paragraph am8 = new iTextSharp.text.Paragraph(page339, times);
                am8.Alignment = Element.ALIGN_LEFT;
                document.Add(am8);
                chkline = chkline + 1;

                ////string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                //string page183 = "--------------------------------------------------------------------------------";
                //iTextSharp.text.Paragraph x6 = new iTextSharp.text.Paragraph(page183, times);
                //x6.Alignment = Element.ALIGN_LEFT;
                //document.Add(x6);
                document.Add(Line);
                chkline = chkline + 1;

            }

            if (chkline < Linecount)
            {
                if (chkline == 59)
                {
                    document.Add(Line);
                    chkline = chkline + 1;

                    msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                    string page335 = "UNIQUE REF : 201834618Z " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(9) + "";
                    iTextSharp.text.Paragraph am4 = new iTextSharp.text.Paragraph(page335, times);
                    am4.Alignment = Element.ALIGN_LEFT;
                    document.Add(am4);
                    chkline = chkline + 1;

                    string pager35 = "                                                                               ";
                    iTextSharp.text.Paragraph ym4 = new iTextSharp.text.Paragraph(pager35, times);
                    ym4.Alignment = Element.ALIGN_LEFT;
                    document.Add(ym4);
                    chkline = chkline + 1;
                }
                else
                {
                    string page363 = "OVERSEAS BANK (UOB) PRIOR TO THE REMOVAL OF GOODS FROM CUSTOMS CONTROL.";
                    iTextSharp.text.Paragraph ap2 = new iTextSharp.text.Paragraph(page363, times);
                    ap2.Alignment = Element.ALIGN_LEFT;
                    document.Add(ap2);
                    chkline = chkline + 1;


                }
            }
            else
            {
                chkline = 0;
                string page336 = "                                     CARGO CLEARANCE PERMIT        Page z1 OF z3";
                iTextSharp.text.Paragraph am5 = new iTextSharp.text.Paragraph(page336, times);
                am5.Alignment = Element.ALIGN_LEFT;
                document.Add(am5);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page337 = "PERMIT NO : XXXXXXXXXXX     (12)     ======================                     ";
                iTextSharp.text.Paragraph am6 = new iTextSharp.text.Paragraph(page337, times);
                am6.Alignment = Element.ALIGN_LEFT;
                document.Add(am6);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page338 = "                                      (CONTINUATION PAGE)                       ";
                iTextSharp.text.Paragraph am7 = new iTextSharp.text.Paragraph(page338, times);
                am7.Alignment = Element.ALIGN_LEFT;
                document.Add(am7);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page339 = "CONSIGNMENT DETAILS (Cont’d)                                                          ";
                iTextSharp.text.Paragraph am8 = new iTextSharp.text.Paragraph(page339, times);
                am8.Alignment = Element.ALIGN_LEFT;
                document.Add(am8);
                chkline = chkline + 1;

                ////string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                //string page183 = "--------------------------------------------------------------------------------";
                //iTextSharp.text.Paragraph x6 = new iTextSharp.text.Paragraph(page183, times);
                //x6.Alignment = Element.ALIGN_LEFT;
                //document.Add(x6);
                document.Add(Line);
                chkline = chkline + 1;

            }

            if (chkline < Linecount)
            {
                if (chkline == 59)
                {
                    document.Add(Line);
                    chkline = chkline + 1;

                    msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                    string page335 = "UNIQUE REF : 201834618Z " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(9) + "";
                    iTextSharp.text.Paragraph am4 = new iTextSharp.text.Paragraph(page335, times);
                    am4.Alignment = Element.ALIGN_LEFT;
                    document.Add(am4);
                    chkline = chkline + 1;

                    string pager35 = "                                                                               ";
                    iTextSharp.text.Paragraph ym4 = new iTextSharp.text.Paragraph(pager35, times);
                    ym4.Alignment = Element.ALIGN_LEFT;
                    document.Add(ym4);
                    chkline = chkline + 1;
                }
                else
                {
                    Chunk t1 = new Chunk("EEE", timesBold);
                    Phrase tt1 = new Phrase(t1);
                    Chunk cc1 = new Chunk(" - END OF CARGO CLEARANCE PERMIT.", times);
                    Phrase tt2 = new Phrase(cc1);
                    //   string page364 = "EEE - END OF CARGO CLEARANCE PERMIT.";
                    iTextSharp.text.Paragraph ap3 = new iTextSharp.text.Paragraph();
                    ap3.Add(tt1);
                    ap3.Add(tt2);
                    ap3.Alignment = Element.ALIGN_LEFT;
                    document.Add(ap3);
                }
            }
            else
            {
                chkline = 0;
                string page336 = "                                     CARGO CLEARANCE PERMIT        Page z1 OF z3";
                iTextSharp.text.Paragraph am5 = new iTextSharp.text.Paragraph(page336, times);
                am5.Alignment = Element.ALIGN_LEFT;
                document.Add(am5);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page337 = "PERMIT NO : XXXXXXXXXXX     (12)     ======================                     ";
                iTextSharp.text.Paragraph am6 = new iTextSharp.text.Paragraph(page337, times);
                am6.Alignment = Element.ALIGN_LEFT;
                document.Add(am6);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page338 = "                                      (CONTINUATION PAGE)                       ";
                iTextSharp.text.Paragraph am7 = new iTextSharp.text.Paragraph(page338, times);
                am7.Alignment = Element.ALIGN_LEFT;
                document.Add(am7);
                chkline = chkline + 1;

                //string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                string page339 = "CONSIGNMENT DETAILS (Cont’d)                                                          ";
                iTextSharp.text.Paragraph am8 = new iTextSharp.text.Paragraph(page339, times);
                am8.Alignment = Element.ALIGN_LEFT;
                document.Add(am8);
                chkline = chkline + 1;

                ////string testerw = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";
                //string page183 = "--------------------------------------------------------------------------------";
                //iTextSharp.text.Paragraph x6 = new iTextSharp.text.Paragraph(page183, times);
                //x6.Alignment = Element.ALIGN_LEFT;
                //document.Add(x6);
                document.Add(Line);
                chkline = chkline + 1;

            }
            //string page365 = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX                                         ";
            //iTextSharp.text.Paragraph ap4 = new iTextSharp.text.Paragraph(page365, times);
            //ap4.Alignment = Element.ALIGN_LEFT;
            //document.Add(ap4);

            //string page366 = "Print Customs conditions                                                        ";
            //iTextSharp.text.Paragraph ap5 = new iTextSharp.text.Paragraph(page366, times);
            //ap5.Alignment = Element.ALIGN_LEFT;
            //document.Add(ap5);
            for (int li = 3; li < 51; li++)
            {
                string page3625 = "                                       ";
                iTextSharp.text.Paragraph ap24 = new iTextSharp.text.Paragraph(page3625, times);
                ap24.Alignment = Element.ALIGN_LEFT;
                document.Add(ap24);
            }
            document.Add(Line);
            chkline = chkline + 1;

            msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
            string page33591 = "UNIQUE REF : 201834618Z " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(9) + "";
            iTextSharp.text.Paragraph am401 = new iTextSharp.text.Paragraph(page33591, times);
            am401.Alignment = Element.ALIGN_LEFT;
            document.Add(am401);
            //MemoryStream pdfStream = new MemoryStream();
            //PdfReader reader = new PdfReader(pdfStream.ToArray());
            //int totalPages = reader.NumberOfPages;
            //PdfCopy copyPdf = new PdfCopy(document, new FileStream(filename, FileMode.Create));
            //PdfImportedPage copiedPage = null;
            //iTextSharp.text.pdf.PdfCopy.PageStamp stamper = null;

            //for (int i = 0; i < totalPages; i++)
            //{

            //    // get the page and create a stamper for that page
            //    copiedPage = copyPdf.GetImportedPage(reader, (i + 1));
            //    stamper = copyPdf.CreatePageStamp(copiedPage);

            //    // add a page number to the page
            //    ColumnText.ShowTextAligned(stamper.GetUnderContent(), Element.ALIGN_CENTER, new Phrase((i + 1) + "/" + totalPages, times), 820f, 15, 0);
            //    stamper.AlterContents();

            //    // add the altered page to the new document
            //    copyPdf.AddPage(copiedPage);
            //}

            //document.Add(bytes);
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
                            ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_RIGHT, new Phrase("Page " + i.ToString() + " OF " + pages, times), 513f, 707f, 0);
                        }
                        else
                        {
                            ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_RIGHT, new Phrase("Page " + i.ToString() + " OF " + pages, times), 508f, 805f, 0);
                        }
                    }
                }
                bytes = stream.ToArray();

            }
            File.WriteAllBytes(filename, bytes);
            ShowPdf(filename);
        }
        public void ShowPdf(string filename)
        {
            //Clears all content output from Buffer Stream
            Response.ClearContent();
            //Clears all headers from Buffer Stream
            Response.ClearHeaders();
            //Adds an HTTP header to the output stream
            Response.AddHeader("Content-Disposition", "inline;filename=" + filename);
            //Gets or Sets the HTTP MIME type of the output stream
            Response.ContentType = "application/pdf";
            //Writes the content of the specified file directory to an HTTP response output stream as a file block
            Response.WriteFile(filename);
            //sends all currently buffered output to the client
            Response.Flush();
            //Clears all content output from Buffer Stream
            Response.Clear();
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
                            SqlCommand cmd6 = new SqlCommand("update CustomiseReport set FiledValue='True' where FiledName='" + col.HeaderText + "'  and ReportName='CO' and UserName='" + Touch_user + "' ", con);
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
                            SqlCommand cmd6 = new SqlCommand("update CustomiseReport set FiledValue='False' where FiledName='" + col.HeaderText + "' and ReportName='CO' and UserName='" + Touch_user + "' ", con);
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
                string str = "SELECT  top 10 t1.Id, t1.JobId, t1.MSGId,CONVERT(varchar, t1.TouchTime, 105) AS DecDate, t1.ApplicationType AS DeclarationType, t1.TouchUser AS Createby, t2.TradeNetMailboxID AS DecId, CONVERT(varchar, t1.DepartureDate, 105) AS ETD, t1.PermitId AS LocalNo, t1.PermitNumber AS PermitNo, t1.PreviousPermitNo,  t3.Code AS Exporter, STUFF((SELECT ', ' + US.InHAWBOBL FROM OutItemDtl US  WHERE US.PermitId = t1.PermitId  FOR XML PATH('')), 1, 1, '') InHAWBOBL, t1.DischargePort as POD, t1.MessageType, t1.OutwardTransportMode, t1.InternalRemarks,  (select Count(ItemNo) from COItemDtl   where   COItemDtl.PermitId=t1.PermitId) as SumOfItem, t1.Status  FROM  COHeaderTbl AS t1 INNER JOIN   DeclarantCompany AS t2   ON t1.DeclarantCompanyCode = t2.Code   INNER JOIN COExporter AS t3   ON t1.ExporterCompanyCode = t3.Code  INNER JOIN ManageUser AS t6 ON t6.UserId=t1.TouchUser where t6.AccountId='" + Session["AccountId"].ToString() + "'  and t2.TradeNetMailboxID='"+ tradmail + "'     GROUP BY t1.Id, t1.JobId, t1.MSGId, t1.TouchTime, t1.TouchUser, t1.ApplicationType, t1.DepartureDate, t1.PermitId,t1.PermitNumber,t1.PreviousPermitNo, t1.OutwardTransportMode, t1.DischargePort, t1.MessageType, t1.OutwardTransportMode, t1.PreviousPermitNo, t1.InternalRemarks, t1.Status, t2.TradeNetMailboxID, t3.Code,t6.AccountId order by t1.Id desc";

                // = "select t1.Id,t1.JobId,MSGId, convert(varchar, t1.TouchTime, 105) as DecDate,Substring(DeclarationType, 1,Charindex(':', DeclarationType)-1) as DeclarationType,t1.TouchUser as Createby,t2.TradeNetMailboxID as DecId, convert(varchar, ArrivalDate, 105) as ETA,t1.PermitId as PermitNo,t3.Name as Importer,t4.InHAWBOBL,CASE  WHEN  t1.InwardTransportMode = '4 : Air' THEN t1.MasterAirwayBill  WHEN t1.InwardTransportMode = '1 : Sea'  THEN t1.OceanBillofLadingNo  ELSE ''  END AS MAWBOBL,t1.LoadingPortCode,t1.MessageType,t1.InwardTransportMode,t1.PreviousPermit,t1.InternalRemarks,Substring(t5.TermType, 1,Charindex(':', t5.TermType)-1) as TermType ,t5.GSTSUMAmount,sum(t4.ItemNo) as SumOFItem,t1.Status from InHeaderTbl t1 , DeclarantCompany t2 , Importer t3,ItemDtl t4,InvoiceDtl t5  where t1.DeclarantCompanyCode=t2.Code  and t1.ImporterCompanyCode=t3.Code  and t1.PermitId=t4.PermitId and t1.PermitId=t5.PermitId  GROUP BY t1.Id,t4.ItemNo,t1.JobId,t1.MSGId,t1.TouchTime,t1.TouchUser,t1.DeclarationType,t2.TradeNetMailboxID,t1.ArrivalDate,t1.PermitId,t3.Name,t4.InHAWBOBL,t1.InwardTransportMode ,t1.MasterAirwayBill,t1.OceanBillofLadingNo,t1.LoadingPortCode ,t1.MessageType,t1.InwardTransportMode,t1.PreviousPermit,t1.InternalRemarks,t5.TermType,t5.GSTSUMAmount,t1.Status";
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
                using (SqlCommand cmd = new SqlCommand("SELECT FiledName,FiledValue FROM CustomiseReport Where ReportName='" + "CO" + "' and UserName='" + Touch_user + "' "))
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
                                                else if (GridInPayment.HeaderRow.Cells[row_val].Text == "CertificateNo")
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
                                            try
                                            {
                                                if (GridInPayment.HeaderRow.Cells[row_val].Text == sdr["FiledName"].ToString())
                                                {
                                                    str1.Add(row_val.ToString());
                                                }
                                                GridInPayment.Columns[row_val].Visible = false;
                                            }
                                            catch (Exception ex)
                                            {
                                                ex.ToString();
                                            }
                                        }
                                    }
                                    GridInPayment.Columns[0].Visible = true;
                                    GridInPayment.Columns[1].Visible = true;
                                    GridInPayment.Columns[2].Visible = true;                                    
                                }
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
            changestatuscolor();
            //colorchange();
        }

        protected void load()
        {
            BindInpaymentGrid();
           // colorchange();
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

                con.Close();
                return null;
                //  ex.ToString();
            }
        }
        //test
        private void BindInpaymentGrid123() { }
            
        //Inpayment Grid
        private void BindInpaymentGrid()
        {
            string Touch_user = Session["UserId"].ToString();
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

                                string str = "SELECT   top 10 t1.Id, t1.JobId, t1.MSGId,CONVERT(varchar, t1.TouchTime, 105) AS DecDate, t1.ApplicationType AS DeclarationType, t1.TouchUser AS Createby, t2.TradeNetMailboxID AS DecId, CONVERT(varchar, t1.DepartureDate, 105) AS ETD, t1.PermitId AS LocalNo, t1.PermitNumber AS PermitNo, t1.PreviousPermitNo,  t3.Code AS Exporter, STUFF((SELECT ', ' + US.InHAWBOBL FROM OutItemDtl US  WHERE US.PermitId = t1.PermitId  FOR XML PATH('')), 1, 1, '') InHAWBOBL, t1.DischargePort as POD, t1.MessageType, t1.OutwardTransportMode, t1.InternalRemarks,  (select Count(ItemNo) from COItemDtl   where   COItemDtl.PermitId=t1.PermitId) as SumOfItem, t1.Status  FROM  COHeaderTbl AS t1 INNER JOIN   DeclarantCompany AS t2   ON t1.DeclarantCompanyCode = t2.Code   INNER JOIN COExporter AS t3   ON t1.ExporterCompanyCode = t3.Code  INNER JOIN ManageUser AS t6 ON t6.UserId=t1.TouchUser where t6.AccountId='" + Session["AccountId"].ToString() + "'  and t2.TradeNetMailboxID='"+ tradmail + "'    GROUP BY t1.Id, t1.JobId, t1.MSGId, t1.TouchTime, t1.TouchUser, t1.ApplicationType, t1.DepartureDate, t1.PermitId,t1.PermitNumber,t1.PreviousPermitNo, t1.OutwardTransportMode, t1.DischargePort, t1.MessageType, t1.OutwardTransportMode, t1.PreviousPermitNo, t1.InternalRemarks, t1.Status, t2.TradeNetMailboxID, t3.Code,t6.AccountId order by t1.Id desc";
                                //string str = "SELECT  t1.Id, t1.JobId, t1.MSGId,CONVERT(varchar, t1.TouchTime, 105) AS DecDate, SUBSTRING(t1.DeclarationType, 1,  CHARINDEX(':', t1.DeclarationType) - 1) AS DeclarationType, t1.TouchUser AS Createby, t2.TradeNetMailboxID AS DecId, CONVERT(varchar, t1.DepartureDate, 105) AS ETD, t1.PermitId AS PermitNo, t1.PreviousPermit,  t3.OutUserName AS Exporter, STUFF((SELECT distinct(', ' +  US.InHAWBOBL) FROM OutItemDtl US  WHERE US.PermitId = t1.PermitId  FOR XML PATH('')), 1, 1, '') InHAWBOBL,CASE   WHEN  t1.OutwardTransportMode = '4 : Air' THEN t1.MasterAirwayBill     WHEN t1.OutwardTransportMode = '1 : Sea'  THEN t1.OceanBillofLadingNo    ELSE ''  END AS MAWBOBL, t1.DischargePort as POD, t1.MessageType, t1.OutwardTransportMode, t1.InternalRemarks,  SUM(t5.GSTSUMAmount) AS GSTSUMAmount,  (select Count(ItemNo) from OutItemDtl   where   OutItemDtl.PermitId=t1.PermitId) as SumOfItem, t1.Status    FROM  OutHeaderTbl AS t1 INNER JOIN   DeclarantCompany AS t2   ON t1.DeclarantCompanyCode = t2.Code   INNER JOIN OutExporter AS t3   ON t1.ExporterCompanyCode = t3.OutUserCode   INNER JOIN OutInvoiceDtl AS t5   ON t1.PermitId = t5.PermitId  GROUP BY t1.Id, t1.JobId, t1.MSGId, t1.TouchTime, t1.TouchUser, t1.DeclarationType, t1.DepartureDate, t1.PermitId,t1.PreviousPermit, t1.OutwardTransportMode, t1.MasterAirwayBill, t1.OceanBillofLadingNo, t1.DischargePort, t1.MessageType, t1.InwardTransportMode, t1.PreviousPermit, t1.InternalRemarks, t1.Status, t2.TradeNetMailboxID, t3.OutUserName";
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
            changestatuscolor();
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            BindInPayment();    
        }

        protected void GridInPayment_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
        }

        protected void GridInPayment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridInPayment.PageIndex = e.NewPageIndex;
            BindInPayment();
           // colorchange();
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
            SqlCommand cmd = new SqlCommand("update  COHeaderTbl set  Status='DEL' where ID=" + employeeId, con);
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
            Response.Redirect("CO.aspx?ID=" + ID);
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
            //  Page.ClientScript.RegisterStartupScript(
            //this.GetType(), "OpenWindow", "window.open('InpaymentCCP.aspx','_newtab');", true);
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
                    //var PermitID = gvrow.FindControl("txtPermitNo") as TextBox;                    
                    //PrintCCPCreate();
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

        protected void View_Click(object sender, EventArgs e)
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer as GridViewRow;

            Label ID1 = (Label)grdrow.FindControl("Id");


            string ID = ID1.Text;
            //string ID = "4";
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(900/2);var Mtop = (screen.height/2)-(500/2);window.open( 'CoView.aspx?ID=" + ID + "', null, 'height=900,width=2000,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

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
                        Response.Redirect("CO.aspx?ID=" + ID);

                        // Label ID1 = (Label)grdrow.FindControl("Id");
                        // string ID = ID1.Text;
                        //string ID = lblCode1.Text;
                        //string ID = "4";
                        //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(900/2);var Mtop = (screen.height/2)-(500/2);window.open( 'Coview.aspx?ID=" + ID + "', null, 'height=500,width=2000,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
                    }
                    //Response.Redirect("InpaymentView.aspx?ID=" + ID);
                }
            }
        }*/


        protected void GridInPayment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
        }


        protected void GridInPayment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }

        protected void Drppermitedit_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (Drppermitedit.SelectedItem.ToString() == "--Select--")
            //{

            //}
            //else if (Drppermitedit.SelectedItem.ToString() == "AMEND")
            //{
            //    foreach (GridViewRow gvrow in GridInPayment.Rows)
            //    {
            //        var checkbox = gvrow.FindControl("CheckBox1") as CheckBox;
            //        if (checkbox.Checked)
            //        {
            //            Label ID1 = (Label)gvrow.FindControl("Id");
            //            string ID = ID1.Text;
            //            MyClass lodobj = new MyClass();
            //            string lodport = "select * from [OutHeaderTbl] where PermitNumber='XO9C015957S'";
            //            lodobj.dr = lodobj.ret_dr(lodport);
            //            if (lodobj.dr.HasRows)
            //            {
            //                while (lodobj.dr.Read())
            //                {
            //                    PermID = lodobj.dr["Id"].ToString();
            //                }
            //            }

            //            Response.Redirect("Out.aspx?Id=" + PermID + "&Update=" + Drppermitedit.SelectedItem.ToString() + "");
            //        }
            //    }

            //}
            //else if (Drppermitedit.SelectedItem.ToString() == "CANCEL")
            //{
            //    foreach (GridViewRow gvrow in GridInPayment.Rows)
            //    {
            //        var checkbox = gvrow.FindControl("CheckBox1") as CheckBox;
            //        if (checkbox.Checked)
            //        {
            //            Label ID1 = (Label)gvrow.FindControl("Id");
            //            string ID = ID1.Text;
            //            MyClass lodobj = new MyClass();
            //            string lodport = "select * from [OutHeaderTbl] where PermitNumber='XO9C015957S'";
            //            lodobj.dr = lodobj.ret_dr(lodport);
            //            if (lodobj.dr.HasRows)
            //            {
            //                while (lodobj.dr.Read())
            //                {
            //                    PermID = lodobj.dr["Id"].ToString();
            //                }
            //            }

            //            Response.Redirect("Out.aspx?Id=" + PermID + "&Update=" + Drppermitedit.SelectedItem.ToString() + "");
            //        }
            //    }
            //}
        }
        private void LoadCOODEC(string permit)
        {
            string tradeID = "";
            dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from COHeaderTbl  where PermitId='" + permit + "'"))
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
                MSGNUMBER = dt.Rows[0]["MSGId"].ToString();
                string[] no = dt.Rows[0]["NumberOfItems"].ToString().Split('.');

                XElement NumberOfItems = new XElement(ns2 + "NumberOfItems", Math.Round(Convert.ToDecimal(dt.Rows[0]["NumberOfItems"].ToString()),0));
                XElement Summary = new XElement(ns8 + "Summary","");
                if (Convert.ToDecimal(dt.Rows[0]["NumberOfItems"].ToString()) > 0)
                {
                    Summary.Add(NumberOfItems);
                }

                //Summary
                XElement Item = null;
                XElement AddCerDetail = null;
                XElement CurrencyCode = null;
                XElement PerferCont = null;
                XElement copNum1 = null;
                XElement CerType1 = null;
                XElement SeqNum1 = null;
                XElement copNum = null;
                XElement CerType = null;
                XElement SeqNum = null;
                XElement certificateDet = null;
                XElement certificateDet1 = null;
                
                //Item               

                string SupFile = "";
                XElement SupportingDocumentReference = new XElement(ns3 + "SupportingDocumentReference", "");
                string infilname = "select * from COFileUpload where InPaymentId='" + dt.Rows[0]["PermitId"].ToString() + "'";
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
                //XElement Licence = new XElement(ns3 + "Licence", "");
                //if (!string.IsNullOrWhiteSpace(dt.Rows[0]["License"].ToString()))
                //{
                //    string[] refid = dt.Rows[0]["License"].ToString().Split('-');
                //    for (int ri = 0; ri < refid.Length; ri++)
                //    {
                //        licNo = refid[0].ToString();
                //        XElement Referenceid = new XElement(ns2 + "ReferenceID", refid[ri].ToString());
                //        Licence.Add(Referenceid);
                //    }
                //}
                string ManufactStr = "select * from dbo.COManufacturer where ManufacturerCode='" + dt.Rows[0]["Manufacturer"].ToString() + "'";
                string ManufactID = "", ManufactName = "", ManufactName1 = "", ManufactAddre = "", ManufactCity = "", ManufactCountrySubCode = "", ManufactCountrySub = "", ManufactCountryCode = "", ManufactPostalCde = "";
                obj.dr = obj.ret_dr(ManufactStr);
                while (obj.dr.Read())
                {
                    ManufactID = obj.dr["ManufacturerCRUEI"].ToString().ToUpper();
                    ManufactName = obj.dr["ManufacturerName"].ToString();
                    ManufactName1 = obj.dr["ManufacturerName1"].ToString();
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

                XElement ManufactPartName2 = new XElement(ns2 + "Name", ManufactName1.ToUpper());
                XElement ManufactPartName1 = new XElement(ns2 + "Name", ManufactName.ToUpper());
                XElement ManufactPartyName = new XElement(ns3 + "PartyName", "");
                ManufactPartyName.Add(ManufactPartName1);
                if (!string.IsNullOrWhiteSpace(ManufactName1))
                {
                    ManufactPartyName.Add(ManufactPartName2);
                }
                XElement ManufactPartyID = new XElement(ns2 + "ID", ManufactID.ToUpper());
                XElement ManufactPartIdenti = new XElement(ns3 + "PartyIdentification", "");
                ManufactPartIdenti.Add(ManufactPartyID);
                XElement ManufactPartDetail = new XElement(ns3 + "PartyDetail", "");
                ManufactPartDetail.Add(ManufactPartIdenti);
                ManufactPartDetail.Add(ManufactPartyName);
                XElement ManufactParty = new XElement(ns3 + "ManufacturerParty", "");
                ManufactParty.Add(ManufactPartDetail);
                ManufactParty.Add(ManufactPartyAddre);

                string ConsigneeStr = "select * from COConsignee where ConsigneeCode='" + dt.Rows[0]["CONSIGNEECode"].ToString() + "'";
                string ConsignID = "", ConsignName = "", ConsignAddre = "", ConsignCity = "", ConsignCountrySubCode = "", ConsignCountrySub = "", ConsignCountryCode = "", ConsignPostalCde = "";
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
                XElement ConsignPartyCountry = new XElement(ns2 + "Line", ConsignCountryCode);
                XElement ConsignPartypostCode = new XElement(ns2 + "Line", ConsignPostalCde);
                XElement ConsignPartyCountrySub = new XElement(ns2 + "Line", ConsignCountrySub);
                XElement ConsignPartyCountrySubCode = new XElement(ns2 + "Line", ConsignCountrySubCode);
                XElement ConsignPartyCity = new XElement(ns2 + "Line", ConsignCity);
                XElement ConsignPartyLine = new XElement(ns2 + "Line", ConsignAddre);
                XElement ConsignPartyAddLine = new XElement(ns3 + "AddressLine", "");
                XElement ConsignPartyAddre = new XElement(ns3 + "Address", "");
                if (!string.IsNullOrWhiteSpace(ConsignAddre))
                {
                    ConsignPartyAddLine.Add(ConsignPartyLine);
                }
                //if (!string.IsNullOrWhiteSpace(ConsignAddre))
                //{
                //    ConsignPartyAddre.Add(ConsignPartyAddLine);
                //}
                if (!string.IsNullOrWhiteSpace(ConsignCity))
                {
                    ConsignPartyAddLine.Add(ConsignPartyCity);
                }
                if (!string.IsNullOrWhiteSpace(ConsignCountrySubCode))
                {
                    ConsignPartyAddLine.Add(ConsignPartyCountrySubCode);
                }
                if (!string.IsNullOrWhiteSpace(ConsignCountrySub))
                {
                    ConsignPartyAddLine.Add(ConsignPartyCountrySub);
                }
                if (!string.IsNullOrWhiteSpace(ConsignPostalCde))
                {
                    ConsignPartyAddLine.Add(ConsignPartypostCode);
                }
                if (!string.IsNullOrWhiteSpace(ConsignCountryCode))
                {
                    ConsignPartyAddLine.Add(ConsignPartyCountry);
                }
                XElement ConsignPartName = new XElement(ns2 + "Name", ConsignName);
                XElement ConsignPartyName = new XElement(ns3 + "PartyName", "");
                if (!string.IsNullOrWhiteSpace(ConsignName))
                {
                    ConsignPartyName.Add(ConsignPartName);
                }
                XElement ConsignParty = new XElement(ns3 + "ConsigneeParty", "");

                if (!string.IsNullOrWhiteSpace(ConsignName))
                {
                    ConsignParty.Add(ConsignPartyName);
                }
                if (!string.IsNullOrWhiteSpace(ConsignAddre))
                {
                    ConsignParty.Add(ConsignPartyAddLine);
                }

                //string impotparty = "select CRUEI,Name,ConsigneeAddress from dbo.COConsignee where Code='" + dt.Rows[0]["CONSIGNEECode"].ToString() + "'";
                //string importName = "", Importid = "", ImpAdd = "";
                //obj.dr = obj.ret_dr(impotparty);
                //while (obj.dr.Read())
                //{
                //    // CPC.Add(obj.dr[0].ToString());
                //    importName = obj.dr["Name"].ToString();
                //    Importid = obj.dr["CRUEI"].ToString();
                //    ImpAdd = obj.dr["ConsigneeAddress"].ToString();
                //}
                //XElement ConAddLine = new XElement(ns2 + "Line", ImpAdd);
                //XElement ConAddress = new XElement(ns3 + "AddressLine", "");
                //ConAddress.Add(ConAddLine);
                //XElement ClainmentName = new XElement(ns2 + "Name", importName);
                //XElement ClainmentPartyName = new XElement(ns3 + "PartyName", "");
                //XElement ImporterParty = new XElement(ns3 + "ConsigneeParty", "");
                //if (!string.IsNullOrWhiteSpace(ImpAdd))
                //{
                //    ImporterParty.Add(ClainmentPartyName);
                //}
                //if (!string.IsNullOrWhiteSpace(importName))
                //{
                //    ClainmentPartyName.Add(ClainmentName);
                //}
                //if (!string.IsNullOrWhiteSpace(ImpAdd))
                //{
                //    ImporterParty.Add(ConAddress);
                //}


                string Expparty = "select CRUEI,Name,Name1,Address,Address1,Address2 from dbo.COExporter where Code='" + dt.Rows[0]["ExporterCompanyCode"].ToString() + "'";
                string ExpName = "", ExpName1="", Expid = "", ExpAdd = "", expadd1 = "", expadd2 = "";
                obj.dr = obj.ret_dr(Expparty);
                while (obj.dr.Read())
                {
                    // CPC.Add(obj.dr[0].ToString());
                    ExpName = obj.dr["Name"].ToString().ToUpper();
                    ExpName1 = obj.dr["Name1"].ToString().ToUpper();
                    Expid = obj.dr["CRUEI"].ToString().ToUpper();
                    ExpAdd = obj.dr["Address"].ToString().ToUpper();
                    expadd1 = obj.dr["Address1"].ToString().ToUpper();
                    expadd2 = obj.dr["Address2"].ToString().ToUpper();
                }
                XElement ExpAddLine = new XElement(ns2 + "Line", ExpAdd);
                XElement ExpAddLine1 = new XElement(ns2 + "Line", expadd1);
                XElement ExpAddLine2 = new XElement(ns2 + "Line", expadd2);

                XElement ExpAddress = new XElement(ns3 + "AddressLine", "");
                if (!string.IsNullOrWhiteSpace(ExpAdd))
                {
                    ExpAddress.Add(ExpAddLine);
                }

                if (!string.IsNullOrWhiteSpace(expadd1))
                {
                    ExpAddress.Add(ExpAddLine1);
                }

                if (!string.IsNullOrWhiteSpace(expadd2))
                {
                    ExpAddress.Add(ExpAddLine2);
                }
                XElement ExportName1 = new XElement(ns2 + "Name", ExpName1);
                XElement ExportName = new XElement(ns2 + "Name", ExpName);
                XElement ExportPartyName = new XElement(ns3 + "PartyName", "");
                XElement ExportID = new XElement(ns2 + "ID", Expid);
                XElement ExportPartyIdentification = new XElement(ns3 + "PartyIdentification", "");
                XElement exportpartyDetail = new XElement(ns3 + "PartyDetail", "");
                XElement ExportParty = new XElement(ns3 + "ExporterParty", "");
                
                ExportPartyIdentification.Add(ExportID);                
                ExportPartyName.Add(ExportName);
                if (!string.IsNullOrWhiteSpace(ExpName1))
                {
                    ExportPartyName.Add(ExportName1);
                }
                exportpartyDetail.Add(ExportPartyIdentification);
                exportpartyDetail.Add(ExportPartyName);
                ExportParty.Add(exportpartyDetail);
                ExportParty.Add(ExpAddress);
                
                

                string outwardparty = "select CRUEI,Name from dbo.COOutwardCarrierAgent where Code='" + dt.Rows[0]["OutwardCarrierAgentCode"].ToString() + "'";
                string outwardName = "", outwardid = "";
                obj.dr = obj.ret_dr(outwardparty);
                while (obj.dr.Read())
                {
                    // CPC.Add(obj.dr[0].ToString());
                    outwardName = obj.dr["Name"].ToString().ToUpper();
                    outwardid = obj.dr["CRUEI"].ToString().ToUpper();
                }
                XElement OutwardName = new XElement(ns2 + "Name", outwardName);
                XElement OutwardPartyName = new XElement(ns3 + "PartyName", "");
                XElement OutwardID = new XElement(ns2 + "ID", outwardid);
                XElement OutwardPartyIdentification = new XElement(ns3 + "PartyIdentification", "");
                XElement OutwardCarrierAgentParty = new XElement(ns3 + "OutwardCarrierAgentParty", "");
                OutwardCarrierAgentParty.Add(OutwardPartyIdentification);
                OutwardPartyIdentification.Add(OutwardID);
                OutwardCarrierAgentParty.Add(OutwardPartyName);
                OutwardPartyName.Add(OutwardPartyName);

                string freiparty = "select CRUEI,Name from dbo.COFreightForwarder where Code='" + dt.Rows[0]["FreightForwarderCode"].ToString() + "'";
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
                    telphn = obj.dr["DeclarantTel"].ToString();
                    decname = obj.dr["DeclarantName"].ToString();
                    deccode = obj.dr["DeclarantCode"].ToString();
                    DecId = obj.dr["CRUEI"].ToString();
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
                XElement Party = new XElement(ns8 + "Party");
                Party.Add(DeclarantParty);
                if (!string.IsNullOrWhiteSpace(declrid))
                {
                    Party.Add(DeclaringAgentParty);
                }
                if (!string.IsNullOrWhiteSpace(FreiID))
                {
                    Party.Add(FreightForwarderParty);
                }
                if (!string.IsNullOrWhiteSpace(Expid))
                {
                    Party.Add(ExportParty);
                }
                if (!string.IsNullOrWhiteSpace(ConsignName))
                {
                    Party.Add(ConsignParty);
                }
                if (!string.IsNullOrWhiteSpace(ManufactID))
                {
                    Party.Add(ManufactParty);
                }
                //if (!string.IsNullOrWhiteSpace(licNo))
                //{
                //    Party.Add(Licence);
                //}
                if (!string.IsNullOrWhiteSpace(SupFile))
                {
                    Party.Add(SupportingDocumentReference);
                }
                //Party.Add(InvoiceName);
                //Party
                string[] final = dt.Rows[0]["FinalDestinationCountry"].ToString().Split(':');
                string ff = final[0].ToString().Substring(0, final[0].Length - 1);
                XElement finalDes = new XElement(ns2 + "FinalDestinationCountry", ff.ToUpper());
                XElement OutLoadingPort = new XElement(ns2 + "DischargePort", dt.Rows[0]["DischargePort"].ToString().ToUpper());
                XElement OutArrivalDate = new XElement(ns2 + "DepartureDate", Convert.ToDateTime(dt.Rows[0]["DepartureDate"].ToString()).ToString("yyyyMMdd").ToUpper());


                XElement OutTransportIdentifier = null;
                XElement OutConveyanceReferenceNumber = null;
                string[] Outmdecde = dt.Rows[0]["OutwardTransportMode"].ToString().Split(':');
                XElement OutModeCode = new XElement(ns2 + "ModeCode", Outmdecde[0].Substring(0, Outmdecde[0].Length - 1).ToUpper());
                XElement OutTransportMode = new XElement(ns3 + "TransportMode", "");
                XElement OutTransportMeans = new XElement(ns3 + "TransportMeans", "");
                XElement OutTransport = new XElement(ns3 + "OutwardTransport", "");

                OutTransport.Add(OutTransportMeans);
                OutTransportMeans.Add(OutTransportMode);
                string transid = "", conrefnum = "";
                if (dt.Rows[0]["OutwardTransportMode"].ToString() == "4 : Air")
                {
                    transid = dt.Rows[0]["OutAircraftRegNo"].ToString().ToUpper();
                    conrefnum = dt.Rows[0]["OutFlightNO"].ToString().ToUpper();
                    OutTransportIdentifier = new XElement(ns2 + "TransportIdentifier", dt.Rows[0]["OutAircraftRegNo"].ToString().ToUpper());
                    OutConveyanceReferenceNumber = new XElement(ns2 + "ConveyanceReferenceNumber", dt.Rows[0]["OutFlightNO"].ToString().ToUpper());
                }
                if (dt.Rows[0]["OutwardTransportMode"].ToString() == "1 : Sea")
                {
                    transid = dt.Rows[0]["OutVesselName"].ToString().ToUpper();
                    conrefnum = dt.Rows[0]["OutVoyageNumber"].ToString().ToUpper();
                    OutTransportIdentifier = new XElement(ns2 + "TransportIdentifier", dt.Rows[0]["OutVesselName"].ToString().ToUpper());
                    OutConveyanceReferenceNumber = new XElement(ns2 + "ConveyanceReferenceNumber", dt.Rows[0]["OutVoyageNumber"].ToString().ToUpper());
                }


                if (!string.IsNullOrWhiteSpace(Outmdecde[0].Substring(0, Outmdecde[0].Length - 1)))
                {
                    OutTransportMode.Add(OutModeCode);
                }
                if (!string.IsNullOrWhiteSpace(conrefnum))
                {
                    OutTransportMode.Add(OutConveyanceReferenceNumber);
                }
                if (!string.IsNullOrWhiteSpace(transid))
                {
                    OutTransportMode.Add(OutTransportIdentifier);
                }
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["DepartureDate"].ToString()))
                {
                    OutTransport.Add(OutArrivalDate);
                }
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["DischargePort"].ToString()))
                {
                    OutTransport.Add(OutLoadingPort);
                }
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["FinalDestinationCountry"].ToString()))
                {
                    OutTransport.Add(finalDes);
                }
                XElement Transport = new XElement(ns8 + "Transport", OutTransport);
                //Transport                


                XElement TransPortDet = null;
                
                
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["CurrencyCode"].ToString()))
                {
                    string[] CurCode = dt.Rows[0]["CurrencyCode"].ToString().Split(':');
                    CurrencyCode = new XElement(ns2 + "CurrencyCode", CurCode[0].Substring(0, CurCode[0].Length).ToUpper());
                    PerferCont = new XElement(ns2 + "PreferenceContentPercent", dt.Rows[0]["PerferenceContent"].ToString().ToUpper());
                    copNum1 = new XElement(ns2 + "CopiesNumeric", dt.Rows[0]["CerDtlCopy2"].ToString().ToUpper());
                }
                if (dt.Rows[0]["CerDtlType2"].ToString() != "--Select--")
                {
                    string[] Cerfititype1 = dt.Rows[0]["CerDtlType2"].ToString().Split(':');
                    CerType1 = new XElement(ns2 + "CertificateType", Cerfititype1[0].Substring(0, Cerfititype1[0].Length - 1).ToUpper());
                    SeqNum1 = new XElement(ns2 + "SequenceNumeric", "2");
                    copNum = new XElement(ns2 + "CopiesNumeric", dt.Rows[0]["CerDtlCopy1"].ToString().ToUpper());
                    certificateDet1 = new XElement(ns3 + "CertificateDetail", "");
                }
                if (dt.Rows[0]["CerDtlType1"].ToString() != "--Select--")
                {
                    string[] Cerfititype = dt.Rows[0]["CerDtlType1"].ToString().Split(':');
                    CerType = new XElement(ns2 + "CertificateType", Cerfititype[0].ToString().Substring(0, Cerfititype[0].Length - 1));
                    SeqNum = new XElement(ns2 + "SequenceNumeric", "1");
                    certificateDet = new XElement(ns3 + "CertificateDetail", "");
                }
                if (dt.Rows[0]["CerDtlType1"].ToString() != "--Select--")
                {
                    certificateDet.Add(SeqNum);
                    certificateDet.Add(CerType);
                }
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["CerDtlCopy1"].ToString()))
                {
                    certificateDet.Add(copNum);
                }
                if (dt.Rows[0]["CerDtlType2"].ToString() != "--Select--")
                {
                    certificateDet1.Add(SeqNum1);
                    certificateDet1.Add(CerType1);
                }
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["CerDtlCopy2"].ToString()))
                {
                    certificateDet.Add(copNum1);
                }
                //XElement GspCountry = new XElement(ns2 + "GSPDonorCountry", "");
                XElement entryYear = new XElement(ns2 + "EntryYear", dt.Rows[0]["EntryYear"].ToString());
                string[] AppType = dt.Rows[0]["COType"].ToString().Split(':');
                XElement AppProdcutType = new XElement(ns2 + "ApplicationProductType", AppType[0].Substring(0, AppType[0].Length - 1).ToUpper());
                XElement Certificate = new XElement(ns8 + "Certificate");
                Certificate.Add(AppProdcutType);
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["EntryYear"].ToString()))
                {
                    Certificate.Add(entryYear);
                }
                //Certificate.Add(GspCountry);
                if (dt.Rows[0]["CerDtlType1"].ToString() != "--Select--")
                {
                    Certificate.Add(certificateDet);
                }
                if (dt.Rows[0]["CerDtlType2"].ToString() != "--Select--")
                {
                    Certificate.Add(certificateDet1);
                }


                List<string> CPC = new List<string>();
                string qry11a = "select distinct(CPCType) from dbo.CoCPCtbl where PermitId='" + dt.Rows[0]["PermitID"].ToString() + "'";
                obj.dr = obj.ret_dr(qry11a);
                while (obj.dr.Read())
                {
                    CPC.Add(obj.dr[0].ToString());
                    // CPC = obj.dr[0].ToString();
                }
                string cusprc = "";
                XElement Customprce = new XElement(ns3 + "CustomseProcedureCodeInformation", "");
                for (int i = 0; i < CPC.Count; i++)
                {
                    string Code = "";
                    string qry111 = "select * from dbo.CoCPCtbl where PermitId='" + dt.Rows[0]["PermitID"].ToString() + "' and CPCType='" + CPC[i].ToString() + "'";
                    obj.dr = obj.ret_dr(qry111);
                    while (obj.dr.Read())
                    {
                        Code = obj.dr[0].ToString();

                        //cARGO

                        XElement Customprce1 = new XElement(ns3 + "CPCProcessingCode", "");
                        if (!string.IsNullOrWhiteSpace(obj.dr["CPCType"].ToString()))
                        {
                            Customprce1.Add(new XElement(ns2 + "ProcessingCodeOne", obj.dr["ProcessingCode1"].ToString().ToUpper()));
                            Customprce1.Add(new XElement(ns2 + "ProcessingCodeTwo", obj.dr["ProcessingCode2"].ToString().ToUpper()));
                            Customprce1.Add(new XElement(ns2 + "ProcessingCodeThree", obj.dr["ProcessingCode3"].ToString().ToUpper()));
                            Customprce.Add(new XElement(ns2 + "CustomseProcedureCode", obj.dr["CPCType"].ToString()));
                            Customprce.Add(Customprce1);
                            cusprc = obj.dr["CPCType"].ToString();
                        }

                    }
                }

                //XElement BankerCode = new XElement(ns2 + "BankerGuaranteeCode", dt.Rows[0]["BGIndicator"].ToString());
                //XElement Additional = new XElement(ns2 + "AdditionalRecipientID", "");
                XElement Remarks = new XElement(ns3 + "CertificateAdditionalInformation", "");
                Remarks.Add(new XElement(ns2 + "Line", dt.Rows[0]["TradeRemarks"].ToString().ToUpper()));
                XElement DeclarationIndicator = new XElement(ns2 + "DeclarationIndicator", dt.Rows[0]["DeclareIndicator"].ToString().ToLower());
                XElement PreviousPermitNumber = new XElement(ns2 + "PreviousPermitNumber", dt.Rows[0]["PreviousPermitNo"].ToString().ToUpper());
                XElement DeclarationType = new XElement(ns2 + "ApplicationType", dt.Rows[0]["ApplicationType"].ToString().ToUpper());
                XElement CommonAccessReference = new XElement(ns2 + "CommonAccessReference", dt.Rows[0]["MessageType"].ToString().ToUpper());
                XElement Applicationtype = new XElement(ns2 + "ApplicationType", dt.Rows[0]["ApplicationType"].ToString().ToUpper());
                XElement DeclarantID = new XElement(ns2 + "DeclarantID", dt.Rows[0]["TradeNetMailboxID"].ToString().ToUpper().TrimEnd());
                XElement MessageReference = new XElement(ns2 + "MessageReference", dt.Rows[0]["MSGId"].ToString().ToUpper());
                string date = "";
                string sequneNo = "";
                date = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                sequneNo = dt.Rows[0]["MSGId"].ToString().Substring(dt.Rows[0]["MSGId"].ToString().Length - 4);
                XElement UniqueReferenceNumber = new XElement(ns3 + "UniqueReferenceNumber", "");
                UniqueReferenceNumber.Add(new XElement(ns2 + "ID", DecId.ToUpper()));
                UniqueReferenceNumber.Add(new XElement(ns2 + "Date", date));
                UniqueReferenceNumber.Add(new XElement(ns2 + "SequenceNumeric", sequneNo.ToUpper()));

                XElement Header = new XElement(ns8 + "Header");
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
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["ApplicationType"].ToString()))
                {
                    Header.Add(Applicationtype);
                }
                //if (!string.IsNullOrWhiteSpace(DecType[0].ToString().Substring(0, DecType[0].ToString().Length - 1)))
                //{
                //    Header.Add(DeclarationType);
                //}
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["DeclareIndicator"].ToString()))
                {
                    Header.Add(DeclarationIndicator);
                }
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["PreviousPermitNo"].ToString()))
                {
                    Header.Add(PreviousPermitNumber);
                }
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["TradeRemarks"].ToString()))
                {
                    Header.Add(Remarks);
                }
                //Header.Add(Additional);
                //if (!string.IsNullOrWhiteSpace(dt.Rows[0]["BGIndicator"].ToString()))
                //{
                //    if (dt.Rows[0]["BGIndicator"].ToString() != "--Select--")
                //    {
                //        Header.Add(BankerCode);
                //    }
                //}
                if (!string.IsNullOrWhiteSpace(cusprc))
                {
                    Header.Add(Customprce);
                }
                if (dt.Rows[0]["COType"].ToString() != "--Select--")
                {
                    Header.Add(Certificate);
                }
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["PerferenceContent"].ToString()))
                {
                    Header.Add(PerferCont);
                }
                if (dt.Rows[0]["CurrencyCode"].ToString() != "")
                {
                    Header.Add(CurrencyCode);
                }
                if (dt.Rows[0]["AdditionalCer"].ToString() != "----")
                {
                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["AdditionalCer"].ToString()))
                    {
                        string[] AddCCer = dt.Rows[0]["AdditionalCer"].ToString().Split('-');
                        for (int i = 0; i < AddCCer.Length; i++)
                        {
                            if (!string.IsNullOrWhiteSpace(AddCCer[i].ToString()))
                            {
                                AddCerDetail = new XElement(ns2 + "AdditionalCertificateDetails", AddCCer[i].ToString().ToUpper());
                                Header.Add(AddCerDetail);
                            }
                            //foreach (string s in AddCCer)
                            //{

                            //}
                        }

                    }
                    
                }
                if (dt.Rows[0]["TransportDtl"].ToString() != "----")
                {
                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["TransportDtl"].ToString()))
                    {
                        string[] TransDet = dt.Rows[0]["TransportDtl"].ToString().Split('-');
                        for (int i = 0; i < TransDet.Length; i++)
                        {
                            if (!string.IsNullOrWhiteSpace(TransDet[i].ToString()))
                            {
                                TransPortDet = new XElement(ns2 + "TransportDetails", TransDet[i].ToString().ToUpper());
                                Header.Add(TransPortDet);
                            }

                        }
                    }
                    
                }
                //header

                XElement InboundMessage = new XElement(ns1 + "InboundMessage");
                XElement InPayment = new XElement(ns8 + "CertificateOfOrigin", Header, Transport, Party);
                string ItemQury = "select * from dbo.COItemDtl where PermitId='" + dt.Rows[0]["PermitId"].ToString() + "'";
                obj.dr = obj.ret_dr(ItemQury);
                if (obj.dr.HasRows)
                {
                    while (obj.dr.Read())
                    {

                        XElement ItemContenPer = new XElement(ns2 + "ContentPercent", obj.dr["PerOrgainCRI"].ToString().ToUpper());
                        XElement ItemHSCode = new XElement(ns2 + "HarmonizedSystemCode", obj.dr["HSOnCer"].ToString().ToUpper());
                        XElement ItemOrgin = null;
                        XElement ItemInvDate = new XElement(ns2 + "ItemInvoiceDate", Convert.ToDateTime(obj.dr["InvoiceDate"].ToString()).ToString("yyyyMMdd").ToUpper());
                        XElement ItemInvNum = new XElement(ns2 + "ItemInvoiceNumber", obj.dr["InvoiceNumber"].ToString().ToUpper());
                        XElement TextCatQty = new XElement(ns2 + "TextileQuotaQuantity", obj.dr["TextileQuotaQty"].ToString().ToUpper());
                        TextCatQty.Add(new XAttribute("unitCode", obj.dr["TextileQuotaQtyUOM"].ToString().ToUpper()));
                        XElement TextCatCode = new XElement(ns2 + "TextileCategoryCode", obj.dr["TextileCat"].ToString().ToUpper());
                        XElement ManfacCostDate = new XElement(ns2 + "ManufacturingCostDate", Convert.ToDateTime(obj.dr["ManfCostDate"].ToString()).ToString("yyyyMMdd").ToUpper());
                        XElement ItemLine = null;
                        XElement ItemCerDescr = new XElement(ns3 + "ItemCertificateDescription", "");
                        int partLength = 35;
                        string sentence = obj.dr["CertificateDes"].ToString();
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
                            if (!string.IsNullOrWhiteSpace(obj.dr["CertificateDes"].ToString()))
                            {
                                ItemLine = new XElement(ns2 + "Line", lines[i].ToString().ToUpper());
                                ItemCerDescr.Add(ItemLine);
                            }
                        }
                        XElement ItemVal = new XElement(ns2 + "ItemValue", obj.dr["ItemValue"].ToString().ToUpper());
                        XElement ItemCerQty = new XElement(ns2 + "ItemCertificateQuantity", obj.dr["CerItemQty"].ToString().ToUpper());
                        ItemCerQty.Add(new XAttribute("unitCode", obj.dr["CerItemUOM"].ToString().ToUpper()));
                        XElement ItemCer = new XElement(ns3 + "ItemCertificate", "");
                        if (Convert.ToDecimal(obj.dr["CerItemQty"].ToString()) > 0)
                        {
                            ItemCer.Add(ItemCerQty);
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["ItemValue"].ToString().ToUpper()))
                        {
                            ItemCer.Add(ItemVal);
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["CertificateDes"].ToString().ToUpper()))
                        {
                            ItemCer.Add(ItemCerDescr);
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["ManfCostDate"].ToString()))
                        {
                            ItemCer.Add(ManfacCostDate);
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["TextileCat"].ToString()))
                        {
                            ItemCer.Add(TextCatCode);
                        }
                        if (obj.dr["TextileQuotaQty"].ToString() != "0.00")
                        {
                            ItemCer.Add(TextCatQty);
                        }
                        //if (!string.IsNullOrWhiteSpace(obj.dr["TextileCat"].ToString()))
                        //{
                        //    ItemCer.Add(TextCatCode);
                        //}
                        if (!string.IsNullOrWhiteSpace(obj.dr["InvoiceNumber"].ToString()))
                        {
                            ItemCer.Add(ItemInvNum);
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["InvoiceDate"].ToString()))
                        {
                            ItemCer.Add(ItemInvDate);
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["OriginCriterion"].ToString()))
                        {
                            string[] orgcri = obj.dr["OriginCriterion"].ToString().Split(',');
                            for (int i = 0; i < orgcri.Length; i++)
                            {
                                if (orgcri[i].ToString() != "")
                                {
                                    ItemOrgin = new XElement(ns2 + "OriginCriterion", orgcri[i].ToString().ToUpper());
                                    ItemCer.Add(ItemOrgin);
                                }
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["HSOnCer"].ToString()))
                        {
                            ItemCer.Add(ItemHSCode);
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["PerOrgainCRI"].ToString()))
                        {
                            ItemCer.Add(ItemContenPer);
                        }
                        XElement ShipMarks = null;
                        XElement ShipMarksInfo = null;

                        XElement ItemCIFFOBValue = new XElement(ns2 + "ItemCIFFOBValue", obj.dr["CIFFOB"].ToString().ToUpper());
                        //  XElement TransactionValue = new XElement(ns3 + "TransactionValue", "");
                        string[] corgin = obj.dr["Contry"].ToString().Split(':');
                        string cuntry = corgin[0].ToString().Substring(0, corgin[0].Length - 1);
                        XElement OriginCountry = new XElement(ns2 + "OriginCountry", corgin[0].ToString().ToUpper());
                        XElement HarmonizedSystemQuantity = new XElement(ns2 + "HarmonizedSystemQuantity", obj.dr["HSQTY"].ToString().ToUpper());
                        HarmonizedSystemQuantity.Add(new XAttribute("unitCode", obj.dr["HSUOM"].ToString().ToUpper()));
                        //XElement ItemQuantity = new XElement(ns3 + "ItemQuantity", "");
                        //if (!string.IsNullOrWhiteSpace(obj.dr["HSQTY"].ToString()))
                        //{
                        //    if (Convert.ToDecimal(obj.dr["HSQTY"].ToString()) > 0)
                        //    {
                        //        ItemQuantity.Add(HarmonizedSystemQuantity);
                        //    }
                        //}
                        XElement ItemHarmonizedSystemCode = new XElement(ns2 + "ItemHarmonizedSystemCode", obj.dr["HSCode"].ToString().ToUpper());
                        XElement ItemSequenceNumeric = new XElement(ns2 + "ItemSequenceNumeric", obj.dr["ItemNo"].ToString().ToUpper());
                        Item = new XElement(ns8 + "Item");
                        if (!string.IsNullOrWhiteSpace(obj.dr["ItemNo"].ToString()))
                        {
                            Item.Add(ItemSequenceNumeric);
                        }

                        if (!string.IsNullOrWhiteSpace(obj.dr["HSCode"].ToString()))
                        {
                            Item.Add(ItemHarmonizedSystemCode);
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["HSQTY"].ToString()))
                        {
                            Item.Add(HarmonizedSystemQuantity);
                        }
                        if (!string.IsNullOrWhiteSpace(corgin[0].ToString()))
                        {
                            Item.Add(OriginCountry);
                        }
                        //if (!string.IsNullOrWhiteSpace(obj.dr["UnitPriceCurrency"].ToString()))
                        //{
                        //    if (obj.dr["UnitPriceCurrency"].ToString() != "--Select--")
                        //    {
                        //        Item.Add(TransactionValue);
                        //    }
                        //}
                        if (!string.IsNullOrWhiteSpace(obj.dr["CIFFOB"].ToString()))
                        {
                            Item.Add(ItemCIFFOBValue);
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["ShippingMark"].ToString()))
                        {
                            int partLength12 = 17;
                            string sentence12 = obj.dr["ShippingMark"].ToString();
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
                            ShipMarksInfo = new XElement(ns3 + "ShippingMarksInformation", "");
                            for (int i = 0; i < lines12.Count; i++)
                            {
                                if (!string.IsNullOrWhiteSpace(lines12[i].ToString()))
                                {
                                    ShipMarks = null;
                                    //ShipMarksInfo = null;
                                    ShipMarks = new XElement(ns2 + "ShippingMarks", lines12[i].ToString().ToUpper());
                                    ShipMarksInfo.Add(ShipMarks);

                                }
                            }
                        }
                        Item.Add(ShipMarksInfo);
                        Item.Add(ItemCer);
                        InPayment.Add(Item);
                    }                    
                }                
                InPayment.Add(Summary);
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
            string filename = path + "\\COODEC" + MsgId + ".xml";
            if (!File.Exists(filename))
            {
                //File.Delete(filename);
                using (StreamWriter sw = File.CreateText(filename))
                {
                    sw.WriteLine(sb.ToString());

                    string strins = "";
                    string Name = "COODEC" + MsgId + ".xml";
                    strins = "Insert Into XmlTbl values('" + path + "','" + Name + "','','" + tradeID.ToLower() + "')";
                    obj.exec(strins);

                    strins = "Insert Into DownXmlTbl values('" + path + "','" + Name + "','','" + tradeID.ToLower() + "')";
                    obj.exec(strins);

                    obj.closecon();

                    string strinsn = "";
                    //Send CMD 
                    // Command=Submit|cont_type=F|subj=IPTDEC202510290002|filename=D:\\MHAccess\\workingdir\\KaizenOUT\\KAKG001\\IPTDEC202510290002.xml|cont_id=G14848838067|recip_id=dcst401|notifn=N"

                    string sunjt = "COODEC" + MsgId + "";
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

        public void ResponseXML(string folName)
        {
            try
            {
                string xmlFile = "";
                string tradeIDXML = tradmail;
                string[] tradID = tradeIDXML.Split('.');
                tradeIDXML = tradID[1].ToString() + "\\";
                string filePath = @"D:\MHAccess\workingdir\KaizenIN\" + tradeIDXML;


               // string filePath = @"D:\Users\Public\" + folName + "\\ResponseFile\\";
                DirectoryInfo apple = new DirectoryInfo(filePath);
                foreach (var file in apple.GetFiles("*"))
                {
                    lststr1.Clear();
                    fldName = "";
                    fldval = "";
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
                                fldName = fldName + authorsList[1].ToString() + ",";
                                fldval = fldval + "'" + child.InnerText + "'" + ",";
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
                        string ffname = file.ToString();
                        ffname = ffname.Substring(0, 3);
                        ffname = "";                        
                        string flanme = file.ToString().Substring(0, file.ToString().Length - 2);
                        for (int j = 0; j < lststr1.Count; j++)
                        {
                            string str = "";
                            if (j == 0)
                            {
                                MyClass objipt = new MyClass();
                                objipt.dr = objipt.ret_dr("select Count(*) FROM InHeaderTbl where MSGId='" + msgid + "'");
                                while (objipt.dr.Read())
                                {
                                    string value = objipt.dr[0].ToString();
                                    if (Convert.ToInt32(value) > 0)
                                    {
                                        str = "update InHeaderTbl set  PermitNumber='" + pemno + "',Status='APR' where MSGId='" + msgid + "'";
                                        obj.exec(str);

                                        str = "delete from DownXmlTbl where FName='" + flanme + "' and tradeID='" + folName + "'";
                                        obj.exec(str);                                       

                                        MyClass objiptrej = new MyClass();
                                        objiptrej.dr = objiptrej.ret_dr("select Count(*) FROM InPMT where PermitNumber='" + pemno + "'");
                                        while (objiptrej.dr.Read())
                                        {
                                            string value1 = objiptrej.dr[0].ToString();
                                            if (Convert.ToInt32(value1) <= 0)
                                            {
                                                ffname = "IPT";
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
                                        str = "update InNonHeaderTbl set  PermitNumber='" + pemno + "',Status='APR' where MSGId='" + msgid + "'";
                                        obj.exec(str);

                                        str = "delete from DownXmlTbl where FName='" + flanme + "' and tradeID='" + folName + "'";
                                        obj.exec(str);

                                        MyClass objiptrej = new MyClass();
                                        objiptrej.dr = objiptrej.ret_dr("select Count(*) FROM InnonPMT where PermitNumber='" + pemno + "'");
                                        while (objiptrej.dr.Read())
                                        {
                                            string value1 = objiptrej.dr[0].ToString();
                                            if (Convert.ToInt32(value1) <= 0)
                                            {
                                                ffname = "INP";
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
                                        str = "update OutHeaderTbl set  PermitNumber='" + pemno + "',Status='APR' where MSGId='" + msgid + "'";
                                        obj.exec(str);

                                        str = "delete from DownXmlTbl where FName='" + flanme + "' and tradeID='" + folName + "'";
                                        obj.exec(str);

                                        MyClass objiptrej = new MyClass();
                                        objiptrej.dr = objiptrej.ret_dr("select Count(*) FROM OutPMT where PermitNumber='" + pemno + "'");
                                        while (objiptrej.dr.Read())
                                        {
                                            string value1 = objiptrej.dr[0].ToString();
                                            if (Convert.ToInt32(value1) <= 0)
                                            {
                                                ffname = "OUT";
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
                                        str = "update TranshipmentHeader set  PermitNumber='" + pemno + "',Status='APR' where MSGId='" + msgid + "'";
                                        obj.exec(str);

                                        str = "delete from DownXmlTbl where FName='" + flanme + "' and tradeID='" + folName + "'";
                                        obj.exec(str);

                                        MyClass objiptrej = new MyClass();
                                        objiptrej.dr = objiptrej.ret_dr("select Count(*) FROM TransPMT where PermitNumber='" + pemno + "'");
                                        while (objiptrej.dr.Read())
                                        {
                                            string value1 = objiptrej.dr[0].ToString();
                                            if (Convert.ToInt32(value1) <= 0)
                                            {
                                                ffname = "TNP";
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
                                        str = "update COHeaderTbl set  PermitNumber='" + pemno + "',Status='APR' where MSGId='" + msgid + "'";
                                        obj.exec(str);

                                        str = "delete from DownXmlTbl where FName='" + flanme + "' and tradeID='" + folName + "'";
                                        obj.exec(str);

                                        MyClass objiptrej = new MyClass();
                                        objiptrej.dr = objiptrej.ret_dr("select Count(*) FROM CoPMT where PermitNumber='" + pemno + "'");
                                        while (objiptrej.dr.Read())
                                        {
                                            string value1 = objiptrej.dr[0].ToString();
                                            if (Convert.ToInt32(value1) <= 0)
                                            {
                                                ffname = "COO";
                                            }
                                        }
                                    }
                                }
                            }
                            //if (j == 0)
                            //{
                            //    if (ffname == "IPT")
                            //    {
                            //        str = "update InHeaderTbl set  PermitNumber='" + pemno + "',Status='APR' where MSGId='" + msgid + "'";
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
                        //string sourceFile = @"D:\Users\Public\ResponseFile\" + file;

                        //string destinationFile = @"D:\Users\Public\CopyFile\" + file;
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

            }
        }
        public void RejectionXML(string folName)
        {
            try
            {
                string filePath = @"D:\Users\Public\" + folName + "\\ResponseFile\\";
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
                    int i = 0;
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
                                    objipt.dr = objipt.ret_dr("select * FROM InHeaderTbl where MSGId='" + strvalue + "'");
                                    while (objipt.dr.Read())
                                    {
                                        string value = objipt.dr["MSGId"].ToString();
                                        if (!string.IsNullOrWhiteSpace(value))
                                        {
                                            str = "update InHeaderTbl set  Status='REJ' where MSGId='" + strvalue + "'";
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
                    Label labelProductID = (Label)gvrow.FindControl("lblPermitNo");
                    permitid = labelProductID.Text;
                    MyClass obj2 = new MyClass();
                    obj2.dr = obj2.ret_dr("Select TradeNetMailboxID from COHeaderTbl where PermitId='" + permitid + "'");
                    if (obj2.dr.HasRows)
                    {
                        while (obj2.dr.Read())
                        {
                            tradeIDXML = obj2.dr["TradeNetMailboxID"].ToString();
                        }
                    }
                    //LoadOUTDEC(permitid);
                    LoadCOODEC(permitid);


                    string Touch_user = Session["UserId"].ToString();
                    string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string P1 = ("Update COHeaderTbl set Status='PEN' , TouchUser= '" + Touch_user + "' , TouchTime='" + strTime + "' where PermitId='" + permitid + "' ");
                    obj.exec(P1);
                    obj.closecon();

                  

                }
            }
            //MyClass obj21 = new MyClass();
            //obj21.dr = obj21.ret_dr("Select TradeNetMailboxID from InHeaderTbl where TouchUser= '" + Session["UserId"].ToString() + "'");
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
            //ResponseXML();
            //ErrorXml();
            //RejectionXML();
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
                    Label ID1 = (Label)gvrow.FindControl("lblPermitNo");
                    PermitId = ID1.Text;
                    PermitNO();
                    JobNO();
                    refid();
                    MSGNO();
                    string Touch_user = Session["UserId"].ToString();
                    string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


                    string headertbl = "insert into COHeaderTbl ([Refid],[JobId],[MSGId],[PermitId],[TradeNetMailboxID],[MessageType],[ApplicationType],[PreviousPermitNo],[OutwardTransportMode],[ReferenceDocuments],[COType],[CerDtlType1],[CerDtlCopy1],[CerDtlType2],[CerDtlCopy2],[CurrencyCode],[AdditionalCer],[TransportDtl],[PerferenceContent],[DeclarantCompanyCode],[ExporterCompanyCode],[OutwardCarrierAgentCode],[FreightForwarderCode],[CONSIGNEECode],[Manufacturer],[DepartureDate],[DischargePort],[FinalDestinationCountry],[OutVoyageNumber],[OutVesselName],[OutConveyanceRefNo],[OutTransportId],[OutFlightNO],[OutAircraftRegNo],[TotalOuterPack],[TotalOuterPackUOM],[TotalGrossWeight],[TotalGrossWeightUOM],[DeclareIndicator],[NumberOfItems],[InternalRemarks],[TradeRemarks],[Status],[TouchUser],[TouchTime],[PermitNumber] )";
                    headertbl = headertbl + " select  '" + refno + "' as Refid,'" + JobNo + "' as JobId ,'" + MsgNO + "' as MSGID,'" + PermitNo + "' as PermitId,[TradeNetMailboxID],[MessageType],[ApplicationType],[PreviousPermitNo],[OutwardTransportMode],[ReferenceDocuments],[COType],[CerDtlType1],[CerDtlCopy1],[CerDtlType2],[CerDtlCopy2],[CurrencyCode],[AdditionalCer],[TransportDtl],[PerferenceContent],[DeclarantCompanyCode],[ExporterCompanyCode],[OutwardCarrierAgentCode],[FreightForwarderCode],[CONSIGNEECode],[Manufacturer],[DepartureDate],[DischargePort],[FinalDestinationCountry],[OutVoyageNumber],[OutVesselName],[OutConveyanceRefNo],[OutTransportId],[OutFlightNO],[OutAircraftRegNo],[TotalOuterPack],[TotalOuterPackUOM],[TotalGrossWeight],[TotalGrossWeightUOM],[DeclareIndicator],[NumberOfItems],[InternalRemarks],[TradeRemarks],'NEW' as [Status],'" + Touch_user + "' as  [TouchUser],'" + strTime + "' as [TouchTime],[PermitNumber] from COHeaderTbl where [PermitId] = '" + PermitId + "'  ";


                    //string invoice = "insert into OutInvoiceDtl ([SNo],[InvoiceNo],[InvoiceDate],[TermType],[AdValoremIndicator],[PreDutyRateIndicator],[SupplierImporterRelationship],[SupplierCode],[ExportPartyCode],[TICurrency],[TIExRate],[TIAmount] ,[TISAmount],[OTCCharge],[OTCCurrency],[OTCExRate],[OTCAmount],[OTCSAmount],[FCCharge],[FCCurrency],[FCExRate],[FCAmount],[FCSAmount],[ICCharge],[ICCurrency],[ICExRate],[ICAmount],[ICSAmount],[CIFSUMAmount],[GSTPercentage],[GSTSUMAmount],[MessageType],[PermitId],[TouchUser],[TouchTime]  )";
                    //invoice = invoice + " select [SNo],[InvoiceNo],[InvoiceDate],[TermType],[AdValoremIndicator],[PreDutyRateIndicator],[SupplierImporterRelationship],[SupplierCode],[ExportPartyCode],[TICurrency],[TIExRate],[TIAmount] ,[TISAmount],[OTCCharge],[OTCCurrency],[OTCExRate],[OTCAmount],[OTCSAmount],[FCCharge],[FCCurrency],[FCExRate],[FCAmount],[FCSAmount],[ICCharge],[ICCurrency],[ICExRate],[ICAmount],[ICSAmount],[CIFSUMAmount],[GSTPercentage],[GSTSUMAmount],[MessageType],'" + PermitNo + "' as [PermitId],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime]  from OutInvoiceDtl where [PermitId] = '" + PermitId + "'  ";


                    string item = "insert into COItemDtl ([ItemNo],[PermitId],[MessageType],[HSCode],[Description],[Contry],[UnitPrice],[UnitPriceCurrency],[ExchangeRate],[SumExchangeRate],[TotalLineAmount],[CIFFOB],[InvoiceQty] ,[HSQTY],[HSUOM],[ShippingMark],[CerItemQty],[CerItemUOM],[ManfCostDate],[TextileCat],[TextileQuotaQty],[TextileQuotaQtyUOM],[ItemValue],[InvoiceNumber],[InvoiceDate],[HSOnCer],[OriginCriterion],[PerOrgainCRI],[CertificateDes],[Touch_user],[TouchTime] )";
                    item = item + " select [ItemNo],'" + PermitNo + "' as [PermitId],[MessageType],[HSCode],[Description],[Contry],[UnitPrice],[UnitPriceCurrency],[ExchangeRate],[SumExchangeRate],[TotalLineAmount],[CIFFOB],[InvoiceQty] ,[HSQTY],[HSUOM],[ShippingMark],[CerItemQty],[CerItemUOM],[ManfCostDate],[TextileCat],[TextileQuotaQty],[TextileQuotaQtyUOM],[ItemValue],[InvoiceNumber],[InvoiceDate],[HSOnCer],[OriginCriterion],[PerOrgainCRI],[CertificateDes],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime]  from COItemDtl where [PermitId] = '" + PermitId + "' ";



                    string file = "insert into COFileUpload ([Name],[ContentType],[Data],[DocumentType],InPaymentId,[TouchUser],[TouchTime] )";
                    file = file + "select  [Name],[ContentType],[Data],[DocumentType],'" + PermitNo + "' as [InPaymentId],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime]  from COFileUpload where InPaymentId = '" + PermitId + "' ";

                   // string PerCount = ("INSERT INTO [dbo].[PermitCount] ([PermitId],[MessageType],[AccountId],[TouchUser],[TouchTime])  VALUES ('" + PermitNo + "','COODEC','" + Session["AccountId"].ToString() + "','" + Touch_user + "','" + strTime + "')");
                    string PerCount = ("INSERT INTO [dbo].[PermitCount] ([PermitId],[MessageType],[AccountId],[MsgId],[TouchUser],[TouchTime])  VALUES ('" + PermitNo + "','COODEC','" + Session["AccountId"].ToString() + "','" + MsgNO + "','" + Touch_user + "','" + strTime + "')");

                    obj.exec(headertbl);
                    //  obj.exec(invoice);
                    obj.exec(item);

                    obj.exec(file);
                   obj.exec(PerCount);

                    obj.closecon();



                    BindInPayment();
                    string strBindTxtBox = "select * from COHeaderTbl where PermitId='" + PermitNo + "'";
                    obj.dr = obj.ret_dr(strBindTxtBox);
                    while (obj.dr.Read())
                    {
                        string idpass = obj.dr["ID"].ToString();
                        Response.Redirect("CO.aspx?ID=" + idpass);

                    }

                }
            }
        }


        private void PermitNO()
        {
            string justdate = DateTime.Now.ToString("yyyyMMdd");
            string Touch_user = Session["UserId"].ToString();
            con.Open();
            SqlCommand command1 = new SqlCommand("SELECT Max(Refid) from COHeaderTbl where  LEFT(MSGId,8) ='" + justdate + "'");
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
            SqlCommand command1 = new SqlCommand("SELECT Max(Refid) from COHeaderTbl where   LEFT(MSGId,8) ='" + justdate + "'");
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

        protected void txtPreviousPermitNo_TextChanged(object sender, EventArgs e)
        {
            search();
        }
    }
}