<%@ Page Title="" ClientIDMode="AutoID" Language="C#" MasterPageFile="~/Home.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="InNonPayment.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="RET.InNonPayment" ValidateRequest="false" %>

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
    <script>
        function fileUpload() {
            $("#ctl00_ContentPlaceHolder1_TabContainer1_Header_Btn_Upload33").click();
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
        function drop_draft_4() {
            document.getElementById("drop_draft_4_area").classList.toggle("hidden");
            document
                .getElementById("drop_draft_4_Svg")
                .classList.toggle("rotate-180");
        }
        function openTab(tabId) {
            var tabContainer = $find("<%= TabContainer1.ClientID %>");
            tabContainer.set_activeTabIndex(tabId - 1);
        }
    </script>

    <link href="css/style.css?abc=123" rel="stylesheet" />
    <style>
        .text-slate-300 {
            color: rgb(0 0 0) !important;
        }

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
            width: 900px;
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

    <asp:UpdateProgress ID="UpdateProgress" class="theme_loader" runat="server" AssociatedUpdatePanelID="innonpayment">
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
                            </g><!-- [ldio] generated by https://loading.io --></svg>
                        <%--<img alt="" src="Loader.gif" width="100" height="100" />--%>
                    </center>
                </div>
            </div>
        </ProgressTemplate>

    </asp:UpdateProgress>

    <asp:UpdatePanel ID="innonpayment" runat="server" UpdateMode="Conditional">
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
                            <button id="Button3" type="button" class="btn1 btn-primary " runat="server" visible="false">Save and Submit</button>
                        </div>
                        <div class="btn-group">
                            <button id="Button4" type="button" class="btn1 btn-primary" runat="server" visible="false">Print Status</button>
                            <button id="Button7" type="button" class="btn1 btn-primary" runat="server" visible="false">Print Draft CCP</button>
                            <asp:Button ID="BtnPrintCIF" runat="server" Visible="false" Text="Print CIF" class="btn1 btn-primary" OnClick="BtnPrintCIF_Click" />
                        </div>
                    </div>
                </div>

                <asp:UpdatePanel ID="updatepanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="flex md:justify-between items-center gap-4 mb-4 mt-6 md:flex-nowrap flex-wrap">
                            <div class="flex gap-2 items-center">
                                <p class="text-gray-500 text-sm font-medium">In Non-Payment</p>
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

                            <asp:Panel ID="PanelErr" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none;">
                                <div class="header">
                                    <svg class="cursor-pointer absolute right-5 top-5" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                        <circle opacity="0.1" cx="12" cy="12" r="12" fill="#676D7C"></circle>
                                        <path d="M16.6663 7.3335L7.33301 16.6668M7.33301 7.3335L16.6663 16.6668" stroke="#676D7C" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                    </svg>
                                    <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40"></p>
                                </div>
                                <div class="body">
                                    <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                        <asp:GridView ID="GridError" PageSize="5" AllowPaging="True" OnPageIndexChanging="GridError_PageIndexChanging" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" AutoGenerateColumns="false" Visible="false">
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
                                </div>
                                <div class="footer" align="right">
                                    <asp:Button ID="BtnCls" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[200px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />

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
                            </div>


                            <div class="board-inner">
                                <div>

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

                                        <cc1:TabPanel ID="Header" CssClass="ajax__tab_header" runat="server" HeaderText="Header">
                                            <ContentTemplate>

                                                <asp:UpdatePanel ID="innonheader" UpdateMode="Conditional" runat="server">
                                                    <ContentTemplate>

                                                        <%--   <div class="flex justify-between gap-2 items-center mt-7">
                                                            <h2 class="text-lg sa700 leading-[18px] text-gray-800">Job Information
                                                            </h2>
                                                        </div>--%>


                                                        <div class="grid grid-cols-1 md:grid-cols-2 gap-6 mt-4 mb-2">

                                                            <!-- Left Column -->
                                                            <div class="space-y-4">
                                                                <!-- TradeNet Mailbox ID -->
                                                                <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-6">
                                                                    <span class="text-white text-sm font-semibold tracking-wide">Declaration Type</span>
                                                                </div>
                                                                <div class="w-full mt-4">
                                                                    <div class="flex items-center gap-4">
                                                                        <label class="text-gray-500 text-sm font-medium w-[200px]">Message Type</label>

                                                                        <div class="flex-1 relative">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)"
                                                                                placeholder="Message Type"
                                                                                autocomplete="off"
                                                                                ID="TxtMsgType"
                                                                                Text="INPDEC"
                                                                                Enabled="false"
                                                                                runat="server"
                                                                                type="text"
                                                                                CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                            </asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="w-full">
                                                                    <div class="flex items-center gap-4">

                                                                        <div class="text-gray-500 text-sm font-medium w-[200px]">
                                                                            Declaration Type
                                                                        </div>

                                                                        <div class="flex-1  w-full">
                                                                            <asp:DropDownList
                                                                                ID="DrpDecType"
                                                                                OnSelectedIndexChanged="DrpDecType_SelectedIndexChanged"
                                                                                AutoPostBack="true"
                                                                                AppendDataBoundItems="true"
                                                                                TabIndex="1"
                                                                                runat="server"
                                                                                CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                            </asp:DropDownList>

                                                                            <asp:RequiredFieldValidator
                                                                                InitialValue="0"
                                                                                BackColor="Red"
                                                                                Width="265"
                                                                                ID="RequiredFieldValidator7"
                                                                                runat="server"
                                                                                ControlToValidate="DrpDecType"
                                                                                Display="None"
                                                                                ErrorMessage="Header --> Declaration Type is Required"
                                                                                ValidationGroup="Validation">
                                                                            </asp:RequiredFieldValidator>
                                                                        </div>

                                                                    </div>
                                                                </div>


                                                                <!-- Previous Permit Number -->
                                                                <div class="w-full mt-4">
                                                                    <div class="flex items-center gap-4">
                                                                        <label class="text-gray-500 text-sm font-medium w-[200px]">Previous Permit Number</label>

                                                                        <div class="flex-1 relative">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)"
                                                                                placeholder=""
                                                                                autocomplete="off"
                                                                                ID="TxtPrevPerNO"
                                                                                Text=""
                                                                                TabIndex="2"
                                                                                runat="server"
                                                                                type="text"
                                                                                CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                            </asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div id="cargo" runat="server" class="w-full">
                                                                    <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-6">
                                                                        <span class="text-white text-sm font-semibold tracking-wide">Declaration Information
                                                                        </span>
                                                                    </div>
                                                                    <div class="flex items-center gap-4">

                                                                        <div class="text-gray-500 text-sm font-medium w-[200px]">
                                                                            Cargo Pack Type
                                                                        </div>

                                                                        <div class="flex-1 w-full">
                                                                            <asp:DropDownList
                                                                                ID="DrpCargoPackType"
                                                                                OnSelectedIndexChanged="DrpCargoPackType_SelectedIndexChanged"
                                                                                AutoPostBack="true"
                                                                                AppendDataBoundItems="true"
                                                                                TabIndex="3"
                                                                                runat="server"
                                                                                CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                            </asp:DropDownList>

                                                                            <asp:RequiredFieldValidator
                                                                                BackColor="Red"
                                                                                InitialValue="0"
                                                                                ID="RequiredFieldValidator5"
                                                                                runat="server"
                                                                                ControlToValidate="DrpCargoPackType"
                                                                                Display="None"
                                                                                ErrorMessage="Header --> Cargo Pack Type is Required"
                                                                                ValidationGroup="Validation">
                                                                            </asp:RequiredFieldValidator>
                                                                        </div>

                                                                    </div>
                                                                </div>

                                                                <div id="Inward" runat="server" class="w-full">
                                                                    <div class="flex items-center gap-4">

                                                                        <!-- Left Label -->
                                                                        <div id="inwared" class="text-gray-500 text-sm font-medium w-[200px]">
                                                                            Inward Transport Mode
                                                                        </div>

                                                                        <div class="flex-1 w-full">
                                                                            <asp:DropDownList
                                                                                ID="DrpInwardtrasMode"
                                                                                OnSelectedIndexChanged="DrpInwardtrasMode_SelectedIndexChanged"
                                                                                AutoPostBack="true"
                                                                                AppendDataBoundItems="true"
                                                                                TabIndex="3"
                                                                                runat="server"
                                                                                CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                            </asp:DropDownList>

                                                                            <asp:RequiredFieldValidator
                                                                                BackColor="Red"
                                                                                InitialValue="0"
                                                                                ID="RequiredFieldValidator6"
                                                                                runat="server"
                                                                                ControlToValidate="DrpInwardtrasMode"
                                                                                Display="None"
                                                                                ErrorMessage="Header --> Inward Transport Mode is Required"
                                                                                ValidationGroup="Validation">
                                                                            </asp:RequiredFieldValidator>
                                                                        </div>

                                                                    </div>
                                                                </div>




                                                                <div id="Outward" runat="server" class="w-full">
                                                                    <div class="flex items-center gap-4">

                                                                        <!-- Left Label -->
                                                                        <div id="q" class="text-gray-500 text-sm font-medium w-[200px]">
                                                                            Outward Transport Mode
                                                                        </div>

                                                                        <div class="flex-1 w-full">
                                                                            <asp:DropDownList
                                                                                ID="DrpOutwardtrasMode"
                                                                                OnSelectedIndexChanged="DrpOutwardtrasMode_SelectedIndexChanged"
                                                                                AutoPostBack="true"
                                                                                AppendDataBoundItems="true"
                                                                                TabIndex="3"
                                                                                runat="server"
                                                                                CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                            </asp:DropDownList>

                                                                            <asp:RequiredFieldValidator
                                                                                BackColor="Red"
                                                                                InitialValue="0"
                                                                                ID="RequiredFieldValidator1"
                                                                                runat="server"
                                                                                ControlToValidate="DrpOutwardtrasMode"
                                                                                Display="None"
                                                                                ErrorMessage="Header --> Outward Transport Mode is Required"
                                                                                ValidationGroup="Validation">
                                                                            </asp:RequiredFieldValidator>
                                                                        </div>

                                                                    </div>
                                                                </div>



                                                                <%--  <div id="Outward" runat="server" class="md:max-w-[250px] w-full">
                                                                          <div class="flex items-center gap-4">
                                                                              <div id="q" class="text-gray-500 text-sm font-medium w-[200px]">Outward Trans Mode</div>

                                                                              <div class="flex-1 w-full">

                                                                                <asp:DropDownList ID="DrpOutwardtrasMode" OnSelectedIndexChanged="DrpOutwardtrasMode_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true" TabIndex="5" runat="server" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                                </asp:DropDownList>

                                                                                <asp:RequiredFieldValidator BackColor="Red" InitialValue="0" ID="RequiredFieldValidator31" runat="server" ControlToValidate="DrpOutwardtrasMode" Display="None" ErrorMessage="Header --> Outward Transport Mode is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                          
                                                                        </div>



                                                                              </div>
                                                                    </div>--%>



                                                                <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-6">
                                                                    <span class="text-white text-sm font-semibold tracking-wide">Job Details

                                                                    </span>
                                                                </div>
                                                                <div class="w-full">
                                                                    <div class="flex items-center gap-4">

                                                                        <label class="text-gray-500 text-sm font-medium w-[200px]">BG Indicator</label>

                                                                        <div class="flex-1 w-full">
                                                                            <asp:DropDownList
                                                                                ID="DrpBGIndicator"
                                                                                AppendDataBoundItems="true"
                                                                                TabIndex="6"
                                                                                runat="server"
                                                                                CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                            </asp:DropDownList>
                                                                        </div>

                                                                    </div>
                                                                </div>


                                                                <!-- Override Ex: Rate -->
                                                                <div class=" w-full">
                                                                    <div class="flex items-center justify-start gap-2">
                                                                        <asp:CheckBox ID="ChkOverrExgRate" AutoPostBack="true" OnCheckedChanged="ChkOverrExgRate_CheckedChanged" runat="server" TabIndex="7" />
                                                                        <label for="ChkOverrExgRate" class="text-gray-500 text-sm font-medium">Override Ex: Rate</label>
                                                                    </div>
                                                                </div>

                                                                <!-- Supply Indicator -->
                                                                <div class="md:max-w-[200px] w-full mt-2">
                                                                    <div class="flex items-center justify-start gap-2">
                                                                        <asp:CheckBox ID="ChkSupplyIndicator" AutoPostBack="true" OnCheckedChanged="ChkOverrExgRate_CheckedChanged" runat="server" TabIndex="7" />
                                                                        <label for="ChkSupplyIndicator" class="text-gray-500 text-sm font-medium">Supply indicator</label>
                                                                    </div>
                                                                </div>

                                                                <!-- Supporting Documents -->
                                                                <div class="md:max-w-[200px] w-full mt-2">
                                                                    <div class="flex items-center justify-start gap-2">
                                                                        <asp:CheckBox ID="ChkRefDoc" AutoPostBack="true" OnCheckedChanged="ChkRefDoc_CheckedChanged" runat="server" TabIndex="7" />

                                                                        <label for="ChkRefDoc" class="text-gray-500 text-sm font-medium">Supporting documents</label>
                                                                    </div>
                                                                </div>

                                                            </div>

                                                            <div class="space-y-4">
                                                                <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-6">
                                                                    <span class="text-white text-sm font-semibold tracking-wide">Job Information


                                                                    </span>
                                                                </div>
                                                                <div class="w-full">
                                                                    <div class="flex items-center gap-4">
                                                                        <label class="text-gray-500 text-sm font-medium w-[200px]">TradeNet Mailbox ID</label>

                                                                        <div class="flex-1 relative">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)"
                                                                                placeholder="TradeNet Mailbox ID"
                                                                                autocomplete="off"
                                                                                runat="server"
                                                                                Text=""
                                                                                type="text"
                                                                                Enabled="false"
                                                                                ID="TxtTradeMailID"
                                                                                CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                            </asp:TextBox>
                                                                            <asp:RequiredFieldValidator
                                                                                BackColor="Red"
                                                                                ID="RequiredFieldValidator2"
                                                                                runat="server"
                                                                                ControlToValidate="TxtTradeMailID"
                                                                                Display="None"
                                                                                ErrorMessage="Header --> TradeNet Mailbox ID is Required"
                                                                                ValidationGroup="Validation">
                                                                            </asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <!-- Declarant Name -->
                                                                <div class="w-full">
                                                                    <div class="flex items-center gap-4">
                                                                        <label class="text-gray-500 text-sm font-medium w-[200px]">Declarant Name</label>

                                                                        <div class="flex-1 w-full relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtDecName" Text="" Enabled="false" runat="server" type="text"
                                                                                CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="TxtDecName" Display="None"
                                                                                ErrorMessage="Header --> Declarant Name is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" Display="None"
                                                                                ControlToValidate="TxtDecName" ValidationExpression="[a-zA-Z ]*$" ErrorMessage="Enter a valid Name"
                                                                                ValidationGroup="Validation" />
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="w-full mt-4">
                                                                    <div class="flex items-center gap-4">
                                                                        <label class="text-gray-500 text-sm font-medium w-[200px]">Declarant Code</label>
                                                                        <div class="flex-1 relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtDecCode" Text="" Enabled="false" runat="server" type="text"
                                                                                CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <!-- Declarant Telephone -->
                                                                <div class="w-full mt-4">
                                                                    <div class="flex items-center gap-4">
                                                                        <label class="text-gray-500 text-sm font-medium w-[200px]">Declarant Telephone</label>
                                                                        <div class="flex-1 w-full relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtDecTelephone" Enabled="false" Text="" runat="server" type="text"
                                                                                CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtDecTelephone" Display="None"
                                                                                ErrorMessage="Header --> Declarant Telephone is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ID="regPhone" runat="server" Display="None" ControlToValidate="TxtDecTelephone"
                                                                                ValidationExpression="[0-9]{10}" ErrorMessage="Enter a valid phone number" ValidationGroup="Validation" />
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <!-- CR UEI Number -->
                                                                <div class="w-full mt-4">
                                                                    <div class="flex items-center gap-4">
                                                                        <label class="text-gray-500 text-sm font-medium w-[200px]">CR UEI Number</label>
                                                                        <div class="flex-1 w-full relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtCRUEINO" Text="" Enabled="false" runat="server" type="text"
                                                                                CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtCRUEINO" Display="None"
                                                                                ErrorMessage="Header --> CR UEI No is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-6">
                                                                    <span class="text-white text-sm font-semibold tracking-wide">ADDITIONAL RECIPIENTS</span>
                                                                    <asp:Label ID="txt_code" Visible="false" runat="server"></asp:Label>
                                                                </div>

                                                                <!-- Recipient 1 -->
                                                                <div class="w-full">
                                                                    <div class="flex items-center gap-4">

                                                                        <label class="text-gray-500 text-sm font-medium w-[200px]">Recipient 1</label>
                                                                        <div class="flex-1 w-full relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)"
                                                                                placeholder="Type Recipient"
                                                                                autocomplete="off"
                                                                                ID="TxtRECPT1"
                                                                                runat="server"
                                                                                TabIndex="18"
                                                                                type="text"
                                                                                CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                            </asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <!-- Recipient 2 -->
                                                                <div class="w-full mt-4">
                                                                    <div class="flex items-center gap-4">

                                                                        <label class="text-gray-500 text-sm font-medium w-[200px]">Recipient 2</label>

                                                                        <div class="flex-1 w-full relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)"
                                                                                placeholder="Type Recipient"
                                                                                autocomplete="off"
                                                                                ID="TxtRECPT2"
                                                                                runat="server"
                                                                                TabIndex="19"
                                                                                type="text"
                                                                                CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                            </asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <!-- Recipient 3 -->
                                                                <div class="w-full mt-4">
                                                                    <div class="flex items-center gap-4">
                                                                        <label class="text-gray-500 text-sm font-medium w-[200px]">Recipient 3</label>
                                                                        <div class="flex-1  w-full relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)"
                                                                                placeholder="Type Recipient"
                                                                                autocomplete="off"
                                                                                ID="TxtRECPT3"
                                                                                runat="server"
                                                                                onkeypress="return isNumber(event)"
                                                                                TabIndex="20"
                                                                                type="text"
                                                                                CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                            </asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>


                                                            </div>
                                                        </div>








                                                        <div class="flex justify-between gap-2 items-center mt-6">
                                                            <h2 class="text-lg sa700 leading-[18px] text-gray-800">Licence Details</h2>
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
                                                                                <label class="text-gray-500 text-sm font-medium">Attachment</label>
                                                                                <div class="mt-1 w-full h-10 bg-slate-100 rounded-md flex items-center justify-center gap-2 cursor-pointer relative">
                                                                                    <asp:FileUpload ID="FileUpload1" CssClass="absolute h-full left-0 opacity-0 w-full" TabIndex="16" runat="server" AllowMultiple="true" onchange="fileUpload()" />
                                                                                    <img src="./images/import.svg" alt="Import">
                                                                                    <p class="text-center text-[#0560FD] text-sm sa700">
                                                                                        Choose Files            
                                                                                    </p>
                                                                                </div>
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


                                                                        <div class="w-full bg-white my-shadow rounded-2xl px-4 py-5 mt-5">
                                                                            <div class="overflow-auto my-shadow whitespace-nowrap amount_offer">
                                                                                <div class="table-responsive">
                                                                                    <label class="text-gray-500 text-sm font-medium">Search </label>
                                                                                    <asp:TextBox autocomplete="off" ID="txtdocserach" OnTextChanged="txtdocserach_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server" Style="width: 400px;"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                        </div>



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
                                                                                            <asp:LinkButton ID="lblName" CommandArgument='<%# Eval("Name") %>' OnCommand="lblName_Command" runat="server"
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

                                        <cc1:TabPanel ID="Party" runat="server" CssClass="nn" HeaderText="Party">
                                            <ContentTemplate>
                                                <asp:UpdatePanel ID="upinnonparty" UpdateMode="Conditional" runat="server">
                                                    <ContentTemplate>
                                                        <br />

                                                        <div class="flex flex-wrap lg:flex-nowrap gap-3">
                                                            <div class="flex items-center justify-between mb-1">
                                                                <!-- Left side heading and buttons -->
                                                                <div class="flex items-center gap-1">
                                                                    <h2 class="text-[18px] sa700 leading-[18px] text-gray-800 mb-0 mt-5 w-[200px]">Declarant Company</h2>
                                                                    <asp:ImageButton ID="btnShow" Style="filter: grayscale(100%);" CssClass="theme_searchIcon mt-5" Enabled="false" runat="server" ImageUrl="images/searchBlue.png" Height="28" Width="28" />
                                                                    <asp:Button ID="DECPLUS" Style="filter: grayscale(100%);" runat="server" CssClass="plusbtn plusbtnIcon mt-5" Enabled="false" BorderWidth="0px" ValidationGroup="PartyDec" OnClick="DECPLUS_Click" Text="+" />
                                                                </div>

                                                                <!-- Code -->
                                                                <div class="flex-1 min-w-[100px] max-w-[300px] m-1">
                                                                    <label for="staticEmail" class="text-gray-500 text-sm font-medium">Code</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" Enabled="false" autocomplete="off" runat="server" type="text" OnTextChanged="TxtDecCompCode_TextChanged" placeholder="" AutoPostBack="true" ID="TxtDecCompCode" TabIndex="24" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
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
                                                                    </div>
                                                                </div>

                                                                <!-- CR UEI -->
                                                                <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                    <label class="text-gray-500 text-sm font-medium">CR UEI</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" Enabled="false" autocomplete="off" ID="TxtDecCompCRUEI" MaxLength="17" placeholder="" runat="server" ValidationGroup="PartyDec" TabIndex="25" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtDecCompCRUEI" ID="RegularExpressionValidator54" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="party"></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>

                                                                <!-- Name 1 -->
                                                                <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                    <label class="text-gray-500 text-sm font-medium">Name 1</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" Enabled="false" autocomplete="off" ID="TxtDecCompName" MaxLength="50" placeholder="" runat="server" ValidationGroup="PartyDec" TabIndex="26" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtDecCompName" ID="RegularExpressionValidator52" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="party"></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>

                                                                <!-- Name 2 -->
                                                                <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                    <label class="text-gray-500 text-sm font-medium">Name 2</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" Enabled="false" autocomplete="off" ID="TxtDecCompName1" MaxLength="50" placeholder="" ValidationGroup="PartyDec" runat="server" TabIndex="27" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" Style="text-transform: uppercase;"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtDecCompName1" ID="RegularExpressionValidator53" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="PartyDec"></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>


                                                        <cc1:ModalPopupExtender ID="popupinnondec" runat="server" PopupControlID="pnldec" TargetControlID="btnShow"
                                                            OkControlID="btnYes" CancelControlID="btnNo" BackgroundCssClass="modalBackground">
                                                        </cc1:ModalPopupExtender>

                                                        <asp:Panel ID="pnldec" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">

                                                            <div class="header">
                                                                <svg class="cursor-pointer absolute right-5 top-5" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                    <circle opacity="0.1" cx="12" cy="12" r="12" fill="#676D7C"></circle>
                                                                    <path d="M16.6663 7.3335L7.33301 16.6668M7.33301 7.3335L16.6663 16.6668" stroke="#676D7C" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                                                </svg>
                                                                <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Declarant Company Search</p>
                                                            </div>

                                                            <div class="body">
                                                                <asp:UpdatePanel ID="upinnondec" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                            <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="DecSearch" OnTextChanged="DecSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                        </div>

                                                                        <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                            <asp:GridView ID="DECCOMPSearGRID" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="DECCOMPSearGRID_PageIndexChanging" OnRowDataBound="DECCOMPSearGRID_RowDataBound" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" AutoGenerateColumns="false" OnRowCommand="DECCOMPSearGRID_RowCommand">
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

                                                                                            <asp:LinkButton ID="lnkRequestID" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="lnkRequestID_Command" CssClass="duration-300 ease-in-out md:max-w-[200px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700">Select </asp:LinkButton>

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





                                                        <div class="flex flex-wrap lg:flex-nowrap gap-3">
                                                            <div class="flex items-center justify-between mb-1">
                                                                <!-- Header and Buttons -->
                                                                <div class="flex items-center gap-1">
                                                                    <h2 class="text-[18px] sa700 leading-[18px] text-gray-800 mb-0 mt-5 w-[200px]">Importer</h2>
                                                                    <asp:ImageButton ID="btninnonimp" CssClass="theme_searchIcon mt-5" runat="server" ImageUrl="images/searchBlue.png" Height="28" Width="28" />
                                                                    <asp:Button ID="BtnImpADD" runat="server" CssClass="plusbtn plusbtnIcon mt-5" BorderWidth="0px" ValidationGroup="PartyImp" OnClick="BtnImpADD_Click" Text="+" />
                                                                </div>

                                                                <!-- Code -->
                                                                <div class="flex-1 min-w-[100px] max-w-[300px] m-1">
                                                                    <label for="staticEmail" class="text-gray-500 text-sm font-medium">Code</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" OnTextChanged="TxtImpCode_TextChanged" placeholder="" AutoPostBack="true" ID="TxtImpCode" TabIndex="24" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
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
                                                                    </div>
                                                                </div>

                                                                <!-- CR UEI -->
                                                                <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                    <label class="text-gray-500 text-sm font-medium">CR UEI</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtImpCRUEI" MaxLength="17" placeholder="" runat="server" ValidationGroup="PartyImp" TabIndex="25" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtImpCRUEI" ID="RegularExpressionValidator57" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="party"></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>

                                                                <!-- Name 1 -->
                                                                <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                    <label class="text-gray-500 text-sm font-medium">Name 1</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtImpName" MaxLength="50" placeholder="" runat="server" ValidationGroup="PartyImp" TabIndex="26" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtImpName" ID="RegularExpressionValidator55" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="party"></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>

                                                                <!-- Name 2 -->
                                                                <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                    <label class="text-gray-500 text-sm font-medium">Name 2</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtImpName1" MaxLength="50" placeholder="" ValidationGroup="PartyImp" runat="server" TabIndex="27" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtImpName1" ID="RegularExpressionValidator56" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="PartyImp"></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>


                                                        <cc1:ModalPopupExtender ID="popupinnonimp" runat="server" PopupControlID="pnlinnonimp" TargetControlID="btninnonimp"
                                                            OkControlID="btnYesinnonimp" CancelControlID="btnNoinnonimp" BackgroundCssClass="modalBackground">
                                                        </cc1:ModalPopupExtender>

                                                        <asp:Panel ID="pnlinnonimp" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                            <div class="header">


                                                                <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Importer Search</p>
                                                            </div>

                                                            <div class="body">
                                                                <asp:UpdatePanel ID="upinnonimpgrid" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                            <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ImporterSearch" OnTextChanged="ImporterSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                        </div>

                                                                        <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                            <asp:GridView ID="ImporterGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ImporterGrid_PageIndexChanging" OnRowDataBound="ImporterGrid_RowDataBound" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" AutoGenerateColumns="false" OnRowCommand="ImporterGrid_RowCommand">
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
                                                                <asp:Button ID="btnYesinnonimp" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                <asp:Button ID="btnNoinnonimp" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px] mt-4 w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                            </div>
                                                        </asp:Panel>




                                                        <div id="ExpParty" visible="false" runat="server">
                                                            <div class="flex flex-wrap lg:flex-nowrap gap-3">
                                                                <div class="flex items-center justify-between mb-1">

                                                                    <div class="flex items-center gap-1">
                                                                        <h2 class="text-[18px] sa700 leading-[18px] text-gray-800 mb-0 mt-5 w-[200px]">Exporter</h2>
                                                                        <asp:ImageButton ID="btninnonexp" CssClass="theme_searchIcon" runat="server" ImageUrl="images/searchBlue.png" Height="28" Width="28" />
                                                                        <asp:Button ID="BtnExpAdd" runat="server" CssClass="plusbtn plusbtnIcon" BorderWidth="0px" ValidationGroup="PartyExp" OnClick="BtnExpAdd_Click" Text="+" />

                                                                    </div>


                                                                    <div class="flex-1 min-w-[100px] max-w-[300px] m-1">

                                                                        <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                        <div class="relative mt-1">


                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" OnTextChanged="TxtExpCode_TextChanged" placeholder="" AutoPostBack="true" ID="TxtExpCode" TabIndex="24" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
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

                                                                        </div>
                                                                    </div>



                                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                        <label class="text-gray-500 text-sm font-medium">CR UEI</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtExpCRUEI" MaxLength="17" placeholder="" runat="server" ValidationGroup="PartyImp" TabIndex="25" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtExpCRUEI" ID="RegularExpressionValidator58" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="party"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                    </div>
                                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                        <label class="text-gray-500 text-sm font-medium">Name 1 </label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtExpName" MaxLength="50" placeholder="" runat="server" ValidationGroup="PartyImp" TabIndex="26" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtExpName" ID="RegularExpressionValidator6" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="PartyExp"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                    </div>
                                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                        <label class="text-gray-500 text-sm font-medium">Name 2</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtExpName1" MaxLength="50" placeholder="" ValidationGroup="PartyExp" runat="server" TabIndex="27" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtExpName1" ID="RegularExpressionValidator2" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="PartyExp"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <cc1:ModalPopupExtender ID="Popupexp" runat="server" PopupControlID="pnlinnonexp" TargetControlID="btninnonexp"
                                                                    OkControlID="btnYesinnonexp" CancelControlID="btnNoinnonexp" BackgroundCssClass="modalBackground">
                                                                </cc1:ModalPopupExtender>

                                                                <asp:Panel ID="pnlinnonexp" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">

                                                                    <div class="header">
                                                                        <%--  <svg class="cursor-pointer absolute right-5 top-5" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
      <circle opacity="0.1" cx="12" cy="12" r="12" fill="#676D7C"></circle>
      <path d="M16.6663 7.3335L7.33301 16.6668M7.33301 7.3335L16.6663 16.6668" stroke="#676D7C" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
    </svg>--%>
                                                                        <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Exporter Search</p>
                                                                    </div>

                                                                    <div class="body">
                                                                        <asp:UpdatePanel ID="upinnonexpgrid" runat="server" UpdateMode="Conditional">
                                                                            <ContentTemplate>
                                                                                <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                    <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ExporterSearch" OnTextChanged="ExporterSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                                </div>

                                                                                <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                                    <asp:GridView ID="ExporterGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ExporterGrid_PageIndexChanging" OnRowDataBound="ExporterGrid_RowDataBound" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" AutoGenerateColumns="false" OnRowCommand="ExporterGrid_RowCommand">
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

                                                                                                    <asp:LinkButton ID="LnkExporter" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkExporter_Command" CssClass="duration-300 ease-in-out md:max-w-[200px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700">Select </asp:LinkButton>

                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </div>
                                                                            </ContentTemplate>

                                                                        </asp:UpdatePanel>

                                                                    </div>
                                                                    <div class="footer" align="right">
                                                                        <asp:Button ID="btnYesinnonexp" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                        <asp:Button ID="btnNoinnonexp" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px] mt-4 w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                    </div>
                                                                </asp:Panel>

                                                            </div>




                                                            <div class="flex flex-wrap lg:flex-nowrap gap-3">
                                                                <div class="flex items-center justify-between mb-1">
                                                                    <!-- Header and Buttons -->
                                                                    <div class="flex items-center gap-1">
                                                                        <h2 class="text-[18px] sa700 leading-[18px] text-gray-800 mb-0 mt-5 w-[200px]">Inward Carrier Agent</h2>
                                                                        <asp:ImageButton ID="btninnoninw" CssClass="theme_searchIcon mt-5" runat="server" ImageUrl="images/searchBlue.png" Height="28" Width="28" />
                                                                        <asp:Button ID="InwardAdd" runat="server" CssClass="plusbtn plusbtnIcon mt-5" BorderWidth="0px" ValidationGroup="PartyInw" OnClick="InwardAdd_Click" Text="+" />
                                                                    </div>

                                                                    <!-- Code -->
                                                                    <div class="flex-1 min-w-[100px] max-w-[300px] m-1">
                                                                        <label for="staticEmail" class="text-gray-500 text-sm font-medium">Code</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" OnTextChanged="InwardCode_TextChanged" placeholder="" AutoPostBack="true" ID="InwardCode" TabIndex="24" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
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
                                                                        </div>
                                                                    </div>

                                                                    <!-- CR UEI -->
                                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                        <label class="text-gray-500 text-sm font-medium">CR UEI</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="InwardCRUEI" MaxLength="17" placeholder="" runat="server" ValidationGroup="PartyInw" TabIndex="25" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="InwardCRUEI" ID="RegularExpressionValidator59" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="party"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                    </div>

                                                                    <!-- Name 1 -->
                                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                        <label class="text-gray-500 text-sm font-medium">Name 1</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="InwardName" MaxLength="50" placeholder="" runat="server" ValidationGroup="PartyInw" TabIndex="26" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="InwardName" ID="RegularExpressionValidator16" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="PartyInw"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                    </div>

                                                                    <!-- Name 2 -->
                                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                        <label class="text-gray-500 text-sm font-medium">Name 2</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="InwardName1" placeholder="" ValidationGroup="PartyInw" runat="server" TabIndex="27" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="InwardName1" ID="RegularExpressionValidator17" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="PartyInw"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>


                                                            <cc1:ModalPopupExtender ID="popupinnoninw" runat="server" PopupControlID="pnlinnoninw" TargetControlID="btninnoninw"
                                                                OkControlID="btnYesinnoninw" CancelControlID="btnNoinnoninw" BackgroundCssClass="modalBackground">
                                                            </cc1:ModalPopupExtender>

                                                            <asp:Panel ID="pnlinnoninw" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">

                                                                <div class="header">
                                                                    <%--   <svg class="cursor-pointer absolute right-5 top-5" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
      <circle opacity="0.1" cx="12" cy="12" r="12" fill="#676D7C"></circle>
      <path d="M16.6663 7.3335L7.33301 16.6668M7.33301 7.3335L16.6663 16.6668" stroke="#676D7C" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
    </svg>--%>
                                                                    <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Inward Carrier Agent Search</p>
                                                                </div>

                                                                <div class="body">
                                                                    <asp:UpdatePanel ID="upinnoninwgrid" runat="server" UpdateMode="Conditional">
                                                                        <ContentTemplate>
                                                                            <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="InwardSearch" OnTextChanged="InwardSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                            </div>

                                                                            <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                                <asp:GridView ID="InwardGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="InwardGrid_PageIndexChanging" OnRowDataBound="InwardGrid_RowDataBound" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" AutoGenerateColumns="false" OnRowCommand="InwardGrid_RowCommand">
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
                                                                    <asp:Button ID="btnYesinnoninw" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                    <asp:Button ID="btnNoinnoninw" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px] mt-4 w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                </div>
                                                            </asp:Panel>

                                                        </div>
                                                        <div>

                                                            <div class="flex flex-wrap lg:flex-nowrap gap-3">
                                                                <div class="flex items-center justify-between mb-1">
                                                                    <!-- Header and Buttons -->
                                                                    <div class="flex items-center gap-1">
                                                                        <h2 class="text-[18px] sa700 leading-[18px] text-gray-800 mb-0 mt-5 w-[200px]">Freight Forwarder</h2>
                                                                        <asp:ImageButton ID="btninnonfreightforwarder" CssClass="theme_searchIcon mt-5" runat="server" ImageUrl="images/searchBlue.png" Height="28" Width="28" />
                                                                        <asp:Button ID="BtnFrieghtAdd" runat="server" CssClass="plusbtn plusbtnIcon mt-5" BorderWidth="0px" ValidationGroup="Partyfreight" OnClick="BtnFrieghtAdd_Click" Text="+" />
                                                                    </div>

                                                                    <!-- Code -->
                                                                    <div class="flex-1 min-w-[100px] max-w-[300px] m-1">
                                                                        <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" OnTextChanged="FrieghtCode_TextChanged" placeholder="" AutoPostBack="true" ID="FrieghtCode" TabIndex="24" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
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
                                                                        </div>
                                                                    </div>

                                                                    <!-- CR UEI -->
                                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                        <label class="text-gray-500 text-sm font-medium">CR UEI</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="FrieghtCRUEI" placeholder="" runat="server" TabIndex="25" ValidationGroup="Partyfreight" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator75" runat="server" ControlToValidate="FrieghtCRUEI" Display="None" ErrorMessage="Party --> Freight Agent CRUEI is Required" ValidationGroup="Partyfreight"></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="FrieghtCRUEI" ID="RegularExpressionValidator62" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Partyfreight"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                    </div>

                                                                    <!-- Name 1 -->
                                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                        <label class="text-gray-500 text-sm font-medium">Name 1</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="FrieghtName" placeholder="" runat="server" ValidationGroup="Partyfreight" TabIndex="26" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator73" runat="server" ControlToValidate="FrieghtName" Display="None" ErrorMessage="Party --> Freight Agent Name is Required" ValidationGroup="Partyfreight"></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="FrieghtName" ID="RegularExpressionValidator60" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Partyfreight"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                    </div>

                                                                    <!-- Name 2 -->
                                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                        <label class="text-gray-500 text-sm font-medium">Name 2</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="FrieghtName1" placeholder="" ValidationGroup="Partyfreight" runat="server" TabIndex="27" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>


                                                            <cc1:ModalPopupExtender ID="popupinnonfreight" runat="server" PopupControlID="pnlinnonfreight" TargetControlID="btninnonfreightforwarder"
                                                                OkControlID="btnYesinnonfreight" CancelControlID="btnNoinnonfreight" BackgroundCssClass="modalBackground">
                                                            </cc1:ModalPopupExtender>

                                                            <asp:Panel ID="pnlinnonfreight" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                                <div class="header">
                                                                    <%--   <svg class="cursor-pointer absolute right-5 top-5" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
  <circle opacity="0.1" cx="12" cy="12" r="12" fill="#676D7C"></circle>
  <path d="M16.6663 7.3335L7.33301 16.6668M7.33301 7.3335L16.6663 16.6668" stroke="#676D7C" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
</svg>--%>
                                                                    <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Freight Forwarder Search</p>
                                                                </div>

                                                                <div class="body">
                                                                    <asp:UpdatePanel ID="upinnonFrieghtGrid" runat="server" UpdateMode="Conditional">
                                                                        <ContentTemplate>
                                                                            <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="FrieghtSearch" OnTextChanged="FrieghtSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                            </div>

                                                                            <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                                <asp:GridView ID="FrieghtGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="FrieghtGrid_PageIndexChanging" OnRowDataBound="FrieghtGrid_RowDataBound" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" AutoGenerateColumns="false" OnRowCommand="FrieghtGrid_RowCommand">
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
                                                                    <asp:Button ID="btnYesinnonfreight" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                    <asp:Button ID="btnNoinnonfreight" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px] mt-4 w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                </div>
                                                            </asp:Panel>

                                                        </div>


                                                        <div id="OutParty" visible="false" runat="server">

                                                            <div class="flex justify-between gap-2 items-center mt-7">
                                                                <h2 class="text-lg sa700 leading-[18px] text-gray-800">Outward Carrier Agent</h2>

                                                                <div class="flex gap-1.5">
                                                                    <asp:ImageButton ID="btninnonout" CssClass="theme_searchIcon" runat="server" ImageUrl="images/searchBlue.png" Height="28" Width="28" />

                                                                    <asp:Button ID="OutwardAdd" runat="server" CssClass="plusbtn plusbtnIcon" BorderWidth="0px" ValidationGroup="Partyout" OnClick="OutwardAdd_Click" Text="+" />


                                                                </div>
                                                            </div>

                                                            <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label for="staticEmail" class="text-gray-500 text-sm font-medium">Code</label>
                                                                    <div class="relative mt-1">

                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" OnTextChanged="OutwardCode_TextChanged" placeholder="" AutoPostBack="true" ID="OutwardCode" TabIndex="24" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
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

                                                                    </div>
                                                                </div>
                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">CR UEI</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="OutwardCRUEI" placeholder="" runat="server" TabIndex="25" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Name 1 </label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="OutwardName" placeholder="" runat="server" ValidationGroup="Payout" TabIndex="26" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Name 2</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="OutwardName1" placeholder="" ValidationGroup="Payout" runat="server" TabIndex="27" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <cc1:ModalPopupExtender ID="popupinnonout" runat="server" PopupControlID="pnlinnonout" TargetControlID="btninnonout"
                                                                OkControlID="btnYesinnonout" CancelControlID="btnNoinnonout" BackgroundCssClass="modalBackground">
                                                            </cc1:ModalPopupExtender>

                                                            <asp:Panel ID="pnlinnonout" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                                <div class="header">
                                                                    <%-- <svg class="cursor-pointer absolute right-5 top-5" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
      <circle opacity="0.1" cx="12" cy="12" r="12" fill="#676D7C"></circle>
      <path d="M16.6663 7.3335L7.33301 16.6668M7.33301 7.3335L16.6663 16.6668" stroke="#676D7C" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
    </svg>--%>
                                                                    <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Outward Carrier Agent Search</p>
                                                                </div>

                                                                <div class="body">
                                                                    <asp:UpdatePanel ID="upinnonoutgrid" runat="server" UpdateMode="Conditional">
                                                                        <ContentTemplate>
                                                                            <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="OutwardSearch" OnTextChanged="OutwardSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                            </div>

                                                                            <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                                <asp:GridView ID="OutwardGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="OutwardGrid_PageIndexChanging" OnRowDataBound="OutwardGrid_RowDataBound" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" AutoGenerateColumns="false" OnRowCommand="OutwardGrid_RowCommand">
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

                                                                                                <asp:LinkButton ID="LmkOutward" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LmkOutward_Command" CssClass="duration-300 ease-in-out md:max-w-[200px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700">Select </asp:LinkButton>

                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </div>
                                                                        </ContentTemplate>

                                                                    </asp:UpdatePanel>

                                                                </div>
                                                                <div class="footer" align="right">
                                                                    <asp:Button ID="btnYesinnonout" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                    <asp:Button ID="btnNoinnonout" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px] mt-4 w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                </div>
                                                            </asp:Panel>

                                                        </div>




                                                        <div id="ConsigneeParty" visible="false" runat="server">

                                                            <div class="flex justify-between gap-2 items-center mt-7">
                                                                <h2 class="text-lg sa700 leading-[18px] text-gray-800">Consignee</h2>

                                                                <div class="flex gap-1.5">
                                                                    <asp:ImageButton ID="btninnonconsigne" CssClass="theme_searchIcon" runat="server" ImageUrl="images/searchBlue.png" Height="28" Width="28" />

                                                                    <asp:Button ID="ConsigneeAdd" runat="server" CssClass="plusbtn plusbtnIcon" BorderWidth="0px" ValidationGroup="PartyClaimant" OnClick="ConsigneeAdd_Click" Text="+" />


                                                                </div>
                                                            </div>

                                                            <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label for="staticEmail" class="text-gray-500 text-sm font-medium">Code</label>
                                                                    <div class="relative mt-1">

                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" OnTextChanged="ConsigneeCode_TextChanged" placeholder="" AutoPostBack="true" ID="ConsigneeCode" TabIndex="24" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
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

                                                                    </div>
                                                                </div>

                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Name</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ConsigneeName" placeholder="" runat="server" TabIndex="27" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeSub" ID="RegularExpressionValidator15" ValidationExpression="^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>

                                                                    </div>
                                                                </div>

                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium"></label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ConsigneeName1" placeholder="" runat="server" TabIndex="27" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" ValidationGroup="PartyClaimant"></asp:TextBox>

                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator78" runat="server" ControlToValidate="ConsigneeName1" Display="None" ErrorMessage="Party --> Claimant Agent Name is Required" ValidationGroup="PartyClaimant"></asp:RequiredFieldValidator>

                                                                    </div>
                                                                </div>

                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">CR UEI</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ConsigneeCRUEI" placeholder="CR UEI" runat="server" TabIndex="25" ValidationGroup="PartyClaimant" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeCRUEI" ID="RegularExpressionValidator68" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>

                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">

                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Address </label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ConsigneeAddress" placeholder="Address" runat="server" ValidationGroup="PartyClaimant" TabIndex="26" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator80" runat="server" ControlToValidate="ConsigneeAddress" Display="None" ErrorMessage="Party --> Consignee Address is Required" ValidationGroup="PartyClaimant"></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeAddress" ID="RegularExpressionValidator3" ValidationExpression="^[\s\S]{0,160}$" runat="server" ErrorMessage="Maximum 160 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>

                                                                    </div>
                                                                </div>

                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium"></label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ConsigneeAddress1" placeholder="ConsigneeAddress1" runat="server" TabIndex="27" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" ValidationGroup="PartyClaimant"></asp:TextBox>
                                                                    </div>
                                                                </div>

                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">City Name</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ConsigneeCity" placeholder="City Name" runat="server" TabIndex="27" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" ValidationGroup="PartyClaimant"></asp:TextBox>

                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeCity" ID="RegularExpressionValidator5" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>

                                                                    </div>
                                                                </div>

                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Country Subdivision Code</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ConsigneeSub" placeholder="Country Subdivision Code" ValidationGroup="PartyClaimant" runat="server" TabIndex="27" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeSub" ID="RegularExpressionValidator7" ValidationExpression="^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>

                                                                    </div>
                                                                </div>

                                                            </div>

                                                            <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">

                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Country Subdivision</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ConsigneeSubDivi" placeholder="Country Subdivision" runat="server" TabIndex="27" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" ValidationGroup="PartyClaimant"></asp:TextBox>

                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeSubDivi" ID="RegularExpressionValidator91" ValidationExpression="^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>

                                                                    </div>
                                                                </div>

                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Postal Code</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ConsigneePostal" placeholder="" runat="server" TabIndex="27" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" ValidationGroup="PartyClaimant"></asp:TextBox>

                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneePostal" ID="RegularExpressionValidator8" ValidationExpression="^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>

                                                                    </div>
                                                                </div>


                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Country Code</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ConsigneeCountry" placeholder="Country Code" runat="server" TabIndex="27" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" ValidationGroup="PartyClaimant" Style="background-color: #f1f5f9 !important;"></asp:TextBox>

                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeSub" ID="RegularExpressionValidator1" ValidationExpression="^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>

                                                                    </div>
                                                                </div>


                                                                <div class="md:max-w-[250px] w-full"></div>

                                                            </div>

                                                            <cc1:ModalPopupExtender ID="popupinnonconsignee" runat="server" PopupControlID="pnlinnonconsignee" TargetControlID="btninnonconsigne"
                                                                OkControlID="btnYesinnonconsignee" CancelControlID="btnNoinnonconsignee" BackgroundCssClass="modalBackground">
                                                            </cc1:ModalPopupExtender>

                                                            <asp:Panel ID="pnlinnonconsignee" runat="server" CssClass="modalPopup md:max-w-[1200px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                                <div class="header">
                                                                    <%--  <svg class="cursor-pointer absolute right-5 top-5" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
      <circle opacity="0.1" cx="12" cy="12" r="12" fill="#676D7C"></circle>
      <path d="M16.6663 7.3335L7.33301 16.6668M7.33301 7.3335L16.6663 16.6668" stroke="#676D7C" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
    </svg>--%>
                                                                    <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Consignee Search</p>
                                                                </div>

                                                                <div class="body">
                                                                    <asp:UpdatePanel ID="upinnonConsigneeGrid" runat="server" UpdateMode="Conditional">
                                                                        <ContentTemplate>
                                                                            <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ConsigneeSearch" OnTextChanged="ConsigneeSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                            </div>

                                                                            <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">

                                                                                <asp:GridView ID="ConsigneeGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ConsigneeGrid_PageIndexChanging" OnRowDataBound="ConsigneeGrid_RowDataBound" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" AutoGenerateColumns="false" OnRowCommand="ConsigneeGrid_RowCommand" Style="overflow: auto !important;">
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
                                                                                                <asp:Label ID="lblName" runat="server"
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
                                                                                        <asp:TemplateField HeaderText="CRUEI" SortExpression="Id">
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

                                                                                        <asp:TemplateField HeaderText="Address1" SortExpression="Id">
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

                                                                                        <asp:TemplateField HeaderText="Country" SortExpression="Id" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="ConsigneeCountry" runat="server"
                                                                                                    Text='<%#Eval("ConsigneeCountry")%>'>
                                                                                                </asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>

                                                                                        <asp:TemplateField Visible="false">
                                                                                            <ItemTemplate>

                                                                                                <asp:LinkButton ID="LmkConsignee" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LmkConsignee_Command" CssClass="duration-300 ease-in-out md:max-w-[200px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700">Select </asp:LinkButton>

                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </div>
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:PostBackTrigger ControlID="ImporterGrid" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>

                                                                </div>
                                                                <div class="footer" align="right">
                                                                    <asp:Button ID="btnYesinnonconsignee" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                    <asp:Button ID="btnNoinnonconsignee" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px] mt-4 w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                </div>
                                                            </asp:Panel>

                                                        </div>


                                                        <div id="ClaimantParty" visible="false" runat="server">

                                                            <div class="flex justify-between gap-2 items-center mt-7">
                                                                <h2 class="text-lg sa700 leading-[18px] text-gray-800">Claimant Party</h2>

                                                                <div class="flex gap-1.5">
                                                                    <asp:ImageButton ID="btninnonclaimant" CssClass="theme_searchIcon" runat="server" ImageUrl="images/searchBlue.png" Height="28" Width="28" />

                                                                    <asp:Button ID="ClaimantAdd" runat="server" CssClass="plusbtn plusbtnIcon" BorderWidth="0px" ValidationGroup="CLAIMANT" OnClick="ClaimantAdd_Click" Text="+" />


                                                                </div>
                                                            </div>

                                                            <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label for="staticEmail" class="text-gray-500 text-sm font-medium">Code</label>
                                                                    <div class="relative mt-1">

                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" OnTextChanged="ClaimantName_TextChanged" placeholder="" AutoPostBack="true" ID="ClaimantName" TabIndex="24" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
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

                                                                    </div>
                                                                </div>
                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">CR UEI</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ClaimantCRUEI" placeholder="" runat="server" TabIndex="25" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                                        <asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator101" runat="server" ControlToValidate="ClaimantCRUEI" Display="None" ErrorMessage="Party --> CLAIMANT PARTY CRUEI" ValidationGroup="CLAIMANT"></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ClaimantCRUEI" ID="RegularExpressionValidator65" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="CLAIMANT"></asp:RegularExpressionValidator>


                                                                    </div>
                                                                </div>
                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Name 1 </label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ClaimantName1" placeholder="" runat="server" ValidationGroup="CLAIMANT" TabIndex="26" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Name 2</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ClaimantName2" placeholder="Claimant Name" ValidationGroup="CLAIMANT" runat="server" TabIndex="27" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    </div>
                                                                </div>

                                                            </div>

                                                            <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Claimant Name</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ClaimantNameC" placeholder="Claimant Name" ValidationGroup="Payout" runat="server" TabIndex="27" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Claimant Name</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ClaimantName1C" placeholder="Claimant ID" ValidationGroup="CLAIMANT" runat="server" TabIndex="27" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <cc1:ModalPopupExtender ID="popupinnonclaimant" runat="server" PopupControlID="pnlinnonclaimant" TargetControlID="btninnonclaimant"
                                                                OkControlID="btnYesinnonclaimant" CancelControlID="btnNoinnonclaimant" BackgroundCssClass="modalBackground">
                                                            </cc1:ModalPopupExtender>

                                                            <asp:Panel ID="pnlinnonclaimant" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                                <div class="header">
                                                                    <svg class="cursor-pointer absolute right-5 top-5" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                        <circle opacity="0.1" cx="12" cy="12" r="12" fill="#676D7C"></circle>
                                                                        <path d="M16.6663 7.3335L7.33301 16.6668M7.33301 7.3335L16.6663 16.6668" stroke="#676D7C" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                                                    </svg>
                                                                    <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Claimant Party Search</p>
                                                                </div>

                                                                <div class="body">
                                                                    <asp:UpdatePanel ID="upClaimantGrid" runat="server" UpdateMode="Conditional">
                                                                        <ContentTemplate>
                                                                            <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ClaimantSearch" OnTextChanged="ClaimantSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                            </div>

                                                                            <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                                <asp:GridView ID="ClaimantGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ClaimantGrid_PageIndexChanging" OnRowDataBound="ClaimantGrid_RowDataBound" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" AutoGenerateColumns="false" OnRowCommand="ClaimantGrid_RowCommand">
                                                                                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                    <Columns>

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
                                                                    <asp:Button ID="btnYesinnonclaimant" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                    <asp:Button ID="btnNoinnonclaimant" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px] mt-4 w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                </div>
                                                            </asp:Panel>

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


                                                    </ContentTemplate>
                                                </asp:UpdatePanel>


                                            </ContentTemplate>
                                        </cc1:TabPanel>


                                        <cc1:TabPanel ID="tabCargo" runat="server" HeaderText="Cargo">
                                            <ContentTemplate>
                                                <asp:UpdatePanel ID="upinnoncargo" UpdateMode="Conditional" runat="server">
                                                    <ContentTemplate>
                                                        <div class="grid grid-cols-1 md:grid-cols-2 gap-6 mt-4 mb-2">
                                                            <!-- Left Column -->
                                                            <div class="space-y-4">


                                                                <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-7">
                                                                    <span class="text-white text-sm font-semibold tracking-wide">Inward Details</span>
                                                                    <asp:Label ID="Label5" Visible="false" runat="server"></asp:Label>
                                                                </div>

                                                                <div id="carMode" runat="server" class="w-full flex items-center gap-2">
                                                                    <label class="text-gray-500 text-sm font-medium w-[200px]">Mode</label>
                                                                    <div class="relative mt-1 w-full">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" Enabled="false" runat="server" type="text" ID="TextMode" OnTextChanged="TextMode_TextChanged" AutoPostBack="true" TabIndex="83" CssClass="w-full h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div id="load" runat="server"></div>
                                                                <div class="w-full flex items-center gap-2">
                                                                    <label class="text-gray-500 text-sm font-medium w-[200px]">Arrival Date</label>
                                                                    <div class="relative mt-1 w-full">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtArrivalDate1" TabIndex="79" runat="server" AutoPostBack="true" OnTextChanged="TxtArrivalDate1_TextChanged" onkeypress="return isNumberKey(event)" CssClass="w-full h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <cc1:CalendarExtender CssClass="cal_Theme1" ID="CalendarExtender2" PopupButtonID="imgPopup" runat="server" TargetControlID="TxtArrivalDate1" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"></cc1:CalendarExtender>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="TxtArrivalDate1" Display="None" ErrorMessage="Cargo --> Arrival Date is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>

                                                                        <asp:Label ID="alertarrival" runat="server" ForeColor="Red"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="flex items-center gap-4 w-full">

                                                                    <!-- Label and Search Icon -->
                                                                    <div class="flex items-center gap-2 flex-shrink-0 w-[133px]">
                                                                        <div class="text-gray-500 text-sm font-medium">
                                                                            Loading Port
                                                                    <asp:ImageButton ID="btninnonloadingport1" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" />
                                                                        </div>
                                                                    </div>

                                                                    <div id="lodprtdiv" runat="server" class="w-[120px]">
                                                                        <div class="group relative">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="TxtLoadShort" OnTextChanged="TxtLoadShort_TextChanged" AutoPostBack="true" TabIndex="80" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

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

                                                                            <cc1:ModalPopupExtender ID="popupinnonloadingport" runat="server" PopupControlID="pnlinnonloadingport" TargetControlID="btninnonloadingport1" OkControlID="btnYesinnonloadingport" CancelControlID="btnNoinnonloadingport" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>

                                                                            <asp:Panel ID="pnlinnonloadingport" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white" Style="display: none">
                                                                                <div class="header">

                                                                                    <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Loading Port</p>
                                                                                </div>

                                                                                <div class="body">
                                                                                    <asp:UpdatePanel ID="upimpgrid" runat="server" UpdateMode="Conditional">
                                                                                        <ContentTemplate>
                                                                                            <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                                <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="CarLoadingSearch" OnTextChanged="CarLoadingSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server" TabIndex="81"></asp:TextBox>
                                                                                            </div>

                                                                                            <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                                                <asp:GridView ID="LoadingGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="LoadingGrid_PageIndexChanging" OnRowCommand="LoadingGrid_RowCommand" OnRowDataBound="LoadingGrid_RowDataBound" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" AutoGenerateColumns="false">
                                                                                                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                    <Columns>
                                                                                                        <asp:TemplateField HeaderText="PortCode" SortExpression="Id">
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblCode" runat="server" Text='<%#Eval("PortCode")%>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="PortName" SortExpression="Id">
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblName" runat="server" Text='<%#Eval("PortName")%>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="Country" SortExpression="Id">
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblName1" runat="server" Text='<%#Eval("Country")%>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField Visible="false">
                                                                                                            <ItemTemplate>
                                                                                                                <asp:LinkButton ID="LnkLoading" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkLoading_Command" CssClass="duration-300 ease-in-out md:max-w-[200px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700">Select</asp:LinkButton>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                    </Columns>
                                                                                                </asp:GridView>
                                                                                            </div>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                </div>

                                                                                <div class="footer" align="right">
                                                                                    <asp:Button ID="btnYesinnonloadingport" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                                    <asp:Button ID="btnNoinnonloadingport" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px] mt-4 w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                                </div>
                                                                            </asp:Panel>


                                                                        </div>
                                                                    </div>

                                                                    <div class="flex-1">
                                                                        <div class="relative">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="TxtLoad" TabIndex="82" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        </div>
                                                                    </div>

                                                                </div>


                                                                <div id="inhawbl" runat="server" class=" w-full flex items-center gap-2">
                                                                    <label class="text-gray-500 text-sm font-medium w-[202px]" id="inhab1" runat="server">In HAWB/HBL</label>
                                                                    <label class="text-gray-500 text-sm font-medium invisible" id="phawb1" runat="server" visible="false">HAWB</label>
                                                                    <label class="text-gray-500 text-sm font-medium invisible" id="inhbl1" runat="server" visible="false">HBL</label>

                                                                    <div class="relative mt-1 w-full">

                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="txthblCargo" TabIndex="84" AutoPostBack="true" OnTextChanged="txthblCargo_TextChanged" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    </div>
                                                                </div>



                                                                <div id="inwa" runat="server">
                                                                    <div id="InwardFlight" runat="server" class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                                        <div class="md:max-w-[250px] w-full">
                                                                            <label class="text-gray-500 text-sm font-medium">Flight Number</label>
                                                                            <div class="relative mt-1">
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="txtflight" TabIndex="93" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtflight" Display="None" ErrorMessage="Cargo -->Flight Number is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                            </div>
                                                                        </div>
                                                                        <div class="md:max-w-[250px] w-full">
                                                                            <label class="text-gray-500 text-sm font-medium">Aircraft Register Number</label>
                                                                            <div class="relative mt-1">
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" MaxLength="17" type="text" ID="txtaircraft" TabIndex="94" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            </div>
                                                                        </div>

                                                                        <div class="md:max-w-[250px] w-full">
                                                                            <label class="text-gray-500 text-sm font-medium">Master Air Waybill</label>
                                                                            <div class="relative mt-1">
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" OnTextChanged="txtwaybill_TextChanged" AutoPostBack="true" type="text" ID="txtwaybill" TabIndex="95" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtwaybill" Display="None" ErrorMessage="Cargo -->Master Air Waybill is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                    <div id="InwardSea" runat="server" class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">


                                                                        <div class="md:max-w-[250px] w-full">
                                                                            <label class="text-gray-500 text-sm font-medium">Voyage Number</label>
                                                                            <div class="relative mt-1">
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" MaxLength="17" type="text" ID="TxtVoyageno" TabIndex="96" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="TxtVoyageno" Display="None" ErrorMessage="Cargo -->Voyage Number is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                            </div>
                                                                        </div>
                                                                        <div class="md:max-w-[250px] w-full">
                                                                            <label class="text-gray-500 text-sm font-medium">Vessel Name</label>
                                                                            <div class="relative mt-1">
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="TxtVesselName" TabIndex="97" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="TxtVesselName" Display="None" ErrorMessage="Cargo -->Vessel Name is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                            </div>
                                                                        </div>

                                                                        <div class="md:max-w-[250px] w-full">
                                                                            <label class="text-gray-500 text-sm font-medium">OBL</label>
                                                                            <div class="relative mt-1">
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" OnTextChanged="TxtOceanBill_TextChanged" AutoPostBack="true" type="text" ID="TxtOceanBill" TabIndex="98" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="TxtOceanBill" Display="None" ErrorMessage="Cargo -->Ocean Bill Of Lading Number is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                            </div>
                                                                        </div>


                                                                    </div>

                                                                    <div id="InwardOther" runat="server" class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                                        <div class="md:max-w-[250px] w-full">
                                                                            <label class="text-gray-500 text-sm font-medium">Conveyance Ref.No</label>
                                                                            <div class="relative mt-1">
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="TxtConRefNo" TabIndex="99" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            </div>
                                                                        </div>

                                                                        <div class="md:max-w-[250px] w-full">
                                                                            <label class="text-gray-500 text-sm font-medium">Transport ID</label>
                                                                            <div class="relative mt-1">
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="TxtTrnsID" TabIndex="100" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>


                                                                            </div>
                                                                        </div>
                                                                    </div>



                                                                </div>

                                                                <!-- Left Column -->
                                                                <div class="space-y-4">

                                                                    <div id="OutwardDiv" runat="server" visible="false">

                                                                        <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-7">
                                                                            <span class="text-white text-sm font-semibold tracking-wide">Outward Details</span>
                                                                            <asp:Label ID="Label7" Visible="false" runat="server"></asp:Label>
                                                                        </div>

                                                                        <%--                                                            <div class="flex justify-between gap-2 items-center mt-7">
                                                                <h2 class="text-lg sa700 leading-[18px] text-gray-800">
                                                                </h2>
                                                            </div>--%>

                                                                        <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                                            <div class="md:max-w-[500px] w-full">
                                                                                <label class="text-gray-500 text-sm font-medium">Mode</label>
                                                                                <div class="relative mt-1">
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" Enabled="false" runat="server" type="text" ID="TxtExpMode" OnTextChanged="TxtExpMode_TextChanged" AutoPostBack="true" TabIndex="100" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="md:max-w-[500px] w-full">
                                                                                <label class="text-gray-500 text-sm font-medium">Departure Date</label>
                                                                                <div class="relative mt-1">
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtExpArrivalDate1" runat="server" AutoPostBack="true" TabIndex="101" onkeypress="return isNumberKey(event)" OnTextChanged="TxtExpArrivalDate1_TextChanged" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                    <cc1:CalendarExtender ID="CalendarExtender6" PopupButtonID="imgPopup" runat="server" TargetControlID="TxtExpArrivalDate1" CssClass="cal_Theme1" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"></cc1:CalendarExtender>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ControlToValidate="TxtExpArrivalDate1" Display="None" ErrorMessage="Cargo --> Arrival Date is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                    <asp:Label ID="alertdeparture" runat="server" ForeColor="Red"></asp:Label>
                                                                                </div>
                                                                            </div>

                                                                        </div>

                                                                        <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2" id="dischargeport" runat="server">

                                                                            <div class="md:max-w-[250px] w-full">
                                                                                <div class="text-gray-500 text-sm font-medium">
                                                                                    Discharge Port
                            <asp:ImageButton ID="btninnondischargeport" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" />
                                                                                </div>
                                                                                <div class="group relative mt-1">

                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="TxtExpLoadShort" OnTextChanged="TxtExpLoadShort_TextChanged" AutoPostBack="true" TabIndex="90" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
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

                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ControlToValidate="TxtExpLoadShort" Display="None" ErrorMessage="Cargo --> Discharge Port is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>

                                                                                    <cc1:ModalPopupExtender ID="popupinnondichargeport" runat="server" PopupControlID="pnlinnondichargeport" TargetControlID="btninnondischargeport" OkControlID="btnYesinnondichargeport" CancelControlID="btninnondischargeport11" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>

                                                                                    <asp:Panel ID="pnlinnondichargeport" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white" Style="display: none">
                                                                                        <div class="header">
                                                                                            <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Discharge Port</p>

                                                                                        </div>
                                                                                        <div class="body">
                                                                                            <asp:UpdatePanel ID="upinnondischargeport" runat="server" UpdateMode="Conditional">
                                                                                                <ContentTemplate>

                                                                                                    <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                                        <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ExpLoadingSearch" OnTextChanged="ExpLoadingSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                        <br />
                                                                                                    </div>

                                                                                                    <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                                                        <asp:GridView ID="ExportGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ExportGrid_PageIndexChanging" OnRowCommand="ExportGrid_RowCommand" OnRowDataBound="ExportGrid_RowDataBound" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" AutoGenerateColumns="false">
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
                                                                                                                        <asp:LinkButton ID="LnkExport" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkExport_Command">Select </asp:LinkButton>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                            </Columns>
                                                                                                        </asp:GridView>

                                                                                                    </div>

                                                                                                </ContentTemplate>
                                                                                                <%-- <Triggers>
            <asp:PostBackTrigger ControlID="LoadingGrid" />
            </Triggers>--%>
                                                                                            </asp:UpdatePanel>
                                                                                        </div>
                                                                                        <div class="footer" align="right">
                                                                                            <asp:Button ID="btnYesinnondichargeport" runat="server" Text="Yes" CssClass="yes" />
                                                                                            <asp:Button ID="btninnondischargeport11" runat="server" Text="Close" CssClass="no" />
                                                                                        </div>
                                                                                    </asp:Panel>


                                                                                </div>
                                                                            </div>
                                                                            <div class="md:max-w-[250px] w-full">
                                                                                <label class="text-gray-500 text-sm font-medium">Details</label>
                                                                                <div class="relative mt-1">
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="TxtExpLoad" TabIndex="87" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="md:max-w-[250px] w-full">
                                                                                <label class="text-gray-500 text-sm font-medium">Final Destination Country</label>
                                                                                <div class="relative mt-1">
                                                                                    <asp:DropDownList runat="server" ID="DrpFinalDesCountry" TabIndex="103" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:DropDownList>
                                                                                </div>
                                                                            </div>

                                                                        </div>

                                                                        <div class="flex justify-between gap-2 items-center mt-7">
                                                                            <h2 class="text-lg sa700 leading-[18px] text-gray-800">Sea Store
                                                                            </h2>
                                                                        </div>

                                                                        <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2" style="display: none;">
                                                                            <div class="md:max-w-[200px] w-full">
                                                                                <div class="flex gap-4 items-center">
                                                                                    <asp:CheckBox ID="chkSea" AutoPostBack="true" OnCheckedChanged="chkSea_CheckedChanged1" runat="server" TabIndex="7" />
                                                                                    <label for="ChkRefDoc" class="text-gray-500 text-sm font-medium">Sea Store</label>
                                                                                </div>
                                                                            </div>
                                                                            <div class="md:max-w-[200px] w-full"></div>
                                                                            <div class="md:max-w-[200px] w-full"></div>
                                                                            <div class="md:max-w-[200px] w-full"></div>
                                                                        </div>

                                                                        <div id="OUTWARDFlight" runat="server" class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                                            <div class="md:max-w-[250px] w-full">
                                                                                <label class="text-gray-500 text-sm font-medium">Flight Number</label>
                                                                                <div class="relative mt-1">
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="Validation" type="text" ID="OUTWARDFlightN0" TabIndex="105" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ControlToValidate="OUTWARDFlightN0" Display="None" ErrorMessage="Cargo -->Flight Number is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="OUTWARDFlightN0" ID="RegularExpressionValidator78" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                </div>
                                                                            </div>
                                                                            <div class="md:max-w-[250px] w-full">
                                                                                <label class="text-gray-500 text-sm font-medium">Aircraft Register Number</label>
                                                                                <div class="relative mt-1">
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="Validation" type="text" ID="OUTWARDAirREgno" TabIndex="106" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="OUTWARDAirREgno" ID="RegularExpressionValidator79" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                </div>
                                                                            </div>
                                                                            <div class="md:max-w-[250px] w-full">
                                                                                <label class="text-gray-500 text-sm font-medium">Master Air Waybill</label>
                                                                                <div class="relative mt-1">
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="Validation" type="text" OnTextChanged="OUTWARDAirwaybill_TextChanged" AutoPostBack="true" ID="OUTWARDAirwaybill" TabIndex="107" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator50" runat="server" ControlToValidate="OUTWARDAirwaybill" Display="None" ErrorMessage="Cargo -->Master Air Waybill is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                    <asp:RegularExpressionValidator BackColor="Yellow" ID="RegularExpressionValidator80" runat="server" Display="None" ControlToValidate="OUTWARDAirwaybill" ValidationExpression="^[\s\S]{0,35}$" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Validation" />
                                                                                </div>
                                                                            </div>

                                                                        </div>

                                                                        <div id="OUTWARDSea" runat="server" class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                                            <div class="md:max-w-[250px] w-full">
                                                                                <label class="text-gray-500 text-sm font-medium">Voyage Number</label>
                                                                                <div class="relative mt-1">
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="Validation" type="text" ID="OUTWARDVoyageNo" TabIndex="108" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator52" runat="server" ControlToValidate="OUTWARDVoyageNo" Display="None" ErrorMessage="Cargo -->Voyage Number is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="OUTWARDVoyageNo" ID="RegularExpressionValidator81" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                </div>
                                                                            </div>
                                                                            <div class="md:max-w-[250px] w-full">
                                                                                <label class="text-gray-500 text-sm font-medium">Vessel Name</label>
                                                                                <div class="relative mt-1">
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="Validation" type="text" ID="OUTWARDVessel" TabIndex="109" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator53" runat="server" ControlToValidate="OUTWARDVessel" Display="None" ErrorMessage="Cargo -->Vessel Name is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="OUTWARDVessel" ID="RegularExpressionValidator82" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                </div>
                                                                            </div>
                                                                            <div class="md:max-w-[250px] w-full">
                                                                                <label class="text-gray-500 text-sm font-medium">OBL</label>
                                                                                <div class="relative mt-1">
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="Validation" OnTextChanged="OUTWARDOcenbill_TextChanged" AutoPostBack="true" type="text" ID="OUTWARDOcenbill" TabIndex="110" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator54" runat="server" ControlToValidate="OUTWARDOcenbill" Display="None" ErrorMessage="Cargo -->Ocean Bill Of Lading Number is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="OUTWARDOcenbill" ID="RegularExpressionValidator83" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                </div>
                                                                            </div>

                                                                        </div>

                                                                        <div id="outhbl" runat="server" class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                                            <div class="md:max-w-[250px] w-full">
                                                                                <label class="text-gray-500 text-sm font-medium">Out HAWB/HBL</label>
                                                                                <div class="relative mt-1">
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="txtouthblCargo" TabIndex="111" AutoPostBack="true" OnTextChanged="txtouthblCargo_TextChanged" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator106" runat="server" ControlToValidate="txtflight" Display="None" ErrorMessage="Cargo -->Flight Number is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>

                                                                        </div>

                                                                        <div id="OUTWARDOther" runat="server" class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                                            <div class="md:max-w-[250px] w-full">
                                                                                <label class="text-gray-500 text-sm font-medium">Conveyance Ref.No</label>
                                                                                <div class="relative mt-1">
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="Validation" type="text" ID="OUTWARDConref" TabIndex="112" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="OUTWARDConref" ID="RegularExpressionValidator84" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                </div>
                                                                            </div>
                                                                            <div class="md:max-w-[250px] w-full">
                                                                                <label class="text-gray-500 text-sm font-medium">Transport ID</label>
                                                                                <div class="relative mt-1">
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="Validation" type="text" ID="OUTWARDTransId" TabIndex="113" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="OUTWARDTransId" ID="RegularExpressionValidator85" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                </div>
                                                                            </div>

                                                                        </div>

                                                                        <div id="OUTWARDVesl" runat="server">
                                                                            <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                                                <div class="md:max-w-[250px] w-full">
                                                                                    <label class="text-gray-500 text-sm font-medium">Vessel Type</label>
                                                                                    <div class="relative mt-1">
                                                                                        <asp:DropDownList ID="ddpVessel" runat="server" TabIndex="114" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:DropDownList>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator55" runat="server" ControlToValidate="ddpVessel" Display="None" ErrorMessage="Cargo -->Master Air Waybill is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="md:max-w-[250px] w-full">
                                                                                    <label class="text-gray-500 text-sm font-medium">Vessel Net Register Tonnage</label>
                                                                                    <div class="relative mt-1">
                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="txtvesnet" TabIndex="115" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="md:max-w-[250px] w-full">
                                                                                    <label class="text-gray-500 text-sm font-medium">Vessel Nationality</label>
                                                                                    <div class="relative mt-1">
                                                                                        <asp:DropDownList runat="server" ID="DroVesslNat" TabIndex="116" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:DropDownList>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="md:max-w-[250px] w-full">
                                                                                    <label class="text-gray-500 text-sm font-medium">Towing Vessel ID</label>
                                                                                    <div class="relative mt-1">
                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="txtTowVes" TabIndex="117" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                                                <div class="md:max-w-[250px] w-full">
                                                                                    <label class="text-gray-500 text-sm font-medium">Towing Vessel Name</label>
                                                                                    <div class="relative mt-1">
                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="txtTowVesName" TabIndex="118" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="md:max-w-[250px] w-full">
                                                                                    <div class="text-gray-500 text-sm font-medium">
                                                                                        Next Port
                            <asp:Button ID="btninnonnxtport" TabIndex="120" runat="server" Text="Search" />
                                                                                    </div>
                                                                                    <div class="group relative mt-1">

                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" Style="text-transform: uppercase" type="text" ID="txtNextprt" AutoPostBack="true" OnTextChanged="txtNextprt_TextChanged" TabIndex="121"></asp:TextBox>

                                                                                        <cc1:ModalPopupExtender ID="popupinnonnxtport" runat="server" PopupControlID="pnlinnonnxtport" TargetControlID="btninnonnxtport" OkControlID="btnYesinnonnxtport" CancelControlID="btnNoinnonnxtport" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>

                                                                                        <asp:Panel ID="pnlinnonnxtport" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                            <div class="header">
                                                                                                NEXT PORT 
                                                                                            </div>
                                                                                            <div class="body">
                                                                                                <asp:UpdatePanel ID="upinnonnxtport" runat="server" UpdateMode="Conditional">
                                                                                                    <ContentTemplate>

                                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="NextPrtLoading" OnTextChanged="NextPrtLoading_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox><br />

                                                                                                        <asp:GridView ID="NextPortGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="NextPortGrid_PageIndexChanging" OnRowCommand="NextPortGrid_RowCommand" OnRowDataBound="NextPortGrid_RowDataBound" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" AutoGenerateColumns="false">
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
                                                                                                    <%-- <Triggers>
            <asp:PostBackTrigger ControlID="LoadingGrid" />
            </Triggers>--%>
                                                                                                </asp:UpdatePanel>
                                                                                            </div>
                                                                                            <div class="footer" align="right">
                                                                                                <asp:Button ID="btnYesinnonnxtport" runat="server" Text="Yes" CssClass="yes" />
                                                                                                <asp:Button ID="btnNoinnonnxtport" runat="server" Text="No" CssClass="no" />
                                                                                            </div>
                                                                                        </asp:Panel>


                                                                                    </div>
                                                                                </div>
                                                                                <div class="md:max-w-[250px] w-full">
                                                                                    <label class="text-gray-500 text-sm font-medium">Details</label>
                                                                                    <div class="relative mt-1">
                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="txtNetPrtSer" Style="text-transform: uppercase" TabIndex="122" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="md:max-w-[250px] w-full"></div>
                                                                            </div>
                                                                            <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                                                <div class="md:max-w-[250px] w-full">
                                                                                    <div class="text-gray-500 text-sm font-medium">
                                                                                        Last Port
                            <asp:Button ID="btninnonlastport" TabIndex="120" runat="server" Text="Search" />
                                                                                    </div>
                                                                                    <div class="group relative mt-1">

                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" Style="text-transform: uppercase" type="text" ID="txtLasPrt" AutoPostBack="true" OnTextChanged="txtLasPrt_TextChanged" TabIndex="121"></asp:TextBox>

                                                                                        <cc1:ModalPopupExtender ID="popupinnonlastport" runat="server" PopupControlID="pnlinnonlastport" TargetControlID="btninnonlastport" OkControlID="btnYesinnonlastport" CancelControlID="btnNoinnonlastport" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>

                                                                                        <asp:Panel ID="pnlinnonlastport" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                            <div class="header">
                                                                                                LAST PORT 
                                                                                            </div>
                                                                                            <div class="body">
                                                                                                <asp:UpdatePanel ID="upinnonolastport" runat="server" UpdateMode="Conditional">
                                                                                                    <ContentTemplate>

                                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txtlastprt" OnTextChanged="txtlastprt_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox><br />

                                                                                                        <asp:GridView ID="LastGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="LastGrid_PageIndexChanging" OnRowCommand="LastGrid_RowCommand" OnRowDataBound="LastGrid_RowDataBound" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" AutoGenerateColumns="false">
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

                                                                                                </asp:UpdatePanel>
                                                                                            </div>
                                                                                            <div class="footer" align="right">
                                                                                                <asp:Button ID="btnYesinnonlastport" runat="server" Text="Yes" CssClass="yes" />
                                                                                                <asp:Button ID="btnNoinnonlastport" runat="server" Text="No" CssClass="no" />
                                                                                            </div>
                                                                                        </asp:Panel>


                                                                                    </div>
                                                                                </div>
                                                                                <div class="md:max-w-[250px] w-full">
                                                                                    <label class="text-gray-500 text-sm font-medium">Details</label>
                                                                                    <div class="relative mt-1">
                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="txtLasPrtSer" Style="text-transform: uppercase" TabIndex="122" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="md:max-w-[250px] w-full"></div>
                                                                                <div class="md:max-w-[250px] w-full"></div>
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                </div>




                                                            </div>

                                                            <div class="space-y-4">



                                                                <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-7">
                                                                    <span class="text-white text-sm font-semibold tracking-wide">Outer Pack Details</span>
                                                                    <asp:Label ID="Label4" Visible="false" runat="server"></asp:Label>
                                                                </div>
                                                                <div class="flex flex-wrap gap-4">
                                                                    <div class="flex-1 min-w-[300px] flex items-center mt-6">
                                                                        <label class="text-gray-500 text-sm font-medium mr-2 w-[200px] mt-3">Total Outer Pack</label>
                                                                        <div class="relative w-full">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)"
                                                                                autocomplete="off"
                                                                                runat="server"
                                                                                type="text"
                                                                                ID="TxttotalOuterPack"
                                                                                TabIndex="75" TextMode="Number"
                                                                                AutoPostBack="true"
                                                                                OnTextChanged="TxttotalOuterPack_TextChanged"
                                                                                CssClass="w-full h-10 bg-slate-100 rounded-md text-left text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                            </asp:TextBox>

                                                                            <%--<img src="./images/circel-search.svg" alt="Search" class="absolute right-4 top-2">--%>
                                                                        </div>

                                                                    </div>

                                                                    <div class="flex-none w-[120px]">

                                                                        <label class="text-gray-500 text-sm font-medium invisible">Unit</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:DropDownList
                                                                                ID="DrptotalOuterPack"
                                                                                CssClass="w-full h-10 bg-slate-100 rounded-md text-left text-slate-950 text-sm font-medium outline-none border-none px-4"
                                                                                OnSelectedIndexChanged="DrptotalOuterPack_SelectedIndexChanged"
                                                                                TabIndex="76"
                                                                                AppendDataBoundItems="true"
                                                                                runat="server">
                                                                            </asp:DropDownList>

                                                                        </div>

                                                                    </div>

                                                                </div>

                                                                <div class="flex flex-wrap gap-4" style="margin: 0px !important;">
                                                                    <div class="flex-1 min-w-[300px] flex items-center">
                                                                        <label class="text-gray-500 text-sm font-medium mr-2 w-[200px] mt-3">Total Gross Weight</label>
                                                                        <div class="relative mt-6 w-full">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)"
                                                                                autocomplete="off" TextMode="Number"
                                                                                runat="server"
                                                                                type="text"
                                                                                ID="TxtTotalGrossWeight"
                                                                                AutoPostBack="true"
                                                                                OnTextChanged="TxtTotalGrossWeight_TextChanged"
                                                                                TabIndex="77"
                                                                                CssClass="w-full h-10 bg-slate-100 rounded-md text-left text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                            </asp:TextBox>
                                                                            <%--<img src="./images/circel-search.svg" alt="Search" class="absolute right-4 top-2">--%>
                                                                        </div>
                                                                    </div>

                                                                    <div class="flex-none w-[120px]">
                                                                        <label class="text-gray-500 text-sm font-medium invisible">Unit</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:DropDownList ID="DrpTotalGrossWeight" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" OnSelectedIndexChanged="DrpTotalGrossWeight_SelectedIndexChanged" AutoPostBack="true" TabIndex="78" runat="server">
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

                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtTotalGrossWeight" ID="RegularExpressionValidator33" ValidationExpression="^[\s\S]{0,15}$" runat="server" ErrorMessage="Maximum 15 characters allowed." ValidationGroup="outerpack"></asp:RegularExpressionValidator>

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



                                                                <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-7">
                                                                    <span class="text-white text-sm font-semibold tracking-wide">Location Information</span>
                                                                    <asp:Label ID="Label6" Visible="false" runat="server"></asp:Label>
                                                                </div>

                                                                <div id="Locationinfo" runat="server">

                                                                    <!-- First Row: Release Loc -->
                                                                    <div class="flex items-center gap-4 w-full mb-4">

                                                                        <!-- Release Loc Label and Search -->
                                                                        <div class="flex items-center gap-2 flex-shrink-0">
                                                                            <div class="text-gray-500 text-sm font-medium">
                                                                                Release Loc
                                                                            <asp:ImageButton ID="btninnonrelloc1" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" />
                                                                            </div>
                                                                        </div>

                                                                        <!-- Release Loc Input -->
                                                                        <div class="w-full">
                                                                            <div class="group relative">
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="txtreLoctn" OnTextChanged="txtreLoctn_TextChanged" AutoPostBack="true" TabIndex="85" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                                                <cc1:AutoCompleteExtender
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
                                                                                    TargetControlID="txtreLoctn" />

                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtreLoctn" Display="None" ErrorMessage="Cargo -->Release Location Code is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtreLoctn" ID="RegularExpressionValidator20" ValidationExpression="^[\s\S]{0,7}$" runat="server" ErrorMessage="Maximum 7 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                <cc1:ModalPopupExtender ID="popupinnonreleaseloction" runat="server" PopupControlID="popupinnonreleaseloc" TargetControlID="btninnonrelloc1" OkControlID="btnYesinnonreleaseloction" CancelControlID="btnNoinnonreleaseloction" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>

                                                                                <asp:Panel ID="popupinnonreleaseloc" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                    <div class="header">
                                                                                        <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">RELEASE LOCATION</p>
                                                                                    </div>
                                                                                    <div class="body">
                                                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                                                            <ContentTemplate>


                                                                                                <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                                    <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="LocationSearch" OnTextChanged="LocationSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>

                                                                                                </div>
                                                                                                <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                                                    <asp:GridView ID="LocationGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="LocationGrid_PageIndexChanging" OnRowCommand="LocationGrid_RowCommand" OnRowDataBound="LocationGrid_RowDataBound" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" AutoGenerateColumns="false">
                                                                                                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                        <Columns>
                                                                                                            <asp:TemplateField HeaderText="Code" SortExpression="Id">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:Label ID="lblCode" runat="server" Text='<%#Eval("Code")%>'></asp:Label>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                            <asp:TemplateField HeaderText="LocationCode" SortExpression="Id">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("LocationCode")%>'></asp:Label>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                            <asp:TemplateField HeaderText="Description" SortExpression="Id">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:Label ID="lblName1" runat="server" Text='<%#Eval("Description")%>'></asp:Label>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                            <asp:TemplateField Visible="false">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:LinkButton ID="LnkLocation" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkLocation_Command">Select</asp:LinkButton>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                        </Columns>
                                                                                                    </asp:GridView>
                                                                                                </div>
                                                                                            </ContentTemplate>
                                                                                        </asp:UpdatePanel>
                                                                                    </div>
                                                                                    <div class="footer" align="right">
                                                                                        <asp:Button ID="btnYesinnonreleaseloction" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                                        <asp:Button ID="btnNoinnonreleaseloction" runat="server" Text="Close" CssClass="yes" />
                                                                                    </div>
                                                                                </asp:Panel>
                                                                            </div>
                                                                        </div>

                                                                        <!-- Release Details -->
                                                                        <div class="flex-1 ">
                                                                            <div class="relative w-[195px]">
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" TextMode="MultiLine" ValidationGroup="Validation" ID="txtrelocDeta" TabIndex="86" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtrelocDeta" ID="RegularExpressionValidator21" ValidationExpression="^[\s\S]{0,250}$" runat="server" ErrorMessage="Maximum 250 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                <asp:Label runat="server" ForeColor="Red" BackColor="Yellow" Visible="false" ID="lblrelloc"></asp:Label>
                                                                            </div>
                                                                        </div>

                                                                    </div>

                                                                    <!-- Second Row: Receipt Loc -->
                                                                    <div class="flex items-center gap-4 w-full mb-4">

                                                                        <!-- Receipt Loc Label and Search -->
                                                                        <div class="flex items-center gap-2 flex-shrink-0">
                                                                            <div class="text-gray-500 text-sm font-medium">
                                                                                Receipt Loc
                                                                            <asp:ImageButton ID="btnreceiptlocation1" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" />
                                                                            </div>
                                                                        </div>

                                                                        <!-- Receipt Loc Input -->
                                                                        <div class="w-full">
                                                                            <div class="group relative">
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="txtrecloctn" OnTextChanged="txtrecloctn_TextChanged" AutoPostBack="true" TabIndex="87" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                                                <cc1:AutoCompleteExtender
                                                                                    ID="AutoCompleteExtender10"
                                                                                    runat="server"
                                                                                    CompletionInterval="100"
                                                                                    FirstRowSelected="true"
                                                                                    MinimumPrefixLength="1"
                                                                                    DelimiterCharacters="1"
                                                                                    ServiceMethod="GetRecLoc"
                                                                                    ServicePath="~/InNonPayment.aspx"
                                                                                    Enabled="True"
                                                                                    CompletionListCssClass="ac_results"
                                                                                    CompletionListItemCssClass="listItem"
                                                                                    CompletionListHighlightedItemCssClass="itemHighlighted"
                                                                                    TargetControlID="txtrecloctn" />

                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtrecloctn" Display="None" ErrorMessage="Cargo -->Receipt Location Code is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtrecloctn" ID="RegularExpressionValidator18" ValidationExpression="^[\s\S]{0,7}$" runat="server" ErrorMessage="Maximum 7 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                <cc1:ModalPopupExtender ID="popupinnonreceiptlocation" runat="server" PopupControlID="pnlinnonreceiptlocation" TargetControlID="btnreceiptlocation1" OkControlID="btnYesinnonreceiptlocation" CancelControlID="btnNoinnonreceiptlocation" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>

                                                                                <asp:Panel ID="pnlinnonreceiptlocation" runat="server" CssClass="modalPopup" Style="display: none">
                                                                                    <div class="header">

                                                                                        <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Receipt Location</p>
                                                                                    </div>
                                                                                    <div class="body">
                                                                                        <asp:UpdatePanel ID="upinnonReceiptSearch" runat="server" UpdateMode="Conditional">
                                                                                            <ContentTemplate>

                                                                                                <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                                    <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ReceiptSearch" OnTextChanged="ReceiptSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                </div>
                                                                                                <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                                                    <asp:GridView ID="ReceiptGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ReceiptGrid_PageIndexChanging" OnRowCommand="ReceiptGrid_RowCommand" OnRowDataBound="ReceiptGrid_RowDataBound" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" AutoGenerateColumns="false">
                                                                                                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                        <Columns>
                                                                                                            <asp:TemplateField HeaderText="Code" SortExpression="Id">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:Label ID="lblCode" runat="server" Text='<%#Eval("Code")%>'></asp:Label>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                            <asp:TemplateField HeaderText="LocationCode" SortExpression="Id">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("LocationCode")%>'></asp:Label>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                            <asp:TemplateField HeaderText="Description" SortExpression="Id">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:Label ID="lblName1" runat="server" Text='<%#Eval("Description")%>'></asp:Label>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                            <asp:TemplateField Visible="false">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:LinkButton ID="LnkReceipt" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkReceipt_Command">Select</asp:LinkButton>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                        </Columns>
                                                                                                    </asp:GridView>
                                                                                                </div>
                                                                                            </ContentTemplate>
                                                                                        </asp:UpdatePanel>
                                                                                    </div>
                                                                                    <div class="footer" align="right">
                                                                                        <asp:Button ID="btnYesinnonreceiptlocation" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                                        <asp:Button ID="btnNoinnonreceiptlocation" runat="server" Text="Close" CssClass="yes" />
                                                                                    </div>
                                                                                </asp:Panel>
                                                                            </div>
                                                                        </div>

                                                                        <!-- Receipt Details -->
                                                                        <div class="flex-1">
                                                                            <div class="relative w-[195px]">
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" TextMode="MultiLine" ValidationGroup="Validation" ID="txtrecloctndet" TabIndex="80" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtrecloctndet" ID="RegularExpressionValidator19" ValidationExpression="^[\s\S]{0,250}$" runat="server" ErrorMessage="Maximum 250 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                            </div>
                                                                        </div>

                                                                    </div>

                                                                    <!-- Third Row: Storage Loc -->
                                                                    <div id="divstrge" visible="false" runat="server" class="flex items-center gap-4 w-full mb-4">

                                                                        <!-- Storage Loc Label and Search -->
                                                                        <div class="flex items-center gap-2 flex-shrink-0">
                                                                            <div class="text-gray-500 text-sm font-medium">
                                                                                Storage Loc
                                                                            <asp:ImageButton ID="btninnonstorageloc1" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" />
                                                                            </div>
                                                                        </div>

                                                                        <!-- Storage Loc Input -->
                                                                        <div class="w-full">
                                                                            <div class="group relative">
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="txtstrgeloc" OnTextChanged="txtstrgeloc_TextChanged" AutoPostBack="true" TabIndex="90" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                                                <cc1:AutoCompleteExtender
                                                                                    ID="AutoCompleteExtender18"
                                                                                    runat="server"
                                                                                    CompletionInterval="100"
                                                                                    FirstRowSelected="true"
                                                                                    MinimumPrefixLength="1"
                                                                                    DelimiterCharacters="1"
                                                                                    ServiceMethod="GetStrgLoc"
                                                                                    ServicePath="~/InNonPayment.aspx"
                                                                                    Enabled="True"
                                                                                    CompletionListCssClass="ac_results"
                                                                                    CompletionListItemCssClass="listItem"
                                                                                    CompletionListHighlightedItemCssClass="itemHighlighted"
                                                                                    TargetControlID="txtstrgeloc" />

                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtstrgeloc" ID="RegularExpressionValidator22" ValidationExpression="^[\s\S]{0,7}$" runat="server" ErrorMessage="Maximum 7 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                                <cc1:ModalPopupExtender ID="popupinnonstorageloc" runat="server" PopupControlID="pnlinnonstorageloc" TargetControlID="btninnonstorageloc1" OkControlID="btnYesinnonstorageloc" CancelControlID="btnNoinnonstorageloc" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>

                                                                                <asp:Panel ID="pnlinnonstorageloc" runat="server" CssClass="modalPopup" Style="display: none">


                                                                                    <div class="header">
                                                                                        <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Storage Location</p>
                                                                                    </div>
                                                                                    <div class="body">
                                                                                        <asp:UpdatePanel ID="upinnonstorage" runat="server" UpdateMode="Conditional">
                                                                                            <ContentTemplate>


                                                                                                <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                                    <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txtstorageSearch" OnTextChanged="txtstorageSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                    <br />
                                                                                                </div>
                                                                                                <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                                                    <asp:GridView ID="GridStorageLoc" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="GridStorageLoc_PageIndexChanging" OnRowCommand="GridStorageLoc_RowCommand" OnRowDataBound="GridStorageLoc_RowDataBound" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" AutoGenerateColumns="false">
                                                                                                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                        <Columns>
                                                                                                            <asp:TemplateField HeaderText="Code" SortExpression="Id">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:Label ID="lblCode" runat="server" Text='<%#Eval("Code")%>'></asp:Label>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                            <asp:TemplateField HeaderText="LocationCode" SortExpression="Id">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("StorageCode")%>'></asp:Label>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                            <asp:TemplateField HeaderText="Description" SortExpression="Id">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:Label ID="lblName1" runat="server" Text='<%#Eval("Description")%>'></asp:Label>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                            <asp:TemplateField Visible="false">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:LinkButton ID="LnkReceipt" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkReceipt_Command1">Select</asp:LinkButton>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                        </Columns>
                                                                                                    </asp:GridView>
                                                                                                </div>
                                                                                            </ContentTemplate>
                                                                                        </asp:UpdatePanel>
                                                                                    </div>
                                                                                    <div class="footer" align="right">
                                                                                        <asp:Button ID="btnYesinnonstorageloc" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                                        <asp:Button ID="btnNoinnonstorageloc" runat="server" Text="Close" CssClass="yes" />
                                                                                    </div>
                                                                                </asp:Panel>
                                                                            </div>
                                                                        </div>

                                                                        <!-- Storage Details -->
                                                                        <div class="flex-1">
                                                                            <div class="relative w-[195px]">
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="txtstrgelocdet" TabIndex="84" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtstrgelocdet" ID="RegularExpressionValidator23" ValidationExpression="^[\s\S]{0,250}$" runat="server" ErrorMessage="Maximum 250 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                            </div>
                                                                        </div>

                                                                    </div>

                                                                </div>
                                                            </div>

                                                        </div>






                                                        <div>




                                                            <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                                <div class="md:max-w-[250px] w-full" id="EXhDiv" runat="server" visible="false">
                                                                    <div class="flex justify-between gap-2 items-center mt-7">
                                                                        <h2 class="text-lg sa700 leading-[18px] text-gray-800">Exhibition / Temp Import
                                                                        </h2>
                                                                    </div>

                                                                    <label class="text-gray-500 text-sm font-medium mt-4">Start Date</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txtExStartDate" OnTextChanged="txtExStartDate_TextChanged" AutoPostBack="true" runat="server" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <cc1:CalendarExtender ID="CalendarExtender4" PopupButtonID="imgPopup" runat="server" CssClass="cal_Theme1" TargetControlID="txtExStartDate" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"></cc1:CalendarExtender>
                                                                    </div>
                                                                </div>

                                                                <div id="startdate" runat="server" class="md:max-w-[250px] w-full" visible="false">
                                                                    <label class="text-gray-500 text-sm font-medium">End Date</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txtExEndDate" OnTextChanged="txtExEndDate_TextChanged" AutoPostBack="true" runat="server" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <cc1:CalendarExtender ID="CalendarExtender5" PopupButtonID="imgPopup" runat="server" CssClass="cal_Theme1" TargetControlID="txtExEndDate" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"></cc1:CalendarExtender>
                                                                    </div>
                                                                </div>

                                                                <div id="BlankStart" runat="server" class="md:max-w-[250px] w-full" visible="false">
                                                                    <label class="text-gray-500 text-sm font-medium">Blanket Start Date</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="BlankDate1" runat="server" onkeypress="return isNumberKey(event)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <cc1:CalendarExtender ID="CalendarExtender1" CssClass="cal_Theme1" PopupButtonID="imgPopup" runat="server" TargetControlID="BlankDate1" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"></cc1:CalendarExtender>
                                                                    </div>
                                                                </div>
                                                                <div class="md:max-w-[250px] w-full"></div>
                                                            </div>

                                                        </div>







                                                        <div class="row">
                                                            <div class="col-sm-12 text-center">

                                                                <center>

                                                                    <div id="ContainerDetails" visible="false" runat="server">
                                                                        <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-6">
                                                                            <span class="text-white text-sm font-semibold tracking-wide">Container Information
                                                                            </span>

                                                                        </div>
                                                                        <asp:GridView ID="ContarinerGrid" FooterStyle-CssClass="w-full h-10 py-4 px-10 bg-[#F4F6FA] rounded-lg" CssClass="w-full bg-white rounded whitespace-nowrap" HeaderStyle-CssClass="w-full h-10 py-4 px-10 bg-[#F4F6FA] rounded-l-lg" PagerStyle-CssClass="pager" RowStyle-CssClass="rows" runat="server" OnRowDeleting="ContarinerGrid_RowDeleting" OnRowDataBound="ContarinerGrid_RowDataBound1" ShowFooter="true" AutoGenerateColumns="false">
                                                                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                            <Columns>
                                                                                <asp:BoundField DataField="RowNumber" HeaderText="Seq." Visible="false" />
                                                                                <asp:TemplateField ItemStyle-CssClass="pl-2 text-xs leading-none py-3 px-2 text-gray-800 w-5 relative">
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
                                                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator231" InitialValue="0" runat="server" Font-Size="XX-Small" ControlToValidate="DrpType" ErrorMessage="Size / Type is Required" ForeColor="Red" ValidationGroup="Container"></asp:RequiredFieldValidator>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-CssClass="pl-2 text-xs leading-none py-3 px-2 text-gray-800 w-5 relative">
                                                                                    <HeaderTemplate>
                                                                                        <div class="pl-2">Weight ( TNE )</div>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txt2" onkeypress="return onlyNumbers(event)" CssClass="mr-4 px-3 w-[150px] h-8 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium relative focus:outline-none" TabIndex="72" ValidationGroup="Validation1" MaxLength="3" runat="server"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2311" runat="server" Font-Size="XX-Small" ControlToValidate="txt2" ErrorMessage="Weight is Required" ForeColor="Red" ValidationGroup="Container"></asp:RequiredFieldValidator>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-CssClass="pl-2 text-xs leading-none py-3 px-2 text-gray-800 w-5 relative">
                                                                                    <HeaderTemplate>
                                                                                        <div class="pl-2">Seal No</div>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txt3" MaxLength="35" CssClass="mr-4 px-3 w-[150px] h-8 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium relative focus:outline-none" TabIndex="73" runat="server"></asp:TextBox>

                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txt3" ID="RequiredFieldValidator23111" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Validation1"></asp:RegularExpressionValidator>
                                                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RegularExpressionValidator45" runat="server" Font-Size="XX-Small" ControlToValidate="txt3" ErrorMessage="Seal No is Required" ForeColor="Red" ValidationGroup="Container"></asp:RequiredFieldValidator>
                                                                                    </ItemTemplate>
                                                                                    <FooterStyle HorizontalAlign="Right" />
                                                                                    <FooterTemplate>
                                                                                        <asp:Button ID="ButtonAdd" runat="server" Text="+ Add Row" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" ValidationGroup="Container" OnClick="ButtonAdd_Click" />
                                                                                        <%-- <asp:Button ID="ButtonAdd" runat="server" Text="+ Add Row" ValidationGroup="Container" OnClick="ButtonAdd_Click" />--%>
                                                                                    </FooterTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </center>
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

                                        <cc1:TabPanel ID="Invoice" runat="server" HeaderText="Invoice">
                                            <ContentTemplate>

                                                <asp:UpdatePanel ID="upinnoninvoice" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>


                                                        <div>

                                                            <div class="flex flex-wrap lg:flex-nowrap gap-3">

                                                                <div class="flex items-center justify-between mb-1 mt-5">

                                                                    <div class="flex items-center gap-1">

                                                                        <h2 class="text-[16px] sa700 leading-[18px] text-gray-800 mb-0 mt-3 w-[200px]">Supplier / Manufacturer Party</h2>

                                                                        <asp:ImageButton ID="btnsupplier1" CssClass="theme_searchIcon mt-3" runat="server" ImageUrl="images/searchBlue.png" Height="28" Width="28" />

                                                                        <asp:Button ID="suppyadd" runat="server" CssClass="plusbtn plusbtnIcon mt-3" BorderWidth="0px" ValidationGroup="supply" OnClick="suppyadd_Click1" Text="+" />

                                                                    </div>

                                                                    <div class="flex-1 min-w-[100px] max-w-[300px] m-1">

                                                                        <label for="staticEmail" class="text-gray-500 text-sm font-medium">Code</label>

                                                                        <div class="relative mt-1">

                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" OnTextChanged="txtcodeinvq_TextChanged" placeholder="" AutoPostBack="true" ID="txtcodeinvq" TabIndex="24" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

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

                                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">

                                                                        <label class="text-gray-500 text-sm font-medium">CR UEI</label>

                                                                        <div class="relative mt-1">

                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txtcruei" MaxLength="17" placeholder="" runat="server" ValidationGroup="supply" TabIndex="25" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtcruei" ID="RegularExpressionValidator38" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="supply"></asp:RegularExpressionValidator>

                                                                            <br />

                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator93" runat="server" ControlToValidate="txtcruei" Display="None" ErrorMessage="Supplier CRUEI is Required" ValidationGroup="supply"></asp:RequiredFieldValidator>

                                                                        </div>

                                                                    </div>

                                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">

                                                                        <label class="text-gray-500 text-sm font-medium">Name 1</label>

                                                                        <div class="relative mt-1">

                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" Style="text-transform: uppercase" runat="server" type="text" ValidationGroup="supply" ID="txtName" placeholder="" TabIndex="136" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                                            <br />

                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtName" ID="RegularExpressionValidator36" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="supply"></asp:RegularExpressionValidator>

                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator87" runat="server" ControlToValidate="txtName" Display="None" ErrorMessage="Supplier Name is Required" ValidationGroup="supply"></asp:RequiredFieldValidator>

                                                                        </div>

                                                                    </div>

                                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">

                                                                        <label class="text-gray-500 text-sm font-medium">Name 2</label>

                                                                        <div class="relative mt-1">

                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" Style="text-transform: uppercase" runat="server" type="text" ValidationGroup="supply" ID="txtName1" placeholder="" TabIndex="137" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                                            <br />

                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtName1" ID="RegularExpressionValidator37" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="supply"></asp:RegularExpressionValidator>

                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator91" runat="server" ControlToValidate="txtName1" Display="None" ErrorMessage="Supplier Name is Required" ValidationGroup="supply"></asp:RequiredFieldValidator>

                                                                        </div>

                                                                    </div>

                                                                </div>

                                                            </div>

                                                            <cc1:ModalPopupExtender ID="popupinnonsp" runat="server" PopupControlID="pnlinnonsp" TargetControlID="btnsupplier1"
                                                                OkControlID="btnYesinnonsp" CancelControlID="btnNoinnonsp" BackgroundCssClass="modalBackground">
                                                            </cc1:ModalPopupExtender>

                                                            <asp:Panel ID="pnlinnonsp" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">

                                                                <div class="header">
                                                                    <%-- <svg class="cursor-pointer absolute right-5 top-5" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                        <circle opacity="0.1" cx="12" cy="12" r="12" fill="#676D7C"></circle>
                                                                        <path d="M16.6663 7.3335L7.33301 16.6668M7.33301 7.3335L16.6663 16.6668" stroke="#676D7C" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                                                    </svg>--%>
                                                                    <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Supplier / Manufacturer Party</p>
                                                                </div>

                                                                <div class="body">
                                                                    <asp:UpdatePanel ID="upinnonsp" runat="server" UpdateMode="Conditional">
                                                                        <ContentTemplate>
                                                                            <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="SUPPLIERSearch" OnTextChanged="SUPPLIERSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                            </div>

                                                                            <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                                <asp:GridView ID="SUPPLIERGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="SUPPLIERGrid_PageIndexChanging" OnRowDataBound="SUPPLIERGrid_RowDataBound" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" AutoGenerateColumns="false" OnRowCommand="SUPPLIERGrid_RowCommand">
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
                                                                                                <asp:LinkButton ID="lnkRequestID" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="lnkRequestID_Command1" CssClass="duration-300 ease-in-out md:max-w-[200px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700">Select </asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </div>
                                                                        </ContentTemplate>

                                                                    </asp:UpdatePanel>

                                                                </div>
                                                                <div class="footer" align="right">
                                                                    <asp:Button ID="btnYesinnonsp" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                    <asp:Button ID="btnNoinnonsp" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px] mt-4 w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                </div>
                                                            </asp:Panel>

                                                        </div>


                                                        <div>

                                                            <div class="flex flex-wrap lg:flex-nowrap gap-3">

                                                                <div class="flex items-center justify-between mb-1">

                                                                    <div class="flex items-center gap-1">

                                                                        <h2 class="text-[18px] sa700 leading-[18px] text-gray-800 mb-0 mt-5 w-[200px]">Importer Party</h2>

                                                                        <asp:ImageButton ID="btninnoninvimp1" CssClass="theme_searchIcon mt-5" runat="server" Style="display: none;" ImageUrl="images/searchBlue.png" Height="28" Width="28" />

                                                                        <asp:Button ID="BtnImpPartyADD" runat="server" CssClass="plusbtn plusbtnIcon mt-5" Visible="false" BorderWidth="0px" ValidationGroup="supply1" OnClick="BtnImpPartyADD_Click" Text="+" />

                                                                    </div>

                                                                    <div class="flex-1 min-w-[100px] max-w-[300px] m-1">

                                                                        <label for="staticEmail" class="text-gray-500 text-sm font-medium">Code</label>

                                                                        <div class="relative mt-1">

                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" Enabled="false" type="text" OnTextChanged="TxtImppartyCode_TextChanged" placeholder="" AutoPostBack="true" ID="TxtImppartyCode" TabIndex="24" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

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

                                                                            <asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator96" runat="server" ControlToValidate="TxtImppartyCode" Display="None" ErrorMessage="Importer Code is Required" ValidationGroup="Importer"></asp:RequiredFieldValidator>

                                                                        </div>

                                                                    </div>

                                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">

                                                                        <label class="text-gray-500 text-sm font-medium">CR UEI</label>

                                                                        <div class="relative mt-1">

                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtImppartyCRUEI" Enabled="false" placeholder="" runat="server" TabIndex="139" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox><br />

                                                                            <asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator26" runat="server" ControlToValidate="TxtImppartyCRUEI" Display="None" ErrorMessage="Importer CRUEI is Required" ValidationGroup="Invoice"></asp:RequiredFieldValidator>

                                                                            <asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator99" runat="server" ControlToValidate="TxtImppartyCRUEI" Display="None" ErrorMessage="Importer CRUEI is Required" ValidationGroup="Importer"></asp:RequiredFieldValidator>

                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtImppartyCRUEI" ID="RegularExpressionValidator51" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Importer"></asp:RegularExpressionValidator>

                                                                        </div>

                                                                    </div>

                                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">

                                                                        <label class="text-gray-500 text-sm font-medium">Name 1</label>

                                                                        <div class="relative mt-1">

                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" Enabled="false" Style="text-transform: uppercase" ID="TxtImppartyName" placeholder="" runat="server" TabIndex="140" type="text" ValidationGroup="Importer" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox><br />

                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtImppartyName" ID="RegularExpressionValidator12" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Importer"></asp:RegularExpressionValidator>

                                                                            <asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator94" runat="server" ControlToValidate="TxtImppartyName" Display="None" ErrorMessage="Importer Name is Required" ValidationGroup="Importer"></asp:RequiredFieldValidator>

                                                                        </div>

                                                                    </div>

                                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">

                                                                        <label class="text-gray-500 text-sm font-medium">Name 2</label>

                                                                        <div class="relative mt-1">

                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" Enabled="false" autocomplete="off" Style="text-transform: uppercase" ID="TxtImppartyName1" placeholder="" runat="server" TabIndex="141" type="text" ValidationGroup="Importer" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <br />

                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtImppartyName1" ID="RegularExpressionValidator13" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Importer"></asp:RegularExpressionValidator>

                                                                            <asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator98" runat="server" ControlToValidate="TxtImppartyName1" Display="None" ErrorMessage="Importer Name is Required" ValidationGroup="Importer"></asp:RequiredFieldValidator>

                                                                        </div>

                                                                    </div>

                                                                </div>

                                                            </div>

                                                            <cc1:ModalPopupExtender ID="popupinnoninvimp" runat="server" PopupControlID="pnlinnoninvimp" TargetControlID="btninnoninvimp1"
                                                                OkControlID="btnYesinnoninvimp" CancelControlID="btnNovinnoninvimp" BackgroundCssClass="modalBackground">
                                                            </cc1:ModalPopupExtender>

                                                            <asp:Panel ID="pnlinnoninvimp" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                                <div class="header">
                                                                    <svg class="cursor-pointer absolute right-5 top-5" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                        <circle opacity="0.1" cx="12" cy="12" r="12" fill="#676D7C"></circle>
                                                                        <path d="M16.6663 7.3335L7.33301 16.6668M7.33301 7.3335L16.6663 16.6668" stroke="#676D7C" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                                                    </svg>
                                                                    <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Importer Party</p>
                                                                </div>

                                                                <div class="body">
                                                                    <asp:UpdatePanel ID="upinnoninvimp" runat="server" UpdateMode="Conditional">
                                                                        <ContentTemplate>
                                                                            <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ImportPartySearch" OnTextChanged="ImportPartySearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                            </div>

                                                                            <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                                <asp:GridView ID="ImportPartyGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ImportPartyGrid_PageIndexChanging" OnRowDataBound="ImportPartyGrid_RowDataBound" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" AutoGenerateColumns="false" OnRowCommand="ImportPartyGrid_RowCommand">
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
                                                                        </ContentTemplate>

                                                                    </asp:UpdatePanel>

                                                                </div>
                                                                <div class="footer" align="right">
                                                                    <asp:Button ID="btnYesinnoninvimp" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                    <asp:Button ID="btnNovinnoninvimp" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px] mt-4 w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                </div>
                                                            </asp:Panel>

                                                        </div>



                                                        <div class="row">
                                                            <div class="col-sm-12" style="text-align: center;">
                                                                <asp:Label ID="lblerrorinv" runat="server" Font-Size="Medium" Font-Bold="true" Text="" BackColor="Red" ForeColor="White" Visible="false"></asp:Label>
                                                            </div>
                                                        </div>


                                                        <div id="InvoiceDiv" runat="server">
                                                            <div class="">
                                                                <asp:ValidationSummary ID="ValidationSummary18" runat="server" ShowMessageBox="True"
                                                                    ShowSummary="False" ValidationGroup="Invoice" />


                                                                <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-6 mb-2">
                                                                    <span class="text-white text-sm font-semibold tracking-wide">INVOICE INFORMATION
                                                                    </span>
                                                                </div>

                                                                <div class="mt-4 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">

                                                                    <div class="md:max-w-[250px] w-full">
                                                                        <label for="staticEmail" class="text-gray-500 text-sm font-medium">Serial Number</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="txtserial" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        </div>
                                                                    </div>

                                                                    <div class="md:max-w-[250px] w-full" id='Div1'>
                                                                        <label for="staticEmail" class="text-gray-500 text-sm font-medium">Invoice Date</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txtinvDate1" TabIndex="143" runat="server" AutoPostBack="true" onkeypress="return isNumberKey(event)" OnTextChanged="txtinvDate1_TextChanged" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                                            <cc1:CalendarExtender ID="CalendarExtender3" CssClass="cal_Theme1" PopupButtonID="imgPopup" runat="server" TargetControlID="txtinvDate1" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"></cc1:CalendarExtender>

                                                                            <asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtinvDate1" Display="None" ErrorMessage="Invoice Date is Required" ValidationGroup="Invoice"></asp:RequiredFieldValidator>

                                                                        </div>
                                                                    </div>

                                                                    <div class="md:max-w-[250px] w-full">
                                                                        <div class="relative mt-1">
                                                                            <asp:CheckBox runat="server" ID="chkindicator" TabIndex="87" Text="" Style="text-transform: none" />
                                                                            <label for="chkindicator" class="text-gray-500 text-sm font-medium">Ad Valorem Indicator</label>
                                                                            <br />
                                                                            <asp:CheckBox runat="server" ID="chkrateind" TabIndex="88" Style="text-transform: none" />
                                                                            <label for="chkrateind" class="text-gray-500 text-sm font-medium">Preferential Duty Rate Indicator</label>
                                                                        </div>
                                                                    </div>







                                                                </div>

                                                                <div class="mt-4 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">


                                                                    <div class="md:max-w-[250px] w-full">
                                                                        <label for="staticEmail" class="text-gray-500 text-sm font-medium">Invoice Number</label>
                                                                        <div class="relative mt-1">

                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="Invoice" type="text" ID="txtinvNo" TabIndex="142" class="w3-input w3-hover-green" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                                            <asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtinvNo" Display="None" ErrorMessage="Invoice Number is Required" ValidationGroup="Invoice"></asp:RequiredFieldValidator>

                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtinvNo" ID="RegularExpressionValidator67" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Invoice"></asp:RegularExpressionValidator>

                                                                        </div>
                                                                    </div>


                                                                    <div class="md:max-w-[250px] w-full">
                                                                        <label for="staticEmail" class="text-gray-500 text-sm font-medium">Term Type</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:DropDownList ID="DrpTerms" TabIndex="144" runat="server" OnSelectedIndexChanged="DrpTerms_SelectedIndexChanged" AutoPostBack="true" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:DropDownList>

                                                                        </div>
                                                                    </div>

                                                                    <div class="md:max-w-[250px] w-full">
                                                                        <label class="text-gray-500 text-sm font-medium">Supplier Importer Relationship</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:DropDownList ID="DrpSupImpRel" TabIndex="147" runat="server" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                                <asp:ListItem Text="--Select--" Value="--Select--" Selected="True"></asp:ListItem>
                                                                                <asp:ListItem Text="Ordinary Importer" Value="Ordinary Importer"></asp:ListItem>
                                                                                <asp:ListItem Text="Agency" Value="Agency" />
                                                                            </asp:DropDownList>

                                                                        </div>
                                                                    </div>


                                                                </div>

                                                            </div>


                                                            <hr />


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

                                                                                    <asp:DropDownList ID="Drpcurrency1" CssClass="font-normal bg-slate-100 rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt- px-4" OnSelectedIndexChanged="Drpcurrency1_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true" TabIndex="90" runat="server">
                                                                                    </asp:DropDownList>

                                                                                    <br />
                                                                                    <asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator29" runat="server" InitialValue="0" ControlToValidate="Drpcurrency1" Display="None" ErrorMessage="Required" ValidationGroup="Invoice"></asp:RequiredFieldValidator>

                                                                                </div>
                                                                                <div class="invoiceExRate">
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ID="LblTotalInvoice" Text="0.00" Enabled="false" TabIndex="1" onkeypress="return isNumberKey(event)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                                                </div>
                                                                                <div class="invoiceAmount">
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" onfocus="removeCommas(this)" OnBlur="addCommas(this)" onkeypress="return isNumberKey(event)" Text="0.00" ID="TxtTotalInvoice" MaxLength="16" OnTextChanged="TxtTotalInvoice_TextChanged" AutoPostBack="true" TabIndex="91" ValidationGroup="Item" CssClass="px-3 h-8 bg-slate-100 rounded-md flex items-center text-slate-300 text-[13px] font-medium w-full"></asp:TextBox>
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtTotalInvoice" ID="RegularExpressionValidator120" ValidationExpression="^[0-9\s\.]+$" runat="server" ErrorMessage="Not Accepted Special Charector" ValidationGroup="Item"></asp:RegularExpressionValidator>
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

                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="lblOtherTaxableCharge" Text="0.00" TabIndex="1" Enabled="false" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>


                                                                                </div>
                                                                                <div class="invoiceAmount">
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" Text="0.00" onfocus="removeCommas(this)" OnBlur="addCommas(this)" onkeypress="return isNumberKey(event)" ID="TxtOtherTaxableCharge" MaxLength="16" OnTextChanged="TxtOtherTaxableCharge_TextChanged" AutoPostBack="true" TabIndex="94" ValidationGroup="Item" CssClass="px-3 h-8 bg-slate-100 rounded-md flex items-center text-slate-300 text-[13px] py-4 font-medium w-full"></asp:TextBox>
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtOtherTaxableCharge" ID="RegularExpressionValidator121" ValidationExpression="^[0-9\s\.]+$" runat="server" ErrorMessage="Not Accepted Special Charector" ValidationGroup="Item"></asp:RegularExpressionValidator>
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

                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="LblFrieghtCharges" Text="0.00" TabIndex="1" Enabled="false" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>


                                                                                </div>
                                                                                <div class="invoiceAmount">
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" onkeypress="return isNumberKey(event)" runat="server" type="text" Text="0.00" ValidationGroup="Item" onfocus="removeCommas(this)" OnBlur="addCommas(this)" ID="TxtFrieghtCharges" OnTextChanged="TxtFrieghtCharges_TextChanged" AutoPostBack="true" TabIndex="97" CssClass="px-3 h-8 bg-slate-100 rounded-md flex items-center text-slate-300 text-[13px] py-4 font-medium w-full"></asp:TextBox>
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtFrieghtCharges" ID="RegularExpressionValidator122" ValidationExpression="^[0-9\s\.]+$" runat="server" ErrorMessage="Not Accepted Special Charector" ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                </div>
                                                                                <div class="invoiceAmount_next">
                                                                                    <asp:Label runat="server" Text="0.00" ID="SumFrieghtCharges" Enabled="false"></asp:Label>
                                                                                </div>
                                                                            </div>

                                                                            <div class="flex my-[5px]" runat="server" id="InsuranceCharges">
                                                                                <div class="invoiceItem">
                                                                                    <p class="h-8 px-3 rounded-md flex items-center text-slate-500 pb-2 pt-3 text-[13px] font-medium pl-8">
                                                                                        Insurance Charges

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

                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="lblInsuranceCharges" Text="0.00" TabIndex="1" Enabled="false" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>


                                                                                </div>
                                                                                <div class="invoiceAmount">
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" onkeypress="return isNumberKey(event)" runat="server" type="text" Text="0.00" onfocus="removeCommas(this)" OnBlur="addCommas(this)" ID="TxtInsuranceCharges" MaxLength="16" TabIndex="101" OnTextChanged="TxtInsuranceCharges_TextChanged" AutoPostBack="true" ValidationGroup="Item" CssClass="px-3 h-8 bg-slate-100 rounded-md flex items-center text-slate-300 text-[13px] font-medium w-full"></asp:TextBox>
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtInsuranceCharges" ID="RegularExpressionValidator131" ValidationExpression="^[0-9\s\.]+$" runat="server" ErrorMessage="Not Accepted Special Charector" ValidationGroup="Item"></asp:RegularExpressionValidator>
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
                                                                            <asp:ValidationSummary ID="ValidationSummary9" runat="server" ShowMessageBox="True"
                                                                                ShowSummary="False" ValidationGroup="Invoice" />
                                                                        </div>
                                                                        <div class="col-sm-4">
                                                                            <asp:Button ID="BtnAddInvoice" ValidationGroup="Invoice" runat="server" Visible="false" Text="Add Invoice" OnClick="BtnAddInvoice_Click" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] bg-opacity-10 border hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-[#0560FD] text-center rounded-md text-sm sa700" />

                                                                        </div>


                                                                    </div>
                                                                </div>
                                                            </div>


                                                        </div>


                                                        <div class="flex justify-end gap-4 md:flex-nowrap flex-wrap mt-4">
                                                            <asp:Button ID="btnsaveinvoice" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] bg-opacity-10 border hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-[#0560FD] text-center rounded-md text-sm sa700 pull-right" runat="server" ValidationGroup="Ivoice" OnClick="BtnAddInvoice_Click" Text="Add Invoice" TabIndex="103" />
                                                            <button style="display: none;" class="duration-300 ease-in-out bg-opacity-10 md:max-w-[120px] w-full bg-[#D81616] border hover:bg-transparent text-[#D81616] h-10 flex items-center justify-center text-center rounded-md text-sm sa700">
                                                                Delete Invoice
             
                                                            </button>
                                                        </div>


                                                        <div id="InvoiceGrid" runat="server">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" Style="display: none;" autocomplete="off" ID="AddInvoiceSearch" OnTextChanged="AddInvoiceSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
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



                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </ContentTemplate>
                                        </cc1:TabPanel>

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


                                                        <div id="ItemDiv" runat="server">


                                                            <div class="grid grid-cols-1 md:grid-cols-3 gap-6 mt-4 mb-2">

                                                                <div class="space-y-4 ">
                                                                    <div class="flex justify-between gap-2 items-center ">
                                                                        <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-6">
                                                                            <span class="text-white text-sm font-semibold tracking-wide">Item Information
                                                                            </span>
                                                                        </div>
                                                                    </div>
                                                                    <div class="w-full">
                                                                        <div class="group relative flex items-center gap-4">
                                                                            <!-- Labels on the left -->
                                                                            <div class="w-[120px] space-y-1">
                                                                                <div id="inhab" class="text-gray-500 text-sm font-medium" visible="false" runat="server">In HAWB/OBL</div>
                                                                                <div id="inhbl" class="text-gray-500 text-sm font-medium" visible="false" runat="server">HBL</div>
                                                                                <div id="phawb" class="text-gray-500 text-sm font-medium" runat="server">HAWB</div>
                                                                            </div>
                                                                            <!-- Input on the right -->
                                                                            <div class="flex-1">
                                                                                <asp:DropDownList ID="TxtHAWB" runat="server" ValidationGroup="Item" TabIndex="167" AutoPostBack="true" Style="text-transform: uppercase" OnTextChanged="TxtHAWB_TextChanged" CssClass="focus:outline-none bg-slate-100 font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt-1 px-4">
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator49" runat="server" ControlToValidate="TxtHAWB" ErrorMessage="Please Enter In HAWB/OBL" Display="Dynamic" ValidationGroup="ItemMasterValidation" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtHAWB" ID="RegularExpressionValidator27" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                <asp:Button ID="btnCopyAll" runat="server" Visible="false" Text="Copy All" />
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                    <div class="w-full">
                                                                        <div class="group relative flex items-center gap-4">
                                                                            <!-- Label with fixed width -->
                                                                            <label class="text-gray-500 text-sm font-medium w-[120px]">Out HAWB/HBL</label>
                                                                            <!-- Input taking remaining space -->
                                                                            <div class="flex-1">
                                                                                <asp:DropDownList ID="txtOutHAWB1" runat="server" ValidationGroup="Item" TabIndex="168" CssClass="focus:outline-none bg-slate-100 font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt-1 px-4"></asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator56" runat="server" ControlToValidate="txtOutHAWB1" ErrorMessage="Please Enter Out HAWB/HBL" Display="Dynamic" ValidationGroup="ItemMasterValidation" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtOutHAWB1" ID="RegularExpressionValidator28" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                <asp:Button ID="BtnOutCopyAll" Width="50" runat="server" Visible="false" Text="Copy All" />
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                    <div class="w-full">
                                                                        <div class="group relative flex items-center gap-4">
                                                                            <!-- Label with fixed width -->
                                                                            <label class="text-gray-500 text-sm font-medium w-[120px]">Term Type</label>
                                                                            <!-- Input taking remaining space -->
                                                                            <div class="flex-1">
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txttermtyp" runat="server" TabIndex="170" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                    <div class="w-full">
                                                                        <div class="group relative flex items-center gap-4">
                                                                            <!-- Label with fixed width -->
                                                                            <label class="text-gray-500 text-sm font-medium w-[120px]">ITEM Code</label>
                                                                            <!-- Input and AutoCompleteExtender -->
                                                                            <div class="flex-1 relative">
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtInHouseItem" AutoPostBack="true" OnTextChanged="TxtInHouseItem_TextChanged" runat="server" TabIndex="171" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
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
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                    <%-- <div class="w-full">
                                                                        <div class="group relative flex items-center gap-4">
                                                                            <!-- Label with fixed width -->
                                                                            <div class="flex items-center gap-1 w-[120px]">
                                                                                <label class="text-gray-500 text-sm font-medium">HS Code</label>
                                                                                  <asp:ImageButton ID="btnhscode1" CssClass="theme_searchIcon mb-35" runat="server" ImageUrl="images/searchBlue.png" Height="28" Width="28" />
                                                                              
                                                                            </div>
                                                                            <!-- Input + AutoComplete -->
                                                                            <div class="flex-1 relative">
                                                                                  <asp:Label ID="is_inpayment_controlled" runat="server" Style="background: yellow;" />
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtHSCodeItem" OnTextChanged="TxtHSCodeItem_TextChanged" AutoPostBack="true" runat="server" TabIndex="172" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                <cc1:AutoCompleteExtender ServiceMethod="GetHSCodeItem"
                                                                                    MinimumPrefixLength="1"
                                                                                    CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
                                                                                    TargetControlID="TxtHSCodeItem"
                                                                                    ID="AutoCompleteExtender16" runat="server" FirstRowSelected="true">
                                                                                </cc1:AutoCompleteExtender>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator44" runat="server" ControlToValidate="TxtHSCodeItem" ErrorMessage="Item--->Please Enter HS Code" Display="None" ValidationGroup="Item" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                            </div>
                                                                        </div>
                                                                    </div>--%>

                                                                    <div class="w-full">
                                                                        <div class="group relative flex items-center gap-4">

                                                                            <!-- Label with fixed width -->

                                                                            <label class="text-gray-500 text-sm font-medium w-[70px]">HS Code </label>

                                                                            <asp:ImageButton ID="btnhscode1" CssClass="theme_searchIcon mb-35" runat="server" ImageUrl="images/searchBlue.png" Height="28" Width="28" />
                                                                            <!-- Input + AutoComplete + Icon -->
                                                                            <div class="flex-1 relative mt-1">

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
                                                                                    ID="AutoCompleteExtender16"
                                                                                    runat="server"
                                                                                    FirstRowSelected="true">
                                                                                </cc1:AutoCompleteExtender>

                                                                                <asp:RequiredFieldValidator
                                                                                    ID="RequiredFieldValidator8"
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

                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox4" OnTextChanged="HSCodeSearchItem_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>


                                                                                    </div>
                                                                                    <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                                        <asp:GridView ID="HSCodeGridItem" OnPageIndexChanging="HSCodeGridItem_PageIndexChanging1" PageSize="5" AllowPaging="True" DataKeyNames="Id" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
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

                                                                                                <asp:TemplateField Visible="false">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton ID="lnkHSCodeItem" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="lnkHSCodeItem_Click">Select </asp:LinkButton>
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

                                                                    <div class="w-full">
                                                                        <div class="group relative flex items-start gap-4">
                                                                            <!-- Label on the left -->
                                                                            <label class="text-gray-500 text-sm font-medium w-[120px] mt-1">Description</label>
                                                                            <!-- Multiline textbox and validators -->
                                                                            <div class="flex-1 relative">
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtDescription" ValidationGroup="Item" OnTextChanged="TxtDescription_TextChanged" AutoPostBack="true" TextMode="MultiLine" runat="server" TabIndex="173" type="text" CssClass="w-full h-[100px] pt-3 px-4 bg-slate-100 resize-none rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" ControlToValidate="TxtDescription" ErrorMessage="Item--->Please Enter Description" Display="None" ValidationGroup="Item" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtDescription" ID="RegularExpressionValidator24" ValidationExpression="^[\s\S]{0,512}$" runat="server" ErrorMessage="Maximum 512 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>


                                                                                <br />
                                                                                <asp:LinkButton ID="lnkcopydesc" runat="server" CssClass="pull-right" OnClick="lnkcopydesc_Click" Text="Copy To All"></asp:LinkButton>


                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                    <asp:Label ID="LblCount" ForeColor="Navy" runat="server" TabIndex="5"></asp:Label>


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
                                                                                TargetControlID="TxtCountryItem" ID="AutoCompleteExtender17" runat="server" FirstRowSelected="true">
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

                                                                    <%--                                                                    <div class="w-full">
                                                                        <div class="group relative flex items-start gap-4">
                                                                            <!-- Label with fixed width -->
                                                                            <label class="text-gray-500 text-sm font-medium w-[120px] mt-1">Country of Origin</label>
                                                                            <!-- Country inputs and modal -->
                                                                            <div class="flex-1">
                                                                                <div class="flex items-center gap-1 mb-2">
                                                                                  
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" Width="100" ID="TxtCountryItem" OnTextChanged="TxtCountryItem_TextChanged" AutoPostBack="true" runat="server" TabIndex="110" type="text" CssClass="h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium outline-none border-none px-2 w-[100px]"></asp:TextBox>
                                                                                </div>

                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txtcname" TabIndex="111" runat="server" Enabled="false" CssClass="w-full h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>


                                                                                <cc1:AutoCompleteExtender ServiceMethod="GetCountryItem" MinimumPrefixLength="1" CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10" TargetControlID="TxtCountryItem" ID="AutoCompleteExtender17" runat="server" FirstRowSelected="true"></cc1:AutoCompleteExtender>

                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TxtCountryItem" Font-Size="XX-Small" ForeColor="Red" ErrorMessage="Item --> Please Enter Country Of Orgin" ValidationGroup="Item"></asp:RequiredFieldValidator>



                                                                                

                                                                            </div>
                                                                        </div>
                                                                    </div>--%>

                                                                    <cc1:ModalPopupExtender ID="popupcountryoforgin" runat="server" PopupControlID="pnlcountryoforgin" TargetControlID="btnorgincountry1" OkControlID="btnyesco" CancelControlID="btnnoco" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>

                                                                    <asp:Panel ID="pnlcountryoforgin" runat="server" CssClass="modalPopup" Style="display: none">
                                                                        <div class="header">Origin Country</div>
                                                                        <div class="body">
                                                                            <asp:UpdatePanel ID="upcountryoforgin" runat="server" UpdateMode="Conditional">
                                                                                <ContentTemplate>

                                                                                    <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                        <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="CountrySearchItem" OnTextChanged="CountrySearchItem_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                    </div>
                                                                                    <br />
                                                                                    <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                                        <asp:GridView ID="CountryGridItem" OnPageIndexChanging="CountryGridItem_PageIndexChanging" PageSize="5" AllowPaging="True" DataKeyNames="Id" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" OnRowDataBound="CountryGridItem_RowDataBound" OnRowCommand="CountryGridItem_RowCommand" runat="server" AutoGenerateColumns="false">
                                                                                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                            <Columns>
                                                                                                <asp:TemplateField HeaderText="CountryCode" SortExpression="Id">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblName" runat="server" Text='<%#Eval("CountryCode")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Description" SortExpression="Id">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblName1" runat="server" Text='<%#Eval("Description")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField Visible="false">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton ID="lnkCountryItem" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="lnkCountryItem_Click">Select </asp:LinkButton>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                            </Columns>
                                                                                        </asp:GridView>
                                                                                    </div>
                                                                                    <div class="footer" align="right">
                                                                                        <asp:Button ID="btnyesco" runat="server" Style="display: none;" Text="Yes" CssClass="yes" />
                                                                                        <asp:Button ID="btnnoco" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px] mt-4 w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700 " />
                                                                                    </div>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                    </asp:Panel>




                                                                </div>
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


                                                                    <div class="w-full">
                                                                        <div class="group relative flex items-center gap-4">
                                                                            <!-- Label with fixed width -->
                                                                            <label class="text-gray-500 text-sm font-medium w-[120px]">Brand</label>
                                                                            <!-- Input taking remaining space -->
                                                                            <div class="flex-1">
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Type Brand Name" autocomplete="off" ID="TxtBrand" MaxLength="35" ValidationGroup="Item" runat="server" TabIndex="114" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" Style="text-transform: uppercase"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TxtBrand" Font-Size="XX-Small" ForeColor="Red" ErrorMessage="Item --> Please Enter Brand" ValidationGroup="Item"></asp:RequiredFieldValidator>
                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtBrand" ID="RegularExpressionValidator9" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>

                                                                                <br />
                                                                                <asp:LinkButton ID="lnkcopybrand" runat="server" CssClass="pull-right" OnClick="lnkcopybrand_Click" Text="Copy To All"></asp:LinkButton>
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                    <div class="w-full">
                                                                        <div class="group relative flex items-center gap-4">
                                                                            <!-- Label with fixed width -->
                                                                            <label class="text-gray-500 text-sm font-medium w-[120px]">Model</label>
                                                                            <!-- Input taking remaining space -->
                                                                            <div class="flex-1">
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Type Model" autocomplete="off" ID="TxtModel" MaxLength="35" runat="server" ValidationGroup="Item" TabIndex="115" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" Style="text-transform: uppercase"></asp:TextBox>
                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtModel" ID="RegularExpressionValidator25" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                <br />
                                                                                <asp:LinkButton ID="lnkcopymodel" runat="server" CssClass="pull-right" OnClick="lnkcopymodel_Click" Text="Copy To All"></asp:LinkButton>
                                                                            </div>
                                                                        </div>
                                                                    </div>



                                                                    <div class="w-full">
                                                                        <div class="w-full bg-gray-700 text-center rounded-full py-2 mb-6">
                                                                            <span class="text-white text-sm font-semibold tracking-wide">Item Quantity

                                                                            </span>

                                                                        </div>
                                                                        <div class="mt-4 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">

                                                                            <div class=" w-full" id="duti" visible="false" runat="server">

                                                                                <div class="group relative flex items-center gap-4">
                                                                                    <!-- Label with fixed width -->
                                                                                    <label class="text-gray-500 text-sm font-medium w-[120px]">Dutiable Quantity</label>
                                                                                    <!-- Split input/dropdown -->
                                                                                    <div class="flex-1">
                                                                                        <div class="flex bg-slate-100 rounded-md w-full h-10">
                                                                                            <div class="w-1/2">
                                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="2" autocomplete="off" runat="server" type="text" onkeypress="return isNumberKey(event)" ValidationGroup="Item" Text="0.00" ID="TxtTotalDutiableQuantity" MaxLength="16" OnTextChanged="TxtTotalDutiableQuantity_TextChanged" AutoPostBack="true" TabIndex="122" CssClass="w-full h-10 bg-slate-100 rounded-l-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                            </div>
                                                                                            <svg class="mt-3" width="1" height="16" viewBox="0 0 1 16" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                                                <line x1="0.5" y1="2.18561e-08" x2="0.499999" y2="16" stroke="#BCBCC4"></line>
                                                                                            </svg>
                                                                                            <div class="w-1/2">
                                                                                                <asp:DropDownList CssClass="drop font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt- px-4 focus:outline-none" ID="TDQUOM" runat="server" TabIndex="123"></asp:DropDownList>
                                                                                                <br />
                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtTotalDutiableQuantity" ID="RegularExpressionValidator71" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>





                                                                            </div>



                                                                        </div>
                                                                        <div class="group relative flex items-center gap-4">
                                                                            <!-- Label with fixed width -->
                                                                            <label class="text-gray-500 text-sm font-medium w-[120px]">Total Dutiable Quantity</label>
                                                                            <!-- Split input/dropdown -->
                                                                            <div class="flex-1">
                                                                                <div class="flex bg-slate-100 rounded-md w-full h-10">
                                                                                    <div class="w-1/2">
                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="2" autocomplete="off" runat="server" type="text" onkeypress="return isNumberKey(event)" ValidationGroup="Item" Text="0.00" ID="txttotDutiableQty" MaxLength="16" OnTextChanged="txttotDutiableQty_TextChanged" AutoPostBack="true" TabIndex="122" CssClass="w-full h-10 bg-slate-100 rounded-l-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                    </div>
                                                                                    <svg class="mt-3" width="1" height="16" viewBox="0 0 1 16" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                                        <line x1="0.5" y1="2.18561e-08" x2="0.499999" y2="16" stroke="#BCBCC4"></line>
                                                                                    </svg>
                                                                                    <div class="w-1/2">
                                                                                        <asp:DropDownList CssClass="drop font-normal rounded-r-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 px-4 focus:outline-none bg-slate-100" ID="ddptotDutiableQty" runat="server" TabIndex="123"></asp:DropDownList>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                    <div class="w-full">
                                                                        <div class="group relative flex items-center gap-4">
                                                                            <!-- Label with fixed width -->
                                                                            <label class="text-gray-500 text-sm font-medium w-[120px]">Invoice Quantity</label>
                                                                            <!-- Input taking remaining space -->
                                                                            <div class="flex-1">
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Type Invoice Quantity" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" AutoPostBack="true" ValidationGroup="Item" type="text" onkeypress="return isNumberKey(event)" OnTextChanged="TxtInvQty_TextChanged" Text="0.00" ID="TxtInvQty" TabIndex="124"></asp:TextBox>
                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtInvQty" ID="RegularExpressionValidator26" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                <asp:Label runat="server" ID="lblinvqty" Visible="false" ForeColor="Red" BackColor="Yellow"></asp:Label>
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                    <div class="w-full">
                                                                        <div class="group relative flex items-center gap-4">
                                                                            <!-- Label with fixed width -->
                                                                            <label class="text-gray-500 text-sm font-medium w-[120px]" style="margin-top: -39px;">HS Quantity</label>
                                                                            <!-- Split input/dropdown -->
                                                                            <div class="flex-1">
                                                                                <div class="flex bg-slate-100 rounded-md w-full h-10">
                                                                                    <div class="w-1/2">
                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Type Quantity" autocomplete="off" runat="server" Text="0.00" ValidationGroup="Item" type="text" onkeypress="return isNumberKey(event)" MaxLength="16" ID="TxtHSQuantity" TabIndex="125" CssClass="w-full h-10 bg-slate-100 rounded-l-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                    </div>
                                                                                    <svg class="mt-3" width="1" height="16" viewBox="0 0 1 16" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                                        <line x1="0.5" y1="2.18561e-08" x2="0.499999" y2="16" stroke="#BCBCC4"></line>
                                                                                    </svg>
                                                                                    <div class="w-1/2">
                                                                                        <asp:DropDownList CssClass="drop font-normal rounded-r-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 px-4 focus:outline-none bg-slate-100" ID="HSQTYUOM" runat="server" OnSelectedIndexChanged="HSQTYUOM_SelectedIndexChanged" AutoPostBack="true" TabIndex="126"></asp:DropDownList>
                                                                                    </div>
                                                                                </div>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TxtHSQuantity" Font-Size="XX-Small" ForeColor="Red" ErrorMessage="Item --> Please Enter HS QTY" ValidationGroup="Item"></asp:RequiredFieldValidator>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="HSQTYUOM" InitialValue="0" Font-Size="XX-Small" ForeColor="Red" ErrorMessage="Item --> Please Enter HS UOM" ValidationGroup="Item"></asp:RequiredFieldValidator>
                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtHSQuantity" ID="RegularExpressionValidator32" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                <asp:Label ID="LblHSErr" ForeColor="Red" runat="server"></asp:Label>
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                    <div class="w-full" id="AlcoholDiv" visible="true" runat="server">
                                                                        <div class="w-full">
                                                                            <div class="group relative flex items-center gap-4">
                                                                                <!-- Label with fixed width -->
                                                                                <label class="text-gray-500 text-sm font-medium w-[120px]">Alcohol Per(%)</label>
                                                                                <!-- Input taking remaining space -->
                                                                                <div class="flex-1">
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="Item" type="text" onkeypress="return isNumberKey(event)" Text="0.00" AutoPostBack="true" ID="txtAlcoholPer" OnTextChanged="txtAlcoholPer_TextChanged" TabIndex="127" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                        </div>




                                                                    </div>

                                                                    <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-6" style="display: none;">
                                                                        <span class="text-white text-sm font-semibold tracking-wide">Additional Features</span>
                                                                    </div>

                                                                    <div class="mt-2 mb-2" style="display: none;">

                                                                        <!-- First Row -->
                                                                        <div class="flex gap-8 mb-4 justify-between">
                                                                            <div class="flex gap-2 items-center">
                                                                                <asp:CheckBox ID="ChkPackInfo" OnCheckedChanged="ChkPackInfo_CheckedChanged" runat="server" AutoPostBack="true" TabIndex="214" />
                                                                                <label for="styled-checkbox-93" class="text-gray-500 text-sm">Packing Info</label>
                                                                            </div>

                                                                            <div class="flex gap-2 items-center">
                                                                                <asp:CheckBox ID="Chkitemcasc" runat="server" OnCheckedChanged="Chkitemcasc_CheckedChanged" AutoPostBack="true" TabIndex="223" />
                                                                                <label for="styled-checkbox-93" class="text-gray-500 text-sm">itemcasc</label>
                                                                            </div>
                                                                        </div>

                                                                        <!-- Second Row -->
                                                                        <div class="flex gap-8 justify-between">
                                                                            <div class="flex gap-2 items-center">
                                                                                <asp:CheckBox ID="ChkTariff" runat="server" OnCheckedChanged="ChkTariff_CheckedChanged" AutoPostBack="true" />
                                                                                <label for="styled-checkbox-93" class="text-gray-500 text-sm">Tariff</label>
                                                                            </div>

                                                                            <div class="flex gap-2 items-center">
                                                                                <asp:CheckBox ID="Chklot" runat="server" OnCheckedChanged="Chklot_CheckedChanged" AutoPostBack="true" />
                                                                                <label for="styled-checkbox-93" class="text-gray-500 text-sm">LOT Identification</label>
                                                                            </div>
                                                                        </div>

                                                                    </div>
                                                                </div>

                                                                <div class="space-y-4">

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


                                                                    <div class="w-full">
                                                                        <div class="group relative flex items-center gap-4">
                                                                            <!-- Label with fixed width -->
                                                                            <label class="text-gray-500 text-sm font-medium w-[120px]">Invoice</label>
                                                                            <!-- Input taking remaining space -->
                                                                            <div class="flex-1">
                                                                                <asp:DropDownList CssClass="focus:outline-none bg-slate-100 font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 px-4" runat="server" type="text" ID="DrpInvoiceNo" OnSelectedIndexChanged="DrpInvoiceNo_SelectedIndexChanged" AutoPostBack="true" TabIndex="128"></asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                    <div class="w-full">
                                                                        <div class="group relative flex items-center gap-4">
                                                                            <!-- Label with checkbox -->
                                                                            <div class="flex items-center gap-2 w-[120px]">
                                                                                <label class="text-gray-500 text-sm font-medium">Currency</label>
                                                                                <asp:CheckBox ID="ChkUnitPrice" CausesValidation="true" OnCheckedChanged="ChkUnitPrice_CheckedChanged" AutoPostBack="true" runat="server" />
                                                                            </div>
                                                                            <!-- Split input/dropdown -->
                                                                            <div class="flex-1">
                                                                                <div class="flex bg-slate-100 rounded-md w-full h-10">
                                                                                    <div class="w-1/2">
                                                                                        <asp:DropDownList ID="DRPCurrency" CausesValidation="true" OnSelectedIndexChanged="DRPCurrency_SelectedIndexChanged" TabIndex="129" AutoPostBack="true" runat="server" CssClass="focus:outline-none drop font-normal rounded-l-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 px-4 bg-slate-100"></asp:DropDownList>
                                                                                    </div>
                                                                                    <svg class="mt-3" width="1" height="16" viewBox="0 0 1 16" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                                        <line x1="0.5" y1="2.18561e-08" x2="0.499999" y2="16" stroke="#BCBCC4"></line>
                                                                                    </svg>
                                                                                    <div class="w-1/2">
                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtExchangeRate" Enabled="false" TabIndex="130" Text="0.00" runat="server" CssClass="w-full h-10 bg-slate-100 rounded-r-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="DRPCurrency" InitialValue="0" Font-Size="XX-Small" ForeColor="Red" ErrorMessage="Item --> Please Enter Invoice Currency" ValidationGroup="Item"></asp:RequiredFieldValidator>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="TxtExchangeRate" Font-Size="XX-Small" ForeColor="Red" ErrorMessage="Item --> Please Enter Invoice Currency EX Rate" ValidationGroup="Item"></asp:RequiredFieldValidator>
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                    <%--   <div class="w-full">
                                                                        <div class="group relative flex items-center gap-4">
                                                                            <!-- Label with fixed width -->
                                                                            <label class="text-gray-500 text-sm font-medium w-[120px]">Unit Price</label>
                                                                            <!-- Split input design -->
                                                                            <div class="flex-1">
                                                                                <div class="flex bg-slate-100 rounded-md w-full h-10">
                                                                                    <div class="w-1/2">
                                                                                        <div class="relative w-full">
                                                                                            <input placeholder="2" type="text" name="" id="" class="w-full h-10 bg-slate-100 rounded-l-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                                        </div>
                                                                                    </div>
                                                                                    <svg class="mt-3" width="1" height="16" viewBox="0 0 1 16" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                                        <line x1="0.5" y1="2.18561e-08" x2="0.499999" y2="16" stroke="#BCBCC4"></line>
                                                                                    </svg>
                                                                                    <div class="w-1/2">
                                                                                        <div class="relative w-full">
                                                                                            <input placeholder="2" type="text" name="" id="" class="w-full h-10 bg-slate-100 rounded-r-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>--%>

                                                                    <div class="w-full">
                                                                        <div class="group relative flex items-center gap-4">
                                                                            <!-- Label with fixed width -->
                                                                            <label class="text-gray-500 text-sm font-medium w-[120px]">Unit Price Value</label>
                                                                            <!-- Input taking remaining space -->
                                                                            <div class="flex-1">
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" Text="0.00" ID="TxtUnitPrice" TabIndex="193" OnTextChanged="TxtUnitPrice_TextChanged" AutoPostBack="true" Visible="false" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                    <div class="w-full">
                                                                        <div class="group relative flex items-center gap-4">
                                                                            <!-- Label with fixed width -->
                                                                            <label class="text-gray-500 text-sm font-medium w-[120px]">Sum Ex Rate</label>
                                                                            <!-- Input taking remaining space -->
                                                                            <div class="flex-1">
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" Visible="false" type="text" ID="TxtSumExRate" Text="0.00" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                    <div class="w-full">
                                                                        <div class="group relative flex items-center gap-4">
                                                                            <!-- Label with fixed width -->
                                                                            <label class="text-gray-500 text-sm font-medium w-[120px]">Total Line Amount</label>
                                                                            <!-- Input taking remaining space -->
                                                                            <div class="flex-1">
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Type Amount" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" onfocus="removeCommas(this)" onkeypress="return isNumberKey(event)" OnBlur="addCommas(this)" CausesValidation="true" OnTextChanged="TxtTotalLineAmount_TextChanged" ValidationGroup="Item" Text="0.00" AutoPostBack="true" runat="server" type="text" ID="TxtTotalLineAmount" TabIndex="134"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" InitialValue="0.00" ControlToValidate="TxtTotalLineAmount" Font-Size="XX-Small" ForeColor="Red" ErrorMessage="Item --> Please Enter Total Line Amount" ValidationGroup="Item"></asp:RequiredFieldValidator>
                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtTotalLineAmount" ID="RegularExpressionValidator10" ValidationExpression="^[0-9\s\.\,]+$" runat="server" ErrorMessage="Not Accepted Special Charector" ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                    <div class="w-full">
                                                                        <div class="group relative flex items-center gap-4">
                                                                            <!-- Label with fixed width -->
                                                                            <label class="text-gray-500 text-sm font-medium w-[120px]">Total Invoice Charged (SGD)</label>
                                                                            <!-- Input taking remaining space -->
                                                                            <div class="flex-1">
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Type Amount" autocomplete="off" runat="server" Enabled="false" type="text" onfocus="removeCommas(this)" OnBlur="addCommas(this)" ID="TxtTotalLineCharges" Text="0.00" TabIndex="135" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                    <div class="w-full">
                                                                        <div class="group relative flex items-center gap-4">
                                                                            <!-- Label with fixed width -->
                                                                            <label class="text-gray-500 text-sm font-medium w-[120px]">CIF/FOB</label>
                                                                            <!-- Input taking remaining space -->
                                                                            <div class="flex-1">
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Type Amount" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" Enabled="false" type="text" onfocus="removeCommas(this)" OnBlur="addCommas(this)" ID="TxtCIFFOB" Text="0.00" TabIndex="135"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                    <div class="w-full">
                                                                        <div class="group relative flex items-center gap-4">
                                                                            <!-- Label with fixed width -->
                                                                            <label class="text-gray-500 text-sm font-medium w-[120px]">Last Selling Price (SGD)</label>
                                                                            <!-- Input taking remaining space -->
                                                                            <div class="flex-1">
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Type Amount" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" onkeypress="return isNumberKey(event)" type="text" ID="txtlsp" Text="0.00" MaxLength="16" OnTextChanged="txtlsp_TextChanged" AutoPostBack="true" TabIndex="136"></asp:TextBox>
                                                                                <asp:Label Font-Size="9" Text="Last selling Price (SGD)" ID="lblsp" Visible="false" runat="server"></asp:Label>
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                </div>
                                                            </div>


                                                            <div class="mt-4 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2" id="Vehicle" visible="false" runat="server">
                                                                <div class="md:max-w-[250px] w-full">
                                                                    <div class="group relative">
                                                                        <label class="text-gray-500 text-sm font-medium">Vehicle Type</label>
                                                                        <asp:DropDownList ID="DrpVehicleType" runat="server" TabIndex="178" CssClass="focus:outline-none bg-slate-100 font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt-1 px-4"></asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div class="md:max-w-[250px] w-full">
                                                                    <div class="group relative">
                                                                        <label class="text-gray-500 text-sm font-medium">Engine Capacity</label>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" Text="" ID="txtengine" onkeypress="return isNumberKey(event)" TabIndex="179" CssClass="focus:outline-none bg-slate-100 font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt-1 px-4"></asp:TextBox>

                                                                    </div>
                                                                </div>
                                                                <div class="md:max-w-[250px] w-full">
                                                                    <div class="group relative">
                                                                        <label class="text-gray-500 text-sm font-medium">Engine Capacity</label>
                                                                        <asp:DropDownList ID="DrpVehicleCapacity" runat="server" TabIndex="180" CssClass="focus:outline-none bg-slate-100 font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt-1 px-4"></asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div class="md:max-w-[250px] w-full" id="dd" runat="server">
                                                                    <div class="group relative">
                                                                        <label class="text-gray-500 text-sm font-medium">Original Regn Date</label>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txtorgindate" TabIndex="181" runat="server" AutoPostBack="true" onkeypress="return isNumberKey(event)" OnTextChanged="txtorgindate_TextChanged" CssClass="focus:outline-none bg-slate-100 font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt-1 px-4"></asp:TextBox>
                                                                        <cc1:CalendarExtender ID="CalendarExtender7" CssClass="cal_Theme1" PopupButtonID="imgPopup" runat="server" TargetControlID="txtorgindate" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"></cc1:CalendarExtender>
                                                                    </div>
                                                                </div>
                                                            </div>






                                                            <div class="mt-4 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2" id="extrsItemDiv" visible="true" runat="server">


                                                                <div class="md:max-w-[250px] w-full"></div>
                                                                <div class="md:max-w-[250px] w-full"></div>
                                                            </div>

                                                            <div class="mt-4 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2" id="OptionalCharges" visible="false" runat="server">
                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Optional Charges</label>
                                                                    <div class="relative mt-1 top-[4px] bg-slate-100 rounded-md h-11">
                                                                        <asp:DropDownList ID="DrpOptionalUom" CausesValidation="true" TabIndex="194" AutoPostBack="true" OnSelectedIndexChanged="DrpOptionalUom_SelectedIndexChanged" runat="server" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:DropDownList>
                                                                        <asp:RequiredFieldValidator BackColor="Red" InitialValue="0" ID="RequiredFieldValidator27" runat="server" ControlToValidate="DRPCurrency" Display="None" ErrorMessage="Item --> Plase Select Currency info" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Optional Charges</label>
                                                                    <div class="relative mt-1 top-[4px] bg-slate-100 rounded-md h-11">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" Text="0.00" ID="TxtOptionalPrice" OnTextChanged="TxtOptionalPrice_TextChanged" AutoPostBack="true" TabIndex="195" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    </div>
                                                                </div>

                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Optional Charges</label>
                                                                    <div class="relative mt-1 top-[4px] bg-slate-100 rounded-md h-11">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtOptionalExchageRate" TabIndex="196" Text="0.00" AutoPostBack="true" onkeypress="return isNumberKey(event)" OnTextChanged="TxtOptionalExchageRate_TextChanged" runat="server" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator BackColor="Red" InitialValue="0.00" ID="RequiredFieldValidator104" runat="server" ControlToValidate="TxtExchangeRate" Display="None" ErrorMessage="Item --> Plase Enter Amount" ValidationGroup="Item"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Optional Charges</label>
                                                                    <div class="relative mt-1 top-[4px] bg-slate-100 rounded-md h-11">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="TxtOptionalSumExRate" TabIndex="197" Text="0.00" Enabled="false" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    </div>
                                                                </div>

                                                            </div>










                                                            <div id="PackingInfo" visible="true" runat="server">
                                                                <div class="mt-6">
                                                                    <div class="flex justify-between gap-2 items-center">
                                                                        <h2 class="text-lg sa700 leading-[18px] text-gray-800">Package Information
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
                                                                            <div class="md:max-w-[250px] w-full">
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
                                                                            <div class="md:max-w-[250px] w-full">
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
                                                                            <div class="md:max-w-[250px] w-full">
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
                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtINPQty" ID="RegularExpressionValidator14" ValidationExpression="^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 8 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                            </div>


                                                                            <div class="md:max-w-[250px] w-full">
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



                                                            <div class="mt-6" id="LOTID" runat="server">
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
                                                                <div aria-label="Main" id="drop_draft_1_area" class="duration-300 ease-in-out transition-all hidden">
                                                                    <div class="mt-2 flex items-center gap-4 lg:flex-nowrap flex-wrap">
                                                                        <div class="md:max-w-[250px] w-full">
                                                                            <label class="text-gray-500 text-sm font-medium">Current Lot</label>
                                                                            <div class="relative mt-1">
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Type Quantity" autocomplete="off" runat="server" type="text" ID="TxtCurrentLot" MaxLength="30" TabIndex="167" ValidationGroup="Item" class="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtCurrentLot" ID="RegularExpressionValidator29" ValidationExpression="^[\s\S]{0,30}$" runat="server" ErrorMessage="Maximum 30 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                            </div>
                                                                        </div>
                                                                        <div class="md:max-w-[250px] w-full">
                                                                            <label class="text-gray-500 text-sm font-medium">Previous Lot</label>
                                                                            <div class="relative mt-1">
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ValidationGroup="Item" ID="TxtPreviousLot" MaxLength="30" TabIndex="169" class="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                <asp:RegularExpressionValidator placeholder="Type Quantity" Display="Dynamic" BackColor="yellow" ControlToValidate="TxtPreviousLot" ID="RegularExpressionValidator30" ValidationExpression="^[\s\S]{0,30}$" runat="server" ErrorMessage="Maximum 30 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                            </div>
                                                                        </div>
                                                                        <div class="md:max-w-[250px] w-full">
                                                                            <div class="group relative">
                                                                                <div class="text-gray-500 text-sm font-medium">Marking</div>
                                                                                <asp:DropDownList CssClass="focus:outline-none bg-slate-100 font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt-1 px-4" runat="server" TabIndex="168" ID="DrpMaking"></asp:DropDownList>
                                                                            </div>
                                                                        </div>

                                                                    </div>
                                                                    <!--  -->
                                                                </div>
                                                            </div>

                                                            <div id="Tariff" runat="server" class="mt-6">
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
                                                                        <div class="md:max-w-[250px] w-full">
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

                                                                                <asp:ValidationSummary ID="ValidationSummary10" runat="server" ShowMessageBox="True"
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
                                                                                                        <asp:Button ID="Button1" runat="server" Text="Copy Of HS-Quantity" OnClick="Button2_Click" Visible="true" />
                                                                                                        <p><%--<i class='fa fa-search' data-toggle="modal" data-target="#Product2"></i>--%></p>
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
                                                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ProductCode1Search" OnTextChanged="ProductCode1Search_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
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

                                                                                                        <asp:GridView CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" ID="ProductCode1Grid1" runat="server" ShowFooter="true" AutoGenerateColumns="false">
                                                                                                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                            <Columns>

                                                                                                                <asp:BoundField DataField="Product Code    " HeaderText="Seq." Visible="false" />

                                                                                                                <asp:TemplateField HeaderText="CASC CODE 1">

                                                                                                                    <ItemTemplate>

                                                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox1" MaxLength="35" CssClass="w-full h-11 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="150" runat="server"></asp:TextBox>

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
                                                                                                            <asp:Button ID="Button2" OnClick="Button2_Click1" runat="server" Text="Copy Of HS-Quantity" Visible="true" />
                                                                                                            <p><%--<i class='fa fa-search' data-toggle="modal" data-target="#Product2"></i>--%></p>
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
                                                                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ProductCode2Search" OnTextChanged="ProductCode2Search_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
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

                                                                                                            <asp:GridView CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" ID="ProductCode2Grid1" runat="server" ShowFooter="true" AutoGenerateColumns="false">
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
                                                                                    <div id="collapsep1dz" class="panel-collapse collapse-show ">
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

                                                                                                            <asp:Button ID="Button8" OnClick="Button8_Click" runat="server" Text="Copy Of HS-Quantity" Visible="true" />

                                                                                                            <p>

                                                                                                                <%--<i class='fa fa-search' data-toggle="modal" data-target="#Product3"></i>--%>
                                                                                                            </p>
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

                                                                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ProductCode3Search" OnTextChanged="ProductCode3Search_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                                                            <br />
                                                                                                                            <asp:DropDownList ID="ddlpc3" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlpc3_SelectedIndexChanged">

                                                                                                                                <asp:ListItem>10</asp:ListItem>

                                                                                                                                <asp:ListItem>20</asp:ListItem>

                                                                                                                                <asp:ListItem>30</asp:ListItem>

                                                                                                                                <asp:ListItem>All</asp:ListItem>

                                                                                                                            </asp:DropDownList>
                                                                                                                            <asp:GridView ID="ProductCode3Grid" PageSize="5" OnPageIndexChanging="ProductCode3Grid_PageIndexChanging" AllowPaging="True" DataKeyNames="Id" CssClass="table table-stri onped table-bordered table-hover" runat="server" OnRowCommand="ProductCode3Grid_RowCommand" OnRowDataBound="ProductCode3Grid_RowDataBound" AutoGenerateColumns="false">
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

                                                                                                            <asp:GridView CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" ID="ProductCode3Grid1" runat="server" ShowFooter="true" AutoGenerateColumns="false">
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

                                                                                                            <asp:Button ID="Button10" OnClick="Button10_Click" runat="server" Text="Copy Of HS-Quantity" Visible="true" />
                                                                                                            <p>
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

                                                                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ProductCode4Search" OnTextChanged="ProductCode4Search_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
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

                                                                                                            <asp:GridView CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" ID="ProductCode4Grid1" runat="server" ShowFooter="true" AutoGenerateColumns="false">
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
                                                                                                            <asp:Button ID="Button11" runat="server" OnClick="Button11_Click" Text="Copy Of HS-Quantity" Visible="true" />
                                                                                                            <p>
                                                                                                            </p>


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

                                                                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ProductCode5Search" OnTextChanged="ProductCode5Search_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
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

                                                                                                            <asp:GridView CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" ID="ProductCode5Grid1" runat="server" ShowFooter="true" AutoGenerateColumns="false">
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

                                                                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox3" MaxLength="35" CssClass="w-full h-11 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>

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








                                                            <div class="mt-6" id="ShippMarkDiv" runat="server">
                                                                <div class="flex justify-between gap-2 items-center">
                                                                    <h2 class="text-lg sa700 leading-[18px] text-gray-800">SHIPPING MARKS INFORMATION
                                                                    </h2>
                                                                    <div onclick="drop_draft_4();" class="bg-[#0560FD] bg-opacity-5 w-7 h-7 flex justify-center items-center rounded-full">
                                                                        <svg id="drop_draft_4_Svg" width="20" height="20" viewBox="0 0 20 20" fill="none" xmlns="http://www.w3.org/2000/svg" class="">
                                                                            <path d="M5 9.58301L9.43692 5.51584C9.70425 5.27076 9.83792 5.14826 10 5.14826C10.1621 5.14826 10.2958 5.27076 10.5631 5.51584L15 9.58301" stroke="#0560FD" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                                                            <path d="M5 15L9.43692 10.9328C9.70425 10.6877 9.83792 10.5652 10 10.5652C10.1621 10.5652 10.2958 10.6877 10.5631 10.9328L15 15" stroke="#0560FD" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                                                        </svg>
                                                                    </div>
                                                                </div>
                                                                <!--  -->
                                                                <!--  -->
                                                                <div aria-label="Main" id="drop_draft_4_area" class="duration-300 ease-in-out transition-all hidden">
                                                                    <div class="mt-2 flex items-center gap-4 lg:flex-nowrap flex-wrap">
                                                                        <div class="md:max-w-[250px] w-full">
                                                                            <label class="text-gray-500 text-sm font-medium">Shipping Marks 1</label>
                                                                            <div class="relative mt-1">

                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="txtShippingMarks1" Style="text-transform: uppercase" MaxLength="17" TextMode="MultiLine" TabIndex="260" ValidationGroup="Shipping" CssClass="focus:outline-none bg-slate-100 font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt-1 px-4"></asp:TextBox>
                                                                                <br />
                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtShippingMarks1" ID="RegularExpressionValidator31" ValidationExpression="^[\s\S]{0,170}$" runat="server" ErrorMessage="Maximum 170 characters allowed." ValidationGroup="Shipping"></asp:RegularExpressionValidator>

                                                                            </div>
                                                                        </div>
                                                                        <div class="md:max-w-[250px] w-full">
                                                                            <label class="text-gray-500 text-sm font-medium">Shipping Marks 2</label>
                                                                            <div class="relative mt-1">
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="txtShippingMarks2" Style="text-transform: uppercase" MaxLength="17" TextMode="MultiLine" TabIndex="261" ValidationGroup="Shipping" CssClass="focus:outline-none bg-slate-100 font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt-1 px-4"></asp:TextBox>
                                                                                <br />
                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtShippingMarks2" ID="RegularExpressionValidator101" ValidationExpression="^[\s\S]{0,170}$" runat="server" ErrorMessage="Maximum 170 characters allowed." ValidationGroup="Shipping"></asp:RegularExpressionValidator>
                                                                            </div>
                                                                        </div>
                                                                        <div class="md:max-w-[250px] w-full">
                                                                            <div class="group relative">
                                                                                <div class="text-gray-500 text-sm font-medium">Shipping Marks 3</div>
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="txtShippingMarks3" Style="text-transform: uppercase" MaxLength="17" TextMode="MultiLine" TabIndex="262" ValidationGroup="Shipping" CssClass="focus:outline-none bg-slate-100 font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt-1 px-4"></asp:TextBox>
                                                                                <br />
                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtShippingMarks3" ID="RegularExpressionValidator86" ValidationExpression="^[\s\S]{0,136}$" runat="server" ErrorMessage="Maximum 136 characters allowed." ValidationGroup="Shipping"></asp:RegularExpressionValidator>
                                                                            </div>
                                                                        </div>

                                                                        <div class="md:max-w-[250px] w-full">
                                                                            <div class="group relative">
                                                                                <div class="text-gray-500 text-sm font-medium">Shipping Marks 4</div>
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="txtShippingMarks4" MaxLength="17" TextMode="MultiLine" TabIndex="263" ValidationGroup="Shipping" Style="text-transform: uppercase" CssClass="focus:outline-none bg-slate-100 font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt-1 px-4"></asp:TextBox>
                                                                                <br />
                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtShippingMarks4" ID="RegularExpressionValidator87" ValidationExpression="^[\s\S]{0,36}$" runat="server" ErrorMessage="Maximum 36 characters allowed." ValidationGroup="Shipping"></asp:RegularExpressionValidator>
                                                                            </div>
                                                                        </div>

                                                                    </div>
                                                                    <!--  -->
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
                                                                            <asp:Label runat="server" ID="Error" />
                                                                        </div>

                                                                    </div>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:PostBackTrigger ControlID="BtnExcelUp" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>

                                                            <hr />
                                                            <div class="row">
                                                                <!-- Importer Search -->

                                                                <div class="col-sm-8">
                                                                </div>
                                                                <asp:ValidationSummary ID="ValidationSummary11" runat="server" ShowMessageBox="True"
                                                                    ShowSummary="False" ValidationGroup="Item" />
                                                                <div class="col-sm-4">
                                                                    <asp:Button ID="BtnItemAdd" CssClass="btn btn-block btn-success" ValidationGroup="Item" runat="server" Visible="false" Text="Add Item" OnClick="BtnItemAdd_Click" />

                                                                </div>

                                                                <div class="col-sm-8">
                                                                </div>
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
                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="InhouseSearchItem" OnTextChanged="InhouseSearchItem_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                        <br />


                                                                                        <div class="row">
                                                                                            <div class="col-md-2">
                                                                                                <asp:Button ID="BtnItemDeleteAll" runat="server" OnClick="BtnItemDeleteAll_Click" Text="Delete All" class="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                                            </div>
                                                                                            <div class="col-md-2">
                                                                                                <asp:Button ID="BtnItemEditAll" runat="server" OnClick="BtnItemEditAll_Click" Text="Edit All" class="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />

                                                                                            </div>
                                                                                            <div class="col-md-8"></div>
                                                                                        </div>
                                                                                        <br />

                                                                                        <asp:GridView ID="InhouseGridItem" OnPageIndexChanging="InhouseGridItem_PageIndexChanging" PageSize="5" AllowPaging="True" DataKeyNames="Id" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" AutoGenerateColumns="false">
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
                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="HSCodeSearchItem" OnTextChanged="HSCodeSearchItem_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                        <br />
                                                                                        <%-- <asp:UpdatePanel ID="UpdatePanelHSCode" runat="server"  UpdateMode="Always">

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
                                                                        <%--<div class="row Borderdiv" style="width:100%">Item Information </div>--%>
                                                                        <div class="row">
                                                                            <div id="ItemSerNo" runat="server" visible="false" class="col-sm-6">

                                                                                <p>Serial Number</p>
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="TxtSerialNo"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server" ControlToValidate="TxtSerialNo" ErrorMessage="Please Enter Serial No"
                                                                                    Display="Dynamic" ValidationGroup="ItemMasterValidation" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                                <br />
                                                                            </div>

                                                                            <div class="col-sm-6">
                                                                            </div>

                                                                        </div>

                                                                    </div>
                                                                </div>

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
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="AddItemSearch" OnTextChanged="AddItemSearch_TextChanged" Visible="false" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server" Style="text-transform: uppercase"></asp:TextBox>
                                                            <br />



                                                            <div class="table-responsive">

                                                                <div class="row">

                                                                    <div class="col-md-4 box box-body">
                                                                        <label class="text-gray-500 text-sm font-medium">Action Buttons</label>
                                                                        <br />
                                                                        <div class="btn-group" role="group" aria-label="Basic example">


                                                                            <asp:Button ID="Btnselectitem" runat="server" OnClick="Btnselectitem_Click" Text="Delete" class="btn btn-primary bg-[#0560FD] border-[#0560FD] hover:bg-transparent hover:text-[#0560FD]" />


                                                                            <asp:Button ID="Button12" runat="server" OnClick="Button12_Click" Text="Delete All" class="btn btn-primary bg-[#0560FD] border-[#0560FD] hover:bg-transparent hover:text-[#0560FD]" />

                                                                            <asp:Button ID="Button13" Visible="false" runat="server" OnClick="BtnItemEditAll_Click" Text="Edit All" class="btn btn-primary bg-[#0560FD] border-[#0560FD] hover:bg-transparent hover:text-[#0560FD]" />



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


                                                                <asp:GridView ID="AddItemGrid" Font-Size="10" OnRowDeleting="AddItemGrid_RowDeleting" PageSize="50" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="AddItemGrid_PageIndexChanging" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" AutoGenerateColumns="false">
                                                                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                    <Columns>

                                                                        <asp:TemplateField>

                                                                            <HeaderTemplate>

                                                                                <asp:CheckBox ID="chkAll" runat="server"
                                                                                    onclick="checkAll(this);" />

                                                                            </HeaderTemplate>

                                                                            <ItemTemplate>

                                                                                <asp:CheckBox ID="chk" runat="server" OnCheckedChanged="chk_CheckedChanged" AutoPostBack="true" />

                                                                            </ItemTemplate>

                                                                        </asp:TemplateField>

                                                                        <%--<asp:TemplateField HeaderText="Del">
                <ItemTemplate>

                    <asp:LinkButton data-target='<%#"#"+DataBinder.Eval(Container.DataItem,"Id")%>' Width="11" OnClick="imgItemDelete_Click" Height="11" ID="imgItemDelete" runat="server"><i class='fa fa-trash' style="color:red;"> </i></asp:LinkButton>



                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Edit">
                <ItemTemplate>


                    <asp:ImageButton ImageUrl="~/IMG/edit.png" Width="11" Height="11" OnClick="ItemEdit_Click" ID="ItemEdit" runat="server" />




                </ItemTemplate>
            </asp:TemplateField>--%>
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

                                                                <asp:Button ID="btnsaveitem" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] bg-opacity-10 border hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-[#0560FD] text-center rounded-md text-sm sa700" runat="server" class="btn btn-info btn-lg" ValidationGroup="Item" OnClick="BtnItemAdd_Click" Text="+ Add Item" TabIndex="175" />


                                                                <%-- <button class="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] bg-opacity-10 border hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-[#0560FD] text-center rounded-md text-sm sa700">
                                                                    + Add Product
                                                                </button>--%>
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
                                                </asp:UpdatePanel>
                                            </ContentTemplate>
                                        </cc1:TabPanel>

                                        <cc1:TabPanel ID="CPC" runat="server" HeaderText="CPC">
                                            <ContentTemplate>
                                                <asp:UpdatePanel ID="upinnoncpc" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>



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

                                                                <asp:CheckBox ID="ChkSea1" OnCheckedChanged="ChkSea_CheckedChanged" AutoPostBack="true" runat="server" TabIndex="178" Checked="false" Style="text-transform: uppercase" />
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

                                                        <div class="row">
                                                            <div class="col-sm-12">
                                                                <center>

                                                                    <div class="flex justify-between gap-4 md:flex-nowrap flex-wrap mt-6">

                                                                        <asp:Button ID="btnprevcpc" runat="server" class="btn btn-info btn-lg" OnClick="btnprevcpc_Click" Text="Previous" TabIndex="284" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" />
                                                                        <asp:Button ID="btnsavecpc" runat="server" class="btn btn-info btn-lg" OnClick="btnsavecpc_Click" Text="Save" TabIndex="285" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" />
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

                                        <cc1:TabPanel ID="Summery" runat="server" HeaderText="Summary">
                                            <ContentTemplate>
                                                <asp:UpdatePanel ID="upinnonsummary" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>

                                                        <asp:ValidationSummary ID="ValidationSummary14" runat="server" ShowMessageBox="True"
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

                                                        <div class="mt-4 flex justify-between items-end gap-4 flex-wrap mb-2">
                                                            <div class="md:max-w-[250px] w-full">
                                                                <label class="text-gray-500 text-sm font-medium">Number of Invoices</label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Type" autocomplete="off" runat="server" Enabled="false" Text="0.00" type="text" ID="txtnoofinv" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                </div>
                                                            </div>


                                                            <div class="md:max-w-[250px] w-full">
                                                                <label class="text-gray-500 text-sm font-medium">Number of Items</label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Type" autocomplete="off" runat="server" Enabled="false" Text="0.00" type="text" ID="txtnoofitm" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                </div>
                                                            </div>


                                                            <div class="md:max-w-[250px] w-full">
                                                                <label class="text-gray-500 text-sm font-medium">Sum of Item Amount</label>
                                                                <div class="relative mt-1">

                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" Enabled="false" ForeColor="Red" Font-Names="verdana" Font-Size="Small" Font-Bold="true" type="text" ID="txtitmAmt" Text="0.00" TabIndex="290" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    <asp:Label ID="lblerror" ForeColor="Red" Font-Names="verdana" runat="server" Font-Size="small" Font-Bold="true"></asp:Label>
                                                                    <asp:Label ID="lblsameerror" ForeColor="Red" Font-Names="verdana" runat="server" Font-Size="small" Font-Bold="true"></asp:Label>

                                                                </div>
                                                            </div>


                                                            <div class="md:max-w-[250px] w-full">
                                                                <label class="text-gray-500 text-sm font-medium">Total Invoice CIF Value</label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="CIF Value" autocomplete="off" runat="server" Enabled="false" Text="0.00" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" type="text" ID="txtcifVal"></asp:TextBox>
                                                                </div>
                                                            </div>


                                                            <div class="md:max-w-[250px] w-full">
                                                                <label class="text-gray-500 text-sm font-medium">Total CIF/FOB Value</label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Total CIF/FOB Value" autocomplete="off" runat="server" Enabled="false" Text="0.00" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" ID="txtfobval"></asp:TextBox>
                                                                </div>
                                                            </div>

                                                            <div class="md:max-w-[250px] w-full">
                                                                <label class="text-gray-500 text-sm font-medium">Total GST Amount</label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Total GST Amount" autocomplete="off" runat="server" Enabled="false" Text="0.00" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" ID="txttotgstAmt"></asp:TextBox>
                                                                </div>
                                                            </div>


                                                            <div class="md:max-w-[250px] w-full">
                                                                <label class="text-gray-500 text-sm font-medium">Total Excise Duty Amount</label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Total Excise Duty" autocomplete="off" runat="server" Enabled="false" Text="0.00" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" type="text" ID="txttotexAmt"></asp:TextBox>
                                                                </div>
                                                            </div>


                                                            <div class="md:max-w-[250px] w-full">
                                                                <label class="text-gray-500 text-sm font-medium">Total Custom Duty Amount</label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Total Custom Duty" autocomplete="off" runat="server" Enabled="false" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" type="text" ID="txtcusdutyAmt"></asp:TextBox>
                                                                </div>
                                                            </div>


                                                            <div class="md:max-w-[250px] w-full">
                                                                <label class="text-gray-500 text-sm font-medium">Total Other Tax Amount</label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Total Other Tax" autocomplete="off" runat="server" Enabled="false" Text="0.00" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" type="text" ID="txtothtaxAmt"></asp:TextBox>
                                                                </div>
                                                            </div>


                                                            <div class="md:max-w-[250px] w-full">
                                                                <label class="text-gray-500 text-sm font-medium">Total Amount Payable</label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Total Payable Amount" autocomplete="off" runat="server" Text="0.00" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" ID="txtAmtPayble"></asp:TextBox>
                                                                </div>
                                                            </div>


                                                            <div class="md:max-w-[250px] w-full">
                                                                <label class="text-gray-500 text-sm font-medium">Sum of Invoice Amount</label>
                                                                <div class="relative mt-1">
                                                                    <div id="div3" class="invoice_div" style="color: red;" runat="server"></div>
                                                                    <asp:Label ID="lbltotinvAmt" Visible="false" runat="server" Text="0.00" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="md:max-w-[250px] w-full">
                                                                <label class="text-gray-500 text-sm font-medium">Sum of Item Amount</label>
                                                                <div class="relative mt-1">
                                                                    <div id="div6" style="color: red;" runat="server"></div>
                                                                    <asp:Label ID="Label1" Visible="false" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server" Text="0.00"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>


                                                        <h2 class="text-lg sa700 leading-[18px] text-gray-800 mt-6">Remarks</h2>

                                                        <div class="row">
                                                            <div class="col-sm-12">
                                                                <div class="form-group row">
                                                                    <label for="staticEmail" class="col-sm-6 col-form-label">
                                                                    </label>
                                                                    <div class="col-sm-6">
                                                                        <p id="cusremarks" runat="server" visible="false">Customer Remarks(will Not be Submitted to Singapore Customs)</p>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txtcusRemrk" Visible="false" TabIndex="194" runat="server" TextMode="MultiLine" Height="70" Width="100%"></asp:TextBox>
                                                                    </div>

                                                                </div>
                                                            </div>
                                                        </div>


                                                        <!-- Trader's Remarks Row with Buttons and Cross Reference -->
                                                        <div class="flex flex-wrap md:flex-nowrap items-start gap-4 mt-4 mb-2">

                                                            <!-- Trader's Remarks Label -->
                                                            <div class="flex items-center w-full md:w-1/3">
                                                                <p class="text-sm text-gray-700 font-medium">Trader's Remarks (will be Submitted to Singapore Customs)</p>
                                                            </div>

                                                            <!-- Append Invoice Number Button -->
                                                            <div class="w-full md:w-1/3">
                                                                <asp:Button ID="btninvnum" CssClass="mt-1 w-full h-10 bg-[#0560FD] bg-opacity-5 rounded-md text-[#0560FD] text-sm font-medium sa700 border-none px-4"
                                                                    TabIndex="195" runat="server" OnClick="btninvnum_Click" Text="Append Invoice No" />
                                                            </div>

                                                            <div class="w-full md:w-1/3">
                                                                <asp:Button ID="BtnPPN" OnClick="BtnPPN_Click" CssClass="relative mt-1 w-full h-10 bg-[#0560FD] bg-opacity-5 rounded-md flex items-center text-[#0560FD] text-sm font-medium outline-none border-none sa700 px-4" TabIndex="195" runat="server" Text="Append Previous Permit NO" />
                                                            </div>

                                                            <!-- Append Exchange Rate Button -->
                                                            <div class="w-full md:w-1/3">
                                                                <asp:Button ID="Button5" CssClass="mt-1 w-full h-10 bg-[#0560FD] bg-opacity-5 rounded-md text-[#0560FD] text-sm font-medium sa700 border-none px-4"
                                                                    TabIndex="196" OnClick="Button3_Click" runat="server" Text="Append Exchange Rate" />
                                                            </div>



                                                            <!-- Cross Reference -->
                                                            <div class="w-full md:w-1/3" style="margin-top: -13px">
                                                                <label class="text-gray-500 text-sm font-medium">Cross Reference</label>
                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="TxtGrossReference"
                                                                    CssClass="mt-1 w-full h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium border-none px-4"></asp:TextBox>


                                                            </div>
                                                        </div>



                                                        <div class="row">
                                                            <div class="col-sm-12">

                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txttrdremrk" ValidationGroup="Summery" runat="server" TextMode="MultiLine" MaxLength="1024" AutoPostBack="true" OnTextChanged="txttrdremrk_TextChanged" TabIndex="197" Height="70" Width="100%" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txttrdremrk"
                                                                    ID="RegularExpressionValidator4" ValidationExpression="^[\s\S]{0,1024}$"
                                                                    runat="server" ErrorMessage="Maximum 1024 characters allowed." ValidationGroup="Summery" />

                                                                <asp:Label ID="lbltracunt" ForeColor="Navy" runat="server"></asp:Label>

                                                                <br />
                                                                <label class="text-gray-500 text-sm font-medium">Internal Remarks </label>

                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txtintremrk" runat="server" Height="70" Width="100%" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                            </div>
                                                        </div>

                                                        <h2 class="text-lg sa700 leading-[18px] text-gray-800 mt-4">Declaration Summary</h2>

                                                        <div class="mt-5 grid grid-cols-1 md:grid-cols-2 gap-x-8 gap-y-5 mb-2">
                                                            <div>
                                                                <label class="text-gray-500 text-sm font-medium">IMPORTER NAME AND UEN</label>
                                                                <div>
                                                                    <asp:Label ID="lblimporterparty" runat="server" CssClass="text-slate-950 text-base sa700 mt-2"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div>
                                                                <label class="text-gray-500 text-sm font-medium">TOTAL OUTER PACK/UNIT</label>
                                                                <div class="text-slate-950 text-base sa700 mt-2">3</div>
                                                            </div>

                                                            <div>
                                                                <label class="text-gray-500 text-sm font-medium">EXPORTER NAME AND UEN</label>
                                                                <div>
                                                                    <asp:Label ID="lblexporterparty" runat="server" CssClass="text-slate-950 text-base sa700 mt-2"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div>
                                                                <label class="text-gray-500 text-sm font-medium">TOTAL PERMIT GROSS WEIGHT/UNIT</label>
                                                                <div>
                                                                    <asp:Label ID="lblgrossweight" runat="server" Text="" CssClass="text-slate-950 text-base sa700 mt-2"></asp:Label>
                                                                </div>
                                                            </div>



                                                            <div>
                                                                <label class="text-gray-500 text-sm font-medium">INWARD HAWB/HBL </label>
                                                                <div>
                                                                    <asp:Label ID="lblhblValue" runat="server" CssClass="text-slate-950 text-base sa700 mt-2"></asp:Label>

                                                                </div>
                                                            </div>

                                                            <div>
                                                                <label class="text-gray-500 text-sm font-medium">EXCHANGE RATE (CUR) </label>
                                                                <div>
                                                                    <asp:Label ID="Label9" runat="server" CssClass="text-slate-950 text-base sa700 mt-2"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div>
                                                                <label class="text-gray-500 text-sm font-medium">INWARD MAWB/MBL/OBL </label>
                                                                <div>
                                                                    <asp:Label ID="lbloblval" runat="server" Text="" CssClass="text-slate-950 text-base sa700 mt-2"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div>
                                                                <label class="text-gray-500 text-sm font-medium">TOTAL INVOICE AMOUNT (CUR)</label>
                                                                <div>
                                                                    <asp:Label ID="lblinvoiceAmt" runat="server" CssClass="text-slate-950 text-base sa700 mt-2"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div>
                                                                <label class="text-gray-500 text-sm font-medium">INWARD TRANSPORT MODE</label>
                                                                <div>
                                                                    <asp:Label ID="lblinwardtm" runat="server" Text="" CssClass="text-slate-950 text-base sa700 mt-2"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div>
                                                                <label class="text-gray-500 text-sm font-medium">TOTAL ITEM AMOUNT (CUR)</label>
                                                                <div>
                                                                    <asp:Label ID="lblTotItemGst" runat="server" class="text-slate-950 text-base sa700 mt-2"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div>
                                                                <label class="text-gray-500 text-sm font-medium">Outward HBL/HAWB</label>
                                                                <div>
                                                                    <asp:Label ID="Lblouthblhawb" runat="server" Text="" CssClass="text-slate-950 text-base sa700 mt-2"></asp:Label>


                                                                </div>
                                                            </div>


                                                            <div>
                                                                <label class="text-gray-500 text-sm font-medium">TOTAL INVOICE GST (SGD)</label>
                                                                <div>
                                                                </div>
                                                            </div>


                                                            <div>
                                                                <label class="text-gray-500 text-sm font-medium">OUTWARD MAWB/MBL/OBL</label>
                                                                <div>
                                                                    <asp:Label ID="LblOutoblmawb" runat="server" Text="" CssClass="text-slate-950 text-base sa700 mt-2"></asp:Label>
                                                                    <asp:Label ID="lbloutobls" runat="server" CssClass="text-slate-950 text-base sa700 mt-2"></asp:Label>

                                                                </div>
                                                            </div>


                                                            <div>
                                                                <label class="text-gray-500 text-sm font-medium">TOTAL ITEM GST (SGD)</label>
                                                                <div>
                                                                    <asp:Label ID="lblnoofpack" Visible="false" runat="server" CssClass="text-slate-950 text-base sa700 mt-2"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div>
                                                                <label class="text-gray-500 text-sm font-medium">OUTWARD TRANSPORT MODE</label>
                                                                <div>
                                                                    <asp:Label ID="lbloutwardtm" runat="server" Text="" CssClass="text-slate-950 text-base sa700 mt-2"></asp:Label>

                                                                </div>
                                                            </div>











                                                        </div>


                                                        <div class="w-full mt-6" id="DeclInd" runat="server" visible="false" style="background-color: #F2D2D2; padding: 19px;">
                                                            <div class="flex gap-2 items-center">
                                                                <asp:CheckBox ID="chkalrt" runat="server" TabIndex="198" Checked="false" />
                                                                <label for="styled-checkbox-90" class="text-gray-500 text-sm">
                                                                    I/We declare that all the particulars in this Application are
                          true &amp; correct</label>
                                                            </div>
                                                        </div>


                                                        <div class="row">
                                                            <div class="col-sm-12">

                                                                <center>

                                                                    <div class="flex justify-between gap-4 md:flex-nowrap flex-wrap mt-6" id="DeclBtn" runat="server" visible="false">

                                                                        <asp:Button ID="btnprevsum" runat="server" class="btn btn-info btn-lg" OnClick="btnprevsum_Click" Text="Previous" TabIndex="304" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" />
                                                                        <asp:Button ID="btnsavesum" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" runat="server" class="btn btn-info btn-lg" OnClick="btnsavesum_Click" Text="Save" TabIndex="305" />
                                                                        <asp:Button ID="btnresetsum" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" runat="server" class="btn btn-info btn-lg" OnClick="btnresetsum_Click" Text="Reset" TabIndex="306" Visible="false" />
                                                                        <asp:Button ID="btnnextsum" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" runat="server" class="btn btn-info btn-lg" OnClick="btnnextsum_Click" Text="Next" TabIndex="307" />

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

                                                                    <asp:Button ID="BtnContinue" runat="server" Text="Continue" OnClick="BtnYes_Click" />
                                                                    <asp:Button ID="BtnCancel" runat="server" Text="Cancel" OnClick="BtnNo_Click" />

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


                                        <cc1:TabPanel ID="Amend" runat="server" Visible="false" HeaderText="Amend">
                                            <ContentTemplate>
                                                <asp:UpdatePanel ID="upinnonamend" runat="server" UpdateMode="Conditional">
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
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" Width="300" type="text" Text="1" Enabled="false" ID="txtamoundcount" TabIndex="308"></asp:TextBox>
                                                                        <br />
                                                                        <p>Update Indicator</p>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" Text="AME" Enabled="false" runat="server" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" Width="300" type="text" ID="txtupdateindicator" TabIndex="309"></asp:TextBox>
                                                                        <br />
                                                                    </div>
                                                                    <div class="col-sm-6">
                                                                        <p>Permit Number</p>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" Width="300" type="text" ID="txtamendpermit" TabIndex="310"></asp:TextBox>
                                                                        <br />
                                                                        <p>Replacement Permit Number</p>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" Width="300" type="text" ID="txtreplacepermit" TabIndex="311"></asp:TextBox>
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
                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" TextMode="MultiLine" Width="100%" type="text" ID="txtdescreason" TabIndex="312"></asp:TextBox>
                                                                <br />
                                                                <asp:CheckBox ID="ChkPermitvalEx" runat="server" Text="Permit Validity Extension" />
                                                                <br />
                                                                <p>Extend Import Period (Reason for Extension of validity for Temporary / Exhibit Cargoes)</p>
                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" TextMode="MultiLine" Width="100%" type="text" ID="txtvalidity" TabIndex="313"></asp:TextBox>
                                                                <br />
                                                                <br />
                                                                <br />
                                                                <div class="row " style="width: 100%">
                                                                    <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-6">
                                                                        <span class="text-white text-sm font-semibold tracking-wide">Declaration Indicator</span>
                                                                    </div>

                                                                </div>

                                                                <div class="alert alert-danger" id="AmendInd" runat="server" visible="false">
                                                                    <asp:CheckBox ID="chkdec" runat="server" Checked="false" TabIndex="314" />
                                                                    <strong></strong>I/We declare that all particulars in this application are true and correct
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <center>
                                                            <div class="btn-group btn-group-lg" id="Amendbtn" runat="server" visible="false">
                                                                <asp:Button ID="btnprevamend" runat="server" Style="display: none;" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" OnClick="btnprevamend_Click" Text="Previous" TabIndex="315" />
                                                                <asp:Button ID="btnsaveamend" runat="server" OnClick="btnsaveamend_Click" Text="Save" TabIndex="316" CssClass="btn duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                <asp:Button ID="btnresetamend" Style="display: none;" runat="server" class="btn btn-info btn-lg" OnClick="btnresetamend_Click" Text="Reset" TabIndex="317" />
                                                                <asp:Button ID="btnnextamend" CssClass="nn" Style="display: none;" runat="server" class="btn btn-info btn-lg" OnClick="btnnextamend_Click" Text="Next" TabIndex="318" />

                                                            </div>

                                                        </center>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <%--  <a href="#Summary" data-toggle="tab" title="Previous">PREVIOUS</a>
    <a href="#Cancel" data-toggle="tab" title="Next">NEXT</a>--%>
                                            </ContentTemplate>
                                        </cc1:TabPanel>

                                        <cc1:TabPanel ID="Cancel" runat="server" Visible="false" HeaderText="cancel">
                                            <ContentTemplate>
                                                <asp:UpdatePanel ID="upinnoncancel" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>


                                                        <div class="row">
                                                            <div class="col-sm-12">

                                                                  <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-7">
      <span class="text-white text-sm font-semibold tracking-wide">Update Information</span>

  </div>


                                                             
                                                                <div class="row">
                                                                    <div class="col-sm-4">
                                                                        <p>Update Indicator</p>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" Text="CNL" Enabled="false" Width="300" type="text" ID="txtupdateInd" TabIndex="319"></asp:TextBox>
                                                                        <br />


                                                                    </div>
                                                                    <div class="col-sm-4">
                                                                        <p>Permit Number</p>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" Width="300" type="text" ID="txtcanPermit" TabIndex="320"></asp:TextBox>
                                                                        <br />
                                                                       
                                                                    </div>
                                                                     <div class="col-sm-4">
                                                                          <p>Replacement Permit Number</p>
 <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" Width="300" type="text" ID="txtcanrepPermit" TabIndex="321"></asp:TextBox>
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
                                                                <asp:DropDownList  CssClass="focus:outline-none bg-slate-100 font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 px-4" ID="DrpReasonCancel" Width="300" TabIndex="322"  runat="server"></asp:DropDownList>
                                                            </div>
                                                            <div class="col-sm-6">
                                                                <p>Description For Reason</p>
                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" TextMode="MultiLine" Width="100%" type="text" ID="txtdesReason" TabIndex="323"></asp:TextBox>
                                                                <br />
                                                            </div>
                                                        </div>
                                                        <br />
                                                        <div class="row">
                                                            <div class="col-sm-12" id="Div7" runat="server">

                                                                <div class="row">


                                                                    <div class="col-sm-12">

                                                                          <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-7">
      <span class="text-white text-sm font-semibold tracking-wide"> Referance Document</span>

  </div>
                                                                       

                                                                        <div class="row">
                                                                            <div class="col-sm-5">
                                                                                <p>Document Type</p>
                                                                                <asp:DropDownList  CssClass="focus:outline-none bg-slate-100 font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 px-4" ID="DrpDocumenttype"  Width="250"  AppendDataBoundItems="true" TabIndex="324" runat="server">
                                                                                </asp:DropDownList><br />
                                                                                <asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator92" runat="server" ControlToValidate="DrpDocumenttype" InitialValue="0" ErrorMessage="Header --> Doc Type" ValidationGroup="Validationbtn"></asp:RequiredFieldValidator>
                                                                            </div>
                                                                            <div class="col-sm-5">
                                                                                <p>Uplaod Document</p>
                                                                                <asp:FileUpload ID="FileUpload2"  runat="server" TabIndex="325" class="btn" AllowMultiple="true" />
                                                                                <asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator95" runat="server" ControlToValidate="FileUpload2" ErrorMessage="Header -->Upload Doc" ValidationGroup="Validationbtn"></asp:RequiredFieldValidator>
                                                                            </div>
                                                                            <div class="col-sm-2">
                                                                                <p>Uplaod</p>
                                                                                <asp:Button runat="server" ID="BtnCancelUp" ValidationGroup="Validationbtn" TabIndex="326" class="btn btn-success" Text="Upload" OnClick="BtnCancelUp_Click" />

                                                                            </div>
                                                                        </div>


                                                                        <hr />
                                                                        <asp:GridView ID="GridCancelDoc" PageSize="5" OnRowDeleting="GridCancelDoc_RowDeleting" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="GridCancelDoc_PageIndexChanging" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" AutoGenerateColumns="false">
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
                                                                  <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-7">
      <span class="text-white text-sm font-semibold tracking-wide"> ADDITIONAL RECIPIENTS</span>

  </div>
                                                              
                                                                <br />
                                                                <div class="row">
                                                                    <div class="col-sm-4">
                                                                        <p>RECIPIENTS 1</p>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" ID="TextBox15" Width="265" runat="server" TabIndex="327" type="text"></asp:TextBox>

                                                                        <br />
                                                                    </div>
                                                                    <div class="col-sm-4">
                                                                        <p>RECIPIENTS 2</p>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" ID="TextBox16" Width="265" runat="server" TabIndex="328" type="text"></asp:TextBox>

                                                                        <br />
                                                                    </div>
                                                                    <div class="col-sm-4">
                                                                        <p>RECIPIENTS 3</p>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" ID="TextBox17" Width="265" runat="server" TabIndex="329" type="text"></asp:TextBox>

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
                                                                    <asp:CheckBox ID="CheckBox4" runat="server" Checked="false" TabIndex="330" />
                                                                    <strong></strong>I/We declare that all particulars in this application are true and correct
                                                                </div>

                                                            </div>
                                                        </div>
                                                        <center>
                                                            <div class="btn-group btn-group-lg" id="CancelBtn" runat="server" visible="false">
                                                                <asp:Button ID="btnprevcancel"   CssClass="btn duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700"  runat="server" class="btn btn-info btn-lg" OnClick="btnprevcancel_Click" Text="Previous" Visible="false" TabIndex="331" />
                                                                <asp:Button ID="btnsavecancel"   CssClass="btn duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700"  runat="server" class="btn btn-info btn-lg" OnClick="btnsavecancel_Click" Text="Save" TabIndex="332" />
                                                                <asp:Button ID="btnresetcancel"   CssClass="btn duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700"  runat="server" class="btn btn-info btn-lg" OnClick="btnresetcancel_Click" Text="Reset" Visible="false" TabIndex="333" />
                                                                <asp:Button ID="btnnextcancel"   CssClass="btn duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700"  runat="server" class="btn btn-info btn-lg" OnClick="btnnextcancel_Click" Text="Next" Visible="false" TabIndex="334" />

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

                                    </cc1:TabContainer>
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

                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
