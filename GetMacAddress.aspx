    <%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="GetMacAddress.aspx.cs" Inherits="RET.GetMacAddress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>System Name</p>
    <asp:TextBox ID="txtsysname" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
   <br />
    <p>Mac Address</p>
    <asp:TextBox ID="txtmac" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
    <br />
    <asp:Button ID="btn" runat="server" OnClick="btn_Click" Text="Save" />

</asp:Content>
