<%@ Page Title="" ClientIDMode="AutoID" Language="C#" MasterPageFile="~/Home.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="InNonPaymentView.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="RET.InNonPaymentView" ValidateRequest="false" %>

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

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode != 46 && charCode > 31
              && (charCode < 48 || charCode > 57))
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

        function myFunction() {




            $("#InnonPayment").css('color', 'White');
            debugger;
            $("#InnonPayment").css('background-color', 'Black');





        }
        function CheckOne(obj) {
            var grid = obj.parentNode.parentNode.parentNode;
            var inputs = grid.getElementsByTagName("input");
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type == "checkbox") {
                    if (obj.checked && inputs[i] != obj && inputs[i].checked) {
                        inputs[i].checked = false;
                    }
                }
            }
        }

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
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="innonpayment">
        <ProgressTemplate>
            <div class="overlay">
                <div style="z-index: 1000; margin-top: 300px; opacity: 1; -moz-opacity: 1;">
                    <center>
<img alt="" src="Loader.gif" width="100" height="100" /></center>
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="innonpayment" UpdateMode="Conditional" runat="server">

        <ContentTemplate>
            <br />
            <div class="row top-pad" style="margin-top: -17px; width:95%">
               <%-- <div class="col-md-12">
                    <ol class="breadcrumb">
                        <li class="active"><i class="fa fa-dashboard"></i>&nbsp;&nbsp;In Non - Payment</li>
                    </ol>
                </div>--%>
                <div class="col-md-12">
                    <div class="btn-group">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="Validation" />
                        <asp:Button ValidationGroup="Validation" ID="BtnSaveDraft" class="btn1 " TabIndex="-1" runat="server" Visible="false" OnClientClick="$('li:eq(2)', $('.nav-tabs')).tab('show')" OnClick="BtnSaveDraft_Click" Text="Save As Draft" />


                        <%--<button type="button" class="btn1  ">Save As Final</button>--%>
                        <button id="Button3" type="button" class="btn1 " runat="server" visible="false">Save and Submit</button>
                    </div>

                    <center>
                    <div class="btn-group ">
                        <button id="Button4" type="button" class="btn1 btn-primary" runat="server" visible="false">Print Status</button>
                        <button id="Button7" type="button" class="btn1 btn-primary" runat="server" visible="false">Print Draft CCP</button>

                        <asp:Button ID="BtnPrintCIF" runat="server" Visible="false" Text="Print CIF" OnClick="BtnPrintCIF_Click" class="btn btn-success" />

                    </div></center>
                    <div class="btn-group pull-right">


                        <asp:Button ID="BtnExit" runat="server" class="btn1 btn-danger"  Visible="false" OnClick="BtnExit_Click" Text="Exit Form" />
                    </div>
                </div>
            </div>
            <div class="container">
                <div class="row">
                    <div class="row">
                        <div class="col-md-12 col-lg-12 col-sm-12">






                            <cc1:ModalPopupExtender ID="POPUPERR" runat="server" PopupControlID="PanelErr" TargetControlID="BtnCls"
                                OkControlID="BtnCls" BackgroundCssClass="modalBackground">
                            </cc1:ModalPopupExtender>


                            <asp:Panel ID="PanelErr" runat="server" CssClass="modalPopup" Style="display: none;">
                                <div class="header">
                                </div>
                                <div class="body">
                                    <asp:GridView ID="GridError" PageSize="5" AllowPaging="True" OnPageIndexChanging="GridError_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false" Visible="false">
                                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                        <Columns>

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
                                        <!-- <h2>Welcome to IGHALO!<sup>™</sup></h2>-->
                                        <div class="board-inner">
                                            <div>


                                                <cc1:TabContainer ID="TabContainer1" AutoPostBack="true" runat="server" ActiveTabIndex="0" CssClass="Tab" Style="margin-top: -50px;" OnActiveTabChanged="TabContainer1_ActiveTabChanged" OnLoad="TabContainer1_ActiveTabChanged" >
                                                    
                                                    <cc1:TabPanel ID="Header" CssClass="ajax__tab_header" runat="server" HeaderText="Header">
                                                        <ContentTemplate>
                                                            <asp:UpdatePanel ID="innonheader" UpdateMode="Conditional" runat="server">
                                                                <ContentTemplate>


                                                                    <div class="row" style="margin-top: 100px;">
                                                                        <div class="col-sm-6">
                                                                            <div class="form-group row">
                                                                                <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                    Message Type
                                                                                </label>
                                                                                <div class="col-sm-9">
                                                                                    <%--<asp:TextBox autocomplete="off"  ID="TextBox18" Text="IPTDEC" Enabled="false" runat="server"    type="text" ></asp:TextBox>--%>
                                                                                    <asp:TextBox autocomplete="off"  ID="TxtMsgType" Text="INPDEC" Enabled="false" runat="server" type="text"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="form-group row">
                                                                                <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                    Declaration Type

                                                                                </label>
                                                                                <div class="col-sm-9">
                                                                                    <asp:DropDownList CssClass="drop" Style="text-transform: uppercase" ID="DrpDecType" OnSelectedIndexChanged="DrpDecType_SelectedIndexChanged" AutoPostBack="true" BackColor="#e8f0fe" Height="28" AppendDataBoundItems="true" TabIndex="1" runat="server">
                                                                                    </asp:DropDownList>
                                                                                    <asp:RequiredFieldValidator InitialValue="0" BackColor="Red" Width="265" ID="RequiredFieldValidator7" runat="server" ControlToValidate="DrpDecType" Display="None" ErrorMessage="Header --> Declaration Type is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>
                                                                            <div class="form-group row">
                                                                                <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                    Prev Permit No

                                                                                </label>
                                                                                <div class="col-sm-9">
                                                                                    <asp:TextBox autocomplete="off"  ID="TxtPrevPerNO" runat="server" type="text" TabIndex="2"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div id="cargo" runat="server" class="form-group row">
                                                                                <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                    Cargo Pack Type

                                                                                </label>
                                                                                <div class="col-sm-9">
                                                                                    <asp:DropDownList CssClass="drop" ID="DrpCargoPackType" BackColor="#e8f0fe" Height="28" OnSelectedIndexChanged="DrpCargoPackType_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true" TabIndex="3" runat="server">
                                                                                    </asp:DropDownList>
                                                                                    <asp:RequiredFieldValidator BackColor="Red" InitialValue="0" ID="RequiredFieldValidator5" runat="server" ControlToValidate="DrpCargoPackType" Display="None" ErrorMessage="Header --> Cargo Pack Type is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>
                                                                            <div id="Inward" runat="server" class="form-group row">
                                                                                <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                    <p id="inwared" runat="server" style="margin-left: -0px;">Inward Trans Mode</p>

                                                                                </label>
                                                                                <div class="col-sm-9">
                                                                                    <asp:DropDownList CssClass="drop" ID="DrpInwardtrasMode" BackColor="#e8f0fe" OnSelectedIndexChanged="DrpInwardtrasMode_SelectedIndexChanged" AutoPostBack="true" Height="28" AppendDataBoundItems="true" TabIndex="4" runat="server">
                                                                                    </asp:DropDownList>
                                                                                    <asp:RequiredFieldValidator BackColor="Red" InitialValue="0" ID="RequiredFieldValidator6" runat="server" ControlToValidate="DrpInwardtrasMode" Display="None" ErrorMessage="Header --> Inward Transport Mode is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>
                                                                            <div id="Outward" runat="server" class="form-group row">
                                                                                <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                    <p id="q" runat="server" style="margin-left: -0px;">Outward Trans Mode</p>

                                                                                </label>
                                                                                <div class="col-sm-9">
                                                                                    <asp:DropDownList CssClass="drop" ID="DrpOutwardtrasMode" BackColor="#e8f0fe" OnSelectedIndexChanged="DrpOutwardtrasMode_SelectedIndexChanged" AutoPostBack="true" Height="28" AppendDataBoundItems="true" TabIndex="5" runat="server">
                                                                                    </asp:DropDownList>
                                                                                    <asp:RequiredFieldValidator BackColor="Red" InitialValue="0" ID="RequiredFieldValidator31" runat="server" ControlToValidate="DrpOutwardtrasMode" Display="None" ErrorMessage="Header --> Outward Transport Mode is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>
                                                                            <div class="form-group row">
                                                                                <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                    BG Indicator

    

                                                                                </label>
                                                                                <div class="col-sm-9">
                                                                                    <asp:DropDownList CssClass="drop" ID="DrpBGIndicator" Height="28" AppendDataBoundItems="true" TabIndex="6" runat="server">
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                            </div>
                                                                            <div class="form-group row">
                                                                                <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                    override Ex Rate

    

                                                                                </label>
                                                                                <div class="col-sm-9">
                                                                                    <asp:CheckBox ID="ChkOverrExgRate" AutoPostBack="true" OnCheckedChanged="ChkOverrExgRate_CheckedChanged" runat="server" TabIndex="7" />
                                                                                </div>
                                                                            </div>
                                                                            <div class="form-group row">
                                                                                <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                    Supply indicator

    

                                                                                </label>
                                                                                <div class="col-sm-9">
                                                                                    <asp:CheckBox ID="ChkSupplyIndicator" runat="server" TabIndex="8" />
                                                                                </div>
                                                                            </div>
                                                                            <div class="form-group row">
                                                                                <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                    Ref Document   
                                                                                </label>
                                                                                <div class="col-sm-9">
                                                                                    <asp:CheckBox ID="ChkRefDoc" OnCheckedChanged="ChkRefDoc_CheckedChanged" AppendDataBoundItems="true" AutoPostBack="true" runat="server" TabIndex="9" />
                                                                                </div>
                                                                            </div>
                                                                        </div>

                                                                        <div class="col-sm-6">
                                                                            <div class="form-group row">
                                                                                <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                    Mailbox ID
                                                                                </label>
                                                                                <div class="col-sm-9">
                                                                                    <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe" Text="" type="text" Enabled="false" ID="TxtTradeMailID"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TxtTradeMailID" Display="None" ErrorMessage="Header --> TradeNet Mailbox ID is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>
                                                                            <div class="form-group row">
                                                                                <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                    Declarant Name
                                                                                </label>
                                                                                <div class="col-sm-9">
                                                                                    <asp:TextBox autocomplete="off"  ID="TxtDecName" BackColor="#e8f0fe" Text="" Enabled="false" runat="server" type="text"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtDecName" Display="None" ErrorMessage="Header --> Declarant Name is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="None" ControlToValidate="TxtDecName" ValidationExpression="[a-zA-Z ]*$" ErrorMessage="Enter a valid Name" ValidationGroup="Validation" />
                                                                                </div>
                                                                            </div>
                                                                            <div class="form-group row">
                                                                                <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                    Declaration Code
                                                                                </label>
                                                                                <div class="col-sm-9">
                                                                                    <asp:TextBox autocomplete="off"  ID="TxtDecCode" BackColor="#e8f0fe" Text="" Enabled="false" runat="server" type="text"></asp:TextBox>

                                                                                </div>
                                                                            </div>
                                                                            <div class="form-group row">
                                                                                <label for="staticEmail" class="col-sm-3 col-form-label">Declarant Tel</label>
                                                                                <div class="col-sm-9">
                                                                                    <asp:TextBox autocomplete="off"  ID="TxtDecTelephone" BackColor="#e8f0fe" Text="" runat="server" type="text"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtDecTelephone" Display="None" ErrorMessage="Header --> Declarant  Telephone is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                    <asp:RegularExpressionValidator ID="regPhone" runat="server" Display="None" ControlToValidate="TxtDecTelephone" ValidationExpression="[0-9]{10}" ErrorMessage="Enter a valid phone number" ValidationGroup="Validation" />
                                                                                </div>
                                                                            </div>
                                                                            <div class="form-group row">
                                                                                <label for="staticEmail" class="col-sm-3 col-form-label">CR UEI No</label>
                                                                                <div class="col-sm-9">
                                                                                    <asp:TextBox autocomplete="off"  ID="TxtCRUEINO" BackColor="#e8f0fe" Text="" Enabled="false" runat="server" type="text"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtCRUEINO" Display="None" ErrorMessage="Header --> CR UEI No is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>



                                                                            <div class="row">
                                                                                <div class="col-sm-12">
                                                                                    <asp:Label ID="txt_code" Visible="false" runat="server"></asp:Label>
                                                                                    <div class="row Borderdiv" style="width: 80%">
                                                                                        ADDITIONAL RECIPIENTS
                                                                                    </div>
                                                                                    <br />
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" style="font-family: 'Times New Roman';" class="col-sm-3 col-form-label">RECIPIENTS</label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  ID="TxtRECPT1" Width="265" runat="server" TabIndex="18" type="text" Style="text-transform: uppercase"></asp:TextBox>

                                                                                        </div>
                                                                                    </div>

                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" style="font-family: 'Times New Roman';" class="col-sm-3 col-form-label">RECIPIENTS 2</label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  ID="TxtRECPT2" Width="265" runat="server" TabIndex="19" type="text" Style="text-transform: uppercase"></asp:TextBox>

                                                                                        </div>
                                                                                    </div>


                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" style="font-family: 'Times New Roman';" class="col-sm-3 col-form-label">RECIPIENTS 3</label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  ID="TxtRECPT3" Width="265" runat="server" onkeypress="return isNumber(event)" TabIndex="20" type="text" Style="text-transform: uppercase"></asp:TextBox>

                                                                                        </div>
                                                                                    </div>




                                                                                </div>
                                                                            </div>




                                                                        </div>

                                                                    </div>

                                                                    <div class="row">
                                                                        <div class="col-sm-12" id="Document" runat="server">
                                                                            <div class="col-sm-6">
                                                                                <div class="row">
                                                                                    <div class="col-sm-12">

                                                                                        <div class="row Borderdiv" style="width: 95%">
                                                                                            License
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-sm-6">
                                                                                                <asp:TextBox autocomplete="off"  ID="TxtLicense1" runat="server" TabIndex="21" type="text"></asp:TextBox><br />
                                                                                                <br />
                                                                                                <asp:TextBox autocomplete="off"  ID="TxtLicense2" runat="server" TabIndex="22" type="text"></asp:TextBox><br />
                                                                                                <br />
                                                                                                <asp:TextBox autocomplete="off"  ID="TxtLicense3" runat="server" TabIndex="23" type="text"></asp:TextBox><br />
                                                                                                <br />
                                                                                            </div>
                                                                                            <div class="col-sm-6">
                                                                                                <asp:TextBox autocomplete="off"  ID="TxtLicense4" runat="server" TabIndex="24" type="text"></asp:TextBox><br />
                                                                                                <br />
                                                                                                <asp:TextBox autocomplete="off"  ID="TxtLicense5" runat="server" TabIndex="25" type="text"></asp:TextBox><br />
                                                                                                <br />
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>

                                                                            <div class="col-sm-6">
                                                                                <div class="row">

                                                                                    <div class="col-sm-12">
                                                                                        <div class="row Borderdiv" style="width: 95%">
                                                                                            Attachment Document
                                                                                        </div>

                                                                                        <div class="row">
                                                                                            <div class="col-sm-5">
                                                                                                <p>Document Type</p>
                                                                                                <asp:DropDownList CssClass="drop" ID="DrpDocType" BackColor="#e8f0fe" Width="200" Height="32" AppendDataBoundItems="true" TabIndex="26" runat="server">
                                                                                                </asp:DropDownList><br />
                                                                                                <asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator8" runat="server" ControlToValidate="DrpDocType" InitialValue="0" ErrorMessage="Header --> Doc Type" ValidationGroup="Validationbtn"></asp:RequiredFieldValidator>
                                                                                            </div>
                                                                                            <div class="col-sm-5">
                                                                                                <p>ATTACHMENT</p>
                                                                                                <asp:FileUpload ID="FileUpload1" BackColor="#e8f0fe" TabIndex="27" runat="server"  AllowMultiple="true" />
                                                                                                <asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator9" runat="server" ControlToValidate="FileUpload1" ErrorMessage="Header -->Upload Doc" ValidationGroup="Validationbtn"></asp:RequiredFieldValidator>
                                                                                            </div>
                                                                                            <div class="col-sm-2">
                                                                                                <p></p>
                                                                                                <asp:Button runat="server" ID="Btn_Upload" TabIndex="28" class="btn btn-success" Text="Upload" OnClick="Btn_Upload_Click" />

                                                                                            </div>
                                                                                        </div>


                                                                                        <hr />
                                                                                        <asp:GridView ID="GridView1" PageSize="5" OnRowDeleting="GridView1_RowDeleting" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                                                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                            <Columns>
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

                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                    </div>

                                                                      <asp:UpdatePanel ID="UpdatePercon" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
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

                                                                         
                                                                            <div class="col-sm-12">
                                                                                  <hr />
                                                                                                <asp:GridView HeaderStyle-Font-Size="X-Small" ShowHeaderWhenEmpty="true"   EmptyDataText="No Records found" PageSize="10" ID="GridCondition" Width="100%" FooterStyle-CssClass="bg-primary text-white"  HeaderStyle-CssClass="bg-primary text-white" RowStyle-CssClass="rows" Font-Bold ="true" PagerStyle-CssClass="pager"  AllowPaging="True" HeaderStyle-ForeColor="DarkBlue"  OnPageIndexChanging="GridCondition_PageIndexChanging"  CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="true">
                                                                                                    <%--<Columns>
                                                                                                       
                                                                                                         <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="false">
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblid" runat="server"
                                                                                                                    Text='<%#Eval("Id")%>'>
                                                                                                                </asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="Condition Code" SortExpression="Id">
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblConditionCode" runat="server"
                                                                                                                    Text='<%#Eval("ConditionCode")%>'>
                                                                                                                </asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="Condition Description" SortExpression="Id">
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblConditionDescription" runat="server"
                                                                                                                    Text='<%#Eval("ConditionDescription")%>'>
                                                                                                                </asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>


                                                                                                    </Columns>--%>
                                                                                                </asp:GridView>
                                                                            </div>
                                                                        </div>
                                                                       </ContentTemplate>

                                                                    </asp:UpdatePanel>


                                                    <div class="row">
                                                        <div class="col-sm-12">
                                                            <center>
                                                                <div id="Div4" runat="server" class="flex justify-between gap-4 md:flex-nowrap flex-wrap mt-6">
                                                                    <asp:Button ID="btnsaveheader" runat="server" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" OnClick="btnsaveheader_Click" Text="Save" TabIndex="21" />
                                                                    <asp:Button ID="btnresetheader" runat="server" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" OnClick="btnresetheader_Click" Text="Reset" TabIndex="22" />
                                                                    <asp:Button ID="btnnextheader" runat="server" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" OnClick="btnnextheader_Click" Text="Next" TabIndex="23" />
                                                                </div>
                                                            </center>
                                                        </div>
                                                    </div>

                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:PostBackTrigger ControlID="Btn_Upload" />
                                                                </Triggers>

                                                            </asp:UpdatePanel>
                                                            <%--  <a href="#Party" data-toggle="tab" title="Next">NEXT</a>--%>
                                                            <%-- <button type="button" id ="btnnext" onclick="" runat ="server" class="btn1 btn-primary">Next</button>--%>
                                                        </ContentTemplate>
                                                    </cc1:TabPanel>
                                                    <%--</div>--%>
                                                    <%--  <div role="tabpanel" class="tab-pane fade" id="Party"  >--%>
                                                    <cc1:TabPanel ID="Party" runat="server" CssClass="nn" HeaderText="Party">
                                                        <ContentTemplate>
                                                            <asp:UpdatePanel ID="upinnonparty" UpdateMode="Conditional" runat="server">
                                                                <ContentTemplate>



                                                                    <div class="row" style="margin-top: 100px;">
                                                                        <div class="col-sm-4">
                                                                            <div class="form-group row">

                                                                                <label for="staticEmail" class="col-sm-8 col-form-label">

                                                                                    <div class="row">
                                                                                        <div class="col-sm-8">
                                                                                            Declarant Company
                                                                                        </div>
                                                                                        <div class="col-sm-4">

                                                                                            <asp:ImageButton ID="btnShow" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />

                                                                                            <asp:Button ID="DECPLUS" runat="server" CssClass="plusbtn" BackColor="Transparent" BorderWidth="0px" ValidationGroup="PartyDec" OnClick="DECPLUS_Click" Text="+" />
                                                                                        </div>
                                                                                    </div>
                                                                                    <cc1:ModalPopupExtender ID="popupinnondec" runat="server" PopupControlID="pnldec" TargetControlID="btnShow" OkControlID="btnYes" CancelControlID="btnNo" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>

                                                                                    <asp:Panel ID="pnldec" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                        <div class="header">
                                                                                            Declarant Company
                                                                                        </div>
                                                                                        <div class="body">
                                                                                            <asp:UpdatePanel ID="upinnondec" runat="server" UpdateMode="Conditional">
                                                                                                <ContentTemplate>
                                                                                                    <asp:TextBox autocomplete="off"  ID="DecSearch" OnTextChanged="DecSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                    <br />
                                                                                                    <%-- <asp:UpdatePanel ID="DeclarantCompanySearch" runat="server"  UpdateMode="Always">

                                                        <ContentTemplate>--%>
                                                                                                    <asp:GridView ID="DECCOMPSearGRID" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="DECCOMPSearGRID_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" OnRowCommand="DECCOMPSearGRID_RowCommand" OnRowDataBound="DECCOMPSearGRID_RowDataBound" runat="server" AutoGenerateColumns="false">
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
                                                                                                                    <asp:LinkButton ID="lnkRequestID" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="lnkRequestID_Command">Select </asp:LinkButton>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                        </Columns>
                                                                                                    </asp:GridView>
                                                                                                    <%-- </ContentTemplate>
                                                           	
                                                            </asp:UpdatePanel>--%>
                                                                                                </ContentTemplate>
                                                                                                <%--<Triggers>
<asp:PostBackTrigger ControlID="DECCOMPSearGRID" />
  </Triggers>--%>
                                                                                            </asp:UpdatePanel>
                                                                                        </div>
                                                                                        <div class="footer" align="right">
                                                                                            <asp:Button ID="btnYes" runat="server" Text="Yes" CssClass="yes" />
                                                                                            <asp:Button ID="btnNo" runat="server" Text="No" CssClass="no" />
                                                                                        </div>
                                                                                    </asp:Panel>


                                                                                </label>
                                                                                <div class="col-sm-4">
                                                                                    <asp:TextBox autocomplete="off"  runat="server" placeholder="Code" Width="100" type="text" OnTextChanged="TxtDecCompCode_TextChanged" AutoPostBack="true" ID="TxtDecCompCode" Style="text-transform: uppercase" TabIndex="32"></asp:TextBox>                                                                                    
                                                                                    <cc1:AutoCompleteExtender
                                                                                            ID="AutoCompleteExtender1"
                                                                                            runat="server"
                                                                                            CompletionInterval="100"
                                                                                            FirstRowSelected="true"
                                                                                            MinimumPrefixLength="1"
                                                                                            DelimiterCharacters="1"
                                                                                            ServiceMethod="GetListofCountries"
                                                                                            ServicePath="~/InNonPayment.aspx"
                                                                                            Enabled="True"
                                                                                            CompletionListCssClass="ac_results"
                                                                                            CompletionListItemCssClass="listItem"
                                                                                            CompletionListHighlightedItemCssClass="itemHighlighted"
                                                                                            TargetControlID="TxtDecCompCode" />
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator63" runat="server" ControlToValidate="TxtDecCompCode" Display="None" ErrorMessage="Party --> Declarant Company Code is Required" ValidationGroup="PartyDec"></asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            <div class="form-group row">

                                                                                <div class="col-sm-12">
                                                                                    <asp:TextBox autocomplete="off"  ID="TxtDecCompCRUEI" ValidationGroup="PartyDec" placeholder="Cruei" Enabled="false" Width="170" runat="server" BackColor="#e8f0fe" TabIndex="33" Style="text-transform: uppercase" type="text"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="TxtDecCompCRUEI" Display="None" ErrorMessage="Party --> Declarant Company CR UEI is Required" ValidationGroup="PartyDec"></asp:RequiredFieldValidator>
                                                                                    <br />
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtDecCompCRUEI" ID="RegularExpressionValidator54" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="party"></asp:RegularExpressionValidator>

                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <div class="form-group row">

                                                                                <div class="col-sm-12">
                                                                                    <asp:TextBox autocomplete="off"  ID="TxtDecCompName" runat="server" placeholder="Name" ValidationGroup="PartyDec" Enabled="false" BackColor="#e8f0fe" TabIndex="34" Style="text-transform: uppercase" type="text"></asp:TextBox>
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtDecCompName" ID="RegularExpressionValidator52" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="PartyDec"></asp:RegularExpressionValidator>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TxtDecCompName" Display="None" ErrorMessage="Party --> Declarant Company Name is Required" ValidationGroup="PartyDec"></asp:RequiredFieldValidator>
                                                                                    <br />
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <div class="form-group row">

                                                                                <div class="col-sm-12">
                                                                                    <asp:TextBox autocomplete="off"  ID="TxtDecCompName1" ValidationGroup="PartyDec" placeholder="Name1" Style="text-transform: uppercase" runat="server" TabIndex="35" type="text"></asp:TextBox>
                                                                                    <br />
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtDecCompName1" ID="RegularExpressionValidator53" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="PartyDec"></asp:RegularExpressionValidator>

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
                                                                                            Importer
                                                                                        </div>
                                                                                        <div class="col-sm-4">

                                                                                            <asp:ImageButton ID="btninnonimp" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />

                                                                                            <asp:Button ID="BtnImpADD" runat="server" CssClass="plusbtn" BackColor="Transparent" BorderWidth="0px" ValidationGroup="PartyImp" OnClick="BtnImpADD_Click" Text="+" />
                                                                                        </div>
                                                                                    </div>



                                                                                    <%--<i class='fa fa-search' data-toggle="modal" data-target="#ImportSearch"></i>--%>
                                                                                    <cc1:ModalPopupExtender ID="popupinnonimp" runat="server" PopupControlID="pnlinnonimp" TargetControlID="btninnonimp"
                                                                                        OkControlID="btnYesinnonimp" CancelControlID="btnNoinnonimp" BackgroundCssClass="modalBackground">
                                                                                    </cc1:ModalPopupExtender>

                                                                                    <asp:Panel ID="pnlinnonimp" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                        <div class="header">
                                                                                            Importer
                                                                                        </div>
                                                                                        <div class="body">
                                                                                            <asp:UpdatePanel ID="upinnonimpgrid" runat="server" UpdateMode="Conditional">
                                                                                                <ContentTemplate>
                                                                                                    <asp:TextBox autocomplete="off"  ID="ImporterSearch" OnTextChanged="ImporterSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                    <br />
                                                                                                    <%--                                                        <asp:UpdatePanel ID="UpdatePanelImporterSearch" runat="server"  UpdateMode="Always">

                                                         <ContentTemplate>--%>
                                                                                                    <asp:GridView ID="ImporterGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ImporterGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover " OnRowCommand="ImporterGrid_RowCommand" OnRowDataBound="ImporterGrid_RowDataBound" runat="server" AutoGenerateColumns="false">
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
                                                                                                                    <asp:LinkButton ID="LnkImport" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkImport_Command">Select </asp:LinkButton>
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
                                                                                            <asp:Button ID="btnYesinnonimp" runat="server" Text="Yes" CssClass="yes" />
                                                                                            <asp:Button ID="btnNoinnonimp" runat="server" Text="No" CssClass="no" />
                                                                                        </div>
                                                                                    </asp:Panel>



                                                                                </label>
                                                                                <div class="col-sm-4">
                                                                                    <asp:TextBox autocomplete="off"  runat="server" Width="100" type="text" ID="TxtImpCode" placeholder="Code" Style="text-transform: uppercase" OnTextChanged="TxtImpCode_TextChanged" AutoPostBack="true" TabIndex="36"></asp:TextBox>
                                                                                    
                                                                                    <cc1:AutoCompleteExtender
                                                                                            ID="AutoCompleteExtender2"
                                                                                            runat="server"
                                                                                            CompletionInterval="100"
                                                                                            FirstRowSelected="true"
                                                                                            MinimumPrefixLength="1"
                                                                                            DelimiterCharacters="1"
                                                                                            ServiceMethod="GetImpcode"
                                                                                            ServicePath="~/InNonPayment.aspx"
                                                                                            Enabled="True"
                                                                                            CompletionListCssClass="ac_results"
                                                                                            CompletionListItemCssClass="listItem"
                                                                                            CompletionListHighlightedItemCssClass="itemHighlighted"
                                                                                            TargetControlID="TxtImpCode" />

                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator64" runat="server" ControlToValidate="TxtImpCode" Display="None" ErrorMessage="Party --> Importer Code is Required" ValidationGroup="PartyImp"></asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            <div class="form-group row">

                                                                                <div class="col-sm-12">
                                                                                    <asp:TextBox autocomplete="off"  ID="TxtImpCRUEI" Width="170" runat="server" placeholder="Cruei" ValidationGroup="PartyImp" Style="text-transform: uppercase" BackColor="#e8f0fe" TabIndex="37" type="text"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="TxtImpCRUEI" Display="None" ErrorMessage="Party --> Importer CRUEI is Required" ValidationGroup="PartyImp"></asp:RequiredFieldValidator>
                                                                                    <br />
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtImpCRUEI" ID="RegularExpressionValidator57" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="PartyImp"></asp:RegularExpressionValidator>
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <div class="form-group row">

                                                                                <div class="col-sm-12">
                                                                                    <asp:TextBox autocomplete="off"  ID="TxtImpName" Style="text-transform: uppercase" placeholder="Name" runat="server" ValidationGroup="PartyImp" BackColor="#e8f0fe" TabIndex="38" type="text"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TxtImpName" Display="None" ErrorMessage="Party --> Importer Name is Required" ValidationGroup="PartyImp"></asp:RequiredFieldValidator>
                                                                                    <br />
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtImpName" ID="RegularExpressionValidator55" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="PartyImp"></asp:RegularExpressionValidator>
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <div class="form-group row">

                                                                                <div class="col-sm-12">
                                                                                    <asp:TextBox autocomplete="off"  ID="TxtImpName1" Style="text-transform: uppercase" placeholder="Name1" runat="server" ValidationGroup="PartyImp" TabIndex="39" type="text"></asp:TextBox>
                                                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator65" runat="server" ControlToValidate="TxtImpName1" Display="None" ErrorMessage="Party --> Importer Name is Required" ValidationGroup="PartyImp"></asp:RequiredFieldValidator>--%>
                                                                                    <br />
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtImpName1" ID="RegularExpressionValidator56" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="PartyImp"></asp:RegularExpressionValidator>
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                    </div>

                                                                    <div id="ExpParty" visible="false" runat="server" class="row">
                                                                        <div class="col-sm-4">
                                                                            <div class="form-group row">
                                                                                <label for="staticEmail" class="col-sm-8 col-form-label">
                                                                                    <div class="row">
                                                                                        <div class="col-sm-8">
                                                                                            Exporter
                                                                                        </div>
                                                                                        <div class="col-sm-4">

                                                                                            <asp:ImageButton ID="btninnonexp" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />

                                                                                            <asp:Button ID="BtnExpAdd" runat="server" CssClass="plusbtn" BackColor="Transparent" BorderWidth="0px" ValidationGroup="PartyExp" OnClick="BtnExpAdd_Click" Text="+" />

                                                                                        </div>
                                                                                    </div>



                                                                                    <cc1:ModalPopupExtender ID="Popupexp" runat="server" PopupControlID="pnlinnonexp" TargetControlID="btninnonexp"
                                                                                        OkControlID="btnYesinnonexp" CancelControlID="btnNoinnonexp" BackgroundCssClass="modalBackground">
                                                                                    </cc1:ModalPopupExtender>

                                                                                    <asp:Panel ID="pnlinnonexp" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                        <div class="header">
                                                                                            Exporter
                                                                                        </div>
                                                                                        <div class="body">
                                                                                            <asp:UpdatePanel ID="upinnonexpgrid" runat="server" UpdateMode="Conditional">
                                                                                                <ContentTemplate>
                                                                                                    <asp:TextBox autocomplete="off"  ID="ExporterSearch" OnTextChanged="ExporterSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                    <br />
                                                                                                    <%-- <asp:UpdatePanel ID="UpdatePanelEXPORTERSearch" runat="server"  UpdateMode="Always">

                                                            <ContentTemplate>--%>
                                                                                                    <asp:GridView ID="ExporterGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ExporterGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" OnRowCommand="ExporterGrid_RowCommand" OnRowDataBound="ExporterGrid_RowDataBound" runat="server" AutoGenerateColumns="false">
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
                                                                                            <asp:Button ID="btnYesinnonexp" runat="server" Text="Yes" CssClass="yes" />
                                                                                            <asp:Button ID="btnNoinnonexp" runat="server" Text="No" CssClass="no" />
                                                                                        </div>
                                                                                    </asp:Panel>

                                                                                </label>
                                                                                <div class="col-sm-4">
                                                                                    <asp:TextBox autocomplete="off"  runat="server" Width="100" type="text" Style="text-transform: uppercase" placeholder="Code" ID="TxtExpCode" OnTextChanged="TxtExpCode_TextChanged" AutoPostBack="true" TabIndex="40"></asp:TextBox>                                                                                    
                                                                                    <cc1:AutoCompleteExtender
                                                                                            ID="AutoCompleteExtender3"
                                                                                            runat="server"
                                                                                            CompletionInterval="100"
                                                                                            FirstRowSelected="true"
                                                                                            MinimumPrefixLength="1"
                                                                                            DelimiterCharacters="1"
                                                                                            ServiceMethod="GetExpcode"
                                                                                            ServicePath="~/InNonPayment.aspx"
                                                                                            Enabled="True"
                                                                                            CompletionListCssClass="ac_results"
                                                                                            CompletionListItemCssClass="listItem"
                                                                                            CompletionListHighlightedItemCssClass="itemHighlighted"
                                                                                            TargetControlID="TxtExpCode" />
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator67" runat="server" ControlToValidate="TxtExpCode" Display="None" ErrorMessage="Party --> Exporter Name is Required" ValidationGroup="PartyExp"></asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            <div class="form-group row">

                                                                                <div class="col-sm-12">
                                                                                    <asp:TextBox autocomplete="off"  ID="TxtExpCRUEI" Width="170" runat="server" Style="text-transform: uppercase" placeholder="Cruei" ValidationGroup="PartyExp" BackColor="#e8f0fe" TabIndex="41" type="text"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="TxtDecCompCRUEI" Display="None" ErrorMessage="Exporter --> Importer CRUEI is Required" ValidationGroup="PartyExp"></asp:RequiredFieldValidator>
                                                                                    <br />
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtExpCRUEI" ID="RegularExpressionValidator58" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="PartyExp"></asp:RegularExpressionValidator>
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <div class="form-group row">

                                                                                <div class="col-sm-12">
                                                                                    <asp:TextBox autocomplete="off"  ID="TxtExpName" runat="server" Style="text-transform: uppercase" placeholder="Name" BackColor="#e8f0fe" TabIndex="42" type="text" ValidationGroup="PartyExp"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ControlToValidate="TxtDecCompCRUEI" Display="None" ErrorMessage="Party --> Exporter Name is Required" ValidationGroup="PartyExp"></asp:RequiredFieldValidator>
                                                                                    <br />
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtExpName" ID="RegularExpressionValidator6" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="PartyExp"></asp:RegularExpressionValidator>
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <div class="form-group row">

                                                                                <div class="col-sm-12">
                                                                                    <asp:TextBox autocomplete="off"  ID="TxtExpName1" runat="server" Style="text-transform: uppercase" placeholder="Name1" TabIndex="43" type="text" ValidationGroup="PartyExp"></asp:TextBox>
                                                                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator66" runat="server" ControlToValidate="TxtExpName1" Display="None" ErrorMessage="Party --> Exporter Name is Required" ValidationGroup="PartyExp"></asp:RequiredFieldValidator>--%>
                                                                                    <br />
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtExpName1" ID="RegularExpressionValidator2" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="PartyExp"></asp:RegularExpressionValidator>
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
                                                                                            Inward Carrier Agent
                                                                                        </div>
                                                                                        <div class="col-sm-4">

                                                                                            <asp:ImageButton ID="btninnoninw" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />

                                                                                            <asp:Button ID="InwardAdd" runat="server" CssClass="plusbtn" BackColor="Transparent" BorderWidth="0px" ValidationGroup="PartyInw" OnClick="InwardAdd_Click" Text="+" />

                                                                                        </div>
                                                                                    </div>




                                                                                    <cc1:ModalPopupExtender ID="popupinnoninw" runat="server" PopupControlID="pnlinnoninw" TargetControlID="btninnoninw"
                                                                                        OkControlID="btnYesinnoninw" CancelControlID="btnNoinnoninw" BackgroundCssClass="modalBackground">
                                                                                    </cc1:ModalPopupExtender>
                                                                                    <asp:Panel ID="pnlinnoninw" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                        <div class="header">
                                                                                            Inward Carrier Agent
                                                                                        </div>
                                                                                        <div class="body">
                                                                                            <asp:UpdatePanel ID="upinnoninwgrid" runat="server" UpdateMode="Conditional">
                                                                                                <ContentTemplate>
                                                                                                    <asp:TextBox autocomplete="off"  ID="InwardSearch" OnTextChanged="InwardSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                    <br />

                                                                                                    <%--  <asp:UpdatePanel ID="UpdatePanelInwardSearch" runat="server"  UpdateMode="Always">

                                                        <ContentTemplate>--%>

                                                                                                    <asp:GridView ID="InwardGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="InwardGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" OnRowCommand="InwardGrid_RowCommand" OnRowDataBound="InwardGrid_RowDataBound" runat="server" AutoGenerateColumns="false">
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
                                                                                                </ContentTemplate>
                                                                                                <%-- <Triggers>
<asp:PostBackTrigger ControlID="InwardGrid" />
  </Triggers>--%>
                                                                                            </asp:UpdatePanel>
                                                                                        </div>
                                                                                        <div class="footer" align="right">
                                                                                            <asp:Button ID="btnYesinnoninw" runat="server" Text="Yes" CssClass="yes" />
                                                                                            <asp:Button ID="btnNoinnoninw" runat="server" Text="No" CssClass="no" />
                                                                                        </div>
                                                                                    </asp:Panel>

                                                                                </label>
                                                                                <div class="col-sm-4">
                                                                                    <asp:TextBox autocomplete="off"  runat="server" Width="100" Style="text-transform: uppercase" placeholder="Code" type="text" AutoPostBack="true" ID="InwardCode" OnTextChanged="InwardCode_TextChanged" TabIndex="44"></asp:TextBox>
                                                                                    
                                                                                    <cc1:AutoCompleteExtender
                                                                                            ID="AutoCompleteExtender4"
                                                                                            runat="server"
                                                                                            CompletionInterval="100"
                                                                                            FirstRowSelected="true"
                                                                                            MinimumPrefixLength="1"
                                                                                            DelimiterCharacters="1"
                                                                                            ServiceMethod="GetInwcode"
                                                                                            ServicePath="~/InNonPayment.aspx"
                                                                                            Enabled="True"
                                                                                            CompletionListCssClass="ac_results"
                                                                                            CompletionListItemCssClass="listItem"
                                                                                            CompletionListHighlightedItemCssClass="itemHighlighted"
                                                                                            TargetControlID="InwardCode" />
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator68" runat="server" ControlToValidate="InwardCode" Display="None" ErrorMessage="Party --> Inward Agent Code is Required" ValidationGroup="PartyInw"></asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            <div class="form-group row">

                                                                                <div class="col-sm-12">
                                                                                    <asp:TextBox autocomplete="off"  ID="InwardCRUEI" Width="170" Style="text-transform: uppercase" placeholder="Cruei" BackColor="#e8f0fe" ValidationGroup="PartyInw" runat="server" TabIndex="45" type="text"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="InwardCRUEI" Display="None" ErrorMessage="Party --> Inward Agent CRUEI is Required" ValidationGroup="PartyInw"></asp:RequiredFieldValidator>
                                                                                    <br />
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="InwardCRUEI" ID="RegularExpressionValidator59" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="PartyInw"></asp:RegularExpressionValidator>
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <div class="form-group row">

                                                                                <div class="col-sm-12">
                                                                                    <asp:TextBox autocomplete="off"  ID="InwardName" Style="text-transform: uppercase" placeholder="Name" BackColor="#e8f0fe" ValidationGroup="PartyInw" runat="server" TabIndex="46" type="text"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="InwardName" Display="None" ErrorMessage="Party --> Inward Agent Name is Required" ValidationGroup="PartyInw"></asp:RequiredFieldValidator>
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="InwardName" ID="RegularExpressionValidator16" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="PartyInw"></asp:RegularExpressionValidator>
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <div class="form-group row">

                                                                                <div class="col-sm-12">
                                                                                    <asp:TextBox autocomplete="off"  ID="InwardName1" Style="text-transform: uppercase" placeholder="Name1" runat="server" TabIndex="47" ValidationGroup="PartyInw" type="text"></asp:TextBox>
                                                                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator69" runat="server" ControlToValidate="InwardName1" Display="None" ErrorMessage="Party --> Inward Agent Name is Required" ValidationGroup="PartyInw"></asp:RequiredFieldValidator>--%>
                                                                                    <br />
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="InwardName1" ID="RegularExpressionValidator17" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="PartyInw"></asp:RegularExpressionValidator>
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                    </div>

                                                                    <div id="OutParty" visible="false" runat="server" class="row">
                                                                        <div class="col-sm-4">
                                                                            <div class="form-group row">
                                                                                <label for="staticEmail" class="col-sm-8 col-form-label">

                                                                                    <div class="row">
                                                                                        <div class="col-sm-8">
                                                                                            Outward Carrier Agent
                                                                                        </div>
                                                                                        <div class="col-sm-4">

                                                                                            <asp:ImageButton ID="btninnonout" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />

                                                                                            <asp:Button ID="OutwardAdd" runat="server" CssClass="plusbtn" BackColor="Transparent" BorderWidth="0px" ValidationGroup="Partyout" OnClick="OutwardAdd_Click" Text="+" />
                                                                                        </div>
                                                                                    </div>


                                                                                    <cc1:ModalPopupExtender ID="popupinnonout" runat="server" PopupControlID="pnlinnonout" TargetControlID="btninnonout"
                                                                                        OkControlID="btnYesinnonout" CancelControlID="btnNoinnonout" BackgroundCssClass="modalBackground">
                                                                                    </cc1:ModalPopupExtender>

                                                                                    <asp:Panel ID="pnlinnonout" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                        <div class="header">
                                                                                            Outward Carrier Agent
                                                                                        </div>
                                                                                        <div class="body">
                                                                                            <asp:UpdatePanel ID="upinnonoutgrid" runat="server" UpdateMode="Conditional">
                                                                                                <ContentTemplate>
                                                                                                    <asp:TextBox autocomplete="off"  ID="OutwardSearch" OnTextChanged="OutwardSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                    <br />
                                                                                                    <%-- <asp:UpdatePanel ID="UpdatePanelOUTWARDSearch" runat="server"  UpdateMode="Always">

                                                            <ContentTemplate>--%>
                                                                                                    <asp:GridView ID="OutwardGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="OutwardGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" OnRowCommand="OutwardGrid_RowCommand" OnRowDataBound="OutwardGrid_RowDataBound" runat="server" AutoGenerateColumns="false">
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
                                                                                                                    <asp:LinkButton ID="LmkOutward" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LmkOutward_Command">Select </asp:LinkButton>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                        </Columns>
                                                                                                    </asp:GridView>
                                                                                                </ContentTemplate>
                                                                                                <%--<Triggers>
<asp:PostBackTrigger ControlID="OutwardGrid" />
  </Triggers>--%>
                                                                                            </asp:UpdatePanel>
                                                                                        </div>
                                                                                        <div class="footer" align="right">
                                                                                            <asp:Button ID="btnYesinnonout" runat="server" Text="Yes" CssClass="yes" />
                                                                                            <asp:Button ID="btnNoinnonout" runat="server" Text="No" CssClass="no" />
                                                                                        </div>
                                                                                    </asp:Panel>



                                                                                </label>
                                                                                <div class="col-sm-4">
                                                                                    <asp:TextBox autocomplete="off"  runat="server" Style="text-transform: uppercase" placeholder="Code" Width="100" type="text" AutoPostBack="true" ID="OutwardCode" OnTextChanged="OutwardCode_TextChanged" TabIndex="48"></asp:TextBox>
                                                                                           <cc1:AutoCompleteExtender
                                                                                            ID="AutoCompleteExtender5"
                                                                                            runat="server"
                                                                                            CompletionInterval="100"
                                                                                            FirstRowSelected="true"
                                                                                            MinimumPrefixLength="1"
                                                                                            DelimiterCharacters="1"
                                                                                            ServiceMethod="GetOutwardCar"
                                                                                            ServicePath="~/InNonPayment.aspx"
                                                                                            Enabled="True"
                                                                                            CompletionListCssClass="ac_results"
                                                                                            CompletionListItemCssClass="listItem"
                                                                                            CompletionListHighlightedItemCssClass="itemHighlighted"
                                                                                            TargetControlID="OutwardCode" />
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator70" runat="server" ControlToValidate="OutwardCode" Display="None" ErrorMessage="Party --> Outward AgentCode is Required" ValidationGroup="Partyout"></asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            <div class="form-group row">

                                                                                <div class="col-sm-12">
                                                                                    <asp:TextBox autocomplete="off"  ID="OutwardCRUEI" Style="text-transform: uppercase" placeholder="Cruei" Width="170" runat="server" TabIndex="49" type="text"></asp:TextBox>
                                                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="InwardCRUEI" Display="None" ErrorMessage="Party --> Outward Agent CRUEI is Required" ValidationGroup="Partyout"></asp:RequiredFieldValidator>--%>
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <div class="form-group row">

                                                                                <div class="col-sm-12">
                                                                                    <asp:TextBox autocomplete="off"  ID="OutwardName" Style="text-transform: uppercase" placeholder="Name" ValidationGroup="Payout" runat="server" TabIndex="50" type="text"></asp:TextBox>
                                                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="OutwardName" Display="None" ErrorMessage="Party --> Outward Agent Name is Required" ValidationGroup="Partyout"></asp:RequiredFieldValidator>
                                                                                    <br />
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="OutwardName" ID="RegularExpressionValidator14" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Partyout"></asp:RegularExpressionValidator>--%>
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <div class="form-group row">

                                                                                <div class="col-sm-12">
                                                                                    <asp:TextBox autocomplete="off"  ID="OutwardName1" Style="text-transform: uppercase" placeholder="Name1" runat="server" ValidationGroup="Payout" TabIndex="51" type="text"></asp:TextBox>
                                                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator71" runat="server" ControlToValidate="OutwardName1" Display="None" ErrorMessage="Party --> Outward Agent Name is Required" ValidationGroup="Partyout"></asp:RequiredFieldValidator>
                                                                                    <br />
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="OutwardName1" ID="RegularExpressionValidator15" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Partyout"></asp:RegularExpressionValidator>--%>
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

                                                                                            <asp:ImageButton ID="btninnonfreightforwarder" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />

                                                                                            <asp:Button ID="BtnFrieghtAdd" runat="server" CssClass="plusbtn" BackColor="Transparent" BorderWidth="0px" ValidationGroup="Partyfreight" OnClick="BtnFrieghtAdd_Click" Text="+" />

                                                                                        </div>
                                                                                    </div>

                                                                                    <cc1:ModalPopupExtender ID="popupinnonfreight" runat="server" PopupControlID="pnlinnonfreight" TargetControlID="btninnonfreightforwarder"
                                                                                        OkControlID="btnYesinnonfreight" CancelControlID="btnNoinnonfreight" BackgroundCssClass="modalBackground">
                                                                                    </cc1:ModalPopupExtender>

                                                                                    <asp:Panel ID="pnlinnonfreight" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                        <div class="header">
                                                                                            Freight Forwarder
                                                                                        </div>
                                                                                        <div class="body">
                                                                                            <asp:UpdatePanel ID="upinnonFrieghtGrid" runat="server" UpdateMode="Conditional">
                                                                                                <ContentTemplate>
                                                                                                    <asp:TextBox autocomplete="off"  ID="FrieghtSearch" OnTextChanged="FrieghtSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                    <br />

                                                                                                    <%-- <asp:UpdatePanel ID="UpdatePanelFrieghtSearch" runat="server"  UpdateMode="Always">

                                                <ContentTemplate>--%>
                                                                                                    <asp:GridView ID="FrieghtGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="FrieghtGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" OnRowCommand="FrieghtGrid_RowCommand" OnRowDataBound="FrieghtGrid_RowDataBound" AutoGenerateColumns="false">
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
                                                                                                                    <asp:LinkButton ID="LnkFrieght" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkFrieght_Command">Select </asp:LinkButton>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                        </Columns>
                                                                                                    </asp:GridView>
                                                                                                </ContentTemplate>
                                                                                                <%--<Triggers>
<asp:PostBackTrigger ControlID="FrieghtGrid" />
  </Triggers>--%>
                                                                                            </asp:UpdatePanel>
                                                                                        </div>
                                                                                        <div class="footer" align="right">
                                                                                            <asp:Button ID="btnYesinnonfreight" runat="server" Text="Yes" CssClass="yes" />
                                                                                            <asp:Button ID="btnNoinnonfreight" runat="server" Text="No" CssClass="no" />
                                                                                        </div>
                                                                                    </asp:Panel>

                                                                                </label>
                                                                                <div class="col-sm-4">
                                                                                    <asp:TextBox autocomplete="off"  runat="server" Style="text-transform: uppercase" Width="100" placeholder="Code" OnTextChanged="FrieghtCode_TextChanged" AutoPostBack="true" type="text" ID="FrieghtCode" TabIndex="52"></asp:TextBox>
                                                                                          <cc1:AutoCompleteExtender
                                                                                            ID="AutoCompleteExtender6"
                                                                                            runat="server"
                                                                                            CompletionInterval="100"
                                                                                            FirstRowSelected="true"
                                                                                            MinimumPrefixLength="1"
                                                                                            DelimiterCharacters="1"
                                                                                            ServiceMethod="GetFrieght"
                                                                                            ServicePath="~/InNonPayment.aspx"
                                                                                            Enabled="True"
                                                                                            CompletionListCssClass="ac_results"
                                                                                            CompletionListItemCssClass="listItem"
                                                                                            CompletionListHighlightedItemCssClass="itemHighlighted"
                                                                                            TargetControlID="FrieghtCode" />
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator72" runat="server" ControlToValidate="FrieghtCode" Display="None" ErrorMessage="Party --> Freight AgentCode is Required" ValidationGroup="Partyfreight"></asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            <div class="form-group row">

                                                                                <div class="col-sm-12">
                                                                                    <asp:TextBox autocomplete="off"  ID="FrieghtCRUEI" Style="text-transform: uppercase" placeholder="Cruei" Width="170" runat="server" ValidationGroup="Partyfreight" TabIndex="53" type="text"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator75" runat="server" ControlToValidate="FrieghtCRUEI" Display="None" ErrorMessage="Party --> Freight Agent CRUEI is Required" ValidationGroup="Partyfreight"></asp:RequiredFieldValidator>
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="FrieghtCRUEI" ID="RegularExpressionValidator62" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Partyfreight"></asp:RegularExpressionValidator>
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <div class="form-group row">

                                                                                <div class="col-sm-12">
                                                                                    <asp:TextBox autocomplete="off"  ID="FrieghtName" runat="server" placeholder="Name" ValidationGroup="Partyfreight" TabIndex="54" type="text"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator73" runat="server" ControlToValidate="FrieghtName" Display="None" ErrorMessage="Party --> Freight Agent Name is Required" ValidationGroup="Partyfreight"></asp:RequiredFieldValidator>
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="FrieghtName" ID="RegularExpressionValidator60" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Partyfreight"></asp:RegularExpressionValidator>
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <div class="form-group row">

                                                                                <div class="col-sm-12">
                                                                                    <asp:TextBox autocomplete="off"  ID="FrieghtName1" Style="text-transform: uppercase" placeholder="Name1" runat="server" ValidationGroup="Partyfreight" TabIndex="55" type="text"></asp:TextBox>
                                                                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator74" runat="server" ControlToValidate="FrieghtName1" Display="None" ErrorMessage="Party --> Freight Agent Name is Required" ValidationGroup="Partyfreight"></asp:RequiredFieldValidator>
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="FrieghtName1" ID="RegularExpressionValidator61" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Partyfreight"></asp:RegularExpressionValidator>--%>
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                    </div>

                                                                    <div id="ConsigneeParty" visible="false" runat="server" class="row">
                                                                        <div class="col-sm-4">
                                                                            <div class="form-group row">
                                                                                <label for="staticEmail" class="col-sm-8 col-form-label">

                                                                                    <div class="row">
                                                                                        <div class="col-sm-8">
                                                                                            Consignee
                                                                                        </div>
                                                                                        <div class="col-sm-4">

                                                                                            <asp:ImageButton ID="btninnonconsigne" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />

                                                                                            <asp:Button ID="ConsigneeAdd" CssClass="plusbtn" runat="server" BackColor="Transparent" BorderWidth="0px" Style="text-transform: uppercase" ValidationGroup="PartyClaimant" OnClick="ConsigneeAdd_Click" Text="+" />

                                                                                        </div>
                                                                                    </div>


                                                                                    <cc1:ModalPopupExtender ID="popupinnonconsignee" runat="server" PopupControlID="pnlinnonconsignee" TargetControlID="btninnonconsigne"
                                                                                        OkControlID="btnYesinnonconsignee" CancelControlID="btnNoinnonconsignee" BackgroundCssClass="modalBackground">
                                                                                    </cc1:ModalPopupExtender>

                                                                                    <asp:Panel ID="pnlinnonconsignee" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                        <div class="header">
                                                                                            Consignee
                                                                                        </div>
                                                                                        <div class="body">
                                                                                            <asp:UpdatePanel ID="upinnonConsigneeGrid" runat="server" UpdateMode="Conditional">
                                                                                                <ContentTemplate>
                                                                                                    <asp:TextBox autocomplete="off"  ID="ConsigneeSearch" OnTextChanged="ConsigneeSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                    <br />
                                                                                                    <%--  <asp:UpdatePanel ID="UpdatePanelCONSIGNEESearch" runat="server"  UpdateMode="Always">

                                                        <ContentTemplate>--%>
                                                                                                    <asp:GridView ID="ConsigneeGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ConsigneeGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" OnRowCommand="ConsigneeGrid_RowCommand" OnRowDataBound="ConsigneeGrid_RowDataBound" runat="server" AutoGenerateColumns="false">
                                                                                                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                        <Columns>
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
                                                                                                            <asp:TemplateField HeaderText="Sub Code" SortExpression="Id" Visible="false">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:Label ID="ConsigneeSub" runat="server"
                                                                                                                        Text='<%#Eval("ConsigneeSub")%>'>
                                                                                                                    </asp:Label>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                            <asp:TemplateField HeaderText="Sub Division" SortExpression="Id" Visible="false">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:Label ID="ConsigneeSubDivi" runat="server"
                                                                                                                        Text='<%#Eval("ConsigneeSubDivi")%>'>
                                                                                                                    </asp:Label>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                            <asp:TemplateField HeaderText="City" SortExpression="Id" Visible="false">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:Label ID="ConsigneePostal" runat="server"
                                                                                                                        Text='<%#Eval("ConsigneePostal")%>'>
                                                                                                                    </asp:Label>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                            <asp:TemplateField HeaderText="Country" SortExpression="Id">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:Label ID="ConsigneeCountry" runat="server"
                                                                                                                        Text='<%#Eval("ConsigneeCountry")%>'>
                                                                                                                    </asp:Label>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                            <asp:TemplateField>
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:LinkButton ID="LmkConsignee" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LmkConsignee_Command">Select </asp:LinkButton>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                        </Columns>
                                                                                                    </asp:GridView>
                                                                                                </ContentTemplate>
                                                                                                <Triggers>
                                                                                                    <asp:PostBackTrigger ControlID="ImporterGrid" />
                                                                                                </Triggers>


                                                                                            </asp:UpdatePanel>
                                                                                        </div>
                                                                                        <div class="footer" align="right">
                                                                                            <asp:Button ID="btnYesinnonconsignee" runat="server" Text="Yes" CssClass="yes" />
                                                                                            <asp:Button ID="btnNoinnonconsignee" runat="server" Text="No" CssClass="no" />
                                                                                        </div>
                                                                                    </asp:Panel>

                                                                                </label>
                                                                                <div class="col-sm-4">
                                                                                    <asp:TextBox autocomplete="off"  runat="server" Width="100" OnTextChanged="ConsigneeCode_TextChanged" placeholder="Code" AutoPostBack="true" Style="text-transform: uppercase" type="text" ID="ConsigneeCode" TabIndex="56"></asp:TextBox>                                                                                    
                                                                                    <cc1:AutoCompleteExtender
                                                                                            ID="AutoCompleteExtender8"
                                                                                            runat="server"
                                                                                            CompletionInterval="100"
                                                                                            FirstRowSelected="true"
                                                                                            MinimumPrefixLength="1"
                                                                                            DelimiterCharacters="1"
                                                                                            ServiceMethod="GetCosigncode"
                                                                                            ServicePath="~/InNonPayment.aspx"
                                                                                            Enabled="True"
                                                                                            CompletionListCssClass="ac_results"
                                                                                            CompletionListItemCssClass="listItem"
                                                                                            CompletionListHighlightedItemCssClass="itemHighlighted"
                                                                                            TargetControlID="ConsigneeCode" />
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator76" runat="server" ControlToValidate="ConsigneeCode" Display="None" ErrorMessage="Party --> Claimant AgentCode is Required" ValidationGroup="PartyClaimant"></asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            <div class="form-group row">

                                                                                <div class="col-sm-12">
                                                                                    <asp:TextBox autocomplete="off"  ID="ConsigneeCRUEI" Style="text-transform: uppercase" placeholder="Cruei" ValidationGroup="PartyClaimant" Width="170" runat="server" TabIndex="57" type="text"></asp:TextBox>                                                                                    
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeCRUEI" ID="RegularExpressionValidator68" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
                                                                                </div>
                                                                                <br />
                                                                                <br />
                                                                                <div class="col-sm-12">
                                                                                    <asp:TextBox autocomplete="off"  ID="ConsigneeAddress" placeholder="Address" Style="text-transform: uppercase" Width="170" runat="server" TabIndex="60" type="text" ValidationGroup="PartyClaimant"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator80" runat="server" ControlToValidate="ConsigneeAddress" Display="None" ErrorMessage="Party --> Consignee Address is Required" ValidationGroup="PartyClaimant"></asp:RequiredFieldValidator>
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeAddress" ID="RegularExpressionValidator3" ValidationExpression="^[\s\S]{0,160}$" runat="server" ErrorMessage="Maximum 160 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
                                                                                </div>
                                                                                <br />
                                                                                <br />
                                                                                <div class="col-sm-12">
                                                                                    <asp:TextBox autocomplete="off"  ID="ConsigneeSub" Width="170" runat="server" TabIndex="63" placeholder="Sub Code" Style="text-transform: uppercase" type="text" ValidationGroup="PartyClaimant"></asp:TextBox>                                                                                    
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeSub" ID="RegularExpressionValidator7" ValidationExpression="^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
                                                                                </div>
                                                                                <div class="col-sm-12">
                                                                                    <asp:TextBox autocomplete="off"  ID="ConsigneeCountry" Width="170" Style="text-transform: uppercase" placeholder="CountryCode" runat="server" TabIndex="66" type="text"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator85" runat="server" ControlToValidate="ConsigneeCountry" Display="None" ErrorMessage="Party --> Country Code is Required" ValidationGroup="PartyClaimant"></asp:RequiredFieldValidator>
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeCountry" ID="RegularExpressionValidator9" ValidationExpression="^[\s\S]{0,2}$" runat="server" ErrorMessage="Maximum 2 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <div class="form-group row">
                                                                                <div class="col-sm-12">
                                                                                    <asp:TextBox autocomplete="off"  runat="server" ValidationGroup="PartyClaimant" Style="text-transform: uppercase" placeholder="Name" type="text" ID="ConsigneeName" TabIndex="58"></asp:TextBox>                                                                                    
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeName" ID="RegularExpressionValidator10" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
                                                                                </div>
                                                                                <br />
                                                                                <br />
                                                                                <div class="col-sm-12">
                                                                                    <asp:TextBox autocomplete="off"  ID="ConsigneeAddress1" Style="text-transform: uppercase" placeholder="Address1" runat="server" TabIndex="61" type="text" ValidationGroup="PartyClaimant"></asp:TextBox>                                                                                    
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeAddress1" ID="RegularExpressionValidator4" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
                                                                                </div>

                                                                                <br />
                                                                                <br />
                                                                                <div class="col-sm-12">
                                                                                    <asp:TextBox autocomplete="off"  ID="ConsigneeSubDivi" runat="server" TabIndex="64" placeholder="Sub Division" Style="text-transform: uppercase" type="text" ValidationGroup="PartyClaimant"></asp:TextBox>                                                                                    
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeSubDivi" ID="RegularExpressionValidator91" ValidationExpression="^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
                                                                                </div>

                                                                            </div>

                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <div class="form-group row">
                                                                                <div class="col-sm-12">
                                                                                    <asp:TextBox autocomplete="off"  ID="ConsigneeName1" Style="text-transform: uppercase" placeholder="Name1" ValidationGroup="PartyClaimant" runat="server" TabIndex="59" type="text"></asp:TextBox>
                                                                                    <br />                                                                                  
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator78" runat="server" ControlToValidate="ConsigneeName1" Display="None" ErrorMessage="Party --> Claimant Agent Name is Required" ValidationGroup="PartyClaimant"></asp:RequiredFieldValidator>
                                                                                </div>
                                                                                <br />
                                                                                <br />
                                                                                <div class="col-sm-12">
                                                                                    <asp:TextBox autocomplete="off"  ID="ConsigneeCity" Style="text-transform: uppercase" placeholder="City" runat="server" TabIndex="62" type="text" ValidationGroup="PartyClaimant"></asp:TextBox>                                                                                    
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeCity" ID="RegularExpressionValidator5" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
                                                                                </div>
                                                                                <br />
                                                                                <br />
                                                                                <div class="col-sm-12">
                                                                                    <asp:TextBox autocomplete="off"  ID="ConsigneePostal" Style="text-transform: uppercase" placeholder="Postal" runat="server" TabIndex="65" type="text" ValidationGroup="PartyClaimant"></asp:TextBox>                                                                                    
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneePostal" ID="RegularExpressionValidator8" ValidationExpression="^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
                                                                                </div>

                                                                            </div>

                                                                        </div>
                                                                    </div>

                                                                    <div id="ClaimantParty" visible="false" runat="server" class="row">
                                                                        <div class="col-sm-4">
                                                                            <div class="form-group row">
                                                                                <label for="staticEmail" class="col-sm-8 col-form-label">

                                                                                    <div class="row">
                                                                                        <div class="col-sm-8">
                                                                                            Claimant Party
                                                                                        </div>
                                                                                        <div class="col-sm-4">

                                                                                            <asp:ImageButton ID="btninnonclaimant" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />

                                                                                            <asp:Button ID="ClaimantAdd" CssClass="plusbtn" runat="server" BackColor="Transparent" BorderWidth="0px" ValidationGroup="CLAIMANT" OnClick="ClaimantAdd_Click" Text="+" />

                                                                                        </div>
                                                                                    </div>

                                                                                    <cc1:ModalPopupExtender ID="popupinnonclaimant" runat="server" PopupControlID="pnlinnonclaimant" TargetControlID="btninnonclaimant"
                                                                                        OkControlID="btnYesinnonclaimant" CancelControlID="btnNoinnonclaimant" BackgroundCssClass="modalBackground">
                                                                                    </cc1:ModalPopupExtender>

                                                                                    <asp:Panel ID="pnlinnonclaimant" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                        <div class="header">
                                                                                            CLAIMANT PARTY
                                                                                        </div>
                                                                                        <div class="body">
                                                                                            <asp:UpdatePanel ID="upClaimantGrid" runat="server" UpdateMode="Conditional">
                                                                                                <ContentTemplate>
                                                                                                    <asp:TextBox autocomplete="off"  ID="ClaimantSearch" OnTextChanged="ClaimantSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                    <br />

                                                                                                    <%-- <asp:UpdatePanel ID="UpdatePanelClaimanSearch" runat="server"  UpdateMode="Always">

                                                            <ContentTemplate>--%>
                                                                                                    <asp:GridView ID="ClaimantGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ClaimantGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" OnRowCommand="ClaimantGrid_RowCommand" OnRowDataBound="ClaimantGrid_RowDataBound" runat="server" AutoGenerateColumns="false">
                                                                                                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                        <Columns>


                                                                                                            <asp:TemplateField HeaderText="Name" SortExpression="Id">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:Label ID="lblname" runat="server"
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
                                                                                                             <asp:TemplateField HeaderText="Name2" SortExpression="Id">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:Label ID="lblName2" runat="server"
                                                                                                                        Text='<%#Eval("Name2")%>'>
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
                                                                                                            <asp:TemplateField HeaderText="ClaimantName" SortExpression="Id">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:Label ID="lblCName" runat="server"
                                                                                                                        Text='<%#Eval("ClaimantName")%>'>
                                                                                                                    </asp:Label>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                            <asp:TemplateField HeaderText="Claimant ID" SortExpression="Id">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:Label ID="lblCName1" runat="server"
                                                                                                                        Text='<%#Eval("ClaimantName1")%>'>
                                                                                                                    </asp:Label>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                            <asp:TemplateField>
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:LinkButton ID="LmkClaimant" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LmkClaimant_Command">Select </asp:LinkButton>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                        </Columns>
                                                                                                    </asp:GridView>
                                                                                                </ContentTemplate>
                                                                                                <%-- <Triggers>
<asp:PostBackTrigger ControlID="ClaimantGrid" />
  </Triggers>--%>
                                                                                            </asp:UpdatePanel>
                                                                                        </div>
                                                                                        <div class="footer" align="right">
                                                                                            <asp:Button ID="btnYesinnonclaimant" runat="server" Text="Yes" CssClass="yes" />
                                                                                            <asp:Button ID="btnNoinnonclaimant" runat="server" Text="No" CssClass="no" />
                                                                                        </div>
                                                                                    </asp:Panel>

                                                                                </label>
                                                                                <div class="col-sm-4">
                                                                                    <asp:TextBox autocomplete="off"  runat="server" Width="100" OnTextChanged="ClaimantName_TextChanged" placeholder="Code" Style="text-transform: uppercase" AutoPostBack="true" type="text" ID="ClaimantName" TabIndex="66"></asp:TextBox>                                                                                    
                                                                                    <cc1:AutoCompleteExtender
                                                                                            ID="AutoCompleteExtender7"
                                                                                            runat="server"
                                                                                            CompletionInterval="100"
                                                                                            FirstRowSelected="true"
                                                                                            MinimumPrefixLength="1"
                                                                                            DelimiterCharacters="1"
                                                                                            ServiceMethod="GetClaimanity"
                                                                                            ServicePath="~/InNonPayment.aspx"
                                                                                            Enabled="True"
                                                                                            CompletionListCssClass="ac_results"
                                                                                            CompletionListItemCssClass="listItem"
                                                                                            CompletionListHighlightedItemCssClass="itemHighlighted"
                                                                                            TargetControlID="ClaimantName" />
                                                                                    <asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator100" runat="server" ControlToValidate="ClaimantName" Display="None" ErrorMessage="Party --> CLAIMANT PARTY Code" ValidationGroup="CLAIMANT"></asp:RequiredFieldValidator>
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ClaimantName" ID="RegularExpressionValidator63" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="CLAIMANT"></asp:RegularExpressionValidator>
                                                                                    <br />
                                                                                    
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            <div class="form-group row">

                                                                                <div class="col-sm-12">
                                                                                    <asp:TextBox autocomplete="off"  ID="ClaimantCRUEI" ValidationGroup="CLAIMANT" Width="170" placeholder="Cruei" Style="text-transform: uppercase" runat="server" TabIndex="67" type="text"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator101" runat="server" ControlToValidate="ClaimantCRUEI" Display="None" ErrorMessage="Party --> CLAIMANT PARTY CRUEI" ValidationGroup="CLAIMANT"></asp:RequiredFieldValidator>
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ClaimantCRUEI" ID="RegularExpressionValidator65" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="CLAIMANT"></asp:RegularExpressionValidator>
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <div class="form-group row">

                                                                                <div class="col-sm-12">
                                                                                    <asp:TextBox autocomplete="off"  ID="ClaimantName1" ValidationGroup="CLAIMANT" placeholder="Name" Style="text-transform: uppercase" runat="server" TabIndex="71" type="text"></asp:TextBox>
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ClaimantName1" ID="RegularExpressionValidator64" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="CLAIMANT"></asp:RegularExpressionValidator>
                                                                                </div>
                                                                                <br />
                                                                                <br />
                                                                                <div class="col-sm-12">
                                                                                    <asp:TextBox autocomplete="off"  ID="ClaimantNameC" ValidationGroup="CLAIMANT" placeholder="Claimant Name" Style="text-transform: uppercase" runat="server" TabIndex="69" type="text"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator102" runat="server" ControlToValidate="ClaimantNameC" Display="None" ErrorMessage="Party --> CLAIMANT PARTY NAME" ValidationGroup="CLAIMANT"></asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <div class="form-group row">
                                                                                <div class="col-sm-12">
                                                                                    <asp:TextBox autocomplete="off"  ID="ClaimantName2" ValidationGroup="CLAIMANT" placeholder="Name1" Style="text-transform: uppercase" runat="server" TabIndex="70" type="text"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator32" runat="server" ControlToValidate="ClaimantNameC" Display="None" ErrorMessage="Party --> CLAIMANT PARTY NAME" ValidationGroup="CLAIMANT"></asp:RequiredFieldValidator>
                                                                                    <br />
                                                                                    <br />
                                                                                    <asp:TextBox autocomplete="off"  ID="ClaimantName1C" ValidationGroup="CLAIMANT" placeholder="Claimant ID" Width="170" Style="text-transform: uppercase" runat="server" TabIndex="68" type="text"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator103" runat="server" ControlToValidate="ClaimantName1C" Display="None" ErrorMessage="Party --> CLAIMANT PARTY ID" ValidationGroup="CLAIMANT"></asp:RequiredFieldValidator>
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ClaimantName1C" ID="RegularExpressionValidator66" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="CLAIMANT"></asp:RegularExpressionValidator>
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                    </div>

                                                                    <div class="col-sm-12">
                                                                        <div class="row">
                                                                            <div class="col-sm-4">
                                                                                <br />
                                                                                <div id="declcomdiv" runat="server" visible="false" class="row Borderdiv">
                                                                                    DECLARANT COMPANY
                                                                                </div>
                                                                                <br />
                                                                                <!-- DECLARANT COMPANY Search -->
                                                                                <div class="modal fade" id="DECLARANTCOMPANYSearch" role="dialog">
                                                                                    <div class="modal-dialog">

                                                                                        <!-- Modal content-->
                                                                                        <div class="modal-content">
                                                                                            <div class="modal-header">
                                                                                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                                                                <h4 class="modal-title">Declarant Company Search
                                                                                                </h4>
                                                                                            </div>
                                                                                            <div class="modal-body">
                                                                                            </div>
                                                                                            <div class="modal-footer">
                                                                                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                                                            </div>
                                                                                        </div>

                                                                                    </div>
                                                                                </div>

                                                                                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                                                                    ShowSummary="False" ValidationGroup="PartyDec" />

                                                                                <div id="ImportDiv" runat="server" visible="false" class="row Borderdiv">
                                                                                    Importer
                                                                                </div>
                                                                                <br />
                                                                                <!-- Importer Search -->
                                                                                <div class="modal fade" id="ImportSearch" role="dialog">
                                                                                    <div class="modal-dialog">

                                                                                        <!-- Modal content-->
                                                                                        <div class="modal-content">
                                                                                            <div class="modal-header">
                                                                                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                                                                <h4 class="modal-title">Importer Search
                                                                                                </h4>
                                                                                            </div>
                                                                                            <div class="modal-body">

                                                                                                <%-- </ContentTemplate>
                                                           	
                                                                </asp:UpdatePanel>--%>
                                                                                            </div>
                                                                                            <div class="modal-footer">
                                                                                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                                                            </div>
                                                                                        </div>

                                                                                    </div>
                                                                                </div>
                                                                                <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                                                                                    ShowSummary="False" ValidationGroup="PartyImp" />

                                                                                <div>
                                                                                    <div id="exportDiv" runat="server" visible="false" class="row Borderdiv">
                                                                                        EXPORTER
                                                                                    </div>
                                                                                    <br />
                                                                                    <!-- Importer Search -->
                                                                                    <div class="modal fade" id="EXPORTER" runat="server" role="dialog">
                                                                                        <div class="modal-dialog">

                                                                                            <!-- Modal content-->
                                                                                            <div class="modal-content">
                                                                                                <div class="modal-header">
                                                                                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                                                                    <h4 class="modal-title">EXPORTER Search
                                                                                                    </h4>
                                                                                                </div>
                                                                                                <div class="modal-body">

                                                                                                    <%--</ContentTemplate>
                                                           	
                                                                   </asp:UpdatePanel>--%>
                                                                                                </div>
                                                                                                <div class="modal-footer">
                                                                                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                                                                </div>
                                                                                            </div>

                                                                                        </div>
                                                                                    </div>

                                                                                    <asp:ValidationSummary ID="ValidationSummary4" runat="server" ShowMessageBox="True"
                                                                                        ShowSummary="False" ValidationGroup="PartyExp" />
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-sm-4">
                                                                                <br />
                                                                                <div id="inwardagentDiv" runat="server" visible="false" class="row Borderdiv">
                                                                                    INWARD CARRIER AGENT
                                                                                </div>

                                                                                <div class="modal fade" id="InwardAgent" role="dialog">
                                                                                    <div class="modal-dialog">

                                                                                        <!-- INWARD CARRIER AGENT-->
                                                                                        <div class="modal-content">
                                                                                            <div class="modal-header">
                                                                                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                                                                <h4 class="modal-title">Inward Search
                                                                                                </h4>
                                                                                            </div>
                                                                                            <div class="modal-body">

                                                                                                <%-- </ContentTemplate>
                                                           	
                                                                </asp:UpdatePanel>--%>
                                                                                            </div>
                                                                                            <div class="modal-footer">
                                                                                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                                                            </div>
                                                                                        </div>

                                                                                    </div>
                                                                                </div>
                                                                                <br />

                                                                                <asp:ValidationSummary ID="ValidationSummary5" runat="server" ShowMessageBox="True"
                                                                                    ShowSummary="False" ValidationGroup="PartyInw" />

                                                                                <div>
                                                                                    <div id="OutwardahentDiv" runat="server" visible="false" class="row Borderdiv">
                                                                                        OUTWARD CARRIER AGENT
                                                                                    </div>

                                                                                    <div class="modal fade" id="Outward1" runat="server" role="dialog">
                                                                                        <div class="modal-dialog">

                                                                                            <!-- INWARD CARRIER AGENT-->
                                                                                            <div class="modal-content">
                                                                                                <div class="modal-header">
                                                                                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                                                                    <h4 class="modal-title">OUTWARD Search
                                                                                                    </h4>
                                                                                                </div>
                                                                                                <div class="modal-body">

                                                                                                    <%--</ContentTemplate>
                                                           	
                                                                    </asp:UpdatePanel>--%>
                                                                                                </div>
                                                                                                <div class="modal-footer">
                                                                                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                                                                </div>
                                                                                            </div>

                                                                                        </div>
                                                                                    </div>
                                                                                    <br />
                                                                                    <asp:ValidationSummary ID="ValidationSummary6" runat="server" ShowMessageBox="True"
                                                                                        ShowSummary="False" ValidationGroup="Partyout" />
                                                                                </div>

                                                                                <br />

                                                                                <div id="FreightDiv" runat="server" visible="false" class="row Borderdiv">
                                                                                    FREIGHT FORWARDER
                                                                                </div>
                                                                                <br />

                                                                                <div class="modal fade" id="Frieght" role="dialog">
                                                                                    <div class="modal-dialog">

                                                                                        <!-- INWARD CARRIER AGENT-->
                                                                                        <div class="modal-content">
                                                                                            <div class="modal-header">
                                                                                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                                                                <h4 class="modal-title">Frieght Search
                                                                                                </h4>
                                                                                            </div>
                                                                                            <div class="modal-body">

                                                                                                <%-- </ContentTemplate>
                                                           	
                                                         </asp:UpdatePanel>--%>
                                                                                            </div>
                                                                                            <div class="modal-footer">
                                                                                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                                                            </div>
                                                                                        </div>

                                                                                    </div>
                                                                                </div>
                                                                                <asp:ValidationSummary ID="ValidationSummary7" runat="server" ShowMessageBox="True"
                                                                                    ShowSummary="False" ValidationGroup="Partyfreight" />
                                                                            </div>

                                                                            <div class="col-sm-4">
                                                                                <br />
                                                                                <div>
                                                                                    <div id="consigneeDiv" runat="server" visible="false" class="row Borderdiv">
                                                                                        Consignee 
                                                                                    </div>
                                                                                    <br />

                                                                                    <div class="modal fade" id="CONSIGNEE" role="dialog">
                                                                                        <div class="modal-dialog">

                                                                                            <!-- INWARD CARRIER AGENT-->
                                                                                            <div class="modal-content">
                                                                                                <div class="modal-header">
                                                                                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                                                                    <h4 class="modal-title">CONSIGNEE Search
                                                                                                    </h4>
                                                                                                </div>
                                                                                                <div class="modal-body">

                                                                                                    <%-- </ContentTemplate>
                                                           	
                                                            </asp:UpdatePanel>--%>
                                                                                                </div>
                                                                                                <div class="modal-footer">
                                                                                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                                                                </div>
                                                                                            </div>

                                                                                        </div>
                                                                                    </div>
                                                                                    <asp:ValidationSummary ID="ValidationSummary8" runat="server" ShowMessageBox="True"
                                                                                        ShowSummary="False" ValidationGroup="PartyClaimant" />
                                                                                </div>

                                                                                <br />
                                                                                <div>


                                                                                    <div id="claimentDiv" runat="server" visible="false" class="row Borderdiv">
                                                                                        CLAIMANT PARTY
                                                                                    </div>

                                                                                    <div class="modal fade" id="Claimant" role="dialog">
                                                                                        <div class="modal-dialog">

                                                                                            <!-- INWARD CARRIER AGENT-->
                                                                                            <div class="modal-content">
                                                                                                <div class="modal-header">
                                                                                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                                                                    <h4 class="modal-title">Claimant Search
                                                                                                    </h4>
                                                                                                </div>
                                                                                                <div class="modal-body">

                                                                                                    <%--   </ContentTemplate>
                                                           	
                                                                </asp:UpdatePanel>--%>
                                                                                                </div>
                                                                                                <div class="modal-footer">
                                                                                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                                                                </div>
                                                                                            </div>

                                                                                        </div>
                                                                                    </div>

                                                                                    <asp:ValidationSummary ID="ValidationSummary13" runat="server" ShowMessageBox="True"
                                                                                        ShowSummary="False" ValidationGroup="CLAIMANT" />

                                                                                </div>
                                                                            </div>



                                                                        </div>

                                                                        <br />
                                                                        <br />
                                                                    </div>
                                                                    <center>

                                                                    
                                                                                                                                            <div class="row">
    <%-- <div class="col-sm-3">
                        </div>--%>
    <div class="col-sm-12">
        <center>

            <div class="flex justify-between gap-4 md:flex-nowrap flex-wrap mt-6">
                <asp:Button ID="btnpreviousparty" runat="server" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" OnClick="btnpreviousparty_Click" Text="Previous" TabIndex="45" />

                <asp:Button ID="btnreset" runat="server" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" OnClick="btnsaveparty_Click" Text="Reset" TabIndex="47" />
                <asp:Button ID="btnnextparty" runat="server" CssClass="nn  duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" OnClick="btnnextparty_Click" Text="Next" TabIndex="48" />
            </div>
        </center>
    </div>
    <%--  <div class="col-sm-3"></div>--%>
</div>

                                                                         </center>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>


                                                        </ContentTemplate>
                                                    </cc1:TabPanel>

                                                    <%--  </div>--%>
                                                    <%--<div role="tabpanel" class="tab-pane fade" id="Cargo">   --%>
                                                    <cc1:TabPanel ID="tabCargo" runat="server" HeaderText="Cargo">
                                                        <ContentTemplate>
                                                            <asp:UpdatePanel ID="upinnoncargo" UpdateMode="Conditional" runat="server">
                                                                <ContentTemplate>


                                                                    <%--<div class="row">--%>

                                                                    <div class="row" style="margin-top: 100px;">
                                                                        <div class="col-sm-12">
                                                                            <div class="col-sm-6">
                                                                                <div class="row Borderdiv" style="width: 100%">
                                                                                    Outer Pack Details
                                                                                </div>
                                                                                <br />
                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail" class="col-sm-4 col-form-label">
                                                                                        Total Outer Pack
                                                                                    </label>
                                                                                    <div class="col-sm-8">
                                                                                        <asp:TextBox autocomplete="off"  runat="server" type="text" ID="TxttotalOuterPack" BackColor="#e8f0fe" TabIndex="75" Width="200" AutoPostBack="true" Style="text-transform: uppercase" OnTextChanged="TxttotalOuterPack_TextChanged"></asp:TextBox>
                                                                                        <asp:DropDownList CssClass="drop" ID="DrptotalOuterPack" runat="server" TabIndex="76" BackColor="#e8f0fe" Width="80" Height="26" AutoPostBack="true" OnSelectedIndexChanged="DrptotalOuterPack_SelectedIndexChanged"></asp:DropDownList>
                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxttotalOuterPack" ID="RegularExpressionValidator69" ValidationExpression="^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 8 characters allowed." ValidationGroup="outerpack"></asp:RegularExpressionValidator>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail" class="col-sm-4 col-form-label">
                                                                                        Total Gross Weight
                                                                                    </label>
                                                                                    <div class="col-sm-8">
                                                                                        <asp:TextBox autocomplete="off"  runat="server" type="text" BackColor="#e8f0fe" Style="text-transform: uppercase" ID="TxtTotalGrossWeight" OnTextChanged="TxtTotalGrossWeight_TextChanged" TabIndex="77" Width="200"></asp:TextBox>
                                                                                        <asp:DropDownList CssClass="drop" ID="DrpTotalGrossWeight" BackColor="#e8f0fe" runat="server" Width="80" TabIndex="78" Height="26" AutoPostBack="true" OnSelectedIndexChanged="DrpTotalGrossWeight_SelectedIndexChanged">
                                                                                            <asp:ListItem Selected="True" Text="--Select--" Value="--SELECT--"> </asp:ListItem>
                                                                                            <asp:ListItem Text="KGM" Value="KGM"> </asp:ListItem>
                                                                                            <asp:ListItem Text="TNE" Value="TNE"> </asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtTotalGrossWeight" ID="RegularExpressionValidator70" ValidationExpression="^[\s\S]{0,15}$" runat="server" ErrorMessage="Maximum 15 characters allowed." ValidationGroup="outerpack"></asp:RegularExpressionValidator>
                                                                                    </div>
                                                                                </div>
                                                                            </div>


                                                                            <div class="col-sm-6">
                                                                                <div class="row Borderdiv" style="width: 100%">
                                                                                    Location Information
                                                                                </div>
                                                                                <br />
                                                                                <div id="Locationinfo" runat="server">

                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">

                                                                                            <div class="row">
                                                                                                <div class="col-sm-8">
                                                                                                    Release Loc
                                                                                                </div>
                                                                                                <div class="col-sm-4">

                                                                                                    <asp:ImageButton ID="btninnonrelloc1" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />


                                                                                                </div>
                                                                                            </div>


                                                                                        </label>
                                                                                        <cc1:ModalPopupExtender ID="popupinnonreleaseloction" runat="server" PopupControlID="popupinnonreleaseloc" TargetControlID="btninnonrelloc1"
                                                                                            OkControlID="btnYesinnonreleaseloction" CancelControlID="btnNoinnonreleaseloction" BackgroundCssClass="modalBackground">
                                                                                        </cc1:ModalPopupExtender>

                                                                                        <asp:Panel ID="popupinnonreleaseloc" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                            <div class="header">
                                                                                                RELEASE LOCATION
                                                                                            </div>
                                                                                            <div class="body">
                                                                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                                                                    <ContentTemplate>
                                                                                                        <asp:TextBox autocomplete="off"  ID="LocationSearch" OnTextChanged="LocationSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                        <br />
                                                                                                        <%--  <asp:UpdatePanel ID="UpdatePanelReleaseLocation" runat="server"  UpdateMode="Always">

                                                      <ContentTemplate>--%>
                                                                                                        <asp:GridView ID="LocationGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="LocationGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" OnRowCommand="LocationGrid_RowCommand" OnRowDataBound="LocationGrid_RowDataBound" runat="server" AutoGenerateColumns="false">
                                                                                                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                            <Columns>


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
                                                                                                    <Triggers>
                                                                                                        <asp:PostBackTrigger ControlID="LocationGrid" />
                                                                                                    </Triggers>


                                                                                                </asp:UpdatePanel>
                                                                                            </div>
                                                                                            <div class="footer" align="right">
                                                                                                <asp:Button ID="btnYesinnonreleaseloction" runat="server" Text="Yes" CssClass="yes" />
                                                                                                <asp:Button ID="btnNoinnonreleaseloction" runat="server" Text="No" CssClass="no" />
                                                                                            </div>
                                                                                        </asp:Panel>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe" Style="text-transform: uppercase" Width="150" ValidationGroup="Validation" type="text" ID="txtreLoctn" OnTextChanged="txtreLoctn_TextChanged" AutoPostBack="true" TabIndex="79"></asp:TextBox>                                                                                            
                                                                                            <cc1:AutoCompleteExtender ServiceMethod="Getrelloc"
                                                                                            MinimumPrefixLength="1"
                                                                                            CompletionInterval="100" EnableCaching="false" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" CompletionSetCount="10"
                                                                                            TargetControlID="txtreLoctn"
                                                                                            ID="AutoCompleteExtender9" runat="server" FirstRowSelected="true">
                                                                                        </cc1:AutoCompleteExtender>
                                                                                            <%--<cc1:AutoCompleteExtender
                                                                                            ID="AutoCompleteExtender9"
                                                                                            runat="server"
                                                                                            CompletionInterval="100"
                                                                                            FirstRowSelected="true"
                                                                                            MinimumPrefixLength="1"
                                                                                            DelimiterCharacters="1"
                                                                                            ServiceMethod="Getrelloc"
                                                                                            ServicePath="~/InNonPayment.aspx"
                                                                                            Enabled="True"
                                                                                            CompletionListCssClass="ac_results"
                                                                                            CompletionListItemCssClass="listItem"
                                                                                            CompletionListHighlightedItemCssClass="itemHighlighted"
                                                                                            TargetControlID="txtreLoctn" />--%>

                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtreLoctn" Display="None" ErrorMessage="Cargo -->Release Location Code is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtreLoctn" ID="RegularExpressionValidator20" ValidationExpression="^[\s\S]{0,7}$" runat="server" ErrorMessage="Maximum 7 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>

                                                                                            <asp:TextBox autocomplete="off"  runat="server" type="text" TextMode="MultiLine" ValidationGroup="Validation" Style="text-transform: uppercase" ID="txtrelocDeta" Width="200" Height="40" TabIndex="80"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtrelocDeta" ID="RegularExpressionValidator21" ValidationExpression="^[\s\S]{0,250}$" runat="server" ErrorMessage="Maximum 250 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                            <br />
                                                                                            <asp:Label runat="server" ForeColor="Red" BackColor="Yellow" Visible="false" ID="lblrelloc"></asp:Label>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            <div class="row">
                                                                                                <div class="col-sm-8">
                                                                                                    Receipt Loc
                                                                                                </div>
                                                                                                <div class="col-sm-4">

                                                                                                    <asp:ImageButton ID="btnreceiptlocation1" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />


                                                                                                </div>
                                                                                            </div>


                                                                                        </label>
                                                                                        <cc1:ModalPopupExtender ID="popupinnonreceiptlocation" runat="server" PopupControlID="pnlinnonreceiptlocation" TargetControlID="btnreceiptlocation1"
                                                                                            OkControlID="btnYesinnonreceiptlocation" CancelControlID="btnNoinnonreceiptlocation" BackgroundCssClass="modalBackground">
                                                                                        </cc1:ModalPopupExtender>

                                                                                        <asp:Panel ID="pnlinnonreceiptlocation" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                            <div class="header">
                                                                                                REceipt Location
                                                                                            </div>
                                                                                            <div class="body">
                                                                                                <asp:UpdatePanel ID="upinnonReceiptSearch" runat="server" UpdateMode="Conditional">
                                                                                                    <ContentTemplate>
                                                                                                        <asp:TextBox autocomplete="off"  ID="ReceiptSearch" OnTextChanged="ReceiptSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                        <br />
                                                                                                        <%-- <asp:UpdatePanel ID="UpdatePanelReceiptLocation" runat="server"  UpdateMode="Always">

                                                     <ContentTemplate>--%>
                                                                                                        <asp:GridView ID="ReceiptGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ReceiptGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" OnRowCommand="ReceiptGrid_RowCommand" OnRowDataBound="ReceiptGrid_RowDataBound" runat="server" AutoGenerateColumns="false">
                                                                                                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                            <Columns>


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
                                                                                                <asp:Button ID="btnYesinnonreceiptlocation" runat="server" Text="Yes" CssClass="yes" />
                                                                                                <asp:Button ID="btnNoinnonreceiptlocation" runat="server" Text="No" CssClass="no" />
                                                                                            </div>
                                                                                        </asp:Panel>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Width="150" BackColor="#e8f0fe" Style="text-transform: uppercase" type="text" OnTextChanged="txtrecloctn_TextChanged" AutoPostBack="true" ID="txtrecloctn" ValidationGroup="Validation" TabIndex="81"></asp:TextBox>                                                                                            
                                                                                            <cc1:AutoCompleteExtender ServiceMethod="GetRecLoc"
                                                                                            MinimumPrefixLength="1"
                                                                                            CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
                                                                                            TargetControlID="txtrecloctn"
                                                                                            ID="AutoCompleteExtender10" runat="server" FirstRowSelected="true">
                                                                                        </cc1:AutoCompleteExtender>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtrecloctn" Display="None" ErrorMessage="Cargo -->Receipt Location Code is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtrecloctn" ID="RegularExpressionValidator18" ValidationExpression="^[\s\S]{0,7}$" runat="server" ErrorMessage="Maximum 7 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Style="text-transform: uppercase" TextMode="MultiLine" Width="200" Height="40" type="text" ID="txtrecloctndet" TabIndex="82" ValidationGroup="Validation"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtrecloctndet" ID="RegularExpressionValidator19" ValidationExpression="^[\s\S]{0,250}$" runat="server" ErrorMessage="Maximum 250 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                    </div>
                                                                                    <%--<div>--%>
                                                                                    <div id="divstrge" runat="server" visible="false" class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">


                                                                                            <div class="row">
                                                                                                <div class="col-sm-8">
                                                                                                    Storage Loc
                                                                                                </div>
                                                                                                <div class="col-sm-4">

                                                                                                    <asp:ImageButton ID="btninnonstorageloc1" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />


                                                                                                </div>
                                                                                            </div>
                                                                                        </label>
                                                                                        <cc1:ModalPopupExtender ID="popupinnonstorageloc" runat="server" PopupControlID="pnlinnonstorageloc" TargetControlID="btninnonstorageloc1"
                                                                                            OkControlID="btnYesinnonstorageloc" CancelControlID="btnNoinnonstorageloc" BackgroundCssClass="modalBackground">
                                                                                        </cc1:ModalPopupExtender>

                                                                                        <asp:Panel ID="pnlinnonstorageloc" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                            <div class="header">
                                                                                                Storage Location
                                                                                            </div>
                                                                                            <div class="body">
                                                                                                <asp:UpdatePanel ID="upinnonstorage" runat="server" UpdateMode="Conditional">
                                                                                                    <ContentTemplate>

                                                                                                        <asp:GridView ID="GridStorageLoc" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="GridStorageLoc_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" OnRowCommand="GridStorageLoc_RowCommand" OnRowDataBound="GridStorageLoc_RowDataBound" runat="server" AutoGenerateColumns="false">
                                                                                                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                            <Columns>


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
                                                                                                                            Text='<%#Eval("StorageCode")%>'>
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
                                                                                                                        <asp:LinkButton ID="LnkReceipt" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkReceipt_Command1">Select </asp:LinkButton>
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
                                                                                                <asp:Button ID="btnYesinnonstorageloc" runat="server" Text="Yes" CssClass="yes" />
                                                                                                <asp:Button ID="btnNoinnonstorageloc" runat="server" Text="No" CssClass="no" />
                                                                                            </div>
                                                                                        </asp:Panel>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Width="150" type="text" OnTextChanged="txtstrgeloc_TextChanged" AutoPostBack="true" ID="txtstrgeloc" TabIndex="83"></asp:TextBox>                                                                                            
                                                                                            <cc1:AutoCompleteExtender ServiceMethod="GetStrgLoc"
                                                                                            MinimumPrefixLength="1"
                                                                                            CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
                                                                                            TargetControlID="txtstrgeloc"
                                                                                            ID="AutoCompleteExtender18" runat="server" FirstRowSelected="true">
                                                                                        </cc1:AutoCompleteExtender>
                                                                                            <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator97" runat="server" ControlToValidate="txtstrgeloc" Display="None" ErrorMessage="Cargo -->Receipt Location Code is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>--%>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtstrgeloc" ID="RegularExpressionValidator22" ValidationExpression="^[\s\S]{0,7}$" runat="server" ErrorMessage="Maximum 7 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Width="200" type="text" ID="txtstrgelocdet" TabIndex="84"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtstrgelocdet" ID="RegularExpressionValidator23" ValidationExpression="^[\s\S]{0,250}$" runat="server" ErrorMessage="Maximum 250 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                    </div>

                                                                                </div>


                                                                                <%--</div>--%>
                                                                                <div id="EXhDiv" runat="server" visible="false">
                                                                                    <div class="form-group row">
                                                                                        <div class="row Borderdiv" style="width: 100%">
                                                                                    Exhibition / Temp Import
                                                                                </div>      
                                                                                        <br />                                                                                 
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Start Date
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  ID="txtExStartDate" TabIndex="85" OnTextChanged ="txtExStartDate_TextChanged" AutoPostBack ="true" runat="server"></asp:TextBox>
                                                                                            <cc1:CalendarExtender ID="CalendarExtender4" PopupButtonID="imgPopup" runat="server" CssClass="cal_Theme1" TargetControlID="txtExStartDate" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"></cc1:CalendarExtender>
                                                                                        </div>
                                                                                    </div>
                                                                                    </div>
                                                                                 <div id="startdate" runat="server" visible="false">
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            End Date
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  ID="txtExEndDate" Style="text-transform: uppercase" OnTextChanged ="txtExEndDate_TextChanged" AutoPostBack="true" TabIndex="86" runat="server"></asp:TextBox>
                                                                                            <cc1:CalendarExtender ID="CalendarExtender5" PopupButtonID="imgPopup" runat="server" CssClass="cal_Theme1" TargetControlID="txtExEndDate" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"></cc1:CalendarExtender>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <div id="BlankStart" runat="server" visible="false">
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Blanket Start Date
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  ID="BlankDate1" Style="width: 350px;" TabIndex="87" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                                                            <cc1:CalendarExtender ID="CalendarExtender1" CssClass="cal_Theme1" PopupButtonID="imgPopup" runat="server" TargetControlID="BlankDate1" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"></cc1:CalendarExtender>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                    </div>

                                                                    <div class="row">
                                                                        <div id="inwa" runat="server">
                                                                            <div class="col-sm-6">
                                                                                <div class="row Borderdiv" style="width: 100%">
                                                                                    Inward Details
                                                                                </div>
                                                                                <br />
                                                                                <div id="carMode" runat="server" class="form-group row">
                                                                                    <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                        Mode
                                                                                    </label>
                                                                                    <div class="col-sm-9">
                                                                                        <asp:TextBox autocomplete="off" Width="300" Enabled="false" Style="text-transform: uppercase" runat="server" type="text" ID="TextMode" OnTextChanged="TextMode_TextChanged" AutoPostBack="true" TabIndex="88"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div id="load" runat="server">
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Arrival Date
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  Width="300"  ID="TxtArrivalDate1" BackColor="#e8f0fe" Style="text-transform: uppercase" TabIndex="89" runat="server" AutoPostBack="true" OnTextChanged="TxtArrivalDate1_TextChanged" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                                                            <cc1:CalendarExtender CssClass="cal_Theme1" ID="CalendarExtender2" PopupButtonID="imgPopup" runat="server" TargetControlID="TxtArrivalDate1" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"></cc1:CalendarExtender>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="TxtArrivalDate1" Display="None" ErrorMessage="Cargo --> Arrival Date is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div id="lodprtdiv" runat="server" class="form-group row">

                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">


                                                                                            <div class="row">
                                                                                                <div class="col-sm-8">
                                                                                                    Loading Port
                                                                                                </div>
                                                                                                <div class="col-sm-4">

                                                                                                    <asp:ImageButton ID="btninnonloadingport1" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />


                                                                                                </div>
                                                                                            </div>

                                                                                        </label>
                                                                                        <cc1:ModalPopupExtender ID="popupinnonloadingport" runat="server" PopupControlID="pnlinnonloadingport" TargetControlID="btninnonloadingport1"
                                                                                            OkControlID="btnYesinnonloadingport" CancelControlID="btnNoinnonloadingport" BackgroundCssClass="modalBackground">
                                                                                        </cc1:ModalPopupExtender>

                                                                                        <asp:Panel ID="pnlinnonloadingport" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                            <div class="header">
                                                                                                Loading Port 
                                                                                            </div>
                                                                                            <div class="body">
                                                                                                <asp:UpdatePanel ID="upimpgrid" runat="server" UpdateMode="Conditional">
                                                                                                    <ContentTemplate>
                                                                                                        <asp:TextBox autocomplete="off"  ID="CarLoadingSearch" OnTextChanged="CarLoadingSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                        <br />
                                                                                                        <%-- <asp:UpdatePanel ID="UpdatePanelLoadingPort" runat="server"  UpdateMode="Always">

                                                 <ContentTemplate>--%>
                                                                                                        <asp:GridView ID="LoadingGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="LoadingGrid_PageIndexChanging" OnRowCommand="LoadingGrid_RowCommand" OnRowDataBound="LoadingGrid_RowDataBound" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                                                                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                            <Columns>


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
                                                                                                    <%-- <Triggers>
<asp:PostBackTrigger ControlID="LoadingGrid" />
  </Triggers>--%>
                                                                                                </asp:UpdatePanel>
                                                                                            </div>
                                                                                            <div class="footer" align="right">
                                                                                                <asp:Button ID="btnYesinnonloadingport" runat="server" Text="Yes" CssClass="yes" />
                                                                                                <asp:Button ID="btnNoinnonloadingport" runat="server" Text="No" CssClass="no" />
                                                                                            </div>
                                                                                        </asp:Panel>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe" Width="75" type="text" Style="text-transform: uppercase" ID="TxtLoadShort" OnTextChanged="TxtLoadShort_TextChanged" AutoPostBack="true" TabIndex="90"></asp:TextBox>                                                                                            
                                                                                            <cc1:AutoCompleteExtender
                                                                                            ID="AutoCompleteExtender11"
                                                                                            runat="server"
                                                                                            CompletionInterval="100"
                                                                                            FirstRowSelected="true"
                                                                                            MinimumPrefixLength="1"
                                                                                            DelimiterCharacters="1"
                                                                                            ServiceMethod="GetLodcode"
                                                                                            ServicePath="~/InNonPayment.aspx"
                                                                                            Enabled="True"
                                                                                            CompletionListCssClass="ac_results"
                                                                                            CompletionListItemCssClass="listItem"
                                                                                            CompletionListHighlightedItemCssClass="itemHighlighted"
                                                                                            TargetControlID="TxtLoadShort" />
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="TxtLoadShort" Display="None" ErrorMessage="Cargo --> Loading Port is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Width="225" type="text" ID="TxtLoad" TabIndex="91"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="form-group row">
                                                                                    <div id="inhawbl" runat="server">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            <p id="inhab1" runat="server" style="margin-left: -0px;">In HAWB/HBL</p>
                                                                                            <p id="phawb1" runat="server" visible="false" style="margin-left: -0px;">HAWB</p>
                                                                                            <p id="inhbl1" runat="server" visible="false" style="margin-left: -0px;">HBL</p>
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"   Width="300" runat="server" type="text" ID="txthblCargo" TabIndex="92" AutoPostBack="true" Style="text-transform: uppercase" OnTextChanged="txthblCargo_TextChanged"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator105" runat="server" ControlToValidate="txtflight" Display="None" ErrorMessage="Cargo -->Flight Number is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>--%>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>

                                                                                <div id="InwardFlight" runat="server">
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Flight Number
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  Width="300"  runat="server" Style="text-transform: uppercase" BackColor="#e8f0fe" type="text" ID="txtflight" TabIndex="93"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtflight" Display="None" ErrorMessage="Cargo -->Flight Number is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Aircraft Register Number
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  Width="300"  runat="server" Style="text-transform: uppercase" MaxLength="17" type="text" ID="txtaircraft" TabIndex="94"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group row">
                                                                                        <%--Cargo Pack Type--%>
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Master Air Waybill
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  Width="300" runat="server" BackColor="#e8f0fe" Style="text-transform: uppercase" OnTextChanged="txtwaybill_TextChanged" AutoPostBack="true" type="text" ID="txtwaybill" TabIndex="95"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtwaybill" Display="None" ErrorMessage="Cargo -->Master Air Waybill is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                        </div>
                                                                                    </div>



                                                                                </div>
                                                                                <div id="InwardSea" runat="server">
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Voyage Number
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  Width="300" runat="server" BackColor="#e8f0fe" MaxLength="17" Style="text-transform: uppercase" type="text" ID="TxtVoyageno" TabIndex="96"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="TxtVoyageno" Display="None" ErrorMessage="Cargo -->Voyage Number is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Vessel Name
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  Width="300" runat="server" BackColor="#e8f0fe" Style="text-transform: uppercase" type="text" ID="TxtVesselName" TabIndex="97"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="TxtVesselName" Display="None" ErrorMessage="Cargo -->Vessel Name is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            OBL
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  Width="300" runat="server" Style="text-transform: uppercase" OnTextChanged="TxtOceanBill_TextChanged" AutoPostBack="true" BackColor="#e8f0fe" type="text" ID="TxtOceanBill" TabIndex="98"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="TxtOceanBill" Display="None" ErrorMessage="Cargo -->Ocean Bill Of Lading Number is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                        </div>
                                                                                    </div>

                                                                                </div>
                                                                                <div id="InwardOther" runat="server">
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Conveyance Ref.No
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  Width="300" runat="server" Style="text-transform: uppercase" type="text" ID="TxtConRefNo" TabIndex="99"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Transport ID
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  Width="300" runat="server" Style="text-transform: uppercase" type="text" ID="TxtTrnsID" TabIndex="100"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>


                                                                            </div>
                                                                        </div>
                                                                        <div id="OutwardDiv" visible="false" runat="server">
                                                                            <div class="col-sm-6">

                                                                                <div class="row Borderdiv" style="width: 100%">
                                                                                    Outward Details
                                                                                </div>
                                                                                <br />
                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                        Mode
                                                                                    </label>
                                                                                    <div class="col-sm-9">
                                                                                        <asp:TextBox autocomplete="off"  Enabled="false" runat="server" type="text" ID="TxtExpMode" OnTextChanged="TxtExpMode_TextChanged" AutoPostBack="true" TabIndex="100"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                        Departure Date
                                                                                    </label>
                                                                                    <div class="col-sm-9">
                                                                                        <%--  <input type="date" id='TxtExpArrivalDate1' style="width:265px;"  runat="server" tabindex="70"  />
                                                        <span class="input-group-addon" style="display:none;">
                                                            <span class="glyphicon glyphicon-calendar"></span>
                                                        </span>--%>
                                                                                        <asp:TextBox autocomplete="off"  ID="TxtExpArrivalDate1" runat="server" AutoPostBack="true" TabIndex="101" onkeypress="return isNumberKey(event)" OnTextChanged="TxtExpArrivalDate1_TextChanged"></asp:TextBox>
                                                                                        <cc1:CalendarExtender ID="CalendarExtender6" PopupButtonID="imgPopup" runat="server" TargetControlID="TxtExpArrivalDate1" CssClass="cal_Theme1" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"></cc1:CalendarExtender>


                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ControlToValidate="TxtExpArrivalDate1" Display="None" ErrorMessage="Cargo --> Arrival Date is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                    </div>
                                                                                </div>

                                                                                <div id="dischargeport" runat="server">

                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Discharge Port<asp:ImageButton ID="btninnondischargeport1" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />
                                                                                            <%--<i class='fa fa-search' data-toggle="modal" data-target="#ExploadingSearch"></i>--%>
                                                                                        </label>
                                                                                        <cc1:ModalPopupExtender ID="popupinnondichargeport" runat="server" PopupControlID="pnlinnondichargeport" TargetControlID="btninnondischargeport1"
                                                                                            OkControlID="btnYesinnondichargeport" CancelControlID="btninnondischargeport1" BackgroundCssClass="modalBackground">
                                                                                        </cc1:ModalPopupExtender>

                                                                                        <asp:Panel ID="pnlinnondichargeport" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                            <div class="header">
                                                                                                Discharge Port
                                                                                            </div>
                                                                                            <div class="body">
                                                                                                <asp:UpdatePanel ID="upinnondischargeport" runat="server" UpdateMode="Conditional">
                                                                                                    <ContentTemplate>
                                                                                                        <asp:TextBox autocomplete="off"  ID="ExpLoadingSearch" OnTextChanged="ExpLoadingSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                        <br />

                                                                                                        <asp:GridView ID="ExportGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ExportGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" OnRowCommand="ExportGrid_RowCommand" OnRowDataBound="ExportGrid_RowDataBound" runat="server" AutoGenerateColumns="false">
                                                                                                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                            <Columns>


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
                                                                                                    <%-- <Triggers>
<asp:PostBackTrigger ControlID="ExportGrid" />
  </Triggers>--%>
                                                                                                </asp:UpdatePanel>
                                                                                            </div>
                                                                                            <div class="footer" align="right">
                                                                                                <asp:Button ID="btnYesinnondichargeport" runat="server" Text="Yes" CssClass="yes" />
                                                                                                <asp:Button ID="btnNoinnondichargeport" runat="server" Text="No" CssClass="no" />
                                                                                            </div>
                                                                                        </asp:Panel>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Width="75" BackColor="#e8f0fe" Style="text-transform: uppercase" type="text" ID="TxtExpLoadShort" OnTextChanged="TxtExpLoadShort_TextChanged" AutoPostBack="true" TabIndex="102"></asp:TextBox>                                                                                                                                                                                        
                                                                                            <cc1:AutoCompleteExtender
                                                                                            ID="AutoCompleteExtender12"
                                                                                            runat="server"
                                                                                            CompletionInterval="100"
                                                                                            FirstRowSelected="true"
                                                                                            MinimumPrefixLength="1"
                                                                                            DelimiterCharacters="1"
                                                                                            ServiceMethod="DischargePort"
                                                                                            ServicePath="~/InNonPayment.aspx"
                                                                                            Enabled="True"
                                                                                            CompletionListCssClass="ac_results"
                                                                                            CompletionListItemCssClass="listItem"
                                                                                            CompletionListHighlightedItemCssClass="itemHighlighted"
                                                                                            TargetControlID="TxtExpLoadShort" />
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ControlToValidate="TxtExpLoadShort" Display="None" ErrorMessage="Cargo --> Loading Port is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Width="175" Style="text-transform: uppercase" type="text" ID="TxtExpLoad" TabIndex="87"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Final Destination Country
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:DropDownList CssClass="drop" BackColor="#e8f0fe" runat="server" ID="DrpFinalDesCountry" TabIndex="103"></asp:DropDownList>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                        Sea Store
                                                                                    </label>
                                                                                    <div class="col-sm-9">
                                                                                        <asp:CheckBox ID="chkSea" runat="server" OnCheckedChanged="chkSea_CheckedChanged1" AutoPostBack="true" Text="Sea Store" TabIndex="104" />
                                                                                    </div>
                                                                                </div>
                                                                                <div id="OUTWARDFlight" runat="server">
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Flight Number
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" ValidationGroup="Validation" BackColor="#e8f0fe" type="text" Style="text-transform: uppercase" ID="OUTWARDFlightN0" TabIndex="105"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ControlToValidate="OUTWARDFlightN0" Display="None" ErrorMessage="Cargo -->Flight Number is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="OUTWARDFlightN0" ID="RegularExpressionValidator78" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Aircraft Register Number
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" ValidationGroup="Validation" type="text" ID="OUTWARDAirREgno" Style="text-transform: uppercase" TabIndex="106"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="OUTWARDAirREgno" ID="RegularExpressionValidator79" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Master Air Waybill
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" ValidationGroup="Validation" BackColor="#e8f0fe" type="text" Style="text-transform: uppercase" OnTextChanged="OUTWARDAirwaybill_TextChanged" AutoPostBack="true" ID="OUTWARDAirwaybill" TabIndex="107"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator50" runat="server" ControlToValidate="OUTWARDAirwaybill" Display="None" ErrorMessage="Cargo -->Master Air Waybill is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator BackColor="Yellow" ID="RegularExpressionValidator80" runat="server" Display="None" ControlToValidate="OUTWARDAirwaybill" ValidationExpression="^[\s\S]{0,35}$" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Validation" />
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <div id="OUTWARDSea" runat="server">
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Voyage Number
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" ValidationGroup="Validation" BackColor="#e8f0fe" type="text" ID="OUTWARDVoyageNo" Style="text-transform: uppercase" TabIndex="108"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator52" runat="server" ControlToValidate="OUTWARDVoyageNo" Display="None" ErrorMessage="Cargo -->Voyage Number is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="OUTWARDVoyageNo" ID="RegularExpressionValidator81" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Vessel Name
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe" ValidationGroup="Validation" type="text" ID="OUTWARDVessel" Style="text-transform: uppercase" TabIndex="109"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator53" runat="server" ControlToValidate="OUTWARDVessel" Display="None" ErrorMessage="Cargo -->Vessel Name is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="OUTWARDVessel" ID="RegularExpressionValidator82" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            OBL
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" ValidationGroup="Validation" OnTextChanged="OUTWARDOcenbill_TextChanged" AutoPostBack="true" BackColor="#e8f0fe" type="text" ID="OUTWARDOcenbill" Style="text-transform: uppercase" TabIndex="110"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator54" runat="server" ControlToValidate="OUTWARDOcenbill" Display="None" ErrorMessage="Cargo -->Ocean Bill Of Lading Number is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="OUTWARDOcenbill" ID="RegularExpressionValidator83" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="form-group row" id="outhbl" runat="server">
                                                                                    <div>
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Out HAWB/HBL
                                                                       
                                                                                        </label>

                                                                                        <div class="col-sm-9">

                                                                                            <asp:TextBox autocomplete="off"  runat="server" type="text" Style="text-transform: uppercase" ID="txtouthblCargo" TabIndex="111" AutoPostBack="true" OnTextChanged="txtouthblCargo_TextChanged"></asp:TextBox>

                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator106" runat="server" ControlToValidate="txtflight" Display="None" ErrorMessage="Cargo -->Flight Number is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>

                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <div id="OUTWARDOther" runat="server">
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Conveyance Ref.No
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" ValidationGroup="Validation" type="text" ID="OUTWARDConref" Style="text-transform: uppercase" TabIndex="112"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="OUTWARDConref" ID="RegularExpressionValidator84" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Transport ID
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" ValidationGroup="Validation" Style="text-transform: uppercase" type="text" ID="OUTWARDTransId" TabIndex="113"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="OUTWARDTransId" ID="RegularExpressionValidator85" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <div id="OUTWARDVesl" runat="server">
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Vessel Type
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:DropDownList CssClass="drop" ID="ddpVessel" runat="server" TabIndex="114"></asp:DropDownList>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator55" runat="server" ControlToValidate="ddpVessel" Display="None" ErrorMessage="Cargo -->Master Air Waybill is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Vessel Net Register Tonnage
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Style="text-transform: uppercase" type="text" ID="txtvesnet" TabIndex="115"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Vessel Nationality
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:DropDownList CssClass="drop" runat="server" ID="DroVesslNat" TabIndex="116"></asp:DropDownList>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Towing Vessel ID
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Style="text-transform: uppercase" type="text" ID="txtTowVes" TabIndex="117"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Towing Vessel Name
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Style="text-transform: uppercase" type="text" ID="txtTowVesName" TabIndex="118"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Next Port<asp:Button ID="btninnonnxtport" TabIndex="120" runat="server" Text="Search" />
                                                                                            <%--<i class='fa fa-search' data-toggle="modal" data-target="#loadingSearch1"></i>--%>
                                                                                        </label>
                                                                                        <cc1:ModalPopupExtender ID="popupinnonnxtport" runat="server" PopupControlID="pnlinnonnxtport" TargetControlID="btninnonnxtport"
                                                                                            OkControlID="btnYesinnonnxtport" CancelControlID="btnNoinnonnxtport" BackgroundCssClass="modalBackground">
                                                                                        </cc1:ModalPopupExtender>

                                                                                        <asp:Panel ID="pnlinnonnxtport" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                            <div class="header">
                                                                                                NEXT PORT
                                                                                            </div>
                                                                                            <div class="body">
                                                                                                <asp:UpdatePanel ID="upinnonnxtport" runat="server" UpdateMode="Conditional">
                                                                                                    <ContentTemplate>
                                                                                                        <asp:TextBox autocomplete="off"  ID="NextPrtLoading" OnTextChanged="NextPrtLoading_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                        <br />
                                                                                                        <asp:GridView ID="NextPortGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="NextPortGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" OnRowCommand="NextPortGrid_RowCommand" OnRowDataBound="NextPortGrid_RowDataBound" runat="server" AutoGenerateColumns="false">
                                                                                                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                            <Columns>


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
                                                                                                    <Triggers>
                                                                                                        <asp:PostBackTrigger ControlID="NextPortGrid" />
                                                                                                    </Triggers>


                                                                                                </asp:UpdatePanel>
                                                                                            </div>
                                                                                            <div class="footer" align="right">
                                                                                                <asp:Button ID="btnYesinnonnxtport" runat="server" Text="Yes" CssClass="yes" />
                                                                                                <asp:Button ID="btnNoinnonnxtport" runat="server" Text="No" CssClass="no" />
                                                                                            </div>
                                                                                        </asp:Panel>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Width="75" Style="text-transform: uppercase" type="text" ID="txtNextprt" AutoPostBack="true" OnTextChanged="txtNextprt_TextChanged" TabIndex="121"></asp:TextBox>
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Width="175" type="text" ID="txtNetPrtSer" Style="text-transform: uppercase" TabIndex="122"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                            Last Port
                                                                                            <asp:Button ID="btninnonlastport" TabIndex="123" runat="server" Text="Search" /><%-- <i class='fa fa-search' data-toggle="modal" data-target="#loadingSearch2"></i>--%>
                                                                                        </label>
                                                                                        <cc1:ModalPopupExtender ID="popupinnonlastport" runat="server" PopupControlID="pnlinnonlastport" TargetControlID="btninnonlastport"
                                                                                            OkControlID="btnYesinnonlastport" CancelControlID="btnNoinnonlastport" BackgroundCssClass="modalBackground">
                                                                                        </cc1:ModalPopupExtender>

                                                                                        <asp:Panel ID="pnlinnonlastport" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                            <div class="header">
                                                                                                LAST PORT
                                                                                            </div>
                                                                                            <div class="body">
                                                                                                <asp:UpdatePanel ID="upinnonolastport" runat="server" UpdateMode="Conditional">
                                                                                                    <ContentTemplate>
                                                                                                        <asp:TextBox autocomplete="off"  ID="txtlastprt" OnTextChanged="txtlastprt_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                        <br />
                                                                                                        <asp:GridView ID="LastGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="LastGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" OnRowCommand="LastGrid_RowCommand" OnRowDataBound="LastGrid_RowDataBound" runat="server" AutoGenerateColumns="false">
                                                                                                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                            <Columns>


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
                                                                                                    <%-- <Triggers>
<asp:PostBackTrigger ControlID="LastGrid" />
  </Triggers>--%>
                                                                                                </asp:UpdatePanel>
                                                                                            </div>
                                                                                            <div class="footer" align="right">
                                                                                                <asp:Button ID="btnYesinnonlastport" runat="server" Text="Yes" CssClass="yes" />
                                                                                                <asp:Button ID="btnNoinnonlastport" runat="server" Text="No" CssClass="no" />
                                                                                            </div>
                                                                                        </asp:Panel>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Width="75" type="text" ID="txtLasPrt" AutoPostBack="true" Style="text-transform: uppercase" OnTextChanged="txtLasPrt_TextChanged" TabIndex="124"></asp:TextBox>
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Style="text-transform: uppercase" Width="175" type="text" ID="txtLasPrtSer" TabIndex="125"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>

                                                                    </div>




                                                                    <div class="row">
                                                                        <div class="col-sm-12">
                                                                            <div class="row" id="ContainerDetails" visible="false" runat="server">
                                                                                <div class="row Borderdiv" style="width: 95%">
                                                                                    Container Info
                                                                                </div>
                                                                                <br />
                                                                                <div class="col-sm-1">
                                                                                </div>
                                                                                <div class="col-sm-10">


                                                                                    <asp:GridView ID="ContarinerGrid" runat="server" OnRowDeleting="ContarinerGrid_RowDeleting" OnRowDataBound="ContarinerGrid_RowDataBound1" ShowFooter="true" AutoGenerateColumns="false">
                                                                                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                        <Columns>

                                                                                            <asp:BoundField DataField="RowNumber" HeaderText="Row Number" Visible="false" />
                                                                                            <asp:TemplateField HeaderText="S.No">
                                                                                                <ItemTemplate>
                                                                                                    <%#Container.DataItemIndex+1 %>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Container No">
                                                                                                <ItemTemplate>
                                                                                                    <asp:TextBox autocomplete="off"  ID="txt1" BackColor="#e8f0fe" Style="text-transform: uppercase" TabIndex="126" runat="server"></asp:TextBox>
                                                                                                    <asp:RegularExpressionValidator ID="revEmail" ValidationGroup="Validation" ForeColor="Red" Display="Dynamic"
                                                                                                        ValidationExpression="[a-zA-Z]{4}[0-9]{7}" ControlToValidate="txt1"
                                                                                                        runat="server"
                                                                                                        ErrorMessage="The container no. format should be 4 alphabets and followed by 7 digit, for ex.: ABCD1234567"></asp:RegularExpressionValidator>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txt1" Display="None" ErrorMessage="Cargo -->Container No is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Size / Type">
                                                                                                <ItemTemplate>
                                                                                                    <asp:DropDownList ID="DrpType" CssClass="drop" Style="text-transform: uppercase" BackColor="#e8f0fe" TabIndex="127" runat="server"></asp:DropDownList>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator231" InitialValue="0" runat="server" ControlToValidate="DrpType" Display="None" ErrorMessage="Cargo -->Size / Type is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Weight ( TNE )">
                                                                                                <ItemTemplate>
                                                                                                    <asp:TextBox autocomplete="off"  ID="txt2" BackColor="#e8f0fe" Style="text-transform: uppercase" ValidationGroup="Validation1" MaxLength="3" TabIndex="128" runat="server"></asp:TextBox>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2311" runat="server" ControlToValidate="txt2" Display="None" ErrorMessage="Cargo -->Weight ( TNE ) is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                                    <%--  <asp:RegularExpressionValidator ID="ReguclarVald" ValidationGroup="Validation1" ForeColor="Red" Display="Dynamic"
ValidationExpression="^[0-9][3]" ControlToValidate="txt2"
runat="server"
ErrorMessage="The container Weight format should be Numbers "></asp:RegularExpressionValidator>--%>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Seal No">
                                                                                                <ItemTemplate>
                                                                                                    <asp:TextBox autocomplete="off"  ID="txt3" BackColor="#e8f0fe" Width="130" Style="text-transform: uppercase" TabIndex="129" runat="server"></asp:TextBox>
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
                                                                            </div>
                                                                        </div>
                                                                    </div>



                                                                    <%--</div>--%>
                                                                    
                                                                                                                                                                                    <div class="row">

    <div class="col-sm-12">

        <center>

            <div class="flex justify-between gap-4 md:flex-nowrap flex-wrap mt-6">
                <asp:Button ID="btnprevcargo" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" runat="server" OnClick="btnprevcargo_Click" Text="Previous" TabIndex="74" />
                <asp:Button ID="btnsavecargo" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" runat="server" OnClick="btnsavecargo_Click" Text="Save Draft" TabIndex="75" />
                <asp:Button ID="btnresetcargo" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" runat="server" OnClick="btnresetcargo_Click" Text="Reset" />
                <asp:Button ID="btnnextcargo" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" runat="server" OnClick="btnnextcargo_Click" Text="Next" />
            </div>
        </center>
    </div>

</div>


                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>

                                                        </ContentTemplate>
                                                    </cc1:TabPanel>
                                                    <%--</div>  --%>

                                                    <%-- <div role="tabpanel" class="tab-pane fade" id="Invoice">--%>
                                                    <cc1:TabPanel ID="Invoice" runat="server" HeaderText="Invoice">
                                                        <ContentTemplate>

                                                            <asp:UpdatePanel ID="upinnoninvoice" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>



                                                                    <div class="row" style="margin-top: 100px;">
                                                                        <div class="col-sm-4">
                                                                            <div class="form-group row">
                                                                                <label for="staticEmail" class="col-sm-8 col-form-label">


                                                                                    <div class="row">
                                                                                        <div class="col-sm-8">
                                                                                            Supplier / Manufacturer Party
                                                                                        </div>
                                                                                        <div class="col-sm-4">

                                                                                            <asp:ImageButton ID="btnsupplier1" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />

                                                                                            <asp:Button ID="suppyadd" runat="server" ValidationGroup="supply" OnClick="suppyadd_Click1" Text="+" />
                                                                                        </div>
                                                                                    </div>
                                                                                    <cc1:ModalPopupExtender ID="popupinnonsp" runat="server" PopupControlID="pnlinnonsp" TargetControlID="btnsupplier1"
                                                                                        OkControlID="btnYesinnonsp" CancelControlID="btnNoinnonsp" BackgroundCssClass="modalBackground">
                                                                                    </cc1:ModalPopupExtender>

                                                                                    <asp:Panel ID="pnlinnonsp" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                        <div class="header">
                                                                                            Supplier / Manufacturer Party
                                                                                        </div>
                                                                                        <div class="body">
                                                                                            <asp:UpdatePanel ID="upinnonsp" runat="server" UpdateMode="Conditional">
                                                                                                <ContentTemplate>
                                                                                                    <asp:TextBox autocomplete="off"  ID="SUPPLIERSearch" OnTextChanged="SUPPLIERSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                    <br />
                                                                                                    <%-- <asp:UpdatePanel ID="UpdatePanelSUPPLIERMANUFACTURERPARTY" runat="server"  UpdateMode="Always">

                                                        <ContentTemplate>--%>
                                                                                                    <asp:GridView ID="SUPPLIERGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="SUPPLIERGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" OnRowCommand="SUPPLIERGrid_RowCommand" OnRowDataBound="SUPPLIERGrid_RowDataBound" runat="server" AutoGenerateColumns="false">
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
                                                                                            <asp:Button ID="btnYesinnonsp" runat="server" Text="Yes" CssClass="yes" />
                                                                                            <asp:Button ID="btnNoinnonsp" runat="server" Text="No" CssClass="no" />
                                                                                        </div>
                                                                                    </asp:Panel>

                                                                                </label>
                                                                                <div class="col-sm-4">
                                                                                    <asp:TextBox autocomplete="off"  Width="100" runat="server" type="text" ID="txtcodeinvq" placeholder="Code" ValidationGroup="supply" Style="text-transform: uppercase" OnTextChanged="txtcodeinvq_TextChanged" AutoPostBack="true" TabIndex="134"></asp:TextBox>                                                                                    
                                                                                    <cc1:AutoCompleteExtender
                                                                                            ID="AutoCompleteExtender13"
                                                                                            runat="server"
                                                                                            CompletionInterval="100"
                                                                                            FirstRowSelected="true"
                                                                                            MinimumPrefixLength="1"
                                                                                            DelimiterCharacters="1"
                                                                                            ServiceMethod="GetSupcode"
                                                                                            ServicePath="~/InNonPayment.aspx"
                                                                                            Enabled="True"
                                                                                            CompletionListCssClass="ac_results"
                                                                                            CompletionListItemCssClass="listItem"
                                                                                            CompletionListHighlightedItemCssClass="itemHighlighted"
                                                                                            TargetControlID="txtcodeinvq" />
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator89" runat="server" ControlToValidate="txtcodeinvq" Display="None" ErrorMessage="Supplier Code is Required" ValidationGroup="supply"></asp:RequiredFieldValidator>
                                                                                    <br />
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtcodeinvq" ID="RegularExpressionValidator35" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="supply"></asp:RegularExpressionValidator>
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            <div class="form-group row">

                                                                                <div class="col-sm-12">
                                                                                    <asp:TextBox autocomplete="off"  Width="170" runat="server" type="text" ValidationGroup="supply" Style="text-transform: uppercase" ID="txtcruei" placeholder="CRUEI" TabIndex="135"></asp:TextBox>
                                                                                    <br />
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtcruei" ID="RegularExpressionValidator38" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="supply"></asp:RegularExpressionValidator>
                                                                                    <%--<asp:RequiredFieldValidator BackColor="Red"  ID="RequiredFieldValidator92" runat="server" ControlToValidate="txtcruei"  ErrorMessage="Supplier CRUEI is Required" ValidationGroup="Validation2"></asp:RequiredFieldValidator>--%>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator93" runat="server" ControlToValidate="txtcruei" Display="None" ErrorMessage="Supplier CRUEI is Required" ValidationGroup="supply"></asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <div class="form-group row">

                                                                                <div class="col-sm-12">
                                                                                    <asp:TextBox autocomplete="off"  Style="text-transform: uppercase" runat="server" type="text" ValidationGroup="supply" ID="txtName" placeholder="NAME" TabIndex="136"></asp:TextBox>
                                                                                    <br />
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtName" ID="RegularExpressionValidator36" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="supply"></asp:RegularExpressionValidator>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator87" runat="server" ControlToValidate="txtName" Display="None" ErrorMessage="Supplier Name is Required" ValidationGroup="supply"></asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <div class="form-group row">

                                                                                <div class="col-sm-12">
                                                                                    <asp:TextBox autocomplete="off"  Style="text-transform: uppercase" runat="server" type="text" ValidationGroup="supply" ID="txtName1" placeholder="NAME1" TabIndex="137"></asp:TextBox>
                                                                                    <br />
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtName1" ID="RegularExpressionValidator37" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="supply"></asp:RegularExpressionValidator>
                                                                                    <%--<asp:RequiredFieldValidator BackColor="Red"  ID="RequiredFieldValidator90" runat="server" ControlToValidate="txtName1"  ErrorMessage="Supplier Name is Required" ValidationGroup="Validation2"></asp:RequiredFieldValidator>--%>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator91" runat="server" ControlToValidate="txtName1" Display="None" ErrorMessage="Supplier Name is Required" ValidationGroup="supply"></asp:RequiredFieldValidator>
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
                                                                                            Importer Party
                                                                                        </div>
                                                                                        <div class="col-sm-4">

                                                                                            <asp:ImageButton ID="btninnoninvimp1" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />

                                                                                            <asp:Button ID="BtnImpPartyADD" TabIndex="79" runat="server" ValidationGroup="supply1" OnClick="BtnImpPartyADD_Click" Text="+" />
                                                                                        </div>
                                                                                    </div>


                                                                                    <cc1:ModalPopupExtender ID="popupinnoninvimp" runat="server" PopupControlID="pnlinnoninvimp" TargetControlID="btninnoninvimp1"
                                                                                        OkControlID="btnYesinnoninvimp" CancelControlID="btnNovinnoninvimp" BackgroundCssClass="modalBackground">
                                                                                    </cc1:ModalPopupExtender>

                                                                                    <asp:Panel ID="pnlinnoninvimp" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                        <div class="header">
                                                                                            Importer Party
                                                                                        </div>
                                                                                        <div class="body">
                                                                                            <asp:UpdatePanel ID="upinnoninvimp" runat="server" UpdateMode="Conditional">
                                                                                                <ContentTemplate>
                                                                                                    <asp:TextBox autocomplete="off"  ID="ImportPartySearch" OnTextChanged="ImportPartySearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                    <br />
                                                                                                    <%--  <asp:UpdatePanel ID="UpdatePanelImporterParty" runat="server"  UpdateMode="Always">

  <ContentTemplate>--%>
                                                                                                    <asp:GridView ID="ImportPartyGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ImportPartyGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" OnRowCommand="ImportPartyGrid_RowCommand" OnRowDataBound="ImportPartyGrid_RowDataBound" runat="server" AutoGenerateColumns="false">
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
                                                                                                                    <asp:LinkButton ID="LnkImportParty" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkImportParty_Command">Select </asp:LinkButton>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                        </Columns>
                                                                                                    </asp:GridView>
                                                                                                </ContentTemplate>
                                                                                                <%--<Triggers>
<asp:PostBackTrigger ControlID="ImportPartyGrid" />
  </Triggers>--%>
                                                                                            </asp:UpdatePanel>
                                                                                        </div>
                                                                                        <div class="footer" align="right">
                                                                                            <asp:Button ID="btnYesinnoninvimp" runat="server" Text="Yes" CssClass="yes" />
                                                                                            <asp:Button ID="btnNovinnoninvimp" runat="server" Text="No" CssClass="no" />
                                                                                        </div>
                                                                                    </asp:Panel>

                                                                                </label>
                                                                                <div class="col-sm-4">
                                                                                    <asp:TextBox autocomplete="off"  Width="100" Style="text-transform: uppercase" runat="server" type="text" ID="TxtImppartyCode" placeholder="Code" OnTextChanged="TxtImppartyCode_TextChanged" AutoPostBack="true" TabIndex="138"></asp:TextBox>                                                                                                                                                                        
                                                                                    <cc1:AutoCompleteExtender
                                                                                            ID="AutoCompleteExtender14"
                                                                                            runat="server"
                                                                                            CompletionInterval="100"
                                                                                            FirstRowSelected="true"
                                                                                            MinimumPrefixLength="1"
                                                                                            DelimiterCharacters="1"
                                                                                            ServiceMethod="GetImppartycode"
                                                                                            ServicePath="~/InNonPayment.aspx"
                                                                                            Enabled="True"
                                                                                            CompletionListCssClass="ac_results"
                                                                                            CompletionListItemCssClass="listItem"
                                                                                            CompletionListHighlightedItemCssClass="itemHighlighted"
                                                                                            TargetControlID="TxtImppartyCode" />
                                                                                    <br />
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtImppartyCode" ID="RegularExpressionValidator50" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Importer"></asp:RegularExpressionValidator>
                                                                                    <%--<asp:RequiredFieldValidator BackColor="Red"  ID="RequiredFieldValidator95" runat="server" ControlToValidate="TxtImppartyCode" ErrorMessage="Importer Code is Required" ValidationGroup="Validation2"></asp:RequiredFieldValidator>--%>
                                                                                    <asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator96" runat="server" ControlToValidate="TxtImppartyCode" Display="None" ErrorMessage="Importer Code is Required" ValidationGroup="Importer"></asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            <div class="form-group row">

                                                                                <div class="col-sm-12">
                                                                                    <asp:TextBox autocomplete="off"  Width="170" ID="TxtImppartyCRUEI" Style="text-transform: uppercase" placeholder="CRUEI" BackColor="#e8f0fe" runat="server" TabIndex="139" type="text"></asp:TextBox><br />
                                                                                    <asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator26" runat="server" ControlToValidate="TxtImppartyCRUEI" Display="None" ErrorMessage="Importer CRUEI is Required" ValidationGroup="Invoice"></asp:RequiredFieldValidator>
                                                                                    <asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator99" runat="server" ControlToValidate="TxtImppartyCRUEI" Display="None" ErrorMessage="Importer CRUEI is Required" ValidationGroup="Importer"></asp:RequiredFieldValidator>
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtImppartyCRUEI" ID="RegularExpressionValidator51" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Importer"></asp:RegularExpressionValidator>
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <div class="form-group row">

                                                                                <div class="col-sm-12">
                                                                                    <asp:TextBox autocomplete="off"  Style="text-transform: uppercase" ID="TxtImppartyName" placeholder="NAME" BackColor="#e8f0fe" runat="server" TabIndex="140" type="text" ValidationGroup="Importer"></asp:TextBox><br />
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtImppartyName" ID="RegularExpressionValidator12" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Importer"></asp:RegularExpressionValidator>

                                                                                    <%-- <asp:RequiredFieldValidator BackColor="Red"  ID="RequiredFieldValidator27" runat="server" ControlToValidate="TxtImppartyName" Display ="None" ErrorMessage="Importer Name is Required" ValidationGroup="Invoice"></asp:RequiredFieldValidator>--%>
                                                                                    <asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator94" runat="server" ControlToValidate="TxtImppartyName" Display="None" ErrorMessage="Importer Name is Required" ValidationGroup="Importer"></asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            <div class="form-group row">

                                                                                <div class="col-sm-12">
                                                                                    <asp:TextBox autocomplete="off"  Style="text-transform: uppercase" ID="TxtImppartyName1" placeholder="NAME1" runat="server" TabIndex="141" type="text" ValidationGroup="Importer"></asp:TextBox>
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtImppartyName1" ID="RegularExpressionValidator13" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Importer"></asp:RegularExpressionValidator>
                                                                                    <%--<asp:RequiredFieldValidator BackColor="Red"  ID="RequiredFieldValidator97" runat="server" ControlToValidate="TxtImppartyName1" ErrorMessage="Importer Name is Required" ValidationGroup="Validation2"></asp:RequiredFieldValidator>--%>
                                                                                    <asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator98" runat="server" ControlToValidate="TxtImppartyName1" Display="None" ErrorMessage="Importer Name is Required" ValidationGroup="Importer"></asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-sm-12" style="text-align: center;">
                                                                            <asp:Label ID="lblerrorinv" runat="server" Font-Size="Medium" Font-Bold="true" Text="" BackColor="Red" ForeColor="White" Visible="false"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row" id="InvoiceDiv" runat="server">
                                                                        <div class="col-sm-12">
                                                                            <asp:ValidationSummary ID="ValidationSummary18" runat="server" ShowMessageBox="True"
                                                                                ShowSummary="False" ValidationGroup="Invoice" />





                                                                            <div class="row">
                                                                                <div class="col-sm-12">
                                                                                    <div class="row Borderdiv" style="width: 100%; margin-left: 8px;">
                                                                                        INVOICE INFORMATION
                                                                                    </div>
                                                                                    <div class="row">
                                                                                        <div class="col-sm-4">
                                                                                            <p>Serial Number</p>
                                                                                            <asp:TextBox autocomplete="off"  runat="server" type="text" ID="txtserial"></asp:TextBox>

                                                                                            <p>Invoice Number</p>

                                                                                            <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe" ValidationGroup="Invoice" type="text" ID="txtinvNo" TabIndex="142" class="w3-input w3-hover-green"></asp:TextBox>
                                                                                            <br />
                                                                                            <asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtinvNo" Display="None" ErrorMessage="Invoice Number is Required" ValidationGroup="Invoice"></asp:RequiredFieldValidator>
                                                                                            <br />
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtinvNo" ID="RegularExpressionValidator67" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Invoice"></asp:RegularExpressionValidator>

                                                                                        </div>
                                                                                        <div class="col-sm-4">
                                                                                            <p>Invoice Date</p>

                                                                                            <div class='input-group date' id='Div1'>
                                                                                                <asp:TextBox autocomplete="off"  ID="txtinvDate1" BackColor="#e8f0fe" TabIndex="143" runat="server" AutoPostBack="true" onkeypress="return isNumberKey(event)" OnTextChanged="txtinvDate1_TextChanged"></asp:TextBox>

                                                                                                <cc1:CalendarExtender ID="CalendarExtender3" CssClass="cal_Theme1" PopupButtonID="imgPopup" runat="server" TargetControlID="txtinvDate1" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"></cc1:CalendarExtender>
                                                                                            </div>

                                                                                            <asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtinvDate1" Display="None" ErrorMessage="Invoice Date is Required" ValidationGroup="Invoice"></asp:RequiredFieldValidator>
                                                                                            <div>
                                                                                                <p>Term Type</p>
                                                                                                <asp:DropDownList CssClass="drop" ID="DrpTerms" TabIndex="144" Height="28" runat="server" OnSelectedIndexChanged="DrpTerms_SelectedIndexChanged" AutoPostBack="true">
                                                                                                </asp:DropDownList>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="col-sm-4">
                                                                                            <asp:CheckBox runat="server" ID="chkindicator" TabIndex="145" Text="Ad Valorem Indicator" />
                                                                                            <asp:CheckBox runat="server" ID="chkrateind" TabIndex="146" Text="Preferential Duty Rate Indicator" /><br /><br />
                                                                                            <p>Supplier Importer Relationship</p>
                                                                                            <asp:DropDownList CssClass="drop" ID="DrpSupImpRel" Height="28" TabIndex="147" runat="server">
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

                                                                        <div class="row">
                                                                            <div class="col-sm-12">

                                                                                <div class="row" style="background: linear-gradient(-135deg, #c850c0, #4158d0); color: white; width: 98%; height: 20px; margin-left: 9px;">
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
                                                                                        <asp:DropDownList CssClass="drop" ID="Drpcurrency1" OnSelectedIndexChanged="Drpcurrency1_SelectedIndexChanged" BackColor="#e8f0fe" AutoPostBack="true" AppendDataBoundItems="true" TabIndex="148" Width="70" runat="server">
                                                                                        </asp:DropDownList>
                                                                                        <br />
                                                                                        <asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator29" runat="server" InitialValue="0" ControlToValidate="Drpcurrency1" Display="None" ErrorMessage="Required" ValidationGroup="Invoice"></asp:RequiredFieldValidator>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox autocomplete="off"  runat="server" ID="LblTotalInvoice" Text="0.00" Enabled="false" TabIndex="1" Width="100" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                                                        <%--<asp:Label runat="server" Text="0.00" ID="LblTotalInvoice"></asp:Label>--%>
                                                                                        <%--<asp:TextBox autocomplete="off"  runat="server" type="text" ID="txtexrate" TabIndex="1" class="form-control"></asp:TextBox>--%>
                                                                                    </div>
                                                                                    <div class="col-sm-2">
                                                                                        <asp:TextBox autocomplete="off"  runat="server" type="text" onfocus="removeCommas(this)" OnBlur="addCommas(this)" ValidationGroup="Item" ID="TxtTotalInvoice" onkeypress="return isNumberKey(event)" OnTextChanged="TxtTotalInvoice_TextChanged" AutoPostBack="true" TabIndex="149" Width="100"></asp:TextBox>
                                                                                        <br />
                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtTotalInvoice" ID="RegularExpressionValidator86" ValidationExpression="^[0-9\s\.]+$" runat="server" ErrorMessage="Not Accepted Special Charector" ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                    </div>
                                                                                    <div class="col-sm-2">
                                                                                        <asp:Label runat="server" Text="0.00" ID="SumTotalInvoice"></asp:Label>
                                                                                        <%--<asp:TextBox autocomplete="off"  runat="server" type="text" ID="txtamountdol" TabIndex="1" class="form-control"></asp:TextBox>--%>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="row" runat="server" id="OtherTaxableCharge">
                                                                                    <div class="col-sm-4">
                                                                                        <p>Other Taxable Charge</p>
                                                                                    </div>
                                                                                    <div class="col-sm-2">
                                                                                        <asp:TextBox autocomplete="off"  runat="server" Text="0.00" ID="OtherTaxableChargePer" onkeypress="return isNumberKey(event)" OnTextChanged="OtherTaxableChargePer_TextChanged" AutoPostBack="true" TabIndex="150" Width="100"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:DropDownList CssClass="drop" ID="Drpcurrency2" OnSelectedIndexChanged="Drpcurrency2_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true" Width="70" TabIndex="151" runat="server">
                                                                                        </asp:DropDownList>
                                                                                        <br />
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" InitialValue="0" ControlToValidate="Drpcurrency2" Display="None" ErrorMessage="Choose Currency"
                                                                                            ValidationGroup="ItemMasterValidation" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox autocomplete="off"  runat="server" type="text" ID="lblOtherTaxableCharge" Text="0.00" TabIndex="1" Width="100" Enabled="false"></asp:TextBox>
                                                                                        <%--<asp:Label runat="server" Text="0.00" ID="lblOtherTaxableCharge"></asp:Label>--%>
                                                                                    </div>
                                                                                    <div class="col-sm-2">
                                                                                        <asp:TextBox autocomplete="off"  runat="server" type="text" Text="0.00" onfocus="removeCommas(this)" OnBlur="addCommas(this)" onkeypress="return isNumberKey(event)" ID="TxtOtherTaxableCharge" ValidationGroup="Item" OnTextChanged="TxtOtherTaxableCharge_TextChanged" AutoPostBack="true" TabIndex="152" Width="100"></asp:TextBox>
                                                                                        <br />
                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtOtherTaxableCharge" ID="RegularExpressionValidator87" ValidationExpression="^[0-9\s\.]+$" runat="server" ErrorMessage="Not Accepted Special Charector" ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                    </div>
                                                                                    <div class="col-sm-2">
                                                                                        <asp:Label runat="server" Text="0.00" ID="SumOtherTaxableCharge"></asp:Label>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="row" runat="server" id="FrieghtCharges">
                                                                                    <div class="col-sm-4">
                                                                                        <p>Frieght Charges( &nbsp;&nbsp;&nbsp;<asp:CheckBox runat="server" ID="CheckBox1" Text="Inculde Other Taxable Charge" TabIndex="153" />)</p>
                                                                                    </div>
                                                                                    <div class="col-sm-2">
                                                                                        <asp:TextBox autocomplete="off"  runat="server" Text="0.00" ID="FrieghtChargesPer" onkeypress="return isNumberKey(event)" OnTextChanged="FrieghtChargesPer_TextChanged" AutoPostBack="true" TabIndex="154" Width="100"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:DropDownList CssClass="drop" ID="Drpcurrency3" OnSelectedIndexChanged="Drpcurrency3_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true" TabIndex="155" Width="70" runat="server">
                                                                                        </asp:DropDownList>
                                                                                        <br />
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server" InitialValue="0" ControlToValidate="Drpcurrency3" Display="None" ErrorMessage="Choose Currency"
                                                                                            ValidationGroup="ItemMasterValidation" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox autocomplete="off"  runat="server" type="text" ID="LblFrieghtCharges" Text="0.00" TabIndex="1" Width="100" Enabled="false"></asp:TextBox>
                                                                                        <%--<asp:Label runat="server" Text="0.00" ID="LblFrieghtCharges"></asp:Label>--%>
                                                                                    </div>
                                                                                    <div class="col-sm-2">
                                                                                        <asp:TextBox autocomplete="off"  runat="server" type="text" Text="0.00" ID="TxtFrieghtCharges" onfocus="removeCommas(this)" OnBlur="addCommas(this)" ValidationGroup="Item" onkeypress="return isNumberKey(event)" OnTextChanged="TxtFrieghtCharges_TextChanged" AutoPostBack="true" TabIndex="156" Width="100"></asp:TextBox>
                                                                                        <br />
                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtFrieghtCharges" ID="RegularExpressionValidator88" ValidationExpression="^[0-9\s\.]+$" runat="server" ErrorMessage="Not Accepted Special Charector" ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                    </div>
                                                                                    <div class="col-sm-2">
                                                                                        <asp:Label runat="server" Text="0.00" ID="SumFrieghtCharges"></asp:Label>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="row" runat="server" id="InsuranceCharges">
                                                                                    <div class="col-sm-4">
                                                                                        <p>Insurance Charges( &nbsp;&nbsp;&nbsp;<asp:CheckBox runat="server" ID="chkchrge" Text="Inculde Other Taxable Charge" TabIndex="157" />)</p>
                                                                                    </div>
                                                                                    <div class="col-sm-2">
                                                                                        <asp:TextBox autocomplete="off"  runat="server" Text="0.00" ID="InsuranceChargesPer" onkeypress="return isNumberKey(event)" OnTextChanged="InsuranceChargesPer_TextChanged" AutoPostBack="true" TabIndex="158" Width="100"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:DropDownList CssClass="drop" ID="Drpcurrency4" OnSelectedIndexChanged="Drpcurrency4_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true" TabIndex="159" Width="70" runat="server">
                                                                                        </asp:DropDownList>
                                                                                        <br />
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" InitialValue="0" ControlToValidate="Drpcurrency4" Display="None" ErrorMessage="Choose Currency"
                                                                                            ValidationGroup="ItemMasterValidation" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                                    </div>
                                                                                    <div class="col-sm-1">
                                                                                        <asp:TextBox autocomplete="off"  runat="server" type="text" ID="lblInsuranceCharges" Text="0.00" TabIndex="1" Enabled="false" Width="100"></asp:TextBox>
                                                                                        <%--<asp:Label runat="server" Text="0.00" ID="lblInsuranceCharges"></asp:Label>--%>
                                                                                    </div>
                                                                                    <div class="col-sm-2">
                                                                                        <asp:TextBox autocomplete="off"  runat="server" type="text" Text="0.00" ID="TxtInsuranceCharges" onfocus="removeCommas(this)" OnBlur="addCommas(this)" ValidationGroup="Item" onkeypress="return isNumberKey(event)" TabIndex="160" OnTextChanged="TxtInsuranceCharges_TextChanged" AutoPostBack="true" Width="100"></asp:TextBox>
                                                                                        <br />
                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtInsuranceCharges" ID="RegularExpressionValidator89" ValidationExpression="^[0-9\s\.]+$" runat="server" ErrorMessage="Not Accepted Special Charector" ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                    </div>
                                                                                    <div class="col-sm-2">
                                                                                        <asp:Label runat="server" Text="0.00" ID="SumInsuranceCharges"></asp:Label>
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
                                                                                        <asp:Label runat="server" Text="0.00" ID="LblSumOFTotal"></asp:Label>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="row" runat="server" id="GST">
                                                                                    <div class="col-sm-4">
                                                                                        <p>GST</p>
                                                                                    </div>
                                                                                    <div class="col-sm-2">
                                                                                        <asp:TextBox autocomplete="off"  Width="100" runat="server" Enabled="false" Text="7" ID="LblGSTpercentage" TabIndex="161"></asp:TextBox>
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

                                                                                    <asp:ValidationSummary ID="ValidationSummary11" runat="server" ShowMessageBox="True"
                                                                                        ShowSummary="False" ValidationGroup="Invoice" />
                                                                                    <div class="col-sm-4">
                                                                                        <asp:Button ID="BtnAddInvoice" ValidationGroup="Invoice" Visible="false" TabIndex="162" runat="server" CssClass="btn btn-block btn-success" Text="Add Invoice" OnClick="BtnAddInvoice_Click" />

                                                                                    </div>


                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <%--<div class="row">                     
               <div class="col-sm-8">
                   </div>
     <div id="DivBtnInve" runat="server" visible="false"  class="col-sm-4">
          <asp:Button ID="NewInvoice" runat="server" CssClass="btn btn-success btn-block" OnClick="NewInvoice_Click" Text="New Invoice" /> <br />
         </div>

              </div>--%>
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

                                                                    <div id="InvoiceGrid" runat="server"><br />
                                                                        <asp:TextBox autocomplete="off"  ID="AddInvoiceSearch" OnTextChanged="AddInvoiceSearch_TextChanged" style="width:100%" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                        <br />

                                                                        <%-- <asp:UpdatePanel ID="upAddInvoiceGrid" runat="server"  UpdateMode="Always">--%>

                                                                        <%--<ContentTemplate>--%>
                                                                        <asp:GridView ID="AddInvoiceGrid" OnRowDeleting="AddInvoiceGrid_RowDeleting" PageSize="100" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="AddInvoiceGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                            <Columns>
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
                                                                                <asp:TemplateField HeaderText="Suplier Name" SortExpression="Id">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblCRUEI" runat="server"
                                                                                            Text='<%#Eval("SupplierCode")%>'>
                                                                                        </asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Invoice GST Amount" SortExpression="Id">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblCRUEI1" runat="server"
                                                                                            Text='<%#Eval("GSTSUMAmount")%>'>
                                                                                        </asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Invoice Cur" SortExpression="Id">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblCur" runat="server"
                                                                                            Text='<%#Eval("TICurrency")%>'>
                                                                                        </asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Total Invoice Amount" SortExpression="Id">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblTIAmount" runat="server"
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
                                                    <%--</div>--%>

                                                    <%--<div role="tabpanel" class="tab-pane fade" id="Item">--%>
                                                    <cc1:TabPanel ID="Item" runat="server" HeaderText="Item">
                                                        <ContentTemplate>
                                                            <asp:UpdatePanel ID="upinnonitem" UpdateMode="Conditional" runat="server">
                                                                <ContentTemplate>


                                                                    <div id="btnitemDiv" runat="server" visible="false" class="row">
                                                                        <div class="col-sm-8">
                                                                        </div>
                                                                        <div class="col-sm-4">
                                                                            <asp:Button ID="BtnAddNEWItem" runat="server" CssClass="btn btn-success btn-block" OnClick="BtnAddNEWItem_Click" Text="New Item" />
                                                                            <br />
                                                                        </div>
                                                                    </div>


                                                                    <div id="ItemDiv" runat="server" style="margin-top: 100px;">
                                                                        <div class="row">
                                                                            <div class="col-sm-4">
                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                        <p id="inhab" runat="server">In HAWB/HBL</p>
                                                                                        <p id="phawb" runat="server" visible="false">HAWB</p>
                                                                                        <p id="inhbl" runat="server" visible="false">HBL</p>
                                                                                    </label>
                                                                                    <div class="col-sm-9">
                                                                                        <asp:DropDownList ID="TxtHAWB" Height="25" CssClass="drop" runat="server" ValidationGroup="Item" TabIndex="167" AutoPostBack="true" Style="text-transform: uppercase" OnTextChanged="TxtHAWB_TextChanged">
                                                                                        </asp:DropDownList>
                                                                                        <%--<asp:TextBox autocomplete="off"  Width="240" runat="server" BackColor="#e8f0fe" type="text" ID="TxtHAWB"  ValidationGroup="Item" OnTextChanged="TxtHAWB_TextChanged" AutoPostBack="true" TabIndex="133"></asp:TextBox>--%>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator49" runat="server" ControlToValidate="TxtHAWB" ErrorMessage="Please Enter In HAWB/OBL"
                                                                                            Display="Dynamic" ValidationGroup="ItemMasterValidation" ForeColor="Red"></asp:RequiredFieldValidator>

                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtHAWB" ID="RegularExpressionValidator27" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>

                                                                                        <asp:Button ID="btnCopyAll" runat="server" Visible="false" Text="Copy All" />
                                                                                    </div>
                                                                                </div>
                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                        Out HAWB/HBL
                                                                                    </label>
                                                                                    <div class="col-sm-9">
                                                                                        <asp:DropDownList ID="txtOutHAWB1" Height="25" CssClass="drop" runat="server" ValidationGroup="Item" Style="text-transform: uppercase" TabIndex="168"></asp:DropDownList>
                                                                                        <%--<asp:TextBox autocomplete="off"  Width="240" runat="server" BackColor="#e8f0fe" type="text" ValidationGroup="Item" ID="txtOutHAWB" TabIndex="134"></asp:TextBox>--%>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator56" runat="server" ControlToValidate="txtOutHAWB1" ErrorMessage="Please Enter Out HAWB/HBL"
                                                                                            Display="Dynamic" ValidationGroup="ItemMasterValidation" ForeColor="Red"></asp:RequiredFieldValidator>

                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtOutHAWB1" ID="RegularExpressionValidator28" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>

                                                                                        <asp:Button ID="BtnOutCopyAll" Width="50" runat="server" Visible="false" Text="Copy All" />
                                                                                    </div>
                                                                                </div>
                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                        Term Type
                                                                                    </label>
                                                                                    <div class="col-sm-9">
                                                                                        <asp:TextBox autocomplete="off"  ID="txttermtyp" runat="server" TabIndex="170" type="text" Style="text-transform: uppercase"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                        ITEM Code
                                                                                    </label>
                                                                                    <div class="col-sm-9">
                                                                                        <asp:TextBox autocomplete="off"  ID="TxtInHouseItem" Style="text-transform: uppercase" AutoPostBack="true" OnTextChanged="TxtInHouseItem_TextChanged" runat="server" TabIndex="171" type="text"></asp:TextBox><br />                                                                                        
                                                                                        <cc1:AutoCompleteExtender
                                                                                            ID="AutoCompleteExtender15"
                                                                                            runat="server"
                                                                                            CompletionInterval="100"
                                                                                            FirstRowSelected="true"
                                                                                            MinimumPrefixLength="1"
                                                                                            DelimiterCharacters="1"
                                                                                            ServiceMethod="GetInhouse"
                                                                                            ServicePath="~/InNonPayment.aspx"
                                                                                            Enabled="True"
                                                                                            CompletionListCssClass="ac_results"
                                                                                            CompletionListItemCssClass="listItem"
                                                                                            CompletionListHighlightedItemCssClass="itemHighlighted"
                                                                                            TargetControlID="TxtInHouseItem" />
                                                                                        <asp:Label ID="lblhserror" Visible="false" Font-Bold="true" ForeColor="White" BackColor="Brown" runat="server"></asp:Label>
                                                                                        <asp:Label ID="lbldhserror" Visible="false" Font-Bold="true" ForeColor="White" BackColor="Brown" runat="server"></asp:Label>
                                                                                        <br />
                                                                                    </div>
                                                                                </div>
                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                        HS Code
                                                                                    </label>
                                                                                    <div class="col-sm-9">
                                                                                        <asp:TextBox autocomplete="off"  ID="TxtHSCodeItem" BackColor="#e8f0fe" Style="text-transform: uppercase" OnTextChanged="TxtHSCodeItem_TextChanged" AutoPostBack="true" runat="server" TabIndex="172" type="text"></asp:TextBox><br />                                                                                                                                                                                
                                                                                        <cc1:AutoCompleteExtender ServiceMethod="GetHSCodeItem"
                                                                                                MinimumPrefixLength="1"
                                                                                                CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
                                                                                                TargetControlID="TxtHSCodeItem"
                                                                                                ID="AutoCompleteExtender16" runat="server" FirstRowSelected="true">
                                                                                            </cc1:AutoCompleteExtender>
                                                                                        <%--<cc1:AutoCompleteExtender
                                                                                            ID="AutoCompleteExtender16"
                                                                                            runat="server"
                                                                                            CompletionInterval="100"
                                                                                            FirstRowSelected="true"
                                                                                            MinimumPrefixLength="1"
                                                                                            DelimiterCharacters="1"
                                                                                            ServiceMethod="GetHSCodeItem"
                                                                                            ServicePath="~/InNonPayment.aspx"
                                                                                            Enabled="True"
                                                                                            CompletionListCssClass="ac_results"
                                                                                            CompletionListItemCssClass="listItem"
                                                                                            CompletionListHighlightedItemCssClass="itemHighlighted"
                                                                                            TargetControlID="TxtHSCodeItem" />--%>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator44" runat="server" ControlToValidate="TxtHSCodeItem" ErrorMessage="Item--->Please Enter HS Code"
                                                                                            Display="None" ValidationGroup="Item" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                        Description
                                                                                    </label>
                                                                                    <div class="col-sm-9">
                                                                                        <asp:TextBox autocomplete="off"  ID="TxtDescription" ValidationGroup="Item" BackColor="#e8f0fe" Style="text-transform: uppercase" OnTextChanged="TxtDescription_TextChanged" AutoPostBack="true" TextMode="MultiLine" Height="75" Width="250" runat="server" TabIndex="173" type="text"></asp:TextBox>
                                                                                        <br />
                                                                                        <br />

                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" ControlToValidate="TxtDescription" ErrorMessage="Item--->Please Enter Description"
                                                                                            Display="None" ValidationGroup="Item" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtDescription" ID="RegularExpressionValidator24" ValidationExpression="^[\s\S]{0,512}$" runat="server" ErrorMessage="Maximum 512 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>


                                                                                        <asp:Label ID="LblCount" runat="server" TabIndex="5"></asp:Label>

                                                                                    </div>
                                                                                </div>
                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                        <div class="row">
                                                                                            <div class="col-sm-8">
                                                                                                COO
                                                                                            </div>
                                                                                            <div class="col-sm-4">

                                                                                                <asp:ImageButton ID="btnorgincountry1" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />


                                                                                            </div>
                                                                                        </div>
                                                                                    </label>
                                                                                    <cc1:ModalPopupExtender ID="popupinnoncountryorgin" runat="server" PopupControlID="pnlinnoncountryorgin" TargetControlID="btnorgincountry1"
                                                                                        OkControlID="btnYesinnoncountryorgin" CancelControlID="btnNoinnoncountryorgin" BackgroundCssClass="modalBackground">
                                                                                    </cc1:ModalPopupExtender>

                                                                                    <asp:Panel ID="pnlinnoncountryorgin" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                        <div class="header">
                                                                                            COUNTRY OF ORGIN
                                                                                        </div>
                                                                                        <div class="body">
                                                                                            <asp:UpdatePanel ID="upinnoncountryorgin" runat="server" UpdateMode="Conditional">
                                                                                                <ContentTemplate>
                                                                                                    <asp:TextBox autocomplete="off"  ID="CountrySearchItem" OnTextChanged="CountrySearchItem_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                    <br />
                                                                                                    <%--<asp:UpdatePanel ID="UpdatePanelCountry" runat="server"  UpdateMode="Always">

                                                            <ContentTemplate>--%>
                                                                                                    <asp:GridView ID="CountryGridItem" OnPageIndexChanging="CountryGridItem_PageIndexChanging" PageSize="5" AllowPaging="True" DataKeyNames="Id" CssClass="table table-striped table-bordered table-hover" OnRowCommand="CountryGridItem_RowCommand" OnRowDataBound="CountryGridItem_RowDataBound" runat="server" AutoGenerateColumns="false">
                                                                                                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                        <Columns>



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
                                                                                                <%-- <Triggers>
<asp:PostBackTrigger ControlID="CountryGridItem" />
  </Triggers>--%>
                                                                                            </asp:UpdatePanel>
                                                                                        </div>
                                                                                        <div class="footer" align="right">
                                                                                            <asp:Button ID="btnYesinnoncountryorgin" runat="server" Text="Yes" CssClass="yes" />
                                                                                            <asp:Button ID="btnNoinnoncountryorgin" runat="server" Text="No" CssClass="no" />
                                                                                        </div>
                                                                                    </asp:Panel>
                                                                                    <div class="col-sm-9">
                                                                                        <asp:TextBox autocomplete="off"  Width="75" ID="TxtCountryItem" BackColor="#e8f0fe" Style="text-transform: uppercase" OnTextChanged="TxtCountryItem_TextChanged" AutoPostBack="true" runat="server" TabIndex="174" type="text"></asp:TextBox>
                                                                                        <asp:TextBox autocomplete="off"  Width="175" ID="txtcname" Style="text-transform: uppercase" runat="server" Enabled="false"></asp:TextBox>                                                                                                                                                                                
                                                                                        <cc1:AutoCompleteExtender
                                                                                            ID="AutoCompleteExtender17"
                                                                                            runat="server"
                                                                                            CompletionInterval="100"
                                                                                            FirstRowSelected="true"
                                                                                            MinimumPrefixLength="1"
                                                                                            DelimiterCharacters="1"
                                                                                            ServiceMethod="GetCountryItem"
                                                                                            ServicePath="~/InNonPayment.aspx"
                                                                                            Enabled="True"
                                                                                            CompletionListCssClass="ac_results"
                                                                                            CompletionListItemCssClass="listItem"
                                                                                            CompletionListHighlightedItemCssClass="itemHighlighted"
                                                                                            TargetControlID="TxtCountryItem" />
                                                                                        <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator46" runat="server" ControlToValidate="TxtCountryItem" ErrorMessage="Item--->Please Enter Country Of Origin"
                                                                                            Display="None" ValidationGroup="Item" ForeColor="Red"></asp:RequiredFieldValidator>

                                                                                    </div>
                                                                                </div>
                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                    </label>
                                                                                    <div class="col-sm-9">
                                                                                        <asp:CheckBox ID="ChkBGIndicator" runat="server" TabIndex="175" Text="DG Indicator" />
                                                                                        <asp:CheckBox ID="ChkUnbrand" OnCheckedChanged="ChkUnbrand_CheckedChanged" AutoPostBack="true" runat="server" Text="Unbranded" TabIndex="175" />
                                                                                    </div>
                                                                                </div>
                                                                              




                                                                                    <br />
                                                                                        <div class="form-group row">
                                                                                                  <div class="col-sm-12">
                                                                                       <asp:Button ID="btnprev" CssClass="previous btn1 btn-primary" Enabled ="false" width="50px"  runat="server" OnClick="btnprev_Click" Text="<<"  />
                                                                                                      <asp:TextBox runat="server" id="itemno" Font-Bold="true" Width="100px" Enabled="false"></asp:TextBox>
                                                                                                       <asp:Button ID="btnnxt" CssClass="previous btn1 btn-primary" Enabled ="false" width="50px" runat="server"  OnClick="btnnxt_Click" Text=">>"  />
                                                                                                   </div>
                                                                                                    </div>


                                                                            </div>
                                                                            <div class="col-sm-4">
                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                        Brand       


                                                                                    </label>
                                                                                    <div class="col-sm-9">
                                                                                        <asp:TextBox autocomplete="off"  Style="text-transform: uppercase" ID="TxtBrand" runat="server" ValidationGroup="Item" TabIndex="176" type="text"></asp:TextBox>
                                                                                        <br />

                                                                                        <asp:RequiredFieldValidator BackColor="#e8f0fe" ID="RequiredFieldValidator47" runat="server" ControlToValidate="TxtBrand" ErrorMessage="Item--->Please Enter Brand"
                                                                                            Display="None" ValidationGroup="Item" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtBrand" ID="RegularExpressionValidator25" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                        Model    


                                                                                    </label>
                                                                                    <div class="col-sm-9">
                                                                                        <asp:TextBox autocomplete="off"  ID="TxtModel" runat="server" TabIndex="177" ValidationGroup="Item" type="text"></asp:TextBox>

                                                                                        <br />
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator48" runat="server" ControlToValidate="TxtModel" ErrorMessage="Please Enter Model"
                                                                                            Display="Dynamic" ValidationGroup="ItemMasterValidation" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtModel" ID="RegularExpressionValidator26" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>

                                                                                    </div>
                                                                                </div>
                                                                                <div id="Vehicle" visible="false" runat="server">
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">Vehicle Type</label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:DropDownList ID="DrpVehicleType" CssClass="drop" runat="server" Height="25" TabIndex="178"></asp:DropDownList>

                                                                                        </div>
                                                                                    </div>

                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">Engine Capacity</label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Width="100" type="text" Text="" ID="txtengine" onkeypress="return isNumberKey(event)" TabIndex="179"></asp:TextBox>
                                                                                            <asp:DropDownList CssClass="drop" ID="DrpVehicleCapacity" runat="server" Width="150" Height="25" TabIndex="180"></asp:DropDownList>

                                                                                        </div>
                                                                                    </div>

                                                                                    <div id="dd" runat="server" class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">Original Regn Date</label>
                                                                                        <div class="col-sm-9">
                                                                                        <div class='input-group date' id='Div2'>


                                                                                            <asp:TextBox autocomplete="off"  ID="txtorgindate" Style="width: 250px;" TabIndex="181"  runat="server" AutoPostBack="true" onkeypress="return isNumberKey(event)" OnTextChanged="txtorgindate_TextChanged"></asp:TextBox>


                                                                                            <cc1:CalendarExtender ID="CalendarExtender7" CssClass="cal_Theme1" PopupButtonID="imgPopup" runat="server" TargetControlID="txtorgindate" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"></cc1:CalendarExtender>

                                                                                        </div>

                                                                                             </div>

                                                                                    </div>
                                                                                </div>
                                                                                <div id="duti" visible="false" runat="server">
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">Duti Qty</label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" type="text" Text="0.00" Width="175" ValidationGroup="Item" onkeypress="return isNumberKey(event)" OnTextChanged="TxtTotalDutiableQuantity_TextChanged" AutoPostBack="true" ID="TxtTotalDutiableQuantity" TabIndex="182"></asp:TextBox>
                                                                                            <asp:DropDownList CssClass="drop" ID="TDQUOM" runat="server" Width="175" Height="25" TabIndex="183"></asp:DropDownList>
                                                                                            <br />
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtTotalDutiableQuantity" ID="RegularExpressionValidator71" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <div id="totDuticableQtyDiv" visible="true" runat="server">
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">TtL Duti Qty</label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Width="175" type="text" ValidationGroup="Item" Text="0.00" ID="txttotDutiableQty" onkeypress="return isNumberKey(event)" AutoPostBack="true" OnTextChanged="txttotDutiableQty_TextChanged" TabIndex="184"></asp:TextBox>
                                                                                            <asp:DropDownList CssClass="drop" ID="ddptotDutiableQty" runat="server" Width="75" Height="25" TabIndex="185"></asp:DropDownList>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail" class="col-sm-3 col-form-label">Invoice Qty</label>
                                                                                    <div class="col-sm-9">
                                                                                        <asp:TextBox autocomplete="off"  runat="server" type="text" ValidationGroup="Item" Text="0.00" ID="TxtInvQty" onkeypress="return isNumberKey(event)" OnTextChanged="TxtInvQty_TextChanged" AutoPostBack="true" TabIndex="186"></asp:TextBox>
                                                                                        <br />
                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtInvQty" ID="RegularExpressionValidator72" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator51" runat="server" ControlToValidate="TxtHAWB" ErrorMessage="Please Enter In HAWB/OBL"
                                                                                            Display="Dynamic" ValidationGroup="ItemMasterValidation" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                                        <br />
                                                                                        <asp:Label runat="server" ID="lblinvqty" Visible="false" ForeColor="Red" BackColor="Yellow"></asp:Label>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail" class="col-sm-3 col-form-label">Hs Quantity</label>
                                                                                    <div class="col-sm-9">
                                                                                        <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe" ValidationGroup="Item" Width="175" type="text" ID="TxtHSQuantity" onkeypress="return isNumberKey(event)" TabIndex="187"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="TxtHSQuantity" ErrorMessage="Item--->Please Enter HS Quantity"
                                                                                            Display="None" ValidationGroup="Item" ForeColor="Red"></asp:RequiredFieldValidator>

                                                                                        <asp:DropDownList CssClass="drop" ID="HSQTYUOM" runat="server" Width="75" OnSelectedIndexChanged="HSQTYUOM_SelectedIndexChanged" AutoPostBack="true" Height="25" TabIndex="188"></asp:DropDownList>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator43" InitialValue="0" runat="server" ControlToValidate="HSQTYUOM" ErrorMessage="Item--->Please Select HS Quantity"
                                                                                            Display="None" ValidationGroup="Item" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                                        <br />
                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtHSQuantity" ID="RegularExpressionValidator73" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                    </div>
                                                                                </div>
                                                                                <div id="AlcoholDiv" visible="false" runat="server">
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">Alcohol %</label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" ValidationGroup="Item" type="text" Text="0.00" ID="txtAlcoholPer" AutoPostBack="true" onkeypress="return isNumberKey(event)" OnTextChanged="txtAlcoholPer_TextChanged" TabIndex="189"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="form-group row">
                                                                                    <div class="row Borderdiv" style="width: 100%;margin-left: 8px;">
                                                                                        Additional Features
                                                                                    </div>
                                                                                </div>

                                                                                <div class="form-group row">
                                                                                    <div class="col-sm-3">
                                                                                        <asp:CheckBox ID="ChkPackInfo" OnCheckedChanged="ChkPackInfo_CheckedChanged" runat="server" AutoPostBack="true" Text="PACKING INFO" TabIndex="202" Width="150"/>
                                                                                    </div>
                                                                                    <div class="col-sm-3">
                                                                                        <asp:CheckBox ID="Chkitemcasc" runat="server" OnCheckedChanged="Chkitemcasc_CheckedChanged" AutoPostBack="true" Text="ITEM CASC" TabIndex="211" Width="150"/>
                                                                                    </div>
                                                                                    <div class="col-sm-3">
                                                                                        <asp:CheckBox ID="ChkTariff" runat="server" Checked="true" OnCheckedChanged="ChkTariff_CheckedChanged" AutoPostBack="true" Text="TARIFF" TabIndex="242" Width="50"/>
                                                                                    </div>
                                                                                    <div class="col-sm-3">
                                                                                        <asp:CheckBox ID="Chklot" runat="server" OnCheckedChanged="Chklot_CheckedChanged" AutoPostBack="true" Text="LOT ID" TabIndex="257" Width="150"/>
                                                                                    </div>




                                                                                </div>

                                                                               

                                                                            </div>
                                                                            <div class="col-sm-4">
                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail" class="col-sm-5 col-form-label">Invoice</label>
                                                                                    <div class="col-sm-7">
                                                                                        <asp:DropDownList CssClass="drop" runat="server" Width="200" type="text" Height="25" ID="DrpInvoiceNo" OnSelectedIndexChanged="DrpInvoiceNo_SelectedIndexChanged" AutoPostBack="true" TabIndex="190"></asp:DropDownList>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail" class="col-sm-5 col-form-label">
                                                                                        Curr ( Unit Price 
                                                <asp:CheckBox ID="ChkUnitPrice" CausesValidation="true" OnCheckedChanged="ChkUnitPrice_CheckedChanged" AutoPostBack="true" runat="server" TabIndex="168" />Auto )
                                                                                    </label>
                                                                                    <div class="col-sm-7">
                                                                                        <asp:DropDownList CssClass="drop" ID="DRPCurrency" BackColor="#e8f0fe" CausesValidation="true" OnSelectedIndexChanged="DRPCurrency_SelectedIndexChanged" TabIndex="191" AutoPostBack="true" runat="server" Width="100" Height="25"></asp:DropDownList>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator88" InitialValue="0" runat="server" ControlToValidate="DRPCurrency" ErrorMessage="Item--->Please Select Currency"
                                                                                            Display="None" ValidationGroup="Item" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                                        <asp:TextBox autocomplete="off"  ID="TxtExchangeRate" Enabled="false" Text="0.00" runat="server" Width="100" Height="25" TabIndex="192"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator90" InitialValue="0.00" runat="server" ControlToValidate="TxtExchangeRate" ErrorMessage="Item--->Please Enter Exchange Rate"
                                                                                            Display="None" ValidationGroup="Item" ForeColor="Red"></asp:RequiredFieldValidator>

                                                                                    </div>
                                                                                </div>
                                                                                <div id="extrsItemDiv" runat="server" visible="false">
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-5 col-form-label">Unit Price Value</label>
                                                                                        <div class="col-sm-7">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Text="0.00" Width="125" ID="TxtUnitPrice" TabIndex="193" OnTextChanged="TxtUnitPrice_TextChanged" AutoPostBack="true" Visible="false"></asp:TextBox>
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Visible="false" Width="125" type="text" ID="TxtSumExRate" Text="0.00"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <div id="OptionalCharges" visible="false" runat="server">
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-5 col-form-label">
                                                                                            Optional Charges
                                                                                        </label>
                                                                                        <div class="col-sm-7">
                                                                                            <asp:DropDownList CssClass="drop" ID="DrpOptionalUom" BackColor="#e8f0fe" CausesValidation="true" TabIndex="194" AutoPostBack="true" OnSelectedIndexChanged="DrpOptionalUom_SelectedIndexChanged" runat="server" Width="75" Height="25"></asp:DropDownList>
                                                                                            <asp:RequiredFieldValidator BackColor="Red" InitialValue="0" ID="RequiredFieldValidator27" runat="server" ControlToValidate="DRPCurrency" Display="None" ErrorMessage="Item --> Plase Select Currency info" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Text="0.00" ID="TxtOptionalPrice" Width="100" OnTextChanged="TxtOptionalPrice_TextChanged" AutoPostBack="true" TabIndex="195"></asp:TextBox>

                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-5 col-form-label">
                                                                                        </label>
                                                                                        <div class="col-sm-7">
                                                                                            <asp:TextBox autocomplete="off"  ID="TxtOptionalExchageRate" TabIndex="196" Text="0.00" AutoPostBack="true" onkeypress="return isNumberKey(event)" OnTextChanged="TxtOptionalExchageRate_TextChanged" runat="server" Width="85" Height="25"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator BackColor="Red" InitialValue="0.00" ID="RequiredFieldValidator104" runat="server" ControlToValidate="TxtExchangeRate" Display="None" ErrorMessage="Item --> Plase Enter Amount" ValidationGroup="Item"></asp:RequiredFieldValidator>
                                                                                            <asp:TextBox autocomplete="off"  runat="server" type="text" ID="TxtOptionalSumExRate" Width="90" TabIndex="197" Text="0.00" Enabled="false"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail" class="col-sm-5 col-form-label">
                                                                                        Total Line Amount 
                                                                                    </label>
                                                                                    <div class="col-sm-7">
                                                                                        <asp:Label ID="Lbl3" Font-Size="9" Text="Total Line Amount" Visible="false" runat="server" Width="100"></asp:Label>
                                                                                        <asp:TextBox autocomplete="off"  BackColor="#e8f0fe" CausesValidation="true" OnTextChanged="TxtTotalLineAmount_TextChanged" onkeypress="return isNumberKey(event)" Text="0.00" AutoPostBack="true" runat="server" ValidationGroup="Item" Width="200" type="text" ID="TxtTotalLineAmount" TabIndex="198"></asp:TextBox>
                                                                                        <br />
                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtTotalLineAmount" ID="RegularExpressionValidator90" ValidationExpression="^[0-9\s\.]+$" runat="server" ErrorMessage="Not Accepted Special Charector" ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail" class="col-sm-5 col-form-label">
                                                                                        Ttl INV Chrg(SGD) 
                                                                                    </label>
                                                                                    <div class="col-sm-7">
                                                                                        <asp:Label Font-Size="9" Text="Total Line Charges(SGD)" ID="Label3" Visible="false" runat="server" Width="100"></asp:Label>
                                                                                        <asp:TextBox autocomplete="off"  runat="server" Enabled="false" type="text" Width="200" ID="TxtTotalLineCharges" Text="0.00" TabIndex="199"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail" class="col-sm-5 col-form-label">
                                                                                        CIF/FOB (SGD) 
                                                                                    </label>
                                                                                    <div class="col-sm-7">
                                                                                        <asp:Label Font-Size="9" Text="CIF/FOB (SGD)" ID="Label4" Visible="false" runat="server" Width="100"></asp:Label>
                                                                                        <asp:TextBox autocomplete="off"  runat="server" Enabled="false" type="text" Width="200" ID="TxtCIFFOB" Text="0.00" TabIndex="200"></asp:TextBox>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail" class="col-sm-5 col-form-label">
                                                                                        Last Selling Price (SGD)
                                                                                    </label>
                                                                                    <div class="col-sm-7">
                                                                                        <asp:Label Font-Size="9" Text="Last selling Price (SGD)" ID="lblsp" Visible="false" runat="server" Width="100"></asp:Label>
                                                                                        <asp:TextBox autocomplete="off"  runat="server" type="text" Width="200" ID="txtlsp" Text="0.00" onkeypress="return isNumberKey(event)" OnTextChanged="txtlsp_TextChanged" AutoPostBack="true" TabIndex="201"></asp:TextBox>
                                                                                    </div>

                                                                                </div>

                                                                                


                                                                                <div id="PackingInfo" visible="false" runat="server">
                                                                                    <div class="form-group row">
                                                                                        <div class="row Borderdiv" style="width: 90%">
                                                                                            PACKING INFO
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-4 col-form-label">
                                                                                            Outer Pack Qty

 
                                                                                        </label>
                                                                                        <div class="col-sm-8">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Text="0" type="text" Width="120" ID="TxtOPQty" onkeypress="return isNumberKey(event)" OnTextChanged="TxtOPQty_TextChanged" AutoPostBack="true" TabIndex="203"></asp:TextBox>
                                                                                            <asp:DropDownList CssClass="drop" ID="DRPOPQUOM" runat="server" Width="75" Height="25" TabIndex="204"></asp:DropDownList>
                                                                                            <br />
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtOPQty" ID="RegularExpressionValidator74" ValidationExpression="^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 8 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>

                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-4 col-form-label">
                                                                                            In Pack Qty

 
                                                                                        </label>
                                                                                        <div class="col-sm-8">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Text="0" type="text" ID="TxtIPQty" Width="120" onkeypress="return isNumberKey(event)" OnTextChanged="TxtIPQty_TextChanged" AutoPostBack="true" TabIndex="205"></asp:TextBox>
                                                                                            <asp:DropDownList CssClass="drop" ID="DRPIPQUOM" runat="server" Width="75" Height="25" TabIndex="206"></asp:DropDownList>
                                                                                            <br />
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtIPQty" ID="RegularExpressionValidator75" ValidationExpression="^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 8 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>

                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-4 col-form-label">
                                                                                            Inner Pack Qty

 
                                                                                        </label>
                                                                                        <div class="col-sm-8">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Text="0" Width="120" type="text" onkeypress="return isNumberKey(event)" OnTextChanged="TxtINPQty_TextChanged" AutoPostBack="true" ID="TxtINPQty" TabIndex="207"></asp:TextBox>
                                                                                            <asp:DropDownList CssClass="drop" ID="DRPINNPQUOM" runat="server" Width="75" Height="25" TabIndex="208"></asp:DropDownList>
                                                                                            <br />
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtINPQty" ID="RegularExpressionValidator76" ValidationExpression="^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 8 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>

                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-4 col-form-label">
                                                                                            Inmost Pack Qty

 
                                                                                        </label>
                                                                                        <div class="col-sm-8">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Text="0" Width="120" type="text" onkeypress="return isNumberKey(event)" OnTextChanged="TxtIMPQty_TextChanged" AutoPostBack="true" ID="TxtIMPQty" TabIndex="209"></asp:TextBox>
                                                                                            <asp:DropDownList CssClass="drop" ID="DRPIMPQUOM" runat="server" Width="75" Height="25" TabIndex="210"></asp:DropDownList>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator57" runat="server" ControlToValidate="TxtHAWB" ErrorMessage="Please Enter In HAWB/OBL"
                                                                                                Display="Dynamic" ValidationGroup="ItemMasterValidation" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                                            <br />
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtIMPQty" ID="RegularExpressionValidator77" ValidationExpression="^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 8 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>

                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <br />
                                                                                <div class="row">
                                                                                     <center>
                                                                                     <div class="row">
                                                                                          <div class="row Borderdiv" style="width: 90%">
                                                                                        Upload Item Excel Template
                                                                                    </div><br />
                                                                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                                                                            <ContentTemplate>
                                                                                               
                                                                                                <div class="col-sm-4"> <a href="ExcelTemplate/InpaymentItemUpload.xlsx" class="btn1 btn-primary"  download>Download Item Excel Template Here</a>
                                                                                                
                                                                                                    </div>
                                                                                                <div class="col-sm-4">
                                                                                                    
                                                                                                    <asp:FileUpload Height="35" ID="FileUpload4" class="btn" runat="server" AllowMultiple="true" />
                                                                                                    <asp:Label runat="server" ID="Label5" />
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
                                                                        <div class="col-sm-12">
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
                                                                                                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                        <Columns>


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
                                                                                                    <%-- <asp:UpdatePanel ID="UpdatePanelHSCode" runat="server"  UpdateMode="Always">

                                                        <ContentTemplate>--%>
                                                                                                    <asp:GridView ID="HSCodeGridItem" OnPageIndexChanging="HSCodeGridItem_PageIndexChanging" PageSize="5" AllowPaging="True" DataKeyNames="Id" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                                                                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                        <Columns>



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
                                                                                                    <%--   </ContentTemplate>
                                                           	
  </asp:UpdatePanel>--%>
                                                                                                </div>
                                                                                                <div class="modal-footer">
                                                                                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                                                                </div>
                                                                                            </div>

                                                                                        </div>
                                                                                    </div>
                                                                                    <%--<div class="row Borderdiv" style="width:100%">Item Information </div>--%>
                                                                                    <div class="row">
                                                                                        <div id="ItemSerNo" runat="server" visible="false" class="col-sm-6">

                                                                                            <p>Serial Number</p>
                                                                                            <asp:TextBox autocomplete="off"  runat="server" type="text" ID="TxtSerialNo"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server" ControlToValidate="TxtSerialNo" ErrorMessage="Please Enter Serial No"
                                                                                                Display="Dynamic" ValidationGroup="ItemMasterValidation" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                                            <br />
                                                                                        </div>

                                                                                        <div class="col-sm-6">
                                                                                        </div>

                                                                                    </div>

                                                                                </div>
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
                                                                                                    <asp:ValidationSummary ID="ValidationSummary15" runat="server" ShowMessageBox="True"
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
                                                                                                                                <asp:Button ID="Button2" runat="server" Text="Copy Of HS-Quantity" OnClick="Button2_Click" />
                                                                                                                                <br />
                                                                                                                                <p>Product Code &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnpc1" runat="server" Text="Search" /></p>
                                                                                                                                <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="pnlpc1" TargetControlID="btnpc1"
                                                                                                                                    OkControlID="btnpcYes" CancelControlID="btnpcNo" BackgroundCssClass="modalBackground">
                                                                                                                                </cc1:ModalPopupExtender>
                                                                                                                                <asp:Panel ID="pnlpc1" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                                                                    <div class="header">
                                                                                                                                        Product Code 1
                                                                                                                                    </div>
                                                                                                                                    <div class="body">
                                                                                                                                        <asp:UpdatePanel ID="upinnonpc1" runat="server" UpdateMode="Conditional">
                                                                                                                                            <ContentTemplate>
                                                                                                                                                <asp:TextBox autocomplete="off"  ID="ProductCode1Search" OnTextChanged="ProductCode1Search_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                                                                <br />
                                                                                                                                                No of Rows:

    <asp:DropDownList ID="dropdownlist5" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropdownlist5_SelectedIndexChanged">

        <asp:ListItem>10</asp:ListItem>

        <asp:ListItem>20</asp:ListItem>

        <asp:ListItem>30</asp:ListItem>

        <asp:ListItem>All</asp:ListItem>

    </asp:DropDownList>
                                                                                                                                                <asp:Button ID="btntest" runat="server" Text="Change" OnClick="btntest_Click" />
                                                                                                                                                <%--<asp:UpdatePanel ID="UpdatePanelProductCode1" runat="server"  UpdateMode="Always">

                                                        <ContentTemplate>--%>
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
                                                                                                                                <asp:TextBox autocomplete="off"  runat="server" type="text" ValidationGroup="Productcode" ID="TxtProductCode1" OnTextChanged="TxtProductCode1_TextChanged" AutoPostBack="true" TabIndex="212"></asp:TextBox>
                                                                                                                                <br />
                                                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProductCode1" ID="RegularExpressionValidator39" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>
                                                                                                                                <br />
                                                                                                                                <p>Quantity</p>
                                                                                                                                <asp:TextBox autocomplete="off"  Width="100" runat="server" type="text" ValidationGroup="Productcode" ID="TxtProQty1" Text="0.00" TabIndex="213"></asp:TextBox>

                                                                                                                                <asp:DropDownList CssClass="drop" ID="DrpP1" runat="server" Width="70" Height="25" TabIndex="214"></asp:DropDownList>
                                                                                                                                <br />
                                                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProQty1" ID="RegularExpressionValidator44" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>
                                                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator58" runat="server" ControlToValidate="TxtHAWB" ErrorMessage="Please Enter In HAWB/OBL"
                                                                                                                                    Display="Dynamic" ValidationGroup="ItemMasterValidation" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                                                                            </div>
                                                                                                                            <div class="col-sm-9">

                                                                                                                                <asp:GridView CssClass="table table-striped table-bordered table-hover" ID="ProductCode1Grid1" runat="server" ShowFooter="true" AutoGenerateColumns="false">
                                                                                                                                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                                                    <Columns>

                                                                                                                                        <asp:BoundField DataField="RowNumber" HeaderText="Row Number" Visible="false" />

                                                                                                                                        <asp:TemplateField HeaderText="CASC CODE 1">

                                                                                                                                            <ItemTemplate>

                                                                                                                                                <asp:TextBox autocomplete="off"  ID="TextBox1" TabIndex="215" runat="server"></asp:TextBox>

                                                                                                                                            </ItemTemplate>

                                                                                                                                        </asp:TemplateField>

                                                                                                                                        <asp:TemplateField HeaderText="CASC CODE 2">

                                                                                                                                            <ItemTemplate>

                                                                                                                                                <asp:TextBox autocomplete="off"  ID="TextBox2" TabIndex="216" runat="server"></asp:TextBox>

                                                                                                                                            </ItemTemplate>

                                                                                                                                        </asp:TemplateField>

                                                                                                                                        <asp:TemplateField HeaderText="CASC CODE 3">

                                                                                                                                            <ItemTemplate>

                                                                                                                                                <asp:TextBox autocomplete="off"  ID="TextBox3" TabIndex="217" runat="server"></asp:TextBox>

                                                                                                                                            </ItemTemplate>

                                                                                                                                            <FooterStyle HorizontalAlign="Right" />

                                                                                                                                            <FooterTemplate>

                                                                                                                                                <asp:Button ID="ProductCode1Add" OnClick="ProductCode1Add_Click" runat="server" Text="Add New Row" />

                                                                                                                                            </FooterTemplate>

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
                                                                                                                                    </div>
                                                                                                                                    <div class="modal-footer">
                                                                                                                                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                                                                                                    </div>
                                                                                                                                </div>

                                                                                                                            </div>
                                                                                                                        </div>

                                                                                                                        <asp:UpdatePanel ID="uppc22" runat="server" UpdateMode="Conditional">
                                                                                                                            <ContentTemplate>

                                                                                                                                <div class="row">

                                                                                                                                    <div class="col-sm-3">
                                                                                                                                        <asp:Button ID="BtnHSQty2" runat="server" Text="Copy Of HS-Qunatity" OnClick="BtnHSQty2_Click" />
                                                                                                                                        <br />
                                                                                                                                        <p>Product Code &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnproductcode" TabIndex="22" runat="server" Text="Search" /></p>
                                                                                                                                        <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" PopupControlID="pnlpc2" TargetControlID="btnproductcode"
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
                                                                                                                                        <asp:TextBox autocomplete="off"  runat="server" type="text" ValidationGroup="Productcode" ID="TxtProductCode2" OnTextChanged="TxtProductCode2_TextChanged" AutoPostBack="true" TabIndex="218"></asp:TextBox>
                                                                                                                                        <br />
                                                                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProductCode2" ID="RegularExpressionValidator40" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>
                                                                                                                                        <br />
                                                                                                                                        <br />
                                                                                                                                        <p>Quantity</p>
                                                                                                                                        <asp:TextBox autocomplete="off"  Width="70" runat="server" type="text" ID="TxtProQty2" ValidationGroup="Productcode" TabIndex="219"></asp:TextBox>

                                                                                                                                        <asp:DropDownList CssClass="drop" ID="DrpP2" runat="server" Width="70" Height="25" TabIndex="220"></asp:DropDownList>

                                                                                                                                        <br />
                                                                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProQty2" ID="RegularExpressionValidator45" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>
                                                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator59" runat="server" ControlToValidate="TxtHAWB" ErrorMessage="Please Enter In HAWB/OBL"
                                                                                                                                            Display="Dynamic" ValidationGroup="ItemMasterValidation" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                                                                                    </div>
                                                                                                                                    <div class="col-sm-9">

                                                                                                                                        <asp:GridView CssClass="table table-striped table-bordered table-hover" ID="ProductCode2Grid1" runat="server" ShowFooter="true" AutoGenerateColumns="false">
                                                                                                                                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                                                            <Columns>

                                                                                                                                                <asp:BoundField DataField="RowNumber" HeaderText="Row Number" Visible="false" />

                                                                                                                                                <asp:TemplateField HeaderText="CASC CODE 1">

                                                                                                                                                    <ItemTemplate>

                                                                                                                                                        <asp:TextBox autocomplete="off"  ID="TextBox1" runat="server" TabIndex="221"></asp:TextBox>

                                                                                                                                                    </ItemTemplate>

                                                                                                                                                </asp:TemplateField>

                                                                                                                                                <asp:TemplateField HeaderText="CASC CODE 2">

                                                                                                                                                    <ItemTemplate>

                                                                                                                                                        <asp:TextBox autocomplete="off"  ID="TextBox2" runat="server" TabIndex="222"></asp:TextBox>

                                                                                                                                                    </ItemTemplate>

                                                                                                                                                </asp:TemplateField>

                                                                                                                                                <asp:TemplateField HeaderText="CASC CODE 3">

                                                                                                                                                    <ItemTemplate>

                                                                                                                                                        <asp:TextBox autocomplete="off"  ID="TextBox3" runat="server" TabIndex="223"></asp:TextBox>

                                                                                                                                                    </ItemTemplate>

                                                                                                                                                    <FooterStyle HorizontalAlign="Right" />

                                                                                                                                                    <FooterTemplate>

                                                                                                                                                        <asp:Button ID="ProductCode2Add" OnClick="ProductCode2Add_Click" runat="server" Text="Add New Row" />

                                                                                                                                                    </FooterTemplate>

                                                                                                                                                </asp:TemplateField>

                                                                                                                                            </Columns>

                                                                                                                                        </asp:GridView>
                                                                                                                                    </div>
                                                                                                                                </div>

                                                                                                                            </ContentTemplate>
                                                                                                                        </asp:UpdatePanel>

                                                                                                                    </div>
                                                                                                                </div>
                                                                                                            </div>
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



                                                                                                                                        <%--</ContentTemplate>
                                                           	
  </asp:UpdatePanel>--%>
                                                                                                                                    </div>
                                                                                                                                    <div class="modal-footer">
                                                                                                                                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                                                                                                    </div>
                                                                                                                                </div>

                                                                                                                            </div>
                                                                                                                        </div>

                                                                                                                        <asp:UpdatePanel ID="upc3" runat="server" UpdateMode="Conditional">
                                                                                                                            <ContentTemplate>

                                                                                                                                <div class="row">
                                                                                                                                    <div class="col-sm-3">
                                                                                                                                        <asp:Button ID="BtnHSQty3" runat="server" Text="Copy Of HS-Qunatity" OnClick="BtnHSQty3_Click" />
                                                                                                                                        <br />
                                                                                                                                        <p>Product Code &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnpc3" TabIndex="22" runat="server" Text="Search" /></p>
                                                                                                                                        <cc1:ModalPopupExtender ID="ModalPopupExtender3" runat="server" PopupControlID="pnlpc3" TargetControlID="btnpc3"
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

                                                                                                                                                        <asp:GridView ID="ProductCode3Grid" PageSize="5" OnPageIndexChanging="ProductCode3Grid_PageIndexChanging" AllowPaging="True" DataKeyNames="Id" CssClass="table table-stri onped table-bordered table-hover" OnRowCommand="ProductCode3Grid_RowCommand" OnRowDataBound="ProductCode3Grid_RowDataBound" runat="server" AutoGenerateColumns="false">
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





                                                                                                                                        <asp:TextBox autocomplete="off"  runat="server" type="text" ID="TxtProductCode3" ValidationGroup="Productcode" OnTextChanged="TxtProductCode3_TextChanged" AutoPostBack="true" TabIndex="224"></asp:TextBox>
                                                                                                                                        <br />
                                                                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProductCode3" ID="RegularExpressionValidator41" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>
                                                                                                                                        <br />
                                                                                                                                        <p>Quantity</p>
                                                                                                                                        <asp:TextBox autocomplete="off"  Width="70" runat="server" type="text" ValidationGroup="Productcode" ID="TxtProQty3" TabIndex="225"></asp:TextBox>


                                                                                                                                        <asp:DropDownList CssClass="drop" ID="DrpP3" runat="server" Width="70" Height="25" TabIndex="226"></asp:DropDownList>
                                                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator60" runat="server" ControlToValidate="TxtHAWB" ErrorMessage="Please Enter In HAWB/OBL"
                                                                                                                                            Display="Dynamic" ValidationGroup="ItemMasterValidation" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                                                                                        <br />

                                                                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProQty3" ID="RegularExpressionValidator46" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>
                                                                                                                                    </div>
                                                                                                                                    <div class="col-sm-9">

                                                                                                                                        <asp:GridView CssClass="table table-striped table-bordered table-hover" ID="ProductCode3Grid1" runat="server" ShowFooter="true" AutoGenerateColumns="false">
                                                                                                                                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                                                            <Columns>

                                                                                                                                                <asp:BoundField DataField="RowNumber" HeaderText="Row Number" Visible="false" />

                                                                                                                                                <asp:TemplateField HeaderText="CASC CODE 1">

                                                                                                                                                    <ItemTemplate>

                                                                                                                                                        <asp:TextBox autocomplete="off"  ID="TextBox1" runat="server" TabIndex="227"></asp:TextBox>

                                                                                                                                                    </ItemTemplate>

                                                                                                                                                </asp:TemplateField>

                                                                                                                                                <asp:TemplateField HeaderText="CASC CODE 2">

                                                                                                                                                    <ItemTemplate>

                                                                                                                                                        <asp:TextBox autocomplete="off"  ID="TextBox2" runat="server" TabIndex="228"></asp:TextBox>

                                                                                                                                                    </ItemTemplate>

                                                                                                                                                </asp:TemplateField>

                                                                                                                                                <asp:TemplateField HeaderText="CASC CODE 3">

                                                                                                                                                    <ItemTemplate>

                                                                                                                                                        <asp:TextBox autocomplete="off"  ID="TextBox3" runat="server" TabIndex="229"></asp:TextBox>

                                                                                                                                                    </ItemTemplate>

                                                                                                                                                    <FooterStyle HorizontalAlign="Right" />

                                                                                                                                                    <FooterTemplate>

                                                                                                                                                        <asp:Button ID="ProductCode3Add" OnClick="ProductCode3Add_Click" runat="server" Text="Add New Row" />

                                                                                                                                                    </FooterTemplate>

                                                                                                                                                </asp:TemplateField>

                                                                                                                                            </Columns>

                                                                                                                                        </asp:GridView>
                                                                                                                                    </div>
                                                                                                                                </div>

                                                                                                                            </ContentTemplate>
                                                                                                                        </asp:UpdatePanel>

                                                                                                                    </div>
                                                                                                                </div>
                                                                                                            </div>
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
                                                                                                                                    </div>
                                                                                                                                    <div class="modal-footer">
                                                                                                                                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                                                                                                    </div>
                                                                                                                                </div>

                                                                                                                            </div>
                                                                                                                        </div>

                                                                                                                        <asp:UpdatePanel ID="upc4" runat="server" UpdateMode="Conditional">
                                                                                                                            <ContentTemplate>
                                                                                                                                <div class="row">
                                                                                                                                    <div class="col-sm-3">
                                                                                                                                        <p>
                                                                                                                                            Product Code &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnpc4" TabIndex="22" runat="server" Text="Search" />
                                                                                                                                        </p>
                                                                                                                                        <cc1:ModalPopupExtender ID="ModalPopupExtender4" runat="server" PopupControlID="pnlpc4" TargetControlID="btnpc4"
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

                                                                                                                                                        <asp:DropDownList ID="ddlpc4" runat="server" AutoPostBack="true">

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

                                                                                                                                        <asp:TextBox autocomplete="off"  runat="server" type="text" ID="TxtProductCode4" ValidationGroup="Productcode" OnTextChanged="TxtProductCode4_TextChanged" AutoPostBack="true" TabIndex="230"></asp:TextBox>
                                                                                                                                        <br />
                                                                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProductCode4" ID="RegularExpressionValidator42" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>
                                                                                                                                        <br />
                                                                                                                                        <p>Quantity</p>
                                                                                                                                        <asp:TextBox autocomplete="off"  Width="70" runat="server" type="text" ValidationGroup="Productcode" ID="TxtProQty4" TabIndex="231"></asp:TextBox>

                                                                                                                                        <asp:DropDownList CssClass="drop" ID="DrpP4" runat="server" Width="70" Height="25" TabIndex="232"></asp:DropDownList>
                                                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator61" runat="server" ControlToValidate="TxtHAWB" ErrorMessage="Please Enter In HAWB/OBL"
                                                                                                                                            Display="Dynamic" ValidationGroup="ItemMasterValidation" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                                                                                        <br />
                                                                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProQty4" ID="RegularExpressionValidator47" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>

                                                                                                                                    </div>
                                                                                                                                    <div class="col-sm-9">

                                                                                                                                        <asp:GridView CssClass="table table-striped table-bordered table-hover" ID="ProductCode4Grid1" runat="server" ShowFooter="true" AutoGenerateColumns="false">
                                                                                                                                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                                                            <Columns>

                                                                                                                                                <asp:BoundField DataField="RowNumber" HeaderText="Row Number" Visible="false" />

                                                                                                                                                <asp:TemplateField HeaderText="CASC CODE 1">

                                                                                                                                                    <ItemTemplate>

                                                                                                                                                        <asp:TextBox autocomplete="off"  ID="TextBox1" runat="server" TabIndex="233"></asp:TextBox>

                                                                                                                                                    </ItemTemplate>

                                                                                                                                                </asp:TemplateField>

                                                                                                                                                <asp:TemplateField HeaderText="CASC CODE 2">

                                                                                                                                                    <ItemTemplate>

                                                                                                                                                        <asp:TextBox autocomplete="off"  ID="TextBox2" runat="server" TabIndex="234"></asp:TextBox>

                                                                                                                                                    </ItemTemplate>

                                                                                                                                                </asp:TemplateField>

                                                                                                                                                <asp:TemplateField HeaderText="CASC CODE 3">

                                                                                                                                                    <ItemTemplate>

                                                                                                                                                        <asp:TextBox autocomplete="off"  ID="TextBox3" runat="server" TabIndex="235"></asp:TextBox>

                                                                                                                                                    </ItemTemplate>

                                                                                                                                                    <FooterStyle HorizontalAlign="Right" />

                                                                                                                                                    <FooterTemplate>

                                                                                                                                                        <asp:Button ID="ProductCode4Add" OnClick="ProductCode4Add_Click" runat="server" Text="Add New Row" />

                                                                                                                                                    </FooterTemplate>

                                                                                                                                                </asp:TemplateField>

                                                                                                                                            </Columns>

                                                                                                                                        </asp:GridView>
                                                                                                                                    </div>
                                                                                                                                </div>

                                                                                                                            </ContentTemplate>
                                                                                                                        </asp:UpdatePanel>

                                                                                                                    </div>
                                                                                                                </div>
                                                                                                            </div>
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

                                                                                                                                        <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                                                                                                    </div>
                                                                                                                                    <div class="modal-footer">
                                                                                                                                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                                                                                                    </div>
                                                                                                                                </div>

                                                                                                                            </div>
                                                                                                                        </div>
                                                                                                                        <asp:UpdatePanel ID="upc5" runat="server" UpdateMode="Conditional">
                                                                                                                            <ContentTemplate>

                                                                                                                                <div class="row">
                                                                                                                                    <div class="col-sm-3">

                                                                                                                                        <p>Product Code &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnpc5" TabIndex="22" runat="server" Text="Search" /></p>


                                                                                                                                        <cc1:ModalPopupExtender ID="ModalPopupExtender5" runat="server" PopupControlID="pnlpc5" TargetControlID="btnpc5"
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

                                                                                                                                                        <asp:DropDownList ID="ddlpc5" runat="server" AutoPostBack="true">

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




                                                                                                                                        <asp:TextBox autocomplete="off"  runat="server" type="text" ID="TxtProductCode5" ValidationGroup="Productcode" OnTextChanged="TxtProductCode5_TextChanged" AutoPostBack="true" TabIndex="236"></asp:TextBox>
                                                                                                                                        <br />
                                                                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProductCode5" ID="RegularExpressionValidator43" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>
                                                                                                                                        <br />
                                                                                                                                        <p>Quantity</p>
                                                                                                                                        <asp:TextBox autocomplete="off"  Width="70" runat="server" type="text" ValidationGroup="Productcode" ID="TxtProQty5" TabIndex="237"></asp:TextBox>

                                                                                                                                        <asp:DropDownList CssClass="drop" ID="DrpP5" runat="server" Width="70" Height="25" TabIndex="238"></asp:DropDownList>
                                                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator62" runat="server" ControlToValidate="TxtHAWB" ErrorMessage="Please Enter In HAWB/OBL"
                                                                                                                                            Display="Dynamic" ValidationGroup="ItemMasterValidation" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                                                                                        <br />
                                                                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProQty5" ID="RegularExpressionValidator48" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>

                                                                                                                                    </div>
                                                                                                                                    <div class="col-sm-9">

                                                                                                                                        <asp:GridView CssClass="table table-striped table-bordered table-hover" ID="ProductCode5Grid1" runat="server" ShowFooter="true" AutoGenerateColumns="false">
                                                                                                                                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                                                            <Columns>

                                                                                                                                                <asp:BoundField DataField="RowNumber" HeaderText="Row Number" Visible="false" />

                                                                                                                                                <asp:TemplateField HeaderText="CASC CODE 1">

                                                                                                                                                    <ItemTemplate>

                                                                                                                                                        <asp:TextBox autocomplete="off"  ID="TextBox1" runat="server" TabIndex="239"></asp:TextBox>

                                                                                                                                                    </ItemTemplate>

                                                                                                                                                </asp:TemplateField>

                                                                                                                                                <asp:TemplateField HeaderText="CASC CODE 2">

                                                                                                                                                    <ItemTemplate>

                                                                                                                                                        <asp:TextBox autocomplete="off"  ID="TextBox2" runat="server" TabIndex="240"></asp:TextBox>

                                                                                                                                                    </ItemTemplate>

                                                                                                                                                </asp:TemplateField>

                                                                                                                                                <asp:TemplateField HeaderText="CASC CODE 3">

                                                                                                                                                    <ItemTemplate>

                                                                                                                                                        <asp:TextBox autocomplete="off"  ID="TextBox3" runat="server" TabIndex="241"></asp:TextBox>

                                                                                                                                                    </ItemTemplate>

                                                                                                                                                    <FooterStyle HorizontalAlign="Right" />

                                                                                                                                                    <FooterTemplate>

                                                                                                                                                        <asp:Button ID="ProductCode5Plus" OnClick="ProductCode5Plus_Click" runat="server" Text="Add New Row" />

                                                                                                                                                    </FooterTemplate>

                                                                                                                                                </asp:TemplateField>

                                                                                                                                            </Columns>

                                                                                                                                        </asp:GridView>
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
                                                                                                            <asp:DropDownList CssClass="drop" ID="DrpPreferentialCode" OnSelectedIndexChanged="DrpPreferentialCode_SelectedIndexChanged" AutoPostBack="true" runat="server" Width="250" Height="25" TabIndex="243"></asp:DropDownList>
                                                                                                        </div>
                                                                                                    </div>



                                                                                                </div>
                                                                                                <div class="col-sm-6">
                                                                                                </div>
                                                                                            </div>


                                                                                            <br />

                                                                                            <div class="row" style="background-color: black; color: white; height: 20px;">
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
                                                                                            <div class="row">
                                                                                                <div class="col-sm-6">
                                                                                                    GST (<asp:CheckBox ID="chk234" runat="server" TabIndex="244" AutoPostBack="true"  OnCheckedChanged="chk234_CheckedChanged" />
                                                                                                    Auto-compute duties and taxes)
                                                                                                </div>
                                                                                                <div class="col-sm-2">
                                                                                                    <asp:TextBox autocomplete="off"  ID="ItemGSTRate" runat="server" onkeypress="return isNumberKey(event)" TabIndex="245" Width="120" Text="7" Enabled="false"></asp:TextBox>

                                                                                                </div>
                                                                                                <div class="col-sm-2">
                                                                                                    <asp:TextBox autocomplete="off"  ID="ItemGSTUOM" runat="server" TabIndex="246" Width="120" Text="PER"></asp:TextBox>

                                                                                                </div>
                                                                                                <div class="col-sm-2">
                                                                                                    <asp:TextBox autocomplete="off"  ID="TxtItemSumGST" runat="server" onkeypress="return isNumberKey(event)" Width="120" TabIndex="247" Text="0.00"></asp:TextBox>
                                                                                                </div>
                                                                                            </div>


                                                                                            <div class="row">
                                                                                                <div class="col-sm-6">
                                                                                                    Excise Duty  
                                                                                                </div>
                                                                                                <div class="col-sm-2">
                                                                                                    <asp:TextBox autocomplete="off"  ID="TxtExciseDutyRate" onkeypress="return isNumberKey(event)" runat="server" Width="120" Text="0.00" TabIndex="248"></asp:TextBox>
                                                                                                </div>
                                                                                                <div class="col-sm-2">
                                                                                                    <asp:TextBox autocomplete="off"  ID="TxtExciseDutyUOM" runat="server" Width="120" Text="0.00" TabIndex="249"></asp:TextBox>
                                                                                                </div>
                                                                                                <div class="col-sm-2">
                                                                                                    <asp:TextBox autocomplete="off"  ID="TxtSumExciseDuty" onkeypress="return isNumberKey(event)" runat="server" Width="120" Text="0.00" TabIndex="250"></asp:TextBox>
                                                                                                </div>
                                                                                            </div>

                                                                                            <div class="row">
                                                                                                <div class="col-sm-6">
                                                                                                    <asp:Label ID="lblCustomsDuty" Text="Customs Duty" Width="120" runat="server"></asp:Label>
                                                                                                </div>
                                                                                                <div class="col-sm-2">
                                                                                                    <asp:TextBox autocomplete="off"  ID="TxtCustomsDutyRate" onkeypress="return isNumberKey(event)" runat="server" Width="120" Text="0.00" TabIndex="251"></asp:TextBox>
                                                                                                </div>
                                                                                                <div class="col-sm-2">
                                                                                                    <asp:TextBox autocomplete="off"  ID="TxtCustomsDutyUOM" runat="server" Width="120" Text="0.00" TabIndex="252"></asp:TextBox>
                                                                                                </div>
                                                                                                <div class="col-sm-2">
                                                                                                    <asp:TextBox autocomplete="off"  ID="TxtSumCustomsDuty" onkeypress="return isNumberKey(event)" runat="server" Width="120" Text="0.00" TabIndex="253"></asp:TextBox>
                                                                                                </div>
                                                                                            </div>

                                                                                            <div class="row">
                                                                                                <div class="col-sm-6">
                                                                                                    Other Tax 
                                                                                                </div>
                                                                                                <div class="col-sm-2">
                                                                                                    <asp:TextBox autocomplete="off"  ID="TxtOtherTaxRate" onkeypress="return isNumberKey(event)" runat="server" Width="120" Text="0.00" TabIndex="254"></asp:TextBox>
                                                                                                </div>
                                                                                                <div class="col-sm-2">
                                                                                                    <asp:DropDownList CssClass="drop" ID="DrpOtherUOM" Width="120" runat="server" TabIndex="255"></asp:DropDownList>
                                                                                                </div>
                                                                                                <div class="col-sm-2">
                                                                                                    <asp:TextBox autocomplete="off"  ID="TxtSumOtherTaxRate" onkeypress="return isNumberKey(event)" runat="server" Width="120" Text="0.00" TabIndex="256"></asp:TextBox>
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
                                                                                                    <asp:TextBox autocomplete="off"  runat="server" type="text" ID="TxtCurrentLot" ValidationGroup="Item" TabIndex="258" class="w3-input w3-hover-green"></asp:TextBox>
                                                                                                    <br />

                                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtCurrentLot" ID="RegularExpressionValidator30" ValidationExpression="^[\s\S]{0,30}$" runat="server" ErrorMessage="Maximum 30 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                                </div>
                                                                                                <div class="col-sm-4">
                                                                                                    <p>Marking </p>
                                                                                                    <asp:DropDownList CssClass="drop" Height="30" runat="server" ID="DrpMaking" Width="250" TabIndex="259"></asp:DropDownList>
                                                                                                </div>
                                                                                                <div class="col-sm-4">
                                                                                                    <p>Previous Lot</p>
                                                                                                    <asp:TextBox autocomplete="off"  runat="server" type="text" ID="TxtPreviousLot" ValidationGroup="Item" TabIndex="260" class="w3-input w3-hover-green"></asp:TextBox>
                                                                                                    <br />

                                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtPreviousLot" ID="RegularExpressionValidator31" ValidationExpression="^[\s\S]{0,30}$" runat="server" ErrorMessage="Maximum 30 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                                </div>
                                                                                            </div>


                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <div id="ShippMarkDiv" runat="server" class="panel panel-primary">
                                                                                <div class="panel-heading">
                                                                                    <h4 class="panel-title">
                                                                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse10">SHIPPILNG MARKS INFORMATION</a>                                        </h4>
                                                                                </div>
                                                                                <div id="collapse10" class="panel-collapse collapse ">
                                                                                    <div class="panel-body">
                                                                                        <div class="row">
                                                                                            <asp:ValidationSummary ID="ValidationSummary16" runat="server" ShowMessageBox="True"
                                                                                                ShowSummary="False" ValidationGroup="Shipping" />
                                                                                            <div class="col-sm-3">
                                                                                                <p>Shipping Marks 1</p>
                                                                                                <asp:TextBox autocomplete="off"  runat="server" type="text" ID="txtShippingMarks1" ValidationGroup="Shipping" Style="text-transform :uppercase" TextMode="MultiLine" TabIndex="261"></asp:TextBox>
                                                                                                <br />
                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtShippingMarks1"  ID="RegularExpressionValidator49" ValidationExpression="^[\s\S]{0,170}$" runat="server" ErrorMessage="Maximum 170 characters allowed." ValidationGroup="Shipping"></asp:RegularExpressionValidator>
                                                                                            </div>
                                                                                            <div class="col-sm-3">
                                                                                                <p>Shipping Marks 2</p>
                                                                                                <asp:TextBox autocomplete="off"  runat="server" type="text" ID="txtShippingMarks2" ValidationGroup="Shipping" Style="text-transform :uppercase"  TextMode="MultiLine" TabIndex="262"></asp:TextBox>
                                                                                                <br />
                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtShippingMarks2" ID="RegularExpressionValidator32" ValidationExpression="^[\s\S]{0,170}$" runat="server" ErrorMessage="Maximum 170 characters allowed." ValidationGroup="Shipping"></asp:RegularExpressionValidator>
                                                                                            </div>
                                                                                            <div class="col-sm-3">
                                                                                                <p>Shipping Marks 3</p>
                                                                                                <asp:TextBox autocomplete="off"  runat="server" type="text" ID="txtShippingMarks3" Style="text-transform :uppercase" ValidationGroup="Shipping" TextMode="MultiLine" TabIndex="263"></asp:TextBox>
                                                                                                <br />
                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtShippingMarks3" ID="RegularExpressionValidator33" ValidationExpression="^[\s\S]{0,136}$" runat="server" ErrorMessage="Maximum 136 characters allowed." ValidationGroup="Shipping"></asp:RegularExpressionValidator>
                                                                                            </div>
                                                                                            <div class="col-sm-3">
                                                                                                <p>Shipping Marks 4</p>
                                                                                                <asp:TextBox autocomplete="off"  runat="server" type="text" ID="txtShippingMarks4" Style="text-transform :uppercase" ValidationGroup="Shipping" TextMode="MultiLine" TabIndex="264"></asp:TextBox>
                                                                                                <br />
                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtShippingMarks4" ID="RegularExpressionValidator34" ValidationExpression="^[\s\S]{0,36}$" runat="server" ErrorMessage="Maximum 36 characters allowed." ValidationGroup="Shipping"></asp:RegularExpressionValidator>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <hr />
                                                                            <div class="row">
                                                                                <!-- Importer Search -->

                                                                                <div class="col-sm-8">
                                                                                </div>

                                                                                <asp:ValidationSummary ID="ValidationSummary12" runat="server" ShowMessageBox="True"
                                                                                    ShowSummary="False" ValidationGroup="Item" />
                                                                                <div class="col-sm-4">
                                                                                    <asp:Button ID="BtnItemAdd" Visible="false" CssClass="btn btn-block btn-success" ValidationGroup="Item" runat="server" Text="Add Item" OnClick="BtnItemAdd_Click" />

                                                                                </div>

                                                                                <div class="col-sm-8">
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                    </div>

                                                                    
                                                                    <hr class="mt-4" />
<div class="flex justify-between gap-4 md:flex-nowrap flex-wrap mt-6">
    <asp:Button ID="btnprevitem" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" runat="server" class="btn btn-info btn-lg" OnClick="btnprevitem_Click" Text="Previous" TabIndex="174" />
    <div class="flex gap-4 flex-wrap md:flex-nowrap md:max-w-[260px] w-full">
        <asp:Button ID="btnresetitem" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" runat="server" class="btn btn-info btn-lg" OnClick="btnresetitem_Click" Text="Reset" TabIndex="176" />
        <asp:Button ID="btnsaveitem" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] bg-opacity-10 border hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-[#0560FD] text-center rounded-md text-sm sa700" runat="server" class="btn btn-info btn-lg" ValidationGroup="Item" OnClick="BtnItemAdd_Click" Text="+ Add Item" TabIndex="175" />

    </div>
    <asp:Button ID="btnnextitem" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" runat="server" class="btn btn-info btn-lg" OnClick="btnnextitem_Click" Text="Next" TabIndex="177" />

</div>

                                                                    <center>
                                                                     <div class="row">
                                                                            <asp:Label  ID="lblitemalert" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                                                        </div>
                                                                        </center>
                                                                    <div id="ItemAddGrid" runat="server"><br />
                                                                        <asp:TextBox autocomplete="off"  ID="AddItemSearch" OnTextChanged="AddItemSearch_TextChanged" style="width:100%" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                        <br />

                                                                        <asp:GridView ID="AddItemGrid" Font-Size="10" OnRowDeleting="AddItemGrid_RowDeleting" PageSize="50" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="AddItemGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" OnRowEditing="AddItemGrid_RowEditing" AutoGenerateColumns="false" OnSelectedIndexChanged="AddItemGrid_SelectedIndexChanged">
                                                                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                            <Columns>
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

                                                                                <asp:TemplateField HeaderText="INHAWB" SortExpression="Id">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="InHAWBOBL" runat="server"
                                                                                            Text='<%#Eval("InHAWBOBL")%>'>
                                                                                        </asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="OutHAWB" SortExpression="Id">
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
                                                    <%--     </div>--%>
                                                    <%--<div role="tabpanel" class="tab-pane fade" id="CPC">--%>
                                                    <cc1:TabPanel ID="CPC" runat="server" HeaderText="CPC">
                                                        <ContentTemplate>
                                                            <asp:UpdatePanel ID="upinnoncpc" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>



                                                                    <div class="row" style="margin-top: 100px;">
                                                                        <div class="col-sm-12">
                                                                            <div class="row">
                                                                                <div class="col-sm-2">
                                                                                    <asp:CheckBox ID="chkaeo" OnCheckedChanged="chkaeo_CheckedChanged" AutoPostBack="true" runat="server" Text="AEO" Checked="false" TabIndex="269" />
                                                                                </div>
                                                                                <div class="col-sm-10" id="AEO" runat="server">
                                                                                    <asp:Button ID="BtnAEO" runat="server" OnClick="BtnAEO_Click" Text="Add Row" />
                                                                                    <br />
                                                                                    <br />
                                                                                    <asp:GridView ID="AEOGrid" OnRowDeleting="AEOGrid_RowDeleting" CssClass="table table-striped table-bordered table-hover" runat="server" ShowFooter="true" AutoGenerateColumns="false">
                                                                                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                        <Columns>

                                                                                            <asp:BoundField DataField="RowNumber" HeaderText="Row Number" />

                                                                                            <asp:TemplateField HeaderText="Processing Code1">

                                                                                                <ItemTemplate>

                                                                                                    <asp:TextBox autocomplete="off"  ID="TextBox1" runat="server" TabIndex="270"></asp:TextBox>

                                                                                                </ItemTemplate>

                                                                                            </asp:TemplateField>

                                                                                            <asp:TemplateField HeaderText="Processing Code2">

                                                                                                <ItemTemplate>

                                                                                                    <asp:TextBox autocomplete="off"  ID="TextBox2" runat="server" TabIndex="271"></asp:TextBox>

                                                                                                </ItemTemplate>

                                                                                            </asp:TemplateField>

                                                                                            <asp:TemplateField HeaderText="Processing Code3">

                                                                                                <ItemTemplate>

                                                                                                    <asp:TextBox autocomplete="off"  ID="TextBox3" runat="server" TabIndex="272"></asp:TextBox>

                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Delete">
                                                                                                <ItemTemplate>
                                                                                                    <asp:LinkButton data-toggle="modal" data-target='<%#"#"+DataBinder.Eval(Container.DataItem,"RowNumber")%>' Width="11" Height="11" ID="imgDelete" runat="server"><i class='fa fa-trash' style="color:red"></i></asp:LinkButton>

                                                                                                    <div class="modal fade" id='<%#Eval("RowNumber")%>' role="dialog">
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
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>

                                                                                    </asp:GridView>

                                                                                </div>
                                                                            </div>
                                                                            <hr />
                                                                            <div class="row">
                                                                                <div class="col-sm-2">
                                                                                    <asp:CheckBox ID="chkcwc" OnCheckedChanged="chkcwc_CheckedChanged" AutoPostBack="true" runat="server" Text="CWC" Checked="false" TabIndex="273" />
                                                                                </div>
                                                                                <div class="col-sm-10" id="CWC" runat="server">
                                                                                    <asp:Button ID="BtnCWC" runat="server" TabIndex="274" OnClick="BtnCWC_Click" Text="Add Row" />
                                                                                    <br />
                                                                                    <br />
                                                                                    <asp:GridView ID="CWCGrid" OnRowDeleting="CWCGrid_RowDeleting" CssClass="table table-striped table-bordered table-hover" runat="server" ShowFooter="true" AutoGenerateColumns="false">
                                                                                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                        <Columns>

                                                                                            <asp:BoundField DataField="RowNumber" HeaderText="Row Number" />

                                                                                            <asp:TemplateField HeaderText="Processing Code1">

                                                                                                <ItemTemplate>

                                                                                                    <asp:TextBox autocomplete="off"  ID="TextBox1" runat="server" TabIndex="275"></asp:TextBox>

                                                                                                </ItemTemplate>

                                                                                            </asp:TemplateField>

                                                                                            <asp:TemplateField HeaderText="Processing Code2">

                                                                                                <ItemTemplate>

                                                                                                    <asp:TextBox autocomplete="off"  ID="TextBox2" runat="server" TabIndex="276"></asp:TextBox>

                                                                                                </ItemTemplate>

                                                                                            </asp:TemplateField>

                                                                                            <asp:TemplateField HeaderText="Processing Code3">

                                                                                                <ItemTemplate>

                                                                                                    <asp:TextBox autocomplete="off"  ID="TextBox3" runat="server" TabIndex="277"></asp:TextBox>

                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Delete">
                                                                                                <ItemTemplate>
                                                                                                    <asp:LinkButton data-toggle="modal" data-target='<%#"#"+DataBinder.Eval(Container.DataItem,"RowNumber")%>' Width="11" Height="11" ID="imgDelete" runat="server"><i class='fa fa-trash' style="color:red"></i></asp:LinkButton>

                                                                                                    <div class="modal fade" id='<%#Eval("RowNumber")%>' role="dialog">
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
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>

                                                                                    </asp:GridView>

                                                                                </div>
                                                                            </div>
                                                                            <hr />
                                                                            <div class="row">
                                                                                <div class="col-sm-2">
                                                                                    <asp:CheckBox ID="ChkSea1" OnCheckedChanged="ChkSea_CheckedChanged" AutoPostBack="true" runat="server" Text="SEA STORE" Checked="false" TabIndex="278" />
                                                                                </div>
                                                                                <div class="col-sm-10" id="SEA" runat="server">
                                                                                    <asp:Button ID="btnSeaStr" runat="server" TabIndex="279" OnClick="btnSeaStr_Click" Text="Add Row" />
                                                                                    <br />
                                                                                    <br />
                                                                                    <asp:GridView ID="SeaGrid" OnRowDeleting="SeaGrid_RowDeleting" CssClass="table table-striped table-bordered table-hover" runat="server" ShowFooter="true" AutoGenerateColumns="false">
                                                                                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                        <Columns>

                                                                                            <asp:BoundField DataField="RowNumber" HeaderText="Row Number" />

                                                                                            <asp:TemplateField HeaderText="Processing Code1">

                                                                                                <ItemTemplate>

                                                                                                    <asp:TextBox autocomplete="off"  ID="TextBox1" runat="server" TabIndex="280"></asp:TextBox>

                                                                                                </ItemTemplate>

                                                                                            </asp:TemplateField>

                                                                                            <asp:TemplateField HeaderText="Processing Code2">

                                                                                                <ItemTemplate>

                                                                                                    <asp:TextBox autocomplete="off"  ID="TextBox2" runat="server" TabIndex="281"></asp:TextBox>

                                                                                                </ItemTemplate>

                                                                                            </asp:TemplateField>

                                                                                            <asp:TemplateField HeaderText="Processing Code3">

                                                                                                <ItemTemplate>

                                                                                                    <asp:TextBox autocomplete="off"  ID="TextBox3" runat="server" TabIndex="282"></asp:TextBox>

                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Delete">
                                                                                                <ItemTemplate>
                                                                                                    <asp:LinkButton data-toggle="modal" data-target='<%#"#"+DataBinder.Eval(Container.DataItem,"RowNumber")%>' Width="11" Height="11" ID="imgDelete" runat="server"><i class='fa fa-trash' style="color:red"></i></asp:LinkButton>

                                                                                                    <div class="modal fade" id='<%#Eval("RowNumber")%>' role="dialog">
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
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>

                                                                                    </asp:GridView>

                                                                                </div>
                                                                            </div>
                                                                            <hr />
                                                                            <div class="row">
                                                                                <div class="col-sm-2">
                                                                                    <asp:CheckBox ID="chkcnb" runat="server" Text="CNB" Checked="false" TabIndex="283" />
                                                                                </div>
                                                                                <div class="col-sm-10">
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                                                <div class="row">
    <div class="col-sm-12">
        <center>

            <div class="flex justify-between gap-4 md:flex-nowrap flex-wrap mt-6">
                
                <asp:Button ID="btnprevcpc" runat="server" class="btn btn-info btn-lg" OnClick="btnprevcpc_Click" Text="Previous" TabIndex="284" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full"  />
                <asp:Button ID="btnsavecpc" runat="server" class="btn btn-info btn-lg" OnClick="btnsavecpc_Click" Text="Save" TabIndex="285" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full"  />
                <asp:Button ID="btnresetcpc" runat="server" class="btn btn-info btn-lg" OnClick="btnresetcpc_Click" Text="Reset" TabIndex="286" Visible="false" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" />
                <asp:Button ID="btnnextcpc" runat="server" class="btn btn-info btn-lg" OnClick="btnnextcpc_Click" Text="Next" TabIndex="287" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />

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
                                                    <%-- </div>--%>
                                                    <div role="tabpanel" class="tab-pane fade" id="Summary">
                                                        <cc1:TabPanel ID="Summery" runat="server" HeaderText="Summary">
                                                            <ContentTemplate>
                                                                <asp:UpdatePanel ID="upinnonsummary" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>



                                                                        <div class="col-sm-12" style="margin-top: 100px;">
                                                                            <asp:ValidationSummary ID="ValidationSummary14" runat="server" ShowMessageBox="True"
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
                                                                                                    <asp:TextBox autocomplete="off"  runat="server" Enabled="false" ForeColor="Red" Font-Names="verdana" Font-Size="small" Font-Bold="true" Width="150" type="text" ID="txtnoofinv" Text="0" TabIndex="288"></asp:TextBox>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="col-sm-3">
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-6 col-form-label">
                                                                                                    No of Items


                                                                                                </label>
                                                                                                <div class="col-sm-6">
                                                                                                    <asp:TextBox autocomplete="off"  runat="server" Enabled="false" ForeColor="Red" Font-Names="verdana" Font-Size="small" Font-Bold="true" Width="150" type="text" ID="txtnoofitm" Text="0.00" TabIndex="289"></asp:TextBox>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="col-sm-3">
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-6 col-form-label">
                                                                                                    Sum of Item Amt


                                                                                                </label>
                                                                                                <div class="col-sm-6">
                                                                                                    <asp:TextBox autocomplete="off"  runat="server" Enabled="false" ForeColor="Red" Font-Names="verdana" Font-Size="Small" Font-Bold="true" Width="150" type="text" ID="txtitmAmt" Text="0.00" TabIndex="290"></asp:TextBox>
                                                                                                    <asp:Label ID="lblerror" ForeColor="Red" Font-Names="verdana"  runat="server" Width="80%" Font-Size="small" Font-Bold="true"></asp:Label>
                                                                                                    <asp:Label ID="lblsameerror" ForeColor="Red" Font-Names="verdana"  runat="server" Width="80%" Font-Size="small" Font-Bold="true"></asp:Label>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="col-sm-3">
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-6 col-form-label">
                                                                                                    Tot Inv CIF Val

                                                                                                </label>
                                                                                                <div class="col-sm-6">
                                                                                                    <asp:TextBox autocomplete="off"  ForeColor="Red" Font-Names="verdana" Font-Size="small" Font-Bold="true" runat="server" Enabled="false" Width="150" type="text" ID="txtcifVal" Text="0.00" TabIndex="291"></asp:TextBox>
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
                                                                                                    <asp:TextBox autocomplete="off" ForeColor="Red" Font-Names="verdana" Font-Size="small" Font-Bold="true" runat="server" Enabled="false" Width="150" type="text" ID="txtfobval" Text="0.00" TabIndex="292"></asp:TextBox>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="col-sm-3">
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-6 col-form-label">
                                                                                                    Tot GST Amt
                                                                                                </label>
                                                                                                <div class="col-sm-6">
                                                                                                    <asp:TextBox autocomplete="off" ForeColor="Red" Font-Names="verdana" Font-Size="small" Font-Bold="true"  runat="server" Enabled="false" Width="150" type="text" ID="txttotgstAmt" Text="0.00" TabIndex="293"></asp:TextBox>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="col-sm-3">
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-6 col-form-label">
                                                                                                    Tot Exc Duty Amt
                                                                                                </label>
                                                                                                <div class="col-sm-6">
                                                                                                    <asp:TextBox autocomplete="off" ForeColor="Red" Font-Names="verdana" Font-Size="small" Font-Bold="true" runat="server" Enabled="false" Width="150" type="text" ID="txttotexAmt" Text="0.00" TabIndex="294"></asp:TextBox>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="col-sm-3">
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-6 col-form-label">
                                                                                                    Tot Cus Duty Amt
                                                                                                </label>
                                                                                                <div class="col-sm-6">
                                                                                                    <asp:TextBox autocomplete="off" ForeColor="Red" Font-Names="verdana" Font-Size="small" Font-Bold="true" runat="server" Enabled="false" Width="150" type="text" ID="txtcusdutyAmt" Text="0.00" TabIndex="295"></asp:TextBox>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="row">
                                                                                        <div class="col-sm-3">
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-6 col-form-label">
                                                                                                    Tot Other Tax Amt
                                                                                                </label>
                                                                                                <div class="col-sm-6">
                                                                                                    <asp:TextBox autocomplete="off" ForeColor="Red" Font-Names="verdana" Font-Size="small" Font-Bold="true" runat="server" Enabled="false" Width="150" type="text" ID="txtothtaxAmt" Text="0.00" TabIndex="296"></asp:TextBox>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="col-sm-3">
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-6 col-form-label">
                                                                                                    Tot Amt Payable
                                                                                                </label>
                                                                                                <div class="col-sm-6">
                                                                                                    <asp:TextBox autocomplete="off"  ForeColor="Red" Font-Names="verdana" Font-Size="small" Font-Bold="true"  runat="server" Enabled="false" Width="150" type="text" ID="txtAmtPayble" Text="0.00" TabIndex="297"></asp:TextBox>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="col-sm-3">
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-6 col-form-label">
                                                                                                    Sum Of Inv Amt
                                                                                                </label>
                                                                                                <div class="col-sm-6">
                                                                                                    <div id="div3" style="color:red;" runat="server"></div>
                                                                                                    <asp:Label ID="lbltotinvAmt" Visible="false" runat="server" Text="0.00"></asp:Label>
                                                                                                    <%--<asp:TextBox  autocomplete="off"    runat="server" type="text" ID="txtinvAmt" TabIndex="1"></asp:TextBox>--%>
                                                                                                    <br />
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="col-sm-3">
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-6 col-form-label">
                                                                                                    Sum Of Item Amt
                                                                                                </label>
                                                                                                <div class="col-sm-6">
                                                                                                    <div id="div6" style="color:red;" runat="server"></div>
                                                                                                    <asp:Label ID="Label1" Visible="false" runat="server" Text="0.00"></asp:Label>
                                                                                                    <%--<asp:TextBox  autocomplete="off"    runat="server" type="text" ID="txtinvAmt" TabIndex="1"></asp:TextBox>--%>
                                                                                                    <br />
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="row">
                                                                                        <asp:CheckBox ID="chkAuto" Enabled="true" AutoPostBack="true" OnCheckedChanged="chkAuto_CheckedChanged" Width="200" runat="server" Text="Auto-Compute" TabIndex="298" />
                                                                                    </div>
                                                                                    <div class="row">
                                                                                        <div class="col-sm-12">
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-6 col-form-label">
                                                                                                </label>
                                                                                                <div class="col-sm-6">




                                                                                                    <p id="cusremarks" runat="server" visible="false">Customer Remarks(will Not be Submitted to Singapore Customs)</p>
                                                                                                    <asp:TextBox  ForeColor="Red" autocomplete="off"    ID="txtcusRemrk" Visible="false" runat="server" TextMode="MultiLine" Height="70" TabIndex="299" Width="100%"></asp:TextBox>



                                                                                                </div>

                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="row">
                                                                                        <div class="col-sm-12">
                                                                                            Trader's Remarks(will be Submitted to Singapore Customs)
                                                                                                      <asp:Button ID="btninvnum" runat="server" OnClick="btninvnum_Click" Text="Append Invoice Number" /><asp:Button ID="Button5" TabIndex="300" OnClick="Button3_Click" runat="server" Text="Append Ex Rate" />  CROSS REFERENCE <asp:TextBox ID="TxtGrossReference" runat="server"  Style="text-transform: uppercase"></asp:TextBox>
                                                                                            <asp:TextBox autocomplete="off"   ID="txttrdremrk" ValidationGroup="Summery" runat="server" TextMode="MultiLine" AutoPostBack="true" OnTextChanged="txttrdremrk_TextChanged" MaxLength="1024" TabIndex="301" Height="70" Width="100%" Style="text-transform: uppercase"></asp:TextBox>
                                                                                            <br />
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txttrdremrk" ID="RegularExpressionValidator14" ValidationExpression="^[\s\S]{0,1024}$" runat="server" ErrorMessage="Maximum 1024 characters allowed." ValidationGroup="Summery"></asp:RegularExpressionValidator>
                                                                                            <br />
                                                                                            <asp:Label ID="lbltracunt" runat="server"></asp:Label>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="row">
                                                                                        <div class="col-sm-12">


                                                                                            <div class="form-group row">

                                                                                                <div class="col-sm-12">

                                                                                                    <p>INTERNAL REFERENCE</p>
                                                                                                    <asp:TextBox autocomplete="off"   ID="txtintremrk" runat="server" Height="70" TabIndex="302" Width="100%" Style="text-transform: uppercase"></asp:TextBox>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>

                                                                                    <div class="row">
                                                                                        <div class="col-sm-12">
                                                                                            <div class="row Borderdiv" style="width: 100%">
                                                                                                Declaration Summary
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="col-sm-12">
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                    Importer


                                                                                                </label>
                                                                                                <div class="col-sm-9">
                                                                                                    <asp:Label ID="lblimporterparty"  Style="text-transform: uppercase" runat="server" Width="80%" Text="" Font-Size="Medium" Font-Bold="true"></asp:Label>
                                                                                                    <%--<asp:TextBox autocomplete="off"  runat="server" Enabled="false" Width="100" type="text" ID="TextBox25" TabIndex="1"></asp:TextBox>--%>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                         <div class="col-sm-6">
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                    
                                                                                                  Outward  OBL/MAWB

                                                                                                </label>
                                                                                                <div class="col-sm-9">
                                                                                                    <asp:Label ID="LblOutoblmawb" Style="text-transform: uppercase" runat="server" Width="80%" Text="" Font-Size="Medium" Font-Bold="true"></asp:Label>
                                                                                                    <%--<asp:TextBox autocomplete="off"  runat="server" Enabled="false" Width="100" type="text" ID="TextBox25" TabIndex="1"></asp:TextBox>--%>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="col-sm-6">
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                    
                                                                                                  Outward  HBL/HAWB
                                                                                                </label>
                                                                                                <div class="col-sm-9">
                                                                                                    <asp:Label ID="Lblouthblhawb"  Style="text-transform: uppercase" runat="server" Width="80%" Font-Size="Medium" Font-Bold="true"></asp:Label>
                                                                                                    <%--<asp:TextBox autocomplete="off"  runat="server" Enabled="false" Width="80%" type="text" ID="TextBox26" TabIndex="1"></asp:TextBox>--%>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="col-sm-6">
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                    OBL


                                                                                                </label>
                                                                                                <div class="col-sm-9">
                                                                                                    <asp:Label ID="lbloblval" Style="text-transform: uppercase" runat="server" Width="80%" Text="" Font-Size="Medium" Font-Bold="true"></asp:Label>
                                                                                                    <%--<asp:TextBox autocomplete="off"  runat="server" Enabled="false" Width="100" type="text" ID="TextBox25" TabIndex="1"></asp:TextBox>--%>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="col-sm-6">
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                    HBL
                                                                                                </label>
                                                                                                <div class="col-sm-9">
                                                                                                    <asp:Label ID="lblhblValue"  Style="text-transform: uppercase" runat="server" Width="80%" Font-Size="Medium" Font-Bold="true"></asp:Label>
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
                                                                                                    <asp:Label ID="lblnoofpack"  Style="text-transform: uppercase" runat="server" Width="80%" Font-Size="Medium" Font-Bold="true"></asp:Label>
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
                                                                                                    <asp:Label ID="lblgrossweight" Style="text-transform: uppercase" runat="server" Width="80%" Text="" Font-Size="Medium" Font-Bold="true"></asp:Label>
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
                                                                                                    <asp:Label ID="lblinvoiceAmt" Style="text-transform: uppercase" runat="server" Width="80%" Font-Size="Medium" Font-Bold="true"></asp:Label>
                                                                                                    <%--<asp:TextBox autocomplete="off"  runat="server" Enabled="false" Width="100" type="text" ID="TextBox28" TabIndex="1"></asp:TextBox>--%>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="col-sm-6">
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                                    Total Item GST

                                                                                                </label>
                                                                                                <div class="col-sm-9">
                                                                                                    <asp:Label ID="lblTotItemGst" Style="text-transform: uppercase" runat="server" Width="80%" Font-Size="Medium" Font-Bold="true"></asp:Label>
                                                                                                    <%--<asp:TextBox autocomplete="off"  runat="server" Enabled="false" Width="100" type="text" ID="TextBox31" TabIndex="1"></asp:TextBox>--%>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="col-sm-12" id="DeclInd" runat="server" visible="false">
                                                                                            <div class="alert alert-danger">
                                                                                                <asp:CheckBox ID="chkalrt" runat="server" Checked="false" TabIndex="303" />
                                                                                                <strong></strong>I/We declare that all particulars in this application are true and correct
                                                                                            </div>

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

                                                                        <br />
                                                                        <div class="col-sm-12">
                                                                           

                                                                            <cc1:ModalPopupExtender ID="ModalPopupOBL" runat="server" PopupControlID="Panelobl" TargetControlID="Button6"
                                                                                OkControlID="Button6" BackgroundCssClass="modalBackground">
                                                                            </cc1:ModalPopupExtender>


                                                                            <asp:Panel ID="Panelobl" runat="server" CssClass="modalPopup" Style="display: none;">
                                                                                <div class="header">
                                                                                </div>
                                                                                <div class="body">
                                                                                    <asp:Label ID="POPOBLERR" runat="server" ForeColor="Red" Font-Size="Large"> </asp:Label>
                                                                                    <br />
                                                                                    <asp:Label ID="Label2" runat="server" Text="Continue Please Choose Yes !!!" ForeColor="Red" Font-Size="Large"> </asp:Label>
                                                                                    <br />
                                                                                    <asp:Button ID="BtnContinue" runat="server" OnClick="BtnYes_Click" Text="Continue" />
                                                                                    <asp:Button ID="BtnCancel" runat="server" OnClick="BtnNo_Click" Text="Cancel" />



                                                                                </div>
                                                                                <div class="footer" align="right">

                                                                                    <asp:Button ID="Button6" runat="server" Text="Close" CssClass="yes" />
                                                                                </div>

                                                                            </asp:Panel>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </ContentTemplate>
                                                        </cc1:TabPanel>
                                                    </div>
                                                    <%-- <div role="tabpanel" class="tab-pane fade" id="Amend">--%>
                                                    <cc1:TabPanel ID="Amend" runat="server" Visible="false" HeaderText="Amend">
                                                        <ContentTemplate>
                                                            <asp:UpdatePanel ID="upinnonamend" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <div class="row">
                                                                        <div class="col-sm-12">
                                                                            <div class="row Borderdiv" style="width: 100%">Update Information</div>
                                                                            <div class="row">
                                                                                <div class="col-sm-6">
                                                                                    <p>Amendment Count</p>
                                                                                    <asp:TextBox autocomplete="off"  runat="server" Width="300" type="text" Text="1" Enabled="false" ID="txtamoundcount" TabIndex="308"></asp:TextBox>
                                                                                    <br />
                                                                                    <p>Update Indicator</p>
                                                                                    <asp:TextBox autocomplete="off"  Text="AME" Enabled="false" runat="server" Width="300" type="text" ID="txtupdateindicator" TabIndex="309"></asp:TextBox>
                                                                                    <br />
                                                                                </div>
                                                                                <div class="col-sm-6">
                                                                                    <p>Permit Number</p>
                                                                                    <asp:TextBox autocomplete="off"  runat="server" Width="300" type="text" ID="txtamendpermit" TabIndex="310"></asp:TextBox>
                                                                                    <br />
                                                                                    <p>Replacement Permit Number</p>
                                                                                    <asp:TextBox autocomplete="off"  runat="server" Width="300" type="text" ID="txtreplacepermit" TabIndex="311"></asp:TextBox>
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
                                                                            <asp:TextBox autocomplete="off"  runat="server" TextMode="MultiLine" Width="100%" type="text" ID="txtdescreason" TabIndex="312"></asp:TextBox>
                                                                            <br />
                                                                            <asp:CheckBox ID="ChkPermitvalEx" runat="server" Text="Permit Validity Extension" />
                                                                            <br />
                                                                            <p>Extend Import Period (Reason for Extension of validity for Temporary / Exhibit Cargoes)</p>
                                                                            <asp:TextBox autocomplete="off"  runat="server" TextMode="MultiLine" Width="100%" type="text" ID="txtvalidity" TabIndex="313"></asp:TextBox>
                                                                            <br />
                                                                            <br />
                                                                            <div class="row Borderdiv" style="width: 100%">Declaration Indicator</div>
                                                                            <div class="alert alert-danger" id="AmendInd" runat="server" visible="false">
                                                                                <asp:CheckBox ID="chkdec" runat="server" Checked="false" TabIndex="314" />
                                                                                <strong></strong>I/We declare that all particulars in this application are true and correct
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                    <center>
                                                                     <div class="btn-group btn-group-lg" id="Amendbtn" runat="server" visible="false">
                                                                            <asp:Button ID="btnprevamend" CssClass="nn" runat="server" class="btn btn-info btn-lg" OnClick="btnprevamend_Click" Text="Previous" TabIndex="315" />
                                                                            <asp:Button ID="btnsaveamend" CssClass="nn" runat="server" class="btn btn-info btn-lg" OnClick="btnsaveamend_Click" Text="Save" TabIndex="316" />
                                                                            <asp:Button ID="btnresetamend" CssClass="nn" runat="server" class="btn btn-info btn-lg" OnClick="btnresetamend_Click" Text="Reset" TabIndex="317" />
                                                                            <asp:Button ID="btnnextamend" CssClass="nn" runat="server" class="btn btn-info btn-lg" OnClick="btnnextamend_Click" Text="Next" TabIndex="318"  />

                                                                        </div>

                                                                   </center>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                            <%--  <a href="#Summary" data-toggle="tab" title="Previous">PREVIOUS</a>
          <a href="#Cancel" data-toggle="tab" title="Next">NEXT</a>--%>
                                                        </ContentTemplate>
                                                    </cc1:TabPanel>
                                                    <%--</div>--%>

                                                    <%-- <div role="tabpanel" class="tab-pane fade " id="Cancel">--%>

                                                    <cc1:TabPanel ID="Cancel" runat="server" Visible="false" HeaderText="cancel">
                                                        <ContentTemplate>
                                                            <asp:UpdatePanel ID="upinnoncancel" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>


                                                                    <div class="row">
                                                                        <div class="col-sm-12">
                                                                            <div class="row Borderdiv" style="width: 100%">Update Information</div>
                                                                            <div class="row">
                                                                                <div class="col-sm-6">
                                                                                    <p>Update Indicator</p>
                                                                                    <asp:TextBox autocomplete="off"  runat="server" Text="CNL" Enabled="false" Width="300" type="text" ID="txtupdateInd" TabIndex="319"></asp:TextBox>
                                                                                    <br />


                                                                                </div>
                                                                                <div class="col-sm-6">
                                                                                    <p>Permit Number</p>
                                                                                    <asp:TextBox autocomplete="off"  runat="server" Width="300" type="text" ID="txtcanPermit" TabIndex="320"></asp:TextBox>
                                                                                    <br />
                                                                                    <p>Replacement Permit Number</p>
                                                                                    <asp:TextBox autocomplete="off"  runat="server" Width="300" type="text" ID="txtcanrepPermit" TabIndex="321"></asp:TextBox>
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
                                                                            <asp:DropDownList CssClass="drop" ID="DrpReasonCancel" Width="300" TabIndex="322" Height="26" runat="server"></asp:DropDownList>
                                                                        </div>
                                                                        <div class="col-sm-6">
                                                                            <p>Description For Reason</p>
                                                                            <asp:TextBox autocomplete="off"  runat="server" TextMode="MultiLine" Width="100%" type="text" ID="txtdesReason" TabIndex="323"></asp:TextBox>
                                                                            <br />
                                                                        </div>
                                                                    </div>
                                                                    <br />
                                                                    <div class="row">
                                                                        <div class="col-sm-12" id="Div7" runat="server">

                                                                            <div class="row">


                                                                                <div class="col-sm-12">
                                                                                    <div class="row Borderdiv" style="width: 100%">
                                                                                        Referance Document
                                                                                    </div>

                                                                                    <div class="row">
                                                                                        <div class="col-sm-5">
                                                                                            <p>Document Type</p>
                                                                                            <asp:DropDownList CssClass="drop" ID="DrpDocumenttype" BackColor="ActiveCaption" Width="250" Height="32" AppendDataBoundItems="true" TabIndex="324" runat="server">
                                                                                            </asp:DropDownList><br />
                                                                                            <asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator92" runat="server" ControlToValidate="DrpDocumenttype" InitialValue="0" ErrorMessage="Header --> Doc Type" ValidationGroup="Validationbtn"></asp:RequiredFieldValidator>
                                                                                        </div>
                                                                                        <div class="col-sm-5">
                                                                                            <p>Uplaod Document</p>
                                                                                            <asp:FileUpload ID="FileUpload2" BackColor="ActiveCaption" runat="server" TabIndex="325" class="btn" AllowMultiple="true" />
                                                                                            <asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator95" runat="server" ControlToValidate="FileUpload2" ErrorMessage="Header -->Upload Doc" ValidationGroup="Validationbtn"></asp:RequiredFieldValidator>
                                                                                        </div>
                                                                                        <div class="col-sm-2">
                                                                                            <p>Uplaod</p>
                                                                                            <asp:Button runat="server" ID="BtnCancelUp" ValidationGroup="Validationbtn" TabIndex="326" class="btn btn-success" Text="Upload" OnClick="BtnCancelUp_Click" />

                                                                                        </div>
                                                                                    </div>


                                                                                    <hr />
                                                                                    <asp:GridView ID="GridCancelDoc" PageSize="5" OnRowDeleting="GridCancelDoc_RowDeleting" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="GridCancelDoc_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                                                        <Columns>
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
                                                                                    <asp:TextBox autocomplete="off"  ID="TextBox15" Width="265" runat="server" TabIndex="327" type="text"></asp:TextBox>

                                                                                    <br />
                                                                                </div>
                                                                                <div class="col-sm-4">
                                                                                    <p>RECIPIENTS 2</p>
                                                                                    <asp:TextBox autocomplete="off"  ID="TextBox16" Width="265" runat="server" TabIndex="328" type="text"></asp:TextBox>

                                                                                    <br />
                                                                                </div>
                                                                                <div class="col-sm-4">
                                                                                    <p>RECIPIENTS 3</p>
                                                                                    <asp:TextBox autocomplete="off"  ID="TextBox17" Width="265" runat="server" TabIndex="329" type="text"></asp:TextBox>

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
                                                                                <asp:CheckBox ID="CheckBox4" runat="server" Checked="false" TabIndex="330" />
                                                                                <strong></strong>I/We declare that all particulars in this application are true and correct
                                                                            </div>

                                                                        </div>
                                                                    </div>
                                                                    <center>
                                                                       <div class="btn-group btn-group-lg" id="CancelBtn" runat="server" visible="false">
                                                                            <asp:Button ID="btnprevcancel" CssClass="nn" runat="server" class="btn btn-info btn-lg" OnClick="btnprevcancel_Click" Text="Previous" TabIndex="331"  />
                                                                            <asp:Button ID="btnsavecancel" CssClass="nn" runat="server" class="btn btn-info btn-lg" OnClick="btnsavecancel_Click" Text="Save" TabIndex="332"  />
                                                                            <asp:Button ID="btnresetcancel" CssClass="nn" runat="server" class="btn btn-info btn-lg" OnClick="btnresetcancel_Click" Text="Reset" TabIndex="333"  />
                                                                            <asp:Button ID="btnnextcancel" CssClass="nn" runat="server" class="btn btn-info btn-lg" OnClick="btnnextcancel_Click" Text="Next" TabIndex="334" />

                                                                        </div>
                                                                 </center>
                                                                    <%--<a href="#Amend" data-toggle="tab" title="Previous">PREVIOUS</a>--%>
                                                                    <%--<a href="#Cancel" data-toggle="tab" title="Next">NEXT</a>--%>
                                                                </ContentTemplate>

                                                                <Triggers>
                                                                    <asp:PostBackTrigger ControlID="BtnCancelUp" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </ContentTemplate>
                                                    </cc1:TabPanel>

                                                    <%-- </div>  --%>
                                                </cc1:TabContainer>
                                                <%-- </div>--%>
                                            </div>
                                        </div>
                                   

                    </div>






                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="BtnPrintCIF" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
