<%@ Page Title="" ClientIDMode="AutoID" Language="C#" MasterPageFile="~/Home.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Inpayment.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="RET.Inpayment" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>




    <style>
        .disabled\:text-slate-300:disabled {
            --tw-text-opacity: 1;
            color: rgb(0 0 0) !important;
        }
    </style>

    <script>
        function toUpperCaseText(ctrl) {
            ctrl.value = ctrl.value.toUpperCase();
        }
    </script>

    <style>
        .text-slate-300 {
            color: rgb(0 0 0) !important;
        }
    </style>
    <script>

        function fileUpload() {

            $("#ctl00_ContentPlaceHolder1_TabContainer1_Header_Btn_Upload").click();
        };
        function myFunction() {

            $("#inpayment").css('color', 'White');

            $("#inpayment").css('background-color', 'Black');
        }
        function drop_draft() {
            document.getElementById("drop_draft_area").classList.toggle("hidden");
            document
                .getElementById("drop_draft_Svg")
                .classList.toggle("rotate-180");
        }
        function drop_draft_1() {
            document.getElementById("drop_draft_1_area").classList.toggle("hidden");
            document
                .getElementById("drop_draft_1_Svg")
                .classList.toggle("rotate-180");
        }
        function drop_draft_2() {
            document.getElementById("drop_draft_2_area").classList.toggle("hidden");
            document
                .getElementById("drop_draft_2_Svg")
                .classList.toggle("rotate-180");
        }
        function drop_draft_3() {
            document.getElementById("drop_draft_3_area").classList.toggle("hidden");
            document
                .getElementById("drop_draft_3_Svg")
                .classList.toggle("rotate-180");
        }
        function drop_draft_SM() {
            document.getElementById("drop_draft_1_SM").classList.toggle("hidden");
            document
                .getElementById("drop_draft_1_Svg")
                .classList.toggle("rotate-180");
        }
        function openTab(tabId) {
            var tabContainer = $find("<%= TabContainer1.ClientID %>");
            tabContainer.set_activeTabIndex(tabId - 1);
        }
    </script>

    <link href="css/style.css?abc=1" rel="stylesheet" />
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
            width: 1200px;
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
                font-size: 16px;
            }

            .modalPopup .body {
                min-height: 50px;
                line-height: 30px;
                text-align: center;
                font-weight: bold;
            }

            .modalPopup .footer {
                padding: 6px 15px;
                border-top: 1px solid #ddd;
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

        table tr td {
            text-align: left;
            padding: 5px;
        }

        table tr th {
            text-align: left;
            padding: 5px;
            color: rgb(107 114 128 / 1);
            font-weight: 500;
            text-align: left;
        }

        table tr td span {
            color: rgb(100 116 139 / 1);
            font-weight: 500;
            font-size: 0.75rem;
        }

        table tr:first-of-type {
            background-color: rgb(223, 227, 235);
            height: 2.5rem;
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









        //Validation Function


    </script>
    <style type="text/css">
        .overlay {
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

    <asp:UpdateProgress ID="UpdateProgress" class="theme_loader" runat="server" AssociatedUpdatePanelID="updatepanel1">
        <ProgressTemplate>
            <div class="overlay">
                <div style="z-index: 1000; margin-top: 300px; opacity: 1; -moz-opacity: 1;">
                    <center>
                        <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" viewBox="0 0 100 100" preserveAspectRatio="xMidYMid" width="200" height="200" style="shape-rendering: auto; display: block; background: rgba(255, 255, 255, 0);">
                            <g>
                                <g transform="rotate(0 50 50)">
                                    <rect fill="#0560fd" height="12" width="6" ry="6" rx="3" y="24" x="47">
                                        <animate repeatCount="indefinite" begin="-0.9166666666666666s" dur="1s" keyTimes="0;1" values="1;0" attributeName="opacity" />
                                    </rect>
                                </g>
                                <g transform="rotate(30 50 50)">
                                    <rect fill="#0560fd" height="12" width="6" ry="6" rx="3" y="24" x="47">
                                        <animate repeatCount="indefinite" begin="-0.8333333333333334s" dur="1s" keyTimes="0;1" values="1;0" attributeName="opacity" />
                                    </rect>
                                </g>
                                <g transform="rotate(60 50 50)">
                                    <rect fill="#0560fd" height="12" width="6" ry="6" rx="3" y="24" x="47">
                                        <animate repeatCount="indefinite" begin="-0.75s" dur="1s" keyTimes="0;1" values="1;0" attributeName="opacity" />
                                    </rect>
                                </g>
                                <g transform="rotate(90 50 50)">
                                    <rect fill="#0560fd" height="12" width="6" ry="6" rx="3" y="24" x="47">
                                        <animate repeatCount="indefinite" begin="-0.6666666666666666s" dur="1s" keyTimes="0;1" values="1;0" attributeName="opacity" />
                                    </rect>
                                </g>
                                <g transform="rotate(120 50 50)">
                                    <rect fill="#0560fd" height="12" width="6" ry="6" rx="3" y="24" x="47">
                                        <animate repeatCount="indefinite" begin="-0.5833333333333334s" dur="1s" keyTimes="0;1" values="1;0" attributeName="opacity" />
                                    </rect>
                                </g>
                                <g transform="rotate(150 50 50)">
                                    <rect fill="#0560fd" height="12" width="6" ry="6" rx="3" y="24" x="47">
                                        <animate repeatCount="indefinite" begin="-0.5s" dur="1s" keyTimes="0;1" values="1;0" attributeName="opacity" />
                                    </rect>
                                </g>
                                <g transform="rotate(180 50 50)">
                                    <rect fill="#0560fd" height="12" width="6" ry="6" rx="3" y="24" x="47">
                                        <animate repeatCount="indefinite" begin="-0.4166666666666667s" dur="1s" keyTimes="0;1" values="1;0" attributeName="opacity" />
                                    </rect>
                                </g>
                                <g transform="rotate(210 50 50)">
                                    <rect fill="#0560fd" height="12" width="6" ry="6" rx="3" y="24" x="47">
                                        <animate repeatCount="indefinite" begin="-0.3333333333333333s" dur="1s" keyTimes="0;1" values="1;0" attributeName="opacity" />
                                    </rect>
                                </g>
                                <g transform="rotate(240 50 50)">
                                    <rect fill="#0560fd" height="12" width="6" ry="6" rx="3" y="24" x="47">
                                        <animate repeatCount="indefinite" begin="-0.25s" dur="1s" keyTimes="0;1" values="1;0" attributeName="opacity" />
                                    </rect>
                                </g>
                                <g transform="rotate(270 50 50)">
                                    <rect fill="#0560fd" height="12" width="6" ry="6" rx="3" y="24" x="47">
                                        <animate repeatCount="indefinite" begin="-0.16666666666666666s" dur="1s" keyTimes="0;1" values="1;0" attributeName="opacity" />
                                    </rect>
                                </g>
                                <g transform="rotate(300 50 50)">
                                    <rect fill="#0560fd" height="12" width="6" ry="6" rx="3" y="24" x="47">
                                        <animate repeatCount="indefinite" begin="-0.08333333333333333s" dur="1s" keyTimes="0;1" values="1;0" attributeName="opacity" />
                                    </rect>
                                </g>
                                <g transform="rotate(330 50 50)">
                                    <rect fill="#0560fd" height="12" width="6" ry="6" rx="3" y="24" x="47">
                                        <animate repeatCount="indefinite" begin="0s" dur="1s" keyTimes="0;1" values="1;0" attributeName="opacity" />
                                    </rect>
                                </g>
                                <g />
                            </g>
                    </center>
                </div>
            </div>
        </ProgressTemplate>

    </asp:UpdateProgress>

    <asp:UpdatePanel ID="updatepanel1" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="BtnPrintCIF" />
        </Triggers>
        <ContentTemplate>
            <div>
                <div class="top-pad text-center hidden">
                    <div>
                        <marquee>
                            <asp:Label ID="Lblmarquee" runat="server" Font-Bold="True" Font-Names="Arial Black" ForeColor="red"></asp:Label>
                        </marquee>
                        <div class="btn-group">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                ShowSummary="False" ValidationGroup="Validation" />
                            <asp:Button ValidationGroup="Validation" ID="BtnSaveDraft" class="btn1 btn-primary " Visible="false" runat="server" OnClientClick="$('li:eq(2)', $('.nav-tabs')).tab('show')" OnClick="BtnSaveDraft_Click" Text="Save As Draft" />
                            <button id="Button1" type="button" class="btn1 btn-primary " runat="server" visible="false">Sent</button>
                        </div>
                        <div class="btn-group">
                            <button id="Button2" type="button" class="btn1 btn-primary" runat="server" visible="false">Print Status</button>
                            <button id="Button3" type="button" class="btn1 btn-primary" runat="server" visible="false">Print Draft CCP</button>


                        </div>
                        <%--<div class="btn-group pull-right">
                        <asp:Button ID="BtnExit" runat="server" class="btn1 btn-danger" OnClick="BtnExit_Click" Text="Exit Form" />
                    </div>--%>
                    </div>
                </div>

                <asp:UpdatePanel ID="updatepanel3" runat="server" UpdateMode="Conditional">
                    <Triggers>
                        <asp:PostBackTrigger ControlID="BtnPrintCIF" />
                    </Triggers>
                    <ContentTemplate>


                        <asp:Button ID="BtnPrintCIF" runat="server" Visible="false" Text="Print CIF" class="btn1 btn-primary" OnClick="BtnPrintCIF_Click" />
                        <div class="flex md:justify-between items-center gap-4 mb-4 mt-6 md:flex-nowrap flex-wrap">
                            <div class="flex gap-2 items-center">
                                <p class="text-gray-500 text-sm font-medium">In-Payment</p>
                                <svg width="8" height="12" viewBox="0 0 8 12" fill="none">
                                    <path d="M1.5 11L5.91075 6.58925C6.1885 6.3115 6.32742 6.17258 6.32742 6C6.32742 5.82742 6.1885 5.6885 5.91075 5.41075L1.5 1" stroke="#676D7C" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                </svg>
                                <p class="text-slate-950 text-sm sa700">New Declaration</p>
                            </div>
                            <p class="text-center text-gray-500 text-xs font-medium">
                                &nbsp;
                            </p>
                            <asp:Button ID="Button9" runat="server" class="text-right text-[#0560FD] text-sm cursor-pointer hover:border-none focus:shadow-none" OnClick="BtnExit_Click" Text="Exit Declaration" />
                        </div>

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
                                <div class="flex flex-col justify-center items-center relative active-step" id="divHeader" runat="server" onclick="openTab(1)" style="cursor: pointer;">
                                    <div class="text-center text-[#0560FD] md:text-base text-[10px] font-bold sa700 mb-2">
                                        Header
               
                                    </div>
                                    <div class="w-[14px] h-[14px] bg-transparent border-2 border-[#0560FD] rounded-full relative b-shadow">
                                        <div class="after:absolute lg:after:w-[128px] md:after:w-[60px] after:w-[20px] after:h-[2px] grads after:top-0 after:bottom-0 after:my-auto after:left-3"></div>
                                    </div>
                                </div>
                                <div class="flex flex-col justify-center items-center relative" id="divParty" runat="server" onclick="openTab(2)" style="cursor: pointer;">
                                    <div class="text-center text-gray-500 md:text-base text-[10px] mb-2">
                                        Party
               
                                    </div>
                                    <div class="w-[14px] h-[14px] bg-transparent border-2 border-[#BCBCC3] rounded-full relative">
                                        <div class="after:absolute lg:after:w-[120px] md:after:w-[53px] after:w-[20px] after:h-[2px] after:bg-[#F4F6FA] after:top-0 after:bottom-0 after:my-auto after:left-3"></div>
                                    </div>
                                </div>
                                <div class="flex flex-col justify-center items-center relative" id="divCargo" runat="server" onclick="openTab(3)" style="cursor: pointer;">
                                    <div class="text-center text-gray-500 md:text-base text-[10px] mb-2">
                                        Cargo
               
                                    </div>
                                    <div class="w-[14px] h-[14px] bg-transparent border-2 border-[#BCBCC3] rounded-full relative">
                                        <div class="after:absolute lg:after:w-[130px] md:after:w-[60px] after:w-[20px] after:h-[2px] after:bg-[#F4F6FA] after:top-0 after:bottom-0 after:my-auto after:left-3"></div>
                                    </div>
                                </div>
                                <div class="flex flex-col justify-center items-center relative" id="divInvoice" runat="server" onclick="openTab(4)" style="cursor: pointer;">
                                    <div class="text-center text-gray-500 md:text-base text-[10px] mb-2">
                                        Invoice
               
                                    </div>
                                    <div class="w-[14px] h-[14px] bg-transparent border-2 border-[#BCBCC3] rounded-full relative">
                                        <div class="after:absolute lg:after:w-[120px] md:after:w-[53px] after:w-[20px] after:h-[2px] after:bg-[#F4F6FA] after:top-0 after:bottom-0 after:my-auto after:left-3"></div>
                                    </div>
                                </div>
                                <div class="flex flex-col justify-center items-center relative" id="divItem" runat="server" onclick="openTab(5)" style="cursor: pointer;">
                                    <div class="text-center text-gray-500 md:text-base text-[10px] mb-2">
                                        Item
               
                                    </div>
                                    <div class="w-[14px] h-[14px] bg-transparent border-2 border-[#BCBCC3] rounded-full relative">
                                        <div class="after:absolute lg:after:w-[110px] md:after:w-[45px] after:w-[12px] after:h-[2px] after:bg-[#F4F6FA] after:top-0 after:bottom-0 after:my-auto after:left-3"></div>
                                    </div>
                                </div>
                                <div class="flex flex-col justify-center items-center relative" id="divCPC" runat="server" onclick="openTab(6)" style="cursor: pointer;">
                                    <div class="text-center text-gray-500 md:text-base text-[10px] mb-2">
                                        CPC
               
                                    </div>
                                    <div class="w-[14px] h-[14px] bg-transparent border-2 border-[#BCBCC3] rounded-full relative">
                                        <div class="after:absolute lg:after:w-[130px] md:after:w-[65px] after:w-[23px] after:h-[2px] after:bg-[#F4F6FA] after:top-0 after:bottom-0 after:my-auto after:left-3"></div>
                                    </div>
                                </div>
                                <div class="flex flex-col justify-center items-center relative" id="divSummary" runat="server" onclick="openTab(7)" style="cursor: pointer;">
                                    <div class="text-center text-gray-500 md:text-base text-[10px] mb-2">
                                        Summary
               
                                    </div>
                                    <div class="w-[14px] h-[14px] bg-transparent border-2 border-[#BCBCC3] rounded-full relative"></div>
                                </div>

                                <div class="flex flex-col justify-center items-center relative" id="divamend" runat="server" onclick="openTab(8)" style="cursor: pointer;">
                                    <div class="text-center text-gray-500 md:text-base text-[10px] mb-2">
                                        Amend
               
                                    </div>
                                    <div class="w-[14px] h-[14px] bg-transparent border-2 border-[#BCBCC3] rounded-full relative"></div>
                                </div>

                                <div class="flex flex-col justify-center items-center relative" id="divcancel" runat="server" onclick="openTab(8)" style="cursor: pointer;">
                                    <div class="text-center text-gray-500 md:text-base text-[10px] mb-2">
                                        Cancel
               
                                    </div>
                                    <div class="w-[14px] h-[14px] bg-transparent border-2 border-[#BCBCC3] rounded-full relative"></div>
                                </div>

                                <div class="flex flex-col justify-center items-center relative" id="divrefund" runat="server" onclick="openTab(8)" style="cursor: pointer;">
                                    <div class="text-center text-gray-500 md:text-base text-[10px] mb-2">
                                        Refund
               
                                    </div>
                                    <div class="w-[14px] h-[14px] bg-transparent border-2 border-[#BCBCC3] rounded-full relative"></div>
                                </div>
                            </div>



                            <div class="board-inner ">
                                <%--  <div>--%>

                                <div id="main_error_div"
                                    class="md:max-w-[870px] w-full mx-auto bg-[#fdf3f3] py-6 md:px-6 px-3 flex items-center gap-4 rounded-xl mt-10" style="display: none;">
                                    <svg
                                        class="flex flex-shrink-0"
                                        width="32"
                                        height="32"
                                        viewBox="0 0 32 32"
                                        fill="none"
                                        xmlns="http://www.w3.org/2000/svg">
                                        <path
                                            fill-rule="evenodd"
                                            clip-rule="evenodd"
                                            d="M13.8163 2.68658C15.2355 2.21548 16.7651 2.21548 18.1843 2.68658C19.5978 3.15574 20.7075 4.26846 21.8223 5.83185C22.9335 7.39005 24.1614 9.56266 25.7441 12.3632L25.8062 12.4732C27.3893 15.2742 28.617 17.4467 29.3822 19.2086C30.151 20.979 30.5339 22.5075 30.2285 23.976C29.9207 25.4547 29.1622 26.7992 28.0574 27.8155C26.9553 28.8292 25.4546 29.257 23.5651 29.4623C21.6863 29.6666 19.2286 29.6666 16.0654 29.6666H15.9354C12.7721 29.6666 10.3144 29.6666 8.43555 29.4623C6.54602 29.257 5.04538 28.8292 3.94329 27.8155C2.83849 26.7992 2.0799 25.4547 1.77226 23.976C1.46673 22.5075 1.84966 20.979 2.61853 19.2086C3.38369 17.4467 4.61146 15.2742 6.19443 12.4732L6.25657 12.3632C7.83927 9.56267 9.0671 7.39005 10.1783 5.83185C11.2932 4.26846 12.4029 3.15574 13.8163 2.68658ZM14.667 22.6666C14.667 21.9302 15.2613 21.3332 15.9943 21.3332H16.0063C16.7394 21.3332 17.3337 21.9302 17.3337 22.6666C17.3337 23.403 16.7394 23.9999 16.0063 23.9999H15.9943C15.2613 23.9999 14.667 23.403 14.667 22.6666ZM14.667 17.3332C14.667 18.0696 15.2639 18.6666 16.0003 18.6666C16.7367 18.6666 17.3337 18.0696 17.3337 17.3332V11.9999C17.3337 11.2635 16.7367 10.6666 16.0003 10.6666C15.2639 10.6666 14.667 11.2635 14.667 11.9999V17.3332Z"
                                            fill="#D81616" />
                                    </svg>
                                    <p id="main_error_message" class="text-xs text-[#676D7C] leading-4"></p>
                                </div>

                                <cc1:TabContainer ID="TabContainer1" AutoPostBack="true" runat="server" ActiveTabIndex="0" CssClass="Tab" OnActiveTabChanged="TabContainer1_ActiveTabChanged" OnLoad="TabContainer1_ActiveTabChanged">

                                    <cc1:TabPanel ID="Header_TAB" CssClass="ajax__tab_header" runat="server" HeaderText="Header">

                                        <ContentTemplate>
                                            <asp:UpdatePanel ID="upinheader" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>



                                                    <%-- <div class="flex justify-between gap-2 items-center mt-7">
                                                        <h2 class="text-lg sa700 leading-[18px] text-gray-800">Job Information
                                                        </h2>
                                                    </div>--%>

                                                    <div class="grid grid-cols-1 md:grid-cols-2 gap-6 mt-4 mb-2">

                                                        <!-- Left Column -->
                                                        <div class="space-y-4">
                                                            <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-6">
                                                                <span class="text-white text-sm font-semibold tracking-wide">Declaration Type</span>
                                                            </div>
                                                            <div class="w-full">
                                                                <label class="text-gray-500 text-sm font-medium">Message Type</label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" placeholder="Message Type" ID="TxtMsgType" Text="IPTDEC" Enabled="false" runat="server" type="text" TabIndex="1" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                </div>
                                                            </div>

                                                            <div class="w-full">
                                                                <div class="group relative mt-1">
                                                                    <label class="text-gray-500 text-sm font-medium">
                                                                        Declaration Type
                 
                                                                    </label>
                                                                    <asp:DropDownList ID="DrpDecType" OnSelectedIndexChanged="DrpDecType_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true" TabIndex="2" runat="server" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>

                                                            <div class="w-full">
                                                                <label class="text-gray-500 text-sm font-medium">
                                                                    Previous Permit Number
                                                                </label>
                                                                </label>
                                                            <div class="relative mt-1">
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Type Number" autocomplete="off" ID="TxtPrevPerNO" MaxLength="35" class="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server" type="text" TabIndex="3"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                                <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-6">
                                                                    <span class="text-white text-sm font-semibold tracking-wide">Declaration Information


                                                                    </span>

                                                                </div>
                                                                <div class="w-full">
                                                                    <label>
                                                                        Cargo Pack Type               
                                                                    </label>
                                                                    <div class="relative mt-1">
                                                                        <asp:DropDownList ID="DrpCargoPackType" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" OnSelectedIndexChanged="DrpCargoPackType_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true" TabIndex="4" runat="server">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>

                                                                <div class="w-full" id="inwared" runat="server">
                                                                    <div class="group relative">
                                                                        <div class="text-gray-500 text-sm font-medium">
                                                                            Inward Transport Mode                 
                                                                        </div>
                                                                        <asp:DropDownList ID="DrpInwardtrasMode" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" OnSelectedIndexChanged="DrpInwardtrasMode_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true" TabIndex="5" runat="server">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-6">
                                                                    <span class="text-white text-sm font-semibold tracking-wide">Job Details</span>

                                                                </div>

                                                                <div class="w-full">
                                                                    <div class="group relative">
                                                                        <div class="text-gray-500 text-sm font-medium">
                                                                            Customers         
                                                                        </div>
                                                                        <asp:DropDownList ID="DrpCustomers" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" AppendDataBoundItems="true" TabIndex="5" runat="server">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>




                                                                <div class="w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">BG Indicator</label>
                                                                    <div class="w-full">
                                                                        <div class="mt-1 relative">
                                                                            <asp:DropDownList ID="DrpBGIndicator" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" AppendDataBoundItems="true" TabIndex="6" runat="server">
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="w-full">
                                                                    <div class="flex gap-4 items-center">
                                                                        <asp:CheckBox ID="ChkOverrExgRate" AutoPostBack="true" OnCheckedChanged="ChkOverrExgRate_CheckedChanged" runat="server" TabIndex="7" />
                                                                        <label for="ChkOverrExgRate" class="text-gray-500 text-sm font-medium">Override Ex: Rate</label>
                                                                    </div>
                                                                </div>


                                                                <div class="w-full mt-2">
                                                                    <div class="flex gap-4 items-center">
                                                                        <asp:CheckBox ID="ChkSupplyIndicator" runat="server" TabIndex="8" />
                                                                        <label for="ChkSupplyIndicator" class="text-gray-500 text-sm font-medium">Supply Indicator</label>
                                                                    </div>
                                                                </div>


                                                                <div class="w-full mt-2">
                                                                    <div class="flex gap-4 items-center">
                                                                        <asp:CheckBox ID="ChkRefDoc" OnCheckedChanged="ChkRefDoc_CheckedChanged" AppendDataBoundItems="true" AutoPostBack="true" runat="server" TabIndex="9" />
                                                                        <label for="ChkRefDoc" class="text-gray-500 text-sm font-medium">Supporting documents</label>
                                                                    </div>
                                                                </div>



                                                            </div>
                                                        </div>
                                                        <!-- Right Column -->
                                                        <div class="space-y-4">
                                                            <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-6">
                                                                <span class="text-white text-sm font-semibold tracking-wide">Job Information
                                                                </span>
                                                                <asp:Label ID="Label6" Visible="false" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="w-full">
                                                                <label class="text-gray-500 text-sm font-medium">TradeNet Mailbox ID</label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="TradeNet Mailbox ID" autocomplete="off" runat="server" Text="" Enabled="false" type="text" ID="TxtTradeMailID" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" Style="text-transform: uppercase"></asp:TextBox>
                                                                </div>
                                                            </div>


                                                            <div class="w-full">
                                                                <label class="text-gray-500 text-sm font-medium">Declarant Name</label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtDecName" Text="" Enabled="false" runat="server" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" Style="text-transform: uppercase"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="None" ControlToValidate="TxtDecName" ValidationExpression="[a-zA-Z ]*$" ErrorMessage="Enter a valid Name" ValidationGroup="Validation" />
                                                                </div>
                                                            </div>


                                                            <div class="w-full">
                                                                <label class="text-gray-500 text-sm font-medium">Declarant Code</label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Declarant Code" autocomplete="off" ID="TxtDecCode" Text="" Enabled="false" runat="server" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" Style="text-transform: uppercase"></asp:TextBox>
                                                                </div>
                                                            </div>

                                                            <div class="w-full">
                                                                <label class="text-gray-500 text-sm font-medium">
                                                                    Declarant Telephone
               
                                                                </label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtDecTelephone" onkeypress="return onlyNumbers(event)" Enabled="false" Text="" runat="server" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="regPhone" runat="server" Display="None" ControlToValidate="TxtDecTelephone" ValidationExpression="[0-9]{10}" ErrorMessage="Enter a valid phone number" ValidationGroup="Validation" />
                                                                </div>
                                                            </div>


                                                            <div class="w-full">
                                                                <label class="text-gray-500 text-sm font-medium">CR UEI Number</label>
                                                                <div class="relative mt-1">

                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="CR UEI Number" autocomplete="off" ID="TxtCRUEINO" Text="" Enabled="false" runat="server" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                </div>
                                                            </div>



                                                            <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-6">
                                                                <span class="text-white text-sm font-semibold tracking-wide">ADDITIONAL RECIPIENTS</span>
                                                                <asp:Label ID="txt_code" Visible="false" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="w-full">
                                                                <label class="text-gray-500 text-sm font-medium">Recipient 1</label>
                                                                <div class="relative mt-1">
                                                                    <%--<input placeholder="Type Recipient" type="text" name="" id="" class="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4">--%>
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Type Recipient" autocomplete="off" MaxLength="17" ID="TxtRECPT1" runat="server" TabIndex="18" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                </div>
                                                            </div>

                                                            <div class="w-full">
                                                                <label class="text-gray-500 text-sm font-medium">Recipient 2</label>
                                                                <div class="relative mt-1">
                                                                    <%--<input placeholder="Type Recipient" type="text" name="" id="" class="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4">--%>
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Type Recipient" autocomplete="off" MaxLength="17" ID="TxtRECPT2" runat="server" TabIndex="19" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="w-full">
                                                                <label class="text-gray-500 text-sm font-medium">
                                                                    Recipient 3               
                                                                </label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Type Recipient" autocomplete="off" MaxLength="17" ID="TxtRECPT3" runat="server" onkeypress="return isNumber(event)" TabIndex="20" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                </div>
                                                            </div>

                                                        </div>



                                                    </div>

                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <div class="space-y-4">
                                                                <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-6">
                                                                    <span class="text-white text-sm font-semibold tracking-wide">Licence Details</span>
                                                                </div>

                                                                <div class="mt-5 flex  items-end gap-y-5 gap-x-5 mb-5">
                                                                    <div class="w-[20%]">
                                                                        <label class="text-gray-500 text-sm font-medium">Licence 1</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="" autocomplete="off" MaxLength="35" ID="TxtLicense1" runat="server" TabIndex="10" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <%--<img src="./images/circel-search.svg" alt="circel-search" class="absolute right-4 top-2">--%>
                                                                        </div>
                                                                    </div>
                                                                    <div class="w-[20%]">
                                                                        <label class="text-gray-500 text-sm font-medium">Licence 2</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="" autocomplete="off" MaxLength="35" ID="TxtLicense2" runat="server" TabIndex="11" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <%--<img src="./images/circel-search.svg" alt="circel-search" class="absolute right-4 top-2">--%>
                                                                        </div>
                                                                    </div>
                                                                    <div class="w-[20%]">
                                                                        <label class="text-gray-500 text-sm font-medium">Licence 3</label>
                                                                        <div class="relative mt-1">
                                                                            <%--<input placeholder="Search Licence" type="text" name="" id="" class="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4">--%>
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="" autocomplete="off" MaxLength="35" ID="TxtLicense3" runat="server" TabIndex="12" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <%--<img src="./images/circel-search.svg" alt="circel-search" class="absolute right-4 top-2">--%>
                                                                        </div>
                                                                    </div>
                                                                    <div class="w-[20%]">
                                                                        <label class="text-gray-500 text-sm font-medium">Licence 4</label>
                                                                        <div class="relative mt-1">
                                                                            <%--<input placeholder="Search Licence" type="text" name="" id="" class="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4">--%>
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="" autocomplete="off" MaxLength="35" ID="TxtLicense4" runat="server" TabIndex="13" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <%--<img src="./images/circel-search.svg" alt="circel-search" class="absolute right-4 top-2">--%>
                                                                        </div>
                                                                    </div>
                                                                    <div class="w-[20%]">
                                                                        <label class="text-gray-500 text-sm font-medium">Licence 5</label>
                                                                        <div class="relative mt-1">
                                                                            <%--<input placeholder="Search Licence" type="text" name="" id="" class="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4">--%>
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="" autocomplete="off" MaxLength="35" ID="TxtLicense5" runat="server" TabIndex="14" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <%--<img src="./images/circel-search.svg" alt="circel-search" class="absolute right-4 top-2">--%>
                                                                        </div>
                                                                    </div>


                                                                </div>



                                                            </div>

                                                        </div>
                                                    </div>

                                                    <div id="Document" runat="server" class="mt-12">

                                                        <div class="row col-md-12">

                                                            <!-- Left Column -->


                                                            <div class="mt-1 justify-between items-start gap-4 lg:flex-nowrap flex-wrap mb-2">

                                                                <!-- Heading in its own row -->
                                                                <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-5">
                                                                    <span class="text-white text-sm font-semibold tracking-wide">Attachment Document</span>
                                                                </div>


                                                                <asp:UpdatePanel ID="updoc" runat="server" UpdateMode="Conditional" Class="flex gap-4">
                                                                    <ContentTemplate>
                                                                        <div class="w-full mt-2">
                                                                            <div class="m-1 relative">
                                                                                <label class="text-gray-500 text-sm font-medium">
                                                                                    Document Type
     
                                                                                </label>
                                                                                <asp:DropDownList ID="DrpDocType" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" AppendDataBoundItems="true" TabIndex="15" runat="server">
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                        <div class="w-full mt-2">
                                                                            <label class="text-gray-500 text-sm font-medium">Attachment </label>

                                                                            <div class="mt-1 w-full h-10 bg-slate-100 rounded-md flex items-center justify-center gap-2 cursor-pointer relative">
                                                                                <asp:FileUpload ID="FileUpload1" CssClass="absolute h-full left-0 opacity-0 w-full" TabIndex="16" runat="server" AllowMultiple="true" onchange="fileUpload()" />
                                                                                <img src="./images/import.svg" alt="Import">
                                                                                <p class="text-center text-[#0560FD] text-sm sa700">
                                                                                    Choose Files            
                                                                                </p>
                                                                            </div>

                                                                            <label class="text-gray-500 text-sm font-medium">Acceptable File Extensions: doc, docx, xls, xlsx, pdf, jpg, jpeg, png, bmp, gif, tif, tiff </label>
                                                                        </div>
                                                                        <div class="w-full mt-2">
                                                                            <label class="text-gray-500 text-sm font-medium">Attachment</label>
                                                                            <div class="mt-1 w-full h-10 bg-slate-100 rounded-md flex items-center justify-center gap-2 cursor-pointer relative">
                                                                                <asp:Button runat="server" ID="Btn_Upload" TabIndex="17" Text="Upload" OnClick="Btn_Upload_Click" />

                                                                            </div>
                                                                        </div>




                                                                    </ContentTemplate>
                                                                    <Triggers>
                                                                        <asp:PostBackTrigger ControlID="Btn_Upload" />

                                                                    </Triggers>
                                                                </asp:UpdatePanel>



                                                                <hr />
                                                                <div style="overflow: auto !important;">


                                                                    <div class="w-full bg-white my-shadow rounded-2xl px-4 py-5 mt-5" style="display: none;">
                                                                        <div class="overflow-auto my-shadow whitespace-nowrap amount_offer">
                                                                            <div class="table-responsive">
                                                                                <label class="text-gray-500 text-sm font-medium">Search </label>
                                                                                <asp:TextBox autocomplete="off" ID="txtdocserach" OnTextChanged="txtdocserach_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server" Style="width: 400px;"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                        <ContentTemplate>

                                                                            <asp:GridView ID="GridView1" PageSize="5" OnRowDeleting="GridView1_RowDeleting" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="GridView1_PageIndexChanging" FooterStyle-CssClass="w-full h-10 py-4 px-10 bg-[#F4F6FA] rounded-lg" CssClass="w-full bg-white rounded whitespace-nowrap" HeaderStyle-CssClass="w-full h-10 py-4 px-10 bg-[#F4F6FA] rounded-l-lg" PagerStyle-CssClass="pager" RowStyle-CssClass="rows" runat="server" AutoGenerateColumns="false" ShowFooter="false">
                                                                                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                <Columns>
                                                                                    <asp:TemplateField>
                                                                                        <HeaderTemplate>
                                                                                            <div class="pl-4">Delete</div>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <div class="pl-4">
                                                                                                <asp:LinkButton OnClientClick="return confirm('Are you sure you want to Delete this Record?');" data-target='<%#"#"+DataBinder.Eval(Container.DataItem,"Id")%>' Width="11" OnClick="imgDelete_Click" Height="11" ID="imgDelete" runat="server"><i class='fa fa-trash' style="color:red;"> </i></asp:LinkButton>
                                                                                            </div>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Doc File Name" SortExpression="Id">
                                                                                        <ItemTemplate>
                                                                                            <p class="text-slate-500 text-xs font-medium py-3 md:px-0 px-2 rounded-l-lg">
                                                                                                <asp:Label ID="lblDocType" runat="server"
                                                                                                    Text='<%#Eval("DocumentType")%>'>
                                                                                                </asp:Label>
                                                                                            </p>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Name" SortExpression="Id">
                                                                                        <ItemTemplate>
                                                                                            <p class="text-slate-500 text-xs font-medium py-3 md:px-0 px-2 rounded-l-lg">
                                                                                                <asp:LinkButton ID="lblName" CommandArgument='<%# Eval("Name") %>' CommandName="DownloadFile" OnCommand="lblName_Command" runat="server"
                                                                                                    Text='<%#Eval("Name")%>'>
                                                                                                </asp:LinkButton>
                                                                                            </p>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>

                                                                                    <asp:TemplateField HeaderText="File Size (KB)">
                                                                                        <ItemTemplate>
                                                                                            <p class="text-slate-500 text-xs font-medium py-3 md:px-0 px-2">
                                                                                                <asp:Label ID="lblFileSize" runat="server"
                                                                                                    Text='<%# Eval("FileSizeKB") %>'>
                                                                                                </asp:Label>
                                                                                            </p>
                                                                                        </ItemTemplate>
                                                                                        <FooterTemplate>

                                                                                            <asp:Label ID="lblTotal" runat="server" Font-Bold="true" />
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>

                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </ContentTemplate>
                                                                        <Triggers>

                                                                            <asp:PostBackTrigger ControlID="GridView1" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>

                                                                </div>



                                                                <div class=" text-right">
                                                                    <br />
                                                                    <asp:Label ID="lblTotalSize" runat="server"
                                                                        CssClass="font-bold" />
                                                                </div>

                                                            </div>
                                                        </div>

                                                        <!-- Right Column -->
                                                        <div class="space-y-4">


                                                            <!--  -->

                                                            <!--  -->
                                                        </div>


                                                    </div>







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
                                    <cc1:TabPanel ID="Party" runat="server" CssClass="nn" HeaderText="Party">
                                        <ContentTemplate>
                                            <asp:UpdatePanel ID="upinparty" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <br />
                                                    <div class="flex flex-wrap lg:flex-nowrap gap-3">
                                                        <div class="flex items-center justify-between mb-1">
                                                            <div class="flex items-center gap-1">
                                                                <h2 class="text-[18px] sa700 leading-[18px] text-gray-800 mb-0 mt-5 w-[200px] ">Declarant Company</h2>
                                                                <asp:ImageButton ID="btnShow1" Style="filter: grayscale(100%);" CssClass="theme_searchIcon mt-5" Enabled="false" runat="server" ImageUrl="images/searchBlue.png" Height="28" Width="28" />

                                                                <asp:Button ID="DECPLUS" Style="filter: grayscale(100%);" runat="server" Enabled="false" CssClass="plusbtn plusbtnIcon mt-5" BorderWidth="0px" ValidationGroup="PartyDec" OnClick="DECPLUS_Click" Text="+" />
                                                            </div>

                                                            <div class="flex-1 min-w-[100px] max-w-[300px] m-1">
                                                                <label for="staticEmail" class="text-gray-500 text-sm font-medium">Code</label>
                                                                <div class="relative mt-1">

                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" Enabled="false" type="text" OnTextChanged="TxtDecCompCode_TextChanged" placeholder="" AutoPostBack="true" ID="TxtDecCompCode" TabIndex="24" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
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
                                                            <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                <label class="text-gray-500 text-sm font-medium">CR UEI</label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtDecCompCRUEI" MaxLength="17" placeholder="" runat="server" Enabled="false" ValidationGroup="party" TabIndex="25" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtDecCompCRUEI" ID="RegularExpressionValidator20" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="party"></asp:RegularExpressionValidator>
                                                                </div>
                                                            </div>
                                                            <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                <label class="text-gray-500 text-sm font-medium">Name 1 </label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtDecCompName" MaxLength="50" placeholder="" runat="server" Enabled="false" ValidationGroup="party" TabIndex="26" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtDecCompName" ID="RegularExpressionValidator18" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="party"></asp:RegularExpressionValidator>
                                                                </div>
                                                            </div>
                                                            <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                <label class="text-gray-500 text-sm font-medium">Name 2</label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtDecCompName1" MaxLength="50" placeholder="" ValidationGroup="party" Enabled="false" runat="server" TabIndex="27" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" Style="text-transform: uppercase;"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtDecCompName1" ID="RegularExpressionValidator19" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="party"></asp:RegularExpressionValidator>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>



                                                    <%--  search popup start here--%>
                                                    <cc1:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlPopup" TargetControlID="btnShow1"
                                                        OkControlID="btnYes" CancelControlID="btnNo" BackgroundCssClass="modalBackground">
                                                    </cc1:ModalPopupExtender>
                                                    <asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                        <%--<asp:UpdatePanel  ID="decgrid" runat ="server" UpdateMode ="Conditional">
                                                                   <ContentTemplate>  --%>
                                                        <div class="header">
                                                            <%--<svg class="cursor-pointer absolute right-5 top-5" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                <circle opacity="0.1" cx="12" cy="12" r="12" fill="#676D7C"></circle>
                                                                <path d="M16.6663 7.3335L7.33301 16.6668M7.33301 7.3335L16.6663 16.6668" stroke="#676D7C" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                                            </svg>--%>
                                                            <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Declarant Company Search</p>
                                                        </div>
                                                        <div class="body">
                                                            <asp:UpdatePanel ID="upindec" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                        <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="DecSearch" OnTextChanged="DecSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                    </div>

                                                                    <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                        <asp:GridView ID="DECCOMPSearGRID" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="DECCOMPSearGRID_PageIndexChanging" OnRowCreated="DECCOMPSearGRID_RowCreated" OnRowDataBound="DECCOMPSearGRID_RowDataBound" OnSelectedIndexChanged="DECCOMPSearGRID_SelectedIndexChanged" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" AutoGenerateColumns="false" OnRowCommand="DECCOMPSearGRID_select">
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
                                                                                <asp:TemplateField Visible="false">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkRequestID" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="lnkRequestID_Command" CssClass="duration-300 ease-in-out md:max-w-[200px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" Style="display: none;">Select </asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </ContentTemplate>

                                                            </asp:UpdatePanel>

                                                        </div>
                                                        <div class="footer" align="right">
                                                            <asp:Button ID="btnYes" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                            <asp:Button ID="btnNo" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px] mt-4 w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                        </div>
                                                    </asp:Panel>



                                                    <%--  search popup End here--%>

                                                    <%--  code start for Importer section --%>
                                                    <div class="flex flex-wrap lg:flex-nowrap gap-3">
                                                        <div class="flex items-center justify-between mb-1">
                                                            <div class="flex items-center gap-1">
                                                                <h2 class="text-[18px] sa700 leading-[18px] text-gray-800 mb-0 mt-5 w-[200px]">Importer </h2>
                                                                <asp:ImageButton ID="btnimp1" CssClass="theme_searchIcon mt-5" runat="server" ImageUrl="images/searchBlue.png" Height="28" Width="28" />

                                                                <asp:Button ID="BtnImpADD" CssClass="plusbtn plusbtnIcon mt-5" BorderWidth="0px" runat="server" ValidationGroup="importer" OnClick="BtnImpADD_Click" Text="+" />

                                                            </div>

                                                            <div class="flex-1 min-w-[100px] max-w-[300px] m-1">
                                                                <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" placeholder="" type="text" ID="TxtImpCode" OnTextChanged="TxtImpCode_TextChanged" AutoPostBack="true" TabIndex="28" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
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
                                                            <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                <label class="text-gray-500 text-sm font-medium">CR UEI</label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtImpCRUEI" placeholder="" MaxLength="17" runat="server" TabIndex="29" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" Style="text-transform: uppercase;"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtImpCRUEI" ID="RegularExpressionValidator23" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="importer"></asp:RegularExpressionValidator>

                                                                </div>
                                                            </div>
                                                            <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                <label class="text-gray-500 text-sm font-medium">Name 1 </label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtImpName" MaxLength="35" placeholder="" runat="server" ValidationGroup="importer" TabIndex="30" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" Style="text-transform: uppercase"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtImpName" ID="RegularExpressionValidator21" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="importer"></asp:RegularExpressionValidator>
                                                                </div>
                                                            </div>
                                                            <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                <label class="text-gray-500 text-sm font-medium">Name 2</label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtImpName1" MaxLength="35" placeholder="" ValidationGroup="importer" runat="server" TabIndex="31" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtImpName1" ID="RegularExpressionValidator22" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="importer"></asp:RegularExpressionValidator>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <%--  search popup Start here--%>
                                                    <cc1:ModalPopupExtender ID="popupimp" runat="server" PopupControlID="pnlimp" TargetControlID="btnimp1"
                                                        OkControlID="btnyesimp" CancelControlID="btnnoimp" BackgroundCssClass="modalBackground">
                                                    </cc1:ModalPopupExtender>
                                                    <asp:Panel ID="pnlimp" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                        <div class="header">

                                                            <%--  <svg class="cursor-pointer absolute right-5 top-5" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                <circle opacity="0.1" cx="12" cy="12" r="12" fill="#676D7C"></circle>
                                                                <path d="M16.6663 7.3335L7.33301 16.6668M7.33301 7.3335L16.6663 16.6668" stroke="#676D7C" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                                            </svg>--%>
                                                            <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Importer Search</p>


                                                        </div>
                                                        <div class="body">

                                                            <asp:UpdatePanel ID="upimpgrid" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>

                                                                    <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                        <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ImporterSearch" OnTextChanged="ImporterSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                    </div>
                                                                    <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                        <asp:GridView ID="ImporterGrid" PageSize="5" OnRowDataBound="ImporterGrid_RowDataBound" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ImporterGrid_PageIndexChanging" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" OnRowCommand="ImporterGrid_RowCommand" AutoGenerateColumns="false">
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
                                                                                <asp:TemplateField Visible="false">

                                                                                    <ItemTemplate>

                                                                                        <asp:LinkButton ID="LnkImport" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkImport_Command" CssClass="duration-300 ease-in-out md:max-w-[200px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700">Select </asp:LinkButton>


                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </ContentTemplate>

                                                            </asp:UpdatePanel>
                                                        </div>
                                                        <div class="footer" align="right">
                                                            <asp:Button ID="btnyesimp" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                            <asp:Button ID="btnnoimp" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px] mt-4 w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                        </div>
                                                    </asp:Panel>

                                                    <%--  search popup End here--%>
                                                    <%--  code End for Importer section --%>


                                                    <%--  code start for Inward Carrier Agent section --%>
                                                    <div class="flex flex-wrap lg:flex-nowrap gap-3">
                                                        <div class="flex items-center justify-between mb-1">
                                                            <div class="flex items-center gap-1">
                                                                <h2 class="text-[18px] sa700 leading-[18px] text-gray-800 mb-0 mt-5 w-[200px]">Inward Carrier Agent </h2>
                                                                <asp:ImageButton ID="btninw1" CssClass="theme_searchIcon mt-5" runat="server" ImageUrl="images/searchBlue.png" Height="28" Width="28" />
                                                                <asp:Button ID="InwardAdd" CssClass="plusbtn plusbtnIcon mt-5" BorderWidth="0px" runat="server" ValidationGroup="Inward" OnClick="InwardAdd_Click" Text="+" />
                                                            </div>

                                                            <div class="flex-1 min-w-[100px] max-w-[300px] m-1">
                                                                <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" placeholder="" type="text" AutoPostBack="true" ID="InwardCode" OnTextChanged="InwardCode_TextChanged" TabIndex="32" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
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
                                                            <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                <label class="text-gray-500 text-sm font-medium">CR UEI</label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="InwardCRUEI" MaxLength="17" placeholder="" runat="server" TabIndex="33" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" Style="text-transform: uppercase;"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                            <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                <label class="text-gray-500 text-sm font-medium">Name 1 </label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="InwardName" MaxLength="50" placeholder="" runat="server" TabIndex="34" type="text" ValidationGroup="Inward" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" Style="text-transform: uppercase;"></asp:TextBox>

                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="InwardName" ID="RegularExpressionValidator7" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="Inward"></asp:RegularExpressionValidator>

                                                                </div>
                                                            </div>
                                                            <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                <label class="text-gray-500 text-sm font-medium">Name 2</label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="InwardName1" MaxLength="50" placeholder="" runat="server" TabIndex="35" type="text" ValidationGroup="Inward" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" Style="text-transform: uppercase;"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="InwardName1" ID="RegularExpressionValidator8" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="Inward"></asp:RegularExpressionValidator>


                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <%--  search popup Start here--%>
                                                    <cc1:ModalPopupExtender ID="popupinw" runat="server" PopupControlID="pnlinward" TargetControlID="btninw1"
                                                        OkControlID="btnyesinw" CancelControlID="btnnoinw" BackgroundCssClass="modalBackground">
                                                    </cc1:ModalPopupExtender>
                                                    <asp:Panel ID="pnlinward" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                        <div class="header">

                                                            <%-- <svg class="cursor-pointer absolute right-5 top-5" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                <circle opacity="0.1" cx="12" cy="12" r="12" fill="#676D7C"></circle>
                                                                <path d="M16.6663 7.3335L7.33301 16.6668M7.33301 7.3335L16.6663 16.6668" stroke="#676D7C" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                                            </svg>--%>
                                                            <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Inward Carrier Agent</p>


                                                        </div>
                                                        <div class="body">
                                                            <asp:UpdatePanel ID="UpdatePanelInwardSearch" runat="server" UpdateMode="Conditional">

                                                                <ContentTemplate>

                                                                    <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                        <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="InwardSearch" OnTextChanged="InwardSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                    </div>

                                                                    <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">

                                                                        <%--  <asp:GridView ID="GridView3" PageSize="5" OnRowDataBound="ImporterGrid_RowDataBound" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ImporterGrid_PageIndexChanging" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" OnRowCommand="ImporterGrid_RowCommand" AutoGenerateColumns="false">
                                                                        --%>

                                                                        <asp:GridView ID="InwardGrid" PageSize="5" OnRowDataBound="InwardGrid_RowDataBound" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="InwardGrid_PageIndexChanging" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" OnRowCommand="InwardGrid_RowCommand" AutoGenerateColumns="false">
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
                                                                                <asp:TemplateField Visible="false">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="LmkInward" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LmkInward_Command" CssClass="duration-300 ease-in-out md:max-w-[200px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700">Select </asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </ContentTemplate>

                                                            </asp:UpdatePanel>
                                                        </div>

                                                        <div class="footer" align="right">
                                                            <asp:Button ID="btnyesinw" runat="server" Text="Yes" CssClass="yes" Style="display: none" />
                                                            <asp:Button ID="btnnoinw" runat="server" Text="close" CssClass="duration-300 ease-in-out md:max-w-[80px] mt-4 w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                        </div>


                                                        <div class="footer" align="right">
                                                            <asp:Button ID="Button13" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                            <asp:Button ID="Button17" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px] mt-4 w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                        </div>



                                                    </asp:Panel>


                                                    <div class="flex flex-wrap lg:flex-nowrap gap-3">
                                                        <div class="flex items-center justify-between mb-1">
                                                            <div class="flex items-center gap-1">
                                                                <h2 class="text-[18px] sa700 leading-[18px] text-gray-800 mb-0 mt-5 w-[200px]">Freight Forwarder </h2>

                                                                <asp:ImageButton ID="btnfreight1" CssClass="theme_searchIcon mt-5" runat="server" ImageUrl="images/searchBlue.png" Height="28" Width="28" />

                                                                <asp:Button ID="BtnFrieghtAdd" CssClass="plusbtn plusbtnIcon mt-5" BorderWidth="0px" runat="server" ValidationGroup="freight" OnClick="BtnFrieghtAdd_Click" Text="+" />
                                                            </div>

                                                            <div class="flex-1 min-w-[100px] max-w-[300px] m-1">
                                                                <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" placeholder="" OnTextChanged="FrieghtCode_TextChanged" AutoPostBack="true" type="text" ID="FrieghtCode" TabIndex="36" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
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
                                                            <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                <label class="text-gray-500 text-sm font-medium">CR UEI</label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="FrieghtCRUEI" MaxLength="17" placeholder="" runat="server" ValidationGroup="freight" TabIndex="37" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" Style="text-transform: uppercase;"></asp:TextBox>


                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="FrieghtCRUEI" ID="RegularExpressionValidator26" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17characters allowed." ValidationGroup="freight"></asp:RegularExpressionValidator>

                                                                </div>
                                                            </div>
                                                            <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                <label class="text-gray-500 text-sm font-medium">Name 1 </label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="FrieghtName" MaxLength="50" placeholder="" runat="server" TabIndex="38" type="text" ValidationGroup="freight" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" Style="text-transform: uppercase;"></asp:TextBox>

                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="FrieghtName" ID="RegularExpressionValidator24" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="freight"></asp:RegularExpressionValidator>

                                                                </div>
                                                            </div>
                                                            <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                <label class="text-gray-500 text-sm font-medium">Name 2</label>
                                                                <div class="relative mt-1">

                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="FrieghtName1" MaxLength="50" placeholder="" runat="server" TabIndex="39" ValidationGroup="freight" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" Style="text-transform: uppercase;"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="FrieghtName1" ID="RegularExpressionValidator25" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="freight"></asp:RegularExpressionValidator>

                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>



                                                    <%--  search popup Start here--%>

                                                    <cc1:ModalPopupExtender ID="popupfreight" runat="server" PopupControlID="pnlfreight" TargetControlID="btnfreight1"
                                                        OkControlID="btnyesfreight" CancelControlID="btnnofreight" BackgroundCssClass="modalBackground">
                                                    </cc1:ModalPopupExtender>
                                                    <asp:Panel ID="pnlfreight" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                        <div class="header">

                                                            <%-- <svg class="cursor-pointer absolute right-5 top-5" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                <circle opacity="0.1" cx="12" cy="12" r="12" fill="#676D7C"></circle>
                                                                <path d="M16.6663 7.3335L7.33301 16.6668M7.33301 7.3335L16.6663 16.6668" stroke="#676D7C" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                                            </svg>--%>
                                                            <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Freight Forwarder Search</p>


                                                        </div>
                                                        <div class="body">
                                                            <asp:UpdatePanel ID="upfreightgrid" runat="server" UpdateMode="Conditional">

                                                                <ContentTemplate>
                                                                    <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                        <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="FrieghtSearch" OnTextChanged="FrieghtSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                    </div>

                                                                    <%--   <asp:UpdatePanel ID="UpdatePanelFrieghtSearch" runat="server"  UpdateMode="Always">

                                                        <ContentTemplate>--%>
                                                                    <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
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
                                                                                <asp:TemplateField Visible="false">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="LnkFrieght" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkFrieght_Command" CssClass="duration-300 ease-in-out md:max-w-[200px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700">Select </asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </ContentTemplate>

                                                            </asp:UpdatePanel>
                                                        </div>
                                                        <div class="footer" align="right">
                                                            <asp:Button ID="btnyesfreight" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                            <asp:Button ID="btnnofreight" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px] mt-4 w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />

                                                        </div>
                                                    </asp:Panel>


                                                    <%--  search popup End here--%>

                                                    <%--  code End for Freight Forwarder section --%>

                                                    <%--  code start for Claimant Party section --%>


                                                    <div class="flex flex-wrap lg:flex-nowrap gap-2">

                                                        <div class="flex items-center justify-between mb-3">
                                                            <div class="flex items-center gap-1">
                                                                <h2 class="text-[18px] sa700 leading-[18px] text-gray-800 mb-0 mt-6 w-[200px]">Claimant Party</h2>
                                                                <asp:ImageButton ID="btnclaimant1" CssClass="theme_searchIcon mt-6" runat="server" ImageUrl="images/searchBlue.png" Height="28" Width="28" />
                                                                <asp:Button ID="ClaimantAdd" CssClass="plusbtn plusbtnIcon mt-6" BorderWidth="0px" runat="server" ValidationGroup="CLAIMANT" OnClick="ClaimantAdd_Click" Text="+" />
                                                            </div>
                                                        </div>


                                                        <!-- Code -->
                                                        <div class="flex-1 min-w-[100px] max-w-[300px]">
                                                            <label class="text-gray-500 text-sm font-medium">Code</label>
                                                            <div class="relative mt-1">
                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" MaxLength="17" placeholder="" ValidationGroup="CLAIMANT" OnTextChanged="ClaimantName_TextChanged" AutoPostBack="true" ID="ClaimantName" TabIndex="40" CssClass="w-full h-10 bg-slate-100 rounded-md px-4 text-sm text-slate-950 font-medium outline-none border-none"></asp:TextBox>
                                                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" CompletionInterval="100" MinimumPrefixLength="1" DelimiterCharacters="" ServiceMethod="GetClaimanity" ServicePath="Inpayment.aspx" Enabled="True" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" TargetControlID="ClaimantName" />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator30" runat="server" ControlToValidate="ClaimantName" ValidationExpression="^[\s\S]{0,50}$" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="CLAIMANT" Display="Dynamic" BackColor="yellow" />
                                                            </div>
                                                        </div>

                                                        <!-- CR UEI -->
                                                        <div class="flex-1 min-w-[200px] max-w-[300px]">
                                                            <label class="text-gray-500 text-sm font-medium">CR UEI</label>
                                                            <div class="relative mt-1">
                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ClaimantCRUEI" MaxLength="17" placeholder="" ValidationGroup="CLAIMANT" runat="server" TabIndex="41" CssClass="w-full h-10 bg-slate-100 rounded-md px-4 text-sm text-slate-950 font-medium outline-none border-none" Style="text-transform: uppercase;" />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator27" runat="server" ControlToValidate="ClaimantCRUEI" ValidationExpression="^[\s\S]{0,17}$" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="CLAIMANT" Display="Dynamic" BackColor="yellow" />
                                                            </div>
                                                        </div>

                                                        <!-- Name 1 -->
                                                        <div class="flex-1 min-w-[200px] max-w-[300px]">
                                                            <label class="text-gray-500 text-sm font-medium">Name 1</label>
                                                            <div class="relative mt-1">
                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ClaimantName1" MaxLength="50" placeholder="" ValidationGroup="CLAIMANT" runat="server" TabIndex="42" CssClass="w-full h-10 bg-slate-100 rounded-md px-4 text-sm text-slate-950 font-medium outline-none border-none" Style="text-transform: uppercase;" />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator29" runat="server" ControlToValidate="ClaimantName1" ValidationExpression="^[\s\S]{0,50}$" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="CLAIMANT" Display="Dynamic" BackColor="yellow" />
                                                            </div>
                                                        </div>

                                                        <!-- Name 2 -->
                                                        <div class="flex-1 min-w-[200px] max-w-[300px]">
                                                            <label class="text-gray-500 text-sm font-medium">Name 2</label>
                                                            <div class="relative mt-1">
                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ClaimantName2" MaxLength="17" placeholder="" runat="server" TabIndex="43" ValidationGroup="CLAIMANT" CssClass="w-full h-10 bg-slate-100 rounded-md px-4 text-sm text-slate-950 font-medium outline-none border-none" Style="text-transform: uppercase;" />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator28" runat="server" ControlToValidate="ClaimantName2" ValidationExpression="^[\s\S]{0,17}$" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="CLAIMANT" Display="Dynamic" BackColor="yellow" />
                                                            </div>
                                                        </div>
                                                    </div>




                                                    <%--  search popup Start here--%>
                                                    <cc1:ModalPopupExtender ID="popupclaimant" runat="server" PopupControlID="pnlclaimant" TargetControlID="btnclaimant1"
                                                        OkControlID="btnyescl" CancelControlID="btnnocl" BackgroundCssClass="modalBackground">
                                                    </cc1:ModalPopupExtender>
                                                    <asp:Panel ID="pnlclaimant" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white" Style="display: none">
                                                        <div class="header">

                                                            <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Claimant Party</p>



                                                        </div>
                                                        <div class="body">
                                                            <asp:UpdatePanel ID="upclaimantgrid" runat="server" UpdateMode="Conditional">

                                                                <ContentTemplate>
                                                                    <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                        <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ClaimantSearch" OnTextChanged="ClaimantSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                    </div>

                                                                    <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                        <asp:GridView ID="ClaimantGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ClaimantGrid_PageIndexChanging" OnRowCommand="ClaimantGrid_RowCommand" OnRowDataBound="ClaimantGrid_RowDataBound" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                            <Columns>


                                                                                <asp:TemplateField HeaderText="Code" SortExpression="Id">
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
                                                                                <asp:TemplateField HeaderText="ClaimantID" SortExpression="Id">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblCName1" runat="server"
                                                                                            Text='<%#Eval("ClaimantName1")%>'>
                                                                                        </asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField Visible="false">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="LmkClaimant" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LmkClaimant_Command" CssClass="duration-300 ease-in-out md:max-w-[200px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700">Select </asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </ContentTemplate>

                                                            </asp:UpdatePanel>
                                                        </div>
                                                        <div class="footer" align="right">
                                                            <asp:Button ID="btnyescl" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                            <asp:Button ID="btnnocl" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px] mt-4 w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />

                                                        </div>
                                                    </asp:Panel>

                                                    <%--  search popup End here--%>



                                                    <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                        <div class="w-full">
                                                            <label class="text-gray-500 text-sm font-medium">Claimant ID</label>
                                                            <div class="relative mt-1">

                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ClaimantName1C" MaxLength="17" placeholder="" runat="server" TabIndex="44" type="text" ValidationGroup="CLAIMANT" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ClaimantName1C" ID="RegularExpressionValidator73" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="CLAIMANT"></asp:RegularExpressionValidator>

                                                            </div>
                                                        </div>
                                                        <div class="w-full">
                                                            <label class="text-gray-500 text-sm font-medium">Claimant Name</label>
                                                            <div class="relative mt-1">
                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ClaimantNameC" MaxLength="100" placeholder="" runat="server" TabIndex="45" type="text" ValidationGroup="CLAIMANT" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" Style="text-transform: uppercase;"></asp:TextBox>

                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ClaimantNameC" ID="RegularExpressionValidator5" ValidationExpression="^[\s\S]{0,100}$" runat="server" ErrorMessage="Maximum 100 characters allowed." ValidationGroup="CLAIMANT"></asp:RegularExpressionValidator>

                                                            </div>
                                                        </div>
                                                        <%--  <div class="w-full">
                                                            <button class="duration-300 ease-in-out w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700">
                                                                + Add New Party
             
                                                            </button>
                                                        </div>--%>
                                                        <div class="w-full">
                                                        </div>
                                                    </div>
                                                    <%--  code End for ImpClaimant Partyorter section --%>
                                                    <%-- start tab old code here--%>
                                                    <div class="col-sm-12">
                                                        <div class="row">
                                                            <div class="col-sm-4">

                                                                <!-- DECLARANT COMPANY Search -->
                                                                <div class="modal fade" id="DECLARANTCOMPANYSearch" role="dialog">
                                                                    <div class="modal-dialog">

                                                                        <!-- Modal content-->
                                                                        <div class="modal-content">
                                                                            <div class="modal-header">
                                                                                <%-- <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                                                <button type="button" class="close" data-dismiss="modal">&times;</button>--%>
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

                                    <cc1:TabPanel ID="Cargo" runat="server" HeaderText="Cargo">
                                        <ContentTemplate>
                                            <asp:UpdatePanel ID="upincargo" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>

                                                    <div class="grid grid-cols-1 md:grid-cols-2 gap-6 mt-4 mb-2">
                                                        <!-- Left Column -->
                                                        <div class="space-y-4">



                                                            <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-7">
                                                                <span class="text-white text-sm font-semibold tracking-wide">Inward Transport Details</span>

                                                            </div>
                                                            <div class="w-full" id="carMode" runat="server">
                                                                <label for="staticEmail" class="text-gray-500 text-sm font-medium">Mode</label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" Enabled="false" runat="server" type="text" ID="TextMode" OnTextChanged="TextMode_TextChanged" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" AutoPostBack="true"></asp:TextBox>
                                                                </div>
                                                            </div>

                                                            <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                                <div id="carLoadingPort" runat="server" class="md:max-w-[500px] w-full">
                                                                    <div class="flex justify-between items-end gap-4">

                                                                        <div class="w-full flex items-center gap-2">
                                                                            <!-- Label and search icon together -->
                                                                            <div class="flex items-center gap-1 whitespace-nowrap mt-4">
                                                                                <label class="text-gray-500 text-sm font-medium w-[130px]">Loading Port</label>
                                                                                <asp:ImageButton ID="btnloadport1" runat="server" CssClass="w-5 h-5" ImageUrl="./images/circel-search.svg" />
                                                                            </div>

                                                                            <!-- Textbox with autocomplete -->
                                                                            <div class="relative w-[200] mt-6">
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="TxtLoadShort"
                                                                                    OnTextChanged="TxtLoadShort_TextChanged" AutoPostBack="true" TabIndex="49"
                                                                                    CssClass="w-full h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                                </asp:TextBox>

                                                                                <cc1:AutoCompleteExtender ServiceMethod="GetLodcode" MinimumPrefixLength="1" CompletionInterval="100"
                                                                                    EnableCaching="false" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem"
                                                                                    CompletionListHighlightedItemCssClass="itemHighlighted" CompletionSetCount="10"
                                                                                    TargetControlID="TxtLoadShort" ID="AutoCompleteExtender6" runat="server" FirstRowSelected="true">
                                                                                </cc1:AutoCompleteExtender>
                                                                            </div>

                                                                            <div class="md:max-w-[650px] w-full ">
                                                                                <label class="text-gray-500 text-sm font-medium">Location Name</label>
                                                                                <div class="relative mt-1">

                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="TxtLoad" Enabled="false" TabIndex="50" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" Style="text-transform: uppercase"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                        </div>

                                                                    </div>


                                                                </div>
                                                            </div>

                                                            <div id="carArrival" runat="server" class="md:max-w-[500px] w-full">
                                                                <div class="flex justify-between items-end gap-4">
                                                                    <div class="w-full">
                                                                        <label class="text-gray-500 text-sm font-medium">HBL</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="txthBlCargo" MaxLength="35" AutoPostBack="true" OnTextChanged="txthBlCargo_TextChanged" ValidationGroup="Validation" TabIndex="51" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                                        </div>
                                                                    </div>

                                                                </div>

                                                            </div>

                                                            <div class="md:max-w-[500px] w-full mt-4">
                                                                <label class="text-gray-500 text-sm font-medium">Arrival Date</label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" onkeypress="return isNumberKey(event)" ID="TxtArrivalDate1" runat="server" AutoPostBack="true" OnTextChanged="TxtArrivalDate1_TextChanged" TabIndex="52" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    <img src="./images/calendar.svg" alt="Calendar" class="absolute right-4 top-2.5 pointer-events-none">

                                                                    <cc1:CalendarExtender ID="CalendarExtender1" PopupButtonID="imgPopup" CssClass="cal_Theme1" runat="server" TargetControlID="TxtArrivalDate1" Format="dd/MM/yyyy"></cc1:CalendarExtender>

                                                                    <asp:Label ID="alertarrival" runat="server" ForeColor="Red"></asp:Label>


                                                                </div>
                                                            </div>


                                                            <div id="InwardFlight" runat="server">
                                                                <div class="row col-md-12">
                                                                    <div class="w-full">
                                                                        <label for="staticEmail" class="text-gray-500 text-sm font-medium">Flight Number</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="Validation" type="text" ID="txtflight" TabIndex="62" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" Style="text-transform: uppercase"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtflight" ID="RegularExpressionValidator60" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                        </div>


                                                                    </div>
                                                                    <div class="w-full">
                                                                        <label for="staticEmail" class="text-gray-500 text-sm font-medium">Aircraft Reg No </label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ValidationGroup="Validation" ID="txtaircraft" TabIndex="63" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" Style="text-transform: uppercase"></asp:TextBox>
                                                                            <br />
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtaircraft" ID="RegularExpressionValidator61" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                    </div>

                                                                    <div class="w-full">
                                                                        <label for="staticEmail" class="text-gray-500 text-sm font-medium">Master Air Waybill</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="Validation" AutoPostBack="true" OnTextChanged="txtwaybill_TextChanged" type="text" ID="txtwaybill" TabIndex="64" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" Style="text-transform: uppercase"></asp:TextBox>

                                                                            <asp:RegularExpressionValidator BackColor="Yellow" ID="RegularExpressionValidator2" runat="server" Display="None" ControlToValidate="txtwaybill" ValidationExpression="^[\s\S]{0,35}$" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Validation" />
                                                                        </div>
                                                                    </div>

                                                                </div>


                                                            </div>

                                                            <div id="InwardSea" runat="server">
                                                                <div class="row col-md-12">
                                                                    <div class="w-full">
                                                                        <label for="staticEmail" class="text-gray-500 text-sm font-medium">Voyage Number</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="Validation" type="text" ID="TxtVoyageno" TabIndex="65" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" Style="text-transform: uppercase"></asp:TextBox>

                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtVoyageno" ID="RegularExpressionValidator53" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                        </div>

                                                                    </div>

                                                                    <div class="w-full">
                                                                        <label for="staticEmail" class="text-gray-500 text-sm font-medium">Vessel Name</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ValidationGroup="Validation" ID="TxtVesselName" TabIndex="66" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" Style="text-transform: uppercase"></asp:TextBox>

                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtVesselName" ID="RegularExpressionValidator54" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                    </div>

                                                                    <div class="w-full">
                                                                        <label for="staticEmail" class="text-gray-500 text-sm font-medium">OBL</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ValidationGroup="Validation" ID="TxtOceanBill" TabIndex="67" AutoPostBack="true" OnTextChanged="TxtOceanBill_TextChanged" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" Style="text-transform: uppercase"></asp:TextBox>

                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtOceanBill" ID="RegularExpressionValidator57" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                    </div>



                                                                </div>



                                                            </div>

                                                            <div id="InwardOther" runat="server">

                                                                <div class="row col-md-12">
                                                                    <div class="w-full">
                                                                        <label for="staticEmail" class="text-gray-500 text-sm font-medium">Conveyance Ref.No</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="TxtConRefNo" ValidationGroup="Validation" TabIndex="68" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" Style="text-transform: uppercase"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtConRefNo" ID="RegularExpressionValidator55" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                        </div>

                                                                    </div>
                                                                    <div class="w-full">
                                                                        <label for="staticEmail" class="text-gray-500 text-sm font-medium">Transport ID</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="TxtTrnsID" ValidationGroup="Validation" TabIndex="69" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" Style="text-transform: uppercase"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtTrnsID" ID="RegularExpressionValidator56" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                    </div>



                                                                </div>



                                                                <%--                                                                <div class="form-group row">
                                                                    <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                        Conveyance Ref.No
                                                                    </label>
                                                                   
                                                                </div>
                                                                <div class="form-group row">
                                                                    <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                        
                                                                    </label>
                                                            
                                                                </div>--%>
                                                            </div>

                                                        </div>

                                                        <!-- Left Column -->
                                                        <div class="space-y-4">

                                                            <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-6">
                                                                <span class="text-white text-sm font-semibold tracking-wide">OUTER PACK DETAILS</span>
                                                                <asp:Label ID="Label4" Visible="false" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="w-full flex flex-wrap lg:flex-nowrap items-end gap-4">

                                                                <!-- Total Outer Pack Input -->
                                                                <div class="w-full">
                                                                    <label for="staticEmail" class="text-gray-500 text-sm font-medium">Total Outer Pack</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" MaxLength="8" ValidationGroup="outerpack"
                                                                            onkeypress="return isNumberKey(event)" ID="TxttotalOuterPack" TabIndex="58" AutoPostBack="true"
                                                                            OnTextChanged="TxttotalOuterPack_TextChanged"
                                                                            CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                        </asp:TextBox>

                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow"
                                                                            ControlToValidate="TxttotalOuterPack" ID="RegularExpressionValidator67"
                                                                            ValidationExpression="^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 8 characters allowed."
                                                                            ValidationGroup="outerpack">
                                                                        </asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>

                                                                <!-- Dropdown beside it -->
                                                                <!-- Dropdown beside it -->
                                                                <div class="w-full">
                                                                    <div class="group relative">
                                                                        <div class="text-gray-500 text-sm font-medium opacity-0">Select</div>
                                                                        <asp:DropDownList ID="DrptotalOuterPack"
                                                                            CssClass="bg-slate-100 font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt-1 px-4"
                                                                            runat="server" TabIndex="59" AutoPostBack="true" OnSelectedIndexChanged="DrptotalOuterPack_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>

                                                            </div>



                                                            <div class="w-full flex flex-wrap lg:flex-nowrap items-end gap-4">
                                                                <div class="w-full">

                                                                    <label for="staticEmail" class="text-gray-500 text-sm font-medium">Total Gross Weight</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" MaxLength="15" ValidationGroup="outerpack" ID="TxtTotalGrossWeight" onkeypress="return isNumberKey(event)" TabIndex="60" AutoPostBack="true" OnTextChanged="TxtTotalGrossWeight_TextChanged" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtTotalGrossWeight" ID="RegularExpressionValidator68" ValidationExpression="^[\s\S]{0,15}$" runat="server" ErrorMessage="Maximum 15 characters allowed." ValidationGroup="outerpack"></asp:RegularExpressionValidator>

                                                                    </div>
                                                                </div>
                                                                <div class="w-full">
                                                                    <div class="group relative">
                                                                        <div class="text-gray-500 text-sm font-medium opacity-0">
                                                                            Select
                 
                                                                        </div>
                                                                        <asp:DropDownList ID="DrpTotalGrossWeight" CssClass="bg-slate-100 font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt-1 px-4" runat="server" TabIndex="61" AutoPostBack="true" OnSelectedIndexChanged="DrpTotalGrossWeight_SelectedIndexChanged">
                                                                            <asp:ListItem Selected="True" Text="--Select--" Value="--SELECT--"> </asp:ListItem>
                                                                            <asp:ListItem Text="KGM" Value="KGM"> </asp:ListItem>
                                                                            <asp:ListItem Text="TNE" Value="TNE"> </asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="w-full flex flex-wrap lg:flex-nowrap items-end gap-4">
                                                                <div class="w-full">

                                                                    <label for="staticEmail" class="text-gray-500 text-sm font-medium">Total Permit Gross Weight</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" MaxLength="15" ValidationGroup="outerpack" Enabled="false" ID="txtTtlPGW" onkeypress="return isNumberKey(event)" TabIndex="60" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtTotalGrossWeight" ID="RegularExpressionValidator11" ValidationExpression="^[\s\S]{0,15}$" runat="server" ErrorMessage="Maximum 15 characters allowed." ValidationGroup="outerpack"></asp:RegularExpressionValidator>

                                                                    </div>
                                                                </div>
                                                                <div class="w-full">
                                                                    <div class="group relative">
                                                                        <div class="text-gray-500 text-sm font-medium opacity-0">
                                                                            Select
                 
                                                                        </div>
                                                                        <asp:DropDownList ID="DrpTtlPGW" CssClass="bg-slate-100 font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt-1 px-4" Enabled="false" runat="server" TabIndex="61">
                                                                            <asp:ListItem Selected="True" Text="--Select--" Value="--SELECT--"> </asp:ListItem>
                                                                            <asp:ListItem Text="KGM" Value="KGM"> </asp:ListItem>
                                                                            <asp:ListItem Text="TNE" Value="TNE"> </asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>



                                                            <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-6">
                                                                <span class="text-white text-sm font-semibold tracking-wide">Location Information
                                                                </span>

                                                            </div>


                                                            <div class="w-[200] flex items-center gap-2 mt-4">
                                                                <!-- Label and search icon together -->
                                                                <div class="flex items-center gap-1 whitespace-nowrap mt-5">
                                                                    <label class="text-gray-500 text-sm font-medium w-[130px]">Release Location</label>
                                                                    <asp:ImageButton ID="btlreleaseloc1" runat="server" ImageUrl="./images/circel-search.svg" CssClass="w-5 h-5" />
                                                                </div>

                                                                <!-- Textbox with autocomplete -->
                                                                <div class="relative w-[200px] mt-6">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="Validation" type="text" MaxLength="7"
                                                                        ID="txtreLoctn" OnTextChanged="txtreLoctn_TextChanged" AutoPostBack="true" TabIndex="53"
                                                                        CssClass="w-full h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium outline-none border-none px-4"
                                                                        Style="text-transform: uppercase">
                                                                    </asp:TextBox>

                                                                    <cc1:AutoCompleteExtender ServiceMethod="Getrelloc" MinimumPrefixLength="1" CompletionInterval="100"
                                                                        EnableCaching="false" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem"
                                                                        CompletionListHighlightedItemCssClass="itemHighlighted" CompletionSetCount="10"
                                                                        TargetControlID="txtreLoctn" ID="AutoCompleteExtender7" runat="server" FirstRowSelected="true">
                                                                    </cc1:AutoCompleteExtender>
                                                                </div>

                                                                <div class="w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Location Name</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" MaxLength="256" ID="txtrelocDeta" Enabled="true" ValidationGroup="Validation" TabIndex="54" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtrelocDeta" ID="RegularExpressionValidator12" ValidationExpression="^[\s\S]{0,256}$" runat="server" ErrorMessage="Maximum 256 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>

                                                                        <asp:Label runat="server" ForeColor="Red" BackColor="Yellow" Visible="false" ID="lblrelloc"></asp:Label>

                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="w-[200] flex items-center gap-2 mt-4">
                                                                <div class="flex items-center gap-1 whitespace-nowrap mt-5">
                                                                    <label class="text-gray-500 text-sm font-medium w-[130px]">Receipt Location</label>
                                                                    <asp:ImageButton ID="btnreceiptloc1" runat="server" ImageUrl="./images/circel-search.svg" CssClass="w-5 h-5" />
                                                                </div>

                                                                <div class="relative w-[200px] mt-6">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="Validation" type="text" MaxLength="7" OnTextChanged="txtrecloctn_TextChanged" AutoPostBack="true" ID="txtrecloctn" TabIndex="55" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" Style="text-transform: uppercase"></asp:TextBox>


                                                                    <cc1:AutoCompleteExtender ServiceMethod="GetRecLoc"
                                                                        MinimumPrefixLength="1"
                                                                        CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
                                                                        TargetControlID="txtrecloctn"
                                                                        ID="AutoCompleteExtender8" runat="server" FirstRowSelected="true">
                                                                    </cc1:AutoCompleteExtender>

                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtrecloctn" ID="RegularExpressionValidator13" ValidationExpression="^[\s\S]{0,7}$" runat="server" ErrorMessage="Maximum 7 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>



                                                                </div>


                                                                <div class="w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Location Name</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" TextMode="MultiLine" type="text" MaxLength="256" ID="txtrecloctndet" Enabled="true" TabIndex="56" ValidationGroup="Validation" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" Style="text-transform: uppercase"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtrecloctndet" ID="RegularExpressionValidator14" ValidationExpression="^[\s\S]{0,256}$" runat="server" ErrorMessage="Maximum 256 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>

                                                            </div>
                                                            <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-6">
                                                                <span class="text-white text-sm font-semibold tracking-wide">Date Information
                                                                </span>

                                                            </div>
                                                            <div class="flex items-center gap-2 mt-4">
                                                                <div class="flex items-center gap-1 whitespace-nowrap">
                                                                    <label for="staticEmail" class="text-gray-500 text-sm font-medium w-[130px]">Blanket Start Date</label>
                                                                </div>
                                                                <div class="relative w-full">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="BlankDate1" onkeypress="return isNumberKey(event)" runat="server" TabIndex="57" AutoPostBack="true" OnTextChanged="BlankDate1_TextChanged" class="w-full h-10 bg-slate-100 rounded-md flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    <img src="./images/calendar.svg" alt="Calendar" class="absolute right-4 top-2.5 pointer-events-none">


                                                                    <cc1:CalendarExtender ID="CalendarExtender2" PopupButtonID="imgPopup" CssClass="cal_Theme1" runat="server" TargetControlID="BlankDate1" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"></cc1:CalendarExtender>
                                                                </div>

                                                            </div>


                                                        </div>
                                                    </div>


                                                    <%--  code start for  Loading Port  section --%>














                                                    <%--  search popup Start here--%>
                                                    <cc1:ModalPopupExtender ID="popuploadingport" runat="server" PopupControlID="pnlloadingport" TargetControlID="btnloadport1"
                                                        OkControlID="btnyeslp" CancelControlID="btnnolp" BackgroundCssClass="modalBackground">
                                                    </cc1:ModalPopupExtender>
                                                    <asp:Panel ID="pnlloadingport" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white" Style="display: none">
                                                        <div class="header">

                                                            <%--   <svg class="cursor-pointer absolute right-5 top-5" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                <circle opacity="0.1" cx="12" cy="12" r="12" fill="#676D7C"></circle>
                                                                <path d="M16.6663 7.3335L7.33301 16.6668M7.33301 7.3335L16.6663 16.6668" stroke="#676D7C" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                                            </svg>--%>
                                                            <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">LOADING PORT</p>


                                                        </div>
                                                        <div class="body">
                                                            <asp:UpdatePanel ID="uploadingport" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="CarLoadingSearch" OnTextChanged="CarLoadingSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                    </div>

                                                                    <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
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

                                                                                <asp:TemplateField Visible="false">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="LnkLoading" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkLoading_Command" CssClass="duration-300 ease-in-out md:max-w-[200px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700">Select </asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </ContentTemplate>

                                                            </asp:UpdatePanel>
                                                            <div class="footer" align="right">
                                                                <asp:Button ID="btnyeslp" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                <asp:Button ID="btnnolp" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px] mt-4 w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                            </div>

                                                        </div>
                                                    </asp:Panel>





                                                    <%--  search popup Start here--%>
                                                    <div class="">

                                                        <cc1:ModalPopupExtender ID="popupreleaseloc" runat="server" PopupControlID="pnlrelloc" TargetControlID="btlreleaseloc1"
                                                            OkControlID="btnyesrelloc" CancelControlID="btnnorelloc" BackgroundCssClass="modalBackground">
                                                        </cc1:ModalPopupExtender>
                                                        <asp:Panel ID="pnlrelloc" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                            <div class="header">

                                                                <%-- <svg class="cursor-pointer absolute right-5 top-5" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                    <circle opacity="0.1" cx="12" cy="12" r="12" fill="#676D7C"></circle>
                                                                    <path d="M16.6663 7.3335L7.33301 16.6668M7.33301 7.3335L16.6663 16.6668" stroke="#676D7C" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                                                </svg>--%>
                                                                <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">RELEASE LOCATION</p>



                                                            </div>
                                                            <div class="body">
                                                                <asp:UpdatePanel ID="uprelloc" runat="server" UpdateMode="Conditional">



                                                                    <ContentTemplate>
                                                                        <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                            <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="LocationSearch" OnTextChanged="LocationSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                        </div>

                                                                        <%-- <asp:UpdatePanel ID="UpdatePanelReleaseLocation" runat="server"  UpdateMode="Always"><ContentTemplate>--%>

                                                                        <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
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

                                                                                    <asp:TemplateField Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="LnkLocation" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkLocation_Command" CssClass="duration-300 ease-in-out md:max-w-[200px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700">Select </asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </div>
                                                                    </ContentTemplate>

                                                                </asp:UpdatePanel>

                                                                <div class="footer" align="right">
                                                                    <asp:Button ID="btnyesrelloc" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                    <asp:Button ID="btnnorelloc" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px] mt-4 w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                </div>


                                                            </div>
                                                        </asp:Panel>
                                                    </div>
                                                    <div class="reciptModal">
                                                        <cc1:ModalPopupExtender ID="popupreceiptloc" runat="server" PopupControlID="pnlreceiptloc" TargetControlID="btnreceiptloc1"
                                                            OkControlID="btnyesrecloc" CancelControlID="btnnorecloc" BackgroundCssClass="modalBackground">
                                                        </cc1:ModalPopupExtender>
                                                        <asp:Panel ID="pnlreceiptloc" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                            <div class="header">

                                                                <%--   <svg class="cursor-pointer absolute right-5 top-5" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                    <circle opacity="0.1" cx="12" cy="12" r="12" fill="#676D7C"></circle>
                                                                    <path d="M16.6663 7.3335L7.33301 16.6668M7.33301 7.3335L16.6663 16.6668" stroke="#676D7C" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                                                </svg>--%>
                                                                <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">
                                                                    Receipt Location
                                                                </p>


                                                            </div>
                                                            <div class="body">
                                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">



                                                                    <ContentTemplate>
                                                                        <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                            <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ReceiptSearch" OnTextChanged="ReceiptSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                        </div>


                                                                        <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
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

                                                                                    <asp:TemplateField Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="LnkReceipt" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkReceipt_Command" CssClass="duration-300 ease-in-out md:max-w-[200px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700">Select </asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </div>
                                                                    </ContentTemplate>

                                                                </asp:UpdatePanel>

                                                                <div class="footer" align="right">
                                                                    <asp:Button ID="btnyesrecloc" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                    <%--  <asp:Button ID="Button13" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px] mt-4 w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />--%>

                                                                    <asp:Button ID="btnnorecloc" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px] mt-4 w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                </div>

                                                            </div>
                                                        </asp:Panel>

                                                    </div>















                                                    <div class="row">
                                                        <div class="col-sm-12 text-center">

                                                            <center>

                                                                <div id="gvAddrow" visible="false" runat="server">
                                                                    <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-6">
                                                                        <span class="text-white text-sm font-semibold tracking-wide">Container Information
                                                                        </span>

                                                                    </div>
                                                                    <asp:GridView ID="ContarinerGrid" FooterStyle-CssClass="w-full h-10 py-4 px-10 bg-[#F4F6FA] rounded-lg" CssClass="w-full bg-white rounded whitespace-nowrap" HeaderStyle-CssClass="w-full h-10 py-4 px-10 bg-[#F4F6FA] rounded-l-lg" PagerStyle-CssClass="pager" RowStyle-CssClass="rows" runat="server" OnRowDeleting="ContarinerGrid_RowDeleting" OnRowDataBound="ContarinerGrid_RowDataBound1" ShowFooter="true" AutoGenerateColumns="false">
                                                                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                        <Columns>
                                                                            <asp:BoundField DataField="RowNumber" HeaderText="Seq." Visible="false" />
                                                                            <asp:TemplateField ItemStyle-CssClass="pl-3 text-xs leading-none py-3 px-2 text-gray-800 w-5 relative">
                                                                                <HeaderTemplate>
                                                                                    <div class="pl-2">S.No</div>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#Container.DataItemIndex+1 %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-CssClass="pl-2 text-xs leading-none py-3 px-2 text-gray-800 w-5 relative">
                                                                                <HeaderTemplate>
                                                                                    <div class="pl-2">Container No</div>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txt1" MaxLength="13" CssClass="mr-4 px-3 w-[150px] h-8 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium relative focus:outline-none" TabIndex="70" runat="server"></asp:TextBox>
                                                                                    <asp:RegularExpressionValidator ID="revEmail" ValidationGroup="Validation1" ForeColor="Red" Display="Dynamic"
                                                                                        ValidationExpression="[a-zA-Z]{4}[0-9]{7}" ControlToValidate="txt1"
                                                                                        runat="server"
                                                                                        ErrorMessage="The container no. format should be 4 alphabets and followed by 7 digit, for ex.: ABCD1234567"></asp:RegularExpressionValidator>
                                                                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator23" runat="server" Font-Size="XX-Small" ControlToValidate="txt1" ErrorMessage="Container No is Required" ForeColor="Red" ValidationGroup="Container"></asp:RequiredFieldValidator>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-CssClass="pl-2 text-xs leading-none py-3 px-2 text-gray-800 w-5 relative">
                                                                                <HeaderTemplate>
                                                                                    <div class="pl-2">Size / Type</div>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:DropDownList ID="DrpType" CssClass="mr-4 px-3 w-[150px] h-8 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium relative focus:outline-none" TabIndex="71" runat="server"></asp:DropDownList>
                                                                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator233" InitialValue="0" runat="server" Font-Size="XX-Small" ControlToValidate="DrpType" ErrorMessage="Size / Type is Required" ForeColor="Red" ValidationGroup="Container"></asp:RequiredFieldValidator>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-CssClass="pl-2 text-xs leading-none py-3 px-2 text-gray-800 w-5 relative">
                                                                                <HeaderTemplate>
                                                                                    <div class="pl-2">Weight ( TNE )</div>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txt2" onkeypress="return onlyNumbers(event)" CssClass="mr-4 px-3 w-[150px] h-8 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium relative focus:outline-none" TabIndex="72" ValidationGroup="Validation1" MaxLength="3" runat="server"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator234" runat="server" Font-Size="XX-Small" ControlToValidate="txt2" ErrorMessage="Weight is Required" ForeColor="Red" ValidationGroup="Container"></asp:RequiredFieldValidator>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-CssClass="pl-2 text-xs leading-none py-3 px-2 text-gray-800 w-5 relative">
                                                                                <HeaderTemplate>
                                                                                    <div class="pl-2">Seal No</div>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txt3" MaxLength="35" CssClass="mr-4 px-3 w-[150px] h-8 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium relative focus:outline-none" TabIndex="73" runat="server"></asp:TextBox>

                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txt3" ID="RegularExpressionValidator45" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Validation1"></asp:RegularExpressionValidator>
                                                                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator235" runat="server" Font-Size="XX-Small" ControlToValidate="txt3" ErrorMessage="Seal No is Required" ForeColor="Red" ValidationGroup="Container"></asp:RequiredFieldValidator>
                                                                                </ItemTemplate>
                                                                                <FooterStyle HorizontalAlign="Right" />
                                                                                <FooterTemplate>
                                                                                    <asp:Button ID="ButtonAdd" runat="server" Text="+ Add Row" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" ValidationGroup="Container" OnClick="ButtonAdd_Click" />
                                                                                </FooterTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />

                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </div>
                                                            </center>
                                                        </div>
                                                    </div>


                                                    <div class="row">
                                                        <div class="col-sm-12 text-center">

                                                            <center>

                                                                <div id="Div7" runat="server">
                                                                    <asp:GridView ID="GridView2" runat="server" OnRowDeleting="ContarinerGrid_RowDeleting" ShowFooter="true" AutoGenerateColumns="false">
                                                                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                        <Columns>
                                                                            <asp:BoundField DataField="RowNumber" HeaderText="Seq." />
                                                                            <asp:TemplateField HeaderText="Container No" ItemStyle-Width="500">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txt1" BackColor="#e8f0fe" TabIndex="70" runat="server"></asp:TextBox>
                                                                                    <asp:RegularExpressionValidator ID="revEmail" ValidationGroup="Validation1" ForeColor="Red" Display="Dynamic"
                                                                                        ValidationExpression="[a-zA-Z]{4}[0-9]{7}" ControlToValidate="txt1"
                                                                                        runat="server"
                                                                                        ErrorMessage="The container no. format should be 4 alphabets and followed by 7 digit, for ex.: ABCD1234567"></asp:RegularExpressionValidator>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" Font-Size="XX-Small" ControlToValidate="txt1" ErrorMessage="Container No is Required" ForeColor="Red" ValidationGroup="Container"></asp:RequiredFieldValidator>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Size / Type">
                                                                                <ItemTemplate>
                                                                                    <asp:DropDownList ID="DrpType" BackColor="#e8f0fe" CssClass="drop" TabIndex="71" runat="server"></asp:DropDownList>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator233" InitialValue="0" runat="server" Font-Size="XX-Small" ControlToValidate="DrpType" ErrorMessage="Size / Type is Required" ForeColor="Red" ValidationGroup="Container"></asp:RequiredFieldValidator>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Weight ( TNE )">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txt2" onkeypress="return onlyNumbers(event)" Width="100" BackColor="#e8f0fe" TabIndex="72" ValidationGroup="Validation1" MaxLength="3" runat="server"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator234" runat="server" Font-Size="XX-Small" ControlToValidate="txt2" ErrorMessage="Weight is Required" ForeColor="Red" ValidationGroup="Container"></asp:RequiredFieldValidator>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Seal No">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txt3" BackColor="#e8f0fe" TabIndex="73" runat="server"></asp:TextBox>
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

                                                    <div class="flex flex-wrap lg:flex-nowrap gap-3">
                                                        <div class="flex items-center justify-between mb-1">
                                                            <div class="flex items-center gap-1">
                                                                <label class="text-[17px] sa700 leading-[18px] text-gray-800 mb-0 mt-6 w-[200px]">Supplier/Manufacturer Party</label>
                                                                <asp:ImageButton ID="btnsupplier1" CssClass="theme_searchIcon  mt-4" runat="server" ImageUrl="images/searchBlue.png" Height="28" Width="28" />

                                                                <asp:Button ValidationGroup="supply" BackColor="Transparent" CssClass="plusbtn  plusbtnIcon  mt-4" BorderWidth="0px" ID="suppyadd" runat="server" TabIndex="73" OnClick="suppyadd_Click" Text="+" />
                                                            </div>

                                                            <div class="flex-1 min-w-[100px] max-w-[300px] m-1">
                                                                <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" placeholder="" ValidationGroup="supply" ID="txtcodeinvq" OnTextChanged="txtcodeinvq_TextChanged" AutoPostBack="true" TabIndex="75" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    <cc1:AutoCompleteExtender ServiceMethod="GetSupcode" MinimumPrefixLength="1" CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10" TargetControlID="txtcodeinvq" ID="AutoCompleteExtender9" runat="server" FirstRowSelected="true"></cc1:AutoCompleteExtender>
                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtcodeinvq" ID="RegularExpressionValidator31" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="supply"></asp:RegularExpressionValidator>

                                                                </div>
                                                            </div>

                                                            <div class="flex-1 min-w-[200px] max-w-[300px] m-1 mt-6">
                                                                <label class="text-gray-500 text-sm font-medium">CR UEI</label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" MaxLength="17" ID="txtcruei" placeholder="" ValidationGroup="supply" TabIndex="76" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" Style="text-transform: uppercase"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="txtcruei" Font-Size="XX-Small" ForeColor="Red" ErrorMessage="Invoice --> Please Enter  Supplier Party CRUEI " ValidationGroup="Invoice"></asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtcruei" ID="RegularExpressionValidator34" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="supply"></asp:RegularExpressionValidator>

                                                                </div>
                                                            </div>
                                                            <div class="flex-1 min-w-[200px] max-w-[300px] m-1 mt-6">
                                                                <label class="text-gray-500 text-sm font-medium">Name 1 </label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" MaxLength="50" ValidationGroup="supply" ID="txtName" placeholder="" TabIndex="77" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" Style="text-transform: uppercase"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" Font-Size="XX-Small" ForeColor="Red" ErrorMessage="Invoice --> Please Enter  Supplier Party Name " ValidationGroup="Invoice"></asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtName" ID="RegularExpressionValidator32" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="supply"></asp:RegularExpressionValidator>


                                                                </div>
                                                            </div>
                                                            <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                <label class="text-gray-500 text-sm font-medium">Name 2</label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" MaxLength="50" ID="txtName1" placeholder="" ValidationGroup="supply" TabIndex="78" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" Style="text-transform: uppercase"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtName1" ID="RegularExpressionValidator33" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="supply"></asp:RegularExpressionValidator>

                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="flex flex-wrap lg:flex-nowrap gap-3">
                                                        <div class="flex items-center justify-between mb-1">
                                                            <div class="flex items-center gap-1">
                                                                <label class="text-[17px] sa700 leading-[18px] text-gray-800 mb-0 mt-5 w-[200px]">Importer Party</label>
                                                                <asp:ImageButton ID="btninvimp1" runat="server" ImageUrl="images/searchBlue.png" Height="28" Width="28" CssClass="theme_searchIcon mt-4" Style="display: none;" />
                                                                <asp:Button ID="BtnImpPartyADD" Visible="false" BackColor="Transparent" BorderWidth="0px" CssClass="plusbtn  plusbtnIcon mt-4" TabIndex="79" runat="server" ValidationGroup="supply1" OnClick="BtnImpPartyADD_Click" Text="+" />
                                                            </div>
                                                            <div class="flex-1 min-w-[100px] max-w-[300px] m-1">
                                                                <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" Enabled="false" runat="server" type="text" ID="TxtImppartyCode" placeholder="" ValidationGroup="supply1" OnTextChanged="TxtImppartyCode_TextChanged" AutoPostBack="true" TabIndex="79" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    <cc1:AutoCompleteExtender ServiceMethod="GetImppartycode"
                                                                        MinimumPrefixLength="1"
                                                                        CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
                                                                        TargetControlID="TxtImppartyCode"
                                                                        ID="AutoCompleteExtender10" runat="server" FirstRowSelected="true">
                                                                    </cc1:AutoCompleteExtender>

                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtImppartyCode" ID="RegularExpressionValidator35" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="supply"></asp:RegularExpressionValidator>
                                                                </div>
                                                            </div>
                                                            <div class="flex-1 min-w-[200px] max-w-[300px] m-1 mt-6">
                                                                <label class="text-gray-500 text-sm font-medium">CR UEI</label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtImppartyCRUEI" Enabled="false" MaxLength="17" placeholder="" runat="server" TabIndex="80" ValidationGroup="supply1" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtImppartyCRUEI" Font-Size="XX-Small" ForeColor="Red" ErrorMessage="Invoice --> Please Enter  Importer Party CRUEI " ValidationGroup="Invoice"></asp:RequiredFieldValidator>

                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtImppartyCRUEI" ID="RegularExpressionValidator36" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="supply"></asp:RegularExpressionValidator>
                                                                </div>
                                                            </div>
                                                            <div class="flex-1 min-w-[200px] max-w-[300px] m-1 mt-6">
                                                                <label class="text-gray-500 text-sm font-medium">Name 1 </label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtImppartyName" Enabled="false" MaxLength="35" placeholder="" ValidationGroup="supply1" runat="server" TabIndex="81" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtImppartyName" Font-Size="XX-Small" ForeColor="Red" ErrorMessage="Invoice --> Please Enter  Importer Party Name " ValidationGroup="Invoice"></asp:RequiredFieldValidator>

                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtImppartyName" ID="RegularExpressionValidator4" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="supply1"></asp:RegularExpressionValidator>
                                                                </div>
                                                            </div>
                                                            <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                <label class="text-gray-500 text-sm font-medium">Name 2</label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtImppartyName1" Enabled="false" MaxLength="35" placeholder="" runat="server" TabIndex="82" type="text" ValidationGroup="supply1" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtImppartyName1" ID="RegularExpressionValidator6" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="supply1"></asp:RegularExpressionValidator>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>





                                                    <cc1:ModalPopupExtender ID="popupsupplier" runat="server" PopupControlID="pnlsupplier" TargetControlID="btnsupplier1"
                                                        OkControlID="btnyessuplier" CancelControlID="btnnosuplier" BackgroundCssClass="modalBackground">
                                                    </cc1:ModalPopupExtender>
                                                    <asp:Panel ID="pnlsupplier" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                        <div class="header">

                                                            <%-- <svg class="cursor-pointer absolute right-5 top-5" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                <circle opacity="0.1" cx="12" cy="12" r="12" fill="#676D7C"></circle>
                                                                <path d="M16.6663 7.3335L7.33301 16.6668M7.33301 7.3335L16.6663 16.6668" stroke="#676D7C" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                                            </svg>--%>
                                                            <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Supplier / Manufacturer Party</p>


                                                        </div>
                                                        <div class="body">
                                                            <asp:UpdatePanel ID="upsuplier" runat="server" UpdateMode="Conditional">



                                                                <ContentTemplate>
                                                                    <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="SUPPLIERSearch" MaxLength="17" OnTextChanged="SUPPLIERSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                    </div>

                                                                    <%-- <asp:UpdatePanel ID="upd" runat="server"  UpdateMode="Always">

                                                        <ContentTemplate>--%>

                                                                    <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
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
                                                                                <asp:TemplateField Visible="false">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkRequestID" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="lnkRequestID_Command1" CssClass="duration-300 ease-in-out md:max-w-[200px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700">Select </asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>

                                                                        </asp:GridView>
                                                                    </div>
                                                                </ContentTemplate>

                                                            </asp:UpdatePanel>
                                                            <div class="footer" align="right">
                                                                <asp:Button ID="btnyessuplier" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                <asp:Button ID="btnnosuplier" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px] mt-4 w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                            </div>

                                                        </div>
                                                    </asp:Panel>




                                                    <cc1:ModalPopupExtender ID="popupinvimp" runat="server" PopupControlID="pnlinvimp" TargetControlID="btninvimp1"
                                                        OkControlID="btnyesinvimp" CancelControlID="btnnoinvimp" BackgroundCssClass="modalBackground">
                                                    </cc1:ModalPopupExtender>
                                                    <asp:Panel ID="pnlinvimp" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                        <div class="header">

                                                            <%--                                                            <svg class="cursor-pointer absolute right-5 top-5" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                <circle opacity="0.1" cx="12" cy="12" r="12" fill="#676D7C"></circle>
                                                                <path d="M16.6663 7.3335L7.33301 16.6668M7.33301 7.3335L16.6663 16.6668" stroke="#676D7C" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                                            </svg>--%>
                                                            <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Importer Party</p>


                                                        </div>
                                                        <div class="body">
                                                            <asp:UpdatePanel ID="upinvimp" runat="server" UpdateMode="Conditional">



                                                                <ContentTemplate>
                                                                    <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                        <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ImportPartySearch" OnTextChanged="ImportPartySearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                    </div>
                                                                    <br />

                                                                    <%--<asp:UpdatePanel ID="UpdatePanelimporter" runat="server"  UpdateMode="Always">

                                                    <ContentTemplate>--%>
                                                                    <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
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
                                                                                        <asp:LinkButton ID="LnkImportParty" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkImportParty_Command" CssClass="duration-300 ease-in-out md:max-w-[200px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700">Select </asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </div>
                                                                    </div>
                                                                    <div class="footer" align="right">
                                                                        <asp:Button ID="btnyesinvimp" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                        <asp:Button ID="btnnoinvimp" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px] mt-4 w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                </ContentTemplate>
                                                                <%--   <Triggers>
                                                                                                    <asp:PostBackTrigger ControlID="ImportPartyGrid" />
                                                                                                </Triggers>--%>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                    </asp:Panel>

                                                    <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-7">
                                                        <span class="text-white text-sm font-semibold tracking-wide">Invoice Information</span>

                                                    </div>


                                                    <%--                                                    <div class="row">
                                                        <div class="col-sm-4">
                                                            <div class="form-group row">
                                                                <label for="staticEmail" class="col-sm-8 col-form-label">

                                                                    <div class="row">
                                                                        <div class="col-sm-9">
                                                                            Supplier / Manuf Party
                                                                        </div>
                                                                        <div class="col-sm-3">

                                                                          
                                                                            </div>
                                                                    </div>



                                               
                                                                </label>
                                                                <div class="col-sm-4">

                                                                 
                                                                    </div>
                                                            </div>

                                                        </div>
                                                        <div class="col-sm-2">
                                                            <div class="form-group row">

                                                                <div class="col-sm-12">

                                                                    </div>
                                                            </div>

                                                        </div>
                                                        <div class="col-sm-3">
                                                            <div class="form-group row">

                                                                <div class="col-sm-12">

                                                                 
                                                                </div>
                                                            </div>

                                                        </div>
                                                        <div class="col-sm-3">
                                                            <div class="form-group row">

                                                                <div class="col-sm-12">

                                                                  
                                                                    </div>
                                                            </div>

                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-sm-4">
                                                            <div class="form-group row">
                                                                <label for="staticEmail" class="col-sm-8 col-form-label">

                                                                    <div class="row">
                                                                        <div class="col-sm-9">
                                                                            Importer Party
                                                                        </div>
                                                                      
                                                                    </div>



                                                                 
                                                                </label>
                                                               
                                                            </div>

                                                        </div>
                                                        <div class="col-sm-2">
                                                            <div class="form-group row">

                                                               
                                                            </div>

                                                        </div>
                                                        <div class="col-sm-3">
                                                            <div class="form-group row">

                                                              
                                                            </div>

                                                        </div>
                                                        <div class="col-sm-3">
                                                            <div class="form-group row">

                                                                <div class="col-sm-12">
                                                                
                                                                </div>
                                                            </div>

                                                        </div>
                                                    </div>--%>

                                                    <div class="row">
                                                        <div class="col-sm-12" style="text-align: center;">
                                                            <asp:Label ID="lblerrorinv" runat="server" Font-Size="Medium" Font-Bold="true" Text="" ForeColor="Red" Visible="false"></asp:Label>
                                                        </div>
                                                    </div>


                                                    <div class="row" id="InvoiceDiv" runat="server">
                                                        <div class="col-sm-12">
                                                            <asp:ValidationSummary ID="ValidationSummary15" runat="server" ShowMessageBox="True"
                                                                ShowSummary="False" ValidationGroup="Invoice" />


                                                            <div class="row">
                                                                <div class="col-sm-12">
                                                                    <div class="flex justify-between gap-2 items-center mt-7">
                                                                        <h2 class="text-lg sa700 leading-[18px] text-gray-800"></h2>
                                                                    </div>

                                                                    <%--<div class="row Borderdiv" style="width: 100%">
                                                                        INVOICE INFORMATION
                                                                    </div>--%>
                                                                    <div class="mt-2 grid xl:grid-cols-4 md:grid-cols-2 grid-cols-1 justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                                        <div class="w-full">
                                                                            <label class="text-gray-500 text-sm font-medium">Serial Number</label>
                                                                            <div class="relative mt-1">
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="txtserial" Enabled="false" TabIndex="83" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                <br />
                                                                            </div>
                                                                        </div>
                                                                        <div class="w-full">
                                                                            <label class="text-gray-500 text-sm font-medium">Invoice Number</label>
                                                                            <div class="relative mt-1">

                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" MaxLength="35" ID="txtinvNo" ValidationGroup="Invoice" TabIndex="84" class="w3-input w3-hover-green" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" Style="text-transform: uppercase"></asp:TextBox>

                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtinvNo" Font-Size="XX-Small" ForeColor="Red" ErrorMessage="Invoice --> Please Enter Invoice No" ValidationGroup="Invoice"></asp:RequiredFieldValidator>


                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtinvNo" ID="RegularExpressionValidator37" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Invoice"></asp:RegularExpressionValidator>


                                                                            </div>
                                                                        </div>


                                                                        <div class="w-full md:mb-6">
                                                                            <div class="flex gap-4 items-center">


                                                                                <asp:CheckBox runat="server" ID="chkrateind" TabIndex="88" Style="text-transform: none" />
                                                                                <label for="chkrateind" class="text-gray-500 text-sm font-medium">Preferential Duty Rate Indicator</label>
                                                                                <%--<label for="chkrateind" class="text-gray-500 text-sm">Preferential Duty Rate Indicator</label>--%>
                                                                            </div>
                                                                        </div>

                                                                        <div class="w-full md:mb-6">
                                                                            <div class="flex gap-4 items-center">

                                                                                <asp:CheckBox runat="server" ID="chkindicator" TabIndex="87" Text="" Style="text-transform: none" />
                                                                                <label for="chkindicator" class="text-gray-500 text-sm font-medium">Ad Valorem Indicator</label>
                                                                                <%--<label for="chkindicator" class="text-gray-500 text-sm">Ad Valorem Indicator</label>--%>
                                                                            </div>
                                                                        </div>

                                                                        <div class="w-full">
                                                                            <label class="text-gray-500 text-sm font-medium">Invoice Date</label>
                                                                            <div class=' date relative mt-1' id='Div2'>


                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" onkeypress="return isNumberKey(event)" ID="txtinvDate1" runat="server" TabIndex="85" AutoPostBack="true" OnTextChanged="txtinvDate1_TextChanged1" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                <img src="./images/calendar.svg" alt="Calendar" class="absolute right-4 top-2.5 pointer-events-none">
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtinvDate1" Font-Size="XX-Small" ForeColor="Red" ErrorMessage="Invoice --> Please Enter Invoice Date" ValidationGroup="Invoice"></asp:RequiredFieldValidator>


                                                                                <cc1:CalendarExtender ID="CalendarExtender3" PopupButtonID="imgPopup" CssClass="cal_Theme1" runat="server" TargetControlID="txtinvDate1" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"></cc1:CalendarExtender>


                                                                            </div>


                                                                        </div>
                                                                        <div class="w-full">
                                                                            <div class="group relative">
                                                                                <div class="text-gray-500 text-sm font-medium">Term Type</div>
                                                                                <asp:DropDownList CssClass="focus:outline-none bg-slate-100 font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt-1 px-4" ID="DrpTerms" TabIndex="86" runat="server" OnSelectedIndexChanged="DrpTerms_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                                                <br />
                                                                                <br />
                                                                            </div>
                                                                        </div>

                                                                        <div class="w-full mb-5">
                                                                            <div class="group relative">
                                                                                <div class="text-gray-500 text-sm font-medium">Supplier Importer Relationship</div>
                                                                                <asp:DropDownList ID="DrpSupImpRel" CssClass="focus:outline-none bg-slate-100 font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt-1 px-4" TabIndex="89" runat="server">
                                                                                    <asp:ListItem Text="--Select--" Value="--Select--" Selected="True"></asp:ListItem>
                                                                                    <asp:ListItem Text="Ordinary Importer" Value="Ordinary Importer"></asp:ListItem>
                                                                                    <asp:ListItem Text="Agency" Value="Agency" />
                                                                                </asp:DropDownList>


                                                                            </div>
                                                                        </div>

                                                                    </div>

                                                                    <%--   <div class="row">
                                                 
                                                                        <div class="col-sm-4">
                                                                            <div class="row">
                                                                                <div class="col-sm-6">
                                                                                    
                                                                                </div>
                                                                                <div class="col-sm-6">
                                                                                   
                                                                                </div>
                                                                            </div>
                                                                            <br />
                                                                            <div class="row">
                                                                                <p>Supplier Importer Relationship </p>
                                                                              
                                                                                <br />
                                                                            </div>
                                                                        </div>
                                                                    </div>--%>


                                                                    <%--hello--%>
                                                                </div>


                                                            </div>
                                                        </div>


                                                        <hr />


                                                    </div>
                                                    <div class="row">
                                                        <br />
                                                        <div class="col-sm-12">

                                                            <div class="overflow-auto my-shadow whitespace-nowrap mt-6 border border-gray-100 rounded-tl-lg rounded-tr-lg rounded-bl-lg rounded-br-lg">
                                                                <div class="w-full bg-white rounded whitespace-nowrap">
                                                                    <div class="flex headerInvoice w-full h-10 py-4  bg-[#F4F6FA]">
                                                                        <div class="invoiceItem text-[13px] font-medium leading-none text-gray-500 text-left rounded-tl-lg pl-8">
                                                                            Item
                                                                        </div>
                                                                        <div class="invoiceCharges text-[13px] font-medium leading-none text-gray-500 px-2 text-left">
                                                                            Charges(%)
                                                                        </div>
                                                                        <div class="invoiceCurrency text-[13px] font-medium leading-none text-gray-500 px-2 text-left">
                                                                            Currency
                                                                        </div>
                                                                        <div class="invoiceExRate text-[13px] font-medium leading-none text-gray-500 px-2 text-left">
                                                                            Ex.Rate
                                                                        </div>
                                                                        <div class="invoiceAmount text-[13px] font-medium leading-none text-gray-500 px-2 text-left">
                                                                            Amount
                                                                        </div>
                                                                        <div class="invoiceAmount_next text-[13px] font-medium leading-none text-gray-500 px-2 text-left">
                                                                            Amount ($)
                                                                        </div>
                                                                    </div>


                                                                    <div class="flex my-[5px]" runat="server" id="TotalInvoice">
                                                                        <div class="invoiceItem">
                                                                            <p class="h-8 px-3 rounded-md flex items-center text-slate-500 pb-2 pt-3 text-[13px] font-medium pl-8">Total Invoice</p>
                                                                        </div>
                                                                        <div class="invoiceCharges">
                                                                        </div>

                                                                        <div class="invoiceCurrency">

                                                                            <asp:DropDownList ID="Drpcurrency1" CssClass="font-normal bg-slate-100 rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt- px-4" OnSelectedIndexChanged="Drpcurrency1_SelectedIndexChanged" BackColor="#e8f0fe" AutoPostBack="true" AppendDataBoundItems="true" TabIndex="90" runat="server">
                                                                            </asp:DropDownList>


                                                                        </div>
                                                                        <div class="invoiceExRate">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" Text="0.00" ID="LblTotalInvoice" Enabled="false" CssClass="w-full px-3 h-8 bg-slate-100 rounded-md flex items-center text-slate-300 text-[13px] font-medium"></asp:TextBox>
                                                                            <%--<asp:Label runat="server" Text="0.00" ID="LblTotalInvoice"></asp:Label>--%>
                                                                        </div>
                                                                        <div class="invoiceAmount">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" onfocus="removeCommas(this)" OnBlur="addCommas(this)" onkeypress="return isNumberKey(event)" Text="0.00" ID="TxtTotalInvoice" MaxLength="16" OnTextChanged="TxtTotalInvoice_TextChanged" AutoPostBack="true" TabIndex="91" ValidationGroup="Item" CssClass="px-3 h-8 bg-slate-100 rounded-md flex items-center text-slate-300 text-[13px] font-medium w-full"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtTotalInvoice" ID="RegularExpressionValidator86" ValidationExpression="^[0-9\s\.]+$" runat="server" ErrorMessage="Not Accepted Special Charector" ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                        <div class="invoiceAmount_next">
                                                                            <asp:Label runat="server" Text="0.00" ID="SumTotalInvoice"></asp:Label>

                                                                        </div>
                                                                    </div>

                                                                    <div class="flex my-[5px]" runat="server" id="OtherTaxableCharge">
                                                                        <div class="invoiceItem">
                                                                            <p class="h-8 px-3 rounded-md flex items-center text-slate-500 pb-2 pt-3 text-[13px] font-medium pl-8">Other Taxable Charge</p>
                                                                        </div>
                                                                        <div class="invoiceCharges">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" onkeypress="return isNumberKey(event)" runat="server" Text="0.00" ID="OtherTaxableChargePer" OnTextChanged="OtherTaxableChargePer_TextChanged" AutoPostBack="true" TabIndex="92" CssClass="px-3 h-8 bg-slate-100 rounded-md flex items-center text-slate-300 text-[13px] font-medium w-full"></asp:TextBox>
                                                                        </div>
                                                                        <div class="invoiceCurrency">
                                                                            <asp:DropDownList ID="Drpcurrency2" CssClass="font-normal bg-slate-100 rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt- px-4" OnSelectedIndexChanged="Drpcurrency2_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true" TabIndex="93" runat="server">
                                                                            </asp:DropDownList>


                                                                        </div>
                                                                        <div class="invoiceExRate">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" Text="0.00" ID="lblOtherTaxableCharge" Enabled="false" CssClass="px-3 h-8 bg-slate-100 rounded-md flex items-center text-slate-300 text-[13px] py-4 font-medium w-full"></asp:TextBox>
                                                                            <%--<asp:Label runat="server" Text="0.00" ID="lblOtherTaxableCharge"></asp:Label>--%>
                                                                        </div>
                                                                        <div class="invoiceAmount">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" Text="0.00" onfocus="removeCommas(this)" OnBlur="addCommas(this)" onkeypress="return isNumberKey(event)" ID="TxtOtherTaxableCharge" MaxLength="16" OnTextChanged="TxtOtherTaxableCharge_TextChanged" AutoPostBack="true" TabIndex="94" ValidationGroup="Item" CssClass="px-3 h-8 bg-slate-100 rounded-md flex items-center text-slate-300 text-[13px] py-4 font-medium w-full"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtOtherTaxableCharge" ID="RegularExpressionValidator69" ValidationExpression="^[0-9\s\.]+$" runat="server" ErrorMessage="Not Accepted Special Charector" ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                        <div class="invoiceAmount_next">
                                                                            <asp:Label runat="server" Text="0.00" ID="SumOtherTaxableCharge"></asp:Label>
                                                                        </div>
                                                                    </div>

                                                                    <div class="flex my-[5px]" runat="server" id="FrieghtCharges">
                                                                        <div class="invoiceItem">
                                                                            <p class="h-8 px-3 rounded-md flex items-center text-slate-500 pb-2 pt-3 text-[13px] font-medium pl-8">
                                                                                Frieght Charges
                                                                                (<asp:CheckBox runat="server" ID="CheckBox1" Text="Inculde Other Taxable Charge" TabIndex="85" />)

                                                                            </p>
                                                                        </div>
                                                                        <div class="invoiceCharges">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" onkeypress="return isNumberKey(event)" runat="server" Text="0.00" ID="FrieghtChargesPer" OnTextChanged="FrieghtChargesPer_TextChanged" AutoPostBack="true" TabIndex="95" CssClass="px-3 h-8 bg-slate-100 rounded-md flex items-center text-slate-300 text-[13px] py-4 font-medium w-full"></asp:TextBox>
                                                                        </div>
                                                                        <div class="invoiceCurrency">
                                                                            <asp:DropDownList ID="Drpcurrency3" CssClass="font-normal bg-slate-100 rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt- px-4" OnSelectedIndexChanged="Drpcurrency3_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true" TabIndex="96" runat="server">
                                                                            </asp:DropDownList>


                                                                        </div>
                                                                        <div class="invoiceExRate">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" Text="0.00" ID="LblFrieghtCharges" CssClass="aspNetDisabled px-3 h-8 bg-slate-100 rounded-md flex items-center text-slate-300 text-[13px] py-4 font-medium w-full"></asp:TextBox>
                                                                            <%--<asp:Label runat="server" Text="0.00" ID="LblFrieghtCharges"></asp:Label>--%>
                                                                        </div>
                                                                        <div class="invoiceAmount">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" onkeypress="return isNumberKey(event)" runat="server" type="text" Text="0.00" ValidationGroup="Item" onfocus="removeCommas(this)" OnBlur="addCommas(this)" ID="TxtFrieghtCharges" OnTextChanged="TxtFrieghtCharges_TextChanged" AutoPostBack="true" TabIndex="97" CssClass="px-3 h-8 bg-slate-100 rounded-md flex items-center text-slate-300 text-[13px] py-4 font-medium w-full"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtFrieghtCharges" ID="RegularExpressionValidator70" ValidationExpression="^[0-9\s\.]+$" runat="server" ErrorMessage="Not Accepted Special Charector" ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                        <div class="invoiceAmount_next">
                                                                            <asp:Label runat="server" Text="0.00" ID="SumFrieghtCharges" Enabled="false"></asp:Label>
                                                                        </div>
                                                                    </div>

                                                                    <div class="flex my-[5px]" runat="server" id="InsuranceCharges">
                                                                        <div class="invoiceItem">
                                                                            <p class="h-8 px-3 rounded-md flex items-center text-slate-500 pb-2 pt-3 text-[13px] font-medium pl-8">
                                                                                Insurance Charges
                                                                                <%--( &nbsp;&nbsp;&nbsp;<asp:CheckBox runat="server" ID="chkchrge" TabIndex="98" Text="Inculde Other Taxable Charge" />)--%>
                                                                            </p>
                                                                        </div>
                                                                        <div class="invoiceCharges">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" onkeypress="return isNumberKey(event)" runat="server" Text="0.00" ID="InsuranceChargesPer" OnTextChanged="InsuranceChargesPer_TextChanged" AutoPostBack="true" TabIndex="99" CssClass="px-3 h-8 bg-slate-100 rounded-md flex items-center text-slate-300 text-[13px] font-medium w-full"></asp:TextBox>
                                                                        </div>
                                                                        <div class="invoiceCurrency">
                                                                            <asp:DropDownList ID="Drpcurrency4" CssClass="font-normal rounded-md bg-slate-100 text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt- px-4" OnSelectedIndexChanged="Drpcurrency4_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true" TabIndex="100" runat="server">
                                                                            </asp:DropDownList>
                                                                            <br />

                                                                        </div>
                                                                        <div class="invoiceExRate">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" Text="0.00" ID="lblInsuranceCharges" CssClass="aspNetDisabled px-3 h-8 bg-slate-100 rounded-md flex items-center text-slate-300 text-[13px] py-4 font-medium w-full"></asp:TextBox>
                                                                            <%--<asp:Label runat="server" Text="0.00" ID="lblInsuranceCharges"></asp:Label>--%>
                                                                        </div>
                                                                        <div class="invoiceAmount">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" onkeypress="return isNumberKey(event)" runat="server" type="text" Text="0.00" onfocus="removeCommas(this)" OnBlur="addCommas(this)" ID="TxtInsuranceCharges" MaxLength="16" TabIndex="101" OnTextChanged="TxtInsuranceCharges_TextChanged" AutoPostBack="true" ValidationGroup="Item" CssClass="px-3 h-8 bg-slate-100 rounded-md flex items-center text-slate-300 text-[13px] font-medium w-full"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtInsuranceCharges" ID="RegularExpressionValidator71" ValidationExpression="^[0-9\s\.]+$" runat="server" ErrorMessage="Not Accepted Special Charector" ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                        <div class="invoiceAmount_next">
                                                                            <asp:Label runat="server" Text="0.00" ID="SumInsuranceCharges"></asp:Label>
                                                                        </div>
                                                                    </div>

                                                                    <div class="flex my-[5px]" runat="server" id="CostInsuranceandFreight">
                                                                        <div class="invoiceItem">
                                                                            <p class="h-8 px-3 rounded-md flex items-center text-slate-500 pb-2 pt-3 text-[13px] font-medium pl-8">Cost, Insurance and Freight</p>
                                                                        </div>
                                                                        <div class="invoiceCharges">
                                                                        </div>
                                                                        <div class="invoiceCurrency">
                                                                        </div>
                                                                        <div class="invoiceExRate">
                                                                        </div>
                                                                        <div class="invoiceAmount">
                                                                        </div>
                                                                        <div class="invoiceAmount_next">
                                                                            <asp:Label runat="server" Text="0.00" ID="LblSumOFTotal"></asp:Label>
                                                                        </div>
                                                                    </div>

                                                                    <div class="flex my-[5px]" runat="server" id="GST">
                                                                        <div class="invoiceItem">
                                                                            <p class="h-8 px-3 rounded-md flex items-center text-slate-500 pb-2 pt-3 text-[13px] font-medium pl-8">GST</p>
                                                                        </div>
                                                                        <div class="invoiceCharges">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" onkeypress="return isNumberKey(event)" CssClass="font-normal rounded-md bg-slate-100 text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt- px-4" runat="server" Enabled="true" Text="9" ID="LblGSTpercentage"></asp:TextBox>
                                                                        </div>
                                                                        <div class="invoiceCurrency">
                                                                        </div>
                                                                        <div class="invoiceExRate">
                                                                        </div>
                                                                        <div class="invoiceAmount">
                                                                        </div>
                                                                        <div class="invoiceAmount_next">
                                                                            <asp:Label runat="server" Text="0.00" ID="lblGSTAmount"></asp:Label>
                                                                        </div>
                                                                    </div>

                                                                </div>
                                                            </div>


                                                            <hr />
                                                            <div class="row">
                                                                <!-- Importer Search -->

                                                                <div class="col-sm-8">
                                                                    <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                                                                        ShowSummary="False" ValidationGroup="Invoice" />
                                                                </div>
                                                                <div class="col-sm-4">
                                                                    <asp:Button ID="BtnAddInvoice" ValidationGroup="Invoice" runat="server" Visible="false" CssClass="btn btn-block btn-success" Text="Add Invoice" OnClick="BtnAddInvoice_Click" />

                                                                </div>


                                                            </div>
                                                        </div>
                                                    </div>


                                                    <div class="flex justify-end gap-4 md:flex-nowrap flex-wrap mt-4">

                                                        <asp:Button ID="btnsaveinvoice" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] bg-opacity-10 border hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-[#0560FD] text-center rounded-md text-sm sa700 PULL-RIGHT" runat="server" ValidationGroup="Ivoice" OnClick="BtnAddInvoice_Click" Text="Add Invoice" TabIndex="103" />



                                                        <button style="display: none;" class="duration-300 ease-in-out bg-opacity-10 md:max-w-[120px] w-full bg-[#D81616] border hover:bg-transparent text-[#D81616] h-10 flex items-center justify-center text-center rounded-md text-sm sa700">
                                                            Delete Invoice
             
                                                        </button>
                                                    </div>





                                                    <div id="InvoiceGrid" runat="server">
                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="AddInvoiceSearch" Visible="false" OnTextChanged="AddInvoiceSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                        <br />
                                                        <div class="table-responsive">
                                                            <asp:GridView ID="AddInvoiceGrid" OnRowDeleting="AddInvoiceGrid_RowDeleting" PageSize="100" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="AddInvoiceGrid_PageIndexChanging" FooterStyle-CssClass="w-full h-10 py-4 px-10 bg-[#F4F6FA] rounded-lg" CssClass="w-full bg-white rounded whitespace-nowrap" HeaderStyle-CssClass="w-full h-10 py-4 px-10 bg-[#F4F6FA] rounded-l-lg" PagerStyle-CssClass="pager" RowStyle-CssClass="rows" runat="server" AutoGenerateColumns="false">
                                                                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                <Columns>

                                                                    <asp:TemplateField HeaderText="ID" Visible="false" SortExpression="Id">

                                                                        <ItemTemplate>
                                                                            <p class="text-slate-500 text-xs font-medium py-3 md:px-0 px-2 rounded-l-lg ">
                                                                                <asp:Label ID="lblID" runat="server"
                                                                                    Text='<%#Eval("Id")%>'></asp:Label>
                                                                            </p>
                                                                        </ItemTemplate>




                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField SortExpression="Id">
                                                                        <HeaderTemplate>
                                                                            <p class="pl-6">S.no</p>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <p class="text-slate-500 text-xs font-medium py-3  rounded-l-lg pl-6">
                                                                                <asp:Label ID="lblCode" runat="server"
                                                                                    Text='<%#Eval("SNo")%>'>
                                                                                </asp:Label>
                                                                            </p>
                                                                        </ItemTemplate>

                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Inv No" SortExpression="Id">
                                                                        <ItemTemplate>
                                                                            <p class="text-slate-500 text-xs font-medium py-3 md:px-0 px-2 rounded-l-lg">
                                                                                <asp:Label ID="lblName" runat="server"
                                                                                    Text='<%#Eval("InvoiceNo")%>'>
                                                                                </asp:Label>
                                                                            </p>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Date" SortExpression="Id">
                                                                        <ItemTemplate>
                                                                            <p class="text-slate-500 text-xs font-medium py-3 md:px-0 px-2 rounded-l-lg">
                                                                                <asp:Label ID="lblName1" runat="server"
                                                                                    Text='<%#Eval("INVDatee")%>'>
                                                                                </asp:Label>
                                                                            </p>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Term Type" SortExpression="Id">
                                                                        <ItemTemplate>
                                                                            <p class="text-slate-500 text-xs font-medium py-3 md:px-0 px-2 rounded-l-lg">
                                                                                <asp:Label ID="lblterm" runat="server"
                                                                                    Text='<%#Eval("tt")%>'>
                                                                                </asp:Label>
                                                                            </p>

                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Suplier Name" SortExpression="Id">
                                                                        <ItemTemplate>
                                                                            <p class="text-slate-500 text-xs font-medium py-3 md:px-0 px-2 rounded-l-lg">
                                                                                <asp:Label ID="lblCRUEI" runat="server"
                                                                                    Text='<%#Eval("SupplierCode")%>'>
                                                                                </asp:Label>
                                                                            </p>

                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Currency" SortExpression="Id">
                                                                        <ItemTemplate>
                                                                            <p class="text-slate-500 text-xs font-medium py-3 md:px-0 px-2 rounded-l-lg">
                                                                                <asp:Label ID="lblTICurrency" runat="server"
                                                                                    Text='<%#Eval("TICurrency")%>'>
                                                                                </asp:Label>
                                                                            </p>

                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Ex. Rate" SortExpression="Id">
                                                                        <ItemTemplate>
                                                                            <p class="text-slate-500 text-xs font-medium py-3 md:px-0 px-2 rounded-l-lg">
                                                                                <asp:Label ID="lblTIExRate" runat="server"
                                                                                    Text='<%#Eval("TIExRate")%>'>
                                                                                </asp:Label>
                                                                            </p>

                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="GST" SortExpression="Id">
                                                                        <ItemTemplate>
                                                                            <p class="text-slate-500 text-xs font-medium py-3 md:px-0 px-2 rounded-l-lg">
                                                                                <asp:Label ID="lblCRUEI1" runat="server"
                                                                                    Text='<%#Eval("GSTSUMAmount")%>'>
                                                                                </asp:Label>
                                                                            </p>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Total" SortExpression="Id">
                                                                        <ItemTemplate>
                                                                            <p class="text-slate-500 text-xs font-medium py-3 md:px-0 px-2 rounded-l-lg">
                                                                                <asp:Label ID="lblTIAmount" runat="server"
                                                                                    Text='<%#Eval("TIAmount")%>'>
                                                                                </asp:Label>
                                                                            </p>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Total (SGD)" SortExpression="Id">
                                                                        <ItemTemplate>
                                                                            <p class="text-slate-500 text-xs font-medium py-3 md:px-0 px-2 rounded-l-lg">
                                                                                <asp:Label ID="lblTISAmount" runat="server"
                                                                                    Text='<%#Eval("TISAmount")%>'>
                                                                                </asp:Label>
                                                                            </p>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left">
                                                                        <ItemTemplate>
                                                                            <div class="flex gap-4 items-center pr-6 status-action">
                                                                                <div class="relative">
                                                                                    <asp:ImageButton CssClass="hover-img" ImageUrl="images/blue-pencil.svg" Width="16" Height="16" OnClick="InvoiceEdit_Click" ID="InvoiceEdit" runat="server" />
                                                                                    <asp:ImageButton ImageUrl="images/pencil.svg" Width="16" Height="16" OnClick="InvoiceEdit_Click" ID="ImageButton1" runat="server" />
                                                                                </div>
                                                                                <div class="relative">

                                                                                    <asp:LinkButton CssClass="hover-img" data-target='<%#"#"+DataBinder.Eval(Container.DataItem,"Id")%>' Width="16" OnClick="imgInvoiceDelete_Click" Height="16" ID="imgInvoiceDelete" runat="server"><img src="images/red-bin.svg" /> </asp:LinkButton>
                                                                                    <asp:LinkButton data-target='<%#"#"+DataBinder.Eval(Container.DataItem,"Id")%>' Width="16" OnClick="imgInvoiceDelete_Click" Height="16" ID="LinkButton2" runat="server"><img src="images/bin-gray.svg" /> </asp:LinkButton>




                                                                                    <%--              <asp:LinkButton data-target='<%#"#"+DataBinder.Eval(Container.DataItem,"Id")%>' Width="16" OnClick="imgInvoiceDelete_Click" Height="16" ID="LinkButton2" runat="server">
  <i class='fa fa-trash' style="color:red;"> </i></asp:LinkButton>--%>
                                                                                </div>
                                                                            </div>

                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>


                                                                </Columns>
                                                                <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                                            </asp:GridView>
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




                                                        <label for="staticEmail" class=" col-form-label">
                                                            <p id="inhab" style="margin-left: -0px;" visible="false" runat="server">In HAWB/OBL</p>
                                                            <p id="inhbl" style="margin-left: -0px;" visible="false" runat="server">HBL</p>
                                                            <p id="p1" style="margin-left: -0px;" visible="false" runat="server">HAWB</p>
                                                        </label>

                                                        <div class="grid grid-cols-1 md:grid-cols-3 gap-6 mt-4 mb-2">

                                                            <!-- Left Column -->
                                                            <div class="space-y-4">
                                                                <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-6">
                                                                    <span class="text-white text-sm font-semibold tracking-wide">Item Information

                                                                    </span>

                                                                </div>
                                                                <div class="w-full">
                                                                    <div class="group relative flex items-center gap-4">
                                                                        <!-- Flex row added -->

                                                                        <!-- Label on the left -->
                                                                        <div class="text-gray-500 text-sm font-medium w-[70px]" id="phawb" runat="server">HAWB</div>

                                                                        <!-- Input on the right -->
                                                                        <div class="flex-1">
                                                                            <asp:DropDownList
                                                                                CssClass="focus:outline-none bg-slate-100 font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 px-4"
                                                                                ID="TxtHAWB"
                                                                                runat="server"
                                                                                TabIndex="106"
                                                                                ValidationGroup="Item"
                                                                                onblur="Frightforwardcheck();">
                                                                            </asp:DropDownList>

                                                                            <asp:RegularExpressionValidator
                                                                                Display="Dynamic"
                                                                                BackColor="yellow"
                                                                                ControlToValidate="TxtHAWB"
                                                                                ID="RegularExpressionValidator15"
                                                                                ValidationExpression="^[\s\S]{0,35}$"
                                                                                runat="server"
                                                                                ErrorMessage="Maximum 35 characters allowed."
                                                                                ValidationGroup="Item">
                                                                            </asp:RegularExpressionValidator>
                                                                        </div>

                                                                    </div>
                                                                </div>
                                                                <div class="w-full">
                                                                    <div class="group relative flex items-center gap-4">

                                                                        <!-- Label with fixed width -->
                                                                        <div class="text-gray-500 text-sm font-medium w-[70px]" id="Div8" runat="server">Term Type</div>

                                                                        <!-- Input taking remaining space -->
                                                                        <div class="flex-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)"
                                                                                placeholder="Type Term Type"
                                                                                autocomplete="off"
                                                                                ID="txttermtyp"
                                                                                runat="server"
                                                                                TabIndex="107"
                                                                                type="text"
                                                                                CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                            </asp:TextBox>
                                                                        </div>

                                                                    </div>
                                                                </div>

                                                                <div class="w-full">
                                                                    <div class="group relative flex items-center gap-4">

                                                                        <!-- Label with fixed width -->
                                                                        <label class="text-gray-500 text-sm font-medium w-[70px]">Item Code</label>

                                                                        <!-- Input and AutoCompleteExtender -->
                                                                        <div class="flex-1 relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)"
                                                                                autocomplete="off"
                                                                                ID="TxtInHouseItem"
                                                                                OnTextChanged="TxtInHouseItem_TextChanged"
                                                                                AutoPostBack="true"
                                                                                runat="server"
                                                                                TabIndex="107"
                                                                                type="text"
                                                                                CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                            </asp:TextBox>

                                                                            <cc1:AutoCompleteExtender
                                                                                ServiceMethod="GetInhouse"
                                                                                MinimumPrefixLength="1"
                                                                                CompletionInterval="100"
                                                                                CompletionListCssClass="ac_results"
                                                                                CompletionListItemCssClass="listItem"
                                                                                CompletionListHighlightedItemCssClass="itemHighlighted"
                                                                                EnableCaching="false"
                                                                                CompletionSetCount="10"
                                                                                TargetControlID="TxtInHouseItem"
                                                                                ID="AutoCompleteExtender11"
                                                                                runat="server"
                                                                                FirstRowSelected="true">
                                                                            </cc1:AutoCompleteExtender>
                                                                        </div>

                                                                    </div>
                                                                </div>

                                                                <div class="w-full">
                                                                    <div class="group relative flex items-center gap-4">

                                                                        <!-- Label with fixed width -->

                                                                        <label class="text-gray-500 text-sm font-medium w-[70px]">HS Code </label>

                                                                        <asp:ImageButton ID="btnhscode1" CssClass="theme_searchIcon mb-35" runat="server" ImageUrl="images/searchBlue.png" Height="28" Width="28" />
                                                                        <!-- Input + AutoComplete + Icon -->
                                                                        <div class="flex-1 relative mt-1">
                                                                            <div class="row">
                                                                                <div class="col-sm-12 ">
                                                                                    <asp:Label ID="lblhserror" Visible="false" CssClass="hserror" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="Brown" runat="server"></asp:Label>
                                                                                    <asp:Label ID="lbldhserror" Visible="false" CssClass="hserror" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="Brown" runat="server"></asp:Label>
                                                                                </div>
                                                                            </div>
                                                                            <asp:Label ID="is_inpayment_controlled" runat="server" Style="background: yellow;" />

                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)"
                                                                                placeholder="Search HS Code"
                                                                                autocomplete="off"
                                                                                MaxLength="8"
                                                                                ID="TxtHSCodeItem"
                                                                                OnTextChanged="TxtHSCodeItem_TextChanged"
                                                                                AutoPostBack="true"
                                                                                runat="server"
                                                                                TabIndex="108"
                                                                                type="text"
                                                                                CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                            </asp:TextBox>


                                                                            <cc1:AutoCompleteExtender
                                                                                ServiceMethod="GetHSCodeItem"
                                                                                MinimumPrefixLength="1"
                                                                                CompletionInterval="100"
                                                                                CompletionListCssClass="ac_results"
                                                                                CompletionListItemCssClass="listItem"
                                                                                CompletionListHighlightedItemCssClass="itemHighlighted"
                                                                                EnableCaching="false"
                                                                                CompletionSetCount="10"
                                                                                TargetControlID="TxtHSCodeItem"
                                                                                ID="AutoCompleteExtender12"
                                                                                runat="server"
                                                                                FirstRowSelected="true">
                                                                            </cc1:AutoCompleteExtender>

                                                                            <asp:RequiredFieldValidator
                                                                                ID="RequiredFieldValidator7"
                                                                                runat="server"
                                                                                ControlToValidate="TxtHSCodeItem"
                                                                                Font-Size="XX-Small"
                                                                                ForeColor="Red"
                                                                                ErrorMessage="Item --> Please Enter HS Code"
                                                                                ValidationGroup="Item">
                                                                            </asp:RequiredFieldValidator>
                                                                            <!-- <img src="./images/circel-search.svg" alt="Search" class="absolute right-4 top-2" /> -->

                                                                        </div>

                                                                    </div>
                                                                </div>

                                                                <div class="w-full">
                                                                    <div class="group relative flex items-start gap-4">

                                                                        <!-- Label on the left -->
                                                                        <label class="text-gray-500 text-sm font-medium w-[70px] mt-1">Description</label>

                                                                        <!-- Multiline textbox and validators -->
                                                                        <div class="flex-1 relative h-full mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)"
                                                                                placeholder="Type Description"
                                                                                autocomplete="off"
                                                                                ID="TxtDescription"
                                                                                OnTextChanged="TxtDescription_TextChanged"
                                                                                AutoPostBack="true"
                                                                                ValidationGroup="Item"
                                                                                TextMode="MultiLine"
                                                                                runat="server"
                                                                                TabIndex="92" ClientIDMode="Static"
                                                                                type="text"
                                                                                MaxLength="512"
                                                                                CssClass="w-full h-[123px] pt-3 px-4 bg-slate-100 resize-none rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none"
                                                                                Style="text-transform: uppercase;">
                                                                            </asp:TextBox>

                                                                            <asp:RequiredFieldValidator
                                                                                ID="RequiredFieldValidator8"
                                                                                runat="server"
                                                                                ControlToValidate="TxtDescription"
                                                                                Font-Size="XX-Small"
                                                                                ForeColor="Red"
                                                                                ErrorMessage="Item --> Please Enter HS Description"
                                                                                ValidationGroup="Item">
                                                                            </asp:RequiredFieldValidator>

                                                                            <asp:RegularExpressionValidator
                                                                                Display="Dynamic"
                                                                                BackColor="yellow"
                                                                                ControlToValidate="TxtDescription"
                                                                                ID="RegularExpressionValidator38"
                                                                                ValidationExpression="^[\s\S]{0,512}$"
                                                                                runat="server"
                                                                                ErrorMessage="Maximum 512 characters allowed."
                                                                                ValidationGroup="Item">
                                                                            </asp:RegularExpressionValidator>


                                                                            <br />

                                                                            <asp:CheckBox ID="chklockitemdesc" runat="server" CssClass="pull-left" Text="Lock Item Description"></asp:CheckBox>

                                                                            <asp:LinkButton ID="lnkcopydesc" runat="server" CssClass="pull-right" OnClick="lnkcopydesc_Click" Text="Copy To All"></asp:LinkButton>


                                                                        </div>

                                                                    </div>
                                                                </div>




                                                                <asp:Label ID="LblCount" ForeColor="Navy" runat="server"></asp:Label>


                                                                <div class="md:w-[196px] w-full">
                                                                    <!-- Label, Icon & First Input -->
                                                                    <div class="flex items-center gap-1 text-gray-500 text-sm font-medium mb-1">
                                                                        <%--<span class="whitespace-nowrap">Country of Origin</span>--%>

                                                                        <label class="text-gray-500 text-sm font-medium w-[70px]">Country of Origin</label>
                                                                        <asp:ImageButton ID="btnorgincountry1" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" />
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtCountryItem" OnTextChanged="TxtCountryItem_TextChanged"
                                                                            AutoPostBack="true" runat="server" TabIndex="110" type="text"
                                                                            CssClass="ml-1 h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium outline-none border border-gray-300 px-2 w-20">
                                                                        </asp:TextBox>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txtcname" TabIndex="111" runat="server" Enabled="false"
                                                                            CssClass=" h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium outline-none border border-gray-300 px-4">
                                                                        </asp:TextBox>

                                                                        <cc1:AutoCompleteExtender ServiceMethod="GetCountryItem" MinimumPrefixLength="1" CompletionInterval="100"
                                                                            CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem"
                                                                            CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
                                                                            TargetControlID="TxtCountryItem" ID="AutoCompleteExtender13" runat="server" FirstRowSelected="true">
                                                                        </cc1:AutoCompleteExtender>

                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TxtCountryItem"
                                                                            Font-Size="XX-Small" ForeColor="Red" ErrorMessage="Item --> Please Enter Country Of Orgin"
                                                                            ValidationGroup="Item">
                                                                        </asp:RequiredFieldValidator>
                                                                    </div>

                                                                    <!-- Second Input Field Aligned Below -->
                                                                    <div class="relative" style="margin-left: calc(135px);">
                                                                    </div>
                                                                </div>




                                                                <cc1:ModalPopupExtender ID="popupcountryoforgin" runat="server" PopupControlID="pnlcountryoforgin" TargetControlID="btnorgincountry1"
                                                                    OkControlID="btnyesco" CancelControlID="btnnoco" BackgroundCssClass="modalBackground">
                                                                </cc1:ModalPopupExtender>
                                                                <asp:Panel ID="pnlcountryoforgin" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                                    <div class="header">

                                                                        <%--  <svg class="cursor-pointer absolute right-5 top-5" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                            <circle opacity="0.1" cx="12" cy="12" r="12" fill="#676D7C"></circle>
                                                                            <path d="M16.6663 7.3335L7.33301 16.6668M7.33301 7.3335L16.6663 16.6668" stroke="#676D7C" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                                                        </svg>--%>
                                                                        <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Country of Origin Search</p>


                                                                    </div>
                                                                    <div class="body">
                                                                        <asp:UpdatePanel ID="upcountryoforgin" runat="server" UpdateMode="Conditional">



                                                                            <ContentTemplate>

                                                                                <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                    <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="CountrySearchItem" OnTextChanged="CountrySearchItem_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                                </div>

                                                                                <%-- <asp:UpdatePanel ID="UpdatePanelCountry" runat="server"  UpdateMode="Always">

<ContentTemplate>--%>
                                                                                <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
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


                                                                                            <asp:TemplateField Visible="false">
                                                                                                <ItemTemplate>
                                                                                                    <asp:LinkButton ID="lnkCountryItem" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="lnkCountryItem_Click" CssClass="duration-300 ease-in-out md:max-w-[200px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700">Select </asp:LinkButton>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </div>
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>
                                                                        <div class="footer" align="right">
                                                                            <asp:Button ID="btnyesco" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                            <asp:Button ID="btnnoco" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px] mt-4 w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />

                                                                        </div>


                                                                    </div>
                                                                </asp:Panel>



                                                            </div>


                                                            <!-- middle Column -->



                                                            <div class="space-y-4 ms-3">

                                                                <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-6">
                                                                    <span class="text-white text-sm font-semibold tracking-wide">Item Information

                                                                    </span>

                                                                </div>
                                                                <div class="w-full flex flex-wrap gap-5">
                                                                    <!-- Unbranded -->
                                                                    <div class="flex gap-2 items-center">
                                                                        <asp:CheckBox ID="ChkUnbrand" OnCheckedChanged="ChkUnbrand_CheckedChanged" TabIndex="113" AutoPostBack="true" runat="server" />
                                                                        <label for="ChkUnbrand" class="text-gray-500 text-sm">Unbranded</label>
                                                                    </div>

                                                                    <!-- DG Indicator -->
                                                                    <div class="flex gap-2 items-center">
                                                                        <asp:CheckBox ID="ChkBGIndicator" runat="server" TabIndex="112" />
                                                                        <label for="ChkBGIndicator" class="text-gray-500 text-sm">DG Indicator</label>
                                                                    </div>
                                                                </div>




                                                                <div class="w-full" style="margin-top: 32px;">
                                                                    <div class="group relative flex gap-1">
                                                                        <label class="text-gray-500 text-sm font-medium w-[70px] mt-4">Brand</label>


                                                                        <div class="relative mt-1 w-[300px] ">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Type Brand Name" autocomplete="off" ID="TxtBrand" MaxLength="35" ValidationGroup="Item" runat="server" TabIndex="114" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" Style="text-transform: uppercase"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TxtBrand" Font-Size="XX-Small" ForeColor="Red" ErrorMessage="Item --> Please Enter Brand" ValidationGroup="Item"></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtBrand" ID="RegularExpressionValidator3" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                            <br />
                                                                            <asp:LinkButton ID="lnkcopybrand" runat="server" CssClass="pull-right" OnClick="lnkcopybrand_Click" Text="Copy To All"></asp:LinkButton>
                                                                            <br />
                                                                            <br />
                                                                        </div>
                                                                    </div>

                                                                </div>

                                                                <div class="w-full" style="margin-top: -9px;">
                                                                    <div class="group relative flex gap-1 ">
                                                                        <label class="text-gray-500 text-sm font-medium w-[70px] mt-4">Model</label>
                                                                        <div class="relative mt-1 w-[300px]">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Type Model" autocomplete="off" ID="TxtModel" MaxLength="35" runat="server" ValidationGroup="Item" TabIndex="115" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" Style="text-transform: uppercase"></asp:TextBox>

                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtModel" ID="RegularExpressionValidator9" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>


                                                                            <br />
                                                                            <asp:LinkButton ID="lnkcopymodel" runat="server" CssClass="pull-right" OnClick="lnkcopymodel_Click" Text="Copy To All"></asp:LinkButton>
                                                                            <br />
                                                                            <br />
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="w-full mt-2">
                                                                    <!-- Label and Input side by side -->
                                                                    <div class="w-full bg-gray-700 text-center rounded-full py-2 mb-6">
                                                                        <span class="text-white text-sm font-semibold tracking-wide">Item Quantity

                                                                        </span>

                                                                    </div>


                                                                    <div id="totDuticableQtyDiv" visible="false" runat="server">


                                                                        <div class="flex items-center gap-2 mb-1">
                                                                            <label class="text-gray-500 text-sm font-medium w-[70px]">Dutiable Quantity</label>
                                                                            <div class="w-[150px]">
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-[125px] h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" onkeypress="return isNumberKey(event)" runat="server" Width="150" type="text" ValidationGroup="Item" Text="0.00" MaxLength="16" ID="TxtTotalDutiableQuantity" OnTextChanged="TxtTotalDutiableQuantity_TextChanged" AutoPostBack="true" TabIndex="120"></asp:TextBox>

                                                                            </div>

                                                                            <div class="w-[150px] mt-1">
                                                                                <asp:DropDownList CssClass="drop font-normal rounded-md text-xs text-slate-400 px-4 h-10 w-[125px] focus:outline-none" ID="TDQUOM" runat="server" Width="100" TabIndex="121"></asp:DropDownList>
                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtTotalDutiableQuantity" ID="RegularExpressionValidator58" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                            </div>

                                                                        </div>





                                                                    </div>


                                                                    <div class="flex items-center gap-2 mb-1">
                                                                        <label class="text-gray-500 text-sm font-medium w-[70px]">Total Dutiable Quantity</label>
                                                                        <div class="w-[150px]">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="2" autocomplete="off" runat="server"
                                                                                type="text" onkeypress="return isNumberKey(event)" ValidationGroup="Item"
                                                                                Text="0.00" ID="txttotDutiableQty" MaxLength="16" OnTextChanged="txttotDutiableQty_TextChanged"
                                                                                AutoPostBack="true" TabIndex="122"
                                                                                CssClass="w-full h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                            </asp:TextBox>
                                                                        </div>

                                                                        <div class="w-[150px] mt-1">
                                                                            <asp:DropDownList CssClass="drop font-normal rounded-md text-xs text-slate-400 px-4 h-10 w-full focus:outline-none" Style="background: #f1f5f9; !important"
                                                                                ID="ddptotDutiableQty" runat="server" TabIndex="123">
                                                                            </asp:DropDownList>
                                                                        </div>

                                                                    </div>

                                                                    <!-- Dropdown placed below input -->

                                                                </div>


                                                                <div class="w-full" style="margin-top: ;">
                                                                    <div class="group relative flex gap-1">
                                                                        <label class="text-gray-500 text-sm font-medium w-[70px] mt-4">
                                                                            Invoice<br />
                                                                            Quantity</label>
                                                                        <div class="relative mt-1  bg-slate-100 rounded-md h-11 w-[300px] ">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Type Invoice Quantity" CssClass="w-full h-11 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" AutoPostBack="true" ValidationGroup="Item" type="text" onkeypress="return isNumberKey(event)" OnTextChanged="TxtInvQty_TextChanged" Text="0.00" ID="TxtInvQty" TabIndex="124"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtInvQty" ID="RegularExpressionValidator59" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                            <asp:Label runat="server" ID="lblinvqty" Visible="false" ForeColor="Red" BackColor="Yellow"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="w-full mt-2">
                                                                    <!-- Label and Input side by side -->
                                                                    <div class="flex items-center gap-2 mb-1  ">
                                                                        <label class="text-gray-500 text-sm font-medium whitespace-nowrap">
                                                                            HS<br />
                                                                            Quantity
                                                                        </label>
                                                                        <div class="w-[150px]">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)"
                                                                                placeholder="Type Quantity"
                                                                                autocomplete="off"
                                                                                runat="server"
                                                                                Text="0.00"
                                                                                ValidationGroup="Item"
                                                                                type="text"
                                                                                onkeypress="return isNumberKey(event)"
                                                                                MaxLength="16"
                                                                                ID="TxtHSQuantity"
                                                                                TabIndex="125"
                                                                                CssClass="w-[125px] h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                            </asp:TextBox>
                                                                        </div>



                                                                        <!-- Dropdown below input -->
                                                                        <div class="full w-[150px] mb-1">
                                                                            <asp:DropDownList
                                                                                CssClass="drop font-normal rounded-md text-xs text-slate-400 px-4 h-10 w-[125px] focus:outline-none" Style="background: #f1f5f9 !important;"
                                                                                ID="HSQTYUOM"
                                                                                runat="server"
                                                                                OnSelectedIndexChanged="HSQTYUOM_SelectedIndexChanged"
                                                                                AutoPostBack="true"
                                                                                TabIndex="126">
                                                                            </asp:DropDownList>
                                                                        </div>

                                                                        <!-- Validators & Label -->
                                                                        <asp:RequiredFieldValidator
                                                                            ID="RequiredFieldValidator11"
                                                                            runat="server"
                                                                            ControlToValidate="TxtHSQuantity"
                                                                            Font-Size="XX-Small"
                                                                            ForeColor="Red"
                                                                            ErrorMessage="Item --> Please Enter HS QTY"
                                                                            ValidationGroup="Item">
                                                                        </asp:RequiredFieldValidator>

                                                                        <asp:RequiredFieldValidator
                                                                            ID="RequiredFieldValidator12"
                                                                            runat="server"
                                                                            ControlToValidate="HSQTYUOM"
                                                                            InitialValue="0"
                                                                            Font-Size="XX-Small"
                                                                            ForeColor="Red"
                                                                            ErrorMessage="Item --> Please Enter HS UOM"
                                                                            ValidationGroup="Item">
                                                                        </asp:RequiredFieldValidator>

                                                                        <asp:RegularExpressionValidator
                                                                            Display="Dynamic"
                                                                            BackColor="yellow"
                                                                            ControlToValidate="TxtHSQuantity"
                                                                            ID="RegularExpressionValidator62"
                                                                            ValidationExpression="^[\s\S]{0,16}$"
                                                                            runat="server"
                                                                            ErrorMessage="Maximum 16 characters allowed."
                                                                            ValidationGroup="Item">
                                                                        </asp:RegularExpressionValidator>

                                                                        <asp:Label ID="LblHSErr" ForeColor="Red" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>


                                                                <div class="w-full" id="AlcoholDiv" visible="false" runat="server">
                                                                    <label class="text-gray-500 text-sm font-medium">Alcohol Per(%)</label>
                                                                    <div class="relative mt-1 top-[4px] bg-slate-100 rounded-md h-11">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="Item" type="text" onkeypress="return isNumberKey(event)" Text="0.00" AutoPostBack="true" ID="txtAlcoholPer" OnTextChanged="txtAlcoholPer_TextChanged" TabIndex="127" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    </div>
                                                                </div>



                                                                <div id="Vehicle" runat="server">


                                                                    <div class="w-full mb-4">

                                                                        <div class="flex items-center gap-2 mb-1">
                                                                            <label class="text-gray-500 text-sm font-medium whitespace-wrap ">
                                                                                Vehicle
                                                                               
                                                                                Type</label>
                                                                            <asp:DropDownList
                                                                                CssClass="focus:outline-none bg-slate-100 font-normal rounded-md text-xs text-slate-400 px-4 h-10 w-full max-w-[250px]"
                                                                                runat="server"
                                                                                ID="DrpVehicleType"
                                                                                TabIndex="128">
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>

                                                                    <div class="flex items-center gap-2 mb-4">
                                                                        <label class="text-gray-500 text-sm font-medium whitespace-wrap ">Engine Capacity</label>
                                                                        <div class="w-[150px]">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-[125px] h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" Width="150" onkeypress="return isNumberKey(event)" type="text" Text="" ID="TextBox4" TabIndex="117" Style="text-transform: uppercase"></asp:TextBox>
                                                                        </div>

                                                                        <div class="w-[150px] mt-1">
                                                                            <asp:DropDownList CssClass=" font-normal rounded-md text-xs text-slate-400 px-4 h-10 w-[125px] focus:outline-none" ID="DrpVehicleCapacity" runat="server" Width="100" TabIndex="118"></asp:DropDownList>

                                                                        </div>

                                                                    </div>


                                                                    <div class="flex items-center gap-2 mb-1">
                                                                        <label for="staticEmail" class="text-gray-500 text-sm font-medium whitespace-wrap  ">
                                                                            Original 
                                                                            <br />
                                                                            Registration
                                                                            <br />
                                                                            Date</label>

                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="focus:outline-none bg-slate-100 font-normal rounded-md text-xs text-slate-400 px-4 h-10 w-full max-w-[250px]" autocomplete="off" ID="OriginalRegDate" TabIndex="119" runat="server" OnTextChanged="OriginalRegDate_TextChanged" AutoPostBack="true" Style="text-transform: uppercase"></asp:TextBox>
                                                                        <cc1:CalendarExtender ID="CalendarExtender4" CssClass="cal_Theme1" PopupButtonID="imgPopup" runat="server" TargetControlID="OriginalRegDate" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"></cc1:CalendarExtender>




                                                                    </div>
                                                                </div>











                                                                <div class="form-group row" style="display: none">
                                                                    <div class="col-sm-3">
                                                                        <asp:CheckBox ID="ChkPackInfo" OnCheckedChanged="ChkPackInfo_CheckedChanged" runat="server" AutoPostBack="true" Text="Packing Info" TabIndex="137" Width="150" Style="text-transform: uppercase" />
                                                                    </div>
                                                                    <div class="col-sm-3">
                                                                        <asp:CheckBox ID="Chkitemcasc" runat="server" OnCheckedChanged="Chkitemcasc_CheckedChanged" AutoPostBack="true" Text="Item CASC" TabIndex="146" Width="150" Style="text-transform: uppercase" />
                                                                    </div>
                                                                    <div class="col-sm-3">
                                                                        <asp:CheckBox ID="ChkTariff" Checked="true" runat="server" OnCheckedChanged="ChkTariff_CheckedChanged" AutoPostBack="true" Text="Tariff" TabIndex="150" Width="150" Style="text-transform: uppercase" />
                                                                    </div>
                                                                    <div class="col-sm-3">
                                                                        <asp:CheckBox ID="Chklot" runat="server" OnCheckedChanged="Chklot_CheckedChanged" AutoPostBack="true" Text="LOT Id" TabIndex="166" Width="150" Style="text-transform: uppercase" />
                                                                    </div>
                                                                </div>


                                                            </div>


                                                            <!-- last Column -->
                                                            <div class="space-y-4">

                                                                <div id="editnextprev" runat="server">
                                                                    <%--  <h2 class="text-lg sa700 leading-[18px] text-gray-800">Item Edit  </h2>--%>
                                                                    <%--       <div class="row">
                                                                    <div class="col-md-6">
                                                                        <asp:Button ID="BtnInvPrev" runat="server" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" OnClick="BtnInvPrev_Click" Text="Prev" /></div>
                                                                    <div class="col-md-6">
                                                                        <asp:Button ID="BtnInvNext" runat="server" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" OnClick="BtnInvNext_Click" Text="Next" />
                                                                    </div>
                                                                </div>--%>





                                                                    <br />
                                                                    <div class="form-group row">
                                                                        <div class="col-sm-5">
                                                                            <asp:Button ID="btnprev" Enabled="false" Width="50px" runat="server" CssClass=" previousduration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" OnClick="btnprev_Click" Text="Prev" />
                                                                        </div>
                                                                        <div class="col-sm-2">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" runat="server" ID="itemno" Font-Bold="true" Width="100px" Enabled="false"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-sm-5">


                                                                            <asp:Button ID="btnnxt" Enabled="false" Width="50px" runat="server" CssClass=" previous duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" OnClick="btnnxt_Click" Text="Next" />
                                                                        </div>
                                                                    </div>




                                                                    <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-6">
                                                                        <span class="text-white text-sm font-semibold tracking-wide">Item Value

                                                                        </span>

                                                                    </div>

                                                                </div>
                                                                <div class="w-full mt-2">
                                                                    <!-- Label and Dropdown aligned -->
                                                                    <div class="flex items-center gap-2 mb-1">
                                                                        <label class="text-gray-500 text-sm font-medium whitespace-nowrap w-[100px]">Invoice</label>
                                                                        <asp:DropDownList
                                                                            CssClass="focus:outline-none bg-slate-100 font-normal rounded-md text-xs text-slate-400 px-4 h-10 w-full max-w-[250px]"
                                                                            runat="server"
                                                                            ID="DrpInvoiceNo"
                                                                            OnSelectedIndexChanged="DrpInvoiceNo_SelectedIndexChanged"
                                                                            AutoPostBack="true"
                                                                            TabIndex="128">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>


                                                                <div class="w-full mt-2">
                                                                    <label class="text-gray-500 text-sm font-medium block mb-1">
                                                                        CURR (UNIT PRICE 
                                                                <asp:CheckBox ID="ChkUnitPrice" CausesValidation="true" OnCheckedChanged="ChkUnitPrice_CheckedChanged" AutoPostBack="true" runat="server" />
                                                                        AUTO)
                                                                    </label>

                                                                    <!-- Dropdown Row -->
                                                                    <div class="flex items-center gap-2 mb-2">
                                                                        <label class="text-gray-500 text-sm font-medium w-[100px]">Currency</label>
                                                                        <asp:DropDownList
                                                                            ID="DRPCurrency"
                                                                            CausesValidation="true"
                                                                            OnSelectedIndexChanged="DRPCurrency_SelectedIndexChanged"
                                                                            TabIndex="129"
                                                                            AutoPostBack="true"
                                                                            runat="server"
                                                                            CssClass="drop font-normal rounded-md text-xs text-slate-400 px-4 h-10 w-full max-w-[200px] bg-slate-100 focus:outline-none border-none">
                                                                        </asp:DropDownList>
                                                                    </div>

                                                                    <!-- Textbox Row -->
                                                                    <div class="flex items-center gap-2">
                                                                        <label class="text-gray-500 text-sm font-medium w-[100px]">Ex. Rate</label>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)"
                                                                            autocomplete="off"
                                                                            ID="TxtExchangeRate"
                                                                            Enabled="false"
                                                                            TabIndex="130"
                                                                            Text="0.00"
                                                                            runat="server"
                                                                            CssClass="w-full max-w-[200px] h-10 bg-slate-100 rounded-md text-end text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                        </asp:TextBox>
                                                                    </div>

                                                                    <!-- Validators -->
                                                                    <asp:RequiredFieldValidator
                                                                        ID="RequiredFieldValidator13"
                                                                        runat="server"
                                                                        ControlToValidate="DRPCurrency"
                                                                        InitialValue="0"
                                                                        Font-Size="XX-Small"
                                                                        ForeColor="Red"
                                                                        ErrorMessage="Item --> Please Enter Invoice Currency"
                                                                        ValidationGroup="Item">
                                                                    </asp:RequiredFieldValidator>

                                                                    <asp:RequiredFieldValidator
                                                                        ID="RequiredFieldValidator14"
                                                                        runat="server"
                                                                        ControlToValidate="TxtExchangeRate"
                                                                        Font-Size="XX-Small"
                                                                        ForeColor="Red"
                                                                        ErrorMessage="Item --> Please Enter Invoice Currency EX Rate"
                                                                        ValidationGroup="Item">
                                                                    </asp:RequiredFieldValidator>
                                                                </div>

                                                                <div id="extrsItemDiv" runat="server" visible="false" class="">
                                                                    <div class="form-group row align-items-center">
                                                                        <!-- Label -->
                                                                        <label for="TxtUnitPrice" class="col-sm-3 col-form-label text-gray-500 text-sm font-medium">
                                                                            Unit Price Val
                                                                        </label>

                                                                        <!-- Inputs -->
                                                                        <div class="col-sm-7">
                                                                            <div class="d-flex gap-2">
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)"
                                                                                    autocomplete="off"
                                                                                    runat="server"
                                                                                    Text="0.00"
                                                                                    ID="TxtUnitPrice"
                                                                                    OnTextChanged="TxtUnitPrice_TextChanged"
                                                                                    AutoPostBack="true"
                                                                                    CssClass="form-control w-[115px] h-10 bg-slate-100 text-slate-950 text-sm font-medium border rounded-md px-2"
                                                                                    TabIndex="104">
                                                                                </asp:TextBox>

                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)"
                                                                                    autocomplete="off"
                                                                                    runat="server"
                                                                                    Text="0.00"
                                                                                    ID="TxtSumExRate"
                                                                                    Visible="false"
                                                                                    CssClass="form-control w-[115px] h-10 bg-slate-100 text-slate-950 text-sm font-medium border rounded-md px-2"
                                                                                    TabIndex="106">
                                                                                </asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="w-full">
                                                                    <div class="flex">
                                                                        <!-- Label on Left -->
                                                                        <label class="text-gray-500 text-sm font-medium md:w-[200px] w-full mt-3">
                                                                            Total Line Amount
                                                                        </label>

                                                                        <!-- Input and Validators -->
                                                                        <div class="w-full">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Type Amount"
                                                                                CssClass="w-full h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium outline-none border-none px-4"
                                                                                autocomplete="off" onfocus="removeCommas(this)" onkeypress="return isNumberKey(event)"
                                                                                OnBlur="addCommas(this)" CausesValidation="true" OnTextChanged="TxtTotalLineAmount_TextChanged"
                                                                                ValidationGroup="Item" Text="0.00" AutoPostBack="true" runat="server" type="text"
                                                                                ID="TxtTotalLineAmount" TabIndex="134">
                                                                            </asp:TextBox>

                                                                            <!-- Validators -->
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server"
                                                                                InitialValue="0.00" ControlToValidate="TxtTotalLineAmount" Font-Size="XX-Small"
                                                                                ForeColor="Red" ErrorMessage="Item --> Please Enter Total Line Amount" ValidationGroup="Item">
                                                                            </asp:RequiredFieldValidator>

                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow"
                                                                                ControlToValidate="TxtTotalLineAmount" ID="RegularExpressionValidator72"
                                                                                ValidationExpression="^[0-9\s\.\,]+$" runat="server"
                                                                                ErrorMessage="Not Accepted Special Charector" ValidationGroup="Item">
                                                                            </asp:RegularExpressionValidator>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <!-- Total Invoice Charged (SGD) -->
                                                                <div class="w-full mt-2">
                                                                    <div class="flex flex-col md:flex-row items-start md:items-center gap-2">
                                                                        <label class="text-gray-500 text-sm font-medium md:w-[200px] w-full mt-1">
                                                                            Total Invoice Charged (SGD)
                                                                        </label>
                                                                        <div class="w-full">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Type Amount" autocomplete="off" runat="server" Enabled="false"
                                                                                type="text" onfocus="removeCommas(this)" OnBlur="addCommas(this)"
                                                                                ID="TxtTotalLineCharges" Text="0.00" TabIndex="135"
                                                                                CssClass="w-full h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                            </asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <!-- CIF/FOB -->
                                                                <div class="w-full mt-2">
                                                                    <div class="flex flex-col md:flex-row items-start md:items-center gap-2">
                                                                        <label class="text-gray-500 text-sm font-medium md:w-[200px] w-full mt-1">
                                                                            CIF/FOB
                                                                        </label>
                                                                        <div class="w-full">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Type Amount" autocomplete="off" runat="server" Enabled="false"
                                                                                type="text" onfocus="removeCommas(this)" OnBlur="addCommas(this)" ID="TxtCIFFOB"
                                                                                Text="0.00" TabIndex="135"
                                                                                CssClass="w-full h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                            </asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <!-- Last Selling Price (SGD) -->
                                                                <div class="w-full mt-2">
                                                                    <div class="flex flex-col md:flex-row items-start md:items-center gap-2">
                                                                        <label class="text-gray-500 text-sm font-medium md:w-[220px] w-full mt-1">
                                                                            Last Selling Price (SGD)
                                                                        </label>
                                                                        <div class="w-full">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Type Amount" autocomplete="off" runat="server"
                                                                                onkeypress="return isNumberKey(event)" type="text" Width="218"
                                                                                ID="txtlsp" Text="0.00" MaxLength="16" OnTextChanged="txtlsp_TextChanged"
                                                                                AutoPostBack="true" TabIndex="136"
                                                                                CssClass="w-full h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                            </asp:TextBox>
                                                                            <asp:Label Font-Size="9" Text="Last selling Price (SGD)" ID="lblsp" Visible="false" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div id="OptionalCharges" runat="server">
                                                                    <div class="form-group row">
                                                                        <label for="staticEmail" class="col-sm-3 col-form-label text-gray-500 text-sm font-medium whitespace-nowrap">
                                                                            Optional<br />
                                                                            Charges
                                                                        </label>
                                                                        <div class="col-sm-9">
                                                                            <asp:DropDownList CssClass="drop font-normal rounded-md text-xs text-slate-400 px-4 h-10 w-[125px] focus:outline-none" ID="DrpOptionalUom" BackColor="#e8f0fe" CausesValidation="true" OnSelectedIndexChanged="DrpOptionalUom_SelectedIndexChanged" TabIndex="131" AutoPostBack="true" runat="server" Width="115"></asp:DropDownList>

                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-[125px] h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" Width="115" Text="0.00" ID="TxtOptionalPrice" OnTextChanged="TxtOptionalPrice_TextChanged" AutoPostBack="true" TabIndex="132"></asp:TextBox>

                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group row">
                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                        </label>
                                                                        <div class="col-sm-9">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-[125px] h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" ID="TxtOptionalExchageRate" Enabled="false" TabIndex="133" Text="0.00" runat="server" Width="115"></asp:TextBox>

                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-[125px] h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" type="text" ID="TxtOptionalSumExRate" TabIndex="134" Width="115" Text="0.00"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>



                                                            </div>

                                                        </div>




                                                        <div class="mt-6 md:max-w-[835px] w-full">

                                                            <div class="mt-2">
                                                                <div class="flex items-start gap-4 flex-wrap">
                                                                </div>
                                                            </div>
                                                        </div>



                                                        <div class="mt-6 w-full" style="display: none;">





                                                            <h2 class="text-lg sa700 leading-[18px] text-gray-800">Item Value
                                                            </h2>
                                                            <div class="mt-2">
                                                                <div class="flex items-start gap-4 flex-wrap">

                                                                    <!--  -->
                                                                    <div class="w-full mb-3">
                                                                        <div class="text-gray-500 text-sm font-medium opacity-0">Invoice</div>
                                                                        <div class="flex gap-2 items-center mt-1">
                                                                            <input class="styled-checkbox-1" id="styled-checkbox-95" type="checkbox" value="value1" checked="">
                                                                            <label for="styled-checkbox-95" class="text-gray-500 text-sm">Unbranded</label>
                                                                        </div>
                                                                    </div>
                                                                    <div>
                                                                        <label class="text-gray-500 text-sm font-medium">Unit Price</label>
                                                                        <div class="flex bg-slate-100 rounded-md md:w-[250px] w-full mt-1 h-10">
                                                                            <div class="md:w-[125px] w-full">
                                                                                <div class="relative w-full">
                                                                                    <input placeholder="2" type="text" name="" id="" class="w-full h-10 bg-slate-100 rounded-l-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                                </div>
                                                                            </div>
                                                                            <svg class="mt-3" width="1" height="16" viewBox="0 0 1 16" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                                <line x1="0.5" y1="2.18561e-08" x2="0.499999" y2="16" stroke="#BCBCC4"></line>
                                                                            </svg>
                                                                            <div class="md:w-[125px] w-full">
                                                                                <div class="relative w-full">
                                                                                    <input placeholder="2" type="text" name="" id="" class="w-full h-10 bg-slate-100 rounded-r-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>







                                                        <%--  <div class="flex justify-between gap-2 items-center mt-7">
                                                            <h2 class="text-lg sa700 leading-[18px] text-gray-800">Item Price
                                                            </h2>
                                                        </div>--%>

                                                        <div class="flex gap-4 lg:flex-nowrap flex-wrap">
                                                            <div class="mt-2 flex items-start gap-4 flex-wrap mb-2 w-full">
                                                            </div>
                                                            <!--  -->
                                                        </div>



                                                        <!--  -->
                                                        <%-- <div id="PackingInfo" visible="false" runat="server">--%>
                                                        <div id="PackingInfo1">
                                                            <div class="mt-6">
                                                                <div class="flex justify-between gap-2 items-center">
                                                                    <h2 class="text-lg sa700 leading-[18px] text-gray-800">PACKING INFORMATION
                                                                    </h2>
                                                                    <div
                                                                        onclick="drop_draft();"
                                                                        class="bg-[#0560FD] bg-opacity-5 w-7 h-7 flex justify-center items-center rounded-full">
                                                                        <svg
                                                                            id="drop_draft_Svg"
                                                                            width="20"
                                                                            height="20"
                                                                            viewBox="0 0 20 20"
                                                                            fill="none"
                                                                            xmlns="http://www.w3.org/2000/svg">
                                                                            <path
                                                                                d="M5 9.58301L9.43692 5.51584C9.70425 5.27076 9.83792 5.14826 10 5.14826C10.1621 5.14826 10.2958 5.27076 10.5631 5.51584L15 9.58301"
                                                                                stroke="#0560FD"
                                                                                stroke-width="1.5"
                                                                                stroke-linecap="round"
                                                                                stroke-linejoin="round" />
                                                                            <path
                                                                                d="M5 15L9.43692 10.9328C9.70425 10.6877 9.83792 10.5652 10 10.5652C10.1621 10.5652 10.2958 10.6877 10.5631 10.9328L15 15"
                                                                                stroke="#0560FD"
                                                                                stroke-width="1.5"
                                                                                stroke-linecap="round"
                                                                                stroke-linejoin="round" />
                                                                        </svg>
                                                                    </div>
                                                                </div>
                                                                <!--  -->
                                                                <!--  -->
                                                                <div
                                                                    aria-label="Main"
                                                                    id="drop_draft_area"
                                                                    class="duration-300 ease-in-out transition-all ">
                                                                    <div
                                                                        class="mt-2 flex justify-between items-center gap-4 lg:flex-nowrap flex-wrap">
                                                                        <div class="w-full">
                                                                            <div class="group relative">
                                                                                <div class="text-gray-500 text-sm font-medium">
                                                                                    Outer Pack Quantity
                                                                                </div>
                                                                                <div class="flex bg-slate-100 rounded-md md:w-[250px] w-full h-10 mt-2">
                                                                                    <div class="md:w-[125px] w-full">
                                                                                        <div class="relative w-full">
                                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" Text="0" MaxLength="8" type="text" onkeypress="return isNumberKey(event)" ValidationGroup="Item" ID="TxtOPQty" AutoPostBack="true" OnTextChanged="TxtOPQty_TextChanged" TabIndex="138"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                    <svg class="mt-3" width="1" height="16" viewBox="0 0 1 16" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                                        <line x1="0.5" y1="2.18561e-08" x2="0.499999" y2="16" stroke="#BCBCC4"></line>
                                                                                    </svg>
                                                                                    <div class="md:w-[125px] w-full">
                                                                                        <div class="group relative">
                                                                                            <asp:DropDownList CssClass="drop font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt- px-4 focus:outline-none" ID="DRPOPQUOM" runat="server" TabIndex="139"></asp:DropDownList>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtOPQty" ID="RegularExpressionValidator64" ValidationExpression="^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 8 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                        <div class="w-full">
                                                                            <div class="group relative">
                                                                                <div class="text-gray-500 text-sm font-medium">
                                                                                    In Pack Quantity
                                                                                </div>

                                                                                <div class="flex bg-slate-100 rounded-md md:w-[250px] w-full h-10 mt-2">
                                                                                    <div class="md:w-[125px] w-full">
                                                                                        <div class="relative w-full">
                                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" Text="0" MaxLength="8" type="text" onkeypress="return isNumberKey(event)" OnTextChanged="TxtIPQty_TextChanged" AutoPostBack="true" ValidationGroup="Item" ID="TxtIPQty" TabIndex="140"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                    <svg class="mt-3" width="1" height="16" viewBox="0 0 1 16" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                                        <line x1="0.5" y1="2.18561e-08" x2="0.499999" y2="16" stroke="#BCBCC4"></line>
                                                                                    </svg>
                                                                                    <div class="md:w-[125px] w-full">
                                                                                        <div class="group relative">
                                                                                            <asp:DropDownList CssClass="drop font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt- px-4 focus:outline-none" ID="DRPIPQUOM" runat="server" TabIndex="141"></asp:DropDownList>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtIPQty" ID="RegularExpressionValidator63" ValidationExpression="^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 8 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                        <div class="w-full">
                                                                            <div class="group relative">
                                                                                <div class="text-gray-500 text-sm font-medium">
                                                                                    Inner Pack Quantity
                                                                                </div>
                                                                                <div class="flex bg-slate-100 rounded-md md:w-[250px] w-full h-10 mt-2">
                                                                                    <div class="md:w-[125px] w-full">
                                                                                        <div class="relative w-full">
                                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" Text="0" type="text" onkeypress="return isNumberKey(event)" MaxLength="8" ValidationGroup="Item" ID="TxtINPQty" OnTextChanged="TxtINPQty_TextChanged" AutoPostBack="true" TabIndex="142"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                    <svg class="mt-3" width="1" height="16" viewBox="0 0 1 16" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                                        <line x1="0.5" y1="2.18561e-08" x2="0.499999" y2="16" stroke="#BCBCC4"></line>
                                                                                    </svg>
                                                                                    <div class="md:w-[125px] w-full">
                                                                                        <div class="group relative">
                                                                                            <asp:DropDownList CssClass="drop font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt- px-4 focus:outline-none" ID="DRPINNPQUOM" runat="server" TabIndex="143"></asp:DropDownList>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtINPQty" ID="RegularExpressionValidator65" ValidationExpression="^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 8 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                        </div>


                                                                        <div class="w-full">
                                                                            <div class="group relative">
                                                                                <div class="text-gray-500 text-sm font-medium">
                                                                                    Inmost Pack Quantity
                                                                                </div>

                                                                                <div class="flex bg-slate-100 rounded-md md:w-[250px] w-full h-10 mt-2">
                                                                                    <div class="md:w-[125px] w-full">
                                                                                        <div class="relative w-full">
                                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" Text="0" type="text" onkeypress="return isNumberKey(event)" MaxLength="8" OnTextChanged="TxtIMPQty_TextChanged" AutoPostBack="true" ValidationGroup="Item" ID="TxtIMPQty" TabIndex="144"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                    <svg class="mt-3" width="1" height="16" viewBox="0 0 1 16" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                                        <line x1="0.5" y1="2.18561e-08" x2="0.499999" y2="16" stroke="#BCBCC4"></line>
                                                                                    </svg>
                                                                                    <div class="md:w-[125px] w-full">
                                                                                        <div class="group relative">
                                                                                            <asp:DropDownList CssClass="drop font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt- px-4 focus:outline-none" ID="DRPIMPQUOM" runat="server" TabIndex="145"></asp:DropDownList>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>


                                                                            </div>
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtIMPQty" ID="RegularExpressionValidator66" ValidationExpression="^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 8 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                        </div>

                                                                    </div>
                                                                    <!--  -->
                                                                </div>
                                                            </div>
                                                            <!--  -->
                                                        </div>



                                                        <div class="mt-6">
                                                            <div class="flex justify-between gap-2 items-center">
                                                                <h2 class="text-lg sa700 leading-[18px] text-gray-800">Lot Identification
                                                                </h2>
                                                                <div onclick="drop_draft_1();" class="bg-[#0560FD] bg-opacity-5 w-7 h-7 flex justify-center items-center rounded-full">
                                                                    <svg id="drop_draft_1_Svg" width="20" height="20" viewBox="0 0 20 20" fill="none" xmlns="http://www.w3.org/2000/svg" class="">
                                                                        <path d="M5 9.58301L9.43692 5.51584C9.70425 5.27076 9.83792 5.14826 10 5.14826C10.1621 5.14826 10.2958 5.27076 10.5631 5.51584L15 9.58301" stroke="#0560FD" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                                                        <path d="M5 15L9.43692 10.9328C9.70425 10.6877 9.83792 10.5652 10 10.5652C10.1621 10.5652 10.2958 10.6877 10.5631 10.9328L15 15" stroke="#0560FD" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                                                    </svg>
                                                                </div>
                                                            </div>
                                                            <!--  -->
                                                            <!--  -->
                                                            <%-- <div aria-label="Main" id="drop_draft_1_area" class="duration-300 ease-in-out transition-all hidden">--%>
                                                            <div aria-label="Main" id="drop_draft_1_area" class="duration-300 ease-in-out transition-all hidden">
                                                                <div class="mt-2 flex items-center gap-4 lg:flex-nowrap flex-wrap">
                                                                    <div class="w-full">
                                                                        <label class="text-gray-500 text-sm font-medium">Current Lot</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Type Quantity" autocomplete="off" runat="server" type="text" ID="TxtCurrentLot" MaxLength="30" TabIndex="167" ValidationGroup="Item" class="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" Style="text-transform: uppercase"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtCurrentLot" ID="RegularExpressionValidator17" ValidationExpression="^[\s\S]{0,30}$" runat="server" ErrorMessage="Maximum 30 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                    </div>
                                                                    <div class="w-full">
                                                                        <label class="text-gray-500 text-sm font-medium">Previous Lot</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ValidationGroup="Item" ID="TxtPreviousLot" MaxLength="30" TabIndex="169" class="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" Style="text-transform: uppercase"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator placeholder="Type Quantity" Display="Dynamic" BackColor="yellow" ControlToValidate="TxtPreviousLot" ID="RegularExpressionValidator10" ValidationExpression="^[\s\S]{0,30}$" runat="server" ErrorMessage="Maximum 30 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                    </div>
                                                                    <div class="w-full">
                                                                        <div class="group relative">
                                                                            <div class="text-gray-500 text-sm font-medium">Marking</div>
                                                                            <asp:DropDownList CssClass="focus:outline-none bg-slate-100 font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt-1 px-4" runat="server" TabIndex="168" ID="DrpMaking"></asp:DropDownList>
                                                                        </div>
                                                                    </div>

                                                                </div>
                                                                <!--  -->
                                                            </div>
                                                        </div>



                                                        <div class="mt-6">
                                                            <div class="flex justify-between gap-2 items-center">
                                                                <h2 class="text-lg sa700 leading-[18px] text-gray-800">Tariff
                                                                </h2>
                                                                <div onclick="drop_draft_2();" class="bg-[#0560FD] bg-opacity-5 w-7 h-7 flex justify-center items-center rounded-full">
                                                                    <svg id="drop_draft_2_Svg" width="20" height="20" viewBox="0 0 20 20" fill="none" xmlns="http://www.w3.org/2000/svg" class="">
                                                                        <path d="M5 9.58301L9.43692 5.51584C9.70425 5.27076 9.83792 5.14826 10 5.14826C10.1621 5.14826 10.2958 5.27076 10.5631 5.51584L15 9.58301" stroke="#0560FD" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                                                        <path d="M5 15L9.43692 10.9328C9.70425 10.6877 9.83792 10.5652 10 10.5652C10.1621 10.5652 10.2958 10.6877 10.5631 10.9328L15 15" stroke="#0560FD" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                                                    </svg>
                                                                </div>
                                                            </div>
                                                            <!--  -->
                                                            <!--  -->
                                                            <div aria-label="Main" id="drop_draft_2_area" class="duration-300 ease-in-out transition-all ">
                                                                <div class="mt-2 flex items-center gap-4 lg:flex-nowrap flex-wrap">
                                                                    <div class="w-full">
                                                                        <div class="group relative">
                                                                            <div class="text-gray-500 text-sm font-medium">Preferential Code</div>

                                                                            <asp:DropDownList CssClass="focus:outline-none bg-slate-100 font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt-1 px-4" ID="DrpPreferentialCode" TabIndex="154" OnSelectedIndexChanged="DrpPreferentialCode_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>

                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <!-- Table -->
                                                                <div class="overflow-auto my-shadow whitespace-nowrap border border-gray-100 rounded-tl-lg rounded-tr-lg rounded-bl-lg rounded-br-lg mt-4">






                                                                    <table class="w-full bg-white rounded whitespace-nowrap">
                                                                        <thead>
                                                                            <tr class="w-full h-10 py-4 px-10 bg-[#F4F6FA]">
                                                                                <th class="md:w-[300px] text-[13px] font-medium leading-none text-gray-500 text-left rounded-tl-lg pl-8">Items
                                                                                </th>
                                                                                <th class="text-[13px] font-medium leading-none text-gray-500 px-10 text-left">Rate
                                                                                </th>
                                                                                <th class="text-[13px] font-medium leading-none text-gray-500 text-left px-10">UOM
                                                                                </th>
                                                                                <th class="text-[13px] font-medium leading-none text-gray-500 px-2 text-left">Amounts
                                                                                </th>
                                                                            </tr>
                                                                        </thead>
                                                                        <tbody>
                                                                            <tr class="my-0 h-[70px]">
                                                                                <td class="pr-2">
                                                                                    <div class="h-8 px-3 rounded-md flex items-center text-slate-500 pb-2 text-[13px] font-medium pl-8">
                                                                                        GST (
                                                                        <div class="flex gap-2 items-center ml-1">
                                                                            <asp:CheckBox ID="chk234" TabIndex="155" runat="server" AutoPostBack="true" OnCheckedChanged="chk234_CheckedChanged" />
                                                                        </div>
                                                                                        Auto-Compute Duties &amp; Taxes)
                                                                                    </div>
                                                                                </td>

                                                                                <td class="md:px-10 px-4">
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full px-3 h-8 bg-slate-100 rounded-md flex items-center disabled:text-slate-300 text-slate-950 focus:outline-none text-[13px] font-medium" autocomplete="off" onkeypress="return isNumberKey(event)" ID="ItemGSTRate" runat="server" Enabled="false" TabIndex="156" Text="9"></asp:TextBox>
                                                                                </td>
                                                                                <td class="md:px-10 px-4">
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full px-3 h-8 bg-slate-100 rounded-md flex items-center disabled:text-slate-300 text-slate-950 focus:outline-none text-[13px] font-medium" autocomplete="off" ID="ItemGSTUOM" runat="server" Enabled="false" TabIndex="157" Text="PER"></asp:TextBox>
                                                                                </td>
                                                                                <td class="md:pr-0 pr-3">
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full px-3 h-8 bg-slate-100 rounded-md flex items-center disabled:text-slate-300 text-slate-950 focus:outline-none text-[13px] font-medium" autocomplete="off" onkeypress="return isNumberKey(event)" ID="TxtItemSumGST" runat="server" Enabled="false" TabIndex="158" Text="0.00"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="my-0">
                                                                                <td class="pr-2">
                                                                                    <div class="h-8 px-3 rounded-md flex items-center text-slate-500 pb-2 text-[13px] font-medium pl-8">
                                                                                        Excise Duty
                                                                                    </div>
                                                                                </td>

                                                                                <td class="md:px-10 px-4">
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full px-3 h-8 bg-slate-100 rounded-md flex items-center disabled:text-slate-300 text-slate-950 focus:outline-none text-[13px] font-medium" autocomplete="off" onkeypress="return isNumberKey(event)" ID="TxtExciseDutyRate" Enabled="false" runat="server" TabIndex="159" Text="0.00"></asp:TextBox>
                                                                                </td>
                                                                                <td class="md:px-10 px-4">
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full px-3 h-8 bg-slate-100 rounded-md flex items-center disabled:text-slate-300 text-slate-950 focus:outline-none text-[13px] font-medium" autocomplete="off" ID="TxtExciseDutyUOM" Enabled="false" runat="server" TabIndex="157" Text="0.00"></asp:TextBox>
                                                                                </td>
                                                                                <td class="md:pr-0 pr-3">
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full px-3 h-8 bg-slate-100 rounded-md flex items-center disabled:text-slate-300 text-slate-950 focus:outline-none text-[13px] font-medium" autocomplete="off" onkeypress="return isNumberKey(event)" ID="TxtSumExciseDuty" Enabled="false" runat="server" TabIndex="160" Text="0.00"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="my-0">
                                                                                <td class="pr-2">
                                                                                    <asp:Label ID="lblCustomsDuty" Text="Customs Duty" CssClass="h-8 px-3 rounded-md flex items-center text-slate-500 pb-2 text-[13px] font-medium pl-8" runat="server"></asp:Label>
                                                                                </td>
                                                                                <td class="md:px-10 px-4 py-3">
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full px-3 h-8 bg-slate-100 rounded-md flex items-center disabled:text-slate-300 text-slate-950 focus:outline-none text-[13px] font-medium" autocomplete="off" MaxLength="8" onkeypress="return isNumberKey(event)" ID="TxtCustomsDutyRate" Enabled="false" runat="server" TabIndex="161" Text="0.00"></asp:TextBox>
                                                                                </td>
                                                                                <td class="md:px-10 px-4 py-3">
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full px-3 h-8 bg-slate-100 rounded-md flex items-center disabled:text-slate-300 text-slate-950 focus:outline-none text-[13px] font-medium" autocomplete="off" ID="TxtCustomsDutyUOM" Enabled="false" runat="server" TabIndex="160" Text="0.00"></asp:TextBox>
                                                                                </td>
                                                                                <td class="md:pr-0 pr-3">
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full px-3 h-8 bg-slate-100 rounded-md flex items-center disabled:text-slate-300 text-slate-950 focus:outline-none text-[13px] font-medium" autocomplete="off" onkeypress="return isNumberKey(event)" ID="TxtSumCustomsDuty" Enabled="false" runat="server" TabIndex="162" Text="0.00"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="my-0">
                                                                                <td class="pr-2">
                                                                                    <div class="h-8 px-3 rounded-md flex items-center text-slate-500 pb-2 text-[13px] font-medium pl-8">
                                                                                        Other Tax
                                                                                    </div>
                                                                                </td>
                                                                                <td class="md:px-10 px-4 pb-2">
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="focus:outline-none w-full px-3 h-8 bg-slate-100 rounded-md flex items-center disabled:text-slate-300 text-slate-950 focus:outline-none text-[13px] font-medium" autocomplete="off" onkeypress="return isNumberKey(event)" ID="TxtOtherTaxRate" runat="server" TabIndex="163" Text="0.00"></asp:TextBox>
                                                                                </td>
                                                                                <td class="md:px-10 px-4 pb-2">
                                                                                    <asp:DropDownList CssClass="focus:outline-none w-full px-3 h-8 bg-slate-100 rounded-md flex items-center disabled:text-slate-300 text-slate-950 focus:outline-none text-[13px] font-medium" ID="DrpOtherUOM" runat="server" TabIndex="164"></asp:DropDownList>
                                                                                </td>
                                                                                <td class="md:pr-0 pr-3 pb-2">
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="focus:outline-none w-full px-3 h-8 bg-slate-100 rounded-md flex items-center disabled:text-slate-300 text-slate-950 focus:outline-none text-[13px] font-medium" autocomplete="off" onkeypress="return isNumberKey(event)" ID="TxtSumOtherTaxRate" runat="server" TabIndex="165" Text="0.00"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </div>
                                                                <!-- Table -->
                                                                <!--  -->
                                                            </div>
                                                        </div>




                                                        <div class="mt-6">
                                                            <div class="flex justify-between gap-2 items-center">
                                                                <h2 class="text-lg sa700 leading-[18px] text-gray-800">Item CASC - Basic CASC Identification
                                                                </h2>
                                                                <div onclick="drop_draft_3();" class="bg-[#0560FD] bg-opacity-5 w-7 h-7 flex justify-center items-center rounded-full">
                                                                    <svg id="drop_draft_3_Svg" width="20" height="20" viewBox="0 0 20 20" fill="none" xmlns="http://www.w3.org/2000/svg" class="">
                                                                        <path d="M5 9.58301L9.43692 5.51584C9.70425 5.27076 9.83792 5.14826 10 5.14826C10.1621 5.14826 10.2958 5.27076 10.5631 5.51584L15 9.58301" stroke="#0560FD" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                                                        <path d="M5 15L9.43692 10.9328C9.70425 10.6877 9.83792 10.5652 10 10.5652C10.1621 10.5652 10.2958 10.6877 10.5631 10.9328L15 15" stroke="#0560FD" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                                                    </svg>
                                                                </div>
                                                            </div>
                                                            <!--  -->
                                                            <!--  -->
                                                            <div aria-label="Main" id="drop_draft_3_area" class="duration-300 ease-in-out transition-all ">


                                                                <%--<div id="ItemCASC" visible="false" runat="server">--%>
                                                                <div id="ItemCASC1" class="panels-table">

                                                                    <div class="panel mb-0">

                                                                        <div class="mt-[15px]">
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

                                                                                        <div class="">
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



                                                                                            <div class="row">
                                                                                                <div class="col-sm-3">
                                                                                                    <asp:Button ID="Button4" runat="server" Text="Copy Of HS-Quantity" OnClick="Button2_Click" Visible="true" />
                                                                                                    <p><%--<i class='fa fa-search' data-toggle="modal" data-target="#Product2"></i>--%></p>
                                                                                                    <cc1:ModalPopupExtender ID="popupinnondec" runat="server" PopupControlID="pnlpc1" TargetControlID="btnpc1"
                                                                                                        OkControlID="btnpcYes" CancelControlID="btnpcNo" BackgroundCssClass="modalBackground">
                                                                                                    </cc1:ModalPopupExtender>
                                                                                                    <asp:Panel ID="pnlpc1" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                                                                        <div class="header">

                                                                                                            <%--   <svg class="cursor-pointer absolute right-5 top-5" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                                                                <circle opacity="0.1" cx="12" cy="12" r="12" fill="#676D7C"></circle>
                                                                                                                <path d="M16.6663 7.3335L7.33301 16.6668M7.33301 7.3335L16.6663 16.6668" stroke="#676D7C" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                                                                                            </svg>--%>
                                                                                                            <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Product Code 1</p>


                                                                                                        </div>
                                                                                                        <div class="body">
                                                                                                            <asp:UpdatePanel ID="upinnonpc1" runat="server" UpdateMode="Conditional">
                                                                                                                <ContentTemplate>
                                                                                                                    <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                                                        <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ProductCode1Search" OnTextChanged="ProductCode1Search_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                                                                    </div>
                                                                                                                    <br />

                                                                                                                    No of Rows:
                                                                                                                                                             <asp:DropDownList ID="dropdownlist5" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropdownlist5_SelectedIndexChanged">
                                                                                                                                                                 <asp:ListItem>10</asp:ListItem>

                                                                                                                                                                 <asp:ListItem>20</asp:ListItem>

                                                                                                                                                                 <asp:ListItem>30</asp:ListItem>

                                                                                                                                                                 <asp:ListItem>All</asp:ListItem>

                                                                                                                                                             </asp:DropDownList>
                                                                                                                    <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
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

                                                                                                                                <asp:TemplateField Visible="false">
                                                                                                                                    <ItemTemplate>
                                                                                                                                        <asp:LinkButton ID="lnkProductCode1" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="lnkProductCode1_Command" CssClass="duration-300 ease-in-out md:max-w-[200px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700">Select </asp:LinkButton>
                                                                                                                                    </ItemTemplate>
                                                                                                                                </asp:TemplateField>
                                                                                                                            </Columns>
                                                                                                                        </asp:GridView>
                                                                                                                    </div>

                                                                                                                </ContentTemplate>

                                                                                                            </asp:UpdatePanel>
                                                                                                        </div>

                                                                                                        <div class="footer" align="right">
                                                                                                            <asp:Button ID="btnpcYes" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                                                            <asp:Button ID="btnpcNo" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px] mt-4 w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                                                        </div>
                                                                                                    </asp:Panel>


                                                                                                    <div class="relative mt-1">
                                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Product Code" CssClass="w-full h-11 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" type="text" ValidationGroup="Productcode" ID="TxtProductCode1" MaxLength="17" OnTextChanged="TxtProductCode1_TextChanged" AutoPostBack="true" TabIndex="147"></asp:TextBox>


                                                                                                        <asp:Button ID="btnpc1" TabIndex="22" runat="server" CssClass="absolute right-4 top-3 btn-search-circle-img w-[22px] h-[22px]" Style="background-image: url('./images/circel-search.svg');" />
                                                                                                        <%--<img src="" alt="Search" >--%>
                                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProductCode1" ID="RegularExpressionValidator39" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>
                                                                                                    </div>
                                                                                                    <div class="flex bg-slate-100 rounded-md md:w-[230px] w-full h-10 mt-2">
                                                                                                        <div class="md:w-[125px] w-full">
                                                                                                            <div class="relative w-full">
                                                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Type Quantity" autocomplete="off" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server" type="text" ID="TxtProQty1" MaxLength="16" ValidationGroup="Productcode" TabIndex="148" Text="0.00"></asp:TextBox>
                                                                                                            </div>
                                                                                                        </div>
                                                                                                        <svg class="mt-3" width="1" height="16" viewBox="0 0 1 16" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                                                            <line x1="0.5" y1="2.18561e-08" x2="0.499999" y2="16" stroke="#BCBCC4"></line>
                                                                                                        </svg>
                                                                                                        <div class="md:w-[125px] w-full">
                                                                                                            <div class="group relative">
                                                                                                                <asp:DropDownList CssClass="drop font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt- px-4 focus:outline-none" ID="DrpP1" runat="server" TabIndex="149"></asp:DropDownList>
                                                                                                            </div>
                                                                                                        </div>
                                                                                                    </div>


                                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProQty1" ID="RegularExpressionValidator44" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7a" runat="server" ControlToValidate="TxtHSCodeItem" Font-Size="XX-Small" ForeColor="Red" ErrorMessage="Item --> Please Enter HS Code" ValidationGroup="Item"></asp:RequiredFieldValidator>

                                                                                                </div>
                                                                                                <div class="col-sm-9">

                                                                                                    <asp:GridView CssClass="table table-striped table-bordered table-hover" ID="ProductCode1Grid1" runat="server" ShowFooter="true" AutoGenerateColumns="false">
                                                                                                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                        <Columns>

                                                                                                            <asp:BoundField DataField="Product Code    " HeaderText="Seq." Visible="false" />

                                                                                                            <asp:TemplateField HeaderText="CASC CODE 1">

                                                                                                                <ItemTemplate>

                                                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox1" MaxLength="35" CssClass="w-full h-11 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="150" runat="server" Style="text-transform: uppercase"></asp:TextBox>

                                                                                                                </ItemTemplate>

                                                                                                            </asp:TemplateField>

                                                                                                            <asp:TemplateField HeaderText="CASC CODE 2">

                                                                                                                <ItemTemplate>

                                                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-11 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" ID="TextBox2" MaxLength="35" TabIndex="151" runat="server"></asp:TextBox>

                                                                                                                </ItemTemplate>

                                                                                                            </asp:TemplateField>

                                                                                                            <asp:TemplateField HeaderText="CASC CODE 3">

                                                                                                                <ItemTemplate>

                                                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-11 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" ID="TextBox3" MaxLength="35" TabIndex="152" runat="server"></asp:TextBox>

                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                            <asp:TemplateField HeaderText="ADD">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:Button ID="ProductCode1Add" OnClick="ProductCode1Add_Click" runat="server" Text="+ Add" TabIndex="153" CssClass="duration-300 ease-in-out w-[100px] bg-[#0560FD] bg-opacity-10 border hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-[#0560FD] text-center rounded-md text-sm sa700" />
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
                                                                            <%-- PRODUCT cODE 2--%>


                                                                            <div class="panel panel-primary">
                                                                                <div class="panel-heading">
                                                                                    <h4 class="panel-title">
                                                                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapsep1d">Product Code 2</a>
                                                                                    </h4>
                                                                                </div>


                                                                                <div id="collapsep1d" class="panel-collapse collapse-show ">
                                                                                    <div class="panel-body">

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
                                                                                                        <asp:Button ID="btnpc2" runat="server" Text="Copy Of HS-Quantity" OnClick="btnpc2_Click" Visible="true" />
                                                                                                        <p><%--<i class='fa fa-search' data-toggle="modal" data-target="#Product2"></i>--%></p>
                                                                                                        <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="pnlpc2" TargetControlID="btnproductcode"
                                                                                                            OkControlID="btnpc2Yes" CancelControlID="btnpc2No" BackgroundCssClass="modalBackground">
                                                                                                        </cc1:ModalPopupExtender>
                                                                                                        <asp:Panel ID="pnlpc2" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                                                                            <div class="header">

                                                                                                                <%--  <svg class="cursor-pointer absolute right-5 top-5" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                                                                    <circle opacity="0.1" cx="12" cy="12" r="12" fill="#676D7C"></circle>
                                                                                                                    <path d="M16.6663 7.3335L7.33301 16.6668M7.33301 7.3335L16.6663 16.6668" stroke="#676D7C" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                                                                                                </svg>--%>
                                                                                                                <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Product Code 2</p>


                                                                                                            </div>
                                                                                                            <div class="body">
                                                                                                                <asp:UpdatePanel ID="uppc2" runat="server" UpdateMode="Conditional">
                                                                                                                    <ContentTemplate>
                                                                                                                        <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                                                            <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ProductCode2Search" OnTextChanged="ProductCode2Search_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server" Style="text-transform: uppercase"></asp:TextBox>
                                                                                                                        </div>
                                                                                                                        <br />

                                                                                                                        No of Rows:

    <asp:DropDownList ID="ddlpc2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlpc2_SelectedIndexChanged">

        <asp:ListItem>10</asp:ListItem>

        <asp:ListItem>20</asp:ListItem>

        <asp:ListItem>30</asp:ListItem>

        <asp:ListItem>All</asp:ListItem>

    </asp:DropDownList>
                                                                                                                        <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
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

                                                                                                                                    <asp:TemplateField Visible="false">
                                                                                                                                        <ItemTemplate>
                                                                                                                                            <asp:LinkButton ID="lnkProductCode2" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="lnkProductCode2_Command" CssClass="duration-300 ease-in-out md:max-w-[200px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700">Select </asp:LinkButton>
                                                                                                                                        </ItemTemplate>
                                                                                                                                    </asp:TemplateField>
                                                                                                                                </Columns>
                                                                                                                            </asp:GridView>
                                                                                                                        </div>

                                                                                                                    </ContentTemplate>

                                                                                                                </asp:UpdatePanel>
                                                                                                            </div>

                                                                                                            <div class="footer" align="right">
                                                                                                                <asp:Button ID="btnpc2Yes" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                                                                <asp:Button ID="btnpc2No" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px] mt-4 w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                                                            </div>
                                                                                                        </asp:Panel>


                                                                                                        <div class="relative mt-1">
                                                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Product Code" CssClass="w-full h-11 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" type="text" ValidationGroup="Productcode" ID="TxtProductCode2" MaxLength="17" OnTextChanged="TxtProductCode1_TextChanged" AutoPostBack="true" TabIndex="124"></asp:TextBox>

                                                                                                            <asp:Button ID="btnproductcode" TabIndex="22" runat="server" CssClass="absolute right-4 top-3 btn-search-circle-img w-[22px] h-[22px]" Style="background-image: url('./images/circel-search.svg');" />
                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProductCode2" ID="RegularExpressionValidator40" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>
                                                                                                        </div>
                                                                                                        <div class="flex bg-slate-100 rounded-md md:w-[230px] w-full h-10 mt-2">
                                                                                                            <div class="md:w-[125px] w-full">
                                                                                                                <div class="relative w-full">
                                                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Type Quantity" autocomplete="off" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server" type="text" ID="TxtProQty2" MaxLength="16" ValidationGroup="Productcode" TabIndex="125" Text="0.00"></asp:TextBox>
                                                                                                                </div>
                                                                                                            </div>
                                                                                                            <svg class="mt-3" width="1" height="16" viewBox="0 0 1 16" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                                                                <line x1="0.5" y1="2.18561e-08" x2="0.499999" y2="16" stroke="#BCBCC4"></line>
                                                                                                            </svg>
                                                                                                            <div class="md:w-[125px] w-full">
                                                                                                                <div class="group relative">
                                                                                                                    <asp:DropDownList CssClass="drop font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt- px-4 focus:outline-none" ID="DrpP2" runat="server" TabIndex="126"></asp:DropDownList>
                                                                                                                </div>
                                                                                                            </div>
                                                                                                        </div>
                                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProQty2" ID="RegularExpressionValidator45" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>


                                                                                                    </div>
                                                                                                    <div class="col-sm-9">

                                                                                                        <asp:GridView CssClass="table table-striped table-bordered table-hover" ID="ProductCode2Grid1" runat="server" ShowFooter="true" AutoGenerateColumns="false">
                                                                                                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                            <Columns>

                                                                                                                <asp:BoundField DataField="Product Code" HeaderText="Seq." Visible="false" />

                                                                                                                <asp:TemplateField HeaderText="CASC CODE 1">

                                                                                                                    <ItemTemplate>

                                                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox1" MaxLength="35" CssClass="w-full h-11 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="127" runat="server"></asp:TextBox>

                                                                                                                    </ItemTemplate>

                                                                                                                </asp:TemplateField>

                                                                                                                <asp:TemplateField HeaderText="CASC CODE 2">

                                                                                                                    <ItemTemplate>

                                                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox2" MaxLength="35" CssClass="w-full h-11 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="128" runat="server"></asp:TextBox>

                                                                                                                    </ItemTemplate>

                                                                                                                </asp:TemplateField>

                                                                                                                <asp:TemplateField HeaderText="CASC CODE 3">

                                                                                                                    <ItemTemplate>

                                                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox3" MaxLength="35" CssClass="w-full h-11 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="129" runat="server"></asp:TextBox>

                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="ADD">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Button ID="ProductCode2Add" OnClick="ProductCode2Add_Click" runat="server" Text="+ Add" TabIndex="130" CssClass="duration-300 ease-in-out w-[100px] bg-[#0560FD] bg-opacity-10 border hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-[#0560FD] text-center rounded-md text-sm sa700" />
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



                                                                            <%-- PRODUCT cODE 3--%>
                                                                            <div class="panel panel-primary">
                                                                                <div class="panel-heading">
                                                                                    <h4 class="panel-title">
                                                                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapsep1dz">Product Code 3</a>
                                                                                    </h4>
                                                                                </div>
                                                                                <div id="collapsep1dz" class="panel-collapse collapse ">
                                                                                    <div class="panel-body">

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

                                                                                                            <%--<i class='fa fa-search' data-toggle="modal" data-target="#Product3"></i>--%>
                                                                                                        </p>

                                                                                                        <asp:Button ID="Button19" runat="server" Text="Copy Of HS-Quantity" OnClick="Button19_Click" Visible="true" />
                                                                                                        <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" PopupControlID="pnlpc3" TargetControlID="btnpc3"
                                                                                                            OkControlID="btnpc3Yes" CancelControlID="btnpc3No" BackgroundCssClass="modalBackground">
                                                                                                        </cc1:ModalPopupExtender>
                                                                                                        <asp:Panel ID="pnlpc3" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                                                                            <div class="header">

                                                                                                                <%--  <svg class="cursor-pointer absolute right-5 top-5" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                                                                    <circle opacity="0.1" cx="12" cy="12" r="12" fill="#676D7C"></circle>
                                                                                                                    <path d="M16.6663 7.3335L7.33301 16.6668M7.33301 7.3335L16.6663 16.6668" stroke="#676D7C" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                                                                                                </svg>--%>
                                                                                                                <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Product Code 3</p>


                                                                                                            </div>
                                                                                                            <div class="body">
                                                                                                                <asp:UpdatePanel ID="uppc3" runat="server" UpdateMode="Conditional">
                                                                                                                    <ContentTemplate>
                                                                                                                        <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                                                            <label class="text-gray-500 text-sm font-medium">Code</label>

                                                                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ProductCode3Search" OnTextChanged="ProductCode3Search_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server" Style="text-transform: uppercase"></asp:TextBox>
                                                                                                                            <br />
                                                                                                                        </div>
                                                                                                                        <asp:DropDownList ID="ddlpc3" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlpc3_SelectedIndexChanged">

                                                                                                                            <asp:ListItem>10</asp:ListItem>

                                                                                                                            <asp:ListItem>20</asp:ListItem>

                                                                                                                            <asp:ListItem>30</asp:ListItem>

                                                                                                                            <asp:ListItem>All</asp:ListItem>

                                                                                                                        </asp:DropDownList>
                                                                                                                        <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
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

                                                                                                                                    <asp:TemplateField Visible="false">
                                                                                                                                        <ItemTemplate>
                                                                                                                                            <asp:LinkButton ID="lnkProductCode3" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="lnkProductCode3_Command" CssClass="duration-300 ease-in-out md:max-w-[200px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700">Select </asp:LinkButton>
                                                                                                                                        </ItemTemplate>
                                                                                                                                    </asp:TemplateField>
                                                                                                                                </Columns>
                                                                                                                            </asp:GridView>
                                                                                                                        </div>
                                                                                                                    </ContentTemplate>

                                                                                                                </asp:UpdatePanel>
                                                                                                            </div>

                                                                                                            <div class="footer" align="right">
                                                                                                                <asp:Button ID="btnpc3Yes" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                                                                <asp:Button ID="btnpc3No" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px] mt-4 w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                                                            </div>
                                                                                                        </asp:Panel>



                                                                                                        <div class="relative mt-1">
                                                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Product Code" CssClass="w-full h-11 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" type="text" ValidationGroup="Productcode" ID="TxtProductCode3" MaxLength="17" OnTextChanged="TxtProductCode1_TextChanged" AutoPostBack="true" TabIndex="130"></asp:TextBox>

                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProductCode3" ID="RegularExpressionValidator41" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>
                                                                                                            <asp:Button ID="btnpc3" TabIndex="22" runat="server" CssClass="absolute right-4 top-3 btn-search-circle-img w-[22px] h-[22px]" Style="background-image: url('./images/circel-search.svg');" />

                                                                                                        </div>
                                                                                                        <div class="flex bg-slate-100 rounded-md md:w-[230px] w-full h-10 mt-2">
                                                                                                            <div class="md:w-[125px] w-full">
                                                                                                                <div class="relative w-full">
                                                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Type Quantity" autocomplete="off" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server" type="text" ID="TxtProQty3" MaxLength="16" ValidationGroup="Productcode" TabIndex="131" Text="0.00"></asp:TextBox>
                                                                                                                </div>
                                                                                                            </div>
                                                                                                            <svg class="mt-3" width="1" height="16" viewBox="0 0 1 16" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                                                                <line x1="0.5" y1="2.18561e-08" x2="0.499999" y2="16" stroke="#BCBCC4"></line>
                                                                                                            </svg>
                                                                                                            <div class="md:w-[125px] w-full">
                                                                                                                <div class="group relative">
                                                                                                                    <asp:DropDownList CssClass="drop font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt- px-4 focus:outline-none" ID="DrpP3" runat="server" TabIndex="132"></asp:DropDownList>
                                                                                                                </div>
                                                                                                            </div>
                                                                                                        </div>
                                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProQty3" ID="RegularExpressionValidator46" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>

                                                                                                    </div>
                                                                                                    <div class="col-sm-9">

                                                                                                        <asp:GridView CssClass="table table-striped table-bordered table-hover" ID="ProductCode3Grid1" runat="server" ShowFooter="true" AutoGenerateColumns="false">
                                                                                                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                            <Columns>

                                                                                                                <asp:BoundField DataField="RowNumber" HeaderText="Seq." Visible="false" />

                                                                                                                <asp:TemplateField HeaderText="CASC CODE 1">

                                                                                                                    <ItemTemplate>

                                                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox1" MaxLength="35" CssClass="w-full h-11 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="133" runat="server"></asp:TextBox>

                                                                                                                    </ItemTemplate>

                                                                                                                </asp:TemplateField>

                                                                                                                <asp:TemplateField HeaderText="CASC CODE 2">

                                                                                                                    <ItemTemplate>

                                                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox2" MaxLength="35" CssClass="w-full h-11 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="134" runat="server"></asp:TextBox>

                                                                                                                    </ItemTemplate>

                                                                                                                </asp:TemplateField>

                                                                                                                <asp:TemplateField HeaderText="CASC CODE 3">

                                                                                                                    <ItemTemplate>

                                                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox3" MaxLength="35" CssClass="w-full h-11 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="135" runat="server"></asp:TextBox>

                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="ADD">

                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Button ID="ProductCode3Add" OnClick="ProductCode3Add_Click" runat="server" Text="+ Add" TabIndex="136" CssClass="duration-300 ease-in-out w-[100px] bg-[#0560FD] bg-opacity-10 border hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-[#0560FD] text-center rounded-md text-sm sa700" />
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


                                                                            <%-- PRODUCT cODE 4--%>
                                                                            <div class="panel panel-primary">
                                                                                <div class="panel-heading">
                                                                                    <h4 class="panel-title">
                                                                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapsep1dz3">Product Code 4</a>
                                                                                    </h4>
                                                                                </div>
                                                                                <div id="collapsep1dz3" class="panel-collapse collapse ">
                                                                                    <div class="panel-body">

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
                                                                                                        </p>
                                                                                                        <asp:Button ID="Button20" runat="server" Text="Copy Of HS-Quantity" OnClick="Button20_Click" Visible="true" />
                                                                                                        <cc1:ModalPopupExtender ID="ModalPopupExtender3" runat="server" PopupControlID="pnlpc4" TargetControlID="btnpc4"
                                                                                                            OkControlID="btnpc4Yes" CancelControlID="btnpc4No" BackgroundCssClass="modalBackground">
                                                                                                        </cc1:ModalPopupExtender>
                                                                                                        <asp:Panel ID="pnlpc4" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                                                                            <div class="header">

                                                                                                                <%-- <svg class="cursor-pointer absolute right-5 top-5" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                                                                    <circle opacity="0.1" cx="12" cy="12" r="12" fill="#676D7C"></circle>
                                                                                                                    <path d="M16.6663 7.3335L7.33301 16.6668M7.33301 7.3335L16.6663 16.6668" stroke="#676D7C" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                                                                                                </svg>--%>
                                                                                                                <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Product Code 4</p>


                                                                                                            </div>

                                                                                                            <div class="body">
                                                                                                                <asp:UpdatePanel ID="uppc4" runat="server" UpdateMode="Conditional">
                                                                                                                    <ContentTemplate>
                                                                                                                        <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                                                            <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ProductCode4Search" OnTextChanged="ProductCode4Search_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server" Style="text-transform: uppercase"></asp:TextBox>
                                                                                                                            <br />
                                                                                                                        </div>

                                                                                                                        <asp:DropDownList ID="ddlpc4" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlpc4_SelectedIndexChanged">

                                                                                                                            <asp:ListItem>10</asp:ListItem>

                                                                                                                            <asp:ListItem>20</asp:ListItem>

                                                                                                                            <asp:ListItem>30</asp:ListItem>

                                                                                                                            <asp:ListItem>All</asp:ListItem>

                                                                                                                        </asp:DropDownList>

                                                                                                                        <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
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

                                                                                                                                    <asp:TemplateField Visible="false">
                                                                                                                                        <ItemTemplate>
                                                                                                                                            <asp:LinkButton ID="lnkProductCode4" runat="server" CommandArgument='<%# Eval("Id") %>' CssClass="duration-300 ease-in-out md:max-w-[200px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700">Select </asp:LinkButton>
                                                                                                                                        </ItemTemplate>
                                                                                                                                    </asp:TemplateField>
                                                                                                                                </Columns>
                                                                                                                            </asp:GridView>
                                                                                                                        </div>

                                                                                                                    </ContentTemplate>

                                                                                                                </asp:UpdatePanel>
                                                                                                            </div>

                                                                                                            <div class="footer" align="right">
                                                                                                                <asp:Button ID="btnpc4Yes" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                                                                <asp:Button ID="btnpc4No" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px] mt-4 w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                                                            </div>
                                                                                                        </asp:Panel>


                                                                                                        <div class="relative mt-1">
                                                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Product Code" CssClass="w-full h-11 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" type="text" ValidationGroup="Productcode" ID="TxtProductCode4" MaxLength="17" OnTextChanged="TxtProductCode1_TextChanged" AutoPostBack="true" TabIndex="241"></asp:TextBox>

                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProductCode4" ID="RegularExpressionValidator42" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>
                                                                                                            <asp:Button ID="btnpc4" TabIndex="22" runat="server" CssClass="absolute right-4 top-3 btn-search-circle-img w-[22px] h-[22px]" Style="background-image: url('./images/circel-search.svg');" />

                                                                                                        </div>
                                                                                                        <div class="flex bg-slate-100 rounded-md md:w-[230px] w-full h-10 mt-2">
                                                                                                            <div class="md:w-[125px] w-full">
                                                                                                                <div class="relative w-full">
                                                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Type Quantity" autocomplete="off" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server" type="text" ID="TxtProQty4" MaxLength="16" ValidationGroup="Productcode" TabIndex="242" Text="0.00"></asp:TextBox>
                                                                                                                </div>
                                                                                                            </div>
                                                                                                            <svg class="mt-3" width="1" height="16" viewBox="0 0 1 16" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                                                                <line x1="0.5" y1="2.18561e-08" x2="0.499999" y2="16" stroke="#BCBCC4"></line>
                                                                                                            </svg>
                                                                                                            <div class="md:w-[125px] w-full">
                                                                                                                <div class="group relative">
                                                                                                                    <asp:DropDownList CssClass="drop font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt- px-4 focus:outline-none" ID="DrpP4" runat="server" TabIndex="243"></asp:DropDownList>
                                                                                                                </div>
                                                                                                            </div>
                                                                                                        </div>
                                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProQty4" ID="RegularExpressionValidator47" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>

                                                                                                    </div>
                                                                                                    <div class="col-sm-9">

                                                                                                        <asp:GridView CssClass="table table-striped table-bordered table-hover" ID="ProductCode4Grid1" runat="server" ShowFooter="true" AutoGenerateColumns="false">
                                                                                                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                            <Columns>

                                                                                                                <asp:BoundField DataField="RowNumber" HeaderText="Seq." Visible="false" />

                                                                                                                <asp:TemplateField HeaderText="CASC CODE 1">

                                                                                                                    <ItemTemplate>

                                                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox1" MaxLength="35" CssClass="w-full h-11 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>

                                                                                                                    </ItemTemplate>

                                                                                                                </asp:TemplateField>

                                                                                                                <asp:TemplateField HeaderText="CASC CODE 2">

                                                                                                                    <ItemTemplate>

                                                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox2" MaxLength="35" CssClass="w-full h-11 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>

                                                                                                                    </ItemTemplate>

                                                                                                                </asp:TemplateField>

                                                                                                                <asp:TemplateField HeaderText="CASC CODE 3">

                                                                                                                    <ItemTemplate>

                                                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox3" MaxLength="35" Width="150" runat="server"></asp:TextBox>

                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>

                                                                                                                <asp:TemplateField HeaderText="ADD">

                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Button ID="ProductCode4Add" OnClick="ProductCode4Add_Click" runat="server" Text="+ Add" CssClass="duration-300 ease-in-out w-[100px] bg-[#0560FD] bg-opacity-10 border hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-[#0560FD] text-center rounded-md text-sm sa700" />

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

                                                                            <%-- PRODUCT cODE 4--%>
                                                                            <div class="panel panel-primary">
                                                                                <div class="panel-heading">
                                                                                    <h4 class="panel-title">
                                                                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapsep1dz5">Product Code 5</a>
                                                                                    </h4>
                                                                                </div>
                                                                                <div id="collapsep1dz5" class="panel-collapse collapse ">
                                                                                    <div class="panel-body">

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
                                                                                                        <p>
                                                                                                        </p>

                                                                                                        <asp:Button ID="Button21" runat="server" Text="Copy Of HS-Quantity" OnClick="Button21_Click" Visible="true" />
                                                                                                        <cc1:ModalPopupExtender ID="ModalPopupExtender4" runat="server" PopupControlID="pnlpc5" TargetControlID="btnpc5"
                                                                                                            OkControlID="btnpc5Yes" CancelControlID="btnpc5No" BackgroundCssClass="modalBackground">
                                                                                                        </cc1:ModalPopupExtender>
                                                                                                        <asp:Panel ID="pnlpc5" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                                                                            <div class="header">

                                                                                                                <%--    <svg class="cursor-pointer absolute right-5 top-5" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                                                                    <circle opacity="0.1" cx="12" cy="12" r="12" fill="#676D7C"></circle>
                                                                                                                    <path d="M16.6663 7.3335L7.33301 16.6668M7.33301 7.3335L16.6663 16.6668" stroke="#676D7C" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                                                                                                </svg>--%>
                                                                                                                <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Product Code 5</p>


                                                                                                                Product Code 5
                                                                                                            </div>

                                                                                                            <div class="body">

                                                                                                                <asp:UpdatePanel ID="uppc5" runat="server" UpdateMode="Conditional">
                                                                                                                    <ContentTemplate>
                                                                                                                        <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                                                            <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ProductCode5Search" OnTextChanged="ProductCode5Search_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server" Style="text-transform: uppercase"></asp:TextBox>
                                                                                                                            <br />
                                                                                                                        </div>

                                                                                                                        <asp:DropDownList ID="ddlpc5" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlpc5_SelectedIndexChanged">

                                                                                                                            <asp:ListItem>10</asp:ListItem>

                                                                                                                            <asp:ListItem>20</asp:ListItem>

                                                                                                                            <asp:ListItem>30</asp:ListItem>

                                                                                                                            <asp:ListItem>All</asp:ListItem>

                                                                                                                        </asp:DropDownList>

                                                                                                                        <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
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

                                                                                                                                    <asp:TemplateField Visible="false">
                                                                                                                                        <ItemTemplate>
                                                                                                                                            <asp:LinkButton ID="lnkProductCode5" runat="server" CommandArgument='<%# Eval("Id") %>' CssClass="duration-300 ease-in-out md:max-w-[200px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700">Select </asp:LinkButton>
                                                                                                                                        </ItemTemplate>
                                                                                                                                    </asp:TemplateField>
                                                                                                                                </Columns>
                                                                                                                            </asp:GridView>
                                                                                                                        </div>
                                                                                                                    </ContentTemplate>

                                                                                                                </asp:UpdatePanel>
                                                                                                            </div>

                                                                                                            <div class="footer" align="right">
                                                                                                                <asp:Button ID="btnpc5Yes" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                                                                <asp:Button ID="btnpc5No" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px] mt-4 w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                                                            </div>
                                                                                                        </asp:Panel>


                                                                                                        <div class="relative mt-1">
                                                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Product Code" CssClass="w-full h-11 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" type="text" ValidationGroup="Productcode" ID="TxtProductCode5" MaxLength="17" OnTextChanged="TxtProductCode1_TextChanged" AutoPostBack="true" TabIndex="142"></asp:TextBox>

                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProductCode5" ID="RegularExpressionValidator43" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>
                                                                                                            <asp:Button ID="btnpc5" TabIndex="22" runat="server" CssClass="absolute right-4 top-3 btn-search-circle-img w-[22px] h-[22px]" Style="background-image: url('./images/circel-search.svg');" />

                                                                                                        </div>
                                                                                                        <div class="flex bg-slate-100 rounded-md md:w-[230px] w-full h-10 mt-2">
                                                                                                            <div class="md:w-[125px] w-full">
                                                                                                                <div class="relative w-full">
                                                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Type Quantity" autocomplete="off" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server" type="text" ID="TxtProQty5" MaxLength="16" ValidationGroup="Productcode" TabIndex="242" Text="0.00"></asp:TextBox>
                                                                                                                </div>
                                                                                                            </div>
                                                                                                            <svg class="mt-3" width="1" height="16" viewBox="0 0 1 16" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                                                                <line x1="0.5" y1="2.18561e-08" x2="0.499999" y2="16" stroke="#BCBCC4"></line>
                                                                                                            </svg>
                                                                                                            <div class="md:w-[125px] w-full">
                                                                                                                <div class="group relative">
                                                                                                                    <asp:DropDownList CssClass="drop font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt- px-4 focus:outline-none" ID="DrpP5" runat="server" TabIndex="243"></asp:DropDownList>
                                                                                                                </div>
                                                                                                            </div>
                                                                                                        </div>
                                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProQty5" ID="RegularExpressionValidator48" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>

                                                                                                    </div>
                                                                                                    <div class="col-sm-9">

                                                                                                        <asp:GridView CssClass="table table-striped table-bordered table-hover" ID="ProductCode5Grid1" runat="server" ShowFooter="true" AutoGenerateColumns="false">
                                                                                                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                            <Columns>

                                                                                                                <asp:BoundField DataField="RowNumber" HeaderText="Seq." Visible="false" />

                                                                                                                <asp:TemplateField HeaderText="CASC CODE 1">

                                                                                                                    <ItemTemplate>

                                                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox1" MaxLength="35" CssClass="w-full h-11 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server" Style="text-transform: uppercase"></asp:TextBox>

                                                                                                                    </ItemTemplate>

                                                                                                                </asp:TemplateField>

                                                                                                                <asp:TemplateField HeaderText="CASC CODE 2">

                                                                                                                    <ItemTemplate>

                                                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox2" MaxLength="35" CssClass="w-full h-11 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server" Style="text-transform: uppercase"></asp:TextBox>

                                                                                                                    </ItemTemplate>

                                                                                                                </asp:TemplateField>

                                                                                                                <asp:TemplateField HeaderText="CASC CODE 3">

                                                                                                                    <ItemTemplate>

                                                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox3" MaxLength="35" CssClass="w-full h-11 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server" Style="text-transform: uppercase"></asp:TextBox>

                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="ADD">

                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Button ID="ProductCode5Plus" OnClick="ProductCode5Plus_Click" runat="server" Text="+ Add" CssClass="duration-300 ease-in-out w-[100px] bg-[#0560FD] bg-opacity-10 border hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-[#0560FD] text-center rounded-md text-sm sa700" />
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





                                                        <div class="row">
                                                            <div class="col-sm-4" style="display: none;">
                                                            </div>






                                                            <div class="col-sm-4">
                                                            </div>
                                                            <div class="col-sm-4">
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
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="InhouseSearchItem" OnTextChanged="InhouseSearchItem_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
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

                                                                    <cc1:ModalPopupExtender ID="popupHSCODE" runat="server" PopupControlID="pnlhscode" TargetControlID="btnhscode1"
                                                                        OkControlID="btyeshs" CancelControlID="btnnohs" BackgroundCssClass="modalBackground">
                                                                    </cc1:ModalPopupExtender>
                                                                    <asp:Panel ID="pnlhscode" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                                        <div class="header">

                                                                            <%--  <svg class="cursor-pointer absolute right-5 top-5" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                              <circle opacity="0.1" cx="12" cy="12" r="12" fill="#676D7C"></circle>
                                                              <path d="M16.6663 7.3335L7.33301 16.6668M7.33301 7.3335L16.6663 16.6668" stroke="#676D7C" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                                          </svg>--%>
                                                                            <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">HS Code Search</p>


                                                                        </div>
                                                                        <div class="body">

                                                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                                                                <ContentTemplate>

                                                                                    <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                        <label class="text-gray-500 text-sm font-medium">Code</label>

                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="HSCodeSearchItem" OnTextChanged="HSCodeSearchItem_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>


                                                                                    </div>
                                                                                    <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                                        <asp:GridView ID="HSCodeGridItem" OnPageIndexChanging="HSCodeGridItem_PageIndexChanging" PageSize="5" AllowPaging="True" OnRowDataBound="HSCodeGridItem_RowDataBound" OnRowCommand="HSCodeGridItem_RowCommand" DataKeyNames="Id" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
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

                                                                                                <asp:TemplateField Visible="true">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton ID="lnkHSCodeItem" OnCommand="lnkHSCodeItem_Command" runat="server" CommandArgument='<%# Eval("Id") %>'>Select </asp:LinkButton>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                            </Columns>
                                                                                        </asp:GridView>
                                                                                    </div>
                                                                                </ContentTemplate>

                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <div class="footer" align="right">
                                                                            <asp:Button ID="btyeshs" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                            <asp:Button ID="btnnohs" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px] mt-4 w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                        </div>
                                                                    </asp:Panel>


                                                                    <div class="row">
                                                                        <div class="col-sm-6" id="hs" runat="server" visible="false">

                                                                            <p>Serial Number</p>
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" Visible="false" type="text" Enabled="false" ID="TxtSerialNo" TabIndex="90"></asp:TextBox>



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

                                                            <br />
                                                            <div class="mt-6">
                                                                <div class="flex justify-between gap-2 items-center">
                                                                    <h2 class="text-lg sa700 leading-[18px] text-gray-800">SHIPPING MARKS INFORMATION
                                                                    </h2>
                                                                    <div onclick="drop_draft_SM();" class="bg-[#0560FD] bg-opacity-5 w-7 h-7 flex justify-center items-center rounded-full">
                                                                        <svg id="drop_draft_1_Svg" width="20" height="20" viewBox="0 0 20 20" fill="none" xmlns="http://www.w3.org/2000/svg" class="">
                                                                            <path d="M5 9.58301L9.43692 5.51584C9.70425 5.27076 9.83792 5.14826 10 5.14826C10.1621 5.14826 10.2958 5.27076 10.5631 5.51584L15 9.58301" stroke="#0560FD" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                                                            <path d="M5 15L9.43692 10.9328C9.70425 10.6877 9.83792 10.5652 10 10.5652C10.1621 10.5652 10.2958 10.6877 10.5631 10.9328L15 15" stroke="#0560FD" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                                                        </svg>
                                                                    </div>
                                                                </div>
                                                                <!--  -->
                                                                <!--  -->
                                                                <%-- <div aria-label="Main" id="drop_draft_1_area" class="duration-300 ease-in-out transition-all hidden">--%>
                                                                <div aria-label="Main" id="drop_draft_1_SM" class="duration-300 ease-in-out transition-all ">
                                                                    <div class="mt-2 flex items-center gap-4 lg:flex-nowrap flex-wrap">
                                                                        <div class="w-full">
                                                                            <label class="text-gray-500 text-sm font-medium">Shipping Marks 1</label>
                                                                            <div class="relative mt-1">
                                                                                <%--<asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Type Quantity" autocomplete="off" runat="server" type="text" ID="TextBox8" MaxLength="30" TabIndex="167" ValidationGroup="Item" class="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" Style="text-transform: uppercase"></asp:TextBox>
                       <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtCurrentLot" ID="RegularExpressionValidator74" ValidationExpression="^[\s\S]{0,30}$" runat="server" ErrorMessage="Maximum 30 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>--%>
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" Width="250" Height="130" type="text" ID="txtShippingMarks1" ValidationGroup="Shipping" TabIndex="170" TextMode="MultiLine" class="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" Style="text-transform: uppercase"></asp:TextBox>

                                                                                <br />
                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtShippingMarks1" ID="RegularExpressionValidator49" ValidationExpression="^[\s\S]{0,170}$" runat="server" ErrorMessage="Maximum 170 characters allowed." ValidationGroup="Shipping"></asp:RegularExpressionValidator>
                                                                            </div>
                                                                        </div>

                                                                        <div class="w-full">
                                                                            <label class="text-gray-500 text-sm font-medium">Shipping Marks 2</label>
                                                                            <div class="relative mt-1">
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" class="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" Width="250" Height="130" type="text" ID="txtShippingMarks2" ValidationGroup="Shipping" TabIndex="171" TextMode="MultiLine" Style="text-transform: uppercase"></asp:TextBox>
                                                                                <br />
                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtShippingMarks2" ID="RegularExpressionValidator50" ValidationExpression="^[\s\S]{0,170}$" runat="server" ErrorMessage="Maximum 170 characters allowed." ValidationGroup="Shipping"></asp:RegularExpressionValidator>
                                                                            </div>
                                                                        </div>
                                                                        <div class="w-full">
                                                                            <label class="text-gray-500 text-sm font-medium">Shipping Marks 3</label>
                                                                            <div class="relative mt-1">
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" class="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" Width="250" Height="130" type="text" ID="txtShippingMarks3" ValidationGroup="Shipping" TabIndex="172" TextMode="MultiLine" Style="text-transform: uppercase"></asp:TextBox>
                                                                                <br />
                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtShippingMarks3" ID="RegularExpressionValidator51" ValidationExpression="^[\s\S]{0,136}$" runat="server" ErrorMessage="Maximum 136 characters allowed." ValidationGroup="Shipping"></asp:RegularExpressionValidator>
                                                                            </div>
                                                                        </div>
                                                                        <div class="w-full">
                                                                            <label class="text-gray-500 text-sm font-medium">Shipping Marks 4</label>
                                                                            <div class="relative mt-1">
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" class="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" Width="250" Height="130" type="text" ID="txtShippingMarks4" ValidationGroup="Shipping" TabIndex="173" TextMode="MultiLine" Style="text-transform: uppercase"></asp:TextBox>
                                                                                <br />
                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtShippingMarks4" ID="RegularExpressionValidator52" ValidationExpression="^[\s\S]{0,36}$" runat="server" ErrorMessage="Maximum 36 characters allowed." ValidationGroup="Shipping"></asp:RegularExpressionValidator>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <!--  -->
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



                                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <div class="card card-body flex justify-between gap-2 items-center mt-6">
                                                                <h2 class="text-lg sa700 leading-[18px] text-gray-800">Upload Item Excel Template
                                                                </h2>
                                                            </div>
                                                            <div class="flex lg:flex-nowrap flex-wrap gap-4 mt-4 items-start">
                                                                <div class="w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Download Item Excel Template</label>
                                                                    <a href="ExcelTemplate/Item_Upload_Excel_Inpayment.xlsx" download class="mt-1 w-full h-10 bg-[#0560FD] rounded-md flex items-center justify-center gap-2 cursor-pointer">
                                                                        <svg width="22" height="22" viewBox="0 0 22 22" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                            <path d="M16.7288 8.25C18.6151 8.31747 20.2167 9.73216 20.1651 11.6274C20.1531 12.0683 19.9824 12.6132 19.6407 13.7032C18.8187 16.3262 17.4371 18.6032 14.342 19.1495C13.773 19.25 13.1328 19.25 11.8524 19.25H10.1469C8.8665 19.25 8.2263 19.25 7.65736 19.1495C4.56228 18.6032 3.18067 16.3262 2.35859 13.7032C2.017 12.6132 1.8462 12.0683 1.83422 11.6274C1.7827 9.73216 3.38428 8.31747 5.27052 8.25" stroke="white" stroke-width="2" stroke-linecap="round"></path>
                                                                            <path opacity="0.4" d="M10.9997 12.8333V2.75M10.9997 12.8333C10.3578 12.8333 9.15858 11.0052 8.70801 10.5417M10.9997 12.8333C11.6415 12.8333 12.8408 11.0052 13.2913 10.5417" stroke="white" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"></path>
                                                                        </svg>
                                                                        <p class="text-center text-white text-sm sa700">
                                                                            Download Template
                 
                                                                        </p>
                                                                    </a>
                                                                </div>
                                                                <div class="w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Upload Excel File</label>
                                                                    <div class="mt-1 w-full h-10 bg-slate-100 rounded-md flex items-center justify-center gap-2 cursor-pointer relative">
                                                                        <asp:Label runat="server" ID="Label3" />
                                                                        <asp:FileUpload ID="FileUpload4" runat="server" AllowMultiple="false" CssClass="absolute h-full left-0 opacity-0 w-full" />
                                                                        <img src="./images/import.svg" alt="Import">
                                                                        <p class="text-center text-[#0560FD] text-sm sa700">
                                                                            Choose &amp; Upload
                 
                                                                        </p>
                                                                    </div>
                                                                </div>

                                                                <div class="w-full self-center">
                                                                    <asp:Button ID="BtnExcelUp" runat="server" OnClick="BtnExcelUp_Click" Text="Upload Excel" class="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                    <asp:Label runat="server" ID="Error_LBL" />
                                                                </div>

                                                            </div>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:PostBackTrigger ControlID="BtnExcelUp" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                    <br />
                                                    <hr />
                                                    <div id="ItemAddGrid" runat="server">
                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="AddItemSearch" OnTextChanged="AddItemSearch_TextChanged" Visible="false" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server" Style="text-transform: uppercase"></asp:TextBox>
                                                        <br />

                                                        <div class="table-responsive">
                                                            <div class="row">

                                                                <div class="col-md-4 box box-body">
                                                                    <label class="text-gray-500 text-sm font-medium">Action Buttons</label>
                                                                    <br />
                                                                    <div class="btn-group" role="group" aria-label="Basic example">


                                                                        <asp:Button ID="Btnselectitem" OnClick="Btnselectitem_Click" runat="server" Text="Delete" class="btn btn-primary bg-[#0560FD] border-[#0560FD] hover:bg-transparent hover:text-[#0560FD]" />


                                                                        <asp:Button ID="BtnItemDeleteAll" runat="server" OnClick="BtnItemDeleteAll_Click" Text="Delete All" class="btn btn-primary bg-[#0560FD] border-[#0560FD] hover:bg-transparent hover:text-[#0560FD]" />

                                                                        <asp:Button ID="BtnItemEditAll" runat="server" OnClick="BtnItemEditAll_Click" Text="Edit All" class="btn btn-primary bg-[#0560FD] border-[#0560FD] hover:bg-transparent hover:text-[#0560FD]" />



                                                                    </div>
                                                                </div>





                                                                <div class="col-md-8">
                                                                    <label class="text-gray-500 text-sm font-medium">Copy Item Details</label>
                                                                    <div class="row">
                                                                        <div class="col-md-4">
                                                                            <asp:TextBox ID="txtctd" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server" placeholder="Type Copy Text.."></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-md-8">
                                                                            <div class="btn-group" role="group" aria-label="Basic example">
                                                                                <asp:Button OnClientClick="return confirm('Confirm this action?');" ID="btncopyhscode" OnClick="btncopyhscode_Click" runat="server" Text="Copy HS Code" class="btn btn-primary bg-[#0560FD] border-[#0560FD] hover:bg-transparent hover:text-[#0560FD]" />
                                                                                <asp:Button OnClientClick="return confirm('Confirm this action?');" ID="btncopydesc" OnClick="btncopydesc_Click" runat="server" Text="Copy Description" class="btn btn-primary bg-[#0560FD] border-[#0560FD] hover:bg-transparent hover:text-[#0560FD]" />
                                                                                <asp:Button OnClientClick="return confirm('Confirm this action?');" ID="btncopycoo" OnClick="btncopycoo_Click" runat="server" Text="Copy COO" class="btn btn-primary bg-[#0560FD] border-[#0560FD] hover:bg-transparent hover:text-[#0560FD]" />


                                                                            </div>
                                                                        </div>
                                                                    </div>



                                                                </div>
                                                            </div>
                                                            <br />
                                                            <asp:GridView ID="AddItemGrid" Font-Size="10" OnRowDeleting="AddItemGrid_RowDeleting" PageSize="50" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="AddItemGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                <Columns>

                                                                    <asp:TemplateField Visible="true">

                                                                        <HeaderTemplate>

                                                                            <asp:CheckBox ID="chkAll" runat="server"
                                                                                onclick="checkAll(this);" />

                                                                        </HeaderTemplate>

                                                                        <ItemTemplate>

                                                                            <asp:CheckBox ID="chk" OnCheckedChanged="chk_CheckedChanged" AutoPostBack="true" runat="server" />

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

                                                                    <asp:TemplateField HeaderText="">
                                                                        <ItemTemplate>
                                                                            <div class="flex gap-4 items-center pr-6 status-action">
                                                                                <div class="relative">
                                                                                    <asp:ImageButton CssClass="hover-img" ImageUrl="images/blue-pencil.svg" Width="16" Height="16" OnClick="ItemEdit_Click" ID="ItemEdit" runat="server" />
                                                                                    <asp:ImageButton ImageUrl="images/pencil.svg" Width="16" Height="16" OnClick="ItemEdit_Click" ID="ImageButton1" runat="server" />
                                                                                </div>
                                                                                <div class="relative">
                                                                                    <asp:LinkButton CssClass="hover-img" data-target='<%#"#"+DataBinder.Eval(Container.DataItem,"Id")%>' Width="16" OnClick="imgItemDelete_Click" Height="16" ID="imgItemDelete" runat="server"><img src="images/red-bin.svg" /></asp:LinkButton>
                                                                                    <asp:LinkButton data-target='<%#"#"+DataBinder.Eval(Container.DataItem,"Id")%>' Width="16" OnClick="imgItemDelete_Click" Height="16" ID="LinkButton1" runat="server"><img src="images/bin-gray.svg" /></asp:LinkButton>
                                                                                </div>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                </Columns>
                                                                <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </div>

                                                        <asp:HiddenField ID="hfCount" runat="server" Value="0" />
                                                        <div class="flex justify-end gap-4">
                                                            <%-- <button class="duration-300 ease-in-out md:max-w-[130px] w-full bg-[#0560FD] bg-opacity-10 border hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-[#0560FD] text-center rounded-md text-sm sa700">
                                                                + Add Product
                                                            </button>--%>

                                                            <asp:Button ID="btnsaveitem" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] bg-opacity-10 border hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-[#0560FD] text-center rounded-md text-sm sa700" runat="server" class="btn btn-info btn-lg" ValidationGroup="Item" OnClick="BtnItemAdd_Click" Text="+ Add Item" TabIndex="175" />


                                                            <%--  <asp:Button ID="btnDelete" runat="server" Text="Delete All" CssClass="duration-300 ease-in-out md:max-w-[130px] w-full bg-[#D81616] bg-opacity-10 border hover:bg-transparent hover:text-[#D81616] h-10 flex items-center justify-center text-[#D81616] text-center rounded-md text-sm sa700" OnClientClick="return ConfirmDelete();" OnClick="btnDelete_Click" />--%>
                                                        </div>
                                                    </div>
                                                    <hr class="mt-4" />
                                                    <div class="flex justify-between gap-4 md:flex-nowrap flex-wrap mt-6">
                                                        <asp:Button ID="btnprevitem" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" runat="server" class="btn btn-info btn-lg" OnClick="btnprevitem_Click" Text="Previous" TabIndex="174" />
                                                        <div class="flex gap-4 flex-wrap md:flex-nowrap md:max-w-[260px] w-full">
                                                            <asp:Button ID="btnresetitem" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" runat="server" class="btn btn-info btn-lg" OnClick="btnresetitem_Click" Text="Reset" TabIndex="176" />


                                                        </div>
                                                        <asp:Button ID="btnnextitem" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" runat="server" class="btn btn-info btn-lg" OnClick="btnnextitem_Click" Text="Next" TabIndex="177" />

                                                    </div>
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

                                    <cc1:TabPanel ID="CPC" runat="server" HeaderText="CPC">
                                        <ContentTemplate>
                                            <asp:UpdatePanel ID="upincpc" runat="server" UpdateMode="Conditional">

                                                <ContentTemplate>



                                                    <div class="row">
                                                        <div class="row">
                                                            <div class="col-sm-12">

                                                                <asp:CheckBox ID="chkaeo" OnCheckedChanged="chkaeo_CheckedChanged" AutoPostBack="true" runat="server" TabIndex="178" Checked="false" Style="text-transform: uppercase" />
                                                                <label for="chkaeo" class="text-gray-500 text-sm font-medium">AEO</label>
                                                            </div>
                                                            <div class="clearfix"></div>
                                                            <div class="table-responsive">
                                                                <div class="flex processingCode_outer">
                                                                    <div class="flex processingCode">
                                                                        <div class="processingCode_left_section" id="AEO" runat="server">
                                                                            <div class="table-responsive">
                                                                                <asp:GridView ID="AEOGrid" OnRowDeleting="AEOGrid_RowDeleting" FooterStyle-CssClass="w-full h-10 py-4 px-10 bg-[#F4F6FA] rounded-lg" CssClass="w-full bg-white rounded whitespace-nowrap" HeaderStyle-CssClass="w-full h-10 py-4 px-10 bg-[#F4F6FA] rounded-l-lg" PagerStyle-CssClass="pager" RowStyle-CssClass="rows" runat="server" ShowFooter="true" AutoGenerateColumns="false" Width="100%">
                                                                                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                    <Columns>

                                                                                        <asp:BoundField DataField="RowNumber" HeaderText="Seq." ItemStyle-Width="5%" />

                                                                                        <asp:TemplateField HeaderText="Processing Code1" ItemStyle-Width="31.66%" ItemStyle-CssClass="pl-2 text-xs leading-none py-3 px-2 text-gray-800 w-5 relative" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left">

                                                                                            <ItemTemplate>

                                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Processing Code1" autocomplete="off" ID="TextBox1" MaxLength="35" runat="server" TabIndex="180" CssClass="mr-4 px-3 w-[150px] h-8 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium relative focus:outline-none w-full" Style="width: 100%;"></asp:TextBox>

                                                                                            </ItemTemplate>

                                                                                        </asp:TemplateField>

                                                                                        <asp:TemplateField HeaderText="Processing Code2" ItemStyle-Width="31.66%" ItemStyle-CssClass="pl-2 text-xs leading-none py-3 px-2 text-gray-800 w-5 relative" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left">

                                                                                            <ItemTemplate>

                                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" placeholder="Processing Code2" ID="TextBox2" MaxLength="35" runat="server" TabIndex="181" CssClass="px-3 w-[180px] h-8 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium relative focus:outline-none" Style="width: 100%;"></asp:TextBox>

                                                                                            </ItemTemplate>

                                                                                        </asp:TemplateField>

                                                                                        <asp:TemplateField HeaderText="Processing Code3" ItemStyle-Width="31.66%" ItemStyle-CssClass="pl-2 text-xs leading-none py-3 px-2 text-gray-800 w-5 relative" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left">

                                                                                            <ItemTemplate>

                                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox3" placeholder="Processing Code3" MaxLength="35" runat="server" TabIndex="182" CssClass="px-3 w-[180px] h-8 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium relative focus:outline-none" Style="width: 100%;"></asp:TextBox>

                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TextBox3" ID="aeopc" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35characters allowed." ValidationGroup="cpc"></asp:RegularExpressionValidator>

                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>

                                                                                        <asp:TemplateField HeaderText="Delete" ItemStyle-Width="5%">
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton ID="imgDelete" runat="server"
                                                                                                    OnClientClick="deleteRowClientSide(this); return false;"
                                                                                                    CommandArgument='<%# Container.DataItemIndex %>'
                                                                                                    CssClass="text-danger">
                                                <i class='fa fa-trash' style="color:red"></i>
                                                                                                </asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>

                                                                                    </Columns>

                                                                                </asp:GridView>
                                                                            </div>

                                                                            <div class="processingCode_right_section">
                                                                                <asp:Button ID="BtnAEO" CssClass="text-sm text-[#0560FD] sa700 cursor-pointer" runat="server" OnClick="BtnAEO_Click"
                                                                                    Text="Add Processing Codes" TabIndex="179" />
                                                                            </div>
                                                                        </div>

                                                                    </div>
                                                                </div>
                                                            </div>



                                                        </div>
                                                        <hr />

                                                        <div class="row">
                                                            <div class="col-sm-12">

                                                                <asp:CheckBox ID="chkcwc" OnCheckedChanged="chkcwc_CheckedChanged" AutoPostBack="true" runat="server" TabIndex="178" Checked="false" Style="text-transform: uppercase" />
                                                                <label for="chkaeo" class="text-gray-500 text-sm font-medium">CWC</label>
                                                            </div>
                                                            <div class="clearfix"></div>
                                                            <div class="table-responsive">
                                                                <div class="flex processingCode_outer">
                                                                    <div class="flex processingCode">
                                                                        <div class="processingCode_left_section" id="CWC" runat="server">
                                                                            <div class="table-responsive">
                                                                                <asp:GridView ID="CWCGrid" OnRowDeleting="CWCGrid_RowDeleting" FooterStyle-CssClass="w-full h-10 py-4 px-10 bg-[#F4F6FA] rounded-lg" CssClass="w-full bg-white rounded whitespace-nowrap" HeaderStyle-CssClass="w-full h-10 py-4 px-10 bg-[#F4F6FA] rounded-l-lg" PagerStyle-CssClass="pager" RowStyle-CssClass="rows" runat="server" ShowFooter="true" AutoGenerateColumns="false">
                                                                                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                    <Columns>

                                                                                        <asp:BoundField DataField="RowNumber" HeaderText="Seq." ItemStyle-Width="5%" />

                                                                                        <asp:TemplateField HeaderText="Processing Code1" ItemStyle-Width="31.66%" ItemStyle-CssClass="pl-2 text-xs leading-none py-3 px-2 text-gray-800 w-5 relative" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left">

                                                                                            <ItemTemplate>

                                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Processing Code1" autocomplete="off" ID="TextBox1" MaxLength="35" runat="server" TabIndex="180" CssClass="mr-4 px-3 w-[150px] h-8 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium relative focus:outline-none" Style="width: 100%;"></asp:TextBox>

                                                                                            </ItemTemplate>

                                                                                        </asp:TemplateField>

                                                                                        <asp:TemplateField HeaderText="Processing Code2" ItemStyle-Width="31.66%" ItemStyle-CssClass="pl-2 text-xs leading-none py-3 px-2 text-gray-800 w-5 relative" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left">

                                                                                            <ItemTemplate>

                                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" placeholder="Processing Code2" ID="TextBox2" MaxLength="35" runat="server" TabIndex="181" CssClass="px-3 w-[180px] h-8 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium relative focus:outline-none" Style="width: 100%;"></asp:TextBox>

                                                                                            </ItemTemplate>

                                                                                        </asp:TemplateField>

                                                                                        <asp:TemplateField HeaderText="Processing Code3" ItemStyle-Width="31.66%" ItemStyle-CssClass="pl-2 text-xs leading-none py-3 px-2 text-gray-800 w-5 relative" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left">

                                                                                            <ItemTemplate>

                                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox3" placeholder="Processing Code3" MaxLength="35" runat="server" TabIndex="182" CssClass="px-3 w-[180px] h-8 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium relative focus:outline-none" Style="width: 100%;"></asp:TextBox>

                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TextBox3" ID="aeopc" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35characters allowed." ValidationGroup="cpc"></asp:RegularExpressionValidator>

                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>

                                                                                        <asp:TemplateField HeaderText="Delete" ItemStyle-Width="5%">
                                                                                            <ItemTemplate>
                                                                                                <!-- Simplified delete button with direct server-side click -->
                                                                                                <asp:LinkButton ID="imgDelete" runat="server"
                                                                                                    CommandName="DeleteRow"
                                                                                                    CommandArgument='<%# Container.DataItemIndex %>'
                                                                                                    OnClientClick="deleteRowClientSide(this); return false;"
                                                                                                    CssClass="text-danger">
                                                <i class='fa fa-trash' style="color:red"></i>
                                                                                                </asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>

                                                                                    </Columns>

                                                                                </asp:GridView>
                                                                            </div>

                                                                            <div class="processingCode_right_section">
                                                                                <asp:Button ID="BtnCWC" CssClass="text-sm text-[#0560FD] sa700 cursor-pointer" runat="server" OnClick="BtnCWC_Click" Text=" Add Processing Codes" TabIndex="179" />
                                                                            </div>
                                                                        </div>

                                                                    </div>
                                                                </div>
                                                            </div>



                                                        </div>
                                                        <hr />

                                                        <div class="row">
                                                            <div class="col-sm-12">

                                                                <asp:CheckBox ID="ChkSea1" OnCheckedChanged="ChkSea1_CheckedChanged" AutoPostBack="true" runat="server" TabIndex="178" Checked="false" Style="text-transform: uppercase" />
                                                                <label for="chkaeo" class="text-gray-500 text-sm font-medium">SEA STORE</label>
                                                            </div>
                                                            <div class="clearfix"></div>
                                                            <div class="table-responsive">
                                                                <div class="flex processingCode_outer">
                                                                    <div class="flex processingCode">
                                                                        <div class="processingCode_left_section" id="SEA" runat="server" visible="false">
                                                                            <div class="table-responsive">
                                                                                <asp:GridView ID="SeaGrid" OnRowDeleting="SeaGrid_RowDeleting" FooterStyle-CssClass="w-full h-10 py-4 px-10 bg-[#F4F6FA] rounded-lg" CssClass="w-full bg-white rounded whitespace-nowrap" HeaderStyle-CssClass="w-full h-10 py-4 px-10 bg-[#F4F6FA] rounded-l-lg" PagerStyle-CssClass="pager" RowStyle-CssClass="rows" runat="server" ShowFooter="true" AutoGenerateColumns="false">
                                                                                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                    <Columns>

                                                                                        <asp:BoundField DataField="RowNumber" HeaderText="Seq." ItemStyle-Width="5%" />

                                                                                        <asp:TemplateField HeaderText="Processing Code1" ItemStyle-Width="31.66%" ItemStyle-CssClass="pl-2 text-xs leading-none py-3 px-2 text-gray-800 w-5 relative" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left">

                                                                                            <ItemTemplate>

                                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="No. of Crew" autocomplete="off" ID="TextBox1" MaxLength="35" runat="server" TabIndex="180" CssClass="mr-4 px-3 w-[150px] h-8 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium relative focus:outline-none" Style="width: 100%;"></asp:TextBox>

                                                                                            </ItemTemplate>

                                                                                        </asp:TemplateField>

                                                                                        <asp:TemplateField HeaderText="Processing Code2" ItemStyle-Width="31.66%" ItemStyle-CssClass="pl-2 text-xs leading-none py-3 px-2 text-gray-800 w-5 relative" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left">

                                                                                            <ItemTemplate>

                                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" placeholder="Voyage Duration" ID="TextBox2" MaxLength="35" runat="server" TabIndex="181" CssClass="px-3 w-[180px] h-8 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium relative focus:outline-none" Style="width: 100%;"></asp:TextBox>

                                                                                            </ItemTemplate>

                                                                                        </asp:TemplateField>

                                                                                        <asp:TemplateField HeaderText="Processing Code3" ItemStyle-Width="31.66%" ItemStyle-CssClass="pl-2 text-xs leading-none py-3 px-2 text-gray-800 w-5 relative" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left">

                                                                                            <ItemTemplate>

                                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox3" placeholder="Processing Code3" MaxLength="35" runat="server" TabIndex="182" CssClass="px-3 w-[180px] h-8 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium relative focus:outline-none" Style="width: 100%;"></asp:TextBox>

                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TextBox3" ID="aeopc" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35characters allowed." ValidationGroup="cpc"></asp:RegularExpressionValidator>

                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>

                                                                                        <asp:TemplateField HeaderText="Delete" ItemStyle-Width="5%">
                                                                                            <ItemTemplate>
                                                                                                <!-- Simplified delete button with direct server-side click -->
                                                                                                <asp:LinkButton ID="imgDelete" runat="server"
                                                                                                    CommandName="DeleteRow"
                                                                                                    CommandArgument='<%# Container.DataItemIndex %>'
                                                                                                    OnClientClick="deleteRowClientSide(this); return false;"
                                                                                                    CssClass="text-danger">
                                                <i class='fa fa-trash' style="color:red"></i>
                                                                                                </asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>

                                                                                    </Columns>

                                                                                </asp:GridView>
                                                                            </div>

                                                                            <div class="processingCode_right_section">
                                                                                <asp:Button ID="btnSeaStr" CssClass="text-sm text-[#0560FD] sa700 cursor-pointer" runat="server" OnClick="btnSeaStr_Click" Text=" Add Processing Codes" TabIndex="179" />
                                                                            </div>
                                                                        </div>

                                                                    </div>
                                                                </div>
                                                            </div>



                                                        </div>
                                                        <hr />

                                                        <div class="row">
                                                            <div class="col-sm-12">

                                                                <asp:CheckBox ID="chkcnb" AutoPostBack="true" runat="server" TabIndex="178" Checked="false" Style="text-transform: uppercase" />
                                                                <label for="chkaeo" class="text-gray-500 text-sm font-medium">CNB</label>
                                                            </div>
                                                        </div>
                                                        <hr />

                                                        <div class="row">
                                                            <div class="col-sm-12">

                                                                <asp:CheckBox ID="Chkscheme1" OnCheckedChanged="Chkscheme_CheckedChanged" AutoPostBack="true" runat="server" TabIndex="178" Checked="false" Style="text-transform: uppercase" />
                                                                <label for="chkaeo" class="text-gray-500 text-sm font-medium">Scheme</label>
                                                            </div>
                                                            <div class="clearfix"></div>
                                                            <div class="table-responsive">
                                                                <div class="flex processingCode_outer">
                                                                    <div class="flex processingCode">
                                                                        <div class="processingCode_left_section" id="SCHEME" runat="server" visible="false">
                                                                            <div class="table-responsive">
                                                                                <asp:GridView ID="SchemeGrid" OnRowDeleting="SchemeGrid_RowDeleting" FooterStyle-CssClass="w-full h-10 py-4 px-10 bg-[#F4F6FA] rounded-lg" CssClass="w-full bg-white rounded whitespace-nowrap" HeaderStyle-CssClass="w-full h-10 py-4 px-10 bg-[#F4F6FA] rounded-l-lg" PagerStyle-CssClass="pager" RowStyle-CssClass="rows" runat="server" ShowFooter="true" AutoGenerateColumns="false">
                                                                                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                    <Columns>

                                                                                        <asp:BoundField DataField="RowNumber" HeaderText="Seq." ItemStyle-Width="5%" />

                                                                                        <asp:TemplateField HeaderText="Processing Code1" ItemStyle-CssClass="pl-2 text-xs leading-none py-3 px-2 text-gray-800 w-5 relative" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left" ItemStyle-Width="31.66%">

                                                                                            <ItemTemplate>

                                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Processing Code1" autocomplete="off" ID="TextBox1" MaxLength="35" runat="server" TabIndex="180" CssClass="mr-4 px-3 w-[150px] h-8 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium relative focus:outline-none" Style="width: 100%;"></asp:TextBox>

                                                                                            </ItemTemplate>

                                                                                        </asp:TemplateField>

                                                                                        <asp:TemplateField HeaderText="Processing Code2" ItemStyle-CssClass="pl-2 text-xs leading-none py-3 px-2 text-gray-800 w-5 relative" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left" ItemStyle-Width="31.66%">

                                                                                            <ItemTemplate>

                                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" placeholder="Processing Code2" ID="TextBox2" MaxLength="35" runat="server" TabIndex="181" CssClass="px-3 w-[180px] h-8 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium relative focus:outline-none" Style="width: 100%;"></asp:TextBox>

                                                                                            </ItemTemplate>

                                                                                        </asp:TemplateField>

                                                                                        <asp:TemplateField HeaderText="Processing Code3" ItemStyle-CssClass="pl-2 text-xs leading-none py-3 px-2 text-gray-800 w-5 relative" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left" ItemStyle-Width="31.66%">

                                                                                            <ItemTemplate>

                                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox3" placeholder="Processing Code3" MaxLength="35" runat="server" TabIndex="182" CssClass="px-3 w-[180px] h-8 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium relative focus:outline-none" Style="width: 100%;"></asp:TextBox>

                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>

                                                                                        <asp:TemplateField HeaderText="Delete" ItemStyle-Width="5%">
                                                                                            <ItemTemplate>
                                                                                                <!-- Simplified delete button with direct server-side click -->
                                                                                                <asp:LinkButton ID="imgDelete" runat="server"
                                                                                                    CommandName="DeleteRow"
                                                                                                    CommandArgument='<%# Container.DataItemIndex %>'
                                                                                                    OnClientClick="deleteRowClientSide(this); return false;"
                                                                                                    CssClass="text-danger">
                                    <i class='fa fa-trash' style="color:red"></i>
                                                                                                </asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>

                                                                                </asp:GridView>
                                                                            </div>

                                                                            <div class="processingCode_right_section">
                                                                                <asp:Button ID="btnSchemeStr" CssClass="text-sm text-[#0560FD] sa700 cursor-pointer" runat="server" OnClick="btnSchemeStr_Click" Text=" Add Processing Codes" TabIndex="179" />
                                                                            </div>
                                                                        </div>

                                                                    </div>
                                                                </div>
                                                            </div>



                                                        </div>
                                                        <hr />

                                                        <div class="row">
                                                            <div class="col-sm-12">

                                                                <asp:CheckBox ID="Chksts1" OnCheckedChanged="Chksts_CheckedChanged" AutoPostBack="true" runat="server" TabIndex="178" Checked="false" Style="text-transform: uppercase" />
                                                                <label for="chkaeo" class="text-gray-500 text-sm font-medium">STS</label>
                                                            </div>
                                                            <div class="clearfix"></div>
                                                            <div class="table-responsive">
                                                                <div class="flex processingCode_outer">
                                                                    <div class="flex processingCode">
                                                                        <div class="processingCode_left_section" id="STS" runat="server" visible="false">
                                                                            <div class="table-responsive">
                                                                                <asp:GridView ID="StsGrid" OnRowDeleting="StsGrid_RowDeleting" FooterStyle-CssClass="w-full h-10 py-4 px-10 bg-[#F4F6FA] rounded-lg" CssClass="w-full bg-white rounded whitespace-nowrap" HeaderStyle-CssClass="w-full h-10 py-4 px-10 bg-[#F4F6FA] rounded-l-lg" PagerStyle-CssClass="pager" RowStyle-CssClass="rows" runat="server" ShowFooter="true" AutoGenerateColumns="false">
                                                                                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                    <Columns>

                                                                                        <asp:BoundField DataField="RowNumber" HeaderText="Seq." ItemStyle-Width="5%" />

                                                                                        <asp:TemplateField HeaderText="Processing Code1" ItemStyle-CssClass="pl-2 text-xs leading-none py-3 px-2 text-gray-800 w-5 relative" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left" ItemStyle-Width="31.66%">

                                                                                            <ItemTemplate>

                                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Processing Code1" autocomplete="off" ID="TextBox1" MaxLength="35" runat="server" TabIndex="180" CssClass="mr-4 px-3 w-[150px] h-8 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium relative focus:outline-none" Style="width: 100%;"></asp:TextBox>

                                                                                            </ItemTemplate>

                                                                                        </asp:TemplateField>

                                                                                        <asp:TemplateField HeaderText="Processing Code2" ItemStyle-CssClass="pl-2 text-xs leading-none py-3 px-2 text-gray-800 w-5 relative" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left" ItemStyle-Width="31.66%">

                                                                                            <ItemTemplate>

                                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" placeholder="Processing Code2" ID="TextBox2" MaxLength="35" runat="server" TabIndex="181" CssClass="px-3 w-[180px] h-8 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium relative focus:outline-none" Style="width: 100%;"></asp:TextBox>

                                                                                            </ItemTemplate>

                                                                                        </asp:TemplateField>

                                                                                        <asp:TemplateField HeaderText="Processing Code3" ItemStyle-CssClass="pl-2 text-xs leading-none py-3 px-2 text-gray-800 w-5 relative" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left" ItemStyle-Width="31.66%">

                                                                                            <ItemTemplate>

                                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox3" placeholder="Processing Code3" MaxLength="35" runat="server" TabIndex="182" CssClass="px-3 w-[180px] h-8 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium relative focus:outline-none" Style="width: 100%;"></asp:TextBox>

                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>


                                                                                        <asp:TemplateField HeaderText="Delete" ItemStyle-Width="5%">
                                                                                            <ItemTemplate>
                                                                                                <!-- Simplified delete button with direct server-side click -->
                                                                                                <asp:LinkButton ID="imgDelete" runat="server"
                                                                                                    CommandName="DeleteRow"
                                                                                                    CommandArgument='<%# Container.DataItemIndex %>'
                                                                                                    OnClientClick="deleteRowClientSide(this); return false;"
                                                                                                    CssClass="text-danger">
                                    <i class='fa fa-trash' style="color:red"></i>
                                                                                                </asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>

                                                                                    </Columns>

                                                                                </asp:GridView>
                                                                            </div>


                                                                            <div class="processingCode_right_section">
                                                                                <asp:Button ID="btnStsStr" CssClass="text-sm text-[#0560FD] sa700 cursor-pointer" runat="server" OnClick="btnStsStr_Click" Text=" Add Processing Codes " TabIndex="179" />

                                                                            </div>
                                                                        </div>

                                                                    </div>
                                                                </div>
                                                            </div>



                                                        </div>

                                                        <hr />


                                                        <div class="row">
                                                            <div class="col-sm-12">

                                                                <asp:CheckBox ID="Chkstscwc1" OnCheckedChanged="Chkstscwc_CheckedChanged" AutoPostBack="true" runat="server" TabIndex="178" Checked="false" Style="text-transform: uppercase" />
                                                                <label for="chkaeo" class="text-gray-500 text-sm font-medium">STS AND CWC</label>
                                                            </div>
                                                            <div class="clearfix"></div>
                                                            <div class="table-responsive">
                                                                <div class="flex processingCode_outer">
                                                                    <div class="flex processingCode">
                                                                        <div class="processingCode_left_section" id="STSANDCWS" runat="server" visible="false">
                                                                            <div class="table-responsive">
                                                                                <asp:GridView ID="StscwcGrid" OnRowDeleting="StscwcGrid_RowDeleting" FooterStyle-CssClass="w-full h-10 py-4 px-10 bg-[#F4F6FA] rounded-lg" CssClass="w-full bg-white rounded whitespace-nowrap" HeaderStyle-CssClass="w-full h-10 py-4 px-10 bg-[#F4F6FA] rounded-l-lg" PagerStyle-CssClass="pager" RowStyle-CssClass="rows" runat="server" ShowFooter="true" AutoGenerateColumns="false">
                                                                                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                    <Columns>

                                                                                        <asp:BoundField DataField="RowNumber" HeaderText="Seq." ItemStyle-Width="5%" />

                                                                                        <asp:TemplateField HeaderText="Processing Code1" ItemStyle-CssClass="pl-2 text-xs leading-none py-3 px-2 text-gray-800 w-5 relative" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left" ItemStyle-Width="31.66%">

                                                                                            <ItemTemplate>

                                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Processing Code1" autocomplete="off" ID="TextBox1" MaxLength="35" runat="server" TabIndex="180" CssClass="mr-4 px-3 w-[150px] h-8 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium relative focus:outline-none" Style="width: 100%;"></asp:TextBox>

                                                                                            </ItemTemplate>

                                                                                        </asp:TemplateField>

                                                                                        <asp:TemplateField HeaderText="Processing Code2" ItemStyle-CssClass="pl-2 text-xs leading-none py-3 px-2 text-gray-800 w-5 relative" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left" ItemStyle-Width="31.66%">

                                                                                            <ItemTemplate>

                                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" placeholder="Processing Code2" ID="TextBox2" MaxLength="35" runat="server" TabIndex="181" CssClass="px-3 w-[180px] h-8 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium relative focus:outline-none" Style="width: 100%;"></asp:TextBox>

                                                                                            </ItemTemplate>

                                                                                        </asp:TemplateField>

                                                                                        <asp:TemplateField HeaderText="Processing Code3" ItemStyle-CssClass="pl-2 text-xs leading-none py-3 px-2 text-gray-800 w-5 relative" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left" ItemStyle-Width="31.66%">

                                                                                            <ItemTemplate>

                                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox3" placeholder="Processing Code3" MaxLength="35" runat="server" TabIndex="182" CssClass="px-3 w-[180px] h-8 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium relative focus:outline-none" Style="width: 100%;"></asp:TextBox>

                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>

                                                                                        <asp:TemplateField HeaderText="Delete" ItemStyle-Width="5%">
                                                                                            <ItemTemplate>
                                                                                                <!-- Simplified delete button with direct server-side click -->
                                                                                                <asp:LinkButton ID="imgDelete" runat="server"
                                                                                                    CommandName="DeleteRow"
                                                                                                    CommandArgument='<%# Container.DataItemIndex %>'
                                                                                                    OnClientClick="deleteRowClientSide(this); return false;"
                                                                                                    CssClass="text-danger">
                                    <i class='fa fa-trash' style="color:red"></i>
                                                                                                </asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>

                                                                                </asp:GridView>
                                                                            </div>


                                                                            <div class="processingCode_right_section">
                                                                                <asp:Button ID="btnStscwcStr" CssClass="text-sm text-[#0560FD] sa700 cursor-pointer" runat="server" OnClick="btnStscwcStr_Click" Text=" Add Processing Codes" TabIndex="179" />


                                                                            </div>
                                                                        </div>

                                                                    </div>
                                                                </div>
                                                            </div>



                                                        </div>

                                                        <hr />


                                                        <div class="row">
                                                            <div class="col-sm-12">

                                                                <asp:CheckBox ID="Chkic1" OnCheckedChanged="Chkic_CheckedChanged" AutoPostBack="true" runat="server" TabIndex="178" Checked="false" Style="text-transform: uppercase" />
                                                                <label for="chkaeo" class="text-gray-500 text-sm font-medium">INTERNATIONAL CONNECTIVITY</label>
                                                            </div>
                                                            <div class="clearfix"></div>
                                                            <div class="table-responsive">
                                                                <div class="flex processingCode_outer">
                                                                    <div class="flex processingCode">
                                                                        <div class="processingCode_left_section" id="IC" runat="server" visible="false">
                                                                            <div class="table-responsive">
                                                                                <asp:GridView ID="IcGrid" OnRowDeleting="IcGrid_RowDeleting" FooterStyle-CssClass="w-full h-10 py-4 px-10 bg-[#F4F6FA] rounded-lg" CssClass="w-full bg-white rounded whitespace-nowrap" HeaderStyle-CssClass="w-full h-10 py-4 px-10 bg-[#F4F6FA] rounded-l-lg" PagerStyle-CssClass="pager" RowStyle-CssClass="rows" runat="server" ShowFooter="true" AutoGenerateColumns="false">
                                                                                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                    <Columns>

                                                                                        <asp:BoundField DataField="RowNumber" HeaderText="Seq." ItemStyle-Width="5%" />

                                                                                        <asp:TemplateField HeaderText="Processing Code1" ItemStyle-CssClass="pl-2 text-xs leading-none py-3 px-2 text-gray-800 w-5 relative" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left" ItemStyle-Width="31.66%">

                                                                                            <ItemTemplate>

                                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Processing Code1" autocomplete="off" ID="TextBox1" MaxLength="35" runat="server" TabIndex="180" CssClass="mr-4 px-3 w-[150px] h-8 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium relative focus:outline-none" Style="width: 100%;"></asp:TextBox>

                                                                                            </ItemTemplate>

                                                                                        </asp:TemplateField>

                                                                                        <asp:TemplateField HeaderText="Processing Code2" ItemStyle-CssClass="pl-2 text-xs leading-none py-3 px-2 text-gray-800 w-5 relative" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left" ItemStyle-Width="31.66%">

                                                                                            <ItemTemplate>

                                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" placeholder="Processing Code2" ID="TextBox2" MaxLength="35" runat="server" TabIndex="181" CssClass="px-3 w-[180px] h-8 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium relative focus:outline-none" Style="width: 100%;"></asp:TextBox>

                                                                                            </ItemTemplate>

                                                                                        </asp:TemplateField>

                                                                                        <asp:TemplateField HeaderText="Processing Code3" ItemStyle-CssClass="pl-2 text-xs leading-none py-3 px-2 text-gray-800 w-5 relative" HeaderStyle-CssClass="text-sm font-medium leading-none text-gray-500 px-2 text-left" ItemStyle-Width="31.66%">

                                                                                            <ItemTemplate>

                                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox3" placeholder="Processing Code3" MaxLength="35" runat="server" TabIndex="182" CssClass="px-3 w-[180px] h-8 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium relative focus:outline-none" Style="width: 100%;"></asp:TextBox>

                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>

                                                                                        <asp:TemplateField HeaderText="Delete" ItemStyle-Width="5%">
                                                                                            <ItemTemplate>
                                                                                                <!-- Simplified delete button with direct server-side click -->
                                                                                                <asp:LinkButton ID="imgDelete" runat="server"
                                                                                                    CommandName="DeleteRow"
                                                                                                    CommandArgument='<%# Container.DataItemIndex %>'
                                                                                                    OnClientClick="deleteRowClientSide(this); return false;"
                                                                                                    CssClass="text-danger">
                                    <i class='fa fa-trash' style="color:red"></i>
                                                                                                </asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>

                                                                                    </Columns>

                                                                                </asp:GridView>
                                                                            </div>


                                                                            <div class="processingCode_right_section">
                                                                                <asp:Button ID="btnIcStr" CssClass="text-sm text-[#0560FD] sa700 cursor-pointer" runat="server" OnClick="btnIcStr_Click" Text=" Add Processing Codes " TabIndex="179" />

                                                                            </div>
                                                                        </div>

                                                                    </div>
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
                                    <cc1:TabPanel ID="Summery" runat="server" HeaderText="Summary">
                                        <ContentTemplate>
                                            <asp:UpdatePanel ID="upinsummary" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>

                                                    <asp:ValidationSummary ID="ValidationSummary11" runat="server" ShowMessageBox="True"
                                                        ShowSummary="False" ValidationGroup="Summery" />


                                                    <div class="flex justify-between gap-2 items-center mt-7">
                                                        <h2 class="text-lg sa700 leading-[18px] text-gray-800">Summary
                                                        </h2>
                                                        <div class="md:max-w-[250px] flex justify-end w-full md:mt-5">
                                                            <div class="flex gap-2 items-center">
                                                                <%--<input class="styled-checkbox-1" id="styled-checkbox-86" type="checkbox" value="value1">--%>
                                                                <asp:CheckBox ID="chkAuto" Enabled="true" AutoPostBack="true" TabIndex="193" OnCheckedChanged="chkAuto_CheckedChanged" runat="server" CssClass="text-gray-500 text-sm" />
                                                                <label class="text-gray-500 text-sm font-medium">Auto Complete</label>

                                                            </div>
                                                        </div>
                                                    </div>


                                                    <div class="grid grid-cols-1 md:grid-cols-3 gap-6 mt-4 mb-2">

                                                        <!-- Left Column -->
                                                        <div class="space-y-4">

                                                            <div class="w-full mt-2">
                                                                <div class="flex flex-col md:flex-row items-start md:items-center gap-2">
                                                                    <label class="text-gray-500 text-sm font-medium md:w-[117px] w-full mt-1">Number of Invoices</label>
                                                                    <div class="w-full w-[200px]">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Type" autocomplete="off" runat="server" Enabled="false" Text="0.00" type="text" ID="txtnoofinv" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="w-full mt-2">
                                                                <div class="flex flex-col md:flex-row items-start md:items-center gap-2">
                                                                    <!-- Label on Left -->
                                                                    <label class="text-gray-500 text-sm font-medium md:w-[117px] w-full mt-1">
                                                                        Number of Items
                                                                    </label>

                                                                    <!-- Disabled Input on Right -->
                                                                    <div class="w-full w-[200px]">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Type" autocomplete="off" runat="server" Enabled="false"
                                                                            Text="0.00" type="text" ID="TextBox7"
                                                                            CssClass="w-full h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                        </asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="w-full mt-2">
                                                                <div class="flex flex-col md:flex-row items-start md:items-center gap-2">
                                                                    <!-- Label on Left -->
                                                                    <label class="text-gray-500 text-sm font-medium md:w-[117px] w-full mt-1">
                                                                        Total Invoice CIF Value
                                                                    </label>

                                                                    <!-- Disabled TextBox on Right -->
                                                                    <div class="w-full w-[200px]">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="CIF Value" autocomplete="off" runat="server" Enabled="false"
                                                                            Text="0.00" CssClass="w-full h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium outline-none border-none px-4"
                                                                            type="text" ID="txtcifVal">
                                                                        </asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="w-full mt-2">
                                                                <div class="flex flex-col md:flex-row items-start md:items-center gap-2">
                                                                    <label class="text-gray-500 text-sm font-medium md:w-[117px] w-full mt-1">Total Custom Duty Amount</label>
                                                                    <div class="w-full w-[200px]">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Total Custom Duty" autocomplete="off" runat="server" Enabled="false" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" type="text" ID="txtcusdutyAmt"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>


                                                            <div class="w-full">
                                                                <label class="text-gray-500 text-sm font-medium">Sum of Item Amount</label>
                                                                <div class="relative mt-1">
                                                                    <div id="div6" style="color: red;" runat="server"></div>
                                                                    <asp:Label ID="Label1" Visible="false" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server" Text="0.00"></asp:Label>
                                                                </div>
                                                            </div>

                                                        </div>

                                                        <div class="space-y-4">



                                                            <div class="w-full mt-2">
                                                                <div class="flex flex-col md:flex-row items-start md:items-center gap-2">
                                                                    <label class="text-gray-500 text-sm font-medium md:w-[117px] w-full mt-1">Total CIF/FOB Value</label>
                                                                    <div class="w-full w-[200px]">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Total CIF/FOB Value" autocomplete="off" runat="server" Enabled="false" Text="0.00" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" ID="txtfobval"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="w-full mt-2">
                                                                <div class="flex flex-col md:flex-row items-start md:items-center gap-2">
                                                                    <!-- Label on Left -->
                                                                    <label class="text-gray-500 text-sm font-medium md:w-[117px] w-full mt-1">
                                                                        Number of Items
                                                                    </label>

                                                                    <!-- Disabled TextBox on Right -->
                                                                    <div class="w-full w-[200px]">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Type" autocomplete="off" runat="server" Enabled="false"
                                                                            Text="0.00" type="text" ID="txtnoofitm"
                                                                            CssClass="w-full h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                        </asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="w-full mt-2">
                                                                <div class="flex flex-col md:flex-row items-start md:items-center gap-2">
                                                                    <label class="text-gray-500 text-sm font-medium md:w-[117px] w-full mt-1">Total GST Amount</label>
                                                                    <div class="w-full w-[200px]">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Total GST Amount" autocomplete="off" runat="server" Enabled="false" Text="0.00" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" ID="txttotgstAmt"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="w-full mt-2">
                                                                <div class="flex flex-col md:flex-row items-start md:items-center gap-2">
                                                                    <label class="text-gray-500 text-sm font-medium md:w-[117px] w-full mt-1">Total Other Tax Amount</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Total Other Tax" autocomplete="off" runat="server" Enabled="false" Text="0.00" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" type="text" ID="txtothtaxAmt"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                        </div>

                                                        <div class="space-y-4">
                                                            <div class="w-full mt-2">
                                                                <div class="flex flex-col md:flex-row items-start md:items-center gap-2">
                                                                    <!-- Label on Left -->
                                                                    <label class="text-gray-500 text-sm font-medium md:w-[117px] w-full mt-1">
                                                                        Sum of Item Amount
                                                                    </label>

                                                                    <!-- Disabled TextBox on Right -->
                                                                    <div class="w-full w-[200px]">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Sum of Item" autocomplete="off" runat="server" Enabled="false"
                                                                            Text="0.00" CssClass="w-full h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium outline-none border-none px-4"
                                                                            type="text" ID="txtitmAmt">
                                                                        </asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="w-full mt-2">
                                                                <div class="flex flex-col md:flex-row items-start md:items-center gap-2">
                                                                    <label class="text-gray-500 text-sm font-medium md:w-[117px] w-full mt-1">Total Excise Duty Amount</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Total Excise Duty" autocomplete="off" runat="server" Enabled="false" Text="0.00" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" type="text" ID="txttotexAmt"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="w-full mt-2">
                                                                <div class="flex flex-col md:flex-row items-start md:items-center gap-2">
                                                                    <label class="text-gray-500 text-sm font-medium md:w-[117px] w-full mt-1">Total Amount Payable</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Total Payable Amount" autocomplete="off" runat="server" Text="0.00" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" ID="txtAmtPayble"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>


                                                            <div class="w-full">
                                                                <label class="text-gray-500 text-sm font-medium">Sum of Invoice Amount</label>
                                                                <div class="relative mt-1">
                                                                    <div id="div3" class="invoice_div" style="color: red;" runat="server"></div>


                                                                    <asp:Label ID="lbltotinvAmt" Visible="false" runat="server" Text="0.00" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:Label>

                                                                </div>
                                                            </div>



                                                        </div>
                                                    </div>


                                                    <div class="mt-4 flex justify-between items-end gap-4 flex-wrap mb-2">
                                                    </div>


                                                    <h2 class="text-lg sa700 leading-[18px] text-gray-800 mt-6">Remarks</h2>

                                                    <div class="row">
                                                        <div class="col-sm-12">
                                                        </div>
                                                    </div>


                                                    <div class="flex flex-wrap md:flex-nowrap gap-6 mt-4 mb-2">

                                                        <!-- Remarks Text -->
                                                        <div class="flex items-center w-full md:w-1/3">
                                                            <p class="text-sm text-gray-700 font-medium">Trader's Remarks (will be Submitted to Singapore Customs)</p>
                                                        </div>

                                                        <!-- Append Invoice Number Button -->
                                                        <div class="w-full md:w-1/3">
                                                            <asp:Button ID="btninvnum" CssClass="relative mt-1 w-full h-10 bg-[#0560FD] bg-opacity-5 rounded-md flex items-center text-[#0560FD] text-sm font-medium outline-none border-none sa700 px-4" TabIndex="195" runat="server" OnClick="btninvnum_Click" Text="Append Invoice NO" />
                                                        </div>

                                                        <div class="w-full md:w-1/3">
                                                            <asp:Button ID="BtnPPN" OnClick="BtnPPN_Click" CssClass="relative mt-1 w-full h-10 bg-[#0560FD] bg-opacity-5 rounded-md flex items-center text-[#0560FD] text-sm font-medium outline-none border-none sa700 px-4" TabIndex="195" runat="server" Text="Append Previous Permit NO" />
                                                        </div>

                                                        <!-- Append Exchange Rate Button -->
                                                        <div class="w-full md:w-1/3">
                                                            <asp:Button CssClass="relative mt-1 w-full h-10 bg-[#0560FD] bg-opacity-5 rounded-md flex items-center text-[#0560FD] text-sm font-medium outline-none border-none sa700 px-4" ID="Button5" TabIndex="196" OnClick="Button3_Click" runat="server" Text="Append Exchange Rate" />
                                                        </div>

                                                        <div class="w-full md:w-1/3" style="margin-top: -13px">
                                                            <label class="text-gray-500 text-sm font-medium">Cross Reference</label>
                                                            <div class="relative mt-1">
                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="TxtGrossReference" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txttrdremrk" ID="RegularExpressionValidator16" ValidationExpression="^[\s\S]{0,1024}$" runat="server" ErrorMessage="Maximum 1024 characters allowed." ValidationGroup="Summery"></asp:RegularExpressionValidator>


                                                            </div>
                                                        </div>



                                                    </div>

                                                    <div class="row mt-4">
                                                        <div class="col-sm-12">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txttrdremrk" ValidationGroup="Summery" runat="server" TextMode="MultiLine" MaxLength="1024" AutoPostBack="true" OnTextChanged="txttrdremrk_TextChanged" TabIndex="197" Height="70" Width="100%" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            <asp:Label ID="lbltracunt" ForeColor="Navy" runat="server"></asp:Label>
                                                        </div>

                                                    </div>

                                                    <div class="w-full mt-3">
                                                        <label class="text-gray-500 text-sm font-medium">Internal Reference</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txtintremrk" runat="server" TabIndex="198" Width="100%" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" Style="text-transform: uppercase"></asp:TextBox>
                                                        </div>
                                                    </div>


                                                    <div class="w-full mt-3">
                                                        <label class="text-gray-500 text-sm font-medium">Customer Remarks(will Not be Submitted to Singapore Customs)</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txtcusRemrk" runat="server" TabIndex="198" TextMode="MultiLine" Height="70" Width="100%" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" Style="text-transform: uppercase"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <%--                                                                                                      <div class="row mt-3">
                                                      <div class="col-sm-12">
                                                           <div class="form-group row">
    <label for="staticEmail" class="col-sm-6 col-form-label">
    </label>
    <div class="col-sm-6">
        <p id="cusremarks" runat="server" visible="true"></p>
        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txtcusRemrk" Visible="true" TabIndex="194" runat="server" TextMode="MultiLine" Height="70" Width="100%"></asp:TextBox>
    </div>

</div>
                                                      </div>
                                                  </div>--%>




                                                    <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-6">
                                                        <span class="text-white text-sm font-semibold tracking-wide">DECLARATION SUMMARY</span>
                                                        <asp:Label ID="Label5" Visible="false" runat="server"></asp:Label>
                                                    </div>


                                                    <div class="flex flex-wrap md:flex-nowrap gap-6 mt-4 mb-2">

                                                        <!-- Left Column -->
                                                        <div class=" space-y-5 w-[534px]">
                                                            <div>
                                                                <label class="text-gray-500 text-sm font-medium">IMPORTER NAME AND UEN </label>
                                                                <div>
                                                                    <asp:Label ID="lblimporterparty" runat="server" CssClass="text-slate-950 text-base sa700 mt-2"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div>
                                                                <label class="text-gray-500 text-sm font-medium">INWARD HAWB/HBL </label>
                                                                <div>
                                                                    <asp:Label ID="lblhblValue" runat="server" CssClass="text-slate-950 text-base sa700 mt-2"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div>
                                                                <label class="text-gray-500 text-sm font-medium">INWARD MAWB/MBL/OBL</label>
                                                                <div>
                                                                    <asp:Label ID="lbloblval" runat="server" Text="" CssClass="text-slate-950 text-base sa700 mt-2"></asp:Label>
                                                                </div>
                                                            </div>


                                                            <div>
                                                                <label class="text-gray-500 text-sm font-medium">INWARD TRANSPORT MODE</label>
                                                                <div>
                                                                    <asp:Label ID="lbltransmode" runat="server" CssClass="text-slate-950 text-base sa700 mt-2"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div>
                                                                <label class="text-gray-500 text-sm font-medium">TERM TYPE</label>
                                                                <div>

                                                                    <div id="div9" class="invoice_div" style="color: red;" runat="server"></div>

                                                                    <asp:Label ID="lbltermtype" runat="server" CssClass="text-slate-950 text-base sa700 mt-2"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <!-- Right Column -->
                                                        <div class=" space-y-5">


                                                            <div>
                                                                <label class="text-gray-500 text-sm font-medium">TOTAL OUTER PACK</label>
                                                                <div>
                                                                    <asp:Label ID="lblnoofpack" runat="server" CssClass="text-slate-950 text-base sa700 mt-2"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div>
                                                                <label class="text-gray-500 text-sm font-medium">TOTAL PERMIT GROSS WEIGHT</label>
                                                                <div>
                                                                    <asp:Label ID="lblttlpermitgw" runat="server" Text="" CssClass="text-slate-950 text-base sa700 mt-2"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div style="display: none">
                                                                <label class="text-gray-500 text-sm font-medium">TOTAL GROSS WEIGHT</label>
                                                                <div>
                                                                    <asp:Label ID="lblgrossweight" runat="server" Text="" CssClass="text-slate-950 text-base sa700 mt-2"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div>
                                                                <label class="text-gray-500 text-sm font-medium">TOTAL INVOICE AMOUNT (CUR)</label>
                                                                <div>
                                                                    <asp:Label ID="lblinvoiceAmt" runat="server" CssClass="text-slate-950 text-base sa700 mt-2"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div>
                                                                <label class="text-gray-500 text-sm font-medium">TOTAL ITEM AMOUNT (CUR)</label>
                                                                <div>
                                                                    <div id="div10" style="color: red;" runat="server"></div>
                                                                </div>
                                                            </div>




                                                            <div>
                                                                <label class="text-gray-500 text-sm font-medium">TOTAL INVOICE GST</label>
                                                                <div>
                                                                    <asp:Label ID="lblTotINVGst" runat="server" class="text-slate-950 text-base sa700 mt-2"></asp:Label>

                                                                </div>
                                                            </div>



                                                            <div>
                                                                <label class="text-gray-500 text-sm font-medium">TOTAL ITEM GST</label>
                                                                <div>
                                                                    <asp:Label ID="lblTotItemGst" runat="server" class="text-slate-950 text-base sa700 mt-2"></asp:Label>
                                                                    <asp:Label ID="lblerror" runat="server"></asp:Label>
                                                                </div>
                                                            </div>


                                                            <div>
                                                                <label class="text-gray-500 text-sm font-medium">TOTAL AMOUNT PAYABLE (SGD)</label>
                                                                <div>
                                                                    <asp:Label ID="lbltap" runat="server" class="text-slate-950 text-base sa700 mt-2"></asp:Label>

                                                                </div>
                                                            </div>

                                                        </div>

                                                    </div>


                                                    <div class="w-full mt-6" id="DeclInd" runat="server" visible="false" style="background-color: #F2D2D2; padding: 19px;">
                                                        <div class="flex gap-2 items-center">
                                                            <asp:CheckBox ID="chkDeclareInd" runat="server" TabIndex="198" Checked="false" />
                                                            <label for="styled-checkbox-90" class="text-gray-500 text-sm">
                                                                I/We declare that all the particulars in this Application are
                                                              true &amp; correct</label>
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
                                                        <asp:Panel ID="Panelobl" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none;">
                                                            <div class="header">
                                                                <svg class="cursor-pointer absolute right-5 top-5" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                    <circle opacity="0.1" cx="12" cy="12" r="12" fill="#676D7C"></circle>
                                                                    <path d="M16.6663 7.3335L7.33301 16.6668M7.33301 7.3335L16.6663 16.6668" stroke="#676D7C" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                                                </svg>
                                                                <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Declarant Company Search</p>
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
                                    <cc1:TabPanel ID="Amend" runat="server" Visible="false" HeaderText="Amend">
                                        <ContentTemplate>
                                            <asp:UpdatePanel ID="upinamend" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div class="row">
                                                        <div class="col-sm-12">
                                                            <div class="row " style="width: 100%">
                                                                <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-6">
                                                                    <span class="text-white text-sm font-semibold tracking-wide">Update Information</span>
                                                                </div>

                                                            </div>

                                                            <div class="row">
                                                                <div class="col-sm-6">
                                                                    <p>Amendment Count</p>
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" Width="300" type="text" Text="1" Enabled="false" ID="txtamoundcount" TabIndex="202"></asp:TextBox>
                                                                    <br />
                                                                    <p>Update Indicator</p>
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" Width="300" Text="AME" type="text" ID="txtupdateindicator" TabIndex="203" Style="text-transform: uppercase"></asp:TextBox>
                                                                    <br />
                                                                </div>
                                                                <div class="col-sm-6">
                                                                    <p>Permit Number</p>
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" Width="300" type="text" ID="txtamendpermit" TabIndex="204" Style="text-transform: uppercase"></asp:TextBox>
                                                                    <br />
                                                                    <p>Replacement Permit Number</p>
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" Width="300" type="text" ID="txtreplacepermit" TabIndex="205" Style="text-transform: uppercase"></asp:TextBox>
                                                                    <br />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="row">
                                                        <div class="col-sm-12">
                                                            <div class="row " style="width: 100%">
                                                                <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-6">
                                                                    <span class="text-white text-sm font-semibold tracking-wide">Amendment Information</span>
                                                                </div>

                                                            </div>


                                                            <p>Description Of Reason</p>
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" TextMode="MultiLine" Width="100%" type="text" ID="txtdescreason" TabIndex="206" Style="text-transform: uppercase"></asp:TextBox>
                                                            <br />
                                                            <asp:CheckBox ID="ChkPermitvalEx" runat="server" TabIndex="207" Text="Permit Validity Extension" Style="text-transform: lowercase" />
                                                            <br />
                                                            <p>Extend Import Period (Reason for Extension of validity for Temporary / Exhibit Cargoes)</p>
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" TextMode="MultiLine" Width="100%" type="text" ID="txtvalidity" TabIndex="208" Style="text-transform: uppercase"></asp:TextBox>
                                                            <br />
                                                            <br />


                                                            <div class="row " style="width: 100%">
                                                                <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-6">
                                                                    <span class="text-white text-sm font-semibold tracking-wide">Declaration Indicator</span>
                                                                </div>

                                                            </div>



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
                                                                    <asp:Button ID="Button7" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" runat="server" class="btn btn-info btn-lg" OnClick="btnprevsum_Click" Text="Previous" TabIndex="210" Visible="false" />


                                                                    <asp:Button ID="Button8" CssClass="btn duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" runat="server" class="btn btn-info btn-lg" OnClick="btnsavesum_Click" Text="Save" TabIndex="211" />

                                                                    <asp:Button ID="Button10" CssClass="nn" runat="server" class="btn btn-info btn-lg" OnClick="btnnextsum_Click" Text="Next" TabIndex="212" Visible="false" />
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
                                    <cc1:TabPanel ID="cancel" runat="server" Visible="false" HeaderText="cancel">
                                        <ContentTemplate>
                                            <asp:UpdatePanel ID="upincancel" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div class="row">
                                                        <div class="col-sm-12">


                                                            <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-7">
                                                                <span class="text-white text-sm font-semibold tracking-wide">Update Information</span>

                                                            </div>


                                                            <div class="row">
                                                                <div class="col-sm-6">
                                                                    <p>Update Indicator</p>
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" Width="300" type="text" ID="txtupdateInd" TabIndex="213" Style="text-transform: uppercase"></asp:TextBox>
                                                                    <br />

                                                                </div>
                                                                <div class="col-sm-6">
                                                                    <p>Permit Number</p>
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" Width="300" type="text" ID="txtcanPermit" TabIndex="214" Style="text-transform: uppercase"></asp:TextBox>
                                                                    <br />
                                                                    <p>Replacement Permit Number</p>
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" Width="300" type="text" ID="txtcanrepPermit" TabIndex="215" Style="text-transform: uppercase"></asp:TextBox>
                                                                    <br />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="row">
                                                        <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-7">
                                                            <span class="text-white text-sm font-semibold tracking-wide">Cancellation Information</span>

                                                        </div>
                                                        
                                                        <div class="col-sm-6">
                                                            <p>Reason For Cancellation</p>
                                                            <asp:DropDownList CssClass="focus:outline-none bg-slate-100 font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 px-4" ID="DrpReasonCancel" TabIndex="216" Width="300" runat="server"></asp:DropDownList>
                                                        </div>
                                                        <div class="col-sm-6">
                                                            <p>Description For Reason</p>
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" TextMode="MultiLine" Width="100%" type="text" ID="txtdesReason" TabIndex="217" Style="text-transform: uppercase"></asp:TextBox>
                                                            <br />
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="row">
                                                        <div class="col-sm-12" id="Div4" runat="server">
                                                            <div class="row">

                                                                <div class="col-sm-12">

                                                                    <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-7">
                                                                        <span class="text-white text-sm font-semibold tracking-wide">Referance Document</span>

                                                                    </div>

                                                                    <div class="row">
                                                                        <div class="col-sm-5">
                                                                            <p>Document Type</p>
                                                                            <asp:DropDownList CssClass="focus:outline-none bg-slate-100 font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 px-4" ID="DrpDocumenttype" BackColor="#e8f0fe" Width="250" ValidationGroup="valcan" AppendDataBoundItems="true" TabIndex="218" runat="server">
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
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox15" Width="265" runat="server" TabIndex="221" type="text" Style="text-transform: uppercase"></asp:TextBox>

                                                                    <br />
                                                                </div>
                                                                <div class="col-sm-4">
                                                                    <p>RECIPIENTS 2</p>
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox16" Width="265" runat="server" TabIndex="222" type="text" Style="text-transform: uppercase"></asp:TextBox>

                                                                    <br />
                                                                </div>
                                                                <div class="col-sm-4">
                                                                    <p>RECIPIENTS 3</p>
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox17" Width="265" runat="server" TabIndex="223" type="text" Style="text-transform: uppercase"></asp:TextBox>

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

                                                            <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-7">
                                                                <span class="text-white text-sm font-semibold tracking-wide">Declarent Indicator</span>
                                                            </div>


                                                           
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
                                                                    <asp:Button ID="Button11" CssClass="btn duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700"  runat="server" class="btn btn-info btn-lg" OnClick="btnprevsum_Click" Visible="false" Text="Previous" TabIndex="225" />
                                                                    <asp:Button ID="Button12" CssClass="btn duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700"  runat="server" class="btn btn-info btn-lg" OnClick="btnsavesum_Click" Text="Save" TabIndex="226" />

                                                                    <asp:Button ID="Button14" CssClass="btn duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700"  runat="server" class="btn btn-info btn-lg" OnClick="btnnextsum_Click" Text="Next" TabIndex="227" Visible="false" />
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
                                    <cc1:TabPanel ID="Refund" runat="server" Visible="false" HeaderText="Refund">
                                        <ContentTemplate>
                                            <asp:UpdatePanel ID="upinrefund" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div class="row">
                                                        <div class="col-sm-12">

                                                            <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-7">
    <span class="text-white text-sm font-semibold tracking-wide">Update Information</span>
</div>

                                                          
                                                            <div class="row">
                                                                <div class="col-sm-4">
                                                                    <p>Update Indicator</p>
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" Width="300" type="text" ID="txtrenupdInd" TabIndex="228" Style="text-transform: uppercase"></asp:TextBox>
                                                                    <br />
                                                                </div>
                                                                <div class="col-sm-4">
                                                                    <p>Permit Number</p>
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" Width="300" type="text" ID="txtreundper" TabIndex="229" Style="text-transform: uppercase"></asp:TextBox>
                                                                    <br />
                                                                   
                                                                </div>
                                                                 <div class="col-sm-4">
                                                                      <p>Replacement Permit Number</p>
 <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server"  type="text" ID="txtrefundrepper" TabIndex="230" Style="text-transform: uppercase"></asp:TextBox>
 <br />
                                                                 </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="row">
                                                        <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-7">
    <span class="text-white text-sm font-semibold tracking-wide">Refund Information</span>
</div>
                                                       
                                                        <div class="col-sm-6">
                                                            <p>Type For Refund</p>
                                                            <asp:DropDownList  CssClass="focus:outline-none bg-slate-100 font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 px-4" ID="DrpTypeRefund"  TabIndex="231" runat="server"></asp:DropDownList>
                                                            <br />
                                                            <p>Reason For Refund</p>
                                                            <asp:DropDownList  CssClass="focus:outline-none bg-slate-100 font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 px-4" ID="DrpRefundReason" TabIndex="210"  runat="server"></asp:DropDownList>
                                                        </div>
                                                        <div class="col-sm-6">
                                                            <p>Description For Reason</p>
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" TextMode="MultiLine" Width="100%" type="text" ID="txtrefudDes" TabIndex="233" Style="text-transform: uppercase"></asp:TextBox>
                                                            <br />
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="row">
                                                        <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-7">
    <span class="text-white text-sm font-semibold tracking-wide">Refund Information</span>
</div>
                                                      
                                                        <div class="col-sm-6">
                                                            <p>Total GST Refund</p>
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" Width="100%" type="text" ID="txtrefundgstAmt" TabIndex="234" Text="0.00" Style="text-transform: uppercase"></asp:TextBox>
                                                            <br />
                                                            <p>Toatl Excise Duty Refund</p>
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" Width="100%" type="text" ID="txtExciseRefund" TabIndex="235" Text="0.00" Style="text-transform: uppercase"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-6">
                                                            <p>Total Customs Duty Refud</p>
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" Width="100%" type="text" ID="txtCustomsRefund" TabIndex="236" Text="0.00" Style="text-transform: uppercase"></asp:TextBox>
                                                            <br />
                                                            <p>Total Other Tax Refud</p>
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" Width="100%" type="text" ID="txtotherRefund" TabIndex="237" Text="0.00" Style="text-transform: uppercase"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="row" id="itemrefund" runat="server" visible="false">
                                                        <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-7">
    <span class="text-white text-sm font-semibold tracking-wide">Item Refund</span>
</div>
                                                      
                                                        <div class="col-sm-4">
                                                            <p>Item No</p>
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" Width="100%" type="text" ID="txtItemNoRefund" TabIndex="238" Style="text-transform: uppercase"></asp:TextBox>
                                                            <br />
                                                            <p>Hs Code</p>
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" Width="100%" type="text" ID="txthscoderefund" TabIndex="239" Style="text-transform: uppercase"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <p>Total GST Refund</p>
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" Width="100%" type="text" ID="txtitemgstRefud" Text="0.00" TabIndex="240" Style="text-transform: uppercase"></asp:TextBox>
                                                            <br />
                                                            <p>Toatl Excise Duty Refund</p>
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" Width="100%" type="text" ID="txtexciseDutyrefud" Text="0.00" TabIndex="241" Style="text-transform: uppercase"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <p>Total Customs Duty Refud</p>
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" Width="100%" type="text" ID="txttotCusitemamt" Text="0.00" TabIndex="242" Style="text-transform: uppercase"></asp:TextBox>
                                                            <br />
                                                            <p>Total Other Tax Refud</p>
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" Width="100%" type="text" ID="tztotheritem" Text="0.00" TabIndex="243" Style="text-transform: uppercase"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-10">
                                                            <asp:Button ID="AddItem" runat="server" OnClick="AddItem_Click" Text="Add Row" TabIndex="244" />
                                                            <br />
                                                            <br />
                                                            <asp:GridView ID="RefundItem" OnRowDeleting="RefundItem_RowDeleting" OnRowDataBound="RefundItem_RowDataBound" CssClass="table-responsive table table-striped table-bordered table-hover" runat="server" ShowFooter="true" AutoGenerateColumns="false">
                                                                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                <Columns>
                                                                    <asp:BoundField DataField="RowNumber" HeaderText="Seq." Visible="false" />

                                                                    <asp:TemplateField HeaderText="ItemNo">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox1" MaxLength="35" runat="server"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Hs Code">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox2" MaxLength="35" runat="server"></asp:TextBox>
                                                                        </ItemTemplate>

                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Total GST Refund">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox3" MaxLength="35" runat="server" Text="0.00"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Toatl Excise Duty Refund">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox4" MaxLength="35" runat="server" Text="0.00"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Total Customs Duty Refud">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox5" MaxLength="35" runat="server" Text="0.00"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Total Other Tax Refud">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox6" MaxLength="35" runat="server" Text="0.00"></asp:TextBox>
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
                                                                    <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-7">
    <span class="text-white text-sm font-semibold tracking-wide"> Referance Document</span>
</div>


                                                                 
                                                                    <div class="row">
                                                                        <div class="col-sm-5">
                                                                            <p>Document Type</p>
                                                                            <asp:DropDownList  CssClass="focus:outline-none bg-slate-100 font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 px-4" ID="DrprefundDocType" BackColor="#e8f0fe" Width="250" Height="32" AppendDataBoundItems="true" TabIndex="245" runat="server">
                                                                            </asp:DropDownList>
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
                                                            <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-7">
    <span class="text-white text-sm font-semibold tracking-wide"> ADDITIONAL RECIPIENTS</span>
</div>
                                                           
                                                            <br />
                                                            <div class="row">
                                                                <div class="col-sm-4">
                                                                    <p>RECIPIENTS 1</p>
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)"  CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" ID="txtrefaddd1" Width="265" runat="server" TabIndex="248" type="text" Style="text-transform: uppercase"></asp:TextBox>

                                                                </div>
                                                                <div class="col-sm-4">
                                                                    <p>RECIPIENTS 2</p>
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" ID="txtrefadd2" Width="265" runat="server" TabIndex="249" type="text" Style="text-transform: uppercase"></asp:TextBox>
                                                                    <br />
                                                                </div>
                                                                <div class="col-sm-4">
                                                                    <p>RECIPIENTS 3</p>
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" ID="txtrefadd3" Width="265" runat="server" TabIndex="250" type="text" Style="text-transform: uppercase"></asp:TextBox>

                                                                </div>
                                                            </div>

                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-12" id="RefundInd" runat="server" visible="false">

                                                            <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-7">
    <span class="text-white text-sm font-semibold tracking-wide">Declarent Indicator</span>
</div>


                                                          
                                                            <div class="alert alert-danger" id="REFDecl" runat="server">
                                                                <asp:CheckBox ID="ChkRefundInd" runat="server" Checked="false" TabIndex="251" Style="text-transform: lowercase" />
                                                                <strong></strong>I/We declare that all particulars in this application are true and correct
                                                            </div>

                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-3"></div>
                                                        <div class="col-sm-6">
                                                            <center>
                                                                <div class="btn-group btn-group-lg" id="RefundDiv" runat="server" visible="false">
                                                                    <asp:Button ID="Button15"   CssClass="btn duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700"  runat="server" class="btn btn-info btn-lg" OnClick="btnprevsum_Click" Visible="false" Text="Previous" TabIndex="252" />
                                                                    <asp:Button ID="Button16"   CssClass="btn duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700"  runat="server" class="btn btn-info btn-lg" OnClick="btnsavesum_Click" Text="Save" TabIndex="253" />

                                                                    <asp:Button ID="Button18"   CssClass="btn duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700"  runat="server" class="btn btn-info btn-lg" OnClick="btnnextsum_Click" Text="Next" TabIndex="254" Visible="false" />
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

                        <asp:HiddenField ID="hfDeletedIndexes" runat="server" />

                        <script type="text/javascript">
                            document.addEventListener('DOMContentLoaded', function () {
                                function setupValidators() {
                                    var mainErrorDiv = document.getElementById('main_error_div');
                                    var mainErrorMessage = document.getElementById('main_error_message');
                                    var errorCount = 0; // Reset error count

                                    // Select all RegularExpressionValidator elements
                                    var errorValidators = document.querySelectorAll('[id*="RegularExpressionValidator"]');

                                    errorValidators.forEach(function (validator) {
                                        var observer = new MutationObserver(function (mutations) {
                                            mutations.forEach(function (mutation) {
                                                if (mutation.type === 'attributes' && mutation.attributeName === 'style' && validator.style.display !== 'none') {
                                                    var errorMessage = validator.innerHTML.trim();
                                                    if (errorMessage) {
                                                        errorCount++;
                                                        // Find the label text
                                                        var parentDiv = validator.closest('.md\\:max-w-\\[250px\\]');
                                                        var label = parentDiv ? parentDiv.querySelector('label') : null;
                                                        var labelText = label ? label.innerText : 'Unknown Label';
                                                        // Format the error message
                                                        var formattedMessage = `${labelText} - ${errorMessage}`;
                                                        mainErrorMessage.innerHTML += `<br>${formattedMessage}`;
                                                    }
                                                }
                                            });

                                            // Show or hide the main error div based on the number of errors
                                            if (errorCount > 0) {
                                                mainErrorDiv.style.display = 'flex';
                                            } else {
                                                mainErrorDiv.style.display = 'none';
                                            }
                                        });

                                        observer.observe(validator, {
                                            attributes: true
                                        });
                                    });
                                }

                                setupValidators();

                                // Handle UpdatePanel postbacks
                                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
                                    setupValidators();
                                });
                            });

                            function deleteRowClientSide(btn) {
                                if (confirm('Are you sure you want to delete this row?')) {
                                    var $row = $(btn).closest('tr'); // Get the row
                                    var rowIndex = $row.index(); // Get the index

                                    // Remove the row from the DOM
                                    $row.remove();

                                    // Optional: Track deleted indexes in a hidden field
                                    var deletedIndexes = $('#<%= hfDeletedIndexes.ClientID %>').val();
                                    deletedIndexes += (deletedIndexes ? ',' : '') + rowIndex;
                                    $('#<%= hfDeletedIndexes.ClientID %>').val(deletedIndexes);
                                }
                            }

                        </script>


                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

