<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ManageMailbox.aspx.cs" Inherits="RET.ManageMailbox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script >
         function myFunction() {
             $("#ManageTradeMailbox").css('color', 'White');
             debugger;
             $("#ManageTradeMailbox").css('background-color', 'red');
         }
    </script>

    <div class="flex items-start flex-no-wrap">
     <div class="px-6 py-6 lg:max-w-[1150px] w-full mx-auto">
         <div class="flex gap-y-3 items-center justify-between flex-wrap">
            <div class="">
              <h1 class="text-2xl sa700 leading-normal text-gray-800">
                Manage TradeNet Mailbox
              </h1>
            </div>
            <div class="flex items-center gap-3 flex-wrap">
              <button
                class="duration-300 group ease-in-out gap-3 md:w-[164px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700"
                >
                View All Records
              </button>
            </div>
          </div>
         <div class="w-full bg-white my-shadow rounded-2xl px-6 py-5 mt-4">
            
             <div class="mt-4 flex items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                
                 <div class="w-full">
                      <label class="text-gray-500 text-sm font-medium">TradeNet Mailbox ID</label>
                      <div class="relative mt-1">
                          <asp:TextBox ID="TxtMailBoxID" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="1" runat="server" ></asp:TextBox>
                      </div>
                  </div>

                 <div class="w-full">
                     <label class="text-gray-500 text-sm font-medium">Declarant Code</label>
                     <div class="relative mt-1">
                         <asp:TextBox ID="TxtDecCompCode" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="4" runat="server" ></asp:TextBox>
                     </div>
                 </div>

                 <div class="w-full">
                    <label class="text-gray-500 text-sm font-medium">Declarant Company Name</label>
                    <div class="relative mt-1">
                        <asp:TextBox ID="TxtDecCompName" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="7" runat="server" ></asp:TextBox>
                    </div>
                </div>
             
             </div>

             <div class="mt-4 flex items-end gap-4 lg:flex-nowrap flex-wrap mb-2">

                  <div class="w-full">
                    <label class="text-gray-500 text-sm font-medium">Current Password</label>
                    <div class="relative mt-1">
                        <asp:TextBox ID="TxtCurrentpwd" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="2" runat="server" ></asp:TextBox>
                    </div>
                  </div>

                 <div class="w-full">
                    <label class="text-gray-500 text-sm font-medium">Declarant Name</label>
                    <div class="relative mt-1">
                        <asp:TextBox ID="TxtDecName" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="5" runat="server" ></asp:TextBox>
                    </div>
                 </div>

                 <div class="w-full">
                   <label class="text-gray-500 text-sm font-medium">Declarant Telephone</label>
                   <div class="relative mt-1">
                       <asp:TextBox ID="TxtDecTel" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="8" runat="server" ></asp:TextBox>
                   </div>
                 </div>

             </div>

             <div class="mt-4 flex items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                 <div class="w-full">
                      <label class="text-gray-500 text-sm font-medium">TradeNet Account</label>
                      <div class="relative mt-1">
                          <asp:TextBox ID="TxttradeAcc" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="3" runat="server" ></asp:TextBox>
                      </div>
                  </div>

                 <div class="w-full">
                     <label class="text-gray-500 text-sm font-medium">Declarant Company UEI</label>
                     <div class="relative mt-1">
                         <asp:TextBox ID="TxtDecCompCRUEI" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="6" runat="server" ></asp:TextBox>
                     </div>
                 </div>

                 <div class="w-full">
                    <label class="text-gray-500 text-sm font-medium">Status</label>
                    <div class="relative mt-1">
                           <asp:DropDownList ID="DrpStatus" CssClass="drop w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"  TabIndex="13"  runat="server">
                                <asp:ListItem Text="--Select--" Value="--Select--"></asp:ListItem>
                                <asp:ListItem Text="Active" Value="Active" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Inactive" Value="Inactive" />
                            </asp:DropDownList> 
                    </div>
                </div>
             </div>

             <div class="mt-4 flex items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                 <div class="w-full">
                    <label class="text-gray-500 text-sm font-medium">Account ID</label>
                    <div class="relative mt-1">
                        <asp:DropDownList ID="DrpAccountId" CssClass="drop w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="14"  runat="server"></asp:DropDownList> 
                    </div>
                </div>
             </div>

             <div class="row">
                <div class="col-sm-12">
                    <center>
                        <div id="Div1" runat="server" class="flex justify-between gap-4 md:flex-nowrap flex-wrap mt-6">
                            <asp:Button ID="BtnCancel" runat="server" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" OnClick="BtnCancel_Click" Text="Reset" TabIndex="22" />
                            <asp:Button ID="BtnSave" runat="server" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" ValidationGroup="ItemMasterValidation" OnClick="BtnSave_Click" Text="Save" TabIndex="21" />
                        </div>
                    </center>
                </div>
            </div>


        </div>
         
         </div>

      </div>

</asp:Content>
