using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using System.Xml;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace RET
{
    /// <summary>
    /// Summary description for Autocomplete
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class Autocomplete : System.Web.Services.WebService
    {

        [WebMethod]
        public List<string> GetAutoCompleteData(string username)
        {
            List<string> result = new List<string>();
            using (SqlConnection con = new SqlConnection(@"Data source=GOD-PC;Initial catalog=KaizenPortal;Persist Security Info=True;user ID=sa;Password=123;Min Pool Size=10; Max Pool Size=20000"))
            {
                using (SqlCommand cmd = new SqlCommand("select * from  Importer where Code like @SearchText+'%'", con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@SearchText", username);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        result.Add(dr["Name"].ToString());
                    }
                    return result;
                }
            }
        }
    }
}
