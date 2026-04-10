<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="OutView.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="RET.OutView" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <link href="css/style.css" rel="stylesheet" />
    
        <style>
               .fancy .ajax__tab_header {
            font-size: 13px;
            font-weight: bold;
            color: #000000;
            font-family: sans-serif;
            background: url(img/blue_bg.jpg) repeat-x;
        }

            .fancy .ajax__tab_active .ajax__tab_outer,
            .fancy .ajax__tab_header .ajax__tab_outer,
            .fancy .ajax__tab_hover .ajax__tab_outer {
                height: 46px;
                background: url(img/blue_left.jpg) no-repeat left top;
            }

            .fancy .ajax__tab_active .ajax__tab_inner,
            .fancy .ajax__tab_header .ajax__tab_inner,
            .fancy .ajax__tab_hover .ajax__tab_inner {
                height: 46px;
                margin-left: 16px; /* offset the width of the left image */
                background: url(img/blue_right.jpg) no-repeat right top;
            }

            .fancy .ajax__tab_active .ajax__taUPLAOD DOCUMENTb_tab,
            .fancy .ajax__tab_hover .ajax__tab_tab,
            .fancy .ajax__tab_header .ajax__tab_tab {
                margin: 16px 16px 0px 0px;
            }

        .fancy .ajax__tab_hover .ajax__tab_tab,
        .fancy .ajax__tab_active .ajax__tab_tab {
            color: #cccccc;
        }

        .hserror {
            border: dotted;
            border-width: 0px;
            padding-left: 5px;
            padding-right: 5px;
        }

        .fancy .ajax__tab_body {
            font-family: verdana,tahoma,helvetica;
            font-size: 10pt;
            border: 1px solid #999999;
            border-top: 0;
            padding: 2px;
            background-color: #666666;
        }

        .Tab .ajax__tab_header {
            color: #ffffff;
            font-weight: bold;
            background-color: #FFFFFF;
            margin-left: 0px;
            height: 30px;
            /*border :inset 1px solid ;*/
            /*border-radius: 50px 20px;*/
            display: none;
        }
        /*Body*/

        /*Tab Active*/
        .Tab .ajax__tab_active .ajax__tab_tab {
            background-color: #fff;
            color: black;
            /*border: 1px solid #b4cbdf;*/
            /*border-radius: 50px 20px;*/
            border-bottom-width: 0px;
            height: 30px;
            padding-top: 5px;
            padding-left: 20px;
            padding-right: 20px;
            padding-bottom: 5px;
        }

        .Tab .ajax__tab_active .ajax__tab_inner {
            border-bottom-width: 0px;
        }



        .previous {
            background-color: #f1f1f1;
            color: black;
        }

        .next {
            background-color: #4CAF50;
            color: white;
        }

        .round {
            border-radius: 50%;
        }

        .Tab .ajax__tab_active .ajax__tab_outer {
       
            padding-left: 0px;
            margin-right: 0px;
            border: solid 1px red;
            border-spacing: 0px;
            border-radius: 10px 0px;
            border-bottom-width: 0px;
            height: 25px;
       
            padding-right: 0px;
        }
 
        .Tab .ajax__tab_hover .ajax__tab_tab {
            /*color: #4cff00;
            background: url("../../tab_hover.gif") repeat-x;
            height: 25px;*/
        }

        .Tab .ajax__tab_hover .ajax__tab_inner {
            /*color: #4682B4;
                      
            background: url("../../tab_left_hover.gif") no-repeat left;
            padding-left: 0px;*/
        }

        .Tab .ajax__tab_hover .ajax__tab_outer {
            /*color: #000000;
            /*background: url("../../tab_right_hover.gif") no-repeat right;*/
            /*padding-right: 0px;*/
        }
        /*Tab Inactive*/
        .Tab .ajax__tab_tab {
            margin-right: 0px;
            border: solid 1px #004080;
            border-spacing: 0px;
            border-radius: 10px 0px;
            border-bottom-width: 0px;
            background: #4158d0;
            color: white;
            height: 30px;
       
            padding-top: 5px;
            padding-left: 20px;
            padding-right: 20px;
            padding-bottom: 5px;
        }

        .Tab .ajax__tab_inner {
            color: #666666;
        
        }

        .Tab .ajax__tab_outer {
            color: #FFA500;
            padding-right: 0px;
            margin-right: 0px;
        }



        .ajax__calendar_container {
            z-index: 1000;
        }

        .drop {
            background: transparent;
        }


        .plusbtn {
            background-color: Transparent;
            background-repeat: no-repeat;
            border: none;
            cursor: pointer;
            overflow: hidden;
            font-size: 20px;
        }

        .upper-case {
            text-transform: uppercase;
        }

        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
        }

        .modalPopup {
            background-color: #FFFFFF;
            width: 800px;
            border: none;
            border-radius: 2px;
            padding: 0;
        }

            .modalPopup .header {
                background: white;
    line-height: 30px;
    text-align: left;
    font-weight: lighter;
    border-top-left-radius: 2px;
    border-top-right-radius: 2px;
    padding: 10px 15px;
    height: auto;
    font-size:16px;
            }

            .modalPopup .body {
                min-height: 50px;
                line-height: 30px;
                text-align: center;
                font-weight: bold;
            }

            .modalPopup .footer {
                padding: 6px 15px;
                border-top:1px solid #ddd;
            }

            .modalPopup .yes, .modalPopup .no {
                   color: White;
    text-align: center;
    font-weight: bold;
    cursor: pointer;
    border-radius: 4px;
    padding: 4px 16px;
            }

            .modalPopup .yes {
                background: #0560fd;
            }

            .modalPopup .no {
               background-color: rgb(241 245 249 / var(--tw-bg-opacity));
    color: rgb(107, 114, 128);
    border: 1px solid #ddd;
            }
            table tr td{
    text-align: left;
    padding: 5px;
}
table tr th{
    text-align: left;
    padding: 5px;
    color: rgb(107 114 128 / 1);
    font-weight: 500;
    text-align: left;
}
table tr td span{
    color: rgb(100 116 139 / 1);
    font-weight: 500;
    font-size: 0.75rem;
}
table tr:first-of-type {
    background-color: rgb(223, 227, 235);
    height: 2.5rem;
}
        @media screen and (min-width: 1280px) {
            .navigation-menu ~ div {
                margin-left: -100px !important;
            }
        }

        @media (min-width: 1536px) {
            .container {
                margin-left: 100px;
            }
        }

        .complete-stepper .bg-transparent div::after {
            background-color: rgb(5 96 253 / var(--tw-bg-opacity));
        }

        @media (min-width: 1024px) {
            .lg\:after\:w-\[120px\]::after {
                content: var(--tw-content);
                width: 120px;
            }
        }
        .complete-stepper .bg-transparent div::after {
            background-color: rgb(5 96 253 / var(--tw-bg-opacity)) !important;
        }
        .active-stepper .bg-transparent div::after {
            background: linear-gradient(90deg, #0560fd 4.47%, rgba(244, 246, 250, 0) 102%) !important;
        }

        input:not([type="checkbox"]):not([type="radio"]):not([type="submit"]):not([type="image"]), 
            optgroup, 
            select, 
            textarea {
                width: 100% !important;
                height: 2.5rem !important;
                border-radius: 0.375rem !important;
                background-color: rgb(241 245 249 / var(--tw-bg-opacity, 1)) !important;
                padding-left: 16px !important;
        }

        label{
            --tw-text-opacity: 1;
            color: rgb(107 114 128 / var(--tw-text-opacity, 1));
            font-weight: 500;
            font-size: 0.875rem;
            line-height: 1.25rem;
        }


    </style>

    <script>


        function noAlphabets(event) {
            var charCode = (event.which) ? event.which : event.keyCode
            if ((charCode >= 97) && (charCode <= 122) || (charCode >= 65) && (charCode <= 90))
                return false;

            return true;
        }

        function addCommas(clientID) {

            var nStr = document.getElementById(clientID.id).value;

            nStr += '';
            x = nStr.split('.');
            if (!x[0]) {
                x[0] = "0";

            }
            x1 = x[0];
            if (!x[1]) {
                x[1] = "00";
            }
            x2 = x.length > 1 ? '.' + x[1] : '';
            var rgx = /(\d+)(\d{3})/;
            while (rgx.test(x1)) {
                x1 = x1.replace(rgx, '$1' + ',' + '$2');
            }

            document.getElementById(clientID.id).value = x1 + x2;
            return true;
        }

        function removeCommas(clientID) {
            var nStr = document.getElementById(clientID.id).value;
            nStr = nStr.replace(/,/g, '');
            document.getElementById(clientID.id).value = nStr;

            $(clientID).select();

            return true;
        }
        // Except only numbers and dot (.) for salary textbox
        function onlyDotsAndNumbers(event) {
            var charCode = (event.which) ? event.which : event.keyCode
            if (charCode == 46) {
                return true;
            }
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
        //Except only numbers for Age textbox
        function onlyNumbers(event) {
            var charCode = (event.which) ? event.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }

        // No alphabets for Emp No textbox
        function noAlphabets(event) {
            var charCode = (event.which) ? event.which : event.keyCode
            if ((charCode >= 97) && (charCode <= 122) || (charCode >= 65) && (charCode <= 90))
                return false;

            return true;
        }


        function myFunction() {

            $("#Out").css('color', 'White');
            debugger;
            $("#Out").css('background-color', 'Black');

            /*$("#useru").css('margin-top', '3px');*/
            $(function () {
                $('a[title]').tooltip();
            });

        }


        //Validation Function

        function openTab(tabId) {
            var tabContainer = $find("<%= TabContainer1.ClientID %>");
            tabContainer.set_activeTabIndex(tabId - 1);
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
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="upout">
<ProgressTemplate>
<div class="overlay">
<div style=" z-index: 1000; margin-top:300px; opacity: 1; -moz-opacity: 1;">
    <center>
<img alt="" src="Loader.gif" width="100" height="100" /></center>
</div>
</div>
</ProgressTemplate>
</asp:UpdateProgress>
    <asp:UpdatePanel ID="upout" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <br />
            <div class="container">
             <div class="row top-pad" style="margin-top: -17px;">
              
                 <div class="col-md-12">
                       <div class="btn-group">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                        ShowSummary="False" ValidationGroup="Validation" />
                                    <asp:Button ValidationGroup="Validation" ID="BtnSaveDraft" class="btn1 " Visible="false" runat="server" OnClientClick="$('li:eq(2)', $('.nav-tabs')).tab('show')" OnClick="BtnSaveDraft_Click" Text="Save As Draft" />

                                   
                                    <asp:Button ID="BtnSaveFinal" runat="server" Visible="false" OnClick="BtnSaveFinal_Click" class="btn1" Text="Save As Final" />

                                    <button id="Button1" type="button" class="btn1 " runat="server" visible="false">Sent</button>
                                </div>
                               
                                <div class="btn-group">
                                    <button id="Button2" type="button" class="btn1 btn-primary" runat="server" visible="false">Load Data</button>


                                </div>
                              
                                <div class="btn-group pull-right">
                                   <asp:Button ID="BtnExit" runat="server" class="btn1 btn-danger" Visible="false" OnClick="BtnExit_Click" Text="Exit Form" />


                                </div>
                     </div>
            </div>
                </div><br /><br />
            <div class="container">
               
                <div class="row">
                    <div class="row">

                      

                        <div class="row">
                            <div class="col-md-12 col-lg-12 col-sm-12">
                              



                              
                                <cc1:ModalPopupExtender ID="POPUPERR" runat="server" PopupControlID="PanelErr" TargetControlID="BtnCls" 
                                                                                            OkControlID="BtnCls"  BackgroundCssClass="modalBackground">
                                                                                        </cc1:ModalPopupExtender>


  <asp:Panel ID="PanelErr" runat="server" CssClass="modalPopup" Style="display: none;">
<div class="header" >

</div>
<div class="body">     
      <asp:GridView ID="GridError" PageSize="5" AllowPaging="True"  OnPageIndexChanging="GridError_PageIndexChanging"  CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false" Visible="false">
                                                                                                   <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>
                                                                                                        
                                                                                                        <asp:TemplateField HeaderText="DocumentType" SortExpression="Id">
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblDocType" runat="server"
                                                                                                                    Text='<%# Container.DataItem %>'>
                                                                                                                </asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                      
                                                                                                    </Columns>


                                                                                                </asp:GridView>
</div>
<div class="footer" align="right">
                                                                                                <asp:Button ID="BtnCls" runat="server" Text="Close" CssClass="yes" />
                                                                                               
                                                                                            </div>

      </asp:Panel>
                            </div>
                        </div>
                      
                         <asp:Label ID="DECLARATIONURN" runat="server" Text="" ForeColor="Blue"></asp:Label>

                        <div class="w-full bg-white my-shadow rounded-2xl px-6 py-6">
                            <div class="flex w-full justify-center lg:gap-[93px] md:gap-6 gap-1">
                                <div class="flex flex-col justify-center items-center relative active-step" id="divHeader" runat="server" onclick="openTab(1)" style="cursor: pointer;" >
                                    <div class="text-center text-[#0560FD] md:text-base text-[10px] font-bold sa700 mb-2">
                                        Header
               
                                    </div>
                                    <div class="w-[14px] h-[14px] bg-transparent border-2 border-[#0560FD] rounded-full relative b-shadow">
                                        <div class="after:absolute lg:after:w-[128px] md:after:w-[60px] after:w-[20px] after:h-[2px] grads after:top-0 after:bottom-0 after:my-auto after:left-3"></div>
                                    </div>
                                </div>
                                <div class="flex flex-col justify-center items-center relative" id="divParty" runat="server" onclick="openTab(2)" style="cursor: pointer;" >
                                    <div class="text-center text-gray-500 md:text-base text-[10px] mb-2">
                                        Party
               
                                    </div>
                                    <div class="w-[14px] h-[14px] bg-transparent border-2 border-[#BCBCC3] rounded-full relative">
                                        <div class="after:absolute lg:after:w-[120px] md:after:w-[53px] after:w-[20px] after:h-[2px] after:bg-[#F4F6FA] after:top-0 after:bottom-0 after:my-auto after:left-3"></div>
                                    </div>
                                </div>
                                <div class="flex flex-col justify-center items-center relative" id="divCargo" runat="server" onclick="openTab(3)" style="cursor: pointer;" >
                                    <div class="text-center text-gray-500 md:text-base text-[10px] mb-2">
                                        Cargo
               
                                    </div>
                                    <div class="w-[14px] h-[14px] bg-transparent border-2 border-[#BCBCC3] rounded-full relative">
                                        <div class="after:absolute lg:after:w-[130px] md:after:w-[60px] after:w-[20px] after:h-[2px] after:bg-[#F4F6FA] after:top-0 after:bottom-0 after:my-auto after:left-3"></div>
                                    </div>
                                </div>
                                <div class="flex flex-col justify-center items-center relative" id="divInvoice" runat="server" onclick="openTab(4)" style="cursor: pointer;" >
                                    <div class="text-center text-gray-500 md:text-base text-[10px] mb-2">
                                        Invoice
               
                                    </div>
                                    <div class="w-[14px] h-[14px] bg-transparent border-2 border-[#BCBCC3] rounded-full relative">
                                        <div class="after:absolute lg:after:w-[120px] md:after:w-[53px] after:w-[20px] after:h-[2px] after:bg-[#F4F6FA] after:top-0 after:bottom-0 after:my-auto after:left-3"></div>
                                    </div>
                                </div>
                                <div class="flex flex-col justify-center items-center relative" id="divItem" runat="server" onclick="openTab(5)" style="cursor: pointer;" >
                                    <div class="text-center text-gray-500 md:text-base text-[10px] mb-2">
                                        Item
               
                                    </div>
                                    <div class="w-[14px] h-[14px] bg-transparent border-2 border-[#BCBCC3] rounded-full relative">
                                        <div class="after:absolute lg:after:w-[110px] md:after:w-[45px] after:w-[12px] after:h-[2px] after:bg-[#F4F6FA] after:top-0 after:bottom-0 after:my-auto after:left-3"></div>
                                    </div>
                                </div>
                                <div class="flex flex-col justify-center items-center relative" id="divCPC" runat="server" onclick="openTab(6)" style="cursor: pointer;" >
                                    <div class="text-center text-gray-500 md:text-base text-[10px] mb-2">
                                        CPC
               
                                    </div>
                                    <div class="w-[14px] h-[14px] bg-transparent border-2 border-[#BCBCC3] rounded-full relative">
                                        <div class="after:absolute lg:after:w-[130px] md:after:w-[65px] after:w-[23px] after:h-[2px] after:bg-[#F4F6FA] after:top-0 after:bottom-0 after:my-auto after:left-3"></div>
                                    </div>
                                </div>
                                <div class="flex flex-col justify-center items-center relative" id="divSummary" runat="server" onclick="openTab(7)" style="cursor: pointer;" > 
                                    <div class="text-center text-gray-500 md:text-base text-[10px] mb-2">
                                        Summary
               
                                    </div>
                                    <div class="w-[14px] h-[14px] bg-transparent border-2 border-[#BCBCC3] rounded-full relative"></div>
                                </div>
                            </div>
                                            <div class="board-inner">
                                                <div> 
                                                        <cc1:TabContainer ID="TabContainer1" AutoPostBack="true" runat="server" ActiveTabIndex="0" CssClass="Tab" OnActiveTabChanged="TabContainer1_ActiveTabChanged" OnLoad="TabContainer1_ActiveTabChanged" Style="margin-top: 50px;" >

                                                            <cc1:TabPanel ID="Header" CssClass="ajax__tab_header" runat="server" HeaderText="Header">
                                                                <ContentTemplate>
                                                                    <asp:UpdatePanel ID="outheader" UpdateMode="Conditional" runat="server">
                                                                        <ContentTemplate>
                                                                            <div class="row">
                                                                                <div class="col-sm-6">
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Message Type
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  ID="TxtMsgType" Text="OUTDEC" Enabled="false" runat="server"  type="text"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>


                                                                                    <div class="form-group row">

                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Declaration Type

                                                                    
                                                                                        </label>

                                                                                        <div class="col-sm-9">

                                                                                            <asp:DropDownList ID="DrpDecType" CssClass="drop"  OnSelectedIndexChanged="DrpDecType_SelectedIndexChanged" AutoPostBack="true" BackColor="#e8f0fe" Height="28" AppendDataBoundItems="true" TabIndex="1" runat="server">
                                                                                            </asp:DropDownList>

                                                                                            <asp:RequiredFieldValidator InitialValue="0" BackColor="Red" Width="265" ID="RequiredFieldValidator7" runat="server" ControlToValidate="DrpDecType" Display="None" ErrorMessage="Header --> Declaration Type is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>

                                                                                        </div>

                                                                                    </div>

                                                                                    <div class="form-group row">

                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Prev Permit No                                                                   
                                                                                        </label>

                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  ID="TxtPrevPerNO" runat="server"  type="text" TabIndex="2"></asp:TextBox>
                                                                                            
                                                                                        </div>
                                                                                    </div>

                                                                                    <div id="cargo" runat="server" class="form-group row">

                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Cargo Pack Type

                                                                   
                                                                                        </label>

                                                                                        <div class="col-sm-9">

                                                                                            <asp:DropDownList ID="DrpCargoPackType" CssClass="drop" BackColor="#e8f0fe"  Height="28" OnSelectedIndexChanged="DrpCargoPackType_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true" TabIndex="3" runat="server">
                                                                                            </asp:DropDownList>

                                                                                            <asp:RequiredFieldValidator BackColor="Red" InitialValue="0" ID="RequiredFieldValidator5" runat="server" ControlToValidate="DrpCargoPackType" Display="None" ErrorMessage="Header --> Cargo Pack Type is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>

                                                                                        </div>

                                                                                    </div>


                                                                                    <div id="Inward" runat="server" visible ="false" class="form-group row">

                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">

                                                                                            <p id="inwared" runat="server" style="margin-left: -0px;">Inward Trans Mode</p>


                                                                                        </label>

                                                                                        <div class="col-sm-9">

                                                                                            <asp:DropDownList ID="DrpInwardtrasMode" CssClass="drop"  OnSelectedIndexChanged="DrpInwardtrasMode_SelectedIndexChanged" AutoPostBack="true"  Height="28" AppendDataBoundItems="true" TabIndex="4" runat="server">
                                                                                            </asp:DropDownList>

                                                                                          <%--  <asp:RequiredFieldValidator BackColor="Red" InitialValue="0" ID="RequiredFieldValidator1" runat="server" ControlToValidate="DrpInwardtrasMode" Display="None" ErrorMessage="Header --> Inward Transport Mode is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>--%>

                                                                                        </div>

                                                                                    </div>

                                                                                    <div id="Outward" runat="server" class="form-group row">

                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">

                                                                                            <p id="P1" runat="server" style="margin-left: -0px;">Outward Trans Mode</p>


                                                                                        </label>

                                                                                        <div class="col-sm-9">

                                                                                            <asp:DropDownList ID="DrpOutwardtrasMode" CssClass="drop" BackColor="#e8f0fe" OnSelectedIndexChanged="DrpOutwardtrasMode_SelectedIndexChanged" AutoPostBack="true"  Height="28" AppendDataBoundItems="true" TabIndex="5" runat="server">
                                                                                            </asp:DropDownList>

                                                                                            <asp:RequiredFieldValidator BackColor="Red" InitialValue="0" ID="RequiredFieldValidator2" runat="server" ControlToValidate="DrpOutwardtrasMode" Display="None" ErrorMessage="Header --> Inward Transport Mode is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>

                                                                                        </div>

                                                                                    </div>

                                                                                    <div id="cotype" visible="false" runat="server" class="form-group row">

                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">

                                                                                            <p id="P2" runat="server" style="margin-left: -0px;">CO Type</p>


                                                                                        </label>

                                                                                        <div class="col-sm-9">

                                                                                            <asp:DropDownList CssClass="drop" ID="DrpCOType" AutoPostBack="true"  OnSelectedIndexChanged="DrpCOType_SelectedIndexChanged" Height="28" AppendDataBoundItems="true" TabIndex="6" runat="server">
                                                                                            </asp:DropDownList>

                                                                                            <asp:RequiredFieldValidator BackColor="Red" InitialValue="0" ID="RequiredFieldValidator28" runat="server" ControlToValidate="DrpOutwardtrasMode" Display="None" ErrorMessage="Header --> Inward Transport Mode is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>

                                                                                        </div>

                                                                                    </div>


                                                                                    <div class="form-group row">

                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            BG Indicator

    

                                                                    
                                                                                        </label>

                                                                                        <div class="col-sm-9">

                                                                                            <asp:DropDownList ID="DrpBGIndicator" CssClass="drop"  Height="28" AppendDataBoundItems="true" TabIndex="7" runat="server">
                                                                                            </asp:DropDownList>

                                                                                        </div>

                                                                                    </div>

                                                                                    <div class="form-group row">

                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            override Ex Rate

    

                                                                   
                                                                                        </label>

                                                                                        <div class="col-sm-9">

                                                                                            <asp:CheckBox ID="ChkOverrExgRate" Width="265" Enabled="false" runat="server" TabIndex="8" />

                                                                                        </div>

                                                                                    </div>

                                                                                    <div class="form-group row">

                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Supply indicator

    

                                                                   
                                                                                        </label>

                                                                                        <div class="col-sm-9">

                                                                                            <asp:CheckBox ID="ChkSupplyIndicator" Width="265" runat="server" TabIndex="9" />

                                                                                        </div>

                                                                                    </div>

                                                                                    <div class="form-group row">

                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Ref Document

    

                                                                   
                                                                                        </label>

                                                                                        <div class="col-sm-9">

                                                                                            <asp:CheckBox ID="ChkRefDoc" Width="265" OnCheckedChanged="ChkRefDoc_CheckedChanged" AppendDataBoundItems="true" AutoPostBack="true" runat="server" TabIndex="10" />

                                                                                        </div>

                                                                                    </div>

                                                                                </div>
                                                                                <div class="col-sm-6">
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">Mailbox ID</label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe" Text=""  type="text" ID="TxtTradeMailID"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TxtTradeMailID" Display="None" ErrorMessage="Header --> TradeNet Mailbox ID is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">Declarant Name</label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  ID="TxtDecName" BackColor="#e8f0fe" Text=""  runat="server" type="text"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtDecName" Display="None" ErrorMessage="Header --> Declarant Name is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator124" runat="server" Display="None" ControlToValidate="TxtDecName" ValidationExpression="[a-zA-Z ]*$" ErrorMessage="Enter a valid Name" ValidationGroup="Validation" />
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">Declaration Code</label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  ID="TxtDecCode" BackColor="#e8f0fe" Text=""  runat="server" type="text"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtDecCode" Display="None" ErrorMessage="Header --> Declarant  Code is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">Declarant Tel
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  ID="TxtDecTelephone" onkeypress="return onlyNumbers(event)" BackColor="#e8f0fe" Text=""  runat="server" type="text"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TxtDecTelephone" Display="None" ErrorMessage="Header --> Declarant  Telephone is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator ID="regPhone" runat="server" Display="None" ControlToValidate="TxtDecTelephone" ValidationExpression="[0-9]{10}" ErrorMessage="Enter a valid phone number" ValidationGroup="Validation" />
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">CR UEI No</label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  ID="TxtCRUEINO" BackColor="#e8f0fe" Text=""  runat="server" type="text"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TxtCRUEINO" Display="None" ErrorMessage="Header --> CR UEI No is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                        </div>
                                                                                    </div>

                                                                                    <%-- //ref doc--%>

                                                                                    <div class="row">
                                                                                        <div class="col-sm-12" id="Document" runat="server">
                                                                                            
                                                                                            <div class="row">
                                                                                                <div class="col-sm-12">
                                                                                                    <br />
                                                                                                    <div class="row Borderdiv" style="width: 100%">
                                                                                                        License
                                                                                                    </div>
                                                                                                    <br />
                                                                                                    <div class="row">
                                                                                                        <div class="col-sm-6">
                                                                                                            <asp:TextBox autocomplete="off"  ID="TxtLicense1" MaxLength="35" Width="265" runat="server" TabIndex="11" type="text"></asp:TextBox><br />
                                                                                                            <br />
                                                                                                            <asp:TextBox autocomplete="off"  ID="TxtLicense2" MaxLength="35" Width="265" runat="server" TabIndex="12" type="text"></asp:TextBox><br />
                                                                                                            <br />
                                                                                                            <asp:TextBox autocomplete="off"  ID="TxtLicense3" MaxLength="35" Width="265" runat="server" TabIndex="13" type="text"></asp:TextBox><br />
                                                                                                            <br />
                                                                                                        </div>
                                                                                                        <div class="col-sm-6">
                                                                                                            <asp:TextBox autocomplete="off"  ID="TxtLicense4" MaxLength="35" Width="265" runat="server" TabIndex="14" type="text"></asp:TextBox><br />
                                                                                                            <br />
                                                                                                            <asp:TextBox autocomplete="off"  ID="TxtLicense5" MaxLength="35" Width="265" runat="server" TabIndex="15" type="text"></asp:TextBox><br />
                                                                                                            <br />
                                                                                                        </div>
                                                                                                    </div>

                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="row">
                                                                                                  <asp:UpdatePanel ID ="updoc" runat ="server" UpdateMode ="Conditional"  >
                                                                                   <ContentTemplate>

                                                                                                <br />
                                                                                                <div class="col-sm-12">
                                                                                                    <div class="row Borderdiv" style="width: 100%">
                                                                                                        Attachment Document
                                                                                                    </div>

                                                                                                    <div class="row">
                                                                                                        <div class="col-sm-5">
                                                                                                            <p>Document Type</p>
                                                                                                            <asp:DropDownList ID="DrpDocType" CssClass="drop" BackColor="#e8f0fe" Width="200" Height="32" AppendDataBoundItems="true" TabIndex="16" runat="server">
                                                                                                            </asp:DropDownList><br />
                                                                                                           
                                                                                                        </div>
                                                                                                        <div class="col-sm-5">
                                                                                                            <p>Attachment</p>
                                                                                                            <asp:FileUpload ID="FileUpload1" BackColor="#e8f0fe" runat="server" TabIndex ="17" class="btn" AllowMultiple="true" />
                                                                                                            <asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator27" runat="server" ControlToValidate="FileUpload1" ErrorMessage="Header -->Upload Doc" ValidationGroup="Validationbtn"></asp:RequiredFieldValidator>
                                                                                                        </div>
                                                                                                        <div class="col-sm-2">
                                                                                                            <p>Upload</p>
                                                                                                            <asp:Button runat="server" ID="Btn_Upload" TabIndex ="18" ValidationGroup="Validationbtn" class="btn btn-success" Text="Upload" OnClick="Btn_Upload_Click" />

                                                                                                        </div>
                                                                                                    </div>


                                                                                                    <hr />
                                                                                                    <asp:GridView ID="GridView1" PageSize="5" OnRowDeleting="GridView1_RowDeleting" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                                                                       <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>
                                                                                                            <asp:TemplateField HeaderText="Delete">
                                                                                                                <ItemTemplate>

                                                                                                                    <asp:LinkButton data-target='<%#"#"+DataBinder.Eval(Container.DataItem,"Id")%>' Width="11" OnClick="imgDelete_Click" Height="11" ID="imgDelete" runat="server"><i class='fa fa-trash' style="color:red;"> </i></asp:LinkButton>



                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                            <asp:TemplateField HeaderText="DocumentType" SortExpression="Id">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:Label ID="lblDocType" runat="server"
                                                                                                                        Text='<%#Eval("DocumentType")%>'>
                                                                                                                    </asp:Label>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                            <asp:TemplateField HeaderText="Name" SortExpression="Id">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:Label ID="lblName" runat="server"
                                                                                                                        Text='<%#Eval("Name")%>'>
                                                                                                                    </asp:Label>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>


                                                                                                        </Columns>
                                                                                                    </asp:GridView>

                                                                                                    <br />
                                                                                                </div>
                                                                                       </ContentTemplate>
                                                                                                       <Triggers>
                                                                        <asp:PostBackTrigger ControlID="Btn_Upload" />
                                                                    </Triggers>
                                                                                                      </asp:UpdatePanel>
                                                                                            </div>

                                                                                        </div>

                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row" style="margin-left:100px;">
                                                                                <div class="row" visible="false" id="coo" runat="server">
                                                                                    <div class="col-sm-4">
                                                                                        <p>Entry year</p>
                                                                                        <asp:TextBox autocomplete="off"   ID="TxtEntryYear" runat="server" TabIndex="19" type="text"></asp:TextBox>
                                                                                        <br />
                                                                                        <p>GSP Donor Country</p>
                                                                                        <asp:DropDownList CssClass="drop" ID="DrpGPSCon" Height="28"  runat="server" TabIndex="20" AppendDataBoundItems="true"></asp:DropDownList>
                                                                                        <br />
                                                                                    </div>
                                                                                    <div class="col-sm-4">
                                                                                        <p>Certificate Detail #1 - Type</p>
                                                                                        <asp:DropDownList CssClass="drop" ID="DrpCerType1"  Height="28" runat="server" TabIndex="21" type="text"></asp:DropDownList>

                                                                                        <br />
                                                                                        <p>Certificate Detail #1 - Copies</p>
                                                                                        <asp:TextBox autocomplete="off" MaxLength="2"   ID="TxtCerCopies1"  Height="28" runat="server" TabIndex="22" type="text"></asp:TextBox>

                                                                                        <br />
                                                                                        <p>Certificate Detail #2 - Type</p>
                                                                                        <asp:DropDownList CssClass="drop" ID="DrpCerType2"  Height="28" runat="server" TabIndex="23" type="text"></asp:DropDownList>

                                                                                        <br />
                                                                                        <p>Certificate Detail #2 - Copies</p>
                                                                                        <asp:TextBox autocomplete="off" MaxLength="2"    ID="TxtCerCopies2" Height="28" runat="server" TabIndex="24" type="text"></asp:TextBox>

                                                                                        <br />
                                                                                        <p>Percentage of Commonwealth Content</p>
                                                                                        <asp:TextBox autocomplete="off"  ID="TxtPerCom"  Height="28" runat="server" TabIndex="25" type="text"></asp:TextBox>

                                                                                        <br />
                                                                                        <p>Currency Code</p>
                                                                                        <asp:DropDownList CssClass="drop"  ID="DrpCurnContry" Height="28" runat="server" TabIndex="26" type="text"></asp:DropDownList>

                                                                                        <br />
                                                                                    </div>
                                                                                    <div class="col-sm-4">
                                                                                        <p>Additional Certificate Details</p>
                                                                                        <asp:TextBox autocomplete="off"  ID="TxtACerDtl1" Width="265" Height="28" runat="server" AutoPostBack="true" TabIndex="27" type="text"></asp:TextBox>
                                                                                        <asp:TextBox autocomplete="off"  ID="TxtACerDtl2" Width="265" Height="28" runat="server" AutoPostBack="true" TabIndex="28" type="text"></asp:TextBox>
                                                                                        <asp:TextBox autocomplete="off"  ID="TxtACerDtl3" Width="265" Height="28" runat="server" AutoPostBack="true" TabIndex="29" type="text"></asp:TextBox>
                                                                                        <asp:TextBox autocomplete="off"  ID="TxtACerDtl4" Width="265" Height="28" runat="server" AutoPostBack="true" TabIndex="30" type="text"></asp:TextBox>
                                                                                        <asp:TextBox autocomplete="off"  ID="TxtACerDtl5" Width="265" Height="28" runat="server" AutoPostBack="true" TabIndex="31" type="text"></asp:TextBox><br />
                                                                                        <p>Transport Details</p>
                                                                                        <asp:TextBox autocomplete="off"  ID="TxtTrnDtl1" Width="265" Height="28" runat="server" AutoPostBack="true" TabIndex="32" type="text"></asp:TextBox>
                                                                                        <asp:TextBox autocomplete="off"  ID="TxtTrnDtl2" Width="265" Height="28" runat="server" AutoPostBack="true" TabIndex="33" type="text"></asp:TextBox>
                                                                                        <asp:TextBox autocomplete="off"  ID="TxtTrnDtl3" Width="265" Height="28" runat="server" AutoPostBack="true" TabIndex="34" type="text"></asp:TextBox>
                                                                                        <asp:TextBox autocomplete="off"  ID="TxtTrnDtl4" Width="265" Height="28" runat="server" AutoPostBack="true" TabIndex="35" type="text"></asp:TextBox>
                                                                                        <asp:TextBox autocomplete="off"  ID="TxtTrnDtl5" Width="265" Height="28" runat="server" AutoPostBack="true" TabIndex="36" type="text"></asp:TextBox>

                                                                                        <br />
                                                                                    </div>
                                                                                </div>
                                                                                <br />
                                                                                <br />
                                                                            </div>
                                                                            <%--</div>--%>
                                                                            <div class="col-sm-12">
                                                                                <form class="form" data-toggle="validator" action="##" method="post" id="registrationForm">

                                                                                    <asp:Label ID="txt_code" Visible="false" runat="server"></asp:Label>


                                                                                    <div class="row" id="addres" runat="server" visible="false">
                                                                                        <div class="col-sm-12">
                                                                                            <div class="row Borderdiv" style="width: 100%">
                                                                                                ADDITIONAL RECIPIENTS
                                                                                            </div>
                                                                                            <br />
                                                                                            <div class="row">
                                                                                                <div class="col-sm-4">
                                                                                                    <p>RECIPIENTS 1</p>
                                                                                                    <asp:TextBox autocomplete="off"  MaxLength="17"  ID="TxtRECPT1" Width="265" runat="server" TabIndex="37" type="text"></asp:TextBox>

                                                                                                    <br />
                                                                                                </div>
                                                                                                <div class="col-sm-4">
                                                                                                    <p>RECIPIENTS 2</p>
                                                                                                    <asp:TextBox autocomplete="off"  MaxLength="17"  ID="TxtRECPT2" Width="265" runat="server" TabIndex="38" type="text"></asp:TextBox>

                                                                                                    <br />
                                                                                                </div>
                                                                                                <div class="col-sm-4">
                                                                                                    <p>RECIPIENTS 3</p>
                                                                                                    <asp:TextBox autocomplete="off" MaxLength="17"   ID="TxtRECPT3" Width="265" runat="server" onkeypress="return isNumber(event)" TabIndex="39" type="text"></asp:TextBox>

                                                                                                    <br />
                                                                                                </div>
                                                                                            </div>
                                                                                            <br />
                                                                                            <br />
                                                                                        </div>
                                                                                    </div>

                                                                                </form>
                                                                            </div>


                                                                            <div class="row">
                                                                            <div class="col-sm-12">
                                                                             <center>  <h4 style="color:white;background-color:blue;">Permit Conditions</h4></center>
                                                                                 <div class="row">
                                                                            <div class="col-sm-4">
                                                                                <p style="font-weight :bold">Permit No : <asp:Label ID="LblPermitNo" runat="server" Text="PermitNo" ForeColor="Blue"></asp:Label> </p>
                                                                            </div>
                                                                            <div class="col-sm-4">
                                                                                         <p style="font-weight :bold">Validity Period : <asp:Label ID="LblValidPeriod" runat="server" Text="Validity Period " ForeColor="Blue"></asp:Label></p>
                                                                             </div>
                                                                             <div class="col-sm-4">
                                                                                         <p style="font-weight :bold">Permit Approved Date :<asp:Label ID="LblApprovedDate" runat="server" Text="Permit Approved Date" ForeColor="Blue"></asp:Label> </p>
                                                                             </div>
                                                                                     </div>
                                                                                </div>
                                                                            </div>
                                                                              <div class="row" >
                                                                            <div class="col-sm-12">
                                                                            
                                                                                 <div class="row">
                                                                            <div class="col-sm-4">
                                                                                <p style="font-weight :bold">JOB ID : <asp:Label ID="lbljobid" runat="server" Text="Jobid" ForeColor="Blue"></asp:Label> </p>
                                                                            </div>
                                                                            <div class="col-sm-4">
                                                                                         <p style="font-weight :bold">MSG ID: <asp:Label ID="lblmsgid" runat="server" Text="Validity Period " ForeColor="Blue"></asp:Label></p>
                                                                             </div>
                                                                             <div class="col-sm-4">
                                                                                         <p style="font-weight :bold">DEC DATE :<asp:Label ID="lbldecdate" runat="server" Text="Permit Approved Date" ForeColor="Blue"></asp:Label> </p>
                                                                             </div>
                                                                                     </div>
                                                                                </div>
                                                                            </div>
                                                                          <div class="row"   >
                                                                            <div class="col-sm-12">
                                                                            
                                                                                 <div class="row">
                                                                            <div class="col-sm-4">
                                                                                <p style="font-weight :bold">CREATE BY : <asp:Label ID="lblcreate" runat="server" Text="PermitNo" ForeColor="Blue"></asp:Label> </p>
                                                                            </div>
                                                                            <div class="col-sm-4">
                                                                                         <p style="font-weight :bold">STATUS: <asp:Label ID="lblstatus" runat="server" Text="Validity Period " ForeColor="Blue"></asp:Label></p>
                                                                             </div>
                                                                             <div class="col-sm-4">
                                                                                       
                                                                             </div>
                                                                                     </div>
                                                                                </div>
                                                                            </div>
                                                                        <div class="row">
                                                                            <div class="col-sm-12">
                                                                                  <hr />
                                                                                                <asp:GridView HeaderStyle-Font-Size="X-Small" ShowHeaderWhenEmpty="true"   EmptyDataText="No Records found" PageSize="10" ID="GridCondition" Width="100%" FooterStyle-CssClass="bg-primary text-white"  HeaderStyle-CssClass="bg-primary " RowStyle-CssClass="rows" Font-Bold ="true" PagerStyle-CssClass="pager"  AllowPaging="True" HeaderStyle-ForeColor="DarkBlue" OnPageIndexChanging="GridCondition_PageIndexChanging"  CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="true">
                                                                                                 
                                                                                                </asp:GridView>
                                                                            </div>
                                                                        </div>
                                                                 
                                                                            <div class="row">
    <div class="col-sm-12">
        <center>
            <div id="Div6" runat="server" class="flex justify-between gap-4 md:flex-nowrap flex-wrap mt-6">
                <asp:Button ID="btnoutsaveheader" runat="server" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" OnClick="btnoutsaveheader_Click" Text="Save" TabIndex="21" />
                <asp:Button ID="btnoutresetheader" runat="server" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" OnClick="btnoutresetheader_Click" Text="Reset" TabIndex="22" />
                <asp:Button ID="btnoutnextheader" runat="server" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" OnClick="btnoutnextheader_Click" Text="Next" TabIndex="23" />
            </div>
        </center>
    </div>
</div>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>

                                                                </ContentTemplate>
                                                            </cc1:TabPanel>
                                                            <%--  </div>--%>
                                                            <%-- </div>--%>
                                                            <%--header Old--%>

                                                            <%--  Party Old--%>

                                                            <%--<div role="tabpanel" class="tab-pane fade" id="Party"  >--%>

                                                            <cc1:TabPanel ID="Party" runat="server" CssClass="nn" HeaderText="Party">
                                                                <ContentTemplate>
                                                                    <asp:UpdatePanel ID="outparty" UpdateMode="Conditional" runat="server">
                                                                        <ContentTemplate>
                                                                            <div class="row">
                                                                                <div class="col-sm-4">
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-8 col-form-label">
                                                                                           <div class="row">
                                                                                        <div class="col-sm-8">
                                                                                            Declarant Company
                                                                                        </div>
                                                                                        <div class="col-sm-4">
                                                                                           <asp:ImageButton id="btnoutdec" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15"  Style="margin-top:-250px;" />
                                                                                             <asp:Button ID="DECPLUS" BackColor="Transparent" CssClass="plusbtn" BorderWidth="0px" runat="server" ValidationGroup="ItemMasterValidation1" OnClick="DECPLUS_Click" Text="+" />
                                                                                            </div>
                                                                                               </div>
                                                                                           
                                                                                            <cc1:ModalPopupExtender ID="popupoutdec" runat="server" PopupControlID="pnloutdec" TargetControlID="btnoutdec"
                                                                                                OkControlID="btnYesoutdec" CancelControlID="btnNooutdec" BackgroundCssClass="modalBackground">
                                                                                            </cc1:ModalPopupExtender>

                                                                                            <asp:Panel ID="pnloutdec" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                                <div class="header">
                                                                                                    Declarant Company
                                                                                                </div>
                                                                                                <div class="body">
                                                                                                    <asp:UpdatePanel ID="upoutdecgrid" runat="server" UpdateMode="Conditional">
                                                                                                        <ContentTemplate>
                                                                                                            <asp:TextBox autocomplete="off"  ID="DecSearch" OnTextChanged="DecSearch_TextChanged"  AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                            <br />
                                                                                                            <asp:GridView ID="DECCOMPSearGRID" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="DECCOMPSearGRID_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" OnRowCommand="DECCOMPSearGRID_RowCommand" OnRowDataBound="DECCOMPSearGRID_RowDataBound" runat="server" AutoGenerateColumns="false">
                                                                                                               <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>


                                                                                                                    <asp:TemplateField HeaderText="Code" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblCode" runat="server"
                                                                                                                                Text='<%#Eval("Code")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="Name" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblName" runat="server"
                                                                                                                                Text='<%#Eval("Name")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>

                                                                                                                    <asp:TemplateField HeaderText="Name1" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblName1" runat="server"
                                                                                                                                Text='<%#Eval("Name1")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="CRUEI" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblCRUEI" runat="server"
                                                                                                                                Text='<%#Eval("CRUEI")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField>
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:LinkButton ID="lnkRequestID" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="lnkRequestID_Command">Select </asp:LinkButton>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                </Columns>
                                                                                                            </asp:GridView>
                                                                                                        </ContentTemplate>
                                                                                                        <%--<Triggers>
<asp:PostBackTrigger ControlID="DECCOMPSearGRID" />
  </Triggers>--%>
                                                                                                    </asp:UpdatePanel>
                                                                                                </div>
                                                                                                <div class="footer" align="right">
                                                                                                    <asp:Button ID="btnYesoutdec" runat="server" Text="Yes" CssClass="yes" />
                                                                                                    <asp:Button ID="btnNooutdec" runat="server" Text="No" CssClass="no" />
                                                                                                </div>
                                                                                            </asp:Panel>
                                                                                           
                                                                                        </label>
                                                                                        <div class="col-sm-4">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Width="100" type="text" placeholder="Code" OnTextChanged="TxtDecCompCode_TextChanged" AutoPostBack="true" ID="TxtDecCompCode" TabIndex="43"></asp:TextBox>
                                                                                            <cc1:AutoCompleteExtender ServiceMethod="GetListofCountries"
                                                                                                MinimumPrefixLength="1"
                                                                                                CompletionInterval="100"
                                                                                                CompletionListCssClass="ac_results" EnableCaching="false" CompletionSetCount="10"
                                                                                                TargetControlID="TxtDecCompCode"
                                                                                                ID="AutoCompleteExtender1" runat="server" CompletionListItemCssClass="listItem"  CompletionListHighlightedItemCssClass="itemHighlighted"   FirstRowSelected="true">
                                                                                            </cc1:AutoCompleteExtender>
                                                                                        </div>
                                                                                    </div>

                                                                                </div>
                                                                                <div class="col-sm-2">
                                                                                    <div class="form-group row">

                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="TxtDecCompCRUEI" Width="170" runat="server" placeholder="Cruei" BackColor="#e8f0fe" TabIndex="44" ValidationGroup="Validation" type="text"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="TxtDecCompCRUEI" Display="None" ErrorMessage="Party --> Declarant Company CR UEI is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator64" runat="server" ControlToValidate="TxtDecCompCRUEI" Display="None" ErrorMessage="Party --> Declarant Company CR UEI is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtDecCompCRUEI" ID="RegularExpressionValidator37" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator><br />

                                                                                        </div>
                                                                                    </div>

                                                                                </div>
                                                                                <div class="col-sm-3">
                                                                                    <div class="form-group row">

                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="TxtDecCompName" Width="275" runat="server" placeholder="Name" BackColor="#e8f0fe" TabIndex="45" ValidationGroup="Validation" type="text"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TxtDecCompName" Display="None" ErrorMessage="Party --> Declarant Company Name is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                            <br />
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtDecCompName" ID="RegularExpressionValidator18" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                    </div>

                                                                                </div>
                                                                                <div class="col-sm-3">
                                                                                    <div class="form-group row">

                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="TxtDecCompName1" Width="275" runat="server" TabIndex="46" placeholder="Name1" ValidationGroup="Validation" type="text"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtDecCompName1" ID="RegularExpressionValidator19" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                    </div>

                                                                                </div>
                                                                            </div>



                                                                            <div class="row">
                                                                                <div class="col-sm-4">
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-8 col-form-label">
                                                                                             <div class="row">
                                                                                        <div class="col-sm-8">
                                                                                            Exporter
                                                                                        </div>
                                                                                        <div class="col-sm-4">
                                                                                             <asp:ImageButton id="btnoutexp" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15"  Style="margin-top:-250px;" />
                                                                                               <asp:Button ID="BtnExpAdd" BackColor="Transparent" CssClass="plusbtn" BorderWidth="0px" runat="server" ValidationGroup="Importer" OnClick="BtnExpAdd_Click" Text="+" />
                                                                                            </div>
                                                                                                 </div>
                                                                                            
                                                                                            
                                                                                            <cc1:ModalPopupExtender ID="popupoutexp" runat="server" PopupControlID="pnloutexp" TargetControlID="btnoutexp"
                                                                                                OkControlID="btnYesoutexp" CancelControlID="btnNooutexp" BackgroundCssClass="modalBackground">
                                                                                            </cc1:ModalPopupExtender>

                                                                                            <asp:Panel ID="pnloutexp" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                                <div class="header">
                                                                                                    Exporter
                                                                                                </div>
                                                                                                <div class="body">
                                                                                                    <asp:UpdatePanel ID="upoutexpgrid" runat="server" UpdateMode="Conditional">
                                                                                                        <ContentTemplate>
                                                                                                            <asp:TextBox autocomplete="off"  ID="ExporterSearch" OnTextChanged="ExporterSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                            <br />
                                                                                                            <asp:GridView ID="ExporterGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ExporterGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" OnRowCommand="ExporterGrid_RowCommand" OnRowDataBound="ExporterGrid_RowDataBound" runat="server" AutoGenerateColumns="false">
                                                                                                                <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>
                                                                                                                    <asp:TemplateField HeaderText="Name" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="Code" runat="server"
                                                                                                                                Text='<%#Eval("OutUserCode")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="Name" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblOutUserName" runat="server"
                                                                                                                                Text='<%#Eval("OutUserName")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>


                                                                                                                    <asp:TemplateField HeaderText="Name1" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblOutUserName1" runat="server"
                                                                                                                                Text='<%#Eval("OutUserName1")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>

                                                                                                                    <asp:TemplateField HeaderText="CRUEI" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblOutUserCRUEI" runat="server"
                                                                                                                                Text='<%#Eval("OutUserCRUEI")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="Address" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="LblOutUserAddress" runat="server"
                                                                                                                                Text='<%#Eval("OutUserAddress")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="Address1" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="LblOutUserAddress1" runat="server"
                                                                                                                                Text='<%#Eval("OutUserAddress1")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="City" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="LblOutUserCity" runat="server"
                                                                                                                                Text='<%#Eval("OutUserCity")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                  <asp:TemplateField HeaderText="Sub Contry Code" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="LblOutUserSubCode" runat="server"
                                                                                                                                Text='<%#Eval("OutUserSubCode")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="Sub Contry" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="LblOutUserSub" runat="server"
                                                                                                                                Text='<%#Eval("OutUserSub")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="City" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="LblOutUserPostal" runat="server"
                                                                                                                                Text='<%#Eval("OutUserPostal")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="City" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="LblOutUserCountry" runat="server"
                                                                                                                                Text='<%#Eval("OutUserCountry")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                   <asp:TemplateField>
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:LinkButton ID="LnkExporter" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkExporter_Command">Select </asp:LinkButton>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                </Columns>
                                                                                                                    
                                                                                                               
                                                                                                            </asp:GridView>
                                                                                                        </ContentTemplate>
                                                                                                        <%--<Triggers>
<asp:PostBackTrigger ControlID="ExporterGrid" />
  </Triggers>--%>
                                                                                                    </asp:UpdatePanel>
                                                                                                </div>
                                                                                                <div class="footer" align="right">
                                                                                                    <asp:Button ID="btnYesoutexp" runat="server" Text="Yes" CssClass="yes" />
                                                                                                    <asp:Button ID="btnNooutexp" runat="server" Text="No" CssClass="no" />
                                                                                                </div>
                                                                                            </asp:Panel>
                                                                                            <%-- <i class='fa fa-search' data-toggle="modal" data-target="#EXPORTER"></i>--%>

                                                                                            <%--  <asp:UpdatePanel ID="UpdatePanel2" runat="server">

                                                       
                                                           
                                          <ContentTemplate>--%>
                                                                                         

                                                                                        </label>
                                                                                        <div class="col-sm-4">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Width="100" type="text" ID="TxtExpCode" placeholder="Code" OnTextChanged="TxtExpCode_TextChanged" AutoPostBack="true" TabIndex="47"></asp:TextBox>
                                                                                            <cc1:AutoCompleteExtender ServiceMethod="GetExpcode"
                                                                                                MinimumPrefixLength="1"
                                                                                                CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem"  CompletionListHighlightedItemCssClass="itemHighlighted"  EnableCaching="false" CompletionSetCount="10"
                                                                                                TargetControlID="TxtExpCode"
                                                                                                ID="AutoCompleteExtender3" runat="server" FirstRowSelected="true">
                                                                                            </cc1:AutoCompleteExtender>
                                                                                        </div>
                                                                                    </div>

                                                                                </div>
                                                                                <div class="col-sm-2">
                                                                                    <div class="form-group row">

                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="TxtExpCRUEI" Width="170" runat="server" ValidationGroup="PartyExp" placeholder="Cruei" BackColor="#e8f0fe" TabIndex="48" type="text"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="TxtDecCompCRUEI" Display="None" ErrorMessage="Exporter --> Importer CRUEI is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtExpCRUEI" ID="RegularExpressionValidator2" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="PartyExp"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                           <br />
                                                                                        <br />
                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="TxtEXPAddress" Width="170" runat="server" placeholder="Address" ValidationGroup="Enduser" TabIndex="51" type="text"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtEXPAddress" ID="RegularExpressionValidator119" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35characters allowed." ValidationGroup="Enduser"></asp:RegularExpressionValidator><br />
                                                                                        </div>
                                                                                        <br />
                                                                                        <br />
                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="TxtExpSubCode" Width="170" runat="server" placeholder="Sub Code" ValidationGroup="Enduser" TabIndex="54" type="text"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtExpSubCode" ID="RegularExpressionValidator123" ValidationExpression="^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="Enduser"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                        <br />
                                                                                        <br />
                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="TxtExpPostal" Width="170" runat="server" placeholder="Postal Code" ValidationGroup="Enduser" TabIndex="57" type="text"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtExpPostal" ID="RegularExpressionValidator128" ValidationExpression="^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="Enduser"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                    </div>

                                                                                </div>
                                                                                <div class="col-sm-3">
                                                                                    <div class="form-group row">

                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="TxtExpName" Width="275" runat="server" ValidationGroup="PartyExp" placeholder="Name" BackColor="#e8f0fe" TabIndex="49" type="text"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ControlToValidate="TxtDecCompCRUEI" Display="None" ErrorMessage="Party --> Exporter Name is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtExpName" ID="RegularExpressionValidator6" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="PartyExp"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                         <br />
                                                                                        <br />
                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="TxtEXPAddress1" Width="275" runat="server" ValidationGroup="Enduser" placeholder="Address1" TabIndex="52" type="text"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtEXPAddress1" ID="RegularExpressionValidator127" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Enduser"></asp:RegularExpressionValidator>
                                                                                        </div>

                                                                                       
                                                                                          <br />
                                                                                        <br />
                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="TxtExpSubDivision" Width="275" runat="server" placeholder="Sub division" TabIndex="55" type="text"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtExpSubDivision" ID="RegularExpressionValidator126" ValidationExpression="^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="Enduser"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                       
                                                                                    </div>

                                                                                </div>
                                                                                <div class="col-sm-3">
                                                                                    <div class="form-group row">

                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="TxtExpName1" Width="275" runat="server" ValidationGroup="PartyExp" TabIndex="50" placeholder="Name1" type="text"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtExpName1" ID="RegularExpressionValidator1" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="PartyExp"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                         <br />
                                                                                        <br />
                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="TxtEXPCity" Width="275" runat="server"  placeholder="City" TabIndex="53" type="text"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtEXPCity" ID="RegularExpressionValidator134" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Enduser"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                        <br />
                                                                                        <br />
                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="TxtExpCountry" Width="275" BackColor="#e8f0fe" runat="server" placeholder="Country" TabIndex="56" type="text"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserCountry" ID="RegularExpressionValidator135" ValidationExpression="^[\s\S]{0,2}$" runat="server" ErrorMessage="Maximum 2 characters allowed." ValidationGroup="Enduser"></asp:RegularExpressionValidator><br />
                                                                                        </div>
                                                                                    </div>

                                                                                </div>
                                                                            </div>

                                                                             <div class="row" id="outimp" runat="server" visible ="false" >
                                                                            <div class="col-sm-4">
                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail" class="col-sm-8 col-form-label">

                                                                                        <div class="row">
                                                                                            <div class="col-sm-8">
                                                                                                Importer
                                                                                            </div>
                                                                                            <div class="col-sm-4">

                                                                                                <asp:ImageButton ID="btnimp1" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />

                                                                                                <asp:Button ID="BtnImpADD" CssClass="plusbtn" BackColor="Transparent" BorderWidth="0px" Font-Size="Small" runat="server" ValidationGroup="importer" OnClick="BtnImpADD_Click" Text="+" />
                                                                                            </div>
                                                                                        </div>





                                                                                        <cc1:ModalPopupExtender ID="popupimp" runat="server" PopupControlID="pnlimp" TargetControlID="btnimp1"
                                                                                            OkControlID="btnyesimp" CancelControlID="btnnoimp" BackgroundCssClass="modalBackground">
                                                                                        </cc1:ModalPopupExtender>
                                                                                        <asp:Panel ID="pnlimp" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                            <div class="header">
                                                                                                IMPORTER
                                                                                            </div>
                                                                                            <div class="body">

                                                                                                <asp:UpdatePanel ID="upimpgrid" runat="server" UpdateMode="Conditional">
                                                                                                    <ContentTemplate>


                                                                                                        <asp:TextBox autocomplete="off"  ID="ImporterSearch" OnTextChanged="ImporterSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                        <br />


                                                                                                        <asp:GridView ID="ImporterGrid" PageSize="5" OnRowDataBound="ImporterGrid_RowDataBound" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ImporterGrid_PageIndexChanging" OnSelectedIndexChanged="ImporterGrid_SelectedIndexChanged" OnRowCreated="ImporterGrid_RowCreated" CssClass="table table-striped table-bordered table-hover" runat="server" OnRowCommand="ImporterGrid_RowCommand" AutoGenerateColumns="false">
                                                                                                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                            <Columns>


                                                                                                                <asp:TemplateField HeaderText="DocumentType" SortExpression="Id">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblCode" runat="server"
                                                                                                                            Text='<%#Eval("Code")%>'>
                                                                                                                        </asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Name" SortExpression="Id">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblName" runat="server"
                                                                                                                            Text='<%#Eval("Name")%>'>
                                                                                                                        </asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>

                                                                                                                <asp:TemplateField HeaderText="Name1" SortExpression="Id">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblName1" runat="server"
                                                                                                                            Text='<%#Eval("Name1")%>'>
                                                                                                                        </asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="CRUEI" SortExpression="Id">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblCRUEI" runat="server"
                                                                                                                            Text='<%#Eval("CRUEI")%>'>
                                                                                                                        </asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField>

                                                                                                                    <ItemTemplate>
                                                                                                                        <%--  <asp:UpdatePanel ID="UpdatePanelImporterSearch" runat="server" ChildrenAsTriggers ="false"  UpdateMode="Conditional">

                                                                    <ContentTemplate>--%>
                                                                                                                        <asp:LinkButton ID="LnkImport" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkImport_Command">Select </asp:LinkButton>
                                                                                                                        <%-- </ContentTemplate>
                                                           	
                                                                    </asp:UpdatePanel>--%>
                                                                                                                    </ItemTemplate>


                                                                                                                </asp:TemplateField>
                                                                                                            </Columns>
                                                                                                        </asp:GridView>

                                                                                                    </ContentTemplate>
                                                                                                    <%-- <Triggers>
                                                                                                        <asp:PostBackTrigger ControlID="ImporterGrid" />
                                                                                                    </Triggers>--%>
                                                                                                </asp:UpdatePanel>
                                                                                            </div>
                                                                                            <div class="footer" align="right">
                                                                                                <asp:Button ID="btnyesimp" runat="server" Text="Yes" CssClass="yes" />
                                                                                                <asp:Button ID="btnnoimp" runat="server" Text="No" CssClass="no" />
                                                                                            </div>
                                                                                        </asp:Panel>
                                                                                        <%--  <asp:UpdatePanel ID="UpdatePanel2" runat="server">

                                                       
                                                           



                                          <ContentTemplate>--%>
                                                                                    </label>
                                                                                    <div class="col-sm-4">
                                                                                        <asp:TextBox autocomplete="off"  runat="server" placeholder="Code" Width="100" type="text" ID="TxtImpCode" OnTextChanged="TxtImpCode_TextChanged" AutoPostBack="true" TabIndex="28" Style="text-transform: uppercase"></asp:TextBox>

                                                                                        <cc1:AutoCompleteExtender ServiceMethod="GetImpcode"
                                                                                            MinimumPrefixLength="1"
                                                                                            CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem"  CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
                                                                                            TargetControlID="TxtImpCode"
                                                                                            ID="AutoCompleteExtender20" runat="server" FirstRowSelected="true">
                                                                                        </cc1:AutoCompleteExtender>

                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-sm-2">
                                                                                <div class="form-group row">

                                                                                    <div class="col-sm-12">
                                                                                        <asp:TextBox autocomplete="off"  ID="TxtImpCRUEI" placeholder="CRUEI" MaxLength="17" Width="170" runat="server"   TabIndex="29" type="text" Style="text-transform: uppercase"></asp:TextBox>

                                                                                        <br />
                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtImpCRUEI" ID="RegularExpressionValidator129" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="importer"></asp:RegularExpressionValidator>
                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-sm-3">
                                                                                <div class="form-group row">

                                                                                    <div class="col-sm-12">
                                                                                        <asp:TextBox autocomplete="off"  ID="TxtImpName" MaxLength="35" Placeholder="Name" Width="275" runat="server" ValidationGroup="importer"   TabIndex="30" type="text" Style="text-transform: uppercase"></asp:TextBox>

                                                                                        <br />
                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtImpName" ID="RegularExpressionValidator130" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="importer"></asp:RegularExpressionValidator>
                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-sm-3">
                                                                                <div class="form-group row">

                                                                                    <div class="col-sm-12">
                                                                                        <asp:TextBox autocomplete="off"  ID="TxtImpName1" MaxLength="35" placeholder="Name1" Width="275" ValidationGroup="importer" runat="server" TabIndex="31" type="text" Style="text-transform: uppercase"></asp:TextBox>
                                                                                        <br />
                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtImpName1" ID="RegularExpressionValidator131" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="importer"></asp:RegularExpressionValidator>
                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                        </div>

                                                                            <div id ="inwardcarrier" runat="server" visible ="false">
                                                                                <div class="row">
                                                                            <div class="col-sm-4">
                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail" class="col-sm-8 col-form-label">


                                                                                        <div class="row">
                                                                                            <div class="col-sm-8">
                                                                                              
                                                                                                Inward Carrier Agent
                                                                                            </div>
                                                                                            <div class="col-sm-4">

                                                                                                <asp:ImageButton ID="btninw1" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />

                                                                                                <asp:Button ID="InwardAdd"  BackColor ="Transparent" CssClass="plusbtn"  runat="server" ValidationGroup="Inward" OnClick="InwardAdd_Click" Text="+" />
                                                                                            </div>
                                                                                        </div>


                                                                                        <cc1:ModalPopupExtender ID="popupinw" runat="server" PopupControlID="pnlinward" TargetControlID="btninw1"
                                                                                            OkControlID="btnyesinw" CancelControlID="btnnoinw" BackgroundCssClass="modalBackground">
                                                                                        </cc1:ModalPopupExtender>
                                                                                        <asp:Panel ID="pnlinward" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                            <div class="header">
                                                                                               Inward Carrier Agent
                                                                                            </div>
                                                                                            <div class="body">
                                                                                                <asp:UpdatePanel ID="UpdatePanelInwardSearch" runat="server" UpdateMode="Conditional">

                                                                                                    <ContentTemplate>
                                                                                                        <asp:TextBox autocomplete="off"  ID="InwardSearch" OnTextChanged="InwardSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server" Style="text-transform: uppercase"></asp:TextBox>
                                                                                                        <br />



                                                                                                        <asp:GridView ID="InwardGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="InwardGrid_PageIndexChanging" OnRowCommand="InwardGrid_RowCommand" OnRowDataBound="InwardGrid_RowDataBound" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                                                                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                            <Columns>


                                                                                                                <asp:TemplateField HeaderText="Code" SortExpression="Id">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblCode" runat="server"
                                                                                                                            Text='<%#Eval("Code")%>'>
                                                                                                                        </asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Name" SortExpression="Id">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblName" runat="server"
                                                                                                                            Text='<%#Eval("Name")%>'>
                                                                                                                        </asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>

                                                                                                                <asp:TemplateField HeaderText="Name1" SortExpression="Id">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblName1" runat="server"
                                                                                                                            Text='<%#Eval("Name1")%>'>
                                                                                                                        </asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="CRUEI" SortExpression="Id">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblCRUEI" runat="server"
                                                                                                                            Text='<%#Eval("CRUEI")%>'>
                                                                                                                        </asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField>
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:LinkButton ID="LmkInward" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LmkInward_Command">Select </asp:LinkButton>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                            </Columns>
                                                                                                        </asp:GridView>

                                                                                                        </div>
    <div class="footer" align="right">
        <asp:Button ID="btnyesinw" runat="server" Text="Yes" CssClass="yes" />
        <asp:Button ID="btnnoinw" runat="server" Text="No" CssClass="no" />
                                                                                                    </ContentTemplate>
                                                                                                    <%-- <Triggers>
                                                                                                        <asp:PostBackTrigger ControlID="InwardGrid" />
                                                                                                    </Triggers>--%>
                                                                                                </asp:UpdatePanel>
                                                                                            </div>
                                                                                        </asp:Panel>


                                                                                    </label>
                                                                                    <div class="col-sm-4">
                                                                                        <asp:TextBox autocomplete="off"  runat="server" placeholder="Code" Width="100" type="text" AutoPostBack="true" ID="InwardCode" OnTextChanged="InwardCode_TextChanged" TabIndex="32" Style="text-transform: uppercase"></asp:TextBox>
                                                                                        <cc1:AutoCompleteExtender ServiceMethod="GetInwcode"
                                                                                            MinimumPrefixLength="1"
                                                                                            CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem"  CompletionListHighlightedItemCssClass="itemHighlighted"  EnableCaching="false" CompletionSetCount="10"
                                                                                            TargetControlID="InwardCode"
                                                                                            ID="AutoCompleteExtender17" runat="server" FirstRowSelected="true">
                                                                                        </cc1:AutoCompleteExtender>


                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-sm-2">
                                                                                <div class="form-group row">

                                                                                    <div class="col-sm-12">
                                                                                        <asp:TextBox autocomplete="off"  ID="InwardCRUEI" MaxLength="17" placeholder="Cruei" Width="170" BackColor="#e8f0fe" runat="server" TabIndex="33" type="text" Style="text-transform: uppercase"></asp:TextBox>

                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-sm-3">
                                                                                <div class="form-group row">

                                                                                    <div class="col-sm-12">
                                                                                        <asp:TextBox autocomplete="off"  ID="InwardName" MaxLength="50" placeholder="name" Width="275" BackColor="#e8f0fe" runat="server" TabIndex="34" type="text" ValidationGroup="Inward" Style="text-transform: uppercase"></asp:TextBox>

                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="InwardName" ID="RegularExpressionValidator138" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="Inward"></asp:RegularExpressionValidator>
                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-sm-3">
                                                                                <div class="form-group row">

                                                                                    <div class="col-sm-12">
                                                                                        <asp:TextBox autocomplete="off"  ID="InwardName1" MaxLength="50" placeholder="name1" Width="275" runat="server" TabIndex="35" type="text" ValidationGroup="Inward" Style="text-transform: uppercase"></asp:TextBox>
                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="InwardName1" ID="RegularExpressionValidator139" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="Inward"></asp:RegularExpressionValidator>
                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                        </div>
                                                                            </div>  

                                                                            <div id="outcarrier" visible ="false"   runat ="server" >
                                                                            <div  class="row">
                                                                                <div class="col-sm-4">
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-8 col-form-label">
                                                                                            <div class="row">
                                                                                        <div class="col-sm-8">
                                                                                           Outward Carrier Agent
                                                                                        </div>
                                                                                        <div class="col-sm-4">
                                                                                            
                                                                                            <asp:ImageButton id="btnoutoutward" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15"  Style="margin-top:-250px;" />
                                                                                             <asp:Button ID="OutwardAdd" BackColor="Transparent" CssClass="plusbtn" BorderWidth="0px" runat="server" ValidationGroup="Outward" OnClick="OutwardAdd_Click" Text="+" />
                                                                                            </div>
                                                                                            </div>
                                                                                            <%--  <i class='fa fa-search' data-toggle="modal" data-target="#Outward1"></i>--%>
                                                                                            <cc1:ModalPopupExtender ID="popupoutoutward" runat="server" PopupControlID="pnloutoutward" TargetControlID="btnoutoutward"
                                                                                                OkControlID="btnYesoutoutward" CancelControlID="btnNooutoutward" BackgroundCssClass="modalBackground">
                                                                                            </cc1:ModalPopupExtender>

                                                                                            <asp:Panel ID="pnloutoutward" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                                <div class="header">
                                                                                                    Outward Agent
                                                                                                </div>
                                                                                                <div class="body">
                                                                                                    <asp:UpdatePanel ID="upoutoutward" runat="server" UpdateMode="Conditional">
                                                                                                        <ContentTemplate>
                                                                                                            <asp:TextBox autocomplete="off"  ID="OutwardSearch" OnTextChanged="OutwardSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                            <br />
                                                                                                            <asp:GridView ID="OutwardGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="OutwardGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" OnRowCommand="OutwardGrid_RowCommand" OnRowDataBound="OutwardGrid_RowDataBound" runat="server" AutoGenerateColumns="false">
                                                                                                               <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>


                                                                                                                    <asp:TemplateField HeaderText="Code" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblCode" runat="server"
                                                                                                                                Text='<%#Eval("Code")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="Name" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblName" runat="server"
                                                                                                                                Text='<%#Eval("Name")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>

                                                                                                                    <asp:TemplateField HeaderText="Name1" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblName1" runat="server"
                                                                                                                                Text='<%#Eval("Name1")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="CRUEI" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblCRUEI" runat="server"
                                                                                                                                Text='<%#Eval("CRUEI")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField>
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:LinkButton ID="LmkOutward" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LmkOutward_Command">Select </asp:LinkButton>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                </Columns>
                                                                                                            </asp:GridView>
                                                                                                        </ContentTemplate>
                                                                                                        <%--  <Triggers>
<asp:PostBackTrigger ControlID="OutwardGrid" />
  </Triggers>--%>
                                                                                                    </asp:UpdatePanel>
                                                                                                </div>
                                                                                                <div class="footer" align="right">
                                                                                                    <asp:Button ID="btnYesoutoutward" runat="server" Text="Yes" CssClass="yes" />
                                                                                                    <asp:Button ID="btnNooutoutward" runat="server" Text="No" CssClass="no" />
                                                                                                </div>
                                                                                            </asp:Panel>
                                                                                           

                                                                                        </label>
                                                                                        <div class="col-sm-4">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Width="100" type="text" AutoPostBack="true" ID="OutwardCode" placeholder="Code" OnTextChanged="OutwardCode_TextChanged" TabIndex="58"></asp:TextBox>
                                                                                            <cc1:AutoCompleteExtender ServiceMethod="GetOutWard"
                                                                                                MinimumPrefixLength="1"
                                                                                                CompletionInterval="100" EnableCaching="false" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem"  CompletionListHighlightedItemCssClass="itemHighlighted"  CompletionSetCount="10"
                                                                                                TargetControlID="OutwardCode"
                                                                                                ID="AutoCompleteExtender2" runat="server" FirstRowSelected="true">
                                                                                            </cc1:AutoCompleteExtender>
                                                                                        </div>
                                                                                    </div>

                                                                                </div>
                                                                                <div class="col-sm-2">
                                                                                    <div class="form-group row">

                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="OutwardCRUEI" ValidationGroup="Partyout" Width="170" BackColor="#e8f0fe" placeholder="Cruei" runat="server" TabIndex="59" type="text"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="OutwardCRUEI" ID="RegularExpressionValidator4" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Partyout"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                    </div>

                                                                                </div>
                                                                                <div class="col-sm-3">
                                                                                    <div class="form-group row">

                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="OutwardName" Width="275" BackColor="#e8f0fe" ValidationGroup="Partyout" runat="server" placeholder="Name" TabIndex="60" type="text"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="OutwardName" Display="None" ErrorMessage="Party --> Outward Agent Name is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="OutwardName" ID="RegularExpressionValidator14" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Partyout"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                    </div>

                                                                                </div>
                                                                                <div class="col-sm-3">
                                                                                    <div class="form-group row">

                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="OutwardName1" ValidationGroup="Partyout" Width="275" runat="server" TabIndex="61" placeholder="Name1" type="text"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="OutwardName1" ID="RegularExpressionValidator3" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Partyout"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                    </div>

                                                                                </div>
                                                                            </div>
                                                                            </div>
                                                                            <div class="row">
                                                                                <div class="col-sm-4">
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-8 col-form-label">
                                                                                             <div class="row">
                                                                                        <div class="col-sm-8">
                                                                                            Freight Forwarder
                                                                                        </div>
                                                                                        <div class="col-sm-4">
                                                                                           
                                                                                             <asp:ImageButton id="btnoutfreight" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15"  Style="margin-top:-250px;" />
                                                                                           <asp:Button ID="BtnFrieghtAdd" runat="server" CssClass="plusbtn" ValidationGroup="FREIGHT" BackColor="Transparent" BorderWidth="0px" OnClick="BtnFrieghtAdd_Click" Text="+" />
                                                                                            </div>
                                                                                                 </div>
                                                                                            <%--  <i class='fa fa-search' data-toggle="modal" data-target="#Frieght"></i>--%>
                                                                                            <cc1:ModalPopupExtender ID="popupoutfreight" runat="server" PopupControlID="pnloutfreight" TargetControlID="btnoutfreight"
                                                                                                OkControlID="btnYesoutfreight" CancelControlID="btnNooutfreight" BackgroundCssClass="modalBackground">
                                                                                            </cc1:ModalPopupExtender>

                                                                                            <asp:Panel ID="pnloutfreight" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                                <div class="header">
                                                                                                    Freight Forwarder
                                                                                                </div>
                                                                                                <div class="body">
                                                                                                    <asp:UpdatePanel ID="upoutfreight" runat="server" UpdateMode="Conditional">
                                                                                                        <ContentTemplate>
                                                                                                            <asp:TextBox autocomplete="off"  ID="FrieghtSearch" OnTextChanged="FrieghtSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                            <br />
                                                                                                            <asp:GridView ID="FrieghtGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="FrieghtGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" OnRowCommand="FrieghtGrid_RowCommand" OnRowDataBound="FrieghtGrid_RowDataBound" runat="server" AutoGenerateColumns="false">
                                                                                                               <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>


                                                                                                                    <asp:TemplateField HeaderText="Code" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblCode" runat="server"
                                                                                                                                Text='<%#Eval("Code")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="Name" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblName" runat="server"
                                                                                                                                Text='<%#Eval("Name")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>

                                                                                                                    <asp:TemplateField HeaderText="Name1" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblName1" runat="server"
                                                                                                                                Text='<%#Eval("Name1")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="CRUEI" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblCRUEI" runat="server"
                                                                                                                                Text='<%#Eval("CRUEI")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField>
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:LinkButton ID="LnkFrieght" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkFrieght_Command">Select </asp:LinkButton>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                </Columns>
                                                                                                            </asp:GridView>
                                                                                                        </ContentTemplate>
                                                                                                        <%-- <Triggers>
<asp:PostBackTrigger ControlID="FrieghtGrid" />
  </Triggers>--%>
                                                                                                    </asp:UpdatePanel>
                                                                                                </div>
                                                                                                <div class="footer" align="right">
                                                                                                    <asp:Button ID="btnYesoutfreight" runat="server" Text="Yes" CssClass="yes" />
                                                                                                    <asp:Button ID="btnNooutfreight" runat="server" Text="No" CssClass="no" />
                                                                                                </div>
                                                                                            </asp:Panel>
                                                                                            

                                                                                        </label>
                                                                                        <div class="col-sm-4">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Width="100" OnTextChanged="FrieghtCode_TextChanged" placeholder="Code" AutoPostBack="true" type="text" ID="FrieghtCode" TabIndex="62"></asp:TextBox>
                                                                                            <cc1:AutoCompleteExtender ServiceMethod="GetFrieght"
                                                                                                MinimumPrefixLength="1"
                                                                                                CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem"  CompletionListHighlightedItemCssClass="itemHighlighted"  EnableCaching="false" CompletionSetCount="10"
                                                                                                TargetControlID="FrieghtCode"
                                                                                                ID="AutoCompleteExtender4" runat="server" FirstRowSelected="true">
                                                                                            </cc1:AutoCompleteExtender>
                                                                                        </div>
                                                                                    </div>

                                                                                </div>
                                                                                <div class="col-sm-2">
                                                                                    <div class="form-group row">

                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="FrieghtCRUEI" Width="170" runat="server" ValidationGroup="Partyfreight" placeholder="Cruei" TabIndex="63" type="text"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="FrieghtCRUEI" ID="RegularExpressionValidator5" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Partyfreight"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                    </div>

                                                                                </div>
                                                                                <div class="col-sm-3">
                                                                                    <div class="form-group row">

                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="FrieghtName" ValidationGroup="Partyfreight" Width="275" placeholder="Name" runat="server" TabIndex="64" type="text"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="FrieghtName" ID="RegularExpressionValidator60" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Partyfreight"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                    </div>

                                                                                </div>
                                                                                <div class="col-sm-3">
                                                                                    <div class="form-group row">

                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="FrieghtName1" Width="275" ValidationGroup="Partyfreight" runat="server" placeholder="Name1" TabIndex="65" type="text"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="FrieghtName1" ID="RegularExpressionValidator61" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Partyfreight"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                    </div>

                                                                                </div>
                                                                            </div>
                                                                            <div id="ConsigneeParty" runat="server" class="row">
                                                                                <div class="col-sm-4">
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-8 col-form-label">
                                                                                             <div class="row">
                                                                                        <div class="col-sm-8">
                                                                                            Consignee
                                                                                        </div>
                                                                                        <div class="col-sm-4">
                                                                                            
                                                                                            <asp:ImageButton id="btnoutconsignee" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15"  Style="margin-top:-250px;" />
                                                                                             <asp:Button ID="ConsigneeAdd" BackColor="Transparent" CssClass="plusbtn" BorderWidth="0px" runat="server" ValidationGroup="PartyClaimant" OnClick="ConsigneeAdd_Click" Text="+" />
                                                                                            </div>
                                                                                                 </div>
                                                                                            <%--<i class='fa fa-search' data-toggle="modal" data-target="#CONSIGNEE"></i>--%>
                                                                                            <cc1:ModalPopupExtender ID="popupoutconsignee" runat="server"  PopupControlID="pnloutconsignee" TargetControlID="btnoutconsignee"
                                                                                                OkControlID="btnYespnloutconsignee" CancelControlID="btnNopnloutconsignee" BackgroundCssClass="modalBackground">
                                                                                            </cc1:ModalPopupExtender>

                                                                                            <asp:Panel ID="pnloutconsignee" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                                <div class="header">
                                                                                                    Consignee 
                                                                                                </div>
                                                                                                <div class="body">
                                                                                                    <asp:UpdatePanel ID="upoutconsignee" runat="server" UpdateMode="Conditional">
                                                                                                        <ContentTemplate>
                                                                                                            <asp:TextBox autocomplete="off"  ID="ConsigneeSearch" OnTextChanged="ConsigneeSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                            <br />
                                                                                                            <asp:GridView ID="ConsigneeGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ConsigneeGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" OnRowCommand="ConsigneeGrid_RowCommand" OnRowDataBound="ConsigneeGrid_RowDataBound" runat="server" AutoGenerateColumns="false">
                                                                                                               <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>
                                                                                                                    <asp:TemplateField HeaderText="Code" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblCode" runat="server"
                                                                                                                                Text='<%#Eval("ConsigneeCode")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="Name" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblname" runat="server"
                                                                                                                                Text='<%#Eval("ConsigneeName")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>


                                                                                                                    <asp:TemplateField HeaderText="Name1" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblName1" runat="server"
                                                                                                                                Text='<%#Eval("ConsigneeName1")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>

                                                                                                                    <asp:TemplateField HeaderText="CRUEI" SortExpression="Id" Visible="false">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblCRUEI" runat="server"
                                                                                                                                Text='<%#Eval("ConsigneeCRUEI")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="Address" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="ConsigneeAddress" runat="server"
                                                                                                                                Text='<%#Eval("ConsigneeAddress")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="Address1" SortExpression="Id" Visible="false">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="ConsigneeAddress1" runat="server"
                                                                                                                                Text='<%#Eval("ConsigneeAddress1")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="City" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="ConsigneeCity" runat="server"
                                                                                                                                Text='<%#Eval("ConsigneeCity")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                   <asp:TemplateField HeaderText="Sub Contry" SortExpression="Id" Visible="false">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="ConsigneeSub" runat="server"
                                                                                                                                Text='<%#Eval("ConsigneeSub")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                     <asp:TemplateField HeaderText="Sub Division" SortExpression="Id" Visible="false">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="ConsigneeSubDivi1" runat="server"
                                                                                                                                Text='<%#Eval("ConsigneeSubDivi")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="Postal" SortExpression="Id" Visible="false">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="ConsigneePostal" runat="server"
                                                                                                                                Text='<%#Eval("ConsigneePostal")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="City" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="ConsigneeCountry" runat="server"
                                                                                                                                Text='<%#Eval("ConsigneeCountry")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>                                                                                                                   <asp:TemplateField>
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:LinkButton ID="LmkConsignee" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LmkConsignee_Command">Select </asp:LinkButton>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                </Columns>
                                                                                                            </asp:GridView>
                                                                                                        </ContentTemplate>
                                                                                                        <%-- <Triggers>
<asp:PostBackTrigger ControlID="ConsigneeGrid" />
  </Triggers>--%>
                                                                                                    </asp:UpdatePanel>
                                                                                                </div>
                                                                                                <div class="footer" align="right">
                                                                                                    <asp:Button ID="btnYespnloutconsignee" runat="server" Text="Yes" CssClass="yes" />
                                                                                                    <asp:Button ID="btnNopnloutconsignee" runat="server" Text="No" CssClass="no" />
                                                                                                </div>
                                                                                            </asp:Panel>
                                                                                           

                                                                                        </label>
                                                                                        <div class="col-sm-4">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Width="100" OnTextChanged="ConsigneeCode_TextChanged"  AutoPostBack="true" placeholder="Code" type="text" ID="ConsigneeCode" TabIndex="66"></asp:TextBox>
                                                                                            <br />
                                                                                            <br />
                                                                                            <cc1:AutoCompleteExtender ServiceMethod="GetCosigncode"
                                                                                                MinimumPrefixLength="1"
                                                                                                CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem"  CompletionListHighlightedItemCssClass="itemHighlighted"  EnableCaching="false" CompletionSetCount="10"
                                                                                                TargetControlID="ConsigneeCode"
                                                                                                ID="AutoCompleteExtender9" runat="server" FirstRowSelected="true">
                                                                                            </cc1:AutoCompleteExtender>
                                                                                        </div>
                                                                                    </div>

                                                                                </div>
                                                                                <div class="col-sm-2">
                                                                                    <div class="form-group row">

                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="ConsigneeCRUEI" Width="170" ValidationGroup="PartyClaimant" placeholder="Cruei" runat="server" TabIndex="67" type="text"></asp:TextBox>
                                                                                          <%--  <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeCRUEI" ID="RegularExpressionValidator68" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>--%>
                                                                                        </div>
                                                                                        <br />
                                                                                        <br />
                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="ConsigneeAddress"  BackColor="#e8f0fe" Width="170" ValidationGroup="PartyClaimant" placeholder="Address" runat="server" TabIndex="69" type="text"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ConsigneeAddress" Display="None" ErrorMessage="Party --> Cosigne Address is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeAddress" ID="RegularExpressionValidator8" ValidationExpression="^[\s\S]{0,160}$" runat="server" ErrorMessage="Maximum 160 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                        <br />
                                                                                        <br />
                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="ConsigneeSub" Width="170" ValidationGroup="PartyClaimant" placeholder="Sub Country" runat="server" TabIndex="72" type="text"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeSub" ID="RegularExpressionValidator12" ValidationExpression="^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                         <br />
                                                                                        <br />
                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="ConsigneePostal" Width="170" ValidationGroup="PartyClaimant" runat="server" TabIndex="75" placeholder="Postal" type="text"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneePostal" ID="RegularExpressionValidator13" ValidationExpression="^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                    </div>

                                                                                </div>
                                                                                <div class="col-sm-3">
                                                                                    <div class="form-group row">
                                                                                        <div class="col-sm-12">                                                                                            
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Width="275" type="text" ID="ConsigneeName" BackColor="#e8f0fe"  ValidationGroup="PartyClaimant" placeholder="Con Name" TabIndex="68"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ConsigneeName" Display="None" ErrorMessage="Party --> Cosigne Name is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeName" ID="RegularExpressionValidator10" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                        <br />
                                                                                        <br />
                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="ConsigneeAddress1" Width="275" ValidationGroup="PartyClaimant" runat="server" placeholder="Address1" TabIndex="70" type="text"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeAddress1" ID="RegularExpressionValidator7" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                       
                                                                                         <br />
                                                                                        <br />
                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="ConsigneeSubDivi" Width="275" ValidationGroup="PartyClaimant" runat="server" TabIndex="73" placeholder="Sub Division" type="text"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeSubDivi" ID="RegularExpressionValidator136" ValidationExpression="^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                        
                                                                                    </div>

                                                                                </div>
                                                                                <div class="col-sm-3">
                                                                                    <div class="form-group row">
                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="ConsigneeName1" Width="275" ValidationGroup="PartyClaimant" runat="server" placeholder="Name1" TabIndex="69" type="text"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeName1" ID="RegularExpressionValidator11" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                        <br />
                                                                                        <br />
                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="ConsigneeCity" Width="275" ValidationGroup="PartyClaimant" runat="server" placeholder="City" TabIndex="71" type="text"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeCity" ID="RegularExpressionValidator9" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                        <br />
                                                                                        <br />
                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="ConsigneeCountry" BackColor="#e8f0fe" Width="275" ValidationGroup="PartyClaimant" placeholder="Country" runat="server" TabIndex="74" type="text"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeCountry" ID="RegularExpressionValidator15" ValidationExpression="^[\s\S]{0,2}$" runat="server" ErrorMessage="Maximum 2 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                    </div>

                                                                                </div>
                                                                            </div>
                                                                            <div class ="row">
                                                                                <div class ="col-sm-2" >
                                                                                 <asp:CheckBox ID="chkeu" OnCheckedChanged ="chkeu_CheckedChanged" Text="END USER" AutoPostBack ="true" TabIndex ="76" runat="server" />
                                                                           </div>
                                                                                     </div>
                                                                          
                                                                               <div id="eu" runat ="server" visible ="false" >
                                                                            <div class="row">
                                                                                <div class="col-sm-4">
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-8 col-form-label">
                                                                                               <div class="row">
                                                                                        <div class="col-sm-8">
                                                                                         
                                                                                        </div>
                                                                                        <div class="col-sm-4">
                                                                                             <asp:ImageButton id="btnoutenduser" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15"  Style="margin-top:-250px;" />
                                                                                             <asp:Button ID="EndUserAdd" BackColor="Transparent" CssClass="plusbtn" BorderWidth="0px" runat="server" ValidationGroup="Enduser" OnClick="EndUserAdd_Click" Text="+" />
                                                                                            </div>
                                                                                                   </div>
                                                                                            <cc1:ModalPopupExtender ID="popupoutend" runat="server" PopupControlID="pnloutend" TargetControlID="btnoutenduser"
                                                                                                OkControlID="btnYesoutend" CancelControlID="btnNooutend" BackgroundCssClass="modalBackground">
                                                                                            </cc1:ModalPopupExtender>

                                                                                            <asp:Panel ID="pnloutend" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                                <div class="header">
                                                                                                    END USER
                                                                                                </div>
                                                                                                <div class="body">
                                                                                                    <asp:UpdatePanel ID="upoutend" runat="server" UpdateMode="Conditional">
                                                                                                        <ContentTemplate>
                                                                                                            <asp:TextBox autocomplete="off"  ID="EndUserSearch" OnTextChanged="EndUserSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                            <br />
                                                                                                            <asp:GridView ID="EndUserGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="EndUserGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" OnRowCommand="EndUserGrid_RowCommand" OnRowDataBound="EndUserGrid_RowDataBound" runat="server" AutoGenerateColumns="false">
                                                                                                               <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>
                                                                                                                    <asp:TemplateField HeaderText="Code" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblCode" runat="server"
                                                                                                                                Text='<%#Eval("EndUserCode")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="Name" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblname" runat="server"
                                                                                                                                Text='<%#Eval("EndUserName")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>


                                                                                                                    <asp:TemplateField HeaderText="Name1" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblName1" runat="server"
                                                                                                                                Text='<%#Eval("EndUserName1")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>

                                                                                                                    <asp:TemplateField HeaderText="CRUEI" SortExpression="Id" Visible="false">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblCRUEI" runat="server"
                                                                                                                                Text='<%#Eval("EndUserCRUEI")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="Address" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="ConsigneeAddress" runat="server"
                                                                                                                                Text='<%#Eval("EndUserAddress")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="Address1" SortExpression="Id" Visible="false">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="ConsigneeAddress1" runat="server"
                                                                                                                                Text='<%#Eval("EndUserAddress1")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="City" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="ConsigneeCity" runat="server"
                                                                                                                                Text='<%#Eval("EndUserCity")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="Sub Contry Code" SortExpression="Id" Visible="false">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="EndUserSubCode" runat="server"
                                                                                                                                Text='<%#Eval("EndUserSubCode")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                     <asp:TemplateField HeaderText="Sub Contry" SortExpression="Id" Visible="false">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="ConsigneeSub" runat="server"
                                                                                                                                Text='<%#Eval("EndUserSub")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="Postal" SortExpression="Id" Visible="false">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="ConsigneePostal" runat="server"
                                                                                                                                Text='<%#Eval("EndUserPostal")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="City" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="ConsigneeCountry" runat="server"
                                                                                                                                Text='<%#Eval("EndUserCountry")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField>
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:LinkButton ID="LmkEndUser" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LmkEndUser_Command">Select </asp:LinkButton>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                </Columns>
                                                                                                            </asp:GridView>
                                                                                                        </ContentTemplate>
                                                                                                        <%-- <Triggers>
<asp:PostBackTrigger ControlID="EndUserGrid" />
  </Triggers>--%>
                                                                                                    </asp:UpdatePanel>
                                                                                                </div>
                                                                                                <div class="footer" align="right">
                                                                                                    <asp:Button ID="btnYesoutend" runat="server" Text="Yes" CssClass="yes" />
                                                                                                    <asp:Button ID="btnNooutend" runat="server" Text="No" CssClass="no" />
                                                                                                </div>
                                                                                            </asp:Panel>
                                                                                          

                                                                                        </label>
                                                                                     
                                                                                        <div class="col-sm-4">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Width="100" OnTextChanged="EndUserCode_TextChanged" placeholder="Code" AutoPostBack="true" type="text" ID="EndUserCode" TabIndex="77"></asp:TextBox>
                                                                                            <br />
                                                                                            <br />
                                                                                            <cc1:AutoCompleteExtender ServiceMethod="GetEnduser"
                                                                                                MinimumPrefixLength="1"
                                                                                                CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem"  CompletionListHighlightedItemCssClass="itemHighlighted"  EnableCaching="false" CompletionSetCount="10"
                                                                                                TargetControlID="EndUserCode"
                                                                                                ID="AutoCompleteExtender5" runat="server" FirstRowSelected="true">
                                                                                            </cc1:AutoCompleteExtender>
                                                                                        </div>

                                                                                        <br />
                                                                                        <br />
                                                                                        <div class="col-sm-4">
                                                                                            <asp:Button ID="btncopyconsign" runat="server" OnClick="btncopyconsign_Click" Text="Copy of Consignee" />
                                                                                        </div>
                                                                                    </div>

                                                                                </div>
                                                                                <div class="col-sm-2">
                                                                                    <div class="form-group row">

                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="EndUserCrueo" Width="170" runat="server" placeholder="Cruei" ValidationGroup="Enduser" TabIndex="77" type="text"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserCrueo" ID="RegularExpressionValidator20" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Enduser"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                        <br />
                                                                                        <br />
                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="EndUserAddress" Width="170" runat="server" placeholder="Address" ValidationGroup="Enduser" TabIndex="80" type="text"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserAddress" ID="RegularExpressionValidator21" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35characters allowed." ValidationGroup="Enduser"></asp:RegularExpressionValidator><br />
                                                                                        </div>
                                                                                        <br />
                                                                                        <br />
                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="EndUserSubCode" Width="170" runat="server" placeholder="Sub Code" ValidationGroup="Enduser" TabIndex="83" type="text"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserSubCode" ID="RegularExpressionValidator24" ValidationExpression="^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="Enduser"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                        <br />
                                                                                        <br />
                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="EndUserSubdivision" Width="170" runat="server" placeholder="Sub division" ValidationGroup="Enduser" TabIndex="86" type="text"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserSubdivision" ID="RegularExpressionValidator27" ValidationExpression="^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="Enduser"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                    </div>

                                                                                </div>
                                                                                <div class="col-sm-3">
                                                                                    <div class="form-group row">
                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Width="275" type="text" ID="EndUserName" placeholder="UserName" ValidationGroup="Enduser" TabIndex="78"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserName" ID="RegularExpressionValidator16" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="Enduser"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                        <br />
                                                                                        <br />
                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="EndUserAddress1" Width="275" runat="server" ValidationGroup="Enduser" placeholder="Address1" TabIndex="81" type="text"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserAddress1" ID="RegularExpressionValidator22" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Enduser"></asp:RegularExpressionValidator>
                                                                                        </div>

                                                                                        <br />
                                                                                        <br />
                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="EndUserPostal" Width="275" runat="server" ValidationGroup="Enduser" placeholder="Postal" TabIndex="84" type="text"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserPostal" ID="RegularExpressionValidator25" ValidationExpression="^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="Enduser"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                    </div>

                                                                                </div>
                                                                                <div class="col-sm-3">
                                                                                    <div class="form-group row">
                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="EndUserName1" Width="275" runat="server" ValidationGroup="Enduser" placeholder="Name1" TabIndex="79" type="text"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserName1" ID="RegularExpressionValidator17" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="Enduser"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                        <br />
                                                                                        <br />
                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="EndUserCity" Width="275" runat="server" ValidationGroup="Enduser" placeholder="City" TabIndex="82" type="text"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserCity" ID="RegularExpressionValidator23" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Enduser"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                        <br />
                                                                                        <br />
                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="EndUserCountry" Width="275" runat="server" ValidationGroup="Enduser" placeholder="Country" TabIndex="85" type="text"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserCountry" ID="RegularExpressionValidator26" ValidationExpression="^[\s\S]{0,2}$" runat="server" ErrorMessage="Maximum 2 characters allowed." ValidationGroup="Enduser"></asp:RegularExpressionValidator><br />
                                                                                        </div>
                                                                                    </div>

                                                                                </div>
                                                                            </div>
                                                                            </div>

                                                                            <div id="manufact" visible ="false"  runat="server" >
                                                                            <div class="row">
                                                                                <div class="col-sm-4">
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-8 col-form-label">
                                                                                             <div class="row">
                                                                                        <div class="col-sm-8">
                                                                                            Manufacturer
                                                                                        </div>
                                                                                        <div class="col-sm-4">
                                                                                            
                                                                                             <asp:ImageButton id="btnoutmanufaturer" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15"  Style="margin-top:-250px;" />
                                                                                            <asp:Button ID="ManufacturerAdd" BackColor="Transparent" CssClass="plusbtn" BorderWidth="0px" runat="server" ValidationGroup="CLAIMANT" OnClick="ManufacturerAdd_Click" Text="+" />
                                                                                            </div>
                                                                                                 </div>
                                                                                            <cc1:ModalPopupExtender ID="popupoutmanufaturer" runat="server" PopupControlID="pnloutmanufaturer" TargetControlID="btnoutmanufaturer"
                                                                                                OkControlID="btnYesoutmanufaturer" CancelControlID="btnNooutmanufaturer" BackgroundCssClass="modalBackground">
                                                                                            </cc1:ModalPopupExtender>

                                                                                            <asp:Panel ID="pnloutmanufaturer" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                                <div class="header">
                                                                                                   Manufacturer
                                                                                                </div>
                                                                                                <div class="body">
                                                                                                    <asp:UpdatePanel ID="upoutmanufaturer" runat="server" UpdateMode="Conditional">
                                                                                                        <ContentTemplate>
                                                                                                            <asp:TextBox autocomplete="off"  ID="ManufacturerSearch" OnTextChanged="ManufacturerSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                            <br />
                                                                                                            <asp:GridView ID="ManufacturerGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ManufacturerGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" OnRowCommand="ManufacturerGrid_RowCommand" OnRowDataBound="ManufacturerGrid_RowDataBound" AutoGenerateColumns="false">
                                                                                                               <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>
                                                                                                                    <asp:TemplateField HeaderText="Code" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblCode" runat="server"
                                                                                                                                Text='<%#Eval("ManufacturerCode")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="Name" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblname" runat="server"
                                                                                                                                Text='<%#Eval("ManufacturerName")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>


                                                                                                                    <asp:TemplateField HeaderText="Name1" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblName1" runat="server"
                                                                                                                                Text='<%#Eval("ManufacturerName1")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>

                                                                                                                    <asp:TemplateField HeaderText="CRUEI" SortExpression="Id" >
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblCRUEI" runat="server"
                                                                                                                                Text='<%#Eval("ManufacturerCRUEI")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="Address" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="ConsigneeAddress" runat="server"
                                                                                                                                Text='<%#Eval("ManufacturerAddress")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="Address1" SortExpression="Id" Visible="false">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="ConsigneeAddress1" runat="server"
                                                                                                                                Text='<%#Eval("ManufacturerAddress1")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="City" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="ConsigneeCity" runat="server"
                                                                                                                                Text='<%#Eval("ManufacturerCity")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    
                                                                                                                    <asp:TemplateField HeaderText="Sub Code" SortExpression="Id" Visible="false">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="ConsigneeSub" runat="server"
                                                                                                                                Text='<%#Eval("ManufacturerSub")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>

                                                                                                                     <asp:TemplateField HeaderText="Sub Division" SortExpression="Id" Visible="false">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="ManufacturerSubCode" runat="server"
                                                                                                                                Text='<%#Eval("ManufacturerSubDivi")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>

                                                                                                                    <asp:TemplateField HeaderText="Postal" SortExpression="Id" Visible="false">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="ConsigneePostal" runat="server"
                                                                                                                                Text='<%#Eval("ManufacturerPostal")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="City" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="ConsigneeCountry" runat="server"
                                                                                                                                Text='<%#Eval("ManufacturerCountry")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField>
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:LinkButton ID="LmkManufacturer" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LmkManufacturer_Command">Select </asp:LinkButton>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                </Columns>
                                                                                                            </asp:GridView>
                                                                                                        </ContentTemplate>
                                                                                                        <%--<Triggers>
<asp:PostBackTrigger ControlID="ManufacturerGrid" />
  </Triggers>--%>
                                                                                                    </asp:UpdatePanel>
                                                                                                </div>
                                                                                                <div class="footer" align="right">
                                                                                                    <asp:Button ID="btnYesoutmanufaturer" runat="server" Text="Yes" CssClass="yes" />
                                                                                                    <asp:Button ID="btnNooutmanufaturer" runat="server" Text="No" CssClass="no" />
                                                                                                </div>
                                                                                            </asp:Panel>
                                                                                            <%--  <i class='fa fa-search' data-toggle="modal" data-target="#Manufacturer"></i>--%>
                                                                                           

                                                                                        </label>
                                                                                        <div class="col-sm-4">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Width="100" OnTextChanged="ManufacturerCode_TextChanged" placeholder="Code" AutoPostBack="true" type="text" ID="ManufacturerCode" TabIndex="87"></asp:TextBox>
                                                                                            <br />
                                                                                            <br />
                                                                                             <cc1:AutoCompleteExtender ServiceMethod="Getmanufac"
                                                                                                MinimumPrefixLength="1"
                                                                                                CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem"  CompletionListHighlightedItemCssClass="itemHighlighted"  EnableCaching="false" CompletionSetCount="10"
                                                                                                TargetControlID="ManufacturerCode"
                                                                                                ID="AutoCompleteExtender21" runat="server" FirstRowSelected="true">
                                                                                            </cc1:AutoCompleteExtender>
                                                                                        </div>
                                                                                    </div>

                                                                                </div>
                                                                                <div class="col-sm-2">
                                                                                    <div class="form-group row">

                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="ManufacturerCRUEI" Width="170" ValidationGroup="Manufacture" placeholder="Cruei" runat="server" TabIndex="88" type="text"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ManufacturerCRUEI" ID="RegularExpressionValidator30" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Manufacture"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                        <br />
                                                                                        <br />
                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="ManufacturerAddress" Width="170" ValidationGroup="Manufacture" placeholder="Address" runat="server" TabIndex="91" type="text"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ManufacturerAddress" ID="RegularExpressionValidator31" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Manufacture"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                        <br />
                                                                                        <br />
                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="ManufacturerSubCode" Width="170" ValidationGroup="Manufacture" placeholder="Subcode" runat="server" TabIndex="94" type="text"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ManufacturerSubCode" ID="RegularExpressionValidator33" ValidationExpression="^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="Manufacture"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                       <br />
                                                                                        <br />
                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="ManufacturerPostal" Width="250" ValidationGroup="Manufacture" placeholder="Postal" runat="server" TabIndex="97" type="text"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ManufacturerPostal" ID="RegularExpressionValidator35" ValidationExpression="^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="Manufacture"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                    </div>

                                                                                </div>
                                                                                <div class="col-sm-3">
                                                                                    <div class="form-group row">
                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Width="275" type="text" ID="ManufacturerName" placeholder="Name" ValidationGroup="Manufacture" TabIndex="89"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ManufacturerName" ID="RegularExpressionValidator29" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="Manufacture"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                        <br />
                                                                                        <br />
                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="ManufacturerAddress1" Width="275" ValidationGroup="Manufacture" placeholder="Address1" runat="server" TabIndex="92" type="text"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ManufacturerAddress1" ID="RegularExpressionValidator34" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Manufacture"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                         <br />
                                                                                        <br />
                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="ManufacturerSubDivi" Width="275" ValidationGroup="Manufacture" placeholder="Sub Division" runat="server" TabIndex="95" type="text"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ManufacturerSubDivi" ID="RegularExpressionValidator137" ValidationExpression="^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="Manufacture"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                        
                                                                                    </div>

                                                                                </div>
                                                                                <div class="col-sm-3">
                                                                                    <div class="form-group row">
                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="ManufacturerName1" Width="275" runat="server" ValidationGroup="Manufacture" placeholder="Name1" TabIndex="90" type="text"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ManufacturerName1" ID="RegularExpressionValidator28" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="Manufacture"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                        <br />
                                                                                        <br />
                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="ManufacturerCity" Width="275" ValidationGroup="Manufacture" runat="server" placeholder="City" TabIndex="93" type="text"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ManufacturerCity" ID="RegularExpressionValidator32" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Manufacture"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                        <br />
                                                                                        <br />
                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  ID="ManufacturerCountry" Width="275" ValidationGroup="Manufacture" placeholder="Country" runat="server" TabIndex="96" type="text"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ManufacturerCountry" ID="RegularExpressionValidator36" ValidationExpression="^[\s\S]{0,2}$" runat="server" ErrorMessage="Maximum 2 characters allowed." ValidationGroup="Manufacture"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                    </div>

                                                                                </div>
                                                                            </div>
                                                                            </div>
                                                                           
                                                                                                        <div class="row">
    <%-- <div class="col-sm-3">
                        </div>--%>
    <div class="col-sm-12">
        <center>

            <div class="flex justify-between gap-4 md:flex-nowrap flex-wrap mt-6">
                <asp:Button ID="btnpreviousparty" runat="server" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" OnClick="btnpreviousparty_Click" Text="Previous" TabIndex="45" />

                
                <asp:Button ID="btnsaveparty" runat="server" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" OnClick="btnsaveparty_Click" Text="Save" TabIndex="47" />
                
                <asp:Button ID="btnreset" runat="server" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" OnClick="btnreset_Click" Text="Reset" TabIndex="47" />

                <asp:Button ID="btnnextparty" runat="server" CssClass="nn  duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" OnClick="btnnextparty_Click" Text="Next" TabIndex="48" />
            </div>
        </center>
    </div>
    <%--  <div class="col-sm-3"></div>--%>
</div>


                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>

                                                                </ContentTemplate>
                                                            </cc1:TabPanel>
                                                            <%--</div>--%>

                                                            <%--  Party Old--%>

                                                            <%--<div role="tabpanel" class="tab-pane fade" id="Cargo">--%>
                                                            <cc1:TabPanel ID="Cargo1" runat="server" CssClass="nn" HeaderText="Cargo">
                                                                <ContentTemplate>
                                                                    <asp:UpdatePanel ID="outcargo" UpdateMode="Conditional" runat="server">
                                                                        <ContentTemplate>
                                                                            <div class="row">
                                                                                <div class="col-sm-6">
                                                                                    <div id="LocationR" runat="server">
                                                                                        
                                                                                        <h5 style="background: linear-gradient(-135deg, #c850c0, #4158d0);color:white; text-align:center;">Location Details</h5>
                                                                                        <br />
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Release Location&nbsp;
                                                                                            
                                                                                            <asp:ImageButton id="btnoutrelloc" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15"  />
                                                                                           
                                                                                            <%--<i class='fa fa-search' data-toggle="modal" data-target="#LOCATION"></i>--%>
                                                                                        </label>
                                                                                        <cc1:ModalPopupExtender ID="popupoutrelloc" runat="server" PopupControlID="pnloutrelloc" TargetControlID="btnoutrelloc"
                                                                                            OkControlID="btnYesoutrelloc" CancelControlID="btnNooutrelloc" BackgroundCssClass="modalBackground">
                                                                                        </cc1:ModalPopupExtender>

                                                                                        <asp:Panel ID="pnloutrelloc" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                            <div class="header">
                                                                                               Release Location
                                                                                            </div>
                                                                                            <div class="body">
                                                                                                <asp:UpdatePanel ID="upoutrelloc" runat="server" UpdateMode="Conditional">
                                                                                                    <ContentTemplate>
                                                                                                        <asp:TextBox autocomplete="off"  ID="LocationSearch" OnTextChanged="LocationSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                        <br />
                                                                                                        <asp:GridView ID="LocationGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="LocationGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" OnRowCommand="LocationGrid_RowCommand" OnRowDataBound="LocationGrid_RowDataBound" AutoGenerateColumns="false">
                                                                                                           <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>


                                                                                                                <asp:TemplateField HeaderText="Code" SortExpression="Id">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblCode" runat="server"
                                                                                                                            Text='<%#Eval("Code")%>'>
                                                                                                                        </asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="LocationCode" SortExpression="Id">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblName" runat="server"
                                                                                                                            Text='<%#Eval("LocationCode")%>'>
                                                                                                                        </asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>

                                                                                                                <asp:TemplateField HeaderText="Description" SortExpression="Id">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblName1" runat="server"
                                                                                                                            Text='<%#Eval("Description")%>'>
                                                                                                                        </asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>

                                                                                                                <asp:TemplateField>
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:LinkButton ID="LnkLocation" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkLocation_Command">Select </asp:LinkButton>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                            </Columns>
                                                                                                        </asp:GridView>
                                                                                                    </ContentTemplate>
                                                                                                    <%-- <Triggers>
<asp:PostBackTrigger ControlID="LocationGrid" />
  </Triggers>--%>
                                                                                                </asp:UpdatePanel>
                                                                                            </div>
                                                                                            <div class="footer" align="right">
                                                                                                <asp:Button ID="btnYesoutrelloc" runat="server" Text="Yes" CssClass="yes" />
                                                                                                <asp:Button ID="btnNooutrelloc" runat="server" Text="No" CssClass="no" />
                                                                                            </div>
                                                                                        </asp:Panel>
                                                                                        
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Width="100" BackColor="#e8f0fe" MaxLength="7" type="text" ValidationGroup="Validation" ID="txtreLoctn" OnTextChanged="txtreLoctn_TextChanged" AutoPostBack="true" TabIndex="102"></asp:TextBox>
                                                                                            <cc1:AutoCompleteExtender ServiceMethod="Getrelloc"
                                                                                                MinimumPrefixLength="1"
                                                                                                CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem"  CompletionListHighlightedItemCssClass="itemHighlighted"  EnableCaching="false" CompletionSetCount="10"
                                                                                                TargetControlID="txtreLoctn"
                                                                                                ID="AutoCompleteExtender7" runat="server" FirstRowSelected="true">
                                                                                            </cc1:AutoCompleteExtender>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtreLoctn" Display="None" ErrorMessage="Cargo -->Release Location Code is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                           <br />
                                                                                            
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Width="350" MaxLength="256" Height="25" type="text" ID="txtrelocDeta" TextMode = "MultiLine" Style="text-transform:uppercase"   ValidationGroup="Validation" TabIndex="103"></asp:TextBox>
                                                                                           
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Receipt Location&nbsp;
                                                                                             <asp:ImageButton id="btnoutreciptloc" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15"  Style="margin-top:-250px;" />
                                                                                            
                                                                                            
                                                                                            <%--<i class='fa fa-search' data-toggle="modal" data-target="#Receipt"></i>--%>
                                                                                        </label>

                                                                                        <cc1:ModalPopupExtender ID="popupoutreceiptloc" runat="server" PopupControlID="pnloutreceiptloc" TargetControlID="btnoutreciptloc"
                                                                                            OkControlID="btnYesoutreceiptloc" CancelControlID="btnNooutreceiptloc" BackgroundCssClass="modalBackground">
                                                                                        </cc1:ModalPopupExtender>

                                                                                        <asp:Panel ID="pnloutreceiptloc" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                            <div class="header">
                                                                                                RECEIPT LOCATION
                                                                                            </div>
                                                                                            <div class="body">
                                                                                                <asp:UpdatePanel ID="upoutreceiptloc" runat="server" UpdateMode="Conditional">
                                                                                                    <ContentTemplate>
                                                                                                        <asp:TextBox autocomplete="off"  ID="ReceiptSearch" OnTextChanged="ReceiptSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>

                                                                                                        <br />
                                                                                                        <asp:GridView ID="ReceiptGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ReceiptGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" OnRowCommand="ReceiptGrid_RowCommand" OnRowDataBound="ReceiptGrid_RowDataBound" AutoGenerateColumns="false">
                                                                                                           <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>


                                                                                                                <asp:TemplateField HeaderText="Code" SortExpression="Id">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblCode" runat="server"
                                                                                                                            Text='<%#Eval("Code")%>'>
                                                                                                                        </asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="LocationCode" SortExpression="Id">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblName" runat="server"
                                                                                                                            Text='<%#Eval("LocationCode")%>'>
                                                                                                                        </asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>

                                                                                                                <asp:TemplateField HeaderText="Description" SortExpression="Id">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblName1" runat="server"
                                                                                                                            Text='<%#Eval("Description")%>'>
                                                                                                                        </asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>

                                                                                                                <asp:TemplateField>
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:LinkButton ID="LnkReceipt" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkReceipt_Command">Select </asp:LinkButton>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                            </Columns>
                                                                                                        </asp:GridView>
                                                                                                    </ContentTemplate>
                                                                                                    <%--<Triggers>
<asp:PostBackTrigger ControlID="ReceiptGrid" />
  </Triggers>--%>
                                                                                                </asp:UpdatePanel>
                                                                                            </div>
                                                                                            <div class="footer" align="right">
                                                                                                <asp:Button ID="btnYesoutreceiptloc" runat="server" Text="Yes" CssClass="yes" />
                                                                                                <asp:Button ID="btnNooutreceiptloc" runat="server" Text="No" CssClass="no" />
                                                                                            </div>
                                                                                        </asp:Panel>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe" Width="100" MaxLength="7" ValidationGroup="Validation" type="text" OnTextChanged="txtrecloctn_TextChanged" AutoPostBack="true" ID="txtrecloctn" TabIndex="104"></asp:TextBox>
                                                                                            <cc1:AutoCompleteExtender ServiceMethod="GetRecLoc"
                                                                                                MinimumPrefixLength="1"
                                                                                                CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem"  CompletionListHighlightedItemCssClass="itemHighlighted"  EnableCaching="false" CompletionSetCount="10"
                                                                                                TargetControlID="txtrecloctn"
                                                                                                ID="AutoCompleteExtender8" runat="server" FirstRowSelected="true">
                                                                                            </cc1:AutoCompleteExtender>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtrecloctn" Display="None" ErrorMessage="Cargo -->Receipt Location Code is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                          <br />
                                                                                           <asp:TextBox autocomplete="off" TextMode ="MultiLine"  Style="text-transform:uppercase"  runat="server" Width="350" Height="25" type="text" ID="txtrecloctndet" ValidationGroup="Validation" TabIndex="105"></asp:TextBox>
                                                                                           
                                                                                        
                                                                                           
                                                                                            <asp:Label runat="server" ForeColor="Red" BackColor="Yellow" Visible="false" ID="lblrecloc"></asp:Label>
                                                                                        </div>
                                                                                    </div>
                                                                                       
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Storage Location&nbsp;
                                                                                             <asp:ImageButton id="btnoutstorageloc" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15"  Style="margin-top:-250px;" />

                                                                                            
                                                                                            <%--<i class='fa fa-search' data-toggle="modal" data-target="#Storage"></i>--%>
                                                                                        </label>
                                                                                        <cc1:ModalPopupExtender ID="popupoutstorageloc" runat="server" PopupControlID="pnloutstorageloc" TargetControlID="btnoutstorageloc"
                                                                                            OkControlID="btnYesoutstorageloc" CancelControlID="btnNooutstorageloc" BackgroundCssClass="modalBackground">
                                                                                        </cc1:ModalPopupExtender>

                                                                                        <asp:Panel ID="pnloutstorageloc" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                            <div class="header">
                                                                                              Storage Location
                                                                                            </div>
                                                                                            <div class="body">
                                                                                                <asp:UpdatePanel ID="upoutstorageloc" runat="server" UpdateMode="Conditional">
                                                                                                    <ContentTemplate>
                                                                                                        <asp:TextBox autocomplete="off"  ID="TextBox4" OnTextChanged="TextBox4_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>

                                                                                                        <br />
                                                                                                        <asp:GridView ID="GridView2" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="GridView2_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" OnRowCommand="GridView2_RowCommand" OnRowDataBound="GridView2_RowDataBound" runat="server" AutoGenerateColumns="false">
                                                                                                           <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>


                                                                                                                <asp:TemplateField HeaderText="Code" SortExpression="Id">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblCode" runat="server"
                                                                                                                            Text='<%#Eval("Code")%>'>
                                                                                                                        </asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="LocationCode" SortExpression="Id">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblName" runat="server"
                                                                                                                            Text='<%#Eval("LocationCode")%>'>
                                                                                                                        </asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>

                                                                                                                <asp:TemplateField HeaderText="Description" SortExpression="Id">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblName1" runat="server"
                                                                                                                            Text='<%#Eval("Description")%>'>
                                                                                                                        </asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>

                                                                                                                <asp:TemplateField>
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:LinkButton ID="Lnkstorage" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="Lnkstorage_Command">Select </asp:LinkButton>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                            </Columns>
                                                                                                        </asp:GridView>
                                                                                                    </ContentTemplate>
                                                                                                    <%--<Triggers>
<asp:PostBackTrigger ControlID="GridView2" />
  </Triggers>--%>
                                                                                                </asp:UpdatePanel>
                                                                                            </div>
                                                                                            <div class="footer" align="right">
                                                                                                <asp:Button ID="btnYesoutstorageloc" runat="server" Text="Yes" CssClass="yes" />
                                                                                                <asp:Button ID="btnNooutstorageloc" runat="server" Text="No" CssClass="no" />
                                                                                            </div>
                                                                                        </asp:Panel>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" type="text" OnTextChanged="txtstrgeloc_TextChanged" ValidationGroup="Validation" Width="100" MaxLength ="7" AutoPostBack="true" ID="txtstrgeloc" TabIndex="106"></asp:TextBox>
                                                                                            <cc1:AutoCompleteExtender ServiceMethod="GetStorageLoc"
                                                                                                MinimumPrefixLength="1"
                                                                                                CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem"  CompletionListHighlightedItemCssClass="itemHighlighted"  EnableCaching="false" CompletionSetCount="10"
                                                                                                TargetControlID="txtstrgeloc"
                                                                                                ID="AutoCompleteExtender14" runat="server" FirstRowSelected="true">
                                                                                            </cc1:AutoCompleteExtender>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtstrgeloc" ID="RegularExpressionValidator42" ValidationExpression="^[\s\S]{0,7}$" runat="server" ErrorMessage="Maximum 7 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                            <br />
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Width="350" Height="25"  type="text" TextMode ="MultiLine" ID="txtstrgelocdet" MaxLength="256" ValidationGroup="Validation" TabIndex="107"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtstrgelocdet" ID="RegularExpressionValidator43" ValidationExpression="^[\s\S]{0,250}$" runat="server" ErrorMessage="Maximum 250 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                    </div>
                                                                                         <div id="BlanketCode" runat="server" visible="false" >
                                                                                              <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Blanket Start Date
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  ID="BlankDate1" Style="width:250px;" onkeypress="return noAlphabets(event)" runat="server" AutoPostBack="true" TabIndex="108" OnTextChanged="BlankDate1_TextChanged"></asp:TextBox>
                                                                                            <cc1:CalendarExtender ID="CalendarExtender1" CssClass="cal_Theme1" PopupButtonID="imgPopup" runat="server" TargetControlID="BlankDate1" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"></cc1:CalendarExtender>
                                                                                        </div>
                                                                                    </div>
                                                                                         </div>
                                                                                        </div>
                                                                                    </div>



                                                                                
                                                                                     <div class="col-sm-6">
                                                                                        
                                                                                          <h5 style="background: linear-gradient(-135deg, #c850c0, #4158d0);color:white; text-align:center;" >Outer Pack Details</h5>
                                                                                        <br />
                                                                                    
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-5 col-form-label">
                                                                                                Total Outer Pack
                                                                                            </label>
                                                                                            <div class="col-sm-7">
                                                                                                <asp:TextBox autocomplete="off"  runat="server" onkeypress="return noAlphabets(event)" type="text" ID="TxttotalOuterPack" BackColor="#e8f0fe" ValidationGroup="outerpack" TabIndex="109" AutoPostBack ="true"  Width="150" OnTextChanged="TxttotalOuterPack_TextChanged"></asp:TextBox>
                                                                                                <asp:DropDownList CssClass="drop" ID="DrptotalOuterPack" BackColor="#e8f0fe" runat="server" TabIndex="110" Width="150" Height="26" OnSelectedIndexChanged="DrptotalOuterPack_SelectedIndexChanged" AutoPostBack ="true"></asp:DropDownList>
                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxttotalOuterPack" ID="RegularExpressionValidator44" ValidationExpression="^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 8 characters allowed." ValidationGroup="outerpack"></asp:RegularExpressionValidator>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-5 col-form-label">
                                                                                                Total Gross Weight
                                                                                            </label>
                                                                                            <div class="col-sm-7">
                                                                                                <asp:TextBox autocomplete="off"  runat="server" type="text" ID="TxtTotalGrossWeight" onkeypress="return noAlphabets(event)" BackColor="#e8f0fe" ValidationGroup="outerpack" TabIndex="111" Width="150" OnTextChanged="TxtTotalGrossWeight_TextChanged" AutoPostBack ="true" ></asp:TextBox>
                                                                                                <asp:DropDownList CssClass="drop" ID="DrpTotalGrossWeight" BackColor="#e8f0fe" runat="server" Width="150" TabIndex="112" Height="26" OnSelectedIndexChanged="DrpTotalGrossWeight_SelectedIndexChanged" AutoPostBack ="true" >
                                                                                                     <asp:ListItem Selected="True" Text="--Select--" Value="--SELECT--"> </asp:ListItem>
                                                                                            <asp:ListItem Text="KGM" Value="KGM"> </asp:ListItem>
                                                                                            <asp:ListItem Text="TNE" Value="TNE"> </asp:ListItem>
                                                                                                </asp:DropDownList>
                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtTotalGrossWeight" ID="RegularExpressionValidator45" ValidationExpression="^[\s\S]{0,15}$" runat="server" ErrorMessage="Maximum 15 characters allowed." ValidationGroup="outerpack"></asp:RegularExpressionValidator>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                    
                                                                                

                                                                            </div>
                                                                            <div class="row">
                                                                                <div class="col-sm-12">

                                                                                    
                                                                                  
                                                                                        <div id="InwardDetailsdiv1" runat="server" class="col-sm-6">

                                                                                     <h5 style="background: linear-gradient(-135deg, #c850c0, #4158d0);color:white; text-align:center;" id="ind" runat ="server">Inward Details</h5>
                                                                                        <br />
                                                                                    
                                                                                  

                                                                                    <div id="carMode" runat="server" class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-4 col-form-label">
                                                                                            Mode
                                                                                        </label>
                                                                                        <div class="col-sm-8">
                                                                                            <asp:TextBox autocomplete="off"  Enabled="false"  BackColor="#e8f0fe" runat="server" type="text" ID="TextMode" OnTextChanged="TextMode_TextChanged" AutoPostBack="true" TabIndex="113"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div id="carArrival" runat="server" class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-4 col-form-label">
                                                                                            Arrival Date & Time
                                                                                        </label>
                                                                                        <div class="col-sm-8">
                                                                                            <asp:TextBox autocomplete="off"  ID="TxtArrivalDate1" OnTextChanged ="TxtArrivalDate1_TextChanged" onkeypress="return noAlphabets(event)" Width="200" AutoPostBack ="true"  TabIndex="114" runat="server"></asp:TextBox>
                                                                                            <asp:TextBox autocomplete="off"  ID="TxtArrivalTime" runat="server" Width="50" TabIndex="115" placeholder="Time"></asp:TextBox>
                                                                                            <cc1:CalendarExtender ID="CalendarExtender2" CssClass="cal_Theme1" PopupButtonID="imgPopup" runat="server" TargetControlID="TxtArrivalDate1" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"></cc1:CalendarExtender>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="TxtArrivalDate1" Display="None" ErrorMessage="Cargo --> Arrival Date is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div id="carLoadingPort" runat="server">
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-4 col-form-label">
                                                                                                Loading Port&nbsp;
                                                                                                <asp:ImageButton id="btnoutload" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15"  Style="margin-top:-250px;" />

                                                                                           
                                                                                            </label>
                                                                                            <cc1:ModalPopupExtender ID="popupoutloadingport" runat="server" PopupControlID="pnloutloadingport" TargetControlID="btnoutload"
                                                                                                OkControlID="btnYesoutloadingport" CancelControlID="btnNooutloadingport" BackgroundCssClass="modalBackground">
                                                                                            </cc1:ModalPopupExtender>

                                                                                            <asp:Panel ID="pnloutloadingport" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                                <div class="header">
                                                                                                    Loading Port
                                                                                                </div>
                                                                                                <div class="body">
                                                                                                    <asp:UpdatePanel ID="upoutloadingport" runat="server" UpdateMode="Conditional">
                                                                                                        <ContentTemplate>
                                                                                                            <asp:TextBox autocomplete="off"  ID="CarLoadingSearch" OnTextChanged="CarLoadingSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                            <br />
                                                                                                            <asp:GridView ID="LoadingGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="LoadingGrid_PageIndexChanging" OnRowCommand="LoadingGrid_RowCommand" OnRowDataBound="LoadingGrid_RowDataBound" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                                                                               <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>


                                                                                                                    <asp:TemplateField HeaderText="PortCode" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblCode" runat="server"
                                                                                                                                Text='<%#Eval("PortCode")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="PortName" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblName" runat="server"
                                                                                                                                Text='<%#Eval("PortName")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>

                                                                                                                    <asp:TemplateField HeaderText="Country" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblName1" runat="server"
                                                                                                                                Text='<%#Eval("Country")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>

                                                                                                                    <asp:TemplateField>
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:LinkButton ID="LnkLoading" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkLoading_Command">Select </asp:LinkButton>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                </Columns>
                                                                                                            </asp:GridView>

                                                                                                        </ContentTemplate>
                                                                                                        <%--<Triggers>
<asp:PostBackTrigger ControlID="LoadingGrid" />
  </Triggers>--%>
                                                                                                    </asp:UpdatePanel>
                                                                                                </div>
                                                                                                <div class="footer" align="right">
                                                                                                    <asp:Button ID="btnYesoutloadingport" runat="server" Text="Yes" CssClass="yes" />
                                                                                                    <asp:Button ID="btnNooutloadingport" runat="server" Text="No" CssClass="no" />
                                                                                                </div>
                                                                                            </asp:Panel>
                                                                                            <div class="col-sm-8">
                                                                                                <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe" Width="75" type="text" ID="TxtLoadShort" OnTextChanged="TxtLoadShort_TextChanged" AutoPostBack="true" TabIndex="116"></asp:TextBox>

                                                                                                <cc1:AutoCompleteExtender ServiceMethod="GetLoadingport"
                                                                                                    MinimumPrefixLength="1"
                                                                                                    CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem"  CompletionListHighlightedItemCssClass="itemHighlighted"  EnableCaching="false" CompletionSetCount="10"
                                                                                                    TargetControlID="TxtLoadShort"
                                                                                                    ID="AutoCompleteExtender15" runat="server" FirstRowSelected="true">
                                                                                                </cc1:AutoCompleteExtender>
                                                                                                <asp:TextBox autocomplete="off"  runat="server" type="text" ID="TxtLoad" Enabled="false" TabIndex="117" Width="175"></asp:TextBox>
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="TxtLoadShort" Display="None" ErrorMessage="Cargo --> Loading Port is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>


                                                                                    <div id="InwardFlight" runat="server">
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-4 col-form-label">
                                                                                                Flight Number
                                                                                            </label>
                                                                                            <div class="col-sm-8">
                                                                                                <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe"  ValidationGroup="Validation" type="text" ID="txtflight" TabIndex="118"></asp:TextBox>
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtflight" Display="None" ErrorMessage="Cargo -->Flight Number is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtflight" ID="RegularExpressionValidator116" ValidationExpression="^[\s\S]{0,15}$" runat="server" ErrorMessage="Maximum 15 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-4 col-form-label">
                                                                                                Aircraft Register Number
                                                                                            </label>
                                                                                            <div class="col-sm-8">
                                                                                                <asp:TextBox autocomplete="off"  runat="server" ValidationGroup="Validation"  type="text" ID="txtaircraft" TabIndex="119"></asp:TextBox>
                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtaircraft" ID="RegularExpressionValidator117" ValidationExpression="^[\s\S]{0,15}$" runat="server" ErrorMessage="Maximum 15 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>

                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-4 col-form-label">
                                                                                                Master Air Waybill
                                                                                            </label>
                                                                                            <div class="col-sm-8">
                                                                                                <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe"  ValidationGroup="Validation" type="text" ID="txtwaybill" OnTextChanged="txtwaybill_TextChanged" AutoPostBack ="true" TabIndex="120"></asp:TextBox>
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtwaybill" Display="None" ErrorMessage="Cargo -->Master Air Waybill is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtwaybill" ID="RegularExpressionValidator118" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div id="InwardSea" runat="server">
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-4 col-form-label">
                                                                                                Voyage Number
                                                                                            </label>
                                                                                            <div class="col-sm-8">
                                                                                                <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe"  ValidationGroup="Validation" type="text" ID="TxtVoyageno" TabIndex="121"></asp:TextBox>
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="TxtVoyageno" Display="None" ErrorMessage="Cargo -->Voyage Number is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtVoyageno" ID="RegularExpressionValidator102" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 15 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-4 col-form-label">
                                                                                                Vessel Name
                                                                                            </label>
                                                                                            <div class="col-sm-8">
                                                                                                <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe" ValidationGroup="Validation"  type="text" ID="TxtVesselName" TabIndex="122"></asp:TextBox>
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="TxtVesselName" Display="None" ErrorMessage="Cargo -->Vessel Name is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtVesselName" ID="RegularExpressionValidator103" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-4 col-form-label">
                                                                                              IN  OBL
                                                                                            </label>
                                                                                            <div class="col-sm-8">
                                                                                                <asp:TextBox autocomplete="off"  runat="server" OnTextChanged ="TxtOceanBill_TextChanged"  BackColor="#e8f0fe"  ValidationGroup="Validation"  type="text" ID="TxtOceanBill" TabIndex="123"></asp:TextBox>
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="TxtOceanBill" Display="None" ErrorMessage="Cargo -->Ocean Bill Of Lading Number is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtOceanBill" ID="RegularExpressionValidator104" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                    
                                                                                    
                                                                                    <div id="InwardOther" runat="server">
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-4 col-form-label">
                                                                                                Conveyance Ref.No
                                                                                            </label>
                                                                                            <div class="col-sm-8">
                                                                                                <asp:TextBox autocomplete="off"  runat="server" type="text" ValidationGroup="Validation" ID="TxtConRefNo"  TabIndex="124"></asp:TextBox>
                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtConRefNo" ID="RegularExpressionValidator106" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-4 col-form-label">
                                                                                                Transport ID
                                                                                            </label>
                                                                                            <div class="col-sm-8">
                                                                                                <asp:TextBox autocomplete="off"  runat="server" type="text" ValidationGroup="Validation" ID="TxtTrnsID"  TabIndex="125"></asp:TextBox>
                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtTrnsID" ID="RegularExpressionValidator107" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                   <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-4 col-form-label">
                                                                                            <p id="inhab1" runat="server">In HAWB/HBL</p>
                                                                                            <p id="phawb1" runat="server" visible="false">HAWB</p>
                                                                                            <p id="inhbl1" runat="server" visible="false">HBL</p>
                                                                                        </label>
                                                                                        <div class="col-sm-8">
                                                                                            <asp:TextBox autocomplete="off"  Width="200" runat="server"  type="text" ID="txthblCargo" OnTextChanged="txthblCargo_TextChanged1" AutoPostBack="true" TabIndex="126"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator49" runat="server" ControlToValidate="TxtHAWB" ErrorMessage="Item--->Please Enter In HAWB/OBL"
Display="None" ValidationGroup="ItemMasterValidation" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txthblCargo" ID="RegularExpressionValidator125" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                            <asp:Button ID="Button10" runat="server" Visible="false" Text="Copy All" />
                                                                                        </div>
                                                                                    </div>

                                                                                   
                                                                                </div>
                                                                                   
                                                                                         

                                                                                     
                                                                                        <div class="col-sm-6" id="OutDiv" visible ="false"  runat="server">
                                                                                  
                                                                                      <h5 style="background: linear-gradient(-135deg, #c850c0, #4158d0);color:white; text-align:center;">Outward Details</h5>
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Mode
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  Enabled="false"  BackColor="#e8f0fe" runat="server" type="text" ID="TxtExpMode" OnTextChanged="TxtExpMode_TextChanged" AutoPostBack="true" TabIndex="127"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Departure Date & Time
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  ID="TxtExpArrivalDate1" Style="width: 175px;" runat="server" onkeypress="return noAlphabets(event)" AutoPostBack="true" TabIndex="128" ValidationGroup="date" OnTextChanged="TxtExpArrivalDate1_TextChanged"></asp:TextBox>
                                                                                            <asp:TextBox autocomplete="off"  ID="TxtDepTime" runat="server" Width="75" TabIndex="129" placeholder="Time"></asp:TextBox>
                                                                                            <cc1:CalendarExtender ID="CalendarExtender3" CssClass="cal_Theme1" PopupButtonID="imgPopup" runat="server" TargetControlID="TxtExpArrivalDate1" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"></cc1:CalendarExtender>

                                                                                            <%-- <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Invalid date format."
                validationgroup="date" Display="None" ForeColor="Red" ControlToValidate="TxtExpArrivalDate1"
                Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>--%>
                                                                                          <%--  <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="AED Failed (Date Must be >= to currentdate)" ValidationGroup="date" Display="Dynamic" ForeColor="Red" ControlToValidate="TxtExpArrivalDate1"
                                                                                                Operator="GreaterThanEqual" EnableClientScript ="true"  Type="Date"></asp:CompareValidator>--%>
                                                                                           <br />
                                                                                             <asp:Label ID="dateerr" BackColor="Brown" ForeColor ="White"  runat ="server" Visible ="false" ></asp:Label>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ControlToValidate="TxtExpArrivalDate1" Display="None" ErrorMessage="Cargo --> Arrival Date is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                        </div>
                                                                                    </div>


 <div id="dischargeport" runat="server">
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Discharge Port&nbsp;&nbsp;
                                                                                            <asp:ImageButton id="btnoutdischargeport" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15"  Style="margin-top:-250px;" />
                                                                                            
                                                                                         
                                                                                        </label>
                                                                                        <cc1:ModalPopupExtender ID="popupoutdischargeport" runat="server" PopupControlID="pnloutdischargeport" TargetControlID="btnoutdischargeport"
                                                                                            OkControlID="btnYesoutdischargeport" CancelControlID="btnNooutdischargeport" BackgroundCssClass="modalBackground">
                                                                                        </cc1:ModalPopupExtender>

                                                                                        <asp:Panel ID="pnloutdischargeport" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                            <div class="header">
                                                                                                Discharge Port
                                                                                            </div>
                                                                                            <div class="body">
                                                                                                <asp:UpdatePanel ID="upoutdischargeport" runat="server" UpdateMode="Conditional">
                                                                                                    <ContentTemplate>
                                                                                                        <asp:TextBox autocomplete="off"  ID="ExpLoadingSearch" OnTextChanged="ExpLoadingSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                        <br />
                                                                                                        <asp:GridView ID="ExportGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ExportGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" OnRowCommand="ExportGrid_RowCommand" OnRowDataBound="ExportGrid_RowDataBound" runat="server" AutoGenerateColumns="false">
                                                                                                           <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>


                                                                                                                <asp:TemplateField HeaderText="PortCode" SortExpression="Id">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblCode" runat="server"
                                                                                                                            Text='<%#Eval("PortCode")%>'>
                                                                                                                        </asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="PortName" SortExpression="Id">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblName" runat="server"
                                                                                                                            Text='<%#Eval("PortName")%>'>
                                                                                                                        </asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>

                                                                                                                <asp:TemplateField HeaderText="Country" SortExpression="Id">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblName1" runat="server"
                                                                                                                            Text='<%#Eval("Country")%>'>
                                                                                                                        </asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>

                                                                                                                <asp:TemplateField>
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:LinkButton ID="LnkExport" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkExport_Command">Select </asp:LinkButton>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                            </Columns>
                                                                                                        </asp:GridView>

                                                                                                    </ContentTemplate>
                                                                                                    <%--<Triggers>
<asp:PostBackTrigger ControlID="ExportGrid" />
  </Triggers>--%>
                                                                                                </asp:UpdatePanel>
                                                                                            </div>
                                                                                            <div class="footer" align="right">
                                                                                                <asp:Button ID="btnYesoutdischargeport" runat="server" Text="Yes" CssClass="yes" />
                                                                                                <asp:Button ID="btnNooutdischargeport" runat="server" Text="No" CssClass="no" />
                                                                                            </div>
                                                                                        </asp:Panel>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe" Width="75" type="text" ID="TxtExpLoadShort" OnTextChanged="TxtExpLoadShort_TextChanged" AutoPostBack="true" TabIndex="130"></asp:TextBox>
                                                                                            <cc1:AutoCompleteExtender ServiceMethod="GetTxtExpLoadShort"
                                                                                                MinimumPrefixLength="1"
                                                                                                CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem"  CompletionListHighlightedItemCssClass="itemHighlighted"  EnableCaching="false" CompletionSetCount="10"
                                                                                                TargetControlID="TxtExpLoadShort"
                                                                                                ID="AutoCompleteExtender16" runat="server" FirstRowSelected="true">
                                                                                            </cc1:AutoCompleteExtender>

                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ControlToValidate="TxtExpLoadShort" Display="None" ErrorMessage="Cargo --> Loading Port is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                            <asp:TextBox autocomplete="off"  runat="server" type="text" ID="TxtExpLoad"  Enabled="false" Width="175" TabIndex="131"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Final Destination Country
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:DropDownList CssClass="drop"  BackColor="#e8f0fe" runat="server" ID="DrpFinalDesCountry" OnSelectedIndexChanged="DrpFinalDesCountry_SelectedIndexChanged" AutoPostBack="true" TabIndex="132"></asp:DropDownList>
                                                                                            <asp:Label ID="lblfinalcountry" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                                                                                        </div>
                                                                                    </div>
      </div>
  <div id="Seastorediv" runat="server" visible="false">
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Sea Store
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:CheckBox ID="chkSea" OnCheckedChanged ="chkSea_CheckedChanged1" AutoPostBack="true" runat="server" TabIndex="133" />
                                                                                        </div>
                                                                                    </div>
      </div>
                                                                                    <div id="OUTWARDFlight" runat="server">
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                Flight Number
                                                                                            </label>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe" ValidationGroup="outsea"  type="text" ID="OUTWARDFlightN0" TabIndex="134"></asp:TextBox>
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ControlToValidate="OUTWARDFlightN0" Display="None" ErrorMessage="Cargo -->Flight Number is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="OUTWARDFlightN0" ID="RegularExpressionValidator108" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="outsea"></asp:RegularExpressionValidator>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                Aircraft Register Number
                                                                                            </label>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:TextBox autocomplete="off"  runat="server"  ValidationGroup="outsea" type="text" ID="OUTWARDAirREgno" TabIndex="135"></asp:TextBox>
                                                                                                <asp:RegularExpressionValidator BackColor="Yellow" Display="Dynamic" ControlToValidate="OUTWARDAirREgno" ID="RegularExpressionValidator109" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="outsea"></asp:RegularExpressionValidator>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                Master Air Waybill
                                                                                            </label>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe"  ValidationGroup="outsea" type="text" ID="OUTWARDAirwaybill" OnTextChanged ="OUTWARDAirwaybill_TextChanged" AutoPostBack ="true" TabIndex="136"></asp:TextBox>
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator50" runat="server" ControlToValidate="OUTWARDAirwaybill" Display="None" ErrorMessage="Cargo -->Master Air Waybill is Required" ValidationGroup="outsea"></asp:RequiredFieldValidator>
                                                                                                <asp:RegularExpressionValidator BackColor="Yellow" ID="RegularExpressionValidator110" runat="server" Display="Dynamic" ControlToValidate="OUTWARDAirwaybill" ValidationExpression="^[\s\S]{0,35}$" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="outsea" />
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div id="OUTWARDSea" runat="server">
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                Voyage Number
                                                                                            </label>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe"  ValidationGroup="outsea" type="text" ID="OUTWARDVoyageNo" TabIndex="137"></asp:TextBox>
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator52" runat="server" ControlToValidate="OUTWARDVessel" Display="None" ErrorMessage="Cargo -->Voyage Number is Required" ValidationGroup="outsea"></asp:RequiredFieldValidator>
                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="OUTWARDVoyageNo" ID="RegularExpressionValidator111" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="outsea"></asp:RegularExpressionValidator>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                Vessel Name
                                                                                            </label>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe"  ValidationGroup="outsea" type="text" ID="OUTWARDVessel" TabIndex="138"></asp:TextBox>
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator53" runat="server" ControlToValidate="OUTWARDVessel" Display="None" ErrorMessage="Cargo -->Vessel Name is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="OUTWARDVessel" ID="RegularExpressionValidator112" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="outsea"></asp:RegularExpressionValidator>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                               OUT  OBL
                                                                                            </label>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe"  ValidationGroup="outsea" type="text" AutoPostBack="true" OnTextChanged ="OUTWARDOcenbill_TextChanged" ID="OUTWARDOcenbill" TabIndex="139"></asp:TextBox>
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator54" runat="server" ControlToValidate="OUTWARDOcenbill" Display="None" ErrorMessage="Cargo -->Ocean Bill Of Lading Number is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="OUTWARDOcenbill" ID="RegularExpressionValidator113" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="outsea"></asp:RegularExpressionValidator>
                                                                                            </div>
                                                                                        </div>                                                                                                                                                                          
                                                                                    </div>
                                                                                     <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Out HAWB/OBL
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  runat="server"   type="text" ID="txtouthblCargo" TabIndex="151" AutoPostBack="true" OnTextChanged="txtouthblCargo_TextChanged"></asp:TextBox>
                                                                                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator106" runat="server" ControlToValidate="txtflight" Display="None" ErrorMessage="Cargo -->Flight Number is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>--%>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div id="OUTWARDOther" runat="server">
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                Conveyance Ref.No
                                                                                            </label>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:TextBox autocomplete="off"  runat="server" type="text" ID="OUTWARDConref" ValidationGroup="outsea"  TabIndex="140"></asp:TextBox>
                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="OUTWARDConref" ID="RegularExpressionValidator114" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="outsea"></asp:RegularExpressionValidator>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                Transport ID
                                                                                            </label>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:TextBox autocomplete="off"  runat="server" type="text" ID="OUTWARDTransId" ValidationGroup="outsea"  TabIndex="141"></asp:TextBox>
                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="OUTWARDTransId" ID="RegularExpressionValidator115" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="outsea"></asp:RegularExpressionValidator>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div id="OUTWARDVesl" runat="server">
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                Vessel Type
                                                                                            </label>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:DropDownList CssClass="drop" ID="ddpVessel" BackColor ="ActiveCaption"  runat="server"  TabIndex="142"></asp:DropDownList>
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator55" runat="server" ControlToValidate="ddpVessel" Display="None" ErrorMessage="Cargo -->Master Air Waybill is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                Vessel Net Register Tonnage
                                                                                            </label>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:TextBox autocomplete="off"  runat="server"   type="text" ID="txtvesnet" ValidationGroup="outsea" TabIndex="143"></asp:TextBox>
                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtvesnet" ID="RegularExpressionValidator105" ValidationExpression="^[\s\S]{0,15}$" runat="server" ErrorMessage="Maximum 15 characters allowed." ValidationGroup="outsea"></asp:RegularExpressionValidator>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                Vessel Nationality
                                                                                            </label>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:DropDownList CssClass="drop"  runat="server" ID="DroVesslNat" TabIndex="144"></asp:DropDownList>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                Towing Vessel ID
                                                                                            </label>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:TextBox autocomplete="off"  runat="server"   type="text" ID="txtTowVes" ValidationGroup="outsea" TabIndex="145"></asp:TextBox>
                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtTowVes" ID="RegularExpressionValidator132" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="outsea"></asp:RegularExpressionValidator>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                Towing Vessel Name
                                                                                            </label>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:TextBox autocomplete="off"  runat="server"   type="text" ID="txtTowVesName" ValidationGroup="outsea" TabIndex="146"></asp:TextBox>
                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtTowVesName" ID="RegularExpressionValidator133" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="outsea"></asp:RegularExpressionValidator>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                Next Port
                                                                                                 <asp:ImageButton id="btnoutnextport" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15"  Style="margin-top:-250px;" />
                                                                                              
                                                                                                <%--<i class='fa fa-search' data-toggle="modal" data-target="#loadingSearch1"></i>--%>
                                                                                            </label>
                                                                                            <cc1:ModalPopupExtender ID="popupoutnextport" runat="server" PopupControlID="pnloutnextport" TargetControlID="btnoutnextport"
                                                                                                OkControlID="btnYesoutnextport" CancelControlID="btnNooutnextport" BackgroundCssClass="modalBackground">
                                                                                            </cc1:ModalPopupExtender>

                                                                                            <asp:Panel ID="pnloutnextport" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                                <div class="header">
                                                                                                    Next Port
                                                                                                </div>
                                                                                                <div class="body">
                                                                                                    <asp:UpdatePanel ID="upoutnextport" runat="server" UpdateMode="Conditional">
                                                                                                        <ContentTemplate>
                                                                                                            <asp:TextBox autocomplete="off"  ID="NextPrtLoading" OnTextChanged="NextPrtLoading_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                            <br />
                                                                                                            <asp:GridView ID="NextPortGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="NextPortGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" OnRowCommand="NextPortGrid_RowCommand" OnRowDataBound="NextPortGrid_RowDataBound" AutoGenerateColumns="false">
                                                                                                               <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>


                                                                                                                    <asp:TemplateField HeaderText="PortCode" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblCode" runat="server"
                                                                                                                                Text='<%#Eval("PortCode")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="PortName" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblName" runat="server"
                                                                                                                                Text='<%#Eval("PortName")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>

                                                                                                                    <asp:TemplateField HeaderText="Country" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblName1" runat="server"
                                                                                                                                Text='<%#Eval("Country")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>

                                                                                                                    <asp:TemplateField>
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:LinkButton ID="LnkLoading1" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkLoading1_Command">Select </asp:LinkButton>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                </Columns>
                                                                                                            </asp:GridView>
                                                                                                        </ContentTemplate>
                                                                                                   <%--     <Triggers>
<asp:PostBackTrigger ControlID="NextPortGrid" />
  </Triggers>--%>
                                                                                                    </asp:UpdatePanel>
                                                                                                </div>
                                                                                                <div class="footer" align="right">
                                                                                                    <asp:Button ID="btnYesoutnextport" runat="server" Text="Yes" CssClass="yes" />
                                                                                                    <asp:Button ID="btnNooutnextport" runat="server" Text="No" CssClass="no" />
                                                                                                </div>
                                                                                            </asp:Panel>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:TextBox autocomplete="off"  runat="server"  Width="75" type="text" ID="txtNextprt" AutoPostBack="true" OnTextChanged="txtNextprt_TextChanged" TabIndex="147"></asp:TextBox>
                                                                                                 <cc1:AutoCompleteExtender ServiceMethod="Getnextport"
                                                                                                MinimumPrefixLength="1"
                                                                                                CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem"  CompletionListHighlightedItemCssClass="itemHighlighted"  EnableCaching="false" CompletionSetCount="10"
                                                                                                TargetControlID="txtNextprt"
                                                                                                ID="AutoCompleteExtender18" runat="server" FirstRowSelected="true">
                                                                                            </cc1:AutoCompleteExtender>

                                                                                                <asp:TextBox autocomplete="off"  runat="server"  Width="175" type="text" ID="txtNetPrtSer" TabIndex="148"></asp:TextBox>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                Last Port

                                                                                                    <asp:ImageButton id="btnoutlastport" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15"  Style="margin-top:-250px;" />
                                                                                               
                                                                                                <%--<i class='fa fa-search' data-toggle="modal" data-target="#loadingSearch2"></i>--%>
                                                                                            </label>
                                                                                            <cc1:ModalPopupExtender ID="popupoutlastport" runat="server" PopupControlID="pnloutlastport" TargetControlID="btnoutlastport"
                                                                                                OkControlID="btnYesoutlastport" CancelControlID="btnNooutlastport" BackgroundCssClass="modalBackground">
                                                                                            </cc1:ModalPopupExtender>

                                                                                            <asp:Panel ID="pnloutlastport" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                                <div class="header">
                                                                                                    Last Port
                                                                                                </div>
                                                                                                <div class="body">
                                                                                                    <asp:UpdatePanel ID="upoutlastport" runat="server" UpdateMode="Conditional">
                                                                                                        <ContentTemplate>
                                                                                                            <asp:TextBox autocomplete="off"  ID="txtlastprt" OnTextChanged="txtlastprt_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                            <br />
                                                                                                            <asp:GridView ID="LastGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="LastGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" OnRowCommand="LastGrid_RowCommand" OnRowDataBound="LastGrid_RowDataBound" AutoGenerateColumns="false">
                                                                                                               <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>


                                                                                                                    <asp:TemplateField HeaderText="PortCode" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblCode" runat="server"
                                                                                                                                Text='<%#Eval("PortCode")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="PortName" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblName" runat="server"
                                                                                                                                Text='<%#Eval("PortName")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>

                                                                                                                    <asp:TemplateField HeaderText="Country" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblName1" runat="server"
                                                                                                                                Text='<%#Eval("Country")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>

                                                                                                                    <asp:TemplateField>
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:LinkButton ID="LnkLoading2" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkLoading2_Command">Select </asp:LinkButton>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                </Columns>
                                                                                                            </asp:GridView>
                                                                                                        </ContentTemplate>
                                                                                                        <Triggers>
                                                                                                            <asp:PostBackTrigger ControlID="LastGrid" />
                                                                                                        </Triggers>


                                                                                                    </asp:UpdatePanel>
                                                                                                </div>
                                                                                                <div class="footer" align="right">
                                                                                                    <asp:Button ID="btnYesoutlastport" runat="server" Text="Yes" CssClass="yes" />
                                                                                                    <asp:Button ID="btnNooutlastport" runat="server" Text="No" CssClass="no" />
                                                                                                </div>
                                                                                            </asp:Panel>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:TextBox autocomplete="off"  runat="server"  Width="75" type="text" ID="txtLasPrt" AutoPostBack="true" OnTextChanged="txtLasPrt_TextChanged" TabIndex="149"></asp:TextBox>
                                                                                                 <cc1:AutoCompleteExtender ServiceMethod="Getlastport"
                                                                                                MinimumPrefixLength="1"
                                                                                                CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem"  CompletionListHighlightedItemCssClass="itemHighlighted"  EnableCaching="false" CompletionSetCount="10"
                                                                                                TargetControlID="txtLasPrt"
                                                                                                ID="AutoCompleteExtender19" runat="server" FirstRowSelected="true">
                                                                                            </cc1:AutoCompleteExtender>
                                                                                                <asp:TextBox autocomplete="off"  runat="server"  Width="175" type="text" ID="txtLasPrtSer" TabIndex="150"></asp:TextBox>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>                                                                                              
                                                                                </div>

                                                                                   

                                                                                </div>
                                                                            </div>

                                                                            <div  class="row">
                                                                                <div class="col-sm-12">
                                                                                    <h5 style="background: linear-gradient(-135deg, #c850c0, #4158d0);color:white; text-align:center;" id="H1" runat ="server">Container Details</h5>
                                                                                        <br />
                                                                                    <center>
                                                                                    <div id="gvAddrow" runat ="server">
                                                                                            <asp:GridView ID="ContarinerGrid" runat="server" OnRowDeleting="ContarinerGrid_RowDeleting" OnRowDataBound="ContarinerGrid_RowDataBound1"  ShowFooter="true" AutoGenerateColumns="false">
                                                                                               <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>
                                                                                                    <asp:TemplateField  HeaderText ="S.No">
        <ItemTemplate>
             <%#Container.DataItemIndex+1 %>
        </ItemTemplate>
    </asp:TemplateField>
                                                                                                    <asp:BoundField DataField="RowNumber" HeaderText="Row Number" Visible="false" />
                                                                                                    <asp:TemplateField HeaderText="Container No">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:TextBox autocomplete="off"  ID="txt1" BackColor="#e8f0fe" TabIndex="131"  runat="server"></asp:TextBox>
                                                                                                            <asp:RegularExpressionValidator ID="revEmail" ValidationGroup="Validation" ForeColor="Red" Display="Dynamic"
                                                                                                                ValidationExpression="[a-zA-Z]{4}[0-9]{7}" ControlToValidate="txt1"
                                                                                                                runat="server"
                                                                                                                ErrorMessage="The container no. format should be 4 alphabets and followed by 7 digit, for ex.: ABCD1234567"></asp:RegularExpressionValidator>
                                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txt1" Display="None" ErrorMessage="Cargo -->Container No is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Size / Type">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:DropDownList CssClass="drop" ID="DrpType" BackColor="#e8f0fe"  runat="server"></asp:DropDownList>
                                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator231" InitialValue="0" runat="server" ControlToValidate="DrpType" Display="None" ErrorMessage="Cargo -->Size / Type is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Weight ( TNE )">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:TextBox autocomplete="off"  ID="txt2" BackColor="#e8f0fe"  ValidationGroup="Validation1" MaxLength ="3" runat="server"></asp:TextBox>
                                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2311" runat="server" ControlToValidate="txt2" Display="None" ErrorMessage="Cargo -->Weight ( TNE ) is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                                           
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Seal No">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:TextBox autocomplete="off"  ID="txt3" BackColor="#e8f0fe"  ValidationGroup="Validation1"  runat="server"></asp:TextBox>
                                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23111" runat="server" ControlToValidate="txt3" Display="None" ErrorMessage="Cargo -->Seal No is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                                            <br />
                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txt3" ID="RegularExpressionValidator45" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Validation1"></asp:RegularExpressionValidator>
                                                                                                        </ItemTemplate>
                                                                                                        <FooterStyle HorizontalAlign="Right" />
                                                                                                        <FooterTemplate>
                                                                                                            <asp:Button ID="ButtonAdd" runat="server" Text="Add Row" OnClick="ButtonAdd_Click" />
                                                                                                        </FooterTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                     <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />

                                                                                                </Columns>
                                                                                            </asp:GridView>
                                                                                        </div>
                                                                                        </center>
                                                                                    </div>
                                                                            </div>                                                                           
                                                                            <br /><br />
                                                                            <center>
                                                                            <div class="btn-group btn-group-lg">
                                                                                <asp:Button ID="btnprevcargo" CssClass="nn" runat="server" class="btn btn-info btn-lg" OnClick="btnprevcargo_Click" Text="Previous" TabIndex="152" />
                                                                                <asp:Button ID="btnsavecargo" Visible="false"  CssClass="nn" runat="server" class="btn btn-info btn-lg" OnClick="btnsavecargo_Click" Text="Save Draft" TabIndex="153" />
                                                                                <asp:Button ID="btnresetcargo" CssClass="nn" runat="server" class="btn btn-info btn-lg" OnClick="btnresetcargo_Click" Text="Reset" TabIndex="154" />
                                                                                <asp:Button ID="btnnextcargo" CssClass="nn" runat="server" class="btn btn-info btn-lg" OnClick="btnnextcargo_Click" Text="Next" TabIndex="155" />

                                                                            </div>
                                                                            </center>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </ContentTemplate>
                                                            </cc1:TabPanel>
                                                            <%--</div> --%>

                                                           
                                                            <cc1:TabPanel ID="Invoice" runat="server" CssClass="nn" HeaderText="Invoice">
                                                                <ContentTemplate>
                                                                    <asp:UpdatePanel ID="outinvoice" UpdateMode="Conditional" runat="server">
                                                                        <ContentTemplate>
                                                                            <div id ="outinvsuply" runat ="server" visible ="false"  class="row">
                                                                                <div class="col-sm-4">
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-8 col-form-label">
                                                                                            Supplier / Manufacturer Party&nbsp;
                                                                                             <asp:ImageButton id="btnoutsupplier" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15"  Style="margin-top:-250px;" />
                                                                                           
                                                                                            <asp:Button ID="suppyadd" runat="server" ValidationGroup="ItemMasterValidation1" OnClick="suppyadd_Click" Text="+" />
                                                                                        </label>
                                                                                        <cc1:ModalPopupExtender ID="popupoutsupplier" runat="server" PopupControlID="pnloutsupplier" TargetControlID="btnoutsupplier"
                                                                                            OkControlID="btnYesoutsupplier" CancelControlID="btnNooutsupplier" BackgroundCssClass="modalBackground">
                                                                                        </cc1:ModalPopupExtender>

                                                                                        <asp:Panel ID="pnloutsupplier" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                            <div class="header">
                                                                                                Supplier / Manufacturer Party
                                                                                            </div>
                                                                                            <div class="body">
                                                                                                <asp:UpdatePanel ID="upoutsupplier" runat="server" UpdateMode="Conditional">
                                                                                                    <ContentTemplate>
                                                                                                        <asp:TextBox autocomplete="off"  ID="SUPPLIERSearch" OnTextChanged="SUPPLIERSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                        <br />
                                                                                                        <asp:GridView ID="SUPPLIERGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="SUPPLIERGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" OnRowCommand="SUPPLIERGrid_RowCommand" OnRowDataBound="SUPPLIERGrid_RowDataBound" AutoGenerateColumns="false">
                                                                                                           <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>


                                                                                                                <asp:TemplateField HeaderText="DocumentType" SortExpression="Id">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblCode" runat="server"
                                                                                                                            Text='<%#Eval("Code")%>'>
                                                                                                                        </asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Name" SortExpression="Id">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblName" runat="server"
                                                                                                                            Text='<%#Eval("Name")%>'>
                                                                                                                        </asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>

                                                                                                                <asp:TemplateField HeaderText="Name1" SortExpression="Id">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblName1" runat="server"
                                                                                                                            Text='<%#Eval("Name1")%>'>
                                                                                                                        </asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="CRUEI" SortExpression="Id">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblCRUEI" runat="server"
                                                                                                                            Text='<%#Eval("CRUEI")%>'>
                                                                                                                        </asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField>
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:LinkButton ID="lnkRequestID" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="lnkRequestID_Command1">Select </asp:LinkButton>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                            </Columns>
                                                                                                        </asp:GridView>
                                                                                                    </ContentTemplate>
                                                                                                    <%--<Triggers>
<asp:PostBackTrigger ControlID="SUPPLIERGrid" />
  </Triggers>--%>
                                                                                                </asp:UpdatePanel>
                                                                                            </div>
                                                                                            <div class="footer" align="right">
                                                                                                <asp:Button ID="btnYesoutsupplier" runat="server" Text="Yes" CssClass="yes" />
                                                                                                <asp:Button ID="btnNooutsupplier" runat="server" Text="No" CssClass="no" />
                                                                                            </div>
                                                                                        </asp:Panel>
                                                                                        <div class="col-sm-4">
                                                                                            <asp:TextBox autocomplete="off"  Width="100" placeholder="Code" runat="server" type="text" ID="txtcodeinvq" OnTextChanged="txtcodeinvq_TextChanged" AutoPostBack="true" TabIndex="156"></asp:TextBox>
                                                                                            <cc1:AutoCompleteExtender ServiceMethod="GetSupcode"
                                                                                                MinimumPrefixLength="1"
                                                                                                CompletionInterval="100" CompletionListCssClass="ac_results" EnableCaching="false" CompletionListItemCssClass="listItem"  CompletionListHighlightedItemCssClass="itemHighlighted"  CompletionSetCount="10"
                                                                                                TargetControlID="txtcodeinvq"
                                                                                                ID="AutoCompleteExtender6" runat="server" FirstRowSelected="true">
                                                                                            </cc1:AutoCompleteExtender>
                                                                                        </div>
                                                                                    </div>

                                                                                </div>
                                                                                <div class="col-sm-2">
                                                                                    <div class="form-group row">
                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  Width="170" placeholder="Cruei"  runat="server" type="text" ValidationGroup="supply" ID="txtcruei" TabIndex="157"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtcruei" ID="RegularExpressionValidator48" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="supply"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                    </div>

                                                                                </div>
                                                                                <div class="col-sm-3">
                                                                                    <div class="form-group row">

                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  Width="275" placeholder="Name" runat="server" type="text" ValidationGroup="supply" ID="txtName" TabIndex="158"></asp:TextBox><br />
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtName" ID="RegularExpressionValidator46" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="supply"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                    </div>

                                                                                </div>
                                                                                <div class="col-sm-3">
                                                                                    <div class="form-group row">

                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  Width="275" placeholder="Name1" runat="server" type="text" ValidationGroup="supply" ID="txtName1" TabIndex="159"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtName1" ID="RegularExpressionValidator47" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="supply"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                    </div>

                                                                                </div>
                                                                            </div>
                                                                            <div class="row">
                                                                                <div class="col-sm-4">
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-8 col-form-label">
                                                                                            Exporter Party&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                            
                                                                                              <asp:ImageButton id="btnoutinvexp" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15"  Style="margin-top:-250px;" />
                                                                                            
                                                                                          
                                                                                        </label>
                                                                                        <cc1:ModalPopupExtender ID="popupoutinvexp" runat="server" PopupControlID="pnloutinvexp" TargetControlID="btnoutinvexp"
                                                                                            OkControlID="btnYesoutinvexp" CancelControlID="btnNooutinvexp" BackgroundCssClass="modalBackground">
                                                                                        </cc1:ModalPopupExtender>

                                                                                        <asp:Panel ID="pnloutinvexp" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                            <div class="header">
                                                                                                Exporter Party
                                                                                            </div>
                                                                                            <div class="body">
                                                                                                <asp:UpdatePanel ID="upoutinvexp" runat="server" UpdateMode="Conditional">
                                                                                                    <ContentTemplate>
                                                                                                        <asp:TextBox autocomplete="off"  ID="ExporterPartySearch" OnTextChanged="ExporterPartySearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                        <br />
                                                                                                        <asp:GridView ID="ExporterPartyGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ExporterPartyGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" OnRowCommand="ExporterPartyGrid_RowCommand" OnRowDataBound="ExporterPartyGrid_RowDataBound" runat="server" AutoGenerateColumns="false">
                                                                                                            <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>
                                                                                                                    <asp:TemplateField HeaderText="Code" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblCode" runat="server"
                                                                                                                                Text='<%#Eval("OutUserCode")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="Name" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblname" runat="server"
                                                                                                                                Text='<%#Eval("OutUserName")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>


                                                                                                                    <asp:TemplateField HeaderText="Name1" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblName1" runat="server"
                                                                                                                                Text='<%#Eval("OutUserName1")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>

                                                                                                                    <asp:TemplateField HeaderText="CRUEI" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblCRUEI" runat="server"
                                                                                                                                Text='<%#Eval("OutUserCRUEI")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                  <%--  <asp:TemplateField HeaderText="Address" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="ConsigneeAddress" runat="server"
                                                                                                                                Text='<%#Eval("OutUserAddress")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="Address1" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="ConsigneeAddress1" runat="server"
                                                                                                                                Text='<%#Eval("OutUserAddress1")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="City" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="ConsigneeCity" runat="server"
                                                                                                                                Text='<%#Eval("OutUserCity")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                  <asp:TemplateField HeaderText="Sub Contry Code" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="ConsigneeSub" runat="server"
                                                                                                                                Text='<%#Eval("OutUserSubCode")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="Sub Contry" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="ConsigneeSub" runat="server"
                                                                                                                                Text='<%#Eval("OutUserSub")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="City" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="ConsigneePostal" runat="server"
                                                                                                                                Text='<%#Eval("OutUserPostal")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="City" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="ConsigneeCountry" runat="server"
                                                                                                                                Text='<%#Eval("OutUserCountry")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>--%>
                                                                                                                    <asp:TemplateField>
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:LinkButton ID="LnkExporterParty" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkExporterParty_Command">Select </asp:LinkButton>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                </Columns>
                                                                                                               
                                                                                                            
                                                                                                        </asp:GridView>
                                                                                                    </ContentTemplate>
                                                                                                    <%--<Triggers>
<asp:PostBackTrigger ControlID="ExporterPartyGrid" />
  </Triggers>--%>
                                                                                                </asp:UpdatePanel>
                                                                                            </div>
                                                                                            <div class="footer" align="right">
                                                                                                <asp:Button ID="btnYesoutinvexp" runat="server" Text="Yes" CssClass="yes" />
                                                                                                <asp:Button ID="btnNooutinvexp" runat="server" Text="No" CssClass="no" />
                                                                                            </div>
                                                                                        </asp:Panel>
                                                                                        <div class="col-sm-4">
                                                                                            <asp:TextBox autocomplete="off"  Width="100" placeholder="Code" runat="server" type="text" ID="TxtExppartyCode" OnTextChanged="TxtExppartyCode_TextChanged" AutoPostBack="true" TabIndex="160"></asp:TextBox>
                                                                                            <cc1:AutoCompleteExtender ServiceMethod="GetImppartycode"
                                                                                                MinimumPrefixLength="1"
                                                                                                CompletionInterval="100" CompletionListCssClass="ac_results" EnableCaching="false" CompletionListItemCssClass="listItem"  CompletionListHighlightedItemCssClass="itemHighlighted"  CompletionSetCount="10"
                                                                                                TargetControlID="TxtExppartyCode"
                                                                                                ID="AutoCompleteExtender10" runat="server" FirstRowSelected="true">
                                                                                            </cc1:AutoCompleteExtender>
                                                                                        </div>
                                                                                    </div>

                                                                                </div>
                                                                                <div class="col-sm-2">
                                                                                    <div class="form-group row">
                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  Width="170" placeholder="Cruei" ID="TxtExppartyCRUEI" ValidationGroup="supply1" runat="server" TabIndex="161" type="text"></asp:TextBox><br />
                                                                                            <asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator262" runat="server" ControlToValidate="TxtExppartyCRUEI" Display="None" ErrorMessage="Invoice--->Exporter CR UEI is Required" ValidationGroup="Invoice"></asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtExppartyCRUEI" ID="RegularExpressionValidator51" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="supply"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                    </div>

                                                                                </div>
                                                                                <div class="col-sm-3">
                                                                                    <div class="form-group row">
                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  Width="275" placeholder="Name" ID="TxtExppartyName" ValidationGroup="supply1" BackColor="#e8f0fe" runat="server" TabIndex="162" type="text"></asp:TextBox><br />
                                                                                            <asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator271" runat="server" ControlToValidate="TxtExppartyName" Display="None" ErrorMessage="Invoice--->Exporter Name is Required" ValidationGroup="Invoice"></asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtExppartyName" ID="RegularExpressionValidator49" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="supply1"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                        
                                                                                    </div>

                                                                                </div>
                                                                                <div class="col-sm-3">
                                                                                    <div class="form-group row">
                                                                                        <div class="col-sm-12">
                                                                                            <asp:TextBox autocomplete="off"  Width="275" placeholder="Name1" ID="TxtExppartyName1" ValidationGroup="supply1" runat="server" TabIndex="163" type="text"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtExppartyName1" ID="RegularExpressionValidator50" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="supply1"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                    </div>

                                                                                </div>
                                                                            </div>
                                                                            <%--<p>
The invoice information is for internal use only and will not be submitted to Singapore Customs
</p>--%>
                                                                            <div class="row">
                                                                                <div class="col-sm-12" style="text-align:center;">
                                                                                            <asp:Label ID="lblerrorinv" runat="server" Font-Size="Medium" Font-Bold="true" Text="" BackColor="Red" ForeColor="White" Visible="false"></asp:Label>
                                                                                            </div>
                                                                                </div>
                                                                            <div class="row">
                                                                                <div class="col-sm-8">
                                                                                </div>
                                                                                <div id="NewInvDiv" runat="server" visible="false" class="col-sm-4">
                                                                                    <asp:Button ID="NewInvoice" runat="server" CssClass="btn btn-success btn-block" OnClick="NewInvoice_Click" Text="New Invoice" />
                                                                                    <br />
                                                                                </div>
                                                                            </div>


                                                                            <div class="row" id="InvoiceDiv" runat="server">
                                                                                <div class="col-sm-12">
                                                                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                                                                        ShowSummary="False" ValidationGroup="Invoice" />
                                                                                    <div id="InvoiceBtnDiv" runat="server" visible="false" class="row">
                                                                                        <!-- Importer Search -->
                                                                                        <div class="col-sm-4">
                                                                                            <asp:Button ID="btnback" runat="server" CssClass="btn   btn-success" OnClick="btnback_Click" Text="Back" />
                                                                                        </div>
                                                                                        <div class="col-sm-4">
                                                                                            <asp:ValidationSummary ID="ValidationSummary17" runat="server" ShowMessageBox="True"
                                                                                                ShowSummary="False" ValidationGroup="Invoice" />
                                                                                        </div>
                                                                                        <div class="col-sm-4">
                                                                                            <asp:Button ID="Button5" ValidationGroup="Invoice" runat="server" CssClass="btn btn-block btn-success"   Text="Save" OnClick="BtnAddInvoice_Click" />


                                                                                        </div>



                                                                                    </div>
                                                                                   
                                                                                    



                                                                                    <div class="row">
                                                                                        <div class="col-sm-12">
                                                                                            <div class="row Borderdiv" style="width: 100%;">
                                                                                                INVOICE INFORMATION
                                                                                            </div>
                                                                                            <div class="row">
                                                                                                <div class="col-sm-4">
                                                                                                    <p>Serial Number</p>
                                                                                                    <asp:TextBox autocomplete="off"  runat="server"  type="text" ID="txtserial" Enabled="false" TabIndex="164"></asp:TextBox>

                                                                                                    <p>Invoice Number</p>

                                                                                                    <asp:TextBox autocomplete="off"  runat="server"  BackColor="#e8f0fe" type="text"  ID="txtinvNo" ValidationGroup="Invoice" TabIndex="165" class="w3-input w3-hover-green"></asp:TextBox>
                                                                                                    <br />
                                                                                                    <%--<asp:RequiredFieldValidator BackColor="Red"  ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtinvNo" Display ="None"  ErrorMessage="Invoice--->Invoice Number is Required" ValidationGroup="Invoice"></asp:RequiredFieldValidator>--%>
                                                                                                    <br />
                                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtinvNo" ID="RegularExpressionValidator52" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Invoice"></asp:RegularExpressionValidator>

                                                                                                </div>
                                                                                                <div class="col-sm-4">
                                                                                                    <p>Invoice Date</p>

                                                                                                    <div>

                                                                                                        <asp:TextBox autocomplete="off"  ID="txtinvDate1" onkeypress="return noAlphabets(event)" Style="width: 250px;" runat="server" AutoPostBack="true" TabIndex="166" OnTextChanged="txtinvDate1_TextChanged"></asp:TextBox>

                                                                                                        <cc1:CalendarExtender ID="CalendarExtender4" CssClass="cal_Theme1" PopupButtonID="imgPopup" runat="server" TargetControlID="txtinvDate1" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"></cc1:CalendarExtender>
                                                                                                    </div>

                                                                                                    <%--<asp:RequiredFieldValidator BackColor="Red"  ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtinvDate1"  Display="None" ErrorMessage="Invoic--->Invoice Date is Required" ValidationGroup="Invoice"></asp:RequiredFieldValidator>                                               --%>
                                                                                                    <div >
                                                                                                        <p>Term Type</p>
                                                                                                        <asp:DropDownList CssClass="drop" ID="DrpTerms"  TabIndex="167" Height="28" runat="server" OnSelectedIndexChanged="DrpTerms_SelectedIndexChanged" AutoPostBack="true">
                                                                                                        </asp:DropDownList>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div class="col-sm-4">
                                                                                                    <asp:CheckBox Width="265" runat="server" ID="chkindicator" TabIndex="168" Text="Ad Valorem Indicator" />
                                                                                                    <asp:CheckBox Width="265" runat="server" ID="chkrateind" TabIndex="169" Text="Preferential Duty Rate Indicator" />
                                                                                                    <p>Supplier Importer Relationship</p>
                                                                                                    <asp:DropDownList CssClass="drop" ID="DrpSupImpRel"  Height="28" TabIndex="170" runat="server">
                                                                                                        <asp:ListItem Text="--Select--" Value="--Select--" Selected="True"></asp:ListItem>
                                                                                                        <asp:ListItem Text="Ordinary Importer" Value="Ordinary Importer"></asp:ListItem>
                                                                                                        <asp:ListItem Text="Agency" Value="Agency" />
                                                                                                    </asp:DropDownList>
                                                                                                    <br />

                                                                                                </div>
                                                                                            </div>

                                                                                        </div>


                                                                                    </div>
                                                                                </div>


                                                                                <hr />

                                                                                <div id="invoicecrg" runat ="server" visible ="false" class="row">

                                                                                    <div class="col-sm-12">

                                                                                        <div class="row" id="invheader" runat ="server" visible ="true" style="background: linear-gradient(-135deg, #c850c0, #4158d0); color: white; width: 95%; height: 20px; margin-left: 18px;">
                                                                                            <div class="col-sm-4">
                                                                                                Item
                                                                                            </div>
                                                                                            <div class="col-sm-2">
                                                                                                Charges(%)
                                                                                            </div>
                                                                                            <div class="col-sm-1">
                                                                                                Currency
                                                                                            </div>
                                                                                            <div class="col-sm-1">
                                                                                                Ex.Rate
                                                                                            </div>
                                                                                            <div class="col-sm-2">
                                                                                                Amount
                                                                                            </div>
                                                                                            <div class="col-sm-2">
                                                                                                Amount ($)
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row" runat="server" id="TotalInvoice">
                                                                                            <div class="col-sm-4">
                                                                                                <p>Total Invoice</p>
                                                                                            </div>
                                                                                            <div class="col-sm-2">
                                                                                            </div>
                                                                                            <div class="col-sm-1">
                                                                                                <asp:DropDownList CssClass="drop" ID="Drpcurrency1" OnSelectedIndexChanged="Drpcurrency1_SelectedIndexChanged" BackColor="#e8f0fe" AutoPostBack="true" AppendDataBoundItems="true" TabIndex="171" Width="70" runat="server">
                                                                                                </asp:DropDownList>
                                                                                                <br />
                                                                                                <asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator29" runat="server" InitialValue="0" ControlToValidate="Drpcurrency1" ErrorMessage="Required" ValidationGroup="Validation2"></asp:RequiredFieldValidator>
                                                                                            </div>
                                                                                            <div class="col-sm-1">
                                                                                                <asp:Label runat="server" Text="0.00" ID="LblTotalInvoice" ></asp:Label>
                                                                                                <%--<asp:TextBox autocomplete="off"  runat="server" type="text" ID="txtexrate" TabIndex="1" class="form-control"></asp:TextBox>--%>
                                                                                            </div>
                                                                                            <div class="col-sm-2">
                                                                                                <asp:TextBox autocomplete="off"  runat="server" type="text" ValidationGroup="Item" onkeypress="return noAlphabets(event)"  onfocus="removeCommas(this)" OnBlur="addCommas(this)"  ID="TxtTotalInvoice" OnTextChanged="TxtTotalInvoice_TextChanged" AutoPostBack="true" TabIndex="172" Width="100"></asp:TextBox>
                                                                                                <br />
                                                                                              <%--  <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtTotalInvoice" ID="RegularExpressionValidator119" ValidationExpression="^[0-9\s\.]+$" runat="server" ErrorMessage="Not Accepted Special Charector" ValidationGroup="Item"></asp:RegularExpressionValidator>--%>
                                                                                            </div>
                                                                                            <div class="col-sm-2">
                                                                                                <asp:Label runat="server" onfocus="removeCommas(this)" OnBlur="addCommas(this)"  Text="0.00"  ID="SumTotalInvoice"></asp:Label>
                                                                                                <%--<asp:TextBox autocomplete="off"  runat="server" type="text" ID="txtamountdol" TabIndex="1" class="form-control"></asp:TextBox>--%>
                                                                                            </div>
                                                                                        </div>

                                                                                        <div class="row" runat="server" id="OtherTaxableCharge">
                                                                                            <div class="col-sm-4">
                                                                                                <p>Other Taxable Charge</p>
                                                                                            </div>
                                                                                            <div class="col-sm-2">
                                                                                                <asp:TextBox autocomplete="off"  runat="server" Text="0.00" ID="OtherTaxableChargePer" onkeypress="return noAlphabets(event)" OnTextChanged="OtherTaxableChargePer_TextChanged" AutoPostBack="true" TabIndex="173" Width="100"></asp:TextBox>
                                                                                            </div>
                                                                                            <div class="col-sm-1">
                                                                                                <asp:DropDownList CssClass="drop" ID="Drpcurrency2" OnSelectedIndexChanged="Drpcurrency2_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true" Width="70" TabIndex="174" runat="server">
                                                                                                </asp:DropDownList>
                                                                                                <br />
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" InitialValue="0" ControlToValidate="Drpcurrency2" ErrorMessage="Choose Currency"
                                                                                                    Display="Dynamic" ValidationGroup="ItemMasterValidation" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                                            </div>
                                                                                            <div class="col-sm-1">
                                                                                                <asp:Label runat="server" Text="0.00" onfocus="removeCommas(this)" OnBlur="addCommas(this)"  ID="lblOtherTaxableCharge"></asp:Label>
                                                                                            </div>
                                                                                            <div class="col-sm-2">
                                                                                                <asp:TextBox autocomplete="off"  runat="server" type="text" ValidationGroup="Item" onkeypress="return noAlphabets(event)" Text="0.00"  onfocus="removeCommas(this)" OnBlur="addCommas(this)"  ID="TxtOtherTaxableCharge" OnTextChanged="TxtOtherTaxableCharge_TextChanged" AutoPostBack="true" TabIndex="175" Width="100"></asp:TextBox>
                                                                                                <br />
                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtOtherTaxableCharge" ID="RegularExpressionValidator120" ValidationExpression="^[0-9\s\.]+$" runat="server" ErrorMessage="Not Accepted Special Charector" ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                            </div>
                                                                                            <div class="col-sm-2">
                                                                                                <asp:Label runat="server" Text="0.00" onfocus="removeCommas(this)" OnBlur="addCommas(this)"  ID="SumOtherTaxableCharge"></asp:Label>
                                                                                            </div>
                                                                                        </div>

                                                                                        <div class="row" runat="server" id="FrieghtCharges">
                                                                                            <div class="col-sm-4">
                                                                                                <p>Frieght Charges( &nbsp;&nbsp;&nbsp;<asp:CheckBox runat="server" ID="CheckBox1" Text="Inculde Other Taxable Charge" TabIndex="176" />)</p>
                                                                                            </div>
                                                                                            <div class="col-sm-2">
                                                                                                <asp:TextBox autocomplete="off"  runat="server" Text="0.00" ID="FrieghtChargesPer" onkeypress="return noAlphabets(event)" OnTextChanged="FrieghtChargesPer_TextChanged" AutoPostBack="true" TabIndex="177" Width="100"></asp:TextBox>
                                                                                            </div>
                                                                                            <div class="col-sm-1">
                                                                                                <asp:DropDownList CssClass="drop" ID="Drpcurrency3" OnSelectedIndexChanged="Drpcurrency3_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true" TabIndex="178" Width="70" runat="server">
                                                                                                </asp:DropDownList>
                                                                                                <br />
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server" InitialValue="0" ControlToValidate="Drpcurrency3" ErrorMessage="Choose Currency"
                                                                                                    Display="Dynamic" ValidationGroup="ItemMasterValidation" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                                            </div>
                                                                                            <div class="col-sm-1">
                                                                                                <asp:Label runat="server" Text="0.00" onfocus="removeCommas(this)" OnBlur="addCommas(this)"  ID="LblFrieghtCharges"></asp:Label>
                                                                                            </div>
                                                                                            <div class="col-sm-2">
                                                                                                <asp:TextBox autocomplete="off"  runat="server" type="text" ValidationGroup="Item" Text="0.00" onkeypress="return noAlphabets(event)"  onfocus="removeCommas(this)" OnBlur="addCommas(this)"  ID="TxtFrieghtCharges" OnTextChanged="TxtFrieghtCharges_TextChanged" AutoPostBack="true" TabIndex="179" Width="100"></asp:TextBox>
                                                                                                <br />
                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtFrieghtCharges" ID="RegularExpressionValidator121" ValidationExpression="^[0-9\s\.]+$" runat="server" ErrorMessage="Not Accepted Special Charector" ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                            </div>
                                                                                            <div class="col-sm-2">
                                                                                                <asp:Label runat="server" Text="0.00" onfocus="removeCommas(this)" OnBlur="addCommas(this)"  ID="SumFrieghtCharges"></asp:Label>
                                                                                            </div>
                                                                                        </div>

                                                                                        <div class="row" runat="server" id="InsuranceCharges">
                                                                                            <div class="col-sm-4">
                                                                                                <p>Insurance Charges( &nbsp;&nbsp;&nbsp;<asp:CheckBox runat="server" ID="chkchrge" Text="Inculde Other Taxable Charge" TabIndex="180" />)</p>
                                                                                            </div>
                                                                                            <div class="col-sm-2">
                                                                                                <asp:TextBox autocomplete="off"  runat="server" Text="0.00" ID="InsuranceChargesPer" onkeypress="return noAlphabets(event)"  onfocus="removeCommas(this)" OnBlur="addCommas(this)"  OnTextChanged="InsuranceChargesPer_TextChanged" AutoPostBack="true" TabIndex="182" Width="100"></asp:TextBox>
                                                                                            </div>
                                                                                            <div class="col-sm-1">
                                                                                                <asp:DropDownList CssClass="drop" ID="Drpcurrency4" OnSelectedIndexChanged="Drpcurrency4_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true" TabIndex="182" Width="70" runat="server">
                                                                                                </asp:DropDownList>
                                                                                                <br />
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" InitialValue="0" ControlToValidate="Drpcurrency4" ErrorMessage="Choose Currency"
                                                                                                    Display="Dynamic" ValidationGroup="ItemMasterValidation" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                                            </div>
                                                                                            <div class="col-sm-1">
                                                                                                <asp:Label runat="server" Text="0.00" onfocus="removeCommas(this)" OnBlur="addCommas(this)"  ID="lblInsuranceCharges"></asp:Label>
                                                                                            </div>
                                                                                            <div class="col-sm-2">
                                                                                                <asp:TextBox autocomplete="off"  runat="server" type="text" Text="0.00" ValidationGroup="Item" onkeypress="return noAlphabets(event)"  onfocus="removeCommas(this)" OnBlur="addCommas(this)"  ID="TxtInsuranceCharges" TabIndex="183" OnTextChanged="TxtInsuranceCharges_TextChanged" AutoPostBack="true" Width="100"></asp:TextBox>
                                                                                                <br />
                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtInsuranceCharges" ID="RegularExpressionValidator122" ValidationExpression="^[0-9\s\.]+$" runat="server" ErrorMessage="Not Accepted Special Charector" ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                            </div>
                                                                                            <div class="col-sm-2">
                                                                                                <asp:Label runat="server" Text="0.00" onfocus="removeCommas(this)" OnBlur="addCommas(this)"  ID="SumInsuranceCharges"></asp:Label>
                                                                                            </div>
                                                                                        </div>

                                                                                        <div class="row" runat="server" id="CostInsuranceandFreight">
                                                                                            <div class="col-sm-4">
                                                                                                <p>Cost, Insurance and Freight</p>
                                                                                            </div>
                                                                                            <div class="col-sm-2">
                                                                                            </div>
                                                                                            <div class="col-sm-1">
                                                                                            </div>
                                                                                            <div class="col-sm-1">
                                                                                            </div>
                                                                                            <div class="col-sm-2">
                                                                                            </div>
                                                                                            <div class="col-sm-2">
                                                                                                <asp:Label runat="server" Text="0.00" onfocus="removeCommas(this)" OnBlur="addCommas(this)"  ID="LblSumOFTotal"></asp:Label>
                                                                                            </div>
                                                                                        </div>

                                                                                        <div class="row" runat="server" id="GST">
                                                                                            <div class="col-sm-4">
                                                                                                <p>GST</p>
                                                                                            </div>
                                                                                            <div class="col-sm-2">
                                                                                                <asp:TextBox autocomplete="off"  Width="100" runat="server" Enabled="false" Text="7" ID="LblGSTpercentage" TabIndex="184"></asp:TextBox>
                                                                                            </div>
                                                                                            <div class="col-sm-1">
                                                                                            </div>
                                                                                            <div class="col-sm-1">
                                                                                            </div>
                                                                                            <div class="col-sm-2">
                                                                                            </div>
                                                                                            <div class="col-sm-2">
                                                                                                <asp:Label runat="server" Text="0.00" ID="lblGSTAmount"></asp:Label>
                                                                                            </div>
                                                                                        </div>
                                                                                        <hr />
                                                                                        <div class="row">
                                                                                            <!-- Importer Search -->

                                                                                            <div class="col-sm-8">
                                                                                            </div>
                                                                                            <div class="col-sm-4">
                                                                                                <asp:Button ID="BtnAddInvoice" ValidationGroup="Invoice" runat="server" Visible ="false" CssClass="btn btn-block btn-success" Text="Add Invoice" OnClick="BtnAddInvoice_Click" />

                                                                                            </div>


                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <br />
                                                                            <br />
                                                                            
                                                                            <div class="row">

    <div class="col-sm-12">

        <center>

            <div class="flex justify-between gap-4 md:flex-nowrap flex-wrap mt-6">
                <asp:Button ID="btnprevinvoice" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" runat="server" OnClick="btnprevinvoice_Click" Text="Previous" TabIndex="102" />

                <asp:Button ID="btnresetinvoice" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" runat="server" OnClick="btnresetinvoice_Click" Text="Reset" TabIndex="104" />
                <asp:Button ID="btnnextinvoice" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" runat="server" OnClick="btnnextinvoice_Click" Text="Next" TabIndex="105" />
            </div>
        </center>

    </div>
    <div class="col-sm-1">
    </div>
</div>

                                                                            <br />
                                                                            <div id="InvoiceGrid" runat="server">
                                                                                <asp:TextBox autocomplete="off"  ID="AddInvoiceSearch" OnTextChanged="AddInvoiceSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                <br />
                                                                                <asp:GridView ID="AddInvoiceGrid" OnRowDeleting="AddInvoiceGrid_RowDeleting" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="AddInvoiceGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                                                   <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>
                                                                                        <asp:TemplateField HeaderText="Delete" Visible="false">
                                                                                            <ItemTemplate>

                                                                                                <asp:LinkButton data-target='<%#"#"+DataBinder.Eval(Container.DataItem,"Id")%>' Width="11" OnClick="imgInvoiceDelete_Click" Height="11" ID="imgInvoiceDelete" runat="server"><i class='fa fa-trash' style="color:red;"> </i></asp:LinkButton>



                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Edit">
                                                                                            <ItemTemplate>


                                                                                                <asp:ImageButton ImageUrl="~/IMG/edit.png" Width="11" Height="11" OnClick="InvoiceEdit_Click" ID="InvoiceEdit" runat="server" />




                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="ID" Visible="false" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblID" runat="server"
                                                                                                    Text='<%#Eval("Id")%>'>
                                                                                                </asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="S.no" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblCode" runat="server"
                                                                                                    Text='<%#Eval("SNo")%>'>
                                                                                                </asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Invoice No" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblName" runat="server"
                                                                                                    Text='<%#Eval("InvoiceNo")%>'>
                                                                                                </asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>

                                                                                        <asp:TemplateField HeaderText="Invoice Date" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblName1" runat="server"
                                                                                                    Text='<%#Eval("InvoiceDate")%>'>
                                                                                                </asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="INV CUR" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblCRUEI" runat="server"
                                                                                                    Text='<%#Eval("TICurrency")%>'>
                                                                                                </asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Invoice Total (GST)" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblCRUEI1" runat="server"
                                                                                                    Text='<%#Eval("GSTSUMAmount")%>'>
                                                                                                </asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Invoice Total Amt" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbltotalinvamt" runat="server"
                                                                                                    Text='<%#Eval("TIAmount")%>'>
                                                                                                </asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                    <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                                                                </asp:GridView>
                                                                            </div>

                                                                           
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </ContentTemplate>
                                                            </cc1:TabPanel>
                                                        

                                                           
                                                            <cc1:TabPanel ID="Item" runat="server" CssClass="nn" HeaderText="Item">
                                                                <ContentTemplate>
                                                                    <asp:UpdatePanel ID="outitem" UpdateMode="Conditional" runat="server">
                                                                        <ContentTemplate>
                                                                            <div class="row">
                                                                                <div class="col-sm-8">
                                                                                </div>
                                                                                <div id="btnitemDiv" runat="server" visible="false" class="col-sm-4">
                                                                                    <asp:Button ID="BtnAddNEWItem" runat="server" CssClass="btn btn-success btn-block" OnClick="BtnAddNEWItem_Click" Text="New Item" />
                                                                                    <br />
                                                                                </div>
                                                                            </div>


                                                                            <div id="ItemDiv" runat="server">

                                                                                 
                                                                                                    
                                                                                <div class="row">
                                                                                    <div class="col-sm-4">

                                                                                         <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                <p id="P3" runat="server" >Serial Number</p>
                                                                                            </label>
                                                                                            <div class="col-sm-9">
                                                                                               <asp:TextBox autocomplete="off"  runat="server"   type="text" Enabled="false" ID="TxtSerialNo" ></asp:TextBox>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server" ControlToValidate="TxtSerialNo" ErrorMessage="Please Enter Serial No"
                                                                                                        Display="None" ValidationGroup="Item" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                                                    <br />
                                                                                            </div>
                                                                                        </div>

                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                <p id="inhab" runat="server">In HAWB/HBL</p>
                                                                                                <p id="phawb" runat="server">HAWB</p>
                                                                                                <p id="inhbl" runat="server">HBL</p>
                                                                                            </label>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:DropDownList ID="TxtHAWB"  Height="25" CssClass="drop" runat="server" ValidationGroup="Item" TabIndex="189" AutoPostBack="true" OnTextChanged="TxtHAWB_TextChanged"></asp:DropDownList>
                                                                                                <%--<asp:TextBox autocomplete="off"  Width="240" runat="server" BackColor="#e8f0fe" type="text" ID="TxtHAWB" OnTextChanged="TxtHAWB_TextChanged" AutoPostBack="true" TabIndex="172"></asp:TextBox>--%>
                                                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator49" runat="server" ControlToValidate="TxtHAWB" ErrorMessage="Item--->Please Enter In HAWB/OBL"
Display="None" ValidationGroup="ItemMasterValidation" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtHAWB" ID="RegularExpressionValidator57" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                                <asp:Button ID="Button9" runat="server" Visible="false" Text="Copy All" />
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                Out HAWB/HBL
                                                                                            </label>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:DropDownList ID="txtOutHAWB"  Height="25" CssClass="drop" runat="server" ValidationGroup="Item" TabIndex="190"></asp:DropDownList>
                                                                                                <%--<asp:TextBox autocomplete="off"  Width="240" runat="server" BackColor="#e8f0fe" type="text" ID="txtOutHAWB" TabIndex="173"></asp:TextBox>--%>
                                                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator56" runat="server" ControlToValidate="txtOutHAWB" ErrorMessage="Item--->Please Enter Out HAWB/OBL"
Display="None" ValidationGroup="Item" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                                                                <br />
                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtOutHAWB" ID="RegularExpressionValidator100" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                            </div>
                                                                                        </div>
                                                                                      <%--  <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Term Type
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  ID="txttermtyp"  runat="server" TabIndex="107" type="text" Style="text-transform: uppercase"></asp:TextBox>                                                                                                                                                                                 </div>
                                                                                    </div>--%>
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                Item Code
                                                                                            </label>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:TextBox autocomplete="off"  ID="TxtInHouseItem"  AutoPostBack="true" OnTextChanged="TxtInHouseItem_TextChanged" runat="server" TabIndex="191" type="text"></asp:TextBox><br />
                                                                                                <cc1:AutoCompleteExtender ServiceMethod="GetInhouse"
                                                                                                    MinimumPrefixLength="1"
                                                                                                    CompletionInterval="100" CompletionListCssClass="ac_results" EnableCaching="false" CompletionListItemCssClass="listItem"  CompletionListHighlightedItemCssClass="itemHighlighted"  CompletionSetCount="10"
                                                                                                    TargetControlID="TxtInHouseItem"
                                                                                                    ID="AutoCompleteExtender11" runat="server" FirstRowSelected="true">
                                                                                                </cc1:AutoCompleteExtender>
                                                                                                <asp:Label ID="lblhserror" Visible="false" ForeColor="White" Font-Bold="true" BackColor="Brown" runat="server"></asp:Label>
                                                                                                <asp:Label ID="lbldhserror" Visible="false" ForeColor="White" Font-Bold="true" BackColor="Brown" runat="server"></asp:Label>
                                                                                                <br />
                                                                                                </div>
                                                                                            </div>
                                                                                          <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                HS Code
                                                                                            </label>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:TextBox autocomplete="off"   ID="TxtHSCodeItem" BackColor="#e8f0fe" ValidationGroup="Item" OnTextChanged="TxtHSCodeItem_TextChanged" AutoPostBack="true" runat="server" TabIndex="192" type="text"></asp:TextBox><br />
                                                                                                <cc1:AutoCompleteExtender ServiceMethod="GetHSCodeItem"
                                                                                                    MinimumPrefixLength="1"
                                                                                                    CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem"  CompletionListHighlightedItemCssClass="itemHighlighted"  EnableCaching="false" CompletionSetCount="10"
                                                                                                    TargetControlID="TxtHSCodeItem"
                                                                                                    ID="AutoCompleteExtender12" runat="server" FirstRowSelected="true">
                                                                                                </cc1:AutoCompleteExtender>
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator44" runat="server" ControlToValidate="TxtHSCodeItem" ErrorMessage="Please Enter HS Code"
                                                                                                    Display="None" ValidationGroup="Item" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                                                <br />
                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtHSCodeItem" ID="RegularExpressionValidator54" ValidationExpression="^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 10 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                Description
                                                                                            </label>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:TextBox autocomplete="off"   ID="TxtDescription" BackColor="#e8f0fe" ValidationGroup="Item" OnTextChanged="TxtDescription_TextChanged" AutoPostBack="true" TextMode="MultiLine" Height="75" Width ="250" runat="server" Style="text-transform :uppercase;font-weight: bold;" MaxLength="512" TabIndex="193"  type="text"></asp:TextBox>
                                                                                                <br />
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" ControlToValidate="TxtDescription" ErrorMessage="Please Enter Description"
                                                                                                    Display="None" ValidationGroup="Item" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtDescription" ID="RegularExpressionValidator53" ValidationExpression="^[\s\S]{0,512}$" runat="server" ErrorMessage="Maximum 512 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>


                                                                                                <asp:Label ID="LblCount" runat="server"  Text="" ></asp:Label>

                                                                                            </div>
                                                                                        </div>

                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                COO&nbsp;
                                                                                                
                                                                                                  <asp:ImageButton id="btnoutorgin" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15"  Style="margin-top:-250px;" />
                                                                                              
                                                                                            </label>
                                                                                            <cc1:ModalPopupExtender ID="popupoutorgin" runat="server" PopupControlID="pnloutorgin" TargetControlID="btnoutorgin"
                                                                                                OkControlID="btnYesoutorgin" CancelControlID="btnNooutorgin" BackgroundCssClass="modalBackground">
                                                                                            </cc1:ModalPopupExtender>

                                                                                            <asp:Panel ID="pnloutorgin" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                                <div class="header">
                                                                                                  Origin Country
                                                                                                </div>
                                                                                                <div class="body">
                                                                                                    <asp:UpdatePanel ID="upoutorgin" runat="server" UpdateMode="Conditional">
                                                                                                        <ContentTemplate>
                                                                                                            <asp:TextBox autocomplete="off"  ID="CountrySearchItem" OnTextChanged="CountrySearchItem_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                            <br />
                                                                                                            <asp:GridView ID="CountryGridItem" OnPageIndexChanging="CountryGridItem_PageIndexChanging" PageSize="5" AllowPaging="True" DataKeyNames="Id" CssClass="table table-striped table-bordered table-hover" OnRowCommand="CountryGridItem_RowCommand" OnRowDataBound="CountryGridItem_RowDataBound" runat="server" AutoGenerateColumns="false">
                                                                                                               <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>



                                                                                                                    <asp:TemplateField HeaderText="CountryCode" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblName" runat="server"
                                                                                                                                Text='<%#Eval("CountryCode")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>

                                                                                                                    <asp:TemplateField HeaderText="Description" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblName1" runat="server"
                                                                                                                                Text='<%#Eval("Description")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>


                                                                                                                    <asp:TemplateField>
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:LinkButton ID="lnkCountryItem" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="lnkCountryItem_Click">Select </asp:LinkButton>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                </Columns>
                                                                                                            </asp:GridView>
                                                                                                        </ContentTemplate>
                                                                                                        <%--<Triggers>
<asp:PostBackTrigger ControlID="CountryGridItem" />
  </Triggers>--%>
                                                                                                    </asp:UpdatePanel>
                                                                                                </div>
                                                                                                <div class="footer" align="right">
                                                                                                    <asp:Button ID="btnYesoutorgin" runat="server" Text="Yes" CssClass="yes" />
                                                                                                    <asp:Button ID="btnNooutorgin" runat="server" Text="No" CssClass="no" />
                                                                                                </div>
                                                                                            </asp:Panel>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:TextBox autocomplete="off"  Width="75" ID="TxtCountryItem" BackColor="#e8f0fe" OnTextChanged="TxtCountryItem_TextChanged" AutoPostBack="true" runat="server" TabIndex="194" type="text"></asp:TextBox>
                                                                                                <asp:TextBox autocomplete="off"   ID="txtcname" Width ="175" runat="server" Enabled="false"></asp:TextBox>
                                                                                                <cc1:AutoCompleteExtender ServiceMethod="GetCountryItem"
                                                                                                    MinimumPrefixLength="1"
                                                                                                    CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem"  CompletionListHighlightedItemCssClass="itemHighlighted"  EnableCaching="false" CompletionSetCount="10"
                                                                                                    TargetControlID="TxtCountryItem"
                                                                                                    ID="AutoCompleteExtender13" runat="server" FirstRowSelected="true">
                                                                                                </cc1:AutoCompleteExtender>
                                                                                                <br />
                                                                                                <asp:Label ID="lblcoutryChk" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator46" runat="server" ControlToValidate="TxtCountryItem" ErrorMessage="Item--->Please Enter Country Of Origin"
                                                                                                    Display="None" ValidationGroup="Item" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            </label>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:CheckBox ID="ChkBGIndicator" TabIndex ="195" runat="server" Text="DG Indicator" />
                                                                                                <asp:CheckBox ID="ChkUnbrand" OnCheckedChanged="ChkUnbrand_CheckedChanged" AutoPostBack="true" runat="server" Text="UNBRANDED" TabIndex="196" />
                                                                                            </div>
                                                                                        </div>
                                                                                          <div class="form-group row">
                                                                                              <div class="col-sm-3">
                                                                                                  </div>
                                                                                                  <div class="col-sm-9">
                                                                                       <asp:Button ID="btnprev" CssClass="previous" Enabled ="false" width="50px"  runat="server" class="btn btn-info btn-lg" OnClick="btnprev_Click" Text="<<"  /><asp:TextBox runat="server" id="itemno" Font-Bold="true" Width="100px" Enabled="false"></asp:TextBox> <asp:Button ID="btnnxt" CssClass="previous" Enabled ="false" width="50px" runat="server" class="btn btn-info btn-lg" OnClick="btnnxt_Click" Text=">>"  />
                                                                                                   </div>
                                                                                                    </div>

                                                                                      
                                                                                    </div>

                                                                                    <div class="col-sm-4">

                                                                                          <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                Brand      
                                                                                            </label>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:TextBox autocomplete="off" MaxLength="35"   ID="TxtBrand" runat="server" ValidationGroup="Item" TabIndex="197" type="text"></asp:TextBox>
                                                                                                <%--<asp:RequiredFieldValidator BackColor="#e8f0fe" ID="RequiredFieldValidator47" runat="server" ControlToValidate="TxtBrand" ErrorMessage="Item--->Please Enter Brand"
Display="None" ValidationGroup="Item" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtBrand" ID="RegularExpressionValidator55" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                Model    


                                                                                            </label>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:TextBox autocomplete="off"   ID="TxtModel" runat="server" ValidationGroup="Item" TabIndex="198" type="text"></asp:TextBox>
                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtModel" ID="RegularExpressionValidator56" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator48" runat="server" ControlToValidate="TxtModel" ErrorMessage="Please Enter Model"
Display="None" ValidationGroup="Item" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div id="Vehicle" runat="server" visible="false">
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-3 col-form-label">Vehicle Type</label>
                                                                                                <div class="col-sm-9">
                                                                                                    <asp:DropDownList ID="DrpVehicleType" CssClass="drop" runat="server"  Height="25" ></asp:DropDownList>
                                                                                                </div>
                                                                                            </div>


                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-3 col-form-label">Engine Capacity</label>
                                                                                                <div class="col-sm-9">
                                                                                                    <asp:TextBox autocomplete="off" onkeypress="return noAlphabets(event)"  runat="server" type="text" Text="" ID="TextBox18" Width="175" ></asp:TextBox>
                                                                                                    <asp:DropDownList CssClass="drop" ID="DrpVehicleCapacity" runat="server" Width="175" Height="25" TabIndex="98"></asp:DropDownList>
                                                                                                </div>
                                                                                            </div>

                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-3 col-form-label">Original Registration Date</label>
                                                                                                <div class="col-sm-9">
                                                                                                  <%--  <input type='Date' id='OriginalRegDate' style="width: 240px;" runat="server" />
                                                                                                    <span class="input-group-addon" style="display: none;">
                                                                                                        <span class="glyphicon glyphicon-calendar"></span>
                                                                                                    </span>--%>
                                                                                                    <asp:TextBox autocomplete="off"  onkeypress="return noAlphabets(event)" ID="txtOriginalRegDate" OnTextChanged="txtOriginalRegDate_TextChanged" AutoPostBack ="true"  runat="server"></asp:TextBox>
                                                                                <cc1:CalendarExtender ID="CalendarExtender7" CssClass="cal_Theme1" PopupButtonID="imgPopup" runat="server" TargetControlID="txtOriginalRegDate" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"></cc1:CalendarExtender>


                                                                                                </div>
                                                                                            </div>


                                                                                        </div>
                                                                                        <div id="totDuticableQtyDiv" runat="server" visible="false">
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">Duti Quantity</label>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:TextBox autocomplete="off"  runat="server"   onkeypress="return noAlphabets(event)" ValidationGroup="Item" type="text" Width="175" Text="0.00" ID="TxtTotalDutiableQuantity" AutoPostBack="true" OnTextChanged="TxtTotalDutiableQuantity_TextChanged" TabIndex="199"></asp:TextBox>
                                                                                                <asp:DropDownList CssClass="drop" ID="TDQUOM" runat="server" Width="175" Height="25" TabIndex="200"></asp:DropDownList>
                                                                                                <br />

                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtTotalDutiableQuantity" ID="RegularExpressionValidator58" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                            </div>
                                                                                        </div>
                                                                                          </div>
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-3 col-form-label">Total Duti Quantity</label>
                                                                                                <div class="col-sm-9">
                                                                                                    <asp:TextBox autocomplete="off"  runat="server" type="text"  onkeypress="return noAlphabets(event)" ValidationGroup="Item" Width="75" Text="0.00" ID="txttotDutiableQty" TabIndex="201"></asp:TextBox>
                                                                                                    <asp:DropDownList CssClass="drop" ID="ddptotDutiableQty" runat="server" Width="175" Height="25" TabIndex="202"></asp:DropDownList>
                                                                                                    <br />
                                                                                                </div>
                                                                                            </div>
                                                                                      
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">Invoice Quantity</label>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:TextBox autocomplete="off"  runat="server"  type="text"  onkeypress="return noAlphabets(event)" ValidationGroup="Item" Text="0.00" ID="TxtInvQty" OnTextChanged="TxtInvQty_TextChanged" AutoPostBack="true" TabIndex="203"></asp:TextBox>
                                                                                                <br />
                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtInvQty" ID="RegularExpressionValidator59" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator51" runat="server" ControlToValidate="TxtInvQty" ErrorMessage="Item--->Please Enter Quantity"
                                                                                                    Display="None" ValidationGroup="Item" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                                                <br />
                                                                                                <asp:Label runat="server" ID="lblinvqty" Visible="false" ForeColor="Red" BackColor="Yellow"></asp:Label>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">Hs Quantity</label>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:TextBox autocomplete="off"  runat="server" Width="75" onkeypress="return noAlphabets(event)" ValidationGroup="Item" BackColor="#e8f0fe" type="text" OnTextChanged="TxtHSQuantity_TextChanged" ID="TxtHSQuantity" TabIndex="204"></asp:TextBox>
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="TxtHSQuantity" ErrorMessage="Item--->Please Enter HS Quantity"
                                                                                                    Display="None" ValidationGroup="Item" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                                                <asp:DropDownList CssClass="drop" ID="HSQTYUOM" runat="server" Width="175" OnSelectedIndexChanged="HSQTYUOM_SelectedIndexChanged" AutoPostBack="true" Height="25" TabIndex="205"></asp:DropDownList>
                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtHSQuantity" ID="RegularExpressionValidator62" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div id="AlcoholDiv" runat="server" visible="false">
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-3 col-form-label">Alcohol Percentage</label>
                                                                                                <div class="col-sm-9">
                                                                                                    <asp:TextBox autocomplete="off"  runat="server" onkeypress="return noAlphabets(event)"  ValidationGroup="Item" type="text" Text="0.00" ID="txtAlcoholPer" TabIndex="206"></asp:TextBox>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>


                                                                                          <div class="form-group row">
                                                                                      <div class="row Borderdiv" style="width: 90%">
                                                                                    Additional Features
                                                                                      </div>
                                                                                          </div>
                                                                                           <div class="form-group row">
                                                                                            <div class="col-sm-3">
                                                                                                <asp:CheckBox ID="ChkPackInfo" OnCheckedChanged="ChkPackInfo_CheckedChanged" runat="server" AutoPostBack="true" Text="Packing Info" TabIndex="214" Width="150" Style="text-transform: lowercase" />
                                                                                            </div>
                                                                                            <div class="col-sm-3">
                                                                                                <asp:CheckBox ID="Chkitemcasc" runat="server" OnCheckedChanged="Chkitemcasc_CheckedChanged" AutoPostBack="true" Text="Item CASC" TabIndex="223" Width="150" Style="text-transform: lowercase" />
                                                                                            </div>
                                                                                            <div class="col-sm-3">
                                                                                                <asp:CheckBox ID="ChkTariff" runat="server" OnCheckedChanged="ChkTariff_CheckedChanged" AutoPostBack="true" Text="Tariff" TabIndex="241" Width="150" Style="text-transform: lowercase" />
                                                                                            </div>
                                                                                            <div class="col-sm-3">
                                                                                                <asp:CheckBox ID="Chklot" runat="server" OnCheckedChanged="Chklot_CheckedChanged" AutoPostBack="true" Text="LOT Identification" TabIndex="256" Width="150" Style="text-transform: lowercase" />
                                                                                            </div>
                                                                                        </div>

                                                                                    </div>

                                                                                    <div class="col-sm-4">
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">Invoice</label>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:DropDownList CssClass="drop" runat="server" type="text"  Height="25" ID="DrpInvoiceNo" OnSelectedIndexChanged="DrpInvoiceNo_SelectedIndexChanged" AutoPostBack="true" TabIndex="207"></asp:DropDownList>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                Currency ( Unit Price 
                                                                                                <asp:CheckBox ID="ChkUnitPrice" CausesValidation="true" OnCheckedChanged="ChkUnitPrice_CheckedChanged" AutoPostBack="true" runat="server" TabIndex="208" />Auto )
                                                                                            </label>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:DropDownList CssClass="drop" ID="DRPCurrency" BackColor="#e8f0fe" CausesValidation="true" OnSelectedIndexChanged="DRPCurrency_SelectedIndexChanged" TabIndex="209" AutoPostBack="true" runat="server" Width="175" Height="25"></asp:DropDownList>
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" InitialValue="0" ControlToValidate="DRPCurrency" ErrorMessage="Item--->Choose Currency"
                                                                                                    Display="None" ValidationGroup="Item" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                                                <asp:TextBox autocomplete="off"  ID="TxtExchangeRate" Enabled="false" Text="0.00" runat="server" Width="175" Height="25" TabIndex="210"></asp:TextBox>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div id="OptionalCharges" visible ="false" runat="server">
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                    Optional Charges
                                                                                                </label>
                                                                                                <div class="col-sm-9">
                                                                                                    <asp:DropDownList CssClass="drop" ID="DrpOptionalUom" BackColor="#e8f0fe" CausesValidation="true" OnSelectedIndexChanged="DrpOptionalUom_SelectedIndexChanged"  AutoPostBack="true" runat="server" Width="175" Height="25"></asp:DropDownList>
                                                                                                    <asp:RequiredFieldValidator BackColor="Red" InitialValue="0" ID="RequiredFieldValidator6" runat="server" ControlToValidate="DrpOptionalUom" Display="None" ErrorMessage="Item --> Plase Select Currency info" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                                    <asp:TextBox autocomplete="off"  runat="server" Text="0.00" Width="175" ID="TxtOptionalPrice" OnTextChanged="TxtOptionalPrice_TextChanged" AutoPostBack="true" ></asp:TextBox>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                </label>
                                                                                                <div class="col-sm-9">
                                                                                                    <asp:TextBox autocomplete="off"  ID="TxtOptionalExchageRate" Enabled="false"  Text="0.00" runat="server" Width="175" Height="25"></asp:TextBox>
                                                                                                    <asp:RequiredFieldValidator BackColor="Red" InitialValue="0.00" ID="RequiredFieldValidator24" runat="server" ControlToValidate="TxtExchangeRate" Display="None" ErrorMessage="Item --> Plase Enter Amount" ValidationGroup="Item"></asp:RequiredFieldValidator>
                                                                                                    <asp:TextBox autocomplete="off"  runat="server" type="text" ID="TxtOptionalSumExRate" Width="175"  Text="0.00"></asp:TextBox>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                Total Line Amount 
                                                                                            </label>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:Label ID="Lbl3" Font-Size="9" onkeypress="return noAlphabets(event)" Text="Total Line Amount" onfocus="removeCommas(this)"  runat="server" Visible="false" Width="100"></asp:Label>
                                                                                                <asp:TextBox autocomplete="off"  BackColor="#e8f0fe" onkeypress="return noAlphabets(event)" CausesValidation="true" ValidationGroup="Item" OnTextChanged="TxtTotalLineAmount_TextChanged" Text="0.00" AutoPostBack="true" runat="server"  type="text" ID="TxtTotalLineAmount" TabIndex="211"></asp:TextBox>
                                                                                                <asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator26" runat="server" ControlToValidate="TxtTotalLineAmount" Display="None" ErrorMessage="Item --> Enter Line Amount" ValidationGroup="Item"></asp:RequiredFieldValidator>
                                                                                               <%-- <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtTotalLineAmount" ID="RegularExpressionValidator123" ValidationExpression="^[0-9\s\.]+$" runat="server" ErrorMessage="Not Accepted Special Charector" ValidationGroup="Item"></asp:RegularExpressionValidator>--%>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                Total INV Chrg(SGD) 
                                                                                            </label>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:Label Font-Size="9" Text="Total Line Charges(SGD)" ID="Label3" runat="server" Width="100" Visible="false"></asp:Label>
                                                                                                <asp:TextBox autocomplete="off"  runat="server" type="text"  ID="TxtTotalLineCharges" Text="0.00" TabIndex="212"></asp:TextBox>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                CIF/FOB (SGD) 
                                                                                            </label>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:Label Font-Size="9" Text="CIF/FOB (SGD)" ID="Label4" runat="server" Visible="false" Width="100"></asp:Label>
                                                                                                <asp:TextBox autocomplete="off"  runat="server" type="text"  ID="TxtCIFFOB" Text="0.00" TabIndex="213"></asp:TextBox>
                                                                                            </div>
                                                                                        </div>

                                                                                      
                                                                                         
                                                                                        <div id="PackingInfo" visible="false" runat="server">
                                                                                             <div class="form-group row">
                                                                                      <div class="row Borderdiv" style="width: 90%">
                                                                                    Packing Info
                                                                                      </div>
                                                                                          </div>
                                                                                     
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                    Outer Pack Qty 
                                                                                                </label>
                                                                                                <div class="col-sm-9">
                                                                                                    <asp:TextBox autocomplete="off" onkeypress="return noAlphabets(event)"  runat="server" Text="0" type="text" ID="TxtOPQty" Width="175" AutoPostBack="true" OnTextChanged="TxtOPQty_TextChanged" ValidationGroup="Item" TabIndex="215"></asp:TextBox>
                                                                                                    <asp:DropDownList CssClass="drop" ID="DRPOPQUOM" runat="server" Width="75" Height="25" TabIndex="216"></asp:DropDownList>
                                                                                                    <br />
                                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtOPQty" ID="RegularExpressionValidator64" ValidationExpression="^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 8 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                    In Pack Qty 
                                                                                                </label>
                                                                                                <div class="col-sm-9">
                                                                                                    <asp:TextBox autocomplete="off" onkeypress="return noAlphabets(event)"  runat="server" Text="0" type="text" Width="175" ID="TxtIPQty" AutoPostBack="true" OnTextChanged="TxtIPQty_TextChanged" ValidationGroup="Item" TabIndex="217"></asp:TextBox>
                                                                                                    <asp:DropDownList CssClass="drop" ID="DRPIPQUOM" runat="server" Width="75" Height="25" TabIndex="218"></asp:DropDownList>
                                                                                                    <br />
                                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtIPQty" ID="RegularExpressionValidator63" ValidationExpression="^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 8 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                    Inner Pack Qty 
                                                                                                </label>
                                                                                                <div class="col-sm-9">
                                                                                                    <asp:TextBox autocomplete="off" onkeypress="return noAlphabets(event)"  runat="server" Text="0" type="text" Width="175" ID="TxtINPQty" ValidationGroup="Item" AutoPostBack="true" OnTextChanged="TxtINPQty_TextChanged" TabIndex="219"></asp:TextBox>
                                                                                                    <asp:DropDownList CssClass="drop" ID="DRPINNPQUOM" runat="server" Width="75" Height="25" TabIndex="220"></asp:DropDownList>
                                                                                                    <br />
                                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtINPQty" ID="RegularExpressionValidator65" ValidationExpression="^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 8 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                    Inmost Pack Qty 
                                                                                                </label>
                                                                                                <div class="col-sm-9">
                                                                                                    <asp:TextBox autocomplete="off" onkeypress="return noAlphabets(event)"  runat="server" Text="0" type="text" ID="TxtIMPQty" Width="175" AutoPostBack="true" OnTextChanged="TxtIMPQty_TextChanged" ValidationGroup="Item" TabIndex="221"></asp:TextBox>
                                                                                                    <asp:DropDownList CssClass="drop" ID="DRPIMPQUOM" runat="server" Width="75" Height="25" TabIndex="222"></asp:DropDownList>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator57" runat="server" ControlToValidate="TxtIMPQty" ErrorMessage="Please Enter In HAWB/OBL"
                                                                                                        Display="Dynamic" ValidationGroup="ItemMasterValidation" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtIMPQty" ID="RegularExpressionValidator66" ValidationExpression="^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 8 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="col-sm-12 bg">
                                                                                    <div class="row">
                                                                                        <div class="col-sm-8">
                                                                                            <!-- INHOUSE Search -->
                                                                                            <div class="modal fade" id="Inhouse" role="dialog">
                                                                                                <div class="modal-dialog">

                                                                                                    <!-- Modal content-->
                                                                                                    <div class="modal-content">
                                                                                                        <div class="modal-header">
                                                                                                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                                                                            <h4 class="modal-title">Inhouse Item Code
                                                                                                            </h4>
                                                                                                        </div>
                                                                                                        <div class="modal-body">
                                                                                                            <asp:TextBox autocomplete="off"  ID="InhouseSearchItem" OnTextChanged="InhouseSearchItem_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                            <br />
                                                                                                            <asp:GridView ID="InhouseGridItem" OnPageIndexChanging="InhouseGridItem_PageIndexChanging" PageSize="5" AllowPaging="True" DataKeyNames="Id" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                                                                               <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>


                                                                                                                    <asp:TemplateField HeaderText="InhouseCode" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblCode" runat="server"
                                                                                                                                Text='<%#Eval("InhouseCode")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="HSCode" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblName" runat="server"
                                                                                                                                Text='<%#Eval("HSCode")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>

                                                                                                                    <asp:TemplateField HeaderText="Description" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblName1" runat="server"
                                                                                                                                Text='<%#Eval("Description")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="Brand" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblCRUEI" runat="server"
                                                                                                                                Text='<%#Eval("Brand")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="Model" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblModel" runat="server"
                                                                                                                                Text='<%#Eval("Model")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="DGIndicator" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblCRUEI1" runat="server"
                                                                                                                                Text='<%#Eval("DGIndicator")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField>
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:LinkButton ID="lnkInhouseItem" OnClick="lnkInhouseItem_Click" runat="server" CommandArgument='<%# Eval("Id") %>'>Select </asp:LinkButton>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                </Columns>
                                                                                                            </asp:GridView>
                                                                                                        </div>
                                                                                                        <div class="modal-footer">
                                                                                                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                                                                        </div>
                                                                                                    </div>

                                                                                                </div>
                                                                                            </div>

                                                                                            <!--  Search -->
                                                                                            <div class="modal fade" id="HSCode" role="dialog">
                                                                                                <div class="modal-dialog">

                                                                                                    <!-- Modal content-->
                                                                                                    <div class="modal-content">
                                                                                                        <div class="modal-header">
                                                                                                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                                                                            <h4 class="modal-title">HSCode
                                                                                                            </h4>
                                                                                                        </div>
                                                                                                        <div class="modal-body">
                                                                                                            <asp:TextBox autocomplete="off"  ID="HSCodeSearchItem" OnTextChanged="HSCodeSearchItem_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                            <br />
                                                                                                            <asp:GridView ID="HSCodeGridItem" OnPageIndexChanging="HSCodeGridItem_PageIndexChanging" PageSize="5" AllowPaging="True" DataKeyNames="Id" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                                                                               <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>



                                                                                                                    <asp:TemplateField HeaderText="HSCode" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblName" runat="server"
                                                                                                                                Text='<%#Eval("HSCode")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>

                                                                                                                    <asp:TemplateField HeaderText="Description" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblName1" runat="server"
                                                                                                                                Text='<%#Eval("Description")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="UOM" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblName11" runat="server"
                                                                                                                                Text='<%#Eval("UOM")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>

                                                                                                                    <asp:TemplateField>
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:LinkButton ID="lnkHSCodeItem" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="lnkHSCodeItem_Click">Select </asp:LinkButton>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                </Columns>
                                                                                                            </asp:GridView>
                                                                                                        </div>
                                                                                                        <div class="modal-footer">
                                                                                                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                                                                        </div>
                                                                                                    </div>

                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="row">
                                                                                                <div class="col-sm-6">
                                                                                                    <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                                                                                                        ShowSummary="False" ValidationGroup="Item" />

                                                                                                  
                                                                                                    <asp:Button Text="+" OnClick="Unnamed_Click" ValidationGroup="ItemMasterValidation5" ID="Btniteminhouse" Visible="false" runat="server" />

                                                                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" ControlToValidate="TxtInHouseItem" ErrorMessage="Please Enter InHouse"
Display="None" ValidationGroup="Item" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                                                                </div>

                                                                                                <div class="col-sm-6">
                             
                                                                                                </div>
                                                                                            </div>

                                                                                        </div>
                                                                                        <div class="col-sm-4">
                                                                                            <asp:Button ID="btnCopyAll" runat="server" Text="Copy All" Visible="false" />
                                                                                            <asp:Button ID="BtnOutCopyAll" runat="server" Text="Copy All" Visible="false" />
                                                                                        </div>

                                                                                    </div>

                                                                                    <div class="row">
                                                                                        <div class="col-sm-4">
                                                                                            <div class="row">
                                                                                                <div class="col-sm-12">
                                                                                                    <asp:TextBox autocomplete="off"  runat="server" Visible="false" Text="0.00" ID="TxtUnitPrice" OnTextChanged="TxtUnitPrice_TextChanged" AutoPostBack="true" TabIndex="182"></asp:TextBox>
                                                                                                </div>

                                                                                            </div>

                                                                                            <div class="row">
                                                                                                <div class="col-sm-12">
                                                                                                    <asp:TextBox autocomplete="off"  runat="server" type="text" Visible="false" ID="TxtSumExRate" Text="0.00" TabIndex="184"></asp:TextBox>
                                                                                                </div>

                                                                                            </div>
                                                                                        </div>
                                                                                    </div>





                                                                                    <div class="row">
                                                                                     <center>
                                                                                     <div class="row">
                                                                                          <div class="row Borderdiv" style="width: 90%">
                                                                                        Upload Item Excel Template
                                                                                    </div><br />
                                                                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                                                                            <ContentTemplate>
                                                                                               
                                                                                                <div class="col-sm-4"> <a href="ExcelTemplate/InpaymentItemUpload.xlsx" class="btn1"  download>Download Item Excel Template Here</a>
                                                                                                
                                                                                                    </div>
                                                                                                <div class="col-sm-4">
                                                                                                    
                                                                                                    <asp:FileUpload Height="35" ID="FileUpload4" class="btn" runat="server" AllowMultiple="true" />
                                                                                                    <asp:Label runat="server" ID="Label2" />
                                                                                                </div>

                                                                                               <div class="col-sm-4">
                                                                                                  
                                                                                                    <asp:Button ID="BtnExcelUp" runat="server" OnClick="BtnExcelUp_Click" Text="Upload Excel" class="btn1 btn-primary"/>
                                                                                                    <asp:Label runat="server" ID="Error" />

                                                                                                </div>
                                                                                                 <div class="col-sm-3">
                                                                                                       
                                                                                                     </div>
                                                                                            </ContentTemplate>
                                                                                            <Triggers>
                                                                                                <asp:PostBackTrigger ControlID="BtnExcelUp" />
                                                                                            </Triggers>
                                                                                        </asp:UpdatePanel>
                                                                                    </div></center>
                                                                                </div> 
                                                                                      


                                                                                    <br />
                                                                                   <div id="ItemCASC" visible="false" runat="server">
                                                                                    <div class="panel panel-primary">
                                                                                        <div class="panel-heading">
                                                                                            <h4 class="panel-title">
                                                                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapse10q">ITEM CASC </a>
                                                                                            </h4>
                                                                                        </div>
                                                                                        <div id="collapse10q" class="panel-collapse collapse in">
                                                                                            <div class="panel-body">
                                                                                                <div class="row">
                                                                                                    <div class="col-sm-12">
                                                                                                        <%-- PRODUCT cODE 1--%>

                                                                                                        <asp:ValidationSummary ID="ValidationSummary12" runat="server" ShowMessageBox="True"
                                                                                                            ShowSummary="False" ValidationGroup="Productcode" />
                                                                                                        <div class="panel panel-primary">
                                                                                                            <div class="panel-heading">
                                                                                                                <h4 class="panel-title">
                                                                                                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapsep1">Product Code 1</a>
                                                                                                                </h4>
                                                                                                            </div>
                                                                                                            <div id="collapsep1" class="panel-collapse collapse in">
                                                                                                                <div class="panel-body">
                                                                                                                    <div class="panel-body">
                                                                                                                        <div class="row">
                                                                                                                            <div class="modal fade" id="Product1" role="dialog">
                                                                                                                                <div class="modal-dialog">

                                                                                                                                    <!-- Modal content-->
                                                                                                                                    <div class="modal-content">
                                                                                                                                        <div class="modal-header">
                                                                                                                                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                                                                                                            <h4 class="modal-title">Product Code 1
                                                                                                                                            </h4>
                                                                                                                                        </div>

                                                                                                                                        <div class="modal-body">

                                                                                                                                            <asp:Button ID="btntest" runat="server" Text="Change" OnClick="btntest_Click" />

                                                                                                                                            <%--<asp:UpdatePanel ID="UpdatePanelProductCode1" runat="server"  UpdateMode="Always">

                                                        <ContentTemplate>--%>

                                                                                                                                            <%-- </ContentTemplate>
                                                           	
                                                                     </asp:UpdatePanel>--%>
                                                                                                                                            <br />
                                                                                                                                        </div>
                                                                                                                                        <div class="modal-footer">
                                                                                                                                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                                                                                                        </div>
                                                                                                                                    </div>

                                                                                                                                </div>
                                                                                                                            </div>
                                                                                                                            <div class="row">
                                                                                                                                <div class="col-sm-3">
                                                                                                                                    <div class="row">
                                                                                                                                        <div class="col-sm-12">
                                                                                                                                            <asp:Button ID="Button4" runat="server" Text="Copy Of HS-Quantity" OnClick="Button2_Click" />





                                                                                                                                            <p>
                                                                                                                                                Product Code
                                                                                                                                                <asp:Button ID="btnpc1" TabIndex="22" runat="server" Text="Search" />
                                                                                                                                                <%--<i class='fa fa-search' data-toggle="modal" data-target="#Product1"></i>--%>
                                                                                                                                            </p>

                                                                                                                                            <cc1:ModalPopupExtender ID="popupinnondec" runat="server" PopupControlID="pnlpc1" TargetControlID="btnpc1"
                                                                                                                                                OkControlID="btnpcYes" CancelControlID="btnpcNo" BackgroundCssClass="modalBackground">
                                                                                                                                            </cc1:ModalPopupExtender>
                                                                                                                                            <asp:Panel ID="pnlpc1" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                                                                                <div class="header">
                                                                                                                                                    Product Code 1
                                                                                                                                                </div>
                                                                                                                                                <div class="body">
                                                                                                                                                    <asp:UpdatePanel ID="upinnonpc1" runat="server" UpdateMode="Conditional">
                                                                                                                                                        <ContentTemplate>
                                                                                                                                                            <asp:TextBox autocomplete="off"  ID="ProductCode1Search" OnTextChanged="ProductCode1Search_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server" Style="text-transform: uppercase"></asp:TextBox>




                                                                                                                                                            No of Rows:

    <asp:DropDownList ID="dropdownlist5" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropdownlist5_SelectedIndexChanged">

        <asp:ListItem>10</asp:ListItem>

        <asp:ListItem>20</asp:ListItem>

        <asp:ListItem>30</asp:ListItem>

        <asp:ListItem>All</asp:ListItem>

    </asp:DropDownList>
                                                                                                                                                            <asp:GridView ID="ProductCode1Grid" OnPageIndexChanging="ProductCode1Grid_PageIndexChanging" AllowPaging="True" DataKeyNames="Id" CssClass="table table-stri onped table-bordered table-hover" runat="server" OnRowCommand="ProductCode1Grid_RowCommand" OnRowDataBound="ProductCode1Grid_RowDataBound" AutoGenerateColumns="false">
                                                                                                                                                                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                                                                                <Columns>



                                                                                                                                                                    <asp:TemplateField HeaderText="CASCCode" SortExpression="Id">
                                                                                                                                                                        <ItemTemplate>
                                                                                                                                                                            <asp:Label ID="lblName" runat="server"
                                                                                                                                                                                Text='<%#Eval("CASCCode")%>'>
                                                                                                                                                                            </asp:Label>
                                                                                                                                                                        </ItemTemplate>
                                                                                                                                                                    </asp:TemplateField>

                                                                                                                                                                    <asp:TemplateField HeaderText="Description" SortExpression="Id">
                                                                                                                                                                        <ItemTemplate>
                                                                                                                                                                            <asp:Label ID="lblName1" runat="server"
                                                                                                                                                                                Text='<%#Eval("Description")%>'>
                                                                                                                                                                            </asp:Label>
                                                                                                                                                                        </ItemTemplate>
                                                                                                                                                                    </asp:TemplateField>
                                                                                                                                                                    <asp:TemplateField HeaderText="UOM" SortExpression="Id">
                                                                                                                                                                        <ItemTemplate>
                                                                                                                                                                            <asp:Label ID="lblUOM" runat="server"
                                                                                                                                                                                Text='<%#Eval("UOM")%>'>
                                                                                                                                                                            </asp:Label>
                                                                                                                                                                        </ItemTemplate>
                                                                                                                                                                    </asp:TemplateField>

                                                                                                                                                                    <asp:TemplateField>
                                                                                                                                                                        <ItemTemplate>
                                                                                                                                                                            <asp:LinkButton ID="lnkProductCode1" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="lnkProductCode1_Command">Select </asp:LinkButton>
                                                                                                                                                                        </ItemTemplate>
                                                                                                                                                                    </asp:TemplateField>
                                                                                                                                                                </Columns>
                                                                                                                                                            </asp:GridView>

                                                                                                                                                        </ContentTemplate>

                                                                                                                                                    </asp:UpdatePanel>
                                                                                                                                                </div>
                                                                                                                                                <div class="footer" align="right">
                                                                                                                                                    <asp:Button ID="btnpcYes" runat="server" Text="Yes" CssClass="yes" />
                                                                                                                                                    <asp:Button ID="btnpcNo" runat="server" Text="No" CssClass="no" />
                                                                                                                                                </div>
                                                                                                                                            </asp:Panel>



                                                                                                                                            <asp:TextBox autocomplete="off"  runat="server" type="text" ValidationGroup="Productcode" ID="TxtProductCode1" MaxLength="17" OnTextChanged="TxtProductCode1_TextChanged" AutoPostBack="true" TabIndex="147" Style="text-transform: uppercase"></asp:TextBox>
                                                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProductCode1" ID="RegularExpressionValidator67" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>



                                                                                                                                            <p>Quantity</p>


                                                                                                                                            <asp:TextBox autocomplete="off"  Width="100" runat="server" type="text" ValidationGroup="Productcode" onkeypress="return noAlphabets(event)" ID="TxtProQty1" MaxLength="16" Text="0.00" TabIndex="148"></asp:TextBox>


                                                                                                                                            <asp:DropDownList CssClass="drop" ID="DrpP1" runat="server" Width="70" Height="25" TabIndex="149"></asp:DropDownList>

                                                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProQty1" ID="RegularExpressionValidator69" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>



                                                                                                                                        </div>
                                                                                                                                    </div>
                                                                                                                                </div>

                                                                                                                                <div class="col-sm-9">
                                                                                                                                    <p style ="font-weight :bold ">End User Description</p>
                                                                                                                                        <asp:TextBox autocomplete="off"  Width="100%" runat="server" type="text" ID="txtEndUserDec" OnTextChanged="txtEndUserDec_TextChanged"  ValidationGroup="Productcode"  TextMode="MultiLine" AutoPostBack="true"  Style="text-transform :uppercase"  Text="" TabIndex="226"></asp:TextBox>
                                                                                                                                       <asp:Label ID="endusercount1" Visible="false" runat="server"></asp:Label>
                                                                                                                                        <br />
                                                                                                                                   
                                                                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtEndUserDec" ID="RegularExpressionValidator78" ValidationExpression="^[\s\S]{0,256}$" runat="server" ErrorMessage="Maximum 256 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>


                                                                                                                                        <br />



                                                                                                                                    <asp:GridView CssClass="table table-striped table-bordered table-hover" ID="ProductCode1Grid1" runat="server" ShowFooter="true" AutoGenerateColumns="false">
                                                                                                                                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                                                        <Columns>

                                                                                                                                            <asp:BoundField DataField="RowNumber" HeaderText="Row Number" Visible="false" />

                                                                                                                                            <asp:TemplateField HeaderText="CASC CODE 1">

                                                                                                                                                <ItemTemplate>

                                                                                                                                                    <asp:TextBox autocomplete="off"  ID="TextBox1" MaxLength="35" runat="server" TabIndex="121"></asp:TextBox>

                                                                                                                                                </ItemTemplate>

                                                                                                                                            </asp:TemplateField>

                                                                                                                                            <asp:TemplateField HeaderText="CASC CODE 2">

                                                                                                                                                <ItemTemplate>

                                                                                                                                                    <asp:TextBox autocomplete="off"  ID="TextBox2" MaxLength="35" TabIndex="122" runat="server"></asp:TextBox>

                                                                                                                                                </ItemTemplate>

                                                                                                                                            </asp:TemplateField>

                                                                                                                                            <asp:TemplateField HeaderText="CASC CODE 3">

                                                                                                                                                <ItemTemplate>

                                                                                                                                                    <asp:TextBox autocomplete="off"  ID="TextBox3" MaxLength="35" TabIndex="123" runat="server"></asp:TextBox>

                                                                                                                                                </ItemTemplate>
                                                                                                                                            </asp:TemplateField>
                                                                                                                                            <asp:TemplateField HeaderText="ADD">
                                                                                                                                                <ItemTemplate>
                                                                                                                                                    <asp:Button ID="ProductCode1Add" OnClick="ProductCode1Add_Click" runat="server" Text="Add" TabIndex="124" />
                                                                                                                                                </ItemTemplate>


                                                                                                                                            </asp:TemplateField>

                                                                                                                                        </Columns>

                                                                                                                                    </asp:GridView>
                                                                                                                                </div>

                                                                                                                            </div>
                                                                                                                        </div>
                                                                                                                    </div>
                                                                                                                </div>
                                                                                                            </div>
                                                                                                        </div>
                                                                                                        <%-- PRODUCT cODE 2--%>
                                                                                                        <div class="panel panel-primary">
                                                                                                            <div class="panel-heading">
                                                                                                                <h4 class="panel-title">
                                                                                                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapsep1d">Product Code 2</a>
                                                                                                                </h4>
                                                                                                            </div>
                                                                                                            <div id="collapsep1d" class="panel-collapse collapse in">
                                                                                                                 <asp:UpdatePanel ID="upnlpc2" runat="server" UpdateMode="Conditional">
                                                                                                                                                <ContentTemplate>
                                                                                                                <div class="panel-body">
                                                                                                                    <div class="panel-body">
                                                                                                                        <div class="row">
                                                                                                                            
                                                                                                                            <div class="modal fade" id="Product2" role="dialog">
                                                                                                                                <div class="modal-dialog">

                                                                                                                                    <!-- Modal content-->
                                                                                                                                    <div class="modal-content">
                                                                                                                                        <div class="modal-header">
                                                                                                                                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                                                                                                            <h4 class="modal-title">Product Code 2
                                                                                                                                            </h4>
                                                                                                                                        </div>
                                                                                                                                        <div class="modal-body">


                                                                                                                                            <%--<asp:UpdatePanel ID="UpdatePanelProductCode2" runat="server"  UpdateMode="Always">

  <ContentTemplate>--%>

                                                                                                                                            <%-- </ContentTemplate>
                                                           	
    </asp:UpdatePanel>--%>
                                                                                                                                        </div>
                                                                                                                                        <div class="modal-footer">
                                                                                                                                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                                                                                                        </div>
                                                                                                                                    </div>

                                                                                                                                </div>
                                                                                                                            </div>
                                                                                                                            <div class="row">
                                                                                                                                <div class="col-sm-3">
                                                                                                                                    <asp:Button ID="btnpc2" runat="server" Text="Copy Of HS-Quantity" OnClick="btnpc2_Click" />
                                                                                                                                    <p>Product Code &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnproductcode" TabIndex="22" runat="server" Text="Search" /><%--<i class='fa fa-search' data-toggle="modal" data-target="#Product2"></i>--%></p>
                                                                                                                                
                                                                                                                                        <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="pnlpc2" TargetControlID="btnproductcode"
                                                                                                                                        OkControlID="btnpc2Yes" CancelControlID="btnpc2No" BackgroundCssClass="modalBackground">
                                                                                                                                    </cc1:ModalPopupExtender>
                                                                                                                                    <asp:Panel ID="pnlpc2" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                                                                        <div class="header">
                                                                                                                                            Product Code 2
                                                                                                                                        </div>
                                                                                                                                        <div class="body">
                                                                                                                                            <asp:UpdatePanel ID="uppc2" runat="server" UpdateMode="Conditional">
                                                                                                                                                <ContentTemplate>
                                                                                                                                                    <asp:TextBox autocomplete="off"  ID="ProductCode2Search" OnTextChanged="ProductCode2Search_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                                                                    <br />

                                                                                                                                                    No of Rows:

    <asp:DropDownList ID="ddlpc2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlpc2_SelectedIndexChanged">

        <asp:ListItem>10</asp:ListItem>

        <asp:ListItem>20</asp:ListItem>

        <asp:ListItem>30</asp:ListItem>

        <asp:ListItem>All</asp:ListItem>

    </asp:DropDownList>
                                                                                                                                                    <asp:GridView ID="ProductCode2Grid" PageSize="5" OnPageIndexChanging="ProductCode2Grid_PageIndexChanging" AllowPaging="True" DataKeyNames="Id" CssClass="table table-stri onped table-bordered table-hover" runat="server" OnRowCommand="ProductCode2Grid_RowCommand" OnRowDataBound="ProductCode2Grid_RowDataBound" AutoGenerateColumns="false">
                                                                                                                                                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                                                                        <Columns>



                                                                                                                                                            <asp:TemplateField HeaderText="CASCCode" SortExpression="Id">
                                                                                                                                                                <ItemTemplate>
                                                                                                                                                                    <asp:Label ID="lblName" runat="server"
                                                                                                                                                                        Text='<%#Eval("CASCCode")%>'>
                                                                                                                                                                    </asp:Label>
                                                                                                                                                                </ItemTemplate>
                                                                                                                                                            </asp:TemplateField>

                                                                                                                                                            <asp:TemplateField HeaderText="Description" SortExpression="Id">
                                                                                                                                                                <ItemTemplate>
                                                                                                                                                                    <asp:Label ID="lblName1" runat="server"
                                                                                                                                                                        Text='<%#Eval("Description")%>'>
                                                                                                                                                                    </asp:Label>
                                                                                                                                                                </ItemTemplate>
                                                                                                                                                            </asp:TemplateField>
                                                                                                                                                            <asp:TemplateField HeaderText="UOM" SortExpression="Id">
                                                                                                                                                                <ItemTemplate>
                                                                                                                                                                    <asp:Label ID="lblUOM" runat="server"
                                                                                                                                                                        Text='<%#Eval("UOM")%>'>
                                                                                                                                                                    </asp:Label>
                                                                                                                                                                </ItemTemplate>
                                                                                                                                                            </asp:TemplateField>

                                                                                                                                                            <asp:TemplateField>
                                                                                                                                                                <ItemTemplate>
                                                                                                                                                                    <asp:LinkButton ID="lnkProductCode2" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="lnkProductCode2_Command">Select </asp:LinkButton>
                                                                                                                                                                </ItemTemplate>
                                                                                                                                                            </asp:TemplateField>
                                                                                                                                                        </Columns>
                                                                                                                                                    </asp:GridView>

                                                                                                                                                </ContentTemplate>

                                                                                                                                            </asp:UpdatePanel>
                                                                                                                                        </div>

                                                                                                                                        <div class="footer" align="right">
                                                                                                                                            <asp:Button ID="btnpc2Yes" runat="server" Text="Yes" CssClass="yes" />
                                                                                                                                            <asp:Button ID="btnpc2No" runat="server" Text="No" CssClass="no" />
                                                                                                                                        </div>
                                                                                                                                    </asp:Panel>

                                                                                                                                    <asp:TextBox autocomplete="off"  runat="server" type="text" ValidationGroup="Productcode" ID="TxtProductCode2" MaxLength="17" OnTextChanged="TxtProductCode2_TextChanged" AutoPostBack="true" TabIndex="124"></asp:TextBox>

                                                                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProductCode2" ID="RegularExpressionValidator70" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>

                                                                                                                                    <p>Quantity</p>
                                                                                                                                    <asp:TextBox autocomplete="off" onkeypress="return noAlphabets(event)"  Width="70" runat="server" type="text" ID="TxtProQty2" MaxLength="16" ValidationGroup="Productcode" TabIndex="125"></asp:TextBox>
                                                                                                                                    <asp:DropDownList CssClass="drop" ID="DrpP2" runat="server" Width="70" Height="25" TabIndex="126"></asp:DropDownList>
                                                                                                                                    <br />
                                                                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProQty2" ID="RegularExpressionValidator71" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>


                                                                                                                                </div>
                                                                                                                                <div class="col-sm-9">


                                                                                                                                     <p>End User Description</p>
                                                                                                                                        <asp:TextBox autocomplete="off"  Width="100%" runat="server" type="text" ID="txtEndUserDec1" OnTextChanged="txtEndUserDec1_TextChanged" AutoPostBack="true"   ValidationGroup="Productcode" Style="text-transform :uppercase" TextMode="MultiLine" Text="" TabIndex="229"></asp:TextBox>
                                                                                                                                        <br />
                                                                                                                                       <asp:Label ID="endusercount2" Visible="false" runat="server"></asp:Label>
                                                                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtEndUserDec1" ID="RegularExpressionValidator79" ValidationExpression="^[\s\S]{0,256}$" runat="server" ErrorMessage="Maximum 256 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>


                                                                                                                                        <br />


                                                                                                                                    <asp:GridView CssClass="table table-striped table-bordered table-hover" ID="ProductCode2Grid1" runat="server" ShowFooter="true" AutoGenerateColumns="false">
                                                                                                                                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                                                        <Columns>

                                                                                                                                            <asp:BoundField DataField="Product Code    " HeaderText="Row Number" Visible="false" />

                                                                                                                                            <asp:TemplateField HeaderText="CASC CODE 1">

                                                                                                                                                <ItemTemplate>

                                                                                                                                                    <asp:TextBox autocomplete="off"  ID="TextBox1" MaxLength="35" TabIndex="127" runat="server"></asp:TextBox>

                                                                                                                                                </ItemTemplate>

                                                                                                                                            </asp:TemplateField>

                                                                                                                                            <asp:TemplateField HeaderText="CASC CODE 2">

                                                                                                                                                <ItemTemplate>

                                                                                                                                                    <asp:TextBox autocomplete="off"  ID="TextBox2" MaxLength="35" TabIndex="128" runat="server"></asp:TextBox>

                                                                                                                                                </ItemTemplate>

                                                                                                                                            </asp:TemplateField>

                                                                                                                                            <asp:TemplateField HeaderText="CASC CODE 3">

                                                                                                                                                <ItemTemplate>

                                                                                                                                                    <asp:TextBox autocomplete="off"  ID="TextBox3" MaxLength="35" TabIndex="129" runat="server"></asp:TextBox>

                                                                                                                                                </ItemTemplate>
                                                                                                                                            </asp:TemplateField>
                                                                                                                                            <asp:TemplateField HeaderText="ADD">
                                                                                                                                                <ItemTemplate>
                                                                                                                                                    <asp:Button ID="ProductCode2Add" OnClick="ProductCode2Add_Click" runat="server" Text="Add" TabIndex="130" />
                                                                                                                                                </ItemTemplate>




                                                                                                                                            </asp:TemplateField>

                                                                                                                                        </Columns>

                                                                                                                                    </asp:GridView>
                                                                                                                                </div>
                                                                                                                            </div>
                                                                                                                                                    
                                                                                                                        </div>
                                                                                                                    </div>
                                                                                                                      
                                                                                                                </div>
                                                                                                                                                    </ContentTemplate>
                                                                                                                                 </asp:UpdatePanel>
                                                                                                            </div>
                                                                                                                       

                                                                                                        </div>

                                                                                                        <%-- PRODUCT cODE 3--%>
                                                                                                        <div class="panel panel-primary">
                                                                                                            <div class="panel-heading">
                                                                                                                <h4 class="panel-title">
                                                                                                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapsep1dz">Product Code 3</a>
                                                                                                                </h4>
                                                                                                            </div>
                                                                                                            <div id="collapsep1dz" class="panel-collapse collapse in ">
                                                                                                                 <asp:UpdatePanel ID="upnlpc3" runat="server" UpdateMode="Conditional">
                                                                                                                                                <ContentTemplate>
                                                                                                                <div class="panel-body">
                                                                                                                    <div class="panel-body">

                                                                                                                        <div class="row">
                                                                                                                            <div class="modal fade" id="Product3" role="dialog">
                                                                                                                                <div class="modal-dialog">

                                                                                                                                    <!-- Modal content-->
                                                                                                                                    <div class="modal-content">
                                                                                                                                        <div class="modal-header">
                                                                                                                                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                                                                                                            <h4 class="modal-title">Product Code 3
                                                                                                                                            </h4>
                                                                                                                                        </div>
                                                                                                                                        <div class="modal-body">

                                                                                                                                            <br />
                                                                                                                                            <%-- <asp:UpdatePanel ID="UpdatePanelProductCode3" runat="server"  UpdateMode="Always">

                                                           <ContentTemplate>--%>

                                                                                                                                            <%--   </ContentTemplate>
                                                           	
                                                                </asp:UpdatePanel>--%>
                                                                                                                                        </div>
                                                                                                                                        <div class="modal-footer">
                                                                                                                                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                                                                                                        </div>
                                                                                                                                    </div>

                                                                                                                                </div>
                                                                                                                            </div>
                                                                                                                            <div class="row">
                                                                                                                                <div class="col-sm-3">
                                                                                                                                      <asp:Button ID="btncopyhscode" runat="server" Text="Copy Of HS-Quantity" OnClick="btncopyhscode_Click" />
                                                                                                                                    <p>Product Code &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnpc3" TabIndex="22" runat="server" Text="Search" />
                                                                                                                                        <%--<i class='fa fa-search' data-toggle="modal" data-target="#Product3"></i>--%></p>
                                                                                                                                    <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" PopupControlID="pnlpc3" TargetControlID="btnpc3"
                                                                                                                                        OkControlID="btnpc3Yes" CancelControlID="btnpc3No" BackgroundCssClass="modalBackground">
                                                                                                                                    </cc1:ModalPopupExtender>
                                                                                                                                    <asp:Panel ID="pnlpc3" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                                                                        <div class="header">
                                                                                                                                            Product Code 3
                                                                                                                                        </div>
                                                                                                                                        <div class="body">
                                                                                                                                            <asp:UpdatePanel ID="uppc3" runat="server" UpdateMode="Conditional">
                                                                                                                                                <ContentTemplate>

                                                                                                                                                    <asp:TextBox autocomplete="off"  ID="ProductCode3Search" OnTextChanged="ProductCode3Search_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                                                                    <br />
                                                                                                                                                    <asp:DropDownList ID="ddlpc3" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlpc3_SelectedIndexChanged">

                                                                                                                                                        <asp:ListItem>10</asp:ListItem>

                                                                                                                                                        <asp:ListItem>20</asp:ListItem>

                                                                                                                                                        <asp:ListItem>30</asp:ListItem>

                                                                                                                                                        <asp:ListItem>All</asp:ListItem>

                                                                                                                                                    </asp:DropDownList>
                                                                                                                                                    <asp:GridView ID="ProductCode3Grid" PageSize="5" OnPageIndexChanging="ProductCode3Grid_PageIndexChanging" AllowPaging="True" DataKeyNames="Id" CssClass="table table-stri onped table-bordered table-hover" runat="server"  OnRowCommand="ProductCode3Grid_RowCommand" OnRowDataBound="ProductCode3Grid_RowDataBound" AutoGenerateColumns="false">
                                                                                                                                                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                                                                        <Columns>



                                                                                                                                                            <asp:TemplateField HeaderText="CASCCode" SortExpression="Id">
                                                                                                                                                                <ItemTemplate>
                                                                                                                                                                    <asp:Label ID="lblName" runat="server"
                                                                                                                                                                        Text='<%#Eval("CASCCode")%>'>
                                                                                                                                                                    </asp:Label>
                                                                                                                                                                </ItemTemplate>
                                                                                                                                                            </asp:TemplateField>

                                                                                                                                                            <asp:TemplateField HeaderText="Description" SortExpression="Id">
                                                                                                                                                                <ItemTemplate>
                                                                                                                                                                    <asp:Label ID="lblName1" runat="server"
                                                                                                                                                                        Text='<%#Eval("Description")%>'>
                                                                                                                                                                    </asp:Label>
                                                                                                                                                                </ItemTemplate>
                                                                                                                                                            </asp:TemplateField>
                                                                                                                                                            <asp:TemplateField HeaderText="UOM" SortExpression="Id">
                                                                                                                                                                <ItemTemplate>
                                                                                                                                                                    <asp:Label ID="lblUOM" runat="server"
                                                                                                                                                                        Text='<%#Eval("UOM")%>'>
                                                                                                                                                                    </asp:Label>
                                                                                                                                                                </ItemTemplate>
                                                                                                                                                            </asp:TemplateField>

                                                                                                                                                            <asp:TemplateField>
                                                                                                                                                                <ItemTemplate>
                                                                                                                                                                    <asp:LinkButton ID="lnkProductCode3" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="lnkProductCode3_Command">Select </asp:LinkButton>
                                                                                                                                                                </ItemTemplate>
                                                                                                                                                            </asp:TemplateField>
                                                                                                                                                        </Columns>
                                                                                                                                                    </asp:GridView>
                                                                                                                                                </ContentTemplate>

                                                                                                                                            </asp:UpdatePanel>
                                                                                                                                        </div>

                                                                                                                                        <div class="footer" align="right">
                                                                                                                                            <asp:Button ID="btnpc3Yes" runat="server" Text="Yes" CssClass="yes" />
                                                                                                                                            <asp:Button ID="btnpc3No" runat="server" Text="No" CssClass="no" />
                                                                                                                                        </div>
                                                                                                                                    </asp:Panel>




                                                                                                                                    <asp:TextBox autocomplete="off"  runat="server" type="text" MaxLength="17" ID="TxtProductCode3" ValidationGroup="Productcode" OnTextChanged="TxtProductCode3_TextChanged" AutoPostBack="true" TabIndex="130" Style="text-transform: uppercase"></asp:TextBox>
                                                                                                                                    <br />
                                                                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProductCode3" ID="RegularExpressionValidator72" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>
                                                                                                                                    <br />
                                                                                                                                    <p>Quantity</p>
                                                                                                                                    <asp:TextBox autocomplete="off" onkeypress="return noAlphabets(event)"  Width="70" runat="server" type="text" MaxLength="16" ValidationGroup="Productcode" ID="TxtProQty3" TabIndex="131"></asp:TextBox>


                                                                                                                                    <asp:DropDownList CssClass="drop" ID="DrpP3" runat="server" Width="70" Height="25" TabIndex="132"></asp:DropDownList>
                                                                                                                                    <br />

                                                                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProQty3" ID="RegularExpressionValidator73" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>

                                                                                                                                </div>
                                                                                                                                <div class="col-sm-9">

                                                                                                                                     <p>End User Description</p>
                                                                                                                                        <asp:TextBox autocomplete="off"  Width="100%" runat="server" type="text" ID="txtEndUserDec2" OnTextChanged="txtEndUserDec2_TextChanged" AutoPostBack="true"  ValidationGroup="Productcode" style="text-transform :uppercase " TextMode="MultiLine" Text="" TabIndex="233"></asp:TextBox>
                                                                                                                                        <br />
                                                                                                                                       <asp:Label ID="endusercount3" Visible="false" runat="server"></asp:Label>
                                                                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtEndUserDec2" ID="RegularExpressionValidator80" ValidationExpression="^[\s\S]{0,256}$" runat="server" ErrorMessage="Maximum 256 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>


                                                                                                                                        <br />

                                                                                                                                    <asp:GridView CssClass="table table-striped table-bordered table-hover" ID="ProductCode3Grid1" runat="server" ShowFooter="true" AutoGenerateColumns="false">
                                                                                                                                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                                                        <Columns>

                                                                                                                                            <asp:BoundField DataField="RowNumber" HeaderText="Row Number" Visible="false" />

                                                                                                                                            <asp:TemplateField HeaderText="CASC CODE 1">

                                                                                                                                                <ItemTemplate>

                                                                                                                                                    <asp:TextBox autocomplete="off"  ID="TextBox1" MaxLength="35" TabIndex="133" runat="server"></asp:TextBox>

                                                                                                                                                </ItemTemplate>

                                                                                                                                            </asp:TemplateField>

                                                                                                                                            <asp:TemplateField HeaderText="CASC CODE 2">

                                                                                                                                                <ItemTemplate>

                                                                                                                                                    <asp:TextBox autocomplete="off"  ID="TextBox2" MaxLength="35" TabIndex="134" runat="server"></asp:TextBox>

                                                                                                                                                </ItemTemplate>

                                                                                                                                            </asp:TemplateField>

                                                                                                                                            <asp:TemplateField HeaderText="CASC CODE 3">

                                                                                                                                                <ItemTemplate>

                                                                                                                                                    <asp:TextBox autocomplete="off"  ID="TextBox3" MaxLength="35" TabIndex="135" runat="server"></asp:TextBox>

                                                                                                                                                </ItemTemplate>
                                                                                                                                            </asp:TemplateField>
                                                                                                                                            <asp:TemplateField HeaderText="ADD">

                                                                                                                                                <ItemTemplate>
                                                                                                                                                    <asp:Button ID="ProductCode3Add" OnClick="ProductCode3Add_Click" runat="server" Text="Add" TabIndex="136" />
                                                                                                                                                </ItemTemplate>


                                                                                                                                            </asp:TemplateField>

                                                                                                                                        </Columns>

                                                                                                                                    </asp:GridView>
                                                                                                                                </div>
                                                                                                                            </div>

                                                                                                                        </div>
                                                                                                                    </div>
                                                                                                                </div>
                                                                                                                     </ContentTemplate>
                                                                                                                     </asp:UpdatePanel>
                                                                                                            </div>
                                                                                                        </div>


                                                                                                        <%-- PRODUCT cODE 4--%>
                                                                                                        <div class="panel panel-primary">
                                                                                                            <div class="panel-heading">
                                                                                                                <h4 class="panel-title">
                                                                                                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapsep1dz3">Product Code 4</a>
                                                                                                                </h4>
                                                                                                            </div>
                                                                                                            <div id="collapsep1dz3" class="panel-collapse collapse ">
                                                                                                                 <asp:UpdatePanel ID="upnlpc4" runat="server" UpdateMode="Conditional">
                                                                                                                                                <ContentTemplate>
                                                                                                                <div class="panel-body">
                                                                                                                    <div class="panel-body">
                                                                                                                        <div class="row">
                                                                                                                            <div class="modal fade" id="Product4" role="dialog">
                                                                                                                                <div class="modal-dialog">

                                                                                                                                    <!-- Modal content-->
                                                                                                                                    <div class="modal-content">
                                                                                                                                        <div class="modal-header">
                                                                                                                                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                                                                                                            <h4 class="modal-title">Product Code 4
                                                                                                                                            </h4>
                                                                                                                                        </div>
                                                                                                                                        <div class="modal-body">
                                                                                                                                            <%-- <asp:UpdatePanel ID="UpdatePanelProductCode4" runat="server"  UpdateMode="Always">

                                                         <ContentTemplate>--%>


                                                                                                                                            <%--</ContentTemplate>
                                                              </asp:UpdatePanel>--%>
                                                                                                                                        </div>
                                                                                                                                        <div class="modal-footer">
                                                                                                                                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                                                                                                        </div>
                                                                                                                                    </div>

                                                                                                                                </div>
                                                                                                                            </div>
                                                                                                                            <div class="row">
                                                                                                                                <div class="col-sm-3">

                                                                                                                                     <asp:Button ID="btncopyhscode4" runat="server" Text="Copy Of HS-Quantity" OnClick="btncopyhscode4_Click" />
                                                                                                                                    <p>Product Code &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnpc4" TabIndex="22" runat="server" Text="Search" />
                                                                                                                                    </p>
                                                                                                                                    <cc1:ModalPopupExtender ID="ModalPopupExtender3" runat="server" PopupControlID="pnlpc4" TargetControlID="btnpc4"
                                                                                                                                        OkControlID="btnpc4Yes" CancelControlID="btnpc4No" BackgroundCssClass="modalBackground">
                                                                                                                                    </cc1:ModalPopupExtender>
                                                                                                                                    <asp:Panel ID="pnlpc4" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                                                                        <div class="header">
                                                                                                                                            Product Code 4
                                                                                                                                        </div>

                                                                                                                                        <div class="body">
                                                                                                                                            <asp:UpdatePanel ID="uppc4" runat="server" UpdateMode="Conditional">
                                                                                                                                                <ContentTemplate>

                                                                                                                                                    <asp:TextBox autocomplete="off"  ID="ProductCode4Search" OnTextChanged="ProductCode4Search_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                                                                    <br />

                                                                                                                                                    <asp:DropDownList ID="ddlpc4" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlpc4_SelectedIndexChanged">

                                                                                                                                                        <asp:ListItem>10</asp:ListItem>

                                                                                                                                                        <asp:ListItem>20</asp:ListItem>

                                                                                                                                                        <asp:ListItem>30</asp:ListItem>

                                                                                                                                                        <asp:ListItem>All</asp:ListItem>

                                                                                                                                                    </asp:DropDownList>

                                                                                                                                                    <asp:GridView ID="ProductCode4Grid" PageSize="5" OnRowCommand="ProductCode4Grid_RowCommand" OnRowDataBound="ProductCode4Grid_RowDataBound" OnPageIndexChanging="ProductCode4Grid_PageIndexChanging" AllowPaging="True" DataKeyNames="Id" CssClass="table table-stri onped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                                                                                                                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                                                                        <Columns>



                                                                                                                                                            <asp:TemplateField HeaderText="CASCCode" SortExpression="Id">
                                                                                                                                                                <ItemTemplate>
                                                                                                                                                                    <asp:Label ID="lblName" runat="server"
                                                                                                                                                                        Text='<%#Eval("CASCCode")%>'>
                                                                                                                                                                    </asp:Label>
                                                                                                                                                                </ItemTemplate>
                                                                                                                                                            </asp:TemplateField>

                                                                                                                                                            <asp:TemplateField HeaderText="Description" SortExpression="Id">
                                                                                                                                                                <ItemTemplate>
                                                                                                                                                                    <asp:Label ID="lblName1" runat="server"
                                                                                                                                                                        Text='<%#Eval("Description")%>'>
                                                                                                                                                                    </asp:Label>
                                                                                                                                                                </ItemTemplate>
                                                                                                                                                            </asp:TemplateField>
                                                                                                                                                            <asp:TemplateField HeaderText="UOM" SortExpression="Id">
                                                                                                                                                                <ItemTemplate>
                                                                                                                                                                    <asp:Label ID="lblUOM" runat="server"
                                                                                                                                                                        Text='<%#Eval("UOM")%>'>
                                                                                                                                                                    </asp:Label>
                                                                                                                                                                </ItemTemplate>
                                                                                                                                                            </asp:TemplateField>

                                                                                                                                                            <asp:TemplateField>
                                                                                                                                                                <ItemTemplate>
                                                                                                                                                                    <asp:LinkButton ID="lnkProductCode4" runat="server" CommandArgument='<%# Eval("Id") %>'>Select </asp:LinkButton>
                                                                                                                                                                </ItemTemplate>
                                                                                                                                                            </asp:TemplateField>
                                                                                                                                                        </Columns>
                                                                                                                                                    </asp:GridView>

                                                                                                                                                </ContentTemplate>

                                                                                                                                            </asp:UpdatePanel>
                                                                                                                                        </div>

                                                                                                                                        <div class="footer" align="right">
                                                                                                                                            <asp:Button ID="btnpc4Yes" runat="server" Text="Yes" CssClass="yes" />
                                                                                                                                            <asp:Button ID="btnpc4No" runat="server" Text="No" CssClass="no" />
                                                                                                                                        </div>
                                                                                                                                    </asp:Panel>

                                                                                                                                    <asp:TextBox autocomplete="off"  runat="server" type="text" ID="TxtProductCode4" MaxLength="17" ValidationGroup="Productcode" OnTextChanged="TxtProductCode4_TextChanged" AutoPostBack="true" TabIndex="241"></asp:TextBox>
                                                                                                                                    <br />
                                                                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProductCode4" ID="RegularExpressionValidator74" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>
                                                                                                                                    <br />
                                                                                                                                    <p>Quantity</p>
                                                                                                                                    <asp:TextBox autocomplete="off" onkeypress="return noAlphabets(event)"  Width="70" runat="server" type="text" ValidationGroup="Productcode" ID="TxtProQty4" MaxLength="16" TabIndex="242"></asp:TextBox>

                                                                                                                                    <asp:DropDownList CssClass="drop" ID="DrpP4" runat="server" Width="70" Height="25" TabIndex="243"></asp:DropDownList>

                                                                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProQty4" ID="RegularExpressionValidator75" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>

                                                                                                                                </div>
                                                                                                                                <div class="col-sm-9">

                                                                                                                                     <p>End User Description</p>
                                                                                                                                        <asp:TextBox autocomplete="off"  Width="100%" runat="server" type="text" OnTextChanged="txtEndUserDec3_TextChanged" AutoPostBack="true" ID="txtEndUserDec3"   ValidationGroup="Productcode" style="text-transform :uppercase " TextMode="MultiLine" Text="" TabIndex="236"></asp:TextBox>
                                                                                                                                        <br />
                                                                                                                                    <asp:Label ID="endusercount4" Visible="false" runat="server"></asp:Label>
                                                                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtEndUserDec3" ID="RegularExpressionValidator81" ValidationExpression="^[\s\S]{0,256}$" runat="server" ErrorMessage="Maximum 256 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>
                                                                                                                                       

                                                                                                                                        <br />

                                                                                                                                    <asp:GridView CssClass="table table-striped table-bordered table-hover" ID="ProductCode4Grid1" runat="server" ShowFooter="true" AutoGenerateColumns="false">
                                                                                                                                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                                                        <Columns>

                                                                                                                                            <asp:BoundField DataField="RowNumber" HeaderText="Row Number" Visible="false" />

                                                                                                                                            <asp:TemplateField HeaderText="CASC CODE 1">

                                                                                                                                                <ItemTemplate>

                                                                                                                                                    <asp:TextBox autocomplete="off"  ID="TextBox1" MaxLength="35" runat="server"></asp:TextBox>

                                                                                                                                                </ItemTemplate>

                                                                                                                                            </asp:TemplateField>

                                                                                                                                            <asp:TemplateField HeaderText="CASC CODE 2">

                                                                                                                                                <ItemTemplate>

                                                                                                                                                    <asp:TextBox autocomplete="off"  ID="TextBox2" MaxLength="35" runat="server"></asp:TextBox>

                                                                                                                                                </ItemTemplate>

                                                                                                                                            </asp:TemplateField>

                                                                                                                                            <asp:TemplateField HeaderText="CASC CODE 3">

                                                                                                                                                <ItemTemplate>

                                                                                                                                                    <asp:TextBox autocomplete="off"  ID="TextBox3" MaxLength="35" runat="server"></asp:TextBox>

                                                                                                                                                </ItemTemplate>
                                                                                                                                            </asp:TemplateField>

                                                                                                                                            <asp:TemplateField HeaderText="ADD">

                                                                                                                                                <ItemTemplate>
                                                                                                                                                    <asp:Button ID="ProductCode4Add" OnClick="ProductCode4Add_Click" runat="server" Text="Add" />

                                                                                                                                                </ItemTemplate>

                                                                                                                                            </asp:TemplateField>

                                                                                                                                        </Columns>

                                                                                                                                    </asp:GridView>
                                                                                                                                </div>
                                                                                                                            </div>

                                                                                                                        </div>
                                                                                                                    </div>
                                                                                                                </div>

                                                                                                                                                    </ContentTemplate>
                                                                                                                     </asp:UpdatePanel>
                                                                                                            </div>
                                                                                                        </div>

                                                                                                        <%-- PRODUCT cODE 4--%>
                                                                                                        <div class="panel panel-primary">
                                                                                                            <div class="panel-heading">
                                                                                                                <h4 class="panel-title">
                                                                                                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapsep1dz5">Product Code 5</a>
                                                                                                                </h4>
                                                                                                            </div>
                                                                                                            <div id="collapsep1dz5" class="panel-collapse collapse ">
                                                                                                                <asp:UpdatePanel ID="upnlpc5" runat="server" UpdateMode="Conditional">
                                                                                                                                                <ContentTemplate>
                                                                                                                <div class="panel-body">
                                                                                                                    <div class="panel-body">
                                                                                                                        <div class="row">
                                                                                                                            <div class="modal fade" id="Product5" role="dialog">
                                                                                                                                <div class="modal-dialog">

                                                                                                                                    <!-- Modal content-->
                                                                                                                                    <div class="modal-content">
                                                                                                                                        <div class="modal-header">
                                                                                                                                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                                                                                                            <h4 class="modal-title">Product Code 5
                                                                                                                                            </h4>
                                                                                                                                        </div>
                                                                                                                                        <div class="modal-body">

                                                                                                                                            <br />

                                                                                                                                        </div>
                                                                                                                                        <div class="modal-footer">
                                                                                                                                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                                                                                                        </div>
                                                                                                                                    </div>

                                                                                                                                </div>
                                                                                                                            </div>
                                                                                                                            <div class="row">
                                                                                                                                <div class="col-sm-3">
                                                                                                                                    <asp:Button ID="btncopyhscode5" runat="server" Text="Copy Of HS-Quantity" OnClick="btncopyhscode5_Click" />
                                                                                                                                    <p>Product Code &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnpc5" TabIndex="22" runat="server" Text="Search" /></p>


                                                                                                                                    <cc1:ModalPopupExtender ID="ModalPopupExtender4" runat="server" PopupControlID="pnlpc5" TargetControlID="btnpc5"
                                                                                                                                        OkControlID="btnpc5Yes" CancelControlID="btnpc5No" BackgroundCssClass="modalBackground">
                                                                                                                                    </cc1:ModalPopupExtender>
                                                                                                                                    <asp:Panel ID="pnlpc5" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                                                                        <div class="header">
                                                                                                                                            Product Code 5
                                                                                                                                        </div>

                                                                                                                                        <div class="body">

                                                                                                                                            <asp:UpdatePanel ID="uppc5" runat="server" UpdateMode="Conditional">
                                                                                                                                                <ContentTemplate>

                                                                                                                                                    <asp:TextBox autocomplete="off"  ID="ProductCode5Search" OnTextChanged="ProductCode5Search_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                                                                    <br />

                                                                                                                                                    <asp:DropDownList ID="ddlpc5" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlpc5_SelectedIndexChanged">

                                                                                                                                                        <asp:ListItem>10</asp:ListItem>

                                                                                                                                                        <asp:ListItem>20</asp:ListItem>

                                                                                                                                                        <asp:ListItem>30</asp:ListItem>

                                                                                                                                                        <asp:ListItem>All</asp:ListItem>

                                                                                                                                                    </asp:DropDownList>

                                                                                                                                                    <asp:GridView ID="ProductCode5Grid" PageSize="5" OnPageIndexChanging="ProductCode5Grid_PageIndexChanging" AllowPaging="True" DataKeyNames="Id" CssClass="table table-stri onped table-bordered table-hover" runat="server" OnRowCommand="ProductCode5Grid_RowCommand" OnRowDataBound="ProductCode5Grid_RowDataBound" AutoGenerateColumns="false">
                                                                                                                                                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                                                                        <Columns>



                                                                                                                                                            <asp:TemplateField HeaderText="CASCCode" SortExpression="Id">
                                                                                                                                                                <ItemTemplate>
                                                                                                                                                                    <asp:Label ID="lblName" runat="server"
                                                                                                                                                                        Text='<%#Eval("CASCCode")%>'>
                                                                                                                                                                    </asp:Label>
                                                                                                                                                                </ItemTemplate>
                                                                                                                                                            </asp:TemplateField>

                                                                                                                                                            <asp:TemplateField HeaderText="Description" SortExpression="Id">
                                                                                                                                                                <ItemTemplate>
                                                                                                                                                                    <asp:Label ID="lblName1" runat="server"
                                                                                                                                                                        Text='<%#Eval("Description")%>'>
                                                                                                                                                                    </asp:Label>
                                                                                                                                                                </ItemTemplate>
                                                                                                                                                            </asp:TemplateField>
                                                                                                                                                            <asp:TemplateField HeaderText="UOM" SortExpression="Id">
                                                                                                                                                                <ItemTemplate>
                                                                                                                                                                    <asp:Label ID="lblUOM" runat="server"
                                                                                                                                                                        Text='<%#Eval("UOM")%>'>
                                                                                                                                                                    </asp:Label>
                                                                                                                                                                </ItemTemplate>
                                                                                                                                                            </asp:TemplateField>

                                                                                                                                                            <asp:TemplateField>
                                                                                                                                                                <ItemTemplate>
                                                                                                                                                                    <asp:LinkButton ID="lnkProductCode5" runat="server" CommandArgument='<%# Eval("Id") %>'>Select </asp:LinkButton>
                                                                                                                                                                </ItemTemplate>
                                                                                                                                                            </asp:TemplateField>
                                                                                                                                                        </Columns>
                                                                                                                                                    </asp:GridView>
                                                                                                                                                </ContentTemplate>

                                                                                                                                            </asp:UpdatePanel>
                                                                                                                                        </div>

                                                                                                                                        <div class="footer" align="right">
                                                                                                                                            <asp:Button ID="btnpc5Yes" runat="server" Text="Yes" CssClass="yes" />
                                                                                                                                            <asp:Button ID="btnpc5No" runat="server" Text="No" CssClass="no" />
                                                                                                                                        </div>
                                                                                                                                    </asp:Panel>



                                                                                                                                    <asp:TextBox autocomplete="off"  runat="server" type="text" ID="TxtProductCode5" MaxLength="17" ValidationGroup="Productcode" OnTextChanged="TxtProductCode5_TextChanged" AutoPostBack="true" TabIndex="142"></asp:TextBox>
                                                                                                                                    <br />
                                                                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProductCode5" ID="RegularExpressionValidator76" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>
                                                                                                                                    <br />
                                                                                                                                    <p>Quantity</p>
                                                                                                                                    <asp:TextBox autocomplete="off" onkeypress="return noAlphabets(event)"  Width="70" runat="server" type="text" ValidationGroup="Productcode" ID="TxtProQty5" MaxLength="16" TabIndex="245"></asp:TextBox>

                                                                                                                                    <asp:DropDownList CssClass="drop" ID="DrpP5" runat="server" Width="70" Height="25" TabIndex="246"></asp:DropDownList>

                                                                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProQty5" ID="RegularExpressionValidator77" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>

                                                                                                                                </div>
                                                                                                                                <div class="col-sm-9">

                                                                                                                                    <p>End User Description</p>
                                                                                                                                        <asp:TextBox autocomplete="off"  Width="100%" runat="server" type="text" ID="txtEndUserDec4" OnTextChanged="txtEndUserDec4_TextChanged" AutoPostBack ="true"   ValidationGroup="Productcode" TextMode="MultiLine" Text="" Style="text-transform :uppercase" TabIndex="240"></asp:TextBox>
                                                                                                                                        <br />
                                                                                                                                    <asp:Label ID="endusercount5" Visible="false" runat="server"></asp:Label>
                                                                                                                                         <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtEndUserDec4" ID="RegularExpressionValidator82" ValidationExpression="^[\s\S]{0,256}$" runat="server" ErrorMessage="Maximum 256 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>

                                                                                                                                     
                                                                                                                                        <br />


                                                                                                                                    <asp:GridView CssClass="table table-striped table-bordered table-hover" ID="ProductCode5Grid1" runat="server" ShowFooter="true" AutoGenerateColumns="false">
                                                                                                                                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                                                        <Columns>

                                                                                                                                            <asp:BoundField DataField="RowNumber" HeaderText="Row Number" Visible="false" />

                                                                                                                                            <asp:TemplateField HeaderText="CASC CODE 1">

                                                                                                                                                <ItemTemplate>

                                                                                                                                                    <asp:TextBox autocomplete="off"  ID="TextBox1" MaxLength="35" runat="server"></asp:TextBox>

                                                                                                                                                </ItemTemplate>

                                                                                                                                            </asp:TemplateField>

                                                                                                                                            <asp:TemplateField HeaderText="CASC CODE 2">

                                                                                                                                                <ItemTemplate>

                                                                                                                                                    <asp:TextBox autocomplete="off"  ID="TextBox2" MaxLength="35" runat="server"></asp:TextBox>

                                                                                                                                                </ItemTemplate>

                                                                                                                                            </asp:TemplateField>

                                                                                                                                            <asp:TemplateField HeaderText="CASC CODE 3">

                                                                                                                                                <ItemTemplate>

                                                                                                                                                    <asp:TextBox autocomplete="off"  ID="TextBox3" MaxLength="35" runat="server"></asp:TextBox>

                                                                                                                                                </ItemTemplate>
                                                                                                                                            </asp:TemplateField>
                                                                                                                                            <asp:TemplateField HeaderText="ADD">

                                                                                                                                                <ItemTemplate>
                                                                                                                                                    <asp:Button ID="ProductCode5Plus" OnClick="ProductCode5Plus_Click" runat="server" Text="Add" />
                                                                                                                                                </ItemTemplate>


                                                                                                                                            </asp:TemplateField>

                                                                                                                                        </Columns>

                                                                                                                                    </asp:GridView>
                                                                                                                                </div>
                                                                                                                            </div>

                                                                                                                        </div>
                                                                                                                    </div>
                                                                                                                </div>

                                                                                                                                                    </ContentTemplate>
                                                                                                                     </asp:UpdatePanel>

                                                                                                            </div>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                               </div>

                                                                                    <br />
                                                                                    <div id="Tariff" visible="false" runat="server">
                                                                                        <div class="panel panel-primary">
                                                                                            <div class="panel-heading">
                                                                                                <h4 class="panel-title">
                                                                                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapse2">TARIFF</a>
                                                                                                </h4>
                                                                                            </div>
                                                                                            <div id="collapse2" class="panel-collapse collapse in">
                                                                                                <div class="panel-body">
                                                                                                    <div class="row">
                                                                                                        <div class="col-sm-6">
                                                                                                            <div class="row">
                                                                                                                <div class="col-sm-6">
                                                                                                                    <p>Preferential Code</p>
                                                                                                                </div>
                                                                                                                <div class="col-sm-6">
                                                                                                                    <asp:DropDownList CssClass="drop" ID="DrpPreferentialCode" OnSelectedIndexChanged="DrpPreferentialCode_SelectedIndexChanged" AutoPostBack="true" runat="server" Width="250" Height="25" TabIndex="242"></asp:DropDownList>
                                                                                                                </div>
                                                                                                            </div>



                                                                                                        </div>
                                                                                                        <div class="col-sm-6">
                                                                                                        </div>
                                                                                                    </div>


                                                                                                    <br />

                                                                                                    <div id="Div1" class="row" style="background-color: black; color: white; height: 20px;" runat="server" visible="false">
                                                                                                        <div class="col-sm-6">
                                                                                                            Item
                                                                                                        </div>
                                                                                                        <div class="col-sm-2">
                                                                                                            Rate
                                                                                                        </div>
                                                                                                        <div class="col-sm-2">
                                                                                                            UOM
                                                                                                        </div>
                                                                                                        <div class="col-sm-2">
                                                                                                            Amount $
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <br />
                                                                                                    <div id="Div2" class="row" runat="server" visible="false">
                                                                                                        <div class="col-sm-6">
                                                                                                            GST (<asp:CheckBox ID="chk234" runat="server" TabIndex="243" />
                                                                                                            Auto-compute duties and taxes)
                                                                                                        </div>
                                                                                                        <div class="col-sm-2">
                                                                                                            <asp:TextBox autocomplete="off"  ID="ItemGSTRate" runat="server" Width="120" Text="244"></asp:TextBox>

                                                                                                        </div>
                                                                                                        <div class="col-sm-2">
                                                                                                            <asp:TextBox autocomplete="off"  ID="ItemGSTUOM" runat="server" Width="120" Text="PER" TabIndex="245"></asp:TextBox>

                                                                                                        </div>
                                                                                                        <div class="col-sm-2">
                                                                                                            <asp:TextBox autocomplete="off"  ID="TxtItemSumGST" runat="server" Width="120" Text="0.00" TabIndex="246"></asp:TextBox>
                                                                                                        </div>
                                                                                                    </div>


                                                                                                    <div id="exsDiv" class="row" runat="server" visible="false">
                                                                                                        <div class="col-sm-6">
                                                                                                            Excise Duty  
                                                                                                        </div>
                                                                                                        <div class="col-sm-2">
                                                                                                            <asp:TextBox autocomplete="off"  ID="TxtExciseDutyRate" runat="server" Width="120" Text="0.00" TabIndex="247"></asp:TextBox>
                                                                                                        </div>
                                                                                                        <div class="col-sm-2">
                                                                                                            <asp:TextBox autocomplete="off"  ID="TxtExciseDutyUOM" runat="server" Width="120" Text="0.00" TabIndex="248"></asp:TextBox>
                                                                                                        </div>
                                                                                                        <div class="col-sm-2">
                                                                                                            <asp:TextBox autocomplete="off"  ID="TxtSumExciseDuty" runat="server" Width="120" Text="0.00" TabIndex="249"></asp:TextBox>
                                                                                                        </div>
                                                                                                    </div>

                                                                                                    <div id="Div4" class="row" runat="server" visible="false">
                                                                                                        <div class="col-sm-6">
                                                                                                            <asp:Label ID="lblCustomsDuty" Text="Customs Duty" Width="120" runat="server"></asp:Label>
                                                                                                        </div>
                                                                                                        <div class="col-sm-2">
                                                                                                            <asp:TextBox autocomplete="off"  ID="TxtCustomsDutyRate" runat="server" Width="120" Text="0.00" TabIndex="250"></asp:TextBox>
                                                                                                        </div>
                                                                                                        <div class="col-sm-2">
                                                                                                            <asp:TextBox autocomplete="off"  ID="TxtCustomsDutyUOM" runat="server" Width="120" Text="0.00" TabIndex="251"></asp:TextBox>
                                                                                                        </div>
                                                                                                        <div class="col-sm-2">
                                                                                                            <asp:TextBox autocomplete="off"  ID="TxtSumCustomsDuty" runat="server" Width="120" Text="0.00" TabIndex="252"></asp:TextBox>
                                                                                                        </div>
                                                                                                    </div>

                                                                                                    <div id="Div5" class="row" runat="server" visible="false">
                                                                                                        <div class="col-sm-6">
                                                                                                            Other Tax 
                                                                                                        </div>
                                                                                                        <div class="col-sm-2">
                                                                                                            <asp:TextBox autocomplete="off"  ID="TxtOtherTaxRate" runat="server" Width="120" Text="0.00" TabIndex="253"></asp:TextBox>
                                                                                                        </div>
                                                                                                        <div class="col-sm-2">
                                                                                                            <asp:DropDownList CssClass="drop" ID="DrpOtherUOM" Width="120" runat="server" TabIndex="254"></asp:DropDownList>
                                                                                                        </div>
                                                                                                        <div class="col-sm-2">
                                                                                                            <asp:TextBox autocomplete="off"  ID="TxtSumOtherTaxRate" runat="server" Width="120" Text="0.00" TabIndex="255"></asp:TextBox>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div id="LOTID" visible="false" runat="server">
                                                                                        <div class="panel panel-primary">
                                                                                            <div class="panel-heading">
                                                                                                <h4 class="panel-title">
                                                                                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapse3">LOT Identification</a>
                                                                                                </h4>
                                                                                            </div>
                                                                                            <div id="collapse3" class="panel-collapse collapse in">
                                                                                                <div class="panel-body">

                                                                                                    <div class="row">
                                                                                                        <div class="col-sm-4">
                                                                                                            <p>Current Lot</p>
                                                                                                            <asp:TextBox autocomplete="off"  runat="server" type="text" ID="TxtCurrentLot" TabIndex="257" ValidationGroup="Item" class="w3-input w3-hover-green"></asp:TextBox>
                                                                                                            <br />

                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtCurrentLot" ID="RegularExpressionValidator83" ValidationExpression="^[\s\S]{0,30}$" runat="server" ErrorMessage="Maximum 30 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                                        </div>
                                                                                                        <div class="col-sm-4">
                                                                                                            <p>Marking </p>
                                                                                                            <asp:DropDownList CssClass="drop" Height="30" runat="server" ID="DrpMaking" Width="250" TabIndex="258"></asp:DropDownList>
                                                                                                        </div>
                                                                                                        <div class="col-sm-4">
                                                                                                            <p>Previous Lot</p>
                                                                                                            <asp:TextBox autocomplete="off"  runat="server" type="text" ID="TxtPreviousLot" TabIndex="259" ValidationGroup="Item" class="w3-input w3-hover-green"></asp:TextBox>
                                                                                                            <br />

                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtPreviousLot" ID="RegularExpressionValidator84" ValidationExpression="^[\s\S]{0,30}$" runat="server" ErrorMessage="Maximum 30 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                                        </div>
                                                                                                    </div>


                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>






                                                                                    <div class="panel panel-primary">
                                                                                        <div class="panel-heading">
                                                                                            <h4 class="panel-title">
                                                                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapse10">SHIPPING MARKS INFORMATION</a>
                                                                                            </h4>
                                                                                        </div>
                                                                                        <div id="collapse10" class="panel-collapse collapse ">
                                                                                            <div class="panel-body">
                                                                                                <div class="row">
                                                                                                    <asp:ValidationSummary ID="ValidationSummary14" runat="server" ShowMessageBox="True"
                                                                                                        ShowSummary="False" ValidationGroup="Shipping" />
                                                                                                    <div class="col-sm-3">
                                                                                                        <p style ="font-weight :bold ">Shipping Marks 1</p>
                                                                                                        <asp:TextBox autocomplete="off"  runat="server" type="text" ID="txtShippingMarks1" Style="text-transform: uppercase" MaxLength="17" TextMode="MultiLine" TabIndex="260" ValidationGroup="Shipping"></asp:TextBox>
                                                                                                        <br />
                                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtShippingMarks1" ID="RegularExpressionValidator85" ValidationExpression="^[\s\S]{0,170}$" runat="server" ErrorMessage="Maximum 170 characters allowed." ValidationGroup="Shipping"></asp:RegularExpressionValidator>
                                                                                                    </div>
                                                                                                    <div class="col-sm-3">
                                                                                                        <p style ="font-weight :bold">Shipping Marks 2</p>
                                                                                                        <asp:TextBox autocomplete="off"  runat="server" type="text" ID="txtShippingMarks2" Style="text-transform: uppercase" MaxLength="17" TextMode="MultiLine" TabIndex="261" ValidationGroup="Shipping"></asp:TextBox>
                                                                                                        <br />
                                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtShippingMarks2" ID="RegularExpressionValidator101" ValidationExpression="^[\s\S]{0,170}$" runat="server" ErrorMessage="Maximum 170 characters allowed." ValidationGroup="Shipping"></asp:RegularExpressionValidator>
                                                                                                    </div>
                                                                                                    <div class="col-sm-3">
                                                                                                        <p style ="font-weight :bold">Shipping Marks 3</p>
                                                                                                        <asp:TextBox autocomplete="off"  runat="server" type="text" ID="txtShippingMarks3" Style="text-transform: uppercase" MaxLength="17" TextMode="MultiLine" TabIndex="262" ValidationGroup="Shipping"></asp:TextBox>
                                                                                                        <br />
                                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtShippingMarks3" ID="RegularExpressionValidator86" ValidationExpression="^[\s\S]{0,136}$" runat="server" ErrorMessage="Maximum 136 characters allowed." ValidationGroup="Shipping"></asp:RegularExpressionValidator>
                                                                                                    </div>
                                                                                                    <div class="col-sm-3">
                                                                                                        <p style ="font-weight :bold">Shipping Marks 4</p>
                                                                                                        <asp:TextBox autocomplete="off"  runat="server" type="text" ID="txtShippingMarks4" MaxLength="17" TextMode="MultiLine" TabIndex="263" ValidationGroup="Shipping" Style="text-transform: uppercase"></asp:TextBox>
                                                                                                        <br />
                                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtShippingMarks4" ID="RegularExpressionValidator87" ValidationExpression="^[\s\S]{0,36}$" runat="server" ErrorMessage="Maximum 36 characters allowed." ValidationGroup="Shipping"></asp:RegularExpressionValidator>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                <hr />
                                                                                    <div id="cor" visible ="false"  runat ="server" >
                                                                                    <div class="panel panel-primary">
                                                                                        <div class="panel-heading">
                                                                                            <h4 class="panel-title">
                                                                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapse11">CERTIFICATE OF ORIGIN </a>
                                                                                            </h4>
                                                                                        </div>
                                                                                        <div id="collapse11" class="panel-collapse collapse ">
                                                                                            <div class="panel-body">
                                                                                                <asp:ValidationSummary ID="ValidationSummary15" runat="server" ShowMessageBox="True"
                                                                                                    ShowSummary="False" ValidationGroup="co" />

                                                                                                <asp:UpdatePanel ID="upcoorgin" runat="server" UpdateMode="Conditional">
                                                                                                                                                <ContentTemplate>
                                                                                                <div class="row">
                                                                                                    <div class="row">
                                                                                                        <div class="col-sm-2">
                                                                                                            <asp:Button ID="btncpy" runat="server" OnClick="btncpy_Click" Text="Copy Of HS Details" />
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div class="col-sm-4">
                                                                                                        <p  style ="font-weight :bold ">Certificate Item Quantity </p>
                                                                                                        <asp:TextBox autocomplete="off"  runat="server" type="text" Text="0.00" MaxLength="16" ValidationGroup="co" ID="TxtCerItemQty" TabIndex="264"></asp:TextBox>
                                                                                                        <asp:DropDownList CssClass="drop" ID="DrpCerItemUOM" runat="server" Width="70" Height="25" TabIndex="265"></asp:DropDownList><br />
                                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtCerItemQty" ID="RegularExpressionValidator88" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="co"></asp:RegularExpressionValidator>
                                                                                                        <p style ="font-weight :bold ">CIF/FOB Item Value on Certificate</p>
                                                                                                        <asp:TextBox autocomplete="off"  runat="server" Width="220" type="text" ValidationGroup="co" ID="TxtCIFCer" TabIndex="266" Text="0.00"></asp:TextBox>
                                                                                                        <br />
                                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtCIFCer" ID="RegularExpressionValidator89" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="co"></asp:RegularExpressionValidator>
                                                                                                        <p style ="font-weight :bold ">Manufacturing Cost Date</p>
                                                                                                        <div class='input-group date' id='ManufactureDate'>
                                                                                                            <asp:TextBox autocomplete="off"  ID="ManuDate" Style="width: 265px;" runat="server" TabIndex="267" AutoPostBack="true" OnTextChanged="ManuDate_TextChanged"></asp:TextBox>

                                                                                                            <cc1:CalendarExtender ID="CalendarExtender5"  PopupButtonID="imgPopup" CssClass="cal_Theme1" runat="server" TargetControlID="ManuDate" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"></cc1:CalendarExtender>

                                                                                                        </div>
                                                                                                        <br />
                                                                                                        <div id="textile" runat="server">
                                                                                                            <p style ="font-weight :bold ">Textile Category</ps>
                                                                                                            <asp:TextBox autocomplete="off"  Width="220" runat="server" type="text" ValidationGroup="co" ID="TxtTexCat" TabIndex="268"></asp:TextBox>
                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtTexCat" ID="RegularExpressionValidator92" ValidationExpression="^[\s\S]{0,5}$" runat="server" ErrorMessage="Maximum 5 characters allowed." ValidationGroup="co"></asp:RegularExpressionValidator>
                                                                                                            <br />
                                                                                                            <p style ="font-weight :bold ">Textile Quota Quantity </p>
                                                                                                            <asp:TextBox autocomplete="off"  runat="server" type="text" Text="0.00" ValidationGroup="co" ID="TxtTexQuota" TabIndex="269"></asp:TextBox>
                                                                                                            <asp:DropDownList CssClass="drop" ID="DrpTexQuotaUOM" runat="server" Width="70" Height="25" TabIndex="270"></asp:DropDownList><br />
                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtTexQuota" ID="RegularExpressionValidator90" ValidationExpression="^[\s\S]{0,5}$" runat="server" ErrorMessage="Maximum 5 characters allowed." ValidationGroup="co"></asp:RegularExpressionValidator>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div class="col-sm-4">
                                                                                                        <p style ="font-weight :bold ">Invoice Number</p>
                                                                                                        <asp:TextBox autocomplete="off"  runat="server" Width="220" type="text" ValidationGroup="co" ID="TxtCerInvoice" TabIndex="271"></asp:TextBox>
                                                                                                        <br />
                                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtCerInvoice" ID="RegularExpressionValidator91" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="co"></asp:RegularExpressionValidator>
                                                                                                        <p style ="font-weight :bold ">Invoice Date</p>
                                                                                                        <div class='input-group date' id='CerInvoiceDate'>

                                                                                                            <asp:TextBox autocomplete="off"  ID="InvDate" Style="width: 265px;" runat="server" TabIndex="272" AutoPostBack="true" OnTextChanged="InvDate_TextChanged"></asp:TextBox>
                                                                                                            <cc1:CalendarExtender ID="CalendarExtender6"  PopupButtonID="imgPopup" CssClass="cal_Theme1" runat="server" TargetControlID="InvDate" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"></cc1:CalendarExtender>

                                                                                                        </div>
                                                                                                        <br />
                                                                                                        <p style="margin-right: -65px;font-weight :bold ">
                                                                                                            Origin Criterion Code&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                                            <i class='fa fa-search' data-toggle="modal" data-target="#Origin"></i>
                                                                                                            <asp:Button ID="OriginAdd" runat="server" ValidationGroup="FREIGHT" OnClick="OriginAdd_Click" Text="+" />

                                                                                                        </p>
                                                                                                        <div class="modal fade" id="Origin" role="dialog">
                                                                                                            <div class="modal-dialog">

                                                                                                                <!-- INWARD CARRIER AGENT-->
                                                                                                                <div class="modal-content">
                                                                                                                    <div class="modal-header">
                                                                                                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                                                                                        <h4 class="modal-title">Origin Search
                                                                                                                        </h4>
                                                                                                                    </div>
                                                                                                                    <div class="modal-body">
                                                                                                                        <asp:TextBox autocomplete="off"  ID="OriginSearch" OnTextChanged="OriginSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                                        <br />
                                                                                                                        <asp:GridView ID="OriginGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="OriginGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                                                                                           <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>


                                                                                                                                <asp:TemplateField HeaderText="Code" SortExpression="Id">
                                                                                                                                    <ItemTemplate>
                                                                                                                                        <asp:Label ID="lblCode" runat="server"
                                                                                                                                            Text='<%#Eval("Code")%>'>
                                                                                                                                        </asp:Label>
                                                                                                                                    </ItemTemplate>
                                                                                                                                </asp:TemplateField>
                                                                                                                                <asp:TemplateField HeaderText="Description1" SortExpression="Id">
                                                                                                                                    <ItemTemplate>
                                                                                                                                        <asp:Label ID="lblName" runat="server"
                                                                                                                                            Text='<%#Eval("Description1")%>'>
                                                                                                                                        </asp:Label>
                                                                                                                                    </ItemTemplate>
                                                                                                                                </asp:TemplateField>

                                                                                                                                <asp:TemplateField HeaderText="Description2" SortExpression="Id">
                                                                                                                                    <ItemTemplate>
                                                                                                                                        <asp:Label ID="lblName1" runat="server"
                                                                                                                                            Text='<%#Eval("Description2")%>'>
                                                                                                                                        </asp:Label>
                                                                                                                                    </ItemTemplate>
                                                                                                                                </asp:TemplateField>
                                                                                                                                <asp:TemplateField HeaderText="Description3" SortExpression="Id">
                                                                                                                                    <ItemTemplate>
                                                                                                                                        <asp:Label ID="lblCRUEI" runat="server"
                                                                                                                                            Text='<%#Eval("Description3")%>'>
                                                                                                                                        </asp:Label>
                                                                                                                                    </ItemTemplate>
                                                                                                                                </asp:TemplateField>
                                                                                                                                <asp:TemplateField>
                                                                                                                                    <ItemTemplate>
                                                                                                                                        <asp:LinkButton ID="LnkOrigin" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkOrigin_Command">Select </asp:LinkButton>
                                                                                                                                    </ItemTemplate>
                                                                                                                                </asp:TemplateField>
                                                                                                                            </Columns>
                                                                                                                        </asp:GridView>
                                                                                                                    </div>
                                                                                                                    <div class="modal-footer">
                                                                                                                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                                                                                    </div>
                                                                                                                </div>

                                                                                                            </div>
                                                                                                        </div>

                                                                                                        <asp:TextBox autocomplete="off"  runat="server" OnTextChanged="OriginCode_TextChanged" AutoPostBack="true" Width="220" type="text"  ID="OriginCode" TabIndex="273"></asp:TextBox><br />
                                                                                                        <asp:TextBox autocomplete="off"  runat="server" Width="220" type="text" ValidationGroup="co" ID="OriginDes1" TabIndex="274"></asp:TextBox><br />
                                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="OriginDes1" ID="RegularExpressionValidator93" ValidationExpression="^[\s\S]{0,25}$" runat="server" ErrorMessage="Maximum 25 characters allowed." ValidationGroup="co"></asp:RegularExpressionValidator>
                                                                                                        <asp:TextBox autocomplete="off"  runat="server" Width="220" type="text"  ID="OriginDes2" TabIndex="275"></asp:TextBox><br />
                                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="OriginDes2" ID="RegularExpressionValidator94" ValidationExpression="^[\s\S]{0,25}$" runat="server" ErrorMessage="Maximum 25 characters allowed." ValidationGroup="co"></asp:RegularExpressionValidator>
                                                                                                        <asp:TextBox autocomplete="off"  runat="server" Width="220" type="text" ValidationGroup="co" ID="OriginDes3" TabIndex="276"></asp:TextBox><br />
                                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="OriginDes3" ID="RegularExpressionValidator95" ValidationExpression="^[\s\S]{0,25}$" runat="server" ErrorMessage="Maximum 25 characters allowed." ValidationGroup="co"></asp:RegularExpressionValidator>

                                                                                                        <p style ="font-weight :bold ">HS Code on Certificate</p>
                                                                                                        <asp:TextBox autocomplete="off"  Width="220" runat="server" type="text" ValidationGroup="co" ID="TxtHSCodeCer" TabIndex="277"></asp:TextBox>
                                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtHSCodeCer" ID="RegularExpressionValidator96" ValidationExpression="^[\s\S]{0,10}$" runat="server" ErrorMessage="Maximum 10 characters allowed." ValidationGroup="co"></asp:RegularExpressionValidator>
                                                                                                        <br />
                                                                                                        <p style ="font-weight :bold ">Percentage Content of Origin Criterion</p>
                                                                                                        <asp:TextBox autocomplete="off"  Width="220" runat="server" type="text" ValidationGroup="co" ID="TxtPerOrigin" TabIndex="278"></asp:TextBox>
                                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtPerOrigin" ID="RegularExpressionValidator97" ValidationExpression="^[\s\S]{0,3}$" runat="server" ErrorMessage="Maximum 3 characters allowed." ValidationGroup="co"></asp:RegularExpressionValidator>
                                                                                                        <br />

                                                                                                    </div>
                                                                                                    <div class="col-sm-4">
                                                                                                        <p style ="font-weight :bold ">
                                                                                                            Certificate Description
                                                                                                        </p>
                                                                                                        <asp:TextBox autocomplete="off"  runat="server" type="text" ID="TxtCerDes" ValidationGroup="co" OnTextChanged="TxtCerDes_TextChanged" AutoPostBack="true" TextMode="MultiLine" Style="text-transform :uppercase" Width="280" Height="400" TabIndex="279"></asp:TextBox>
                                                                                                        <asp:Label ID="lblcertdesc" runat="server" Visible="false"></asp:Label>
                                                                                                       
                                                                                                    </div>

                                                                                                </div>
                                                                                                                                                    </ContentTemplate>
                                                                                                    </asp:UpdatePanel>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                    </div>
                                                                                   
                                                                                   

                                                                                
                                                                                    
                                                                            
                                                                             <div class="row">
                                                                                                                                                                    <!-- Importer Search -->
                                                                            
                                                                                                                                                                    <div class="col-sm-8">
                                                                                                                                                                    </div>
                                                                                                                                                                    <div class="col-sm-4">
                                                                                                                                                                        <asp:Button ID="BtnItemAdd" CssClass="btn btn-block btn-success" ValidationGroup="Item" Visible ="false" runat="server" Text="Add Item" OnClick="BtnItemAdd_Click" />
                                                                            
                                                                                                                                                                    </div>
                                                                            
                                                                                                                                                                    <div class="col-sm-8">
                                                                                                                                                                    </div>
                                                                                                                                                                </div>
                                                                            </div>
                                                                            </div>
                                                                            <center>
                                                                              <div class="btn-group btn-group-lg" >
                                                                                <asp:Button  ID="btnprevitem" CssClass="nn" runat="server" class="btn btn-info btn-lg" OnClick="btnprevitem_Click" Text="Previous" TabIndex="280" />
                                                                                <asp:Button ID="btnsaveitem" CssClass="nn" runat="server" class="btn btn-info btn-lg" OnClick="BtnItemAdd_Click" Visible="false" Text="Add Item" TabIndex="281" />
                                                                                <asp:Button ID="btnresetitem" CssClass="nn" runat="server" class="btn btn-info btn-lg" OnClick="btnresetitem_Click" Text="Reset" TabIndex="282" />
                                                                                <asp:Button ID="btnnextitem" CssClass="nn" runat="server" class="btn btn-info btn-lg" OnClick="btnnextitem_Click" Text="Next" TabIndex="283" />

                                                                            </div>
                                                                                </center>

                                                                             <div class="row">
                                                                            <div class="col-sm-3">
                                                                            </div>
                                                                            <div class="col-sm-6">
                                                                                <%--<center>--%>
                                                                                  <asp:Label ID="lblitemalert" Visible="false" CssClass="hserror" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="Brown" runat="server"></asp:Label>
                                                                                    <%--<asp:Label id="lblitemalert" ></asp:Label>--%>
                                                                                    <%--</center>--%>
                                                                                </div>
                                                                             <div class="col-sm-3">
                                                                            </div>
                                                                        </div>

                                                                            <div id="ItemAddGrid" runat="server">
                                                                                <asp:TextBox autocomplete="off"  ID="AddItemSearch"  AutoPostBack="false" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                <br />
                                                                                <asp:GridView ID="AddItemGrid" Font-Size="10" OnRowDeleting="AddItemGrid_RowDeleting" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="AddItemGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                                                   <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>
                                                                                        <asp:TemplateField HeaderText="Del" Visible="false">
                                                                                            <ItemTemplate>

                                                                                                <asp:LinkButton data-target='<%#"#"+DataBinder.Eval(Container.DataItem,"Id")%>' Width="11" OnClick="imgItemDelete_Click" Height="11" ID="imgItemDelete" runat="server"><i class='fa fa-trash' style="color:red;"> </i></asp:LinkButton>



                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Edit">
                                                                                            <ItemTemplate>


                                                                                                <asp:ImageButton ImageUrl="~/IMG/edit.png" Width="11" Height="11" OnClick="ItemEdit_Click" ID="ItemEdit" runat="server" />




                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="ID" Visible="false" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblID" runat="server"
                                                                                                    Text='<%#Eval("Id")%>'>
                                                                                                </asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="S.no" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="ItemNo" runat="server"
                                                                                                    Text='<%#Eval("ItemNo")%>'>
                                                                                                </asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="HS Code" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="HSCode" runat="server"
                                                                                                    Text='<%#Eval("HSCode")%>'>
                                                                                                </asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>



                                                                                        <asp:TemplateField HeaderText="Description" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Description" runat="server"
                                                                                                    Text='<%#Eval("Description")%>'>
                                                                                                </asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>


                                                                                        <asp:TemplateField HeaderText="CO" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Contry" runat="server"
                                                                                                    Text='<%#Eval("Contry")%>'>
                                                                                                </asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>

                                                                                        <asp:TemplateField HeaderText="IN HAWB/HBL" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="InHAWBOBL" runat="server"
                                                                                                    Text='<%#Eval("InHAWBOBL")%>'>
                                                                                                </asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>

                                                                                       <asp:TemplateField HeaderText="OUT HAWB/HBL" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="OutHAWBOBL" runat="server"
                                                                                                    Text='<%#Eval("OutHAWBOBL")%>'>
                                                                                                </asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>

                                                                                        <asp:TemplateField HeaderText="Cur" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="UnitPriceCurrency" runat="server"
                                                                                                    Text='<%#Eval("UnitPriceCurrency")%>'>
                                                                                                </asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>


                                                                                        <asp:TemplateField HeaderText="CIFFOB" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="CIFFOB" runat="server"
                                                                                                    Text='<%#Eval("CIFFOB")%>'>
                                                                                                </asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>

                                                                                        <asp:TemplateField HeaderText="HS Qty" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="HSQty" runat="server"
                                                                                                    Text='<%#Eval("HSQty")%>'>
                                                                                                </asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>


                                                                                        <asp:TemplateField HeaderText="UOM" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="HSUOM" runat="server"
                                                                                                    Text='<%#Eval("HSUOM")%>'>
                                                                                                </asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>



                                                                                        <asp:TemplateField HeaderText="GST" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="GSTAmount" runat="server"
                                                                                                    Text='<%#Eval("GSTAmount")%>'>
                                                                                                </asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Line Amt" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="TotalLineAmount" runat="server"
                                                                                                    Text='<%#Eval("TotalLineAmount")%>'>
                                                                                                </asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                    <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                                                                </asp:GridView>
                                                                            </div>

                                                                          
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </ContentTemplate>
                                                            </cc1:TabPanel>
                                                            
                                                            <cc1:TabPanel ID="CPC" runat="server" CssClass="nn" HeaderText="CPC">
                                                                <ContentTemplate>
                                                                    <asp:UpdatePanel ID="outcpc" UpdateMode="Conditional" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:ValidationSummary ID="ValidationSummary21" runat="server" ShowMessageBox="True"
                                                                                ShowSummary="False" ValidationGroup="cpc" />

                                                                            <div class="row">
                                                                                <div class="col-sm-12">
                                                                                    <div class="row">
                                                                                        <div class="col-sm-2">
                                                                                            <asp:CheckBox ID="chkaeo" OnCheckedChanged="chkaeo_CheckedChanged" AutoPostBack="true" runat="server" Text="AEO" Checked="false" TabIndex="284" />
                                                                                        </div>
                                                                                        <div class="col-sm-10" id="AEO" runat="server">
                                                                                            <asp:Button ID="BtnAEO" runat="server" OnClick="BtnAEO_Click" Text="Add Row" />
                                                                                            <br />
                                                                                            <br />
                                                                                            <asp:GridView ID="AEOGrid" OnRowDeleting="AEOGrid_RowDeleting" CssClass="table table-striped table-bordered table-hover" runat="server" ShowFooter="true" AutoGenerateColumns="false">

                                                                                               <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>

                                                                                                    <asp:BoundField DataField="RowNumber" HeaderText="Row Number" />

                                                                                                    <asp:TemplateField HeaderText="Processing Code1">

                                                                                                        <ItemTemplate>

                                                                                                            <asp:TextBox autocomplete="off"  ID="TextBox1" runat="server" ValidationGroup="cpc" ></asp:TextBox>
                                                                                                            <br />
                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TextBox1" ID="aeopc1" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35characters allowed." ValidationGroup="cpc"></asp:RegularExpressionValidator>
                                                                                                        </ItemTemplate>

                                                                                                    </asp:TemplateField>

                                                                                                    <asp:TemplateField HeaderText="Processing Code2">

                                                                                                        <ItemTemplate>

                                                                                                            <asp:TextBox autocomplete="off"  ID="TextBox2" runat="server" ValidationGroup="cpc" ></asp:TextBox>
                                                                                                            <br />
                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TextBox2" ID="aeopc2" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35characters allowed." ValidationGroup="cpc"></asp:RegularExpressionValidator>
                                                                                                        </ItemTemplate>

                                                                                                    </asp:TemplateField>

                                                                                                    <asp:TemplateField HeaderText="Processing Code3">

                                                                                                        <ItemTemplate>

                                                                                                            <asp:TextBox autocomplete="off"  ID="TextBox3" runat="server" ValidationGroup="cpc" ></asp:TextBox>
                                                                                                            <br />
                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TextBox3" ID="aeopc" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35characters allowed." ValidationGroup="cpc"></asp:RegularExpressionValidator>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Delete">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:LinkButton data-toggle="modal" data-target='<%#"#"+DataBinder.Eval(Container.DataItem,"RowNumber")%>' Width="11" Height="11" ID="imgDelete" runat="server"><i class='fa fa-trash' style="color:red"></i></asp:LinkButton>

                                                                                                           <%-- <div class="modal fade" id='<%#Eval("RowNumber")%>' role="dialog">
                                                                                                                <div class="modal-dialog">

                                                                                                                    <!-- Modal content-->
                                                                                                                    <div class="modal-content" style="width: 50%; left: 30%; top: 200px;">
                                                                                                                        <div class="modal-header">
                                                                                                                        </div>
                                                                                                                        <div class="modal-footer">
                                                                                                                            <h4 class="modal-title">Are you sure to delete this Record?</h4>
                                                                                                                            <asp:Button ID="Button1" CommandName="delete" runat="server" OnClientClick='<%# DataBinder.Eval(Container.DataItem, "RowNumber", "javascript:return deletefunction(\"{0}\");")%> ' CssClass="btn btn-theme03 modal-add" Text="Yes"></asp:Button>
                                                                                                                            <button type="button" class="btn btn-theme03 modal-add" data-dismiss="modal">No</button>
                                                                                                                        </div>
                                                                                                                    </div>

                                                                                                                </div>
                                                                                                            </div>--%>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                </Columns>

                                                                                            </asp:GridView>

                                                                                        </div>
                                                                                    </div>
                                                                                    <hr />
                                                                                    <div class="row">
                                                                                        <div class="col-sm-2">
                                                                                            <asp:CheckBox ID="chkcwc" OnCheckedChanged="chkcwc_CheckedChanged" AutoPostBack="true" runat="server" Text="CWC" Checked="false" TabIndex="285" />
                                                                                        </div>
                                                                                        <div class="col-sm-10" id="CWC" runat="server">
                                                                                            <asp:Button ID="BtnCWC" runat="server" OnClick="BtnCWC_Click" Text="Add Row" />
                                                                                            <br />
                                                                                            <br />
                                                                                            <asp:GridView ID="CWCGrid" OnRowDeleting="CWCGrid_RowDeleting" CssClass="table table-striped table-bordered table-hover" runat="server" ShowFooter="true" AutoGenerateColumns="false">

                                                                                               <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>

                                                                                                    <asp:BoundField DataField="RowNumber" HeaderText="Row Number" />

                                                                                                    <asp:TemplateField HeaderText="Processing Code1">

                                                                                                        <ItemTemplate>

                                                                                                            <asp:TextBox autocomplete="off"  ID="TextBox1" runat="server" ValidationGroup="cpc" ></asp:TextBox>
                                                                                                            <br />
                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TextBox1" ID="cwcpc1" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35characters allowed." ValidationGroup="cpc"></asp:RegularExpressionValidator>
                                                                                                        </ItemTemplate>

                                                                                                    </asp:TemplateField>

                                                                                                    <asp:TemplateField HeaderText="Processing Code2">

                                                                                                        <ItemTemplate>

                                                                                                            <asp:TextBox autocomplete="off"  ID="TextBox2" runat="server" ValidationGroup="cpc" ></asp:TextBox>
                                                                                                            <br />
                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TextBox2" ID="cwcpc2" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35characters allowed." ValidationGroup="cpc"></asp:RegularExpressionValidator>
                                                                                                        </ItemTemplate>

                                                                                                    </asp:TemplateField>

                                                                                                    <asp:TemplateField HeaderText="Processing Code3">

                                                                                                        <ItemTemplate>

                                                                                                            <asp:TextBox autocomplete="off"  ID="TextBox3" runat="server" ValidationGroup="cpc"></asp:TextBox>
                                                                                                            <br />
                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TextBox3" ID="cwcpc3" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35characters allowed." ValidationGroup="cpc"></asp:RegularExpressionValidator>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Delete">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:LinkButton data-toggle="modal" data-target='<%#"#"+DataBinder.Eval(Container.DataItem,"RowNumber")%>' Width="11" Height="11" ID="imgDelete" runat="server"><i class='fa fa-trash' style="color:red"></i></asp:LinkButton>

                                                                                                           <%-- <div class="modal fade" id='<%#Eval("RowNumber")%>' role="dialog">
                                                                                                                <div class="modal-dialog">

                                                                                                                    <!-- Modal content-->
                                                                                                                    <div class="modal-content" style="width: 50%; left: 30%; top: 200px;">
                                                                                                                        <div class="modal-header">
                                                                                                                        </div>
                                                                                                                        <div class="modal-footer">
                                                                                                                            <h4 class="modal-title">Are you sure to delete this Record?</h4>
                                                                                                                            <asp:Button ID="Button1" CommandName="delete" runat="server" OnClientClick='<%# DataBinder.Eval(Container.DataItem, "RowNumber", "javascript:return deletefunction(\"{0}\");")%> ' CssClass="btn btn-theme03 modal-add" Text="Yes"></asp:Button>
                                                                                                                            <button type="button" class="btn btn-theme03 modal-add" data-dismiss="modal">No</button>
                                                                                                                        </div>
                                                                                                                    </div>

                                                                                                                </div>
                                                                                                            </div>
                                                       --%>                                                 </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                </Columns>

                                                                                            </asp:GridView>

                                                                                        </div>
                                                                                    </div>
                                                                                    <hr />
                                                                                    <div class="row">
                                                                                        <div class="col-sm-2">
                                                                                            <asp:CheckBox ID="ChkSea1" OnCheckedChanged="ChkSea1_CheckedChanged" AutoPostBack="true" runat="server" Text="SEA STORE" Checked="false" TabIndex="286" />
                                                                                        </div>
                                                                                        <div class="col-sm-10" id="SEA" runat="server">
                                                                                            <asp:Button ID="btnSeaStr" runat="server" OnClick="btnSeaStr_Click" Text="Add Row" />
                                                                                            <br />
                                                                                            <br />
                                                                                            <asp:GridView ID="SeaGrid" OnRowDeleting="SeaGrid_RowDeleting" CssClass="table table-striped table-bordered table-hover" runat="server" ShowFooter="true" AutoGenerateColumns="false">

                                                                                               <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>

                                                                                                    <asp:BoundField DataField="RowNumber" HeaderText="Row Number" />

                                                                                                    <asp:TemplateField HeaderText="Processing Code1">

                                                                                                        <ItemTemplate>

                                                                                                            <asp:TextBox autocomplete="off"  ID="TextBox1" runat="server" ValidationGroup="cpc" ></asp:TextBox>
                                                                                                            <br />
                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TextBox1" ID="seapc1" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35characters allowed." ValidationGroup="cpc"></asp:RegularExpressionValidator>
                                                                                                        </ItemTemplate>

                                                                                                    </asp:TemplateField>

                                                                                                    <asp:TemplateField HeaderText="Processing Code2">

                                                                                                        <ItemTemplate>

                                                                                                            <asp:TextBox autocomplete="off"  ID="TextBox2" runat="server" ValidationGroup="cpc" ></asp:TextBox>
                                                                                                            <br />
                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TextBox2" ID="seawcpc2" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35characters allowed." ValidationGroup="cpc"></asp:RegularExpressionValidator>
                                                                                                        </ItemTemplate>

                                                                                                    </asp:TemplateField>

                                                                                                    <asp:TemplateField HeaderText="Processing Code3">

                                                                                                        <ItemTemplate>

                                                                                                            <asp:TextBox autocomplete="off"  ID="TextBox3" runat="server" ValidationGroup="cpc" ></asp:TextBox>
                                                                                                            <br />
                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TextBox3" ID="seawcpc3" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35characters allowed." ValidationGroup="cpc"></asp:RegularExpressionValidator>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Delete">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:LinkButton data-toggle="modal" data-target='<%#"#"+DataBinder.Eval(Container.DataItem,"RowNumber")%>' Width="11" Height="11" ID="imgDelete" runat="server"><i class='fa fa-trash' style="color:red"></i></asp:LinkButton>

                                                                                                           <%-- <div class="modal fade" id='<%#Eval("RowNumber")%>' role="dialog">
                                                                                                                <div class="modal-dialog">

                                                                                                                    <!-- Modal content-->
                                                                                                                    <div class="modal-content" style="width: 50%; left: 30%; top: 200px;">
                                                                                                                        <div class="modal-header">
                                                                                                                        </div>
                                                                                                                        <div class="modal-footer">
                                                                                                                            <h4 class="modal-title">Are you sure to delete this Record?</h4>
                                                                                                                            <asp:Button ID="Button1" CommandName="delete" runat="server" OnClientClick='<%# DataBinder.Eval(Container.DataItem, "RowNumber", "javascript:return deletefunction(\"{0}\");")%> ' CssClass="btn btn-theme03 modal-add" Text="Yes"></asp:Button>
                                                                                                                            <button type="button" class="btn btn-theme03 modal-add" data-dismiss="modal">No</button>
                                                                                                                        </div>
                                                                                                                    </div>

                                                                                                                </div>
                                                                                                            </div>--%>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                </Columns>

                                                                                            </asp:GridView>

                                                                                        </div>
                                                                                    </div>
                                                                                    <hr />
                                                                                    <%-- STS --%>
                                                                                    <div class="row">
                                                                                        <div class="col-sm-2">
                                                                                            <asp:CheckBox ID="ChkSTS" OnCheckedChanged="ChkSTS_CheckedChanged" AutoPostBack="true" runat="server" Text="STS" Checked="false" TabIndex="287" />
                                                                                        </div>
                                                                                        <div class="col-sm-10" id="STS" runat="server">
                                                                                            <asp:Button ID="BtnSTS" runat="server" OnClick="BtnSTS_Click" Text="Add Row" />
                                                                                            <br />
                                                                                            <br />
                                                                                            <asp:GridView ID="STSGrid" OnRowDeleting="STSGrid_RowDeleting" CssClass="table table-striped table-bordered table-hover" runat="server" ShowFooter="true" AutoGenerateColumns="false">

                                                                                               <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>

                                                                                                    <asp:BoundField DataField="RowNumber" HeaderText="Row Number" />

                                                                                                    <asp:TemplateField HeaderText="Processing Code1">

                                                                                                        <ItemTemplate>

                                                                                                            <asp:TextBox autocomplete="off"  ID="TextBox1" OnTextChanged="TextBox1_TextChanged" ValidationGroup="cpc" AutoPostBack="true" runat="server" ></asp:TextBox>
                                                                                                            <br />
                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TextBox1" ID="STSpc1" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35characters allowed." ValidationGroup="cpc"></asp:RegularExpressionValidator>
                                                                                                        </ItemTemplate>

                                                                                                    </asp:TemplateField>

                                                                                                    <asp:TemplateField HeaderText="Processing Code2">

                                                                                                        <ItemTemplate>

                                                                                                            <asp:TextBox autocomplete="off"  ID="TextBox2" runat="server" ValidationGroup="cpc" ></asp:TextBox>
                                                                                                            <br />
                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TextBox2" ID="STSpc2" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35characters allowed." ValidationGroup="cpc"></asp:RegularExpressionValidator>
                                                                                                        </ItemTemplate>

                                                                                                    </asp:TemplateField>

                                                                                                    <asp:TemplateField HeaderText="Processing Code3">

                                                                                                        <ItemTemplate>

                                                                                                            <asp:TextBox autocomplete="off"  ID="TextBox3" runat="server" ValidationGroup="cpc" ></asp:TextBox>
                                                                                                            <br />
                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TextBox3" ID="STSpc3" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35characters allowed." ValidationGroup="cpc"></asp:RegularExpressionValidator>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Delete">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:LinkButton data-toggle="modal" data-target='<%#"#"+DataBinder.Eval(Container.DataItem,"RowNumber")%>' Width="11" Height="11" ID="imgDelete" runat="server"><i class='fa fa-trash' style="color:red"></i></asp:LinkButton>

                                                                                                         <%--   <div class="modal fade" id='<%#Eval("RowNumber")%>' role="dialog">
                                                                                                                <div class="modal-dialog">

                                                                                                                    <!-- Modal content-->
                                                                                                                    <div class="modal-content" style="width: 50%; left: 30%; top: 200px;">
                                                                                                                        <div class="modal-header">
                                                                                                                        </div>
                                                                                                                        <div class="modal-footer">
                                                                                                                            <h4 class="modal-title">Are you sure to delete this Record?</h4>
                                                                                                                            <asp:Button ID="Button1" CommandName="delete" runat="server" OnClientClick='<%# DataBinder.Eval(Container.DataItem, "RowNumber", "javascript:return deletefunction(\"{0}\");")%> ' CssClass="btn btn-theme03 modal-add" Text="Yes"></asp:Button>
                                                                                                                            <button type="button" class="btn btn-theme03 modal-add" data-dismiss="modal">No</button>
                                                                                                                        </div>
                                                                                                                    </div>

                                                                                                                </div>
                                                                                                            </div>--%>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                </Columns>

                                                                                            </asp:GridView>

                                                                                        </div>
                                                                                    </div>
                                                                                    <hr />
                                                                                    <%-- STSCWC--%>

                                                                                    <div class="row">
                                                                                        <div class="col-sm-2">
                                                                                            <asp:CheckBox ID="ChkSTSCWC" OnCheckedChanged="ChkSTSCWC_CheckedChanged" AutoPostBack="true" runat="server" Text=" STS & CWC" Checked="false" TabIndex="288" />
                                                                                        </div>
                                                                                        <div class="col-sm-10" id="STSCWC" runat="server">
                                                                                            <asp:Button ID="BtnSTSCWC" runat="server" OnClick="BtnSTSCWC_Click" Text="Add Row" />
                                                                                            <br />
                                                                                            <br />
                                                                                            <asp:GridView ID="STSCWCGrid" OnRowDeleting="STSCWCGrid_RowDeleting" CssClass="table table-striped table-bordered table-hover" runat="server" ShowFooter="true" AutoGenerateColumns="false">

                                                                                               <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>

                                                                                                    <asp:BoundField DataField="RowNumber" HeaderText="Row Number" />

                                                                                                    <asp:TemplateField HeaderText="Processing Code1">

                                                                                                        <ItemTemplate>

                                                                                                            <asp:TextBox autocomplete="off"  ID="TextBox1" runat="server" ValidationGroup="cpc" ></asp:TextBox>
                                                                                                            <br />
                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TextBox1" ID="STSCWCpc1" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35characters allowed." ValidationGroup="cpc"></asp:RegularExpressionValidator>
                                                                                                        </ItemTemplate>

                                                                                                    </asp:TemplateField>

                                                                                                    <asp:TemplateField HeaderText="Processing Code2">

                                                                                                        <ItemTemplate>

                                                                                                            <asp:TextBox autocomplete="off"  ID="TextBox2" runat="server" ValidationGroup="cpc" ></asp:TextBox>
                                                                                                            <br />
                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TextBox2" ID="STSCWCpc2" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35characters allowed." ValidationGroup="cpc"></asp:RegularExpressionValidator>
                                                                                                        </ItemTemplate>

                                                                                                    </asp:TemplateField>

                                                                                                    <asp:TemplateField HeaderText="Processing Code3">

                                                                                                        <ItemTemplate>

                                                                                                            <asp:TextBox autocomplete="off"  ID="TextBox3" runat="server" ValidationGroup="cpc" ></asp:TextBox>
                                                                                                            <br />
                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TextBox1" ID="STSCWCpc3" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35characters allowed." ValidationGroup="cpc"></asp:RegularExpressionValidator>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Delete">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:LinkButton data-toggle="modal" data-target='<%#"#"+DataBinder.Eval(Container.DataItem,"RowNumber")%>' Width="11" Height="11" ID="imgDelete" runat="server"><i class='fa fa-trash' style="color:red"></i></asp:LinkButton>

                                                                                                          <%--  <div class="modal fade" id='<%#Eval("RowNumber")%>' role="dialog">
                                                                                                                <div class="modal-dialog">

                                                                                                                    <!-- Modal content-->
                                                                                                                    <div class="modal-content">
                                                                                                                        <div class="modal-header">
                                                                                                                        </div>
                                                                                                                        <div class="modal-footer">
                                                                                                                            <h4 class="modal-title">Are you sure to delete this Record?</h4>
                                                                                                                            <asp:Button ID="Button1" CommandName="delete" runat="server" OnClientClick='<%# DataBinder.Eval(Container.DataItem, "RowNumber", "javascript:return deletefunction(\"{0}\");")%> ' CssClass="btn btn-theme03 modal-add" Text="Yes"></asp:Button>
                                                                                                                            <button type="button" class="btn btn-theme03 modal-add" data-dismiss="modal">No</button>
                                                                                                                        </div>
                                                                                                                    </div>

                                                                                                                </div>
                                                                                                            </div>--%>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                </Columns>

                                                                                            </asp:GridView>

                                                                                        </div>
                                                                                    </div>
                                                                                    <hr />
                                                                                    <div class="row">
                                                                                        <div class="col-sm-2">
                                                                                            <asp:CheckBox ID="ChkDefCo"  runat="server" OnCheckedChanged ="ChkDefCo_CheckedChanged" Text="Deferred Printing Of CO" Checked="false" TabIndex="289" />
                                                                                        </div>
                                                                                        <div class="col-sm-10" id="DFCWC" runat="server">
                                                                                             
																							<asp:Button ID="BtnDFC" runat="server" Visible ="false"   OnClick ="BtnDFC_Click" Text="Add Row" />
                                                                                            <br />
                                                                                            <br />
                                                                                            <asp:GridView ID="DFCGrid" OnRowDeleting="DFCGrid_RowDeleting" CssClass="table table-striped table-bordered table-hover" runat="server" ShowFooter="true" AutoGenerateColumns="false">

                                                                                               <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>

                                                                                                    <asp:BoundField DataField="RowNumber" HeaderText="Row Number" />

                                                                                                    <asp:TemplateField HeaderText="Processing Code1">

                                                                                                        <ItemTemplate>

                                                                                                            <asp:TextBox autocomplete="off"  ID="TextBox1" runat="server" ValidationGroup="cpc" ></asp:TextBox>
                                                                                                            <br />
                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TextBox1" ID="STSCWCpc1" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35characters allowed." ValidationGroup="cpc"></asp:RegularExpressionValidator>
                                                                                                        </ItemTemplate>

                                                                                                    </asp:TemplateField>

                                                                                                    <asp:TemplateField HeaderText="Processing Code2">

                                                                                                        <ItemTemplate>

                                                                                                            <asp:TextBox autocomplete="off"  ID="TextBox2" runat="server" ValidationGroup="cpc" ></asp:TextBox>
                                                                                                            <br />
                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TextBox2" ID="STSCWCpc2" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35characters allowed." ValidationGroup="cpc"></asp:RegularExpressionValidator>
                                                                                                        </ItemTemplate>

                                                                                                    </asp:TemplateField>

                                                                                                    <asp:TemplateField HeaderText="Processing Code3">

                                                                                                        <ItemTemplate>

                                                                                                            <asp:TextBox autocomplete="off"  ID="TextBox3" runat="server" ValidationGroup="cpc" ></asp:TextBox>
                                                                                                            <br />
                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TextBox1" ID="STSCWCpc3" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35characters allowed." ValidationGroup="cpc"></asp:RegularExpressionValidator>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Delete">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:LinkButton data-toggle="modal" data-target='<%#"#"+DataBinder.Eval(Container.DataItem,"RowNumber")%>' Width="11" Height="11" ID="imgDelete" runat="server"><i class='fa fa-trash' style="color:red"></i></asp:LinkButton>

                                                                                                           <%-- <div class="modal fade" id='<%#Eval("RowNumber")%>' role="dialog">
                                                                                                                <div class="modal-dialog">

                                                                                                                    <!-- Modal content-->
                                                                                                                    <div class="modal-content">
                                                                                                                        <div class="modal-header">
                                                                                                                        </div>
                                                                                                                        <div class="modal-footer">
                                                                                                                            <h4 class="modal-title">Are you sure to delete this Record?</h4>
                                                                                                                            <asp:Button ID="Button1" CommandName="delete" runat="server" OnClientClick='<%# DataBinder.Eval(Container.DataItem, "RowNumber", "javascript:return deletefunction(\"{0}\");")%> ' CssClass="btn btn-theme03 modal-add" Text="Yes"></asp:Button>
                                                                                                                            <button type="button" class="btn btn-theme03 modal-add" data-dismiss="modal">No</button>
                                                                                                                        </div>
                                                                                                                    </div>

                                                                                                                </div>
                                                                                                            </div>--%>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                </Columns>

                                                                                            </asp:GridView>

                                                                                        </div>

                                                                                        </div>
                                                                                    <hr />
                                                                                    <%--  cnb--%>
                                                                                    <div class="row">
                                                                                        <div class="col-sm-2">
                                                                                            <asp:CheckBox ID="chkcnb" runat="server" Text="CNB" OnCheckedChanged="chkcnb_CheckedChanged1" AutoPostBack="true" Checked="false" TabIndex="290" />
                                                                                        </div>
                                                                                        <div class="col-sm-10" id="CNB" runat ="server" >
                                                                                            <asp:Button ID="Btncnb" Visible ="false"  runat="server"  OnClick ="Btncnb_Click" Text="Add Row" />
                                                                                            <br />
                                                                                            <br />
                                                                                            <asp:GridView ID="CNBGrid" OnRowDeleting ="CNBGrid_RowDeleting" CssClass="table table-striped table-bordered table-hover" runat="server" ShowFooter="true" AutoGenerateColumns="false">

                                                                                               <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>

                                                                                                    <asp:BoundField DataField="RowNumber" HeaderText="Row Number" />

                                                                                                    <asp:TemplateField HeaderText="Processing Code1">

                                                                                                        <ItemTemplate>

                                                                                                            <asp:TextBox autocomplete="off"  ID="TextBox1" runat="server" ValidationGroup="cpc" ></asp:TextBox>
                                                                                                            <br />
                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TextBox1" ID="STSCWCpc1" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35characters allowed." ValidationGroup="cpc"></asp:RegularExpressionValidator>
                                                                                                        </ItemTemplate>

                                                                                                    </asp:TemplateField>

                                                                                                    <asp:TemplateField HeaderText="Processing Code2">

                                                                                                        <ItemTemplate>

                                                                                                            <asp:TextBox autocomplete="off"  ID="TextBox2" runat="server" ValidationGroup="cpc" ></asp:TextBox>
                                                                                                            <br />
                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TextBox2" ID="STSCWCpc2" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35characters allowed." ValidationGroup="cpc"></asp:RegularExpressionValidator>
                                                                                                        </ItemTemplate>

                                                                                                    </asp:TemplateField>

                                                                                                    <asp:TemplateField HeaderText="Processing Code3">

                                                                                                        <ItemTemplate>

                                                                                                            <asp:TextBox autocomplete="off"  ID="TextBox3" runat="server" ValidationGroup="cpc" ></asp:TextBox>
                                                                                                            <br />
                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TextBox1" ID="STSCWCpc3" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35characters allowed." ValidationGroup="cpc"></asp:RegularExpressionValidator>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Delete">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:LinkButton data-toggle="modal" data-target='<%#"#"+DataBinder.Eval(Container.DataItem,"RowNumber")%>' Width="11" Height="11" ID="imgDelete" runat="server"><i class='fa fa-trash' style="color:red"></i></asp:LinkButton>

                                                                                                           <%-- <div class="modal fade" id='<%#Eval("RowNumber")%>' role="dialog">
                                                                                                                <div class="modal-dialog">

                                                                                                                    <!-- Modal content-->
                                                                                                                    <div class="modal-content">
                                                                                                                        <div class="modal-header">
                                                                                                                        </div>
                                                                                                                        <div class="modal-footer">
                                                                                                                            <h4 class="modal-title">Are you sure to delete this Record?</h4>
                                                                                                                            <asp:Button ID="Button1" CommandName="delete" runat="server" OnClientClick='<%# DataBinder.Eval(Container.DataItem, "RowNumber", "javascript:return deletefunction(\"{0}\");")%> ' CssClass="btn btn-theme03 modal-add" Text="Yes"></asp:Button>
                                                                                                                            <button type="button" class="btn btn-theme03 modal-add" data-dismiss="modal">No</button>
                                                                                                                        </div>
                                                                                                                    </div>

                                                                                                                </div>
                                                                                                            </div>--%>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                </Columns>

                                                                                            </asp:GridView>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                                                                                        <div class="row">
    <div class="col-sm-12">
        <center>

            <div class="flex justify-between gap-4 md:flex-nowrap flex-wrap mt-6">
                <asp:Button ID="btnprevcpc" runat="server" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" OnClick="btnprevcpc_Click" Text="Previous" TabIndex="191" />
                <asp:Button ID="btnnextcpc" runat="server" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" OnClick="btnnextcpc_Click" Text="Next" TabIndex="192" />
            </div>
        </center>
    </div>
    <div class="col-sm-3">
    </div>
</div>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </ContentTemplate>
                                                            </cc1:TabPanel>
                                                            <%--</div>--%>
                                                            <%--<div role="tabpanel" class="tab-pane fade" id="Summary">--%>
                                                            <cc1:TabPanel ID="Summary" runat="server" CssClass="nn" HeaderText="Summary">
                                                                <ContentTemplate>
                                                                    <asp:UpdatePanel ID="outsummery" UpdateMode="Conditional" runat="server">
                                                                        <ContentTemplate>

                                                                            <div class="col-sm-12">

                                                                                <asp:ValidationSummary ID="ValidationSummary16" runat="server" ShowMessageBox="True"
                                                                                    ShowSummary="False" ValidationGroup="Summery" />
                                                                                <div class="row">
                                                                                    <div class="col-sm-12">
                                                                                        <div class="row">
                                                                                            <div class="col-sm-3">
                                                                                                <div class="form-group row">
                                                                                                    <label for="staticEmail" class="col-sm-6 col-form-label">
                                                                                                        No of Invoices
                                                                                                    </label>
                                                                                                    <div class="col-sm-6">
                                                                                                        <asp:TextBox autocomplete="off"  runat="server" Enabled="false"  Text="0.00"  Width="100" ForeColor="red" Font-Names="verdana" Font-Size="small" Font-Bold="true" type="text" ID="txtnoofinv" ></asp:TextBox>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-sm-3">
                                                                                                <div class="form-group row">
                                                                                                    <label for="staticEmail" class="col-sm-6 col-form-label">
                                                                                                        No of Items
                                                                                                    </label>
                                                                                                    <div class="col-sm-6">
                                                                                                        <asp:TextBox autocomplete="off"  runat="server" Enabled="false"  Text="0.00"  Width="100" ForeColor="red" Font-Names="verdana" Font-Size="small" Font-Bold="true" type="text" ID="txtnoofitm" ></asp:TextBox>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-sm-3" runat="server" id="sumlbl" visible="false"> 
                                                                                                <div class="form-group row">
                                                                                                    <label for="staticEmail" class="col-sm-6 col-form-label">
                                                                                                        Sum of Item Amt
                                                                                                    </label>
                                                                                                    <div class="col-sm-6">
                                                                                                        <asp:TextBox autocomplete="off"  runat="server" Enabled="false"  Text="0.00"  Width="100" ForeColor="red" Font-Names="verdana" Font-Size="small" Font-Bold="true" type="text" ID="txtitmAmt" ></asp:TextBox>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-sm-3">
                                                                                                <div class="form-group row">
                                                                                                    <label for="staticEmail" class="col-sm-6 col-form-label">
                                                                                                        Tot Inv CIF Val
                                                                                                    </label>
                                                                                                    <div class="col-sm-6">
                                                                                                        <asp:TextBox autocomplete="off"  runat="server" Enabled="false"  Text="0.00"  Width="100" ForeColor="red" Font-Names="verdana" Font-Size="small" Font-Bold="true" type="text" ID="txtcifVal" ></asp:TextBox>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="row">
                                                                                            <div class="col-sm-3">
                                                                                                <div class="form-group row">
                                                                                                    <label for="staticEmail" class="col-sm-6 col-form-label">
                                                                                                        Tot CIF/FOB Val
                                                                                                    </label>
                                                                                                    <div class="col-sm-6">
                                                                                                        <asp:TextBox autocomplete="off"  runat="server" Enabled="false"  Text="0.00"  Width="100" ForeColor="red" Font-Names="verdana" Font-Size="small" Font-Bold="true" type="text" ID="txtfobval" ></asp:TextBox>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-sm-3" >
                                                                                                 <div class="form-group row">
                                                                                                    <label for="staticEmail" class="col-sm-6 col-form-label">
                                                                                                        Sum Of Inv Amt
                                                                                                    </label>
                                                                                                    <div class="col-sm-6">
                                                                                                        <div id="div7" runat="server"></div>
                                                                                                         <asp:Label ID="lbltotinvAmt" Visible ="false"   runat="server" Text="0.00"></asp:Label>  
                                                                                                        <%--<asp:TextBox autocomplete="off"  runat="server" type="text" ID="txtinvAmt" TabIndex="1"></asp:TextBox>--%>
                                                                                                        <br />
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div class="form-group row" id="A" runat="server" visible="false">
                                                                                                    <label for="staticEmail" class="col-sm-6 col-form-label">
                                                                                                        Tot GST Amt
                                                                                                    </label>
                                                                                                    <div class="col-sm-6">
                                                                                                        <asp:TextBox autocomplete="off"  runat="server" Enabled="false"  Text="0.00"  Width="100" ForeColor="red" Font-Names="verdana" Font-Size="small" Font-Bold="true" type="text" ID="txttotgstAmt" ></asp:TextBox>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>

                                                                                             <div class="col-sm-3">
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-6 col-form-label">
                                                                                                    Sum Of Item Amt
                                                                                                </label>
                                                                                                <div class="col-sm-6">
                                                                                                    <div id="dIViTEMzzz" style="color:red;" runat="server"></div>
                                                                                                    <asp:Label ID="Label1" Visible ="false"  Text="0.00"  runat="server" ></asp:Label>
                                                                                                    <%--<asp:TextBox autocomplete="off"  runat="server" type="text" ID="txtinvAmt" TabIndex="1"></asp:TextBox>--%>
                                                                                                    <br />
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                            <div class="col-sm-3">
                                                                                                <div class="form-group row" id="b" runat="server" visible="false">
                                                                                                    <label for="staticEmail" class="col-sm-6 col-form-label">
                                                                                                        Tot Exc Duty Amt
                                                                                                    </label>
                                                                                                    <div class="col-sm-6">
                                                                                                        <asp:TextBox autocomplete="off"  runat="server" Enabled="false"  Text="0.00"  Width="100" type="text" ID="txttotexAmt" ></asp:TextBox>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-sm-3">
                                                                                                <div class="form-group row" id="c" runat="server" visible="false">
                                                                                                    <label for="staticEmail" class="col-sm-6 col-form-label">
                                                                                                        Tot Cus Duty Amt
                                                                                                    </label>
                                                                                                    <div class="col-sm-6">
                                                                                                        <asp:TextBox autocomplete="off"  runat="server" Enabled="false"  Text="0.00"  Width="100" type="text" ID="txtcusdutyAmt" ></asp:TextBox>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="row">
                                                                                            <div class="col-sm-3">
                                                                                                <div class="form-group row" id="d" runat="server" visible="false">
                                                                                                    <label for="staticEmail" class="col-sm-6 col-form-label">
                                                                                                        Tot Other Tax Amt
                                                                                                    </label>
                                                                                                    <div class="col-sm-6">
                                                                                                        <asp:TextBox autocomplete="off"  runat="server" Enabled="false"  Text="0.00"  Width="100" type="text" ID="txtothtaxAmt" ></asp:TextBox>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-sm-3">
                                                                                                <div class="form-group row" id="e" runat="server" visible="false">
                                                                                                    <label for="staticEmail" class="col-sm-6 col-form-label">
                                                                                                        Tot Amt Payable
                                                                                                    </label>
                                                                                                    <div class="col-sm-6">
                                                                                                        <asp:TextBox autocomplete="off"  runat="server" Enabled="false"  Text="0.00"  Width="100" type="text" ID="txtAmtPayble" ></asp:TextBox>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-sm-3">
                                                                                               
                                                                                            </div>
                                                                                            <div class="col-sm-3" id="fdfg" runat="server" visible="false">
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-6 col-form-label">
                                                                                                    Sum Of Item Amt
                                                                                                </label>
                                                                                                <div class="col-sm-6">
                                                                                                    <div id="dIViTEMz" style="color:red;" runat="server"></div>
                                                                                                    <asp:Label ID="Labelz1" Visible ="false" runat="server" Text="0.00"></asp:Label>
                                                                                                    <%--<asp:TextBox autocomplete="off"  runat="server" type="text" ID="txtinvAmt" TabIndex="1"></asp:TextBox>--%>
                                                                                                    <br />
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        </div>
                                                                                        <div class="row">
                                                                                            <asp:CheckBox ID="chkAuto" OnCheckedChanged="chkAuto_CheckedChanged" AutoPostBack="true" Width="200" runat="server" Text="Auto-Compute" TabIndex="295" />
                                                                                        </div>
                                                                                        <div class="row">
                                                                                        <div class="col-sm-12">
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-6 col-form-label">
                                                                                                </label>
                                                                                                <div class="col-sm-6">




                                                                                                    <p id="cusremarks" runat="server" visible="false">Customer Remarks(will Not be Submitted to Singapore Customs)</p>
                                                                                                    <asp:TextBox autocomplete="off"  ID="txtcusRemrk" Visible="false"  runat="server" TextMode="MultiLine" Height="70" Width="100%"></asp:TextBox>



                                                                                                </div>

                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="row">
                                                                                        <div class="col-sm-12">
                                                                                            Trader's Remarks(will be Submitted to Singapore Customs)
                                                                                                      <asp:Button ID="btninvnum" runat="server" OnClick="btninvnum_Click" Text="Append Invoice Number" /><asp:Button ID="Button3" TabIndex="296" OnClick="Button3_Click" runat="server" Text="Append Ex Rate" />&nbsp;&nbsp;Cross Reference   <asp:TextBox autocomplete="off"  runat="server" type="text" ID="TxtGrossReference" Style="text-transform: uppercase"></asp:TextBox>
                                                                                            <asp:TextBox autocomplete="off"  ID="txttrdremrk" ValidationGroup="Summery" runat="server" TextMode="MultiLine" OnTextChanged="txttrdremrk_TextChanged" AutoPostBack="true"  MaxLength="1024" TabIndex="246" Height="70" Width="100%" Style="text-transform: uppercase"></asp:TextBox>
                                                                                            <br />
                                                                                             <asp:Label ID="lbltradecount" runat="server"   Font-Size="medium" ></asp:Label>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txttrdremrk" ID="RegularExpressionValidator99" ValidationExpression="^[\s\S]{0,1024}$" runat="server" ErrorMessage="Maximum 1024 characters allowed." ValidationGroup="Summery"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="row">
                                                                                        <div class="col-sm-12">


                                                                                            <div class="form-group row">

                                                                                                <div class="col-sm-12">

                                                                                                    <p>INTERNAL REFERENCE</p>
                                                                                                    <asp:TextBox autocomplete="off"  ID="txtintremrk" runat="server"  Height="70" TabIndex="297" Width="100%" Style="text-transform: uppercase"></asp:TextBox>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                        <div class="row">
                                                                                            <div class="col-sm-12">
                                                                                                <div class="row Borderdiv" style="width: 100%">
                                                                                                    Declaration Summary
                                                                                                </div>
                                                                                                <br />
                                                                                            </div>
                                                                                            <div class="col-sm-12">
                                                                                                <div class="form-group row">
                                                                                                    <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                        Exporter
                                                                                                    </label>
                                                                                                    <div class="col-sm-9">
                                                                                                        <asp:Label ID="lblimporterparty" runat="server" Width="80%" Text="" Font-Size="Medium" Font-Bold="true"></asp:Label>
                                                                                                        <%--<asp:TextBox autocomplete="off"  runat="server" Enabled="false" Width="100" type="text" ID="TextBox25" TabIndex="1"></asp:TextBox>--%>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                              <div class="col-sm-6">
                                                                                                <div class="form-group row">
                                                                                                    <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                        In - OBL


                                                                                                    </label>
                                                                                                    <div class="col-sm-9">
                                                                                                        <asp:Label ID="INOBL" runat="server" Width="80%" Text="" Font-Size="Medium" Font-Bold="true"></asp:Label>
                                                                                                        <%--<asp:TextBox autocomplete="off"  runat="server" Enabled="false" Width="100" type="text" ID="TextBox25" TabIndex="1"></asp:TextBox>--%>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-sm-6">
                                                                                                <div class="form-group row">
                                                                                                    <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                    IN -   HBL
                                                                                                    </label>
                                                                                                    <div class="col-sm-9">
                                                                                                        <asp:Label ID="INHBLS" runat="server" Width="80%" Font-Size="Medium" Font-Bold="true"></asp:Label>
                                                                                                        <%--<asp:TextBox autocomplete="off"  runat="server" Enabled="false" Width="80%" type="text" ID="TextBox26" TabIndex="1"></asp:TextBox>--%>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-sm-6">
                                                                                                <div class="form-group row">
                                                                                                    <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                     OUT -   OBL


                                                                                                    </label>
                                                                                                    <div class="col-sm-9">
                                                                                                        <asp:Label ID="lbloblval" runat="server" Width="80%" Text="" Font-Size="Medium" Font-Bold="true"></asp:Label>
                                                                                                        <%--<asp:TextBox autocomplete="off"  runat="server" Enabled="false" Width="100" type="text" ID="TextBox25" TabIndex="1"></asp:TextBox>--%>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-sm-6">
                                                                                                <div class="form-group row">
                                                                                                    <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                     Out -   HBL
                                                                                                    </label>
                                                                                                    <div class="col-sm-9">
                                                                                                        <asp:Label ID="OUTHBL" runat="server" Width="80%" Font-Size="Medium" Font-Bold="true"></asp:Label>
                                                                                                        <%--<asp:TextBox autocomplete="off"  runat="server" Enabled="false" Width="80%" type="text" ID="TextBox26" TabIndex="1"></asp:TextBox>--%>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-sm-6">
                                                                                                <div class="form-group row">
                                                                                                    <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                        No of Packing


                                                                                                    </label>
                                                                                                    <div class="col-sm-9">
                                                                                                        <asp:Label ID="lblnoofpack" runat="server" Width="80%" Font-Size="Medium" Font-Bold="true"></asp:Label>
                                                                                                        <%--<asp:TextBox autocomplete="off"  runat="server" Enabled="false" Width="100" type="text" ID="TextBox30" TabIndex="1"></asp:TextBox>--%>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-sm-6">
                                                                                                <div class="form-group row">
                                                                                                    <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                        Gross Weight


                                                                                                    </label>
                                                                                                    <div class="col-sm-9">
                                                                                                        <asp:Label ID="lblgrossweight" runat="server" Width="80%" Text="" Font-Size="Medium" Font-Bold="true"></asp:Label>
                                                                                                        <%--<asp:TextBox autocomplete="off"  runat="server" Enabled="false"  Width="100"  type="text" ID="TextBox27" TabIndex="1"></asp:TextBox>--%>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-sm-6">
                                                                                                <div class="form-group row">
                                                                                                    <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                        Invoice Amount

                                                                                                    </label>
                                                                                                    <div class="col-sm-9">
                                                                                                        <asp:Label ID="lblinvoiceAmt" runat="server" Width="80%" Font-Size="Medium" Font-Bold="true"></asp:Label>
                                                                                                        <%--<asp:TextBox autocomplete="off"  runat="server" Enabled="false" Width="100" type="text" ID="TextBox28" TabIndex="1"></asp:TextBox>--%>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-sm-6">
                                                                                                <div class="form-group row" id="abc" runat="server" visible="false">
                                                                                                    <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                        Total Item GST

                                                                                                    </label>
                                                                                                    <div class="col-sm-9">
                                                                                                        <asp:Label ID="lblTotItemGst" runat="server" Width="80%" Font-Size="Medium" Font-Bold="true"></asp:Label>
                                                                                                        <%--<asp:TextBox autocomplete="off"  runat="server" Enabled="false" Width="100" type="text" ID="TextBox31" TabIndex="1"></asp:TextBox>--%>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                             <div class="col-sm-12">
                                                                                             <asp:Label ID="lblerror" runat="server" Visible ="false" BackColor ="Brown"  BorderStyle ="Solid" BorderWidth ="1px" ForeColor ="White"  Width="80%" Font-Size="Medium" Font-Bold="true"></asp:Label>
                                                                                        </div>
                                                                                            <div class="col-sm-12" id="DeclInd" runat="server" visible="false">
                                                                                                <div class="alert alert-danger" >
                                                                                                    <asp:CheckBox ID="chkalrt" runat="server" Checked="false" OnCheckedChanged ="chkalrt_CheckedChanged" TabIndex="299" />
                                                                                                    <strong></strong>I/We declare that all particulars in this application are true and correct
                                                                                                </div>

                                                                                            </div>
                                                                                            <br />
                                                                                            <div class="col-sm-12">
                                                                                               
                                                                                            </div>
                                                                                        </div>

                                                                                       
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                             
                                                                            <div class="row">
    <div class="col-sm-12">

        <center>

            <div class="flex justify-between gap-4 md:flex-nowrap flex-wrap mt-6" id="DeclBtn" runat="server" visible="false">
                 
                 <asp:Button ID="btnprevsum" runat="server" class="btn btn-info btn-lg" OnClick="btnprevsum_Click" Text="Previous" TabIndex="304" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full"  />
                 <asp:Button ID="btnsavesum" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" runat="server" class="btn btn-info btn-lg" OnClick="btnsavesum_Click" Text="Save" TabIndex="305" />
                 <asp:Button ID="btnresetsum" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" runat="server" class="btn btn-info btn-lg" OnClick="btnresetsum_Click" Text="Reset" TabIndex="306"  Visible="false"/>
                 <asp:Button ID="btnnextsum" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" runat="server" class="btn btn-info btn-lg" OnClick="btnnextsum_Click" Text="Next" TabIndex="307" />
                
            </div>
        </center>
    </div>
</div>

                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </ContentTemplate>
                                                            </cc1:TabPanel>
                                                            <%--</div>--%>
                                                            <%--<div role="tabpanel" class="tab-pane fade " id="Amend">--%>
                                                            <cc1:TabPanel ID="Amend" runat="server" CssClass="nn" Visible="false" HeaderText="Amend">
                                                                <ContentTemplate>
                                                                    <asp:UpdatePanel ID="outamend" UpdateMode="Conditional" runat="server">
                                                                        <ContentTemplate>
                                                                            <div class="row">
                                                                                <div class="col-sm-12">
                                                                                    <div class="row Borderdiv" style="width: 100%">Update Information</div>
                                                                                    <div class="row">
                                                                                        <div class="col-sm-6">
                                                                                            <p>Amendment Count</p>
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Width="300" type="text" ID="txtamoundcount" Text="1" Enabled="false" TabIndex="304"></asp:TextBox>
                                                                                            <br />
                                                                                            <p>Update Indicator</p>
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Width="300" type="text" ID="txtupdateindicator" TabIndex="305"></asp:TextBox>
                                                                                            <br />
                                                                                        </div>
                                                                                        <div class="col-sm-6">
                                                                                            <p>Permit Number</p>
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Width="300" type="text" ID="txtamendpermit" TabIndex="306"></asp:TextBox>
                                                                                            <br />
                                                                                            <p>Replacement Permit Number</p>
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Width="300" type="text" ID="txtreplacepermit" TabIndex="307"></asp:TextBox>
                                                                                            <br />
                                                                                        </div>
                                                                                    </div>

                                                                                </div>
                                                                            </div>
                                                                            <br />
                                                                            <div class="row">
                                                                                <div class="col-sm-12">
                                                                                    <div class="row Borderdiv" style="width: 100%">Amendment Information</div>
                                                                                    <p>Description Of Reason</p>
                                                                                    <asp:TextBox autocomplete="off"  runat="server" TextMode="MultiLine" Width="100%" type="text" ID="txtdescreason" TabIndex="308"></asp:TextBox>
                                                                                    <br />
                                                                                    <asp:CheckBox ID="ChkPermitvalEx" runat="server" Text="Permit Validity Extension" />
                                                                                    <br />
                                                                                    <p>Extend Import Period (Reason for Extension of validity for Temporary / Exhibit Cargoes)</p>
                                                                                    <asp:TextBox autocomplete="off"  runat="server" TextMode="MultiLine" Width="100%" type="text" ID="txtvalidity" TabIndex="309"></asp:TextBox>
                                                                                    <br />
                                                                                    <br />
                                                                                    <div class="row Borderdiv" style="width: 100%">Declaration Indicator</div>
                                                                                    <div class="alert alert-danger" id="AmendInd" runat="server" visible="false">
                                                                                        <asp:CheckBox ID="chkdec" runat="server" Checked="false" TabIndex="310" />
                                                                                        <strong></strong>I/We declare that all particulars in this application are true and correct
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <center>
                                                                     <div class="btn-group btn-group-lg" id="Amendbtn" runat="server" visible="false">
                                                                              <asp:Button ID="btnsaveamend" Visible="false"  CssClass="nn" runat="server" class="btn btn-info btn-lg" OnClick="btnsaveamend_Click" Text="Save" TabIndex="261" />
                                                                         </div>
                                                                                </center>
                                                                           <%-- <ul class="pager">
                                                                                <li class="previous"><a href="#Summary" data-toggle="tab" title="Previous">Previous</a></li>
                                                                                <li class="next"><a href="#Cancel" data-toggle="tab" title="Next">Next</a></li>
                                                                            </ul>--%>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </ContentTemplate>
                                                            </cc1:TabPanel>
                                                            <%--</div>--%>

                                                            <%--<div role="tabpanel" class="tab-pane fade " id="Cancel">--%>
                                                            <cc1:TabPanel ID="Cancel" runat="server" CssClass="nn" Visible="false" HeaderText="Cancel">
                                                                <ContentTemplate>
                                                                    <asp:UpdatePanel ID="outcancel" UpdateMode="Conditional" runat="server">
                                                                        <ContentTemplate>
                                                                            <div class="row">
                                                                                <div class="col-sm-12">
                                                                                    <div class="row Borderdiv" style="width: 100%">Update Information</div>
                                                                                    <div class="row">
                                                                                        <div class="col-sm-6">
                                                                                            <p>Update Indicator</p>
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Width="300" type="text" ID="txtupdateInd"></asp:TextBox>
                                                                                            <br />


                                                                                        </div>
                                                                                        <div class="col-sm-6">
                                                                                            <p>Permit Number</p>
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Width="300" type="text" ID="txtcanPermit"></asp:TextBox>
                                                                                            <br />
                                                                                            <p>Replacement Permit Number</p>
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Width="300" type="text" ID="txtcanrepPermit" ></asp:TextBox>
                                                                                            <br />
                                                                                        </div>
                                                                                    </div>

                                                                                </div>
                                                                            </div>
                                                                            <br />
                                                                            <div class="row">
                                                                                <div class="row Borderdiv" style="width: 100%">Cancellation Information</div>
                                                                                <div class="col-sm-6">
                                                                                    <p>Reason For Cancellation</p>
                                                                                    <asp:DropDownList CssClass="drop" ID="DrpReasonCancel" Width="300" Height="26" runat="server"></asp:DropDownList>
                                                                                </div>
                                                                                <div class="col-sm-6">
                                                                                    <p>Description For Reason</p>
                                                                                    <asp:TextBox autocomplete="off"  runat="server" TextMode="MultiLine" Width="100%" type="text" ID="txtdesReason" ></asp:TextBox>
                                                                                    <br />
                                                                                </div>
                                                                            </div>
                                                                            <br />
                                                                            <div class="row">
                                                                                <div class="col-sm-12" id="Div8" runat="server">

                                                                                    <div class="row">


                                                                                        <div class="col-sm-12">
                                                                                            <div class="row Borderdiv" style="width: 100%">
                                                                                                Referance Document
                                                                                            </div>

                                                                                            <div class="row">
                                                                                                <div class="col-sm-5">
                                                                                                    <p>Document Type</p>
                                                                                                    <asp:DropDownList CssClass="drop" ID="DrpDocumenttype" BackColor="#e8f0fe" Width="250" Height="32" AppendDataBoundItems="true"  runat="server">
                                                                                                    </asp:DropDownList><br />
                                                                                                    <asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator63" runat="server" ControlToValidate="DrpDocumenttype" InitialValue="0" ErrorMessage="Header --> Doc Type" ValidationGroup="Validationbtn"></asp:RequiredFieldValidator>
                                                                                                </div>
                                                                                                <div class="col-sm-5">
                                                                                                    <p>Attachment</p>
                                                                                                    <asp:FileUpload ID="FileUpload2" BackColor="#e8f0fe" runat="server"  class="btn" AllowMultiple="true" />
                                                                                                    <asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator67" runat="server" ControlToValidate="FileUpload2" ErrorMessage="Header -->Upload Doc" ValidationGroup="Validationbtn"></asp:RequiredFieldValidator>
                                                                                                </div>
                                                                                                <div class="col-sm-2">
                                                                                                    <p>Uplaod</p>
                                                                                                    <asp:Button runat="server" ID="BtnCancelUp" ValidationGroup="Validationbtn" class="btn btn-success" Text="Upload" OnClick="BtnCancelUp_Click" />

                                                                                                </div>
                                                                                            </div>


                                                                                            <hr />
                                                                                            <asp:GridView ID="GridCancelDoc" PageSize="5" OnRowDeleting="GridCancelDoc_RowDeleting" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="GridCancelDoc_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                                                               <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>
                                                                                                    <asp:TemplateField HeaderText="Delete">
                                                                                                        <ItemTemplate>

                                                                                                            <asp:LinkButton data-target='<%#"#"+DataBinder.Eval(Container.DataItem,"Id")%>' Width="11" OnClick="CancelDocDelete_Click" Height="11" ID="CancelDocDelete" runat="server"><i class='fa fa-trash' style="color:red;"> </i></asp:LinkButton>



                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="DocumentType" SortExpression="Id">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblDocType" runat="server"
                                                                                                                Text='<%#Eval("DocumentType")%>'>
                                                                                                            </asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Name" SortExpression="Id">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblName" runat="server"
                                                                                                                Text='<%#Eval("Name")%>'>
                                                                                                            </asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>


                                                                                                </Columns>
                                                                                            </asp:GridView>

                                                                                            <br />
                                                                                        </div>

                                                                                    </div>

                                                                                </div>
                                                                            </div>
                                                                            <br />
                                                                            <div class="row">
                                                                                <div class="col-sm-12">
                                                                                    <div class="row Borderdiv" style="width: 100%">
                                                                                        ADDITIONAL RECIPIENTS
                                                                                    </div>
                                                                                    <br />
                                                                                    <div class="row">
                                                                                        <div class="col-sm-4">
                                                                                            <p>RECIPIENTS 1</p>
                                                                                            <asp:TextBox autocomplete="off"  ID="TextBox15" Width="265" runat="server"  type="text"></asp:TextBox>

                                                                                            <br />
                                                                                        </div>
                                                                                        <div class="col-sm-4">
                                                                                            <p>RECIPIENTS 2</p>
                                                                                            <asp:TextBox autocomplete="off"  ID="TextBox16" Width="265" runat="server"  type="text"></asp:TextBox>

                                                                                            <br />
                                                                                        </div>
                                                                                        <div class="col-sm-4">
                                                                                            <p>RECIPIENTS 3</p>
                                                                                            <asp:TextBox autocomplete="off"  ID="TextBox17" Width="265" runat="server"  type="text"></asp:TextBox>

                                                                                            <br />
                                                                                        </div>
                                                                                    </div>
                                                                                    <br />
                                                                                    <br />
                                                                                </div>
                                                                            </div>
                                                                            <br />
                                                                            <div class="row">
                                                                                <div class="col-sm-12" id="CancelInd" runat="server" visible="false">
                                                                                    <div class="row Borderdiv" style="width: 100%">Declarent Indicator</div>
                                                                                    <div class="alert alert-danger">
                                                                                        <asp:CheckBox ID="CheckBox4" runat="server" Checked="false" ></asp:CheckBox>
                                                                                        <strong></strong>I/We declare that all particulars in this application are true and correct
                                                                                    </div>

                                                                                </div>
                                                                            </div>
                                                                            <center>
                                                                       <div class="btn-group btn-group-lg" id="CancelBtn" runat="server" visible="false">
                                                                          
                                                                            <asp:Button ID="btnsavecancel" Visible="false"  CssClass="nn" runat="server" class="btn btn-info btn-lg" OnClick="btnsavecancel_Click" Text="Save" TabIndex="277"  />
                                                                           

                                                                        </div>
                                                                 </center>
                                                                           <%-- <ul class="pager">
                                                                                <li class="previous"><a href="#Amend" data-toggle="tab" title="Previous">Previous</a></li>
                                                                                <%-- <li class="next"><a href="#Cancel" data-toggle="tab" title="Next">Next</a></li>--%>
                                                                            </ul>--%>
                                                                        </ContentTemplate>
                                                                          <Triggers>
                                                                        <asp:PostBackTrigger ControlID="BtnCancelUp" />
                                                                    </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </ContentTemplate>
                                                            </cc1:TabPanel>
                                                            <%--</div>--%>
                                                        </cc1:TabContainer>

                                                    </div>
                                                    </center>

                                                </div>

                                            

                        </div>






                    </div>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
