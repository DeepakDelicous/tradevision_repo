<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Changepassword.aspx.cs" Inherits="RET.Changepassword" %>
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
                Change Password
              </h1>
            </div>
          </div>
         <div class="w-full bg-white my-shadow rounded-2xl px-6 py-5 mt-4">
            
             <div class="mt-4 flex items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                
                 <div class="w-full">
                      <label class="text-gray-500 text-sm font-medium">TradeNet Mailbox ID</label>
                      <div class="relative mt-1">
                          <asp:TextBox ID="TxtMailBoxID" Enabled ="false" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="1" runat="server" ></asp:TextBox>
                      </div>
                  </div>

                 <div class="w-full">
                     <label class="text-gray-500 text-sm font-medium">Declarant Code</label>
                     <div class="relative mt-1">
                         <asp:TextBox ID="TxtDecCompCode" Enabled ="false" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="4" runat="server" ></asp:TextBox>
                     </div>
                 </div>             
             </div>

             <div class="mt-4 flex items-end gap-4 lg:flex-nowrap flex-wrap mb-2">

                  <div class="w-full">
                    <label class="text-gray-500 text-sm font-medium">Current Password</label>
                    <div class="relative mt-1">
                        <asp:TextBox ID="txtcurrentpassword" Enabled ="false" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="2" runat="server" ></asp:TextBox>
                    </div>
                  </div>

                 <div class="w-full">
                    <label class="text-gray-500 text-sm font-medium">New Password</label>
                    <div class="relative mt-1">
                        <asp:TextBox ID="txtnewpassword" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="5" runat="server" ></asp:TextBox>

                        <asp:Label ID="lblnewpwd" Visible ="false"  runat ="server" ></asp:Label>
                        <asp:Label ID="lblmsg" Visible ="false"  runat ="server" ></asp:Label>

                    </div>
                 </div>

             </div>

             <div class="row">
                <div class="col-sm-12">
                    <center>
                        <div id="Div1" runat="server" class="flex justify-between gap-4 md:flex-nowrap flex-wrap mt-6">
                            <asp:Button ID="BtnCancel" runat="server" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" Text="Cancel" TabIndex="22" />
                            <asp:Button ID="BtnSave" runat="server" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" ValidationGroup="ItemMasterValidation" OnClick="BtnSave_Click" Text="Submit" TabIndex="21" />
                        </div>
                    </center>
                </div>
            </div>


        </div>
         
         </div>

      </div>

</asp:Content>
