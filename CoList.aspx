<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" enableEventValidation="false" AutoEventWireup="true" CodeBehind="CoList.aspx.cs" Inherits="RET.CoList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/style.css?abc=1" rel="stylesheet" />

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <script>
        function myFunction() {

            $("#CO").css('color', 'White');
            debugger;
            $("#CO").css('background-color', 'Black');



            /*$("#useru").css('margin-top', '3px');*/
            $(function () {
                $('a[title]').tooltip();
            });


            function field() {
                $('#Fields').modal({ show: true });
            }


        }
    </script>
    <style type="text/css">
.overlay
{
position: fixed;
z-index: 999;
height: 100%;
width: 100%;
top: 0;
background-color: Black;
filter: alpha(opacity=60);
opacity: 0.6;
-moz-opacity: 0.8;
}
</style>
<script type="text/javascript">
    function showProgress() {
        var updateProgress = $get("<%= UpdateProgress.ClientID %>");
        updateProgress.style.display = "block";
    }
</script>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
<ProgressTemplate>
<div class="overlay">
<div style=" z-index: 1000; margin-top:300px; opacity: 1; -moz-opacity: 1;">
    <center>
<img alt="" src="Loader.gif" width="100" height="100" /></center>
</div>
</div>
</ProgressTemplate>

</asp:UpdateProgress>

<div class="modal fade" id="Error" role="dialog">
    <div class="modal-dialog">

        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title">Declarant Company Search
                </h4>
            </div>
            <div class="modal-body">
                <asp:Label Text="" ID="LblErr" runat="server" ForeColor="Red" />
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
            </div>
        </div>

    </div>
</div>

<div class="flex gap-y-3 items-center justify-between flex-wrap">

    <div>
        <h1 class="text-2xl sa700 leading-normal text-gray-800">Certificate of Origin
          </h1>
    </div>
    <div class="flex items-center gap-4 lg:flex-nowrap flex-wrap">

        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="Validation" />
        <a href="CO.aspx" id="Inpay" runat="server" class="hover:no-underline  w-full  md:w-[160px]">
            <button type="button" class="duration-300 group ease-in-out gap-3 md:w-[160px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm">+ New Declaration</button>
        </a>


        <asp:Button ID="PrintCCP" runat="server" Text="Print CCP" OnClick="PrintCCP_Click" class="duration-300 group ease-in-out gap-3 md:w-[160px] w-full bg-white text-gray-500 text-sm font-medium hover:bg-transparent border border-transparent hover:border hover:border-gray-200 h-10 flex items-center justify-center text-center rounded-md" style="display: none;" />


        <asp:Button ID="BtnCopyPermit" runat="server" Text="Copy to ReSubmit" OnClick="BtnCopyPermit_Click" class="duration-300 group ease-in-out gap-3 md:w-[160px] w-full bg-white text-gray-500 text-sm font-medium hover:bg-transparent border border-transparent hover:border hover:border-gray-200 h-10 flex items-center justify-center text-center rounded-md" />

        <asp:Button ID="BtnSaveFinal" runat="server" Text="Send / Receive" OnClick="BtnSaveFinal_Click" class="duration-300 group ease-in-out gap-3 md:w-[120px] w-full bg-white text-gray-500 text-sm font-medium hover:bg-transparent border border-transparent hover:border hover:border-gray-200 h-10 flex items-center justify-center text-center rounded-md" />

        <asp:Button ID="btndelete" OnClick="btndelete_Click" runat="server" Text="Delete" class="duration-300 group ease-in-out gap-3 md:w-20 w-full bg-white text-gray-500 text-sm font-medium hover:bg-transparent border border-transparent hover:border hover:border-gray-200 h-10 flex items-center justify-center text-center rounded-md" />

        <asp:Button ID="btndeleteAll" runat="server" Text="Delete All" class="duration-300 group ease-in-out gap-3 md:w-[120px] w-full bg-white text-gray-500 text-sm font-medium hover:bg-transparent border border-transparent hover:border hover:border-gray-200 h-10 flex items-center justify-center text-center rounded-md" style="display: none;" />

        <div class="group relative z-10">
            <button
                onclick="event.stopPropagation();showFilterDropDown('dropdown')"
                id="dropdownDividerButton"
                class="bg-white font-normal rounded-lg text-xs text-slate-400 p-2 text-left inline-flex items-center w-[140px] h-10"
                type="button">
                <img
                    src="images/filter.svg"
                    alt="Filter"
                    class="mr-2 ml-2" />
                <span id="setfilterText1">Filter</span>
                <svg
                    class="ml-auto w-4 h-4"
                    fill="none"
                    stroke="currentColor"
                    viewBox="0 0 24 24"
                    xmlns="http://www.w3.org/2000/svg">
                    <path
                        stroke-linecap="round"
                        stroke-linejoin="round"
                        stroke-width="2"
                        d="M19 9l-7 7-7-7">
                    </path>
                </svg>
            </button>
            <div id="dropdown" class="hidden relative drop-shadow">
                <div
                    class="bg-white w-5 h-5 rotate-45 absolute -top-1 rounded-sm drop-shadow right-2">
                </div>
                <div
                    class="z-10 w-[155px] text-base list-none bg-white shadow pt-3 pb-4 absolute top-[1px] right-0 rounded-xl">

                    <asp:Button ID="btnRejectSta" runat="server" Text="Rejected Status" class="w-full text-left py-2 px-6 text-sm text-gray-500 hover:text-[#0560FD] hover:font-medium hover:bg-[#0560FD] hover:bg-opacity-10 hover:rounded" />

                </div>
            </div>
        </div>

    </div>
</div>

<div class="w-full bg-white my-shadow rounded-2xl px-4 py-5 mt-5"  style="display: none;">
    <div class="overflow-auto my-shadow whitespace-nowrap amount_offer">
        <div class="table-responsive">
            <label class="text-gray-500 text-sm font-medium">Search By JobId</label>
            <asp:TextBox autocomplete="off" ID="txtJobId" OnTextChanged="txtJobId_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server" Style="width: 400px;" ></asp:TextBox>
        </div>
    </div>
</div>


<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
    <ContentTemplate>
        <div class="w-full bg-white my-shadow rounded-2xl px-4 py-5 mt-5">
            <div class="overflow-auto my-shadow whitespace-nowrap amount_offer">
                <div class="table-responsive">
                    <asp:GridView ID="GridInPayment" ShowHeaderWhenEmpty="true" EmptyDataText="No Records found" PageSize="10" Width="100%" FooterStyle-CssClass="w-full h-10 py-4 px-10 bg-[#F4F6FA] rounded-lg" CssClass="w-full bg-white rounded whitespace-nowrap" HeaderStyle-CssClass="w-full h-10 py-4 px-10 bg-[#F4F6FA] rounded-l-lg" PagerStyle-CssClass="pager" RowStyle-CssClass="rows" OnRowDeleting="GridInPayment_RowDeleting" AllowPaging="true" DataKeyNames="Id" OnPageIndexChanging="GridInPayment_PageIndexChanging" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowDataBound="GridInPayment_RowDataBound" OnRowCommand="GridInPayment_RowCommand" RowStyle-Font-Bold="true">
                        <PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last" />
                        <PagerStyle HorizontalAlign="left" CssClass="GridPager" />
                        <Columns>

                            <asp:TemplateField ItemStyle-CssClass="text-xs leading-none py-3 md:px-0 px-2 text-gray-800 w-5 relative" HeaderStyle-CssClass="font-medium leading-none md:px-0 px-2 rounded-l-lg text-base text-gray-600 text-left w-[20px]">
                                <HeaderTemplate>
                                    <div class="flex gap-4 items-center pl-6">
                                        <div class="custom-check">
                                        <span><input
                                            class="styled-checkbox-2"
                                            id="styled-checkbox-51"
                                            type="checkbox"
                                            value="value1" /></span>
                                        <label
                                            for="styled-checkbox-51"
                                            class="text-gray-500 text-sm">
                                        </label>
                                            </div>
                                    </div>
                                </HeaderTemplate>
                                <ItemTemplate>

                                    <div class="flex gap-4 items-center pl-6 relative">
                                
                                        <div class="custom-check">
                                        <span>
                                        <asp:CheckBox ID="CheckBox1" runat="server" />
                                            </span>
                                        <label for="CheckBox1" class="text-gray-500 text-sm"></label>
                                            </div>
                                    </div>


                                </ItemTemplate>
                            </asp:TemplateField>

    <asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left">
        <ItemTemplate>
            <div class="flex gap-4 items-center pr-6 status-action">
                <div class="relative">
                    <asp:ImageButton CssClass="hover-img" OnClientClick="return confirm('Are you sure you want to Edit this entry?');" ImageUrl="images/blue-pencil.svg" Width="16" Height="16" OnClick="InpaymentEdit_Click" ID="InpaymentEdit" runat="server" />
                    <asp:ImageButton ImageUrl="images/pencil.svg" OnClientClick="return confirm('Are you sure you want to Edit this entry?');" Width="16" Height="16" OnClick="InpaymentEdit_Click" ID="ImageButton1" runat="server" />
                </div>
                <div class="relative">
                    <asp:LinkButton CssClass="hover-img" OnClientClick="return confirm('Are you sure you want to delete this entry?');" OnClick="imgDelete_Click" data-target='<%#"#"+DataBinder.Eval(Container.DataItem,"Id")%>' Width="16" Height="16" ID="imgDelete" runat="server"><img src="images/red-bin.svg" /> </asp:LinkButton>

                    <asp:LinkButton OnClick="imgDelete_Click" OnClientClick="return confirm('Are you sure you want to delete this entry?');" data-target='<%#"#"+DataBinder.Eval(Container.DataItem,"Id")%>' Width="16" Height="16" ID="LinkButton1" runat="server"><img src="images/bin-gray.svg" /> </asp:LinkButton>
                </div>
                <div class="relative">
                    <asp:LinkButton CssClass="hover-img" OnClick="View_Click" data-target='<%#"#"+DataBinder.Eval(Container.DataItem,"Id")%>' Width="16" Height="16" ID="View" runat="server"><img src="images/eye-open.svg" /> </asp:LinkButton>
                    <asp:LinkButton OnClick="View_Click" data-target='<%#"#"+DataBinder.Eval(Container.DataItem,"Id")%>' Width="16" Height="16" ID="LinkButton3" runat="server"><img src="images/eye-open.svg" /> </asp:LinkButton>
                </div>
            </div>
        </ItemTemplate>
    </asp:TemplateField>



                            <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="false" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500  px-2 text-left">
                                <ItemTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 md:px-0 px-2 rounded-l-lg">
                                        <asp:Label ID="Id" runat="server" Text='<%#Eval("Id")%>'>
                                        </asp:Label>
                                    </p>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="JobId" SortExpression="JobId" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500  px-2 text-left">
                                <ItemTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 px-2">
                                        <asp:Label ID="lblJobId" runat="server" Text='<%#Eval("JobId")%>'>
                                        </asp:Label>
                                    </p>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 px-2">
                                        
                                    </p>
                                </FooterTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="MSGId" SortExpression="MSGId" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500  px-2 text-left">
                                <ItemTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 px-2">
                                        <asp:Label ID="lblMSGId" runat="server" Text='<%#Eval("MSGId")%>'>
                                        </asp:Label>
                                    </p>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 px-2" >
                                        <asp:TextBox  class="w-full h-10 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"  placeholder="Search"   ID="txtMSGId" runat="server" ForeColor="Black"  AutoPostBack="true" OnTextChanged="txtMSGId_TextChanged" Text='<%# Bind("MSGId") %>'>
                                        </asp:TextBox>
                                    </p>
                                </FooterTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="DecDate" SortExpression="DecDate" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500  px-2 text-left">
                                <ItemTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 px-2">
                                        <asp:Label ID="lblDecDate" Width="60" runat="server" Text='<%#Eval("DecDate")%>'>
                                        </asp:Label>
                                    </p>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 px-2" >
                                        <asp:TextBox  class="w-full h-10 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"  placeholder="Search"   ID="txtDecDate" runat="server" ForeColor="Black"  AutoPostBack="true" OnTextChanged="txtDecDate_TextChanged" Text='<%# Bind("DecDate") %>'>
                                        </asp:TextBox>
                                    </p>
                                </FooterTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="DeclarationType" SortExpression="DeclarationType" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left">
                                <ItemTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 px-2">
                                        <asp:Label ID="lblDeclarationType" runat="server" Text='<%#Eval("DeclarationType")%>'>
                                        </asp:Label>
                                    </p>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 px-2" >
                                        <asp:TextBox  placeholder="Search"  class="w-full h-10 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"   ID="txtDeclarationType" runat="server" ForeColor="Black"  AutoPostBack="true" OnTextChanged="txtDeclarationType_TextChanged" Text='<%# Bind("DeclarationType") %>'>
                                        </asp:TextBox>
                                    </p>
                                </FooterTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Createby" SortExpression="Createby" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left">
                                <ItemTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 px-2">
                                        <asp:Label ID="lblCreateby" runat="server" Text='<%#Eval("Createby")%>'>
                                        </asp:Label>
                                    </p>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 px-2" >
                                        <asp:TextBox placeholder="Search"   class="w-full h-10 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"   ID="txtCreateby" runat="server" ForeColor="Black"  AutoPostBack="true" OnTextChanged="txtCreateby_TextChanged" Text='<%# Bind("DeclarationType") %>'>
                                        </asp:TextBox>
                                    </p>
                                </FooterTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="DecId" SortExpression="DecId" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left">
                                <ItemTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 px-2">
                                        <asp:Label ID="lblDecId" runat="server" Text='<%#Eval("DecId")%>'>
                                        </asp:Label>
                                    </p>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 px-2" >
                                        <asp:TextBox  placeholder="Search"  class="w-full h-10 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"   ID="txtDecId" runat="server" ForeColor="Black"  AutoPostBack="true" OnTextChanged="txtDecId_TextChanged" Text='<%# Bind("DecId") %>'>
                                        </asp:TextBox>
                                    </p>
                                </FooterTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="ETD" SortExpression="ETD" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left">
                                <ItemTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 px-2">
                                        <asp:Label ID="lblETD" Width="60" runat="server" Text='<%#Eval("ETD")%>'>
                                        </asp:Label>
                                    </p>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 px-2" >
                                        <asp:TextBox  placeholder="Search"  class="w-full h-10 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"   ID="txtETD" runat="server" ForeColor="Black"  AutoPostBack="true" OnTextChanged="txtETD_TextChanged" Text='<%# Bind("ETD") %>'>
                                        </asp:TextBox>
                                    </p>
                                </FooterTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="LocalNo" SortExpression="LocalNo" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left">
                                <ItemTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 px-2">
                                        <asp:Label ID="lblPermitNo" runat="server" Text='<%#Eval("LocalNo")%>'>
                                        </asp:Label>
                                    </p>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 px-2" >
                                        <asp:TextBox placeholder="Search"   class="w-full h-10 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"   ID="txtLocalNo" runat="server" ForeColor="Black"  AutoPostBack="true" OnTextChanged="txtLocalNo_TextChanged" Text='<%# Bind("PermitNo") %>'>
                                        </asp:TextBox>
                                    </p>
                                </FooterTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="PermitNo" SortExpression="PermitNo" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left">

                                <ItemTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 px-2">
                                        <asp:Label ID="lblPermitNoOnline" runat="server" Text='<%#Eval("PermitNo")%>'>
                                        </asp:Label>
                                    </p>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 px-2" >
                                        <asp:TextBox  placeholder="Search"  class="w-full h-10 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"   ID="txtPermitNo" runat="server" ForeColor="Black"  AutoPostBack="true" OnTextChanged="txtPermitNo_TextChanged" Text='<%# Bind("PermitNumber") %>'>
                                        </asp:TextBox>
                                    </p>
                                </FooterTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="PreviousPermitNo" SortExpression="PreviousPermitNo" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left">
                                <ItemTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 px-2">
                                        <asp:Label ID="lblPreviousPermitNo" Width="260" runat="server" Text='<%#Eval("PreviousPermitNo")%>'>
                                        </asp:Label>
                                    </p>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 px-2" >
                                        <asp:TextBox  placeholder="Search"  class="w-full h-10 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"   ID="txtPreviousPermitNo" runat="server" ForeColor="Black"  AutoPostBack="true" OnTextChanged="txtPreviousPermitNo_TextChanged" Text='<%# Bind("PreviousPermitNo") %>'>
                                        </asp:TextBox>
                                    </p>
                                </FooterTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Exporter" SortExpression="Exporter" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left">
                                <ItemTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 px-2">
                                        <asp:Label ID="lblExporter" Width="260" runat="server" Text='<%#Eval("Exporter")%>'>
                                        </asp:Label>
                                    </p>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 px-2" >
                                        <asp:TextBox  placeholder="Search"  class="w-full h-10 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"   ID="txtExporter" runat="server" ForeColor="Black"  AutoPostBack="true" OnTextChanged="txtExporter_TextChanged" Text='<%# Bind("Exporter") %>'>
                                        </asp:TextBox>
                                    </p>
                                </FooterTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="InHAWBOBL" SortExpression="InHAWBOBL" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left">
                                <ItemTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 px-2">
                                        <asp:Label ID="lblInHAWBOBL" runat="server" Text='<%#Eval("InHAWBOBL")%>'>
                                        </asp:Label>
                                    </p>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 px-2" >
                                        <asp:TextBox  placeholder="Search"  class="w-full h-10 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"   ID="txtInHAWBOBL" runat="server" ForeColor="Black"  AutoPostBack="true" OnTextChanged="txtInHAWBOBL_TextChanged" Text='<%# Bind("InHAWBOBL") %>'>
                                        </asp:TextBox>
                                    </p>
                                </FooterTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="InHAWBOBL" SortExpression="MAWBOBL" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left">
                                <ItemTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 px-2">
                                        <asp:Label ID="lblMAWBOBL" runat="server" Text='<%#Eval("InHAWBOBL")%>'>
                                        </asp:Label>
                                    </p>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 px-2" >
                                        <asp:TextBox  placeholder="Search"  class="w-full h-10 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"   ID="txtMAWBOBL" runat="server" ForeColor="Black"  AutoPostBack="true" OnTextChanged="txtMAWBOBL_TextChanged" Text='<%# Bind("MAWBOBL") %>'>
                                        </asp:TextBox>
                                    </p>
                                </FooterTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="POD" SortExpression="LoadingPortCode" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left">

                                <ItemTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 px-2">
                                        <asp:Label ID="lblPOD" runat="server" Text='<%#Eval("POD")%>'>
                                        </asp:Label>
                                    </p>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 px-2" >
                                        <asp:TextBox  placeholder="Search"  class="w-full h-10 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"   ID="txtPOD" runat="server" ForeColor="Black"  AutoPostBack="true" OnTextChanged="txtPOD_TextChanged" Text='<%# Bind("POD") %>'>
                                        </asp:TextBox>
                                    </p>
                                </FooterTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="MessageType" SortExpression="MessageType" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left">
                                <ItemTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 px-2">
                                        <asp:Label ID="lblMessageType" runat="server" Text='<%#Eval("MessageType")%>'>
                                        </asp:Label>
                                    </p>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 px-2" >
                                        <asp:TextBox  placeholder="Search"  class="w-full h-10 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"   ID="txtMessageType" runat="server" ForeColor="Black"  AutoPostBack="true" OnTextChanged="txtMessageType_TextChanged" Text='<%# Bind("MessageType") %>'>
                                        </asp:TextBox>
                                    </p>
                                </FooterTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="OutwardTransportMode" SortExpression="OutwardTransportMode" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left">
                                <ItemTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 px-2">
                                        <asp:Label ID="lblOutwardTransportMode" runat="server" Text='<%#Eval("OutwardTransportMode")%>'>
                                        </asp:Label>
                                    </p>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 px-2" >
                                        <asp:TextBox  placeholder="Search"  class="w-full h-10 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"   ID="txtOutwardTransportMode" runat="server" ForeColor="Black"  AutoPostBack="true" OnTextChanged="txtOutwardTransportMode_TextChanged" Text='<%# Bind("InwardTransportMode") %>'>
                                        </asp:TextBox>
                                    </p>
                                </FooterTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="PreviousPermit" SortExpression="PreviousPermit" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left">
                                <ItemTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 px-2">
                                        <asp:Label ID="lblPreviousPermit" runat="server" Text='<%#Eval("PreviousPermitNo")%>'>
                                        </asp:Label>
                                    </p>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 px-2" >
                                        <asp:TextBox  placeholder="Search"  class="w-full h-10 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"   ID="txtPreviousPermit" runat="server" ForeColor="Black"  AutoPostBack="true" OnTextChanged="txtPreviousPermit_TextChanged" Text='<%# Bind("PreviousPermit") %>'>
                                        </asp:TextBox>
                                    </p>
                                </FooterTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="InternalRemarks" SortExpression="InternalRemarks" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left">
                                <ItemTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 px-2">
                                        <asp:Label ID="lblInternalRemarks" runat="server" Text='<%#Eval("InternalRemarks")%>'>
                                        </asp:Label>
                                    </p>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 px-2" >
                                        <asp:TextBox  placeholder="Search"  class="w-full h-10 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"   ID="txtInternalRemarks" runat="server" ForeColor="Black"  AutoPostBack="true" OnTextChanged="txtInternalRemarks_TextChanged" Text='<%# Bind("InternalRemarks") %>'>
                                        </asp:TextBox>
                                    </p>
                                </FooterTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="SumOFItem" SortExpression="SumOFItem" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left">
                                <ItemTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 px-2">
                                        <asp:Label ID="lblSumOFItem" runat="server" Text='<%#Eval("SumOFItem")%>'>
                                        </asp:Label>
                                    </p>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 px-2" >
                                        <asp:TextBox  placeholder="Search"  class="w-full h-10 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"   ID="txtSumOFItem" runat="server" ForeColor="Black"  AutoPostBack="true" OnTextChanged="txtSumOFItem_TextChanged" Text='<%# Bind("SumOFItem") %>'>
                                        </asp:TextBox>
                                    </p>
                                </FooterTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Status" SortExpression="Status" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left">
                                <ItemTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 px-2">
                                        <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status")%>'>
                                        </asp:Label>
                                    </p>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <p class="text-slate-500 text-xs font-medium py-3 px-2" >
                                        <asp:TextBox  placeholder="Search"  class="w-full h-10 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"   ID="txtStatus" runat="server" ForeColor="Black"  AutoPostBack="true" OnTextChanged="txtStatus_TextChanged" Text='<%# Bind("Status") %>'>
                                        </asp:TextBox>
                                    </p>
                                </FooterTemplate>
                            </asp:TemplateField>

                        

                        </Columns>
                    </asp:GridView>

                    <div id="PagerDiv" runat="server">
                        <!-- Pager controls will be added here -->
                    </div>
                </div>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>

<div
    class="flex md:justify-between justify-center gap-4 items-center mt-6">
        <div class="relative md:max-w-[150px] w-full">
            <button type="button"
                onclick="showcheckdropdown()"
                class="duration-300 ease-in-out gap-2 md:max-w-[150px] w-full bg-white border border-transparent hover:bg-transparent text-gray-500 hover:border hover:border-gray-200 h-10 flex items-center justify-center text-center rounded-md text-sm sa700">
                Show Columns
                <img src="images/arrow-down-01-sharp.svg" alt="Arrow" />
            </button>
            <!--  -->
            <div
                id="checkdrop"
                class="hidden z-10 w-[240px] text-base list-none bg-white drop-shadow px-3 py-4 absolute bottom-10 left-0 rounded-xl flex flex-col column-checkdrop overflow-auto max-h-[280px]">


                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                    <ContentTemplate>

                        <asp:CheckBoxList ID="CheckBoxList1" runat="server" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged" OnTextChanged="CheckBoxList1_TextChanged" AutoPostBack="True" CssClass="w-full"></asp:CheckBoxList>


                    </ContentTemplate>
                </asp:UpdatePanel>

 

            </div>
            <!--  -->
        </div>
        <!-- Pagination -->
        <div class="flex justify-center gap-2 hidden">
            <div
                class="w-8 h-8 flex rounded-md justify-center items-center bg-white">
                <svg
                    width="20"
                    height="20"
                    viewBox="0 0 20 20"
                    fill="none"
                    xmlns="http://www.w3.org/2000/svg">
                    <path
                        d="M12.4998 5L8.08903 9.41075C7.81125 9.6885 7.67236 9.82742 7.67236 10C7.67236 10.1726 7.81125 10.3115 8.08903 10.5892L12.4998 15"
                        stroke="#BCBCC4"
                        stroke-width="1.5"
                        stroke-linecap="round"
                        stroke-linejoin="round" />
                </svg>
            </div>
            <div
                class="w-8 h-8 flex rounded-md justify-center items-center text-white text-sm sa700 bg-[#0560FD]">
                1
            </div>
            <div
                class="w-8 h-8 flex rounded-md justify-center items-center text-gray-500 text-sm sa700 bg-white">
                2
            </div>
            <div
                class="w-8 h-8 flex rounded-md justify-center items-center text-gray-500 text-sm sa700 bg-white">
                3
            </div>
            <div
                class="w-8 h-8 flex rounded-md justify-center items-center bg-white">
                <svg
                    width="20"
                    height="20"
                    viewBox="0 0 20 20"
                    fill="none"
                    xmlns="http://www.w3.org/2000/svg">
                    <path
                        d="M7.5 15L11.9108 10.5892C12.1885 10.3115 12.3274 10.1726 12.3274 10C12.3274 9.82742 12.1885 9.6885 11.9108 9.41075L7.5 5"
                        stroke="#0560FD"
                        stroke-width="1.5"
                        stroke-linecap="round"
                        stroke-linejoin="round" />
                </svg>
            </div>
        </div>
        <!-- Pagination -->
    </div>

<script>
    function showcheckdropdown() {
        document.getElementById("checkdrop").classList.toggle("hidden");
    }
</script>

</asp:Content>
