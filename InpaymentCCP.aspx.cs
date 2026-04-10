                                                                                                                                                                                                                                                                                                                    
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RET
{
    public partial class InpaymentCCP : System.Web.UI.Page
    {
        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
        MyClass obj = new MyClass();
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
            //font
            BaseFont bf = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

            iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 4, iTextSharp.text.Font.NORMAL);
            // HEADER & FOOTER

            string path = Server.MapPath("PDF-Files");
            string filename = path + "\\InpaymentCCP.pdf";

            //Create new PDF document 
            iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 20f, 20f, 20f, 20f);
            PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create, FileAccess.ReadWrite));

            //Barcode genarate
            Response.ContentType = "application/pdf";
            PdfWriter writer = PdfWriter.GetInstance(
              document, Response.OutputStream
            );
            document.Open();



            PdfContentByte cb = writer.DirectContent;
            iTextSharp.text.pdf.Barcode128 bc = new Barcode128();
            bc.TextAlignment = Element.ALIGN_CENTER;

            bc.Code = "Deepak";
            bc.StartStopText = false;

            bc.CodeType = iTextSharp.text.pdf.Barcode128.CODE128;
            bc.Extended = true;
            iTextSharp.text.Image PatImage1 = bc.CreateImageWithBarcode(cb, iTextSharp.text.BaseColor.BLACK, iTextSharp.text.BaseColor.BLACK);
            PatImage1.ScaleToFit(460, 60);
            PdfPTable p_detail1 = new PdfPTable(1);
            p_detail1.WidthPercentage = 100;
            PdfPCell barcideimage = new PdfPCell(PatImage1);
            //barcideimage.Colspan = 2;
            barcideimage.HorizontalAlignment = 2;
            barcideimage.Border = 0;
            p_detail1.AddCell(barcideimage);
            document.Add(p_detail1);
            //title
            string title = "CARGO CLEARANCE PERMIT";
            iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph(title, FontFactory.GetFont("COURIER", 12));
            paragraph.Alignment = Element.ALIGN_CENTER;
            document.Add(paragraph);
            document.Add(new Paragraph("\n"));

            //page no
            PdfPTable page1 = new PdfPTable(2);
            page1.WidthPercentage = 100f;

            page1.DefaultCell.Padding = 5;
            page1.DefaultCell.Border = 0;
            page1.AddCell("PERMIT NO : IG8J722954I ");
            page1.AddCell("                                        Page 1 OF 3");
            document.Add(page1);

            //Message type
            string msgtype = "MESSAGE TYPE : IN-PAYMENT PERMIT";
            iTextSharp.text.Paragraph Pmsgtype = new iTextSharp.text.Paragraph(msgtype, FontFactory.GetFont("COURIER", 10));
            Pmsgtype.Alignment = Element.ALIGN_LEFT;
            document.Add(Pmsgtype);


            document.Add(new Paragraph("\n"));

            //Dec Type
            string DecType = "DECLARATION TYPE : GST (INCLUDING DUTY EXEMPTION)";
            iTextSharp.text.Paragraph PDecType = new iTextSharp.text.Paragraph(DecType, FontFactory.GetFont("COURIER", 10));
            PDecType.Alignment = Element.ALIGN_LEFT;
            document.Add(PDecType);
            document.Add(new Paragraph("\n"));
            //2 column
            PdfPTable table = new PdfPTable(2);



            table.WidthPercentage = 100f;
            table.DefaultCell.Padding = 5;
            table.DefaultCell.Border = 0;
            iTextSharp.text.Font fontTable = FontFactory.GetFont("COURIER", 2, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            table.DefaultCell.Phrase = new Phrase() { Font = fontTable };
            table.AddCell("IMPORTER:");
            table.AddCell("VALIDITY PERIOD");

            table.AddCell("MSA S.E.ASIA PTE LTD 12/10");
            table.AddCell("01/10/2018 - 30/10/2018");

            table.AddCell("");
            table.AddCell("");

            string value = "600000.00";
            table.AddCell("197802733G");
            table.AddCell("TOTAL GROSS WT/UNIT :           600.960/KGM");

            table.AddCell("EXPORTER:");
            table.AddCell("TOTAL OUTER PACK/UNIT :                 42/PKG");

            table.AddCell("Expoter Name");
            table.AddCell("TOT EXCISE DUT PAYABLE :S$       " + value);

            table.AddCell("Exporter Add");
            table.AddCell("TOT CUSTOMS DUT PAYABLE:S$   " + value);

            table.AddCell("197802733G");
            table.AddCell("TOT OTHER TAX PAYABLE : S$       " + value);

            table.AddCell("HANDLING AGENT:");
            table.AddCell("TOTAL GST AMT : S$                        " + value);

            table.AddCell("");
            table.AddCell("TOTAL AMOUNT PAYABLE : S$       " + value);

            table.AddCell("");
            table.AddCell("CARGO PACKING TYPE: OTHER NON-CONTAINERIZED");

            table.AddCell("");
            table.AddCell("IN TRANSPORT IDENTIFIER:");

            table.AddCell("PORT OF LOADING/NEXT PORT OF CALL:");
            table.AddCell("CONVEYANCE REFERENCE NO: SQ7367");

            table.AddCell("LYON-SATOLAS APT");
            table.AddCell("OBL/MAWB NO:");

            table.AddCell("PORT OF DISCHARGE/FINAL PORT OF CALL:");
            table.AddCell("61855390020");

            table.AddCell("");
            table.AddCell("ARRIVAL DATE : 01/10/2018");

            table.AddCell("COUNTRY OF FINAL DESTINATION:");
            table.AddCell("OU TRANSPORT IDENTIFIER:");

            table.AddCell("");
            table.AddCell("");

            table.AddCell("INWARD CARRIER AGENT:");
            table.AddCell("CONVEYANCE REFERENCE NO:");

            table.AddCell("SINGAPORE AIRPORT TERMINAL SERVICES");
            table.AddCell("OBL/MAWB/UCR NO:");

            table.AddCell("");
            table.AddCell("DEPARTURE DATE :");

            table.AddCell("OUTWARD CARRIER AGENT:");
            table.AddCell("");

            table.AddCell("");
            table.AddCell("CERTIFICATE NO:");

            table.AddCell("");
            table.AddCell("");

            table.AddCell("PLACE OF RELEASE:");
            table.AddCell("PLACE OF RECEIPT:");

            table.AddCell("CHANGI FTZ");
            table.AddCell("OTHERS");

            table.AddCell("CZ");
            table.AddCell("O");

            table.AddCell("LICENCE NO:");
            table.AddCell("CUSTOMS PROCEDURE CODE (CPC) :");


            document.Add(table);
            //line
            Paragraph Line = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 200.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            document.Add(Line);
            //ref No

            document.Add(new Paragraph(new Chunk("UNIQUE REF : 199400013D 20181001 7138", font)));
            //page 2
            document.Add(paragraph);
            string Continue = "(CONTINUATION PAGE)";
            iTextSharp.text.Paragraph pContinue = new iTextSharp.text.Paragraph(Continue, FontFactory.GetFont("COURIER", 12));
            pContinue.Alignment = Element.ALIGN_CENTER;
            document.Add(pContinue);

            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph("\n"));


            PdfPTable page2 = new PdfPTable(2);
            page2.WidthPercentage = 100f;

            page2.DefaultCell.Padding = 5;
            page2.DefaultCell.Border = 0;
            page2.AddCell("PERMIT NO : IG8J722954I ");
            page1.AddCell("                                        Page 2 OF 3");
            document.Add(page2);


            document.Add(new Paragraph("CONSIGMENT DETAILS"));
            document.Add(Line);

            //CONSIGMENT tbl
            PdfPTable constbl = new PdfPTable(2);
            constbl.WidthPercentage = 100f;
            constbl.DefaultCell.Padding = 5;
            constbl.DefaultCell.Border = 0;
            iTextSharp.text.Font fconstbl = FontFactory.GetFont("COURIER", 2, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            constbl.DefaultCell.Phrase = new Phrase() { Font = fconstbl };
            constbl.AddCell("S/NO HS CODE CURRENT LOT NO");
            constbl.AddCell("PREVIOUS LOT NO");

            constbl.AddCell("MARKING CTY OF ORIGIN BRAND NAME");
            constbl.AddCell("MODEL");

            constbl.AddCell("IN HAWB/HUCR/HBL");
            constbl.AddCell("OUT HAWB/HUCR/HBL");

            constbl.AddCell("PACKING/GOODS DESCRIPTION");
            constbl.AddCell("HS QUANTITY & UNIT");

            constbl.AddCell("");
            constbl.AddCell("CIF/FOB VALUE (S$)");

            constbl.AddCell("");
            constbl.AddCell("GST AMOUNT (S$)");

            document.Add(constbl);


            document.Add(new Paragraph("MANUFACTURER'S NAME"));
            document.Add(Line);

            //manufacture tbl

            PdfPTable manu = new PdfPTable(2);
            manu.WidthPercentage = 100f;
            manu.DefaultCell.Padding = 5;
            manu.DefaultCell.Border = 0;
            iTextSharp.text.Font fmanu = FontFactory.GetFont("COURIER", 2, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            manu.DefaultCell.Phrase = new Phrase() { Font = fmanu };
            manu.AddCell("01 65061020");
            manu.AddCell("");

            manu.AddCell("FR MSA");
            manu.AddCell("");

            manu.AddCell("1022335686");
            manu.AddCell("");

            manu.AddCell("INDUSTRIAL SAFETY HELMETS & FIREFIGHTERS' HELMETS");
            manu.AddCell("000000.0000 NMB");

            manu.AddCell("EXCL STEEL HELMETS (NMB)");
            manu.AddCell("000000.92");

            manu.AddCell("");
            manu.AddCell("000000.67");

            document.Add(manu);
            document.Add(Line);
            document.Add(manu);
            document.Add(new Paragraph("MSA EUROPE GMBH"));

            document.Add(Line);

            //CA/SC PRODUCT tbl

            PdfPTable casc = new PdfPTable(3);
            casc.WidthPercentage = 100f;
            casc.DefaultCell.Padding = 5;
            casc.DefaultCell.Border = 0;

            iTextSharp.text.Font fcasc = FontFactory.GetFont("COURIER", 2, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            casc.DefaultCell.Phrase = new Phrase() { Font = fcasc };
            casc.AddCell("S/NO");
            casc.AddCell("CA/SC PRODUCT CODE");
            casc.AddCell("CA/SC PRODUCT QTY & UNIT");

            casc.AddCell("01");
            casc.AddCell("IDAMISC");
            casc.AddCell("5.0000 NMB");
            document.Add(casc);
            document.Add(Line);
            //TRADER'S REMARKS
            document.Add(new Paragraph("TRADER'S REMARKS"));
            document.Add(new Paragraph("1022335686-0012"));
            document.Add(new Paragraph("INVOICE: 95288997/95288999/95289000/95288998"));
            document.Add(Line);
            document.Add(new Paragraph("NO UNAUTHORISED ADDITION/AMENDMENT TO THIS PERMIT MAY BE MADE AFTER APPROVAL"));
            document.Add(Line);
            document.Add(new Paragraph("NAME OF COMPANY: KUEHNE + NAGEL PTE. LTD"));

            document.Add(new Paragraph("DECLARANT NAME : HIZWANDY BIN MOHD AZAN"));
            document.Add(new Paragraph("DECLARANT CODE : XXXX5571E"));
            document.Add(new Paragraph("TEL NO : 63186961"));
            document.Add(Line);

            document.Close();
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
    }
}