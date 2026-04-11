<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Transhipment.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="RET.Transhipment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .disabled\:text-slate-300:disabled {
            --tw-text-opacity: 1;
            color: rgb(0 0 0) !important;
        }
    </style>
    <style type="text/css">
        .ajax__calendar_container {
            z-index: 1000;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script>
        function toUpperCaseText(ctrl) {
            ctrl.value = ctrl.value.toUpperCase();
        }
    </script>
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
        function countChars(obj) {
            document.getElementById("charNum").innerHTML = obj.value.length + ' characters';
        }
        function countChars1(obj) {
            document.getElementById("end2").innerHTML = obj.value.length + ' characters';
        }
        function countChars2(obj) {
            document.getElementById("end3").innerHTML = obj.value.length + ' characters';
        }
        function countChars3(obj) {
            document.getElementById("end4").innerHTML = obj.value.length + ' characters';
        }
        function countChars4(obj) {
            document.getElementById("end5").innerHTML = obj.value.length + ' characters';
        }
        function countCharstrade(obj) {
            document.getElementById("trade").innerHTML = obj.value.length + ' characters';
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




            $("#Transhipment").css('color', 'White');
            debugger;
            $("#Transhipment").css('background-color', 'Black');



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
    <asp:UpdateProgress ID="UpdateProgress" class="theme_loader" runat="server" AssociatedUpdatePanelID="transhipment">
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


    <asp:UpdatePanel ID="transhipment" UpdateMode="Conditional" runat="server">
        <ContentTemplate>

            <div class="flex md:justify-between items-center gap-4 mb-4 mt-6 md:flex-nowrap flex-wrap">
                <div class="flex gap-2 items-center">
                    <p class="text-gray-500 text-sm font-medium">Transhipment</p>
                    <svg width="8" height="12" viewBox="0 0 8 12" fill="none">
                        <path d="M1.5 11L5.91075 6.58925C6.1885 6.3115 6.32742 6.17258 6.32742 6C6.32742 5.82742 6.1885 5.6885 5.91075 5.41075L1.5 1" stroke="#676D7C" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                    </svg>
                    <p class="text-slate-950 text-sm sa700">New Declaration</p>
                </div>
                <p class="text-center text-gray-500 text-xs font-medium">
                    &nbsp;
                </p>
                <asp:Button ID="BtnExit" runat="server" class="text-right text-[#0560FD] text-sm cursor-pointer hover:border-none focus:shadow-none" OnClick="BtnExit_Click" Text="Exit Declaration" />
            </div>




            <div class="row">
                <div class="col-md-12 col-lg-12 col-sm-12 ">
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



                    <div class="btn-group">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="Validation" />
                        <asp:Button ValidationGroup="Validation" ID="BtnSaveDraft" class="btn1" Visible="false" runat="server" OnClientClick="$('li:eq(2)', $('.nav-tabs')).tab('show')" OnClick="BtnSaveDraft_Click" Text="Save As Draft" />


                    </div>
                </div>
            </div>


            <div class="row">
                <cc1:ModalPopupExtender ID="POPUPERR" runat="server" PopupControlID="PanelErr" TargetControlID="BtnCls" OkControlID="BtnCls" BackgroundCssClass="modalBackground">
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
                        <asp:GridView ID="GridError" PageSize="5" AllowPaging="True" OnPageIndexChanging="GridError_PageIndexChanging" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" AutoGenerateColumns="false" Visible="false">
                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                            <Columns>

                                <asp:TemplateField HeaderText="DocumentType" SortExpression="Id">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDocType" runat="server" Text='<%# Container.DataItem %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>


                        </asp:GridView>
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
                    <div class="flex flex-col justify-center items-center relative" id="divItem" runat="server" onclick="openTab(4)" style="cursor: pointer;">
                        <div class="text-center text-gray-500 md:text-base text-[10px] mb-2">
                            Item
               
                        </div>
                        <div class="w-[14px] h-[14px] bg-transparent border-2 border-[#BCBCC3] rounded-full relative">
                            <div class="after:absolute lg:after:w-[110px] md:after:w-[45px] after:w-[12px] after:h-[2px] after:bg-[#F4F6FA] after:top-0 after:bottom-0 after:my-auto after:left-3"></div>
                        </div>
                    </div>
                    <div class="flex flex-col justify-center items-center relative" id="divCPC" runat="server" onclick="openTab(5)" style="cursor: pointer;">
                        <div class="text-center text-gray-500 md:text-base text-[10px] mb-2">
                            CPC
               
                        </div>
                        <div class="w-[14px] h-[14px] bg-transparent border-2 border-[#BCBCC3] rounded-full relative">
                            <div class="after:absolute lg:after:w-[130px] md:after:w-[65px] after:w-[23px] after:h-[2px] after:bg-[#F4F6FA] after:top-0 after:bottom-0 after:my-auto after:left-3"></div>
                        </div>
                    </div>
                    <div class="flex flex-col justify-center items-center relative" id="divSummary" runat="server" onclick="openTab(6)">
                        <div class="text-center text-gray-500 md:text-base text-[10px] mb-2">
                            Summary
               
                        </div>
                        <div class="w-[14px] h-[14px] bg-transparent border-2 border-[#BCBCC3] rounded-full relative"></div>
                    </div>
                    <div class="flex flex-col justify-center items-center relative" id="divamend" runat="server" onclick="openTab(7)" style="cursor: pointer;">
                        <div class="text-center text-gray-500 md:text-base text-[10px] mb-2">
                            Amend
              
                        </div>
                        <div class="w-[14px] h-[14px] bg-transparent border-2 border-[#BCBCC3] rounded-full relative"></div>
                    </div>

                      <div class="flex flex-col justify-center items-center relative" id="divcancel" runat="server" onclick="openTab(7)" style="cursor: pointer;">
      <div class="text-center text-gray-500 md:text-base text-[10px] mb-2">
          Cancel
              
      </div>
      <div class="w-[14px] h-[14px] bg-transparent border-2 border-[#BCBCC3] rounded-full relative"></div>
  </div>
                </div>

                <div class="board-inner">


                    <!-- Tab panes -->

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

                                <asp:UpdatePanel ID="transhipheader" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>


                                        <div class="grid grid-cols-1 md:grid-cols-2 gap-6  mb-2">

                                            <!-- Left Column -->
                                            <div class="space-y-4">
                                                <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-6">
                                                    <span class="text-white text-sm font-semibold tracking-wide">Declaration Type</span>
                                                </div>
                                                <div class="w-full">
                                                    <div class="group relative flex items-center gap-4">
                                                        <label class="text-gray-500 text-sm font-medium w-[180px]">Message Type</label>
                                                        <div class="flex-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Message Type" autocomplete="off" ID="TxtMsgType" Text="TNPDEC" Enabled="false" runat="server" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="w-full">
                                                    <div class="group relative flex items-center gap-4">
                                                        <label class="text-gray-500 text-sm font-medium w-[180px]">Declaration Type</label>
                                                        <div class="flex-1">
                                                            <asp:DropDownList ID="DrpDecType" OnSelectedIndexChanged="DrpDecType_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true" TabIndex="1" runat="server" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="w-full">
                                                    <div class="group relative flex items-center gap-4">
                                                        <label class="text-gray-500 text-sm font-medium w-[180px]">Previous Permit Number</label>
                                                        <div class="flex-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Type Number" autocomplete="off" ID="TxtPrevPerNO" Text="" TabIndex="2" runat="server" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-6">
                                                    <span class="text-white text-sm font-semibold tracking-wide">Declaration Information
                                                    </span>
                                                </div>

                                                <div id="cargo" runat="server" class="w-full">
                                                    <div class="group relative flex items-center gap-4">
                                                        <label class="text-gray-500 text-sm font-medium w-[180px]">Cargo Pack Type</label>
                                                        <div class="flex-1">
                                                            <asp:DropDownList ID="DrpCargoPackType" OnSelectedIndexChanged="DrpCargoPackType_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true" TabIndex="3" runat="server" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator BackColor="Red" InitialValue="0" ID="RequiredFieldValidator5" runat="server" ControlToValidate="DrpCargoPackType" Display="None" ErrorMessage="Header --> Cargo Pack Type is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div id="Inward" runat="server" class="w-full">
                                                    <div class="group relative flex items-center gap-4">
                                                        <label class="text-gray-500 text-sm font-medium w-[180px]">Inward Transport Mode</label>
                                                        <div class="flex-1">
                                                            <asp:DropDownList ID="DrpInwardtrasMode" OnSelectedIndexChanged="DrpInwardtrasMode_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true" TabIndex="3" runat="server" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div id="Outward" runat="server" class="w-full">
                                                    <div class="group relative flex items-center gap-4">
                                                        <label class="text-gray-500 text-sm font-medium w-[180px]">Outward Trans Mode</label>
                                                        <div class="flex-1">
                                                            <asp:DropDownList ID="DrpOutwardtrasMode" OnSelectedIndexChanged="DrpOutwardtrasMode_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true" TabIndex="5" runat="server" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="w-full">
                                                    <div class="group relative flex items-center gap-4">
                                                        <label class="text-gray-500 text-sm font-medium w-[180px]">BG Indicator</label>
                                                        <div class="flex-1">
                                                            <asp:DropDownList ID="DrpBGIndicator" AppendDataBoundItems="true" TabIndex="6" runat="server" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="w-full">
                                                    <div class="group relative flex items-center gap-4">
                                                        <label class="text-gray-500 text-sm font-medium w-[180px]">Override Ex: Rate</label>
                                                        <div class="flex-1">
                                                            <asp:CheckBox ID="ChkOverrExgRate" AutoPostBack="true" runat="server" TabIndex="7" />
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="w-full">
                                                    <div class="group relative flex items-center gap-4">
                                                        <label class="text-gray-500 text-sm font-medium w-[180px]">Supply Indicator</label>
                                                        <div class="flex-1">
                                                            <asp:CheckBox ID="ChkSupplyIndicator" AutoPostBack="true" runat="server" TabIndex="7" />
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="w-full">
                                                    <div class="group relative flex items-center gap-4">
                                                        <label class="text-gray-500 text-sm font-medium w-[180px]">Supporting Documents</label>
                                                        <div class="flex-1">
                                                            <asp:CheckBox ID="ChkRefDoc" AutoPostBack="true" OnCheckedChanged="ChkRefDoc_CheckedChanged" runat="server" TabIndex="7" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="space-y-4">
                                                <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-6">
                                                    <span class="text-white text-sm font-semibold tracking-wide">Job Information
                                                    </span>
                                                    <asp:Label ID="Label2" Visible="false" runat="server"></asp:Label>
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
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator36" runat="server" Display="None" ControlToValidate="TxtDecName" ValidationExpression="[a-zA-Z ]*$" ErrorMessage="Enter a valid Name" ValidationGroup="Validation" />
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

                                                <div class="space-y-4">
                                                    <div class="w-full">
                                                        <div class="group relative flex items-center gap-4">
                                                            <label class="text-gray-500 text-sm font-medium w-[180px]">Recipient 1</label>
                                                            <div class="flex-1">
                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Type Recipient" autocomplete="off" ID="TxtRECPT1" runat="server" TabIndex="18" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="w-full">
                                                        <div class="group relative flex items-center gap-4">
                                                            <label class="text-gray-500 text-sm font-medium w-[180px]">Recipient 2</label>
                                                            <div class="flex-1">
                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Type Recipient" autocomplete="off" ID="TxtRECPT2" runat="server" TabIndex="19" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="w-full">
                                                        <div class="group relative flex items-center gap-4">
                                                            <label class="text-gray-500 text-sm font-medium w-[180px]">Recipient 3</label>
                                                            <div class="flex-1">
                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Type Recipient" autocomplete="off" ID="TxtRECPT3" runat="server" onkeypress="return isNumber(event)" TabIndex="21" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            </div>
                                                        </div>
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






                                        <div class="row">
                                            <div class="col-sm-12">
                                                <center>
                                                    <div id="Div6" runat="server" class="flex justify-between gap-4 md:flex-nowrap flex-wrap mt-6">
                                                        <asp:Button ID="btnoutsaveheader" CssClass="nn bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full " runat="server" Visible="false" OnClick="btnoutsaveheader_Click" Text="Save" TabIndex="22" />

                                                        <asp:Button ID="btnoutresetheader" CssClass="nn bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" runat="server" class="btn btn-info btn-md" OnClick="btnoutresetheader_Click" Text="Reset" TabIndex="23" />

                                                        <asp:Button ID="btnoutnextheader" runat="server" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" OnClick="btnoutnextheader_Click" Text="Next" TabIndex="23" />
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
                                <asp:UpdatePanel ID="transhipparty" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>

                                        <div class="flex flex-wrap lg:flex-nowrap gap-3 ">
                                            <div class="flex items-center justify-between mb-1 ">
                                                <!-- Left side heading and buttons -->
                                                <div class="flex items-center gap-1">
                                                    <h2 class="text-[18px] sa700 leading-[18px] text-gray-800 mb-0 mt-5 w-[200px]">Declarant Company</h2>
                                                    <asp:ImageButton ID="btntransdec" Enabled="false" Style="filter: grayscale(100%);" CssClass="theme_searchIcon mt-5" runat="server" ImageUrl="images/searchBlue.png" Height="28" Width="28" />
                                                    <asp:Button ID="DECPLUS" Enabled="false" Style="filter: grayscale(100%);" runat="server" CssClass="plusbtn plusbtnIcon mt-5" BorderWidth="0px" ValidationGroup="ItemMasterValidation1" OnClick="DECPLUS_Click" Text="+" />
                                                    <cc1:ModalPopupExtender ID="popuptransdec" runat="server" PopupControlID="pnltransdec" TargetControlID="btntransdec"
                                                        OkControlID="btnYestransdec" CancelControlID="btnNotransdec" BackgroundCssClass="modalBackground">
                                                    </cc1:ModalPopupExtender>

                                                    <asp:Panel ID="pnltransdec" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                        <div class="header">
                                                            <svg class="cursor-pointer absolute right-5 top-5" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                <circle opacity="0.1" cx="12" cy="12" r="12" fill="#676D7C"></circle>
                                                                <path d="M16.6663 7.3335L7.33301 16.6668M7.33301 7.3335L16.6663 16.6668" stroke="#676D7C" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                                            </svg>
                                                            <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Declarant Company</p>
                                                        </div>
                                                        <div class="body">
                                                            <asp:UpdatePanel ID="uptransdec" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                        <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="DecSearch" OnTextChanged="DecSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                    </div>
                                                                    <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                        <asp:GridView ID="DECCOMPSearGRID" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="DECCOMPSearGRID_PageIndexChanging" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" OnRowCommand="DECCOMPSearGRID_RowCommand" OnRowDataBound="DECCOMPSearGRID_RowDataBound" runat="server" AutoGenerateColumns="false">
                                                                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="DocumentType" SortExpression="Id">
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
                                                            <asp:Button ID="btnYestransdec" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                            <asp:Button ID="btnNotransdec" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px]  w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                        </div>
                                                    </asp:Panel>
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
                                                            ServicePath="~/Transhipment.aspx"
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
                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" Enabled="false" autocomplete="off" ID="TxtDecCompCRUEI" MaxLength="17" placeholder="" runat="server" ValidationGroup="Validation" TabIndex="25" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="TxtDecCompCRUEI" Display="None" ErrorMessage="Party --> Declarant Company CR UEI is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>

                                                <!-- Name 1 -->
                                                <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                    <label class="text-gray-500 text-sm font-medium">Name 1</label>
                                                    <div class="relative mt-1">
                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" Enabled="false" autocomplete="off" ID="TxtDecCompName" MaxLength="50" placeholder="" runat="server" ValidationGroup="party" TabIndex="26" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TxtDecCompName" Display="None" ErrorMessage="Party --> Declarant Company Name is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtDecCompName" ID="RegularExpressionValidator18" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                    </div>
                                                </div>

                                                <!-- Name 2 -->
                                                <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                    <label class="text-gray-500 text-sm font-medium">Name 2</label>
                                                    <div class="relative mt-1">
                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" Enabled="false" autocomplete="off" ID="TxtDecCompName1" MaxLength="50" placeholder="" ValidationGroup="Validation" runat="server" TabIndex="27" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtDecCompName1" ID="RegularExpressionValidator1" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="" id="ImportDiv" runat="server">
                                            <div id="transimp" visible="true" runat="server">
                                                <div class="flex flex-wrap lg:flex-nowrap gap-3">
                                                    <div class="flex items-center justify-between mb-1">
                                                        <!-- Left side heading and buttons -->
                                                        <div class="flex items-center gap-1">
                                                            <h2 class="text-[18px] sa700 leading-[18px] text-gray-800 mb-0 mt-5 w-[200px]">Importer</h2>
                                                            <asp:ImageButton ID="btntransimp" CssClass="theme_searchIcon mt-5" runat="server" ImageUrl="images/searchBlue.png" Height="28" Width="28" />
                                                            <asp:Button ID="BtnImpADD" runat="server" CssClass="plusbtn plusbtnIcon mt-5" BorderWidth="0px" ValidationGroup="Importer" OnClick="BtnImpADD_Click" Text="+" />
                                                            <cc1:ModalPopupExtender ID="popuptransimp" runat="server" PopupControlID="pnltransimp" TargetControlID="btntransimp"
                                                                OkControlID="btnYestransimp" CancelControlID="btnNotransimp" BackgroundCssClass="modalBackground">
                                                            </cc1:ModalPopupExtender>
                                                            <asp:Panel ID="pnltransimp" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                                <div class="header">

                                                                    <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Importer Search</p>
                                                                </div>
                                                                <div class="body">
                                                                    <asp:UpdatePanel ID="uptransimp" runat="server" UpdateMode="Conditional">
                                                                        <ContentTemplate>
                                                                            <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ImporterSearch" OnTextChanged="ImporterSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" runat="server" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            </div>
                                                                            <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                                <asp:GridView ID="ImporterGrid" PageSize="5" OnRowDataBound="ImporterGrid_RowDataBound" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ImporterGrid_PageIndexChanging" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" OnRowCommand="ImporterGrid_RowCommand" AutoGenerateColumns="false">
                                                                                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="DocumentType" SortExpression="Id">
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
                                                                    <asp:Button ID="btnYestransimp" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                    <asp:Button ID="btnNotransimp" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px]  w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                </div>
                                                            </asp:Panel>
                                                        </div>

                                                        <!-- Code -->
                                                        <div class="flex-1 min-w-[100px] max-w-[300px] m-1">
                                                            <label for="staticEmail" class="text-gray-500 text-sm font-medium">Code</label>
                                                            <div class="relative mt-1">
                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" placeholder="" type="text" ID="TxtImpCode" OnTextChanged="TxtImpCode_TextChanged" AutoPostBack="true" TabIndex="28" Style="text-transform: uppercase" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                <cc1:AutoCompleteExtender ServiceMethod="GetImpcode"
                                                                    MinimumPrefixLength="1"
                                                                    CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
                                                                    TargetControlID="TxtImpCode"
                                                                    ID="AutoCompleteExtender2" runat="server" FirstRowSelected="true">
                                                                </cc1:AutoCompleteExtender>
                                                            </div>
                                                        </div>

                                                        <!-- CR UEI -->
                                                        <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                            <label class="text-gray-500 text-sm font-medium">CR UEI</label>
                                                            <div class="relative mt-1">
                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtImpCRUEI" placeholder="" MaxLength="17" runat="server" TabIndex="29" type="text" Style="text-transform: uppercase" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtImpCRUEI" ID="RegularExpressionValidator6" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="importer"></asp:RegularExpressionValidator>
                                                            </div>
                                                        </div>

                                                        <!-- Name 1 -->
                                                        <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                            <label class="text-gray-500 text-sm font-medium">Name 1</label>
                                                            <div class="relative mt-1">
                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtImpName" MaxLength="35" Placeholder="" runat="server" ValidationGroup="importer" TabIndex="30" type="text" Style="text-transform: uppercase" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtImpName" ID="RegularExpressionValidator4" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="importer"></asp:RegularExpressionValidator>
                                                            </div>
                                                        </div>

                                                        <!-- Name 2 -->
                                                        <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                            <label class="text-gray-500 text-sm font-medium">Name 2</label>
                                                            <div class="relative mt-1">
                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtImpName1" MaxLength="35" placeholder="" ValidationGroup="importer" runat="server" TabIndex="31" type="text" Style="text-transform: uppercase" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtImpName1" ID="RegularExpressionValidator5" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="importer"></asp:RegularExpressionValidator>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>


                                        <div class="">
                                            <div class="flex flex-wrap lg:flex-nowrap gap-3">
                                                <div class="flex items-center justify-between mb-1">
                                                    <!-- Left side heading and buttons -->
                                                    <div class="flex items-center gap-1">
                                                        <h2 class="text-[18px] sa700 leading-[18px] text-gray-800 mb-0 mt-5 w-[200px]">Handling Agent</h2>
                                                        <asp:ImageButton ID="btntransexporter" CssClass="theme_searchIcon mt-5" runat="server" ImageUrl="images/searchBlue.png" Height="28" Width="28" />
                                                        <asp:Button ID="BtnExpAdd" runat="server" CssClass="plusbtn plusbtnIcon mt-5" BorderWidth="0px" ValidationGroup="Importer" OnClick="BtnExpAdd_Click" Text="+" />
                                                        <cc1:ModalPopupExtender ID="popuptransexp" runat="server" PopupControlID="pnltransexp" TargetControlID="btntransexporter"
                                                            OkControlID="btnYestransexp" CancelControlID="btnNtransexpo" BackgroundCssClass="modalBackground">
                                                        </cc1:ModalPopupExtender>
                                                        <asp:Panel ID="pnltransexp" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                            <div class="header">

                                                                <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Handling Agent</p>
                                                            </div>
                                                            <div class="body">
                                                                <asp:UpdatePanel ID="uptransexp" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                            <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ExporterSearch" OnTextChanged="ExporterSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                        </div>
                                                                        <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                            <asp:GridView ID="ExporterGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ExporterGrid_PageIndexChanging" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" OnRowCommand="ExporterGrid_RowCommand" OnRowDataBound="ExporterGrid_RowDataBound" AutoGenerateColumns="false">
                                                                                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="DocumentType" SortExpression="Id">
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
                                                                <asp:Button ID="btnYestransexp" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                <asp:Button ID="btnNtransexpo" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px]  w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                            </div>
                                                        </asp:Panel>
                                                    </div>

                                                    <!-- Code -->
                                                    <div class="flex-1 min-w-[100px] max-w-[300px] m-1">
                                                        <label for="staticEmail" class="text-gray-500 text-sm font-medium">Code</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" placeholder="" type="text" ID="TxtExpCode" OnTextChanged="TxtExpCode_TextChanged" AutoPostBack="true" TabIndex="28" Style="text-transform: uppercase" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            <cc1:AutoCompleteExtender ServiceMethod="GetExpcode"
                                                                MinimumPrefixLength="1"
                                                                CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
                                                                TargetControlID="TxtExpCode"
                                                                ID="AutoCompleteExtender3" runat="server" FirstRowSelected="true">
                                                            </cc1:AutoCompleteExtender>
                                                        </div>
                                                    </div>

                                                    <!-- CR UEI -->
                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                        <label class="text-gray-500 text-sm font-medium">CR UEI</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtExpCRUEI" placeholder="" runat="server" ValidationGroup="Validation" TabIndex="31" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtExpCRUEI" ID="RegularExpressionValidator2" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>

                                                    <!-- Name 1 -->
                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                        <label class="text-gray-500 text-sm font-medium">Name 1</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtExpName" placeholder="" runat="server" ValidationGroup="Validation" TabIndex="32" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtExpName" ID="RegularExpressionValidator3" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>

                                                    <!-- Name 2 -->
                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                        <label class="text-gray-500 text-sm font-medium">Name 2</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtExpName1" placeholder="" runat="server" ValidationGroup="Validation" TabIndex="33" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtExpName1" ID="RegularExpressionValidator7" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>


                                        <div class="" id="inw" runat="server">
                                            <div class="flex flex-wrap lg:flex-nowrap gap-3">
                                                <div class="flex items-center justify-between mb-1">
                                                    <!-- Left side heading and buttons -->
                                                    <div class="flex items-center gap-1">
                                                        <h2 class="text-[18px] sa700 leading-[18px] text-gray-800 mb-0 mt-5 w-[200px]">Inward Carrier Agent</h2>
                                                        <asp:ImageButton ID="btntransinw" CssClass="theme_searchIcon mt-5" runat="server" ImageUrl="images/searchBlue.png" Height="28" Width="28" />
                                                        <asp:Button ID="InwardAdd" runat="server" CssClass="plusbtn plusbtnIcon mt-5" BorderWidth="0px" ValidationGroup="INWARD" OnClick="InwardAdd_Click" Text="+" />
                                                        <cc1:ModalPopupExtender ID="popuptransinw" runat="server" PopupControlID="pnltransinw" TargetControlID="btntransinw"
                                                            OkControlID="btnYestransinw" CancelControlID="btnNotransinw" BackgroundCssClass="modalBackground">
                                                        </cc1:ModalPopupExtender>
                                                        <asp:Panel ID="pnltransinw" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                            <div class="header">

                                                                <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Inward Carrier Agent</p>
                                                            </div>
                                                            <div class="body">
                                                                <asp:UpdatePanel ID="uptransinw" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                            <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="InwardSearch" OnTextChanged="InwardSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" runat="server" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        </div>
                                                                        <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                            <asp:GridView ID="InwardGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="InwardGrid_PageIndexChanging" OnRowCommand="InwardGrid_RowCommand" OnRowDataBound="InwardGrid_RowDataBound" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" AutoGenerateColumns="false">
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
                                                                <asp:Button ID="btnYestransinw" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                <asp:Button ID="btnNotransinw" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px]  w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                            </div>
                                                        </asp:Panel>
                                                    </div>

                                                    <!-- Code -->
                                                    <div class="flex-1 min-w-[100px] max-w-[300px] m-1">
                                                        <label for="staticEmail" class="text-gray-500 text-sm font-medium">Code</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" placeholder="" type="text" AutoPostBack="true" ID="InwardCode" OnTextChanged="InwardCode_TextChanged" TabIndex="32" Style="text-transform: uppercase" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            <cc1:AutoCompleteExtender ServiceMethod="GetInwcode"
                                                                MinimumPrefixLength="1"
                                                                CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
                                                                TargetControlID="InwardCode"
                                                                ID="AutoCompleteExtender4" runat="server" FirstRowSelected="true">
                                                            </cc1:AutoCompleteExtender>
                                                        </div>
                                                    </div>

                                                    <!-- CR UEI -->
                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                        <label class="text-gray-500 text-sm font-medium">CR UEI</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="InwardCRUEI" MaxLength="17" placeholder="" runat="server" TabIndex="33" type="text" Style="text-transform: uppercase" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="InwardCRUEI" ID="RegularExpressionValidator11" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>

                                                    <!-- Name 1 -->
                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                        <label class="text-gray-500 text-sm font-medium">Name 1</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="InwardName" MaxLength="50" placeholder="" runat="server" TabIndex="34" type="text" ValidationGroup="Inward" Style="text-transform: uppercase" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="InwardName" ID="RegularExpressionValidator14" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="Inward"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>

                                                    <!-- Name 2 -->
                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                        <label class="text-gray-500 text-sm font-medium">Name 2</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="InwardName1" MaxLength="50" placeholder="" runat="server" TabIndex="35" type="text" ValidationGroup="Inward" Style="text-transform: uppercase" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="InwardName1" ID="RegularExpressionValidator10" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="" id="outw" runat="server">
                                            <div class="flex flex-wrap lg:flex-nowrap gap-3">
                                                <div class="flex items-center justify-between mb-1">
                                                    <!-- Left side heading and buttons -->
                                                    <div class="flex items-center gap-1">
                                                        <h2 class="text-[18px] sa700 leading-[18px] text-gray-800 mb-0 mt-5 w-[200px]">Outward Carrier Agent</h2>
                                                        <asp:ImageButton ID="btntransoutward" CssClass="theme_searchIcon mt-5" runat="server" ImageUrl="images/searchBlue.png" Height="28" Width="28" />
                                                        <asp:Button ID="OutwardAdd" runat="server" CssClass="plusbtn plusbtnIcon mt-5" BorderWidth="0px" ValidationGroup="ItemMasterValidation1" OnClick="OutwardAdd_Click" Text="+" />
                                                        <cc1:ModalPopupExtender ID="popuptransoutward" runat="server" PopupControlID="pnltransoutward" TargetControlID="btntransoutward"
                                                            OkControlID="btnYestransoutward" CancelControlID="btnNotransoutward" BackgroundCssClass="modalBackground">
                                                        </cc1:ModalPopupExtender>
                                                        <asp:Panel ID="pnltransoutward" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                            <div class="header">

                                                                <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Outward Agent</p>
                                                            </div>
                                                            <div class="body">
                                                                <asp:UpdatePanel ID="uptransoutward" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                            <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="OutwardSearch" OnTextChanged="OutwardSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                        </div>
                                                                        <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                            <asp:GridView ID="OutwardGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="OutwardGrid_PageIndexChanging" OnRowCommand="OutwardGrid_RowCommand" OnRowDataBound="OutwardGrid_RowDataBound" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" AutoGenerateColumns="false">
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
                                                                <asp:Button ID="btnYestransoutward" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                <asp:Button ID="btnNotransoutward" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px]  w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                            </div>
                                                        </asp:Panel>
                                                    </div>

                                                    <!-- Code -->
                                                    <div class="flex-1 min-w-[100px] max-w-[300px] m-1">
                                                        <label for="staticEmail" class="text-gray-500 text-sm font-medium">Code</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" AutoPostBack="true" ID="OutwardCode" placeholder="" OnTextChanged="OutwardCode_TextChanged" TabIndex="58" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            <cc1:AutoCompleteExtender ServiceMethod="GetOutWard"
                                                                MinimumPrefixLength="1"
                                                                CompletionInterval="100" EnableCaching="false" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" CompletionSetCount="10"
                                                                TargetControlID="OutwardCode"
                                                                ID="AutoCompleteExtender5" runat="server" FirstRowSelected="true">
                                                            </cc1:AutoCompleteExtender>
                                                        </div>
                                                    </div>

                                                    <!-- CR UEI -->
                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                        <label class="text-gray-500 text-sm font-medium">CR UEI</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="OutwardCRUEI" ValidationGroup="Partyout" placeholder="" runat="server" TabIndex="59" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="OutwardCRUEI" ID="RegularExpressionValidator15" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>

                                                    <!-- Name 1 -->
                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                        <label class="text-gray-500 text-sm font-medium">Name 1</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="OutwardName" BackColor="#e8f0fe" ValidationGroup="Partyout" runat="server" placeholder="" TabIndex="60" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="OutwardName" ID="RegularExpressionValidator12" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>

                                                    <!-- Name 2 -->
                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                        <label class="text-gray-500 text-sm font-medium">Name 2</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="OutwardName1" ValidationGroup="Partyout" runat="server" TabIndex="61" placeholder="" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="OutwardName1" ID="RegularExpressionValidator13" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div id="transfreight" runat="server">
                                            <div class="flex flex-wrap lg:flex-nowrap gap-3">
                                                <div class="flex items-center justify-between mb-1">
                                                    <!-- Left side heading and buttons -->
                                                    <div class="flex items-center gap-1">
                                                        <h2 class="text-[18px] sa700 leading-[18px] text-gray-800 mb-0 mt-5 w-[200px]">Freight Forwarder</h2>
                                                        <asp:ImageButton ID="btntransfreight" CssClass="theme_searchIcon mt-5" runat="server" ImageUrl="images/searchBlue.png" Height="28" Width="28" />
                                                        <asp:Button ID="BtnFrieghtAdd" runat="server" CssClass="plusbtn plusbtnIcon mt-5" BorderWidth="0px" ValidationGroup="ItemMasterValidation1" OnClick="BtnFrieghtAdd_Click" Text="+" />
                                                        <cc1:ModalPopupExtender ID="popuptransfreight" runat="server" PopupControlID="pnltransfreight" TargetControlID="btntransfreight"
                                                            OkControlID="btnYestransfreight" CancelControlID="btnNotransfreight" BackgroundCssClass="modalBackground">
                                                        </cc1:ModalPopupExtender>
                                                        <asp:Panel ID="pnltransfreight" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                            <div class="header">

                                                                <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Freight Forwarder</p>
                                                            </div>
                                                            <div class="body">
                                                                <asp:UpdatePanel ID="uptransfreight" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                            <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="FrieghtSearch" OnTextChanged="FrieghtSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                        </div>
                                                                        <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                            <asp:GridView ID="FrieghtGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="FrieghtGrid_PageIndexChanging" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" OnRowCommand="FrieghtGrid_RowCommand" OnRowDataBound="FrieghtGrid_RowDataBound" runat="server" AutoGenerateColumns="false">
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
                                                                <asp:Button ID="btnYestransfreight" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                <asp:Button ID="btnNotransfreight" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px]  w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                            </div>
                                                        </asp:Panel>
                                                    </div>

                                                    <!-- Code -->
                                                    <div class="flex-1 min-w-[100px] max-w-[300px] m-1">
                                                        <label for="staticEmail" class="text-gray-500 text-sm font-medium">Code</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" OnTextChanged="FrieghtCode_TextChanged" placeholder="" AutoPostBack="true" type="text" ID="FrieghtCode" TabIndex="62" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            <cc1:AutoCompleteExtender ServiceMethod="GetFrieght"
                                                                MinimumPrefixLength="1"
                                                                CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
                                                                TargetControlID="FrieghtCode"
                                                                ID="AutoCompleteExtender6" runat="server" FirstRowSelected="true">
                                                            </cc1:AutoCompleteExtender>
                                                        </div>
                                                    </div>

                                                    <!-- CR UEI -->
                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                        <label class="text-gray-500 text-sm font-medium">CR UEI</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="FrieghtCRUEI" runat="server" ValidationGroup="FREIGHT" placeholder="" TabIndex="63" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="FrieghtCRUEI" ID="RegularExpressionValidator20" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="FREIGHT"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>

                                                    <!-- Name 1 -->
                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                        <label class="text-gray-500 text-sm font-medium">Name 1</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="FrieghtName" ValidationGroup="FREIGHT" placeholder="" runat="server" TabIndex="64" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="FrieghtName" ID="RegularExpressionValidator8" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="FREIGHT"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>

                                                    <!-- Name 2 -->
                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                        <label class="text-gray-500 text-sm font-medium">Name 2</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="FrieghtName1" ValidationGroup="FREIGHT" runat="server" placeholder="" TabIndex="65" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="FrieghtName1" ID="RegularExpressionValidator17" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="FREIGHT"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div id="ConsigneeParty" runat="server">
                                            <div class="flex flex-wrap lg:flex-nowrap gap-3">
                                                <div class="flex items-center justify-between mb-1">
                                                    <!-- Left side heading and buttons -->
                                                    <div class="flex items-center gap-1">
                                                        <h2 class="text-[18px] sa700 leading-[18px] text-gray-800 mb-0 mt-5 w-[200px]">CONSIGNEE</h2>
                                                        <asp:ImageButton ID="btntransconsignee" CssClass="theme_searchIcon mt-5" runat="server" ImageUrl="images/searchBlue.png" Height="28" Width="28" />
                                                        <asp:Button ID="ConsigneeAdd" runat="server" CssClass="plusbtn plusbtnIcon mt-5" BorderWidth="0px" ValidationGroup="CLAIMANT" OnClick="ConsigneeAdd_Click" Text="+" />
                                                        <cc1:ModalPopupExtender ID="popuptransconsignee" runat="server" PopupControlID="pnltransconsignee" TargetControlID="btntransconsignee"
                                                            OkControlID="btnYestransconsignee" CancelControlID="btnNotransconsignee" BackgroundCssClass="modalBackground">
                                                        </cc1:ModalPopupExtender>
                                                        <asp:Panel ID="pnltransconsignee" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                            <div class="header">
                                                                <svg class="cursor-pointer absolute right-5 top-5" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                    <circle opacity="0.1" cx="12" cy="12" r="12" fill="#676D7C"></circle>
                                                                    <path d="M16.6663 7.3335L7.33301 16.6668M7.33301 7.3335L16.6663 16.6668" stroke="#676D7C" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                                                </svg>
                                                                <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">CONSIGNEE</p>
                                                            </div>
                                                            <div class="body">
                                                                <asp:UpdatePanel ID="uptransconsignee" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                            <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ConsigneeSearch" OnTextChanged="ConsigneeSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" runat="server" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        </div>
                                                                        <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4" style="overflow: auto !important">
                                                                            <asp:GridView ID="ConsigneeGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ConsigneeGrid_PageIndexChanging" OnRowDataBound="ConsigneeGrid_RowDataBound" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" AutoGenerateColumns="false" OnRowCommand="ConsigneeGrid_RowCommand">
                                                                                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="Code" SortExpression="Id">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblCode" runat="server" Text='<%#Eval("ConsigneeCode")%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Name" SortExpression="Id">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblname" runat="server" Text='<%#Eval("ConsigneeName")%>'></asp:Label>
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
                                                                                    <asp:TemplateField HeaderText="City" SortExpression="Id">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="ConsigneeCity" runat="server" Text='<%#Eval("ConsigneeCity")%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Sub Contry" SortExpression="Id" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="ConsigneeSub" runat="server" Text='<%#Eval("ConsigneeSub")%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Sub Contry" SortExpression="Id" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="ConsigneeSubDivi" runat="server" Text='<%#Eval("ConsigneeSubDivi")%>'></asp:Label>
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
                                                                <asp:Button ID="btnYestransconsignee" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                <asp:Button ID="btnNotransconsignee" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px]  w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                            </div>
                                                        </asp:Panel>
                                                    </div>

                                                    <!-- Code -->
                                                    <div class="flex-1 min-w-[100px] max-w-[300px] m-1">
                                                        <label for="staticEmail" class="text-gray-500 text-sm font-medium">Code</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="ConsigneeCode" placeholder="" OnTextChanged="ConsigneeCode_TextChanged" AutoPostBack="true" TabIndex="47" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            <cc1:AutoCompleteExtender ServiceMethod="GetCosigncode"
                                                                MinimumPrefixLength="1"
                                                                CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
                                                                TargetControlID="ConsigneeCode"
                                                                ID="AutoCompleteExtender9" runat="server" FirstRowSelected="true">
                                                            </cc1:AutoCompleteExtender>
                                                        </div>
                                                    </div>

                                                    <!-- Name -->
                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                        <label for="staticEmail" class="text-gray-500 text-sm font-medium">Name</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ConsigneeName" runat="server" ValidationGroup="PartyClaimant" placeholder="" TabIndex="49" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ConsigneeName" Display="None" ErrorMessage="Party --> Cosigne Name is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeName" ID="RegularExpressionValidator21" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>

                                                    <!-- Name 1 -->
                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                        <label class="text-gray-500 text-sm font-medium">Name 1</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ConsigneeName1" runat="server" ValidationGroup="PartyClaimant" TabIndex="50" placeholder="" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeName1" ID="RegularExpressionValidator23" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>

                                                    <!-- CR UEI -->
                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                        <label class="text-gray-500 text-sm font-medium">CR UEI</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ConsigneeCRUEI" runat="server" ValidationGroup="consignee" placeholder="" TabIndex="48" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeCRUEI" ID="RegularExpressionValidator68" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="consignee"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <!-- Second Row -->
                                            <div class="flex flex-wrap lg:flex-nowrap gap-3 mt-2">
                                                <div class="flex items-center justify-between mb-1">
                                                    <div class="flex items-center gap-1">
                                                        <div class="w-[200px]"></div>
                                                        <!-- Empty space for alignment -->
                                                    </div>

                                                    <!-- Address -->
                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                        <label class="text-gray-500 text-sm font-medium">Address</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ConsigneeAddress" runat="server" placeholder="" ValidationGroup="consignee" TabIndex="51" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeAddress" ID="RegularExpressionValidator9" ValidationExpression="^[\s\S]{0,160}$" runat="server" ErrorMessage="Maximum 160 characters allowed." ValidationGroup="consignee"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>

                                                    <!-- Address 1 -->
                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                        <label class="text-gray-500 text-sm font-medium">Address 1</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ConsigneeAddress1" runat="server" ValidationGroup="PartyClaimant" placeholder="" TabIndex="52" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeAddress1" ID="RegularExpressionValidator22" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>

                                                    <!-- City Name -->
                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                        <label class="text-gray-500 text-sm font-medium">City Name</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ConsigneeCity" runat="server" ValidationGroup="PartyClaimant" TabIndex="50" placeholder="" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeCity" ID="RegularExpressionValidator24" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>

                                                    <!-- Country Subdivision Code -->
                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                        <label class="text-gray-500 text-sm font-medium">Country Subdivision Code</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ConsigneeSub" runat="server" placeholder="" ValidationGroup="PartyClaimant" TabIndex="54" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeSub" ID="RegularExpressionValidator26" ValidationExpression="^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="consignee"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <!-- Third Row -->
                                            <div class="flex flex-wrap lg:flex-nowrap gap-3 mt-2">
                                                <div class="flex items-center justify-between mb-1">
                                                    <div class="flex items-center gap-1">
                                                        <div class="w-[200px]"></div>
                                                        <!-- Empty space for alignment -->
                                                    </div>

                                                    <!-- Country Subdivision -->
                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                        <label class="text-gray-500 text-sm font-medium">Country Subdivision</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ConsigneeSubDivi" runat="server" ValidationGroup="PartyClaimant" TabIndex="50" placeholder="" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeSubDivi" ID="RegularExpressionValidator136" ValidationExpression="^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>

                                                    <!-- Postal Code -->
                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                        <label class="text-gray-500 text-sm font-medium">Postal code</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ConsigneePostal" runat="server" placeholder="" ValidationGroup="consignee" TabIndex="57" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneePostal" ID="RegularExpressionValidator27" ValidationExpression="^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="consignee"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>

                                                    <!-- Country Code -->
                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                        <label class="text-gray-500 text-sm font-medium">Country Code</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ConsigneeCountry" runat="server" ValidationGroup="PartyClaimant" TabIndex="50" placeholder="" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ConsigneeCountry" ID="RegularExpressionValidator25" ValidationExpression="^[\s\S]{0,2}$" runat="server" ErrorMessage="Maximum 2 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>

                                                    <!-- Empty space -->
                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1"></div>
                                                </div>
                                            </div>
                                        </div>

                                        <div>
                                            <div class="flex flex-wrap lg:flex-nowrap gap-3">
                                                <div class="flex items-center justify-between mb-1">
                                                    <!-- Left side heading and buttons -->
                                                    <div class="flex items-center gap-1">
                                                        <h2 class="text-[18px] sa700 leading-[18px] text-gray-800 mb-0 mt-5 w-[200px]">END USER</h2>
                                                        <asp:ImageButton ID="btntransenduser" CssClass="theme_searchIcon mt-5" runat="server" ImageUrl="images/searchBlue.png" Height="28" Width="28" />
                                                        <asp:Button ID="EndUserAdd" runat="server" CssClass="plusbtn plusbtnIcon mt-5" BorderWidth="0px" OnClick="EndUserAdd_Click" Text="+" />
                                                        <cc1:ModalPopupExtender ID="popuptransenduser" runat="server" PopupControlID="pnltransenduser" TargetControlID="btntransenduser"
                                                            OkControlID="btnYestransenduser" CancelControlID="btnNotransenduser" BackgroundCssClass="modalBackground">
                                                        </cc1:ModalPopupExtender>
                                                        <asp:Panel ID="pnltransenduser" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                            <div class="header">
                                                                <svg class="cursor-pointer absolute right-5 top-5" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                    <circle opacity="0.1" cx="12" cy="12" r="12" fill="#676D7C"></circle>
                                                                    <path d="M16.6663 7.3335L7.33301 16.6668M7.33301 7.3335L16.6663 16.6668" stroke="#676D7C" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                                                </svg>
                                                                <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">END USER</p>
                                                            </div>
                                                            <div class="body">
                                                                <asp:UpdatePanel ID="uptransenduser" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                            <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="EndUserSearch" OnTextChanged="EndUserSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                        </div>
                                                                        <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4" style="overflow: auto !important">
                                                                            <asp:GridView ID="EndUserGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="EndUserGrid_PageIndexChanging" OnRowDataBound="EndUserGrid_RowDataBound" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" AutoGenerateColumns="false" OnRowCommand="EndUserGrid_RowCommand">
                                                                                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="Code" SortExpression="Id">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblCode" runat="server" Text='<%#Eval("EndUserCode")%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Name" SortExpression="Id">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblname" runat="server" Text='<%#Eval("EndUserName")%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Name1" SortExpression="Id">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblName1" runat="server" Text='<%#Eval("EndUserName1")%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="CRUEI" SortExpression="Id" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblCRUEI" runat="server" Text='<%#Eval("EndUserCRUEI")%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Address" SortExpression="Id">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="ConsigneeAddress" runat="server" Text='<%#Eval("EndUserAddress")%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Address1" SortExpression="Id" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="ConsigneeAddress1" runat="server" Text='<%#Eval("EndUserAddress1")%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="City" SortExpression="Id">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="ConsigneeCity" runat="server" Text='<%#Eval("EndUserCity")%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Sub Contry" SortExpression="Id" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="ConsigneeSub" runat="server" Text='<%#Eval("EndUserSub")%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Sub Division" SortExpression="Id" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="ConsigneeSubDivi" runat="server" Text='<%#Eval("EndUserSubDivi")%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="City" SortExpression="Id" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="ConsigneePostal" runat="server" Text='<%#Eval("EndUserPostal")%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="City" SortExpression="Id">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="ConsigneeCountry" runat="server" Text='<%#Eval("EndUserCountry")%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="LmkEndUser" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LmkEndUser_Command" CssClass="duration-300 ease-in-out md:max-w-[200px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700">Select </asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            <div class="footer" align="right">
                                                                <asp:Button ID="btnYestransenduser" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                <asp:Button ID="btnNotransenduser" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px]  w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                            </div>
                                                        </asp:Panel>
                                                    </div>

                                                    <!-- Code -->
                                                    <div class="flex-1 min-w-[100px] max-w-[300px] m-1">
                                                        <label for="staticEmail" class="text-gray-500 text-sm font-medium">Code</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="EndUserCode" placeholder="" OnTextChanged="EndUserCode_TextChanged" AutoPostBack="true" TabIndex="47" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            <cc1:AutoCompleteExtender ServiceMethod="GetEnduser"
                                                                MinimumPrefixLength="1"
                                                                CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
                                                                TargetControlID="EndUserCode"
                                                                ID="AutoCompleteExtender7" runat="server" FirstRowSelected="true">
                                                            </cc1:AutoCompleteExtender>
                                                        </div>
                                                    </div>
                                                      <!-- User Name -->
  <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
      <label class="text-gray-500 text-sm font-medium"> Name</label>
      <div class="relative mt-1">
          <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="EndUserName" runat="server" ValidationGroup="Enduser" placeholder="" TabIndex="52" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
          <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserName" ID="RegularExpressionValidator30" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="Enduser"></asp:RegularExpressionValidator>
      </div>
  </div>


                                                      <!-- User Name1 -->
  <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
      <label class="text-gray-500 text-sm font-medium"> Name1</label>
      <div class="relative mt-1">
          <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="EndUserName1" runat="server" ValidationGroup="Enduser" TabIndex="50" placeholder="" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
          <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserName1" ID="RegularExpressionValidator33" ValidationExpression="^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="Enduser"></asp:RegularExpressionValidator>
      </div>
  </div>
                                                    <!-- End User Crueo -->
                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                        <label class="text-gray-500 text-sm font-medium">CR UEI</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="EndUserCrueo" runat="server" placeholder="" ValidationGroup="Enduser" TabIndex="51" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserCrueo" ID="RegularExpressionValidator16" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Enduser"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>

                                                   
                                                </div>
                                            </div>

                                            <!-- Second Row -->
                                            <div class="flex flex-wrap lg:flex-nowrap gap-3 mt-2">
                                                <div class="flex items-center justify-between mb-1">
                                                    <div class="flex items-center gap-1">
                                                        <div class="w-[200px]"></div>
                                                        <!-- Empty space for alignment -->
                                                    </div>


                                                     <!-- End User Address -->
 <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
     <label class="text-gray-500 text-sm font-medium"> Address</label>
     <div class="relative mt-1">
         <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="EndUserAddress" runat="server" placeholder="" ValidationGroup="Enduser" TabIndex="54" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
         <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserAddress" ID="RegularExpressionValidator19" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35characters allowed." ValidationGroup="Enduser"></asp:RegularExpressionValidator>
     </div>
 </div>

                                                    
                                                    <!-- End User Address1 -->
                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                        <label class="text-gray-500 text-sm font-medium">Address1</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="EndUserAddress1" runat="server" ValidationGroup="Enduser" TabIndex="50" placeholder="" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserPostal" ID="RegularExpressionValidator31" ValidationExpression="^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="Enduser"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>

                                                    
                                                    <!-- User City -->
                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                        <label class="text-gray-500 text-sm font-medium"> City</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="EndUserCity" runat="server" ValidationGroup="Enduser" TabIndex="50" placeholder="" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserCity" ID="RegularExpressionValidator34" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Enduser"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>

 <!-- End User Sub Code -->
 <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
     <label class="text-gray-500 text-sm font-medium">Country Subdivision Code</label>
     <div class="relative mt-1">
         <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="EndUserSubCode" runat="server" placeholder="" ValidationGroup="Enduser" TabIndex="57" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
         <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserSubCode" ID="RegularExpressionValidator28" ValidationExpression="^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="Enduser"></asp:RegularExpressionValidator>
     </div>
 </div>

                                                 
                                                </div>
                                            </div>

                                            <!-- Third Row -->
                                            <div class="flex flex-wrap lg:flex-nowrap gap-3 mt-2">
                                                <div class="flex items-center justify-between mb-1">
                                                    <div class="flex items-center gap-1">
                                                        <div class="w-[200px]"></div>
                                                        <!-- Empty space for alignment -->
                                                    </div>

                                                     <!-- End User Sub division -->
   <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
       <label for="staticEmail" class="text-gray-500 text-sm font-medium">Country Subdivision</label>
       <div class="relative mt-1">
           <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="EndUserSubCodeDivi" runat="server" ValidationGroup="Enduser" placeholder="" TabIndex="49" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
           <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserSubCodeDivi" ID="RegularExpressionValidator29" ValidationExpression="^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="Enduser"></asp:RegularExpressionValidator>
       </div>
   </div>

 


   <!-- User Postal -->
   <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
       <label class="text-gray-500 text-sm font-medium">Postal Code</label>
       <div class="relative mt-1">
           <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="EndUserPostal" runat="server" ValidationGroup="Enduser" TabIndex="50" placeholder="" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
           <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserPostal" ID="RegularExpressionValidator32" ValidationExpression="^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="Enduser"></asp:RegularExpressionValidator>
       </div>
   </div>


                                                    <!-- User Country -->
                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                        <label class="text-gray-500 text-sm font-medium">Country Code</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="EndUserCountry" runat="server" ValidationGroup="Enduser" TabIndex="50" placeholder="" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserCountry" ID="RegularExpressionValidator35" ValidationExpression="^[\s\S]{0,2}$" runat="server" ErrorMessage="Maximum 2 characters allowed." ValidationGroup="Enduser"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>

                                                    <!-- Copy Button -->
                                                    <div class="flex-1 min-w-[200px] max-w-[300px] m-1">
                                                        <label class="text-gray-500 text-sm font-medium">&nbsp;</label>
                                                        <div class="relative mt-1">
                                                            <asp:Button ID="btncopyconsign" runat="server" OnClick="btncopyconsign_Click" Text="Copy of Consignee" CssClass="duration-300 ease-in-out md:max-w-[150px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
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


                        <cc1:TabPanel ID="Cargo1" runat="server" CssClass="nn" HeaderText="Cargo">
                            <ContentTemplate>
                                <asp:UpdatePanel ID="transhipcargo" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>

                                        <div class="grid grid-cols-1 md:grid-cols-2 gap-6  mb-2">
                                            <div class="space-y-4">
                                                <!-- Location Information Section -->
                                                <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-7">
                                                    <span class="text-white text-sm font-semibold tracking-wide">Location Information</span>
                                                </div>

                                                <div id="location" runat="server">
                                                    <!-- First Row: Release Location -->
                                                    <div class="mb-6">

                                                        <!-- Release Location Label and Input - Now First Row (small input) -->
                                                        <div class="flex items-center gap-4 w-full mb-4">
                                                            <div class="flex items-center gap-2 flex-shrink-0">
                                                                <div class="text-gray-500 text-sm font-medium">
                                                                    Release Location
                        <asp:ImageButton ID="btntransreleaselocation" runat="server" ImageUrl="./images/circel-search.svg" Height="15" Width="15" />
                                                                </div>
                                                            </div>

                                                            <!-- Release Location Input -->
                                                            <div class="w-[150px]">
                                                                <div class="group relative">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" Style="text-transform: uppercase" ID="txtreLoctn" OnTextChanged="txtreLoctn_TextChanged" AutoPostBack="true" TabIndex="90" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender8" runat="server" CompletionInterval="100" FirstRowSelected="true" MinimumPrefixLength="1" DelimiterCharacters="1" ServiceMethod="Getrelloc" ServicePath="~/InNonPayment.aspx" Enabled="True" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" TargetControlID="txtreLoctn" />

                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtreLoctn" ID="RegularExpressionValidator38" ValidationExpression="^[\s\S]{0,7}$" runat="server" ErrorMessage="Maximum 7 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>

                                                                    <cc1:ModalPopupExtender ID="popuptransreleaseloc" runat="server" PopupControlID="pnltransreleaseloc" TargetControlID="btntransreleaselocation" OkControlID="btnyestransrel" CancelControlID="btnnotransrel" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>

                                                                    <asp:Panel ID="pnltransreleaseloc" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                                        <div class="header">

                                                                            <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Release Location</p>
                                                                        </div>
                                                                        <div class="body">
                                                                            <asp:UpdatePanel ID="uptransreleaseloc" runat="server" UpdateMode="Conditional">
                                                                                <ContentTemplate>
                                                                                    <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                        <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="LocationSearch" OnTextChanged="LocationSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                                        <asp:GridView ID="LocationGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="LocationGrid_PageIndexChanging" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" OnRowCommand="LocationGrid_RowCommand" OnRowDataBound="LocationGrid_RowDataBound" AutoGenerateColumns="false">
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
                                                                                                        <asp:LinkButton ID="LnkLocation" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkLocation_Command" CssClass="duration-300 ease-in-out md:max-w-[200px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700">Select</asp:LinkButton>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                            </Columns>
                                                                                        </asp:GridView>
                                                                                    </div>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <div class="footer" align="right">
                                                                            <asp:Button ID="btnyestransrel" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                            <asp:Button ID="btnnotransrel" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px]  w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                        </div>
                                                                    </asp:Panel>
                                                                </div>
                                                            </div>
                                                            <div class="w-full">
                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" MaxLength="256" type="text" ID="txtrelocDeta" Style="text-transform: uppercase" ValidationGroup="Validation" TabIndex="103" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            </div>
                                                        </div>

                                                        <!-- Release Details - Now Second Row (large textarea) -->

                                                    </div>

                                                    <!-- Second Row: Receipt Location -->
                                                    <div class="mb-6">
                                                        <!-- Receipt Location Label and Input - First Row (small input) -->
                                                        <div class="flex items-center gap-4 w-full mb-4">
                                                            <div class="flex items-center gap-2 flex-shrink-0">
                                                                <div class="text-gray-500 text-sm font-medium">
                                                                    Receipt Location
                        <asp:ImageButton ID="btntransrecloc" runat="server" ImageUrl="./images/circel-search.svg" Height="15" Width="15" />
                                                                </div>
                                                            </div>

                                                            <!-- Receipt Location Input -->
                                                            <div class="w-[150px]">
                                                                <div class="group relative">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" Style="text-transform: uppercase" ID="txtrecloctn" OnTextChanged="txtrecloctn_TextChanged" AutoPostBack="true" TabIndex="90" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender10" runat="server" CompletionInterval="100" FirstRowSelected="true" MinimumPrefixLength="1" DelimiterCharacters="1" ServiceMethod="GetRecLoc" ServicePath="~/Transhipment.aspx" Enabled="True" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" TargetControlID="txtrecloctn" />

                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtrecloctn" Display="None" ErrorMessage="Cargo -->Receipt Location Code is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>

                                                                    <cc1:ModalPopupExtender ID="popuptransrecloc" runat="server" PopupControlID="pnltransrecloc" TargetControlID="btntransrecloc" OkControlID="btnYestransrecloc" CancelControlID="btnNotransrecloc" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>

                                                                    <asp:Panel ID="pnltransrecloc" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                                        <div class="header">

                                                                            <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Receipt Location</p>
                                                                        </div>
                                                                        <div class="body">
                                                                            <asp:UpdatePanel ID="uptransrecloc" runat="server" UpdateMode="Conditional">
                                                                                <ContentTemplate>
                                                                                    <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                        <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ReceiptSearch" OnTextChanged="ReceiptSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                                        <asp:GridView ID="ReceiptGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ReceiptGrid_PageIndexChanging" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" OnRowCommand="ReceiptGrid_RowCommand" OnRowDataBound="ReceiptGrid_RowDataBound" AutoGenerateColumns="false">
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
                                                                                                        <asp:LinkButton ID="LnkReceipt" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkReceipt_Command" CssClass="duration-300 ease-in-out md:max-w-[200px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700">Select</asp:LinkButton>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                            </Columns>
                                                                                        </asp:GridView>
                                                                                    </div>
                                                                                </ContentTemplate>
                                                                                <Triggers>
                                                                                    <asp:PostBackTrigger ControlID="ReceiptGrid" />
                                                                                </Triggers>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <div class="footer" align="right">
                                                                            <asp:Button ID="btnYestransrecloc" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                            <asp:Button ID="btnNotransrecloc" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px]  w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                        </div>
                                                                    </asp:Panel>
                                                                </div>
                                                            </div>
                                                            <div class="w-full">
                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" MaxLength="256" type="text" ID="txtrecloctndet" Style="text-transform: uppercase" ValidationGroup="Validation" TabIndex="103" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                <asp:Label runat="server" ForeColor="Red" BackColor="Yellow" Visible="false" ID="lblrecloc"></asp:Label>
                                                            </div>

                                                        </div>

                                                        <!-- Receipt Details - Second Row (large textarea) -->

                                                    </div>

                                                    <!-- Third Row: Storage Location -->
                                                    <div class="mb-6">
                                                        <!-- Storage Location Label and Input - First Row (small input) -->
                                                        <div class="flex items-center gap-4 w-full mb-4">
                                                            <div class="flex items-center gap-2 flex-shrink-0">
                                                                <div class="text-gray-500 text-sm font-medium">
                                                                    Storage Location
                        <asp:ImageButton ID="btntransstorageloc" runat="server" ImageUrl="./images/circel-search.svg" Height="15" Width="15" />
                                                                </div>
                                                            </div>

                                                            <!-- Storage Location Input -->
                                                            <div class="w-[150px]">
                                                                <div class="group relative">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" Style="text-transform: uppercase" ID="TxtStorageShort" AutoPostBack="true" TabIndex="90" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" OnTextChanged="TxtStorageShort_TextChanged"></asp:TextBox>

                                                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender14" runat="server" CompletionInterval="100" FirstRowSelected="true" MinimumPrefixLength="1" DelimiterCharacters="1" ServiceMethod="GetStorageLoc" ServicePath="~/InNonPayment.aspx" Enabled="True" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" TargetControlID="TxtStorageShort" />

                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtStorageShort" ID="RegularExpressionValidator42" ValidationExpression="^[\s\S]{0,7}$" runat="server" ErrorMessage="Maximum 7 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>

                                                                    <cc1:ModalPopupExtender ID="popuptransstorage" runat="server" PopupControlID="pnltransstorage" TargetControlID="btntransstorageloc" OkControlID="btnYestransstorage" CancelControlID="btnNotransstorage" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>

                                                                    <asp:Panel ID="pnltransstorage" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                                        <div class="header">

                                                                            <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Storage Location</p>
                                                                        </div>
                                                                        <div class="body">
                                                                            <asp:UpdatePanel ID="uptransstorage" runat="server" UpdateMode="Conditional">
                                                                                <ContentTemplate>
                                                                                    <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                        <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="StorageSearch" OnTextChanged="StorageSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                                        <asp:GridView ID="StorageGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="StorageGrid_PageIndexChanging" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" OnRowCommand="StorageGrid_RowCommand" OnRowDataBound="StorageGrid_RowDataBound" runat="server" AutoGenerateColumns="false">
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
                                                                                                        <asp:LinkButton ID="LnkStorage" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkStorage_Command" CssClass="duration-300 ease-in-out md:max-w-[200px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700">Select</asp:LinkButton>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                            </Columns>
                                                                                        </asp:GridView>
                                                                                    </div>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <div class="footer" align="right">
                                                                            <asp:Button ID="btnYestransstorage" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                            <asp:Button ID="btnNotransstorage" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px]  w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                        </div>
                                                                    </asp:Panel>
                                                                </div>
                                                            </div>

                                                            <!-- Storage Details - Second Row (large textarea) -->
                                                            <div class="w-full">
                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" MaxLength="256" type="text" ID="TxtStorageName" Style="text-transform: uppercase" ValidationGroup="Validation" TabIndex="103" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtStorageName" ID="RegularExpressionValidator43" ValidationExpression="^[\s\S]{0,250}$" runat="server" ErrorMessage="Maximum 250 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
                                                            </div>

                                                        </div>


                                                    </div>

                                                    <!-- Fourth Row: Blanket Start Date (if visible) -->
                                                    <div class="flex items-center gap-4 w-full mb-4">
                                                        <!-- Blanket Start Date -->
                                                        <div id="BlanketCode" runat="server" visible="false" class="flex items-center gap-2 flex-shrink-0">
                                                            <div class="text-gray-500 text-sm font-medium" id="lblrem" runat="server">
                                                                Removal Start Date
                                                            </div>
                                                        </div>

                                                        <!-- Blanket Date Input -->
                                                        <div class="w-full">
                                                            <div class="group relative" visible="false">
                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="BlankDate1" onkeypress="return noAlphabets(event)" Visible="false" runat="server" TabIndex="78" AutoPostBack="true" OnTextChanged="BlankDate1_TextChanged" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                <cc1:CalendarExtender ID="CalendarExtender1" CssClass="cal_Theme1" PopupButtonID="imgPopup" runat="server" TargetControlID="BlankDate1" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"></cc1:CalendarExtender>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="space-y-4">
                                                <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-7">
                                                    <span class="text-white text-sm font-semibold tracking-wide">Outer Pack Details</span>
                                                </div>

                                                <div id="totalout" runat="server">
                                                    <!-- First Row: Total Outer Pack -->
                                                    <div class="flex items-start mb-4">
                                                        <!-- Label -->
                                                        <div class="w-[200px] flex-shrink-0">
                                                            <label class="text-gray-500 text-sm font-medium">TOTAL OUTER PACK</label>
                                                        </div>
                                                        <!-- Input and Dropdown Side by Side -->
                                                        <div class="flex gap-2">
                                                            <div class="w-[168px]">
                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" onkeypress="return noAlphabets(event)" type="text" ID="TxttotalOuterPack" ValidationGroup="outerpack" TabIndex="109" AutoPostBack="true" OnTextChanged="TxttotalOuterPack_TextChanged" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxttotalOuterPack" ID="RegularExpressionValidator44" ValidationExpression="^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 8 characters allowed." ValidationGroup="outerpack"></asp:RegularExpressionValidator>
                                                            </div>

                                                            <div class="w-[120px]">
                                                                <asp:DropDownList ID="DrptotalOuterPack" OnSelectedIndexChanged="DrptotalOuterPack_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true" TabIndex="2" runat="server" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <!-- Second Row: Total Gross Weight -->
                                                    <div class="flex items-start">
                                                        <!-- Label -->
                                                        <div class="w-[194px] flex-shrink-0">
                                                            <label class="text-gray-500 text-sm font-medium">TOTAL GROSS WEIGHT</label>
                                                        </div>
                                                        <!-- Input and Dropdown Side by Side -->
                                                        <div class="flex gap-2">
                                                            <div class="w-[171px]">
                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" onkeypress="return noAlphabets(event)" type="text" OnTextChanged="TxtTotalGrossWeight_TextChanged" AutoPostBack="true" ValidationGroup="outerpack" ID="TxtTotalGrossWeight" TabIndex="81" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtTotalGrossWeight" ID="RegularExpressionValidator45" ValidationExpression="^[\s\S]{0,15}$" runat="server" ErrorMessage="Maximum 15 characters allowed." ValidationGroup="outerpack"></asp:RegularExpressionValidator>
                                                            </div>

                                                            <div class="w-[127px]">
                                                                <asp:DropDownList ID="DrpTotalGrossWeight" OnSelectedIndexChanged="DrpTotalGrossWeight_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true" TabIndex="2" runat="server" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4">
                                                                    <asp:ListItem Selected="True" Text="--Select--" Value="--SELECT--"></asp:ListItem>
                                                                    <asp:ListItem Text="KGM" Value="KGM"></asp:ListItem>
                                                                    <asp:ListItem Text="TNE" Value="TNE"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <br />

                                                    <div class="flex items-start">
                                                        <!-- Label -->
                                                        <div class="w-[194px] flex-shrink-0">
                                                            <label class="text-gray-500 text-sm font-medium">Total Permit Gross Weight</label>
                                                        </div>
                                                        <!-- Input and Dropdown Side by Side -->
                                                        <div class="flex gap-2">
                                                            <div class="w-[171px]">
                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" MaxLength="15" ValidationGroup="outerpack" Enabled="false" ID="txtTtlPGW" onkeypress="return isNumberKey(event)" TabIndex="60" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtTotalGrossWeight" ID="RegularExpressionValidator47" ValidationExpression="^[\s\S]{0,15}$" runat="server" ErrorMessage="Maximum 15 characters allowed." ValidationGroup="outerpack"></asp:RegularExpressionValidator>
                                                            </div>

                                                            <div class="w-[127px]">
                                                                <asp:DropDownList ID="DrpTtlPGW" CssClass="bg-slate-100 font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt-1 px-4" Enabled="false" runat="server" TabIndex="61">
                                                                    <asp:ListItem Selected="True" Text="--Select--" Value="--SELECT--"> </asp:ListItem>
                                                                    <asp:ListItem Text="KGM" Value="KGM"> </asp:ListItem>
                                                                    <asp:ListItem Text="TNE" Value="TNE"> </asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>



                                                </div>
                                            </div>

                                        </div>

                                        <div class="" runat="server">
                                            <div id="InwardDetailsdiv1" runat="server">


                                                <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-6">
                                                    <span class="text-white text-sm font-semibold tracking-wide">Inward Details
                                                    </span>
                                                </div>
                                                <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                    <div class="md:max-w-[250px] w-full" id="carMode" runat="server">
                                                        <label class="text-gray-500 text-sm font-medium">Mode</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" Enabled="false" runat="server" type="text" ID="TextMode" OnTextChanged="TextMode_TextChanged" AutoPostBack="true" TabIndex="113" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                    <div class="md:max-w-[250px] w-full" id="carArrival" runat="server">

                                                        <label class="text-gray-500 text-sm font-medium">Arrival Date & Time</label>

                                                        <div class="group relative">
                                                            <div class="flex space-x-1">

                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" onkeypress="return noAlphabets(event)" ID="TxtArrivalDate1" runat="server" AutoPostBack="true" TabIndex="84" OnTextChanged="TxtArrivalDate1_TextChanged" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                                <cc1:CalendarExtender ID="CalendarExtender2" PopupButtonID="imgPopup" runat="server" TargetControlID="TxtArrivalDate1" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"></cc1:CalendarExtender>


                                                            </div>
                                                        </div>
                                                    </div>


                                                    <div class="md:max-w-[250px] w-full" id="carLoadingPort" runat="server">
                                                        <div class="text-gray-500 text-sm font-medium">
                                                            Loading Port
                                    <asp:ImageButton ID="btntransloadingport" runat="server" ImageUrl="./images/circel-search.svg" Height="15" Width="15" />
                                                        </div>
                                                        <div class="group relative mt-1">

                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" Style="text-transform: uppercase" ID="TxtLoadShort" OnTextChanged="TxtLoadShort_TextChanged" AutoPostBack="true" TabIndex="90" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            <cc1:AutoCompleteExtender ServiceMethod="GetLoadingport" MinimumPrefixLength="1" CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false"
                                                                CompletionSetCount="10" TargetControlID="TxtLoadShort" ID="AutoCompleteExtender15" runat="server" FirstRowSelected="true">
                                                            </cc1:AutoCompleteExtender>

                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="TxtLoadShort" Display="None" ErrorMessage="Cargo --> Loading Port is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>

                                                            <cc1:ModalPopupExtender ID="popuptransloadingport" runat="server" PopupControlID="pnltransloadingport" TargetControlID="btntransloadingport" OkControlID="btnYesoutloadingport" CancelControlID="btnNooutloadingport" BackgroundCssClass="modalBackground">
                                                            </cc1:ModalPopupExtender>

                                                            <asp:Panel ID="pnltransloadingport" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                                <div class="header">

                                                                    <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Loading Port</p>
                                                                </div>
                                                                <div class="body">
                                                                    <asp:UpdatePanel ID="uptransloadingport" runat="server" UpdateMode="Conditional">
                                                                        <ContentTemplate>
                                                                            <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="CarLoadingSearch" OnTextChanged="CarLoadingSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                            </div>
                                                                            <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                                <asp:GridView ID="LoadingGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="LoadingGrid_PageIndexChanging" OnRowCommand="LoadingGrid_RowCommand" OnRowDataBound="LoadingGrid_RowDataBound" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered"
                                                                                    runat="server" AutoGenerateColumns="false">
                                                                                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />

                                                                                    <Columns>


                                                                                        <asp:TemplateField HeaderText="PortCode" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblCode" runat="server" Text='<%#Eval("PortCode")%>'>
                                                                                                </asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="PortName" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblName" runat="server" Text='<%#Eval("PortName")%>'>
                                                                                                </asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>

                                                                                        <asp:TemplateField HeaderText="Country" SortExpression="Id">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblName1" runat="server" Text='<%#Eval("Country")%>'>
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
                                                                </div>
                                                                <div class="footer" align="right">
                                                                    <asp:Button ID="btnYesoutloadingport" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                    <asp:Button ID="btnNooutloadingport" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px]  w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                </div>
                                                            </asp:Panel>


                                                        </div>
                                                    </div>
                                                    <div class="md:max-w-[250px] w-full">
                                                        <label class="text-gray-500 text-sm font-medium"></label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" OnTextChanged="TxtLoadShort_TextChanged" type="text" ID="TxtLoad" Enabled="false" TabIndex="117" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2" id="InwardFlight" runat="server">

                                                    <div class="md:max-w-[250px] w-full">
                                                        <label class="text-gray-500 text-sm font-medium">Flight Number</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="Validation" type="text" ID="txtflight" TabIndex="118" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtflight" Display="None" ErrorMessage="Cargo -->Flight Number is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>

                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtflight" ID="RegularExpressionValidator116" ValidationExpression="^[\s\S]{0,15}$" runat="server" ErrorMessage="Maximum 15 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>


                                                        </div>
                                                    </div>

                                                    <div class="md:max-w-[250px] w-full">
                                                        <label class="text-gray-500 text-sm font-medium">Aircraft Register Number</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="Validation" type="text" ID="txtaircraft" TabIndex="119" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtaircraft" ID="RegularExpressionValidator117" ValidationExpression="^[\s\S]{0,15}$" runat="server" ErrorMessage="Maximum 15 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>

                                                        </div>
                                                    </div>


                                                    <div class="md:max-w-[250px] w-full" id="inmaster" runat="server">
                                                        <label class="text-gray-500 text-sm font-medium">Master Air Waybill</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="Validation" type="text" ID="txtwaybill" OnTextChanged="txtwaybill_TextChanged" TabIndex="119" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtwaybill" Display="None" ErrorMessage="Cargo -->Master Air Waybill is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>

                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtwaybill" ID="RegularExpressionValidator118" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>

                                                        </div>
                                                    </div>
                                                    <div class="md:max-w-[250px] w-full"></div>

                                                </div>

                                                <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2" id="InwardSea" runat="server">

                                                    <div class="md:max-w-[250px] w-full">
                                                        <label class="text-gray-500 text-sm font-medium">Voyage Number</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="Validation" type="text" ID="TxtVoyageno" TabIndex="118" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="TxtVoyageno" Display="None" ErrorMessage="Cargo -->Voyage Number is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>

                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtVoyageno" ID="RegularExpressionValidator102" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 15 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>

                                                        </div>
                                                    </div>

                                                    <div class="md:max-w-[250px] w-full">
                                                        <label class="text-gray-500 text-sm font-medium">Vessel Name</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="Validation" type="text" ID="TxtVesselName" TabIndex="119" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="TxtVesselName" Display="None" ErrorMessage="Cargo -->Vessel Name is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>

                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtVesselName" ID="RegularExpressionValidator103" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>

                                                        </div>
                                                    </div>


                                                    <div class="md:max-w-[250px] w-full" id="inobl" runat="server">
                                                        <label class="text-gray-500 text-sm font-medium">IN OBL</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="Validation" type="text" ID="TxtOceanBill" OnTextChanged="TxtOceanBill_TextChanged" TabIndex="119" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

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
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="Validation" type="text" ID="TxtConRefNo" TabIndex="118" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="TxtConRefNo" ID="RegularExpressionValidator106" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>

                                                        </div>
                                                    </div>

                                                    <div class="md:max-w-[250px] w-full">
                                                        <label class="text-gray-500 text-sm font-medium">Transport ID</label>
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ValidationGroup="Validation" ID="TxtTrnsID" TabIndex="125" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtTrnsID" ID="RegularExpressionValidator107" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>

                                                        </div>
                                                    </div>

                                                    <div class="md:max-w-[250px] w-full"></div>
                                                    <div class="md:max-w-[250px] w-full"></div>
                                                </div>

                                                <div class="mt-2 flex items-start gap-4 flex-wrap mb-2 md:max-w-[835px] w-full">
                                                    <div class="md:max-w-[196px] w-full">
                                                        <div class="group relative">
                                                            <div id="inhab1" runat="server" class="text-gray-500 text-sm font-medium">In HAWB/OBL</div>
                                                            <div id="phawb1" runat="server" class="text-gray-500 text-sm font-medium">HBL</div>
                                                            <div id="inhbl1" runat="server" class="text-gray-500 text-sm font-medium">HAWB</div>
                                                        </div>
                                                    </div>
                                                    <div class="md:max-w-[250px] w-full">
                                                        <div class="relative mt-1">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="txthblCargo" AutoPostBack="true" TabIndex="126" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="TxtConRefNo" ID="RegularExpressionValidator60" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>

                                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txthblCargo" ID="RegularExpressionValidator125" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                            <asp:Button ID="Button10" runat="server" Text="Copy of All" />
                                                        </div>
                                                    </div>

                                                </div>

                                            </div>
                                        </div>

                                        <div id="outtr" runat="server" visible="false">
                                            <div class="grid grid-cols-1 md:grid-cols-1 gap-6  mb-2">
                                                <div class="space-y-4">
                                                    <!-- Location Information Section -->
                                                    <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-7">
                                                        <span class="text-white text-sm font-semibold tracking-wide">Outward Transport Details
                                                        </span>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="grid grid-cols-1 md:grid-cols-1 gap-6  mb-2">


                                                <div class="space-y-4">
                                                    <!-- Outward Details Header -->



                                                    <div class="grid grid-cols-1 md:grid-cols-2 gap-6  mb-2">
                                                        <div class="space-y-4">

                                                            <div class="space-y-4">

                                                                <!-- Mode -->
                                                                <div class="flex items-center gap-4 w-full mb-4">
                                                                    <div class="w-[200px] flex-shrink-0">
                                                                        <label class="text-gray-500 text-sm font-medium">MODE</label>
                                                                    </div>
                                                                    <div class="w-[350px]">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" Enabled="false" runat="server" type="text" ID="TxtExpMode" OnTextChanged="TxtExpMode_TextChanged" AutoPostBack="true" TabIndex="127" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="space-y-4">

                                                                <!-- Departure Date & Time -->
                                                                <div class="flex items-center gap-4 w-full mb-4">
                                                                    <div class="w-[200px] flex-shrink-0">
                                                                        <label class="text-gray-500 text-sm font-medium">DEPARTURE DATE & TIME</label>
                                                                    </div>
                                                                    <div class="w-[350px]">
                                                                        <div class="flex space-x-1">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtExpArrivalDate1" onkeypress="return noAlphabets(event)" runat="server" AutoPostBack="true" TabIndex="96" OnTextChanged="TxtExpArrivalDate1_TextChanged" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-2"></asp:TextBox>
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtDepTime" runat="server" Width="50" TabIndex="115" placeholder="Time" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-2"></asp:TextBox>
                                                                            <cc1:CalendarExtender ID="CalendarExtender3" CssClass="cal_Theme1" PopupButtonID="imgPopup" runat="server" TargetControlID="TxtExpArrivalDate1" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"></cc1:CalendarExtender>
                                                                            <asp:Label ID="dateerr" BackColor="Brown" ForeColor="White" runat="server" Visible="false"></asp:Label>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ControlToValidate="TxtExpArrivalDate1" Display="None" ErrorMessage="Cargo --> Arrival Date is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                            <br />
                                                                            <asp:Label ID="alertdeparture" runat="server" ForeColor="Red" ></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <!-- Discharge Port -->
                                                                <div class="flex items-center gap-4 w-full mb-4" id="dischargeport" runat="server">
                                                                    <div class="w-[200px] flex-shrink-0">
                                                                        <div class="text-gray-500 text-sm font-medium">
                                                                            DISCHARGE PORT
                                                                            <asp:ImageButton ID="btntransdischargeport" runat="server" ImageUrl="./images/circel-search.svg" Height="15" Width="15" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="w-[350px]">
                                                                        <div class="flex gap-2">
                                                                            <div class="w-[150px]">
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" Style="text-transform: uppercase" ID="TxtExpLoadShort" OnTextChanged="TxtExpLoadShort_TextChanged" AutoPostBack="true" TabIndex="90" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                                <cc1:AutoCompleteExtender ServiceMethod="GetLoadingport" MinimumPrefixLength="1" CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10" TargetControlID="TxtExpLoadShort" ID="AutoCompleteExtender16" runat="server" FirstRowSelected="true"></cc1:AutoCompleteExtender>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ControlToValidate="TxtExpLoadShort" Display="None" ErrorMessage="Cargo --> Loading Port is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                            </div>
                                                                            <div class="w-[150px]">
                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="TxtExpLoad" Enabled="false" TabIndex="117" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                    <cc1:ModalPopupExtender ID="popuptransdischargeport" runat="server" PopupControlID="pnltransdischargeport" TargetControlID="btntransdischargeport" OkControlID="btnYestransdischargeport" CancelControlID="btnNotransdischargeport" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
                                                                    <asp:Panel ID="pnltransdischargeport" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                                        <div class="header">

                                                                            <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">DISCHARGE PORT</p>
                                                                        </div>
                                                                        <div class="body">
                                                                            <asp:UpdatePanel ID="uptransdischargeport" runat="server" UpdateMode="Conditional">
                                                                                <ContentTemplate>
                                                                                    <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                        <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ExpLoadingSearch" OnTextChanged="ExpLoadingSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                                    </div>
                                                                                    <asp:GridView ID="ExportGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ExportGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" OnRowCommand="ExportGrid_RowCommand" OnRowDataBound="ExportGrid_RowDataBound" runat="server" AutoGenerateColumns="false">
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
                                                                                                    <asp:LinkButton ID="LnkExport" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkExport_Command" CssClass="duration-300 ease-in-out md:max-w-[200px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700">Select</asp:LinkButton>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </ContentTemplate>
                                                                                <Triggers>
                                                                                    <asp:PostBackTrigger ControlID="ExportGrid" />
                                                                                </Triggers>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <div class="footer" align="right">
                                                                            <asp:Button ID="btnYestransdischargeport" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                            <asp:Button ID="btnNotransdischargeport" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px]  w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                        </div>
                                                                    </asp:Panel>
                                                                </div>

                                                                <!-- Final Destination Country -->
                                                                <div class="flex items-center gap-4 w-full mb-4">
                                                                    <div class="w-[200px] flex-shrink-0">
                                                                        <label class="text-gray-500 text-sm font-medium">FINAL DESTINATION COUNTRY</label>
                                                                    </div>
                                                                    <div class="w-[350px]">
                                                                        <asp:DropDownList CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" ID="DrpFinalDesCountry" runat="server" TabIndex="149"></asp:DropDownList>
                                                                        <asp:Label ID="lblfinalcountry" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                                                                    </div>
                                                                </div>

                                                                <!-- Sea Store (if visible) -->
                                                                <div class="flex items-center gap-4 w-full mb-4" id="Seastorediv" runat="server" visible="false">
                                                                    <div class="w-[200px] flex-shrink-0">
                                                                        <label class="text-gray-500 text-sm font-medium">SEA STORE</label>
                                                                    </div>
                                                                    <div class="w-[350px]">
                                                                        <asp:CheckBox ID="chkSea" OnCheckedChanged="chkSea_CheckedChanged1" runat="server" AutoPostBack="true" />
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <!-- Flight Details (if visible) -->
                                                            <div id="OUTWARDFlight" runat="server">
                                                                <!-- Flight Number -->
                                                                <div class="flex items-center gap-4 w-full mb-4">
                                                                    <div class="w-[200px] flex-shrink-0">
                                                                        <label class="text-gray-500 text-sm font-medium">FLIGHT NUMBER</label>
                                                                    </div>
                                                                    <div class="w-[350px]">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="outsea" type="text" ID="OUTWARDFlightN0" TabIndex="134" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ControlToValidate="OUTWARDFlightN0" Display="None" ErrorMessage="Cargo -->Flight Number is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="OUTWARDFlightN0" ID="RegularExpressionValidator108" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="outsea"></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>

                                                                <!-- Aircraft Register Number -->
                                                                <div class="flex items-center gap-4 w-full mb-4">
                                                                    <div class="w-[200px] flex-shrink-0">
                                                                        <label class="text-gray-500 text-sm font-medium">AIRCRAFT REGISTER NUMBER</label>
                                                                    </div>
                                                                    <div class="w-[350px]">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="outsea" type="text" ID="OUTWARDAirREgno" TabIndex="134" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="OUTWARDAirREgno" ID="RegularExpressionValidator109" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="outsea"></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>

                                                                <!-- Master Air Waybill -->
                                                                <div class="flex items-center gap-4 w-full mb-4" id="outmaster" runat="server">
                                                                    <div class="w-[200px] flex-shrink-0">
                                                                        <label class="text-gray-500 text-sm font-medium">MASTER AIR WAYBILL</label>
                                                                    </div>
                                                                    <div class="w-[350px]">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="outsea" type="text" ID="OUTWARDAirwaybill" TabIndex="134" OnTextChanged="OUTWARDAirwaybill_TextChanged" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator50" runat="server" ControlToValidate="OUTWARDAirwaybill" Display="None" ErrorMessage="Cargo -->Master Air Waybill is Required" ValidationGroup="outsea"></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator110" runat="server" Display="Dynamic" ControlToValidate="OUTWARDAirwaybill" ValidationExpression="^[\s\S]{0,35}$" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="outsea" />
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <!-- Sea Details (if visible) -->
                                                            <div id="OUTWARDSea" runat="server">
                                                                <!-- Voyage Number -->
                                                                <div class="flex items-center gap-4 w-full mb-4">
                                                                    <div class="w-[200px] flex-shrink-0">
                                                                        <label class="text-gray-500 text-sm font-medium">VOYAGE NUMBER</label>
                                                                    </div>
                                                                    <div class="w-[350px]">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="outsea" type="text" ID="OUTWARDVoyageNo" TabIndex="134" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="OUTWARDVoyageNo" ID="RegularExpressionValidator111" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="outsea"></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>

                                                                <!-- Vessel Name -->
                                                                <div class="flex items-center gap-4 w-full mb-4">
                                                                    <div class="w-[200px] flex-shrink-0">
                                                                        <label class="text-gray-500 text-sm font-medium">VESSEL NAME</label>
                                                                    </div>
                                                                    <div class="w-[350px]">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="outsea" type="text" ID="OUTWARDVessel" TabIndex="134" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator53" runat="server" ControlToValidate="OUTWARDVessel" Display="None" ErrorMessage="Cargo -->Vessel Name is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="OUTWARDVessel" ID="RegularExpressionValidator112" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="outsea"></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>

                                                                <!-- OUT OBL -->
                                                                <div class="flex items-center gap-4 w-full mb-4" id="outobl" runat="server">
                                                                    <div class="w-[200px] flex-shrink-0">
                                                                        <label class="text-gray-500 text-sm font-medium">OBL</label>
                                                                    </div>
                                                                    <div class="w-[350px]">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="outsea" type="text" ID="OUTWARDOcenbill" TabIndex="134" OnTextChanged="OUTWARDOcenbill_TextChanged" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator54" runat="server" ControlToValidate="OUTWARDOcenbill" Display="None" ErrorMessage="Cargo -->Ocean Bill Of Lading Number is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="OUTWARDOcenbill" ID="RegularExpressionValidator113" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="outsea"></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <!-- Vessel Type -->
                                                            <div class="flex items-center gap-4 w-full mb-4" id="outvessel" runat="server">
                                                                <div class="w-[200px] flex-shrink-0">
                                                                    <label class="text-gray-500 text-sm font-medium">VESSEL TYPE</label>
                                                                </div>
                                                                <div class="w-[350px]">
                                                                    <asp:DropDownList ID="ddpVessel" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="71" runat="server"></asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator55" runat="server" ControlToValidate="ddpVessel" Display="None" ErrorMessage="Cargo -->Master Air Waybill is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>

                                                            <!-- Vessel Net Register Tonnage -->
                                                            <div class="flex items-center gap-4 w-full mb-4">
                                                                <div class="w-[200px] flex-shrink-0">
                                                                    <label class="text-gray-500 text-sm font-medium">VESSEL NET REGISTER TONNAGE</label>
                                                                </div>
                                                                <div class="w-[350px]">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="txtvesnet" TabIndex="151" AutoPostBack="true" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtvesnet" ID="RegularExpressionValidator105" ValidationExpression="^[\s\S]{0,15}$" runat="server" ErrorMessage="Maximum 15 characters allowed." ValidationGroup="outsea"></asp:RegularExpressionValidator>
                                                                </div>
                                                            </div>


                                                        </div>
                                                        <div class="space-y-4">



                                                            <!-- Vessel Nationality -->
                                                            <div class="flex items-center gap-4 w-full mb-4">
                                                                <div class="w-[200px] flex-shrink-0">
                                                                    <label class="text-gray-500 text-sm font-medium">VESSEL NATIONALITY</label>
                                                                </div>
                                                                <div class="w-[350px]">
                                                                    <asp:DropDownList ID="DroVesslNat" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="71" runat="server"></asp:DropDownList>
                                                                </div>
                                                            </div>

                                                            <!-- Towing Vessel ID -->
                                                            <div class="flex items-center gap-4 w-full mb-4">
                                                                <div class="w-[200px] flex-shrink-0">
                                                                    <label class="text-gray-500 text-sm font-medium">TOWING VESSEL ID</label>
                                                                </div>
                                                                <div class="w-[350px]">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="txtTowVes" ValidationGroup="outsea" TabIndex="145" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtTowVes" ID="RegularExpressionValidator132" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="outsea"></asp:RegularExpressionValidator>
                                                                </div>
                                                            </div>

                                                            <!-- Towing Vessel Name -->
                                                            <div class="flex items-center gap-4 w-full mb-4">
                                                                <div class="w-[200px] flex-shrink-0">
                                                                    <label class="text-gray-500 text-sm font-medium">TOWING VESSEL NAME</label>
                                                                </div>
                                                                <div class="w-[350px]">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="outsea" type="text" ID="txtTowVesName" TabIndex="134" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtTowVesName" ID="RegularExpressionValidator133" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="outsea"></asp:RegularExpressionValidator>
                                                                </div>
                                                            </div>

                                                            <!-- Next Port -->
                                                            <div class="flex items-center gap-4 w-full mb-4">
                                                                <div class="w-[200px] flex-shrink-0">
                                                                    <div class="text-gray-500 text-sm font-medium">
                                                                        NEXT PORT
                                                                        <asp:ImageButton ID="btntransnxtport" runat="server" ImageUrl="./images/circel-search.svg" Height="15" Width="15" />
                                                                    </div>
                                                                </div>
                                                                <div class="w-[350px]">
                                                                    <div class="flex gap-2">
                                                                        <div class="w-[150px]">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" Style="text-transform: uppercase" ID="txtNextprt" OnTextChanged="txtNextprt_TextChanged" AutoPostBack="true" TabIndex="90" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <cc1:AutoCompleteExtender ServiceMethod="Getnextport" MinimumPrefixLength="1" CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10" TargetControlID="txtNextprt" ID="AutoCompleteExtender18" runat="server" FirstRowSelected="true"></cc1:AutoCompleteExtender>
                                                                        </div>
                                                                        <div class="w-[150px]">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="txtNetPrtSer" TabIndex="148" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <cc1:ModalPopupExtender ID="popuptransnxtport" runat="server" PopupControlID="pnltransnxtport" TargetControlID="btntransnxtport" OkControlID="btnYestransnxtport" CancelControlID="btnNotransnxtport" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
                                                                <asp:Panel ID="pnltransnxtport" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                                    <div class="header">

                                                                        <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Next Port</p>
                                                                    </div>
                                                                    <div class="body">
                                                                        <asp:UpdatePanel ID="uptransnxtport" runat="server" UpdateMode="Conditional">
                                                                            <ContentTemplate>
                                                                                <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                    <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="NextPrtLoading" OnTextChanged="NextPrtLoading_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                                </div>
                                                                                <asp:GridView ID="NextPortGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="NextPortGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" OnRowCommand="NextPortGrid_RowCommand" OnRowDataBound="NextPortGrid_RowDataBound" AutoGenerateColumns="false">
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
                                                                                                <asp:LinkButton ID="LnkLoading1" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkLoading1_Command" CssClass="duration-300 ease-in-out md:max-w-[200px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700">Select</asp:LinkButton>
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
                                                                        <asp:Button ID="btnYestransnxtport" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                        <asp:Button ID="btnNotransnxtport" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px]  w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                    </div>
                                                                </asp:Panel>
                                                            </div>

                                                            <!-- Last Port -->
                                                            <div class="flex items-center gap-4 w-full mb-4">
                                                                <div class="w-[200px] flex-shrink-0">
                                                                    <div class="text-gray-500 text-sm font-medium">
                                                                        LAST PORT
                                                                        <asp:ImageButton ID="btntranslastport" runat="server" ImageUrl="./images/circel-search.svg" Height="15" Width="15" />
                                                                    </div>
                                                                </div>
                                                                <div class="w-[350px]">
                                                                    <div class="flex gap-2">
                                                                        <div class="w-[150px]">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" Style="text-transform: uppercase" ID="txtLasPrt" OnTextChanged="txtLasPrt_TextChanged" AutoPostBack="true" TabIndex="90" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                            <cc1:AutoCompleteExtender ServiceMethod="Getlastport" MinimumPrefixLength="1" CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10" TargetControlID="txtLasPrt" ID="AutoCompleteExtender19" runat="server" FirstRowSelected="true"></cc1:AutoCompleteExtender>
                                                                        </div>
                                                                        <div class="w-[150px]">
                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="txtLasPrtSer" TabIndex="148" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <cc1:ModalPopupExtender ID="popuptranslastport" runat="server" PopupControlID="pnltranslastport" TargetControlID="btntranslastport" OkControlID="btnYestranslastport" CancelControlID="btnNotranslastport" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
                                                                <asp:Panel ID="pnltranslastport" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                                    <div class="header">

                                                                        <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Last Port</p>
                                                                    </div>
                                                                    <div class="body">
                                                                        <asp:UpdatePanel ID="uptranslastport" runat="server" UpdateMode="Conditional">
                                                                            <ContentTemplate>
                                                                                <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                    <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txtlastprt" OnTextChanged="txtlastprt_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                                </div>
                                                                                <asp:GridView ID="LastGrid" PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="LastGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" OnRowCommand="LastGrid_RowCommand" OnRowDataBound="LastGrid_RowDataBound" AutoGenerateColumns="false">
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
                                                                                                <asp:LinkButton ID="LnkLoading2" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="LnkLoading2_Command" CssClass="duration-300 ease-in-out md:max-w-[200px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700">Select</asp:LinkButton>
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
                                                                        <asp:Button ID="btnYestranslastport" runat="server" Text="Yes" CssClass="yes" Style="display: none;" />
                                                                        <asp:Button ID="btnNotranslastport" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px]  w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                    </div>
                                                                </asp:Panel>
                                                            </div>

                                                            <!-- Out HAWB/OBL -->
                                                            <div class="flex items-center gap-4 w-full mb-4">
                                                                <div class="w-[200px] flex-shrink-0">
                                                                    <label class="text-gray-500 text-sm font-medium">OUT HAWB/OBL</label>
                                                                </div>
                                                                <div class="w-[350px]">
                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="txtouthblCargo" TabIndex="151" AutoPostBack="true" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                </div>
                                                            </div>

                                                            <!-- Other Details (if visible) -->
                                                            <div id="OUTWARDOther" runat="server">
                                                                <!-- Conveyance Ref.No -->
                                                                <div class="flex items-center gap-4 w-full mb-4">
                                                                    <div class="w-[200px] flex-shrink-0">
                                                                        <label class="text-gray-500 text-sm font-medium">CONVEYANCE REF.NO</label>
                                                                    </div>
                                                                    <div class="w-[350px]">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="OUTWARDConref" TabIndex="151" AutoPostBack="true" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="OUTWARDConref" ID="RegularExpressionValidator114" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="outsea"></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>

                                                                <!-- Transport ID -->
                                                                <div class="flex items-center gap-4 w-full mb-4">
                                                                    <div class="w-[200px] flex-shrink-0">
                                                                        <label class="text-gray-500 text-sm font-medium">TRANSPORT ID</label>
                                                                    </div>
                                                                    <div class="w-[350px]">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="OUTWARDTransId" TabIndex="151" AutoPostBack="true" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="OUTWARDTransId" ID="RegularExpressionValidator115" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="outsea"></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>
                                                            </div>


                                                        </div>






                                                    </div>
                                                </div>




                                            </div>
                                        </div>



                                        <div class="row">
                                            <div class="col-sm-12 text-center">

                                                <%-- <div class="flex justify-between gap-2 items-center mt-7">
                                                    <h2 class="text-lg sa700 leading-[18px] text-gray-800 mb-6">Container Details
                                                    </h2>
                                                </div>--%>

                                                <center>

                                                    <div id="gvAddrow" visible="false" runat="server">
                                                        <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-6">
                                                            <span class="text-white text-sm font-semibold tracking-wide">Container Information
                                                            </span>

                                                        </div>
                                                        <asp:GridView ID="ContarinerGrid" FooterStyle-CssClass="w-full h-10 py-4 px-10 bg-[#F4F6FA] rounded-lg" CssClass="w-full bg-white rounded whitespace-nowrap" HeaderStyle-CssClass="w-full h-10 py-4 px-10 bg-[#F4F6FA] rounded-l-lg" PagerStyle-CssClass="pager"
                                                            RowStyle-CssClass="rows" runat="server" OnRowDeleting="ContarinerGrid_RowDeleting" OnRowDataBound="ContarinerGrid_RowDataBound1" ShowFooter="true" AutoGenerateColumns="false">
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
                                                                        <asp:RegularExpressionValidator ID="revEmail" ValidationGroup="Validation1" ForeColor="Red" Display="Dynamic" ValidationExpression="[a-zA-Z]{4}[0-9]{7}" ControlToValidate="txt1" runat="server" ErrorMessage="The container no. format should be 4 alphabets and followed by 7 digit, for ex.: ABCD1234567"></asp:RegularExpressionValidator>
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

                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txt2" onkeypress="return onlyNumbers(event)" TabIndex="72" ValidationGroup="Validation1" MaxLength="3" runat="server" CssClass="mr-4 px-3 w-[150px] h-8 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium relative focus:outline-none"></asp:TextBox>


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
                                                                        <asp:Button ID="ButtonAdd" runat="server" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" Text="+ Add Row" ValidationGroup="Container" OnClick="ButtonAdd_Click" />
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
                                            <asp:ValidationSummary ID="ValidationSummary10" runat="server" ShowMessageBox="True"
                                                ShowSummary="False" ValidationGroup="outerpack" />

                                            <div class="col-sm-8">
                                            </div>
                                            <div class="col-sm-4">
                                            </div>

                                        </div>
                                        <br />
                                        <div class="row">

                                            <div class="col-sm-12">

                                                <center>

                                                    <div class="flex justify-between gap-4 md:flex-nowrap flex-wrap mt-6">
                                                        <asp:Button ID="btnprevcargo" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full"
                                                            runat="server" OnClick="btnprevcargo_Click" Text="Previous" TabIndex="74" />
                                                        <asp:Button ID="btnsavecargo" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full"
                                                            runat="server" OnClick="btnsavecargo_Click" Text="Save Draft" TabIndex="75" />
                                                        <asp:Button ID="btnresetcargo" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full"
                                                            runat="server" OnClick="btnresetcargo_Click" Text="Reset" TabIndex="76" />
                                                        <asp:Button ID="btnnextcargo" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700"
                                                            runat="server" OnClick="btnnextcargo_Click" Text="Next" TabIndex="77" />
                                                    </div>
                                                </center>
                                            </div>

                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </ContentTemplate>
                        </cc1:TabPanel>

                        <cc1:TabPanel ID="Item" runat="server" CssClass="nn" HeaderText="Item">
                            <ContentTemplate>
                                <asp:UpdatePanel ID="transhipitem" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>

                                        <div class="row">
                                            <div class="col-sm-8">
                                            </div>
                                            <div id="BtnItemDiv" runat="server" visible="false" class="col-sm-4">
                                                <asp:Button ID="BtnAddNEWItem" runat="server" CssClass="btn btn-success btn-block" OnClick="BtnAddNEWItem_Click" Text="New Item" />
                                                <br />
                                            </div>
                                        </div>


                                        <div id="ItemDiv" runat="server">

                                            <div class="grid grid-cols-1 md:grid-cols-3 gap-6  mb-2">
                                                <!-- Column 1 (Left) -->
                                                <div class="space-y-4">
                                                    <!-- IN HAWB/OBL -->
                                                    <div class="space-y-2">
                                                        <div id="inhab" class="text-gray-500 text-sm font-medium" runat="server">IN HAWB/OBL</div>
                                                        <div id="phawb" visible="false" class="text-gray-500 text-sm font-medium" runat="server">HBL</div>
                                                        <div id="inhbl" visible="false" class="text-gray-500 text-sm font-medium" runat="server">HAWB</div>
                                                        <div class="flex gap-2">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="Item" type="text" ID="TxtHAWB" OnTextChanged="TxtHAWB_TextChanged" AutoPostBack="true" TabIndex="127" CssClass="flex-1 h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            <asp:Button ID="btnCopyAll" runat="server" Text="Copy All" OnClick="btnCopyAll_Click" CssClass="h-10 px-4 bg-blue-500 text-white rounded-md hover:bg-blue-600 whitespace-nowrap" />
                                                        </div>
                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtHAWB" ID="RegularExpressionValidator57" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                    </div>

                                                    <!-- OUT HAWB/HBL -->
                                                    <div class="space-y-2">
                                                        <label class="text-gray-500 text-sm font-medium">OUT HAWB/HBL</label>
                                                        <div class="flex gap-2">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" ValidationGroup="Item" type="text" ID="txtOutHAWB" OnTextChanged="txtOutHAWB_TextChanged" AutoPostBack="true" TabIndex="128" CssClass="flex-1 h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            <asp:Button ID="BtnOutCopyAll" runat="server" Text="Copy All" OnClick="BtnOutCopyAll_Click" CssClass="h-10 px-4 bg-blue-500 text-white rounded-md hover:bg-blue-600 whitespace-nowrap" />
                                                        </div>
                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtOutHAWB" ID="RegularExpressionValidator100" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                    </div>

                                                    <!-- ITEM CODE -->
                                                    <div class="space-y-2">
                                                        <label class="text-gray-500 text-sm font-medium">ITEM CODE</label>
                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtInHouseItem" AutoPostBack="true" OnTextChanged="TxtInHouseItem_TextChanged" runat="server" TabIndex="129" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                        <cc1:AutoCompleteExtender ServiceMethod="GetInhouse" MinimumPrefixLength="1" CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10" TargetControlID="TxtInHouseItem" ID="AutoCompleteExtender11" runat="server" FirstRowSelected="true"></cc1:AutoCompleteExtender>
                                                        <asp:Label ID="Label1" Visible="false" ForeColor="White" Font-Bold="true" BackColor="Brown" runat="server"></asp:Label>
                                                        <asp:Label ID="ITEM_CASC_HSCODES" Visible="false" CssClass="hserror" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="Brown" runat="server"></asp:Label>
                                                        <asp:Label ID="lbldhserror" Visible="false" ForeColor="White" Font-Bold="true" BackColor="Brown" runat="server"></asp:Label>
                                                        <asp:Label ID="lblhserror" Visible="false" ForeColor="White" Font-Bold="true" BackColor="Brown" runat="server"></asp:Label>
                                                    </div>



                                                    <%--   <!-- HS CODE -->
                                                    <div class="space-y-2">
                                                        <label class="text-gray-500 text-sm font-medium">HS CODE</label>
                                                        <asp:Label ID="is_inpayment_controlled" runat="server" Style="background: yellow;" />
                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtHSCodeItem" ValidationGroup="Item" OnTextChanged="TxtHSCodeItem_TextChanged" AutoPostBack="true" runat="server" TabIndex="130" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                        <cc1:AutoCompleteExtender ServiceMethod="GetHSCodeItem" MinimumPrefixLength="1" CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10" TargetControlID="TxtHSCodeItem" ID="AutoCompleteExtender12" runat="server" FirstRowSelected="true"></cc1:AutoCompleteExtender>
                                                    </div>

                                                    <!-- DESCRIPTION -->
                                                    <div class="space-y-2">
                                                        <label class="text-gray-500 text-sm font-medium">DESCRIPTION</label>
                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtDescription" ValidationGroup="Item" Style="text-transform: uppercase" OnTextChanged="TxtDescription_TextChanged" AutoPostBack="true" TextMode="MultiLine" runat="server" TabIndex="131" type="text" CssClass="w-full h-[80px] pt-3 px-4 bg-slate-100 resize-none rounded-md text-slate-950 text-sm font-medium outline-none border-none"></asp:TextBox>
                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtDescription" ID="RegularExpressionValidator53" ValidationExpression="^[\s\S]{0,512}$" runat="server" ErrorMessage="Maximum 512 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                        <asp:Label ID="LblCount" runat="server" TabIndex="5"></asp:Label>
                                                    </div>--%>
                                                    <div class="w-full">
                                                        <div class="group relative flex items-center gap-4">

                                                            <!-- Label with fixed width -->

                                                            <label class="text-gray-500 text-sm font-medium w-[70px]">HS Code </label>

                                                            <asp:ImageButton ID="btnhscode1" CssClass="theme_searchIcon mb-35" runat="server" ImageUrl="images/searchBlue.png" Height="28" Width="28" />


                                                            <cc1:ModalPopupExtender ID="popupHSCODE" runat="server" PopupControlID="pnlhscode" TargetControlID="btnhscode1"
                                                                OkControlID="btyeshs" CancelControlID="btnnohs" BackgroundCssClass="modalBackground">
                                                            </cc1:ModalPopupExtender>
                                                            <asp:Panel ID="pnlhscode" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                                <div class="header">


                                                                    <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">HS Code Search</p>


                                                                </div>
                                                                <div class="body">

                                                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                                                        <ContentTemplate>

                                                                            <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                <label class="text-gray-500 text-sm font-medium">Code</label>

                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="HSCodeSearchItem" OnTextChanged="HSCodeSearchItem_TextChanged1" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>


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

                                                                                        <asp:TemplateField Visible="false">
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
                                                                    <asp:Button ID="btnnohs" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px]  w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                </div>
                                                            </asp:Panel>
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
                                                                    ID="AutoCompleteExtender12"
                                                                    runat="server"
                                                                    FirstRowSelected="true">
                                                                </cc1:AutoCompleteExtender>

                                                                <asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator13"
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
                                                                    TabIndex="92"
                                                                    type="text"
                                                                    MaxLength="512"
                                                                    CssClass="w-full h-[123px] pt-3 px-4 bg-slate-100 resize-none rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none"
                                                                    Style="text-transform: uppercase;">
                                                                </asp:TextBox>

                                                                <asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator25"
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
                                                                    ID="RegularExpressionValidator53"
                                                                    ValidationExpression="^[\s\S]{0,512}$"
                                                                    runat="server"
                                                                    ErrorMessage="Maximum 512 characters allowed."
                                                                    ValidationGroup="Item">
                                                                </asp:RegularExpressionValidator>


                                                                <br />
                                                                <asp:LinkButton ID="lnkcopydesc" runat="server" CssClass="pull-right" Text="Copy To All"></asp:LinkButton>


                                                            </div>

                                                        </div>
                                                    </div>

                                                    <asp:Label ID="LblCount" ForeColor="Navy" runat="server" TabIndex="5"></asp:Label>

                                                    <!-- COO -->
                                                    <div class="md:w-[196px] w-full">
                                                        <!-- Label, Icon & First Input -->
                                                        <div class="flex items-center gap-1 text-gray-500 text-sm font-medium mb-1">
                                                            <%--<span class="whitespace-nowrap">Country of Origin</span>--%>

                                                            <label class="text-gray-500 text-sm font-medium w-[70px]">Country of Origin</label>
                                                            <asp:ImageButton ID="btntransorgin" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15" />
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

                                                    <%-- <div class="space-y-2">
                                                        <label class="text-gray-500 text-sm font-medium">
                                                            COO
                                                            <asp:ImageButton ID="btntransorgin" runat="server" ImageUrl="./images/circel-search.svg" Height="15" Width="15" /></label>
                                                        <div class="space-y-2">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtCountryItem" OnTextChanged="TxtCountryItem_TextChanged" AutoPostBack="true" runat="server" TabIndex="132" type="text" CssClass="w-[150px] h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            <cc1:AutoCompleteExtender ServiceMethod="GetCountryItem"
                                                                MinimumPrefixLength="1"
                                                                CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
                                                                TargetControlID="TxtCountryItem"
                                                                ID="AutoCompleteExtender13" runat="server" FirstRowSelected="true">
                                                            </cc1:AutoCompleteExtender>
                                                          

                                                        </div>
                                                         <div class="md:max-w-[250px] w-full">
     <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="txtcname" runat="server" Enabled="false" TabIndex="133" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

 </div>
                                                    </div>--%>

                                                    <!-- CHECKBOXES -->


                                                    <!-- Modal for COO -->
                                                    <cc1:ModalPopupExtender ID="popuptransorgin" runat="server" PopupControlID="pnltransorgin" TargetControlID="btntransorgin" OkControlID="btnYestransorgin" CancelControlID="btnNotransorgin" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
                                                    <asp:Panel ID="pnltransorgin" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                        <div class="header">
                                                            <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">ORGIN OF COUNTRY</p>


                                                        </div>
                                                        <div class="body">
                                                            <asp:UpdatePanel ID="uptransorgin" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>

                                                                    <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                        <label class="text-gray-500 text-sm font-medium">Code</label>


                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="CountrySearchItem" OnTextChanged="CountrySearchItem_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                                                    </div>

                                                                    <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                        <asp:GridView ID="CountryGridItem" OnPageIndexChanging="CountryGridItem_PageIndexChanging" PageSize="5" OnRowCommand="CountryGridItem_RowCommand" OnRowDataBound="CountryGridItem_RowDataBound" AllowPaging="True" DataKeyNames="Id" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
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
                                                                </ContentTemplate>

                                                                <Triggers>
                                                                    <asp:PostBackTrigger ControlID="CountryGridItem" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                        <div class="footer" align="right">
                                                            <asp:Button ID="btnYestransorgin" Style="display: none;" runat="server" Text="Yes" CssClass="yes" />
                                                            <asp:Button ID="btnNotransorgin" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px]  w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                        </div>
                                                    </asp:Panel>
                                                </div>

                                                <!-- Column 2 (Middle) -->



                                                <div class="space-y-4">

                                                    <div class="space-y-2">
                                                        <div class="flex flex-col gap-2">
                                                            <asp:CheckBox ID="ChkBGIndicator" runat="server" Text="DG INDICATOR" TabIndex="134" CssClass="text-sm" />
                                                            <asp:CheckBox ID="ChkUnbrand" OnCheckedChanged="ChkUnbrand_CheckedChanged" AutoPostBack="true" runat="server" Text="UNBRANDED" TabIndex="135" CssClass="text-sm" />
                                                        </div>
                                                    </div>
                                                    <!-- BRAND -->
                                                    <div class="space-y-2">
                                                        <label class="text-gray-500 text-sm font-medium">BRAND</label>
                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtBrand" runat="server" ValidationGroup="Item" TabIndex="136" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtBrand" ID="RegularExpressionValidator55" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                    </div>

                                                    <!-- MODEL -->
                                                    <div class="space-y-2">
                                                        <label class="text-gray-500 text-sm font-medium">MODEL</label>
                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtModel" runat="server" ValidationGroup="Item" TabIndex="137" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtModel" ID="RegularExpressionValidator56" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                    </div>

                                                    <!-- TTL DUTI QTY -->

                                                    <div id="totDuticableQtyDiv" visible="false" runat="server">


                                                        <div class="space-y-2">
                                                            <label class="text-gray-500 text-sm font-medium">Dutiable QTY</label>
                                                            <div class="flex gap-2">
                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" onkeypress="return noAlphabets(event)" ValidationGroup="Item" AutoPostBack="true" OnTextChanged="TxtTotalDutiableQuantity_TextChanged" type="text" Text="0.00" ID="TxtTotalDutiableQuantity" TabIndex="141" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                <asp:DropDownList ID="TDQUOM" runat="server" TabIndex="142" CssClass=" w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:DropDownList>
                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtTotalDutiableQuantity" ID="RegularExpressionValidator58" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                            </div>
                                                        </div>




                                                    </div>




                                                    <div class="space-y-2">
                                                        <label class="text-gray-500 text-sm font-medium">Total Dutiable QTY</label>
                                                        <div class="flex gap-2">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" onkeypress="return noAlphabets(event)" runat="server" type="text" ValidationGroup="Item" Text="0.00" ID="txttotDutiableQty" TabIndex="143" CssClass="flex-1 h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            <asp:DropDownList ID="ddptotDutiableQty" runat="server" TabIndex="150" CssClass="w-32 h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:DropDownList>
                                                        </div>
                                                    </div>

                                                    <!-- INV QTY -->
                                                    <div class="space-y-2">
                                                        <label class="text-gray-500 text-sm font-medium">
                                                            Invoice Quantity
                                                        </label>
                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" onkeypress="return noAlphabets(event)" ValidationGroup="Item" type="text" Text="0.00" ID="TxtInvQty" OnTextChanged="TxtInvQty_TextChanged" AutoPostBack="true" TabIndex="144" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtInvQty" ID="RegularExpressionValidator59" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                        <asp:Label runat="server" ID="lblinvqty" Visible="false" ForeColor="Red" BackColor="Yellow"></asp:Label>
                                                    </div>

                                                    <!-- HS QTY -->
                                                    <div class="space-y-2">
                                                        <label class="text-gray-500 text-sm font-medium">HS QTY</label>
                                                        <div class="flex gap-2">
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" onkeypress="return noAlphabets(event)" ValidationGroup="Item" type="text" ID="TxtHSQuantity" TabIndex="145" CssClass="flex-1 h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                            <asp:DropDownList ID="HSQTYUOM" runat="server" OnSelectedIndexChanged="HSQTYUOM_SelectedIndexChanged" AutoPostBack="true" TabIndex="146" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:DropDownList>
                                                            <br />
                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtHSQuantity" ID="RegularExpressionValidator62" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                            <br />
                                                            <asp:Label ID="LblHSErr" ForeColor="Red" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class=" w-full" id="AlcoholDiv" runat="server" visible="false">

                                                        <div class="space-y-2">
                                                            <label class="text-gray-500 text-sm font-medium">
                                                                Alcohol Percentage
                                                            </label>
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" onkeypress="return noAlphabets(event)" ValidationGroup="Item" type="text" Text="0.00" ID="txtAlcoholPer" TabIndex="147" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                        </div>




                                                    </div>




                                                    <!-- CHECKBOXES -->
                                                    <div class="space-y-2" style="display: none;">
                                                        <div class="flex flex-col gap-2">
                                                            <asp:CheckBox ID="ChkPackInfo" OnCheckedChanged="ChkPackInfo_CheckedChanged" runat="server" AutoPostBack="true" Checked="true" Text="PACKING INFO" TabIndex="148" CssClass="text-sm" />
                                                            <asp:CheckBox ID="Chkitemcasc" runat="server" OnCheckedChanged="Chkitemcasc_CheckedChanged" AutoPostBack="true" Checked="true" Text="ITEM CASC" TabIndex="157" CssClass="text-sm" />
                                                            <asp:CheckBox ID="Chklot" Checked="true" runat="server" OnCheckedChanged="Chklot_CheckedChanged" AutoPostBack="true" Text="LOT IDENTIFICATION" TabIndex="186" CssClass="text-sm" />
                                                            <asp:CheckBox ID="ChkTariff" Checked="true" runat="server" OnCheckedChanged="ChkTariff_CheckedChanged" Visible="false" AutoPostBack="true" Text="TARIFF" CssClass="text-sm" />
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- Column 3 (Right) -->
                                                <div class="space-y-4">
                                                    <div class="space-y-2">
                                                        <!-- Currency (Unit Price Auto) -->

                                                        <asp:Button ID="btnprev" CssClass="previous" Enabled="false" Width="50px" runat="server" class="btn btn-info btn-lg" OnClick="btnprev_Click" Text="Prev" /><asp:TextBox onkeyup="toUpperCaseText(this)" runat="server" ID="itemno" Font-Bold="true" Width="100px" Enabled="false"></asp:TextBox>
                                                        <asp:Button ID="btnnxt" CssClass="previous" Enabled="false" Width="50px" runat="server" class="btn btn-info btn-lg" OnClick="btnnxt_Click" Text="Next" />


                                                    </div>
                                                    <div class="space-y-2">
                                                        <label class="text-gray-500 text-sm font-medium">
                                                            CURRENCY (UNIT PRICE
                                                            <asp:CheckBox ID="ChkUnitPrice" CausesValidation="true" OnCheckedChanged="ChkUnitPrice_CheckedChanged" AutoPostBack="true" runat="server" TabIndex="190" />AUTO )</label>
                                                        <div class="flex gap-2">
                                                            <asp:DropDownList ID="DRPCurrency" BackColor="#e8f0fe" CausesValidation="true" OnSelectedIndexChanged="DRPCurrency_SelectedIndexChanged" TabIndex="191" AutoPostBack="true" runat="server" CssClass="w-32 h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:DropDownList>
                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" Text="0.00" CssClass="flex-1 h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <!-- TTL Line Amt -->
                                                    <div class="space-y-2">

                                                        <label class="text-gray-500 text-sm font-medium">Exchange Rate </label>
                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtExchangeRate" Enabled="false" Text="0.00" runat="server" TabIndex="192" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

                                                    </div>
                                                    <div class="space-y-2">


                                                        <label class="text-gray-500 text-sm font-medium">TTL LINE AMT</label>
                                                        <asp:Label ID="Lbl3" Font-Size="9" onkeypress="return noAlphabets(event)" Text="Total Line Amount" Visible="false" runat="server"></asp:Label>
                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" CausesValidation="true" OnTextChanged="TxtTotalLineAmount_TextChanged" onkeypress="return noAlphabets(event)" Text="0.00" AutoPostBack="true" runat="server" type="text" ID="TxtTotalLineAmount" TabIndex="197" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                    </div>

                                                    <!-- CIF/FOB (SGD) -->
                                                    <div class="space-y-2">
                                                        <label class="text-gray-500 text-sm font-medium">CIF/FOB (SGD)</label>
                                                        <asp:Label Font-Size="9" Text="CIF/FOB (SGD)" ID="Label4" runat="server" Width="100" Visible="false"></asp:Label>
                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="TxtCIFFOB" Text="0.00" TabIndex="199" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                    </div>

                                                    <!-- Packing Info Section -->
                                                    <%--<div id="PackingInfo" visible="false" runat="server">
                                                        <!-- Outer Pack Qty -->
                                                        <div class="space-y-2">
                                                            <label class="text-gray-500 text-sm font-medium">OUTER PACK QTY</label>
                                                            <div class="flex gap-2">
                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" onkeypress="return noAlphabets(event)" Text="0" type="text" ValidationGroup="Item" ID="TxtOPQty" AutoPostBack="true" OnTextChanged="TxtOPQty_TextChanged" TabIndex="149" CssClass="flex-1 h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                <asp:DropDownList ID="DRPOPQUOM" runat="server" TabIndex="150" CssClass="w-32 h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:DropDownList>
                                                            </div>
                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtOPQty" ID="RegularExpressionValidator64" ValidationExpression="^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 8 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                        </div>

                                                        <!-- In Pack Qty -->
                                                        <div class="space-y-2">
                                                            <label class="text-gray-500 text-sm font-medium">IN PACK QTY</label>
                                                            <div class="flex gap-2">
                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" onkeypress="return noAlphabets(event)" Text="0" type="text" ValidationGroup="Item" AutoPostBack="true" OnTextChanged="TxtIPQty_TextChanged" ID="TxtIPQty" TabIndex="151" CssClass="flex-1 h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                <asp:DropDownList ID="DRPIPQUOM" runat="server" TabIndex="152" CssClass="w-32 h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:DropDownList>
                                                            </div>
                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtIPQty" ID="RegularExpressionValidator63" ValidationExpression="^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 8 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                        </div>

                                                        <!-- Inner Pack Qty -->
                                                        <div class="space-y-2">
                                                            <label class="text-gray-500 text-sm font-medium">INNER PACK QTY</label>
                                                            <div class="flex gap-2">
                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" onkeypress="return noAlphabets(event)" Text="0" type="text" ValidationGroup="Item" ID="TxtINPQty" OnTextChanged="TxtINPQty_TextChanged" AutoPostBack="true" TabIndex="153" CssClass="flex-1 h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                <asp:DropDownList ID="DRPINNPQUOM" runat="server" TabIndex="154" CssClass="w-32 h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:DropDownList>
                                                            </div>
                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtINPQty" ID="RegularExpressionValidator65" ValidationExpression="^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 8 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                        </div>

                                                        <!-- Inmost Pack Qty -->
                                                        <div class="space-y-2">
                                                            <label class="text-gray-500 text-sm font-medium">INMOST PACK QTY</label>
                                                            <div class="flex gap-2">
                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" Text="0" AutoPostBack="true" OnTextChanged="TxtIMPQty_TextChanged" onkeypress="return noAlphabets(event)" type="text" ValidationGroup="Item" ID="TxtIMPQty" TabIndex="156" CssClass="flex-1 h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                <asp:DropDownList ID="DRPIMPQUOM" runat="server" TabIndex="175" CssClass="w-32 h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:DropDownList>
                                                            </div>
                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtIMPQty" ID="RegularExpressionValidator66" ValidationExpression="^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 8 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>--%>
                                                </div>
                                            </div>

                                            <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                            </div>



                                            <div id="Vehicle" visible="false" runat="server">
                                                <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                    <div class="md:max-w-[250px] w-full">
                                                        <label class="text-gray-500 text-sm font-medium">Vehicle Type </label>
                                                        <asp:DropDownList ID="DrpVehicleType" runat="server" TabIndex="138" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:DropDownList>
                                                    </div>
                                                    <div class="md:max-w-[250px] w-full">
                                                        <label class="text-gray-500 text-sm font-medium">Engine Capacity </label>
                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" onkeypress="return noAlphabets(event)" Text="" ID="txtengine" TabIndex="97" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                    </div>
                                                    <div class="md:max-w-[250px] w-full">
                                                        <label class="text-gray-500 text-sm font-medium">Dropdown</label>
                                                        <asp:DropDownList ID="DrpVehicleCapacity" runat="server" TabIndex="139" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:DropDownList>
                                                    </div>
                                                    <div class="md:max-w-[250px] w-full">
                                                        <label class="text-gray-500 text-sm font-medium">Original Registration Date </label>
                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="OriginalRegDate" onkeypress="return noAlphabets(event)" runat="server" AutoPostBack="true" TabIndex="140" OnTextChanged="OriginalRegDate_TextChanged" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="CalendarExtender4" PopupButtonID="imgPopup" runat="server" TargetControlID="OriginalRegDate" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"></cc1:CalendarExtender>
                                                    </div>
                                                </div>
                                            </div>




                                            <div class="mt-2 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                <div class="md:max-w-[250px] w-full">
                                                </div>

                                                <div class="md:max-w-[250px] w-full"></div>
                                                <div class="md:max-w-[250px] w-full"></div>
                                            </div>





                                            <div class="mt-0 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2" id="OptionalCharges" visible="false" runat="server">
                                                <div class="md:max-w-[250px] w-full">
                                                    <label class="text-gray-500 text-sm font-medium">Unit </label>
                                                    <asp:DropDownList ID="DrpOptionalUom" CausesValidation="true" OnSelectedIndexChanged="DrpOptionalUom_SelectedIndexChanged" TabIndex="193" AutoPostBack="true" runat="server" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:DropDownList>
                                                </div>
                                                <div class="md:max-w-[250px] w-full">
                                                    <label class="text-gray-500 text-sm font-medium">Optional Charges </label>
                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" Text="0.00" ID="TxtOptionalPrice" Enabled="false" OnTextChanged="TxtOptionalPrice_TextChanged" AutoPostBack="true" TabIndex="194" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                </div>
                                                <div class="md:max-w-[250px] w-full">
                                                    <label class="text-gray-500 text-sm font-medium">Txt Optional Exchage Rate </label>
                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtOptionalExchageRate" TabIndex="195" Text="0.00" OnTextChanged="TxtOptionalExchageRate_TextChanged" AutoPostBack="true" runat="server" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                </div>
                                                <div class="md:max-w-[250px] w-full">
                                                    <label class="text-gray-500 text-sm font-medium">Txt Optional Sum ExRate </label>
                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="TxtOptionalSumExRate" TabIndex="196" Text="0.00" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="mt-0 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                <div class="md:max-w-[250px] w-full">
                                                    <asp:Label Font-Size="9" Text="Total Line Charges(SGD)" Visible="false" ID="Label3" runat="server" Width="100"></asp:Label>
                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="TxtTotalLineCharges" Visible="false" Text="0.00" TabIndex="198" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                </div>

                                                <div class="md:max-w-[250px] w-full" id="OBLINOUT" runat="server" visible="false">
                                                    <label class="text-gray-500 text-sm font-medium">In MAWB/OBL </label>
                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" Width="275" BackColor="#e8f0fe" ID="TxtInMAWBOBL" OnTextChanged="TxtInMAWBOBL_TextChanged" AutoPostBack="true" runat="server" ValidationGroup="Item" TabIndex="200" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtInMAWBOBL" ID="RegularExpressionValidator51" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>

                                            <div class="mt-0 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2">
                                                <div class="md:max-w-[250px] w-full" id="OBLOUTMAWBL" runat="server" visible="false">
                                                    <label class="text-gray-500 text-sm font-medium">Out MAWB/OBL </label>
                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TxtOutMAWBOBL" OnTextChanged="TxtOutMAWBOBL_TextChanged" AutoPostBack="true" runat="server" ValidationGroup="Item" TabIndex="201" type="text" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtOutMAWBOBL" ID="RegularExpressionValidator52" ValidationExpression="^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                </div>
                                                <div class="md:max-w-[250px] w-full"></div>
                                                <div class="md:max-w-[250px] w-full"></div>
                                                <div class="md:max-w-[250px] w-full"></div>
                                            </div>



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

                                            <div class="modal fade" id="HSCode" role="dialog">
                                                <div class="modal-dialog">

                                                    <!-- Modal content-->
                                                    <div class="modal-content">
                                                        <div class="modal-header">
                                                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                            <h4 class="modal-title">HSCode
                                                            </h4>
                                                        </div>

                                                        <div class="modal-footer">
                                                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>

                                            <div id="SerItemDiv" runat="server" visible="false" class="row">
                                                <div class="col-sm-12">
                                                    <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                                                        ShowSummary="False" ValidationGroup="Item" />
                                                    <p>Serial Number</p>
                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" Width="240" type="text" ID="TxtSerialNo" TabIndex="176"></asp:TextBox>

                                                    <br />




                                                </div>


                                            </div>

                                            <div class="mt-0 flex justify-between items-end gap-4 lg:flex-nowrap flex-wrap mb-2" style="display: none;">
                                                <div class="md:max-w-[250px] w-full">
                                                    <label class="text-gray-500 text-sm font-medium">TxtUnitPrice </label>
                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" Text="0.00" ID="TxtUnitPrice" OnTextChanged="TxtUnitPrice_TextChanged" AutoPostBack="true" Visible="false" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                </div>
                                                <div class="md:max-w-[250px] w-full">
                                                    <label class="text-gray-500 text-sm font-medium">TxtSumExRate </label>
                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="TxtSumExRate" Text="0.00" Visible="false" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                </div>
                                                <div class="md:max-w-[250px] w-full"></div>
                                                <div class="md:max-w-[250px] w-full"></div>
                                            </div>







                                            <div id="PackingInfo" runat="server">
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
                                                        class="duration-300 ease-in-out transition-all hidden">
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
                                            <div class="mt-6" id="LOTID" visible="false" runat="server">
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
                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtCurrentLot" ID="RegularExpressionValidator77" ValidationExpression="^[\s\S]{0,30}$" runat="server" ErrorMessage="Maximum 30 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                            </div>
                                                        </div>
                                                        <div class="md:max-w-[250px] w-full">
                                                            <label class="text-gray-500 text-sm font-medium">Previous Lot</label>
                                                            <div class="relative mt-1">
                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ValidationGroup="Item" ID="TxtPreviousLot" MaxLength="30" TabIndex="169" class="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                                <asp:RegularExpressionValidator placeholder="Type Quantity" Display="Dynamic" BackColor="yellow" ControlToValidate="TxtPreviousLot" ID="RegularExpressionValidator78" ValidationExpression="^[\s\S]{0,30}$" runat="server" ErrorMessage="Maximum 30 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
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
                                            <div id="Tariff" runat="server" visible="false" class="mt-6">
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
                                                <div aria-label="Main" id="drop_draft_2_area" class="duration-300 ease-in-out transition-all">
                                                    <div class="mt-2 flex items-center gap-4 lg:flex-nowrap flex-wrap">
                                                        <div class="md:max-w-[250px] w-full">
                                                            <div class="group relative">
                                                                <div class="text-gray-500 text-sm font-medium">Preferential Code</div>

                                                                <asp:DropDownList CssClass="focus:outline-none bg-slate-100 font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 mt-1 px-4" ID="DrpPreferentialCode" TabIndex="154" OnSelectedIndexChanged="DrpPreferentialCode_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>

                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- Table -->
                                                    <div class="overflow-auto my-shadow whitespace-nowrap border border-gray-100 rounded-tl-lg rounded-tr-lg rounded-bl-lg rounded-br-lg ">






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
                    <asp:CheckBox ID="chk234" TabIndex="155" runat="server" AutoPostBack="true" />
                </div>
                                                                            Auto-Compute Duties &amp; Taxes)
                                                                        </div>
                                                                    </td>

                                                                    <td class="md:px-10 px-4">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full px-3 h-8 bg-slate-100 rounded-md flex items-center disabled:text-slate-300 text-slate-950 focus:outline-none text-[13px] font-medium" autocomplete="off" onkeypress="return isNumberKey(event)" ID="ItemGSTRate" runat="server" TabIndex="156" Text="7"></asp:TextBox>
                                                                    </td>
                                                                    <td class="md:px-10 px-4">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full px-3 h-8 bg-slate-100 rounded-md flex items-center disabled:text-slate-300 text-slate-950 focus:outline-none text-[13px] font-medium" autocomplete="off" ID="ItemGSTUOM" runat="server" TabIndex="157" Text="PER"></asp:TextBox>
                                                                    </td>
                                                                    <td class="md:pr-0 pr-3">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full px-3 h-8 bg-slate-100 rounded-md flex items-center disabled:text-slate-300 text-slate-950 focus:outline-none text-[13px] font-medium" autocomplete="off" onkeypress="return isNumberKey(event)" ID="TxtItemSumGST" runat="server" TabIndex="158" Text="0.00"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr class="my-0">
                                                                    <td class="pr-2">
                                                                        <div class="h-8 px-3 rounded-md flex items-center text-slate-500 pb-2 text-[13px] font-medium pl-8">
                                                                            Excise Duty
                                                                        </div>
                                                                    </td>

                                                                    <td class="md:px-10 px-4">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full px-3 h-8 bg-slate-100 rounded-md flex items-center disabled:text-slate-300 text-slate-950 focus:outline-none text-[13px] font-medium" autocomplete="off" onkeypress="return isNumberKey(event)" ID="TxtExciseDutyRate" runat="server" TabIndex="159" Text="0.00" Enabled="false"></asp:TextBox>
                                                                    </td>
                                                                    <td class="md:px-10 px-4">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full px-3 h-8 bg-slate-100 rounded-md flex items-center disabled:text-slate-300 text-slate-950 focus:outline-none text-[13px] font-medium" autocomplete="off" ID="TxtExciseDutyUOM" runat="server" Enabled="false" TabIndex="157" Text="0.00"></asp:TextBox>
                                                                    </td>
                                                                    <td class="md:pr-0 pr-3">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full px-3 h-8 bg-slate-100 rounded-md flex items-center disabled:text-slate-300 text-slate-950 focus:outline-none text-[13px] font-medium" autocomplete="off" onkeypress="return isNumberKey(event)" ID="TxtSumExciseDuty" runat="server" TabIndex="160" Text="0.00" Enabled="false"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr class="my-0">
                                                                    <td class="pr-2">
                                                                        <asp:Label ID="lblCustomsDuty" Text="Customs Duty" CssClass="h-8 px-3 rounded-md flex items-center text-slate-500 pb-2 text-[13px] font-medium pl-8" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td class="md:px-10 px-4 py-3">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full px-3 h-8 bg-slate-100 rounded-md flex items-center disabled:text-slate-300 text-slate-950 focus:outline-none text-[13px] font-medium" Enabled="false" autocomplete="off" MaxLength="8" onkeypress="return isNumberKey(event)" ID="TxtCustomsDutyRate" runat="server" TabIndex="161" Text="0.00"></asp:TextBox>
                                                                    </td>
                                                                    <td class="md:px-10 px-4 py-3">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full px-3 h-8 bg-slate-100 rounded-md flex items-center disabled:text-slate-300 text-slate-950 focus:outline-none text-[13px] font-medium" Enabled="false" autocomplete="off" ID="TxtCustomsDutyUOM" runat="server" TabIndex="160" Text="0.00"></asp:TextBox>
                                                                    </td>
                                                                    <td class="md:pr-0 pr-3">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full px-3 h-8 bg-slate-100 rounded-md flex items-center disabled:text-slate-300 text-slate-950 focus:outline-none text-[13px] font-medium" Enabled="false" autocomplete="off" onkeypress="return isNumberKey(event)" ID="TxtSumCustomsDuty" runat="server" TabIndex="162" Text="0.00"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr class="my-0">
                                                                    <td class="pr-2">
                                                                        <div class="h-8 px-3 rounded-md flex items-center text-slate-500 pb-2 text-[13px] font-medium pl-8">
                                                                            Other Tax
                                                                        </div>
                                                                    </td>
                                                                    <td class="md:px-10 px-4 pb-2">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="focus:outline-none w-full px-3 h-8 bg-slate-100 rounded-md flex items-center disabled:text-slate-300 text-slate-950 focus:outline-none text-[13px] font-medium" autocomplete="off" onkeypress="return isNumberKey(event)" Enabled="false" ID="TxtOtherTaxRate" runat="server" TabIndex="163" Text="0.00"></asp:TextBox>
                                                                    </td>
                                                                    <td class="md:px-10 px-4 pb-2">
                                                                        <asp:DropDownList CssClass="focus:outline-none w-full px-3 h-8 bg-slate-100 rounded-md flex items-center disabled:text-slate-300 text-slate-950 focus:outline-none text-[13px] font-medium" ID="DrpOtherUOM" Enabled="false" runat="server" TabIndex="164"></asp:DropDownList>
                                                                    </td>
                                                                    <td class="md:pr-0 pr-3 pb-2">
                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="focus:outline-none w-full px-3 h-8 bg-slate-100 rounded-md flex items-center disabled:text-slate-300 text-slate-950 focus:outline-none text-[13px] font-medium" autocomplete="off" onkeypress="return isNumberKey(event)" Enabled="false" ID="TxtSumOtherTaxRate" runat="server" TabIndex="165" Text="0.00"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                    <!-- Table -->
                                                    <!--  -->
                                                </div>
                                            </div>

                                            <div id="ItemCASC" class="panels-table " visible="false" runat="server">
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
                                                    <div>

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
                                                                                        <asp:Button ID="Button4" runat="server" Text="Copy Of HS-Quantity" OnClick="Button2_Click" Visible="false" />
                                                                                        <p><%--<i class='fa fa-search' data-toggle="modal" data-target="#Product2"></i>--%></p>
                                                                                        <cc1:ModalPopupExtender ID="popupinnondec" runat="server" PopupControlID="pnlpc1" TargetControlID="btnpc1"
                                                                                            OkControlID="btnpcYes" CancelControlID="btnpcNo" BackgroundCssClass="modalBackground">
                                                                                        </cc1:ModalPopupExtender>
                                                                                        <asp:Panel ID="pnlpc1" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                                                            <div class="header">
                                                                                                <svg class="cursor-pointer absolute right-5 top-5" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                                                    <circle opacity="0.1" cx="12" cy="12" r="12" fill="#676D7C"></circle>
                                                                                                    <path d="M16.6663 7.3335L7.33301 16.6668M7.33301 7.3335L16.6663 16.6668" stroke="#676D7C" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                                                                                </svg>
                                                                                                <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Product Code 1</p>
                                                                                            </div>

                                                                                            <div class="body">
                                                                                                <asp:UpdatePanel ID="upinnonpc1" runat="server" UpdateMode="Conditional">
                                                                                                    <ContentTemplate>
                                                                                                        <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                                            <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ProductCode1Search" OnTextChanged="ProductCode1Search_TextChanged" AutoPostBack="true" placeholder="Search here by Code" runat="server" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
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
                                                                                                            <asp:GridView ID="ProductCode1Grid" PageSize="5" OnPageIndexChanging="ProductCode1Grid_PageIndexChanging" AllowPaging="True" DataKeyNames="Id" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" OnRowCommand="ProductCode1Grid_RowCommand" OnRowDataBound="ProductCode1Grid_RowDataBound" AutoGenerateColumns="false">
                                                                                                                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                                <Columns>



                                                                                                                    <asp:TemplateField HeaderText="CASCCode" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="Label5" runat="server"
                                                                                                                                Text='<%#Eval("CASCCode")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>

                                                                                                                    <asp:TemplateField HeaderText="Description" SortExpression="Id">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="Label6" runat="server"
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
                                                                                                <asp:Button ID="btnpcNo" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px]  w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                                            </div>
                                                                                        </asp:Panel>


                                                                                        <div class="relative mt-1">
                                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Product Code" CssClass="w-full h-11 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" type="text" ValidationGroup="Productcode" ID="TxtProductCode1" MaxLength="17" OnTextChanged="TxtProductCode1_TextChanged" AutoPostBack="true" TabIndex="147"></asp:TextBox>


                                                                                            <asp:Button ID="btnpc1" TabIndex="22" runat="server" CssClass="absolute right-4 top-3 btn-search-circle-img w-[22px] h-[22px]" Style="background-image: url('./images/circel-search.svg');" />
                                                                                            <%--<img src="" alt="Search" >--%>
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProductCode1" ID="RegularExpressionValidator37" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>
                                                                                        </div>
                                                                                        <div class="flex bg-slate-100 rounded-md md:w-[230px] w-full h-10 mt-2">
                                                                                            <div class="md:w-[125px] w-full">
                                                                                                <div class="relative w-full">


                                                                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" onkeypress="return noAlphabets(event)" runat="server" type="text" ValidationGroup="Productcode" ID="TxtProQty1" MaxLength="16" Text="0.00" TabIndex="159" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

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


                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProQty1" ID="RegularExpressionValidator67" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7a" runat="server" ControlToValidate="TxtHSCodeItem" Font-Size="XX-Small" ForeColor="Red" ErrorMessage="Item --> Please Enter HS Code" ValidationGroup="Item"></asp:RequiredFieldValidator>

                                                                                    </div>
                                                                                    <div class="col-sm-9">


                                                                                        <p style="font-weight: bold">End User Description</p>
                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" Width="100%" runat="server" type="text" ID="EndUserDesp1" AutoPostBack="true" OnTextChanged="EndUserDesp1_TextChanged" ValidationGroup="Productcode" Style="text-transform: uppercase" class="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TextMode="MultiLine" Text="" TabIndex="161"></asp:TextBox>
                                                                                        <br />
                                                                                        <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserDesp1" ID="RegularExpressionValidator48" ValidationExpression="^[\s\S]{0,256}$" runat="server" ErrorMessage="Maximum 256 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>
                                                                                        <br />
                                                                                        <asp:Label ID="lblenddescr" runat="server" Text="CHARACTER COUNT : 0"></asp:Label>

                                                                                        <asp:GridView CssClass="table table-striped table-bordered table-hover" ID="ProductCode1Grid1" runat="server" ShowFooter="true" AutoGenerateColumns="false">
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
                                                                                            <asp:Button ID="btnpc2" runat="server" Text="Copy Of HS-Quantity" OnClick="btnpc2_Click" Visible="false" />
                                                                                            <p><%--<i class='fa fa-search' data-toggle="modal" data-target="#Product2"></i>--%></p>
                                                                                            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="pnlpc2" TargetControlID="btnproductcode"
                                                                                                OkControlID="btnpc2Yes" CancelControlID="btnpc2No" BackgroundCssClass="modalBackground">
                                                                                            </cc1:ModalPopupExtender>
                                                                                            <asp:Panel ID="pnlpc2" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                                                                <div class="header">
                                                                                                    <svg class="cursor-pointer absolute right-5 top-5" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                                                        <circle opacity="0.1" cx="12" cy="12" r="12" fill="#676D7C"></circle>
                                                                                                        <path d="M16.6663 7.3335L7.33301 16.6668M7.33301 7.3335L16.6663 16.6668" stroke="#676D7C" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                                                                                    </svg>
                                                                                                    <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Product Code 2</p>
                                                                                                </div>

                                                                                                <div class="body">
                                                                                                    <asp:UpdatePanel ID="uppc2" runat="server" UpdateMode="Conditional">
                                                                                                        <ContentTemplate>
                                                                                                            <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                                                <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ProductCode2Search" OnTextChanged="ProductCode2Search_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                                                            </div>


                                                                                                            No of Rows:

    <asp:DropDownList ID="ddlpc2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlpc2_SelectedIndexChanged">

        <asp:ListItem>10</asp:ListItem>

        <asp:ListItem>20</asp:ListItem>

        <asp:ListItem>30</asp:ListItem>

        <asp:ListItem>All</asp:ListItem>

    </asp:DropDownList>
                                                                                                            <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                                                                <asp:GridView ID="ProductCode2Grid" PageSize="5" OnPageIndexChanging="ProductCode2Grid_PageIndexChanging" AllowPaging="True" DataKeyNames="Id" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" OnRowCommand="ProductCode2Grid_RowCommand" OnRowDataBound="ProductCode2Grid_RowDataBound" AutoGenerateColumns="false">
                                                                                                                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                                    <Columns>



                                                                                                                        <asp:TemplateField HeaderText="CASCCode" SortExpression="Id">
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:Label ID="Label7" runat="server"
                                                                                                                                    Text='<%#Eval("CASCCode")%>'>
                                                                                                                                </asp:Label>
                                                                                                                            </ItemTemplate>
                                                                                                                        </asp:TemplateField>

                                                                                                                        <asp:TemplateField HeaderText="Description" SortExpression="Id">
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:Label ID="Label8" runat="server"
                                                                                                                                    Text='<%#Eval("Description")%>'>
                                                                                                                                </asp:Label>
                                                                                                                            </ItemTemplate>
                                                                                                                        </asp:TemplateField>
                                                                                                                        <asp:TemplateField HeaderText="UOM" SortExpression="Id">
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:Label ID="Label9" runat="server"
                                                                                                                                    Text='<%#Eval("UOM")%>'>
                                                                                                                                </asp:Label>
                                                                                                                            </ItemTemplate>
                                                                                                                        </asp:TemplateField>

                                                                                                                        <asp:TemplateField>
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
                                                                                                    <asp:Button ID="btnpc2No" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px]  w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                                                </div>
                                                                                            </asp:Panel>


                                                                                            <div class="relative mt-1">
                                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Product Code" CssClass="w-full h-11 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" type="text" ValidationGroup="Productcode" ID="TxtProductCode2" MaxLength="17" OnTextChanged="TxtProductCode1_TextChanged" AutoPostBack="true" TabIndex="124"></asp:TextBox>

                                                                                                <asp:Button ID="btnproductcode" TabIndex="22" runat="server" CssClass="absolute right-4 top-3 btn-search-circle-img w-[22px] h-[22px]" Style="background-image: url('./images/circel-search.svg');" />
                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProductCode2" ID="RegularExpressionValidator69" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>
                                                                                            </div>
                                                                                            <div class="flex bg-slate-100 rounded-md md:w-[230px] w-full h-10 mt-2">
                                                                                                <div class="md:w-[125px] w-full">
                                                                                                    <div class="relative w-full">

                                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" onkeypress="return noAlphabets(event)" ID="TxtProQty2" MaxLength="16" ValidationGroup="Productcode" TabIndex="125" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>

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
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProQty2" ID="RegularExpressionValidator70" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>


                                                                                        </div>
                                                                                        <div class="col-sm-9">

                                                                                            <p>End User Description</p>
                                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" Width="100%" runat="server" type="text" ID="EndUserDesp2" AutoPostBack="true" class="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" OnTextChanged="EndUserDesp2_TextChanged" Style="text-transform: uppercase" ValidationGroup="Productcode" TextMode="MultiLine" Text="" TabIndex="229"></asp:TextBox>
                                                                                            <br />
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserDesp2" ID="RegularExpressionValidator79" ValidationExpression="^[\s\S]{0,256}$" runat="server" ErrorMessage="Maximum 256 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>
                                                                                            <br />
                                                                                            <asp:Label ID="lblenddescr1" runat="server"></asp:Label>

                                                                                            <asp:GridView CssClass="table table-striped table-bordered table-hover" ID="ProductCode2Grid1" runat="server" ShowFooter="true" AutoGenerateColumns="false">
                                                                                                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                <Columns>

                                                                                                    <asp:BoundField DataField="Product Code" HeaderText="Seq." Visible="false" />

                                                                                                    <asp:TemplateField HeaderText="CASC CODE 1">

                                                                                                        <ItemTemplate>

                                                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox1" MaxLength="35" CssClass="w-full h-11 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="127" runat="server"></asp:TextBox>

                                                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" Width="100%" runat="server" type="text" ID="txtEndUserDec2" AutoPostBack="true" ValidationGroup="Productcode" Style="text-transform: uppercase" TextMode="MultiLine" Text="" TabIndex="229"></asp:TextBox>

                                                                                                            <asp:Label ID="endusercount3" Visible="false" runat="server"></asp:Label>
                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtEndUserDec2" ID="RegularExpressionValidator80" ValidationExpression="^[\s\S]{0,256}$" runat="server" ErrorMessage="Maximum 256 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>

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

                                                                                            <p>

                                                                                                <%--<i class='fa fa-search' data-toggle="modal" data-target="#Product3"></i>--%>
                                                                                            </p>
                                                                                            <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" PopupControlID="pnlpc3" TargetControlID="btnpc3"
                                                                                                OkControlID="btnpc3Yes" CancelControlID="btnpc3No" BackgroundCssClass="modalBackground">
                                                                                            </cc1:ModalPopupExtender>
                                                                                            <asp:Panel ID="pnlpc3" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                                                                <div class="header">
                                                                                                    <svg class="cursor-pointer absolute right-5 top-5" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                                                        <circle opacity="0.1" cx="12" cy="12" r="12" fill="#676D7C"></circle>
                                                                                                        <path d="M16.6663 7.3335L7.33301 16.6668M7.33301 7.3335L16.6663 16.6668" stroke="#676D7C" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                                                                                    </svg>
                                                                                                    <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Product Code 3</p>
                                                                                                </div>
                                                                                                <div class="body">
                                                                                                    <asp:UpdatePanel ID="uppc3" runat="server" UpdateMode="Conditional">
                                                                                                        <ContentTemplate>
                                                                                                            <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                                                <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ProductCode3Search" OnTextChanged="ProductCode3Search_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                                                            </div>
                                                                                                            <asp:DropDownList ID="ddlpc3" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlpc3_SelectedIndexChanged">

                                                                                                                <asp:ListItem>10</asp:ListItem>

                                                                                                                <asp:ListItem>20</asp:ListItem>

                                                                                                                <asp:ListItem>30</asp:ListItem>

                                                                                                                <asp:ListItem>All</asp:ListItem>

                                                                                                            </asp:DropDownList>
                                                                                                            <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                                                                <asp:GridView ID="ProductCode3Grid" PageSize="5" OnPageIndexChanging="ProductCode3Grid_PageIndexChanging" AllowPaging="True" DataKeyNames="Id" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" OnRowCommand="ProductCode3Grid_RowCommand" OnRowDataBound="ProductCode3Grid_RowDataBound" AutoGenerateColumns="false">
                                                                                                                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                                    <Columns>



                                                                                                                        <asp:TemplateField HeaderText="CASCCode" SortExpression="Id">
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:Label ID="Label10" runat="server"
                                                                                                                                    Text='<%#Eval("CASCCode")%>'>
                                                                                                                                </asp:Label>
                                                                                                                            </ItemTemplate>
                                                                                                                        </asp:TemplateField>

                                                                                                                        <asp:TemplateField HeaderText="Description" SortExpression="Id">
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:Label ID="Label11" runat="server"
                                                                                                                                    Text='<%#Eval("Description")%>'>
                                                                                                                                </asp:Label>
                                                                                                                            </ItemTemplate>
                                                                                                                        </asp:TemplateField>
                                                                                                                        <asp:TemplateField HeaderText="UOM" SortExpression="Id">
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:Label ID="Label12" runat="server"
                                                                                                                                    Text='<%#Eval("UOM")%>'>
                                                                                                                                </asp:Label>
                                                                                                                            </ItemTemplate>
                                                                                                                        </asp:TemplateField>

                                                                                                                        <asp:TemplateField>
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
                                                                                                    <asp:Button ID="btnpc3No" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px]  w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                                                </div>
                                                                                            </asp:Panel>



                                                                                            <div class="relative mt-1">
                                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Product Code" CssClass="w-full h-11 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" type="text" ValidationGroup="Productcode" ID="TxtProductCode3" MaxLength="17" OnTextChanged="TxtProductCode1_TextChanged" AutoPostBack="true" TabIndex="130"></asp:TextBox>

                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProductCode3" ID="RegularExpressionValidator71" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>
                                                                                                <asp:Button ID="btnpc3" TabIndex="22" runat="server" CssClass="absolute right-4 top-3 btn-search-circle-img w-[22px] h-[22px]" Style="background-image: url('./images/circel-search.svg');" />

                                                                                            </div>
                                                                                            <div class="flex bg-slate-100 rounded-md md:w-[230px] w-full h-10 mt-2">
                                                                                                <div class="md:w-[125px] w-full">
                                                                                                    <div class="relative w-full">

                                                                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" MaxLength="16" ValidationGroup="Productcode" onkeypress="return noAlphabets(event)" ID="TxtProQty3" TabIndex="166" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
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
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProQty3" ID="RegularExpressionValidator72" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>

                                                                                        </div>
                                                                                        <div class="col-sm-9">
                                                                                            <p style="font-weight: bold">End User Description</p>

                                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" Width="100%" runat="server" Style="text-transform: uppercase" type="text" class="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" ID="EndUserDesp3" AutoPostBack="true" OnTextChanged="EndUserDesp3_TextChanged" ValidationGroup="Productcode" TextMode="MultiLine" Text="" TabIndex="168"></asp:TextBox>
                                                                                            <br />
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserDesp3" ID="RegularExpressionValidator39" ValidationExpression="^[\s\S]{0,256}$" runat="server" ErrorMessage="Maximum 256 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>
                                                                                            <br />
                                                                                            <asp:Label ID="lblenddescr2" runat="server"></asp:Label>

                                                                                            <asp:GridView CssClass="table table-striped table-bordered table-hover" ID="ProductCode3Grid1" runat="server" ShowFooter="true" AutoGenerateColumns="false">
                                                                                                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                <Columns>

                                                                                                    <asp:BoundField DataField="RowNumber" HeaderText="Seq." Visible="false" />

                                                                                                    <asp:TemplateField HeaderText="CASC CODE 1">

                                                                                                        <ItemTemplate>

                                                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="TextBox1" MaxLength="35" CssClass="w-full h-11 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" TabIndex="133" runat="server"></asp:TextBox>

                                                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" Width="100%" runat="server" type="text" ID="txtEndUserDec3" AutoPostBack="true" ValidationGroup="Productcode" Style="text-transform: uppercase" TextMode="MultiLine" Text="" TabIndex="229"></asp:TextBox>

                                                                                                            <asp:Label ID="endusercount4" Visible="false" runat="server"></asp:Label>
                                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtEndUserDec3" ID="RegularExpressionValidator81" ValidationExpression="^[\s\S]{0,256}$" runat="server" ErrorMessage="Maximum 256 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>

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
                                                                                            <cc1:ModalPopupExtender ID="ModalPopupExtender3" runat="server" PopupControlID="pnlpc4" TargetControlID="btnpc4"
                                                                                                OkControlID="btnpc4Yes" CancelControlID="btnpc4No" BackgroundCssClass="modalBackground">
                                                                                            </cc1:ModalPopupExtender>
                                                                                            <asp:Panel ID="pnlpc4" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                                                                <div class="header">
                                                                                                    <svg class="cursor-pointer absolute right-5 top-5" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                                                        <circle opacity="0.1" cx="12" cy="12" r="12" fill="#676D7C"></circle>
                                                                                                        <path d="M16.6663 7.3335L7.33301 16.6668M7.33301 7.3335L16.6663 16.6668" stroke="#676D7C" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                                                                                    </svg>
                                                                                                    <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Product Code 4</p>
                                                                                                </div>

                                                                                                <div class="body">
                                                                                                    <asp:UpdatePanel ID="uppc4" runat="server" UpdateMode="Conditional">
                                                                                                        <ContentTemplate>
                                                                                                            <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                                                <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ProductCode4Search" OnTextChanged="ProductCode4Search_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                                                            </div>

                                                                                                            <asp:DropDownList ID="ddlpc4" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlpc4_SelectedIndexChanged">

                                                                                                                <asp:ListItem>10</asp:ListItem>

                                                                                                                <asp:ListItem>20</asp:ListItem>

                                                                                                                <asp:ListItem>30</asp:ListItem>

                                                                                                                <asp:ListItem>All</asp:ListItem>

                                                                                                            </asp:DropDownList>

                                                                                                            <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                                                                <asp:GridView ID="ProductCode4Grid" PageSize="5" OnRowCommand="ProductCode4Grid_RowCommand" OnRowDataBound="ProductCode4Grid_RowDataBound" OnPageIndexChanging="ProductCode4Grid_PageIndexChanging" AllowPaging="True" DataKeyNames="Id" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" AutoGenerateColumns="false">
                                                                                                                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                                    <Columns>



                                                                                                                        <asp:TemplateField HeaderText="CASCCode" SortExpression="Id">
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:Label ID="Label13" runat="server"
                                                                                                                                    Text='<%#Eval("CASCCode")%>'>
                                                                                                                                </asp:Label>
                                                                                                                            </ItemTemplate>
                                                                                                                        </asp:TemplateField>

                                                                                                                        <asp:TemplateField HeaderText="Description" SortExpression="Id">
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:Label ID="Label14" runat="server"
                                                                                                                                    Text='<%#Eval("Description")%>'>
                                                                                                                                </asp:Label>
                                                                                                                            </ItemTemplate>
                                                                                                                        </asp:TemplateField>
                                                                                                                        <asp:TemplateField HeaderText="UOM" SortExpression="Id">
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:Label ID="Label15" runat="server"
                                                                                                                                    Text='<%#Eval("UOM")%>'>
                                                                                                                                </asp:Label>
                                                                                                                            </ItemTemplate>
                                                                                                                        </asp:TemplateField>

                                                                                                                        <asp:TemplateField>
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
                                                                                                    <asp:Button ID="btnpc4No" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px]  w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                                                </div>
                                                                                            </asp:Panel>


                                                                                            <div class="relative mt-1">
                                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Product Code" CssClass="w-full h-11 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" type="text" ValidationGroup="Productcode" ID="TxtProductCode4" MaxLength="17" OnTextChanged="TxtProductCode1_TextChanged" AutoPostBack="true" TabIndex="241"></asp:TextBox>

                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProductCode4" ID="RegularExpressionValidator73" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>
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
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProQty4" onkeypress="return noAlphabets(event)" ID="RegularExpressionValidator40" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>

                                                                                        </div>
                                                                                        <div class="col-sm-9">
                                                                                            <p style="font-weight: bold">End User Description</p>

                                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" Width="100%" class="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server" type="text" Style="text-transform: uppercase" ID="EndUserDesp4" AutoPostBack="true" OnTextChanged="EndUserDesp4_TextChanged" ValidationGroup="Productcode" TextMode="MultiLine" Text="" TabIndex="175"></asp:TextBox>
                                                                                            <br />
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserDesp4" ID="RegularExpressionValidator41" ValidationExpression="^[\s\S]{0,256}$" runat="server" ErrorMessage="Maximum 256 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>

                                                                                            <br />
                                                                                            <asp:Label ID="lblenddescr3" runat="server"></asp:Label>

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


                                                                                            <cc1:ModalPopupExtender ID="ModalPopupExtender4" runat="server" PopupControlID="pnlpc5" TargetControlID="btnpc5"
                                                                                                OkControlID="btnpc5Yes" CancelControlID="btnpc5No" BackgroundCssClass="modalBackground">
                                                                                            </cc1:ModalPopupExtender>
                                                                                            <asp:Panel ID="pnlpc5" runat="server" CssClass="modalPopup md:max-w-[890px] w-full rounded-2xl px-6 py-5 relative bg-white " Style="display: none">
                                                                                                <div class="header">
                                                                                                    <svg class="cursor-pointer absolute right-5 top-5" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                                                                        <circle opacity="0.1" cx="12" cy="12" r="12" fill="#676D7C"></circle>
                                                                                                        <path d="M16.6663 7.3335L7.33301 16.6668M7.33301 7.3335L16.6663 16.6668" stroke="#676D7C" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path>
                                                                                                    </svg>
                                                                                                    <p class="text-center text-slate-950 text-lg sa700 lg:pt-1 pt-40">Product Code 5</p>
                                                                                                </div>

                                                                                                <div class="body">

                                                                                                    <asp:UpdatePanel ID="uppc5" runat="server" UpdateMode="Conditional">
                                                                                                        <ContentTemplate>
                                                                                                            <div class="bg-[#F4F6FA] text-left m-4 p-4">
                                                                                                                <label class="text-gray-500 text-sm font-medium">Code</label>
                                                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="ProductCode5Search" OnTextChanged="ProductCode5Search_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="login-input w-full h-10 bg-[#DFE3EB] rounded-lg flex items-center appearance-none text-slate-950 text-sm font-medium outline-none border-none px-4" runat="server"></asp:TextBox>
                                                                                                            </div>

                                                                                                            <asp:DropDownList ID="ddlpc5" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlpc5_SelectedIndexChanged">

                                                                                                                <asp:ListItem>10</asp:ListItem>

                                                                                                                <asp:ListItem>20</asp:ListItem>

                                                                                                                <asp:ListItem>30</asp:ListItem>

                                                                                                                <asp:ListItem>All</asp:ListItem>

                                                                                                            </asp:DropDownList>

                                                                                                            <div class="bg-[#F4F6FA] rounded-xl px-6 py-4 mt-6 m-4">
                                                                                                                <asp:GridView ID="ProductCode5Grid" PageSize="5" OnPageIndexChanging="ProductCode5Grid_PageIndexChanging" AllowPaging="True" DataKeyNames="Id" CssClass="w-full bg-transparent rounded whitespace-nowrap table-bordered" runat="server" OnRowCommand="ProductCode5Grid_RowCommand" OnRowDataBound="ProductCode5Grid_RowDataBound" AutoGenerateColumns="false">
                                                                                                                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                                                                                    <Columns>



                                                                                                                        <asp:TemplateField HeaderText="CASCCode" SortExpression="Id">
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:Label ID="Label16" runat="server"
                                                                                                                                    Text='<%#Eval("CASCCode")%>'>
                                                                                                                                </asp:Label>
                                                                                                                            </ItemTemplate>
                                                                                                                        </asp:TemplateField>

                                                                                                                        <asp:TemplateField HeaderText="Description" SortExpression="Id">
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:Label ID="Label17" runat="server"
                                                                                                                                    Text='<%#Eval("Description")%>'>
                                                                                                                                </asp:Label>
                                                                                                                            </ItemTemplate>
                                                                                                                        </asp:TemplateField>
                                                                                                                        <asp:TemplateField HeaderText="UOM" SortExpression="Id">
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:Label ID="Label18" runat="server"
                                                                                                                                    Text='<%#Eval("UOM")%>'>
                                                                                                                                </asp:Label>
                                                                                                                            </ItemTemplate>
                                                                                                                        </asp:TemplateField>

                                                                                                                        <asp:TemplateField>
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
                                                                                                    <asp:Button ID="btnpc5No" runat="server" Text="Close" CssClass="duration-300 ease-in-out md:max-w-[80px]  w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" />
                                                                                                </div>
                                                                                            </asp:Panel>


                                                                                            <div class="relative mt-1">
                                                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" placeholder="Product Code" CssClass="w-full h-11 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" type="text" ValidationGroup="Productcode" ID="TxtProductCode5" MaxLength="17" OnTextChanged="TxtProductCode1_TextChanged" AutoPostBack="true" TabIndex="142"></asp:TextBox>

                                                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProductCode5" ID="RegularExpressionValidator75" ValidationExpression="^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>
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
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="TxtProQty5" onkeypress="return noAlphabets(event)" ID="RegularExpressionValidator46" ValidationExpression="^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>

                                                                                        </div>
                                                                                        <div class="col-sm-9">
                                                                                            <p style="font-weight: bold">End User Description</p>
                                                                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" Width="100%" runat="server" Style="text-transform: uppercase" type="text" class="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" ID="EndUserDesp5" AutoPostBack="true" OnTextChanged="EndUserDesp5_TextChanged" ValidationGroup="Productcode" TextMode="MultiLine" Text="" TabIndex="182"></asp:TextBox>
                                                                                            <br />
                                                                                            <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="EndUserDesp5" ID="RegularExpressionValidator82" ValidationExpression="^[\s\S]{0,256}$" runat="server" ErrorMessage="Maximum 256 characters allowed." ValidationGroup="Productcode"></asp:RegularExpressionValidator>


                                                                                            <br />
                                                                                            <asp:Label ID="lblenddescr4" runat="server"></asp:Label>

                                                                                            <asp:GridView CssClass="table table-striped table-bordered table-hover" ID="ProductCode5Grid1" runat="server" ShowFooter="true" AutoGenerateColumns="false">
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
                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtShippingMarks3" ID="RegularExpressionValidator54" ValidationExpression="^[\s\S]{0,136}$" runat="server" ErrorMessage="Maximum 136 characters allowed." ValidationGroup="Shipping"></asp:RegularExpressionValidator>
                                                            </div>
                                                        </div>
                                                        <div class="w-full">
                                                            <label class="text-gray-500 text-sm font-medium">Shipping Marks 4</label>
                                                            <div class="relative mt-1">
                                                                <asp:TextBox onkeyup="toUpperCaseText(this)" class="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" Width="250" Height="130" type="text" ID="txtShippingMarks4" ValidationGroup="Shipping" TabIndex="173" TextMode="MultiLine" Style="text-transform: uppercase"></asp:TextBox>
                                                                <br />
                                                                <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="txtShippingMarks4" ID="RegularExpressionValidator61" ValidationExpression="^[\s\S]{0,36}$" runat="server" ErrorMessage="Maximum 36 characters allowed." ValidationGroup="Shipping"></asp:RegularExpressionValidator>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!--  -->
                                                </div>
                                            </div>

                                            <asp:Button ID="BtnItemAdd" CssClass="btn btn-block btn-success" ValidationGroup="Item" runat="server" Visible="false" Text="Add Item" OnClick="BtnItemAdd_Click1" />

                                        </div>

                                        <center>

                                            <div class="row">



                                                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <div class="card card-body flex justify-between gap-2 items-center mt-6">
                                                            <h2 class="text-lg sa700 leading-[18px] text-gray-800"></h2>
                                                        </div>
                                                        <div class="flex lg:flex-nowrap flex-wrap gap-4  items-start">
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
                                                                    <asp:Label runat="server" ID="Label19" />
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

                                            </div>

                                         
                                        </center>

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
                                            <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" ID="AddItemSearch" OnTextChanged="AddItemSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code" class="form-control" runat="server"></asp:TextBox>
                                            <br />




                                            <asp:GridView ID="AddItemGrid" Font-Size="10" OnRowDeleting="AddItemGrid_RowDeleting" PageSize="50" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="AddItemGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Del">
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

                                                    <asp:TemplateField HeaderText="IN HAWB/OBL" SortExpression="Id">
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

                                        <div class="flex justify-end gap-4">
                                            <asp:Button ID="btnsaveitem" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] bg-opacity-10 border hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-[#0560FD] text-center rounded-md text-sm sa700" runat="server" class="btn btn-info btn-lg" ValidationGroup="Item" OnClick="btnsaveitem_Click" Text="+ Add Item" TabIndex="175" />
                                        </div>


                                           <div class="flex justify-between gap-4 md:flex-nowrap flex-wrap mt-6 mb-6">
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

                        <cc1:TabPanel ID="TabPanel1" runat="server" CssClass="nn" HeaderText="CPC">
                            <ContentTemplate>
                                <asp:UpdatePanel ID="transhipcpc" UpdateMode="Conditional" runat="server">
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


                        <cc1:TabPanel ID="Summary" runat="server" HeaderText="Summary">
                            <ContentTemplate>
                                <asp:UpdatePanel ID="transhipsummery" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>

                                        <asp:ValidationSummary ID="ValidationSummary16" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="Summery" />


                                        <div class="flex justify-between gap-2 items-center mt-7">
                                            <h2 class="text-lg sa700 leading-[18px] text-gray-800">Summary
                                            </h2>
                                            <div class="md:max-w-[250px] flex justify-end w-full md:mt-5" >
                                                <div class="flex gap-2 items-center" style="display:none;">
                                                    <%--<input class="styled-checkbox-1" id="styled-checkbox-86" type="checkbox" value="value1">--%>
                                                    <asp:CheckBox ID="chkAuto" Enabled="false" AutoPostBack="true" TabIndex="193" runat="server" CssClass="text-gray-500 text-sm" />
                                                    <label class="text-gray-500 text-sm font-medium">Auto Complete</label>

                                                </div>
                                            </div>
                                        </div>

                                        <div class=" flex justify-between items-end gap-4 flex-wrap mb-2">
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
                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" Enabled="false" Text="0.00" ForeColor="red" Font-Names="verdana" Font-Size="small" Font-Bold="true" type="text" ID="txtitmAmt" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
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
                                                    <div id="div2" class="invoice_div" style="color: red;" runat="server"></div>
                                                    <asp:TextBox onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" Visible="false" Text="0.00" type="text" ID="txtinvAmt" TabIndex="1" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="md:max-w-[250px] w-full">
                                                <label class="text-gray-500 text-sm font-medium">Sum of Item Amount</label>
                                                <div class="relative mt-1">
                                                    <div id="div1" runat="server"></div>
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


                                        <!-- Row with Flex Settings -->
                                        <div class="flex flex-wrap md:flex-nowrap items-start gap-4  mb-2">

                                            <!-- Trader's Remarks Label -->
                                            <div class="w-full md:w-1/3">
                                                <label class="text-sm text-gray-700 font-medium uppercase">
                                                    Trader's Remarks (Will be submitted to Singapore Customs)
                                                </label>
                                            </div>

                                            <!-- Append Invoice Number Button -->
                                            <div class="w-full md:w-1/3">
                                                <asp:Button ID="btninvnum" runat="server" TabIndex="195" Text="Append Invoice Number"
                                                    CssClass="mt-1 w-full h-10 bg-[#0560FD] bg-opacity-5 rounded-md text-[#0560FD] text-sm font-medium sa700 border-none px-4"
                                                    OnClick="btninvnum_Click" />
                                            </div>

                                             <div class="w-full md:w-1/3">
     <asp:Button ID="BtnPPN" OnClick="BtnPPN_Click" CssClass="relative mt-1 w-full h-10 bg-[#0560FD] bg-opacity-5 rounded-md flex items-center text-[#0560FD] text-sm font-medium outline-none border-none sa700 px-4" TabIndex="195" runat="server" Text="Append Previous Permit NO" />
 </div>

                                            <!-- Append Exchange Rate Button -->
                                            <div class="w-full md:w-1/3">
                                                <asp:Button ID="Button3" runat="server" TabIndex="196" Text="Append Exchange Rate"
                                                    CssClass="mt-1 w-full h-10 bg-[#0560FD] bg-opacity-5 rounded-md text-[#0560FD] text-sm font-medium sa700 border-none px-4"
                                                    OnClick="Button3_Click" />
                                            </div>

                                            <!-- Cross Reference -->

                                            <div class="w-full md:w-1/3 mt-[-13px]">
                                                <label class="text-gray-500 text-sm font-medium">Cross Reference</label>
                                                <asp:TextBox onkeyup="toUpperCaseText(this)" ID="TxtGrossReference" runat="server" autocomplete="off" type="text"
                                                    CssClass="mt-1 w-full h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium border-none px-4" />


                                            </div>
                                        </div>

                                        <!-- Invoice Number Field -->
                                     <%--   <div class="mt-3">
                                            <label class="text-gray-500 text-sm font-medium">Invoice Number</label>
                                            <input placeholder="Type Number" type="text" id="txtInvoiceNum"
                                                class="mt-1 w-full h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium border-none px-4" />
                                        </div>--%>

                                         <div class="mt-3">
     <label class="text-gray-500 text-sm font-medium">Trader Remarks</label>



     <asp:TextBox onkeyup="toUpperCaseText(this)" ID="txttrdremrk" runat="server" TextMode="MultiLine" TabIndex="197"
         MaxLength="1024" AutoPostBack="true" OnTextChanged="txttrdremrk_TextChanged" ValidationGroup="Summery" autocomplete="off" Height="70"
         CssClass="mt-1 w-full bg-slate-100 rounded-md text-slate-950 text-sm font-medium border-none px-4" />
     <asp:RegularExpressionValidator ID="RegularExpressionValidator84" runat="server"
         ControlToValidate="txttrdremrk" ValidationExpression="^[\s\S]{0,1024}$"
         ErrorMessage="Maximum 1024 characters allowed." Display="Dynamic" BackColor="yellow"
         ValidationGroup="Summery" />

     <asp:Label ID="lbltracunt"  ForeColor="Navy" runat="server" />

     <asp:Label ID="lbltradecount" runat="server" Font-Size="Medium" />
 </div>

                                        <!-- Internal Reference -->
                                        <div class="mt-3">
                                            <label class="text-gray-500 text-sm font-medium">Internal Reference</label>
                                            <asp:TextBox onkeyup="toUpperCaseText(this)" ID="txtintremrk" runat="server" TabIndex="198" autocomplete="off" placeholder="Type"
                                                CssClass="mt-1 w-full h-10 bg-slate-100 rounded-md text-slate-950 text-sm font-medium border-none px-4" />
                                        </div>

                                        <!-- Trader Remarks Multi-line Field -->
                                       


                                        <h2 class="text-lg sa700 leading-[18px] text-gray-800 ">Declaration Summary</h2>

                                        <div class="mt-5 grid grid-cols-1 md:grid-cols-2 gap-x-6 gap-y-5 mb-2">

                                            <div>
                                                <label class="text-gray-500 text-sm font-medium">Importer</label>
                                                <div>
                                                    <asp:Label ID="lblimporterparty" runat="server" CssClass="text-slate-950 text-base sa700 mt-2"></asp:Label>
                                                </div>
                                            </div>

                                            <div>
                                                <label class="text-gray-500 text-sm font-medium">Handling Agent</label>
                                                <div>
                                                    <asp:Label ID="LblHandAgent" runat="server" CssClass="text-slate-950 text-base sa700 mt-2"></asp:Label>
                                                </div>
                                            </div>

                                            <div>
                                                <label class="text-gray-500 text-sm font-medium">In - OBL</label>
                                                <div>
                                                    <asp:Label ID="lbloblval" runat="server" CssClass="text-slate-950 text-base sa700 mt-2"></asp:Label>
                                                </div>
                                            </div>

                                            <div>
                                                <label class="text-gray-500 text-sm font-medium">In - HBL</label>
                                                <div>
                                                    <asp:Label ID="lblhblValue" runat="server" CssClass="text-slate-950 text-base sa700 mt-2"></asp:Label>
                                                </div>
                                            </div>

                                            <div>
                                                <label class="text-gray-500 text-sm font-medium">Out - OBL</label>
                                                <div>
                                                    <asp:Label ID="lbloutobl" runat="server" CssClass="text-slate-950 text-base sa700 mt-2"></asp:Label>
                                                </div>
                                            </div>

                                            <div>
                                                <label class="text-gray-500 text-sm font-medium">Out - HBL</label>
                                                <div>
                                                    <asp:Label ID="lblouthbl" runat="server" CssClass="text-slate-950 text-base sa700 mt-2"></asp:Label>
                                                </div>
                                            </div>

                                            <div>
                                                <label class="text-gray-500 text-sm font-medium">Number of Packing</label>
                                                <div>
                                                    <asp:Label ID="lblnoofpack" runat="server" CssClass="text-slate-950 text-base sa700 mt-2"></asp:Label>
                                                </div>
                                            </div>

                                            <div>
                                                <label class="text-gray-500 text-sm font-medium">Total Gross Weight</label>
                                                <div>
                                                    <asp:Label ID="lblgrossweight" runat="server" CssClass="text-slate-950 text-base sa700 mt-2"></asp:Label>
                                                </div>
                                            </div>

                                            <div>
                                                <label class="text-gray-500 text-sm font-medium">Total Outer Pack</label>
                                                <div class="text-slate-950 text-base sa700 mt-2">3</div>
                                            </div>

                                            <div>
                                                <label class="text-gray-500 text-sm font-medium">Invoice Amount</label>
                                                <div>
                                                    <asp:Label ID="lblinvoiceAmt" runat="server" CssClass="text-slate-950 text-base sa700 mt-2"></asp:Label>
                                                </div>
                                            </div>

                                            <div>
                                                <label class="text-gray-500 text-sm font-medium">Total Item GST</label>
                                                <div>
                                                    <asp:Label ID="lblTotItemGst" runat="server" CssClass="text-slate-950 text-base sa700 mt-2"></asp:Label>
                                                </div>
                                            </div>

                                        </div>


                                        <asp:Label ID="lblerror" runat="server" Visible="false" BackColor="Brown" BorderStyle="Solid" BorderWidth="1px" ForeColor="White" Width="80%" Font-Size="Medium" Font-Bold="true"></asp:Label>

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

                                    </ContentTemplate>
                                    <%-- <Triggers>
                                    <asp:PostBackTrigger ControlID="btnprevsum" />
                                    <asp:PostBackTrigger ControlID="btnnextsum" />

                                </Triggers>--%>
                                </asp:UpdatePanel>
                            </ContentTemplate>
                        </cc1:TabPanel>

                        <cc1:TabPanel ID="Amend" runat="server" CssClass="nn" Visible="false" HeaderText="Amend">
                            <ContentTemplate>
                                <asp:UpdatePanel ID="transhipamend" UpdateMode="Conditional" runat="server">
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
                                                        <asp:TextBox
                                                            CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="txtamoundcount" Text="1" Enabled="false" TabIndex="236"></asp:TextBox>
                                                        <br />
                                                        <p>Update Indicator</p>
                                                        <asp:TextBox
                                                            CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="txtupdateindicator" TabIndex="237"></asp:TextBox>
                                                        <br />
                                                    </div>
                                                    <div class="col-sm-6">
                                                        <p>Permit Number</p>
                                                        <asp:TextBox
                                                            CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="txtamendpermit" TabIndex="238"></asp:TextBox>
                                                        <br />
                                                        <p>Replacement Permit Number</p>
                                                        <asp:TextBox
                                                            CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" type="text" ID="txtreplacepermit" TabIndex="239"></asp:TextBox>
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
                                                <asp:TextBox
                                                    CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" TextMode="MultiLine" Width="100%" type="text" ID="txtdescreason" TabIndex="240"></asp:TextBox>
                                                <br />
                                                <asp:CheckBox ID="ChkPermitvalEx" runat="server" Text="Permit Validity Extension" />
                                                <br />
                                                <p>Extend Import Period (Reason for Extension of validity for Temporary / Exhibit Cargoes)</p>
                                                <asp:TextBox
                                                    CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" onkeyup="toUpperCaseText(this)" autocomplete="off" runat="server" TextMode="MultiLine" Width="100%" type="text" ID="txtvalidity" TabIndex="241"></asp:TextBox>
                                                <br />
                                                <br />
                                                <div class="row " style="width: 100%">
                                                    <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-6">
                                                        <span class="text-white text-sm font-semibold tracking-wide">Declaration Indicator</span>
                                                    </div>

                                                </div>
                                                <div class="alert alert-danger" id="AmendInd" runat="server" visible="false">
                                                    <asp:CheckBox ID="chkdec" runat="server" Checked="false" TabIndex="242" />
                                                    <strong></strong>I/We declare that all particulars in this application are true and correct
                                                </div>
                                            </div>
                                        </div>

                                        <center>
                                            <div class="btn-group btn-group-lg" id="Amendbtn" runat="server" visible="false">
                                                <asp:Button ID="btnsaveamend" CssClass="btn duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" runat="server" class="btn btn-info btn-lg" OnClick="btnsaveamend_Click" Text="Save" TabIndex="243" />
                                            </div>
                                        </center>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </ContentTemplate>
                        </cc1:TabPanel>

                        <cc1:TabPanel ID="Cancel" runat="server" CssClass="nn" Visible="false" HeaderText="Cancel">
                            <ContentTemplate>
                                <asp:UpdatePanel ID="transhipcancelcancel" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-sm-12">
                                                  <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-7">
      <span class="text-white text-sm font-semibold tracking-wide">Update Information</span>

  </div>
                                               
                                                <div class="row">
                                                    <div class="col-sm-4">
                                                        <p>Update Indicator</p>
                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" type="text" ID="txtupdateInd" TabIndex="244"></asp:TextBox>
                                                        <br />


                                                    </div>
                                                    <div class="col-sm-4">
                                                        <p>Permit Number</p>
                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" type="text" ID="txtcanPermit" TabIndex="245"></asp:TextBox>
                                                        <br />
                                                       
                                                    </div>
                                                     <div class="col-sm-4">
                                                          <p>Replacement Permit Number</p>
 <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" type="text" ID="txtcanrepPermit" TabIndex="246"></asp:TextBox>
 <br />
                                                     </div>
                                                </div>

                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">  <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-7">
      <span class="text-white text-sm font-semibold tracking-wide">Cancellation Information</span>

  </div>
                                           
                                            <div class="col-sm-6">
                                                <p>Reason For Cancellation</p>
                                                <asp:DropDownList  CssClass="focus:outline-none bg-slate-100 font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 px-4" ID="DrpReasonCancel"  runat="server" TabIndex="247"></asp:DropDownList>
                                            </div>
                                            <div class="col-sm-6">
                                                <p>Description For Reason</p>
                                                <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" runat="server" TextMode="MultiLine" Width="100%" type="text" ID="txtdesReason" TabIndex="248"></asp:TextBox>
                                                <br />
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-sm-12" id="Div10" runat="server">

                                                <div class="row">


                                                    <div class="col-sm-12">  <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-7">
      <span class="text-white text-sm font-semibold tracking-wide">  Referance Document</span>

  </div>
                                                       

                                                        <div class="row">
                                                            <div class="col-sm-5">
                                                                <p>Document Type</p>
                                                                <asp:DropDownList  CssClass="focus:outline-none bg-slate-100 font-normal rounded-md text-xs text-slate-400 p-2 text-left inline-flex items-center w-full h-10 px-4" ID="DrpDocumenttype"  Width="250" AppendDataBoundItems="true" TabIndex="249" runat="server">
                                                                </asp:DropDownList>
                                                                <br />
                                                                <%--<asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator27" runat="server" ControlToValidate="DrpDocumenttype" InitialValue="0" ErrorMessage="Header --> Doc Type" ValidationGroup="Validationbtn"></asp:RequiredFieldValidator>--%>
                                                            </div>
                                                            <div class="col-sm-5">
                                                                <p>Uplaod Document</p>
                                                                <asp:FileUpload ID="FileUpload2"  runat="server" class="btn" AllowMultiple="true" />
                                                                <%--<asp:RequiredFieldValidator BackColor="Red" ID="RequiredFieldValidator67" runat="server" ControlToValidate="FileUpload1" ErrorMessage="Header -->Upload Doc" ValidationGroup="Validationbtn"></asp:RequiredFieldValidator>--%>
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <p>Uplaod</p>
                                                                <asp:Button runat="server" ID="BtnCancelUp" ValidationGroup="Validationbtn" class="btn btn-success" Text="Upload" OnClick="BtnCancelUp_Click" />

                                                            </div>
                                                        </div>


                                                        <hr />
                                                        <asp:GridView ID="GridCancelDoc" PageSize="5" OnRowDeleting="GridCancelDoc_RowDeleting" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="GridCancelDoc_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server"
                                                            AutoGenerateColumns="false">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Delete">
                                                                    <ItemTemplate>

                                                                        <asp:LinkButton data-target='<%#"#"+DataBinder.Eval(Container.DataItem,"Id")%>' Width="11" OnClick="CancelDocDelete_Click" Height="11" ID="CancelDocDelete" runat="server"><i class='fa fa-trash' style="color:red;"> </i></asp:LinkButton>



                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="DocumentType" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDocType" runat="server" Text='<%#Eval("DocumentType")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Name" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name")%>'>
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
                                            <div class="col-sm-12">  <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-7">
      <span class="text-white text-sm font-semibold tracking-wide">ADDITIONAL RECIPIENTS</span>

  </div>
                                               
                                                <br />
                                                <div class="row">
                                                    <div class="col-sm-4">
                                                        <p>RECIPIENTS 1</p>
                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" ID="TextBox15" Width="265" runat="server" TabIndex="250" type="text"></asp:TextBox>

                                                        <br />
                                                    </div>
                                                    <div class="col-sm-4">
                                                        <p>RECIPIENTS 2</p>
                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" ID="TextBox16" Width="265" runat="server" TabIndex="251" type="text"></asp:TextBox>

                                                        <br />
                                                    </div>
                                                    <div class="col-sm-4">
                                                        <p>RECIPIENTS 3</p>
                                                        <asp:TextBox onkeyup="toUpperCaseText(this)" CssClass="w-full h-10 bg-slate-100 rounded-md flex items-center text-slate-950 text-sm font-medium outline-none border-none px-4" autocomplete="off" ID="TextBox17" Width="265" runat="server" TabIndex="252" type="text"></asp:TextBox>

                                                        <br />
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-sm-12">  <div class="w-full bg-gray-700 text-center rounded-full py-2 mt-7">
      <span class="text-white text-sm font-semibold tracking-wide">Declarent Indicator</span>

  </div>
                                                <div class="alert alert-danger" id="CancelInd" runat="server" visible="false">
                                                    <asp:CheckBox ID="CheckBox4" runat="server" Checked="false" TabIndex="268" />
                                                    <strong></strong>I/We declare that all particulars in this application are true and correct
                                                </div>

                                            </div>
                                        </div>

                                        <center>
                                            <div class="btn-group btn-group-lg" id="CancelBtn" runat="server" visible="false">

                                                <asp:Button ID="btnsavecancel"  CssClass="btn duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700"  runat="server" class="btn btn-info btn-lg" OnClick="btnsavecancel_Click" Text="Save" TabIndex="277" />


                                            </div>
                                        </center>
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

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
