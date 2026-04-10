<%@ Page Language="C#" EnableViewState="false" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RET.Login" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Kaizen Login</title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Inter:300,400,500,600,700" />
    <link rel="stylesheet" type="text/css" href="Login/css/newLogin.css" />
    <link rel="stylesheet" type="text/css" href="Login/css/plugins.bundle.css" />
    <style>
        body {
            background-image: url('Login/images/bg10.jpg');


        }
    </style>

    <script>
        var defaultThemeMode = "light";
        var themeMode;
        if (document.documentElement) {
            if (document.documentElement.hasAttribute("data-bs-theme-mode")) {
                themeMode = document.documentElement.getAttribute("data-bs-theme-mode");
            } else {
                if (localStorage.getItem("data-bs-theme") !== null) {
                    themeMode = localStorage.getItem("data-bs-theme");
                } else {
                    themeMode = defaultThemeMode;
                }
            }
            if (themeMode === "system") {
                themeMode = window.matchMedia("(prefers-color-scheme: dark)").matches ? "dark" : "light";
            }
            document.documentElement.setAttribute("data-bs-theme", themeMode);
        }
    </script>
</head>
<body id="kt_body" class="app-blank bgi-size-cover bgi-attachment-fixed bgi-position-center">
    <div class="d-flex flex-column flex-root" id="kt_app_root">
        <div class="d-flex flex-column flex-lg-row flex-column-fluid">
            <div class="d-flex flex-lg-row-fluid">
                <div class="d-flex flex-column flex-center pb-0 pb-lg-10 p-10 w-100">
                    <img class="theme-light-show mx-auto mw-100 w-150px w-lg-300px mb-10 mb-lg-20" 
                    src="Login/images/1711101675.jpg" alt="" />
                    <h1 class="text-gray-800 fs-2qx fw-bold text-center mb-7">  Kaizen Logistics </h1>
                    <div class="text-gray-600 fs-base text-center fw-semibold">                        
                            Kaizen Logistics Pte Ltd was officially incorporated in 2015 <br> as a logistics solutions provider for the aviation industry. <br>                        
                    </div>
                </div>
            </div> 
        
            <div class="d-flex flex-column-fluid flex-lg-row-auto justify-content-center justify-content-lg-end p-12">
            <div class="bg-body d-flex flex-column flex-center rounded-4 w-md-600px p-10">
                <div class="d-flex flex-center flex-column align-items-stretch h-lg-100 w-md-400px">
                    <div class="d-flex flex-center flex-column flex-column-fluid pb-15 pb-lg-20">
                        
                        <form class="form w-100" id="form1" runat="server">
                           <div class="text-center mb-11">
                                <h1 class="text-gray-900 fw-bolder mb-3">Sign In</h1>
                                <div class="text-gray-500 fw-semibold fs-6 pb-12">
                                    Kaizen Logistics
                                </div>
                               
                               <div class="fv-row mb-8 wrap-input100 validate-input">
                                   <asp:TextBox ID="Username" runat="server" class="form-control bg-transparent" placeholder="Username"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Username" CssClass="indexvalidation" ErrorMessage="Please Enter UserName1"
                                        Display="Dynamic" ValidationGroup="ItemMasterValidation" ForeColor="Red"></asp:RequiredFieldValidator>
                                    
                               </div>

                               <div class="fv-row mb-3 wrap-input100 validate-input" style="padding-bottom: 14px;">
                                    <asp:TextBox ID="Password" TextMode="Password" runat="server" class="form-control bg-transparent" placeholder="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Password" CssClass="indexvalidation" ErrorMessage="Please Enter PassWord"
                                        Display="Dynamic" ValidationGroup="ItemMasterValidation" ForeColor="Red"></asp:RequiredFieldValidator>
                                    
                               </div>

                               
                               <asp:Label ID="lbl_err" runat="server" ForeColor="Red" style="margin-bottom: 20px; display: block;"></asp:Label>

                               <asp:CheckBox ID="ChkLogin"  runat="server"  Text =" &nbsp;Click here If already Logged IN" />
                               

                               <div class="container-login100-form-btn d-grid mb-10" style="margin-top: 14px;">
                                    <asp:Button ID="btnLogin" class="btn btn-primary" runat="server" ValidationGroup="ItemMasterValidation" Text="Login" OnClick="btnLogin_Click" /> <br />
                                    
                                </div>

                           </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
        </div>
    </div>
</body>

</html>
