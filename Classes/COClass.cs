using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace RET.Classes
{
    public class COClass
    {
        // string key = "A!9HHhi%XjjYY4YP2@Nob009X";
        static string SessionName, AccountId, MacId;
        public SqlDataReader dr;
        public SqlDataAdapter sda;
        public DataSet ds = new DataSet();
        int ItemCode = 0;
        public static string GetSession()
        {
            return SessionName;

        }
        public static string GetSessionDes()
        {
            return AccountId;

        }
        public static string GetSessionMac()
        {
            return MacId;

        }

        public static void SetSessionMac(string Session)
        {
            MacId = Session;

        }
        public static void SetSession(string Session)
        {
            SessionName = Session;

        }
        public static void SetSessionDes(string Session)
        {
            AccountId = Session;

        }
        public SqlConnection con()
        {
            String str = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            SqlConnection con1 = new SqlConnection(str);
            if (con1.State == ConnectionState.Closed || con1.State == ConnectionState.Broken)
            {
                con1.Open();
            }
            return con1;
        }

        public SqlDataReader ret_dr(String str)
        {
            SqlCommand cmd = new SqlCommand(str, con());
            return cmd.ExecuteReader();
        }

        public DataSet ds1(string str)
        {
            DataSet ds2 = new DataSet();
            SqlCommand cmd = new SqlCommand(str, con());
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd);
            sda1.Fill(ds2);
            return ds2;
        }
        public int exec(String str)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(str, con());
                ItemCode = cmd.ExecuteNonQuery();
                return ItemCode;
            }
            catch (SqlException ex)
            {
                ItemCode = ex.ErrorCode;
                return ItemCode;
            }
        }
        public SqlConnection closecon()
        {
            string str = ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString;
            SqlConnection con1 = new SqlConnection(str);
            if (con1.State == ConnectionState.Open)
            {
                con1.Close();
            }
            return con1;
        }
        public void BindDropDown(DropDownList drpObject, object dataSource,
       string value, string text, string customSelectText = "--Select--")
        {
            drpObject.DataSource = dataSource;
            drpObject.DataTextField = text;
            drpObject.DataValueField = value;
            drpObject.DataBind();
            var li = new ListItem { Text = customSelectText, Value = "0" };
            drpObject.Items.Insert(0, li);
        }
        public class Class
        {
            public string name { get; set; }
            public string Countryid { get; set; }
            public List<Class> listcontinent { get; set; }

            public List<Class> listcontinentupdate { get; set; }
        }

        public static string Encrypt(string text)
        {
            string key = "A!9HHhi%XjjYY4YP2@Nob009X";
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateEncryptor())
                    {
                        byte[] textBytes = UTF8Encoding.UTF8.GetBytes(text);
                        byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                        return Convert.ToBase64String(bytes, 0, bytes.Length);
                    }
                }
            }
        }

        public static string Decrypt(string cipher)
        {
            string key = "A!9HHhi%XjjYY4YP2@Nob009X";
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateDecryptor())
                    {
                        byte[] cipherBytes = Convert.FromBase64String(cipher);
                        byte[] bytes = transform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                        return UTF8Encoding.UTF8.GetString(bytes);
                    }
                }
            }
        }
    }
}