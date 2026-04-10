<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="date.aspx.cs" Inherits="RET.date" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="form-group">
                                                    
                                                    <div class='input-group date'  >
                                                        <input type="date" id='TxtArrivalDate1' style="width:265px;"  runat="server"  />
                                                        <span class="input-group-addon" style="display:none;">
                                                            <span class="glyphicon glyphicon-calendar"></span>
                                                        </span>
                                                    </div>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="TxtArrivalDate1" Display="None" ErrorMessage="Cargo --> Arrival Date is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                </div>
</asp:Content>
