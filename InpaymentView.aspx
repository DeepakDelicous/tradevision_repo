<%@ Page Title="" ClientIDMode="AutoID" Language="C#" MasterPageFile="~/Home.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="InpaymentView.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="RET.InpaymentView" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script>
        function myFunction() {

            $("#inpayment").css('color', 'White');
          
            $("#inpayment").css('background-color', 'Black');
        }
    </script>
  
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
       <!--
    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode != 46 && charCode > 31
          && (charCode < 48 || charCode > 57))
            return false;

        return true;
    }

    //-->

    function ConfirmDelete() {

        var count = document.getElementById("<%=hfCount.ClientID %>").value;

        var gv = document.getElementById("<%=AddItemGrid.ClientID%>");

        var chk = gv.getElementsByTagName("input");

        for (var i = 0; i < chk.length; i++) {

            if (chk[i].checked && chk[i].id.indexOf("chkAll") == -1) {

                count++;

            }

        }

        if (count == 0) {

            alert("No records to delete.");

            return false;

        }

        else {

            return confirm("Do you want to delete " + count + " records.");

        }

    }
    $('.nav-tabs a:first').tab('show')
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






    function checkPress(e) {



        var key = window.event ? e.keyCode : e.which;
        // alert(key);

        if (key == 32) {

            $('.myTab a[data-toggle="tab" href="#' + Party + '"]').tab('show');

        }
    }



        function openTab(tabId) {
            var tabContainer = $find("<%= TabContainer1.ClientID %>");
        tabContainer.set_activeTabIndex(tabId - 1);
    }





    //Validation Function


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
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
        <ProgressTemplate>
            <div class="overlay">
                <div style="z-index: 1000; margin-top: 300px; opacity: 1; -moz-opacity: 1;">
                    <center>
<img alt="" src="Loader.gif" width="100" height="100" /></center>
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="updatepanel1" runat="server" UpdateMode="Conditional">
        <Triggers>
        <asp:PostBackTrigger ControlID="BtnPrintCIF" />
    </Triggers>
        <ContentTemplate>

            <br />
             <div class="container" style="width: 95%;">
            <div class="row top-pad text-center" style="margin-top: -17px;">
               <%-- <div class="col-md-12">
                    <ol class="breadcrumb">
                        <li class="active"><i class="fa fa-dashboard"></i>&nbsp;&nbsp;Inpayment</li>

                    </ol>
                </div>--%>
                <div class="col-lg-12" runat="server" visible="false">
                    

                                                                                

                                                                                   
                    <div class="btn-group">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="Validation" />
                        <asp:Button ValidationGroup="Validation" ID="BtnSaveDraft"  class="btn1 btn-primary "  Visible="false" runat="server" OnClientClick="$('li:eq(2)', $('.nav-tabs')).tab('show')" OnClick="BtnSaveDraft_Click" Text="Save As Draft" />

                      
                        <button id="Button1" type="button"  class="btn1 btn-primary "  runat="server" visible="false">Sent</button>
                    </div>




                    <div class="btn-group">
                        <button id="Button2" type="button" class="btn1 btn-primary" runat="server" visible="false">Print Status</button>
                        <button id="Button3" type="button" class="btn1 btn-primary" runat="server" visible="false">Print Draft CCP</button>
                        <asp:Button ID="BtnPrintCIF" runat="server" Visible="false" Text="Print CIF" class="btn1 btn-primary" OnClick="BtnPrintCIF_Click" />

                    </div>
                  <div class="btn-group pull-right">
                        <asp:Button ID="BtnExit" runat="server" class="btn1 btn-danger" OnClick="BtnExit_Click" Text="Exit Form" />



                    </div>


                </div>


            </div>

           

                <asp:UpdatePanel ID="updatepanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>


                        <div class="row">


                            <div class="row">
                                <div class="col-md-12 col-lg-12 col-sm-12">
                                </div>

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
                                                <div class="board-inner ">
                                                    <%--  <div>--%>


                                                    <cc1:TabContainer ID="TabContainer1" AutoPostBack="true" runat="server" ActiveTabIndex="0" CssClass="Tab"  OnActiveTabChanged="TabContainer1_ActiveTabChanged" OnLoad="TabContainer1_ActiveTabChanged" >

                                                        <cc1:TabPanel ID="Header" CssClass="ajax__tab_header" runat="server" HeaderText="Header"  >

                                                            <ContentTemplate  >
                                                                <asp:UpdatePanel ID="upinheader" runat="server" UpdateMode="Conditional" >
                                                                    <ContentTemplate>
                                                                        <div class="row">


                                                                            <div class="col-sm-6">
                                                                                <br>
                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail"  class="col-sm-3 col-form-label">Message Type
                                                                                    </label>
                                                                                    <div class="col-sm-9">
                                                                                      <asp:TextBox autocomplete="off"  ID="TxtMsgType" Text="IPTDEC" Enabled="false" runat="server" type="text" TabIndex="1"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail"  class="col-sm-3 col-form-label">Declaration Type

                                                                                    </label>
                                                                                    <div class="col-sm-9">
                                                                                        
                                                                                        <asp:DropDownList ID="DrpDecType" CssClass="drop" OnSelectedIndexChanged="DrpDecType_SelectedIndexChanged" AutoPostBack="true" BackColor="#e8f0fe" Height="28" AppendDataBoundItems="true" TabIndex="2" runat="server">
                                                                                        </asp:DropDownList>

                                                                                    </div>
                                                                                </div>
                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail"  class="col-sm-3 col-form-label">
                                                                                        Prev Permit No

                                                                                    </label>
                                                                                    <div class="col-sm-9">
                                                                                        <asp:TextBox autocomplete="off"  ID="TxtPrevPerNO" MaxLength="35" CssClass="upper-case" runat="server" type="text" TabIndex="3"></asp:TextBox>

                                                                                    </div>
                                                                                </div>
                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail"  class="col-sm-3 col-form-label">
                                                                                        Cargo Pack Type

                                                                                    </label>
                                                                                    <div class="col-sm-9">
                                                                                        <asp:DropDownList ID="DrpCargoPackType" CssClass="drop" BackColor="#e8f0fe" Height="28" OnSelectedIndexChanged="DrpCargoPackType_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true" TabIndex="4" runat="server">
                                                                                        </asp:DropDownList>

                                                                                    </div>
                                                                                </div>

                                                                                <div class="form-group row" id="inwared" runat="server">
                                                                                    <label for="staticEmail"  class="col-sm-3 col-form-label">
                                                                                        Inward Trans Mode

                                                                                    </label>
                                                                                    <div class="col-sm-9">
                                                                                       <asp:DropDownList ID="DrpInwardtrasMode" CssClass="drop" BackColor="#e8f0fe" OnSelectedIndexChanged="DrpInwardtrasMode_SelectedIndexChanged" AutoPostBack="true" Height="28" AppendDataBoundItems="true" TabIndex="5" runat="server">
                                                                                        </asp:DropDownList>

                                                                                    </div>
                                                                                </div>

                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail"  class="col-sm-3 col-form-label">
                                                                                        BG Indicator

    

                                                                                    </label>
                                                                                    <div class="col-sm-9">
                                                                                        
                                                                                        <asp:DropDownList ID="DrpBGIndicator" CssClass="drop" Height="28" AppendDataBoundItems="true" TabIndex="6" runat="server">
                                                                                        </asp:DropDownList>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail"  class="col-sm-3 col-form-label">
                                                                                        override Ex: Rate

    

                                                                                    </label>
                                                                                    <div class="col-sm-9">
                                                                                        <asp:CheckBox ID="ChkOverrExgRate" Width="265" AutoPostBack="true" OnCheckedChanged="ChkOverrExgRate_CheckedChanged" runat="server" TabIndex="7" Style="text-transform: lowercase" />
                                                                                    </div>
                                                                                </div>

                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail"  class="col-sm-3 col-form-label">
                                                                                       Supply indicator

    

                                                                                    </label>
                                                                                    <div class="col-sm-9">
                                                                                       <asp:CheckBox ID="ChkSupplyIndicator" Width="265" runat="server" TabIndex="8" Style="text-transform: lowercase" />
                                                                                    </div>
                                                                                </div>

                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail"  class="col-sm-3 col-form-label">
                                                                                        Ref Document

    

                                                                                    </label>
                                                                                    <div class="col-sm-9">
                                                                                        <asp:CheckBox ID="ChkRefDoc" Width="265" OnCheckedChanged="ChkRefDoc_CheckedChanged" AppendDataBoundItems="true" AutoPostBack="true" runat="server" TabIndex="9" Style="text-transform: lowercase" />
                                                                                    </div>
                                                                                </div>
                                                                            </div>


                                                                            <div class="col-sm-6">


                                                                                <div class="form-group row">
                                                                                    <br />
                                                                                    <label for="staticEmail"  class="col-sm-3 col-form-label">Mailbox ID</label>
                                                                                    <div class="col-sm-9">
                                                                                        <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe" Text="" Enabled="false" type="text" ID="TxtTradeMailID" Style="text-transform: uppercase"></asp:TextBox>

                                                                                    </div>
                                                                                </div>
                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail"  class="col-sm-3 col-form-label">Declarant Name</label>
                                                                                    <div class="col-sm-9">
                                                                                        <asp:TextBox autocomplete="off"  ID="TxtDecName" BackColor="#e8f0fe" Text="" Enabled="false" runat="server" type="text" Style="text-transform: uppercase"></asp:TextBox>

                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="None" ControlToValidate="TxtDecName" ValidationExpression="[a-zA-Z ]*$" ErrorMessage="Enter a valid Name" ValidationGroup="Validation" />
                                                                                    </div>
                                                                                </div>
                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail"  class="col-sm-3 col-form-label">Declaration Code</label>
                                                                                    <div class="col-sm-9">
                                                                                        <asp:TextBox autocomplete="off"  ID="TxtDecCode" BackColor="#e8f0fe" Text="" Enabled="false" runat="server" type="text" Style="text-transform: uppercase"></asp:TextBox>

                                                                                    </div>
                                                                                </div>
                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail"  class="col-sm-3 col-form-label">Declarant Tel</label>
                                                                                    <div class="col-sm-9">
                                                                                        <asp:TextBox autocomplete="off"  ID="TxtDecTelephone" onkeypress="return onlyNumbers(event)" BackColor="#e8f0fe" Text="" runat="server" type="text" Style="text-transform: uppercase"></asp:TextBox>

                                                                                        <asp:RegularExpressionValidator ID="regPhone" runat="server" Display="None" ControlToValidate="TxtDecTelephone" ValidationExpression="[0-9]{10}" ErrorMessage="Enter a valid phone number" ValidationGroup="Validation" />
                                                                                    </div>
                                                                                </div>
                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail"  class="col-sm-3 col-form-label">CR UEI No</label>
                                                                                    <div class="col-sm-9">
                                                                                        <asp:TextBox autocomplete="off"  ID="TxtCRUEINO" BackColor="#e8f0fe" Text="" Enabled="false" runat="server" type="text" Style="text-transform: uppercase"></asp:TextBox>

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
                                                                                            <label for="staticEmail"  class="col-sm-3 col-form-label">RECIPIENTS</label>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:TextBox autocomplete="off"  ID="TxtRECPT1" Width="265" runat="server" TabIndex="18" type="text" Style="text-transform: uppercase"></asp:TextBox>

                                                                                            </div>
                                                                                        </div>

                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail"  class="col-sm-3 col-form-label">RECIPIENTS 2</label>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:TextBox autocomplete="off"  ID="TxtRECPT2" Width="265" runat="server" TabIndex="19" type="text" Style="text-transform: uppercase"></asp:TextBox>

                                                                                            </div>
                                                                                        </div>


                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail"  class="col-sm-3 col-form-label">RECIPIENTS 3</label>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:TextBox autocomplete="off"  ID="TxtRECPT3" Width="265" runat="server" onkeypress="return isNumber(event)" TabIndex="20" type="text" Style="text-transform: uppercase"></asp:TextBox>

                                                                                            </div>
                                                                                        </div>




                                                                                    </div>
                                                                                </div>

                                                                                <%-- //ref doc--%>
                                                                            </div>


                                                                        </div>
                                                                        <div class="row">

                                                                            <div class="col-sm-12" id="Document" runat="server">
                                                                                <div class="col-sm-6">



                                                                                    <div class="row">
                                                                                        <div class="col-sm-12">

                                                                                            <div class="row Borderdiv" style="width: 100%">
                                                                                                License
                                                                                            </div>
                                                                                            <br />
                                                                                            <div class="row">
                                                                                                <div class="col-sm-6">
                                                                                                    <asp:TextBox autocomplete="off"  ID="TxtLicense1" Width="250" runat="server" TabIndex="10" type="text" Style="text-transform: uppercase"></asp:TextBox><br />
                                                                                                    <br />
                                                                                                    <asp:TextBox autocomplete="off"  ID="TxtLicense2" Width="250" runat="server" TabIndex="11" type="text" Style="text-transform: uppercase"></asp:TextBox><br />
                                                                                                    <br />
                                                                                                    <asp:TextBox autocomplete="off"  ID="TxtLicense3" Width="250" runat="server" TabIndex="12" type="text" Style="text-transform: uppercase"></asp:TextBox><br />
                                                                                                    <br />
                                                                                                </div>
                                                                                                <div class="col-sm-6">
                                                                                                    <asp:TextBox autocomplete="off"  ID="TxtLicense4" Width="250" runat="server" TabIndex="13" type="text" Style="text-transform: uppercase"></asp:TextBox><br />
                                                                                                    <br />
                                                                                                    <asp:TextBox autocomplete="off"  ID="TxtLicense5" Width="250" runat="server" TabIndex="14" type="text" Style="text-transform: uppercase"></asp:TextBox><br />
                                                                                                    <br />
                                                                                                </div>
                                                                                            </div>

                                                                                        </div>
                                                                                    </div>


                                                                                    <div class="row">


                                                                                        <br />


                                                                                    </div>

                                                                                </div>


                                                                                <div class="col-sm-6">
                                                                                    <asp:UpdatePanel ID="updoc" runat="server" UpdateMode="Conditional">
                                                                                        <ContentTemplate>


                                                                                            <div class="col-sm-12">
                                                                                                <div class="row Borderdiv" style="width: 100%">
                                                                                                    Attachment Document
                                                                                                </div>
                                                                                                <br />
                                                                                                <div class="row">
                                                                                                    <div class="col-sm-5">
                                                                                                        <p>Document Type</p>
                                                                                                        <asp:DropDownList ID="DrpDocType" CssClass="drop" BackColor="#e8f0fe" Width="200" Height="32" AppendDataBoundItems="true" TabIndex="15" runat="server">
                                                                                                        </asp:DropDownList><br />

                                                                                                    </div>
                                                                                                    <div class="col-sm-5">
                                                                                                        <p>ATTACHMENT</p>
                                                                                                        <asp:FileUpload ID="FileUpload1" BackColor="#e8f0fe" TabIndex="16" runat="server"  AllowMultiple="true" />

                                                                                                    </div>
                                                                                                    <div class="col-sm-2">
                                                                                                        
                                                                                                        <asp:Button runat="server" ID="Btn_Upload" TabIndex="17" class="btn btn-success" Text="Upload" OnClick="Btn_Upload_Click" />

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
                                                                                        </ContentTemplate>
                                                                                        <Triggers>
                                                                                            <asp:PostBackTrigger ControlID="Btn_Upload" />
                                                                                        </Triggers>
                                                                                    </asp:UpdatePanel>




                                                                                </div>
                                                                            </div>
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
                                                                                                <asp:GridView HeaderStyle-Font-Size="X-Small" ShowHeaderWhenEmpty="true"   EmptyDataText="No Records found" PageSize="10" ID="GridCondition" Width="100%" FooterStyle-CssClass="bg-primary text-white"  HeaderStyle-CssClass="bg-primary text-white" RowStyle-CssClass="rows" Font-Bold ="true" PagerStyle-CssClass="pager"  AllowPaging="True" HeaderStyle-ForeColor="DarkBlue"  OnPageIndexChanging="GridCondition_PageIndexChanging"   CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="true">
                                                                                                 
                                                                                                </asp:GridView>
                                                                            </div>
                                                                        </div>

                                                                        <div class="row">
                                                                            <div class="col-sm-3">
                                                                            </div>
                                                                            <div class="col-sm-6">

                                                                                <div class="row">
    <div class="col-sm-12">
        <center>
            <div id="Div1" runat="server" class="flex justify-between gap-4 md:flex-nowrap flex-wrap mt-6">
                <asp:Button ID="btnsaveheader" runat="server" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" OnClick="btnsaveheader_Click" Text="Save" TabIndex="21" />
                <asp:Button ID="btnresetheader" runat="server" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" OnClick="btnresetheader_Click" Text="Reset" TabIndex="22" />
                <asp:Button ID="btnnextheader" runat="server" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" OnClick="btnnextheader_Click" Text="Next" TabIndex="23" />
            </div>
        </center>
    </div>
</div>

                                                                                <div class="col-sm-3">
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <%-- <ul class="pager">
                                                                    <%-- <li class="previous"><a href="#Header">Previous</a></li>--%>
                                                                        <%-- <li class="next"><a href="Party"  onclick="javascript:MoveTab('1')" tabindex ="20" title="Next">Next</a></li>
                                                                </ul>--%>
                                                                    </ContentTemplate>


                                                                </asp:UpdatePanel>

                                                            </ContentTemplate>
                                                        </cc1:TabPanel>
                                                        <%--</div>--%>

                                                        <%-- <div role="tabpanel" class="tab-pane fade" aria-labelledby="party-tab" id="Party">--%>
                                                        <cc1:TabPanel ID="Party" runat="server" CssClass="nn" HeaderText="Party" >
                                                            <ContentTemplate>
                                                                <asp:UpdatePanel ID="upinparty" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>

                                                                        <br />

                                                                        <div class="row">
                                                                            <div class="col-sm-4">
                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail" class="col-sm-8 col-form-label">


                                                                                        <div class="row">
                                                                                            <div class="col-sm-8" style="font-family: 'Times New Roman'">
                                                                                                Declarant Company
                                                                                            </div>
                                                                                            <div class="col-sm-4">

                                                                                                <asp:ImageButton ID="btnShow1" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />

                                                                                                <asp:Button ID="DECPLUS" runat="server" CssClass="plusbtn" BackColor="Transparent" BorderWidth="0px" Font-Size="Small" ValidationGroup="PartyDec" OnClick="DECPLUS_Click" Text="+" />
                                                                                            </div>
                                                                                        </div>



                                                                                        <%-- <asp:Button ID="Button4"  runat="server"   OnClick="Button4_Click" Text="Search" />--%>
                                                                                        <%--<asp:Label Text="" ID="LblErr" runat="server" ForeColor="Red" />--%>

                                                                                        <cc1:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlPopup" TargetControlID="btnShow1"
                                                                                            OkControlID="btnYes" CancelControlID="btnNo" BackgroundCssClass="modalBackground">
                                                                                        </cc1:ModalPopupExtender>


                                                                                        <asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                            <%--<asp:UpdatePanel  ID="decgrid" runat ="server" UpdateMode ="Conditional">
                                                                            <ContentTemplate>  --%>
                                                                                            <div class="header" style="font-weight: bold; font-family: 'Arial Rounded MT'; font-size: medium">
                                                                                                Declarant Company Search
                                                                                            </div>
                                                                                            <div class="body">
                                                                                                <asp:UpdatePanel ID="upindec" runat="server" UpdateMode="Conditional">
                                                                                                    <ContentTemplate>
                                                                                                        <asp:TextBox autocomplete="off"  ID="DecSearch" OnTextChanged="DecSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                        <br />

                                                                                                        <%--<mani>--%>

                                                                                                        <%--<asp:UpdatePanel ID="UpdatePanelDCS" runat="server"  ChildrenAsTriggers="true" UpdateMode="Always">

                                                       
                                                           
                                                             <ContentTemplate>--%>


                                                                                                        <asp:GridView ID="DECCOMPSearGRID" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="DECCOMPSearGRID_PageIndexChanging" OnRowCreated="DECCOMPSearGRID_RowCreated" OnRowDataBound="DECCOMPSearGRID_RowDataBound" OnSelectedIndexChanged="DECCOMPSearGRID_SelectedIndexChanged" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false" OnRowCommand="DECCOMPSearGRID_select">
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
                                                                                                                        <%--<asp:UpdatePanel ID="gridUpdatePanel" runat="server" UpdateMode ="Conditional" ChildrenAsTriggers="false">
                                                                            
                                                                        <ContentTemplate><br /> --%>
                                                                                                                        <%--  <asp:LinkButton ID="lnkRequestID" runat="server" CommandArgument='<%# Eval("Id") %>' CommandName ="lnkRequestID"  >Select </asp:LinkButton>
                                                                       <%--  <asp:LinkButton ID="lnkFull" runat="server"  OnClick="FullPostBack">Select </asp:LinkButton>--%>
                                                                                                                        <asp:LinkButton ID="lnkRequestID" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="lnkRequestID_Command">Select </asp:LinkButton>
                                                                                                                        <%--</ContentTemplate>                
                                                                      </asp:UpdatePanel>           
                                                                                                                        --%>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                            </Columns>
                                                                                                        </asp:GridView>

                                                                                                    </ContentTemplate>
                                                                                                    <%-- <Triggers>
                                                                                                        <asp:PostBackTrigger ControlID="DECCOMPSearGRID" />

                                                                                                    </Triggers>--%>
                                                                                                </asp:UpdatePanel>

                                                                                                <%--<mani>--%>
                                                                                            </div>
                                                                                            <div class="footer" align="right">
                                                                                                <asp:Button ID="btnYes" runat="server" Text="Yes" CssClass="yes" />
                                                                                                <asp:Button ID="btnNo" runat="server" Text="No" CssClass="no" />
                                                                                            </div>
                                                                                            <%-- </ContentTemplate>
        
         <Triggers>
             <asp:PostBackTrigger ControlID="DECCOMPSearGRID" />
         </Triggers>
                                                                        </asp:UpdatePanel>--%>
                                                                                        </asp:Panel>

                                                                                        <%--<i class='fa fa-search' data-toggle="modal" data-target="#DECLARANTCOMPANYSearch"></i>--%>
                                                                                        <%--  <asp:Button ID="DECPLUS" runat="server" CssClass="plusbtn" TabIndex="25" ValidationGroup="party" OnClick="DECPLUS_Click" Visible="false" Text="+" />--%>
                                                                                    </label>
                                                                                    <div class="col-sm-4">
                                                                                        <asp:TextBox autocomplete="off"  runat="server" Width="100" type="text" OnTextChanged="TxtDecCompCode_TextChanged" placeholder="Code" AutoPostBack="true" ID="TxtDecCompCode" TabIndex="24" Style="text-transform: uppercase"></asp:TextBox>
                                                                                        <cc1:AutoCompleteExtender
                                                                                            ID="AutoCompleteExtender1"
                                                                                            runat="server"
                                                                                            CompletionInterval="100"
                                                                                            FirstRowSelected="true"
                                                                                            MinimumPrefixLength="1"
                                                                                            DelimiterCharacters="1"
                                                                                            ServiceMethod="GetListofCountries"
                                                                                            ServicePath="~/Inpayment.aspx"
                                                                                            Enabled="True"
                                                                                            CompletionListCssClass="ac_results"
                                                                                            CompletionListItemCssClass="listItem"
                                                                                            CompletionListHighlightedItemCssClass="itemHighlighted"
                                                                                            TargetControlID="TxtDecCompCode" />

                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-sm-2">
                                                                                <div class="form-group row">

                                                                                    <div class="col-sm-12">
                                                                                        <asp:TextBox autocomplete="off"  ID="TxtDecCompCRUEI" MaxLength="17" Width="170" placeholder="CRUEI" runat="server" Enabled="false" ValidationGroup="party" BackColor="#e8f0fe" TabIndex="25" type="text" Style="text-transform: uppercase"></asp:TextBox>

                                                                                        <br />
                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtDecCompCRUEI" ID="RegularExpressionValidator20" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="party"></asp:RegularExpressionValidator>
                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-sm-3">
                                                                                <div class="form-group row">

                                                                                    <div class="col-sm-12">
                                                                                        <asp:TextBox autocomplete="off"  ID="TxtDecCompName" MaxLength="50" placeholder="Name" Width="275" runat="server" Enabled="false" ValidationGroup="party" BackColor="#e8f0fe" TabIndex="26" type="text" Style="text-transform: uppercase"></asp:TextBox>

                                                                                        <br />
                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtDecCompName" ID="RegularExpressionValidator18" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="party"></asp:RegularExpressionValidator>


                                                                                        <br />
                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-sm-3">
                                                                                <div class="form-group row">

                                                                                    <div class="col-sm-12">
                                                                                        <asp:TextBox autocomplete="off"  ID="TxtDecCompName1" MaxLength="50" placeholder="Name1" ValidationGroup="party" Enabled="false" Width="275" runat="server" TabIndex="27" type="text" Style="text-transform: uppercase"></asp:TextBox>

                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtDecCompName1" ID="RegularExpressionValidator19" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="party"></asp:RegularExpressionValidator>
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
                                                                                        <cc1:AutoCompleteExtender
                                                                                            ID="Search_AutoCompleteExtender"
                                                                                            runat="server"
                                                                                            CompletionInterval="100"
                                                                                            MinimumPrefixLength="1"
                                                                                            DelimiterCharacters=""
                                                                                            FirstRowSelected="true"
                                                                                            ServiceMethod="GetImpcode"
                                                                                            ServicePath="Inpayment.aspx"
                                                                                            Enabled="True"
                                                                                            CompletionListCssClass="ac_results"
                                                                                            CompletionListItemCssClass="listItem"
                                                                                            CompletionListHighlightedItemCssClass="itemHighlighted"
                                                                                            TargetControlID="TxtImpCode" />

                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-sm-2">
                                                                                <div class="form-group row">

                                                                                    <div class="col-sm-12">
                                                                                        <asp:TextBox autocomplete="off"  ID="TxtImpCRUEI" placeholder="CRUEI" MaxLength="17" Width="170" runat="server" BackColor="#e8f0fe" TabIndex="29" type="text" Style="text-transform: uppercase"></asp:TextBox>

                                                                                        <br />
                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtImpCRUEI" ID="RegularExpressionValidator23" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="importer"></asp:RegularExpressionValidator>
                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-sm-3">
                                                                                <div class="form-group row">

                                                                                    <div class="col-sm-12">
                                                                                        <asp:TextBox autocomplete="off"  ID="TxtImpName" MaxLength="35" Placeholder="Name" Width="275" runat="server" ValidationGroup="importer" BackColor="#e8f0fe" TabIndex="30" type="text" Style="text-transform: uppercase"></asp:TextBox>

                                                                                        <br />
                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtImpName" ID="RegularExpressionValidator21" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="importer"></asp:RegularExpressionValidator>
                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-sm-3">
                                                                                <div class="form-group row">

                                                                                    <div class="col-sm-12">
                                                                                        <asp:TextBox autocomplete="off"  ID="TxtImpName1" MaxLength="35" placeholder="Name1" Width="275" ValidationGroup="importer" runat="server" TabIndex="31" type="text" Style="text-transform: uppercase"></asp:TextBox>
                                                                                        <br />
                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtImpName1" ID="RegularExpressionValidator22" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="importer"></asp:RegularExpressionValidator>
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

                                                                                                <asp:ImageButton ID="btninw1" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />

                                                                                                <asp:Button ID="InwardAdd" CssClass="plusbtn" BackColor="Transparent" BorderWidth="0px" Font-Size="Small" runat="server" ValidationGroup="Inward" OnClick="InwardAdd_Click" Text="+" />
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
                                                                                        <cc1:AutoCompleteExtender
                                                                                            ID="AutoCompleteExtender2"
                                                                                            runat="server"
                                                                                            FirstRowSelected="true"
                                                                                            CompletionInterval="100"
                                                                                            MinimumPrefixLength="1"
                                                                                            DelimiterCharacters=""
                                                                                            ServiceMethod="GetInwcode"
                                                                                            ServicePath="Inpayment.aspx"
                                                                                            Enabled="True"
                                                                                            CompletionListCssClass="ac_results"
                                                                                            CompletionListItemCssClass="listItem"
                                                                                            CompletionListHighlightedItemCssClass="itemHighlighted"
                                                                                            TargetControlID="InwardCode" />


                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-sm-2">
                                                                                <div class="form-group row">

                                                                                    <div class="col-sm-12">
                                                                                        <asp:TextBox autocomplete="off"  ID="InwardCRUEI" MaxLength="17" placeholder="CRUEI" Width="170"  runat="server" TabIndex="33" type="text" Style="text-transform: uppercase"></asp:TextBox>

                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-sm-3">
                                                                                <div class="form-group row">

                                                                                    <div class="col-sm-12">
                                                                                        <asp:TextBox autocomplete="off"  ID="InwardName" MaxLength="50" placeholder="name" Width="275"  runat="server" TabIndex="34" type="text" ValidationGroup="Inward" Style="text-transform: uppercase"></asp:TextBox>

                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="InwardName" ID="RegularExpressionValidator7" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="Inward"></asp:RegularExpressionValidator>
                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-sm-3">
                                                                                <div class="form-group row">

                                                                                    <div class="col-sm-12">
                                                                                        <asp:TextBox autocomplete="off"  ID="InwardName1" MaxLength="50" placeholder="name1" Width="275" runat="server" TabIndex="35" type="text" ValidationGroup="Inward" Style="text-transform: uppercase"></asp:TextBox>
                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="InwardName1" ID="RegularExpressionValidator8" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="Inward"></asp:RegularExpressionValidator>
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

                                                                                                <asp:ImageButton ID="btnfreight1" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />

                                                                                                <asp:Button ID="BtnFrieghtAdd" CssClass="plusbtn" BackColor="Transparent" BorderWidth="0px" Font-Size="Small" runat="server" ValidationGroup="freight" OnClick="BtnFrieghtAdd_Click" Text="+" />
                                                                                            </div>
                                                                                        </div>



                                                                                        <cc1:ModalPopupExtender ID="popupfreight" runat="server" PopupControlID="pnlfreight" TargetControlID="btnfreight1"
                                                                                            OkControlID="btnyesfreight" CancelControlID="btnnofreight" BackgroundCssClass="modalBackground">
                                                                                        </cc1:ModalPopupExtender>
                                                                                        <asp:Panel ID="pnlfreight" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                            <div class="header">
                                                                                                Freight Forwarder
                                                                                            </div>
                                                                                            <div class="body">
                                                                                                <asp:UpdatePanel ID="upfreightgrid" runat="server" UpdateMode="Conditional">

                                                                                                    <ContentTemplate>
                                                                                                        <asp:TextBox autocomplete="off"  ID="FrieghtSearch" OnTextChanged="FrieghtSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                        <br />
                                                                                                        <%--   <asp:UpdatePanel ID="UpdatePanelFrieghtSearch" runat="server"  UpdateMode="Always">

                                                        <ContentTemplate>--%>
                                                                                                        <asp:GridView ID="FrieghtGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnRowCommand="FrieghtGrid_RowCommand" OnRowDataBound="FrieghtGrid_RowDataBound" OnPageIndexChanging="FrieghtGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
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

                                                                                                        </div>
    <div class="footer" align="right">
        <asp:Button ID="btnyesfreight" runat="server" Text="Yes" CssClass="yes" />
        <asp:Button ID="btnnofreight" runat="server" Text="No" CssClass="no" />
                                                                                                    </ContentTemplate>
                                                                                                    <%--   <Triggers>
                                                                                                        <asp:PostBackTrigger ControlID="FrieghtGrid" />
                                                                                                    </Triggers>--%>
                                                                                                </asp:UpdatePanel>
                                                                                            </div>
                                                                                        </asp:Panel>


                                                                                    </label>
                                                                                    <div class="col-sm-4">
                                                                                        <asp:TextBox autocomplete="off"  runat="server" placeholder="Code" Width="100" OnTextChanged="FrieghtCode_TextChanged" AutoPostBack="true" type="text" ID="FrieghtCode" TabIndex="36" Style="text-transform: uppercase"></asp:TextBox>
                                                                                        <cc1:AutoCompleteExtender
                                                                                            ID="AutoCompleteExtender3"
                                                                                            runat="server"
                                                                                            CompletionInterval="10"
                                                                                            FirstRowSelected="true"
                                                                                            MinimumPrefixLength="1"
                                                                                            DelimiterCharacters=""
                                                                                            ServiceMethod="GetFrieght"
                                                                                            ServicePath="Inpayment.aspx"
                                                                                            Enabled="True"
                                                                                            CompletionListCssClass="ac_results"
                                                                                            CompletionListItemCssClass="listItem"
                                                                                            CompletionListHighlightedItemCssClass="itemHighlighted"
                                                                                            TargetControlID="FrieghtCode" />


                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-sm-2">
                                                                                <div class="form-group row">

                                                                                    <div class="col-sm-12">
                                                                                        <asp:TextBox autocomplete="off"  ID="FrieghtCRUEI" MaxLength="17" placeholder="CRUEI" Width="170" runat="server" ValidationGroup="freight" TabIndex="37" type="text" Style="text-transform: uppercase"></asp:TextBox>


                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="FrieghtCRUEI" ID="RegularExpressionValidator26" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17characters allowed." ValidationGroup="freight"></asp:RegularExpressionValidator>
                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-sm-3">
                                                                                <div class="form-group row">

                                                                                    <div class="col-sm-12">
                                                                                        <asp:TextBox autocomplete="off"  ID="FrieghtName" MaxLength="50" placeholder="name" Width="275" runat="server" TabIndex="38" type="text" ValidationGroup="freight" Style="text-transform: uppercase"></asp:TextBox>

                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="FrieghtName" ID="RegularExpressionValidator24" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="freight"></asp:RegularExpressionValidator>
                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-sm-3">
                                                                                <div class="form-group row">

                                                                                    <div class="col-sm-12">
                                                                                        <asp:TextBox autocomplete="off"  ID="FrieghtName1" MaxLength="50" placeholder="name1" Width="275" runat="server" TabIndex="39" ValidationGroup="freight" type="text" Style="text-transform: uppercase"></asp:TextBox>
                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="FrieghtName1" ID="RegularExpressionValidator25" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="freight"></asp:RegularExpressionValidator>
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
                                                                                                Claimant Party
                                                                                            </div>
                                                                                            <div class="col-sm-4">

                                                                                                <asp:ImageButton ID="btnclaimant1" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />

                                                                                                <asp:Button ID="ClaimantAdd" CssClass="plusbtn" BackColor="Transparent" BorderWidth="0px" Font-Size="Small" runat="server" ValidationGroup="CLAIMANT" OnClick="ClaimantAdd_Click" Text="+" />
                                                                                            </div>
                                                                                        </div>

                                                                                        <%--  &nbsp;&nbsp&nbsp;Claimant Party&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button TabIndex="45" ID="btnclaimant" runat="server" Text="Search" />--%>
                                                                                        <%--<i class='fa fa-search' data-toggle="modal" data-target="#Claimant"></i>--%>

                                                                                        <cc1:ModalPopupExtender ID="popupclaimant" runat="server" PopupControlID="pnlclaimant" TargetControlID="btnclaimant1"
                                                                                            OkControlID="btnyescl" CancelControlID="btnnocl" BackgroundCssClass="modalBackground">
                                                                                        </cc1:ModalPopupExtender>
                                                                                        <asp:Panel ID="pnlclaimant" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                            <div class="header">
                                                                                                Claimant Party
                                                                                            </div>
                                                                                            <div class="body">
                                                                                                <asp:UpdatePanel ID="upclaimantgrid" runat="server" UpdateMode="Conditional">

                                                                                                    <ContentTemplate>

                                                                                                        <asp:TextBox autocomplete="off"  ID="ClaimantSearch" OnTextChanged="ClaimantSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                        <br />


                                                                                                        <asp:GridView ID="ClaimantGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ClaimantGrid_PageIndexChanging" OnRowCommand="ClaimantGrid_RowCommand" OnRowDataBound="ClaimantGrid_RowDataBound" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
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
                                                                                                                <asp:TemplateField HeaderText="ClaimantID" SortExpression="Id">
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
                                                                                                        </div>
                                                                                            <div class="footer" align="right">
                                                                                                <asp:Button ID="btnyescl" runat="server" Text="Yes" CssClass="yes" />
                                                                                                <asp:Button ID="btnnocl" runat="server" Text="No" CssClass="no" />
                                                                                                    </ContentTemplate>
                                                                                                    <%-- <Triggers>
                                                                                                        <asp:PostBackTrigger ControlID="ClaimantGrid" />
                                                                                                    </Triggers>--%>
                                                                                                </asp:UpdatePanel>
                                                                                            </div>
                                                                                        </asp:Panel>


                                                                                    </label>
                                                                                    <div class="col-sm-4">
                                                                                        <asp:TextBox autocomplete="off"  runat="server" MaxLength="50" placeholder="Code" Width="100" ValidationGroup="CLAIMANT" OnTextChanged="ClaimantName_TextChanged" AutoPostBack="true" type="text" ID="ClaimantName" TabIndex="40" Style="text-transform: uppercase"></asp:TextBox>
                                                                                        <cc1:AutoCompleteExtender
                                                                                            ID="AutoCompleteExtender4"
                                                                                            runat="server"
                                                                                            CompletionInterval="100"
                                                                                            MinimumPrefixLength="1"
                                                                                            DelimiterCharacters=""
                                                                                            ServiceMethod="GetClaimanity"
                                                                                            ServicePath="Inpayment.aspx"
                                                                                            Enabled="True"
                                                                                            CompletionListCssClass="ac_results"
                                                                                            CompletionListItemCssClass="listItem"
                                                                                            CompletionListHighlightedItemCssClass="itemHighlighted"
                                                                                            TargetControlID="ClaimantName" />

                                                                                        <br />
                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ClaimantName" ID="RegularExpressionValidator30" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="CLAIMANT"></asp:RegularExpressionValidator>
                                                                                        <br />
                                                                                        <asp:TextBox autocomplete="off"  ID="ClaimantName1C" MaxLength="17" placeholder="Claimant ID " Width="275" runat="server" TabIndex="44" type="text" ValidationGroup="CLAIMANT" Style="text-transform: uppercase"></asp:TextBox>

                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ClaimantName1C" ID="RegularExpressionValidator73" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="CLAIMANT"></asp:RegularExpressionValidator>

                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-sm-2">
                                                                                <div class="form-group row">

                                                                                    <div class="col-sm-12">
                                                                                        <asp:TextBox autocomplete="off"  ID="ClaimantCRUEI" MaxLength="17" placeholder="CRUEI" Width="170" ValidationGroup="CLAIMANT" runat="server" TabIndex="41" type="text" Style="text-transform: uppercase"></asp:TextBox>


                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ClaimantCRUEI" ID="RegularExpressionValidator27" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="CLAIMANT"></asp:RegularExpressionValidator>

                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-sm-3">
                                                                                <div class="form-group row">

                                                                                    <div class="col-sm-12">
                                                                                        <asp:TextBox autocomplete="off"  ID="ClaimantName1" MaxLength="50" placeholder="Name" Width="275" ValidationGroup="CLAIMANT" runat="server" TabIndex="42" type="text" Style="text-transform: uppercase"></asp:TextBox>
                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ClaimantName1" ID="RegularExpressionValidator29" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="CLAIMANT"></asp:RegularExpressionValidator>

                                                                                        <br />
                                                                                        <br />
                                                                                        <asp:TextBox autocomplete="off"  ID="ClaimantNameC" MaxLength="100" placeholder="Claimant Name" Width="275" runat="server" TabIndex="45" type="text" ValidationGroup="CLAIMANT" Style="text-transform: uppercase"></asp:TextBox>

                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ClaimantNameC" ID="RegularExpressionValidator5" ValidationExpression="^[\s\S]{0,100}$" runat="server" ErrorMessage="Maximum 100 characters allowed." ValidationGroup="CLAIMANT"></asp:RegularExpressionValidator>
                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-sm-3">
                                                                                <div class="form-group row">

                                                                                    <div class="col-sm-12">
                                                                                        <asp:TextBox autocomplete="off"  ID="ClaimantName2" MaxLength="17" placeholder="Name1 " Width="275" runat="server" TabIndex="43" type="text" ValidationGroup="CLAIMANT" Style="text-transform: uppercase"></asp:TextBox>

                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ClaimantName2" ID="RegularExpressionValidator28" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="CLAIMANT"></asp:RegularExpressionValidator>
                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                        </div>



                                                                        <div class="col-sm-12">
                                                                            <div class="row">
                                                                                <div class="col-sm-4">

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

                                                                                    <asp:ValidationSummary ID="ValidationSummary6" runat="server" ShowMessageBox="True"
                                                                                        ShowSummary="False" ValidationGroup="party" />
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
                                                                                                </div>
                                                                                                <div class="modal-footer">
                                                                                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                                                                </div>
                                                                                            </div>

                                                                                        </div>
                                                                                    </div>
                                                                                    <asp:ValidationSummary ID="ValidationSummary7" runat="server" ShowMessageBox="True"
                                                                                        ShowSummary="False" ValidationGroup="importer" />
                                                                                </div>
                                                                                <div class="col-sm-4">
                                                                                    <br />

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
                                                                                                </div>
                                                                                                <div class="modal-footer">
                                                                                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                                                                </div>
                                                                                            </div>

                                                                                        </div>
                                                                                    </div>
                                                                                    <br />
                                                                                    <asp:ValidationSummary ID="ValidationSummary8" runat="server" ShowMessageBox="True"
                                                                                        ShowSummary="False" ValidationGroup="Inward" />
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
                                                                                                </div>
                                                                                                <div class="modal-footer">
                                                                                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                    <asp:ValidationSummary ID="ValidationSummary9" runat="server" ShowMessageBox="True"
                                                                                        ShowSummary="False" ValidationGroup="freight" />
                                                                                </div>
                                                                                <div class="col-sm-4">
                                                                                    <br />
                                                                                    <br />
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
                                                                                                </div>
                                                                                                <div class="modal-footer">
                                                                                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                    <asp:ValidationSummary ID="ValidationSummary10" runat="server" ShowMessageBox="True"
                                                                                        ShowSummary="False" ValidationGroup="CLAIMANT" />
                                                                                </div>
                                                                            </div>
                                                                            <br />
                                                                            <br />
                                                                        </div>
                                                                        <div class="row">
    <%-- <div class="col-sm-3">
                        </div>--%>
    <div class="col-sm-12">
        <center>

            <div class="flex justify-between gap-4 md:flex-nowrap flex-wrap mt-6">
                <asp:Button ID="btnpreviousparty" runat="server" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" OnClick="btnpreviousparty_Click" Text="Previous" TabIndex="45" />

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
                                                        <%--     </div>--%>
                                                        <%--<div role="tabpanel" class="tab-pane fade" aria-labelledby="cargo-tab" id="Cargo">--%>

                                                        <cc1:TabPanel ID="Cargo" runat="server" HeaderText="Cargo" >
                                                            <ContentTemplate>
                                                                <asp:UpdatePanel ID="upincargo" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <br />
                                                                        <div class="row">
                                                                            <div class="col-sm-6">
                                                                                <div id="carLoadingPort" runat="server">
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail"  class="col-sm-3 col-form-label">
                                                                                            <div class="row">
                                                                                                <div class="col-sm-9">
                                                                                                    Loading Port
                                                                                                </div>
                                                                                                <div class="col-sm-3">
                                                                                                    <asp:ImageButton ID="btnloadport1" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />
                                                                                                </div>
                                                                                            </div>
                                                                                            <%--<i class='fa fa-search' data-toggle="modal" data-target="#loadingSearch"></i>--%>
                                                                                        </label>
                                                                                        <cc1:ModalPopupExtender ID="popuploadingport" runat="server" PopupControlID="pnlloadingport" TargetControlID="btnloadport1"
                                                                                            OkControlID="btnyeslp" CancelControlID="btnnolp" BackgroundCssClass="modalBackground">
                                                                                        </cc1:ModalPopupExtender>
                                                                                        <asp:Panel ID="pnlloadingport" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                            <div class="header">
                                                                                                LOADING PORT
                                                                                            </div>
                                                                                            <div class="body">
                                                                                                <asp:UpdatePanel ID="uploadingport" runat="server" UpdateMode="Conditional">
                                                                                                    <ContentTemplate>
                                                                                                        <asp:TextBox autocomplete="off"  ID="CarLoadingSearch" OnTextChanged="CarLoadingSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                        <br />
                                                                                                        <asp:GridView ID="LoadingGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="LoadingGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" OnRowCommand="LoadingGrid_RowCommand" OnRowDataBound="LoadingGrid_RowDataBound" runat="server" AutoGenerateColumns="false">
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
                                                                                                        </div>
    <div class="footer" align="right">
        <asp:Button ID="btnyeslp" runat="server" Text="Yes" CssClass="yes" />
        <asp:Button ID="btnnolp" runat="server" Text="No" CssClass="no" />
                                                                                                    </ContentTemplate>
                                                                                                    <%--<Triggers>
                                                                                                        <asp:PostBackTrigger ControlID="LoadingGrid" />
                                                                                                        <%-- <asp:AsyncPostBackTrigger ControlID ="LoadingGrid" />--%>
                                                                                                    <%--  </Triggers>--%>
                                                                                                </asp:UpdatePanel>
                                                                                            </div>
                                                                                        </asp:Panel>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe" Width="75" type="text" ID="TxtLoadShort" OnTextChanged="TxtLoadShort_TextChanged" AutoPostBack="true" TabIndex="49" Style="text-transform: uppercase"></asp:TextBox>
                                                                                            <cc1:AutoCompleteExtender ServiceMethod="GetLodcode" MinimumPrefixLength="1" CompletionInterval="100" EnableCaching="false" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" CompletionSetCount="10" TargetControlID="TxtLoadShort" ID="AutoCompleteExtender6" runat="server" FirstRowSelected="true"></cc1:AutoCompleteExtender>

                                                                                            <asp:TextBox autocomplete="off"  runat="server" type="text" Width="250" ID="TxtLoad" Enabled="false" TabIndex="50"></asp:TextBox>


                                                                                        </div>
                                                                                    </div>
                                                                                </div>



                                                                                <div id="carArrival" runat="server">
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail"  class="col-sm-3 col-form-label">
                                                                                            HBL
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  Width="325" runat="server" type="text" ID="txthBlCargo" MaxLength="35" AutoPostBack="true" OnTextChanged="txthBlCargo_TextChanged" ValidationGroup="Validation" TabIndex="51" Style="text-transform: uppercase"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>


                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail"  class="col-sm-3 col-form-label">
                                                                                            Arrival Date


                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off" Width="325"  onkeypress="return isNumberKey(event)" ID="TxtArrivalDate1" runat="server" AutoPostBack="true" OnTextChanged="TxtArrivalDate1_TextChanged" TabIndex="52"></asp:TextBox>

                                                                                            <cc1:CalendarExtender ID="CalendarExtender1" PopupButtonID="imgPopup" CssClass="cal_Theme1" runat="server" TargetControlID="TxtArrivalDate1" Format="dd/MM/yyyy"></cc1:CalendarExtender>
                                                                                        </div>

                                                                                    </div>
                                                                                </div>

                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail"  class="col-sm-3 col-form-label">
                                                                                        <div class="row">
                                                                                            <div class="col-sm-9">
                                                                                                Release Loc
                                                                                            </div>
                                                                                            <div class="col-sm-3">

                                                                                                <asp:ImageButton ID="btlreleaseloc1" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />


                                                                                            </div>
                                                                                        </div>

                                                                                    </label>
                                                                                    <cc1:ModalPopupExtender ID="popupreleaseloc" runat="server" PopupControlID="pnlrelloc" TargetControlID="btlreleaseloc1"
                                                                                        OkControlID="btnyesrelloc" CancelControlID="btnnorelloc" BackgroundCssClass="modalBackground">
                                                                                    </cc1:ModalPopupExtender>
                                                                                    <asp:Panel ID="pnlrelloc" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                        <div class="header">
                                                                                            RELEASE LOCATION
                                                                                        </div>
                                                                                        <div class="body">
                                                                                            <asp:UpdatePanel ID="uprelloc" runat="server" UpdateMode="Conditional">



                                                                                                <ContentTemplate>
                                                                                                    <asp:TextBox autocomplete="off"  ID="LocationSearch" OnTextChanged="LocationSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                    <br />
                                                                                                    <%-- <asp:UpdatePanel ID="UpdatePanelReleaseLocation" runat="server"  UpdateMode="Always">

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
                                                                                                    </div>
    <div class="footer" align="right">
        <asp:Button ID="btnyesrelloc" runat="server" Text="Yes" CssClass="yes" />
        <asp:Button ID="btnnorelloc" runat="server" Text="No" CssClass="no" />
                                                                                                </ContentTemplate>
                                                                                                <%--  <Triggers>
                                                                                                    <asp:PostBackTrigger ControlID="LocationGrid" />
                                                                                                </Triggers>--%>
                                                                                            </asp:UpdatePanel>
                                                                                        </div>
                                                                                    </asp:Panel>
                                                                                    <div class="col-sm-9">
                                                                                        <asp:TextBox autocomplete="off"  runat="server" Width="75" BackColor="#e8f0fe" ValidationGroup="Validation" type="text" MaxLength="7" ID="txtreLoctn" OnTextChanged="txtreLoctn_TextChanged" AutoPostBack="true" TabIndex="53" Style="text-transform: uppercase"></asp:TextBox>
                                                                                        <cc1:AutoCompleteExtender ServiceMethod="Getrelloc"
                                                                                            MinimumPrefixLength="1"
                                                                                            CompletionInterval="100" EnableCaching="false" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" CompletionSetCount="10"
                                                                                            TargetControlID="txtreLoctn"
                                                                                            ID="AutoCompleteExtender7" runat="server" FirstRowSelected="true">
                                                                                        </cc1:AutoCompleteExtender>

                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtreLoctn" ID="RegularExpressionValidator11" ValidationExpression="^[\s\S]{0,7}$" runat="server" ErrorMessage="Maximum 7 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>

                                                                                        <asp:TextBox autocomplete="off"  runat="server" Width="250" Height="40" type="text" TextMode="MultiLine"  MaxLength="256" ID="txtrelocDeta" Enabled="true" ValidationGroup="Validation" TabIndex="54" Style="text-transform: uppercase; border-radius: 15px 50px 30px;"></asp:TextBox>
                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtrelocDeta" ID="RegularExpressionValidator12" ValidationExpression="^[\s\S]{0,256}$" runat="server" ErrorMessage="Maximum 256 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                        <br />
                                                                                        <asp:Label runat="server" ForeColor="Red" BackColor="Yellow" Visible="false" ID="lblrelloc"></asp:Label>
                                                                                    </div>
                                                                                </div>



                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail"  class="col-sm-3 col-form-label">

                                                                                        <div class="row">
                                                                                            <div class="col-sm-9">
                                                                                                Receipt Loc
                                                                                            </div>
                                                                                            <div class="col-sm-3">

                                                                                                <asp:ImageButton ID="btnreceiptloc1" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />


                                                                                            </div>
                                                                                        </div>


                                                                                        <%--<i class='fa fa-search' data-toggle="modal" data-target="#Receipt"></i>--%>
                                                                                    </label>
                                                                                    <cc1:ModalPopupExtender ID="popupreceiptloc" runat="server" PopupControlID="pnlreceiptloc" TargetControlID="btnreceiptloc1"
                                                                                        OkControlID="btnyesrecloc" CancelControlID="btnnorecloc" BackgroundCssClass="modalBackground">
                                                                                    </cc1:ModalPopupExtender>
                                                                                    <asp:Panel ID="pnlreceiptloc" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                        <div class="header">
                                                                                            Receipt Loc
                                                                                        </div>
                                                                                        <div class="body">
                                                                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">



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
                                                                                                    </div>
    <div class="footer" align="right">
        <asp:Button ID="btnyesrecloc" runat="server" Text="Yes" CssClass="yes" />
        <asp:Button ID="btnnorecloc" runat="server" Text="No" CssClass="no" />
                                                                                                </ContentTemplate>
                                                                                                <%-- <Triggers>
                                                                                                    <asp:PostBackTrigger ControlID="ReceiptGrid" />
                                                                                                </Triggers>--%>
                                                                                            </asp:UpdatePanel>
                                                                                        </div>
                                                                                    </asp:Panel>
                                                                                    <div class="col-sm-9">
                                                                                        <asp:TextBox autocomplete="off"  runat="server" Width="75" BackColor="#e8f0fe" ValidationGroup="Validation" type="text" MaxLength="7" OnTextChanged="txtrecloctn_TextChanged" AutoPostBack="true" ID="txtrecloctn" TabIndex="55" Style="text-transform: uppercase"></asp:TextBox>

                                                                                        <cc1:AutoCompleteExtender ServiceMethod="GetRecLoc"
                                                                                            MinimumPrefixLength="1"
                                                                                            CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
                                                                                            TargetControlID="txtrecloctn"
                                                                                            ID="AutoCompleteExtender8" runat="server" FirstRowSelected="true">
                                                                                        </cc1:AutoCompleteExtender>

                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtrecloctn" ID="RegularExpressionValidator13" ValidationExpression="^[\s\S]{0,7}$" runat="server" ErrorMessage="Maximum 7 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                        <asp:TextBox autocomplete="off"   runat="server" Width="250" Height="40" TextMode="MultiLine" type="text" MaxLength="256" ID="txtrecloctndet" Enabled="true" TabIndex="56" ValidationGroup="Validation" Style="text-transform: uppercase; border-radius: 15px 50px 30px;"></asp:TextBox>
                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtrecloctndet" ID="RegularExpressionValidator14" ValidationExpression="^[\s\S]{0,256}$" runat="server" ErrorMessage="Maximum 256 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail"  class="col-sm-3 col-form-label">Blanket Start Date</label>
                                                                                    <div class="col-sm-9">
                                                                                        <asp:TextBox autocomplete="off" Width="325"   ID="BlankDate1" onkeypress="return isNumberKey(event)" runat="server" TabIndex="57" AutoPostBack="true" OnTextChanged="BlankDate1_TextChanged"></asp:TextBox>



                                                                                        <cc1:CalendarExtender ID="CalendarExtender2" PopupButtonID="imgPopup" CssClass="cal_Theme1" runat="server" TargetControlID="BlankDate1" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"></cc1:CalendarExtender>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-sm-6">
                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail"  class="col-sm-3 col-form-label">
                                                                                        &nbsp;&nbsp;Total Outer Pack

                                                                                    </label>
                                                                                    <div class="col-sm-9">
                                                                                        <asp:TextBox autocomplete="off"  runat="server" type="text" MaxLength="8" ValidationGroup="outerpack" onkeypress="return isNumberKey(event)" ID="TxttotalOuterPack" TabIndex="58" Width="175" AutoPostBack="true" OnTextChanged="TxttotalOuterPack_TextChanged" Style="text-transform: uppercase"></asp:TextBox>
                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxttotalOuterPack" ID="RegularExpressionValidator67" ValidationExpression="^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 8 characters allowed." ValidationGroup="outerpack"></asp:RegularExpressionValidator>
                                                                                        <asp:DropDownList ID="DrptotalOuterPack" CssClass="drop" runat="server" TabIndex="59" Width="175" AutoPostBack="true" OnSelectedIndexChanged="DrptotalOuterPack_SelectedIndexChanged"></asp:DropDownList>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail"  class="col-sm-3 col-form-label">
                                                                                        &nbsp;&nbsp;Total Gross Weight

                                                                                    </label>
                                                                                    <div class="col-sm-9">
                                                                                        <asp:TextBox autocomplete="off"  runat="server" type="text" MaxLength="15" ValidationGroup="outerpack" ID="TxtTotalGrossWeight" onkeypress="return isNumberKey(event)" TabIndex="60" Width="175" AutoPostBack="true" OnTextChanged="TxtTotalGrossWeight_TextChanged" Style="text-transform: uppercase"></asp:TextBox>

                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtTotalGrossWeight" ID="RegularExpressionValidator68" ValidationExpression="^[\s\S]{0,15}$" runat="server" ErrorMessage="Maximum 15 characters allowed." ValidationGroup="outerpack"></asp:RegularExpressionValidator>
                                                                                        <asp:DropDownList ID="DrpTotalGrossWeight" CssClass="drop" runat="server" Width="175" TabIndex="61" AutoPostBack="true" OnSelectedIndexChanged="DrpTotalGrossWeight_SelectedIndexChanged">
                                                                                            <asp:ListItem Selected="True" Text="--Select--" Value="--SELECT--"> </asp:ListItem>
                                                                                            <asp:ListItem Text="KGM" Value="KGM"> </asp:ListItem>
                                                                                            <asp:ListItem Text="TNE" Value="TNE"> </asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </div>
                                                                                </div>

                                                                                


                                                                                <div class="row Borderdiv" style="width: 100%">
                                                                                    INWARD DETAILS
                                                                                </div>
                                                                                <br />
                                                                                <div id="carMode" runat="server">
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail"  class="col-sm-3 col-form-label">
                                                                                            &nbsp;&nbsp;Mode
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off" Width="350"  Enabled="false" runat="server" type="text" ID="TextMode" OnTextChanged="TextMode_TextChanged" Style="text-transform: uppercase" AutoPostBack="true"></asp:TextBox>

                                                                                        </div>
                                                                                    </div>
                                                                                </div>


                                                                                <div id="InwardFlight" runat="server">
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail"  class="col-sm-3 col-form-label">
                                                                                            Flight Number
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  Width="350" runat="server" BackColor="#e8f0fe" ValidationGroup="Validation" type="text" ID="txtflight" TabIndex="62" Style="text-transform: uppercase"></asp:TextBox>

                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtflight" ID="RegularExpressionValidator60" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail"  class="col-sm-3 col-form-label">
                                                                                            Aircraft Reg No 
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox Width="350"  autocomplete="off"  runat="server" type="text" ValidationGroup="Validation" ID="txtaircraft" TabIndex="63" Style="text-transform: uppercase"></asp:TextBox>
                                                                                            <br />
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtaircraft" ID="RegularExpressionValidator61" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail"  class="col-sm-3 col-form-label">
                                                                                            Master Air Waybill
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off" Width="350"  runat="server" BackColor="#e8f0fe" ValidationGroup="Validation" AutoPostBack="true" OnTextChanged="txtwaybill_TextChanged" type="text" ID="txtwaybill" TabIndex="64"></asp:TextBox>

                                                                                            <asp:RegularExpressionValidator BackColor="Yellow" ID="RegularExpressionValidator2" runat="server" Display="None" ControlToValidate="txtwaybill" ValidationExpression="^[\s\S]{0,35}$" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Validation" />
                                                                                        </div>
                                                                                    </div>
                                                                                </div>

                                                                                <div id="InwardSea" runat="server">
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail"  class="col-sm-3 col-form-label">
                                                                                            Voyage Number
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off" Width="350"  runat="server" BackColor="#e8f0fe" ValidationGroup="Validation" type="text" ID="TxtVoyageno" TabIndex="65" Style="text-transform: uppercase"></asp:TextBox>

                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtVoyageno" ID="RegularExpressionValidator53" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail"  class="col-sm-3 col-form-label">
                                                                                            Vessel Name
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox Width="350"  autocomplete="off"  runat="server" BackColor="#e8f0fe" type="text" ValidationGroup="Validation" ID="TxtVesselName" TabIndex="66" Style="text-transform: uppercase"></asp:TextBox>

                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtVesselName" ID="RegularExpressionValidator54" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail"  class="col-sm-3 col-form-label">
                                                                                            OBL
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe" type="text" ValidationGroup="Validation" ID="TxtOceanBill" Width="350"  TabIndex="67" AutoPostBack="true" OnTextChanged="TxtOceanBill_TextChanged" Style="text-transform: uppercase"></asp:TextBox>

                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtOceanBill" ID="RegularExpressionValidator57" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>

                                                                                <div id="InwardOther" runat="server">
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail"  class="col-sm-3 col-form-label">
                                                                                            Conveyance Ref.No
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off" Width="350"  runat="server" type="text" ID="TxtConRefNo" ValidationGroup="Validation" TabIndex="68" Style="text-transform: uppercase"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtConRefNo" ID="RegularExpressionValidator55" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail"  class="col-sm-3 col-form-label">
                                                                                            Transport ID
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off" Width="350"   runat="server" type="text" ID="TxtTrnsID" ValidationGroup="Validation" TabIndex="69" Style="text-transform: uppercase"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtTrnsID" ID="RegularExpressionValidator56" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>


                                                                            </div>



                                                                        </div>
                                                                        <div class="row">
                                                                            <div class="col-sm-12 text-center">

                                                                                <center>

                                                                                        <div id="gvAddrow" visible ="false"  runat ="server" >
                                                                                            <asp:GridView ID="ContarinerGrid" CssClass="table" runat="server"  OnRowDeleting="ContarinerGrid_RowDeleting" OnRowDataBound="ContarinerGrid_RowDataBound1" ShowFooter="true" AutoGenerateColumns="false">
                                                                                                <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />
                                                                                                 <Columns>
                                                                                                    <asp:BoundField DataField="RowNumber" HeaderText="Row Number"  Visible="false" />
                                                                                                     <asp:TemplateField  HeaderText ="S.No"  >
        <ItemTemplate>
             <%#Container.DataItemIndex+1 %>
        </ItemTemplate>
    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Container No">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:TextBox autocomplete="off"  ID="txt1"  BackColor="#e8f0fe" Width="100" TabIndex="70" runat="server"></asp:TextBox>
                                                                                                            <asp:RegularExpressionValidator ID="revEmail" ValidationGroup="Validation1" ForeColor="Red" Display="Dynamic"
                                                                                                                ValidationExpression="[a-zA-Z]{4}[0-9]{7}" ControlToValidate="txt1"
                                                                                                                runat="server"
                                                                                                                ErrorMessage="The container no. format should be 4 alphabets and followed by 7 digit, for ex.: ABCD1234567"></asp:RegularExpressionValidator>
                                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" Font-Size="XX-Small" ControlToValidate="txt1" ErrorMessage="Container No is Required" ForeColor="Red" ValidationGroup="Container"></asp:RequiredFieldValidator>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Size / Type">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:DropDownList ID="DrpType"  BackColor="#e8f0fe" CssClass="drop" TabIndex="71" runat="server"></asp:DropDownList>
                                                                                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator233" InitialValue="0" runat="server" Font-Size="XX-Small" ControlToValidate="DrpType" ErrorMessage="Size / Type is Required" ForeColor="Red" ValidationGroup="Container"></asp:RequiredFieldValidator>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Weight ( TNE )">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:TextBox autocomplete="off"  ID="txt2" onkeypress="return onlyNumbers(event)" Width="100"  BackColor="#e8f0fe" TabIndex="72" ValidationGroup="Validation1" MaxLength="3" runat="server"></asp:TextBox>
                                                                                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator234" runat="server" Font-Size="XX-Small" ControlToValidate="txt2" ErrorMessage="Weight is Required" ForeColor="Red" ValidationGroup="Container"></asp:RequiredFieldValidator>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Seal No">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:TextBox autocomplete="off"  ID="txt3"  BackColor="#e8f0fe" TabIndex="73" runat="server"></asp:TextBox>
                                                                                                            <br />
                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txt3" ID="RegularExpressionValidator45" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Validation1"></asp:RegularExpressionValidator>
                                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator235" runat="server" Font-Size="XX-Small" ControlToValidate="txt3" ErrorMessage="Seal No is Required" ForeColor="Red" ValidationGroup="Container"></asp:RequiredFieldValidator>
                                                                                                        </ItemTemplate>
                                                                                                        <FooterStyle HorizontalAlign="Right" />
                                                                                                        <FooterTemplate>
                                                                                                            <asp:Button ID="ButtonAdd" runat="server" Text="Add Row" ValidationGroup="Container" OnClick="ButtonAdd_Click" />
                                                                                                        </FooterTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                     <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
                                                                                                   <%-- <asp:TemplateField HeaderText="Delete">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:LinkButton data-toggle="modal" data-target='<%#"#"+DataBinder.Eval(Container.DataItem,"RowNumber")%>' Width="11" Height="11" ID="imgDelete" runat="server"><i class='fa fa-trash' style="color:red"></i></asp:LinkButton>

                                                                                                            <div class="modal fade" id='<%#Eval("RowNumber")%>' role="dialog">
                                                                                                                <div class="modal-dialog">

                                                                                                                    <!-- Modal content-->
                                                                                                                    <div class="modal-content" style="width: 68%; left: 42%; top: 200px;">
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
                                                                                                    </asp:TemplateField>--%>
                                                                                                </Columns>
                                                                                            </asp:GridView>
                                                                                        </div>
</center>
                                                                            </div>
                                                                        </div>
                                                                        <div class="row">
                                                                            <div class="col-sm-12 text-center">

                                                                                <center>

                                                                                        <div id="Div7" runat ="server" >
                                                                                            <asp:GridView ID="GridView2" runat="server"  OnRowDeleting="ContarinerGrid_RowDeleting" ShowFooter="true" AutoGenerateColumns="false">
                                                                                                <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />
                                                                                                 <Columns>
                                                                                                    <asp:BoundField DataField="RowNumber" HeaderText="Row Number"  />
                                                                                                    <asp:TemplateField HeaderText="Container No" ItemStyle-Width="500">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:TextBox autocomplete="off"  ID="txt1"  BackColor="#e8f0fe" TabIndex="70" runat="server"></asp:TextBox>
                                                                                                            <asp:RegularExpressionValidator ID="revEmail" ValidationGroup="Validation1" ForeColor="Red" Display="Dynamic"
                                                                                                                ValidationExpression="[a-zA-Z]{4}[0-9]{7}" ControlToValidate="txt1"
                                                                                                                runat="server"
                                                                                                                ErrorMessage="The container no. format should be 4 alphabets and followed by 7 digit, for ex.: ABCD1234567"></asp:RegularExpressionValidator>
                                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" Font-Size="XX-Small" ControlToValidate="txt1" ErrorMessage="Container No is Required" ForeColor="Red" ValidationGroup="Container"></asp:RequiredFieldValidator>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Size / Type">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:DropDownList ID="DrpType"  BackColor="#e8f0fe" CssClass="drop" TabIndex="71" runat="server"></asp:DropDownList>
                                                                                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator233" InitialValue="0" runat="server" Font-Size="XX-Small" ControlToValidate="DrpType" ErrorMessage="Size / Type is Required" ForeColor="Red" ValidationGroup="Container"></asp:RequiredFieldValidator>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Weight ( TNE )">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:TextBox autocomplete="off"  ID="txt2" onkeypress="return onlyNumbers(event)" Width="100"  BackColor="#e8f0fe" TabIndex="72" ValidationGroup="Validation1" MaxLength="3" runat="server"></asp:TextBox>
                                                                                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator234" runat="server" Font-Size="XX-Small" ControlToValidate="txt2" ErrorMessage="Weight is Required" ForeColor="Red" ValidationGroup="Container"></asp:RequiredFieldValidator>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Seal No">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:TextBox autocomplete="off"  ID="txt3"  BackColor="#e8f0fe" TabIndex="73" runat="server"></asp:TextBox>
                                                                                                            <br />
                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txt3" ID="RegularExpressionValidator45" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Validation1"></asp:RegularExpressionValidator>
                                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator235" runat="server" Font-Size="XX-Small" ControlToValidate="txt3" ErrorMessage="Seal No is Required" ForeColor="Red" ValidationGroup="Container"></asp:RequiredFieldValidator>
                                                                                                        </ItemTemplate>
                                                                                                        <FooterStyle HorizontalAlign="Right" />
                                                                                                        <FooterTemplate>
                                                                                                            <asp:Button ID="ButtonAdd" runat="server" Text="Add Row" ValidationGroup="Container" CssClass="btn" OnClick="ButtonAdd_Click" />
                                                                                                        </FooterTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Delete">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:LinkButton CssClass="btn" data-toggle="modal" data-target='<%#"#"+DataBinder.Eval(Container.DataItem,"RowNumber")%>' Width="11" Height="11" ID="imgDelete" runat="server"><i class='fa fa-trash' style="color:red"></i></asp:LinkButton>

                                                                                                            <div class="modal fade" id='<%#Eval("RowNumber")%>' role="dialog">
                                                                                                                <div class="modal-dialog">

                                                                                                                    <!-- Modal content-->
                                                                                                                    <div class="modal-content" style="width: 68%; left: 42%; top: 200px;">
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
</center>
                                                                            </div>
                                                                        </div>
                                                                        <asp:ValidationSummary ID="ValidationSummary14" runat="server" ShowMessageBox="True"
                                                                            ShowSummary="False" ValidationGroup="outerpack" />


                                                                        <div class="row">

    <div class="col-sm-12">

        <center>

            <div class="flex justify-between gap-4 md:flex-nowrap flex-wrap mt-6">
                <asp:Button ID="btnprevcargo" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" runat="server" OnClick="btnprevcargo_Click" Text="Previous" TabIndex="74" />
                <asp:Button ID="btnsavecargo" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" runat="server" OnClick="btnsavecargo_Click" Text="Save Draft" TabIndex="75" />
                <asp:Button ID="btnresetcargo" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" runat="server" OnClick="btnresetcargo_Click" Text="Reset" TabIndex="76" />
                <asp:Button ID="btnnextcargo" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" runat="server" OnClick="btnnextcargo_Click" Text="Next" TabIndex="77" />
            </div>
        </center>
    </div>

</div>


                                                                    </ContentTemplate>

                                                                </asp:UpdatePanel>
                                                            </ContentTemplate>
                                                        </cc1:TabPanel>


                                                        <cc1:TabPanel ID="Invoice" runat="server" HeaderText="Invoice">
                                                            <ContentTemplate>
                                                                <br />

                                                                <asp:UpdatePanel ID="updateInvoice" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <div class="row">
                                                                            <div class="col-sm-4">
                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail" class="col-sm-8 col-form-label">

                                                                                        <div class="row">
                                                                                            <div class="col-sm-9" style="font-family: 'Times New Roman'">
                                                                                                Supplier / Manuf Party
                                                                                            </div>
                                                                                            <div class="col-sm-3">

                                                                                                <asp:ImageButton ID="btnsupplier1" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />

                                                                                                <asp:Button ValidationGroup="supply" BackColor="Transparent" BorderWidth="0px" Font-Size="Small" ID="suppyadd" runat="server" TabIndex="73" OnClick="suppyadd_Click" Text="+" />
                                                                                            </div>
                                                                                        </div>



                                                                                        <cc1:ModalPopupExtender ID="popupsupplier" runat="server" PopupControlID="pnlsupplier" TargetControlID="btnsupplier1"
                                                                                            OkControlID="btnyessuplier" CancelControlID="btnnosuplier" BackgroundCssClass="modalBackground">
                                                                                        </cc1:ModalPopupExtender>
                                                                                        <asp:Panel ID="pnlsupplier" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                            <div class="header">
                                                                                                Supplier / Manufacturer Party
                                                                                            </div>
                                                                                            <div class="body">
                                                                                                <asp:UpdatePanel ID="upsuplier" runat="server" UpdateMode="Conditional">



                                                                                                    <ContentTemplate>

                                                                                                        <asp:TextBox autocomplete="off"  ID="SUPPLIERSearch" MaxLength="17" OnTextChanged="SUPPLIERSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                        <br />
                                                                                                        <%-- <asp:UpdatePanel ID="upd" runat="server"  UpdateMode="Always">

                                                            <ContentTemplate>--%>


                                                                                                        <asp:GridView ID="SUPPLIERGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="SUPPLIERGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" OnRowCommand="SUPPLIERGrid_RowCommand" OnRowDataBound="SUPPLIERGrid_RowDataBound" runat="server" AutoGenerateColumns="false">
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
                                                                                                                        <asp:LinkButton ID="lnkRequestID" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="lnkRequestID_Command1">Select </asp:LinkButton>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                            </Columns>

                                                                                                        </asp:GridView>
                                                                                                        </div>
    <div class="footer" align="right">
        <asp:Button ID="btnyessuplier" runat="server" Text="Yes" CssClass="yes" />
        <asp:Button ID="btnnosuplier" runat="server" Text="No" CssClass="no" />
                                                                                                    </ContentTemplate>
                                                                                                    <%-- <Triggers>
                                                                                                        <asp:PostBackTrigger ControlID="SUPPLIERGrid" />
                                                                                                    </Triggers>--%>
                                                                                                </asp:UpdatePanel>
                                                                                            </div>
                                                                                        </asp:Panel>

                                                                                    </label>
                                                                                    <div class="col-sm-4">
                                                                                        <asp:TextBox autocomplete="off"  Width="100" runat="server" type="text" placeholder="Code" ValidationGroup="supply" ID="txtcodeinvq" OnTextChanged="txtcodeinvq_TextChanged" AutoPostBack="true" TabIndex="75" Style="text-transform: uppercase"></asp:TextBox>
                                                                                        <cc1:AutoCompleteExtender ServiceMethod="GetSupcode" MinimumPrefixLength="1" CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10" TargetControlID="txtcodeinvq" ID="AutoCompleteExtender9" runat="server" FirstRowSelected="true"></cc1:AutoCompleteExtender>

                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtcodeinvq" ID="RegularExpressionValidator31" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="supply"></asp:RegularExpressionValidator>
                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-sm-2">
                                                                                <div class="form-group row">

                                                                                    <div class="col-sm-12">
                                                                                        <asp:TextBox autocomplete="off"  Width="170" runat="server" type="text" MaxLength="17" ID="txtcruei" placeholder="CRUEI" ValidationGroup="supply" TabIndex="76" Style="text-transform: uppercase"></asp:TextBox>
                                                                                        <br />
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="txtcruei" Font-Size="XX-Small" ForeColor="Red" ErrorMessage="Invoice --> Please Enter  Supplier Party CRUEI " ValidationGroup="Invoice"></asp:RequiredFieldValidator>
                                                                                        <br />
                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtcruei" ID="RegularExpressionValidator34" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="supply"></asp:RegularExpressionValidator>
                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-sm-3">
                                                                                <div class="form-group row">

                                                                                    <div class="col-sm-12">
                                                                                        <asp:TextBox autocomplete="off"  Width="275" runat="server" type="text" MaxLength="50" BackColor="#e8f0fe" ValidationGroup="supply" ID="txtName" placeholder="NAME" TabIndex="77" Style="text-transform: uppercase"></asp:TextBox><br />
                                                                                        <br />
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" Font-Size="XX-Small" ForeColor="Red" ErrorMessage="Invoice --> Please Enter  Supplier Party Name " ValidationGroup="Invoice"></asp:RequiredFieldValidator>
                                                                                        <br />
                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtName" ID="RegularExpressionValidator32" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="supply"></asp:RegularExpressionValidator>
                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-sm-3">
                                                                                <div class="form-group row">

                                                                                    <div class="col-sm-12">
                                                                                        <asp:TextBox autocomplete="off"  Width="275" runat="server" type="text" MaxLength="50" ID="txtName1" placeholder="NAME1" ValidationGroup="supply" TabIndex="78" Style="text-transform: uppercase"></asp:TextBox>
                                                                                        <br />
                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtName1" ID="RegularExpressionValidator33" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="supply"></asp:RegularExpressionValidator>
                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                        </div>

                                                                        <div class="row">
                                                                            <div class="col-sm-4">
                                                                                <div class="form-group row">
                                                                                    <label for="staticEmail" class="col-sm-8 col-form-label">

                                                                                        <div class="row">
                                                                                            <div class="col-sm-9" style="font-family: 'Times New Roman'">
                                                                                                Importer Party
                                                                                            </div>
                                                                                            <div class="col-sm-3">

                                                                                                <asp:ImageButton ID="btninvimp1" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />

                                                                                                <asp:Button ID="BtnImpPartyADD" BackColor="Transparent" BorderWidth="0px" Font-Size="Small" TabIndex="79" runat="server" ValidationGroup="supply1" OnClick="BtnImpPartyADD_Click" Text="+" />
                                                                                            </div>
                                                                                        </div>



                                                                                        <cc1:ModalPopupExtender ID="popupinvimp" runat="server" PopupControlID="pnlinvimp" TargetControlID="btninvimp1"
                                                                                            OkControlID="btnyesinvimp" CancelControlID="btnnoinvimp" BackgroundCssClass="modalBackground">
                                                                                        </cc1:ModalPopupExtender>
                                                                                        <asp:Panel ID="pnlinvimp" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                            <div class="header">
                                                                                                Importer Party
                                                                                            </div>
                                                                                            <div class="body">
                                                                                                <asp:UpdatePanel ID="upinvimp" runat="server" UpdateMode="Conditional">



                                                                                                    <ContentTemplate>
                                                                                                        <asp:TextBox autocomplete="off"  ID="ImportPartySearch" OnTextChanged="ImportPartySearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                        <br />

                                                                                                        <%--<asp:UpdatePanel ID="UpdatePanelimporter" runat="server"  UpdateMode="Always">

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

                                                                                                        </div>
    <div class="footer" align="right">
        <asp:Button ID="btnyesinvimp" runat="server" Text="Yes" CssClass="yes" />
        <asp:Button ID="btnnoinvimp" runat="server" Text="No" CssClass="no" />
                                                                                                    </ContentTemplate>
                                                                                                    <%--   <Triggers>
                                                                                                        <asp:PostBackTrigger ControlID="ImportPartyGrid" />
                                                                                                    </Triggers>--%>
                                                                                                </asp:UpdatePanel>
                                                                                            </div>
                                                                                        </asp:Panel>

                                                                                    </label>
                                                                                    <div class="col-sm-4">
                                                                                        <asp:TextBox autocomplete="off"  Width="100" runat="server" type="text" ID="TxtImppartyCode" placeholder="Code" ValidationGroup="supply1" OnTextChanged="TxtImppartyCode_TextChanged" AutoPostBack="true" TabIndex="79" Style="text-transform: uppercase"></asp:TextBox>
                                                                                        <cc1:AutoCompleteExtender ServiceMethod="GetImppartycode"
                                                                                            MinimumPrefixLength="1"
                                                                                            CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
                                                                                            TargetControlID="TxtImppartyCode"
                                                                                            ID="AutoCompleteExtender10" runat="server" FirstRowSelected="true">
                                                                                        </cc1:AutoCompleteExtender>

                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtImppartyCode" ID="RegularExpressionValidator35" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="supply"></asp:RegularExpressionValidator>
                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-sm-2">
                                                                                <div class="form-group row">

                                                                                    <div class="col-sm-12">
                                                                                        <asp:TextBox autocomplete="off"  Width="170" ID="TxtImppartyCRUEI" MaxLength="17" placeholder="CRUEI" BackColor="#e8f0fe" runat="server" TabIndex="80" ValidationGroup="supply1" type="text" Style="text-transform: uppercase"></asp:TextBox>
                                                                                        <br />
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtImppartyCRUEI" Font-Size="XX-Small" ForeColor="Red" ErrorMessage="Invoice --> Please Enter  Importer Party CRUEI " ValidationGroup="Invoice"></asp:RequiredFieldValidator>
                                                                                        <br />
                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtImppartyCRUEI" ID="RegularExpressionValidator36" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="supply"></asp:RegularExpressionValidator>
                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-sm-3">
                                                                                <div class="form-group row">

                                                                                    <div class="col-sm-12">
                                                                                        <asp:TextBox autocomplete="off"  Width="275" ID="TxtImppartyName" MaxLength="35" placeholder="NAME" ValidationGroup="supply1" BackColor="#e8f0fe" runat="server" TabIndex="81" type="text" Style="text-transform: uppercase"></asp:TextBox><br />
                                                                                        <br />
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtImppartyName" Font-Size="XX-Small" ForeColor="Red" ErrorMessage="Invoice --> Please Enter  Importer Party Name " ValidationGroup="Invoice"></asp:RequiredFieldValidator>
                                                                                        <br />
                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtImppartyName" ID="RegularExpressionValidator4" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="supply1"></asp:RegularExpressionValidator>
                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-sm-3">
                                                                                <div class="form-group row">

                                                                                    <div class="col-sm-12">
                                                                                        <asp:TextBox autocomplete="off"  Width="275" ID="TxtImppartyName1" MaxLength="35" placeholder="NAME1" runat="server" TabIndex="82" type="text" ValidationGroup="supply1" Style="text-transform: uppercase"></asp:TextBox>
                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtImppartyName1" ID="RegularExpressionValidator6" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="supply1"></asp:RegularExpressionValidator>
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
                                                                                <asp:ValidationSummary ID="ValidationSummary15" runat="server" ShowMessageBox="True"
                                                                                    ShowSummary="False" ValidationGroup="Invoice" />






                                                                                <div class="row">
                                                                                    <div class="col-sm-12">
                                                                                        <div class="row Borderdiv" style="width: 100%">
                                                                                            INVOICE INFORMATION
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-sm-4">
                                                                                                <p>Serial Number</p>
                                                                                                <asp:TextBox autocomplete="off" Width="325"  runat="server" type="text" ID="txtserial" Enabled="false" TabIndex="83" Style="text-transform: uppercase"></asp:TextBox>

                                                                                                <p>Invoice Number</p>

                                                                                                <asp:TextBox autocomplete="off" Width="325"  runat="server" type="text" MaxLength="35" ID="txtinvNo" ValidationGroup="Invoice" TabIndex="84" class="w3-input w3-hover-green" Style="text-transform: uppercase"></asp:TextBox>
                                                                                                <br />
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtinvNo" Font-Size="XX-Small" ForeColor="Red" ErrorMessage="Invoice --> Please Enter Invoice No" ValidationGroup="Invoice"></asp:RequiredFieldValidator>
                                                                                                <br />

                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtinvNo" ID="RegularExpressionValidator37" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Invoice"></asp:RegularExpressionValidator>

                                                                                            </div>
                                                                                            <div class="col-sm-4">
                                                                                                <p>Invoice Date</p>

                                                                                                <div class='input-group date' id='Div2'>

                                                                                                    <div>
                                                                                                        <asp:TextBox autocomplete="off"  onkeypress="return isNumberKey(event)"  ID="txtinvDate1" Width="325"  runat="server" TabIndex="85" AutoPostBack="true" OnTextChanged="txtinvDate1_TextChanged1"></asp:TextBox>
                                                                                                        <br />
                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtinvDate1" Font-Size="XX-Small" ForeColor="Red" ErrorMessage="Invoice --> Please Enter Invoice Date" ValidationGroup="Invoice"></asp:RequiredFieldValidator>
                                                                                                    </div>

                                                                                                    <cc1:CalendarExtender ID="CalendarExtender3" PopupButtonID="imgPopup" CssClass="cal_Theme1" runat="server" TargetControlID="txtinvDate1" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"></cc1:CalendarExtender>


                                                                                                </div>

                                                                                                <p>Term Type</p>
                                                                                                <asp:DropDownList CssClass="drop" ID="DrpTerms" TabIndex="86" Height="28" Width="325"  runat="server" OnSelectedIndexChanged="DrpTerms_SelectedIndexChanged" AutoPostBack="true">
                                                                                                </asp:DropDownList>

                                                                                            </div>
                                                                                            <div class="col-sm-4">
                                                                                                <div class="row">
                                                                                                    <div class="col-sm-6">
                                                                                                        <asp:CheckBox Width="325" runat="server" ID="chkindicator" TabIndex="87" Text="Ad Valorem Indicator" Style="text-transform: none" />
                                                                                                    </div>
                                                                                                    <div class="col-sm-6">
                                                                                                        <asp:CheckBox Width="325"  runat="server" ID="chkrateind" TabIndex="88" Text="Preferential Duty Rate Indicator" Style="text-transform: none" />
                                                                                                    </div>
                                                                                                </div>
                                                                                                <br />
                                                                                                <div class="row">
                                                                                                    <p>Supplier Importer Relationship </p>
                                                                                                    <asp:DropDownList ID="DrpSupImpRel" CssClass="drop" Height="28" TabIndex="89" Width="325"  runat="server">
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
                                                                            </div>


                                                                            <hr />

                                                                            <div class="row">
                                                                                <br />
                                                                                <div class="col-sm-12">
                                                                                    <br /><br />
                                                                                    <div class="row" style="background: linear-gradient(-135deg, #c850c0, #4158d0); flex-align: stretch; color: white; width: 100%; height: 20px; margin-left: 7px;">
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

                                                                                            <asp:DropDownList ID="Drpcurrency1" CssClass="drop" OnSelectedIndexChanged="Drpcurrency1_SelectedIndexChanged" BackColor="#e8f0fe" AutoPostBack="true" AppendDataBoundItems="true" TabIndex="90" Width="70" runat="server">
                                                                                            </asp:DropDownList>


                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Text="0.00" ID="LblTotalInvoice" Enabled="false" Width="100"></asp:TextBox>
                                                                                            <%--<asp:Label runat="server" Text="0.00" ID="LblTotalInvoice"></asp:Label>--%>
                                                                                        </div>
                                                                                        <div class="col-sm-2">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" type="text" onfocus="removeCommas(this)" OnBlur="addCommas(this)" onkeypress="return isNumberKey(event)" Text="0.00" ID="TxtTotalInvoice" MaxLength="16" OnTextChanged="TxtTotalInvoice_TextChanged" AutoPostBack="true" TabIndex="91" Width="100" ValidationGroup="Item"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtTotalInvoice" ID="RegularExpressionValidator86" ValidationExpression="^[0-9\s\.]+$" runat="server" ErrorMessage="Not Accepted Special Charector" ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                        <div class="col-sm-2">
                                                                                            <asp:Label runat="server" Text="0.00" ID="SumTotalInvoice"></asp:Label>

                                                                                        </div>
                                                                                    </div>

                                                                                    <div class="row" runat="server" id="OtherTaxableCharge">
                                                                                        <div class="col-sm-4">
                                                                                            <p>Other Taxable Charge</p>
                                                                                        </div>
                                                                                        <div class="col-sm-2">
                                                                                            <asp:TextBox autocomplete="off"  onkeypress="return isNumberKey(event)"  runat="server" Text="0.00" ID="OtherTaxableChargePer" OnTextChanged="OtherTaxableChargePer_TextChanged" AutoPostBack="true" TabIndex="92" Width="100" Style="text-transform: uppercase"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:DropDownList ID="Drpcurrency2" CssClass="drop" OnSelectedIndexChanged="Drpcurrency2_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true" Width="70" TabIndex="93" runat="server">
                                                                                            </asp:DropDownList>


                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Text="0.00" ID="lblOtherTaxableCharge" Enabled="false" Width="100"></asp:TextBox>
                                                                                            <%--<asp:Label runat="server" Text="0.00" ID="lblOtherTaxableCharge"></asp:Label>--%>
                                                                                        </div>
                                                                                        <div class="col-sm-2">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" type="text" Text="0.00" onfocus="removeCommas(this)" OnBlur="addCommas(this)" onkeypress="return isNumberKey(event)" ID="TxtOtherTaxableCharge" MaxLength="16" OnTextChanged="TxtOtherTaxableCharge_TextChanged" AutoPostBack="true" TabIndex="94" Width="100" ValidationGroup="Item" Style="text-transform: uppercase"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtOtherTaxableCharge" ID="RegularExpressionValidator69" ValidationExpression="^[0-9\s\.]+$" runat="server" ErrorMessage="Not Accepted Special Charector" ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                        <div class="col-sm-2">
                                                                                            <asp:Label runat="server" Text="0.00" ID="SumOtherTaxableCharge"></asp:Label>
                                                                                        </div>
                                                                                    </div>

                                                                                    <div class="row" runat="server" id="FrieghtCharges">
                                                                                        <div class="col-sm-4">
                                                                                            <p>Frieght Charges( &nbsp;&nbsp;&nbsp;<asp:CheckBox runat="server" ID="CheckBox1" Text="Inculde Other Taxable Charge" TabIndex="85" />)</p>
                                                                                        </div>
                                                                                        <div class="col-sm-2">
                                                                                            <asp:TextBox autocomplete="off"  onkeypress="return isNumberKey(event)"  runat="server" Text="0.00" ID="FrieghtChargesPer" OnTextChanged="FrieghtChargesPer_TextChanged" AutoPostBack="true" TabIndex="95" Width="100" Style="text-transform: uppercase"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:DropDownList ID="Drpcurrency3" CssClass="drop" OnSelectedIndexChanged="Drpcurrency3_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true" TabIndex="96" Width="70" runat="server">
                                                                                            </asp:DropDownList>
                                                                                            <br />

                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Text="0.00" ID="LblFrieghtCharges" Width="100"></asp:TextBox>
                                                                                            <%--<asp:Label runat="server" Text="0.00" ID="LblFrieghtCharges"></asp:Label>--%>
                                                                                        </div>
                                                                                        <div class="col-sm-2">
                                                                                            <asp:TextBox autocomplete="off"   onkeypress="return isNumberKey(event)" runat="server" type="text" Text="0.00" ValidationGroup="Item" onfocus="removeCommas(this)" OnBlur="addCommas(this)" ID="TxtFrieghtCharges" OnTextChanged="TxtFrieghtCharges_TextChanged" AutoPostBack="true" TabIndex="97" Width="100" Style="text-transform: uppercase"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtFrieghtCharges" ID="RegularExpressionValidator70" ValidationExpression="^[0-9\s\.]+$" runat="server" ErrorMessage="Not Accepted Special Charector" ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                        <div class="col-sm-2">
                                                                                            <asp:Label runat="server" Text="0.00" ID="SumFrieghtCharges" Enabled="false"></asp:Label>
                                                                                        </div>
                                                                                    </div>

                                                                                    <div class="row" runat="server" id="InsuranceCharges">
                                                                                        <div class="col-sm-4">
                                                                                            <p>Insurance Charges( &nbsp;&nbsp;&nbsp;<asp:CheckBox runat="server" ID="chkchrge" TabIndex="98" Text="Inculde Other Taxable Charge" />)</p>
                                                                                        </div>
                                                                                        <div class="col-sm-2">
                                                                                            <asp:TextBox autocomplete="off"  onkeypress="return isNumberKey(event)"  runat="server" Text="0.00" ID="InsuranceChargesPer" OnTextChanged="InsuranceChargesPer_TextChanged" AutoPostBack="true" TabIndex="99" Width="100" Style="text-transform: uppercase"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:DropDownList ID="Drpcurrency4" CssClass="drop" OnSelectedIndexChanged="Drpcurrency4_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true" TabIndex="100" Width="70" runat="server">
                                                                                            </asp:DropDownList>
                                                                                            <br />

                                                                                        </div>
                                                                                        <div class="col-sm-1">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Text="0.00" ID="lblInsuranceCharges" Width="100"></asp:TextBox>
                                                                                            <%--<asp:Label runat="server" Text="0.00" ID="lblInsuranceCharges"></asp:Label>--%>
                                                                                        </div>
                                                                                        <div class="col-sm-2">
                                                                                            <asp:TextBox autocomplete="off"  onkeypress="return isNumberKey(event)"  runat="server" type="text" Text="0.00" onfocus="removeCommas(this)" OnBlur="addCommas(this)" ID="TxtInsuranceCharges" MaxLength="16" TabIndex="101" OnTextChanged="TxtInsuranceCharges_TextChanged" AutoPostBack="true" Width="100" ValidationGroup="Item" Style="text-transform: uppercase"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtInsuranceCharges" ID="RegularExpressionValidator71" ValidationExpression="^[0-9\s\.]+$" runat="server" ErrorMessage="Not Accepted Special Charector" ValidationGroup="Item"></asp:RegularExpressionValidator>
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
                                                                                            <asp:TextBox autocomplete="off"  onkeypress="return isNumberKey(event)"  Width="100" runat="server" Enabled="false" Text="7" ID="LblGSTpercentage"></asp:TextBox>
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
                                                                                            <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                                                                                                ShowSummary="False" ValidationGroup="Invoice" />
                                                                                        </div>
                                                                                        <div class="col-sm-4" >
                                                                                            <asp:Button ID="BtnAddInvoice" ValidationGroup="Invoice" runat="server" Visible="false" CssClass="btn btn-block btn-success" Text="Add Invoice" OnClick="BtnAddInvoice_Click" />

                                                                                        </div>


                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        
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



                                                                        <div id="InvoiceGrid" runat="server">
                                                                            <asp:TextBox autocomplete="off"  ID="AddInvoiceSearch" Visible="false" OnTextChanged="AddInvoiceSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                            <br />
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




                                                                        <%--  <ul class="pager">
                                                                    <li class="previous"><a href="#Header" tabindex ="53" data-toggle="tab" title="Previous">Previous</a></li>
                                                                    <li class="next"><a href="#Cargo" data-toggle="tab" tabindex ="54" title="Next">Next</a></li>
                                                                </ul>--%>
                                                                    </ContentTemplate>
                                                                    <%-- <Triggers>
                                                                        <asp:PostBackTrigger ControlID="btnprevinvoice" />
                                                                        <asp:PostBackTrigger ControlID="btnnextinvoice" />

                                                                    </Triggers>--%>
                                                                </asp:UpdatePanel>
                                                            </ContentTemplate>
                                                        </cc1:TabPanel>
                                                        <%--   </div>--%>

                                                        <%-- <div role="tabpanel" class="tab-pane fade" aria-labelledby="header-tab" id="Item">--%>
                                                        <cc1:TabPanel ID="Item" runat="server" HeaderText="Item">
                                                            <ContentTemplate>
                                                                <asp:UpdatePanel ID="upinitem" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>

                                                                        <div id="btnItemDiv" runat="server" visible="false" class="row">
                                                                            <div class="col-sm-8">
                                                                            </div>
                                                                            <div class="col-sm-4">
                                                                                <asp:Button ID="BtnAddNEWItem" runat="server" CssClass="btn btn-success btn-block" OnClick="BtnAddNEWItem_Click" Text="New Item" />
                                                                                <br />
                                                                            </div>
                                                                        </div>


                                                                        <div id="ItemDiv" runat="server">

                                                                            <div class="row">
                                                                                <div class="col-sm-4">
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail"  class="col-sm-3 col-form-label">
                                                                                            <p id="inhab" style="margin-left: -0px;" visible="false" runat="server">In HAWB/OBL</p>
                                                                                            <p id="inhbl" style="margin-left: -0px;" visible="false" runat="server">HBL</p>
                                                                                            <p id="phawb" style="margin-left: -0px;" runat="server">HAWB</p>
                                                                                        </label>
                                                                                        <div class="col-sm-9">

                                                                                            <asp:DropDownList   CssClass="drop" ID="TxtHAWB" runat="server" TabIndex="106" ValidationGroup="Item" Style="text-transform: uppercase" onblur="Frightforwardcheck();"></asp:DropDownList>
                                                                                           
                                                                                            <br />

                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtHAWB" ID="RegularExpressionValidator15" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>


                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail"  class="col-sm-3 col-form-label">
                                                                                            Term Type
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  ID="txttermtyp" runat="server" TabIndex="107" type="text" Style="text-transform: uppercase"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail"  class="col-sm-3 col-form-label">
                                                                                            Item Code
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  ID="TxtInHouseItem" OnTextChanged="TxtInHouseItem_TextChanged" AutoPostBack="true" runat="server" TabIndex="107" type="text" Style="text-transform: uppercase"></asp:TextBox>
                                                                                            <cc1:AutoCompleteExtender ServiceMethod="GetInhouse"
                                                                                                MinimumPrefixLength="1"
                                                                                                CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
                                                                                                TargetControlID="TxtInHouseItem"
                                                                                                ID="AutoCompleteExtender11" runat="server" FirstRowSelected="true">
                                                                                            </cc1:AutoCompleteExtender>


                                                                                        </div>
                                                                                    </div>

                                                                                    <div class="row">
                                                                                        <div class="col-sm-12 ">
                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblhserror" Visible="false" CssClass="hserror" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="Brown" runat="server"></asp:Label>
                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbldhserror" Visible="false" CssClass="hserror" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="Brown" runat="server"></asp:Label>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group row">



                                                                                        <label for="staticEmail"  class="col-sm-3 col-form-label">
                                                                                            HS Code
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  MaxLength="8" ID="TxtHSCodeItem" BackColor="#e8f0fe" OnTextChanged="TxtHSCodeItem_TextChanged" AutoPostBack="true" runat="server" TabIndex="108" type="text" Style="text-transform: uppercase"></asp:TextBox>




                                                                                            <cc1:AutoCompleteExtender ServiceMethod="GetHSCodeItem"
                                                                                                MinimumPrefixLength="1"
                                                                                                CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
                                                                                                TargetControlID="TxtHSCodeItem"
                                                                                                ID="AutoCompleteExtender12" runat="server" FirstRowSelected="true">
                                                                                            </cc1:AutoCompleteExtender>
                                                                                            <br />
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TxtHSCodeItem" Font-Size="XX-Small" ForeColor="Red" ErrorMessage="Item --> Please Enter HS Code" ValidationGroup="Item"></asp:RequiredFieldValidator>

                                                                                        </div>
                                                                                    </div>

                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail"  class="col-sm-3 col-form-label">
                                                                                            Description
                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  ID="TxtDescription" BackColor="#e8f0fe" OnTextChanged="TxtDescription_TextChanged" AutoPostBack="true" ValidationGroup="Item" Width="250" TextMode="MultiLine" Height="75" runat="server" TabIndex="92" type="text" MaxLength="512" Style="text-transform: uppercase; font-weight: bold;"></asp:TextBox>
                                                                                            <br />
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TxtDescription" Font-Size="XX-Small" ForeColor="Red" ErrorMessage="Item --> Please Enter HS Description" ValidationGroup="Item"></asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtDescription" ID="RegularExpressionValidator38" ValidationExpression="^[\s\S]{0,512}$" runat="server" ErrorMessage="Maximum 512 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                            <br />
                                                                                            <asp:Label ID="LblCount" runat="server" TabIndex="5"></asp:Label>
                                                                                        </div>
                                                                                    </div>

                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail"  class="col-sm-3 col-form-label">

                                                                                            <div class="row">
                                                                                                <div class="col-sm-1">
                                                                                                    COO
                                                                                                </div>
                                                                                                <div class="col-sm-2">

                                                                                                    <asp:ImageButton ID="btnorgincountry1" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" Style="margin-top: -250px;" />


                                                                                                </div>
                                                                                            </div>


                                                                                            <%-- <asp:Button ID="btnorgincountry" TabIndex="108" runat="server" Text="Search" />--%>
                                                                                            <%--<i class='fa fa-search' data-toggle="modal" data-target="#Country"></i>--%>
                                                                                        </label>
                                                                                        <cc1:ModalPopupExtender ID="popupcountryoforgin" runat="server" PopupControlID="pnlcountryoforgin" TargetControlID="btnorgincountry1"
                                                                                            OkControlID="btnyesco" CancelControlID="btnnoco" BackgroundCssClass="modalBackground">
                                                                                        </cc1:ModalPopupExtender>
                                                                                        <asp:Panel ID="pnlcountryoforgin" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                            <div class="header">
                                                                                                Origin Country
                                                                                            </div>
                                                                                            <div class="body">
                                                                                                <asp:UpdatePanel ID="upcountryoforgin" runat="server" UpdateMode="Conditional">



                                                                                                    <ContentTemplate>

                                                                                                        <asp:TextBox autocomplete="off"  ID="CountrySearchItem" OnTextChanged="CountrySearchItem_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                        <br />
                                                                                                        <%-- <asp:UpdatePanel ID="UpdatePanelCountry" runat="server"  UpdateMode="Always">

                                                            <ContentTemplate>--%>
                                                                                                        <asp:GridView ID="CountryGridItem" OnPageIndexChanging="CountryGridItem_PageIndexChanging" PageSize="5" AllowPaging="True" DataKeyNames="Id" CssClass="table table-striped table-bordered table-hover" OnRowDataBound="CountryGridItem_RowDataBound" OnRowCommand="CountryGridItem_RowCommand" runat="server" AutoGenerateColumns="false">
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

                                                                                                        <div class="footer" align="right">
                                                                                                            <asp:Button ID="btnyesco" runat="server" Text="Yes" CssClass="yes" />
                                                                                                            <asp:Button ID="btnnoco" runat="server" Text="No" CssClass="no" />

                                                                                                        </div>

                                                                                                    </ContentTemplate>
                                                                                                    <%-- <Triggers>
                                                                                                        <asp:PostBackTrigger ControlID="CountryGridItem" />
                                                                                                    </Triggers>--%>
                                                                                                </asp:UpdatePanel>
                                                                                            </div>
                                                                                        </asp:Panel>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  Width="75" ID="TxtCountryItem" BackColor="#e8f0fe" OnTextChanged="TxtCountryItem_TextChanged" AutoPostBack="true" runat="server" TabIndex="110" type="text" Style="text-transform: uppercase"></asp:TextBox>


                                                                                            <asp:TextBox autocomplete="off"  Width="175" ID="txtcname" TabIndex="111" runat="server" Enabled="false" Style="text-transform: uppercase"></asp:TextBox>
                                                                                            <cc1:AutoCompleteExtender ServiceMethod="GetCountryItem" MinimumPrefixLength="1" CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10" TargetControlID="TxtCountryItem" ID="AutoCompleteExtender13" runat="server" FirstRowSelected="true"></cc1:AutoCompleteExtender>
                                                                                            <br />
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TxtCountryItem" Font-Size="XX-Small" ForeColor="Red" ErrorMessage="Item --> Please Enter Country Of Orgin" ValidationGroup="Item"></asp:RequiredFieldValidator>

                                                                                        </div>
                                                                                    </div>


                                                                                   
                                                                                    <br />
                                                                                        <div class="form-group row">
                                                                                                  <div class="col-sm-12">
                                                                                       <asp:Button ID="btnprev" CssClass="previous" Enabled ="false" width="50px"  runat="server" class="btn btn-info btn-lg" OnClick="btnprev_Click" Text="<<"  /><asp:TextBox runat="server" id="itemno" Font-Bold="true" Width="100px" Enabled="false"></asp:TextBox> <asp:Button ID="btnnxt" CssClass="previous" Enabled ="false" width="50px" runat="server" class="btn btn-info btn-lg" OnClick="btnnxt_Click" Text=">>"  />
                                                                                                   </div>
                                                                                                    </div>
                                                                                       

                                                                                </div>
                                                                                        
                                                                                        
                                                                                        
                                                                                        
                                                                                        

                                                                                <div class="col-sm-4">

                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail"  class="col-sm-3 col-form-label">
                                                                                        </label>
                                                                                        <div class="col-sm-4">
                                                                                            <asp:CheckBox ID="ChkBGIndicator" Width="125" runat="server" Text="DG Indicator" TabIndex="112" Style="text-transform: uppercase" />

                                                                                        </div>
                                                                                        <div class="col-sm-4">
                                                                                            <asp:CheckBox ID="ChkUnbrand" Width="125" OnCheckedChanged="ChkUnbrand_CheckedChanged" TabIndex="113" AutoPostBack="true" runat="server" Text="Unbranded" Style="text-transform: uppercase" />
                                                                                        </div>
                                                                                    </div>

                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail"  class="col-sm-3 col-form-label">
                                                                                            Brand       


                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  ID="TxtBrand" MaxLength="35" ValidationGroup="Item" runat="server" TabIndex="114" type="text" Style="text-transform: uppercase"></asp:TextBox>
                                                                                            <br />
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TxtBrand" Font-Size="XX-Small" ForeColor="Red" ErrorMessage="Item --> Please Enter Brand" ValidationGroup="Item"></asp:RequiredFieldValidator>
                                                                                            <br />

                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtBrand" ID="RegularExpressionValidator3" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail"  class="col-sm-3 col-form-label">
                                                                                            Model    


                                                                                        </label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  ID="TxtModel" MaxLength="35" runat="server" ValidationGroup="Item" TabIndex="115" type="text" Style="text-transform: uppercase"></asp:TextBox>

                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtModel" ID="RegularExpressionValidator9" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>

                                                                                        </div>
                                                                                    </div>

                                                                                    <div id="Vehicle" runat="server">
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail"  class="col-sm-3 col-form-label">Vehicle Type</label>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:DropDownList ID="DrpVehicleType" CssClass="drop" runat="server" Height="25" TabIndex="116"></asp:DropDownList>

                                                                                            </div>
                                                                                        </div>

                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail"  class="col-sm-3 col-form-label">Engine Capacity</label>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:TextBox autocomplete="off"  runat="server" Width="150" onkeypress="return isNumberKey(event)" type="text" Text="" ID="TextBox4" TabIndex="117" Style="text-transform: uppercase"></asp:TextBox>
                                                                                                <asp:DropDownList CssClass="drop" ID="DrpVehicleCapacity" runat="server" Width="100" TabIndex="118"></asp:DropDownList>

                                                                                            </div>
                                                                                        </div>

                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail"  class="col-sm-3 col-form-label">Original Registration Date</label>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:TextBox autocomplete="off"  ID="OriginalRegDate" TabIndex="119" runat="server" OnTextChanged="OriginalRegDate_TextChanged" AutoPostBack="true" Style="text-transform: uppercase"></asp:TextBox>
                                                                                                <cc1:CalendarExtender ID="CalendarExtender4" CssClass="cal_Theme1" PopupButtonID="imgPopup" runat="server" TargetControlID="OriginalRegDate" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"></cc1:CalendarExtender>


                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div id="totDuticableQtyDiv" visible="false" runat="server">
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail"  class="col-sm-3 col-form-label">Duti Quantity</label>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:TextBox autocomplete="off"   onkeypress="return isNumberKey(event)"  runat="server" Width="150" type="text" ValidationGroup="Item" Text="0.00" MaxLength="16" ID="TxtTotalDutiableQuantity" OnTextChanged="TxtTotalDutiableQuantity_TextChanged" AutoPostBack="true" TabIndex="120"></asp:TextBox>
                                                                                                <asp:DropDownList CssClass="drop" ID="TDQUOM" runat="server" Width="100" TabIndex="121"></asp:DropDownList>
                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtTotalDutiableQuantity" ID="RegularExpressionValidator58" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>

                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail"  class="col-sm-3 col-form-label">TTL Duti Qty</label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"   runat="server" Width="150" type="text" onkeypress="return isNumberKey(event)" ValidationGroup="Item" Text="0.00" ID="txttotDutiableQty" MaxLength="16" OnTextChanged="txttotDutiableQty_TextChanged" AutoPostBack="true" TabIndex="122"></asp:TextBox>
                                                                                            <asp:DropDownList CssClass="drop" ID="ddptotDutiableQty" runat="server" Width="100" TabIndex="123"></asp:DropDownList>
                                                                                        </div>
                                                                                    </div>

                                                                                    <%-- Hs Quantity--%>
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail"  class="col-sm-3 col-form-label">Invoice Qty</label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" AutoPostBack="true" Width="250" ValidationGroup="Item" type="text" onkeypress="return isNumberKey(event)" OnTextChanged="TxtInvQty_TextChanged" Text="0.00" ID="TxtInvQty" TabIndex="124"></asp:TextBox>

                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtInvQty" ID="RegularExpressionValidator59" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>

                                                                                            <asp:Label runat="server" ID="lblinvqty" Visible="false" ForeColor="Red" BackColor="Yellow"></asp:Label>

                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail"  class="col-sm-3 col-form-label">Hs Quantity</label>
                                                                                        <div class="col-sm-9">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe" Width="150" Text="0.00" ValidationGroup="Item" type="text" onkeypress="return isNumberKey(event)" MaxLength="16" ID="TxtHSQuantity" TabIndex="125"></asp:TextBox>


                                                                                            <asp:DropDownList CssClass="drop" ID="HSQTYUOM" runat="server" OnSelectedIndexChanged="HSQTYUOM_SelectedIndexChanged" AutoPostBack="true" Width="100" TabIndex="126"></asp:DropDownList>

                                                                                            <br />
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TxtHSQuantity" Font-Size="XX-Small" ForeColor="Red" ErrorMessage="Item --> Please Enter HS QTY" ValidationGroup="Item"></asp:RequiredFieldValidator>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="HSQTYUOM" InitialValue="0" Font-Size="XX-Small" ForeColor="Red" ErrorMessage="Item --> Please Enter HS UOM" ValidationGroup="Item"></asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtHSQuantity" ID="RegularExpressionValidator62" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                            <br />
                                                                                            <asp:Label ID="LblHSErr" ForeColor="Red" runat="server"></asp:Label>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div id="AlcoholDiv" visible="false" runat="server">
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail"  class="col-sm-3 col-form-label">Alcohol Per(%)</label>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:TextBox autocomplete="off"  runat="server" ValidationGroup="Item" type="text" onkeypress="return isNumberKey(event)" Text="0.00" AutoPostBack="true" ID="txtAlcoholPer" OnTextChanged="txtAlcoholPer_TextChanged" TabIndex="127"></asp:TextBox>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>


                                                                                    <div class="form-group row">
                                                                                        <div class="col-sm-3">
                                                                                            <asp:CheckBox ID="ChkPackInfo" OnCheckedChanged="ChkPackInfo_CheckedChanged" runat="server" AutoPostBack="true" Text="Packing Info" TabIndex="137" Width="150" Style="text-transform: uppercase" />
                                                                                        </div>
                                                                                        <div class="col-sm-3">
                                                                                            <asp:CheckBox ID="Chkitemcasc" runat="server" OnCheckedChanged="Chkitemcasc_CheckedChanged" AutoPostBack="true" Text="Item CASC" TabIndex="146" Width="150" Style="text-transform: uppercase" />
                                                                                        </div>
                                                                                        <div class="col-sm-3">
                                                                                            <asp:CheckBox ID="ChkTariff" runat="server" OnCheckedChanged="ChkTariff_CheckedChanged" AutoPostBack="true" Checked="true" Text="Tariff" TabIndex="150" Width="150" Style="text-transform: uppercase" />
                                                                                        </div>
                                                                                        <div class="col-sm-3">
                                                                                            <asp:CheckBox ID="Chklot" runat="server" OnCheckedChanged="Chklot_CheckedChanged" AutoPostBack="true" Text="LOT Id" TabIndex="166" Width="150" Style="text-transform: uppercase" />
                                                                                        </div>




                                                                                    </div>

                                                                                  

                                                                                </div>
                                                                                <div class="col-sm-4">
                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail"  class="col-sm-4 col-form-label">Invoice</label>
                                                                                        <div class="col-sm-8">
                                                                                            <asp:DropDownList CssClass="drop" runat="server" type="text" Height="25" ID="DrpInvoiceNo" OnSelectedIndexChanged="DrpInvoiceNo_SelectedIndexChanged" AutoPostBack="true" TabIndex="128"></asp:DropDownList>

                                                                                        </div>
                                                                                    </div>

                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail"  class="col-sm-4 col-form-label">
                                                                                               Curr ( Unit Price 
                                                <asp:CheckBox ID="ChkUnitPrice" CausesValidation="true" OnCheckedChanged="ChkUnitPrice_CheckedChanged" AutoPostBack="true" runat="server" Style="text-transform: lowercase" />Auto )</label>
                                                                                        </label>
                                                                                        <div class="col-sm-8">
                                                                                            <asp:DropDownList CssClass="drop" ID="DRPCurrency" BackColor="#e8f0fe" CausesValidation="true" OnSelectedIndexChanged="DRPCurrency_SelectedIndexChanged" TabIndex="129" AutoPostBack="true" runat="server" Width="100"></asp:DropDownList>



                                                                                            <asp:TextBox autocomplete="off"  ID="TxtExchangeRate" Enabled="false" TabIndex="130" Text="0.00" runat="server" Width="135"></asp:TextBox>

                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="DRPCurrency" InitialValue="0" Font-Size="XX-Small" ForeColor="Red" ErrorMessage="Item --> Please Enter Invoice Currency" ValidationGroup="Item"></asp:RequiredFieldValidator>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="TxtExchangeRate" Font-Size="XX-Small" ForeColor="Red" ErrorMessage="Item --> Please Enter Invoice Currency EX Rate" ValidationGroup="Item"></asp:RequiredFieldValidator>
                                                                                        </div>
                                                                                    </div>

                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail"  class="col-sm-12 col-form-label">
                                                                                         

                                                                                    </div>


                                                                                    <div id="extrsItemDiv" runat="server" visible="false">
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail"  class="col-sm-3 col-form-label">
                                                                                                Unit Price Val
                                                                                            </label>
                                                                                            <div class="col-sm-7">
                                                                                                <asp:TextBox autocomplete="off"  runat="server" Text="0.00" ID="TxtUnitPrice" OnTextChanged="TxtUnitPrice_TextChanged" AutoPostBack="true" Width="115" TabIndex="104"></asp:TextBox>
                                                                                                <asp:TextBox autocomplete="off" Width="115"  runat="server" Visible="false" type="text" ID="TxtSumExRate" TabIndex="106" Text="0.00"></asp:TextBox>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div id="OptionalCharges" runat="server">
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail"  class="col-sm-3 col-form-label">
                                                                                                Optional Charges
                                                                                            </label>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:DropDownList CssClass="drop" ID="DrpOptionalUom" BackColor="#e8f0fe" CausesValidation="true" OnSelectedIndexChanged="DrpOptionalUom_SelectedIndexChanged" TabIndex="131" AutoPostBack="true" runat="server" Width="115"></asp:DropDownList>

                                                                                                <asp:TextBox autocomplete="off"  runat="server" Width="115" Text="0.00" ID="TxtOptionalPrice" OnTextChanged="TxtOptionalPrice_TextChanged" AutoPostBack="true" TabIndex="132"></asp:TextBox>

                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail"  class="col-sm-3 col-form-label">
                                                                                            </label>
                                                                                            <div class="col-sm-9">
                                                                                                <asp:TextBox autocomplete="off"  ID="TxtOptionalExchageRate" Enabled="false" TabIndex="133" Text="0.00" runat="server" Width="115"></asp:TextBox>

                                                                                                <asp:TextBox autocomplete="off"  runat="server" type="text" ID="TxtOptionalSumExRate" TabIndex="134" Width="115" Text="0.00"></asp:TextBox>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>

                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail"  class="col-sm-4 col-form-label">
                                                                                            Total Line Amt 
                                                                                        </label>
                                                                                        <div class="col-sm-8">
                                                                                            <asp:TextBox autocomplete="off" Width="235"  BackColor="#e8f0fe" onfocus="removeCommas(this)" onkeypress="return isNumberKey(event)" OnBlur="addCommas(this)" CausesValidation="true" OnTextChanged="TxtTotalLineAmount_TextChanged" ValidationGroup="Item" Text="0.00" AutoPostBack="true" runat="server" type="text" ID="TxtTotalLineAmount" TabIndex="134"></asp:TextBox>
                                                                                            <br />
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" InitialValue="0.00" ControlToValidate="TxtTotalLineAmount" Font-Size="XX-Small" ForeColor="Red" ErrorMessage="Item --> Please Enter Total Line Amount" ValidationGroup="Item"></asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtTotalLineAmount" ID="RegularExpressionValidator72" ValidationExpression="^[0-9\s\.\,]+$" runat="server" ErrorMessage="Not Accepted Special Charector" ValidationGroup="Item"></asp:RegularExpressionValidator>

                                                                                        </div>
                                                                                    </div>

                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail"  class="col-sm-4 col-form-label">
                                                                                            Total INV Chrg(SGD) 
                                                                                        </label>
                                                                                        <div class="col-sm-8">
                                                                                            <asp:TextBox autocomplete="off"  runat="server" Enabled="false" type="text" onfocus="removeCommas(this)" OnBlur="addCommas(this)"  Width="235" ID="TxtTotalLineCharges" Text="0.00" TabIndex="135"></asp:TextBox>

                                                                                        </div>
                                                                                    </div>

                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail"  class="col-sm-4 col-form-label">
                                                                                            CIF/FOB (SGD) 
                                                                                        </label>
                                                                                        <div class="col-sm-8">
                                                                                            <asp:TextBox autocomplete="off"  Width="235" runat="server" Enabled="false" type="text" onfocus="removeCommas(this)" OnBlur="addCommas(this)" ID="TxtCIFFOB" Text="0.00" TabIndex="135"></asp:TextBox>

                                                                                        </div>
                                                                                    </div>

                                                                                    <div class="form-group row">
                                                                                        <label for="staticEmail" class="col-sm-4 col-form-label">
                                                                                            Last Selling Price (SGD)
                                                                                        </label>
                                                                                        <div class="col-sm-8">
                                                                                            <asp:Label Font-Size="9" Text="Last selling Price (SGD)" ID="lblsp" Visible="false" runat="server"></asp:Label>
                                                                                            <asp:TextBox autocomplete="off"  runat="server"   onkeypress="return isNumberKey(event)" type="text"  Width="235" ID="txtlsp" Text="0.00" MaxLength="16" OnTextChanged="txtlsp_TextChanged" AutoPostBack="true" TabIndex="136"></asp:TextBox>
                                                                                        </div>

                                                                                    </div>
                                                                                                  



                                                                                    <div id="PackingInfo" visible="false" runat="server">
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail"  class="col-sm-4 col-form-label">
                                                                                                Outer Pack Qty

 
                                                                                            </label>
                                                                                            <div class="col-sm-8">
                                                                                                <asp:TextBox autocomplete="off"  runat="server" Text="0" MaxLength="8" type="text" onkeypress="return isNumberKey(event)" ValidationGroup="Item" Width="150" ID="TxtOPQty" AutoPostBack="true" OnTextChanged="TxtOPQty_TextChanged" TabIndex="138"></asp:TextBox>
                                                                                                <asp:DropDownList CssClass="drop" ID="DRPOPQUOM" runat="server" TabIndex="139" Width="75"></asp:DropDownList>
                                                                                                <br />
                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtOPQty" ID="RegularExpressionValidator64" ValidationExpression="^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 8 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>

                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail"  class="col-sm-4 col-form-label">
                                                                                                In Pack Qty

 
                                                                                            </label>
                                                                                            <div class="col-sm-8">
                                                                                                <asp:TextBox autocomplete="off"  runat="server" Text="0" MaxLength="8" type="text" onkeypress="return isNumberKey(event)" Width="150" OnTextChanged="TxtIPQty_TextChanged" AutoPostBack="true" ValidationGroup="Item" ID="TxtIPQty" TabIndex="140"></asp:TextBox>
                                                                                                <asp:DropDownList CssClass="drop" ID="DRPIPQUOM" runat="server" Width="75" TabIndex="141"></asp:DropDownList>

                                                                                                <br />
                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtIPQty" ID="RegularExpressionValidator63" ValidationExpression="^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 8 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>

                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail"  class="col-sm-4 col-form-label">
                                                                                                Inner Pack Qty

 
                                                                                            </label>
                                                                                            <div class="col-sm-8">
                                                                                                <asp:TextBox autocomplete="off"  runat="server" Text="0" Width="150" type="text" onkeypress="return isNumberKey(event)" MaxLength="8" ValidationGroup="Item" ID="TxtINPQty" OnTextChanged="TxtINPQty_TextChanged" AutoPostBack="true" TabIndex="142"></asp:TextBox>
                                                                                                <asp:DropDownList CssClass="drop" ID="DRPINNPQUOM" runat="server" Width="75" TabIndex="143"></asp:DropDownList>
                                                                                                <br />
                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtINPQty" ID="RegularExpressionValidator65" ValidationExpression="^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 8 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>

                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="form-group row">
                                                                                            <label for="staticEmail"  class="col-sm-4 col-form-label">
                                                                                                Inmost Pack Qty

 
                                                                                            </label>
                                                                                            <div class="col-sm-8">
                                                                                                <asp:TextBox autocomplete="off"  runat="server" Text="0" type="text" onkeypress="return isNumberKey(event)" MaxLength="8" OnTextChanged="TxtIMPQty_TextChanged" AutoPostBack="true" Width="150" ValidationGroup="Item" ID="TxtIMPQty" TabIndex="144"></asp:TextBox>
                                                                                                <asp:DropDownList CssClass="drop" ID="DRPIMPQUOM" runat="server" Width="75" TabIndex="145"></asp:DropDownList>

                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtIMPQty" ID="RegularExpressionValidator66" ValidationExpression="^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 8 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>

                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>

                                                                            <%--END--%>
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

                                                                                                        <%-- <asp:UpdatePanel ID="UpdatePanelInhouseItemCode" runat="server"  UpdateMode="Always">

                                                         <ContentTemplate>--%>
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
                                                                                                        <%--  </ContentTemplate>
                                                           	
                                                            </asp:UpdatePanel>--%>
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
                                                                                            <div class="col-sm-6" id="hs" runat="server" visible="false">

                                                                                                <p>Serial Number</p>
                                                                                                <asp:TextBox autocomplete="off"  runat="server" Visible="false" type="text" Enabled="false" ID="TxtSerialNo" TabIndex="90"></asp:TextBox>



                                                                                                <p>
                                                                                                    In-House Item Code
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<i class='fa fa-search' data-toggle="modal" data-target="#Inhouse"></i>
                                                                                                    <asp:Button Text="+" OnClick="Unnamed_Click" ValidationGroup="ItemMasterValidation5" ID="Btniteminhouse" runat="server" />
                                                                                                </p>



                                                                                                <p>HS Code &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<i class='fa fa-search' data-toggle="modal" data-target="#HSCode"></i></p>




                                                                                                <br />

                                                                                                <p>Description</p>





                                                                                            </div>

                                                                                            <div class="col-sm-6">
                                                                                                <div class="modal fade" id="Country" role="dialog">
                                                                                                    <div class="modal-dialog">

                                                                                                        <!-- Modal content-->
                                                                                                        <div class="modal-content">
                                                                                                            <div class="modal-header">
                                                                                                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                                                                                <h4 class="modal-title">Country 
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




                                                                                            </div>

                                                                                        </div>

                                                                                    </div>
                                                                                    <div class="col-sm-4">
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
                                                                                               
                                                                                                <div class="col-sm-4"> <a href="ExcelTemplate/InpaymentItemUpload.xlsx" class="btn1"  download>Download Item Excel Template Here</a>
                                                                                                
                                                                                                    </div>
                                                                                                <div class="col-sm-4">
                                                                                                    
                                                                                                    <asp:FileUpload Height="35" ID="FileUpload4" class="btn" runat="server" AllowMultiple="true" />
                                                                                                    <asp:Label runat="server" ID="Label3" />
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


                                                                                                            <div id="collapsep1" class="panel-collapse collapse-show  ">
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

                                                                                                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                                                                                                                <ContentTemplate>

                                                                                                                                    <div class="row">
                                                                                                                                        <div class="col-sm-3">
                                                                                                                                            <asp:Button ID="Button4" runat="server" Text="Copy Of HS-Quantity" OnClick="Button2_Click" />
                                                                                                                                            <p>Product Code &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnpc1" TabIndex="22" runat="server" Text="Search" /><%--<i class='fa fa-search' data-toggle="modal" data-target="#Product2"></i>--%></p>
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
                                                                                                                                                            <asp:TextBox autocomplete="off"  ID="ProductCode1Search" OnTextChanged="ProductCode1Search_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                                                                            <br />

                                                                                                                                                            No of Rows:
                                                                                                                                                             <asp:DropDownList ID="dropdownlist5" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropdownlist5_SelectedIndexChanged">
                                                                                                                                                                 <asp:ListItem>10</asp:ListItem>

                                                                                                                                                                 <asp:ListItem>20</asp:ListItem>

                                                                                                                                                                 <asp:ListItem>30</asp:ListItem>

                                                                                                                                                                 <asp:ListItem>All</asp:ListItem>

                                                                                                                                                             </asp:DropDownList>
                                                                                                                                                            <asp:GridView ID="ProductCode1Grid" PageSize="5" OnPageIndexChanging="ProductCode1Grid_PageIndexChanging" AllowPaging="True" DataKeyNames="Id" CssClass="table table-stri onped table-bordered table-hover" runat="server" OnRowCommand="ProductCode1Grid_RowCommand" OnRowDataBound="ProductCode1Grid_RowDataBound" AutoGenerateColumns="false">
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

                                                                                                                                            <asp:TextBox autocomplete="off"  runat="server" type="text" Width="150" ValidationGroup="Productcode" ID="TxtProductCode1" MaxLength="17" OnTextChanged="TxtProductCode1_TextChanged" AutoPostBack="true" TabIndex="147"></asp:TextBox>

                                                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProductCode1" ID="RegularExpressionValidator39" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>

                                                                                                                                            <p>Quantity</p>
                                                                                                                                            <asp:TextBox autocomplete="off"  Width="70" runat="server" type="text" ID="TxtProQty1" MaxLength="16" ValidationGroup="Productcode" TabIndex="148" Text="0.00"></asp:TextBox>
                                                                                                                                            <asp:DropDownList CssClass="drop" ID="DrpP1" runat="server" Width="70" Height="25" TabIndex="149"></asp:DropDownList>
                                                                                                                                            <br />
                                                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProQty1" ID="RegularExpressionValidator44" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>


                                                                                                                                        </div>
                                                                                                                                        <div class="col-sm-9">

                                                                                                                                            <asp:GridView CssClass="table table-striped table-bordered table-hover" ID="ProductCode1Grid1" runat="server" ShowFooter="true" AutoGenerateColumns="false">
                                                                                                                                                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                                                                <Columns>

                                                                                                                                                    <asp:BoundField DataField="Product Code    " HeaderText="Row Number" Visible="false" />

                                                                                                                                                    <asp:TemplateField HeaderText="CASC CODE 1">

                                                                                                                                                        <ItemTemplate>

                                                                                                                                                            <asp:TextBox autocomplete="off"  ID="TextBox1" MaxLength="35" Width="150" TabIndex="150" runat="server"></asp:TextBox>

                                                                                                                                                        </ItemTemplate>

                                                                                                                                                    </asp:TemplateField>

                                                                                                                                                    <asp:TemplateField HeaderText="CASC CODE 2">

                                                                                                                                                        <ItemTemplate>

                                                                                                                                                            <asp:TextBox autocomplete="off"  ID="TextBox2" MaxLength="35" Width="150" TabIndex="151" runat="server"></asp:TextBox>

                                                                                                                                                        </ItemTemplate>

                                                                                                                                                    </asp:TemplateField>

                                                                                                                                                    <asp:TemplateField HeaderText="CASC CODE 3">

                                                                                                                                                        <ItemTemplate>

                                                                                                                                                            <asp:TextBox autocomplete="off"  ID="TextBox3" MaxLength="35" Width="150" TabIndex="152" runat="server"></asp:TextBox>

                                                                                                                                                        </ItemTemplate>
                                                                                                                                                    </asp:TemplateField>
                                                                                                                                                    <asp:TemplateField HeaderText="ADD">
                                                                                                                                                        <ItemTemplate>
                                                                                                                                                            <asp:Button ID="ProductCode1Add" OnClick="ProductCode1Add_Click" runat="server" Text="Add" TabIndex="153" />
                                                                                                                                                        </ItemTemplate>




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
                                                                                                        <%-- PRODUCT cODE 2--%>


                                                                                                        <div class="panel panel-primary">
                                                                                                            <div class="panel-heading">
                                                                                                                <h4 class="panel-title">
                                                                                                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapsep1d">Product Code 2</a>
                                                                                                                </h4>
                                                                                                            </div>


                                                                                                            <div id="collapsep1d" class="panel-collapse collapse-show ">
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

                                                                                                                            <asp:UpdatePanel ID="uppc22" runat="server" UpdateMode="Conditional">
                                                                                                                                <ContentTemplate>

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

                                                                                                                                            <asp:TextBox autocomplete="off"  runat="server" type="text" Width="150" ValidationGroup="Productcode" ID="TxtProductCode2" MaxLength="17" OnTextChanged="TxtProductCode2_TextChanged" AutoPostBack="true" TabIndex="124"></asp:TextBox>

                                                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProductCode2" ID="RegularExpressionValidator40" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>

                                                                                                                                            <p>Quantity</p>
                                                                                                                                            <asp:TextBox autocomplete="off"  Width="70" runat="server" type="text" ID="TxtProQty2" MaxLength="16" ValidationGroup="Productcode" TabIndex="125"></asp:TextBox>
                                                                                                                                            <asp:DropDownList CssClass="drop" ID="DrpP2" runat="server" Width="70" Height="25" TabIndex="126"></asp:DropDownList>
                                                                                                                                            <br />
                                                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProQty2" ID="RegularExpressionValidator45" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>


                                                                                                                                        </div>
                                                                                                                                        <div class="col-sm-9">

                                                                                                                                            <asp:GridView CssClass="table table-striped table-bordered table-hover" ID="ProductCode2Grid1" runat="server" ShowFooter="true" AutoGenerateColumns="false">
                                                                                                                                                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                                                                <Columns>

                                                                                                                                                    <asp:BoundField DataField="Product Code    " HeaderText="Row Number" Visible="false" />

                                                                                                                                                    <asp:TemplateField HeaderText="CASC CODE 1">

                                                                                                                                                        <ItemTemplate>

                                                                                                                                                            <asp:TextBox autocomplete="off"  ID="TextBox1" MaxLength="35" Width="150" TabIndex="127" runat="server"></asp:TextBox>

                                                                                                                                                        </ItemTemplate>

                                                                                                                                                    </asp:TemplateField>

                                                                                                                                                    <asp:TemplateField HeaderText="CASC CODE 2">

                                                                                                                                                        <ItemTemplate>

                                                                                                                                                            <asp:TextBox autocomplete="off"  ID="TextBox2" MaxLength="35" Width="150" TabIndex="128" runat="server"></asp:TextBox>

                                                                                                                                                        </ItemTemplate>

                                                                                                                                                    </asp:TemplateField>

                                                                                                                                                    <asp:TemplateField HeaderText="CASC CODE 3">

                                                                                                                                                        <ItemTemplate>

                                                                                                                                                            <asp:TextBox autocomplete="off"  ID="TextBox3" MaxLength="35" Width="150" TabIndex="129" runat="server"></asp:TextBox>

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
                                                                                                            <div id="collapsep1dz" class="panel-collapse collapse-show ">
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

                                                                                                                            <asp:UpdatePanel ID="uppc33" runat="server" UpdateMode="Conditional">
                                                                                                                                <ContentTemplate>


                                                                                                                                    <div class="row">
                                                                                                                                        <div class="col-sm-3">

                                                                                                                                            <p>
                                                                                                                                                Product Code &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnpc3" TabIndex="22" runat="server" Text="Search" />
                                                                                                                                                <%--<i class='fa fa-search' data-toggle="modal" data-target="#Product3"></i>--%>
                                                                                                                                            </p>
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
                                                                                                                                                            <asp:GridView ID="ProductCode3Grid" PageSize="5" OnPageIndexChanging="ProductCode3Grid_PageIndexChanging" AllowPaging="True" DataKeyNames="Id" CssClass="table table-stri onped table-bordered table-hover" runat="server" OnSelectedIndexChanged="ProductCode3Grid_SelectedIndexChanged" OnSelectedIndexChanging="ProductCode3Grid_SelectedIndexChanging" OnRowCommand="ProductCode3Grid_RowCommand" OnRowDataBound="ProductCode3Grid_RowDataBound" AutoGenerateColumns="false">
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




                                                                                                                                            <asp:TextBox autocomplete="off"  runat="server" type="text" Width="150" MaxLength="17" ID="TxtProductCode3" ValidationGroup="Productcode" OnTextChanged="TxtProductCode3_TextChanged" AutoPostBack="true" TabIndex="130" Style="text-transform: uppercase"></asp:TextBox>
                                                                                                                                            <br />
                                                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProductCode3" ID="RegularExpressionValidator41" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>
                                                                                                                                            <br />
                                                                                                                                            <p>Quantity</p>
                                                                                                                                            <asp:TextBox autocomplete="off"  Width="70" runat="server" type="text" MaxLength="16" ValidationGroup="Productcode" ID="TxtProQty3" TabIndex="131"></asp:TextBox>


                                                                                                                                            <asp:DropDownList CssClass="drop" ID="DrpP3" runat="server" Width="70" Height="25" TabIndex="132"></asp:DropDownList>
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

                                                                                                                                                            <asp:TextBox autocomplete="off"  ID="TextBox1" MaxLength="35" Width="150" TabIndex="133" runat="server"></asp:TextBox>

                                                                                                                                                        </ItemTemplate>

                                                                                                                                                    </asp:TemplateField>

                                                                                                                                                    <asp:TemplateField HeaderText="CASC CODE 2">

                                                                                                                                                        <ItemTemplate>

                                                                                                                                                            <asp:TextBox autocomplete="off"  ID="TextBox2" MaxLength="35" Width="150" TabIndex="134" runat="server"></asp:TextBox>

                                                                                                                                                        </ItemTemplate>

                                                                                                                                                    </asp:TemplateField>

                                                                                                                                                    <asp:TemplateField HeaderText="CASC CODE 3">

                                                                                                                                                        <ItemTemplate>

                                                                                                                                                            <asp:TextBox autocomplete="off"  ID="TextBox3" MaxLength="35" Width="150" TabIndex="135" runat="server"></asp:TextBox>

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



                                                                                                                            <asp:UpdatePanel ID="uppc44" runat="server" UpdateMode="Conditional">
                                                                                                                                <ContentTemplate>

                                                                                                                                    <div class="row">
                                                                                                                                        <div class="col-sm-3">


                                                                                                                                            <p>
                                                                                                                                                Product Code &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnpc4" TabIndex="22" runat="server" Text="Search" />
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

                                                                                                                                            <asp:TextBox autocomplete="off"  runat="server" type="text" Width="150" ID="TxtProductCode4" MaxLength="17" ValidationGroup="Productcode" OnTextChanged="TxtProductCode4_TextChanged" AutoPostBack="true" TabIndex="241"></asp:TextBox>
                                                                                                                                            <br />
                                                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProductCode4" ID="RegularExpressionValidator42" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>
                                                                                                                                            <br />
                                                                                                                                            <p>Quantity</p>
                                                                                                                                            <asp:TextBox autocomplete="off"  Width="70" runat="server" type="text" ValidationGroup="Productcode" ID="TxtProQty4" MaxLength="16" TabIndex="242"></asp:TextBox>

                                                                                                                                            <asp:DropDownList CssClass="drop" ID="DrpP4" runat="server" Width="70" Height="25" TabIndex="243"></asp:DropDownList>

                                                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProQty4" ID="RegularExpressionValidator47" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>

                                                                                                                                        </div>
                                                                                                                                        <div class="col-sm-9">

                                                                                                                                            <asp:GridView CssClass="table table-striped table-bordered table-hover" ID="ProductCode4Grid1" runat="server" ShowFooter="true" AutoGenerateColumns="false">
                                                                                                                                                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                                                                <Columns>

                                                                                                                                                    <asp:BoundField DataField="RowNumber" HeaderText="Row Number" Visible="false" />

                                                                                                                                                    <asp:TemplateField HeaderText="CASC CODE 1">

                                                                                                                                                        <ItemTemplate>

                                                                                                                                                            <asp:TextBox autocomplete="off"  ID="TextBox1" MaxLength="35" Width="150" runat="server"></asp:TextBox>

                                                                                                                                                        </ItemTemplate>

                                                                                                                                                    </asp:TemplateField>

                                                                                                                                                    <asp:TemplateField HeaderText="CASC CODE 2">

                                                                                                                                                        <ItemTemplate>

                                                                                                                                                            <asp:TextBox autocomplete="off"  ID="TextBox2" MaxLength="35" Width="150" runat="server"></asp:TextBox>

                                                                                                                                                        </ItemTemplate>

                                                                                                                                                    </asp:TemplateField>

                                                                                                                                                    <asp:TemplateField HeaderText="CASC CODE 3">

                                                                                                                                                        <ItemTemplate>

                                                                                                                                                            <asp:TextBox autocomplete="off"  ID="TextBox3" MaxLength="35" Width="150" runat="server"></asp:TextBox>

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

                                                                                                                                            <br />

                                                                                                                                        </div>
                                                                                                                                        <div class="modal-footer">
                                                                                                                                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                                                                                                        </div>
                                                                                                                                    </div>

                                                                                                                                </div>
                                                                                                                            </div>


                                                                                                                            <asp:UpdatePanel ID="uppc55" runat="server" UpdateMode="Conditional">
                                                                                                                                <ContentTemplate>


                                                                                                                                    <div class="row">
                                                                                                                                        <div class="col-sm-3">
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



                                                                                                                                            <asp:TextBox autocomplete="off"  runat="server" Width="150" type="text" ID="TxtProductCode5" MaxLength="17" ValidationGroup="Productcode" OnTextChanged="TxtProductCode5_TextChanged" AutoPostBack="true" TabIndex="142"></asp:TextBox>
                                                                                                                                            <br />
                                                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProductCode5" ID="RegularExpressionValidator43" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>
                                                                                                                                            <br />
                                                                                                                                            <p>Quantity</p>
                                                                                                                                            <asp:TextBox autocomplete="off"  Width="70" runat="server" type="text" ValidationGroup="Productcode" ID="TxtProQty5" MaxLength="16" TabIndex="245"></asp:TextBox>

                                                                                                                                            <asp:DropDownList CssClass="drop" ID="DrpP5" runat="server" Width="70" Height="25" TabIndex="246"></asp:DropDownList>

                                                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProQty5" ID="RegularExpressionValidator48" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>

                                                                                                                                        </div>
                                                                                                                                        <div class="col-sm-9">

                                                                                                                                            <asp:GridView CssClass="table table-striped table-bordered table-hover" ID="ProductCode5Grid1" runat="server" ShowFooter="true" AutoGenerateColumns="false">
                                                                                                                                                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                                                                <Columns>

                                                                                                                                                    <asp:BoundField DataField="RowNumber" HeaderText="Row Number" Visible="false" />

                                                                                                                                                    <asp:TemplateField HeaderText="CASC CODE 1">

                                                                                                                                                        <ItemTemplate>

                                                                                                                                                            <asp:TextBox autocomplete="off"  ID="TextBox1" MaxLength="35" Width="150" runat="server"></asp:TextBox>

                                                                                                                                                        </ItemTemplate>

                                                                                                                                                    </asp:TemplateField>

                                                                                                                                                    <asp:TemplateField HeaderText="CASC CODE 2">

                                                                                                                                                        <ItemTemplate>

                                                                                                                                                            <asp:TextBox autocomplete="off"  ID="TextBox2" MaxLength="35" Width="150" runat="server"></asp:TextBox>

                                                                                                                                                        </ItemTemplate>

                                                                                                                                                    </asp:TemplateField>

                                                                                                                                                    <asp:TemplateField HeaderText="CASC CODE 3">

                                                                                                                                                        <ItemTemplate>

                                                                                                                                                            <asp:TextBox autocomplete="off"  ID="TextBox3" MaxLength="35" Width="150" runat="server"></asp:TextBox>

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
                                                                                                                <asp:DropDownList CssClass="drop" ID="DrpPreferentialCode" TabIndex="154" OnSelectedIndexChanged="DrpPreferentialCode_SelectedIndexChanged" AutoPostBack="true" runat="server" Width="250" Height="25"></asp:DropDownList>
                                                                                                            </div>
                                                                                                        </div>



                                                                                                    </div>
                                                                                                    <div class="col-sm-6">
                                                                                                    </div>
                                                                                                </div>


                                                                                                <br />

                                                                                                <div class="row" style="background: linear-gradient(-135deg, #c850c0, #4158d0); color: white; height: 20px;">
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
                                                                                                        GST (<asp:CheckBox ID="chk234" TabIndex="155" runat="server" AutoPostBack="true" OnCheckedChanged="chk234_CheckedChanged" />
                                                                                                        Auto-compute duties and taxes)
                                                                                                    </div>
                                                                                                    <div class="col-sm-2">
                                                                                                        <asp:TextBox autocomplete="off"    onkeypress="return isNumberKey(event)" ID="ItemGSTRate" runat="server" Enabled="false" Width="120" TabIndex="156" Text="7"></asp:TextBox>

                                                                                                    </div>
                                                                                                    <div class="col-sm-2">
                                                                                                        <asp:TextBox autocomplete="off"   ID="ItemGSTUOM" runat="server" Width="120" Enabled="false" TabIndex="157" Text="PER"></asp:TextBox>

                                                                                                    </div>
                                                                                                    <div class="col-sm-2">
                                                                                                        <asp:TextBox autocomplete="off"    onkeypress="return isNumberKey(event)" ID="TxtItemSumGST" runat="server" Width="120" onfocus="removeCommas(this)" OnBlur="addCommas(this)" Enabled="false" TabIndex="158" Text="0.00"></asp:TextBox>
                                                                                                    </div>
                                                                                                </div>


                                                                                                <div class="row">
                                                                                                    <div class="col-sm-6">
                                                                                                        Excise Duty  
                                                                                                    </div>
                                                                                                    <div class="col-sm-2">
                                                                                                        <asp:TextBox autocomplete="off"   onkeypress="return isNumberKey(event)"  ID="TxtExciseDutyRate" Enabled="false" runat="server" Width="120" TabIndex="159" Text="0.00"></asp:TextBox>
                                                                                                    </div>
                                                                                                    <div class="col-sm-2">
                                                                                                        <asp:TextBox autocomplete="off"  ID="TxtExciseDutyUOM" Enabled="false" runat="server" Width="120" TabIndex="157" Text="0.00"></asp:TextBox>
                                                                                                    </div>
                                                                                                    <div class="col-sm-2">
                                                                                                        <asp:TextBox autocomplete="off"   onkeypress="return isNumberKey(event)"  ID="TxtSumExciseDuty" Enabled="false" runat="server" Width="120" TabIndex="160" Text="0.00"></asp:TextBox>
                                                                                                    </div>
                                                                                                </div>

                                                                                                <div class="row">
                                                                                                    <div class="col-sm-6">
                                                                                                        <asp:Label ID="lblCustomsDuty" Text="Customs Duty" Width="120" runat="server"></asp:Label>
                                                                                                    </div>
                                                                                                    <div class="col-sm-2">
                                                                                                        <asp:TextBox autocomplete="off"   onkeypress="return isNumberKey(event)"  ID="TxtCustomsDutyRate" Enabled="false" runat="server" Width="120" TabIndex="161" Text="0.00"></asp:TextBox>
                                                                                                    </div>
                                                                                                    <div class="col-sm-2">
                                                                                                        <asp:TextBox autocomplete="off"  ID="TxtCustomsDutyUOM" Enabled="false" runat="server" Width="120" TabIndex="160" Text="0.00"></asp:TextBox>
                                                                                                    </div>
                                                                                                    <div class="col-sm-2">
                                                                                                        <asp:TextBox autocomplete="off"    onkeypress="return isNumberKey(event)"  ID="TxtSumCustomsDuty" Enabled="false" runat="server" Width="120" TabIndex="162" Text="0.00"></asp:TextBox>
                                                                                                    </div>
                                                                                                </div>

                                                                                                <div class="row">
                                                                                                    <div class="col-sm-6">
                                                                                                        Other Tax 
                                                                                                    </div>
                                                                                                    <div class="col-sm-2">
                                                                                                        <asp:TextBox autocomplete="off"   onkeypress="return isNumberKey(event)"  ID="TxtOtherTaxRate" runat="server" Width="120" TabIndex="163" Text="0.00"></asp:TextBox>
                                                                                                    </div>
                                                                                                    <div class="col-sm-2">
                                                                                                        <asp:DropDownList CssClass="drop" ID="DrpOtherUOM" Width="120" runat="server" TabIndex="164"></asp:DropDownList>
                                                                                                    </div>
                                                                                                    <div class="col-sm-2">
                                                                                                        <asp:TextBox autocomplete="off"    onkeypress="return isNumberKey(event)" ID="TxtSumOtherTaxRate" runat="server" Width="120" TabIndex="165" Text="0.00"></asp:TextBox>
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
                                                                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapse3">LOT ID</a>
                                                                                            </h4>
                                                                                        </div>
                                                                                        <div id="collapse3" class="panel-collapse collapse in">
                                                                                            <div class="panel-body">

                                                                                                <div class="row">
                                                                                                    <div class="col-sm-4">
                                                                                                        <p>Current Lot</p>
                                                                                                        <asp:TextBox autocomplete="off"  runat="server" type="text" ID="TxtCurrentLot" MaxLength="30" TabIndex="167" ValidationGroup="Item" class="w3-input w3-hover-green" Style="text-transform: uppercase"></asp:TextBox>
                                                                                                        <br />

                                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtCurrentLot" ID="RegularExpressionValidator17" ValidationExpression="^[\s\S]{0,30}$" runat="server" ErrorMessage="Maximum 30 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                                    </div>
                                                                                                    <div class="col-sm-4">
                                                                                                        <p>Marking </p>
                                                                                                        <asp:DropDownList CssClass="drop" Height="30" runat="server" TabIndex="168" ID="DrpMaking" Width="250" Style="text-transform: uppercase"></asp:DropDownList>
                                                                                                    </div>
                                                                                                    <div class="col-sm-4">
                                                                                                        <p>Previous Lot</p>
                                                                                                        <asp:TextBox autocomplete="off"  runat="server" type="text" ValidationGroup="Item" ID="TxtPreviousLot" MaxLength="30" TabIndex="169" class="w3-input w3-hover-green" Style="text-transform: uppercase"></asp:TextBox>
                                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtPreviousLot" ID="RegularExpressionValidator10" ValidationExpression="^[\s\S]{0,30}$" runat="server" ErrorMessage="Maximum 30 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                                    </div>
                                                                                                </div>


                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="panel panel-primary" id="SM" runat="server" visible="false">
                                                                                    <div class="panel-heading">
                                                                                        <h4 class="panel-title">
                                                                                            <a data-toggle="collapse" data-parent="#accordion" href="#collapse10">SHIPPING MARKS INFORMATION</a>
                                                                                        </h4>
                                                                                    </div>
                                                                                    <div id="collapse10" class="panel-collapse collapse ">
                                                                                        <div class="panel-body">
                                                                                            <div class="row">
                                                                                                <asp:ValidationSummary ID="ValidationSummary13" runat="server" ShowMessageBox="True"
                                                                                                    ShowSummary="False" ValidationGroup="Shipping" />
                                                                                                <div class="col-sm-3">
                                                                                                    <p>Shipping Marks 1</p>
                                                                                                    <asp:TextBox autocomplete="off"  runat="server" Width="250" Height="130" type="text" ID="txtShippingMarks1" ValidationGroup="Shipping" TabIndex="170" TextMode="MultiLine" Style="text-transform: uppercase"></asp:TextBox>
                                                                                                    <br />
                                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtShippingMarks1" ID="RegularExpressionValidator49" ValidationExpression="^[\s\S]{0,170}$" runat="server" ErrorMessage="Maximum 170 characters allowed." ValidationGroup="Shipping"></asp:RegularExpressionValidator>
                                                                                                </div>
                                                                                                <div class="col-sm-3">
                                                                                                    <p>Shipping Marks 2</p>
                                                                                                    <asp:TextBox autocomplete="off"  runat="server" Width="250" Height="130" type="text" ID="txtShippingMarks2" ValidationGroup="Shipping" TabIndex="171" TextMode="MultiLine" Style="text-transform: uppercase"></asp:TextBox>
                                                                                                    <br />
                                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtShippingMarks2" ID="RegularExpressionValidator50" ValidationExpression="^[\s\S]{0,170}$" runat="server" ErrorMessage="Maximum 170 characters allowed." ValidationGroup="Shipping"></asp:RegularExpressionValidator>
                                                                                                </div>
                                                                                                <div class="col-sm-3">
                                                                                                    <p>Shipping Marks 3</p>
                                                                                                    <asp:TextBox autocomplete="off"  runat="server" Width="250" Height="130" type="text" ID="txtShippingMarks3" ValidationGroup="Shipping" TabIndex="172" TextMode="MultiLine" Style="text-transform: uppercase"></asp:TextBox>
                                                                                                    <br />
                                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtShippingMarks3" ID="RegularExpressionValidator51" ValidationExpression="^[\s\S]{0,136}$" runat="server" ErrorMessage="Maximum 136 characters allowed." ValidationGroup="Shipping"></asp:RegularExpressionValidator>
                                                                                                </div>
                                                                                                <div class="col-sm-3">
                                                                                                    <p>Shipping Marks 4</p>
                                                                                                    <asp:TextBox autocomplete="off"  runat="server" Width="250" Height="130" type="text" ID="txtShippingMarks4" ValidationGroup="Shipping" TabIndex="173" TextMode="MultiLine" Style="text-transform: uppercase"></asp:TextBox>
                                                                                                    <br />
                                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtShippingMarks4" ID="RegularExpressionValidator52" ValidationExpression="^[\s\S]{0,36}$" runat="server" ErrorMessage="Maximum 36 characters allowed." ValidationGroup="Shipping"></asp:RegularExpressionValidator>
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
                                                                                    <asp:ValidationSummary ID="ValidationSummary4" runat="server" ShowMessageBox="True"
                                                                                        ShowSummary="False" ValidationGroup="Item" />
                                                                                    <div class="col-sm-4">
                                                                                        <asp:Button ID="BtnItemAdd" CssClass="btn btn-block btn-success" ValidationGroup="Item" runat="server" Visible="false" Text="Add Item" OnClick="BtnItemAdd_Click" />

                                                                                    </div>

                                                                                    <div class="col-sm-8">
                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                        </div>
                                                                        <br />

                                                                        <div class="row">
                                                                            <div class="col-sm-1">
                                                                             
                                                                            </div>
                                                                            <div class="col-sm-10">
                                                                                <center>
                                                                           
                                                                        <div class="btn-group btn-group-lg">
                                                                            <hr class="mt-4" />
<div class="flex justify-between gap-4 md:flex-nowrap flex-wrap mt-6">
    <asp:Button ID="btnprevitem" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" runat="server" class="btn btn-info btn-lg" OnClick="btnprevitem_Click" Text="Previous" TabIndex="174" />
    <div class="flex gap-4 flex-wrap md:flex-nowrap md:max-w-[260px] w-full">
        <asp:Button ID="btnresetitem" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" runat="server" class="btn btn-info btn-lg" OnClick="btnresetitem_Click" Text="Reset" TabIndex="176" />
        <asp:Button ID="btnsaveitem" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] bg-opacity-10 border hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-[#0560FD] text-center rounded-md text-sm sa700" runat="server" class="btn btn-info btn-lg" ValidationGroup="Item" OnClick="BtnItemAdd_Click" Text="+ Add Item" TabIndex="175" />

    </div>
    <asp:Button ID="btnnextitem" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" runat="server" class="btn btn-info btn-lg" OnClick="btnnextitem_Click" Text="Next" TabIndex="177" />

</div>
                                                                            </div>
                                                                                      </center>
                                                                            </div>
                                                                            <div class="col-sm-1">
                                                                            </div>
                                                                        </div>


                                                                        <div class="row">
                                                                            <div class="col-sm-3">
                                                                            </div>
                                                                            <div class="col-sm-6">
                                                                                <center>
                                                                           
                                                                        <div class="btn-group btn-group-lg">
                                                                    
                                                                            </div>
                                                                                      </center>
                                                                            </div>
                                                                            <div class="col-sm-3">
                                                                            </div>
                                                                        </div>


                                                                         <div class="row">
                                                                            <div class="col-sm-3">
                                                                            </div>
                                                                            <div class="col-sm-6">
                                                                                <center>
                                                                                  <asp:Label ID="lblitemalert" Visible="false" CssClass="hserror" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="Brown" runat="server"></asp:Label>
                                                                                    </center>
                                                                                </div>
                                                                             <div class="col-sm-3">
                                                                            </div>
                                                                        </div>

                                                                        <div id="ItemAddGrid" runat="server">
                                                                            <asp:TextBox autocomplete="off"  ID="AddItemSearch" OnTextChanged="AddItemSearch_TextChanged" Visible="false" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server" Style="text-transform: uppercase"></asp:TextBox>
                                                                            <br />
                                                                            <asp:GridView ID="AddItemGrid" Font-Size="10" OnRowDeleting="AddItemGrid_RowDeleting" PageSize="50" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="AddItemGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                                                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                <Columns>

                                                                                    <asp:TemplateField>

                                                                                        <HeaderTemplate>

                                                                                            <asp:CheckBox ID="chkAll" runat="server"
                                                                                                onclick="checkAll(this);" />

                                                                                        </HeaderTemplate>

                                                                                        <ItemTemplate>

                                                                                            <asp:CheckBox ID="chk" runat="server"
                                                                                                onclick="Check_Click(this)" />

                                                                                        </ItemTemplate>

                                                                                    </asp:TemplateField>

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

                                                                                    <asp:TemplateField HeaderText="HAWB" SortExpression="Id">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="InHAWBOBL" runat="server" Style="text-transform: uppercase"
                                                                                                Text='<%#Eval("InHAWBOBL")%>'>
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
                                                                            <asp:HiddenField ID="hfCount" runat="server" Value="0" />
                                                                            <asp:Button ID="btnDelete" runat="server" Text="Delete All" CssClass="nn" OnClientClick="return ConfirmDelete();" OnClick="btnDelete_Click" />
                                                                        </div>

                                                                        <%-- <ul class="pager">
                                                                    <li class="previous"><a href="#Invoice" data-toggle="tab" tabindex ="149" title="Previous">Previous</a></li>
                                                                    <li class="next"><a href="#CPC" tabindex ="150" data-toggle="tab" title="Next">Next</a></li>
                                                                </ul>--%>
                                                                    </ContentTemplate>
                                                                    <%-- <Triggers>
                                                                        <asp:PostBackTrigger ControlID="btnprevitem" />
                                                                        <asp:PostBackTrigger ControlID="btnnextitem" />

                                                                    </Triggers>--%>
                                                                </asp:UpdatePanel>
                                                            </ContentTemplate>
                                                        </cc1:TabPanel>
                                                        <%--</div>--%>
                                                        <%-- <div role="tabpanel" class="tab-pane fade" aria-labelledby="cpc-tab" id="CPC">--%>
                                                        <cc1:TabPanel ID="CPC" runat="server" HeaderText="CPC" >
                                                            <ContentTemplate>
                                                                <asp:UpdatePanel ID="upincpc" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <div class="row">
                                                                            <div class="col-sm-12">
                                                                                <div class="row">
                                                                                    <div class="col-sm-2">
                                                                                        <asp:CheckBox ID="chkaeo" OnCheckedChanged="chkaeo_CheckedChanged" AutoPostBack="true" runat="server" Text="AEO" TabIndex="178" Checked="false" Style="text-transform: uppercase" />
                                                                                    </div>
                                                                                    <div class="col-sm-10" id="AEO" runat="server">
                                                                                        <asp:Button ID="BtnAEO" runat="server" OnClick="BtnAEO_Click" Text="Add Row" TabIndex="179" />
                                                                                        <br />
                                                                                        <br />
                                                                                        <asp:GridView ID="AEOGrid" OnRowDeleting="AEOGrid_RowDeleting" OnRowDataBound="AEOGrid_RowDataBound" CssClass="table table-striped table-bordered table-hover" runat="server" ShowFooter="true" AutoGenerateColumns="false">
                                                                                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                            <Columns>

                                                                                                <asp:BoundField DataField="RowNumber" HeaderText="Row Number" Visible="false" />

                                                                                                <asp:TemplateField HeaderText="Processing Code1">

                                                                                                    <ItemTemplate>

                                                                                                        <asp:TextBox autocomplete="off"  ID="TextBox1" MaxLength="35" runat="server" TabIndex="180"></asp:TextBox>

                                                                                                    </ItemTemplate>

                                                                                                </asp:TemplateField>

                                                                                                <asp:TemplateField HeaderText="Processing Code2">

                                                                                                    <ItemTemplate>

                                                                                                        <asp:TextBox autocomplete="off"  ID="TextBox2" MaxLength="35" runat="server" TabIndex="181"></asp:TextBox>

                                                                                                    </ItemTemplate>

                                                                                                </asp:TemplateField>

                                                                                                <asp:TemplateField HeaderText="Processing Code3">

                                                                                                    <ItemTemplate>

                                                                                                        <asp:TextBox autocomplete="off"  ID="TextBox3" MaxLength="35" runat="server" TabIndex="182"></asp:TextBox>

                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Delete">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton OnClick="imgDelete_Click1" TabIndex="132" data-target='<%#"#"+DataBinder.Eval(Container.DataItem,"RowNumber")%>' Width="11" Height="11" ID="imgDelete" runat="server"><i class='fa fa-trash' style="color:red"></i></asp:LinkButton>

                                                                                                        <%--<div class="modal fade" id='<%#Eval("RowNumber")%>' role="dialog">
                                                                                                            <div class="modal-dialog">

                                                                                                                <!-- Modal content-->
                                                                                                                <div class="modal-content" style="width: 68%; left: 42%; top: 200px;">
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
                                                                                        <asp:CheckBox ID="chkcwc" OnCheckedChanged="chkcwc_CheckedChanged" TabIndex="183" AutoPostBack="true" runat="server" Text="CWC" Checked="false" Style="text-transform: uppercase" />
                                                                                    </div>
                                                                                    <div class="col-sm-10" id="CWC" runat="server">
                                                                                        <asp:Button ID="BtnCWC" runat="server" OnClick="BtnCWC_Click" Text="Add Row" TabIndex="184" />
                                                                                        <br />
                                                                                        <br />
                                                                                        <asp:GridView ID="CWCGrid" OnRowDeleting="CWCGrid_RowDeleting" CssClass="table table-striped table-bordered table-hover" runat="server" ShowFooter="true" AutoGenerateColumns="false">
                                                                                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                            <Columns>

                                                                                                <asp:BoundField DataField="RowNumber" HeaderText="Row Number" />

                                                                                                <asp:TemplateField HeaderText="Processing Code1">

                                                                                                    <ItemTemplate>

                                                                                                        <asp:TextBox autocomplete="off"  ID="TextBox1" MaxLength="35" TabIndex="185" runat="server"></asp:TextBox>

                                                                                                    </ItemTemplate>

                                                                                                </asp:TemplateField>

                                                                                                <asp:TemplateField HeaderText="Processing Code2">

                                                                                                    <ItemTemplate>

                                                                                                        <asp:TextBox autocomplete="off"  ID="TextBox2" MaxLength="35" TabIndex="186" runat="server"></asp:TextBox>

                                                                                                    </ItemTemplate>

                                                                                                </asp:TemplateField>

                                                                                                <asp:TemplateField HeaderText="Processing Code3">

                                                                                                    <ItemTemplate>

                                                                                                        <asp:TextBox autocomplete="off"  ID="TextBox3" MaxLength="35" TabIndex="187" runat="server"></asp:TextBox>

                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Delete">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton data-toggle="modal" TabIndex="189" Width="11" Height="11" ID="imgDelete" runat="server"><i class='fa fa-trash' style="color:red"></i></asp:LinkButton>

                                                                                                        <%--  <div class="modal fade" id='<%#Eval("RowNumber")%>' role="dialog">
                                                                                                            <div class="modal-dialog">

                                                                                                                <!-- Modal content-->
                                                                                                                <div class="modal-content" style="width: 68%; left: 42%; top: 200px;">
                                                                                                                    <div class="modal-header">
                                                                                                                    </div>
                                                                                                                    <div class="modal-footer">
                                                                                                                        <h4 class="modal-title">Are you sure to delete this Record?</h4>
                                                                                                                        <asp:Button ID="Button1" CommandName="delete" TabIndex="140" runat="server" OnClientClick='<%# DataBinder.Eval(Container.DataItem, "RowNumber", "javascript:return deletefunction(\"{0}\");")%> ' CssClass="btn btn-theme03 modal-add" Text="Yes"></asp:Button>
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
                                                                                        <asp:CheckBox ID="chkcnb" TabIndex="190" runat="server" Text="CNB" Checked="false" Style="text-transform: uppercase" />
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
                <asp:Button ID="btnprevcpc" runat="server" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" OnClick="btnprevcpc_Click" Text="Previous" TabIndex="191" />
                <asp:Button ID="btnnextcpc" runat="server" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" OnClick="btnnextcpc_Click" Text="Next" TabIndex="192" />
            </div>
        </center>
    </div>
    <div class="col-sm-3">
    </div>
</div>

                                                                    </ContentTemplate>
                                                                    <%-- <Triggers>
                                                                        <asp:PostBackTrigger ControlID="btnprevcpc" />
                                                                        <asp:PostBackTrigger ControlID="btnnextcpc" />

                                                                    </Triggers>--%>
                                                                </asp:UpdatePanel>
                                                            </ContentTemplate>
                                                        </cc1:TabPanel>
                                                        <%--</div>--%>
                                                        <%-- <div role="tabpanel" class="tab-pane fade" aria-labelledby="summery-tab" id="Summary">--%>
                                                        <cc1:TabPanel ID="Summery" runat="server" HeaderText="Summary" >
                                                            <ContentTemplate>
                                                                <asp:UpdatePanel ID="upinsummary" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <div class="col-sm-12">

                                                                            <asp:ValidationSummary ID="ValidationSummary11" runat="server" ShowMessageBox="True"
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
                                                                                                    <asp:TextBox autocomplete="off"  runat="server" Enabled="false"  Text="0.00" Width="100" ForeColor="red" Font-Names="verdana" Font-Size="small" Font-Bold="true" type="text" ID="txtnoofinv"></asp:TextBox>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="col-sm-3">
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-6 col-form-label">
                                                                                                    No of Items


                                                                                                </label>
                                                                                                <div class="col-sm-6">
                                                                                                    <asp:TextBox autocomplete="off"  runat="server" Enabled="false" Text="0.00" Width="100" ForeColor="red" Font-Names="verdana" Font-Size="small" Font-Bold="true" type="text" ID="txtnoofitm"></asp:TextBox>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="col-sm-3">
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-6 col-form-label">
                                                                                                    Sum of Item Amt


                                                                                                </label>
                                                                                                <div class="col-sm-6">
                                                                                                    <asp:TextBox autocomplete="off"  runat="server" Enabled="false" Text="0.00" Width="100" ForeColor="red" Font-Names="verdana" Font-Size="small" Font-Bold="true" type="text" ID="txtitmAmt"></asp:TextBox>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="col-sm-3">
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-6 col-form-label">
                                                                                                    Ttl Inv CIF Val

                                                                                                </label>
                                                                                                <div class="col-sm-6">
                                                                                                    <asp:TextBox autocomplete="off"  runat="server" Enabled="false" Text="0.00" Width="100" ForeColor="red" Font-Names="verdana" Font-Size="small" Font-Bold="true" type="text" ID="txtcifVal"></asp:TextBox>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="row">
                                                                                        <div class="col-sm-3">
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-6 col-form-label">
                                                                                                    Ttl CIF/FOB Val




                                                                                                </label>
                                                                                                <div class="col-sm-6">
                                                                                                    <asp:TextBox autocomplete="off"  runat="server" Enabled="false" Text="0.00" Width="100" type="text" ForeColor="red" Font-Names="verdana" Font-Size="small" Font-Bold="true" ID="txtfobval"></asp:TextBox>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="col-sm-3">
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-6 col-form-label">
                                                                                                    Ttl GST Amt



                                                                                                </label>
                                                                                                <div class="col-sm-6">
                                                                                                    <asp:TextBox autocomplete="off"  runat="server" Enabled="false" Text="0.00" Width="100" type="text" ForeColor="red" Font-Names="verdana" Font-Size="small" Font-Bold="true" ID="txttotgstAmt"></asp:TextBox>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="col-sm-3">
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-6 col-form-label">
                                                                                                    Ttl Exc Duty Amt




                                                                                                </label>
                                                                                                <div class="col-sm-6">
                                                                                                    <asp:TextBox autocomplete="off"  runat="server" Enabled="false" Width="100" Text="0.00" ForeColor="red" Font-Names="verdana" Font-Size="small" Font-Bold="true" type="text" ID="txttotexAmt"></asp:TextBox>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="col-sm-3">
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-6 col-form-label">
                                                                                                    Ttl Cus Duty Amt



                                                                                                </label>
                                                                                                <div class="col-sm-6">
                                                                                                    <asp:TextBox autocomplete="off"  runat="server" Enabled="false" Width="100" Text="0.00" ForeColor="red" Font-Names="verdana" Font-Size="small" Font-Bold="true" type="text" ID="txtcusdutyAmt"></asp:TextBox>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="row">
                                                                                        <div class="col-sm-3">
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-6 col-form-label">
                                                                                                    Ttl Other Tax Amt




                                                                                                </label>
                                                                                                <div class="col-sm-6">
                                                                                                    <asp:TextBox autocomplete="off"  runat="server" Enabled="false" Width="100" Text="0.00" ForeColor="red" Font-Names="verdana" Font-Size="small" Font-Bold="true" type="text" ID="txtothtaxAmt"></asp:TextBox>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="col-sm-3">
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-6 col-form-label">
                                                                                                    Ttl Amt Payable
                                                                                                </label>
                                                                                                <div class="col-sm-6">
                                                                                                    <asp:TextBox autocomplete="off"  runat="server" Width="100" Text="0.00" type="text" ForeColor="red" Font-Names="verdana" Font-Size="small" Font-Bold="true" ID="txtAmtPayble"></asp:TextBox>
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
                                                                                                    <asp:Label ID="lbltotinvAmt" Visible="false" Width="98px" runat="server" Text="0.00"></asp:Label>
                                                                                                    <%--<asp:TextBox autocomplete="off"  runat="server" type="text" ID="txtinvAmt" TabIndex="1"></asp:TextBox>--%>
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
                                                                                                    <asp:Label ID="Label1" Visible="false" Width="98px" Font-Size="Small" Font-Names="verdana" BorderWidth="2px" runat="server" Text="0.00"></asp:Label>
                                                                                                    <%--<asp:TextBox autocomplete="off"  runat="server" type="text" ID="txtinvAmt" TabIndex="1"></asp:TextBox>--%>
                                                                                                    <br />
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="row">
                                                                                        <asp:CheckBox ID="chkAuto" Enabled="true" Width="200" AutoPostBack="true" TabIndex="193" OnCheckedChanged="chkAuto_CheckedChanged" runat="server" Text="Auto-Compute" Style="text-transform: uppercase" />
                                                                                    </div>
                                                                                    <div class="row">
                                                                                        <div class="col-sm-12">
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" class="col-sm-6 col-form-label">
                                                                                                </label>
                                                                                                <div class="col-sm-6">




                                                                                                    <p id="cusremarks" runat="server" visible="false">Customer Remarks(will Not be Submitted to Singapore Customs)</p>
                                                                                                    <asp:TextBox autocomplete="off"  ID="txtcusRemrk" Visible="false" TabIndex="194" runat="server" TextMode="MultiLine" Height="70" Width="100%"></asp:TextBox>



                                                                                                </div>

                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                    
                                                                                    <div class="row">
                                                                                        <div class="col-sm-12">
                                                                                            Trader's Remarks(will be Submitted to Singapore Customs)
                                                                                                      <asp:Button ID="btninvnum" Css class="btn1 btn-primary " TabIndex="195"  runat="server" OnClick="btninvnum_Click" Text="Append Invoice Number" /><asp:Button  Css class="btn1 btn-primary "  ID="Button5" TabIndex="196" OnClick="Button3_Click" runat="server" Text="Append Ex Rate" /> &nbsp;&nbsp;Cross Reference   <asp:TextBox autocomplete="off"  runat="server" type="text" ID="TxtGrossReference" Style="text-transform: uppercase"></asp:TextBox>
                                                                                            <asp:TextBox autocomplete="off"  ID="txttrdremrk" ValidationGroup="Summery" runat="server" TextMode="MultiLine" MaxLength="1024" AutoPostBack="true" OnTextChanged="txttrdremrk_TextChanged" TabIndex="197" Height="70" Width="100%" Style="text-transform: uppercase; border-radius: 15px 50px 30px;"></asp:TextBox>
                                                                                            <br />
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txttrdremrk" ID="RegularExpressionValidator16" ValidationExpression="^[\s\S]{0,1024}$" runat="server" ErrorMessage="Maximum 1024 characters allowed." ValidationGroup="Summery"></asp:RegularExpressionValidator>
                                                                                            <br />
                                                                                            <asp:Label ID="lbltracunt" runat="server"></asp:Label>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="row">
                                                                                        <div class="col-sm-12">


                                                                                            <div class="form-group row">

                                                                                                <div class="col-sm-12">

                                                                                                    <p>INTERNAL REFERENCE</p>
                                                                                                    <asp:TextBox autocomplete="off"  ID="txtintremrk" runat="server" Height="70" TabIndex="198" Width="100%" Style="text-transform: uppercase"></asp:TextBox>
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
                                                                                                <label for="staticEmail"  class="col-sm-3 col-form-label">
                                                                                                    Importer


                                                                                                </label>
                                                                                                <div class="col-sm-9">
                                                                                                    <asp:Label ID="lblimporterparty" runat="server" Width="80%" Text="" Font-Size="Medium" Font-Bold="true"></asp:Label>
                                                                                                    <%--<asp:TextBox autocomplete="off"  runat="server" Enabled="false" Width="100" type="text" ID="TextBox25" TabIndex="1"></asp:TextBox>--%>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="col-sm-6">
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" style="text-transform: uppercase" class="col-sm-3 col-form-label">
                                                                                                    OBL


                                                                                                </label>
                                                                                                <div class="col-sm-9">
                                                                                                    <asp:Label ID="lbloblval" runat="server" Width="80%" Text="" Font-Size="Medium" Style="text-transform: uppercase" Font-Bold="true"></asp:Label>
                                                                                                    <%--<asp:TextBox autocomplete="off"  runat="server" Enabled="false" Width="100" type="text" ID="TextBox25" TabIndex="1"></asp:TextBox>--%>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="col-sm-6">
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" style="text-transform: uppercase" class="col-sm-3 col-form-label">
                                                                                                    HBL


                                                                                                </label>
                                                                                                <div class="col-sm-9">
                                                                                                    <asp:Label ID="lblhblValue" runat="server" Width="80%" Font-Size="Medium" Font-Bold="true"></asp:Label>
                                                                                                    <%--<asp:TextBox autocomplete="off"  runat="server" Enabled="false" Width="80%" type="text" ID="TextBox26" TabIndex="1"></asp:TextBox>--%>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="col-sm-6">
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail" style="text-transform: uppercase" class="col-sm-3 col-form-label">
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
                                                                                                <label for="staticEmail"  class="col-sm-3 col-form-label">
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
                                                                                                <label for="staticEmail"  class="col-sm-3 col-form-label">
                                                                                                    Invoice Amount

                                                                                                </label>
                                                                                                <div class="col-sm-9">
                                                                                                    <asp:Label ID="lblinvoiceAmt" runat="server" Width="80%" Font-Size="Medium" Font-Bold="true"></asp:Label>
                                                                                                    <%--<asp:TextBox autocomplete="off"  runat="server" Enabled="false" Width="100" type="text" ID="TextBox28" TabIndex="1"></asp:TextBox>--%>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="col-sm-6">
                                                                                            <div class="form-group row">
                                                                                                <label for="staticEmail"  class="col-sm-3 col-form-label">
                                                                                                    Total Item GST

                                                                                                </label>
                                                                                                <div class="col-sm-9">
                                                                                                    <asp:Label ID="lblTotItemGst" runat="server" Width="80%" Font-Size="Medium" Font-Bold="true"></asp:Label>
                                                                                                    <asp:Label ID="lblerror" runat="server" Width="80%" Font-Size="Medium" Font-Bold="true"></asp:Label>
                                                                                                    <%--<asp:TextBox autocomplete="off"  runat="server" Enabled="false" Width="100" type="text" ID="TextBox31" TabIndex="1"></asp:TextBox>--%>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="col-sm-12" id="DeclInd" runat="server" visible="false">
                                                                                            <div class="alert alert-danger">
                                                                                                <asp:CheckBox ID="chkDeclareInd" runat="server" TabIndex="198" Checked="false" />
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
                <asp:Button ID="btnprevsum" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" runat="server" OnClick="btnprevsum_Click" Text="Previous" TabIndex="199" />
                <asp:Button ID="btnnextsum" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" runat="server" OnClick="btnnextsum_Click" Text="Next" TabIndex="201" />
                <asp:Button ID="btnsavesum" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" runat="server" OnClick="btnsavesum_Click" Text="Save Permit" TabIndex="200" />
            </div>
        </center>
    </div>
</div>
                                                                        
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

                                                                                    <asp:Button ID="btnyes1" runat="server" Text="Continue" OnClick="btnyes_Click" />
                                                                                    <asp:Button ID="btnNo1" runat="server" Text="Cancel" OnClick="btnNo_Click" />sss
                                            
                                                                                </div>
                                                                                <div class="footer" align="right">

                                                                                    <asp:Button ID="Button6" runat="server" Text="Close" CssClass="yes" />
                                                                                </div>

                                                                            </asp:Panel>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                    <%-- <Triggers>
                                                                        <asp:PostBackTrigger ControlID="btnprevsum" />
                                                                        <asp:PostBackTrigger ControlID="btnnextsum" />

                                                                    </Triggers>--%>
                                                                </asp:UpdatePanel>
                                                            </ContentTemplate>
                                                        </cc1:TabPanel>
                                                        <%--</div>--%>



                                                        <%-- </div>--%>

                                                        <%-- <div role="tabpanel" class="tab-pane fade " id="Amend" runat="server" visible="false">--%>
                                                        <cc1:TabPanel ID="Amend" runat="server" Visible="false" HeaderText="Amend" > 
                                                            <ContentTemplate>
                                                                <asp:UpdatePanel ID="upinamend" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <div class="row">
                                                                            <div class="col-sm-12">
                                                                                <div class="row Borderdiv" style="width: 100%">Update Information</div>
                                                                                <div class="row">
                                                                                    <div class="col-sm-6">
                                                                                        <p>Amendment Count</p>
                                                                                        <asp:TextBox autocomplete="off"  runat="server" Width="300" type="text" Text="1" Enabled="false" ID="txtamoundcount" TabIndex="202"></asp:TextBox>
                                                                                        <br />
                                                                                        <p>Update Indicator</p>
                                                                                        <asp:TextBox autocomplete="off"  runat="server" Width="300" Text="AME" type="text" ID="txtupdateindicator" TabIndex="203" Style="text-transform: uppercase"></asp:TextBox>
                                                                                        <br />
                                                                                    </div>
                                                                                    <div class="col-sm-6">
                                                                                        <p>Permit Number</p>
                                                                                        <asp:TextBox autocomplete="off"  runat="server" Width="300" type="text" ID="txtamendpermit" TabIndex="204" Style="text-transform: uppercase"></asp:TextBox>
                                                                                        <br />
                                                                                        <p>Replacement Permit Number</p>
                                                                                        <asp:TextBox autocomplete="off"  runat="server" Width="300" type="text" ID="txtreplacepermit" TabIndex="205" Style="text-transform: uppercase"></asp:TextBox>
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
                                                                                <asp:TextBox autocomplete="off"  runat="server" TextMode="MultiLine" Width="100%" type="text" ID="txtdescreason" TabIndex="206" Style="text-transform: uppercase"></asp:TextBox>
                                                                                <br />
                                                                                <asp:CheckBox ID="ChkPermitvalEx" runat="server" TabIndex="207" Text="Permit Validity Extension" Style="text-transform: lowercase" />
                                                                                <br />
                                                                                <p>Extend Import Period (Reason for Extension of validity for Temporary / Exhibit Cargoes)</p>
                                                                                <asp:TextBox autocomplete="off"  runat="server" TextMode="MultiLine" Width="100%" type="text" ID="txtvalidity" TabIndex="208" Style="text-transform: uppercase"></asp:TextBox>
                                                                                <br />
                                                                                <br />
                                                                                <div class="row Borderdiv" style="width: 100%">Declaration Indicator</div>
                                                                                <div class="alert alert-danger" id="AmdInd" runat="server" visible="false">
                                                                                    <asp:CheckBox ID="chkdec" runat="server" Checked="false" TabIndex="209" Style="text-transform: lowercase" />
                                                                                    <strong></strong>I/We declare that all particulars in this application are true and correct
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="row">
                                                                            <div class="col-sm-3">
                                                                            </div>
                                                                            <div class="col-sm-6">

                                                                                <center>
                                                                           
                                                                        <div class="btn-group btn-group-lg" id="AmendBtn" runat="server" visible="false">
                                                                            <asp:Button ID="Button7" CssClass="nn"  runat="server" class="btn btn-info btn-lg" OnClick="btnprevsum_Click" Text="Previous" TabIndex="210" />
                                                                            <asp:Button ID="Button8" CssClass="nn"  runat="server" class="btn btn-info btn-lg" OnClick="btnsavesum_Click" Text="Save" TabIndex="211" />
                                                                           
                                                                            <asp:Button ID="Button10" CssClass="nn"  runat="server" class="btn btn-info btn-lg" OnClick="btnnextsum_Click" Text="Next" TabIndex="212" Visible="false" />
                                                                            </div>
                                                                                      </center>
                                                                            </div>
                                                                            <div class="col-sm-3">
                                                                            </div>
                                                                        </div>
                                                                        <br />

                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </ContentTemplate>
                                                        </cc1:TabPanel>
                                                        <%--</div>--%>

                                                        <%-- <div role="tabpanel" class="tab-pane fade " id="Cancel" runat="server" visible="false">--%>
                                                        <cc1:TabPanel ID="cancel" runat="server" Visible="false" HeaderText="cancel" >
                                                            <ContentTemplate>
                                                                <asp:UpdatePanel ID="upincancel" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <div class="row">
                                                                            <div class="col-sm-12">
                                                                                <div class="row Borderdiv" style="width: 100%">Update Information</div>
                                                                                <div class="row">
                                                                                    <div class="col-sm-6">
                                                                                        <p>Update Indicator</p>
                                                                                        <asp:TextBox autocomplete="off"  runat="server" Width="300" type="text" ID="txtupdateInd" TabIndex="213" Style="text-transform: uppercase"></asp:TextBox>
                                                                                        <br />


                                                                                    </div>
                                                                                    <div class="col-sm-6">
                                                                                        <p>Permit Number</p>
                                                                                        <asp:TextBox autocomplete="off"  runat="server" Width="300" type="text" ID="txtcanPermit" TabIndex="214" Style="text-transform: uppercase"></asp:TextBox>
                                                                                        <br />
                                                                                        <p>Replacement Permit Number</p>
                                                                                        <asp:TextBox autocomplete="off"  runat="server" Width="300" type="text" ID="txtcanrepPermit" TabIndex="215" Style="text-transform: uppercase"></asp:TextBox>
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
                                                                                <asp:DropDownList CssClass="drop" ID="DrpReasonCancel" TabIndex="216" Width="300" Height="26" runat="server"></asp:DropDownList>
                                                                            </div>
                                                                            <div class="col-sm-6">
                                                                                <p>Description For Reason</p>
                                                                                <asp:TextBox autocomplete="off"  runat="server" TextMode="MultiLine" Width="100%" type="text" ID="txtdesReason" TabIndex="217" Style="text-transform: uppercase"></asp:TextBox>
                                                                                <br />
                                                                            </div>
                                                                        </div>
                                                                        <br />
                                                                        <div class="row">
                                                                            <div class="col-sm-12" id="Div4" runat="server">

                                                                                <div class="row">


                                                                                    <div class="col-sm-12">
                                                                                        <div class="row Borderdiv" style="width: 100%">
                                                                                            Referance Document
                                                                                        </div>

                                                                                        <div class="row">
                                                                                            <div class="col-sm-5">
                                                                                                <p>Document Type</p>
                                                                                                <asp:DropDownList CssClass="drop" ID="DrpDocumenttype" BackColor="#e8f0fe" Width="250" ValidationGroup="valcan" Height="32" AppendDataBoundItems="true" TabIndex="218" runat="server">
                                                                                                </asp:DropDownList><br />

                                                                                            </div>
                                                                                            <div class="col-sm-5">
                                                                                                <p>Uplaod Document</p>
                                                                                                <asp:FileUpload ID="FileUpload2" BackColor="#e8f0fe" TabIndex="219" runat="server" ValidationGroup="valcan" class="btn" AllowMultiple="true" />

                                                                                            </div>
                                                                                            <div class="col-sm-2">
                                                                                                <p>Uplaod</p>
                                                                                                <asp:Button runat="server" ID="BtnCancelUp" TabIndex="220" ValidationGroup="valcan" class="btn btn-success" Text="Upload" OnClick="BtnCancelUp_Click" />

                                                                                            </div>
                                                                                        </div>


                                                                                        <hr />
                                                                                        <asp:GridView ID="GridCancelDoc" PageSize="5" OnRowDeleting="GridCancelDoc_RowDeleting" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="GridCancelDoc_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                                                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
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
                                                                            <div class="col-sm-12" id="AddRec" runat="server" visible="false">
                                                                                <div class="row Borderdiv" style="width: 100%">
                                                                                    ADDITIONAL RECIPIENTS
                                                                                </div>
                                                                                <br />
                                                                                <div class="row">
                                                                                    <div class="col-sm-4">
                                                                                        <p>RECIPIENTS 1</p>
                                                                                        <asp:TextBox autocomplete="off"  ID="TextBox15" Width="265" runat="server" TabIndex="221" type="text" Style="text-transform: uppercase"></asp:TextBox>

                                                                                        <br />
                                                                                    </div>
                                                                                    <div class="col-sm-4">
                                                                                        <p>RECIPIENTS 2</p>
                                                                                        <asp:TextBox autocomplete="off"  ID="TextBox16" Width="265" runat="server" TabIndex="222" type="text" Style="text-transform: uppercase"></asp:TextBox>

                                                                                        <br />
                                                                                    </div>
                                                                                    <div class="col-sm-4">
                                                                                        <p>RECIPIENTS 3</p>
                                                                                        <asp:TextBox autocomplete="off"  ID="TextBox17" Width="265" runat="server" TabIndex="223" type="text" Style="text-transform: uppercase"></asp:TextBox>

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
                                                                                    <asp:CheckBox ID="ChkCancelInd" runat="server" Checked="false" TabIndex="224" Style="text-transform: lowercase" />
                                                                                    <strong></strong>I/We declare that all particulars in this application are true and correct
                                                                                </div>

                                                                            </div>
                                                                        </div>
                                                                        <br />
                                                                        <div class="row">
                                                                            <div class="col-sm-3">
                                                                            </div>
                                                                            <div class="col-sm-6">

                                                                                <center>
                                                                           
                                                                        <div class="btn-group btn-group-lg" id="CancelBtn" runat="server" visible="false">
                                                                            <asp:Button ID="Button11" CssClass="nn"  runat="server" class="btn btn-info btn-lg" OnClick="btnprevsum_Click" Text="Previous" TabIndex="225" />
                                                                            <asp:Button ID="Button12" CssClass="nn"  runat="server" class="btn btn-info btn-lg" OnClick="btnsavesum_Click" Text="Save" TabIndex="226" />
                                                                           
                                                                            <asp:Button ID="Button14" CssClass="nn"  runat="server" class="btn btn-info btn-lg" OnClick="btnnextsum_Click" Text="Next" TabIndex="227" Visible="false" />
                                                                            </div>
                                                                                      </center>
                                                                            </div>
                                                                            <div class="col-sm-3">
                                                                            </div>
                                                                        </div>


                                                                    </ContentTemplate>
                                                                    <Triggers>
                                                                        <asp:PostBackTrigger ControlID="BtnCancelUp" />
                                                                    </Triggers>
                                                                </asp:UpdatePanel>
                                                            </ContentTemplate>
                                                        </cc1:TabPanel>
                                                        <%-- </div>--%>

                                                        <%-- <div role="tabpanel" class="tab-pane fade " id="Refund" runat="server" visible="false">--%>
                                                        <cc1:TabPanel ID="Refund" runat="server" Visible="false" HeaderText="Refund" >
                                                            <ContentTemplate>
                                                                <asp:UpdatePanel ID="upinrefund" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <div class="row">
                                                                            <div class="col-sm-12">
                                                                                <div class="row Borderdiv" style="width: 100%">Update Information</div>
                                                                                <div class="row">
                                                                                    <div class="col-sm-6">
                                                                                        <p>Update Indicator</p>
                                                                                        <asp:TextBox autocomplete="off"  runat="server" Width="300" type="text" ID="txtrenupdInd" TabIndex="228" Style="text-transform: uppercase"></asp:TextBox>
                                                                                        <br />


                                                                                    </div>
                                                                                    <div class="col-sm-6">
                                                                                        <p>Permit Number</p>
                                                                                        <asp:TextBox autocomplete="off"  runat="server" Width="300" type="text" ID="txtreundper" TabIndex="229" Style="text-transform: uppercase"></asp:TextBox>
                                                                                        <br />
                                                                                        <p>Replacement Permit Number</p>
                                                                                        <asp:TextBox autocomplete="off"  runat="server" Width="300" type="text" ID="txtrefundrepper" TabIndex="230" Style="text-transform: uppercase"></asp:TextBox>
                                                                                        <br />
                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                        </div>
                                                                        <br />
                                                                        <div class="row">
                                                                            <div class="row Borderdiv" style="width: 100%">Refund Information</div>
                                                                            <div class="col-sm-6">
                                                                                <p>Type For Refund</p>
                                                                                <asp:DropDownList CssClass="drop" ID="DrpTypeRefund" Width="300" Height="26" TabIndex="231" runat="server"></asp:DropDownList>
                                                                                <br />
                                                                                <p>Reason For Refund</p>
                                                                                <asp:DropDownList CssClass="drop" ID="DrpRefundReason" Width="300" TabIndex="210" Height="232" runat="server"></asp:DropDownList>
                                                                            </div>
                                                                            <div class="col-sm-6">
                                                                                <p>Description For Reason</p>
                                                                                <asp:TextBox autocomplete="off"  runat="server" TextMode="MultiLine" Width="100%" type="text" ID="txtrefudDes" TabIndex="233" Style="text-transform: uppercase"></asp:TextBox>
                                                                                <br />
                                                                            </div>
                                                                        </div>
                                                                        <br />
                                                                        <div class="row">
                                                                            <div class="row Borderdiv" style="width: 100%">Refund Information</div>
                                                                            <div class="col-sm-6">
                                                                                <p>Total GST Refund</p>
                                                                                <asp:TextBox autocomplete="off"  runat="server" Width="100%" type="text" ID="txtrefundgstAmt" TabIndex="234" Text="0.00" Style="text-transform: uppercase"></asp:TextBox>
                                                                                <br />
                                                                                <p>Toatl Excise Duty Refund</p>
                                                                                <asp:TextBox autocomplete="off"  runat="server" Width="100%" type="text" ID="txtExciseRefund" TabIndex="235" Text="0.00" Style="text-transform: uppercase"></asp:TextBox>
                                                                            </div>
                                                                            <div class="col-sm-6">
                                                                                <p>Total Customs Duty Refud</p>
                                                                                <asp:TextBox autocomplete="off"  runat="server" Width="100%" type="text" ID="txtCustomsRefund" TabIndex="236" Text="0.00" Style="text-transform: uppercase"></asp:TextBox>
                                                                                <br />
                                                                                <p>Total Other Tax Refud</p>
                                                                                <asp:TextBox autocomplete="off"  runat="server" Width="100%" type="text" ID="txtotherRefund" TabIndex="237" Text="0.00" Style="text-transform: uppercase"></asp:TextBox>
                                                                            </div>
                                                                        </div>

                                                                        <br />
                                                                        <div class="row" id="itemrefund" runat="server" visible="false">
                                                                            <div class="row Borderdiv" style="width: 100%">Item Refund</div>
                                                                            <div class="col-sm-4">
                                                                                <p>Item No</p>
                                                                                <asp:TextBox autocomplete="off"  runat="server" Width="100%" type="text" ID="txtItemNoRefund" TabIndex="238" Style="text-transform: uppercase"></asp:TextBox>
                                                                                <br />
                                                                                <p>Hs Code</p>
                                                                                <asp:TextBox autocomplete="off"  runat="server" Width="100%" type="text" ID="txthscoderefund" TabIndex="239" Style="text-transform: uppercase"></asp:TextBox>
                                                                            </div>
                                                                            <div class="col-sm-4">
                                                                                <p>Total GST Refund</p>
                                                                                <asp:TextBox autocomplete="off"  runat="server" Width="100%" type="text" ID="txtitemgstRefud" Text="0.00" TabIndex="240" Style="text-transform: uppercase"></asp:TextBox>
                                                                                <br />
                                                                                <p>Toatl Excise Duty Refund</p>
                                                                                <asp:TextBox autocomplete="off"  runat="server" Width="100%" type="text" ID="txtexciseDutyrefud" Text="0.00" TabIndex="241" Style="text-transform: uppercase"></asp:TextBox>
                                                                            </div>
                                                                            <div class="col-sm-4">
                                                                                <p>Total Customs Duty Refud</p>
                                                                                <asp:TextBox autocomplete="off"  runat="server" Width="100%" type="text" ID="txttotCusitemamt" Text="0.00" TabIndex="242" Style="text-transform: uppercase"></asp:TextBox>
                                                                                <br />
                                                                                <p>Total Other Tax Refud</p>
                                                                                <asp:TextBox autocomplete="off"  runat="server" Width="100%" type="text" ID="tztotheritem" Text="0.00" TabIndex="243" Style="text-transform: uppercase"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="row">
                                                                            <div class="col-sm-10">
                                                                                <asp:Button ID="AddItem" runat="server" OnClick="AddItem_Click" Text="Add Row" TabIndex="244" />
                                                                                <br />
                                                                                <br />
                                                                                <asp:GridView ID="RefundItem" OnRowDeleting="RefundItem_RowDeleting" OnRowDataBound="RefundItem_RowDataBound" CssClass="table table-striped table-bordered table-hover" runat="server" ShowFooter="true" AutoGenerateColumns="false">
                                                                                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                    <Columns>

                                                                                        <asp:BoundField DataField="RowNumber" HeaderText="Row Number" Visible="false" />

                                                                                        <asp:TemplateField HeaderText="ItemNo">

                                                                                            <ItemTemplate>

                                                                                                <asp:TextBox autocomplete="off"  ID="TextBox1" MaxLength="35" runat="server"></asp:TextBox>

                                                                                            </ItemTemplate>

                                                                                        </asp:TemplateField>

                                                                                        <asp:TemplateField HeaderText="Hs Code">

                                                                                            <ItemTemplate>

                                                                                                <asp:TextBox autocomplete="off"  ID="TextBox2" MaxLength="35" runat="server"></asp:TextBox>

                                                                                            </ItemTemplate>

                                                                                        </asp:TemplateField>

                                                                                        <asp:TemplateField HeaderText="Total GST Refund">
                                                                                            <ItemTemplate>
                                                                                                <asp:TextBox autocomplete="off"  ID="TextBox3" MaxLength="35" runat="server" Text="0.00"></asp:TextBox>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Toatl Excise Duty Refund">
                                                                                            <ItemTemplate>
                                                                                                <asp:TextBox autocomplete="off"  ID="TextBox4" MaxLength="35" runat="server" Text="0.00"></asp:TextBox>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Total Customs Duty Refud">
                                                                                            <ItemTemplate>
                                                                                                <asp:TextBox autocomplete="off"  ID="TextBox5" MaxLength="35" runat="server" Text="0.00"></asp:TextBox>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Total Other Tax Refud">
                                                                                            <ItemTemplate>
                                                                                                <asp:TextBox autocomplete="off"  ID="TextBox6" MaxLength="35" runat="server" Text="0.00"></asp:TextBox>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Delete">
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton OnClick="imgDelete_Click1" TabIndex="132" data-target='<%#"#"+DataBinder.Eval(Container.DataItem,"RowNumber")%>' Width="11" Height="11" ID="imgDelete" runat="server"><i class='fa fa-trash' style="color:red"></i></asp:LinkButton>

                                                                                                <%--<div class="modal fade" id='<%#Eval("RowNumber")%>' role="dialog">
                                                                                                            <div class="modal-dialog">

                                                                                                                <!-- Modal content-->
                                                                                                                <div class="modal-content" style="width: 68%; left: 42%; top: 200px;">
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
                                                                        <br />
                                                                        <div class="row">
                                                                            <div class="col-sm-12" id="Div5" runat="server">

                                                                                <div class="row">


                                                                                    <div class="col-sm-12">
                                                                                        <div class="row Borderdiv" style="width: 100%">
                                                                                            Referance Document
                                                                                        </div>

                                                                                        <div class="row">
                                                                                            <div class="col-sm-5">
                                                                                                <p>Document Type</p>
                                                                                                <asp:DropDownList CssClass="drop" ID="DrprefundDocType" BackColor="#e8f0fe" Width="250" Height="32" AppendDataBoundItems="true" TabIndex="245" runat="server">
                                                                                                </asp:DropDownList><br />

                                                                                            </div>
                                                                                            <div class="col-sm-5">
                                                                                                <p>Uplaod Document</p>
                                                                                                <asp:FileUpload ID="FileUpload3" BackColor="#e8f0fe" TabIndex="246" runat="server" class="btn" AllowMultiple="true" />

                                                                                            </div>
                                                                                            <div class="col-sm-2">
                                                                                                <p>Uplaod</p>
                                                                                                <asp:Button runat="server" ID="BtnRefundUp" ValidationGroup="Validationbtn" TabIndex="247" class="btn btn-success" Text="Upload" OnClick="BtnRefundUp_Click" />

                                                                                            </div>
                                                                                        </div>


                                                                                        <hr />
                                                                                        <asp:GridView ID="GridRefundDoc" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="GridRefundDoc_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                                                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                            <Columns>
                                                                                                <asp:TemplateField HeaderText="Delete">
                                                                                                    <ItemTemplate>

                                                                                                        <asp:LinkButton data-target='<%#"#"+DataBinder.Eval(Container.DataItem,"Id")%>' Width="11" OnClick="RefundDocDelete_Click" Height="11" ID="RefundDocDelete" runat="server"><i class='fa fa-trash' style="color:red;"> </i></asp:LinkButton>



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
                                                                                        <asp:TextBox autocomplete="off"  ID="txtrefaddd1" Width="265" runat="server" TabIndex="248" type="text" Style="text-transform: uppercase"></asp:TextBox>

                                                                                        <br />
                                                                                    </div>
                                                                                    <div class="col-sm-4">
                                                                                        <p>RECIPIENTS 2</p>
                                                                                        <asp:TextBox autocomplete="off"  ID="txtrefadd2" Width="265" runat="server" TabIndex="249" type="text" Style="text-transform: uppercase"></asp:TextBox>

                                                                                        <br />
                                                                                    </div>
                                                                                    <div class="col-sm-4">
                                                                                        <p>RECIPIENTS 3</p>
                                                                                        <asp:TextBox autocomplete="off"  ID="txtrefadd3" Width="265" runat="server" TabIndex="250" type="text" Style="text-transform: uppercase"></asp:TextBox>

                                                                                        <br />
                                                                                    </div>
                                                                                </div>
                                                                                <br />
                                                                                <br />
                                                                            </div>
                                                                        </div>
                                                                        <br />
                                                                        <div class="row">
                                                                            <div class="col-sm-12" id="RefundInd" runat="server" visible="false">
                                                                                <div class="row Borderdiv" style="width: 100%">Declarent Indicator</div>
                                                                                <div class="alert alert-danger" id="REFDecl" runat="server">
                                                                                    <asp:CheckBox ID="ChkRefundInd" runat="server" Checked="false" TabIndex="251" Style="text-transform: lowercase" />
                                                                                    <strong></strong>I/We declare that all particulars in this application are true and correct
                                                                                </div>

                                                                            </div>
                                                                        </div>
                                                                        div class="row">
                                                                            <div class="col-sm-3">
                                                                            </div>
                                                                        <div class="col-sm-6">

                                                                            <center>
                                                                           
                                                                        <div class="btn-group btn-group-lg" id="RefundDiv" runat="server" visible="false">
                                                                            <asp:Button ID="Button15" CssClass="nn"  runat="server" class="btn btn-info btn-lg" OnClick="btnprevsum_Click" Text="Previous" TabIndex="252" />
                                                                            <asp:Button ID="Button16" CssClass="nn"  runat="server" class="btn btn-info btn-lg" OnClick="btnsavesum_Click" Text="Save" TabIndex="253" />
                                                                            
                                                                            <asp:Button ID="Button18" CssClass="nn"  runat="server" class="btn btn-info btn-lg" OnClick="btnnextsum_Click" Text="Next" TabIndex="254" Visible="false" />
                                                                            </div>
                                                                                      </center>
                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                        </div>
                                                                        </div>

                                                                    </ContentTemplate>
                                                                    <Triggers>
                                                                        <asp:PostBackTrigger ControlID="BtnRefundUp" />
                                                                    </Triggers>
                                                                </asp:UpdatePanel>
                                                            </ContentTemplate>



                                                        </cc1:TabPanel>
                                                        <%-- </div>--%>
                                                    </cc1:TabContainer>
                                                    <%--</div>--%>
                                                </div>

                                        

                        </div>


                    </ContentTemplate>


                </asp:UpdatePanel>



            </div>



        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
