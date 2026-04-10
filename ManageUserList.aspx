<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ManageUserList.aspx.cs" Inherits="RET.ManageUserList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script >
        function myFunction() {




            $("#ManageUser").css('color', 'White');
            debugger;
            $("#ManageUser").css('background-color', 'red');





        }


    </script>

    <div class="flex items-start flex-no-wrap">
        <div class="px-6 py-6 lg:max-w-[1150px] w-full mx-auto">
            <div class="flex gap-y-3 items-center justify-between flex-wrap">
               <div class="">
                 <h1 class="text-2xl sa700 leading-normal text-gray-800">
                   Manage Users
                 </h1>
               </div>
               <div class="flex items-center gap-3 flex-wrap">
                 <asp:Button ID="NewInvoice" runat="server" OnClick="NewInvoice_Click" CssClass="duration-300 group ease-in-out gap-3 md:w-[164px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" Text="Add New Record" />
               </div>
             </div>

            <div class="w-full bg-white my-shadow rounded-2xl px-6 py-5 mt-4">
                <div class="">       
                   <asp:GridView ID="GridView1" HeaderStyle-CssClass="w-full h-10 py-4 px-10 bg-[#F4F6FA] rounded-l-lg" PagerStyle-CssClass="pager" RowStyle-CssClass="rows" AllowPaging="true" DataKeyNames="Id" Font-Size="Small" ShowHeaderWhenEmpty="true" EmptyDataText="No Records found" PageSize="100" Width="100%" FooterStyle-CssClass="w-full h-10 py-4 px-10 bg-[#F4F6FA] rounded-lg" runat="server" AutoGenerateColumns="false" CssClass="w-full bg-white rounded whitespace-nowrap" RowStyle-Font-Bold="true" >

                                       <Columns>


                                           <asp:TemplateField HeaderText="ID" SortExpression="Id" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500  px-2 text-left pl-0">
                                               <ItemTemplate>
                                                   <p class="text-slate-500 text-xs font-medium py-3 md:px-0 px-2 rounded-l-lg">
                                                       <asp:Label ID="Id" runat="server" Text='<%#Eval("Id")%>'>
                                                       </asp:Label>
                                                   </p>
                                               </ItemTemplate>
                                           </asp:TemplateField>

             

                                           <asp:TemplateField HeaderText="User ID" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500  px-2 text-left pl-0" >
                                               <ItemTemplate>
                                                   <p class="text-slate-500 text-xs font-medium py-3 md:px-0 px-2 rounded-l-lg">
                                                       <asp:Label ID="LblUserId" runat="server"
                                                       Text='<%#Eval("UserId")%>'>
                                                       </asp:Label>
                                                   </p>
                                               </ItemTemplate>
                                           </asp:TemplateField>

                       <asp:TemplateField HeaderText="Account ID" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500  px-2 text-left pl-0"  >
                                       <ItemTemplate>
                                         <p class="text-slate-500 text-xs font-medium py-3 md:px-0 px-2 rounded-l-lg">
                                           <asp:Label ID="LblAccountId" runat="server"
                                           Text='<%#Eval("AccountId")%>'>
                                           </asp:Label>
                                         </p>
                                       </ItemTemplate>
                                       </asp:TemplateField>

                                           <asp:TemplateField HeaderText="User Name" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500  px-2 text-left pl-0" >
                                       <ItemTemplate>
                                         <p class="text-slate-500 text-xs font-medium py-3 md:px-0 px-2 rounded-l-lg">
                                           <asp:Label ID="LblUserName" runat="server"
                                               Text='<%#Eval("UserName")%>'>
                                               </asp:Label>
                                         </p>
                                       </ItemTemplate>
                                       </asp:TemplateField>


                                           <asp:TemplateField HeaderText="Department" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500  px-2 text-left pl-0" >
                                            <ItemTemplate>
                                              <p class="text-slate-500 text-xs font-medium py-3 md:px-0 px-2 rounded-l-lg">
                                                <asp:Label ID="LblDepartment" runat="server"
                                                    Text='<%#Eval("Department")%>'>
                                                    </asp:Label>
                                              </p>
                                            </ItemTemplate>
                                           </asp:TemplateField>

                                           <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500  px-2 text-left pl-0" >
                                             <ItemTemplate>
                                               <p class="text-slate-500 text-xs font-medium py-3 md:px-0 px-2 rounded-l-lg">
                                                 <asp:Label ID="LblStatus" runat="server"
                                                     Text='<%#Eval("Status")%>'>
                                                     </asp:Label>
                                               </p>
                                             </ItemTemplate>
                                            </asp:TemplateField>

                               
                                               <asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left pl-0">
                                                   <ItemTemplate>
                                                       <div class="flex gap-4 items-center pr-6 status-action">
                                                           <div class="relative">
                                                               <asp:ImageButton CssClass="hover-img" ImageUrl="images/blue-pencil.svg" Width="16" Height="16" OnClick="InpaymentEdit_Click" ID="InpaymentEdit" runat="server" />
                                                               <asp:ImageButton ImageUrl="images/pencil.svg" Width="16" Height="16" OnClick="InpaymentEdit_Click" ID="ImageButton1" runat="server" />
                                                           </div>
                                                           <div class="relative">
                                                               <asp:LinkButton CssClass="hover-img" OnClick="imgDelete_Click" data-target='<%#"#"+DataBinder.Eval(Container.DataItem,"Id")%>' Width="16" Height="16" ID="imgDelete" runat="server"><img src="images/red-bin.svg" /> </asp:LinkButton>
                                                               <asp:LinkButton OnClick="imgDelete_Click" data-target='<%#"#"+DataBinder.Eval(Container.DataItem,"Id")%>' Width="16" Height="16" ID="LinkButton1" runat="server"><img src="images/bin-gray.svg" /> </asp:LinkButton>
                                                           </div>

                                                       </div>
                                                   </ItemTemplate>
                                               </asp:TemplateField>

                                       </Columns>
                                   </asp:GridView>
       
                </div>
            </div>

        </div>
    </div>


    
</asp:Content>
