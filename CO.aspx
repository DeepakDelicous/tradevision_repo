<%@ Page Title="" ClientIDMode="AutoID" Language="C#" MasterPageFile="~/Home.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="CO.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="RET.CO" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <link href="css/style.css" rel="stylesheet" />
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
        function openTab(tabId) {
            var tabContainer = $find("<%= TabContainer1.ClientID %>");
            tabContainer.set_activeTabIndex(tabId - 1);
        }
        function countChars(obj) {
            document.getElementById("certificate").innerHTML = obj.value.length + ' characters';
        }
        function countcert(obj) {
            document.getElementById("certificatedesc").innerHTML = obj.value.length + ' characters';
        }

        // No alphabets for Emp No textbox
        function noAlphabets(event) {
            var charCode = (event.which) ? event.which : event.keyCode
            if ((charCode >= 97) && (charCode <= 122) || (charCode >= 65) && (charCode <= 90))
                return false;

            return true;
        }

        function myFunction() {




            $("#CO").css('color', 'White');
            debugger;
            $("#CO").css('background-color', 'Black');



            /*$("#useru").css('margin-top', '3px');*/
            $(function () {
                $('a[title]').tooltip();
            });


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

    <asp:UpdateProgress ID="UpdateProgress" class="theme_loader" runat="server" AssociatedUpdatePanelID="co">
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



    <asp:UpdatePanel ID="co" UpdateMode="Conditional" runat="server">
        <ContentTemplate>

            <div>
                <div class="top-pad text-center hidden">
                    <div>
                        <marquee>
                            <asp:Label ID="Lblmarquee" runat="server" Font-Bold="True" Font-Names="Arial Black" ForeColor="red"></asp:Label>
                        </marquee>
                        <div class="btn-group">
                            <asp:ValidationSummary ID="ValidationSummary4" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="Validation" />
                            <asp:Button ValidationGroup="Validation" ID="Button2" class="btn1 btn-primary " Visible="false" runat="server" OnClientClick="$('li:eq(2)', $('.nav-tabs')).tab('show')" OnClick="BtnSaveDraft_Click" Text="Save As Draft" />
                            <button type="button" class="btn1  " runat="server" visible="false">Save As Final</button>
                            <button type="button" class="btn1 " runat="server" visible="false">Save and Submit</button>
                        </div>
                        <div class="btn-group">
                            <button type="button" class="btn1 btn-primary" runat="server" visible="false">Load Data</button>
                            <button type="button" class="btn1 btn-primary" runat="server" visible="false">Print Status</button>
                            <button type="button" class="btn1 btn-primary" runat="server" visible="false">Print Draft CCP</button>
                            <button type="button" class="btn1 btn-primary" runat="server" visible="false">Print CIF</button>

                        </div>
                        <%--<div class="btn-group pull-right">
                    <asp:Button ID="BtnExit" runat="server" class="btn1 btn-danger" OnClick="BtnExit_Click" Text="Exit Form" />
                </div>--%>
                    </div>
                </div>

                <asp:UpdatePanel ID="updatepanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="flex md:justify-between items-center gap-4 mb-4 mt-6 md:flex-nowrap flex-wrap">
                            <div class="flex gap-2 items-center">
                                <p class="text-gray-500 text-sm font-medium">Certificate of Origin</p>
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
                                <div class="flex flex-col justify-center items-center relative" id="divItem" runat="server" onclick="openTab(4)" style="cursor: pointer;">
                                    <div class="text-center text-gray-500 md:text-base text-[10px] mb-2">
                                        Item

                                    </div>
                                    <div class="w-[14px] h-[14px] bg-transparent border-2 border-[#BCBCC3] rounded-full relative">
                                        <div class="after:absolute lg:after:w-[110px] md:after:w-[45px] after:w-[12px] after:h-[2px] after:bg-[#F4F6FA] after:top-0 after:bottom-0 after:my-auto after:left-3"></div>
                                    </div>
                                </div>
                                <div class="flex flex-col justify-center items-center relative" id="divSummary" runat="server" onclick="openTab(5)" style="cursor: pointer;">
                                    <div class="text-center text-gray-500 md:text-base text-[10px] mb-2">
                                        Summary

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

                                                <asp:UpdatePanel ID="coheader" UpdateMode="Conditional" runat="server">
                                                    <ContentTemplate>




                                                        <div class="grid grid-cols-1 md:grid-cols-2 gap-6 mt-4 mb-2">

                                                            <!-- Left Column -->


                                                            <div class="space-y-4">
                                                                <!-- MESSAGE TYPE -->
                                                                <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-6">
                                                                    <span class="text-white text-sm font-semibold tracking-wide">Declaration Type</span>
                                                                </div>
                                                                <div class="flex items-center gap-4 w-full">
                                                                    <div class="w-[150px] flex-shrink-0">
                                                                        <label class="text-gray-500 text-sm font-medium">Message Type</label>
                                                                    </div>
                                                                    <div class="flex-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" placeholder="Message Type" ID="TxtMsgType" Text="COODEC" Enabled="false" runat="server" type="text" TabIndex="1" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    </div>
                                                                </div>

                                                                <!-- APPLICATION TYPE -->
                                                                <div class="flex items-center gap-4 w-full">
                                                                    <div class="w-[150px] flex-shrink-0">
                                                                        <label class="text-gray-500 text-sm font-medium">Application Type</label>
                                                                    </div>
                                                                    <div class="flex-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" placeholder="Message Type" ID="TxtAppType" Text="COO" Enabled="false" runat="server" type="text" TabIndex="1" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    </div>
                                                                </div>

                                                                <!-- PREVIOUS PERMIT NO -->
                                                                <div class="flex items-center gap-4 w-full">
                                                                    <div class="w-[150px] flex-shrink-0">
                                                                        <label class="text-gray-500 text-sm font-medium">Previous Permit No</label>
                                                                    </div>
                                                                    <div class="flex-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" placeholder="Previous Permit No
" ID="TxtPrevPerNO" Enabled="true" runat="server" type="text" TabIndex="1" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    </div>
                                                                </div>

                                                                <!-- OUTWARD TRANS MODE -->
                                                                <div class="flex items-center gap-4 w-full">
                                                                    <div class="w-[150px] flex-shrink-0">
                                                                        <label class="text-gray-500 text-sm font-medium">Outward Transport Mode</label>
                                                                    </div>
                                                                    <div class="flex-1">
                                                                        <div id="cargozz" runat="server">
                                                                            <asp:DropDownList ID="DrpOutwardtrasMode" OnSelectedIndexChanged="DrpOutwardtrasMode_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true" TabIndex="2" runat="server" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator BackColor="Red" InitialValue="0" ID="RequiredFieldValidator8" runat="server" ControlToValidate="DrpOutwardtrasMode" Display="None" ErrorMessage="Header --> Outward Transport Mode is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <!-- CHECKBOXES -->
                                                                <div class="flex items-center gap-2">
                                                                    <asp:CheckBox ID="ChkOverrExgRate" AutoPostBack="true" runat="server" TabIndex="7" />
                                                                    <label for="" class="text-gray-500 text-sm font-medium">Override Ex: Rate</label>
                                                                </div>
                                                                <div class="flex items-center gap-2" style="display:none;">
                                                                    <asp:CheckBox ID="ChkSupplyIndicator" AutoPostBack="true" runat="server" TabIndex="7" />
                                                                    <label for="" class="text-gray-500 text-sm font-medium">Supply indicator</label>
                                                                </div>

                                                                <div class="flex items-center gap-2">

                                                                    <asp:CheckBox ID="ChkRefDoc" OnCheckedChanged="ChkRefDoc_CheckedChanged" AppendDataBoundItems="true" AutoPostBack="true" runat="server" TabIndex="8" />

                                                                    <label for="" class="text-gray-500 text-sm font-medium">Supporting documents</label>
                                                                </div>




                                                            </div>


                                                            <div class="space-y-4">
                                                                <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-6">
                                                                    <span class="text-white text-sm font-semibold tracking-wide">Job Information </span>
                                                                </div>
                                                                <!-- Mailbox ID -->
                                                                <div class="flex items-center gap-4 w-full">
                                                                    <div class="w-[150px] flex-shrink-0">
                                                                        <label class="text-gray-500 text-sm font-medium">Mailbox ID</label>
                                                                    </div>
                                                                    <div class="flex-1">
                                                                        <asp:TextBox Enabled="false" onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" Text="" type="text" ID="TxtTradeMailID" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TxtTradeMailID" Display="None" ErrorMessage="Header --> TradeNet Mailbox ID is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>

                                                                <!-- Declarant Name -->
                                                                <div class="flex items-center gap-4 w-full">
                                                                    <div class="w-[150px] flex-shrink-0">
                                                                        <label class="text-gray-500 text-sm font-medium">Declarant Name</label>
                                                                    </div>
                                                                    <div class="flex-1">
                                                                        <asp:TextBox Enabled="false"  onkeyup="toUpperCaseText(this)" placeholder="Type Number" autocomplete="off" ID="TxtDecName" MaxLength="35" class="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server" type="text" TabIndex="3"></asp:TextBox>
                                                                    </div>
                                                                </div>

                                                                <!-- Declarant Code -->
                                                                <div class="flex items-center gap-4 w-full">
                                                                    <div class="w-[150px] flex-shrink-0">
                                                                        <label class="text-gray-500 text-sm font-medium">Declarant Code</label>
                                                                    </div>
                                                                    <div class="flex-1">
                                                                        <asp:TextBox Enabled="false"  onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" Text="" type="text" ID="TxtDecCode" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtDecCode" Display="None" ErrorMessage="Header --> Declarant  Code is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>

                                                                <!-- Declarant Tel -->
                                                                <div class="flex items-center gap-4 w-full">
                                                                    <div class="w-[150px] flex-shrink-0">
                                                                        <label class="text-gray-500 text-sm font-medium">Declarant Tel</label>
                                                                    </div>
                                                                    <div class="flex-1">
                                                                        <asp:TextBox Enabled="false"  onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" Text="" type="text" ID="TxtDecTelephone" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtDecTelephone" Display="None" ErrorMessage="Header --> Declarant  Telephone is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>

                                                                <!-- CR UEI No -->
                                                                <div class="flex items-center gap-4 w-full">
                                                                    <div class="w-[150px] flex-shrink-0">
                                                                        <label class="text-gray-500 text-sm font-medium">CR UEI No</label>
                                                                    </div>
                                                                    <div class="flex-1">
                                                                        <asp:TextBox Enabled="false"  onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" Text="" type="text" ID="TxtCRUEINO" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtCRUEINO" Display="None" ErrorMessage="Header --> CR UEI No is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
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
                                                                <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-5">
                                                                    <span class="text-white text-sm font-semibold tracking-wide">Attachment Document</span>
                                                                </div>

                                                                <div class="mt-1 justify-between items-start gap-4 lg:flex-nowrap flex-wrap mb-2">

                                                                    <!-- Heading in its own row -->



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
                                                                                    <asp:TextBox autocomplete="off" ID="txtdocserach" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server" Style="width: 400px;"></asp:TextBox>
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
                                                        <div class="w-full  text-center rounded-full py-2 mt-6">
                                                            <span class="text-white text-sm font-semibold tracking-wide text-black">Certificate of Origin</span>
                                                        </div>



                                                        <div class="w-[68%] mt-3">
                                                            <div class="flex items-center justify-center gap-4">
                                                                <label class="text-gray-500 text-sm font-medium w-1/2">
                                                                    CO Type
                                                                </label>
                                                                <asp:DropDownList
                                                                    ID="DrpCoType"
                                                                    OnSelectedIndexChanged="DrpCoType_SelectedIndexChanged"
                                                                    AutoPostBack="true"
                                                                    AppendDataBoundItems="true"
                                                                    TabIndex="2"
                                                                    runat="server"
                                                                    CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4 w-1/2">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>


                                                        <div class="grid grid-cols-1 md:grid-cols-3 gap-6 mt-4 mb-2">

                                                            <!-- Left Column -->
                                                            <div class="space-y-4">

                                                                <div class="flex flex-wrap gap-6 w-full">

                                                                    <!-- Certificate Detail #1 - Type -->
                                                                    <div class="w-full md:max-w-[300px]">
                                                                        <label class="text-gray-500 text-sm font-medium block mb-1">
                                                                            Certificate Detail #1 - Type
                                                                        </label>
                                                                        <asp:DropDownList ID="DrpCerDtl1" OnSelectedIndexChanged="DrpCerDtl1_SelectedIndexChanged"
                                                                            AutoPostBack="true" AppendDataBoundItems="true" TabIndex="2" runat="server"
                                                                            CssClass="w-full h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                        </asp:DropDownList>
                                                                    </div>

                                                                    <!-- Certificate Detail #1 - Copies -->
                                                                    <div class="w-full md:max-w-[300px]">
                                                                        <label class="text-gray-500 text-sm font-medium block mb-1">
                                                                            Certificate Detail #1 - Copies
                                                                        </label>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtCerDtl1" runat="server" TabIndex="20" type="text"
                                                                            CssClass="w-full h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                        </asp:TextBox>
                                                                    </div>

                                                                    <!-- Certificate Detail #2 - Type -->
                                                                    <div class="w-full md:max-w-[300px]">
                                                                        <label class="text-gray-500 text-sm font-medium block mb-1">
                                                                            Certificate Detail #2 - Type
                                                                        </label>
                                                                        <asp:DropDownList ID="DrpCerDtl2" AutoPostBack="true" AppendDataBoundItems="true" TabIndex="2" runat="server"
                                                                            CssClass="w-full h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                        </asp:DropDownList>
                                                                    </div>

                                                                    <!-- Certificate Detail #2 - Copies -->
                                                                    <div class="w-full md:max-w-[300px]">
                                                                        <label class="text-gray-500 text-sm font-medium block mb-1">
                                                                            Certificate Detail #2 - Copies
                                                                        </label>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtCerDtl2" runat="server" TabIndex="20" type="text"
                                                                            CssClass="w-full h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                        </asp:TextBox>
                                                                    </div>

                                                                    <div class="md:max-w-[250px] w-full" id="common" runat="server" visible="false">
                                                                        <label class="text-gray-500 text-sm font-medium">Percentage of Commonwealth Preference Content</label>
                                                                        <div class="group relative mt-5">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txtper" Text="0.00" runat="server" TabIndex="23" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        </div>
                                                                    </div>

                                                                    <!-- Currency Code -->
                                                                    <div class="w-full md:max-w-[300px]">
                                                                        <label class="text-gray-500 text-sm font-medium block mb-1">
                                                                            Currency Code
                                                                        </label>
                                                                        <asp:DropDownList ID="DrpCurrencyCode" AutoPostBack="true" AppendDataBoundItems="true" TabIndex="2" runat="server"
                                                                            CssClass="w-full h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                        </asp:DropDownList>
                                                                    </div>

                                                                </div>


                                                            </div>

                                                            <div class="space-y-4">
                                                                <div class="flex flex-wrap gap-6 w-full">

                                                                    <!-- Additional Certificate Detail 1 -->
                                                                    <div class="w-full md:max-w-[250px]">
                                                                        <label class="text-gray-500 text-sm font-medium block mb-1">Additional Certificate Details</label>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="AddCerDtl1" runat="server" TabIndex="20" type="text"
                                                                            class="w-full h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                        </asp:TextBox>
                                                                    </div>

                                                                    <!-- Additional Certificate Detail 2 -->
                                                                    <div class="w-full md:max-w-[250px]">
                                                                        <label class="text-gray-500 text-sm font-medium block mb-1"></label>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="AddCerDtl2" runat="server" TabIndex="20" type="text"
                                                                            class="w-full h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                        </asp:TextBox>
                                                                    </div>

                                                                    <!-- Additional Certificate Detail 3 -->
                                                                    <div class="w-full md:max-w-[250px]">
                                                                        <label class="text-gray-500 text-sm font-medium block mb-1"></label>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="AddCerDtl3" runat="server" TabIndex="20" type="text"
                                                                            class="w-full h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                        </asp:TextBox>
                                                                    </div>

                                                                    <!-- Additional Certificate Detail 4 -->
                                                                    <div class="w-full md:max-w-[250px]">
                                                                        <label class="text-gray-500 text-sm font-medium block mb-1"></label>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="AddCerDtl4" runat="server" TabIndex="20" type="text"
                                                                            class="w-full h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                        </asp:TextBox>
                                                                    </div>

                                                                    <!-- Additional Certificate Detail 5 -->
                                                                    <div class="w-full md:max-w-[250px]">
                                                                        <label class="text-gray-500 text-sm font-medium block mb-1"></label>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="AddCerDtl5" runat="server" TabIndex="20" type="text"
                                                                            class="w-full h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                        </asp:TextBox>
                                                                    </div>

                                                                </div>


                                                            </div>

                                                            <div class="space-y-4">
                                                                <div class="flex flex-wrap gap-6 w-full">

                                                                    <!-- Transport Detail 1 -->
                                                                    <div class="w-full md:max-w-[250px]">
                                                                        <label class="text-gray-500 text-sm font-medium block mb-1">Transport Details</label>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TransDtl1" runat="server" TabIndex="20" type="text"
                                                                            class="w-full h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                        </asp:TextBox>
                                                                    </div>

                                                                    <!-- Transport Detail 2 -->
                                                                    <div class="w-full md:max-w-[250px]">
                                                                        <label class="text-gray-500 text-sm font-medium block mb-1"></label>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TransDtl2" runat="server" TabIndex="20" type="text"
                                                                            class="w-full h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                        </asp:TextBox>
                                                                    </div>

                                                                    <!-- Transport Detail 3 -->
                                                                    <div class="w-full md:max-w-[250px]">
                                                                        <label class="text-gray-500 text-sm font-medium block mb-1"></label>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TransDtl3" runat="server" TabIndex="20" type="text"
                                                                            class="w-full h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                        </asp:TextBox>
                                                                    </div>

                                                                    <!-- Transport Detail 4 -->
                                                                    <div class="w-full md:max-w-[250px]">
                                                                        <label class="text-gray-500 text-sm font-medium block mb-1"></label>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TransDtl4" runat="server" TabIndex="20" type="text"
                                                                            class="w-full h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                        </asp:TextBox>
                                                                    </div>

                                                                    <!-- Transport Detail 5 -->
                                                                    <div class="w-full md:max-w-[250px]">
                                                                        <label class="text-gray-500 text-sm font-medium block mb-1"></label>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TransDtl5" runat="server" TabIndex="20" type="text"
                                                                            class="w-full h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                        </asp:TextBox>
                                                                    </div>

                                                                </div>

                                                            </div>
                                                        </div>



                                                        <!-- GridView at bottom -->

                                                      


                                                        <div class="mt-2 flex justify-between items-start gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                            <div class="md:max-w-[250px] w-full">
                                                                <label class="text-gray-500 text-sm font-medium">BG Indicator</label>
                                                                <div class="relative mt-1">
                                                                    <div class="relative mt-1">
                                                                        <asp:DropDownList ID="DrpBGIndicator" OnSelectedIndexChanged="DrpOutwardtrasMode_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true" TabIndex="2" runat="server" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>




                                                        </div>



                                                        <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                                                            ShowSummary="False" ValidationGroup="cotype" />



                                                        <div class="mt-2 flex justify-between items-start gap-4 lg:flex-nowrap flex-wrap mb-2">

                                                            <div class="md:max-w-[250px] w-full" id="entryyrs" runat="server" visible="false">
                                                                <div class="group relative mt-1">
                                                                    <label class="text-gray-500 text-sm font-medium">
                                                                        Entry Year
                 
                                                                    </label>
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" placeholder="Message Type" ID="txtentry"  Enabled="false" runat="server" type="text" TabIndex="1" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div id="gps" runat="server" visible="false" class="md:max-w-[250px] w-full">
                                                                <label class="text-gray-500 text-sm font-medium">
                                                                    GSP Donor Country
               
                                                                </label>
                                                                <div class="relative mt-1">


                                                                    <asp:DropDownList ID="Drpgpsdonorcountry" AutoPostBack="true" AppendDataBoundItems="true" TabIndex="2" runat="server" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>

                                                        </div>





                                                        <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-6">
                                                            <span class="text-white text-sm font-semibold tracking-wide">ADDITIONAL RECIPIENTS</span>
                                                        </div>




                                                        <div class="mt-2 flex justify-between items-start gap-4 lg:flex-nowrap flex-wrap mb-2">

                                                            <div class="md:max-w-[250px] w-full">
                                                                <label class="text-gray-500 text-sm font-medium">RECIPIENTS 1</label>
                                                                <div class="relative mt-1">
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtRECPT1" runat="server" TabIndex="20" type="text" class="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="md:max-w-[250px] w-full">
                                                                <label class="text-gray-500 text-sm font-medium">RECIPIENTS 2</label>
                                                                <div class="relative mt-1">
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtRECPT2" runat="server" TabIndex="20" type="text" class="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>


                                                            <div class="md:max-w-[250px] w-full">
                                                                <label class="text-gray-500 text-sm font-medium">RECIPIENTS 3</label>
                                                                <div class="relative mt-1">
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtRECPT3" runat="server" TabIndex="20" type="text" class="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>



                                                        </div>




                                                        <div class="row">

                                                            <div class="col-sm-12">
                                                                <%--  <form class="form" data-toggle="validator" action="##" method="post" id="registrationForm">--%>

                                                                <asp:Label ID="txt_code" Visible="false" runat="server"></asp:Label>
                                                                <div class="row">
                                                                    <div class="col-sm-4 ">
                                                                    </div>
                                                                    <div class="col-sm-4 ">
                                                                    </div>
                                                                    <div class="col-sm-4 ">
                                                                    </div>
                                                                </div>
                                                                <br />
                                                                <div class="row">

                                                                    <%--</form>--%>
                                                                </div>
                                                            </div>

                                                            <center>
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
                                                        </div>
                                                        </center>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:PostBackTrigger ControlID="Btn_Upload" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                           
                                                
                                            
                                            </ContentTemplate>
                                        </cc1:TabPanel>

                                        <%--</div>--%>
                                        <%--<div role="tabpanel" class="tab-pane fade" id="Party"  >--%>
                                        <cc1:TabPanel ID="Party" CssClass="ajax__tab_header" runat="server" HeaderText="Party">

                                            <ContentTemplate>
                                                <asp:UpdatePanel ID="coparty" UpdateMode="Conditional" runat="server">
                                                    <ContentTemplate>


                                                        <div>
                                                            <div class="flex flex-wrap lg:flex-nowrap gap-3">
                                                                <!-- Heading & Buttons -->
                                                                <div class="flex items-center justify-between mb-1 w-full">
                                                                    <div class="flex items-center gap-1">
                                                                        <h2 class="text-[18px] sa700 leading-[18px] text-gray-800 mt-5">Declarant Company</h2>
                                                                        <asp:ImageButton ID="btnShow1" Enabled="false" Style="filter: grayscale(100%); display:none;" CssClass="theme_searchIcon mt-5" runat="server" ImageUrl="images/searchBlue.png" Height="28" Width="28" />
                                                                        <asp:Button ID="DECPLUS" Enabled="false" Style="filter: grayscale(100%);display:none;" runat="server" CssClass="plusbtn plusbtnIcon mt-5" BorderWidth="0px" ValidationGroup="PartyDec" OnClick="DECPLUS_Click" Text="+" />
                                                                    </div>
                                                                </div>

                                                                <!-- Form Inputs -->
                                                                <div class="flex  gap-3 w-full">

                                                                    <!-- Code -->
                                                                    <div class="flex-1 min-w-[150px] max-w-[300px]">
                                                                        <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" Enabled="false" autocomplete="off" runat="server" type="text" OnTextChanged="TxtDecCompCode_TextChanged" placeholder="Code" AutoPostBack="true" ID="TxtDecCompCode" TabIndex="24" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <cc1:AutoCompleteExtender
                                                                                ID="AutoCompleteExtender5"
                                                                                runat="server"
                                                                                CompletionInterval="100"
                                                                                FirstRowSelected="true"
                                                                                MinimumPrefixLength="1"
                                                                                DelimiterCharacters="1"
                                                                                ServiceMethod="GetListofCountries"
                                                                                ServicePath="~/CO.aspx"
                                                                                Enabled="True"
                                                                                CompletionListCssClass="ac_results"
                                                                                CompletionListItemCssClass="listItem"
                                                                                CompletionListHighlightedItemCssClass="itemHighlighted"
                                                                                TargetControlID="TxtDecCompCode" />
                                                                        </div>
                                                                    </div>

                                                                    <!-- CR UEI -->
                                                                    <div class="flex-1 min-w-[200px] max-w-[300px]">
                                                                        <label class="text-gray-500 text-sm font-medium">CR UEI</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" Enabled="false" autocomplete="off" ID="TxtDecCompCRUEI" MaxLength="17" placeholder="CRUEI" runat="server" ValidationGroup="party" TabIndex="25" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtDecCompCRUEI" ID="RegularExpressionValidator1" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="party"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                    </div>

                                                                    <!-- Name 1 -->
                                                                    <div class="flex-1 min-w-[200px] max-w-[300px]">
                                                                        <label class="text-gray-500 text-sm font-medium">Name 1</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" Enabled="false" autocomplete="off" ID="TxtDecCompName" MaxLength="50" placeholder="Name" runat="server" ValidationGroup="party" TabIndex="26" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtDecCompName" ID="RegularExpressionValidator18" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="party"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                    </div>

                                                                    <!-- Name 2 -->
                                                                    <div class="flex-1 min-w-[200px] max-w-[300px]">
                                                                        <label class="text-gray-500 text-sm font-medium">Name 2</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" Enabled="false" autocomplete="off" ID="TxtDecCompName1" MaxLength="50" placeholder="Name1" ValidationGroup="party" runat="server" TabIndex="27" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtDecCompName1" ID="RegularExpressionValidator19" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="party"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                    </div>

                                                                </div>
                                                            </div>


                                                            <%--  search popup start here--%>
                                                            <cc1:ModalPopupExtender ID="popupcodec" runat="server" PopupControlID="pnlPopup" TargetControlID="btnShow1"
                                                                OkControlID="btnYes" CancelControlID="btnNo" BackgroundCssClass="modalBackground">
                                                            </cc1:ModalPopupExtender>
                                                            <asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                                <%--<asp:UpdatePanel  ID="decgrid" runat ="server" UpdateMode ="Conditional">
               <ContentTemplate>  --%>

                                                                <div class="header">

                                                                    <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Declarant Company Search</p>
                                                                </div>

                                                                <div class="body">
                                                                    <asp:UpdatePanel ID="upindec" runat="server" UpdateMode="Conditional">
                                                                        <ContentTemplate>

                                                                            <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="DecSearch" OnTextChanged="DecSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                            </div>

                                                                            <%--<mani>--%>

                                                                            <%--<asp:UpdatePanel ID="UpdatePanelDCS" runat="server"  ChildrenAsTriggers="true" UpdateMode="Always">

                                        
<ContentTemplate>--%>
                                                                            <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                                <asp:GridView ID="DECCOMPSearGRID" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="DECCOMPSearGRID_PageIndexChanging" OnRowCreated="DECCOMPSearGRID_RowCreated" OnRowDataBound="DECCOMPSearGRID_RowDataBound" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" AutoGenerateColumns="false" OnRowCommand="DECCOMPSearGRID_RowCommand">
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
                                                                                                <asp:Label ID="Label1" runat="server"
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
                                                                                                <%--<asp:UpdatePanel ID="gridUpdatePanel" runat="server" UpdateMode ="Conditional" ChildrenAsTriggers="false">
           
           <ContentTemplate><br /> --%>
                                                                                                <%--  <asp:LinkButton ID="lnkRequestID" runat="server" CommandArgument='<%# Eval("Id") %>' CommandName ="lnkRequestID"  >Select </asp:LinkButton>
          <%--  <asp:LinkButton ID="lnkFull" runat="server"  OnClick="FullPostBack">Select </asp:LinkButton>--%>
                                                                                                <asp:LinkButton ID="lnkRequestID" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="lnkRequestID_Command" CssClass="duration-300 ease-in-out md:max-w-[200px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700">Select </asp:LinkButton>
                                                                                                <%--</ContentTemplate>                
         </asp:UpdatePanel>           
                                                                                                --%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </div>
                                                                        </ContentTemplate>
                                                                        <%-- <Triggers>
                                          <asp:PostBackTrigger ControlID="DECCOMPSearGRID" />
                                                                                                           </Triggers>--%>
                                                                    </asp:UpdatePanel>

                                                                </div>
                                                                <div class="footer" align="right">
                                                                    <asp:Button ID="btnYes" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                    <asp:Button ID="btnNo" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px] mt-4 w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                </div>
                                                            </asp:Panel>
                                                        </div>


                                                        <div>
                                                            <div class="flex flex-wrap lg:flex-nowrap gap-3 mt-4">
                                                                <div class="flex items-center justify-between mb-1 mt-4">
                                                                    <!-- Left side heading and buttons -->
                                                                    <div class="flex items-center gap-1">
                                                                        <h2 class="text-[18px] sa700 leading-[18px] text-gray-800 mb-0 mt-5 w-[200px]">Exporter</h2>
                                                                        <asp:ImageButton ID="btncoexp1" CssClass="theme_searchIcon mt-5" runat="server" ImageUrl="images/searchBlue.png" Height="28" Width="28" />
                                                                        <asp:Button ID="BtnExpAdd" runat="server" CssClass="plusbtn plusbtnIcon mt-5" BorderWidth="0px" ValidationGroup="Importer" OnClick="BtnExpAdd_Click" Text="+" />
                                                                    </div>

                                                                    <!-- Code -->
                                                                    <div class="flex-1 min-w-[100px] max-w-[300px] m-1">
                                                                        <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="TxtExpCode" placeholder="Code" OnTextChanged="TxtExpCode_TextChanged" AutoPostBack="true" TabIndex="47" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" />
                                                                            <cc1:AutoCompleteExtender ServiceMethod="GetExpcode"
                                                                                MinimumPrefixLength="1" CompletionInterval="100"
                                                                                CompletionListCssClass="ac_results"
                                                                                CompletionListItemCssClass="listItem"
                                                                                CompletionListHighlightedItemCssClass="itemHighlighted"
                                                                                EnableCaching="false" CompletionSetCount="10"
                                                                                TargetControlID="TxtExpCode"
                                                                                ID="AutoCompleteExtender3" runat="server" FirstRowSelected="true" />
                                                                        </div>
                                                                    </div>

                                                                    <!-- CR UEI -->
                                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                        <label class="text-gray-500 text-sm font-medium">CR UEI</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtExpCRUEI" runat="server" BackColor="#e8f0fe" placeholder="CRUEI" TabIndex="43" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" />

                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="TxtDecCompCRUEI" Display="None" ErrorMessage="Exporter --> Importer CRUEI is Required" ValidationGroup="Validation" />
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtExpCRUEI" ID="RegularExpressionValidator13" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="PartyExp" />
                                                                        </div>
                                                                    </div>

                                                                    <!-- Name -->
                                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                        <label class="text-gray-500 text-sm font-medium">Name</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtExpName" runat="server" placeholder="Name" TabIndex="44" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" />
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ControlToValidate="TxtDecCompCRUEI" Display="None" ErrorMessage="Party --> Exporter Name is Required" ValidationGroup="Validation" />
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtExpName" ID="RegularExpressionValidator11" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="PartyExp" />
                                                                        </div>
                                                                    </div>

                                                                    <!-- Exp Name1 -->
                                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                        <label class="text-gray-500 text-sm font-medium">Exp Name1</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtExpName1" runat="server" ValidationGroup="PartyExp" TabIndex="50" placeholder="Name1" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" />
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtExpName1" ID="RegularExpressionValidator3" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="PartyExp" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <!-- Exporter Address -->
                                                            <div id="expaddress" runat="server" class="flex flex-wrap lg:flex-nowrap gap-3 mt-4">
                                                                <!-- Address 1 -->
                                                               
                                                                <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                    <label class="text-gray-500 text-sm font-medium">Address1</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txtadd1" runat="server" placeholder="Address1" TabIndex="46" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" />
                                                                    </div>
                                                                </div>

                                                                <!-- Address 2 -->
                                                                <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                    <label class="text-gray-500 text-sm font-medium">Address2</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txtadd2" runat="server" placeholder="Address2" TabIndex="47" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" />
                                                                    </div>
                                                                </div>

                                                                <!-- Address 3 -->
                                                                <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                    <label class="text-gray-500 text-sm font-medium">Address3</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txtadd3" runat="server" placeholder="Address3" TabIndex="48" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" />
                                                                    </div>
                                                                </div>
                                                            </div>




                                                            <cc1:ModalPopupExtender ID="popupcoexp" runat="server" PopupControlID="pnlcoexp" TargetControlID="btncoexp1"
                                                                OkControlID="btnYescoexp" CancelControlID="btnNocoexp" BackgroundCssClass="modalBackground">
                                                            </cc1:ModalPopupExtender>

                                                            <asp:Panel ID="pnlcoexp" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                                <%--<asp:UpdatePanel  ID="decgrid" runat ="server" UpdateMode ="Conditional">
               <ContentTemplate>  --%>

                                                                <div class="header">

                                                                    <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">EXPORTER</p>
                                                                </div>

                                                                <div class="body">
                                                                    <asp:UpdatePanel ID="upcoexp" runat="server" UpdateMode="Conditional">
                                                                        <ContentTemplate>
                                                                            <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ExporterSearch" OnTextChanged="ExporterSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                            </div>
                                                                            <%--<mani>--%>

                                                                            <%--<asp:UpdatePanel ID="UpdatePanelDCS" runat="server"  ChildrenAsTriggers="true" UpdateMode="Always">

                                            
<ContentTemplate>--%>
                                                                            <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4 table-responsive">
                                                                                <asp:GridView ID="ExporterGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ExporterGrid_PageIndexChanging" OnRowDataBound="ExporterGrid_RowDataBound" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" AutoGenerateColumns="false" OnRowCommand="ExporterGrid_RowCommand">
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
                                                                                        <asp:TemplateField HeaderText="Address" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblAddress" runat="server"
                                                                                                    Text='<%#Eval("Address")%>'>
                                                                                                </asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Address1" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblAddress1" runat="server"
                                                                                                    Text='<%#Eval("Address1")%>'>
                                                                                                </asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Address2" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblAddress2" runat="server"
                                                                                                    Text='<%#Eval("Address2")%>'>
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
                                                                        <%-- <Triggers>
                                          <asp:PostBackTrigger ControlID="DECCOMPSearGRID" />
                                                                                                           </Triggers>--%>
                                                                    </asp:UpdatePanel>

                                                                </div>
                                                                <div class="footer" align="right">
                                                                    <asp:Button ID="btnYescoexp" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                    <asp:Button ID="btnNocoexp" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px] mt-4 w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                </div>
                                                            </asp:Panel>
                                                        </div>

                                                        <!-- Inward Carrier Agent -->
                                                        <div id="partyinw" runat="server" visible="false">
                                                            <div class="flex flex-wrap lg:flex-nowrap gap-3 mt-4">
                                                                <div class="flex items-center justify-between mb-1 mt-4">
                                                                    <!-- Left side heading and buttons -->
                                                                    <div class="flex items-center gap-1">
                                                                        <h2 class="text-[18px] sa700 leading-[18px] text-gray-800 mb-0 mt-5 w-[200px]">Inward Carrier Agent</h2>
                                                                        <asp:ImageButton ID="btncoinw1" CssClass="theme_searchIcon mt-5" runat="server" ImageUrl="images/searchBlue.png" Height="28" Width="28" />
                                                                        <asp:Button ID="InwardAdd" runat="server" CssClass="plusbtn plusbtnIcon mt-5" BorderWidth="0px" ValidationGroup="PartyDec" OnClick="InwardAdd_Click" Text="+" />
                                                                    </div>

                                                                    <!-- Code -->
                                                                    <div class="flex-1 min-w-[100px] max-w-[300px] m-1">
                                                                        <label for="staticEmail" class="text-gray-500 text-sm font-medium">Code</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" OnTextChanged="InwardCode_TextChanged" placeholder="Code" AutoPostBack="true" ID="InwardCode" TabIndex="24" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <cc1:AutoCompleteExtender
                                                                                ID="AutoCompleteExtender4"
                                                                                runat="server"
                                                                                CompletionInterval="100"
                                                                                FirstRowSelected="true"
                                                                                MinimumPrefixLength="1"
                                                                                DelimiterCharacters="1"
                                                                                ServiceMethod="GetInwcode"
                                                                                ServicePath="~/CO.aspx"
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
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="InwardCRUEI" runat="server" TabIndex="50" PlaceHolder="CRUEI" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="InwardCRUEI" Display="None" ErrorMessage="Party --> Inward Agent CRUEI is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </div>

                                                                    <!-- Name 1 -->
                                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                        <label class="text-gray-500 text-sm font-medium">Name 1</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="InwardName" runat="server" PlaceHolder="Name" TabIndex="51" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="InwardName" Display="None" ErrorMessage="Party --> Inward Agent Name is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </div>

                                                                    <!-- Name 2 -->
                                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                        <label class="text-gray-500 text-sm font-medium">Name 2</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="InwardName1" TabIndex="52" runat="server" PlaceHolder="Name1" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <%--  search popup start here--%>
                                                            <cc1:ModalPopupExtender ID="popupcoinw" runat="server" PopupControlID="pnlcoinw" TargetControlID="btncoinw1"
                                                                OkControlID="btnYescoinw" CancelControlID="btnNocoinw" BackgroundCssClass="modalBackground">
                                                            </cc1:ModalPopupExtender>
                                                            <asp:Panel ID="pnlcoinw" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                                <div class="header">

                                                                    <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Inward Carrier Agent</p>
                                                                </div>
                                                                <div class="body">
                                                                    <asp:UpdatePanel ID="upcoinw" runat="server" UpdateMode="Conditional">
                                                                        <ContentTemplate>
                                                                            <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="InwardSearch" OnTextChanged="InwardSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                            </div>
                                                                            <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                                <asp:GridView ID="InwardGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="InwardGrid_PageIndexChanging" OnRowCreated="DECCOMPSearGRID_RowCreated" OnRowDataBound="InwardGrid_RowDataBound" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" AutoGenerateColumns="false" OnRowCommand="InwardGrid_RowCommand">
                                                                                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="Code" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("Code")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Name" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Label7" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Name1" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Label8" runat="server" Text='<%#Eval("Name1")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="CRUEI" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Label9" runat="server" Text='<%#Eval("CRUEI")%>'></asp:Label>
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
                                                                    <asp:Button ID="btnyesinw" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                    <asp:Button ID="btnnoinw" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px] mt-4 w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                </div>
                                                            </asp:Panel>
                                                        </div>

                                                        <!-- Outward Carrier Agent -->
                                                        <div>
                                                            <div class="flex flex-wrap lg:flex-nowrap gap-3 mt-4">
                                                                <div class="flex items-center justify-between mb-1 mt-4">
                                                                    <!-- Left side heading and buttons -->
                                                                    <div class="flex items-center gap-1">
                                                                        <h2 class="text-[18px] sa700 leading-[18px] text-gray-800 mb-0 mt-5 w-[200px]">OutwardCarrierAgent</h2>
                                                                        <asp:ImageButton ID="btncoout1" CssClass="theme_searchIcon mt-5" runat="server" ImageUrl="images/searchBlue.png" Height="28" Width="28" />
                                                                        <asp:Button ID="OutwardAdd" runat="server" CssClass="plusbtn plusbtnIcon mt-5" BorderWidth="0px" ValidationGroup="Outward" OnClick="OutwardAdd_Click" Text="+" />
                                                                    </div>

                                                                    <!-- Code -->
                                                                    <div class="flex-1 min-w-[100px] max-w-[300px] m-1">
                                                                        <label for="staticEmail" class="text-gray-500 text-sm font-medium">Code</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" OnTextChanged="OutwardCode_TextChanged" placeholder="Code" AutoPostBack="true" ID="OutwardCode" TabIndex="24" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <cc1:AutoCompleteExtender
                                                                                ID="AutoCompleteExtender2"
                                                                                runat="server"
                                                                                CompletionInterval="100"
                                                                                FirstRowSelected="true"
                                                                                MinimumPrefixLength="1"
                                                                                DelimiterCharacters="1"
                                                                                ServiceMethod="GetOutWard"
                                                                                ServicePath="~/CO.aspx"
                                                                                Enabled="True"
                                                                                CompletionListCssClass="ac_results"
                                                                                CompletionListItemCssClass="listItem"
                                                                                CompletionListHighlightedItemCssClass="itemHighlighted"
                                                                                TargetControlID="OutwardCode" />
                                                                        </div>
                                                                    </div>

                                                                    <!-- CR UEI -->
                                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                        <label class="text-gray-500 text-sm font-medium">CR UEI</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="OutwardCRUEI" ValidationGroup="Partyout" PlaceHolder="CRUEI" runat="server" TabIndex="54" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="InwardCRUEI" Display="None" ErrorMessage="Party --> Outward Agent CRUEI is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="OutwardCRUEI" ID="RegularExpressionValidator16" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Partyout"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                    </div>

                                                                    <!-- Name 1 -->
                                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                        <label class="text-gray-500 text-sm font-medium">Name 1</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="OutwardName" ValidationGroup="Partyout" PlaceHolder="Name" runat="server" TabIndex="55" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="OutwardName" Display="None" ErrorMessage="Party --> Outward Agent Name is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="OutwardName" ID="RegularExpressionValidator14" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Partyout"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                    </div>

                                                                    <!-- Name 2 -->
                                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                        <label class="text-gray-500 text-sm font-medium">Name 2</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="OutwardName1" ValidationGroup="Partyout" runat="server" PlaceHolder="Name1" TabIndex="56" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="OutwardName1" ID="RegularExpressionValidator15" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Partyout"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <%--  search popup start here--%>
                                                            <cc1:ModalPopupExtender ID="popupcoout" runat="server" PopupControlID="pnlcoout" TargetControlID="btncoout1"
                                                                OkControlID="btnYescoout" CancelControlID="btnNocoout" BackgroundCssClass="modalBackground">
                                                            </cc1:ModalPopupExtender>
                                                            <asp:Panel ID="pnlcoout" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                                <div class="header">

                                                                    <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Outward Carrier</p>
                                                                </div>
                                                                <div class="body">
                                                                    <asp:UpdatePanel ID="upcoout" runat="server" UpdateMode="Conditional">
                                                                        <ContentTemplate>
                                                                            <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="OutwardSearch" OnTextChanged="OutwardSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                            </div>
                                                                            <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                                <asp:GridView ID="OutwardGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="OutwardGrid_PageIndexChanging" OnRowCreated="DECCOMPSearGRID_RowCreated" OnRowDataBound="OutwardGrid_RowDataBound" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" AutoGenerateColumns="false" OnRowCommand="OutwardGrid_RowCommand">
                                                                                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="Code" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblCode" runat="server" Text='<%#Eval("Code")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Name" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Name1" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblName1" runat="server" Text='<%#Eval("Name1")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="CRUEI" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblCRUEI" runat="server" Text='<%#Eval("CRUEI")%>'></asp:Label>
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
                                                                    <asp:Button ID="btnYescoout" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                    <asp:Button ID="btnNocoout" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px] mt-4 w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                </div>
                                                            </asp:Panel>
                                                        </div>

                                                        <!-- Freight Forwarder -->
                                                        <div>
                                                            <div class="flex flex-wrap lg:flex-nowrap gap-3 mt-4">
                                                                <div class="flex items-center justify-between mb-1 mt-4">
                                                                    <!-- Left side heading and buttons -->
                                                                    <div class="flex items-center gap-1">
                                                                        <h2 class="text-[18px] sa700 leading-[18px] text-gray-800 mb-0 mt-5 w-[200px]">Freight Forwarder</h2>
                                                                        <asp:ImageButton ID="btncofreight1" CssClass="theme_searchIcon mt-5" runat="server" ImageUrl="images/searchBlue.png" Height="28" Width="28" />
                                                                        <asp:Button ID="BtnFrieghtAdd" runat="server" CssClass="plusbtn plusbtnIcon mt-5" BorderWidth="0px" ValidationGroup="FREIGHT" OnClick="BtnFrieghtAdd_Click" Text="+" />
                                                                    </div>

                                                                    <!-- Code -->
                                                                    <div class="flex-1 min-w-[100px] max-w-[300px] m-1">
                                                                        <label for="staticEmail" class="text-gray-500 text-sm font-medium">Code</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" OnTextChanged="FrieghtCode_TextChanged" placeholder="Code" AutoPostBack="true" ID="FrieghtCode" TabIndex="24" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <cc1:AutoCompleteExtender
                                                                                ID="AutoCompleteExtender6"
                                                                                runat="server"
                                                                                CompletionInterval="100"
                                                                                FirstRowSelected="true"
                                                                                MinimumPrefixLength="1"
                                                                                DelimiterCharacters="1"
                                                                                ServiceMethod="GetFrieght"
                                                                                ServicePath="~/CO.aspx"
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
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="FrieghtCRUEI" ValidationGroup="Partyfreight" PlaceHolder="CRUEI" runat="server" TabIndex="58" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="FrieghtCRUEI" ID="RegularExpressionValidator17" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Partyfreight"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                    </div>

                                                                    <!-- Name 1 -->
                                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                        <label class="text-gray-500 text-sm font-medium">Name 1</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="FrieghtName" ValidationGroup="Partyfreight" PlaceHolder="Name" runat="server" TabIndex="60" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="FrieghtName" ID="RegularExpressionValidator60" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Partyfreight"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                    </div>

                                                                    <!-- Name 2 -->
                                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                        <label class="text-gray-500 text-sm font-medium">Name 2</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="FrieghtName1" ValidationGroup="Partyfreight" PlaceHolder="Name1" runat="server" TabIndex="61" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="FrieghtName1" ID="RegularExpressionValidator61" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Partyfreight"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <%--  search popup start here--%>
                                                            <cc1:ModalPopupExtender ID="popupcofreight" runat="server" PopupControlID="pnlcofreight" TargetControlID="btncofreight1"
                                                                OkControlID="btnYescofreight" CancelControlID="btnNocofreight" BackgroundCssClass="modalBackground">
                                                            </cc1:ModalPopupExtender>
                                                            <asp:Panel ID="pnlcofreight" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                                <div class="header">

                                                                    <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Outward Carrier</p>
                                                                </div>
                                                                <div class="body">
                                                                    <asp:UpdatePanel ID="upcofreight" runat="server" UpdateMode="Conditional">
                                                                        <ContentTemplate>
                                                                            <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="FrieghtSearch" OnTextChanged="FrieghtSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                            </div>
                                                                            <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                                <asp:GridView ID="FrieghtGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="FrieghtGrid_PageIndexChanging" OnRowCreated="DECCOMPSearGRID_RowCreated" OnRowDataBound="FrieghtGrid_RowDataBound" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" AutoGenerateColumns="false" OnRowCommand="FrieghtGrid_RowCommand">
                                                                                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="Code" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblCode" runat="server" Text='<%#Eval("Code")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Name" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Name1" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblName1" runat="server" Text='<%#Eval("Name1")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="CRUEI" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblCRUEI" runat="server" Text='<%#Eval("CRUEI")%>'></asp:Label>
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
                                                                    <asp:Button ID="btnYescofreight" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                    <asp:Button ID="btnNocofreight" runat="server" Text="No" CssClass="duration-300 ease-in-out md:max-w-[80px] mt-4 w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                </div>
                                                            </asp:Panel>
                                                        </div>

                                                        <!-- Consignee -->
                                                        <div>
                                                            <div class="flex flex-wrap lg:flex-nowrap gap-3 mt-4">
                                                                <div class="flex items-center justify-between mb-1 mt-4">
                                                                    <!-- Left side heading and buttons -->
                                                                    <div class="flex items-center gap-1">
                                                                        <h2 class="text-[18px] sa700 leading-[18px] text-gray-800 mb-0 mt-5 w-[200px]">Consignee</h2>
                                                                        <asp:ImageButton ID="btncoconsignee1" CssClass="theme_searchIcon mt-5" runat="server" ImageUrl="images/searchBlue.png" Height="28" Width="28" />
                                                                        <asp:Button ID="ConsigneeAdd" runat="server" CssClass="plusbtn plusbtnIcon mt-5" BorderWidth="0px" ValidationGroup="CLAIMANT" OnClick="ConsigneeAdd_Click" Text="+" />
                                                                    </div>

                                                                    <!-- Code -->
                                                                    <div class="flex-1 min-w-[100px] max-w-[300px] m-1">
                                                                        <label for="staticEmail" class="text-gray-500 text-sm font-medium">Code</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="ConsigneeCode" placeholder="Code" OnTextChanged="ConsigneeCode_TextChanged" AutoPostBack="true" TabIndex="47" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <cc1:AutoCompleteExtender ServiceMethod="GetCosigncode"
                                                                                MinimumPrefixLength="1"
                                                                                CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
                                                                                TargetControlID="ConsigneeCode"
                                                                                ID="AutoCompleteExtender9" runat="server" FirstRowSelected="true">
                                                                            </cc1:AutoCompleteExtender>
                                                                        </div>
                                                                    </div>

                                                                    <!-- CR UEI -->
                                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                        <label class="text-gray-500 text-sm font-medium">CR UEI</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ConsigneeCRUEI" ValidationGroup="PartyClaimant" runat="server" PlaceHolder="CRUEI" TabIndex="63" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeCRUEI" ID="RegularExpressionValidator68" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                    </div>

                                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                        <label class="text-gray-500 text-sm font-medium">Name</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="PartyClaimant" type="text" ID="ConsigneeName" PlaceHolder="Name" TabIndex="66" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <br />
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeName" ID="RegularExpressionValidator20" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                    </div>
                                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                        <label class="text-gray-500 text-sm font-medium">Name1</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ConsigneeName1" ValidationGroup="PartyClaimant" PlaceHolder="Name1" runat="server" TabIndex="69" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <br />
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeName1" ID="RegularExpressionValidator21" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                    </div>

                                                                </div>
                                                            </div>

                                                            <!-- Additional rows for Consignee -->
                                                            <div id="Div2" runat="server" class="flex flex-wrap lg:flex-nowrap gap-3 mt-4">
                                                               <%-- <div class="flex-1 min-w-[200px] max-w-[300px] m-1"></div>--%>

                                                                <!-- Name -->
                                                                <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                    <label class="text-gray-500 text-sm font-medium">Address</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ConsigneeAddress" ValidationGroup="PartyClaimant" PlaceHolder="Address" BackColor="#e8f0fe" runat="server" TabIndex="64" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeAddress" ID="RegularExpressionValidator22" ValidationExpression="^[\s\S]{0,160}$" runat="server" ErrorMessage="Maximum 160 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                    <label class="text-gray-500 text-sm font-medium">Address1</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ConsigneeAddress1" ValidationGroup="PartyClaimant" runat="server" PlaceHolder="Address1" TabIndex="67" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <br />
                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeAddress1" ID="RegularExpressionValidator23" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>

                                                                <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                    <label class="text-gray-500 text-sm font-medium">City</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ConsigneeCity" ValidationGroup="PartyClaimant" PlaceHolder="Address2" runat="server" TabIndex="70" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <br />
                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeCity" ID="RegularExpressionValidator24" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>

                                                                <!-- Exp Name1 -->
                                                                <div class="flex-1 min-w-[200px] max-w-[300px] m-1" style="display: none;">
                                                                    <label class="text-gray-500 text-sm font-medium">Sub</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ConsigneeSub" ValidationGroup="PartyClaimant" runat="server" Visible="false" TabIndex="65" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <br />
                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeSub" ID="RegularExpressionValidator25" ValidationExpression="^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>




                                                            </div>

                                                            <div id="Div4" runat="server" class="flex flex-wrap lg:flex-nowrap gap-3 mt-4">

                                                                <div class="flex-1 min-w-[200px] max-w-[300px] m-1" style="display: none;">
                                                                    <label class="text-gray-500 text-sm font-medium">Postal</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ConsigneePostal" ValidationGroup="PartyClaimant" runat="server" TabIndex="68" Visible="false" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <br />
                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneePostal" ID="RegularExpressionValidator26" ValidationExpression="^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="flex-1 min-w-[200px] max-w-[300px] m-1" style="display: none;">
                                                                    <label class="text-gray-500 text-sm font-medium">Country</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ConsigneeCountry" ValidationGroup="PartyClaimant" runat="server" Visible="false" TabIndex="71" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <br />
                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeCountry" ID="RegularExpressionValidator27" ValidationExpression="^[\s\S]{0,2}$" runat="server" ErrorMessage="Maximum 2 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <!-- Modal popup for Consignee -->
                                                            <cc1:ModalPopupExtender ID="popupcoconsignee" runat="server" PopupControlID="pnlcoconsignee" TargetControlID="btncoconsignee1"
                                                                OkControlID="btnYescoconsignee" CancelControlID="btnNococonsignee" BackgroundCssClass="modalBackground">
                                                            </cc1:ModalPopupExtender>
                                                            <asp:Panel ID="pnlcoconsignee" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                                <div class="header">

                                                                    <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">CONSIGNEE</p>
                                                                </div>
                                                                <div class="body">
                                                                    <asp:UpdatePanel ID="upcoconsignee" runat="server" UpdateMode="Conditional">
                                                                        <ContentTemplate>
                                                                            <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ConsigneeSearch" OnTextChanged="ConsigneeSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                            </div>
                                                                            <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4 table-responsive">
                                                                                <asp:GridView ID="ConsigneeGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ConsigneeGrid_PageIndexChanging" OnRowDataBound="ConsigneeGrid_RowDataBound" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false" OnRowCommand="ConsigneeGrid_RowCommand">
                                                                                    <PagerStyle HorizontalAlign="Center" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" />
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="Code" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblCode" runat="server" Text='<%#Eval("ConsigneeCode")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Name" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblName" runat="server" Text='<%#Eval("ConsigneeName")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Name1" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblName1" runat="server" Text='<%#Eval("ConsigneeName1")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="CRUEI" SortExpression="Id" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblCRUEI" runat="server" Text='<%#Eval("ConsigneeCRUEI")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Address" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="ConsigneeAddress" runat="server" Text='<%#Eval("ConsigneeAddress")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Address1" SortExpression="Id" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="ConsigneeAddress1" runat="server" Text='<%#Eval("ConsigneeAddress1")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Address2" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="ConsigneeCity" runat="server" Text='<%#Eval("ConsigneeCity")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Sub Contry" SortExpression="Id" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="ConsigneeSub" runat="server" Text='<%#Eval("ConsigneeSub")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="City" SortExpression="Id" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="ConsigneePostal" runat="server" Text='<%#Eval("ConsigneePostal")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="City" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="ConsigneeCountry" runat="server" Text='<%#Eval("ConsigneeCountry")%>'></asp:Label>
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
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div class="footer" align="right">
                                                                    <asp:Button ID="btnYescoconsignee" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                    <asp:Button ID="btnNococonsignee" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px] mt-4 w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                </div>
                                                            </asp:Panel>
                                                        </div>

                                                        <!-- Manufacturer -->
                                                        <div>
                                                            <div class="flex flex-wrap lg:flex-nowrap gap-3 mt-4">
                                                                <div class="flex items-center justify-between mb-1 mt-4">
                                                                    <!-- Left side heading and buttons -->
                                                                    <div class="flex items-center gap-1">
                                                                        <h2 class="text-[18px] sa700 leading-[18px] text-gray-800 mb-0 mt-5 w-[200px]">Manufacturer</h2>
                                                                        <asp:ImageButton ID="btncomanufacturer1" CssClass="theme_searchIcon mt-5" runat="server" ImageUrl="images/searchBlue.png" Height="28" Width="28" />
                                                                        <asp:Button ID="ManufacturerAdd" runat="server" CssClass="plusbtn plusbtnIcon mt-5" BorderWidth="0px" ValidationGroup="CLAIMANT" OnClick="ManufacturerAdd_Click" Text="+" />
                                                                    </div>

                                                                    <!-- Code -->
                                                                    <div class="flex-1 min-w-[100px] max-w-[300px] m-1">
                                                                        <label for="staticEmail" class="text-gray-500 text-sm font-medium">Code</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="ManufacturerCode" placeholder="Code" OnTextChanged="ManufacturerCode_TextChanged" AutoPostBack="true" TabIndex="47" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <cc1:AutoCompleteExtender ServiceMethod="GetManufactcode"
                                                                                MinimumPrefixLength="1"
                                                                                CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
                                                                                TargetControlID="ManufacturerCode"
                                                                                ID="AutoCompleteExtender1" runat="server" FirstRowSelected="true">
                                                                            </cc1:AutoCompleteExtender>
                                                                        </div>
                                                                    </div>

                                                                    <!-- Name -->
                                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                        <label class="text-gray-500 text-sm font-medium">Name</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="ManufacturerName" PlaceHolder="Name" TabIndex="74" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ManufacturerName" ID="RegularExpressionValidator4" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="Manufacture"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                    </div>

                                                                    <!-- Name 1 -->
                                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                        <label class="text-gray-500 text-sm font-medium">Name 1</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ManufacturerName1" runat="server" PlaceHolder="Name1" TabIndex="75" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ManufacturerName1" ID="RegularExpressionValidator28" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="Manufacture"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                    </div>

                                                                    <!-- CR UEI -->
                                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                        <label class="text-gray-500 text-sm font-medium">CR UEI</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ManufacturerCRUEI" runat="server" PlaceHolder="CRUEI" TabIndex="73" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ManufacturerCRUEI" ID="RegularExpressionValidator2" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Manufacture"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <!-- Additional rows for Manufacturer -->
                                                            <div id="Div5" runat="server" class="flex flex-wrap lg:flex-nowrap gap-3 mt-4">
                                                                <%--<div class="flex-1 min-w-[200px] max-w-[300px] m-1"></div>--%>
                                                                <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                    <label class="text-gray-500 text-sm font-medium">Address</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ManufacturerAddress" PlaceHolder="Address" runat="server" TabIndex="76" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ManufacturerAddress" ID="RegularExpressionValidator31" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Manufacture"></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                    <label class="text-gray-500 text-sm font-medium">Address 1</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ManufacturerAddress1" runat="server" PlaceHolder="Address1" TabIndex="77" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ManufacturerAddress1" ID="RegularExpressionValidator34" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Manufacture"></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                    <label class="text-gray-500 text-sm font-medium">Country Subdivision Code</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ManufacturerSubCode" runat="server" PlaceHolder="Sub Code" TabIndex="79" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ManufacturerSubCode" ID="RegularExpressionValidator33" ValidationExpression="^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="Manufacture"></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                    <label class="text-gray-500 text-sm font-medium">Subdivision</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ManufacturerSubDivi" Style="text-transform: uppercase" ValidationGroup="Manufacture" placeholder="Sub Division" runat="server" TabIndex="80" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ManufacturerSubDivi" ID="RegularExpressionValidator137" ValidationExpression="^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="Manufacture"></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div id="Div6" runat="server" class="flex flex-wrap lg:flex-nowrap gap-3 mt-4">
                                                                <%--<div class="flex-1 min-w-[200px] max-w-[300px] m-1"></div>--%>
                                                                <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                    <label class="text-gray-500 text-sm font-medium">Postal Code</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ManufacturerPostal" runat="server" PlaceHolder="Postal Code" TabIndex="82" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ManufacturerPostal" ID="RegularExpressionValidator35" ValidationExpression="^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="Manufacture"></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                    <label class="text-gray-500 text-sm font-medium">City Name</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ManufacturerCity" runat="server" Placeholder="City" TabIndex="78" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ManufacturerCity" ID="RegularExpressionValidator32" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Manufacture"></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                                    <label class="text-gray-500 text-sm font-medium">Country Code</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ManufacturerCountry" runat="server" PlaceHolder="Country" TabIndex="81" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ManufacturerCountry" ID="RegularExpressionValidator36" ValidationExpression="^[\s\S]{0,2}$" runat="server" ErrorMessage="Maximum 2 characters allowed." ValidationGroup="Manufacture"></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="flex-1 min-w-[200px] max-w-[300px] m-1"></div>
                                                            </div>

                                                            <!-- Modal popup for Manufacturer -->
                                                            <cc1:ModalPopupExtender ID="popupcomanufacturer" runat="server" PopupControlID="pnlcomanufacturer" TargetControlID="btncomanufacturer1"
                                                                OkControlID="btnYescomanufacturer" CancelControlID="btnNocomanufacturer" BackgroundCssClass="modalBackground">
                                                            </cc1:ModalPopupExtender>
                                                            <asp:Panel ID="pnlcomanufacturer" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                                <div class="header">

                                                                    <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Manufacturer</p>
                                                                </div>
                                                                <div class="body">
                                                                    <asp:UpdatePanel ID="upcomanufacturer" runat="server" UpdateMode="Conditional">
                                                                        <ContentTemplate>
                                                                            <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ManufacturerSearch" OnTextChanged="ManufacturerSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                            </div>
                                                                            <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4 table-responsive">
                                                                                <asp:GridView ID="ManufacturerGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ManufacturerGrid_PageIndexChanging" OnRowDataBound="ManufacturerGrid_RowDataBound" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" AutoGenerateColumns="false" OnRowCommand="ManufacturerGrid_RowCommand">
                                                                                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="Code" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblCode" runat="server" Text='<%#Eval("ManufacturerCode")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Name" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblName" runat="server" Text='<%#Eval("ManufacturerName")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Name1" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblName1" runat="server" Text='<%#Eval("ManufacturerName1")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="CRUEI" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblCRUEI" runat="server" Text='<%#Eval("ManufacturerCRUEI")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Address" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Address" runat="server" Text='<%#Eval("ManufacturerAddress")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Address1" SortExpression="Id" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Address1" runat="server" Text='<%#Eval("ManufacturerAddress1")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="City" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="City" runat="server" Text='<%#Eval("ManufacturerCity")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Contry Sub Code" SortExpression="Id" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="subcounty" runat="server" Text='<%#Eval("ManufacturerSub")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Sub Division" SortExpression="Id" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Division" runat="server" Text='<%#Eval("ManufacturerSubDivi")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Postal" SortExpression="Id" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Postal" runat="server" Text='<%#Eval("ManufacturerPostal")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>

                                                                                        <asp:TemplateField HeaderText="Country" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Country" runat="server" Text='<%#Eval("ManufacturerCountry")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton ID="LmkManufacturer" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LmkManufacturer_Command" CssClass="duration-300 ease-in-out md:max-w-[200px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700">Select </asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </div>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div class="footer" align="right">
                                                                    <asp:Button ID="btnYescomanufacturer" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                    <asp:Button ID="btnNocomanufacturer" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px] mt-4 w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                </div>
                                                            </asp:Panel>
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

                                        <%--  </div>--%>
                                        <%-- <div role="tabpanel" class="tab-pane fade" id="Cargo">--%>

                                        <cc1:TabPanel ID="Cargo1" CssClass="ajax__tab_header" runat="server" HeaderText="Cargo">

                                            <ContentTemplate>
                                                <asp:UpdatePanel ID="cocargo" UpdateMode="Conditional" runat="server">
                                                    <ContentTemplate>


                                                        <div id="InwardDetailsdiv1" runat="server" class="mt-4" visible="false">


                                                            <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                                <div class="md:max-w-[250px] w-full" id="carMode" runat="server">
                                                                    <label class="text-gray-500 text-sm font-medium">Mode</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" Enabled="false" runat="server" type="text" ID="TextMode" OnTextChanged="TextMode_TextChanged" AutoPostBack="true" TabIndex="113" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    </div>
                                                                </div>

                                                                <div class="md:max-w-[250px] w-full" id="carArrival" runat="server">
                                                                    <label class="text-gray-500 text-sm font-medium">Arrival Date & Time</label>
                                                                    <div class="relative mt-1">
                                                                        <input type="date" id='TxtArrivalDate1' runat="server" class="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" />
                                                                        <span class="input-group-addon" style="display: none;">
                                                                            <span class="glyphicon glyphicon-calendar"></span>
                                                                        </span>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtArrivalDate1" Display="None" ErrorMessage="Cargo --> Arrival Date is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>

                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Loading Port </label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="TxtLoadShort" OnTextChanged="TxtLoadShort_TextChanged" AutoPostBack="true" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="TxtLoadShort" Display="None" ErrorMessage="Cargo --> Loading Port is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>

                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Loading Port 2  </label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="TxtLoad" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    </div>
                                                                </div>

                                                            </div>

                                                            <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2" id="InwardFlight" runat="server">

                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Flight Number</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="Validation" type="text" ID="txtflight" TabIndex="56" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtflight" Display="None" ErrorMessage="Cargo -->Flight Number is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>

                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Aircraft Register Number</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="Validation" type="text" ID="txtaircraft" TabIndex="57" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    </div>
                                                                </div>

                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Master Air Waybill </label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="Validation" type="text" ID="txtwaybill" TabIndex="58" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtwaybill" Display="None" ErrorMessage="Cargo -->Master Air Waybill is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>

                                                                <div class="md:max-w-[250px] w-full"></div>
                                                            </div>

                                                            <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2" id="InwardSea" runat="server">

                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Voyage Number</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="Validation" type="text" ID="TxtVoyageno" TabIndex="59" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="TxtVoyageno" Display="None" ErrorMessage="Cargo -->Voyage Number is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtVoyageno" ID="RegularExpressionValidator102" ValidationExpression="^[\s\S]{0,15}$" runat="server" ErrorMessage="Maximum 15 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>

                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Vessel Name</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="Validation" type="text" ID="TxtVesselName" TabIndex="60" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="TxtVesselName" Display="None" ErrorMessage="Cargo -->Vessel Name is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                        <br />
                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtVesselName" ID="RegularExpressionValidator7" ValidationExpression="^[\s\S]{0,15}$" runat="server" ErrorMessage="Maximum 15 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>

                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">OBL</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="Validation" type="text" ID="TxtOceanBill" TabIndex="93" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="TxtOceanBill" Display="None" ErrorMessage="Cargo -->Ocean Bill Of Lading Number is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtOceanBill" ID="RegularExpressionValidator104" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="md:max-w-[250px] w-full"></div>

                                                            </div>

                                                            <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2" id="InwardOther" runat="server">
                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Conveyance Ref.No</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ValidationGroup="Validation" ID="TxtConRefNo" TabIndex="62" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtConRefNo" ID="RegularExpressionValidator9" ValidationExpression="^[\s\S]{0,15}$" runat="server" ErrorMessage="Maximum 15 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>

                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Transport ID</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ValidationGroup="Validation" ID="TxtTrnsID" TabIndex="63" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtTrnsID" ID="RegularExpressionValidator10" ValidationExpression="^[\s\S]{0,15}$" runat="server" ErrorMessage="Maximum 15 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>

                                                                <div class="md:max-w-[250px] w-full"></div>
                                                                <div class="md:max-w-[250px] w-full"></div>
                                                            </div>
                                                            <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">

                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Release Location</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="txtreLoctn" OnTextChanged="txtreLoctn_TextChanged" AutoPostBack="true" TabIndex="64" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtreLoctn" Display="None" ErrorMessage="Cargo -->Release Location Code is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>

                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Release Location2</label>
                                                                    <div class="relative mt-1">

                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="txtrelocDeta" TabIndex="65" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    </div>
                                                                </div>

                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Receipt Location </label>
                                                                    <div class="relative mt-1">

                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" OnTextChanged="txtrecloctn_TextChanged" AutoPostBack="true" ID="txtrecloctn" TabIndex="66" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtrecloctn" Display="None" ErrorMessage="Cargo -->Receipt Location Code is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>

                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Receipt Location2 </label>
                                                                    <div class="relative mt-1">

                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="txtrecloctndet" TabIndex="67" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Storage Location </label>
                                                                    <div class="relative mt-1">

                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" OnTextChanged="TxtStorageShort_TextChanged" AutoPostBack="true" ID="TxtStorageShort" TabIndex="66" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator63" runat="server" ControlToValidate="txtrecloctn" Display="None" ErrorMessage="Cargo -->Receipt Location Code is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>

                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Storage Location2 </label>
                                                                    <div class="relative mt-1">

                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="TxtStorageName" TabIndex="67" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    </div>
                                                                </div>

                                                                <div class="md:max-w-[250px] w-full"></div>
                                                                <div class="md:max-w-[250px] w-full"></div>
                                                            </div>
                                                        </div>



                                                        <div id="outtr" runat="server">


                                                            <div class="grid grid-cols-1 md:grid-cols-2 gap-6 mt-4 mb-2">
                                                                <div class="space-y-4">
                                                                    <!-- Header -->
                                                                    <div class="bg-gray-700 text-center rounded-full py-2 mt-7 w-[566px]">
                                                                        <span class="text-white text-sm font-semibold tracking-wide">OUTWARD DETAILS</span>
                                                                    </div>

                                                                    <!-- MODE - Full Width -->
                                                                    <div class="mb-4 flex items-center gap-4">
                                                                        <label class="text-gray-700 font-medium text-sm w-48 flex-shrink-0">MODE</label>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" Enabled="false" runat="server" type="text" ID="TxtExpMode" OnTextChanged="TxtExpMode_TextChanged" AutoPostBack="true" CssClass="flex-1 h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    </div>

                                                                    <!-- DEPARTURE DATE & TIME - Full Width -->
                                                                    <div class="mb-4 flex items-center gap-4">
                                                                        <label class="text-gray-500 text-sm font-medium w-48 flex-shrink-0">DEPARTURE DATE & TIME</label>
                                                                        <div class="flex-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtExpArrivalDate1" TabIndex="87" AutoPostBack="true" onkeypress="return noAlphabets(event)" runat="server" OnTextChanged="TxtExpArrivalDate1_TextChanged" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <cc1:CalendarExtender ID="CalendarExtender2" CssClass="cal_Theme1" PopupButtonID="imgPopup" runat="server" TargetControlID="TxtExpArrivalDate1" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"></cc1:CalendarExtender>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ControlToValidate="TxtExpArrivalDate1" Display="None" ErrorMessage="Cargo --> Arrival Date is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </div>

                                                                    <!-- DISCHARGE PORT - Two Fields Side by Side -->
                                                                    <div class="mb-4 flex items-start gap-4">
                                                                        <label class="text-gray-500 text-sm font-medium w-48 flex-shrink-0 flex items-center gap-2 pt-2">
                                                                            DISCHARGE PORT
                <asp:ImageButton ID="btncodischargeport1" runat="server" ImageUrl="./images/circel-search.svg" Height="15" Width="15" />
                                                                        </label>
                                                                        <div class="flex-1">
                                                                            <div class="grid grid-cols-2 gap-3">
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="TxtExpLoadShort" OnTextChanged="TxtExpLoadShort_TextChanged" AutoPostBack="true" TabIndex="88" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtExpLoad" TabIndex="87" AutoPostBack="true" onkeypress="return noAlphabets(event)" runat="server" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            </div>
                                                                            <cc1:AutoCompleteExtender ServiceMethod="DischargePort" MinimumPrefixLength="1" CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10" TargetControlID="TxtExpLoadShort" ID="AutoCompleteExtender18" runat="server" FirstRowSelected="true"></cc1:AutoCompleteExtender>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ControlToValidate="TxtExpLoadShort" Display="None" ErrorMessage="Cargo --> Loading Port is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </div>

                                                                    <!-- FINAL DESTINATION COUNTRY - Full Width -->
                                                                    <div class="mb-4 flex items-center gap-4">
                                                                        <label class="text-gray-500 text-sm font-medium w-48 flex-shrink-0">FINAL DESTINATION COUNTRY</label>
                                                                        <asp:DropDownList ID="DrpFinalDesCountry" CssClass="flex-1 bg-slate-100 font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center h-10 px-4" runat="server" TabIndex="59" AutoPostBack="true"></asp:DropDownList>
                                                                    </div>

                                                                    <!-- Modal Popup (keeping original structure) -->
                                                                    <cc1:ModalPopupExtender ID="popupcodischargeport" runat="server" PopupControlID="pnlcodischargeport" TargetControlID="btncodischargeport1" OkControlID="btnYescodischargeport" CancelControlID="btnNocodischargeport" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
                                                                    <asp:Panel ID="pnlcodischargeport" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white" Style="display: none">
                                                                        <div class="header">

                                                                            <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">DISCHARGE PORT</p>
                                                                        </div>
                                                                        <div class="body">
                                                                            <asp:UpdatePanel ID="upcodischargeport" runat="server" UpdateMode="Conditional">
                                                                                <ContentTemplate>
                                                                                    <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                        <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ExpLoadingSearch" OnTextChanged="ExpLoadingSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                                        <asp:GridView ID="ExportGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ExportGrid_PageIndexChanging" OnRowCommand="ExportGrid_RowCommand" OnRowDataBound="ExportGrid_RowDataBound" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" AutoGenerateColumns="false">
                                                                                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                            <Columns>
                                                                                                <asp:TemplateField HeaderText="PortCode" SortExpression="Id">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="Label39" runat="server" Text='<%#Eval("PortCode")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="PortName" SortExpression="Id">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="Label40" runat="server" Text='<%#Eval("PortName")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Country" SortExpression="Id">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="Label41" runat="server" Text='<%#Eval("Country")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField Visible="false">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton ID="LnkExport" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkExport_Command" CssClass="duration-300 ease-in-out md:max-w-[200px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700">Select </asp:LinkButton>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                            </Columns>
                                                                                        </asp:GridView>
                                                                                    </div>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <div class="footer" align="right">
                                                                            <asp:Button ID="btnYescodischargeport" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                            <asp:Button ID="btnNocodischargeport" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px] mt-4 w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                        </div>
                                                                    </asp:Panel>
                                                                </div>
                                                            </div>


                                                            <div class="md:max-w-[250px] w-full" id="seasore" runat="server" visible="false">
                                                                <label class="text-gray-500 text-sm font-medium">Sea Store</label>
                                                                <div class="relative mt-1">
                                                                    <asp:CheckBox ID="chkSea" runat="server" TabIndex="251" Style="text-transform: lowercase" />
                                                                </div>
                                                            </div>

                                                            <div class="md:max-w-[250px] w-full"></div>
                                                            <div class="md:max-w-[250px] w-full"></div>


                                                            <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2" id="OUTWARDFlight" runat="server">
                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Flight Number</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="OUTWARDFlightN0" TabIndex="92" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ControlToValidate="txtflight" Display="None" ErrorMessage="Cargo -->Flight Number is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>

                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Aircraft Register Number</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="OUTWARDAirREgno" TabIndex="93" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="md:max-w-[250px] w-full"></div>
                                                                <div class="md:max-w-[250px] w-full"></div>
                                                            </div>

                                                            <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2" id="OUTWARDSea" runat="server">
                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Voyage Number</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="OUTWARDVoyageNo" TabIndex="94" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator52" runat="server" ControlToValidate="TxtVoyageno" Display="None" ErrorMessage="Cargo -->Voyage Number is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>

                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Vessel Name</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="OUTWARDVessel" TabIndex="95" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator53" runat="server" ControlToValidate="TxtVesselName" Display="None" ErrorMessage="Cargo -->Vessel Name is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>

                                                                <div class="md:max-w-[250px] w-full"></div>
                                                                <div class="md:max-w-[250px] w-full"></div>
                                                            </div>

                                                            <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2" id="OUTWARDOther" runat="server">
                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Conveyance Ref.No</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="OUTWARDConref" TabIndex="96" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    </div>
                                                                </div>

                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Transport ID</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="OUTWARDTransId" TabIndex="97" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="md:max-w-[250px] w-full"></div>
                                                                <div class="md:max-w-[250px] w-full"></div>
                                                            </div>


                                                            <div id="OUTWARDVesl" runat="server">
                                                                <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2" runat="server">
                                                                    <div class="md:max-w-[250px] w-full">
                                                                        <label class="text-gray-500 text-sm font-medium">Vessel Name</label>
                                                                        <div class="relative mt-1">

                                                                            <asp:DropDownList ID="ddpVessel" CssClass=" bg-slate-100 font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt-1 px-4" runat="server" TabIndex="59" AutoPostBack="true"></asp:DropDownList>



                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator55" runat="server" ControlToValidate="ddpVessel" Display="None" ErrorMessage="Cargo -->Master Air Waybill is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </div>

                                                                    <div class="md:max-w-[250px] w-full">
                                                                        <label class="text-gray-500 text-sm font-medium">Vessel Net Register Tonnage</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="txtvesnet" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        </div>
                                                                    </div>

                                                                    <div class="md:max-w-[250px] w-full">
                                                                        <label class="text-gray-500 text-sm font-medium">Vessel Nationality</label>
                                                                        <div class="relative mt-1">

                                                                            <asp:DropDownList ID="DroVesslNat" CssClass=" bg-slate-100 font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt-1 px-4" runat="server" TabIndex="59" AutoPostBack="true"></asp:DropDownList>
                                                                        </div>
                                                                    </div>

                                                                    <div class="md:max-w-[250px] w-full">
                                                                        <label class="text-gray-500 text-sm font-medium">Towing Vessel ID</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="txtTowVes" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                                    <div class="md:max-w-[250px] w-full">
                                                                        <label class="text-gray-500 text-sm font-medium">Towing Vessel Name</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="txtTowVesName" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        </div>
                                                                    </div>

                                                                    <div class="md:max-w-[250px] w-full">
                                                                        <label class="text-gray-500 text-sm font-medium">Next Port</i></label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="txtNextprt" AutoPostBack="true" OnTextChanged="txtNextprt_TextChanged" TabIndex="88" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        </div>
                                                                    </div>

                                                                    <div class="md:max-w-[250px] w-full">
                                                                        <label class="text-gray-500 text-sm font-medium">Next Port2 </i></label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="txtNetPrtSer" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        </div>
                                                                    </div>

                                                                    <div class="md:max-w-[250px] w-full">
                                                                        <label class="text-gray-500 text-sm font-medium">Last Port  </label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="txtLasPrt" AutoPostBack="true" OnTextChanged="txtLasPrt_TextChanged" TabIndex="90" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                                    <div class="md:max-w-[250px] w-full">
                                                                        <label class="text-gray-500 text-sm font-medium">Last Port2  </i></label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="txtLasPrtSer" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                        </div>


                                                        <div id="outerpack" runat="server" visible="false">
                                                            <div class="flex justify-between gap-2 items-center mt-7">
                                                                <h2 class="text-lg sa700 leading-[18px] text-gray-800">Outer Pack Details
                                                                </h2>
                                                            </div>

                                                            <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Total Outer Pack</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="TxttotalOuterPack" TabIndex="98" AutoPostBack="true" OnTextChanged="TxttotalOuterPack_TextChanged" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    </div>
                                                                </div>

                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Total Outer Pack</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:DropDownList ID="DrptotalOuterPack" OnSelectedIndexChanged="DrptotalOuterPack_SelectedIndexChanged" CssClass=" bg-slate-100 font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt-1 px-4" runat="server" TabIndex="59" AutoPostBack="true"></asp:DropDownList>
                                                                    </div>
                                                                </div>

                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Total Gross Weight</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="TxtTotalGrossWeight" TabIndex="100" AutoPostBack="true" OnTextChanged="TxtTotalGrossWeight_TextChanged" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    </div>
                                                                </div>

                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Total Outer Pack</label>
                                                                    <div class="relative mt-1">

                                                                        <asp:DropDownList ID="DrpTotalGrossWeight" OnSelectedIndexChanged="DrpTotalGrossWeight_SelectedIndexChanged" CssClass=" bg-slate-100 font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt-1 px-4" runat="server" TabIndex="59" AutoPostBack="true">


                                                                            <asp:ListItem Selected="True" Text="--Select--" Value="--SELECT--"> </asp:ListItem>
                                                                            <asp:ListItem Selected="false" Text="KGM" Value="KGM"> </asp:ListItem>
                                                                            <asp:ListItem Selected="false" Text="TNE" Value="TNE"> </asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <%--  --%>
                                                                    </div>
                                                                </div>

                                                            </div>

                                                            <div id="ContainerDetails" runat="server" class="mt-3">
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
                                                                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator5" runat="server" Font-Size="XX-Small" ControlToValidate="txt1" ErrorMessage="Container No is Required" ForeColor="Red" ValidationGroup="Container"></asp:RequiredFieldValidator>
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
                                                                                <asp:Button ID="ButtonAdd" runat="server" Text="+ Add Row" ValidationGroup="Container" OnClick="ButtonAdd_Click" />
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>











                                                        <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                            <div class="col-sm-12">
                                                                <div class="row">
                                                                    <div class="col-sm-8">


                                                                        <div class="modal fade" id="loadingSearch" role="dialog">
                                                                            <div class="modal-dialog">

                                                                                <!-- Modal content-->
                                                                                <div class="modal-content">
                                                                                    <div class="modal-header">
                                                                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                                                        <h4 class="modal-title">Loading Port</h4>
                                                                                    </div>
                                                                                    <div class="modal-body">
                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="CarLoadingSearch" OnTextChanged="CarLoadingSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                        <br />
                                                                                        <asp:GridView ID="LoadingGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="LoadingGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                                                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                            <Columns>


                                                                                                <asp:TemplateField HeaderText="PortCode" SortExpression="Id">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="Label42" runat="server"
                                                                                                            Text='<%#Eval("PortCode")%>'>
                                                                                                        </asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="PortName" SortExpression="Id">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="Label43" runat="server"
                                                                                                            Text='<%#Eval("PortName")%>'>
                                                                                                        </asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>

                                                                                                <asp:TemplateField HeaderText="Country" SortExpression="Id">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="Label44" runat="server"
                                                                                                            Text='<%#Eval("Country")%>'>
                                                                                                        </asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>

                                                                                                <asp:TemplateField Visible="false">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton ID="LnkLoading" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkLoading_Command">Select </asp:LinkButton>
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
                                                                        <div class="modal fade" id="loadingSearch1" role="dialog">
                                                                            <div class="modal-dialog">

                                                                                <!-- Modal content-->
                                                                                <div class="modal-content">
                                                                                    <div class="modal-header">
                                                                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                                                        <h4 class="modal-title">Next Port</h4>
                                                                                    </div>
                                                                                    <div class="modal-body">
                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="NextPrtLoading" OnTextChanged="NextPrtLoading_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                        <br />
                                                                                        <asp:GridView ID="NextPortGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="NextPortGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                                                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                            <Columns>


                                                                                                <asp:TemplateField HeaderText="PortCode" SortExpression="Id">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="Label45" runat="server"
                                                                                                            Text='<%#Eval("PortCode")%>'>
                                                                                                        </asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="PortName" SortExpression="Id">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="Label46" runat="server"
                                                                                                            Text='<%#Eval("PortName")%>'>
                                                                                                        </asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>

                                                                                                <asp:TemplateField HeaderText="Country" SortExpression="Id">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="Label47" runat="server"
                                                                                                            Text='<%#Eval("Country")%>'>
                                                                                                        </asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>

                                                                                                <asp:TemplateField Visible="false">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton ID="LnkLoading1" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkLoading1_Command">Select </asp:LinkButton>
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
                                                                        <div class="modal fade" id="loadingSearch2" role="dialog">
                                                                            <div class="modal-dialog">

                                                                                <!-- Modal content-->
                                                                                <div class="modal-content">
                                                                                    <div class="modal-header">
                                                                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                                                        <h4 class="modal-title">Last Port</h4>
                                                                                    </div>
                                                                                    <div class="modal-body">
                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txtlastprt" OnTextChanged="txtlastprt_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                        <br />
                                                                                        <asp:GridView ID="LastGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="LastGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                                                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                            <Columns>


                                                                                                <asp:TemplateField HeaderText="PortCode" SortExpression="Id">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="Label48" runat="server"
                                                                                                            Text='<%#Eval("PortCode")%>'>
                                                                                                        </asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="PortName" SortExpression="Id">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="Label49" runat="server"
                                                                                                            Text='<%#Eval("PortName")%>'>
                                                                                                        </asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>

                                                                                                <asp:TemplateField HeaderText="Country" SortExpression="Id">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="Label50" runat="server"
                                                                                                            Text='<%#Eval("Country")%>'>
                                                                                                        </asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>

                                                                                                <asp:TemplateField Visible="false">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton ID="LnkLoading2" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkLoading2_Command">Select </asp:LinkButton>
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
                                                                    </div>

                                                                    <div class="col-sm-4">
                                                                        <div id="Div7" runat="server" visible="false">
                                                                            <div class="modal fade" id="LOCATION" role="dialog">
                                                                                <div class="modal-dialog">

                                                                                    <!-- Modal content-->
                                                                                    <div class="modal-content">
                                                                                        <div class="modal-header">
                                                                                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                                                            <h4 class="modal-title">Release Location </h4>
                                                                                        </div>
                                                                                        <div class="modal-body">
                                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="LocationSearch" OnTextChanged="LocationSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                            <br />
                                                                                            <asp:GridView ID="LocationGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="LocationGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                                                                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                <Columns>


                                                                                                    <asp:TemplateField HeaderText="Code" SortExpression="Id">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="Label51" runat="server"
                                                                                                                Text='<%#Eval("Code")%>'>
                                                                                                            </asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="LocationCode" SortExpression="Id">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="Label52" runat="server"
                                                                                                                Text='<%#Eval("LocationCode")%>'>
                                                                                                            </asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>

                                                                                                    <asp:TemplateField HeaderText="Description" SortExpression="Id">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="Label53" runat="server"
                                                                                                                Text='<%#Eval("Description")%>'>
                                                                                                            </asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>

                                                                                                    <asp:TemplateField Visible="false">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:LinkButton ID="LnkLocation" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkLocation_Command">Select </asp:LinkButton>
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
                                                                            <br />
                                                                            <div class="modal fade" id="Receipt" role="dialog">
                                                                                <div class="modal-dialog">

                                                                                    <!-- Modal content-->
                                                                                    <div class="modal-content">
                                                                                        <div class="modal-header">
                                                                                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                                                            <h4 class="modal-title">Receipt Location</h4>
                                                                                        </div>
                                                                                        <div class="modal-body">
                                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ReceiptSearch" OnTextChanged="ReceiptSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                            <br />
                                                                                            <asp:GridView ID="ReceiptGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ReceiptGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                                                                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                <Columns>


                                                                                                    <asp:TemplateField HeaderText="Code" SortExpression="Id">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="Label54" runat="server"
                                                                                                                Text='<%#Eval("Code")%>'>
                                                                                                            </asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="LocationCode" SortExpression="Id">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="Label55" runat="server"
                                                                                                                Text='<%#Eval("LocationCode")%>'>
                                                                                                            </asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>

                                                                                                    <asp:TemplateField HeaderText="Description" SortExpression="Id">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="Label56" runat="server"
                                                                                                                Text='<%#Eval("Description")%>'>
                                                                                                            </asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>

                                                                                                    <asp:TemplateField Visible="false">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:LinkButton ID="LnkReceipt" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkReceipt_Command">Select </asp:LinkButton>
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
                                                                            <br />
                                                                            <div class="modal fade" id="Storage" role="dialog">
                                                                                <div class="modal-dialog">

                                                                                    <!-- Modal content-->
                                                                                    <div class="modal-content">
                                                                                        <div class="modal-header">
                                                                                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                                                            <h4 class="modal-title">Storage Location</h4>
                                                                                        </div>
                                                                                        <div class="modal-body">
                                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="StorageSearch" OnTextChanged="StorageSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                                            <br />
                                                                                            <asp:GridView ID="StorageGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="StorageGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                                                                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                <Columns>


                                                                                                    <asp:TemplateField HeaderText="Code" SortExpression="Id">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="Label57" runat="server"
                                                                                                                Text='<%#Eval("Code")%>'>
                                                                                                            </asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="LocationCode" SortExpression="Id">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="Label58" runat="server"
                                                                                                                Text='<%#Eval("StorageCode")%>'>
                                                                                                            </asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>

                                                                                                    <asp:TemplateField HeaderText="Description" SortExpression="Id">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="Label59" runat="server"
                                                                                                                Text='<%#Eval("Description")%>'>
                                                                                                            </asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>

                                                                                                    <asp:TemplateField Visible="false">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:LinkButton ID="LnkStorage" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkStorage_Command">Select </asp:LinkButton>
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
                                                                            <br />
                                                                        </div>
                                                                    </div>

                                                                </div>


                                                                <div class="row">
                                                                    <div class="col-sm-4">
                                                                        <div class="modal fade" id="ExploadingSearch" role="dialog">
                                                                            <div class="modal-dialog">

                                                                                <!-- Modal content-->
                                                                                <div class="modal-content">
                                                                                    <div class="modal-header">
                                                                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                                                        <h4 class="modal-title">Export Loading Port</h4>
                                                                                    </div>
                                                                                    <div class="modal-body">
                                                                                    </div>
                                                                                    <div class="modal-footer">
                                                                                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                    <div class="col-sm-4">
                                                                    </div>
                                                                    <div class="col-sm-4">
                                                                    </div>
                                                                </div>

                                                                <div class="row" runat="server" visible="false">
                                                                    <div class="col-sm-4">
                                                                    </div>
                                                                    <div class="col-sm-4">
                                                                    </div>


                                                                </div>
                                                                <br />
                                                                <br />

                                                            </div>
                                                        </div>
                                                        <br />
                                                        <br />
                                                        <div class="row">
                                                            <div class="col-sm-12">
                                                                <div id="gvAddrow">
                                                                </div>
                                                            </div>
                                                        </div>
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
                                        <%--  </div>   --%>

                                        <%-- <div role="tabpanel" class="tab-pane fade" id="Item">--%>
                                        <cc1:TabPanel ID="Item" CssClass="ajax__tab_header" runat="server" HeaderText="Item">

                                            <ContentTemplate>
                                                <asp:UpdatePanel ID="coitem" UpdateMode="Conditional" runat="server">
                                                    <ContentTemplate>

                                                        <div class="row">
                                                            <div class="col-sm-8">
                                                            </div>

                                                            <div class="col-sm-4">
                                                                <asp:Button ID="BtnAddNEWItem" runat="server" CssClass="btn btn-success btn-block" Visible="false" OnClick="BtnAddNEWItem_Click" Text="New Item" />
                                                                <br />
                                                            </div>
                                                        </div>

                                                        <div id="ItemDiv" runat="server">
                                                            <div class="flex justify-between gap-2 items-center mt-7">
                                                                <h2 class="text-lg sa700 leading-[18px] text-gray-800">Item Information
                                                                </h2>
                                                            </div>


                                                            <div class="grid grid-cols-1 md:grid-cols-2 gap-6 mt-4 mb-2">

                                                                <!-- Left Column -->
                                                                <div class="space-y-4">
                                                                    <!-- Item Code -->
                                                                    <div class="flex items-center gap-4">
                                                                        <label class="text-gray-500 text-sm font-medium w-48 flex-shrink-0">ITEM CODE</label>
                                                                        <div class="flex-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtInHouseItem" AutoPostBack="true" runat="server" TabIndex="106" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" ControlToValidate="TxtInHouseItem" ErrorMessage="Please Enter InHouse" Display="Dynamic" ValidationGroup="ItemMasterValidation5" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                             <asp:Label ID="ITEM_CASC_HSCODES" Visible="false" CssClass="hserror" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="Brown" runat="server"></asp:Label>
                                                                            <asp:Label ID="lblhserror" Visible="false" ForeColor="White" BackColor="Brown" runat="server"></asp:Label>
                                                                            <asp:Label ID="lbldhserror" Visible="false" ForeColor="Red" BackColor="#ffff00" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>

                                                                    <!-- HAWB NO -->
                                                                    <div class="flex items-center gap-4" style="display:none;">
                                                                        <label class="text-gray-500 text-sm font-medium w-48 flex-shrink-0">HAWB NO</label>
                                                                        <div class="flex-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txthawbl" AutoPostBack="true" runat="server" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txthawbl" ErrorMessage="Please Enter InHouse" Display="Dynamic" ValidationGroup="ItemMasterValidation5" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                            <asp:Label ID="Label60" Visible="false" ForeColor="Red" BackColor="#ffff00" runat="server"></asp:Label>
                                                                            <asp:Label ID="Label61" Visible="false" ForeColor="Red" BackColor="#ffff00" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>

                                                                    <!-- HS Code -->
                                                                    <%--  <div class="flex items-center gap-4">
                                                                        <label class="text-gray-500 text-sm font-medium w-48 flex-shrink-0">HS CODE</label>
                                                                        <div class="flex-1">
                                                                            <asp:Label ID="is_inpayment_controlled" runat="server" Style="background: yellow;" />
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtHSCodeItem" ValidationGroup="Item" OnTextChanged="TxtHSCodeItem_TextChanged" AutoPostBack="true" runat="server" TabIndex="107" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <cc1:AutoCompleteExtender ServiceMethod="GetHSCodeItem" MinimumPrefixLength="1" CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10" TargetControlID="TxtHSCodeItem" ID="AutoCompleteExtender12" runat="server" FirstRowSelected="true"></cc1:AutoCompleteExtender>
                                                                        </div>
                                                                    </div>

                                                                    <!-- Description -->
                                                                    <div class="flex items-start gap-4">
                                                                        <label class="text-gray-500 text-sm font-medium w-48 flex-shrink-0 pt-2">DESCRIPTION</label>
                                                                        <div class="flex-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtDescription" ValidationGroup="Item" OnTextChanged="TxtDescription_TextChanged" AutoPostBack="true" TextMode="MultiLine" runat="server" TabIndex="108" type="text" CssClass="w-full h-[80px] pt-3 px-4 bg-slate-100 resize-none rounded-md text-slate-950 text-sm font-medium outline-none border-none"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtDescription" ID="RegularExpressionValidator53" ValidationExpression="^[\s\S]{0,512}$" runat="server" ErrorMessage="Maximum 512 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" ControlToValidate="TxtDescription" ErrorMessage="Please Enter Description" Display="Dynamic" ValidationGroup="ItemMasterValidation5" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                            <asp:Label ID="LblCount" runat="server" TabIndex="5"></asp:Label>
                                                                        </div>
                                                                    </div>--%>


                                                                    <div class="flex items-center gap-4">
                                                                        <label class="text-gray-500 text-sm font-medium w-48 flex-shrink-0">HS Code</label>
                                                                        <asp:ImageButton ID="btnhscode1" CssClass="theme_searchIcon mb-35" runat="server" ImageUrl="images/searchBlue.png" Height="28" Width="28" />
                                                                        <div class="flex-1">
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
                                                                                ID="RequiredFieldValidator10"
                                                                                runat="server"
                                                                                ControlToValidate="TxtHSCodeItem"
                                                                                Font-Size="XX-Small"
                                                                                ForeColor="Red"
                                                                                ErrorMessage="Item --> Please Enter HS Code"
                                                                                ValidationGroup="Item">
                                                                            </asp:RequiredFieldValidator>


                                                                        </div>
                                                                    </div>

                                                                    <div class="flex items-center gap-4">
                                                                        <label class="text-gray-500 text-sm font-medium w-48 flex-shrink-0"></label>
                                                                        <div class="flex-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)"
                                                                                placeholder="Type Description"
                                                                                autocomplete="off"
                                                                                ID="TxtDescription"
                                                                                OnTextChanged="TxtDescription_TextChanged"
                                                                                AutoPostBack="true"
                                                                                ValidationGroup="Item"
                                                                                TextMode="MultiLine"
                                                                                runat="server"
                                                                                TabIndex="92"
                                                                                type="text"
                                                                                MaxLength="512"
                                                                                CssClass="w-full h-[323px] pt-3 px-4 bg-slate-100 resize-none rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none"
                                                                                Style="text-transform: uppercase;">
                                                                            </asp:TextBox>

                                                                            <asp:RequiredFieldValidator
                                                                                ID="RequiredFieldValidator11"
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
                                                                            <asp:LinkButton ID="lnkcopydesc" runat="server" CssClass="pull-right" OnClick="lnkcopydesc_Click" Text="Copy To All"></asp:LinkButton>

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

                              <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox24" OnTextChanged="HSCodeSearchItem_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>


                          </div>
                          <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                              <asp:GridView ID="GridView2"  OnPageIndexChanging="HSCodeGridItem_PageIndexChanging" PageSize="5" AllowPaging="True"  OnRowDataBound="GridView2_RowDataBound"  OnRowCommand="GridView2_RowCommand" DataKeyNames="Id" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
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
                                              <asp:LinkButton ID="lnkHSCodeItem" OnCommand="lnkHSCodeItem_Command" runat="server" CommandArgument='<%# Eval("Id") %>' >Select </asp:LinkButton>
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

                                                                    <asp:Label ID="LblCount" runat="server"></asp:Label>




                                                                    <!-- Country of Origin -->
                                                                    <div class="flex items-center gap-4">
                                                                        <label class="text-gray-500 text-sm font-medium w-48 flex-shrink-0 flex items-center gap-2">
                                                                            COO
            <asp:ImageButton ID="btncoorgin1" runat="server" ImageUrl="./images/circel-search.svg" Height="15" Width="15" />
                                                                        </label>
                                                                        <div class="flex-1">
                                                                            <div class="grid grid-cols-2 gap-3">
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="TxtCountryItem" OnTextChanged="TxtCountryItem_TextChanged" AutoPostBack="true" TabIndex="90" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txtcname" runat="server" Enabled="false" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            </div>
                                                                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender17" runat="server" CompletionInterval="100" FirstRowSelected="true" MinimumPrefixLength="1" DelimiterCharacters="1" ServiceMethod="GetCountryItem" ServicePath="~/InNonPayment.aspx" Enabled="True" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" TargetControlID="TxtCountryItem" />
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator46" runat="server" ControlToValidate="TxtCountryItem" ErrorMessage="Please Enter Country Of Origin" Display="Dynamic" ValidationGroup="ItemMasterValidation" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                            <cc1:ModalPopupExtender ID="popupcoorgin" runat="server" PopupControlID="pnlcoorgin" TargetControlID="btncoorgin1" OkControlID="btnYescoorgin" CancelControlID="btnNocoorgin" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
                                                                        </div>
                                                                    </div>

                                                                    <!-- Modal Popup Panel -->
                                                                    <asp:Panel ID="pnlcoorgin" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white" Style="display: none">
                                                                        <div class="header">

                                                                            <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Origin Country</p>
                                                                        </div>
                                                                        <div class="body">
                                                                            <asp:UpdatePanel ID="upcoorgin" runat="server" UpdateMode="Conditional">
                                                                                <ContentTemplate>
                                                                                    <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                        <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="CountrySearchItem" OnTextChanged="CountrySearchItem_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                                        <asp:GridView ID="CountryGridItem" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="CountryGridItem_PageIndexChanging" OnRowCommand="CountryGridItem_RowCommand" OnRowDataBound="CountryGridItem_RowDataBound" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" AutoGenerateColumns="false">
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
                                                                                                        <asp:LinkButton ID="lnkCountryItem" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="lnkCountryItem_Click" CssClass="duration-300 ease-in-out md:max-w-[200px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700">Select </asp:LinkButton>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                            </Columns>
                                                                                        </asp:GridView>
                                                                                    </div>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <div class="footer" align="right">
                                                                            <asp:Button ID="btnYescoorgin" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                            <asp:Button ID="btnNocoorgin" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px] mt-4 w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                        </div>
                                                                    </asp:Panel>
                                                                </div>

                                                                <div class="space-y-4">
                                                                    <!-- Currency (Unit Price Auto) -->
                                                                    <div class="flex items-center gap-4">
                                                                        <label class="text-gray-500 text-sm font-medium w-48 flex-shrink-0">CURRENCY (UNIT PRICE)</label>
                                                                        <div class="flex-1">
                                                                            <asp:DropDownList ID="DRPCurrency" CausesValidation="true" OnSelectedIndexChanged="DRPCurrency_SelectedIndexChanged" TabIndex="111" AutoPostBack="true" runat="server" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:DropDownList>
                                                                            <div class="flex items-center gap-2 mt-2">
                                                                                <asp:CheckBox ID="ChkUnitPrice" CausesValidation="true" OnCheckedChanged="ChkUnitPrice_CheckedChanged" AutoPostBack="true" runat="server" TabIndex="110" />
                                                                                <span class="text-gray-500 text-sm">Auto</span>
                                                                            </div>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" InitialValue="0" ControlToValidate="DRPCurrency" ErrorMessage="Item--->Choose Currency" Display="None" ValidationGroup="Item" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </div>

                                                                    <!-- Unit Price -->
                                                                    <div class="flex items-center gap-4">
                                                                        <label class="text-gray-500 text-sm font-medium w-48 flex-shrink-0">UNIT PRICE</label>
                                                                        <div class="flex-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtUnitPrice" Enabled="false" Text="0.00" runat="server" TabIndex="144" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        </div>
                                                                    </div>

                                                                    <!-- Exchange Rate -->
                                                                    <div class="flex items-center gap-4">
                                                                        <label class="text-gray-500 text-sm font-medium w-48 flex-shrink-0">EXCHANGE RATE</label>
                                                                        <div class="flex-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtExchangeRate" Enabled="false" Text="0.00" runat="server" TabIndex="112" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        </div>
                                                                    </div>

                                                                    <!-- Total Line Amount -->
                                                                    <div class="flex items-center gap-4">
                                                                        <label class="text-gray-500 text-sm font-medium w-48 flex-shrink-0">TOTAL LINE AMOUNT</label>
                                                                        <div class="flex-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" CausesValidation="true" OnTextChanged="TxtTotalLineAmount_TextChanged" onkeypress="return noAlphabets(event)" Text="0.00" AutoPostBack="true" runat="server" type="text" ID="TxtTotalLineAmount" TabIndex="113" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <asp:Label ID="Lbl3" Font-Size="9" Text="Total Line Amount" Visible="false" runat="server" Width="100"></asp:Label>
                                                                        </div>
                                                                    </div>

                                                                    <!-- CIF/FOB (SGD) -->
                                                                    <div class="flex items-center gap-4">
                                                                        <label class="text-gray-500 text-sm font-medium w-48 flex-shrink-0">CIF/FOB (SGD)</label>
                                                                        <div class="flex-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" onkeypress="return noAlphabets(event)" type="text" ID="TxtCIFFOB" Text="0.00" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <asp:Label Font-Size="9" Text="CIF/FOB (SGD)" ID="Label64" runat="server" Visible="false" Width="100"></asp:Label>
                                                                        </div>
                                                                    </div>

                                                                    <!-- Invoice Quantity -->
                                                                    <div class="flex items-center gap-4">
                                                                        <label class="text-gray-500 text-sm font-medium w-48 flex-shrink-0">INVOICE QUANTITY</label>
                                                                        <div class="flex-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" onkeypress="return noAlphabets(event)" runat="server" type="text" ID="TxtInvQTY2" OnTextChanged="TxtInvQTY2_TextChanged" AutoPostBack="true" Text="0.00" TabIndex="85" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <asp:Label Font-Size="9" Text="Invoice Quantity" ID="Label65" runat="server" Visible="false" Width="100"></asp:Label>
                                                                            <asp:Label runat="server" ID="lblinvqty" Visible="false" ForeColor="Red" BackColor="Yellow"></asp:Label>
                                                                        </div>
                                                                    </div>

                                                                    <!-- HS Quantity -->
                                                                    <div class="flex items-center gap-4">
                                                                        <label class="text-gray-500 text-sm font-medium w-48 flex-shrink-0">HS QUANTITY</label>
                                                                        <div class="flex-1">
                                                                            <div class="flex bg-slate-100 rounded-md h-10">
                                                                                <div class="flex-1">
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="TxtHSQty" Text="0.00" TabIndex="114" CssClass="w-full h-10 bg-slate-100 rounded-l-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                </div>
                                                                                <svg class="mt-3" width="1" height="16" viewBox="0 0 1 16" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                                    <line x1="0.5" y1="2.18561e-08" x2="0.499999" y2="16" stroke="#BCBCC4"></line>
                                                                                </svg>
                                                                                <div class="flex-1">
                                                                                    <asp:DropDownList ID="drpInvoiceUOM" runat="server" TabIndex="115" CssClass="w-full h-10 bg-slate-100 rounded-r-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:DropDownList>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                    <!-- Shipping Marks -->
                                                                    <div class="flex items-start gap-4">
                                                                        <label class="text-gray-500 text-sm font-medium w-48 flex-shrink-0 pt-2">SHIPPING MARKS</label>
                                                                        <div class="flex-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="txtShippingMarks1" Style="text-transform: uppercase" TextMode="MultiLine" TabIndex="116" CssClass="w-full h-20 pt-3 px-4 bg-slate-100 resize-none rounded-md text-slate-950 text-sm font-medium outline-none border-none"></asp:TextBox>
                                                                        </div>
                                                                    </div>

                                                                    <!-- Sum Exchange Rate -->
                                                                    <div class="flex items-center gap-4">
                                                                        <label class="text-gray-500 text-sm font-medium w-48 flex-shrink-0" id="sss" runat="server">SUM EXCHANGE RATE</label>
                                                                        <div class="flex-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="TxtSumExRate" Text="0.00" TabIndex="82" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div id="coi" runat="server" visible="false">
                                                                <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2" id="Vehicle" runat="server">
                                                                    <div class="md:max-w-[250px] w-full">
                                                                        <label class="text-gray-500 text-sm font-medium">Vehicle Type</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:DropDownList ID="DrpVehicleType" runat="server" TabIndex="101" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:DropDownList>
                                                                        </div>
                                                                    </div>

                                                                    <div class="md:max-w-[250px] w-full">
                                                                        <label class="text-gray-500 text-sm font-medium">Engine Capacity</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" Text="" ID="TextBox4" TabIndex="97" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        </div>
                                                                    </div>

                                                                    <div class="md:max-w-[250px] w-full">
                                                                        <label class="text-gray-500 text-sm font-medium">Engine Capacity</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:DropDownList ID="DrpVehicleCapacity" runat="server" TabIndex="98" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:DropDownList>
                                                                        </div>
                                                                    </div>

                                                                    <div class="md:max-w-[250px] w-full">
                                                                        <label class="text-gray-500 text-sm font-medium">Original Registration Date</label>
                                                                        <div class="relative mt-1">
                                                                            <input type='Date' id='OriginalRegDate' runat="server" class="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" />
                                                                            <span class="input-group-addon" style="display: none;">
                                                                                <span class="glyphicon glyphicon-calendar"></span>
                                                                            </span>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2" id="totDuticableQtyDiv" runat="server" visible="false">
                                                                    <div class="md:max-w-[250px] w-full" runat="server" visible="false">
                                                                        <label class="text-gray-500 text-sm font-medium">Original Registration Date</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ValidationGroup="Item" Text="0.00" ID="TxtTotalDutiableQuantity" TabIndex="97" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtTotalDutiableQuantity" ID="RegularExpressionValidator58" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                    </div>
                                                                    <div class="md:max-w-[250px] w-full" runat="server" visible="false">
                                                                        <label class="text-gray-500 text-sm font-medium">Original Registration Date</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:DropDownList ID="TDQUOM" runat="server" TabIndex="98" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                    <div class="md:max-w-[250px] w-full"></div>
                                                                    <div class="md:max-w-[250px] w-full"></div>
                                                                </div>
                                                                <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">

                                                                    <div class="flex items-start gap-4 flex-wrap">
                                                                        <div>
                                                                            <label class="text-gray-500 text-sm font-medium">Total Dutiable Quantity</label>
                                                                            <div class="flex bg-slate-100 rounded-md md:w-[250px] w-full mt-1 h-10">
                                                                                <div class="md:w-[125px] w-full">
                                                                                    <div class="relative w-full">
                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ValidationGroup="Item" Text="0.00" ID="txttotDutiableQty" TabIndex="97" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <svg class="mt-3" width="1" height="16" viewBox="0 0 1 16" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                                    <line x1="0.5" y1="2.18561e-08" x2="0.499999" y2="16" stroke="#BCBCC4"></line>
                                                                                </svg>
                                                                                <div class="md:w-[125px] w-full">
                                                                                    <div class="group relative">

                                                                                        <asp:DropDownList CssClass="drop font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt- px-4 focus:outline-none" ID="ddptotDutiableQty" runat="server" TabIndex="123"></asp:DropDownList>

                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>

                                                                    </div>

                                                                    <div class="md:max-w-[250px] w-full">
                                                                        <label class="text-gray-500 text-sm font-medium">Invoice Quantity</label>
                                                                        <div class="relative mt-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ValidationGroup="Item" Text="0.00" ID="TxtInvQty" OnTextChanged="TxtInvQty_TextChanged" AutoPostBack="true" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtInvQty" ID="RegularExpressionValidator59" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                    </div>

                                                                    <div class="flex items-start gap-4 flex-wrap">
                                                                        <div>
                                                                            <label class="text-gray-500 text-sm font-medium">Hs Quantity</label>
                                                                            <div class="flex bg-slate-100 rounded-md md:w-[250px] w-full mt-1 h-10">
                                                                                <div class="md:w-[125px] w-full">
                                                                                    <div class="relative w-full">
                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="Item" type="text" ID="TxtHSQuantity" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <svg class="mt-3" width="1" height="16" viewBox="0 0 1 16" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                                    <line x1="0.5" y1="2.18561e-08" x2="0.499999" y2="16" stroke="#BCBCC4"></line>
                                                                                </svg>
                                                                                <div class="md:w-[125px] w-full">
                                                                                    <div class="group relative">

                                                                                        <asp:DropDownList CssClass="drop font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt- px-4 focus:outline-none" ID="HSQTYUOM" runat="server" OnSelectedIndexChanged="HSQTYUOM_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtHSQuantity" ID="RegularExpressionValidator62" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>

                                                                    </div>
                                                                    <div class="md:max-w-[250px] w-full"></div>

                                                                </div>
                                                            </div>

                                                            <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                                <div class="md:max-w-[250px] w-full" id="AlcoholDiv" runat="server" visible="false">
                                                                    <label class="text-gray-500 text-sm font-medium">Alcohol Percentage</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="Item" type="text" Text="0.00" ID="txtAlcoholPer" TabIndex="99" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium"></label>
                                                                    <div class="relative mt-1">
                                                                        <asp:Button ID="btnprev" CssClass="previous" Enabled="false" Width="50px" runat="server" class="btn btn-info btn-lg" OnClick="btnprev_Click" Text="<<" />
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" runat="server" ID="itemno" Font-Bold="true" Width="100px" Enabled="false"></asp:TextBox>
                                                                        <asp:Button ID="btnnxt" CssClass="previous" Enabled="false" Width="50px" runat="server" class="btn btn-info btn-lg" OnClick="btnnxt_Click" Text=">>" />
                                                                    </div>
                                                                </div>
                                                                <div class="md:max-w-[250px] w-full"></div>
                                                                <div class="md:max-w-[250px] w-full"></div>
                                                            </div>

                                                            <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                            </div>

                                                            <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2" id="OptionalCharges" visible="false" runat="server">
                                                                <div class="flex items-start gap-4 flex-wrap">
                                                                    <div>
                                                                        <label class="text-gray-500 text-sm font-medium">Optional Charges</label>
                                                                        <div class="flex bg-slate-100 rounded-md md:w-[250px] w-full mt-1 h-10">
                                                                            <div class="md:w-[125px] w-full">
                                                                                <div class="relative w-full">
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" Text="0.00" ID="TxtOptionalPrice" OnTextChanged="TxtOptionalPrice_TextChanged" AutoPostBack="true" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <svg class="mt-3" width="1" height="16" viewBox="0 0 1 16" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                                <line x1="0.5" y1="2.18561e-08" x2="0.499999" y2="16" stroke="#BCBCC4"></line>
                                                                            </svg>
                                                                            <div class="md:w-[125px] w-full">
                                                                                <div class="group relative">
                                                                                    <asp:DropDownList ID="DrpOptionalUom" CausesValidation="true" OnSelectedIndexChanged="DrpOptionalUom_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:DropDownList>
                                                                                    <asp:RequiredFieldValidator BackColor="Red" InitialValue="0" ID="RequiredFieldValidator54" runat="server" ControlToValidate="DRPCurrency" Display="None" ErrorMessage="Item --> Plase Select Currency info" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                </div>
                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Details</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtOptionalExchageRate" Enabled="false" Text="0.00" runat="server" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator BackColor="Red" InitialValue="0.00" ID="RequiredFieldValidator6" runat="server" ControlToValidate="TxtExchangeRate" Display="None" ErrorMessage="Item --> Plase Enter Amount" ValidationGroup="Item"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="md:max-w-[250px] w-full">
                                                                    <label class="text-gray-500 text-sm font-medium">Details</label>
                                                                    <div class="relative mt-1">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="TxtOptionalSumExRate" TabIndex="106" Text="0.00" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="md:max-w-[250px] w-full"></div>
                                                            </div>



                                                            <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2" id="pack" runat="server" visible="false">

                                                                <div class="md:max-w-[250px] w-full">
                                                                    <div class="relative mt-1">
                                                                        <asp:CheckBox ID="ChkPackInfo" OnCheckedChanged="ChkPackInfo_CheckedChanged" runat="server" AutoPostBack="true" Text="Packing Info" Width="150" Style="text-transform: lowercase" />
                                                                    </div>
                                                                </div>

                                                                <div class="md:max-w-[250px] w-full">
                                                                    <div class="relative mt-1">
                                                                        <asp:CheckBox ID="Chkitemcasc" runat="server" OnCheckedChanged="Chkitemcasc_CheckedChanged" AutoPostBack="true" Text="Item CASC" Width="150" Style="text-transform: lowercase" />
                                                                    </div>
                                                                </div>

                                                                <div class="md:max-w-[250px] w-full">
                                                                    <div class="relative mt-1">
                                                                        <asp:CheckBox ID="ChkTariff" runat="server" OnCheckedChanged="ChkTariff_CheckedChanged" AutoPostBack="true" Text="Tariff" Width="150" Style="text-transform: lowercase" />
                                                                    </div>
                                                                </div>

                                                                <div class="md:max-w-[250px] w-full">
                                                                    <div class="relative mt-1">
                                                                        <asp:CheckBox ID="Chklot" runat="server" OnCheckedChanged="Chklot_CheckedChanged" AutoPostBack="true" Text="LOT Identification" Width="150" Style="text-transform: lowercase" />
                                                                    </div>
                                                                </div>

                                                            </div>

                                                            <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2" id="PackingInfo" runat="server" visible="false">
                                                                <div class="flex items-start gap-4 flex-wrap">
                                                                    <div>
                                                                        <label class="text-gray-500 text-sm font-medium">Outer Pack Qty </label>
                                                                        <div class="flex bg-slate-100 rounded-md md:w-[250px] w-full mt-1 h-10">
                                                                            <div class="md:w-[125px] w-full">
                                                                                <div class="relative w-full">
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="Item" Text="0" type="text" ID="TxtOPQty" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <svg class="mt-3" width="1" height="16" viewBox="0 0 1 16" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                                <line x1="0.5" y1="2.18561e-08" x2="0.499999" y2="16" stroke="#BCBCC4"></line>
                                                                            </svg>
                                                                            <div class="md:w-[125px] w-full">
                                                                                <div class="group relative">
                                                                                    <asp:DropDownList ID="DRPOPQUOM" runat="server" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:DropDownList>
                                                                                    <br />
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtOPQty" ID="RegularExpressionValidator64" ValidationExpression="^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 8 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                </div>

                                                                <div class="flex items-start gap-4 flex-wrap">
                                                                    <div>
                                                                        <label class="text-gray-500 text-sm font-medium">In Pack Qty</label>
                                                                        <div class="flex bg-slate-100 rounded-md md:w-[250px] w-full mt-1 h-10">
                                                                            <div class="md:w-[125px] w-full">
                                                                                <div class="relative w-full">
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="Item" Text="0" type="text" ID="TxtIPQty" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <svg class="mt-3" width="1" height="16" viewBox="0 0 1 16" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                                <line x1="0.5" y1="2.18561e-08" x2="0.499999" y2="16" stroke="#BCBCC4"></line>
                                                                            </svg>
                                                                            <div class="md:w-[125px] w-full">
                                                                                <div class="group relative">
                                                                                    <asp:DropDownList ID="DRPIPQUOM" runat="server" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:DropDownList>
                                                                                    <br />
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtIPQty" ID="RegularExpressionValidator63" ValidationExpression="^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 8 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                </div>

                                                                <div class="flex items-start gap-4 flex-wrap">
                                                                    <div>
                                                                        <label class="text-gray-500 text-sm font-medium">Inner Pack Qty</label>
                                                                        <div class="flex bg-slate-100 rounded-md md:w-[250px] w-full mt-1 h-10">
                                                                            <div class="md:w-[125px] w-full">
                                                                                <div class="relative w-full">
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="Item" Text="0" type="text" ID="TxtINPQty" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <svg class="mt-3" width="1" height="16" viewBox="0 0 1 16" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                                <line x1="0.5" y1="2.18561e-08" x2="0.499999" y2="16" stroke="#BCBCC4"></line>
                                                                            </svg>
                                                                            <div class="md:w-[125px] w-full">
                                                                                <div class="group relative">
                                                                                    <asp:DropDownList ID="DRPINNPQUOM" runat="server" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:DropDownList>
                                                                                    <br />
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtINPQty" ID="RegularExpressionValidator65" ValidationExpression="^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 8 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                </div>

                                                                <div class="flex items-start gap-4 flex-wrap">
                                                                    <div>
                                                                        <label class="text-gray-500 text-sm font-medium">Inmost Pack Qty</label>
                                                                        <div class="flex bg-slate-100 rounded-md md:w-[250px] w-full mt-1 h-10">
                                                                            <div class="md:w-[125px] w-full">
                                                                                <div class="relative w-full">
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="Item" Text="0" type="text" ID="TxtIMPQty" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <svg class="mt-3" width="1" height="16" viewBox="0 0 1 16" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                                <line x1="0.5" y1="2.18561e-08" x2="0.499999" y2="16" stroke="#BCBCC4"></line>
                                                                            </svg>
                                                                            <div class="md:w-[125px] w-full">
                                                                                <div class="group relative">
                                                                                    <asp:DropDownList ID="DRPIMPQUOM" runat="server" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:DropDownList>
                                                                                    <br />
                                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtIMPQty" ID="RegularExpressionValidator66" ValidationExpression="^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 8 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                </div>

                                                            </div>

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
                                                                                    <asp:GridView ID="InhouseGridItem" OnPageIndexChanging="InhouseGridItem_PageIndexChanging" PageSize="5" AllowPaging="True" DataKeyNames="Id" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                                                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                        <Columns>


                                                                                            <asp:TemplateField HeaderText="InhouseCode" SortExpression="Id">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="Label66" runat="server"
                                                                                                        Text='<%#Eval("InhouseCode")%>'>
                                                                                                    </asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="HSCode" SortExpression="Id">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="Label67" runat="server"
                                                                                                        Text='<%#Eval("HSCode")%>'>
                                                                                                    </asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>

                                                                                            <asp:TemplateField HeaderText="Description" SortExpression="Id">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="Label68" runat="server"
                                                                                                        Text='<%#Eval("Description")%>'>
                                                                                                    </asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Brand" SortExpression="Id">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="Label69" runat="server"
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
                                                                                            <asp:TemplateField Visible="false">
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
                                                                                    <asp:GridView ID="HSCodeGridItem" OnPageIndexChanging="HSCodeGridItem_PageIndexChanging" PageSize="5" AllowPaging="True" DataKeyNames="Id" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                                                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                        <Columns>



                                                                                            <asp:TemplateField HeaderText="HSCode" SortExpression="Id">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="Label70" runat="server"
                                                                                                        Text='<%#Eval("HSCode")%>'>
                                                                                                    </asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>

                                                                                            <asp:TemplateField HeaderText="Description" SortExpression="Id">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="Label71" runat="server"
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
                                                                                <div class="modal-footer">
                                                                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                    </div>

                                                                    <div class="row">
                                                                        <div class="col-sm-6" id="SerNumDiv" runat="server" visible="false">

                                                                            <p>Serial Number</p>
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" Width="240" type="text" ID="TxtSerialNo" TabIndex="74"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server" ControlToValidate="TxtSerialNo" ErrorMessage="Please Enter Serial No"
                                                                                Display="Dynamic" ValidationGroup="ItemMasterValidation" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                            <br />
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
                                                            <div>
                                                                <!-- Header - Full Width -->
                                                                <div class="bg-gray-700 text-center rounded-full py-2 mt-7 mb-4  w-full">
                                                                    <span class="text-white text-sm font-semibold tracking-wide">CERTIFICATE OF ORIGIN</span>
                                                                </div>

                                                                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="cotype" />
                                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <div class="grid grid-cols-3 gap-6">
                                                                            <!-- Left Column -->
                                                                            <div class="space-y-4">
                                                                                <!-- Certificate Item Quantity -->
                                                                                <div>
                                                                                    <label class="text-gray-500 text-sm font-medium block mb-2">CERTIFICATE ITEM QUANTITY</label>
                                                                                    <div class="flex bg-slate-100 rounded-md h-10">
                                                                                        <div class="flex-1">
                                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtCerITEMQty" runat="server" Text="0.00" TabIndex="117" type="text" CssClass="w-full h-10 bg-slate-100 rounded-l-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                        </div>
                                                                                        <svg class="mt-3" width="1" height="16" viewBox="0 0 1 16" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                                            <line x1="0.5" y1="2.18561e-08" x2="0.499999" y2="16" stroke="#BCBCC4"></line>
                                                                                        </svg>
                                                                                        <div class="flex-1">
                                                                                            <asp:DropDownList CssClass="w-full h-10 bg-slate-100 rounded-r-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" ID="DrpCerITemUOM" runat="server" TabIndex="118" AppendDataBoundItems="true"></asp:DropDownList>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>

                                                                                <!-- Manufacturing Cost Date -->
                                                                                <div>
                                                                                    <label class="text-gray-500 text-sm font-medium block mb-2">MANUFACTURING COST DATE</label>
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtManuDate" runat="server" AutoPostBack="true" TabIndex="119" type="text" OnTextChanged="TxtManuDate_TextChanged" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                    <cc1:CalendarExtender ID="CalendarExtender3" PopupButtonID="imgPopup" CssClass="cal_Theme1" runat="server" TargetControlID="TxtManuDate" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"></cc1:CalendarExtender>
                                                                                </div>

                                                                                <!-- Hidden/Conditional Fields -->
                                                                                <div id="itemvalue" visible="false" runat="server">
                                                                                    <label class="text-gray-500 text-sm font-medium block mb-2">CIF/FOB Item Value On Certificate</label>
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txtcifitemvalue" OnTextChanged="txtcifitemvalue_TextChanged" AutoPostBack="true" runat="server" TabIndex="120" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                </div>

                                                                                <div id="txttile" visible="false" runat="server">
                                                                                    <label class="text-gray-500 text-sm font-medium block mb-2">Textile Quota Quantity</label>
                                                                                    <div class="flex bg-slate-100 rounded-md h-10">
                                                                                        <div class="flex-1">
                                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtTextileQty" Text="0.00" runat="server" TabIndex="122" type="text" CssClass="w-full h-10 bg-slate-100 rounded-l-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                        </div>
                                                                                        <svg class="mt-3" width="1" height="16" viewBox="0 0 1 16" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                                            <line x1="0.5" y1="2.18561e-08" x2="0.499999" y2="16" stroke="#BCBCC4"></line>
                                                                                        </svg>
                                                                                        <div class="flex-1">
                                                                                            <asp:DropDownList ID="DrpTextQoutoQTYUOM" runat="server" TabIndex="94" AppendDataBoundItems="true" CssClass="w-full h-10 bg-slate-100 rounded-r-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:DropDownList>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>

                                                                                <div>
                                                                                    <label class="text-gray-500 text-sm font-medium block mb-2">Textile Category</label>
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtTextileCat" runat="server" TabIndex="121" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                </div>

                                                                                <div id="coinvno" runat="server">
                                                                                    <label class="text-gray-500 text-sm font-medium block mb-2">Invoice Number</label>
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txtinvno" MaxLength="10" runat="server" TabIndex="123" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                </div>
                                                                            </div>

                                                                            <!-- Middle Column -->
                                                                            <div class="space-y-4">
                                                                                <!-- Invoice Date -->
                                                                                <div>
                                                                                    <label class="text-gray-500 text-sm font-medium block mb-2">INVOICE DATE</label>
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtInvDate" runat="server" AutoPostBack="true" TabIndex="128" type="text" OnTextChanged="TxtInvDate_TextChanged" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                    <cc1:CalendarExtender ID="CalendarExtender1" PopupButtonID="imgPopup" CssClass="cal_Theme1" runat="server" TargetControlID="TxtInvDate" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"></cc1:CalendarExtender>
                                                                                </div>

                                                                                <!-- HS Code on Certificate -->
                                                                                <div>
                                                                                    <label class="text-gray-500 text-sm font-medium block mb-2">HS CODE ON CERTIFICATE</label>
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtHSCodeCer" MaxLength="10" runat="server" TabIndex="129" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                </div>

                                                                                <!-- Percentage Content of Origin Criterion -->
                                                                                <div>
                                                                                    <label class="text-gray-500 text-sm font-medium block mb-2">PERCENTAGE CONTENT OF ORIGIN CRITERION</label>
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtPerOrgCir" MaxLength="3" runat="server" TabIndex="130" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                </div>

                                                                                <!-- Origin Criterion Fields -->
                                                                                <div id="coorgincriterien" runat="server" visible="false" class="space-y-4">
                                                                                    <div>
                                                                                        <label class="text-gray-500 text-sm font-medium block mb-2">ORIGIN CRITERION 1</label>
                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txtcreteriencode" MaxLength="10" runat="server" TabIndex="124" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                    </div>
                                                                                    <div>
                                                                                        <label class="text-gray-500 text-sm font-medium block mb-2">ORIGIN CRITERION 2</label>
                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txtcodesc1" MaxLength="10" runat="server" TabIndex="125" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                    </div>
                                                                                    <div>
                                                                                        <label class="text-gray-500 text-sm font-medium block mb-2">ORIGIN CRITERION 3</label>
                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txtcodesc2" MaxLength="10" runat="server" TabIndex="126" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                    </div>
                                                                                    <div>
                                                                                        <label class="text-gray-500 text-sm font-medium block mb-2">ORIGIN CRITERION 4</label>
                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txtcodesc3" MaxLength="10" runat="server" TabIndex="127" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                            </div>

                                                                            <!-- Right Column - Item Certificate Description -->
                                                                            <div>
                                                                                <label class="text-gray-500 text-sm font-medium block mb-2">ITEM CERTIFICATE DESCRIPTION</label>
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtCerDes" OnTextChanged="TxtCerDes_TextChanged" TextMode="MultiLine" Style="text-transform: uppercase" runat="server" TabIndex="131" type="text" CssClass="w-full h-[323px] pt-3 px-4 bg-slate-100 resize-none rounded-md text-slate-950 text-sm font-medium outline-none border-none" ></asp:TextBox>
                                                                                <p runat="server" visible="false" id="certificatedesc">0 characters</p>
                                                                                <asp:Label ID="LbldescCount" runat="server"></asp:Label>
                                                                            </div>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>

                                                            <div class="row">
                                                                <!-- Importer Search -->

                                                                <div class="col-sm-8">
                                                                </div>
                                                                <div class="col-sm-4">
                                                                    <asp:Button ID="BtnItemAdd" CssClass="btn btn-block btn-success" ValidationGroup="Validation2" runat="server" Visible="false" Text="Add Item" OnClick="BtnItemAdd_Click" />

                                                                </div>

                                                                <div class="col-sm-8">
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


                                                        <div class="flex justify-between gap-4 md:flex-nowrap flex-wrap mt-6 mb-6">
                                                            <asp:Button ID="btnprevitem" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" runat="server" class="btn btn-info btn-lg" OnClick="btnprevitem_Click" Text="Previous" TabIndex="174" />
                                                            <div class="flex gap-4 flex-wrap md:flex-nowrap md:max-w-[260px] w-full">
                                                                <asp:Button ID="btnresetitem" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" runat="server" class="btn btn-info btn-lg" OnClick="btnresetitem_Click" Text="Reset" TabIndex="176" />
                                                              

                                                            </div>
                                                            <asp:Button ID="btnnextitem" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" runat="server" class="btn btn-info btn-lg" OnClick="btnnextitem_Click" Text="Next" TabIndex="177" />

                                                        </div>



                                                        <div id="ItemAddGrid" runat="server">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="AddItemSearch" OnTextChanged="AddItemSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                            <br />
                                                            <asp:GridView ID="AddItemGrid" Font-Size="10" OnRowDeleting="AddItemGrid_RowDeleting" PageSize="50" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="AddItemGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Delete">
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
                                                                            <asp:Label ID="Label72" runat="server"
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


                                                                    <asp:TemplateField HeaderText="Currency" SortExpression="Id">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="UnitPriceCurrency" runat="server"
                                                                                Text='<%#Eval("UnitPriceCurrency")%>'>
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

                                                                    <asp:TemplateField HeaderText="HS UOM" SortExpression="Id">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="HSUOM" runat="server"
                                                                                Text='<%#Eval("HSUOM")%>'>
                                                                            </asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="TOT LINE AMOUNT" SortExpression="Id">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="TotalLineAmount" runat="server"
                                                                                Text='<%#Eval("TotalLineAmount")%>'>
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


                                                                    <asp:TemplateField HeaderText="Cert Item Qty" SortExpression="Id">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="CertItemQty" runat="server"
                                                                                Text='<%#Eval("CerItemQty")%>'>
                                                                            </asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Cert Item UOM" SortExpression="Id">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="CerItemUOM" runat="server"
                                                                                Text='<%#Eval("CerItemUOM")%>'>
                                                                            </asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Cert Item Value" SortExpression="Id">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="CertItemValue" runat="server"
                                                                                Text='<%#Eval("ItemValue")%>'>
                                                                            </asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>





                                                                </Columns>
                                                                <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </div>

                                                          <div class="flex justify-end gap-4">
                                                          <asp:Button ID="btnsaveitem" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] bg-opacity-10 border hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-[#0560FD] text-center rounded-md text-sm sa700" runat="server" class="btn btn-info btn-lg" ValidationGroup="Item" OnClick="BtnItemAdd_Click" Text="+ Add Item" TabIndex="175" />
                                                              </div>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </ContentTemplate>
                                        </cc1:TabPanel>
                                        <%--    </div>--%>
                                        <%--<div role="tabpanel" class="tab-pane fade" id="CPC" runat="server" visible="false">--%>
                                        <cc1:TabPanel ID="CPC" CssClass="ajax__tab_header" Visible="false" runat="server" HeaderText="CPC">

                                            <ContentTemplate>
                                                <asp:UpdatePanel ID="cocpc" UpdateMode="Conditional" runat="server">
                                                    <ContentTemplate>

                                                        <div class="row">
                                                            <div class="col-sm-12">

                                                                <div class="row">
                                                                    <div class="col-sm-2">
                                                                        <asp:CheckBox ID="chkaeo" OnCheckedChanged="chkaeo_CheckedChanged" AutoPostBack="true" runat="server" Text="AEO" Checked="false" />
                                                                    </div>
                                                                    <div class="col-sm-10" id="AEO" runat="server">
                                                                        <asp:Button ID="BtnAEO" runat="server" OnClick="BtnAEO_Click" Text="Add Row" />
                                                                        <br />
                                                                        <br />
                                                                        <asp:GridView ID="AEOGrid" OnRowDeleting="AEOGrid_RowDeleting" CssClass="table table-striped table-bordered table-hover" runat="server" ShowFooter="true" AutoGenerateColumns="false">

                                                                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                            <Columns>

                                                                                <asp:BoundField DataField="RowNumber" HeaderText="Seq." />

                                                                                <asp:TemplateField HeaderText="Processing Code1">

                                                                                    <ItemTemplate>

                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox1" runat="server"></asp:TextBox>

                                                                                    </ItemTemplate>

                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="Processing Code2">

                                                                                    <ItemTemplate>

                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox2" runat="server"></asp:TextBox>

                                                                                    </ItemTemplate>

                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="Processing Code3">

                                                                                    <ItemTemplate>

                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox3" runat="server"></asp:TextBox>

                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Delete">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton data-toggle="modal" data-target='<%#"#"+DataBinder.Eval(Container.DataItem,"RowNumber")%>' Width="11" Height="11" ID="LinkButton1" runat="server"><i class='fa fa-trash' style="color:red"></i></asp:LinkButton>

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
                                                                        <asp:CheckBox ID="chkcwc" OnCheckedChanged="chkcwc_CheckedChanged" AutoPostBack="true" runat="server" Text="STS" Checked="false" />
                                                                    </div>
                                                                    <div class="col-sm-10" id="CWC" runat="server">
                                                                        <asp:Button ID="BtnCWC" runat="server" OnClick="BtnCWC_Click" Text="Add Row" />
                                                                        <br />
                                                                        <br />
                                                                        <asp:GridView ID="CWCGrid" OnRowDeleting="CWCGrid_RowDeleting" CssClass="table table-striped table-bordered table-hover" runat="server" ShowFooter="true" AutoGenerateColumns="false">

                                                                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                            <Columns>

                                                                                <asp:BoundField DataField="RowNumber" HeaderText="Seq." />

                                                                                <asp:TemplateField HeaderText="Processing Code1">

                                                                                    <ItemTemplate>

                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox5" runat="server"></asp:TextBox>

                                                                                    </ItemTemplate>

                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="Processing Code2">

                                                                                    <ItemTemplate>

                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox6" runat="server"></asp:TextBox>

                                                                                    </ItemTemplate>

                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="Processing Code3">

                                                                                    <ItemTemplate>

                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox7" runat="server"></asp:TextBox>

                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Delete">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton data-toggle="modal" data-target='<%#"#"+DataBinder.Eval(Container.DataItem,"RowNumber")%>' Width="11" Height="11" ID="LinkButton2" runat="server"><i class='fa fa-trash' style="color:red"></i></asp:LinkButton>

                                                                                        <div class="modal fade" id='<%#Eval("RowNumber")%>' role="dialog">
                                                                                            <div class="modal-dialog">

                                                                                                <!-- Modal content-->
                                                                                                <div class="modal-content" style="width: 50%; left: 30%; top: 200px;">
                                                                                                    <div class="modal-header">
                                                                                                    </div>
                                                                                                    <div class="modal-footer">
                                                                                                        <h4 class="modal-title">Are you sure to delete this Record?</h4>
                                                                                                        <asp:Button ID="Button3" CommandName="delete" runat="server" OnClientClick='<%# DataBinder.Eval(Container.DataItem, "RowNumber", "javascript:return deletefunction(\"{0}\");")%> ' CssClass="btn btn-theme03 modal-add" Text="Yes"></asp:Button>
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
                                                                        <asp:CheckBox ID="ChkSea1" OnCheckedChanged="ChkSea_CheckedChanged" AutoPostBack="true" runat="server" Text="SEA STORE" Checked="false" />
                                                                    </div>
                                                                    <div class="col-sm-10" id="SEA" runat="server">
                                                                        <asp:Button ID="btnSeaStr" runat="server" OnClick="btnSeaStr_Click" Text="Add Row" />
                                                                        <br />
                                                                        <br />
                                                                        <asp:GridView ID="SeaGrid" OnRowDeleting="SeaGrid_RowDeleting" CssClass="table table-striped table-bordered table-hover" runat="server" ShowFooter="true" AutoGenerateColumns="false">

                                                                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                            <Columns>

                                                                                <asp:BoundField DataField="RowNumber" HeaderText="Seq." />

                                                                                <asp:TemplateField HeaderText="No. of Crew">

                                                                                    <ItemTemplate>

                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox8" runat="server"></asp:TextBox>

                                                                                    </ItemTemplate>

                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="Voyage Duration">

                                                                                    <ItemTemplate>

                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox9" runat="server"></asp:TextBox>

                                                                                    </ItemTemplate>

                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="Processing Code3">

                                                                                    <ItemTemplate>

                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox10" runat="server"></asp:TextBox>

                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Delete">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton data-toggle="modal" data-target='<%#"#"+DataBinder.Eval(Container.DataItem,"RowNumber")%>' Width="11" Height="11" ID="LinkButton3" runat="server"><i class='fa fa-trash' style="color:red"></i></asp:LinkButton>

                                                                                        <div class="modal fade" id='<%#Eval("RowNumber")%>' role="dialog">
                                                                                            <div class="modal-dialog">

                                                                                                <!-- Modal content-->
                                                                                                <div class="modal-content" style="width: 50%; left: 30%; top: 200px;">
                                                                                                    <div class="modal-header">
                                                                                                    </div>
                                                                                                    <div class="modal-footer">
                                                                                                        <h4 class="modal-title">Are you sure to delete this Record?</h4>
                                                                                                        <asp:Button ID="Button4" CommandName="delete" runat="server" OnClientClick='<%# DataBinder.Eval(Container.DataItem, "RowNumber", "javascript:return deletefunction(\"{0}\");")%> ' CssClass="btn btn-theme03 modal-add" Text="Yes"></asp:Button>
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
                                                                        <asp:CheckBox ID="chkcnb" runat="server" Text="CNB" Checked="false" />
                                                                    </div>
                                                                    <div class="col-sm-10">
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <center>
                                                            <div class="btn-group btn-group-lg">
                                                                <asp:Button ID="btnprevcpc" CssClass="nn" runat="server" class="btn btn-info btn-lg" OnClick="btnprevcpc_Click" Text="Previous" />
                                                                <asp:Button ID="btnsavecpc" CssClass="nn" runat="server" class="btn btn-info btn-lg" OnClick="btnsavecpc_Click" Text="Save" />
                                                                <asp:Button ID="btnresetcpc" CssClass="nn" runat="server" class="btn btn-info btn-lg" OnClick="btnresetcpc_Click" Text="Reset" Visible="false" />
                                                                <asp:Button ID="btnnextcpc" CssClass="nn" runat="server" class="btn btn-info btn-lg" OnClick="btnnextcpc_Click" Text="Next" />

                                                            </div>
                                                        </center>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                            </ContentTemplate>
                                        </cc1:TabPanel>
                                        <%-- </div>--%>
                                        <%--<div role="tabpanel" class="tab-pane fade" id="Summary">--%>
                                        <cc1:TabPanel ID="Summary" CssClass="ajax__tab_header" runat="server" HeaderText="Summary">

                                            <ContentTemplate>
                                                <asp:UpdatePanel ID="cosummery" UpdateMode="Conditional" runat="server">
                                                    <ContentTemplate>

                                                        <div class="bg-gray-700 text-center rounded-full py-2 mt-7 mb-4 w-full">
                                                            <span class="text-white text-sm font-semibold tracking-wide">Summary
                                                            </span>
                                                        </div>

                                                        <div class="space-y-4">
                                                            <!-- First Row -->
                                                            <div class="grid grid-cols-4 gap-8">
                                                                <div>
                                                                    <label class="text-gray-500 text-sm font-medium block mb-2">Number of items</label>
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" Enabled="false" Text="0.00" type="text" ID="txtnoofitm" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                </div>
                                                                <div>
                                                                    <label class="text-gray-500 text-sm font-medium block mb-2">Sum of itemamount</label>
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" Enabled="false" Text="0.00" type="text" ID="txtitmAmt" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                </div>

                                                                 <div>
     <label class="text-gray-500 text-sm font-medium block mb-2">Item value on certificate</label>
     <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" Enabled="false" Text="0.00" type="text" ID="txtitemvaluecert" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
 </div>


                                                                <div style="display:none;" >
    <label class="text-gray-500 text-sm font-medium">Certificate Additional Information  Details</label>
    <div class="relative mt-1">
        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" Enabled="false" Text="0.00" type="text" ID="txtcifVal" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
    </div>
</div>

<div >
    <label class="text-gray-500 text-sm font-medium"> Cross Reference  </label>
    <div class="relative mt-1">
        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="TxtGrossReference" Style="text-transform: uppercase" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
    </div>
</div>
                                                            </div>

                                                           

                                                          
                                                        </div>
                                                        </div>


                                                        <div class="flex flex-wrap md:flex-nowrap gap-6 mt-4 mb-2">



  

    <div class="w-full md:w-1/3">
        <asp:Button ID="BtnPPN" OnClick="BtnPPN_Click" CssClass="relative mt-1 w-full h-10 bg-[#0560FD] bg-opacity-5 rounded-md flex items-center text-[#0560FD] text-sm font-medium outline-none border-none sa700 px-4" TabIndex="195" runat="server" Text="Append Previous Permit NO" />
    </div>


  



</div>


                                                        <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                            <div class="md:max-w-[1000px] w-full">
                                                                <label class="text-gray-500 text-sm font-medium">Trader's Remarks (will be Submitted to Singapore Customs)</label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txttrdremrk" OnTextChanged="txttrdremrk_TextChanged" TextMode="MultiLine" Style="text-transform: uppercase" runat="server" AutoPostBack="true" Height="70" Width="100%" TabIndex="135" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>


                                                                     <asp:Label ID="lblceraddcunt"  ForeColor="Navy" Font-Bold="true" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                            <div class="md:max-w-[1000px] w-full">
                                                               
                                                                <label class="text-gray-500 text-sm font-medium">Internal Reference</label>
                                                                <div class="relative mt-1">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txtinternal" runat="server" Height="70" Width="100%" TabIndex="136" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="bg-gray-700 text-center rounded-full py-2 mt-7 w-full">
                                                            <span class="text-white text-sm font-semibold tracking-wide">DECLARATION SUMMARY
                                                            </span>
                                                        </div>

                                                        <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                            <div class="md:max-w-[1000px] w-full">
                                                                <label class="text-gray-500 text-sm font-medium">Exporter</label>
                                                                <div class="relative mt-1">
                                                                    <asp:Label ID="lblimporterparty" runat="server" Width="80%" Text="" Font-Size="Medium" Font-Bold="true"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                            <div class="md:max-w-[500px] w-full">
                                                                <label class="text-gray-500 text-sm font-medium">Certificate Type</label>
                                                                <div class="relative mt-1">
                                                                    <asp:Label ID="lbloblval" runat="server" Width="80%" Text="" Font-Size="Medium" Font-Bold="true"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="md:max-w-[500px] w-full">
                                                                <label class="text-gray-500 text-sm font-medium">CO Type</label>
                                                                <div class="relative mt-1">
                                                                    <asp:Label ID="lblhblValue" runat="server" Width="80%" Font-Size="Medium" Font-Bold="true"></asp:Label>
                                                                </div>
                                                            </div>

                                                        </div>

                                                        <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                            <div class="md:max-w-[500px] w-full">
                                                                <label class="text-gray-500 text-sm font-medium">Currency Code</label>
                                                                <div class="relative mt-1">
                                                                    <asp:Label ID="lblnoofpack" runat="server" Width="80%" Font-Size="Medium" Font-Bold="true"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="md:max-w-[500px] w-full">
                                                                <label class="text-gray-500 text-sm font-medium">Prev Permit No</label>
                                                                <div class="relative mt-1">
                                                                    <asp:Label ID="lblgrossweight" runat="server" Width="80%" Text="" Font-Size="Medium" Font-Bold="true"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                            <div class="md:max-w-[500px] w-full">
                                                                <label class="text-gray-500 text-sm font-medium">Item Amount</label>
                                                                <div class="relative mt-1">
                                                                    <asp:Label ID="lblinvoiceAmt" runat="server" Width="80%" Font-Size="Medium" Font-Bold="true"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="md:max-w-[500px] w-full">
                                                                <label class="text-gray-500 text-sm font-medium">Transport Mode</label>
                                                                <div class="relative mt-1">
                                                                    <asp:Label ID="lblTotItemGst" runat="server" Width="80%" Font-Size="Medium" Font-Bold="true"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                            <div class="md:max-w-[1000px] w-full">
                                                                <div class="relative mt-1">
                                                                    <div class="alert alert-danger">
                                                                        <asp:CheckBox ID="chkalrt" runat="server" Checked="false" TabIndex="138" />
                                                                        <strong></strong>(1) I/We declare that all particulars in this application are true and correct.<br />
                                                                        &nbsp;&nbsp;&nbsp;(2) I/We declare that all the product(s) to be exported in this Application has/have been registered with the TTSB of Singapore Customs and qualify(s) for the respective Certificate applied for.
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="row">
                                                            <div class="col-sm-12">

                                                                <center>

                                                                    <div class="flex justify-between gap-4 md:flex-nowrap flex-wrap mt-6" id="DeclBtn" runat="server">
                                                                        <asp:Button ID="btnprevsum" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" runat="server" OnClick="btnprevsum_Click" Text="Previous" TabIndex="199" />
                                                                        <asp:Button ID="btnnextsum" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" runat="server" OnClick="btnnextsum_Click" Text="Next" TabIndex="201" />
                                                                        <asp:Button ID="btnsavesum" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" runat="server" OnClick="btnsavesum_Click" Text="Save Permit" TabIndex="200" />
                                                                    </div>
                                                                </center>
                                                            </div>
                                                        </div>

                                                    </ContentTemplate>

                                                </asp:UpdatePanel>
                                            </ContentTemplate>
                                        </cc1:TabPanel>
                                        <%--</div>--%>
                                        <%-- <div role="tabpanel" class="tab-pane fade" id="Amend">--%>
                                        <cc1:TabPanel ID="Amend" CssClass="ajax__tab_header" runat="server" Visible="false" HeaderText="Amend">

                                            <ContentTemplate>
                                                <asp:UpdatePanel ID="coamend" UpdateMode="Conditional" runat="server">
                                                    <ContentTemplate>
                                                        <div class="row">
                                                            <div class="col-sm-12">
                                                                <div class="row Borderdiv" style="width: 100%">Update Information</div>
                                                                <div class="row">
                                                                    <div class="col-sm-6">
                                                                        <p>Amendment Count</p>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" Width="300" type="text" ID="TextBox11" TabIndex="143"></asp:TextBox>
                                                                        <br />
                                                                        <p>Update Indicator</p>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" Width="300" type="text" ID="TextBox12" TabIndex="144"></asp:TextBox>
                                                                        <br />
                                                                    </div>
                                                                    <div class="col-sm-6">
                                                                        <p>Permit Number</p>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" Width="300" type="text" ID="TextBox13" TabIndex="145"></asp:TextBox>
                                                                        <br />
                                                                        <p>Replacement Permit Number</p>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" Width="300" type="text" ID="TextBox14" TabIndex="146"></asp:TextBox>
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
                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" TextMode="MultiLine" Width="100%" type="text" Style="text-transform: uppercase" ID="TextBox15" TabIndex="147"></asp:TextBox>
                                                                <br />
                                                                <asp:CheckBox ID="ChkPermitvalEx" runat="server" TabIndex="109" Text="Permit Validity Extension" />
                                                                <br />
                                                                <p>Extend Import Period (Reason for Extension of validity for Temporary / Exhibit Cargoes)</p>
                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" TextMode="MultiLine" Width="100%" type="text" ID="TextBox16" TabIndex="148"></asp:TextBox>
                                                                <br />
                                                                <br />
                                                                <div class="row Borderdiv" style="width: 100%">Declaration Indicator</div>
                                                                <div class="alert alert-danger">
                                                                    <asp:CheckBox ID="CheckBox2" runat="server" Checked="false" TabIndex="149" />
                                                                    <strong></strong>I/We declare that all particulars in this application are true and correct
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <center>
                                                            <div class="btn-group btn-group-lg">
                                                                <asp:Button ID="Button5" CssClass="nn" runat="server" class="btn btn-info btn-lg" OnClick="btnprevsum_Click" Text="Previous" TabIndex="150" />
                                                                <asp:Button ID="Button6" CssClass="nn" runat="server" class="btn btn-info btn-lg" OnClick="btnsavesum_Click" Text="Save" TabIndex="151" />
                                                                <asp:Button ID="Button7" CssClass="nn" runat="server" class="btn btn-info btn-lg" OnClick="btnresetsum_Click" Text="Reset" TabIndex="152" />
                                                                <asp:Button ID="Button8" CssClass="nn" runat="server" class="btn btn-info btn-lg" OnClick="btnnextsum_Click" Text="Next" TabIndex="153" />

                                                            </div>
                                                        </center>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </ContentTemplate>
                                        </cc1:TabPanel>
                                        <%-- </div>--%>

                                        <%--  <div role="tabpanel" class="tab-pane fade " id="Cancel">--%>
                                        <cc1:TabPanel ID="Cancel" CssClass="ajax__tab_header" runat="server" Visible="false" HeaderText="Cancel">

                                            <ContentTemplate>
                                                <asp:UpdatePanel ID="cocancel" UpdateMode="Conditional" runat="server">
                                                    <ContentTemplate>
                                                        <div class="row">
                                                            <div class="col-sm-12">
                                                                <div class="row Borderdiv" style="width: 100%">Update Information</div>
                                                                <div class="row">
                                                                    <div class="col-sm-6">
                                                                        <p>Update Indicator</p>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" Width="300" type="text" ID="TextBox17" TabIndex="154"></asp:TextBox>
                                                                        <br />


                                                                    </div>
                                                                    <div class="col-sm-6">
                                                                        <p>Permit Number</p>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" Width="300" type="text" ID="TextBox18" TabIndex="155"></asp:TextBox>
                                                                        <br />
                                                                        <p>Replacement Permit Number</p>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" Width="300" type="text" ID="TextBox19" TabIndex="156"></asp:TextBox>
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
                                                                <asp:DropDownList CssClass="drop" ID="DrpReasonCancel" Width="300" TabIndex="157" Height="26" runat="server"></asp:DropDownList>
                                                            </div>
                                                            <div class="col-sm-6">
                                                                <p>Description For Reason</p>
                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" TextMode="MultiLine" Width="100%" type="text" ID="TextBox20" TabIndex="158"></asp:TextBox>
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
                                                                                <asp:DropDownList CssClass="drop" ID="DropDownList1" BackColor="#e8f0fe" Width="250" Height="32" AppendDataBoundItems="true" TabIndex="117" runat="server">
                                                                                </asp:DropDownList><br />
                                                                                <asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator9" runat="server" ControlToValidate="DropDownList1" InitialValue="0" ErrorMessage="Header --> Doc Type" ValidationGroup="Validationbtn"></asp:RequiredFieldValidator>
                                                                            </div>
                                                                            <div class="col-sm-5">
                                                                                <p>Uplaod Document</p>
                                                                                <asp:FileUpload ID="FileUpload2" BackColor="#e8f0fe" runat="server" TabIndex="118" class="btn" AllowMultiple="true" />
                                                                                <asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator67" runat="server" ControlToValidate="FileUpload2" ErrorMessage="Header -->Upload Doc" ValidationGroup="Validationbtn"></asp:RequiredFieldValidator>
                                                                            </div>
                                                                            <div class="col-sm-2">
                                                                                <p>Uplaod</p>
                                                                                <asp:Button runat="server" ID="BtnCancelUp" ValidationGroup="Validationbtn" class="btn btn-success" TabIndex="119" Text="Upload" OnClick="BtnCancelUp_Click" />

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
                                                                                        <asp:Label ID="Label73" runat="server"
                                                                                            Text='<%#Eval("DocumentType")%>'>
                                                                                        </asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Name" SortExpression="Id">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label74" runat="server"
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
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox21" Width="265" runat="server" TabIndex="120" type="text"></asp:TextBox>

                                                                        <br />
                                                                    </div>
                                                                    <div class="col-sm-4">
                                                                        <p>RECIPIENTS 2</p>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox22" Width="265" runat="server" TabIndex="121" type="text"></asp:TextBox>

                                                                        <br />
                                                                    </div>
                                                                    <div class="col-sm-4">
                                                                        <p>RECIPIENTS 3</p>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox23" Width="265" runat="server" TabIndex="122" type="text"></asp:TextBox>

                                                                        <br />
                                                                    </div>
                                                                </div>
                                                                <br />
                                                                <br />
                                                            </div>
                                                        </div>
                                                        <br />
                                                        <div class="row">
                                                            <div class="col-sm-12">
                                                                <div class="row Borderdiv" style="width: 100%">Declarent Indicator</div>
                                                                <div class="alert alert-danger">
                                                                    <asp:CheckBox ID="CheckBox4" runat="server" Checked="false" TabIndex="123" />
                                                                    <strong></strong>I/We declare that all particulars in this application are true and correct
                                                                </div>

                                                            </div>
                                                        </div>
                                                        <ul class="pager">
                                                            <li class="previous"><a href="#Amend" data-toggle="tab" title="Previous">Previous</a></li>
                                                            <%--<li class="next"><a href="#Cancel" data-toggle="tab" title="Next">Next</a></li>
  </ul>--%>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </ContentTemplate>
                                        </cc1:TabPanel>
                                        <%-- </div>--%>
                                    </cc1:TabContainer>

                                    <%-- </div>--%>
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
