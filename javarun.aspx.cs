using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RET
{
    public partial class javarun : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblName.Text = Server.MapPath("itextsharp.dll");
           // lblName.Text = AppDomain.CurrentDomain.BaseDirectory.ToString();
            exce();
        }
        private void exce()
        {
            try
            {
                lblName.Text = @"C:\Users\THOMAS\Desktop\dist";
                //string command = "java -jar C:\\Users\\Administrator\\Desktop\\dist\\RetinalImage.jar";

                string command = "java -jar C:\\Users\\THOMAS\\Desktop\\dist\\RetinalImage.jar";

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
                lblName.Text = command;
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
            catch (Exception ex)
            {
                lblName.Text = ex.ToString();
            }
        }
    }
}