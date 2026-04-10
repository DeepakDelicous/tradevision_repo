using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Configuration;

namespace RET
{
    /// <summary>
    /// Summary description for GetImporter
    /// </summary>
    public class GetImporter : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string term = context.Request["term"] ?? "";
            List<string> Deccode = new List<string>();

            string cs = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select Code from Importer where Code like @SearchText + '%'", con);
                cmd.Parameters.AddWithValue("@SearchText", term);          
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Deccode.Add(rdr["Code"].ToString());
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            context.Response.Write(js.Serialize(Deccode));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}