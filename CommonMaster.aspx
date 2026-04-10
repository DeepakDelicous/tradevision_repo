<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="CommonMaster.aspx.cs" Inherits="RET.CommonMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="flex md:justify-between items-center gap-4 mb-4 mt-6 md:flex-nowrap flex-wrap">
        <div class="flex gap-2 items-center">
            <p class="text-gray-500 text-sm font-medium">Admin</p>
            <svg width="8" height="12" viewBox="0 0 8 12" fill="none">
                <path d="M1.5 11L5.91075 6.58925C6.1885 6.3115 6.32742 6.17258 6.32742 6C6.32742 5.82742 6.1885 5.6885 5.91075 5.41075L1.5 1" stroke="#676D7C" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
            </svg>
            <p class="text-slate-950 text-sm sa700">Add Common Master</p>
        </div>
        <p class="text-center text-gray-500 text-xs font-medium">
            &nbsp;
        </p>
    </div>
     
    <div class="w-full bg-white my-shadow rounded-2xl px-6 py-6">
        <div class="flex justify-between gap-2 items-center mt-2">
            <h2 class="text-lg sa700 leading-[18px] text-gray-800">Add Common Master
            </h2>
        </div>


                <div class="row">
                    <div class="col-sm-6 col-md-6 col-lg-6  col-xs-8">
                    </div>
                    <div class="col-sm-6 col-md-6 col-lg-6 col-xs-12 add">
                        <div style="float: right">
                            
                        </div>

                    </div>
                </div>

                <form class="form-horizontal">
                    <div class="mt-4 flex items-end gap-4 lg:flex-nowrap flex-wrap mb-2 commonmaster">

                        <div class="w-full">
                            <label class="text-gray-500 text-sm font-medium">ID</label>
                            <div class="relative mt-1">
                                <asp:TextBox ID="txt_code" ReadOnly="true" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_code" ErrorMessage="Please Enter Code"
                                    Display="Dynamic" ValidationGroup="ItemMasterValidation" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="w-full">
                            <label class="text-gray-500 text-sm font-medium">Code</label>
                            <div class="relative mt-1">
                                <asp:TextBox ID="txt_name" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_name" ErrorMessage="Please Enter Name"
                                    Display="Dynamic" ValidationGroup="ItemMasterValidation" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="w-full">
                            <label class="text-gray-500 text-sm font-medium">Description</label>
                            <div class="relative mt-1">
                                <asp:TextBox ID="txt_des" runat="server" TextMode="MultiLine" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="mt-4 flex items-end gap-4 lg:flex-nowrap flex-wrap mb-2 commonmaster">
                        <div class="w-full">
                            <label class="text-gray-500 text-sm font-medium">Type</label>
                            <div class="relative mt-1">
                                <asp:DropDownList ID="drp_type" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" AppendDataBoundItems="true" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="drp_type" ErrorMessage="Please Select Type "
                                    Display="Dynamic" InitialValue="0" ValidationGroup="ItemMasterValidation" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="w-full">
                            <label class="text-gray-500 text-sm font-medium">Status</label>
                            <div class="relative mt-1">
                                <asp:DropDownList ID="drp_sts" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server">
                                    <asp:ListItem Text="---Select---" Value="0" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="InActive" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" InitialValue="0" ControlToValidate="drp_sts" ValidationGroup="ItemMasterValidation"
                                    Display="Dynamic" ErrorMessage="Please Select Status" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="w-full"></div>
                    </div>


                    <div class="row">
                        <div class="col-sm-12">
                            <center>
                                <div id="Div1" runat="server" class="flex justify-between gap-4 md:flex-nowrap flex-wrap mt-6">
                                    <asp:Button ID="btn_cancel" runat="server" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" OnClick="btn_cancel_Click" Text="Reset" TabIndex="22" />
                                    <asp:Button ID="btnSave" runat="server" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" ValidationGroup="ItemMasterValidation" OnClick="btnSave_Click" Text="Save" TabIndex="21" />
                                </div>
                            </center>
                        </div>
                    </div>

                </form>
            </div>

</asp:Content>
