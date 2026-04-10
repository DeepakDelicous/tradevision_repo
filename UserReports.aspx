<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="UserReports.aspx.cs" Inherits="RET.UserReports" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <script >
         function myFunction() {

             $("#Reports").css('color', 'White');
             debugger;
             $("#Reports").css('background-color', 'red');
             
         }


    </script>
      <script type="text/javascript">
         function OnClientShown(sender, args) {
             sender._popupBehavior._element.style.zIndex = 10005;
         }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

        <div class="flex items-start flex-no-wrap">
             <div class="px-6 py-6 lg:max-w-[1150px] w-full mx-auto">
                 <div class="flex gap-y-3 items-center justify-between flex-wrap">
                    <div class="">
                      <h1 class="text-2xl sa700 leading-normal text-gray-800">
                        Reports - Search Filter
                      </h1>
                    </div>
                  </div>
                 <center> <asp:Label ID="LblErr" runat="server" ForeColor="Red"></asp:Label></center>
                 <div class="w-full bg-white my-shadow rounded-2xl px-6 py-5 mt-4">
                     <div class="mt-4 flex items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                        <div class="w-full">
                             <label class="text-gray-500 text-sm font-medium">From Date</label>
                             <div class="relative mt-1">
                                 <asp:TextBox ID="TxtFromDate" CssClass="drop w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="1" runat="server" ></asp:TextBox>
                                  <cc1:CalendarExtender CssClass="cal_Theme1" ID="CalendarExtender2" PopupButtonID="imgPopup" runat="server" TargetControlID="TxtFromDate" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"></cc1:CalendarExtender>
                                    <asp:RequiredFieldValidator  BackColor="Red" ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtFromDate"  ErrorMessage="Please Enter From Date" ValidationGroup="UserReport"></asp:RequiredFieldValidator>
                             </div>
                         </div>

                         <div class="w-full">
                             <label class="text-gray-500 text-sm font-medium">To Date</label>
                             <div class="relative mt-1">
                                 <asp:TextBox ID="TxtToDate" CssClass="drop w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="1" runat="server" ></asp:TextBox>
                                  <cc1:CalendarExtender CssClass="cal_Theme1" ID="CalendarExtender1" PopupButtonID="imgPopup" runat="server" TargetControlID="TxtToDate" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"></cc1:CalendarExtender>
                                    <asp:RequiredFieldValidator  BackColor="Red" ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtToDate"  ErrorMessage="Please Enter To Date" ValidationGroup="UserReport"></asp:RequiredFieldValidator>
                             </div>
                         </div>

                         <div class="w-full">
                            <label class="text-gray-500 text-sm font-medium">Reports</label>
                            <div class="relative mt-1">
                                <asp:DropDownList CssClass="drop w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"  Style="text-transform: uppercase" ID="DrpRepport"  AppendDataBoundItems="true" TabIndex="1" runat="server">
                                    <asp:ListItem Text="--Select--" Value="--Select--" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="AED Compliance Report (Monthly)" Value="AED Compliance Report (Monthly)" ></asp:ListItem>
                                    <asp:ListItem Text="Billing Report (Summary by Approved Date)" Value="Billing Report (Summary by Approved Date)" ></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator InitialValue="0" BackColor="Red" ID="RequiredFieldValidator7" runat="server" ControlToValidate="DrpRepport"  ErrorMessage="Please Choose Report" ValidationGroup="UserReport"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                     </div>

                      <div class="row">
                        <div class="col-sm-12">
                            <center>
                                <div id="Div1" runat="server" class="flex gap-4 md:flex-nowrap flex-wrap mt-6" >
                                    <asp:Button ID="BtnExcel" runat="server" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" OnClick="BtnExcel_Click" Text="Excel" TabIndex="22" />
                                    <asp:Button ID="BtnSave" runat="server" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" ValidationGroup="UserReport" OnClick="BtnSave_Click" Text="Save" TabIndex="21" />
                                </div>
                            </center>
                        </div>
                    </div>

                     <div class="table-responsive">
                         <asp:GridView ID="GridReport" HeaderStyle-CssClass="w-full h-10 py-4 px-10 bg-[#F4F6FA] rounded-l-lg"  ShowHeaderWhenEmpty="true" FooterStyle-CssClass="w-full h-10 py-4 px-10 bg-[#F4F6FA] rounded-lg" runat="server" CssClass="w-full bg-white rounded whitespace-nowrap" >
                               <EmptyDataTemplate>
                                   <div class="text-center">No record found</div>
                               </EmptyDataTemplate>
                        </asp:GridView>
                    </div>

                </div>
            </div>
        </div>

</asp:Content>
