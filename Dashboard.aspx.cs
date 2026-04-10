using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RET
{
    public partial class Dashboard : System.Web.UI.Page
    {
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



            //string LogStstus = "";
            //string perqry31 = "select LoginStatus from ManageUser where UserId='" + Session["UserId"].ToString() + "'";
            //obj.dr = obj.ret_dr(perqry31);
            //while (obj.dr.Read())
            //{
            //    LogStstus = obj.dr["LoginStatus"].ToString();
            //}

            //if (LogStstus == "True")
            //{
            //    Response.Redirect("sessionTimeout.aspx");
            //}
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelPackage.License.SetNonCommercialOrganization("My Noncommercial organization");

                if (!fuExcel.HasFile)
                {
                    lblMessage.Text = "Please select an Excel file.";
                    return;
                }

                // Read Excel codes
                List<string> hsCodes = new List<string>();
                using (var stream = new MemoryStream(fuExcel.FileBytes))
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;

                    // Read first column (A) starting from row 2 (skip header)
                    for (int row = 2; row <= rowCount; row++)
                    {
                        string code = worksheet.Cells[row, 1].Text // Column A (1-based)
                            .Replace("/", "").Trim();

                        if (!string.IsNullOrEmpty(code))
                        {
                            hsCodes.Add(code);
                        }
                    }
                }

                if (hsCodes.Count == 0)
                {
                    lblMessage.Text = "No valid HS Codes found.";
                    return;
                }

                // Update database
                string connectionString = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
                int updatedRows = 0;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    foreach (string code in hsCodes)
                    {
                        using (SqlCommand cmd = new SqlCommand(
                            @"UPDATE HSCode 
                              SET is_out_controlled = 1
                              WHERE HSCode = @Code", conn))
                        {
                            cmd.Parameters.AddWithValue("@Code", code);
                            updatedRows += cmd.ExecuteNonQuery();
                        }
                    }
                }

                lblMessage.Text = $"Updated {updatedRows} HS Code(s) successfully!";
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"Error: {ex.Message}";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

    }
}