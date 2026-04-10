<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="SequencePool.aspx.cs" Inherits="RET.SequencePool" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script >
         function myFunction() {
             $("#ManageSeqpool").css('color', 'White');
             debugger;
             $("#ManageSeqpool").css('background-color', 'red');
         }

    </script>

    <div class="flex items-start flex-no-wrap">
        <div class="px-6 lg:max-w-[1150px] w-full mx-auto">
            <div class="flex gap-y-3 items-center justify-between flex-wrap">
               <div class="">
                 <h1 class="text-2xl sa700 leading-normal text-gray-800">
                   Sequence Pool
                 </h1>
               </div>
             </div>
        </div>
    </div>

    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-6">
                <div class="w-full bg-white my-shadow rounded-2xl px-6 py-5 mt-4">
                    <asp:GridView ID="GridView1" HeaderStyle-CssClass="w-full h-10 py-4 px-10 bg-[#F4F6FA] rounded-l-lg" PagerStyle-CssClass="pager" RowStyle-CssClass="rows" AllowPaging="true" DataKeyNames="Id" Font-Size="Small" ShowHeaderWhenEmpty="true" EmptyDataText="No Records found" PageSize="10" Width="100%" FooterStyle-CssClass="w-full h-10 py-4 px-10 bg-[#F4F6FA] rounded-lg" runat="server" AutoGenerateColumns="false" CssClass="w-full bg-white rounded whitespace-nowrap" RowStyle-Font-Bold="true" >

                    <Columns>


                        <asp:TemplateField HeaderText="ID" SortExpression="Id" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500  px-2 text-left pl-0">
                            <ItemTemplate>
                                <p class="text-slate-500 text-xs font-medium py-3 md:px-0 px-2 rounded-l-lg">
                                    <asp:Label ID="Id" runat="server" Text='<%#Eval("Id")%>'>
                                    </asp:Label>
                                </p>
                            </ItemTemplate>
                        </asp:TemplateField>

      

                        <asp:TemplateField HeaderText="PoolID" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500  px-2 text-left pl-0" >
                            <ItemTemplate>
                                <p class="text-slate-500 text-xs font-medium py-3 md:px-0 px-2 rounded-l-lg">
                                    <asp:Label ID="LBLPoolID" runat="server"
                                    Text='<%#Eval("PoolID")%>'>
                                    </asp:Label>
                                </p>
                            </ItemTemplate>
                        </asp:TemplateField>

                    <asp:TemplateField HeaderText="Description" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500  px-2 text-left pl-0"  >
                    <ItemTemplate>
                      <p class="text-slate-500 text-xs font-medium py-3 md:px-0 px-2 rounded-l-lg">
                        <asp:Label ID="LBLDescription" runat="server"
                        Text='<%#Eval("Description")%>'>
                        </asp:Label>
                      </p>
                    </ItemTemplate>
                    </asp:TemplateField>

                        <asp:TemplateField HeaderText="StartSequence" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500  px-2 text-left pl-0" >
                    <ItemTemplate>
                      <p class="text-slate-500 text-xs font-medium py-3 md:px-0 px-2 rounded-l-lg">
                        <asp:Label ID="LBLStartSequence" runat="server"
                            Text='<%#Eval("StartSequence")%>'>
                            </asp:Label>
                      </p>
                    </ItemTemplate>
                    </asp:TemplateField>

                            <asp:TemplateField HeaderText="EndSequence" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500  px-2 text-left pl-0" >
                                <ItemTemplate>
                                  <p class="text-slate-500 text-xs font-medium py-3 md:px-0 px-2 rounded-l-lg">
                                    <asp:Label ID="LBLEndSequence" runat="server"
                                        Text='<%#Eval("EndSequence")%>'>
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

            <div class="col-sm-6">

                <div class="w-full bg-white my-shadow rounded-2xl px-6 py-5 mt-4">
                    <div class="mt-4 flex items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                        <div class="w-full">
                             <label class="text-gray-500 text-sm font-medium">Pool ID</label>
                             <div class="relative mt-1">
                                 <asp:TextBox ID="TxtPoolId" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="4" runat="server" ></asp:TextBox>
                             </div>
                         </div>
                    </div>
                    <div class="mt-4 flex items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                        <div class="w-full">
                            <label class="text-gray-500 text-sm font-medium">Description</label>
                            <div class="relative mt-1">
                                <asp:TextBox ID="TxtDes" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="4" runat="server" ></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="mt-4 flex items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                        <div class="w-full">
                            <label class="text-gray-500 text-sm font-medium">Start Sequence</label>
                            <div class="relative mt-1">
                                <asp:TextBox ID="TxtStartSeq" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="4" runat="server" ></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="mt-4 flex items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                        <div class="w-full">
                            <label class="text-gray-500 text-sm font-medium">End Sequence</label>
                            <div class="relative mt-1">
                                <asp:TextBox ID="TxtEndSeq" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="4" runat="server" ></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="mt-4 flex items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                        <div class="w-full">
                            <label class="text-gray-500 text-sm font-medium">Status</label>
                            <div class="relative mt-1">
                                  <asp:DropDownList ID="DrpStatus" CssClass="drop w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="13" runat="server">
                                   <asp:ListItem Text="--Select--" Value="--Select--"></asp:ListItem>
                                 <asp:ListItem Text="Active" Value="Active" Selected="True"></asp:ListItem>
                                  <asp:ListItem Text="Inactive" Value="Inactive" />
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                     <div class="row">
                        <div class="col-sm-12">
                            <center>
                                <div id="Div1" runat="server" class="flex justify-between gap-4 md:flex-nowrap flex-wrap mt-6">
                                    <asp:Button ID="BtnSave" runat="server" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" ValidationGroup="ItemMasterValidation" OnClick="BtnSave_Click" Text="Save" TabIndex="21" />
                                </div>
                            </center>
                        </div>
                    </div>
                </div>

                
            </div>
        </div>
    </div>

</asp:Content>
