<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetMac.aspx.cs" Inherits="RET.GetMac" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <p>System Name</p>
    <asp:TextBox ID="txtsysname" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
   <br />
    <p>Mac Address</p>
    <asp:TextBox ID="txtmac" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
    <br />
    <asp:Button ID="btn" runat="server" OnClick="btn_Click" Text="Save" />
    </div>
    </form>
</body>
</html>
