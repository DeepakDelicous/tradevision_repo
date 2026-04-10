using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using iTextSharp.text.html.simpleparser;



namespace RET
{
    public partial class InpaymentList : System.Web.UI.Page
    {
        string PermID = "";
        DataTable dt = new DataTable();
        MyClass obj = new MyClass();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
        string sqlconn = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
        string PermitId = "";
        string PermitNo = "";
        iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 60f, 5f, 5f, 20f);
        float pgheight = 0;
        int lineheight = 0;
        int Linecount = 62;
        // int chkline = 0;
        string space = "", space1 = ""; string lspval = "";
        int sapceval = 0, spceval1 = 0;
        string handl = "";
        string strInHAWBOBL = "";
        string MSGNUMBER = "";
        string JobNo, MsgNO, refno = "";
        private static string Update = "";

        static List<string> lststr = new List<string>();
        List<string> lststr1 = new List<string>();
        List<string> lststr2 = new List<string>();
        List<string> lststr3 = new List<string>();
        List<string> AmdFileds = new List<string>();
        string msgid = "", pemno = "";
        string fldName = "", fldval = "", fldval1 = "";
        static string tradmail = "";
        
        string issueaut = "", commacc = "", commacc1 = "", ststype = "", msgidName = "MsgID", SnoName = "Sno";
        string commaccName = "", issueautName = "", commaccName1 = "";


        // string fldName = "", fldName1 = "", fldval = "", fldval1 = "";
        //warning
        /* SqlDataAdapter dastudent;
         DataSet ds_student, ds_course;
         SqlCommand cmdStudent;*/

        //TextBox txtJobid;
        //TextBox txtPermitId;

        public void RunJavaProgram()
        {
            Process process = new Process();
            process.StartInfo.FileName = "java"; // or "java.exe"
                                                 // Set the path to the directory containing your .class file and specify the class name
            process.StartInfo.Arguments = "-cp D:\\MHAccess\\snsjar\\demo demo.Kaizen";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            process.WaitForExit();

            Console.WriteLine("Output: " + output);
            if (!string.IsNullOrEmpty(error))
            {
                Console.WriteLine("Error: " + error);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            Debug.WriteLine("10, processing each row...");


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
                //Mailboxpath = obj.dr["UserId"].ToString();
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
                //colorchange();
                changestatuscolor();
                // search();
            }
            // colorchange();
            changestatuscolor();


        }
        public void RejectionXML(string folName)
        {
            try
            {
                string tradeIDXML = tradmail;
                string[] tradID = tradeIDXML.Split('.');
                tradeIDXML = tradID[1].ToString() + "\\";

                string filePath = @"D:\MHAccess\workingdir\KaizenIN\" + tradeIDXML;
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
                                //string sourceFile = @"D:\MHAccess\workingdir\KaizenIN\" + file;
                                //string sourceFile = @"D:\MHAccess\workingdir\KaizenIN\" + file;

                                //string destinationFile = @"C:\Users\Public\CopyFile\" + file;
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
        public void ErrorXml(string folName)
        {
            try
            {
                string xmlFile = "";

                //Added for testing
                string str1 = "update testing_send_receive set update_field = 'Inside-ErrorXml' where id = 1 ";
                obj.exec(str1);

                string tradeIDXML = tradmail;
                string[] tradID = tradeIDXML.Split('.');
                tradeIDXML = tradID[1].ToString()+"\\" ;
                string filePath = @"D:\MHAccess\workingdir\KaizenIN\" + tradeIDXML;
                DirectoryInfo apple = new DirectoryInfo(filePath);
                foreach (var file in apple.GetFiles("*"))
                {

                    string str3 = "update testing_send_receive set update_field = 'Inside-Foreach' where id = 1 ";
                    obj.exec(str3);

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

                    string str9 = "update testing_send_receive set update_field = 'Update-"+ strvalue + "' where id = 1 ";
                    obj.exec(str9);

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

                        string str4 = "update testing_send_receive set update_field = 'Inside-ERRORM' where id = 1 ";
                        obj.exec(str4);

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
                                    string str5 = "update testing_send_receive set update_field = 'Inside-cac-Check' where id = 1 ";
                                    obj.exec(str5);

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

                                        string str7 = "update testing_send_receive set update_field = 'Inside-fldval-Check' where id = 1 ";
                                        obj.exec(str7);

                                        string ffname = "";
                                        string flanme = file.ToString().Substring(0, file.ToString().Length - 2);
                                        for (int j = 0; j < lststr1.Count; j++)
                                        {

                                            string str8 = "update testing_send_receive set update_field = 'Inside-lststr1-Check' where id = 1 ";
                                            obj.exec(str8);

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
                                            
                                            //Added for testing
                                            string str2 = "update testing_send_receive set update_field = '" + strvalue + "' where id = 1 ";
                                            obj.exec(str2);

                                            while (objipt.dr.Read())
                                            {
                                                string value = objipt.dr["MSGId"].ToString();

                                                string str10 = "update testing_send_receive set update_field = 'Update-Message-" + value + "' where id = 1 ";
                                                obj.exec(str10);

                                                if (!string.IsNullOrWhiteSpace(value))
                                                {

                                                    string str11 = "update testing_send_receive set update_field = 'Update-Last-" + strvalue + "' where id = 1 ";
                                                    obj.exec(str11);

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

            }
        }
        public void AmendXml(string folName)
        {
            try
            {
                string xmlFile = "";
                string date = "";
                string date1 = "", date2 = "", date3 = "";
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
                                    objipt.dr = objipt.ret_dr("select * FROM InHeaderTbl where MSGId='" + msgid + "'");
                                    if (objipt.dr.HasRows)
                                    {
                                        while (objipt.dr.Read())
                                        {
                                            string value = objipt.dr["MSGId"].ToString();
                                            if (!string.IsNullOrWhiteSpace(value))
                                            {
                                                str = "update InHeaderTbl set  PermitNumber='" + pemno + "',Status='APR' where MSGId='" + msgid + "'";
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


                                                str = "delete from DownXmlTbl where FName='" + flanme + "' and tradeID='" + folName + "'";
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
                                                str = "update OutHeaderTbl set  PermitNumber='" + pemno + "',Status='APR' where MSGId='" + msgid + "'";
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

            }
        }

        private void BindInPayment()
        {

            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string str = "SELECT top 20   t6.AccountId,t1.Id, t1.JobId, t1.MSGId, CONVERT(varchar, t1.TouchTime, 105) AS DecDate, SUBSTRING(t1.DeclarationType, 1, CHARINDEX(':', t1.DeclarationType) - 1) AS DeclarationType, t1.TouchUser AS Createby, t2.TradeNetMailboxID AS DecId, CONVERT(varchar, t1.ArrivalDate, 105) AS ETA, t1.PermitId AS LocalNo, t1.PermitNumber AS PermitNo, t3.Name+' '+t3.Name1 AS Importer,STUFF((SELECT distinct(', ' +  US.InHAWBOBL)  FROM ItemDtl US WHERE US.PermitId = t1.PermitId FOR XML PATH('')), 1, 1, '') InHAWBOBL,CASE  WHEN  t1.InwardTransportMode = '4 : Air' THEN t1.MasterAirwayBill  WHEN t1.InwardTransportMode = '1 : Sea'  THEN t1.OceanBillofLadingNo  ELSE ''  END AS MAWBOBL,t1.LoadingPortCode, t1.MessageType, t1.InwardTransportMode, t1.PreviousPermit, t1.InternalRemarks,  SUM(t5.GSTSUMAmount) AS GSTSUMAmount,(select Count(ItemNo) from ItemDtl where ItemDtl.PermitId=t1.PermitId) as SumOfItem, t1.Status FROM  InHeaderTbl AS t1 INNER JOIN DeclarantCompany AS t2 ON t1.DeclarantCompanyCode = t2.Code INNER JOIN Importer AS t3 ON t1.ImporterCompanyCode = t3.Code  INNER JOIN InvoiceDtl AS t5 ON t1.PermitId = t5.PermitId  INNER JOIN ManageUser AS t6 ON t6.UserId=t1.TouchUser where t6.AccountId='" + Session["AccountId"].ToString() + "' and t2.TradeNetMailboxID='"+ tradmail + "'  GROUP BY t1.Id, t1.JobId, t1.MSGId, t1.TouchTime, t1.TouchUser, t1.DeclarationType, t1.ArrivalDate, t1.PermitId, t1.InwardTransportMode, t1.MasterAirwayBill, t1.OceanBillofLadingNo, t1.LoadingPortCode, t1.MessageType, t1.InwardTransportMode, t1.PreviousPermit, t1.InternalRemarks, t1.Status, t2.TradeNetMailboxID, t3.Name,t3.Name1,t6.AccountId,t1.PermitNumber order by t1.Id Desc";

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
                using (SqlCommand cmd = new SqlCommand("SELECT FiledName,FiledValue FROM CustomiseReport Where ReportName='" + "Inpayment" + "' and UserName='" + Touch_user + "' and FiledValue='True'"))
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
                using (SqlCommand cmd = new SqlCommand("SELECT FiledName,FiledValue FROM CustomiseReport Where ReportName='" + "Inpayment" + "' and UserName='" + Touch_user + "' "))
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

                                Debug.WriteLine("1, processing each row...");

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

                                Debug.WriteLine("2, processing each row...");

                                string str = "SELECT  top 1 t6.AccountId,t1.Id, t1.JobId, t1.MSGId, CONVERT(varchar, t1.TouchTime, 105) AS DecDate, SUBSTRING(t1.DeclarationType, 1, CHARINDEX(':', t1.DeclarationType) - 1) AS DeclarationType, t1.TouchUser AS Createby, t2.TradeNetMailboxID AS DecId, CONVERT(varchar, t1.ArrivalDate, 105) AS ETA, t1.PermitId AS LocalNo, t1.PermitNumber AS PermitNo, t3.Name AS Importer,STUFF((SELECT distinct(', ' +  US.InHAWBOBL)  FROM ItemDtl US WHERE US.PermitId = t1.PermitId FOR XML PATH('')), 1, 1, '') InHAWBOBL,CASE  WHEN  t1.InwardTransportMode = '4 : Air' THEN t1.MasterAirwayBill  WHEN t1.InwardTransportMode = '1 : Sea'  THEN t1.OceanBillofLadingNo  ELSE ''  END AS MAWBOBL,t1.LoadingPortCode, t1.MessageType, t1.InwardTransportMode, t1.PreviousPermit, t1.InternalRemarks, SUM(t5.GSTSUMAmount) AS GSTSUMAmount,(select Count(ItemNo) from ItemDtl where ItemDtl.PermitId=t1.PermitId) as SumOfItem, t1.Status FROM  InHeaderTbl AS t1 LEFT JOIN DeclarantCompany AS t2 ON t1.DeclarantCompanyCode = t2.Code LEFT JOIN Importer AS t3 ON t1.ImporterCompanyCode = t3.Code LEFT JOIN InvoiceDtl AS t5 ON t1.PermitId = t5.PermitId  LEFT JOIN ManageUser AS t6 ON t6.UserId=t1.TouchUser where t6.AccountId='" + Session["AccountId"].ToString() + "' and t2.TradeNetMailboxID='"+ tradmail + "'  GROUP BY t1.Id, t1.JobId, t1.MSGId, t1.TouchTime, t1.TouchUser, t1.DeclarationType, t1.ArrivalDate, t1.PermitId, t1.InwardTransportMode, t1.MasterAirwayBill, t1.OceanBillofLadingNo, t1.LoadingPortCode, t1.MessageType, t1.InwardTransportMode, t1.PreviousPermit, t1.InternalRemarks, t1.Status, t2.TradeNetMailboxID, t3.Name,t6.AccountId,t1.PermitNumber order by t1.Id Desc";

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
            //foreach (GridViewRow gvrow in GridInPayment.Rows)
            //{
            //    Label ID1 = (Label)gvrow.FindControl("lblStatus");
            //    string ID = ID1.Text;
            //    if (ID.ToUpper() == "NEW")
            //    {
            //        gvrow.Cells[1].Enabled = true;
            //        gvrow.Cells[2].Enabled = true;
            //    }
            //    else
            //    {
            //        gvrow.Cells[1].Enabled = false;
            //        gvrow.Cells[2].Enabled = false;
            //    }
            //}

            //colorchange();
            changestatuscolor();
        }

        protected void GridInPayment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridInPayment.PageIndex = e.NewPageIndex;
            BindInPayment();
            //UpdatePanel2.Update();
        }

        protected void GridInPayment_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //string id = GridInPayment.DataKeys[e.RowIndex].Value.ToString();

            //string strDelete = "delete from InHeaderTbl where Id='" + id + "' ";
            //obj.exec(strDelete);
            //obj.closecon();
            //BindInPayment();
            //// colorchange();
            //changestatuscolor();
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
            SqlCommand cmd = new SqlCommand("update  InHeaderTbl set  Status='DEL' where ID=" + employeeId, con);
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
            Response.Redirect("Inpayment.aspx?ID=" + ID);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BindInPayment();
        }

        protected void CheckBoxList1_TextChanged(object sender, EventArgs e)
        {

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
                            SqlCommand cmd6 = new SqlCommand("update CustomiseReport set FiledValue='True' where FiledName='"+ col.HeaderText + "'  and ReportName='Inpayment' and UserName='" + Touch_user + "' ", con);
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
                            SqlCommand cmd6 = new SqlCommand("update CustomiseReport set FiledValue='False' where FiledName='"+ col.HeaderText + "' and ReportName='Inpayment' and UserName='" + Touch_user + "' ", con);
                            result = cmd6.ExecuteNonQuery();
                            con.Close();
                            col.Visible = false;
                        }
                    }

                }
            }
        }

        //protected void txtJobid_TextChanged(object sender, EventArgs e)
        //{

        //    txtJobid = (TextBox)GridInPayment.FooterRow.FindControl("txtJobid");

        //    Session["Val"] = txtJobid.Text;
        //    string tt = Session["UserId"].ToString();


        //    string Status = GridInPayment.HeaderRow.Cells[3].Text;
        //    if (this.IsPostBack)
        //    {
        //        txtJobid.Attributes["Value"] = txtJobid.Text;
        //    }
        //    if (txtJobid.Text == null)
        //    {
        //        BindInPayment();
        //    }
        //    else
        //    {


        //        // Label Status = (Label)grdrow.FindControl("JobId");

        //        search(Status, txtJobid.Text, "InHeaderTbl");
        //        //  txtJobid = default(TextBox);

        //        //ViewState["jobid"] = txtJobid.Text;
        //        //  txtJobid.Attributes["value"] = txtJobid.Text;
        //    }
        //    Response.Write(txtJobid.Text);



        //}

        //protected void txtMSGId_TextChanged(object sender, EventArgs e)
        //{


        //    TextBox txtMSGId = (TextBox)GridInPayment.FooterRow.FindControl("txtMSGId");
        //    if (txtMSGId.Text == null)
        //    {
        //        BindInPayment();
        //    }
        //    else
        //    {

        //        string Status = GridInPayment.HeaderRow.Cells[4].Text;
        //        search(Status, txtMSGId.Text, "InHeaderTbl");
        //        txtMSGId.Text = txtMSGId.Text;
        //    }
        //    //Response.Write(txtMSGId.Text);

        //}

        //protected void txtPermitId_TextChanged(object sender, EventArgs e)
        //{
        //    txtPermitId = (TextBox)GridInPayment.FooterRow.FindControl("txtPermitId");
        //    txtPermitId = (TextBox)ViewState["Permit"];
        //    string Status = GridInPayment.HeaderRow.Cells[5].Text;
        //    if (txtPermitId == null)
        //    {
        //        BindInPayment();
        //    }
        //    else
        //    {

        //        search(Status, txtPermitId.Text, "InHeaderTbl");


        //    }


        //}

        //protected void txtTradeNetMailBoxID_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtTradeNetMailBoxID = (TextBox)GridInPayment.FooterRow.FindControl("txtTradeNetMailBoxID");
        //    string Status = GridInPayment.HeaderRow.Cells[6].Text;
        //    search(Status, txtTradeNetMailBoxID.Text, "InHeaderTbl");
        //}

        //protected void txtMessageType_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtMessageType = (TextBox)GridInPayment.FooterRow.FindControl("txtMessageType");
        //    string Status = GridInPayment.HeaderRow.Cells[7].Text;
        //    search(Status, txtMessageType.Text, "InHeaderTbl");
        //}

        //protected void txtDeclarationType_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtDeclarationType = (TextBox)GridInPayment.FooterRow.FindControl("txtDeclarationType");
        //    string Status = GridInPayment.HeaderRow.Cells[8].Text;
        //    search(Status, txtDeclarationType.Text, "InHeaderTbl");
        //}

        //protected void txtCargoPackType_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtCargoPackType = (TextBox)GridInPayment.FooterRow.FindControl("txtCargoPackType");
        //    string Status = GridInPayment.HeaderRow.Cells[9].Text;
        //    search(Status, txtCargoPackType.Text, "InHeaderTbl");
        //}

        //protected void txtInwardTransportMode_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtInwardTransportMode = (TextBox)GridInPayment.FooterRow.FindControl("txtInwardTransportMode");
        //    string Status = GridInPayment.HeaderRow.Cells[10].Text;
        //    search(Status, txtInwardTransportMode.Text, "InHeaderTbl");
        //}

        //protected void txtBGIndicator_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtBGIndicator = (TextBox)GridInPayment.FooterRow.FindControl("txtBGIndicator");
        //    string Status = GridInPayment.HeaderRow.Cells[11].Text;
        //    search(Status, txtBGIndicator.Text, "InHeaderTbl");
        //}

        //protected void txtSupplyIndicator_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtSupplyIndicator = (TextBox)GridInPayment.FooterRow.FindControl("txtSupplyIndicator");
        //    string Status = GridInPayment.HeaderRow.Cells[12].Text;
        //    search(Status, txtSupplyIndicator.Text, "InHeaderTbl");
        //}

        //protected void txtReferenceDocuments_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtReferenceDocuments = (TextBox)GridInPayment.FooterRow.FindControl("txtReferenceDocuments");
        //    string Status = GridInPayment.HeaderRow.Cells[13].Text;
        //    search(Status, txtReferenceDocuments.Text, "InHeaderTbl");
        //}

        //protected void txtLicense_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtLicense = (TextBox)GridInPayment.FooterRow.FindControl("txtLicense");
        //    string Status = GridInPayment.HeaderRow.Cells[14].Text;
        //    search(Status, txtLicense.Text, "InHeaderTbl");
        //}

        //protected void txtRecipient_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtRecipient = (TextBox)GridInPayment.FooterRow.FindControl("txtRecipient");
        //    string Status = GridInPayment.HeaderRow.Cells[15].Text;
        //    search(Status, txtRecipient.Text, "InHeaderTbl");
        //}

        //protected void txtDeclarantCompanyCode_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtDeclarantCompanyCode = (TextBox)GridInPayment.FooterRow.FindControl("txtDeclarantCompanyCode");
        //    string Status = GridInPayment.HeaderRow.Cells[16].Text;
        //    search(Status, txtDeclarantCompanyCode.Text, "InHeaderTbl");
        //}

        //protected void txtImporterCompanyCode_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtImporterCompanyCode = (TextBox)GridInPayment.FooterRow.FindControl("txtImporterCompanyCode");
        //    string Status = GridInPayment.HeaderRow.Cells[17].Text;
        //    search(Status, txtImporterCompanyCode.Text, "InHeaderTbl");
        //}

        //protected void txtInwardCarrierAgentCode_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtInwardCarrierAgentCode = (TextBox)GridInPayment.FooterRow.FindControl("txtInwardCarrierAgentCode");
        //    string Status = GridInPayment.HeaderRow.Cells[18].Text;
        //    search(Status, txtInwardCarrierAgentCode.Text, "InHeaderTbl");
        //}

        //protected void txtFreightForwarderCode_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtFreightForwarderCode = (TextBox)GridInPayment.FooterRow.FindControl("txtFreightForwarderCode");
        //    string Status = GridInPayment.HeaderRow.Cells[19].Text;
        //    search(Status, txtFreightForwarderCode.Text, "InHeaderTbl");
        //}

        //protected void txtClaimantPartyCode_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtClaimantPartyCode = (TextBox)GridInPayment.FooterRow.FindControl("txtClaimantPartyCode");
        //    string Status = GridInPayment.HeaderRow.Cells[20].Text;
        //    search(Status, txtClaimantPartyCode.Text, "InHeaderTbl");
        //}







        //protected void txtArrivalDate_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtArrivalDate = (TextBox)GridInPayment.FooterRow.FindControl("txtArrivalDate");
        //    string Status = GridInPayment.HeaderRow.Cells[21].Text;
        //    search(Status, txtArrivalDate.Text, "InHeaderTbl");

        //}


        ////







        //protected void txtLoadingPortCode_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtLoadingPortCode = (TextBox)GridInPayment.FooterRow.FindControl("txtLoadingPortCode");
        //    string Status = GridInPayment.HeaderRow.Cells[22].Text;
        //    search(Status, txtLoadingPortCode.Text, "InHeaderTbl");
        //}

        //protected void txtVoyageNumber_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtVoyageNumber = (TextBox)GridInPayment.FooterRow.FindControl("txtVoyageNumber");
        //    string Status = GridInPayment.HeaderRow.Cells[23].Text;
        //    search(Status, txtVoyageNumber.Text, "InHeaderTbl");
        //}

        //protected void txtVesselName_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtVesselName = (TextBox)GridInPayment.FooterRow.FindControl("txtVesselName");
        //    string Status = GridInPayment.HeaderRow.Cells[24].Text;
        //    search(Status, txtVesselName.Text, "InHeaderTbl");
        //}

        //protected void txtOceanBillofLadingNo_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtOceanBillofLadingNo = (TextBox)GridInPayment.FooterRow.FindControl("txtOceanBillofLadingNo");
        //    string Status = GridInPayment.HeaderRow.Cells[25].Text;
        //    search(Status, txtOceanBillofLadingNo.Text, "InHeaderTbl");
        //}

        //protected void txtConveyanceRefNo_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtConveyanceRefNo = (TextBox)GridInPayment.FooterRow.FindControl("txtConveyanceRefNo");
        //    string Status = GridInPayment.HeaderRow.Cells[26].Text;
        //    search(Status, txtConveyanceRefNo.Text, "InHeaderTbl");
        //}

        //protected void txtTransportId_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtTransportId = (TextBox)GridInPayment.FooterRow.FindControl("txtTransportId");
        //    string Status = GridInPayment.HeaderRow.Cells[27].Text;
        //    search(Status, txtTransportId.Text, "InHeaderTbl");
        //}

        //protected void txtFlightNO_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtFlightNO = (TextBox)GridInPayment.FooterRow.FindControl("txtFlightNO");
        //    string Status = GridInPayment.HeaderRow.Cells[28].Text;
        //    search(Status, txtFlightNO.Text, "InHeaderTbl");
        //}

        //protected void txtAircraftRegNo_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtAircraftRegNo = (TextBox)GridInPayment.FooterRow.FindControl("txtAircraftRegNo");
        //    string Status = GridInPayment.HeaderRow.Cells[29].Text;
        //    search(Status, txtAircraftRegNo.Text, "InHeaderTbl");
        //}

        //protected void txtMasterAirwayBill_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtMasterAirwayBill = (TextBox)GridInPayment.FooterRow.FindControl("txtMasterAirwayBill");
        //    string Status = GridInPayment.HeaderRow.Cells[30].Text;
        //    search(Status, txtMasterAirwayBill.Text, "InHeaderTbl");
        //}


        //protected void txtReleaseLocation_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtReleaseLocation = (TextBox)GridInPayment.FooterRow.FindControl("txtReleaseLocation");
        //    string Status = GridInPayment.HeaderRow.Cells[31].Text;
        //    search(Status, txtReleaseLocation.Text, "InHeaderTbl");
        //}

        //protected void txtRecepitLocation_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtRecepitLocation = (TextBox)GridInPayment.FooterRow.FindControl("txtRecepitLocation");
        //    string Status = GridInPayment.HeaderRow.Cells[32].Text;
        //    search(Status, txtRecepitLocation.Text, "InHeaderTbl");
        //}



        //protected void txtTotalOuterPack_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtTotalOuterPack = (TextBox)GridInPayment.FooterRow.FindControl("txtTotalOuterPack");
        //    string Status = GridInPayment.HeaderRow.Cells[33].Text;
        //    search(Status, txtTotalOuterPack.Text, "InHeaderTbl");
        //}

        //protected void txtTotalOuterPackUOM_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtTotalOuterPackUOM = (TextBox)GridInPayment.FooterRow.FindControl("txtTotalOuterPackUOM");
        //    string Status = GridInPayment.HeaderRow.Cells[34].Text;
        //    search(Status, txtTotalOuterPackUOM.Text, "InHeaderTbl");
        //}

        //protected void txtTotalGrossWeight_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtTotalGrossWeight = (TextBox)GridInPayment.FooterRow.FindControl("txtTotalGrossWeight");
        //    string Status = GridInPayment.HeaderRow.Cells[35].Text;
        //    search(Status, txtTotalGrossWeight.Text, "InHeaderTbl");
        //}

        //protected void txtTotalGrossWeightUOM_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtTotalGrossWeightUOM = (TextBox)GridInPayment.FooterRow.FindControl("txtTotalGrossWeightUOM");
        //    string Status = GridInPayment.HeaderRow.Cells[36].Text;
        //    search(Status, txtTotalGrossWeightUOM.Text, "InHeaderTbl");
        //}

        //protected void txtGrossReference_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtGrossReference = (TextBox)GridInPayment.FooterRow.FindControl("txtGrossReference");
        //    string Status = GridInPayment.HeaderRow.Cells[37].Text;
        //    search(Status, txtGrossReference.Text, "InHeaderTbl");

        //}

        //protected void txtBlanketStartDate_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtBlanketStartDate = (TextBox)GridInPayment.FooterRow.FindControl("txtBlanketStartDate");
        //    string Status = GridInPayment.HeaderRow.Cells[38].Text;
        //    search(Status, txtBlanketStartDate.Text, "InHeaderTbl");
        //}

        //protected void txtStatus_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtStatus = (TextBox)GridInPayment.FooterRow.FindControl("txtStatus");
        //    string Status = GridInPayment.HeaderRow.Cells[39].Text;
        //    search(Status, txtStatus.Text, "InHeaderTbl");

        //}
        //protected void txtTouchUser_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtTouchUser = (TextBox)GridInPayment.FooterRow.FindControl("txtTouchUser");
        //    string Status = GridInPayment.HeaderRow.Cells[40].Text;
        //    search(Status, txtTouchUser.Text, "InHeaderTbl");
        //}

        //protected void txtTouchTime_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtTouchTime = (TextBox)GridInPayment.FooterRow.FindControl("txtTouchTime");
        //    string Status = GridInPayment.HeaderRow.Cells[41].Text;
        //    search(Status, txtTouchTime.Text, "InHeaderTbl");
        //}



        //protected void txtHAWL_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtHAWL = (TextBox)GridInPayment.FooterRow.FindControl("txtHAWL");
        //    string Status = GridInPayment.HeaderRow.Cells[42].Text;
        //    search(Status, txtHAWL.Text, "ItemDtl");
        //}

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
                    string lodport = "select * from [InHeaderTbl] where Id=" + ID + "";
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
                        LoadCCPPrint(PermID);
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
        private void RefundCcp(string permit)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("select * from InHeaderTbl  where PermitId='" + permit + "'"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            sda.Fill(dt);
                        }
                    }
                }

                DataTable adt = new DataTable();
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("select * from refundvalsummary  where MSGId='" + dt.Rows[0]["MSGId"].ToString() + "'"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            sda.Fill(adt);
                        }
                    }
                }

                DataTable dt1 = new DataTable();
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("select * from InRefund  where MessaheRef='" + dt.Rows[0]["MSGId"].ToString() + "'"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            sda.Fill(dt1);
                        }
                    }
                }

                DataTable dt2 = new DataTable();
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("select * from DeclarantCompany  where Code='" + dt.Rows[0]["DeclarantCompanyCode"].ToString() + "'"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            sda.Fill(dt2);
                        }
                    }
                }

                int linecount = 0;
                string path = @"C:\Users\Public\NEW-Files";
                string filename = path + "\\RefundCcp" + dt.Rows[0]["MSGId"].ToString() + ".pdf";

                //Create new PDF document 

                PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create, FileAccess.ReadWrite));
                //Barcode genarate
                Response.ContentType = "application/pdf";
                PdfWriter writer = PdfWriter.GetInstance(
                  document, Response.OutputStream
                );
                document.Open();

                BaseFont bfTimes = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1257, false);
                iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 10, iTextSharp.text.Font.NORMAL);

                BaseFont bfTimes1 = BaseFont.CreateFont(BaseFont.COURIER_BOLD, BaseFont.CP1257, false);
                iTextSharp.text.Font timesBold = new iTextSharp.text.Font(bfTimes1, 10, iTextSharp.text.Font.NORMAL);

                string perName = "REFUND NO";
                space = ""; space1 = "";
                sapceval = 0; spceval1 = 0;
                sapceval = perName.Length;
                spceval1 = 40 - sapceval;
                for (int i = 0; i < 40; i++)
                {
                    space = space + " ";
                }

                string strtest2 = "REPLACEMENT PERMIT NO ";
                sapceval = 0; spceval1 = 0;
                sapceval = strtest2.Length;
                spceval1 = sapceval - perName.Length;
                for (int i = 0; i < spceval1; i++)
                {
                    space1 = space1 + " ";
                }
                perName = space + perName + space1 + ": ";

                Chunk c11 = new Chunk(perName + "", times);
                Phrase t12 = new Phrase(c11);
                Chunk c1 = new Chunk(dt1.Rows[0]["RefundRefNo"].ToString() + "", timesBold);
                Phrase t2 = new Phrase(c1);

                iTextSharp.text.Paragraph blnk1 = new iTextSharp.text.Paragraph();
                blnk1.Alignment = Element.ALIGN_LEFT;
                blnk1.Add(t12);
                blnk1.Add(t2);
                blnk1.SetLeading(0.0f, 1.2f);
                document.Add(blnk1);
                linecount = linecount + 1;


                perName = "REPLACEMENT PERMIT NO : ";
                space = ""; space1 = "";
                sapceval = 0; spceval1 = 0;
                sapceval = perName.Length;
                spceval1 = 40 - sapceval;
                for (int i = 0; i < 40; i++)
                {
                    space = space + " ";
                }
                perName = space + perName;

                blnk1 = new iTextSharp.text.Paragraph(perName, times);
                blnk1.Alignment = Element.ALIGN_LEFT;
                blnk1.SetLeading(0.0f, 1.2f);
                document.Add(blnk1);
                linecount = linecount + 1;

                string blnkvalu = "        ";
                blnk1 = new iTextSharp.text.Paragraph(blnkvalu, times);
                blnk1.Alignment = Element.ALIGN_LEFT;
                blnk1.SetLeading(0.0f, 1.2f);
                document.Add(blnk1);
                linecount = linecount + 1;

                blnkvalu = "        ";
                blnk1 = new iTextSharp.text.Paragraph(blnkvalu, times);
                blnk1.Alignment = Element.ALIGN_LEFT;
                blnk1.SetLeading(0.0f, 1.2f);
                document.Add(blnk1);
                linecount = linecount + 1;

                blnkvalu = "        ";
                blnk1 = new iTextSharp.text.Paragraph(blnkvalu, times);
                blnk1.Alignment = Element.ALIGN_LEFT;
                blnk1.SetLeading(0.0f, 1.2f);
                document.Add(blnk1);
                linecount = linecount + 1;

                blnkvalu = "        ";
                blnk1 = new iTextSharp.text.Paragraph(blnkvalu, times);
                blnk1.Alignment = Element.ALIGN_LEFT;
                blnk1.SetLeading(0.0f, 1.2f);
                document.Add(blnk1);
                linecount = linecount + 1;

                space1 = "";
                strtest2 = "REFUND INFORMATION";
                sapceval = 0; spceval1 = 0;
                sapceval = strtest2.Length;
                spceval1 = sapceval - perName.Length;
                for (int i = 0; i < 24; i++)
                {
                    space1 = space1 + " ";
                }
                blnkvalu = space1 + "REFUND INFORMATION";
                blnk1 = new iTextSharp.text.Paragraph(blnkvalu, times);
                blnk1.Alignment = Element.ALIGN_LEFT;
                blnk1.SetLeading(0.0f, 1.2f);
                document.Add(blnk1);
                linecount = linecount + 1;

                blnkvalu = "        ";
                blnk1 = new iTextSharp.text.Paragraph(blnkvalu, times);
                blnk1.Alignment = Element.ALIGN_LEFT;
                blnk1.SetLeading(0.0f, 1.2f);
                document.Add(blnk1);
                linecount = linecount + 1;

                blnkvalu = "NAME OF COMPANY: " + dt2.Rows[0]["Name"].ToString();
                blnk1 = new iTextSharp.text.Paragraph(blnkvalu, times);
                blnk1.Alignment = Element.ALIGN_LEFT;
                blnk1.SetLeading(0.0f, 1.2f);
                document.Add(blnk1);
                linecount = linecount + 1;

                blnkvalu = "        ";
                blnk1 = new iTextSharp.text.Paragraph(blnkvalu, times);
                blnk1.Alignment = Element.ALIGN_LEFT;
                blnk1.SetLeading(0.0f, 1.2f);
                document.Add(blnk1);
                linecount = linecount + 1;

                blnkvalu = "DECLARANT NAME : " + dt2.Rows[0]["DeclarantName"].ToString();
                blnk1 = new iTextSharp.text.Paragraph(blnkvalu, times);
                blnk1.Alignment = Element.ALIGN_LEFT;
                blnk1.SetLeading(0.0f, 1.2f);
                document.Add(blnk1);
                linecount = linecount + 1;

                blnkvalu = "     ";
                blnk1 = new iTextSharp.text.Paragraph(blnkvalu, times);
                blnk1.Alignment = Element.ALIGN_LEFT;
                blnk1.SetLeading(0.0f, 1.2f);
                document.Add(blnk1);
                linecount = linecount + 1;

                string res = dt2.Rows[0]["DeclarantCode"].ToString().Substring(dt2.Rows[0]["DeclarantCode"].ToString().Length - 5);
                strtest2 = "TEL NO";
                space1 = "";
                sapceval = 0; spceval1 = 0;
                sapceval = dt2.Rows[0]["DeclarantCode"].ToString().Length;
                spceval1 = dt2.Rows[0]["DeclarantCode"].ToString().Length - res.Length;
                for (int i = 0; i < spceval1; i++)
                {
                    res = "X" + res;
                }
                blnkvalu = "DECLARANT CODE : " + res;
                blnk1 = new iTextSharp.text.Paragraph(blnkvalu, times);
                blnk1.Alignment = Element.ALIGN_LEFT;
                blnk1.SetLeading(0.0f, 1.2f);
                document.Add(blnk1);
                linecount = linecount + 1;

                strtest2 = "TEL NO";
                space1 = "";
                sapceval = 0; spceval1 = 0;
                sapceval = strtest2.Length;
                spceval1 = 15 - sapceval;
                for (int i = 0; i < spceval1; i++)
                {
                    space1 = space1 + " ";
                }
                blnkvalu = "TEL NO" + space1 + ": " + dt2.Rows[0]["DeclarantTel"].ToString();
                blnk1 = new iTextSharp.text.Paragraph(blnkvalu, times);
                blnk1.Alignment = Element.ALIGN_LEFT;
                blnk1.SetLeading(0.0f, 1.2f);
                document.Add(blnk1);
                linecount = linecount + 1;

                strtest2 = "DATE OF APPROVAL";
                space1 = "";
                sapceval = 0; spceval1 = 0;
                sapceval = strtest2.Length;
                spceval1 = 23 - sapceval;
                for (int i = 0; i < spceval1; i++)
                {
                    space1 = space1 + " ";
                }
                string date = Convert.ToDateTime(dt1.Rows[0]["AppDate"].ToString()).ToString("dd/MM/yyyy");
                blnkvalu = "DATE OF APPROVAL" + space1 + ": " + date;
                blnk1 = new iTextSharp.text.Paragraph(blnkvalu, times);
                blnk1.Alignment = Element.ALIGN_LEFT;
                blnk1.SetLeading(0.0f, 1.2f);
                document.Add(blnk1);
                linecount = linecount + 1;

                string linecode = "";
                for (int i = 1; i <= 80; i++)
                {
                    linecode = linecode + "-";
                }

                iTextSharp.text.Paragraph Line = new iTextSharp.text.Paragraph(linecode, times);
                Line.SetLeading(0.0f, 1.2f);
                document.Add(Line);
                linecount = linecount + 1;

                blnkvalu = "        ";
                blnk1 = new iTextSharp.text.Paragraph(blnkvalu, times);
                blnk1.Alignment = Element.ALIGN_LEFT;
                blnk1.SetLeading(0.0f, 1.2f);
                document.Add(blnk1);
                linecount = linecount + 1;

                blnkvalu = "        ";
                blnk1 = new iTextSharp.text.Paragraph(blnkvalu, times);
                blnk1.Alignment = Element.ALIGN_LEFT;
                blnk1.SetLeading(0.0f, 1.2f);
                document.Add(blnk1);
                linecount = linecount + 1;

                blnkvalu = "TOTAL";
                blnk1 = new iTextSharp.text.Paragraph(blnkvalu, times);
                blnk1.Alignment = Element.ALIGN_LEFT;
                blnk1.SetLeading(0.0f, 1.2f);
                document.Add(blnk1);
                linecount = linecount + 1;

                Line = new iTextSharp.text.Paragraph(linecode, times);
                Line.SetLeading(0.0f, 1.2f);
                document.Add(Line);
                linecount = linecount + 1;

                space1 = "";
                sapceval = 0; spceval1 = 0;
                sapceval = strtest2.Length;
                spceval1 = 23 - sapceval;
                for (int i = 0; i < 4; i++)
                {
                    space1 = space1 + " ";
                }

                blnkvalu = "REFUND AMOUNT FOR" + space1 + "REFUND AMOUNT FOR" + space1 + "REFUND AMOUNT FOR" + space1 + "REFUND AMOUNT FOR";
                blnk1 = new iTextSharp.text.Paragraph(blnkvalu, times);
                blnk1.Alignment = Element.ALIGN_LEFT;
                blnk1.SetLeading(0.0f, 1.2f);
                document.Add(blnk1);
                linecount = linecount + 1;

                strtest2 = "REFUND AMOUNT FOR";
                string strtest1 = "CUSTOMS DUTY (S$)";
                space1 = "";
                sapceval = 0; spceval1 = 0;
                sapceval = strtest2.Length + 4;
                spceval1 = sapceval - strtest1.Length;
                for (int i = 0; i < spceval1; i++)
                {
                    space1 = space1 + " ";
                }

                strtest2 = "REFUND AMOUNT FOR";
                strtest1 = "EXCISE DUTY (S$)";
                string space2 = "";
                sapceval = 0; spceval1 = 0;
                sapceval = strtest2.Length + 4;
                spceval1 = sapceval - strtest1.Length;
                for (int i = 0; i < spceval1; i++)
                {
                    space2 = space2 + " ";
                }

                strtest2 = "REFUND AMOUNT FOR";
                strtest1 = "OTHER TAX (S$)";
                string space3 = "";
                sapceval = 0; spceval1 = 0;
                sapceval = strtest2.Length + 4;
                spceval1 = sapceval - strtest1.Length;
                for (int i = 0; i < spceval1; i++)
                {
                    space3 = space3 + " ";
                }

                blnkvalu = "CUSTOMS DUTY (S$)" + space1 + "EXCISE DUTY (S$)" + space2 + "OTHER TAX (S$)" + space3 + "GST (S$)";
                blnk1 = new iTextSharp.text.Paragraph(blnkvalu, times);
                blnk1.Alignment = Element.ALIGN_LEFT;
                blnk1.SetLeading(0.0f, 1.2f);
                document.Add(blnk1);
                linecount = linecount + 1;

                strtest2 = "REFUND AMOUNT FOR";
                strtest1 = dt.Rows[0]["TotalCusDutyAmt"].ToString();
                space1 = "";
                sapceval = 0; spceval1 = 0;
                sapceval = strtest2.Length - 1;
                spceval1 = sapceval - strtest1.Length;
                for (int i = 0; i < spceval1; i++)
                {
                    space1 = space1 + " ";
                }

                strtest2 = " REFUND AMOUNT FOR";
                strtest1 = dt.Rows[0]["TotalExDutyAmt"].ToString();
                space2 = "";
                sapceval = 0; spceval1 = 0;
                sapceval = strtest2.Length - 1;
                spceval1 = sapceval - strtest1.Length;
                for (int i = 0; i < spceval1; i++)
                {
                    space2 = space2 + " ";
                }

                strtest2 = " REFUND AMOUNT FOR";
                strtest1 = dt.Rows[0]["TotalODutyAmt"].ToString();
                space3 = "";
                sapceval = 0; spceval1 = 0;
                sapceval = strtest2.Length - 1;
                spceval1 = sapceval - strtest1.Length;
                for (int i = 0; i < spceval1; i++)
                {
                    space3 = space3 + " ";
                }

                strtest2 = "REFUND AMOUNT FOR";
                strtest1 = dt.Rows[0]["TotalAmtPay"].ToString();
                string space4 = "";
                sapceval = 0; spceval1 = 0;
                sapceval = strtest2.Length - 1;
                spceval1 = sapceval - strtest1.Length;
                for (int i = 0; i < spceval1; i++)
                {
                    space4 = space4 + " ";
                }

                Line = new iTextSharp.text.Paragraph(linecode, times);
                Line.SetLeading(0.0f, 1.2f);
                document.Add(Line);
                linecount = linecount + 1;

                blnkvalu = space1 + adt.Rows[0]["txtcusdutyAmt"].ToString() + "    " + space2 + adt.Rows[0]["totalexciseAmt"].ToString() + "    " + space3 + adt.Rows[0]["txtotherAmt"].ToString() + "    " + space1 + adt.Rows[0]["totalgstAmt"].ToString();
                blnk1 = new iTextSharp.text.Paragraph(blnkvalu, times);
                blnk1.Alignment = Element.ALIGN_LEFT;
                blnk1.SetLeading(0.0f, 1.2f);
                document.Add(blnk1);
                linecount = linecount + 1;

                blnkvalu = "   ";
                blnk1 = new iTextSharp.text.Paragraph(blnkvalu, times);
                blnk1.Alignment = Element.ALIGN_LEFT;
                blnk1.SetLeading(0.0f, 1.2f);
                document.Add(blnk1);
                linecount = linecount + 1;

                blnkvalu = "REASON FOR REFUND";
                blnk1 = new iTextSharp.text.Paragraph(blnkvalu, times);
                blnk1.Alignment = Element.ALIGN_LEFT;
                blnk1.SetLeading(0.0f, 1.2f);
                document.Add(blnk1);
                linecount = linecount + 1;

                string cnstr = "";
                cnstr = dt1.Rows[0]["ReasonCode"].ToString();
                for (int k = 0; cnstr.Length < 4; k++)
                {
                    cnstr = cnstr + " ";
                }
                int partLength = 70;
                string sentence = dt1.Rows[0]["ReasonDes"].ToString();
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
                for (int j = 0; j < lines.Count; j++)
                {
                    cnstr = "";
                    cnstr = dt1.Rows[0]["ReasonCode"].ToString();
                    for (int k = 0; cnstr.Length < 10; k++)
                    {
                        cnstr = cnstr + " ";
                    }
                    Chunk cc1 = new Chunk(cnstr + lines[j].ToString() + "", times);
                    Phrase tt2 = new Phrase(cc1);
                    iTextSharp.text.Paragraph ao1 = new iTextSharp.text.Paragraph();
                    //if (j == 0)
                    //{
                    //    ao1.Add(tt1);
                    //}
                    ao1.Add(tt2);
                    ao1.Alignment = Element.ALIGN_LEFT;
                    ao1.SetLeading(0.0f, 1.0f);
                    document.Add(ao1);
                }


                blnkvalu = "     ";
                blnk1 = new iTextSharp.text.Paragraph(blnkvalu, times);
                blnk1.Alignment = Element.ALIGN_LEFT;
                blnk1.SetLeading(0.0f, 1.2f);
                document.Add(blnk1);
                linecount = linecount + 1;

                blnkvalu = "REFUND MESSAGE";
                blnk1 = new iTextSharp.text.Paragraph(blnkvalu, times);
                blnk1.Alignment = Element.ALIGN_LEFT;
                blnk1.SetLeading(0.0f, 1.2f);
                document.Add(blnk1);
                linecount = linecount + 1;

                foreach (DataRow dr in dt1.Rows)
                {
                    cnstr = "";
                    cnstr = dr["ReasonConditionCode"].ToString();
                    for (int k = 0; cnstr.Length < 4; k++)
                    {
                        cnstr = cnstr + " ";
                    }
                    partLength = 78;
                    sentence = cnstr + " " + " - " + dr["ReasonConDes"].ToString();
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
                    for (int j = 0; j < lines.Count; j++)
                    {
                        Chunk t1 = null;
                        Phrase tt1 = null;
                        if (j == 0)
                        {
                            cnstr = "";
                            cnstr = dr["ReasonConditionCode"].ToString();
                            for (int k = 0; cnstr.Length < 4; k++)
                            {
                                cnstr = cnstr + " ";
                            }
                            t1 = new Chunk(cnstr + " ", timesBold);
                            tt1 = new Phrase(t1);
                            if (dr["ReasonConditionCode"].ToString().Length == 2)
                            {
                                lines[j] = lines[j].ToString().Substring(3);
                            }
                            else
                            {
                                if (dr["ReasonConditionCode"].ToString().Length == 4)
                                {
                                    lines[j] = lines[j].ToString().Substring(5);
                                }
                                else
                                {
                                    lines[j] = lines[j].ToString().Substring(4);
                                }
                            }
                        }
                        Chunk cc1 = new Chunk(lines[j].ToString() + "", times);
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
                    }
                }

                for (int i = linecount; i <= 60; i++)
                {
                    blnkvalu = "       ";
                    blnk1 = new iTextSharp.text.Paragraph(blnkvalu, times);
                    blnk1.Alignment = Element.ALIGN_LEFT;
                    blnk1.SetLeading(0.0f, 1.2f);
                    document.Add(blnk1);
                    linecount = linecount + 1;
                }


                Line = new iTextSharp.text.Paragraph(linecode, times);
                Line.SetLeading(0.0f, 1.2f);
                document.Add(Line);
                linecount = linecount + 1;

                string msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                string page335 = "UNIQUE REF : 201834618Z " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                blnkvalu = "UNIQUE REF : ";
                blnk1 = new iTextSharp.text.Paragraph(page335, times);
                blnk1.Alignment = Element.ALIGN_LEFT;
                blnk1.SetLeading(0.0f, 1.2f);
                document.Add(blnk1);
                linecount = linecount + 1;

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
                                ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_RIGHT, new Phrase("PG  : " + i.ToString() + " OF " + pages, times), 541f, 742f, 0);
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
            catch (Exception ex)
            {

            }
        }
        private void LoadCCPPrint(string permit)
        {
            string type = "", tableName = "";
            string comNamedec = "", Decname = "", unicref = "", telphn = "", deccode = "";
            type = "IN-Non-Payment";
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from InHeaderTbl  where PermitId='" + permit + "' "))
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
            string path = Server.MapPath("PDF-Files");
            //string path = @"C:\Users\Public\PDF-Files";
            //string filename = path + "\\" + dt.Rows[0]["PermitNumber"].ToString() + "CCCp.pdf";
            string filename = path + "\\" + dt.Rows[0]["PermitNumber"].ToString() + "CCCp.pdf";

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
                pernum = dt.Rows[0]["PermitNumber"].ToString().ToUpper();
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
                    comNamedec = objdec.dr["Name"].ToString().ToUpper();
                    Decname = objdec.dr["DeclarantName"].ToString().ToUpper();
                    unicref = objdec.dr["CRUEI"].ToString().ToUpper();
                    telphn = objdec.dr["DeclarantTel"].ToString().ToUpper();
                    deccode = objdec.dr["DeclarantCode"].ToString().ToUpper();
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
                msgtype = "MESSAGE TYPE      : IN-PAYMENT UPDATED PERMIT";
            }
            else
            {
                msgtype = "MESSAGE TYPE      : IN-PAYMENT PERMIT";
            }


            iTextSharp.text.Paragraph msgty = new iTextSharp.text.Paragraph(msgtype, times);
            msgty.Alignment = Element.ALIGN_LEFT;
            msgty.SetLeading(0.0f, 1.0f);
            document.Add(msgty);
            linecount = linecount + 1;

            string[] decltype = dt.Rows[0]["DeclarationType"].ToString().Split(':');
            string dectype = "DECLARATION TYPE  :" + decltype[1].ToString().ToUpper() + "";
            if (decltype[1].ToString().ToUpper() == " Blanket ".ToUpper())
            {
                dectype = "DECLARATION TYPE  : Blanket (including blanket GST payment and duty exemption)".ToUpper();
            }
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

            string Validate = "", Validate1 = "";
            string datechk = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4).ToString();
            //string[] str = dt.Rows[0]["MSGId"].ToString().Substring(0,dt.Rows[0]["MSGId"].ToString().Length-4).ToString();
            //var chkdt = DateTime.ParseExact(datechk, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //Validate = chkdt.ToString("dd/MM/yyyy");
            MyClass prmtdt = new MyClass();
            prmtdt.dr = prmtdt.ret_dr("select * from InPMT where PermitNumber='" + dt.Rows[0]["PermitNumber"].ToString() + "'");
            if (prmtdt.dr.HasRows)
            {
                while (prmtdt.dr.Read())
                {
                    Validate = Convert.ToDateTime(prmtdt.dr["StartDate"].ToString()).ToString("dd/MM/yyyy");
                    Validate1 = Convert.ToDateTime(prmtdt.dr["EndDate"].ToString()).ToString("dd/MM/yyyy");
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
            string impname = "IMPORTER:                            VALIDITY PERIOD" + space + ": " + validityfrom + " -             ";
            iTextSharp.text.Paragraph a1 = new iTextSharp.text.Paragraph(impname, times);
            a1.Alignment = Element.ALIGN_LEFT;
            a1.SetLeading(0.0f, 1.0f);
            document.Add(a1);
            linecount = linecount + 1;
            string imptrname = "", impname1 = "", impceui = "";
            string impget = "Select * from Importer where Code='" + dt.Rows[0]["ImporterCompanyCode"].ToString() + "'";
            obj.dr = obj.ret_dr(impget);
            if (obj.dr.HasRows)
            {
                while (obj.dr.Read())
                {
                    imptrname = obj.dr["Name"].ToString().ToUpper();
                    impname1 = obj.dr["Name1"].ToString().ToUpper();
                    impceui = obj.dr["CRUEI"].ToString().ToUpper();
                }
            }

            //impname1 = "                                   ";


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
                amddate.dr = prmtdt.ret_dr("select * from amndtbl where MSGId='" + dt.Rows[0]["MSGId"].ToString() + "' and DecType='IPTDEC'");
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
            if (dt.Rows[0]["TotalGrossWeightUOM"].ToString()=="KGM")
            {
                 TtlPGW = Convert.ToDecimal(dt.Rows[0]["TotalGrossWeight"].ToString()) ;
            }
            else
            {
                 TtlPGW = Convert.ToDecimal(dt.Rows[0]["TotalGrossWeight"].ToString()) / Convert.ToDecimal(1000);
            }

                



            string strtest2 = Math.Round(Convert.ToDecimal(TtlPGW), 2).ToString("0.000");
            sapceval = 0; spceval1 = 0;
            sapceval = strtest2.Length;
            spceval1 = 15 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space1 = space1 + " ";
            }


            string impnam3 = "" + impceui + "" + space + "TOTAL GROSS WT/UNIT  :  " + space1 + "" + strtest2 + "/" + dt.Rows[0]["TotalGrossWeightUOM"].ToString().ToUpper() + "";
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

            string impnam4 = "EXPORTER:" + space + "TOTAL OUTER PACK/UNIT:  " + space1 + "" + dt.Rows[0]["TotalOuterPack"].ToString() + "/" + dt.Rows[0]["TotalOuterPackUOM"].ToString().ToUpper() + "       ";
            iTextSharp.text.Paragraph a5 = new iTextSharp.text.Paragraph(impnam4, times);
            a5.Alignment = Element.ALIGN_LEFT;
            a5.SetLeading(0.0f, 1.0f);
            document.Add(a5);
            linecount = linecount + 1;



            string Exptrname = "", Expname1 = "", Expceui = "";
            //string Exppget = "Select * from Exporter where Code='" + dt.Rows[0]["ExporterCompanyCode"].ToString() + "'";
            //obj.dr = obj.ret_dr(Exppget);
            //if (obj.dr.HasRows)
            //{
            //    while (obj.dr.Read())
            //    {
            //        Exptrname = obj.dr["Name"].ToString();
            //        Expname1 = obj.dr["Name1"].ToString();
            //        Expceui = obj.dr["CRUEI"].ToString();
            //    }
            //}
            if (string.IsNullOrWhiteSpace(Exptrname))
            {
                Exptrname = " ";
            }
            if (string.IsNullOrWhiteSpace(Expname1))
            {
                Expname1 = " ";
            }
            if (string.IsNullOrWhiteSpace(Expceui))
            {
                Expceui = " ";
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
                transidval = dt.Rows[0]["VesselName"].ToString().ToUpper();
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
                conveno = dt.Rows[0]["VoyageNumber"].ToString();
                mastebill = dt.Rows[0]["OceanBillofLadingNo"].ToString().ToUpper();
            }
            else
            {
                conveno = dt.Rows[0]["ConveyanceRefNo"].ToString().ToUpper();
                mastebill = "";
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

            string lodportName = "";
            MyClass lodobj = new MyClass();
            string lodport = "Select * from LoadingPort where PortCode='" + dt.Rows[0]["LoadingPortCode"].ToString().ToUpper() + "'";
            lodobj.dr = lodobj.ret_dr(lodport);
            if (lodobj.dr.HasRows)
            {
                while (lodobj.dr.Read())
                {
                    lodportName = lodobj.dr["PortName"].ToString().ToUpper();
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




            string Portdischarge = " ";
            MyClass Portobj = new MyClass();
            //string loddisport = "Select * from LoadingPort where PortCode='" + dt.Rows[0]["DischargePort"].ToString() + "'";
            //Portobj.dr = Portobj.ret_dr(loddisport);
            //if (Portobj.dr.HasRows)
            //{
            //    while (Portobj.dr.Read())
            //    {
            //        Portdischarge = Portobj.dr["PortName"].ToString();
            //    }
            //}

            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = Portdischarge.Length;
            spceval1 = 36 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }
            string ddate = "";
            ddate = Convert.ToDateTime(dt.Rows[0]["ArrivalDate"].ToString()).ToString("dd/MM/yyyy");
            if (ddate == "01/01/1900")
            {
                ddate = "";
            }
            string impna16 = "" + Portdischarge + " " + space + "ARRIVAL DATE         : " + ddate + "";
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

            string FianlDis = " ";
            //if (dt.Rows[0]["FinalDestinationCountry"].ToString() != "--Select--")
            //{
            //    string[] ss = dt.Rows[0]["FinalDestinationCountry"].ToString().Split(':');

            //    string finaldischarge = ss[1].ToString();
            //    FianlDis = finaldischarge.Substring(1);
            //}
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
            sapceval = handl.Length;
            spceval1 = 52 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }
            //string impna18 = "" + FianlDis + "    " + space + "     " + dt.Rows[0]["OutVesselName"].ToString() + "   ";
            string impna18 = " ";
            iTextSharp.text.Paragraph c1 = new iTextSharp.text.Paragraph(impna18, times);
            c1.Alignment = Element.ALIGN_LEFT;
            c1.SetLeading(0.0f, 1.0f);
            document.Add(c1);
            linecount = linecount + 1;

            conveno = " "; mastebill = " ";
            //if (dt.Rows[0]["OutwardTransportMode"].ToString() == "4 : Air")
            //{
            //    conveno = dt.Rows[0]["OutFlightNO"].ToString();
            //    mastebill = dt.Rows[0]["OutMasterAirwayBill"].ToString();
            //}
            //else if (dt.Rows[0]["OutwardTransportMode"].ToString() == "1 : Sea")
            //{
            //    conveno = dt.Rows[0]["OutVoyageNumber"].ToString();
            //    mastebill = dt.Rows[0]["OutOceanBillofLadingNo"].ToString();
            //}
            //else
            //{
            //    conveno = dt.Rows[0]["OutConveyanceRefNo"].ToString();
            //    mastebill = dt.Rows[0]["OutTransportId"].ToString();
            //}
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
            //string voyageno = dt.Rows[0]["OutVoyageNumber"].ToString();
            string impna19 = "INWARD CARRIER AGENT:" + space + "CONVEYANCE REFERENCE NO: " + conveno.ToUpper() + "";
            iTextSharp.text.Paragraph c2 = new iTextSharp.text.Paragraph(impna19, times);
            c2.Alignment = Element.ALIGN_LEFT;
            c2.SetLeading(0.0f, 1.0f);
            document.Add(c2);
            linecount = linecount + 1;

            string inwName = "", inwName1 = "", inwCUIE = "";
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
                        inwName = lines[lines.Count - 1].ToString().ToUpper();
                        inwName1 = " ";
                        inwCUIE = "  ";
                    }
                    else if (lines.Count == 2)
                    {
                        inwName = lines[0].ToString().ToUpper();
                        inwName1 = lines[1].ToString().ToUpper();
                        inwCUIE = "  ";
                    }
                    else if (lines.Count == 3)
                    {
                        inwName = lines[0].ToString().ToUpper();
                        inwName1 = lines[1].ToString().ToUpper();
                        inwCUIE = lines[2].ToString().ToUpper();
                    }
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
            string impna21 = "" + inwName1 + "" + space + "" + mastebill.ToUpper() + "   ";

            iTextSharp.text.Paragraph c4 = new iTextSharp.text.Paragraph(impna21, times);
            c4.Alignment = Element.ALIGN_LEFT;
            c4.SetLeading(0.0f, 1.0f);
            document.Add(c4);
            linecount = linecount + 1;

            handl = "INWARD CARRIER AGENT:";
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = inwCUIE.Length;
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
            ddate = "";
            if (dt.Rows[0]["DeclarationType"].ToString() == "REX : FOR RE-EXPORT")
            {
                ddate = Convert.ToDateTime(dt.Rows[0]["DepartureDate"].ToString()).ToString("dd/MM/yyyy");
            }

            string impna22 = "" + inwCUIE + "" + space + "DEPARTURE DATE       :" + ddate + "";
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

            string OutName = "", OutName1 = "", OutCIEU = "";
            //MyClass Outobj = new MyClass();
            //string Outqury = "Select * from InnonOutwardCarrierAgent where Code='" + dt.Rows[0]["OutwardCarrierAgentCode"].ToString() + "'";
            //Outobj.dr = Outobj.ret_dr(Outqury);
            //if (Outobj.dr.HasRows)
            //{
            //    while (Outobj.dr.Read())
            //    {
            //        OutName = Outobj.dr["Name"].ToString();
            //        OutName1 = Outobj.dr["Name1"].ToString();
            //        OutCIEU = Outobj.dr["CRUEI"].ToString();
            //    }
            //}
            if (string.IsNullOrWhiteSpace(OutName))
            {
                OutName = " ";
            }
            if (string.IsNullOrWhiteSpace(OutName1))
            {
                OutName1 = " ";
            }
            if (string.IsNullOrWhiteSpace(OutCIEU))
            {
                OutCIEU = " ";
            }
            space = ""; space1 = "";
            sapceval = 0; spceval1 = 0;
            sapceval = OutName.Length;
            spceval1 = 37 - sapceval;
            for (int i = 0; i < spceval1; i++)
            {
                space = space + " ";
            }
            string impna25 = "" + OutName + "" + space + "CERTIFICATE NO:";
            iTextSharp.text.Paragraph c8 = new iTextSharp.text.Paragraph(impna25, times);
            c8.Alignment = Element.ALIGN_LEFT;
            c8.SetLeading(0.0f, 1.0f);
            document.Add(c8);
            linecount = linecount + 1;

            string impna26 = "" + OutName1 + "";
            iTextSharp.text.Paragraph c9 = new iTextSharp.text.Paragraph(impna26, times);
            c9.Alignment = Element.ALIGN_LEFT;
            c9.SetLeading(0.0f, 1.0f);
            document.Add(c9);
            linecount = linecount + 1;

            string impna26p = "" + OutCIEU + "";
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
            rectName = dt.Rows[0]["RecepitLocName"].ToString();
            string receploc = "Select * from ReceiptLocation where Code='" + dt.Rows[0]["RecepitLocation"].ToString() + "'";
            obj.dr = obj.ret_dr(receploc);
            if (obj.dr.HasRows)
            {
                while (obj.dr.Read())
                {
                    if (string.IsNullOrWhiteSpace(rectName))
                    {
                        rectName = obj.dr["Description"].ToString().ToUpper();
                    }
                }
            }

            string relseName = "";
            relseName = dt.Rows[0]["ReleaseLocName"].ToString().ToUpper();
            string relseloc = "Select * from ReleaseLocation where Code='" + dt.Rows[0]["ReleaseLocation"].ToString() + "'";
            obj.dr = obj.ret_dr(relseloc);
            if (obj.dr.HasRows)
            {
                while (obj.dr.Read())
                {
                    if (string.IsNullOrWhiteSpace(relseName))
                    {
                        relseName = obj.dr["Description"].ToString().ToUpper();
                    }
                }
            }

            int partLengthp = 32;
            string sentencep = rectName;
            sentencep = sentencep.Replace("\n", " ");
            List<string> linesp =
                sentencep
                    .Split(' ')
                    .Aggregate(new[] { "" }.ToList(), (a, x) =>
                    {
                        var last = a[a.Count - 1];
                        if ((last + " " + x).Length > partLengthp)
                        {
                            a.Add(x);
                        }
                        else
                        {
                            a[a.Count - 1] = (last + " " + x).Trim();
                        }
                        return a;
                    });

            for (int i = 0; i < linesp.Count; i++)
            {
                if (i != 0)
                {
                    relseName = "";
                }
                handl = "PLACE OF RELEASE:";
                space = ""; space1 = "";
                sapceval = 0; spceval1 = 0;
                sapceval = relseName.Length;
                spceval1 = 37 - sapceval;
                for (int j = 0; j < spceval1; j++)
                {
                    space = space + " ";
                }
                string impna28 = "" + relseName.ToUpper() + "" + space + "" + linesp[i].ToString().ToUpper() + "";
                iTextSharp.text.Paragraph d2 = new iTextSharp.text.Paragraph(impna28, times);
                d2.Alignment = Element.ALIGN_LEFT;
                d2.SetLeading(0.0f, 1.0f);
                document.Add(d2);
                linecount = linecount + 1;
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



            string aeoName = "", cwcName = "", cnbName = "";
            string cpcQury = "Select * from CPCDtl where PermitId='" + dt.Rows[0]["PermitId"].ToString() + "'";
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
                    else if (obj.dr["CPCType"].ToString() == "CNB")
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
                    LicNo1 = LicVal[li].ToString().ToUpper();
                }
                else if (li == 1)
                {
                    LicNo2 = LicVal[li].ToString().ToUpper();
                }
                else if (li == 2)
                {
                    LicNo3 = LicVal[li].ToString().ToUpper();
                }
                else if (li == 3)
                {
                    LicNo4 = LicVal[li].ToString().ToUpper();
                }
                else if (li == 4)
                {
                    LicNo5 = LicVal[li].ToString().ToUpper();
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
            string impna39 = "" + LicNo2 + "" + space + "" + cwcName.ToUpper() + "";
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
            string impna41 = "" + LicNo4 + "" + space + "";
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
            string impna30 = "" + LicNo5 + "" + space + "         ";
            iTextSharp.text.Paragraph d4 = new iTextSharp.text.Paragraph(impna30, times);
            d4.Alignment = Element.ALIGN_LEFT;
            d4.SetLeading(0.0f, 1.0f);
            document.Add(d4);
            linecount = linecount + 1;
            lineheight = 540;
            for (int i = linecount; i <= 73; i++)
            {
                if (pgheight - 142 > lineheight)
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
            //if (linecount == 73)
            //{
            Line.Alignment = Element.ALIGN_LEFT;
            Line.SetLeading(0.0f, 1.0f);
            //document.Add(Line);

            //document.Add(new Paragraph("\n"));

            iTextSharp.text.Paragraph l3 = new iTextSharp.text.Paragraph(impna43, times);
            l3.Alignment = Element.ALIGN_LEFT;
            l3.SetLeading(0.0f, 1.0f);
            //document.Add(l3);
            //if (!string.IsNullOrWhiteSpace(data))
            //{
            //     BlankSapce1(1);
            //}
            //else
            //{
            //    BlankSapce1(2);
            //}
            //}
            document.NewPage();
            BlankSapce1(1);
            lineheight = 0;
            Linecount = 0;
            int chkline = 0;
            string itemQury = "Select * from ItemDtl where PermitId='" + dt.Rows[0]["PermitId"].ToString() + "' order by ItemNo";
            obj.dr = obj.ret_dr(itemQury);
            if (obj.dr.HasRows)
            {
                while (obj.dr.Read())
                {
                    strInHAWBOBL = obj.dr["InHAWBOBL"].ToString();
                    lspval = obj.dr["LSPValue"].ToString();
                    if (pgheight - 82 > lineheight)
                    {
                        if (Linecount == 0)
                        {
                            ItemHeaderprint(decltype[0].ToString().Substring(0, decltype[0].ToString().Length - 1).ToUpper());
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
                        if (pgheight - 82 > lineheight)
                        {
                            string page022 = "   " + sno + "  " + obj.dr["HSCode"].ToString().ToUpper() + "   " + obj.dr["CurrentLot"].ToString().ToUpper() + "";
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

                            document.NewPage();
                            BlankSapce1(1);
                            Linecount = 0;
                            lineheight = 0;
                            ItemHeaderprint(decltype[0].ToString().Substring(0, decltype[0].ToString().Length - 1).ToUpper());

                            string page022 = "   " + sno + "  " + obj.dr["HSCode"].ToString().ToUpper() + "   " + obj.dr["CurrentLot"].ToString().ToUpper() + "";
                            iTextSharp.text.Paragraph h3 = new iTextSharp.text.Paragraph(page022, times);
                            h3.Alignment = Element.ALIGN_LEFT;
                            h3.SetLeading(0.0f, 1.0f);
                            document.Add(h3);
                            Linecount = Linecount + 1;
                            lineheight = lineheight + 10;

                        }

                        string Marking1 = "";
                        string[] Marking = obj.dr["Making"].ToString().Split(':');
                        if (obj.dr["Making"].ToString() != "--Select--")
                        {
                            Marking1 = Marking[0].Substring(0, Marking[0].Length - 1).ToString();
                        }
                        if (string.IsNullOrWhiteSpace(Marking1))
                        {
                            Marking1 = "  ";
                        }
                        string Marking2 = "" + Marking1.ToUpper() + "  " + obj.dr["Contry"].ToString().ToUpper() + "   " + obj.dr["Brand"].ToString().ToUpper() + " ";
                        space = ""; space1 = "";
                        sapceval = 0; spceval1 = 0;
                        sapceval = Marking2.Length;
                        spceval1 = 44 - sapceval;
                        for (int i = 0; i < spceval1; i++)
                        {
                            space = space + " ";
                        }
                        if (pgheight - 82 > lineheight)
                        {
                            string page023 = "" + Marking1.ToUpper() + "  " + obj.dr["Contry"].ToString().ToUpper() + "   " + obj.dr["Brand"].ToString().ToUpper() + " " + space + " " + obj.dr["Model"].ToString().ToUpper() + "";
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

                            document.NewPage();
                            BlankSapce1(1);
                            Linecount = 0;
                            lineheight = 0;
                            ItemHeaderprint(decltype[0].ToString().Substring(0, decltype[0].ToString().Length - 1).ToUpper());

                            string page023 = "" + Marking1.ToUpper() + "  " + obj.dr["Contry"].ToString().ToUpper() + "   " + obj.dr["Brand"].ToString().ToUpper() + " " + space + " " + obj.dr["Model"].ToString().ToUpper() + "";
                            iTextSharp.text.Paragraph h4 = new iTextSharp.text.Paragraph(page023, times);
                            h4.Alignment = Element.ALIGN_LEFT;
                            h4.SetLeading(0.0f, 1.0f);
                            document.Add(h4);
                            Linecount = Linecount + 1;
                            lineheight = lineheight + 10;

                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["InHAWBOBL"].ToString()))
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
                            if (pgheight - 82 > lineheight)
                            {
                                string page024 = "" + obj.dr["InHAWBOBL"].ToString().ToUpper() + "" + space + "";
                                iTextSharp.text.Paragraph h5 = new iTextSharp.text.Paragraph(page024, times);
                                h5.Alignment = Element.ALIGN_LEFT;
                                h5.SetLeading(0.0f, 1.0f);
                                document.Add(h5);
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

                                document.NewPage();
                                BlankSapce1(1);
                                Linecount = 0;
                                lineheight = 0;
                                ItemHeaderprint(decltype[0].ToString().Substring(0, decltype[0].ToString().Length - 1).ToUpper());

                                string page024 = "" + obj.dr["InHAWBOBL"].ToString().ToUpper() + "" + space + "";
                                iTextSharp.text.Paragraph h5 = new iTextSharp.text.Paragraph(page024, times);
                                h5.Alignment = Element.ALIGN_LEFT;
                                h5.SetLeading(0.0f, 1.0f);
                                document.Add(h5);
                                Linecount = Linecount + 1;
                                lineheight = lineheight + 10;

                            }
                        }

                        string opqty = "", strtest = "";

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
                            opqty = space + Math.Round(Convert.ToDecimal(obj.dr["OPQty"].ToString()), 0) + " " + obj.dr["OPUOM"].ToString() + " ";
                            strtest = "1";
                        }
                        if (obj.dr["IPUOM"].ToString() != "--Select--")
                        {
                            space = ""; space1 = "";
                            sapceval = 0; spceval1 = 0;
                            double val = Convert.ToDouble(obj.dr["IPQty"].ToString());
                            sapceval = val.ToString().Length;
                            spceval1 = 8 - sapceval;
                            for (int i = 0; i < spceval1; i++)
                            {
                                space = space + " ";
                            }
                            opqty = opqty + space + Math.Round(Convert.ToDecimal(obj.dr["IPQty"].ToString()), 0) + " " + obj.dr["IPUOM"].ToString() + "       ";
                            strtest = "2";
                        }


                        int partLength = 50;
                        string sentence = obj.dr["Description"].ToString();
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

                        int rcunt = 0;
                        string teststr = "";
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

                        if (decltype[0].ToString().Substring(0, decltype[0].ToString().Length - 1).ToUpper() == "DUT" || decltype[0].ToString().Substring(0, decltype[0].ToString().Length - 1).ToUpper() == "DNG")
                        {
                            string hsval = Math.Round(Convert.ToDecimal(obj.dr["TotalDutiableQty"].ToString()), 4).ToString("0.0000");
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
                            sapceval = hsval.Length;
                            spceval1 = 25 - sapceval;
                            for (int i = 0; i < spceval1; i++)
                            {
                                space1 = space1 + " ";
                            }

                            if (pgheight - 82 > lineheight)
                            {
                                string page025 = "" + teststr.ToUpper() + "" + space + "" + space1 + "" + hsval + " " + obj.dr["TotalDutiableUOM"].ToString() + "    ";
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
                                //BlankSapce1(1);
                                document.NewPage();
                                BlankSapce1(1);
                                Linecount = 0;
                                lineheight = 0;
                                ItemHeaderprint(decltype[0].ToString().Substring(0, decltype[0].ToString().Length - 1).ToUpper());

                                string page025 = "" + teststr.ToUpper() + "" + space + "" + space1 + "" + hsval + " " + obj.dr["TotalDutiableUOM"].ToString() + "    ";
                                iTextSharp.text.Paragraph h6 = new iTextSharp.text.Paragraph(page025, times);
                                h6.Alignment = Element.ALIGN_LEFT;
                                h6.SetLeading(0.0f, 1.0f);
                                document.Add(h6);
                                Linecount = Linecount + 1;
                                lineheight = lineheight + 10;

                            }

                        }
                        else
                        {
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
                                string hsval = Math.Round(Convert.ToDecimal(obj.dr["TotalDutiableQty"].ToString()), 4).ToString("0.0000");
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
                                sapceval = hsval.Length;
                                spceval1 = 25 - sapceval;
                                for (int i = 0; i < spceval1; i++)
                                {
                                    space1 = space1 + " ";
                                }

                                if (pgheight - 82 > lineheight)
                                {
                                    string page025 = "" + teststr.ToUpper() + "" + space + "" + space1 + "" + hsval + " " + obj.dr["TotalDutiableUOM"].ToString() + "    ";
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
                                    //BlankSapce1(1);
                                    document.NewPage();
                                    BlankSapce1(1);
                                    Linecount = 0;
                                    lineheight = 0;
                                    ItemHeaderprint(decltype[0].ToString().Substring(0, decltype[0].ToString().Length - 1).ToUpper());

                                    string page025 = "" + teststr.ToUpper() + "" + space + "" + space1 + "" + hsval + " " + obj.dr["TotalDutiableUOM"].ToString() + "    ";
                                    iTextSharp.text.Paragraph h6 = new iTextSharp.text.Paragraph(page025, times);
                                    h6.Alignment = Element.ALIGN_LEFT;
                                    h6.SetLeading(0.0f, 1.0f);
                                    document.Add(h6);
                                    Linecount = Linecount + 1;
                                    lineheight = lineheight + 10;

                                }
                            }
                            else
                            {
                                string hsval = Math.Round(Convert.ToDecimal(obj.dr["HSQty"].ToString()), 4).ToString("0.0000");
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
                                sapceval = hsval.Length;
                                spceval1 = 25 - sapceval;
                                for (int i = 0; i < spceval1; i++)
                                {
                                    space1 = space1 + " ";
                                }

                                if (pgheight - 82 > lineheight)
                                {
                                    string page025 = "" + teststr.ToUpper() + "" + space + "" + space1 + "" + hsval + " " + obj.dr["HSUOM"].ToString().ToUpper() + "    ";
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
                                    //BlankSapce1(1);
                                    document.NewPage();
                                    BlankSapce1(1);
                                    Linecount = 0;
                                    lineheight = 0;
                                    ItemHeaderprint(decltype[0].ToString().Substring(0, decltype[0].ToString().Length - 1).ToUpper());

                                    string page025 = "" + teststr.ToUpper() + "" + space + "" + space1 + "" + hsval + " " + obj.dr["HSUOM"].ToString().ToUpper() + "    ";
                                    iTextSharp.text.Paragraph h6 = new iTextSharp.text.Paragraph(page025, times);
                                    h6.Alignment = Element.ALIGN_LEFT;
                                    h6.SetLeading(0.0f, 1.0f);
                                    document.Add(h6);
                                    Linecount = Linecount + 1;
                                    lineheight = lineheight + 10;

                                }
                            }
                        }

                        if (obj.dr["OPUOM"].ToString() != "--Select--")
                        {
                            opqty = ""; strtest = "";
                        }
                        if (obj.dr["InPUOM"].ToString() != "--Select--")
                        {
                            handl = "LICENCE NO:";
                            space = ""; space1 = "";
                            sapceval = 0; spceval1 = 0;
                            double val = Convert.ToDouble(obj.dr["InPqty"].ToString());
                            sapceval = val.ToString().Length;
                            spceval1 = 8 - sapceval;
                            for (int i = 0; i < spceval1; i++)
                            {
                                space = space + " ";
                            }
                            opqty = space + Math.Round(Convert.ToDecimal(obj.dr["InPqty"].ToString()), 0) + " " + obj.dr["InPUOM"].ToString().ToUpper() + " ";
                            strtest = "3";
                        }
                        if (obj.dr["ImPUOM"].ToString() != "--Select--")
                        {
                            handl = "LICENCE NO:";
                            space = ""; space1 = "";
                            sapceval = 0; spceval1 = 0;
                            double val = Convert.ToDouble(obj.dr["ImPQty"].ToString());
                            sapceval = val.ToString().Length;
                            spceval1 = 8 - sapceval;
                            for (int i = 0; i < spceval1; i++)
                            {
                                space = space + " ";
                            }
                            opqty = opqty + space + Math.Round(Convert.ToDecimal(obj.dr["ImPQty"].ToString()), 0) + " " + obj.dr["ImPUOM"].ToString().ToUpper() + "";
                            strtest = "4";
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
                        if (pgheight - 82 > lineheight)
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
                            //BlankSapce1(1);
                            document.NewPage();
                            BlankSapce1(1);
                            Linecount = 0;
                            lineheight = 0;
                            ItemHeaderprint(decltype[0].ToString().Substring(0, decltype[0].ToString().Length - 1).ToUpper());

                            string page026 = "" + teststr + "" + space + "" + space1 + "" + obj.dr["CIFFOB"].ToString() + "    ";
                            iTextSharp.text.Paragraph h7 = new iTextSharp.text.Paragraph(page026, times);
                            h7.Alignment = Element.ALIGN_LEFT;
                            h7.SetLeading(0.0f, 1.0f);
                            document.Add(h7);
                            Linecount = Linecount + 1;
                            lineheight = lineheight + 10;

                        }

                        if (obj.dr["InPUOM"].ToString() != "--Select--")
                        {
                            opqty = ""; strtest = "";
                        }
                        if (Convert.ToDecimal(lspval) > 0)
                        {
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
                            if (pgheight - 82 > lineheight)
                            {
                                string page026p = "" + teststr + "" + space + "" + space1 + "" + obj.dr["LSPValue"].ToString() + "    ";
                                iTextSharp.text.Paragraph h7p = new iTextSharp.text.Paragraph(page026p, times);
                                h7p.Alignment = Element.ALIGN_LEFT;
                                h7p.SetLeading(0.0f, 1.0f);
                                document.Add(h7p);
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
                                //BlankSapce1(1);
                                document.NewPage();
                                BlankSapce1(1);
                                Linecount = 0;
                                lineheight = 0;
                                ItemHeaderprint(decltype[0].ToString().Substring(0, decltype[0].ToString().Length - 1).ToUpper());

                                string page026p = "" + teststr + "" + space + "" + space1 + "" + obj.dr["LSPValue"].ToString() + "    ";
                                iTextSharp.text.Paragraph h7p = new iTextSharp.text.Paragraph(page026p, times);
                                h7p.Alignment = Element.ALIGN_LEFT;
                                h7p.SetLeading(0.0f, 1.0f);
                                document.Add(h7p);
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
                        if (pgheight - 82 > lineheight)
                        {
                            string page027 = "" + teststr + "" + space + "" + space1 + "" + obj.dr["GSTAmount"].ToString() + "    ";
                            iTextSharp.text.Paragraph h8 = new iTextSharp.text.Paragraph(page027, times);
                            h8.Alignment = Element.ALIGN_LEFT;
                            h8.SetLeading(0.0f, 1.0f);
                            document.Add(h8);
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
                            //BlankSapce1(1);
                            document.NewPage();
                            BlankSapce1(1);
                            Linecount = 0;
                            lineheight = 0;
                            ItemHeaderprint(decltype[0].ToString().Substring(0, decltype[0].ToString().Length - 1).ToUpper());

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
                            h8.SetLeading(0.0f, 1.0f);
                            document.Add(h8);
                            Linecount = Linecount + 1;
                            lineheight = lineheight + 10;

                        }



                        string DutiAmt = "";
                        if (obj.dr["DutiableUOM"].ToString() != "--Select--")
                        {
                            DutiAmt = Math.Round(Convert.ToDecimal(obj.dr["DutiableQty"].ToString()), 4).ToString("0.0000") + " " + obj.dr["DutiableUOM"].ToString().ToUpper();
                        }
                        if (!string.IsNullOrWhiteSpace(DutiAmt))
                        {
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
                            handl = "LICENCE NO:";
                            space = ""; space1 = "";
                            sapceval = 0; spceval1 = 0;
                            sapceval = teststr.Length;
                            spceval1 = 50 - sapceval;
                            for (int i = 0; i < spceval1; i++)
                            {
                                space = space + " ";
                            }
                            string dutamt = Math.Round(Convert.ToDecimal(obj.dr["DutiableQty"].ToString()), 4).ToString("0.0000");
                            cartype = dt.Rows[0]["VesselName"].ToString().Split(':');
                            sapceval = 0; spceval1 = 0;
                            sapceval = dutamt.Length;
                            spceval1 = 25 - sapceval;
                            for (int i = 0; i < spceval1; i++)
                            {
                                space1 = space1 + " ";
                            }
                            if (pgheight - 82 > lineheight)
                            {
                                string page033 = "" + teststr + "" + space + "" + space1 + "" + DutiAmt + "";
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
                                // document.Add(l3p);
                                //BlankSapce1(1);
                                document.NewPage();
                                BlankSapce1(1);
                                Linecount = 0;
                                lineheight = 0;
                                ItemHeaderprint(decltype[0].ToString().Substring(0, decltype[0].ToString().Length - 1).ToUpper());

                                string page033 = "" + teststr + "" + space + "" + space1 + "" + DutiAmt + "";
                                iTextSharp.text.Paragraph i4 = new iTextSharp.text.Paragraph(page033, times);
                                i4.Alignment = Element.ALIGN_LEFT;
                                i4.SetLeading(0.0f, 1.0f);
                                document.Add(i4);
                                Linecount = Linecount + 1;
                                lineheight = lineheight + 10;

                            }

                        }

                        if (decltype[0].ToString().Substring(0, decltype[0].ToString().Length - 1).ToUpper() == "DNG")
                        {

                        }
                        else
                        {
                            if (Convert.ToDecimal(obj.dr["UnitPrice"].ToString()) > 0)
                            {
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

                                string hsval = Math.Round(Convert.ToDecimal(obj.dr["TotalLineAmount"].ToString()), 4).ToString("0.0000");
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
                                if (pgheight - 82 > lineheight)
                                {
                                    string page028 = "" + teststr + "" + space + "" + space1 + "" + hsval + " " + obj.dr["UnitPriceCurrency"].ToString().ToUpper() + "";
                                    iTextSharp.text.Paragraph h9 = new iTextSharp.text.Paragraph(page028, times);
                                    h9.Alignment = Element.ALIGN_LEFT;
                                    h9.SetLeading(0.0f, 1.0f);
                                    document.Add(h9);
                                    Linecount = Linecount + 1;
                                    lineheight = lineheight + 10;
                                }
                                else
                                {
                                    // document.Add(Line);
                                    Linecount = Linecount + 1;
                                    lineheight = lineheight + 10;

                                    msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                                    string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                                    iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                                    l3p.Alignment = Element.ALIGN_LEFT;
                                    l3p.SetLeading(0.0f, 1.0f);
                                    //document.Add(l3p);
                                    //BlankSapce1(1);
                                    document.NewPage();
                                    BlankSapce1(1);
                                    Linecount = 0;
                                    lineheight = 0;
                                    ItemHeaderprint(decltype[0].ToString().Substring(0, decltype[0].ToString().Length - 1).ToUpper());

                                    string page028 = "" + teststr + "" + space + "" + space1 + "" + hsval + " " + obj.dr["UnitPriceCurrency"].ToString().ToUpper() + "";
                                    iTextSharp.text.Paragraph h9 = new iTextSharp.text.Paragraph(page028, times);
                                    h9.Alignment = Element.ALIGN_LEFT;
                                    h9.SetLeading(0.0f, 1.0f);
                                    document.Add(h9);
                                    Linecount = Linecount + 1;
                                    lineheight = lineheight + 10;

                                }
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
                        DutiAmt = "";
                        if (Convert.ToDecimal(obj.dr["ExciseDutyRate"].ToString()) > 0)
                        {
                            DutiAmt = obj.dr["ExciseDutyAmount"].ToString() + "";
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
                            if (pgheight - 82 > lineheight)
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
                                //BlankSapce1(1);
                                document.NewPage();
                                BlankSapce1(1);
                                Linecount = 0;
                                lineheight = 0;
                                ItemHeaderprint(decltype[0].ToString().Substring(0, decltype[0].ToString().Length - 1).ToUpper());

                                string page034 = "" + teststr + "" + space + "" + space1 + "" + DutiAmt + "";
                                iTextSharp.text.Paragraph i5 = new iTextSharp.text.Paragraph(page034, times);
                                i5.Alignment = Element.ALIGN_LEFT;
                                i5.SetLeading(0.0f, 1.0f);
                                document.Add(i5);
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
                        DutiAmt = "";
                        if (Convert.ToDecimal(obj.dr["CustomsDutyAmount"].ToString()) > 0)
                        {
                            DutiAmt = obj.dr["CustomsDutyAmount"].ToString() + "";
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
                            sapceval = obj.dr["CustomsDutyAmount"].ToString().Length;
                            spceval1 = 25 - sapceval;
                            for (int i = 0; i < spceval1; i++)
                            {
                                space1 = space1 + " ";
                            }
                            if (pgheight - 82 > lineheight)
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
                                //BlankSapce1(1);
                                document.NewPage();
                                BlankSapce1(1);
                                Linecount = 0;
                                lineheight = 0;
                                ItemHeaderprint(decltype[0].ToString().Substring(0, decltype[0].ToString().Length - 1).ToUpper());

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
                            if (pgheight - 82 > lineheight)
                            {
                                teststr = lines[rcunt].ToString().ToUpper();
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
                                //BlankSapce1(1);
                                document.NewPage();
                                BlankSapce1(1);
                                Linecount = 0;
                                lineheight = 0;
                                ItemHeaderprint(decltype[0].ToString().Substring(0, decltype[0].ToString().Length - 1).ToUpper());

                                teststr = lines[rcunt].ToString().ToUpper();
                                string page034 = "" + teststr + "" + space + "" + space1 + "" + DutiAmt + "";
                                iTextSharp.text.Paragraph i5 = new iTextSharp.text.Paragraph(page034, times);
                                i5.Alignment = Element.ALIGN_LEFT;
                                i5.SetLeading(0.0f, 1.0f);
                                document.Add(i5);
                                Linecount = Linecount + 1;
                                lineheight = lineheight + 10;

                            }

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
                                        supName = obj2.dr["Name"].ToString().ToUpper();
                                    }
                                }
                                if (obj1.dr["SupplierCode"].ToString() == "-")
                                {
                                    supName = "-";
                                }
                            }
                        }

                        if (!string.IsNullOrWhiteSpace(supName))
                        {
                            if (pgheight - 82 > lineheight)
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
                                //BlankSapce1(1);
                                document.NewPage();
                                BlankSapce1(1);
                                Linecount = 0;
                                lineheight = 0;
                                ItemHeaderprint(decltype[0].ToString().Substring(0, decltype[0].ToString().Length - 1).ToUpper());

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
                            //BlankSapce1(1);
                            document.NewPage();
                            BlankSapce1(1);
                            Linecount = 0;
                            lineheight = 0;
                            ItemHeaderprint(decltype[0].ToString().Substring(0, decltype[0].ToString().Length - 1).ToUpper());

                            //document.Add(Line);
                            //Linecount = Linecount + 1;
                            //lineheight = lineheight + 10;

                        }


                        //            string casccode = "", cacsprctQty = "", EngNo = "", Chaseno = "";
                        //            MyClass obj3 = new MyClass();
                        //            string CascQury = "Select * from CASCDtl where PermitId='" + dt.Rows[0]["PermitId"].ToString() + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "'";
                        //            obj3.dr = obj3.ret_dr(CascQury);
                        //            int l = 0;
                        //            string sno1 = "";
                        //            if (obj3.dr.HasRows)
                        //            {
                        //                while (obj3.dr.Read())
                        //                {
                        //                    l = l + 1;
                        //                    sno1 = "0" + l;
                        //                    casccode = obj3.dr["ProductCode"].ToString().ToUpper();
                        //                    cacsprctQty = Math.Round(Convert.ToDecimal(obj3.dr["Quantity"].ToString()), 4).ToString("0.0000") + " " + obj3.dr["ProductUOM"].ToString().ToUpper();
                        //                    EngNo = obj3.dr["CascCode1"].ToString().ToUpper();
                        //                    Chaseno = obj3.dr["CascCode2"].ToString().ToUpper();
                        //                    if (!string.IsNullOrWhiteSpace(casccode))
                        //                    {
                        //                        if (pgheight - 82 > lineheight)
                        //                        {
                        //                            string page042 = "S/NO   CA/SC PRODUCT CODE                      CA/SC PRODUCT QTY & UNIT         ";
                        //                            iTextSharp.text.Paragraph j3 = new iTextSharp.text.Paragraph(page042, times);
                        //                            j3.Alignment = Element.ALIGN_LEFT;
                        //                            j3.SetLeading(0.0f, 1.0f);
                        //                            document.Add(j3);
                        //                            Linecount = Linecount + 1;
                        //                            lineheight = lineheight + 10;
                        //                        }
                        //                        else
                        //                        {
                        //                            //document.Add(Line);
                        //                            Linecount = Linecount + 1;
                        //                            lineheight = lineheight + 10;

                        //                            msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                        //                            string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                        //                            iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                        //                            l3p.Alignment = Element.ALIGN_LEFT;
                        //                            l3p.SetLeading(0.0f, 1.0f);
                        //                            //document.Add(l3p);
                        //                            //BlankSapce1(1);
                        //                            document.NewPage();
                        //                            BlankSapce1(1);
                        //                            Linecount = 0;
                        //                            lineheight = 0;
                        //                            ItemHeaderprint(decltype[0].ToString().Substring(0, decltype[0].ToString().Length - 1).ToUpper());

                        //                            string page042 = "S/NO   CA/SC PRODUCT CODE                      CA/SC PRODUCT QTY & UNIT         ";
                        //                            iTextSharp.text.Paragraph j3 = new iTextSharp.text.Paragraph(page042, times);
                        //                            j3.Alignment = Element.ALIGN_LEFT;
                        //                            j3.SetLeading(0.0f, 1.0f);
                        //                            document.Add(j3);
                        //                            Linecount = Linecount + 1;
                        //                            lineheight = lineheight + 10;

                        //                        }


                        //                        for (int k = 0; sno1.Length < 5; k++)
                        //                        {
                        //                            sno1 = " " + sno1;
                        //                        }
                        //                        string caspt = "";
                        //                        if (Convert.ToDecimal(obj3.dr["Quantity"].ToString()) > 0)
                        //                        {
                        //                            caspt = Math.Round(Convert.ToDecimal(obj3.dr["Quantity"].ToString()), 4).ToString("0.0000");
                        //                        }
                        //                        if (caspt != "")
                        //                        {
                        //                            for (int k = 0; caspt.Length < 18; k++)
                        //                            {
                        //                                caspt = " " + caspt;
                        //                            }
                        //                        }
                        //                        if (caspt != "")
                        //                        {
                        //                            caspt = caspt + " " + obj3.dr["ProductUOM"].ToString().ToUpper() + "";
                        //                        }
                        //                        handl = "" + sno1 + "" + "  " + casccode.ToUpper();
                        //                        space = ""; space1 = "";
                        //                        sapceval = 0; spceval1 = 0;
                        //                        sapceval = handl.Length;
                        //                        spceval1 = 45 - sapceval;
                        //                        for (int i = 0; i < spceval1; i++)
                        //                        {
                        //                            space = space + " ";
                        //                        }
                        //                        if (pgheight - 82 > lineheight)
                        //                        {
                        //                            string page043 = "" + sno1 + "" + "  " + casccode.ToUpper() + space + caspt;
                        //                            iTextSharp.text.Paragraph j4 = new iTextSharp.text.Paragraph(page043, times);
                        //                            j4.Alignment = Element.ALIGN_LEFT;
                        //                            j4.SetLeading(0.0f, 1.0f);
                        //                            document.Add(j4);
                        //                            Linecount = Linecount + 1;
                        //                            lineheight = lineheight + 10;
                        //                        }
                        //                        else
                        //                        {
                        //                            //document.Add(Line);
                        //                            Linecount = Linecount + 1;
                        //                            lineheight = lineheight + 10;

                        //                            msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                        //                            string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                        //                            iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                        //                            l3p.Alignment = Element.ALIGN_LEFT;
                        //                            l3p.SetLeading(0.0f, 1.0f);
                        //                            //document.Add(l3p);
                        //                            //BlankSapce1(1);
                        //                            document.NewPage();
                        //                            BlankSapce1(1);
                        //                            Linecount = 0;
                        //                            lineheight = 0;
                        //                            ItemHeaderprint(decltype[0].ToString().Substring(0, decltype[0].ToString().Length - 1).ToUpper());

                        //                            string page043 = "" + sno1 + "" + "  " + casccode.ToUpper() + space + caspt + " " + obj3.dr["ProductUOM"].ToString() + "";
                        //                            iTextSharp.text.Paragraph j4 = new iTextSharp.text.Paragraph(page043, times);
                        //                            j4.Alignment = Element.ALIGN_LEFT;
                        //                            j4.SetLeading(0.0f, 1.0f);
                        //                            document.Add(j4);
                        //                            Linecount = Linecount + 1;
                        //                            lineheight = lineheight + 10;

                        //                        }

                        //                        if (pgheight - 82 > lineheight)
                        //                        {
                        //                            document.Add(Line);
                        //                            Linecount = Linecount + 1;
                        //                            lineheight = lineheight + 10;
                        //                        }
                        //                        else
                        //                        {
                        //                            //document.Add(Line);
                        //                            Linecount = Linecount + 1;
                        //                            lineheight = lineheight + 10;

                        //                            msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                        //                            string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                        //                            iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                        //                            l3p.Alignment = Element.ALIGN_LEFT;
                        //                            l3p.SetLeading(0.0f, 1.0f);
                        //                            //document.Add(l3p);
                        //                            //BlankSapce1(1);
                        //                            document.NewPage();
                        //                            BlankSapce1(1);
                        //                            Linecount = 0;
                        //                            lineheight = 0;
                        //                            ItemHeaderprint(decltype[0].ToString().Substring(0, decltype[0].ToString().Length - 1).ToUpper());

                        //                            document.Add(Line);
                        //                            Linecount = Linecount + 1;
                        //                            lineheight = lineheight + 10;

                        //                        }

                        //                    }

                        //                }
                        //            }
                        //            if (pgheight - 82 > lineheight)
                        //            {
                        //                Linecount = Linecount + 1;
                        //                BlankSapce(2);
                        //                if (pgheight - 82 > lineheight)
                        //                {
                        //                    document.Add(Line);
                        //                    Linecount = Linecount + 1;
                        //                }
                        //                else
                        //                {
                        //                    //document.Add(Line);
                        //                    Linecount = Linecount + 1;
                        //                    lineheight = lineheight + 10;

                        //                    msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                        //                    string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                        //                    iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                        //                    l3p.Alignment = Element.ALIGN_LEFT;
                        //                    l3p.SetLeading(0.0f, 1.0f);
                        //                    //document.Add(l3p);
                        //                    //BlankSapce1(1);
                        //                    document.NewPage();
                        //                    BlankSapce1(1);
                        //                    Linecount = 0;
                        //                    lineheight = 0;
                        //                    ItemHeaderprint(decltype[0].ToString().Substring(0, decltype[0].ToString().Length - 1).ToUpper());
                        //                }
                        //            }
                        //            else
                        //            {
                        //                //document.Add(Line);
                        //                Linecount = Linecount + 1;
                        //                lineheight = lineheight + 10;

                        //                msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                        //                string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                        //                iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                        //                l3p.Alignment = Element.ALIGN_LEFT;
                        //                l3p.SetLeading(0.0f, 1.0f);
                        //                //document.Add(l3p);
                        //                //BlankSapce1(1);
                        //                document.NewPage();
                        //                BlankSapce1(1);
                        //                Linecount = 0;
                        //                lineheight = 0;
                        //                ItemHeaderprint(decltype[0].ToString().Substring(0, decltype[0].ToString().Length - 1).ToUpper());
                        //            }
                        //            //BlankSapce(1);
                        //            //Linecount = Linecount + 1;
                        //        }
                        //        else
                        //        {
                        //            //document.Add(Line);
                        //            Linecount = Linecount + 1;

                        //            msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                        //            string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                        //            iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                        //            l3p.Alignment = Element.ALIGN_LEFT;
                        //            l3p.SetLeading(0.0f, 1.0f);
                        //            //document.Add(l3p);
                        //            document.NewPage();
                        //            BlankSapce1(1);
                        //            Linecount = 0;
                        //            lineheight = 0;
                        //            ItemHeaderprint(decltype[0].ToString().Substring(0, decltype[0].ToString().Length - 1).ToUpper());
                        //        }
                        //        if (!string.IsNullOrWhiteSpace(EngNo))
                        //        {

                        //            string eng = obj.dr["HSCode"].ToString().Substring(0, 2);
                        //            if (eng == "87")
                        //            {
                        //                for (int k = 0; sno1.Length < 5; k++)
                        //                {
                        //                    sno1 = " " + sno1;
                        //                }
                        //                if (newcasccode != oldcasccode)
                        //                {
                        //                    if (pgheight - 82 > lineheight)
                        //                    {
                        //                        document.Add(Line);
                        //                        Linecount = Linecount + 1;
                        //                        lineheight = lineheight + 10;
                        //                    }
                        //                    else
                        //                    {
                        //                        //document.Add(Line);
                        //                        Linecount = Linecount + 1;
                        //                        lineheight = lineheight + 10;

                        //                        msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                        //                        string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                        //                        iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                        //                        l3p.Alignment = Element.ALIGN_LEFT;
                        //                        l3p.SetLeading(0.0f, 1.0f);
                        //                        //document.Add(l3p);
                        //                        BlankSapce1(3);
                        //                        //document.NewPage();
                        //                        Linecount = 0;
                        //                        lineheight = 0;
                        //                        ItemHeaderprint();
                        //                    }
                        //                    if (pgheight - 82 > lineheight)
                        //                    {
                        //                        newcasccode = obj3.dr["CASCId"].ToString();
                        //                        string page042 = "S/NO   ENGINE NO/CHASSIS NO                               ";
                        //                        iTextSharp.text.Paragraph j3 = new iTextSharp.text.Paragraph(page042, times);
                        //                        j3.Alignment = Element.ALIGN_LEFT;
                        //                        j3.SetLeading(0.0f, 1.0f);
                        //                        document.Add(j3);
                        //                        Linecount = Linecount + 1;
                        //                        lineheight = lineheight + 10;
                        //                    }
                        //                    else
                        //                    {
                        //                        //document.Add(Line);
                        //                        Linecount = Linecount + 1;
                        //                        lineheight = lineheight + 10;

                        //                        msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                        //                        string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                        //                        iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                        //                        l3p.Alignment = Element.ALIGN_LEFT;
                        //                        l3p.SetLeading(0.0f, 1.0f);
                        //                        //document.Add(l3p);
                        //                        BlankSapce1(3);
                        //                        //document.NewPage();
                        //                        Linecount = 0;
                        //                        lineheight = 0;
                        //                        ItemHeaderprint();

                        //                        newcasccode = obj3.dr["CASCId"].ToString();
                        //                        string page042 = "S/NO   ENGINE NO/CHASSIS NO                               ";
                        //                        iTextSharp.text.Paragraph j3 = new iTextSharp.text.Paragraph(page042, times);
                        //                        j3.Alignment = Element.ALIGN_LEFT;
                        //                        j3.SetLeading(0.0f, 1.0f);
                        //                        document.Add(j3);
                        //                        Linecount = Linecount + 1;
                        //                        lineheight = lineheight + 10;
                        //                    }
                        //                }
                        //                if (pgheight - 82 > lineheight)
                        //                {
                        //                    string page043 = "" + sno1 + "" + "  " + EngNo + "/" + Chaseno + "";
                        //                    iTextSharp.text.Paragraph j4 = new iTextSharp.text.Paragraph(page043, times);
                        //                    j4.Alignment = Element.ALIGN_LEFT;
                        //                    j4.SetLeading(0.0f, 1.0f);
                        //                    document.Add(j4);
                        //                    Linecount = Linecount + 1;
                        //                    lineheight = lineheight + 10;

                        //                    //document.Add(Line);
                        //                    //Linecount = Linecount + 1;
                        //                    //lineheight = lineheight + 10;
                        //                }
                        //                else
                        //                {
                        //                    //document.Add(Line);
                        //                    Linecount = Linecount + 1;
                        //                    lineheight = lineheight + 10;

                        //                    msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                        //                    string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                        //                    iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                        //                    l3p.Alignment = Element.ALIGN_LEFT;
                        //                    l3p.SetLeading(0.0f, 1.0f);
                        //                    //document.Add(l3p);
                        //                    BlankSapce1(3);
                        //                    //document.NewPage();
                        //                    Linecount = 0;
                        //                    lineheight = 0;
                        //                    ItemHeaderprint();

                        //                    string page043 = "" + sno1 + "" + "  " + EngNo + "/" + Chaseno + "";
                        //                    iTextSharp.text.Paragraph j4 = new iTextSharp.text.Paragraph(page043, times);
                        //                    j4.Alignment = Element.ALIGN_LEFT;
                        //                    j4.SetLeading(0.0f, 1.0f);
                        //                    document.Add(j4);
                        //                    Linecount = Linecount + 1;
                        //                    lineheight = lineheight + 10;

                        //                    //document.Add(Line);
                        //                    //Linecount = Linecount + 1;
                        //                    //lineheight = lineheight + 10;
                        //                }
                        //            }
                        //        }
                        //    }
                        //}
                        string casccode = "", cacsprctQty = "", EngNo = "", Chaseno = "", oldcasccode = "", newcasccode = "";
                        MyClass obj3 = new MyClass();
                        string CascQury = "Select * from CASCDtl where PermitId='" + dt.Rows[0]["PermitId"].ToString() + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "'";
                        obj3.dr = obj3.ret_dr(CascQury);
                        int l = 0;
                        string sno1 = "";
                        if (obj3.dr.HasRows)
                        {
                            while (obj3.dr.Read())
                            {
                                l = l + 1;
                                sno1 = "0" + l;
                                oldcasccode = obj3.dr["CASCId"].ToString();
                                casccode = obj3.dr["ProductCode"].ToString();


                                cacsprctQty = Math.Round(Convert.ToDecimal(obj3.dr["Quantity"].ToString()), 4).ToString("0.0000") + " " + obj3.dr["ProductUOM"].ToString();
                                EngNo = obj3.dr["CascCode1"].ToString();
                                Chaseno = obj3.dr["CascCode2"].ToString();
                                if (!string.IsNullOrWhiteSpace(casccode))
                                {
                                    if (newcasccode != oldcasccode)
                                    {
                                        if (pgheight - 82 > lineheight)
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
                                            ItemHeaderprint(decltype[0].ToString().Substring(0, decltype[0].ToString().Length - 1).ToUpper());

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
                                        for (int k = 0; caspt.Length < 18; k++)
                                        {
                                            caspt = " " + caspt;
                                        }
                                        if (pgheight - 82 > lineheight)
                                        {
                                            handl = "LICENCE NO:";
                                            space = ""; space1 = "";
                                            sapceval = 0; spceval1 = 0;
                                            string valstr = sno1 + "  " + casccode;
                                            sapceval = valstr.Length;
                                            spceval1 = 45 - sapceval;
                                            for (int i = 0; i < spceval1; i++)
                                            {
                                                space = space + " ";
                                            }
                                            if (obj3.dr["ProductUOM"].ToString() != "--Select--")
                                            {
                                                caspt = caspt + " " + obj3.dr["ProductUOM"].ToString();
                                            }


                                            string page043 = "" + sno1 + "" + "  " + casccode.ToUpper() + space + caspt;
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
                                            ItemHeaderprint(decltype[0].ToString().Substring(0, decltype[0].ToString().Length - 1).ToUpper());
                                            if (obj3.dr["ProductUOM"].ToString() != "Select")
                                            {
                                                caspt = caspt + " " + obj3.dr["ProductUOM"].ToString();
                                            }
                                            string page043 = "" + sno1 + "" + "  " + casccode.ToUpper() + "                                     " + caspt;
                                            iTextSharp.text.Paragraph j4 = new iTextSharp.text.Paragraph(page043, times);
                                            j4.Alignment = Element.ALIGN_LEFT;
                                            j4.SetLeading(0.0f, 1.0f);
                                            document.Add(j4);
                                            Linecount = Linecount + 1;
                                            lineheight = lineheight + 10;

                                            document.Add(Line);
                                            Linecount = Linecount + 1;
                                            lineheight = lineheight + 10;
                                        }
                                    }
                                }
                                if (!string.IsNullOrWhiteSpace(EngNo))
                                {

                                    string eng = obj.dr["HSCode"].ToString().Substring(0, 2);
                                    if (eng == "87")
                                    {
                                        for (int k = 0; sno1.Length < 5; k++)
                                        {
                                            sno1 = " " + sno1;
                                        }
                                        if (newcasccode != oldcasccode)
                                        {
                                            if (pgheight - 82 > lineheight)
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
                                                ItemHeaderprint(decltype[0].ToString().Substring(0, decltype[0].ToString().Length - 1).ToUpper());
                                            }
                                            if (pgheight - 82 > lineheight)
                                            {
                                                newcasccode = obj3.dr["CASCId"].ToString();
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
                                                ItemHeaderprint(decltype[0].ToString().Substring(0, decltype[0].ToString().Length - 1).ToUpper());

                                                newcasccode = obj3.dr["CASCId"].ToString();
                                                string page042 = "S/NO   ENGINE NO/CHASSIS NO                               ";
                                                iTextSharp.text.Paragraph j3 = new iTextSharp.text.Paragraph(page042, times);
                                                j3.Alignment = Element.ALIGN_LEFT;
                                                j3.SetLeading(0.0f, 1.0f);
                                                document.Add(j3);
                                                Linecount = Linecount + 1;
                                                lineheight = lineheight + 10;
                                            }
                                        }
                                        if (pgheight - 82 > lineheight)
                                        {
                                            string page043 = "" + sno1 + "" + "  " + EngNo.ToUpper() + "/" + Chaseno.ToUpper() + "";
                                            iTextSharp.text.Paragraph j4 = new iTextSharp.text.Paragraph(page043, times);
                                            j4.Alignment = Element.ALIGN_LEFT;
                                            j4.SetLeading(0.0f, 1.0f);
                                            document.Add(j4);
                                            Linecount = Linecount + 1;
                                            lineheight = lineheight + 10;

                                            //document.Add(Line);
                                            //Linecount = Linecount + 1;
                                            //lineheight = lineheight + 10;
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
                                            ItemHeaderprint(decltype[0].ToString().Substring(0, decltype[0].ToString().Length - 1).ToUpper());

                                            string page043 = "" + sno1 + "" + "  " + EngNo.ToUpper() + "/" + Chaseno.ToUpper() + "";
                                            iTextSharp.text.Paragraph j4 = new iTextSharp.text.Paragraph(page043, times);
                                            j4.Alignment = Element.ALIGN_LEFT;
                                            j4.SetLeading(0.0f, 1.0f);
                                            document.Add(j4);
                                            Linecount = Linecount + 1;
                                            lineheight = lineheight + 10;

                                            //document.Add(Line);
                                            //Linecount = Linecount + 1;
                                            //lineheight = lineheight + 10;
                                        }
                                    }
                                }
                            }
                        }
                        if (string.IsNullOrWhiteSpace(EngNo))
                        {
                            EngNo = casccode;
                        }
                        if (pgheight - 82 > lineheight)
                        {
                            if (!string.IsNullOrWhiteSpace(EngNo))
                            {
                                if (pgheight - 92 > lineheight)
                                {
                                    document.Add(Line);
                                    Linecount = Linecount + 1;
                                    lineheight = lineheight + 10;
                                }
                            }
                            Linecount = Linecount + 1;
                            if (lineheight != 140)
                            {
                                BlankSapce(2);
                            }
                            if (pgheight - 82 > lineheight)
                            {
                                if (lineheight != 140)
                                {
                                    document.Add(Line);
                                    Linecount = Linecount + 1;
                                    lineheight = lineheight + 10;
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
                                BlankSapce1(5);
                                //document.NewPage();
                                Linecount = 0;
                                lineheight = 0;
                                ItemHeaderprint(decltype[0].ToString().Substring(0, decltype[0].ToString().Length - 1).ToUpper());
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
                            BlankSapce1(5);
                            //document.NewPage();
                            Linecount = 0;
                            lineheight = 0;
                            ItemHeaderprint(decltype[0].ToString().Substring(0, decltype[0].ToString().Length - 1).ToUpper());
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
                        BlankSapce1(5);
                        Linecount = 0;
                        lineheight = 0;
                    }
                }
            }
            if (pgheight - 82 > lineheight)
            {
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["TradeRemarks"].ToString()))
                {
                    string page323 = "TRADER’S REMARKS                                                            ";
                    iTextSharp.text.Paragraph al4 = new iTextSharp.text.Paragraph(page323, times);
                    al4.Alignment = Element.ALIGN_LEFT;
                    al4.SetLeading(0.0f, 1.0f);
                    document.Add(al4);
                    Linecount = Linecount + 1;
                    lineheight = lineheight + 10;
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
                //BlankSapce1(1);
                document.NewPage();
                BlankSapce1(1);
                Linecount = 0;
                lineheight = 0;
                Detailprintval();

                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["TradeRemarks"].ToString()))
                {
                    string page323 = "TRADER’S REMARKS                                                            ";
                    iTextSharp.text.Paragraph al4 = new iTextSharp.text.Paragraph(page323, times);
                    al4.Alignment = Element.ALIGN_LEFT;
                    al4.SetLeading(0.0f, 1.0f);
                    document.Add(al4);
                    Linecount = Linecount + 1;
                    lineheight = lineheight + 10;
                }
            }

            if (pgheight - 82 > lineheight)
            {
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["TradeRemarks"].ToString()))
                {
                    string page324 = "" + dt.Rows[0]["TradeRemarks"].ToString().ToUpper() + "";
                    iTextSharp.text.Paragraph al5 = new iTextSharp.text.Paragraph(page324, times);
                    al5.Alignment = Element.ALIGN_LEFT;
                    al5.SetLeading(0.0f, 1.0f);
                    document.Add(al5);
                    Linecount = Linecount + 1;
                    lineheight = lineheight + 10;

                    if (pgheight - 82 > lineheight)
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
                        //BlankSapce1(1);
                        document.NewPage();
                        BlankSapce1(1);
                        Linecount = 0;
                        lineheight = 0;
                        Detailprintval();
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
                //BlankSapce1(3);
                document.NewPage();
                BlankSapce1(1);
                Linecount = 0;
                lineheight = 0;
                Detailprintval();

                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["TradeRemarks"].ToString()))
                {
                    string page324 = "" + dt.Rows[0]["TradeRemarks"].ToString().ToUpper() + "";
                    iTextSharp.text.Paragraph al5 = new iTextSharp.text.Paragraph(page324, times);
                    al5.Alignment = Element.ALIGN_LEFT;
                    al5.SetLeading(0.0f, 1.0f);
                    document.Add(al5);
                    Linecount = Linecount + 1;
                    lineheight = lineheight + 10;

                    if (pgheight - 82 > lineheight)
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
                        page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                        iTextSharp.text.Paragraph l3p1 = new iTextSharp.text.Paragraph(page062, times);
                        l3p1.Alignment = Element.ALIGN_LEFT;
                        l3p1.SetLeading(0.0f, 1.0f);
                        //document.Add(l3p1);
                        //BlankSapce1(1);
                        document.NewPage();
                        BlankSapce1(1);
                        Linecount = 0;
                        lineheight = 0;
                        Detailprintval();
                    }
                }
            }



            string csno = "", cName = "", Ctype = "", cVal = "", cVal1 = "";
            MyClass obj5 = new MyClass();
            string Conqury = "select * from ContainerDtl where PermitId='" + dt.Rows[0]["PermitId"].ToString() + "' order by RowNo";
            obj5.dr = obj5.ret_dr(Conqury);
            if (obj5.dr.HasRows)
            {
                while (obj5.dr.Read())
                {
                    csno = obj5.dr["RowNo"].ToString();
                    cName = obj5.dr["ContainerNo"].ToString().ToUpper();
                    Ctype = obj5.dr["Size"].ToString().ToUpper();
                    cVal = obj5.dr["Weight"].ToString();
                    cVal1 = obj5.dr["SealNo"].ToString().ToUpper();
                    if (csno == "1")
                    {
                        if (pgheight - 82 > lineheight)
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
                            //BlankSapce1(1);
                            document.NewPage();
                            BlankSapce1(1);
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

                    if (pgheight - 82 > lineheight)
                    {
                        if (csno.Length < 2)
                        {
                            csno = "0" + csno;
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
                        string page332 = "" + csno + ")" + "  " + cName.ToUpper() + " " + ctype + " " + cVal + " " + cVal1.ToUpper() + "             ";
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
                        //BlankSapce1(3);
                        document.NewPage();
                        BlankSapce1(1);
                        Linecount = 0;
                        lineheight = 0;
                        Detailprintval();

                        if (csno.Length < 2)
                        {
                            csno = "0" + csno;
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
                        string page332 = "" + csno + ")" + "  " + cName.ToUpper() + " " + ctype + " " + cVal + " " + cVal1.ToUpper() + "             ";
                        iTextSharp.text.Paragraph am1 = new iTextSharp.text.Paragraph(page332, times);
                        am1.Alignment = Element.ALIGN_LEFT;
                        am1.SetLeading(0.0f, 1.0f);
                        document.Add(am1);
                        Linecount = Linecount + 1;
                        lineheight = lineheight + 10;

                        //if (pgheight - 82 > lineheight)
                        //{
                        //    document.Add(Line);
                        //    Linecount = Linecount + 1;
                        //    lineheight = lineheight + 10;
                        //}
                        //else
                        //{
                        //    //document.Add(Line);
                        //    Linecount = Linecount + 1;
                        //    lineheight = lineheight + 10;

                        //    msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                        //    page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                        //    iTextSharp.text.Paragraph l3pe = new iTextSharp.text.Paragraph(page062, times);
                        //    l3pe.Alignment = Element.ALIGN_LEFT;
                        //    l3pe.SetLeading(0.0f, 1.0f);
                        //    //document.Add(l3pe);
                        //    //BlankSapce1(1);
                        //    document.NewPage();
                        //    BlankSapce1(1);
                        //    Linecount = 0;
                        //    lineheight = 0;
                        //    Detailprintval();
                        //}

                    }
                }
                if (pgheight - 82 > lineheight)
                {
                    document.Add(Line);
                    Linecount = Linecount + 1;
                    lineheight = lineheight + 10;
                }
                else
                {
                    // document.Add(Line);
                    Linecount = Linecount + 1;
                    lineheight = lineheight + 10;

                    msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                    string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                    iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                    l3p.Alignment = Element.ALIGN_LEFT;
                    l3p.SetLeading(0.0f, 1.0f);
                    //document.Add(l3p);
                    //BlankSapce1(1);
                    document.NewPage();
                    BlankSapce1(1);
                    Linecount = 0;
                    lineheight = 0;
                    Detailprintval();
                }
            }

            if (pgheight - 82 > lineheight)
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
                // document.Add(Line);
                Linecount = Linecount + 1;
                lineheight = lineheight + 10;

                msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                string page062 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
                iTextSharp.text.Paragraph l3p = new iTextSharp.text.Paragraph(page062, times);
                l3p.Alignment = Element.ALIGN_LEFT;
                l3p.SetLeading(0.0f, 1.0f);
                //document.Add(l3p);
                //BlankSapce1(1);
                document.NewPage();
                BlankSapce1(1);
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

            if (pgheight - 82 > lineheight)
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
                //BlankSapce1(1);
                document.NewPage();
                BlankSapce1(1);
                Linecount = 0;
                lineheight = 0;
                Detailprintval();
            }


            if (pgheight - 82 > lineheight)
            {
                BlankSapce(1);
                string page344 = "NAME OF COMPANY: " + comNamedec.ToUpper() + "             ";
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
                //BlankSapce1(1);
                document.NewPage();
                BlankSapce1(1);
                Linecount = 0;
                lineheight = 0;
                Detailprintval();

                BlankSapce(1);
                string page344 = "NAME OF COMPANY: " + comNamedec.ToUpper() + "             ";
                iTextSharp.text.Paragraph an3 = new iTextSharp.text.Paragraph(page344, times);
                an3.Alignment = Element.ALIGN_LEFT;
                an3.SetLeading(0.0f, 1.0f);
                document.Add(an3);
                Linecount = Linecount + 1;
                lineheight = lineheight + 10;

                BlankSapce(1);
            }

            if (pgheight - 82 > lineheight)
            {
                string page346 = "DECLARANT NAME : " + Decname.ToUpper() + "             ";
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
                //BlankSapce1(1);
                document.NewPage();
                BlankSapce1(1);
                Linecount = 0;
                lineheight = 0;
                Detailprintval();

                string page346 = "DECLARANT NAME : " + Decname.ToUpper() + "             ";
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
            if (pgheight - 82 > lineheight)
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
                //BlankSapce1(1);
                document.NewPage();
                BlankSapce1(1);
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

            if (pgheight - 82 > lineheight)
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
                //BlankSapce1(1);
                document.NewPage();
                BlankSapce1(1);
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

            if (pgheight - 82 > lineheight)
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
                //BlankSapce1(1);
                document.NewPage();
                BlankSapce1(1);
                Linecount = 0;
                lineheight = 0;
                Detailprintval();
            }

            if (pgheight - 82 > lineheight)
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
                //BlankSapce1(1);
                document.NewPage();
                BlankSapce1(1);
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
                prmtdt.dr = prmtdt.ret_dr("select Distinct * from InAMDPMT where PermitNumber='" + dt.Rows[0]["PermitNumber"].ToString() + "' order by Sno");
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
                        int partLength = 78;
                        string sentence = cnstr + "" + " - " + prmtdt.dr["ConditionDescription"].ToString();
                        List<string> lines = new List<string>();
                        for (int i = 0; i < sentence.Length; i++)
                        {
                            if (i == 80)
                            {
                                lines.Add(sentence.Substring(0, 80));
                                sentence = sentence.Remove(0, 80);
                                sentence.TrimStart();
                                i = 0;
                            }
                        }
                        lines.Add(sentence);
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
                ojbcon.dr = ojbcon.ret_dr("select * from amndtbl where MSGId='" + dt.Rows[0]["MSGId"].ToString() + "' and DecType='IPTDEC'");
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
                                    int partLength = 80;
                                    string sentence = objki.dr["Desciption"].ToString();
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

                                    int partLength = 80;
                                    string sentence = objki.dr["Desciption"].ToString();
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
                prmtdt.dr = prmtdt.ret_dr("select Distinct * from InPMT where PermitNumber='" + dt.Rows[0]["PermitNumber"].ToString() + "' order by Sno");
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
                        int partLength = 78;
                        string sentence = cnstr + "" + " - " + prmtdt.dr["ConditionDescription"].ToString();
                        List<string> lines = new List<string>();
                        for (int i = 0; i < sentence.Length; i++)
                        {
                            if (i == 80)
                            {
                                lines.Add(sentence.Substring(0, 80));
                                sentence = sentence.Remove(0, 80);
                                sentence.TrimStart();
                                i = 0;
                            }
                        }
                        lines.Add(sentence);
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

            }

            //for (int li = Linecount; li <= 75; li++)
            //{
            //    if (pgheight - 112 > lineheight)
            //    {
            //        string page3625 = "                                       ";
            //        iTextSharp.text.Paragraph ap24 = new iTextSharp.text.Paragraph(page3625, times);
            //        ap24.Alignment = Element.ALIGN_LEFT;
            //        ap24.SetLeading(0.0f, 1.0f);
            //        document.Add(ap24);
            //        lineheight = lineheight + 10;
            //    }
            //}

            //if (Linecount <=72 )
            //{
            //document.Add(Line);
            Linecount = Linecount + 1;

            msgid = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
            string page33591 = "UNIQUE REF : " + unicref + " " + msgid + " " + dt.Rows[0]["MSGId"].ToString().Substring(8) + "";
            iTextSharp.text.Paragraph am401 = new iTextSharp.text.Paragraph(page33591, times);
            am401.Alignment = Element.ALIGN_LEFT;
            am401.SetLeading(0.0f, 1.0f);
            //document.Add(am401);


            //}
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
        private void BlankSapce(int spceval)
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
            string msgid = "";


            for (int j = 1; j <= spceval; j++)
            {
                //string impna4a = "                                                                                ";
                //iTextSharp.text.Paragraph rr = new iTextSharp.text.Paragraph(impna4a, times);
                //rr.Alignment = Element.ALIGN_LEFT;
                //rr.SetLeading(0.0f, 1.0f);
                //document.Add(rr);
                if (pgheight - 82 > lineheight)
                {
                    document.Add(Chunk.NEWLINE);
                    Linecount = Linecount + 1;
                    lineheight = lineheight + 10;
                }
            }
        }
        private void ItemHeaderprint(string Dectype)
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
            Line.Alignment = Element.ALIGN_LEFT;
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
            string pernum = "";
            if (!string.IsNullOrWhiteSpace(dt.Rows[0]["PermitNumber"].ToString()))
            {
                pernum = dt.Rows[0]["PermitNumber"].ToString();
            }
            else
            {
                pernum = "DRAFT";
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

            if (Convert.ToDecimal(lspval) > 0)
            {
                string page011p = "                                             LSP VALUE (S$)                ";
                iTextSharp.text.Paragraph g1g = new iTextSharp.text.Paragraph(page011p, times);
                g1g.Alignment = Element.ALIGN_LEFT;
                g1g.SetLeading(0.0f, 1.0f);
                document.Add(g1g);
                Linecount = Linecount + 1;
                lineheight = lineheight + 10;
            }

            string page013 = "                                             GST AMOUNT (S$)                   ";
            iTextSharp.text.Paragraph g3 = new iTextSharp.text.Paragraph(page013, times);
            g3.Alignment = Element.ALIGN_LEFT;
            g3.SetLeading(0.0f, 1.0f);
            document.Add(g3);
            Linecount = Linecount + 1;
            lineheight = lineheight + 10;

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
            if (Dectype.ToUpper() == "DNG")
            {

            }
            else
            {
                if (Convert.ToDecimal(obj.dr["UnitPrice"].ToString()) > 0)
                {
                    string page015 = "                                             UNIT PRICE & CODE                 ";
                    iTextSharp.text.Paragraph g5 = new iTextSharp.text.Paragraph(page015, times);
                    g5.Alignment = Element.ALIGN_LEFT;
                    g5.SetLeading(0.0f, 1.0f);
                    document.Add(g5);
                    Linecount = Linecount + 1;
                    lineheight = lineheight + 10;
                }
            }
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
            if (Convert.ToDecimal(obj.dr["CustomsDutyAmount"].ToString()) > 0)
            {
                string page016 = "                                             CUSTOMS DUTY PAYABLE(S$)          ";
                iTextSharp.text.Paragraph g6 = new iTextSharp.text.Paragraph(page016, times);
                g6.Alignment = Element.ALIGN_LEFT;
                g6.SetLeading(0.0f, 1.0f);
                document.Add(g6);
                Linecount = Linecount + 1;
                lineheight = lineheight + 10;
            }
            MyClass obj11 = new MyClass();
            string InvQury = "Select * from InvoiceDtl where PermitId='" + dt.Rows[0]["PermitId"].ToString() + "'";
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
            Line.SetLeading(0.0f, 1.0f);

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
            string pernum = "";
            if (!string.IsNullOrWhiteSpace(dt.Rows[0]["PermitNumber"].ToString()))
            {
                pernum = dt.Rows[0]["PermitNumber"].ToString();
            }
            else
            {
                pernum = "DRAFT";
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
        public void printbarcode()
        {
            //string barCode = txtBarcode.Text;
            //System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
            //using (Bitmap bitMap = new Bitmap(barCode.Length * 30, 80))
            //{
            //    using (Graphics graphics = Graphics.FromImage(bitMap))
            //    {
            //        Font oFont = new Font("IDAutomationHC39M", 16);
            //        PointF point = new PointF(2f, 2f);
            //        SolidBrush blackBrush = new SolidBrush(Color.Black);
            //        SolidBrush whiteBrush = new SolidBrush(Color.White);
            //        graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);
            //        graphics.DrawString("*" + barCode + "*", oFont, blackBrush, point);
            //    }
            //    using (MemoryStream ms = new MemoryStream())
            //    {
            //        bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            //        byte[] byteImage = ms.ToArray();

            //        Convert.ToBase64String(byteImage);
            //        imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);


            //    }
            //    PlaceHolder1.Controls.Add(imgBarCode);


        }
        protected void txtJobId_TextChanged(object sender, EventArgs e)
        {
            search();
        }
        public void search()
        {

            //  colorchange();
            changestatuscolor();
            string condidtion = "", str = "";
            string JobId = (GridInPayment.FooterRow.FindControl("txtJobId") as TextBox).Text;
            string MSGId = (GridInPayment.FooterRow.FindControl("txtMSGId") as TextBox).Text;
            string DecDate = (GridInPayment.FooterRow.FindControl("txtDecDate") as TextBox).Text;
            string Createby = (GridInPayment.FooterRow.FindControl("txtCreateby") as TextBox).Text;
            string DeclarationType = (GridInPayment.FooterRow.FindControl("txtDeclarationType") as TextBox).Text;
            string DecId = (GridInPayment.FooterRow.FindControl("txtDecId") as TextBox).Text;
            string ETA = (GridInPayment.FooterRow.FindControl("txtETA") as TextBox).Text;
            string LocalNo = (GridInPayment.FooterRow.FindControl("txtLocalNo") as TextBox).Text;
            string PermitNo = (GridInPayment.FooterRow.FindControl("txtPermitNo") as TextBox).Text;
            string Importer = (GridInPayment.FooterRow.FindControl("txtImporter") as TextBox).Text;
            string InHAWBOBL = (GridInPayment.FooterRow.FindControl("txtInHAWBOBL") as TextBox).Text;
            string MAWBOBL = (GridInPayment.FooterRow.FindControl("txtMAWBOBL") as TextBox).Text;
            string LoadingPortCode = (GridInPayment.FooterRow.FindControl("txtLoadingPortCode") as TextBox).Text;
            string MessageType = (GridInPayment.FooterRow.FindControl("txtMessageType") as TextBox).Text;
            string InwardTransportMode = (GridInPayment.FooterRow.FindControl("txtInwardTransportMode") as TextBox).Text;

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
                    condidtion = condidtion + "convert(varchar, ArrivalDate, 105) like '%" + ETA + "%' and ";
                }

                if (!string.IsNullOrWhiteSpace(LocalNo))
                {
                    condidtion = condidtion + "t1.PermitId like '%" + LocalNo + "%' and ";
                }
                if (!string.IsNullOrWhiteSpace(PermitNo))
                {
                    condidtion = condidtion + "t1.PermitNumber like '%" + PermitNo + "%' and ";
                }
                if (!string.IsNullOrWhiteSpace(Importer))
                {
                    condidtion = condidtion + "t3.Name like '%" + Importer + "%' and ";
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
                    condidtion = condidtion + "t1.LoadingPortCode like '%" + LoadingPortCode + "%' and ";
                }

                if (!string.IsNullOrWhiteSpace(MessageType))
                {
                    condidtion = condidtion + "t1.MessageType like '%" + MessageType + "%' and ";
                }

                if (!string.IsNullOrWhiteSpace(InwardTransportMode))
                {
                    condidtion = condidtion + "t1.InwardTransportMode like '%" + InwardTransportMode + "%' and ";
                }

                if (!string.IsNullOrWhiteSpace(PreviousPermit))
                {
                    condidtion = condidtion + "t1.PreviousPermit like '%" + PreviousPermit + "%' and ";
                }
                if (!string.IsNullOrWhiteSpace(InternalRemarks))
                {
                    condidtion = condidtion + "t1.InternalRemarks like '%" + InternalRemarks + "%' and ";
                }
                //if (!string.IsNullOrWhiteSpace(TermType))
                //{
                //    condidtion = condidtion + "Substring(t5.TermType, 1,Charindex(':', t5.TermType)-1) like '%" + TermType + "%' and ";
                //}


                if (!string.IsNullOrWhiteSpace(Status))
                {
                    condidtion = condidtion + "t1.Status like '%" + Status + "%' and ";
                }

                string SUMMM = "";
                if (!string.IsNullOrWhiteSpace(gstsum))
                {
                    SUMMM = " HAVING SUM(t5.GSTSUMAmount) ='"+ gstsum + "'  ";
                }

                if (!string.IsNullOrWhiteSpace(condidtion))
                {
                    condidtion = condidtion.Substring(0, condidtion.Length - 4);
                }




                if (condidtion == "")
                {
                    if(SUMMM=="")
                    {
                        str = "SELECT   t6.AccountId,t1.Id, t1.JobId, t1.MSGId, CONVERT(varchar, t1.TouchTime, 105) AS DecDate, SUBSTRING(t1.DeclarationType, 1, CHARINDEX(':', t1.DeclarationType) - 1) AS DeclarationType, t1.TouchUser AS Createby, t2.TradeNetMailboxID AS DecId, CONVERT(varchar, t1.ArrivalDate, 105) AS ETA, t1.PermitId AS LocalNo, t1.PermitNumber AS PermitNo, t3.Name AS Importer,STUFF((SELECT distinct(', ' +  US.InHAWBOBL)  FROM ItemDtl US WHERE US.PermitId = t1.PermitId FOR XML PATH('')), 1, 1, '') InHAWBOBL,CASE  WHEN  t1.InwardTransportMode = '4 : Air' THEN t1.MasterAirwayBill  WHEN t1.InwardTransportMode = '1 : Sea'  THEN t1.OceanBillofLadingNo  ELSE ''  END AS MAWBOBL,t1.LoadingPortCode, t1.MessageType, t1.InwardTransportMode, t1.PreviousPermit, t1.InternalRemarks, SUBSTRING(t5.TermType, 1, CHARINDEX(':', t5.TermType) - 1) AS TermType, SUM(t5.GSTSUMAmount) AS GSTSUMAmount,(select Count(ItemNo) from ItemDtl where ItemDtl.PermitId=t1.PermitId) as SumOfItem, t1.Status FROM  InHeaderTbl AS t1 INNER JOIN DeclarantCompany AS t2 ON t1.DeclarantCompanyCode = t2.Code INNER JOIN Importer AS t3 ON t1.ImporterCompanyCode = t3.Code INNER JOIN ItemDtl AS t4 ON t1.PermitId = t4.PermitId   INNER JOIN InvoiceDtl AS t5 ON t1.PermitId = t5.PermitId  INNER JOIN ManageUser AS t6 ON t6.UserId=t1.TouchUser where t6.AccountId='" + Session["AccountId"].ToString() + "'  and t2.TradeNetMailboxID='" + tradmail + "'  GROUP BY t1.Id, t1.JobId, t1.MSGId, t1.TouchTime, t1.TouchUser, t1.DeclarationType, t1.ArrivalDate, t1.PermitId, t1.InwardTransportMode, t1.MasterAirwayBill, t1.OceanBillofLadingNo, t1.LoadingPortCode, t1.MessageType, t1.InwardTransportMode, t1.PreviousPermit, t1.InternalRemarks, t1.Status, t2.TradeNetMailboxID, t3.Name, t5.TermType,t6.AccountId,t1.PermitNumber order by t1.Id Desc";

                    }
                    else
                    {
                        str = "SELECT   t6.AccountId,t1.Id, t1.JobId, t1.MSGId, CONVERT(varchar, t1.TouchTime, 105) AS DecDate, SUBSTRING(t1.DeclarationType, 1, CHARINDEX(':', t1.DeclarationType) - 1) AS DeclarationType, t1.TouchUser AS Createby, t2.TradeNetMailboxID AS DecId, CONVERT(varchar, t1.ArrivalDate, 105) AS ETA, t1.PermitId AS LocalNo, t1.PermitNumber AS PermitNo, t3.Name AS Importer,STUFF((SELECT distinct(', ' +  US.InHAWBOBL)  FROM ItemDtl US WHERE US.PermitId = t1.PermitId FOR XML PATH('')), 1, 1, '') InHAWBOBL,CASE  WHEN  t1.InwardTransportMode = '4 : Air' THEN t1.MasterAirwayBill  WHEN t1.InwardTransportMode = '1 : Sea'  THEN t1.OceanBillofLadingNo  ELSE ''  END AS MAWBOBL,t1.LoadingPortCode, t1.MessageType, t1.InwardTransportMode, t1.PreviousPermit, t1.InternalRemarks, SUBSTRING(t5.TermType, 1, CHARINDEX(':', t5.TermType) - 1) AS TermType, SUM(t5.GSTSUMAmount) AS GSTSUMAmount,(select Count(ItemNo) from ItemDtl where ItemDtl.PermitId=t1.PermitId) as SumOfItem, t1.Status FROM  InHeaderTbl AS t1 INNER JOIN DeclarantCompany AS t2 ON t1.DeclarantCompanyCode = t2.Code INNER JOIN Importer AS t3 ON t1.ImporterCompanyCode = t3.Code INNER JOIN ItemDtl AS t4 ON t1.PermitId = t4.PermitId   INNER JOIN InvoiceDtl AS t5 ON t1.PermitId = t5.PermitId  INNER JOIN ManageUser AS t6 ON t6.UserId=t1.TouchUser where t6.AccountId='" + Session["AccountId"].ToString() + "'  and t2.TradeNetMailboxID='" + tradmail + "'  GROUP BY t1.Id, t1.JobId, t1.MSGId, t1.TouchTime, t1.TouchUser, t1.DeclarationType, t1.ArrivalDate, t1.PermitId, t1.InwardTransportMode, t1.MasterAirwayBill, t1.OceanBillofLadingNo, t1.LoadingPortCode, t1.MessageType, t1.InwardTransportMode, t1.PreviousPermit, t1.InternalRemarks, t1.Status, t2.TradeNetMailboxID, t3.Name, t5.TermType,t6.AccountId,t1.PermitNumber "+ SUMMM + " order by t1.Id Desc";

                    }


                }

                else
                {


                    if (SUMMM == "")
                    {

                        str = "SELECT   t6.AccountId,t1.Id, t1.JobId, t1.MSGId, CONVERT(varchar, t1.TouchTime, 105) AS DecDate, SUBSTRING(t1.DeclarationType, 1, CHARINDEX(':', t1.DeclarationType) - 1) AS DeclarationType, t1.TouchUser AS Createby, t2.TradeNetMailboxID AS DecId, CONVERT(varchar, t1.ArrivalDate, 105) AS ETA, t1.PermitId AS LocalNo, t1.PermitNumber AS PermitNo, t3.Name AS Importer,STUFF((SELECT distinct(', ' +  US.InHAWBOBL)  FROM ItemDtl US WHERE US.PermitId = t1.PermitId FOR XML PATH('')), 1, 1, '') InHAWBOBL,CASE  WHEN  t1.InwardTransportMode = '4 : Air' THEN t1.MasterAirwayBill  WHEN t1.InwardTransportMode = '1 : Sea'  THEN t1.OceanBillofLadingNo  ELSE ''  END AS MAWBOBL,t1.LoadingPortCode, t1.MessageType, t1.InwardTransportMode, t1.PreviousPermit, t1.InternalRemarks, SUBSTRING(t5.TermType, 1, CHARINDEX(':', t5.TermType) - 1) AS TermType, SUM(t5.GSTSUMAmount) AS GSTSUMAmount,(select Count(ItemNo) from ItemDtl where ItemDtl.PermitId=t1.PermitId) as SumOfItem, t1.Status FROM  InHeaderTbl AS t1 INNER JOIN DeclarantCompany AS t2 ON t1.DeclarantCompanyCode = t2.Code INNER JOIN Importer AS t3 ON t1.ImporterCompanyCode = t3.Code INNER JOIN ItemDtl AS t4 ON t1.PermitId = t4.PermitId   INNER JOIN InvoiceDtl AS t5 ON t1.PermitId = t5.PermitId  INNER JOIN ManageUser AS t6 ON t6.UserId=t1.TouchUser where t6.AccountId='" + Session["AccountId"].ToString() + "'   and t2.TradeNetMailboxID='" + tradmail + "'   and " + condidtion + "  GROUP BY t1.Id, t1.JobId, t1.MSGId, t1.TouchTime, t1.TouchUser, t1.DeclarationType, t1.ArrivalDate, t1.PermitId, t1.InwardTransportMode, t1.MasterAirwayBill, t1.OceanBillofLadingNo, t1.LoadingPortCode, t1.MessageType, t1.InwardTransportMode, t1.PreviousPermit, t1.InternalRemarks, t1.Status, t2.TradeNetMailboxID, t3.Name, t5.TermType,t6.AccountId,t1.PermitNumber " + SUMMM + " order by t1.Id Desc";
                    }
                    else
                    {
                        str = "SELECT   t6.AccountId,t1.Id, t1.JobId, t1.MSGId, CONVERT(varchar, t1.TouchTime, 105) AS DecDate, SUBSTRING(t1.DeclarationType, 1, CHARINDEX(':', t1.DeclarationType) - 1) AS DeclarationType, t1.TouchUser AS Createby, t2.TradeNetMailboxID AS DecId, CONVERT(varchar, t1.ArrivalDate, 105) AS ETA, t1.PermitId AS LocalNo, t1.PermitNumber AS PermitNo, t3.Name AS Importer,STUFF((SELECT distinct(', ' +  US.InHAWBOBL)  FROM ItemDtl US WHERE US.PermitId = t1.PermitId FOR XML PATH('')), 1, 1, '') InHAWBOBL,CASE  WHEN  t1.InwardTransportMode = '4 : Air' THEN t1.MasterAirwayBill  WHEN t1.InwardTransportMode = '1 : Sea'  THEN t1.OceanBillofLadingNo  ELSE ''  END AS MAWBOBL,t1.LoadingPortCode, t1.MessageType, t1.InwardTransportMode, t1.PreviousPermit, t1.InternalRemarks, SUBSTRING(t5.TermType, 1, CHARINDEX(':', t5.TermType) - 1) AS TermType, SUM(t5.GSTSUMAmount) AS GSTSUMAmount,(select Count(ItemNo) from ItemDtl where ItemDtl.PermitId=t1.PermitId) as SumOfItem, t1.Status FROM  InHeaderTbl AS t1 INNER JOIN DeclarantCompany AS t2 ON t1.DeclarantCompanyCode = t2.Code INNER JOIN Importer AS t3 ON t1.ImporterCompanyCode = t3.Code INNER JOIN ItemDtl AS t4 ON t1.PermitId = t4.PermitId   INNER JOIN InvoiceDtl AS t5 ON t1.PermitId = t5.PermitId  INNER JOIN ManageUser AS t6 ON t6.UserId=t1.TouchUser where t6.AccountId='" + Session["AccountId"].ToString() + "'   and t2.TradeNetMailboxID='" + tradmail + "'   and " + condidtion + "  GROUP BY t1.Id, t1.JobId, t1.MSGId, t1.TouchTime, t1.TouchUser, t1.DeclarationType, t1.ArrivalDate, t1.PermitId, t1.InwardTransportMode, t1.MasterAirwayBill, t1.OceanBillofLadingNo, t1.LoadingPortCode, t1.MessageType, t1.InwardTransportMode, t1.PreviousPermit, t1.InternalRemarks, t1.Status, t2.TradeNetMailboxID, t3.Name, t5.TermType,t6.AccountId,t1.PermitNumber " + SUMMM + " order by t1.Id Desc";

                    }
                    
                }

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


                    (GridInPayment.FooterRow.FindControl("txtJobId") as TextBox).Text = JobId;
                    (GridInPayment.FooterRow.FindControl("txtMSGId") as TextBox).Text = MSGId;
                    (GridInPayment.FooterRow.FindControl("txtDecDate") as TextBox).Text = DecDate;
                    (GridInPayment.FooterRow.FindControl("txtDeclarationType") as TextBox).Text = DeclarationType;
                    (GridInPayment.FooterRow.FindControl("txtDecId") as TextBox).Text = DecId;
                    (GridInPayment.FooterRow.FindControl("txtETA") as TextBox).Text = ETA;
                    (GridInPayment.FooterRow.FindControl("txtImporter") as TextBox).Text = Importer;
                    (GridInPayment.FooterRow.FindControl("txtInHAWBOBL") as TextBox).Text = InHAWBOBL;
                    (GridInPayment.FooterRow.FindControl("txtMAWBOBL") as TextBox).Text = MAWBOBL;
                    (GridInPayment.FooterRow.FindControl("txtLoadingPortCode") as TextBox).Text = LoadingPortCode;
                    (GridInPayment.FooterRow.FindControl("txtMessageType") as TextBox).Text = MessageType;
                    (GridInPayment.FooterRow.FindControl("txtInwardTransportMode") as TextBox).Text = InwardTransportMode;
                    (GridInPayment.FooterRow.FindControl("txtPreviousPermit") as TextBox).Text = PreviousPermit;
                    (GridInPayment.FooterRow.FindControl("txtInternalRemarks") as TextBox).Text = InternalRemarks;
                   // (GridInPayment.FooterRow.FindControl("txtTermType") as TextBox).Text = TermType;

                    (GridInPayment.FooterRow.FindControl("txtStatus") as TextBox).Text = Status;
                    (GridInPayment.FooterRow.FindControl("txtMSGId") as TextBox).Text = MSGId;
                    (GridInPayment.FooterRow.FindControl("txtJobId") as TextBox).Text = JobId;
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
        protected void txtDecId_TextChanged(object sender, EventArgs e)
        {
            search();
        }
        protected void txtETA_TextChanged(object sender, EventArgs e)
        {
            search();
        }
        protected void txtPermitNo_TextChanged(object sender, EventArgs e)
        {
            search();
        }
        protected void txtImporter_TextChanged(object sender, EventArgs e)
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

        protected void txtLoadingPortCode_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        protected void txtMessageType_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        protected void txtInwardTransportMode_TextChanged(object sender, EventArgs e)
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

        protected void txtTermType_TextChanged(object sender, EventArgs e)
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

        protected void txtCreateby_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        protected void GridInPayment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridInPayment, "Select$" + e.Row.RowIndex);
            //    e.Row.Attributes["style"] = "cursor:pointer";
            //}
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
                    var chk = row.FindControl("CheckBox1") as CheckBox;
                    if (chk.Checked != true)
                    {
                        var invEdit = row.FindControl("ImageButton1") as ImageButton;

                        Label ID1 = (Label)row.FindControl("Id");
                        string ID = ID1.Text;
                        Response.Redirect("Inpayment.aspx?ID=" + ID);
                        // Label ID1 = (Label)grdrow.FindControl("Id");
                        // string ID = ID1.Text;
                        //string ID = lblCode1.Text;
                        //string ID = "4";
                        // ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(900/2);var Mtop = (screen.height/2)-(500/2);window.open( 'Inpayment.aspx?ID=" + ID + "', null, 'height=500,width=2000,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
                    }
                    // Response.Redirect("Inpayment.aspx?ID=" + ID);
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
            //            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(900/2);var Mtop = (screen.height/2)-(500/2);window.open( 'InpaymentView.aspx?ID=" + ID + "', null, 'height=500,width=2000,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
            //        }
            //        //Response.Redirect("InpaymentView.aspx?ID=" + ID);
            //    }
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
                                //string lodport = "select * from [InHeaderTbl] where PermitNumber='IG9C436122K'";
                                //lodobj.dr = lodobj.ret_dr(lodport);
                                //if (lodobj.dr.HasRows)
                                //{
                                //    while (lodobj.dr.Read())
                                //    {
                                //        PermID = lodobj.dr["Id"].ToString();
                                //    }
                                //}
                                Label ID1 = (Label)gvrow.FindControl("lblPermitNo");
                                PermitId = ID1.Text;
                                PermitNO();
                                JobNO();
                                refid();
                                MSGNO();
                                string Touch_user = Session["UserId"].ToString();
                                string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


                                string headertbl = "insert into InHeaderTbl ([Refid],[JobId],[MSGId],[PermitId],[TradeNetMailboxID],[MessageType],[DeclarationType],[PreviousPermit],[CargoPackType],[InwardTransportMode],[BGIndicator],[SupplyIndicator],[ReferenceDocuments],[License],[Recipient],[DeclarantCompanyCode],[ImporterCompanyCode] ,[InwardCarrierAgentCode],[FreightForwarderCode],[ClaimantPartyCode],[HBL],[ArrivalDate],[LoadingPortCode],[VoyageNumber],[VesselName],[OceanBillofLadingNo],[ConveyanceRefNo],[TransportId],[FlightNO],[AircraftRegNo],[MasterAirwayBill],[ReleaseLocation],[ReleaseLocName],[RecepitLocation],[TotalOuterPack],[TotalOuterPackUOM],[TotalGrossWeight],[TotalGrossWeightUOM],[GrossReference],[BlanketStartDate],[TradeRemarks],[InternalRemarks],[CustomerRemarks],[DeclareIndicator],[NumberOfItems],[TotalCIFFOBValue],[TotalGSTTaxAmt],[TotalExDutyAmt],[TotalCusDutyAmt],[TotalODutyAmt],[TotalAmtPay],[Status],[TouchUser],[TouchTime],[PermitNumber],[prmtStatus] )";
                                headertbl = headertbl + "  select  '" + refno + "' as Refid,'" + JobNo + "' as JobId ,'" + MsgNO + "' as MSGID,'" + PermitNo + "' as PermitId,[TradeNetMailboxID],[MessageType],[DeclarationType],[PreviousPermit],[CargoPackType],[InwardTransportMode],[BGIndicator],[SupplyIndicator],[ReferenceDocuments],[License],[Recipient],[DeclarantCompanyCode],[ImporterCompanyCode] ,[InwardCarrierAgentCode],[FreightForwarderCode],[ClaimantPartyCode],[HBL],[ArrivalDate],[LoadingPortCode],[VoyageNumber],[VesselName],[OceanBillofLadingNo],[ConveyanceRefNo],[TransportId],[FlightNO],[AircraftRegNo],[MasterAirwayBill],[ReleaseLocation],[ReleaseLocName],[RecepitLocation],[TotalOuterPack],[TotalOuterPackUOM],[TotalGrossWeight],[TotalGrossWeightUOM],[GrossReference],[BlanketStartDate],[TradeRemarks],[InternalRemarks],[CustomerRemarks],[DeclareIndicator],[NumberOfItems],[TotalCIFFOBValue],[TotalGSTTaxAmt],[TotalExDutyAmt],[TotalCusDutyAmt],[TotalODutyAmt],[TotalAmtPay],'NEW' as [Status],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime],[PermitNumber],'AMD' as [prmtStatus] from InHeaderTbl where [PermitId] = '" + PermitId + "' ";


                                string invoice = "insert into InvoiceDtl ([SNo],[InvoiceNo],[InvoiceDate],[TermType],[AdValoremIndicator],[PreDutyRateIndicator],[SupplierImporterRelationship],[SupplierCode],[ImportPartyCode],[TICurrency],[TIExRate],[TIAmount],[TISAmount],[OTCCharge],[OTCCurrency],[OTCExRate],[OTCAmount],[OTCSAmount],[FCCharge],[FCCurrency],[FCExRate],[FCAmount],[FCSAmount],[ICCharge],[ICCurrency],[ICExRate],[ICAmount],[ICSAmount],[CIFSUMAmount],[GSTPercentage],[GSTSUMAmount],[MessageType],[PermitId],[TouchUser],[TouchTime]  )";
                                invoice = invoice + " select  [SNo],[InvoiceNo],[InvoiceDate],[TermType],[AdValoremIndicator],[PreDutyRateIndicator],[SupplierImporterRelationship],[SupplierCode],[ImportPartyCode],[TICurrency],[TIExRate],[TIAmount],[TISAmount],[OTCCharge],[OTCCurrency],[OTCExRate],[OTCAmount],[OTCSAmount],[FCCharge],[FCCurrency],[FCExRate],[FCAmount],[FCSAmount],[ICCharge],[ICCurrency],[ICExRate],[ICAmount],[ICSAmount],[CIFSUMAmount],[GSTPercentage],[GSTSUMAmount],[MessageType],'" + PermitNo + "' as [PermitId],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime]  from InvoiceDtl where [PermitId] = '" + PermitId + "' ";


                                string item = "insert into ItemDtl ([ItemNo],[PermitId],[MessageType],[HSCode],[Description],[DGIndicator],[Contry],[Brand],[Model],[InHAWBOBL],[DutiableQty],[DutiableUOM],[TotalDutiableQty],[TotalDutiableUOM],[InvoiceQuantity],[HSQty],[HSUOM],[AlcoholPer],[InvoiceNo],[ChkUnitPrice],[UnitPrice],[UnitPriceCurrency],[ExchangeRate],[SumExchangeRate],[TotalLineAmount],[InvoiceCharges],[CIFFOB],[OPQty],[OPUOM],[IPQty],[IPUOM] ,[InPqty],[InPUOM],[ImPQty],[ImPUOM],[PreferentialCode],[GSTRate],[GSTUOM],[GSTAmount],[ExciseDutyRate],[ExciseDutyUOM],[ExciseDutyAmount],[CustomsDutyRate],[CustomsDutyUOM],[CustomsDutyAmount],[OtherTaxRate],[OtherTaxUOM],[OtherTaxAmount],[CurrentLot],[PreviousLot],[LSPValue],[Making],[ShippingMarks1],[ShippingMarks2],[ShippingMarks3],[ShippingMarks4],[TouchUser],[TouchTime])";
                                item = item + " select  [ItemNo],'" + PermitNo + "' as [PermitId],[MessageType],[HSCode],[Description],[DGIndicator],[Contry],[Brand],[Model],[InHAWBOBL],[DutiableQty],[DutiableUOM],[TotalDutiableQty],[TotalDutiableUOM],[InvoiceQuantity],[HSQty],[HSUOM],[AlcoholPer],[InvoiceNo],[ChkUnitPrice],[UnitPrice],[UnitPriceCurrency],[ExchangeRate],[SumExchangeRate],[TotalLineAmount],[InvoiceCharges],[CIFFOB],[OPQty],[OPUOM],[IPQty],[IPUOM] ,[InPqty],[InPUOM],[ImPQty],[ImPUOM],[PreferentialCode],[GSTRate],[GSTUOM],[GSTAmount],[ExciseDutyRate],[ExciseDutyUOM],[ExciseDutyAmount],[CustomsDutyRate],[CustomsDutyUOM],[CustomsDutyAmount],[OtherTaxRate],[OtherTaxUOM],[OtherTaxAmount],[CurrentLot],[PreviousLot],[LSPValue],[Making],[ShippingMarks1],[ShippingMarks2],[ShippingMarks3],[ShippingMarks4],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime]  from ItemDtl where [PermitId] = '" + PermitId + "' ";


                                string container = "insert into ContainerDtl ([PermitId],[RowNo],[ContainerNo],[Size],[Weight],[SealNo],[MessageType],[TouchUser],[TouchTime])";
                                container = container + " select  '" + PermitNo + "' as [PermitId],[RowNo],[ContainerNo],[Size],[Weight],[SealNo],[MessageType],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime]  from ContainerDtl where [PermitId] = '" + PermitId + "' ";


                                string CPCDtl = "insert into CPCDtl ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])";
                                CPCDtl = CPCDtl + " select  '" + PermitNo + "' as [PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime]  from CPCDtl where [PermitId] = '" + PermitId + "' ";


                                string CASCDtl = "insert into CASCDtl ([ItemNo],[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime],[CASCId])";
                                CASCDtl = CASCDtl + "  select  [ItemNo],[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],'" + PermitNo + "' as [PermitId],[MessageType],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime],[CASCId]  from CASCDtl where [PermitId] = '" + PermitId + "' ";


                                string file = "insert into InFile ([Sno],[Name],[ContentType],[Data],[DocumentType],[InPaymentId],[TouchUser],[TouchTime] )";
                                file = file + " select  [Sno],[Name],[ContentType],[Data],[DocumentType],'" + PermitNo + "' as [InPaymentId],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime]  from InFile where [InPaymentId] = '" + PermitId + "' ";

                                //string PerCount = ("INSERT INTO [dbo].[PermitCount] ([PermitId],[MessageType],[AccountId],[TouchUser],[TouchTime])  VALUES ('" + PermitNo + "','IPTDEC','" + Session["AccountId"].ToString() + "','" + Touch_user + "','" + strTime + "')");
                                string PerCount = ("INSERT INTO [dbo].[PermitCount] ([PermitId],[MessageType],[AccountId],[MsgId],[TouchUser],[TouchTime])  VALUES ('" + PermitNo + "','IPTDEC','" + Session["AccountId"].ToString() + "','" + MsgNO + "','" + Touch_user + "','" + strTime + "')");

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
                                string strBindTxtBox = "select * from InHeaderTbl where PermitId='" + PermitNo + "'";
                                obj.dr = obj.ret_dr(strBindTxtBox);
                                while (obj.dr.Read())
                                {
                                    string idpass = obj.dr["ID"].ToString();
                                    Response.Redirect("Inpayment.aspx?ID=" + idpass + "&Update=" + Drppermitedit.SelectedItem.ToString() + "");

                                }
                                //Response.Redirect("Inpayment.aspx?Id=" + ID + "&Update=" + Drppermitedit.SelectedItem.ToString() + "");
                                //}
                            }

                        }
                        else if (Drppermitedit.SelectedItem.ToString() == "CANCEL")
                        {
                            //foreach (GridViewRow gvrow in GridInPayment.Rows)
                            //{
                            var checkbox = gvrow.FindControl("CheckBox1") as CheckBox;
                            if (checkbox.Checked)
                            {
                                //Label ID1 = (Label)gvrow.FindControl("Id");
                                //string ID = ID1.Text;
                                //MyClass lodobj = new MyClass();
                                //string lodport = "select * from [InHeaderTbl] where PermitNumber='IG9C436122K'";
                                //lodobj.dr = lodobj.ret_dr(lodport);
                                //if (lodobj.dr.HasRows)
                                //{
                                //    while (lodobj.dr.Read())
                                //    {
                                //        PermID = lodobj.dr["Id"].ToString();
                                //    }
                                //}
                                Label ID1 = (Label)gvrow.FindControl("lblPermitNo");
                                PermitId = ID1.Text;
                                PermitNO();
                                JobNO();
                                refid();
                                MSGNO();
                                string Touch_user = Session["UserId"].ToString();
                                string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


                                string headertbl = "insert into InHeaderTbl ([Refid],[JobId],[MSGId],[PermitId],[TradeNetMailboxID],[MessageType],[DeclarationType],[PreviousPermit],[CargoPackType],[InwardTransportMode],[BGIndicator],[SupplyIndicator],[ReferenceDocuments],[License],[Recipient],[DeclarantCompanyCode],[ImporterCompanyCode] ,[InwardCarrierAgentCode],[FreightForwarderCode],[ClaimantPartyCode],[HBL],[ArrivalDate],[LoadingPortCode],[VoyageNumber],[VesselName],[OceanBillofLadingNo],[ConveyanceRefNo],[TransportId],[FlightNO],[AircraftRegNo],[MasterAirwayBill],[ReleaseLocation],[ReleaseLocName],[RecepitLocation],[TotalOuterPack],[TotalOuterPackUOM],[TotalGrossWeight],[TotalGrossWeightUOM],[GrossReference],[BlanketStartDate],[TradeRemarks],[InternalRemarks],[CustomerRemarks],[DeclareIndicator],[NumberOfItems],[TotalCIFFOBValue],[TotalGSTTaxAmt],[TotalExDutyAmt],[TotalCusDutyAmt],[TotalODutyAmt],[TotalAmtPay],[Status],[TouchUser],[TouchTime],[PermitNumber],[prmtStatus] )";
                                headertbl = headertbl + "  select  '" + refno + "' as Refid,'" + JobNo + "' as JobId ,'" + MsgNO + "' as MSGID,'" + PermitNo + "' as PermitId,[TradeNetMailboxID],[MessageType],[DeclarationType],[PreviousPermit],[CargoPackType],[InwardTransportMode],[BGIndicator],[SupplyIndicator],[ReferenceDocuments],[License],[Recipient],[DeclarantCompanyCode],[ImporterCompanyCode] ,[InwardCarrierAgentCode],[FreightForwarderCode],[ClaimantPartyCode],[HBL],[ArrivalDate],[LoadingPortCode],[VoyageNumber],[VesselName],[OceanBillofLadingNo],[ConveyanceRefNo],[TransportId],[FlightNO],[AircraftRegNo],[MasterAirwayBill],[ReleaseLocation],[ReleaseLocName],[RecepitLocation],[TotalOuterPack],[TotalOuterPackUOM],[TotalGrossWeight],[TotalGrossWeightUOM],[GrossReference],[BlanketStartDate],[TradeRemarks],[InternalRemarks],[CustomerRemarks],[DeclareIndicator],[NumberOfItems],[TotalCIFFOBValue],[TotalGSTTaxAmt],[TotalExDutyAmt],[TotalCusDutyAmt],[TotalODutyAmt],[TotalAmtPay],'NEW' as [Status],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime],[PermitNumber],'CNL' as [prmtStatus] from InHeaderTbl where [PermitId] = '" + PermitId + "' ";


                                string invoice = "insert into InvoiceDtl ([SNo],[InvoiceNo],[InvoiceDate],[TermType],[AdValoremIndicator],[PreDutyRateIndicator],[SupplierImporterRelationship],[SupplierCode],[ImportPartyCode],[TICurrency],[TIExRate],[TIAmount],[TISAmount],[OTCCharge],[OTCCurrency],[OTCExRate],[OTCAmount],[OTCSAmount],[FCCharge],[FCCurrency],[FCExRate],[FCAmount],[FCSAmount],[ICCharge],[ICCurrency],[ICExRate],[ICAmount],[ICSAmount],[CIFSUMAmount],[GSTPercentage],[GSTSUMAmount],[MessageType],[PermitId],[TouchUser],[TouchTime]  )";
                                invoice = invoice + " select  [SNo],[InvoiceNo],[InvoiceDate],[TermType],[AdValoremIndicator],[PreDutyRateIndicator],[SupplierImporterRelationship],[SupplierCode],[ImportPartyCode],[TICurrency],[TIExRate],[TIAmount],[TISAmount],[OTCCharge],[OTCCurrency],[OTCExRate],[OTCAmount],[OTCSAmount],[FCCharge],[FCCurrency],[FCExRate],[FCAmount],[FCSAmount],[ICCharge],[ICCurrency],[ICExRate],[ICAmount],[ICSAmount],[CIFSUMAmount],[GSTPercentage],[GSTSUMAmount],[MessageType],'" + PermitNo + "' as [PermitId],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime]  from InvoiceDtl where [PermitId] = '" + PermitId + "' ";


                                string item = "insert into ItemDtl ([ItemNo],[PermitId],[MessageType],[HSCode],[Description],[DGIndicator],[Contry],[Brand],[Model],[InHAWBOBL],[DutiableQty],[DutiableUOM],[TotalDutiableQty],[TotalDutiableUOM],[InvoiceQuantity],[HSQty],[HSUOM],[AlcoholPer],[InvoiceNo],[ChkUnitPrice],[UnitPrice],[UnitPriceCurrency],[ExchangeRate],[SumExchangeRate],[TotalLineAmount],[InvoiceCharges],[CIFFOB],[OPQty],[OPUOM],[IPQty],[IPUOM] ,[InPqty],[InPUOM],[ImPQty],[ImPUOM],[PreferentialCode],[GSTRate],[GSTUOM],[GSTAmount],[ExciseDutyRate],[ExciseDutyUOM],[ExciseDutyAmount],[CustomsDutyRate],[CustomsDutyUOM],[CustomsDutyAmount],[OtherTaxRate],[OtherTaxUOM],[OtherTaxAmount],[CurrentLot],[PreviousLot],[LSPValue],[Making],[ShippingMarks1],[ShippingMarks2],[ShippingMarks3],[ShippingMarks4],[TouchUser],[TouchTime])";
                                item = item + " select  [ItemNo],'" + PermitNo + "' as [PermitId],[MessageType],[HSCode],[Description],[DGIndicator],[Contry],[Brand],[Model],[InHAWBOBL],[DutiableQty],[DutiableUOM],[TotalDutiableQty],[TotalDutiableUOM],[InvoiceQuantity],[HSQty],[HSUOM],[AlcoholPer],[InvoiceNo],[ChkUnitPrice],[UnitPrice],[UnitPriceCurrency],[ExchangeRate],[SumExchangeRate],[TotalLineAmount],[InvoiceCharges],[CIFFOB],[OPQty],[OPUOM],[IPQty],[IPUOM] ,[InPqty],[InPUOM],[ImPQty],[ImPUOM],[PreferentialCode],[GSTRate],[GSTUOM],[GSTAmount],[ExciseDutyRate],[ExciseDutyUOM],[ExciseDutyAmount],[CustomsDutyRate],[CustomsDutyUOM],[CustomsDutyAmount],[OtherTaxRate],[OtherTaxUOM],[OtherTaxAmount],[CurrentLot],[PreviousLot],[LSPValue],[Making],[ShippingMarks1],[ShippingMarks2],[ShippingMarks3],[ShippingMarks4],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime]  from ItemDtl where [PermitId] = '" + PermitId + "' ";


                                string container = "insert into ContainerDtl ([PermitId],[RowNo],[ContainerNo],[Size],[Weight],[SealNo],[MessageType],[TouchUser],[TouchTime])";
                                container = container + " select  '" + PermitNo + "' as [PermitId],[RowNo],[ContainerNo],[Size],[Weight],[SealNo],[MessageType],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime]  from ContainerDtl where [PermitId] = '" + PermitId + "' ";


                                string CPCDtl = "insert into CPCDtl ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])";
                                CPCDtl = CPCDtl + " select  '" + PermitNo + "' as [PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime]  from CPCDtl where [PermitId] = '" + PermitId + "' ";


                                string CASCDtl = "insert into CASCDtl ([ItemNo],[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime],[CASCId])";
                                CASCDtl = CASCDtl + "  select  [ItemNo],[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],'" + PermitNo + "' as [PermitId],[MessageType],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime],[CASCId]  from CASCDtl where [PermitId] = '" + PermitId + "' ";


                                string file = "insert into InFile ([Sno],[Name],[ContentType],[Data],[DocumentType],[InPaymentId],[TouchUser],[TouchTime] )";
                                file = file + " select  [Sno],[Name],[ContentType],[Data],[DocumentType],'" + PermitNo + "' as [InPaymentId],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime]  from InFile where [InPaymentId] = '" + PermitId + "' ";

                                //string PerCount = ("INSERT INTO [dbo].[PermitCount] ([PermitId],[MessageType],[AccountId],[TouchUser],[TouchTime])  VALUES ('" + PermitNo + "','IPTDEC','" + Session["AccountId"].ToString() + "','" + Touch_user + "','" + strTime + "')");
                                string PerCount = ("INSERT INTO [dbo].[PermitCount] ([PermitId],[MessageType],[AccountId],[MsgId],[TouchUser],[TouchTime])  VALUES ('" + PermitNo + "','IPTDEC','" + Session["AccountId"].ToString() + "','" + MsgNO + "','" + Touch_user + "','" + strTime + "')");

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
                                string strBindTxtBox = "select * from InHeaderTbl where PermitId='" + PermitNo + "'";
                                obj.dr = obj.ret_dr(strBindTxtBox);
                                while (obj.dr.Read())
                                {
                                    string idpass = obj.dr["ID"].ToString();
                                    Response.Redirect("Inpayment.aspx?ID=" + idpass + "&Update=" + Drppermitedit.SelectedItem.ToString() + "");

                                }
                                //Response.Redirect("Inpayment.aspx?Id=" + ID + "&Update=" + Drppermitedit.SelectedItem.ToString() + "");
                                //  }
                            }
                        }
                        else if (Drppermitedit.SelectedItem.ToString() == "REFUND")
                        {
                            //foreach (GridViewRow gvrow in GridInPayment.Rows)
                            //{
                            var checkbox = gvrow.FindControl("CheckBox1") as CheckBox;
                            if (checkbox.Checked)
                            {
                                //Label ID1 = (Label)gvrow.FindControl("Id");
                                //string ID = ID1.Text;
                                //MyClass lodobj = new MyClass();
                                //string lodport = "select * from [InHeaderTbl] where PermitNumber='IG9C436122K'";
                                //lodobj.dr = lodobj.ret_dr(lodport);
                                //if (lodobj.dr.HasRows)
                                //{
                                //    while (lodobj.dr.Read())
                                //    {
                                //        PermID = lodobj.dr["Id"].ToString();
                                //    }
                                //}
                                Label ID1 = (Label)gvrow.FindControl("lblPermitNo");
                                PermitId = ID1.Text;
                                PermitNO();
                                JobNO();
                                refid();
                                MSGNO();
                                string Touch_user = Session["UserId"].ToString();
                                string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


                                string headertbl = "insert into InHeaderTbl ([Refid],[JobId],[MSGId],[PermitId],[TradeNetMailboxID],[MessageType],[DeclarationType],[PreviousPermit],[CargoPackType],[InwardTransportMode],[BGIndicator],[SupplyIndicator],[ReferenceDocuments],[License],[Recipient],[DeclarantCompanyCode],[ImporterCompanyCode] ,[InwardCarrierAgentCode],[FreightForwarderCode],[ClaimantPartyCode],[HBL],[ArrivalDate],[LoadingPortCode],[VoyageNumber],[VesselName],[OceanBillofLadingNo],[ConveyanceRefNo],[TransportId],[FlightNO],[AircraftRegNo],[MasterAirwayBill],[ReleaseLocation],[ReleaseLocName],[RecepitLocation],[TotalOuterPack],[TotalOuterPackUOM],[TotalGrossWeight],[TotalGrossWeightUOM],[GrossReference],[BlanketStartDate],[TradeRemarks],[InternalRemarks],[CustomerRemarks],[DeclareIndicator],[NumberOfItems],[TotalCIFFOBValue],[TotalGSTTaxAmt],[TotalExDutyAmt],[TotalCusDutyAmt],[TotalODutyAmt],[TotalAmtPay],[Status],[TouchUser],[TouchTime],[PermitNumber],[prmtStatus] )";
                                headertbl = headertbl + "  select  '" + refno + "' as Refid,'" + JobNo + "' as JobId ,'" + MsgNO + "' as MSGID,'" + PermitNo + "' as PermitId,[TradeNetMailboxID],[MessageType],[DeclarationType],[PreviousPermit],[CargoPackType],[InwardTransportMode],[BGIndicator],[SupplyIndicator],[ReferenceDocuments],[License],[Recipient],[DeclarantCompanyCode],[ImporterCompanyCode] ,[InwardCarrierAgentCode],[FreightForwarderCode],[ClaimantPartyCode],[HBL],[ArrivalDate],[LoadingPortCode],[VoyageNumber],[VesselName],[OceanBillofLadingNo],[ConveyanceRefNo],[TransportId],[FlightNO],[AircraftRegNo],[MasterAirwayBill],[ReleaseLocation],[ReleaseLocName],[RecepitLocation],[TotalOuterPack],[TotalOuterPackUOM],[TotalGrossWeight],[TotalGrossWeightUOM],[GrossReference],[BlanketStartDate],[TradeRemarks],[InternalRemarks],[CustomerRemarks],[DeclareIndicator],[NumberOfItems],[TotalCIFFOBValue],[TotalGSTTaxAmt],[TotalExDutyAmt],[TotalCusDutyAmt],[TotalODutyAmt],[TotalAmtPay],'NEW' as [Status],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime],[PermitNumber],'RFD' as [prmtStatus] from InHeaderTbl where [PermitId] = '" + PermitId + "' ";


                                string invoice = "insert into InvoiceDtl ([SNo],[InvoiceNo],[InvoiceDate],[TermType],[AdValoremIndicator],[PreDutyRateIndicator],[SupplierImporterRelationship],[SupplierCode],[ImportPartyCode],[TICurrency],[TIExRate],[TIAmount],[TISAmount],[OTCCharge],[OTCCurrency],[OTCExRate],[OTCAmount],[OTCSAmount],[FCCharge],[FCCurrency],[FCExRate],[FCAmount],[FCSAmount],[ICCharge],[ICCurrency],[ICExRate],[ICAmount],[ICSAmount],[CIFSUMAmount],[GSTPercentage],[GSTSUMAmount],[MessageType],[PermitId],[TouchUser],[TouchTime]  )";
                                invoice = invoice + " select  [SNo],[InvoiceNo],[InvoiceDate],[TermType],[AdValoremIndicator],[PreDutyRateIndicator],[SupplierImporterRelationship],[SupplierCode],[ImportPartyCode],[TICurrency],[TIExRate],[TIAmount],[TISAmount],[OTCCharge],[OTCCurrency],[OTCExRate],[OTCAmount],[OTCSAmount],[FCCharge],[FCCurrency],[FCExRate],[FCAmount],[FCSAmount],[ICCharge],[ICCurrency],[ICExRate],[ICAmount],[ICSAmount],[CIFSUMAmount],[GSTPercentage],[GSTSUMAmount],[MessageType],'" + PermitNo + "' as [PermitId],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime]  from InvoiceDtl where [PermitId] = '" + PermitId + "' ";


                                string item = "insert into ItemDtl ([ItemNo],[PermitId],[MessageType],[HSCode],[Description],[DGIndicator],[Contry],[Brand],[Model],[InHAWBOBL],[DutiableQty],[DutiableUOM],[TotalDutiableQty],[TotalDutiableUOM],[InvoiceQuantity],[HSQty],[HSUOM],[AlcoholPer],[InvoiceNo],[ChkUnitPrice],[UnitPrice],[UnitPriceCurrency],[ExchangeRate],[SumExchangeRate],[TotalLineAmount],[InvoiceCharges],[CIFFOB],[OPQty],[OPUOM],[IPQty],[IPUOM] ,[InPqty],[InPUOM],[ImPQty],[ImPUOM],[PreferentialCode],[GSTRate],[GSTUOM],[GSTAmount],[ExciseDutyRate],[ExciseDutyUOM],[ExciseDutyAmount],[CustomsDutyRate],[CustomsDutyUOM],[CustomsDutyAmount],[OtherTaxRate],[OtherTaxUOM],[OtherTaxAmount],[CurrentLot],[PreviousLot],[LSPValue],[Making],[ShippingMarks1],[ShippingMarks2],[ShippingMarks3],[ShippingMarks4],[TouchUser],[TouchTime])";
                                item = item + " select  [ItemNo],'" + PermitNo + "' as [PermitId],[MessageType],[HSCode],[Description],[DGIndicator],[Contry],[Brand],[Model],[InHAWBOBL],[DutiableQty],[DutiableUOM],[TotalDutiableQty],[TotalDutiableUOM],[InvoiceQuantity],[HSQty],[HSUOM],[AlcoholPer],[InvoiceNo],[ChkUnitPrice],[UnitPrice],[UnitPriceCurrency],[ExchangeRate],[SumExchangeRate],[TotalLineAmount],[InvoiceCharges],[CIFFOB],[OPQty],[OPUOM],[IPQty],[IPUOM] ,[InPqty],[InPUOM],[ImPQty],[ImPUOM],[PreferentialCode],[GSTRate],[GSTUOM],[GSTAmount],[ExciseDutyRate],[ExciseDutyUOM],[ExciseDutyAmount],[CustomsDutyRate],[CustomsDutyUOM],[CustomsDutyAmount],[OtherTaxRate],[OtherTaxUOM],[OtherTaxAmount],[CurrentLot],[PreviousLot],[LSPValue],[Making],[ShippingMarks1],[ShippingMarks2],[ShippingMarks3],[ShippingMarks4],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime]  from ItemDtl where [PermitId] = '" + PermitId + "' ";


                                string container = "insert into ContainerDtl ([PermitId],[RowNo],[ContainerNo],[Size],[Weight],[SealNo],[MessageType],[TouchUser],[TouchTime])";
                                container = container + " select  '" + PermitNo + "' as [PermitId],[RowNo],[ContainerNo],[Size],[Weight],[SealNo],[MessageType],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime]  from ContainerDtl where [PermitId] = '" + PermitId + "' ";


                                string CPCDtl = "insert into CPCDtl ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])";
                                CPCDtl = CPCDtl + " select  '" + PermitNo + "' as [PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime]  from CPCDtl where [PermitId] = '" + PermitId + "' ";


                                string CASCDtl = "insert into CASCDtl ([ItemNo],[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime],[CASCId])";
                                CASCDtl = CASCDtl + "  select  [ItemNo],[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],'" + PermitNo + "' as [PermitId],[MessageType],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime],[CASCId]  from CASCDtl where [PermitId] = '" + PermitId + "' ";


                                string file = "insert into InFile ([Sno],[Name],[ContentType],[Data],[DocumentType],[InPaymentId],[TouchUser],[TouchTime] )";
                                file = file + " select  [Sno],[Name],[ContentType],[Data],[DocumentType],'" + PermitNo + "' as [InPaymentId],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime]  from InFile where [InPaymentId] = '" + PermitId + "' ";

                                //string PerCount = ("INSERT INTO [dbo].[PermitCount] ([PermitId],[MessageType],[AccountId],[TouchUser],[TouchTime])  VALUES ('" + PermitNo + "','IPTDEC','" + Session["AccountId"].ToString() + "','" + Touch_user + "','" + strTime + "')");
                                string PerCount = ("INSERT INTO [dbo].[PermitCount] ([PermitId],[MessageType],[AccountId],[MsgId],[TouchUser],[TouchTime])  VALUES ('" + PermitNo + "','IPTDEC','" + Session["AccountId"].ToString() + "','" + MsgNO + "','" + Touch_user + "','" + strTime + "')");

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
                                string strBindTxtBox = "select * from InHeaderTbl where PermitId='" + PermitNo + "'";
                                obj.dr = obj.ret_dr(strBindTxtBox);
                                while (obj.dr.Read())
                                {
                                    string idpass = obj.dr["ID"].ToString();
                                    Response.Redirect("Inpayment.aspx?ID=" + idpass + "&Update=" + Drppermitedit.SelectedItem.ToString() + "");

                                }
                                //Response.Redirect("Inpayment.aspx?Id=" + ID + "&Update=" + Drppermitedit.SelectedItem.ToString() + "");
                            }
                            // }
                        }
                    }
                }
            }

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


                    string headertbl = "insert into InHeaderTbl ([Refid],[JobId],[MSGId],[PermitId],[TradeNetMailboxID],[MessageType],[DeclarationType],[PreviousPermit],[CargoPackType],[InwardTransportMode],[BGIndicator],[SupplyIndicator],[ReferenceDocuments],[License],[Recipient],[DeclarantCompanyCode],[ImporterCompanyCode] ,[InwardCarrierAgentCode],[FreightForwarderCode],[ClaimantPartyCode],[HBL],[ArrivalDate],[LoadingPortCode],[VoyageNumber],[VesselName],[OceanBillofLadingNo],[ConveyanceRefNo],[TransportId],[FlightNO],[AircraftRegNo],[MasterAirwayBill],[ReleaseLocation],[ReleaseLocName],[RecepitLocation],[RecepitLocName],[TotalOuterPack],[TotalOuterPackUOM],[TotalGrossWeight],[TotalGrossWeightUOM],[GrossReference],[BlanketStartDate],[TradeRemarks],[InternalRemarks],[CustomerRemarks],[DeclareIndicator],[NumberOfItems],[TotalCIFFOBValue],[TotalGSTTaxAmt],[TotalExDutyAmt],[TotalCusDutyAmt],[TotalODutyAmt],[TotalAmtPay],[Status],[TouchUser],[TouchTime],[PermitNumber],[prmtStatus] )";
                    headertbl = headertbl + "  select  '" + refno + "' as Refid,'" + JobNo + "' as JobId ,'" + MsgNO + "' as MSGID,'" + PermitNo + "' as PermitId,[TradeNetMailboxID],[MessageType],[DeclarationType],[PreviousPermit],[CargoPackType],[InwardTransportMode],[BGIndicator],[SupplyIndicator],[ReferenceDocuments],[License],[Recipient],[DeclarantCompanyCode],[ImporterCompanyCode] ,[InwardCarrierAgentCode],[FreightForwarderCode],[ClaimantPartyCode],[HBL],[ArrivalDate],[LoadingPortCode],[VoyageNumber],[VesselName],[OceanBillofLadingNo],[ConveyanceRefNo],[TransportId],[FlightNO],[AircraftRegNo],[MasterAirwayBill],[ReleaseLocation],[ReleaseLocName],[RecepitLocation],[RecepitLocName],[TotalOuterPack],[TotalOuterPackUOM],[TotalGrossWeight],[TotalGrossWeightUOM],[GrossReference],[BlanketStartDate],[TradeRemarks],[InternalRemarks],[CustomerRemarks],[DeclareIndicator],[NumberOfItems],[TotalCIFFOBValue],[TotalGSTTaxAmt],[TotalExDutyAmt],[TotalCusDutyAmt],[TotalODutyAmt],[TotalAmtPay],'NEW' as [Status],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime],'' as  [PermitNumber],'NEW' as [prmtStatus] from InHeaderTbl where [PermitId] = '" + PermitId + "' ";


                    string invoice = "insert into InvoiceDtl ([SNo],[InvoiceNo],[InvoiceDate],[TermType],[AdValoremIndicator],[PreDutyRateIndicator],[SupplierImporterRelationship],[SupplierCode],[ImportPartyCode],[TICurrency],[TIExRate],[TIAmount],[TISAmount],[OTCCharge],[OTCCurrency],[OTCExRate],[OTCAmount],[OTCSAmount],[FCCharge],[FCCurrency],[FCExRate],[FCAmount],[FCSAmount],[ICCharge],[ICCurrency],[ICExRate],[ICAmount],[ICSAmount],[CIFSUMAmount],[GSTPercentage],[GSTSUMAmount],[MessageType],[PermitId],[TouchUser],[TouchTime]  )";
                    invoice = invoice + " select  [SNo],[InvoiceNo],[InvoiceDate],[TermType],[AdValoremIndicator],[PreDutyRateIndicator],[SupplierImporterRelationship],[SupplierCode],[ImportPartyCode],[TICurrency],[TIExRate],[TIAmount],[TISAmount],[OTCCharge],[OTCCurrency],[OTCExRate],[OTCAmount],[OTCSAmount],[FCCharge],[FCCurrency],[FCExRate],[FCAmount],[FCSAmount],[ICCharge],[ICCurrency],[ICExRate],[ICAmount],[ICSAmount],[CIFSUMAmount],[GSTPercentage],[GSTSUMAmount],[MessageType],'" + PermitNo + "' as [PermitId],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime]  from InvoiceDtl where [PermitId] = '" + PermitId + "' ";


                    string item = "insert into ItemDtl ([ItemNo],[PermitId],[MessageType],[HSCode],[Description],[DGIndicator],[Contry],[Brand],[Model],[InHAWBOBL],[DutiableQty],[DutiableUOM],[TotalDutiableQty],[TotalDutiableUOM],[InvoiceQuantity],[HSQty],[HSUOM],[AlcoholPer],[InvoiceNo],[ChkUnitPrice],[UnitPrice],[UnitPriceCurrency],[ExchangeRate],[SumExchangeRate],[TotalLineAmount],[InvoiceCharges],[CIFFOB],[OPQty],[OPUOM],[IPQty],[IPUOM] ,[InPqty],[InPUOM],[ImPQty],[ImPUOM],[PreferentialCode],[GSTRate],[GSTUOM],[GSTAmount],[ExciseDutyRate],[ExciseDutyUOM],[ExciseDutyAmount],[CustomsDutyRate],[CustomsDutyUOM],[CustomsDutyAmount],[OtherTaxRate],[OtherTaxUOM],[OtherTaxAmount],[CurrentLot],[PreviousLot],[LSPValue],[Making],[ShippingMarks1],[ShippingMarks2],[ShippingMarks3],[ShippingMarks4],[VehicleType],[EngineCapcity],[EngineCapUOM],[orignaldatereg],[TouchUser],[TouchTime])";
                    item = item + " select  [ItemNo],'" + PermitNo + "' as [PermitId],[MessageType],[HSCode],[Description],[DGIndicator],[Contry],[Brand],[Model],[InHAWBOBL],[DutiableQty],[DutiableUOM],[TotalDutiableQty],[TotalDutiableUOM],[InvoiceQuantity],[HSQty],[HSUOM],[AlcoholPer],[InvoiceNo],[ChkUnitPrice],[UnitPrice],[UnitPriceCurrency],[ExchangeRate],[SumExchangeRate],[TotalLineAmount],[InvoiceCharges],[CIFFOB],[OPQty],[OPUOM],[IPQty],[IPUOM] ,[InPqty],[InPUOM],[ImPQty],[ImPUOM],[PreferentialCode],[GSTRate],[GSTUOM],[GSTAmount],[ExciseDutyRate],[ExciseDutyUOM],[ExciseDutyAmount],[CustomsDutyRate],[CustomsDutyUOM],[CustomsDutyAmount],[OtherTaxRate],[OtherTaxUOM],[OtherTaxAmount],[CurrentLot],[PreviousLot],[LSPValue],[Making],[ShippingMarks1],[ShippingMarks2],[ShippingMarks3],[ShippingMarks4],[VehicleType],[EngineCapcity],[EngineCapUOM],[orignaldatereg],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime]  from ItemDtl where [PermitId] = '" + PermitId + "' ";


                    string container = "insert into ContainerDtl ([PermitId],[RowNo],[ContainerNo],[Size],[Weight],[SealNo],[MessageType],[TouchUser],[TouchTime])";
                    container = container + " select  '" + PermitNo + "' as [PermitId],[RowNo],[ContainerNo],[Size],[Weight],[SealNo],[MessageType],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime]  from ContainerDtl where [PermitId] = '" + PermitId + "' ";


                    string CPCDtl = "insert into CPCDtl ([PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],[TouchUser],[TouchTime])";
                    CPCDtl = CPCDtl + " select  '" + PermitNo + "' as [PermitId],[MessageType],[RowNo],[CPCType],[ProcessingCode1],[ProcessingCode2],[ProcessingCode3],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime]  from CPCDtl where [PermitId] = '" + PermitId + "' ";


                    string CASCDtl = "insert into CASCDtl ([ItemNo],[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],[PermitId],[MessageType],[TouchUser],[TouchTime],[CASCId])";
                    CASCDtl = CASCDtl + "  select  [ItemNo],[ProductCode],[Quantity],[ProductUOM],[RowNo],[CascCode1],[CascCode2],[CascCode3],'" + PermitNo + "' as [PermitId],[MessageType],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime],[CASCId]  from CASCDtl where [PermitId] = '" + PermitId + "' ";


                    string file = "insert into InFile ([Sno],[Name],[ContentType],[Data],[DocumentType],[InPaymentId],[TouchUser],[TouchTime] )";
                    file = file + " select  [Sno],[Name],[ContentType],[Data],[DocumentType],'" + PermitNo + "' as [InPaymentId],'" + Touch_user + "' as [TouchUser],'" + strTime + "' as [TouchTime]  from InFile where [InPaymentId] = '" + PermitId + "' ";

                    //string PerCount = ("INSERT INTO [dbo].[PermitCount] ([PermitId],[MessageType],[AccountId],[TouchUser],[TouchTime])  VALUES ('" + PermitNo + "','IPTDEC','" + Session["AccountId"].ToString() + "','" + Touch_user + "','" + strTime + "')");
                    string PerCount = ("INSERT INTO [dbo].[PermitCount] ([PermitId],[MessageType],[AccountId],[MsgId],[TouchUser],[TouchTime])  VALUES ('" + PermitNo + "','IPTDEC','" + Session["AccountId"].ToString() + "','" + MsgNO + "','" + Touch_user + "','" + strTime + "')");

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
                    string strBindTxtBox = "select * from InHeaderTbl where PermitId='" + PermitNo + "'";
                    obj.dr = obj.ret_dr(strBindTxtBox);
                    while (obj.dr.Read())
                    {
                        string idpass = obj.dr["ID"].ToString();
                        Response.Redirect("Inpayment.aspx?ID=" + idpass);

                    }
                    //}

                }
            }


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
                string Date = DateTime.Now.ToString("yyMMdd");
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
                    SqlCommand cmd = new SqlCommand("update  InHeaderTbl set  Status='DEL' where ID=" + labelProductID.Text, con);
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
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(900/2);var Mtop = (screen.height/2)-(500/2);window.open( 'InpaymentView.aspx?ID=" + ID + "', null, 'height=900,width=2000,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

        }

        protected void txtJobId_TextChanged1(object sender, EventArgs e)
        {
            search();
        }

        protected void GridInPayment_Sorting(object sender, GridViewSortEventArgs e)
        {
           // this.BindInPayment(e.SortExpression);
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
                    string lodport = "select * from [InHeaderTbl] where Id=" + ID + "";
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
            string qry11 = "select t2.Name,t2.CRUEI,t1.JobId,t1.MSGId,t1.TouchTime,t3.* from InHeaderTbl t1,Importer t2,InvoiceDtl t3 where  t1.ImporterCompanyCode=t2.Code and t1.PermitId=t3.PermitId  and  t1.PermitId='" + PermID + "'";
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
                Response.AddHeader("content-disposition", "attachment;filename=In-PrintGST.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

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
            PermitNo = code;
        }
        private void LoadIPTDEC(string permit)
        {
            string tradeID = "";
            dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from inheadertbl  where PermitId='" + permit + "'"))
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

                XElement TotalAmountPayable = new XElement(ns2 + "TotalAmountPayable", dt.Rows[0]["TotalAmtPay"].ToString().ToUpper());
                XElement TotalOtherTaxAmount = new XElement(ns2 + "TotalOtherTaxAmount", dt.Rows[0]["TotalODutyAmt"].ToString().ToUpper());
                XElement TotalCustomsDutyAmount = new XElement(ns2 + "TotalCustomsDutyAmount", dt.Rows[0]["TotalCusDutyAmt"].ToString().ToUpper());
                XElement TotalExciseDutyAmount = new XElement(ns2 + "TotalExciseDutyAmount", dt.Rows[0]["TotalExDutyAmt"].ToString().ToUpper());
                XElement TotalGoodsAndServicesTaxAmount = new XElement(ns2 + "TotalGoodsAndServicesTaxAmount", dt.Rows[0]["TotalGSTTaxAmt"].ToString().ToUpper());
                XElement TotalTariff = new XElement(ns3 + "TotalTariff", "");
                if (Convert.ToDecimal(dt.Rows[0]["TotalGSTTaxAmt"].ToString()) > 0)
                {
                    TotalTariff.Add(TotalGoodsAndServicesTaxAmount);
                }
                if (Convert.ToDecimal(dt.Rows[0]["TotalExDutyAmt"].ToString()) > 0)
                {
                    TotalTariff.Add(TotalExciseDutyAmount);
                }
                if (Convert.ToDecimal(dt.Rows[0]["TotalCusDutyAmt"].ToString()) > 0)
                {
                    TotalTariff.Add(TotalCustomsDutyAmount);
                }
                if (Convert.ToDecimal(dt.Rows[0]["TotalODutyAmt"].ToString()) > 0)
                {
                    TotalTariff.Add(TotalOtherTaxAmount);
                }
                if (Convert.ToDecimal(dt.Rows[0]["TotalAmtPay"].ToString()) > 0)
                {
                    TotalTariff.Add(TotalAmountPayable);
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


                XElement TotalGrossWeight = new XElement(ns2 + "TotalGrossWeight", strtest2.ToUpper());



                TotalGrossWeight.Add(new XAttribute("unitCode", dt.Rows[0]["TotalGrossWeightUOM"].ToString().ToUpper()));
                XElement TotalOuterPack = new XElement(ns2 + "TotalOuterPack", dt.Rows[0]["TotalOuterPack"].ToString().ToUpper());
                TotalOuterPack.Add(new XAttribute("unitCode", dt.Rows[0]["TotalOuterPackUOM"].ToString().ToUpper()));
                XElement TotalCIFFOBValue = new XElement(ns2 + "TotalCIFFOBValue", dt.Rows[0]["TotalCIFFOBValue"].ToString().ToUpper());
                //  string NoItem = Math.Round(Convert.ToDecimal(obj.dr["GSTRate"].ToString()), 0).ToString();
                //string noofitem = dt.Rows[0]["NumberOfItems"].ToString("0");
                XElement NumberOfItems = new XElement(ns2 + "NumberOfItems", Math.Round(Convert.ToDecimal(dt.Rows[0]["NumberOfItems"].ToString().ToUpper()), 0));
                XElement Summary = new XElement(ns5 + "Summary");
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
                if (Convert.ToDecimal(dt.Rows[0]["TotalGSTTaxAmt"].ToString()) > 0)
                {
                    Summary.Add(TotalTariff);
                }
                //Summary
                XElement Item = null;


                //Item
                XElement InvoiceName = new XElement(ns3 + "Invoice", "");
                string invQury = "select * from dbo.InvoiceDtl where PermitId='" + dt.Rows[0]["PermitId"].ToString() + "'";
                obj.dr = obj.ret_dr(invQury);
                if (obj.dr.HasRows)
                {
                    while (obj.dr.Read())
                    {
                        XElement ChargePercent3 = new XElement(ns2 + "ChargePercent", obj.dr["OTCCharge"].ToString().ToUpper());
                        XElement ExchangeRate3 = new XElement(ns2 + "ExchangeRate", obj.dr["OTCExRate"].ToString().ToUpper());
                        XElement Amount3 = new XElement(ns2 + "Amount", obj.dr["OTCAmount"].ToString().ToUpper());
                        string Othercurny = "";
                        if (obj.dr["OTCCurrency"].ToString() == "--Select--")
                        {
                            Othercurny = "";
                        }
                        else
                        {
                            Othercurny = obj.dr["OTCCurrency"].ToString();
                        }
                        Amount3.Add(new XAttribute("currencyID", Othercurny));
                        XElement OtherTaxableCharge = new XElement(ns3 + "OtherTaxableCharge", "");
                        XElement ChargePercent2 = new XElement(ns2 + "ChargePercent", obj.dr["ICCharge"].ToString().ToUpper());
                        XElement ExchangeRate2 = new XElement(ns2 + "ExchangeRate", obj.dr["ICExRate"].ToString().ToUpper());
                        XElement Amount2 = new XElement(ns2 + "Amount", obj.dr["ICAmount"].ToString().ToUpper());
                        string Incucurny = "";
                        if (obj.dr["ICCurrency"].ToString() == "--Select--")
                        {
                            Incucurny = "";
                        }
                        else
                        {
                            Incucurny = obj.dr["ICCurrency"].ToString();
                        }
                        Amount2.Add(new XAttribute("currencyID", Incucurny));
                        XElement InsuranceCharge = new XElement(ns3 + "InsuranceCharge", "");
                        XElement ChargePercent = new XElement(ns2 + "ChargePercent", obj.dr["FCCharge"].ToString().ToUpper());
                        XElement ExchangeRate1 = new XElement(ns2 + "ExchangeRate", obj.dr["FCExRate"].ToString().ToUpper());
                        XElement Amount1 = new XElement(ns2 + "Amount", obj.dr["FCAmount"].ToString().ToUpper());
                        string frgtcurny = "";
                        if (obj.dr["FCCurrency"].ToString() == "--Select--")
                        {
                            frgtcurny = "";
                        }
                        else
                        {
                            frgtcurny = obj.dr["FCCurrency"].ToString();
                        }
                        Amount1.Add(new XAttribute("currencyID", frgtcurny));
                        XElement FreightCharge = new XElement(ns3 + "FreightCharge", "");
                        XElement ExchangeRate = new XElement(ns2 + "ExchangeRate", obj.dr["TIExRate"].ToString().ToUpper());
                        XElement Amount = new XElement(ns2 + "Amount", obj.dr["TIAmount"].ToString().ToUpper());
                        Amount.Add(new XAttribute("currencyID", obj.dr["TICurrency"].ToString().ToUpper()));
                        XElement TotalInvoiceValue = new XElement(ns3 + "TotalInvoiceValue", "");
                        string[] termtype = obj.dr["TermType"].ToString().Split(':');
                        XElement UnitPriceTermType = new XElement(ns2 + "UnitPriceTermType", termtype[0].ToString().Substring(0, termtype[0].Length - 1).ToUpper());
                        string Suppqury = "select CRUEI,Name from dbo.SUPPLIERMANUFACTURERPARTY where Code='" + obj.dr["SupplierCode"].ToString().ToUpper().Replace("'","''") + "'";
                        string SuppName = "", Suppid = "";
                        MyClass obj1 = new MyClass();
                        obj1.dr = obj1.ret_dr(Suppqury);
                        while (obj1.dr.Read())
                        {
                            // CPC.Add(obj.dr[0].ToString());
                            SuppName = obj1.dr["Name"].ToString();
                            Suppid = obj1.dr["CRUEI"].ToString();
                        }
                        XElement InvName = new XElement(ns2 + "Name", SuppName.ToUpper());
                        XElement InvCodeValue = null;
                        if (!string.IsNullOrWhiteSpace(Suppid))
                        {
                            InvCodeValue = new XElement(ns2 + "CodeValue", Suppid.ToUpper());
                        }
                        XElement SupplierManufacturerParty = new XElement(ns3 + "SupplierManufacturerParty", "");
                        XElement InvoiceDate = new XElement(ns2 + "InvoiceDate", Convert.ToDateTime(obj.dr["InvoiceDate"].ToString()).ToString("yyyyMMdd").ToUpper());
                        XElement InvoiceNumber = new XElement(ns2 + "InvoiceNumber", obj.dr["InvoiceNo"].ToString().ToUpper());
                        if (!string.IsNullOrWhiteSpace(obj.dr["InvoiceNo"].ToString()))
                        {
                            String Decty = dt.Rows[0]["DeclarationType"].ToString();
                            if (dt.Rows[0]["RecepitLocation"].ToString().ToUpper() == "AISSLOC" || dt.Rows[0]["RecepitLocation"].ToString().ToUpper() == "SPIGDS" || dt.Rows[0]["RecepitLocation"].ToString().ToUpper() == "SPSTK" || dt.Rows[0]["RecepitLocation"].ToString().ToUpper() == "SPNOSTK" || dt.Rows[0]["RecepitLocation"].ToString().ToUpper() == "SPIGDS" || dt.Rows[0]["RecepitLocation"].ToString().ToUpper() == "RCNOSTK")
                            {
                                //   InvoiceName.Add(InvoiceNumber);
                            }
                            else if (dt.Rows[0]["ReleaseLocation"].ToString().ToUpper() == "EM" || dt.Rows[0]["ReleaseLocation"].ToString().ToUpper() == "EXEMPT")
                            {
                                //  InvoiceName.Add(InvoiceNumber);
                            }

                            else if (Decty == "BKT : Blanket ")
                            {
                                //  InvoiceName.Add(InvoiceNumber);
                            }
                            else
                            {
                                InvoiceName.Add(InvoiceNumber);
                            }




                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["InvoiceDate"].ToString()))
                        {
                            String Decty = dt.Rows[0]["DeclarationType"].ToString();
                            if (dt.Rows[0]["RecepitLocation"].ToString().ToUpper() == "AISSLOC" || dt.Rows[0]["RecepitLocation"].ToString().ToUpper() == "SPIGDS" || dt.Rows[0]["RecepitLocation"].ToString().ToUpper() == "SPSTK" || dt.Rows[0]["RecepitLocation"].ToString().ToUpper() == "SPNOSTK" || dt.Rows[0]["RecepitLocation"].ToString().ToUpper() == "SPIGDS" || dt.Rows[0]["RecepitLocation"].ToString().ToUpper() == "RCNOSTK")
                            {
                                //  InvoiceName.Add(InvoiceDate);
                            }
                            else if (dt.Rows[0]["ReleaseLocation"].ToString().ToUpper() == "EM" || dt.Rows[0]["ReleaseLocation"].ToString().ToUpper() == "EXEMPT")
                            {
                                //  InvoiceName.Add(InvoiceDate);
                            }

                            else if (Decty == "BKT : Blanket ")
                            {
                                // InvoiceName.Add(InvoiceDate);
                            }
                            else
                            {
                                InvoiceName.Add(InvoiceDate);
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(SuppName))
                        {
                            String Decty = dt.Rows[0]["DeclarationType"].ToString();
                            if (dt.Rows[0]["RecepitLocation"].ToString().ToUpper() == "AISSLOC" || dt.Rows[0]["RecepitLocation"].ToString().ToUpper() == "SPIGDS" || dt.Rows[0]["RecepitLocation"].ToString().ToUpper() == "SPSTK" || dt.Rows[0]["RecepitLocation"].ToString().ToUpper() == "SPNOSTK" || dt.Rows[0]["RecepitLocation"].ToString().ToUpper() == "SPIGDS" || dt.Rows[0]["RecepitLocation"].ToString().ToUpper() == "RCNOSTK")
                            {
                                //  InvoiceName.Add(InvoiceDate);
                            }
                            else if (dt.Rows[0]["ReleaseLocation"].ToString().ToUpper() == "EM" || dt.Rows[0]["ReleaseLocation"].ToString().ToUpper() == "EXEMPT")
                            {
                                //  InvoiceName.Add(InvoiceDate);
                            }

                            else if (Decty == "BKT : Blanket ")
                            {
                                // InvoiceName.Add(InvoiceDate);
                            }
                            else
                            {
                                InvoiceName.Add(SupplierManufacturerParty);
                                SupplierManufacturerParty.Add(InvCodeValue);
                                SupplierManufacturerParty.Add(InvName);
                            }

                        }
                        if (!string.IsNullOrWhiteSpace(termtype[0].ToString().Substring(0, termtype[0].Length - 1)))
                        {
                            InvoiceName.Add(UnitPriceTermType);
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["TICurrency"].ToString()))
                        {
                            if (obj.dr["TICurrency"].ToString() != "--Select--")
                            {
                                InvoiceName.Add(TotalInvoiceValue);
                                TotalInvoiceValue.Add(Amount);
                                TotalInvoiceValue.Add(ExchangeRate);
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(frgtcurny))
                        {
                            InvoiceName.Add(FreightCharge);
                            FreightCharge.Add(Amount1);
                            FreightCharge.Add(ExchangeRate1);
                            if (Convert.ToDecimal(obj.dr["FCCharge"].ToString()) > 0)
                            {
                                FreightCharge.Add(ChargePercent);
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(Incucurny))
                        {
                            InvoiceName.Add(InsuranceCharge);
                            InsuranceCharge.Add(Amount2);
                            InsuranceCharge.Add(ExchangeRate2);
                            if (Convert.ToDecimal(obj.dr["ICCharge"].ToString()) > 0)
                            {
                                InsuranceCharge.Add(ChargePercent2);
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(Othercurny))
                        {
                            InvoiceName.Add(OtherTaxableCharge);
                            OtherTaxableCharge.Add(Amount3);
                            OtherTaxableCharge.Add(ExchangeRate3);
                            if (Convert.ToDecimal(obj.dr["OTCCharge"].ToString()) > 0)
                            {
                                OtherTaxableCharge.Add(ChargePercent3);
                            }
                        }
                    }
                }

                string SupFile = "";
                XElement SupportingDocumentReference = new XElement(ns3 + "SupportingDocumentReference", "");
                string infilname = "select * from InFile where InPaymentId='" + dt.Rows[0]["PermitId"].ToString() + "'";
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
                string clamtparty = "select CRUEI,Name,Name1,Name2,ClaimantName1,ClaimantName from dbo.ClaimantParty where Name='" + dt.Rows[0]["ClaimantPartyCode"].ToString() + "'";
                string clamtpartyuName = "", clamtpartyuName1 = "", clamtuei = "", clatinfocode = "", clatinfoname = "";
                obj.dr = obj.ret_dr(clamtparty);
                while (obj.dr.Read())
                {
                    // CPC.Add(obj.dr[0].ToString());
                    clamtpartyuName = obj.dr["Name1"].ToString();
                    clamtpartyuName1 = obj.dr["Name2"].ToString();
                    clamtuei = obj.dr["CRUEI"].ToString();
                    clatinfocode = obj.dr["ClaimantName1"].ToString();
                    clatinfoname = obj.dr["ClaimantName"].ToString();
                }
                XElement LicName1 = new XElement(ns2 + "Name", clamtpartyuName1.ToUpper());
                XElement LicName = new XElement(ns2 + "Name", clamtpartyuName.ToUpper());
                XElement LicCodeValue = new XElement(ns2 + "CodeValue", clatinfocode.ToUpper());
                XElement ClaimantInformation = new XElement(ns3 + "ClaimantInformation", "");
                XElement ClainmentInfoName = new XElement(ns2 + "Name", clamtpartyuName.ToUpper());
                XElement ClainmentInfoPartyName = new XElement(ns3 + "PartyName", "");
                XElement ClainmentInfoID = new XElement(ns2 + "ID", clamtuei.ToUpper());
                XElement ClainmentPartyIdentification = new XElement(ns3 + "PartyIdentification", "");
                XElement PartyDetail = new XElement(ns3 + "PartyDetail", "");
                XElement ClaimantParty = new XElement(ns3 + "ClaimantParty", "");
                ClaimantParty.Add(PartyDetail);
                PartyDetail.Add(ClainmentPartyIdentification);
                ClainmentPartyIdentification.Add(ClainmentInfoID);
                PartyDetail.Add(ClainmentInfoPartyName);
                ClainmentInfoPartyName.Add(ClainmentInfoName);
                if (!string.IsNullOrWhiteSpace(clatinfocode))
                {
                    ClaimantParty.Add(ClaimantInformation);
                    ClaimantInformation.Add(LicCodeValue);
                    ClaimantInformation.Add(LicName);
                    if (!string.IsNullOrWhiteSpace(clamtpartyuName1))
                    {
                        ClaimantInformation.Add(LicName1);
                    }
                }
                string impotparty = "select CRUEI,Name,Name1 from dbo.Importer where Code='" + dt.Rows[0]["ImporterCompanyCode"].ToString() + "'";
                string importName = "", importName1 = "", Importid = "";
                obj.dr = obj.ret_dr(impotparty);
                while (obj.dr.Read())
                {
                    // CPC.Add(obj.dr[0].ToString());
                    importName = obj.dr["Name"].ToString();
                    importName1 = obj.dr["Name1"].ToString();
                    Importid = obj.dr["CRUEI"].ToString();
                }
                XElement ClainmentName1 = new XElement(ns2 + "Name", importName1.ToUpper());
                XElement ClainmentName = new XElement(ns2 + "Name", importName.ToUpper());
                XElement ClainmentPartyName = new XElement(ns3 + "PartyName", "");
                XElement ClainmentID = new XElement(ns2 + "ID", Importid.ToUpper());
                XElement ImportPartyIdentification = new XElement(ns3 + "PartyIdentification", "");
                XElement ImporterParty = new XElement(ns3 + "ImporterParty", "");
                ImporterParty.Add(ImportPartyIdentification);
                ImportPartyIdentification.Add(ClainmentID);
                ImporterParty.Add(ClainmentPartyName);
                ClainmentPartyName.Add(ClainmentName);
                if (!string.IsNullOrWhiteSpace(importName1))
                {
                    ClainmentPartyName.Add(ClainmentName1);
                }
                XElement InwardCarrierAgentParty = null;
                string inwardparty = "select CRUEI,Name,Name1 from dbo.InwardCarrierAgent where Code='" + dt.Rows[0]["InwardCarrierAgentCode"].ToString() + "'";
                string inwardName = "", inwardName1 = "", inwardid = "";
                if (dt.Rows[0]["InwardTransportMode"].ToString() == "1 : Sea" || dt.Rows[0]["InwardTransportMode"].ToString() == "4 : Air")
                {
                    obj.dr = obj.ret_dr(inwardparty);
                    while (obj.dr.Read())
                    {
                        // CPC.Add(obj.dr[0].ToString());
                        inwardName = obj.dr["Name"].ToString();
                        inwardName1 = obj.dr["Name1"].ToString();
                        inwardid = obj.dr["CRUEI"].ToString();
                    }
                    XElement ImportName1 = new XElement(ns2 + "Name", inwardName1.ToUpper());
                    XElement ImportName = new XElement(ns2 + "Name", inwardName.ToUpper());
                    XElement ImportPartyName = new XElement(ns3 + "PartyName", "");
                    XElement ImportID = new XElement(ns2 + "ID", inwardid.ToUpper());
                    XElement InwardPartyIdentification = new XElement(ns3 + "PartyIdentification", "");
                    InwardCarrierAgentParty = new XElement(ns3 + "InwardCarrierAgentParty", "");

                    InwardCarrierAgentParty.Add(InwardPartyIdentification);
                    InwardPartyIdentification.Add(ImportID);
                    InwardCarrierAgentParty.Add(ImportPartyName);
                    ImportPartyName.Add(ImportName);
                    if (!string.IsNullOrWhiteSpace(inwardName1))
                    {
                        ImportPartyName.Add(ImportName1);
                    }
                }
                string freiparty = "select CRUEI,Name,Name1 from dbo.FreightForwarder where Code='" + dt.Rows[0]["FreightForwarderCode"].ToString() + "'";
                string FreiName = "", FreiName1 = "", FreiID = "";
                obj.dr = obj.ret_dr(freiparty);
                while (obj.dr.Read())
                {
                    // CPC.Add(obj.dr[0].ToString());
                    FreiID = obj.dr["CRUEI"].ToString();
                    FreiName = obj.dr["Name"].ToString();
                    FreiName1 = obj.dr["Name1"].ToString();
                    //InwardTransportMode = obj.dr[1].ToString();
                }
                XElement InwardName1 = new XElement(ns2 + "Name", FreiName1.ToUpper());
                XElement InwardName = new XElement(ns2 + "Name", FreiName.ToUpper());
                XElement InwardPartyName = new XElement(ns3 + "PartyName", "");
                XElement InwardID = new XElement(ns2 + "ID", FreiID.ToUpper());
                XElement FreightPartyIdentification = new XElement(ns3 + "PartyIdentification", "");
                XElement FreightForwarderParty = new XElement(ns3 + "FreightForwarderParty", "");
                FreightForwarderParty.Add(FreightPartyIdentification);
                FreightPartyIdentification.Add(InwardID);
                FreightForwarderParty.Add(InwardPartyName);
                InwardPartyName.Add(InwardName);
                if (!string.IsNullOrWhiteSpace(FreiName1))
                {
                    InwardPartyName.Add(InwardName1);
                }
                string delparty = "select CRUEI,Name,Name1 from dbo.DeclarantCompany where Code='" + dt.Rows[0]["DeclarantCompanyCode"].ToString() + "'";
                string declrName = "", declrName1 = "", declrid = "";
                obj.dr = obj.ret_dr(delparty);
                while (obj.dr.Read())
                {
                    // CPC.Add(obj.dr[0].ToString());
                    declrid = obj.dr["CRUEI"].ToString();
                    declrName = obj.dr["Name"].ToString();
                    declrName1 = obj.dr["Name1"].ToString();
                    //InwardTransportMode = obj.dr[1].ToString();
                }
                XElement FreightName1 = new XElement(ns2 + "Name", declrName1.ToUpper());
                XElement FreightName = new XElement(ns2 + "Name", declrName.ToUpper());
                XElement PartyName = new XElement(ns3 + "PartyName", "");
                XElement ID = new XElement(ns2 + "ID", declrid.ToUpper());
                XElement PartyIdentification = new XElement(ns3 + "PartyIdentification", "");
                XElement DeclaringAgentParty = new XElement(ns3 + "DeclaringAgentParty", "");
                DeclaringAgentParty.Add(PartyIdentification);
                PartyIdentification.Add(ID);
                DeclaringAgentParty.Add(PartyName);
                PartyName.Add(FreightName);
                if (!string.IsNullOrWhiteSpace(declrName1))
                {
                    PartyName.Add(FreightName1);
                }

                tradeID = dt.Rows[0]["TradeNetMailboxID"].ToString();
                string[] tradID = tradeID.Split('.');
                tradeID = tradID[1].ToString();
                delparty = "select * from dbo.DeclarantCompany where TradeNetMailboxID='" + dt.Rows[0]["TradeNetMailboxID"].ToString() + "'";
                string telphn = "", decname = "", deccode = "", DecId = "";
                obj.dr = obj.ret_dr(delparty);
                while (obj.dr.Read())
                {
                    telphn = obj.dr["DeclarantTel"].ToString();
                    decname = obj.dr["DeclarantName"].ToString();
                    deccode = obj.dr["DeclarantCode"].ToString();
                    DecId = obj.dr["CRUEI"].ToString();
                }

                XElement Telephone = new XElement(ns2 + "Telephone", telphn);
                XElement DeclarName = new XElement(ns2 + "Name", decname);
                XElement CodeValue = new XElement(ns2 + "CodeValue", deccode);
                XElement PersonInformation = new XElement(ns3 + "PersonInformation", "");
                XElement DeclarantParty = new XElement(ns3 + "DeclarantParty", "");
                DeclarantParty.Add(PersonInformation);
                PersonInformation.Add(CodeValue);
                PersonInformation.Add(DeclarName);
                DeclarantParty.Add(Telephone);
                XElement Party = new XElement(ns5 + "Party");
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
                if (!string.IsNullOrWhiteSpace(clamtuei))
                {
                    Party.Add(ClaimantParty);
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
                string conveno = "", mastebill = "", vessname = "";
                if (dt.Rows[0]["InwardTransportMode"].ToString() == "4 : Air")
                {
                    conveno = dt.Rows[0]["FlightNO"].ToString();
                    mastebill = dt.Rows[0]["MasterAirwayBill"].ToString();
                }
                else if (dt.Rows[0]["InwardTransportMode"].ToString() == "1 : Sea")
                {
                    conveno = dt.Rows[0]["VoyageNumber"].ToString();
                    mastebill = dt.Rows[0]["OceanBillofLadingNo"].ToString();
                    vessname = dt.Rows[0]["VesselName"].ToString();
                }
                else
                {
                    conveno = dt.Rows[0]["ConveyanceRefNo"].ToString();

                    vessname = dt.Rows[0]["TransportId"].ToString();
                }

                XElement LoadingPort = new XElement(ns2 + "LoadingPort", dt.Rows[0]["LoadingPortCode"].ToString().ToUpper());
                XElement ArrivalDate = new XElement(ns2 + "ArrivalDate", Convert.ToDateTime(dt.Rows[0]["ArrivalDate"].ToString()).ToString("yyyyMMdd").ToUpper());
                XElement MAWBOUCROBLNumber = new XElement(ns2 + "MAWBOUCROBLNumber", mastebill.ToUpper());
                XElement TransportIdentifier = new XElement(ns2 + "TransportIdentifier", vessname.ToUpper());
                XElement ConveyanceReferenceNumber = new XElement(ns2 + "ConveyanceReferenceNumber", conveno.ToUpper());
                string[] mdecde = dt.Rows[0]["InwardTransportMode"].ToString().Split(':');
                XElement ModeCode = new XElement(ns2 + "ModeCode", mdecde[0].Substring(0, mdecde[0].Length - 1));
                XElement TransportMode = new XElement(ns3 + "TransportMode", "");
                XElement TransportMeans = new XElement(ns3 + "TransportMeans", "");
                XElement InwardTransport = new XElement(ns3 + "InwardTransport", "");
                if (mdecde[0].Substring(0, mdecde[0].Length - 1).ToString() != "N")
                {
                    InwardTransport.Add(TransportMeans);
                    TransportMeans.Add(TransportMode);
                    if (dt.Rows[0]["InwardTransportMode"].ToString() != "--Select--")
                    {
                        if (!string.IsNullOrWhiteSpace(mdecde[0].Substring(0, mdecde[0].Length - 1)))
                        {
                            TransportMode.Add(ModeCode);
                        }
                    }
                }
                if (!string.IsNullOrWhiteSpace(conveno))
                {
                    TransportMode.Add(ConveyanceReferenceNumber);
                }
                if (!string.IsNullOrWhiteSpace(vessname))
                {
                    TransportMode.Add(TransportIdentifier);
                }
                if (!string.IsNullOrWhiteSpace(mastebill))
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

                XElement Transport = new XElement(ns5 + "Transport", InwardTransport);
                //Transport


                XElement BlanketStartDate = new XElement(ns2 + "BlanketStartDate", Convert.ToDateTime(dt.Rows[0]["BlanketStartDate"].ToString()).ToString("yyyyMMdd").ToUpper());
                
                
                
                XElement SupplyIndicator = new XElement(ns2 + "SupplyIndicator", dt.Rows[0]["SupplyIndicator"].ToString().ToLower());
                string CargoPackType = "", InwardTransportMode = "";
                string qry1213 = "select CargoPackType,InwardTransportMode from dbo.inheadertbl where PermitID='" + dt.Rows[0]["PermitID"].ToString() + "'";
                obj.dr = obj.ret_dr(qry1213);
                while (obj.dr.Read())
                {
                    // CPC.Add(obj.dr[0].ToString());
                    CargoPackType = obj.dr[0].ToString();
                    InwardTransportMode = obj.dr[1].ToString();
                }
                XElement TransportEquipment = new XElement(ns3 + "TransportEquipment", "");


                string ReceiptLoc = "";
                ReceiptLoc = dt.Rows[0]["RecepitLocName"].ToString().ToUpper();

                if (string.IsNullOrWhiteSpace(ReceiptLoc))
                {
                    string qry113 = "select LocationCode,Description from dbo.ReceiptLocation where LocationCode='" + dt.Rows[0]["RecepitLocation"].ToString() + "'";
                    obj.dr = obj.ret_dr(qry113);
                    while (obj.dr.Read())
                    {
                        // CPC.Add(obj.dr[0].ToString());
                        ReceiptLoc = obj.dr[1].ToString();
                    }
                }

                XElement ReceiptLocationName = new XElement(ns2 + "LocationName", ReceiptLoc.ToUpper());
                XElement ReceiptLocationCode = new XElement(ns2 + "LocationCode", dt.Rows[0]["RecepitLocation"].ToString().ToUpper());
                XElement ReceiptLocation = new XElement(ns3 + "ReceiptLocation", "");
                ReceiptLocation.Add(ReceiptLocationCode);
                if (!string.IsNullOrWhiteSpace(ReceiptLoc))
                {
                    ReceiptLocation.Add(ReceiptLocationName);
                }
                string ReleaseLoc = "";
                ReleaseLoc = dt.Rows[0]["ReleaseLocName"].ToString().ToUpper();

                if (string.IsNullOrWhiteSpace(ReleaseLoc))
                {
                    string qry11 = "select LocationCode,Description from dbo.ReleaseLocation where LocationCode='" + dt.Rows[0]["ReleaseLocation"].ToString() + "'";
                    obj.dr = obj.ret_dr(qry11);
                    while (obj.dr.Read())
                    {
                        // CPC.Add(obj.dr[0].ToString());
                        ReleaseLoc = obj.dr[1].ToString();
                    }
                }
                XElement LocationName = new XElement(ns2 + "LocationName", ReleaseLoc.ToUpper());
                XElement LocationCode = new XElement(ns2 + "LocationCode", dt.Rows[0]["ReleaseLocation"].ToString().ToUpper());
                XElement ReleaseLocation = new XElement(ns3 + "ReleaseLocation", "");
                ReleaseLocation.Add(LocationCode);
                if (!string.IsNullOrWhiteSpace(ReleaseLoc))
                {
                    ReleaseLocation.Add(LocationName);
                }

                string[] cartype = dt.Rows[0]["CargoPackType"].ToString().Split(':');
                string cartpefin = "";
                cartpefin = cartype[0].ToString();
                if (cartype[1].ToString() == " Other non-Containerized")
                {
                    cartpefin = cartpefin.Remove(cartpefin.Length - 1);
                }

                XElement CargoPackingType = new XElement(ns2 + "CargoPackingType", cartpefin.ToUpper());
                XElement Cargo = new XElement(ns5 + "Cargo");
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
                if (CargoPackType == "9: Containerized")
                {

                    string Con = "select RowNo,ContainerNo,Size,Weight,SealNo from dbo.ContainerDtl where PermitID='" + dt.Rows[0]["PermitID"].ToString() + "' ORDER BY RowNo";
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
                        Cargo.Add(TransportEquipment);
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

                //   Cargo.Add(TransportEquipment);

                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["SupplyIndicator"].ToString()))
                {
                    if (dt.Rows[0]["SupplyIndicator"].ToString().ToUpper() == "True".ToUpper())
                    {
                        Cargo.Add(SupplyIndicator);
                    }
                }
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["BlanketStartDate"].ToString()))
                {

                    if (dt.Rows[0]["BlanketStartDate"].ToString()!= "19000101")
                    {
                        Cargo.Add(BlanketStartDate);
                    }
                }



                string[] bankercode1 = dt.Rows[0]["BGIndicator"].ToString().Split(':');
                XElement BankerCode = new XElement(ns2 + "BankerGuaranteeCode", bankercode1[0].Substring(0, bankercode1[0].ToString().Length - 1).ToUpper());
                XElement Additional = new XElement(ns2 + "AdditionalRecipientID", "");
                XElement Remarks = new XElement(ns3 + "Remarks", "");
                Remarks.Add(new XElement(ns2 + "FreeText", dt.Rows[0]["TradeRemarks"].ToString().ToUpper()));
                XElement DeclarationIndicator = new XElement(ns2 + "DeclarationIndicator", "true");
                XElement PreviousPermitNumber = new XElement(ns2 + "PreviousPermitNumber", dt.Rows[0]["PreviousPermit"].ToString().ToUpper());
                string[] DecType = dt.Rows[0]["DeclarationType"].ToString().Split(':');
                XElement DeclarationType = new XElement(ns2 + "DeclarationType", DecType[0].ToString().Substring(0, DecType[0].ToString().Length - 1).ToUpper());
                XElement CommonAccessReference = null;
                if (Update == "AMEND")
                {
                    CommonAccessReference = new XElement(ns2 + "CommonAccessReference", "IPTUPD");
                }
                else
                {
                    CommonAccessReference = new XElement(ns2 + "CommonAccessReference", dt.Rows[0]["MessageType"].ToString().ToUpper());
                }
                XElement DeclarantID = new XElement(ns2 + "DeclarantID", dt.Rows[0]["TradeNetMailboxID"].ToString().ToUpper().TrimEnd());
                XElement MessageReference = new XElement(ns2 + "MessageReference", dt.Rows[0]["MSGId"].ToString().ToUpper());
                string date = "";
                string sequneNo = "";
                date = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                sequneNo = dt.Rows[0]["MSGId"].ToString().Substring(dt.Rows[0]["MSGId"].ToString().Length - 4);
                XElement UniqueReferenceNumber = new XElement(ns3 + "UniqueReferenceNumber", "");
                UniqueReferenceNumber.Add(new XElement(ns2 + "ID", DecId.ToUpper()));
                UniqueReferenceNumber.Add(new XElement(ns2 + "Date", date.ToUpper()));
                UniqueReferenceNumber.Add(new XElement(ns2 + "SequenceNumeric", sequneNo.ToUpper()));
                XElement Header = new XElement(ns5 + "Header");
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
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["TradeRemarks"].ToString()))
                {
                    Header.Add(Remarks);
                }
                //Header.Add(Additional);
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["BGIndicator"].ToString()))
                {
                    if (dt.Rows[0]["BGIndicator"].ToString() != "--Select--")
                    {
                        Header.Add(BankerCode);
                    }
                }
                List<string> CPC = new List<string>();
                string qry11a = "select distinct(CPCType) from dbo.CPCDtl where PermitId='" + dt.Rows[0]["PermitID"].ToString() + "'";
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
                    string qry111 = "select * from dbo.CPCDtl where PermitId='" + dt.Rows[0]["PermitID"].ToString() + "' and CPCType='" + CPC[i].ToString() + "'";
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
                            objcas.dr = objcas.ret_dr("select CPCCode from CPCCodeValue where PCode='" + obj.dr["CPCType"].ToString() + "' and CarRef='IPT' and DecType='" + DecType1[0].ToString().Substring(0, DecType1[0].ToString().Length - 1) + "'");
                            while (objcas.dr.Read())
                            {
                                Customprce.Add(new XElement(ns2 + "CustomsProcedureCode", objcas.dr["CPCCode"].ToString().ToUpper()));
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
                            qry111 = "select * from dbo.InpaymentAmend where Permitno='" + dt.Rows[0]["PermitNumber"].ToString() + "'";
                            objcan.dr = objcan.ret_dr(qry111);
                        }
                        else
                        {
                            qry111 = "select * from dbo.InpaymentCancel where Permitno='" + dt.Rows[0]["PermitNumber"].ToString() + "'";
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
                                //updateexdper = new XElement(ns2 + "ExtensionReason", objcan.dr["ExtendImportPeriod"].ToString().ToUpper());
                                updatepervalexp = new XElement(ns2 + "PermitValidityExtensionIndicator", objcan.dr["PermitExtension"].ToString().ToLower());
                            }
                            XElement updateAmtval = new XElement(ns3 + "Amendment", "");
                            XElement updateReppermitno = new XElement(ns2 + "ReplacementPermitNumber", objcan.dr["ReplacementPermitno"].ToString());
                            XElement updatepermitno = new XElement(ns2 + "UpdatePermitNumber", objcan.dr["Permitno"].ToString().ToUpper());
                            XElement updatereuqno = new XElement(ns2 + "UpdateRequestNumber", objcan.dr["AmendmentCount"].ToString());
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
                            //if (!string.IsNullOrWhiteSpace(objcan.dr["ReplacementPermitno"].ToString()))
                            //{
                            //    updateAmt.Add(updateReppermitno);
                            //}
                            if (Update == "AMEND")
                            {
                                string chkval = "";
                                if (!string.IsNullOrWhiteSpace(objcan.dr["PermitExtension"].ToString().ToLower()))
                                {
                                    if (objcan.dr["PermitExtension"].ToString().ToLower() != "false")
                                    {
                                        updateAmtval.Add(updatepervalexp);
                                        chkval = "In";
                                    }
                                }
                                //if (!string.IsNullOrWhiteSpace(objcan.dr["ExtendImportPeriod"].ToString()))
                                //{
                                //    updateAmtval.Add(updateexdper);
                                //    chkval = "In";
                                //}
                                if (!string.IsNullOrWhiteSpace(objcan.dr["DescriptionOfReason"].ToString()))
                                {
                                    updateAmtval.Add(updateAmtReason);
                                    chkval = "In";
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
                XElement InPayment = null;
                XElement inpdel = new XElement(ns5 + "Declaration", "");
                if (!string.IsNullOrWhiteSpace(Update))
                {
                    if (Update != "NEW")
                    {
                        InPayment = new XElement(ns5 + "InPaymentUpdate", "");
                    }
                    else
                    {
                        InPayment = new XElement(ns5 + "InPayment", "");
                    }
                }
                else
                {
                    InPayment = new XElement(ns5 + "InPayment", "");
                }
                //if (!string.IsNullOrWhiteSpace(Update))
                //{
                //    InPayment.Add(updateAmt);
                //}
                if (Update != "NEW")
                {
                    inpdel.Add(Header);
                    inpdel.Add(Cargo);
                    if (dt.Rows[0]["InwardTransportMode"].ToString() != "--Select--")
                    {
                        if (mdecde[0].Substring(0, mdecde[0].Length - 1).ToString() != "N")
                        {
                            inpdel.Add(Transport);
                        }
                    }
                    inpdel.Add(Party);
                    inpdel.Add(InvoiceName);
                }
                else
                {
                    InPayment.Add(Header);
                    InPayment.Add(Cargo);
                    if (dt.Rows[0]["InwardTransportMode"].ToString() != "--Select--")
                    {
                        if (mdecde[0].Substring(0, mdecde[0].Length - 1).ToString() != "N")
                        {
                            InPayment.Add(Transport);
                        }
                    }
                    InPayment.Add(Party);
                    InPayment.Add(InvoiceName);
                }
                //InPayment.Add(Item);
                string ItemQury = "select * from dbo.itemDtl where PermitId='" + dt.Rows[0]["PermitId"].ToString() + "' order by ItemNo";
                obj.dr = obj.ret_dr(ItemQury);
                if (obj.dr.HasRows)
                {
                    while (obj.dr.Read())
                    {
                        XElement OtherDutyAmount = new XElement(ns2 + "DutyAmount", obj.dr["OtherTaxAmount"].ToString().ToUpper());
                        XElement OtherDutyRateUnit = new XElement(ns2 + "DutyRateUnit", obj.dr["OtherTaxUOM"].ToString().ToUpper());
                        XElement OtherDutyRate = new XElement(ns2 + "DutyRate", obj.dr["OtherTaxRate"].ToString().ToUpper());
                        XElement OtherTax = new XElement(ns3 + "OtherTax", "");
                        OtherTax.Add(OtherDutyRate);
                        OtherTax.Add(OtherDutyRateUnit);
                        OtherTax.Add(OtherDutyAmount);
                        XElement CustomDutyAmount = new XElement(ns2 + "DutyAmount", obj.dr["CustomsDutyAmount"].ToString().ToUpper());
                        XElement CustomDutyRateUnit = new XElement(ns2 + "DutyRateUnit", obj.dr["CustomsDutyUOM"].ToString().ToUpper());
                        XElement CustomDutyRate = new XElement(ns2 + "DutyRate", obj.dr["CustomsDutyRate"].ToString().ToUpper());
                        XElement CustomsDuty = new XElement(ns3 + "CustomsDuty", "");
                        if (!string.IsNullOrWhiteSpace(obj.dr["CustomsDutyRate"].ToString()))
                        {
                            if (Convert.ToDecimal(obj.dr["CustomsDutyRate"].ToString()) > 0)
                            {
                                CustomsDuty.Add(CustomDutyRate);
                                CustomsDuty.Add(CustomDutyRateUnit);
                                CustomsDuty.Add(CustomDutyAmount);
                            }

                        }
                        XElement DutyAmount = new XElement(ns2 + "DutyAmount", obj.dr["ExciseDutyAmount"].ToString().ToUpper());
                        XElement DutyRateUnit = new XElement(ns2 + "DutyRateUnit", obj.dr["ExciseDutyUOM"].ToString().ToUpper());
                        XElement DutyRate = new XElement(ns2 + "DutyRate", obj.dr["ExciseDutyRate"].ToString().ToUpper());
                        XElement ExciseDuty = new XElement(ns3 + "ExciseDuty", "");
                        if (!string.IsNullOrWhiteSpace(obj.dr["ExciseDutyRate"].ToString()))
                        {
                            if (Convert.ToDecimal(obj.dr["ExciseDutyRate"].ToString()) > 0)
                            {
                                ExciseDuty.Add(DutyRate);
                                ExciseDuty.Add(DutyRateUnit);
                                ExciseDuty.Add(DutyAmount);
                            }
                        }

                        XElement GoodsAndServicesTaxAmount = new XElement(ns2 + "GoodsAndServicesTaxAmount", obj.dr["GSTAmount"].ToString().ToUpper());
                        string GSTPER = Math.Round(Convert.ToDecimal(obj.dr["GSTRate"].ToString()), 0).ToString();
                        XElement GoodsAndServicesTaxPercent = new XElement(ns2 + "GoodsAndServicesTaxPercent", GSTPER.ToUpper());
                        XElement GoodsAndServicesTax = new XElement(ns3 + "GoodsAndServicesTax", "");
                        if (Convert.ToDecimal(obj.dr["GSTRate"].ToString()) > 0)
                        {
                            GoodsAndServicesTax.Add(GoodsAndServicesTaxPercent);
                        }
                        if (Convert.ToDecimal(obj.dr["GSTAmount"].ToString()) > 0)
                        {
                            GoodsAndServicesTax.Add(GoodsAndServicesTaxAmount);
                        }
                        string[] percode = obj.dr["PreferentialCode"].ToString().Split(':');
                        XElement PreferentialCode = new XElement(ns2 + "PreferentialCode", percode[0].ToString().Substring(0, percode[0].Length - 1).ToUpper());
                        XElement Tariff = new XElement(ns3 + "Tariff", "");
                        if (!string.IsNullOrWhiteSpace(percode[0].ToString().Substring(0, percode[0].Length - 1)))
                        {
                            if (obj.dr["PreferentialCode"].ToString() != "--Select--")
                            {
                                Tariff.Add(PreferentialCode);
                            }
                        }
                        if (Convert.ToDecimal(obj.dr["GSTRate"].ToString()) > 0 || Convert.ToDecimal(obj.dr["GSTAmount"].ToString()) > 0)
                        {
                            Tariff.Add(GoodsAndServicesTax);
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["ExciseDutyUOM"].ToString()))
                        {
                            if (obj.dr["ExciseDutyUOM"].ToString() != "--Select--")
                            {
                                if (Convert.ToDecimal(obj.dr["ExciseDutyRate"].ToString()) > 0)
                                {
                                    Tariff.Add(ExciseDuty);
                                }
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["CustomsDutyUOM"].ToString()))
                        {
                            if (obj.dr["CustomsDutyUOM"].ToString() != "--Select--")
                            {
                                if (Convert.ToDecimal(obj.dr["CustomsDutyRate"].ToString()) > 0)
                                {
                                    Tariff.Add(CustomsDuty);
                                }

                            }
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["OtherTaxUOM"].ToString()))
                        {
                            if (obj.dr["OtherTaxUOM"].ToString() != "--Select--")
                            {

                                Tariff.Add(OtherTax);

                            }
                        }
                        XElement OriginalRegistrationDate = null;
                        if (!string.IsNullOrWhiteSpace(obj.dr["orignaldatereg"].ToString()))
                        {
                            OriginalRegistrationDate = new XElement(ns2 + "OriginalRegistrationDate", Convert.ToDateTime(obj.dr["orignaldatereg"].ToString()).ToString("yyyyMMdd"));
                        }
                        XElement EngineCapacity = new XElement(ns2 + "EngineCapacity", obj.dr["EngineCapcity"].ToString());
                        string[] enginecap = obj.dr["EngineCapUOM"].ToString().Split(':');
                        EngineCapacity.Add(new XAttribute("unitCode", enginecap[0].ToString().ToUpper()));
                        XElement MotorVehicle = new XElement(ns3 + "MotorVehicle", "");
                        if (!string.IsNullOrWhiteSpace(obj.dr["EngineCapcity"].ToString()))
                        {
                            MotorVehicle.Add(EngineCapacity);
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["orignaldatereg"].ToString()))
                        {
                            MotorVehicle.Add(OriginalRegistrationDate);
                        }
                        XElement ItemInvoiceNumber = new XElement(ns2 + "ItemInvoiceNumber", obj.dr["InvoiceNo"].ToString().ToUpper());
                        XElement InHAWBHUCRHBLNumber = new XElement(ns2 + "InHAWBHUCRHBLNumber", obj.dr["InHAWBOBL"].ToString().ToUpper());
                        string making = null;


                        string[] strhw = obj.dr["Making"].ToString().Split(':');

                        XElement Marking = new XElement(ns2 + "Marking", strhw[0].ToString().Substring(0, strhw[0].Length - 1).ToUpper());

                        XElement PreviousLotNumber = new XElement(ns2 + "PreviousLotNumber", obj.dr["PreviousLot"].ToString().ToUpper());
                        XElement CurrentLotNumber = new XElement(ns2 + "CurrentLotNumber", obj.dr["CurrentLot"].ToString().ToUpper());
                        XElement LotIdentification = new XElement(ns3 + "LotIdentification", "");
                        if (!string.IsNullOrWhiteSpace(obj.dr["CurrentLot"].ToString()))
                        {
                            making = obj.dr["CurrentLot"].ToString();
                            LotIdentification.Add(CurrentLotNumber);
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["PreviousLot"].ToString()))
                        {
                            making = obj.dr["PreviousLot"].ToString();

                            LotIdentification.Add(PreviousLotNumber);
                        }
                        if (!string.IsNullOrWhiteSpace(strhw[0].ToString().Substring(0, strhw[0].Length - 1)))
                        {
                            if (obj.dr["Making"].ToString() != "--Select--")
                            {
                                making = strhw[0].ToString().Substring(0, strhw[0].Length - 1);
                            }
                            LotIdentification.Add(Marking);
                        }

                        XElement ShippingMarks = new XElement(ns2 + "ShippingMarks", "");
                        XElement ShippingMarksInformation = new XElement(ns3 + "ShippingMarksInformation", "");
                        //ShippingMarksInformation.Add(ShippingMarks);

                        XElement InmostPackQuantity = new XElement(ns2 + "InmostPackQuantity", Math.Round(Convert.ToDecimal(obj.dr["ImPQty"].ToString()), 0));
                        InmostPackQuantity.Add(new XAttribute("unitCode", obj.dr["ImPUOM"].ToString()));
                        XElement InnerPackQuantity = new XElement(ns2 + "InnerPackQuantity", Math.Round(Convert.ToDecimal(obj.dr["InPqty"].ToString()), 0));
                        InnerPackQuantity.Add(new XAttribute("unitCode", obj.dr["InPUOM"].ToString()));
                        XElement InPackQuantity = new XElement(ns2 + "InPackQuantity", Math.Round(Convert.ToDecimal(obj.dr["IPQty"].ToString()), 0));
                        InPackQuantity.Add(new XAttribute("unitCode", obj.dr["IPUOM"].ToString()));
                        XElement OuterPackQuantity = new XElement(ns2 + "OuterPackQuantity", Math.Round(Convert.ToDecimal(obj.dr["OPQty"].ToString()), 0));
                        OuterPackQuantity.Add(new XAttribute("unitCode", obj.dr["OPUOM"].ToString()));
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
                        XElement DangerousGoodsIndicator = new XElement(ns2 + "DangerousGoodsIndicator", obj.dr["DGIndicator"].ToString().ToLower());
                        XElement ModelDescription = new XElement(ns2 + "ModelDescription", obj.dr["Model"].ToString().ToUpper());
                        XElement BrandName = new XElement(ns2 + "BrandName", obj.dr["Brand"].ToString().ToUpper());
                        XElement AdditionalCASCIdentification = new XElement(ns3 + "AdditionalCASCIdentification", "");
                        string CascQury = "select * from dbo.CASCDtl where PermitId='" + obj.dr["PermitId"].ToString() + "' and ItemNo='" + obj.dr["ItemNo"].ToString() + "'";
                        string CascQuryName = "", CascQuryid = "", CascPdrt = "";
                        List<string> cascde1 = new List<string>();
                        List<string> cascde2 = new List<string>();
                        List<string> cascde3 = new List<string>();
                        cascde1.Add("");
                        cascde2.Add("");
                        cascde3.Add("");
                        MyClass obj2 = new MyClass();
                        obj2.dr = obj2.ret_dr(CascQury);
                        if (obj2.dr.HasRows)
                        {
                            while (obj2.dr.Read())
                            {
                                CascQuryName = obj2.dr["Quantity"].ToString();
                                CascQuryid = obj2.dr["ProductUOM"].ToString();
                                CascPdrt = obj2.dr["ProductCode"].ToString();
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
                            }
                        }
                        else
                        {
                            //CascQuryName = obj.dr["Quantity"].ToString();
                            //CascQuryid = obj.dr["ProductUOM"].ToString();
                            //XElement CASCCodeThree = new XElement(ns2 + "CASCCodeThree", "");
                            //XElement CASCCodeTwo = new XElement(ns2 + "CASCCodeTwo", "");
                            //XElement CASCCodeOne = new XElement(ns2 + "CASCCodeOne", "");

                            //AdditionalCASCIdentification.Add(CASCCodeOne);
                            //AdditionalCASCIdentification.Add(CASCCodeTwo);
                            //AdditionalCASCIdentification.Add(CASCCodeThree);
                        }
                        XElement CASCProductQuantity = new XElement(ns2 + "CASCProductQuantity", CascQuryName);
                        CASCProductQuantity.Add(new XAttribute("unitCode", CascQuryid));
                        XElement CASCProductCode = new XElement(ns2 + "CASCProductCode", CascPdrt.ToUpper());
                        XElement CASCProduct = new XElement(ns3 + "CASCProduct", "");
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
                        }
                        XElement ItemExchangeRate1 = new XElement(ns2 + "ExchangeRate", "0.00");
                        XElement ItemAmount1 = new XElement(ns2 + "Amount", "0.00");
                        ItemAmount1.Add(new XAttribute("currencyID", ""));
                        XElement OptionalItemCharge = new XElement(ns3 + "OptionalItemCharge", "");
                        OptionalItemCharge.Add(ItemAmount1);
                        OptionalItemCharge.Add(ItemExchangeRate1);
                        XElement ItemExchangeRate = new XElement(ns2 + "ExchangeRate", obj.dr["ExchangeRate"].ToString());
                        XElement ItemAmount = new XElement(ns2 + "Amount", obj.dr["UnitPrice"].ToString());
                        ItemAmount.Add(new XAttribute("currencyID", obj.dr["UnitPriceCurrency"].ToString()));
                        XElement UnitPriceValue = new XElement(ns3 + "UnitPriceValue", "");
                        UnitPriceValue.Add(ItemAmount);
                        UnitPriceValue.Add(ItemExchangeRate);
                        XElement LastSellingPriceValue = new XElement(ns2 + "LastSellingPriceValue", obj.dr["LSPValue"].ToString());
                        XElement ItemCIFFOBValue = new XElement(ns2 + "ItemCIFFOBValue", obj.dr["CIFFOB"].ToString());
                        XElement TransactionValue = new XElement(ns3 + "TransactionValue", "");
                        if (Convert.ToDecimal(obj.dr["CIFFOB"].ToString()) > 0)
                        {
                            TransactionValue.Add(ItemCIFFOBValue);
                        }
                        if (Convert.ToDecimal(obj.dr["LSPValue"].ToString()) > 0)
                        {
                            TransactionValue.Add(LastSellingPriceValue);
                        }
                        //if (dt.Rows[0]["DeclarationType"].ToString() != "DNG : Duty & GST" && dt.Rows[0]["DeclarationType"].ToString() != "DUT : Duty")
                        //{
                        if (!string.IsNullOrWhiteSpace(obj.dr["UnitPriceCurrency"].ToString()))
                        {
                            if (obj.dr["UnitPriceCurrency"].ToString() != "--Select--")
                            {
                                string hsval1 = "";
                                string hscvalue = obj.dr["HSCode"].ToString();
                                hsval1 = hscvalue.Substring(0, 6);
                                hscvalue = hscvalue.Substring(0, 3);
                                if (hscvalue == "220")
                                {

                                }
                                else if (hscvalue == "270")
                                {

                                }
                                else if (hscvalue == "271")
                                {

                                }
                                else if (hscvalue == "240")
                                {

                                }
                                else if (hscvalue == "330")
                                {

                                }
                                else
                                {
                                    if (hsval1 != "210690")
                                    {
                                        if (hsval1 != "38260090")
                                        {
                                            if (Convert.ToDecimal(obj.dr["UnitPrice"].ToString()) > 0)
                                            {
                                                TransactionValue.Add(UnitPriceValue);
                                            }
                                        }
                                    }

                                }
                                //string chkval = "";
                                //string itemQury1 = "Select Count(*) from ChkHsCode where HSCode='" + obj.dr["HSCode"].ToString() + "'";
                                //MyClass objchk = new MyClass();
                                //objchk.dr = objchk.ret_dr(itemQury1);
                                //if (objchk.dr.HasRows)
                                //{
                                //    while (objchk.dr.Read())
                                //    {
                                //        chkval = objchk.dr[0].ToString();
                                //    }
                                //}
                                //if (chkval == "1")
                                //{
                                //}
                                //else
                                //{
                                //    TransactionValue.Add(UnitPriceValue);
                                //}
                            }
                        }

                        //}
                        //TransactionValue.Add(OptionalItemCharge);
                        string[] corgin = obj.dr["Contry"].ToString().Split(':');
                        string cuntry = corgin[0].ToString().Substring(0, corgin[0].Length - 1);
                        XElement OriginCountry = new XElement(ns2 + "OriginCountry", corgin[0].ToString());
                        XElement AlcoholPercent = new XElement(ns2 + "AlcoholPercent", obj.dr["AlcoholPer"].ToString());
                        XElement DutiableQuantity = new XElement(ns2 + "DutiableQuantity", obj.dr["DutiableQty"].ToString());
                        DutiableQuantity.Add(new XAttribute("unitCode", obj.dr["DutiableUOM"].ToString()));
                        XElement TotalDutiableQuantity = new XElement(ns2 + "TotalDutiableQuantity", obj.dr["TotalDutiableQty"].ToString());
                        TotalDutiableQuantity.Add(new XAttribute("unitCode", obj.dr["TotalDutiableUOM"].ToString()));
                        XElement HarmonizedSystemQuantity = new XElement(ns2 + "HarmonizedSystemQuantity", obj.dr["HSQty"].ToString());
                        HarmonizedSystemQuantity.Add(new XAttribute("unitCode", obj.dr["HSUOM"].ToString()));
                        XElement ItemQuantity = new XElement(ns3 + "ItemQuantity", "");
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
                        XElement GoodsDescription = new XElement(ns2 + "GoodsDescription", obj.dr["Description"].ToString().ToUpper().ToUpper());
                        XElement ItemHarmonizedSystemCode = new XElement(ns2 + "ItemHarmonizedSystemCode", obj.dr["HSCode"].ToString().ToUpper());
                        XElement ItemSequenceNumeric = new XElement(ns2 + "ItemSequenceNumeric", obj.dr["ItemNo"].ToString().ToUpper());
                        Item = new XElement(ns5 + "Item");
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
                            Item.Add(OriginCountry);
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["UnitPriceCurrency"].ToString()))
                        {
                            if (obj.dr["UnitPriceCurrency"].ToString() != "--Select--")
                            {
                                Item.Add(TransactionValue);
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(CascPdrt))
                        {
                            Item.Add(CASCProduct);
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
                        //Item.Add(ShippingMarksInformation);
                        if (!string.IsNullOrWhiteSpace(making))
                        {
                            Item.Add(LotIdentification);
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["InHAWBOBL"].ToString()))
                        {
                            Item.Add(InHAWBHUCRHBLNumber);
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["InvoiceNo"].ToString()))
                        {
                            if (obj.dr["InvoiceNo"].ToString() != "--Select--")
                            {
                                Item.Add(ItemInvoiceNumber);
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(obj.dr["EngineCapcity"].ToString()))
                        {
                            if (obj.dr["EngineCapcity"].ToString() != "--Select--")
                            {
                                Item.Add(MotorVehicle);
                            }
                        }
                        Item.Add(Tariff);
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
                //reportElement.Add(new XElement(ns2 + "RecipientID", "DCS4.DCS4001"));
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
            string filename = path + "\\IPTDEC" + MsgId + ".xml";
            // Create a file to write to.
            if (!File.Exists(filename))
            {
                //File.Delete(filename);
                using (StreamWriter sw = File.CreateText(filename))
                {
                    sw.WriteLine(sb.ToString());
                    string Name = "IPTDEC" + MsgId + ".xml";
                    string strins = "";
                    strins = "Insert Into XmlTbl values('" + path + "','" + Name + "','','" + tradeID.ToLower() + "')";
                    obj.exec(strins);

                    strins = "Insert Into DownXmlTbl values('" + path + "','" + Name + "','','" + tradeID.ToLower() + "')";
                    obj.exec(strins);


                    string strinsn = "";
                    //Send CMD 
                    // Command=Submit|cont_type=F|subj=IPTDEC202510290002|filename=D:\\MHAccess\\workingdir\\KaizenOUT\\KAKG001\\IPTDEC202510290002.xml|cont_id=G14848838067|recip_id=dcst401|notifn=N"

                    string sunjt = "IPTDEC" + MsgId + "";
                    strinsn = "Insert Into Customs_Data values('" + tradeID.ToLower() + "','" + path + "','" + Name + "','Command=Submit|cont_type=F|subj=" + sunjt + "|filename=" + path + "\\" + Name + "|cont_id=G14848838067|recip_id=dcst401|notifn=N','Send CMD','Not Executed')";
                    obj.exec(strinsn);
                    obj.exec(strinsn);
                    //obj.dr = obj.ret_dr("select * from Customs_Data where Status='Not Executed'");
                    //while (obj.dr.Read())
                    //{
                    //    MyClass objsss = new MyClass();                       
                    //    objsss.exec("update Customs_Data set Status='Executed' where id='"+ obj.dr["id"].ToString() + "'");

                    //    string body = obj.dr["CMD"].ToString() + Environment.NewLine + "Command=Retrieve|filename=D:\\MHAccess\\workingdir\\KaizenIN\\KAKG001\\"+ sunjt + ".xml|sender_id=dcst401|loc=I";
                    //    string eml = body;
                    //    File.WriteAllText(@"D:\MHAccess\pmmin.msg", eml);
                    //}
                    obj.closecon();
                }
            }
           
        }
        //private void LoadIPTDEC(string permit)
        //{
        //    string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
        //    using (SqlConnection con = new SqlConnection(constr))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("select * from inheadertbl  where PermitId='" + permit + "'"))
        //        {
        //            using (SqlDataAdapter sda = new SqlDataAdapter())
        //            {
        //                cmd.Connection = con;
        //                sda.SelectCommand = cmd;
        //                sda.Fill(dt);
        //            }
        //        }
        //    }

        //    StringBuilder sb = new StringBuilder();
        //    XmlWriterSettings xws = new XmlWriterSettings();
        //    xws.OmitXmlDeclaration = true;
        //    xws.Indent = true;

        //    using (XmlWriter xw = XmlWriter.Create(sb, xws))
        //    {
        //        XNamespace ns1 = "urn:crimsonlogic:tn:schema:xsd:TradenetDeclaration";
        //        XNamespace ns2 = "urn:crimsonlogic:tn:schema:xsd:CommonBasicComponents-2";
        //        XNamespace ns3 = "urn:crimsonlogic:tn:schema:xsd:CommonAggregateComponents-2";
        //        XNamespace ns4 = "urn:crimsonlogic:tn:schema:xsd:InNonPayment";
        //        XNamespace ns5 = "urn:crimsonlogic:tn:schema:xsd:InPayment";
        //        XNamespace ns6 = "urn:crimsonlogic:tn:schema:xsd:OutwardDeclaration";
        //        XNamespace ns7 = "urn:crimsonlogic:tn:schema:xsd:TranshipmentMovement";
        //        XNamespace ns8 = "urn:crimsonlogic:tn:schema:xsd:CertificateOfOrigin";

        //        XDocument doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
        //        XElement reportElement = new XElement(ns1 + "TradenetDeclaration",
        //        new XAttribute(XNamespace.Xmlns + "cbc", ns2),
        //        new XAttribute(XNamespace.Xmlns + "cac", ns3),
        //        new XAttribute(XNamespace.Xmlns + "inp", ns4),
        //        new XAttribute(XNamespace.Xmlns + "ipt", ns5),
        //        new XAttribute(XNamespace.Xmlns + "out", ns6),
        //        new XAttribute(XNamespace.Xmlns + "tnp", ns7),
        //        new XAttribute(XNamespace.Xmlns + "coo", ns8));
        //        string Date = DateTime.Now.ToString("yyyyMMddHHmm");
        //        reportElement.Add(new XAttribute("dateTime", Date));
        //        reportElement.Add(new XAttribute("instanceIdentifier", dt.Rows[0]["JobId"].ToString()));
        //        doc.Add(reportElement);


        //        MSGNUMBER = dt.Rows[0]["MSGId"].ToString();

        //        XElement TotalAmountPayable = new XElement(ns2 + "TotalAmountPayable", dt.Rows[0]["TotalAmtPay"].ToString().ToUpper());
        //        XElement TotalOtherTaxAmount = new XElement(ns2 + "TotalOtherTaxAmount", dt.Rows[0]["TotalODutyAmt"].ToString().ToUpper());
        //        XElement TotalCustomsDutyAmount = new XElement(ns2 + "TotalCustomsDutyAmount", dt.Rows[0]["TotalCusDutyAmt"].ToString().ToUpper());
        //        XElement TotalExciseDutyAmount = new XElement(ns2 + "TotalExciseDutyAmount", dt.Rows[0]["TotalExDutyAmt"].ToString().ToUpper());
        //        XElement TotalGoodsAndServicesTaxAmount = new XElement(ns2 + "TotalGoodsAndServicesTaxAmount", dt.Rows[0]["TotalGSTTaxAmt"].ToString().ToUpper());
        //        XElement TotalTariff = new XElement(ns3 + "TotalTariff", "");
        //        if (Convert.ToDecimal(dt.Rows[0]["TotalGSTTaxAmt"].ToString()) > 0)
        //        {
        //            TotalTariff.Add(TotalGoodsAndServicesTaxAmount);
        //        }
        //        if (Convert.ToDecimal(dt.Rows[0]["TotalExDutyAmt"].ToString()) > 0)
        //        {
        //            TotalTariff.Add(TotalExciseDutyAmount);
        //        }
        //        if (Convert.ToDecimal(dt.Rows[0]["TotalCusDutyAmt"].ToString()) > 0)
        //        {
        //            TotalTariff.Add(TotalCustomsDutyAmount);
        //        }
        //        if (Convert.ToDecimal(dt.Rows[0]["TotalODutyAmt"].ToString()) > 0)
        //        {
        //            TotalTariff.Add(TotalOtherTaxAmount);
        //        }
        //        if (Convert.ToDecimal(dt.Rows[0]["TotalAmtPay"].ToString()) > 0)
        //        {
        //            TotalTariff.Add(TotalAmountPayable);
        //        }
        //        XElement TotalGrossWeight = new XElement(ns2 + "TotalGrossWeight", dt.Rows[0]["TotalGrossWeight"].ToString().ToUpper());
        //        TotalGrossWeight.Add(new XAttribute("unitCode", dt.Rows[0]["TotalGrossWeightUOM"].ToString().ToUpper()));
        //        XElement TotalOuterPack = new XElement(ns2 + "TotalOuterPack", dt.Rows[0]["TotalOuterPack"].ToString().ToUpper());
        //        TotalOuterPack.Add(new XAttribute("unitCode", dt.Rows[0]["TotalOuterPackUOM"].ToString().ToUpper()));
        //        XElement TotalCIFFOBValue = new XElement(ns2 + "TotalCIFFOBValue", dt.Rows[0]["TotalCIFFOBValue"].ToString().ToUpper());
        //        //  string NoItem = Math.Round(Convert.ToDecimal(obj.dr["GSTRate"].ToString()), 0).ToString();
        //        //string noofitem = dt.Rows[0]["NumberOfItems"].ToString("0");
        //        XElement NumberOfItems = new XElement(ns2 + "NumberOfItems", Math.Round(Convert.ToDecimal(dt.Rows[0]["NumberOfItems"].ToString().ToUpper()), 0));
        //        XElement Summary = new XElement(ns5 + "Summary");
        //        if (Convert.ToDecimal(dt.Rows[0]["NumberOfItems"].ToString()) > 0)
        //        {
        //            Summary.Add(NumberOfItems);
        //        }
        //        if (Convert.ToDecimal(dt.Rows[0]["TotalCIFFOBValue"].ToString()) > 0)
        //        {
        //            Summary.Add(TotalCIFFOBValue);
        //        }
        //        if (!string.IsNullOrWhiteSpace(dt.Rows[0]["TotalOuterPackUOM"].ToString()))
        //        {
        //            if (dt.Rows[0]["TotalOuterPackUOM"].ToString() != "--Select--")
        //            {
        //                Summary.Add(TotalOuterPack);
        //            }
        //        }
        //        if (!string.IsNullOrWhiteSpace(dt.Rows[0]["TotalGrossWeightUOM"].ToString()))
        //        {
        //            if (dt.Rows[0]["TotalGrossWeightUOM"].ToString() != "--Select--")
        //            {
        //                Summary.Add(TotalGrossWeight);
        //            }
        //        }
        //        if (Convert.ToDecimal(dt.Rows[0]["TotalGSTTaxAmt"].ToString()) > 0)
        //        {
        //            Summary.Add(TotalTariff);
        //        }
        //        //Summary
        //        XElement Item = null;


        //        //Item
        //        XElement InvoiceName = new XElement(ns3 + "Invoice", "");
        //        string invQury = "select * from dbo.InvoiceDtl where PermitId='" + dt.Rows[0]["PermitId"].ToString() + "'";
        //        obj.dr = obj.ret_dr(invQury);
        //        if (obj.dr.HasRows)
        //        {
        //            while (obj.dr.Read())
        //            {
        //                XElement ChargePercent3 = new XElement(ns2 + "ChargePercent", obj.dr["OTCCharge"].ToString().ToUpper());
        //                XElement ExchangeRate3 = new XElement(ns2 + "ExchangeRate", obj.dr["OTCExRate"].ToString().ToUpper());
        //                XElement Amount3 = new XElement(ns2 + "Amount", obj.dr["OTCAmount"].ToString().ToUpper());
        //                string Othercurny = "";
        //                if (obj.dr["OTCCurrency"].ToString() == "--Select--")
        //                {
        //                    Othercurny = "";
        //                }
        //                else
        //                {
        //                    Othercurny = obj.dr["OTCCurrency"].ToString();
        //                }
        //                Amount3.Add(new XAttribute("currencyID", Othercurny));
        //                XElement OtherTaxableCharge = new XElement(ns3 + "OtherTaxableCharge", "");
        //                XElement ChargePercent2 = new XElement(ns2 + "ChargePercent", obj.dr["ICCharge"].ToString().ToUpper());
        //                XElement ExchangeRate2 = new XElement(ns2 + "ExchangeRate", obj.dr["ICExRate"].ToString().ToUpper());
        //                XElement Amount2 = new XElement(ns2 + "Amount", obj.dr["ICAmount"].ToString().ToUpper());
        //                string Incucurny = "";
        //                if (obj.dr["ICCurrency"].ToString() == "--Select--")
        //                {
        //                    Incucurny = "";
        //                }
        //                else
        //                {
        //                    Incucurny = obj.dr["ICCurrency"].ToString();
        //                }
        //                Amount2.Add(new XAttribute("currencyID", Incucurny));
        //                XElement InsuranceCharge = new XElement(ns3 + "InsuranceCharge", "");
        //                XElement ChargePercent = new XElement(ns2 + "ChargePercent", obj.dr["FCCharge"].ToString().ToUpper());
        //                XElement ExchangeRate1 = new XElement(ns2 + "ExchangeRate", obj.dr["FCExRate"].ToString().ToUpper());
        //                XElement Amount1 = new XElement(ns2 + "Amount", obj.dr["FCAmount"].ToString().ToUpper());
        //                string frgtcurny = "";
        //                if (obj.dr["FCCurrency"].ToString() == "--Select--")
        //                {
        //                    frgtcurny = "";
        //                }
        //                else
        //                {
        //                    frgtcurny = obj.dr["FCCurrency"].ToString();
        //                }
        //                Amount1.Add(new XAttribute("currencyID", frgtcurny));
        //                XElement FreightCharge = new XElement(ns3 + "FreightCharge", "");
        //                XElement ExchangeRate = new XElement(ns2 + "ExchangeRate", obj.dr["TIExRate"].ToString().ToUpper());
        //                XElement Amount = new XElement(ns2 + "Amount", obj.dr["TIAmount"].ToString().ToUpper());
        //                Amount.Add(new XAttribute("currencyID", obj.dr["TICurrency"].ToString().ToUpper()));
        //                XElement TotalInvoiceValue = new XElement(ns3 + "TotalInvoiceValue", "");
        //                string[] termtype = obj.dr["TermType"].ToString().Split(':');
        //                XElement UnitPriceTermType = new XElement(ns2 + "UnitPriceTermType", termtype[0].ToString().Substring(0, termtype[0].Length - 1).ToUpper());
        //                string Suppqury = "select CRUEI,Name from dbo.SUPPLIERMANUFACTURERPARTY where Code='" + obj.dr["SupplierCode"].ToString().ToUpper() + "'";
        //                string SuppName = "", Suppid = "";
        //                MyClass obj1 = new MyClass();
        //                obj1.dr = obj1.ret_dr(Suppqury);
        //                while (obj1.dr.Read())
        //                {
        //                    // CPC.Add(obj.dr[0].ToString());
        //                    SuppName = obj1.dr["Name"].ToString();
        //                    Suppid = obj1.dr["CRUEI"].ToString();
        //                }
        //                XElement InvName = new XElement(ns2 + "Name", SuppName.ToUpper());
        //                XElement InvCodeValue = new XElement(ns2 + "CodeValue", Suppid.ToUpper());
        //                XElement SupplierManufacturerParty = new XElement(ns3 + "SupplierManufacturerParty", "");
        //                XElement InvoiceDate = new XElement(ns2 + "InvoiceDate", Convert.ToDateTime(obj.dr["InvoiceDate"].ToString()).ToString("yyyyMMdd").ToUpper());
        //                XElement InvoiceNumber = new XElement(ns2 + "InvoiceNumber", obj.dr["InvoiceNo"].ToString().ToUpper());
        //                if (!string.IsNullOrWhiteSpace(obj.dr["InvoiceNo"].ToString()))
        //                {
        //                    String Decty = dt.Rows[0]["DeclarationType"].ToString();
        //                    if (dt.Rows[0]["RecepitLocation"].ToString().ToUpper() == "AISSLOC" || dt.Rows[0]["RecepitLocation"].ToString().ToUpper() == "SPIGDS" || dt.Rows[0]["RecepitLocation"].ToString().ToUpper() == "SPSTK" || dt.Rows[0]["RecepitLocation"].ToString().ToUpper() == "SPNOSTK" || dt.Rows[0]["RecepitLocation"].ToString().ToUpper() == "SPIGDS" || dt.Rows[0]["RecepitLocation"].ToString().ToUpper() == "RCNOSTK")
        //                    {
        //                     //   InvoiceName.Add(InvoiceNumber);
        //                    }
        //                    else  if (dt.Rows[0]["ReleaseLocation"].ToString().ToUpper() == "EM" || dt.Rows[0]["ReleaseLocation"].ToString().ToUpper() == "EXEMPT")
        //                    {
        //                      //  InvoiceName.Add(InvoiceNumber);
        //                    }

        //                    else if (Decty == "BKT : Blanket ")
        //                    {
        //                      //  InvoiceName.Add(InvoiceNumber);
        //                    }
        //                    else
        //                    {
        //                        InvoiceName.Add(InvoiceNumber);
        //                    }




        //                }
        //                if (!string.IsNullOrWhiteSpace(obj.dr["InvoiceDate"].ToString()))
        //                {
        //                    String Decty = dt.Rows[0]["DeclarationType"].ToString();
        //                    if (dt.Rows[0]["RecepitLocation"].ToString().ToUpper() == "AISSLOC" || dt.Rows[0]["RecepitLocation"].ToString().ToUpper() == "SPIGDS" || dt.Rows[0]["RecepitLocation"].ToString().ToUpper() == "SPSTK" || dt.Rows[0]["RecepitLocation"].ToString().ToUpper() == "SPNOSTK" || dt.Rows[0]["RecepitLocation"].ToString().ToUpper() == "SPIGDS" || dt.Rows[0]["RecepitLocation"].ToString().ToUpper() == "RCNOSTK")
        //                    {
        //                      //  InvoiceName.Add(InvoiceDate);
        //                    }
        //                    else if (dt.Rows[0]["ReleaseLocation"].ToString().ToUpper() == "EM" || dt.Rows[0]["ReleaseLocation"].ToString().ToUpper() == "EXEMPT")
        //                    {
        //                      //  InvoiceName.Add(InvoiceDate);
        //                    }

        //                    else if (Decty == "BKT : Blanket ")
        //                    {
        //                       // InvoiceName.Add(InvoiceDate);
        //                    }
        //                    else
        //                    {
        //                        InvoiceName.Add(InvoiceDate);
        //                    }
        //                }
        //                if (!string.IsNullOrWhiteSpace(Suppid))
        //                {
        //                    String Decty = dt.Rows[0]["DeclarationType"].ToString();
        //                    if (dt.Rows[0]["RecepitLocation"].ToString().ToUpper() == "AISSLOC" || dt.Rows[0]["RecepitLocation"].ToString().ToUpper() == "SPIGDS" || dt.Rows[0]["RecepitLocation"].ToString().ToUpper() == "SPSTK" || dt.Rows[0]["RecepitLocation"].ToString().ToUpper() == "SPNOSTK" || dt.Rows[0]["RecepitLocation"].ToString().ToUpper() == "SPIGDS" || dt.Rows[0]["RecepitLocation"].ToString().ToUpper() == "RCNOSTK")
        //                    {
        //                        //  InvoiceName.Add(InvoiceDate);
        //                    }
        //                    else if (dt.Rows[0]["ReleaseLocation"].ToString().ToUpper() == "EM" || dt.Rows[0]["ReleaseLocation"].ToString().ToUpper() == "EXEMPT")
        //                    {
        //                        //  InvoiceName.Add(InvoiceDate);
        //                    }

        //                    else if (Decty == "BKT : Blanket ")
        //                    {
        //                        // InvoiceName.Add(InvoiceDate);
        //                    }
        //                    else
        //                    {
        //                        InvoiceName.Add(SupplierManufacturerParty);
        //                        SupplierManufacturerParty.Add(InvCodeValue);
        //                        SupplierManufacturerParty.Add(InvName);
        //                    }

        //                }
        //                if (!string.IsNullOrWhiteSpace(termtype[0].ToString().Substring(0, termtype[0].Length - 1)))
        //                {
        //                    InvoiceName.Add(UnitPriceTermType);
        //                }
        //                if (!string.IsNullOrWhiteSpace(obj.dr["TICurrency"].ToString()))
        //                {
        //                    if (obj.dr["TICurrency"].ToString() != "--Select--")
        //                    {
        //                        InvoiceName.Add(TotalInvoiceValue);
        //                        TotalInvoiceValue.Add(Amount);
        //                        TotalInvoiceValue.Add(ExchangeRate);
        //                    }
        //                }
        //                if (!string.IsNullOrWhiteSpace(frgtcurny))
        //                {
        //                    InvoiceName.Add(FreightCharge);
        //                    FreightCharge.Add(Amount1);
        //                    FreightCharge.Add(ExchangeRate1);
        //                    if (Convert.ToDecimal(obj.dr["FCCharge"].ToString()) > 0)
        //                    {
        //                        FreightCharge.Add(ChargePercent);
        //                    }
        //                }
        //                if (!string.IsNullOrWhiteSpace(Incucurny))
        //                {
        //                    InvoiceName.Add(InsuranceCharge);
        //                    InsuranceCharge.Add(Amount2);
        //                    InsuranceCharge.Add(ExchangeRate2);
        //                    if (Convert.ToDecimal(obj.dr["ICCharge"].ToString()) > 0)
        //                    {
        //                        InsuranceCharge.Add(ChargePercent2);
        //                    }
        //                }
        //                if (!string.IsNullOrWhiteSpace(Othercurny))
        //                {
        //                    InvoiceName.Add(OtherTaxableCharge);
        //                    OtherTaxableCharge.Add(Amount3);
        //                    OtherTaxableCharge.Add(ExchangeRate3);
        //                    if (Convert.ToDecimal(obj.dr["OTCCharge"].ToString()) > 0)
        //                    {
        //                        OtherTaxableCharge.Add(ChargePercent3);
        //                    }
        //                }
        //            }
        //        }

        //        string SupFile = "";
        //        XElement SupportingDocumentReference = new XElement(ns3 + "SupportingDocumentReference", "");
        //        string infilname = "select * from InFile where InPaymentId='" + dt.Rows[0]["PermitId"].ToString() + "'";
        //        obj.dr = obj.ret_dr(infilname);
        //        while (obj.dr.Read())
        //        {
        //            XElement Filename = new XElement(ns2 + "Filename", obj.dr["Name"].ToString().ToUpper());
        //            string[] docuID = obj.dr["DocumentType"].ToString().Split(':');
        //            XElement DocumentID = new XElement(ns2 + "DocumentID", docuID[0].ToString().Substring(0, docuID[0].Length - 1).ToUpper());
        //            SupFile = docuID[0].ToString().Substring(0, docuID[0].Length - 1);
        //            SupportingDocumentReference.Add(DocumentID);
        //            SupportingDocumentReference.Add(Filename);
        //        }
        //        string licNo = "";
        //        XElement Licence = new XElement(ns3 + "Licence", "");
        //        string[] refid = dt.Rows[0]["License"].ToString().Split('-');
        //        for (int ri = 0; ri < refid.Length; ri++)
        //        {
        //            if (!string.IsNullOrWhiteSpace(refid[ri].ToString()))
        //            {
        //                licNo = refid[0].ToString();
        //                XElement Referenceid = new XElement(ns2 + "ReferenceID", refid[ri].ToString().ToUpper());
        //                Licence.Add(Referenceid);
        //            }
        //        }
        //        string clamtparty = "select CRUEI,Name,ClaimantName1,ClaimantName from dbo.ClaimantParty where Name='" + dt.Rows[0]["ClaimantPartyCode"].ToString() + "'";
        //        string clamtpartyuName = "", clamtuei = "", clatinfocode = "", clatinfoname = "";
        //        obj.dr = obj.ret_dr(clamtparty);
        //        while (obj.dr.Read())
        //        {
        //            // CPC.Add(obj.dr[0].ToString());
        //            clamtpartyuName = obj.dr["Name"].ToString();
        //            clamtuei = obj.dr["CRUEI"].ToString();
        //            clatinfocode = obj.dr["ClaimantName1"].ToString();
        //            clatinfoname = obj.dr["ClaimantName"].ToString();
        //        }
        //        XElement LicName = new XElement(ns2 + "Name", clatinfoname.ToUpper());
        //        XElement LicCodeValue = new XElement(ns2 + "CodeValue", clatinfocode.ToUpper());
        //        XElement ClaimantInformation = new XElement(ns3 + "ClaimantInformation", "");
        //        XElement ClainmentInfoName = new XElement(ns2 + "Name", clamtpartyuName.ToUpper());
        //        XElement ClainmentInfoPartyName = new XElement(ns3 + "PartyName", "");
        //        XElement ClainmentInfoID = new XElement(ns2 + "ID", clamtuei.ToUpper());
        //        XElement ClainmentPartyIdentification = new XElement(ns3 + "PartyIdentification", "");
        //        XElement PartyDetail = new XElement(ns3 + "PartyDetail", "");
        //        XElement ClaimantParty = new XElement(ns3 + "ClaimantParty", "");
        //        ClaimantParty.Add(PartyDetail);
        //        PartyDetail.Add(ClainmentPartyIdentification);
        //        ClainmentPartyIdentification.Add(ClainmentInfoID);
        //        PartyDetail.Add(ClainmentInfoPartyName);
        //        ClainmentInfoPartyName.Add(ClainmentInfoName);
        //        if (!string.IsNullOrWhiteSpace(clatinfocode))
        //        {
        //            ClaimantParty.Add(ClaimantInformation);
        //            ClaimantInformation.Add(LicCodeValue);
        //            ClaimantInformation.Add(LicName);
        //        }
        //        string impotparty = "select CRUEI,Name,Name1 from dbo.Importer where Code='" + dt.Rows[0]["ImporterCompanyCode"].ToString() + "'";
        //        string importName = "", importName1="", Importid = "";
        //        obj.dr = obj.ret_dr(impotparty);
        //        while (obj.dr.Read())
        //        {
        //            // CPC.Add(obj.dr[0].ToString());
        //            importName = obj.dr["Name"].ToString();
        //            importName1 = obj.dr["Name1"].ToString();
        //            Importid = obj.dr["CRUEI"].ToString();
        //        }
        //        XElement ClainmentName1 = new XElement(ns2 + "Name", importName1.ToUpper());
        //        XElement ClainmentName = new XElement(ns2 + "Name", importName.ToUpper());
        //        XElement ClainmentPartyName = new XElement(ns3 + "PartyName", "");
        //        XElement ClainmentID = new XElement(ns2 + "ID", Importid.ToUpper());
        //        XElement ImportPartyIdentification = new XElement(ns3 + "PartyIdentification", "");
        //        XElement ImporterParty = new XElement(ns3 + "ImporterParty", "");
        //        ImporterParty.Add(ImportPartyIdentification);
        //        ImportPartyIdentification.Add(ClainmentID);
        //        ImporterParty.Add(ClainmentPartyName);
        //        ClainmentPartyName.Add(ClainmentName);
        //        if (!string.IsNullOrWhiteSpace(importName1))
        //        {
        //            ClainmentPartyName.Add(ClainmentName1);
        //        }
        //        XElement InwardCarrierAgentParty = null;
        //        string inwardparty = "select CRUEI,Name,Name1 from dbo.InwardCarrierAgent where Code='" + dt.Rows[0]["InwardCarrierAgentCode"].ToString() + "'";
        //        string inwardName = "", inwardName1="", inwardid = "";
        //        if (dt.Rows[0]["InwardTransportMode"].ToString() == "1 : Sea" || dt.Rows[0]["InwardTransportMode"].ToString() == "4 : Air")
        //        {
        //            obj.dr = obj.ret_dr(inwardparty);
        //            while (obj.dr.Read())
        //            {
        //                // CPC.Add(obj.dr[0].ToString());
        //                inwardName = obj.dr["Name"].ToString();
        //                inwardName1 = obj.dr["Name1"].ToString();
        //                inwardid = obj.dr["CRUEI"].ToString();
        //            }
        //            XElement ImportName1 = new XElement(ns2 + "Name", inwardName1.ToUpper());
        //            XElement ImportName = new XElement(ns2 + "Name", inwardName.ToUpper());
        //            XElement ImportPartyName = new XElement(ns3 + "PartyName", "");
        //            XElement ImportID = new XElement(ns2 + "ID", inwardid.ToUpper());
        //            XElement InwardPartyIdentification = new XElement(ns3 + "PartyIdentification", "");
        //            InwardCarrierAgentParty = new XElement(ns3 + "InwardCarrierAgentParty", "");

        //            InwardCarrierAgentParty.Add(InwardPartyIdentification);
        //            InwardPartyIdentification.Add(ImportID);
        //            InwardCarrierAgentParty.Add(ImportPartyName);
        //            ImportPartyName.Add(ImportName);
        //            if (!string.IsNullOrWhiteSpace(inwardName1))
        //            {
        //                ImportPartyName.Add(ImportName1);
        //            }
        //        }
        //        string freiparty = "select CRUEI,Name,Name1 from dbo.FreightForwarder where Code='" + dt.Rows[0]["FreightForwarderCode"].ToString() + "'";
        //        string FreiName = "", FreiName1="", FreiID = "";
        //        obj.dr = obj.ret_dr(freiparty);
        //        while (obj.dr.Read())
        //        {
        //            // CPC.Add(obj.dr[0].ToString());
        //            FreiID = obj.dr["CRUEI"].ToString();
        //            FreiName = obj.dr["Name"].ToString();
        //            FreiName1 = obj.dr["Name1"].ToString();
        //            //InwardTransportMode = obj.dr[1].ToString();
        //        }
        //        XElement InwardName1 = new XElement(ns2 + "Name", FreiName1.ToUpper());
        //        XElement InwardName = new XElement(ns2 + "Name", FreiName.ToUpper());
        //        XElement InwardPartyName = new XElement(ns3 + "PartyName", "");
        //        XElement InwardID = new XElement(ns2 + "ID", FreiID.ToUpper());
        //        XElement FreightPartyIdentification = new XElement(ns3 + "PartyIdentification", "");
        //        XElement FreightForwarderParty = new XElement(ns3 + "FreightForwarderParty", "");
        //        FreightForwarderParty.Add(FreightPartyIdentification);
        //        FreightPartyIdentification.Add(InwardID);
        //        FreightForwarderParty.Add(InwardPartyName);
        //        InwardPartyName.Add(InwardName);
        //        if (!string.IsNullOrWhiteSpace(FreiName1))
        //        {
        //            InwardPartyName.Add(InwardName1);
        //        }
        //        string delparty = "select CRUEI,Name,Name1 from dbo.DeclarantCompany where Code='" + dt.Rows[0]["DeclarantCompanyCode"].ToString() + "'";
        //        string declrName = "", declrName1="", declrid = "";
        //        obj.dr = obj.ret_dr(delparty);
        //        while (obj.dr.Read())
        //        {
        //            // CPC.Add(obj.dr[0].ToString());
        //            declrid = obj.dr["CRUEI"].ToString();
        //            declrName = obj.dr["Name"].ToString();
        //            declrName1 = obj.dr["Name1"].ToString();
        //            //InwardTransportMode = obj.dr[1].ToString();
        //        }
        //        XElement FreightName1 = new XElement(ns2 + "Name", declrName1.ToUpper());
        //        XElement FreightName = new XElement(ns2 + "Name", declrName.ToUpper());
        //        XElement PartyName = new XElement(ns3 + "PartyName", "");
        //        XElement ID = new XElement(ns2 + "ID", declrid.ToUpper());
        //        XElement PartyIdentification = new XElement(ns3 + "PartyIdentification", "");
        //        XElement DeclaringAgentParty = new XElement(ns3 + "DeclaringAgentParty", "");
        //        DeclaringAgentParty.Add(PartyIdentification);
        //        PartyIdentification.Add(ID);
        //        DeclaringAgentParty.Add(PartyName);
        //        PartyName.Add(FreightName);
        //        if (!string.IsNullOrWhiteSpace(declrName1))
        //        {
        //            PartyName.Add(FreightName1);
        //        }
        //        delparty = "select * from dbo.DeclarantCompany where TradeNetMailboxID='" + dt.Rows[0]["TradeNetMailboxID"].ToString() + "'";
        //        string telphn = "", decname = "", deccode = "",DecId="";
        //        obj.dr = obj.ret_dr(delparty);
        //        while (obj.dr.Read())
        //        {
        //            telphn = obj.dr["DeclarantTel"].ToString();
        //            decname = obj.dr["DeclarantName"].ToString();
        //            deccode = obj.dr["DeclarantCode"].ToString();
        //            DecId = obj.dr["CRUEI"].ToString();
        //        }

        //        XElement Telephone = new XElement(ns2 + "Telephone", telphn);
        //        XElement DeclarName = new XElement(ns2 + "Name", decname);
        //        XElement CodeValue = new XElement(ns2 + "CodeValue", deccode);
        //        XElement PersonInformation = new XElement(ns3 + "PersonInformation", "");
        //        XElement DeclarantParty = new XElement(ns3 + "DeclarantParty", "");
        //        DeclarantParty.Add(PersonInformation);
        //        PersonInformation.Add(CodeValue);
        //        PersonInformation.Add(DeclarName);
        //        DeclarantParty.Add(Telephone);
        //        XElement Party = new XElement(ns5 + "Party");
        //        Party.Add(DeclarantParty);
        //        if (!string.IsNullOrWhiteSpace(declrid))
        //        {
        //            Party.Add(DeclaringAgentParty);
        //        }
        //        if (!string.IsNullOrWhiteSpace(FreiID))
        //        {
        //            Party.Add(FreightForwarderParty);
        //        }
        //        if (!string.IsNullOrWhiteSpace(inwardid))
        //        {
        //            Party.Add(InwardCarrierAgentParty);
        //        }
        //        if (!string.IsNullOrWhiteSpace(Importid))
        //        {
        //            Party.Add(ImporterParty);
        //        }
        //        if (!string.IsNullOrWhiteSpace(clamtuei))
        //        {
        //            Party.Add(ClaimantParty);
        //        }
        //        if (!string.IsNullOrWhiteSpace(licNo))
        //        {
        //            Party.Add(Licence);
        //        }
        //        if (!string.IsNullOrWhiteSpace(SupFile))
        //        {
        //            Party.Add(SupportingDocumentReference);
        //        }
        //        //Party.Add(InvoiceName);
        //        //Party
        //        string conveno = "", mastebill = "", vessname = "";
        //        if (dt.Rows[0]["InwardTransportMode"].ToString() == "4 : Air")
        //        {
        //            conveno = dt.Rows[0]["FlightNO"].ToString();
        //            mastebill = dt.Rows[0]["MasterAirwayBill"].ToString();
        //        }
        //        else if (dt.Rows[0]["InwardTransportMode"].ToString() == "1 : Sea")
        //        {
        //            conveno = dt.Rows[0]["VoyageNumber"].ToString();
        //            mastebill = dt.Rows[0]["OceanBillofLadingNo"].ToString();
        //            vessname = dt.Rows[0]["VesselName"].ToString();
        //        }
        //        else
        //        {
        //            conveno = dt.Rows[0]["ConveyanceRefNo"].ToString();

        //            vessname = dt.Rows[0]["TransportId"].ToString();
        //        }

        //        XElement LoadingPort = new XElement(ns2 + "LoadingPort", dt.Rows[0]["LoadingPortCode"].ToString().ToUpper());
        //        XElement ArrivalDate = new XElement(ns2 + "ArrivalDate", Convert.ToDateTime(dt.Rows[0]["ArrivalDate"].ToString()).ToString("yyyyMMdd").ToUpper());
        //        XElement MAWBOUCROBLNumber = new XElement(ns2 + "MAWBOUCROBLNumber", mastebill.ToUpper());
        //        XElement TransportIdentifier = new XElement(ns2 + "TransportIdentifier", vessname.ToUpper());
        //        XElement ConveyanceReferenceNumber = new XElement(ns2 + "ConveyanceReferenceNumber", conveno.ToUpper());
        //        string[] mdecde = dt.Rows[0]["InwardTransportMode"].ToString().Split(':');
        //        XElement ModeCode = new XElement(ns2 + "ModeCode", mdecde[0].Substring(0, mdecde[0].Length - 1));
        //        XElement TransportMode = new XElement(ns3 + "TransportMode", "");
        //        XElement TransportMeans = new XElement(ns3 + "TransportMeans", "");
        //        XElement InwardTransport = new XElement(ns3 + "InwardTransport", "");
        //        if (mdecde[0].Substring(0, mdecde[0].Length - 1).ToString() != "N")
        //        {
        //            InwardTransport.Add(TransportMeans);
        //            TransportMeans.Add(TransportMode);
        //            if (dt.Rows[0]["InwardTransportMode"].ToString() != "--Select--")
        //            {
        //                if (!string.IsNullOrWhiteSpace(mdecde[0].Substring(0, mdecde[0].Length - 1)))
        //                {
        //                    TransportMode.Add(ModeCode);
        //                }
        //            }
        //        }
        //        if (!string.IsNullOrWhiteSpace(conveno))
        //        {
        //            TransportMode.Add(ConveyanceReferenceNumber);
        //        }
        //        if (!string.IsNullOrWhiteSpace(vessname))
        //        {
        //            TransportMode.Add(TransportIdentifier);
        //        }
        //        if (!string.IsNullOrWhiteSpace(mastebill))
        //        {
        //            TransportMeans.Add(MAWBOUCROBLNumber);
        //        }
        //        if (!string.IsNullOrWhiteSpace(dt.Rows[0]["ArrivalDate"].ToString()))
        //        {
        //            InwardTransport.Add(ArrivalDate);
        //        }
        //        if (!string.IsNullOrWhiteSpace(dt.Rows[0]["LoadingPortCode"].ToString()))
        //        {
        //            InwardTransport.Add(LoadingPort);
        //        }

        //        XElement Transport = new XElement(ns5 + "Transport", InwardTransport);
        //        //Transport


        //        XElement BlanketStartDate = new XElement(ns2 + "BlanketStartDate", Convert.ToDateTime(dt.Rows[0]["BlanketStartDate"].ToString()).ToString("yyyyMMdd").ToUpper());
        //        XElement SupplyIndicator = new XElement(ns2 + "SupplyIndicator", dt.Rows[0]["SupplyIndicator"].ToString().ToLower());
        //        string CargoPackType = "", InwardTransportMode = "";
        //        string qry1213 = "select CargoPackType,InwardTransportMode from dbo.inheadertbl where PermitID='" + dt.Rows[0]["PermitID"].ToString() + "'";
        //        obj.dr = obj.ret_dr(qry1213);
        //        while (obj.dr.Read())
        //        {
        //            // CPC.Add(obj.dr[0].ToString());
        //            CargoPackType = obj.dr[0].ToString();
        //            InwardTransportMode = obj.dr[1].ToString();
        //        }
        //        XElement TransportEquipment = new XElement(ns3 + "TransportEquipment", "");


        //        string ReceiptLoc = "";
        //        string qry113 = "select LocationCode,Description from dbo.ReceiptLocation where LocationCode='" + dt.Rows[0]["RecepitLocation"].ToString() + "'";
        //        obj.dr = obj.ret_dr(qry113);
        //        while (obj.dr.Read())
        //        {
        //            // CPC.Add(obj.dr[0].ToString());
        //            ReceiptLoc = obj.dr[1].ToString();
        //        }

        //        XElement ReceiptLocationName = new XElement(ns2 + "LocationName", ReceiptLoc.ToUpper());
        //        XElement ReceiptLocationCode = new XElement(ns2 + "LocationCode", dt.Rows[0]["RecepitLocation"].ToString().ToUpper());
        //        XElement ReceiptLocation = new XElement(ns3 + "ReceiptLocation", "");
        //        ReceiptLocation.Add(ReceiptLocationCode);
        //        if (!string.IsNullOrWhiteSpace(ReceiptLoc))
        //        {
        //            ReceiptLocation.Add(ReceiptLocationName);
        //        }
        //        string ReleaseLoc = "";
        //        string qry11 = "select LocationCode,Description from dbo.ReleaseLocation where LocationCode='" + dt.Rows[0]["ReleaseLocation"].ToString() + "'";
        //        obj.dr = obj.ret_dr(qry11);
        //        while (obj.dr.Read())
        //        {
        //            // CPC.Add(obj.dr[0].ToString());
        //            ReleaseLoc = obj.dr[1].ToString();
        //        }
        //        XElement LocationName = new XElement(ns2 + "LocationName", dt.Rows[0]["ReleaseLocName"].ToString ().ToUpper ());
        //        XElement LocationCode = new XElement(ns2 + "LocationCode", dt.Rows[0]["ReleaseLocation"].ToString().ToUpper ());
        //       XElement ReleaseLocation  = new XElement(ns3 + "ReleaseLocation", "");
        //        ReleaseLocation.Add(LocationCode);
        //        if (!string.IsNullOrWhiteSpace(dt.Rows[0]["ReleaseLocName"].ToString()))
        //        {
        //            ReleaseLocation.Add(LocationName);
        //        }

        //        string[] cartype = dt.Rows[0]["CargoPackType"].ToString().Split(':');
        //        string cartpefin = "";
        //        cartpefin = cartype[0].ToString();
        //        if (cartype[1].ToString() == " Other non-Containerized")
        //        {                    
        //            cartpefin= cartpefin.Remove(cartpefin.Length-1);
        //        }

        //        XElement CargoPackingType = new XElement(ns2 + "CargoPackingType", cartpefin.ToUpper());
        //        XElement Cargo = new XElement(ns5 + "Cargo");
        //        if (!string.IsNullOrWhiteSpace(dt.Rows[0]["CargoPackType"].ToString()))
        //        {
        //            Cargo.Add(CargoPackingType);
        //        }
        //        if (!string.IsNullOrWhiteSpace(dt.Rows[0]["ReleaseLocation"].ToString()))
        //        {
        //            Cargo.Add(ReleaseLocation);
        //        }
        //        if (!string.IsNullOrWhiteSpace(dt.Rows[0]["RecepitLocation"].ToString()))
        //        {
        //            Cargo.Add(ReceiptLocation);
        //        }
        //        if (CargoPackType == "9: Containerized")
        //        {

        //                string Con = "select RowNo,ContainerNo,Size,Weight,SealNo from dbo.ContainerDtl where PermitID='" + dt.Rows[0]["PermitID"].ToString() + "' ORDER BY RowNo";
        //                obj.dr = obj.ret_dr(Con);

        //                while (obj.dr.Read())
        //                {
        //                    // CPC.Add(obj.dr[0].ToString());
        //                    //CargoPackType = obj.dr[0].ToString();
        //                    //InwardTransportMode = obj.dr[1].ToString();
        //                    string[] ConType = obj.dr[2].ToString().Split(':');

        //                    XElement SealID = new XElement(ns2 + "SealID", obj.dr[4].ToString().ToUpper());
        //                    XElement TransportEquipmentSeal = new XElement(ns3 + "TransportEquipmentSeal", "");
        //                    TransportEquipmentSeal.Add(SealID);
        //                    XElement EquipmentWeightMeasureNumeric = new XElement(ns2 + "EquipmentWeightMeasureNumeric", obj.dr[3].ToString().ToUpper());
        //                    XElement SizeTypeCode = new XElement(ns2 + "SizeTypeCode", ConType[0].Substring(0, ConType[0].Length - 1).ToUpper());
        //                    XElement EquipmentID = new XElement(ns2 + "EquipmentID", obj.dr[1].ToString().ToUpper());
        //                    XElement SequenceNumeric = new XElement(ns2 + "SequenceNumeric", obj.dr[0].ToString().ToUpper());
        //                    TransportEquipment = new XElement(ns3 + "TransportEquipment", "");
        //                    TransportEquipment.Add(SequenceNumeric);
        //                    TransportEquipment.Add(EquipmentID);
        //                    TransportEquipment.Add(SizeTypeCode);
        //                    TransportEquipment.Add(EquipmentWeightMeasureNumeric);
        //                    TransportEquipment.Add(TransportEquipmentSeal);
        //                     Cargo.Add(TransportEquipment);
        //                }
        //            }
        //            else
        //            {
        //                XElement SealID = new XElement(ns2 + "SealID", "");
        //                XElement TransportEquipmentSeal = new XElement(ns3 + "TransportEquipmentSeal", "");
        //                TransportEquipmentSeal.Add(SealID);
        //                XElement EquipmentWeightMeasureNumeric = new XElement(ns2 + "EquipmentWeightMeasureNumeric", "");
        //                XElement SizeTypeCode = new XElement(ns2 + "SizeTypeCode", "");
        //                XElement EquipmentID = new XElement(ns2 + "EquipmentID", "");
        //                XElement SequenceNumeric = new XElement(ns2 + "SequenceNumeric", "");

        //                TransportEquipment.Add(SequenceNumeric);
        //                TransportEquipment.Add(EquipmentID);
        //                TransportEquipment.Add(SizeTypeCode);
        //                TransportEquipment.Add(EquipmentWeightMeasureNumeric);
        //                TransportEquipment.Add(TransportEquipmentSeal);
        //            }

        //         //   Cargo.Add(TransportEquipment);

        //        if (!string.IsNullOrWhiteSpace(dt.Rows[0]["SupplyIndicator"].ToString()))
        //        {
        //            if (dt.Rows[0]["SupplyIndicator"].ToString().ToUpper() == "True".ToUpper())
        //            {
        //                Cargo.Add(SupplyIndicator);
        //            }
        //        }
        //        if (!string.IsNullOrWhiteSpace(dt.Rows[0]["BlanketStartDate"].ToString()))
        //        {
        //            Cargo.Add(BlanketStartDate);
        //        }



        //        string[] bankercode1 = dt.Rows[0]["BGIndicator"].ToString().Split(':');
        //        XElement BankerCode = new XElement(ns2 + "BankerGuaranteeCode", bankercode1[0].Substring(0, bankercode1[0].ToString().Length - 1).ToUpper());
        //        XElement Additional = new XElement(ns2 + "AdditionalRecipientID", "");
        //        XElement Remarks = new XElement(ns3 + "Remarks", "");
        //        Remarks.Add(new XElement(ns2 + "FreeText", dt.Rows[0]["TradeRemarks"].ToString().ToUpper()));
        //        XElement DeclarationIndicator = new XElement(ns2 + "DeclarationIndicator", "true");
        //        XElement PreviousPermitNumber = new XElement(ns2 + "PreviousPermitNumber", dt.Rows[0]["PreviousPermit"].ToString().ToUpper());
        //        string[] DecType = dt.Rows[0]["DeclarationType"].ToString().Split(':');
        //        XElement DeclarationType = new XElement(ns2 + "DeclarationType", DecType[0].ToString().Substring(0, DecType[0].ToString().Length - 1).ToUpper());
        //        XElement CommonAccessReference = null;
        //        if (Update == "AMEND")
        //        {
        //            CommonAccessReference = new XElement(ns2 + "CommonAccessReference", "IPTUPD");
        //        }
        //        else
        //        {
        //            CommonAccessReference = new XElement(ns2 + "CommonAccessReference", dt.Rows[0]["MessageType"].ToString().ToUpper());
        //        }
        //        XElement DeclarantID = new XElement(ns2 + "DeclarantID", dt.Rows[0]["TradeNetMailboxID"].ToString().ToUpper());
        //        XElement MessageReference = new XElement(ns2 + "MessageReference", dt.Rows[0]["MSGId"].ToString().ToUpper());
        //        string date = "";
        //        string sequneNo = "";
        //        date = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
        //        sequneNo = dt.Rows[0]["MSGId"].ToString().Substring(dt.Rows[0]["MSGId"].ToString().Length - 4);
        //        XElement UniqueReferenceNumber = new XElement(ns3 + "UniqueReferenceNumber", "");
        //        UniqueReferenceNumber.Add(new XElement(ns2 + "ID", DecId.ToUpper()));
        //        UniqueReferenceNumber.Add(new XElement(ns2 + "Date", date.ToUpper()));
        //        UniqueReferenceNumber.Add(new XElement(ns2 + "SequenceNumeric", sequneNo.ToUpper()));
        //        XElement Header = new XElement(ns5 + "Header");
        //        if (!string.IsNullOrWhiteSpace(dt.Rows[0]["MSGId"].ToString()))
        //        {
        //            Header.Add(MessageReference);
        //        }
        //        Header.Add(UniqueReferenceNumber);
        //        Header.Add(DeclarantID);
        //        if (!string.IsNullOrWhiteSpace(dt.Rows[0]["MessageType"].ToString()))
        //        {
        //            Header.Add(CommonAccessReference);
        //        }
        //        if (!string.IsNullOrWhiteSpace(DecType[0].ToString().Substring(0, DecType[0].ToString().Length - 1)))
        //        {
        //            Header.Add(DeclarationType);
        //        }
        //        if (!string.IsNullOrWhiteSpace(dt.Rows[0]["DeclareIndicator"].ToString()))
        //        {
        //            Header.Add(DeclarationIndicator);
        //        }
        //        if (!string.IsNullOrWhiteSpace(dt.Rows[0]["PreviousPermit"].ToString()))
        //        {
        //            Header.Add(PreviousPermitNumber);
        //        }
        //        if (!string.IsNullOrWhiteSpace(dt.Rows[0]["TradeRemarks"].ToString()))
        //        {
        //            Header.Add(Remarks);
        //        }
        //        //Header.Add(Additional);
        //        if (!string.IsNullOrWhiteSpace(dt.Rows[0]["BGIndicator"].ToString()))
        //        {
        //            if (dt.Rows[0]["BGIndicator"].ToString() != "--Select--")
        //            {
        //                Header.Add(BankerCode);
        //            }
        //        }
        //        List<string> CPC = new List<string>();
        //        string qry11a = "select distinct(CPCType) from dbo.CPCDtl where PermitId='" + dt.Rows[0]["PermitID"].ToString() + "'";
        //        obj.dr = obj.ret_dr(qry11a);
        //        while (obj.dr.Read())
        //        {
        //            CPC.Add(obj.dr[0].ToString());
        //            // CPC = obj.dr[0].ToString();
        //        }
        //        string cusprc = "";
        //        XElement Customprce = null;
        //        for (int i = 0; i < CPC.Count; i++)
        //        {
        //            string Code = "";
        //            string qry111 = "select * from dbo.CPCDtl where PermitId='" + dt.Rows[0]["PermitID"].ToString() + "' and CPCType='" + CPC[i].ToString() + "'";
        //            obj.dr = obj.ret_dr(qry111);
        //            while (obj.dr.Read())
        //            {
        //                Code = obj.dr[0].ToString();

        //                //cARGO
        //                Customprce = new XElement(ns3 + "CustomsProcedureCodeInformation", "");
        //                XElement Customprce1 = null;
        //                Customprce1 = new XElement(ns3 + "CPCProcessingCode", "");
        //                if (!string.IsNullOrWhiteSpace(obj.dr["CPCType"].ToString()))
        //                {
        //                    if (!string.IsNullOrWhiteSpace(obj.dr["ProcessingCode1"].ToString()))
        //                    {
        //                        Customprce1.Add(new XElement(ns2 + "ProcessingCodeOne", obj.dr["ProcessingCode1"].ToString().ToUpper()));
        //                    }
        //                    if (!string.IsNullOrWhiteSpace(obj.dr["ProcessingCode2"].ToString()))
        //                    {
        //                        Customprce1.Add(new XElement(ns2 + "ProcessingCodeTwo", obj.dr["ProcessingCode2"].ToString().ToUpper()));
        //                    }
        //                    if (!string.IsNullOrWhiteSpace(obj.dr["ProcessingCode3"].ToString()))
        //                    {
        //                        Customprce1.Add(new XElement(ns2 + "ProcessingCodeThree", obj.dr["ProcessingCode3"].ToString().ToUpper()));
        //                    }
        //                    MyClass objcas = new MyClass();
        //                    string[] DecType1 = dt.Rows[0]["DeclarationType"].ToString().Split(':');
        //                    objcas.dr = objcas.ret_dr("select CPCCode from CPCCodeValue where PCode='" + obj.dr["CPCType"].ToString() + "' and CarRef='IPT' and DecType='" + DecType1[0].ToString().Substring(0, DecType1[0].ToString().Length - 1) + "'");
        //                    while (objcas.dr.Read())
        //                    {
        //                        Customprce.Add(new XElement(ns2 + "CustomsProcedureCode", objcas.dr["CPCCode"].ToString().ToUpper()));
        //                        cusprc = objcas.dr["CPCCode"].ToString();
        //                    }
        //                    Customprce.Add(Customprce1);
        //                    Header.Add(Customprce);
        //                }

        //            }
        //        }                
        //        //header
        //        XElement updateAmt = null;
        //        int n = 0;
        //        if (!string.IsNullOrWhiteSpace(Update))
        //        {
        //            if (Update == "AMEND")
        //            {
        //                string qry111 = "";
        //                MyClass objcan = new MyClass();
        //                if (Update == "AMEND")
        //                {
        //                    qry111 = "select * from dbo.InpaymentAmend where Permitno='" + dt.Rows[0]["PermitNumber"].ToString() + "'";
        //                    objcan.dr = objcan.ret_dr(qry111);
        //                }
        //                else
        //                {
        //                    qry111 = "select * from dbo.InpaymentCancel where Permitno='" + dt.Rows[0]["PermitNumber"].ToString() + "'";
        //                    objcan.dr = objcan.ret_dr(qry111);
        //                }
        //                while (objcan.dr.Read())
        //                {
        //                    n = n + 1;
        //                    XElement updateAmtReason = null;
        //                    XElement updateexdper = null;
        //                    XElement updatepervalexp = null;
        //                    if (Update == "AMEND")
        //                    {
        //                        updateAmtReason = new XElement(ns2 + "AmendmentReason", objcan.dr["DescriptionOfReason"].ToString().ToUpper());
        //                        //updateexdper = new XElement(ns2 + "ExtensionReason", objcan.dr["ExtendImportPeriod"].ToString().ToUpper());
        //                        updatepervalexp = new XElement(ns2 + "PermitValidityExtensionIndicator", objcan.dr["PermitExtension"].ToString().ToLower());
        //                    }
        //                    XElement updateAmtval = new XElement(ns3 + "Amendment", "");
        //                    XElement updateReppermitno = new XElement(ns2 + "ReplacementPermitNumber", objcan.dr["ReplacementPermitno"].ToString());
        //                    XElement updatepermitno = new XElement(ns2 + "UpdatePermitNumber", objcan.dr["Permitno"].ToString().ToUpper());
        //                    XElement updatereuqno = new XElement(ns2 + "UpdateRequestNumber", objcan.dr["AmendmentCount"].ToString());
        //                    XElement updateInd = new XElement(ns2 + "UpdateIndicatorCode", objcan.dr["UpdateIndicator"].ToString());
        //                    updateAmt = new XElement(ns3 + "Update", "");
        //                    if (!string.IsNullOrWhiteSpace(objcan.dr["UpdateIndicator"].ToString()))
        //                    {
        //                        updateAmt.Add(updateInd);
        //                    }
        //                    updateAmt.Add(updatereuqno);
        //                    if (!string.IsNullOrWhiteSpace(objcan.dr["Permitno"].ToString()))
        //                    {
        //                        updateAmt.Add(updatepermitno);
        //                    }
        //                    //if (!string.IsNullOrWhiteSpace(objcan.dr["ReplacementPermitno"].ToString()))
        //                    //{
        //                    //    updateAmt.Add(updateReppermitno);
        //                    //}
        //                    if (Update == "AMEND")
        //                    {
        //                        string chkval = "";
        //                        if (!string.IsNullOrWhiteSpace(objcan.dr["PermitExtension"].ToString().ToLower()))
        //                        {
        //                            if (objcan.dr["PermitExtension"].ToString().ToLower() != "false")
        //                            {
        //                                updateAmtval.Add(updatepervalexp);
        //                                chkval = "In";
        //                            }
        //                        }
        //                        //if (!string.IsNullOrWhiteSpace(objcan.dr["ExtendImportPeriod"].ToString()))
        //                        //{
        //                        //    updateAmtval.Add(updateexdper);
        //                        //    chkval = "In";
        //                        //}
        //                        if (!string.IsNullOrWhiteSpace(objcan.dr["DescriptionOfReason"].ToString()))
        //                        {
        //                            updateAmtval.Add(updateAmtReason);
        //                            chkval = "In";
        //                        }
        //                        if (!string.IsNullOrWhiteSpace(chkval))
        //                        {
        //                            updateAmt.Add(updateAmtval);
        //                        }
        //                    }
        //                }
        //            }
        //            //reportElement.Add(updateAmt);
        //        }
        //        XElement InboundMessage = new XElement(ns1 + "InboundMessage");
        //        XElement InPayment=null;
        //        XElement inpdel = new XElement(ns5 + "Declaration", "");
        //        if (!string.IsNullOrWhiteSpace(Update))
        //        {
        //            if (Update != "NEW")
        //            {
        //                InPayment = new XElement(ns5 + "InPaymentUpdate", "");
        //            }
        //            else
        //            {
        //                InPayment = new XElement(ns5 + "InPayment", "");
        //            }
        //        }
        //        else
        //        {
        //            InPayment = new XElement(ns5 + "InPayment", "");
        //        }                 
        //        //if (!string.IsNullOrWhiteSpace(Update))
        //        //{
        //        //    InPayment.Add(updateAmt);
        //        //}
        //        if (Update != "NEW")
        //        {
        //            inpdel.Add(Header);
        //            inpdel.Add(Cargo);
        //            if (dt.Rows[0]["InwardTransportMode"].ToString() != "--Select--")
        //            {
        //                if (mdecde[0].Substring(0, mdecde[0].Length - 1).ToString() != "N")
        //                {
        //                    inpdel.Add(Transport);
        //                }
        //            }
        //            inpdel.Add(Party);
        //            inpdel.Add(InvoiceName);
        //        }
        //        else
        //        {
        //            InPayment.Add(Header);
        //            InPayment.Add(Cargo);
        //            if (dt.Rows[0]["InwardTransportMode"].ToString() != "--Select--")
        //            {
        //                if (mdecde[0].Substring(0, mdecde[0].Length - 1).ToString() != "N")
        //                {
        //                    InPayment.Add(Transport);
        //                }
        //            }
        //            InPayment.Add(Party);
        //            InPayment.Add(InvoiceName);
        //        }
        //        //InPayment.Add(Item);
        //        string ItemQury = "select * from dbo.itemDtl where PermitId='" + dt.Rows[0]["PermitId"].ToString() + "' order by ItemNo";
        //        obj.dr = obj.ret_dr(ItemQury);
        //        if (obj.dr.HasRows)
        //        {
        //            while (obj.dr.Read())
        //            {
        //                XElement OtherDutyAmount = new XElement(ns2 + "DutyAmount", obj.dr["OtherTaxAmount"].ToString().ToUpper());
        //                XElement OtherDutyRateUnit = new XElement(ns2 + "DutyRateUnit", obj.dr["OtherTaxUOM"].ToString().ToUpper());
        //                XElement OtherDutyRate = new XElement(ns2 + "DutyRate", obj.dr["OtherTaxRate"].ToString().ToUpper());
        //                XElement OtherTax = new XElement(ns3 + "OtherTax", "");
        //                OtherTax.Add(OtherDutyRate);
        //                OtherTax.Add(OtherDutyRateUnit);
        //                OtherTax.Add(OtherDutyAmount);
        //                XElement CustomDutyAmount = new XElement(ns2 + "DutyAmount", obj.dr["CustomsDutyAmount"].ToString().ToUpper());
        //                XElement CustomDutyRateUnit = new XElement(ns2 + "DutyRateUnit", obj.dr["CustomsDutyUOM"].ToString().ToUpper());
        //                XElement CustomDutyRate = new XElement(ns2 + "DutyRate", obj.dr["CustomsDutyRate"].ToString().ToUpper());
        //                XElement CustomsDuty = new XElement(ns3 + "CustomsDuty", "");
        //                if (!string.IsNullOrWhiteSpace(obj.dr["CustomsDutyRate"].ToString()))
        //                {
        //                    if (Convert.ToDecimal(obj.dr["CustomsDutyRate"].ToString()) > 0)
        //                    {
        //                        CustomsDuty.Add(CustomDutyRate);
        //                        CustomsDuty.Add(CustomDutyRateUnit);
        //                        CustomsDuty.Add(CustomDutyAmount);
        //                    }

        //                }
        //                XElement DutyAmount = new XElement(ns2 + "DutyAmount", obj.dr["ExciseDutyAmount"].ToString().ToUpper());
        //                XElement DutyRateUnit = new XElement(ns2 + "DutyRateUnit", obj.dr["ExciseDutyUOM"].ToString().ToUpper());
        //                XElement DutyRate = new XElement(ns2 + "DutyRate", obj.dr["ExciseDutyRate"].ToString().ToUpper());
        //                XElement ExciseDuty = new XElement(ns3 + "ExciseDuty", "");
        //                if (!string.IsNullOrWhiteSpace(obj.dr["ExciseDutyRate"].ToString()))
        //                {
        //                    if (Convert.ToDecimal(obj.dr["ExciseDutyRate"].ToString()) > 0)
        //                    {
        //                        ExciseDuty.Add(DutyRate);
        //                        ExciseDuty.Add(DutyRateUnit);
        //                        ExciseDuty.Add(DutyAmount);
        //                    }
        //                }

        //                XElement GoodsAndServicesTaxAmount = new XElement(ns2 + "GoodsAndServicesTaxAmount", obj.dr["GSTAmount"].ToString().ToUpper());
        //                string GSTPER = Math.Round(Convert.ToDecimal(obj.dr["GSTRate"].ToString()), 0).ToString();
        //                XElement GoodsAndServicesTaxPercent = new XElement(ns2 + "GoodsAndServicesTaxPercent", GSTPER.ToUpper());
        //                XElement GoodsAndServicesTax = new XElement(ns3 + "GoodsAndServicesTax", "");
        //                if (Convert.ToDecimal(obj.dr["GSTRate"].ToString()) > 0)
        //                {
        //                    GoodsAndServicesTax.Add(GoodsAndServicesTaxPercent);
        //                }
        //                if (Convert.ToDecimal(obj.dr["GSTAmount"].ToString()) > 0)
        //                {
        //                    GoodsAndServicesTax.Add(GoodsAndServicesTaxAmount);
        //                }
        //                string[] percode = obj.dr["PreferentialCode"].ToString().Split(':');
        //                XElement PreferentialCode = new XElement(ns2 + "PreferentialCode", percode[0].ToString().Substring(0, percode[0].Length - 1).ToUpper());
        //                XElement Tariff = new XElement(ns3 + "Tariff", "");
        //                if (!string.IsNullOrWhiteSpace(percode[0].ToString().Substring(0, percode[0].Length - 1)))
        //                {
        //                    if (obj.dr["PreferentialCode"].ToString() != "--Select--")
        //                    {
        //                        Tariff.Add(PreferentialCode);
        //                    }
        //                }
        //                if (Convert.ToDecimal(obj.dr["GSTRate"].ToString()) > 0 || Convert.ToDecimal(obj.dr["GSTAmount"].ToString()) > 0)
        //                {
        //                    Tariff.Add(GoodsAndServicesTax);
        //                }
        //                if (!string.IsNullOrWhiteSpace(obj.dr["ExciseDutyUOM"].ToString()))
        //                {
        //                    if (obj.dr["ExciseDutyUOM"].ToString() != "--Select--")
        //                    {
        //                        if (Convert.ToDecimal(obj.dr["ExciseDutyRate"].ToString()) > 0)
        //                        {
        //                            Tariff.Add(ExciseDuty);
        //                        }
        //                    }
        //                }
        //                if (!string.IsNullOrWhiteSpace(obj.dr["CustomsDutyUOM"].ToString()))
        //                {
        //                    if (obj.dr["CustomsDutyUOM"].ToString() != "--Select--")
        //                    {
        //                        if (Convert.ToDecimal(obj.dr["CustomsDutyRate"].ToString()) > 0)
        //                        {
        //                            Tariff.Add(CustomsDuty);
        //                        }

        //                    }
        //                }
        //                if (!string.IsNullOrWhiteSpace(obj.dr["OtherTaxUOM"].ToString()))
        //                {
        //                    if (obj.dr["OtherTaxUOM"].ToString() != "--Select--")
        //                    {

        //                        Tariff.Add(OtherTax);

        //                    }
        //                }
        //                XElement OriginalRegistrationDate = null;
        //                if (!string.IsNullOrWhiteSpace(obj.dr["orignaldatereg"].ToString()))
        //                {
        //                    OriginalRegistrationDate = new XElement(ns2 + "OriginalRegistrationDate", Convert.ToDateTime(obj.dr["orignaldatereg"].ToString()).ToString("yyyyMMdd"));
        //                }
        //                XElement EngineCapacity = new XElement(ns2 + "EngineCapacity", obj.dr["EngineCapcity"].ToString());
        //                string[] enginecap = obj.dr["EngineCapUOM"].ToString().Split(':');
        //                EngineCapacity.Add(new XAttribute("unitCode", enginecap[0].ToString().ToUpper()));
        //                XElement MotorVehicle = new XElement(ns3 + "MotorVehicle", "");
        //                if (!string.IsNullOrWhiteSpace(obj.dr["EngineCapcity"].ToString()))
        //                {                           
        //                      MotorVehicle.Add(EngineCapacity);                           
        //                }
        //                if (!string.IsNullOrWhiteSpace(obj.dr["orignaldatereg"].ToString()))
        //                {
        //                    MotorVehicle.Add(OriginalRegistrationDate);
        //                }
        //                XElement ItemInvoiceNumber = new XElement(ns2 + "ItemInvoiceNumber", obj.dr["InvoiceNo"].ToString().ToUpper());
        //                XElement InHAWBHUCRHBLNumber = new XElement(ns2 + "InHAWBHUCRHBLNumber", obj.dr["InHAWBOBL"].ToString().ToUpper());
        //                string making = null;


        //                string[] strhw = obj.dr["Making"].ToString().Split(':');

        //                XElement Marking = new XElement(ns2 + "Marking", strhw[0].ToString().Substring(0, strhw[0].Length - 1).ToUpper());

        //                XElement PreviousLotNumber = new XElement(ns2 + "PreviousLotNumber", obj.dr["PreviousLot"].ToString().ToUpper());
        //                XElement CurrentLotNumber = new XElement(ns2 + "CurrentLotNumber", obj.dr["CurrentLot"].ToString().ToUpper());
        //                XElement LotIdentification = new XElement(ns3 + "LotIdentification", "");
        //                if (!string.IsNullOrWhiteSpace(obj.dr["CurrentLot"].ToString()))
        //                {
        //                    making = obj.dr["CurrentLot"].ToString();
        //                    LotIdentification.Add(CurrentLotNumber);
        //                }
        //                if (!string.IsNullOrWhiteSpace(obj.dr["PreviousLot"].ToString()))
        //                {
        //                    making = obj.dr["PreviousLot"].ToString();

        //                    LotIdentification.Add(PreviousLotNumber);
        //                }
        //                if (!string.IsNullOrWhiteSpace(strhw[0].ToString().Substring(0, strhw[0].Length - 1)))
        //                {
        //                    if (obj.dr["Making"].ToString() != "--Select--")
        //                    {
        //                        making = strhw[0].ToString().Substring(0, strhw[0].Length - 1);
        //                    }
        //                    LotIdentification.Add(Marking);
        //                }
        //                XElement ShippingMarks = new XElement(ns2 + "ShippingMarks", "");
        //                XElement ShippingMarksInformation = new XElement(ns3 + "ShippingMarksInformation", "");
        //                //ShippingMarksInformation.Add(ShippingMarks);
        //                XElement InmostPackQuantity = new XElement(ns2 + "InmostPackQuantity", Math.Round(Convert.ToDecimal(obj.dr["ImPQty"].ToString()), 0));
        //                InmostPackQuantity.Add(new XAttribute("unitCode", obj.dr["ImPUOM"].ToString()));
        //                XElement InnerPackQuantity = new XElement(ns2 + "InnerPackQuantity", Math.Round(Convert.ToDecimal(obj.dr["InPqty"].ToString()), 0));
        //                InnerPackQuantity.Add(new XAttribute("unitCode", obj.dr["InPUOM"].ToString()));
        //                XElement InPackQuantity = new XElement(ns2 + "InPackQuantity", Math.Round(Convert.ToDecimal(obj.dr["IPQty"].ToString()), 0));
        //                InPackQuantity.Add(new XAttribute("unitCode", obj.dr["IPUOM"].ToString()));
        //                XElement OuterPackQuantity = new XElement(ns2 + "OuterPackQuantity", Math.Round(Convert.ToDecimal(obj.dr["OPQty"].ToString()), 0));
        //                OuterPackQuantity.Add(new XAttribute("unitCode", obj.dr["OPUOM"].ToString()));
        //                XElement PackingDescription = new XElement(ns3 + "PackingDescription", "");
        //                if (!string.IsNullOrWhiteSpace(obj.dr["OPUOM"].ToString()))
        //                {
        //                    if (obj.dr["OPUOM"].ToString() != "--Select--")
        //                    {
        //                        PackingDescription.Add(OuterPackQuantity);
        //                    }
        //                }
        //                if (!string.IsNullOrWhiteSpace(obj.dr["IPUOM"].ToString()))
        //                {
        //                    if (obj.dr["IPUOM"].ToString() != "--Select--")
        //                    {
        //                        PackingDescription.Add(InPackQuantity);
        //                    }
        //                }
        //                if (!string.IsNullOrWhiteSpace(obj.dr["InPUOM"].ToString()))
        //                {
        //                    if (obj.dr["InPUOM"].ToString() != "--Select--")
        //                    {
        //                        PackingDescription.Add(InnerPackQuantity);
        //                    }
        //                }
        //                if (!string.IsNullOrWhiteSpace(obj.dr["ImPUOM"].ToString()))
        //                {
        //                    if (obj.dr["ImPUOM"].ToString() != "--Select--")
        //                    {
        //                        PackingDescription.Add(InmostPackQuantity);
        //                    }
        //                }
        //                XElement DangerousGoodsIndicator = new XElement(ns2 + "DangerousGoodsIndicator", obj.dr["DGIndicator"].ToString().ToLower());
        //                XElement ModelDescription = new XElement(ns2 + "ModelDescription", obj.dr["Model"].ToString().ToUpper ());
        //                XElement BrandName = new XElement(ns2 + "BrandName", obj.dr["Brand"].ToString().ToUpper());
        //                XElement AdditionalCASCIdentification = new XElement(ns3 + "AdditionalCASCIdentification", "");
        //                string CascQury = "select * from dbo.CASCDtl where PermitId='" + obj.dr["PermitId"].ToString() + "' and ItemNo='"+ obj.dr["ItemNo"].ToString()+"'";
        //                string CascQuryName = "", CascQuryid = "", CascPdrt = "";
        //                List<string> cascde1 = new List<string>();
        //                List<string> cascde2 = new List<string>();
        //                List<string> cascde3 = new List<string>();
        //                cascde1.Add("");
        //                cascde2.Add("");
        //                cascde3.Add("");
        //                MyClass obj2 = new MyClass();
        //                obj2.dr = obj2.ret_dr(CascQury);
        //                if (obj2.dr.HasRows)
        //                {
        //                    while (obj2.dr.Read())
        //                    {
        //                        CascQuryName = obj2.dr["Quantity"].ToString();
        //                        CascQuryid = obj2.dr["ProductUOM"].ToString();
        //                        CascPdrt = obj2.dr["ProductCode"].ToString();
        //                        XElement CASCCodeThree = new XElement(ns2 + "CASCCodeThree", obj2.dr["CascCode3"].ToString().ToUpper());
        //                        XElement CASCCodeTwo = new XElement(ns2 + "CASCCodeTwo", obj2.dr["CascCode2"].ToString().ToUpper());
        //                        XElement CASCCodeOne = new XElement(ns2 + "CASCCodeOne", obj2.dr["CascCode1"].ToString().ToUpper());
        //                        if (!string.IsNullOrEmpty(obj2.dr["CascCode1"].ToString()))
        //                        {
        //                            cascde1.Remove("");
        //                            cascde1.Add(obj2.dr["CascCode1"].ToString());
        //                            AdditionalCASCIdentification.Add(CASCCodeOne);
        //                        }
        //                        if (!string.IsNullOrEmpty(obj2.dr["CascCode2"].ToString()))
        //                        {
        //                            cascde2.Remove("");
        //                            cascde2.Add(obj2.dr["CascCode2"].ToString());
        //                            AdditionalCASCIdentification.Add(CASCCodeTwo);
        //                        }
        //                        if (!string.IsNullOrEmpty(obj2.dr["CascCode3"].ToString()))
        //                        {
        //                            cascde2.Remove("");
        //                            cascde2.Add(obj2.dr["CascCode3"].ToString());
        //                            AdditionalCASCIdentification.Add(CASCCodeThree);
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    //CascQuryName = obj.dr["Quantity"].ToString();
        //                    //CascQuryid = obj.dr["ProductUOM"].ToString();
        //                    //XElement CASCCodeThree = new XElement(ns2 + "CASCCodeThree", "");
        //                    //XElement CASCCodeTwo = new XElement(ns2 + "CASCCodeTwo", "");
        //                    //XElement CASCCodeOne = new XElement(ns2 + "CASCCodeOne", "");

        //                    //AdditionalCASCIdentification.Add(CASCCodeOne);
        //                    //AdditionalCASCIdentification.Add(CASCCodeTwo);
        //                    //AdditionalCASCIdentification.Add(CASCCodeThree);
        //                }
        //                XElement CASCProductQuantity = new XElement(ns2 + "CASCProductQuantity", CascQuryName);
        //                CASCProductQuantity.Add(new XAttribute("unitCode", CascQuryid));
        //                XElement CASCProductCode = new XElement(ns2 + "CASCProductCode", CascPdrt.ToUpper ());
        //                XElement CASCProduct = new XElement(ns3 + "CASCProduct", "");
        //                if (!string.IsNullOrWhiteSpace(CascPdrt))
        //                {
        //                    CASCProduct.Add(CASCProductCode);
        //                    if (Convert.ToDecimal(CascQuryName) > 0)
        //                    {
        //                        CASCProduct.Add(CASCProductQuantity);
        //                    }
        //                    if (!string.IsNullOrWhiteSpace(cascde1[0].ToString()) || !string.IsNullOrWhiteSpace(cascde2[0].ToString()) || !string.IsNullOrWhiteSpace(cascde3[0].ToString()))
        //                    {
        //                        CASCProduct.Add(AdditionalCASCIdentification);
        //                    }                            
        //                }
        //                XElement ItemExchangeRate1 = new XElement(ns2 + "ExchangeRate", "0.00");
        //                XElement ItemAmount1 = new XElement(ns2 + "Amount", "0.00");
        //                ItemAmount1.Add(new XAttribute("currencyID", ""));
        //                XElement OptionalItemCharge = new XElement(ns3 + "OptionalItemCharge", "");
        //                OptionalItemCharge.Add(ItemAmount1);
        //                OptionalItemCharge.Add(ItemExchangeRate1);
        //                XElement ItemExchangeRate = new XElement(ns2 + "ExchangeRate", obj.dr["ExchangeRate"].ToString());
        //                XElement ItemAmount = new XElement(ns2 + "Amount", obj.dr["TotalLineAmount"].ToString());
        //                ItemAmount.Add(new XAttribute("currencyID", obj.dr["UnitPriceCurrency"].ToString()));
        //                XElement UnitPriceValue = new XElement(ns3 + "UnitPriceValue", "");
        //                UnitPriceValue.Add(ItemAmount);
        //                UnitPriceValue.Add(ItemExchangeRate);
        //                XElement LastSellingPriceValue = new XElement(ns2 + "LastSellingPriceValue", obj.dr["LSPValue"].ToString());
        //                XElement ItemCIFFOBValue = new XElement(ns2 + "ItemCIFFOBValue", obj.dr["CIFFOB"].ToString());
        //                XElement TransactionValue = new XElement(ns3 + "TransactionValue", "");
        //                if (Convert.ToDecimal(obj.dr["CIFFOB"].ToString()) > 0)
        //                {
        //                    TransactionValue.Add(ItemCIFFOBValue);
        //                }
        //                if (Convert.ToDecimal(obj.dr["LSPValue"].ToString()) > 0)
        //                {
        //                    TransactionValue.Add(LastSellingPriceValue);
        //                }
        //                if (dt.Rows[0]["DeclarationType"].ToString() != "DNG : Duty & GST" && dt.Rows[0]["DeclarationType"].ToString() != "DUT : Duty")
        //                {
        //                    if (!string.IsNullOrWhiteSpace(obj.dr["UnitPriceCurrency"].ToString()))
        //                    {
        //                        if (obj.dr["UnitPriceCurrency"].ToString() != "--Select--")
        //                        {
        //                            string hsval1 = "";
        //                            string hscvalue = obj.dr["HSCode"].ToString();
        //                            hsval1 = hscvalue.Substring(0, 6);
        //                            hscvalue = hscvalue.Substring(0, 3);
        //                            if (hscvalue == "220")
        //                            {

        //                            }
        //                            else if (hscvalue == "270")
        //                            {

        //                            }
        //                            else if (hscvalue == "271")
        //                            {

        //                            }
        //                            else if (hscvalue == "240")
        //                            {

        //                            }
        //                            else if (hscvalue == "330")
        //                            {

        //                            }
        //                            else
        //                            {
        //                                if (hsval1 != "210690")
        //                                {
        //                                    if (hsval1 != "38260090")
        //                                    {
        //                                        TransactionValue.Add(UnitPriceValue);
        //                                    }
        //                                }

        //                            }
        //                        }
        //                    }
        //                }
        //                //TransactionValue.Add(OptionalItemCharge);
        //                string[] corgin = obj.dr["Contry"].ToString().Split(':');
        //                string cuntry = corgin[0].ToString().Substring(0, corgin[0].Length - 1);
        //                XElement OriginCountry = new XElement(ns2 + "OriginCountry", corgin[0].ToString());
        //                XElement AlcoholPercent = new XElement(ns2 + "AlcoholPercent", obj.dr["AlcoholPer"].ToString());
        //                XElement DutiableQuantity = new XElement(ns2 + "DutiableQuantity", obj.dr["DutiableQty"].ToString());
        //                DutiableQuantity.Add(new XAttribute("unitCode", obj.dr["DutiableUOM"].ToString()));
        //                XElement TotalDutiableQuantity = new XElement(ns2 + "TotalDutiableQuantity", obj.dr["TotalDutiableQty"].ToString());
        //                TotalDutiableQuantity.Add(new XAttribute("unitCode", obj.dr["TotalDutiableUOM"].ToString()));
        //                XElement HarmonizedSystemQuantity = new XElement(ns2 + "HarmonizedSystemQuantity", obj.dr["HSQty"].ToString());
        //                HarmonizedSystemQuantity.Add(new XAttribute("unitCode", obj.dr["HSUOM"].ToString()));
        //                XElement ItemQuantity = new XElement(ns3 + "ItemQuantity", "");
        //                if (!string.IsNullOrWhiteSpace(obj.dr["HSQty"].ToString()))
        //                {
        //                    if (Convert.ToDecimal(obj.dr["HSQty"].ToString()) > 0)
        //                    {
        //                        ItemQuantity.Add(HarmonizedSystemQuantity);
        //                    }
        //                }
        //                if (!string.IsNullOrWhiteSpace(obj.dr["TotalDutiableQty"].ToString()))
        //                {
        //                    if (Convert.ToDecimal(obj.dr["TotalDutiableQty"].ToString()) > 0)
        //                    {
        //                        ItemQuantity.Add(TotalDutiableQuantity);
        //                    }
        //                }
        //                if (!string.IsNullOrWhiteSpace(obj.dr["DutiableQty"].ToString()))
        //                {
        //                    if (Convert.ToDecimal(obj.dr["DutiableQty"].ToString()) > 0)
        //                    {
        //                        ItemQuantity.Add(DutiableQuantity);
        //                    }
        //                }
        //                if (!string.IsNullOrWhiteSpace(obj.dr["AlcoholPer"].ToString()))
        //                {
        //                    if (Convert.ToDecimal(obj.dr["AlcoholPer"].ToString()) > 0)
        //                    {
        //                        ItemQuantity.Add(AlcoholPercent);
        //                    }
        //                }
        //                XElement GoodsDescription = new XElement(ns2 + "GoodsDescription", obj.dr["Description"].ToString().ToUpper().ToUpper());
        //                XElement ItemHarmonizedSystemCode = new XElement(ns2 + "ItemHarmonizedSystemCode", obj.dr["HSCode"].ToString().ToUpper());
        //                XElement ItemSequenceNumeric = new XElement(ns2 + "ItemSequenceNumeric", obj.dr["ItemNo"].ToString().ToUpper());
        //                Item = new XElement(ns5 + "Item");
        //                if (!string.IsNullOrWhiteSpace(obj.dr["ItemNo"].ToString()))
        //                {
        //                    Item.Add(ItemSequenceNumeric);
        //                }
        //                if (!string.IsNullOrWhiteSpace(obj.dr["HSCode"].ToString()))
        //                {
        //                    Item.Add(ItemHarmonizedSystemCode);
        //                }
        //                if (!string.IsNullOrWhiteSpace(obj.dr["Description"].ToString()))
        //                {
        //                    Item.Add(GoodsDescription);
        //                }
        //                if (!string.IsNullOrWhiteSpace(obj.dr["HSQty"].ToString()))
        //                {
        //                    Item.Add(ItemQuantity);
        //                }
        //                if (!string.IsNullOrWhiteSpace(corgin[0].ToString()))
        //                {
        //                    Item.Add(OriginCountry);
        //                }
        //                if (!string.IsNullOrWhiteSpace(obj.dr["UnitPriceCurrency"].ToString()))
        //                {
        //                    if (obj.dr["UnitPriceCurrency"].ToString() != "--Select--")
        //                    {
        //                        Item.Add(TransactionValue);
        //                    }
        //                }
        //                if (!string.IsNullOrWhiteSpace(CascPdrt))
        //                {
        //                    Item.Add(CASCProduct);
        //                }
        //                if (!string.IsNullOrWhiteSpace(obj.dr["Brand"].ToString()))
        //                {
        //                    Item.Add(BrandName);
        //                }
        //                if (!string.IsNullOrWhiteSpace(obj.dr["Model"].ToString()))
        //                {
        //                    Item.Add(ModelDescription);
        //                }
        //                if (!string.IsNullOrWhiteSpace(obj.dr["DGIndicator"].ToString()))
        //                {
        //                    Item.Add(DangerousGoodsIndicator);
        //                }
        //                if (!string.IsNullOrWhiteSpace(obj.dr["OPUOM"].ToString()) || !string.IsNullOrWhiteSpace(obj.dr["IPUOM"].ToString()) || !string.IsNullOrWhiteSpace(obj.dr["InPUOM"].ToString()) || !string.IsNullOrWhiteSpace(obj.dr["ImPUOM"].ToString()))
        //                {
        //                    string oucur = "", incur = "", inpaccur = "", imcur = "";
        //                    oucur = obj.dr["OPUOM"].ToString();
        //                    incur = obj.dr["IPUOM"].ToString();
        //                    inpaccur = obj.dr["InPUOM"].ToString();
        //                    imcur = obj.dr["ImPUOM"].ToString();
        //                    if (oucur != "--Select--" || incur != "--Select--" || inpaccur != "--Select--" || imcur != "--Select--")
        //                    {
        //                        Item.Add(PackingDescription);
        //                    }
        //                }
        //                //Item.Add(ShippingMarksInformation);
        //                if (!string.IsNullOrWhiteSpace(making))
        //                {
        //                    Item.Add(LotIdentification);
        //                }
        //                if (!string.IsNullOrWhiteSpace(obj.dr["InHAWBOBL"].ToString()))
        //                {
        //                    Item.Add(InHAWBHUCRHBLNumber);
        //                }
        //                if (!string.IsNullOrWhiteSpace(obj.dr["InvoiceNo"].ToString()))
        //                {
        //                    if (obj.dr["InvoiceNo"].ToString() != "--Select--")
        //                    {
        //                        Item.Add(ItemInvoiceNumber);
        //                    }
        //                }
        //                if (!string.IsNullOrWhiteSpace(obj.dr["EngineCapcity"].ToString()))
        //                {
        //                    if (obj.dr["EngineCapcity"].ToString() != "--Select--")
        //                    {
        //                        Item.Add(MotorVehicle);
        //                    }
        //                }
        //                Item.Add(Tariff);
        //                if (Update != "NEW")
        //                {
        //                    inpdel.Add(Item);
        //                }
        //                else
        //                {
        //                    InPayment.Add(Item);
        //                }                        
        //            }
        //        }
        //        if (Update != "NEW")
        //        {
        //            inpdel.Add(Summary);
        //        }
        //        else
        //        {
        //            InPayment.Add(Summary);
        //        }
        //        if (Update != "NEW")
        //        {
        //            InPayment.Add(updateAmt);
        //            InPayment.Add(inpdel);
        //        }                
        //        InboundMessage.Add(InPayment);
        //        //XElement InPayment = new XElement(ns5 + "Inpayment", "");
        //        reportElement.Add(new XElement(ns2 + "MessageVersion", "041"));
        //        reportElement.Add(new XElement(ns2 + "SenderID", dt.Rows[0]["TradeNetMailboxID"].ToString().ToUpper()));
        //        reportElement.Add(new XElement(ns2 + "RecipientID", "DCST.DCST401"));
        //        reportElement.Add(new XElement(ns2 + "TotalNumberOfDeclaration", "1"));
        //        reportElement.Add(InboundMessage);
        //        //reportElement.Add(new XElement(ns5 + "InPayment", Header, Cargo, Transport, Party, Item, Summary));
        //        //reportElement.Add(new XElement(ns5 + "InboundMessage", "InPayment"));

        //        doc.WriteTo(xw);
        //    }
        //    // Response.Write(sb.ToString());


        //    //var folder = Server.MapPath("KaizenXML");
        //    var folder = @"C:\Users\Public\KaizenXML";
        //    if (!Directory.Exists(folder))
        //    {
        //        Directory.CreateDirectory(folder);
        //    }

        //    //string path = @"D:\Kaizen\IPTDEC.xml";
        //    //string path = Server.MapPath("KaizenXML");
        //    string path = @"C:\Users\Public\KaizenXML";          


        //     //foreach (GridViewRow gvrow in GridInPayment.Rows)
        //     //{
        //     //    CheckBox chk = (CheckBox)gvrow.FindControl("CheckBox1");
        //     //    if (chk != null & chk.Checked)
        //     //    {
        //     //        Label labelProductID = (Label)gvrow.FindControl("lblPermitNo");
        //     //        permitid = labelProductID.Text;
        //     //    }
        //     //}
        //     string MsgId = MSGNUMBER;
        //    string filename = path + "\\IPTDEC" + MsgId + ".xml";
        //    // Create a file to write to.
        //    if (!File.Exists(filename))
        //    {
        //        //File.Delete(filename);
        //        using (StreamWriter sw = File.CreateText(filename))
        //        {
        //            sw.WriteLine(sb.ToString());
        //            string Name = "IPTDEC" + MsgId + ".xml";
        //            string strins = "";
        //            strins = "Insert Into XmlTbl values('" + path + "','" + Name + "','')";
        //            obj.exec(strins);

        //            strins = "Insert Into DownXmlTbl values('" + path + "','" + Name + "','')";
        //            obj.exec(strins);

        //            obj.closecon();
        //        }
        //    }

        //}
        private void LoadIptDecCancel(string permitid)
        {
            string tradeID = "";
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from InHeaderTbl  where PermitId='" + permitid + "'"))
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
                objd.dr = objd.ret_dr("select * from InpaymentCancel where Permitno='" + dt.Rows[0]["PermitNumber"].ToString() + "'");
                if (objd.dr.HasRows)
                {
                    while (objd.dr.Read())
                    {
                        percode = objd.dr["ResonForCancel"].ToString().Split(':');
                    }
                }
                XElement canreason = new XElement(ns2 + "CancellationReasonCode", percode[0].ToString().Substring(0, percode[0].Length - 1).ToUpper());
                XElement DeclarationIndicator = new XElement(ns2 + "DeclarationIndicator", "true");
                XElement CommonAccessReference = new XElement(ns2 + "CommonAccessReference", "IPTUPD");
                XElement DeclarantID = new XElement(ns2 + "DeclarantID", dt.Rows[0]["TradeNetMailboxID"].ToString().ToUpper());
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
                string infilname = "select * from InFile where InPaymentId='" + dt.Rows[0]["PermitId"].ToString() + "'";
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
                    if (Update == "AMEND")
                    {
                        qry111 = "select * from dbo.InpaymentAmend where Permitno='" + dt.Rows[0]["PermitNumber"].ToString() + "'";
                        objcan.dr = objcan.ret_dr(qry111);
                    }
                    else
                    {
                        qry111 = "select * from dbo.InpaymentCancel where Permitno='" + dt.Rows[0]["PermitNumber"].ToString() + "'";
                        objcan.dr = objcan.ret_dr(qry111);
                    }
                    while (objcan.dr.Read())
                    {
                        n = 1;
                        XElement updateAmtReason = null;
                        XElement updateexdper = null;
                        XElement updatepervalexp = null;
                        //if (Update == "AMEND")
                        //{
                        //    updateAmtReason = new XElement(ns2 + "AmendmentReason", objcan.dr["DescriptionOfReason"].ToString().ToUpper());
                        //    updateexdper = new XElement(ns2 + "ExtensionReason", objcan.dr["ExtendImportPeriod"].ToString().ToUpper());
                        //    updatepervalexp = new XElement(ns2 + "PermitValidityExtensionIndicator", objcan.dr["PermitExtension"].ToString().ToLower());
                        //}
                        XElement updateAmtval = new XElement(ns3 + "Amendment", "");
                        XElement updateReppermitno = new XElement(ns2 + "ReplacementPermitNumber", objcan.dr["ReplacementPermitno"].ToString().ToUpper());
                        XElement updatepermitno = new XElement(ns2 + "UpdatePermitNumber", objcan.dr["Permitno"].ToString().ToUpper());
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

                        string chkval = "";
                        //if (!string.IsNullOrWhiteSpace(objcan.dr["PermitExtension"].ToString().ToLower()))
                        //{
                        //    updateAmtval.Add(updatepervalexp);
                        //    chkval = "IN";
                        //}
                        //if (!string.IsNullOrWhiteSpace(objcan.dr["ExtendImportPeriod"].ToString()))
                        //{
                        //    updateAmtval.Add(updateexdper);
                        //    chkval = "IN";
                        //}
                        //if (!string.IsNullOrWhiteSpace(objcan.dr["DescriptionOfReason"].ToString()))
                        //{
                        //    updateAmtval.Add(updateAmtReason);
                        //    chkval = "IN";
                        //}
                        //if (!string.IsNullOrWhiteSpace(chkval))
                        //{
                        //    updateAmt.Add(updateAmtval);
                        //}                       
                    }
                    //reportElement.Add(updateAmt);
                }

                XElement InboundMessage = new XElement(ns1 + "InboundMessage");
                XElement InPayment = new XElement(ns5 + "InPaymentUpdate", "");
                if (!string.IsNullOrWhiteSpace(Update))
                {
                    InPayment.Add(updateAmt);
                }
                InPayment.Add(cancelupd);
                InboundMessage.Add(InPayment);
                //XElement InPayment = new XElement(ns5 + "Inpayment", "");
                reportElement.Add(new XElement(ns2 + "MessageVersion", "041"));
                reportElement.Add(new XElement(ns2 + "SenderID", dt.Rows[0]["TradeNetMailboxID"].ToString().ToUpper()));
                //reportElement.Add(new XElement(ns2 + "RecipientID", "DCST.DCST401"));
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

            var folder = @"D:\MHAccess\workingdir\KaizenOUT\" + tradeID;
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }


            //string path = @"D:\Kaizen\IPTDEC.xml";
            string path = @"D:\MHAccess\workingdir\KaizenOUT\" + tradeID;
            string MsgId = MSGNUMBER;
            string filename = path + "\\IPTDEC" + MsgId + ".xml";
            // Create a file to write to.
            if (!File.Exists(filename))
            {
                //File.Delete(filename);
                using (StreamWriter sw = File.CreateText(filename))
                {
                    sw.WriteLine(sb.ToString());
                    string Name = "IPTDEC" + MsgId + ".xml";
                    string strins = "";
                    strins = "Insert Into XmlTbl values('" + path + "','" + Name + "','','" + tradeID.ToLower() + "')";
                    obj.exec(strins);

                    strins = "Insert Into DownXmlTbl values('" + path + "','" + Name + "','','" + tradeID.ToLower() + "')";
                    obj.exec(strins);

                    obj.closecon();
                }
            }
        }
        private void LoadIptDecRefund(string permitid)
        {
            string tradeID = "";
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from InHeaderTbl  where PermitId='" + permitid + "'"))
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
                string type = "";
                MyClass objcan = new MyClass();
                string qry111p = "select * from dbo.InpaymentRefund where Msgid='" + dt.Rows[0]["MSGId"].ToString() + "'";
                objcan.dr = objcan.ret_dr(qry111p);
                while (objcan.dr.Read())
                {
                    string[] reasoncode = objcan.dr["TypeOfRefund"].ToString().Split(':'); ;
                    type = reasoncode[0].Substring(0, reasoncode[0].Length - 1);
                }

                XElement taotaltrif = null;
                XElement summary = new XElement(ns3 + "RefundSummary", "");
                decimal gstAmt = 0, excieamt = 0, cusamt = 0, othertaxAmt = 0;
                if (type != "PRS")
                {
                    string infilname = "select * from refundvalsummary where PermitId='" + dt.Rows[0]["PermitNumber"].ToString() + "'";
                    obj.dr = obj.ret_dr(infilname);
                    while (obj.dr.Read())
                    {
                        gstAmt = Convert.ToDecimal(obj.dr["totalgstAmt"].ToString());
                        excieamt = Convert.ToDecimal(obj.dr["totalexciseAmt"].ToString());
                        cusamt = Convert.ToDecimal(obj.dr["txtcusdutyAmt"].ToString());
                        othertaxAmt = Convert.ToDecimal(obj.dr["txtotherAmt"].ToString());
                    }
                    XElement tottrifOtheramt = new XElement(ns2 + "TotalOtherTaxRefundAmount", othertaxAmt);
                    XElement tottrifCustomsamt = new XElement(ns2 + "TotalCustomsDutyRefundAmount", cusamt);
                    XElement tottrifExiceamt = new XElement(ns2 + "TotalExciseDutyRefundAmount", excieamt);
                    XElement tottrifamt = new XElement(ns2 + "TotalGoodsAndServicesTaxRefundAmount", gstAmt);
                    taotaltrif = new XElement(ns3 + "TotalTariffRefund", "");
                    if (Convert.ToDecimal(gstAmt) > 0)
                    {
                        taotaltrif.Add(tottrifamt);
                    }
                    if (Convert.ToDecimal(excieamt) > 0)
                    {
                        taotaltrif.Add(tottrifExiceamt);
                    }
                    if (Convert.ToDecimal(cusamt) > 0)
                    {
                        taotaltrif.Add(tottrifCustomsamt);
                    }
                    if (Convert.ToDecimal(othertaxAmt) > 0)
                    {
                        taotaltrif.Add(tottrifOtheramt);
                    }
                }
                else
                {
                    string count = "";
                    string infilname1 = "select Count(*) as Numofitem,Sum(totalgstAmt) as totalgstAmt,sum(totalexciseAmt) as totalexciseAmt,sum(txtcusdutyAmt) as txtcusdutyAmt,sum(txtotherAmt) as txtotherAmt from reunditemsumm where MSGId='" + dt.Rows[0]["MSGId"].ToString() + "'";
                    obj.dr = obj.ret_dr(infilname1);
                    while (obj.dr.Read())
                    {
                        count = obj.dr["Numofitem"].ToString();
                        gstAmt = Convert.ToDecimal(obj.dr["totalgstAmt"].ToString());
                        excieamt = Convert.ToDecimal(obj.dr["totalexciseAmt"].ToString());
                        cusamt = Convert.ToDecimal(obj.dr["txtcusdutyAmt"].ToString());
                        othertaxAmt = Convert.ToDecimal(obj.dr["txtotherAmt"].ToString());
                    }
                    XElement tottrifOtheramt = new XElement(ns2 + "TotalOtherTaxRefundAmount", othertaxAmt);
                    XElement tottrifCustomsamt = new XElement(ns2 + "TotalCustomsDutyRefundAmount", cusamt);
                    XElement tottrifExiceamt = new XElement(ns2 + "TotalExciseDutyRefundAmount", excieamt);
                    XElement tottrifamt = new XElement(ns2 + "TotalGoodsAndServicesTaxRefundAmount", gstAmt);
                    taotaltrif = new XElement(ns3 + "TotalTariffRefund", "");
                    if (Convert.ToDecimal(gstAmt) > 0)
                    {
                        taotaltrif.Add(tottrifamt);
                    }
                    if (Convert.ToDecimal(excieamt) > 0)
                    {
                        taotaltrif.Add(tottrifExiceamt);
                    }
                    if (Convert.ToDecimal(cusamt) > 0)
                    {
                        taotaltrif.Add(tottrifCustomsamt);
                    }
                    if (Convert.ToDecimal(othertaxAmt) > 0)
                    {
                        taotaltrif.Add(tottrifOtheramt);
                    }
                    XElement nofoitem = new XElement(ns2 + "NumberOfItems", count);
                    summary.Add(nofoitem);
                }
                summary.Add(taotaltrif);



                string SupFile = "";
                XElement SupportingDocumentReference = null;
                XElement Filename = null;
                XElement DocumentID = null;
                //XElement SupportingDocumentReference = new XElement(ns3 + "SupportingDocumentReference", "");
                //infilname = "select * from InFile where InPaymentId='" + dt.Rows[0]["PermitId"].ToString() + "'";
                //obj.dr = obj.ret_dr(infilname);
                //while (obj.dr.Read())
                //{
                //    XElement Filename = new XElement(ns2 + "Filename", obj.dr["Name"].ToString().ToUpper());
                //    string[] docuID = obj.dr["DocumentType"].ToString().Split(':');
                //    XElement DocumentID = new XElement(ns2 + "DocumentID", docuID[0].ToString().Substring(0, docuID[0].Length - 1).ToUpper());
                //    SupFile = docuID[0].ToString().Substring(0, docuID[0].Length - 1);
                //    SupportingDocumentReference.Add(DocumentID);
                //    SupportingDocumentReference.Add(Filename);
                //}

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
                //string[] percode = null;
                //objd.dr = objd.ret_dr("select * from InpaymentCancel where Permitno='" + dt.Rows[0]["PermitNumber"].ToString() + "'");
                //if (objd.dr.HasRows)
                //{
                //    while (objd.dr.Read())
                //    {
                //        percode = objd.dr["ResonForCancel"].ToString().Split(':');
                //    }
                //}
                //XElement canreason = new XElement(ns2 + "CancellationReasonCode", percode[0].ToString().Substring(0, percode[0].Length - 1).ToUpper());
                //XElement DeclarationIndicator = new XElement(ns2 + "DeclarationIndicator", "true");
                //XElement CommonAccessReference = new XElement(ns2 + "CommonAccessReference", "IPTUPD");
                //XElement DeclarantID = new XElement(ns2 + "DeclarantID", "QXMF.QXMF001");
                //XElement MessageReference = new XElement(ns2 + "MessageReference", dt.Rows[0]["MSGId"].ToString());
                //string date = "";
                //string sequneNo = "";
                MSGNUMBER = dt.Rows[0]["MSGId"].ToString();
                //date = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                //sequneNo = dt.Rows[0]["MSGId"].ToString().Substring(dt.Rows[0]["MSGId"].ToString().Length - 4);
                //XElement UniqueReferenceNumber = new XElement(ns3 + "UniqueReferenceNumber", "");
                //UniqueReferenceNumber.Add(new XElement(ns2 + "ID", "201834618Z"));
                //UniqueReferenceNumber.Add(new XElement(ns2 + "Date", date));
                //UniqueReferenceNumber.Add(new XElement(ns2 + "SequenceNumeric", sequneNo));

                //XElement cancelupdhed = new XElement(ns3 + "CancellationHeader", "");
                //XElement cancelupd = new XElement(ns3 + "Cancellation", "");
                //if (!string.IsNullOrWhiteSpace(dt.Rows[0]["MSGId"].ToString()))
                //{
                //    cancelupdhed.Add(MessageReference);
                //}
                //cancelupdhed.Add(UniqueReferenceNumber);
                //cancelupdhed.Add(DeclarantID);
                //if (!string.IsNullOrWhiteSpace(dt.Rows[0]["MessageType"].ToString()))
                //{
                //    cancelupdhed.Add(CommonAccessReference);
                //}
                //cancelupdhed.Add(DeclarationIndicator);
                //cancelupdhed.Add(canreason);
                //cancelupd.Add(cancelupdhed);


                XElement Additional = new XElement(ns2 + "AdditionalRecipientID", "");
                XElement DeclarationIndicatorh = new XElement(ns2 + "DeclarationIndicator", "true");
                string[] DecType = dt.Rows[0]["DeclarationType"].ToString().Split(':');
                XElement CommonAccessReferenceh = null;
                //if (Update == "AMEND")
                //{
                CommonAccessReferenceh = new XElement(ns2 + "CommonAccessReference", "IPTUPD");
                //}
                //else
                //{
                //    CommonAccessReferenceh = new XElement(ns2 + "CommonAccessReference", dt.Rows[0]["MessageType"].ToString().ToUpper());
                //}
                XElement DeclarantIDh = new XElement(ns2 + "DeclarantID", dt.Rows[0]["TradeNetMailboxID"].ToString().ToUpper());
                XElement MessageReferenceh = new XElement(ns2 + "MessageReference", dt.Rows[0]["MSGId"].ToString().ToUpper());
                string dateh = "";
                string sequneNoh = "";
                dateh = dt.Rows[0]["MSGId"].ToString().Substring(0, dt.Rows[0]["MSGId"].ToString().Length - 4);
                sequneNoh = dt.Rows[0]["MSGId"].ToString().Substring(dt.Rows[0]["MSGId"].ToString().Length - 4);
                XElement UniqueReferenceNumberh = new XElement(ns3 + "UniqueReferenceNumber", "");
                UniqueReferenceNumberh.Add(new XElement(ns2 + "ID", DecId.ToUpper()));
                UniqueReferenceNumberh.Add(new XElement(ns2 + "Date", dateh.ToUpper()));
                UniqueReferenceNumberh.Add(new XElement(ns2 + "SequenceNumeric", sequneNoh.ToUpper()));
                XElement Header = new XElement(ns3 + "RefundHeader");
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["MSGId"].ToString()))
                {
                    Header.Add(MessageReferenceh);
                }
                Header.Add(UniqueReferenceNumberh);
                Header.Add(DeclarantIDh);
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["MessageType"].ToString()))
                {
                    Header.Add(CommonAccessReferenceh);
                }
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["DeclareIndicator"].ToString()))
                {
                    Header.Add(DeclarationIndicatorh);
                }
                //Header.Add(Additional);
                //header
                XElement updateAmt = null;
                int n = 0;
                if (!string.IsNullOrWhiteSpace(Update))
                {
                    string qry111 = "";
                    objcan = new MyClass();
                    qry111 = "select * from dbo.InpaymentRefund where Msgid='" + dt.Rows[0]["MSGId"].ToString() + "'";
                    objcan.dr = objcan.ret_dr(qry111);
                    while (objcan.dr.Read())
                    {
                        n = 1;
                        XElement updateAmtReason = null;
                        XElement updateexdper = null;
                        XElement updatepervalexp = null;
                        //if (Update == "AMEND")
                        //{
                        string[] reasoncode = objcan.dr["ResonForREfund"].ToString().Split(':');
                        updateAmtReason = new XElement(ns2 + "ReasonCode", reasoncode[0].Substring(0, reasoncode[0].Length - 1).ToUpper());
                        if (objcan.dr["ResonForREfund"].ToString() != "--Select--")
                        {
                            reasoncode[1] = reasoncode[1].ToString().Replace("~", "'");
                            updateexdper = new XElement(ns2 + "Reason", reasoncode[1].ToString().Trim().ToUpper());
                        }
                        //updatepervalexp = new XElement(ns2 + "PermitValidityExtensionIndicator", objcan.dr["PermitExtension"].ToString().ToLower());
                        //}
                        XElement updateAmtval = new XElement(ns3 + "Refund", "");
                        XElement updateReppermitno = new XElement(ns2 + "ReplacementPermitNumber", objcan.dr["ReplacementPermitno"].ToString().ToUpper());
                        XElement updatepermitno = new XElement(ns2 + "UpdatePermitNumber", objcan.dr["Permitno"].ToString().ToUpper());
                        XElement updatereuqno = new XElement(ns2 + "UpdateRequestNumber", n);
                        string[] refcode = objcan.dr["TypeOfRefund"].ToString().Split(':');

                        XElement updateInd = new XElement(ns2 + "UpdateIndicatorCode", refcode[0].Substring(0, refcode[0].Length - 1).ToUpper());
                        updateAmt = new XElement(ns3 + "Update", "");
                        //if (!string.IsNullOrWhiteSpace(objcan.dr["UpdateIndicator"].ToString()))
                        //{
                        updateAmt.Add(updateInd);
                        //}
                        updateAmt.Add(updatereuqno);
                        if (!string.IsNullOrWhiteSpace(objcan.dr["Permitno"].ToString()))
                        {
                            updateAmt.Add(updatepermitno);
                        }
                        if (!string.IsNullOrWhiteSpace(objcan.dr["ReplacementPermitno"].ToString()))
                        {
                            updateAmt.Add(updateReppermitno);
                        }
                        //if (Update == "AMEND")
                        //{
                        string chkval = "";
                        //if (!string.IsNullOrWhiteSpace(objcan.dr["PermitExtension"].ToString().ToLower()))
                        //{
                        //    updateAmtval.Add(updatepervalexp);
                        //    chkval = "IN";
                        //}
                        if (!string.IsNullOrWhiteSpace(objcan.dr["ResonForREfund"].ToString()))
                        {
                            updateAmtval.Add(updateAmtReason);
                            chkval = "IN";
                        }
                        if (!string.IsNullOrWhiteSpace(objcan.dr["ResonForREfund"].ToString()))
                        {
                            updateAmtval.Add(updateexdper);
                            chkval = "IN";
                        }

                        if (!string.IsNullOrWhiteSpace(chkval))
                        {
                            updateAmt.Add(updateAmtval);
                        }
                        //}
                    }
                    //reportElement.Add(updateAmt);
                }

                XElement InboundMessage = new XElement(ns1 + "InboundMessage");
                XElement InPayment = new XElement(ns5 + "InPaymentUpdate", "");
                XElement Refunfonly = new XElement(ns3 + "RefundOnly", "");
                if (!string.IsNullOrWhiteSpace(Update))
                {
                    InPayment.Add(updateAmt);
                }
                Refunfonly.Add(Header);
                Refunfonly.Add(DeclarantParty);
                //Refunfonly.Add(DeclarantParty);

                string infilnamet = "select * from InFile where InPaymentId='" + dt.Rows[0]["MSGId"].ToString() + "'";
                obj.dr = obj.ret_dr(infilnamet);
                while (obj.dr.Read())
                {
                    if (!string.IsNullOrWhiteSpace(SupFile))
                    {
                        SupportingDocumentReference = null;
                        SupportingDocumentReference = new XElement(ns3 + "SupportingDocumentReference", "");
                        Filename = new XElement(ns2 + "Filename", obj.dr["Name"].ToString().ToUpper());
                        string[] docuID = obj.dr["DocumentType"].ToString().Split(':');
                        DocumentID = new XElement(ns2 + "DocumentID", docuID[0].ToString().Substring(0, docuID[0].Length - 1).ToUpper());
                        SupFile = docuID[0].ToString().Substring(0, docuID[0].Length - 1);
                        SupportingDocumentReference.Add(DocumentID);
                        SupportingDocumentReference.Add(Filename);
                        Refunfonly.Add(SupportingDocumentReference);
                    }

                }
                decimal gstAmtI = 0, excieamtI = 0, cusamtI = 0, othertaxAmtI = 0;
                string itemno = "", hscode = "";
                string infilnamec = "select * from reunditemsumm where MSGId='" + dt.Rows[0]["MSGId"].ToString() + "'";
                obj.dr = obj.ret_dr(infilnamec);
                while (obj.dr.Read())
                {
                    if (!string.IsNullOrWhiteSpace(obj.dr["ItemNo"].ToString()))
                    {
                        itemno = obj.dr["ItemNo"].ToString();
                        hscode = obj.dr["HsCode"].ToString();
                        gstAmtI = Convert.ToDecimal(obj.dr["totalgstAmt"].ToString());
                        excieamtI = Convert.ToDecimal(obj.dr["totalexciseAmt"].ToString());
                        cusamtI = Convert.ToDecimal(obj.dr["txtcusdutyAmt"].ToString());
                        othertaxAmtI = Convert.ToDecimal(obj.dr["txtotherAmt"].ToString());
                        XElement Othersexcieduty = new XElement(ns2 + "OtherTaxRefundAmount", othertaxAmtI);
                        XElement Cusexcieduty = new XElement(ns2 + "CustomsDutyRefundAmount", cusamtI);
                        XElement excieduty = new XElement(ns2 + "ExciseDutyRefundAmount", excieamtI);
                        XElement tsrgoos = new XElement(ns2 + "GoodsAndServicesTaxRefundAmount", gstAmtI);
                        XElement triff = new XElement(ns3 + "TariffRefund", "");
                        if (Convert.ToDecimal(gstAmtI) > 0)
                        {
                            triff.Add(tsrgoos);
                        }
                        if (Convert.ToDecimal(excieamtI) > 0)
                        {
                            triff.Add(excieduty);
                        }
                        if (Convert.ToDecimal(cusamtI) > 0)
                        {
                            triff.Add(Cusexcieduty);
                        }
                        if (Convert.ToDecimal(othertaxAmtI) > 0)
                        {
                            triff.Add(Othersexcieduty);
                        }

                        XElement itemhscode = new XElement(ns2 + "ItemHarmonizedSystemCode", hscode.ToUpper());
                        XElement itemsequnce = new XElement(ns2 + "ItemSequenceNumeric", itemno);
                        XElement item = new XElement(ns3 + "RefundItem", "");
                        item.Add(itemsequnce);
                        item.Add(itemhscode);
                        item.Add(triff);
                        Refunfonly.Add(item);
                    }
                }


                Refunfonly.Add(summary);
                InPayment.Add(Refunfonly);
                InboundMessage.Add(InPayment);

                //XElement InPayment = new XElement(ns5 + "Inpayment", "");
                reportElement.Add(new XElement(ns2 + "MessageVersion", "041"));
                reportElement.Add(new XElement(ns2 + "SenderID", dt.Rows[0]["TradeNetMailboxID"].ToString().ToUpper()));
                //reportElement.Add(new XElement(ns2 + "RecipientID", "DCST.DCST401"));
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

            var folder = @"D:\MHAccess\workingdir\KaizenOUT\" + tradeID;
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            //string path = @"D:\Kaizen\IPTDEC.xml";
            string path = @"D:\MHAccess\workingdir\KaizenOUT\" + tradeID;
            string MsgId = MSGNUMBER;
            string filename = path + "\\IPTDEC" + MsgId + ".xml";
            // Create a file to write to.
            if (!File.Exists(filename))
            {
                //File.Delete(filename);
                using (StreamWriter sw = File.CreateText(filename))
                {
                    sw.WriteLine(sb.ToString());

                    string Name = "IPTDEC" + MsgId + ".xml";
                    string strins = "";
                    strins = "Insert Into XmlTbl values('" + path + "','" + Name + "','','" + tradeID.ToLower() + "')";
                    obj.exec(strins);

                    strins = "Insert Into DownXmlTbl values('" + path + "','" + Name + "','','" + tradeID.ToLower() + "')";
                    obj.exec(strins);

                    string strinsn = "";

                    //Send CMD 
                    //            Command=Submit|cont_type=F|subj=IPTDEC202510290002|filename=D:\\MHAccess\\workingdir\\KaizenOUT\\KAKG001\\IPTDEC202510290002.xml|cont_id=G14848838067|recip_id=dcst401|notifn=N"

                    string sunjt = "IPTDEC" + MsgId + "";
                    strinsn = "Insert Into Customs_Data values('" + tradeID.ToLower() + "','" + path + "','" + Name + "','Command=Submit|cont_type=F|subj="+ sunjt + "|filename="+ path + "\\"+ Name + "|cont_id=G14848838067|recip_id=dcst401|notifn=N','Send CMD','Not Executed')";
                    obj.exec(strinsn);


                    obj.closecon();
                }
            }
        }
        private void exce()
        {
            string command = "java -jar C:\\Users\\Administrator\\Desktop\\dist\\Demo.jar";

            int exitCode;
            ProcessStartInfo processInfo;
            Process process;

            processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            // *** Redirect the output ***
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            process = Process.Start(processInfo);
            process.WaitForExit();

            // *** Read the streams ***
            // Warning: This approach can lead to deadlocks, see Edit #2
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            exitCode = process.ExitCode;

            Console.WriteLine("output>>" + (String.IsNullOrEmpty(output) ? "(none)" : output));
            Console.WriteLine("error>>" + (String.IsNullOrEmpty(error) ? "(none)" : error));
            Console.WriteLine("ExitCode: " + exitCode.ToString(), "ExecuteCommand");
            process.Close();
        }
        protected void BtnSaveFinal_Click(object sender, EventArgs e)
        {
            string str = string.Empty;
            string strname = string.Empty;
            string permitid = null;
            string tradeIDXML = "";

            //Added for testing
            string str100 = "update testing_send_receive set update_field = 'Inside-First' where id = 1 ";
            obj.exec(str100);

            //RunJavaProgram();

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
                        obj2.dr = obj2.ret_dr("Select prmtStatus,TradeNetMailboxID from InHeaderTbl where PermitId='" + permitid + "'");
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
                            LoadIptDecCancel(permitid);
                        }
                        else if (Update == "RFD")
                        {
                            LoadIptDecRefund(permitid);
                        }
                        else
                        {
                            LoadIPTDEC(permitid);
                        }


                        string Touch_user = Session["UserId"].ToString();
                        string strTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        string P1 = ("Update InHeaderTbl set Status='PEN' , TouchUser= '" + Touch_user + "' , TouchTime='" + strTime + "' where PermitId='" + permitid + "' ");
                        obj.exec(P1);
                        obj.closecon();
                    }
                }
            }



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




            ErrorXml(tradeIDXML);
           
            Cancelxml(tradeIDXML);
            RejectionXML(tradeIDXML);
            AmendXml(tradeIDXML);
            ResponseXML(tradeIDXML);


            BindInPayment();





        }

        protected void txtLocalNo_TextChanged(object sender, EventArgs e)
        {
            search();
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

        protected void btnrefundccp_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gvrow in GridInPayment.Rows)
            {
                var checkbox = gvrow.FindControl("CheckBox1") as CheckBox;
                if (checkbox.Checked)
                {
                    Label ID1 = (Label)gvrow.FindControl("Id");
                    string ID = ID1.Text;
                    MyClass lodobj = new MyClass();
                    string lodport = "select * from [InHeaderTbl] where Id=" + ID + "";
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
                        RefundCcp(PermID);
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

        private void LoadCCPPrintstatus(string permit)
        {
            string permitno = "KAIZEN00120190519001";
            string type = "", tableName = "";
            SqlDataAdapter da;
            SqlDataReader dr;
            SqlCommand cmd1;
            //  SqlConnection con = new SqlConnection();
            string comNamedec = "", Decname = "", unicref = "", telphn = "", deccode = "";
            type = "IN-Payment";

            //string constr = ConfigurationManager.ConnectionStrings["Data source=GOD-PC;Initial catalog=KaizenTrial;Persist Security Info=True;user ID=sa;Password=123;Min Pool Size=10; Max Pool Size=20000"].ConnectionString;
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from InHeaderTbl  where PermitId='" + permit + "'"))
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
            string path = Server.MapPath("PDF-Files");
            //string path = @"C:\Users\Public\PDF-Files";
            //string filename = path + "\\" + "CCCp.pdf";
            string filename = path + "\\" + "CCCp";

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
            string data = "00000000";
            Barcode39 code128 = new Barcode39();



            string pernum = "";

            string msgtype = "";

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
            string impget = "Select * from Importer where Code='" + dt.Rows[0]["ImporterCompanyCode"].ToString() + "'";
            objdec.dr = objdec.ret_dr("Select * from Importer where Code='" + dt.Rows[0]["ImporterCompanyCode"].ToString() + "'");
            // dr = cmd1.ExecuteReader();

            if (objdec.dr.Read())
            {
                imptrname = objdec.dr["Name"].ToString();
                impname1 = objdec.dr["Name1"].ToString();
                impceui = objdec.dr["CRUEI"].ToString();
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

            cell = new PdfPCell(new Phrase("MESSAGE TYPE :IN-PAYMENT DECLARATION", times));
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
            string date = "DATE: 12/08/2019 ";
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
            cell = new PdfPCell(new Phrase("AME / CNL PERMIT: " + dt.Rows[0]["PermitNumber"].ToString(), times));
            table.AddCell(cell);


            cell.Colspan = 2;

            cell = new PdfPCell(new Phrase("PORT OF DISCHG: ", times));

            table.AddCell(cell);
            //  string msgid = dt.Rows[0]["MSGId"].ToString();
            cell = new PdfPCell(new Phrase("PREV PERMIT: " + dt.Rows[0]["PreviousPermit"].ToString(), times));
            table.AddCell(cell);

            cell.Colspan = 2;

            cell = new PdfPCell(new Phrase("DESTINATION CITY: ", times));

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

            cell = new PdfPCell(new Phrase("IN TRANSPORT ID: " + transportid.ToUpper(), times));

            table.AddCell(cell);
            //  string msgid = dt.Rows[0]["MSGId"].ToString();
            cell = new PdfPCell(new Phrase("DEPARTURE DATE: ", times));
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

            cell.Colspan = 2;

            cell = new PdfPCell(new Phrase("OUT TRANSPORT ID:", times));

            table.AddCell(cell);
            //  string msgid = dt.Rows[0]["MSGId"].ToString();
            cell = new PdfPCell(new Phrase("TOTAL GROSS WGT: " + grossgst, times));
            table.AddCell(cell);


            cell.Colspan = 2;

            cell = new PdfPCell(new Phrase("CONVEYANCEREF: ", times));

            table.AddCell(cell);
            //  string msgid = dt.Rows[0]["MSGId"].ToString();
            cell = new PdfPCell(new Phrase("TOTAL CIFFOB VAL: $ " + dt.Rows[0]["TotalCIFFOBValue"].ToString(), times));
            table.AddCell(cell);


            //cell.Colspan = 2;

            cell = new PdfPCell(new Phrase("MAWB/OBL: ", times));


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

            cell1 = new PdfPCell(new Phrase("Error Id", times));
            table1.AddCell(cell1);

            cell1 = new PdfPCell(new Phrase("Description", times));
            table1.AddCell(cell1);

            //reject desc


            string rej = "select ErrorSno,ErrorID,ErrorDescription from RejectStatus  where MsgID='" + dt.Rows[0]["MSGId"].ToString() + "'";
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
                    obj2.dr = obj2.ret_dr("Select Status from InHeaderTbl where PermitId='" + permitid + "'");
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
            string permitno = "KAIZEN00120190519001";
            string type = "", tableName = "";
            SqlDataAdapter da;
            SqlDataReader dr;
            SqlCommand cmd1;
            //  SqlConnection con = new SqlConnection();
            string comNamedec = "", Decname = "", unicref = "", telphn = "", deccode = "";
            type = "IN-Payment";

            //string constr = ConfigurationManager.ConnectionStrings["Data source=GOD-PC;Initial catalog=KaizenTrial;Persist Security Info=True;user ID=sa;Password=123;Min Pool Size=10; Max Pool Size=20000"].ConnectionString;
            string constr = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from InHeaderTbl  where PermitId='" + permit + "'"))
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
            string path = Server.MapPath("PDF-Files");
            //string path = @"C:\Users\Public\PDF-Files";
            //string filename = path + "\\" + "CCCp.pdf";
            string filename = path + "\\" + "CCCp";

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
            string data = "00000000";
            Barcode39 code128 = new Barcode39();



            //string pernum = "";

            //string msgtype = "";

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
            string impget = "Select * from Importer where Code='" + dt.Rows[0]["ImporterCompanyCode"].ToString() + "'";
            objdec.dr = objdec.ret_dr("Select * from Importer where Code='" + dt.Rows[0]["ImporterCompanyCode"].ToString() + "'");
            // dr = cmd1.ExecuteReader();

            if (objdec.dr.Read())
            {
                imptrname = objdec.dr["Name"].ToString();
                impname1 = objdec.dr["Name1"].ToString();
                impceui = objdec.dr["CRUEI"].ToString();
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

            cell = new PdfPCell(new Phrase("MESSAGE TYPE :IN-PAYMENT UPDATE APPLICATION", times));
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
            string date = "DATE: 12/08/2019 ";
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
            cell = new PdfPCell(new Phrase("PERMIT NUMBER: " + dt.Rows[0]["PermitNumber"].ToString().ToUpper(), times));
            table.AddCell(cell);


            cell.Colspan = 2;

            cell = new PdfPCell(new Phrase("PORT OF DISCHG: ", times));

            table.AddCell(cell);
            //  string msgid = dt.Rows[0]["MSGId"].ToString();
            cell = new PdfPCell(new Phrase("PREV PERMIT: " + dt.Rows[0]["PreviousPermit"].ToString(), times));
            table.AddCell(cell);

            cell.Colspan = 2;

            cell = new PdfPCell(new Phrase("DESTINATION CITY: ", times));

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

            cell = new PdfPCell(new Phrase("IN TRANSPORT ID: " + transportid.ToUpper(), times));

            table.AddCell(cell);
            //  string msgid = dt.Rows[0]["MSGId"].ToString();
            cell = new PdfPCell(new Phrase("DEPARTURE DATE: ", times));
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

            cell.Colspan = 2;

            cell = new PdfPCell(new Phrase("OUT TRANSPORT ID:", times));

            table.AddCell(cell);
            //  string msgid = dt.Rows[0]["MSGId"].ToString();
            cell = new PdfPCell(new Phrase("TOTAL GROSS WGT: " + grossgst, times));
            table.AddCell(cell);


            cell.Colspan = 2;

            cell = new PdfPCell(new Phrase("CONVEYANCEREF: ", times));

            table.AddCell(cell);
            //  string msgid = dt.Rows[0]["MSGId"].ToString();
            cell = new PdfPCell(new Phrase("TOTAL CIFFOB VAL: $ " + dt.Rows[0]["TotalCIFFOBValue"].ToString(), times));
            table.AddCell(cell);


            //cell.Colspan = 2;

            cell = new PdfPCell(new Phrase("MAWB/OBL: ", times));


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


            string rej = "select * from InpaymentCancel  where Permitno='" + dt.Rows[0]["PermitNumber"].ToString() + "'";
            lodobj.dr = lodobj.ret_dr(rej);
            if (lodobj.dr.HasRows)
            {
                while (lodobj.dr.Read())
                {
                    string[] roc = lodobj.dr["ResonForCancel"].ToString().Split(':');
                    cell1 = new PdfPCell(new Phrase(roc[0].ToString().ToUpper(), times));
                    table1.AddCell(cell1);
                    cell1 = new PdfPCell(new Phrase(lodobj.dr["DescriptionOfReason"].ToString().ToUpper(), times));
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


            string rej1 = "select * from InCancel  where PermitNumber='" + dt.Rows[0]["PermitNumber"].ToString() + "'";
            lodobj.dr = lodobj.ret_dr(rej1);
            if (lodobj.dr.HasRows)
            {
                while (lodobj.dr.Read())
                {
                    string[] roc = lodobj.dr["ConditionCde"].ToString().Split(':');
                    cell12 = new PdfPCell(new Phrase(roc[0].ToString().ToUpper(), times));
                    table2.AddCell(cell12);
                    cell12 = new PdfPCell(new Phrase(lodobj.dr["ConditionDes"].ToString().ToUpper(), times));
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
                    obj2.dr = obj2.ret_dr("Select Status from InHeaderTbl where PermitId='" + permitid + "'");
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

    }
}