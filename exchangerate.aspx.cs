using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace RET
{
    public partial class exchangerate : System.Web.UI.Page
    {
        MyClass obj = new MyClass();
        static List<string> lststr = new List<string>();
        List<string> lststr1 = new List<string>();
        List<string> lststr2 = new List<string>();
        List<string> lststr3 = new List<string>();
        string msgid = "", pemno = "", issueaut = "", commacc = "", ststype = "", SnoName = "Sno";
        string issueautName = "", commaccName = "";
        string curycde = "";
        decimal currate = 0, ratunt = 0;
        string fldName = "", fldval = "", fldval1 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string xmlFile = File.ReadAllText(@"C:\Users\Public\ResponseFile\CUSEXR10-05-2019.xml");
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
            var nodeList = xmldoc.GetElementsByTagName("cux:CustomsExchangeRate");
            string Short_Fall = string.Empty;
            string hdtext = string.Empty;
            int i = 0;
            var nodeList3 = xmldoc.GetElementsByTagName("cbc:StartDate");
            foreach (XmlNode node in nodeList3)
            {
                issueautName = "StartDate";
                issueaut = node.InnerText;
            }
            var nodeList4 = xmldoc.GetElementsByTagName("cbc:EndDate");
            foreach (XmlNode node in nodeList4)
            {
                commaccName = "EndDate";
                commacc = node.InnerText;
            }
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
                        if (hdtext == "cac:ExchangeRate")
                        {
                            foreach (XmlNode child1 in children1)
                            {
                                string name = child1.Name;
                                string[] hval1 = child1.Name.ToString().Split(':');
                                if (hval1[1].ToString() == "CurrencyCode")
                                {
                                    sno1 = sno1 + 1;
                                    if (chki == 0)
                                    {
                                        fldName = fldName + hval1[1].ToString() + ",";
                                    }
                                    curycde = child1.InnerText;
                                    fldval = fldval + "'" + child1.InnerText + "',";
                                }
                                else if (hval1[1].ToString() == "CurrencyDescription")
                                {
                                    if (chki == 0)
                                    {
                                        fldName = fldName + "CurrencyDescription,";
                                    }
                                    fldval = fldval + "'" + child1.InnerText + "',";
                                }
                                else if (hval1[1].ToString() == "CurrencyExchangeRate")
                                {
                                    if (chki == 0)
                                    {
                                        fldName = fldName + "CurrencyExchangeRate,";
                                    }
                                    currate = Convert.ToDecimal(child1.InnerText);
                                    fldval = fldval + "'" + child1.InnerText + "',";
                                }
                                else if (hval1[1].ToString() == "RateUnit")
                                {
                                    if (chki == 0)
                                    {
                                        fldName = fldName + "RateUnit,";
                                    }
                                    ratunt = Convert.ToDecimal(child1.InnerText);
                                    fldval = fldval + "'" + child1.InnerText + "',";
                                }
                                else if (hval1[1].ToString() == "CountryName")
                                {
                                    if (chki == 0)
                                    {
                                        fldName = fldName + "CountryName,";
                                    }
                                    fldval = fldval + "'" + child1.InnerText + "',";
                                }
                            }

                        }
                        if (!string.IsNullOrWhiteSpace(fldval))
                        {
                            //for (int j = 0; j < lststr1.Count; j++)
                            //{
                            //    if (j == 0)
                            //    {
                            fldval1 = "'" + sno1 + "',";
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
                            //}

                            string str = "";
                            //str = "Insert into RejectStatus("+SnoName+","+msgidName+","+issueautName+","+commaccName+","+ststypeName+"," + fldName + ") values(" + fldval + ")";
                            str = "Insert into CustomsCurrency(" + SnoName + "," + issueautName + "," + commaccName + "," + fldName + ") values(" + fldval1 + ")";
                            obj.exec(str);

                            decimal rateval = currate / ratunt;
                            str = "update Currency set CurrencyRate='" + rateval + "' where Currency='" + curycde + "'";
                            obj.exec(str);
                            //}
                        }
                    }
                }
            }
        }
    }
}