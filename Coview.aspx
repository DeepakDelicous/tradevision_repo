<%@ Page Title="" ClientIDMode ="AutoID" Language="C#" MasterPageFile="~/Home.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Coview.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="RET.Coview"  ValidateRequest="false" %>

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
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="co">
<ProgressTemplate>
<div class="overlay">
<div style=" z-index: 1000; margin-top:300px; opacity: 1; -moz-opacity: 1;">
    <center>
<img alt="" src="Loader.gif" width="100" height="100" /></center>
</div>
</div>
</ProgressTemplate>
</asp:UpdateProgress>
    <asp:UpdatePanel ID="co" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
             <div class="row top-pad" style="margin-top: -17px;">
            <%--    <div class="col-md-12">
                    <ol class="breadcrumb">
                        <li class="active"><i class="fa fa-dashboard"></i>&nbsp;&nbsp;CO</li>
                    </ol>
                </div>--%>
            </div>
            <div class="container">
               
                <div class="row">

                    <%-- <div class="container bootstrap snippet">
            <div class="row top-pad">
                <div class="col-md-12">
                    <ol class="breadcrumb">
                        
                    </ol>
                </div>
            </div>
        </div>   --%>

                    <div class="row">
                        <div class="col-md-12 col-lg-12 col-sm-12    ">
                            <div class="modal fade" id="Error" role="dialog">
                                <div class="modal-dialog">
                                </div>
                            </div>



                            <div class="btn-group">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                    ShowSummary="False" ValidationGroup="Validation" />
                                <asp:Button ValidationGroup="Validation" ID="BtnSaveDraft" Visible="false" class="btn1 " runat="server" OnClientClick="$('li:eq(2)', $('.nav-tabs')).tab('show')" OnClick="BtnSaveDraft_Click" Text="Save As Draft" />

                                <button type="button" class="btn1  " runat="server" visible="false">Save As Final</button>
                                <button type="button" class="btn1 " runat="server" visible="false">Save and Submit</button>
                            </div>
                           
                          <%--  <div class="btn-group">
                                <button type="button" class="btn1 btn-primary">Download Template</button>
                                <button type="button" class="btn1 btn-primary">Upload Data</button>
                                <button type="button" class="btn1 btn-primary">Download Data</button>

                            </div>--%>
                            <div class="btn-group">
                                <button type="button" class="btn1 btn-primary" runat="server" visible="false">Load Data</button>


                            </div>
                            <div class="btn-group">
                                <button type="button" class="btn1 btn-primary" runat="server" visible="false">Print Status</button>
                                <button type="button" class="btn1 btn-primary" runat="server" visible="false">Print Draft CCP</button>
                                <button type="button" class="btn1 btn-primary" runat="server" visible="false">Print CIF</button>

                            </div>
                            <div class="btn-group pull-right">
                                 <asp:Button ID="BtnExit" runat="server" class="btn1 btn-danger" Visible="false" OnClick="BtnExit_Click" Text="Exit Form" />


                            </div>
                        </div>
                    </div>



                    
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
                    <div class="flex flex-col justify-center items-center relative" id="divItem" runat="server" onclick="openTab(5)" style="cursor: pointer;" >
                        <div class="text-center text-gray-500 md:text-base text-[10px] mb-2">
                            Item

                        </div>
                        <div class="w-[14px] h-[14px] bg-transparent border-2 border-[#BCBCC3] rounded-full relative">
                            <div class="after:absolute lg:after:w-[110px] md:after:w-[45px] after:w-[12px] after:h-[2px] after:bg-[#F4F6FA] after:top-0 after:bottom-0 after:my-auto after:left-3"></div>
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

                                               

<cc1:TabContainer ID="TabContainer1" AutoPostBack="true" runat="server" ActiveTabIndex="0" CssClass="Tab" style="margin-top: 50px;" OnActiveTabChanged="TabContainer1_ActiveTabChanged" OnLoad="TabContainer1_ActiveTabChanged" >
   <%-- <div role="tabpanel" class="tab-pane fade in active" id="Header">--%>
<cc1:TabPanel ID="Header" CssClass="ajax__tab_header" runat="server" HeaderText="Header">
                                                            
                                                            <ContentTemplate>

 <asp:UpdatePanel ID ="coheader" UpdateMode ="Conditional" runat ="server">
           <ContentTemplate>

        <div class="row">
              <div class="col-sm-6">
<div class="form-group row">
    <label for="staticEmail" class="col-sm-3 col-form-label">Message Type
</label>
    <div class="col-sm-9">
        <asp:TextBox autocomplete="off"  ID="TxtMsgType" Text="COODEC" runat="server"  Width="350" TabIndex="1" type="text" Enabled="false"></asp:TextBox>
    </div>
  </div>
                  <div class="form-group row">
    <label for="staticEmail" class="col-sm-3 col-form-label">Application Type

</label>
    <div class="col-sm-9">
          <asp:TextBox autocomplete="off"  ID="TxtAppType" Text="COO" runat="server"  Enabled="false" Width="350" TabIndex="2" type="text" ></asp:TextBox>
    </div>
  </div>
                  <div class="form-group row">
    <label for="staticEmail" class="col-sm-3 col-form-label">Previous Permit No

</label>
    <div class="col-sm-9">
       <asp:TextBox autocomplete="off"  ID="TxtPrevPerNO" BackColor="#e8f0fe" OnTextChanged ="TxtPrevPerNO_TextChanged" runat="server" AutoPostBack ="true"  Width="350" type="text" TabIndex="3"></asp:TextBox>
    </div>
  </div>
                  <div id="cargo" runat="server" class="form-group row">
    <label for="staticEmail" class="col-sm-3 col-form-label">Outward Trans Mode

</label>
    <div class="col-sm-9">
       <asp:DropDownList CssClass="drop" ID="DrpOutwardtrasMode" BackColor="#e8f0fe" OnSelectedIndexChanged="DrpOutwardtrasMode_SelectedIndexChanged"   AutoPostBack="true"  Width="350" Height="28" AppendDataBoundItems="true" TabIndex="4"  runat="server">
                                                </asp:DropDownList>
                                               <asp:RequiredFieldValidator BackColor="Red" InitialValue="0"  ID="RequiredFieldValidator31" runat="server" ControlToValidate="DrpOutwardtrasMode" Display="None" ErrorMessage="Header --> Outward Transport Mode is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
    </div>
  </div>
                  <div runat ="server" visible ="false" class="form-group row">
    <label for="staticEmail" class="col-sm-3 col-form-label">  BG Indicator   
</label>
    <div class="col-sm-9">
        <asp:DropDownList CssClass="drop" ID="DrpBGIndicator"  Width="350" Height="28" AppendDataBoundItems="true" TabIndex="5"  runat="server">
                                                </asp:DropDownList>
    </div>
  </div>
                  <div class="form-group row">
    <label for="staticEmail" class="col-sm-3 col-form-label"> 
</label>
    <div class="col-sm-9">
       <asp:CheckBox ID="ChkOverrExgRate"  Width="350" Enabled="false" runat="server" TabIndex="6" Text="override Exchange Rate" />
    </div>
  </div>
                  <div runat ="server" visible ="false" class="form-group row">
    <label for="staticEmail" class="col-sm-3 col-form-label">    
</label>
    <div class="col-sm-9">
       <asp:CheckBox ID="ChkSupplyIndicator"  Width="350" runat="server" TabIndex="7" Text="Supply indicator" />
    </div>
  </div>
                  <div class="form-group row">
    <label for="staticEmail" class="col-sm-3 col-form-label"> 
</label>
    <div class="col-sm-9">
         <asp:CheckBox ID="ChkRefDoc"  Width="350" OnCheckedChanged="ChkRefDoc_CheckedChanged" AppendDataBoundItems="true" AutoPostBack="true" runat="server" TabIndex="8" Text="Reference Document" />
    </div>
  </div>
                  </div>
            <div class="col-sm-6">
                <div class="form-group row">
    <label for="staticEmail" class="col-sm-3 col-form-label">Mailbox ID
</label>
    <div class="col-sm-9">
        <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe" Text="" Width="350" type="text" ID="TxtTradeMailID"  ></asp:TextBox>
                                               <asp:RequiredFieldValidator BackColor="Red"  ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TxtTradeMailID" Display="None" ErrorMessage="Header --> TradeNet Mailbox ID is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
    </div>
  </div>
                <div class="form-group row">
    <label for="staticEmail" class="col-sm-3 col-form-label">Declarant Name
</label>
    <div class="col-sm-9">
        <asp:TextBox autocomplete="off"  ID="TxtDecName" BackColor="#e8f0fe" Text=""  Width="350" runat="server"  type="text" ></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtDecName" Display="None" ErrorMessage="Header --> Declarant Name is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
    </div>
  </div>
                <div class="form-group row">
    <label for="staticEmail" class="col-sm-3 col-form-label">Declaration Code
</label>
    <div class="col-sm-9">
        <asp:TextBox autocomplete="off"  ID="TxtDecCode" BackColor="#e8f0fe" Text=""  Width="350" runat="server"  type="text" ></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtDecCode" Display="None" ErrorMessage="Header --> Declarant  Code is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
    </div>
  </div>
                <div class="form-group row">
                <label for="staticEmail" class="col-sm-3 col-form-label">Declarant Tel</label>
                <div class="col-sm-9">
                    <asp:TextBox autocomplete="off"  ID="TxtDecTelephone" BackColor="#e8f0fe" Text=""  Width="350" runat="server"  type="text" ></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtDecTelephone" Display="None" ErrorMessage="Header --> Declarant  Telephone is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                </div>
              </div>
                <div class="form-group row">
                <label for="staticEmail" class="col-sm-3 col-form-label">CR UEI No</label>
                <div class="col-sm-9">
                   <asp:TextBox autocomplete="off"  ID="TxtCRUEINO" BackColor="#e8f0fe" Text=""  Width="350" runat="server" type="text"  ></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtCRUEINO" Display="None" ErrorMessage="Header --> CR UEI No is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                </div>
                </div>
              
                
                  
                </div>
            </div>
               <div class="row">

                    <div class="col-sm-12" id="Document" runat="server">
    <div class="row">
                                            <div class="col-sm-6">
                                                        <br />
                                                        <div class="row Borderdiv"  style="width:100%">
                                          License
                                        </div><br />
                                                 <div class="row">
                                            <div class="col-sm-6">
                                               <asp:TextBox autocomplete="off"  ID="TxtLicense1"  Width="275" runat="server" TabIndex="9" type="text" ></asp:TextBox><br /><br />
                                                        <asp:TextBox autocomplete="off"  ID="TxtLicense2"  Width="275" runat="server" TabIndex="10" type="text" ></asp:TextBox><br /><br />
                                                        <asp:TextBox autocomplete="off"  ID="TxtLicense3"  Width="275" runat="server" TabIndex="11" type="text"></asp:TextBox><br /><br />                                                                   
                                                </div>
                                                      <div class="col-sm-6">
                                                             <asp:TextBox autocomplete="off"  ID="TxtLicense4"  Width="275" runat="server" TabIndex="12" type="text"></asp:TextBox><br /><br />
                                                        <asp:TextBox autocomplete="off"  ID="TxtLicense5"  Width="275" runat="server" TabIndex="13" type="text" ></asp:TextBox><br /><br />
                                                </div>
                                                     </div>
                                                      
                                                    </div>
                                       
                                                    <div class="col-sm-6">
                                                         <asp:UpdatePanel ID ="updoc" runat ="server" UpdateMode ="Conditional"  >
                                                                                   <ContentTemplate>

                                                         <div class="row Borderdiv"  style="width:100%">
                                          Attachment Document
                                        </div>
                                                        <br />
                                                        <div class="row">
                                                            <div class="col-sm-5">
                                                                <p>Document Type</p> 
                                                                <asp:DropDownList CssClass="drop" ID="DrpDocType"  BackColor="#e8f0fe"  Width="250" Height="32" AppendDataBoundItems="true" TabIndex="14" runat="server">
                                                                </asp:DropDownList><br />
                                                               
                                                            </div>
                                                            <div class="col-sm-5">
                                                                <p>Uplaod Document</p>
                                                                <asp:FileUpload ID="FileUpload1"  BackColor="#e8f0fe" runat="server" TabIndex ="15"  AllowMultiple="true" />
                                                                
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <p>Uplaod</p>
                                                                <asp:Button runat="server" ID="Btn_Upload"  class="btn btn-success" TabIndex ="16" Text="Upload" OnClick="Btn_Upload_Click" />
                                                               
                                                            </div>
                                                        </div>


                                                        <hr />
                                                        <asp:GridView ID="GridView1" PageSize="5" OnRowDeleting="GridView1_RowDeleting" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="GridView1_PageIndexChanging"  CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
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

                                                                                 </ContentTemplate>
                                                                                     <Triggers>
                                                                        <asp:PostBackTrigger ControlID="Btn_Upload" />
                                                                    </Triggers>
                                                                               </asp:UpdatePanel>
                                                    </div>

                                                </div>
                                            
</div>


                </div>
        <div class="row">
               
                 <div class="col-sm-12" >
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
                     <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="cotype" />
                                    <div class="col-sm-12">
                                         <div class="row Borderdiv" style="width:100%">
                                         Certificate of Origin
                                        </div>
                                       <br />
                                         <div class="row">
                                             <label for="staticEmail" class="col-sm-4 col-form-label">CO Type</label>
                                                   
                                             <div class="col-sm-4">
                                                   <asp:DropDownList CssClass="drop" ID="DrpCoType" BackColor="#e8f0fe" OnSelectedIndexChanged="DrpCoType_SelectedIndexChanged" AutoPostBack="true"  Width="500" Height="28" AppendDataBoundItems="true" TabIndex="17"  runat="server">
                                                </asp:DropDownList>
                                                        </div>
                                              <div class="col-sm-4"></div>
                                             </div>
                                        <br />
                                        <div class="row" id="entryyrs" runat="server" visible="false">
                                             <label for="staticEmail" class="col-sm-4 col-form-label">Entry Year</label>
                                                   
                                             <div class="col-sm-8">
                                                   <asp:TextBox autocomplete="off"  ID="txtentry" runat="server"></asp:TextBox>
                                                        </div>
                                             </div>
                                        <br />
                                        <div id ="gps" runat ="server" visible ="false">

                                       
                                          <div class="row">
                                              <label for="staticEmail" class="col-sm-4 col-form-label"> GSP Donor Country</label>
                                                 
                                             <div class="col-sm-8">
                                                   <asp:DropDownList CssClass="drop" ID="Drpgpsdonorcountry"  AutoPostBack="true"  Width="500" Height="28" AppendDataBoundItems="true" TabIndex="18"  runat="server">
                                                </asp:DropDownList>
                                                        </div>
                                             </div>
                                             </div>
                                        <br />
                                        <br />
                                        <b>
                                                <div class="row">
                                                    
                                                    <div class="col-sm-6">
                                                        <p>Certificate Detail #1 - Type</p>
                                                        <asp:DropDownList CssClass="drop"   ID="DrpCerDtl1" BackColor="#e8f0fe"  Width="500" Height="28" AutoPostBack="true" OnSelectedIndexChanged="DrpCerDtl1_SelectedIndexChanged" Style="text-transform: uppercase"  runat="server" TabIndex="19" type="text" ></asp:DropDownList>

                                                        <br />
                                                          <p>Certificate Detail #1 - Copies</p>
                                                        <asp:TextBox autocomplete="off"   ID="TxtCerDtl1"  Width="500" Height="28"  runat="server" TabIndex="20" type="text" ></asp:TextBox>

                                                        <br />
                                                          <p>Certificate Detail #2 - Type</p>
                                                        <asp:DropDownList CssClass="drop"   ID="DrpCerDtl2"  Width="500" Height="28"  runat="server" TabIndex="21" type="text" ></asp:DropDownList>

                                                        <br />
                                                          <p>Certificate Detail #2 - Copies</p>
                                                        <asp:TextBox autocomplete="off"   Width="500" ID="TxtCerDtl2" Height="28"  runat="server" TabIndex="22" type="text" ></asp:TextBox>

                                                        <br />
                                                        <div id="common" runat ="server" visible ="false">

                                                        
                                                        <p>Percentage of Commonwealth Preference Content</p>
                                                        <asp:TextBox autocomplete="off"   Width="500" ID="txtper" Height="28"  Text="0.00" runat="server" TabIndex="23" type="text" ></asp:TextBox>
</div>

                                                        <br />
                                                        
                                                          <p>Currency Code</p>
                                                        <asp:DropDownList CssClass="drop" BackColor="#e8f0fe"  Width="500" ID="DrpCurrencyCode"  Height="28"  runat="server" AutoPostBack ="true" OnSelectedIndexChanged="DrpCurrencyCode_SelectedIndexChanged" TabIndex="24" type="text" ></asp:DropDownList>

                                                        <br />
                                                    </div>
                                                    <div class="col-sm-3">
                                                        <p>Additional Certificate Details</p>
                                                        <asp:TextBox autocomplete="off"  ID="AddCerDtl1"  ValidationGroup="cotype"   Width="275" Height="28" runat="server"      TabIndex="25" type="text" ></asp:TextBox>
                                                        <br /><br />
                                                        
                                                        <asp:TextBox autocomplete="off"  ID="AddCerDtl2"  ValidationGroup="cotype"   Width="275" Height="28" runat="server"     TabIndex="26" type="text" ></asp:TextBox>
                                                         <br /><br />
                                                         
                                                        <asp:TextBox autocomplete="off"  ID="AddCerDtl3"  ValidationGroup="cotype"  Width="275" Height="28" runat="server"     TabIndex="27" type="text" ></asp:TextBox>
                                                        <br /><br />
                                                       
                                                         <asp:TextBox autocomplete="off"  ID="AddCerDtl4"  ValidationGroup="cotype"  Width="275" Height="28" runat="server"     TabIndex="28" type="text" ></asp:TextBox>
                                                        <br /><br />
                                                        
                                                         <asp:TextBox autocomplete="off"  ID="AddCerDtl5"  ValidationGroup="cotype"  Width="275" Height="28" runat="server"      TabIndex="29" type="text" ></asp:TextBox><br />
                                                         <br /><br />
                                                        
                                                        
                                                      
                                                    </div>
                                                    <div class="col-sm-3">
                                                           <p>Transport Details</p>
                                                        <asp:TextBox autocomplete="off"  ID="TransDtl1"  Width="275" Height="28" runat="server"      TabIndex="30" type="text" ></asp:TextBox><br /><br />
                                                        <asp:TextBox autocomplete="off"  ID="TransDtl2"  Width="275" Height="28" runat="server"     TabIndex="31" type="text" ></asp:TextBox><br /><br />
                                                        <asp:TextBox autocomplete="off"  ID="TransDtl3"  Width="275" Height="28" runat="server"    TabIndex="32" type="text" ></asp:TextBox><br /><br />
                                                        <asp:TextBox autocomplete="off"  ID="TransDtl4"  Width="275" Height="28" runat="server"     TabIndex="33" type="text" ></asp:TextBox><br /><br />
                                                        <asp:TextBox autocomplete="off"  ID="TransDtl5"  Width="275" Height="28" runat="server"      TabIndex="34" type="text" ></asp:TextBox>
                                                        <br />
                                                        <br />
                                                        </div>
                                                </div>
                                            </b>
                                           <br />
                                        <br />
                                    </div>
                                </div>
                                <div class="row" runat="server" >
                                    <div class="col-sm-12">
                                         <div class="row Borderdiv" style="width:100%">
                                          ADDITIONAL RECIPIENTS
                                        </div>
                                       <br />
                                                <div class="row">
                                                    <div class="col-sm-4">
                                                        <p>RECIPIENTS 1</p>
                                                        <asp:TextBox autocomplete="off"  ID="TxtRECPT1"  Width="350" runat="server"  type="text" ></asp:TextBox>

                                                        <br />
                                                    </div>
                                                    <div class="col-sm-4">
                                                        <p>RECIPIENTS 2</p>
                                                        <asp:TextBox autocomplete="off"  ID="TxtRECPT2"  Width="350"  runat="server" type="text" ></asp:TextBox>

                                                        <br />
                                                    </div>
                                                    <div class="col-sm-4">
                                                        <p>RECIPIENTS 3</p>
                                                        <asp:TextBox autocomplete="off"  ID="TxtRECPT3"  Width="350" runat="server" OnTextChanged="TxtRECPT3_TextChanged" AutoPostBack="true"    type="text" ></asp:TextBox>

                                                        <br />
                                                    </div>
                                                </div>
                                           <br />
                                        <br />
                                    </div>
                                </div>

                            <%--</form>--%>
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
                                                                                                <asp:GridView HeaderStyle-Font-Size="X-Small" ShowHeaderWhenEmpty="true"   EmptyDataText="No Records found" PageSize="10" ID="GridCondition" Width="100%" FooterStyle-CssClass="bg-primary text-white"  HeaderStyle-CssClass="bg-primary text-white" RowStyle-CssClass="rows" Font-Bold ="true" PagerStyle-CssClass="pager"  AllowPaging="True"  CssClass="table table-striped table-bordered table-hover" runat="server" OnPageIndexChanging="GridCondition_PageIndexChanging" AutoGenerateColumns="true">
                                                                                                  
                                                                                                </asp:GridView>
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

            </ContentTemplate>
      <Triggers>
                                                                        <asp:PostBackTrigger ControlID="Btn_Upload"/>
                                                                    </Triggers>
       </asp:UpdatePanel>
  </ContentTemplate>
                                                        </cc1:TabPanel>

    <%--</div>--%>
    <%--<div role="tabpanel" class="tab-pane fade" id="Party"  >--%>
        <cc1:TabPanel ID="Party" CssClass="ajax__tab_header" runat="server" HeaderText="Party">
                                                            
                                                            <ContentTemplate>
        <asp:UpdatePanel ID ="coparty" UpdateMode ="Conditional" runat ="server">
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
                                                                                            
            <asp:ImageButton id="btnShow" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15"  Style="margin-top:-250px;" />
                                                                                            
           <asp:Button ID="DECPLUS" runat="server" CssClass="plusbtn" BackColor="Transparent" BorderWidth="0px" ValidationGroup="ItemMasterValidation1" OnClick="DECPLUS_Click" Text="+" />
     </div>
   </div>
                  
                
            
                </label>
<cc1:ModalPopupExtender ID="popupcodec" runat="server" PopupControlID="pnlcodec" TargetControlID="btnShow"
 OkControlID="btnYescodec" CancelControlID="btnNocodec" BackgroundCssClass="modalBackground">
  </cc1:ModalPopupExtender>

<asp:Panel ID="pnlcodec" runat="server" CssClass="modalPopup" Style="display: none">
<div class="header">
 Declarant Company
</div>
 <div class="body">
 <asp:UpdatePanel ID="upcodec" runat="server" UpdateMode="Conditional">
   <ContentTemplate>
         <asp:TextBox autocomplete="off"  ID="DecSearch"   OnTextChanged="DecSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code"   class="form-control" runat="server"  ></asp:TextBox>
                                                        <br />
                                                        <asp:GridView ID="DECCOMPSearGRID"  PageSize="5" AllowPaging="True" DataKeyNames="Id"  OnPageIndexChanging="DECCOMPSearGRID_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" OnRowCreated ="DECCOMPSearGRID_RowCreated" OnRowCommand ="DECCOMPSearGRID_RowCommand"  OnRowDataBound ="DECCOMPSearGRID_RowDataBound" AutoGenerateColumns="false">
                                                            <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>


                                                                <asp:TemplateField HeaderText="DocumentType" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCode"  runat="server"
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
                                                                        <asp:Label ID="lblName1"  runat="server"
                                                                            Text='<%#Eval("Name1")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CRUEI" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCRUEI"  runat="server"
                                                                            Text='<%#Eval("CRUEI")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                      <asp:LinkButton ID="lnkRequestID" runat="server" CommandArgument='<%# Eval("Id") %>'   OnCommand="lnkRequestID_Command" >Select </asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
 </ContentTemplate>
<%--  <Triggers>
<asp:PostBackTrigger ControlID="DECCOMPSearGRID" />
  </Triggers>--%>


 </asp:UpdatePanel>
 </div>
 <div class="footer" align="right">
 <asp:Button ID="btnYescodec" runat="server" Text="Yes" CssClass="yes" />
  <asp:Button ID="btnNocodec" runat="server" Text="No" CssClass="no" />
   </div>
  </asp:Panel>
                <div class="col-sm-4">
               <asp:TextBox autocomplete="off"  runat="server" Width="100" type="text" OnTextChanged="TxtDecCompCode_TextChanged" placeholder="Code" AutoPostBack="true" ID="TxtDecCompCode" TabIndex="38" ></asp:TextBox>
                      <cc1:AutoCompleteExtender ServiceMethod="GetListofCountries"
    MinimumPrefixLength="1"
    CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem"  CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
    TargetControlID="TxtDecCompCode"
    ID="AutoCompleteExtender8" runat="server" FirstRowSelected = "true">
</cc1:AutoCompleteExtender>
                </div>
              </div>
                 
                  </div>
               <div class="col-sm-2">
<div class="form-group row">
   
    <div class="col-sm-12">
        <asp:TextBox autocomplete="off"  ID="TxtDecCompCRUEI" Width="170" ValidationGroup="Validation" runat="server" placeholder="CRUEI" BackColor="#e8f0fe" TabIndex="39" type="text" ></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="TxtDecCompCRUEI" Display="None" ErrorMessage="Party --> Declarant Company CR UEI is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "TxtDecCompCRUEI" ID="RegularExpressionValidator37" ValidationExpression = "^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator><br />
    </div>
  </div>
                 
                  </div>
              <div class="col-sm-3">
<div class="form-group row">
   
    <div class="col-sm-12">
         <asp:TextBox autocomplete="off"  ID="TxtDecCompName" ValidationGroup="Validation" Width="265" runat="server" placeholder="Name" BackColor="#e8f0fe" TabIndex="40" type="text"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TxtDecCompName" Display="None" ErrorMessage="Party --> Declarant Company Name is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator> <br />
                                        <br />
                                        <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "TxtDecCompName" ID="RegularExpressionValidator18" ValidationExpression = "^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
    </div>
  </div>
                 
                  </div>
              <div class="col-sm-3">
<div class="form-group row">
    
    <div class="col-sm-12">
        <asp:TextBox autocomplete="off"  ID="TxtDecCompName1" Width="265" ValidationGroup="Validation" placeholder="Name1" runat="server" TabIndex="41" type="text" ></asp:TextBox>
                                      <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "TxtDecCompName1" ID="RegularExpressionValidator19" ValidationExpression = "^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
    </div>
  </div>
                 
                  </div>
                  </div>
        <div class="row">
              <div  class="col-sm-4">
<div class="form-group row">
    <label for="staticEmail" class="col-sm-8 col-form-label">

         <div class="row">
       <div class="col-sm-8">
             Exporter
       </div>
       <div class="col-sm-4">
                                                                                            
            <asp:ImageButton id="btncoexp1" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15"  Style="margin-top:-250px;" />
                                                                                            
            <asp:Button ID="BtnExpAdd" runat="server" CssClass="plusbtn" BackColor="Transparent" BorderWidth="0px" ValidationGroup="Importer" OnClick="BtnExpAdd_Click" Text="+" />
     </div>
   </div>
</label>
 <cc1:ModalPopupExtender ID="popupcoexp" runat="server" PopupControlID="pnlcoexp" TargetControlID="btncoexp1"
 OkControlID="btnYescoexp" CancelControlID="btnNocoexp" BackgroundCssClass="modalBackground">
  </cc1:ModalPopupExtender>

<asp:Panel ID="pnlcoexp" runat="server" CssClass="modalPopup" Style="display: none">
<div class="header">
 EXPORTER
</div>
 <div class="body">
 <asp:UpdatePanel ID="upcoexp" runat="server" UpdateMode="Conditional">
   <ContentTemplate>
        <asp:TextBox autocomplete="off"  ID="ExporterSearch"  OnTextChanged="ExporterSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code"   class="form-control" runat="server"  ></asp:TextBox>
                                                        <br />
                                                        <asp:GridView ID="ExporterGrid"  PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ExporterGrid_PageIndexChanging" OnRowCommand ="ExporterGrid_RowCommand" OnRowDataBound ="ExporterGrid_RowDataBound" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                            <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>


                                                                <asp:TemplateField HeaderText="DocumentType" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCode"  runat="server"
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
                                                                        <asp:Label ID="lblName1"  runat="server"
                                                                            Text='<%#Eval("Name1")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CRUEI" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCRUEI"  runat="server"
                                                                            Text='<%#Eval("CRUEI")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                      <asp:LinkButton ID="LnkExporter" runat="server" CommandArgument='<%# Eval("Id") %>'   OnCommand="LnkExporter_Command" >Select </asp:LinkButton>
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
 <asp:Button ID="btnYescoexp" runat="server" Text="Yes" CssClass="yes" />
  <asp:Button ID="btnNocoexp" runat="server" Text="No" CssClass="no" />
   </div>
  </asp:Panel>
    <div class="col-sm-4">
        <asp:TextBox autocomplete="off"  runat="server" Width="100" type="text" ID="TxtExpCode" placeholder="Code" OnTextChanged="TxtExpCode_TextChanged" AutoPostBack="true" TabIndex="42" ></asp:TextBox>                                  
          <cc1:AutoCompleteExtender ServiceMethod="GetExpcode"
    MinimumPrefixLength="1"
    CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem"  CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
    TargetControlID="TxtExpCode"
    ID="AutoCompleteExtender3" runat="server" FirstRowSelected = "true">
</cc1:AutoCompleteExtender>
    </div>
  </div>
                 
                  </div>
               <div class="col-sm-2">
<div class="form-group row">
   
    <div class="col-sm-12">
        <asp:TextBox autocomplete="off"  ID="TxtExpCRUEI" Width="170" runat="server" BackColor="#e8f0fe" placeholder="CRUEI" TabIndex="43" type="text"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator35"  runat="server" ControlToValidate="TxtDecCompCRUEI" Display="None" ErrorMessage="Exporter --> Importer CRUEI is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                <br />
                                <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "TxtExpCRUEI" ID="RegularExpressionValidator13" ValidationExpression = "^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="PartyExp"></asp:RegularExpressionValidator>
    </div>
  </div>
                 
                  </div>
              <div class="col-sm-3">
<div class="form-group row">
   
    <div class="col-sm-12">
        <asp:TextBox autocomplete="off"  ID="TxtExpName" Width="265" runat="server" BackColor="#e8f0fe" placeholder="Name" TabIndex="44" type="text" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ControlToValidate="TxtDecCompCRUEI" Display="None" ErrorMessage="Party --> Exporter Name is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                         <br />
                                <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "TxtExpName" ID="RegularExpressionValidator11" ValidationExpression = "^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="PartyExp"></asp:RegularExpressionValidator>
    </div>
  </div>
                 
                  </div>
              <div class="col-sm-3">
<div class="form-group row">
    
    <div class="col-sm-12">
        <asp:TextBox autocomplete="off"  ID="TxtExpName1" Width="265" runat="server" TabIndex="45" placeholder="Name1" type="text" ></asp:TextBox>
                                         <br /> 
                                <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "TxtExpName1" ID="RegularExpressionValidator12" ValidationExpression = "^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="PartyExp"></asp:RegularExpressionValidator> 
    </div>
  </div>
                 
                  </div>
                  </div>
               <div id="expaddress" class ="row"  runat ="server" >
                   <div class ="col-sm-1">

                   </div>
                   <div class ="col-sm-1">

                   </div>
                   <div class ="col-sm-2">

                   </div>
                   <div class ="col-sm-2">
              <asp:TextBox autocomplete="off"  ID="txtadd1" Width="165" runat="server" placeholder="Address1"  TabIndex="46" type="text" ></asp:TextBox>
                   </div>
                    <div class ="col-sm-2">
             <asp:TextBox autocomplete="off"  ID="txtadd2" Width="265" runat="server" placeholder="Address2"  TabIndex="47" type="text" ></asp:TextBox>
                   </div>
                    <div class ="col-sm-1">
              
                   </div>
                    <div class ="col-sm-3">
                        <asp:TextBox autocomplete="off"  ID="txtadd3" Width="265" runat="server" placeholder="Address3"  TabIndex="48" type="text" ></asp:TextBox>
                        </div>
                   
               </div>
               <br />

        <div class="row" id="partyinw" runat="server" visible ="false">
              <div class="col-sm-4">
<div class="form-group row">
    <label for="staticEmail" class="col-sm-8 col-form-label">
        <div class="row">
       <div class="col-sm-8">
             Inward Carrier Agent
       </div>
       <div class="col-sm-4">
                                                                                            
            <asp:ImageButton id="btncoinw1" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15"  Style="margin-top:-250px;" />
                                                                                            
          <asp:Button ID="InwardAdd" runat="server" CssClass="plusbtn" BackColor="Transparent" BorderWidth="0px" ValidationGroup="INWARD" OnClick="InwardAdd_Click" Text="+" />
     </div>
   </div>
      
                                           
                                       
        

</label>
     <cc1:ModalPopupExtender ID="popupcoinw" runat="server" PopupControlID="pnlcoinw" TargetControlID="btncoinw1"
 OkControlID="btnYescoinw" CancelControlID="btnNocoinw" BackgroundCssClass="modalBackground">
  </cc1:ModalPopupExtender>

<asp:Panel ID="pnlcoinw" runat="server" CssClass="modalPopup" Style="display: none">
<div class="header">
   Inward Carrier Agent
</div>
 <div class="body">
 <asp:UpdatePanel ID="upcoinw" runat="server" UpdateMode="Conditional">
   <ContentTemplate>
        <asp:TextBox autocomplete="off"  ID="InwardSearch"  OnTextChanged="InwardSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code"   class="form-control" runat="server"  ></asp:TextBox>
                                                        <br />
                                                        <asp:GridView ID="InwardGrid"  PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="InwardGrid_PageIndexChanging"  OnRowCommand ="InwardGrid_RowCommand" OnRowDataBound ="InwardGrid_RowDataBound" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                            <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>


                                                                <asp:TemplateField HeaderText="Code" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCode"  runat="server"
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
                                                                        <asp:Label ID="lblName1"  runat="server"
                                                                            Text='<%#Eval("Name1")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CRUEI" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCRUEI"  runat="server"
                                                                            Text='<%#Eval("CRUEI")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                      <asp:LinkButton ID="LmkInward" runat="server" CommandArgument='<%# Eval("Id") %>'   OnCommand="LmkInward_Command" >Select </asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
 </ContentTemplate>
<%--  <Triggers>
<asp:PostBackTrigger ControlID="InwardGrid" />
  </Triggers>--%>


 </asp:UpdatePanel>
 </div>
 <div class="footer" align="right">
 <asp:Button ID="btnYescoinw" runat="server" Text="Yes" CssClass="yes" />
  <asp:Button ID="btnNocoinw" runat="server" Text="No" CssClass="no" />
   </div>
  </asp:Panel>
    <div class="col-sm-4">
        <asp:TextBox autocomplete="off"  runat="server" Width="100" type="text" TabIndex ="49" AutoPostBack="true" ID="InwardCode" PlaceHolder="Code" OnTextChanged="InwardCode_TextChanged"  ></asp:TextBox>
    <cc1:AutoCompleteExtender ServiceMethod="GetInwcode"
    MinimumPrefixLength="1"
    CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem"  CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
    TargetControlID="InwardCode"
    ID="AutoCompleteExtender4" runat="server" FirstRowSelected = "true">
</cc1:AutoCompleteExtender>
    </div>
  </div>
                 
                  </div>
               <div class="col-sm-2">
<div class="form-group row">
   
    <div class="col-sm-12">
        <asp:TextBox autocomplete="off"  ID="InwardCRUEI" Width="170" BackColor="#e8f0fe" runat="server" TabIndex ="50" PlaceHolder="CRUEI" type="text" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="InwardCRUEI" Display="None" ErrorMessage="Party --> Inward Agent CRUEI is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
    </div>
  </div>
                 
                  </div>
              <div class="col-sm-3">
<div class="form-group row">
   
    <div class="col-sm-12">
        <asp:TextBox autocomplete="off"  ID="InwardName" Width="265" BackColor="#e8f0fe"  runat="server" PlaceHolder="Name" TabIndex ="51"  type="text" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="InwardName" Display="None" ErrorMessage="Party --> Inward Agent Name is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
    </div>
  </div>
                 
                  </div>
              <div class="col-sm-3">
<div class="form-group row">
    
    <div class="col-sm-12">
        <asp:TextBox autocomplete="off"  ID="InwardName1" Width="265" TabIndex ="52" runat="server" PlaceHolder="Name1"  type="text" ></asp:TextBox>
    </div>
  </div>
                 
                  </div>
                  </div>

        <div class="row">
              <div  class="col-sm-4">
<div class="form-group row">
 <label for="staticEmail" class="col-sm-8 col-form-label">

     <div class="row">
       <div class="col-sm-8">
             OutwardCarrierAgent
       </div>
       <div class="col-sm-4">
                                                                                            
            <asp:ImageButton id="btncoout1" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15"  Style="margin-top:-250px;" />
                                                                                            
          <asp:Button ID="OutwardAdd" CssClass="plusbtn" BackColor="Transparent" BorderWidth="0px" runat="server" ValidationGroup="Outward" OnClick="OutwardAdd_Click" Text="+" />
     </div>
   </div>

  
                                        
   

</label>
    <cc1:ModalPopupExtender ID="popupcoout" runat="server" PopupControlID="pnlcoout" TargetControlID="btncoout1"
 OkControlID="btnYescoout" CancelControlID="btnNocoout" BackgroundCssClass="modalBackground">
  </cc1:ModalPopupExtender>

<asp:Panel ID="pnlcoout" runat="server" CssClass="modalPopup" Style="display: none">
<div class="header">
 Outward Carrier
</div>
 <div class="body">
 <asp:UpdatePanel ID="upcoout" runat="server" UpdateMode="Conditional">
   <ContentTemplate>
       <asp:TextBox autocomplete="off"  ID="OutwardSearch"  OnTextChanged="OutwardSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code"   class="form-control" runat="server"  ></asp:TextBox>
                                                        <br />
                                                        <asp:GridView ID="OutwardGrid"  PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="OutwardGrid_PageIndexChanging" OnRowCommand ="OutwardGrid_RowCommand" OnRowDataBound ="OutwardGrid_RowDataBound" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                            <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>


                                                                <asp:TemplateField HeaderText="Code" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCode"  runat="server"
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
                                                                        <asp:Label ID="lblName1"  runat="server"
                                                                            Text='<%#Eval("Name1")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CRUEI" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCRUEI"  runat="server"
                                                                            Text='<%#Eval("CRUEI")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                      <asp:LinkButton ID="LmkOutward" runat="server" CommandArgument='<%# Eval("Id") %>'   OnCommand="LmkOutward_Command" >Select </asp:LinkButton>
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
 <asp:Button ID="btnYescoout" runat="server" Text="Yes" CssClass="yes" />
  <asp:Button ID="btnNocoout" runat="server" Text="No" CssClass="no" />
   </div>
  </asp:Panel>
    <div class="col-sm-4">
        <asp:TextBox autocomplete="off"  runat="server" Width="100" type="text" AutoPostBack="true" ID="OutwardCode" PlaceHolder="Code" OnTextChanged="OutwardCode_TextChanged" TabIndex="53" ></asp:TextBox>                                
    <cc1:AutoCompleteExtender ServiceMethod="GetOutWard"
MinimumPrefixLength="1"
CompletionInterval="100" EnableCaching="false" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem"  CompletionListHighlightedItemCssClass="itemHighlighted" CompletionSetCount="10"
TargetControlID="OutwardCode"
ID="AutoCompleteExtender2" runat="server" FirstRowSelected = "true">
</cc1:AutoCompleteExtender>
    </div>
  </div>
                 
                  </div>
               <div class="col-sm-2">
<div class="form-group row">
   
    <div class="col-sm-12">
        <asp:TextBox autocomplete="off"  ID="OutwardCRUEI" ValidationGroup="Partyout"  Width="170" BackColor="#e8f0fe" PlaceHolder="CRUEI" runat="server" TabIndex="54" type="text" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="InwardCRUEI" Display="None" ErrorMessage="Party --> Outward Agent CRUEI is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                       <br />
                               <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "OutwardCRUEI" ID="RegularExpressionValidator16" ValidationExpression = "^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Partyout"></asp:RegularExpressionValidator>                                                           
    </div>
  </div>
                 
                  </div>
              <div class="col-sm-3">
<div class="form-group row">
   
    <div class="col-sm-12">
        <asp:TextBox autocomplete="off"  ID="OutwardName" ValidationGroup="Partyout"  Width="265" BackColor="#e8f0fe" PlaceHolder="Name"  runat="server" TabIndex="55" type="text" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="OutwardName" Display="None" ErrorMessage="Party --> Outward Agent Name is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>                                         
                                 <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "OutwardName" ID="RegularExpressionValidator14" ValidationExpression = "^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Partyout"></asp:RegularExpressionValidator>
    </div>
  </div>
                 
                  </div>
              <div class="col-sm-3">
<div class="form-group row">
    
    <div class="col-sm-12">
        <asp:TextBox autocomplete="off"  ID="OutwardName1" ValidationGroup="Partyout"  Width="265" runat="server" PlaceHolder="Name1" TabIndex="56" type="text" ></asp:TextBox>                                        
                                         <br />
                               <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "OutwardName1" ID="RegularExpressionValidator15" ValidationExpression = "^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Partyout"></asp:RegularExpressionValidator>   
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
                                                                                            
            <asp:ImageButton id="btncofreight1" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15"  Style="margin-top:-250px;" />
                                                                                            
          <asp:Button ID="BtnFrieghtAdd" CssClass="plusbtn" BackColor="Transparent" BorderWidth="0px" runat="server" ValidationGroup="FREIGHT" OnClick="BtnFrieghtAdd_Click" Text="+" />
     </div>
   </div>

                                       
        

</label>
     <cc1:ModalPopupExtender ID="popupcofreight" runat="server" PopupControlID="pnlcofreight" TargetControlID="btncofreight1"
 OkControlID="btnYescofreight" CancelControlID="btnNocofreight" BackgroundCssClass="modalBackground">
  </cc1:ModalPopupExtender>

<asp:Panel ID="pnlcofreight" runat="server" CssClass="modalPopup" Style="display: none">
<div class="header">
 FREIGHT FORWARDER
</div>
 <div class="body">
 <asp:UpdatePanel ID="upcofreight" runat="server" UpdateMode="Conditional">
   <ContentTemplate>
        <asp:TextBox autocomplete="off"  ID="FrieghtSearch"  OnTextChanged="FrieghtSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code"   class="form-control" runat="server"  ></asp:TextBox>
                                                        <br />
                                                        <asp:GridView ID="FrieghtGrid"  PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="FrieghtGrid_PageIndexChanging" OnRowCommand ="FrieghtGrid_RowCommand" OnRowDataBound ="FrieghtGrid_RowDataBound" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                            <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>


                                                                <asp:TemplateField HeaderText="Code" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCode"  runat="server"
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
                                                                        <asp:Label ID="lblName1"  runat="server"
                                                                            Text='<%#Eval("Name1")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CRUEI" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCRUEI"  runat="server"
                                                                            Text='<%#Eval("CRUEI")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                      <asp:LinkButton ID="LnkFrieght" runat="server" CommandArgument='<%# Eval("Id") %>'   OnCommand="LnkFrieght_Command" >Select </asp:LinkButton>
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
 <asp:Button ID="btnYescofreight" runat="server" Text="Yes" CssClass="yes" />
  <asp:Button ID="btnNocofreight" runat="server" Text="No" CssClass="no" />
   </div>
  </asp:Panel>
    <div class="col-sm-4">
         <asp:TextBox autocomplete="off"  runat="server" Width="100" OnTextChanged="FrieghtCode_TextChanged" Placeholder="Code" AutoPostBack="true" type="text" ID="FrieghtCode" TabIndex="57" ></asp:TextBox>
      <cc1:AutoCompleteExtender ServiceMethod="GetFrieght"
    MinimumPrefixLength="1"
    CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem"  CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
    TargetControlID="FrieghtCode"
    ID="AutoCompleteExtender6" runat="server" FirstRowSelected = "true">
</cc1:AutoCompleteExtender>
    </div>
  </div>
                 
                  </div>
               <div class="col-sm-2">
<div class="form-group row">
   
    <div class="col-sm-12">
        <asp:TextBox autocomplete="off"  ID="FrieghtCRUEI" Width="170" ValidationGroup="Partyfreight" PlaceHolder="CRUEI" runat="server" TabIndex="58" type="text"></asp:TextBox>
                                         <br />
                                <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "FrieghtCRUEI" ID="RegularExpressionValidator17" ValidationExpression = "^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Partyfreight"></asp:RegularExpressionValidator>
    </div>
  </div>
                 
                  </div>
              <div class="col-sm-3">
<div class="form-group row">
   
    <div class="col-sm-12">
        <asp:TextBox autocomplete="off"  ID="FrieghtName" Width="265" ValidationGroup="Partyfreight" PlaceHolder="Name" runat="server" TabIndex="60" type="text" ></asp:TextBox>
                                        <br />
                                 <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "FrieghtName" ID="RegularExpressionValidator60" ValidationExpression = "^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Partyfreight"></asp:RegularExpressionValidator>        
    </div>
  </div>
                 
                  </div>
              <div class="col-sm-3">
<div class="form-group row">
    
    <div class="col-sm-12">
        <asp:TextBox autocomplete="off"  ID="FrieghtName1" Width="265" ValidationGroup="Partyfreight" PlaceHolder="Name1" runat="server" TabIndex="61" type="text" ></asp:TextBox>
                                        <br />
                               <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "FrieghtName1" ID="RegularExpressionValidator61" ValidationExpression = "^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Partyfreight"></asp:RegularExpressionValidator>   
    </div>
  </div>
                 
                  </div>
                  </div>
        <div class="row">
              <div  class="col-sm-4">
<div class="form-group row">
    <label for="staticEmail" class="col-sm-8 col-form-label">
        <div class="row">
       <div class="col-sm-8">
             Consignee
       </div>
       <div class="col-sm-4">
                                                                                            
            <asp:ImageButton id="btncoconsignee1" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15"  Style="margin-top:-250px;" />
                                                                                            
        <asp:Button ID="ConsigneeAdd" CssClass="plusbtn" BackColor="Transparent" BorderWidth="0px" runat="server" ValidationGroup="CLAIMANT" OnClick="ConsigneeAdd_Click" Text="+" />
     </div>
   </div>
     
       

</label>
 <cc1:ModalPopupExtender ID="popupcoconsignee" runat="server" PopupControlID="pnlcoconsignee" TargetControlID="btncoconsignee1"
 OkControlID="btnYescoconsignee" CancelControlID="btnNococonsignee" BackgroundCssClass="modalBackground">
  </cc1:ModalPopupExtender>

<asp:Panel ID="pnlcoconsignee" runat="server" CssClass="modalPopup" Style="display: none">
<div class="header">
CONSIGNEE
</div>
 <div class="body">
 <asp:UpdatePanel ID="upcoconsignee" runat="server" UpdateMode="Conditional">
   <ContentTemplate>
<asp:TextBox autocomplete="off"  ID="ConsigneeSearch"  OnTextChanged="ConsigneeSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code"   class="form-control" runat="server"  ></asp:TextBox>
                                                        <br />
                                                        <asp:GridView ID="ConsigneeGrid"  PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ConsigneeGrid_PageIndexChanging" OnRowCommand ="ConsigneeGrid_RowCommand" OnRowDataBound ="ConsigneeGrid_RowDataBound" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                            <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>
                                                                <asp:TemplateField HeaderText="Code" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCode"  runat="server"
                                                                            Text='<%#Eval("ConsigneeCode")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                  <asp:TemplateField HeaderText="Name" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblname"  runat="server"
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
                                                                        <asp:Label ID="lblCRUEI"  runat="server"
                                                                            Text='<%#Eval("ConsigneeCRUEI")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Address" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="ConsigneeAddress"  runat="server"
                                                                            Text='<%#Eval("ConsigneeAddress")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Address1" SortExpression="Id" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="ConsigneeAddress1"  runat="server"
                                                                            Text='<%#Eval("ConsigneeAddress1")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="Address2" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="ConsigneeCity"  runat="server"
                                                                            Text='<%#Eval("ConsigneeCity")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                  <asp:TemplateField HeaderText="Sub Contry" SortExpression="Id" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="ConsigneeSub"  runat="server"
                                                                            Text='<%#Eval("ConsigneeSub")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                  <asp:TemplateField HeaderText="City" SortExpression="Id" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="ConsigneePostal"  runat="server"
                                                                            Text='<%#Eval("ConsigneePostal")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="City" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="ConsigneeCountry"  runat="server"
                                                                            Text='<%#Eval("ConsigneeCountry")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                      <asp:LinkButton ID="LmkConsignee" runat="server" CommandArgument='<%# Eval("Id") %>'   OnCommand="LmkConsignee_Command" >Select </asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
 </ContentTemplate>
  <%--<Triggers>
<asp:PostBackTrigger ControlID="ConsigneeGrid" />
  </Triggers>--%>


 </asp:UpdatePanel>
 </div>
 <div class="footer" align="right">
 <asp:Button ID="btnYescoconsignee" runat="server" Text="Yes" CssClass="yes" />
  <asp:Button ID="btnNococonsignee" runat="server" Text="No" CssClass="no" />
   </div>
  </asp:Panel>
    <div class="col-sm-4">
         <asp:TextBox autocomplete="off"  runat="server" Width="100" OnTextChanged="ConsigneeCode_TextChanged" AutoPostBack="true" type="text" PlaceHolder="Code" ID="ConsigneeCode" TabIndex="62" ></asp:TextBox> <br /> <br />
          <cc1:AutoCompleteExtender ServiceMethod="GetCosigncode"
    MinimumPrefixLength="1"
    CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem"  CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
    TargetControlID="ConsigneeCode"
    ID="AutoCompleteExtender9" runat="server" FirstRowSelected = "true">
</cc1:AutoCompleteExtender>

    </div>
  </div>
                 
                  </div>
               <div class="col-sm-2">
<div class="form-group row">
   
    <div class="col-sm-12">
        <asp:TextBox autocomplete="off"  ID="ConsigneeCRUEI" Width="170" ValidationGroup="PartyClaimant" runat="server" PlaceHolder="CRUEI" TabIndex="63" type="text" ></asp:TextBox>
                                       <br />
                              <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "ConsigneeCRUEI" ID="RegularExpressionValidator68" ValidationExpression = "^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
    </div>
    <br />  
    <br />         
        <div class="col-sm-12">            
                                         <asp:TextBox autocomplete="off"  ID="ConsigneeAddress" Width="170" ValidationGroup="PartyClaimant" PlaceHolder="Address" runat="server" TabIndex="64" type="text" ></asp:TextBox>
                                        <br />
                               <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "ConsigneeAddress" ID="RegularExpressionValidator22" ValidationExpression = "^[\s\S]{0,160}$" runat="server" ErrorMessage="Maximum 160 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
            </div>    
    <br /> 
    <br />         
        <div class="col-sm-12">
            <asp:TextBox autocomplete="off"  ID="ConsigneeSub" Width="170" ValidationGroup="PartyClaimant" runat="server" Visible ="false" TabIndex="65" type="text" ></asp:TextBox>
                              <br />
                              <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "ConsigneeSub" ID="RegularExpressionValidator25" ValidationExpression = "^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
        </div>       
  </div>
                 
                  </div>
              <div class="col-sm-3">
<div class="form-group row">   
    <div class="col-sm-12">
        <asp:TextBox autocomplete="off"  runat="server" Width="265" ValidationGroup="PartyClaimant" type="text" ID="ConsigneeName"   PlaceHolder="Name" TabIndex="66" ></asp:TextBox>
                                        <br />
                              <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "ConsigneeName" ID="RegularExpressionValidator20" ValidationExpression = "^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
    </div>
    <br />
    <br />
        <div class="col-sm-12">
            <asp:TextBox autocomplete="off"  ID="ConsigneeAddress1" Width="265" ValidationGroup="PartyClaimant" runat="server" PlaceHolder="Address1"  TabIndex="67" type="text" ></asp:TextBox>                                      
                              <br />
                               <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "ConsigneeAddress1" ID="RegularExpressionValidator23" ValidationExpression = "^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
            </div>
        
    <br /> 
    <br />
            <div class="col-sm-12">
            <asp:TextBox autocomplete="off"  ID="ConsigneePostal" Width="265" ValidationGroup="PartyClaimant" runat="server" TabIndex="68" Visible="false" type="text" ></asp:TextBox>
                              <br />
                              <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "ConsigneePostal" ID="RegularExpressionValidator26" ValidationExpression = "^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
            </div>        
  </div>
                 
                  </div>
              <div class="col-sm-3">
<div class="form-group row">   
    <div class="col-sm-12">
        <asp:TextBox autocomplete="off"  ID="ConsigneeName1" Width="265" ValidationGroup="PartyClaimant" PlaceHolder="Name1" runat="server" TabIndex="69" type="text" ></asp:TextBox>
                                        <br />
                               <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "ConsigneeName1" ID="RegularExpressionValidator21" ValidationExpression = "^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
    </div>
    <br />   
    <br />
        <div class="col-sm-12">
            <asp:TextBox autocomplete="off"  ID="ConsigneeCity" Width="265" ValidationGroup="PartyClaimant" PlaceHolder="Address2" runat="server" TabIndex="70" type="text" ></asp:TextBox>
                              <br />
                              <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "ConsigneeCity" ID="RegularExpressionValidator24" ValidationExpression = "^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
            </div>        
    <br />
    <br />    
        <div class="col-sm-12">
             <asp:TextBox autocomplete="off"  ID="ConsigneeCountry" Width="265" ValidationGroup="PartyClaimant" runat="server" Visible ="false" TabIndex="71" type="text" ></asp:TextBox>
                              <br />
                              <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "ConsigneeCountry" ID="RegularExpressionValidator27" ValidationExpression = "^[\s\S]{0,2}$" runat="server" ErrorMessage="Maximum 2 characters allowed." ValidationGroup="PartyClaimant"></asp:RegularExpressionValidator>
            </div>       
  </div>
                 
                  </div>
                  </div>
        <div class="row">
              <div  class="col-sm-4">
<div class="form-group row">
    <label for="staticEmail" class="col-sm-8 col-form-label">
        <div class="row">
       <div class="col-sm-8">
              Manufacturer
       </div>
       <div class="col-sm-4">
                                                                                            
            <asp:ImageButton id="btncomanufacturer1" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15"  Style="margin-top:-250px;" />
                                                                                            
         <asp:Button ID="ManufacturerAdd" CssClass="plusbtn" BackColor="Transparent" BorderWidth="0px" runat="server" ValidationGroup="CLAIMANT" OnClick="ManufacturerAdd_Click" Text="+" />
     </div>
   </div>
      
                                      

</label>
    <cc1:ModalPopupExtender ID="popupcomanufacturer" runat="server" PopupControlID="pnlcomanufacturer" TargetControlID="btncomanufacturer1"
 OkControlID="btnYescomanufacturer" CancelControlID="btnNocomanufacturer" BackgroundCssClass="modalBackground">
  </cc1:ModalPopupExtender>

<asp:Panel ID="pnlcomanufacturer" runat="server" CssClass="modalPopup" Style="display: none">
<div class="header">
 Manufacturer
</div>
 <div class="body">
 <asp:UpdatePanel ID="upcomanufacturer" runat="server" UpdateMode="Conditional">
   <ContentTemplate>
 <asp:TextBox autocomplete="off"  ID="ManufacturerSearch"  OnTextChanged="ManufacturerSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code"   class="form-control" runat="server"  ></asp:TextBox>
                                                        <br />
                                                        <asp:GridView ID="ManufacturerGrid"  PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ManufacturerGrid_PageIndexChanging" OnRowCommand ="ManufacturerGrid_RowCommand" OnRowDataBound ="ManufacturerGrid_RowDataBound" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                            <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>
                                                                <asp:TemplateField HeaderText="Code" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCode"  runat="server"
                                                                            Text='<%#Eval("ManufacturerCode")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                  <asp:TemplateField HeaderText="Name" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblname"  runat="server"
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

                                                                <asp:TemplateField HeaderText="CRUEI" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCRUEI"  runat="server"
                                                                            Text='<%#Eval("ManufacturerCRUEI")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Address" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="ConsigneeAddress"  runat="server"
                                                                            Text='<%#Eval("ManufacturerAddress")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Address1" SortExpression="Id" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="ConsigneeAddress1"  runat="server"
                                                                            Text='<%#Eval("ManufacturerAddress1")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="City" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="ConsigneeCity"  runat="server"
                                                                            Text='<%#Eval("ManufacturerCity")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                  <asp:TemplateField HeaderText="Sub Contry" SortExpression="Id" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="ConsigneeSub"  runat="server"
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


                                                                  <asp:TemplateField HeaderText="City" SortExpression="Id" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="ConsigneePostal"  runat="server"
                                                                            Text='<%#Eval("ManufacturerPostal")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="City" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="ConsigneeCountry"  runat="server"
                                                                            Text='<%#Eval("ManufacturerCountry")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                      <asp:LinkButton ID="LmkManufacturer" runat="server" CommandArgument='<%# Eval("Id") %>'   OnCommand="LmkManufacturer_Command" >Select </asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
 </ContentTemplate>
 <%-- <Triggers>
<asp:PostBackTrigger ControlID="ManufacturerGrid" />
  </Triggers>--%>


 </asp:UpdatePanel>
 </div>
 <div class="footer" align="right">
 <asp:Button ID="btnYescomanufacturer" runat="server" Text="Yes" CssClass="yes" />
  <asp:Button ID="btnNocomanufacturer" runat="server" Text="No" CssClass="no" />
   </div>
  </asp:Panel>
    <div class="col-sm-4">
         <asp:TextBox autocomplete="off"  runat="server" Width="100" OnTextChanged="ManufacturerCode_TextChanged" AutoPostBack="true" PlaceHolder="Code" type="text" ID="ManufacturerCode" TabIndex="72" ></asp:TextBox> <br /> <br />
          <cc1:AutoCompleteExtender ServiceMethod="GetManufactcode"
    MinimumPrefixLength="1"
    CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem"  CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
    TargetControlID="ManufacturerCode"
    ID="AutoCompleteExtender1" runat="server" FirstRowSelected = "true">
</cc1:AutoCompleteExtender>
    </div>
  </div>
                 
                  </div>
               <div class="col-sm-2">
<div class="form-group row">
   
    <div class="col-sm-12">
       <asp:TextBox autocomplete="off"  ID="ManufacturerCRUEI" Width="170" runat="server" PlaceHolder="CRUEI" TabIndex="73" type="text" ></asp:TextBox>                                       
                                        <br />
                      <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "ManufacturerCRUEI" ID="RegularExpressionValidator30" ValidationExpression = "^[\s\S]{0,17}$" runat="server" ErrorMessage="Maximum 17 characters allowed." ValidationGroup="Manufacture"></asp:RegularExpressionValidator>
    </div>
    <br />  
    <br />         
        <div class="col-sm-12">            
                                         <asp:TextBox autocomplete="off"  ID="ManufacturerAddress" Width="170" PlaceHolder="Address" runat="server" TabIndex="76" type="text" ></asp:TextBox>
                                 <br />
                               <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "ManufacturerAddress" ID="RegularExpressionValidator31" ValidationExpression = "^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Manufacture"></asp:RegularExpressionValidator>
            </div>    
    <br /> 
    <br />         
        <div class="col-sm-12">
           <asp:TextBox autocomplete="off"  ID="ManufacturerSubCode" Width="170" runat="server" PlaceHolder="Sub Code" TabIndex="79" type="text" ></asp:TextBox>
                              <br />
                                 <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "ManufacturerSubCode" ID="RegularExpressionValidator33" ValidationExpression = "^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="Manufacture"></asp:RegularExpressionValidator>
        </div>   
    <div class="col-sm-12">
           <asp:TextBox autocomplete="off"  ID="ManufacturerPostal" Width="170" runat="server" PlaceHolder="Postal Code" TabIndex="82" type="text" ></asp:TextBox>
                              <br />
                                  <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "ManufacturerPostal" ID="RegularExpressionValidator35" ValidationExpression = "^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="Manufacture"></asp:RegularExpressionValidator>
            </div>         
  </div>
                 
                  </div>
              <div class="col-sm-3">
<div class="form-group row">   
    <div class="col-sm-12">
       <asp:TextBox autocomplete="off"  runat="server" Width="265" type="text" ID="ManufacturerName" PlaceHolder="Name" TabIndex="74" ></asp:TextBox>
                                        <br />
                       <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "ManufacturerName" ID="RegularExpressionValidator29" ValidationExpression = "^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="Manufacture"></asp:RegularExpressionValidator>
    </div>
    <br />
    <br />
        <div class="col-sm-12">
            <asp:TextBox autocomplete="off"  ID="ManufacturerAddress1" Width="265" runat="server" PlaceHolder="Address1" TabIndex="77" type="text" ></asp:TextBox>
                               <br />
                               <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "ManufacturerAddress1" ID="RegularExpressionValidator34" ValidationExpression = "^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Manufacture"></asp:RegularExpressionValidator>
            </div>
    <div class="col-sm-12">
       <asp:TextBox autocomplete="off"  ID="ManufacturerSubDivi" Style="text-transform: uppercase" Width="265" ValidationGroup="Manufacture" placeholder="Sub Division" runat="server" TabIndex="80" type="text"></asp:TextBox>
    <asp:RegularExpressionValidator Display="Dynamic" BackColor="yellow" ControlToValidate="ManufacturerSubDivi" ID="RegularExpressionValidator137" ValidationExpression="^[\s\S]{0,9}$" runat="server" ErrorMessage="Maximum 9 characters allowed." ValidationGroup="Manufacture"></asp:RegularExpressionValidator>
    </div>
        
    <br /> 
    <br />
                    
  </div>
                 
                  </div>
              <div class="col-sm-3">
<div class="form-group row">    
    <div class="col-sm-12">
        <asp:TextBox autocomplete="off"  ID="ManufacturerName1" Width="265" runat="server" PlaceHolder="Name1" TabIndex="75" type="text" ></asp:TextBox>
                                        <br />
                      <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "ManufacturerName1" ID="RegularExpressionValidator28" ValidationExpression = "^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed." ValidationGroup="Manufacture"></asp:RegularExpressionValidator>
    </div>
    <br />   
    <br />
        <div class="col-sm-12">
            <asp:TextBox autocomplete="off"  ID="ManufacturerCity" Width="265" runat="server" Placeholder="City" TabIndex="78" type="text" ></asp:TextBox>
                              <br />
                                   <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "ManufacturerCity" ID="RegularExpressionValidator32" ValidationExpression = "^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Manufacture"></asp:RegularExpressionValidator>
            </div>        
    <br />
    <br />    
        <div class="col-sm-12">
             <asp:TextBox autocomplete="off"  ID="ManufacturerCountry" Width="265" runat="server" PlaceHolder="Country" TabIndex="81" type="text" ></asp:TextBox>
                              <br />
                                 <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "ManufacturerCountry" ID="RegularExpressionValidator36" ValidationExpression = "^[\s\S]{0,2}$" runat="server" ErrorMessage="Maximum 2 characters allowed." ValidationGroup="Manufacture"></asp:RegularExpressionValidator>
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
          <asp:UpdatePanel ID ="cocargo" UpdateMode ="Conditional" runat ="server">
           <ContentTemplate>
         <div class="row">
            <div class="col-sm-6" id="InwardDetailsdiv1" runat="server" visible="false">
                <div  id="carMode" runat="server" class="form-group row">
    <label for="staticEmail" class="col-sm-3 col-form-label">Mode
</label>
    <div class="col-sm-9">
        <asp:TextBox autocomplete="off"  Enabled="false" Width="350" BackColor="#e8f0fe"   runat="server" type="text" ID="TextMode" OnTextChanged="TextMode_TextChanged" AutoPostBack="true"  ></asp:TextBox>
    </div>
  </div>
                <div id="carArrival" runat="server" class="form-group row">
    <label for="staticEmail" class="col-sm-3 col-form-label">Arrival Date & Time
</label>
    <div class="col-sm-9">
        <input type="date" id='TxtArrivalDate1' style="width:350px;"  runat="server"   />
                                                        <span class="input-group-addon" style="display:none;">
                                                            <span class="glyphicon glyphicon-calendar"></span>
                                                        </span>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="TxtArrivalDate1" Display="None" ErrorMessage="Cargo --> Arrival Date is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
    </div>
  </div>                
                <div class="form-group row">
                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                            Loading Port&nbsp;&nbsp;&nbsp;&nbsp; <i class='fa fa-search' data-toggle="modal" data-target="#loadingSearch"></i>
                                                                        </label>
                                                                        <div class="col-sm-9">
                                                                            <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe" Width="175"    type="text" ID="TxtLoadShort" OnTextChanged="TxtLoadShort_TextChanged" AutoPostBack="true" ></asp:TextBox>
                                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="TxtLoadShort" Display="None" ErrorMessage="Cargo --> Loading Port is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                            <asp:TextBox autocomplete="off"  runat="server" type="text" ID="TxtLoad"  Width="175" ></asp:TextBox>
                                                                        </div>
                                                                    </div>  
                <div id="InwardFlight" runat="server">
                        <div  class="form-group row">
    <label for="staticEmail" class="col-sm-3 col-form-label">Flight Number
</label>
    <div class="col-sm-9">
        <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe"  ValidationGroup="Validation" Width="350"  type="text" ID="txtflight" TabIndex="56" ></asp:TextBox>
                                               <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtflight" Display="None" ErrorMessage="Cargo -->Flight Number is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
    </div>
  </div>
                        <div  class="form-group row">
    <label for="staticEmail" class="col-sm-3 col-form-label">Aircraft Register Number
</label>
    <div class="col-sm-9">
        <asp:TextBox autocomplete="off"  runat="server"   ValidationGroup="Validation"  Width="350" type="text" ID="txtaircraft" TabIndex="57" ></asp:TextBox>
    </div>
  </div>
                        <div  class="form-group row">
    <label for="staticEmail" class="col-sm-3 col-form-label">Master Air Waybill
</label>
    <div class="col-sm-9">
        <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe"  ValidationGroup="Validation" Width="350"  type="text" ID="txtwaybill" TabIndex="58" ></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtwaybill" Display="None" ErrorMessage="Cargo -->Master Air Waybill is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
    </div>
  </div>
                        </div>         
                <div id="InwardSea" runat="server">
                        <div  class="form-group row">
    <label for="staticEmail" class="col-sm-3 col-form-label">Voyage Number
</label>
    <div class="col-sm-9">
        <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe"  ValidationGroup="Validation" Width="350"  type="text" ID="TxtVoyageno" TabIndex="59" ></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="TxtVoyageno" Display="None" ErrorMessage="Cargo -->Voyage Number is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "TxtVoyageno" ID="RegularExpressionValidator102" ValidationExpression = "^[\s\S]{0,15}$" runat="server" ErrorMessage="Maximum 15 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
    </div>
  </div>
                        <div  class="form-group row">
    <label for="staticEmail" class="col-sm-3 col-form-label">Vessel Name
</label>
    <div class="col-sm-9">
        <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe"  ValidationGroup="Validation"  Width="350" type="text" ID="TxtVesselName" TabIndex="60" ></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="TxtVesselName" Display="None" ErrorMessage="Cargo -->Vessel Name is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                <br />
                                                     <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "TxtVesselName" ID="RegularExpressionValidator7" ValidationExpression = "^[\s\S]{0,15}$" runat="server" ErrorMessage="Maximum 15 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
    </div>
  </div>
                        <div  class="form-group row">
    <label for="staticEmail" class="col-sm-3 col-form-label">OBL
</label>
    <div class="col-sm-9">
       <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe" ValidationGroup="Validation" Width="350"  type="text" ID="TxtOceanBill" TabIndex="93" ></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="TxtOceanBill" Display="None" ErrorMessage="Cargo -->Ocean Bill Of Lading Number is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "TxtOceanBill" ID="RegularExpressionValidator104" ValidationExpression = "^[\s\S]{0,35}$" runat="server" ErrorMessage="Maximum 35 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
    </div>
  </div>
                        </div>   
                <div id="InwardOther" runat="server"> 
                        <div  class="form-group row">
    <label for="staticEmail" class="col-sm-3 col-form-label">Conveyance Ref.No
</label>
    <div class="col-sm-9">
        <asp:TextBox autocomplete="off"  runat="server" type="text"  ValidationGroup="Validation" ID="TxtConRefNo" Width="350" TabIndex="62" ></asp:TextBox>
                                                     <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "TxtConRefNo" ID="RegularExpressionValidator9" ValidationExpression = "^[\s\S]{0,15}$" runat="server" ErrorMessage="Maximum 15 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
    </div>
  </div>
                        <div  class="form-group row">
    <label for="staticEmail" class="col-sm-3 col-form-label">Transport ID
</label>
    <div class="col-sm-9">
        <asp:TextBox autocomplete="off"  runat="server" type="text"  ValidationGroup="Validation" ID="TxtTrnsID" Width="350" TabIndex="63" ></asp:TextBox>
                                               <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "TxtTrnsID" ID="RegularExpressionValidator10" ValidationExpression = "^[\s\S]{0,15}$" runat="server" ErrorMessage="Maximum 15 characters allowed." ValidationGroup="Validation"></asp:RegularExpressionValidator>
    </div>
  </div>
                        </div>  
                <div class="form-group row">
                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                            Release Location&nbsp; <i class='fa fa-search' data-toggle="modal" data-target="#LOCATION"></i>
                                                                        </label>
                                                                        <div class="col-sm-9">
                                                                            <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe" Width="175"  type="text" ID="txtreLoctn" OnTextChanged="txtreLoctn_TextChanged" AutoPostBack="true" TabIndex="64" ></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtreLoctn" Display="None" ErrorMessage="Cargo -->Release Location Code is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                            <asp:TextBox autocomplete="off"  runat="server" type="text" ID="txtrelocDeta" Width="175" TabIndex="65" ></asp:TextBox>
                                                                        </div>
                                                                    </div>  
                <div class="form-group row">
                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                            Receipt Location&nbsp; <i class='fa fa-search' data-toggle="modal" data-target="#Receipt"></i>
                                                                        </label>
                                                                        <div class="col-sm-9">
                                                                            <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe" Width="175"  type="text" OnTextChanged="txtrecloctn_TextChanged" AutoPostBack="true" ID="txtrecloctn" TabIndex="66"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtrecloctn" Display="None" ErrorMessage="Cargo -->Receipt Location Code is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                            <asp:TextBox autocomplete="off"  runat="server" type="text" ID="txtrecloctndet" Width="175" TabIndex="67" ></asp:TextBox>
                                                                        </div>
                                                                    </div>
                <div class="form-group row">
                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                            Storage Location&nbsp; <i class='fa fa-search' data-toggle="modal" data-target="#Storage"></i>
                                                                        </label>
                                                                        <div class="col-sm-9">
                                                                            <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe" Width="175"  type="text" OnTextChanged="TxtStorageShort_TextChanged" AutoPostBack="true" ID="TxtStorageShort" TabIndex="66"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator63" runat="server" ControlToValidate="txtrecloctn" Display="None" ErrorMessage="Cargo -->Receipt Location Code is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                            <asp:TextBox autocomplete="off"  runat="server" type="text" ID="TxtStorageName" Width="175" TabIndex="67" ></asp:TextBox>
                                                                        </div>
                                                                    </div> 
                </div>


                   <div id ="outtr" runat ="server"  class="col-sm-6">
                <div  class="row Borderdiv" style="width:100%">
                                             Outward Details
                                        </div>
              <br />
              <div  class="form-group row">
    <label for="staticEmail" class="col-sm-4 col-form-label">Mode
</label>
    <div class="col-sm-8">
        <asp:TextBox autocomplete="off"  Enabled="false" Width="350" BackColor="#e8f0fe"   runat="server" type="text" ID="TxtExpMode" OnTextChanged="TxtExpMode_TextChanged" AutoPostBack="true" ></asp:TextBox>
    </div>
  </div>
                       <div  class="form-group row">
    <label for="staticEmail" class="col-sm-4 col-form-label">Departure Date & Time
</label>
    <div class="col-sm-8">
        <asp:TextBox autocomplete="off"  ID="TxtExpArrivalDate1" style="width:350px;" TabIndex="87" AutoPostBack="true" onkeypress="return noAlphabets(event)"

  runat="server" OnTextChanged="TxtExpArrivalDate1_TextChanged" ></asp:TextBox>         
<cc1:CalendarExtender ID="CalendarExtender2" CssClass="cal_Theme1" PopupButtonID="imgPopup" runat="server" TargetControlID="TxtExpArrivalDate1" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"> </cc1:CalendarExtender>  
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ControlToValidate="TxtExpArrivalDate1" Display="None" ErrorMessage="Cargo --> Arrival Date is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
    </div>
  </div>
                       <div class="form-group row">
                                                                        <label for="staticEmail" class="col-sm-4 col-form-label">
                                                                            <div class="row">
       <div class="col-sm-9">
               Discharge Port
       </div>
       <div class="col-sm-3">
                                                                                            
            <asp:ImageButton id="btncodischargeport1" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15"  Style="margin-top:-250px;" />
                                                                                            
         
     </div>
   </div>
                                                                      
                                                                        </label>
<cc1:ModalPopupExtender ID="popupcodischargeport" runat="server" PopupControlID="pnlcodischargeport" TargetControlID="btncodischargeport1"
 OkControlID="btnYescodischargeport" CancelControlID="btnNocodischargeport" BackgroundCssClass="modalBackground">
  </cc1:ModalPopupExtender>

<asp:Panel ID="pnlcodischargeport" runat="server" CssClass="modalPopup" Style="display: none">
<div class="header">
 DISCHARGE PORT
</div>
 <div class="body">
 <asp:UpdatePanel ID="upcodischargeport" runat="server" UpdateMode="Conditional">
   <ContentTemplate>
        <asp:TextBox autocomplete="off"  ID="ExpLoadingSearch"  OnTextChanged="ExpLoadingSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code"   class="form-control" runat="server"  ></asp:TextBox>
                                                        <br />
                                                        <asp:GridView ID="ExportGrid"  PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ExportGrid_PageIndexChanging" OnRowCommand ="ExportGrid_RowCommand" OnRowDataBound ="ExportGrid_RowDataBound"  CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                            <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>


                                                                <asp:TemplateField HeaderText="PortCode" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCode"  runat="server"
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
                                                                        <asp:Label ID="lblName1"  runat="server"
                                                                            Text='<%#Eval("Country")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                               
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                      <asp:LinkButton ID="LnkExport" runat="server" CommandArgument='<%# Eval("Id") %>'   OnCommand="LnkExport_Command" >Select </asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
 </ContentTemplate>
<%--  <Triggers>
<asp:PostBackTrigger ControlID="ExportGrid" />
  </Triggers>--%>


 </asp:UpdatePanel>
 </div>
 <div class="footer" align="right">
 <asp:Button ID="btnYescodischargeport" runat="server" Text="Yes" CssClass="yes" />
  <asp:Button ID="btnNocodischargeport" runat="server" Text="No" CssClass="no" />
   </div>
  </asp:Panel>
                                                                        <div class="col-sm-8">
                                                                            <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe"    type="text" ID="TxtExpLoadShort" OnTextChanged="TxtExpLoadShort_TextChanged" AutoPostBack="true" TabIndex="88" Width="175"></asp:TextBox>
                                                                             <cc1:AutoCompleteExtender ServiceMethod="DischargePort"
    MinimumPrefixLength="1"
    CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem"  CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
    TargetControlID="TxtExpLoadShort"
    ID="AutoCompleteExtender18" runat="server" FirstRowSelected = "true">
</cc1:AutoCompleteExtender>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ControlToValidate="TxtExpLoadShort" Display="None" ErrorMessage="Cargo --> Loading Port is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                                                            <asp:TextBox autocomplete="off"  runat="server" type="text" ID="TxtExpLoad" TabIndex="89"  Width="175"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                       <div  class="form-group row">
    <label for="staticEmail" class="col-sm-4 col-form-label">Final Destination Country
</label>
    <div class="col-sm-8">
        <asp:DropDownList CssClass="drop"  Width="350" BackColor="#e8f0fe"   runat="server"  ID="DrpFinalDesCountry" TabIndex="90" ></asp:DropDownList>
        <%--<asp:Label ID="lblfinalcountry" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>--%>
    </div>
  </div>
         <div id="seasore" runat ="server" visible ="false">             
                       <div  class="form-group row">
    <label for="staticEmail" class="col-sm-4 col-form-label">Sea Store
</label>
    <div class="col-sm-8">
        <asp:CheckBox ID="chkSea" runat="server" TabIndex="91" />
    </div>
  </div>
             </div> 
                       <div id="OUTWARDFlight" runat="server">
                  <div  class="form-group row">
    <label for="staticEmail" class="col-sm-4 col-form-label">Flight Number
</label>
    <div class="col-sm-8">
        <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe" Width="350"  type="text" ID="OUTWARDFlightN0" TabIndex="92" ></asp:TextBox>
                                               <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ControlToValidate="txtflight" Display="None" ErrorMessage="Cargo -->Flight Number is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
    </div>
  </div>
                  <div  class="form-group row">
    <label for="staticEmail" class="col-sm-4 col-form-label">Aircraft Register Number
</label>
    <div class="col-sm-8">
        <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe"  Width="350" type="text" ID="OUTWARDAirREgno" TabIndex="93" ></asp:TextBox>
    </div>
  </div>                  
                  </div>
                       <div id="OUTWARDSea" runat="server">
                  <div  class="form-group row">
    <label for="staticEmail" class="col-sm-4 col-form-label">Voyage Number
</label>
    <div class="col-sm-8">
        <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe" Width="350"  type="text" ID="OUTWARDVoyageNo" TabIndex="94" ></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator52" runat="server" ControlToValidate="TxtVoyageno" Display="None" ErrorMessage="Cargo -->Voyage Number is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
    </div>
  </div>
                  <div  class="form-group row">
    <label for="staticEmail" class="col-sm-4 col-form-label">Vessel Name
</label>
    <div class="col-sm-8">
        <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe"  Width="350" type="text" ID="OUTWARDVessel" TabIndex="95" ></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator53" runat="server" ControlToValidate="TxtVesselName" Display="None" ErrorMessage="Cargo -->Vessel Name is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
    </div>
  </div>                  
                  </div>
                       <div id="OUTWARDOther" runat="server">  
                  <div  class="form-group row">
    <label for="staticEmail" class="col-sm-4 col-form-label">Conveyance Ref.No
</label>
    <div class="col-sm-8">
        <asp:TextBox autocomplete="off"  runat="server" type="text" ID="OUTWARDConref" Width="350" TabIndex="96" ></asp:TextBox>
    </div>
  </div>
                  <div  class="form-group row">
    <label for="staticEmail" class="col-sm-4 col-form-label">Transport ID
</label>
    <div class="col-sm-8">
        <asp:TextBox autocomplete="off"  runat="server" type="text" ID="OUTWARDTransId" Width="350" TabIndex="97" ></asp:TextBox>
    </div>
  </div>
                  </div>
                       <div id="OUTWARDVesl" visible ="false" runat="server">
                  <div  class="form-group row">
    <label for="staticEmail" class="col-sm-4 col-form-label">Vessel Type
</label>
    <div class="col-sm-8">
        <asp:DropDownList CssClass="drop" ID="ddpVessel" TabIndex ="98" runat="server" Width="350" ></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator55" runat="server" ControlToValidate="ddpVessel" Display="None" ErrorMessage="Cargo -->Master Air Waybill is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
    </div>
  </div>
                  <div  class="form-group row">
    <label for="staticEmail" class="col-sm-4 col-form-label">Vessel Net Register Tonnage
</label>
    <div class="col-sm-8">
        <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe"  Width="350" type="text" ID="txtvesnet"  ></asp:TextBox>
    </div>
  </div>
                  <div  class="form-group row">
    <label for="staticEmail" class="col-sm-4 col-form-label">Vessel Nationality
</label>
    <div class="col-sm-8">
        <asp:DropDownList CssClass="drop"  Width="350" BackColor="#e8f0fe"   runat="server"  ID="DroVesslNat" TabIndex="85" ></asp:DropDownList>
    </div>
  </div>
                  <div  class="form-group row">
    <label for="staticEmail" class="col-sm-4 col-form-label">Towing Vessel ID
</label>
    <div class="col-sm-8">
        <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe" Width="350"  type="text" ID="txtTowVes"  ></asp:TextBox>
    </div>
  </div>
                  <div  class="form-group row">
    <label for="staticEmail" class="col-sm-4 col-form-label">Towing Vessel Name
</label>
    <div class="col-sm-8">
       <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe"  Width="350" type="text" ID="txtTowVesName" ></asp:TextBox>
    </div>
  </div>
                  <div  class="form-group row">
    <label for="staticEmail" class="col-sm-4 col-form-label">Next Port <i class='fa fa-search' data-toggle="modal" data-target="#loadingSearch1"></i>
</label>
    <div class="col-sm-8">
        <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe" Width="175"  type="text" ID="txtNextprt" AutoPostBack="true" OnTextChanged="txtNextprt_TextChanged" TabIndex="88" ></asp:TextBox> 
                                                    <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe" Width="175"  type="text" ID="txtNetPrtSer"  ></asp:TextBox>                                               
    </div>
  </div>
                  <div  class="form-group row">
    <label for="staticEmail" class="col-sm-3 col-form-label">Last Port <i class='fa fa-search' data-toggle="modal" data-target="#loadingSearch2"></i>
</label>
    <div class="col-sm-9">
         <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe" Width="175"  type="text" ID="txtLasPrt" AutoPostBack="true" OnTextChanged="txtLasPrt_TextChanged" TabIndex="90" ></asp:TextBox> 
                                                    <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe" Width="175"  type="text" ID="txtLasPrtSer" ></asp:TextBox>                                            
        </div>
  </div>
                  </div>
                       </div>
          </div>
        <div class="row" id="outerpack" runat="server" visible ="false"  >
                <div class="col-sm-12" >
            <div  class="col-sm-5">
                <div  class="row Borderdiv" style="width:100%">
                                             Outer Pack Details
                                        </div>
                <br />
                <div class="form-group row">
                                                                        <label for="staticEmail" class="col-sm-5 col-form-label">
                                                                           Total Outer Pack
                                                                        </label>
                                                                        <div class="col-sm-7">
                                                                           <asp:TextBox autocomplete="off"  runat="server" type="text"  ID="TxttotalOuterPack" TabIndex="98" AutoPostBack="true" OnTextChanged="TxttotalOuterPack_TextChanged" Width="100"></asp:TextBox>
                                                        <asp:DropDownList CssClass="drop" ID="DrptotalOuterPack" runat="server" TabIndex="99" Width="100" Height="26" AutoPostBack="true" OnSelectedIndexChanged="DrptotalOuterPack_SelectedIndexChanged"></asp:DropDownList>
                                                                        </div>
                                                                    </div>
                 <div class="form-group row">
                                                                        <label for="staticEmail" class="col-sm-5 col-form-label">
                                                                           Total Gross Weight
                                                                        </label>
                                                                        <div class="col-sm-7">
                                                                           <asp:TextBox autocomplete="off"  runat="server" type="text" ID="TxtTotalGrossWeight" TabIndex="100" Width="100" AutoPostBack="true" OnTextChanged="TxtTotalGrossWeight_TextChanged"></asp:TextBox>
                                                        <asp:DropDownList CssClass="drop" ID="DrpTotalGrossWeight" runat="server" Width="100" TabIndex="101" Height="26" AutoPostBack="true" OnSelectedIndexChanged="DrpTotalGrossWeight_SelectedIndexChanged">
                                                             <asp:ListItem Selected="True" Text="--Select--" Value="--SELECT--"> </asp:ListItem>
                                                                                    <asp:ListItem Selected="false" Text="KGM" Value="KGM"> </asp:ListItem>
                                                                                    <asp:ListItem Selected="false" Text="TNE" Value="TNE"> </asp:ListItem>
                                                        </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                </div>
                    <div class="col-sm-7">
                        <div id="ContainerDetails" runat="server" visible="false">  
<asp:gridview ID="ContarinerGrid" runat="server" OnRowDeleting="ContarinerGrid_RowDeleting" OnRowDataBound="ContarinerGrid_RowDataBound1" ShowFooter="true"   AutoGenerateColumns="false">  
        <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns> 
            <asp:TemplateField  HeaderText ="S.No"  >
        <ItemTemplate>
             <%#Container.DataItemIndex+1 %>
        </ItemTemplate>
    </asp:TemplateField> 
            <asp:BoundField DataField="RowNumber" HeaderText="Row Number" Visible="false" />  
            <asp:TemplateField HeaderText="Container No">  
                <ItemTemplate>  
                    <asp:TextBox autocomplete="off"  ID="txt1" BackColor="#e8f0fe" TabIndex="92"  runat="server"></asp:TextBox>  
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txt1" Display="None" ErrorMessage="Cargo -->Container No is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                </ItemTemplate>  
            </asp:TemplateField>  
             <asp:TemplateField HeaderText="Size / Type">  
                <ItemTemplate>  
                   <asp:DropDownList CssClass="drop" id="DrpType" BackColor="#e8f0fe"  TabIndex="93"    runat="server" ></asp:DropDownList>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator231" InitialValue="0" runat="server" ControlToValidate="DrpType" Display="None" ErrorMessage="Cargo -->Size / Type is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                </ItemTemplate>  
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Weight ( TNE )">  
                <ItemTemplate>  
                    <asp:TextBox autocomplete="off"  ID="txt2" BackColor="#e8f0fe"  TabIndex="94" runat="server"></asp:TextBox>  
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2311" runat="server" ControlToValidate="txt2" Display="None" ErrorMessage="Cargo -->Weight ( TNE ) is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                </ItemTemplate>  
            </asp:TemplateField>  
            <asp:TemplateField HeaderText="Seal No">  
                <ItemTemplate>  
                    <asp:TextBox autocomplete="off"  ID="txt3" BackColor="#e8f0fe"  TabIndex="95"  runat="server"></asp:TextBox> 
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator23111" runat="server" ControlToValidate="txt3" Display="None" ErrorMessage="Cargo -->Seal No is Required" ValidationGroup="Validation"></asp:RequiredFieldValidator> 
                </ItemTemplate>  
                <FooterStyle HorizontalAlign="Right" />  
                <FooterTemplate>  
                    <asp:Button ID="ButtonAdd" runat="server" Text="Add Row"  onclick="ButtonAdd_Click" /> </FooterTemplate>  
            </asp:TemplateField>  
              <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />

        </Columns>  
    </asp:gridview>  
</div>
                                            </div>
                    </div>
                </div>
      
        <div class="row">
             <div class="col-sm-12" >
                  <div class="row" >
             <div class="col-sm-8"  >
                
                      
                 <div class="modal fade" id="loadingSearch" role="dialog">
                                    <div class="modal-dialog">

                                        <!-- Modal content-->
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                <h4 class="modal-title">Loading Port</h4>
                                            </div>
                                            <div class="modal-body">
                                                <asp:TextBox autocomplete="off"  ID="CarLoadingSearch"  OnTextChanged="CarLoadingSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code"   class="form-control" runat="server"  ></asp:TextBox>
                                                        <br />
                                                        <asp:GridView ID="LoadingGrid"  PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="LoadingGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                            <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>


                                                                <asp:TemplateField HeaderText="PortCode" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCode"  runat="server"
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
                                                                        <asp:Label ID="lblName1"  runat="server"
                                                                            Text='<%#Eval("Country")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                               
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                      <asp:LinkButton ID="LnkLoading" runat="server" CommandArgument='<%# Eval("Id") %>'   OnCommand="LnkLoading_Command" >Select </asp:LinkButton>
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
                                                <asp:TextBox autocomplete="off"  ID="NextPrtLoading"  OnTextChanged="NextPrtLoading_TextChanged" AutoPostBack="true" placeholder="Search here by Code"   class="form-control" runat="server"  ></asp:TextBox>
                                                        <br />
                                                        <asp:GridView ID="NextPortGrid"  PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="NextPortGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                            <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>


                                                                <asp:TemplateField HeaderText="PortCode" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCode"  runat="server"
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
                                                                        <asp:Label ID="lblName1"  runat="server"
                                                                            Text='<%#Eval("Country")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                               
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                      <asp:LinkButton ID="LnkLoading1" runat="server" CommandArgument='<%# Eval("Id") %>'   OnCommand="LnkLoading1_Command" >Select </asp:LinkButton>
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
                                                <asp:TextBox autocomplete="off"  ID="txtlastprt"  OnTextChanged="txtlastprt_TextChanged" AutoPostBack="true" placeholder="Search here by Code"   class="form-control" runat="server"  ></asp:TextBox>
                                                        <br />
                                                        <asp:GridView ID="LastGrid"  PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="LastGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                            <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>


                                                                <asp:TemplateField HeaderText="PortCode" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCode"  runat="server"
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
                                                                        <asp:Label ID="lblName1"  runat="server"
                                                                            Text='<%#Eval("Country")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                               
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                      <asp:LinkButton ID="LnkLoading2" runat="server" CommandArgument='<%# Eval("Id") %>'   OnCommand="LnkLoading2_Command" >Select </asp:LinkButton>
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
                                                <asp:TextBox autocomplete="off"  ID="LocationSearch"  OnTextChanged="LocationSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code"   class="form-control" runat="server"  ></asp:TextBox>
                                                        <br />
                                                        <asp:GridView ID="LocationGrid"  PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="LocationGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                            <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>


                                                                <asp:TemplateField HeaderText="Code" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCode"  runat="server"
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
                                                                        <asp:Label ID="lblName1"  runat="server"
                                                                            Text='<%#Eval("Description")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                               
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                      <asp:LinkButton ID="LnkLocation" runat="server" CommandArgument='<%# Eval("Id") %>'   OnCommand="LnkLocation_Command" >Select </asp:LinkButton>
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
                                                    <asp:TextBox autocomplete="off"  ID="ReceiptSearch"  OnTextChanged="ReceiptSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code"   class="form-control" runat="server"  ></asp:TextBox>
                                                        <br />
                                                        <asp:GridView ID="ReceiptGrid"  PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="ReceiptGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                            <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>


                                                                <asp:TemplateField HeaderText="Code" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCode"  runat="server"
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
                                                                        <asp:Label ID="lblName1"  runat="server"
                                                                            Text='<%#Eval("Description")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                               
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                      <asp:LinkButton ID="LnkReceipt" runat="server" CommandArgument='<%# Eval("Id") %>'   OnCommand="LnkReceipt_Command" >Select </asp:LinkButton>
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
                                                    <asp:TextBox autocomplete="off"  ID="StorageSearch"  OnTextChanged="StorageSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code"   class="form-control" runat="server"  ></asp:TextBox>
                                                        <br />
                                                        <asp:GridView ID="StorageGrid"  PageSize="5" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="StorageGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                            <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>


                                                                <asp:TemplateField HeaderText="Code" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCode"  runat="server"
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
                                                                        <asp:Label ID="lblName1"  runat="server"
                                                                            Text='<%#Eval("Description")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                               
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                      <asp:LinkButton ID="LnkStorage" runat="server" CommandArgument='<%# Eval("Id") %>'   OnCommand="LnkStorage_Command" >Select </asp:LinkButton>
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
                       <div class="col-sm-4" >
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
                     
                      <div class="col-sm-4"  >                                                                         
                       
                     </div>
                      <div class="col-sm-4" >

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
           
                 <br />
                 <br />
                   <div class="row">
                        <div class="col-sm-12">                                                                     
                                    <div id="gvAddrow">  
      
</div>                                 
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
             <asp:UpdatePanel ID ="coitem" UpdateMode ="Conditional" runat ="server">
           <ContentTemplate>
            <div class="row">       
               <div class="col-sm-8">
                   </div>
                     <div class="col-sm-4">
                            <asp:Button ID="BtnAddNEWItem" runat="server" Visible ="false" CssClass="btn btn-success btn-block" OnClick="BtnAddNEWItem_Click" Text="New Item" /> <br />
                   </div>
                   </div>    
           
         <div id="ItemDiv" runat="server">
             <div class="row">
                                                                <div class="col-sm-6">
                                                                    <div class="form-group row">
                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                            Item Code
                                                                        </label>
                                                                        <div class="col-sm-9">
                                                                            <asp:TextBox autocomplete="off"  ID="TxtInHouseItem"  Width="350" AutoPostBack="true" runat="server" TabIndex="106" type="text"></asp:TextBox><br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" ControlToValidate="TxtInHouseItem" ErrorMessage="Please Enter InHouse"
                                                Display="Dynamic" ValidationGroup="ItemMasterValidation5" ForeColor="Red"></asp:RequiredFieldValidator>
<asp:Label ID ="lblhserror" Visible="false" ForeColor="Red" BackColor="#ffff00" runat="server"></asp:Label> <br />
        <asp:Label ID ="lbldhserror" Visible="false" ForeColor="Red" BackColor="#ffff00" runat="server"></asp:Label> <br />
                                                                            </div>
                                                                        </div>
                                                                    <div class="form-group row">
                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                            HAWB NO
                                                                        </label>
                                                                        <div class="col-sm-9">
                                                                            <asp:TextBox autocomplete="off"  ID="txthawbl"  Width="350" AutoPostBack="true" runat="server"  type="text"></asp:TextBox><br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txthawbl" ErrorMessage="Please Enter InHouse"
                                                Display="Dynamic" ValidationGroup="ItemMasterValidation5" ForeColor="Red"></asp:RequiredFieldValidator>
<asp:Label ID ="Label2" Visible="false" ForeColor="Red" BackColor="#ffff00" runat="server"></asp:Label> <br />
        <asp:Label ID ="Label3" Visible="false" ForeColor="Red" BackColor="#ffff00" runat="server"></asp:Label> <br />
                                                                            </div>
                                                                        </div>
                                                                     <div class="form-group row">
                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                            HS Code
                                                                        </label>
                                                                        <div class="col-sm-9">
                                            <asp:TextBox autocomplete="off"  Width="350" ID="TxtHSCodeItem" ValidationGroup="Item"  BackColor="#e8f0fe" OnTextChanged="TxtHSCodeItem_TextChanged" AutoPostBack="true" runat="server" TabIndex="107" type="text"></asp:TextBox><br />
                                                <cc1:AutoCompleteExtender ServiceMethod="GetHSCodeItem"
                                                                                                    MinimumPrefixLength="1"
                                                                                                    CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem"  CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
                                                                                                    TargetControlID="TxtHSCodeItem"
                                                                                                    ID="AutoCompleteExtender12" runat="server" FirstRowSelected="true">
                                                                                                </cc1:AutoCompleteExtender>
                                                                             <br />
                                    <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "TxtHSCodeItem" ID="RegularExpressionValidator54" ValidationExpression = "^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 10 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>                                   
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator44" runat="server" ControlToValidate="TxtHSCodeItem" ErrorMessage="Please Enter HS Code"
                                                Display="Dynamic" ValidationGroup="ItemMasterValidation5" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group row">
                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                            Description
                                                                        </label>
                                                                        <div class="col-sm-9">
                                                                           <asp:TextBox autocomplete="off"  Width="350" ID="TxtDescription" MaxLength="512" Style="text-transform:uppercase "  ValidationGroup="Item"  BackColor="#e8f0fe" OnTextChanged="TxtDescription_TextChanged" AutoPostBack="true"  TextMode="MultiLine" Height="100" runat="server" TabIndex="108" type="text"></asp:TextBox> <br />
                                             <br />
                                              <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "TxtDescription" ID="RegularExpressionValidator53" ValidationExpression = "^[\s\S]{0,512}$" runat="server" ErrorMessage="Maximum 512 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" ControlToValidate="TxtDescription" ErrorMessage="Please Enter Description"
                                                Display="Dynamic" ValidationGroup="ItemMasterValidation5" ForeColor="Red"></asp:RequiredFieldValidator>                                                                                                                             
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
                                                                                            
                                                                                        <asp:ImageButton id="btncoorgin1" runat="server" ImageUrl="~/IMG/search.png" Height="15" Width="15"  Style="margin-top:-250px;" />
                                                                                            
         
                                                                                   </div>
                                                                                       </div>


                                                                          
                                                                        </label>
<cc1:ModalPopupExtender ID="popupcoorgin" runat="server" PopupControlID="pnlcoorgin" TargetControlID="btncoorgin1"
 OkControlID="btnYescoorgin" CancelControlID="btnNocoorgin" BackgroundCssClass="modalBackground">
  </cc1:ModalPopupExtender>

<asp:Panel ID="pnlcoorgin" runat="server" CssClass="modalPopup" Style="display: none">
<div class="header">
 Origin Country
</div>
 <div class="body">
 <asp:UpdatePanel ID="upcoorgin" runat="server" UpdateMode="Conditional">
   <ContentTemplate>
   <asp:TextBox autocomplete="off"  ID="CountrySearchItem" OnTextChanged="CountrySearchItem_TextChanged" AutoPostBack="true" placeholder="Search here by Code"   class="form-control" runat="server"  ></asp:TextBox>
                                                        <br />
                                                        <asp:GridView ID="CountryGridItem" OnPageIndexChanging="CountryGridItem_PageIndexChanging"  PageSize="5" AllowPaging="True" DataKeyNames="Id"  CssClass="table table-striped table-bordered table-hover" OnRowCommand ="CountryGridItem_RowCommand"  OnRowDataBound ="CountryGridItem_RowDataBound"  runat="server" AutoGenerateColumns="false">
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
                                                                        <asp:Label ID="lblName1"  runat="server"
                                                                            Text='<%#Eval("Description")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                              
                                                                
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                      <asp:LinkButton ID="lnkCountryItem" runat="server" CommandArgument='<%# Eval("Id") %>'  OnClick="lnkCountryItem_Click"  >Select </asp:LinkButton>
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
 <asp:Button ID="btnYescoorgin" runat="server" Text="Yes" CssClass="yes" />
  <asp:Button ID="btnNocoorgin" runat="server" Text="No" CssClass="no" />
   </div>
  </asp:Panel>
                                                                        <div class="col-sm-9">
                                                                            <asp:TextBox autocomplete="off"  Width="175" ID="TxtCountryItem" BackColor="#e8f0fe"  OnTextChanged="TxtCountryItem_TextChanged" AutoPostBack="true" runat="server" TabIndex="109" type="text"></asp:TextBox>
                                                                            <asp:TextBox autocomplete="off"  Width="175" ID ="txtcname" runat="server" Enabled="false"></asp:TextBox>
                                                                            <cc1:AutoCompleteExtender ServiceMethod="GetCountryItem"
    MinimumPrefixLength="1"
    CompletionInterval="100" CompletionListCssClass="ac_results" CompletionListItemCssClass="listItem"  CompletionListHighlightedItemCssClass="itemHighlighted" EnableCaching="false" CompletionSetCount="10"
    TargetControlID="TxtCountryItem"
    ID="AutoCompleteExtender17" runat="server" FirstRowSelected = "true">
</cc1:AutoCompleteExtender> 
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator46" runat="server" ControlToValidate="TxtCountryItem" ErrorMessage="Please Enter Country Of Origin"
                                                Display="Dynamic" ValidationGroup="ItemMasterValidation" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </div>
                                                                    <div id="coi" runat ="server" visible ="false" >
                                                                    <div  id="Vehicle" runat="server">
                                                                        <div class="form-group row">
                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">Vehicle Type</label>
                                                                            <div class="col-sm-9">
                                                                                <asp:DropDownList ID="DrpVehicleType" CssClass="drop"  runat="server" Width="350" Height="25" TabIndex="101"></asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group row">
                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">Engine Capacity</label>
                                                                            <div class="col-sm-9">
                                                                                <asp:TextBox autocomplete="off"  runat="server"  type="text" Text="" ID="TextBox4" Width="175" TabIndex="97"></asp:TextBox>
                                            <asp:DropDownList CssClass="drop"  ID="DrpVehicleCapacity" runat="server" Width="175" Height="25" TabIndex="98"></asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group row">
                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">Original Registration Date</label>
                                                                            <div class="col-sm-9">
                                                                                <input type='Date' id='OriginalRegDate'  style="width:350px;" runat="server"  />
                                                <span class="input-group-addon" style="display:none;">
                                                    <span class="glyphicon glyphicon-calendar"></span>
                                                </span>
                                                                            </div>
                                                                        </div>
                                                                        </div>
<div id="totDuticableQtyDiv" runat="server" visible="false">
                                                                    <div runat ="server" visible ="false"  class="form-group row">
                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">Duti Quantity</label>
                                                                        <div class="col-sm-9">
                                                                            <asp:TextBox autocomplete="off"  runat="server"  type="text" Width="175" ValidationGroup="Item" Text="0.00" ID="TxtTotalDutiableQuantity" TabIndex="97"></asp:TextBox>
                                            <asp:DropDownList CssClass="drop"  ID="TDQUOM" runat="server" Width="175" Height="25" TabIndex="98"></asp:DropDownList>
<asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "TxtTotalDutiableQuantity" ID="RegularExpressionValidator58" ValidationExpression = "^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                    </div>
                                                                   
                                                                    </div>
                                                                         <div class="form-group row">
                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">Total Duti Quantity</label>
                                                                            <div class="col-sm-9">
                                                                                <asp:TextBox autocomplete="off"  runat="server"  type="text" ValidationGroup="Item" Width="175" Text="0.00" ID="txttotDutiableQty" TabIndex="97"></asp:TextBox>
                                            <asp:DropDownList CssClass="drop"  ID="ddptotDutiableQty" runat="server" Width="175" Height="25" TabIndex="98"></asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                        
                                                                    <div class="form-group row">
                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">Invoice Quantity</label>
                                                                        <div class="col-sm-9">
                                                                            <asp:TextBox autocomplete="off"  runat="server"  Width="350" type="text" ValidationGroup="Item" Text="0.00" ID="TxtInvQty" OnTextChanged="TxtInvQty_TextChanged" AutoPostBack="true" ></asp:TextBox>
                             <br />
    <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "TxtInvQty" ID="RegularExpressionValidator59" ValidationExpression = "^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group row">
                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">Hs Quantity</label>
                                                                        <div class="col-sm-9">
                                                                            <asp:TextBox autocomplete="off"  runat="server" BackColor="#e8f0fe" Width="175" ValidationGroup="Item" type="text" ID="TxtHSQuantity" ></asp:TextBox>
                                    <asp:DropDownList CssClass="drop" ID="HSQTYUOM" runat="server" Width="175" OnSelectedIndexChanged="HSQTYUOM_SelectedIndexChanged" AutoPostBack="true" Height="25"></asp:DropDownList>
                                                                            <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "TxtHSQuantity" ID="RegularExpressionValidator62" ValidationExpression = "^[\s\S]{0,16}$" runat="server" ErrorMessage="Maximum 16 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                        </div>
                                                                    </div>
                                                                       
                                                                         </div>
                                                                            
                                                                    <div id="AlcoholDiv" runat="server" visible="false">
                                                                        <div class="form-group row">
                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">Alcohol Percentage</label>
                                                                            <div class="col-sm-9">
                                                                                <asp:TextBox autocomplete="off"  runat="server"   Width="350" ValidationGroup="Item"  type="text"  Text="0.00" ID="txtAlcoholPer" TabIndex="99"></asp:TextBox>
                                                                            </div>
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
                 <div class="col-sm-6">
                     <div class="form-group row">
                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                           Currency ( Unit Price 
                                                <asp:CheckBox ID="ChkUnitPrice" CausesValidation="true"  OnCheckedChanged="ChkUnitPrice_CheckedChanged" AutoPostBack="true" runat="server" TabIndex="110" />Auto )
                                                                        </label>
                                                                        <div class="col-sm-9">
                                                                            <asp:DropDownList CssClass="drop" ID="DRPCurrency" BackColor="#e8f0fe" CausesValidation="true" OnSelectedIndexChanged="DRPCurrency_SelectedIndexChanged" TabIndex="111" AutoPostBack="true" runat="server" Width="175" Height="25"></asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" InitialValue="0" ControlToValidate="DRPCurrency" ErrorMessage="Item--->Choose Currency"
Display="None" ValidationGroup="Item" ForeColor="Red"></asp:RequiredFieldValidator> 
<asp:TextBox autocomplete="off"  ID="TxtUnitPrice" Enabled="false" Text = "0.00" runat="server" Width="70" Height="25" TabIndex="144"></asp:TextBox>
                                                                             <asp:TextBox autocomplete="off"  ID="TxtExchangeRate" Enabled="false" Text = "0.00" runat="server" Width="175" Height="25" TabIndex="112"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                     <div id="OptionalCharges" visible ="false"  runat="server">
                <div runat ="server"  class="form-group row">
                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                Optional Charges
                                                                            </label>
                                                                            <div class="col-sm-9">
                                                                                <asp:DropDownList CssClass="drop"  ID="DrpOptionalUom" BackColor="#e8f0fe" CausesValidation="true" OnSelectedIndexChanged ="DrpOptionalUom_SelectedIndexChanged"  AutoPostBack="true" runat="server" Width="175" Height="25"></asp:DropDownList>
                                             <asp:RequiredFieldValidator BackColor="Red" InitialValue="0" ID="RequiredFieldValidator54" runat="server" ControlToValidate="DRPCurrency" Display="None" ErrorMessage="Item --> Plase Select Currency info" ValidationGroup="Validation"></asp:RequiredFieldValidator>
                                            <asp:TextBox autocomplete="off"  runat="server"  Width="175" Text = "0.00" ID="TxtOptionalPrice" OnTextChanged="TxtOptionalPrice_TextChanged" AutoPostBack="true" ></asp:TextBox>
                                                                            </div>
                                                                        </div>
                <div class="form-group row">
                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                            </label>
                                                                            <div class="col-sm-9">
                                                                                <asp:TextBox autocomplete="off"  ID="TxtOptionalExchageRate" Enabled="false"  Text = "0.00" runat="server" Width="175" Height="25"></asp:TextBox>
                                            <asp:RequiredFieldValidator  BackColor="Red" InitialValue="0.00" ID="RequiredFieldValidator6" runat="server" ControlToValidate="TxtExchangeRate" Display="None" ErrorMessage="Item --> Plase Enter Amount" ValidationGroup="Item"></asp:RequiredFieldValidator>
                                            <asp:TextBox autocomplete="off"  runat="server" type="text" ID="TxtOptionalSumExRate" TabIndex="106" Width="175"   Text = "0.00"  ></asp:TextBox>
                                                                            </div>
                                                                        </div>
                </div>
                     <div class="form-group row">
                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                            Total Line Amount 
                                                                        </label>
                                                                        <div class="col-sm-9">
                                                                            <asp:Label ID="Lbl3" Font-Size="9" Text="Total Line Amount" Visible="false"  runat="server" Width="100"></asp:Label><br />
                                            <asp:TextBox autocomplete="off"  BackColor="#e8f0fe" CausesValidation="true"  OnTextChanged="TxtTotalLineAmount_TextChanged" onkeypress="return noAlphabets(event)" Text = "0.00" AutoPostBack="true" runat="server" Width="350" type="text" ID="TxtTotalLineAmount" TabIndex="113"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                     <div class="form-group row">
                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                            CIF/FOB (SGD) 
                                                                        </label>
                                                                        <div class="col-sm-9">
                                                                            <asp:Label Font-Size="9" Text="CIF/FOB (SGD)" ID="Label4" runat="server" Visible="false"  Width="100"></asp:Label><br />
                                                                            <asp:TextBox autocomplete="off"  runat="server" onkeypress="return noAlphabets(event)" type="text" Width="350" ID="TxtCIFFOB" Text = "0.00" ></asp:TextBox>
                                                                        </div>
                                                                    </div>
                     <div class="form-group row">
                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                            Invoice Quantity
                                                                        </label>
                                                                        <div class="col-sm-9">
                                                                            <asp:Label Font-Size="9" Text="Invoice Quantity" ID="Label1" runat="server" Visible="false"  Width="100"></asp:Label><br />
                                                                            <asp:TextBox autocomplete="off" onkeypress="return noAlphabets(event)"  runat="server" type="text" Width="350" ID="TxtInvQTY2" OnTextChanged ="TxtInvQTY2_TextChanged" AutoPostBack ="true"    Text = "0.00" TabIndex="85"></asp:TextBox>
                                                                             <asp:Label runat="server" ID="lblinvqty" Visible="false" ForeColor="Red" BackColor="Yellow"></asp:Label>
                                                                        </div>
                                                                    </div>
                     <div class="form-group row">
                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                            HS Quantity
                                                                        </label>
                                                                        <div class="col-sm-9">
                                                                           <%-- <asp:Label Font-Size="9" Text="HS Quantity" ID="Label2" runat="server"  Width="100"></asp:Label><br />--%>
                                            <asp:TextBox autocomplete="off"  runat="server" type="text" Width="175" ID="TxtHSQty" Text = "0.00" TabIndex="114"></asp:TextBox>
                                            <asp:DropDownList CssClass="drop" ID="drpInvoiceUOM" runat="server" Width="175"  TabIndex="115"></asp:DropDownList>
                                                                        </div>
                                                                    </div>
                      <div class="form-group row">
                                                                      
                                                   <label for="staticEmail" class="col-sm-3 col-form-label">Shipping Marks</label>
                                                    <div class="col-sm-9">
                                                                              <asp:TextBox autocomplete="off"  runat="server" type="text" ID="txtShippingMarks1"  Style="text-transform:uppercase "  TextMode="MultiLine" TabIndex="116"></asp:TextBox> 
                                              
 
                                                </div>
                                                                         </div>
                     <div class="form-group row">
                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">                                                                            
                                                                        </label>
                                                                        <div class="col-sm-9">
                                                                           
                                                                            <asp:TextBox autocomplete="off"  runat="server" type="text" ID="TxtSumExRate" Width="175" Text ="0.00"  TabIndex="82"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                     <div  id="pack" runat ="server" visible ="false" class="form-group row">
                                                                        <div class="col-sm-3">
                                                                            <asp:CheckBox ID="ChkPackInfo" OnCheckedChanged="ChkPackInfo_CheckedChanged" runat="server" AutoPostBack="true" Text="Packing Info"  Width="150" Style="text-transform:lowercase" /></div>
                                                                        <div class="col-sm-3">
                                                                            <asp:CheckBox ID="Chkitemcasc" runat="server" OnCheckedChanged="Chkitemcasc_CheckedChanged" AutoPostBack="true" Text="Item CASC"  Width="150" Style="text-transform:lowercase" /></div>
                                                                        <div class="col-sm-3">
                                                                            <asp:CheckBox ID="ChkTariff" runat="server" OnCheckedChanged="ChkTariff_CheckedChanged" AutoPostBack="true" Text="Tariff"  Width="150" Style="text-transform:lowercase" /></div>
                                                                        <div class="col-sm-3">
                                                                            <asp:CheckBox ID="Chklot" runat="server" OnCheckedChanged="Chklot_CheckedChanged" AutoPostBack="true" Text="LOT Identification" Width="150" Style="text-transform:lowercase" />
                                                                        </div>
            </div>
                     <div id="PackingInfo" visible="false" runat="server">
                                                                        <div class="form-group row">
                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                Outer Pack Qty 
                                                                            </label>
                                                                            <div class="col-sm-9">
                                                                                <asp:TextBox autocomplete="off"  runat="server" Width="175" ValidationGroup="Item" Text="0" type="text" ID="TxtOPQty" ></asp:TextBox>
                                            <asp:DropDownList CssClass="drop" ID="DRPOPQUOM" runat="server" Width="175" Height="25" ></asp:DropDownList>
                                            <br />
                                            <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "TxtOPQty" ID="RegularExpressionValidator64" ValidationExpression = "^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 8 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group row">
                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                In Pack Qty 
                                                                            </label>
                                                                            <div class="col-sm-9">
                                                                               <<asp:TextBox autocomplete="off"  runat="server" ValidationGroup="Item" Width="175" Text="0" type="text" ID="TxtIPQty" ></asp:TextBox>
                                            <asp:DropDownList CssClass="drop" ID="DRPIPQUOM" runat="server" Width="175" Height="25" ></asp:DropDownList>
                                           <br />
                                            <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "TxtIPQty" ID="RegularExpressionValidator63" ValidationExpression = "^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 8 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group row">
                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                Inner Pack Qty 
                                                                            </label>
                                                                            <div class="col-sm-9">
                                                                                <asp:TextBox autocomplete="off"  runat="server" Width="175"  ValidationGroup="Item" Text="0" type="text" ID="TxtINPQty"></asp:TextBox>
                                            <asp:DropDownList CssClass="drop" ID="DRPINNPQUOM" runat="server" Width="175" Height="25"></asp:DropDownList>
                                            <br />
                                            <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "TxtINPQty" ID="RegularExpressionValidator65" ValidationExpression = "^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 8 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group row">
                                                                            <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                Inmost Pack Qty 
                                                                            </label>
                                                                            <div class="col-sm-9">
                                                                                <asp:TextBox autocomplete="off"  runat="server" ValidationGroup="Item" Width="175" Text="0" type="text" ID="TxtIMPQty" ></asp:TextBox>
                                            <asp:DropDownList CssClass="drop" ID="DRPIMPQUOM" runat="server" Width="175" Height="25" ></asp:DropDownList>
                                           <br />
                                            <asp:RegularExpressionValidator Display ="Dynamic" BackColor="yellow" ControlToValidate = "TxtIMPQty" ID="RegularExpressionValidator66" ValidationExpression = "^[\s\S]{0,8}$" runat="server" ErrorMessage="Maximum 8 characters allowed." ValidationGroup="Item"></asp:RegularExpressionValidator>
                                                                            </div>
                                                                        </div>
                                                                    </div>
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
                                                        <asp:TextBox autocomplete="off"  ID="InhouseSearchItem" OnTextChanged="InhouseSearchItem_TextChanged"   AutoPostBack="true" placeholder="Search here by Code"   class="form-control" runat="server"  ></asp:TextBox>
                                                        <br />
                                                        <asp:GridView ID="InhouseGridItem" OnPageIndexChanging="InhouseGridItem_PageIndexChanging" PageSize="5" AllowPaging="True" DataKeyNames="Id"  CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                            <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>


                                                                <asp:TemplateField HeaderText="InhouseCode" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCode"  runat="server"
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
                                                                        <asp:Label ID="lblName1"  runat="server"
                                                                            Text='<%#Eval("Description")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Brand" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCRUEI"  runat="server"
                                                                            Text='<%#Eval("Brand")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="Model" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblModel"  runat="server"
                                                                            Text='<%#Eval("Model")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="DGIndicator" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCRUEI1"  runat="server"
                                                                            Text='<%#Eval("DGIndicator")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                      <asp:LinkButton ID="lnkInhouseItem" OnClick="lnkInhouseItem_Click" runat="server" CommandArgument='<%# Eval("Id") %>' >Select </asp:LinkButton>
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
                                                        <asp:TextBox autocomplete="off"  ID="HSCodeSearchItem" OnTextChanged="HSCodeSearchItem_TextChanged"   AutoPostBack="true" placeholder="Search here by Code"   class="form-control" runat="server"  ></asp:TextBox>
                                                        <br />
                                                        <asp:GridView ID="HSCodeGridItem" OnPageIndexChanging="HSCodeGridItem_PageIndexChanging"  PageSize="5" AllowPaging="True" DataKeyNames="Id" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
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
                                                                        <asp:Label ID="lblName1"  runat="server"
                                                                            Text='<%#Eval("Description")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                               <asp:TemplateField HeaderText="UOM" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblName11"  runat="server"
                                                                            Text='<%#Eval("UOM")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                      <asp:LinkButton ID="lnkHSCodeItem" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="lnkHSCodeItem_Click"    >Select </asp:LinkButton>
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
                                            <asp:TextBox autocomplete="off"  runat="server" Width="240" type="text" ID="TxtSerialNo" TabIndex="74"></asp:TextBox>
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
                         
       


                            
                 <div class="row">
                     <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="cotype" />
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                                                                                                                <ContentTemplate>
                                    <div class="col-sm-12">
                                         <div class="row Borderdiv" style="width:100%">
                                         Certificate of Origin
                                        </div>
                                       <br />
                                                               <div class="row">
                                                    <div class="col-sm-4">
                                                                                                        <p>Certificate Item Quantity</p>
                                                        <asp:TextBox autocomplete="off"   Width="170" ID="TxtCerITEMQty"  runat="server" Text="0.00" TabIndex="117" type="text" ></asp:TextBox>
                                                        <asp:DropDownList CssClass="drop"  ID="DrpCerITemUOM" Height="28"  Width="170" runat="server" TabIndex="118"  AppendDataBoundItems="true"></asp:DropDownList>
                                                            <br />
                                                            <p>Manufacturing Cost Date</p>
                                                       <asp:TextBox autocomplete="off"   ID="TxtManuDate"  Width="350" Height="28"  runat="server" AutoPostBack ="true"  TabIndex="119" type="text" OnTextChanged="TxtManuDate_TextChanged" ></asp:TextBox>
                                                         <cc1:CalendarExtender ID="CalendarExtender3" PopupButtonID="imgPopup" CssClass="cal_Theme1" runat="server" TargetControlID="TxtManuDate" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"> </cc1:CalendarExtender>  

                                                        <br />
                                                          <div id="itemvalue" visible="false" runat="server"> 
                                                         <p>CIF/FOB Item Value On Certificate</p>
                                                            <asp:TextBox autocomplete="off"   ID="txtcifitemvalue"  Text="0.00"  Width="350" Height="28" OnTextChanged="txtcifitemvalue_TextChanged" AutoPostBack="true"   runat="server" TabIndex="120" type="text" ></asp:TextBox>
                                                              </div>
                                                        <div id="txttile" visible="false" runat="server"> 
                                                           <p>Textile Category</p>
                                                            <asp:TextBox autocomplete="off"   ID="TxtTextileCat"  Width="350" Height="28"  runat="server" TabIndex="121" type="text" ></asp:TextBox>
                                                         <br />
                                                           <p>Textile Quota Quantity</p>
                                                            <asp:TextBox autocomplete="off"   ID="TxtTextileQty" Text = "0.00"  Width="350" Height="28"  runat="server" TabIndex="122" type="text" ></asp:TextBox>
                                                         <asp:DropDownList CssClass="drop"  ID="DrpTextQoutoQTYUOM" Height="28"  Width="65" runat="server" TabIndex="94"  AppendDataBoundItems="true"></asp:DropDownList>
                                                            </div>
                                                    </div>
                                                    <div class="col-sm-4">
                                                        <br />
                                                         <br />
                                                         <div id="coinvno" runat ="server" visible ="false" >
                                                          <p>Invoice Number</p>
                                                            <asp:TextBox autocomplete="off"   ID="txtinvno"  Width="350" Height="28" MaxLength="10"  runat="server" TabIndex="123" type="text" ></asp:TextBox>
                                                        </div>
                                                         <br />
                                                        <div id="coorgincriterien" runat ="server" visible ="false" >
                                                           <p>ORIGIN CRITERION</p>
                                                            <asp:TextBox autocomplete="off"   ID="txtcreteriencode"  Width="350" Height="28" MaxLength="10"  runat="server" TabIndex="124" type="text" ></asp:TextBox>
                                                            <asp:TextBox autocomplete="off"   ID="txtcodesc1"  Width="350" Height="28" MaxLength="10"  runat="server" TabIndex="125" type="text" ></asp:TextBox>
                                                            <asp:TextBox autocomplete="off"   ID="txtcodesc2"  Width="350" Height="28" MaxLength="10"  runat="server" TabIndex="126" type="text" ></asp:TextBox>
                                                            <asp:TextBox autocomplete="off"   ID="txtcodesc3"  Width="350" Height="28" MaxLength="10"  runat="server" TabIndex="127" type="text" ></asp:TextBox>
                                                        </div>
                                                             

                                                        <br />
                                                           <p>Invoice Date</p>
                                                            <asp:TextBox autocomplete="off"   ID="TxtInvDate"  Width="350" Height="28"  runat="server" AutoPostBack="true" TabIndex="128" type="text" OnTextChanged="TxtInvDate_TextChanged" ></asp:TextBox>
                                                         <cc1:CalendarExtender ID="CalendarExtender1" PopupButtonID="imgPopup" CssClass="cal_Theme1" runat="server" TargetControlID="TxtInvDate" Enabled="true" Format="dd/MM/yyyy" ClientIDMode="Inherit"> </cc1:CalendarExtender>  

                                                         <br />
                                                           <p>HS Code on Certificate</p>
                                                            <asp:TextBox autocomplete="off"   ID="TxtHSCodeCer"  Width="350" Height="28" MaxLength="10"  runat="server" TabIndex="129" type="text" ></asp:TextBox>
                                                         <br />
                                                           <p>Percentage Content of Origin Criterion</p>
                                                            <asp:TextBox autocomplete="off"   ID="TxtPerOrgCir" MaxLength="3"  Width="350" Height="28"  runat="server" TabIndex="130" type="text" ></asp:TextBox>
                                                    </div>
                                                    <div class="col-sm-4">
                                                        <p>Item Certificate Description</p>
                                                         <asp:TextBox autocomplete="off"   ID="TxtCerDes" onkeyup="countcert(this);"  TextMode="MultiLine" Style="text-transform:uppercase "  Width="300" Height="200"  runat="server" TabIndex="131" type="text" ></asp:TextBox>
                                                        <br />
                                                          <p id="certificatedesc">0 characters</p>
                                                    </div>
                                                </div>
                                           <br />
                                        <br />
                                    </div>
                                                                                                                                                    </ContentTemplate>
                            </asp:UpdatePanel>
                                </div>
            
                         <div class="row">
                                   <!-- Importer Search -->
                                       
               <div class="col-sm-8">
                   </div>
                          <div class="col-sm-4">
                              <asp:Button ID="BtnItemAdd" CssClass="btn btn-block btn-success" Visible="false"  ValidationGroup="Validation2" runat="server" Text="Add Item" OnClick="BtnItemAdd_Click" />
                           
                              </div>  
                        
                         <div class="col-sm-8">
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
                 
                                <div class="flex justify-between gap-4 md:flex-nowrap flex-wrap mt-6 mb-6">
    <asp:Button ID="btnprevitem" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" runat="server" class="btn btn-info btn-lg" OnClick="btnprevitem_Click" Text="Previous" TabIndex="174" />
    <div class="flex gap-4 flex-wrap md:flex-nowrap md:max-w-[260px] w-full">
        <asp:Button ID="btnresetitem" CssClass="bg-[#f1f5f9] bg-white border border-[#ffff] duration-300 ease-in-out flex h-10 hover:bg-transparent hover:border-gray-200 items-center justify-center md:max-w-[120px] rounded-md sa700 text-center text-gray-500 text-sm w-full" runat="server" class="btn btn-info btn-lg" OnClick="btnresetitem_Click" Text="Reset" TabIndex="176" />
        <asp:Button ID="btnsaveitem" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] bg-opacity-10 border hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-[#0560FD] text-center rounded-md text-sm sa700" runat="server" class="btn btn-info btn-lg" ValidationGroup="Item" OnClick="BtnItemAdd_Click" Text="+ Add Item" TabIndex="175" />

    </div>
    <asp:Button ID="btnnextitem" CssClass="duration-300 ease-in-out md:max-w-[120px] w-full bg-[#0560FD] border border-[#0560FD] hover:bg-transparent hover:text-[#0560FD] h-10 flex items-center justify-center text-white text-center rounded-md text-sm sa700" runat="server" class="btn btn-info btn-lg" OnClick="btnnextitem_Click" Text="Next" TabIndex="177" />

</div>



          <div id="ItemAddGrid" runat="server">
              <asp:TextBox autocomplete="off"  ID="AddItemSearch"   OnTextChanged="AddItemSearch_TextChanged" AutoPostBack="true" placeholder="Search here by Code"   class="form-control" runat="server"  ></asp:TextBox>
                                                        <br />
                                                        <asp:GridView ID="AddItemGrid" Font-Size="10"  OnRowDeleting="AddItemGrid_RowDeleting"  PageSize="50" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="AddItemGrid_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
                                                            <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>
                                                                  <asp:TemplateField HeaderText="Delete" Visible="false">
                                                                    <ItemTemplate>

                                                                        <asp:LinkButton data-target='<%#"#"+DataBinder.Eval(Container.DataItem,"Id")%>' Width="11" OnClick="imgItemDelete_Click" Height="11" ID="imgItemDelete" runat="server"><i class='fa fa-trash' style="color:red;"> </i></asp:LinkButton>



                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                  <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>

                                
                                <asp:ImageButton ImageUrl="~/IMG/edit.png" Width="11" Height="11"  OnClick="ItemEdit_Click" ID="ItemEdit" runat="server" />




                            </ItemTemplate>
                        </asp:TemplateField>
                                                                  <asp:TemplateField HeaderText="ID" Visible="false" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblID"  runat="server"
                                                                            Text='<%#Eval("Id")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="S.no" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="ItemNo"  runat="server"
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
                                                                        <asp:Label ID="Description"  runat="server"
                                                                            Text='<%#Eval("Description")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>


                                                                  <asp:TemplateField HeaderText="CO" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Contry"  runat="server"
                                                                            Text='<%#Eval("Contry")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>


                                                                 <asp:TemplateField HeaderText="Currency" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="UnitPriceCurrency"  runat="server"
                                                                            Text='<%#Eval("UnitPriceCurrency")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>


                                                                

                                                                 <asp:TemplateField HeaderText="CIFFOB" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="CIFFOB"  runat="server"
                                                                            Text='<%#Eval("CIFFOB")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>


                                                                 <asp:TemplateField HeaderText="Cert Item Qty" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="CertItemQty"  runat="server"
                                                                            Text='<%#Eval("CerItemQty")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>


                                                                 <asp:TemplateField HeaderText="Cert Item Value" SortExpression="Id">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="CertItemValue"  runat="server"
                                                                            Text='<%#Eval("ItemValue")%>'>
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
  <%--    </div>--%>
      <%--<div role="tabpanel" class="tab-pane fade" id="CPC" runat="server" visible="false">--%>
          <cc1:TabPanel ID="CPC" CssClass="ajax__tab_header" Visible ="false"  runat="server" HeaderText="CPC">
                                                            
                                                            <ContentTemplate>
        <asp:UpdatePanel ID ="cocpc" UpdateMode ="Conditional" runat ="server">
           <ContentTemplate>    
         
          <div class="row">
               <div class="col-sm-12">
                     <div class="row">
                                                    <div class="col-sm-2">
                                                        <asp:CheckBox id="chkaeo" OnCheckedChanged="chkaeo_CheckedChanged" AutoPostBack="true" runat="server" Text="AEO" Checked="false"  />
                                                        </div>
                                                    <div class="col-sm-10" id="AEO" runat="server">
                                                         <asp:Button ID="BtnAEO" runat="server" OnClick="BtnAEO_Click" Text="Add Row" />
                                                        <br />
                                                        <br />                                                        
                                                        <asp:gridview ID="AEOGrid" OnRowDeleting="AEOGrid_RowDeleting" CssClass="table table-striped table-bordered table-hover"  runat="server" ShowFooter="true" AutoGenerateColumns="false">

        <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>
            
        <asp:BoundField DataField="RowNumber" HeaderText="Row Number" />
             
        <asp:TemplateField HeaderText="Processing Code1">

            <ItemTemplate>

                <asp:TextBox autocomplete="off"  ID="TextBox1" runat="server" ></asp:TextBox>

            </ItemTemplate>

        </asp:TemplateField>

        <asp:TemplateField HeaderText="Processing Code2">

            <ItemTemplate>

                <asp:TextBox autocomplete="off"  ID="TextBox2" runat="server" ></asp:TextBox>

            </ItemTemplate>

        </asp:TemplateField>

        <asp:TemplateField HeaderText="Processing Code3">

            <ItemTemplate>

                 <asp:TextBox autocomplete="off"  ID="TextBox3" runat="server"></asp:TextBox>

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

</asp:gridview>
                                                        
                                                        </div>
                                                </div>
                    <hr />
                                                <div class="row">
                                                    <div class="col-sm-2">
                                                        <asp:CheckBox id="chkcwc" OnCheckedChanged="chkcwc_CheckedChanged" AutoPostBack="true" runat="server" Text="STS" Checked="false"/>
                                                        </div>
                                                    <div class="col-sm-10" id="CWC" runat="server">
                                                       <asp:Button ID="BtnCWC" runat="server" OnClick="BtnCWC_Click" Text="Add Row" />
                                                        <br />
                                                        <br />                                                        
                                                        <asp:gridview ID="CWCGrid" OnRowDeleting="CWCGrid_RowDeleting" CssClass="table table-striped table-bordered table-hover" runat="server" ShowFooter="true" AutoGenerateColumns="false">

        <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>
            
        <asp:BoundField DataField="RowNumber" HeaderText="Row Number" />

        <asp:TemplateField HeaderText="Processing Code1">

            <ItemTemplate>

                <asp:TextBox autocomplete="off"  ID="TextBox1" runat="server" ></asp:TextBox>

            </ItemTemplate>

        </asp:TemplateField>

        <asp:TemplateField HeaderText="Processing Code2">

            <ItemTemplate>

                <asp:TextBox autocomplete="off"  ID="TextBox2" runat="server" ></asp:TextBox>

            </ItemTemplate>

        </asp:TemplateField>

        <asp:TemplateField HeaderText="Processing Code3">

            <ItemTemplate>

                 <asp:TextBox autocomplete="off"  ID="TextBox3" runat="server" ></asp:TextBox>

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

</asp:gridview>
                                                        
                                                        </div>
                                                </div>
                     <hr />
                   <div class="row">
                                                    <div class="col-sm-2">
                                                        <asp:CheckBox id="ChkSea1" OnCheckedChanged="ChkSea_CheckedChanged" AutoPostBack="true" runat="server" Text="SEA STORE" Checked="false" />
                                                        </div>
                                                    <div class="col-sm-10" id="SEA" runat="server">
                                                       <asp:Button ID="btnSeaStr" runat="server" OnClick="btnSeaStr_Click" Text="Add Row" />
                                                        <br />
                                                        <br />                                                        
                                                        <asp:gridview ID="SeaGrid" OnRowDeleting="SeaGrid_RowDeleting" CssClass="table table-striped table-bordered table-hover" runat="server" ShowFooter="true" AutoGenerateColumns="false">

        <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /><Columns>
            
        <asp:BoundField DataField="RowNumber" HeaderText="Row Number" />

        <asp:TemplateField HeaderText="Processing Code1">

            <ItemTemplate>

                <asp:TextBox autocomplete="off"  ID="TextBox1" runat="server" ></asp:TextBox>

            </ItemTemplate>

        </asp:TemplateField>

        <asp:TemplateField HeaderText="Processing Code2">

            <ItemTemplate>

                <asp:TextBox autocomplete="off"  ID="TextBox2" runat="server" ></asp:TextBox>

            </ItemTemplate>

        </asp:TemplateField>

        <asp:TemplateField HeaderText="Processing Code3">

            <ItemTemplate>

                 <asp:TextBox autocomplete="off"  ID="TextBox3" runat="server" ></asp:TextBox>

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

</asp:gridview>
                                                        
                                                        </div>
                                                </div>
                   <hr />
                                                <div class="row">
                                                    <div class="col-sm-2">
                                                        <asp:CheckBox id="chkcnb" runat="server" Text="CNB" Checked="false"  />
                                                        </div>
                                                    <div class="col-sm-10">                                                        
                                                        
                                                        </div>
                                                </div>
                </div>
          </div>
                 
                        <center>
<div class="btn-group btn-group-lg">
                                                                    <asp:Button ID="btnprevcpc" CssClass="nn"  runat="server" class="btn btn-info btn-lg" OnClick="btnprevcpc_Click" Text="Previous"  />
                                                                    <asp:Button ID="btnsavecpc" CssClass="nn"  runat="server" class="btn btn-info btn-lg" OnClick="btnsavecpc_Click" Text="Save"  />
                                                                    <asp:Button ID="btnresetcpc" CssClass="nn"  runat="server" class="btn btn-info btn-lg" OnClick="btnresetcpc_Click" Text="Reset" Visible="false"  />
                                                                    <asp:Button ID="btnnextcpc" CssClass="nn"  runat="server" class="btn btn-info btn-lg" OnClick="btnnextcpc_Click" Text="Next"  />

                                                                </div></center>

</ContentTemplate>
       </asp:UpdatePanel>  

</ContentTemplate>
                                                        </cc1:TabPanel>
     <%-- </div>--%>
      <%--<div role="tabpanel" class="tab-pane fade" id="Summary">--%>
            <cc1:TabPanel ID="Summary" CssClass="ajax__tab_header"  runat="server" HeaderText="Summary">
                                                            
                                                            <ContentTemplate>
          <asp:UpdatePanel ID ="cosummery" UpdateMode ="Conditional" runat ="server">
           <ContentTemplate>      

           <div class="col-sm-12">
                    

                                <div class="row">
                                    <div class="col-sm-12">
                                       
                                       
                                                <div class="row">
                                                    
                                                    <div class="col-sm-12">
                                                         <div class="row Borderdiv" style="width:100%">
                                          SUMMARY
                                        </div>
                                                       <%-- <p>Number of Invoices</p>--%>
                                                        <asp:TextBox autocomplete="off"  runat="server" Visible="false" Enabled="false" Width="200" type="text" ID="txtnoofinv" ></asp:TextBox>
                                                        <br />
                                                       <div class="form-group row">
                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                           No of Items
                                                                        </label>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox autocomplete="off"  runat="server" Enabled="false" Width="100%"  Text="0.00"  type="text" ID="txtnoofitm" ></asp:TextBox>
                                                                        </div>
                                                            <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                           Sum of Item Amount
                                                                        </label>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox autocomplete="off"  runat="server" Enabled="false"  Text="0.00"   Width="100%"  type="text" ID="txtitmAmt" ></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                        
                                                        <div class="form-group row">
                                                                        <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                           Item Value on Cert
                                                                        </label>
                                                                        <div class="col-sm-3">
                                                                            <asp:TextBox autocomplete="off"  runat="server" Enabled="false" Width="100%"  Text="0.00"  type="text" ID="txtitemvaluecert" ></asp:TextBox>
                                                                        </div>
                                                           
                                                                    </div>



                                                     <%--   <p>Sum Of InvoiceAmount</p>--%>
                                                        <div id="div3" runat = "server" Visible="false" ></div>
                                                        <%--<asp:TextBox autocomplete="off"  runat="server" type="text" ID="txtinvAmt" TabIndex="1"></asp:TextBox>--%>
                                                        
                                                        
                                                        <div class="form-group row">
                                                                       
                                                                    </div>
                                                        
                                                        <%--<p>Toatl Invoice CIF Value</p>--%>
                                                        <asp:TextBox autocomplete="off"  runat="server" Visible="false" Enabled="false"  Text="0.00"  Width="200" type="text" ID="txtcifVal" ></asp:TextBox>
                                                        <br />
                                                       
                                                       
                                                        </div>
                                                   </div>
                                         <div class="row">
                                                    <div class="col-sm-12">
                                         
                                                         
                                                             
                                         <p style="font-weight:bold"> Certificate Additional Information &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;Cross Reference  <asp:TextBox autocomplete="off"  runat="server" type="text" ID="TxtGrossReference" Style="text-transform: uppercase"></asp:TextBox></p>


                                       
                                       
                                                
                                                <asp:TextBox autocomplete="off"  ID="txttrdremrk" onkeyup="countChars(this);" TextMode="MultiLine" Style="text-transform :uppercase" runat="server"  Height="70" Width="100%" TabIndex="135"></asp:TextBox>
                                                <br />
                                          <p id="certificate">0 characters</p>
                                        Internal Reference

                                       
                                       
                                                
                                                <asp:TextBox autocomplete="off"  ID="txtinternal" runat="server"  Height="70" Width="100%" TabIndex="136"></asp:TextBox>
                                                <br />
                                      
                                               
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
                                                                                    Certificate Type

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
                                                                                    CO Type
                                                                                </label>
                                                                                <div class="col-sm-9">
                                                                                    <asp:Label ID="lblhblValue" runat="server" Width="80%" Font-Size="Medium" Font-Bold="true"></asp:Label>
                                                                                    <%--<asp:TextBox autocomplete="off"  runat="server" Enabled="false" Width="80%" type="text" ID="TextBox26" TabIndex="1"></asp:TextBox>--%>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-sm-6">
                                                                            <div class="form-group row">
                                                                                <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                    Currency Code


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
                                                                                    Prev Permit No


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
                                                                            <div class="form-group row">
                                                                                <label for="staticEmail" class="col-sm-3 col-form-label">
                                                                                    Transport Mode

                                                                                </label>
                                                                                <div class="col-sm-9">
                                                                                    <asp:Label ID="lblTotItemGst" runat="server" Width="80%" Font-Size="Medium" Font-Bold="true"></asp:Label>
                                                                                    <%--<asp:TextBox autocomplete="off"  runat="server" Enabled="false" Width="100" type="text" ID="TextBox31" TabIndex="1"></asp:TextBox>--%>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-sm-12">
                                                                            <div class="alert alert-danger">
                                                                                <asp:CheckBox ID="chkalrt" runat="server" Checked="false" TabIndex="138" />
  <strong></strong> (1) I/We declare that all particulars in this application are true and correct.<br />
&nbsp;&nbsp;&nbsp;(2) I/We declare that all the product(s) to be exported in this Application has/have been registered with the TTSB of Singapore Customs and qualify(s) for the respective Certificate applied for.
                                                                            </div>
                                                                        </div>
                                                                      
                                                                        </div>
                                                                    </div>
                         
                          <%--<div class="row">
                                    <div class="col-sm-12">
                                          <div class="row Borderdiv" style="width:100%">
                                          DECLARATION INDICATOR
                                        </div>
                                       
                                               <br />
                                        <br />
                                              
                                                <div class="alert alert-danger">
                                                    
</div>
                                               
                                        </div>
                              </div>--%>             
                          
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


                 <br />
                                                                        <div class="col-sm-12">
                                                                            <div class="row Borderdiv" style="width: 100%">
                                                                            </div>
 </ContentTemplate>

       </asp:UpdatePanel>
</ContentTemplate>
                                                        </cc1:TabPanel>
  <%--</div>--%>
                      <%-- <div role="tabpanel" class="tab-pane fade" id="Amend">--%>
                             <cc1:TabPanel ID="Amend" CssClass="ajax__tab_header"  runat="server" Visible ="false" HeaderText="Amend">
                                                            
                                                            <ContentTemplate>
                           <asp:UpdatePanel ID ="coamend" UpdateMode ="Conditional" runat ="server">
           <ContentTemplate>  
        <div class="row">
            <div class="col-sm-12" >
                  <div class="row Borderdiv" style="width:100%">Update Information</div>
                        <div class="row">               
                          <div class="col-sm-6" >
                               <p>Amendment Count</p>
                               <asp:TextBox autocomplete="off"  runat="server"  Width="300" type="text" ID="TextBox5" TabIndex="143"></asp:TextBox>
                                <br />
                              <p>Update Indicator</p>
                               <asp:TextBox autocomplete="off"  runat="server"  Width="300" type="text" ID="TextBox6" TabIndex="144"></asp:TextBox>
                                <br />
                          </div>
                           <div class="col-sm-6" >
                                <p>Permit Number</p>
                               <asp:TextBox autocomplete="off"  runat="server"  Width="300" type="text" ID="TextBox7" TabIndex="145"></asp:TextBox>
                                <br />
                              <p>Replacement Permit Number</p>
                               <asp:TextBox autocomplete="off"  runat="server"  Width="300" type="text" ID="TextBox8" TabIndex="146"></asp:TextBox>
                                <br />
                           </div>
                        </div>

            </div>
        </div>
     <br />
      <div class="row">
            <div class="col-sm-12" >
                <div class="row Borderdiv" style="width:100%">Amendment Information</div>
                  <p>Description Of Reason</p>
                  <asp:TextBox autocomplete="off"  runat="server" TextMode="MultiLine" Width="100%" type="text" Style="text-transform:uppercase " ID="TextBox9" TabIndex="147"></asp:TextBox>
                  <br />
                <asp:CheckBox ID="ChkPermitvalEx" runat="server" TabIndex="109" Text="Permit Validity Extension" />
                <br />
                <p>Extend Import Period (Reason for Extension of validity for Temporary / Exhibit Cargoes)</p>
                 <asp:TextBox autocomplete="off"  runat="server" TextMode="MultiLine" Width="100%" type="text" ID="TextBox10" TabIndex="148"></asp:TextBox>
                <br /> <br />
                <div class="row Borderdiv" style="width:100%">Declaration Indicator</div>
                 <div class="alert alert-danger">
                                                    <asp:CheckBox ID="CheckBox2" runat="server" Checked="false" TabIndex="149" />
  <strong></strong> I/We declare that all particulars in this application are true and correct
</div>
            </div>
      </div>
               <center>
   <div class="btn-group btn-group-lg">
                                                                            <asp:Button ID="Button3" CssClass="nn"  runat="server" class="btn btn-info btn-lg" OnClick="btnprevsum_Click" Text="Previous" TabIndex="150" />
                                                                            <asp:Button ID="Button4" Visible="false" CssClass="nn"  runat="server" class="btn btn-info btn-lg" OnClick="btnsavesum_Click" Text="Save" TabIndex="151" />
                                                                            <asp:Button ID="Button5" CssClass="nn"  runat="server" class="btn btn-info btn-lg" OnClick="btnresetsum_Click" Text="Reset" TabIndex="152" />
                                                                            <asp:Button ID="Button6" CssClass="nn"  runat="server" class="btn btn-info btn-lg" OnClick="btnnextsum_Click" Text="Next" TabIndex="153" />

                                                                        </div></center>

</ContentTemplate>
       </asp:UpdatePanel>
</ContentTemplate>
                                                        </cc1:TabPanel>
<%-- </div>--%>

      <%--  <div role="tabpanel" class="tab-pane fade " id="Cancel">--%>
            <cc1:TabPanel ID="Cancel" CssClass="ajax__tab_header"  runat="server" Visible ="false" HeaderText="Cancel">
                                                            
                                                            <ContentTemplate>
   <asp:UpdatePanel ID ="cocancel" UpdateMode ="Conditional" runat ="server">
           <ContentTemplate>  
               <div class="row">
            <div class="col-sm-12" >
                  <div class="row Borderdiv" style="width:100%">Update Information</div>
                        <div class="row">               
                          <div class="col-sm-6" >
                               <p>Update Indicator</p>
                               <asp:TextBox autocomplete="off"  runat="server"  Width="300" type="text" ID="TextBox11" TabIndex="154"></asp:TextBox>
                                <br />
                             
                               
                          </div>
                           <div class="col-sm-6" >
                                <p>Permit Number</p>
                               <asp:TextBox autocomplete="off"  runat="server"  Width="300" type="text" ID="TextBox13" TabIndex="155"></asp:TextBox>
                                <br />
                              <p>Replacement Permit Number</p>
                               <asp:TextBox autocomplete="off"  runat="server"  Width="300" type="text" ID="TextBox14" TabIndex="156"></asp:TextBox>
                                <br />
                           </div>
                        </div>

            </div>
        </div>
     <br />
             <div class="row">
                    <div class="row Borderdiv" style="width:100%">Cancellation Information</div>
            <div class="col-sm-6" >
                 <p>Reason For Cancellation</p>
                <asp:DropDownList CssClass="drop" ID="DrpReasonCancel" Width="300" TabIndex="157" Height="26" runat="server"></asp:DropDownList>
                </div>
                 <div class="col-sm-6" >
                     <p>Description For Reason</p>
                      <asp:TextBox autocomplete="off"  runat="server" TextMode="MultiLine" Width="100%" type="text" ID="TextBox12" TabIndex="158"></asp:TextBox>
                <br /> 
                </div>
                 </div>
            <br />
             <div class="row">
                                    <div class="col-sm-12" id="Div8" runat="server">
                                      
                                                <div class="row">
                                                    
                                                  
                                                    <div class="col-sm-12">
                                                         <div class="row Borderdiv"  style="width:100%">
                                          Referance Document
                                        </div>
                                                        
                                                        <div class="row">
                                                            <div class="col-sm-5">
                                                                <p>Document Type</p> 
                                                                <asp:DropDownList CssClass="drop" ID="DropDownList1"  BackColor="#e8f0fe"  Width="250" Height="32" AppendDataBoundItems="true" TabIndex="117" runat="server">
                                                                </asp:DropDownList><br />
                                                                <asp:RequiredFieldValidator BackColor="Red"  ID="RequiredFieldValidator5" runat="server" ControlToValidate="DropDownList1" InitialValue="0" ErrorMessage="Header --> Doc Type" ValidationGroup="Validationbtn"></asp:RequiredFieldValidator>
                                                            </div>
                                                            <div class="col-sm-5">
                                                                <p>Uplaod Document</p>
                                                                <asp:FileUpload ID="FileUpload2"  BackColor="#e8f0fe" runat="server" TabIndex="118" class="btn" AllowMultiple="true" />
                                                                <asp:RequiredFieldValidator BackColor="Red"  ID="RequiredFieldValidator67" runat="server" ControlToValidate="FileUpload2" ErrorMessage="Header -->Upload Doc" ValidationGroup="Validationbtn"></asp:RequiredFieldValidator>
                                                            </div>
                                                            <div class="col-sm-2">
                                                                <p>Uplaod</p>
                                                                <asp:Button runat="server" ID="BtnCancelUp" ValidationGroup="Validationbtn" class="btn btn-success" TabIndex="119" Text="Upload" OnClick="BtnCancelUp_Click" />
                                                               
                                                            </div>
                                                        </div>


                                                        <hr />
                                                        <asp:GridView ID="GridCancelDoc" PageSize="5" OnRowDeleting="GridCancelDoc_RowDeleting" AllowPaging="True" DataKeyNames="Id" OnPageIndexChanging="GridCancelDoc_PageIndexChanging"  CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="false">
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
                                         <div class="row Borderdiv" style="width:100%">
                                          ADDITIONAL RECIPIENTS
                                        </div>
                                       <br />
                                                <div class="row">
                                                    <div class="col-sm-4">
                                                        <p>RECIPIENTS 1</p>
                                                        <asp:TextBox autocomplete="off"  ID="TextBox15"  Width="265" runat="server" TabIndex="120" type="text" ></asp:TextBox>

                                                        <br />
                                                    </div>
                                                    <div class="col-sm-4">
                                                        <p>RECIPIENTS 2</p>
                                                        <asp:TextBox autocomplete="off"  ID="TextBox16"  Width="265"  runat="server" TabIndex="121" type="text" ></asp:TextBox>

                                                        <br />
                                                    </div>
                                                    <div class="col-sm-4">
                                                        <p>RECIPIENTS 3</p>
                                                        <asp:TextBox autocomplete="off"  ID="TextBox17"  Width="265" runat="server"     TabIndex="122" type="text" ></asp:TextBox>

                                                        <br />
                                                    </div>
                                                </div>
                                           <br />
                                        <br />
                                    </div>
                                </div>
            <br />
      <div class="row">
            <div class="col-sm-12" >
                 <div class="row Borderdiv" style="width:100%">Declarent Indicator</div>
                  <div class="alert alert-danger">
                                                    <asp:CheckBox ID="CheckBox4" runat="server" Checked="false" TabIndex="123" />
  <strong></strong> I/We declare that all particulars in this application are true and correct
</div>
               
            </div>
      </div>
  <ul class="pager">
    <li class="previous"><a href="#Amend"  data-toggle="tab" title="Previous">Previous</a></li>
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
                                    


                    </div>






                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
